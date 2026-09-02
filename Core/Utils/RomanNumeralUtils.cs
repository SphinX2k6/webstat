using System;
using System.Runtime.CompilerServices;
using System.Text;

namespace CSharpScript.Core.Utils
{
	// Token: 0x0200711A RID: 28954
	public class RomanNumeralUtils : IStaticVariableResetter
	{
		// Token: 0x06046239 RID: 287289 RVA: 0x0126BE87 File Offset: 0x0126A087
		static RomanNumeralUtils()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(RomanNumeralUtils.CreateStaticDefaultValue), new Action(RomanNumeralUtils.ResetStaticDefaultValue));
		}

		// Token: 0x0604623A RID: 287290 RVA: 0x0126BEA8 File Offset: 0x0126A0A8
		public static void CreateStaticDefaultValue()
		{
			RomanNumeralUtils.MaxRomanNumeral = 3999;
			RomanNumeralUtils.StaticBuilder = new StringBuilder();
			RomanNumeralUtils.RomanNumerals = new ValueTuple<int, string>[]
			{
				new ValueTuple<int, string>(1000, "M"),
				new ValueTuple<int, string>(900, "CM"),
				new ValueTuple<int, string>(500, "D"),
				new ValueTuple<int, string>(400, "CD"),
				new ValueTuple<int, string>(100, "C"),
				new ValueTuple<int, string>(90, "XC"),
				new ValueTuple<int, string>(50, "L"),
				new ValueTuple<int, string>(40, "XL"),
				new ValueTuple<int, string>(10, "X"),
				new ValueTuple<int, string>(9, "IX"),
				new ValueTuple<int, string>(5, "V"),
				new ValueTuple<int, string>(4, "IV"),
				new ValueTuple<int, string>(1, "I")
			};
		}

		// Token: 0x0604623B RID: 287291 RVA: 0x0126BFD9 File Offset: 0x0126A1D9
		public static void ResetStaticDefaultValue()
		{
			RomanNumeralUtils.MaxRomanNumeral = 0;
			RomanNumeralUtils.RomanNumerals = null;
			RomanNumeralUtils.StaticBuilder = null;
		}

		// Token: 0x0604623C RID: 287292 RVA: 0x0126BFF0 File Offset: 0x0126A1F0
		[NullableContext(1)]
		public static string ConvertToRoman(int number)
		{
			if (!RomanNumeralUtils.IsValidInput(number))
			{
				return string.Empty;
			}
			StringBuilder staticBuilder = RomanNumeralUtils.StaticBuilder;
			staticBuilder.Clear();
			int num = number;
			foreach (ValueTuple<int, string> valueTuple in RomanNumeralUtils.RomanNumerals)
			{
				int num2 = num / valueTuple.Item1;
				if (num2 > 0)
				{
					for (int j = 0; j < num2; j++)
					{
						staticBuilder.Append(valueTuple.Item2);
					}
					num -= valueTuple.Item1 * num2;
				}
			}
			return staticBuilder.ToString();
		}

		// Token: 0x0604623D RID: 287293 RVA: 0x0126C079 File Offset: 0x0126A279
		private static bool IsValidInput(int number)
		{
			return number > 0 && number <= RomanNumeralUtils.MaxRomanNumeral;
		}

		// Token: 0x0604623E RID: 287294 RVA: 0x0126C08C File Offset: 0x0126A28C
		public static bool IsValidRange(int number)
		{
			return RomanNumeralUtils.IsValidInput(number);
		}

		// Token: 0x04027559 RID: 161113
		[Nullable(2)]
		private static StringBuilder StaticBuilder;

		// Token: 0x0402755A RID: 161114
		[TupleElementNames(new string[]
		{
			"Value",
			"Symbol"
		})]
		[Nullable(new byte[]
		{
			1,
			0,
			1
		})]
		private static ValueTuple<int, string>[] RomanNumerals;

		// Token: 0x0402755B RID: 161115
		private static int MaxRomanNumeral;
	}
}
