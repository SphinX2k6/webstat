using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001E3B RID: 7739
[NullableContext(2)]
[Nullable(0)]
public class HandBookChipToggleItem : UiPanelBase
{
	// Token: 0x0600E514 RID: 58644 RVA: 0x003DDB2C File Offset: 0x003DBD2C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(6, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(5, new Action<EToggleState>(this.OnToggleClicked))
		};
	}

	// Token: 0x0600E515 RID: 58645 RVA: 0x003DDC01 File Offset: 0x003DBE01
	protected override void OnStart()
	{
		this.ItemGrid = new SmallItemGrid();
		this.ItemGrid.Initialize(base.GetItem(0).GetOwner());
	}

	// Token: 0x0600E516 RID: 58646 RVA: 0x003DDC28 File Offset: 0x003DBE28
	[NullableContext(1)]
	public void Refresh(HandBookCommonItemData data, bool isSelect)
	{
		this.HandBookCommonItemData = data;
		ChipHandBook chipHandBook = (ChipHandBook)data.Config;
		PropSmallItemGrid parameters = new PropSmallItemGrid
		{
			Data = data,
			IconPath = data.Icon,
			QualityId = new int?(data.QualityId)
		};
		this.ItemGrid.Apply<PropSmallItemGrid>(parameters);
		this.ItemGrid.BindOnCanExecuteChange((object _, bool _, EToggleState _) => false);
		bool flag = this.CheckIsCanShowChildList(chipHandBook.Id);
		base.GetText(2).SetText(flag ? this.HandBookCommonItemData.Title : ConfigMultiTextLang.GetLocalTextNew("Text_Unknown_Text", null), true);
		base.GetItem(4).SetUIActive(!flag);
		base.GetItem(1).SetUIActive(flag && isSelect);
		base.GetItem(6).SetUIActive(flag && !isSelect);
		bool uiactive = this.CheckNewState(chipHandBook.Id);
		base.GetItem(3).SetUIActive(uiactive);
		base.GetExtendToggle(5).SetToggleState(isSelect ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x0600E517 RID: 58647 RVA: 0x003DDD48 File Offset: 0x003DBF48
	public bool CheckIsCanShowChildList(int type)
	{
		IReadOnlyList<ChipHandBook> chipHandBookConfigList = ConfigBase<HandBookConfig>.Instance.GetChipHandBookConfigList(type);
		int num = (chipHandBookConfigList != null) ? chipHandBookConfigList.Count : 0;
		bool result = false;
		for (int i = 0; i < num; i++)
		{
			ChipHandBook chipHandBook = chipHandBookConfigList[i];
			if (ModelBase<HandBookModel>.Instance.GetHandBookInfo(EHandBookTabType.Chip, chipHandBook.Id) != null)
			{
				result = true;
				break;
			}
		}
		return result;
	}

	// Token: 0x0600E518 RID: 58648 RVA: 0x003DDDA0 File Offset: 0x003DBFA0
	public bool CheckNewState(int type)
	{
		IReadOnlyList<ChipHandBook> chipHandBookConfigList = ConfigBase<HandBookConfig>.Instance.GetChipHandBookConfigList(type);
		int num = (chipHandBookConfigList != null) ? chipHandBookConfigList.Count : 0;
		bool result = false;
		for (int i = 0; i < num; i++)
		{
			ChipHandBook chipHandBook = chipHandBookConfigList[i];
			HandBookEntry handBookInfo = ModelBase<HandBookModel>.Instance.GetHandBookInfo(EHandBookTabType.Chip, chipHandBook.Id);
			if (handBookInfo != null && !handBookInfo.IsRead)
			{
				result = true;
				break;
			}
		}
		return result;
	}

	// Token: 0x0600E519 RID: 58649 RVA: 0x003DDE08 File Offset: 0x003DC008
	public void RefreshNewState()
	{
		if (this.HandBookCommonItemData == null)
		{
			return;
		}
		bool uiactive = this.CheckNewState(((ChipHandBook)this.HandBookCommonItemData.Config).Id);
		base.GetItem(3).SetUIActive(uiactive);
	}

	// Token: 0x0600E51A RID: 58650 RVA: 0x003DDE4C File Offset: 0x003DC04C
	private void OnToggleClicked(EToggleState state)
	{
		bool flag = state == EToggleState.ETT_Checked;
		if (!flag)
		{
			return;
		}
		ChipHandBook chipHandBook = (ChipHandBook)this.HandBookCommonItemData.Config;
		bool flag2 = this.CheckIsCanShowChildList(chipHandBook.Id);
		base.GetItem(1).SetUIActive(flag2);
		base.GetItem(6).SetUIActive(false);
		base.GetItem(4).SetUIActive(!flag2);
		if (this.OnToggleCallback != null && flag)
		{
			this.OnToggleCallback(chipHandBook.Id);
		}
	}

	// Token: 0x0600E51B RID: 58651 RVA: 0x003DDECA File Offset: 0x003DC0CA
	[NullableContext(1)]
	public void BindToggleCallback(TChipToggleFunction toggleFunction)
	{
		this.OnToggleCallback = toggleFunction;
	}

	// Token: 0x04006E22 RID: 28194
	private TChipToggleFunction OnToggleCallback;

	// Token: 0x04006E23 RID: 28195
	private SmallItemGrid ItemGrid;

	// Token: 0x04006E24 RID: 28196
	private HandBookCommonItemData HandBookCommonItemData;
}
