using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.RogueBattle
{
	// Token: 0x02005237 RID: 21047
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Config(0)]
	public class RogueBattleConfig : ConfigBase<RogueBattleConfig>
	{
		// Token: 0x06035E79 RID: 220793 RVA: 0x00D91900 File Offset: 0x00D8FB00
		public RogueResBuffPool? GetRogueResBuffPoolById(int id)
		{
			RogueResBuffPool? config = ConfigRogueResBuffPoolById.GetConfig(id, true);
			if (config == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.RogueBattle;
				ELogAuthor author = ELogAuthor.WHJ;
				string message = "RogueBattleTokenItem.RefreshDescText tokenConfig is null";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ConfigId", id);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			return config;
		}

		// Token: 0x06035E7A RID: 220794 RVA: 0x00D9194E File Offset: 0x00D8FB4E
		public RogueResRoomPool? GetRoomPoolConfig(int id)
		{
			return ConfigRogueResRoomPoolById.GetConfig(id, true);
		}

		// Token: 0x06035E7B RID: 220795 RVA: 0x00D91957 File Offset: 0x00D8FB57
		public RogueResRoomType? GetRogueRoomType(int id)
		{
			return ConfigRogueResRoomTypeById.GetConfig(id, true);
		}

		// Token: 0x06035E7C RID: 220796 RVA: 0x00D91960 File Offset: 0x00D8FB60
		public ResElementLevelGain? GetElementLevelGain(int targetType)
		{
			return ConfigResElementLevelGainByTargetType.GetConfig(targetType, true);
		}

		// Token: 0x06035E7D RID: 220797 RVA: 0x00D91969 File Offset: 0x00D8FB69
		public RogueResPokemon? GetRogueResPokemon(int id)
		{
			return ConfigRogueResPokemonById.GetConfig(id, true);
		}

		// Token: 0x06035E7E RID: 220798 RVA: 0x00D91972 File Offset: 0x00D8FB72
		public RogueResAffix? GetRogueResAffix(int id)
		{
			return ConfigRogueResAffixById.GetConfig(id, true);
		}

		// Token: 0x06035E7F RID: 220799 RVA: 0x00D9197B File Offset: 0x00D8FB7B
		public RogueResQualityConfig? GetRogueResQualityConfig(int id)
		{
			return ConfigRogueResQualityConfigById.GetConfig(id, true);
		}

		// Token: 0x06035E80 RID: 220800 RVA: 0x00D91984 File Offset: 0x00D8FB84
		public RogueResBond? GetRogueResBond(int id)
		{
			return ConfigRogueResBondById.GetConfig(id, true);
		}

		// Token: 0x06035E81 RID: 220801 RVA: 0x00D9198D File Offset: 0x00D8FB8D
		public IReadOnlyList<RogueResBond> GetAllRogueResBond()
		{
			return ConfigRogueResBondAll.GetConfigList(true);
		}

		// Token: 0x06035E82 RID: 220802 RVA: 0x00D91995 File Offset: 0x00D8FB95
		public RogueResBondRole? GetRogueResBondRole(int id)
		{
			return ConfigRogueResBondRoleByRoleId.GetConfig(id, true);
		}

		// Token: 0x06035E83 RID: 220803 RVA: 0x00D9199E File Offset: 0x00D8FB9E
		public IReadOnlyList<RogueResBondRole> GetAllRogueResBondRole()
		{
			return ConfigRogueResBondRoleAll.GetConfigList(true);
		}

		// Token: 0x06035E84 RID: 220804 RVA: 0x00D919A6 File Offset: 0x00D8FBA6
		public RogueResCharacterBuff? GetRogueResCharacterBuff(int id)
		{
			return ConfigRogueResCharacterBuffById.GetConfig(id, true);
		}

		// Token: 0x06035E85 RID: 220805 RVA: 0x00D919AF File Offset: 0x00D8FBAF
		public IReadOnlyList<RogueResSynergyType> GetAllRogueResBondType()
		{
			return ConfigRogueResSynergyTypeAll.GetConfigList(true);
		}

		// Token: 0x06035E86 RID: 220806 RVA: 0x00D919B7 File Offset: 0x00D8FBB7
		public RogueResSynergyType? GetRogueResBondTypeById(int id)
		{
			return ConfigRogueResSynergyTypeById.GetConfig(id, true);
		}

		// Token: 0x06035E87 RID: 220807 RVA: 0x00D919C0 File Offset: 0x00D8FBC0
		public RogueResEffect? GetRogueResEffectById(int id)
		{
			return ConfigRogueResEffectById.GetConfig(id, true);
		}

		// Token: 0x06035E88 RID: 220808 RVA: 0x00D919C9 File Offset: 0x00D8FBC9
		public RogueResEffectTag? GetRogueResEffectTagById(int id)
		{
			return ConfigRogueResEffectTagById.GetConfig(id, true);
		}

		// Token: 0x06035E89 RID: 220809 RVA: 0x00D919D2 File Offset: 0x00D8FBD2
		public IReadOnlyList<RogueResTeamLvRule> GetAllRogueResTeamLvRule()
		{
			return ConfigRogueResTeamLvRuleAll.GetConfigList(true);
		}

		// Token: 0x06035E8A RID: 220810 RVA: 0x00D919DA File Offset: 0x00D8FBDA
		public IReadOnlyList<RogueResSkillLvRule> GetAllRogueResSkillLvRule()
		{
			return ConfigRogueResSkillLvRuleAll.GetConfigList(true);
		}

		// Token: 0x06035E8B RID: 220811 RVA: 0x00D919E2 File Offset: 0x00D8FBE2
		public RogueResBondLv? GetBondLvConfigByLv(int lv)
		{
			return ConfigRogueResBondLvByLv.GetConfig(lv, true);
		}
	}
}
