using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using AkiClient.Game.Aki.Character.NPC.Tuanzi;
using CSharpScript.Game.Effect;
using CSharpScript.Game.NewWorld.Character.Common.Component;
using UnrealEngine;

// Token: 0x02003080 RID: 12416
[NullableContext(1)]
[Nullable(0)]
public class DangoPerformComponent : StackableChessComponent
{
	// Token: 0x17002270 RID: 8816
	// (get) Token: 0x06019982 RID: 104834 RVA: 0x0076F6D0 File Offset: 0x0076D8D0
	// (set) Token: 0x06019983 RID: 104835 RVA: 0x0076F6DD File Offset: 0x0076D8DD
	[Nullable(2)]
	protected new BaseCharacterComponent ActorComp
	{
		[NullableContext(2)]
		get
		{
			return this.ActorComp as BaseCharacterComponent;
		}
		[NullableContext(2)]
		set
		{
			this.ActorComp = value;
		}
	}

	// Token: 0x06019984 RID: 104836 RVA: 0x0076F6E6 File Offset: 0x0076D8E6
	protected override bool OnStart()
	{
		if (!base.OnStart())
		{
			return false;
		}
		this.ActorComp = base.Entity.CheckGetComponent<BaseCharacterComponent>();
		return true;
	}

	// Token: 0x06019985 RID: 104837 RVA: 0x0076F704 File Offset: 0x0076D904
	protected override void OnActivate()
	{
		CharacterAnimationComponent component = base.Entity.GetComponent<CharacterAnimationComponent>();
		UAnimInstance uanimInstance = (component != null) ? component.MainAnimInstance : null;
		if (uanimInstance != null && UKuroStaticLibrary.IsObjectClassByName(uanimInstance, new FName("ABP_TuanziNPC_C")))
		{
			this.AnimInstance = uanimInstance;
		}
		BaseCharacterComponent actorComp = this.ActorComp;
		AActor aactor = (actorComp != null) ? actorComp.Owner : null;
		if (aactor == null || !aactor.IsValid())
		{
			return;
		}
		this.TempVector.Set(1.2000000476837158, 1.2000000476837158, 1.2000000476837158);
		aactor.D_SetActorScale3D(this.TempVector.ToUeVector(false));
		UCharacterMovementComponent ucharacterMovementComponent = aactor.GetComponentByClass(UCharacterMovementComponent.StaticClass()) as UCharacterMovementComponent;
		if (ucharacterMovementComponent != null)
		{
			ucharacterMovementComponent.SetComponentTickEnabled(false);
		}
	}

