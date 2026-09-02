using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.Battle
{
	// Token: 0x02005F3E RID: 24382
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class BattleScoreConfig : ConfigBase<BattleScoreConfig>
	{
		// Token: 0x0603D42A RID: 250922 RVA: 0x00F94A19 File Offset: 0x00F92C19
		public BattleScoreConf? GetBattleScoreConfig(int id)
		{
			return ConfigBattleScoreConfById.GetConfig(id, true);
		}

		// Token: 0x0603D42B RID: 250923 RVA: 0x00F94A22 File Offset: 0x00F92C22
		public BattleScoreLevelConf? GetBattleScoreLevelConfig(int id)
		{
			return ConfigBattleScoreLevelConfById.GetConfig(id, true);
		}

		// Token: 0x0603D42C RID: 250924 RVA: 0x00F94A2B File Offset: 0x00F92C2B
		public IReadOnlyList<BattleScoreLevelConf> GetBattleScoreActionConfigByGroupId(int groupId)
		{
			return ConfigBattleScoreLevelConfByGroupId.GetConfigList(groupId, true);
		}
	}
}
