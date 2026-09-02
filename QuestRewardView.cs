using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.ItemReward;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001E0B RID: 7691
public class QuestRewardView : UiViewBase
{
	// Token: 0x0600E311 RID: 58129 RVA: 0x003D2A44 File Offset: 0x003D0C44
	[NullableContext(1)]
	public QuestRewardView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600E312 RID: 58130 RVA: 0x003D2A50 File Offset: 0x003D0C50
	protected unsafe override void OnRegisterComponent()
	{
		int num = 5;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickedMaskButton));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600E313 RID: 58131 RVA: 0x003D2B59 File Offset: 0x003D0D59
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<IReadOnlyList<RewardItemData>>(EEventName.OnRefreshRewardViewItemList, new Action<IReadOnlyList<RewardItemData>>(this.OnRefreshRewardItemList));
		Singleton<EventSystem>.Instance.Add<EUiTabViewName, int?>(EEventName.ChangeChildView, new Action<EUiTabViewName, int?>(this.OnChangeChildView));
	}

	// Token: 0x0600E314 RID: 58132 RVA: 0x003D2B90 File Offset: 0x003D0D90
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnRefreshRewardViewItemList, new Action<IReadOnlyList<RewardItemData>>(this.OnRefreshRewardItemList));
		Singleton<EventSystem>.Instance.Remove(EEventName.ChangeChildView, new Action<EUiTabViewName, int?>(this.OnChangeChildView));
	}

	// Token: 0x0600E315 RID: 58133 RVA: 0x003D2BC8 File Offset: 0x003D0DC8
	protected override void OnStart()
	{
		RewardData<ICommonRewardInfo> rewardData = this.OpenParam as RewardData<ICommonRewardInfo>;
		if (rewardData == null)
		{
			return;
		}
		this.RewardData = rewardData;
		this.RewardItemList = new QuestRewardItemList(base.GetItem(3).GetOwner());
		if (this.RefreshTitleVisible())
		{
			this.RefreshTitle();
		}
		if (this.RefreshContinueTextVisible())
		{
			this.RefreshContinueText();
		}
		if (this.RefreshItemListVisible())
		{
			this.RefreshItemList();
		}
		string audioId = rewardData.GetRewardInfo().AudioId;
		ControllerBase<ItemRewardController>.Instance.PlayAudio(audioId, null);
	}

	// Token: 0x0600E316 RID: 58134 RVA: 0x003D2C45 File Offset: 0x003D0E45
	protected override void OnAfterDestroy()
	{
		this.RewardData = null;
	}

	// Token: 0x0600E317 RID: 58135 RVA: 0x003D2C4E File Offset: 0x003D0E4E
	protected override void OnAfterShow()
	{
		Singleton<EventSystem>.Instance.Emit(EEventName.OnShowRewardView);
	}

	// Token: 0x0600E318 RID: 58136 RVA: 0x003D2C60 File Offset: 0x003D0E60
	protected override void OnBeforeDestroyImplement()
	{
		Action onCloseCallback = this.RewardData.GetRewardInfo().OnCloseCallback;
		if (onCloseCallback != null)
		{
			onCloseCallback();
		}
		ModelBase<ItemRewardModel>.Instance.ClearCurrentRewardData();
	}

	// Token: 0x0600E319 RID: 58137 RVA: 0x003D2C87 File Offset: 0x003D0E87
	private void OnChangeChildView(EUiTabViewName eUiTabViewName, int? o)
	{
		Singleton<UiManager>.Instance.CloseView(this.ViewInfo.Name, null);
	}

	// Token: 0x0600E31A RID: 58138 RVA: 0x003D2C9F File Offset: 0x003D0E9F
	private void OnClickedMaskButton()
	{
		Singleton<UiManager>.Instance.CloseView(this.ViewInfo.Name, null);
	}

	// Token: 0x0600E31B RID: 58139 RVA: 0x003D2CB7 File Offset: 0x003D0EB7
	[NullableContext(1)]
	private void OnRefreshRewardItemList(IReadOnlyList<RewardItemData> itemList)
	{
		if (this.RefreshItemListVisible())
		{
			this.RefreshItemList();
		}
	}

	// Token: 0x0600E31C RID: 58140 RVA: 0x003D2CC8 File Offset: 0x003D0EC8
	private bool RefreshTitleVisible()
	{
		bool flag = !string.IsNullOrEmpty(this.RewardData.GetRewardInfo().Title);
		base.GetItem(2).SetUIActive(flag);
		return flag;
	}

	// Token: 0x0600E31D RID: 58141 RVA: 0x003D2CFC File Offset: 0x003D0EFC
	private void RefreshTitle()
	{
		string title = this.RewardData.GetRewardInfo().Title;
		if (string.IsNullOrEmpty(title))
		{
			return;
		}
		UUIText text = base.GetText(1);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(text, title, Array.Empty<object>());
	}

	// Token: 0x0600E31E RID: 58142 RVA: 0x003D2D3C File Offset: 0x003D0F3C
	private bool RefreshContinueTextVisible()
	{
		bool flag = !string.IsNullOrEmpty(this.RewardData.GetRewardInfo().ContinueText);
		base.GetText(4).SetUIActive(flag);
		return flag;
	}

	// Token: 0x0600E31F RID: 58143 RVA: 0x003D2D70 File Offset: 0x003D0F70
	private void RefreshContinueText()
	{
		string continueText = this.RewardData.GetRewardInfo().ContinueText;
		if (string.IsNullOrEmpty(continueText))
		{
			return;
		}
		UUIText text = base.GetText(4);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(text, continueText, Array.Empty<object>());
	}

	// Token: 0x0600E320 RID: 58144 RVA: 0x003D2DB0 File Offset: 0x003D0FB0
	private bool RefreshItemListVisible()
	{
		bool isItemVisible = this.RewardData.GetRewardInfo().IsItemVisible;
		List<RewardItemData> itemList = this.RewardData.GetItemList();
		bool flag = isItemVisible && itemList != null && itemList.Count > 0;
		if (this.RewardItemList.GetActive() != flag)
		{
			this.RewardItemList.SetActive(flag);
		}
		return flag;
	}

	// Token: 0x0600E321 RID: 58145 RVA: 0x003D2E06 File Offset: 0x003D1006
	private void RefreshItemList()
	{
		this.RewardItemList.Refresh(this.RewardData.GetItemList());
	}

	// Token: 0x04006D35 RID: 27957
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private RewardData<ICommonRewardInfo> RewardData;

	// Token: 0x04006D36 RID: 27958
	[Nullable(2)]
	private QuestRewardItemList RewardItemList;

	// Token: 0x0200817A RID: 33146
	private static class EChildType
	{
		// Token: 0x0402BF98 RID: 180120
		public const int MaskButton = 0;

		// Token: 0x0402BF99 RID: 180121
		public const int TitleText = 1;

		// Token: 0x0402BF9A RID: 180122
		public const int TitlePanelItem = 2;

		// Token: 0x0402BF9B RID: 180123
		public const int RewardItemListItem = 3;

		// Token: 0x0402BF9C RID: 180124
		public const int ContinueText = 4;
	}
}
