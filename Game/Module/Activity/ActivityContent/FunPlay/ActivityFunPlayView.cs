using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.FunPlay
{
	// Token: 0x02006779 RID: 26489
	[NullableContext(1)]
	[Nullable(0)]
	public class ActivityFunPlayView : UiTickViewBase
	{
		// Token: 0x06042083 RID: 270467 RVA: 0x010F11DE File Offset: 0x010EF3DE
		public ActivityFunPlayView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x06042084 RID: 270468 RVA: 0x010F11F4 File Offset: 0x010EF3F4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 15;
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
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 3;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnClickBtnUp));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(4, new Action(this.OnClickBtnDown));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(13, new Action(this.OnClickConfirmBtn));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06042085 RID: 270469 RVA: 0x010F1498 File Offset: 0x010EF698
		protected override UniTask OnBeforeStartAsync()
		{
			ActivityFunPlayView.<OnBeforeStartAsync>d__12 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<ActivityFunPlayView.<OnBeforeStartAsync>d__12>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06042086 RID: 270470 RVA: 0x010F14DC File Offset: 0x010EF6DC
		private UniTask InitRewardComp()
		{
			ActivityFunPlayView.<InitRewardComp>d__13 <InitRewardComp>d__;
			<InitRewardComp>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitRewardComp>d__.<>4__this = this;
			<InitRewardComp>d__.<>1__state = -1;
			<InitRewardComp>d__.<>t__builder.Start<ActivityFunPlayView.<InitRewardComp>d__13>(ref <InitRewardComp>d__);
			return <InitRewardComp>d__.<>t__builder.Task;
		}

		// Token: 0x06042087 RID: 270471 RVA: 0x010F1520 File Offset: 0x010EF720
		private UniTask InitPageView()
		{
			ActivityFunPlayView.<InitPageView>d__14 <InitPageView>d__;
			<InitPageView>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitPageView>d__.<>4__this = this;
			<InitPageView>d__.<>1__state = -1;
			<InitPageView>d__.<>t__builder.Start<ActivityFunPlayView.<InitPageView>d__14>(ref <InitPageView>d__);
			return <InitPageView>d__.<>t__builder.Task;
		}

		// Token: 0x06042088 RID: 270472 RVA: 0x010F1564 File Offset: 0x010EF764
		private void InitLoopScrollView()
		{
			UUILoopScrollViewComponent scrollView = base.GetItem(1).GetOwner().GetComponentByClass(UUILoopScrollViewComponent.StaticClass()) as UUILoopScrollViewComponent;
			this.ExhibitionView = new LoopScrollView<ActivityFunPlayTabItem, ActivityFunPlayChallengeData>(scrollView, base.GetItem(2).GetOwner() as AUIBaseActor, new Func<ActivityFunPlayTabItem>(this.CreateItem), false);
			base.GetItem(2).SetUIActive(false);
			this.ExhibitionView.BindOnScrollValueChanged(new Action<FVector2D>(this.OnScrollValueChanged));
		}

		// Token: 0x06042089 RID: 270473 RVA: 0x010F15E0 File Offset: 0x010EF7E0
		private void InitCaptionItem()
		{
			this.CaptionItem = new PopupCaptionItem(base.GetItem(0));
			if (this.CurrentActivity != null)
			{
				this.CaptionItem.SetTitle(this.CurrentActivity.GetTitle());
			}
			this.CaptionItem.SetHelpBtnActive(true);
			this.CaptionItem.SetCloseCallBack(new Action(this.OnCloseBtnClick));
			this.CaptionItem.SetHelpCallBack(new Action(this.OnHelpBtnClick));
		}

		// Token: 0x0604208A RID: 270474 RVA: 0x010F1658 File Offset: 0x010EF858
		private UniTask RefreshActivityScroller(bool reset)
		{
			ActivityFunPlayView.<RefreshActivityScroller>d__17 <RefreshActivityScroller>d__;
			<RefreshActivityScroller>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshActivityScroller>d__.<>4__this = this;
			<RefreshActivityScroller>d__.reset = reset;
			<RefreshActivityScroller>d__.<>1__state = -1;
			<RefreshActivityScroller>d__.<>t__builder.Start<ActivityFunPlayView.<RefreshActivityScroller>d__17>(ref <RefreshActivityScroller>d__);
			return <RefreshActivityScroller>d__.<>t__builder.Task;
		}

		// Token: 0x0604208B RID: 270475 RVA: 0x010F16A4 File Offset: 0x010EF8A4
		protected override void OnBeforeShow()
		{
			ControllerBase<ActivityController>.Instance.CheckIsActivityClose(null, new int?(this.CurrentActivity.Id));
			this.RefreshActivityScroller(true);
		}

		// Token: 0x0604208C RID: 270476 RVA: 0x010F16DC File Offset: 0x010EF8DC
		private ActivityFunPlayTabItem CreateItem()
		{
			return new ActivityFunPlayTabItem();
		}

		// Token: 0x0604208D RID: 270477 RVA: 0x010F16E4 File Offset: 0x010EF8E4
		private void OnClickConfirmBtn()
		{
			ActivityFunPlayChallengeData currentChallengeData = ModelBase<ActivityFunPlayModel>.Instance.GetCurrentChallengeData();
			int? num = (currentChallengeData != null) ? new int?(currentChallengeData.GetChallengeId()) : null;
			if (num != null)
			{
				ControllerBase<ActivityFunPlayController>.Instance.RequestEnterChallengeAsync(num.Value);
			}
		}

		// Token: 0x0604208E RID: 270478 RVA: 0x010F1730 File Offset: 0x010EF930
		private void OnClickBtnUp()
		{
			int gridIndex = Math.Max(this.ExhibitionView.GetDisplayGridStartIndex() - 1, 0);
			if (this.PreRedDotIndex != -1)
			{
				gridIndex = this.PreRedDotIndex;
			}
			LoopScrollView<ActivityFunPlayTabItem, ActivityFunPlayChallengeData> exhibitionView = this.ExhibitionView;
			if (exhibitionView == null)
			{
				return;
			}
			exhibitionView.ScrollToGridIndex(gridIndex, true);
		}

		// Token: 0x0604208F RID: 270479 RVA: 0x010F1774 File Offset: 0x010EF974
		private void OnClickBtnDown()
		{
			int gridIndex = this.ExhibitionView.GetDisplayGridStartIndex() + 1;
			if (this.NextRedDotIndex != -1)
			{
				gridIndex = this.NextRedDotIndex;
			}
			LoopScrollView<ActivityFunPlayTabItem, ActivityFunPlayChallengeData> exhibitionView = this.ExhibitionView;
			if (exhibitionView == null)
			{
				return;
			}
			exhibitionView.ScrollToGridIndex(gridIndex, true);
		}

		// Token: 0x06042090 RID: 270480 RVA: 0x010F17B4 File Offset: 0x010EF9B4
		private void OnScrollValueChanged(FVector2D _)
		{
			bool flag = false;
			bool flag2 = false;
			this.PreRedDotIndex = -1;
			this.NextRedDotIndex = -1;
			int displayGridStartIndex = this.ExhibitionView.GetDisplayGridStartIndex();
			int displayGridEndIndexPurely = this.ExhibitionView.GetDisplayGridEndIndexPurely();
			List<ActivityFunPlayChallengeData> allChallengeData = ModelBase<ActivityFunPlayModel>.Instance.GetAllChallengeData();
			for (int i = 0; i < allChallengeData.Count; i++)
			{
				ActivityFunPlayChallengeData activityFunPlayChallengeData = allChallengeData[i];
				if (!flag && activityFunPlayChallengeData.GetRedPoint() && i < displayGridStartIndex)
				{
					flag = true;
					this.PreRedDotIndex = i;
				}
				if (!flag2 && activityFunPlayChallengeData.GetRedPoint() && i > displayGridEndIndexPurely)
				{
					flag2 = true;
					this.NextRedDotIndex = i;
				}
			}
			base.GetItem(5).SetUIActive(flag);
			base.GetItem(6).SetUIActive(flag2);
			base.GetButton(3).RootUIComp.Get().SetUIActive(displayGridStartIndex > 0);
			base.GetButton(4).RootUIComp.Get().SetUIActive(displayGridEndIndexPurely < allChallengeData.Count - 1);
		}

		// Token: 0x06042091 RID: 270481 RVA: 0x010F18AC File Offset: 0x010EFAAC
		private void OnCloseBtnClick()
		{
			base.CloseMe(null);
		}

		// Token: 0x06042092 RID: 270482 RVA: 0x010F18B8 File Offset: 0x010EFAB8
		private void OnHelpBtnClick()
		{
			int helpId = this.CurrentActivity.GetHelpId();
			ControllerBase<HelpController>.Instance.OpenHelpById(helpId);
		}

		// Token: 0x06042093 RID: 270483 RVA: 0x010F18DC File Offset: 0x010EFADC
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnSelectActivityFunPlayChallengeItem, new Action(this.OnSelectChallengeItem));
			Singleton<EventSystem>.Instance.Add(EEventName.ActivityFunPlayInfoRefresh, new Action(this.OnInfoRefresh));
		}

		// Token: 0x06042094 RID: 270484 RVA: 0x010F1916 File Offset: 0x010EFB16
		private void OnSelectChallengeItem()
		{
			this.RefreshLockUi();
			this.RefreshCenterInfo(true);
			this.RefreshRightInfo();
			this.PlaySwitchAnimation();
		}

		// Token: 0x06042095 RID: 270485 RVA: 0x010F1934 File Offset: 0x010EFB34
		private void RefreshCenterInfo(bool reset)
		{
			ActivityFunPlayChallengeData currentChallengeData = ModelBase<ActivityFunPlayModel>.Instance.GetCurrentChallengeData();
			if (currentChallengeData == null)
			{
				return;
			}
			bool isUnlock = currentChallengeData.GetIsUnlock();
			base.GetItem(14).SetUIActive(isUnlock);
			if (isUnlock)
			{
				ActivityFunPlayPages pageView = this.PageView;
				if (pageView == null)
				{
					return;
				}
				pageView.Refresh(reset);
			}
		}

		// Token: 0x06042096 RID: 270486 RVA: 0x010F197C File Offset: 0x010EFB7C
		private void RefreshLockUi()
		{
			ActivityFunPlayChallengeData currentChallengeData = ModelBase<ActivityFunPlayModel>.Instance.GetCurrentChallengeData();
			if (currentChallengeData == null)
			{
				return;
			}
			bool isUnlock = currentChallengeData.GetIsUnlock();
			base.GetItem(7).SetUIActive(!isUnlock);
			if (!isUnlock)
			{
				string leftTimeText = currentChallengeData.GetLeftTimeText();
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(8), EFunPlayTextKey.UnlockTxt.ToString(), new <>z__ReadOnlySingleElementList<object>(leftTimeText));
			}
		}

		// Token: 0x06042097 RID: 270487 RVA: 0x010F19E4 File Offset: 0x010EFBE4
		private void RefreshRightInfo()
		{
			ActivityFunPlayChallengeData currentChallengeData = ModelBase<ActivityFunPlayModel>.Instance.GetCurrentChallengeData();
			if (currentChallengeData == null)
			{
				return;
			}
			bool isUnlock = currentChallengeData.GetIsUnlock();
			base.GetItem(9).SetUIActive(isUnlock);
			if (isUnlock)
			{
				this.RefreshTitleAndDesc();
				ActivityFunPlayRewardView rewardComp = this.RewardComp;
				if (rewardComp == null)
				{
					return;
				}
				rewardComp.Refresh();
			}
		}

		// Token: 0x06042098 RID: 270488 RVA: 0x010F1A30 File Offset: 0x010EFC30
		private void RefreshTitleAndDesc()
		{
			ActivityFunPlayChallengeData currentChallengeData = ModelBase<ActivityFunPlayModel>.Instance.GetCurrentChallengeData();
			if (currentChallengeData == null)
			{
				return;
			}
			string title = currentChallengeData.GetTitle();
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(10), title, Array.Empty<object>());
			string desc = currentChallengeData.GetDesc();
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(11), desc, Array.Empty<object>());
		}

		// Token: 0x06042099 RID: 270489 RVA: 0x010F1A8C File Offset: 0x010EFC8C
		private void OnInfoRefresh()
		{
			Singleton<Log>.Instance.Info(ELogModule.ActivityFunPlay, ELogAuthor.CB, "趣味活动页面信息刷新", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.RefreshActivityScroller(false);
			this.RefreshLockUi();
			this.RefreshCenterInfo(false);
			this.RefreshRightInfo();
		}

		// Token: 0x0604209A RID: 270490 RVA: 0x010F1AD3 File Offset: 0x010EFCD3
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnSelectActivityFunPlayChallengeItem, new Action(this.OnSelectChallengeItem));
			Singleton<EventSystem>.Instance.Remove(EEventName.ActivityFunPlayInfoRefresh, new Action(this.OnInfoRefresh));
		}

		// Token: 0x0604209B RID: 270491 RVA: 0x010F1B10 File Offset: 0x010EFD10
		private void PlaySwitchAnimation()
		{
			if (this.UiViewSequence.HasSequenceNameInPlaying("Switch"))
			{
				this.UiViewSequence.ReplaySequence("Switch");
				return;
			}
			this.UiViewSequence.PlaySequence("Switch", false, null);
		}

		// Token: 0x0604209C RID: 270492 RVA: 0x010F1B5C File Offset: 0x010EFD5C
		protected override void OnTick(float delta)
		{
			this.TickTime += delta;
			if (this.TickTime >= (float)Singleton<TimeUtil>.Instance.InverseMillisecond)
			{
				this.TickTime = 0f;
				int? needRefreshUnlock = this.GetNeedRefreshUnlock();
				if (needRefreshUnlock == null)
				{
					return;
				}
				this.OnInfoRefresh();
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshActivityFunPlayRedDot, needRefreshUnlock.Value);
				if (this.CurrentActivity != null)
				{
					Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, this.CurrentActivity.Id);
				}
			}
		}

		// Token: 0x0604209D RID: 270493 RVA: 0x010F1BE8 File Offset: 0x010EFDE8
		public int? GetNeedRefreshUnlock()
		{
			if (this.LockChallengeIds.Count == 0)
			{
				return null;
			}
			int num = this.LockChallengeIds[0];
			ActivityFunPlayChallengeData challengeData = ModelBase<ActivityFunPlayModel>.Instance.GetChallengeData(num);
			if (challengeData != null && challengeData.GetIsUnlock())
			{
				this.LockChallengeIds.RemoveAt(0);
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.ActivityFunPlay;
				ELogAuthor author = ELogAuthor.CB;
				string message = "解锁刷新的关卡id";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ChallengeId", num);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return new int?(num);
			}
			return null;
		}

		// Token: 0x0604209E RID: 270494 RVA: 0x010F1C80 File Offset: 0x010EFE80
		private void InitLastLockChallengeIds()
		{
			foreach (ActivityFunPlayChallengeData activityFunPlayChallengeData in ModelBase<ActivityFunPlayModel>.Instance.GetAllChallengeData())
			{
				if (!activityFunPlayChallengeData.GetIsUnlock())
				{
					int challengeId = activityFunPlayChallengeData.GetChallengeId();
					this.LockChallengeIds.Add(challengeId);
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.ActivityFunPlay;
					ELogAuthor author = ELogAuthor.CB;
					string message = "添加未解锁的关卡id";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ChallengeId", challengeId);
					instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				}
			}
		}

		// Token: 0x04024D18 RID: 150808
		private PopupCaptionItem CaptionItem;

		// Token: 0x04024D19 RID: 150809
		private ActivityFunPlayData CurrentActivity;

		// Token: 0x04024D1A RID: 150810
		private LoopScrollView<ActivityFunPlayTabItem, ActivityFunPlayChallengeData> ExhibitionView;

		// Token: 0x04024D1B RID: 150811
		private ActivityFunPlayRewardView RewardComp;

		// Token: 0x04024D1C RID: 150812
		private ActivityFunPlayPages PageView;

		// Token: 0x04024D1D RID: 150813
		private int PreRedDotIndex;

		// Token: 0x04024D1E RID: 150814
		private int NextRedDotIndex;

		// Token: 0x04024D1F RID: 150815
		private readonly List<int> LockChallengeIds = new List<int>();

		// Token: 0x04024D20 RID: 150816
		private float TickTime;

		// Token: 0x0200C796 RID: 51094
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x0403D725 RID: 251685
			public const int CaptionItem = 0;

			// Token: 0x0403D726 RID: 251686
			public const int LeftScroller = 1;

			// Token: 0x0403D727 RID: 251687
			public const int LeftItem = 2;

			// Token: 0x0403D728 RID: 251688
			public const int BtnUp = 3;

			// Token: 0x0403D729 RID: 251689
			public const int BtnDown = 4;

			// Token: 0x0403D72A RID: 251690
			public const int UpRed = 5;

			// Token: 0x0403D72B RID: 251691
			public const int DownRed = 6;

			// Token: 0x0403D72C RID: 251692
			public const int LockUiItem = 7;

			// Token: 0x0403D72D RID: 251693
			public const int LockTxt = 8;

			// Token: 0x0403D72E RID: 251694
			public const int RightInfo = 9;

			// Token: 0x0403D72F RID: 251695
			public const int TxtTitle = 10;

			// Token: 0x0403D730 RID: 251696
			public const int TxtInfo = 11;

			// Token: 0x0403D731 RID: 251697
			public const int RewardComp = 12;

			// Token: 0x0403D732 RID: 251698
			public const int BtnConfirm = 13;

			// Token: 0x0403D733 RID: 251699
			public const int CenterInfo = 14;
		}
	}
}
