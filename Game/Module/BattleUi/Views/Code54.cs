using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02005FE3 RID: 24547
	[NullableContext(1)]
	[Nullable(0)]
	public class Code54 : CodeNBase
	{
		// Token: 0x0603DC7F RID: 253055 RVA: 0x00FBE140 File Offset: 0x00FBC340
		public override Dictionary<string, int[]> GetCodeTable()
		{
			return Code54.CodeTable;
		}

		// Token: 0x0603DC80 RID: 253056 RVA: 0x00FBE147 File Offset: 0x00FBC347
		public override int SingleCodeLength()
		{
			return 5;
		}

		// Token: 0x0603DC81 RID: 253057 RVA: 0x00FBE14A File Offset: 0x00FBC34A
		public override int SupportCharCount()
		{
			return 52;
		}

		// Token: 0x0603DC83 RID: 253059 RVA: 0x00FBE158 File Offset: 0x00FBC358
		// Note: this type is marked as 'beforefieldinit'.
		static Code54()
		{
			Dictionary<string, int[]> dictionary = new Dictionary<string, int[]>();
			Dictionary<string, int[]> dictionary2 = dictionary;
			string key = "+";
			int[] array = new int[4];
			array[0] = 1;
			dictionary2.Add(key, array);
			dictionary.Add("-", new int[]
			{
				1,
				0,
				0,
				1
			});
			dictionary.Add("0", new int[]
			{
				1,
				0,
				0,
				2
			});
			Dictionary<string, int[]> dictionary3 = dictionary;
			string key2 = "1";
			int[] array2 = new int[4];
			array2[0] = 1;
			array2[2] = 1;
			dictionary3.Add(key2, array2);
			dictionary.Add("2", new int[]
			{
				1,
				0,
				1,
				1
			});
			dictionary.Add("3", new int[]
			{
				1,
				0,
				1,
				2
			});
			Dictionary<string, int[]> dictionary4 = dictionary;
			string key3 = "4";
			int[] array3 = new int[4];
			array3[0] = 1;
			array3[2] = 2;
			dictionary4.Add(key3, array3);
			dictionary.Add("5", new int[]
			{
				1,
				0,
				2,
				1
			});
			dictionary.Add("6", new int[]
			{
				1,
				0,
				2,
				2
			});
			Dictionary<string, int[]> dictionary5 = dictionary;
			string key4 = "7";
			int[] array4 = new int[4];
			array4[0] = 1;
			array4[1] = 1;
			dictionary5.Add(key4, array4);
			dictionary.Add("8", new int[]
			{
				1,
				1,
				0,
				1
			});
			dictionary.Add("9", new int[]
			{
				1,
				1,
				0,
				2
			});
			dictionary.Add("a", new int[]
			{
				1,
				1,
				1,
				0
			});
			dictionary.Add("b", new int[]
			{
				1,
				1,
				1,
				1
			});
			dictionary.Add("c", new int[]
			{
				1,
				1,
				1,
				2
			});
			dictionary.Add("d", new int[]
			{
				1,
				1,
				2,
				0
			});
			dictionary.Add("e", new int[]
			{
				1,
				1,
				2,
				1
			});
			dictionary.Add("f", new int[]
			{
				1,
				1,
				2,
				2
			});
			Dictionary<string, int[]> dictionary6 = dictionary;
			string key5 = "g";
			int[] array5 = new int[4];
			array5[0] = 1;
			array5[1] = 2;
			dictionary6.Add(key5, array5);
			dictionary.Add("h", new int[]
			{
				1,
				2,
				0,
				1
			});
			dictionary.Add("i", new int[]
			{
				1,
				2,
				0,
				2
			});
			dictionary.Add("j", new int[]
			{
				1,
				2,
				1,
				0
			});
			dictionary.Add("k", new int[]
			{
				1,
				2,
				1,
				1
			});
			dictionary.Add("l", new int[]
			{
				1,
				2,
				1,
				2
			});
			dictionary.Add("m", new int[]
			{
				1,
				2,
				2,
				0
			});
			dictionary.Add("n", new int[]
			{
				1,
				2,
				2,
				1
			});
			dictionary.Add("o", new int[]
			{
				1,
				2,
				2,
				2
			});
			Dictionary<string, int[]> dictionary7 = dictionary;
			string key6 = "p";
			int[] array6 = new int[4];
			array6[0] = 2;
			dictionary7.Add(key6, array6);
			dictionary.Add("q", new int[]
			{
				2,
				0,
				0,
				1
			});
			dictionary.Add("r", new int[]
			{
				2,
				0,
				0,
				2
			});
			Dictionary<string, int[]> dictionary8 = dictionary;
			string key7 = "s";
			int[] array7 = new int[4];
			array7[0] = 2;
			array7[2] = 1;
			dictionary8.Add(key7, array7);
			dictionary.Add("t", new int[]
			{
				2,
				0,
				1,
				1
			});
			dictionary.Add("u", new int[]
			{
				2,
				0,
				1,
				2
			});
			Dictionary<string, int[]> dictionary9 = dictionary;
			string key8 = "v";
			int[] array8 = new int[4];
			array8[0] = 2;
			array8[2] = 2;
			dictionary9.Add(key8, array8);
			dictionary.Add("w", new int[]
			{
				2,
				0,
				2,
				1
			});
			dictionary.Add("x", new int[]
			{
				2,
				0,
				2,
				2
			});
			Dictionary<string, int[]> dictionary10 = dictionary;
			string key9 = "y";
			int[] array9 = new int[4];
			array9[0] = 2;
			array9[1] = 1;
			dictionary10.Add(key9, array9);
			dictionary.Add("z", new int[]
			{
				2,
				1,
				0,
				1
			});
			dictionary.Add("A", new int[]
			{
				2,
				1,
				0,
				2
			});
			dictionary.Add("B", new int[]
			{
				2,
				1,
				1,
				0
			});
			dictionary.Add("C", new int[]
			{
				2,
				1,
				1,
				1
			});
			dictionary.Add("D", new int[]
			{
				2,
				1,
				1,
				2
			});
			dictionary.Add("E", new int[]
			{
				2,
				1,
				2,
				0
			});
			dictionary.Add("F", new int[]
			{
				2,
				1,
				2,
				1
			});
			dictionary.Add("G", new int[]
			{
				2,
				1,
				2,
				2
			});
			Dictionary<string, int[]> dictionary11 = dictionary;
			string key10 = "H";
			int[] array10 = new int[4];
			array10[0] = 2;
			array10[1] = 2;
			dictionary11.Add(key10, array10);
			dictionary.Add("I", new int[]
			{
				2,
				2,
				0,
				1
			});
			dictionary.Add("J", new int[]
			{
				2,
				2,
				0,
				2
			});
			dictionary.Add("K", new int[]
			{
				2,
				2,
				1,
				0
			});
			dictionary.Add("L", new int[]
			{
				2,
				2,
				1,
				1
			});
			dictionary.Add("M", new int[]
			{
				2,
				2,
				1,
				2
			});
			dictionary.Add("N", new int[]
			{
				2,
				2,
				2,
				0
			});
			dictionary.Add("O", new int[]
			{
				2,
				2,
				2,
				1
			});
			dictionary.Add("P", new int[]
			{
				2,
				2,
				2,
				2
			});
			Code54.CodeTable = dictionary;
		}

		// Token: 0x04022A6B RID: 141931
		[StaticVariableRuleIgnore]
		private static readonly Dictionary<string, int[]> CodeTable;
	}
}
