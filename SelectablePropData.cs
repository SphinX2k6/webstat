using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Inventory;

// Token: 0x02001A08 RID: 6664
[NullableContext(1)]
[Nullable(0)]
public class SelectablePropData : ISelectedData
{
	// Token: 0x17000F9D RID: 3997
	// (get) Token: 0x0600BEEE RID: 48878 RVA: 0x00328698 File Offset: 0x00326898
	// (set) Token: 0x0600BEEF RID: 48879 RVA: 0x003286A0 File Offset: 0x003268A0
	public int IncId { get; set; }

	// Token: 0x17000F9E RID: 3998
	// (get) Token: 0x0600BEF0 RID: 48880 RVA: 0x003286A9 File Offset: 0x003268A9
	// (set) Token: 0x0600BEF1 RID: 48881 RVA: 0x003286B1 File Offset: 0x003268B1
	public int ItemId { get; set; }

	// Token: 0x17000F9F RID: 3999
	// (get) Token: 0x0600BEF2 RID: 48882 RVA: 0x003286BA File Offset: 0x003268BA
	// (set) Token: 0x0600BEF3 RID: 48883 RVA: 0x003286C2 File Offset: 0x003268C2
	public int Count { get; set; } = 1;

	// Token: 0x17000FA0 RID: 4000
	// (get) Token: 0x0600BEF4 RID: 48884 RVA: 0x003286CB File Offset: 0x003268CB
	// (set) Token: 0x0600BEF5 RID: 48885 RVA: 0x003286D3 File Offset: 0x003268D3
	public int SelectedCount { get; set; }

	// Token: 0x17000FA1 RID: 4001
	// (get) Token: 0x0600BEF6 RID: 48886 RVA: 0x003286DC File Offset: 0x003268DC
	// (set) Token: 0x0600BEF7 RID: 48887 RVA: 0x003286E4 File Offset: 0x003268E4
	public InventoryDefine.EItemDataType ItemDataType { get; set; }

	// Token: 0x17000FA2 RID: 4002
	// (get) Token: 0x0600BEF8 RID: 48888 RVA: 0x003286ED File Offset: 0x003268ED
	// (set) Token: 0x0600BEF9 RID: 48889 RVA: 0x003286F5 File Offset: 0x003268F5
	public int RoleId { get; set; }

	// Token: 0x17000FA3 RID: 4003
	// (get) Token: 0x0600BEFA RID: 48890 RVA: 0x003286FE File Offset: 0x003268FE
	// (set) Token: 0x0600BEFB RID: 48891 RVA: 0x00328706 File Offset: 0x00326906
	public int ResonanceLevel { get; set; }

	// Token: 0x17000FA4 RID: 4004
	// (get) Token: 0x0600BEFC RID: 48892 RVA: 0x0032870F File Offset: 0x0032690F
	// (set) Token: 0x0600BEFD RID: 48893 RVA: 0x00328717 File Offset: 0x00326917
	public string LevelText { get; set; } = "";

	// Token: 0x17000FA5 RID: 4005
	// (get) Token: 0x0600BEFE RID: 48894 RVA: 0x00328720 File Offset: 0x00326920
	// (set) Token: 0x0600BEFF RID: 48895 RVA: 0x00328728 File Offset: 0x00326928
	public string ChipPath { get; set; } = "";

	// Token: 0x17000FA6 RID: 4006
	// (get) Token: 0x0600BF00 RID: 48896 RVA: 0x00328731 File Offset: 0x00326931
	// (set) Token: 0x0600BF01 RID: 48897 RVA: 0x00328739 File Offset: 0x00326939
	public bool OnlyGold { get; set; }

	// Token: 0x17000FA7 RID: 4007
	// (get) Token: 0x0600BF02 RID: 48898 RVA: 0x00328742 File Offset: 0x00326942
	// (set) Token: 0x0600BF03 RID: 48899 RVA: 0x0032874A File Offset: 0x0032694A
	public bool? OnlyTextFlag { get; set; }

	// Token: 0x0600BF04 RID: 48900 RVA: 0x00328754 File Offset: 0x00326954
	public bool GetIsLock()
	{
		if (this.IncId < 0)
		{
			return false;
		}
		AttributeItemData attributeItemData = ModelBase<InventoryModel>.Instance.GetAttributeItemData(this.IncId);
		return attributeItemData != null && attributeItemData.GetIsLock();
	}
}
