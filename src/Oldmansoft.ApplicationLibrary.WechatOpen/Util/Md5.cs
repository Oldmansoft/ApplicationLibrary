using System.Collections.Generic;

namespace Oldmansoft.ApplicationLibrary.WechatOpen.Util
{
    /// <summary>
    /// System.Security.Cryptography.MD5 替代加密方案，规避 FIPS 策略
    /// </summary>
    public class Md5
    {
        private uint A;

        private uint B;

        private uint C;

        private uint D;

        private const int S11 = 7;

        private const int S12 = 12;

        private const int S13 = 17;

        private const int S14 = 22;

        private const int S21 = 5;

        private const int S22 = 9;

        private const int S23 = 14;

        private const int S24 = 20;

        private const int S31 = 4;

        private const int S32 = 11;

        private const int S33 = 16;

        private const int S34 = 23;

        private const int S41 = 6;

        private const int S42 = 10;

        private const int S43 = 15;

        private const int S44 = 21;

        // F, G, H and I are basic MD5 functions.

        // F(X,Y,Z) =(X&Y)|((~X)&Z)

        // G(X,Y,Z) =(X&Z)|(Y&(~Z))

        // H(X,Y,Z) =X^Y^Z

        // I(X,Y,Z)=Y^(X|(~Z))

        // (& AND，| OR，~NOT，^XOR)

        private uint F(uint x, uint y, uint z)
        {
            return (x & y) | ((~x) & z);
        }

        private uint G(uint x, uint y, uint z)
        {
            return (x & z) | (y & (~z));
        }

        private uint H(uint x, uint y, uint z)
        {
            return x ^ y ^ z;
        }

        private uint I(uint x, uint y, uint z)
        {
            return y ^ (x | (~z));
        }

        // FF, GG, HH, and II transformations for rounds 1, 2, 3, and 4.

        // Rotation is separate from addition to prevent recomputation.

        private void FF(ref uint a, uint b, uint c, uint d, uint mj, int s, uint ti)
        {
            a = a + F(b, c, d) + mj + ti;
            a = a << s | a >> (32 - s);
            a += b;
        }

        private void GG(ref uint a, uint b, uint c, uint d, uint mj, int s, uint ti)
        {
            a = a + G(b, c, d) + mj + ti;
            a = a << s | a >> (32 - s);
            a += b;
        }

        private void HH(ref uint a, uint b, uint c, uint d, uint mj, int s, uint ti)
        {
            a = a + H(b, c, d) + mj + ti;
            a = a << s | a >> (32 - s);
            a += b;
        }

        private void II(ref uint a, uint b, uint c, uint d, uint mj, int s, uint ti)
        {
            a = a + I(b, c, d) + mj + ti;
            a = a << s | a >> (32 - s);
            a += b;
        }

        private void MD5_Init()
        {
            A = 0x67452301; //in memory, this is 0x01234567
            B = 0xefcdab89; //in memory, this is 0x89abcdef
            C = 0x98badcfe; //in memory, this is 0xfedcba98
            D = 0x10325476; //in memory, this is 0x76543210
        }

        private uint[] MD5_Append(byte[] input)
        {
            var zeros = 0;
            var ones = 1;
            var size = 0;
            var n = input.Length;
            var m = n % 64;
            if (m < 56)
            {
                zeros = 55 - m;
                size = n - m + 64;
            }
            else if (m == 56)
            {
                zeros = 63;
                ones = 1;
                size = n + 8 + 64;
            }
            else
            {
                zeros = 63 - m + 56;
                size = n + 64 - m + 64;
            }

            var bs = new List<byte>(input);
            if (ones == 1)
            {
                bs.Add(0x80); // 0x80 = 10000000
            }
            for (int i = 0; i < zeros; i++)
            {
                bs.Add(0);
            }

            var N = (ulong)n * 8;
            var h1 = (byte)(N & 0xFF);
            var h2 = (byte)((N >> 8) & 0xFF);
            var h3 = (byte)((N >> 16) & 0xFF);
            var h4 = (byte)((N >> 24) & 0xFF);
            var h5 = (byte)((N >> 32) & 0xFF);
            var h6 = (byte)((N >> 40) & 0xFF);
            var h7 = (byte)((N >> 48) & 0xFF);
            var h8 = (byte)(N >> 56);
            bs.Add(h1);
            bs.Add(h2);
            bs.Add(h3);
            bs.Add(h4);
            bs.Add(h5);
            bs.Add(h6);
            bs.Add(h7);
            bs.Add(h8);

            var ts = bs.ToArray();
            // Decodes input (byte[]) into output (uint[]). Assumes len is
            // a multiple of 4.
            var output = new uint[size / 4];
            for (long i = 0, j = 0; i < size; j++, i += 4)
            {
                output[j] = (uint)(ts[i] | ts[i + 1] << 8 | ts[i + 2] << 16 | ts[i + 3] << 24);
            }

            return output;
        }

