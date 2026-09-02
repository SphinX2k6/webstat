using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Sheriff
{
	// Token: 0x02004FBE RID: 20414
	public static class SheriffDefineData
	{
		// Token: 0x06034A8B RID: 215691 RVA: 0x00D34A9C File Offset: 0x00D32C9C
		// Note: this type is marked as 'beforefieldinit'.
		static SheriffDefineData()
		{
			Dictionary<int, IReadOnlyDictionary<int, string>> dictionary = new Dictionary<int, IReadOnlyDictionary<int, string>>();
			int key = 1;
			Dictionary<int, string> dictionary2 = new Dictionary<int, string>();
			dictionary2[0] = "SP_IconMap_Task_10_05_UI";
			dictionary2[1] = "SP_IconMap_Task_10_1_UI";
			dictionary2[2] = "SP_IconMap_Task_10_UI";
			dictionary2[3] = "SP_IconMap_Task_10_UI";
			dictionary[key] = dictionary2;
			int key2 = 2;
			Dictionary<int, string> dictionary3 = new Dictionary<int, string>();
			dictionary3[0] = "SP_IconMap_Task_02_4_UI";
			dictionary3[1] = "SP_IconMap_Task_02_1_UI";
			dictionary3[2] = "SP_IconMap_Task_02_UI";
			dictionary3[3] = "SP_IconMap_Task_02_UI";
			dictionary[key2] = dictionary3;
			SheriffDefineData.SheriffQuestMarkIconRecord = dictionary;
		}

		// Token: 0x0401E5C7 RID: 124359
		[Nullable(1)]
		[StaticVariableRuleIgnore]
		public static readonly IReadOnlyDictionary<int, IReadOnlyDictionary<int, string>> SheriffQuestMarkIconRecord;
	}
}
