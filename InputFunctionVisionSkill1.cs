using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using AkiClient.Game.Aki.Character.Input.Enum;
using AkiClient.Game.Aki.Character.Input.Structures;
using AkiClient.Game.Aki.Character.Vision;
using CSharpScript.Core.Common;
using CSharpScript.Game;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.NewWorld.Character.Common.Component.Explore;
using CSharpScript.Game.NewWorld.Character.Custom.Components;
using CSharpScript.Game.NewWorld.Character.Role.Component;
using UnrealEngine;

// Token: 0x0200309C RID: 12444
[NullableContext(1)]
[Nullable(0)]
public class InputFunctionVisionSkill1 : IStaticVariableResetter
{
	// Token: 0x06019A40 RID: 105024 RVA: 0x00773C3C File Offset: 0x00771E3C
	static InputFunctionVisionSkill1()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(InputFunctionVisionSkill1.CreateStaticDefaultValue), new Action(InputFunctionVisionSkill1.ResetStaticDefaultValue));
	}

	// Token: 0x06019A41 RID: 105025 RVA: 0x00773C98 File Offset: 0x00771E98
	public static void CreateStaticDefaultValue()
	{
		InputFunctionVisionSkill1.MotorcycleDisableChain = new MotorFunctionDisableHandler();
		InputFunctionVisionSkill1.MotorcycleDisableChain.SetNext(new CharacterResponseInputDisableHandler()).SetNext(new PositionStateDisableHandler()).SetNext(new TagDisableHandler()).SetNext(new EntityDisableHandler()).SetNext(new OnlineDisableHandler());
	}

	// Token: 0x06019A42 RID: 105026 RVA: 0x00773CE7 File Offset: 0x00771EE7
	public static void ResetStaticDefaultValue()
	{
		InputFunctionVisionSkill1.MotorcycleDisableChain = null;
	}

	// Token: 0x06019A43 RID: 105027 RVA: 0x00773CF0 File Offset: 0x00771EF0
	private static bool VisionSkill1TraceDetectHasGround(Entity entity)
	{
		CharacterActorComponent component = entity.GetComponent<CharacterActorComponent>();
		if (component == null)
		{
			return false;
		}
		UTraceSphereElement actorTrace = ModelBase<TraceElementModel>.Instance.GetActorTrace();
		actorTrace.WorldContextObject = component.Actor;
		actorTrace.Radius = component.ScaledRadius;
		Singleton<TraceElementCommon>.Instance.SetStartLocation(actorTrace, component.FloorLocation);
		Vector tmpVector = InputFunctionVisionSkill1.TmpVector;
		FVectorDouble fvectorDouble = component.ActorTransform.TransformVectorNoScale(InputFunctionVisionSkill1.SoarLandDetectOffset);
		tmpVector.FromUeVector(fvectorDouble);
		InputFunctionVisionSkill1.TmpVector.AdditionEqual(component.FloorLocation);
		Singleton<TraceElementCommon>.Instance.SetEndLocation(actorTrace, InputFunctionVisionSkill1.TmpVector);
		actorTrace.ActorsToIgnore.Empty(true);
		return Singleton<TraceElementCommon>.Instance.ShapeTrace(component.Actor.CapsuleComponent, actorTrace, "SoarEnterDetect", "SoarEnterDetect");
	}

	// Token: 0x06019A44 RID: 105028 RVA: 0x00773DAC File Offset: 0x00771FAC
	private static bool IsFollowerDisable(BaseTagComponent tagComp)
	{
		return tagComp.HasAnyTag(new int[]
		{
			GameplayTagDefine.EGameplayTagId["功能.功能制作.瞄准模式.瞄准蓄力"],
			GameplayTagDefine.EGameplayTagId["功能.功能制作.瞄准模式.瞄准射击"],
			GameplayTagDefine.EGameplayTagId["功能.功能制作.瞄准模式.瞄准键进入"],
			GameplayTagDefine.EGameplayTagId["功能.功能制作.瞄准模式.通用瞄准进入"],
			GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.技能中.全身动作"],
			GameplayTagDefine.EGameplayTagId["行为状态.动作状态.受击"]
		});
	}

	// Token: 0x06019A45 RID: 105029 RVA: 0x00773E34 File Offset: 0x00772034
	[NullableContext(2)]
	private static SInputCommand VisionSkill1Function(float time)
	{
		TsBaseCharacter baseCharacter = Global.BaseCharacter;
		if (baseCharacter == null)
		{
			return null;
		}
		CharacterActorComponent characterActorComponent = baseCharacter.CharacterActorComponent;
		Entity entity = (characterActorComponent != null) ? characterActorComponent.Entity : null;
		if (entity == null)
		{
			return null;
		}
		BaseTagComponent component = entity.GetComponent<BaseTagComponent>();
		if (component == null || !component.Valid)
		{
			return null;
		}
		BaseMoveComponent component2 = entity.GetComponent<BaseMoveComponent>();
		if (component2 == null || !component2.CanResponseInput() || component.HasTag(GameplayTagDefine.EGameplayTagId["角色.BaseRole.技能通用标识.幻象变身中"]))
		{
			return null;
		}
		SInputCommand sinputCommand = InputFunctionCommon.CreateInputCommandFromDataTable(entity.Id, EInputAction.幻象1, EInputState.Press);
		if (sinputCommand != null)
		{
			return sinputCommand;
		}
		if (component.HasTag(GameplayTagDefine.EGameplayTagId["关卡.道具.怨鸟泽.水龙卷buff"]))
		{
			CharacterMoveComponent component3 = entity.GetComponent<CharacterMoveComponent>();
			if (component3 != null && component3.IsOnGroundOrOnWater())
			{
				return InputFunctionCommon.CreateSkillCommand(entity, 210014);
			}
		}
		else if (component.HasTag(GameplayTagDefine.EGameplayTagId["关卡.时停状态.可使用时停"]))
		{
			if (component.HasTag(GameplayTagDefine.EGameplayTagId["关卡.时停状态.进入时停"]))
			{
				return InputFunctionCommon.CreateSkillCommand(entity, 210024);
			}
			return InputFunctionCommon.CreateSkillCommand(entity, 210023);
		}
		else if (component.HasTag(GameplayTagDefine.EGameplayTagId["辅助机.通用标签.幻象1召唤"]))
		{
			if (InputFunctionVisionSkill1.IsFollowerDisable(component))
			{
				return null;
			}
			return InputFunctionCommon.CreateSkillCommand(entity, 210020);
		}
		int currentExploreSkillId = ModelBase<RouletteModel>.Instance.CurrentExploreSkillId;
		if (currentExploreSkillId == 0)
		{
			return null;
		}
		int num = 0;
		SVisionData visionData = PhantomUtil.GetVisionData(currentExploreSkillId);
		if (visionData != null && visionData.类型 == EVisionType.探索)
		{
			num = visionData.技能ID;
		}
		if (num == 210001)
		{
			int pbDataId = baseCharacter.CharacterActorComponent.CreatureData.GetPbDataId();
			if (ConfigBase<RoleConfig>.Instance.GetBaseRoleId(pbDataId) == 1208 && component.HasTag(GameplayTagDefine.EGameplayTagId["功能.通用镜头.第一人称镜头"]))
			{
				num = 1208713;
			}
			else if (component.HasTag(GameplayTagDefine.EGameplayTagId["角色.Common.技能通用标识.风筝钩索可用"]))
			{
				num = 210130;
			}
			else if (component.HasTag(GameplayTagDefine.EGameplayTagId["角色.Common.技能通用标识.移动钩锁可用"]))
			{
				num = 100024;
			}
			else if (component.HasTag(GameplayTagDefine.EGameplayTagId["角色.Common.技能通用标识.摩托弹射机关可用"]))
			{
				num = 800017;
			}
			else
			{
				RoleSceneInteractComponent component4 = entity.GetComponent<RoleSceneInteractComponent>();
				if (component4 != null && component4.CanActivateFixHook())
				{
					if (component.HasTag(GameplayTagDefine.EGameplayTagId["角色.Common.探索技能.定点钩锁切换"]))
					{
						num = 100021;
					}
					else
					{
						num = 100020;
					}
				}
				else
				{
					if (component.HasTag(GameplayTagDefine.EGameplayTagId["角色.Common.技能通用标识.定点钩索"]))
					{
						return null;
					}
					if (component.HasTag(GameplayTagDefine.EGameplayTagId["角色.Common.探索技能.禁用自由钩锁"]))
					{
						ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("ExploreToolsDisable011007", Array.Empty<object>());
						return null;
					}
					if (component.HasTag(GameplayTagDefine.EGameplayTagId["角色.Common.技能通用标识.定点钩索可用"]))
					{
						return null;
					}
				}
			}
		}
		else if (num == 2100081)
		{
			if (component.HasAnyTag(new int[]
			{
				GameplayTagDefine.EGameplayTagId["行为状态.位置状态.空中"],
				GameplayTagDefine.EGameplayTagId["行为状态.位置状态.水中"],
				GameplayTagDefine.EGameplayTagId["行为状态.位置状态.攀爬"],
				GameplayTagDefine.EGameplayTagId["战斗状态.技能限制.禁止声骸展示技能"],
				GameplayTagDefine.EGameplayTagId["角色.Common.探索技能.禁用声骸显像"]
			}))
			{
				return null;
			}
		}
		else if (num == 210003)
		{
			if (component.HasTag(GameplayTagDefine.EGameplayTagId["角色.Common.技能通用标识.拉取巨物可用"]))
			{
				num = 2100031;
			}
			else if (component.HasTag(GameplayTagDefine.EGameplayTagId["角色.Common.技能通用标识.拉取雕像可用"]))
			{
				num = 2100033;
			}
			else if (component.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.位置状态.攀爬"]) || !component.HasTag(GameplayTagDefine.EGameplayTagId["角色.Common.技能通用标识.控物可用"]))
			{
				return null;
			}
		}
		else if (num == 210020)
		{
			if (!component.HasTag(GameplayTagDefine.EGameplayTagId["辅助机.通用射击"]))
			{
				if (component.HasTag(GameplayTagDefine.EGameplayTagId["角色.Common.探索技能.禁用辅助机"]) || component.HasTag(GameplayTagDefine.EGameplayTagId["角色.Common.BUFF通用标识.禁止瞄准模式"]))
				{
					ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("ExploreToolsShooterDisable", Array.Empty<object>());
					return null;
				}
				if (InputFunctionVisionSkill1.IsFollowerDisable(component))
				{
					return null;
				}
			}
		}
		else if (num == 210030)
		{
			if (component.HasTag(GameplayTagDefine.EGameplayTagId["角色.Common.探索技能.翱翔内置CD"]))
			{
				return null;
			}
			if (component.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.动作状态.XA"]))
			{
				baseCharacter.KuroSetMovementMode(new SetMovementModeInfo
				{
					Mode = EMovementMode.MOVE_Falling,
					Context = "[visionSkill1Function]"
				});
				return null;
			}
			CharacterGlideComponent component5 = entity.GetComponent<CharacterGlideComponent>();
			ValueTuple<bool, string>? valueTuple = (component5 != null) ? new ValueTuple<bool, string>?(component5.CheckSoarAllowed()) : null;
			if (valueTuple == null || (valueTuple != null && !valueTuple.GetValueOrDefault().Item1))
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Flying_Tip_002", Array.Empty<object>());
				return null;
			}
			if (component.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.进入战斗"]))
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Flying_Tip_002", Array.Empty<object>());
				return null;
			}
			BaseUnifiedStateComponent component6 = entity.GetComponent<BaseUnifiedStateComponent>();
			ECharPositionState? echarPositionState = (component6 != null) ? new ECharPositionState?(component6.PositionState) : null;
			if (echarPositionState.GetValueOrDefault() == ECharPositionState.Air)
			{
				BaseMoveComponent component7 = entity.GetComponent<BaseMoveComponent>();
				float? num2 = (component7 != null) ? new float?(component7.GetHeightAboveGround(650f)) : null;
				if (num2 != null)
				{
					float? num3 = num2;
					float num4 = 650f;
					if (!(num3.GetValueOrDefault() < num4 & num3 != null))
					{
						goto IL_686;
					}
				}
				if (InputFunctionVisionSkill1.VisionSkill1TraceDetectHasGround(entity))
				{
					ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Flying_Tip", Array.Empty<object>());
					return null;
				}
			}
			else
			{
				ECharPositionState? echarPositionState2 = echarPositionState;
				ECharPositionState echarPositionState3 = ECharPositionState.Ground;
				if (!(echarPositionState2.GetValueOrDefault() == echarPositionState3 & echarPositionState2 != null))
				{
					ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Flying_Tip_002", Array.Empty<object>());
					return null;
				}
				num = 210031;
			}
		}
		else if (num == 800001 || num == 800002 || num == 800003)
		{
			if (InputFunctionVisionSkill1.MotorcycleDisableChain == null || InputFunctionVisionSkill1.MotorcycleDisableChain.Stop(new InputFunctionContext(entity, num)))
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Flying_Tip_002", Array.Empty<object>());
				return null;
			}
		}
		else if (currentExploreSkillId == 121001 && (!component.HasTag(GameplayTagDefine.EGameplayTagId["角色.AimisiMd10011.状态.主控机甲"]) || component.HasTag(GameplayTagDefine.EGameplayTagId["角色.AimisiMd10011.状态.低冲刺能量"])))
		{
			return null;
		}
		IL_686:
		if (num != 0)
		{
			if (ModelBase<ExploreSkillFlagModel>.Instance.GetExploreSkillFlagEnable((EExploreSkillType)num))
			{
				CharacterExploreComponent characterExploreComponent = (entity != null) ? entity.GetComponent<CharacterExploreComponent>() : null;
				RouletteModel instance = ModelBase<RouletteModel>.Instance;
				int exploreSkillId = currentExploreSkillId;
				int skillId = num;
				int? num5;
				if (characterExploreComponent == null)
				{
					num5 = null;
				}
				else
				{
					GrapplingHookPointComponent focusTarget = characterExploreComponent.FocusTarget;
					num5 = ((focusTarget != null) ? new int?(focusTarget.EntityConfigId) : null);
				}
				int? num6 = num5;
				instance.TrySendExploreToolGeneralUseLogData(exploreSkillId, skillId, num6.GetValueOrDefault());
				return InputFunctionCommon.CreateSkillCommand(entity, num);
			}
			ControllerBase<GenericPromptController>.Instance.ShowPromptByCode(EMapExploreToolCheckTipId.TempTeleporterPlacementBanned.ToEnumString(), Array.Empty<object>());
		}
		return null;
	}

	// Token: 0x06019A46 RID: 105030 RVA: 0x00774552 File Offset: 0x00772752
	[NullableContext(2)]
	public static SInputCommand VisionSkill1OnPress(float time)
	{
		if (Singleton<Info>.Instance.IsInTouch())
		{
			return null;
		}
		return InputFunctionVisionSkill1.VisionSkill1Function(time);
	}

	// Token: 0x06019A47 RID: 105031 RVA: 0x00774568 File Offset: 0x00772768
	[NullableContext(2)]
	public static SInputCommand VisionSkill1OnRelease(float time)
	{
		if (!Singleton<Info>.Instance.IsInTouch())
		{
			return null;
		}
		if (UiBlueprintFunctionLibrary.IsLongPressExploreButton())
		{
			return null;
		}
		return InputFunctionVisionSkill1.VisionSkill1Function(time);
	}

	// Token: 0x06019A48 RID: 105032 RVA: 0x00774588 File Offset: 0x00772788
	public static int? GetVisionSkill1SkillId()
	{
		SInputCommand sinputCommand = InputFunctionVisionSkill1.VisionSkill1Function(0f);
		if (sinputCommand != null)
		{
			return new int?(sinputCommand.IntValue);
		}
		return null;
	}

	// Token: 0x0400CC38 RID: 52280
	[Nullable(2)]
	private static MotorFunctionDisableHandler MotorcycleDisableChain;

	// Token: 0x0400CC39 RID: 52281
	private const float SOAR_HEIGHT_LIMIT = 650f;

	// Token: 0x0400CC3A RID: 52282
	[StaticVariableRuleIgnore]
	private static readonly FVectorDouble SoarLandDetectOffset = new FVectorDouble(1100.0, 0.0, -500.0);

	// Token: 0x0400CC3B RID: 52283
	private const int ROLE_ID_CALBRENA = 1208;

	// Token: 0x0400CC3C RID: 52284
	private const string PROFILE_KEY = "SoarEnterDetect";

	// Token: 0x0400CC3D RID: 52285
	[StaticVariableRuleIgnore]
	private static readonly Vector TmpVector = Vector.Create();
}
