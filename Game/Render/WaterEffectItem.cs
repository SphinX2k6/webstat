using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Effect.WaterInteraction;
using UnrealEngine;

namespace CSharpScript.Game.Render
{
	// Token: 0x02004785 RID: 18309
	public class WaterEffectItem
	{
		// Token: 0x0602F81C RID: 194588 RVA: 0x00B4E6DF File Offset: 0x00B4C8DF
		[NullableContext(1)]
		public void Init(SWaterEffectItem configData)
		{
			this.SpeedThreshold = (double)configData.Speed;
			this.EffectDataPath = configData.EffectDataRef;
			this.AudioEffectDataPath = configData.AudioEffectDataRef;
		}

		// Token: 0x0401B292 RID: 111250
		public double SpeedThreshold;

		// Token: 0x0401B293 RID: 111251
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public TSoftObjectPtr<UEffectModelBase> EffectDataPath;

		// Token: 0x0401B294 RID: 111252
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public TSoftObjectPtr<UEffectModelBase> AudioEffectDataPath;
	}
}
