using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using AkiClient.Game.Aki.Character.BaseCharacter;
using CSharpScript.Game;
using UnrealEngine;

// Token: 0x02003121 RID: 12577
[NullableContext(1)]
[Nullable(0)]
public class CharacterSkillComponent : BaseSkillComponent, IStaticVariableResetter
{
	// Token: 0x0601A093 RID: 106643 RVA: 0x007A0774 File Offset: 0x0079E974
	static CharacterSkillComponent()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(CharacterSkillComponent.CreateStaticDefaultValue), new Action(CharacterSkillComponent.ResetStaticDefaultValue));
	}

	// Token: 0x1700234F RID: 9039
	// (get) Token: 0x0601A094 RID: 106644 RVA: 0x007A07E9 File Offset: 0x0079E9E9
	[Nullable(2)]
	protected new CharacterActorComponent ActorComp
	{
		[NullableContext(2)]
		get
		{
			return this.ActorComp as CharacterActorComponent;
		}
	}

	// Token: 0x0601A095 RID: 106645 RVA: 0x007A07F8 File Offset: 0x0079E9F8
	[NullableContext(2)]
	protected override bool OnInitData(IEntityArgs args = null)
	{
		if (!base.OnInitData(null))
		{
			return false;
		}
		this.ActorComp = base.Entity.GetComponent<CharacterActorComponent>();
		if (!CharacterSkillComponent._isConfigInited)
		{
			CharacterSkillComponent._jumpPriority = ConfigCommonParamById.GetIntConfig("jump_priority").GetValueOrDefault();
			CharacterSkillComponent._glidePriority = ConfigCommonParamById.GetIntConfig("fly_priority").GetValueOrDefault();
			CharacterSkillComponent._isConfigInited = true;
		}
		return true;
	}

	// Token: 0x0601A096 RID: 106646 RVA: 0x007A085D File Offset: 0x0079EA5D
	protected override bool OnInit()
	{
		if (!base.OnInit())
		{
			return false;
		}
		this.MoveComp = base.Entity.GetComponent<CharacterMoveComponent>();
		this.StateComp = base.Entity.CheckGetComponent<CharacterUnifiedStateComponent>();
		this.AnimComp = base.Entity.GetComponent<CharacterAnimationComponent>();
		return true;
	}

	// Token: 0x0601A097 RID: 106647 RVA: 0x007A08A0 File Offset: 0x0079EAA0
	protected override bool OnEnd()
	{
		if (!base.OnEnd())
		{
			return false;
		}
		this.SkillElevationAngleInternal = 0f;
		this.LastActivateSkillTimeInternal = 0f;
		if (this.RollingGroundEndTimer != null)
		{
			TimerSystem.Instance.Remove(this.RollingGroundEndTimer);
			this.RollingGroundEndTimer = null;
		}
		return true;
	}

	// Token: 0x0601A098 RID: 106648 RVA: 0x007A08F0 File Offset: 0x0079EAF0
	protected override void DoSkillBeginMoveAction(global::Skill skill, SSkillInfo info)
	{
		this.StateComp.ExitHitState("释放技能");
		this.SetSkillTargetDirection(info.SkillDirection, info.SkillTarget.SkillTargetPriority);
		this.SetSkillMoveState(skill.SkillId, info);
		CharacterAnimationComponent animComp = this.AnimComp;
		if (animComp == null)
		{
			return;
		}
		animComp.StartForceDisableAnimOptimization(EForceDisableAnimOptimization.Skill, false);
	}

	// Token: 0x0601A099 RID: 106649 RVA: 0x007A0950 File Offset: 0x0079EB50
	public void SetSkillTargetDirection(ESkillTargetDirection direction, ESkillTargetPriority priority = ESkillTargetPriority.摇杆方向优先)
	{
		BaseLockOnComponent lockOnComp = this.LockOnComp;
		if (lockOnComp != null && lockOnComp.Valid)
		{
			switch (direction)
			{
			case ESkillTargetDirection.技能目标方向:
			{
				EntityHandle skillTarget = this.SkillTarget;
				if (skillTarget != null && skillTarget.Valid)
				{
					this.TurnToSkillTarget();
					return;
				}
				if (priority == ESkillTargetPriority.镜头方向优先_精准模式_)
				{
					this.TurnToCameraDir();
					return;
				}
				this.TurnToInputDir();
				return;
			}
			case ESkillTargetDirection.摇杆方向:
				this.TurnToInputDir();
				return;
			case ESkillTargetDirection.角色方向:
				break;
			case ESkillTargetDirection.相机方向:
				this.TurnToCameraDir();
				break;
			default:
				return;
			}
		}
	}

	// Token: 0x0601A09A RID: 106650 RVA: 0x007A09C4 File Offset: 0x0079EBC4
	private void TurnToInputDir()
	{
		if (!this.ActorComp.IsAutonomousProxy)
		{
			return;
		}
		if (!this.IsHasInputDir())
		{
			return;
		}
		CharacterInputComponent component = base.Entity.GetComponent<CharacterInputComponent>();
		if (component != null && component.IsLocalInput)
		{
			return;
		}
		Singleton<MathUtils>.Instance.LookRotationUpFirst(this.ActorComp.InputDirectProxy, this.MoveComp.GravityUp, this.TmpRotator);
		this.TmpTransform.Set(this.ActorComp.ActorLocationProxy, this.TmpRotator.Quaternion(null), this.ActorComp.ActorScaleProxy);
		this.ActorComp.SetActorTransform(this.TmpTransform.ToUeTransform(), "释放技能.转向输入方向", false, new ESetRotationPriority?(ESetRotationPriority.Skill));
	}

	// Token: 0x0601A09B RID: 106651 RVA: 0x007A0A78 File Offset: 0x0079EC78
	public bool IsHasInputDir()
	{
		if (!base.CheckIsLoaded())
		{
			return false;
		}
		global::Vector inputDirectProxy = this.ActorComp.InputDirectProxy;
		return 0.0 < Math.Abs(inputDirectProxy.X) || 0.0 < Math.Abs(inputDirectProxy.Y);
	}

	// Token: 0x0601A09C RID: 106652 RVA: 0x007A0ACC File Offset: 0x0079ECCC
	private void TurnToCameraDir()
	{
		Rotator tmpRotator = this.TmpRotator;
		FRotator cameraRotation = Global.CharacterCameraManager.GetCameraRotation();
		tmpRotator.FromUeRotator(cameraRotation);
		this.TmpRotator.Vector(this.TmpVector);
		MathUtils instance = Singleton<MathUtils>.Instance;
		global::Vector tmpVector = this.TmpVector;
		CharacterActorComponent actorComp = this.ActorComp;
		global::Vector vector;
		if (actorComp == null)
		{
			vector = null;
		}
		else
		{
			BaseMoveComponent moveComp = actorComp.MoveComp;
			vector = ((moveComp != null) ? moveComp.GravityUp : null);
		}
		instance.LookRotationUpFirst(tmpVector, vector ?? global::Vector.UpVectorProxy, this.TmpRotator);
		this.TmpTransform.Set(this.ActorComp.ActorLocationProxy, this.TmpRotator.Quaternion(null), this.ActorComp.ActorScaleProxy);
		this.ActorComp.SetActorTransform(this.TmpTransform.ToUeTransform(), "释放技能.转向摄像机方向", false, new ESetRotationPriority?(ESetRotationPriority.Skill));
	}

	// Token: 0x0601A09D RID: 106653 RVA: 0x007A0B90 File Offset: 0x0079ED90
	private void TurnToSkillTarget()
	{
		if (this.SkillTarget == null)
		{
			return;
		}
		global::Vector tmpVector = this.TmpVector;
		FVectorDouble location = base.GetTargetTransform().GetLocation();
		tmpVector.FromUeVector(location);
		this.TmpVector.SubtractionEqual(this.ActorComp.ActorLocationProxy);
		MathUtils instance = Singleton<MathUtils>.Instance;
		global::Vector tmpVector2 = this.TmpVector;
		CharacterActorComponent actorComp = this.ActorComp;
		global::Vector vector;
		if (actorComp == null)
		{
			vector = null;
		}
		else
		{
			BaseMoveComponent moveComp = actorComp.MoveComp;
			vector = ((moveComp != null) ? moveComp.GravityUp : null);
		}
		instance.LookRotationUpFirst(tmpVector2, vector ?? global::Vector.UpVectorProxy, this.TmpRotator);
		this.ActorComp.SetActorRotation(this.TmpRotator.ToUeRotator(), "释放技能.转向技能目标", false);
	}

	// Token: 0x0601A09E RID: 106654 RVA: 0x007A0C33 File Offset: 0x0079EE33
	private Rotator GetInputRotatorOfWorld()
	{
		return this.ActorComp.InputRotatorProxy;
	}

	// Token: 0x0601A09F RID: 106655 RVA: 0x007A0C40 File Offset: 0x0079EE40
	private void SetSkillMoveState(int skillId, SSkillInfo info)
	{
		if (info.WalkOffLedge)
		{
			this.MoveComp.SetWalkOffLedgeRecord(false);
		}
		if (info.SkillStepUp)
		{
			this.MoveComp.SetStepUpParamsRecord(false);
		}
		if (1 == info.GroupId)
		{
			if (this.MoveComp != null && this.MoveComp.CharacterMovement.MovementMode == EMovementMode.MOVE_Custom)
			{
				byte customMovementMode = this.MoveComp.CharacterMovement.CustomMovementMode;
				if (customMovementMode == 2)
				{
					CharacterGlideComponent component = base.Entity.GetComponent<CharacterGlideComponent>();
					if (component.Valid)
					{
						component.ExitGlideState("Skill");
					}
				}
				else if (customMovementMode == 7)
				{
					CharacterGlideComponent component2 = base.Entity.GetComponent<CharacterGlideComponent>();
					if (component2.Valid)
					{
						component2.ExitSoarState(EMovementMode.MOVE_Falling, "Skill");
					}
				}
			}
			switch (this.StateComp.MoveState)
			{
			case ECharMoveState.WalkStop:
			case ECharMoveState.RunStop:
			case ECharMoveState.SprintStop:
				this.StateComp.SetMoveState(ECharMoveState.Stand);
				break;
			case ECharMoveState.Sprint:
				if (!this.TagComp.HasTag(GameplayTagDefine.EGameplayTagId["角色.Common.技能通用标识.闪避"]))
				{
					int value = GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.冲刺保持"];
					this.TagComp.RemoveTag(new int?(value));
					CharacterBuffComponent buffComp = this.BuffComp;
					if (buffComp != null)
					{
						int? tagId = new int?(value);
						DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(6, 1);
						defaultInterpolatedStringHandler.AppendLiteral("技能");
						defaultInterpolatedStringHandler.AppendFormatted<int>(skillId);
						defaultInterpolatedStringHandler.AppendLiteral("结束移动");
						buffComp.RemoveBuffByTag(tagId, defaultInterpolatedStringHandler.ToStringAndClear(), null);
					}
					this.StateComp.SetMoveState(ECharMoveState.Run);
				}
				break;
			}
		}
		this.MoveComp.CharacterMovement.OverrideTerminalVelocity = 99999f;
		this.MoveComp.SetFallingHorizontalMaxSpeed(99999f);
	}

	// Token: 0x0601A0A0 RID: 106656 RVA: 0x007A0E04 File Offset: 0x0079F004
	protected override void DoSkillEndMoveAction(SSkillInfo info)
	{
		if (info.WalkOffLedge)
		{
			this.MoveComp.SetWalkOffLedgeRecord(true);
		}
		if (info.SkillStepUp)
		{
			this.MoveComp.SetStepUpParamsRecord(true);
		}
		this.MoveComp.CharacterMovement.OverrideTerminalVelocity = 0f;
		this.MoveComp.ClearFallingHorizontalMaxSpeed();
		CharacterAnimationComponent animComp = this.AnimComp;
		if (animComp == null)
		{
			return;
		}
		animComp.CancelForceDisableAnimOptimization(EForceDisableAnimOptimization.Skill);
	}

	// Token: 0x0601A0A1 RID: 106657 RVA: 0x007A0E6A File Offset: 0x0079F06A
	protected override void OnBeforePlaySkillMontage()
	{
		this.StateComp.ExitHitState("播放技能蒙太奇");
	}

	// Token: 0x0601A0A2 RID: 106658 RVA: 0x007A0E7C File Offset: 0x0079F07C
	[NullableContext(2)]
	public override UAnimInstance GetMainAnimInstance()
	{
		return this.AnimComp.GetAnimInstance();
	}

	// Token: 0x0601A0A3 RID: 106659 RVA: 0x007A0E8C File Offset: 0x0079F08C
	public void RollingGrounded()
	{
		this.IsMainSkillReadyEnd = false;
		this.RollingGroundEndTimer = TimerSystem.Instance.Delay(new TTimerAction(this.RollingGroundedDelay), 600f, null, null, true, 1f);
		if (this.StateComp.PositionState == ECharPositionState.Ground)
		{
			this.StateComp.SetMoveState(ECharMoveState.LandRoll);
		}
	}

	// Token: 0x0601A0A4 RID: 106660 RVA: 0x007A0EE4 File Offset: 0x0079F0E4
	private void RollingGroundedDelay(float delta)
	{
		if (!this.TagComp.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.技能中"]))
		{
			Singleton<CombatLog>.Instance.Info(CombatLog.EDebugModule.Skill, base.Entity, "疑难杂症debug日志，RollingGroundedDelay", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.IsMainSkillReadyEnd = true;
		}
		this.RollingGroundEndTimer = null;
	}

	// Token: 0x0601A0A5 RID: 106661 RVA: 0x007A0F3C File Offset: 0x0079F13C
	public bool UpdateAllSkillRotator(float deltaSeconds)
	{
		if (!base.CheckIsLoaded() || this.MoveComp == null)
		{
			return false;
		}
		if (this.TagComp.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.位置状态.攀爬"]))
		{
			return false;
		}
		if (!this.SkillCanRotateInternal)
		{
			return false;
		}
		if (!this.ActorComp.IsMoveAutonomousProxy)
		{
			return false;
		}
		float speed = Math.Abs(this.SkillRotateSpeedInternal);
		if (this.SkillRotateToTargetInternal)
		{
			global::Vector currentSkillRotateDirect = base.GetCurrentSkillRotateDirect();
			if (currentSkillRotateDirect.IsNearlyZero(9.999999747378752E-05))
			{
				return false;
			}
			MathUtils instance = Singleton<MathUtils>.Instance;
			global::Vector forward = currentSkillRotateDirect;
			CharacterActorComponent actorComp = this.ActorComp;
			global::Vector vector;
			if (actorComp == null)
			{
				vector = null;
			}
			else
			{
				BaseMoveComponent moveComp = actorComp.MoveComp;
				vector = ((moveComp != null) ? moveComp.GravityUp : null);
			}
			instance.LookRotationUpFirst(forward, vector ?? global::Vector.UpVectorProxy, this.TmpRotator);
			this.MoveComp.SmoothCharacterRotation(this.TmpRotator, speed, deltaSeconds, false, "Skill.UpdateAllSkillRotator", true);
		}
		else
		{
			this.MoveComp.SmoothCharacterRotation(this.GetInputRotatorOfWorld(), speed, deltaSeconds, false, "Skill.UpdateAllSkillRotator", true);
		}
		return true;
	}

	// Token: 0x0601A0A6 RID: 106662 RVA: 0x007A102F File Offset: 0x0079F22F
	public bool CheckJumpCanInterrupt()
	{
		return base.DoCheckInterrupt(1, CharacterSkillComponent._jumpPriority, null, null, null);
	}

	// Token: 0x0601A0A7 RID: 106663 RVA: 0x007A1040 File Offset: 0x0079F240
	public bool CheckGlideCanInterrupt()
	{
		return base.DoCheckInterrupt(1, CharacterSkillComponent._glidePriority, null, null, null);
	}

	// Token: 0x17002350 RID: 9040
	// (get) Token: 0x0601A0A8 RID: 106664 RVA: 0x007A1051 File Offset: 0x0079F251
	public float SkillElevationAngle
	{
		get
		{
			return this.SkillElevationAngleInternal;
		}
	}

	// Token: 0x0601A0A9 RID: 106665 RVA: 0x007A1059 File Offset: 0x0079F259
	public void SetSkillElevationAngle(float angle)
	{
		this.SkillElevationAngleInternal = angle;
	}

	// Token: 0x17002351 RID: 9041
	// (get) Token: 0x0601A0AA RID: 106666 RVA: 0x007A1062 File Offset: 0x0079F262
	public float LastActivateSkillTime
	{
		get
		{
			return this.LastActivateSkillTimeInternal;
		}
	}

	// Token: 0x0601A0AB RID: 106667 RVA: 0x007A106A File Offset: 0x0079F26A
	public void SetLastActivateSkillTime(float time)
	{
		this.LastActivateSkillTimeInternal = time;
	}

	// Token: 0x0601A0AC RID: 106668 RVA: 0x007A1073 File Offset: 0x0079F273
	public static void CreateStaticDefaultValue()
	{
		CharacterSkillComponent._isConfigInited = false;
		CharacterSkillComponent._jumpPriority = 0;
		CharacterSkillComponent._glidePriority = 0;
	}

	// Token: 0x0601A0AD RID: 106669 RVA: 0x007A1087 File Offset: 0x0079F287
	public static void ResetStaticDefaultValue()
	{
		CharacterSkillComponent._isConfigInited = false;
		CharacterSkillComponent._jumpPriority = 0;
		CharacterSkillComponent._glidePriority = 0;
	}

	// Token: 0x0601A0AE RID: 106670 RVA: 0x007A109C File Offset: 0x0079F29C
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		CharacterSkillComponent characterSkillComponent = (CharacterSkillComponent)componentTemplate;
		if (base.CanResetComponentProperty("MoveComp"))
		{
			if (characterSkillComponent.MoveComp == null)
			{
				this.MoveComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterMoveComponent>(this.MoveComp), "MoveComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("StateComp"))
		{
			if (characterSkillComponent.StateComp == null)
			{
				this.StateComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterUnifiedStateComponent>(this.StateComp), "StateComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("AnimComp"))
		{
			if (characterSkillComponent.AnimComp == null)
			{
				this.AnimComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterAnimationComponent>(this.AnimComp), "AnimComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("RollingGroundEndTimer"))
		{
			if (characterSkillComponent.RollingGroundEndTimer == null)
			{
				this.RollingGroundEndTimer = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<TimerHandle>(this.RollingGroundEndTimer), "RollingGroundEndTimer"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("SkillElevationAngleInternal"))
		{
			this.SkillElevationAngleInternal = characterSkillComponent.SkillElevationAngleInternal;
		}
		if (base.CanResetComponentProperty("LastActivateSkillTimeInternal"))
		{
			this.LastActivateSkillTimeInternal = characterSkillComponent.LastActivateSkillTimeInternal;
		}
		return true;
	}

	// Token: 0x0400D0D0 RID: 53456
	private const int ROLLING_GROUNDED_RECOVER_TIME = 600;

	// Token: 0x0400D0D1 RID: 53457
	[StaticVariableRuleIgnore]
	private static readonly Stat StatDoSkillBegin5 = Stat.Create("DoSkillBegin5 SetAnimState", "", "");

	// Token: 0x0400D0D2 RID: 53458
	[StaticVariableRuleIgnore]
	private static readonly Stat StatDoSkillBegin6 = Stat.Create("DoSkillBegin6 Target&Rotation", "", "");

	// Token: 0x0400D0D3 RID: 53459
	[StaticVariableRuleIgnore]
	private static readonly Stat StatDoSkillBegin7 = Stat.Create("DoSkillBegin7 SetMoveState", "", "");

	// Token: 0x0400D0D4 RID: 53460
	[Nullable(2)]
	private CharacterMoveComponent MoveComp;

	// Token: 0x0400D0D5 RID: 53461
	[Nullable(2)]
	private CharacterUnifiedStateComponent StateComp;

	// Token: 0x0400D0D6 RID: 53462
	[Nullable(2)]
	private CharacterAnimationComponent AnimComp;

	// Token: 0x0400D0D7 RID: 53463
	private static bool _isConfigInited;

	// Token: 0x0400D0D8 RID: 53464
	private static int _jumpPriority;

	// Token: 0x0400D0D9 RID: 53465
	private static int _glidePriority;

	// Token: 0x0400D0DA RID: 53466
	[Nullable(2)]
	private TimerHandle RollingGroundEndTimer;

	// Token: 0x0400D0DB RID: 53467
	private float SkillElevationAngleInternal;

	// Token: 0x0400D0DC RID: 53468
	private float LastActivateSkillTimeInternal;
}
