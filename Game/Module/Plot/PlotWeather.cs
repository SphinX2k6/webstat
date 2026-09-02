using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Weather;
using UnrealEngine;

namespace CSharpScript.Game.Module.Plot
{
	// Token: 0x0200537C RID: 21372
	[NullableContext(2)]
	[Nullable(0)]
	public class PlotWeather
	{
		// Token: 0x0603681D RID: 223261 RVA: 0x00DC647E File Offset: 0x00DC467E
		public void Init()
		{
			this.WeatherId = 0;
			this.IsInherit = false;
		}

		// Token: 0x0603681E RID: 223262 RVA: 0x00DC648E File Offset: 0x00DC468E
		public void Clear()
		{
			this.WeatherId = 0;
			this.IsInherit = false;
			this.ClearAllWeather();
		}

		// Token: 0x0603681F RID: 223263 RVA: 0x00DC64A4 File Offset: 0x00DC46A4
		public void OnPlotEnd()
		{
			if (this.IsInherit)
			{
				this.IsInherit = false;
				ControllerBase<WeatherController>.Instance.RequestChangeWeather(this.WeatherId, null);
			}
			this.ClearAllWeather();
		}

		// Token: 0x06036820 RID: 223264 RVA: 0x00DC64DF File Offset: 0x00DC46DF
		public void StopAllWeather()
		{
			if (!this.IsInherit)
			{
				return;
			}
			PlotWeatherActorInfo curActorInfo = this.CurActorInfo;
			if (curActorInfo != null)
			{
				curActorInfo.Disable();
			}
			PlotWeatherActorInfo lastActorInfo = this.LastActorInfo;
			if (lastActorInfo == null)
			{
				return;
			}
			lastActorInfo.Disable();
		}

		// Token: 0x06036821 RID: 223265 RVA: 0x00DC650B File Offset: 0x00DC470B
		private void ClearAllWeather()
		{
			PlotWeatherActorInfo curActorInfo = this.CurActorInfo;
			if (curActorInfo != null)
			{
				curActorInfo.Destroy();
			}
			this.CurActorInfo = null;
			PlotWeatherActorInfo lastActorInfo = this.LastActorInfo;
			if (lastActorInfo != null)
			{
				lastActorInfo.Destroy();
			}
			this.LastActorInfo = null;
		}

		// Token: 0x06036822 RID: 223266 RVA: 0x00DC653D File Offset: 0x00DC473D
		public void OnTick(float delta)
		{
			this.UpdateBlendWeight(this.LastActorInfo, delta);
			this.UpdateBlendWeight(this.CurActorInfo, delta);
		}

		// Token: 0x06036823 RID: 223267 RVA: 0x00DC655C File Offset: 0x00DC475C
		private void UpdateBlendWeight(PlotWeatherActorInfo actorInfo, float delta)
		{
			if (actorInfo == null || !actorInfo.IsLoadCompleted)
			{
				return;
			}
			if (Singleton<MathUtils>.Instance.IsNearlyEqual((double)actorInfo.CurBlendWeight, (double)actorInfo.TargetBlendWeight, null))
			{
				return;
			}
			float curBlendWeight = actorInfo.CurBlendWeight;
			if (Singleton<MathUtils>.Instance.IsNearlyEqual((double)actorInfo.ChangeSpeed, 0.0, null))
			{
				actorInfo.CurBlendWeight = actorInfo.TargetBlendWeight;
			}
			else
			{
				if (delta <= 0f)
				{
					return;
				}
				if (actorInfo.TargetBlendWeight > actorInfo.CurBlendWeight)
				{
					actorInfo.CurBlendWeight += delta * actorInfo.ChangeSpeed;
					actorInfo.CurBlendWeight = Math.Min(actorInfo.CurBlendWeight, actorInfo.TargetBlendWeight);
				}
				else
				{
					actorInfo.CurBlendWeight -= delta * actorInfo.ChangeSpeed;
					actorInfo.CurBlendWeight = Math.Max(actorInfo.CurBlendWeight, actorInfo.TargetBlendWeight);
				}
			}
			actorInfo.KuroPostProcessComponent.BlendWeight = actorInfo.CurBlendWeight;
			if (curBlendWeight == 0f && actorInfo.CurBlendWeight > 0f)
			{
				actorInfo.KuroPostProcessComponent.bEnabled = true;
			}
			if (curBlendWeight > 0f && Singleton<MathUtils>.Instance.IsNearlyEqual((double)actorInfo.CurBlendWeight, 0.0, null))
			{
				actorInfo.KuroPostProcessComponent.bEnabled = false;
			}
		}

