using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Effect.WaterInteraction;
using AkiClient.Game.Aki.Scene.Assets.PCG.BP_Tools.RippleSwim;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Effect;
using CSharpScript.Game.Utils;
using UnrealEngine;

namespace CSharpScript.Game.Render
{
	// Token: 0x0200478B RID: 18315
	[NullableContext(1)]
	[Nullable(0)]
	public class SceneCharacterWaterEffect
	{
		// Token: 0x0602F830 RID: 194608 RVA: 0x00B4ECE8 File Offset: 0x00B4CEE8
		public void Start(TsBaseCharacter owner)
		{
			if (this.Config == null || !this.Config.IsValid() || !owner.IsValid())
			{
				return;
			}
			this.Owner = owner;
			this.OwnerHeight = ((this.Owner.CapsuleComponent != null) ? (this.Owner.CapsuleComponent.CapsuleHalfHeight * 2f) : 0f);
			this.InWaterSubConfig.Init(this.Config.WaterEffectConfig);
			this.SwimIdleEffect = this.Config.SwimIdleEffectRef;
			this.SwimNormalEffect = this.Config.SwimNormalEffectRef;
			this.SwimFastEffect = this.Config.SwimFastEffectRef;
			this.VehicleEffect = new SceneCharacterVehicleEffect();
			this.VehicleEffect.Start(owner);
			this.VehicleEffect.Enable();
			int num = this.Config.MaterialEffectConfig.Num();
			for (int i = 0; i < num; i++)
			{
				UPhysicalMaterial key = this.Config.MaterialEffectConfig.GetKey(i);
				SWaterEffectSubConfig swaterEffectSubConfig = this.Config.MaterialEffectConfig.Get(key);
				if (swaterEffectSubConfig != null)
				{
					WaterEffectSubConfig waterEffectSubConfig = new WaterEffectSubConfig();
					waterEffectSubConfig.Init(swaterEffectSubConfig);
					this.OnMaterialSubConfig[key] = waterEffectSubConfig;
				}
			}
			int size = 12;
			this.VelocityHistory.Initialize(size);
			this.IsReady = true;
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.RenderEffect;
			ELogAuthor author = ELogAuthor.LSY;
			string message = "WaterEffect Start";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Owner", owner);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}

		// Token: 0x0602F831 RID: 194609 RVA: 0x00B4EE60 File Offset: 0x00B4D060
		public void Enable()
		{
			if (!this.IsReady)
			{
				return;
			}
			CharacterActorComponent characterActorComponent = this.Owner.CharacterActorComponent;
			CharacterUnifiedStateComponent ownerStateComponent;
			if (characterActorComponent == null)
			{
				ownerStateComponent = null;
			}
			else
			{
				Entity entity = characterActorComponent.Entity;
				ownerStateComponent = ((entity != null) ? entity.GetComponent<CharacterUnifiedStateComponent>() : null);
			}
			this.OwnerStateComponent = ownerStateComponent;
			this.WetController = (this.Owner.GetComponentByClass(UKuroCharWetControllerComponent.StaticClass()) as UKuroCharWetControllerComponent);
			this.WetStateTagId = GameplayTagUtils.GetTagIdByName("TA.表现.角色.状态效果.湿身");
			this.LastWetStateTagActive = false;
			this.IsEnabled = true;
			this.ShoreTraceElement = new UTraceSphereElement();
			this.ShoreTraceElement.bIsSingle = true;
			this.ShoreTraceElement.bTraceComplex = false;
			this.ShoreTraceElement.bIgnoreSelf = true;
			this.ShoreTraceElement.WorldContextObject = this.Owner;
			this.ShoreTraceElement.Radius = 50f;
			this.ShoreTraceElement.SetTraceTypeQuery(KuroTraceTypeQuery.Water);
			if (UKismetSystemLibrary.GetConsoleVariableFloatValue("r.Kuro.InteractionEffect.IESystemDebugDraw") > 0f)
			{
				this.ShoreTraceElement.SetDrawDebugTrace(EDrawDebugTrace.ForOneFrame);
				Singleton<TraceElementCommon>.Instance.SetTraceColor(this.ShoreTraceElement, new FLinearColor(255f, 255f, 0f, 1f));
				Singleton<TraceElementCommon>.Instance.SetTraceHitColor(this.ShoreTraceElement, new FLinearColor(0f, 255f, 0f, 1f));
			}
			this.ShoreTraceDelegate = new FAsyncTraceDelegate();
			this.ShoreTraceDelegate.Bind(new Action<bool, UTraceBaseElement, double, double>(this.SetShoreTraceState));
			CharacterActorComponent characterActorComponent2 = this.Owner.CharacterActorComponent;
			Entity entity2 = (characterActorComponent2 != null) ? characterActorComponent2.Entity : null;
			if (entity2 != null)
			{
				Singleton<EventSystem>.Instance.AddWithTarget<bool>(entity2, EEventName.OnCharFootOnTheGround, new Action<bool>(this.OnOwnerCharFootOnTheGround));
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.RenderEffect;
			ELogAuthor author = ELogAuthor.LSY;
			string message = "WaterEffect Enabled";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Owner", this.Owner);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}

		// Token: 0x0602F832 RID: 194610 RVA: 0x00B4F034 File Offset: 0x00B4D234
		public void Disable()
		{
			if (!this.IsEnabled)
			{
				return;
			}
			TsBaseCharacter owner = this.Owner;
			Entity entity;
			if (owner == null)
			{
				entity = null;
			}
			else
			{
				CharacterActorComponent characterActorComponent = owner.CharacterActorComponent;
				entity = ((characterActorComponent != null) ? characterActorComponent.Entity : null);
			}
			Entity entity2 = entity;
			if (entity2 != null)
			{
				Singleton<EventSystem>.Instance.RemoveWithTarget<bool>(entity2, EEventName.OnCharFootOnTheGround, new Action<bool>(this.OnOwnerCharFootOnTheGround));
			}
			if (Singleton<EffectSystem>.Instance.IsValid(this.Handle))
			{
				Singleton<EffectSystem>.Instance.StopEffectById(this.Handle, "[SceneCharacterWaterEffect.Disable]", true, null);
				this.Handle = 0;
			}
			if (Singleton<EffectSystem>.Instance.IsValid(this.AudioEffectHandle))
			{
				Singleton<EffectSystem>.Instance.StopEffectById(this.AudioEffectHandle, "[SceneCharacterWaterEffect.Disable]", true, null);
				this.AudioEffectHandle = 0;
			}
			if (this.VehicleEffect != null)
			{
				this.VehicleEffect.Disable();
			}
			if (this.LastWetStateTagActive)
			{
				TsBaseCharacter owner2 = this.Owner;
				object obj;
				if (owner2 == null)
				{
					obj = null;
				}
				else
				{
					CharacterActorComponent characterActorComponent2 = owner2.CharacterActorComponent;
					if (characterActorComponent2 == null)
					{
						obj = null;
					}
					else
					{
						Entity entity3 = characterActorComponent2.Entity;
						obj = ((entity3 != null) ? entity3.GetComponent<BaseTagComponent>() : null);
					}
				}
				object obj2 = obj;
				if (obj2 != null)
				{
					obj2.RemoveTag(new int?(this.WetStateTagId));
				}
				this.LastWetStateTagActive = false;
			}
			this.WetController = null;
			this.IsEnabled = false;
			UTraceSphereElement shoreTraceElement = this.ShoreTraceElement;
			if (shoreTraceElement != null)
			{
				shoreTraceElement.Dispose();
			}
			this.ShoreTraceElement = null;
			this.ShoreTraceDelegate = null;
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.RenderEffect;
			ELogAuthor author = ELogAuthor.LSY;
			string message = "WaterEffect Disabled";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Owner", this.Owner);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}

		// Token: 0x0602F833 RID: 194611 RVA: 0x00B4F1B8 File Offset: 0x00B4D3B8
		public void Tick()
		{
			if (!this.IsEnabled)
			{
				return;
			}
			this.UpdateWetStateTag();
			if (this.VehicleEffect != null)
			{
				this.VehicleEffect.Tick();
			}
			CharacterActorComponent characterActorComponent = this.Owner.CharacterActorComponent;
			CharacterMoveComponent characterMoveComponent;
			if (characterActorComponent == null)
			{
				characterMoveComponent = null;
			}
			else
			{
				Entity entity = characterActorComponent.Entity;
				characterMoveComponent = ((entity != null) ? entity.GetComponent<CharacterMoveComponent>() : null);
			}
			CharacterMoveComponent characterMoveComponent2 = characterMoveComponent;
			if (characterMoveComponent2 != null)
			{
				Vector inB = Vector.Create(this.CurrentWaterNormal.X, this.CurrentWaterNormal.Y, -this.CurrentWaterNormal.Z);
				if (characterMoveComponent2.GravityDirect.DotProduct(inB) < 0.20000000298023224)
				{
					return;
				}
			}
			CharacterActorComponent characterActorComponent2 = this.Owner.CharacterActorComponent;
			object obj;
			if (characterActorComponent2 == null)
			{
				obj = null;
			}
			else
			{
				Entity entity2 = characterActorComponent2.Entity;
				obj = ((entity2 != null) ? entity2.GetComponent<CharacterBuffComponent>() : null);
			}
			object obj2 = obj;
			if (((obj2 != null) ? obj2.GetBuffById(640003011L) : null) != null)
			{
				return;
			}
			CharacterActorComponent characterActorComponent3 = this.Owner.CharacterActorComponent;
			object obj3;
			if (characterActorComponent3 == null)
			{
				obj3 = null;
			}
			else
			{
				Entity entity3 = characterActorComponent3.Entity;
				obj3 = ((entity3 != null) ? entity3.GetComponent<BaseTagComponent>() : null);
			}
			object obj4 = obj3;
			if (obj4 != null && obj4.HasTag(GameplayTagDefine.EGameplayTagId["GameplayEffect.ShieldWaterMoveEffect"]))
			{
				return;
			}
			if (Singleton<EffectSystem>.Instance.IsValid(this.Handle) && !this.IsBlackWave && !this.FindNoWaterPhysicalMaterial)
			{
				Singleton<EffectSystem>.Instance.HandleSeekToTime(this.Handle, (float)this.CurrentSpeed, false, false);
				OneOf<KuroEffectActorHandle, AActor> effectActor = Singleton<EffectSystem>.Instance.GetEffectActor(this.Handle);
				Vector currentWaterLocation = this.CurrentWaterLocation;
				currentWaterLocation.X = this.Owner.D_K2_GetActorLocation().X;
				currentWaterLocation.Y = this.Owner.D_K2_GetActorLocation().Y;
				FVectorDouble fvectorDouble = currentWaterLocation.ToUeVector(false);
				effectActor.D_K2_SetActorLocation(fvectorDouble, false, ref Singleton<PhysicsUtils>.Instance.DefaultHitResult, true);
				FVectorDouble fvectorDouble2 = this.CurrentWaterNormal.ToUeVector(false);
				FVectorDouble fvectorDouble3 = this.Owner.D_GetActorForwardVector();
				FVectorDouble fvectorDouble4 = UKismetMathLibrary.D_Cross_VectorVector(fvectorDouble2, fvectorDouble3);
				fvectorDouble3 = UKismetMathLibrary.D_Cross_VectorVector(fvectorDouble4, fvectorDouble2);
				FRotator frotator = UKismetMathLibrary.D_MakeRotationFromAxes(fvectorDouble3, fvectorDouble4, fvectorDouble2);
				effectActor.K2_SetActorRotation(frotator, true);
				if (Singleton<EffectSystem>.Instance.IsValid(this.AudioEffectHandle))
				{
					OneOf<KuroEffectActorHandle, AActor> effectActor2 = Singleton<EffectSystem>.Instance.GetEffectActor(this.AudioEffectHandle);
					fvectorDouble = this.CurrentWaterLocation.ToUeVector(false);
					effectActor2.D_K2_SetActorLocation(fvectorDouble, false, ref Singleton<PhysicsUtils>.Instance.DefaultHitResult, true);
				}
			}
			if (this.OwnerHeight > 0f)
			{
				float value = Singleton<MathUtils>.Instance.Clamp((float)(this.CurrentWaterDepth / (double)this.OwnerHeight), 0f, 1f);
				Singleton<AudioSystem>.Instance.SetRtpcValue("amb_water_depth", value, new SetRtpcValueArgs?(new SetRtpcValueArgs
				{
					Actor = this.Owner
				}));
			}
		}

		// Token: 0x0602F834 RID: 194612 RVA: 0x00B4F454 File Offset: 0x00B4D654
		protected void UpdateWetStateTag()
		{
			if (this.WetController == null || !this.WetController.IsValid() || this.WetStateTagId == 0)
			{
				return;
			}
			bool bWetStateTagActive = this.WetController.bWetStateTagActive;
			if (bWetStateTagActive == this.LastWetStateTagActive)
			{
				return;
			}
			this.LastWetStateTagActive = bWetStateTagActive;
			TsBaseCharacter owner = this.Owner;
			BaseTagComponent baseTagComponent;
			if (owner == null)
			{
				baseTagComponent = null;
			}
			else
			{
				CharacterActorComponent characterActorComponent = owner.CharacterActorComponent;
				if (characterActorComponent == null)
				{
					baseTagComponent = null;
				}
				else
				{
					Entity entity = characterActorComponent.Entity;
					baseTagComponent = ((entity != null) ? entity.GetComponent<BaseTagComponent>() : null);
				}
			}
			BaseTagComponent baseTagComponent2 = baseTagComponent;
			if (baseTagComponent2 == null)
			{
				return;
			}
			if (bWetStateTagActive)
			{
				baseTagComponent2.AddTag(new int?(this.WetStateTagId));
				return;
			}
			baseTagComponent2.RemoveTag(new int?(this.WetStateTagId));
		}

		// Token: 0x0602F835 RID: 194613 RVA: 0x00B4F4F4 File Offset: 0x00B4D6F4
		public bool IsMaterialInUse(UPhysicalMaterial physicalMaterial)
		{
			WaterEffectSubConfig waterEffectSubConfig;
			return this.OnMaterialSubConfig.TryGetValue(physicalMaterial, out waterEffectSubConfig) && (!waterEffectSubConfig.TriggerInGrass || Singleton<RenderDataManager>.Instance.GetPlayerInGrass());
		}

		// Token: 0x0602F836 RID: 194614 RVA: 0x00B4F528 File Offset: 0x00B4D728
		public void SetStateNone(Vector velocity)
		{
			if (!this.IsEnabled)
			{
				return;
			}
			this.VelocityHistory.AddVelocity(velocity);
			this.CurrentSpeed = velocity.Size();
			if (this.State != EWaterEffectState.None)
			{
				if (this.CurrentSubConfig != null)
				{
					this.OnCharacterJumpOutWater(velocity, this.CurrentWaterLocation, this.CurrentWaterNormal, this.CurrentSubConfig, this.CurrentWaterDepth);
				}
				this.StopEffect();
				this.CurrentSubConfig = null;
				this.State = EWaterEffectState.None;
			}
			if (this.VehicleEffect != null)
			{
				this.VehicleEffect.IsVehicleWaterState = false;
			}
		}

		// Token: 0x0602F837 RID: 194615 RVA: 0x00B4F5B0 File Offset: 0x00B4D7B0
		public void SetStateInWater(double waterDepth, Vector waterNormal, Vector velocity, Vector location, double waterHeight)
		{
			if (!this.IsEnabled)
			{
				return;
			}
			CharacterActorComponent characterActorComponent = this.Owner.CharacterActorComponent;
			CharacterDriveVehicleComponent characterDriveVehicleComponent;
			if (characterActorComponent == null)
			{
				characterDriveVehicleComponent = null;
			}
			else
			{
				Entity entity = characterActorComponent.Entity;
				characterDriveVehicleComponent = ((entity != null) ? entity.GetComponent<CharacterDriveVehicleComponent>() : null);
			}
			CharacterDriveVehicleComponent characterDriveVehicleComponent2 = characterDriveVehicleComponent;
			if (characterDriveVehicleComponent2 != null && characterDriveVehicleComponent2.IsOnVehicle)
			{
				this.SetStateNone(velocity);
				return;
			}
			this.CurrentWaterDepth = waterDepth;
			this.CurrentWaterLocation.Set(location.X, location.Y, waterHeight);
			this.CurrentWaterNormal = waterNormal;
			this.VelocityHistory.AddVelocity(velocity);
			this.CurrentSpeed = velocity.Size();
			if (this.State == EWaterEffectState.None)
			{
				this.OnCharacterFallInWater(velocity, this.CurrentWaterLocation, waterNormal, this.InWaterSubConfig, waterDepth);
			}
			CharacterUnifiedStateComponent ownerStateComponent = this.OwnerStateComponent;
			ECharMoveState? echarMoveState = (ownerStateComponent != null) ? new ECharMoveState?(ownerStateComponent.MoveState) : null;
			if (echarMoveState.GetValueOrDefault() == ECharMoveState.NormalSwim)
			{
				this.SpawnEffect(this.SwimNormalEffect, null, location, false);
			}
			else if (echarMoveState.GetValueOrDefault() == ECharMoveState.FastSwim)
			{
				this.SpawnEffect(this.SwimFastEffect, null, location, false);
			}
			else
			{
				this.WadeMoveSearchSpeed = this.CurrentSpeed;
				WaterEffectItem waterEffectItem = this.InWaterSubConfig.FindWadeMoveEffect(waterDepth, this.WadeMoveSearchSpeed);
				if (waterEffectItem != null)
				{
					this.SpawnEffect(waterEffectItem.EffectDataPath, waterEffectItem.AudioEffectDataPath, location, false);
				}
				else if (this.InWaterSubConfig.ShouldUseShallowFootSplashes(waterDepth))
				{
					this.StopEffect();
				}
				else
				{
					if (waterDepth > (double)this.InWaterSubConfig.FallJumpDepthThreshold)
					{
						ECharMoveState? echarMoveState2 = echarMoveState;
						ECharMoveState echarMoveState3 = ECharMoveState.Other;
						if (echarMoveState2.GetValueOrDefault() == echarMoveState3 & echarMoveState2 != null)
						{
							this.SpawnEffect(this.SwimIdleEffect, null, location, false);
							goto IL_18E;
						}
					}
					this.StopEffect();
				}
			}
			IL_18E:
			this.CurrentSubConfig = this.InWaterSubConfig;
			this.State = EWaterEffectState.InWater;
		}

		// Token: 0x0602F838 RID: 194616 RVA: 0x00B4F760 File Offset: 0x00B4D960
		public void SetStateInWaterEnviData([Nullable(2)] FKuroEnviInteractionData enviData, Vector velocity, Vector location)
		{
			if (!this.IsEnabled || enviData == null)
			{
				return;
			}
			this.EIData = enviData;
			CharacterActorComponent characterActorComponent = this.Owner.CharacterActorComponent;
			CharacterDriveVehicleComponent characterDriveVehicleComponent;
			if (characterActorComponent == null)
			{
				characterDriveVehicleComponent = null;
			}
			else
			{
				Entity entity = characterActorComponent.Entity;
				characterDriveVehicleComponent = ((entity != null) ? entity.GetComponent<CharacterDriveVehicleComponent>() : null);
			}
			CharacterDriveVehicleComponent characterDriveVehicleComponent2 = characterDriveVehicleComponent;
			if (characterDriveVehicleComponent2 != null && characterDriveVehicleComponent2.IsOnVehicle && !this.IsMotorState)
			{
				this.SetStateNone(velocity);
				return;
			}
			this.CurrentWaterDepth = (double)enviData.WaterDepth;
			this.CurrentWaterLocation.Set(location.X, location.Y, (double)enviData.HitWaterLocation.Z);
			this.CurrentWaterNormal.Set((double)enviData.HitWaterNormal.X, (double)enviData.HitWaterNormal.Y, (double)enviData.HitWaterNormal.Z);
			this.VelocityHistory.AddVelocity(velocity);
			this.CurrentSpeed = velocity.Size();
			if (this.State == EWaterEffectState.None)
			{
				this.OnCharacterFallInWater(velocity, this.CurrentWaterLocation, this.CurrentWaterNormal, this.InWaterSubConfig, this.CurrentWaterDepth);
			}
			if (this.IsMotorState)
			{
				if (this.VehicleEffect != null)
				{
					this.VehicleEffect.IsVehicleWaterState = true;
					this.VehicleEffect.SetStateInWaterEnviData(enviData);
				}
				this.StopEffect();
			}
			else
			{
				CharacterUnifiedStateComponent ownerStateComponent = this.OwnerStateComponent;
				ECharMoveState? echarMoveState = (ownerStateComponent != null) ? new ECharMoveState?(ownerStateComponent.MoveState) : null;
				if (echarMoveState.GetValueOrDefault() == ECharMoveState.NormalSwim)
				{
					this.SpawnEffect(this.SwimNormalEffect, null, location, false);
				}
				else if (echarMoveState.GetValueOrDefault() == ECharMoveState.FastSwim)
				{
					this.SpawnEffect(this.SwimFastEffect, null, location, false);
				}
				else
				{
					Vector currentWaterNormal = this.CurrentWaterNormal;
					currentWaterNormal.GetSafeNormal(currentWaterNormal, 9.99999993922529E-09);
					double num = velocity.DotProduct(currentWaterNormal);
					double num2 = Math.Sqrt(this.CurrentSpeed * this.CurrentSpeed - num * num);
					this.WadeMoveSearchSpeed = num2;
					WaterEffectItem waterEffectItem = this.InWaterSubConfig.FindWadeMoveEffect(this.CurrentWaterDepth, num2);
					if (waterEffectItem != null)
					{
						this.SpawnEffect(waterEffectItem.EffectDataPath, waterEffectItem.AudioEffectDataPath, location, false);
					}
					else if (this.InWaterSubConfig.ShouldUseShallowFootSplashes(this.CurrentWaterDepth))
					{
						this.StopEffect();
					}
					else
					{
						if (this.CurrentWaterDepth > (double)this.InWaterSubConfig.FallJumpDepthThreshold)
						{
							ECharMoveState? echarMoveState2 = echarMoveState;
							ECharMoveState echarMoveState3 = ECharMoveState.Other;
							if (echarMoveState2.GetValueOrDefault() == echarMoveState3 & echarMoveState2 != null)
							{
								this.SpawnEffect(this.SwimIdleEffect, null, location, false);
								goto IL_25A;
							}
						}
						this.StopEffect();
					}
				}
				IL_25A:
				if (this.VehicleEffect != null)
				{
					this.VehicleEffect.IsVehicleWaterState = false;
				}
				this.CurrentSubConfig = this.InWaterSubConfig;
			}
			this.State = EWaterEffectState.InWater;
		}

		// Token: 0x0602F839 RID: 194617 RVA: 0x00B4F9F0 File Offset: 0x00B4DBF0
		public void SetStateOnMaterialEnviData(UPhysicalMaterial material, Vector velocity, Vector location, [Nullable(2)] FKuroEnviInteractionData enviData)
		{
			this.EIData = enviData;
			WaterEffectSubConfig valueOrDefault = this.OnMaterialSubConfig.GetValueOrDefault(material);
			if (valueOrDefault == null)
			{
				this.SetStateNone(velocity);
				return;
			}
			if (this.VehicleEffect != null)
			{
				this.VehicleEffect.IsVehicleWaterState = false;
			}
			CharacterUnifiedStateComponent ownerStateComponent = this.OwnerStateComponent;
			if (((ownerStateComponent != null) ? new ECharMoveState?(ownerStateComponent.MoveState) : null).GetValueOrDefault() == ECharMoveState.Soar)
			{
				return;
			}
			this.CurrentWaterDepth = (double)enviData.WaterDepth;
			this.CurrentWaterLocation.Set(location.X, location.Y, (double)enviData.HitWaterLocationWithOffset.Z);
			this.CurrentWaterNormal.Set((double)enviData.HitWaterNormal.X, (double)enviData.HitWaterNormal.Y, (double)enviData.HitWaterNormal.Z);
			this.VelocityHistory.AddVelocity(velocity);
			this.CurrentSpeed = velocity.Size();
			if (this.State == EWaterEffectState.None)
			{
				this.OnCharacterFallInWater(velocity, this.CurrentWaterLocation, this.CurrentWaterNormal, valueOrDefault, this.CurrentWaterDepth);
			}
			Vector currentWaterNormal = this.CurrentWaterNormal;
			currentWaterNormal.GetSafeNormal(currentWaterNormal, 9.99999993922529E-09);
			double num = velocity.DotProduct(currentWaterNormal);
			double num2 = Math.Sqrt(this.CurrentSpeed * this.CurrentSpeed - num * num);
			this.WadeMoveSearchSpeed = num2;
			WaterEffectItem waterEffectItem = valueOrDefault.FindWadeMoveEffect(this.CurrentWaterDepth, num2);
			if (waterEffectItem != null)
			{
				this.SpawnEffect(waterEffectItem.EffectDataPath, waterEffectItem.AudioEffectDataPath, location, true);
			}
			else if (valueOrDefault.ShouldUseShallowFootSplashes(this.CurrentWaterDepth))
			{
				this.StopEffect();
			}
			this.CurrentSubConfig = valueOrDefault;
			this.State = EWaterEffectState.OnMaterial;
		}

		// Token: 0x0602F83A RID: 194618 RVA: 0x00B4FB8C File Offset: 0x00B4DD8C
		public void SetWaterDataEnviDataCheckFly([Nullable(2)] FKuroEnviInteractionData enviData, Vector location, Vector velocity)
		{
			if (!this.IsEnabled || enviData == null || this.Owner == null)
			{
				return;
			}
			this.CurrentWaterDepth = (double)enviData.WaterDepth;
			this.CurrentWaterNormal.Set((double)enviData.HitWaterNormal.X, (double)enviData.HitWaterNormal.Y, (double)enviData.HitWaterNormal.Z);
			this.CurrentToWaterHeight = enviData.CapsuleToWater;
			this.CurrentWaterLocation.Set(location.X, location.Y, (double)enviData.HitWaterLocation.Z);
			this.IsTraceWater = enviData.bTraceWater;
			this.IsBlackWave = enviData.bTouchBlackWave;
			this.VelocityHistory.AddVelocity(velocity);
			this.CurrentSpeed = velocity.Size();
			if (this.Owner.CharacterMovement != null && !this.IsBlackWave)
			{
				CharacterUnifiedStateComponent ownerStateComponent = this.OwnerStateComponent;
				ECharMoveState? echarMoveState = (ownerStateComponent != null) ? new ECharMoveState?(ownerStateComponent.MoveState) : null;
				this.IsMotorState = false;
				CharacterActorComponent characterActorComponent = this.Owner.CharacterActorComponent;
				BaseTagComponent baseTagComponent;
				if (characterActorComponent == null)
				{
					baseTagComponent = null;
				}
				else
				{
					Entity entity = characterActorComponent.Entity;
					baseTagComponent = ((entity != null) ? entity.GetComponent<BaseTagComponent>() : null);
				}
				BaseTagComponent baseTagComponent2 = baseTagComponent;
				if (baseTagComponent2 != null && baseTagComponent2.HasTag(GameplayTagDefine.EGameplayTagId["角色.Common.载具驾驶.摩托.驾驶期间"]))
				{
					this.IsMotorState = true;
				}
				bool flag = echarMoveState.GetValueOrDefault() == ECharMoveState.Soar && !enviData.bInWater;
				bool flag2 = this.IsMotorState && this.CurrentSpeed > 100.0 && (baseTagComponent2 == null || !baseTagComponent2.HasTag(GameplayTagDefine.EGameplayTagId["角色.Common.载具驾驶.摩托.状态.空中状态"]));
				bool flag3 = baseTagComponent2 != null && baseTagComponent2.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.悬浮.冲刺移动"]) && baseTagComponent2 != null && baseTagComponent2.HasTag(GameplayTagDefine.EGameplayTagId["角色.AimisiMd10011.状态.主控机甲"]);
				bool flag4 = baseTagComponent2 != null && baseTagComponent2.HasTag(GameplayTagDefine.EGameplayTagId["角色.Common.载具驾驶.摩托.状态.空中状态.翱翔"]);
				if ((flag || flag2 || flag3 || flag4) && this.IsTraceWater)
				{
					int? currentValue = Singleton<GameSettingsManager>.Instance.GetCurrentValue(EFunction.IMAGEQUALITY, true, true);
					if (currentValue != null)
					{
						int? num = currentValue;
						int num2 = 2;
						if (!(num.GetValueOrDefault() < num2 & num != null) && !Singleton<Info>.Instance.IsMobilePlatform())
						{
							EFlyWaterEffectState flyWaterType = EFlyWaterEffectState.Default;
							if (flag4)
							{
								flyWaterType = EFlyWaterEffectState.MotorSoaring;
							}
							this.OnCharacterFlyOnWater(velocity, this.InWaterSubConfig, flyWaterType);
							goto IL_251;
						}
					}
					return;
				}
			}
			IL_251:
			this.FindNoWaterPhysicalMaterial = enviData.HitPhysicMaterialArray.Contains("DynamicWater");
			if (this.VehicleEffect != null)
			{
				this.VehicleEffect.UpdateVehicleEffectData(enviData, this.IsMotorState, this.VelocityHistory.GetMaxVelocity(), this.IsBlackWave);
			}
		}

		// Token: 0x0602F83B RID: 194619 RVA: 0x00B4FE2C File Offset: 0x00B4E02C
		public void SetStateOnMaterial(UPhysicalMaterial material, double waterDepth, Vector waterNormal, Vector velocity, Vector location, double waterHeight)
		{
			if (!this.IsEnabled)
			{
				return;
			}
			WaterEffectSubConfig valueOrDefault = this.OnMaterialSubConfig.GetValueOrDefault(material);
			if (valueOrDefault == null)
			{
				this.SetStateNone(velocity);
				return;
			}
			this.CurrentWaterDepth = waterDepth;
			this.CurrentWaterLocation.Set(location.X, location.Y, waterHeight);
			this.CurrentWaterNormal = waterNormal;
			this.VelocityHistory.AddVelocity(velocity);
			this.CurrentSpeed = velocity.Size();
			if (this.State == EWaterEffectState.None)
			{
				this.OnCharacterFallInWater(velocity, this.CurrentWaterLocation, waterNormal, valueOrDefault, waterDepth);
			}
			this.WadeMoveSearchSpeed = this.CurrentSpeed;
			WaterEffectItem waterEffectItem = valueOrDefault.FindWadeMoveEffect(waterDepth, this.WadeMoveSearchSpeed);
			if (waterEffectItem != null)
			{
				this.SpawnEffect(waterEffectItem.EffectDataPath, waterEffectItem.AudioEffectDataPath, location, true);
			}
			else if (valueOrDefault.ShouldUseShallowFootSplashes(waterDepth))
			{
				this.StopEffect();
			}
			this.CurrentSubConfig = valueOrDefault;
			this.State = EWaterEffectState.OnMaterial;
		}

		// Token: 0x0602F83C RID: 194620 RVA: 0x00B4FF08 File Offset: 0x00B4E108
		protected unsafe void OnCharacterFallInWater(Vector speed, Vector location, Vector normal, WaterEffectSubConfig subConfig, double waterDepth)
		{
			if (!this.IsEnabled)
			{
				return;
			}
			if (waterDepth < (double)subConfig.FallJumpDepthThreshold)
			{
				return;
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.RenderEffect;
			ELogAuthor author = ELogAuthor.LSY;
			string message = "WaterEffect Spawn Fall In Water";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Owner", this.Owner);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("vel", this.VelocityHistory.GetMaxVelocityDirection(Vector.Create(-this.CurrentWaterNormal.X, -this.CurrentWaterNormal.Y, -this.CurrentWaterNormal.Z)));
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			WaterEffectItem waterEffectItem = subConfig.FindFallEffectAtSpeed((float)this.VelocityHistory.GetMaxVelocityDirection(Vector.Create(-this.CurrentWaterNormal.X, -this.CurrentWaterNormal.Y, -this.CurrentWaterNormal.Z)));
			if (waterEffectItem == null)
			{
				return;
			}
			Vector location2 = Vector.Create(location.X + speed.X * (double)this.Config.FallJumpPositionFix, location.Y + speed.Y * (double)this.Config.FallJumpPositionFix, location.Z);
			this.SpawnFallEffect(waterEffectItem.EffectDataPath, waterEffectItem.AudioEffectDataPath, location2, normal);
		}

		// Token: 0x0602F83D RID: 194621 RVA: 0x00B50054 File Offset: 0x00B4E254
		protected void OnCharacterJumpOutWater(Vector speed, Vector location, Vector normal, WaterEffectSubConfig subConfig, double waterDepth)
		{
			if (!this.IsEnabled)
			{
				return;
			}
			if (waterDepth < (double)subConfig.FallJumpDepthThreshold)
			{
				return;
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.RenderEffect;
			ELogAuthor author = ELogAuthor.LSY;
			string message = "WaterEffect Spawn Jump Out of Water";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Owner", this.Owner);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			WaterEffectItem waterEffectItem = subConfig.FindJumpEffectAtSpeed((float)this.VelocityHistory.GetMaxVelocityDirection(this.CurrentWaterNormal));
			if (waterEffectItem == null)
			{
				return;
			}
			Vector location2 = Vector.Create(location.X + speed.X * (double)this.Config.FallJumpPositionFix, location.Y + speed.Y * (double)this.Config.FallJumpPositionFix, location.Z);
			this.SpawnFallEffect(waterEffectItem.EffectDataPath, waterEffectItem.AudioEffectDataPath, location2, normal);
		}

		// Token: 0x0602F83E RID: 194622 RVA: 0x00B50118 File Offset: 0x00B4E318
		protected void StopEffect()
		{
			int effectHandle = this.Handle;
			if (effectHandle != 0 && Singleton<EffectSystem>.Instance.IsValid(effectHandle))
			{
				Singleton<EffectSystem>.Instance.HandleSeekToTime(effectHandle, -1f, false, false);
				float num = this.Config.TimeExistAfterDead * 1000f;
				if (num > 20f)
				{
					TimerSystem.Instance.Delay(delegate(float deltaTime)
					{
						if (Singleton<EffectSystem>.Instance.IsValid(effectHandle))
						{
							Singleton<EffectSystem>.Instance.StopEffectById(effectHandle, "[SceneCharacterWaterEffect.StopEffect]", true, null);
						}
					}, (float)((int)num), null, null, true, 1f);
				}
				else
				{
					TimerSystem.Instance.Next(delegate(float deltaTime)
					{
						if (Singleton<EffectSystem>.Instance.IsValid(effectHandle))
						{
							Singleton<EffectSystem>.Instance.StopEffectById(effectHandle, "[SceneCharacterWaterEffect.StopEffect]", true, null);
						}
					}, null, null);
				}
			}
			this.Handle = 0;
			if (Singleton<EffectSystem>.Instance.IsValid(this.AudioEffectHandle))
			{
				Singleton<EffectSystem>.Instance.StopEffectById(this.AudioEffectHandle, "[SceneCharacterWaterEffect.StopEffect]", true, null);
			}
			this.AudioEffectHandle = 0;
		}

		// Token: 0x0602F83F RID: 194623 RVA: 0x00B50204 File Offset: 0x00B4E404
		protected void SpawnEffect([Nullable(new byte[]
		{
			2,
			1
		})] TSoftObjectPtr<UEffectModelBase> effectDataPath, [Nullable(new byte[]
		{
			2,
			1
		})] TSoftObjectPtr<UEffectModelBase> audioEffectDataPath, Vector location, bool physicsMaterialWater)
		{
			if (!Singleton<EffectSystem>.Instance.IsValid(this.Handle) || this.HandlePath != effectDataPath)
			{
				this.StopEffect();
				if (effectDataPath == null || this.IsBlackWave || this.EIData == null || this.FindNoWaterPhysicalMaterial)
				{
					return;
				}
				if (!physicsMaterialWater && this.EIData.CapsuleToBlock < this.EIData.CapsuleToWater)
				{
					return;
				}
				FVectorDouble fvectorDouble = location.ToUeVector(false);
				this.EmptyUeTransform.SetLocation(fvectorDouble);
				EffectSystem instance = Singleton<EffectSystem>.Instance;
				UObject owner = this.Owner;
				FTransformDouble? ftransformDouble = new FTransformDouble?(this.EmptyUeTransform);
				this.Handle = instance.SpawnEffect(owner, ftransformDouble, effectDataPath.ToAssetPathName(), "[SceneCharacterWaterEffect.SpawnEffect]", new EffectContext(null, this.Owner, false), EEffectType.Fight, null, null, null, false, false);
				Singleton<EffectSystem>.Instance.FreezeHandle(this.Handle, true, false);
				if (Singleton<EffectSystem>.Instance.IsValid(this.Handle))
				{
					this.HandlePath = effectDataPath;
				}
				if (audioEffectDataPath != null)
				{
					string text = audioEffectDataPath.ToAssetPathName();
					if (!string.IsNullOrEmpty(text))
					{
						EffectSystem instance2 = Singleton<EffectSystem>.Instance;
						UObject owner2 = this.Owner;
						ftransformDouble = new FTransformDouble?(this.EmptyUeTransform);
						this.AudioEffectHandle = instance2.SpawnEffect(owner2, ftransformDouble, text, "[SceneCharacterWaterEffect.SpawnEffect(Audio)]", new EffectContext(null, this.Owner, false), EEffectType.Fight, null, null, null, false, false);
					}
				}
			}
		}

		// Token: 0x0602F840 RID: 194624 RVA: 0x00B50368 File Offset: 0x00B4E568
		protected int SpawnFallEffect([Nullable(new byte[]
		{
			2,
			1
		})] TSoftObjectPtr<UEffectModelBase> effectDataPath, [Nullable(new byte[]
		{
			2,
			1
		})] TSoftObjectPtr<UEffectModelBase> audioEffectDataPath, Vector location, Vector normal)
		{
			if (effectDataPath == null || this.IsBlackWave || this.FindNoWaterPhysicalMaterial)
			{
				return -1;
			}
			TsBaseCharacter owner = this.Owner;
			CharacterMoveComponent characterMoveComponent;
			if (owner == null)
			{
				characterMoveComponent = null;
			}
			else
			{
				CharacterActorComponent characterActorComponent = owner.CharacterActorComponent;
				if (characterActorComponent == null)
				{
					characterMoveComponent = null;
				}
				else
				{
					Entity entity = characterActorComponent.Entity;
					characterMoveComponent = ((entity != null) ? entity.GetComponent<CharacterMoveComponent>() : null);
				}
			}
			CharacterMoveComponent characterMoveComponent2 = characterMoveComponent;
			if (characterMoveComponent2 != null)
			{
				Vector inB = Vector.Create(this.CurrentWaterNormal.X, this.CurrentWaterNormal.Y, -this.CurrentWaterNormal.Z);
				if (characterMoveComponent2.GravityDirect.DotProduct(inB) < 0.20000000298023224)
				{
					return -1;
				}
				if (Math.Abs(characterMoveComponent2.GravityDirect.Z) < 0.8999999761581421)
				{
					return -1;
				}
			}
			if (this.IsMotorState && this.VehicleEffect != null)
			{
				this.VehicleEffect.OnFallInWater(location, normal);
				return -1;
			}
			FVectorDouble fvectorDouble = location.ToUeVector(false);
			this.EmptyUeTransform.SetLocation(fvectorDouble);
			fvectorDouble = normal.ToUeVector(false);
			FQuat fquat = UKismetMathLibrary.D_MakeRotFromZ(fvectorDouble).Quaternion();
			this.EmptyUeTransform.SetRotation(fquat);
			string path = effectDataPath.ToAssetPathName();
			EffectSystem instance = Singleton<EffectSystem>.Instance;
			UObject world = GlobalData.World;
			FTransformDouble? ftransformDouble = new FTransformDouble?(this.EmptyUeTransform);
			int result = instance.SpawnUnloopedEffect(world, ftransformDouble, path, "[SceneCharacterWaterEffect.SpawnFallEffect]", new EffectContext(null, this.Owner, false), EEffectType.Scene, null, null, null, false, false);
			if (audioEffectDataPath != null)
			{
				string text = audioEffectDataPath.ToAssetPathName();
				if (!string.IsNullOrEmpty(text))
				{
					EffectSystem instance2 = Singleton<EffectSystem>.Instance;
					UObject world2 = GlobalData.World;
					ftransformDouble = new FTransformDouble?(this.EmptyUeTransform);
					instance2.SpawnUnloopedEffect(world2, ftransformDouble, text, "[SceneCharacterWaterEffect.SpawnFallEffect(Audio)]", null, EEffectType.Fight, null, null, null, false, false);
				}
			}
			return result;
		}

		// Token: 0x0602F841 RID: 194625 RVA: 0x00B50508 File Offset: 0x00B4E708
		protected void OnCharacterFlyOnWater(Vector speed, WaterEffectSubConfig subConfig, EFlyWaterEffectState flyWaterType)
		{
			if (!this.IsEnabled || this.FindNoWaterPhysicalMaterial)
			{
				return;
			}
			if (this.CurrentToWaterHeight > subConfig.FlyEffectHeightThreshold)
			{
				return;
			}
			WaterEffectItem waterEffectItem = subConfig.FindFlyEffectAtSpeed((float)this.VelocityHistory.GetMaxVelocity());
			if (waterEffectItem == null)
			{
				return;
			}
			TsBaseCharacter owner = this.Owner;
			CharacterMoveComponent characterMoveComponent;
			if (owner == null)
			{
				characterMoveComponent = null;
			}
			else
			{
				CharacterActorComponent characterActorComponent = owner.CharacterActorComponent;
				if (characterActorComponent == null)
				{
					characterMoveComponent = null;
				}
				else
				{
					Entity entity = characterActorComponent.Entity;
					characterMoveComponent = ((entity != null) ? entity.GetComponent<CharacterMoveComponent>() : null);
				}
			}
			CharacterMoveComponent characterMoveComponent2 = characterMoveComponent;
			if (characterMoveComponent2 != null)
			{
				Vector inB = Vector.Create(this.CurrentWaterNormal.X, this.CurrentWaterNormal.Y, -this.CurrentWaterNormal.Z);
				if (characterMoveComponent2.GravityDirect.DotProduct(inB) < 0.20000000298023224)
				{
					return;
				}
			}
			Vector vector = Vector.Create(this.CurrentWaterLocation.X + speed.X * 0.30000001192092896, this.CurrentWaterLocation.Y + speed.Y * 0.30000001192092896, this.CurrentWaterLocation.Z);
			if (this.RippleSwim == null && this.Owner != null)
			{
				this.RippleSwim = (UKuroRenderingRuntimeBPPluginBPLibrary.GetActorOfClass(this.Owner, BP_RippleSwim_C.StaticClass()) as BP_RippleSwim_C);
			}
			if (this.RippleSwim != null && flyWaterType != EFlyWaterEffectState.MotorSoaring)
			{
				FVector2D currentRippleCenter = this.RippleSwim.CurrentRippleCenter;
				FVector2D safeNormal = currentRippleCenter.GetSafeNormal(1E-08f);
				vector.X = this.CurrentWaterLocation.X + (double)currentRippleCenter.X + (double)(this.IsMotorState ? 0f : (safeNormal.X * this.RippleSwim.PlayerSize * 1.1f));
				vector.Y = this.CurrentWaterLocation.Y + (double)currentRippleCenter.Y + (double)(this.IsMotorState ? 0f : (safeNormal.Y * this.RippleSwim.PlayerSize * 1.1f));
			}
			else if (flyWaterType == EFlyWaterEffectState.MotorSoaring)
			{
				vector.X = this.CurrentWaterLocation.X + speed.X * 0.15000000596046448;
				vector.Y = this.CurrentWaterLocation.Y + speed.Y * 0.15000000596046448;
			}
			this.ShoreTraceTicker++;
			if (this.ShoreTraceTicker >= 3 && characterMoveComponent2 != null)
			{
				this.ShoreTraceTicker = 0;
				Vector vector2 = vector;
				vector2.AdditionEqual(speed.MultiplyEqual(0.10000000149011612));
				this.ShoreTraceHandle = this.DetectShoreForFlyEffect(vector2);
			}
			Rotator rotator = Rotator.Create();
			if (characterMoveComponent2 != null)
			{
				Vector up = Vector.Create(-characterMoveComponent2.GravityDirect.X, -characterMoveComponent2.GravityDirect.Y, -characterMoveComponent2.GravityDirect.Z);
				Singleton<MathUtils>.Instance.LookRotationUpFirst(speed, up, rotator);
			}
			rotator.Yaw += 90f;
			FVectorDouble fvectorDouble = vector.ToUeVector(false);
			this.EmptyUeTransform.SetLocation(fvectorDouble);
			FQuat fquat = rotator.ToUeRotator().Quaternion();
			this.EmptyUeTransform.SetRotation(fquat);
			string text = "";
			if (flyWaterType != EFlyWaterEffectState.Default)
			{
				if (flyWaterType == EFlyWaterEffectState.MotorSoaring)
				{
					text = "/Game/Aki/Effect/EffectGroup/Common/Water/DA_Fx_Group_SI3_FlyWater_Gliding.DA_Fx_Group_SI3_FlyWater_Gliding";
				}
			}
			else if (waterEffectItem.EffectDataPath != null)
			{
				text = waterEffectItem.EffectDataPath.ToAssetPathName();
			}
			if (!Singleton<EffectSystem>.Instance.IsValid(this.FlyWaterHandle) || text != this.FlyWaterEffectPath)
			{
				if (Singleton<EffectSystem>.Instance.IsValid(this.FlyWaterHandle))
				{
					int oldFlyHandle = this.FlyWaterHandle;
					TimerSystem.Instance.Delay(delegate(float deltaTime)
					{
						if (Singleton<EffectSystem>.Instance.IsValid(oldFlyHandle))
						{
							Singleton<EffectSystem>.Instance.StopEffectById(oldFlyHandle, "[SceneCharacterWaterEffect.StopEffect]", true, null);
						}
					}, 1000f, null, null, true, 1f);
				}
				if (!string.IsNullOrEmpty(text))
				{
					EffectSystem instance = Singleton<EffectSystem>.Instance;
					UObject owner2 = this.Owner;
					FTransformDouble? ftransformDouble = new FTransformDouble?(this.EmptyUeTransform);
					this.FlyWaterHandle = instance.SpawnEffect(owner2, ftransformDouble, text, "[SceneCharacterWaterEffect.SpawnEffect(FlyWaterEffect)]", new EffectContext(null, this.Owner, false), EEffectType.Scene, null, null, null, false, false);
					OneOf<KuroEffectActorHandle, AActor> effectActor = Singleton<EffectSystem>.Instance.GetEffectActor(this.FlyWaterHandle);
					Log instance2 = Singleton<Log>.Instance;
					ELogModule module = ELogModule.RenderEffect;
					ELogAuthor author = ELogAuthor.LLX;
					string message = "WaterEffect Spawn Fly on Water";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("WaterEffectActor", effectActor.D_K2_GetActorLocation());
					instance2.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					this.FlyWaterEffectPath = text;
				}
			}
			OneOf<KuroEffectActorHandle, AActor> effectActor2 = Singleton<EffectSystem>.Instance.GetEffectActor(this.FlyWaterHandle);
			if (effectActor2.HasValue && this.IsTraceWater && !this.IsTracedShore)
			{
				FHitResult fhitResult = new FHitResult();
				effectActor2.D_K2_SetActorTransform(this.EmptyUeTransform, false, ref fhitResult, false);
				EffectParameterNiagara effectParameterNiagara = new EffectParameterNiagara();
				effectParameterNiagara.UserParameterFloat = new List<ValueTuple<FName, float>>();
				effectParameterNiagara.UserParameterFloat.Add(new ValueTuple<FName, float>(FNameUtil.GetDynamicFName("DistanceToWater").Value, this.CurrentToWaterHeight));
				double num = 1.0;
				if (subConfig.FallJumpDepthThreshold > 0f)
				{
					num = Math.Min(0.8, this.CurrentWaterDepth / (double)subConfig.FallJumpDepthThreshold);
				}
				effectParameterNiagara.UserParameterFloat.Add(new ValueTuple<FName, float>(FNameUtil.GetDynamicFName("SpriteScale").Value, (float)num));
				Singleton<EffectSystem>.Instance.SetEffectParameterNiagara(this.FlyWaterHandle, effectParameterNiagara);
			}
		}

		// Token: 0x0602F842 RID: 194626 RVA: 0x00B50A48 File Offset: 0x00B4EC48
		private void OnOwnerCharFootOnTheGround(bool isLeftFoot)
		{
			if (!this.IsEnabled || this.Owner == null || this.IsMotorState)
			{
				return;
			}
			CharacterActorComponent characterActorComponent = this.Owner.CharacterActorComponent;
			CharacterMoveComponent characterMoveComponent;
			if (characterActorComponent == null)
			{
				characterMoveComponent = null;
			}
			else
			{
				Entity entity = characterActorComponent.Entity;
				characterMoveComponent = ((entity != null) ? entity.GetComponent<CharacterMoveComponent>() : null);
			}
			CharacterMoveComponent characterMoveComponent2 = characterMoveComponent;
			if (characterMoveComponent2 != null)
			{
				Vector inB = Vector.Create(this.CurrentWaterNormal.X, this.CurrentWaterNormal.Y, -this.CurrentWaterNormal.Z);
				if (characterMoveComponent2.GravityDirect.DotProduct(inB) < 0.20000000298023224)
				{
					return;
				}
			}
			CharacterActorComponent characterActorComponent2 = this.Owner.CharacterActorComponent;
			object obj;
			if (characterActorComponent2 == null)
			{
				obj = null;
			}
			else
			{
				Entity entity2 = characterActorComponent2.Entity;
				obj = ((entity2 != null) ? entity2.GetComponent<CharacterBuffComponent>() : null);
			}
			object obj2 = obj;
			if (((obj2 != null) ? obj2.GetBuffById(640003011L) : null) != null)
			{
				return;
			}
			CharacterActorComponent characterActorComponent3 = this.Owner.CharacterActorComponent;
			object obj3;
			if (characterActorComponent3 == null)
			{
				obj3 = null;
			}
			else
			{
				Entity entity3 = characterActorComponent3.Entity;
				obj3 = ((entity3 != null) ? entity3.GetComponent<BaseTagComponent>() : null);
			}
			object obj4 = obj3;
			if (obj4 != null && obj4.HasTag(GameplayTagDefine.EGameplayTagId["GameplayEffect.ShieldWaterMoveEffect"]))
			{
				return;
			}
			if (this.State != EWaterEffectState.InWater && this.State != EWaterEffectState.OnMaterial)
			{
				return;
			}
			WaterEffectSubConfig currentSubConfig = this.CurrentSubConfig;
			if (currentSubConfig == null || !currentSubConfig.ShouldUseShallowFootSplashes(this.CurrentWaterDepth))
			{
				return;
			}
			CharacterUnifiedStateComponent ownerStateComponent = this.OwnerStateComponent;
			ECharMoveState? echarMoveState = (ownerStateComponent != null) ? new ECharMoveState?(ownerStateComponent.MoveState) : null;
			if (echarMoveState.GetValueOrDefault() == ECharMoveState.NormalSwim || echarMoveState.GetValueOrDefault() == ECharMoveState.FastSwim)
			{
				return;
			}
			WaterEffectItem waterEffectItem = currentSubConfig.FindShallowMoveEffect(this.CurrentWaterDepth, this.WadeMoveSearchSpeed);
			if (waterEffectItem == null)
			{
				return;
			}
			this.TrySpawnShallowMoveFootSplash(waterEffectItem, isLeftFoot);
		}

		// Token: 0x0602F843 RID: 194627 RVA: 0x00B50BD4 File Offset: 0x00B4EDD4
		private void TrySpawnShallowMoveFootSplash(WaterEffectItem item, bool isLeftFoot)
		{
			if (item.EffectDataPath == null || this.IsBlackWave || this.EIData == null || this.FindNoWaterPhysicalMaterial)
			{
				return;
			}
			TsBaseCharacter owner = this.Owner;
			if (owner == null)
			{
				return;
			}
			USkeletalMeshComponent mesh = owner.Mesh;
			if (mesh == null)
			{
				return;
			}
			CharacterActorComponent characterActorComponent = owner.CharacterActorComponent;
			CharacterMoveComponent characterMoveComponent;
			if (characterActorComponent == null)
			{
				characterMoveComponent = null;
			}
			else
			{
				Entity entity = characterActorComponent.Entity;
				characterMoveComponent = ((entity != null) ? entity.GetComponent<CharacterMoveComponent>() : null);
			}
			CharacterMoveComponent characterMoveComponent2 = characterMoveComponent;
			if (characterMoveComponent2 != null)
			{
				Vector inB = Vector.Create(this.CurrentWaterNormal.X, this.CurrentWaterNormal.Y, -this.CurrentWaterNormal.Z);
				if (characterMoveComponent2.GravityDirect.DotProduct(inB) < 0.20000000298023224)
				{
					return;
				}
				if (Math.Abs(characterMoveComponent2.GravityDirect.Z) < 0.8999999761581421)
				{
					return;
				}
			}
			if (this.IsMotorState && this.VehicleEffect != null)
			{
				return;
			}
			FName inSocketName = isLeftFoot ? CharacterFootEffectComponent.LeftFootSocketName : CharacterFootEffectComponent.RightFootSocketName;
			FVectorDouble fvectorDouble = mesh.D_GetSocketLocation(inSocketName);
			Vector vector = Vector.Create(fvectorDouble.X, fvectorDouble.Y, this.CurrentWaterLocation.Z);
			FVectorDouble fvectorDouble2 = vector.ToUeVector(false);
			this.EmptyUeTransform.SetLocation(fvectorDouble2);
			fvectorDouble2 = this.CurrentWaterNormal.ToUeVector(false);
			FQuat fquat = UKismetMathLibrary.D_MakeRotFromZ(fvectorDouble2).Quaternion();
			this.EmptyUeTransform.SetRotation(fquat);
			string path = item.EffectDataPath.ToAssetPathName();
			EffectSystem instance = Singleton<EffectSystem>.Instance;
			UObject world = GlobalData.World;
			FTransformDouble? ftransformDouble = new FTransformDouble?(this.EmptyUeTransform);
			instance.SpawnUnloopedEffect(world, ftransformDouble, path, "[SceneCharacterWaterEffect.TrySpawnShallowMoveFootSplash]", new EffectContext(null, owner, false), EEffectType.Scene, null, null, null, false, false);
			if (item.AudioEffectDataPath != null)
			{
				string text = item.AudioEffectDataPath.ToAssetPathName();
				if (!string.IsNullOrEmpty(text))
				{
					EffectSystem instance2 = Singleton<EffectSystem>.Instance;
					UObject world2 = GlobalData.World;
					ftransformDouble = new FTransformDouble?(this.EmptyUeTransform);
					instance2.SpawnUnloopedEffect(world2, ftransformDouble, text, "[SceneCharacterWaterEffect.TrySpawnShallowMoveFootSplash(Audio)]", null, EEffectType.Fight, null, null, null, false, false);
				}
			}
		}

		// Token: 0x0602F844 RID: 194628 RVA: 0x00B50DD0 File Offset: 0x00B4EFD0
		private TraceHandle DetectShoreForFlyEffect(Vector shoreTraceLocation)
		{
			TsBaseCharacter owner = this.Owner;
			CharacterMoveComponent characterMoveComponent;
			if (owner == null)
			{
				characterMoveComponent = null;
			}
			else
			{
				CharacterActorComponent characterActorComponent = owner.CharacterActorComponent;
				if (characterActorComponent == null)
				{
					characterMoveComponent = null;
				}
				else
				{
					Entity entity = characterActorComponent.Entity;
					characterMoveComponent = ((entity != null) ? entity.GetComponent<CharacterMoveComponent>() : null);
				}
			}
			CharacterMoveComponent characterMoveComponent2 = characterMoveComponent;
			Vector location = Vector.Create(-500.0 * characterMoveComponent2.GravityDirect.X + shoreTraceLocation.X, -500.0 * characterMoveComponent2.GravityDirect.Y + shoreTraceLocation.Y, -500.0 * characterMoveComponent2.GravityDirect.Z + shoreTraceLocation.Z);
			Vector location2 = Vector.Create(3000.0 * characterMoveComponent2.GravityDirect.X + shoreTraceLocation.X, 3000.0 * characterMoveComponent2.GravityDirect.Y + shoreTraceLocation.Y, 3000.0 * characterMoveComponent2.GravityDirect.Z + shoreTraceLocation.Z);
			Singleton<TraceElementCommon>.Instance.SetStartLocation(this.ShoreTraceElement, location);
			Singleton<TraceElementCommon>.Instance.SetEndLocation(this.ShoreTraceElement, location2);
			return Singleton<TraceElementCommon>.Instance.AsyncSphereTrace(this.ShoreTraceElement, "WaterEffect_ShoreTrace", this.ShoreTraceDelegate);
		}

		// Token: 0x0602F845 RID: 194629 RVA: 0x00B50EFC File Offset: 0x00B4F0FC
		[NullableContext(2)]
		private void SetShoreTraceState(bool hitResult, UTraceBaseElement element, double frame, double index)
		{
			if (this.ShoreTraceHandle != null && (double)this.ShoreTraceHandle.Frame > frame)
			{
				return;
			}
			if (this.ShoreTraceHandle != null && Singleton<MathUtils>.Instance.IsNearlyEqual((double)this.ShoreTraceHandle.Frame, frame, null) && (double)this.ShoreTraceHandle.Index > index)
			{
				return;
			}
			if (hitResult)
			{
				if (this.IsTracedShore)
				{
					Singleton<Log>.Instance.Info(ELogModule.RenderEffect, ELogAuthor.LLX, "LLX  TraceChange True to False", default(ReadOnlySpan<ValueTuple<string, object>>));
				}
				this.IsTracedShore = false;
				return;
			}
			if (!this.IsTracedShore)
			{
				Singleton<Log>.Instance.Info(ELogModule.RenderEffect, ELogAuthor.LLX, "LLX  TraceChange False to True", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			this.IsTracedShore = true;
		}

		// Token: 0x0401B2A9 RID: 111273
		private const int ONE_SECOND = 1000;

		// Token: 0x0401B2AA RID: 111274
		private const float FLYEFFECT_VELOCITY_XY_OFFSET_SCALE = 0.3f;

		// Token: 0x0401B2AB RID: 111275
		private const float FLYEFFECT_VELOCITY_XY_OFFSET_SCALE_MOTOR = 0.15f;

		// Token: 0x0401B2AC RID: 111276
		private const float FLYEFFECT_RIPPLEWATER_XY_OFFSET_SCALE = 1.1f;

		// Token: 0x0401B2AD RID: 111277
		private const float FLYEFFECT_SHORE_TRACE_START_OFFSET = 500f;

		// Token: 0x0401B2AE RID: 111278
		private const float FLYEFFECT_SHORE_TRACE_END_OFFSET = -3000f;

		// Token: 0x0401B2AF RID: 111279
		private const float WATER_NORMAL_DOT_CHECK = 0.2f;

		// Token: 0x0401B2B0 RID: 111280
		private const float MOTOR_EFFECT_SPEED_CLAMP = 100f;

		// Token: 0x0401B2B1 RID: 111281
		private const string FLYWATER_MOTOR_SOARING = "/Game/Aki/Effect/EffectGroup/Common/Water/DA_Fx_Group_SI3_FlyWater_Gliding.DA_Fx_Group_SI3_FlyWater_Gliding";

		// Token: 0x0401B2B2 RID: 111282
		[Nullable(2)]
		public PDA_WaterEffectConfigs_C Config;

		// Token: 0x0401B2B3 RID: 111283
		[Nullable(2)]
		public TsBaseCharacter Owner;

		// Token: 0x0401B2B4 RID: 111284
		[Nullable(2)]
		public CharacterUnifiedStateComponent OwnerStateComponent;

		// Token: 0x0401B2B5 RID: 111285
		protected float OwnerHeight;

		// Token: 0x0401B2B6 RID: 111286
		public bool IsReady;

		// Token: 0x0401B2B7 RID: 111287
		protected EWaterEffectState State;

		// Token: 0x0401B2B8 RID: 111288
		[Nullable(2)]
		protected WaterEffectSubConfig CurrentSubConfig;

		// Token: 0x0401B2B9 RID: 111289
		protected WaterEffectSubConfig InWaterSubConfig = new WaterEffectSubConfig();

		// Token: 0x0401B2BA RID: 111290
		[Nullable(new byte[]
		{
			2,
			1
		})]
		protected TSoftObjectPtr<UEffectModelBase> SwimIdleEffect;

		// Token: 0x0401B2BB RID: 111291
		[Nullable(new byte[]
		{
			2,
			1
		})]
		protected TSoftObjectPtr<UEffectModelBase> SwimNormalEffect;

		// Token: 0x0401B2BC RID: 111292
		[Nullable(new byte[]
		{
			2,
			1
		})]
		protected TSoftObjectPtr<UEffectModelBase> SwimFastEffect;

		// Token: 0x0401B2BD RID: 111293
		protected Dictionary<UPhysicalMaterial, WaterEffectSubConfig> OnMaterialSubConfig = new Dictionary<UPhysicalMaterial, WaterEffectSubConfig>();

		// Token: 0x0401B2BE RID: 111294
		protected int Handle;

		// Token: 0x0401B2BF RID: 111295
		protected int AudioEffectHandle;

		// Token: 0x0401B2C0 RID: 111296
		[Nullable(new byte[]
		{
			2,
			1
		})]
		protected TSoftObjectPtr<UEffectModelBase> HandlePath;

		// Token: 0x0401B2C1 RID: 111297
		protected double CurrentSpeed;

		// Token: 0x0401B2C2 RID: 111298
		protected double WadeMoveSearchSpeed;

		// Token: 0x0401B2C3 RID: 111299
		protected Vector CurrentWaterLocation = Vector.Create();

		// Token: 0x0401B2C4 RID: 111300
		protected Vector CurrentWaterNormal = Vector.Create();

		// Token: 0x0401B2C5 RID: 111301
		protected double CurrentWaterDepth;

		// Token: 0x0401B2C6 RID: 111302
		protected VelocityHistoryCache VelocityHistory = new VelocityHistoryCache();

		// Token: 0x0401B2C7 RID: 111303
		protected float CurrentToWaterHeight;

		// Token: 0x0401B2C8 RID: 111304
		protected int FlyWaterHandle;

		// Token: 0x0401B2C9 RID: 111305
		protected string FlyWaterEffectPath = "";

		// Token: 0x0401B2CA RID: 111306
		protected bool IsTraceWater;

		// Token: 0x0401B2CB RID: 111307
		protected bool IsBlackWave;

		// Token: 0x0401B2CC RID: 111308
		protected FTransformDouble EmptyUeTransform = new FTransformDouble();

		// Token: 0x0401B2CD RID: 111309
		[Nullable(2)]
		protected BP_RippleSwim_C RippleSwim;

		// Token: 0x0401B2CE RID: 111310
		[Nullable(2)]
		protected UTraceSphereElement ShoreTraceElement;

		// Token: 0x0401B2CF RID: 111311
		[Nullable(2)]
		protected TraceHandle ShoreTraceHandle;

		// Token: 0x0401B2D0 RID: 111312
		[Nullable(2)]
		protected FAsyncTraceDelegate ShoreTraceDelegate;

		// Token: 0x0401B2D1 RID: 111313
		protected int ShoreTraceTicker;

		// Token: 0x0401B2D2 RID: 111314
		protected bool IsTracedShore;

		// Token: 0x0401B2D3 RID: 111315
		protected bool IsMotorState;

		// Token: 0x0401B2D4 RID: 111316
		protected bool FindNoWaterPhysicalMaterial;

		// Token: 0x0401B2D5 RID: 111317
		[Nullable(2)]
		protected FKuroEnviInteractionData EIData;

		// Token: 0x0401B2D6 RID: 111318
		[Nullable(2)]
		protected SceneCharacterVehicleEffect VehicleEffect;

		// Token: 0x0401B2D7 RID: 111319
		private const string WET_STATE_TAG_NAME = "TA.表现.角色.状态效果.湿身";

		// Token: 0x0401B2D8 RID: 111320
		[Nullable(2)]
		protected UKuroCharWetControllerComponent WetController;

		// Token: 0x0401B2D9 RID: 111321
		protected int WetStateTagId;

		// Token: 0x0401B2DA RID: 111322
		protected bool LastWetStateTagActive;

		// Token: 0x0401B2DB RID: 111323
		public bool IsEnabled;
	}
}
