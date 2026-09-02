using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;

// Token: 0x0200180A RID: 6154
[NullableContext(1)]
[Nullable(0)]
public class VisionRecoverySlotGridItem : VisionRecoverySlotItem, IGridProxy<PhantomItemData>
{
	// Token: 0x0600AEF5 RID: 44789 RVA: 0x002E99F4 File Offset: 0x002E7BF4
	[NullableContext(2)]
	public VisionRecoverySlotGridItem(Action<bool, PhantomItemData> callBack = null, bool showRemoveBtn = true) : base(callBack, showRemoveBtn)
	{
	}

	// Token: 0x0600AEF6 RID: 44790 RVA: 0x002E99FE File Offset: 0x002E7BFE
	public void Refresh(PhantomItemData data, bool isSelected, int gridIndex)
	{
		base.RefreshUi(data);
	}

	// Token: 0x17000E46 RID: 3654
	// (get) Token: 0x0600AEF7 RID: 44791 RVA: 0x002E9A07 File Offset: 0x002E7C07
	// (set) Token: 0x0600AEF8 RID: 44792 RVA: 0x002E9A0F File Offset: 0x002E7C0F
	[Nullable(new byte[]
	{
		2,
		1,
		1,
		1
	})]
	public IScrollViewDelegate<IGridProxy<PhantomItemData>, PhantomItemData> ScrollViewDelegate { [return: Nullable(new byte[]
	{
		2,
		1,
		1,
		1
	})] get; [param: Nullable(new byte[]
	{
		2,
		1,
		1,
		1
	})] set; }

	// Token: 0x17000E47 RID: 3655
	// (get) Token: 0x0600AEF9 RID: 44793 RVA: 0x002E9A18 File Offset: 0x002E7C18
	// (set) Token: 0x0600AEFA RID: 44794 RVA: 0x002E9A20 File Offset: 0x002E7C20
	public int GridIndex { get; set; }

	// Token: 0x17000E48 RID: 3656
	// (get) Token: 0x0600AEFB RID: 44795 RVA: 0x002E9A29 File Offset: 0x002E7C29
	// (set) Token: 0x0600AEFC RID: 44796 RVA: 0x002E9A31 File Offset: 0x002E7C31
	public int DisplayIndex { get; set; }

	// Token: 0x0600AEFD RID: 44797 RVA: 0x002E9A3A File Offset: 0x002E7C3A
	public void Clear()
	{
	}

	// Token: 0x0600AEFE RID: 44798 RVA: 0x002E9A3C File Offset: 0x002E7C3C
	public void OnSelected(bool fireEvent)
	{
	}

	// Token: 0x0600AEFF RID: 44799 RVA: 0x002E9A3E File Offset: 0x002E7C3E
	public void OnDeselected(bool fireEvent)
	{
	}

	// Token: 0x0600AF00 RID: 44800 RVA: 0x002E9A40 File Offset: 0x002E7C40
	public object GetKey(PhantomItemData data, int gridIndex)
	{
		return this.GridIndex;
	}
}
