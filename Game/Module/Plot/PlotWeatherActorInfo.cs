using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.Module.Plot
{
	// Token: 0x0200537B RID: 21371
	[NullableContext(2)]
	[Nullable(0)]
	public class PlotWeatherActorInfo
	{
		// Token: 0x0603681A RID: 223258 RVA: 0x00DC63C4 File Offset: 0x00DC45C4
		public void Disable()
		{
			if (this.WeatherConfig == null)
			{
				return;
			}
			this.WeatherConfig = null;
			UKuroPostProcessComponent kuroPostProcessComponent = this.KuroPostProcessComponent;
			if (kuroPostProcessComponent != null && kuroPostProcessComponent.IsValid())
			{
				this.KuroPostProcessComponent.bEnabled = false;
			}
			this.IsLoadCompleted = false;
			this.CurBlendWeight = 0f;
			this.IsLoadCompleted = false;
		}

		// Token: 0x0603681B RID: 223259 RVA: 0x00DC6424 File Offset: 0x00DC4624
		public void Destroy()
		{
			this.WeatherConfig = null;
			AActor actor = this.Actor;
			if (actor != null && actor.IsValid())
			{
				Singleton<ActorSystem>.Instance.Put("PlotWeatherActorInfo.Destroy", this.Actor, null);
				this.Actor = null;
			}
			this.KuroPostProcessComponent = null;
		}

		// Token: 0x0401F62A RID: 128554
		public Weather? WeatherConfig;

		// Token: 0x0401F62B RID: 128555
		public AActor Actor;

		// Token: 0x0401F62C RID: 128556
		public UKuroPostProcessComponent KuroPostProcessComponent;

		// Token: 0x0401F62D RID: 128557
		public float TargetBlendWeight;

		// Token: 0x0401F62E RID: 128558
		public float CurBlendWeight;

		// Token: 0x0401F62F RID: 128559
		public float ChangeSpeed;

		// Token: 0x0401F630 RID: 128560
		public int Priority;

		// Token: 0x0401F631 RID: 128561
		public bool IsLoadCompleted;
	}
}
