using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Area;
using CSharpScript.Game.Module.Map;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.Map.Mark;
using CSharpScript.Game.Module.Map.Marks.MarkItem;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Module.WorldMap.ViewComponent;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.WorldMap.SubViews.WorldMapQuickNavigate
{
	// Token: 0x02004B76 RID: 19318
	[NullableContext(1)]
	[Nullable(0)]
	public class WorldMapQuickNavigatePanel : WorldMapSecondaryUi
	{
		// Token: 0x0603275C RID: 206684 RVA: 0x00C9F2D7 File Offset: 0x00C9D4D7
		public override string GetResourceId()
		{
			return "UiItem_MapChange";
		}

		// Token: 0x0603275D RID: 206685 RVA: 0x00C9F2E0 File Offset: 0x00C9D4E0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 7;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIDynScrollViewComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUILoopScrollViewComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIHorizontalLayout));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603275E RID: 206686 RVA: 0x00C9F3EE File Offset: 0x00C9D5EE
		protected override PopupTypeRightItem GetPopupRightItem()
		{
			return new PopupRightItemA();
		}

		// Token: 0x0603275F RID: 206687 RVA: 0x00C9F3F8 File Offset: 0x00C9D5F8
		protected override UniTask OnBeforeStartAsync()
		{
			WorldMapQuickNavigatePanel.<OnBeforeStartAsync>d__10 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<WorldMapQuickNavigatePanel.<OnBeforeStartAsync>d__10>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06032760 RID: 206688 RVA: 0x00C9F43C File Offset: 0x00C9D63C
		protected override void OnStart()
		{
			UUIItem rootItem = base.GetRootItem();
			this.SequencePlayer = new UiSequencePlayer(rootItem);
		}

		// Token: 0x06032761 RID: 206689 RVA: 0x00C9F45C File Offset: 0x00C9D65C
		protected override void OnBeforeShow()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.WorldMapFirstNavigateSelect, new Action<QuickNavigateDynamicData>(this.OnFirstNavigateSelect));
			Singleton<EventSystem>.Instance.Add(EEventName.WorldMapSecondNavigateSelect, new Action<int>(this.OnSecondNavigateSelect));
			Singleton<EventSystem>.Instance.Add(EEventName.WorldMapBeforeChangeMap, new Action(this.OnBeforeChangeMap));
			Singleton<EventSystem>.Instance.Add(EEventName.WorldMapAfterChangeMap, new Action(this.OnAfterChangeMap));
			Singleton<EventSystem>.Instance.Add(EEventName.UpdateOnlinePlayersArea, new Action(this.OnUpdateOnlinePlayersArea));
			Singleton<EventSystem>.Instance.Add(EEventName.PlayerMarkItemChanged, new Action(this.OnPlayerMarkItemChanged));
			int num = Singleton<TimeUtil>.Instance.InverseMillisecond * 3;
			this.RefreshTimerHandle = TimerSystem.RealTimeInstance.Forever(new TTimerAction(this.OnTimerRefresh), (float)num, 1f, null, null, true);
			this.OnTimerRefresh(0f);
		}

		// Token: 0x06032762 RID: 206690 RVA: 0x00C9F550 File Offset: 0x00C9D750
		protected override void OnAfterHide()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.WorldMapFirstNavigateSelect, new Action<QuickNavigateDynamicData>(this.OnFirstNavigateSelect));
			Singleton<EventSystem>.Instance.Remove(EEventName.WorldMapSecondNavigateSelect, new Action<int>(this.OnSecondNavigateSelect));
			Singleton<EventSystem>.Instance.Remove(EEventName.WorldMapBeforeChangeMap, new Action(this.OnBeforeChangeMap));
			Singleton<EventSystem>.Instance.Remove(EEventName.WorldMapAfterChangeMap, new Action(this.OnAfterChangeMap));
			Singleton<EventSystem>.Instance.Remove(EEventName.UpdateOnlinePlayersArea, new Action(this.OnUpdateOnlinePlayersArea));
			Singleton<EventSystem>.Instance.Remove(EEventName.PlayerMarkItemChanged, new Action(this.OnPlayerMarkItemChanged));
			this.ClearTimer();
		}

		// Token: 0x06032763 RID: 206691 RVA: 0x00C9F60C File Offset: 0x00C9D80C
		private void SetupSelection()
		{
			if (this.SelectionInfo == null)
			{
				this.SelectionInfo = new SelectionInfo
				{
					FirstIndex = 0,
					SecondIndex = 0,
					CountryId = 0,
					ExpandCountry = true,
					StateId = 0,
					AreaId = 0
				};
				int worldMapLevelOneAreaId = MapUtil.GetWorldMapLevelOneAreaId();
				IWorldMapNavigate valueOrDefault = ConfigBase<MapConfig>.Instance.WorldMapNavigateAreaMap.GetValueOrDefault(worldMapLevelOneAreaId);
				if (valueOrDefault != null)
				{
					this.SelectionInfo.CountryId = valueOrDefault.CountryId;
					this.SelectionInfo.StateId = valueOrDefault.StateId.GetValueOrDefault();
					this.SelectionInfo.AreaId = valueOrDefault.AreaId;
				}
			}
		}

		// Token: 0x06032764 RID: 206692 RVA: 0x00C9F6AE File Offset: 0x00C9D8AE
		protected override void OnShowWorldMapSecondaryUi(params object[] parameters)
		{
			this.SetupSelection();
			this.RefreshNavigateLayout(ERefreshNavigateType.All);
		}

		// Token: 0x06032765 RID: 206693 RVA: 0x00C9F6C0 File Offset: 0x00C9D8C0
		protected override UniTask OnBeforeShowWorldMapSecondaryUiAsync(params object[] parameters)
		{
			WorldMapQuickNavigatePanel.<OnBeforeShowWorldMapSecondaryUiAsync>d__16 <OnBeforeShowWorldMapSecondaryUiAsync>d__;
			<OnBeforeShowWorldMapSecondaryUiAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeShowWorldMapSecondaryUiAsync>d__.<>4__this = this;
			<OnBeforeShowWorldMapSecondaryUiAsync>d__.parameters = parameters;
			<OnBeforeShowWorldMapSecondaryUiAsync>d__.<>1__state = -1;
			<OnBeforeShowWorldMapSecondaryUiAsync>d__.<>t__builder.Start<WorldMapQuickNavigatePanel.<OnBeforeShowWorldMapSecondaryUiAsync>d__16>(ref <OnBeforeShowWorldMapSecondaryUiAsync>d__);
			return <OnBeforeShowWorldMapSecondaryUiAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06032766 RID: 206694 RVA: 0x00C9F70B File Offset: 0x00C9D90B
		protected override void OnCloseWorldMapSecondaryUi()
		{
			this.SelectionInfo = null;
		}

		// Token: 0x06032767 RID: 206695 RVA: 0x00C9F714 File Offset: 0x00C9D914
		protected override void OnBeforeDestroy()
		{
			LoopScrollView<QuickNavigateLoopScrollAreaGridItem, QuickNavigateLoopScrollAreaGridItemData> areaLoopScrollView = this.AreaLoopScrollView;
			if (areaLoopScrollView != null)
			{
				areaLoopScrollView.ClearGridProxies();
			}
			this.AreaLoopScrollView = null;
			DynamicScrollView<QuickNavigateDynamicScrollItem, QuickNavigateDynamicItem, QuickNavigateDynamicData> dynamicScrollView = this.DynamicScrollView;
			if (dynamicScrollView != null)
			{
				dynamicScrollView.ClearChildren();
			}
			this.DynamicScrollView = null;
			this.IconLayout = null;
		}

		// Token: 0x06032768 RID: 206696 RVA: 0x00C9F74D File Offset: 0x00C9D94D
		private QuickNavigateLoopScrollAreaGridItem OnGridProxyCreate()
		{
			return new QuickNavigateLoopScrollAreaGridItem();
		}

		// Token: 0x06032769 RID: 206697 RVA: 0x00C9F754 File Offset: 0x00C9D954
		private QuickNavigateDynamicScrollItem CreateItemFunc(QuickNavigateDynamicData data, UUIItem uiItem, int index)
		{
			return new QuickNavigateDynamicScrollItem();
		}

		// Token: 0x0603276A RID: 206698 RVA: 0x00C9F75C File Offset: 0x00C9D95C
		private void RefreshNavigateLayout(ERefreshNavigateType refreshType)
		{
			if (refreshType == ERefreshNavigateType.All || refreshType == ERefreshNavigateType.StateOnly)
			{
				QuickNavigateDynamicData[] dynamicScrollViewDataList = this.GetDynamicScrollViewDataList(refreshType);
				this.DynamicScrollView.RefreshByData(dynamicScrollViewDataList, false, false);
			}
			if (refreshType == ERefreshNavigateType.StateAndAreaBoth)
			{
				QuickNavigateDynamicData[] dynamicScrollViewDataList2 = this.GetDynamicScrollViewDataList(refreshType);
				int num = 0;
				QuickNavigateDynamicScrollItem[] scrollItemItems = this.DynamicScrollView.GetScrollItemItems();
				for (int i = 0; i < scrollItemItems.Length; i++)
				{
					scrollItemItems[i].Update(dynamicScrollViewDataList2[num], num++);
				}
			}
			if (refreshType == ERefreshNavigateType.All || refreshType == ERefreshNavigateType.AreaOnly || refreshType == ERefreshNavigateType.StateAndAreaBoth)
			{
				List<QuickNavigateLoopScrollAreaGridItemData> gridItemDataList = this.GetAreaGridItemDataList(refreshType);
				this.AreaLoopScrollView.RefreshByData(gridItemDataList, false, delegate
				{
					if (refreshType != ERefreshNavigateType.All)
					{
						if (this.IsRepeatSelectCountry)
						{
							LoopScrollView<QuickNavigateLoopScrollAreaGridItem, QuickNavigateLoopScrollAreaGridItemData> areaLoopScrollView = this.AreaLoopScrollView;
							if (areaLoopScrollView != null)
							{
								areaLoopScrollView.ScrollToGridIndex(0, false);
							}
							this.IsRepeatSelectCountry = false;
						}
						return;
					}
					int gridIndex = gridItemDataList.FindIndex((QuickNavigateLoopScrollAreaGridItemData item) => item.IsSelected);
					LoopScrollView<QuickNavigateLoopScrollAreaGridItem, QuickNavigateLoopScrollAreaGridItemData> areaLoopScrollView2 = this.AreaLoopScrollView;
					if (areaLoopScrollView2 == null)
					{
						return;
					}
					areaLoopScrollView2.ScrollToGridIndex(gridIndex, false);
				}, false);
			}
		}

		// Token: 0x0603276B RID: 206699 RVA: 0x00C9F840 File Offset: 0x00C9DA40
		private QuickNavigateDynamicData[] GetDynamicScrollViewDataList(ERefreshNavigateType refreshType)
		{
			List<IWorldMapNavigateCountryData> worldMapNavigateCountryList = ConfigBase<MapConfig>.Instance.WorldMapNavigateCountryList;
			List<QuickNavigateDynamicData> list = new List<QuickNavigateDynamicData>();
			foreach (IWorldMapNavigateCountryData worldMapNavigateCountryData in worldMapNavigateCountryList)
			{
				int countryId = worldMapNavigateCountryData.CountryId;
				IWorldMapNavigateCountry navigateCountry = worldMapNavigateCountryData.NavigateCountry;
				QuickNavigateDynamicData quickNavigateDynamicData = new QuickNavigateDynamicData();
				quickNavigateDynamicData.ItemType = EQuickNavigateItemType.Country;
				quickNavigateDynamicData.CountryId = countryId;
				quickNavigateDynamicData.Index = list.Count;
				quickNavigateDynamicData.IsSelected = (this.SelectionInfo.CountryId == countryId);
				quickNavigateDynamicData.RefreshType = refreshType;
				quickNavigateDynamicData.HasState = (navigateCountry.StateMap != null);
				quickNavigateDynamicData.IsExpand = (this.SelectionInfo.CountryId == countryId && this.SelectionInfo.ExpandCountry);
				list.Add(quickNavigateDynamicData);
				if (navigateCountry.StateMap != null)
				{
					using (IEnumerator<IWorldMapNavigateState> enumerator2 = (from a in navigateCountry.StateMap.Values
					orderby a.SortIndex
					select a).GetEnumerator())
					{
						while (enumerator2.MoveNext())
						{
							IWorldMapNavigateState worldMapNavigateState = enumerator2.Current;
							if (this.SelectionInfo.CountryId == 0)
							{
								this.SelectionInfo.CountryId = countryId;
								this.SelectionInfo.ExpandCountry = true;
								this.SelectionInfo.StateId = worldMapNavigateState.StateId;
								this.SelectionInfo.AreaId = worldMapNavigateState.AreaNavigateList[0].AreaId;
								quickNavigateDynamicData.IsSelected = (this.SelectionInfo.CountryId == countryId);
								quickNavigateDynamicData.IsExpand = true;
							}
							quickNavigateDynamicData.StateId = worldMapNavigateState.StateId;
							bool flag = this.SelectionInfo.CountryId == countryId;
							bool expandCountry = this.SelectionInfo.ExpandCountry;
							if (flag && expandCountry)
							{
								this.SelectionInfo.FirstIndex = list.Count - 1;
								list.Add(new QuickNavigateDynamicData
								{
									ItemType = EQuickNavigateItemType.State,
									CountryId = countryId,
									StateId = worldMapNavigateState.StateId,
									Index = list.Count,
									IsSelected = (this.SelectionInfo.StateId == worldMapNavigateState.StateId),
									RefreshType = refreshType
								});
								if (this.SelectionInfo.StateId == worldMapNavigateState.StateId)
								{
									this.SelectionInfo.FirstIndex = list.Count - 1;
								}
							}
						}
						continue;
					}
				}
				if (this.SelectionInfo.CountryId == 0)
				{
					this.SelectionInfo.CountryId = countryId;
					this.SelectionInfo.ExpandCountry = false;
					this.SelectionInfo.StateId = 0;
					this.SelectionInfo.AreaId = navigateCountry.AreaNavigateList[0].AreaId;
					quickNavigateDynamicData.IsSelected = (this.SelectionInfo.CountryId == countryId);
				}
			}
			return list.ToArray();
		}

		// Token: 0x0603276C RID: 206700 RVA: 0x00C9FB54 File Offset: 0x00C9DD54
		private List<QuickNavigateLoopScrollAreaGridItemData> GetAreaGridItemDataList(ERefreshNavigateType refreshType)
		{
			List<QuickNavigateLoopScrollAreaGridItemData> list = new List<QuickNavigateLoopScrollAreaGridItemData>();
			int countryId = this.SelectionInfo.CountryId;
			int stateId = this.SelectionInfo.StateId;
			IWorldMapNavigateCountry valueOrDefault = ConfigBase<MapConfig>.Instance.WorldMapNavigateCountryMap.GetValueOrDefault(countryId);
			List<IWorldMapNavigate> areaNavigateList = valueOrDefault.AreaNavigateList;
			if (valueOrDefault.StateMap != null)
			{
				areaNavigateList = valueOrDefault.StateMap.GetValueOrDefault(stateId).AreaNavigateList;
			}
			foreach (IWorldMapNavigate worldMapNavigate in areaNavigateList)
			{
				QuickNavigateLoopScrollAreaGridItemData quickNavigateLoopScrollAreaGridItemData = new QuickNavigateLoopScrollAreaGridItemData();
				quickNavigateLoopScrollAreaGridItemData.AreaNavigateInfo = worldMapNavigate;
				quickNavigateLoopScrollAreaGridItemData.Index = list.Count;
				quickNavigateLoopScrollAreaGridItemData.RefreshType = refreshType;
				list.Add(quickNavigateLoopScrollAreaGridItemData);
				if (this.SelectionInfo.AreaId == 0)
				{
					this.SelectionInfo.AreaId = worldMapNavigate.AreaId;
				}
				if (this.SelectionInfo.AreaId == worldMapNavigate.AreaId)
				{
					this.SelectionInfo.FirstIndex = list.Count - 1;
				}
				quickNavigateLoopScrollAreaGridItemData.IsSelected = (this.SelectionInfo.AreaId == worldMapNavigate.AreaId);
			}
			return list;
		}

		// Token: 0x0603276D RID: 206701 RVA: 0x00C9FC88 File Offset: 0x00C9DE88
		private void Select(ISelectionInfo selectInfo)
		{
			IWorldMapNavigateCountry valueOrDefault = ConfigBase<MapConfig>.Instance.WorldMapNavigateCountryMap.GetValueOrDefault(selectInfo.CountryId);
			bool flag = ((valueOrDefault != null) ? valueOrDefault.StateMap : null) != null;
			int stateId = selectInfo.StateId;
			ISelectionInfo selectionInfo = this.SelectionInfo;
			int? num = (selectionInfo != null) ? new int?(selectionInfo.StateId) : null;
			bool flag2 = !(stateId == num.GetValueOrDefault() & num != null);
			bool flag4;
			if (flag)
			{
				bool expandCountry = selectInfo.ExpandCountry;
				ISelectionInfo selectionInfo2 = this.SelectionInfo;
				bool? flag3 = (selectionInfo2 != null) ? new bool?(selectionInfo2.ExpandCountry) : null;
				flag4 = !(expandCountry == flag3.GetValueOrDefault() & flag3 != null);
			}
			else
			{
				flag4 = false;
			}
			bool flag5 = flag4;
			int countryId = selectInfo.CountryId;
			ISelectionInfo selectionInfo3 = this.SelectionInfo;
			num = ((selectionInfo3 != null) ? new int?(selectionInfo3.CountryId) : null);
			bool flag6 = !(countryId == num.GetValueOrDefault() & num != null);
			bool flag7 = flag5 || flag6;
			this.SelectionInfo = selectInfo;
			if (!flag2 && !flag7)
			{
				ERefreshNavigateType refreshType = ERefreshNavigateType.AreaOnly;
				this.RefreshNavigateLayout(refreshType);
				this.ExecuteSelection(false);
				return;
			}
			if (flag2 && !flag7)
			{
				ERefreshNavigateType refreshType = ERefreshNavigateType.StateAndAreaBoth;
				this.RefreshNavigateLayout(refreshType);
				this.ExecuteSelection(false);
				return;
			}
			if (flag6)
			{
				ERefreshNavigateType refreshType = ERefreshNavigateType.All;
				this.RefreshNavigateLayout(refreshType);
				this.ExecuteSelection(false);
				return;
			}
			if (flag5)
			{
				ERefreshNavigateType refreshType = ERefreshNavigateType.StateOnly;
				this.RefreshNavigateLayout(refreshType);
			}
		}

		// Token: 0x0603276E RID: 206702 RVA: 0x00C9FDDC File Offset: 0x00C9DFDC
		private void SelectCountry(int countryId, int index)
		{
			IWorldMapNavigateCountry valueOrDefault = ConfigBase<MapConfig>.Instance.WorldMapNavigateCountryMap.GetValueOrDefault(countryId);
			bool expandCountry = !this.SelectionInfo.ExpandCountry;
			bool flag = countryId != this.SelectionInfo.CountryId;
			if (valueOrDefault.StateMap != null)
			{
				if (flag)
				{
					expandCountry = true;
				}
				IWorldMapNavigateState worldMapNavigateState = (from a in valueOrDefault.StateMap.Values
				orderby a.SortIndex
				select a).First<IWorldMapNavigateState>();
				IWorldMapNavigate worldMapNavigate = worldMapNavigateState.AreaNavigateList[0];
				ISelectionInfo selectionInfo = this.SelectionInfo;
				int? num = (selectionInfo != null) ? new int?(selectionInfo.CountryId) : null;
				this.IsRepeatSelectCountry = (countryId == num.GetValueOrDefault() & num != null);
				this.Select(new SelectionInfo
				{
					FirstIndex = index,
					SecondIndex = 0,
					CountryId = countryId,
					ExpandCountry = expandCountry,
					StateId = (this.IsRepeatSelectCountry ? this.SelectionInfo.StateId : worldMapNavigateState.StateId),
					AreaId = worldMapNavigate.AreaId
				});
			}
			else
			{
				ISelectionInfo selectionInfo2 = this.SelectionInfo;
				int? num = (selectionInfo2 != null) ? new int?(selectionInfo2.CountryId) : null;
				this.IsRepeatSelectCountry = (countryId == num.GetValueOrDefault() & num != null);
				this.Select(new SelectionInfo
				{
					FirstIndex = index,
					SecondIndex = 0,
					CountryId = countryId,
					ExpandCountry = false,
					StateId = 0,
					AreaId = valueOrDefault.AreaNavigateList[0].AreaId
				});
			}
			if (flag)
			{
				if (this.SequencePlayer.IsSequenceInPlaying("Switch"))
				{
					this.SequencePlayer.ReplaySequence("Switch");
					return;
				}
				this.SequencePlayer.PlaySequence("Switch", false, null);
			}
		}

		// Token: 0x0603276F RID: 206703 RVA: 0x00C9FFC0 File Offset: 0x00C9E1C0
		private void SelectState(int stateId, int index)
		{
			bool flag = stateId != this.SelectionInfo.StateId;
			IWorldMapNavigateState valueOrDefault = ConfigBase<MapConfig>.Instance.WorldMapNavigateCountryMap.GetValueOrDefault(this.SelectionInfo.CountryId).StateMap.GetValueOrDefault(stateId);
			SelectionInfo selectionInfo = new SelectionInfo();
			selectionInfo.FirstIndex = index;
			selectionInfo.SecondIndex = 0;
			selectionInfo.CountryId = this.SelectionInfo.CountryId;
			ISelectionInfo selectionInfo2 = this.SelectionInfo;
			selectionInfo.ExpandCountry = (selectionInfo2 == null || selectionInfo2.ExpandCountry);
			selectionInfo.StateId = stateId;
			selectionInfo.AreaId = valueOrDefault.AreaNavigateList[0].AreaId;
			this.Select(selectionInfo);
			if (flag)
			{
				if (this.SequencePlayer.IsSequenceInPlaying("Switch"))
				{
					this.SequencePlayer.ReplaySequence("Switch");
					return;
				}
				this.SequencePlayer.PlaySequence("Switch", false, null);
			}
		}

		// Token: 0x06032770 RID: 206704 RVA: 0x00CA00A4 File Offset: 0x00C9E2A4
		private void SelectArea(int areaId, int index)
		{
			SelectionInfo selectionInfo = new SelectionInfo();
			selectionInfo.FirstIndex = this.SelectionInfo.FirstIndex;
			selectionInfo.SecondIndex = index;
			selectionInfo.CountryId = this.SelectionInfo.CountryId;
			ISelectionInfo selectionInfo2 = this.SelectionInfo;
			selectionInfo.ExpandCountry = (selectionInfo2 == null || selectionInfo2.ExpandCountry);
			selectionInfo.StateId = this.SelectionInfo.StateId;
			selectionInfo.AreaId = areaId;
			this.Select(selectionInfo);
		}

		// Token: 0x06032771 RID: 206705 RVA: 0x00CA0118 File Offset: 0x00C9E318
		private void ExecuteSelection(bool closeView = false)
		{
			if (closeView)
			{
				base.Close();
			}
			IWorldMapNavigate valueOrDefault = ConfigBase<MapConfig>.Instance.WorldMapNavigateAreaMap.GetValueOrDefault(this.SelectionInfo.AreaId);
			Singleton<EventSystem>.Instance.Emit<NavigateMark>(EEventName.WorldMapNavigate, new NavigateMark
			{
				MarkId = valueOrDefault.MarkId,
				MarkType = valueOrDefault.MarkType
			});
		}

		// Token: 0x06032772 RID: 206706 RVA: 0x00CA0176 File Offset: 0x00C9E376
		private void OnFirstNavigateSelect(QuickNavigateDynamicData navigateDynamicData)
		{
			if (navigateDynamicData.ItemType == EQuickNavigateItemType.Country)
			{
				this.SelectCountry(navigateDynamicData.CountryId, navigateDynamicData.Index);
				return;
			}
			this.SelectState(navigateDynamicData.StateId, navigateDynamicData.Index);
		}

		// Token: 0x06032773 RID: 206707 RVA: 0x00CA01A8 File Offset: 0x00C9E3A8
		private void OnSecondNavigateSelect(int gridIndex)
		{
			IWorldMapNavigate areaNavigateInfo = this.AreaLoopScrollView.TryGetCachedData(gridIndex).AreaNavigateInfo;
			this.SelectArea(areaNavigateInfo.AreaId, gridIndex);
		}

		// Token: 0x06032774 RID: 206708 RVA: 0x00CA01D4 File Offset: 0x00C9E3D4
		private void OnBeforeChangeMap()
		{
			base.GetItem(5).SetUIActive(true);
		}

		// Token: 0x06032775 RID: 206709 RVA: 0x00CA01E3 File Offset: 0x00C9E3E3
		private void OnAfterChangeMap()
		{
			base.GetItem(5).SetUIActive(false);
		}

		// Token: 0x06032776 RID: 206710 RVA: 0x00CA01F2 File Offset: 0x00C9E3F2
		[NullableContext(2)]
		private void OnFocusPlayerClick(int id, MarkItem markItem)
		{
			this.SelectionInfo = null;
			this.SetupSelection();
			this.RefreshNavigateLayout(ERefreshNavigateType.All);
			Singleton<EventSystem>.Instance.Emit(EEventName.WorldMapFocusPlayer);
		}

		// Token: 0x06032777 RID: 206711 RVA: 0x00CA0218 File Offset: 0x00C9E418
		private INavigateIconItemData[] GetNavigateIconDataList(List<MarkItem> navigateMarkItems)
		{
			ModelBase<ExploreProgressModel>.Instance.ClearTrackTaskAreaId();
			List<INavigateIconItemData> list = new List<INavigateIconItemData>();
			foreach (MarkItem markItem in navigateMarkItems)
			{
				EMarkType markType = markItem.MarkType;
				if (markType != EMarkType.OtherPlayers)
				{
					if (markType == EMarkType.Quest)
					{
						list.Add(new NavigateIconItemData
						{
							Id = 1,
							IconPath = markItem.IconPath,
							ClickCallback = new Action<int, MarkItem>(this.OnNavigateIconClick),
							MarkItem = markItem
						});
						this.UpdateTrackTaskArea(markItem);
					}
				}
				else
				{
					int num = (markItem as PlayerMarkItem).PlayerIndex - 1;
					list.Add(new NavigateIconItemData
					{
						Id = 2 + num,
						IconId = WorldMapDefine.OnlinePlayerIconPathList2[num],
						ClickCallback = new Action<int, MarkItem>(this.OnNavigateIconClick),
						MarkItem = markItem
					});
				}
			}
			list.Sort((INavigateIconItemData a, INavigateIconItemData b) => b.Id - a.Id);
			list.Add(new NavigateIconItemData
			{
				Id = 0,
				IconId = "SP_IconCommonPlayer",
				ClickCallback = new Action<int, MarkItem>(this.OnFocusPlayerClick)
			});
			return list.ToArray();
		}

		// Token: 0x06032778 RID: 206712 RVA: 0x00CA0370 File Offset: 0x00C9E570
		[NullableContext(2)]
		private void OnNavigateIconClick(int id, MarkItem markItem = null)
		{
			ControllerBase<UiNavigationNewController>.Instance.MarkViewHandleRefreshNavigationDirty();
			Singleton<EventSystem>.Instance.Emit<EMarkType, int>(EEventName.OnWorldMapTrackMarkItem, markItem.MarkType, markItem.MarkId);
		}

		// Token: 0x06032779 RID: 206713 RVA: 0x00CA0398 File Offset: 0x00C9E598
		private void UpdateTrackTaskArea(MarkItem markItem)
		{
			TTrackTarget trackTarget = markItem.TrackTarget;
			if (!(trackTarget is TTrackTarget_Int))
			{
				return;
			}
			LevelEntityConfig? entityConfigByMapIdAndEntityId = ConfigBase<MapConfig>.Instance.GetEntityConfigByMapIdAndEntityId(markItem.MapId, ((TTrackTarget_Int)trackTarget).Value);
			int? num = (entityConfigByMapIdAndEntityId != null) ? new int?(entityConfigByMapIdAndEntityId.GetValueOrDefault().AreaId) : null;
			if (num != null && num.Value != 0)
			{
				int levelOneAreaId = ConfigBase<AreaConfig>.Instance.GetLevelOneAreaId(num.Value);
				if (levelOneAreaId > 0)
				{
					ModelBase<ExploreProgressModel>.Instance.SetTrackTaskAreaId(levelOneAreaId, markItem.IconPath);
				}
			}
		}

		// Token: 0x0603277A RID: 206714 RVA: 0x00CA0437 File Offset: 0x00C9E637
		private void OnTimerRefresh(float delta)
		{
			if (ModelBase<OnlineModel>.Instance.GetIsTeamModel())
			{
				ControllerBase<ExploreProgressController>.Instance.QueryOnlinePlayersAreaAsyncRequest().Forget();
			}
		}

		// Token: 0x0603277B RID: 206715 RVA: 0x00CA0454 File Offset: 0x00C9E654
		private void ClearTimer()
		{
			if (TimerSystem.RealTimeInstance.Has(this.RefreshTimerHandle))
			{
				TimerSystem.RealTimeInstance.Remove(this.RefreshTimerHandle);
				this.RefreshTimerHandle = null;
			}
		}

		// Token: 0x0603277C RID: 206716 RVA: 0x00CA0480 File Offset: 0x00C9E680
		private void OnUpdateOnlinePlayersArea()
		{
			ERefreshNavigateType refreshType = ERefreshNavigateType.AreaOnly;
			this.RefreshNavigateLayout(refreshType);
		}

		// Token: 0x0603277D RID: 206717 RVA: 0x00CA0498 File Offset: 0x00C9E698
		private void OnPlayerMarkItemChanged()
		{
			List<MarkItem> navigateMarkList = this.Map.GetNavigateMarkList();
			this.OnBeforeShowWorldMapSecondaryUiAsync(new object[]
			{
				navigateMarkList
			}).Forget();
		}

		// Token: 0x0401D716 RID: 120598
		[Nullable(2)]
		private ISelectionInfo SelectionInfo;

		// Token: 0x0401D717 RID: 120599
		[Nullable(2)]
		protected UiSequencePlayer SequencePlayer;

		// Token: 0x0401D718 RID: 120600
		[Nullable(new byte[]
		{
			2,
			1,
			1,
			1
		})]
		private DynamicScrollView<QuickNavigateDynamicScrollItem, QuickNavigateDynamicItem, QuickNavigateDynamicData> DynamicScrollView;

		// Token: 0x0401D719 RID: 120601
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private LoopScrollView<QuickNavigateLoopScrollAreaGridItem, QuickNavigateLoopScrollAreaGridItemData> AreaLoopScrollView;

		// Token: 0x0401D71A RID: 120602
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<NavigateIconItem, INavigateIconItemData> IconLayout;

		// Token: 0x0401D71B RID: 120603
		[Nullable(2)]
		private TimerHandle RefreshTimerHandle;

		// Token: 0x0401D71C RID: 120604
		private bool IsRepeatSelectCountry;
	}
}
