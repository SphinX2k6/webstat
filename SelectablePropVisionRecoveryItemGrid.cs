using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Inventory;

// Token: 0x02001A0A RID: 6666
public class SelectablePropVisionRecoveryItemGrid : SelectablePropMediumItemGrid
{
	// Token: 0x0600BF11 RID: 48913 RVA: 0x00328C44 File Offset: 0x00326E44
	[NullableContext(1)]
	public override void RefreshUi(SelectablePropData data)
	{
		this.SelectablePropData = data;
		InventoryModel instance = ModelBase<InventoryModel>.Instance;
		int incId = data.IncId;
		int itemId = data.ItemId;
		InventoryDefine.EItemDataType itemDataType = data.ItemDataType;
		ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(itemId);
		if (itemConfigData == null)
		{
			return;
		}
		ItemDataBase itemDataBase;
		if (incId > 0)
		{
			itemDataBase = instance.GetAttributeItemData(incId);
		}
		else
		{
			itemDataBase = instance.GetCommonItemData(itemId, 0);
		}
		if (itemDataBase == null)
		{
			return;
		}
		int selectedCount = this.SelectablePropData.SelectedCount;
		int count = this.SelectablePropData.Count;
		PropMediumItemGrid propMediumItemGrid = new PropMediumItemGrid
		{
			Data = data,
			ItemConfigId = new int?(itemId),
			StarLevel = new int?(itemConfigData.QualityId),
			ReduceButtonInfo = new LongPressButton
			{
				IsVisible = new bool?(selectedCount > 0),
				LongPressConfigId = new LongPressButtonItem.ELongPressConfigId?(LongPressButtonItem.ELongPressConfigId.LongPressOne)
			}
		};
		if (itemDataType == InventoryDefine.EItemDataType.PhantomItem)
		{
			PhantomBattleData phantomBattleData = ModelBase<PhantomBattleModel>.Instance.GetPhantomBattleData(incId);
			if (phantomBattleData != null)
			{
				int phantomLevel = phantomBattleData.GetPhantomLevel();
				int exp = phantomBattleData.GetExp();
				propMediumItemGrid.ItemConfigId = new int?(phantomBattleData.GetConfigId(true));
				propMediumItemGrid.QualityId = new int?(phantomBattleData.GetQuality());
				propMediumItemGrid.Level = new int?(phantomBattleData.GetCost());
				propMediumItemGrid.IsLevelTextUseChangeColor = new bool?(true);
				propMediumItemGrid.BottomTextId = "VisionLevel";
				propMediumItemGrid.IsDisable = new bool?(phantomLevel > 1 || exp > 0 || (this.SelectablePropData.OnlyGold && phantomBattleData.GetQuality() < 5));
				propMediumItemGrid.BottomTextParameter = new object[]
				{
					phantomBattleData.GetPhantomLevel()
				};
				propMediumItemGrid.VisionFetterGroupId = new int?(phantomBattleData.GetFetterGroupId());
				propMediumItemGrid.IsOmitBottomText = new bool?(true);
				propMediumItemGrid.IsLockVisible = new bool?(phantomBattleData.GetIsLock());
				propMediumItemGrid.IsDeprecate = new bool?(phantomBattleData.GetIsDeprecated());
			}
		}
		else if (selectedCount > 0)
		{
			propMediumItemGrid.BottomTextId = "Text_ItemEnoughText_Text";
			propMediumItemGrid.BottomTextParameter = new object[]
			{
				selectedCount,
				count
			};
		}
		else
		{
			propMediumItemGrid.BottomText = count.ToString();
		}
		base.Apply<PropMediumItemGrid>(propMediumItemGrid);
	}
}
