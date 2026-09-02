using System;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.RecallQuest
{
	// Token: 0x0200528C RID: 21132
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RecallQuestConfig : ConfigBase<RecallQuestConfig>
	{
		// Token: 0x060360A7 RID: 221351 RVA: 0x00D9A801 File Offset: 0x00D98A01
		public RecallConfig? GetRecallQuestConfig(int id)
		{
			return ConfigRecallConfigByRecallId.GetConfig(id, true);
		}
	}
}
