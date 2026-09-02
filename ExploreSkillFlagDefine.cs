using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

// Token: 0x02001CAA RID: 7338
public class ExploreSkillFlagDefine : IStaticVariableResetter
{
	// Token: 0x0600D770 RID: 55152 RVA: 0x00399D8F File Offset: 0x00397F8F
	static ExploreSkillFlagDefine()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(ExploreSkillFlagDefine.CreateStaticDefaultValue), new Action(ExploreSkillFlagDefine.ResetStaticDefaultValue));
	}

	// Token: 0x0600D771 RID: 55153 RVA: 0x00399DB0 File Offset: 0x00397FB0
	public static void CreateStaticDefaultValue()
	{
		ExploreSkillFlagDefine.levelExploreSkillFlagDefaultVal = new Dictionary<EExploreSkillType, bool>
		{
			{
				EExploreSkillType.Hook,
				true
			},
			{
				EExploreSkillType.Throw,
				true
			},
			{
				EExploreSkillType.Control,
				true
			},
			{
				EExploreSkillType.Scan,
				true
			},
			{
				EExploreSkillType.ShowVision,
				true
			},
			{
				EExploreSkillType.Photo,
				true
			},
			{
				EExploreSkillType.PlaceTemporaryTeleport,
				true
			},
			{
				EExploreSkillType.DetectSoundBox,
				true
			},
			{
				EExploreSkillType.DetectTreasure,
				true
			},
			{
				EExploreSkillType.FollowShooterEnter,
				true
			},
			{
				EExploreSkillType.Soaring,
				true
			},
			{
				EExploreSkillType.SummonMotorcycle,
				true
			},
			{
				EExploreSkillType.MotorcycleCruise,
				true
			}
		};
		Dictionary<EExploreSkillType, bool>.KeyCollection keys = ExploreSkillFlagDefine.levelExploreSkillFlagDefaultVal.Keys;
		int num = 0;
		EExploreSkillType[] array = new EExploreSkillType[2 + keys.Count];
		foreach (EExploreSkillType eexploreSkillType in keys)
		{
			array[num] = eexploreSkillType;
			num++;
		}
		array[num] = EExploreSkillType.MotorcycleHook;
		num++;
		array[num] = EExploreSkillType.MotorcycleCollect;
		ExploreSkillFlagDefine.levelOperationRestrictExploreSkillTypes = array;
	}

	// Token: 0x0600D772 RID: 55154 RVA: 0x00399EDC File Offset: 0x003980DC
	public static void ResetStaticDefaultValue()
	{
		ExploreSkillFlagDefine.levelExploreSkillFlagDefaultVal = null;
		ExploreSkillFlagDefine.levelOperationRestrictExploreSkillTypes = null;
	}

	// Token: 0x04006617 RID: 26135
	[Nullable(2)]
	public static Dictionary<EExploreSkillType, bool> levelExploreSkillFlagDefaultVal;

	// Token: 0x04006618 RID: 26136
	[Nullable(2)]
	public static EExploreSkillType[] levelOperationRestrictExploreSkillTypes;
}
