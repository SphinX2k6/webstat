using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x020013B1 RID: 5041
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class BusinessConfig : ConfigBase<BusinessConfig>
{
	// Token: 0x06008AF5 RID: 35573 RVA: 0x00249E4C File Offset: 0x0024804C
	public TrackMoonEntrust GetDelegationConfig(int delegateId)
	{
		return ConfigTrackMoonEntrustById.GetConfig(delegateId, true).Value;
	}

	// Token: 0x06008AF6 RID: 35574 RVA: 0x00249E68 File Offset: 0x00248068
	public Evaluate GetEvaluateByLevel(int level)
	{
		return ConfigEvaluateById.GetConfig(level, true).Value;
	}

	// Token: 0x06008AF7 RID: 35575 RVA: 0x00249E84 File Offset: 0x00248084
	public Character GetCharacterConfig(int id)
	{
		return ConfigCharacterById.GetConfig(id, true).Value;
	}

	// Token: 0x06008AF8 RID: 35576 RVA: 0x00249EA0 File Offset: 0x002480A0
	public EntrustRole GetEntrustRoleById(int id)
	{
		return ConfigEntrustRoleById.GetConfig(id, true).Value;
	}

	// Token: 0x06008AF9 RID: 35577 RVA: 0x00249EBC File Offset: 0x002480BC
	public IReadOnlyList<EntrustRole> GetEntrustRoleAll()
	{
		return ConfigEntrustRoleAll.GetConfigList(true);
	}

	// Token: 0x06008AFA RID: 35578 RVA: 0x00249EC4 File Offset: 0x002480C4
	public IReadOnlyList<Popularity> GetPopularityAll()
	{
		return ConfigPopularityAll.GetConfigList(true);
	}

	// Token: 0x06008AFB RID: 35579 RVA: 0x00249ECC File Offset: 0x002480CC
	public IReadOnlyList<RoleDevelopCurve> GetRoleDevelopCurveByGroupId(int groupId)
	{
		return ConfigRoleDevelopCurveByGroupId.GetConfigList(groupId, true);
	}

	// Token: 0x06008AFC RID: 35580 RVA: 0x00249ED8 File Offset: 0x002480D8
	public EntrustFinishDialog GetEntrustFinishDialogByIdAndLevel(int id, int level)
	{
		return ConfigEntrustFinishDialogByEntrustIdAndLevel.GetConfig(id, level, true).Value;
	}

	// Token: 0x06008AFD RID: 35581 RVA: 0x00249EF8 File Offset: 0x002480F8
	public EntrustType GetEntrustTypeById(int id)
	{
		return ConfigEntrustTypeById.GetConfig(id, true).Value;
	}

	// Token: 0x06008AFE RID: 35582 RVA: 0x00249F14 File Offset: 0x00248114
	public TrainRoleDialog GetTrainRoleDialogByIdAndType(int id, int type)
	{
		return ConfigTrainRoleDialogByRoleIdAndTrainType.GetConfig(id, type, true).Value;
	}

	// Token: 0x06008AFF RID: 35583 RVA: 0x00249F34 File Offset: 0x00248134
	public RoleDevelopType GetRoleDevelopTypeById(int id)
	{
		return ConfigRoleDevelopTypeById.GetConfig(id, true).Value;
	}

	// Token: 0x06008B00 RID: 35584 RVA: 0x00249F50 File Offset: 0x00248150
	public int GetPowerItemId()
	{
		return ConfigCommonParamById.GetIntConfig("MoonFiestaEnergyItemId").GetValueOrDefault();
	}

	// Token: 0x06008B01 RID: 35585 RVA: 0x00249F70 File Offset: 0x00248170
	public int GetCoinItemId()
	{
		return ConfigCommonParamById.GetIntConfig("MoonFiestaCoinItemId").GetValueOrDefault();
	}

	// Token: 0x06008B02 RID: 35586 RVA: 0x00249F90 File Offset: 0x00248190
	public int GetWishItemId()
	{
		return ConfigCommonParamById.GetIntConfig("MoonFiestaWishItemId").GetValueOrDefault();
	}

	// Token: 0x06008B03 RID: 35587 RVA: 0x00249FB0 File Offset: 0x002481B0
	public int GetPopularityItemId()
	{
		return ConfigCommonParamById.GetIntConfig("MoonFiestaPopularityItemId").GetValueOrDefault();
	}

	// Token: 0x06008B04 RID: 35588 RVA: 0x00249FD0 File Offset: 0x002481D0
	public int GetTokenItemId()
	{
		return ConfigCommonParamById.GetIntConfig("MoonFiestaTokenItemId").GetValueOrDefault();
	}

	// Token: 0x06008B05 RID: 35589 RVA: 0x00249FEF File Offset: 0x002481EF
	public string GetTipsCommonRoleIcon()
	{
		return ConfigCommonParamById.GetStringConfig("MoonFiestaHintRole") ?? "";
	}

	// Token: 0x06008B06 RID: 35590 RVA: 0x0024A004 File Offset: 0x00248204
	public int GetSkipAnimDelayTime()
	{
		return ConfigCommonParamById.GetIntConfig("MoonChasingBusinessSkipAnimDelayTime").GetValueOrDefault();
	}

	// Token: 0x06008B07 RID: 35591 RVA: 0x0024A024 File Offset: 0x00248224
	public int GetEntrustScoreMax()
	{
		return ConfigCommonParamById.GetIntConfig("MoonChasingEntrustScoreMax").GetValueOrDefault();
	}

	// Token: 0x06008B08 RID: 35592 RVA: 0x0024A044 File Offset: 0x00248244
	public int GetRoleCharacterMax()
	{
		return ConfigCommonParamById.GetIntConfig("MoonChasingRoleCharacterMax").GetValueOrDefault();
	}
}