		// Token: 0x06036824 RID: 223268 RVA: 0x00DC66B4 File Offset: 0x00DC48B4
		public void ChangeWeather(int weatherId, bool isInherit, float tweenTime, int priority = 100)
		{
			this.WeatherId = weatherId;
			this.IsInherit = isInherit;
			if (this.CurActorInfo != null)
			{
				this.CurActorInfo.TargetBlendWeight = 0f;
			}
			Weather? weatherConfig = ConfigBase<WeatherModuleConfig>.Instance.GetWeatherConfig(weatherId);
			if (weatherConfig == null)
			{
				return;
			}
			if (this.CurActorInfo == null)
			{
				this.CurActorInfo = new PlotWeatherActorInfo();
				this.UpdateCurWeatherActorInfo(weatherConfig.Value, tweenTime);
				this.UpdateCurPriority(priority);
				this.CreateWeatherActor();
				return;
			}
			PlotWeatherActorInfo curActorInfo = this.CurActorInfo;
			int? num = (curActorInfo.WeatherConfig != null) ? new int?(curActorInfo.WeatherConfig.GetValueOrDefault().Id) : null;
			int id = weatherConfig.Value.Id;
			if (num.GetValueOrDefault() == id & num != null)
			{
				this.CurActorInfo.TargetBlendWeight = 1f;
				this.UpdateBlendWeight(this.CurActorInfo, 0f);
				this.UpdateCurActorTransform();
				this.UpdateCurWeatherActorInfo(weatherConfig.Value, tweenTime);
				this.UpdateCurPriority(priority);
				return;
			}
			if (this.LastActorInfo == null)
			{
				this.LastActorInfo = this.CurActorInfo;
				this.CurActorInfo = new PlotWeatherActorInfo();
				this.UpdateCurWeatherActorInfo(weatherConfig.Value, tweenTime);
				this.UpdateCurPriority(priority);
				this.CreateWeatherActor();
				return;
			}
			PlotWeatherActorInfo curActorInfo2 = this.CurActorInfo;
			PlotWeatherActorInfo lastActorInfo = this.LastActorInfo;
			this.LastActorInfo = curActorInfo2;
			this.CurActorInfo = lastActorInfo;
			PlotWeatherActorInfo curActorInfo3 = this.CurActorInfo;
			num = ((curActorInfo3.WeatherConfig != null) ? new int?(curActorInfo3.WeatherConfig.GetValueOrDefault().Id) : null);
			id = weatherConfig.Value.Id;
			if (num.GetValueOrDefault() == id & num != null)
			{
				this.CurActorInfo.TargetBlendWeight = 1f;
				this.UpdateBlendWeight(this.CurActorInfo, 0f);
				this.UpdateCurActorTransform();
				this.UpdateCurWeatherActorInfo(weatherConfig.Value, tweenTime);
				this.UpdateCurPriority(priority);
				return;
			}
			this.UpdateCurWeatherActorInfo(weatherConfig.Value, tweenTime);
			this.UpdateAtmosphereActor();
			this.UpdateCurPriority(priority);
		}

		// Token: 0x06036825 RID: 223269 RVA: 0x00DC68D4 File Offset: 0x00DC4AD4
		private void UpdateCurWeatherActorInfo(Weather weatherConfig, float tweenTime)
		{
			this.CurActorInfo.WeatherConfig = new Weather?(weatherConfig);
			if (tweenTime > 0f)
			{
				this.CurActorInfo.ChangeSpeed = 1f / (tweenTime * (float)Singleton<TimeUtil>.Instance.InverseMillisecond);
			}
			else
			{
				this.CurActorInfo.ChangeSpeed = 0f;
			}
			if (this.LastActorInfo != null)
			{
				this.LastActorInfo.ChangeSpeed = this.CurActorInfo.ChangeSpeed;
			}
		}

		// Token: 0x06036826 RID: 223270 RVA: 0x00DC6948 File Offset: 0x00DC4B48
		private void UpdateCurActorTransform()
		{
			if (this.CurActorInfo != null)
			{
				AActor actor = this.CurActorInfo.Actor;
				if (actor != null && actor.IsValid())
				{
					if (Global.BaseCharacter != null)
					{
						this.CurActorInfo.Actor.D_K2_SetActorLocation(Global.BaseCharacter.D_K2_GetActorLocation(), false, ref WorldGlobal.SweepHitResult, true);
					}
					return;
				}
			}
		}

