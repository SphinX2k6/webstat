using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.TrapDefense;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002C17 RID: 11287
[NullableContext(1)]
[Nullable(0)]
public class TrapDefenseBdBuffSelectView : UiViewBase
{
	// Token: 0x0601691E RID: 92446 RVA: 0x00643B4F File Offset: 0x00641D4F
	public TrapDefenseBdBuffSelectView(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x0601691F RID: 92447 RVA: 0x00643B74 File Offset: 0x00641D74
	protected unsafe override void OnRegisterComponent()
	{
		int num = 9;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUILayoutBase));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnClickBtnBdSum));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06016920 RID: 92448 RVA: 0x00643D04 File Offset: 0x00641F04
	protected override UniTask OnBeforeStartAsync()
	{
		TrapDefenseBdBuffSelectView.<OnBeforeStartAsync>d__14 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<TrapDefenseBdBuffSelectView.<OnBeforeStartAsync>d__14>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06016921 RID: 92449 RVA: 0x00643D48 File Offset: 0x00641F48
	public UniTask InitGoldCostItem()
	{
		TrapDefenseBdBuffSelectView.<InitGoldCostItem>d__15 <InitGoldCostItem>d__;
		<InitGoldCostItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitGoldCostItem>d__.<>4__this = this;
		<InitGoldCostItem>d__.<>1__state = -1;
		<InitGoldCostItem>d__.<>t__builder.Start<TrapDefenseBdBuffSelectView.<InitGoldCostItem>d__15>(ref <InitGoldCostItem>d__);
		return <InitGoldCostItem>d__.<>t__builder.Task;
	}

	// Token: 0x06016922 RID: 92450 RVA: 0x00643D8C File Offset: 0x00641F8C
	public UniTask CreateBdBuffPanel(int key)
	{
		TrapDefenseBdBuffSelectView.<CreateBdBuffPanel>d__16 <CreateBdBuffPanel>d__;
		<CreateBdBuffPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateBdBuffPanel>d__.<>4__this = this;
		<CreateBdBuffPanel>d__.key = key;
		<CreateBdBuffPanel>d__.<>1__state = -1;
		<CreateBdBuffPanel>d__.<>t__builder.Start<TrapDefenseBdBuffSelectView.<CreateBdBuffPanel>d__16>(ref <CreateBdBuffPanel>d__);
		return <CreateBdBuffPanel>d__.<>t__builder.Task;
	}

	// Token: 0x06016923 RID: 92451 RVA: 0x00643DD8 File Offset: 0x00641FD8
	protected override void OnStart()
	{
		this.BtnItem.SetActive(true);
		this.BtnAndCostItem.SetActive(true);
		string refreshBuffCostIconPath = this.ViewModel.GetRefreshBuffCostIconPath(new int?(this.RefreshBuffCostId));
		this.BtnAndCostItem.UpdateCostIcon(refreshBuffCostIconPath);
		this.UpdateCostNum();
	}

	// Token: 0x06016924 RID: 92452 RVA: 0x00643E26 File Offset: 0x00642026
	public void UpdateCostNum()
	{
		this.RefreshBuffCostNum = this.ViewModel.RefreshBuffCostNum;
		this.BtnAndCostItem.UpdateCostNum(this.RefreshBuffCostNum);
	}

	// Token: 0x06016925 RID: 92453 RVA: 0x00643E4A File Offset: 0x0064204A
	protected override void OnAddEventListener()
	{
	}

	// Token: 0x06016926 RID: 92454 RVA: 0x00643E4C File Offset: 0x0064204C
	protected override void OnRemoveEventListener()
	{
	}

	// Token: 0x06016927 RID: 92455 RVA: 0x00643E4E File Offset: 0x0064204E
	protected override void OnBeforeShow()
	{
		this.UpdateData();
	}

	// Token: 0x06016928 RID: 92456 RVA: 0x00643E56 File Offset: 0x00642056
	protected override void OnBeforeDestroy()
	{
	}

	// Token: 0x06016929 RID: 92457 RVA: 0x00643E58 File Offset: 0x00642058
	protected override void OnAfterDestroy()
	{
		this.ViewModel.OnViewClose();
	}

	// Token: 0x0601692A RID: 92458 RVA: 0x00643E68 File Offset: 0x00642068
	private void OnClickBtnBdSum()
	{
		this.ViewModel.Model.OpenViewBdSum(new bool?(true), new ETrapDefenseBdTabType?(ETrapDefenseBdTabType.BdProgress), null);
	}

	// Token: 0x0601692B RID: 92459 RVA: 0x00643E9C File Offset: 0x0064209C
	public void UpdateData()
	{
		this.LayoutBd.RefreshByData(this.ViewModel.GetShowBdDataList(), null, true);
		List<TrapDefenseBdBuffData> bdBuffDataList = this.ViewModel.BdBuffDataList;
		TrapDefenseBdBuffData curSelectBdBuffData = this.ViewModel.CurSelectBdBuffData;
		for (int i = 0; i < this.BdBuffPanelList.Count; i++)
		{
			TrapDefenseBdSumBuffDescPanel trapDefenseBdSumBuffDescPanel = this.BdBuffPanelList[i];
			TrapDefenseBdBuffData trapDefenseBdBuffData = (i < bdBuffDataList.Count) ? bdBuffDataList[i] : null;
			trapDefenseBdSumBuffDescPanel.SetActive(trapDefenseBdBuffData != null);
			if (trapDefenseBdBuffData != null)
			{
				trapDefenseBdSumBuffDescPanel.UpdateDataSelectMode(trapDefenseBdBuffData);
				trapDefenseBdSumBuffDescPanel.SetSelect(trapDefenseBdBuffData == curSelectBdBuffData);
			}
		}
		this.UpdateCost();
		this.CheckBdActiveNewQuality();
		this.UpdateSureBtnEnable();
	}

	// Token: 0x0601692C RID: 92460 RVA: 0x00643F48 File Offset: 0x00642148
	public void UpdateCost()
	{
		this.RefreshBuffMaxTimes = this.ViewModel.MaxRefreshCount;
		ETrapDefenseTextKey bdBuffSelectRefreshDesc = ETrapDefenseTextKey.BdBuffSelectRefreshDesc;
		int remainRefreshCount = this.ViewModel.RemainRefreshCount;
		this.BtnAndCostItem.SetLocalTextNew(bdBuffSelectRefreshDesc.ToString(), new object[]
		{
			remainRefreshCount,
			this.RefreshBuffMaxTimes
		});
		this.BtnAndCostItem.UpdateCostColor(!this.ViewModel.RefreshBuffIsEnoughCost(null));
		this.BtnAndCostItem.SetEnableClick(remainRefreshCount > 0);
		this.BtnAndCostItem.SetActive(this.RefreshBuffMaxTimes > 0);
	}

	// Token: 0x0601692D RID: 92461 RVA: 0x00643FF2 File Offset: 0x006421F2
	public void CheckBdActiveNewQuality()
	{
		this.BtnTagTips.SetActive(false);
	}

	// Token: 0x0601692E RID: 92462 RVA: 0x00644000 File Offset: 0x00642200
	public void UpdateSureBtnEnable()
	{
		bool enableClick = this.ViewModel.CurSelectBdBuffData != null || this.ViewModel.BdBuffDataList.Count <= 0;
		ButtonItem btnItem = this.BtnItem;
		if (btnItem == null)
		{
			return;
		}
		btnItem.SetEnableClick(enableClick);
	}

	// Token: 0x0601692F RID: 92463 RVA: 0x00644045 File Offset: 0x00642245
	private TrapDefenseBdBuffSelectBdItem CreateItemBd()
	{
		return new TrapDefenseBdBuffSelectBdItem
		{
			ClickCallBack = new Action<TrapDefenseBdData>(this.OnClickBdItem)
		};
	}

	// Token: 0x06016930 RID: 92464 RVA: 0x0064405E File Offset: 0x0064225E
	private void OnClickBdItem(TrapDefenseBdData data)
	{
		this.ViewModel.Model.OpenViewBdSum(new bool?(true), new ETrapDefenseBdTabType?(ETrapDefenseBdTabType.BdProgress), new int?(data.Id));
	}

	// Token: 0x06016931 RID: 92465 RVA: 0x00644087 File Offset: 0x00642287
	private bool OnCanSelectBdBuff()
	{
		return true;
	}

	// Token: 0x06016932 RID: 92466 RVA: 0x0064408A File Offset: 0x0064228A
	private void OnSelectBdBuff(TrapDefenseBdBuffData data)
	{
		this.ViewModel.SetSelectBuff(data);
		this.UpdateCost();
		this.UpdateBuffPanelSelectState();
		this.CheckBdActiveNewQuality();
		this.UpdateSureBtnEnable();
		this.LayoutBd.RefreshWithoutDataSync();
	}

	// Token: 0x06016933 RID: 92467 RVA: 0x006440BC File Offset: 0x006422BC
	public void UpdateBuffPanelSelectState()
	{
		TrapDefenseBdBuffData curSelectBdBuffData = this.ViewModel.CurSelectBdBuffData;
		foreach (TrapDefenseBdSumBuffDescPanel trapDefenseBdSumBuffDescPanel in this.BdBuffPanelList)
		{
			trapDefenseBdSumBuffDescPanel.SetSelect(curSelectBdBuffData == trapDefenseBdSumBuffDescPanel.BdBuffData);
		}
	}

	// Token: 0x06016934 RID: 92468 RVA: 0x00644124 File Offset: 0x00642324
	private void OnBtnClose()
	{
		if (this.ViewModel.BdBuffDataList.Count <= 0)
		{
			base.CloseMe(null);
		}
	}

	// Token: 0x06016935 RID: 92469 RVA: 0x00644140 File Offset: 0x00642340
	private void OnBtnHelp()
	{
		int helpIdBdBuffSelect = ConfigBase<TrapDefenseConfig>.Instance.GetHelpIdBdBuffSelect();
		ControllerBase<HelpController>.Instance.OpenHelpById(helpIdBdBuffSelect);
	}

	// Token: 0x06016936 RID: 92470 RVA: 0x00644163 File Offset: 0x00642363
	private void OnClickBtnSure(int _)
	{
		if (this.ViewModel.BdBuffDataList.Count <= 0)
		{
			base.CloseMe(null);
			return;
		}
		this.SureBuffSelect().Forget();
	}

	// Token: 0x06016937 RID: 92471 RVA: 0x0064418C File Offset: 0x0064238C
	public UniTask SureBuffSelect()
	{
		TrapDefenseBdBuffSelectView.<SureBuffSelect>d__37 <SureBuffSelect>d__;
		<SureBuffSelect>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<SureBuffSelect>d__.<>4__this = this;
		<SureBuffSelect>d__.<>1__state = -1;
		<SureBuffSelect>d__.<>t__builder.Start<TrapDefenseBdBuffSelectView.<SureBuffSelect>d__37>(ref <SureBuffSelect>d__);
		return <SureBuffSelect>d__.<>t__builder.Task;
	}

	// Token: 0x06016938 RID: 92472 RVA: 0x006441D0 File Offset: 0x006423D0
	public UniTask CheckPlayUpStageEffect()
	{
		TrapDefenseBdBuffSelectView.<CheckPlayUpStageEffect>d__38 <CheckPlayUpStageEffect>d__;
		<CheckPlayUpStageEffect>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CheckPlayUpStageEffect>d__.<>4__this = this;
		<CheckPlayUpStageEffect>d__.<>1__state = -1;
		<CheckPlayUpStageEffect>d__.<>t__builder.Start<TrapDefenseBdBuffSelectView.<CheckPlayUpStageEffect>d__38>(ref <CheckPlayUpStageEffect>d__);
		return <CheckPlayUpStageEffect>d__.<>t__builder.Task;
	}

	// Token: 0x06016939 RID: 92473 RVA: 0x00644213 File Offset: 0x00642413
	private void OnClickRefreshBuff(int _)
	{
		this.ViewModel.RequestUpdateBdBuffList().ContinueWith(delegate(bool ok)
		{
			if (ok)
			{
				this.UpdateCostNum();
				this.UpdateData();
				base.PlaySequence("Start", null, false);
			}
		});
	}

	// Token: 0x0601693A RID: 92474 RVA: 0x00644234 File Offset: 0x00642434
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
	{
		if (configParams.Length == 0)
		{
			return null;
		}
		if (!(configParams[0] == "BdList"))
		{
			return null;
		}
		if (configParams.Length < 2)
		{
			return null;
		}
		int num;
		if (!int.TryParse(configParams[1], out num))
		{
			return null;
		}
		if (num < 0 || num >= this.LayoutBd.GetDatas().Count)
		{
			return null;
		}
		UUIItem itemByIndex = this.LayoutBd.GetItemByIndex(num);
		if (itemByIndex == null)
		{
			return null;
		}
		return new UUIItem[]
		{
			itemByIndex,
			itemByIndex
		};
	}

	// Token: 0x0400AE54 RID: 44628
	public PopupCaptionItem PopupCaption;

	// Token: 0x0400AE55 RID: 44629
	public GenericLayout<TrapDefenseBdBuffSelectBdItem, TrapDefenseBdData> LayoutBd;

	// Token: 0x0400AE56 RID: 44630
	public List<TrapDefenseBdSumBuffDescPanel> BdBuffPanelList = new List<TrapDefenseBdSumBuffDescPanel>();

	// Token: 0x0400AE57 RID: 44631
	public ButtonAndCostItem BtnAndCostItem;

	// Token: 0x0400AE58 RID: 44632
	public ButtonItem BtnItem;

	// Token: 0x0400AE59 RID: 44633
	public TrapDefenseBtnTagTips BtnTagTips;

	// Token: 0x0400AE5A RID: 44634
	public TrapDefenseBdBuffSelectViewModel ViewModel = ModelBase<TrapDefenseModel>.Instance.ViewModeBdBuffSelect;

	// Token: 0x0400AE5B RID: 44635
	public int RefreshBuffCostId;

	// Token: 0x0400AE5C RID: 44636
	public int RefreshBuffCostNum;

	// Token: 0x0400AE5D RID: 44637
	public int RefreshBuffMaxTimes;

	// Token: 0x0400AE5E RID: 44638
	public TrapDefenseGoldCostItem GoldCostItem;

	// Token: 0x02008F2B RID: 36651
	[NullableContext(0)]
	private class EChildType
	{
		// Token: 0x0403014F RID: 196943
		public const int ItemCaption = 0;

		// Token: 0x04030150 RID: 196944
		public const int LayoutBd = 1;

		// Token: 0x04030151 RID: 196945
		public const int BtnBdSum = 2;

		// Token: 0x04030152 RID: 196946
		public const int ItemBdBuff1 = 3;

		// Token: 0x04030153 RID: 196947
		public const int ItemBdBuff2 = 4;

		// Token: 0x04030154 RID: 196948
		public const int ItemBdBuff3 = 5;

		// Token: 0x04030155 RID: 196949
		public const int ItemBtnRefresh = 6;

		// Token: 0x04030156 RID: 196950
		public const int ItemBtnSure = 7;

		// Token: 0x04030157 RID: 196951
		public const int ItemTagTip = 8;
	}
}
