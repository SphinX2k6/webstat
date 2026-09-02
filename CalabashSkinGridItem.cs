using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Skin;

// Token: 0x02002A48 RID: 10824
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class CalabashSkinGridItem : LoopScrollSmallItemGrid<CalabashSkinData>
{
	// Token: 0x06015ACA RID: 88778 RVA: 0x00604774 File Offset: 0x00602974
	public override void OnSelected(bool fireEvent)
	{
		if (fireEvent)
		{
			this.SetSelected(true, true);
		}
		CalabashSkinData calabashSkinData = this.Data as CalabashSkinData;
		if (calabashSkinData.IsNew)
		{
			ModelBase<CalabashSkinModel>.Instance.RemoveCalabashSkinRedDot(calabashSkinData.SkinId);
			base.SetNewFlagVisible(new bool?(false));
		}
	}

	// Token: 0x06015ACB RID: 88779 RVA: 0x006047BC File Offset: 0x006029BC
	public override void OnDeselected(bool fireEvent)
	{
		this.SetSelected(false, true);
	}

	// Token: 0x06015ACC RID: 88780 RVA: 0x006047C8 File Offset: 0x006029C8
	protected override void OnRefresh(CalabashSkinData data, bool isSelected, int gridIndex)
	{
		this.Data = data;
		PropSmallItemGrid propSmallItemGrid = new PropSmallItemGrid
		{
			Data = data,
			IconPath = (data.IsEmptyData ? ConfigBase<SkinConfig>.Instance.GetDefaultCalabashSkinIconPath() : null),
			ItemConfigId = (data.IsEmptyData ? null : new int?(data.SkinId)),
			IsNewVisible = new bool?(data.IsNew),
			QualityId = (data.IsEmptyData ? new int?(5) : null)
		};
		base.Apply<PropSmallItemGrid>(propSmallItemGrid);
		this.SetSelected(isSelected, false);
		base.SetLockBlackVisible(data.GetIsLock());
		this.RefreshVisible();
		if (data.IsEmptyData)
		{
			base.SetSkinQualityByParameters(propSmallItemGrid);
			base.RefreshSkinByDefault(propSmallItemGrid.QualityId.Value, InventoryDefine.EItemDataType.CalabashSkinItem);
		}
	}

	// Token: 0x06015ACD RID: 88781 RVA: 0x0060489C File Offset: 0x00602A9C
	public void RefreshVisible()
	{
		CalabashSkinData calabashSkinData = this.Data as CalabashSkinData;
		base.SetSelectVisible(calabashSkinData.IsCurrentEquipSkinId());
	}
}
