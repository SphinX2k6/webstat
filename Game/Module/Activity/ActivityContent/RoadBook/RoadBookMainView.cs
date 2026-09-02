using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Reward;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RoadBook
{
	// Token: 0x0200649B RID: 25755
	[NullableContext(1)]
	[Nullable(0)]
	public class RoadBookMainView : UiViewBase
	{
		// Token: 0x06040954 RID: 264532 RVA: 0x0108DBB7 File Offset: 0x0108BDB7
		public RoadBookMainView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06040955 RID: 264533 RVA: 0x0108DBD4 File Offset: 0x0108BDD4
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUITexture)),
				new ValueTuple<int, Type>(2, typeof(UUIArtText)),
				new ValueTuple<int, Type>(3, typeof(UUIArtText)),
				new ValueTuple<int, Type>(4, typeof(UUIText)),
				new ValueTuple<int, Type>(5, typeof(UUIItem)),
				new ValueTuple<int, Type>(6, typeof(UUIItem)),
				new ValueTuple<int, Type>(9, typeof(UUIItem)),
				new ValueTuple<int, Type>(8, typeof(UUIItem)),
				new ValueTuple<int, Type>(7, typeof(UUIItem)),
				new ValueTuple<int, Type>(10, typeof(UUIScrollViewWithScrollbarComponent)),
				new ValueTuple<int, Type>(11, typeof(UUIItem)),
				new ValueTuple<int, Type>(12, typeof(UUIText)),
				new ValueTuple<int, Type>(13, typeof(UUITexture)),
				new ValueTuple<int, Type>(14, typeof(UUITexture)),
				new ValueTuple<int, Type>(15, typeof(UUIItem)),
				new ValueTuple<int, Type>(16, typeof(UUIItem)),
				new ValueTuple<int, Type>(17, typeof(UUIItem)),
				new ValueTuple<int, Type>(18, typeof(UUIText)),
				new ValueTuple<int, Type>(19, typeof(UUIItem)),
				new ValueTuple<int, Type>(20, typeof(UUIItem))
			};
		}

		// Token: 0x06040956 RID: 264534 RVA: 0x0108DDC8 File Offset: 0x0108BFC8
		protected override UniTask OnBeforeStartAsync()
		{
			RoadBookMainView.<OnBeforeStartAsync>d__12 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RoadBookMainView.<OnBeforeStartAsync>d__12>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06040957 RID: 264535 RVA: 0x0108DE0B File Offset: 0x0108C00B
		protected override void OnStart()
		{
			this.SelectedLevel = this.ActivityBaseData.TravelLevel;
		}

		// Token: 0x06040958 RID: 264536 RVA: 0x0108DE1E File Offset: 0x0108C01E
		protected override void OnBeforeShow()
		{
			this.RefreshExpComponent(this.SelectedLevel);
			this.RefreshSubViewButton();
		}

		// Token: 0x06040959 RID: 264537 RVA: 0x0108DE32 File Offset: 0x0108C032
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<EUiViewName, int>(EEventName.CloseView, new Action<EUiViewName, int>(this.OnRewardViewClose));
		}

		// Token: 0x0604095A RID: 264538 RVA: 0x0108DE4D File Offset: 0x0108C04D
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove<EUiViewName, int>(EEventName.CloseView, new Action<EUiViewName, int>(this.OnRewardViewClose));
		}

		// Token: 0x0604095B RID: 264539 RVA: 0x0108DE68 File Offset: 0x0108C068
		protected override void OnBeforeDestroy()
		{
		}

		// Token: 0x0604095C RID: 264540 RVA: 0x0108DE6C File Offset: 0x0108C06C
		private UniTask CreateSubViewButton()
		{
			RoadBookMainView.<CreateSubViewButton>d__18 <CreateSubViewButton>d__;
			<CreateSubViewButton>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateSubViewButton>d__.<>4__this = this;
			<CreateSubViewButton>d__.<>1__state = -1;
			<CreateSubViewButton>d__.<>t__builder.Start<RoadBookMainView.<CreateSubViewButton>d__18>(ref <CreateSubViewButton>d__);
			return <CreateSubViewButton>d__.<>t__builder.Task;
		}

		// Token: 0x0604095D RID: 264541 RVA: 0x0108DEB0 File Offset: 0x0108C0B0
		protected void OnOpenSubView(ERoadBookSubType type)
		{
			switch (type)
			{
			case ERoadBookSubType.TravelTask:
				Singleton<UiManager>.Instance.OpenView(EUiViewName.RoadBookTravelTaskView, this.ActivityBaseData, null);
				return;
			case ERoadBookSubType.PhantomQuest:
				break;
			case ERoadBookSubType.PhantomCollect:
				Singleton<UiManager>.Instance.OpenView(EUiViewName.RoadBookPhantomTaskView, this.ActivityBaseData, null);
				break;
			case ERoadBookSubType.MotorChallenge:
				Singleton<UiManager>.Instance.OpenView(EUiViewName.RoadBookVehicleTaskView, this.ActivityBaseData, null);
				return;
			default:
				return;
			}
		}

		// Token: 0x0604095E RID: 264542 RVA: 0x0108DF1A File Offset: 0x0108C11A
		private void OnClickedLevelUpButton()
		{
			ControllerBase<ActivityRoadBookController>.Instance.RequestRoadBookLevelUp(delegate(bool success)
			{
				this.NeedLevelUp = success;
				this.LevelUp();
			});
		}

		// Token: 0x0604095F RID: 264543 RVA: 0x0108DF34 File Offset: 0x0108C134
		private void LevelUp()
		{
			if (this.NeedLevelUp)
			{
				this.UiViewSequence.PlaySequence("LevelUp", false, null);
				if (this.SelectedLevel < this.ActivityBaseData.MaxTravelLevel)
				{
					this.SelectedLevel++;
				}
				this.RefreshExpComponent(this.SelectedLevel);
				this.RefreshSubViewButton();
				this.NeedLevelUp = false;
			}
		}

		// Token: 0x06040960 RID: 264544 RVA: 0x0108DF9D File Offset: 0x0108C19D
		private void OnRewardViewClose(EUiViewName viewName, int viewId)
		{
			if (this.SelectedViewType != ERoadBookSubType.Main)
			{
				return;
			}
			if (viewName == EUiViewName.CommonRewardView)
			{
				this.LevelUp();
			}
			if (viewName == EUiViewName.RoleLevelUpSuccessAttributeView)
			{
				this.LevelUp();
			}
		}

		// Token: 0x06040961 RID: 264545 RVA: 0x0108DFD0 File Offset: 0x0108C1D0
		private void RefreshExpComponent(int level)
		{
			bool hasClaimed = level < this.ActivityBaseData.TravelLevel;
			if (level < this.ActivityBaseData.TravelLevel)
			{
				this.SetPerformanceFinishedLevel(level);
			}
			else if (level == this.ActivityBaseData.TravelLevel)
			{
				this.SetPerformanceCurrentLevel(level);
			}
			else
			{
				this.SetPerformanceUnFinishedLevel(level);
			}
			if (this.ActivityBaseData.CanTravelLevelUp())
			{
				this.BtnLeft.SetRedDotVisible(level > this.ActivityBaseData.TravelLevel);
				this.BtnRight.SetRedDotVisible(level < this.ActivityBaseData.TravelLevel);
			}
			else
			{
				this.BtnLeft.SetRedDotVisible(false);
				this.BtnRight.SetRedDotVisible(false);
			}
			IRoadBookLevelData roadBookLevelData;
			this.ActivityBaseData.TravelLevelData.TryGetValue(level, out roadBookLevelData);
			if (roadBookLevelData == null)
			{
				return;
			}
			RoadBookLevelExp value = ConfigBase<ActivityRoadBookConfig>.Instance.GetLevelExpConfig(roadBookLevelData.Id).Value;
			base.GetArtText(2).SetText(level.ToString());
			base.GetArtText(3).SetText(level.ToString());
			List<TItem> list = (value.RewardDropId > 0) ? ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackagePreviewItemList(value.RewardDropId) : new List<TItem>();
			List<IItemGridData> list2 = new List<IItemGridData>();
			foreach (TItem item in list)
			{
				ItemGridData item2 = new ItemGridData
				{
					Item = item,
					HasClaimed = hasClaimed
				};
				list2.Add(item2);
			}
			this.LevelRewardLayout.RefreshByData(list2, null, false);
			UUIText text = base.GetText(12);
			if (text != null)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(3, 1);
				defaultInterpolatedStringHandler.AppendLiteral("Lv.");
				defaultInterpolatedStringHandler.AppendFormatted<int>(level + 1);
				text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
			}
			base.GetItem(6).SetUIActive(level > 0);
			base.GetItem(5).SetUIActive(level < this.ActivityBaseData.MaxTravelLevel);
		}

		// Token: 0x06040962 RID: 264546 RVA: 0x0108E1C8 File Offset: 0x0108C3C8
		private void RefreshSubViewButton()
		{
			foreach (KeyValuePair<ERoadBookSubType, RoadBookSubViewButton> keyValuePair in this.SubViewButtonMap)
			{
				ERoadBookSubType key = keyValuePair.Key;
				RoadBookSubViewButton value = keyValuePair.Value;
				ValueTuple<int, int> typeProgress = this.ActivityBaseData.GetTypeProgress(key);
				int item = typeProgress.Item1;
				int item2 = typeProgress.Item2;
				int value2 = (int)Math.Ceiling((double)item / (double)item2 * 100.0);
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
				defaultInterpolatedStringHandler.AppendFormatted<int>(value2);
				defaultInterpolatedStringHandler.AppendLiteral("%");
				value.SetProgressText(defaultInterpolatedStringHandler.ToStringAndClear());
				bool typeRedDotState = this.ActivityBaseData.GetTypeRedDotState(key);
				bool typeNewState = this.ActivityBaseData.GetTypeNewState(key);
				value.RefreshRedDot(typeRedDotState || typeNewState);
			}
		}

		// Token: 0x06040963 RID: 264547 RVA: 0x0108E2AC File Offset: 0x0108C4AC
		private void SetLevelProgress(int current, int target)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), "RoadBookExp_Text", new <>z__ReadOnlyArray<object>(new object[]
			{
				current,
				target
			}));
			base.GetText(4).SetUIActive(true);
		}

		// Token: 0x06040964 RID: 264548 RVA: 0x0108E2FC File Offset: 0x0108C4FC
		private void SetPerformanceFinishedLevel(int level)
		{
			base.GetItem(17).SetUIActive(true);
			base.GetItem(19).SetUIActive(true);
			base.GetItem(15).SetUIActive(true);
			base.GetItem(16).SetUIActive(false);
			if (level != this.ActivityBaseData.TravelLevel)
			{
				this.LevelUpButton.SetEnableClick(false);
				this.LevelUpButton.SetRedDotVisible(false);
				this.LevelUpButton.SetShowText("RoadBookClaimed_Text");
			}
			else
			{
				this.LevelUpButton.SetShowText("RoadBookLevelUp_Text");
				this.LevelUpButton.SetRedDotVisible(false);
				this.LevelUpButton.SetEnableClick(false);
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), "RoadBookLevelMax_Text", Array.Empty<object>());
		}

		// Token: 0x06040965 RID: 264549 RVA: 0x0108E3BC File Offset: 0x0108C5BC
		private void SetPerformanceCurrentLevel(int level)
		{
			bool flag = this.ActivityBaseData.MaxTravelLevel == level;
			bool flag2 = !flag && this.ActivityBaseData.CanTravelLevelUp();
			int currentExp = this.ActivityBaseData.GetCurrentExp();
			int currentTargetExp = this.ActivityBaseData.GetCurrentTargetExp();
			base.GetItem(17).SetUIActive(true);
			base.GetItem(19).SetUIActive(true);
			if (flag)
			{
				base.GetItem(15).SetUIActive(true);
				base.GetItem(16).SetUIActive(true);
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(18), "PrefabTextItem_2612260890_Text", Array.Empty<object>());
				base.GetItem(20).SetUIActive(true);
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), "RoadBookLevelMax_Text", Array.Empty<object>());
				base.GetText(4).SetUIActive(true);
			}
			else
			{
				this.SetLevelProgress(currentExp, currentTargetExp);
				base.GetItem(15).SetUIActive(false);
				base.GetItem(16).SetUIActive(false);
			}
			if (flag2)
			{
				this.UiViewSequence.PlaySequence("PreLevelUp", false, null);
				this.LevelUpButton.SetShowText("RoadBookLevelUp_Text");
				this.LevelUpButton.SetRedDotVisible(true);
				this.LevelUpButton.SetEnableClick(true);
				return;
			}
			this.LevelUpButton.SetShowText("RoadBookExpNotEnough_Text");
			this.LevelUpButton.SetRedDotVisible(false);
			this.LevelUpButton.SetEnableClick(false);
		}

		// Token: 0x06040966 RID: 264550 RVA: 0x0108E524 File Offset: 0x0108C724
		private void SetPerformanceUnFinishedLevel(int level)
		{
			IRoadBookLevelData roadBookLevelData;
			this.ActivityBaseData.TravelLevelData.TryGetValue(level, out roadBookLevelData);
			bool flag = this.ActivityBaseData.MaxTravelLevel == level;
			int current = 0;
			int target = flag ? roadBookLevelData.AccumulateExp : roadBookLevelData.TargetExp;
			base.GetItem(17).SetUIActive(true);
			if (flag)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), "RoadBookLevelMax_Text", Array.Empty<object>());
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(18), "RoadBookLevelNotReach_Text", Array.Empty<object>());
				base.GetItem(19).SetUIActive(false);
				base.GetItem(16).SetUIActive(true);
				base.GetItem(20).SetUIActive(false);
			}
			else
			{
				this.SetLevelProgress(current, target);
				base.GetItem(19).SetUIActive(true);
				base.GetItem(16).SetUIActive(false);
				base.GetItem(20).SetUIActive(true);
			}
			this.LevelUpButton.SetShowText("RoadBookLevelNotReach_Text");
			this.LevelUpButton.SetRedDotVisible(false);
			this.LevelUpButton.SetEnableClick(false);
		}

		// Token: 0x06040967 RID: 264551 RVA: 0x0108E634 File Offset: 0x0108C834
		private void OnClickedPreLevelButton()
		{
			this.SelectedLevel--;
			this.RefreshExpComponent(this.SelectedLevel);
			this.UiViewSequence.PlaySequence("Switch", true, null);
		}

		// Token: 0x06040968 RID: 264552 RVA: 0x0108E678 File Offset: 0x0108C878
		private void OnClickedNextLevelButton()
		{
			this.SelectedLevel++;
			this.RefreshExpComponent(this.SelectedLevel);
			this.UiViewSequence.PlaySequence("Switch", true, null);
		}

		// Token: 0x06040969 RID: 264553 RVA: 0x0108E6B9 File Offset: 0x0108C8B9
		private void CloseButtonClicked()
		{
			base.CloseMe(null);
		}

		// Token: 0x0604096A RID: 264554 RVA: 0x0108E6C4 File Offset: 0x0108C8C4
		private void HelpButtonClicked()
		{
			ControllerBase<HelpController>.Instance.OpenHelpById(this.ActivityBaseData.LocalConfig.Value.HelpId);
		}

		// Token: 0x0402427E RID: 148094
		[Nullable(2)]
		private PopupCaptionItem CaptionComponent;

		// Token: 0x0402427F RID: 148095
		protected ActivityRoadBookData ActivityBaseData;

		// Token: 0x04024280 RID: 148096
		private int SelectedLevel = -1;

		// Token: 0x04024281 RID: 148097
		[Nullable(2)]
		private ActivityButtonItem LevelUpButton;

		// Token: 0x04024282 RID: 148098
		private readonly Dictionary<ERoadBookSubType, RoadBookSubViewButton> SubViewButtonMap = new Dictionary<ERoadBookSubType, RoadBookSubViewButton>();

		// Token: 0x04024283 RID: 148099
		private bool NeedLevelUp;

		// Token: 0x04024284 RID: 148100
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericScrollViewNew<ActivitySmallItemGrid, IItemGridData> LevelRewardLayout;

		// Token: 0x04024285 RID: 148101
		private readonly ERoadBookSubType SelectedViewType;

		// Token: 0x04024286 RID: 148102
		private ButtonWithRedDot BtnRight;

		// Token: 0x04024287 RID: 148103
		private ButtonWithRedDot BtnLeft;
	}
}