        private uint[] MD5_Trasform(uint[] x)
        {
            uint a, b, c, d;
            for (var k = 0; k < x.Length; k += 16)
            {
                a = A;
                b = B;
                c = C;
                d = D;
                //Round 1
                FF(ref a, b, c, d, x[k + 0], S11, 0xd76aa478); // 1
                FF(ref d, a, b, c, x[k + 1], S12, 0xe8c7b756); // 2
                FF(ref c, d, a, b, x[k + 2], S13, 0x242070db); // 3
                FF(ref b, c, d, a, x[k + 3], S14, 0xc1bdceee); // 4
                FF(ref a, b, c, d, x[k + 4], S11, 0xf57c0faf); // 5
                FF(ref d, a, b, c, x[k + 5], S12, 0x4787c62a); // 6
                FF(ref c, d, a, b, x[k + 6], S13, 0xa8304613); // 7
                FF(ref b, c, d, a, x[k + 7], S14, 0xfd469501); // 8
                FF(ref a, b, c, d, x[k + 8], S11, 0x698098d8); // 9
                FF(ref d, a, b, c, x[k + 9], S12, 0x8b44f7af); // 10
                FF(ref c, d, a, b, x[k + 10], S13, 0xffff5bb1); // 11
                FF(ref b, c, d, a, x[k + 11], S14, 0x895cd7be); // 12
                FF(ref a, b, c, d, x[k + 12], S11, 0x6b901122); // 13
                FF(ref d, a, b, c, x[k + 13], S12, 0xfd987193); // 14
                FF(ref c, d, a, b, x[k + 14], S13, 0xa679438e); // 15
                FF(ref b, c, d, a, x[k + 15], S14, 0x49b40821); // 16
                // Round 2
                GG(ref a, b, c, d, x[k + 1], S21, 0xf61e2562); // 17
                GG(ref d, a, b, c, x[k + 6], S22, 0xc040b340); // 18
                GG(ref c, d, a, b, x[k + 11], S23, 0x265e5a51); // 19
                GG(ref b, c, d, a, x[k + 0], S24, 0xe9b6c7aa); // 20
                GG(ref a, b, c, d, x[k + 5], S21, 0xd62f105d); // 21
                GG(ref d, a, b, c, x[k + 10], S22, 0x2441453); // 22
                GG(ref c, d, a, b, x[k + 15], S23, 0xd8a1e681); // 23
                GG(ref b, c, d, a, x[k + 4], S24, 0xe7d3fbc8); // 24
                GG(ref a, b, c, d, x[k + 9], S21, 0x21e1cde6); // 25
                GG(ref d, a, b, c, x[k + 14], S22, 0xc33707d6); // 26
                GG(ref c, d, a, b, x[k + 3], S23, 0xf4d50d87); // 27
                GG(ref b, c, d, a, x[k + 8], S24, 0x455a14ed); // 28
                GG(ref a, b, c, d, x[k + 13], S21, 0xa9e3e905); // 29
                GG(ref d, a, b, c, x[k + 2], S22, 0xfcefa3f8); // 30
                GG(ref c, d, a, b, x[k + 7], S23, 0x676f02d9); // 31
                GG(ref b, c, d, a, x[k + 12], S24, 0x8d2a4c8a); // 32
                // Round 3
                HH(ref a, b, c, d, x[k + 5], S31, 0xfffa3942); // 33
                HH(ref d, a, b, c, x[k + 8], S32, 0x8771f681); // 34
                HH(ref c, d, a, b, x[k + 11], S33, 0x6d9d6122); // 35
                HH(ref b, c, d, a, x[k + 14], S34, 0xfde5380c); // 36
                HH(ref a, b, c, d, x[k + 1], S31, 0xa4beea44); // 37
                HH(ref d, a, b, c, x[k + 4], S32, 0x4bdecfa9); // 38
                HH(ref c, d, a, b, x[k + 7], S33, 0xf6bb4b60); // 39
                HH(ref b, c, d, a, x[k + 10], S34, 0xbebfbc70); // 40
                HH(ref a, b, c, d, x[k + 13], S31, 0x289b7ec6); // 41
                HH(ref d, a, b, c, x[k + 0], S32, 0xeaa127fa); // 42
                HH(ref c, d, a, b, x[k + 3], S33, 0xd4ef3085); // 43
                HH(ref b, c, d, a, x[k + 6], S34, 0x4881d05); // 44
                HH(ref a, b, c, d, x[k + 9], S31, 0xd9d4d039); // 45
                HH(ref d, a, b, c, x[k + 12], S32, 0xe6db99e5); // 46
                HH(ref c, d, a, b, x[k + 15], S33, 0x1fa27cf8); // 47
                HH(ref b, c, d, a, x[k + 2], S34, 0xc4ac5665); // 48
                // Round 4
                II(ref a, b, c, d, x[k + 0], S41, 0xf4292244); // 49
                II(ref d, a, b, c, x[k + 7], S42, 0x432aff97); // 50
                II(ref c, d, a, b, x[k + 14], S43, 0xab9423a7); // 51
                II(ref b, c, d, a, x[k + 5], S44, 0xfc93a039); // 52
                II(ref a, b, c, d, x[k + 12], S41, 0x655b59c3); // 53
                II(ref d, a, b, c, x[k + 3], S42, 0x8f0ccc92); // 54
                II(ref c, d, a, b, x[k + 10], S43, 0xffeff47d); // 55
                II(ref b, c, d, a, x[k + 1], S44, 0x85845dd1); // 56
                II(ref a, b, c, d, x[k + 8], S41, 0x6fa87e4f); // 57
                II(ref d, a, b, c, x[k + 15], S42, 0xfe2ce6e0); // 58
                II(ref c, d, a, b, x[k + 6], S43, 0xa3014314); // 59
                II(ref b, c, d, a, x[k + 13], S44, 0x4e0811a1); // 60
                II(ref a, b, c, d, x[k + 4], S41, 0xf7537e82); // 61
                II(ref d, a, b, c, x[k + 11], S42, 0xbd3af235); // 62
                II(ref c, d, a, b, x[k + 2], S43, 0x2ad7d2bb); // 63
                II(ref b, c, d, a, x[k + 9], S44, 0xeb86d391); // 64
                A += a;
                B += b;
                C += c;
                D += d;
            }

            return new uint[] { A, B, C, D };
        }

        /// <summary>
        /// 哈希计算
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public byte[] ComputeHash(byte[] input)
        {
            MD5_Init();
            var block = MD5_Append(input);
            var bits = MD5_Trasform(block);
            // Encodes bits (uint[]) into output (byte[]). Assumes len is
            // a multiple of 4.
            var output = new byte[bits.Length * 4];

            for (int i = 0, j = 0; i < bits.Length; i++, j += 4)
            {
                output[j] = (byte)(bits[i] & 0xff);
                output[j + 1] = (byte)((bits[i] >> 8) & 0xff);
                output[j + 2] = (byte)((bits[i] >> 16) & 0xff);
                output[j + 3] = (byte)((bits[i] >> 24) & 0xff);
            }

            return output;
        }
    }
}
