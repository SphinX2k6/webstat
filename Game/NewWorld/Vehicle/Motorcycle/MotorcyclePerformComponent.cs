using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol.Summon;
using AkiClient.Game.Aki.Character.Vehicle.Motor;
using AkiClient.Game.Aki.Data.Level.Vehicle;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.Manager;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.NewWorld.Character.Common.Component.Abilities.Follow;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.Vehicle.Motorcycle
{
	// Token: 0x020047A8 RID: 18344
	[NullableContext(1)]
	[Nullable(0)]
	public class MotorcyclePerformComponent : VehiclePerformComponent, IStaticVariableResetter
	{
		// Token: 0x0602F9AA RID: 194986 RVA: 0x00B5B0BD File Offset: 0x00B592BD
		static MotorcyclePerformComponent()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(MotorcyclePerformComponent.CreateStaticDefaultValue), new Action(MotorcyclePerformComponent.ResetStaticDefaultValue));
		}

		// Token: 0x170081B2 RID: 33202
		// (get) Token: 0x0602F9AB RID: 194987 RVA: 0x00B5B0EB File Offset: 0x00B592EB
		// (set) Token: 0x0602F9AC RID: 194988 RVA: 0x00B5B0F4 File Offset: 0x00B592F4
		protected bool DrivingBuffActivating
		{
			get
			{
				return this.DrivingBuffActivatingInternal;
			}
			set
			{
				if (this.DrivingBuffActivatingInternal == value)
				{
					return;
				}
				this.DrivingBuffActivatingInternal = value;
				VehicleActorComponent actorComp = this.ActorComp;
				if (actorComp == null || !actorComp.IsAutonomousProxy)
				{
					return;
				}
				if (value)
				{
					using (List<long>.Enumerator enumerator = this.DrivingBuffs.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							long buffId = enumerator.Current;
							VehicleBuffComponent buffComp = this.BuffComp;
							if (buffComp != null)
							{
								buffComp.AddBuff(buffId, new AddBuffParam
								{
									InstigatorId = this.BuffComp.CreatureDataId,
									Reason = "常驻buffs"
								});
							}
						}
						return;
					}
				}
				foreach (long buffId2 in this.DrivingBuffs)
				{
					VehicleBuffComponent buffComp2 = this.BuffComp;
					if (buffComp2 != null)
					{
						buffComp2.RemoveBuff(buffId2, -1, "常驻buffs", null, null, null);
					}
				}
			}
		}

		// Token: 0x170081B3 RID: 33203
		// (get) Token: 0x0602F9AD RID: 194989 RVA: 0x00B5B210 File Offset: 0x00B59410
		// (set) Token: 0x0602F9AE RID: 194990 RVA: 0x00B5B218 File Offset: 0x00B59418
		protected int Hour
		{
			get
			{
				return this.HourInternal;
			}
			set
			{
				if (this.HourInternal == value)
				{
					return;
				}
				this.HourInternal = value;
				if (value < 0)
				{
					this.CurrentHourEffect = 0L;
					return;
				}
				foreach (ValueTuple<float, long> valueTuple in this.DayTimeBuffs)
				{
					float item = valueTuple.Item1;
					long item2 = valueTuple.Item2;
					if ((float)value < item)
					{
						this.CurrentHourEffect = item2;
						break;
					}
				}
			}
		}

		// Token: 0x170081B4 RID: 33204
		// (get) Token: 0x0602F9AF RID: 194991 RVA: 0x00B5B29C File Offset: 0x00B5949C
		// (set) Token: 0x0602F9B0 RID: 194992 RVA: 0x00B5B2A4 File Offset: 0x00B594A4
		protected long CurrentHourEffect
		{
			get
			{
				return this.CurrentHourEffectInternal;
			}
			set
			{
				if (this.CurrentHourEffectInternal == value)
				{
					return;
				}
				if (this.CurrentHourEffectInternal > 0L)
				{
					VehicleBuffComponent buffComp = this.BuffComp;
					if (buffComp != null)
					{
						buffComp.RemoveBuff(this.CurrentHourEffectInternal, -1, "时间buff", null, null, null);
					}
				}
				this.CurrentHourEffectInternal = value;
				if (this.CurrentHourEffectInternal > 0L)
				{
					VehicleBuffComponent buffComp2 = this.BuffComp;
					if (buffComp2 == null)
					{
						return;
					}
					buffComp2.AddBuff(this.CurrentHourEffectInternal, new AddBuffParam
					{
						InstigatorId = this.BuffComp.CreatureDataId,
						Reason = "时间buff"
					});
				}
			}
		}

		// Token: 0x170081B5 RID: 33205
		// (get) Token: 0x0602F9B1 RID: 194993 RVA: 0x00B5B345 File Offset: 0x00B59545
		public float LaunchSpeedFadeTime
		{
			get
			{
				return this.LaunchSpeedFadeTimeInternal;
			}
		}

		// Token: 0x170081B6 RID: 33206
		// (get) Token: 0x0602F9B2 RID: 194994 RVA: 0x00B5B34D File Offset: 0x00B5954D
		public float LaunchVehicleSpeedAddRatio
		{
			get
			{
				return this.LaunchVehicleSpeedAddRatioInternal;
			}
		}

		// Token: 0x170081B7 RID: 33207
		// (get) Token: 0x0602F9B3 RID: 194995 RVA: 0x00B5B355 File Offset: 0x00B59555
		[Nullable(2)]
		public UCurveFloat LaunchSpeedFadeCurve
		{
			[NullableContext(2)]
			get
			{
				return this.LaunchSpeedFadeCurveInternal;
			}
		}

		// Token: 0x0602F9B4 RID: 194996 RVA: 0x00B5B360 File Offset: 0x00B59560
		protected override bool OnStart()
		{
			bool result = base.OnStart();
			this.BuffComp = base.Entity.GetComponent<VehicleBuffComponent>();
			this.InitMotorcycleDither();
			BaseVehiclePerformComponent component = base.Entity.GetComponent<BaseVehiclePerformComponent>();
			object obj;
			if (component == null)
			{
				obj = null;
			}
			else
			{
				VehicleConfig config = component.Config;
				obj = ((config != null) ? config.Asset : null);
			}
			BP_MotorConfig_C bp_MotorConfig_C = obj as BP_MotorConfig_C;
			if (bp_MotorConfig_C == null)
			{
				return result;
			}
			TArray<long> 常驻buffs = bp_MotorConfig_C.常驻buffs;
			this.DrivingBuffs.Clear();
			for (int i = 常驻buffs.Num() - 1; i >= 0; i--)
			{
				this.DrivingBuffs.Add(常驻buffs.Get(i));
			}
			this.HitBuffMap.Clear();
			foreach (KeyValuePair<EMotorPart, long> keyValuePair in bp_MotorConfig_C.撞击buff)
			{
				EMotorPart emotorPart;
				long num;
				keyValuePair.Deconstruct(out emotorPart, out num);
				EMotorPart key = emotorPart;
				long value = num;
				this.HitBuffMap[key] = value;
			}
			this.DayTimeBuffs.Clear();
			foreach (SFloatThresholdAndBuff sfloatThresholdAndBuff in bp_MotorConfig_C.时段buff)
			{
				this.DayTimeBuffs.Add(new ValueTuple<float, long>(sfloatThresholdAndBuff.Threshold, sfloatThresholdAndBuff.BuffId));
			}
			this.OverlapSmallObjectEffectBuff = bp_MotorConfig_C.和小物件重合时的特效Buff;
			this.LaunchSpeedFadeTimeInternal = bp_MotorConfig_C.叠加速度衰减时间;
			this.LaunchSpeedFadeCurveInternal = bp_MotorConfig_C.叠加速度衰减曲线;
			this.LaunchVehicleSpeedAddRatioInternal = bp_MotorConfig_C.载具速度叠加比例;
			Singleton<EventSystem>.Instance.AddWithTarget<VehiclePassengerInfo, bool>(base.Entity, EEventName.OnVehicleBeenEntered, new Action<VehiclePassengerInfo, bool>(this.OnVehicleBeenEntered));
			Singleton<EventSystem>.Instance.AddWithTarget<VehiclePassengerInfo, bool>(base.Entity, EEventName.OnVehicleBeenLeaved, new Action<VehiclePassengerInfo, bool>(this.OnVehicleBeenLeaved));
			return result;
		}

		// Token: 0x0602F9B5 RID: 194997 RVA: 0x00B5B538 File Offset: 0x00B59738
		protected override bool OnEnd()
		{
			Singleton<EventSystem>.Instance.RemoveWithTarget<VehiclePassengerInfo, bool>(base.Entity, EEventName.OnVehicleBeenEntered, new Action<VehiclePassengerInfo, bool>(this.OnVehicleBeenEntered));
			Singleton<EventSystem>.Instance.RemoveWithTarget<VehiclePassengerInfo, bool>(base.Entity, EEventName.OnVehicleBeenLeaved, new Action<VehiclePassengerInfo, bool>(this.OnVehicleBeenLeaved));
			return base.OnEnd();
		}

		// Token: 0x0602F9B6 RID: 194998 RVA: 0x00B5B58F File Offset: 0x00B5978F
		private void OnVehicleBeenEntered(VehiclePassengerInfo _, bool byChangeRole)
		{
			this.DrivingBuffActivating = true;
		}

		// Token: 0x0602F9B7 RID: 194999 RVA: 0x00B5B598 File Offset: 0x00B59798
		private void OnVehicleBeenLeaved(VehiclePassengerInfo _, bool byChangeRole)
		{
			if (byChangeRole)
			{
				return;
			}
			this.DrivingBuffActivating = false;
		}

		// Token: 0x0602F9B8 RID: 195000 RVA: 0x00B5B5A8 File Offset: 0x00B597A8
		protected override void OnTick(float delta)
		{
			base.OnTick(delta);
			if (base.Driver != null && ModelBase<TimeOfDayModel>.Instance != null)
			{
				this.Hour = (int)Math.Floor(ModelBase<TimeOfDayModel>.Instance.GameTime.Hour);
			}
			else
			{
				this.Hour = -1;
			}
			this.HandlePendingDitherActor();
			this.HandleSmallItemTrace();
			if (this.NextResetSeatTransTime < Singleton<Time>.Instance.Now)
			{
				this.NextResetSeatTransTime = Singleton<Time>.Instance.Now + 3000.0;
				foreach (KeyValuePair<int, VehiclePassengerInfo> keyValuePair in this.PassengerInfoMap)
				{
					int num;
					VehiclePassengerInfo vehiclePassengerInfo;
					keyValuePair.Deconstruct(out num, out vehiclePassengerInfo);
					VehiclePassengerInfo vehiclePassengerInfo2 = vehiclePassengerInfo;
					Entity passengerEntity = vehiclePassengerInfo2.PassengerEntity;
					UeMovementTickManageComponent ueMovementTickManageComponent = (passengerEntity != null) ? passengerEntity.GetComponent<UeMovementTickManageComponent>() : null;
					if (ueMovementTickManageComponent == null || !ueMovementTickManageComponent.Active)
					{
						Entity passengerEntity2 = vehiclePassengerInfo2.PassengerEntity;
						CharacterDriveVehicleComponent characterDriveVehicleComponent = (passengerEntity2 != null) ? passengerEntity2.GetComponent<CharacterDriveVehicleComponent>() : null;
						if (characterDriveVehicleComponent != null)
						{
							characterDriveVehicleComponent.MotorCheckAndResetRelativeTransform();
						}
					}
				}
			}
		}

		// Token: 0x0602F9B9 RID: 195001 RVA: 0x00B5B6B8 File Offset: 0x00B598B8
		protected override void OnSetDriver()
		{
			base.OnSetDriver();
			VehicleAnimationComponent animComp = this.AnimComp;
			if (((animComp != null) ? animComp.MainAnimInstance : null) != null && this.AnimComp.MainAnimInstance is UKuroAnimInstanceVehicle)
			{
				Entity driverInternal = this.DriverInternal;
				CharacterActorComponent characterActorComponent = (driverInternal != null) ? driverInternal.GetComponent<CharacterActorComponent>() : null;
				((UKuroAnimInstanceVehicle)this.AnimComp.MainAnimInstance).SetDriver((characterActorComponent != null) ? characterActorComponent.Actor : null);
				((UKuroAnimInstanceVehicle)this.AnimComp.MainAnimInstance).ConsumeExtractedRootMotion(1f);
			}
			if (base.Driver == null)
			{
				this.SetNoDriverFrame = Singleton<Time>.Instance.Frame;
				return;
			}
			if (Singleton<Time>.Instance.Frame == this.SetNoDriverFrame)
			{
				return;
			}
			VehicleActorComponent actorComp = this.ActorComp;
			UKuroVehicleMovementComponent ukuroVehicleMovementComponent = (actorComp != null) ? actorComp.Actor.VehicleMovementComponent : null;
			if (ukuroVehicleMovementComponent != null)
			{
				ukuroVehicleMovementComponent.Velocity = global::Vector.ZeroVector;
				ukuroVehicleMovementComponent.SetMotorRotateSpeed(global::Vector.ZeroVector, 0f);
			}
			VehicleActorComponent actorComp2 = this.ActorComp;
			if (actorComp2 == null)
			{
				return;
			}
			UKuroVehicleMovementComponent vehicleMovementComponent = actorComp2.Actor.VehicleMovementComponent;
			if (vehicleMovementComponent == null)
			{
				return;
			}
			vehicleMovementComponent.ResetMotorcycle();
		}

		// Token: 0x0602F9BA RID: 195002 RVA: 0x00B5B7C4 File Offset: 0x00B599C4
		protected void RefreshSummonedEntity(VehiclePassengerInfo info, bool isEnter)
		{
			EntityHandle summonedEntity = PhantomUtil.GetSummonedEntity(base.Entity, ESummonType.ConcomitantMotorcycle, 1);
			if (summonedEntity == null)
			{
				return;
			}
			Entity passengerEntity = info.PassengerEntity;
			int? num;
			if (passengerEntity == null)
			{
				num = null;
			}
			else
			{
				CreatureDataComponent creatureDataComponent = passengerEntity.CheckGetComponent<CreatureDataComponent>();
				num = ((creatureDataComponent != null) ? new int?(creatureDataComponent.GetPlayerId()) : null);
			}
			int? num2 = num;
			if (num2 != null)
			{
				int? num3 = num2;
				int num4 = 0;
				if (!(num3.GetValueOrDefault() <= num4 & num3 != null))
				{
					WorldEntity playerEntity = ControllerBase<FormationDataController>.Instance.GetPlayerEntity(num2.Value);
					PlayerFollowableComponent playerFollowableComponent = (playerEntity != null) ? playerEntity.CheckGetComponent<PlayerFollowableComponent>() : null;
					if (playerFollowableComponent == null)
					{
						return;
					}
					playerFollowableComponent.UpdatePlayerFollowers(new PlayerFollowerItemInfo[]
					{
						new PlayerFollowerItemInfo
						{
							Type = 666,
							EntityId = (isEnter ? summonedEntity.CreatureDataId : 0L)
						}
					});
					return;
				}
			}
		}

		// Token: 0x0602F9BB RID: 195003 RVA: 0x00B5B88F File Offset: 0x00B59A8F
		protected override void EnterVehiclePerform(VehiclePassengerInfo info)
		{
			base.EnterVehiclePerform(info);
			this.RefreshSummonedEntity(info, true);
			this.SetDitherEnable(info, true);
		}

		// Token: 0x0602F9BC RID: 195004 RVA: 0x00B5B8A8 File Offset: 0x00B59AA8
		protected override void LeaveVehiclePerform(VehiclePassengerInfo info)
		{
			base.LeaveVehiclePerform(info);
			this.SetDitherEnable(info, false);
			this.RefreshSummonedEntity(info, false);
		}

		// Token: 0x0602F9BD RID: 195005 RVA: 0x00B5B8C4 File Offset: 0x00B59AC4
		protected override void OnHit(FHitResult hitResult)
		{
			base.OnHit(hitResult);
			VehicleActorComponent actorComp = this.ActorComp;
			UKuroVehicleMovementComponent ukuroVehicleMovementComponent = (actorComp != null) ? actorComp.Actor.VehicleMovementComponent : null;
			if (ukuroVehicleMovementComponent == null)
			{
				return;
			}
			EMotorPart lastMotorHitPart = ukuroVehicleMovementComponent.LastMotorHitPart;
			long num2;
			long num = this.HitBuffMap.TryGetValue(ukuroVehicleMovementComponent.LastMotorHitPart, out num2) ? num2 : 0L;
			if (num > 0L)
			{
				VehicleBuffComponent buffComp = this.BuffComp;
				if (buffComp != null)
				{
					buffComp.AddBuff(num, new AddBuffParam
					{
						InstigatorId = this.BuffComp.CreatureDataId,
						Reason = "撞击buff"
					});
				}
				Singleton<EventSystem>.Instance.EmitWithTarget<EMotorPart, FHitResult>(base.Entity, EEventName.MotorOnHit, ukuroVehicleMovementComponent.LastMotorHitPart, hitResult);
			}
		}

		// Token: 0x0602F9BE RID: 195006 RVA: 0x00B5B96C File Offset: 0x00B59B6C
		protected unsafe void SetDitherEnable(VehiclePassengerInfo info, bool enable)
		{
			if (this.EnableDither == enable)
			{
				return;
			}
			this.EnableDither = enable;
			this.SetDitherCollisionEnable(enable);
			if (!enable)
			{
				this.ResetAllPendingDitherActor();
				this.PendingSmallItemComponents.Clear();
				this.ApplySmallItemComponents();
			}
			CreatureDataComponent creatureData = this.CreatureData;
			long? num = (creatureData != null) ? new long?(creatureData.GetCreatureDataId()) : null;
			Entity passengerEntity = info.PassengerEntity;
			long? num2;
			if (passengerEntity == null)
			{
				num2 = null;
			}
			else
			{
				CreatureDataComponent creatureDataComponent = passengerEntity.CheckGetComponent<CreatureDataComponent>();
				num2 = ((creatureDataComponent != null) ? new long?(creatureDataComponent.GetCreatureDataId()) : null);
			}
			long? num3 = num2;
			if (num != null)
			{
				long? num4 = num;
				long num5 = 0L;
				if ((num4.GetValueOrDefault() > num5 & num4 != null) && num3 != null)
				{
					num4 = num3;
					num5 = 0L;
					if (num4.GetValueOrDefault() > num5 & num4 != null)
					{
						if (enable)
						{
							ModelBase<CameraModel>.Instance.MainModel.DitherEntityGroups.Union(num.Value, num3.Value);
							VehicleActorComponent vehicleActorComponent = base.Entity.CheckGetComponent<VehicleActorComponent>();
							double? num6;
							if (vehicleActorComponent == null)
							{
								num6 = null;
							}
							else
							{
								TsBaseVehicle actor = vehicleActorComponent.Actor;
								if (actor == null)
								{
									num6 = null;
								}
								else
								{
									CharacterDitherEffectController ditherEffectController = actor.DitherEffectController;
									num6 = ((ditherEffectController != null) ? new double?(ditherEffectController.CurrentDitherValue) : null);
								}
							}
							double? num7 = num6;
							if (num7 == null)
							{
								return;
							}
							Entity passengerEntity2 = info.PassengerEntity;
							if (passengerEntity2 == null)
							{
								return;
							}
							CharacterActorComponent characterActorComponent = passengerEntity2.CheckGetComponent<CharacterActorComponent>();
							if (characterActorComponent == null)
							{
								return;
							}
							TsBaseCharacter actor2 = characterActorComponent.Actor;
							if (actor2 == null)
							{
								return;
							}
							actor2.SetDitherEffect((float)num7.Value, ECharacterDitherType.Fight);
							return;
						}
						else
						{
							DisjointSet<long> ditherEntityGroups = ModelBase<CameraModel>.Instance.MainModel.DitherEntityGroups;
							if (ditherEntityGroups != null)
							{
								ditherEntityGroups.Delete(num.Value);
							}
							DisjointSet<long> ditherEntityGroups2 = ModelBase<CameraModel>.Instance.MainModel.DitherEntityGroups;
							if (ditherEntityGroups2 == null)
							{
								return;
							}
							ditherEntityGroups2.Delete(num3.Value);
							return;
						}
					}
				}
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Vehicle;
			ELogAuthor author = ELogAuthor.XDW;
			string message = "MotorcyclePerformComponent.SetDitherEnable: 载具或乘客不存在";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("vehicleCreatureDataId", ((num != null) ? num.GetValueOrDefault().ToString() : null) ?? "null");
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("passengerCreatureDataId", ((num3 != null) ? num3.GetValueOrDefault().ToString() : null) ?? "null");
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}

		// Token: 0x0602F9BF RID: 195007 RVA: 0x00B5BBE8 File Offset: 0x00B59DE8
		protected void SetDitherCollisionEnable(bool enable)
		{
			VehicleActorComponent actorComp = this.ActorComp;
			BP_Motor_BaseVehicle_C bp_Motor_BaseVehicle_C = ((actorComp != null) ? actorComp.Owner : null) as BP_Motor_BaseVehicle_C;
			if (bp_Motor_BaseVehicle_C == null)
			{
				return;
			}
			ECollisionEnabled collisionEnabled = enable ? ECollisionEnabled.QueryOnly : ECollisionEnabled.NoCollision;
			UCapsuleComponent capsuleForDither = bp_Motor_BaseVehicle_C.CapsuleForDither;
			if (capsuleForDither != null)
			{
				capsuleForDither.SetCollisionEnabled(collisionEnabled);
			}
			UCapsuleComponent capsuleForDither2 = bp_Motor_BaseVehicle_C.CapsuleForDither;
			if (capsuleForDither2 == null)
			{
				return;
			}
			capsuleForDither2.SetGenerateOverlapEvents(enable);
		}

		// Token: 0x0602F9C0 RID: 195008 RVA: 0x00B5BC3C File Offset: 0x00B59E3C
		protected void InitMotorcycleDither()
		{
			VehicleActorComponent actorComp = this.ActorComp;
			BP_Motor_BaseVehicle_C bp_Motor_BaseVehicle_C = ((actorComp != null) ? actorComp.Owner : null) as BP_Motor_BaseVehicle_C;
			if (bp_Motor_BaseVehicle_C == null)
			{
				return;
			}
			UCapsuleComponent capsuleForDither = bp_Motor_BaseVehicle_C.CapsuleForDither;
			if (capsuleForDither != null)
			{
				capsuleForDither.OnComponentBeginOverlap.Add(new Action<UPrimitiveComponent, AActor, UPrimitiveComponent, int, bool, FHitResult>(this.OnComponentBeginOverlap));
			}
			this.DitherCapsuleHalfHeight = bp_Motor_BaseVehicle_C.CapsuleForDither.CapsuleHalfHeight;
			this.DitherCapsuleRadius = bp_Motor_BaseVehicle_C.CapsuleForDither.CapsuleRadius;
			this.DitherDepthCurve = bp_Motor_BaseVehicle_C.深度虚化值曲线;
			this.DitherNpcRadius = Math.Max(20f, Math.Min(bp_Motor_BaseVehicle_C.虚化碰撞NPC半径, 200f));
			Transform tmpTrans = this.TmpTrans1;
			FTransformDouble ftransformDouble = this.ActorComp.ActorTransform;
			tmpTrans.FromUeTransform(ftransformDouble);
			Transform tmpTrans2 = this.TmpTrans2;
			ftransformDouble = bp_Motor_BaseVehicle_C.CapsuleForDither.D_K2_GetComponentToWorld();
			tmpTrans2.FromUeTransform(ftransformDouble);
			Transform ditherCapsuleRelativeTrans = this.DitherCapsuleRelativeTrans;
			ftransformDouble = this.TmpTrans2.ToUeTransform();
			FTransformDouble ftransformDouble2 = this.TmpTrans1.ToUeTransform();
			ftransformDouble = ftransformDouble.GetRelativeTransform(ftransformDouble2);
			ditherCapsuleRelativeTrans.FromUeTransform(ftransformDouble);
			double num = (double)(this.DitherNpcRadius + this.DitherCapsuleHalfHeight) / (double)this.DitherCapsuleHalfHeight;
			double num2 = (double)(this.DitherNpcRadius + this.DitherCapsuleRadius) / (double)this.DitherCapsuleRadius;
			this.TmpVector1.Set((double)((float)num2), (double)((float)num2), (double)((float)num));
			bp_Motor_BaseVehicle_C.CapsuleForDither.SetWorldScale3D(this.TmpVector1.ToUeVectorOld());
			float num3 = this.DitherCapsuleHalfHeight + this.DitherNpcRadius + 100f;
			this.DitherRemoveDistSquared = Math.Max(this.DitherRemoveDistSquared, num3 * num3);
		}

		// Token: 0x0602F9C1 RID: 195009 RVA: 0x00B5BDBC File Offset: 0x00B59FBC
		[NullableContext(2)]
		protected void OnComponentBeginOverlap(UPrimitiveComponent overlappedComponent, AActor otherActor, UPrimitiveComponent otherComp, int otherBodyIndex, bool bFromSweep, [Nullable(1)] FHitResult sweepResult)
		{
			TsBaseCharacter tsBaseCharacter = otherActor as TsBaseCharacter;
			if (tsBaseCharacter == null)
			{
				return;
			}
			Entity entityNoBlueprint = tsBaseCharacter.GetEntityNoBlueprint();
			CreatureDataComponent creatureDataComponent = (entityNoBlueprint != null) ? entityNoBlueprint.GetComponent<CreatureDataComponent>() : null;
			if ((creatureDataComponent == null || !creatureDataComponent.IsNpc()) && (creatureDataComponent == null || !creatureDataComponent.IsAnimal()))
			{
				return;
			}
			this.PendingDitherActorSet.Add(tsBaseCharacter);
		}

		// Token: 0x0602F9C2 RID: 195010 RVA: 0x00B5BE18 File Offset: 0x00B5A018
		private void InitSmallItemTraceElement()
		{
			if (this.SmallItemTraceElement != null)
			{
				return;
			}
			this.SmallItemTraceElement = new UTraceCapsuleElement();
			this.SmallItemTraceElement.bIsSingle = false;
			this.SmallItemTraceElement.bIgnoreSelf = true;
			this.SmallItemTraceElement.WorldContextObject = this.ActorComp.Owner;
			this.SmallItemTraceElement.ActorsToIgnore.Add(this.ActorComp.Actor);
			this.SmallItemTraceElement.SetTraceTypeQuery(KuroTraceTypeQuery.IkGround);
			this.SmallItemTraceElement.Radius = this.DitherCapsuleRadius;
			this.SmallItemTraceElement.HalfHeight = this.DitherCapsuleHalfHeight;
		}

		// Token: 0x0602F9C3 RID: 195011 RVA: 0x00B5BEB4 File Offset: 0x00B5A0B4
		private void HandleSmallItemTrace()
		{
			if (this.OverlapSmallObjectEffectBuff <= 0L || !this.EnableDither)
			{
				return;
			}
			VehicleMoveComponent moveComp = this.MoveComp;
			if (((moveComp != null) ? moveComp.Speed : 0f) >= 1000f)
			{
				this.PendingSmallItemComponents.Clear();
				this.ApplySmallItemComponents();
				return;
			}
			if (Singleton<Time>.Instance.Now < this.NextSmallItemTraceTime)
			{
				return;
			}
			this.NextSmallItemTraceTime = Singleton<Time>.Instance.Now + 500.0;
			this.InitSmallItemTraceElement();
			this.CalculateCapsuleTransform();
			global::Vector location = this.TmpTrans2.GetLocation();
			Singleton<TraceElementCommon>.Instance.SetStartLocation(this.SmallItemTraceElement, location);
			Singleton<TraceElementCommon>.Instance.SetEndLocation(this.SmallItemTraceElement, location);
			Singleton<TraceElementCommon>.Instance.SetCapsuleOrientation(this.SmallItemTraceElement, this.TmpTrans2.GetRotation().Rotator(null));
			bool flag = Singleton<TraceElementCommon>.Instance.CapsuleTrace(this.SmallItemTraceElement, "MotorcycleSmallItemTrace");
			this.PendingSmallItemComponents.Clear();
			if (flag)
			{
				UKuroHitResult hitResult = this.SmallItemTraceElement.HitResult;
				int hitCount = hitResult.GetHitCount();
				for (int i = 0; i < hitCount; i++)
				{
					UPrimitiveComponent uprimitiveComponent = hitResult.Components.Get(i).Get();
					bool flag2 = uprimitiveComponent != null && uprimitiveComponent.IsValid() && uprimitiveComponent.ComponentHasTag(MotorcyclePerformComponent.SmallItemTag);
					if (!flag2 && uprimitiveComponent != null && uprimitiveComponent.IsValid() && uprimitiveComponent is UCollisionClusterComponent)
					{
						flag2 = UKuroCollisionLibrary.ActorHasTag(uprimitiveComponent.GetOwner(), MotorcyclePerformComponent.SmallItemTag, hitResult.ItemArray.Get(i));
					}
					if (flag2 && uprimitiveComponent != null && uprimitiveComponent.IsA(UStaticMeshComponent.StaticClass()))
					{
						this.PendingSmallItemComponents.Add(uprimitiveComponent as UStaticMeshComponent);
					}
				}
			}
			this.ApplySmallItemComponents();
		}

		// Token: 0x0602F9C4 RID: 195012 RVA: 0x00B5C074 File Offset: 0x00B5A274
		private void ApplySmallItemComponents()
		{
			foreach (UStaticMeshComponent ustaticMeshComponent in this.PendingSmallItemComponents)
			{
				if (!this.DetectedSmallItemComponents.Contains(ustaticMeshComponent))
				{
					ControllerBase<SceneOpacityController>.Instance.SetOpacity(ustaticMeshComponent, base.Entity.Id, true);
				}
			}
			foreach (UStaticMeshComponent ustaticMeshComponent2 in this.DetectedSmallItemComponents)
			{
				if (!this.PendingSmallItemComponents.Contains(ustaticMeshComponent2))
				{
					ControllerBase<SceneOpacityController>.Instance.SetOpacity(ustaticMeshComponent2, base.Entity.Id, false);
				}
			}
			HashSet<UStaticMeshComponent> detectedSmallItemComponents = this.DetectedSmallItemComponents;
			this.DetectedSmallItemComponents = this.PendingSmallItemComponents;
			this.PendingSmallItemComponents = detectedSmallItemComponents;
		}

		// Token: 0x0602F9C5 RID: 195013 RVA: 0x00B5C160 File Offset: 0x00B5A360
		protected void HandlePendingDitherActor()
		{
			if (this.PendingDitherActorSet.Count <= 0)
			{
				return;
			}
			this.CalculateCapsuleTransform();
			List<TsBaseCharacter> list = new List<TsBaseCharacter>();
			foreach (TsBaseCharacter tsBaseCharacter in this.PendingDitherActorSet)
			{
				if (!tsBaseCharacter.IsValid())
				{
					list.Add(tsBaseCharacter);
				}
				else
				{
					Entity entityNoBlueprint = tsBaseCharacter.GetEntityNoBlueprint();
					BaseCharacterComponent baseCharacterComponent = (entityNoBlueprint != null) ? entityNoBlueprint.GetComponent<BaseCharacterComponent>() : null;
					if (baseCharacterComponent == null || !baseCharacterComponent.Valid)
					{
						list.Add(tsBaseCharacter);
					}
					else
					{
						CharacterDriveVehicleComponent component = entityNoBlueprint.GetComponent<CharacterDriveVehicleComponent>();
						int? num;
						if (component == null)
						{
							num = null;
						}
						else
						{
							Entity vehicleEntity = component.VehicleEntity;
							num = ((vehicleEntity != null) ? new int?(vehicleEntity.Id) : null);
						}
						int? num2 = num;
						int id = base.Entity.Id;
						if (num2.GetValueOrDefault() == id & num2 != null)
						{
							list.Add(tsBaseCharacter);
							tsBaseCharacter.SetDitherEffect(1f, ECharacterDitherType.Fight);
						}
						else if (global::Vector.DistSquared(baseCharacterComponent.ActorLocationProxy, this.ActorComp.ActorLocationProxy) > (double)this.DitherRemoveDistSquared)
						{
							list.Add(tsBaseCharacter);
							tsBaseCharacter.SetDitherEffect(1f, ECharacterDitherType.Fight);
						}
						else
						{
							double num3 = this.CalcDitherValue(baseCharacterComponent);
							tsBaseCharacter.SetDitherEffect((float)num3, ECharacterDitherType.Fight);
						}
					}
				}
			}
			foreach (TsBaseCharacter item in list)
			{
				this.PendingDitherActorSet.Remove(item);
			}
		}

		// Token: 0x0602F9C6 RID: 195014 RVA: 0x00B5C32C File Offset: 0x00B5A52C
		protected double CalcDitherValue(BaseCharacterComponent otherActorComp)
		{
			double val = this.GetMinDistFromPointToCapsule(otherActorComp.ActorLocationProxy) - (double)this.DitherCapsuleRadius;
			double num = Singleton<MathUtils>.Instance.Clamp(Math.Max(0.0, val) / (double)this.DitherNpcRadius, 0.0, 1.0);
			if (this.DitherDepthCurve != null)
			{
				return (double)Singleton<MathUtils>.Instance.Clamp(this.DitherDepthCurve.GetFloatValue((float)num), 0f, 1f);
			}
			return num;
		}

		// Token: 0x0602F9C7 RID: 195015 RVA: 0x00B5C3B0 File Offset: 0x00B5A5B0
		protected void ResetAllPendingDitherActor()
		{
			foreach (TsBaseCharacter tsBaseCharacter in this.PendingDitherActorSet)
			{
				if (tsBaseCharacter.IsValid())
				{
					Entity entityNoBlueprint = tsBaseCharacter.GetEntityNoBlueprint();
					BaseCharacterComponent baseCharacterComponent = (entityNoBlueprint != null) ? entityNoBlueprint.GetComponent<BaseCharacterComponent>() : null;
					if (baseCharacterComponent != null && baseCharacterComponent.Valid)
					{
						tsBaseCharacter.SetDitherEffect(1f, ECharacterDitherType.Fight);
					}
				}
			}
			this.PendingDitherActorSet.Clear();
		}

		// Token: 0x0602F9C8 RID: 195016 RVA: 0x00B5C440 File Offset: 0x00B5A640
		protected void CalculateCapsuleTransform()
		{
			Transform tmpTrans = this.TmpTrans1;
			FTransformDouble actorTransform = this.ActorComp.ActorTransform;
			tmpTrans.FromUeTransform(actorTransform);
			this.DitherCapsuleRelativeTrans.ComposeTransforms(this.TmpTrans1, this.TmpTrans2);
			this.TmpVector2.DeepCopy(this.TmpTrans2.GetLocation());
			this.TmpTrans2.GetRotation().GetUpVector(this.TmpVector3);
			this.TmpVector3.MultiplyEqual((double)(this.DitherCapsuleHalfHeight - this.DitherCapsuleRadius));
			this.TmpVector2.Addition(this.TmpVector3, this.CapsulePointA);
			this.TmpVector2.Subtraction(this.TmpVector3, this.CapsulePointB);
			this.TryDebugDraw();
			Singleton<GravityUtils>.Instance.ConvertToPlanarVectorForActor(this.ActorComp, this.CapsulePointA);
			Singleton<GravityUtils>.Instance.ConvertToPlanarVectorForActor(this.ActorComp, this.CapsulePointB);
		}

		// Token: 0x0602F9C9 RID: 195017 RVA: 0x00B5C528 File Offset: 0x00B5A728
		protected double GetMinDistFromPointToCapsule(global::Vector otherLocation)
		{
			this.TmpVector1.DeepCopy(otherLocation);
			Singleton<GravityUtils>.Instance.ConvertToPlanarVectorForActor(this.ActorComp, this.TmpVector1);
			if (this.CapsulePointA.Equals(this.CapsulePointB, 9.999999747378752E-05))
			{
				return global::Vector.Dist(this.TmpVector1, this.CapsulePointA);
			}
			this.CapsulePointB.Subtraction(this.CapsulePointA, this.TmpVector3);
			this.TmpVector1.Subtraction(this.CapsulePointA, this.TmpVector5);
			double num = global::Vector.DotProduct(this.TmpVector3, this.TmpVector5) / this.TmpVector3.SizeSquared();
			if (num > 0.0 && num < 1.0)
			{
				this.TmpVector3.MultiplyEqual(num);
				this.TmpVector3.SubtractionEqual(this.TmpVector5);
				return this.TmpVector3.Size();
			}
			if (num > 0.0)
			{
				return global::Vector.Dist(this.TmpVector1, this.CapsulePointB);
			}
			return global::Vector.Dist(this.TmpVector1, this.CapsulePointA);
		}

		// Token: 0x0602F9CA RID: 195018 RVA: 0x00B5C648 File Offset: 0x00B5A848
		protected void TryDebugDraw()
		{
			if (!MotorcyclePerformComponent.DitherDebugMode)
			{
				return;
			}
			double num = (double)(this.DitherNpcRadius + this.DitherCapsuleHalfHeight) / (double)this.DitherCapsuleHalfHeight;
			double num2 = (double)(this.DitherNpcRadius + this.DitherCapsuleRadius) / (double)this.DitherCapsuleRadius;
			this.CapsulePointA.Addition(this.CapsulePointB, Singleton<MathUtils>.Instance.CommonTempVector);
			Singleton<MathUtils>.Instance.CommonTempVector.MultiplyEqual(0.5);
			VehicleActorComponent actorComp = this.ActorComp;
			UKismetSystemLibrary.D_DrawDebugCapsule((actorComp != null) ? actorComp.Actor : null, Singleton<MathUtils>.Instance.CommonTempVector.ToUeVector(false), this.DitherCapsuleHalfHeight, this.DitherCapsuleRadius, this.TmpTrans2.GetRotation().Rotator(null).ToUeRotator(), new FLinearColor?(new FLinearColor(1f, 0f, 0f, 1f)), 0f, 5f);
			VehicleActorComponent actorComp2 = this.ActorComp;
			UKismetSystemLibrary.D_DrawDebugCapsule((actorComp2 != null) ? actorComp2.Actor : null, Singleton<MathUtils>.Instance.CommonTempVector.ToUeVector(false), (float)((double)this.DitherCapsuleHalfHeight * num), (float)((double)this.DitherCapsuleRadius * num2), this.TmpTrans2.GetRotation().Rotator(null).ToUeRotator(), new FLinearColor?(new FLinearColor(0f, 1f, 0f, 1f)), 0f, 5f);
		}

		// Token: 0x0602F9CB RID: 195019 RVA: 0x00B5C7AC File Offset: 0x00B5A9AC
		protected override void OnAddTrialAttributeModifier(VehiclePassengerInfo info)
		{
			TrialMotor? trialMotorConfig = ConfigBase<MotorConfig>.Instance.GetTrialMotorConfig(this.TrialAttributeId.Value);
			if (trialMotorConfig == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Vehicle;
				ELogAuthor author = ELogAuthor.TZQ;
				string message = "无效的试用属性";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Id", this.TrialAttributeId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			if (trialMotorConfig.Value.TechTreeType == 1)
			{
				MotorcycleFreezeWaterComponent component = base.Entity.GetComponent<MotorcycleFreezeWaterComponent>();
				if (component != null)
				{
					component.SetIsFunctionOpenOverride(new bool?(true));
				}
				MotorcycleMoveComponent component2 = base.Entity.GetComponent<MotorcycleMoveComponent>();
				if (component2 != null)
				{
					component2.SetIsFunctionOpenOverride(new bool?(true));
				}
				BaseTagComponent component3 = base.Entity.GetComponent<BaseTagComponent>();
				if (component3 != null)
				{
					component3.AddTag(new int?(GameplayTagDefine.EGameplayTagId["载具.摩托.科技树.战斗相关.科技树3节点8"]));
				}
				if (component3 != null)
				{
					component3.AddTag(new int?(GameplayTagDefine.EGameplayTagId["载具.摩托.科技树.战斗相关.科技树3节点7"]));
				}
			}
			if (trialMotorConfig.Value.Level == 0)
			{
				return;
			}
			MotorLvl? motorLevelConfig = ConfigBase<MotorConfig>.Instance.GetMotorLevelConfig(trialMotorConfig.Value.Level);
			if (motorLevelConfig == null)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.Vehicle;
				ELogAuthor author2 = ELogAuthor.TZQ;
				string message2 = "无效的等级";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("Level", trialMotorConfig.Value.Level);
				instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				return;
			}
			Log instance3 = Singleton<Log>.Instance;
			ELogModule module3 = ELogModule.Vehicle;
			ELogAuthor author3 = ELogAuthor.TZQ;
			string message3 = "添加试用属性Modifier";
			ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("Level", this.TrialAttributeId);
			instance3.Info(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
			ControllerBase<FormationAttributeController>.Instance.AddSpeedModifier(this.ModifierKey, EFormationAttributeId.MotorcycleStrength, EModifierType.Override, (float)motorLevelConfig.Value.NitrogenRecoverRate, 1);
		}

		// Token: 0x0602F9CC RID: 195020 RVA: 0x00B5C974 File Offset: 0x00B5AB74
		protected override void OnRemoveTrialAttributeModifier(VehiclePassengerInfo info)
		{
			TrialMotor? trialMotorConfig = ConfigBase<MotorConfig>.Instance.GetTrialMotorConfig(this.TrialAttributeId.Value);
			if (trialMotorConfig != null && trialMotorConfig.GetValueOrDefault().TechTreeType == 1)
			{
				MotorcycleFreezeWaterComponent component = base.Entity.GetComponent<MotorcycleFreezeWaterComponent>();
				if (component != null)
				{
					component.SetIsFunctionOpenOverride(null);
				}
				MotorcycleMoveComponent component2 = base.Entity.GetComponent<MotorcycleMoveComponent>();
				if (component2 != null)
				{
					component2.SetIsFunctionOpenOverride(null);
				}
				BaseTagComponent component3 = base.Entity.GetComponent<BaseTagComponent>();
				if (component3 != null)
				{
					component3.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["载具.摩托.科技树.战斗相关.科技树3节点8"]));
				}
				if (component3 != null)
				{
					component3.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["载具.摩托.科技树.战斗相关.科技树3节点7"]));
				}
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Vehicle;
			ELogAuthor author = ELogAuthor.TZQ;
			string message = "移除试用属性Modifier";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Id", this.TrialAttributeId);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			ControllerBase<FormationAttributeController>.Instance.RemoveSpeedModifier(this.ModifierKey, EFormationAttributeId.MotorcycleStrength);
		}

		// Token: 0x0602F9CD RID: 195021 RVA: 0x00B5CA8A File Offset: 0x00B5AC8A
		[NullableContext(2)]
		public override void FixBornLocation(global::Vector target = null, string context = null)
		{
			base.FixBornLocation(null, "FixBornLocation");
			VehicleActorComponent actorComp = this.ActorComp;
			if (actorComp == null)
			{
				return;
			}
			actorComp.SetActorLocation(target.ToUeVector(false), context, false);
		}

		// Token: 0x0602F9CE RID: 195022 RVA: 0x00B5CAB4 File Offset: 0x00B5ACB4
		public override bool TryEnter(Entity entity, int seat)
		{
			bool flag = base.TryEnter(entity, seat);
			if (flag)
			{
				int id = entity.Id;
				TsBaseCharacter baseCharacter = Global.BaseCharacter;
				int? num = (baseCharacter != null) ? new int?(baseCharacter.GetEntityIdNoBlueprint()) : null;
				if (id == num.GetValueOrDefault() & num != null)
				{
					this.SendGetOnLogEvent(entity);
				}
			}
			return flag;
		}

		// Token: 0x0602F9CF RID: 195023 RVA: 0x00B5CB0C File Offset: 0x00B5AD0C
		public override int TryEnterAtOnce(Entity entity, int seat, string reason = "", bool notSync = false)
		{
			int num = base.TryEnterAtOnce(entity, seat, reason, notSync);
			if (num > 0)
			{
				int id = entity.Id;
				TsBaseCharacter baseCharacter = Global.BaseCharacter;
				int? num2 = (baseCharacter != null) ? new int?(baseCharacter.GetEntityIdNoBlueprint()) : null;
				if (id == num2.GetValueOrDefault() & num2 != null)
				{
					this.SendGetOnLogEvent(entity);
				}
			}
			return num;
		}

		// Token: 0x0602F9D0 RID: 195024 RVA: 0x00B5CB68 File Offset: 0x00B5AD68
		protected void SendGetOnLogEvent(Entity entity)
		{
			BaseActorComponent component = entity.GetComponent<BaseActorComponent>();
			if (component != null)
			{
				MotorSummonGetOnLogEvent motorSummonGetOnLogEvent = new MotorSummonGetOnLogEvent();
				motorSummonGetOnLogEvent.pos_x = (float)component.ActorLocationProxy.X;
				motorSummonGetOnLogEvent.pos_y = (float)component.ActorLocationProxy.Y;
				motorSummonGetOnLogEvent.pos_z = (float)component.ActorLocationProxy.Z;
				motorSummonGetOnLogEvent.operation_type = 2;
				ControllerBase<LogReportController>.Instance.LogReport(motorSummonGetOnLogEvent);
			}
		}

		// Token: 0x0602F9D1 RID: 195025 RVA: 0x00B5CBCD File Offset: 0x00B5ADCD
		public static void CreateStaticDefaultValue()
		{
			MotorcyclePerformComponent.DitherDebugMode = false;
		}

		// Token: 0x0602F9D2 RID: 195026 RVA: 0x00B5CBD5 File Offset: 0x00B5ADD5
		public static void ResetStaticDefaultValue()
		{
			MotorcyclePerformComponent.DitherDebugMode = false;
		}

		// Token: 0x0602F9D3 RID: 195027 RVA: 0x00B5CBE0 File Offset: 0x00B5ADE0
		public override bool ClearComponent(EntityComponent componentTemplate)
		{
			if (!base.ClearComponent(componentTemplate))
			{
				return false;
			}
			MotorcyclePerformComponent motorcyclePerformComponent = (MotorcyclePerformComponent)componentTemplate;
			if (base.CanResetComponentProperty("BuffComp"))
			{
				if (motorcyclePerformComponent.BuffComp == null)
				{
					this.BuffComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<VehicleBuffComponent>(this.BuffComp), "BuffComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("SetNoDriverFrame"))
			{
				this.SetNoDriverFrame = motorcyclePerformComponent.SetNoDriverFrame;
			}
			if (base.CanResetComponentProperty("DrivingBuffs") && motorcyclePerformComponent.DrivingBuffs != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<List<long>>(this.DrivingBuffs), "DrivingBuffs"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("DrivingBuffActivatingInternal"))
			{
				this.DrivingBuffActivatingInternal = motorcyclePerformComponent.DrivingBuffActivatingInternal;
			}
			if (base.CanResetComponentProperty("HitBuffMap") && motorcyclePerformComponent.HitBuffMap != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<EMotorPart, long>>(this.HitBuffMap), "HitBuffMap"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("DayTimeBuffs") && motorcyclePerformComponent.DayTimeBuffs != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<List<ValueTuple<float, long>>>(this.DayTimeBuffs), "DayTimeBuffs"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("OverlapSmallObjectEffectBuff"))
			{
				this.OverlapSmallObjectEffectBuff = motorcyclePerformComponent.OverlapSmallObjectEffectBuff;
			}
			if (base.CanResetComponentProperty("DetectedSmallItemComponents"))
			{
				if (motorcyclePerformComponent.DetectedSmallItemComponents == null)
				{
					this.DetectedSmallItemComponents = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<UStaticMeshComponent>(this.DetectedSmallItemComponents), "DetectedSmallItemComponents"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("PendingSmallItemComponents"))
			{
				if (motorcyclePerformComponent.PendingSmallItemComponents == null)
				{
					this.PendingSmallItemComponents = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<UStaticMeshComponent>(this.PendingSmallItemComponents), "PendingSmallItemComponents"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("SmallItemTraceElement"))
			{
				if (motorcyclePerformComponent.SmallItemTraceElement == null)
				{
					this.SmallItemTraceElement = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<UTraceCapsuleElement>(this.SmallItemTraceElement), "SmallItemTraceElement"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("NextSmallItemTraceTime"))
			{
				this.NextSmallItemTraceTime = motorcyclePerformComponent.NextSmallItemTraceTime;
			}
			if (base.CanResetComponentProperty("HourInternal"))
			{
				this.HourInternal = motorcyclePerformComponent.HourInternal;
			}
			if (base.CanResetComponentProperty("CurrentHourEffectInternal"))
			{
				this.CurrentHourEffectInternal = motorcyclePerformComponent.CurrentHourEffectInternal;
			}
			if (base.CanResetComponentProperty("LaunchSpeedFadeTimeInternal"))
			{
				this.LaunchSpeedFadeTimeInternal = motorcyclePerformComponent.LaunchSpeedFadeTimeInternal;
			}
			if (base.CanResetComponentProperty("LaunchVehicleSpeedAddRatioInternal"))
			{
				this.LaunchVehicleSpeedAddRatioInternal = motorcyclePerformComponent.LaunchVehicleSpeedAddRatioInternal;
			}
			if (base.CanResetComponentProperty("LaunchSpeedFadeCurveInternal"))
			{
				if (motorcyclePerformComponent.LaunchSpeedFadeCurveInternal == null)
				{
					this.LaunchSpeedFadeCurveInternal = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<UCurveFloat>(this.LaunchSpeedFadeCurveInternal), "LaunchSpeedFadeCurveInternal"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("NextResetSeatTransTime"))
			{
				this.NextResetSeatTransTime = motorcyclePerformComponent.NextResetSeatTransTime;
			}
			if (base.CanResetComponentProperty("DitherNpcRadius"))
			{
				this.DitherNpcRadius = motorcyclePerformComponent.DitherNpcRadius;
			}
			if (base.CanResetComponentProperty("DitherDepthCurve"))
			{
				if (motorcyclePerformComponent.DitherDepthCurve == null)
				{
					this.DitherDepthCurve = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<UCurveFloat>(this.DitherDepthCurve), "DitherDepthCurve"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("DitherCapsuleHalfHeight"))
			{
				this.DitherCapsuleHalfHeight = motorcyclePerformComponent.DitherCapsuleHalfHeight;
			}
			if (base.CanResetComponentProperty("DitherCapsuleRadius"))
			{
				this.DitherCapsuleRadius = motorcyclePerformComponent.DitherCapsuleRadius;
			}
			if (base.CanResetComponentProperty("DitherCapsuleRelativeTrans"))
			{
				if (motorcyclePerformComponent.DitherCapsuleRelativeTrans == null)
				{
					this.DitherCapsuleRelativeTrans = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Transform>(this.DitherCapsuleRelativeTrans), "DitherCapsuleRelativeTrans"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("CapsulePointA"))
			{
				if (motorcyclePerformComponent.CapsulePointA == null)
				{
					this.CapsulePointA = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.CapsulePointA), "CapsulePointA"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("CapsulePointB"))
			{
				if (motorcyclePerformComponent.CapsulePointB == null)
				{
					this.CapsulePointB = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.CapsulePointB), "CapsulePointB"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("DitherRemoveDistSquared"))
			{
				this.DitherRemoveDistSquared = motorcyclePerformComponent.DitherRemoveDistSquared;
			}
			if (base.CanResetComponentProperty("PendingDitherActorSet"))
			{
				if (motorcyclePerformComponent.PendingDitherActorSet == null)
				{
					this.PendingDitherActorSet = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<TsBaseCharacter>(this.PendingDitherActorSet), "PendingDitherActorSet"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("EnableDither"))
			{
				this.EnableDither = motorcyclePerformComponent.EnableDither;
			}
			return true;
		}

		// Token: 0x0401B3B9 RID: 111545
		private const float MIN_NPC_DITHER_RADIUS = 20f;

		// Token: 0x0401B3BA RID: 111546
		private const float MAX_NPC_DITHER_RADIUS = 200f;

		// Token: 0x0401B3BB RID: 111547
		private const float REMOVE_DITHER_ENTITY_DIST_SQUARED = 250000f;

		// Token: 0x0401B3BC RID: 111548
		private static readonly FName SmallItemTag = new FName("SMALL_ITEM");

		// Token: 0x0401B3BD RID: 111549
		private const double SMALL_ITEM_TRACE_INTERVAL = 500.0;

		// Token: 0x0401B3BE RID: 111550
		private const float SMALL_ITEM_TRACE_SPEED_THRESHOLD = 1000f;

		// Token: 0x0401B3BF RID: 111551
		[Nullable(2)]
		private VehicleBuffComponent BuffComp;

		// Token: 0x0401B3C0 RID: 111552
		protected int SetNoDriverFrame;

		// Token: 0x0401B3C1 RID: 111553
		private readonly List<long> DrivingBuffs = new List<long>();

		// Token: 0x0401B3C2 RID: 111554
		private bool DrivingBuffActivatingInternal;

		// Token: 0x0401B3C3 RID: 111555
		private readonly Dictionary<EMotorPart, long> HitBuffMap = new Dictionary<EMotorPart, long>();

		// Token: 0x0401B3C4 RID: 111556
		[Nullable(new byte[]
		{
			1,
			0
		})]
		private readonly List<ValueTuple<float, long>> DayTimeBuffs = new List<ValueTuple<float, long>>();

		// Token: 0x0401B3C5 RID: 111557
		private long OverlapSmallObjectEffectBuff;

		// Token: 0x0401B3C6 RID: 111558
		private HashSet<UStaticMeshComponent> DetectedSmallItemComponents = new HashSet<UStaticMeshComponent>();

		// Token: 0x0401B3C7 RID: 111559
		private HashSet<UStaticMeshComponent> PendingSmallItemComponents = new HashSet<UStaticMeshComponent>();

		// Token: 0x0401B3C8 RID: 111560
		[Nullable(2)]
		private UTraceCapsuleElement SmallItemTraceElement;

		// Token: 0x0401B3C9 RID: 111561
		private double NextSmallItemTraceTime;

		// Token: 0x0401B3CA RID: 111562
		private int HourInternal = -1;

		// Token: 0x0401B3CB RID: 111563
		private long CurrentHourEffectInternal;

		// Token: 0x0401B3CC RID: 111564
		private float LaunchSpeedFadeTimeInternal;

		// Token: 0x0401B3CD RID: 111565
		private float LaunchVehicleSpeedAddRatioInternal = 1f;

		// Token: 0x0401B3CE RID: 111566
		[Nullable(2)]
		private UCurveFloat LaunchSpeedFadeCurveInternal;

		// Token: 0x0401B3CF RID: 111567
		private double NextResetSeatTransTime;

		// Token: 0x0401B3D0 RID: 111568
		protected float DitherNpcRadius = 20f;

		// Token: 0x0401B3D1 RID: 111569
		[Nullable(2)]
		protected UCurveFloat DitherDepthCurve;

		// Token: 0x0401B3D2 RID: 111570
		protected float DitherCapsuleHalfHeight;

		// Token: 0x0401B3D3 RID: 111571
		protected float DitherCapsuleRadius;

		// Token: 0x0401B3D4 RID: 111572
		protected Transform DitherCapsuleRelativeTrans = Transform.Create();

		// Token: 0x0401B3D5 RID: 111573
		protected global::Vector CapsulePointA = global::Vector.Create();

		// Token: 0x0401B3D6 RID: 111574
		protected global::Vector CapsulePointB = global::Vector.Create();

		// Token: 0x0401B3D7 RID: 111575
		protected float DitherRemoveDistSquared = 250000f;

		// Token: 0x0401B3D8 RID: 111576
		protected HashSet<TsBaseCharacter> PendingDitherActorSet = new HashSet<TsBaseCharacter>();

		// Token: 0x0401B3D9 RID: 111577
		public bool EnableDither;

		// Token: 0x0401B3DA RID: 111578
		public static bool DitherDebugMode;
	}
}
