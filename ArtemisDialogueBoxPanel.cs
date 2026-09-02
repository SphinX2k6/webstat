using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020011AD RID: 4525
[NullableContext(1)]
[Nullable(0)]
public class ArtemisDialogueBoxPanel : UiPanelBase
{
	// Token: 0x0600771B RID: 30491 RVA: 0x001F2DF8 File Offset: 0x001F0FF8
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIScrollViewWithScrollbarComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIVerticalLayout)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIScrollbarComponent))
		};
	}

	// Token: 0x0600771C RID: 30492 RVA: 0x001F2EAC File Offset: 0x001F10AC
	protected override UniTask OnBeforeStartAsync()
	{
		ArtemisDialogueBoxPanel.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ArtemisDialogueBoxPanel.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600771D RID: 30493 RVA: 0x001F2EEF File Offset: 0x001F10EF
	protected override void OnStart()
	{
		this.ItemLayout = new GenericLayout<CommonItemSmallItemGrid, TItem>(base.GetHorizontalLayout(4), new Func<CommonItemSmallItemGrid>(this.InitGridItem), null, false, true);
		this.UiScrollView = base.GetScrollViewWithScrollbar(0);
	}

	// Token: 0x0600771E RID: 30494 RVA: 0x001F2F1F File Offset: 0x001F111F
	protected override void OnBeforeDestroy()
	{
		if (this.ScrollTimer != null && this.ScrollTimer.Valid())
		{
			this.ScrollTimer.Remove();
			this.ScrollTimer = null;
		}
	}

	// Token: 0x0600771F RID: 30495 RVA: 0x001F2F49 File Offset: 0x001F1149
	private CommonItemSmallItemGrid InitGridItem()
	{
		return new CommonItemSmallItemGrid
		{
			ShowReceivedCallBack = ((TItem _) => this.IsRewarded)
		};
	}

	// Token: 0x06007720 RID: 30496 RVA: 0x001F2F62 File Offset: 0x001F1162
	public void SetShowRewardItems(bool isShow)
	{
		UUIItem item = base.GetItem(2);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(isShow);
	}

	// Token: 0x06007721 RID: 30497 RVA: 0x001F2F78 File Offset: 0x001F1178
	public void SetRewardItems(List<TItem> rewardItems, bool isRewarded)
	{
		this.IsRewarded = isRewarded;
		GenericLayout<CommonItemSmallItemGrid, TItem> itemLayout = this.ItemLayout;
		if (itemLayout != null)
		{
			itemLayout.SetActive(rewardItems == null || rewardItems.Count != 0);
		}
		if (rewardItems == null || rewardItems.Count == 0)
		{
			return;
		}
		GenericLayout<CommonItemSmallItemGrid, TItem> itemLayout2 = this.ItemLayout;
		if (itemLayout2 == null)
		{
			return;
		}
		itemLayout2.RefreshByData(rewardItems, null, false);
	}

	// Token: 0x06007722 RID: 30498 RVA: 0x001F2FCB File Offset: 0x001F11CB
	public void ShowDialogue(int[] ids, bool isLockStatus, bool isShowEffect)
	{
		ArtemisDialogueParentItem chatParentItem = this.ChatParentItem;
		if (chatParentItem == null)
		{
			return;
		}
		chatParentItem.RefreshChatUiItem(ids, isLockStatus, isShowEffect);
	}

	// Token: 0x06007723 RID: 30499 RVA: 0x001F2FE0 File Offset: 0x001F11E0
	public void ScrollToTop(bool isTop)
	{
		this.IsScrollToTop = isTop;
	}

	// Token: 0x06007724 RID: 30500 RVA: 0x001F2FE9 File Offset: 0x001F11E9
	public void DelayScrollToBotttom()
	{
		this.ScrollTimer = TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
		{
			UUIItem uuiitem;
			if (!this.IsScrollToTop)
			{
				ArtemisDialogueParentItem chatParentItem = this.ChatParentItem;
				uuiitem = ((chatParentItem != null) ? chatParentItem.GetLastItem() : null);
			}
			else
			{
				ArtemisDialogueParentItem chatParentItem2 = this.ChatParentItem;
				uuiitem = ((chatParentItem2 != null) ? chatParentItem2.GetFirstItem() : null);
			}
			UUIItem uuiitem2 = uuiitem;
			if (uuiitem2 != null)
			{
				UUIScrollViewWithScrollbarComponent uiScrollView = this.UiScrollView;
				if (uiScrollView != null)
				{
					uiScrollView.StopMovement();
				}
				this.UiScrollView.ScrollTo(uuiitem2, false);
			}
		}, 100f, null, null, true, 1f);
	}

	// Token: 0x06007725 RID: 30501 RVA: 0x001F3014 File Offset: 0x001F1214
	public void PlayFixDoneSequence()
	{
		ArtemisDialogueParentItem chatParentItem = this.ChatParentItem;
		if (chatParentItem == null)
		{
			return;
		}
		chatParentItem.LeftPlayFixDoneLevelSequence();
	}

	// Token: 0x0400398B RID: 14731
	[Nullable(2)]
	private ArtemisDialogueParentItem ChatParentItem;

	// Token: 0x0400398C RID: 14732
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<CommonItemSmallItemGrid, TItem> ItemLayout;

	// Token: 0x0400398D RID: 14733
	private bool IsRewarded;

	// Token: 0x0400398E RID: 14734
	[Nullable(2)]
	private TimerHandle ScrollTimer;

	// Token: 0x0400398F RID: 14735
	private bool IsScrollToTop;

	// Token: 0x04003990 RID: 14736
	public UUIScrollViewWithScrollbarComponent UiScrollView;

	// Token: 0x02007506 RID: 29958
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x0402866F RID: 165487
		public const int ChatView = 0;

		// Token: 0x04028670 RID: 165488
		public const int DiglogueItem = 1;

		// Token: 0x04028671 RID: 165489
		public const int PnlReward = 2;

		// Token: 0x04028672 RID: 165490
		public const int RewardTitle = 3;

		// Token: 0x04028673 RID: 165491
		public const int RewardItemLayout = 4;

		// Token: 0x04028674 RID: 165492
		public const int RewardItem = 5;

		// Token: 0x04028675 RID: 165493
		public const int ChatScrollBar = 6;
	}
}
