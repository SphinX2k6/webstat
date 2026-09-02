using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Activity.ActivityContent.PrizeDrawing.Components;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.PrizeDrawing
{
	// Token: 0x02006563 RID: 25955
	[NullableContext(1)]
	[Nullable(0)]
	public class PrizeDrawingMainView : UiTickViewBase
	{
		// Token: 0x17009E9E RID: 40606
		// (get) Token: 0x06040D75 RID: 265589 RVA: 0x010A0B7A File Offset: 0x0109ED7A
		private ActivityPrizeDrawingData Data
		{
			get
			{
				return ControllerBase<ActivityPrizeDrawingController>.Instance.ActivityData;
			}
		}

		// Token: 0x06040D76 RID: 265590 RVA: 0x010A0B86 File Offset: 0x0109ED86
		public PrizeDrawingMainView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06040D77 RID: 265591 RVA: 0x010A0BA8 File Offset: 0x0109EDA8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 20;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
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
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(17, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(18, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(19, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06040D78 RID: 265592 RVA: 0x010A0E70 File Offset: 0x0109F070
		protected override UniTask OnBeforeStartAsync()
		{
			PrizeDrawingMainView.<OnBeforeStartAsync>d__13 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<PrizeDrawingMainView.<OnBeforeStartAsync>d__13>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06040D79 RID: 265593 RVA: 0x010A0EB3 File Offset: 0x0109F0B3
		protected override void OnStart()
		{
			this.RefreshCaption();
			this.RefreshRewardList(true);
			this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
			this.LevelSequencePlayer.BindSequenceCloseEvent(new TSequenceEndEvent(this.OnSequenceCloseEvent), false);
		}

		// Token: 0x06040D7A RID: 265594 RVA: 0x010A0EEB File Offset: 0x0109F0EB
		private void RefreshView()
		{
			this.RefreshRewardList(false);
			this.RefreshProgress();
			this.RefreshTime();
			this.RefreshButton();
			this.RefreshQuest();
		}

		// Token: 0x06040D7B RID: 265595 RVA: 0x010A0F0C File Offset: 0x0109F10C
		protected override void OnBeforeShow()
		{
			base.OnBeforeShow();
			this.RefreshView();
		}

		// Token: 0x06040D7C RID: 265596 RVA: 0x010A0F1A File Offset: 0x0109F11A
		protected override void OnBeforeDestroy()
		{
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer == null)
			{
				return;
			}
			levelSequencePlayer.Clear();
		}

		// Token: 0x06040D7D RID: 265597 RVA: 0x010A0F2C File Offset: 0x0109F12C
		protected override void OnTick(float delta)
		{
			this.RefreshTime();
		}

		// Token: 0x06040D7E RID: 265598 RVA: 0x010A0F34 File Offset: 0x0109F134
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<EUiViewName, int>(EEventName.CloseView, new Action<EUiViewName, int>(this.OnCloseView));
			Singleton<EventSystem>.Instance.Add(EEventName.OnPrizeDrawingRewardStatusChanged, new Action(this.OnRewardStatusChanged));
			Singleton<EventSystem>.Instance.Add(EEventName.OnPrizeDrawingQuestUpdated, new Action(this.OnPrizeDrawingQuestUpdated));
			Singleton<EventSystem>.Instance.Add<string>(EEventName.OnActivitySequenceEmitEvent, new Action<string>(this.OnOpenAnimationEvent));
		}

		// Token: 0x06040D7F RID: 265599 RVA: 0x010A0FB0 File Offset: 0x0109F1B0
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove<EUiViewName, int>(EEventName.CloseView, new Action<EUiViewName, int>(this.OnCloseView));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnPrizeDrawingRewardStatusChanged, new Action(this.OnRewardStatusChanged));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnPrizeDrawingQuestUpdated, new Action(this.OnPrizeDrawingQuestUpdated));
			Singleton<EventSystem>.Instance.Remove<string>(EEventName.OnActivitySequenceEmitEvent, new Action<string>(this.OnOpenAnimationEvent));
		}

		// Token: 0x06040D80 RID: 265600 RVA: 0x010A102A File Offset: 0x0109F22A
		private void OnOpenAnimationEvent(string param)
		{
			if (param == "Guide")
			{
				this.RefreshButtonAnimation();
			}
		}

		// Token: 0x06040D81 RID: 265601 RVA: 0x010A103F File Offset: 0x0109F23F
		private void OnSequenceCloseEvent(string seqName)
		{
			if (seqName == "TransIn")
			{
				this.RefreshButtonAnimation();
			}
		}

		// Token: 0x06040D82 RID: 265602 RVA: 0x010A1054 File Offset: 0x0109F254
		private void RefreshButtonAnimation()
		{
			if (this.Data.ShouldShowButtonRedDot())
			{
				LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
				if (levelSequencePlayer == null)
				{
					return;
				}
				levelSequencePlayer.PlayOrReplaySequenceByName("GuideLoop", false, null);
				return;
			}
			else
			{
				LevelSequencePlayer levelSequencePlayer2 = this.LevelSequencePlayer;
				if (levelSequencePlayer2 == null)
				{
					return;
				}
				levelSequencePlayer2.PlaySequencePurely("GuideDefault", false, false, null, null, false);
				return;
			}
		}

		// Token: 0x06040D83 RID: 265603 RVA: 0x010A10B0 File Offset: 0x0109F2B0
		private void OnRewardStatusChanged()
		{
			this.IsRewardStatusChanged = true;
			this.RefreshButton();
			this.RefreshProgress();
		}

		// Token: 0x06040D84 RID: 265604 RVA: 0x010A10C8 File Offset: 0x0109F2C8
		private void OnCloseView(EUiViewName viewName, int viewId)
		{
			if (viewName == EUiViewName.PrizeDrawingTearView)
			{
				if (this.IsRewardStatusChanged)
				{
					this.RefreshRewardList(false);
					this.IsRewardStatusChanged = false;
				}
				LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
				if (levelSequencePlayer == null)
				{
					return;
				}
				levelSequencePlayer.PlaySequencePurely("TransIn", true, false, null, null, false);
			}
		}

		// Token: 0x06040D85 RID: 265605 RVA: 0x010A111A File Offset: 0x0109F31A
		private void OnPrizeDrawingQuestUpdated()
		{
			this.RefreshView();
		}

		// Token: 0x06040D86 RID: 265606 RVA: 0x010A1124 File Offset: 0x0109F324
		private UniTask CreateRewardList()
		{
			PrizeDrawingMainView.<CreateRewardList>d__27 <CreateRewardList>d__;
			<CreateRewardList>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateRewardList>d__.<>4__this = this;
			<CreateRewardList>d__.<>1__state = -1;
			<CreateRewardList>d__.<>t__builder.Start<PrizeDrawingMainView.<CreateRewardList>d__27>(ref <CreateRewardList>d__);
			return <CreateRewardList>d__.<>t__builder.Task;
		}

		// Token: 0x06040D87 RID: 265607 RVA: 0x010A1168 File Offset: 0x0109F368
		private UniTask CreateFinalRewardItem(PrizeDrawingMainView.EComp itemIndex, int itemId, int count)
		{
			PrizeDrawingMainView.<CreateFinalRewardItem>d__28 <CreateFinalRewardItem>d__;
			<CreateFinalRewardItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateFinalRewardItem>d__.<>4__this = this;
			<CreateFinalRewardItem>d__.itemIndex = itemIndex;
			<CreateFinalRewardItem>d__.itemId = itemId;
			<CreateFinalRewardItem>d__.count = count;
			<CreateFinalRewardItem>d__.<>1__state = -1;
			<CreateFinalRewardItem>d__.<>t__builder.Start<PrizeDrawingMainView.<CreateFinalRewardItem>d__28>(ref <CreateFinalRewardItem>d__);
			return <CreateFinalRewardItem>d__.<>t__builder.Task;
		}

		// Token: 0x06040D88 RID: 265608 RVA: 0x010A11C4 File Offset: 0x0109F3C4
		private UniTask CreateRewardItem(PrizeDrawingMainView.EComp itemIndex, int itemId, int count, int maxAmount)
		{
			PrizeDrawingMainView.<CreateRewardItem>d__29 <CreateRewardItem>d__;
			<CreateRewardItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateRewardItem>d__.<>4__this = this;
			<CreateRewardItem>d__.itemIndex = itemIndex;
			<CreateRewardItem>d__.itemId = itemId;
			<CreateRewardItem>d__.count = count;
			<CreateRewardItem>d__.maxAmount = maxAmount;
			<CreateRewardItem>d__.<>1__state = -1;
			<CreateRewardItem>d__.<>t__builder.Start<PrizeDrawingMainView.<CreateRewardItem>d__29>(ref <CreateRewardItem>d__);
			return <CreateRewardItem>d__.<>t__builder.Task;
		}

		// Token: 0x06040D89 RID: 265609 RVA: 0x010A1228 File Offset: 0x0109F428
		private void RefreshRewardList(bool animBanned = false)
		{
			IReadOnlyList<KujiAwardsGroup> allAwardGroup = this.Data.GetAllAwardGroup();
			for (int i = 0; i < this.FinalRewardItemList.Count; i++)
			{
				this.FinalRewardItemList[i].Refresh(this.Data.IsGotAward(allAwardGroup[i].Id), animBanned);
			}
			for (int j = 0; j < this.RewardItemList.Count; j++)
			{
				this.RewardItemList[j].Refresh(this.Data.GetAwardCurrentAmount(allAwardGroup[j + this.FinalRewardItemList.Count].Id), animBanned);
			}
		}

		// Token: 0x06040D8A RID: 265610 RVA: 0x010A12D4 File Offset: 0x0109F4D4
		private void RefreshCaption()
		{
			this.CaptionItem.SetTitleLocalText(this.Data.GetTitleTextId());
			this.CaptionItem.SetCloseCallBack(new Action(this.OnCloseCallback));
			PopupCaptionItem captionItem = this.CaptionItem;
			if (captionItem == null)
			{
				return;
			}
			captionItem.SetCurrencyItemList(new int[]
			{
				this.Data.GetCostCoinId()
			});
		}

		// Token: 0x06040D8B RID: 265611 RVA: 0x010A1334 File Offset: 0x0109F534
		private void RefreshProgress()
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(11), "Ichiban_Kuji_Progress_Reward", new <>z__ReadOnlyArray<object>(new object[]
			{
				this.Data.GetCurrentProgress(),
				this.Data.GetTotalProgress()
			}));
		}

		// Token: 0x06040D8C RID: 265612 RVA: 0x010A138C File Offset: 0x0109F58C
		private void RefreshTime()
		{
			ValueTuple<bool, string, long> timeVisibleAndRemainTime = ModelBase<ActivityModel>.Instance.GetTimeVisibleAndRemainTime(this.Data, null);
			bool item = timeVisibleAndRemainTime.Item1;
			string item2 = timeVisibleAndRemainTime.Item2;
			this.TimeTxtItem = base.GetText(12);
			this.TimeTxtItem.SetUIActive(item);
			this.TimeTxtItem.SetText(item2, true);
		}

		// Token: 0x06040D8D RID: 265613 RVA: 0x010A13E0 File Offset: 0x0109F5E0
		private void RefreshButton()
		{
			UUIItem item = base.GetItem(17);
			ActivityPrizeDrawingData data = this.Data;
			if (data != null && data.IsAllFinished())
			{
				ActivityButtonItem activityButton = this.ActivityButton;
				if (activityButton != null)
				{
					activityButton.SetUiActive(false);
				}
				if (item != null)
				{
					item.SetUIActive(true);
					return;
				}
			}
			else
			{
				ActivityButtonItem activityButton2 = this.ActivityButton;
				if (activityButton2 != null)
				{
					activityButton2.SetUiActive(true);
				}
				if (item != null)
				{
					item.SetUIActive(false);
				}
				ActivityButtonItem activityButton3 = this.ActivityButton;
				if (activityButton3 != null)
				{
					activityButton3.SetShowText("Ichiban_Kuji_Start");
				}
				ActivityButtonItem activityButton4 = this.ActivityButton;
				if (activityButton4 != null)
				{
					activityButton4.SetFunction(new Action(this.OnClickRoll));
				}
				ActivityButtonItem activityButton5 = this.ActivityButton;
				if (activityButton5 == null)
				{
					return;
				}
				activityButton5.SetRedDotVisible(this.Data.ShouldShowButtonRedDot());
			}
		}

		// Token: 0x06040D8E RID: 265614 RVA: 0x010A1494 File Offset: 0x0109F694
		private void RefreshQuest()
		{
			if (!this.Data.IsQuestAllCompleted())
			{
				PrizeDrawingQuestItem questItem = this.QuestItem;
				if (questItem != null)
				{
					questItem.RefreshFinishState(false);
				}
				int? currentQuestId = this.Data.GetCurrentQuestId();
				if (currentQuestId != null)
				{
					int? num = currentQuestId;
					int num2 = 0;
					if (!(num.GetValueOrDefault() == num2 & num != null))
					{
						PrizeDrawingQuestItem questItem2 = this.QuestItem;
						if (questItem2 == null)
						{
							return;
						}
						questItem2.RefreshByQuestId(currentQuestId.Value, this.Data.GetQuestProgress(), this.Data.GetQuestTotalProgress());
						return;
					}
				}
				return;
			}
			PrizeDrawingQuestItem questItem3 = this.QuestItem;
			if (questItem3 == null)
			{
				return;
			}
			questItem3.RefreshFinishState(true);
		}

		// Token: 0x06040D8F RID: 265615 RVA: 0x010A1530 File Offset: 0x0109F730
		private void OnClickRoll()
		{
			if (!ControllerBase<ActivityPrizeDrawingController>.Instance.ActivityData.HaveEnoughCoinToRoll())
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Ichiban_Kuji_NotEnoughTips", Array.Empty<object>());
				return;
			}
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null)
			{
				levelSequencePlayer.PlaySequencePurely("TransOut", true, false, null, null, false);
			}
			LevelSequencePlayer levelSequencePlayer2 = this.LevelSequencePlayer;
			if (levelSequencePlayer2 != null)
			{
				levelSequencePlayer2.StopSequenceByKey("GuideLoop", false, false);
			}
			LevelSequencePlayer levelSequencePlayer3 = this.LevelSequencePlayer;
			if (levelSequencePlayer3 != null)
			{
				levelSequencePlayer3.PlaySequencePurely("GuideDefault", false, false, null, null, false);
			}
			Singleton<UiManager>.Instance.OpenView(EUiViewName.PrizeDrawingTearView, null, null);
		}

		// Token: 0x06040D90 RID: 265616 RVA: 0x010A15D2 File Offset: 0x0109F7D2
		private void OnCloseCallback()
		{
			base.CloseMe(null);
		}

		// Token: 0x04024623 RID: 149027
		[Nullable(2)]
		private PopupCaptionItem CaptionItem;

		// Token: 0x04024624 RID: 149028
		[Nullable(2)]
		private ActivityButtonItem ActivityButton;

		// Token: 0x04024625 RID: 149029
		[Nullable(2)]
		private PrizeDrawingQuestItem QuestItem;

		// Token: 0x04024626 RID: 149030
		[Nullable(2)]
		private UUIText TimeTxtItem;

		// Token: 0x04024627 RID: 149031
		private readonly List<PrizeDrawingFinalRewardItem> FinalRewardItemList = new List<PrizeDrawingFinalRewardItem>();

		// Token: 0x04024628 RID: 149032
		private readonly List<PrizeDrawingRewardItem> RewardItemList = new List<PrizeDrawingRewardItem>();

		// Token: 0x04024629 RID: 149033
		[Nullable(2)]
		private LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x0402462A RID: 149034
		private bool IsRewardStatusChanged;

		// Token: 0x0200C542 RID: 50498
		[NullableContext(0)]
		private enum EComp
		{
			// Token: 0x0403CB2D RID: 248621
			Caption,
			// Token: 0x0403CB2E RID: 248622
			PrizeS1,
			// Token: 0x0403CB2F RID: 248623
			PrizeS2,
			// Token: 0x0403CB30 RID: 248624
			PrizeS3,
			// Token: 0x0403CB31 RID: 248625
			PrizeS4,
			// Token: 0x0403CB32 RID: 248626
			PrizeA,
			// Token: 0x0403CB33 RID: 248627
			PrizeB,
			// Token: 0x0403CB34 RID: 248628
			PrizeC,
			// Token: 0x0403CB35 RID: 248629
			PrizeD,
			// Token: 0x0403CB36 RID: 248630
			PrizeE,
			// Token: 0x0403CB37 RID: 248631
			PrizeF,
			// Token: 0x0403CB38 RID: 248632
			TxtProgress,
			// Token: 0x0403CB39 RID: 248633
			TxtDelTime,
			// Token: 0x0403CB3A RID: 248634
			TxtQuestName,
			// Token: 0x0403CB3B RID: 248635
			TxtQuestProgress,
			// Token: 0x0403CB3C RID: 248636
			QuestRewardItem,
			// Token: 0x0403CB3D RID: 248637
			SkipQuestBtn,
			// Token: 0x0403CB3E RID: 248638
			TipsFinish,
			// Token: 0x0403CB3F RID: 248639
			FunctionBtn,
			// Token: 0x0403CB40 RID: 248640
			QuestItem
		}
	}
}
