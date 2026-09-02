using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02005FE0 RID: 24544
	[NullableContext(1)]
	[Nullable(0)]
	public class Converter
	{
		// Token: 0x0603DC72 RID: 253042 RVA: 0x00FBD930 File Offset: 0x00FBBB30
		public static string Convert(string inputStr, int baseNum, int to)
		{
			if (baseNum == to)
			{
				return inputStr;
			}
			if (to < 2 || to > 62 || baseNum < 2 || baseNum > 62)
			{
				return "";
			}
			double num = Converter.ConvertToDecimal(inputStr, baseNum);
			string text = "";
			while (num > 0.0)
			{
				char c = Converter.CodeTable[(int)num % to];
				text = new ReadOnlySpan<char>(ref c) + text;
				num = Math.Floor(num / (double)to);
			}
			return text;
		}

		// Token: 0x0603DC73 RID: 253043 RVA: 0x00FBD9A4 File Offset: 0x00FBBBA4
		private static double ConvertToDecimal(string inputStr, int baseNum)
		{
			double num = 0.0;
			for (int i = 0; i < inputStr.Length; i++)
			{
				num += (double)Converter.CodeTable.IndexOf(inputStr[i]) * Math.Pow((double)baseNum, (double)(inputStr.Length - i - 1));
			}
			return num;
		}

		// Token: 0x04022A69 RID: 141929
		private static readonly string CodeTable = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
	}
}
