using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.ItemReward;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001F5C RID: 8028
public class HonamiWeaponRewardView : UiViewBase
{
	// Token: 0x0600F057 RID: 61527 RVA: 0x0041AF74 File Offset: 0x00419174
	[NullableContext(1)]
	public HonamiWeaponRewardView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600F058 RID: 61528 RVA: 0x0041AF80 File Offset: 0x00419180
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

	// Token: 0x0600F059 RID: 61529 RVA: 0x0041B08C File Offset: 0x0041928C
	protected override void OnStart()
	{
		RewardData<ICommonRewardInfo> rewardData = (RewardData<ICommonRewardInfo>)this.OpenParam;
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

	// Token: 0x0600F05A RID: 61530 RVA: 0x0041B109 File Offset: 0x00419309
	protected override void OnAfterDestroy()
	{
		this.RewardData = null;
	}

	// Token: 0x0600F05B RID: 61531 RVA: 0x0041B112 File Offset: 0x00419312
	protected override void OnBeforeDestroyImplement()
	{
		Action onCloseCallback = this.RewardData.GetRewardInfo().OnCloseCallback;
		if (onCloseCallback != null)
		{
			onCloseCallback();
		}
		ModelBase<ItemRewardModel>.Instance.ClearCurrentRewardData();
	}

	// Token: 0x0600F05C RID: 61532 RVA: 0x0041B139 File Offset: 0x00419339
	private void OnClickedMaskButton()
	{
		base.CloseMe(null);
	}

	// Token: 0x0600F05D RID: 61533 RVA: 0x0041B144 File Offset: 0x00419344
	private bool RefreshTitleVisible()
	{
		bool flag = !StringUtils.IsEmpty(this.RewardData.GetRewardInfo().Title);
		base.GetItem(2).SetUIActive(flag);
		return flag;
	}

	// Token: 0x0600F05E RID: 61534 RVA: 0x0041B178 File Offset: 0x00419378
	private void RefreshTitle()
	{
		string title = this.RewardData.GetRewardInfo().Title;
		if (StringUtils.IsEmpty(title))
		{
			return;
		}
		UUIText text = base.GetText(1);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(text, title, Array.Empty<object>());
	}

	// Token: 0x0600F05F RID: 61535 RVA: 0x0041B1B8 File Offset: 0x004193B8
	private bool RefreshContinueTextVisible()
	{
		bool flag = !StringUtils.IsEmpty(this.RewardData.GetRewardInfo().ContinueText);
		base.GetText(4).SetUIActive(flag);
		return flag;
	}

	// Token: 0x0600F060 RID: 61536 RVA: 0x0041B1EC File Offset: 0x004193EC
	private void RefreshContinueText()
	{
		string continueText = this.RewardData.GetRewardInfo().ContinueText;
		if (StringUtils.IsEmpty(continueText))
		{
			return;
		}
		UUIText text = base.GetText(4);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(text, continueText, Array.Empty<object>());
	}

	// Token: 0x0600F061 RID: 61537 RVA: 0x0041B22C File Offset: 0x0041942C
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

	// Token: 0x0600F062 RID: 61538 RVA: 0x0041B284 File Offset: 0x00419484
	private void RefreshItemList()
	{
		List<RewardItemData> itemList = this.RewardData.GetItemList();
		this.RewardItemList.Refresh(itemList);
	}

	// Token: 0x04007385 RID: 29573
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private RewardData<ICommonRewardInfo> RewardData;

	// Token: 0x04007386 RID: 29574
	[Nullable(2)]
	private QuestRewardItemList RewardItemList;

	// Token: 0x020082E9 RID: 33513
	private enum EChildType
	{
		// Token: 0x0402C62F RID: 181807
		MaskButton,
		// Token: 0x0402C630 RID: 181808
		TitleText,
		// Token: 0x0402C631 RID: 181809
		TitlePanelItem,
		// Token: 0x0402C632 RID: 181810
		RewardItemListItem,
		// Token: 0x0402C633 RID: 181811
		ContinueText
	}
}