	// Token: 0x06019986 RID: 104838 RVA: 0x0076F7BC File Offset: 0x0076D9BC
	protected override void OnTick(float delta)
	{
		if (this.MoveState == DangoPerformComponent.EMoveState.Idle)
		{
			return;
		}
		DangoGlobalConfig config = ModelBase<DangoGlobalModel>.Instance.Config;
		if (config == null)
		{
			return;
		}
		if (this.CurrentMoveTime >= (float)config.MoveTotalTime)
		{
			this.MoveEnd();
			return;
		}
		this.CurrentMoveTime += delta;
		if (this.CurrentMoveTime <= (float)config.MoveStartingTime)
		{
			return;
		}
		if (this.MoveState != DangoPerformComponent.EMoveState.Starting && this.CurrentMoveTime >= (float)(config.MoveStartingTime + config.MoveTime))
		{
			if (this.MoveState == DangoPerformComponent.EMoveState.Moving)
			{
				this.ActorComp.SetActorLocationAndRotation(this.MoveTargetLocation.ToUeVector(false), this.MoveTargetRotator.ToUeRotator(), "ChessMove", false, null);
				this.MoveState = DangoPerformComponent.EMoveState.Recovering;
			}
			return;
		}
		if (this.MoveState != DangoPerformComponent.EMoveState.Moving)
		{
			this.MoveState = DangoPerformComponent.EMoveState.Moving;
			ControllerBase<DangoGlobalController>.Instance.ApplyDangoMoveCamera(this.MoveTargetLocation);
		}
		float num = MathCommon.Clamp((this.CurrentMoveTime - (float)config.MoveStartingTime) / (float)config.MoveTime, 0f, 1f);
		Vector.Lerp(this.MoveStartLocation, this.MoveTargetLocation, (double)num, this.TempVector);
		float powerCurveValue = this.GetPowerCurveValue(num, 2f);
		float floatValue;
		if (this.SignOffsetRate > 0f)
		{
			floatValue = config.MoveRiseCurve.GetFloatValue(num);
		}
		else
		{
			floatValue = config.MoveFallCurve.GetFloatValue(num);
		}
		float num2 = Math.Abs(this.SignOffsetRate);
		float num3 = (powerCurveValue * (1f - num2) + floatValue * num2) * (float)config.MoveBaseHeightOffset;
		this.TempVector.Z += (double)num3;
		Rotator actorRotationProxy = this.ActorComp.ActorRotationProxy;
		if (!actorRotationProxy.Equals2(this.MoveTargetRotator, 0.0001f))
		{
			this.TempRotator.DeepCopy(this.MoveTargetRotator);
			Singleton<MathUtils>.Instance.RotatorInterpConstantTo(actorRotationProxy, this.TempRotator, delta * 0.001f, (float)config.MoveRotateSpeed, this.TempRotator);
		}
		this.ActorComp.SetActorLocationAndRotation(this.TempVector.ToUeVector(false), this.TempRotator.ToUeRotator(), "ChessMove", false, null);
	}

	// Token: 0x06019987 RID: 104839 RVA: 0x0076F9D4 File Offset: 0x0076DBD4
	private float GetPowerCurveValue(float key, float pow)
	{
		return 1f - (float)Math.Pow((double)Math.Abs(2f * key - 1f), (double)pow);
	}

	// Token: 0x06019988 RID: 104840 RVA: 0x0076F9F8 File Offset: 0x0076DBF8
	[NullableContext(2)]
	public override Vector GetStackableLocation()
	{
		BaseCharacterComponent actorComp = this.ActorComp;
		if (actorComp == null || !actorComp.Valid)
		{
			return null;
		}
		this.TempVector.DeepCopy(this.ActorComp.ActorLocationProxy);
		DangoGlobalConfig config = ModelBase<DangoGlobalModel>.Instance.Config;
		Number a = (config != null) ? config.StackInterval : 0;
		Vector tempVector = this.TempVector;
		tempVector.Z += a * 1.2f;
		return this.TempVector;
	}

	// Token: 0x06019989 RID: 104841 RVA: 0x0076FA88 File Offset: 0x0076DC88
	public override void OnPreviousMoveStateChange(IStackableChessAgent agent, bool isMoving, bool previousIsForward, bool isSameDirection)
	{
		if (!isMoving)
		{
			this.JumpHeight = 0f;
			this.JumpDistance = 0f;
			this.ReturnStand();
			return;
		}
		this.JumpHeight = ((DangoPerformComponent)agent).JumpHeight;
		this.JumpDistance = ((DangoPerformComponent)agent).JumpDistance;
		if (isSameDirection ? previousIsForward : (!previousIsForward))
		{
			this.StartJumpPerform(this.JumpHeight, this.JumpDistance);
			return;
		}
		this.StartJumpBackwardPerform(this.JumpHeight, this.JumpDistance);
	}

