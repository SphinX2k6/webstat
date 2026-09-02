using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Map;
using CSharpScript.Game.Module.Map.Controller;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.Map.Mark;
using CSharpScript.Game.Module.Map.Mark.Misc;
using CSharpScript.Game.Module.Map.Marks.MarkItem;
using CSharpScript.Game.Module.Teleport;
using CSharpScript.Game.Module.Track;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Module.WorldMap;
using CSharpScript.Game.Module.WorldMap.SubViews;
using CSharpScript.Game.Module.WorldMap.SubViews.Common;
using CSharpScript.Game.Module.WorldMap.SubViews.MapMarkToggle;
using CSharpScript.Game.Module.WorldMap.ViewComponent;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Sheriff.View.Map
{
	// Token: 0x02004FDE RID: 20446
	[NullableContext(1)]
	[Nullable(0)]
	public class SheriffMapPanel : WorldMapExtraUiPanel
	{
		// Token: 0x17008A9A RID: 35482
		// (get) Token: 0x06034B71 RID: 215921 RVA: 0x00D38868 File Offset: 0x00D36A68
		// (set) Token: 0x06034B72 RID: 215922 RVA: 0x00D38875 File Offset: 0x00D36A75
		[Nullable(2)]
		public new ISheriffMapPanelParam OpenParam
		{
			[NullableContext(2)]
			get
			{
				return this.OpenParam as ISheriffMapPanelParam;
			}
			[NullableContext(2)]
			set
			{
				this.OpenParam = value;
			}
		}

		// Token: 0x06034B73 RID: 215923 RVA: 0x00D3887E File Offset: 0x00D36A7E
		public SheriffMapPanel(EWorldMapExtraUiPanelName panelName, WorldMapExtraUiPanelComponent extraUiPanelComponent) : base(panelName, extraUiPanelComponent)
		{
		}

		// Token: 0x06034B74 RID: 215924 RVA: 0x00D388A4 File Offset: 0x00D36AA4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 11;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUILayoutBase));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUILayoutBase));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUINiagara));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(4, new Action(this.OnClickBtnShop));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06034B75 RID: 215925 RVA: 0x00D38A76 File Offset: 0x00D36C76
		private void OnClickBtnShop()
		{
			ModelBase<SheriffModel>.Instance.ClearShopRedDot();
			Singleton<UiManager>.Instance.OpenView(EUiViewName.SheriffShopView, null, delegate(bool success, int viewId)
			{
				if (success)
				{
					UiViewBase viewByName = Singleton<UiManager>.Instance.GetViewByName(EUiViewName.WorldMapView);
					if (viewByName == null)
					{
						return;
					}
					viewByName.AddChildViewById(viewId);
				}
			});
		}

		// Token: 0x06034B76 RID: 215926 RVA: 0x00D38AB4 File Offset: 0x00D36CB4
		protected override UniTask OnBeforeStartAsync()
		{
			SheriffMapPanel.<OnBeforeStartAsync>d__17 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<SheriffMapPanel.<OnBeforeStartAsync>d__17>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06034B77 RID: 215927 RVA: 0x00D38AF8 File Offset: 0x00D36CF8
		protected override void OnStart()
		{
			this.InitCaptionItem();
			this.RefreshShopRedDot();
			Singleton<EventSystem>.Instance.Add<int>(EEventName.OnGotoAnomaly, new Action<int>(this.OnGotoAnomaly));
			Singleton<EventSystem>.Instance.Add(EEventName.OnSheriffShopRedDotRefresh, new Action(this.RefreshShopRedDot));
			Singleton<EventSystem>.Instance.Add<int, PayShopDefine.EPayShopTabType, int>(EEventName.RefreshGoods, new Action<int, PayShopDefine.EPayShopTabType, int>(this.OnRefreshGoodsList));
			this.SequencePlayer = new UiSequencePlayer(base.GetRootItem());
			this.RefreshShopText();
			ISheriffMapPanelParam openParam = this.OpenParam;
			if (openParam == null)
			{
				return;
			}
			Action onPanelOpened = openParam.OnPanelOpened;
			if (onPanelOpened == null)
			{
				return;
			}
			onPanelOpened();
		}

		// Token: 0x06034B78 RID: 215928 RVA: 0x00D38B96 File Offset: 0x00D36D96
		private void OnRefreshGoodsList(int goodsId, PayShopDefine.EPayShopTabType payShopId, int tabId)
		{
			this.RefreshShopText();
		}

		// Token: 0x06034B79 RID: 215929 RVA: 0x00D38BA0 File Offset: 0x00D36DA0
		private void RefreshShopText()
		{
			ValueTuple<int, int, int> shopGoodsPriceInfo = ModelBase<SheriffModel>.Instance.GetShopGoodsPriceInfo();
			Singleton<LguiUtil>.Instance.TrySetLocalTextNew(base.GetText(5), "Sheriff_Shop_2", new <>z__ReadOnlyArray<object>(new object[]
			{
				shopGoodsPriceInfo.Item1,
				shopGoodsPriceInfo.Item2
			}));
		}

		// Token: 0x06034B7A RID: 215930 RVA: 0x00D38BF5 File Offset: 0x00D36DF5
		private void RefreshShopRedDot()
		{
			base.GetItem(6).SetUIActive(ModelBase<SheriffModel>.Instance.CheckShopRedDot());
		}

		// Token: 0x06034B7B RID: 215931 RVA: 0x00D38C10 File Offset: 0x00D36E10
		protected override void OnAfterShow()
		{
			UiSequencePlayer sequencePlayer = this.SequencePlayer;
			if (sequencePlayer == null)
			{
				return;
			}
			sequencePlayer.PlaySequence("Start", false, null);
		}

		// Token: 0x06034B7C RID: 215932 RVA: 0x00D38C3C File Offset: 0x00D36E3C
		private void InitCaptionItem()
		{
			this.CaptionItem = new PopupCaptionItem(base.GetItem(0));
			this.CaptionItem.SetCloseCallBack(new Action(this.CloseCallBack));
			this.CaptionItem.SetTitleLocalText("Activity_110600001_Title");
			this.CaptionItem.CreateHomeBtn(EUiViewName.WorldMapView, null, false);
			this.CaptionItem.SetHelpCallBack(delegate
			{
				ControllerBase<HelpController>.Instance.OpenHelpById(618);
			});
		}

		// Token: 0x06034B7D RID: 215933 RVA: 0x00D38CBE File Offset: 0x00D36EBE
		private void CloseCallBack()
		{
			base.CloseMe();
		}

		// Token: 0x06034B7E RID: 215934 RVA: 0x00D38CC8 File Offset: 0x00D36EC8
		private UniTask InitCommonMapItemsView()
		{
			SheriffMapPanel.<InitCommonMapItemsView>d__25 <InitCommonMapItemsView>d__;
			<InitCommonMapItemsView>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitCommonMapItemsView>d__.<>4__this = this;
			<InitCommonMapItemsView>d__.<>1__state = -1;
			<InitCommonMapItemsView>d__.<>t__builder.Start<SheriffMapPanel.<InitCommonMapItemsView>d__25>(ref <InitCommonMapItemsView>d__);
			return <InitCommonMapItemsView>d__.<>t__builder.Task;
		}

		// Token: 0x06034B7F RID: 215935 RVA: 0x00D38D0C File Offset: 0x00D36F0C
		private void OnClickBtnSwitch()
		{
			List<IMapMarkToggleItemData> list = new List<IMapMarkToggleItemData>();
			if (this.CurrentMainTabType == ESheriffMainTabType.Event)
			{
				list.Add(new MapMarkToggleItemData
				{
					NameId = "FunctionMap_Content_13",
					GetToggleResultCallback = new Func<EToggleState>(this.GetHideCompletedMarkItemToggleState),
					SetToggleStateCallback = new Func<EToggleState, bool>(this.SetHideCompletedMarkItemToggleState)
				});
			}
			WorldMapUiEntity worldMapUiComponent = this.ExtraUiPanelComponent.WorldMapUiComponent;
			if (worldMapUiComponent == null)
			{
				return;
			}
			worldMapUiComponent.SecondaryUiComponent.ShowMapMarkTogglePanel(this.ParentUiItem, list, null);
		}

		// Token: 0x06034B80 RID: 215936 RVA: 0x00D38D83 File Offset: 0x00D36F83
		private EToggleState GetHideCompletedMarkItemToggleState()
		{
			if (!LocalStorage.GetPlayer<bool>(ELocalStoragePlayerKey.SheriffHideCompletedMarkItem, false))
			{
				return EToggleState.ETT_UnChecked;
			}
			return EToggleState.ETT_Checked;
		}

		// Token: 0x06034B81 RID: 215937 RVA: 0x00D38D98 File Offset: 0x00D36F98
		private bool SetHideCompletedMarkItemToggleState(EToggleState state)
		{
			LocalStorage.SetPlayer<bool>(ELocalStoragePlayerKey.SheriffHideCompletedMarkItem, state == EToggleState.ETT_Checked);
			WorldMapUiEntity worldMapUiComponent = this.ExtraUiPanelComponent.WorldMapUiComponent;
			if (worldMapUiComponent != null)
			{
				worldMapUiComponent.UpdateMarkItems(null);
			}
			return true;
		}

		// Token: 0x06034B82 RID: 215938 RVA: 0x00D38DD4 File Offset: 0x00D36FD4
		private UniTask InitMainTabLayout()
		{
			SheriffMapPanel.<InitMainTabLayout>d__29 <InitMainTabLayout>d__;
			<InitMainTabLayout>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitMainTabLayout>d__.<>4__this = this;
			<InitMainTabLayout>d__.<>1__state = -1;
			<InitMainTabLayout>d__.<>t__builder.Start<SheriffMapPanel.<InitMainTabLayout>d__29>(ref <InitMainTabLayout>d__);
			return <InitMainTabLayout>d__.<>t__builder.Task;
		}

		// Token: 0x06034B83 RID: 215939 RVA: 0x00D38E18 File Offset: 0x00D37018
		private UniTask RefreshMainTabLayout()
		{
			SheriffMapPanel.<RefreshMainTabLayout>d__30 <RefreshMainTabLayout>d__;
			<RefreshMainTabLayout>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshMainTabLayout>d__.<>4__this = this;
			<RefreshMainTabLayout>d__.<>1__state = -1;
			<RefreshMainTabLayout>d__.<>t__builder.Start<SheriffMapPanel.<RefreshMainTabLayout>d__30>(ref <RefreshMainTabLayout>d__);
			return <RefreshMainTabLayout>d__.<>t__builder.Task;
		}

		// Token: 0x06034B84 RID: 215940 RVA: 0x00D38E5B File Offset: 0x00D3705B
		private ESheriffMainTabType GetDefaultMainTabType()
		{
			return ESheriffMainTabType.Event;
		}

		// Token: 0x06034B85 RID: 215941 RVA: 0x00D38E5E File Offset: 0x00D3705E
		private SheriffMapMainTabItem CreateMainTabItem()
		{
			return new SheriffMapMainTabItem
			{
				SelectCallBack = new Action<ISheriffMainTabItemData>(this.OnSelectMainTab)
			};
		}

		// Token: 0x06034B86 RID: 215942 RVA: 0x00D38E78 File Offset: 0x00D37078
		private void OnSelectMainTab(ISheriffMainTabItemData data)
		{
			this.CurrentMainTabType = data.TabType;
			this.RefreshSubTabLayout(data.TabType);
			this.ExtraUiPanelComponent.RefreshExtraMark();
			this.ExtraUiPanelComponent.RefreshScaleParam();
			this.ExtraUiPanelComponent.UpdateMarkItems();
			if (data.TabType == ESheriffMainTabType.Event)
			{
				Singleton<EventSystem>.Instance.Emit<string>(EEventName.OnGuideTriggerEvent, "SheriffMapEventTabShow");
				return;
			}
			if (data.TabType == ESheriffMainTabType.Quest)
			{
				Singleton<EventSystem>.Instance.Emit<string>(EEventName.OnGuideTriggerEvent, "SheriffMapQuestTabShow");
			}
		}

		// Token: 0x06034B87 RID: 215943 RVA: 0x00D38EFA File Offset: 0x00D370FA
		private void InitSubTabLayout()
		{
			this.SubTabLayout = new GenericLayout<SheriffMapSubTabItem, ISheriffSubTabItemData>(base.GetLayoutBase(2), new Func<SheriffMapSubTabItem>(this.CreateSubTabItem), null, false, true);
		}

		// Token: 0x06034B88 RID: 215944 RVA: 0x00D38F20 File Offset: 0x00D37120
		private void RefreshSubTabLayout(ESheriffMainTabType tabType)
		{
			this.SubTabItemDataList.Clear();
			if (tabType != ESheriffMainTabType.Event)
			{
				if (tabType == ESheriffMainTabType.Quest)
				{
					SheriffQuestState questState = ModelBase<SheriffModel>.Instance.GetQuestState(this.CurrentZoneId, ESheriffQuestType.POI);
					if (questState.TotalList.Count > 0)
					{
						int current = questState.TotalList.Count - questState.UnFinishList.Count;
						this.PushSubTabItem(ESheriffSubTabType.POI, "SP_IconMap_Task_10_UI", "FunctionMap_Content_5", current, questState.TotalList.Count);
					}
					SheriffQuestState questState2 = ModelBase<SheriffModel>.Instance.GetQuestState(this.CurrentZoneId, ESheriffQuestType.Branch);
					if (questState2.TotalList.Count > 0)
					{
						int current2 = questState2.TotalList.Count - questState2.UnFinishList.Count;
						this.PushSubTabItem(ESheriffSubTabType.Branch, "SP_IconMap_Task_02_UI", "FunctionMap_Content_6", current2, questState2.TotalList.Count);
					}
					if (!this.IsInitialTabSelect)
					{
						this.NavigateToQuestMark(questState, questState2);
					}
				}
			}
			else
			{
				ValueTuple<int, int> anomalyProgress = ModelBase<SheriffModel>.Instance.GetAnomalyProgress();
				this.PushSubTabItem(ESheriffSubTabType.Criminal, "SP_IconMapMonster", "FunctionMap_Content_1", anomalyProgress.Item1, anomalyProgress.Item2);
				if (!this.IsInitialTabSelect)
				{
					this.NavigateToAnomalyMark();
				}
			}
			this.IsInitialTabSelect = false;
			GenericLayout<SheriffMapSubTabItem, ISheriffSubTabItemData> subTabLayout = this.SubTabLayout;
			if (subTabLayout != null)
			{
				subTabLayout.RefreshByData(this.SubTabItemDataList, null, false);
			}
			UiSequencePlayer sequencePlayer = this.SequencePlayer;
			if (sequencePlayer != null)
			{
				sequencePlayer.PlayOrReplaySequenceByName("Switch", false, null);
			}
			UUINiagara uiNiagara = base.GetUiNiagara(10);
			if (uiNiagara == null)
			{
				return;
			}
			uiNiagara.ActivateSystem(true);
		}

		// Token: 0x06034B89 RID: 215945 RVA: 0x00D39094 File Offset: 0x00D37294
		private void PushSubTabItem(ESheriffSubTabType tabType, string iconId, string textId, int current, int total)
		{
			string localTextNew = ConfigMultiTextLang.GetLocalTextNew(textId, null);
			this.SubTabItemDataList.Add(new SheriffSubTabItemData
			{
				TabType = tabType,
				TabIcon = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(iconId),
				TabTxt = StringUtils.Format(localTextNew, new string[]
				{
					current.ToString(),
					total.ToString()
				}),
				IsFinished = (current >= total)
			});
		}

		// Token: 0x06034B8A RID: 215946 RVA: 0x00D39108 File Offset: 0x00D37308
		private void NavigateToAnomalyMark()
		{
			int targetAnomalyMarkId = ModelBase<SheriffModel>.Instance.GetTargetAnomalyMarkId();
			if (targetAnomalyMarkId == 0)
			{
				return;
			}
			Singleton<EventSystem>.Instance.Emit<NavigateMark>(EEventName.WorldMapNavigate, new NavigateMark
			{
				MarkId = targetAnomalyMarkId,
				MarkType = EMarkType.SheriffAnomaly,
				Focal = new bool?(false)
			});
		}

		// Token: 0x06034B8B RID: 215947 RVA: 0x00D39154 File Offset: 0x00D37354
		private void NavigateToQuestMark(SheriffQuestState poiState, SheriffQuestState branchState)
		{
			int? num = this.FindTrackingQuestMarkId(poiState.UnFinishList);
			int? num2 = (num != null) ? num : this.FindTrackingQuestMarkId(branchState.UnFinishList);
			if (num2 != null)
			{
				Singleton<EventSystem>.Instance.Emit<NavigateMark>(EEventName.WorldMapNavigate, new NavigateMark
				{
					MarkId = num2.Value,
					MarkType = EMarkType.SheriffQuest,
					Focal = new bool?(false)
				});
				return;
			}
			List<int> list = null;
			if (poiState.UnFinishList.Count > 0)
			{
				list = poiState.UnFinishList;
			}
			else if (branchState.UnFinishList.Count > 0)
			{
				list = branchState.UnFinishList;
			}
			else if (poiState.TotalList.Count > 0)
			{
				list = poiState.TotalList;
			}
			else if (branchState.TotalList.Count > 0)
			{
				list = branchState.TotalList;
			}
			if (list != null)
			{
				int targetMapMarkIdByQuestIds = ModelBase<SheriffModel>.Instance.GetTargetMapMarkIdByQuestIds(list);
				Singleton<EventSystem>.Instance.Emit<NavigateMark>(EEventName.WorldMapNavigate, new NavigateMark
				{
					MarkId = targetMapMarkIdByQuestIds,
					MarkType = EMarkType.SheriffQuest,
					Focal = new bool?(false)
				});
			}
		}

		// Token: 0x06034B8C RID: 215948 RVA: 0x00D39264 File Offset: 0x00D37464
		private int? FindTrackingQuestMarkId(List<int> questIds)
		{
			foreach (int questId in questIds)
			{
				if (ModelBase<QuestNewModel>.Instance.IsTrackingQuest(questId))
				{
					return new int?(ConfigBase<SheriffConfig>.Instance.GetQuestConfigByQuestId(questId).Value.MarkId);
				}
			}
			return null;
		}

		// Token: 0x06034B8D RID: 215949 RVA: 0x00D392EC File Offset: 0x00D374EC
		private SheriffMapSubTabItem CreateSubTabItem()
		{
			return new SheriffMapSubTabItem
			{
				ClickCallBack = new Action<ISheriffSubTabItemData>(this.OnClickSubTab)
			};
		}

		// Token: 0x06034B8E RID: 215950 RVA: 0x00D39308 File Offset: 0x00D37508
		private void OnClickSubTab(ISheriffSubTabItemData data)
		{
			switch (data.TabType)
			{
			case ESheriffSubTabType.Criminal:
			{
				WorldMapUiEntity worldMapUiComponent = this.ExtraUiPanelComponent.WorldMapUiComponent;
				if (worldMapUiComponent == null)
				{
					return;
				}
				worldMapUiComponent.SecondaryUiComponent.OpenUi(ESecondaryPanel.SheriffCriminalPanel, this.ParentUiItem, new object[]
				{
					this.CurrentZoneId
				});
				return;
			}
			case ESheriffSubTabType.POI:
			{
				SheriffQuestState questState = ModelBase<SheriffModel>.Instance.GetQuestState(this.CurrentZoneId, ESheriffQuestType.POI);
				int num = questState.TotalList.Count - questState.UnFinishList.Count;
				int count = questState.TotalList.Count;
				if (num >= count)
				{
					ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("FunctionMap_Content_15", Array.Empty<object>());
					return;
				}
				int targetMapMarkIdByQuestIds = ModelBase<SheriffModel>.Instance.GetTargetMapMarkIdByQuestIds(questState.UnFinishList);
				Singleton<EventSystem>.Instance.Emit<NavigateMark>(EEventName.WorldMapNavigate, new NavigateMark
				{
					MarkId = targetMapMarkIdByQuestIds,
					MarkType = EMarkType.SheriffQuest,
					Focal = new bool?(true)
				});
				return;
			}
			case ESheriffSubTabType.Branch:
			{
				SheriffQuestState questState2 = ModelBase<SheriffModel>.Instance.GetQuestState(this.CurrentZoneId, ESheriffQuestType.Branch);
				int num2 = questState2.TotalList.Count - questState2.UnFinishList.Count;
				int count2 = questState2.TotalList.Count;
				if (num2 >= count2)
				{
					ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("FunctionMap_Content_16", Array.Empty<object>());
					return;
				}
				int targetMapMarkIdByQuestIds2 = ModelBase<SheriffModel>.Instance.GetTargetMapMarkIdByQuestIds(questState2.UnFinishList);
				Singleton<EventSystem>.Instance.Emit<NavigateMark>(EEventName.WorldMapNavigate, new NavigateMark
				{
					MarkId = targetMapMarkIdByQuestIds2,
					MarkType = EMarkType.SheriffQuest,
					Focal = new bool?(true)
				});
				return;
			}
			default:
				return;
			}
		}

		// Token: 0x06034B8F RID: 215951 RVA: 0x00D3948D File Offset: 0x00D3768D
		[NullableContext(2)]
		public override UUISliderComponent GetScaleSlider()
		{
			CommonMapItemsView commonMapItemsViewInstance = this.CommonMapItemsViewInstance;
			if (commonMapItemsViewInstance == null)
			{
				return null;
			}
			return commonMapItemsViewInstance.GetScaleSlider();
		}

		// Token: 0x06034B90 RID: 215952 RVA: 0x00D394A0 File Offset: 0x00D376A0
		public override float GetDefaultMapScale()
		{
			int mapId = ConfigBase<SheriffConfig>.Instance.GetZoneConfigById(this.CurrentZoneId).Value.MapId;
			SheriffMap? mapConfigById = ConfigBase<SheriffConfig>.Instance.GetMapConfigById(mapId);
			return (float)((this.CurrentMainTabType == ESheriffMainTabType.Event) ? ((mapConfigById != null) ? mapConfigById.GetValueOrDefault().BigMapDefaultScale : 0) : ((mapConfigById != null) ? mapConfigById.GetValueOrDefault().QuestMapDefaultScale : 0));
		}

		// Token: 0x06034B91 RID: 215953 RVA: 0x00D39520 File Offset: 0x00D37720
		public override float GetMaxMapScale()
		{
			int mapId = ConfigBase<SheriffConfig>.Instance.GetZoneConfigById(this.CurrentZoneId).Value.MapId;
			SheriffMap? mapConfigById = ConfigBase<SheriffConfig>.Instance.GetMapConfigById(mapId);
			return (float)((this.CurrentMainTabType == ESheriffMainTabType.Event) ? ((mapConfigById != null) ? mapConfigById.GetValueOrDefault().BigMapMaxScale : 0) : ((mapConfigById != null) ? mapConfigById.GetValueOrDefault().QuestMapMaxScale : 0));
		}

		// Token: 0x06034B92 RID: 215954 RVA: 0x00D395A0 File Offset: 0x00D377A0
		public override float GetMinMapScale()
		{
			int mapId = ConfigBase<SheriffConfig>.Instance.GetZoneConfigById(this.CurrentZoneId).Value.MapId;
			SheriffMap? mapConfigById = ConfigBase<SheriffConfig>.Instance.GetMapConfigById(mapId);
			return (float)((this.CurrentMainTabType == ESheriffMainTabType.Event) ? ((mapConfigById != null) ? mapConfigById.GetValueOrDefault().BigMapMinScale : 0) : ((mapConfigById != null) ? mapConfigById.GetValueOrDefault().QuestMapMinScale : 0));
		}

		// Token: 0x06034B93 RID: 215955 RVA: 0x00D39620 File Offset: 0x00D37820
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public override IEnumerable<string> GetTileRange()
		{
			int mapId = ConfigBase<SheriffConfig>.Instance.GetZoneConfigById(this.CurrentZoneId).Value.MapId;
			SheriffMap? mapConfigById = ConfigBase<SheriffConfig>.Instance.GetMapConfigById(mapId);
			if (mapConfigById == null)
			{
				return null;
			}
			return mapConfigById.Value.TileRangeIter();
		}

		// Token: 0x06034B94 RID: 215956 RVA: 0x00D39678 File Offset: 0x00D37878
		[NullableContext(2)]
		public override int[] GetUnlockFogs()
		{
			int mapId = ConfigBase<SheriffConfig>.Instance.GetZoneConfigById(this.CurrentZoneId).Value.MapId;
			SheriffMap? mapConfigById = ConfigBase<SheriffConfig>.Instance.GetMapConfigById(mapId);
			if (mapConfigById == null || mapConfigById.Value.UnlockFogsLength == 0)
			{
				return null;
			}
			return mapConfigById.Value.GetUnlockFogsArray();
		}

		// Token: 0x06034B95 RID: 215957 RVA: 0x00D396DF File Offset: 0x00D378DF
		public override EMarkType[] GetExtraMarkTypes()
		{
			return new EMarkType[]
			{
				(this.CurrentMainTabType == ESheriffMainTabType.Event) ? EMarkType.SheriffAnomaly : EMarkType.SheriffQuest
			};
		}

		// Token: 0x06034B96 RID: 215958 RVA: 0x00D396F8 File Offset: 0x00D378F8
		[NullableContext(2)]
		public override int[] GetExtraMarkIds()
		{
			int mapId = ConfigBase<SheriffConfig>.Instance.GetZoneConfigById(this.CurrentZoneId).Value.MapId;
			SheriffMap? mapConfigById = ConfigBase<SheriffConfig>.Instance.GetMapConfigById(mapId);
			if (mapConfigById == null || mapConfigById.Value.UnlockFogsLength == 0)
			{
				return null;
			}
			return mapConfigById.Value.GetExtraMarkIdsArray();
		}

		// Token: 0x06034B97 RID: 215959 RVA: 0x00D39760 File Offset: 0x00D37960
		[return: TupleElementNames(new string[]
		{
			"ResourceId",
			"SequenceType"
		})]
		[return: Nullable(new byte[]
		{
			0,
			1,
			1
		})]
		public override ValueTuple<string, string>? GetStartSequenceInfo()
		{
			ISheriffMapPanelParam openParam = this.OpenParam;
			if (openParam != null && openParam.IsError.GetValueOrDefault())
			{
				return null;
			}
			return new ValueTuple<string, string>?(new ValueTuple<string, string>("UiItem_SkyEyeMapLoading", "Start"));
		}

		// Token: 0x06034B98 RID: 215960 RVA: 0x00D397A7 File Offset: 0x00D379A7
		public override string GetBackgroundMusicAudioEvent()
		{
			return "play_ui_music_tongji_3_5_layer1";
		}

		// Token: 0x06034B99 RID: 215961 RVA: 0x00D397B0 File Offset: 0x00D379B0
		public override int? GetCustomClickRange()
		{
			if (this.CurrentMainTabType != ESheriffMainTabType.Event)
			{
				return null;
			}
			return new int?(65);
		}

		// Token: 0x06034B9A RID: 215962 RVA: 0x00D397D8 File Offset: 0x00D379D8
		public override ClickMarkItemRet OnClickMarkItem(MarkItem markItem)
		{
			if (markItem.MarkType == EMarkType.SheriffAnomaly)
			{
				Singleton<AudioSystem>.Instance.PostEvent("play_ui_skyeye_button_npc_click");
				SheriffAnomaly? anomalyConfigByMarkId = ConfigBase<SheriffConfig>.Instance.GetAnomalyConfigByMarkId(markItem.MarkId);
				SheriffAnomalyInfo anomalyInfo = ModelBase<SheriffModel>.Instance.GetAnomalyInfo(anomalyConfigByMarkId.Value.Id);
				WorldMapUiEntity worldMapUiComponent = this.ExtraUiPanelComponent.WorldMapUiComponent;
				if (worldMapUiComponent != null && worldMapUiComponent.SecondaryUiComponent.IsInternalSecondaryUiOpen())
				{
					WorldMapUiEntity worldMapUiComponent2 = this.ExtraUiPanelComponent.WorldMapUiComponent;
					if (worldMapUiComponent2 != null)
					{
						worldMapUiComponent2.SecondaryUiComponent.CloseUi(delegate
						{
							this.HandleAnomalyClick(anomalyInfo);
						}, true);
					}
				}
				else
				{
					this.HandleAnomalyClick(anomalyInfo);
				}
				this.ClickMarkItemRetData.IsExtraUiLogic = true;
				this.ClickMarkItemRetData.IsNeedSelected = false;
				return this.ClickMarkItemRetData;
			}
			this.ClickMarkItemRetData.IsExtraUiLogic = false;
			this.ClickMarkItemRetData.IsNeedSelected = true;
			return this.ClickMarkItemRetData;
		}

		// Token: 0x06034B9B RID: 215963 RVA: 0x00D398D0 File Offset: 0x00D37AD0
		public override bool OnClickEmpty(Vector2D clickedPosition)
		{
			WorldMapUiEntity worldMapUiComponent = this.ExtraUiPanelComponent.WorldMapUiComponent;
			return worldMapUiComponent == null || !worldMapUiComponent.SecondaryUiComponent.IsSecondaryUiOpening;
		}

		// Token: 0x06034B9C RID: 215964 RVA: 0x00D398F3 File Offset: 0x00D37AF3
		private void HandleAnomalyClick(SheriffAnomalyInfo anomalyInfo)
		{
			ControllerBase<SheriffController>.Instance.OpenSheriffReportPop(anomalyInfo.CriminalId, true);
		}

		// Token: 0x06034B9D RID: 215965 RVA: 0x00D39908 File Offset: 0x00D37B08
		private void OnGotoAnomaly(int anomalyId)
		{
			int markId = ModelBase<SheriffModel>.Instance.GetAnomalyInfo(anomalyId).MarkId;
			MarkItem markItem = this.ExtraUiPanelComponent.WorldMapUiComponent.Map.GetMarkItem(EMarkType.SheriffAnomaly, markId);
			if (markItem == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Sheriff;
				ELogAuthor author = ELogAuthor.CB;
				string message = "获取不到异常事件标记";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("MarkId", markId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			if (ModelBase<SheriffModel>.Instance.CheckInBehaviorTreeRange(anomalyId))
			{
				TrackMapMarkParams curTrackMark = ModelBase<MapModel>.Instance.GetCurTrackMark();
				if (curTrackMark != null)
				{
					ControllerBase<MapController>.Instance.RequestTrackMapMark(new TrackMapMarkParams
					{
						MarkType = curTrackMark.MarkType,
						MarkId = curTrackMark.MarkId,
						Track = false
					}, null);
				}
				if (!ModelBase<SheriffModel>.Instance.IsBehaviorTreeTracking(anomalyId))
				{
					TrackHelper.SetMarkItemTrack(markItem, delegate
					{
						WorldMapUiEntity worldMapUiComponent = this.ExtraUiPanelComponent.WorldMapUiComponent;
						if (worldMapUiComponent == null)
						{
							return;
						}
						worldMapUiComponent.UpdateMarkItems(null);
					});
				}
				Singleton<UiManager>.Instance.ResetToBattleView(delegate(bool success)
				{
					ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("FunctionMap_Content_23", Array.Empty<object>());
				});
				return;
			}
			MarkItem markItem3 = MarkUiUtils.FindNearbyValidGotoMark(this.ExtraUiPanelComponent.WorldMapUiComponent.Map, markItem);
			if (markItem3 != null)
			{
				TrackHelper.SetMarkItemTrack(markItem, delegate
				{
					WorldMapUiEntity worldMapUiComponent = this.ExtraUiPanelComponent.WorldMapUiComponent;
					if (worldMapUiComponent == null)
					{
						return;
					}
					worldMapUiComponent.UpdateMarkItems(null);
				});
				TemporaryTeleportMarkItem temporaryTeleportMarkItem = markItem3 as TemporaryTeleportMarkItem;
				if (temporaryTeleportMarkItem != null)
				{
					ControllerBase<MapController>.Instance.RequestTeleportToTargetByTemporaryTeleport(temporaryTeleportMarkItem.TeleportId, null);
					Singleton<EventSystem>.Instance.Once<TeleportContext>(EEventName.TeleportComplete, new Action<TeleportContext>(this.OnTeleportComplete));
				}
				ConfigMarkItem configMarkItem = markItem3 as ConfigMarkItem;
				if (configMarkItem != null)
				{
					ControllerBase<WorldMapController>.Instance.TryTeleport(configMarkItem.MarkConfigId, null);
					Singleton<EventSystem>.Instance.Once<TeleportContext>(EEventName.TeleportComplete, new Action<TeleportContext>(this.OnTeleportComplete));
					return;
				}
			}
			else
			{
				Action <>9__4;
				Singleton<UiManager>.Instance.ResetToBattleView(delegate(bool success)
				{
					ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("FunctionMap_Content_17", Array.Empty<object>());
					MarkItem markItem2 = markItem;
					Action finishCallback;
					if ((finishCallback = <>9__4) == null)
					{
						finishCallback = (<>9__4 = delegate()
						{
							WorldMapUiEntity worldMapUiComponent = this.ExtraUiPanelComponent.WorldMapUiComponent;
							if (worldMapUiComponent == null)
							{
								return;
							}
							worldMapUiComponent.UpdateMarkItems(null);
						});
					}
					TrackHelper.SetMarkItemTrack(markItem2, finishCallback);
				});
			}
		}

		// Token: 0x06034B9E RID: 215966 RVA: 0x00D39AEC File Offset: 0x00D37CEC
		[NullableContext(2)]
		private void OnTeleportComplete(TeleportContext teleportContext)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("FunctionMap_Content_23", Array.Empty<object>());
		}

		// Token: 0x06034B9F RID: 215967 RVA: 0x00D39B04 File Offset: 0x00D37D04
		protected override UniTask OnBeforeHideAsync()
		{
			SheriffMapPanel.<OnBeforeHideAsync>d__58 <OnBeforeHideAsync>d__;
			<OnBeforeHideAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeHideAsync>d__.<>4__this = this;
			<OnBeforeHideAsync>d__.<>1__state = -1;
			<OnBeforeHideAsync>d__.<>t__builder.Start<SheriffMapPanel.<OnBeforeHideAsync>d__58>(ref <OnBeforeHideAsync>d__);
			return <OnBeforeHideAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06034BA0 RID: 215968 RVA: 0x00D39B48 File Offset: 0x00D37D48
		protected override void OnBeforeDestroy()
		{
			Singleton<EventSystem>.Instance.Remove<int>(EEventName.OnGotoAnomaly, new Action<int>(this.OnGotoAnomaly));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnSheriffShopRedDotRefresh, new Action(this.RefreshShopRedDot));
			Singleton<EventSystem>.Instance.Remove<int, PayShopDefine.EPayShopTabType, int>(EEventName.RefreshGoods, new Action<int, PayShopDefine.EPayShopTabType, int>(this.OnRefreshGoodsList));
		}

		// Token: 0x0401E615 RID: 124437
		[Nullable(2)]
		private PopupCaptionItem CaptionItem;

		// Token: 0x0401E616 RID: 124438
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<SheriffMapMainTabItem, ISheriffMainTabItemData> MainTabLayout;

		// Token: 0x0401E617 RID: 124439
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<SheriffMapSubTabItem, ISheriffSubTabItemData> SubTabLayout;

		// Token: 0x0401E618 RID: 124440
		[Nullable(2)]
		private CommonMapItemsView CommonMapItemsViewInstance;

		// Token: 0x0401E619 RID: 124441
		private ESheriffMainTabType CurrentMainTabType;

		// Token: 0x0401E61A RID: 124442
		private const int CUSTOM_CLICK_RANGE = 65;

		// Token: 0x0401E61B RID: 124443
		private readonly int CurrentZoneId = 1;

		// Token: 0x0401E61C RID: 124444
		private readonly List<ISheriffSubTabItemData> SubTabItemDataList = new List<ISheriffSubTabItemData>();

		// Token: 0x0401E61D RID: 124445
		[Nullable(2)]
		private UiSequencePlayer SequencePlayer;

		// Token: 0x0401E61E RID: 124446
		private bool IsInitialTabSelect = true;

		// Token: 0x0200AFB1 RID: 44977
		[NullableContext(0)]
		private static class EComponent
		{
			// Token: 0x04036846 RID: 223302
			public const int CaptionItem = 0;

			// Token: 0x04036847 RID: 223303
			public const int PnlInfo = 1;

			// Token: 0x04036848 RID: 223304
			public const int SubTab = 2;

			// Token: 0x04036849 RID: 223305
			public const int SubTabItem = 3;

			// Token: 0x0403684A RID: 223306
			public const int BtnShop = 4;

			// Token: 0x0403684B RID: 223307
			public const int ShopText = 5;

			// Token: 0x0403684C RID: 223308
			public const int RedDotShop = 6;

			// Token: 0x0403684D RID: 223309
			public const int MainTab = 7;

			// Token: 0x0403684E RID: 223310
			public const int MainTabItem = 8;

			// Token: 0x0403684F RID: 223311
			public const int PnlContent = 9;

			// Token: 0x04036850 RID: 223312
			public const int NiaSwitch = 10;
		}
	}
}
