using System;
using CSharpScript.Game.Module.Inventory;

// Token: 0x0200291E RID: 10526
public class AssemblyEquipItemGridData : AssemblyGridData
{
	// Token: 0x06014E0F RID: 85519 RVA: 0x005C79D8 File Offset: 0x005C5BD8
	public AssemblyEquipItemGridData()
	{
		this.ItemType = InventoryDefine.EItemType.Common;
		this.QualityId = 0;
		this.ItemNum = 0;
	}

	// Token: 0x0400A0ED RID: 41197
	public InventoryDefine.EItemType ItemType;

	// Token: 0x0400A0EE RID: 41198
	public int QualityId;

	// Token: 0x0400A0EF RID: 41199
	public int ItemNum;
}