	// Token: 0x0601998A RID: 104842 RVA: 0x0076FB0C File Offset: 0x0076DD0C
	public override void Move(Vector location, Rotator rotator, bool performIsForward, Action finishCallback)
	{
		BaseCharacterComponent actorComp = this.ActorComp;
		if (actorComp == null || !actorComp.Valid)
		{
			this.MoveEnd();
			return;
		}
		DangoGlobalConfig config = ModelBase<DangoGlobalModel>.Instance.Config;
		if (config == null)
		{
			return;
		}
		this.MoveStartLocation.DeepCopy(this.ActorComp.ActorLocationProxy);
		this.MoveTargetLocation.DeepCopy(location);
		this.MoveTargetLocation.Z += (double)(this.ActorComp.HalfHeight * 1.2f);
		this.MoveTargetRotator.DeepCopy(rotator);
		this.MoveFinishCallback = finishCallback;
		this.MoveState = DangoPerformComponent.EMoveState.Starting;
		this.CurrentMoveTime = 0f;
		double num = this.MoveTargetLocation.Z - this.MoveStartLocation.Z;
		if (num >= 0.0)
		{
			this.SignOffsetRate = (float)MathCommon.Clamp(num / (double)config.MaxRiseHeightEdge, 0.0, 1.0);
		}
		else
		{
			this.SignOffsetRate = (float)MathCommon.Clamp(num / (double)config.MaxFallHeightEdge, -1.0, 0.0);
		}
		this.JumpHeight = (float)num;
		this.JumpDistance = (float)Vector.Distance(this.MoveTargetLocation, this.MoveStartLocation);
		if (performIsForward)
		{
			this.StartJumpPerform(this.JumpHeight, this.JumpDistance);
			return;
		}
		this.StartJumpBackwardPerform(this.JumpHeight, this.JumpDistance);
	}

	// Token: 0x0601998B RID: 104843 RVA: 0x0076FC70 File Offset: 0x0076DE70
	public override void Teleport(Vector location, Rotator rotator)
	{
		if (this.ActorComp == null)
		{
			return;
		}
		this.TempVector.DeepCopy(location);
		this.TempVector.Z += (double)(this.ActorComp.HalfHeight * 1.2f);
		this.ActorComp.SetActorLocationAndRotation(this.TempVector.ToUeVector(false), rotator.ToUeRotator(), "ChessTeleport", false, null);
	}

