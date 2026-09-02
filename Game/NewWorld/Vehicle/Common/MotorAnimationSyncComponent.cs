using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using AkiClient.Game.Aki.Character.Vehicle.Motor;
using CSharpScript.Game.NewWorld.Character.Common.Component;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.Vehicle.Common
{
	// Token: 0x020047D3 RID: 18387
	[NullableContext(1)]
	[Nullable(0)]
	public class MotorAnimationSyncComponent : CharacterAnimationSyncComponent
	{
		// Token: 0x0602FB25 RID: 195365 RVA: 0x00B69346 File Offset: 0x00B67546
		static MotorAnimationSyncComponent()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(MotorAnimationSyncComponent.CreateStaticDefaultValue), new Action(MotorAnimationSyncComponent.ResetStaticDefaultValue));
		}

		// Token: 0x0602FB26 RID: 195366 RVA: 0x00B69365 File Offset: 0x00B67565
		protected override void OnActivate()
		{
			base.OnActivate();
			this.VehiclePerformComponent = base.Entity.CheckGetComponent<VehiclePerformComponent>();
			this.VehicleMovement = (this.ActorComp.Owner.GetComponentByClass(UKuroVehicleMovementComponent.StaticClass()) as UKuroVehicleMovementComponent);
		}

		// Token: 0x0602FB27 RID: 195367 RVA: 0x00B693A3 File Offset: 0x00B675A3
		protected override void AfterTickInner(float delta)
		{
			base.AfterTickInner(delta);
			this.TryCollectAnimationParams();
			this.TryPushAnimationParams();
		}

		// Token: 0x0602FB28 RID: 195368 RVA: 0x00B693B9 File Offset: 0x00B675B9
		protected override void OnTick(float delta)
		{
			this.ApplyMotorAnimSample();
		}

		// Token: 0x0602FB29 RID: 195369 RVA: 0x00B693C4 File Offset: 0x00B675C4
		private bool TryCollectAnimationParams()
		{
			if (ModelBase<GameModeModel>.Instance.IsMulti)
			{
				BaseActorComponent actorComp = this.ActorComp;
				if (actorComp != null && actorComp.IsMoveAutonomousProxy && this.VehicleMovement != null)
				{
					VehiclePerformComponent vehiclePerformComponent = this.VehiclePerformComponent;
					bool flag = vehiclePerformComponent != null && vehiclePerformComponent.IsBeingImpacted;
					if ((!flag || Singleton<Time>.Instance.NowSeconds - this.LastSyncImpactTime < 0.10000000149011612) && Singleton<Time>.Instance.NowSeconds - this.LastPendingTime < 0.10000000149011612)
					{
						return false;
					}
					if (!flag && this.VehicleMovement.MotorSubState == EMotorSubState.Stop)
					{
						return false;
					}
					MotorAnimInfo motorAnimInfo = MotorAnimInfo.Create();
					UMotorWheelDisplayInfoObject wheelDisplayInfosObj = this.VehicleMovement.WheelDisplayInfosObj;
					if (wheelDisplayInfosObj != null)
					{
						FMotorWheelDisplayInfo fmotorWheelDisplayInfo = wheelDisplayInfosObj.DisplayInfos.Get(0);
						if (fmotorWheelDisplayInfo != null)
						{
							motorAnimInfo.FrontWheelInfo = new MotorWheelInfo
							{
								Accel = fmotorWheelDisplayInfo.WheelAccel,
								Speed = fmotorWheelDisplayInfo.WheelSpeed,
								Location = new Aki.Protocol.Vector
								{
									X = fmotorWheelDisplayInfo.WheelLocation.X,
									Y = fmotorWheelDisplayInfo.WheelLocation.Y,
									Z = fmotorWheelDisplayInfo.WheelLocation.Z
								}
							};
						}
						FMotorWheelDisplayInfo fmotorWheelDisplayInfo2 = wheelDisplayInfosObj.DisplayInfos.Get(1);
						if (fmotorWheelDisplayInfo2 != null)
						{
							motorAnimInfo.BackWheelInfo = new MotorWheelInfo
							{
								Accel = fmotorWheelDisplayInfo2.WheelAccel,
								Speed = fmotorWheelDisplayInfo2.WheelSpeed,
								Location = new Aki.Protocol.Vector
								{
									X = fmotorWheelDisplayInfo2.WheelLocation.X,
									Y = fmotorWheelDisplayInfo2.WheelLocation.Y,
									Z = fmotorWheelDisplayInfo2.WheelLocation.Z
								}
							};
						}
					}
					else
					{
						Singleton<Log>.Instance.Warn(ELogModule.Vehicle, ELogAuthor.ZFJ, "MotorAnimParam NoWheelInfoObj", default(ReadOnlySpan<ValueTuple<string, object>>));
					}
					if (this.VehiclePerformComponent != null && flag != this.LastBeingImpacted)
					{
						this.LastBeingImpacted = flag;
						VehiclePerformComponent vehiclePerformComponent2 = this.VehiclePerformComponent;
						motorAnimInfo.IsBeingImpacted = flag;
						if (flag)
						{
							motorAnimInfo.ImpactedVelocity = new Aki.Protocol.Vector
							{
								X = (float)vehiclePerformComponent2.ImpactedVelocity.X,
								Y = (float)vehiclePerformComponent2.ImpactedVelocity.Y,
								Z = (float)vehiclePerformComponent2.ImpactedVelocity.Z
							};
							if (vehiclePerformComponent2.CacheImpactHitResult != null)
							{
								global::Vector vector = global::Vector.Create(vehiclePerformComponent2.CacheImpactHitResult.Normal);
								motorAnimInfo.ImpactedNormal = new Aki.Protocol.Vector
								{
									X = (float)vector.X,
									Y = (float)vector.Y,
									Z = (float)vector.Z
								};
							}
							this.LastSyncImpactTime = Singleton<Time>.Instance.NowSeconds;
						}
					}
					if (this.MotorAnimInstance == null)
					{
						this.MotorAnimInstance = (base.MainAnimInstance as ABP_Motor_BaseVehicle_C);
					}
					if (this.MotorAnimInstance != null)
					{
						motorAnimInfo.MoveMix = new Aki.Protocol.Vector
						{
							X = this.MotorAnimInstance.移动混合.X,
							Y = this.MotorAnimInstance.移动混合.Y,
							Z = 0f
						};
					}
					this.PendingAnimInfos.Add(motorAnimInfo);
					return true;
				}
			}
			return false;
		}

		// Token: 0x0602FB2A RID: 195370 RVA: 0x00B696E8 File Offset: 0x00B678E8
		private void TryPushAnimationParams()
		{
			if (this.PendingAnimInfos.Count == 0)
			{
				return;
			}
			MotorAnimEntity motorAnimEntity = MotorAnimEntity.Create();
			motorAnimEntity.EntityId = Singleton<MathUtils>.Instance.NumberToLong(this.ActorComp.CreatureData.GetCreatureDataId());
			foreach (MotorAnimInfo item in this.PendingAnimInfos)
			{
				motorAnimEntity.MotorAnimInfos.Add(item);
			}
			MotorAnimReplaySampleUdpPush motorAnimReplaySampleUdpPush = MotorAnimReplaySampleUdpPush.Create();
			motorAnimReplaySampleUdpPush.MotorAnimEntities.Add(motorAnimEntity);
			motorAnimReplaySampleUdpPush.SceneOwnerId = ModelBase<OnlineModel>.Instance.OwnerId;
			Singleton<Net>.Instance.Send(EPushMessageId.MotorAnimReplaySampleUdpPush, motorAnimReplaySampleUdpPush);
			this.LastPendingTime = Singleton<Time>.Instance.NowSeconds;
			this.PendingAnimInfos = new List<MotorAnimInfo>();
		}

		// Token: 0x0602FB2B RID: 195371 RVA: 0x00B697C4 File Offset: 0x00B679C4
		public void ReceiveMotorAnimSample(IList<MotorAnimInfo> data)
		{
			foreach (MotorAnimInfo element in data)
			{
				this.ReplaySampleQueue.AddRear(element);
			}
		}

		// Token: 0x0602FB2C RID: 195372 RVA: 0x00B69814 File Offset: 0x00B67A14
		private void ApplyMotorAnimSample()
		{
			if (!ModelBase<GameModeModel>.Instance.IsMulti)
			{
				return;
			}
			BaseActorComponent actorComp = this.ActorComp;
			if (actorComp != null && actorComp.IsMoveAutonomousProxy)
			{
				return;
			}
			if (this.VehiclePerformComponent == null || this.VehicleMovement == null)
			{
				return;
			}
			if (this.ReplaySampleQueue.Empty)
			{
				return;
			}
			while (!this.ReplaySampleQueue.Empty)
			{
				MotorAnimInfo motorAnimInfo = this.ReplaySampleQueue.RemoveFront();
				if (MotorAnimationSyncComponent.WheelInfos == null)
				{
					MotorAnimationSyncComponent.WheelInfos = new TArray<FMotorWheelDisplayInfo>();
					MotorAnimationSyncComponent.WheelInfos.Add(new FMotorWheelDisplayInfo());
					MotorAnimationSyncComponent.WheelInfos.Add(new FMotorWheelDisplayInfo());
				}
				FMotorWheelDisplayInfo fmotorWheelDisplayInfo = MotorAnimationSyncComponent.WheelInfos.Get(0);
				if (fmotorWheelDisplayInfo != null)
				{
					MotorWheelInfo frontWheelInfo = motorAnimInfo.FrontWheelInfo;
					fmotorWheelDisplayInfo.WheelSpeed = frontWheelInfo.Speed;
					fmotorWheelDisplayInfo.WheelAccel = frontWheelInfo.Accel;
					Aki.Protocol.Vector location = frontWheelInfo.Location;
					fmotorWheelDisplayInfo.WheelLocation = new FVector(location.X, location.Y, location.Z);
				}
				FMotorWheelDisplayInfo fmotorWheelDisplayInfo2 = MotorAnimationSyncComponent.WheelInfos.Get(1);
				if (fmotorWheelDisplayInfo2 != null)
				{
					MotorWheelInfo backWheelInfo = motorAnimInfo.BackWheelInfo;
					fmotorWheelDisplayInfo2.WheelSpeed = backWheelInfo.Speed;
					fmotorWheelDisplayInfo2.WheelAccel = backWheelInfo.Accel;
					Aki.Protocol.Vector location2 = backWheelInfo.Location;
					fmotorWheelDisplayInfo2.WheelLocation = new FVector(location2.X, location2.Y, location2.Z);
				}
				MotorAnimationSyncComponent.WheelInfosRef = MotorAnimationSyncComponent.WheelInfos;
				this.VehicleMovement.SetSimulatedMotorWheelInfos(ref MotorAnimationSyncComponent.WheelInfosRef);
				MotorAnimationSyncComponent.WheelInfosRef = null;
				VehiclePerformComponent vehiclePerformComponent = this.VehiclePerformComponent;
				vehiclePerformComponent.IsBeingImpacted = motorAnimInfo.IsBeingImpacted;
				if (motorAnimInfo.IsBeingImpacted && Singleton<Time>.Instance.NowSeconds - this.LastReplayBeingImpactedTime >= 1.0)
				{
					this.LastReplayBeingImpactedTime = Singleton<Time>.Instance.NowSeconds;
					VehiclePerformComponent vehiclePerformComponent2 = vehiclePerformComponent;
					Aki.Protocol.Vector impactedVelocity = motorAnimInfo.ImpactedVelocity;
					float velocityX = (impactedVelocity != null) ? impactedVelocity.X : 0f;
					Aki.Protocol.Vector impactedVelocity2 = motorAnimInfo.ImpactedVelocity;
					float velocityY = (impactedVelocity2 != null) ? impactedVelocity2.Y : 0f;
					Aki.Protocol.Vector impactedVelocity3 = motorAnimInfo.ImpactedVelocity;
					float velocityZ = (impactedVelocity3 != null) ? impactedVelocity3.Z : 0f;
					Aki.Protocol.Vector impactedNormal = motorAnimInfo.ImpactedNormal;
					float normalX = (impactedNormal != null) ? impactedNormal.X : 0f;
					Aki.Protocol.Vector impactedNormal2 = motorAnimInfo.ImpactedNormal;
					float normalY = (impactedNormal2 != null) ? impactedNormal2.Y : 0f;
					Aki.Protocol.Vector impactedNormal3 = motorAnimInfo.ImpactedNormal;
					vehiclePerformComponent2.SimulatedImpactInfo(velocityX, velocityY, velocityZ, normalX, normalY, (impactedNormal3 != null) ? impactedNormal3.Z : 0f);
				}
				if (this.MotorAnimInstance == null)
				{
					this.MotorAnimInstance = (base.MainAnimInstance as ABP_Motor_BaseVehicle_C);
				}
				if (this.MotorAnimInstance != null && motorAnimInfo.MoveMix != null)
				{
					this.MotorAnimInstance.移动混合 = new FVector2D(motorAnimInfo.MoveMix.X, motorAnimInfo.MoveMix.Y);
				}
			}
		}

		// Token: 0x0602FB2D RID: 195373 RVA: 0x00B69AB6 File Offset: 0x00B67CB6
		public new static void CreateStaticDefaultValue()
		{
			MotorAnimationSyncComponent.WheelInfosRef = null;
			MotorAnimationSyncComponent.WheelInfos = null;
		}

		// Token: 0x0602FB2E RID: 195374 RVA: 0x00B69AC4 File Offset: 0x00B67CC4
		public new static void ResetStaticDefaultValue()
		{
			MotorAnimationSyncComponent.WheelInfosRef = null;
			MotorAnimationSyncComponent.WheelInfos = null;
		}

		// Token: 0x0602FB2F RID: 195375 RVA: 0x00B69AD4 File Offset: 0x00B67CD4
		public override bool ClearComponent(EntityComponent componentTemplate)
		{
			if (!base.ClearComponent(componentTemplate))
			{
				return false;
			}
			MotorAnimationSyncComponent motorAnimationSyncComponent = (MotorAnimationSyncComponent)componentTemplate;
			if (base.CanResetComponentProperty("VehicleMovement"))
			{
				if (motorAnimationSyncComponent.VehicleMovement == null)
				{
					this.VehicleMovement = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<UKuroVehicleMovementComponent>(this.VehicleMovement), "VehicleMovement"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("VehiclePerformComponent"))
			{
				if (motorAnimationSyncComponent.VehiclePerformComponent == null)
				{
					this.VehiclePerformComponent = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<VehiclePerformComponent>(this.VehiclePerformComponent), "VehiclePerformComponent"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("PendingAnimInfos"))
			{
				if (motorAnimationSyncComponent.PendingAnimInfos == null)
				{
					this.PendingAnimInfos = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<List<MotorAnimInfo>>(this.PendingAnimInfos), "PendingAnimInfos"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("ReplaySampleQueue") && motorAnimationSyncComponent.ReplaySampleQueue != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Deque<MotorAnimInfo>>(this.ReplaySampleQueue), "ReplaySampleQueue"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("MotorAnimInstance"))
			{
				if (motorAnimationSyncComponent.MotorAnimInstance == null)
				{
					this.MotorAnimInstance = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<ABP_Motor_BaseVehicle_C>(this.MotorAnimInstance), "MotorAnimInstance"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("LastPendingTime"))
			{
				this.LastPendingTime = motorAnimationSyncComponent.LastPendingTime;
			}
			if (base.CanResetComponentProperty("LastSyncImpactTime"))
			{
				this.LastSyncImpactTime = motorAnimationSyncComponent.LastSyncImpactTime;
			}
			if (base.CanResetComponentProperty("LastReplayBeingImpactedTime"))
			{
				this.LastReplayBeingImpactedTime = motorAnimationSyncComponent.LastReplayBeingImpactedTime;
			}
			if (base.CanResetComponentProperty("LastBeingImpacted"))
			{
				this.LastBeingImpacted = motorAnimationSyncComponent.LastBeingImpacted;
			}
			return true;
		}

		// Token: 0x0401B526 RID: 111910
		private const float ANIMSYNCUDPSENDINTERVAL = 0.1f;

		// Token: 0x0401B527 RID: 111911
		private const float COLLISIONANIMSYNCUDPSENDINTERVAL = 1f;

		// Token: 0x0401B528 RID: 111912
		private const float ANIM_SYNC_IMPACT_INTERVAL = 0.1f;

		// Token: 0x0401B529 RID: 111913
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private static TArray<FMotorWheelDisplayInfo> WheelInfosRef;

		// Token: 0x0401B52A RID: 111914
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private static TArray<FMotorWheelDisplayInfo> WheelInfos;

		// Token: 0x0401B52B RID: 111915
		[Nullable(2)]
		public UKuroVehicleMovementComponent VehicleMovement;

		// Token: 0x0401B52C RID: 111916
		[Nullable(2)]
		private VehiclePerformComponent VehiclePerformComponent;

		// Token: 0x0401B52D RID: 111917
		public List<MotorAnimInfo> PendingAnimInfos = new List<MotorAnimInfo>();

		// Token: 0x0401B52E RID: 111918
		private readonly Deque<MotorAnimInfo> ReplaySampleQueue = new Deque<MotorAnimInfo>(4);

		// Token: 0x0401B52F RID: 111919
		[Nullable(2)]
		private ABP_Motor_BaseVehicle_C MotorAnimInstance;

		// Token: 0x0401B530 RID: 111920
		private double LastPendingTime;

		// Token: 0x0401B531 RID: 111921
		private double LastSyncImpactTime;

		// Token: 0x0401B532 RID: 111922
		private double LastReplayBeingImpactedTime;

		// Token: 0x0401B533 RID: 111923
		private bool LastBeingImpacted;
	}
}
