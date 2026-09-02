using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Activity.ActivityContent.PrizeDrawing.Components;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.PrizeDrawing
{
	// Token: 0x02006564 RID: 25956
	[NullableContext(2)]
	[Nullable(0)]
	public class ActivityPrizeDrawingSubView : ActivitySubViewBase
	{
		// Token: 0x17009E9F RID: 40607
		// (get) Token: 0x06040D91 RID: 265617 RVA: 0x010A15DB File Offset: 0x0109F7DB
		[Nullable(1)]
		private ActivityPrizeDrawingData ActivityPrizeDrawingData
		{
			[NullableContext(1)]
			get
			{
				return (ActivityPrizeDrawingData)this.ActivityBaseData;
			}
		}

		// Token: 0x06040D92 RID: 265618 RVA: 0x010A15E8 File Offset: 0x0109F7E8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 12;
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
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(8, new Action(this.OnClickSkipBtn));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06040D93 RID: 265619 RVA: 0x010A17DC File Offset: 0x0109F9DC
		protected override UniTask OnBeforeStartAsync()
		{
			ActivityPrizeDrawingSubView.<OnBeforeStartAsync>d__12 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<ActivityPrizeDrawingSubView.<OnBeforeStartAsync>d__12>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06040D94 RID: 265620 RVA: 0x010A1820 File Offset: 0x0109FA20
		protected override void OnStart()
		{
			ActivityPrizeDrawingData activityData = this.ActivityPrizeDrawingData;
			activityData.ReadRedDot();
			this.TitleComponent.SetActivityBaseData(activityData);
			this.TitleComponent.SetTitleByText(activityData.GetTitle());
			this.DescriptionComponent.SetContentByTextId(activityData.LocalConfig.Value.Desc, Array.Empty<string>());
			string conditionGroupHintText = LevelGeneralCommons.GetConditionGroupHintText(activityData.ConditionGroupId);
			if (!string.IsNullOrEmpty(conditionGroupHintText))
			{
				this.TipsLock.SetTextByTextId(conditionGroupHintText, Array.Empty<string>());
			}
			this.TipsLock.ButtonCallBack = delegate()
			{
				ControllerBase<ActivityController>.Instance.OpenActivityConditionView(activityData.Id);
			};
			this.SkipBtn.SetExtraFunction(new Action(this.ExtraButtonFunction));
			this.SkipBtn.SetFunction(new Action(this.OnClickSkipBtn));
		}

		// Token: 0x06040D95 RID: 265621 RVA: 0x010A1908 File Offset: 0x0109FB08
		protected override void OnRefreshView()
		{
			this.RefreshRewardComponent();
			this.RefreshPageState();
			this.RefreshTimerText();
			this.RefreshProgress();
			this.RefreshQuest();
		}

		// Token: 0x06040D96 RID: 265622 RVA: 0x010A1928 File Offset: 0x0109FB28
		protected override void OnTimer(float gap)
		{
			this.RefreshTimerText();
		}

		// Token: 0x06040D97 RID: 265623 RVA: 0x010A1930 File Offset: 0x0109FB30
		protected override UniTask OnBeforeHideSelfAsync()
		{
			ActivityPrizeDrawingSubView.<OnBeforeHideSelfAsync>d__16 <OnBeforeHideSelfAsync>d__;
			<OnBeforeHideSelfAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeHideSelfAsync>d__.<>4__this = this;
			<OnBeforeHideSelfAsync>d__.<>1__state = -1;
			<OnBeforeHideSelfAsync>d__.<>t__builder.Start<ActivityPrizeDrawingSubView.<OnBeforeHideSelfAsync>d__16>(ref <OnBeforeHideSelfAsync>d__);
			return <OnBeforeHideSelfAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06040D98 RID: 265624 RVA: 0x010A1973 File Offset: 0x0109FB73
		protected override void OnBeforeDestroy()
		{
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer == null)
			{
				return;
			}
			levelSequencePlayer.Clear();
		}

		// Token: 0x06040D99 RID: 265625 RVA: 0x010A1985 File Offset: 0x0109FB85
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnPrizeDrawingQuestUpdated, new Action(this.OnQuestUpdated));
		}

		// Token: 0x06040D9A RID: 265626 RVA: 0x010A19A3 File Offset: 0x0109FBA3
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnPrizeDrawingQuestUpdated, new Action(this.OnQuestUpdated));
		}

		// Token: 0x06040D9B RID: 265627 RVA: 0x010A19C1 File Offset: 0x0109FBC1
		private void OnQuestUpdated()
		{
			this.OnRefreshView();
		}

		// Token: 0x06040D9C RID: 265628 RVA: 0x010A19CC File Offset: 0x0109FBCC
		private void RefreshProgress()
		{
			ActivityPrizeDrawingData activityPrizeDrawingData = this.ActivityPrizeDrawingData;
			int currentProgress = activityPrizeDrawingData.GetCurrentProgress();
			int totalProgress = activityPrizeDrawingData.GetTotalProgress();
			UUIText text = base.GetText(4);
			if (text != null)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
				defaultInterpolatedStringHandler.AppendFormatted<int>(currentProgress);
				defaultInterpolatedStringHandler.AppendLiteral("/");
				defaultInterpolatedStringHandler.AppendFormatted<int>(totalProgress);
				text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
			}
			UUIItem item = base.GetItem(5);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(currentProgress >= totalProgress);
		}

		// Token: 0x06040D9D RID: 265629 RVA: 0x010A1A44 File Offset: 0x0109FC44
		private void RefreshQuest()
		{
			if (!this.ActivityPrizeDrawingData.GetPreGuideQuestFinishState())
			{
				PrizeDrawingQuestItem questItem = this.QuestItem;
				if (questItem == null)
				{
					return;
				}
				questItem.GetRootItem().SetUIActive(false);
				return;
			}
			else
			{
				PrizeDrawingQuestItem questItem2 = this.QuestItem;
				if (questItem2 != null)
				{
					questItem2.GetRootItem().SetUIActive(true);
				}
				ActivityPrizeDrawingData activityPrizeDrawingData = this.ActivityPrizeDrawingData;
				if (!activityPrizeDrawingData.IsQuestAllCompleted())
				{
					PrizeDrawingQuestItem questItem3 = this.QuestItem;
					if (questItem3 != null)
					{
						questItem3.RefreshFinishState(false);
					}
					int? currentQuestId = activityPrizeDrawingData.GetCurrentQuestId();
					if (currentQuestId != null)
					{
						int? num = currentQuestId;
						int num2 = 0;
						if (!(num.GetValueOrDefault() == num2 & num != null))
						{
							PrizeDrawingQuestItem questItem4 = this.QuestItem;
							if (questItem4 == null)
							{
								return;
							}
							questItem4.RefreshByQuestId(currentQuestId.Value, activityPrizeDrawingData.GetQuestProgress(), activityPrizeDrawingData.GetQuestTotalProgress());
							return;
						}
					}
					return;
				}
				PrizeDrawingQuestItem questItem5 = this.QuestItem;
				if (questItem5 == null)
				{
					return;
				}
				questItem5.RefreshFinishState(true);
				return;
			}
		}

		// Token: 0x06040D9E RID: 265630 RVA: 0x010A1B0C File Offset: 0x0109FD0C
		private void RefreshTimerText()
		{
			ValueTuple<bool, string, long> timeVisibleAndRemainTime = this.GetTimeVisibleAndRemainTime();
			bool item = timeVisibleAndRemainTime.Item1;
			string item2 = timeVisibleAndRemainTime.Item2;
			this.TitleComponent.SetTimeTextVisible(item);
			if (item)
			{
				this.TitleComponent.SetTimeTextByText(item2);
			}
		}

		// Token: 0x06040D9F RID: 265631 RVA: 0x010A1B48 File Offset: 0x0109FD48
		private void RefreshRewardComponent()
		{
			List<TItem> previewReward = this.ActivityPrizeDrawingData.GetPreviewReward(null);
			this.RewardListComponent.InitGridLayout(new Func<CommonItemSmallItemGrid>(this.RewardListComponent.InitCommonGridItem));
			this.RewardListComponent.RefreshItemLayout(previewReward, null);
		}

		// Token: 0x06040DA0 RID: 265632 RVA: 0x010A1B94 File Offset: 0x0109FD94
		private void RefreshPageState()
		{
			ActivityBaseData activityBaseData = this.ActivityBaseData;
			bool? flag = (activityBaseData != null) ? new bool?(activityBaseData.IsUnLock()) : null;
			if (flag == null || !flag.Value)
			{
				this.RefreshByState(ActivityPrizeDrawingSubView.EState.Lock);
				return;
			}
			if (!this.ActivityPrizeDrawingData.GetPreGuideQuestFinishState())
			{
				this.RefreshByState(ActivityPrizeDrawingSubView.EState.Guide);
				return;
			}
			if (this.ActivityPrizeDrawingData.IsAllFinished())
			{
				this.RefreshByState(ActivityPrizeDrawingSubView.EState.Finish);
				return;
			}
			this.RefreshByState(ActivityPrizeDrawingSubView.EState.Normal);
		}

		// Token: 0x06040DA1 RID: 265633 RVA: 0x010A1C0C File Offset: 0x0109FE0C
		private void RefreshByState(ActivityPrizeDrawingSubView.EState state)
		{
			UUIItem item = base.GetItem(0);
			if (item != null)
			{
				item.SetUIActive(state == ActivityPrizeDrawingSubView.EState.Lock);
			}
			UUIItem item2 = base.GetItem(1);
			if (item2 != null)
			{
				item2.SetUIActive(state > ActivityPrizeDrawingSubView.EState.Lock);
			}
			UUIItem item3 = base.GetItem(11);
			if (item3 != null)
			{
				item3.SetUIActive(state == ActivityPrizeDrawingSubView.EState.Normal || state == ActivityPrizeDrawingSubView.EState.Finish);
			}
			UUIItem item4 = base.GetItem(7);
			if (item4 != null)
			{
				item4.SetUIActive(state == ActivityPrizeDrawingSubView.EState.Lock);
			}
			UUIButtonComponent button = base.GetButton(8);
			if (button != null)
			{
				button.RootUIComp.Get().SetUIActive(state == ActivityPrizeDrawingSubView.EState.Finish);
			}
			UUIItem item5 = base.GetItem(9);
			if (item5 != null)
			{
				item5.SetUIActive(state == ActivityPrizeDrawingSubView.EState.Guide || state == ActivityPrizeDrawingSubView.EState.Normal);
			}
			switch (state)
			{
			case ActivityPrizeDrawingSubView.EState.Lock:
				break;
			case ActivityPrizeDrawingSubView.EState.Guide:
			{
				ActivityButtonItem skipBtn = this.SkipBtn;
				if (skipBtn != null)
				{
					skipBtn.SetShowText("Ichiban_Kuji_GuideQuestTips");
				}
				ActivityButtonItem skipBtn2 = this.SkipBtn;
				if (skipBtn2 == null)
				{
					return;
				}
				skipBtn2.SetRedDotVisible(this.ActivityPrizeDrawingData.NeedFinishGuideQuest());
				return;
			}
			case ActivityPrizeDrawingSubView.EState.Normal:
			case ActivityPrizeDrawingSubView.EState.Finish:
			{
				Singleton<EventSystem>.Instance.Emit<IReadOnlyList<int>>(EEventName.SetActivityViewCurrency, new List<int>
				{
					this.ActivityPrizeDrawingData.GetCostCoinId()
				});
				ActivityButtonItem skipBtn3 = this.SkipBtn;
				if (skipBtn3 != null)
				{
					skipBtn3.SetShowText("Ichiban_Kuji_SkipMainViewTips");
				}
				ActivityButtonItem skipBtn4 = this.SkipBtn;
				if (skipBtn4 == null)
				{
					return;
				}
				skipBtn4.SetRedDotVisible(this.ActivityPrizeDrawingData.ShouldShowButtonRedDot());
				break;
			}
			default:
				return;
			}
		}

		// Token: 0x06040DA2 RID: 265634 RVA: 0x010A1D5A File Offset: 0x0109FF5A
		private void ExtraButtonFunction()
		{
			if (this.ActivityBaseData != null)
			{
				ModelBase<ActivityModel>.Instance.SendActivityViewJumpClickLogData(this.ActivityBaseData);
			}
		}

		// Token: 0x06040DA3 RID: 265635 RVA: 0x010A1D74 File Offset: 0x0109FF74
		private void OnClickSkipBtn()
		{
			if (!this.ActivityPrizeDrawingData.GetPreGuideQuestFinishState())
			{
				int unFinishPreGuideQuestId = this.ActivityPrizeDrawingData.GetUnFinishPreGuideQuestId();
				Singleton<UiManager>.Instance.OpenView(EUiViewName.QuestView, unFinishPreGuideQuestId, null);
				return;
			}
			this.IsGoToMainView = true;
			Singleton<UiManager>.Instance.OpenView(EUiViewName.PrizeDrawingMainView, null, null);
		}

		// Token: 0x0402462B RID: 149035
		private ActivityTitleTypeA TitleComponent;

		// Token: 0x0402462C RID: 149036
		private ActivityDescriptionTypeA DescriptionComponent;

		// Token: 0x0402462D RID: 149037
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private ActivityRewardList<CommonItemSmallItemGrid, TItem> RewardListComponent;

		// Token: 0x0402462E RID: 149038
		private FunctionalPanelConditionLock TipsLock;

		// Token: 0x0402462F RID: 149039
		private ActivityButtonItem SkipBtn;

		// Token: 0x04024630 RID: 149040
		private PrizeDrawingQuestItem QuestItem;

		// Token: 0x04024631 RID: 149041
		private bool IsGoToMainView;

		// Token: 0x0200C547 RID: 50503
		[NullableContext(0)]
		private enum EChildType
		{
			// Token: 0x0403CB59 RID: 248665
			PnlLock,
			// Token: 0x0403CB5A RID: 248666
			PnlUnlock,
			// Token: 0x0403CB5B RID: 248667
			TitleItem,
			// Token: 0x0403CB5C RID: 248668
			DescItem,
			// Token: 0x0403CB5D RID: 248669
			TxtProgress,
			// Token: 0x0403CB5E RID: 248670
			PnlProgressGot,
			// Token: 0x0403CB5F RID: 248671
			RewardPreviewComp,
			// Token: 0x0403CB60 RID: 248672
			TipsLock,
			// Token: 0x0403CB61 RID: 248673
			BtnFinish,
			// Token: 0x0403CB62 RID: 248674
			SkipBtn,
			// Token: 0x0403CB63 RID: 248675
			QuestItem,
			// Token: 0x0403CB64 RID: 248676
			PnlProgress
		}

		// Token: 0x0200C548 RID: 50504
		[NullableContext(0)]
		private enum EState
		{
			// Token: 0x0403CB66 RID: 248678
			Lock,
			// Token: 0x0403CB67 RID: 248679
			Guide,
			// Token: 0x0403CB68 RID: 248680
			Normal,
			// Token: 0x0403CB69 RID: 248681
			Finish
		}
	}
}
