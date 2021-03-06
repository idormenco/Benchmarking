﻿using System.Security.Cryptography;
using System.Text;
using BCrypt.Net;

namespace Benchmarking.SharedLibrary.Hashing
{
	public static class Hashing
	{
		public static string Sha256(string value)
		{
			StringBuilder Sb = new StringBuilder();

			using (var hash = SHA256.Create())
			{
				Encoding enc = Encoding.UTF8;
				byte[] result = hash.ComputeHash(enc.GetBytes(value));

				foreach (byte b in result)
				{
					Sb.Append(b.ToString("x2"));
				}
			}

			return Sb.ToString();
		}

		public static string BlowFish(string value)
		{
			return BCrypt.Net.BCrypt.HashPassword(value);
		}

		public static string BlowFish(string value,int workFactor)
		{
			return BCrypt.Net.BCrypt.HashPassword(value, workFactor);
		}
	}
}