using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Module.WorldMap.RegionalTerminal.Data;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.WorldMap.RegionalTerminal.View
{
	// Token: 0x02004BF3 RID: 19443
	[NullableContext(1)]
	[Nullable(0)]
	public class RegionalTerminalOverviewView : UiViewBase
	{
		// Token: 0x06032BB8 RID: 207800 RVA: 0x00CB5730 File Offset: 0x00CB3930
		public RegionalTerminalOverviewView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06032BB9 RID: 207801 RVA: 0x00CB575C File Offset: 0x00CB395C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 13;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06032BBA RID: 207802 RVA: 0x00CB5938 File Offset: 0x00CB3B38
		protected override UniTask OnBeforeStartAsync()
		{
			RegionalTerminalOverviewView.<OnBeforeStartAsync>d__14 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RegionalTerminalOverviewView.<OnBeforeStartAsync>d__14>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06032BBB RID: 207803 RVA: 0x00CB597C File Offset: 0x00CB3B7C
		protected override void OnBeforeShow()
		{
			foreach (RegionalTerminalGroupItem regionalTerminalGroupItem in this.AreaScrollView.GetScrollItemList())
			{
				regionalTerminalGroupItem.RefreshFunctional();
			}
			this.RefreshSelectGameplayData();
		}

		// Token: 0x06032BBC RID: 207804 RVA: 0x00CB59D8 File Offset: 0x00CB3BD8
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<int, bool>(EEventName.RegionalTerminalGameplayPinUpdate, new Action<int, bool>(this.OnGameplayPinUpdate));
			Singleton<EventSystem>.Instance.Add(EEventName.PlaySequenceEventByStringParam, new Action<string>(this.OnPlaySequenceEventByStringParam));
		}

		// Token: 0x06032BBD RID: 207805 RVA: 0x00CB5A12 File Offset: 0x00CB3C12
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.RegionalTerminalGameplayPinUpdate, new Action<int, bool>(this.OnGameplayPinUpdate));
			Singleton<EventSystem>.Instance.Remove(EEventName.PlaySequenceEventByStringParam, new Action<string>(this.OnPlaySequenceEventByStringParam));
		}

		// Token: 0x06032BBE RID: 207806 RVA: 0x00CB5A4C File Offset: 0x00CB3C4C
		protected override void OnBeforeDestroy()
		{
			this.UnBindRedDot();
		}

		// Token: 0x06032BBF RID: 207807 RVA: 0x00CB5A54 File Offset: 0x00CB3C54
		private UniTask InitGroupList()
		{
			RegionalTerminalOverviewView.<InitGroupList>d__19 <InitGroupList>d__;
			<InitGroupList>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitGroupList>d__.<>4__this = this;
			<InitGroupList>d__.<>1__state = -1;
			<InitGroupList>d__.<>t__builder.Start<RegionalTerminalOverviewView.<InitGroupList>d__19>(ref <InitGroupList>d__);
			return <InitGroupList>d__.<>t__builder.Task;
		}

		// Token: 0x06032BC0 RID: 207808 RVA: 0x00CB5A98 File Offset: 0x00CB3C98
		private void InitScroll()
		{
			RegionalTerminalGroupItem scrollItemByKey = this.AreaScrollView.GetScrollItemByKey(this.CurrentSelectGameplayData.GroupId);
			UUIItem uuiitem;
			if (scrollItemByKey == null)
			{
				uuiitem = null;
			}
			else
			{
				RegionalTerminalGameplayItem gameplayItem = scrollItemByKey.GetGameplayItem(this.CurrentSelectGameplayData.Id);
				uuiitem = ((gameplayItem != null) ? gameplayItem.GetRootItem() : null);
			}
			UUIItem uuiitem2 = uuiitem;
			if (uuiitem2 != null)
			{
				this.AreaScrollView.LateScrollTo(uuiitem2, null, false);
			}
		}

		// Token: 0x06032BC1 RID: 207809 RVA: 0x00CB5AF5 File Offset: 0x00CB3CF5
		private int SortGroupData(RegionalTerminalGroupData a, RegionalTerminalGroupData b)
		{
			return b.SortId - a.SortId;
		}

		// Token: 0x06032BC2 RID: 207810 RVA: 0x00CB5B04 File Offset: 0x00CB3D04
		private RegionalTerminalGroupItem CreateGroupItem()
		{
			return new RegionalTerminalGroupItem
			{
				OnClickToggleCallBack = new Action<bool, RegionalTerminalGameplayData, int>(this.OnClickGameplayItemToggle),
				IsToggleSelectOnCallBack = new Func<RegionalTerminalGameplayData, bool>(this.IsGameplayItemToggleSelectOn)
			};
		}

		// Token: 0x06032BC3 RID: 207811 RVA: 0x00CB5B30 File Offset: 0x00CB3D30
		private void OnClickGameplayItemToggle(bool state, RegionalTerminalGameplayData data, int groupId)
		{
			if (!state)
			{
				return;
			}
			if (this.CurrentSelectGameplayData != null)
			{
				RegionalTerminalGroupItem scrollItemByKey = this.AreaScrollView.GetScrollItemByKey(this.CurrentSelectGameplayData.GroupId);
				if (groupId != this.CurrentSelectGameplayData.GroupId && scrollItemByKey != null)
				{
					scrollItemByKey.SetSelectOn(false);
				}
				if (scrollItemByKey != null)
				{
					RegionalTerminalGameplayItem gameplayItem = scrollItemByKey.GetGameplayItem(this.CurrentSelectGameplayData.Id);
					if (gameplayItem != null)
					{
						gameplayItem.OnDeselected(false);
					}
				}
			}
			this.SelectGameplayItem(data, groupId);
		}

		// Token: 0x06032BC4 RID: 207812 RVA: 0x00CB5BA8 File Offset: 0x00CB3DA8
		private void SelectGameplayItem(RegionalTerminalGameplayData data, int groupId)
		{
			this.CurrentSelectGameplayData = data;
			this.RefreshSelectGameplayData();
			UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
			if (uiViewSequence == null)
			{
				return;
			}
			uiViewSequence.PlayOrReplaySequenceByName("Switch", false, null);
		}

		// Token: 0x06032BC5 RID: 207813 RVA: 0x00CB5BE1 File Offset: 0x00CB3DE1
		private bool IsGameplayItemToggleSelectOn(RegionalTerminalGameplayData data)
		{
			return this.CurrentSelectGameplayData == data;
		}

		// Token: 0x06032BC6 RID: 207814 RVA: 0x00CB5BEC File Offset: 0x00CB3DEC
		[NullableContext(2)]
		private RegionalTerminalGameplayItem GetGameplayItem(int gameplayId)
		{
			RegionalTerminalGameplayData valueOrDefault = ModelBase<RegionalTerminalModel>.Instance.GameplayDataMap.GetValueOrDefault(gameplayId);
			if (valueOrDefault == null)
			{
				return null;
			}
			RegionalTerminalGroupItem scrollItemByKey = this.AreaScrollView.GetScrollItemByKey(valueOrDefault.GroupId);
			if (scrollItemByKey == null)
			{
				return null;
			}
			return scrollItemByKey.GetGameplayItem(gameplayId);
		}

		// Token: 0x06032BC7 RID: 207815 RVA: 0x00CB5C34 File Offset: 0x00CB3E34
		private void OnPlaySequenceEventByStringParam(string eventName)
		{
			GenericLayout<RegionalTerminalGroupItem, RegionalTerminalGroupData> genericLayout = this.AreaScrollView.GetGenericLayout();
			UUIInturnAnimController uuiinturnAnimController = (genericLayout != null) ? genericLayout.GetUiAnimController() : null;
			if (uuiinturnAnimController != null)
			{
				uuiinturnAnimController.AnimName = eventName;
				uuiinturnAnimController.Play("", -1, false);
			}
		}

		// Token: 0x06032BC8 RID: 207816 RVA: 0x00CB5C70 File Offset: 0x00CB3E70
		private void OnGameplayPinUpdate(int gameplayId, bool isPin)
		{
			RegionalTerminalGameplayData currentSelectGameplayData = this.CurrentSelectGameplayData;
			if (currentSelectGameplayData != null && currentSelectGameplayData.Id == gameplayId)
			{
				this.RefreshGameplayItem(this.CurrentSelectGameplayData);
			}
			RegionalTerminalGameplayItem gameplayItem = this.GetGameplayItem(gameplayId);
			if (gameplayItem == null)
			{
				return;
			}
			gameplayItem.SetPin(isPin);
		}

		// Token: 0x06032BC9 RID: 207817 RVA: 0x00CB5CA7 File Offset: 0x00CB3EA7
		private void InitPinToggle()
		{
			base.GetExtendToggle(7).CanExecuteChange.Bind(new Func<bool>(this.CanExecutePinToggle));
		}

		// Token: 0x06032BCA RID: 207818 RVA: 0x00CB5CC8 File Offset: 0x00CB3EC8
		private unsafe void OnClickTogglePin(bool isPin)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Map;
			ELogAuthor author = ELogAuthor.YYZ;
			string message = "[RegionalTerminal] PinGameplay";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("GameplayId", this.CurrentSelectGameplayData.Id);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("IsPin", isPin);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			int id = this.CurrentSelectGameplayData.Id;
			ControllerBase<RegionalTerminalController>.Instance.RequestTerminalPinOperation(id, isPin, delegate(bool success)
			{
				ModelBase<RegionalTerminalModel>.Instance.StartPinCdTimer();
				if (!success)
				{
					return;
				}
				this.RefreshPin(false);
				string textId = isPin ? "Terminal_Area_PinTipSuccess" : "Terminal_Area_PinTipCancel";
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId(textId, Array.Empty<object>());
			});
		}

		// Token: 0x06032BCB RID: 207819 RVA: 0x00CB5D80 File Offset: 0x00CB3F80
		private bool CanExecutePinToggle()
		{
			if (this.CurrentSelectGameplayData == null)
			{
				return false;
			}
			EToggleState toggleState = base.GetExtendToggle(7).GetToggleState();
			if (toggleState == EToggleState.ETT_UnChecked && ModelBase<RegionalTerminalModel>.Instance.GetPinnedGameplayIds().Count >= this.PinMaxCount)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Terminal_Area_PinTipMax", Array.Empty<object>());
				return false;
			}
			if (!ModelBase<RegionalTerminalModel>.Instance.IsInPinCd)
			{
				this.OnClickTogglePin(toggleState == EToggleState.ETT_UnChecked);
			}
			return false;
		}

		// Token: 0x06032BCC RID: 207820 RVA: 0x00CB5DEC File Offset: 0x00CB3FEC
		private void RefreshSelectGameplayData()
		{
			if (this.CurrentSelectGameplayData == null)
			{
				return;
			}
			this.CurrentSelectGameplayData.OnSelected();
			this.RefreshGameplayItem(this.CurrentSelectGameplayData);
			RegionalTerminalGroupItem scrollItemByKey = this.AreaScrollView.GetScrollItemByKey(this.CurrentSelectGameplayData.GroupId);
			if (scrollItemByKey != null)
			{
				scrollItemByKey.SetSelectOn(true);
			}
			bool lockState = this.CurrentSelectGameplayData.GetLockState();
			AreaTerminal? areaTerminalByGameplayId = ConfigBase<RegionalTerminalConfig>.Instance.GetAreaTerminalByGameplayId(this.CurrentSelectGameplayData.Id);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), areaTerminalByGameplayId.Value.Desc, Array.Empty<object>());
			this.RefreshRewardPreview();
			this.RefreshPin(true);
			base.GetItem(5).SetUIActive(!lockState);
			IRegionalTerminalViewParams viewParams = this.CurrentSelectGameplayData.GetViewParams();
			this.PanelLock.SetUiActive(viewParams.ShowLockPanel);
			if (viewParams.ShowLockPanel)
			{
				if (viewParams.LockClickFunc != null)
				{
					this.PanelLock.ButtonCallBack = viewParams.LockClickFunc;
					this.PanelLock.SetButtonVisible(true);
				}
				else
				{
					this.PanelLock.SetButtonVisible(false);
				}
				if (!string.IsNullOrEmpty(viewParams.LockTxtId))
				{
					this.PanelLock.SetTextByTextId(viewParams.LockTxtId, Array.Empty<string>());
				}
			}
			if (!string.IsNullOrEmpty(viewParams.ButtonTxtId))
			{
				this.ButtonItem.SetLocalTextNew(viewParams.ButtonTxtId, Array.Empty<object>());
			}
			this.ButtonItem.SetUiActive(viewParams.ShowButton);
			this.BindRedDot();
		}

		// Token: 0x06032BCD RID: 207821 RVA: 0x00CB5F5C File Offset: 0x00CB415C
		private void RefreshRewardPreview()
		{
			if (this.CurrentSelectGameplayData == null)
			{
				return;
			}
			List<TItem> rewardPreviewList = this.CurrentSelectGameplayData.GetRewardPreviewList();
			bool flag = rewardPreviewList != null && rewardPreviewList.Count > 0;
			UUIItem item = base.GetItem(10);
			if (item != null)
			{
				item.SetUIActive(flag);
			}
			if (flag)
			{
				GenericScrollViewNew<CommonItemSmallItemGrid, TItem> rewardScrollView = this.RewardScrollView;
				if (rewardScrollView == null)
				{
					return;
				}
				rewardScrollView.RefreshByData(rewardPreviewList, delegate
				{
					UUIScrollViewWithScrollbarComponent scrollViewWithScrollbar = base.GetScrollViewWithScrollbar(11);
					if (scrollViewWithScrollbar == null)
					{
						return;
					}
					scrollViewWithScrollbar.SetScrollProgress(1f);
				}, false);
			}
		}

		// Token: 0x06032BCE RID: 207822 RVA: 0x00CB5FC4 File Offset: 0x00CB41C4
		private void RefreshPin(bool bIngnoreAnim)
		{
			bool flag = ModelBase<RegionalTerminalModel>.Instance.IsGameplayPin(this.CurrentSelectGameplayData.Id);
			base.GetExtendToggle(7).SetToggleStateForce(flag ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, bIngnoreAnim);
			if (!bIngnoreAnim)
			{
				Singleton<AudioSystem>.Instance.PostEvent("play_ui_ia_com_tab_click");
			}
			int count = ModelBase<RegionalTerminalModel>.Instance.GetPinnedGameplayIds().Count;
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(6), "Terminal_Area_PinText", new <>z__ReadOnlyArray<object>(new object[]
			{
				count,
				this.PinMaxCount
			}));
		}

		// Token: 0x06032BCF RID: 207823 RVA: 0x00CB6058 File Offset: 0x00CB4258
		private void RefreshGameplayItem(RegionalTerminalGameplayData data)
		{
			this.GameplayItem.RefreshAsync(data, false, 0);
		}

		// Token: 0x06032BD0 RID: 207824 RVA: 0x00CB606C File Offset: 0x00CB426C
		private void OnClickButton(int index)
		{
			if (this.CurrentSelectGameplayData == null)
			{
				return;
			}
			RegionalTerminalGameplayData currentSelectGameplayData = this.CurrentSelectGameplayData;
			if (currentSelectGameplayData != null)
			{
				currentSelectGameplayData.TerminalFunction(null);
			}
			if (this.CurrentSelectGameplayData.CloseTerminalWhenForwarding)
			{
				base.CloseMe(null);
			}
			AreaTerminalOpenActivityLogEvent areaTerminalOpenActivityLogEvent = new AreaTerminalOpenActivityLogEvent();
			areaTerminalOpenActivityLogEvent.i_id = this.CurrentSelectGameplayData.Id;
			areaTerminalOpenActivityLogEvent.i_type = 2;
			ControllerBase<LogReportController>.Instance.LogReport(areaTerminalOpenActivityLogEvent);
		}

		// Token: 0x06032BD1 RID: 207825 RVA: 0x00CB60D4 File Offset: 0x00CB42D4
		private void BindRedDot()
		{
			this.UnBindRedDot();
			this.RedDotName = this.CurrentSelectGameplayData.GetRedDotName();
			this.RedDotId = this.CurrentSelectGameplayData.GetRedDotId();
			if (this.RedDotName != null)
			{
				this.ButtonItem.BindRedDot(this.RedDotName.Value, this.RedDotId);
				return;
			}
			this.ButtonItem.SetRedDotVisible(this.CurrentSelectGameplayData.GetRedDotState());
		}

		// Token: 0x06032BD2 RID: 207826 RVA: 0x00CB6149 File Offset: 0x00CB4349
		private void UnBindRedDot()
		{
			if (this.RedDotName != null)
			{
				this.ButtonItem.UnBindGivenUid(this.RedDotId);
				this.RedDotId = 0;
				this.RedDotName = null;
			}
		}

		// Token: 0x0401D876 RID: 120950
		[Nullable(2)]
		private PopupCaptionItem CaptionItem;

		// Token: 0x0401D877 RID: 120951
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericScrollViewNew<RegionalTerminalGroupItem, RegionalTerminalGroupData> AreaScrollView;

		// Token: 0x0401D878 RID: 120952
		[Nullable(2)]
		private RegionalTerminalGameplayItem GameplayItem;

		// Token: 0x0401D879 RID: 120953
		[Nullable(2)]
		private FunctionalPanelConditionLock PanelLock;

		// Token: 0x0401D87A RID: 120954
		[Nullable(2)]
		private ButtonItem ButtonItem;

		// Token: 0x0401D87B RID: 120955
		private ERedDotName? RedDotName;

		// Token: 0x0401D87C RID: 120956
		private int RedDotId;

		// Token: 0x0401D87D RID: 120957
		[Nullable(2)]
		private RegionalTerminalGameplayData CurrentSelectGameplayData;

		// Token: 0x0401D87E RID: 120958
		private readonly int PinMaxCount = ConfigCommonParamById.GetIntConfig("AreaTerminalPinMaxCount").GetValueOrDefault();

		// Token: 0x0401D87F RID: 120959
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericScrollViewNew<CommonItemSmallItemGrid, TItem> RewardScrollView;

		// Token: 0x0200ACE4 RID: 44260
		[NullableContext(0)]
		public static class EComponents
		{
			// Token: 0x04035B3D RID: 219965
			public const int CaptionItem = 0;

			// Token: 0x04035B3E RID: 219966
			public const int GroupScrollView = 1;

			// Token: 0x04035B3F RID: 219967
			public const int GroupItem = 2;

			// Token: 0x04035B40 RID: 219968
			public const int RightGameplayItem = 3;

			// Token: 0x04035B41 RID: 219969
			public const int TxtDesc = 4;

			// Token: 0x04035B42 RID: 219970
			public const int PinPanel = 5;

			// Token: 0x04035B43 RID: 219971
			public const int TxtPin = 6;

			// Token: 0x04035B44 RID: 219972
			public const int TogglePin = 7;

			// Token: 0x04035B45 RID: 219973
			public const int PanelLock = 8;

			// Token: 0x04035B46 RID: 219974
			public const int BtnConfirm = 9;

			// Token: 0x04035B47 RID: 219975
			public const int RewardPanel = 10;

			// Token: 0x04035B48 RID: 219976
			public const int RewardScroll = 11;

			// Token: 0x04035B49 RID: 219977
			public const int RewardItem = 12;
		}

		// Token: 0x0200ACE5 RID: 44261
		[Nullable(0)]
		public static class ESequenceName
		{
			// Token: 0x04035B4A RID: 219978
			public const string Start = "Start";

			// Token: 0x04035B4B RID: 219979
			public const string Switch = "Switch";
		}
	}
}
