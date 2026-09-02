using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Component;

// Token: 0x0200316F RID: 12655
[NullableContext(1)]
[Nullable(0)]
public static class GrapplingHookPointDefine
{
	// Token: 0x0400D322 RID: 54050
	public const int HOOK_VISION_ID = 1001;

	// Token: 0x0400D323 RID: 54051
	public const int HOOK_MAX_SPEED = 3500;

	// Token: 0x0400D324 RID: 54052
	[StaticVariableRuleIgnore]
	public static readonly HashSet<int> UpdateTargetSkillIds = new HashSet<int>
	{
		1208713,
		100020,
		100021,
		100022,
		200004,
		50170004,
		501700042,
		501700043,
		501700044,
		501700045,
		50170001,
		501700011,
		50180004,
		210130,
		100024,
		200006,
		5021005,
		5021008,
		5021009,
		210032,
		210033,
		210034,
		210041,
		800006,
		210044,
		5054010,
		5045008
	};

	// Token: 0x0400D325 RID: 54053
	[StaticVariableRuleIgnore]
	public static readonly Dictionary<EHookPointState, int> HookPointStateToTagMap = new Dictionary<EHookPointState, int>
	{
		{
			EHookPointState.Normal,
			GameplayTagDefine.EGameplayTagId["关卡.定点钩锁.常态"]
		},
		{
			EHookPointState.Interactive,
			GameplayTagDefine.EGameplayTagId["关卡.定点钩锁.可交互"]
		},
		{
			EHookPointState.NonInteractive,
			GameplayTagDefine.EGameplayTagId["关卡.定点钩锁.不可交互"]
		},
		{
			EHookPointState.Interacting,
			GameplayTagDefine.EGameplayTagId["关卡.定点钩锁.交互中"]
		}
	};

	// Token: 0x0400D326 RID: 54054
	[StaticVariableRuleIgnore]
	public static readonly Dictionary<EHookInteractType, int> NormalHookTagMap = new Dictionary<EHookInteractType, int>
	{
		{
			EHookInteractType.FixedPointHook,
			GameplayTagDefine.EGameplayTagId["角色.Common.技能通用标识.定点钩索可用"]
		},
		{
			EHookInteractType.SuiGuangHook,
			GameplayTagDefine.EGameplayTagId["角色.Common.技能通用标识.岁光钩索可用"]
		},
		{
			EHookInteractType.FlyingFeather,
			GameplayTagDefine.EGameplayTagId["角色.Common.技能通用标识.飞雷神可用"]
		},
		{
			EHookInteractType.KiteHook,
			GameplayTagDefine.EGameplayTagId["角色.Common.技能通用标识.风筝钩索可用"]
		},
		{
			EHookInteractType.RagDollJumpingPoint,
			GameplayTagDefine.EGameplayTagId["角色.Common.技能通用标识.大布偶.跳跃可用"]
		},
		{
			EHookInteractType.RagDollClimbingPoint,
			GameplayTagDefine.EGameplayTagId["角色.Common.技能通用标识.大布偶.攀爬可用"]
		},
		{
			EHookInteractType.MovementPointHook,
			GameplayTagDefine.EGameplayTagId["角色.Common.技能通用标识.移动钩锁可用"]
		},
		{
			EHookInteractType.SlashHook,
			GameplayTagDefine.EGameplayTagId["角色.Common.技能通用标识.古英雄铠.变身可用标识"]
		},
		{
			EHookInteractType.ChargeSlashHook,
			GameplayTagDefine.EGameplayTagId["角色.Common.技能通用标识.古英雄铠.变身可用标识"]
		},
		{
			EHookInteractType.GravityHook,
			GameplayTagDefine.EGameplayTagId["角色.Common.技能通用标识.重力钩锁.可用"]
		},
		{
			EHookInteractType.PilotThrow,
			GameplayTagDefine.EGameplayTagId["角色.Common.技能通用标识.铁驭投掷.可用"]
		},
		{
			EHookInteractType.CableWay,
			GameplayTagDefine.EGameplayTagId["角色.Common.技能通用标识.索道.可用"]
		},
		{
			EHookInteractType.MotorPullInteract,
			GameplayTagDefine.EGameplayTagId["角色.Common.技能通用标识.定点钩索可用"]
		},
		{
			EHookInteractType.SunSpiritLauncher,
			GameplayTagDefine.EGameplayTagId["角色.Common.技能通用标识.日灵交互启动器.可用"]
		},
		{
			EHookInteractType.SpaceStationEnergyCore,
			GameplayTagDefine.EGameplayTagId["角色.Common.技能通用标识.空间站能量核心.可用"]
		},
		{
			EHookInteractType.MotorEject,
			GameplayTagDefine.EGameplayTagId["角色.Common.技能通用标识.摩托弹射机关可用"]
		}
	};

	// Token: 0x0400D327 RID: 54055
	[StaticVariableRuleIgnore]
	public static readonly Dictionary<EHookInteractType, int[]> MultipurposeHookTagMap = new Dictionary<EHookInteractType, int[]>
	{
		{
			EHookInteractType.FixedPointHook,
			new int[]
			{
				GameplayTagDefine.EGameplayTagId["角色.Common.技能通用标识.定点钩索可用"],
				GameplayTagDefine.EGameplayTagId["角色.Common.技能通用标识.摩托车.定点钩锁.可用"]
			}
		},
		{
			EHookInteractType.CableWay,
			new int[]
			{
				GameplayTagDefine.EGameplayTagId["角色.Common.技能通用标识.索道.可用"],
				GameplayTagDefine.EGameplayTagId["角色.Common.技能通用标识.摩托车.索道.可用"]
			}
		},
		{
			EHookInteractType.PilotThrow,
			new int[]
			{
				GameplayTagDefine.EGameplayTagId["角色.Common.技能通用标识.铁驭投掷.可用"],
				GameplayTagDefine.EGameplayTagId["角色.Common.技能通用标识.摩托车.铁驭投掷.可用"]
			}
		},
		{
			EHookInteractType.MotorPullInteract,
			new int[]
			{
				GameplayTagDefine.EGameplayTagId["角色.Common.技能通用标识.定点钩索可用"],
				GameplayTagDefine.EGameplayTagId["角色.Common.技能通用标识.摩托车.拉取采集物.可用"]
			}
		}
	};

	// Token: 0x0400D328 RID: 54056
	[StaticVariableRuleIgnore]
	public static readonly HashSet<EHookInteractType> MotorcycleDetectableHookType = new HashSet<EHookInteractType>
	{
		EHookInteractType.CableWay,
		EHookInteractType.PilotThrow,
		EHookInteractType.MotorPullInteract,
		EHookInteractType.FollowerShoot
	};

	// Token: 0x0400D329 RID: 54057
	[Nullable(new byte[]
	{
		1,
		1,
		2
	})]
	[StaticVariableRuleIgnore]
	public static readonly Dictionary<EHookInteractType, Func<HookLockPoint, bool>> MotorcycleDetectableHookCondition = new Dictionary<EHookInteractType, Func<HookLockPoint, bool>>
	{
		{
			EHookInteractType.KiteHook,
			delegate(HookLockPoint config)
			{
				if (config == null)
				{
					return false;
				}
				IMotorHookConfig motorHookConfig = config.MotorHookConfig;
				return ((motorHookConfig != null) ? motorHookConfig.AutoExit : null).GetValueOrDefault();
			}
		}
	};
}
