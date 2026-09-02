using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Inventory;

// Token: 0x02001A09 RID: 6665
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class SelectablePropMediumItemGrid : LoopScrollMediumItemGrid<SelectablePropData>
{
	// Token: 0x0600BF06 RID: 48902 RVA: 0x003287B0 File Offset: 0x003269B0
	public override void OnSelected(bool fireEvent)
	{
		if (fireEvent)
		{
			LongPressButton reduceButton = new LongPressButton
			{
				IsVisible = new bool?(true),
				LongPressConfigId = new LongPressButtonItem.ELongPressConfigId?(LongPressButtonItem.ELongPressConfigId.LongPressOne)
			};
			this.SetSelected(true, true);
			base.SetReduceButton(reduceButton);
		}
	}

	// Token: 0x0600BF07 RID: 48903 RVA: 0x003287ED File Offset: 0x003269ED
	public override void OnDeselected(bool fireEvent)
	{
		this.SetSelected(false, true);
	}

	// Token: 0x0600BF08 RID: 48904 RVA: 0x003287F7 File Offset: 0x003269F7
	public override void SetSelected(bool bSelected, bool bForce = false)
	{
		this.RefreshUi(this.SelectablePropData);
		base.SetSelected(bSelected, bForce);
	}

	// Token: 0x0600BF09 RID: 48905 RVA: 0x0032880D File Offset: 0x00326A0D
	protected override void OnStart()
	{
		this.GetItemGridExtendToggle().FocusListenerDelegate.Bind(new Action(this.ShowItemTips));
	}

	// Token: 0x0600BF0A RID: 48906 RVA: 0x0032882B File Offset: 0x00326A2B
	protected override void OnBeforeDestroy()
	{
		this.GetItemGridExtendToggle().FocusListenerDelegate.Unbind();
		this.OnAfterApplyCallback = null;
	}

	// Token: 0x0600BF0B RID: 48907 RVA: 0x00328844 File Offset: 0x00326A44
	private void ShowItemTips()
	{
		Singleton<EventSystem>.Instance.Emit<int, int>(EEventName.OnSelectItemAdd, this.SelectablePropData.ItemId, this.SelectablePropData.IncId);
	}

	// Token: 0x0600BF0C RID: 48908 RVA: 0x0032886C File Offset: 0x00326A6C
	protected override void OnRefresh(SelectablePropData data, bool isSelected, int gridIndex)
	{
		this.SelectablePropData = data;
		this.SetSelected(data.SelectedCount > 0, true);
		if (this.OnAfterApplyCallback != null)
		{
			this.OnAfterApplyCallback(this);
		}
	}

	// Token: 0x0600BF0D RID: 48909 RVA: 0x0032889C File Offset: 0x00326A9C
	public virtual void RefreshUi(SelectablePropData data)
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
			},
			IsLockVisible = new bool?(itemDataBase.GetIsLock()),
			IsDeprecate = new bool?(itemDataBase.GetIsDeprecated())
		};
		switch (itemDataType)
		{
		case InventoryDefine.EItemDataType.CommonItem:
			propMediumItemGrid.BuffIconType = new EMediumItemGridBuffType?((EMediumItemGridBuffType)itemConfigData.ItemBuffType);
			propMediumItemGrid.IsOmitBottomText = new bool?(false);
			if (selectedCount > 0)
			{
				propMediumItemGrid.BottomTextId = "Text_ItemEnoughText_Text";
				propMediumItemGrid.BottomTextParameter = new object[]
				{
					selectedCount,
					count
				};
				goto IL_2AA;
			}
			propMediumItemGrid.BottomText = count.ToString();
			goto IL_2AA;
		case InventoryDefine.EItemDataType.WeaponItem:
		{
			WeaponInstance weaponDataByIncId = ModelBase<WeaponModel>.Instance.GetWeaponDataByIncId(incId);
			if (weaponDataByIncId != null)
			{
				int resonanceLevel = weaponDataByIncId.GetResonanceLevel();
				propMediumItemGrid.Level = new int?(resonanceLevel);
				propMediumItemGrid.BottomTextId = "Text_LevelShow_Text";
				propMediumItemGrid.BottomTextParameter = new object[]
				{
					weaponDataByIncId.GetLevel()
				};
				goto IL_2AA;
			}
			goto IL_2AA;
		}
		case InventoryDefine.EItemDataType.PhantomItem:
		{
			PhantomBattleData phantomBattleData = ModelBase<PhantomBattleModel>.Instance.GetPhantomBattleData(incId);
			if (phantomBattleData != null)
			{
				propMediumItemGrid.ItemConfigId = new int?(phantomBattleData.GetConfigId(true));
				propMediumItemGrid.QualityId = new int?(phantomBattleData.GetQuality());
				propMediumItemGrid.Level = new int?(phantomBattleData.GetCost());
				propMediumItemGrid.IsLevelTextUseChangeColor = new bool?(true);
				propMediumItemGrid.BottomTextId = "VisionLevel";
				propMediumItemGrid.BottomTextParameter = new object[]
				{
					phantomBattleData.GetPhantomLevel()
				};
				propMediumItemGrid.VisionFetterGroupId = new int?(phantomBattleData.GetFetterGroupId());
				propMediumItemGrid.IsOmitBottomText = new bool?(true);
				goto IL_2AA;
			}
			goto IL_2AA;
		}
		}
		if (selectedCount > 0)
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
		IL_2AA:
		base.Apply<PropMediumItemGrid>(propMediumItemGrid);
	}

	// Token: 0x0600BF0E RID: 48910 RVA: 0x00328B5C File Offset: 0x00326D5C
	public void RefreshCostCount()
	{
		if (this.SelectablePropData == null)
		{
			return;
		}
		InventoryDefine.EItemDataType itemDataType = this.SelectablePropData.ItemDataType;
		int selectedCount = this.SelectablePropData.SelectedCount;
		int count = this.SelectablePropData.Count;
		switch (itemDataType)
		{
		case InventoryDefine.EItemDataType.CommonItem:
			if (selectedCount > 0)
			{
				base.SetBottomTextId("Text_ItemEnoughText_Text", new object[]
				{
					selectedCount,
					count
				});
				return;
			}
			base.SetBottomText(this.SelectablePropData.Count.ToString());
			return;
		case InventoryDefine.EItemDataType.WeaponItem:
		case InventoryDefine.EItemDataType.PhantomItem:
			return;
		}
		if (selectedCount > 0)
		{
			base.SetBottomTextId("Text_ItemEnoughText_Text", new object[]
			{
				selectedCount,
				count
			});
			return;
		}
		base.SetBottomText(this.SelectablePropData.Count.ToString());
	}

	// Token: 0x0600BF0F RID: 48911 RVA: 0x00328C31 File Offset: 0x00326E31
	public void BindAfterApply(Action<SelectablePropMediumItemGrid> onAfterApplyCallback)
	{
		this.OnAfterApplyCallback = onAfterApplyCallback;
	}

	// Token: 0x040059D1 RID: 22993
	[Nullable(2)]
	public SelectablePropData SelectablePropData;

	// Token: 0x040059D2 RID: 22994
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Action<SelectablePropMediumItemGrid> OnAfterApplyCallback;
}
