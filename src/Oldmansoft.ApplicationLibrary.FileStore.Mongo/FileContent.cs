﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;

namespace Oldmansoft.ApplicationLibrary.FileStore.Mongo
{
    public class FileContent : IFileContent
    {
        private static ConcurrentDictionary<string, MongoServer> Servers { get; set; }

        static FileContent()
        {
            Servers = new ConcurrentDictionary<string, MongoServer>();
        }

        private MongoGridFS Fs { get; set; }

        public FileContent(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString)) throw new ArgumentNullException();

            string databaseName;
            MongoServerSettings setting;
            if (connectionString.IndexOf("mongodb://") > -1)
            {
                setting = MongoServerSettings.FromUrl(new MongoUrl(connectionString));
                databaseName = new Uri(connectionString).GetDatabase();
            }
            else
            {
                var connectionContext = new ClassicDomain.Configuration.ConnectionString(null, connectionString, 27017);
                databaseName = connectionContext.InitialCatalog;
                var urlBuilder = new MongoUrlBuilder();
                var servers = new List<MongoServerAddress>();
                foreach (var dataSource in connectionContext.DataSource)
                {
                    servers.Add(new MongoServerAddress(dataSource.Host, dataSource.Port));
                }
                urlBuilder.Servers = servers;
                if (!string.IsNullOrEmpty(connectionContext.UserID))
                {
                    urlBuilder.Username = connectionContext.UserID;
                    urlBuilder.Password = connectionContext.Password;
                }

                setting = MongoServerSettings.FromUrl(urlBuilder.ToMongoUrl());
                setting.WriteConcern = WriteConcern.Acknowledged;
            }

            MongoServer server;
            if (!Servers.TryGetValue(connectionString, out server))
            {
                server = new MongoServer(setting);
                Servers.TryAdd(connectionString, server);
            }
            Fs = server.GetDatabase(databaseName).GetGridFS(new MongoGridFSSettings() { Root = "FileContent" });
        }

        public Stream Load(string location)
        {
            return Fs.OpenRead(location);
        }

        public void Remove(string location)
        {
            if (string.IsNullOrEmpty(location)) throw new ArgumentNullException();
            Fs.Delete(location);
        }

        public string Save(Stream stream)
        {
            var location = ClassicDomain.Driver.GuidGenerator.Default.Create(ClassicDomain.Driver.StorageMapping.MongoMapping).ToString("N");
            Fs.Upload(stream, location);
            return location;
        }
    }
}
