using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02001A03 RID: 6659
[NullableContext(2)]
[Nullable(0)]
public class SelectableComponentData
{
	// Token: 0x17000F94 RID: 3988
	// (get) Token: 0x0600BE91 RID: 48785 RVA: 0x003274BA File Offset: 0x003256BA
	// (set) Token: 0x0600BE92 RID: 48786 RVA: 0x003274C2 File Offset: 0x003256C2
	public bool IsSingleSelected { get; set; }

	// Token: 0x17000F95 RID: 3989
	// (get) Token: 0x0600BE93 RID: 48787 RVA: 0x003274CB File Offset: 0x003256CB
	// (set) Token: 0x0600BE94 RID: 48788 RVA: 0x003274D3 File Offset: 0x003256D3
	public bool IsNumSelectable { get; set; } = true;

	// Token: 0x17000F96 RID: 3990
	// (get) Token: 0x0600BE95 RID: 48789 RVA: 0x003274DC File Offset: 0x003256DC
	// (set) Token: 0x0600BE96 RID: 48790 RVA: 0x003274E4 File Offset: 0x003256E4
	public int MaxSelectedGridNum { get; set; } = 20;

	// Token: 0x17000F97 RID: 3991
	// (get) Token: 0x0600BE97 RID: 48791 RVA: 0x003274ED File Offset: 0x003256ED
	// (set) Token: 0x0600BE98 RID: 48792 RVA: 0x003274F5 File Offset: 0x003256F5
	public bool OnlyGold { get; set; }

	// Token: 0x17000F98 RID: 3992
	// (get) Token: 0x0600BE99 RID: 48793 RVA: 0x003274FE File Offset: 0x003256FE
	// (set) Token: 0x0600BE9A RID: 48794 RVA: 0x00327506 File Offset: 0x00325706
	public bool SuitActive { get; set; }

	// Token: 0x17000F99 RID: 3993
	// (get) Token: 0x0600BE9B RID: 48795 RVA: 0x0032750F File Offset: 0x0032570F
	// (set) Token: 0x0600BE9C RID: 48796 RVA: 0x00327517 File Offset: 0x00325717
	public bool IsNeedSort { get; set; } = true;

	// Token: 0x040059A1 RID: 22945
	public ISelectedData FirstOpenOperationData;

	// Token: 0x040059A2 RID: 22946
	public Action OtherFunction;

	// Token: 0x040059A3 RID: 22947
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Action<object> OnPropItemFunction;

	// Token: 0x040059A4 RID: 22948
	[Nullable(new byte[]
	{
		2,
		1,
		1,
		1
	})]
	public Action<List<ISelectedData>, SelectableExpData> OnChangeSelectedFunction;

	// Token: 0x040059A5 RID: 22949
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	public Func<List<ISelectedData>, int, int, int, bool> CheckIfCanAddFunction;
}
