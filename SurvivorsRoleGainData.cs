using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02002AF8 RID: 11000
[NullableContext(1)]
[Nullable(0)]
public class SurvivorsRoleGainData : global::SurvivorsGainData
{
	// Token: 0x06015FEE RID: 90094 RVA: 0x0061A6C7 File Offset: 0x006188C7
	public SurvivorsRoleGainData(int incId, int configId, SurvivorsRole data, ESurvivorsRogueItemType type = ESurvivorsRogueItemType.Character) : base(incId, configId)
	{
		this.Data = data;
		this.Type = type;
	}

	// Token: 0x06015FEF RID: 90095 RVA: 0x0061A6E0 File Offset: 0x006188E0
	public int GetCurrentEvolveId()
	{
		if (this.Data.Evolves.Count == 0)
		{
			return 0;
		}
		return this.Data.Evolves[this.Data.Evolves.Count - 1];
	}

	// Token: 0x0400A8E4 RID: 43236
	public SurvivorsRole Data;
}
