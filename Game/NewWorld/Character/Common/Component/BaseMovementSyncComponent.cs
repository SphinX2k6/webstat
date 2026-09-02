using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Core.Common;
using CSharpScript.Game.Module.CombatMessage;
using CSharpScript.Game.Utils;
using CSharpScript.Typing;
using Google.Protobuf;
using Google.Protobuf.Collections;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.Character.Common.Component
{
	// Token: 0x020048F9 RID: 18681
	[NullableContext(1)]
	[Nullable(0)]
	public class BaseMovementSyncComponent : EntityComponent, IMoveSync
	{
		// Token: 0x06030C62 RID: 199778 RVA: 0x00C0CC17 File Offset: 0x00C0AE17
		protected virtual bool DefaultEnableMovementSync()
		{
			return false;
		}

		// Token: 0x17008324 RID: 33572
		// (get) Token: 0x06030C63 RID: 199779 RVA: 0x00C0CC1A File Offset: 0x00C0AE1A
		// (set) Token: 0x06030C64 RID: 199780 RVA: 0x00C0CC24 File Offset: 0x00C0AE24
		protected bool EnableMovementSync
		{
			get
			{
				return this.EnableMovementSyncInternal;
			}
			set
			{
				if (this.EnableMovementSyncInternal == value)
				{
					return;
				}
				this.EnableMovementSyncInternal = value;
				if (!this.Activated)
				{
					return;
				}
				if (value)
				{
					this.RecordLastData(false);
					this.ClearPendingMoveInfos();
					this.CollectSampleAndSend(false);
					ControllerBase<CombatMessageController>.Instance.RegisterPreTick(this, new Action<float>(this.CustomPreTick));
					ControllerBase<CombatMessageController>.Instance.RegisterAfterTick(this, new Action<float>(this.CustomAfterTick));
					return;
				}
				this.ClearReplaySamples();
				this.ClearPendingMoveInfos();
				ControllerBase<CombatMessageController>.Instance.UnregisterPreTick(this);
				ControllerBase<CombatMessageController>.Instance.UnregisterAfterTick(this);
			}
		}

		// Token: 0x06030C65 RID: 199781 RVA: 0x00C0CCB3 File Offset: 0x00C0AEB3
		protected override bool OnInit()
		{
			this.EnableMovementSync = this.DefaultEnableMovementSync();
			return true;
		}

		// Token: 0x06030C66 RID: 199782 RVA: 0x00C0CCC4 File Offset: 0x00C0AEC4
		protected override bool OnStart()
		{
			this.ActorComp = base.Entity.GetComponent<BaseActorComponent>();
			this.TimeScaleComp = base.Entity.GetComponent<CharacterTimeScaleComponent>();
			this.MoveComp = base.Entity.GetComponent<BaseMoveComponent>();
			this.CreatureDataComp = base.Entity.GetComponent<CreatureDataComponent>();
			if (!ModelBase<CombatMessageModel>.Instance.AddMoveSync(this))
			{
				Singleton<CombatLog>.Instance.Warn(CombatLog.EDebugModule.Move, base.Entity, "重复添加移动同步", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			return true;
		}

		// Token: 0x06030C67 RID: 199783 RVA: 0x00C0CD44 File Offset: 0x00C0AF44
		protected override bool OnEnd()
		{
			if (!ModelBase<CombatMessageModel>.Instance.DeleteMoveSync(this))
			{
				Singleton<CombatLog>.Instance.Warn(CombatLog.EDebugModule.Move, base.Entity, "移除移动同步失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			this.EnableMovementSync = false;
			return true;
		}

		// Token: 0x06030C68 RID: 199784 RVA: 0x00C0CD86 File Offset: 0x00C0AF86
		protected virtual void ApplyInput(int input, global::Rotator rotation)
		{
		}

		// Token: 0x17008325 RID: 33573
		// (get) Token: 0x06030C69 RID: 199785 RVA: 0x00C0CD88 File Offset: 0x00C0AF88
		// (set) Token: 0x06030C6A RID: 199786 RVA: 0x00C0CD90 File Offset: 0x00C0AF90
		public List<MoveReplaySample> PendingMoveInfos { get; set; } = new List<MoveReplaySample>();

		// Token: 0x06030C6B RID: 199787 RVA: 0x00C0CD9C File Offset: 0x00C0AF9C
		protected override void OnActivate()
		{
			if (this.LastReceiveMoveSample != null && Singleton<Time>.Instance.NowSeconds >= this.LastReceiveMoveSample.TimeStamp)
			{
				this.ActorComp.SetActorLocationAndRotation(this.LastReceiveMoveSample.Location.ToUeVector(false), this.LastReceiveMoveSample.Rotation.ToUeRotator(), "角色移动同步.处理出生位置刷新", false, null);
				this.LastLocation.DeepCopy(this.LastReceiveMoveSample.Location);
				this.LastRotation.DeepCopy(this.LastReceiveMoveSample.Rotation);
			}
			else
			{
				global::Vector lastLocation = this.LastLocation;
				FVectorDouble fvectorDouble = this.ActorComp.Owner.D_K2_GetActorLocation();
				lastLocation.DeepCopy(fvectorDouble);
				global::Rotator lastRotation = this.LastRotation;
				FRotator frotator = this.ActorComp.Owner.K2_GetActorRotation();
				lastRotation.DeepCopy(frotator);
			}
			if (this.ActorComp.IsMoveAutonomousProxy)
			{
				this.CollectSampleAndSend(false);
			}
			this.LastMoveAutonomousProxy = this.ActorComp.IsMoveAutonomousProxy;
			if (this.EnableMovementSyncInternal)
			{
				ControllerBase<CombatMessageController>.Instance.RegisterPreTick(this, new Action<float>(this.CustomPreTick));
				ControllerBase<CombatMessageController>.Instance.RegisterAfterTick(this, new Action<float>(this.CustomAfterTick));
			}
			this.Activated = true;
		}

		// Token: 0x06030C6C RID: 199788 RVA: 0x00C0CED4 File Offset: 0x00C0B0D4
		public virtual MoveReplaySample GetCurrentMoveSample()
		{
			MoveReplaySample moveReplaySample = MoveReplaySample.Create();
			moveReplaySample.Location = new Aki.Protocol.Vector
			{
				X = (float)this.ActorComp.ActorLocationProxy.X,
				Y = (float)this.ActorComp.ActorLocationProxy.Y,
				Z = (float)this.ActorComp.ActorLocationProxy.Z
			};
			moveReplaySample.Rotation = new Aki.Protocol.Rotator
			{
				Pitch = this.ActorComp.ActorRotationProxy.Pitch,
				Roll = this.ActorComp.ActorRotationProxy.Roll,
				Yaw = this.ActorComp.ActorRotationProxy.Yaw
			};
			moveReplaySample.ServerTimeStamp = (long)Singleton<Time>.Instance.CombatServerTime;
			moveReplaySample.TimeStamp = (float)Singleton<Time>.Instance.NowSeconds;
			if (base.Entity.GetTickInterval() > 1 && this.LastLogicTickTime > 0.0 && this.NowLogicTickTime > 0.0)
			{
				moveReplaySample.TickInterval = (int)((this.NowLogicTickTime - this.LastLogicTickTime) * 1000.0);
			}
			moveReplaySample.RTT = (int)Singleton<Net>.Instance.RttMs;
			MoveReplaySample moveReplaySample2 = moveReplaySample;
			float timeDilation = base.Entity.TimeDilation;
			CharacterTimeScaleComponent timeScaleComp = this.TimeScaleComp;
			moveReplaySample2.TimeScale = timeDilation * ((timeScaleComp != null) ? timeScaleComp.CurrentTimeScale : 1f);
			this.LastMoveSample = moveReplaySample;
			this.CompressData(moveReplaySample);
			return moveReplaySample;
		}

		// Token: 0x06030C6D RID: 199789 RVA: 0x00C0D03C File Offset: 0x00C0B23C
		protected void CompressData(MoveReplaySample data)
		{
			if (!ModelBase<GameModeModel>.Instance.IsMulti)
			{
				data.LinearVelocity = null;
				data.MovementMode = 0;
				data.InputDirection = 0;
				data.RelativeMoveReplaySample = null;
				data.ControllerPitch = 0f;
				data.TimeScale = 0f;
				data.ServerTimeStamp = 0L;
				data.RTT = 0;
				data.SlideForward = null;
				data.TickInterval = 0;
				return;
			}
			if (Singleton<Info>.Instance.IsBuildDevelopmentOrDebug)
			{
				data.ServerTimeStamp = 0L;
				data.RTT = 0;
			}
		}

		// Token: 0x06030C6E RID: 199790 RVA: 0x00C0D0C0 File Offset: 0x00C0B2C0
		protected virtual void RecordLastData(bool isMove = false)
		{
			this.LastLocation.DeepCopy(this.ActorComp.ActorLocationProxy);
			this.LastRotation.DeepCopy(this.ActorComp.ActorRotationProxy);
			this.LastMoveAutonomousProxy = this.ActorComp.IsMoveAutonomousProxy;
			this.LastMove = isMove;
		}

		// Token: 0x06030C6F RID: 199791 RVA: 0x00C0D111 File Offset: 0x00C0B311
		protected override void OnTick(float delta)
		{
			this.LastLogicTickTime = this.NowLogicTickTime;
			this.NowLogicTickTime = Singleton<Time>.Instance.NowSeconds;
		}

		// Token: 0x06030C70 RID: 199792 RVA: 0x00C0D12F File Offset: 0x00C0B32F
		private void CustomPreTick(float delta)
		{
			this.CustomPreTickInternal(delta);
		}

		// Token: 0x06030C71 RID: 199793 RVA: 0x00C0D138 File Offset: 0x00C0B338
		protected unsafe virtual void CustomPreTickInternal(float delta)
		{
			if (this.ActorComp.IsMoveAutonomousProxy)
			{
				return;
			}
			if (base.Entity.GetComponent<BaseTagComponent>().HasTag(GameplayTagDefine.EGameplayTagId["行为状态.动作状态.受击.被抓取"]))
			{
				return;
			}
			this.IsPending = false;
			this.PendingMoveInfos.Clear();
			this.TickReplaySamples();
			if (this.LastMoveAutonomousProxy)
			{
				double num = global::Vector.Dist(this.LastLocation, this.ActorComp.ActorLocationProxy);
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.MultiplayerCombat;
				ELogAuthor author = ELogAuthor.WCL;
				string message = "ChangeControl";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("control", this.ActorComp.IsMoveAutonomousProxy);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("diffDistance", num);
				instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				this.ReportMoveDataDragDistance((float)num, false);
			}
		}

		// Token: 0x06030C72 RID: 199794 RVA: 0x00C0D224 File Offset: 0x00C0B424
		protected virtual bool GetIsMoving()
		{
			return !this.LastLocation.Equals(this.ActorComp.ActorLocationProxy, 9.999999747378752E-05) || !this.LastRotation.Equals(this.ActorComp.ActorRotationProxy, 0.0001f);
		}

		// Token: 0x06030C73 RID: 199795 RVA: 0x00C0D272 File Offset: 0x00C0B472
		protected virtual bool GetImportantMove(bool moving)
		{
			return !moving && this.LastMove;
		}

		// Token: 0x06030C74 RID: 199796 RVA: 0x00C0D27F File Offset: 0x00C0B47F
		protected virtual bool GetSecondaryImportantMove()
		{
			return false;
		}

		// Token: 0x06030C75 RID: 199797 RVA: 0x00C0D282 File Offset: 0x00C0B482
		private void CustomAfterTick(float delta)
		{
			this.CustomAfterTickInternal(delta);
		}

		// Token: 0x06030C76 RID: 199798 RVA: 0x00C0D28C File Offset: 0x00C0B48C
		protected virtual void CustomAfterTickInternal(float delta)
		{
			if (!this.EnableMovementSync || !this.ActorComp.IsMoveAutonomousProxy)
			{
				this.RecordLastData(false);
				return;
			}
			if (this.LastApplyLogicTickTime > 0.0 && this.LastApplyLogicTickTime == this.NowLogicTickTime)
			{
				return;
			}
			this.LastApplyLogicTickTime = this.NowLogicTickTime;
			this.ControllerPlayerId = ModelBase<CreatureModel>.Instance.GetPlayerId();
			this.ClearReplaySamples();
			bool isMoving = this.GetIsMoving();
			bool importantMove = this.GetImportantMove(isMoving);
			if (!ModelBase<GameModeModel>.Instance.IsMulti)
			{
				this.TryPushMoveSingle(isMoving, this.ActorComp.ActorLocationProxy, this.ActorComp.ActorRotationProxy);
			}
			else
			{
				this.TryPushMoveMulti(isMoving, importantMove, this.ActorComp.ActorLocationProxy);
			}
			this.RecordLastData(isMoving);
		}

		// Token: 0x06030C77 RID: 199799 RVA: 0x00C0D34C File Offset: 0x00C0B54C
		protected void TryPushMoveSingle(bool isMoving, global::Vector location, global::Rotator rotation)
		{
			bool flag = Singleton<Time>.Instance.NowSeconds - this.LastSendTime >= (double)this.SingleModeSendInterval;
			bool flag2 = !this.LastSendLocation.Equals(location, (double)BaseMovementSyncComponent.SingleModeSendLocationTolerance) || !this.LastSendRotation.Equals(rotation, BaseMovementSyncComponent.SingleModeSendRotationTolerance);
			TsBaseCharacter baseCharacter = Global.BaseCharacter;
			int? num = (baseCharacter != null) ? new int?(baseCharacter.EntityId) : null;
			int id = base.Entity.Id;
			bool flag3 = (num.GetValueOrDefault() == id & num != null) && !this.LastSendLocation.Equals(location, (double)BaseMovementSyncComponent.SingleModeSendLocationToleranceMax);
			if (!isMoving && this.LastMove)
			{
				MoveReplaySample currentMoveSample = this.GetCurrentMoveSample();
				this.PendingMoveInfos.Add(currentMoveSample);
				ModelBase<CombatMessageModel>.Instance.NeedPushMove = true;
				return;
			}
			if ((isMoving && flag2) || flag3)
			{
				if (flag || flag3)
				{
					MoveReplaySample currentMoveSample2 = this.GetCurrentMoveSample();
					this.PendingMoveInfos.Add(currentMoveSample2);
					ModelBase<CombatMessageModel>.Instance.NeedPushMove = true;
					return;
				}
				if (this.GetSecondaryImportantMove())
				{
					MoveReplaySample currentMoveSample3 = this.GetCurrentMoveSample();
					this.PendingMoveInfos.Add(currentMoveSample3);
				}
			}
		}

		// Token: 0x06030C78 RID: 199800 RVA: 0x00C0D474 File Offset: 0x00C0B674
		protected unsafe void TryPushMoveMulti(bool isMoving, bool importantMove, global::Vector location)
		{
			if (!this.LastMoveAutonomousProxy)
			{
				double num = global::Vector.Dist(this.LastLocation, location);
				this.ReportMoveDataDragDistance((float)num, true);
				CombatLog instance = Singleton<CombatLog>.Instance;
				CombatLog.EDebugModule flag = CombatLog.EDebugModule.Move;
				Entity entity = base.Entity;
				string message = "移动来源切换自身";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("上个控制者", this.ControllerPlayerId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("当前控制者", ModelBase<CreatureModel>.Instance.GetPlayerId());
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("位移距离", num);
				instance.Info(flag, entity, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			}
			CreatureDataComponent component = base.Entity.GetComponent<CreatureDataComponent>();
			if (ControllerBase<CombatDebugDrawController>.Instance.DebugMonsterMovePath && component.GetEntityType() == EEntityType.Monster)
			{
				UKismetSystemLibrary.D_DrawDebugLine(GlobalData.World, this.LastLocation.ToUeVector(false), location.ToUeVector(false), new FLinearColor(0f, 1f, 0f, 1f), 15f, 0f);
			}
			if (!ModelBase<CombatMessageModel>.Instance.MoveSyncUdpMode)
			{
				if (!this.IsPending)
				{
					if (!isMoving)
					{
						return;
					}
					this.IsPending = true;
					this.PendingTime = Singleton<Time>.Instance.NowSeconds;
					this.PendingMoveInfos.Clear();
				}
				MoveReplaySample currentMoveSample = this.GetCurrentMoveSample();
				new ReplaySample(currentMoveSample, ModelBase<CreatureModel>.Instance.GetPlayerId(), Singleton<Time>.Instance.NowSeconds).TimeStamp = Singleton<Time>.Instance.NowSeconds;
				this.PendingMoveInfos.Add(currentMoveSample);
				if (Singleton<Time>.Instance.NowSeconds >= this.PendingTime + (double)BaseMovementSyncComponent.PendingMoveCacheTime || !isMoving)
				{
					ModelBase<CombatMessageModel>.Instance.NeedPushMove = true;
				}
				return;
			}
			if (importantMove)
			{
				this.CollectSampleAndSend(true);
				return;
			}
			if (isMoving)
			{
				this.CollectSampleAndSendUdp();
			}
		}

		// Token: 0x06030C79 RID: 199801 RVA: 0x00C0D644 File Offset: 0x00C0B844
		protected void UpdateForcePushFlag(MovePackagePush movePkg)
		{
			if (!ModelBase<GameModeModel>.Instance.IsMulti)
			{
				return;
			}
			if (!this.ActorComp || !this.ActorComp.IsAutonomousProxy)
			{
				return;
			}
			foreach (MovingEntityData movingEntityData in movePkg.MovingEntities)
			{
				foreach (MoveReplaySample moveReplaySample in movingEntityData.MoveInfos)
				{
					if (this.PkgLastTimeScale != 1f && moveReplaySample.TimeScale == 1f)
					{
						movingEntityData.ForcePush = true;
						this.PkgLastTimeScale = 1f;
						break;
					}
					this.PkgLastTimeScale = moveReplaySample.TimeScale;
				}
			}
		}

		// Token: 0x06030C7A RID: 199802 RVA: 0x00C0D724 File Offset: 0x00C0B924
		public virtual void CollectSampleAndSend(bool immediately = false)
		{
			MoveReplaySample currentMoveSample = this.GetCurrentMoveSample();
			this.PendingMoveInfos.Add(currentMoveSample);
			if (immediately)
			{
				MovePackagePush movePackagePush = MovePackagePush.Create();
				movePackagePush.SceneOwnerId = (ModelBase<GameModeModel>.Instance.IsMulti ? ModelBase<OnlineModel>.Instance.OwnerId : ModelBase<CreatureModel>.Instance.GetPlayerId());
				MovingEntityData movingEntityData = this.CollectPendingMoveInfos();
				if (movingEntityData != null)
				{
					movePackagePush.MovingEntities.Add(movingEntityData);
					this.UpdateForcePushFlag(movePackagePush);
				}
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
							BaseMovementSyncComponent.IsWithEditor
						},
						{
							"br",
							Singleton<LogAnalyzer>.Instance.GetBranch()
						}
					}, null);
					ControllerBase<CombatDebugController>.Instance.DataReport("COMBAT_MESSAGE_COUNT", data);
				}
				this.LastSendTime = Singleton<Time>.Instance.NowSeconds;
				return;
			}
			ModelBase<CombatMessageModel>.Instance.NeedPushMove = true;
		}

		// Token: 0x06030C7B RID: 199803 RVA: 0x00C0D8A0 File Offset: 0x00C0BAA0
		public void CollectSampleAndSendUdp()
		{
			if (Singleton<Time>.Instance.NowSeconds - this.LastSendTime < (double)ModelBase<CombatMessageModel>.Instance.MoveSyncUdpSendInterval)
			{
				if (ModelBase<CombatMessageModel>.Instance.MoveSyncUdpFullSampling)
				{
					MoveReplaySample currentMoveSample = this.GetCurrentMoveSample();
					this.PendingMoveInfos.Add(currentMoveSample);
				}
				return;
			}
			MoveReplaySample currentMoveSample2 = this.GetCurrentMoveSample();
			this.PendingMoveInfos.Add(currentMoveSample2);
			UDPMovePackagePush udpmovePackagePush = UDPMovePackagePush.Create();
			udpmovePackagePush.SceneOwnerId = (ModelBase<GameModeModel>.Instance.IsMulti ? ModelBase<OnlineModel>.Instance.OwnerId : ModelBase<CreatureModel>.Instance.GetPlayerId());
			udpmovePackagePush.MovingEntities.Add(this.CollectPendingMoveInfos());
			Singleton<Net>.Instance.Send(EPushMessageId.UDPMovePackagePush, udpmovePackagePush);
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
						29722
					},
					{
						"immediately",
						true
					},
					{
						"is_multi",
						ModelBase<GameModeModel>.Instance.IsMulti
					},
					{
						"ed",
						BaseMovementSyncComponent.IsWithEditor
					},
					{
						"br",
						Singleton<LogAnalyzer>.Instance.GetBranch()
					}
				}, null);
				ControllerBase<CombatDebugController>.Instance.DataReport("COMBAT_MESSAGE_COUNT", data);
			}
			this.LastSendTime = Singleton<Time>.Instance.NowSeconds;
		}

		// Token: 0x06030C7C RID: 199804 RVA: 0x00C0DA24 File Offset: 0x00C0BC24
		[NullableContext(2)]
		public unsafe MovingEntityData CollectPendingMoveInfos()
		{
			int i = 0;
			foreach (MoveReplaySample moveReplaySample in this.PendingMoveInfos)
			{
				if (Singleton<Time>.Instance.NowSeconds < (double)(moveReplaySample.TimeStamp + BaseMovementSyncComponent.MaxPendingMoveCacheTime))
				{
					break;
				}
				i++;
			}
			if (this.PendingMoveInfos.Count > 50)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.MultiplayerCombat;
				ELogAuthor author = ELogAuthor.WCL;
				string message = "移动包过多";
				<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("diff", Singleton<Time>.Instance.NowSeconds - (double)this.PendingMoveInfos[0].TimeStamp);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("NowSeconds", Singleton<Time>.Instance.NowSeconds);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("TimeStamp", this.PendingMoveInfos[0].TimeStamp);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("length", this.PendingMoveInfos.Count);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
			}
			if (i > 0)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.MultiplayerCombat;
				ELogAuthor author2 = ELogAuthor.WCL;
				string message2 = "移动包过期";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("diff", Singleton<Time>.Instance.NowSeconds - (double)this.PendingMoveInfos[0].TimeStamp);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("NowSeconds", Singleton<Time>.Instance.NowSeconds);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("TimeStamp", this.PendingMoveInfos[0].TimeStamp);
				instance2.Warn(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 3));
				while (i > 0)
				{
					this.PendingMoveInfos.RemoveAt(0);
					i--;
				}
			}
			if (this.PendingMoveInfos.Count == 0)
			{
				return null;
			}
			MovingEntityData movingEntityData = MovingEntityData.Create();
			movingEntityData.EntityId = this.ActorComp.CreatureData.GetCreatureDataId();
			movingEntityData.Originator = (long)ModelBase<CreatureModel>.Instance.GetPlayerId();
			movingEntityData.MoveInfos.AddRange(this.PendingMoveInfos);
			List<MoveReplaySample> pendingMoveInfos = this.PendingMoveInfos;
			MoveReplaySample moveReplaySample2 = pendingMoveInfos[pendingMoveInfos.Count - 1];
			this.LastSendLocation.X = (double)moveReplaySample2.Location.X;
			this.LastSendLocation.Y = (double)moveReplaySample2.Location.Y;
			this.LastSendLocation.Z = (double)moveReplaySample2.Location.Z;
			this.LastSendRotation.Roll = moveReplaySample2.Rotation.Roll;
			this.LastSendRotation.Pitch = moveReplaySample2.Rotation.Pitch;
			this.LastSendRotation.Yaw = moveReplaySample2.Rotation.Yaw;
			this.IsPending = false;
			this.LastSendTime = Singleton<Time>.Instance.NowSeconds;
			this.PendingMoveInfos = new List<MoveReplaySample>();
			if (Singleton<Info>.Instance.IsBuildDevelopmentOrDebug)
			{
				byte[] array = movingEntityData.ToByteArray();
				CreatureDataComponent creatureDataComp = this.CreatureDataComp;
				int? num = (creatureDataComp != null) ? new int?(creatureDataComp.GetPbDataId()) : null;
				CreatureDataComponent creatureDataComp2 = this.CreatureDataComp;
				EEntityType? eentityType = (creatureDataComp2 != null) ? new EEntityType?(creatureDataComp2.GetEntityType()) : null;
				CreatureDataComponent creatureDataComp3 = this.CreatureDataComp;
				long? num2 = (creatureDataComp3 != null) ? new long?(creatureDataComp3.GetCreatureDataId()) : null;
				if (array.Length != 0)
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
							"creature_id",
							num2
						},
						{
							"pb_data_id",
							num
						},
						{
							"entity_type",
							eentityType
						},
						{
							"msg_id",
							-1
						},
						{
							"length",
							array.Length
						},
						{
							"is_multi",
							ModelBase<GameModeModel>.Instance.IsMulti
						},
						{
							"is_send",
							true
						},
						{
							"ed",
							BaseMovementSyncComponent.IsWithEditor
						},
						{
							"br",
							Singleton<LogAnalyzer>.Instance.GetBranch()
						}
					}, null);
					ControllerBase<CombatDebugController>.Instance.DataReport("COMBAT_MESSAGE_INFO", data);
				}
			}
			return movingEntityData;
		}

		// Token: 0x06030C7D RID: 199805 RVA: 0x00C0DEDC File Offset: 0x00C0C0DC
		public unsafe void ReceiveMoveInfos(RepeatedField<MoveReplaySample> moveInfos, int originator, float timestamp)
		{
			if (moveInfos.Count == 0)
			{
				Singleton<CombatLog>.Instance.Warn(CombatLog.EDebugModule.Move, base.Entity, "收移动包失败，移动包长度为0", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			CombatMessageBuffer messageBufferByEntityId = ModelBase<CombatMessageModel>.Instance.GetMessageBufferByEntityId(base.Entity.Id);
			if (messageBufferByEntityId == null)
			{
				Singleton<CombatLog>.Instance.Warn(CombatLog.EDebugModule.Move, base.Entity, "收移动包失败，缓冲器查询失败", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			double num = (double)timestamp + messageBufferByEntityId.TimelineOffset;
			if (Singleton<Time>.Instance.NowSeconds > num)
			{
				double num2 = Singleton<Time>.Instance.NowSeconds - num;
				CombatLog instance = Singleton<CombatLog>.Instance;
				CombatLog.EDebugModule flag = CombatLog.EDebugModule.Move;
				Entity entity = base.Entity;
				string message = "移动缓冲不足";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("missTime", num2);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("TimeStamp", timestamp);
				instance.Warn(flag, entity, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				this.ReportMoveDataBufferMissTime((float)(num2 * 1000.0));
			}
			if (this.LastReceiveControllerPlayerId != originator)
			{
				CombatLog instance2 = Singleton<CombatLog>.Instance;
				CombatLog.EDebugModule flag2 = CombatLog.EDebugModule.Move;
				Entity entity2 = base.Entity;
				string message2 = "移动协议包切换";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("上个控制者", this.LastReceiveControllerPlayerId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("当前控制者", originator);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("TimeStamp", timestamp);
				instance2.Info(flag2, entity2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 3));
			}
			foreach (MoveReplaySample moveReplaySample in moveInfos)
			{
				if (moveReplaySample.TimeStamp <= 0f)
				{
					Log instance3 = Singleton<Log>.Instance;
					ELogModule module = ELogModule.MultiplayerCombat;
					ELogAuthor author = ELogAuthor.WCL;
					string message3 = "[BaseMovementSyncComponent.ReceiveMoveInfos] TimeStamp不能小于等于0";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("TimeStamp", moveReplaySample.TimeStamp);
					instance3.Error(module, author, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				}
				float num3 = (moveReplaySample.TickInterval > 0) ? ((float)moveReplaySample.TickInterval * 0.001f) : 0f;
				if (num3 > 0f)
				{
					num3 = Singleton<MathUtils>.Instance.Clamp(num3, 0f, this.MaxExtraOffset);
					CombatLog instance4 = Singleton<CombatLog>.Instance;
					CombatLog.EDebugModule flag3 = CombatLog.EDebugModule.Move;
					Entity entity3 = base.Entity;
					string message4 = "额外移动缓冲";
					ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("extraOffset", num3);
					instance4.Info(flag3, entity3, message4, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				}
				ReplaySample sample = new ReplaySample(moveReplaySample, originator, (double)moveReplaySample.TimeStamp + messageBufferByEntityId.TimelineOffset + (double)num3);
				this.AddReplaySample(sample);
			}
			this.LastReceiveControllerPlayerId = originator;
		}

		// Token: 0x06030C7E RID: 199806 RVA: 0x00C0E1A0 File Offset: 0x00C0C3A0
		public bool GetEnableMovementSync()
		{
			return this.EnableMovementSync;
		}

		// Token: 0x06030C7F RID: 199807 RVA: 0x00C0E1A8 File Offset: 0x00C0C3A8
		public unsafe void SetEnableMovementSync(bool enable, string reason = "")
		{
			CombatLog instance = Singleton<CombatLog>.Instance;
			CombatLog.EDebugModule flag = CombatLog.EDebugModule.Move;
			Entity entity = base.Entity;
			string message = "SetEnableMovementSync";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("enable", enable);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("reason", reason);
			instance.Info(flag, entity, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			this.EnableMovementSync = enable;
		}

		// Token: 0x06030C80 RID: 199808 RVA: 0x00C0E218 File Offset: 0x00C0C418
		public void AddReplaySample(ReplaySample sample)
		{
			while (!this.ReplaySampleQueue.Empty && this.ReplaySampleQueue.Rear.TimeStamp > sample.TimeStamp)
			{
				this.ReplaySampleQueue.RemoveRear();
			}
			this.ReplaySampleQueue.AddRear(sample);
			this.LastReceiveMoveSample = sample;
		}

		// Token: 0x06030C81 RID: 199809 RVA: 0x00C0E26B File Offset: 0x00C0C46B
		public void ClearReplaySamples()
		{
			this.ReplaySampleQueue.Clear();
			this.LastApplyMoveSample = null;
		}

		// Token: 0x06030C82 RID: 199810 RVA: 0x00C0E27F File Offset: 0x00C0C47F
		public void ClearPendingMoveInfos()
		{
			this.PendingMoveInfos.Clear();
			this.IsPending = false;
		}

		// Token: 0x06030C83 RID: 199811 RVA: 0x00C0E293 File Offset: 0x00C0C493
		public void CloneMoveSampleInfos(BaseMovementSyncComponent otherMoveSyncComp)
		{
			this.ReplaySampleQueue.Clone(otherMoveSyncComp.ReplaySampleQueue);
		}

		// Token: 0x06030C84 RID: 199812 RVA: 0x00C0E2A6 File Offset: 0x00C0C4A6
		protected virtual bool CalcRelativeMove(ReplaySample sample1, ReplaySample sample2, float lerpPercent, global::Vector outLocation, global::Rotator outRotator)
		{
			return false;
		}

		// Token: 0x06030C85 RID: 199813 RVA: 0x00C0E2A9 File Offset: 0x00C0C4A9
		[return: Nullable(2)]
		protected virtual EntityHandle CheckRelativeMove(ReplaySample sample1, ReplaySample sample2, float lerpPercent, global::Vector outLocation, global::Rotator outRotator)
		{
			return null;
		}

		// Token: 0x06030C86 RID: 199814 RVA: 0x00C0E2AC File Offset: 0x00C0C4AC
		protected virtual bool TransformFromRelativeMove(EntityHandle handle, global::Vector location, global::Rotator rotator, global::Vector outLocation, global::Rotator outRotator)
		{
			return false;
		}

		// Token: 0x06030C87 RID: 199815 RVA: 0x00C0E2B0 File Offset: 0x00C0C4B0
		public virtual void TickReplaySamples()
		{
			double nowSeconds = Singleton<Time>.Instance.NowSeconds;
			if (this.LastApplyMoveSample != null && nowSeconds - this.LastApplyMoveSample.TimeStamp > 1.0)
			{
				CombatLog instance = Singleton<CombatLog>.Instance;
				CombatLog.EDebugModule flag = CombatLog.EDebugModule.Move;
				Entity entity = base.Entity;
				string message = "不连贯的样条点丢弃";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("diff", nowSeconds - this.LastApplyMoveSample.TimeStamp);
				instance.Info(flag, entity, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				this.LastApplyMoveSample = null;
			}
			while (!this.ReplaySampleQueue.Empty)
			{
				ReplaySample lastApplyMoveSample = this.LastApplyMoveSample;
				ReplaySample front = this.ReplaySampleQueue.Front;
				if (nowSeconds >= front.TimeStamp)
				{
					this.LastApplyMoveSample = front;
					this.LastApplyMoveSampleUsed = false;
					this.ReplaySampleQueue.RemoveFront();
				}
				else
				{
					if (lastApplyMoveSample != null)
					{
						float num = (float)Singleton<MathUtils>.Instance.RangeClamp(nowSeconds, lastApplyMoveSample.TimeStamp, front.TimeStamp, 0.0, 1.0);
						this.CacheBaseEntityHandle = this.CheckRelativeMove(lastApplyMoveSample, front, num, this.CacheRelativeLocation, this.CacheRelativeRotator);
						if (this.CacheBaseEntityHandle != null && this.TransformFromRelativeMove(this.CacheBaseEntityHandle, this.CacheRelativeLocation, this.CacheRelativeRotator, this.CacheFinalLocation, this.CacheFinalRotator))
						{
							bool lastRelativeMove = this.LastRelativeMove;
							this.LastRelativeMove = true;
						}
						else
						{
							global::Vector.Lerp(lastApplyMoveSample.Location, front.Location, (double)num, this.CacheFinalLocation);
							global::Rotator.Lerp(lastApplyMoveSample.Rotation, front.Rotation, num, this.CacheFinalRotator);
							bool lastRelativeMove2 = this.LastRelativeMove;
							this.LastRelativeMove = false;
						}
						global::Vector.Lerp(lastApplyMoveSample.LinearVelocity, front.LinearVelocity, (double)num, this.CacheVelocity);
						float controllerPitch = Singleton<MathUtils>.Instance.Lerp(MathCommon.WrapAngle(lastApplyMoveSample.ControllerPitch), MathCommon.WrapAngle(front.ControllerPitch), num);
						this.ApplyMoveSample(lastApplyMoveSample.MovementMode, this.CacheFinalLocation, this.CacheFinalRotator, lastApplyMoveSample.LinearVelocity, lastApplyMoveSample.SlideForward, front.ControllerPlayerId, lastApplyMoveSample.Input, controllerPitch, lastApplyMoveSample.TimeScale, lastApplyMoveSample.ServerTimeStamp, (float)lastApplyMoveSample.Rtt);
						this.LastApplyMoveSampleUsed = true;
						break;
					}
					break;
				}
			}
			if (this.ReplaySampleQueue.Empty && !this.LastApplyMoveSampleUsed && this.LastApplyMoveSample != null)
			{
				ReplaySample lastApplyMoveSample2 = this.LastApplyMoveSample;
				this.CacheBaseEntityHandle = this.CheckRelativeMove(lastApplyMoveSample2, lastApplyMoveSample2, 1f, this.CacheRelativeLocation, this.CacheRelativeRotator);
				bool flag2 = this.CacheBaseEntityHandle != null && this.TransformFromRelativeMove(this.CacheBaseEntityHandle, this.CacheRelativeLocation, this.CacheRelativeRotator, this.CacheFinalLocation, this.CacheFinalRotator);
				this.ApplyMoveSample(this.LastApplyMoveSample.MovementMode, flag2 ? this.CacheFinalLocation : lastApplyMoveSample2.Location, flag2 ? this.CacheFinalRotator : lastApplyMoveSample2.Rotation, this.LastApplyMoveSample.LinearVelocity, this.LastApplyMoveSample.SlideForward, this.LastApplyMoveSample.ControllerPlayerId, this.LastApplyMoveSample.Input, this.LastApplyMoveSample.ControllerPitch, this.LastApplyMoveSample.TimeScale, this.LastApplyMoveSample.ServerTimeStamp, (float)this.LastApplyMoveSample.Rtt);
				this.LastApplyMoveSampleUsed = true;
			}
		}

		// Token: 0x06030C88 RID: 199816 RVA: 0x00C0E5F4 File Offset: 0x00C0C7F4
		protected unsafe virtual void ApplyMoveSample(int movementMode, global::Vector location, global::Rotator rotator, global::Vector linearVelocity, global::Vector slideForward, int controllerPlayerId, int input, float controllerPitch, float timeScale, long serverTimeStamp, float originRtt)
		{
			if (this.LastMoveAutonomousProxy || this.ControllerPlayerId != controllerPlayerId)
			{
				double num = global::Vector.Dist(this.LastLocation, this.CacheFinalLocation);
				CombatLog instance = Singleton<CombatLog>.Instance;
				CombatLog.EDebugModule flag = CombatLog.EDebugModule.Move;
				Entity entity = base.Entity;
				string message = "移动来源切换";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("上个控制者", this.ControllerPlayerId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("当前控制者", controllerPlayerId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("位移距离", num.ToString("#"));
				instance.Info(flag, entity, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			}
			CreatureDataComponent component = base.Entity.GetComponent<CreatureDataComponent>();
			if (ControllerBase<CombatDebugDrawController>.Instance.DebugMonsterMovePath && component.GetEntityType() == EEntityType.Monster)
			{
				UKismetSystemLibrary.D_DrawDebugLine(GlobalData.World, this.LastLocation.ToUeVector(false), this.CacheFinalLocation.ToUeVector(false), new FLinearColor(1f, 0f, 0f, 1f), 15f, 0f);
			}
			this.ControllerPlayerId = controllerPlayerId;
			this.ActorComp.SetActorLocationAndRotation(location.ToUeVector(false), rotator.ToUeRotator(), "角色移动同步.添加简单位移", false, null);
			float bufferTime = 0f;
			if (this.LastReceiveMoveSample != null)
			{
				bufferTime = (float)((this.LastReceiveMoveSample.TimeStamp - Singleton<Time>.Instance.NowSeconds) * 1000.0);
			}
			this.ReportMoveDataApplyInfo((float)(Singleton<Time>.Instance.CombatServerTime - (double)serverTimeStamp), bufferTime, originRtt);
		}

		// Token: 0x06030C89 RID: 199817 RVA: 0x00C0E794 File Offset: 0x00C0C994
		public string VectorToString([Nullable(2)] Aki.Protocol.Vector vector)
		{
			if (vector == null)
			{
				return "[-]";
			}
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(4, 3);
			defaultInterpolatedStringHandler.AppendLiteral("[");
			defaultInterpolatedStringHandler.AppendFormatted<float>(vector.X, "#");
			defaultInterpolatedStringHandler.AppendLiteral(",");
			defaultInterpolatedStringHandler.AppendFormatted<float>(vector.Y, "#");
			defaultInterpolatedStringHandler.AppendLiteral(",");
			defaultInterpolatedStringHandler.AppendFormatted<float>(vector.Z, "#");
			defaultInterpolatedStringHandler.AppendLiteral("]");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x06030C8A RID: 199818 RVA: 0x00C0E820 File Offset: 0x00C0CA20
		public string VectorToString([Nullable(2)] global::Vector vector)
		{
			if (vector == null)
			{
				return "[-]";
			}
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(4, 3);
			defaultInterpolatedStringHandler.AppendLiteral("[");
			defaultInterpolatedStringHandler.AppendFormatted<double>(vector.X, "#");
			defaultInterpolatedStringHandler.AppendLiteral(",");
			defaultInterpolatedStringHandler.AppendFormatted<double>(vector.Y, "#");
			defaultInterpolatedStringHandler.AppendLiteral(",");
			defaultInterpolatedStringHandler.AppendFormatted<double>(vector.Z, "#");
			defaultInterpolatedStringHandler.AppendLiteral("]");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x06030C8B RID: 199819 RVA: 0x00C0E8AC File Offset: 0x00C0CAAC
		public string MoveInfosToString(IList<MoveReplaySample> moveInfos)
		{
			MoveReplaySample moveReplaySample = moveInfos[0];
			MoveReplaySample moveReplaySample2 = moveInfos[moveInfos.Count - 1];
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(49, 9);
			defaultInterpolatedStringHandler.AppendLiteral("length:");
			defaultInterpolatedStringHandler.AppendFormatted<int>(moveInfos.Count);
			defaultInterpolatedStringHandler.AppendLiteral(", t:");
			defaultInterpolatedStringHandler.AppendFormatted<float>(moveReplaySample.TimeStamp, "F3");
			defaultInterpolatedStringHandler.AppendLiteral("-");
			defaultInterpolatedStringHandler.AppendFormatted<float>(moveReplaySample2.TimeStamp, "F3");
			defaultInterpolatedStringHandler.AppendLiteral(", position:");
			defaultInterpolatedStringHandler.AppendFormatted(this.VectorToString(moveReplaySample.Location));
			defaultInterpolatedStringHandler.AppendLiteral("-");
			defaultInterpolatedStringHandler.AppendFormatted(this.VectorToString(moveReplaySample2.Location));
			defaultInterpolatedStringHandler.AppendLiteral(", refPos:");
			RelativeMoveReplaySample relativeMoveReplaySample = moveReplaySample2.RelativeMoveReplaySample;
			defaultInterpolatedStringHandler.AppendFormatted(this.VectorToString((relativeMoveReplaySample != null) ? relativeMoveReplaySample.RelativeLocation : null));
			defaultInterpolatedStringHandler.AppendLiteral(" r:");
			Aki.Protocol.Rotator rotation = moveReplaySample.Rotation;
			defaultInterpolatedStringHandler.AppendFormatted<float?>((rotation != null) ? new float?(rotation.Yaw) : null, "#");
			defaultInterpolatedStringHandler.AppendLiteral("-");
			Aki.Protocol.Rotator rotation2 = moveReplaySample2.Rotation;
			defaultInterpolatedStringHandler.AppendFormatted<float?>((rotation2 != null) ? new float?(rotation2.Yaw) : null, "#");
			defaultInterpolatedStringHandler.AppendLiteral(", timeScale:");
			defaultInterpolatedStringHandler.AppendFormatted<float>(moveReplaySample2.TimeScale);
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x06030C8C RID: 199820 RVA: 0x00C0EA28 File Offset: 0x00C0CC28
		public string MoveInfoToString(MoveReplaySample moveInfo)
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(25, 3);
			defaultInterpolatedStringHandler.AppendLiteral("t:");
			defaultInterpolatedStringHandler.AppendFormatted<float>(moveInfo.TimeStamp, "F3");
			defaultInterpolatedStringHandler.AppendLiteral(", position:");
			defaultInterpolatedStringHandler.AppendFormatted(this.VectorToString(moveInfo.Location));
			defaultInterpolatedStringHandler.AppendLiteral(", timeScale:");
			defaultInterpolatedStringHandler.AppendFormatted<float>(moveInfo.TimeScale);
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x06030C8D RID: 199821 RVA: 0x00C0EA9C File Offset: 0x00C0CC9C
		public string MoveInfoToString(ReplaySample moveInfo)
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(25, 3);
			defaultInterpolatedStringHandler.AppendLiteral("t:");
			defaultInterpolatedStringHandler.AppendFormatted<double>(moveInfo.TimeStamp, "F3");
			defaultInterpolatedStringHandler.AppendLiteral(", position:");
			defaultInterpolatedStringHandler.AppendFormatted(this.VectorToString(moveInfo.Location));
			defaultInterpolatedStringHandler.AppendLiteral(", timeScale:");
			defaultInterpolatedStringHandler.AppendFormatted<float>(moveInfo.TimeScale);
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x06030C8E RID: 199822 RVA: 0x00C0EB10 File Offset: 0x00C0CD10
		public void ReportMoveDataApplyInfo(float delayMs, float bufferTime, float originRtt)
		{
			string data = Json.Encode(new Dictionary<string, object>
			{
				{
					"udp_mode",
					ModelBase<CombatMessageModel>.Instance.MoveSyncUdpMode
				},
				{
					"creature_id",
					this.CreatureDataComp.GetCreatureDataId()
				},
				{
					"pb_data_id",
					this.CreatureDataComp.GetPbDataId()
				},
				{
					"rtt",
					Singleton<Net>.Instance.RttMs
				},
				{
					"rtt_total",
					Singleton<Net>.Instance.RttMs + originRtt
				},
				{
					"delay",
					delayMs
				},
				{
					"buffer_time",
					bufferTime
				}
			}, null);
			ControllerBase<CombatDebugController>.Instance.DataReport("MOVE_SYNC_INFO", data);
		}

		// Token: 0x06030C8F RID: 199823 RVA: 0x00C0EBE4 File Offset: 0x00C0CDE4
		public void ReportMoveDataDragDistance(float distance, bool toSelf)
		{
			string data = Json.Encode(new Dictionary<string, object>
			{
				{
					"udp_mode",
					ModelBase<CombatMessageModel>.Instance.MoveSyncUdpMode
				},
				{
					"creature_id",
					this.CreatureDataComp.GetCreatureDataId()
				},
				{
					"pb_data_id",
					this.CreatureDataComp.GetPbDataId()
				},
				{
					"rtt",
					Singleton<Net>.Instance.RttMs
				},
				{
					"to_self",
					toSelf
				},
				{
					"distance",
					distance
				}
			}, null);
			ControllerBase<CombatDebugController>.Instance.DataReport("MOVE_SYNC_DRAG_DISTANCE", data);
		}

		// Token: 0x06030C90 RID: 199824 RVA: 0x00C0EC9C File Offset: 0x00C0CE9C
		public void ReportMoveDataBufferMissTime(float missTime)
		{
			string data = Json.Encode(new Dictionary<string, object>
			{
				{
					"udp_mode",
					ModelBase<CombatMessageModel>.Instance.MoveSyncUdpMode
				},
				{
					"creature_id",
					this.CreatureDataComp.GetCreatureDataId()
				},
				{
					"pb_data_id",
					this.CreatureDataComp.GetPbDataId()
				},
				{
					"rtt",
					Singleton<Net>.Instance.RttMs
				},
				{
					"miss_time",
					missTime
				}
			}, null);
			ControllerBase<CombatDebugController>.Instance.DataReport("MOVE_SYNC_BUFFER_MISS_TIME", data);
		}

		// Token: 0x06030C91 RID: 199825 RVA: 0x00C0ED40 File Offset: 0x00C0CF40
		public void ReportMoveDataInnerBufferMissTime(float missTime)
		{
			string data = Json.Encode(new Dictionary<string, object>
			{
				{
					"udp_mode",
					ModelBase<CombatMessageModel>.Instance.MoveSyncUdpMode
				},
				{
					"creature_id",
					this.CreatureDataComp.GetCreatureDataId()
				},
				{
					"pb_data_id",
					this.CreatureDataComp.GetPbDataId()
				},
				{
					"rtt",
					Singleton<Net>.Instance.RttMs
				},
				{
					"miss_time",
					missTime
				}
			}, null);
			ControllerBase<CombatDebugController>.Instance.DataReport("MOVE_SYNC_INNER_BUFFER_MISS_TIME", data);
		}

		// Token: 0x06030C92 RID: 199826 RVA: 0x00C0EDE4 File Offset: 0x00C0CFE4
		public override bool ClearComponent(EntityComponent componentTemplate)
		{
			if (!base.ClearComponent(componentTemplate))
			{
				return false;
			}
			BaseMovementSyncComponent baseMovementSyncComponent = (BaseMovementSyncComponent)componentTemplate;
			if (base.CanResetComponentProperty("ActorComp"))
			{
				if (baseMovementSyncComponent.ActorComp == null)
				{
					this.ActorComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BaseActorComponent>(this.ActorComp), "ActorComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("TimeScaleComp"))
			{
				if (baseMovementSyncComponent.TimeScaleComp == null)
				{
					this.TimeScaleComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterTimeScaleComponent>(this.TimeScaleComp), "TimeScaleComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("MoveComp"))
			{
				if (baseMovementSyncComponent.MoveComp == null)
				{
					this.MoveComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BaseMoveComponent>(this.MoveComp), "MoveComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("CreatureDataComp"))
			{
				if (baseMovementSyncComponent.CreatureDataComp == null)
				{
					this.CreatureDataComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CreatureDataComponent>(this.CreatureDataComp), "CreatureDataComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("EnableMovementSyncInternal"))
			{
				this.EnableMovementSyncInternal = baseMovementSyncComponent.EnableMovementSyncInternal;
			}
			if (base.CanResetComponentProperty("CacheBaseEntityHandle"))
			{
				if (baseMovementSyncComponent.CacheBaseEntityHandle == null)
				{
					this.CacheBaseEntityHandle = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<EntityHandle>(this.CacheBaseEntityHandle), "CacheBaseEntityHandle"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("CacheRelativeLocation") && baseMovementSyncComponent.CacheRelativeLocation != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.CacheRelativeLocation), "CacheRelativeLocation"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("CacheRelativeRotator") && baseMovementSyncComponent.CacheRelativeRotator != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<global::Rotator>(this.CacheRelativeRotator), "CacheRelativeRotator"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("CacheFinalLocation") && baseMovementSyncComponent.CacheFinalLocation != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.CacheFinalLocation), "CacheFinalLocation"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("CacheFinalRotator") && baseMovementSyncComponent.CacheFinalRotator != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<global::Rotator>(this.CacheFinalRotator), "CacheFinalRotator"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("CacheVelocity") && baseMovementSyncComponent.CacheVelocity != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.CacheVelocity), "CacheVelocity"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("ControllerPlayerId"))
			{
				this.ControllerPlayerId = baseMovementSyncComponent.ControllerPlayerId;
			}
			if (base.CanResetComponentProperty("TmpVector") && baseMovementSyncComponent.TmpVector != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.TmpVector), "TmpVector"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("TmpVector2") && baseMovementSyncComponent.TmpVector2 != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.TmpVector2), "TmpVector2"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("LastHasBaseMovement"))
			{
				this.LastHasBaseMovement = baseMovementSyncComponent.LastHasBaseMovement;
			}
			if (base.CanResetComponentProperty("LastBasePlatform"))
			{
				if (baseMovementSyncComponent.LastBasePlatform == null)
				{
					this.LastBasePlatform = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BasePlatform>(this.LastBasePlatform), "LastBasePlatform"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("LastMoveAutonomousProxy"))
			{
				this.LastMoveAutonomousProxy = baseMovementSyncComponent.LastMoveAutonomousProxy;
			}
			if (base.CanResetComponentProperty("LastRelativeMove"))
			{
				this.LastRelativeMove = baseMovementSyncComponent.LastRelativeMove;
			}
			if (base.CanResetComponentProperty("LastMove"))
			{
				this.LastMove = baseMovementSyncComponent.LastMove;
			}
			if (base.CanResetComponentProperty("LastSendTime"))
			{
				this.LastSendTime = baseMovementSyncComponent.LastSendTime;
			}
			if (base.CanResetComponentProperty("LastReceiveControllerPlayerId"))
			{
				this.LastReceiveControllerPlayerId = baseMovementSyncComponent.LastReceiveControllerPlayerId;
			}
			if (base.CanResetComponentProperty("LastSendLocation") && baseMovementSyncComponent.LastSendLocation != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.LastSendLocation), "LastSendLocation"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("LastSendRotation") && baseMovementSyncComponent.LastSendRotation != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<global::Rotator>(this.LastSendRotation), "LastSendRotation"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("LastLocation") && baseMovementSyncComponent.LastLocation != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.LastLocation), "LastLocation"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("LastRotation") && baseMovementSyncComponent.LastRotation != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<global::Rotator>(this.LastRotation), "LastRotation"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("IsPending"))
			{
				this.IsPending = baseMovementSyncComponent.IsPending;
			}
			if (base.CanResetComponentProperty("PendingTime"))
			{
				this.PendingTime = baseMovementSyncComponent.PendingTime;
			}
			if (base.CanResetComponentProperty("SingleModeSendInterval"))
			{
				this.SingleModeSendInterval = baseMovementSyncComponent.SingleModeSendInterval;
			}
			if (base.CanResetComponentProperty("<PendingMoveInfos>k__BackingField"))
			{
				if (baseMovementSyncComponent.PendingMoveInfos == null)
				{
					this.PendingMoveInfos = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<List<MoveReplaySample>>(this.PendingMoveInfos), "<PendingMoveInfos>k__BackingField"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("LastReceiveMoveSample"))
			{
				if (baseMovementSyncComponent.LastReceiveMoveSample == null)
				{
					this.LastReceiveMoveSample = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<ReplaySample>(this.LastReceiveMoveSample), "LastReceiveMoveSample"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("LastApplyMoveSample"))
			{
				if (baseMovementSyncComponent.LastApplyMoveSample == null)
				{
					this.LastApplyMoveSample = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<ReplaySample>(this.LastApplyMoveSample), "LastApplyMoveSample"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("LastMoveSample"))
			{
				if (baseMovementSyncComponent.LastMoveSample == null)
				{
					this.LastMoveSample = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<MoveReplaySample>(this.LastMoveSample), "LastMoveSample"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("LastApplyMoveSampleUsed"))
			{
				this.LastApplyMoveSampleUsed = baseMovementSyncComponent.LastApplyMoveSampleUsed;
			}
			if (base.CanResetComponentProperty("NowLogicTickTime"))
			{
				this.NowLogicTickTime = baseMovementSyncComponent.NowLogicTickTime;
			}
			if (base.CanResetComponentProperty("LastLogicTickTime"))
			{
				this.LastLogicTickTime = baseMovementSyncComponent.LastLogicTickTime;
			}
			if (base.CanResetComponentProperty("LastApplyLogicTickTime"))
			{
				this.LastApplyLogicTickTime = baseMovementSyncComponent.LastApplyLogicTickTime;
			}
			if (base.CanResetComponentProperty("Activated"))
			{
				this.Activated = baseMovementSyncComponent.Activated;
			}
			if (base.CanResetComponentProperty("PkgLastTimeScale"))
			{
				this.PkgLastTimeScale = baseMovementSyncComponent.PkgLastTimeScale;
			}
			if (base.CanResetComponentProperty("ReplaySampleQueue") && baseMovementSyncComponent.ReplaySampleQueue != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Deque<ReplaySample>>(this.ReplaySampleQueue), "ReplaySampleQueue"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("TmpLocation"))
			{
				if (baseMovementSyncComponent.TmpLocation == null)
				{
					this.TmpLocation = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.TmpLocation), "TmpLocation"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("TmpLocation2"))
			{
				if (baseMovementSyncComponent.TmpLocation2 == null)
				{
					this.TmpLocation2 = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.TmpLocation2), "TmpLocation2"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("TmpRotation"))
			{
				if (baseMovementSyncComponent.TmpRotation == null)
				{
					this.TmpRotation = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<global::Rotator>(this.TmpRotation), "TmpRotation"))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x0401C073 RID: 114803
		private static readonly int IsWithEditor = (KuroApplication.IsWithEditor() > false) ? 1 : 0;

		// Token: 0x0401C074 RID: 114804
		[Nullable(2)]
		protected BaseActorComponent ActorComp;

		// Token: 0x0401C075 RID: 114805
		[Nullable(2)]
		protected CharacterTimeScaleComponent TimeScaleComp;

		// Token: 0x0401C076 RID: 114806
		[Nullable(2)]
		protected BaseMoveComponent MoveComp;

		// Token: 0x0401C077 RID: 114807
		[Nullable(2)]
		protected CreatureDataComponent CreatureDataComp;

		// Token: 0x0401C078 RID: 114808
		protected bool EnableMovementSyncInternal;

		// Token: 0x0401C079 RID: 114809
		[Nullable(2)]
		protected EntityHandle CacheBaseEntityHandle;

		// Token: 0x0401C07A RID: 114810
		protected readonly global::Vector CacheRelativeLocation = global::Vector.Create();

		// Token: 0x0401C07B RID: 114811
		protected readonly global::Rotator CacheRelativeRotator = global::Rotator.Create();

		// Token: 0x0401C07C RID: 114812
		protected readonly global::Vector CacheFinalLocation = global::Vector.Create();

		// Token: 0x0401C07D RID: 114813
		protected readonly global::Rotator CacheFinalRotator = global::Rotator.Create();

		// Token: 0x0401C07E RID: 114814
		protected readonly global::Vector CacheVelocity = global::Vector.Create();

		// Token: 0x0401C07F RID: 114815
		public int ControllerPlayerId;

		// Token: 0x0401C080 RID: 114816
		private readonly float MaxExtraOffset = 1f;

		// Token: 0x0401C081 RID: 114817
		protected readonly global::Vector TmpVector = global::Vector.Create();

		// Token: 0x0401C082 RID: 114818
		protected readonly global::Vector TmpVector2 = global::Vector.Create();

		// Token: 0x0401C083 RID: 114819
		protected bool LastHasBaseMovement;

		// Token: 0x0401C084 RID: 114820
		[Nullable(2)]
		protected BasePlatform LastBasePlatform;

		// Token: 0x0401C085 RID: 114821
		public bool LastMoveAutonomousProxy;

		// Token: 0x0401C086 RID: 114822
		protected bool LastRelativeMove;

		// Token: 0x0401C087 RID: 114823
		protected bool LastMove;

		// Token: 0x0401C088 RID: 114824
		protected double LastSendTime;

		// Token: 0x0401C089 RID: 114825
		protected int LastReceiveControllerPlayerId;

		// Token: 0x0401C08A RID: 114826
		protected readonly global::Vector LastSendLocation = global::Vector.Create();

		// Token: 0x0401C08B RID: 114827
		protected readonly global::Rotator LastSendRotation = global::Rotator.Create();

		// Token: 0x0401C08C RID: 114828
		protected readonly global::Vector LastLocation = global::Vector.Create();

		// Token: 0x0401C08D RID: 114829
		protected readonly global::Rotator LastRotation = global::Rotator.Create();

		// Token: 0x0401C08E RID: 114830
		protected bool IsPending;

		// Token: 0x0401C08F RID: 114831
		protected double PendingTime;

		// Token: 0x0401C090 RID: 114832
		public static readonly float PendingMoveCacheTime = 0.08f;

		// Token: 0x0401C091 RID: 114833
		public static readonly float MaxPendingMoveCacheTime = 1f;

		// Token: 0x0401C092 RID: 114834
		public float SingleModeSendInterval = 1f;

		// Token: 0x0401C093 RID: 114835
		public static readonly float SingleModeSendLocationTolerance = 10f;

		// Token: 0x0401C094 RID: 114836
		public static readonly float SingleModeSendRotationTolerance = 5f;

		// Token: 0x0401C095 RID: 114837
		public static readonly float SingleModeSendLocationToleranceMax = 600f;

		// Token: 0x0401C097 RID: 114839
		[Nullable(2)]
		protected ReplaySample LastReceiveMoveSample;

		// Token: 0x0401C098 RID: 114840
		[Nullable(2)]
		protected ReplaySample LastApplyMoveSample;

		// Token: 0x0401C099 RID: 114841
		[Nullable(2)]
		protected MoveReplaySample LastMoveSample;

		// Token: 0x0401C09A RID: 114842
		protected bool LastApplyMoveSampleUsed;

		// Token: 0x0401C09B RID: 114843
		protected double NowLogicTickTime;

		// Token: 0x0401C09C RID: 114844
		protected double LastLogicTickTime;

		// Token: 0x0401C09D RID: 114845
		protected double LastApplyLogicTickTime;

		// Token: 0x0401C09E RID: 114846
		private bool Activated;

		// Token: 0x0401C09F RID: 114847
		private float PkgLastTimeScale;

		// Token: 0x0401C0A0 RID: 114848
		private readonly Deque<ReplaySample> ReplaySampleQueue = new Deque<ReplaySample>(4);

		// Token: 0x0401C0A1 RID: 114849
		public global::Vector TmpLocation = global::Vector.Create();

		// Token: 0x0401C0A2 RID: 114850
		public global::Vector TmpLocation2 = global::Vector.Create();

		// Token: 0x0401C0A3 RID: 114851
		public global::Rotator TmpRotation = global::Rotator.Create();
	}
}
