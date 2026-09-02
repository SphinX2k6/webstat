using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.DreamLink
{
	// Token: 0x02005D91 RID: 23953
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class DreamLinkConfig : ConfigBase<DreamLinkConfig>
	{
		// Token: 0x0603C4F4 RID: 247028 RVA: 0x00F4E2DE File Offset: 0x00F4C4DE
		public DreamLinkRoleDungeon? GetDreamLinkRoleDungeonConfig(int id)
		{
			return ConfigDreamLinkRoleDungeonById.GetConfig(id, true);
		}

		// Token: 0x0603C4F5 RID: 247029 RVA: 0x00F4E2E7 File Offset: 0x00F4C4E7
		public RogueWhiteCat? GetActivityConfig(int id)
		{
			return ConfigRogueWhiteCatById.GetConfig(id, true);
		}

		// Token: 0x0603C4F6 RID: 247030 RVA: 0x00F4E2F0 File Offset: 0x00F4C4F0
		public RogueBossInstance? GetRogueBossInstanceConfig(int id)
		{
			return ConfigRogueBossInstanceById.GetConfig(id, true);
		}

		// Token: 0x0603C4F7 RID: 247031 RVA: 0x00F4E2F9 File Offset: 0x00F4C4F9
		public BattleLinkCharacter? GetRoleConfig(int id)
		{
			return ConfigBattleLinkCharacterById.GetConfig(id, true);
		}

		// Token: 0x0603C4F8 RID: 247032 RVA: 0x00F4E302 File Offset: 0x00F4C502
		public IReadOnlyList<BattleLinkCharacter> GetRoleConfigList()
		{
			return ConfigBattleLinkCharacterAll.GetConfigList(true);
		}

		// Token: 0x0603C4F9 RID: 247033 RVA: 0x00F4E30A File Offset: 0x00F4C50A
		public RogueWhiteCatReward? GetEnergyRewardConfig(int id)
		{
			return ConfigRogueWhiteCatRewardById.GetConfig(id, true);
		}

		// Token: 0x0603C4FA RID: 247034 RVA: 0x00F4E313 File Offset: 0x00F4C513
		public DreamLinkWorldRun? GetWorldRunConfig(int id)
		{
			return ConfigDreamLinkWorldRunById.GetConfig(id, true);
		}

		// Token: 0x0603C4FB RID: 247035 RVA: 0x00F4E31C File Offset: 0x00F4C51C
		public DreamLinkWorldRun? GetWorldRunConfigByMarkId(int markId)
		{
			return ConfigDreamLinkWorldRunByMarkId.GetConfig(markId, true);
		}

		// Token: 0x0603C4FC RID: 247036 RVA: 0x00F4E325 File Offset: 0x00F4C525
		public RogueLimitTimeReward? GetLimitTimeRewardConfig(int id)
		{
			return ConfigRogueLimitTimeRewardById.GetConfig(id, true);
		}

		// Token: 0x0603C4FD RID: 247037 RVA: 0x00F4E32E File Offset: 0x00F4C52E
		public RogueWhiteCatBossReward? GetBossRewardConfig(int id)
		{
			return ConfigRogueWhiteCatBossRewardById.GetConfig(id, true);
		}
	}
}
