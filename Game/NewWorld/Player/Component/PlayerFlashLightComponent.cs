using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.Role.Common.Data.Structure;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Common.Event;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.Player.Component
{
	// Token: 0x0200489F RID: 18591
	[NullableContext(1)]
	[Nullable(0)]
	public class PlayerFlashLightComponent : EntityComponent
	{
		// Token: 0x0603070D RID: 198413 RVA: 0x00BDFBC8 File Offset: 0x00BDDDC8
		protected override bool OnStart()
		{
			this.TagComp = base.Entity.CheckGetComponent<PlayerTagComponent>();
			this.DisableKey = new int?(base.Disable("OnStart"));
			this.SwitchFlashLight = this.TagComp.ListenForTagAddOrRemove(new int?(GameplayTagDefine.EGameplayTagId["功能.功能制作.启动手电筒"]), delegate(int tagId, bool tagExists)
			{
				this.EnableFlashLight(tagExists);
			}, null);
			Singleton<EventSystem>.Instance.Add(EEventName.ClearWorld, new Action(this.OnClearWorld));
			Singleton<EventSystem>.Instance.Add(EEventName.WorldDone, new Action(this.OnWorldDone));
			return true;
		}

		// Token: 0x0603070E RID: 198414 RVA: 0x00BDFC67 File Offset: 0x00BDDE67
		protected override void OnTick(float delta)
		{
			if (!this.IsEnabled)
			{
				return;
			}
			this.UpdateFlashLightTransform(delta * 0.001f);
		}

		// Token: 0x0603070F RID: 198415 RVA: 0x00BDFC80 File Offset: 0x00BDDE80
		protected override bool OnEnd()
		{
			ITagTask switchFlashLight = this.SwitchFlashLight;
			if (switchFlashLight != null)
			{
				switchFlashLight.EndTask();
			}
			Singleton<EventSystem>.Instance.Remove(EEventName.ClearWorld, new Action(this.OnClearWorld));
			Singleton<EventSystem>.Instance.Remove(EEventName.WorldDone, new Action(this.OnWorldDone));
			return true;
		}

		// Token: 0x06030710 RID: 198416 RVA: 0x00BDFCD7 File Offset: 0x00BDDED7
		protected override void OnEnable()
		{
			this.EnableFlashLight(true);
		}

		// Token: 0x06030711 RID: 198417 RVA: 0x00BDFCE0 File Offset: 0x00BDDEE0
		protected override void OnDisable(string reason)
		{
			this.EnableFlashLight(false);
		}

		// Token: 0x06030712 RID: 198418 RVA: 0x00BDFCEC File Offset: 0x00BDDEEC
		protected void EnableFlashLight(bool enable)
		{
			if (this.IsEnabled == enable)
			{
				return;
			}
			this.IsEnabled = enable;
			if (enable && this.DisableKey != null)
			{
				this.LoadAndInitFlashLightActor();
				base.Enable(this.DisableKey, "EnableFlashLight");
				this.DisableKey = null;
				return;
			}
			if (!enable && this.DisableKey == null)
			{
				Singleton<ActorSystem>.Instance.Put("DisableFlashLight", this.FlashLightActor, null);
				this.FlashLightActor = null;
				this.DisableKey = new int?(base.Disable("DisableFlashLight"));
			}
		}

		// Token: 0x06030713 RID: 198419 RVA: 0x00BDFD83 File Offset: 0x00BDDF83
		protected void LoadAndInitFlashLightActor()
		{
			Singleton<ResourceSystem>.Instance.LoadTypeAsync("BP_FlashLightConfig_C", delegate
			{
				Singleton<ResourceSystem>.Instance.LoadAsync<BP_FlashLightConfig_C>("/Game/Aki/Character/Role/Common/Data/DA/DA_FlashLightCommon.DA_FlashLightCommon", delegate([Nullable(2)] BP_FlashLightConfig_C asset, string _)
				{
					if (asset == null || !asset.IsValid())
					{
						return;
					}
					if (!this.IsEnabled)
					{
						return;
					}
					FlashLightConfig flashLightConfig = new FlashLightConfig();
					flashLightConfig.Init(asset);
					if (!flashLightConfig.IsValid())
					{
						return;
					}
					this.InitFlashLightParams(flashLightConfig).Forget();
				}, 100, "js_undefined");
			}, "js_undefined");
		}

		// Token: 0x06030714 RID: 198420 RVA: 0x00BDFDA8 File Offset: 0x00BDDFA8
		protected UniTask InitFlashLightParams(FlashLightConfig config)
		{
			PlayerFlashLightComponent.<InitFlashLightParams>d__23 <InitFlashLightParams>d__;
			<InitFlashLightParams>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitFlashLightParams>d__.<>4__this = this;
			<InitFlashLightParams>d__.config = config;
			<InitFlashLightParams>d__.<>1__state = -1;
			<InitFlashLightParams>d__.<>t__builder.Start<PlayerFlashLightComponent.<InitFlashLightParams>d__23>(ref <InitFlashLightParams>d__);
			return <InitFlashLightParams>d__.<>t__builder.Task;
		}

		// Token: 0x06030715 RID: 198421 RVA: 0x00BDFDF4 File Offset: 0x00BDDFF4
		protected void UpdateFlashLightTransform(float deltaSecond)
		{
			EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
			WorldEntity worldEntity = (getCurrentEntity != null) ? getCurrentEntity.Entity : null;
			if (worldEntity != null)
			{
				FlashLightConfig config = this.Config;
				if (config != null && config.IsValid())
				{
					AActor flashLightActor = this.FlashLightActor;
					if (flashLightActor != null && flashLightActor.IsValid())
					{
						BaseActorComponent component = worldEntity.GetComponent<BaseActorComponent>();
						Transform tmpTrans = this.TmpTrans1;
						FTransformDouble ftransformDouble = component.ActorTransform;
						tmpTrans.FromUeTransform(ftransformDouble);
						this.Config.RelativeTrans.ComposeTransforms(this.TmpTrans1, this.TmpTrans2);
						this.TmpTrans1.Reset();
						this.TmpTrans1.SetLocation(this.TmpTrans2.GetLocation());
						this.TmpVector1.DeepCopy(component.ActorForwardProxy);
						Singleton<GravityUtils>.Instance.ConvertToPlanarVectorForActor(component, this.TmpVector1);
						Singleton<GravityUtils>.Instance.GetBaseQuatInGravityForActor(component, this.TmpQuat1);
						this.TmpQuat1.Inverse(this.TmpQuat2);
						this.TmpQuat2.RotateVector(this.TmpVector1, this.TmpVector2);
						this.TmpVector2.GetSafeNormal(this.TmpVector1, 9.99999993922529E-09);
						double num = this.TmpVector1.HeadingAngle();
						double num2 = 1.5707963267948966;
						if (this.Config.IsUseCameraPitch)
						{
							ControllerBase<CameraController>.Instance.GetCameraRotation(this.TmpRotator, "MainCamera");
							this.TmpRotator.Vector(this.TmpVector1);
							double znInGravityForActor = Singleton<GravityUtils>.Instance.GetZnInGravityForActor(component, this.TmpVector1);
							double num3 = Math.Acos(Singleton<MathUtils>.Instance.Clamp(znInGravityForActor, -1.0, 1.0));
							num2 = num3;
							if (this.Config.IsUsePitchLerp && this.LastPitchRad != 360f && deltaSecond > 0f)
							{
								double num4 = Math.Abs(num3 - (double)this.LastPitchRad) * 57.295780181884766;
								float lerpDegAlpha = this.Config.GetLerpDegAlpha((float)Singleton<MathUtils>.Instance.Clamp(num4 / (double)this.Config.LerpBeginDeg, 0.0, 1.0));
								float num5 = Singleton<MathUtils>.Instance.Lerp(this.Config.MinTurnSpeed, this.Config.MaxTurnSpeed, lerpDegAlpha) * 0.017453292f;
								num2 = Singleton<MathUtils>.Instance.InterpConstantTo((double)this.LastPitchRad, num3, (double)deltaSecond, (double)num5);
							}
						}
						double inX = Math.Cos(num) * Math.Sin(num2);
						double inY = Math.Sin(num) * Math.Sin(num2);
						double inZ = Math.Cos(num2);
						this.TmpVector1.Set(inX, inY, inZ);
						this.TmpVector1.Rotation(this.TmpRotator);
						this.TmpQuat1.Multiply(this.TmpRotator.Quaternion(null), this.TmpQuat2);
						this.TmpTrans1.SetRotation(this.TmpQuat2);
						AActor flashLightActor2 = this.FlashLightActor;
						ftransformDouble = this.TmpTrans1.ToUeTransform();
						flashLightActor2.D_K2_SetActorTransform(ftransformDouble, false, null, false);
						this.LastPitchRad = (float)num2;
						return;
					}
				}
			}
		}

		// Token: 0x06030716 RID: 198422 RVA: 0x00BE00FB File Offset: 0x00BDE2FB
		protected void OnClearWorld()
		{
			if (!this.IsEnabled)
			{
				return;
			}
			if (this.FlashLightActor != null)
			{
				Singleton<ActorSystem>.Instance.Put("FlashLightComp.OnClearWorld", this.FlashLightActor, null);
				this.FlashLightActor = null;
			}
		}

		// Token: 0x06030717 RID: 198423 RVA: 0x00BE012C File Offset: 0x00BDE32C
		protected void OnWorldDone()
		{
			if (!this.IsEnabled)
			{
				return;
			}
			if (this.FlashLightActor != null)
			{
				Singleton<ActorSystem>.Instance.Put("FlashLightComp.OnWorldDone", this.FlashLightActor, null);
				this.FlashLightActor = null;
			}
			this.InitFlashLightParams(this.Config).Forget();
		}

		// Token: 0x06030718 RID: 198424 RVA: 0x00BE017C File Offset: 0x00BDE37C
		public override bool ClearComponent(EntityComponent componentTemplate)
		{
			if (!base.ClearComponent(componentTemplate))
			{
				return false;
			}
			PlayerFlashLightComponent playerFlashLightComponent = (PlayerFlashLightComponent)componentTemplate;
			if (base.CanResetComponentProperty("TagComp"))
			{
				if (playerFlashLightComponent.TagComp == null)
				{
					this.TagComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<PlayerTagComponent>(this.TagComp), "TagComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("DisableKey"))
			{
				this.DisableKey = playerFlashLightComponent.DisableKey;
			}
			if (base.CanResetComponentProperty("SwitchFlashLight"))
			{
				if (playerFlashLightComponent.SwitchFlashLight == null)
				{
					this.SwitchFlashLight = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<ITagTask>(this.SwitchFlashLight), "SwitchFlashLight"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("Config"))
			{
				if (playerFlashLightComponent.Config == null)
				{
					this.Config = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<FlashLightConfig>(this.Config), "Config"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("FlashLightActor"))
			{
				if (playerFlashLightComponent.FlashLightActor == null)
				{
					this.FlashLightActor = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<AActor>(this.FlashLightActor), "FlashLightActor"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("IsEnabled"))
			{
				this.IsEnabled = playerFlashLightComponent.IsEnabled;
			}
			if (base.CanResetComponentProperty("LastPitchRad"))
			{
				this.LastPitchRad = playerFlashLightComponent.LastPitchRad;
			}
			if (base.CanResetComponentProperty("TmpVector1"))
			{
				if (playerFlashLightComponent.TmpVector1 == null)
				{
					this.TmpVector1 = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Vector>(this.TmpVector1), "TmpVector1"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("TmpVector2"))
			{
				if (playerFlashLightComponent.TmpVector2 == null)
				{
					this.TmpVector2 = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Vector>(this.TmpVector2), "TmpVector2"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("TmpRotator"))
			{
				if (playerFlashLightComponent.TmpRotator == null)
				{
					this.TmpRotator = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Rotator>(this.TmpRotator), "TmpRotator"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("TmpTrans1"))
			{
				if (playerFlashLightComponent.TmpTrans1 == null)
				{
					this.TmpTrans1 = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Transform>(this.TmpTrans1), "TmpTrans1"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("TmpTrans2"))
			{
				if (playerFlashLightComponent.TmpTrans2 == null)
				{
					this.TmpTrans2 = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Transform>(this.TmpTrans2), "TmpTrans2"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("TmpQuat1"))
			{
				if (playerFlashLightComponent.TmpQuat1 == null)
				{
					this.TmpQuat1 = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Quat>(this.TmpQuat1), "TmpQuat1"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("TmpQuat2"))
			{
				if (playerFlashLightComponent.TmpQuat2 == null)
				{
					this.TmpQuat2 = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Quat>(this.TmpQuat2), "TmpQuat2"))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x0401BD32 RID: 113970
		private const string FLASH_LIGHT_CONFIG_PATH = "/Game/Aki/Character/Role/Common/Data/DA/DA_FlashLightCommon.DA_FlashLightCommon";

		// Token: 0x0401BD33 RID: 113971
		private const float INVALID_PITCH_RAD = 360f;

		// Token: 0x0401BD34 RID: 113972
		[Nullable(2)]
		protected PlayerTagComponent TagComp;

		// Token: 0x0401BD35 RID: 113973
		private int? DisableKey;

		// Token: 0x0401BD36 RID: 113974
		[Nullable(2)]
		private ITagTask SwitchFlashLight;

		// Token: 0x0401BD37 RID: 113975
		[Nullable(2)]
		protected FlashLightConfig Config;

		// Token: 0x0401BD38 RID: 113976
		[Nullable(2)]
		protected AActor FlashLightActor;

		// Token: 0x0401BD39 RID: 113977
		protected bool IsEnabled;

		// Token: 0x0401BD3A RID: 113978
		protected float LastPitchRad = 360f;

		// Token: 0x0401BD3B RID: 113979
		protected Vector TmpVector1 = Vector.Create();

		// Token: 0x0401BD3C RID: 113980
		protected Vector TmpVector2 = Vector.Create();

		// Token: 0x0401BD3D RID: 113981
		protected Rotator TmpRotator = Rotator.Create();

		// Token: 0x0401BD3E RID: 113982
		protected Transform TmpTrans1 = Transform.Create();

		// Token: 0x0401BD3F RID: 113983
		protected Transform TmpTrans2 = Transform.Create();

		// Token: 0x0401BD40 RID: 113984
		protected Quat TmpQuat1 = Quat.Create(0f, 0f, 0f, 1f);

		// Token: 0x0401BD41 RID: 113985
		protected Quat TmpQuat2 = Quat.Create(0f, 0f, 0f, 1f);
	}
}
