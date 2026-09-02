using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Plot.Flow;

// Token: 0x02002746 RID: 10054
public class RandomPlotItem
{
	// Token: 0x06013DAF RID: 81327 RVA: 0x00588D9C File Offset: 0x00586F9C
	[NullableContext(1)]
	public static RandomPlotItem Create(RandomPlot config)
	{
		RandomPlotItem randomPlotItem = new RandomPlotItem();
		randomPlotItem.Probability = (float)config.Probability / 100f;
		randomPlotItem.Cooldown = (float)(config.Cooldown * 1000);
		int clientPlotReferenceListLength = config.ClientPlotReferenceListLength;
		for (int i = 0; i < clientPlotReferenceListLength; i++)
		{
			PlotReference? config2 = ConfigPlotReferenceById.GetConfig(config.ClientPlotReferenceList(i), true);
			if (config2 != null)
			{
				string plot = config2.Value.Plot;
				if (plot != null)
				{
					string[] array = plot.Split(',', StringSplitOptions.None);
					randomPlotItem.FlowConfigs.Add(new RandomPlotItem.FlowConfig
					{
						FlowListName = array[0],
						FlowId = int.Parse(array[1]),
						StateId = int.Parse(array[2])
					});
				}
			}
		}
		return randomPlotItem;
	}

	// Token: 0x06013DB0 RID: 81328 RVA: 0x00588E60 File Offset: 0x00587060
	public void PlayRandomPlot()
	{
		double playerTime = Singleton<Time>.Instance.PlayerTime;
		if (playerTime < this.CooldownFinishStamp)
		{
			return;
		}
		float probability = this.Probability;
		if (probability == 0f)
		{
			return;
		}
		float num = Random.Shared.NextSingle();
		if (probability < 1f && num > probability)
		{
			return;
		}
		int count = this.FlowConfigs.Count;
		float num2 = Random.Shared.NextSingle();
		int index = Singleton<MathUtils>.Instance.Clamp((int)Math.Floor((double)(num2 * (float)count)), 0, count - 1);
		RandomPlotItem.FlowConfig flowConfig = this.FlowConfigs[index];
		ControllerBase<FlowController>.Instance.StartFlow(flowConfig.FlowListName, flowConfig.FlowId, flowConfig.StateId, null, 0L, false, false, false, null);
		this.CooldownFinishStamp = playerTime + (double)this.Cooldown;
	}

	// Token: 0x04009A6A RID: 39530
	private float Probability;

	// Token: 0x04009A6B RID: 39531
	private float Cooldown;

	// Token: 0x04009A6C RID: 39532
	[Nullable(1)]
	private readonly List<RandomPlotItem.FlowConfig> FlowConfigs = new List<RandomPlotItem.FlowConfig>();

	// Token: 0x04009A6D RID: 39533
	private double CooldownFinishStamp;

	// Token: 0x02008B0D RID: 35597
	private class FlowConfig
	{
		// Token: 0x0402EE59 RID: 192089
		[Nullable(1)]
		public string FlowListName = "";

		// Token: 0x0402EE5A RID: 192090
		public int FlowId;

		// Token: 0x0402EE5B RID: 192091
		public int StateId;
	}
}
