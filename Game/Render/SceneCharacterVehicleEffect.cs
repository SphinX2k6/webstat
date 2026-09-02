using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Effect;
using CSharpScript.Game.Utils;
using UnrealEngine;

namespace CSharpScript.Game.Render
{
	// Token: 0x02004784 RID: 18308
	[NullableContext(1)]
	[Nullable(0)]
	public class SceneCharacterVehicleEffect
	{
		// Token: 0x0602F80B RID: 194571 RVA: 0x00B4DC14 File Offset: 0x00B4BE14
		public void Start(TsBaseCharacter owner)
		{
			if (!owner.IsValid())
			{
				return;
			}
			this.Owner = owner;
			this.IsReady = true;
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.RenderEffect;
			ELogAuthor author = ELogAuthor.LLX;
			string message = "VehicleEffect Start";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Owner", owner);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}

		// Token: 0x0602F80C RID: 194572 RVA: 0x00B4DC60 File Offset: 0x00B4BE60
		public void Enable()
		{
			if (!this.IsReady)
			{
				return;
			}
			this.IsEnabled = true;
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.RenderEffect;
			ELogAuthor author = ELogAuthor.LLX;
			string message = "WaterEffect Enabled";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Owner", this.Owner);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}

		// Token: 0x0602F80D RID: 194573 RVA: 0x00B4DCAC File Offset: 0x00B4BEAC
		public void Disable()
		{
			if (!this.IsEnabled)
			{
				return;
			}
			if (Singleton<EffectSystem>.Instance.IsValid(this.MotorAttachHandle))
			{
				Singleton<EffectSystem>.Instance.StopEffectById(this.MotorAttachHandle, "[SceneCharacterWaterEffect.Disable]", true, null);
				this.MotorAttachHandle = 0;
			}
			if (Singleton<EffectSystem>.Instance.IsValid(this.MotorScreenHandle))
			{
				Singleton<EffectSystem>.Instance.StopEffectById(this.MotorScreenHandle, "[SceneCharacterWaterEffect.Disable]", true, null);
				this.MotorScreenHandle = 0;
			}
			this.MotorAttachHandlePath = "";
			this.MotorScreenHandlePath = "";
			this.IsEnabled = false;
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.RenderEffect;
			ELogAuthor author = ELogAuthor.LLX;
			string message = "WaterEffect Disabled";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Owner", this.Owner);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}

		// Token: 0x0602F80E RID: 194574 RVA: 0x00B4DD7D File Offset: 0x00B4BF7D
		public void Tick()
		{
			if (!this.IsEnabled)
			{
				return;
			}
			if (!this.IsVehicleWaterState && (this.MotorAttachHandlePath == "/Game/Aki/Effect/DataAsset/Niagara/Common/Water/DA_Fx_SI3_Water_Moto_Putong.DA_Fx_SI3_Water_Moto_Putong" || this.MotorAttachHandlePath == "/Game/Aki/Effect/DataAsset/Niagara/Common/Water/DA_Fx_SI3_Water_Moto_Danqi.DA_Fx_SI3_Water_Moto_Danqi"))
			{
				this.StopMotorAttachEffect();
			}
		}

		// Token: 0x0602F80F RID: 194575 RVA: 0x00B4DDBC File Offset: 0x00B4BFBC
		[NullableContext(2)]
		public void SetStateInWaterEnviData(FKuroEnviInteractionData enviData)
		{
			if (!this.IsEnabled || enviData == null)
			{
				return;
			}
			this.EnviData = enviData;
			if (this.IsMotorState)
			{
				CharacterActorComponent characterActorComponent = this.Owner.CharacterActorComponent;
				object obj;
				if (characterActorComponent == null)
				{
					obj = null;
				}
				else
				{
					Entity entity = characterActorComponent.Entity;
					obj = ((entity != null) ? entity.GetComponent<BaseTagComponent>() : null);
				}
				object obj2 = obj;
				if (obj2 != null && obj2.HasTag(GameplayTagDefine.EGameplayTagId["角色.Common.载具驾驶.摩托.冲刺"]))
				{
					if (!this.FindNoWaterPhysicalMaterial)
					{
						this.SpawnMotorAttachEffect("/Game/Aki/Effect/DataAsset/Niagara/Common/Water/DA_Fx_SI3_Water_Moto_Danqi.DA_Fx_SI3_Water_Moto_Danqi");
					}
				}
				else if (this.CacheMaxSpeed > 100.0)
				{
					if (!this.FindNoWaterPhysicalMaterial)
					{
						this.SpawnMotorAttachEffect("/Game/Aki/Effect/DataAsset/Niagara/Common/Water/DA_Fx_SI3_Water_Moto_Putong.DA_Fx_SI3_Water_Moto_Putong");
					}
				}
				else
				{
					this.StopMotorAttachEffect();
				}
			}
			string screenEffectPath = this.GetScreenEffectPath(enviData);
			this.UpdateMotorScreenEffect(screenEffectPath);
		}

		// Token: 0x0602F810 RID: 194576 RVA: 0x00B4DE80 File Offset: 0x00B4C080
		[NullableContext(2)]
		public void UpdateVehicleEffectData(FKuroEnviInteractionData enviData, bool motorState, double cacheMaxSpeed, bool isBlackWave)
		{
			if (!this.IsEnabled || enviData == null || this.Owner == null)
			{
				return;
			}
			this.IsMotorState = motorState;
			this.CacheMaxSpeed = cacheMaxSpeed;
			this.IsBlackWave = isBlackWave;
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
			string attachEffectPath = this.GetAttachEffectPath(enviData);
			if (this.IsMotorState && (baseTagComponent2 == null || !baseTagComponent2.HasTag(GameplayTagDefine.EGameplayTagId["角色.Common.载具驾驶.摩托.状态.空中状态"])) && attachEffectPath != "")
			{
				if (this.CacheMaxSpeed > 100.0 && !enviData.bInWater)
				{
					this.SpawnMotorAttachEffect(attachEffectPath);
				}
				else if (this.IsPlayingAttachEffectButNotWater())
				{
					this.StopMotorAttachEffect();
				}
			}
			else if (this.IsPlayingAttachEffectButNotWater())
			{
				this.StopMotorAttachEffect();
			}
			this.FindNoWaterPhysicalMaterial = enviData.HitPhysicMaterialArray.Contains("DynamicWater");
			string screenEffectPath = this.GetScreenEffectPath(enviData);
			this.UpdateMotorScreenEffect(screenEffectPath);
		}

		// Token: 0x0602F811 RID: 194577 RVA: 0x00B4DF84 File Offset: 0x00B4C184
		public unsafe void OnFallInWater(Vector location, Vector normal)
		{
			if (!this.IsEnabled)
			{
				return;
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.RenderEffect;
			ELogAuthor author = ELogAuthor.LLX;
			string message = "VehicleEffect Spawn Fall In Water";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Owner", this.Owner.GetName());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("vel", this.CacheMaxSpeed);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			this.SpawnFallEffect(location, normal);
		}

		// Token: 0x0602F812 RID: 194578 RVA: 0x00B4E00C File Offset: 0x00B4C20C
		protected void StopMotorAttachEffect()
		{
			int motorAttachHandle = this.MotorAttachHandle;
			if (motorAttachHandle != 0 && Singleton<EffectSystem>.Instance.IsValid(motorAttachHandle))
			{
				Singleton<EffectSystem>.Instance.StopEffectById(motorAttachHandle, "[SceneCharacterWaterEffect.StopMotorAttachEffect]", false, null);
			}
			this.MotorAttachHandle = 0;
			this.MotorAttachHandlePath = "";
		}

		// Token: 0x0602F813 RID: 194579 RVA: 0x00B4E060 File Offset: 0x00B4C260
		protected void StopMotorScreenEffect()
		{
			int effectHandle = this.MotorScreenHandle;
			if (effectHandle != 0 && Singleton<EffectSystem>.Instance.IsValid(effectHandle))
			{
				TimerSystem.Instance.Delay(delegate(float deltaTime)
				{
					if (Singleton<EffectSystem>.Instance.IsValid(effectHandle))
					{
						Singleton<EffectSystem>.Instance.StopEffectById(effectHandle, "[SceneCharacterVehicleEffect.StopMotorScreenEffect]", false, null);
					}
				}, 20f, null, null, true, 1f);
			}
			this.MotorScreenHandle = 0;
			this.MotorScreenHandlePath = "";
		}

		// Token: 0x0602F814 RID: 194580 RVA: 0x00B4E0D0 File Offset: 0x00B4C2D0
		protected void SpawnMotorAttachEffect(string effectDataPath)
		{
			if (this.IsBlackWave || this.CacheMaxSpeed < 100.0 || this.Owner == null)
			{
				return;
			}
			if (!Singleton<EffectSystem>.Instance.IsValid(this.MotorAttachHandle) || this.MotorAttachHandlePath != effectDataPath)
			{
				this.StopMotorAttachEffect();
				EffectSystem instance = Singleton<EffectSystem>.Instance;
				UObject owner = this.Owner;
				FTransformDouble? ftransformDouble = new FTransformDouble?(this.EmptyUeTransform);
				this.MotorAttachHandle = instance.SpawnEffect(owner, ftransformDouble, effectDataPath, "[SceneCharacterWaterEffect.SpawnMotorAttachEffect]", new EffectContext(null, this.Owner, false), EEffectType.Fight, null, null, null, false, false);
				if (Singleton<EffectSystem>.Instance.IsValid(this.MotorAttachHandle))
				{
					OneOf<KuroEffectActorHandle, AActor> effectActor = Singleton<EffectSystem>.Instance.GetEffectActor(this.MotorAttachHandle);
					if (effectActor.HasValue)
					{
						OneOf<KuroEffectActorHandle, AActor> self = effectActor;
						AActor owner2 = this.Owner;
						FName? fname = null;
						self.K2_AttachToActor(owner2, fname, EAttachmentRule.SnapToTarget, EAttachmentRule.SnapToTarget, EAttachmentRule.SnapToTarget, false);
						FTransformDouble ftransformDouble2 = new FTransformDouble();
						FVectorDouble fvectorDouble = new FVectorDouble(0.0, 0.0, -80.0);
						ftransformDouble2.SetLocation(fvectorDouble);
						effectActor.D_K2_SetActorRelativeTransform(ftransformDouble2, false, ref Singleton<PhysicsUtils>.Instance.DefaultHitResult, true);
					}
					this.MotorAttachHandlePath = effectDataPath;
				}
			}
		}

		// Token: 0x0602F815 RID: 194581 RVA: 0x00B4E204 File Offset: 0x00B4C404
		protected string GetScreenEffectPath(FKuroEnviInteractionData enviData)
		{
			if (this.Owner == null || !this.IsMotorState)
			{
				return "";
			}
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
			if (baseTagComponent2 != null && baseTagComponent2.HasTag(GameplayTagDefine.EGameplayTagId["角色.Common.载具驾驶.摩托.冲刺"]) && enviData.bInWater && !this.FindNoWaterPhysicalMaterial && (baseTagComponent2 == null || !baseTagComponent2.HasTag(GameplayTagDefine.EGameplayTagId["GameplayEffect.ShieldWaterMoveEffect"])))
			{
				return "/Game/Aki/Effect/DataAsset/Niagara/Common/Snow/DA_Fx_Sl3_Motuo_Screen01.DA_Fx_Sl3_Motuo_Screen01";
			}
			return "";
		}

		// Token: 0x0602F816 RID: 194582 RVA: 0x00B4E2A0 File Offset: 0x00B4C4A0
		protected void UpdateMotorScreenEffect(string screenEffectPath)
		{
			if (this.IsBlackWave || this.CacheMaxSpeed < 100.0 || this.Owner == null)
			{
				screenEffectPath = "";
			}
			if (screenEffectPath == "")
			{
				if (Singleton<EffectSystem>.Instance.IsValid(this.MotorScreenHandle))
				{
					this.StopMotorScreenEffect();
				}
				return;
			}
			if (Singleton<EffectSystem>.Instance.IsValid(this.MotorScreenHandle) && this.MotorScreenHandlePath == screenEffectPath)
			{
				return;
			}
			this.StopMotorScreenEffect();
			EffectSystem instance = Singleton<EffectSystem>.Instance;
			UObject owner = this.Owner;
			FTransformDouble? ftransformDouble = new FTransformDouble?(this.EmptyUeTransform);
			this.MotorScreenHandle = instance.SpawnEffect(owner, ftransformDouble, screenEffectPath, "[SceneCharacterVehicleEffect.UpdateMotorScreenEffect]", new EffectContext(null, this.Owner, false), EEffectType.Fight, null, null, null, false, false);
			if (Singleton<EffectSystem>.Instance.IsValid(this.MotorScreenHandle))
			{
				OneOf<KuroEffectActorHandle, AActor> effectActor = Singleton<EffectSystem>.Instance.GetEffectActor(this.MotorScreenHandle);
				if (effectActor.HasValue)
				{
					OneOf<KuroEffectActorHandle, AActor> self = effectActor;
					AActor owner2 = this.Owner;
					FName? fname = null;
					self.K2_AttachToActor(owner2, fname, EAttachmentRule.SnapToTarget, EAttachmentRule.SnapToTarget, EAttachmentRule.SnapToTarget, false);
				}
				this.MotorScreenHandlePath = screenEffectPath;
			}
		}

		// Token: 0x0602F817 RID: 194583 RVA: 0x00B4E3B4 File Offset: 0x00B4C5B4
		protected int SpawnFallEffect(Vector location, Vector normal)
		{
			if (this.FindNoWaterPhysicalMaterial)
			{
				return -1;
			}
			FVectorDouble fvectorDouble = location.ToUeVector(false);
			this.EmptyUeTransform.SetLocation(fvectorDouble);
			fvectorDouble = normal.ToUeVector(false);
			FQuat fquat = UKismetMathLibrary.D_MakeRotFromZ(fvectorDouble).Quaternion();
			this.EmptyUeTransform.SetRotation(fquat);
			EffectSystem instance = Singleton<EffectSystem>.Instance;
			UObject world = GlobalData.World;
			FTransformDouble? ftransformDouble = new FTransformDouble?(this.EmptyUeTransform);
			return instance.SpawnUnloopedEffect(world, ftransformDouble, "/Game/Aki/Effect/DataAsset/Niagara/Common/Water/DA_Fx_SI3_Water_Moto_Fall.DA_Fx_SI3_Water_Moto_Fall", "[SceneCharacterVehicleEffect.SpawnFallEffect]", new EffectContext(null, this.Owner, false), EEffectType.Scene, null, null, null, false, false);
		}

		// Token: 0x0602F818 RID: 194584 RVA: 0x00B4E448 File Offset: 0x00B4C648
		protected string GetAttachEffectPath(FKuroEnviInteractionData enviData)
		{
			string result = "";
			if ((enviData.HitPhysicMaterialArray.Contains("DirtLand") || enviData.HitPhysicMaterialArray.Contains("SoilLand")) && !enviData.HitPhysicMaterialArray.Contains("Highway"))
			{
				result = "/Game/Aki/Effect/DataAsset/Niagara/Common/Snow/DA_Fx_Sl3_Moto_ShaChen.DA_Fx_Sl3_Moto_ShaChen";
			}
			if (this.Owner != null)
			{
				if (enviData.HitPhysicMaterialArray.Contains("SnowLand") || enviData.HitPhysicMaterialArray.Contains("PM_LandThickSnow"))
				{
					CharacterActorComponent characterActorComponent = this.Owner.CharacterActorComponent;
					object obj;
					if (characterActorComponent == null)
					{
						obj = null;
					}
					else
					{
						Entity entity = characterActorComponent.Entity;
						obj = ((entity != null) ? entity.GetComponent<BaseTagComponent>() : null);
					}
					object obj2 = obj;
					if (obj2 != null && obj2.HasTag(GameplayTagDefine.EGameplayTagId["角色.Common.载具驾驶.摩托.冲刺"]))
					{
						result = "/Game/Aki/Effect/DataAsset/Niagara/Common/Snow/DA_Fx_Sl3_Moto_Snow_DQ.DA_Fx_Sl3_Moto_Snow_DQ";
					}
					else
					{
						result = "/Game/Aki/Effect/DataAsset/Niagara/Common/Snow/DA_Fx_Sl3_Moto_Snow_PT.DA_Fx_Sl3_Moto_Snow_PT";
					}
					if (obj2 != null && obj2.HasTag(GameplayTagDefine.EGameplayTagId["角色.Common.载具驾驶.摩托.漂移"]))
					{
						if (this.DriftingLift())
						{
							result = "/Game/Aki/Effect/DataAsset/Niagara/Common/Snow/DA_Fx_Sl3_Moto_Snow_SP_L.DA_Fx_Sl3_Moto_Snow_SP_L";
						}
						else
						{
							result = "/Game/Aki/Effect/DataAsset/Niagara/Common/Snow/DA_Fx_Sl3_Moto_Snow_SP_R.DA_Fx_Sl3_Moto_Snow_SP_R";
						}
					}
					if (obj2 != null && obj2.HasTag(GameplayTagDefine.EGameplayTagId["角色.Common.载具驾驶.摩托.烧胎"]))
					{
						result = "/Game/Aki/Effect/DataAsset/Niagara/Common/Snow/DA_Fx_Sl3_Moto_Snow_ST.DA_Fx_Sl3_Moto_Snow_ST";
					}
				}
				else if (enviData.HitTagArray.Contains("ObjTrail"))
				{
					CharacterActorComponent characterActorComponent2 = this.Owner.CharacterActorComponent;
					object obj3;
					if (characterActorComponent2 == null)
					{
						obj3 = null;
					}
					else
					{
						Entity entity2 = characterActorComponent2.Entity;
						obj3 = ((entity2 != null) ? entity2.GetComponent<BaseTagComponent>() : null);
					}
					object obj4 = obj3;
					if (obj4 != null && obj4.HasTag(GameplayTagDefine.EGameplayTagId["角色.Common.载具驾驶.摩托.冲刺"]))
					{
						result = "/Game/Aki/Effect/DataAsset/Niagara/Common/Snow/DA_Fx_Sl3_Moto_Ice_DQ.DA_Fx_Sl3_Moto_Ice_DQ";
					}
					else
					{
						result = "/Game/Aki/Effect/DataAsset/Niagara/Common/Snow/DA_Fx_Sl3_Moto_Ice_PT.DA_Fx_Sl3_Moto_Ice_PT";
					}
					if (obj4 != null && obj4.HasTag(GameplayTagDefine.EGameplayTagId["角色.Common.载具驾驶.摩托.漂移"]))
					{
						if (this.DriftingLift())
						{
							result = "/Game/Aki/Effect/DataAsset/Niagara/Common/Snow/DA_Fx_Sl3_Moto_Ice_SP_L.DA_Fx_Sl3_Moto_Ice_SP_L";
						}
						else
						{
							result = "/Game/Aki/Effect/DataAsset/Niagara/Common/Snow/DA_Fx_Sl3_Moto_Ice_SP_R.DA_Fx_Sl3_Moto_Ice_SP_R";
						}
					}
					if (obj4 != null && obj4.HasTag(GameplayTagDefine.EGameplayTagId["角色.Common.载具驾驶.摩托.烧胎"]))
					{
						result = "/Game/Aki/Effect/DataAsset/Niagara/Common/Snow/DA_Fx_Sl3_Moto_Ice_ST.DA_Fx_Sl3_Moto_Ice_ST";
					}
				}
				if (enviData.HitPhysicMaterialArray.Contains("LightRail"))
				{
					result = "/Game/Aki/Effect/EffectGroup/BigWorld/3_3AnYuan/DA_Fx_Group_Sl2_AY_Glg_MT.DA_Fx_Group_Sl2_AY_Glg_MT";
				}
				else if (enviData.HitPhysicMaterialArray.Contains("XuZhiCube"))
				{
					result = "/Game/Aki/Effect/EffectGroup/BigWorld/3_3AnYuan/DA_Fx_Group_Sl2_AY_3_3_Motuo_Trail.DA_Fx_Group_Sl2_AY_3_3_Motuo_Trail";
				}
			}
			return result;
		}

		// Token: 0x0602F819 RID: 194585 RVA: 0x00B4E665 File Offset: 0x00B4C865
		protected bool IsPlayingAttachEffectButNotWater()
		{
			return this.MotorAttachHandlePath != "" && this.MotorAttachHandlePath != "/Game/Aki/Effect/DataAsset/Niagara/Common/Water/DA_Fx_SI3_Water_Moto_Putong.DA_Fx_SI3_Water_Moto_Putong" && this.MotorAttachHandlePath != "/Game/Aki/Effect/DataAsset/Niagara/Common/Water/DA_Fx_SI3_Water_Moto_Danqi.DA_Fx_SI3_Water_Moto_Danqi";
		}

		// Token: 0x0602F81A RID: 194586 RVA: 0x00B4E69D File Offset: 0x00B4C89D
		protected bool DriftingLift()
		{
			return this.Owner.K2_GetActorRotation().Roll < 0f;
		}

		// Token: 0x0401B272 RID: 111218
		private const string MOTOR_DANQI = "/Game/Aki/Effect/DataAsset/Niagara/Common/Water/DA_Fx_SI3_Water_Moto_Danqi.DA_Fx_SI3_Water_Moto_Danqi";

		// Token: 0x0401B273 RID: 111219
		private const string MOTOR_PUTONG = "/Game/Aki/Effect/DataAsset/Niagara/Common/Water/DA_Fx_SI3_Water_Moto_Putong.DA_Fx_SI3_Water_Moto_Putong";

		// Token: 0x0401B274 RID: 111220
		private const string MOTOR_SHACHEN = "/Game/Aki/Effect/DataAsset/Niagara/Common/Snow/DA_Fx_Sl3_Moto_ShaChen.DA_Fx_Sl3_Moto_ShaChen";

		// Token: 0x0401B275 RID: 111221
		private const string MOTOR_FALL_IN = "/Game/Aki/Effect/DataAsset/Niagara/Common/Water/DA_Fx_SI3_Water_Moto_Fall.DA_Fx_SI3_Water_Moto_Fall";

		// Token: 0x0401B276 RID: 111222
		private const string MOTOR_SCREEN = "/Game/Aki/Effect/DataAsset/Niagara/Common/Snow/DA_Fx_Sl3_Motuo_Screen01.DA_Fx_Sl3_Motuo_Screen01";

		// Token: 0x0401B277 RID: 111223
		private const string ICE_DQ = "/Game/Aki/Effect/DataAsset/Niagara/Common/Snow/DA_Fx_Sl3_Moto_Ice_DQ.DA_Fx_Sl3_Moto_Ice_DQ";

		// Token: 0x0401B278 RID: 111224
		private const string ICE_PT = "/Game/Aki/Effect/DataAsset/Niagara/Common/Snow/DA_Fx_Sl3_Moto_Ice_PT.DA_Fx_Sl3_Moto_Ice_PT";

		// Token: 0x0401B279 RID: 111225
		private const string ICE_SP_L = "/Game/Aki/Effect/DataAsset/Niagara/Common/Snow/DA_Fx_Sl3_Moto_Ice_SP_L.DA_Fx_Sl3_Moto_Ice_SP_L";

		// Token: 0x0401B27A RID: 111226
		private const string ICE_SP_R = "/Game/Aki/Effect/DataAsset/Niagara/Common/Snow/DA_Fx_Sl3_Moto_Ice_SP_R.DA_Fx_Sl3_Moto_Ice_SP_R";

		// Token: 0x0401B27B RID: 111227
		private const string ICE_ST = "/Game/Aki/Effect/DataAsset/Niagara/Common/Snow/DA_Fx_Sl3_Moto_Ice_ST.DA_Fx_Sl3_Moto_Ice_ST";

		// Token: 0x0401B27C RID: 111228
		private const string SNOW_DQ = "/Game/Aki/Effect/DataAsset/Niagara/Common/Snow/DA_Fx_Sl3_Moto_Snow_DQ.DA_Fx_Sl3_Moto_Snow_DQ";

		// Token: 0x0401B27D RID: 111229
		private const string SNOW_PT = "/Game/Aki/Effect/DataAsset/Niagara/Common/Snow/DA_Fx_Sl3_Moto_Snow_PT.DA_Fx_Sl3_Moto_Snow_PT";

		// Token: 0x0401B27E RID: 111230
		private const string SNOW_SP_L = "/Game/Aki/Effect/DataAsset/Niagara/Common/Snow/DA_Fx_Sl3_Moto_Snow_SP_L.DA_Fx_Sl3_Moto_Snow_SP_L";

		// Token: 0x0401B27F RID: 111231
		private const string SNOW_SP_R = "/Game/Aki/Effect/DataAsset/Niagara/Common/Snow/DA_Fx_Sl3_Moto_Snow_SP_R.DA_Fx_Sl3_Moto_Snow_SP_R";

		// Token: 0x0401B280 RID: 111232
		private const string SNOW_ST = "/Game/Aki/Effect/DataAsset/Niagara/Common/Snow/DA_Fx_Sl3_Moto_Snow_ST.DA_Fx_Sl3_Moto_Snow_ST";

		// Token: 0x0401B281 RID: 111233
		private const string MOTOR_LIGHT_RAIL = "/Game/Aki/Effect/EffectGroup/BigWorld/3_3AnYuan/DA_Fx_Group_Sl2_AY_Glg_MT.DA_Fx_Group_Sl2_AY_Glg_MT";

		// Token: 0x0401B282 RID: 111234
		private const string MOTOR_XU_ZHI_CUBE = "/Game/Aki/Effect/EffectGroup/BigWorld/3_3AnYuan/DA_Fx_Group_Sl2_AY_3_3_Motuo_Trail.DA_Fx_Group_Sl2_AY_3_3_Motuo_Trail";

		// Token: 0x0401B283 RID: 111235
		private const double MOTOR_EFFECT_SPEED_CLAMP = 100.0;

		// Token: 0x0401B284 RID: 111236
		[Nullable(2)]
		public TsBaseCharacter Owner;

		// Token: 0x0401B285 RID: 111237
		public bool IsReady;

		// Token: 0x0401B286 RID: 111238
		public bool IsEnabled;

		// Token: 0x0401B287 RID: 111239
		protected int MotorAttachHandle;

		// Token: 0x0401B288 RID: 111240
		protected string MotorAttachHandlePath = "";

		// Token: 0x0401B289 RID: 111241
		protected int MotorScreenHandle;

		// Token: 0x0401B28A RID: 111242
		protected string MotorScreenHandlePath = "";

		// Token: 0x0401B28B RID: 111243
		protected double CacheMaxSpeed;

		// Token: 0x0401B28C RID: 111244
		protected FTransformDouble EmptyUeTransform = new FTransformDouble();

		// Token: 0x0401B28D RID: 111245
		protected bool IsMotorState;

		// Token: 0x0401B28E RID: 111246
		protected bool FindNoWaterPhysicalMaterial;

		// Token: 0x0401B28F RID: 111247
		public bool IsVehicleWaterState;

		// Token: 0x0401B290 RID: 111248
		public bool IsBlackWave;

		// Token: 0x0401B291 RID: 111249
		[Nullable(2)]
		protected FKuroEnviInteractionData EnviData;
	}
}