	// Token: 0x0601998C RID: 104844 RVA: 0x0076FCE4 File Offset: 0x0076DEE4
	private void MoveEnd()
	{
		this.MoveState = DangoPerformComponent.EMoveState.Idle;
		this.CurrentMoveTime = 0f;
		this.ReturnStand();
		this.JumpHeight = 0f;
		this.JumpDistance = 0f;
		TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
		{
			Action moveFinishCallback = this.MoveFinishCallback;
			if (moveFinishCallback == null)
			{
				return;
			}
			moveFinishCallback();
		}, 100f, null, null, true, 1f);
	}

	// Token: 0x0601998D RID: 104845 RVA: 0x0076FD44 File Offset: 0x0076DF44
	public override bool IsPerformRecursion(int type)
	{
		EDangoPerformType type2;
		if (!Enum.TryParse<EDangoPerformType>(type.ToString(), out type2))
		{
			return false;
		}
		DangoGlobalConfig config = ModelBase<DangoGlobalModel>.Instance.Config;
		if (config == null)
		{
			return false;
		}
		DangoPerformConfig performConfig = config.GetPerformConfig(type2);
		EDangoActionTargetType? edangoActionTargetType = (performConfig != null) ? new EDangoActionTargetType?(performConfig.ActionTargetType) : null;
		EDangoActionTargetType edangoActionTargetType2 = EDangoActionTargetType.自身与堆叠上方团子;
		return edangoActionTargetType.GetValueOrDefault() == edangoActionTargetType2 & edangoActionTargetType != null;
	}

	// Token: 0x0601998E RID: 104846 RVA: 0x0076FDA8 File Offset: 0x0076DFA8
	public override void Perform(int type, [Nullable(2)] Vector pointLocation, Action finishCallback)
	{
		DangoPerformConfig dangoPerformConfig = null;
		EDangoPerformType type2;
		if (Enum.TryParse<EDangoPerformType>(type.ToString(), out type2))
		{
			DangoGlobalConfig config = ModelBase<DangoGlobalModel>.Instance.Config;
			dangoPerformConfig = ((config != null) ? config.GetPerformConfig(type2) : null);
		}
		if (dangoPerformConfig != null)
		{
			BaseCharacterComponent actorComp = this.ActorComp;
			if (actorComp != null && actorComp.Valid)
			{
				Vector actorLocationProxy = this.ActorComp.ActorLocationProxy;
				using (List<DangoPerformEffectConfig>.Enumerator enumerator = dangoPerformConfig.EffectConfigList.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						DangoPerformEffectConfig effectConfig = enumerator.Current;
						Vector location = Vector.Create();
						location.DeepCopy(actorLocationProxy);
						if (effectConfig.PerformLocationType == EDangoPerformLocationType.当前底座位置 && pointLocation != null)
						{
							location.DeepCopy(pointLocation);
						}
						location.AdditionEqual(effectConfig.LocationOffset);
						FName? attachSocket = null;
						if (effectConfig.PerformLocationType == EDangoPerformLocationType.跟随团子骨骼)
						{
							attachSocket = effectConfig.AttachSocket;
						}
						int delayTime = effectConfig.DelayTime;
						if (delayTime <= 0)
						{
							this.SpawnEffect(location, effectConfig.EffectPath, attachSocket);
						}
						else
						{
							TimerSystem.FlowTimeInstance.Delay(delegate(float _)
							{
								this.SpawnEffect(location, effectConfig.EffectPath, attachSocket);
							}, (float)delayTime, null, null, true, 1f);
						}
					}
				}
				this.StartActionPerform(dangoPerformConfig.ActionType);
				TTimerAction <>9__2;
				TimerSystem.FlowTimeInstance.Delay(delegate(float _)
				{
					this.ReturnStand();
					TimerSystemInstance flowTimeInstance = TimerSystem.FlowTimeInstance;
					TTimerAction action;
					if ((action = <>9__2) == null)
					{
						action = (<>9__2 = delegate(float _)
						{
							finishCallback();
						});
					}
					flowTimeInstance.Delay(action, 100f, null, null, true, 1f);
				}, (float)dangoPerformConfig.Duration, null, null, true, 1f);
				return;
			}
		}
		finishCallback();
	}

	// Token: 0x0601998F RID: 104847 RVA: 0x0076FF98 File Offset: 0x0076E198
	public override void OnPreviousPerformStateChange(IStackableChessAgent agent, int type, bool isPerforming)
	{
		if (!isPerforming)
		{
			this.ReturnStand();
			return;
		}
		DangoPerformConfig dangoPerformConfig = null;
		EDangoPerformType type2;
		if (Enum.TryParse<EDangoPerformType>(type.ToString(), out type2))
		{
			DangoGlobalConfig config = ModelBase<DangoGlobalModel>.Instance.Config;
			dangoPerformConfig = ((config != null) ? config.GetPerformConfig(type2) : null);
		}
		if (dangoPerformConfig != null)
		{
			this.StartActionPerform(dangoPerformConfig.RecursionActionType);
		}
	}

	// Token: 0x06019990 RID: 104848 RVA: 0x0076FFE8 File Offset: 0x0076E1E8
	private void StartJumpPerform(float jumpHeight, float jumpDistance)
	{
		UAnimInstance animInstance = this.AnimInstance;
		if (animInstance != null && animInstance.IsValid())
		{
			(this.AnimInstance as ABP_TuanziNPC_C).StartJumpWithParams(jumpHeight, jumpDistance);
		}
	}

	// Token: 0x06019991 RID: 104849 RVA: 0x00770010 File Offset: 0x0076E210
	private void StartJumpBackwardPerform(float jumpHeight, float jumpDistance)
	{
		UAnimInstance animInstance = this.AnimInstance;
		if (animInstance != null && animInstance.IsValid())
		{
			(this.AnimInstance as ABP_TuanziNPC_C).StartJumpBackwardWithParams(jumpHeight, jumpDistance);
		}
	}

	// Token: 0x06019992 RID: 104850 RVA: 0x00770038 File Offset: 0x0076E238
	private void StartActionPerform(EDangoActionPerformType type)
	{
		UAnimInstance animInstance = this.AnimInstance;
		if (animInstance != null && animInstance.IsValid())
		{
			(this.AnimInstance as ABP_TuanziNPC_C).StartActionPerform(type);
		}
	}

	// Token: 0x06019993 RID: 104851 RVA: 0x0077005F File Offset: 0x0076E25F
	private void ReturnStand()
	{
		UAnimInstance animInstance = this.AnimInstance;
		if (animInstance != null && animInstance.IsValid())
		{
			(this.AnimInstance as ABP_TuanziNPC_C).ReturnStand();
		}
	}

	// Token: 0x06019994 RID: 104852 RVA: 0x00770088 File Offset: 0x0076E288
	protected override FName? GetAttachSocketName()
	{
		DangoGlobalConfig config = ModelBase<DangoGlobalModel>.Instance.Config;
		if (config == null)
		{
			return null;
		}
		return config.AttachSocketName;
	}

	// Token: 0x06019995 RID: 104853 RVA: 0x007700B4 File Offset: 0x0076E2B4
	private void SpawnEffect(Vector location, string effectPath, FName? socketName)
	{
		BaseCharacterComponent actorComp = this.ActorComp;
		USkeletalMeshComponent uskeletalMeshComponent = (actorComp != null) ? actorComp.SkeletalMesh : null;
		if (uskeletalMeshComponent == null || !uskeletalMeshComponent.IsValid())
		{
			return;
		}
		EffectSystem instance = Singleton<EffectSystem>.Instance;
		UObject world = GlobalData.World;
		FVectorDouble fvectorDouble = location.ToUeVector(false);
		FVector fvector = Vector.OneVectorDouble;
		FTransformDouble? ftransformDouble = new FTransformDouble?(new FTransformDouble(ref Rotator.ZeroRotator, ref fvectorDouble, ref fvector));
		int id = instance.SpawnEffect(world, ftransformDouble, effectPath, "[DangoPerformComponent.SpawnEffect]", new EffectContext(new int?(base.Entity.Id), null, false), EEffectType.Scene, null, null, null, false, false);
		if (!FNameUtil.IsNothing(socketName))
		{
			Singleton<EffectSystem>.Instance.GetEffectActor(id).K2_AttachToComponent(uskeletalMeshComponent, socketName, EAttachmentRule.SnapToTarget, EAttachmentRule.SnapToTarget, EAttachmentRule.SnapToTarget, false);
		}
	}

	// Token: 0x06019996 RID: 104854 RVA: 0x0077015C File Offset: 0x0076E35C
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		DangoPerformComponent dangoPerformComponent = (DangoPerformComponent)componentTemplate;
		if (base.CanResetComponentProperty("AnimInstance"))
		{
			if (dangoPerformComponent.AnimInstance == null)
			{
				this.AnimInstance = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<UAnimInstance>(this.AnimInstance), "AnimInstance"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("IsBeginJump"))
		{
			this.IsBeginJump = dangoPerformComponent.IsBeginJump;
		}
		if (base.CanResetComponentProperty("IsInterruptJump"))
		{
			this.IsInterruptJump = dangoPerformComponent.IsInterruptJump;
		}
		if (base.CanResetComponentProperty("JumpHeight"))
		{
			this.JumpHeight = dangoPerformComponent.JumpHeight;
		}
		if (base.CanResetComponentProperty("JumpDistance"))
		{
			this.JumpDistance = dangoPerformComponent.JumpDistance;
		}
		if (base.CanResetComponentProperty("MoveState"))
		{
			this.MoveState = dangoPerformComponent.MoveState;
		}
		if (base.CanResetComponentProperty("CurrentMoveTime"))
		{
			this.CurrentMoveTime = dangoPerformComponent.CurrentMoveTime;
		}
		if (base.CanResetComponentProperty("SignOffsetRate"))
		{
			this.SignOffsetRate = dangoPerformComponent.SignOffsetRate;
		}
		if (base.CanResetComponentProperty("MoveFinishCallback"))
		{
			if (dangoPerformComponent.MoveFinishCallback == null)
			{
				this.MoveFinishCallback = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Action>(this.MoveFinishCallback), "MoveFinishCallback"))
			{
				return false;
			}
		}
		return (!base.CanResetComponentProperty("MoveStartLocation") || dangoPerformComponent.MoveStartLocation == null || base.CheckClearObject(EntityComponentSystem.ClearObject<Vector>(this.MoveStartLocation), "MoveStartLocation")) && (!base.CanResetComponentProperty("MoveTargetLocation") || dangoPerformComponent.MoveTargetLocation == null || base.CheckClearObject(EntityComponentSystem.ClearObject<Vector>(this.MoveTargetLocation), "MoveTargetLocation")) && (!base.CanResetComponentProperty("MoveTargetRotator") || dangoPerformComponent.MoveTargetRotator == null || base.CheckClearObject(EntityComponentSystem.ClearObject<Rotator>(this.MoveTargetRotator), "MoveTargetRotator")) && (!base.CanResetComponentProperty("TempVector") || dangoPerformComponent.TempVector == null || base.CheckClearObject(EntityComponentSystem.ClearObject<Vector>(this.TempVector), "TempVector")) && (!base.CanResetComponentProperty("TempRotator") || dangoPerformComponent.TempRotator == null || base.CheckClearObject(EntityComponentSystem.ClearObject<Rotator>(this.TempRotator), "TempRotator"));
	}

	// Token: 0x0400CB97 RID: 52119
	public const int STAND_DELAY_TIME = 100;

	// Token: 0x0400CB98 RID: 52120
	public const float SCALE_SIZE = 1.2f;

	// Token: 0x0400CB99 RID: 52121
	[Nullable(2)]
	private UAnimInstance AnimInstance;

	// Token: 0x0400CB9A RID: 52122
	public bool IsBeginJump;

	// Token: 0x0400CB9B RID: 52123
	public bool IsInterruptJump;

	// Token: 0x0400CB9C RID: 52124
	public float JumpHeight;

	// Token: 0x0400CB9D RID: 52125
	public float JumpDistance;

	// Token: 0x0400CB9E RID: 52126
	private DangoPerformComponent.EMoveState MoveState;

	// Token: 0x0400CB9F RID: 52127
	private float CurrentMoveTime;

	// Token: 0x0400CBA0 RID: 52128
	private float SignOffsetRate;

	// Token: 0x0400CBA1 RID: 52129
	[Nullable(2)]
	private Action MoveFinishCallback;

	// Token: 0x0400CBA2 RID: 52130
	private readonly Vector MoveStartLocation = Vector.Create();

	// Token: 0x0400CBA3 RID: 52131
	private readonly Vector MoveTargetLocation = Vector.Create();

	// Token: 0x0400CBA4 RID: 52132
	private readonly Rotator MoveTargetRotator = Rotator.Create();

	// Token: 0x0400CBA5 RID: 52133
	private readonly Vector TempVector = Vector.Create();

	// Token: 0x0400CBA6 RID: 52134
	private readonly Rotator TempRotator = Rotator.Create();

	// Token: 0x0200938E RID: 37774
	[NullableContext(0)]
	public enum EMoveState
	{
		// Token: 0x04031175 RID: 201077
		Idle,
		// Token: 0x04031176 RID: 201078
		Starting,
		// Token: 0x04031177 RID: 201079
		Moving,
		// Token: 0x04031178 RID: 201080
		Recovering
	}
}
