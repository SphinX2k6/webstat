using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using AkiClient.Game.Aki.Character.BaseCharacter;
using AkiClient.Game.Aki.Data.Level.AssistedWalk;
using AkiClient.Game.Aki.Data.Level.AttachMove;
using AkiClient.Game.Aki.Data.Level.KeepFollowing;
using CSharpScript.Core.Common;
using CSharpScript.Game.LevelGamePlay;
using CSharpScript.Game.NewWorld.Character.Common.Component.Move.AssistedWalk;
using CSharpScript.Game.NewWorld.Character.Common.Component.Move.AttachMove;
using CSharpScript.Game.Utils;
using CSharpScript.Typing;
using UnrealEngine.Extension;

// Token: 0x020030DC RID: 12508
[NullableContext(1)]
[Nullable(0)]
public class MoveToLocationController : IStaticVariableResetter
{
	// Token: 0x06019D19 RID: 105753 RVA: 0x0078BDC3 File Offset: 0x00789FC3
	static MoveToLocationController()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(MoveToLocationController.CreateStaticDefaultValue), new Action(MoveToLocationController.ResetStaticDefaultValue));
	}

	// Token: 0x06019D1A RID: 105754 RVA: 0x0078BDE4 File Offset: 0x00789FE4
	public MoveToLocationController(Entity entity)
	{
		this.Entity = entity;
		this.ActorComp = entity.GetComponent<CharacterActorComponent>();
		this.StateComp = entity.GetComponent<BaseUnifiedStateComponent>();
	}

	// Token: 0x170022DB RID: 8923
	// (get) Token: 0x06019D1B RID: 105755 RVA: 0x0078BE3F File Offset: 0x0078A03F
	private BaseMoveCharacter MoveAlongPathLogic
	{
		get
		{
			if (this.MoveAlongPathLogicInternal == null)
			{
				this.MoveAlongPathLogicInternal = new BaseMoveCharacter();
				this.MoveAlongPathLogicInternal.Init(this.ActorComp.Entity);
			}
			return this.MoveAlongPathLogicInternal;
		}
	}

	// Token: 0x170022DC RID: 8924
	// (get) Token: 0x06019D1C RID: 105756 RVA: 0x0078BE70 File Offset: 0x0078A070
	private MoveToLocation MoveToLocationLogic
	{
		get
		{
			if (this.MoveToLocationLogicInternal == null)
			{
				this.MoveToLocationLogicInternal = new MoveToLocation();
				this.MoveToLocationLogicInternal.Init(this.ActorComp.Entity);
			}
			return this.MoveToLocationLogicInternal;
		}
	}

	// Token: 0x170022DD RID: 8925
	// (get) Token: 0x06019D1D RID: 105757 RVA: 0x0078BEA1 File Offset: 0x0078A0A1
	private KeepFollowingMoveLogic KeepFollowingMoveLogic
	{
		get
		{
			if (this.KeepFollowingMoveLogicInternal == null)
			{
				this.KeepFollowingMoveLogicInternal = new KeepFollowingMoveLogic();
				this.KeepFollowingMoveLogicInternal.Init(this.ActorComp.Entity);
			}
			return this.KeepFollowingMoveLogicInternal;
		}
	}

	// Token: 0x06019D1E RID: 105758 RVA: 0x0078BED4 File Offset: 0x0078A0D4
	public void UpdateMove(float deltaSeconds)
	{
		BaseMoveCharacter moveAlongPathLogic = this.MoveAlongPathLogic;
		if (moveAlongPathLogic != null && moveAlongPathLogic.IsRunning)
		{
			BaseMoveCharacter moveAlongPathLogic2 = this.MoveAlongPathLogic;
			if (moveAlongPathLogic2 != null)
			{
				moveAlongPathLogic2.UpdateMove(deltaSeconds);
			}
		}
		else
		{
			MoveToLocation moveToLocationLogic = this.MoveToLocationLogic;
			if (((moveToLocationLogic != null) ? moveToLocationLogic.GetCurrentMoveToLocation() : null) != null)
			{
				MoveToLocation moveToLocationLogic2 = this.MoveToLocationLogic;
				if (moveToLocationLogic2 != null)
				{
					moveToLocationLogic2.UpdateMove(deltaSeconds);
				}
			}
			else if (this.KeepFollowingMoveLogic.IsMoving())
			{
				this.KeepFollowingMoveLogic.UpdateMove(deltaSeconds);
			}
			else
			{
				AttachMoveLogic attachMoveLogicInternal = this.AttachMoveLogicInternal;
				if (attachMoveLogicInternal != null && attachMoveLogicInternal.IsMoving())
				{
					this.AttachMoveLogicInternal.UpdateMove(deltaSeconds);
				}
			}
		}
		this.UpdateAutoSync(deltaSeconds);
	}

	// Token: 0x06019D1F RID: 105759 RVA: 0x0078BF74 File Offset: 0x0078A174
	public bool IsMoving()
	{
		if (!this.KeepFollowingMoveLogic.IsMoving())
		{
			AttachMoveLogic attachMoveLogicInternal = this.AttachMoveLogicInternal;
			if (attachMoveLogicInternal == null || !attachMoveLogicInternal.IsMoving())
			{
				BaseMoveCharacter moveAlongPathLogic = this.MoveAlongPathLogic;
				if (moveAlongPathLogic == null || !moveAlongPathLogic.IsRunning)
				{
					MoveToLocation moveToLocationLogic = this.MoveToLocationLogic;
					return ((moveToLocationLogic != null) ? moveToLocationLogic.GetCurrentMoveToLocation() : null) != null;
				}
			}
		}
		return true;
	}

	// Token: 0x06019D20 RID: 105760 RVA: 0x0078BFD0 File Offset: 0x0078A1D0
	[NullableContext(2)]
	public void StopMoveWithCallback(ELevelEventState result, string context = null)
	{
		BaseMoveCharacter moveAlongPathLogic = this.MoveAlongPathLogic;
		if (moveAlongPathLogic != null && moveAlongPathLogic.IsRunning)
		{
			this.MoveAlongPathLogic.MoveEnd(result);
		}
		MoveToLocation moveToLocationLogic = this.MoveToLocationLogic;
		if (((moveToLocationLogic != null) ? moveToLocationLogic.GetCurrentMoveToLocation() : null) != null)
		{
			this.MoveToLocationLogic.MoveEnd(result);
		}
		if (this.KeepFollowingMoveLogic.IsMoving())
		{
			this.KeepFollowingMoveLogic.MoveEnd(result);
		}
		AttachMoveLogic attachMoveLogicInternal = this.AttachMoveLogicInternal;
		if (attachMoveLogicInternal != null && attachMoveLogicInternal.IsMoving())
		{
			this.AttachMoveLogicInternal.StopMoveWithCallback(result);
		}
		this.ClearCurrentMoveHandle(context);
	}

	// Token: 0x06019D21 RID: 105761 RVA: 0x0078C060 File Offset: 0x0078A260
	[NullableContext(2)]
	public void StopMove(string context = null)
	{
		BaseMoveCharacter moveAlongPathLogic = this.MoveAlongPathLogic;
		if (moveAlongPathLogic != null && moveAlongPathLogic.IsRunning)
		{
			this.MoveAlongPathLogic.StopMove();
		}
		MoveToLocation moveToLocationLogic = this.MoveToLocationLogic;
		if (((moveToLocationLogic != null) ? moveToLocationLogic.GetCurrentMoveToLocation() : null) != null)
		{
			this.MoveToLocationLogic.StopMove(null);
		}
		if (this.KeepFollowingMoveLogic.IsMoving())
		{
			this.KeepFollowingMoveLogic.StopMove();
		}
		AttachMoveLogic attachMoveLogicInternal = this.AttachMoveLogicInternal;
		if (attachMoveLogicInternal != null && attachMoveLogicInternal.IsMoving())
		{
			this.AttachMoveLogicInternal.StopMove();
		}
		this.ClearCurrentMoveHandle(context);
	}

	// Token: 0x06019D22 RID: 105762 RVA: 0x0078C0EC File Offset: 0x0078A2EC
	public void Dispose()
	{
		BaseMoveCharacter moveAlongPathLogicInternal = this.MoveAlongPathLogicInternal;
		if (moveAlongPathLogicInternal != null)
		{
			moveAlongPathLogicInternal.Dispose();
		}
		MoveToLocation moveToLocationLogicInternal = this.MoveToLocationLogicInternal;
		if (moveToLocationLogicInternal != null)
		{
			moveToLocationLogicInternal.Dispose();
		}
		KeepFollowingMoveLogic keepFollowingMoveLogicInternal = this.KeepFollowingMoveLogicInternal;
		if (keepFollowingMoveLogicInternal != null)
		{
			keepFollowingMoveLogicInternal.Dispose();
		}
		AttachMoveLogic attachMoveLogicInternal = this.AttachMoveLogicInternal;
		if (attachMoveLogicInternal != null)
		{
			attachMoveLogicInternal.Dispose();
		}
		this.DisableAutoSync();
		this.ClearCurrentMoveHandle("Dispose");
	}

	// Token: 0x06019D23 RID: 105763 RVA: 0x0078C150 File Offset: 0x0078A350
	[NullableContext(2)]
	public global::Vector GetCurrentToLocation()
	{
		BaseMoveCharacter moveAlongPathLogic = this.MoveAlongPathLogic;
		if (moveAlongPathLogic != null && moveAlongPathLogic.IsRunning)
		{
			return this.MoveAlongPathLogic.CurrentToLocation;
		}
		MoveToLocation moveToLocationLogic = this.MoveToLocationLogic;
		if (((moveToLocationLogic != null) ? moveToLocationLogic.GetLastMoveToLocation() : null) != null)
		{
			return this.MoveToLocationLogic.GetLastMoveToLocation();
		}
		return null;
	}

	// Token: 0x06019D24 RID: 105764 RVA: 0x0078C19E File Offset: 0x0078A39E
	public void EnableAutoSync(int interval = 5, float ratio = 0.01f)
	{
		this.AutoSyncEnabled = true;
		this.AutoSyncInterval = interval;
		this.AutoSyncRatio = ratio;
		this.AutoSyncTimer = (float)interval;
		this.AutoSyncLastLocationValid = false;
	}

	// Token: 0x06019D25 RID: 105765 RVA: 0x0078C1C4 File Offset: 0x0078A3C4
	public void DisableAutoSync()
	{
		this.AutoSyncEnabled = false;
		this.AutoSyncTimer = 0f;
		this.AutoSyncLastLocationValid = false;
	}

	// Token: 0x06019D26 RID: 105766 RVA: 0x0078C1E0 File Offset: 0x0078A3E0
	private void UpdateAutoSync(float deltaSeconds)
	{
		if (!this.AutoSyncEnabled)
		{
			return;
		}
		if (this.AutoSyncTimer < 0f)
		{
			this.PushMoveInfo();
			this.AutoSyncTimer = (float)this.AutoSyncInterval;
			return;
		}
		global::Vector actorLocationProxy = this.ActorComp.ActorLocationProxy;
		float num = 0f;
		if (this.AutoSyncLastLocationValid && deltaSeconds > 0f)
		{
			MoveToLocationController.CacheVector.DeepCopy(actorLocationProxy);
			MoveToLocationController.CacheVector.SubtractionEqual(this.AutoSyncLastLocation);
			num = (float)(MoveToLocationController.CacheVector.Size() / (double)deltaSeconds);
		}
		this.AutoSyncLastLocation.DeepCopy(actorLocationProxy);
		this.AutoSyncLastLocationValid = true;
		float num2 = Math.Min((float)this.AutoSyncInterval / 0.25f, Math.Max(1f, num * this.AutoSyncRatio));
		this.AutoSyncTimer -= deltaSeconds * num2;
	}

	// Token: 0x06019D27 RID: 105767 RVA: 0x0078C2AD File Offset: 0x0078A4AD
	public void PushMoveInfo()
	{
		int entityTypeByEntity = WorldFunctionLibrary.GetEntityTypeByEntity(this.ActorComp.Entity.Id);
		if (entityTypeByEntity == 1)
		{
			this.PushNpcMoveInfoWithPointPos();
		}
		if (entityTypeByEntity == 2)
		{
			this.PushMonsterMoveInfoWithPointPos();
		}
	}

	// Token: 0x06019D28 RID: 105768 RVA: 0x0078C2D8 File Offset: 0x0078A4D8
	private void PushNpcMoveInfoWithPointPos()
	{
		EntitySimplyMoveInfo entitySimplyMoveInfo = EntitySimplyMoveInfo.Create();
		entitySimplyMoveInfo.EntityId = Singleton<MathUtils>.Instance.NumberToLong(this.ActorComp.CreatureData.GetCreatureDataId());
		entitySimplyMoveInfo.Location = Aki.Protocol.Vector.Create();
		entitySimplyMoveInfo.Location.X = (float)this.ActorComp.ActorLocationProxy.X;
		entitySimplyMoveInfo.Location.Y = (float)this.ActorComp.ActorLocationProxy.Y;
		entitySimplyMoveInfo.Location.Z = (float)this.ActorComp.ActorLocationProxy.Z;
		entitySimplyMoveInfo.Rotation = Aki.Protocol.Rotator.Create();
		entitySimplyMoveInfo.Rotation.Pitch = this.ActorComp.ActorRotationProxy.Pitch;
		entitySimplyMoveInfo.Rotation.Yaw = this.ActorComp.ActorRotationProxy.Yaw;
		entitySimplyMoveInfo.Rotation.Roll = this.ActorComp.ActorRotationProxy.Roll;
		EntitySimplyMoveInfoPackagePush entitySimplyMoveInfoPackagePush = EntitySimplyMoveInfoPackagePush.Create();
		entitySimplyMoveInfoPackagePush.MoveInfos.Add(entitySimplyMoveInfo);
		Singleton<Net>.Instance.Send(EPushMessageId.EntitySimplyMoveInfoPackagePush, entitySimplyMoveInfoPackagePush);
	}

	// Token: 0x06019D29 RID: 105769 RVA: 0x0078C3EC File Offset: 0x0078A5EC
	private void PushMonsterMoveInfoWithPointPos()
	{
		CharacterMovementSyncComponent component = this.ActorComp.Entity.GetComponent<CharacterMovementSyncComponent>();
		MoveReplaySample currentMoveSample = component.GetCurrentMoveSample();
		currentMoveSample.Location = Aki.Protocol.Vector.Create();
		currentMoveSample.Location.X = (float)this.ActorComp.ActorLocationProxy.X;
		currentMoveSample.Location.Y = (float)this.ActorComp.ActorLocationProxy.Y;
		currentMoveSample.Location.Z = (float)this.ActorComp.ActorLocationProxy.Z;
		component.PendingMoveInfos.Add(currentMoveSample);
		MovePackagePush movePackagePush = MovePackagePush.Create();
		movePackagePush.SceneOwnerId = (ModelBase<GameModeModel>.Instance.IsMulti ? ModelBase<OnlineModel>.Instance.OwnerId : ModelBase<CreatureModel>.Instance.GetPlayerId());
		movePackagePush.MovingEntities.Add(component.CollectPendingMoveInfos());
		Singleton<Net>.Instance.Send(EPushMessageId.MovePackagePush, movePackagePush);
		if (Singleton<Info>.Instance.IsBuildDevelopmentOrDebug)
		{
			string data = Json.Encode(new Dictionary<string, object>
			{
				{
					"scene_id",
					ModelBase<CreatureModel>.Instance.GetSceneId()
				},
				{
					"instance_id",
					ModelBase<CreatureModel>.Instance.GetInstanceId()
				},
				{
					"msg_id",
					17573
				},
				{
					"immediately",
					true
				},
				{
					"sub_count",
					movePackagePush.MovingEntities.Count
				},
				{
					"is_multi",
					ModelBase<GameModeModel>.Instance.IsMulti
				},
				{
					"ed",
					MoveToLocationController.IS_WITH_EDITOR
				},
				{
					"br",
					Singleton<LogAnalyzer>.Instance.GetBranch()
				}
			}, null);
			ControllerBase<CombatDebugController>.Instance.DataReport("COMBAT_MESSAGE_COUNT", data);
		}
	}

	// Token: 0x06019D2A RID: 105770 RVA: 0x0078C5AA File Offset: 0x0078A7AA
	public void GetFollowingPosition(global::Vector out_, CharacterActorComponent leader)
	{
		KeepFollowingMoveLogic keepFollowingMoveLogic = this.KeepFollowingMoveLogic;
		if (keepFollowingMoveLogic == null)
		{
			return;
		}
		keepFollowingMoveLogic.GetTargetFollowingPosition(out_, leader);
	}

	// Token: 0x06019D2B RID: 105771 RVA: 0x0078C5BF File Offset: 0x0078A7BF
	[NullableContext(2)]
	private int CreateMoveHandle(MoveToLocationController.EMoveHandleKind kind, string context = null)
	{
		this.CheckStopMontage();
		int currentMoveHandleId = this.CurrentMoveHandleId;
		MoveToLocationController.EMoveHandleKind currentMoveKind = this.CurrentMoveKind;
		this.LastMoveHandleId++;
		this.CurrentMoveHandleId = this.LastMoveHandleId;
		this.CurrentMoveKind = kind;
		return this.CurrentMoveHandleId;
	}

	// Token: 0x06019D2C RID: 105772 RVA: 0x0078C5FC File Offset: 0x0078A7FC
	public int GetCurrentMoveHandleId()
	{
		return this.CurrentMoveHandleId;
	}

	// Token: 0x06019D2D RID: 105773 RVA: 0x0078C604 File Offset: 0x0078A804
	[NullableContext(2)]
	public bool StopMoveByHandleId(int handleId, string context = null)
	{
		if (handleId <= 0)
		{
			return false;
		}
		if (this.CurrentMoveHandleId != handleId)
		{
			return false;
		}
		this.StopMove(context);
		return true;
	}

	// Token: 0x06019D2E RID: 105774 RVA: 0x0078C61F File Offset: 0x0078A81F
	[NullableContext(2)]
	private void ClearCurrentMoveHandle(string reason = null)
	{
		if (this.CurrentMoveHandleId == 0)
		{
			return;
		}
		this.CurrentMoveHandleId = 0;
		this.CurrentMoveKind = MoveToLocationController.EMoveHandleKind.None;
	}

	// Token: 0x06019D2F RID: 105775 RVA: 0x0078C638 File Offset: 0x0078A838
	public int StartKeepFollowingWithDataAsset(CharacterActorComponent leader, BP_KeepFollowingConfig_C da, EHandType? handType = null, bool followingOnce = false, [Nullable(2)] Action<ELevelEventState> onFinish = null, [TupleElementNames(new string[]
	{
		"X",
		"Y"
	})] [Nullable(0)] ValueTuple<double, double>? walkOffset = null)
	{
		int result = this.CreateMoveHandle(MoveToLocationController.EMoveHandleKind.KeepFollowing, null);
		this.KeepFollowingMoveLogic.StartKeepFollowingWithDataAsset(leader, da, handType, followingOnce, onFinish, walkOffset);
		return result;
	}

	// Token: 0x06019D30 RID: 105776 RVA: 0x0078C656 File Offset: 0x0078A856
	public int StartKeepFollowingWithDataAssetPath(CharacterActorComponent leader, string daPath, EHandType? handType = null, bool followingOnce = false, [Nullable(2)] Action<ELevelEventState> onFinish = null, [TupleElementNames(new string[]
	{
		"X",
		"Y"
	})] [Nullable(0)] ValueTuple<double, double>? walkOffset = null)
	{
		int result = this.CreateMoveHandle(MoveToLocationController.EMoveHandleKind.KeepFollowing, null);
		this.KeepFollowingMoveLogic.StartKeepFollowingWithDataAssetPath(leader, daPath, handType, followingOnce, onFinish, walkOffset);
		return result;
	}

	// Token: 0x06019D31 RID: 105777 RVA: 0x0078C674 File Offset: 0x0078A874
	public int StartSplineKeepFollowingWithDataAssetPath(CharacterActorComponent leader, string daPath, SplineDistanceParams param, [Nullable(2)] Action<ELevelEventState> onFinish = null)
	{
		int result = this.CreateMoveHandle(MoveToLocationController.EMoveHandleKind.KeepFollowingSpline, null);
		this.KeepFollowingMoveLogic.StartKeepFollowingWithDataAssetPath(leader, daPath, null, false, onFinish, null);
		this.KeepFollowingMoveLogic.SetSplineDistanceParam(param);
		return result;
	}

	// Token: 0x06019D32 RID: 105778 RVA: 0x0078C6B7 File Offset: 0x0078A8B7
	public void StopKeepHoldingHands()
	{
		this.KeepFollowingMoveLogic.StopMove();
		if (this.CurrentMoveKind == MoveToLocationController.EMoveHandleKind.KeepFollowing || this.CurrentMoveKind == MoveToLocationController.EMoveHandleKind.KeepFollowingSpline)
		{
			this.ClearCurrentMoveHandle("StopKeepHoldingHands");
		}
	}

	// Token: 0x06019D33 RID: 105779 RVA: 0x0078C6E1 File Offset: 0x0078A8E1
	public bool IsAttachMoving()
	{
		AttachMoveLogic attachMoveLogicInternal = this.AttachMoveLogicInternal;
		return attachMoveLogicInternal != null && attachMoveLogicInternal.IsMoving();
	}

	// Token: 0x06019D34 RID: 105780 RVA: 0x0078C6F4 File Offset: 0x0078A8F4
	public int StartAttachMoveWithData(CharacterActorComponent leader, BP_AttachMoveConfig_C data, [Nullable(2)] Action endCallback = null)
	{
		int result = this.CreateMoveHandle(MoveToLocationController.EMoveHandleKind.AttachMove, null);
		AttachMoveLogic attachMoveLogicInternal = this.AttachMoveLogicInternal;
		if (attachMoveLogicInternal != null && attachMoveLogicInternal.IsMoving())
		{
			this.AttachMoveLogicInternal.StopMove();
		}
		this.AttachMoveLogicInternal = new AttachMoveLogic();
		this.AttachMoveLogicInternal.StartHelpedAttachMoveWithData(this.ActorComp.Entity, leader, data, endCallback);
		return result;
	}

	// Token: 0x06019D35 RID: 105781 RVA: 0x0078C74C File Offset: 0x0078A94C
	public void StopAttachMove()
	{
		AttachMoveLogic attachMoveLogicInternal = this.AttachMoveLogicInternal;
		if (attachMoveLogicInternal != null)
		{
			attachMoveLogicInternal.StopMove();
		}
		this.AttachMoveLogicInternal = null;
		if (this.CurrentMoveKind == MoveToLocationController.EMoveHandleKind.AttachMove)
		{
			this.ClearCurrentMoveHandle("StopAttachMove");
		}
	}

	// Token: 0x06019D36 RID: 105782 RVA: 0x0078C77A File Offset: 0x0078A97A
	public void StartAssistedWalk()
	{
		AttachMoveLogic attachMoveLogicInternal = this.AttachMoveLogicInternal;
		if (attachMoveLogicInternal == null)
		{
			return;
		}
		attachMoveLogicInternal.StartAssistedWalk();
	}

	// Token: 0x06019D37 RID: 105783 RVA: 0x0078C78C File Offset: 0x0078A98C
	public void EnterAssistedWalkIdle()
	{
		AttachMoveLogic attachMoveLogicInternal = this.AttachMoveLogicInternal;
		if (attachMoveLogicInternal == null)
		{
			return;
		}
		attachMoveLogicInternal.EnterAssistedWalkIdle();
	}

	// Token: 0x06019D38 RID: 105784 RVA: 0x0078C79E File Offset: 0x0078A99E
	public void EnterAssistedWalking()
	{
		AttachMoveLogic attachMoveLogicInternal = this.AttachMoveLogicInternal;
		if (attachMoveLogicInternal == null)
		{
			return;
		}
		attachMoveLogicInternal.EnterAssistedWalking();
	}

	// Token: 0x06019D39 RID: 105785 RVA: 0x0078C7B0 File Offset: 0x0078A9B0
	public void LeftAssistedWalking()
	{
		AttachMoveLogic attachMoveLogicInternal = this.AttachMoveLogicInternal;
		if (attachMoveLogicInternal == null)
		{
			return;
		}
		attachMoveLogicInternal.LeftAssistedWalking();
	}

	// Token: 0x06019D3A RID: 105786 RVA: 0x0078C7C4 File Offset: 0x0078A9C4
	public int StartAssistedWalkWithData(CharacterActorComponent leader, BP_AssistedWalkConfig_C data, [Nullable(2)] Action endCallback = null, bool waitAnim = true)
	{
		int result = this.CreateMoveHandle(MoveToLocationController.EMoveHandleKind.AttachMove, null);
		AttachMoveLogic attachMoveLogicInternal = this.AttachMoveLogicInternal;
		if (attachMoveLogicInternal != null && attachMoveLogicInternal.IsMoving())
		{
			this.AttachMoveLogicInternal.StopMove();
		}
		AssistedWalkFollowerLogic assistedWalkFollowerLogic = new AssistedWalkFollowerLogic();
		this.AttachMoveLogicInternal = assistedWalkFollowerLogic;
		assistedWalkFollowerLogic.StartHelpedAssistedWalkWithData(this.ActorComp.Entity, leader, data, endCallback, waitAnim);
		return result;
	}

	// Token: 0x06019D3B RID: 105787 RVA: 0x0078C81C File Offset: 0x0078AA1C
	public int StartLeaderAssistedWalkWithData(BP_AssistedWalkConfig_C data, [Nullable(2)] Action endCallback = null, bool waitAnim = true)
	{
		int result = this.CreateMoveHandle(MoveToLocationController.EMoveHandleKind.AttachMove, null);
		AttachMoveLogic attachMoveLogicInternal = this.AttachMoveLogicInternal;
		if (attachMoveLogicInternal != null && attachMoveLogicInternal.IsMoving())
		{
			this.AttachMoveLogicInternal.StopMove();
		}
		AssistedWalkLeaderLogic assistedWalkLeaderLogic = new AssistedWalkLeaderLogic();
		this.AttachMoveLogicInternal = assistedWalkLeaderLogic;
		assistedWalkLeaderLogic.StartLeaderAssistedWalkWithData(this.ActorComp.Entity, data, endCallback, waitAnim);
		return result;
	}

	// Token: 0x06019D3C RID: 105788 RVA: 0x0078C871 File Offset: 0x0078AA71
	public void StopAssistedWalk()
	{
		this.StopAttachMove();
	}

	// Token: 0x06019D3D RID: 105789 RVA: 0x0078C87C File Offset: 0x0078AA7C
	public unsafe int MoveAlongPath(MoveCharacterConfig config, [Nullable(2)] string context = null)
	{
		if (this.IsMoving())
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Movement;
			ELogAuthor author = ELogAuthor.YJX;
			string message = "[BaseMoveComponent.MoveAlongPath]正在移动中，停止当前移动";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0);
			string item = "PbDataId";
			CharacterActorComponent actorComp = this.ActorComp;
			ptr = new ValueTuple<string, object>(item, (actorComp != null) ? new int?(actorComp.CreatureData.GetPbDataId()) : null);
			ref ValueTuple<string, object> ptr2 = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1);
			string item2 = "Actor";
			CharacterActorComponent actorComp2 = this.ActorComp;
			ptr2 = new ValueTuple<string, object>(item2, (actorComp2 != null) ? actorComp2.Owner : null);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("IsRunning", this.IsMovingAlongPath());
			instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			this.StopMove(context);
		}
		int result = this.CreateMoveHandle(MoveToLocationController.EMoveHandleKind.MoveAlongPath, context);
		this.MoveAlongPathLogic.MoveAlongPath(config);
		return result;
	}

	// Token: 0x06019D3E RID: 105790 RVA: 0x0078C95D File Offset: 0x0078AB5D
	public bool IsMovingAlongPath()
	{
		BaseMoveCharacter moveAlongPathLogic = this.MoveAlongPathLogic;
		return moveAlongPathLogic != null && moveAlongPathLogic.IsRunning;
	}

	// Token: 0x06019D3F RID: 105791 RVA: 0x0078C970 File Offset: 0x0078AB70
	public void StopMoveAlongPath()
	{
		BaseMoveCharacter moveAlongPathLogic = this.MoveAlongPathLogic;
		if (moveAlongPathLogic != null)
		{
			moveAlongPathLogic.StopMove();
		}
		if (this.CurrentMoveKind == MoveToLocationController.EMoveHandleKind.MoveAlongPath)
		{
			this.ClearCurrentMoveHandle("StopMoveAlongPath");
		}
	}

	// Token: 0x06019D40 RID: 105792 RVA: 0x0078C997 File Offset: 0x0078AB97
	public bool IsMovingToLocation()
	{
		MoveToLocation moveToLocationLogic = this.MoveToLocationLogic;
		return ((moveToLocationLogic != null) ? moveToLocationLogic.GetCurrentMoveToLocation() : null) != null;
	}

	// Token: 0x06019D41 RID: 105793 RVA: 0x0078C9AE File Offset: 0x0078ABAE
	[NullableContext(2)]
	public void StopMoveToLocation(string context = null)
	{
		this.MoveToLocationLogic.StopMove(context);
		if (this.CurrentMoveKind == MoveToLocationController.EMoveHandleKind.MoveToLocation || this.CurrentMoveKind == MoveToLocationController.EMoveHandleKind.NavigateMoveToLocation)
		{
			this.ClearCurrentMoveHandle(context);
		}
	}

	// Token: 0x06019D42 RID: 105794 RVA: 0x0078C9D5 File Offset: 0x0078ABD5
	[NullableContext(2)]
	public MoveToLocation GetMoveToLocationLogic()
	{
		MoveToLocation moveToLocationLogic = this.MoveToLocationLogic;
		if (((moveToLocationLogic != null) ? moveToLocationLogic.GetCurrentMoveToLocation() : null) != null)
		{
			return this.MoveToLocationLogic;
		}
		return null;
	}

	// Token: 0x06019D43 RID: 105795 RVA: 0x0078C9F3 File Offset: 0x0078ABF3
	public void PullbackMoveToLocation()
	{
		MoveToLocation moveToLocationLogic = this.MoveToLocationLogic;
		if (((moveToLocationLogic != null) ? moveToLocationLogic.GetCurrentMoveToLocation() : null) != null)
		{
			MoveToLocation moveToLocationLogic2 = this.MoveToLocationLogic;
			if (moveToLocationLogic2 == null)
			{
				return;
			}
			moveToLocationLogic2.ResetPullbackLocation();
		}
	}

	// Token: 0x06019D44 RID: 105796 RVA: 0x0078CA1C File Offset: 0x0078AC1C
	public bool MoveToLocation(IMoveToPointConfig moveConfig, bool stopMove = true, [Nullable(2)] string context = null)
	{
		if (this.MoveToLocationLogic == null)
		{
			return false;
		}
		global::Vector actorLocationProxy = this.ActorComp.ActorLocationProxy;
		double num = moveConfig.Distance ?? ((double)MoveToPointConfig.DefaultDistance);
		if (Singleton<GravityUtils>.Instance.GetDistSquared2dForActor(this.ActorComp, actorLocationProxy, moveConfig.Position) >= num * num)
		{
			if (stopMove)
			{
				this.ClearLastMove();
			}
			bool flag = this.MoveToLocationLogic.SetMoveToLocation(moveConfig);
			if (flag)
			{
				this.CreateMoveHandle(MoveToLocationController.EMoveHandleKind.MoveToLocation, context);
			}
			return flag;
		}
		if (moveConfig.CallbackList == null || moveConfig.CallbackList.Count == 0)
		{
			return true;
		}
		foreach (Action<ELevelEventState> action in moveConfig.CallbackList)
		{
			if (action != null)
			{
				action(ELevelEventState.Success);
			}
		}
		return true;
	}

	// Token: 0x06019D45 RID: 105797 RVA: 0x0078CB00 File Offset: 0x0078AD00
	public bool NavigateMoveToLocation(IMoveToPointConfig moveConfig, bool? navFailReturn = null, bool clear = true, [Nullable(2)] string context = null)
	{
		if (this.MoveToLocationLogic == null)
		{
			return false;
		}
		CharacterActorComponent actorComp = this.ActorComp;
		if (actorComp != null && actorComp.WanderDirectionType == EWanderDirectionType.LR)
		{
			moveConfig.MoveState = new global::ECharMoveState?(global::ECharMoveState.Walk);
		}
		global::Vector actorLocationProxy = this.ActorComp.ActorLocationProxy;
		double num = moveConfig.Distance ?? ((double)MoveToPointConfig.DefaultDistance);
		if (Singleton<GravityUtils>.Instance.GetDistSquared2dForActor(this.ActorComp, actorLocationProxy, moveConfig.Position) < num * num)
		{
			if (moveConfig.CallbackList == null || moveConfig.CallbackList.Count == 0)
			{
				return true;
			}
			foreach (Action<ELevelEventState> action in moveConfig.CallbackList)
			{
				if (action != null)
				{
					action(ELevelEventState.Success);
				}
			}
			return true;
		}
		else
		{
			BaseUnifiedStateComponent stateComp = this.StateComp;
			if (stateComp != null && stateComp.PositionState == global::ECharPositionState.Ground)
			{
				MoveToLocationController.CacheVector.DeepCopy(this.ActorComp.FloorLocation);
			}
			else
			{
				MoveToLocationController.CacheVector.DeepCopy(actorLocationProxy);
			}
			bool navigateMoveToLocationQueue = MoveToLocationController.GetNavigateMoveToLocationQueue(this.ActorComp, MoveToLocationController.CacheVector, moveConfig.Position, this.CacheQueue, num);
			if (navFailReturn.GetValueOrDefault() && !navigateMoveToLocationQueue)
			{
				return false;
			}
			if (clear)
			{
				this.ClearLastMove();
			}
			if (!this.CacheQueue.Empty)
			{
				moveConfig.Position.DeepCopy(this.CacheQueue.Pop());
				moveConfig.NextMovePointConfig = this.CacheQueue;
			}
			bool flag = this.MoveToLocationLogic.SetMoveToLocation(moveConfig);
			if (flag)
			{
				this.CreateMoveHandle(MoveToLocationController.EMoveHandleKind.NavigateMoveToLocation, context);
			}
			return flag;
		}
	}

	// Token: 0x06019D46 RID: 105798 RVA: 0x0078CC9C File Offset: 0x0078AE9C
	private unsafe void ClearLastMove()
	{
		MoveToLocation moveToLocationLogic = this.MoveToLocationLogic;
		if (((moveToLocationLogic != null) ? moveToLocationLogic.GetCurrentMoveToLocation() : null) == null)
		{
			return;
		}
		this.MoveToLocationLogic.StopMove(null);
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.AI;
		ELogAuthor author = ELogAuthor.CWZ;
		string message = "正在移动中，停止移动。";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("PbDataId", this.ActorComp.CreatureData.GetPbDataId());
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("EntityId", this.ActorComp.Entity.Id);
		instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		if (this.CurrentMoveKind == MoveToLocationController.EMoveHandleKind.MoveToLocation || this.CurrentMoveKind == MoveToLocationController.EMoveHandleKind.NavigateMoveToLocation)
		{
			this.ClearCurrentMoveHandle("ClearLastMove");
		}
	}

	// Token: 0x06019D47 RID: 105799 RVA: 0x0078CD64 File Offset: 0x0078AF64
	private string GetMoveKindDesc(MoveToLocationController.EMoveHandleKind kind)
	{
		switch (kind)
		{
		case MoveToLocationController.EMoveHandleKind.None:
			return "无";
		case MoveToLocationController.EMoveHandleKind.MoveAlongPath:
			return "MoveAlongPath";
		case MoveToLocationController.EMoveHandleKind.MoveToLocation:
			return "MoveToLocation";
		case MoveToLocationController.EMoveHandleKind.NavigateMoveToLocation:
			return "NavigateMoveToLocation";
		case MoveToLocationController.EMoveHandleKind.KeepFollowing:
			return "KeepFollowing";
		case MoveToLocationController.EMoveHandleKind.KeepFollowingSpline:
			return "KeepFollowingSpline";
		case MoveToLocationController.EMoveHandleKind.AttachMove:
			return "AttachMove";
		default:
			return string.Empty;
		}
	}

	// Token: 0x06019D48 RID: 105800 RVA: 0x0078CDC4 File Offset: 0x0078AFC4
	private string GetPointsDebugText([Nullable(2)] object points)
	{
		if (points == null)
		{
			return string.Empty;
		}
		IList list = points as IList;
		if (list == null)
		{
			return this.GetPointPositionDebugText(points);
		}
		if (list.Count <= 0)
		{
			return string.Empty;
		}
		return this.GetPointPositionDebugText(list[list.Count - 1]);
	}

	// Token: 0x06019D49 RID: 105801 RVA: 0x0078CE10 File Offset: 0x0078B010
	private string GetPointPositionDebugText([Nullable(2)] object point)
	{
		if (point == null)
		{
			return string.Empty;
		}
		PropertyInfo property = point.GetType().GetProperty("Position");
		global::Vector vector = ((property != null) ? property.GetValue(point) : null) as global::Vector;
		return ((vector != null) ? vector.ToString() : null) ?? string.Empty;
	}

	// Token: 0x06019D4A RID: 105802 RVA: 0x0078CE60 File Offset: 0x0078B060
	private void CheckStopMontage()
	{
		Entity entity = this.Entity;
		CharacterAnimationComponent characterAnimationComponent = (entity != null) ? entity.GetComponent<CharacterAnimationComponent>() : null;
		if (characterAnimationComponent != null)
		{
			characterAnimationComponent.MontageManager.StopMontage(new IStopMontageParam
			{
				Method = new EStopMethod?(EStopMethod.BlendOut),
				BlendOutTime = new float?(0.5f)
			});
		}
	}

	// Token: 0x06019D4B RID: 105803 RVA: 0x0078CEB0 File Offset: 0x0078B0B0
	private static bool GetNavigateMoveToLocationQueue(CharacterActorComponent actor, global::Vector start, global::Vector target, Queue<global::Vector> queue, double minDistance)
	{
		queue.Clear();
		MoveToLocationController.CacheMovePath.Clear();
		global::Vector actorLocationProxy = actor.ActorLocationProxy;
		if (!AiControllerLibrary.NavigationFindPath(actor.Owner.GetWorld(), start.ToUeVector(false), target.ToUeVector(false), MoveToLocationController.CacheMovePath, new bool?(true), new bool?(true)) || MoveToLocationController.CacheMovePath.Count == 0)
		{
			return false;
		}
		if (MoveToLocationController.CacheMovePath.Count > 0)
		{
			if (global::Vector.Dist2D(MoveToLocationController.CacheMovePath[0], actorLocationProxy) > minDistance)
			{
				queue.Push(MoveToLocationController.CacheMovePath[0]);
			}
			for (int i = 1; i < MoveToLocationController.CacheMovePath.Count; i++)
			{
				queue.Push(MoveToLocationController.CacheMovePath[i]);
			}
		}
		return true;
	}

	// Token: 0x06019D4C RID: 105804 RVA: 0x0078CF70 File Offset: 0x0078B170
	public static void CreateStaticDefaultValue()
	{
		MoveToLocationController.IS_WITH_EDITOR = (KuroApplication.IsWithEditor() ? new int?(1) : null);
		MoveToLocationController.CacheMovePath = new List<global::Vector>();
		MoveToLocationController.CacheVector = global::Vector.Create();
	}

	// Token: 0x06019D4D RID: 105805 RVA: 0x0078CFAE File Offset: 0x0078B1AE
	public static void ResetStaticDefaultValue()
	{
		MoveToLocationController.IS_WITH_EDITOR = null;
		MoveToLocationController.DebugDraw = false;
		MoveToLocationController.CacheMovePath = null;
		MoveToLocationController.CacheVector = null;
	}

	// Token: 0x0400CE9D RID: 52893
	private static int? IS_WITH_EDITOR;

	// Token: 0x0400CE9E RID: 52894
	private const int ASYNC_INTERVAL = 5;

	// Token: 0x0400CE9F RID: 52895
	private const float ASYNC_RATIO = 0.01f;

	// Token: 0x0400CEA0 RID: 52896
	private const float ASYNC_MIN_INTERVAL = 0.25f;

	// Token: 0x0400CEA1 RID: 52897
	public static bool DebugDraw;

	// Token: 0x0400CEA2 RID: 52898
	private readonly Queue<global::Vector> CacheQueue = new Queue<global::Vector>(4);

	// Token: 0x0400CEA3 RID: 52899
	[Nullable(2)]
	private MoveToLocation MoveToLocationLogicInternal;

	// Token: 0x0400CEA4 RID: 52900
	[Nullable(2)]
	private BaseMoveCharacter MoveAlongPathLogicInternal;

	// Token: 0x0400CEA5 RID: 52901
	[Nullable(2)]
	private KeepFollowingMoveLogic KeepFollowingMoveLogicInternal;

	// Token: 0x0400CEA6 RID: 52902
	[Nullable(2)]
	private AttachMoveLogic AttachMoveLogicInternal;

	// Token: 0x0400CEA7 RID: 52903
	[Nullable(2)]
	private readonly Entity Entity;

	// Token: 0x0400CEA8 RID: 52904
	[Nullable(2)]
	private readonly CharacterActorComponent ActorComp;

	// Token: 0x0400CEA9 RID: 52905
	[Nullable(2)]
	private readonly BaseUnifiedStateComponent StateComp;

	// Token: 0x0400CEAA RID: 52906
	private int LastMoveHandleId;

	// Token: 0x0400CEAB RID: 52907
	private int CurrentMoveHandleId;

	// Token: 0x0400CEAC RID: 52908
	private MoveToLocationController.EMoveHandleKind CurrentMoveKind;

	// Token: 0x0400CEAD RID: 52909
	private static global::Vector CacheVector;

	// Token: 0x0400CEAE RID: 52910
	private bool AutoSyncEnabled;

	// Token: 0x0400CEAF RID: 52911
	private int AutoSyncInterval = 5;

	// Token: 0x0400CEB0 RID: 52912
	private float AutoSyncRatio = 0.01f;

	// Token: 0x0400CEB1 RID: 52913
	private float AutoSyncTimer;

	// Token: 0x0400CEB2 RID: 52914
	private readonly global::Vector AutoSyncLastLocation = global::Vector.Create();

	// Token: 0x0400CEB3 RID: 52915
	private bool AutoSyncLastLocationValid;

	// Token: 0x0400CEB4 RID: 52916
	private static List<global::Vector> CacheMovePath;

	// Token: 0x0200939F RID: 37791
	[NullableContext(0)]
	private enum EMoveHandleKind
	{
		// Token: 0x040311A1 RID: 201121
		None,
		// Token: 0x040311A2 RID: 201122
		MoveAlongPath,
		// Token: 0x040311A3 RID: 201123
		MoveToLocation,
		// Token: 0x040311A4 RID: 201124
		NavigateMoveToLocation,
		// Token: 0x040311A5 RID: 201125
		KeepFollowing,
		// Token: 0x040311A6 RID: 201126
		KeepFollowingSpline,
		// Token: 0x040311A7 RID: 201127
		AttachMove
	}
}