		// Token: 0x06036827 RID: 223271 RVA: 0x00DC69A4 File Offset: 0x00DC4BA4
		private void CreateWeatherActor()
		{
			FTransformDouble? ftransformDouble = null;
			if (Global.BaseCharacter != null)
			{
				ftransformDouble = new FTransformDouble?(Global.BaseCharacter.D_GetTransform());
			}
			else
			{
				ftransformDouble = new FTransformDouble?(new FTransformDouble());
			}
			AActor aactor = Singleton<ActorSystem>.Instance.Get(AActor.StaticClass(), ftransformDouble.Value, null, true);
			UKuroPostProcessComponent ukuroPostProcessComponent = (UKuroPostProcessComponent)aactor.AddComponentByClass(UKuroPostProcessComponent.StaticClass(), false, Singleton<MathUtils>.Instance.DefaultTransform, false, default(FName));
			ukuroPostProcessComponent.bUnbound = true;
			ukuroPostProcessComponent.BlendWeight = 0f;
			ukuroPostProcessComponent.bEnabled = false;
			this.CurActorInfo.Actor = aactor;
			this.CurActorInfo.KuroPostProcessComponent = ukuroPostProcessComponent;
			this.CurActorInfo.TargetBlendWeight = 1f;
			this.CurActorInfo.CurBlendWeight = 0f;
			this.CurActorInfo.IsLoadCompleted = false;
			this.LoadDaAsset();
		}

		// Token: 0x06036828 RID: 223272 RVA: 0x00DC6A88 File Offset: 0x00DC4C88
		private void UpdateAtmosphereActor()
		{
			UKuroPostProcessComponent kuroPostProcessComponent = this.CurActorInfo.KuroPostProcessComponent;
			this.CurActorInfo.TargetBlendWeight = 1f;
			this.CurActorInfo.CurBlendWeight = 0f;
			this.CurActorInfo.IsLoadCompleted = false;
			kuroPostProcessComponent.PPTODDataAsset = null;
			kuroPostProcessComponent.WeatherDataAsset = null;
			kuroPostProcessComponent.BlendWeight = 0f;
			kuroPostProcessComponent.bEnabled = false;
			this.UpdateCurActorTransform();
			this.LoadDaAsset();
		}

		// Token: 0x06036829 RID: 223273 RVA: 0x00DC6AF8 File Offset: 0x00DC4CF8
		private void LoadDaAsset()
		{
			Weather? weatherConfig = this.CurActorInfo.WeatherConfig;
			UKuroPostProcessComponent kuroPostProcessComponent = this.CurActorInfo.KuroPostProcessComponent;
			Singleton<ResourceSystem>.Instance.LoadAsync<UKuroWeatherDataAsset>(weatherConfig.Value.DAPath, delegate([Nullable(2)] UKuroWeatherDataAsset dataAsset, string _)
			{
				if (dataAsset == null || !dataAsset.IsValid())
				{
					return;
				}
				PlotWeatherActorInfo curActorInfo = this.CurActorInfo;
				int? num = (curActorInfo.WeatherConfig != null) ? new int?(curActorInfo.WeatherConfig.GetValueOrDefault().Id) : null;
				int id = weatherConfig.Value.Id;
				if (!(num.GetValueOrDefault() == id & num != null))
				{
					return;
				}
				kuroPostProcessComponent.WeatherDataAsset = dataAsset;
				kuroPostProcessComponent.SetPriority((float)this.CurActorInfo.Priority);
				this.CurActorInfo.IsLoadCompleted = true;
				this.UpdateBlendWeight(this.CurActorInfo, 0f);
			}, 100, "js_undefined");
		}

		// Token: 0x0603682A RID: 223274 RVA: 0x00DC6B68 File Offset: 0x00DC4D68
		private void UpdateCurPriority(int priority)
		{
			if (this.CurActorInfo == null || this.CurActorInfo.Priority == priority)
			{
				return;
			}
			this.CurActorInfo.Priority = priority;
			if (this.CurActorInfo.IsLoadCompleted)
			{
				UKuroPostProcessComponent kuroPostProcessComponent = this.CurActorInfo.KuroPostProcessComponent;
				if (kuroPostProcessComponent != null && kuroPostProcessComponent.IsValid())
				{
					this.CurActorInfo.KuroPostProcessComponent.SetPriority((float)priority);
				}
			}
		}

		// Token: 0x0401F632 RID: 128562
		private const int PLOT_WEATHER_PRIORITY = 100;

		// Token: 0x0401F633 RID: 128563
		private int WeatherId;

		// Token: 0x0401F634 RID: 128564
		private bool IsInherit;

		// Token: 0x0401F635 RID: 128565
		private PlotWeatherActorInfo CurActorInfo;

		// Token: 0x0401F636 RID: 128566
		private PlotWeatherActorInfo LastActorInfo;
	}
}
