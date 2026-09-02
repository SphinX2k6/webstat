using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Activity.ActivityContent.MoonChasing;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x020063D8 RID: 25560
	[NullableContext(2)]
	[Nullable(0)]
	public class ActivitySubViewRoverlike : ActivitySubViewBase
	{
		// Token: 0x17009DBE RID: 40382
		// (get) Token: 0x06040301 RID: 262913 RVA: 0x01073426 File Offset: 0x01071626
		protected new RoverlikeActivityData ActivityBaseData
		{
			get
			{
				return this.ActivityBaseData as RoverlikeActivityData;
			}
		}

		// Token: 0x06040302 RID: 262914 RVA: 0x01073434 File Offset: 0x01071634
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(USpineSkeletonAnimationComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(USpineSkeletonAnimationComponent));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06040303 RID: 262915 RVA: 0x01073500 File Offset: 0x01071700
		protected override UniTask OnBeforeStartAsync()
		{
			ActivitySubViewRoverlike.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<ActivitySubViewRoverlike.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06040304 RID: 262916 RVA: 0x01073544 File Offset: 0x01071744
		protected override void OnBeforeShow()
		{
			this.OnRefreshView();
			this.RefreshGenderSpine();
			RoverlikeQuestRewardButton questRewardBtn = this.QuestRewardBtn;
			if (questRewardBtn != null)
			{
				questRewardBtn.BindRedDot();
			}
			RoverlikeShopRewardButton shopRewardBtn = this.ShopRewardBtn;
			if (shopRewardBtn != null)
			{
				shopRewardBtn.BindRedDot();
			}
			Singleton<EventSystem>.Instance.Add<int>(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnRefreshCommonActivityRedDot));
		}

		// Token: 0x06040305 RID: 262917 RVA: 0x0107359B File Offset: 0x0107179B
		protected override void OnBeforeHide()
		{
			RoverlikeQuestRewardButton questRewardBtn = this.QuestRewardBtn;
			if (questRewardBtn != null)
			{
				questRewardBtn.UnBindRedDot();
			}
			RoverlikeShopRewardButton shopRewardBtn = this.ShopRewardBtn;
			if (shopRewardBtn != null)
			{
				shopRewardBtn.UnBindRedDot();
			}
			Singleton<EventSystem>.Instance.Remove<int>(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnRefreshCommonActivityRedDot));
		}

		// Token: 0x06040306 RID: 262918 RVA: 0x010735DC File Offset: 0x010717DC
		private void OnRefreshCommonActivityRedDot(int activityId)
		{
			RoverlikeActivityData activityBaseData = this.ActivityBaseData;
			int? num = (activityBaseData != null) ? new int?(activityBaseData.Id) : null;
			if (!(activityId == num.GetValueOrDefault() & num != null))
			{
				return;
			}
			ActivitySubViewGeneralInfo commonInfoPanel = this.CommonInfoPanel;
			if (commonInfoPanel == null)
			{
				return;
			}
			commonInfoPanel.SetFunctionRedDotVisible(this.GetFunctionRedDotState());
		}

		// Token: 0x06040307 RID: 262919 RVA: 0x01073634 File Offset: 0x01071834
		protected void OnTimer(int gap)
		{
		}

		// Token: 0x06040308 RID: 262920 RVA: 0x01073636 File Offset: 0x01071836
		protected override void OnRefreshView()
		{
			ActivitySubViewGeneralInfo commonInfoPanel = this.CommonInfoPanel;
			if (commonInfoPanel != null)
			{
				commonInfoPanel.OnRefreshView();
			}
			ActivitySubViewGeneralInfo commonInfoPanel2 = this.CommonInfoPanel;
			if (commonInfoPanel2 != null)
			{
				commonInfoPanel2.SetFunctionRedDotVisible(this.GetFunctionRedDotState());
			}
			this.RefreshRewardProgress();
		}

		// Token: 0x06040309 RID: 262921 RVA: 0x01073668 File Offset: 0x01071868
		private void RefreshGenderSpine()
		{
			bool flag = ModelBase<PlayerInfoModel>.Instance.GetPlayerGender() == EPlayerGender.Male;
			this.SetSpineActiveAndPlay(base.GetSpine(3), flag);
			this.SetSpineActiveAndPlay(base.GetSpine(4), !flag);
		}

		// Token: 0x0604030A RID: 262922 RVA: 0x010736A4 File Offset: 0x010718A4
		private void SetSpineActiveAndPlay(USpineSkeletonAnimationComponent spine, bool active)
		{
			if (spine == null)
			{
				return;
			}
			UUIItem uuiitem = spine.GetOwner().GetComponentByClass(UUIItem.StaticClass()) as UUIItem;
			if (uuiitem != null)
			{
				uuiitem.SetUIActive(active);
			}
			if (active)
			{
				spine.SetAnimation(0, ESpineAnimation.Idle.ToString(), true);
			}
		}

		// Token: 0x0604030B RID: 262923 RVA: 0x010736F8 File Offset: 0x010718F8
		private void RefreshRewardProgress()
		{
			RoverlikeActivityData activityBaseData = this.ActivityBaseData;
			if (activityBaseData == null)
			{
				return;
			}
			ValueTuple<int, int> questProgress = activityBaseData.GetQuestProgress();
			RoverlikeQuestRewardButton questRewardBtn = this.QuestRewardBtn;
			if (questRewardBtn != null)
			{
				questRewardBtn.SetProgressNumText(questProgress.Item1, questProgress.Item2);
			}
			ValueTuple<int, int> shopProgress = activityBaseData.GetShopProgress();
			RoverlikeShopRewardButton shopRewardBtn = this.ShopRewardBtn;
			if (shopRewardBtn == null)
			{
				return;
			}
			shopRewardBtn.SetProgressNumText(shopProgress.Item1, shopProgress.Item2);
		}

		// Token: 0x0604030C RID: 262924 RVA: 0x01073757 File Offset: 0x01071957
		private bool GetFunctionRedDotState()
		{
			RoverlikeActivityData activityBaseData = this.ActivityBaseData;
			return activityBaseData != null && activityBaseData.HasNewLevelUnlockRedDot();
		}

		// Token: 0x0604030D RID: 262925 RVA: 0x0107376C File Offset: 0x0107196C
		private void OnEnterBtnClick(ActivityBaseData _)
		{
			if (!this.ActivityBaseData.GetPreGuideQuestFinishState())
			{
				int unFinishPreGuideQuestId = this.ActivityBaseData.GetUnFinishPreGuideQuestId();
				Singleton<UiManager>.Instance.OpenView(EUiViewName.QuestView, unFinishPreGuideQuestId, null);
				return;
			}
			Singleton<UiManager>.Instance.OpenView(EUiViewName.RoverlikeMainView, this.ActivityBaseData, null);
		}

		// Token: 0x0402400E RID: 147470
		protected ActivitySubViewGeneralInfo CommonInfoPanel;

		// Token: 0x0402400F RID: 147471
		protected RoverlikeShopRewardButton ShopRewardBtn;

		// Token: 0x04024010 RID: 147472
		protected RoverlikeQuestRewardButton QuestRewardBtn;

		// Token: 0x0200C43E RID: 50238
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x0403C68A RID: 247434
			public const int CommonActionInfo = 0;

			// Token: 0x0403C68B RID: 247435
			public const int NormalRewardBtn = 1;

			// Token: 0x0403C68C RID: 247436
			public const int LimitedTimeRewardBtn = 2;

			// Token: 0x0403C68D RID: 247437
			public const int SpineMale = 3;

			// Token: 0x0403C68E RID: 247438
			public const int SpineFemale = 4;
		}
	}
}
