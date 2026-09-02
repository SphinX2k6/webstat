using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using AkiClient.Game.Aki.Render.Data.Weather;
using UnrealEngine;

namespace CSharpScript.Game.Module.Weather
{
	// Token: 0x02004BFB RID: 19451
	[NullableContext(2)]
	[Nullable(0)]
	public class WeatherActor
	{
		// Token: 0x06032C18 RID: 207896 RVA: 0x00CB7054 File Offset: 0x00CB5254
		private void CheckActorExistThenInit()
		{
			BP_Weather_C weatherActorInternal = this.WeatherActorInternal;
			if (weatherActorInternal == null || !weatherActorInternal.IsValid())
			{
				this.WeatherActorInternal = (Singleton<ActorSystem>.Instance.Get(BP_Weather_C.StaticClass(), Singleton<MathUtils>.Instance.DefaultTransformDouble, null, true) as BP_Weather_C);
				this.WeatherActorInternal.OnDestroyed.Add(new Action<AActor>(this.OnActorDestroy));
				this.WeatherComponent1.Component = this.WeatherActorInternal.KuroPostProcess_1;
				this.WeatherComponent1.Component.BlendWeight = (this.WeatherComponent1.BlendWeightNonScale = 1f);
				this.WeatherComponent2.Component = this.WeatherActorInternal.KuroPostProcess_2;
				this.WeatherComponent2.Component.BlendWeight = (this.WeatherComponent2.BlendWeightNonScale = 0f);
			}
		}

		// Token: 0x06032C19 RID: 207897 RVA: 0x00CB712F File Offset: 0x00CB532F
		public void BanWeather()
		{
			this.Destroy();
			this.BanState = !this.BanState;
		}

		// Token: 0x06032C1A RID: 207898 RVA: 0x00CB7146 File Offset: 0x00CB5346
		public void SetActorState(bool state)
		{
			if (this.CurrentState != state)
			{
				BP_Weather_C weatherActorInternal = this.WeatherActorInternal;
				if (weatherActorInternal != null && weatherActorInternal.IsValid())
				{
					this.WeatherActorInternal.SetActorHiddenInGame(!state);
				}
				this.CurrentState = state;
			}
		}

		// Token: 0x06032C1B RID: 207899 RVA: 0x00CB717B File Offset: 0x00CB537B
		private void CancelCurrentLoadTask()
		{
			if (this.CurrentLoadTask != 0)
			{
				Singleton<ResourceSystem>.Instance.CancelAsyncLoad(this.CurrentLoadTask);
				this.CurrentLoadTask = 0;
			}
		}

