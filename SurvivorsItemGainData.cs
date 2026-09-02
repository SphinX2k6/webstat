using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02002AFA RID: 11002
[NullableContext(1)]
[Nullable(0)]
public class SurvivorsItemGainData : global::SurvivorsGainData
{
	// Token: 0x06015FF4 RID: 90100 RVA: 0x0061A86E File Offset: 0x00618A6E
	public SurvivorsItemGainData(int incId, int configId, SurvivorsToken data, ESurvivorsRogueItemType type = ESurvivorsRogueItemType.Normal) : base(incId, configId)
	{
		this.Data = data;
		this.Type = type;
	}

	// Token: 0x0400A8E6 RID: 43238
	public SurvivorsToken Data;
}
