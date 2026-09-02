using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Inventory;

// Token: 0x020018BE RID: 6334
[NullableContext(1)]
[Nullable(0)]
public class TCommonSingleConsumeData
{
	// Token: 0x17000EF6 RID: 3830
	// (get) Token: 0x0600B606 RID: 46598 RVA: 0x00306697 File Offset: 0x00304897
	// (set) Token: 0x0600B607 RID: 46599 RVA: 0x0030669F File Offset: 0x0030489F
	public InventoryDefine.IGetItemData ItemData { get; set; }

	// Token: 0x17000EF7 RID: 3831
	// (get) Token: 0x0600B608 RID: 46600 RVA: 0x003066A8 File Offset: 0x003048A8
	// (set) Token: 0x0600B609 RID: 46601 RVA: 0x003066B0 File Offset: 0x003048B0
	public int Count { get; set; }
}
