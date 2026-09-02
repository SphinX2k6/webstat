using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02001DBA RID: 7610
public class DynamicFlowInfo
{
	// Token: 0x0600E0E7 RID: 57575 RVA: 0x003C7834 File Offset: 0x003C5A34
	public DynamicFlowInfo()
	{
		this.DynamicFlowNpcList = new List<int>();
	}

	// Token: 0x0600E0E8 RID: 57576 RVA: 0x003C7847 File Offset: 0x003C5A47
	public void Dispose()
	{
		this.ClearDynamicFlowNpcList();
	}

	// Token: 0x0600E0E9 RID: 57577 RVA: 0x003C784F File Offset: 0x003C5A4F
	public void AddDynamicFlowNpc(int npcPbDataId)
	{
		this.DynamicFlowNpcList.Add(npcPbDataId);
	}

	// Token: 0x0600E0EA RID: 57578 RVA: 0x003C7860 File Offset: 0x003C5A60
	public void ClearDynamicFlowNpcList()
	{
		foreach (int pbDataId in this.DynamicFlowNpcList)
		{
			EntityHandle entityByPbDataId = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(pbDataId);
			if (entityByPbDataId != null)
			{
				NpcFlowComponent component = entityByPbDataId.Entity.GetComponent<NpcFlowComponent>();
				if (component != null)
				{
					component.PlayDynamicFlowEnd();
				}
			}
		}
		this.DynamicFlowNpcList.Clear();
	}

	// Token: 0x04006BCD RID: 27597
	[Nullable(2)]
	private readonly List<int> DynamicFlowNpcList;
}
