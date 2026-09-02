using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.ItemReward
{
	// Token: 0x02005B48 RID: 23368
	[NullableContext(1)]
	[Nullable(0)]
	public class CommonRewardComponent
	{
		// Token: 0x0603B19E RID: 242078 RVA: 0x00EF405A File Offset: 0x00EF225A
		public CommonRewardComponent(ICommonRewardComponentUiAccessor uiAccessor, ICommonRewardComponentChildType childType, [Nullable(2)] ICommonRewardComponentCallbacks callbacks = null)
		{
			this.UiAccessor = uiAccessor;
			this.ChildType = childType;
			this.Callbacks = callbacks;
		}

		// Token: 0x0603B19F RID: 242079 RVA: 0x00EF4078 File Offset: 0x00EF2278
		public UniTask InitializeAsync(EUiViewName? viewName = null)
		{
			CommonRewardComponent.<InitializeAsync>d__13 <InitializeAsync>d__;
			<InitializeAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitializeAsync>d__.<>4__this = this;
			<InitializeAsync>d__.viewName = viewName;
			<InitializeAsync>d__.<>1__state = -1;
			<InitializeAsync>d__.<>t__builder.Start<CommonRewardComponent.<InitializeAsync>d__13>(ref <InitializeAsync>d__);
			return <InitializeAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603B1A0 RID: 242080 RVA: 0x00EF40C3 File Offset: 0x00EF22C3
		public void AddEventListener()
		{
			this.EventListenStatus = true;
			Singleton<EventSystem>.Instance.Add<IReadOnlyList<RewardItemData>>(EEventName.OnRefreshRewardViewItemList, new Action<IReadOnlyList<RewardItemData>>(this.OnRefreshRewardItemList));
			Singleton<EventSystem>.Instance.Add<EUiTabViewName, int?>(EEventName.ChangeChildView, new Action<EUiTabViewName, int?>(this.OnChangeChildView));
		}

		// Token: 0x0603B1A1 RID: 242081 RVA: 0x00EF4104 File Offset: 0x00EF2304
		public void RemoveEventListener()
		{
			if (!this.EventListenStatus)
			{
				return;
			}
			this.EventListenStatus = false;
			Singleton<EventSystem>.Instance.Remove(EEventName.OnRefreshRewardViewItemList, new Action<IReadOnlyList<RewardItemData>>(this.OnRefreshRewardItemList));
			Singleton<EventSystem>.Instance.Remove(EEventName.ChangeChildView, new Action<EUiTabViewName, int?>(this.OnChangeChildView));
		}

		// Token: 0x0603B1A2 RID: 242082 RVA: 0x00EF4156 File Offset: 0x00EF2356
		public void Refresh(RewardData<ICommonRewardInfo> rewardData)
		{
			this.RewardData = rewardData;
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
			this.RefreshButton(rewardData);
		}

		// Token: 0x0603B1A3 RID: 242083 RVA: 0x00EF4190 File Offset: 0x00EF2390
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public RewardData<ICommonRewardInfo> GetRewardData()
		{
			return this.RewardData;
		}

		// Token: 0x0603B1A4 RID: 242084 RVA: 0x00EF4198 File Offset: 0x00EF2398
		[NullableContext(2)]
		public ICommonRewardInfo GetRewardInfo()
		{
			RewardData<ICommonRewardInfo> rewardData = this.RewardData;
			if (rewardData == null)
			{
				return null;
			}
			return rewardData.GetRewardInfo();
		}

		// Token: 0x0603B1A5 RID: 242085 RVA: 0x00EF41AC File Offset: 0x00EF23AC
		public bool HasButtons()
		{
			RewardData<ICommonRewardInfo> rewardData = this.RewardData;
			ICommonRewardInfo commonRewardInfo = (rewardData != null) ? rewardData.GetRewardInfo() : null;
			return commonRewardInfo != null && commonRewardInfo.LeftBtnTextId != null && commonRewardInfo != null && commonRewardInfo.RightBtnTextId != null;
		}

		// Token: 0x0603B1A6 RID: 242086 RVA: 0x00EF41E8 File Offset: 0x00EF23E8
		public void HandleCloseCallback()
		{
			RewardData<ICommonRewardInfo> rewardData = this.RewardData;
			ICommonRewardInfo commonRewardInfo = (rewardData != null) ? rewardData.GetRewardInfo() : null;
			Action action = (commonRewardInfo != null) ? commonRewardInfo.OnCloseCallback : null;
			if (action != null)
			{
				action();
			}
		}

		// Token: 0x0603B1A7 RID: 242087 RVA: 0x00EF421D File Offset: 0x00EF241D
		public void Destroy()
		{
			this.RemoveEventListener();
			this.RewardItemLoopList = null;
			this.RewardItemList = null;
			this.LeftButton = null;
			this.RightButton = null;
			this.RewardData = null;
			this.ViewName = null;
		}

		// Token: 0x0603B1A8 RID: 242088 RVA: 0x00EF4254 File Offset: 0x00EF2454
		private bool RefreshTitleVisible()
		{
			bool flag = !StringUtils.IsEmpty(this.RewardData.GetRewardInfo().Title);
			this.UiAccessor.GetItemForComponent(this.ChildType.TitlePanelItem).SetUIActive(flag);
			return flag;
		}

		// Token: 0x0603B1A9 RID: 242089 RVA: 0x00EF4298 File Offset: 0x00EF2498
		private void RefreshTitle()
		{
			string title = this.RewardData.GetRewardInfo().Title;
			if (StringUtils.IsEmpty(title))
			{
				return;
			}
			UUIText textForComponent = this.UiAccessor.GetTextForComponent(this.ChildType.TitleText);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(textForComponent, title, Array.Empty<object>());
		}

		// Token: 0x0603B1AA RID: 242090 RVA: 0x00EF42E8 File Offset: 0x00EF24E8
		private bool RefreshContinueTextVisible()
		{
			ICommonRewardInfo rewardInfo = this.RewardData.GetRewardInfo();
			bool flag = !StringUtils.IsEmpty(rewardInfo.ContinueText);
			flag = (flag && rewardInfo.LeftBtnTextId == null && rewardInfo.RightBtnTextId == null);
			this.UiAccessor.GetItemForComponent(this.ChildType.ContinueText).SetUIActive(flag);
			return flag;
		}

		// Token: 0x0603B1AB RID: 242091 RVA: 0x00EF4348 File Offset: 0x00EF2548
		private void RefreshContinueText()
		{
			string continueText = this.RewardData.GetRewardInfo().ContinueText;
			if (StringUtils.IsEmpty(continueText))
			{
				return;
			}
			UUIText textForComponent = this.UiAccessor.GetTextForComponent(this.ChildType.ContinueText);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(textForComponent, continueText, Array.Empty<object>());
		}

		// Token: 0x0603B1AC RID: 242092 RVA: 0x00EF4398 File Offset: 0x00EF2598
		private bool RefreshItemListVisible()
		{
			bool isItemVisible = this.RewardData.GetRewardInfo().IsItemVisible;
			List<RewardItemData> itemList = this.RewardData.GetItemList();
			bool flag = isItemVisible && itemList != null && itemList != null && itemList.Count > 0;
			if (this.RewardItemList.GetActive() != flag)
			{
				this.RewardItemList.SetActive(flag);
			}
			return flag;
		}

		// Token: 0x0603B1AD RID: 242093 RVA: 0x00EF43F4 File Offset: 0x00EF25F4
		private int CalcMaxCountPerRow()
		{
			float x = this.UiAccessor.GetGridLayoutForComponent(this.ChildType.ListContentItem).GetCellSize().X;
			return (int)Math.Floor((double)(this.UiAccessor.GetGridLayoutForComponent(this.ChildType.ListContentItem).RootUIComp.Get().GetWidth() / x)) * 2;
		}

		// Token: 0x0603B1AE RID: 242094 RVA: 0x00EF4458 File Offset: 0x00EF2658
		private void RefreshItemList()
		{
			if (this.RewardData == null || this.RewardItemList == null || this.RewardItemLoopList == null)
			{
				return;
			}
			if (this.RewardData.GetItemList().Count < this.CalcMaxCountPerRow())
			{
				this.RewardItemList.Show(null);
				this.RewardItemLoopList.Hide(null);
				this.RewardItemList.Refresh(this.RewardData.GetItemList(), this.RewardData.GetRewardInfo().TipsCanSkip.GetValueOrDefault(true));
				return;
			}
			this.RewardItemList.Hide(null);
			this.RewardItemLoopList.Show(null);
			this.RewardItemLoopList.Refresh(this.RewardData.GetItemList(), this.RewardData.GetRewardInfo().TipsCanSkip.GetValueOrDefault(true));
		}

		// Token: 0x0603B1AF RID: 242095 RVA: 0x00EF4528 File Offset: 0x00EF2728
		private void RefreshButton(RewardData<ICommonRewardInfo> rewardData)
		{
			ICommonRewardInfo rewardInfo = rewardData.GetRewardInfo();
			if (!string.IsNullOrEmpty((rewardInfo != null) ? rewardInfo.LeftBtnTextId : null))
			{
				ButtonItem leftButton = this.LeftButton;
				if (leftButton != null)
				{
					leftButton.SetShowText(rewardInfo.LeftBtnTextId);
				}
				ButtonItem leftButton2 = this.LeftButton;
				if (leftButton2 != null)
				{
					leftButton2.SetUiActive(true);
				}
			}
			else
			{
				ButtonItem leftButton3 = this.LeftButton;
				if (leftButton3 != null)
				{
					leftButton3.SetUiActive(false);
				}
			}
			if (!string.IsNullOrEmpty((rewardInfo != null) ? rewardInfo.RightBtnTextId : null))
			{
				ButtonItem rightButton = this.RightButton;
				if (rightButton != null)
				{
					rightButton.SetShowText(rewardInfo.RightBtnTextId);
				}
				ButtonItem rightButton2 = this.RightButton;
				if (rightButton2 != null)
				{
					rightButton2.SetUiActive(true);
				}
			}
			else
			{
				ButtonItem rightButton3 = this.RightButton;
				if (rightButton3 != null)
				{
					rightButton3.SetUiActive(false);
				}
			}
			if (rewardInfo != null && rewardInfo.DisableMaskClose.GetValueOrDefault())
			{
				UUIButtonComponent maskButton = this.MaskButton;
				if (maskButton == null)
				{
					return;
				}
				maskButton.RootUIComp.Get().SetUIActive(false);
				return;
			}
			else
			{
				UUIButtonComponent maskButton2 = this.MaskButton;
				if (maskButton2 == null)
				{
					return;
				}
				maskButton2.RootUIComp.Get().SetUIActive(true);
				return;
			}
		}

		// Token: 0x0603B1B0 RID: 242096 RVA: 0x00EF462C File Offset: 0x00EF282C
		private void OnRefreshRewardItemList(IReadOnlyList<RewardItemData> itemList)
		{
			if (this.RefreshItemListVisible())
			{
				this.RefreshItemList();
			}
		}

		// Token: 0x0603B1B1 RID: 242097 RVA: 0x00EF463C File Offset: 0x00EF283C
		public void OnRefreshRewardView(IRewardDataInterface rewardData)
		{
			RewardData<ICommonRewardInfo> rewardData2 = rewardData as RewardData<ICommonRewardInfo>;
			if (rewardData2 == null)
			{
				return;
			}
			ICommonRewardInfo rewardInfo = rewardData2.GetRewardInfo();
			if (rewardInfo.Type != ERewardInfoType.Common)
			{
				return;
			}
			if (this.ViewName != null && rewardInfo.ViewName != this.ViewName)
			{
				return;
			}
			if (this.Callbacks != null)
			{
				this.Callbacks.OnRefreshView();
			}
			this.Refresh(rewardData2);
		}

		// Token: 0x0603B1B2 RID: 242098 RVA: 0x00EF46B6 File Offset: 0x00EF28B6
		private void OnChangeChildView(EUiTabViewName eUiTabViewName, int? o)
		{
			this.OnClickMaskButton();
		}

		// Token: 0x0603B1B3 RID: 242099 RVA: 0x00EF46C0 File Offset: 0x00EF28C0
		public void OnClickMaskButton()
		{
			RewardData<ICommonRewardInfo> rewardData = this.RewardData;
			ICommonRewardInfo commonRewardInfo = (rewardData != null) ? rewardData.GetRewardInfo() : null;
			if (commonRewardInfo != null && commonRewardInfo.DisableMaskClose.GetValueOrDefault())
			{
				return;
			}
			if (this.HasButtons())
			{
				return;
			}
			if (this.Callbacks != null)
			{
				this.Callbacks.OnCloseView();
			}
		}

		// Token: 0x0603B1B4 RID: 242100 RVA: 0x00EF4712 File Offset: 0x00EF2912
		private void OnClickLeftButton(int _)
		{
			RewardData<ICommonRewardInfo> rewardData = this.RewardData;
			ICommonRewardInfo commonRewardInfo = (rewardData != null) ? rewardData.GetRewardInfo() : null;
			if (commonRewardInfo != null)
			{
				Action leftAction = commonRewardInfo.LeftAction;
				if (leftAction != null)
				{
					leftAction();
				}
			}
			if (this.Callbacks != null)
			{
				this.Callbacks.OnCloseView();
			}
		}

		// Token: 0x0603B1B5 RID: 242101 RVA: 0x00EF474F File Offset: 0x00EF294F
		private void OnClickRightButton(int _)
		{
			RewardData<ICommonRewardInfo> rewardData = this.RewardData;
			ICommonRewardInfo commonRewardInfo = (rewardData != null) ? rewardData.GetRewardInfo() : null;
			if (commonRewardInfo != null)
			{
				Action rightAction = commonRewardInfo.RightAction;
				if (rightAction != null)
				{
					rightAction();
				}
			}
			if (this.Callbacks != null)
			{
				this.Callbacks.OnCloseView();
			}
		}

		// Token: 0x0402154C RID: 136524
		private const int MAXROWCNT = 2;

		// Token: 0x0402154D RID: 136525
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private RewardData<ICommonRewardInfo> RewardData;

		// Token: 0x0402154E RID: 136526
		[Nullable(2)]
		private RewardItemList RewardItemList;

		// Token: 0x0402154F RID: 136527
		[Nullable(2)]
		private ButtonItem LeftButton;

		// Token: 0x04021550 RID: 136528
		[Nullable(2)]
		private ButtonItem RightButton;

		// Token: 0x04021551 RID: 136529
		[Nullable(2)]
		private UUIButtonComponent MaskButton;

		// Token: 0x04021552 RID: 136530
		[Nullable(2)]
		private RewardItemLoopList RewardItemLoopList;

		// Token: 0x04021553 RID: 136531
		private readonly ICommonRewardComponentUiAccessor UiAccessor;

		// Token: 0x04021554 RID: 136532
		private readonly ICommonRewardComponentChildType ChildType;

		// Token: 0x04021555 RID: 136533
		private readonly ICommonRewardComponentCallbacks Callbacks;

		// Token: 0x04021556 RID: 136534
		private EUiViewName? ViewName;

		// Token: 0x04021557 RID: 136535
		private bool EventListenStatus;
	}
}
