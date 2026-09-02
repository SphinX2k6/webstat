using System;
using System.Runtime.CompilerServices;

// Token: 0x0200291B RID: 10523
public class AssemblyGridData
{
	// Token: 0x06014E0B RID: 85515 RVA: 0x005C7962 File Offset: 0x005C5B62
	public AssemblyGridData()
	{
		this.Id = 0;
		this.Index = -1;
		this.GridType = ERouletteGridType.Explore;
		this.Name = "";
		this.State = EAssemblyGridState.UnEquip;
		this.SortId = 0;
		this.RelativeIndex = 0;
	}

	// Token: 0x0400A0E4 RID: 41188
	public int Id;

	// Token: 0x0400A0E5 RID: 41189
	public int Index;

	// Token: 0x0400A0E6 RID: 41190
	public ERouletteGridType GridType;

	// Token: 0x0400A0E7 RID: 41191
	[Nullable(1)]
	public string Name;

	// Token: 0x0400A0E8 RID: 41192
	public EAssemblyGridState State;

	// Token: 0x0400A0E9 RID: 41193
	public int SortId;

	// Token: 0x0400A0EA RID: 41194
	public int RelativeIndex;
}
