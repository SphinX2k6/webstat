using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Item;

// Token: 0x02002291 RID: 8849
public class MotorcycleRewardItemGrid : LoopScrollSmallItemGrid<TItem>
{
	// Token: 0x06010BAA RID: 68522 RVA: 0x0049556C File Offset: 0x0049376C
	protected override void OnRefresh(TItem data, bool isSelected, int gridIndex)
	{
		InventoryDefine.IGetItemData itemData = data.ItemData;
		int count = data.Count;
		this.ConfigId = itemData.ItemId;
		MotorSticker? motorStickerConfig = ConfigBase<MotorDiyConfig>.Instance.GetMotorStickerConfig(this.ConfigId);
		if (motorStickerConfig != null)
		{
			PropSmallItemGrid propSmallItemGrid = new PropSmallItemGrid();
			propSmallItemGrid.Data = data;
			propSmallItemGrid.IconPath = motorStickerConfig.Value.Icon;
			propSmallItemGrid.QualityId = new int?(motorStickerConfig.Value.QualityId);
			propSmallItemGrid.BottomText = ((count > 0) ? count.ToString() : "");
			Func<TItem, bool> showReceivedCallBack = this.ShowReceivedCallBack;
			propSmallItemGrid.IsReceivedVisible = new bool?(showReceivedCallBack != null && showReceivedCallBack(data));
			PropSmallItemGrid parameters = propSmallItemGrid;
			base.Apply<PropSmallItemGrid>(parameters);
			return;
		}
		PropSmallItemGrid propSmallItemGrid2 = new PropSmallItemGrid();
		propSmallItemGrid2.Data = data;
		propSmallItemGrid2.ItemConfigId = new int?(this.ConfigId);
		propSmallItemGrid2.BottomText = ((count > 0) ? count.ToString() : "");
		Func<TItem, bool> showReceivedCallBack2 = this.ShowReceivedCallBack;
		propSmallItemGrid2.IsReceivedVisible = new bool?(showReceivedCallBack2 != null && showReceivedCallBack2(data));
		PropSmallItemGrid parameters2 = propSmallItemGrid2;
		base.Apply<PropSmallItemGrid>(parameters2);
	}

	// Token: 0x06010BAB RID: 68523 RVA: 0x00495693 File Offset: 0x00493893
	protected override bool OnCanExecuteChange()
	{
		return false;
	}

	// Token: 0x06010BAC RID: 68524 RVA: 0x00495696 File Offset: 0x00493896
	public void SetAllowClickBack(bool isAllow)
	{
		this.AllowClickBack = isAllow;
	}

	// Token: 0x06010BAD RID: 68525 RVA: 0x0049569F File Offset: 0x0049389F
	protected override void OnExtendToggleClicked()
	{
		if (!this.AllowClickBack)
		{
			return;
		}
		ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(this.ConfigId, true, null);
	}

	// Token: 0x040083FD RID: 33789
	private int ConfigId;

	// Token: 0x040083FE RID: 33790
	private bool AllowClickBack = true;

	// Token: 0x040083FF RID: 33791
	[Nullable(2)]
	public Func<TItem, bool> ShowReceivedCallBack;
}
