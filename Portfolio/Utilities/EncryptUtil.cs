using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Utilities
{
	public class EncryptUtil
	{
		public EncryptUtil()
		{

		}

		/// <summary>
		/// 암호화 결과 리턴
		/// </summary>
		/// <param name="Parameter"></param>
		/// <param name="Salt"></param>
		/// <returns></returns>
		public static string Encrypt(string Parameter, string Salt)
		{
			byte[] PasswordValue = Encoding.Default.GetBytes(Parameter);
			byte[] SaltValue = Encoding.Default.GetBytes(Salt);
			byte[] CombineValue = SaltValue.Concat(PasswordValue).ToArray();

			// Salt와 Password를 합친 암호화 결과
			byte[] HashValue; 
			
			string result = string.Empty;

			using (SHA256 sha256 = SHA256.Create())
			{
				HashValue = sha256.ComputeHash(CombineValue);
			}

			for (int i = 0; i < HashValue.Length; i++)
			{
				result += HashValue[i].ToString("x2");
			}

			return result;
		}
	}
}