		// Token: 0x06032C1C RID: 207900 RVA: 0x00CB719C File Offset: 0x00CB539C
		public unsafe void ChangeWeather(int targetId, float tweenTime)
		{
			this.ClearTimer();
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Weather;
			ELogAuthor author = ELogAuthor.YZY;
			string message = "改变天气";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("targetId", targetId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("tweentime", tweenTime);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			if (this.BanState)
			{
				return;
			}
			Weather? weatherConfig = ConfigBase<WeatherModuleConfig>.Instance.GetWeatherConfig(targetId);
			if (weatherConfig == null)
			{
				return;
			}
			string dapath = weatherConfig.Value.DAPath;
			this.CheckActorExistThenInit();
			if (this.WeatherComponent1.BlendWeightNonScale >= this.WeatherComponent2.BlendWeightNonScale)
			{
				this.CurrentComponent = this.WeatherComponent1;
				this.TargetComponent = this.WeatherComponent2;
			}
			else
			{
				this.CurrentComponent = this.WeatherComponent2;
				this.TargetComponent = this.WeatherComponent1;
			}
			this.CancelCurrentLoadTask();
			this.CurrentLoadTask = Singleton<ResourceSystem>.Instance.LoadAsync<UKuroWeatherDataAsset>(dapath, delegate([Nullable(2)] UKuroWeatherDataAsset dataAsset, string path)
			{
				if (dataAsset == null || !dataAsset.IsValid())
				{
					return;
				}
				if (this.TargetComponent == null || this.TargetComponent.Component == null)
				{
					return;
				}
				this.CurrentLoadTask = 0;
				this.TargetComponent.Component.WeatherDataAsset = dataAsset;
			}, ResourceSystem.EResourceLoadPriority.Default, "Ui.WeatherUi");
			if (tweenTime == 0f)
			{
				this.OnTweenCurrentUpdate(0f);
				this.OnTweenTargetUpdate(1f);
				return;
			}
			this.Timer1StartValue = this.CurrentComponent.BlendWeightNonScale;
			this.Timer1EndValue = 0f;
			this.Timer2StartValue = this.TargetComponent.BlendWeightNonScale;
			this.Timer2EndValue = 1f;
			this.TweenTime = tweenTime;
			this.CurrentRunningTime = 0f;
			if (this.Ticker == -1)
			{
				this.Ticker = Singleton<TickSystem>.Instance.Add(new Action<float>(this.OnTick), "WeatherActor", ETickingGroup.TG_PrePhysics, false, 0, false).Id;
			}
		}

		// Token: 0x06032C1D RID: 207901 RVA: 0x00CB7354 File Offset: 0x00CB5554
		public void SetWeatherForbidden(bool bForbidWeather)
		{
			this.ForbidWeather = bForbidWeather;
			if (this.Ticker == -1)
			{
				this.Ticker = Singleton<TickSystem>.Instance.Add(new Action<float>(this.OnTick), "WeatherActor", ETickingGroup.TG_PrePhysics, false, 0, false).Id;
			}
		}

		// Token: 0x06032C1E RID: 207902 RVA: 0x00CB7390 File Offset: 0x00CB5590
		private void ClearTimer()
		{
			if (this.Ticker != -1)
			{
				Singleton<TickSystem>.Instance.Remove(this.Ticker);
				this.Ticker = -1;
			}
		}

		// Token: 0x06032C1F RID: 207903 RVA: 0x00CB73B4 File Offset: 0x00CB55B4
		private void OnTick(float _)
		{
			this.CurrentRunningTime += Singleton<Time>.Instance.DeltaTime;
			float num = this.CurrentRunningTime / (this.TweenTime * 1000f);
			num = Singleton<MathUtils>.Instance.Clamp(num, 0f, 1f);
			float value = Singleton<MathUtils>.Instance.Lerp(this.Timer1StartValue, this.Timer1EndValue, num);
			float value2 = Singleton<MathUtils>.Instance.Lerp(this.Timer2StartValue, this.Timer2EndValue, num);
			float deltaTimeSeconds = Singleton<Time>.Instance.DeltaTimeSeconds;
			this.WeatherScalar = (this.ForbidWeather ? (this.WeatherScalar - deltaTimeSeconds) : (this.WeatherScalar + deltaTimeSeconds));
			this.WeatherScalar = Singleton<MathUtils>.Instance.Clamp(this.WeatherScalar, 0f, 1f);
			this.OnTweenCurrentUpdate(value);
			this.OnTweenTargetUpdate(value2);
			if (num >= 1f && ((this.ForbidWeather && this.WeatherScalar <= 0f) || (!this.ForbidWeather && this.WeatherScalar >= 1f)))
			{
				this.ClearTimer();
			}
		}

		// Token: 0x06032C20 RID: 207904 RVA: 0x00CB74C3 File Offset: 0x00CB56C3
		private void OnTweenCurrentUpdate(float value)
		{
			if (this.CurrentComponent != null)
			{
				this.CurrentComponent.BlendWeightNonScale = value;
				this.CurrentComponent.Component.BlendWeight = value * this.WeatherScalar;
			}
		}

		// Token: 0x06032C21 RID: 207905 RVA: 0x00CB74F1 File Offset: 0x00CB56F1
		private void OnTweenTargetUpdate(float value)
		{
			if (this.TargetComponent != null)
			{
				this.TargetComponent.BlendWeightNonScale = value;
				this.TargetComponent.Component.BlendWeight = value * this.WeatherScalar;
			}
		}

		// Token: 0x06032C22 RID: 207906 RVA: 0x00CB751F File Offset: 0x00CB571F
		private void OnActorDestroy(AActor _)
		{
			this.ClearTimer();
			this.CurrentComponent = null;
			this.TargetComponent = null;
			this.WeatherActorInternal = null;
		}

		// Token: 0x06032C23 RID: 207907 RVA: 0x00CB753C File Offset: 0x00CB573C
		public void Destroy()
		{
			BP_Weather_C weatherActorInternal = this.WeatherActorInternal;
			if (weatherActorInternal != null && weatherActorInternal.IsValid())
			{
				this.WeatherActorInternal.K2_DestroyActor();
			}
			this.CurrentState = false;
			this.WeatherActorInternal = null;
		}

		// Token: 0x0401D894 RID: 120980
		private BP_Weather_C WeatherActorInternal;

		// Token: 0x0401D895 RID: 120981
		[Nullable(1)]
		private readonly WeatherComponent WeatherComponent1 = new WeatherComponent();

		// Token: 0x0401D896 RID: 120982
		[Nullable(1)]
		private readonly WeatherComponent WeatherComponent2 = new WeatherComponent();

		// Token: 0x0401D897 RID: 120983
		private WeatherComponent CurrentComponent;

		// Token: 0x0401D898 RID: 120984
		private WeatherComponent TargetComponent;

		// Token: 0x0401D899 RID: 120985
		private float Timer1StartValue;

		// Token: 0x0401D89A RID: 120986
		private float Timer2StartValue;

		// Token: 0x0401D89B RID: 120987
		private float Timer1EndValue;

		// Token: 0x0401D89C RID: 120988
		private float Timer2EndValue;

		// Token: 0x0401D89D RID: 120989
		private float CurrentRunningTime;

		// Token: 0x0401D89E RID: 120990
		private float TweenTime;

		// Token: 0x0401D89F RID: 120991
		private bool BanState;

		// Token: 0x0401D8A0 RID: 120992
		private int Ticker = -1;

		// Token: 0x0401D8A1 RID: 120993
		private bool CurrentState;

		// Token: 0x0401D8A2 RID: 120994
		private int CurrentLoadTask;

		// Token: 0x0401D8A3 RID: 120995
		private bool ForbidWeather;

		// Token: 0x0401D8A4 RID: 120996
		private float WeatherScalar = 1f;
	}
}
