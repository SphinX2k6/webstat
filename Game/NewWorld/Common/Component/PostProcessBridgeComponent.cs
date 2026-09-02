using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.TDConfigMgr.Component;
using CSharpScript.Core.Common;
using CSharpScript.Game.NewWorld.Character.Custom.Components;
using CSharpScript.Game.World.Controller;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.Common.Component
{
	// Token: 0x020048C8 RID: 18632
	[NullableContext(2)]
	[Nullable(0)]
	public class PostProcessBridgeComponent : EntityComponent
	{
		// Token: 0x0603098F RID: 199055 RVA: 0x00BF40C4 File Offset: 0x00BF22C4
		protected override bool OnInitData(IEntityArgs args = null)
		{
			SkyboxComponent skyboxComponent = args.GetP1<CreateEntityData>().GetParam<PostProcessBridgeComponent>() as SkyboxComponent;
			int? skyboxSetting = skyboxComponent.SkyboxSetting;
			if (skyboxSetting != null && skyboxSetting.GetValueOrDefault() != 0)
			{
				Skybox? config = ConfigSkyboxById.GetConfig(skyboxComponent.SkyboxSetting.Value, true);
				if (config != null)
				{
					this.WeatherDataAssetPath = config.Value.StaticSkybox;
					this.TodDataAssetPath = config.Value.DynamicSkybox;
				}
			}
			else
			{
				this.WeatherDataAssetPath = skyboxComponent.WeatherDataAsset;
				this.TodDataAssetPath = skyboxComponent.PPTODDataAsset;
			}
			float? num;
			float num2;
			if (skyboxComponent.FadeTime != null)
			{
				num = skyboxComponent.FadeTime;
				num2 = 0f;
				if (num.GetValueOrDefault() > num2 & num != null)
				{
					this.ChangeSpeed = (1f / (skyboxComponent.FadeTime * (float)Singleton<TimeUtil>.Instance.InverseMillisecond)).Value;
					goto IL_147;
				}
			}
			this.ChangeSpeed = 0f;
			IL_147:
			num = skyboxComponent.Priority;
			num2 = 0f;
			this.Priority = ((!(num.GetValueOrDefault() == num2 & num != null)) ? skyboxComponent.Priority.Value : 10f);
			this.ActiveByTriggerComponent = (skyboxComponent.TriggerMode == null);
			this.TriggerMode = skyboxComponent.TriggerMode;
			ISkyboxTrigger triggerMode = skyboxComponent.TriggerMode;
			if (triggerMode != null && triggerMode.Type == ETriggerMode.Distance)
			{
				ISkyboxDistanceTrigger skyboxDistanceTrigger = skyboxComponent.TriggerMode as ISkyboxDistanceTrigger;
				this.TriggerDistanceSquared = new float?(skyboxDistanceTrigger.Distance * skyboxDistanceTrigger.Distance);
			}
			else
			{
				this.TriggerDistanceSquared = new float?(0f);
			}
			this.TickTime = 0f;
			this.InTrigger = false;
			return true;
		}

		// Token: 0x06030990 RID: 199056 RVA: 0x00BF42D8 File Offset: 0x00BF24D8
		protected unsafe override bool OnStart()
		{
			AActor owner = base.Entity.GetComponent<BaseActorComponent>().Owner;
			if (owner == null || !owner.IsValid())
			{
				Singleton<Log>.Instance.Error(ELogModule.Entity, ELogAuthor.CFT, "氛围组件初始化失败, actor为空", default(ReadOnlySpan<ValueTuple<string, object>>));
				return false;
			}
			this.Actor = owner;
			this.KuroPostProcessComponent = (owner.GetComponentByClass(UKuroPostProcessComponent.StaticClass()) as UKuroPostProcessComponent);
			UKuroPostProcessComponent kuroPostProcessComponent = this.KuroPostProcessComponent;
			if (kuroPostProcessComponent == null || !kuroPostProcessComponent.IsValid())
			{
				this.KuroPostProcessComponent = (owner.AddComponentByClass(UKuroPostProcessComponent.StaticClass(), false, Singleton<MathUtils>.Instance.DefaultTransform, false, default(FName)) as UKuroPostProcessComponent);
			}
			this.KuroPostProcessComponent.bUnbound = true;
			this.KuroPostProcessComponent.BlendWeight = this.CurBlendWeight;
			this.UpdatePostProcessComponentEnable();
			if (this.ActiveByTriggerComponent)
			{
				this.RangeComponent = base.Entity.GetComponent<CSharpScript.Game.NewWorld.Character.Custom.Components.RangeComponent>();
				if (!this.RangeComponent)
				{
					this.IsInit = false;
					Singleton<Log>.Instance.Error(ELogModule.Entity, ELogAuthor.CFT, "氛围组件初始化失败，缺少RangeComponent", default(ReadOnlySpan<ValueTuple<string, object>>));
					return false;
				}
				this.RangeComponent.AddOnPlayerOverlapCallback(new Action<bool>(this.OnPlayerTrigger));
			}
			this.IsInit = true;
			this.EnableComponent();
			if (!string.IsNullOrEmpty(this.WeatherDataAssetPath))
			{
				Singleton<ResourceSystem>.Instance.LoadAsync<UKuroWeatherDataAsset>(this.WeatherDataAssetPath, delegate([Nullable(2)] UKuroWeatherDataAsset dataAsset, string _)
				{
					if (dataAsset == null || !dataAsset.IsValid())
					{
						return;
					}
					this.WeatherDataAsset = dataAsset;
					this.KuroPostProcessComponent.WeatherDataAsset = this.WeatherDataAsset;
					this.KuroPostProcessComponent.SetPriority(this.Priority);
				}, 100, "js_undefined");
				return true;
			}
			if (!string.IsNullOrEmpty(this.TodDataAssetPath))
			{
				Singleton<ResourceSystem>.Instance.LoadAsync<UKuroTODData>(this.TodDataAssetPath, delegate([Nullable(2)] UKuroTODData dataAsset, string _)
				{
					if (dataAsset == null || !dataAsset.IsValid())
					{
						return;
					}
					this.TodDataAsset = dataAsset;
					this.KuroPostProcessComponent.PPTODDataAsset = this.TodDataAsset;
					this.KuroPostProcessComponent.SetPriority(this.Priority);
				}, 100, "js_undefined");
				return true;
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Entity;
			ELogAuthor author = ELogAuthor.CFT;
			string message = "氛围组件初始化失败";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("WeatherDataAssetPath", this.WeatherDataAssetPath);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("TodDataAssetPath", this.TodDataAssetPath);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return false;
		}

		// Token: 0x06030991 RID: 199057 RVA: 0x00BF44E6 File Offset: 0x00BF26E6
		private void OnPlayerTrigger(bool isEnter)
		{
			if (isEnter)
			{
				this.OnTriggerEnter();
				return;
			}
			this.OnTriggerExit();
		}

		// Token: 0x06030992 RID: 199058 RVA: 0x00BF44F8 File Offset: 0x00BF26F8
		public void OnTriggerEnter()
		{
			if (!this.IsInit || !this.IsEnabled)
			{
				return;
			}
			this.InTrigger = true;
			this.SetTargetBlendWeight(1f, false);
		}

		// Token: 0x06030993 RID: 199059 RVA: 0x00BF451E File Offset: 0x00BF271E
		public void OnTriggerExit()
		{
			if (!this.IsInit || !this.IsEnabled)
			{
				return;
			}
			this.InTrigger = false;
			this.SetTargetBlendWeight(0f, false);
		}

		// Token: 0x06030994 RID: 199060 RVA: 0x00BF4544 File Offset: 0x00BF2744
		public void SetTargetBlendWeight(float blendWeight, bool immediately = false)
		{
			if (!this.IsInit)
			{
				return;
			}
			this.TargetBlendWeight = blendWeight;
			if (immediately || this.ChangeSpeed == 0f)
			{
				this.CurBlendWeight = blendWeight;
				this.KuroPostProcessComponent.BlendWeight = this.CurBlendWeight;
				this.UpdatePostProcessComponentEnable();
			}
		}

		// Token: 0x06030995 RID: 199061 RVA: 0x00BF4584 File Offset: 0x00BF2784
		public void EnableComponent()
		{
			if (!this.IsInit)
			{
				return;
			}
			this.IsEnabled = true;
			this.TickTime = 1000f;
			this.InTrigger = false;
			if (this.ActiveByTriggerComponent)
			{
				if (this.RangeComponent.IsOverlappingPlayer())
				{
					this.OnTriggerEnter();
					return;
				}
			}
			else
			{
				ISkyboxTrigger triggerMode = this.TriggerMode;
				if (triggerMode != null && triggerMode.Type == ETriggerMode.Global)
				{
					this.OnTriggerEnter();
				}
			}
		}

		// Token: 0x06030996 RID: 199062 RVA: 0x00BF45EC File Offset: 0x00BF27EC
		public void DisableComponent()
		{
			if (!this.IsInit)
			{
				return;
			}
			this.IsEnabled = false;
			this.SetTargetBlendWeight(0f, false);
		}

		// Token: 0x06030997 RID: 199063 RVA: 0x00BF460A File Offset: 0x00BF280A
		protected override void OnActivate()
		{
			if (!Singleton<Info>.Instance.EnableForceTick && base.Active)
			{
				ControllerBase<ComponentForceTickController>.Instance.RegisterTick(this, new Action<float>(this.ForceTickInternal));
			}
		}

		// Token: 0x06030998 RID: 199064 RVA: 0x00BF4637 File Offset: 0x00BF2837
		protected override void OnEnable()
		{
			if (!Singleton<Info>.Instance.EnableForceTick)
			{
				Entity entity = base.Entity;
				if (entity != null && entity.IsInit)
				{
					ControllerBase<ComponentForceTickController>.Instance.RegisterTick(this, new Action<float>(this.ForceTickInternal));
				}
			}
		}

		// Token: 0x06030999 RID: 199065 RVA: 0x00BF4670 File Offset: 0x00BF2870
		[NullableContext(1)]
		protected override void OnDisable(string reason)
		{
			if (!Singleton<Info>.Instance.EnableForceTick)
			{
				ControllerBase<ComponentForceTickController>.Instance.UnregisterTick(this);
			}
		}

		// Token: 0x0603099A RID: 199066 RVA: 0x00BF4689 File Offset: 0x00BF2889
		protected override void OnForceTick(float delta)
		{
			this.ForceTickInternal(delta);
		}

		// Token: 0x0603099B RID: 199067 RVA: 0x00BF4694 File Offset: 0x00BF2894
		private void ForceTickInternal(float delta)
		{
			if (!this.IsInit)
			{
				return;
			}
			float? triggerDistanceSquared = this.TriggerDistanceSquared;
			float num = 0f;
			if (triggerDistanceSquared.GetValueOrDefault() > num & triggerDistanceSquared != null)
			{
				this.CheckInTriggerByTriggerDistance(delta);
			}
			if (Math.Abs(this.CurBlendWeight - this.TargetBlendWeight) < 1E-45f)
			{
				return;
			}
			if (this.TargetBlendWeight > this.CurBlendWeight)
			{
				this.CurBlendWeight += delta * this.ChangeSpeed;
				this.CurBlendWeight = Math.Min(this.CurBlendWeight, this.TargetBlendWeight);
			}
			else
			{
				this.CurBlendWeight -= delta * this.ChangeSpeed;
				this.CurBlendWeight = Math.Max(this.CurBlendWeight, this.TargetBlendWeight);
			}
			this.KuroPostProcessComponent.BlendWeight = this.CurBlendWeight;
			this.UpdatePostProcessComponentEnable();
		}

		// Token: 0x0603099C RID: 199068 RVA: 0x00BF476C File Offset: 0x00BF296C
		private void CheckInTriggerByTriggerDistance(float delta)
		{
			this.TickTime += delta;
			if (this.TickTime < 1000f)
			{
				return;
			}
			this.TickTime = 0f;
			AActor myRoleTrigger = ControllerBase<RoleTriggerController>.Instance.GetMyRoleTrigger();
			if (myRoleTrigger != null && myRoleTrigger.IsValid())
			{
				AActor actor = this.Actor;
				if (actor != null && actor.IsValid())
				{
					float squaredDistanceTo = myRoleTrigger.GetSquaredDistanceTo(this.Actor);
					float? triggerDistanceSquared = this.TriggerDistanceSquared;
					bool flag = squaredDistanceTo < triggerDistanceSquared.GetValueOrDefault() & triggerDistanceSquared != null;
					if (!this.InTrigger)
					{
						if (flag)
						{
							this.OnTriggerEnter();
							return;
						}
					}
					else if (!flag)
					{
						this.OnTriggerExit();
					}
					return;
				}
			}
		}

		// Token: 0x0603099D RID: 199069 RVA: 0x00BF4814 File Offset: 0x00BF2A14
		private void UpdatePostProcessComponentEnable()
		{
			this.KuroPostProcessComponent.bEnabled = (this.CurBlendWeight > 0f);
		}

		// Token: 0x0603099E RID: 199070 RVA: 0x00BF4830 File Offset: 0x00BF2A30
		protected override bool OnEnd()
		{
			if (this.RangeComponent != null)
			{
				this.RangeComponent.RemoveOnPlayerOverlapCallback(new Action<bool>(this.OnPlayerTrigger));
				this.RangeComponent = null;
			}
			this.IsInit = false;
			if (!Singleton<Info>.Instance.EnableForceTick)
			{
				ControllerBase<ComponentForceTickController>.Instance.UnregisterTick(this);
			}
			return true;
		}

		// Token: 0x0603099F RID: 199071 RVA: 0x00BF4884 File Offset: 0x00BF2A84
		[NullableContext(1)]
		public override bool ClearComponent(EntityComponent componentTemplate)
		{
			if (!base.ClearComponent(componentTemplate))
			{
				return false;
			}
			PostProcessBridgeComponent postProcessBridgeComponent = (PostProcessBridgeComponent)componentTemplate;
			if (base.CanResetComponentProperty("IsInit"))
			{
				this.IsInit = postProcessBridgeComponent.IsInit;
			}
			if (base.CanResetComponentProperty("IsEnabled"))
			{
				this.IsEnabled = postProcessBridgeComponent.IsEnabled;
			}
			if (base.CanResetComponentProperty("WeatherDataAssetPath"))
			{
				this.WeatherDataAssetPath = postProcessBridgeComponent.WeatherDataAssetPath;
			}
			if (base.CanResetComponentProperty("TodDataAssetPath"))
			{
				this.TodDataAssetPath = postProcessBridgeComponent.TodDataAssetPath;
			}
			if (base.CanResetComponentProperty("WeatherDataAsset"))
			{
				if (postProcessBridgeComponent.WeatherDataAsset == null)
				{
					this.WeatherDataAsset = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<UKuroWeatherDataAsset>(this.WeatherDataAsset), "WeatherDataAsset"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("TodDataAsset"))
			{
				if (postProcessBridgeComponent.TodDataAsset == null)
				{
					this.TodDataAsset = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<UKuroTODData>(this.TodDataAsset), "TodDataAsset"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("RangeComponent"))
			{
				if (postProcessBridgeComponent.RangeComponent == null)
				{
					this.RangeComponent = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CSharpScript.Game.NewWorld.Character.Custom.Components.RangeComponent>(this.RangeComponent), "RangeComponent"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("KuroPostProcessComponent"))
			{
				if (postProcessBridgeComponent.KuroPostProcessComponent == null)
				{
					this.KuroPostProcessComponent = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<UKuroPostProcessComponent>(this.KuroPostProcessComponent), "KuroPostProcessComponent"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("Actor"))
			{
				if (postProcessBridgeComponent.Actor == null)
				{
					this.Actor = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<AActor>(this.Actor), "Actor"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("ActiveByTriggerComponent"))
			{
				this.ActiveByTriggerComponent = postProcessBridgeComponent.ActiveByTriggerComponent;
			}
			if (base.CanResetComponentProperty("TriggerMode"))
			{
				if (postProcessBridgeComponent.TriggerMode == null)
				{
					this.TriggerMode = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<ISkyboxTrigger>(this.TriggerMode), "TriggerMode"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("TriggerDistanceSquared"))
			{
				this.TriggerDistanceSquared = postProcessBridgeComponent.TriggerDistanceSquared;
			}
			if (base.CanResetComponentProperty("TickTime"))
			{
				this.TickTime = postProcessBridgeComponent.TickTime;
			}
			if (base.CanResetComponentProperty("InTrigger"))
			{
				this.InTrigger = postProcessBridgeComponent.InTrigger;
			}
			if (base.CanResetComponentProperty("ChangeSpeed"))
			{
				this.ChangeSpeed = postProcessBridgeComponent.ChangeSpeed;
			}
			if (base.CanResetComponentProperty("Priority"))
			{
				this.Priority = postProcessBridgeComponent.Priority;
			}
			if (base.CanResetComponentProperty("TargetBlendWeight"))
			{
				this.TargetBlendWeight = postProcessBridgeComponent.TargetBlendWeight;
			}
			if (base.CanResetComponentProperty("CurBlendWeight"))
			{
				this.CurBlendWeight = postProcessBridgeComponent.CurBlendWeight;
			}
			return true;
		}

		// Token: 0x0401BEC3 RID: 114371
		private const int DEFAULT_PRIORITY = 10;

		// Token: 0x0401BEC4 RID: 114372
		private const int TICK_TIME = 1000;

		// Token: 0x0401BEC5 RID: 114373
		private bool IsInit;

		// Token: 0x0401BEC6 RID: 114374
		private bool IsEnabled;

		// Token: 0x0401BEC7 RID: 114375
		private string WeatherDataAssetPath;

		// Token: 0x0401BEC8 RID: 114376
		private string TodDataAssetPath;

		// Token: 0x0401BEC9 RID: 114377
		private UKuroWeatherDataAsset WeatherDataAsset;

		// Token: 0x0401BECA RID: 114378
		private UKuroTODData TodDataAsset;

		// Token: 0x0401BECB RID: 114379
		private CSharpScript.Game.NewWorld.Character.Custom.Components.RangeComponent RangeComponent;

		// Token: 0x0401BECC RID: 114380
		private UKuroPostProcessComponent KuroPostProcessComponent;

		// Token: 0x0401BECD RID: 114381
		private AActor Actor;

		// Token: 0x0401BECE RID: 114382
		private bool ActiveByTriggerComponent = true;

		// Token: 0x0401BECF RID: 114383
		private ISkyboxTrigger TriggerMode;

		// Token: 0x0401BED0 RID: 114384
		private float? TriggerDistanceSquared;

		// Token: 0x0401BED1 RID: 114385
		private float TickTime;

		// Token: 0x0401BED2 RID: 114386
		private bool InTrigger;

		// Token: 0x0401BED3 RID: 114387
		private float ChangeSpeed = 0.001f;

		// Token: 0x0401BED4 RID: 114388
		private float Priority = 10f;

		// Token: 0x0401BED5 RID: 114389
		private float TargetBlendWeight;

		// Token: 0x0401BED6 RID: 114390
		private float CurBlendWeight;
	}
}
