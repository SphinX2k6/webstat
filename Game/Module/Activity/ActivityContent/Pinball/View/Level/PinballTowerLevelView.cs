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
	// Token: 0x02006608 RID: 26120
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class PinballTowerLevelView : PinballMainChildViewBase<PinballMainViewModel>
	{
		// Token: 0x06041442 RID: 267330 RVA: 0x010BEDE0 File Offset: 0x010BCFE0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 10;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 3;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnBtnRankingClick));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(6, new Action(this.OnBtnLeftClick));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(7, new Action(this.OnBtnRightClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06041443 RID: 267331 RVA: 0x010BEFD8 File Offset: 0x010BD1D8
		protected override UniTask OnBeforeStartAsync()
		{
			PinballTowerLevelView.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<PinballTowerLevelView.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06041444 RID: 267332 RVA: 0x010BF01C File Offset: 0x010BD21C
		protected override UniTask OnPlayingStartSequenceAsync()
		{
			PinballTowerLevelView.<OnPlayingStartSequenceAsync>d__7 <OnPlayingStartSequenceAsync>d__;
			<OnPlayingStartSequenceAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnPlayingStartSequenceAsync>d__.<>4__this = this;
			<OnPlayingStartSequenceAsync>d__.<>1__state = -1;
			<OnPlayingStartSequenceAsync>d__.<>t__builder.Start<PinballTowerLevelView.<OnPlayingStartSequenceAsync>d__7>(ref <OnPlayingStartSequenceAsync>d__);
			return <OnPlayingStartSequenceAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06041445 RID: 267333 RVA: 0x010BF05F File Offset: 0x010BD25F
		protected override void OnBeforeShow()
		{
			this.SetCaptionInfo();
		}

		// Token: 0x06041446 RID: 267334 RVA: 0x010BF068 File Offset: 0x010BD268
		protected override UniTask OnPlayingCloseSequenceAsync()
		{
			PinballTowerLevelView.<OnPlayingCloseSequenceAsync>d__9 <OnPlayingCloseSequenceAsync>d__;
			<OnPlayingCloseSequenceAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnPlayingCloseSequenceAsync>d__.<>4__this = this;
			<OnPlayingCloseSequenceAsync>d__.<>1__state = -1;
			<OnPlayingCloseSequenceAsync>d__.<>t__builder.Start<PinballTowerLevelView.<OnPlayingCloseSequenceAsync>d__9>(ref <OnPlayingCloseSequenceAsync>d__);
			return <OnPlayingCloseSequenceAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06041447 RID: 267335 RVA: 0x010BF0AC File Offset: 0x010BD2AC
		private void SetCaptionInfo()
		{
			if (base.ViewModel != null)
			{
				PinballChapterData chapterData = base.ViewModel.GetChapterData();
				PinballChapterConfig? pinballChapterConfigById = ConfigBase<PinballConfig>.Instance.GetPinballChapterConfigById(chapterData.ChapterId);
				Action<string> setViewTitle = base.ViewModel.SetViewTitle;
				if (setViewTitle != null)
				{
					setViewTitle(pinballChapterConfigById.Value.Name);
				}
				Action<int> setViewHelpId = base.ViewModel.SetViewHelpId;
				if (setViewHelpId != null)
				{
					setViewHelpId(557);
				}
				base.ViewModel.SetOverrideCloseFunc(new Action(this.OnBtnBackClick));
			}
		}

		// Token: 0x06041448 RID: 267336 RVA: 0x010BF138 File Offset: 0x010BD338
		private int AutoFindFloorIndex()
		{
			int result = this.LevelDataList.Count - 1;
			for (int i = 0; i < this.LevelDataList.Count; i++)
			{
				if (this.LevelDataList[i].PassStatus == EPinballLevelPassStatus.Unfinished)
				{
					result = i;
					break;
				}
			}
			return result;
		}

		// Token: 0x06041449 RID: 267337 RVA: 0x010BF182 File Offset: 0x010BD382
		private bool IsLevelLock(int levelId)
		{
			return ModelBase<PinballModel>.Instance.ActivityData.GetLevelLockStatus(levelId) != EPinballChapterLevelLockStatus.Activated;
		}

		// Token: 0x0604144A RID: 267338 RVA: 0x010BF19A File Offset: 0x010BD39A
		private string GetLevelLockTexts(int levelId)
		{
			return ModelBase<PinballModel>.Instance.ActivityData.GetLevelPreConditionLockTexts(levelId);
		}

		// Token: 0x0604144B RID: 267339 RVA: 0x010BF1AC File Offset: 0x010BD3AC
		private void RefreshLevelInfo()
		{
			PinballLevelRecordData pinballLevelRecordData = this.LevelDataList[this.CurFloorIndex];
			bool value = this.IsLevelLock(pinballLevelRecordData.LevelId);
			string levelLockTexts = this.GetLevelLockTexts(pinballLevelRecordData.LevelId);
			PinballLevelInfoData data = new PinballLevelInfoData
			{
				LevelId = pinballLevelRecordData.LevelId,
				RealLevelId = pinballLevelRecordData.LevelId,
				LevelStarConditionIds = pinballLevelRecordData.LevelStarConditionIds,
				LevelLock = new bool?(value),
				LevelLockTexts = levelLockTexts,
				ShowStar = new bool?(true),
				ShowReward = new bool?(true),
				RewardReceived = new bool?(pinballLevelRecordData.LevelStarConditionIds.Length != 0)
			};
			this.LevelInfoPanel.Refresh(data);
			PinballLevelConfig? pinballLevelConfigById = ConfigBase<PinballConfig>.Instance.GetPinballLevelConfigById(pinballLevelRecordData.LevelId);
			bool isTowerBoss = pinballLevelConfigById.Value.IsTowerBoss;
			string item = pinballLevelConfigById.Value.TowerNum.ToString();
			bool uiactive = pinballLevelRecordData.PassStatus == EPinballLevelPassStatus.Perfect;
			string timeDataFormatWithHour = Singleton<TimeUtil>.Instance.GetTimeDataFormatWithHour((double)pinballLevelRecordData.LevelPassedTime);
			base.GetItem(2).SetUIActive(!isTowerBoss);
			base.GetItem(4).SetUIActive(isTowerBoss);
			base.GetItem(8).SetUIActive(uiactive);
			base.GetButton(6).RootUIComp.Get().SetUIActive(this.CurFloorIndex > 0);
			base.GetButton(7).RootUIComp.Get().SetUIActive(this.CurFloorIndex < this.LevelDataList.Count - 1);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(9), "Pinball_Level_TowerTime", new <>z__ReadOnlySingleElementList<object>(timeDataFormatWithHour));
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), "Pinball_Level_EndlessFloor", new <>z__ReadOnlySingleElementList<object>(item));
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), "Pinball_Level_EndlessFloor", new <>z__ReadOnlySingleElementList<object>(item));
		}

		// Token: 0x0604144C RID: 267340 RVA: 0x010BF390 File Offset: 0x010BD590
		private void OnBtnRankingClick()
		{
			PinballActivityData activityData = ModelBase<PinballModel>.Instance.ActivityData;
			if (activityData != null)
			{
				Singleton<UiManager>.Instance.OpenView(EUiViewName.PinballRankView, activityData, null);
			}
		}

		// Token: 0x0604144D RID: 267341 RVA: 0x010BF3BC File Offset: 0x010BD5BC
		private void OnBtnLeftClick()
		{
			this.CurFloorIndex = Math.Max(this.CurFloorIndex - 1, 0);
			this.SeqPlayer.StopSequenceByKey("Switch", false, false);
			this.SeqPlayer.PlayLevelSequenceByName("Switch", false, null, false);
			this.RefreshLevelInfo();
		}

		// Token: 0x0604144E RID: 267342 RVA: 0x010BF410 File Offset: 0x010BD610
		private void OnBtnRightClick()
		{
			this.CurFloorIndex = Math.Min(this.CurFloorIndex + 1, this.LevelDataList.Count - 1);
			this.SeqPlayer.StopSequenceByKey("Switch", false, false);
			this.SeqPlayer.PlayLevelSequenceByName("Switch", false, null, false);
			this.RefreshLevelInfo();
		}

		// Token: 0x0604144F RID: 267343 RVA: 0x010BF470 File Offset: 0x010BD670
		private void OnBtnBackClick()
		{
			base.ViewModel.ClearSelectLevelData();
			if (this.RootView.GetChildViewStackNum() > 1)
			{
				base.BackToLastView();
				return;
			}
			UiAsyncTask task = new UiAsyncTask("PinballLevelViewToMainView", delegate()
			{
				PinballTowerLevelView.<<OnBtnBackClick>b__18_0>d <<OnBtnBackClick>b__18_0>d;
				<<OnBtnBackClick>b__18_0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
				<<OnBtnBackClick>b__18_0>d.<>4__this = this;
				<<OnBtnBackClick>b__18_0>d.<>1__state = -1;
				<<OnBtnBackClick>b__18_0>d.<>t__builder.Start<PinballTowerLevelView.<<OnBtnBackClick>b__18_0>d>(ref <<OnBtnBackClick>b__18_0>d);
				return <<OnBtnBackClick>b__18_0>d.<>t__builder.Task;
			}, null);
			base.RunAsyncTask(task).Forget();
		}

		// Token: 0x0402487D RID: 149629
		[Nullable(2)]
		private PinballLevelInfoPanel LevelInfoPanel;

		// Token: 0x0402487E RID: 149630
		private List<PinballLevelRecordData> LevelDataList;

		// Token: 0x0402487F RID: 149631
		private LevelSequencePlayer SeqPlayer;

		// Token: 0x04024880 RID: 149632
		private int CurFloorIndex;

		// Token: 0x0200C630 RID: 50736
		[NullableContext(0)]
		private enum EComponent
		{
			// Token: 0x0403D01C RID: 249884
			LevelDetailTips,
			// Token: 0x0403D01D RID: 249885
			BtnRanking,
			// Token: 0x0403D01E RID: 249886
			NormalItem,
			// Token: 0x0403D01F RID: 249887
			TxtNormalFloor,
			// Token: 0x0403D020 RID: 249888
			BossItem,
			// Token: 0x0403D021 RID: 249889
			TxtBossFloor,
			// Token: 0x0403D022 RID: 249890
			BtnLeft,
			// Token: 0x0403D023 RID: 249891
			BtnRight,
			// Token: 0x0403D024 RID: 249892
			TimeRecordItem,
			// Token: 0x0403D025 RID: 249893
			TxtTimeRecord
		}
	}
}
