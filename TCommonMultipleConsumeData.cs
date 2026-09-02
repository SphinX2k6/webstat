using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Inventory;

// Token: 0x020018B6 RID: 6326
[NullableContext(1)]
[Nullable(0)]
public struct TCommonMultipleConsumeData
{
	// Token: 0x17000EF4 RID: 3828
	// (get) Token: 0x0600B5D1 RID: 46545 RVA: 0x00305FAB File Offset: 0x003041AB
	// (set) Token: 0x0600B5D2 RID: 46546 RVA: 0x00305FB3 File Offset: 0x003041B3
	public InventoryDefine.IGetItemData ItemData { readonly get; set; }

	// Token: 0x17000EF5 RID: 3829
	// (get) Token: 0x0600B5D3 RID: 46547 RVA: 0x00305FBC File Offset: 0x003041BC
	// (set) Token: 0x0600B5D4 RID: 46548 RVA: 0x00305FC4 File Offset: 0x003041C4
	public int Count { readonly get; set; }

	// Token: 0x0600B5D5 RID: 46549 RVA: 0x00305FCD File Offset: 0x003041CD
	public TCommonMultipleConsumeData(InventoryDefine.IGetItemData itemData, int count)
	{
		this.ItemData = itemData;
		this.Count = count;
	}
}
