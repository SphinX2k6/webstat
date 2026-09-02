using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Main;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Level
{
	// Token: 0x02006601 RID: 26113
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class PinballDailyLevelView : PinballMainChildViewBase<PinballMainViewModel>
	{
		// Token: 0x06041406 RID: 267270 RVA: 0x010BD28C File Offset: 0x010BB48C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 1;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int index = 0;
			*span[index] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06041407 RID: 267271 RVA: 0x010BD2D4 File Offset: 0x010BB4D4
		protected override UniTask OnBeforeStartAsync()
		{
			PinballDailyLevelView.<OnBeforeStartAsync>d__3 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<PinballDailyLevelView.<OnBeforeStartAsync>d__3>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06041408 RID: 267272 RVA: 0x010BD318 File Offset: 0x010BB518
		protected override UniTask OnPlayingStartSequenceAsync()
		{
			PinballDailyLevelView.<OnPlayingStartSequenceAsync>d__4 <OnPlayingStartSequenceAsync>d__;
			<OnPlayingStartSequenceAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnPlayingStartSequenceAsync>d__.<>4__this = this;
			<OnPlayingStartSequenceAsync>d__.<>1__state = -1;
			<OnPlayingStartSequenceAsync>d__.<>t__builder.Start<PinballDailyLevelView.<OnPlayingStartSequenceAsync>d__4>(ref <OnPlayingStartSequenceAsync>d__);
			return <OnPlayingStartSequenceAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06041409 RID: 267273 RVA: 0x010BD35B File Offset: 0x010BB55B
		protected override void OnBeforeShow()
		{
			this.SetCaptionInfo();
		}

		// Token: 0x0604140A RID: 267274 RVA: 0x010BD364 File Offset: 0x010BB564
		protected override UniTask OnPlayingCloseSequenceAsync()
		{
			PinballDailyLevelView.<OnPlayingCloseSequenceAsync>d__6 <OnPlayingCloseSequenceAsync>d__;
			<OnPlayingCloseSequenceAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnPlayingCloseSequenceAsync>d__.<>4__this = this;
			<OnPlayingCloseSequenceAsync>d__.<>1__state = -1;
			<OnPlayingCloseSequenceAsync>d__.<>t__builder.Start<PinballDailyLevelView.<OnPlayingCloseSequenceAsync>d__6>(ref <OnPlayingCloseSequenceAsync>d__);
			return <OnPlayingCloseSequenceAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0604140B RID: 267275 RVA: 0x010BD3A8 File Offset: 0x010BB5A8
		private void SetCaptionInfo()
		{
			if (base.ViewModel != null)
			{
				PinballChapterData dailyChapterData = ModelBase<PinballModel>.Instance.ActivityData.GetDailyChapterData();
				PinballChapterConfig? pinballChapterConfigById = ConfigBase<PinballConfig>.Instance.GetPinballChapterConfigById(dailyChapterData.ChapterId);
				Action<string> setViewTitle = base.ViewModel.SetViewTitle;
				if (setViewTitle != null)
				{
					setViewTitle(pinballChapterConfigById.Value.Name);
				}
				Action<int> setViewHelpId = base.ViewModel.SetViewHelpId;
				if (setViewHelpId != null)
				{
					setViewHelpId(556);
				}
				base.ViewModel.SetOverrideCloseFunc(new Action(this.OnBtnBackClick));
			}
		}

		// Token: 0x0604140C RID: 267276 RVA: 0x010BD438 File Offset: 0x010BB638
		private void RefreshLevelInfo()
		{
			PinballActivityData activityData = ModelBase<PinballModel>.Instance.ActivityData;
			int dailyConfigId = activityData.GetDailyConfigId();
			int dailyRandomLevelId = activityData.GetDailyRandomLevelId();
			int curDailyRewardDropId = activityData.GetCurDailyRewardDropId();
			PinballLevelInfoData data = new PinballLevelInfoData
			{
				LevelId = dailyConfigId,
				RealLevelId = dailyRandomLevelId,
				RewardDropId = new int?(curDailyRewardDropId),
				RewardClearTitle = "Pinball_Level_DailyClear",
				ShowDesc = new bool?(true),
				ShowReward = new bool?(true)
			};
			this.LevelInfoPanel.Refresh(data);
		}

		// Token: 0x0604140D RID: 267277 RVA: 0x010BD4B4 File Offset: 0x010BB6B4
		private void OnBtnBackClick()
		{
			if (this.RootView.GetChildViewStackNum() > 1)
			{
				base.BackToLastView();
				return;
			}
			UiAsyncTask task = new UiAsyncTask("PinballDailyLevelViewToMainView", delegate()
			{
				PinballDailyLevelView.<<OnBtnBackClick>b__9_0>d <<OnBtnBackClick>b__9_0>d;
				<<OnBtnBackClick>b__9_0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
				<<OnBtnBackClick>b__9_0>d.<>4__this = this;
				<<OnBtnBackClick>b__9_0>d.<>1__state = -1;
				<<OnBtnBackClick>b__9_0>d.<>t__builder.Start<PinballDailyLevelView.<<OnBtnBackClick>b__9_0>d>(ref <<OnBtnBackClick>b__9_0>d);
				return <<OnBtnBackClick>b__9_0>d.<>t__builder.Task;
			}, null);
			base.RunAsyncTask(task).Forget();
		}

		// Token: 0x0402486B RID: 149611
		[Nullable(2)]
		private PinballLevelInfoPanel LevelInfoPanel;

		// Token: 0x0200C61D RID: 50717
		private enum EComponent
		{
			// Token: 0x0403CFB3 RID: 249779
			LevelDetailTips
		}
	}
}
