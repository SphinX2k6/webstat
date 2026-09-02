using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Protocol;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.LinkageReward
{
	// Token: 0x0200675B RID: 26459
	[NullableContext(2)]
	[Nullable(0)]
	public class LinkageRewardActivitySubView : ActivitySubViewBase
	{
		// Token: 0x06041F3F RID: 270143 RVA: 0x010EBA74 File Offset: 0x010E9C74
		protected unsafe override void OnRegisterComponent()
		{
			int num = 7;
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
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06041F40 RID: 270144 RVA: 0x010EBB82 File Offset: 0x010E9D82
		protected override void OnSetData()
		{
			this.LinkageRewardData = (this.ActivityBaseData as LinkageRewardActivityData);
		}

		// Token: 0x06041F41 RID: 270145 RVA: 0x010EBB98 File Offset: 0x010E9D98
		protected override UniTask OnBeforeStartAsync()
		{
			LinkageRewardActivitySubView.<OnBeforeStartAsync>d__18 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<LinkageRewardActivitySubView.<OnBeforeStartAsync>d__18>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06041F42 RID: 270146 RVA: 0x010EBBDC File Offset: 0x010E9DDC
		protected override void OnStart()
		{
			this.RewardItemA1.OnClickToGet = new Action<int, int, bool>(this.OnGetReward);
			this.RewardItemA2.OnClickToGet = new Action<int, int, bool>(this.OnGetReward);
			this.RewardItemA3.OnClickToGet = new Action<int, int, bool>(this.OnGetReward);
			this.TitleComponent.SetActivityBaseData(this.ActivityBaseData);
			this.TitleComponent.SetTitleByText(this.ActivityBaseData.GetTitle());
			this.TitleComponent.SetSubTitleVisible(false);
			this.TitleComponent.SetSubTitleIconVisible(false);
			this.TitleComponent.ApplyLinkageSubTitleVisible(false);
		}

		// Token: 0x06041F43 RID: 270147 RVA: 0x010EBC79 File Offset: 0x010E9E79
		protected override void OnRefreshView()
		{
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshActivityTab, this.ActivityBaseData.Id);
		}

		// Token: 0x06041F44 RID: 270148 RVA: 0x010EBC96 File Offset: 0x010E9E96
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<int>(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnRefreshCommonActivityRedDot));
		}

		// Token: 0x06041F45 RID: 270149 RVA: 0x010EBCB4 File Offset: 0x010E9EB4
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnRefreshCommonActivityRedDot));
		}

		// Token: 0x06041F46 RID: 270150 RVA: 0x010EBCD4 File Offset: 0x010E9ED4
		protected override UniTask OnBeforeShowSelfAsync()
		{
			LinkageRewardActivitySubView.<OnBeforeShowSelfAsync>d__23 <OnBeforeShowSelfAsync>d__;
			<OnBeforeShowSelfAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeShowSelfAsync>d__.<>4__this = this;
			<OnBeforeShowSelfAsync>d__.<>1__state = -1;
			<OnBeforeShowSelfAsync>d__.<>t__builder.Start<LinkageRewardActivitySubView.<OnBeforeShowSelfAsync>d__23>(ref <OnBeforeShowSelfAsync>d__);
			return <OnBeforeShowSelfAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06041F47 RID: 270151 RVA: 0x010EBD17 File Offset: 0x010E9F17
		public override void SetActive(bool visibility)
		{
			if (!visibility)
			{
				this.PendingFocusRequestId++;
			}
			base.SetActive(visibility);
		}

		// Token: 0x06041F48 RID: 270152 RVA: 0x010EBD31 File Offset: 0x010E9F31
		public override void OnCommonViewStateChange(bool show)
		{
			this.CanApplyGamepadFocus = !show;
			if (this.CanApplyGamepadFocus && this.PendingFocusRewardIndex >= 0)
			{
				this.ScheduleApplyPendingFocus(this.LinkageRewardData.GetRewardDataList().Count);
			}
		}

		// Token: 0x06041F49 RID: 270153 RVA: 0x010EBD64 File Offset: 0x010E9F64
		protected override void OnTimer(float gap)
		{
			this.RefreshTimerText();
		}

		// Token: 0x06041F4A RID: 270154 RVA: 0x010EBD6C File Offset: 0x010E9F6C
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

		// Token: 0x06041F4B RID: 270155 RVA: 0x010EBDA7 File Offset: 0x010E9FA7
		private void OnRefreshCommonActivityRedDot(int id)
		{
			if (this.ActivityBaseData.Id != id)
			{
				return;
			}
			this.ScheduleRefreshRewardLayout();
		}

		// Token: 0x06041F4C RID: 270156 RVA: 0x010EBDBE File Offset: 0x010E9FBE
		private void ScheduleRefreshRewardLayout()
		{
			if (this.HasPendingRefreshRewardLayout)
			{
				return;
			}
			this.HasPendingRefreshRewardLayout = true;
			TimerSystem.Instance.Next(delegate(float _)
			{
				this.HasPendingRefreshRewardLayout = false;
				this.RefreshRewardLayout(false);
			}, null, null);
		}

		// Token: 0x06041F4D RID: 270157 RVA: 0x010EBDEC File Offset: 0x010E9FEC
		private void RefreshRewardLayout(bool playGridAnimForListB = false)
		{
			LinkageRewardActivitySubView.<>c__DisplayClass30_0 CS$<>8__locals1 = new LinkageRewardActivitySubView.<>c__DisplayClass30_0();
			CS$<>8__locals1.<>4__this = this;
			List<TimePointRewardData> keepRewardDataList = this.LinkageRewardData.GetKeepRewardDataList();
			CS$<>8__locals1.normalRewardList = this.LinkageRewardData.GetRewardDataList();
			this.RefreshKeepRewardPanel(this.RewardItemA1, (keepRewardDataList.Count > 0) ? keepRewardDataList[0] : null, 0);
			this.RefreshKeepRewardPanel(this.RewardItemA2, (keepRewardDataList.Count > 1) ? keepRewardDataList[1] : null, 1);
			this.RefreshKeepRewardPanel(this.RewardItemA3, (keepRewardDataList.Count > 2) ? keepRewardDataList[2] : null, 2);
			LinkageRewardActivitySubView.<>c__DisplayClass30_0 CS$<>8__locals2 = CS$<>8__locals1;
			int num = this.AutoScrollRewardItemBRequestId + 1;
			this.AutoScrollRewardItemBRequestId = num;
			CS$<>8__locals2.requestId = num;
			GenericLayout<LinkageRewardRewardItem, TimePointRewardData> rewardItemBLayout = this.RewardItemBLayout;
			if (rewardItemBLayout != null)
			{
				rewardItemBLayout.RefreshByData(CS$<>8__locals1.normalRewardList, delegate
				{
					if (CS$<>8__locals1.requestId != CS$<>8__locals1.<>4__this.AutoScrollRewardItemBRequestId)
					{
						return;
					}
					int num2 = CS$<>8__locals1.<>4__this.FindPreferredRewardIndex(CS$<>8__locals1.normalRewardList);
					CS$<>8__locals1.<>4__this.PendingFocusRewardIndex = num2;
					CS$<>8__locals1.<>4__this.TryAutoScrollRewardItemB(num2);
					CS$<>8__locals1.<>4__this.ScheduleApplyPendingFocus(CS$<>8__locals1.normalRewardList.Count);
				}, playGridAnimForListB);
			}
			LinkageRewardProgressPanel progressPanel = this.ProgressPanel;
			if (progressPanel == null)
			{
				return;
			}
			progressPanel.Refresh(keepRewardDataList, this.LinkageRewardData.GetCurrentCheckInDay());
		}

		// Token: 0x06041F4E RID: 270158 RVA: 0x010EBEDC File Offset: 0x010EA0DC
		[NullableContext(1)]
		private void CacheRewardItemBScrollView(UUIHorizontalLayout contentLayout)
		{
			AUIBaseActor auibaseActor = contentLayout.GetOwner() as AUIBaseActor;
			UUIScrollViewWithScrollbarComponent uuiscrollViewWithScrollbarComponent = ((auibaseActor != null) ? auibaseActor.GetComponentByClass(UUIScrollViewWithScrollbarComponent.StaticClass()) : null) as UUIScrollViewWithScrollbarComponent;
			if (uuiscrollViewWithScrollbarComponent != null)
			{
				this.RewardItemBScrollView = uuiscrollViewWithScrollbarComponent;
				return;
			}
			UUIItem uuiitem = contentLayout.RootUIComp.Get();
			for (UUIItem uuiitem2 = (uuiitem != null) ? uuiitem.GetParentAsUIItem() : null; uuiitem2 != null; uuiitem2 = uuiitem2.GetParentAsUIItem())
			{
				AUIBaseActor auibaseActor2 = uuiitem2.GetOwner() as AUIBaseActor;
				UUIScrollViewWithScrollbarComponent uuiscrollViewWithScrollbarComponent2 = ((auibaseActor2 != null) ? auibaseActor2.GetComponentByClass(UUIScrollViewWithScrollbarComponent.StaticClass()) : null) as UUIScrollViewWithScrollbarComponent;
				if (uuiscrollViewWithScrollbarComponent2 != null)
				{
					this.RewardItemBScrollView = uuiscrollViewWithScrollbarComponent2;
					return;
				}
			}
		}

		// Token: 0x06041F4F RID: 270159 RVA: 0x010EBF74 File Offset: 0x010EA174
		private void TryAutoScrollRewardItemB(int targetIndex)
		{
			if (this.HasAutoScrolledRewardItemB || targetIndex < 0)
			{
				return;
			}
			this.HasAutoScrolledRewardItemB = true;
			UUIScrollViewWithScrollbarComponent rewardItemBScrollView = this.RewardItemBScrollView;
			if (rewardItemBScrollView == null || !rewardItemBScrollView.IsValid())
			{
				return;
			}
			GenericLayout<LinkageRewardRewardItem, TimePointRewardData> rewardItemBLayout = this.RewardItemBLayout;
			UUIItem uuiitem = (rewardItemBLayout != null) ? rewardItemBLayout.GetItemByIndex(targetIndex) : null;
			if (uuiitem != null && uuiitem.IsValid())
			{
				rewardItemBScrollView.ScrollToLeftLater(uuiitem, false);
			}
		}

		// Token: 0x06041F50 RID: 270160 RVA: 0x010EBFCF File Offset: 0x010EA1CF
		[NullableContext(1)]
		private LinkageRewardRewardItem InitRewardItemB()
		{
			return new LinkageRewardRewardItem
			{
				OnClickToGet = new Action<int, int, bool>(this.OnGetReward)
			};
		}

		// Token: 0x06041F51 RID: 270161 RVA: 0x010EBFE8 File Offset: 0x010EA1E8
		[NullableContext(1)]
		private int FindPreferredRewardIndex(List<TimePointRewardData> normalRewardList)
		{
			for (int i = 0; i < normalRewardList.Count; i++)
			{
				if (normalRewardList[i].RewardState == ETimePointRewardState.UnlockAndUnClaimed)
				{
					return i;
				}
			}
			int num = normalRewardList.FindIndex((TimePointRewardData data) => data.RewardState == ETimePointRewardState.Lock);
			if (num >= 0)
			{
				return num;
			}
			for (int j = normalRewardList.Count - 1; j >= 0; j--)
			{
				if (normalRewardList[j].RewardState == ETimePointRewardState.UnlockAndClaimed)
				{
					return j;
				}
			}
			return 0;
		}

		// Token: 0x06041F52 RID: 270162 RVA: 0x010EC068 File Offset: 0x010EA268
		private bool TryAlignGamepadEntryFocus(int targetIndex, int totalCount)
		{
			if (!Singleton<Info>.Instance.IsInGamepad() || totalCount <= 0 || targetIndex < 0)
			{
				return false;
			}
			if (!this.CanApplyGamepadFocus)
			{
				return false;
			}
			UUIItem uuiitem = this.FindFocusTargetRewardItem(targetIndex, totalCount);
			if (uuiitem == null || !uuiitem.IsValid())
			{
				return false;
			}
			AActor owner = uuiitem.GetOwner();
			TsUiNavigationBehaviorListener tsUiNavigationBehaviorListener = ((owner != null) ? owner.GetComponentByClass(TsUiNavigationBehaviorListener.StaticClass()) : null) as TsUiNavigationBehaviorListener;
			if (tsUiNavigationBehaviorListener == null)
			{
				return false;
			}
			GenericLayout<LinkageRewardRewardItem, TimePointRewardData> rewardItemBLayout = this.RewardItemBLayout;
			UUIItem uuiitem2 = (rewardItemBLayout != null) ? rewardItemBLayout.GetItemByIndex(targetIndex) : null;
			if (uuiitem2 != null && uuiitem2.IsValid())
			{
				UUIScrollViewWithScrollbarComponent rewardItemBScrollView = this.RewardItemBScrollView;
				if (rewardItemBScrollView != null)
				{
					rewardItemBScrollView.ScrollToLeftLater(uuiitem2, false);
				}
			}
			UiNavigationNewController instance = ControllerBase<UiNavigationNewController>.Instance;
			TsUiNavigationBehaviorListener tsUiNavigationBehaviorListener2 = (instance != null) ? instance.GetCurrentNavigationFocusListener() : null;
			if (tsUiNavigationBehaviorListener2 != null && tsUiNavigationBehaviorListener2.GroupName != tsUiNavigationBehaviorListener.GroupName)
			{
				return false;
			}
			UiNavigationNewController instance2 = ControllerBase<UiNavigationNewController>.Instance;
			if (instance2 != null)
			{
				instance2.SetNavigationFocusForView(uuiitem, true, false, false);
			}
			return true;
		}

		// Token: 0x06041F53 RID: 270163 RVA: 0x010EC144 File Offset: 0x010EA344
		private void ScheduleApplyPendingFocus(int totalCount)
		{
			if (!Singleton<Info>.Instance.IsInGamepad() || totalCount <= 0)
			{
				return;
			}
			if (!this.CanApplyGamepadFocus)
			{
				return;
			}
			int num = this.PendingFocusRequestId + 1;
			this.PendingFocusRequestId = num;
			int requestId = num;
			this.TryApplyPendingFocusWithRetry(requestId, totalCount, 600);
		}

		// Token: 0x06041F54 RID: 270164 RVA: 0x010EC18C File Offset: 0x010EA38C
		private void TryApplyPendingFocusWithRetry(int requestId, int totalCount, int remainRetryCount)
		{
			TimerSystem.Instance.Next(delegate(float _)
			{
				if (requestId != this.PendingFocusRequestId || !this.IsUiActiveInHierarchy())
				{
					return;
				}
				if (this.TryAlignGamepadEntryFocus(this.PendingFocusRewardIndex, totalCount))
				{
					return;
				}
				if (remainRetryCount <= 0 || !this.IsUiActiveInHierarchy())
				{
					return;
				}
				this.TryApplyPendingFocusWithRetry(requestId, totalCount, remainRetryCount - 1);
			}, null, null);
		}

		// Token: 0x06041F55 RID: 270165 RVA: 0x010EC1D4 File Offset: 0x010EA3D4
		private UUIItem FindFocusTargetRewardItem(int index, int totalCount)
		{
			GenericLayout<LinkageRewardRewardItem, TimePointRewardData> rewardItemBLayout = this.RewardItemBLayout;
			LinkageRewardRewardItem linkageRewardRewardItem = (rewardItemBLayout != null) ? rewardItemBLayout.GetLayoutItemByIndex(index) : null;
			UUIItem uuiitem = (linkageRewardRewardItem != null) ? linkageRewardRewardItem.GetNavigationFocusItem() : null;
			if (uuiitem == null || !uuiitem.IsValid())
			{
				return null;
			}
			return uuiitem;
		}

		// Token: 0x06041F56 RID: 270166 RVA: 0x010EC210 File Offset: 0x010EA410
		private void RefreshKeepRewardPanel(LinkageRewardRewardItemA panel, TimePointRewardData data, int gridIndex)
		{
			if (panel == null)
			{
				return;
			}
			if (data == null)
			{
				panel.SetUiActive(false);
				return;
			}
			panel.SetUiActive(true);
			bool hasConnector = gridIndex > 0;
			panel.RefreshWithNextState(data, false, gridIndex, hasConnector);
		}

		// Token: 0x06041F57 RID: 270167 RVA: 0x010EC244 File Offset: 0x010EA444
		private void OnGetReward(int id, int gridIndex, bool isKeepReward)
		{
			LinkageCheckInType fallbackType = isKeepReward ? LinkageCheckInType.KeepCheckIn : LinkageCheckInType.NormalCheckIn;
			LinkageRewardActivityController.ClaimAllRewardsByController(this.LinkageRewardData.Id, id, fallbackType, delegate
			{
				this.RefreshRewardLayout(false);
			});
		}

		// Token: 0x04024CC3 RID: 150723
		private const int FocusRetryMaxCount = 600;

		// Token: 0x04024CC4 RID: 150724
		private LinkageRewardActivityData LinkageRewardData;

		// Token: 0x04024CC5 RID: 150725
		private LinkageRewardActivityTitle TitleComponent;

		// Token: 0x04024CC6 RID: 150726
		private LinkageRewardRewardItemA RewardItemA1;

		// Token: 0x04024CC7 RID: 150727
		private LinkageRewardRewardItemA RewardItemA2;

		// Token: 0x04024CC8 RID: 150728
		private LinkageRewardRewardItemA RewardItemA3;

		// Token: 0x04024CC9 RID: 150729
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<LinkageRewardRewardItem, TimePointRewardData> RewardItemBLayout;

		// Token: 0x04024CCA RID: 150730
		private UUIScrollViewWithScrollbarComponent RewardItemBScrollView;

		// Token: 0x04024CCB RID: 150731
		private LinkageRewardProgressPanel ProgressPanel;

		// Token: 0x04024CCC RID: 150732
		private bool HasAutoScrolledRewardItemB;

		// Token: 0x04024CCD RID: 150733
		private int AutoScrollRewardItemBRequestId;

		// Token: 0x04024CCE RID: 150734
		private bool HasPendingRefreshRewardLayout;

		// Token: 0x04024CCF RID: 150735
		private int PendingFocusRewardIndex = -1;

		// Token: 0x04024CD0 RID: 150736
		private int PendingFocusRequestId;

		// Token: 0x04024CD1 RID: 150737
		private bool CanApplyGamepadFocus = true;

		// Token: 0x0200C771 RID: 51057
		[NullableContext(0)]
		private static class EComponents
		{
			// Token: 0x0403D675 RID: 251509
			public const int TitleItem = 0;

			// Token: 0x0403D676 RID: 251510
			public const int RewardItemA1 = 1;

			// Token: 0x0403D677 RID: 251511
			public const int RewardItemA2 = 2;

			// Token: 0x0403D678 RID: 251512
			public const int RewardItemA3 = 3;

			// Token: 0x0403D679 RID: 251513
			public const int Progress = 4;

			// Token: 0x0403D67A RID: 251514
			public const int Content = 5;

			// Token: 0x0403D67B RID: 251515
			public const int RewardItemB = 6;
		}
	}
}
