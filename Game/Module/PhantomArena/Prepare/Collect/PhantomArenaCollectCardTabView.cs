using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.PhantomArena.Common.CardItem.Item;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Prepare.Collect
{
	// Token: 0x0200551C RID: 21788
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomArenaCollectCardTabView : UiTabViewBase
	{
		// Token: 0x06037943 RID: 227651 RVA: 0x00E19948 File Offset: 0x00E17B48
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIArtText)),
				new ValueTuple<int, Type>(1, typeof(UUISprite)),
				new ValueTuple<int, Type>(2, typeof(UUIHorizontalLayout)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUILoopScrollViewComponent)),
				new ValueTuple<int, Type>(5, typeof(UUIItem)),
				new ValueTuple<int, Type>(6, typeof(UUIHorizontalLayout)),
				new ValueTuple<int, Type>(7, typeof(UUIText))
			};
		}

		// Token: 0x06037944 RID: 227652 RVA: 0x00E19A10 File Offset: 0x00E17C10
		protected override UniTask OnBeforeStartAsync()
		{
			PhantomArenaCollectCardTabView.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<PhantomArenaCollectCardTabView.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06037945 RID: 227653 RVA: 0x00E19A54 File Offset: 0x00E17C54
		protected override void OnStart()
		{
			this.CardScrollView = new LoopScrollView<CollectGridCardItem, CollectGridCardData>(base.GetLoopScrollViewComponent(4), base.GetItem(5).GetOwner() as AUIBaseActor, new Func<CollectGridCardItem>(this.CreateCardItem), false);
			this.RewardLayout = new GenericLayout<CollectRewardItem, int>(base.GetHorizontalLayout(2), new Func<CollectRewardItem>(this.CreateRewardItem), null, false, true);
			this.ElementLayout = new GenericLayout<CardElementCountItem, CardElementCount>(base.GetHorizontalLayout(6), new Func<CardElementCountItem>(this.CreateElementItem), null, false, true);
			this.InturnAniComponent = (base.GetLoopScrollViewComponent(4).GetContent().GetComponentByClass(UUIInturnAnimController.StaticClass()) as UUIInturnAnimController);
		}

		// Token: 0x06037946 RID: 227654 RVA: 0x00E19AF9 File Offset: 0x00E17CF9
		protected override void OnBeforeShow()
		{
			this.RefreshCard(true);
			this.RefreshElement();
			this.RefreshReward();
		}

		// Token: 0x06037947 RID: 227655 RVA: 0x00E19B10 File Offset: 0x00E17D10
		protected override void OnAfterShow()
		{
			this.UiViewSequence.PlaySequence("Start", false, null);
			UUIInturnAnimController inturnAniComponent = this.InturnAniComponent;
			if (inturnAniComponent == null)
			{
				return;
			}
			inturnAniComponent.Play("", -1, false);
		}

		// Token: 0x06037948 RID: 227656 RVA: 0x00E19B50 File Offset: 0x00E17D50
		protected override void AddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<int>(EEventName.OnPhantomArenaCardRewardUpdate, new Action<int>(this.OnCardRewardUpdate));
			Singleton<EventSystem>.Instance.Add(EEventName.OnPhantomArenaCardUnlock, new Action<int>(this.OnCardInfoUpdate));
			Singleton<EventSystem>.Instance.Add(EEventName.OnPhantomArenaCardOutlookUnlock, new Action<int>(this.OnCardInfoUpdate));
		}

		// Token: 0x06037949 RID: 227657 RVA: 0x00E19BB4 File Offset: 0x00E17DB4
		protected override void RemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnPhantomArenaCardRewardUpdate, new Action<int>(this.OnCardRewardUpdate));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnPhantomArenaCardUnlock, new Action<int>(this.OnCardInfoUpdate));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnPhantomArenaCardOutlookUnlock, new Action<int>(this.OnCardInfoUpdate));
		}

		// Token: 0x0603794A RID: 227658 RVA: 0x00E19C18 File Offset: 0x00E17E18
		private void RefreshCard(bool keepContentPosition)
		{
			List<CollectGridCardData> collectCardDataList = ModelBase<PhantomArenaModel>.Instance.GetCollectCardDataList(this.ActivityId, this.SelectedElementId, false);
			this.CardScrollView.RefreshByData(collectCardDataList, keepContentPosition, null, false);
		}

		// Token: 0x0603794B RID: 227659 RVA: 0x00E19C4C File Offset: 0x00E17E4C
		private void RefreshElement()
		{
			List<CardElementCount> collectCardElementDataList = ModelBase<PhantomArenaModel>.Instance.GetCollectCardElementDataList(this.ActivityId);
			this.ElementLayout.RefreshByData(collectCardElementDataList, delegate
			{
				GenericLayout<CardElementCountItem, CardElementCount> elementLayout = this.ElementLayout;
				if (elementLayout == null)
				{
					return;
				}
				elementLayout.SelectGridProxyByKey(this.SelectedElementId, false);
			}, false);
			if (!ModelBase<PhantomArenaModel>.Instance.IsNewPhantomArenaActivity(this.ActivityId))
			{
				UUIText text = base.GetText(7);
				if (text != null)
				{
					text.SetUIActive(true);
				}
				string multiTextByKey = ConfigBase<TextConfig>.Instance.GetMultiTextByKey("PhantomBattle_1123", "");
				Dictionary<int, int[]> collectCardElementCount = ModelBase<PhantomArenaModel>.Instance.GetCollectCardElementCount(this.ActivityId);
				int[] array = collectCardElementCount.ContainsKey(0) ? collectCardElementCount[0] : null;
				int num = (array != null && array.Length != 0) ? array[0] : 0;
				int num2 = (array != null && array.Length > 1) ? array[1] : 0;
				base.GetText(7).SetText(StringUtils.Format("{0} {1}/{2}", new string[]
				{
					multiTextByKey,
					num.ToString(),
					num2.ToString()
				}), true);
				return;
			}
			UUIText text2 = base.GetText(7);
			if (text2 == null)
			{
				return;
			}
			text2.SetUIActive(false);
		}

		// Token: 0x0603794C RID: 227660 RVA: 0x00E19D4C File Offset: 0x00E17F4C
		private void RefreshReward()
		{
			List<int> cardRewardConfigList = ModelBase<PhantomArenaModel>.Instance.GetCardRewardConfigList(this.ActivityId);
			this.RewardLayout.RefreshByData(cardRewardConfigList, null, false);
			int cardUnlockCount = ModelBase<PhantomArenaModel>.Instance.GetCardUnlockCount(this.ActivityId);
			base.GetArtText(0).SetText(cardUnlockCount.ToString());
			float cardRewardProgress = ModelBase<PhantomArenaModel>.Instance.GetCardRewardProgress(this.ActivityId);
			base.GetSprite(1).SetFillAmount(cardRewardProgress);
		}

		// Token: 0x0603794D RID: 227661 RVA: 0x00E19DBC File Offset: 0x00E17FBC
		private void RequestReward()
		{
			List<int> cardRewardConfigList = ModelBase<PhantomArenaModel>.Instance.GetCardRewardConfigList(this.ActivityId);
			List<int> list = new List<int>();
			foreach (int num in cardRewardConfigList)
			{
				if (ModelBase<PhantomArenaModel>.Instance.GetCardRewardStateById(num) == ECollectRewardState.Finish)
				{
					list.Add(num);
				}
			}
			if (list.Count <= 0)
			{
				return;
			}
			ControllerBase<PhantomArenaController>.Instance.CardRewardRequest(list.ToArray(), this.ActivityId);
		}

		// Token: 0x0603794E RID: 227662 RVA: 0x00E19E50 File Offset: 0x00E18050
		private void OnClickReward(int rewardId, UUIItem root)
		{
			if (ModelBase<PhantomArenaModel>.Instance.GetCardRewardStateById(rewardId) == ECollectRewardState.Finish)
			{
				this.RequestReward();
				return;
			}
			List<RewardTuple> cardRewardPopupTupleData = ModelBase<PhantomArenaModel>.Instance.GetCardRewardPopupTupleData(rewardId);
			RewardPopupData data = new RewardPopupData
			{
				RewardLists = cardRewardPopupTupleData,
				MountItem = root,
				PosBias = new FVector?(new FVector(0f, 30f, 0f))
			};
			this.RewardPopup.Refresh(data);
		}

		// Token: 0x0603794F RID: 227663 RVA: 0x00E19EC0 File Offset: 0x00E180C0
		private void OnClickCard(int cardId)
		{
			CollectCardDetailViewOpenParam param = new CollectCardDetailViewOpenParam
			{
				CardId = cardId,
				ActivityId = this.ActivityId,
				CallbackOnClose = new Action<int>(this.OnCloseDetailView)
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.CollectCardDetailView, param, null);
		}

		// Token: 0x06037950 RID: 227664 RVA: 0x00E19F09 File Offset: 0x00E18109
		private void OnCardRewardUpdate(int activityId)
		{
			this.RefreshReward();
		}

		// Token: 0x06037951 RID: 227665 RVA: 0x00E19F11 File Offset: 0x00E18111
		private void OnCardInfoUpdate(int cardId)
		{
			this.RefreshCard(true);
			this.RefreshElement();
			this.RefreshReward();
		}

		// Token: 0x06037952 RID: 227666 RVA: 0x00E19F26 File Offset: 0x00E18126
		private void OnCloseDetailView(int cardId)
		{
		}

		// Token: 0x06037953 RID: 227667 RVA: 0x00E19F28 File Offset: 0x00E18128
		private CollectGridCardItem CreateCardItem()
		{
			return new CollectGridCardItem
			{
				CallbackOnClick = new Action<int>(this.OnClickCard)
			};
		}

		// Token: 0x06037954 RID: 227668 RVA: 0x00E19F41 File Offset: 0x00E18141
		private CollectRewardItem CreateRewardItem()
		{
			return new CollectRewardItem
			{
				RewardType = ECollectRewardType.Card,
				CallbackClickReward = new Action<int, UUIItem>(this.OnClickReward)
			};
		}

		// Token: 0x06037955 RID: 227669 RVA: 0x00E19F61 File Offset: 0x00E18161
		private CardElementCountItem CreateElementItem()
		{
			return new CardElementCountItem
			{
				SelectCallBack = new Action<int>(this.OnSelectElement)
			};
		}

		// Token: 0x06037956 RID: 227670 RVA: 0x00E19F7A File Offset: 0x00E1817A
		private void OnSelectElement(int elementId)
		{
			this.SelectedElementId = elementId;
			this.RefreshCard(false);
		}

		// Token: 0x06037957 RID: 227671 RVA: 0x00E19F8A File Offset: 0x00E1818A
		protected override void OnBeforeHide()
		{
			this.RewardPopup.SetActive(false);
		}

		// Token: 0x0401FDE6 RID: 130534
		protected int ActivityId;

		// Token: 0x0401FDE7 RID: 130535
		protected LoopScrollView<CollectGridCardItem, CollectGridCardData> CardScrollView;

		// Token: 0x0401FDE8 RID: 130536
		private GenericLayout<CollectRewardItem, int> RewardLayout;

		// Token: 0x0401FDE9 RID: 130537
		private GenericLayout<CardElementCountItem, CardElementCount> ElementLayout;

		// Token: 0x0401FDEA RID: 130538
		private CollectRewardPopup RewardPopup;

		// Token: 0x0401FDEB RID: 130539
		private UUIInturnAnimController InturnAniComponent;

		// Token: 0x0401FDEC RID: 130540
		private int SelectedElementId = -1;

		// Token: 0x0200B4AE RID: 46254
		[NullableContext(0)]
		private static class EComponents
		{
			// Token: 0x04037EE8 RID: 229096
			public const int TextArtNum = 0;

			// Token: 0x04037EE9 RID: 229097
			public const int SpriteBar = 1;

			// Token: 0x04037EEA RID: 229098
			public const int LayoutReward = 2;

			// Token: 0x04037EEB RID: 229099
			public const int PanelReward = 3;

			// Token: 0x04037EEC RID: 229100
			public const int LoopCard = 4;

			// Token: 0x04037EED RID: 229101
			public const int ItemCard = 5;

			// Token: 0x04037EEE RID: 229102
			public const int LayoutElement = 6;

			// Token: 0x04037EEF RID: 229103
			public const int TextPhysical = 7;
		}
	}
}
