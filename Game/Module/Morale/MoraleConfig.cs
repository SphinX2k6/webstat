using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.Morale
{
	// Token: 0x020056F9 RID: 22265
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Config(0)]
	public class MoraleConfig : ConfigBase<MoraleConfig>
	{
		// Token: 0x06038A92 RID: 232082 RVA: 0x00E59287 File Offset: 0x00E57487
		protected override bool OnInit()
		{
			return true;
		}

		// Token: 0x06038A93 RID: 232083 RVA: 0x00E5928A File Offset: 0x00E5748A
		protected override bool OnClear()
		{
			return true;
		}

		// Token: 0x06038A94 RID: 232084 RVA: 0x00E5928D File Offset: 0x00E5748D
		public IReadOnlyList<OccupyScore> GetAllScoreConfigList()
		{
			return ConfigOccupyScoreAll.GetConfigList(true) ?? Array.Empty<OccupyScore>();
		}

		// Token: 0x06038A95 RID: 232085 RVA: 0x00E5929E File Offset: 0x00E5749E
		public IReadOnlyList<FlagArea> GetFlagConfigListByAreaId(int areaId)
		{
			return ConfigFlagAreaByAreaId.GetConfigList(areaId, true) ?? Array.Empty<FlagArea>();
		}

		// Token: 0x06038A96 RID: 232086 RVA: 0x00E592B0 File Offset: 0x00E574B0
		public MoraleFlagType? GetFlagTypeConfig(int flagTypeId)
		{
			return ConfigMoraleFlagTypeByType.GetConfig(flagTypeId, true);
		}

		// Token: 0x06038A97 RID: 232087 RVA: 0x00E592B9 File Offset: 0x00E574B9
		public IReadOnlyList<MoraleLvPower> GetAllMoraleLvPowerConfigList()
		{
			return ConfigMoraleLvPowerAll.GetConfigList(true) ?? Array.Empty<MoraleLvPower>();
		}

		// Token: 0x06038A98 RID: 232088 RVA: 0x00E592CA File Offset: 0x00E574CA
		public IReadOnlyList<MoraleArea> GetAllAreaConfigList()
		{
			return ConfigMoraleAreaAll.GetConfigList(true) ?? Array.Empty<MoraleArea>();
		}

		// Token: 0x06038A99 RID: 232089 RVA: 0x00E592DB File Offset: 0x00E574DB
		public IReadOnlyList<int> GetAllAttrAddIdList()
		{
			return ConfigCommonParamById.GetIntArrayConfig("MoraleRoleAttrAddIdList") ?? Array.Empty<int>();
		}

		// Token: 0x06038A9A RID: 232090 RVA: 0x00E592F0 File Offset: 0x00E574F0
		public MoraleRoleGrowth? GetRoleAttrAddConfigByLv(int lv)
		{
			return ConfigMoraleRoleGrowthByLevel.GetConfig(lv, true);
		}

		// Token: 0x06038A9B RID: 232091 RVA: 0x00E592FC File Offset: 0x00E574FC
		public int GetScoreProgressRichValue()
		{
			return ConfigCommonParamById.GetIntConfig("MoraleScoreProgressRichValue").GetValueOrDefault();
		}

		// Token: 0x06038A9C RID: 232092 RVA: 0x00E5931C File Offset: 0x00E5751C
		public int GetMoraleGameOverQuestId()
		{
			return ConfigCommonParamById.GetIntConfig("MoraleGameOver").GetValueOrDefault();
		}

		// Token: 0x06038A9D RID: 232093 RVA: 0x00E5933C File Offset: 0x00E5753C
		public bool GetMoraleMarkIsAutoTrack()
		{
			return ConfigCommonParamById.GetBoolConfig("MoraleMarkIsAutoTrack").GetValueOrDefault();
		}

		// Token: 0x06038A9E RID: 232094 RVA: 0x00E5935C File Offset: 0x00E5755C
		public int GetMoraleBuffShowTime()
		{
			return ConfigCommonParamById.GetIntConfig("MoraleBuffShowTime").GetValueOrDefault(1);
		}

		// Token: 0x06038A9F RID: 232095 RVA: 0x00E5937C File Offset: 0x00E5757C
		public bool GetMoraleSelectHighLevelFlag()
		{
			return ConfigCommonParamById.GetBoolConfig("MoraleSelectHighLevelFlag").GetValueOrDefault();
		}

		// Token: 0x06038AA0 RID: 232096 RVA: 0x00E5939C File Offset: 0x00E5759C
		public bool GetMoraleIsShowSmallFlagProgress()
		{
			return ConfigCommonParamById.GetBoolConfig("MoraleIsShowSmallFlagProgress").GetValueOrDefault();
		}

		// Token: 0x06038AA1 RID: 232097 RVA: 0x00E593BC File Offset: 0x00E575BC
		public bool GetMoraleHighFlagUnFinishIsShowExploreBoxProgress()
		{
			return ConfigCommonParamById.GetBoolConfig("MoraleHighFlagUnFinishIsShowExploreBoxProgress").GetValueOrDefault();
		}
	}
}
