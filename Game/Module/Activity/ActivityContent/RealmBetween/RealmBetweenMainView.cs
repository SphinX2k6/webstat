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

namespace CSharpScript.Game.Module.Activity.ActivityContent.RealmBetween
{
	// Token: 0x0200653E RID: 25918
	[NullableContext(1)]
	[Nullable(0)]
	public class RealmBetweenMainView : UiViewBase
	{
		// Token: 0x06040CAC RID: 265388 RVA: 0x0109D0AF File Offset: 0x0109B2AF
		public RealmBetweenMainView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06040CAD RID: 265389 RVA: 0x0109D0CC File Offset: 0x0109B2CC
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIArtText)),
				new ValueTuple<int, Type>(2, typeof(UUIText)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(12, typeof(UUIItem)),
				new ValueTuple<int, Type>(13, typeof(UUIItem)),
				new ValueTuple<int, Type>(14, typeof(UUIItem)),
				new ValueTuple<int, Type>(6, typeof(UUIScrollViewWithScrollbarComponent)),
				new ValueTuple<int, Type>(7, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIItem)),
				new ValueTuple<int, Type>(8, typeof(UUIItem)),
				new ValueTuple<int, Type>(10, typeof(UUISprite)),
				new ValueTuple<int, Type>(11, typeof(UUIText)),
				new ValueTuple<int, Type>(9, typeof(UUIItem))
			};
		}

		// Token: 0x06040CAE RID: 265390 RVA: 0x0109D234 File Offset: 0x0109B434
		protected override UniTask OnBeforeStartAsync()
		{
			RealmBetweenMainView.<OnBeforeStartAsync>d__12 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RealmBetweenMainView.<OnBeforeStartAsync>d__12>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06040CAF RID: 265391 RVA: 0x0109D277 File Offset: 0x0109B477
		protected override void OnStart()
		{
			this.SelectedLevel = this.ActivityBaseData.TravelLevel;
		}

		// Token: 0x06040CB0 RID: 265392 RVA: 0x0109D28A File Offset: 0x0109B48A
		protected override void OnBeforeShow()
		{
			this.RefreshExpComponent(this.SelectedLevel);
			this.RefreshSubViewButton();
		}

		// Token: 0x06040CB1 RID: 265393 RVA: 0x0109D29E File Offset: 0x0109B49E
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<EUiViewName, int>(EEventName.CloseView, new Action<EUiViewName, int>(this.OnRewardViewClose));
		}

		// Token: 0x06040CB2 RID: 265394 RVA: 0x0109D2B9 File Offset: 0x0109B4B9
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove<EUiViewName, int>(EEventName.CloseView, new Action<EUiViewName, int>(this.OnRewardViewClose));
		}

		// Token: 0x06040CB3 RID: 265395 RVA: 0x0109D2D4 File Offset: 0x0109B4D4
		private UniTask CreateSubViewButton()
		{
			RealmBetweenMainView.<CreateSubViewButton>d__17 <CreateSubViewButton>d__;
			<CreateSubViewButton>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateSubViewButton>d__.<>4__this = this;
			<CreateSubViewButton>d__.<>1__state = -1;
			<CreateSubViewButton>d__.<>t__builder.Start<RealmBetweenMainView.<CreateSubViewButton>d__17>(ref <CreateSubViewButton>d__);
			return <CreateSubViewButton>d__.<>t__builder.Task;
		}

		// Token: 0x06040CB4 RID: 265396 RVA: 0x0109D318 File Offset: 0x0109B518
		protected void OnOpenSubView(ERealmBetweenSubType type)
		{
			switch (type)
			{
			case ERealmBetweenSubType.TravelTask:
				Singleton<UiManager>.Instance.OpenView(EUiViewName.RealmBetweenTravelTaskView, this.ActivityBaseData, null);
				return;
			case ERealmBetweenSubType.PhantomQuest:
				break;
			case ERealmBetweenSubType.PhantomCollect:
				Singleton<UiManager>.Instance.OpenView(EUiViewName.RealmBetweenPhantomTaskView, this.ActivityBaseData, null);
				break;
			case ERealmBetweenSubType.MotorChallenge:
				Singleton<UiManager>.Instance.OpenView(EUiViewName.RealmBetweenVehicleTaskView, this.ActivityBaseData, null);
				return;
			default:
				return;
			}
		}

		// Token: 0x06040CB5 RID: 265397 RVA: 0x0109D382 File Offset: 0x0109B582
		private void OnClickedLevelUpButton()
		{
			ControllerBase<ActivityRealmBetweenController>.Instance.RequestRealmBetweenLevelUp(delegate(bool success)
			{
				this.NeedLevelUp = success;
				this.LevelUp();
			});
		}

		// Token: 0x06040CB6 RID: 265398 RVA: 0x0109D39C File Offset: 0x0109B59C
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

		// Token: 0x06040CB7 RID: 265399 RVA: 0x0109D405 File Offset: 0x0109B605
		private void OnRewardViewClose(EUiViewName viewName, int viewId)
		{
			if (this.SelectedViewType != ERealmBetweenSubType.Main)
			{
				return;
			}
			if (viewName == EUiViewName.CommonRewardView || viewName == EUiViewName.RoleLevelUpSuccessAttributeView)
			{
				this.LevelUp();
			}
		}

		// Token: 0x06040CB8 RID: 265400 RVA: 0x0109D430 File Offset: 0x0109B630
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
			IRealmBetweenLevelData realmBetweenLevelData;
			this.ActivityBaseData.TravelLevelData.TryGetValue(level, out realmBetweenLevelData);
			if (realmBetweenLevelData == null)
			{
				return;
			}
			RealmBetweenLevelExp value = ConfigBase<ActivityRealmBetweenConfig>.Instance.GetLevelExpConfig(realmBetweenLevelData.Id).Value;
			string text;
			if (level <= 0 || level >= 10)
			{
				text = level.ToString();
			}
			else
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
				defaultInterpolatedStringHandler.AppendLiteral("0");
				defaultInterpolatedStringHandler.AppendFormatted<int>(level);
				text = defaultInterpolatedStringHandler.ToStringAndClear();
			}
			string text2 = text;
			base.GetArtText(1).SetText(text2);
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
			base.GetItem(3).SetUIActive(level > 0);
			base.GetItem(4).SetUIActive(level < this.ActivityBaseData.MaxTravelLevel);
		}

		// Token: 0x06040CB9 RID: 265401 RVA: 0x0109D60C File Offset: 0x0109B80C
		private void RefreshSubViewButton()
		{
			foreach (KeyValuePair<ERealmBetweenSubType, RealmBetweenSubViewButton> keyValuePair in this.SubViewButtonMap)
			{
				ERealmBetweenSubType key = keyValuePair.Key;
				RealmBetweenSubViewButton value = keyValuePair.Value;
				ValueTuple<int, int> typeProgress = this.ActivityBaseData.GetTypeProgress(key);
				int item = typeProgress.Item1;
				int item2 = typeProgress.Item2;
				int num = (int)Math.Ceiling((double)item / (double)item2 * 100.0);
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
				defaultInterpolatedStringHandler.AppendFormatted<int>(num);
				defaultInterpolatedStringHandler.AppendLiteral("%");
				value.SetProgressText(defaultInterpolatedStringHandler.ToStringAndClear());
				value.SeFinishIconState(num >= 100);
				bool typeRedDotState = this.ActivityBaseData.GetTypeRedDotState(key);
				bool typeNewState = this.ActivityBaseData.GetTypeNewState(key);
				value.RefreshRedDot(typeRedDotState || typeNewState);
			}
		}

		// Token: 0x06040CBA RID: 265402 RVA: 0x0109D700 File Offset: 0x0109B900
		private void SetPerformanceFinishedLevel(int level)
		{
			IRealmBetweenLevelData realmBetweenLevelData;
			this.ActivityBaseData.TravelLevelData.TryGetValue(level, out realmBetweenLevelData);
			base.GetItem(5).SetUIActive(true);
			base.GetItem(7).SetUIActive(false);
			base.GetItem(8).SetUIActive(true);
			base.GetItem(9).SetUIActive(false);
			UUIText text = base.GetText(2);
			text.SetUIActive(true);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "RealmBetweenExp_Text", new <>z__ReadOnlyArray<object>(new object[]
			{
				realmBetweenLevelData.TargetExp,
				realmBetweenLevelData.TargetExp
			}));
		}

		// Token: 0x06040CBB RID: 265403 RVA: 0x0109D79C File Offset: 0x0109B99C
		private void SetPerformanceCurrentLevel(int level)
		{
			ActivityRealmBetweenData activityBaseData = this.ActivityBaseData;
			bool flag = activityBaseData.MaxTravelLevel == level;
			bool flag2 = !flag && activityBaseData.CanTravelLevelUp();
			IRealmBetweenLevelData realmBetweenLevelData;
			activityBaseData.TravelLevelData.TryGetValue(level, out realmBetweenLevelData);
			base.GetItem(5).SetUIActive(!flag);
			base.GetItem(7).SetUIActive(true);
			base.GetItem(8).SetUIActive(false);
			base.GetItem(9).SetUIActive(flag);
			base.GetText(11).ShowTextNew("RealmBetweenLevelMaxBtn_Text");
			base.GetText(2).SetUIActive(true);
			UUIText text = base.GetText(2);
			if (flag)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "RealmBetweenLevelMax_Text", Array.Empty<object>());
			}
			else
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "RealmBetweenExp_Text", new <>z__ReadOnlyArray<object>(new object[]
				{
					activityBaseData.GetCurrentExp(),
					realmBetweenLevelData.TargetExp
				}));
			}
			if (flag2)
			{
				this.UiViewSequence.PlaySequence("PreLevelUp", false, null);
				this.LevelUpButton.SetShowText("RealmBetweenLevelUp_Text");
				this.LevelUpButton.SetRedDotVisible(true);
				this.LevelUpButton.SetEnableClick(true);
				return;
			}
			this.LevelUpButton.SetShowText("RealmBetweenExpNotEnough_Text");
			this.LevelUpButton.SetRedDotVisible(false);
			this.LevelUpButton.SetEnableClick(false);
		}

		// Token: 0x06040CBC RID: 265404 RVA: 0x0109D8F8 File Offset: 0x0109BAF8
		private void SetPerformanceUnFinishedLevel(int level)
		{
			bool flag = this.ActivityBaseData.MaxTravelLevel == level;
			base.GetItem(5).SetUIActive(!flag);
			this.LevelUpButton.SetShowText("RealmBetweenLevelNotReach_Text");
			this.LevelUpButton.SetRedDotVisible(false);
			this.LevelUpButton.SetEnableClick(false);
			base.GetItem(9).SetUIActive(flag);
			base.GetText(11).ShowTextNew("RealmBetweenLevelNotReach_Text");
			base.GetSprite(10).SetUIActive(false);
			base.GetText(2).SetUIActive(false);
		}

		// Token: 0x06040CBD RID: 265405 RVA: 0x0109D988 File Offset: 0x0109BB88
		private void OnClickedPreLevelButton()
		{
			this.SelectedLevel--;
			this.RefreshExpComponent(this.SelectedLevel);
			this.UiViewSequence.PlaySequence("Switch", true, null);
		}

		// Token: 0x06040CBE RID: 265406 RVA: 0x0109D9CC File Offset: 0x0109BBCC
		private void OnClickedNextLevelButton()
		{
			this.SelectedLevel++;
			this.RefreshExpComponent(this.SelectedLevel);
			this.UiViewSequence.PlaySequence("Switch", true, null);
		}

		// Token: 0x06040CBF RID: 265407 RVA: 0x0109DA0D File Offset: 0x0109BC0D
		private void CloseButtonClicked()
		{
			base.CloseMe(null);
		}

		// Token: 0x06040CC0 RID: 265408 RVA: 0x0109DA18 File Offset: 0x0109BC18
		private void HelpButtonClicked()
		{
			ControllerBase<HelpController>.Instance.OpenHelpById(this.ActivityBaseData.LocalConfig.Value.HelpId);
		}

		// Token: 0x04024582 RID: 148866
		[Nullable(2)]
		private PopupCaptionItem CaptionComponent;

		// Token: 0x04024583 RID: 148867
		protected ActivityRealmBetweenData ActivityBaseData;

		// Token: 0x04024584 RID: 148868
		private int SelectedLevel = -1;

		// Token: 0x04024585 RID: 148869
		[Nullable(2)]
		private ActivityButtonItem LevelUpButton;

		// Token: 0x04024586 RID: 148870
		private readonly Dictionary<ERealmBetweenSubType, RealmBetweenSubViewButton> SubViewButtonMap = new Dictionary<ERealmBetweenSubType, RealmBetweenSubViewButton>();

		// Token: 0x04024587 RID: 148871
		private bool NeedLevelUp;

		// Token: 0x04024588 RID: 148872
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericScrollViewNew<ActivitySmallItemGrid, IItemGridData> LevelRewardLayout;

		// Token: 0x04024589 RID: 148873
		private readonly ERealmBetweenSubType SelectedViewType;

		// Token: 0x0402458A RID: 148874
		private ButtonWithRedDot BtnRight;

		// Token: 0x0402458B RID: 148875
		private ButtonWithRedDot BtnLeft;
	}
}
