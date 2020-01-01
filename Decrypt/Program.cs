using System;
using System.IO;
using System.Text;

namespace Decrypt
{
    class Program
    {
        static void Main(string[] args)
        {
			encrypt();
		}

		private static void encrypt()
		{
			int i = 0;
			int j = 0;
			string[] array = new string[]
			{
				"secret_file_1",
				"secret_file_2",
				"secret_file_3"
			};
			char[][] array2 = new char[][]
			{
				new char[]
				{
					'f',
					'R',
					'E',
					'y'
				},
				new char[]
				{
					'B',
					'o',
					'l',
					'T',
					'o',
					'n'
				},
				new char[]
				{
					'C',
					'A',
					's',
					'T',
					'a',
					'm',
					'E',
					'R',
					'e'
				}
			};
			while (j < 3)
			{
				string s = File.ReadAllText(array[j]);
				byte[] bytes = Encoding.UTF8.GetBytes(s);
				string text = Convert.ToBase64String(bytes);
				while (i < 3)
				{
					char[] value = array2[i]; //key 
					string s2 = new string(value); // key as string
					byte[] bytes2 = Encoding.ASCII.GetBytes(s2); //key as bytes
					int num = bytes2.Length; //key bytes number
					byte[] array3 = Convert.FromBase64String(text); //
					int num2 = array3.Length;
					byte[] array4 = new byte[num2];
					for (int k = 0; k < num2; k++)
					{
						int num3 = k % num;
						array4[k] = (byte)(array3[k] ^ bytes2[num3]);
					}
					text = Convert.ToBase64String(array4);
					i++;
				}
				i = 0;
				Console.WriteLine(text);
				File.WriteAllText(array[j], text);
				j++;
			}
		}
	}
}
