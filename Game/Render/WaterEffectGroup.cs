using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Effect.WaterInteraction;

namespace CSharpScript.Game.Render
{
	// Token: 0x02004786 RID: 18310
	[NullableContext(1)]
	[Nullable(0)]
	public class WaterEffectGroup
	{
		// Token: 0x0602F81E RID: 194590 RVA: 0x00B4E710 File Offset: 0x00B4C910
		[NullableContext(2)]
		public WaterEffectItem FindEffectAtSpeed(double speed)
		{
			int num = 0;
			while (num < this.EffectItems.Count && speed >= this.EffectItems[num].SpeedThreshold)
			{
				num++;
			}
			if (num == 0)
			{
				return null;
			}
			return this.EffectItems[num - 1];
		}

		// Token: 0x0602F81F RID: 194591 RVA: 0x00B4E75C File Offset: 0x00B4C95C
		public void Init(SWaterEffectGroup configData)
		{
			this.WaterDepthThreshold = (double)configData.WaterDepth;
			int num = configData.EffectConfig.Num();
			this.EffectItems.Clear();
			for (int i = 0; i < num; i++)
			{
				WaterEffectItem waterEffectItem = new WaterEffectItem();
				waterEffectItem.Init(configData.EffectConfig.Get(i));
				this.EffectItems.Add(waterEffectItem);
			}
		}

		// Token: 0x0401B295 RID: 111253
		public double WaterDepthThreshold;

		// Token: 0x0401B296 RID: 111254
		public List<WaterEffectItem> EffectItems = new List<WaterEffectItem>();
	}
}
