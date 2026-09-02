using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Ui;

// Token: 0x02002028 RID: 8232
public class InventoryGiftCellItem : SmallItemGrid
{
	// Token: 0x0600FA44 RID: 64068 RVA: 0x00448DE8 File Offset: 0x00446FE8
	[NullableContext(1)]
	public void RefreshByConfigId(GiftItemData giftItemData)
	{
		this.GiftItemData = giftItemData;
		if (ConfigBase<InventoryConfig>.Instance.GetItemDataTypeByConfigId(new int?(giftItemData.ItemId)) == InventoryDefine.EItemDataType.RoleItem)
		{
			RoleInfo? roleConfig = ConfigBase<RoleConfig>.Instance.GetRoleConfig(giftItemData.ItemId);
			CharacterSmallItemGrid parameters = new CharacterSmallItemGrid
			{
				Data = null,
				ItemConfigId = new int?(giftItemData.ItemId),
				BottomText = "",
				QualityId = new int?(roleConfig.Value.QualityId),
				IsReceivedVisible = new bool?(false)
			};
			base.Apply<CharacterSmallItemGrid>(parameters);
			return;
		}
		if (this.GiftItemData.PhantomItemData != null)
		{
			PhantomSmallItemGrid parameters2 = new PhantomSmallItemGrid
			{
				Data = null,
				ItemConfigId = new int?(giftItemData.ItemId),
				BottomText = "",
				IsReceivedVisible = new bool?(false),
				FetterGroupId = new int?(this.GiftItemData.PhantomItemData.FetterGroupId)
			};
			base.Apply<PhantomSmallItemGrid>(parameters2);
			return;
		}
		PropSmallItemGrid parameters3 = new PropSmallItemGrid
		{
			Data = null,
			ItemConfigId = new int?(giftItemData.ItemId),
			BottomText = "",
			IsReceivedVisible = new bool?(false)
		};
		base.Apply<PropSmallItemGrid>(parameters3);
	}

	// Token: 0x0600FA45 RID: 64069 RVA: 0x00448F1F File Offset: 0x0044711F
	protected override bool OnCanExecuteChange()
	{
		return false;
	}

	// Token: 0x0600FA46 RID: 64070 RVA: 0x00448F24 File Offset: 0x00447124
	protected override void OnExtendToggleClicked()
	{
		bool canSkip = Singleton<UiManager>.Instance.IsViewShow(EUiViewName.InventoryView);
		if (this.GiftItemData.PhantomItemData != null)
		{
			ControllerBase<ItemController>.Instance.OpenItemTipsByExtraParam(this.GiftItemData.IncId, this.GiftItemData.PhantomItemData.Id, this.GiftItemData.PhantomItemData, canSkip, null);
			return;
		}
		ControllerBase<ItemController>.Instance.OpenItemTipsByItemUid(this.GiftItemData.IncId, this.GiftItemData.ItemId, canSkip, null);
	}

	// Token: 0x0400782D RID: 30765
	[Nullable(2)]
	private GiftItemData GiftItemData;
}
