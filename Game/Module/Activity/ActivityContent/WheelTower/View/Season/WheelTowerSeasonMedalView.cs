using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.WheelTower.View.Season
{
	// Token: 0x0200623D RID: 25149
	[NullableContext(1)]
	[Nullable(0)]
	public class WheelTowerSeasonMedalView : UiViewBase
	{
		// Token: 0x0603F697 RID: 259735 RVA: 0x01040CC5 File Offset: 0x0103EEC5
		public WheelTowerSeasonMedalView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603F698 RID: 259736 RVA: 0x01040CF8 File Offset: 0x0103EEF8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 16;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(14, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 2;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(6, new Action(this.OnAllSeasonBtnClick));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(12, new Action(this.OnShareBtnClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603F699 RID: 259737 RVA: 0x01040F98 File Offset: 0x0103F198
		protected override UniTask OnBeforeStartAsync()
		{
			WheelTowerSeasonMedalView.<OnBeforeStartAsync>d__10 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<WheelTowerSeasonMedalView.<OnBeforeStartAsync>d__10>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603F69A RID: 259738 RVA: 0x01040FDC File Offset: 0x0103F1DC
		private UniTask LoadSeasonBgItem()
		{
			WheelTowerSeasonMedalView.<LoadSeasonBgItem>d__11 <LoadSeasonBgItem>d__;
			<LoadSeasonBgItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<LoadSeasonBgItem>d__.<>4__this = this;
			<LoadSeasonBgItem>d__.<>1__state = -1;
			<LoadSeasonBgItem>d__.<>t__builder.Start<WheelTowerSeasonMedalView.<LoadSeasonBgItem>d__11>(ref <LoadSeasonBgItem>d__);
			return <LoadSeasonBgItem>d__.<>t__builder.Task;
		}

		// Token: 0x0603F69B RID: 259739 RVA: 0x0104101F File Offset: 0x0103F21F
		protected override void OnStart()
		{
			this.ReportEnterMedalEvent();
		}

		// Token: 0x0603F69C RID: 259740 RVA: 0x01041028 File Offset: 0x0103F228
		protected override UniTask OnPlayingStartSequenceAsync()
		{
			WheelTowerSeasonMedalView.<OnPlayingStartSequenceAsync>d__13 <OnPlayingStartSequenceAsync>d__;
			<OnPlayingStartSequenceAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnPlayingStartSequenceAsync>d__.<>4__this = this;
			<OnPlayingStartSequenceAsync>d__.<>1__state = -1;
			<OnPlayingStartSequenceAsync>d__.<>t__builder.Start<WheelTowerSeasonMedalView.<OnPlayingStartSequenceAsync>d__13>(ref <OnPlayingStartSequenceAsync>d__);
			return <OnPlayingStartSequenceAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603F69D RID: 259741 RVA: 0x0104106C File Offset: 0x0103F26C
		protected override UniTask OnPlayingCloseSequenceAsync()
		{
			WheelTowerSeasonMedalView.<OnPlayingCloseSequenceAsync>d__14 <OnPlayingCloseSequenceAsync>d__;
			<OnPlayingCloseSequenceAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnPlayingCloseSequenceAsync>d__.<>4__this = this;
			<OnPlayingCloseSequenceAsync>d__.<>1__state = -1;
			<OnPlayingCloseSequenceAsync>d__.<>t__builder.Start<WheelTowerSeasonMedalView.<OnPlayingCloseSequenceAsync>d__14>(ref <OnPlayingCloseSequenceAsync>d__);
			return <OnPlayingCloseSequenceAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603F69E RID: 259742 RVA: 0x010410AF File Offset: 0x0103F2AF
		protected override void OnBeforeShow()
		{
			if (!this.IsFirstShow)
			{
				this.RefreshMedalLayout();
				this.RefreshScoreLayout();
			}
			else
			{
				this.IsFirstShow = false;
			}
			this.RefreshSeasonInfo();
			this.RefreshAllSeasonBtn();
		}

		// Token: 0x0603F69F RID: 259743 RVA: 0x010410DC File Offset: 0x0103F2DC
		private void ReportEnterMedalEvent()
		{
			NewTowerEnterMedalEvent newTowerEnterMedalEvent = new NewTowerEnterMedalEvent();
			newTowerEnterMedalEvent.i_activity_id = ModelBase<WheelTowerModel>.Instance.ActivityData.Id;
			newTowerEnterMedalEvent.i_season_id = this.GetSeasonId();
			ControllerBase<LogReportController>.Instance.LogReport(newTowerEnterMedalEvent);
		}

		// Token: 0x0603F6A0 RID: 259744 RVA: 0x0104111C File Offset: 0x0103F31C
		private void MarkSeasonMedalsRead()
		{
			int seasonId = this.GetSeasonId();
			ModelBase<WheelTowerModel>.Instance.MarkSeasonMedalsRead(seasonId);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, ModelBase<WheelTowerModel>.Instance.ActivityData.Id);
		}

		// Token: 0x0603F6A1 RID: 259745 RVA: 0x0104115C File Offset: 0x0103F35C
		private void SnapshotOldMedalIds()
		{
			this.OldMedalIdMap.Clear();
			WheelTowerModel instance = ModelBase<WheelTowerModel>.Instance;
			foreach (IWheelTowerMedalItemData wheelTowerMedalItemData in this.MedalItemDataList)
			{
				int seasonMedalReadId = instance.GetSeasonMedalReadId(wheelTowerMedalItemData.GroupId);
				if (seasonMedalReadId != 0)
				{
					this.OldMedalIdMap[wheelTowerMedalItemData.GroupId] = seasonMedalReadId;
				}
			}
			foreach (IWheelTowerMedalItemData wheelTowerMedalItemData2 in this.ScoreItemDataList)
			{
				int seasonMedalReadId2 = instance.GetSeasonMedalReadId(wheelTowerMedalItemData2.GroupId);
				if (seasonMedalReadId2 != 0)
				{
					this.OldMedalIdMap[wheelTowerMedalItemData2.GroupId] = seasonMedalReadId2;
				}
			}
		}

		// Token: 0x0603F6A2 RID: 259746 RVA: 0x01041240 File Offset: 0x0103F440
		private void ApplyPreviewMedalIds()
		{
			GenericLayout<WheelTowerSeasonMedalItem, IWheelTowerMedalItemData> medalLayout = this.MedalLayout;
			foreach (WheelTowerSeasonMedalItem wheelTowerSeasonMedalItem in (((medalLayout != null) ? medalLayout.GetLayoutItemList() : null) ?? new List<WheelTowerSeasonMedalItem>()))
			{
				if (wheelTowerSeasonMedalItem.GridIndex >= 0 && wheelTowerSeasonMedalItem.GridIndex < this.MedalItemDataList.Count)
				{
					IWheelTowerMedalItemData wheelTowerMedalItemData = this.MedalItemDataList[wheelTowerSeasonMedalItem.GridIndex];
					int previewMedalId;
					this.OldMedalIdMap.TryGetValue(wheelTowerMedalItemData.GroupId, out previewMedalId);
					wheelTowerSeasonMedalItem.SetPreviewMedalId(previewMedalId);
				}
			}
			GenericLayout<WheelTowerStageMedalItem, IWheelTowerMedalItemData> scoreLayout = this.ScoreLayout;
			foreach (WheelTowerStageMedalItem wheelTowerStageMedalItem in (((scoreLayout != null) ? scoreLayout.GetLayoutItemList() : null) ?? new List<WheelTowerStageMedalItem>()))
			{
				if (wheelTowerStageMedalItem.GridIndex >= 0 && wheelTowerStageMedalItem.GridIndex < this.ScoreItemDataList.Count)
				{
					IWheelTowerMedalItemData wheelTowerMedalItemData2 = this.ScoreItemDataList[wheelTowerStageMedalItem.GridIndex];
					int previewMedalId2;
					this.OldMedalIdMap.TryGetValue(wheelTowerMedalItemData2.GroupId, out previewMedalId2);
					wheelTowerStageMedalItem.SetPreviewMedalId(previewMedalId2);
				}
			}
		}

		// Token: 0x0603F6A3 RID: 259747 RVA: 0x0104138C File Offset: 0x0103F58C
		private void TryAutoShare()
		{
			WheelTowerSeasonMedalViewData wheelTowerSeasonMedalViewData = this.OpenParam as WheelTowerSeasonMedalViewData;
			if (wheelTowerSeasonMedalViewData == null || !wheelTowerSeasonMedalViewData.AutoShare)
			{
				return;
			}
			this.OpenShareView();
		}

		// Token: 0x0603F6A4 RID: 259748 RVA: 0x010413B8 File Offset: 0x0103F5B8
		private void RefreshAllSeasonBtn()
		{
			WheelTowerSeasonMedalViewData wheelTowerSeasonMedalViewData = this.OpenParam as WheelTowerSeasonMedalViewData;
			bool flag = wheelTowerSeasonMedalViewData != null && wheelTowerSeasonMedalViewData.HideAllSeasonBtn;
			UUIButtonComponent button = base.GetButton(6);
			if (button == null)
			{
				return;
			}
			UUIItem rootComponent = button.GetRootComponent();
			if (rootComponent == null)
			{
				return;
			}
			rootComponent.SetUIActive(!flag);
		}

		// Token: 0x0603F6A5 RID: 259749 RVA: 0x010413FC File Offset: 0x0103F5FC
		private void RefreshSeasonInfo()
		{
			int seasonId = this.GetSeasonId();
			if (seasonId == 0)
			{
				return;
			}
			NewTowerSeason? seasonConfig = ConfigBase<WheelTowerConfig>.Instance.GetSeasonConfig(seasonId);
			if (seasonConfig == null)
			{
				return;
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), seasonConfig.Value.Name, Array.Empty<object>());
			base.SetTextureByPath(seasonConfig.Value.VersionIconMain, base.GetTexture(4), null, null);
			UUISprite sprite = base.GetSprite(14);
			if (sprite != null)
			{
				sprite.SetUIActive(this.IsCurrentSeason());
			}
			WheelTowerData activityData = ModelBase<WheelTowerModel>.Instance.ActivityData;
			int num = (activityData != null) ? activityData.SeasonId : 0;
			UUIText text = base.GetText(5);
			if (text != null)
			{
				text.SetUIActive(seasonId <= num);
			}
			if (seasonId < num)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "NewTower_HistorySeason", new <>z__ReadOnlyArray<object>(new object[]
				{
					seasonConfig.Value.StartVersionId,
					seasonConfig.Value.EndVersionId
				}));
				return;
			}
			if (seasonId == num)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "WheelTower_SeasonReward_EndVersion", new <>z__ReadOnlySingleElementList<object>(seasonConfig.Value.EndVersionId));
			}
		}

		// Token: 0x0603F6A6 RID: 259750 RVA: 0x0104152F File Offset: 0x0103F72F
		private void RefreshMedalLayout()
		{
			if (this.MedalItemDataList.Count == 0)
			{
				return;
			}
			GenericLayout<WheelTowerSeasonMedalItem, IWheelTowerMedalItemData> medalLayout = this.MedalLayout;
			if (medalLayout == null)
			{
				return;
			}
			medalLayout.RefreshWithoutDataSync();
		}

		// Token: 0x0603F6A7 RID: 259751 RVA: 0x01041550 File Offset: 0x0103F750
		private UniTask RefreshMedalLayoutAsync()
		{
			WheelTowerSeasonMedalView.<RefreshMedalLayoutAsync>d__24 <RefreshMedalLayoutAsync>d__;
			<RefreshMedalLayoutAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshMedalLayoutAsync>d__.<>4__this = this;
			<RefreshMedalLayoutAsync>d__.<>1__state = -1;
			<RefreshMedalLayoutAsync>d__.<>t__builder.Start<WheelTowerSeasonMedalView.<RefreshMedalLayoutAsync>d__24>(ref <RefreshMedalLayoutAsync>d__);
			return <RefreshMedalLayoutAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603F6A8 RID: 259752 RVA: 0x01041593 File Offset: 0x0103F793
		private void RefreshScoreLayout()
		{
			if (this.ScoreItemDataList.Count == 0)
			{
				return;
			}
			GenericLayout<WheelTowerStageMedalItem, IWheelTowerMedalItemData> scoreLayout = this.ScoreLayout;
			if (scoreLayout == null)
			{
				return;
			}
			scoreLayout.RefreshWithoutDataSync();
		}

		// Token: 0x0603F6A9 RID: 259753 RVA: 0x010415B4 File Offset: 0x0103F7B4
		private UniTask RefreshScoreLayoutAsync()
		{
			WheelTowerSeasonMedalView.<RefreshScoreLayoutAsync>d__26 <RefreshScoreLayoutAsync>d__;
			<RefreshScoreLayoutAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshScoreLayoutAsync>d__.<>4__this = this;
			<RefreshScoreLayoutAsync>d__.<>1__state = -1;
			<RefreshScoreLayoutAsync>d__.<>t__builder.Start<WheelTowerSeasonMedalView.<RefreshScoreLayoutAsync>d__26>(ref <RefreshScoreLayoutAsync>d__);
			return <RefreshScoreLayoutAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603F6AA RID: 259754 RVA: 0x010415F7 File Offset: 0x0103F7F7
		private int GetSeasonId()
		{
			WheelTowerSeasonMedalViewData wheelTowerSeasonMedalViewData = this.OpenParam as WheelTowerSeasonMedalViewData;
			if (wheelTowerSeasonMedalViewData != null)
			{
				return wheelTowerSeasonMedalViewData.SeasonId;
			}
			WheelTowerData activityData = ModelBase<WheelTowerModel>.Instance.ActivityData;
			if (activityData == null)
			{
				return 0;
			}
			return activityData.SeasonId;
		}

		// Token: 0x0603F6AB RID: 259755 RVA: 0x01041623 File Offset: 0x0103F823
		private bool IsCurrentSeason()
		{
			int seasonId = this.GetSeasonId();
			WheelTowerData activityData = ModelBase<WheelTowerModel>.Instance.ActivityData;
			return seasonId == ((activityData != null) ? activityData.SeasonId : 0);
		}

		// Token: 0x0603F6AC RID: 259756 RVA: 0x01041643 File Offset: 0x0103F843
		private WheelTowerSeasonMedalItem CreateMedalItem()
		{
			return new WheelTowerSeasonMedalItem();
		}

		// Token: 0x0603F6AD RID: 259757 RVA: 0x0104164A File Offset: 0x0103F84A
		private WheelTowerStageMedalItem CreateScoreMedalItem()
		{
			return new WheelTowerStageMedalItem();
		}

		// Token: 0x0603F6AE RID: 259758 RVA: 0x01041651 File Offset: 0x0103F851
		private void OnCloseBtnClick()
		{
			base.CloseMe(null);
		}

		// Token: 0x0603F6AF RID: 259759 RVA: 0x0104165A File Offset: 0x0103F85A
		private void OnAllSeasonBtnClick()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.WheelTowerSeasonOverviewView, null, null);
		}

		// Token: 0x0603F6B0 RID: 259760 RVA: 0x0104166D File Offset: 0x0103F86D
		private void OnShareBtnClick()
		{
			this.OpenShareView();
		}

		// Token: 0x0603F6B1 RID: 259761 RVA: 0x01041678 File Offset: 0x0103F878
		private void OpenShareView()
		{
			this.ReportShareEvent();
			UiAsyncTask task = new UiAsyncTask("OpenShareView", delegate()
			{
				WheelTowerSeasonMedalView.<<OpenShareView>b__34_0>d <<OpenShareView>b__34_0>d;
				<<OpenShareView>b__34_0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
				<<OpenShareView>b__34_0>d.<>4__this = this;
				<<OpenShareView>b__34_0>d.<>1__state = -1;
				<<OpenShareView>b__34_0>d.<>t__builder.Start<WheelTowerSeasonMedalView.<<OpenShareView>b__34_0>d>(ref <<OpenShareView>b__34_0>d);
				return <<OpenShareView>b__34_0>d.<>t__builder.Task;
			}, null);
			base.RunAsyncTask(task);
		}

		// Token: 0x0603F6B2 RID: 259762 RVA: 0x010416AC File Offset: 0x0103F8AC
		private void ReportShareEvent()
		{
			int seasonId = this.GetSeasonId();
			WheelTowerModel instance = ModelBase<WheelTowerModel>.Instance;
			List<IWheelTowerMedalGroupData> seasonMedalGroupList = instance.GetSeasonMedalGroupList(seasonId, EWheelTowerMedalType.Season);
			List<IWheelTowerMedalGroupData> seasonMedalGroupList2 = instance.GetSeasonMedalGroupList(seasonId, EWheelTowerMedalType.Stage);
			List<int> list = new List<int>(seasonMedalGroupList.Count + seasonMedalGroupList2.Count);
			foreach (IWheelTowerMedalGroupData wheelTowerMedalGroupData in seasonMedalGroupList)
			{
				list.Add((wheelTowerMedalGroupData.CurrentMedalId != 0) ? wheelTowerMedalGroupData.CurrentMedalId : wheelTowerMedalGroupData.NextMedalId);
			}
			foreach (IWheelTowerMedalGroupData wheelTowerMedalGroupData2 in seasonMedalGroupList2)
			{
				list.Add((wheelTowerMedalGroupData2.CurrentMedalId != 0) ? wheelTowerMedalGroupData2.CurrentMedalId : wheelTowerMedalGroupData2.NextMedalId);
			}
			NewTowerMedalShareEvent newTowerMedalShareEvent = new NewTowerMedalShareEvent();
			newTowerMedalShareEvent.i_season_id = seasonId;
			newTowerMedalShareEvent.s_item_id = string.Join<int>(",", list);
			ControllerBase<LogReportController>.Instance.LogReport(newTowerMedalShareEvent);
		}

		// Token: 0x0603F6B3 RID: 259763 RVA: 0x010417C8 File Offset: 0x0103F9C8
		private UniTask WaitFrame()
		{
			WheelTowerSeasonMedalView.<WaitFrame>d__36 <WaitFrame>d__;
			<WaitFrame>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<WaitFrame>d__.<>1__state = -1;
			<WaitFrame>d__.<>t__builder.Start<WheelTowerSeasonMedalView.<WaitFrame>d__36>(ref <WaitFrame>d__);
			return <WaitFrame>d__.<>t__builder.Task;
		}

		// Token: 0x0603F6B4 RID: 259764 RVA: 0x01041804 File Offset: 0x0103FA04
		private UniTask OpenShareViewAsync()
		{
			WheelTowerSeasonMedalView.<OpenShareViewAsync>d__37 <OpenShareViewAsync>d__;
			<OpenShareViewAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OpenShareViewAsync>d__.<>4__this = this;
			<OpenShareViewAsync>d__.<>1__state = -1;
			<OpenShareViewAsync>d__.<>t__builder.Start<WheelTowerSeasonMedalView.<OpenShareViewAsync>d__37>(ref <OpenShareViewAsync>d__);
			return <OpenShareViewAsync>d__.<>t__builder.Task;
		}

		// Token: 0x04023956 RID: 145750
		[Nullable(2)]
		private PopupCaptionItem CaptionItem;

		// Token: 0x04023957 RID: 145751
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<WheelTowerSeasonMedalItem, IWheelTowerMedalItemData> MedalLayout;

		// Token: 0x04023958 RID: 145752
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<WheelTowerStageMedalItem, IWheelTowerMedalItemData> ScoreLayout;

		// Token: 0x04023959 RID: 145753
		[Nullable(2)]
		private WheelTowerSeasonBgItem SeasonBgItem;

		// Token: 0x0402395A RID: 145754
		private List<IWheelTowerMedalItemData> MedalItemDataList = new List<IWheelTowerMedalItemData>();

		// Token: 0x0402395B RID: 145755
		private List<IWheelTowerMedalItemData> ScoreItemDataList = new List<IWheelTowerMedalItemData>();

		// Token: 0x0402395C RID: 145756
		private bool IsFirstShow = true;

		// Token: 0x0402395D RID: 145757
		private readonly Dictionary<int, int> OldMedalIdMap = new Dictionary<int, int>();
	}
}
