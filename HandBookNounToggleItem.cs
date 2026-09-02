using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001EA2 RID: 7842
[NullableContext(2)]
[Nullable(0)]
internal class HandBookNounToggleItem : UiPanelBase
{
	// Token: 0x0600E7CD RID: 59341 RVA: 0x003E9EA4 File Offset: 0x003E80A4
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

	// Token: 0x0600E7CE RID: 59342 RVA: 0x003E9F79 File Offset: 0x003E8179
	protected override void OnStart()
	{
		this.ItemGrid = new SmallItemGrid();
		this.ItemGrid.Initialize(base.GetItem(0).GetOwner());
	}

	// Token: 0x0600E7CF RID: 59343 RVA: 0x003E9FA0 File Offset: 0x003E81A0
	[NullableContext(1)]
	public void Refresh(HandBookCommonItemData data, bool isSelect)
	{
		this.HandBookCommonItemData = data;
		NounType nounType = (NounType)data.Config;
		PropSmallItemGrid parameters = new PropSmallItemGrid
		{
			Data = data,
			IconPath = data.Icon,
			QualityId = new int?(data.QualityId)
		};
		this.ItemGrid.Apply<PropSmallItemGrid>(parameters);
		this.ItemGrid.BindOnCanExecuteChange((object _, bool _, EToggleState _) => false);
		bool flag = this.CheckIsCanShowChildList(nounType.Id);
		string newText = flag ? this.HandBookCommonItemData.Title : (ConfigMultiTextLang.GetLocalTextNew("Text_Unknown_Text", null) ?? "");
		base.GetText(2).SetText(newText, true);
		base.GetItem(4).SetUIActive(!flag);
		base.GetItem(1).SetUIActive(flag && isSelect);
		base.GetItem(6).SetUIActive(flag && !isSelect);
		bool uiactive = this.CheckNewState(nounType.Id);
		base.GetItem(3).SetUIActive(uiactive);
		base.GetExtendToggle(5).SetToggleState(isSelect ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x0600E7D0 RID: 59344 RVA: 0x003EA0CC File Offset: 0x003E82CC
	public bool CheckIsCanShowChildList(int type)
	{
		IReadOnlyList<NounHandBook> nounHandBookConfigList = ConfigBase<HandBookConfig>.Instance.GetNounHandBookConfigList(type);
		int num = (nounHandBookConfigList != null) ? nounHandBookConfigList.Count : 0;
		bool result = false;
		for (int i = 0; i < num; i++)
		{
			NounHandBook nounHandBook = nounHandBookConfigList[i];
			if (ModelBase<HandBookModel>.Instance.GetHandBookInfo(EHandBookTabType.Noun, nounHandBook.Id) != null)
			{
				result = true;
				break;
			}
		}
		return result;
	}

	// Token: 0x0600E7D1 RID: 59345 RVA: 0x003EA124 File Offset: 0x003E8324
	public bool CheckNewState(int type)
	{
		IReadOnlyList<NounHandBook> nounHandBookConfigList = ConfigBase<HandBookConfig>.Instance.GetNounHandBookConfigList(type);
		int num = (nounHandBookConfigList != null) ? nounHandBookConfigList.Count : 0;
		bool result = false;
		for (int i = 0; i < num; i++)
		{
			NounHandBook nounHandBook = nounHandBookConfigList[i];
			HandBookEntry handBookInfo = ModelBase<HandBookModel>.Instance.GetHandBookInfo(EHandBookTabType.Noun, nounHandBook.Id);
			if (handBookInfo != null && !handBookInfo.IsRead)
			{
				result = true;
				break;
			}
		}
		return result;
	}

	// Token: 0x0600E7D2 RID: 59346 RVA: 0x003EA18C File Offset: 0x003E838C
	public void RefreshNewState()
	{
		if (this.HandBookCommonItemData == null)
		{
			return;
		}
		bool uiactive = this.CheckNewState(((NounType)this.HandBookCommonItemData.Config).Id);
		base.GetItem(3).SetUIActive(uiactive);
	}

	// Token: 0x0600E7D3 RID: 59347 RVA: 0x003EA1D0 File Offset: 0x003E83D0
	private void OnToggleClicked(EToggleState state)
	{
		bool flag = state == EToggleState.ETT_Checked;
		if (!flag)
		{
			return;
		}
		NounType nounType = (NounType)this.HandBookCommonItemData.Config;
		bool flag2 = this.CheckIsCanShowChildList(nounType.Id);
		base.GetItem(1).SetUIActive(flag2);
		base.GetItem(6).SetUIActive(false);
		base.GetItem(4).SetUIActive(!flag2);
		if (this.OnToggleCallback != null && flag)
		{
			this.OnToggleCallback(nounType.Id);
		}
	}

	// Token: 0x0600E7D4 RID: 59348 RVA: 0x003EA24E File Offset: 0x003E844E
	[NullableContext(1)]
	public void BindToggleCallback(TNounToggleFunction toggleFunction)
	{
		this.OnToggleCallback = toggleFunction;
	}

	// Token: 0x04006FC1 RID: 28609
	private TNounToggleFunction OnToggleCallback;

	// Token: 0x04006FC2 RID: 28610
	private SmallItemGrid ItemGrid;

	// Token: 0x04006FC3 RID: 28611
	private HandBookCommonItemData HandBookCommonItemData;
}
