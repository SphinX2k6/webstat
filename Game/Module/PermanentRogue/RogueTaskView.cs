using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PermanentRogue
{
	// Token: 0x020056AC RID: 22188
	[NullableContext(1)]
	[Nullable(0)]
	public class RogueTaskView : UiViewBase
	{
		// Token: 0x06038795 RID: 231317 RVA: 0x00E4EFF6 File Offset: 0x00E4D1F6
		public RogueTaskView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06038796 RID: 231318 RVA: 0x00E4F034 File Offset: 0x00E4D234
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIHorizontalLayout)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIScrollViewWithScrollbarComponent)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIText)),
				new ValueTuple<int, Type>(6, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(7, typeof(UUIItem)),
				new ValueTuple<int, Type>(8, typeof(UUIItem)),
				new ValueTuple<int, Type>(9, typeof(UUIItem)),
				new ValueTuple<int, Type>(10, typeof(UUIText))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(6, new Action(this.OnClickBtnRogue))
			};
		}

		// Token: 0x06038797 RID: 231319 RVA: 0x00E4F164 File Offset: 0x00E4D364
		protected override void OnStart()
		{
			this.RemainTimeText = ConfigMultiTextLang.GetLocalTextNew("ActivityRemainingTime", null);
			this.RefreshTimeTitle();
			this.TabLayout = new GenericLayout<RogueTaskTabItem, RogueTaskRewardTabData>(base.GetHorizontalLayout(1), new Func<RogueTaskTabItem>(this.TabItemProxyCreate), null, false, true);
			this.ScrollView = new GenericScrollViewNew<RogueTaskItem, RogueTaskData>(base.GetScrollViewWithScrollbar(3), new Func<RogueTaskItem>(this.InitTaskItem), null, false, null);
			this.CaptionItem = new PopupCaptionItem(base.GetItem(0));
			this.CaptionItem.SetCloseCallBack(new Action(this.OnClickBackBtn));
			this.CaptionItem.SetHelpBtnActive(false);
		}

		// Token: 0x06038798 RID: 231320 RVA: 0x00E4F1FF File Offset: 0x00E4D3FF
		protected override void OnBeforeDestroy()
		{
			this.CaptionItem = null;
			this.ScrollView = null;
			this.TabLayout = null;
		}

		// Token: 0x06038799 RID: 231321 RVA: 0x00E4F218 File Offset: 0x00E4D418
		protected override UniTask OnBeforeShowAsyncImplement()
		{
			RogueTaskView.<OnBeforeShowAsyncImplement>d__15 <OnBeforeShowAsyncImplement>d__;
			<OnBeforeShowAsyncImplement>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeShowAsyncImplement>d__.<>4__this = this;
			<OnBeforeShowAsyncImplement>d__.<>1__state = -1;
			<OnBeforeShowAsyncImplement>d__.<>t__builder.Start<RogueTaskView.<OnBeforeShowAsyncImplement>d__15>(ref <OnBeforeShowAsyncImplement>d__);
			return <OnBeforeShowAsyncImplement>d__.<>t__builder.Task;
		}

		// Token: 0x0603879A RID: 231322 RVA: 0x00E4F25B File Offset: 0x00E4D45B
		protected override void OnBeforeShow()
		{
			this.RefreshTimer = TimerSystem.GameplayTimeInstance.Forever(new TTimerAction(this.OnTimerRefresh), (float)Singleton<TimeUtil>.Instance.InverseMillisecond, 1f, null, null, true);
			this.OnTimerRefresh(0f);
		}

		// Token: 0x0603879B RID: 231323 RVA: 0x00E4F297 File Offset: 0x00E4D497
		protected override void OnAfterHide()
		{
			if (TimerSystem.GameplayTimeInstance.Has(this.RefreshTimer))
			{
				TimerSystem.GameplayTimeInstance.Remove(this.RefreshTimer);
				this.RefreshTimer = null;
			}
		}

		// Token: 0x0603879C RID: 231324 RVA: 0x00E4F2C3 File Offset: 0x00E4D4C3
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.PermanentRogueRewardUpdate, new Action(this.OnGetRewardUpdate));
		}

		// Token: 0x0603879D RID: 231325 RVA: 0x00E4F2E1 File Offset: 0x00E4D4E1
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.PermanentRogueRewardUpdate, new Action(this.OnGetRewardUpdate));
		}

		// Token: 0x0603879E RID: 231326 RVA: 0x00E4F300 File Offset: 0x00E4D500
		private UniTask InitRolePortrait()
		{
			RogueTaskView.<InitRolePortrait>d__20 <InitRolePortrait>d__;
			<InitRolePortrait>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitRolePortrait>d__.<>4__this = this;
			<InitRolePortrait>d__.<>1__state = -1;
			<InitRolePortrait>d__.<>t__builder.Start<RogueTaskView.<InitRolePortrait>d__20>(ref <InitRolePortrait>d__);
			return <InitRolePortrait>d__.<>t__builder.Task;
		}

		// Token: 0x0603879F RID: 231327 RVA: 0x00E4F343 File Offset: 0x00E4D543
		private RogueTaskTabItem TabItemProxyCreate()
		{
			return new RogueTaskTabItem();
		}

		// Token: 0x060387A0 RID: 231328 RVA: 0x00E4F34A File Offset: 0x00E4D54A
		private RogueTaskItem InitTaskItem()
		{
			return new RogueTaskItem();
		}

		// Token: 0x060387A1 RID: 231329 RVA: 0x00E4F354 File Offset: 0x00E4D554
		private void OnClickTab(int index)
		{
			if (index == 4 && !ModelBase<ActivityPermanentRogueModel>.Instance.GetActivityData().SaveFirstCheckRedDotState(EPermanentRogueSaveFlag.NewTaskCheck))
			{
				Singleton<EventSystem>.Instance.Emit(EEventName.PermanentRogueRewardUpdate);
				this.TabLayout.GetLayoutItemByIndex(this.TabTypeList.IndexOf(index)).RefreshRedDot();
			}
			for (int i = 0; i < this.TabTypeList.Count; i++)
			{
				this.TabLayout.GetLayoutItemByIndex(i).SetToggleState(index == this.TabTypeList[i], false);
			}
			this.CurrentTypeIndex = index;
			this.RefreshScrollView(this.CurrentTypeIndex);
		}

		// Token: 0x060387A2 RID: 231330 RVA: 0x00E4F3ED File Offset: 0x00E4D5ED
		private void OnGetRewardUpdate()
		{
			this.TabLayout.GetLayoutItemByIndex(this.TabTypeList.IndexOf(this.CurrentTypeIndex)).RefreshRedDot();
			this.RefreshScrollView(this.CurrentTypeIndex);
		}

		// Token: 0x060387A3 RID: 231331 RVA: 0x00E4F41C File Offset: 0x00E4D61C
		private void OnClickBtnRogue()
		{
			int newSeasonId = ModelBase<ActivityPermanentRogueModel>.Instance.GetNewSeasonId();
			base.CloseMe(null);
			if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.RogueSeasonEntranceView))
			{
				Singleton<UiManager>.Instance.NormalResetToView(EUiViewName.RogueSeasonEntranceView, null, true);
				return;
			}
			Singleton<UiManager>.Instance.OpenView(EUiViewName.RogueSeasonEntranceView, newSeasonId, null);
		}

		// Token: 0x060387A4 RID: 231332 RVA: 0x00E4F474 File Offset: 0x00E4D674
		private void OnClickBackBtn()
		{
			base.CloseMe(null);
		}

		// Token: 0x060387A5 RID: 231333 RVA: 0x00E4F47D File Offset: 0x00E4D67D
		private void OnTimerRefresh(float delta)
		{
			this.RefreshTimeTitle();
		}

		// Token: 0x060387A6 RID: 231334 RVA: 0x00E4F488 File Offset: 0x00E4D688
		private List<RogueTaskRewardTabData> CreateTabItemDataList()
		{
			ActivityPermanentRogueData activityData = ModelBase<ActivityPermanentRogueModel>.Instance.GetActivityData();
			RogueResTaskTheme? config = ConfigRogueResTaskThemeById.GetConfig(activityData.GetTaskThemeId(), true);
			List<RogueTaskRewardTabData> list = new List<RogueTaskRewardTabData>();
			this.TabTypeList.Clear();
			foreach (DicIntString dicIntString in config.Value.TabNamesIter())
			{
				if (activityData.GetTaskListByType(dicIntString.Key).Count != 0)
				{
					RogueTaskRewardTabData rogueTaskRewardTabData = new RogueTaskRewardTabData();
					rogueTaskRewardTabData.NameTextId = dicIntString.Value;
					rogueTaskRewardTabData.Index = dicIntString.Key;
					rogueTaskRewardTabData.ClickedCallback = new Action<int>(this.OnClickTab);
					rogueTaskRewardTabData.RefreshRedDot = ((int tabIndex) => ModelBase<ActivityPermanentRogueModel>.Instance.CheckTaskRedDot(tabIndex));
					list.Add(rogueTaskRewardTabData);
					this.TabTypeList.Add(rogueTaskRewardTabData.Index);
				}
			}
			this.CurrentTypeIndex = ((this.TabTypeList.Count > 0) ? this.TabTypeList[0] : -1);
			return list;
		}

		// Token: 0x060387A7 RID: 231335 RVA: 0x00E4F5B8 File Offset: 0x00E4D7B8
		private void RefreshScrollView(int tabIndex)
		{
			this.DataList.Clear();
			List<RogueTaskData> taskDataListById = ModelBase<ActivityPermanentRogueModel>.Instance.GetTaskDataListById(tabIndex);
			taskDataListById.Sort(new Comparison<RogueTaskData>(ModelBase<ActivityPermanentRogueModel>.Instance.SortTaskData));
			this.DataList = taskDataListById;
			this.ScrollView.RefreshByDataAsync(this.DataList, true);
			int taskProgressByType = ModelBase<ActivityPermanentRogueModel>.Instance.GetTaskProgressByType(this.TabTypeList[tabIndex - 1]);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), "RogueRes_Task_Progress", new <>z__ReadOnlySingleElementList<object>(taskProgressByType));
		}

		// Token: 0x060387A8 RID: 231336 RVA: 0x00E4F648 File Offset: 0x00E4D848
		private void RefreshTimeTitle()
		{
			long endTime = Singleton<MathUtils>.Instance.LongToNumber(ModelBase<ActivityPermanentRogueModel>.Instance.GetTaskEndTime());
			string remainTimeText = ModelBase<ActivityModel>.Instance.GetRemainTimeText(endTime, this.RemainTimeText);
			UUIText text = base.GetText(10);
			if (text != null)
			{
				text.SetUIActive(remainTimeText != null);
			}
			if (text != null)
			{
				text.SetText(remainTimeText ?? "0", true);
			}
			if (ModelBase<ActivityPermanentRogueModel>.Instance.GetTaskIsEnd() && !this.TimeoutConfirm)
			{
				this.TimeoutConfirm = true;
				ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.ActivityEnd);
				confirmBoxDataNew.FunctionMap.Add(1, new Action(RogueTaskView.<RefreshTimeTitle>g__confirmCallback|30_0));
				confirmBoxDataNew.FunctionMap.Add(0, new Action(RogueTaskView.<RefreshTimeTitle>g__confirmCallback|30_0));
				ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
			}
		}

		// Token: 0x060387A9 RID: 231337 RVA: 0x00E4F709 File Offset: 0x00E4D909
		[CompilerGenerated]
		internal static void <RefreshTimeTitle>g__confirmCallback|30_0()
		{
			Singleton<UiManager>.Instance.ResetToBattleView(null);
		}

		// Token: 0x04020404 RID: 132100
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		protected GenericLayout<RogueTaskTabItem, RogueTaskRewardTabData> TabLayout;

		// Token: 0x04020405 RID: 132101
		protected int CurrentTypeIndex = 1;

		// Token: 0x04020406 RID: 132102
		protected List<int> TabTypeList = new List<int>();

		// Token: 0x04020407 RID: 132103
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		protected GenericScrollViewNew<RogueTaskItem, RogueTaskData> ScrollView;

		// Token: 0x04020408 RID: 132104
		[Nullable(2)]
		private PopupCaptionItem CaptionItem;

		// Token: 0x04020409 RID: 132105
		private List<RogueTaskData> DataList = new List<RogueTaskData>();

		// Token: 0x0402040A RID: 132106
		[Nullable(2)]
		private TimerHandle RefreshTimer;

		// Token: 0x0402040B RID: 132107
		private string RemainTimeText = "";

		// Token: 0x0402040C RID: 132108
		private readonly List<RogueTaskRoleItem> RoleItemList = new List<RogueTaskRoleItem>();

		// Token: 0x0402040D RID: 132109
		private bool TimeoutConfirm;

		// Token: 0x0402040E RID: 132110
		private const int MAX_ROLE_COUNT = 3;
	}
}
