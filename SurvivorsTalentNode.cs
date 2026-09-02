using System;
using System.Runtime.CompilerServices;

// Token: 0x02002AC4 RID: 10948
[NullableContext(1)]
[Nullable(0)]
public class SurvivorsTalentNode
{
	// Token: 0x06015E87 RID: 89735 RVA: 0x006162B1 File Offset: 0x006144B1
	public SurvivorsTalentNode(int nodeId, int areaId, int[] preNodeIds, int effectId, int indexId, int indexSortId)
	{
		this.NodeId = nodeId;
		this.AreaId = areaId;
		this.PreNodeIds = preNodeIds;
		this.EffectId = effectId;
		this.IndexId = indexId;
		this.IndexSortId = indexSortId;
	}

	// Token: 0x0400A844 RID: 43076
	public int NodeId;

	// Token: 0x0400A845 RID: 43077
	public int AreaId;

	// Token: 0x0400A846 RID: 43078
	public int[] PreNodeIds;

	// Token: 0x0400A847 RID: 43079
	public int EffectId;

	// Token: 0x0400A848 RID: 43080
	public int IndexId;

	// Token: 0x0400A849 RID: 43081
	public int IndexSortId;

	// Token: 0x0400A84A RID: 43082
	public ESurvivorsTalentNodeStatus Status = ESurvivorsTalentNodeStatus.Lock;
}
