using System;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.Activity.ActivityContent.DirectTrain
{
	// Token: 0x02006941 RID: 26945
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Config(0)]
	public class ActivityDirectTrainConfig : ConfigBase<ActivityDirectTrainConfig>
	{
		// Token: 0x06042E08 RID: 273928 RVA: 0x0112A9F5 File Offset: 0x01128BF5
		public DirectTrainActivity? GetDirectTrainActivityConfById(int activityId)
		{
			return ConfigDirectTrainActivityById.GetConfig(activityId, true);
		}

		// Token: 0x06042E09 RID: 273929 RVA: 0x0112A9FE File Offset: 0x01128BFE
		public DirectTrainMain? GetDirectTrainMainConfByActivityId(int activityId)
		{
			return ConfigDirectTrainMainByActivityId.GetConfig(activityId, true);
		}

		// Token: 0x06042E0A RID: 273930 RVA: 0x0112AA07 File Offset: 0x01128C07
		public DirectTrainHighlight? GetDirectTrainHighlightConfById(int id)
		{
			return ConfigDirectTrainHighlightById.GetConfig(id, true);
		}
	}
}
