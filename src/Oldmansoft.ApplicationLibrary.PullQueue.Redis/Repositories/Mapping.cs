using System;

namespace Oldmansoft.ApplicationLibrary.PullQueue.Redis.Repositories
{
    class Mapping : ClassicDomain.Driver.Redis.Context
    {
        protected override void OnModelCreating()
        {
            Add<Domain.Queue, Guid>(o => o.Id);
        }
    }
}
