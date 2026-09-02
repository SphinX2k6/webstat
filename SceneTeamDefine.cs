using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x0200295A RID: 10586
[NullableContext(1)]
[Nullable(0)]
public static class SceneTeamDefine
{
	// Token: 0x0400A1FF RID: 41471
	public const int SCENE_TEAM_MAX_NUM = 4;

	// Token: 0x0400A200 RID: 41472
	public const float DATA_LAYER_CHANGE_RADIUS = 20000f;

	// Token: 0x0400A201 RID: 41473
	public const float SPECIAL_CHANGE_DIS_LAND = 200f;

	// Token: 0x0400A202 RID: 41474
	public const float SPECIAL_CHANGE_DIS_AIR = 150f;

	// Token: 0x0400A203 RID: 41475
	public const float SPECIAL_CHANGE_ANGLE_LAND = 80f;

	// Token: 0x0400A204 RID: 41476
	public const float SPECIAL_CHANGE_ANGLE_AIR = 35f;

	// Token: 0x0400A205 RID: 41477
	public const float SPECIAL_CHANGE_HEIGHT_LAND = 0f;

	// Token: 0x0400A206 RID: 41478
	public const float SPECIAL_CHANGE_HEIGHT_AIR = -100f;

	// Token: 0x0400A207 RID: 41479
	public const string GO_BATTLE_MATERIAL = "GoBattleMaterial";

	// Token: 0x0400A208 RID: 41480
	public const string GO_BATTLE_EFFECT = "/Game/Aki/Effect/EffectGroup/Common/DA_Fx_Group_ChangeRole_Play.DA_Fx_Group_ChangeRole_Play";

	// Token: 0x0400A209 RID: 41481
	public const string GO_DOWN_MATERIAL = "GoDownMaterial";

	// Token: 0x0400A20A RID: 41482
	public const int EFFECT_DELAY = 100;

	// Token: 0x0400A20B RID: 41483
	public const int EFFECT_DELAY_QUIT = 300;

	// Token: 0x0400A20C RID: 41484
	public const int CHECK_ROLE_INTERVAL = 30000;

	// Token: 0x0400A20D RID: 41485
	[StaticVariableRuleIgnore]
	public static readonly int[] beHitTagList = new int[]
	{
		GameplayTagDefine.EGameplayTagId["行为状态.动作状态.受击.被弹反"],
		GameplayTagDefine.EGameplayTagId["行为状态.动作状态.受击.被抓取"],
		GameplayTagDefine.EGameplayTagId["行为状态.动作状态.受击.轻击"],
		GameplayTagDefine.EGameplayTagId["行为状态.动作状态.受击.重击"],
		GameplayTagDefine.EGameplayTagId["行为状态.动作状态.受击.击飞"]
	};

	// Token: 0x0400A20E RID: 41486
	[StaticVariableRuleIgnore]
	public static IReadOnlySet<ETeamGroupType> needInheritTypeSet = new HashSet<ETeamGroupType>(new <>z__ReadOnlyArray<ETeamGroupType>(new ETeamGroupType[]
	{
		ETeamGroupType.VisionControl,
		ETeamGroupType.Plot,
		ETeamGroupType.Performance
	}));

	// Token: 0x0400A20F RID: 41487
	[StaticVariableRuleIgnore]
	public static readonly ETeamGroupType[] innerGroupType = new ETeamGroupType[]
	{
		ETeamGroupType.VisionControl,
		ETeamGroupType.Plot
	};

	// Token: 0x0400A210 RID: 41488
	[StaticVariableRuleIgnore]
	public static readonly int[] needFixLocationTagList = new int[]
	{
		GameplayTagDefine.EGameplayTagId["行为状态.位置状态.地面"],
		GameplayTagDefine.EGameplayTagId["行为状态.动作状态.滑坡.普通滑坡"],
		GameplayTagDefine.EGameplayTagId["行为状态.动作状态.滑雪.正常滑雪"]
	};

	// Token: 0x0400A211 RID: 41489
	public const float AUTO_ROLE_OFFSET_DISTANCE = 150f;

	// Token: 0x0400A212 RID: 41490
	public const int CHANGING_ROLE_TIMEOUT = 2000;

	// Token: 0x0400A213 RID: 41491
	public const int SEAMLESS_UPDATE_TEAM_TIMEOUT = 30000;
}
