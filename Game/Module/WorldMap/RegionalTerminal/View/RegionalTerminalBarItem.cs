using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Module.WorldMap.RegionalTerminal.Data;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.WorldMap.RegionalTerminal.View
{
	// Token: 0x02004BF0 RID: 19440
	[NullableContext(1)]
	[Nullable(0)]
	public class RegionalTerminalBarItem : UiPanelBase, IWorldMapItemVisibleControlInterface
	{
		// Token: 0x1700871C RID: 34588
		// (get) Token: 0x06032B88 RID: 207752 RVA: 0x00CB477E File Offset: 0x00CB297E
		// (set) Token: 0x06032B89 RID: 207753 RVA: 0x00CB4786 File Offset: 0x00CB2986
		public EWorldMapShowMode ShowMode { get; set; }

		// Token: 0x06032B8A RID: 207754 RVA: 0x00CB4790 File Offset: 0x00CB2990
		protected unsafe override void OnRegisterComponent()
		{
			int num = 10;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 3;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnClickButtonFold));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(7, new Action(this.OnClickButtonUnfold));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(5, new Action(this.OnClickButtonMenu));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06032B8B RID: 207755 RVA: 0x00CB4988 File Offset: 0x00CB2B88
		protected override void OnStart()
		{
			this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
			this.LevelSequencePlayer.BindSequenceCloseEvent(new TSequenceEndEvent(this.OnSequenceFinishEvent), false);
			this.RootActor.OnSequencePlayEvent.Bind(new Action<string, string>(this.OnEventSequence));
			this.LayoutGameplay = new GenericScrollViewNew<RegionalTerminalBarGameplayItem, RegionalTerminalGameplayData>(base.GetScrollViewWithScrollbar(0), new Func<RegionalTerminalBarGameplayItem>(this.CreateGameplayItem), null, false, null);
			this.RefreshGameplayList();
			base.GetItem(8).SetUIActive(!this.CanUnfold);
			IRegionalTerminalBarItemParams regionalTerminalBarItemParams = this.OpenParam as IRegionalTerminalBarItemParams;
			if (regionalTerminalBarItemParams != null && regionalTerminalBarItemParams.IsUnfold != null)
			{
				this.FoldState = (!this.CanUnfold || !regionalTerminalBarItemParams.IsUnfold.GetValueOrDefault());
			}
			else
			{
				this.FoldState = (!this.CanUnfold || ModelBase<RegionalTerminalModel>.Instance.BarFoldState);
			}
			this.RefreshState();
		}

		// Token: 0x06032B8C RID: 207756 RVA: 0x00CB4A7C File Offset: 0x00CB2C7C
		public void BeforeShow()
		{
			this.RefreshGameplayList();
			this.RefreshState();
			Singleton<EventSystem>.Instance.Add<int, bool>(EEventName.RegionalTerminalGameplayPinUpdate, new Action<int, bool>(this.OnGameplayPinUpdate));
			Singleton<EventSystem>.Instance.Add(EEventName.AreaMapGroupIdChanged, new Action(this.OnAreaMapGroupIdChanged));
		}

		// Token: 0x06032B8D RID: 207757 RVA: 0x00CB4ACD File Offset: 0x00CB2CCD
		public void BeforeHide()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.RegionalTerminalGameplayPinUpdate, new Action<int, bool>(this.OnGameplayPinUpdate));
			Singleton<EventSystem>.Instance.Remove(EEventName.AreaMapGroupIdChanged, new Action(this.OnAreaMapGroupIdChanged));
		}

		// Token: 0x06032B8E RID: 207758 RVA: 0x00CB4B07 File Offset: 0x00CB2D07
		private void OnGameplayPinUpdate(int i, bool b)
		{
			this.RefreshGameplayList();
			this.RefreshState();
		}

		// Token: 0x06032B8F RID: 207759 RVA: 0x00CB4B18 File Offset: 0x00CB2D18
		private void OnAreaMapGroupIdChanged()
		{
			this.RefreshGameplayList();
			this.RefreshState();
			if (!this.FoldState && this.IsGameplayListShow)
			{
				this.LevelSequencePlayer.StopSequenceByKey("Close", true, false);
				this.AnimState = true;
				this.LevelSequencePlayer.PlayOrReplaySequenceByName("Start", false, null);
			}
		}

		// Token: 0x06032B90 RID: 207760 RVA: 0x00CB4B74 File Offset: 0x00CB2D74
		private void OnSequenceFinishEvent(string sequenceName)
		{
			if (sequenceName == "Close")
			{
				this.RefreshState();
			}
			this.AnimState = false;
		}

		// Token: 0x06032B91 RID: 207761 RVA: 0x00CB4B90 File Offset: 0x00CB2D90
		private void OnEventSequence(string sequenceName, string eventName)
		{
			GenericScrollViewNew<RegionalTerminalBarGameplayItem, RegionalTerminalGameplayData> layoutGameplay = this.LayoutGameplay;
			UUIInturnAnimController uuiinturnAnimController;
			if (layoutGameplay == null)
			{
				uuiinturnAnimController = null;
			}
			else
			{
				GenericLayout<RegionalTerminalBarGameplayItem, RegionalTerminalGameplayData> genericLayout = layoutGameplay.GetGenericLayout();
				uuiinturnAnimController = ((genericLayout != null) ? genericLayout.GetUiAnimController() : null);
			}
			UUIInturnAnimController uuiinturnAnimController2 = uuiinturnAnimController;
			if (uuiinturnAnimController2 != null)
			{
				uuiinturnAnimController2.AnimName = eventName;
				uuiinturnAnimController2.Play("", -1, false);
			}
		}

		// Token: 0x06032B92 RID: 207762 RVA: 0x00CB4BD3 File Offset: 0x00CB2DD3
		private RegionalTerminalBarGameplayItem CreateGameplayItem()
		{
			return new RegionalTerminalBarGameplayItem();
		}

		// Token: 0x06032B93 RID: 207763 RVA: 0x00CB4BDC File Offset: 0x00CB2DDC
		private void OnClickButtonFold()
		{
			if (this.AnimState)
			{
				return;
			}
			AreaTerminalOpenLogEvent areaTerminalOpenLogEvent = new AreaTerminalOpenLogEvent();
			areaTerminalOpenLogEvent.i_type = 2;
			ControllerBase<LogReportController>.Instance.LogReport(areaTerminalOpenLogEvent);
			this.FoldState = true;
			ModelBase<RegionalTerminalModel>.Instance.BarFoldState = this.FoldState;
			this.LevelSequencePlayer.StopSequenceByKey("Start", true, false);
			this.AnimState = true;
			this.LevelSequencePlayer.PlayOrReplaySequenceByName("Close", false, null);
		}

		// Token: 0x06032B94 RID: 207764 RVA: 0x00CB4C54 File Offset: 0x00CB2E54
		private void OnClickButtonUnfold()
		{
			if (!this.CanUnfold)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Terminal_Area_UnlockTip", Array.Empty<object>());
				return;
			}
			if (this.AnimState)
			{
				return;
			}
			AreaTerminalOpenLogEvent areaTerminalOpenLogEvent = new AreaTerminalOpenLogEvent();
			areaTerminalOpenLogEvent.i_type = 1;
			ControllerBase<LogReportController>.Instance.LogReport(areaTerminalOpenLogEvent);
			this.FoldState = false;
			ModelBase<RegionalTerminalModel>.Instance.BarFoldState = this.FoldState;
			this.RefreshState();
			this.LevelSequencePlayer.StopSequenceByKey("Close", true, false);
			this.AnimState = true;
			this.LevelSequencePlayer.PlayOrReplaySequenceByName("Start", false, null);
			List<RegionalTerminalBarGameplayItem> scrollItemList = this.LayoutGameplay.GetScrollItemList();
			if (scrollItemList.Count > 0)
			{
				ControllerBase<UiNavigationNewController>.Instance.SetNavigationFocusForView(scrollItemList[0].GetRootItem(), false, false, false);
			}
		}

		// Token: 0x06032B95 RID: 207765 RVA: 0x00CB4D1E File Offset: 0x00CB2F1E
		private void OnClickButtonMenu()
		{
			ControllerBase<LogReportController>.Instance.LogReport(new AreaTerminalOpenSettingsLogEvent());
			ControllerBase<RegionalTerminalController>.Instance.OpenTerminalOverviewView(0);
		}

		// Token: 0x06032B96 RID: 207766 RVA: 0x00CB4D3C File Offset: 0x00CB2F3C
		private void RefreshGameplayList()
		{
			this.CurrentDataList = ModelBase<RegionalTerminalModel>.Instance.GetGameplayDataList(true);
			this.IsGameplayListShow = (this.CurrentDataList.Count > 0);
			if (this.IsGameplayListShow)
			{
				this.CanUnfold = true;
				this.LayoutGameplay.RefreshByData(this.CurrentDataList, null, false);
			}
			this.HasShowGameplayRedDot = false;
			this.HasTerminalRedDot = false;
			foreach (RegionalTerminalGameplayData regionalTerminalGameplayData in ModelBase<RegionalTerminalModel>.Instance.GameplayDataMap.Values)
			{
				if (this.CurrentDataList.Contains(regionalTerminalGameplayData))
				{
					if (regionalTerminalGameplayData.GetRedDotState())
					{
						this.HasShowGameplayRedDot = true;
					}
				}
				else if (regionalTerminalGameplayData.GetShowState())
				{
					this.CanUnfold = true;
					if (regionalTerminalGameplayData.GetRedDotState())
					{
						this.HasTerminalRedDot = true;
						break;
					}
				}
			}
			this.RefreshRedDot();
		}

		// Token: 0x06032B97 RID: 207767 RVA: 0x00CB4E2C File Offset: 0x00CB302C
		private void RefreshState()
		{
			base.GetButton(2).RootUIComp.Get().SetUIActive(!this.FoldState);
			base.GetButton(5).RootUIComp.Get().SetUIActive(!this.FoldState);
			base.GetButton(7).RootUIComp.Get().SetUIActive(this.FoldState);
			base.GetScrollViewWithScrollbar(0).RootUIComp.Get().SetUIActive(this.IsGameplayListShow && !this.FoldState);
		}

		// Token: 0x06032B98 RID: 207768 RVA: 0x00CB4EC9 File Offset: 0x00CB30C9
		private void RefreshRedDot()
		{
			base.GetItem(6).SetUIActive(this.HasTerminalRedDot);
			base.GetItem(9).SetUIActive(this.HasShowGameplayRedDot || this.HasTerminalRedDot);
		}

		// Token: 0x06032B99 RID: 207769 RVA: 0x00CB4EFB File Offset: 0x00CB30FB
		public void SetWorldMapSelfShow(EWorldMapShowMode showMode)
		{
			this.ShowMode = showMode;
		}

		// Token: 0x06032B9A RID: 207770 RVA: 0x00CB4F04 File Offset: 0x00CB3104
		public void RefreshWorldMapSelfShow(EWorldMapShowMode showMode)
		{
			base.SetUiActive(this.IsAvailableShow());
		}

		// Token: 0x06032B9B RID: 207771 RVA: 0x00CB4F12 File Offset: 0x00CB3112
		public bool IsAvailableShow()
		{
			return this.ShowMode == EWorldMapShowMode.Default;
		}

		// Token: 0x06032B9C RID: 207772 RVA: 0x00CB4F20 File Offset: 0x00CB3120
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
		{
			if (configParams.Length == 0)
			{
				return null;
			}
			if (configParams[0] == "BarItem")
			{
				int num = int.Parse(configParams[1]);
				int i = 0;
				while (i < this.CurrentDataList.Count)
				{
					if (this.CurrentDataList[i].Id == num)
					{
						GenericScrollViewNew<RegionalTerminalBarGameplayItem, RegionalTerminalGameplayData> layoutGameplay = this.LayoutGameplay;
						UUIItem uuiitem;
						if (layoutGameplay == null)
						{
							uuiitem = null;
						}
						else
						{
							GenericLayout<RegionalTerminalBarGameplayItem, RegionalTerminalGameplayData> genericLayout = layoutGameplay.GetGenericLayout();
							if (genericLayout == null)
							{
								uuiitem = null;
							}
							else
							{
								RegionalTerminalBarGameplayItem layoutItemByIndex = genericLayout.GetLayoutItemByIndex(i);
								uuiitem = ((layoutItemByIndex != null) ? layoutItemByIndex.GetRootItem() : null);
							}
						}
						UUIItem uuiitem2 = uuiitem;
						if (uuiitem2 == null)
						{
							return null;
						}
						return new UUIItem[]
						{
							uuiitem2,
							uuiitem2
						};
					}
					else
					{
						i++;
					}
				}
			}
			return null;
		}

		// Token: 0x0401D85E RID: 120926
		private LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x0401D85F RID: 120927
		private GenericScrollViewNew<RegionalTerminalBarGameplayItem, RegionalTerminalGameplayData> LayoutGameplay;

		// Token: 0x0401D860 RID: 120928
		private bool HasTerminalRedDot;

		// Token: 0x0401D861 RID: 120929
		private bool HasShowGameplayRedDot;

		// Token: 0x0401D862 RID: 120930
		private bool FoldState;

		// Token: 0x0401D863 RID: 120931
		private bool CanUnfold;

		// Token: 0x0401D864 RID: 120932
		private bool AnimState;

		// Token: 0x0401D865 RID: 120933
		private bool IsGameplayListShow;

		// Token: 0x0401D867 RID: 120935
		private List<RegionalTerminalGameplayData> CurrentDataList = new List<RegionalTerminalGameplayData>();

		// Token: 0x0200ACDE RID: 44254
		[NullableContext(0)]
		public static class EComponents
		{
			// Token: 0x04035B13 RID: 219923
			public const int ScrollView = 0;

			// Token: 0x04035B14 RID: 219924
			public const int GameplayItem = 1;

			// Token: 0x04035B15 RID: 219925
			public const int BtnFold = 2;

			// Token: 0x04035B16 RID: 219926
			public const int ItemLockBtnFold = 3;

			// Token: 0x04035B17 RID: 219927
			public const int RedDotBtnFold = 4;

			// Token: 0x04035B18 RID: 219928
			public const int BtnMenu = 5;

			// Token: 0x04035B19 RID: 219929
			public const int RedDotBtnMenu = 6;

			// Token: 0x04035B1A RID: 219930
			public const int BtnUnfold = 7;

			// Token: 0x04035B1B RID: 219931
			public const int ItemLockBtnUnfold = 8;

			// Token: 0x04035B1C RID: 219932
			public const int RedDotBtnUnfold = 9;
		}

		// Token: 0x0200ACDF RID: 44255
		[Nullable(0)]
		public static class ESequenceName
		{
			// Token: 0x04035B1D RID: 219933
			public const string Start = "Start";

			// Token: 0x04035B1E RID: 219934
			public const string Close = "Close";
		}
	}
}
