using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.PhantomArena.Prepare.DeckBuilder;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Prepare.Collect
{
	// Token: 0x02005516 RID: 21782
	[NullableContext(1)]
	[Nullable(0)]
	public class CollectCardDetailView : UiViewBase
	{
		// Token: 0x06037901 RID: 227585 RVA: 0x00E186B5 File Offset: 0x00E168B5
		public CollectCardDetailView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x06037902 RID: 227586 RVA: 0x00E186E0 File Offset: 0x00E168E0
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUILayoutBase)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(3, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(2, new Action(this.OnClickLeft)),
				new ValueTuple<int, Delegate>(3, new Action(this.OnClickRight))
			};
		}

		// Token: 0x06037903 RID: 227587 RVA: 0x00E187B8 File Offset: 0x00E169B8
		protected override UniTask OnBeforeStartAsync()
		{
			CollectCardDetailView.<OnBeforeStartAsync>d__12 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<CollectCardDetailView.<OnBeforeStartAsync>d__12>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06037904 RID: 227588 RVA: 0x00E187FB File Offset: 0x00E169FB
		private CollectCardDetailTabItem CreateTabItem()
		{
			return new CollectCardDetailTabItem
			{
				CallbackOnClick = new Action<ECollectCardDetailViewTab>(this.OnClickTab)
			};
		}

		// Token: 0x06037905 RID: 227589 RVA: 0x00E18814 File Offset: 0x00E16A14
		protected override void OnStart()
		{
			if (this.DataList.Count <= 0)
			{
				Singleton<Log>.Instance.Error(ELogModule.PhantomArena, ELogAuthor.WDX, "获取卡牌图鉴数据错误", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			if (this.CardId < 0 || this.CardIndex < 0)
			{
				this.CardIndex = 0;
				this.CardId = this.DataList[0].CardId;
			}
			this.RefreshTabView();
			this.TabIndex = 0;
			this.TabLayout.SelectGridProxyByKey((ECollectCardDetailViewTab)this.TabIndex, true);
		}

		// Token: 0x06037906 RID: 227590 RVA: 0x00E188A2 File Offset: 0x00E16AA2
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnPhantomArenaCardUnlock, new Action<int>(this.OnUnlockCard));
			Singleton<EventSystem>.Instance.Add(EEventName.OnPhantomArenaCardOutlookUnlock, new Action<int>(this.OnUnlockOutlook));
		}

		// Token: 0x06037907 RID: 227591 RVA: 0x00E188DC File Offset: 0x00E16ADC
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnPhantomArenaCardUnlock, new Action<int>(this.OnUnlockCard));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnPhantomArenaCardOutlookUnlock, new Action<int>(this.OnUnlockOutlook));
		}

		// Token: 0x06037908 RID: 227592 RVA: 0x00E18918 File Offset: 0x00E16B18
		private void RefreshTabView()
		{
			CollectCardDetailPanel detailPanel = this.DetailPanel;
			if (detailPanel != null)
			{
				detailPanel.Refresh(this.CardId);
			}
			DeckBuilderCardOutlookUnlockPanelData data = new DeckBuilderCardOutlookUnlockPanelData
			{
				CardId = this.CardId
			};
			DeckBuilderCardOutlookUnlockPanel outlookPanel = this.OutlookPanel;
			if (outlookPanel == null)
			{
				return;
			}
			outlookPanel.Refresh(data);
		}

		// Token: 0x06037909 RID: 227593 RVA: 0x00E1895F File Offset: 0x00E16B5F
		private void RefreshSwitchSequence()
		{
			if (this.TabIndex == 0)
			{
				CollectCardDetailPanel detailPanel = this.DetailPanel;
				if (detailPanel == null)
				{
					return;
				}
				detailPanel.PlaySwitchSequence();
				return;
			}
			else
			{
				DeckBuilderCardOutlookUnlockPanel outlookPanel = this.OutlookPanel;
				if (outlookPanel == null)
				{
					return;
				}
				outlookPanel.PlaySwitchSequence();
				return;
			}
		}

		// Token: 0x0603790A RID: 227594 RVA: 0x00E1898C File Offset: 0x00E16B8C
		private void SetTabViewState(ECollectCardDetailViewTab index, bool activeState)
		{
			if (index == ECollectCardDetailViewTab.Detail)
			{
				CollectCardDetailPanel detailPanel = this.DetailPanel;
				if (detailPanel != null)
				{
					detailPanel.SetActive(activeState);
				}
				if (activeState)
				{
					CollectCardDetailPanel detailPanel2 = this.DetailPanel;
					if (detailPanel2 == null)
					{
						return;
					}
					detailPanel2.PlayShowSequence();
					return;
				}
			}
			else
			{
				DeckBuilderCardOutlookUnlockPanel outlookPanel = this.OutlookPanel;
				if (outlookPanel != null)
				{
					outlookPanel.SetActive(activeState);
				}
				if (activeState)
				{
					DeckBuilderCardOutlookUnlockPanel outlookPanel2 = this.OutlookPanel;
					if (outlookPanel2 == null)
					{
						return;
					}
					outlookPanel2.PlayShowSequence();
				}
			}
		}

		// Token: 0x0603790B RID: 227595 RVA: 0x00E189E7 File Offset: 0x00E16BE7
		private void OnClickTab(ECollectCardDetailViewTab index)
		{
			if (this.TabIndex >= 0)
			{
				this.SetTabViewState((ECollectCardDetailViewTab)this.TabIndex, false);
			}
			this.TabIndex = (int)index;
			this.TabLayout.SelectGridProxy(this.TabIndex, false);
			this.SetTabViewState((ECollectCardDetailViewTab)this.TabIndex, true);
		}

		// Token: 0x0603790C RID: 227596 RVA: 0x00E18A28 File Offset: 0x00E16C28
		private void OnClickLeft()
		{
			int cardIndex = (this.CardIndex - 1 + this.DataList.Count) % this.DataList.Count;
			this.CardIndex = cardIndex;
			this.CardId = this.DataList[this.CardIndex].CardId;
			this.RefreshTabView();
			this.RefreshSwitchSequence();
		}

		// Token: 0x0603790D RID: 227597 RVA: 0x00E18A88 File Offset: 0x00E16C88
		private void OnClickRight()
		{
			int cardIndex = (this.CardIndex + 1) % this.DataList.Count;
			this.CardIndex = cardIndex;
			this.CardId = this.DataList[this.CardIndex].CardId;
			this.RefreshTabView();
			this.RefreshSwitchSequence();
		}

		// Token: 0x0603790E RID: 227598 RVA: 0x00E18AD9 File Offset: 0x00E16CD9
		private void OnClickClose()
		{
			base.CloseMe(new Action<bool>(this.OnCloseSuccess));
		}

		// Token: 0x0603790F RID: 227599 RVA: 0x00E18AED File Offset: 0x00E16CED
		private void OnCloseSuccess(bool result)
		{
			if (this.CallbackOnClose != null)
			{
				this.CallbackOnClose(this.CardId);
			}
		}

		// Token: 0x06037910 RID: 227600 RVA: 0x00E18B08 File Offset: 0x00E16D08
		private void OnUnlockCard(int cardId)
		{
			if (cardId == this.CardId)
			{
				this.RefreshTabView();
				this.RefreshSwitchSequence();
			}
		}

		// Token: 0x06037911 RID: 227601 RVA: 0x00E18B1F File Offset: 0x00E16D1F
		private void OnUnlockOutlook(int cardId)
		{
			if (cardId == this.CardId)
			{
				this.RefreshTabView();
				this.RefreshSwitchSequence();
			}
		}

		// Token: 0x0401FDCA RID: 130506
		private int CardId = -1;

		// Token: 0x0401FDCB RID: 130507
		private int ActivityId;

		// Token: 0x0401FDCC RID: 130508
		private int CardIndex = -1;

		// Token: 0x0401FDCD RID: 130509
		private int TabIndex = -1;

		// Token: 0x0401FDCE RID: 130510
		private List<CollectGridCardData> DataList = new List<CollectGridCardData>();

		// Token: 0x0401FDCF RID: 130511
		private CollectCardDetailPanel DetailPanel;

		// Token: 0x0401FDD0 RID: 130512
		private DeckBuilderCardOutlookUnlockPanel OutlookPanel;

		// Token: 0x0401FDD1 RID: 130513
		private PopupCaptionItem CaptionItem;

		// Token: 0x0401FDD2 RID: 130514
		private GenericLayout<CollectCardDetailTabItem, CollectCardDetailViewTabData> TabLayout;

		// Token: 0x0401FDD3 RID: 130515
		private Action<int> CallbackOnClose;

		// Token: 0x0200B4A4 RID: 46244
		[NullableContext(0)]
		private static class EComponents
		{
			// Token: 0x04037EB3 RID: 229043
			public const int TabLayout = 0;

			// Token: 0x04037EB4 RID: 229044
			public const int CaptionItem = 1;

			// Token: 0x04037EB5 RID: 229045
			public const int LeftArrowButton = 2;

			// Token: 0x04037EB6 RID: 229046
			public const int RightArrowButton = 3;

			// Token: 0x04037EB7 RID: 229047
			public const int ContentItem = 4;

			// Token: 0x04037EB8 RID: 229048
			public const int ItemTabPanel = 5;
		}
	}
}
