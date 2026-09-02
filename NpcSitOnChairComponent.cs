using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Component;
using CSharpScript.Game.LevelGamePlay;
using CSharpScript.Game.NewWorld.Pawn.Component;
using CSharpScript.Game.NewWorld.Pawn.Controllers;
using NpcSitOnChair;
using UnrealEngine;

// Token: 0x02003193 RID: 12691
[NullableContext(1)]
[Nullable(0)]
public class NpcSitOnChairComponent : EntityComponent
{
	// Token: 0x170023C7 RID: 9159
	// (get) Token: 0x0601A513 RID: 107795 RVA: 0x007BFAE1 File Offset: 0x007BDCE1
	// (set) Token: 0x0601A514 RID: 107796 RVA: 0x007BFAE9 File Offset: 0x007BDCE9
	public NpcSitOnChair.ETaskPhase Phase
	{
		get
		{
			return this.PhaseInternal;
		}
		set
		{
			if (this.PhaseInternal == value)
			{
				return;
			}
			this.PhaseInternal = value;
		}
	}

	// Token: 0x170023C8 RID: 9160
	// (get) Token: 0x0601A515 RID: 107797 RVA: 0x007BFAFC File Offset: 0x007BDCFC
	[Nullable(2)]
	public Entity CurrentChairEntity
	{
		[NullableContext(2)]
		get
		{
			if (this.Phase != NpcSitOnChair.ETaskPhase.SitOnChair || !this.IsExecutePlayMontage)
			{
				return null;
			}
			PawnChairController chairController = this.ChairController;
			if (chairController == null)
			{
				return null;
			}
			return chairController.Entity;
		}
	}

	// Token: 0x0601A516 RID: 107798 RVA: 0x007BFB24 File Offset: 0x007BDD24
	protected override bool OnStart()
	{
		this.ActorComp = base.Entity.GetComponent<CharacterActorComponent>();
		this.MoveComp = base.Entity.GetComponent<BaseMoveComponent>();
		this.PerformComp = base.Entity.GetComponent<BasePerformComponent>();
		this.AnimComp = base.Entity.GetComponent<CharacterAnimationComponent>();
		CharacterAnimationComponent animComp = this.AnimComp;
		if (((animComp != null) ? animComp.MainAnimInstance : null) != null && this.IsRoleAnimInstance())
		{
			this.IsRoleNpc = true;
		}
		return true;
	}

	// Token: 0x0601A517 RID: 107799 RVA: 0x007BFB9C File Offset: 0x007BDD9C
	private bool IsRoleAnimInstance()
	{
		CharacterAnimationComponent animComp = this.AnimComp;
		UAnimInstance @object = (animComp != null) ? animComp.MainAnimInstance : null;
		return UKuroStaticLibrary.IsObjectClassByName(@object, Singleton<CharacterNameDefines>.Instance.ABP_BASEROLENPC) || UKuroStaticLibrary.IsObjectClassByName(@object, Singleton<CharacterNameDefines>.Instance.ABP_BASEROLE);
	}

	// Token: 0x0601A518 RID: 107800 RVA: 0x007BFBE0 File Offset: 0x007BDDE0
	protected override void OnActivate()
	{
	}

	// Token: 0x0601A519 RID: 107801 RVA: 0x007BFBE2 File Offset: 0x007BDDE2
	protected override void OnTick(float deltaTime)
	{
		if (this.Params != null && !this.IsAbortRequested && this.Params.InterruptCondition())
		{
			this.AbortGracefully();
			return;
		}
		if (this.IsExecuting)
		{
			this.NpcSitOnChairTick();
		}
	}

	// Token: 0x0601A51A RID: 107802 RVA: 0x007BFC1B File Offset: 0x007BDE1B
	protected override bool OnEnd()
	{
		this.AbortImmediately();
		return true;
	}

	// Token: 0x0601A51B RID: 107803 RVA: 0x007BFC24 File Offset: 0x007BDE24
	public void RequestExit()
	{
		if (this.Params != null)
		{
			this.AbortGracefully();
		}
	}

