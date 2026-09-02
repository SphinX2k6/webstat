using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x0200315E RID: 12638
[NullableContext(1)]
[Nullable(0)]
public static class GameplayAbilityVisionMisc
{
	// Token: 0x0400D28A RID: 53898
	public const long ROLE_SUMMON_BUFF_ID = 1900000014L;

	// Token: 0x0400D28B RID: 53899
	public const long VISION_SUMMON_BUFF_ID = 1900000015L;

	// Token: 0x0400D28C RID: 53900
	public const long VISION_APPEAR_BUFF_ID = 1900000017L;

	// Token: 0x0400D28D RID: 53901
	public const int ROLE_DODGE_FORBID_BUFF_ID = 1101004005;

	// Token: 0x0400D28E RID: 53902
	public const long ROLE_HIDE_CUE_ID = 19000000191L;

	// Token: 0x0400D28F RID: 53903
	public const long ROLE_APPEAR_CUE_ID = 19000000201L;

	// Token: 0x0400D290 RID: 53904
	public const long MATERIAL_CUE_ID = 19000000181L;

	// Token: 0x0400D291 RID: 53905
	public const long MORPH_PARTICLE_CUE_ID = 19000000182L;

	// Token: 0x0400D292 RID: 53906
	public const long SUMMON_PARTICLE_CUE_ID = 19000000162L;

	// Token: 0x0400D293 RID: 53907
	public const int CHARACTER_HIDDEN_DELAY = 300;

	// Token: 0x0400D294 RID: 53908
	public const int VISION_HIDDEN_DELAY = 1000;

	// Token: 0x0400D295 RID: 53909
	public const int EXPLORE_SKILL_ID = 1200000;

	// Token: 0x0400D296 RID: 53910
	public const string VISION_END_BULLET = "210000004";

	// Token: 0x0400D297 RID: 53911
	public static readonly EAttributeType controlVisionEnergy = EAttributeType.Life;

	// Token: 0x0400D298 RID: 53912
	public static readonly int morphTag = GameplayTagDefine.EGameplayTagId["角色.BaseRole.技能通用标识.幻象变身中"];

	// Token: 0x0400D299 RID: 53913
	public static readonly int summonTag = GameplayTagDefine.EGameplayTagId["角色.BaseRole.技能通用标识.召唤幻象.激活幻象中"];

	// Token: 0x0400D29A RID: 53914
	public static readonly int invincibleTag = GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.隐身.不被子弹命中"];

	// Token: 0x0400D29B RID: 53915
	public static readonly int skillTag = GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.技能中"];

	// Token: 0x0400D29C RID: 53916
	public static readonly int stealthTag = GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.不被敌方子弹命中.前台不受控制"];

	// Token: 0x0400D29D RID: 53917
	[StaticVariableRuleIgnore]
	public static readonly global::Rotator tempRotator = global::Rotator.Create();

	// Token: 0x0400D29E RID: 53918
	[StaticVariableRuleIgnore]
	public static readonly global::Vector tempVector1 = global::Vector.Create();

	// Token: 0x0400D29F RID: 53919
	[StaticVariableRuleIgnore]
	public static readonly global::Vector tempVector2 = global::Vector.Create();

	// Token: 0x0400D2A0 RID: 53920
	public static readonly int newVisionInteractTag = GameplayTagDefine.EGameplayTagId["关卡.新版声骸显像.可用"];

	// Token: 0x0400D2A1 RID: 53921
	public static readonly int newShowVisionTag = GameplayTagDefine.EGameplayTagId["角色.BaseRole.技能通用标识.召唤幻象.显影幻象中"];
}
