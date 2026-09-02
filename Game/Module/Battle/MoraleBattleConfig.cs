using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.Battle
{
	// Token: 0x02005F32 RID: 24370
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Config(0)]
	public class MoraleBattleConfig : ConfigBase<MoraleBattleConfig>
	{
		// Token: 0x0603D37B RID: 250747 RVA: 0x00F912C8 File Offset: 0x00F8F4C8
		public MoralePlay? GetMoraleConfig(int id)
		{
			if (id == 0)
			{
				return null;
			}
			return ConfigMoralePlayById.GetConfig(id, true);
		}

		// Token: 0x0603D37C RID: 250748 RVA: 0x00F912E9 File Offset: 0x00F8F4E9
		public MoraleKeepLevel? GetExpConfig(int id)
		{
			return ConfigMoraleKeepLevelById.GetConfig(id, true);
		}

		// Token: 0x0603D37D RID: 250749 RVA: 0x00F912F2 File Offset: 0x00F8F4F2
		public IReadOnlyList<MoraleKeepLevel> GetAllExpConfig()
		{
			return ConfigMoraleKeepLevelAll.GetConfigList(true);
		}

		// Token: 0x0603D37E RID: 250750 RVA: 0x00F912FA File Offset: 0x00F8F4FA
		public MoraleLevelDiff? GetLevelDiffConfig(int id)
		{
			return ConfigMoraleLevelDiffById.GetConfig(id, true);
		}

		// Token: 0x0603D37F RID: 250751 RVA: 0x00F91303 File Offset: 0x00F8F503
		public MoraleLevelDiffShow? GetLevelDiffShowConfig(int id)
		{
			return ConfigMoraleLevelDiffShowById.GetConfig(id, true);
		}

		// Token: 0x0603D380 RID: 250752 RVA: 0x00F9130C File Offset: 0x00F8F50C
		public IReadOnlyList<MoraleLevelDiffShow> GetAllLevelDiffShowConfig()
		{
			return ConfigMoraleLevelDiffShowAll.GetConfigList(true);
		}
	}
}