	// Token: 0x0601A51C RID: 107804 RVA: 0x007BFC34 File Offset: 0x007BDE34
	public void StartNpcSitOnChair(INpcSitOnChairParams @params)
	{
		if (this.ActorComp == null)
		{
			return;
		}
		if (this.Params != null)
		{
			this.AbortImmediately();
		}
		this.FlowId++;
		int flowId = this.FlowId;
		this.IsAbortRequested = false;
		this.Params = @params;
		BaseMoveComponent moveComp = this.MoveComp;
		bool flag;
		if (moveComp == null)
		{
			flag = true;
		}
		else
		{
			UCharacterMovementComponent characterMovement = moveComp.CharacterMovement;
			flag = !((characterMovement != null) ? new bool?(characterMovement.IsValid()) : null).GetValueOrDefault();
		}
		if (flag)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.BehaviorTree;
			ELogAuthor author = ELogAuthor.CWZ;
			string message = "[NpcSitOnChairComponent] MoveComp不合法";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("PbDataId", this.ActorComp.CreatureData.GetPbDataId());
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			this.AbortImmediately();
			return;
		}
		EntityHandle entityByPbDataId = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(this.Params.ChairEntityId);
		object obj;
		if (entityByPbDataId == null)
		{
			obj = null;
		}
		else
		{
			WorldEntity entity = entityByPbDataId.Entity;
			if (entity == null)
			{
				obj = null;
			}
			else
			{
				PawnInteractNewComponent component = entity.GetComponent<PawnInteractNewComponent>();
				obj = ((component != null) ? component.GetSubEntityInteractLogicController() : null);
			}
		}
		this.ChairController = (obj as PawnChairController);
		if (this.ChairController == null || !this.ChairController.IsSceneInteractionLoadCompleted())
		{
			this.AbortImmediately();
			return;
		}
		if (!this.IsRoleNpc && string.IsNullOrEmpty(this.Params.MontagePath))
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.BehaviorTree;
			ELogAuthor author2 = ELogAuthor.CWZ;
			string message2 = "[NpcSitOnChairComponent] 无效的Montage路径";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("PbDataId", this.ActorComp.CreatureData.GetPbDataId());
			instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			this.AbortImmediately();
			return;
		}
		if (!this.TryPossessAndLockChair())
		{
			this.AbortImmediately();
			return;
		}
		this.DelayExecuteAction(delegate
		{
			if (!this.IsCurrentFlow(flowId))
			{
				return;
			}
			this.Phase = NpcSitOnChair.ETaskPhase.Execute;
			this.IsExecuting = true;
		}, 2000, this.LastFinishTime);
	}

	// Token: 0x0601A51D RID: 107805 RVA: 0x007BFDF4 File Offset: 0x007BDFF4
	private void NpcSitOnChairTick()
	{
		switch (this.Phase)
		{
		case NpcSitOnChair.ETaskPhase.Execute:
			this.Phase = NpcSitOnChair.ETaskPhase.MoveNearby;
			return;
		case NpcSitOnChair.ETaskPhase.MoveNearby:
			this.ExecuteMoveNearby();
			return;
		case NpcSitOnChair.ETaskPhase.MoveClose:
			this.ExecuteMoveClose();
			return;
		case NpcSitOnChair.ETaskPhase.TurnTo:
			this.ExecuteTurnTo();
			if (Singleton<GravityUtils>.Instance.GetAngleOffsetFromCurrentToInputAbs(this.ActorComp) < 10f)
			{
				this.MoveComp.CharacterMovement.MovementMode = this.MovementMode;
				this.Phase = NpcSitOnChair.ETaskPhase.SitOnChair;
				return;
			}
			break;
		case NpcSitOnChair.ETaskPhase.SitOnChair:
			this.ExecutePlaySitOnChairAnim();
			return;
		case NpcSitOnChair.ETaskPhase.MoveAway:
			this.ExecuteMoveAway();
			this.TickRoleNpcStandUp();
			return;
		case NpcSitOnChair.ETaskPhase.Finish:
			this.CompleteTask();
			return;
		default:
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.BehaviorTree;
			ELogAuthor author = ELogAuthor.CWZ;
			string message = "[NpcSitOnChairComponent] 阶段切换出错";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("CurPhase", this.Phase);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			break;
		}
		}
	}

	// Token: 0x0601A51E RID: 107806 RVA: 0x007BFED0 File Offset: 0x007BE0D0
	private void NpcSitOnChairEnd()
	{
		this.ReleaseChairPossession();
		this.UnlockChairInteract();
		this.FlowId++;
		this.Phase = NpcSitOnChair.ETaskPhase.None;
		this.MovementMode = EMovementMode.MOVE_None;
		this.IsExecuteMoveNearby = false;
		this.IsExecuteMoveClose = false;
		this.IsExecuteTurnTo = false;
		this.IsExecutePlayMontage = false;
		this.IsExecuteMoveAway = false;
		this.IsAlignedToChair = false;
		this.MoveHandleId = 0;
		this.Params = null;
		this.ChairController = null;
		this.IsExecuting = false;
		this.CloseMoveLocation.Reset();
		this.ClearExitSitTimerHandle();
	}

	// Token: 0x0601A51F RID: 107807 RVA: 0x007BFF5C File Offset: 0x007BE15C
	private bool TryPossessAndLockChair()
	{
		PawnChairController chairController = this.ChairController;
		Entity entity = base.Entity;
		PawnInteractNewComponent pawnInteractNewComponent;
		if (chairController == null)
		{
			pawnInteractNewComponent = null;
		}
		else
		{
			Entity entity2 = chairController.Entity;
			pawnInteractNewComponent = ((entity2 != null) ? entity2.GetComponent<PawnInteractNewComponent>() : null);
		}
		PawnInteractNewComponent pawnInteractNewComponent2 = pawnInteractNewComponent;
		if (chairController == null || entity == null || pawnInteractNewComponent2 == null || this.IsChairPossessed || this.IsChairInteractLocked || chairController.IsPossessed() || !pawnInteractNewComponent2.CanInteraction || pawnInteractNewComponent2.GetIsExecutingInteract())
		{
			return false;
		}
		if (!chairController.Possess(entity, false))
		{
			return false;
		}
		this.IsChairPossessed = true;
		this.LastChairClientCanInteraction = pawnInteractNewComponent2.GetClientCanInteraction();
		this.IsChairInteractLocked = true;
		pawnInteractNewComponent2.SetInteractionState(false, "NpcSitOnChairComponent.TryPossessAndLockChair");
		return true;
	}

	// Token: 0x0601A520 RID: 107808 RVA: 0x007BFFF8 File Offset: 0x007BE1F8
	private void ReleaseChairPossession()
	{
		if (!this.IsChairPossessed)
		{
			return;
		}
		PawnChairController chairController = this.ChairController;
		Entity entity = base.Entity;
		if (chairController != null && entity != null && chairController.IsPossessedBy(entity))
		{
			chairController.UnPossess(entity);
		}
		this.IsChairPossessed = false;
	}

	// Token: 0x0601A521 RID: 107809 RVA: 0x007C003C File Offset: 0x007BE23C
	private void UnlockChairInteract()
	{
		if (!this.IsChairInteractLocked)
		{
			return;
		}
		PawnChairController chairController = this.ChairController;
		PawnInteractNewComponent pawnInteractNewComponent;
		if (chairController == null)
		{
			pawnInteractNewComponent = null;
		}
		else
		{
			Entity entity = chairController.Entity;
			pawnInteractNewComponent = ((entity != null) ? entity.GetComponent<PawnInteractNewComponent>() : null);
		}
		PawnInteractNewComponent pawnInteractNewComponent2 = pawnInteractNewComponent;
		if (pawnInteractNewComponent2 != null)
		{
			pawnInteractNewComponent2.SetInteractionState(this.LastChairClientCanInteraction, "NpcSitOnChairComponent.UnlockChairInteract");
		}
		this.IsChairInteractLocked = false;
		this.LastChairClientCanInteraction = true;
	}

	// Token: 0x0601A522 RID: 107810 RVA: 0x007C0094 File Offset: 0x007BE294
	private void AbortGracefully()
	{
		if (this.IsAbortRequested)
		{
			return;
		}
		NpcSitOnChair.ETaskPhase phase = this.Phase;
		if (phase != NpcSitOnChair.ETaskPhase.SitOnChair)
		{
			if (phase - NpcSitOnChair.ETaskPhase.MoveAway > 1)
			{
				this.AbortImmediately();
				return;
			}
			this.IsAbortRequested = true;
			return;
		}
		else
		{
			if (!this.IsExecutePlayMontage)
			{
				this.AbortImmediately();
				return;
			}
			this.IsAbortRequested = true;
			this.RequestMoveAwayAfterSitDown();
			return;
		}
	}

	// Token: 0x0601A523 RID: 107811 RVA: 0x007C00E8 File Offset: 0x007BE2E8
	public void AbortImmediately()
	{
		if (this.Params == null)
		{
			this.ClearExitSitTimerHandle();
			return;
		}
		Action abort = this.Params.Abort;
		NpcSitOnChair.ETaskPhase phase = this.Phase;
		this.FlowId++;
		CharacterActorComponent actorComp = this.ActorComp;
		if (actorComp != null)
		{
			actorComp.ClearInput(false, true);
		}
		BaseMoveComponent moveComp = this.MoveComp;
		UCharacterMovementComponent ucharacterMovementComponent = (moveComp != null) ? moveComp.CharacterMovement : null;
		if (this.MovementMode != EMovementMode.MOVE_None && ucharacterMovementComponent != null && ucharacterMovementComponent.IsValid())
		{
			ucharacterMovementComponent.MovementMode = this.MovementMode;
		}
		bool flag = phase == NpcSitOnChair.ETaskPhase.SitOnChair || phase == NpcSitOnChair.ETaskPhase.MoveAway;
		if (flag && this.IsExecutePlayMontage)
		{
			this.PlayStandUpAnim();
		}
		if ((phase == NpcSitOnChair.ETaskPhase.MoveClose || phase == NpcSitOnChair.ETaskPhase.TurnTo || flag) && !this.ChairNearbyPos.IsNearlyZero(9.999999747378752E-05))
		{
			this.SetActorLocation(this.ChairNearbyPos, "AbortImmediately.立即离开椅子");
		}
		this.OnMoveAwayEnd();
		this.LastFinishTime = Singleton<Time>.Instance.Now;
		this.NpcSitOnChairEnd();
		if (abort == null)
		{
			return;
		}
		abort();
	}

	// Token: 0x0601A524 RID: 107812 RVA: 0x007C01E8 File Offset: 0x007BE3E8
	private void CompleteTask()
	{
		object obj;
		if (!this.IsAbortRequested)
		{
			INpcSitOnChairParams @params = this.Params;
			obj = ((@params != null) ? @params.Finish : null);
		}
		else
		{
			INpcSitOnChairParams params2 = this.Params;
			obj = ((params2 != null) ? params2.Abort : null);
		}
		this.LastFinishTime = Singleton<Time>.Instance.Now;
		this.NpcSitOnChairEnd();
		object obj2 = obj;
		if (obj2 == null)
		{
			return;
		}
		obj2();
	}

	// Token: 0x0601A525 RID: 107813 RVA: 0x007C0244 File Offset: 0x007BE444
	private void ExecuteMoveNearby()
	{
		if (this.IsExecuteMoveNearby)
		{
			return;
		}
		this.IsExecuteMoveNearby = true;
		Vector sitLocation = this.ChairController.GetSitLocation();
		this.ChairController.GetForwardDirection().Multiply(50.0, this.ChairNearbyPos);
		this.ChairNearbyPos.AdditionEqual(sitLocation);
		double distSquared2dForActor = Singleton<GravityUtils>.Instance.GetDistSquared2dForActor(this.ActorComp, this.ChairNearbyPos, this.ActorComp.ActorLocationProxy);
		if (distSquared2dForActor < 2500.0 && this.AnimComp != null)
		{
			this.SkipMoveToChair();
			return;
		}
		MoveCharacterPoint moveCharacterPoint = new MoveCharacterPoint
		{
			Index = 0,
			Position = this.ChairNearbyPos,
			MoveState = new EPatrolMoveState?((distSquared2dForActor > 160000.0) ? EPatrolMoveState.Run : EPatrolMoveState.Walk),
			MoveSpeed = new float?((float)((distSquared2dForActor > 160000.0) ? 400 : 100))
		};
		MoveCharacterConfig config = new MoveCharacterConfig
		{
			Points = new MoveCharacterPoint[]
			{
				moveCharacterPoint
			},
			Navigation = true,
			IsFly = false,
			DebugMode = true,
			Loop = false,
			Distance = new float?((float)5),
			Callback = delegate(ELevelEventState result)
			{
				this.StopCurrentMove();
				if (result == ELevelEventState.Failure)
				{
					this.ChairController.IgnoreCollision();
					INpcSitOnChairParams @params = this.Params;
					bool flag;
					if (@params == null)
					{
						flag = false;
					}
					else
					{
						int[] teleportEffect = @params.TeleportEffect;
						int? num = (teleportEffect != null) ? new int?(teleportEffect.Length) : null;
						int i = 0;
						flag = (num.GetValueOrDefault() > i & num != null);
					}
					if (flag)
					{
						Entity entity = base.Entity;
						BaseGameplayCueComponent baseGameplayCueComponent = (entity != null) ? entity.GetComponent<BaseGameplayCueComponent>() : null;
						foreach (int num2 in this.Params.TeleportEffect)
						{
							if (baseGameplayCueComponent != null)
							{
								baseGameplayCueComponent.AddCue((long)num2, new GameplayCueParam?(new GameplayCueParam
								{
									Instant = true
								}));
							}
						}
					}
					CharacterActorComponent actorComp = this.ActorComp;
					if (actorComp != null)
					{
						actorComp.SetActorLocation(this.ChairNearbyPos.ToUeVector(false), "[NpcSitOnChairComponent] ExecuteMoveNearby", false);
					}
					Vector sitLocation2 = this.ChairController.GetSitLocation();
					this.CloseMoveLocation.Set(sitLocation2.X, sitLocation2.Y, this.ActorComp.ActorLocationProxy.Z);
					this.ResetMoveStateAtChair();
					this.Phase = NpcSitOnChair.ETaskPhase.TurnTo;
					return;
				}
				this.Phase = NpcSitOnChair.ETaskPhase.MoveClose;
			},
			ReturnTimeoutFailed = new float?((float)1),
			ReturnFalseWhenNavigationFailed = true,
			StrictNavigation = new bool?(true)
		};
		this.MoveHandleId = this.MoveComp.MoveAlongPath(config, "NpcSitOnChairComponent.ExecuteMoveNearby");
	}

	// Token: 0x0601A526 RID: 107814 RVA: 0x007C03C8 File Offset: 0x007BE5C8
	private void ExecuteMoveClose()
	{
		if (this.IsExecuteMoveClose)
		{
			return;
		}
		this.IsExecuteMoveClose = true;
		this.ChairController.IgnoreCollision();
		Vector actorLocationProxy = this.ActorComp.ActorLocationProxy;
		Vector sitLocation = this.ChairController.GetSitLocation();
		this.CloseMoveLocation.Set(sitLocation.X, sitLocation.Y, actorLocationProxy.Z);
		MoveCharacterPoint moveCharacterPoint = new MoveCharacterPoint
		{
			Index = 0,
			Position = this.CloseMoveLocation,
			MoveState = new EPatrolMoveState?(EPatrolMoveState.Walk),
			MoveSpeed = new float?((float)70)
		};
		MoveCharacterConfig config = new MoveCharacterConfig
		{
			Points = new MoveCharacterPoint[]
			{
				moveCharacterPoint
			},
			Navigation = true,
			IsFly = false,
			DebugMode = true,
			Loop = false,
			Distance = new float?((float)5),
			Callback = delegate(ELevelEventState result)
			{
				this.StopCurrentMove();
				if (result == ELevelEventState.Failure)
				{
					this.SetActorLocation(this.CloseMoveLocation, "ExecuteMoveClose.移动靠近椅子保底");
				}
				this.ResetMoveStateAtChair();
				this.Phase = NpcSitOnChair.ETaskPhase.TurnTo;
			},
			ReturnTimeoutFailed = new float?((float)1),
			ReturnFalseWhenNavigationFailed = true,
			StrictNavigation = new bool?(true)
		};
		this.MoveHandleId = this.MoveComp.MoveAlongPath(config, "NpcSitOnChairComponent.ExecuteMoveClose");
	}

	// Token: 0x0601A527 RID: 107815 RVA: 0x007C04F4 File Offset: 0x007BE6F4
	private void ExecuteTurnTo()
	{
		if (this.IsExecuteTurnTo)
		{
			return;
		}
		this.IsExecuteTurnTo = true;
		int num = 200;
		this.ChairController.GetForwardDirection().Multiply((double)num, this.TempVector);
		this.TempVector.AdditionEqual(this.ChairNearbyPos);
		this.MovementMode = this.MoveComp.CharacterMovement.MovementMode;
		this.MoveComp.CharacterMovement.MovementMode = EMovementMode.MOVE_Walking;
		AiControllerLibrary.TurnToTarget(this.ActorComp, this.TempVector, 200f, false, 0f);
	}

	// Token: 0x0601A528 RID: 107816 RVA: 0x007C058F File Offset: 0x007BE78F
	private void ExecutePlaySitOnChairAnim()
	{
		if (!this.IsExecutePlayMontage)
		{
			this.StartSitOnChairTime = Singleton<Time>.Instance.Now;
			this.IsExecutePlayMontage = true;
			this.PlaySitDownAnim();
		}
	}

	// Token: 0x0601A529 RID: 107817 RVA: 0x007C05B8 File Offset: 0x007BE7B8
	private void RequestMoveAwayAfterSitDown()
	{
		int flowId = this.FlowId;
		this.DelayExecuteAction(delegate
		{
			if (!this.IsCurrentPhase(flowId, NpcSitOnChair.ETaskPhase.SitOnChair))
			{
				return;
			}
			this.Phase = NpcSitOnChair.ETaskPhase.MoveAway;
		}, 1500, this.StartSitOnChairTime);
	}

	// Token: 0x0601A52A RID: 107818 RVA: 0x007C05FB File Offset: 0x007BE7FB
	private void ExecuteMoveAway()
	{
		if (this.IsExecuteMoveAway)
		{
			return;
		}
		this.PlayStandUpAnim();
		this.IsExecuteMoveAway = true;
		if (this.IsRoleNpc)
		{
			this.StartStandUpTime = Singleton<Time>.Instance.Now;
			return;
		}
		this.StartMoveAwayPath();
	}

	// Token: 0x0601A52B RID: 107819 RVA: 0x007C0634 File Offset: 0x007BE834
	private void StartMoveAwayPath()
	{
		MoveCharacterPoint moveCharacterPoint = new MoveCharacterPoint
		{
			Index = 0,
			Position = this.ChairNearbyPos,
			MoveState = new EPatrolMoveState?(EPatrolMoveState.Walk),
			MoveSpeed = new float?((float)70)
		};
		MoveCharacterConfig config = new MoveCharacterConfig
		{
			Points = new MoveCharacterPoint[]
			{
				moveCharacterPoint
			},
			Navigation = true,
			IsFly = false,
			DebugMode = true,
			Loop = false,
			Distance = new float?((float)5),
			Callback = delegate(ELevelEventState result)
			{
				if (result == ELevelEventState.Failure)
				{
					this.SetActorLocation(this.ChairNearbyPos, "ExecuteMoveAway.移动离开椅子保底");
				}
				this.OnMoveAwayEnd();
				this.Phase = NpcSitOnChair.ETaskPhase.Finish;
			},
			ReturnTimeoutFailed = new float?((float)2),
			ReturnFalseWhenNavigationFailed = false
		};
		this.MoveHandleId = this.MoveComp.MoveAlongPath(config, "NpcSitOnChairComponent.StartMoveAwayPath");
	}

	// Token: 0x0601A52C RID: 107820 RVA: 0x007C06F8 File Offset: 0x007BE8F8
	private void TickRoleNpcStandUp()
	{
		if (!this.IsRoleNpc || this.StartStandUpTime == 0.0)
		{
			return;
		}
		if (Singleton<Time>.Instance.Now - this.StartStandUpTime >= 2000.0)
		{
			this.StartStandUpTime = 0.0;
			this.StartMoveAwayPath();
		}
	}

	// Token: 0x0601A52D RID: 107821 RVA: 0x007C0750 File Offset: 0x007BE950
	private void OnMoveAwayEnd()
	{
		this.StopCurrentMove();
		PawnChairController chairController = this.ChairController;
		if (chairController != null && this.IsExecuteMoveNearby)
		{
			if (this.IsActorChairCollisionIgnored && chairController.Entity != null)
			{
				this.ResetCollision(chairController.Entity);
			}
			this.IsActorChairCollisionIgnored = false;
			chairController.ResetCollision();
		}
		this.ReleaseChairPossession();
		this.IsExecuteMoveNearby = false;
	}

	// Token: 0x0601A52E RID: 107822 RVA: 0x007C07AC File Offset: 0x007BE9AC
	private void StopCurrentMove()
	{
		if (this.MoveHandleId == 0)
		{
			return;
		}
		int moveHandleId = this.MoveHandleId;
		this.MoveHandleId = 0;
		BaseMoveComponent moveComp = this.MoveComp;
		if (moveComp == null)
		{
			return;
		}
		moveComp.StopMoveByHandleId(moveHandleId, "NpcSitOnChairComponent.StopCurrentMove");
	}

	// Token: 0x0601A52F RID: 107823 RVA: 0x007C07E6 File Offset: 0x007BE9E6
	private void ResetMoveStateAtChair()
	{
		this.MoveComp.Speed = 0f;
		this.MoveComp.SetForceSpeed(Vector.ZeroVectorProxy);
		Entity entity = base.Entity;
		if (entity == null)
		{
			return;
		}
		BaseUnifiedStateComponent component = entity.GetComponent<BaseUnifiedStateComponent>();
		if (component == null)
		{
			return;
		}
		component.SetMoveState(ECharMoveState.Stand);
	}

	// Token: 0x0601A530 RID: 107824 RVA: 0x007C0824 File Offset: 0x007BEA24
	private void SkipMoveToChair()
	{
		this.ChairController.IgnoreCollision();
		Vector sitLocation = this.ChairController.GetSitLocation();
		this.CloseMoveLocation.Set(sitLocation.X, sitLocation.Y, this.ActorComp.ActorLocationProxy.Z);
		this.ResetMoveStateAtChair();
		this.ChairController.GetForwardDirection().Multiply(200.0, this.TempVector);
		this.TempVector.AdditionEqual(this.ChairNearbyPos);
		this.TempVector.Subtraction(this.ActorComp.ActorLocationProxy, this.TempVector2);
		this.ActorComp.SetInputFacing(this.TempVector2, true);
		bool flag = (double)Singleton<GravityUtils>.Instance.GetAngleOffsetFromCurrentToInputAbs(this.ActorComp) < 10.0;
		if (flag)
		{
			this.ActorComp.SetActorLocationAndRotation(this.CloseMoveLocation.ToUeVector(false), this.ActorComp.InputRotatorProxy.ToUeRotator(), "NpcSitOnChairComponent.SkipMoveToChair", false, null);
		}
		else
		{
			this.AnimComp.SetLocationAndRotatorWithModelBuffer(this.CloseMoveLocation.ToUeVector(false), this.ActorComp.ActorRotationProxy.ToUeRotator(), 200f, "NpcSitOnChairComponent.SkipMoveToChair", ESetRotationPriority.Anim, true);
		}
		this.IsAlignedToChair = flag;
		this.Phase = (flag ? NpcSitOnChair.ETaskPhase.SitOnChair : NpcSitOnChair.ETaskPhase.TurnTo);
	}

	// Token: 0x0601A531 RID: 107825 RVA: 0x007C097B File Offset: 0x007BEB7B
	private bool IsCurrentFlow(int flowId)
	{
		return this.FlowId == flowId && this.Params != null;
	}

	// Token: 0x0601A532 RID: 107826 RVA: 0x007C0991 File Offset: 0x007BEB91
	private bool IsCurrentPhase(int flowId, NpcSitOnChair.ETaskPhase phase)
	{
		return this.IsCurrentFlow(flowId) && this.IsExecuting && this.Phase == phase;
	}

	// Token: 0x0601A533 RID: 107827 RVA: 0x007C09B0 File Offset: 0x007BEBB0
	private void SetActorLocation(Vector target, string context)
	{
		FTransformDouble meshTransform = base.Entity.GetComponent<CharacterAnimationComponent>().GetMeshTransform();
		CharacterActorComponent actorComp = this.ActorComp;
		if (actorComp != null)
		{
			actorComp.SetActorLocation(target.ToUeVector(false), "[NpcSitOnChairComponent]" + context, false);
		}
		CharacterAnimationComponent component = base.Entity.GetComponent<CharacterAnimationComponent>();
		if (component == null)
		{
			return;
		}
		component.SetModelBuffer(meshTransform, 200f);
	}

	// Token: 0x0601A534 RID: 107828 RVA: 0x007C0A10 File Offset: 0x007BEC10
	private void DelayExecuteAction(Action action, int time, double lastTime)
	{
		this.ClearExitSitTimerHandle();
		double num = (double)time - (Singleton<Time>.Instance.Now - lastTime);
		if (num <= 20.0)
		{
			action();
			return;
		}
		this.ExitSitTimerHandle = TimerSystem.Instance.Delay(delegate(float _)
		{
			Action action2 = action;
			if (action2 != null)
			{
				action2();
			}
			this.ExitSitTimerHandle = null;
		}, (float)((int)num), null, null, true, 1f);
	}

	// Token: 0x0601A535 RID: 107829 RVA: 0x007C0A86 File Offset: 0x007BEC86
	private void ClearExitSitTimerHandle()
	{
		if (this.ExitSitTimerHandle != null && TimerSystem.Instance.Has(this.ExitSitTimerHandle))
		{
			TimerSystem.Instance.Remove(this.ExitSitTimerHandle);
		}
		this.ExitSitTimerHandle = null;
	}

	// Token: 0x0601A536 RID: 107830 RVA: 0x007C0ABA File Offset: 0x007BECBA
	private void PlaySitDownAnim()
	{
		if (this.IsRoleNpc)
		{
			this.RoleNpcSitOnChair();
			return;
		}
		this.NormalNpcSitOnChair();
	}

	// Token: 0x0601A537 RID: 107831 RVA: 0x007C0AD1 File Offset: 0x007BECD1
	private void PlayStandUpAnim()
	{
		if (this.IsRoleNpc)
		{
			this.RoleNpcStandUp();
			return;
		}
		this.NormalNpcStopMontage();
	}

	// Token: 0x0601A538 RID: 107832 RVA: 0x007C0AE8 File Offset: 0x007BECE8
	private void NormalNpcSitOnChair()
	{
		if (string.IsNullOrEmpty(this.Params.MontagePath))
		{
			Singleton<Log>.Instance.Error(ELogModule.BehaviorTree, ELogAuthor.CWZ, "[NpcSitOnChairComponent] 没有MontagePath", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		if (!this.IsAlignedToChair)
		{
			CharacterAnimationComponent animComp = this.AnimComp;
			if (animComp != null)
			{
				animComp.SetLocationAndRotatorWithModelBuffer(this.CloseMoveLocation.ToUeVector(false), this.ActorComp.ActorRotationProxy.ToUeRotator(), 200f, "NpcSitOnChairComp.NormalNpcSitOnChair", ESetRotationPriority.Anim, true);
			}
		}
		int flowId = this.FlowId;
		this.PlayingMontage = this.PerformComp.VolatileMontagePlayByLoad(EPerformMode.Ecology, this.Params.MontagePath, null, null, delegate(UAnimMontage montage, bool _)
		{
			if (!this.IsCurrentPhase(flowId, NpcSitOnChair.ETaskPhase.SitOnChair))
			{
				return;
			}
			if (montage != null)
			{
				this.Phase = NpcSitOnChair.ETaskPhase.MoveAway;
				return;
			}
			this.AbortImmediately();
		}, new float?((float)-1), new float?((float)-1), new bool?(false), new bool?(false), new bool?(false));
	}

	// Token: 0x0601A539 RID: 107833 RVA: 0x007C0BC9 File Offset: 0x007BEDC9
	private void NormalNpcStopMontage()
	{
		if (this.PlayingMontage != -1)
		{
			BasePerformComponent performComp = this.PerformComp;
			if (performComp != null)
			{
				performComp.VolatileMontageStopByLoad(EPerformMode.Ecology, this.PlayingMontage, EStopMethod.BlendOut);
			}
			this.PlayingMontage = -1;
		}
	}

	// Token: 0x0601A53A RID: 107834 RVA: 0x007C0BF4 File Offset: 0x007BEDF4
	private void RoleNpcSitOnChair()
	{
		CharacterAnimationComponent animComp = this.AnimComp;
		UAnimInstance uanimInstance = (animComp != null) ? animComp.MainAnimInstance : null;
		if (this.IsRoleAnimInstance())
		{
			UKuroAnimInstanceChar ukuroAnimInstanceChar = uanimInstance as UKuroAnimInstanceChar;
			if (((ukuroAnimInstanceChar != null) ? ukuroAnimInstanceChar.LogicParams : null) != null)
			{
				this.IgnoreCollision(this.ChairController.Entity);
				this.IsActorChairCollisionIgnored = true;
				ukuroAnimInstanceChar.LogicParams.SitDownDirect = this.IsChairCanInteract(this.ChairController.Entity) - EChairInteractDirection.Forward;
				ukuroAnimInstanceChar.LogicParams.SitDownType = 1;
				ukuroAnimInstanceChar.LogicParams.bSitDown = true;
				return;
			}
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.BehaviorTree;
		ELogAuthor author = ELogAuthor.CWZ;
		string message = "[NpcSitOnChairComponent] RoleNpcSitOnChair执行异常";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("instance", uanimInstance != null);
		instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
	}

	// Token: 0x0601A53B RID: 107835 RVA: 0x007C0CB0 File Offset: 0x007BEEB0
	private void RoleNpcStandUp()
	{
		CharacterAnimationComponent animComp = this.AnimComp;
		UAnimInstance uanimInstance = (animComp != null) ? animComp.MainAnimInstance : null;
		if (this.IsRoleAnimInstance())
		{
			UKuroAnimInstanceChar ukuroAnimInstanceChar = uanimInstance as UKuroAnimInstanceChar;
			if (((ukuroAnimInstanceChar != null) ? ukuroAnimInstanceChar.LogicParams : null) != null)
			{
				ukuroAnimInstanceChar.LogicParams.StandUpDirect = this.CalculateLeaveSitDownIndex(this.ChairController.Entity);
				ukuroAnimInstanceChar.LogicParams.bSitDown = false;
				return;
			}
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.BehaviorTree;
		ELogAuthor author = ELogAuthor.CWZ;
		string message = "[NpcSitOnChairComponent] RoleNpcStandUp执行异常";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("instance", uanimInstance != null);
		instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
	}

	// Token: 0x0601A53C RID: 107836 RVA: 0x007C0D48 File Offset: 0x007BEF48
	public void DoSitDownAction(Entity chair)
	{
		if (chair == null)
		{
			return;
		}
		this.TempVector.Reset();
		this.MoveComp.SetForceSpeed(this.TempVector);
		SceneItemActorComponent component = chair.GetComponent<SceneItemActorComponent>();
		PawnInteractNewComponent component2 = chair.GetComponent<PawnInteractNewComponent>();
		this.TempVector.DeepCopy(component2.GetInteractPoint());
		this.TempVector.Z += (double)this.ActorComp.HalfHeight;
		this.TempRotator.DeepCopy(component.ActorRotationProxy);
		this.TempRotator.Yaw += 90f;
		this.ActorComp.SetInputRotator(this.TempRotator);
		this.ActorComp.SetActorLocationAndRotation(this.TempVector.ToUeVector(false), this.TempRotator.ToUeRotator(), "角色坐下", false, null);
	}

	// Token: 0x0601A53D RID: 107837 RVA: 0x007C0E20 File Offset: 0x007BF020
	private int CalculateLeaveSitDownIndex(Entity chair)
	{
		if (chair == null)
		{
			return 0;
		}
		this.ActorComp.Actor.KuroSetMovementMode(new SetMovementModeInfo
		{
			Mode = EMovementMode.MOVE_Walking,
			Context = "[NpcSitOnChairComponent.CalculateLeaveSitDownIndex]"
		});
		this.TempVector.DeepCopy(this.ActorComp.InputDirectProxy);
		if (this.TempVector.IsNearlyZero(9.999999747378752E-05))
		{
			return 0;
		}
		this.TempVector.Normalize(9.99999993922529E-09);
		IInteractSectorRange sectorRange = chair.GetComponent<PawnInteractNewComponent>().GetInteractController().SectorRange;
		if (this.TempVector.DotProduct(this.ActorComp.ActorForwardProxy) > 0.8 || sectorRange == null)
		{
			return 0;
		}
		this.TempVector.CrossProduct(this.ActorComp.ActorForwardProxy, this.TempVector2);
		if (this.TempVector2.Z >= 0.0)
		{
			if (sectorRange.Begin < -45f)
			{
				return 1;
			}
			return 0;
		}
		else
		{
			if (sectorRange.End > 45f)
			{
				return 2;
			}
			return 0;
		}
	}

	// Token: 0x0601A53E RID: 107838 RVA: 0x007C0F28 File Offset: 0x007BF128
	private EChairInteractDirection IsChairCanInteract(Entity sceneItem)
	{
		SceneItemActorComponent component = sceneItem.GetComponent<SceneItemActorComponent>();
		if (component == null)
		{
			return EChairInteractDirection.None;
		}
		this.ActorComp.ActorLocationProxy.Subtraction(component.ActorLocationProxy, this.TempVector);
		this.TempVector.Z = 0.0;
		this.TempVector.Normalize(9.99999993922529E-09);
		double num = Math.Acos(this.TempVector.DotProduct(component.ActorRightProxy)) * 57.295780181884766;
		this.TempVector.CrossProduct(component.ActorRightProxy, this.TempVector2);
		if (this.TempVector2.Z < 0.0)
		{
			num *= -1.0;
		}
		if (num >= -50.0 && num <= 50.0)
		{
			return EChairInteractDirection.Forward;
		}
		if (num >= 50.0 && num <= 140.0)
		{
			return EChairInteractDirection.Left;
		}
		if (num >= -140.0 && num <= -50.0)
		{
			return EChairInteractDirection.Right;
		}
		if (num < 0.0)
		{
			num += 360.0;
		}
		if (num >= 140.0 && num <= 220.0)
		{
			return EChairInteractDirection.Backward;
		}
		return EChairInteractDirection.None;
	}

	// Token: 0x0601A53F RID: 107839 RVA: 0x007C1064 File Offset: 0x007BF264
	public void ResetCollision(Entity chair)
	{
		this.ActorComp.Actor.CapsuleComponent.SetCollisionResponseToChannel(ECollisionChannel.ECC_Pawn, ECollisionResponse.ECR_Block);
		if (chair == null)
		{
			return;
		}
		SceneItemActorComponent component = chair.GetComponent<SceneItemActorComponent>();
		if (component != null && component.Entity != null)
		{
			this.IgnoreActorsCollision(component, false);
		}
	}

	// Token: 0x0601A540 RID: 107840 RVA: 0x007C10A8 File Offset: 0x007BF2A8
	private void IgnoreCollision(Entity chair)
	{
		SceneItemActorComponent component = chair.GetComponent<SceneItemActorComponent>();
		if (component != null && component.Entity != null)
		{
			this.IgnoreActorsCollision(component, true);
		}
		this.ActorComp.Actor.CapsuleComponent.SetCollisionResponseToChannel(ECollisionChannel.ECC_Pawn, ECollisionResponse.ECR_Ignore);
	}

	// Token: 0x0601A541 RID: 107841 RVA: 0x007C10E8 File Offset: 0x007BF2E8
	private void IgnoreActorsCollision(SceneItemActorComponent actorComp, bool bCollision)
	{
		CreatureDataComponent component = actorComp.Entity.GetComponent<CreatureDataComponent>();
		int pbDataId = (component != null) ? component.GetPbDataId() : 0;
		int? ownerEntity = ModelBase<CreatureModel>.Instance.GetOwnerEntity(pbDataId);
		SceneItemActorComponent sceneItemActorComponent;
		if (ownerEntity != null)
		{
			EntityHandle entityByPbDataId = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(ownerEntity.Value);
			if (entityByPbDataId != null && entityByPbDataId.Valid)
			{
				sceneItemActorComponent = entityByPbDataId.Entity.GetComponent<SceneItemActorComponent>();
			}
			else
			{
				sceneItemActorComponent = actorComp;
			}
		}
		else
		{
			sceneItemActorComponent = actorComp;
		}
		TArray<AActor> tarray = new TArray<AActor>();
		sceneItemActorComponent.Owner.GetAttachedActors(ref tarray, true);
		int num = tarray.Num();
		for (int i = 0; i < num; i++)
		{
			AActor aactor = tarray.Get(i);
			TArray<AActor> tarray2 = new TArray<AActor>();
			aactor.GetAttachedActors(ref tarray2, true);
			int num2 = tarray2.Num();
			for (int j = 0; j < num2; j++)
			{
				this.ActorComp.Actor.CapsuleComponent.IgnoreActorWhenMoving(tarray2.Get(j), bCollision);
			}
		}
	}

	// Token: 0x0601A542 RID: 107842 RVA: 0x007C11D8 File Offset: 0x007BF3D8
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		NpcSitOnChairComponent npcSitOnChairComponent = (NpcSitOnChairComponent)componentTemplate;
		if (base.CanResetComponentProperty("ChairNearbyPos") && npcSitOnChairComponent.ChairNearbyPos != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Vector>(this.ChairNearbyPos), "ChairNearbyPos"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("TempVector") && npcSitOnChairComponent.TempVector != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Vector>(this.TempVector), "TempVector"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("TempVector2") && npcSitOnChairComponent.TempVector2 != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Vector>(this.TempVector2), "TempVector2"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("TempRotator") && npcSitOnChairComponent.TempRotator != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Rotator>(this.TempRotator), "TempRotator"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("ActorComp"))
		{
			if (npcSitOnChairComponent.ActorComp == null)
			{
				this.ActorComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterActorComponent>(this.ActorComp), "ActorComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("MoveComp"))
		{
			if (npcSitOnChairComponent.MoveComp == null)
			{
				this.MoveComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BaseMoveComponent>(this.MoveComp), "MoveComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("PerformComp"))
		{
			if (npcSitOnChairComponent.PerformComp == null)
			{
				this.PerformComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BasePerformComponent>(this.PerformComp), "PerformComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("AnimComp"))
		{
			if (npcSitOnChairComponent.AnimComp == null)
			{
				this.AnimComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterAnimationComponent>(this.AnimComp), "AnimComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("IsRoleNpc"))
		{
			this.IsRoleNpc = npcSitOnChairComponent.IsRoleNpc;
		}
		if (base.CanResetComponentProperty("PlayingMontage"))
		{
			this.PlayingMontage = npcSitOnChairComponent.PlayingMontage;
		}
		if (base.CanResetComponentProperty("MovementMode"))
		{
			this.MovementMode = npcSitOnChairComponent.MovementMode;
		}
		if (base.CanResetComponentProperty("ChairController"))
		{
			if (npcSitOnChairComponent.ChairController == null)
			{
				this.ChairController = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<PawnChairController>(this.ChairController), "ChairController"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("Params"))
		{
			if (npcSitOnChairComponent.Params == null)
			{
				this.Params = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<INpcSitOnChairParams>(this.Params), "Params"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("CloseMoveLocation") && npcSitOnChairComponent.CloseMoveLocation != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Vector>(this.CloseMoveLocation), "CloseMoveLocation"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("IsExecuting"))
		{
			this.IsExecuting = npcSitOnChairComponent.IsExecuting;
		}
		if (base.CanResetComponentProperty("IsAbortRequested"))
		{
			this.IsAbortRequested = npcSitOnChairComponent.IsAbortRequested;
		}
		if (base.CanResetComponentProperty("FlowId"))
		{
			this.FlowId = npcSitOnChairComponent.FlowId;
		}
		if (base.CanResetComponentProperty("MoveHandleId"))
		{
			this.MoveHandleId = npcSitOnChairComponent.MoveHandleId;
		}
		if (base.CanResetComponentProperty("IsActorChairCollisionIgnored"))
		{
			this.IsActorChairCollisionIgnored = npcSitOnChairComponent.IsActorChairCollisionIgnored;
		}
		if (base.CanResetComponentProperty("IsChairPossessed"))
		{
			this.IsChairPossessed = npcSitOnChairComponent.IsChairPossessed;
		}
		if (base.CanResetComponentProperty("IsChairInteractLocked"))
		{
			this.IsChairInteractLocked = npcSitOnChairComponent.IsChairInteractLocked;
		}
		if (base.CanResetComponentProperty("LastChairClientCanInteraction"))
		{
			this.LastChairClientCanInteraction = npcSitOnChairComponent.LastChairClientCanInteraction;
		}
		if (base.CanResetComponentProperty("IsExecuteMoveNearby"))
		{
			this.IsExecuteMoveNearby = npcSitOnChairComponent.IsExecuteMoveNearby;
		}
		if (base.CanResetComponentProperty("IsExecuteMoveClose"))
		{
			this.IsExecuteMoveClose = npcSitOnChairComponent.IsExecuteMoveClose;
		}
		if (base.CanResetComponentProperty("IsExecuteTurnTo"))
		{
			this.IsExecuteTurnTo = npcSitOnChairComponent.IsExecuteTurnTo;
		}
		if (base.CanResetComponentProperty("IsExecutePlayMontage"))
		{
			this.IsExecutePlayMontage = npcSitOnChairComponent.IsExecutePlayMontage;
		}
		if (base.CanResetComponentProperty("IsExecuteMoveAway"))
		{
			this.IsExecuteMoveAway = npcSitOnChairComponent.IsExecuteMoveAway;
		}
		if (base.CanResetComponentProperty("IsAlignedToChair"))
		{
			this.IsAlignedToChair = npcSitOnChairComponent.IsAlignedToChair;
		}
		if (base.CanResetComponentProperty("PhaseInternal"))
		{
			this.PhaseInternal = npcSitOnChairComponent.PhaseInternal;
		}
		if (base.CanResetComponentProperty("LastFinishTime"))
		{
			this.LastFinishTime = npcSitOnChairComponent.LastFinishTime;
		}
		if (base.CanResetComponentProperty("StartSitOnChairTime"))
		{
			this.StartSitOnChairTime = npcSitOnChairComponent.StartSitOnChairTime;
		}
		if (base.CanResetComponentProperty("StartStandUpTime"))
		{
			this.StartStandUpTime = npcSitOnChairComponent.StartStandUpTime;
		}
		if (base.CanResetComponentProperty("ExitSitTimerHandle"))
		{
			if (npcSitOnChairComponent.ExitSitTimerHandle == null)
			{
				this.ExitSitTimerHandle = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<TimerHandle>(this.ExitSitTimerHandle), "ExitSitTimerHandle"))
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x0400D41C RID: 54300
	private const int TOLERANCE = 10;

	// Token: 0x0400D41D RID: 54301
	private const int TURN_SPEED = 200;

	// Token: 0x0400D41E RID: 54302
	private const int NEARBY_CHAIR_TOLERANCE_SQUARED = 2500;

	// Token: 0x0400D41F RID: 54303
	private const int NEARBY_CHAIR_OFFSET = 50;

	// Token: 0x0400D420 RID: 54304
	private const int MOVE_TO_CHAIR_SPEED = 70;

	// Token: 0x0400D421 RID: 54305
	private const int MOVE_TO_NEARBY_CHAIR_SPEED = 100;

	// Token: 0x0400D422 RID: 54306
	private const int MOVE_TO_NEARBY_CHAIR_RUN_SPEED = 400;

	// Token: 0x0400D423 RID: 54307
	private const int MOVE_TO_CHAIR_DISTANCE_TOLERANCE = 5;

	// Token: 0x0400D424 RID: 54308
	private const int NEARBY_RUN_DISTANCE_SQUARED = 160000;

	// Token: 0x0400D425 RID: 54309
	private const int MODEL_BUFFER_TIME = 200;

	// Token: 0x0400D426 RID: 54310
	private const int SIT_UP_TIME = 2000;

	// Token: 0x0400D427 RID: 54311
	private const int SIT_DOWN_TIME = 1500;

	// Token: 0x0400D428 RID: 54312
	private const int MOVE_TIMEOUT_1 = 1;

	// Token: 0x0400D429 RID: 54313
	private const int MOVE_TIMEOUT_2 = 2;

	// Token: 0x0400D42A RID: 54314
	private const int FOURTY_FIVE = 45;

	// Token: 0x0400D42B RID: 54315
	private const double ZERO_EIGHT = 0.8;

	// Token: 0x0400D42C RID: 54316
	private const int FIVETY = 50;

	// Token: 0x0400D42D RID: 54317
	private const int ONE_HUNDRED_FOURTY = 140;

	// Token: 0x0400D42E RID: 54318
	private const int TWO_HUNDRED_TWENTY = 220;

	// Token: 0x0400D42F RID: 54319
	private const double PI_DEG_DOUBLE = 360.0;

	// Token: 0x0400D430 RID: 54320
	private readonly Vector ChairNearbyPos = Vector.Create();

	// Token: 0x0400D431 RID: 54321
	private readonly Vector TempVector = Vector.Create();

	// Token: 0x0400D432 RID: 54322
	private readonly Vector TempVector2 = Vector.Create();

	// Token: 0x0400D433 RID: 54323
	private readonly Rotator TempRotator = Rotator.Create();

	// Token: 0x0400D434 RID: 54324
	[Nullable(2)]
	private CharacterActorComponent ActorComp;

	// Token: 0x0400D435 RID: 54325
	[Nullable(2)]
	private BaseMoveComponent MoveComp;

	// Token: 0x0400D436 RID: 54326
	[Nullable(2)]
	private BasePerformComponent PerformComp;

	// Token: 0x0400D437 RID: 54327
	[Nullable(2)]
	private CharacterAnimationComponent AnimComp;

	// Token: 0x0400D438 RID: 54328
	private bool IsRoleNpc;

	// Token: 0x0400D439 RID: 54329
	private int PlayingMontage = -1;

	// Token: 0x0400D43A RID: 54330
	private EMovementMode MovementMode;

	// Token: 0x0400D43B RID: 54331
	[Nullable(2)]
	private PawnChairController ChairController;

	// Token: 0x0400D43C RID: 54332
	[Nullable(2)]
	private INpcSitOnChairParams Params;

	// Token: 0x0400D43D RID: 54333
	private readonly Vector CloseMoveLocation = Vector.Create();

	// Token: 0x0400D43E RID: 54334
	private bool IsExecuting;

	// Token: 0x0400D43F RID: 54335
	private bool IsAbortRequested;

	// Token: 0x0400D440 RID: 54336
	private int FlowId;

	// Token: 0x0400D441 RID: 54337
	private int MoveHandleId;

	// Token: 0x0400D442 RID: 54338
	private bool IsActorChairCollisionIgnored;

	// Token: 0x0400D443 RID: 54339
	private bool IsChairPossessed;

	// Token: 0x0400D444 RID: 54340
	private bool IsChairInteractLocked;

	// Token: 0x0400D445 RID: 54341
	private bool LastChairClientCanInteraction = true;

	// Token: 0x0400D446 RID: 54342
	private bool IsExecuteMoveNearby;

	// Token: 0x0400D447 RID: 54343
	private bool IsExecuteMoveClose;

	// Token: 0x0400D448 RID: 54344
	private bool IsExecuteTurnTo;

	// Token: 0x0400D449 RID: 54345
	private bool IsExecutePlayMontage;

	// Token: 0x0400D44A RID: 54346
	private bool IsExecuteMoveAway;

	// Token: 0x0400D44B RID: 54347
	private bool IsAlignedToChair;

	// Token: 0x0400D44C RID: 54348
	private NpcSitOnChair.ETaskPhase PhaseInternal;

	// Token: 0x0400D44D RID: 54349
	private double LastFinishTime;

	// Token: 0x0400D44E RID: 54350
	private double StartSitOnChairTime;

	// Token: 0x0400D44F RID: 54351
	private double StartStandUpTime;

	// Token: 0x0400D450 RID: 54352
	[Nullable(2)]
	private TimerHandle ExitSitTimerHandle;
}
