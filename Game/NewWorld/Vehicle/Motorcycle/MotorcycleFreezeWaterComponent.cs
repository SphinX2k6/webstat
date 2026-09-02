using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol.Summon;
using AkiClient.Game.Aki.Data.Fight.Enum;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Effect;
using CSharpScript.Game.NewWorld.Character.Common.Capability;
using CSharpScript.Game.NewWorld.Character.Common.Component.Abilities.Follow;
using CSharpScript.Game.Render;
using CSharpScript.Game.Utils;
using CSharpScript.Game.Utils.Priority;
using CSharpScript.Typing;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.Vehicle.Motorcycle
{
	// Token: 0x020047A6 RID: 18342
	[NullableContext(1)]
	[Nullable(0)]
	public class MotorcycleFreezeWaterComponent : EntityComponent
	{
		// Token: 0x170081AF RID: 33199
		// (get) Token: 0x0602F980 RID: 194944 RVA: 0x00B59168 File Offset: 0x00B57368
		// (set) Token: 0x0602F981 RID: 194945 RVA: 0x00B59170 File Offset: 0x00B57370
		private bool InNavWaterArea
		{
			get
			{
				return this.InNavWaterAreaInternal;
			}
			set
			{
				if (this.InNavWaterAreaInternal == value)
				{
					return;
				}
				this.InNavWaterAreaInternal = value;
				if (!this.IsFunctionOpen())
				{
					return;
				}
				if (!value)
				{
					if (this.OriginMotorcycleToKuroWaterCollisionResponse != null)
					{
						ECollisionResponse? originMotorcycleToKuroWaterCollisionResponse = this.OriginMotorcycleToKuroWaterCollisionResponse;
						ECollisionResponse ecollisionResponse = ECollisionResponse.ECR_Ignore;
						if (!(originMotorcycleToKuroWaterCollisionResponse.GetValueOrDefault() == ecollisionResponse & originMotorcycleToKuroWaterCollisionResponse != null))
						{
							MotorcycleMoveComponent moveComp = this.MoveComp;
							if (moveComp != null)
							{
								UKuroVehicleMovementComponent vehicleMovement = moveComp.VehicleMovement;
								if (vehicleMovement != null)
								{
									UPrimitiveComponent updatedPrimitive = vehicleMovement.UpdatedPrimitive;
									if (updatedPrimitive != null)
									{
										updatedPrimitive.SetCollisionResponseToChannel(KuroCollisionChannel.KuroWater, this.OriginMotorcycleToKuroWaterCollisionResponse.Value);
									}
								}
							}
							MotorcycleMoveComponent moveComp2 = this.MoveComp;
							if (moveComp2 != null)
							{
								UKuroVehicleMovementComponent vehicleMovement2 = moveComp2.VehicleMovement;
								if (vehicleMovement2 != null)
								{
									vehicleMovement2.InitVehicleShapes();
								}
							}
							this.OriginMotorcycleToKuroWaterCollisionResponse = null;
						}
					}
					return;
				}
				MotorcycleMoveComponent moveComp3 = this.MoveComp;
				TEnumAsByte<ECollisionResponse>? tenumAsByte;
				if (moveComp3 == null)
				{
					tenumAsByte = null;
				}
				else
				{
					UKuroVehicleMovementComponent vehicleMovement3 = moveComp3.VehicleMovement;
					if (vehicleMovement3 == null)
					{
						tenumAsByte = null;
					}
					else
					{
						UPrimitiveComponent updatedPrimitive2 = vehicleMovement3.UpdatedPrimitive;
						tenumAsByte = ((updatedPrimitive2 != null) ? new TEnumAsByte<ECollisionResponse>?(updatedPrimitive2.GetCollisionResponseToChannel(KuroCollisionChannel.KuroWater)) : null);
					}
				}
				TEnumAsByte<ECollisionResponse>? tenumAsByte2 = tenumAsByte;
				this.OriginMotorcycleToKuroWaterCollisionResponse = ((tenumAsByte2 != null) ? new ECollisionResponse?(tenumAsByte2.GetValueOrDefault()) : null);
				if (this.OriginMotorcycleToKuroWaterCollisionResponse.GetValueOrDefault() == ECollisionResponse.ECR_Block)
				{
					this.OriginMotorcycleToKuroWaterCollisionResponse = null;
					return;
				}
				MotorcycleMoveComponent moveComp4 = this.MoveComp;
				if (moveComp4 != null)
				{
					UKuroVehicleMovementComponent vehicleMovement4 = moveComp4.VehicleMovement;
					if (vehicleMovement4 != null)
					{
						UPrimitiveComponent updatedPrimitive3 = vehicleMovement4.UpdatedPrimitive;
						if (updatedPrimitive3 != null)
						{
							updatedPrimitive3.SetCollisionResponseToChannel(KuroCollisionChannel.KuroWater, ECollisionResponse.ECR_Block);
						}
					}
				}
				MotorcycleMoveComponent moveComp5 = this.MoveComp;
				if (moveComp5 == null)
				{
					return;
				}
				UKuroVehicleMovementComponent vehicleMovement5 = moveComp5.VehicleMovement;
				if (vehicleMovement5 == null)
				{
					return;
				}
				vehicleMovement5.InitVehicleShapes();
			}
		}

		// Token: 0x170081B0 RID: 33200
		// (get) Token: 0x0602F982 RID: 194946 RVA: 0x00B59301 File Offset: 0x00B57501
		// (set) Token: 0x0602F983 RID: 194947 RVA: 0x00B5930C File Offset: 0x00B5750C
		private bool DetectedWater
		{
			get
			{
				return this.DetectedWaterInternal;
			}
			set
			{
				if (this.DetectedWaterInternal == value)
				{
					return;
				}
				this.DetectedWaterInternal = value;
				if (!this.IsFunctionOpen())
				{
					return;
				}
				EntityHandle summonedEntity = PhantomUtil.GetSummonedEntity(base.Entity, ESummonType.ConcomitantMotorcycle, 1);
				if (summonedEntity != null && summonedEntity.Valid)
				{
					WorldEntity entity = summonedEntity.Entity;
					if (entity != null && entity.Valid)
					{
						FollowShooterComponent component = summonedEntity.Entity.GetComponent<FollowShooterComponent>();
						if (component != null)
						{
							component.SetEnable(value, BPEEnableFollowShooter.AutoDetectedFreezeWater, "");
						}
					}
				}
				if (value)
				{
					BaseTagComponent tagComp = this.TagComp;
					if (tagComp == null || !tagComp.HasTag(MotorcycleFreezeWaterComponent.freezeWaterEffectTag))
					{
						BaseTagComponent tagComp2 = this.TagComp;
						if (tagComp2 != null)
						{
							tagComp2.AddTag(new int?(MotorcycleFreezeWaterComponent.freezeWaterEffectTag));
						}
					}
					if (ControllerBase<FormationDataController>.Instance.HasPlayerTag(ModelBase<CreatureModel>.Instance.GetPlayerId(), MotorcycleFreezeWaterComponent.freezeRunningWaterTag, false))
					{
						CustomPriorityManager<MotorcycleFreezeWaterComponent.EFreezeWaterType> freezeWaterPriorityManager = this.FreezeWaterPriorityManager;
						if (freezeWaterPriorityManager != null)
						{
							freezeWaterPriorityManager.TryEnter(MotorcycleFreezeWaterComponent.EFreezeWaterType.SetPositionByMaterialParameterCollection, "DetectedWater");
						}
					}
					else
					{
						CustomPriorityManager<MotorcycleFreezeWaterComponent.EFreezeWaterType> freezeWaterPriorityManager2 = this.FreezeWaterPriorityManager;
						if (freezeWaterPriorityManager2 != null)
						{
							freezeWaterPriorityManager2.TryEnter(MotorcycleFreezeWaterComponent.EFreezeWaterType.MovementTrailCollision, "DetectedWater");
						}
					}
					Action<bool> freezeWaterEnterExitHandler = this.FreezeWaterEnterExitHandler;
					if (freezeWaterEnterExitHandler == null)
					{
						return;
					}
					freezeWaterEnterExitHandler(value);
					return;
				}
				else
				{
					BaseTagComponent tagComp3 = this.TagComp;
					if (tagComp3 != null)
					{
						tagComp3.RemoveTag(new int?(MotorcycleFreezeWaterComponent.freezeWaterEffectTag));
					}
					CustomPriorityManager<MotorcycleFreezeWaterComponent.EFreezeWaterType> freezeWaterPriorityManager3 = this.FreezeWaterPriorityManager;
					if (freezeWaterPriorityManager3 == null)
					{
						return;
					}
					freezeWaterPriorityManager3.TryExitAll("Not DetectedWater");
					return;
				}
			}
		}

		// Token: 0x170081B1 RID: 33201
		// (get) Token: 0x0602F984 RID: 194948 RVA: 0x00B5944C File Offset: 0x00B5764C
		public new static Type[] Dependencies
		{
			get
			{
				return new Type[]
				{
					typeof(CreatureDataComponent),
					typeof(VehicleActorComponent),
					typeof(BaseTagComponent),
					typeof(MotorcycleMoveComponent),
					typeof(MotorcycleWaterComponent)
				};
			}
		}

		// Token: 0x0602F985 RID: 194949 RVA: 0x00B594A0 File Offset: 0x00B576A0
		[NullableContext(2)]
		protected override bool OnInitData(IEntityArgs args = null)
		{
			this.KuroTrailCollisionAssetPath = (ConfigCommonParamById.GetStringConfig("KuroTrailCollisionAsset") ?? "");
			IEnumerable<string> enumerable = ConfigCommonParamById.GetStringArrayConfig("FreezeWaterEffectComponentNames") ?? Array.Empty<string>();
			this.FreezeWaterEffectTagToContexts.Clear();
			foreach (string text in enumerable)
			{
				foreach (KeyValuePair<string, string> keyValuePair in StringUtils.ParseCSVStringToMap(text))
				{
					string key = keyValuePair.Key;
					string value = keyValuePair.Value;
					if (StringUtils.IsBlank(key) || StringUtils.IsBlank(value))
					{
						Log instance = Singleton<Log>.Instance;
						ELogModule module = ELogModule.Motor;
						ELogAuthor author = ELogAuthor.XDW;
						string message = "FreezeWaterEffectComponentNames 配置错误, 格式为 ComponentName:SocketName";
						ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Content", text);
						instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					}
					else
					{
						foreach (MotorcycleFreezeWaterComponent.IEffectConfig effectConfig in MotorcycleFreezeWaterComponent.FreezeWaterEffectConfigs)
						{
							if (effectConfig.EffectPath == null)
							{
								effectConfig.EffectPath = (ConfigCommonParamById.GetStringConfig(effectConfig.Config) ?? "");
							}
							if (!this.FreezeWaterEffectTagToContexts.ContainsKey(effectConfig.TagId))
							{
								this.FreezeWaterEffectTagToContexts[effectConfig.TagId] = new List<MotorcycleFreezeWaterComponent.IEffectContext>();
							}
							this.FreezeWaterEffectTagToContexts[effectConfig.TagId].Add(new MotorcycleFreezeWaterComponent.EffectContextImpl
							{
								AssetPath = effectConfig.EffectPath,
								ComponentName = key,
								Socket = FNameUtil.GetDynamicFName(value).Value
							});
						}
					}
				}
			}
			return true;
		}

		// Token: 0x0602F986 RID: 194950 RVA: 0x00B59688 File Offset: 0x00B57888
		protected override bool OnStart()
		{
			CreatureDataComponent creatureDataComponent = base.Entity.CheckGetComponent<CreatureDataComponent>();
			this.ActorComp = base.Entity.CheckGetComponent<MotorcycleActorComponent>();
			this.TagComp = base.Entity.CheckGetComponent<BaseTagComponent>();
			this.MoveComp = base.Entity.CheckGetComponent<MotorcycleMoveComponent>();
			int num = (creatureDataComponent != null) ? creatureDataComponent.GetPlayerId() : 0;
			this.IsAutonomousProxy = (num == ModelBase<CreatureModel>.Instance.GetPlayerId());
			MotorcycleWaterComponent motorcycleWaterComponent = base.Entity.CheckGetComponent<MotorcycleWaterComponent>();
			this.TraceWaterCapability = ((motorcycleWaterComponent != null) ? motorcycleWaterComponent.TraceWaterCapability : null);
			this.TempWheelHitResults = new Dictionary<int, FHitResult>
			{
				{
					0,
					new FHitResult()
				},
				{
					1,
					new FHitResult()
				}
			};
			this.WheelHitResults = new Dictionary<int, FHitResult>
			{
				{
					0,
					null
				},
				{
					1,
					null
				}
			};
			foreach (int value in this.FreezeWaterEffectTagToContexts.Keys)
			{
				BaseTagComponent tagComp = this.TagComp;
				ITagTask tagTask = (tagComp != null) ? tagComp.ListenForTagAddOrRemove(new int?(value), new BaseTagComponent.TTagSwitchedCallback(this.OnFreezeWaterEffectTagAddOrRemove), null) : null;
				if (tagTask != null)
				{
					this.TagTasks.Add(tagTask);
				}
			}
			this.EffectSystemContext = new EffectContext(new int?(base.Entity.Id), null, false);
			MotorcycleActorComponent actorComp = this.ActorComp;
			this.InteractionComp = FreezeWaterRenderCapability.CheckKuroWaterDetectedInterface((actorComp != null) ? actorComp.Owner : null);
			Singleton<EventSystem>.Instance.AddWithTarget<bool>(base.Entity, EEventName.MotorcycleWaterAreaChange, new Action<bool>(this.OnMotorcycleWaterAreaChange));
			Singleton<EventSystem>.Instance.AddWithTarget<VehiclePassengerInfo, bool>(base.Entity, EEventName.OnVehicleBeenEntered, new Action<VehiclePassengerInfo, bool>(this.OnVehicleBeenEntered));
			Singleton<EventSystem>.Instance.AddWithTarget<VehiclePassengerInfo, bool>(base.Entity, EEventName.OnVehicleBeenLeaved, new Action<VehiclePassengerInfo, bool>(this.OnVehicleBeenLeaved));
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(31, 1);
			defaultInterpolatedStringHandler.AppendLiteral("MotorcycleFreezeWaterComponent ");
			defaultInterpolatedStringHandler.AppendFormatted<int>(base.Entity.Id);
			this.FreezeWaterPriorityManager = new CustomPriorityManager<MotorcycleFreezeWaterComponent.EFreezeWaterType>(defaultInterpolatedStringHandler.ToStringAndClear());
			this.FreezeWaterPriorityManager.Register(MotorcycleFreezeWaterComponent.EFreezeWaterType.MovementTrailCollision, new CustomPriorityConfig<MotorcycleFreezeWaterComponent.EFreezeWaterType>
			{
				Enable = false,
				EnterCallback = new Func<ICustomPriorityCallbackParam, bool>(this.MovementTrailCollisionEnterCallback),
				ExitCallback = new Func<ICustomPriorityCallbackParam, bool>(this.MovementTrailCollisionExitCallback)
			});
			this.FreezeWaterPriorityManager.Register(MotorcycleFreezeWaterComponent.EFreezeWaterType.SetPositionByMaterialParameterCollection, new CustomPriorityConfig<MotorcycleFreezeWaterComponent.EFreezeWaterType>
			{
				Enable = false,
				EnterCallback = new Func<ICustomPriorityCallbackParam, bool>(this.SetPositionByMaterialParameterCollectionEnterCallback),
				ExitCallback = new Func<ICustomPriorityCallbackParam, bool>(this.SetPositionByMaterialParameterCollectionExitCallback)
			});
			return true;
		}

		// Token: 0x0602F987 RID: 194951 RVA: 0x00B5991C File Offset: 0x00B57B1C
		protected override bool OnEnd()
		{
			this.FreezeWaterEnterExitHandler = null;
			this.FreezeWaterTickHandler = null;
			Singleton<EventSystem>.Instance.RemoveWithTarget<VehiclePassengerInfo, bool>(base.Entity, EEventName.OnVehicleBeenLeaved, new Action<VehiclePassengerInfo, bool>(this.OnVehicleBeenLeaved));
			Singleton<EventSystem>.Instance.RemoveWithTarget<VehiclePassengerInfo, bool>(base.Entity, EEventName.OnVehicleBeenEntered, new Action<VehiclePassengerInfo, bool>(this.OnVehicleBeenEntered));
			Singleton<EventSystem>.Instance.RemoveWithTarget<bool>(base.Entity, EEventName.MotorcycleWaterAreaChange, new Action<bool>(this.OnMotorcycleWaterAreaChange));
			this.EffectSystemContext = null;
			foreach (ITagTask tagTask in this.TagTasks)
			{
				tagTask.EndTask();
			}
			this.TagTasks.Clear();
			this.InNavWaterArea = false;
			this.DetectedWater = false;
			this.TraceWaterCapability = null;
			this.MoveComp = null;
			this.TagComp = null;
			this.ActorComp = null;
			this.InteractionComp = null;
			Dictionary<int, FHitResult> tempWheelHitResults = this.TempWheelHitResults;
			if (tempWheelHitResults != null)
			{
				tempWheelHitResults.Clear();
			}
			this.TempWheelHitResults = null;
			Dictionary<int, FHitResult> wheelHitResults = this.WheelHitResults;
			if (wheelHitResults != null)
			{
				wheelHitResults.Clear();
			}
			this.WheelHitResults = null;
			this.ClearFreezeWaterEffect();
			foreach (WaterDetectedCapability waterDetectedCapability in this.GameCapabilities)
			{
				waterDetectedCapability.Deactivate();
			}
			this.GameCapabilities.Clear();
			CustomPriorityManager<MotorcycleFreezeWaterComponent.EFreezeWaterType> freezeWaterPriorityManager = this.FreezeWaterPriorityManager;
			if (freezeWaterPriorityManager != null)
			{
				freezeWaterPriorityManager.TryExitAll("OnEnd");
			}
			CustomPriorityManager<MotorcycleFreezeWaterComponent.EFreezeWaterType> freezeWaterPriorityManager2 = this.FreezeWaterPriorityManager;
			if (freezeWaterPriorityManager2 != null)
			{
				freezeWaterPriorityManager2.ClearObject();
			}
			this.FreezeWaterPriorityManager = null;
			return true;
		}

		// Token: 0x0602F988 RID: 194952 RVA: 0x00B59AD4 File Offset: 0x00B57CD4
		protected override void OnTick(float delta)
		{
			if (!this.IsFunctionOpen())
			{
				return;
			}
			if (!this.InNavWaterArea)
			{
				return;
			}
			MotorcycleActorComponent actorComp = this.ActorComp;
			if (actorComp != null && actorComp.Valid)
			{
				TsBaseVehicle vehicleOwner = this.ActorComp.VehicleOwner;
				if (vehicleOwner != null && vehicleOwner.IsValid())
				{
					if (this.TraceWaterCapability == null)
					{
						return;
					}
					bool flag = false;
					TraceWaterResult traceWaterResult = null;
					if (this.IsAutonomousProxy)
					{
						if (this.WheelHitResults == null)
						{
							return;
						}
						foreach (int wheelIndex in this.WheelHitResults.Keys)
						{
							flag = (this.CheckWheelHitResultIsWater(wheelIndex) || flag);
						}
						int num = 0;
						Singleton<MathUtils>.Instance.CommonTempVector.Set(0.0, 0.0, 0.0);
						Singleton<MathUtils>.Instance.CommonTempVector2.Set(0.0, 0.0, 0.0);
						foreach (FHitResult fhitResult in this.WheelHitResults.Values)
						{
							if (!(fhitResult == null))
							{
								num++;
								global::Vector impactPoint = this.TraceWaterCapability.ImpactPoint;
								FVector_NetQuantize impactPoint2 = fhitResult.ImpactPoint;
								impactPoint.FromUeVector(impactPoint2);
								global::Vector impactNormal = this.TraceWaterCapability.ImpactNormal;
								FVector_NetQuantizeNormal impactNormal2 = fhitResult.ImpactNormal;
								impactNormal.FromUeVector(impactNormal2);
								if (ModelBase<SundryModel>.Instance.GetModuleDebugLevel("MotorcycleFreezeWaterComponent") >= 1)
								{
									this.TmpVector.Set((double)fhitResult.ImpactPoint.X, (double)fhitResult.ImpactPoint.Y, (double)fhitResult.ImpactPoint.Z);
									this.TmpVector.MultiplyEqual(101.0);
									UObject vehicleOwner2 = this.ActorComp.VehicleOwner;
									impactPoint2 = fhitResult.ImpactPoint;
									FVector lineStart = impactPoint2;
									FVectorDouble fvectorDouble = this.TmpVector.ToUeVector(false);
									UKismetSystemLibrary.DrawDebugArrow(vehicleOwner2, lineStart, fvectorDouble, 100f, ColorUtils.LinearGreen, 0f, 0f);
								}
								Singleton<MathUtils>.Instance.CommonTempVector.AdditionEqual(this.TraceWaterCapability.ImpactPoint);
								Singleton<MathUtils>.Instance.CommonTempVector2.AdditionEqual(this.TraceWaterCapability.ImpactNormal);
							}
						}
						if (num > 0)
						{
							Singleton<MathUtils>.Instance.CommonTempVector.DivisionEqual((double)num);
							Singleton<MathUtils>.Instance.CommonTempVector2.DivisionEqual((double)num);
							FIntVector worldOriginLocation = UGameplayStatics.GetWorldOriginLocation(this.ActorComp.VehicleOwner);
							global::Vector inB = global::Vector.Create((double)worldOriginLocation.X, (double)worldOriginLocation.Y, (double)worldOriginLocation.Z);
							traceWaterResult = new TraceWaterResult
							{
								FoundWater = true,
								MinWaterHeight = (float)Singleton<MathUtils>.Instance.CommonTempVector.Z,
								ImpactPoint = Singleton<MathUtils>.Instance.CommonTempVector.Addition(inB, global::Vector.Create()),
								ImpactNormal = global::Vector.Create(Singleton<MathUtils>.Instance.CommonTempVector2)
							};
						}
					}
					else
					{
						traceWaterResult = this.TraceWaterCapability.TraceWater(100.0, -100.0);
						if (traceWaterResult.FoundWater && !this.TraceWaterCapability.CeilingCheck((double)traceWaterResult.MinWaterHeight))
						{
							flag = true;
						}
					}
					this.DetectedWater = flag;
					if (this.DetectedWater && ((traceWaterResult != null) ? traceWaterResult.ImpactNormal : null) != null && ((traceWaterResult != null) ? traceWaterResult.ImpactPoint : null) != null)
					{
						Action<float, global::Vector, global::Vector> freezeWaterTickHandler = this.FreezeWaterTickHandler;
						if (freezeWaterTickHandler == null)
						{
							return;
						}
						freezeWaterTickHandler(delta, traceWaterResult.ImpactPoint, traceWaterResult.ImpactNormal);
					}
					return;
				}
			}
		}

		// Token: 0x0602F989 RID: 194953 RVA: 0x00B59EA8 File Offset: 0x00B580A8
		private void MovementTrailCollisionHandler(bool value)
		{
			MotorcycleActorComponent actorComp = this.ActorComp;
			if (actorComp != null && actorComp.Valid)
			{
				TsBaseVehicle vehicleOwner = this.ActorComp.VehicleOwner;
				if (vehicleOwner != null && vehicleOwner.IsValid())
				{
					UKuroEnviInteractionComponent interactionComp = this.InteractionComp;
					if (interactionComp == null || !interactionComp.IsValid())
					{
						return;
					}
					if (value)
					{
						this.CreateFreezeWaterDependency();
						foreach (WaterDetectedCapability waterDetectedCapability in this.GameCapabilities)
						{
							waterDetectedCapability.OnWaterDetectedStart();
						}
						FKuroWaterDetectedInterfaceHelper.Execute_BroadcastWaterDetectedStart(this.InteractionComp);
						return;
					}
					foreach (WaterDetectedCapability waterDetectedCapability2 in this.GameCapabilities)
					{
						waterDetectedCapability2.OnWaterDetectedEnd();
					}
					FKuroWaterDetectedInterfaceHelper.Execute_BroadcastWaterDetectedEnd(this.InteractionComp);
					return;
				}
			}
		}

		// Token: 0x0602F98A RID: 194954 RVA: 0x00B59FA4 File Offset: 0x00B581A4
		private void MovementTrailCollisionTickHandler(float delta, global::Vector impactPoint, global::Vector impactNormal)
		{
			UKuroEnviInteractionComponent interactionComp = this.InteractionComp;
			if (interactionComp == null || !interactionComp.IsValid())
			{
				return;
			}
			foreach (WaterDetectedCapability waterDetectedCapability in this.GameCapabilities)
			{
				waterDetectedCapability.OnWaterDetectedTick(delta, impactPoint, impactNormal);
			}
			UObject interactionComp2 = this.InteractionComp;
			float waterSurface = (float)impactPoint.Z;
			FVectorDouble fvectorDouble = impactPoint.ToUeVector(false);
			FKuroWaterDetectedInterfaceHelper.Execute_BroadcastWaterDetectedTick(interactionComp2, delta, waterSurface, fvectorDouble);
		}

		// Token: 0x0602F98B RID: 194955 RVA: 0x00B5A034 File Offset: 0x00B58234
		private void SetPositionByMaterialParameterCollectionHandler(bool value)
		{
			if (!value)
			{
				MotorcycleActorComponent actorComp = this.ActorComp;
				bool flag;
				if (actorComp == null)
				{
					flag = true;
				}
				else
				{
					TsBaseVehicle vehicleOwner = actorComp.VehicleOwner;
					flag = !((vehicleOwner != null) ? new bool?(vehicleOwner.IsValid()) : null).GetValueOrDefault();
				}
				if (flag)
				{
					return;
				}
				if (!this.IsAutonomousProxy)
				{
					return;
				}
				UKismetMaterialLibrary.SetVectorParameterValue(this.ActorComp.VehicleOwner, Singleton<RenderDataManager>.Instance.GetGlobalShaderParameters(), MovementTrailCollisionCapability.iceRiderPositionName, ColorUtils.LinearClear);
			}
		}

		// Token: 0x0602F98C RID: 194956 RVA: 0x00B5A0AC File Offset: 0x00B582AC
		private void SetPositionByMaterialParameterCollectionTickHandler(float delta, global::Vector impactPoint, global::Vector impactNormal)
		{
			MotorcycleActorComponent actorComp = this.ActorComp;
			bool flag;
			if (actorComp == null)
			{
				flag = true;
			}
			else
			{
				TsBaseVehicle vehicleOwner = actorComp.VehicleOwner;
				flag = !((vehicleOwner != null) ? new bool?(vehicleOwner.IsValid()) : null).GetValueOrDefault();
			}
			if (flag)
			{
				return;
			}
			if (!this.IsAutonomousProxy)
			{
				return;
			}
			FVector fvector = this.ActorComp.VehicleOwner.K2_GetActorLocation();
			UObject vehicleOwner2 = this.ActorComp.VehicleOwner;
			UMaterialParameterCollection globalShaderParameters = Singleton<RenderDataManager>.Instance.GetGlobalShaderParameters();
			FName iceRiderPositionName = MovementTrailCollisionCapability.iceRiderPositionName;
			FLinearColor flinearColor = new FLinearColor(fvector.X, fvector.Y, fvector.Z, 2f);
			UKismetMaterialLibrary.SetVectorParameterValue(vehicleOwner2, globalShaderParameters, iceRiderPositionName, flinearColor);
		}

		// Token: 0x0602F98D RID: 194957 RVA: 0x00B5A14A File Offset: 0x00B5834A
		public void SetIsFunctionOpenOverride(bool? value)
		{
			this.IsFunctionOpenOverride = value;
		}

		// Token: 0x0602F98E RID: 194958 RVA: 0x00B5A153 File Offset: 0x00B58353
		private bool IsFunctionOpen()
		{
			if (this.IsFunctionOpenOverride != null)
			{
				return this.IsFunctionOpenOverride.Value;
			}
			return ModelBase<FunctionModel>.Instance.IsOpen(EFunctionType.MotorFreezeWater);
		}

		// Token: 0x0602F98F RID: 194959 RVA: 0x00B5A180 File Offset: 0x00B58380
		private bool CheckWheelHitResultIsWater(int wheelIndex)
		{
			this.WheelHitResults[wheelIndex] = null;
			FHitResult fhitResult;
			if (this.TempWheelHitResults == null || !this.TempWheelHitResults.TryGetValue(wheelIndex, out fhitResult))
			{
				return false;
			}
			MotorcycleMoveComponent moveComp = this.MoveComp;
			bool flag;
			if (moveComp == null)
			{
				flag = true;
			}
			else
			{
				UKuroVehicleMovementComponent vehicleMovement = moveComp.VehicleMovement;
				flag = !((vehicleMovement != null) ? new bool?(vehicleMovement.IsValid()) : null).GetValueOrDefault();
			}
			if (flag)
			{
				return false;
			}
			bool flag2;
			if (wheelIndex != 0)
			{
				if (wheelIndex != 1)
				{
					return false;
				}
				flag2 = this.MoveComp.VehicleMovement.GetBackMotorHitResult(ref fhitResult);
			}
			else
			{
				flag2 = this.MoveComp.VehicleMovement.GetFrontMotorHitResult(ref fhitResult);
			}
			if (!flag2)
			{
				return false;
			}
			FHitResult fhitResult2 = fhitResult;
			if (!fhitResult2.bBlockingHit)
			{
				return false;
			}
			if (!fhitResult2.Component.IsValid(false, false))
			{
				return false;
			}
			if (UKuroCollisionLibrary.GetCollisionProfileName(fhitResult2.Component, fhitResult2.Item) != MotorcycleTraceWaterCapability.waterCollisionProfileName)
			{
				return false;
			}
			this.WheelHitResults[wheelIndex] = fhitResult2;
			return true;
		}

		// Token: 0x0602F990 RID: 194960 RVA: 0x00B5A27D File Offset: 0x00B5847D
		private void OnFreezeWaterEffectTagAddOrRemove(int tagId, bool tagExist)
		{
			if (!this.IsFunctionOpen())
			{
				return;
			}
			if (tagExist)
			{
				this.StartSummonedEntityFreezeWaterEffect(tagId);
				return;
			}
			this.EndSummonedEntityFreezeWaterEffect(tagId);
		}

		// Token: 0x0602F991 RID: 194961 RVA: 0x00B5A29C File Offset: 0x00B5849C
		private void StartSummonedEntityFreezeWaterEffect(int tagId)
		{
			EntityHandle summonedEntity = PhantomUtil.GetSummonedEntity(base.Entity, ESummonType.ConcomitantMotorcycle, 1);
			if (summonedEntity != null && summonedEntity.Valid)
			{
				WorldEntity entity = summonedEntity.Entity;
				if (entity != null && entity.Valid)
				{
					CharacterActorComponent characterActorComponent = summonedEntity.Entity.CheckGetComponent<CharacterActorComponent>();
					if (characterActorComponent == null || !characterActorComponent.IsAutonomousProxy)
					{
						return;
					}
					BaseActorComponent component = summonedEntity.Entity.GetComponent<BaseActorComponent>();
					bool flag;
					if (component == null)
					{
						flag = true;
					}
					else
					{
						AActor owner = component.Owner;
						flag = !((owner != null) ? new bool?(owner.IsValid()) : null).GetValueOrDefault();
					}
					if (flag)
					{
						return;
					}
					TArray<UActorComponent> tarray = component.Owner.K2_GetComponentsByClass(USkeletalMeshComponent.StaticClass());
					Dictionary<string, USkeletalMeshComponent> dictionary = new Dictionary<string, USkeletalMeshComponent>();
					for (int i = 0; i < tarray.Num(); i++)
					{
						UActorComponent uactorComponent = tarray.Get(i);
						dictionary[uactorComponent.GetName()] = (uactorComponent as USkeletalMeshComponent);
					}
					List<MotorcycleFreezeWaterComponent.IEffectContext> valueOrDefault = this.FreezeWaterEffectTagToContexts.GetValueOrDefault(tagId);
					if (valueOrDefault == null || valueOrDefault.Count == 0)
					{
						return;
					}
					foreach (MotorcycleFreezeWaterComponent.IEffectContext effectContext in valueOrDefault)
					{
						USkeletalMeshComponent uskeletalMeshComponent;
						dictionary.TryGetValue(effectContext.ComponentName, out uskeletalMeshComponent);
						if (uskeletalMeshComponent != null && uskeletalMeshComponent.IsValid())
						{
							EffectSystem instance = Singleton<EffectSystem>.Instance;
							UObject owner2 = component.Owner;
							FTransformDouble? ftransformDouble = new FTransformDouble?(Singleton<MathUtils>.Instance.DefaultTransformDouble);
							int num = instance.SpawnEffect(owner2, ftransformDouble, effectContext.AssetPath, "[OnMotorcycleWaterDetectedStart]", this.EffectSystemContext, EEffectType.Fight, null, null, null, false, false);
							effectContext.EffectHandleId = new int?(num);
							Singleton<EffectSystem>.Instance.GetEffectActor(num).K2_AttachToComponent(uskeletalMeshComponent, new FName?(effectContext.Socket), EAttachmentRule.SnapToTarget, EAttachmentRule.SnapToTarget, EAttachmentRule.SnapToTarget, false);
						}
					}
					return;
				}
			}
		}

		// Token: 0x0602F992 RID: 194962 RVA: 0x00B5A480 File Offset: 0x00B58680
		private void EndSummonedEntityFreezeWaterEffect(int tagId)
		{
			List<MotorcycleFreezeWaterComponent.IEffectContext> list;
			this.FreezeWaterEffectTagToContexts.TryGetValue(tagId, out list);
			if (list == null || list.Count == 0)
			{
				return;
			}
			foreach (MotorcycleFreezeWaterComponent.IEffectContext effectContext in list)
			{
				int? effectHandleId = effectContext.EffectHandleId;
				if (effectHandleId != null)
				{
					EffectSystem instance = Singleton<EffectSystem>.Instance;
					int value = effectHandleId.Value;
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(35, 1);
					defaultInterpolatedStringHandler.AppendLiteral("EndSummonedEntityFreezeWaterEffect:");
					defaultInterpolatedStringHandler.AppendFormatted<int>(tagId);
					instance.StopEffectById(value, defaultInterpolatedStringHandler.ToStringAndClear(), false, null);
					effectContext.EffectHandleId = null;
				}
			}
		}

		// Token: 0x0602F993 RID: 194963 RVA: 0x00B5A544 File Offset: 0x00B58744
		protected UniTask CreateFreezeWaterDependencyByTaskGraph()
		{
			MotorcycleFreezeWaterComponent.<CreateFreezeWaterDependencyByTaskGraph>d__59 <CreateFreezeWaterDependencyByTaskGraph>d__;
			<CreateFreezeWaterDependencyByTaskGraph>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateFreezeWaterDependencyByTaskGraph>d__.<>4__this = this;
			<CreateFreezeWaterDependencyByTaskGraph>d__.<>1__state = -1;
			<CreateFreezeWaterDependencyByTaskGraph>d__.<>t__builder.Start<MotorcycleFreezeWaterComponent.<CreateFreezeWaterDependencyByTaskGraph>d__59>(ref <CreateFreezeWaterDependencyByTaskGraph>d__);
			return <CreateFreezeWaterDependencyByTaskGraph>d__.<>t__builder.Task;
		}

		// Token: 0x0602F994 RID: 194964 RVA: 0x00B5A588 File Offset: 0x00B58788
		private static UniTask LoadBlueprintTypeAsync()
		{
			MotorcycleFreezeWaterComponent.<LoadBlueprintTypeAsync>d__60 <LoadBlueprintTypeAsync>d__;
			<LoadBlueprintTypeAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<LoadBlueprintTypeAsync>d__.<>1__state = -1;
			<LoadBlueprintTypeAsync>d__.<>t__builder.Start<MotorcycleFreezeWaterComponent.<LoadBlueprintTypeAsync>d__60>(ref <LoadBlueprintTypeAsync>d__);
			return <LoadBlueprintTypeAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0602F995 RID: 194965 RVA: 0x00B5A5C4 File Offset: 0x00B587C4
		private UniTask LoadKuroTrailCollisionAsset<[Nullable(0)] T>(string path) where T : UKuroTrailCollisionAsset
		{
			MotorcycleFreezeWaterComponent.<LoadKuroTrailCollisionAsset>d__61<T> <LoadKuroTrailCollisionAsset>d__;
			<LoadKuroTrailCollisionAsset>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<LoadKuroTrailCollisionAsset>d__.<>4__this = this;
			<LoadKuroTrailCollisionAsset>d__.path = path;
			<LoadKuroTrailCollisionAsset>d__.<>1__state = -1;
			<LoadKuroTrailCollisionAsset>d__.<>t__builder.Start<MotorcycleFreezeWaterComponent.<LoadKuroTrailCollisionAsset>d__61<T>>(ref <LoadKuroTrailCollisionAsset>d__);
			return <LoadKuroTrailCollisionAsset>d__.<>t__builder.Task;
		}

		// Token: 0x0602F996 RID: 194966 RVA: 0x00B5A610 File Offset: 0x00B58810
		private void CreateFreezeWaterDependency()
		{
			if (!this.IsFunctionOpen())
			{
				return;
			}
			if (this.GameCapabilities.Count > 0)
			{
				return;
			}
			MotorcycleActorComponent actorComp = this.ActorComp;
			bool flag;
			if (actorComp == null)
			{
				flag = true;
			}
			else
			{
				AActor owner = actorComp.Owner;
				flag = !((owner != null) ? new bool?(owner.IsValid()) : null).GetValueOrDefault();
			}
			if (flag)
			{
				return;
			}
			string text = ConfigCommonParamById.GetStringConfig("KuroTrailCollisionAsset") ?? "";
			UKuroTrailCollisionAsset ukuroTrailCollisionAsset = Singleton<ResourceSystem>.Instance.Load<UKuroTrailCollisionAsset>(text, "js_undefined");
			if (ukuroTrailCollisionAsset == null || !ukuroTrailCollisionAsset.IsValid())
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Motor;
				ELogAuthor author = ELogAuthor.XDW;
				string message = "MotorcycleFreezeWaterComponent: kuroTrailCollisionAsset is invalid";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("path", text);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			this.FreezeWaterRenderCapability1 = new FreezeWaterRenderCapability(this.ActorComp.Owner, ukuroTrailCollisionAsset);
			this.MovementTrailCollisionCapability = new MovementTrailCollisionCapability(this.ActorComp.Owner, this.FreezeWaterRenderCapability1.Actor, ukuroTrailCollisionAsset);
			this.GameCapabilities.Add(this.FreezeWaterRenderCapability1);
			this.GameCapabilities.Add(this.MovementTrailCollisionCapability);
			foreach (WaterDetectedCapability waterDetectedCapability in this.GameCapabilities)
			{
				waterDetectedCapability.Activate();
			}
		}

		// Token: 0x0602F997 RID: 194967 RVA: 0x00B5A770 File Offset: 0x00B58970
		private void ClearFreezeWaterEffect()
		{
			foreach (int tagId in this.FreezeWaterEffectTagToContexts.Keys)
			{
				this.EndSummonedEntityFreezeWaterEffect(tagId);
			}
		}

		// Token: 0x0602F998 RID: 194968 RVA: 0x00B5A7C8 File Offset: 0x00B589C8
		private void OnMotorcycleWaterAreaChange(bool inArea)
		{
			this.InNavWaterArea = inArea;
		}

		// Token: 0x0602F999 RID: 194969 RVA: 0x00B5A7D4 File Offset: 0x00B589D4
		private void OnVehicleBeenLeaved(VehiclePassengerInfo info, bool byChangeRole)
		{
			if (!info.IsDriver)
			{
				return;
			}
			this.ClearFreezeWaterEffect();
			this.InNavWaterArea = false;
			this.DetectedWater = false;
			ITagTask freezeRunningWaterTagTask = this.FreezeRunningWaterTagTask;
			if (freezeRunningWaterTagTask != null)
			{
				freezeRunningWaterTagTask.EndTask();
			}
			this.FreezeRunningWaterTagTask = null;
			CustomPriorityManager<MotorcycleFreezeWaterComponent.EFreezeWaterType> freezeWaterPriorityManager = this.FreezeWaterPriorityManager;
			if (freezeWaterPriorityManager == null)
			{
				return;
			}
			freezeWaterPriorityManager.TryExitAll("");
		}

		// Token: 0x0602F99A RID: 194970 RVA: 0x00B5A82C File Offset: 0x00B58A2C
		private void OnVehicleBeenEntered(VehiclePassengerInfo info, bool byChangeRole)
		{
			if (!info.IsDriver)
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
			int valueOrDefault = num2.GetValueOrDefault();
			if (valueOrDefault != ModelBase<CreatureModel>.Instance.GetPlayerId())
			{
				return;
			}
			WorldEntity playerEntity = ControllerBase<FormationDataController>.Instance.GetPlayerEntity(valueOrDefault);
			PlayerTagComponent playerTagComponent = (playerEntity != null) ? playerEntity.CheckGetComponent<PlayerTagComponent>() : null;
			if (playerTagComponent == null)
			{
				return;
			}
			this.FreezeRunningWaterTagTask = playerTagComponent.ListenForTagAddOrRemove(new int?(MotorcycleFreezeWaterComponent.freezeRunningWaterTag), new BaseTagComponent.TTagSwitchedCallback(this.OnFreezeRunningWaterTagChanged), null);
		}

		// Token: 0x0602F99B RID: 194971 RVA: 0x00B5A8CC File Offset: 0x00B58ACC
		private void OnFreezeRunningWaterTagChanged(int tagId, bool tagExist)
		{
			if (tagId != MotorcycleFreezeWaterComponent.freezeRunningWaterTag)
			{
				return;
			}
			if (!this.IsFunctionOpen())
			{
				return;
			}
			if (tagExist)
			{
				CustomPriorityManager<MotorcycleFreezeWaterComponent.EFreezeWaterType> freezeWaterPriorityManager = this.FreezeWaterPriorityManager;
				if (freezeWaterPriorityManager == null)
				{
					return;
				}
				freezeWaterPriorityManager.TryEnter(MotorcycleFreezeWaterComponent.EFreezeWaterType.SetPositionByMaterialParameterCollection, "OnFreezeRunningWaterTagChanged");
				return;
			}
			else
			{
				CustomPriorityManager<MotorcycleFreezeWaterComponent.EFreezeWaterType> freezeWaterPriorityManager2 = this.FreezeWaterPriorityManager;
				if (freezeWaterPriorityManager2 != null)
				{
					freezeWaterPriorityManager2.TryExit(MotorcycleFreezeWaterComponent.EFreezeWaterType.SetPositionByMaterialParameterCollection, "OnFreezeRunningWaterTagChanged");
				}
				CustomPriorityManager<MotorcycleFreezeWaterComponent.EFreezeWaterType> freezeWaterPriorityManager3 = this.FreezeWaterPriorityManager;
				if (freezeWaterPriorityManager3 == null)
				{
					return;
				}
				freezeWaterPriorityManager3.TryEnter(MotorcycleFreezeWaterComponent.EFreezeWaterType.MovementTrailCollision, "OnFreezeRunningWaterTagChanged");
				return;
			}
		}

		// Token: 0x0602F99C RID: 194972 RVA: 0x00B5A935 File Offset: 0x00B58B35
		private bool MovementTrailCollisionEnterCallback(ICustomPriorityCallbackParam param)
		{
			if (this.IsFunctionOpen() && this.DetectedWater)
			{
				this.MovementTrailCollisionHandler(true);
			}
			this.FreezeWaterEnterExitHandler = new Action<bool>(this.MovementTrailCollisionHandler);
			this.FreezeWaterTickHandler = new Action<float, global::Vector, global::Vector>(this.MovementTrailCollisionTickHandler);
			return true;
		}

		// Token: 0x0602F99D RID: 194973 RVA: 0x00B5A973 File Offset: 0x00B58B73
		private bool MovementTrailCollisionExitCallback(ICustomPriorityCallbackParam param)
		{
			this.MovementTrailCollisionHandler(false);
			this.FreezeWaterEnterExitHandler = null;
			this.FreezeWaterTickHandler = null;
			return true;
		}

		// Token: 0x0602F99E RID: 194974 RVA: 0x00B5A98C File Offset: 0x00B58B8C
		private bool SetPositionByMaterialParameterCollectionEnterCallback(ICustomPriorityCallbackParam param)
		{
			if (this.IsFunctionOpen() && ControllerBase<FormationDataController>.Instance.HasPlayerTag(ModelBase<CreatureModel>.Instance.GetPlayerId(), MotorcycleFreezeWaterComponent.freezeRunningWaterTag, false) && this.DetectedWater)
			{
				this.SetPositionByMaterialParameterCollectionHandler(true);
			}
			this.FreezeWaterEnterExitHandler = new Action<bool>(this.SetPositionByMaterialParameterCollectionHandler);
			this.FreezeWaterTickHandler = new Action<float, global::Vector, global::Vector>(this.SetPositionByMaterialParameterCollectionTickHandler);
			return true;
		}

		// Token: 0x0602F99F RID: 194975 RVA: 0x00B5A9F1 File Offset: 0x00B58BF1
		private bool SetPositionByMaterialParameterCollectionExitCallback(ICustomPriorityCallbackParam param)
		{
			this.SetPositionByMaterialParameterCollectionHandler(false);
			this.FreezeWaterEnterExitHandler = null;
			this.FreezeWaterTickHandler = null;
			return true;
		}

		// Token: 0x0602F9A0 RID: 194976 RVA: 0x00B5AA0C File Offset: 0x00B58C0C
		public override bool ClearComponent(EntityComponent componentTemplate)
		{
			if (!base.ClearComponent(componentTemplate))
			{
				return false;
			}
			MotorcycleFreezeWaterComponent motorcycleFreezeWaterComponent = (MotorcycleFreezeWaterComponent)componentTemplate;
			if (base.CanResetComponentProperty("TraceWaterCapability"))
			{
				if (motorcycleFreezeWaterComponent.TraceWaterCapability == null)
				{
					this.TraceWaterCapability = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<MotorcycleTraceWaterCapability>(this.TraceWaterCapability), "TraceWaterCapability"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("FreezeWaterRenderCapability1"))
			{
				if (motorcycleFreezeWaterComponent.FreezeWaterRenderCapability1 == null)
				{
					this.FreezeWaterRenderCapability1 = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<FreezeWaterRenderCapability>(this.FreezeWaterRenderCapability1), "FreezeWaterRenderCapability1"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("MovementTrailCollisionCapability"))
			{
				if (motorcycleFreezeWaterComponent.MovementTrailCollisionCapability == null)
				{
					this.MovementTrailCollisionCapability = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<MovementTrailCollisionCapability>(this.MovementTrailCollisionCapability), "MovementTrailCollisionCapability"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("GameCapabilities") && motorcycleFreezeWaterComponent.GameCapabilities != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<List<WaterDetectedCapability>>(this.GameCapabilities), "GameCapabilities"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("ActorComp"))
			{
				if (motorcycleFreezeWaterComponent.ActorComp == null)
				{
					this.ActorComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<MotorcycleActorComponent>(this.ActorComp), "ActorComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("MoveComp"))
			{
				if (motorcycleFreezeWaterComponent.MoveComp == null)
				{
					this.MoveComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<MotorcycleMoveComponent>(this.MoveComp), "MoveComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("TagComp"))
			{
				if (motorcycleFreezeWaterComponent.TagComp == null)
				{
					this.TagComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BaseTagComponent>(this.TagComp), "TagComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("InteractionComp"))
			{
				if (motorcycleFreezeWaterComponent.InteractionComp == null)
				{
					this.InteractionComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<UKuroEnviInteractionComponent>(this.InteractionComp), "InteractionComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("OriginMotorcycleToKuroWaterCollisionResponse"))
			{
				this.OriginMotorcycleToKuroWaterCollisionResponse = motorcycleFreezeWaterComponent.OriginMotorcycleToKuroWaterCollisionResponse;
			}
			if (base.CanResetComponentProperty("KuroTrailCollisionAsset"))
			{
				if (motorcycleFreezeWaterComponent.KuroTrailCollisionAsset == null)
				{
					this.KuroTrailCollisionAsset = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<UKuroTrailCollisionAsset>(this.KuroTrailCollisionAsset), "KuroTrailCollisionAsset"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("InNavWaterAreaInternal"))
			{
				this.InNavWaterAreaInternal = motorcycleFreezeWaterComponent.InNavWaterAreaInternal;
			}
			if (base.CanResetComponentProperty("DetectedWaterInternal"))
			{
				this.DetectedWaterInternal = motorcycleFreezeWaterComponent.DetectedWaterInternal;
			}
			if (base.CanResetComponentProperty("TempWheelHitResults"))
			{
				if (motorcycleFreezeWaterComponent.TempWheelHitResults == null)
				{
					this.TempWheelHitResults = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<int, FHitResult>>(this.TempWheelHitResults), "TempWheelHitResults"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("WheelHitResults"))
			{
				if (motorcycleFreezeWaterComponent.WheelHitResults == null)
				{
					this.WheelHitResults = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<int, FHitResult>>(this.WheelHitResults), "WheelHitResults"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("IsAutonomousProxy"))
			{
				this.IsAutonomousProxy = motorcycleFreezeWaterComponent.IsAutonomousProxy;
			}
			if (base.CanResetComponentProperty("KuroTrailCollisionAssetPath"))
			{
				this.KuroTrailCollisionAssetPath = motorcycleFreezeWaterComponent.KuroTrailCollisionAssetPath;
			}
			if (base.CanResetComponentProperty("FreezeWaterEffectTagToContexts") && motorcycleFreezeWaterComponent.FreezeWaterEffectTagToContexts != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<int, List<MotorcycleFreezeWaterComponent.IEffectContext>>>(this.FreezeWaterEffectTagToContexts), "FreezeWaterEffectTagToContexts"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("TagTasks") && motorcycleFreezeWaterComponent.TagTasks != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<List<ITagTask>>(this.TagTasks), "TagTasks"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("FreezeRunningWaterTagTask"))
			{
				if (motorcycleFreezeWaterComponent.FreezeRunningWaterTagTask == null)
				{
					this.FreezeRunningWaterTagTask = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<ITagTask>(this.FreezeRunningWaterTagTask), "FreezeRunningWaterTagTask"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("FreezeWaterPriorityManager"))
			{
				if (motorcycleFreezeWaterComponent.FreezeWaterPriorityManager == null)
				{
					this.FreezeWaterPriorityManager = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CustomPriorityManager<MotorcycleFreezeWaterComponent.EFreezeWaterType>>(this.FreezeWaterPriorityManager), "FreezeWaterPriorityManager"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("IsFunctionOpenOverride"))
			{
				this.IsFunctionOpenOverride = motorcycleFreezeWaterComponent.IsFunctionOpenOverride;
			}
			if (base.CanResetComponentProperty("FreezeWaterEnterExitHandler"))
			{
				if (motorcycleFreezeWaterComponent.FreezeWaterEnterExitHandler == null)
				{
					this.FreezeWaterEnterExitHandler = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Action<bool>>(this.FreezeWaterEnterExitHandler), "FreezeWaterEnterExitHandler"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("FreezeWaterTickHandler"))
			{
				if (motorcycleFreezeWaterComponent.FreezeWaterTickHandler == null)
				{
					this.FreezeWaterTickHandler = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Action<float, global::Vector, global::Vector>>(this.FreezeWaterTickHandler), "FreezeWaterTickHandler"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("EffectSystemContext"))
			{
				if (motorcycleFreezeWaterComponent.EffectSystemContext == null)
				{
					this.EffectSystemContext = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<EffectContext>(this.EffectSystemContext), "EffectSystemContext"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("TmpVector"))
			{
				if (motorcycleFreezeWaterComponent.TmpVector == null)
				{
					this.TmpVector = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.TmpVector), "TmpVector"))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x0401B399 RID: 111513
		private const string LOAD_BP_TYPE = "LoadBPType";

		// Token: 0x0401B39A RID: 111514
		private const string LOAD_KURO_TRAIL_COLLISION_ASSET = "LoadKuroTrailCollisionAsset";

		// Token: 0x0401B39B RID: 111515
		private const string CREATE_DEPENDENCY = "CreateDependency";

		// Token: 0x0401B39C RID: 111516
		[StaticVariableRuleIgnore]
		private static int freezeWaterEffectTag = GameplayTagDefine.EGameplayTagId["载具.摩托.移动.冻结水面.特效1"];

		// Token: 0x0401B39D RID: 111517
		[StaticVariableRuleIgnore]
		private static int freezeMotorSlideEffectTag = GameplayTagDefine.EGameplayTagId["载具.摩托.移动.冻结水面.特效2"];

		// Token: 0x0401B39E RID: 111518
		[StaticVariableRuleIgnore]
		private static int freezeRunningWaterTag = GameplayTagDefine.EGameplayTagId["角色.Common.载具驾驶.摩托.冰面行驶.启用流体冰面"];

		// Token: 0x0401B39F RID: 111519
		[Nullable(2)]
		private MotorcycleTraceWaterCapability TraceWaterCapability;

		// Token: 0x0401B3A0 RID: 111520
		[Nullable(2)]
		private FreezeWaterRenderCapability FreezeWaterRenderCapability1;

		// Token: 0x0401B3A1 RID: 111521
		[Nullable(2)]
		private MovementTrailCollisionCapability MovementTrailCollisionCapability;

		// Token: 0x0401B3A2 RID: 111522
		private readonly List<WaterDetectedCapability> GameCapabilities = new List<WaterDetectedCapability>();

		// Token: 0x0401B3A3 RID: 111523
		[Nullable(2)]
		private MotorcycleActorComponent ActorComp;

		// Token: 0x0401B3A4 RID: 111524
		[Nullable(2)]
		private MotorcycleMoveComponent MoveComp;

		// Token: 0x0401B3A5 RID: 111525
		[Nullable(2)]
		private BaseTagComponent TagComp;

		// Token: 0x0401B3A6 RID: 111526
		[Nullable(2)]
		private UKuroEnviInteractionComponent InteractionComp;

		// Token: 0x0401B3A7 RID: 111527
		private ECollisionResponse? OriginMotorcycleToKuroWaterCollisionResponse;

		// Token: 0x0401B3A8 RID: 111528
		[Nullable(2)]
		protected UKuroTrailCollisionAsset KuroTrailCollisionAsset;

		// Token: 0x0401B3A9 RID: 111529
		private bool InNavWaterAreaInternal;

		// Token: 0x0401B3AA RID: 111530
		private bool DetectedWaterInternal;

		// Token: 0x0401B3AB RID: 111531
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Dictionary<int, FHitResult> TempWheelHitResults;

		// Token: 0x0401B3AC RID: 111532
		[Nullable(2)]
		private Dictionary<int, FHitResult> WheelHitResults;

		// Token: 0x0401B3AD RID: 111533
		private bool IsAutonomousProxy;

		// Token: 0x0401B3AE RID: 111534
		[StaticVariableRuleIgnore]
		private static readonly MotorcycleFreezeWaterComponent.IEffectConfig[] FreezeWaterEffectConfigs = new MotorcycleFreezeWaterComponent.IEffectConfig[]
		{
			new MotorcycleFreezeWaterComponent.EffectConfigImpl
			{
				Config = "FreezeWaterEffect",
				TagId = MotorcycleFreezeWaterComponent.freezeWaterEffectTag
			},
			new MotorcycleFreezeWaterComponent.EffectConfigImpl
			{
				Config = "FreezeMotorSlideEffect",
				TagId = MotorcycleFreezeWaterComponent.freezeMotorSlideEffectTag
			}
		};

		// Token: 0x0401B3AF RID: 111535
		private string KuroTrailCollisionAssetPath = "";

		// Token: 0x0401B3B0 RID: 111536
		private readonly Dictionary<int, List<MotorcycleFreezeWaterComponent.IEffectContext>> FreezeWaterEffectTagToContexts = new Dictionary<int, List<MotorcycleFreezeWaterComponent.IEffectContext>>();

		// Token: 0x0401B3B1 RID: 111537
		private readonly List<ITagTask> TagTasks = new List<ITagTask>();

		// Token: 0x0401B3B2 RID: 111538
		[Nullable(2)]
		private ITagTask FreezeRunningWaterTagTask;

		// Token: 0x0401B3B3 RID: 111539
		[Nullable(2)]
		private CustomPriorityManager<MotorcycleFreezeWaterComponent.EFreezeWaterType> FreezeWaterPriorityManager;

		// Token: 0x0401B3B4 RID: 111540
		private bool? IsFunctionOpenOverride;

		// Token: 0x0401B3B5 RID: 111541
		[Nullable(2)]
		private Action<bool> FreezeWaterEnterExitHandler;

		// Token: 0x0401B3B6 RID: 111542
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private Action<float, global::Vector, global::Vector> FreezeWaterTickHandler;

		// Token: 0x0401B3B7 RID: 111543
		[Nullable(2)]
		private EffectContext EffectSystemContext;

		// Token: 0x0401B3B8 RID: 111544
		[StaticVariableRuleIgnore]
		private global::Vector TmpVector = global::Vector.Create();

		// Token: 0x0200A895 RID: 43157
		public interface IEffectContext
		{
			// Token: 0x1700A90B RID: 43275
			// (get) Token: 0x0604AF7A RID: 307066
			// (set) Token: 0x0604AF7B RID: 307067
			string AssetPath { get; set; }

			// Token: 0x1700A90C RID: 43276
			// (get) Token: 0x0604AF7C RID: 307068
			// (set) Token: 0x0604AF7D RID: 307069
			string ComponentName { get; set; }

			// Token: 0x1700A90D RID: 43277
			// (get) Token: 0x0604AF7E RID: 307070
			// (set) Token: 0x0604AF7F RID: 307071
			FName Socket { get; set; }

			// Token: 0x1700A90E RID: 43278
			// (get) Token: 0x0604AF80 RID: 307072
			// (set) Token: 0x0604AF81 RID: 307073
			int? EffectHandleId { get; set; }
		}

		// Token: 0x0200A896 RID: 43158
		[Nullable(0)]
		public class EffectContextImpl : MotorcycleFreezeWaterComponent.IEffectContext
		{
			// Token: 0x1700A90F RID: 43279
			// (get) Token: 0x0604AF82 RID: 307074 RVA: 0x0146847E File Offset: 0x0146667E
			// (set) Token: 0x0604AF83 RID: 307075 RVA: 0x01468486 File Offset: 0x01466686
			public string AssetPath { get; set; }

			// Token: 0x1700A910 RID: 43280
			// (get) Token: 0x0604AF84 RID: 307076 RVA: 0x0146848F File Offset: 0x0146668F
			// (set) Token: 0x0604AF85 RID: 307077 RVA: 0x01468497 File Offset: 0x01466697
			public string ComponentName { get; set; }

			// Token: 0x1700A911 RID: 43281
			// (get) Token: 0x0604AF86 RID: 307078 RVA: 0x014684A0 File Offset: 0x014666A0
			// (set) Token: 0x0604AF87 RID: 307079 RVA: 0x014684A8 File Offset: 0x014666A8
			public FName Socket { get; set; }

			// Token: 0x1700A912 RID: 43282
			// (get) Token: 0x0604AF88 RID: 307080 RVA: 0x014684B1 File Offset: 0x014666B1
			// (set) Token: 0x0604AF89 RID: 307081 RVA: 0x014684B9 File Offset: 0x014666B9
			public int? EffectHandleId { get; set; }
		}

		// Token: 0x0200A897 RID: 43159
		public interface IEffectConfig
		{
			// Token: 0x1700A913 RID: 43283
			// (get) Token: 0x0604AF8B RID: 307083
			// (set) Token: 0x0604AF8C RID: 307084
			string Config { get; set; }

			// Token: 0x1700A914 RID: 43284
			// (get) Token: 0x0604AF8D RID: 307085
			// (set) Token: 0x0604AF8E RID: 307086
			int TagId { get; set; }

			// Token: 0x1700A915 RID: 43285
			// (get) Token: 0x0604AF8F RID: 307087
			// (set) Token: 0x0604AF90 RID: 307088
			[Nullable(2)]
			string EffectPath { [NullableContext(2)] get; [NullableContext(2)] set; }
		}

		// Token: 0x0200A898 RID: 43160
		[Nullable(0)]
		public class EffectConfigImpl : MotorcycleFreezeWaterComponent.IEffectConfig
		{
			// Token: 0x1700A916 RID: 43286
			// (get) Token: 0x0604AF91 RID: 307089 RVA: 0x014684CA File Offset: 0x014666CA
			// (set) Token: 0x0604AF92 RID: 307090 RVA: 0x014684D2 File Offset: 0x014666D2
			public string Config { get; set; }

			// Token: 0x1700A917 RID: 43287
			// (get) Token: 0x0604AF93 RID: 307091 RVA: 0x014684DB File Offset: 0x014666DB
			// (set) Token: 0x0604AF94 RID: 307092 RVA: 0x014684E3 File Offset: 0x014666E3
			public int TagId { get; set; }

			// Token: 0x1700A918 RID: 43288
			// (get) Token: 0x0604AF95 RID: 307093 RVA: 0x014684EC File Offset: 0x014666EC
			// (set) Token: 0x0604AF96 RID: 307094 RVA: 0x014684F4 File Offset: 0x014666F4
			[Nullable(2)]
			public string EffectPath { [NullableContext(2)] get; [NullableContext(2)] set; }
		}

		// Token: 0x0200A899 RID: 43161
		[NullableContext(0)]
		public enum EFreezeWaterType
		{
			// Token: 0x040344F6 RID: 214262
			SetPositionByMaterialParameterCollection,
			// Token: 0x040344F7 RID: 214263
			MovementTrailCollision
		}

		// Token: 0x0200A89B RID: 43163
		[CompilerGenerated]
		private static class <>O
		{
			// Token: 0x040344FB RID: 214267
			[Nullable(0)]
			public static Func<UniTask> <0>__LoadBlueprintTypeAsync;
		}
	}
}
