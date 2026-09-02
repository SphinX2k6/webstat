using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x0200249C RID: 9372
[NullableContext(1)]
[Nullable(0)]
public class VisionEquipGroupData
{
	// Token: 0x060122F5 RID: 74485 RVA: 0x00500C3B File Offset: 0x004FEE3B
	public VisionEquipGroupData()
	{
		this.Name = "";
		this.IncIdList = new List<int>();
	}

	// Token: 0x060122F6 RID: 74486 RVA: 0x00500C59 File Offset: 0x004FEE59
	public int GetIndex()
	{
		return this.Index;
	}

	// Token: 0x060122F7 RID: 74487 RVA: 0x00500C61 File Offset: 0x004FEE61
	public string GetName()
	{
		return this.Name;
	}

	// Token: 0x060122F8 RID: 74488 RVA: 0x00500C69 File Offset: 0x004FEE69
	public int[] GetVisionUniqueIdList()
	{
		return this.IncIdList.ToArray();
	}

	// Token: 0x060122F9 RID: 74489 RVA: 0x00500C76 File Offset: 0x004FEE76
	public void Phrase(int index, PhantomEquipGroupInfo data)
	{
		this.Index = index;
		this.Name = data.Name;
		this.IncIdList = ((data.IncId != null) ? new List<int>(data.IncId) : new List<int>());
	}

	// Token: 0x04008DEB RID: 36331
	private int Index;

	// Token: 0x04008DEC RID: 36332
	private string Name;

	// Token: 0x04008DED RID: 36333
	private List<int> IncIdList;
}
