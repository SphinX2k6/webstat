using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using Aki.Protocol.Debug;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Area;
using CSharpScript.Game.Module.Battle;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Module.Map;
using CSharpScript.Game.Module.Map.Controller;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.Map.Mark;
using CSharpScript.Game.Module.Map.Mark.Debug;
using CSharpScript.Game.Module.Map.Marks.MarkItem;
using CSharpScript.Game.Module.Map.Marks.MarkItemView;
using CSharpScript.Game.Module.Map.Misc;
using CSharpScript.Game.Module.Map.View.BaseMap;
using CSharpScript.Game.Module.Map.View.BaseMap.Assistant.MapLifeEvent;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Module.WorldMap.RegionalTerminal.View;
using CSharpScript.Game.Module.WorldMap.SubItems;
using CSharpScript.Game.Module.WorldMap.SubViews;
using CSharpScript.Game.Module.WorldMap.SubViews.Common;
using CSharpScript.Game.Module.WorldMap.SubViews.CustomMarkPanel;
using CSharpScript.Game.Module.WorldMap.SubViews.TrackMenu;
using CSharpScript.Game.Module.WorldMap.SubViews.UnderseaExperimentField;
using CSharpScript.Game.Module.WorldMap.ViewComponent;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using Ui.WorldMap.View.Component;
using UnrealEngine;
using UnrealEngine.Extension;

namespace CSharpScript.Game.Module.WorldMap
{
	// Token: 0x02004B47 RID: 19271
	[NullableContext(1)]
	[Nullable(0)]
	public class WorldMapView : UiTickViewBase
	{
		// Token: 0x06032474 RID: 205940 RVA: 0x00C91B8C File Offset: 0x00C8FD8C
		public WorldMapView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06032475 RID: 205941 RVA: 0x00C91C52 File Offset: 0x00C8FE52
		private bool InEightMap()
		{
			return this.OpenParamMapId == 8;
		}

		// Token: 0x06032476 RID: 205942 RVA: 0x00C91C60 File Offset: 0x00C8FE60
		protected unsafe override void OnRegisterComponent()
		{
			int num = 26;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISliderComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUINiagara));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIVerticalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(17, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(18, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(19, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(20, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(21, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(22, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(23, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(24, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(25, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 3;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(5, new Action(this.OnCloseBtnClick));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(17, new Action(this.OnChangeMapBtnClick));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(6, new Action(this.OnMarkToggleBtnClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06032477 RID: 205943 RVA: 0x00C92078 File Offset: 0x00C90278
		protected override UniTask OnBeforeStartAsync()
		{
			WorldMapView.<OnBeforeStartAsync>d__39 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<WorldMapView.<OnBeforeStartAsync>d__39>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06032478 RID: 205944 RVA: 0x00C920BC File Offset: 0x00C902BC
		private void InitShowMode()
		{
			this.ShowMode = (EWorldMapShowMode)ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(ModelBase<CreatureModel>.Instance.GetInstanceId()).Value.MapShowMode;
			if (ModelBase<FlagChallengeBattleModel>.Instance.IsInFlagChallengeDungeon)
			{
				this.ShowMode = EWorldMapShowMode.Base;
			}
			this.PowerCurrencyItem.SetWorldMapSelfShow(this.ShowMode);
			this.OverPowerCurrencyItem.SetWorldMapSelfShow(this.ShowMode);
			this.WorldMapPeriodicActivityItem.SetWorldMapSelfShow(this.ShowMode);
			this.ExploreInfoItem.SetWorldMapSelfShow(this.ShowMode);
			this.RegionalTerminalBar.SetWorldMapSelfShow(this.ShowMode);
		}

		// Token: 0x06032479 RID: 205945 RVA: 0x00C9215C File Offset: 0x00C9035C
		private void SetupParams()
		{
			if (this.ShowParams != null)
			{
				int? markId = this.ShowParams.MarkId;
				if (markId != null && markId.GetValueOrDefault() != 0 && this.ShowParams.MapId == null)
				{
					int? markId2 = this.ShowParams.MarkId;
					EMarkType markType = this.ShowParams.MarkType;
					int markMapConfigId = ModelBase<MapModel>.Instance.GetMarkMapConfigId(markId2.Value, markType);
					this.ShowParams.MapId = new int?(markMapConfigId);
				}
				if (this.ShowParams.MapId == null)
				{
					this.ShowParams.MapId = new int?(ModelBase<MapModel>.Instance.CurrentWorldMapConfigId);
				}
				this.OpenParamMapId = this.ShowParams.MapId.GetValueOrDefault();
			}
			else
			{
				this.OpenParamMapId = ModelBase<MapModel>.Instance.CurrentWorldMapConfigId;
			}
			if (this.OpenParamMapId == 0 || !ConfigBase<WorldMapConfig>.Instance.IsMapInWorld(this.OpenParamMapId))
			{
				this.InstanceIdToMapId();
			}
			ModelBase<WorldMapModel>.Instance.WorldMapId = new int?(this.OpenParamMapId);
			ModelBase<WorldMapModel>.Instance.ResetMapScale();
		}

		// Token: 0x0603247A RID: 205946 RVA: 0x00C9227C File Offset: 0x00C9047C
		private unsafe void InstanceIdToMapId()
		{
			MapModel instance = ModelBase<MapModel>.Instance;
			AreaConfig instance2 = ConfigBase<AreaConfig>.Instance;
			int num = instance.GetDungeonWorldMapConfigId(ModelBase<CreatureModel>.Instance.GetInstanceId());
			ILastBigSceneMiniMapInfo lastBigSceneMiniMapInfo = ModelBase<WorldMapModel>.Instance.LastBigSceneMiniMapInfo;
			if (!ConfigBase<WorldMapConfig>.Instance.IsMapInWorld(num))
			{
				int? lastHighLevelArea = instance.LastHighLevelArea;
				int num2 = 0;
				if (!(lastHighLevelArea.GetValueOrDefault() == num2 & lastHighLevelArea != null))
				{
					int levelOneAreaId = instance2.GetLevelOneAreaId(instance.LastHighLevelArea.Value);
					Area? area;
					num = ((instance2.GetAreaInfo(levelOneAreaId) != null) ? area.GetValueOrDefault().MapConfigId : num);
				}
			}
			this.OpenParamMapId = num;
			if (!ConfigBase<WorldMapConfig>.Instance.IsMapInWorld(num))
			{
				this.OpenParamMapId = 8;
				ELogAuthor author = ELogAuthor.LYX;
				string message = "[地图系统]->获取上一次大世界区域配置失败";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("MapId:", this.OpenParamMapId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("lastBigSceneMiniMapInfo", lastBigSceneMiniMapInfo);
				MapLogger.Error(author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			}
		}

		// Token: 0x0603247B RID: 205947 RVA: 0x00C92390 File Offset: 0x00C90590
		[NullableContext(0)]
		private UniTask<bool> LoadAllUiObjAsync()
		{
			WorldMapView.<LoadAllUiObjAsync>d__43 <LoadAllUiObjAsync>d__;
			<LoadAllUiObjAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<LoadAllUiObjAsync>d__.<>4__this = this;
			<LoadAllUiObjAsync>d__.<>1__state = -1;
			<LoadAllUiObjAsync>d__.<>t__builder.Start<WorldMapView.<LoadAllUiObjAsync>d__43>(ref <LoadAllUiObjAsync>d__);
			return <LoadAllUiObjAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603247C RID: 205948 RVA: 0x00C923D4 File Offset: 0x00C905D4
		[NullableContext(0)]
		private UniTask<bool> RequestInfrV2Info()
		{
			WorldMapView.<RequestInfrV2Info>d__44 <RequestInfrV2Info>d__;
			<RequestInfrV2Info>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<RequestInfrV2Info>d__.<>1__state = -1;
			<RequestInfrV2Info>d__.<>t__builder.Start<WorldMapView.<RequestInfrV2Info>d__44>(ref <RequestInfrV2Info>d__);
			return <RequestInfrV2Info>d__.<>t__builder.Task;
		}

		// Token: 0x0603247D RID: 205949 RVA: 0x00C92410 File Offset: 0x00C90610
		private UniTask CreateMapUiObj()
		{
			WorldMapView.<CreateMapUiObj>d__45 <CreateMapUiObj>d__;
			<CreateMapUiObj>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateMapUiObj>d__.<>4__this = this;
			<CreateMapUiObj>d__.<>1__state = -1;
			<CreateMapUiObj>d__.<>t__builder.Start<WorldMapView.<CreateMapUiObj>d__45>(ref <CreateMapUiObj>d__);
			return <CreateMapUiObj>d__.<>t__builder.Task;
		}

		// Token: 0x0603247E RID: 205950 RVA: 0x00C92454 File Offset: 0x00C90654
		private UniTask CreateCurrencyItemUiObj()
		{
			WorldMapView.<CreateCurrencyItemUiObj>d__46 <CreateCurrencyItemUiObj>d__;
			<CreateCurrencyItemUiObj>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateCurrencyItemUiObj>d__.<>4__this = this;
			<CreateCurrencyItemUiObj>d__.<>1__state = -1;
			<CreateCurrencyItemUiObj>d__.<>t__builder.Start<WorldMapView.<CreateCurrencyItemUiObj>d__46>(ref <CreateCurrencyItemUiObj>d__);
			return <CreateCurrencyItemUiObj>d__.<>t__builder.Task;
		}

		// Token: 0x0603247F RID: 205951 RVA: 0x00C92498 File Offset: 0x00C90698
		private UniTask CreatePowerCurrencyItemUiObj()
		{
			WorldMapView.<CreatePowerCurrencyItemUiObj>d__47 <CreatePowerCurrencyItemUiObj>d__;
			<CreatePowerCurrencyItemUiObj>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreatePowerCurrencyItemUiObj>d__.<>4__this = this;
			<CreatePowerCurrencyItemUiObj>d__.<>1__state = -1;
			<CreatePowerCurrencyItemUiObj>d__.<>t__builder.Start<WorldMapView.<CreatePowerCurrencyItemUiObj>d__47>(ref <CreatePowerCurrencyItemUiObj>d__);
			return <CreatePowerCurrencyItemUiObj>d__.<>t__builder.Task;
		}

		// Token: 0x06032480 RID: 205952 RVA: 0x00C924DC File Offset: 0x00C906DC
		private UniTask CreateCursorItemUiObj()
		{
			WorldMapView.<CreateCursorItemUiObj>d__48 <CreateCursorItemUiObj>d__;
			<CreateCursorItemUiObj>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateCursorItemUiObj>d__.<>4__this = this;
			<CreateCursorItemUiObj>d__.<>1__state = -1;
			<CreateCursorItemUiObj>d__.<>t__builder.Start<WorldMapView.<CreateCursorItemUiObj>d__48>(ref <CreateCursorItemUiObj>d__);
			return <CreateCursorItemUiObj>d__.<>t__builder.Task;
		}

		// Token: 0x06032481 RID: 205953 RVA: 0x00C92520 File Offset: 0x00C90720
		private UniTask CreateExploreItemUiObj()
		{
			WorldMapView.<CreateExploreItemUiObj>d__49 <CreateExploreItemUiObj>d__;
			<CreateExploreItemUiObj>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateExploreItemUiObj>d__.<>4__this = this;
			<CreateExploreItemUiObj>d__.<>1__state = -1;
			<CreateExploreItemUiObj>d__.<>t__builder.Start<WorldMapView.<CreateExploreItemUiObj>d__49>(ref <CreateExploreItemUiObj>d__);
			return <CreateExploreItemUiObj>d__.<>t__builder.Task;
		}

		// Token: 0x06032482 RID: 205954 RVA: 0x00C92564 File Offset: 0x00C90764
		private UniTask CreateActivityListItemUiObj()
		{
			WorldMapView.<CreateActivityListItemUiObj>d__50 <CreateActivityListItemUiObj>d__;
			<CreateActivityListItemUiObj>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateActivityListItemUiObj>d__.<>4__this = this;
			<CreateActivityListItemUiObj>d__.<>1__state = -1;
			<CreateActivityListItemUiObj>d__.<>t__builder.Start<WorldMapView.<CreateActivityListItemUiObj>d__50>(ref <CreateActivityListItemUiObj>d__);
			return <CreateActivityListItemUiObj>d__.<>t__builder.Task;
		}

		// Token: 0x06032483 RID: 205955 RVA: 0x00C925A8 File Offset: 0x00C907A8
		private UniTask CreateShowAreaOpenEffect()
		{
			WorldMapView.<CreateShowAreaOpenEffect>d__51 <CreateShowAreaOpenEffect>d__;
			<CreateShowAreaOpenEffect>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateShowAreaOpenEffect>d__.<>4__this = this;
			<CreateShowAreaOpenEffect>d__.<>1__state = -1;
			<CreateShowAreaOpenEffect>d__.<>t__builder.Start<WorldMapView.<CreateShowAreaOpenEffect>d__51>(ref <CreateShowAreaOpenEffect>d__);
			return <CreateShowAreaOpenEffect>d__.<>t__builder.Task;
		}

		// Token: 0x06032484 RID: 205956 RVA: 0x00C925EC File Offset: 0x00C907EC
		private UniTask CreateUnderseaOverview()
		{
			WorldMapView.<CreateUnderseaOverview>d__52 <CreateUnderseaOverview>d__;
			<CreateUnderseaOverview>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateUnderseaOverview>d__.<>4__this = this;
			<CreateUnderseaOverview>d__.<>1__state = -1;
			<CreateUnderseaOverview>d__.<>t__builder.Start<WorldMapView.<CreateUnderseaOverview>d__52>(ref <CreateUnderseaOverview>d__);
			return <CreateUnderseaOverview>d__.<>t__builder.Task;
		}

		// Token: 0x06032485 RID: 205957 RVA: 0x00C92630 File Offset: 0x00C90830
		private UniTask CreateChangeGravityButton()
		{
			WorldMapView.<CreateChangeGravityButton>d__53 <CreateChangeGravityButton>d__;
			<CreateChangeGravityButton>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateChangeGravityButton>d__.<>4__this = this;
			<CreateChangeGravityButton>d__.<>1__state = -1;
			<CreateChangeGravityButton>d__.<>t__builder.Start<WorldMapView.<CreateChangeGravityButton>d__53>(ref <CreateChangeGravityButton>d__);
			return <CreateChangeGravityButton>d__.<>t__builder.Task;
		}

		// Token: 0x06032486 RID: 205958 RVA: 0x00C92674 File Offset: 0x00C90874
		private void CreateZoomButtonUiObj()
		{
			this.ZoomInButton = new LongPressButton(base.GetButton(2), new Action<float>(this.OnZoomOut), 100);
			this.ZoomOutButton = new LongPressButton(base.GetButton(3), new Action<float>(this.OnZoomIn), 100);
		}

		// Token: 0x06032487 RID: 205959 RVA: 0x00C926C1 File Offset: 0x00C908C1
		private void CreateMultiMapFloorLayout()
		{
			this.MultiMapFloorLayout = new GenericLayout<WorldMapSubMapItem, MultiMap>(base.GetVerticalLayout(15), () => new WorldMapSubMapItem(), null, false, true);
		}

		// Token: 0x06032488 RID: 205960 RVA: 0x00C926F8 File Offset: 0x00C908F8
		private UniTask CreateHonamiMarkSelectPanel()
		{
			WorldMapView.<CreateHonamiMarkSelectPanel>d__56 <CreateHonamiMarkSelectPanel>d__;
			<CreateHonamiMarkSelectPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateHonamiMarkSelectPanel>d__.<>4__this = this;
			<CreateHonamiMarkSelectPanel>d__.<>1__state = -1;
			<CreateHonamiMarkSelectPanel>d__.<>t__builder.Start<WorldMapView.<CreateHonamiMarkSelectPanel>d__56>(ref <CreateHonamiMarkSelectPanel>d__);
			return <CreateHonamiMarkSelectPanel>d__.<>t__builder.Task;
		}

		// Token: 0x06032489 RID: 205961 RVA: 0x00C9273C File Offset: 0x00C9093C
		private UniTask CreateRegionalTerminalBar()
		{
			WorldMapView.<CreateRegionalTerminalBar>d__57 <CreateRegionalTerminalBar>d__;
			<CreateRegionalTerminalBar>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateRegionalTerminalBar>d__.<>4__this = this;
			<CreateRegionalTerminalBar>d__.<>1__state = -1;
			<CreateRegionalTerminalBar>d__.<>t__builder.Start<WorldMapView.<CreateRegionalTerminalBar>d__57>(ref <CreateRegionalTerminalBar>d__);
			return <CreateRegionalTerminalBar>d__.<>t__builder.Task;
		}

		// Token: 0x0603248A RID: 205962 RVA: 0x00C92780 File Offset: 0x00C90980
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<MarkItem>(EEventName.MarkMenuClickItem, new Action<MarkItem>(this.OnMarkMenuClickItem));
			Singleton<EventSystem>.Instance.Add<EUiViewName>(EEventName.OpenViewBegined, new Action<EUiViewName>(this.OnOpenViewBegin));
			Singleton<EventSystem>.Instance.Add<EUiViewName, int>(EEventName.CloseView, new Action<EUiViewName, int>(this.OnCloseView));
			Singleton<EventSystem>.Instance.Add<Vector2D>(EEventName.WorldMapPointerDrag, new Action<Vector2D>(this.OnPointerDrag));
			Singleton<EventSystem>.Instance.Add<float, EMapScaleSetType>(EEventName.WorldMapFingerExpandClose, new Action<float, EMapScaleSetType>(this.IncreaseMapScale));
			Singleton<EventSystem>.Instance.Add<float, EMapScaleSetType>(EEventName.WorldMapWheelAxisInput, new Action<float, EMapScaleSetType>(this.IncreaseMapScale));
			Singleton<EventSystem>.Instance.Add<float, EMapScaleSetType>(EEventName.WorldMapHandleTriggerAxisInput, new Action<float, EMapScaleSetType>(this.IncreaseMapScale));
			Singleton<EventSystem>.Instance.Add<float, EMapScaleSetType>(EEventName.WorldMapZoomBtnInput, new Action<float, EMapScaleSetType>(this.IncreaseMapScale));
			Singleton<EventSystem>.Instance.Add<ULGUIPointerEventData>(EEventName.WorldMapPointerUp, new Action<ULGUIPointerEventData>(this.OnPointerUp));
			Singleton<EventSystem>.Instance.Add<bool>(EEventName.WorldMapSecondaryUiClosed, new Action<bool>(this.OnSecondaryUiClosed));
			Singleton<EventSystem>.Instance.Add(EEventName.WorldMapSecondaryUiOpened, new Action(this.OnSecondaryUiOpened));
			Singleton<EventSystem>.Instance.Add<EInputControllerType, EInputControllerType>(EEventName.InputControllerChange, new Action<EInputControllerType, EInputControllerType>(this.InputControllerChange));
			Singleton<EventSystem>.Instance.Add(EEventName.WorldMapFocusPlayer, new Action(this.OnWorldMapFocusPlayer));
			Singleton<EventSystem>.Instance.Add(EEventName.WorldMapShowTrackList, new Action(this.OnWorldMapShowTrackList));
			Singleton<EventSystem>.Instance.Add<ITrackMenuItemData>(EEventName.TrackMenuClickItem, new Action<ITrackMenuItemData>(this.OnTrackMenuClickItem));
			Singleton<EventSystem>.Instance.Add(EEventName.GetAreaProgress, new Action(this.UpdateAreaProgress));
			Singleton<EventSystem>.Instance.Add<EMarkType, int>(EEventName.OnWorldMapTrackMarkItem, new Action<EMarkType, int>(this.OnWorldMapTrackMarkItem));
			Singleton<EventSystem>.Instance.Add<DynamicMarkCreateInfo>(EEventName.CreateMapMark, new Action<DynamicMarkCreateInfo>(this.OnCreateMarkItem));
			Singleton<EventSystem>.Instance.Add<MarkItem>(EEventName.AddMapMark, new Action<MarkItem>(this.OnAddMarkItem));
			Singleton<EventSystem>.Instance.Add<EMarkType, int>(EEventName.RemoveMapMark, new Action<EMarkType, int>(this.OnRemoveMarkItem));
			Singleton<EventSystem>.Instance.Add(EEventName.BlackScreenFadeOnPlotToWorldMap, new Action(this.HandleUnLockEffect));
			Singleton<EventSystem>.Instance.Add<int, EMarkType, bool, bool, bool?>(EEventName.WorldMapFocalMarkItem, new Action<int, EMarkType, bool, bool, bool?>(this.OnNavigateFocalMarkItem));
			Singleton<EventSystem>.Instance.Add<WorldMapChangeMapParams>(EEventName.ChangeWorldMap, new Action<WorldMapChangeMapParams>(this.OnChangeWorldMap));
			Singleton<EventSystem>.Instance.Add<bool>(EEventName.ToggleShowCustomMark, new Action<bool>(this.EventToggleShowCustomMark));
			Singleton<EventSystem>.Instance.Add<bool>(EEventName.ToggleShowCompletedPlayMark, new Action<bool>(this.EventToggleShowCompletedPlayMark));
			Singleton<EventSystem>.Instance.Add<NavigateMarkShowRange>(EEventName.NavigateMarkAndShowRange, new Action<NavigateMarkShowRange>(this.EventNavigateMarkAndShowRange));
			Singleton<EventSystem>.Instance.Add<int, EExploreType?>(EEventName.OpenExploreAreaDetailViewFromMap, new Action<int, EExploreType?>(this.EventOpenExploreAreaDetailViewFromMap));
			Singleton<EventSystem>.Instance.Add<EWorldMapExtraUiPanelName, object>(EEventName.OpenExtraUiFromMap, new Action<EWorldMapExtraUiPanelName, object>(this.EventOpenExtraUiFromMap));
			Singleton<EventSystem>.Instance.Add(EEventName.CloseAllExtraUiFromMap, new Action(this.EventCloseAllExtraUiFromMap));
			Singleton<EventSystem>.Instance.Add<int>(EEventName.MapOpenFogChange, new Action<int>(this.OnMapOpenFogChange));
			Singleton<EventSystem>.Instance.Add(EEventName.WorldMapActivityListDataUpdate, new Action(this.OnWorldMapActivityListDataUpdate));
			Singleton<EventSystem>.Instance.Add<bool>(EEventName.SetWorldMapCursorButtonVisible, new Action<bool>(this.SetWorldMapCursorButtonVisible));
			if (!Singleton<Info>.Instance.IsBuildShipping)
			{
				ControllerBase<InputDistributeController>.Instance.BindKey("C", new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputKeyEvent));
				Singleton<Net>.Instance.Register<DebugDrawPosNotify>(ENotifyMessageId.DebugDrawPosNotify, new Action<DebugDrawPosNotify, Net.CallbackStatus>(this.DebugDrawPosNotify));
			}
		}

		// Token: 0x0603248B RID: 205963 RVA: 0x00C92B4C File Offset: 0x00C90D4C
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove<MarkItem>(EEventName.MarkMenuClickItem, new Action<MarkItem>(this.OnMarkMenuClickItem));
			Singleton<EventSystem>.Instance.Remove<EUiViewName>(EEventName.OpenViewBegined, new Action<EUiViewName>(this.OnOpenViewBegin));
			Singleton<EventSystem>.Instance.Remove<EUiViewName, int>(EEventName.CloseView, new Action<EUiViewName, int>(this.OnCloseView));
			Singleton<EventSystem>.Instance.Remove<Vector2D>(EEventName.WorldMapPointerDrag, new Action<Vector2D>(this.OnPointerDrag));
			Singleton<EventSystem>.Instance.Remove<float, EMapScaleSetType>(EEventName.WorldMapFingerExpandClose, new Action<float, EMapScaleSetType>(this.IncreaseMapScale));
			Singleton<EventSystem>.Instance.Remove<float, EMapScaleSetType>(EEventName.WorldMapWheelAxisInput, new Action<float, EMapScaleSetType>(this.IncreaseMapScale));
			Singleton<EventSystem>.Instance.Remove<float, EMapScaleSetType>(EEventName.WorldMapHandleTriggerAxisInput, new Action<float, EMapScaleSetType>(this.IncreaseMapScale));
			Singleton<EventSystem>.Instance.Remove<float, EMapScaleSetType>(EEventName.WorldMapZoomBtnInput, new Action<float, EMapScaleSetType>(this.IncreaseMapScale));
			Singleton<EventSystem>.Instance.Remove<ULGUIPointerEventData>(EEventName.WorldMapPointerUp, new Action<ULGUIPointerEventData>(this.OnPointerUp));
			Singleton<EventSystem>.Instance.Remove<bool>(EEventName.WorldMapSecondaryUiClosed, new Action<bool>(this.OnSecondaryUiClosed));
			Singleton<EventSystem>.Instance.Remove(EEventName.WorldMapSecondaryUiOpened, new Action(this.OnSecondaryUiOpened));
			Singleton<EventSystem>.Instance.Remove<EInputControllerType, EInputControllerType>(EEventName.InputControllerChange, new Action<EInputControllerType, EInputControllerType>(this.InputControllerChange));
			Singleton<EventSystem>.Instance.Remove(EEventName.WorldMapFocusPlayer, new Action(this.OnWorldMapFocusPlayer));
			Singleton<EventSystem>.Instance.Remove(EEventName.WorldMapShowTrackList, new Action(this.OnWorldMapShowTrackList));
			Singleton<EventSystem>.Instance.Remove<ITrackMenuItemData>(EEventName.TrackMenuClickItem, new Action<ITrackMenuItemData>(this.OnTrackMenuClickItem));
			Singleton<EventSystem>.Instance.Remove(EEventName.GetAreaProgress, new Action(this.UpdateAreaProgress));
			Singleton<EventSystem>.Instance.Remove<EMarkType, int>(EEventName.OnWorldMapTrackMarkItem, new Action<EMarkType, int>(this.OnWorldMapTrackMarkItem));
			Singleton<EventSystem>.Instance.Remove<DynamicMarkCreateInfo>(EEventName.CreateMapMark, new Action<DynamicMarkCreateInfo>(this.OnCreateMarkItem));
			Singleton<EventSystem>.Instance.Remove<MarkItem>(EEventName.AddMapMark, new Action<MarkItem>(this.OnAddMarkItem));
			Singleton<EventSystem>.Instance.Remove<EMarkType, int>(EEventName.RemoveMapMark, new Action<EMarkType, int>(this.OnRemoveMarkItem));
			Singleton<EventSystem>.Instance.Remove(EEventName.BlackScreenFadeOnPlotToWorldMap, new Action(this.HandleUnLockEffect));
			Singleton<EventSystem>.Instance.Remove<int, EMarkType, bool, bool, bool?>(EEventName.WorldMapFocalMarkItem, new Action<int, EMarkType, bool, bool, bool?>(this.OnNavigateFocalMarkItem));
			Singleton<EventSystem>.Instance.Remove<WorldMapChangeMapParams>(EEventName.ChangeWorldMap, new Action<WorldMapChangeMapParams>(this.OnChangeWorldMap));
			Singleton<EventSystem>.Instance.Remove<bool>(EEventName.ToggleShowCustomMark, new Action<bool>(this.EventToggleShowCustomMark));
			Singleton<EventSystem>.Instance.Remove<bool>(EEventName.ToggleShowCompletedPlayMark, new Action<bool>(this.EventToggleShowCompletedPlayMark));
			Singleton<EventSystem>.Instance.Remove<NavigateMarkShowRange>(EEventName.NavigateMarkAndShowRange, new Action<NavigateMarkShowRange>(this.EventNavigateMarkAndShowRange));
			Singleton<EventSystem>.Instance.Remove<int, EExploreType?>(EEventName.OpenExploreAreaDetailViewFromMap, new Action<int, EExploreType?>(this.EventOpenExploreAreaDetailViewFromMap));
			Singleton<EventSystem>.Instance.Remove<EWorldMapExtraUiPanelName, object>(EEventName.OpenExtraUiFromMap, new Action<EWorldMapExtraUiPanelName, object>(this.EventOpenExtraUiFromMap));
			Singleton<EventSystem>.Instance.Remove(EEventName.CloseAllExtraUiFromMap, new Action(this.EventCloseAllExtraUiFromMap));
			Singleton<EventSystem>.Instance.Remove<int>(EEventName.MapOpenFogChange, new Action<int>(this.OnMapOpenFogChange));
			Singleton<EventSystem>.Instance.Remove(EEventName.WorldMapActivityListDataUpdate, new Action(this.OnWorldMapActivityListDataUpdate));
			Singleton<EventSystem>.Instance.Remove<bool>(EEventName.SetWorldMapCursorButtonVisible, new Action<bool>(this.SetWorldMapCursorButtonVisible));
			if (!Singleton<Info>.Instance.IsBuildShipping)
			{
				ControllerBase<InputDistributeController>.Instance.UnBindKey("C", new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputKeyEvent));
				Singleton<Net>.Instance.UnRegister(ENotifyMessageId.DebugDrawPosNotify);
			}
		}

		// Token: 0x0603248C RID: 205964 RVA: 0x00C92F0C File Offset: 0x00C9110C
		protected override void OnStart()
		{
			this.RegisterLogicComponents();
			this.CheckAndCleanInvalidCustomMarks();
			this.HudSequencer = new LevelSequencePlayer(base.GetItem(14));
			this.HudSequencer.BindSequenceCloseEvent(new TSequenceEndEvent(this.OnHudSequenceEnd), false);
			base.GetText(18).ShowTextNew("ChangeMapBtn_Text");
			this.ExploreInfoItem.SetInfo(this.WorldMapUiEntity, new Action<Action, bool>(this.CloseSecondaryUi));
			this.ExploreInfoItem.UpdateBtnRedOrNew(false, false);
			base.GetText(21).SetUIActive(ModelBase<WorldMapModel>.Instance.EnableDebug);
			this.RefreshAllItemShow();
		}

		// Token: 0x0603248D RID: 205965 RVA: 0x00C92FAC File Offset: 0x00C911AC
		private void RefreshAllItemShow()
		{
			PowerCurrencyItem powerCurrencyItem = this.PowerCurrencyItem;
			if (powerCurrencyItem != null)
			{
				powerCurrencyItem.RefreshWorldMapSelfShow(this.ShowMode);
			}
			PowerCurrencyItem overPowerCurrencyItem = this.OverPowerCurrencyItem;
			if (overPowerCurrencyItem != null)
			{
				overPowerCurrencyItem.RefreshWorldMapSelfShow(this.ShowMode);
			}
			WorldMapPeriodicActivityItem worldMapPeriodicActivityItem = this.WorldMapPeriodicActivityItem;
			if (worldMapPeriodicActivityItem != null)
			{
				worldMapPeriodicActivityItem.RefreshWorldMapSelfShow(this.ShowMode);
			}
			ExploreInfoItem exploreInfoItem = this.ExploreInfoItem;
			if (exploreInfoItem != null)
			{
				exploreInfoItem.RefreshWorldMapSelfShow(this.ShowMode);
			}
			RegionalTerminalBarItem regionalTerminalBar = this.RegionalTerminalBar;
			if (regionalTerminalBar != null)
			{
				regionalTerminalBar.RefreshWorldMapSelfShow(this.ShowMode);
			}
			base.GetButton(17).RootUIComp.Get().SetUIActive(this.ShowMode == EWorldMapShowMode.Default);
		}

		// Token: 0x0603248E RID: 205966 RVA: 0x00C93050 File Offset: 0x00C91250
		protected override void OnBeforeShow()
		{
			this.InitSize();
			this.WorldMapUiEntity.Init();
			this.WorldMapUiEntity.MultiFloorComponent.MultiMapFloorContainer = base.GetItem(16);
			this.ExploreInfoItem.SetMapNotesState(true);
			this.UpdateAreaProgress();
			this.UpdateGravityBtn();
			this.UpdateCustomizedThumbnail();
			if (this.OpenFogId > 0)
			{
				this.Map.HandleFogAreaOpen(this.OpenFogId);
			}
			this.LifeEventDispatcher.OnWorldMapBeforeShow();
			this.WorldMapUiEntity.UpdateMarkItems(null);
			IWorldMapViewOpenParams showParams = this.ShowParams;
			if (showParams != null)
			{
				if (showParams.SkipToExtraUiName != null)
				{
					this.OpenExtraUi(showParams.SkipToExtraUiName.Value, showParams.SkipToExtraUiParam);
				}
				int? markId = showParams.MarkId;
				if (markId != null && markId.GetValueOrDefault() != 0)
				{
					MarkItem markItem = this.Map.GetMarkItem(showParams.MarkType, showParams.MarkId.Value);
					if (markItem != null)
					{
						MapHelper.CheckAndShowCrossMapTips(showParams.MarkId.Value, showParams.MarkType, markItem.TrackAreaId, markItem.WorldPosition);
						this.WorldMapUiEntity.QuickNavigateComponent.NavigateTo(showParams.MarkId.Value, showParams.MarkType, !showParams.IsNotFocal.GetValueOrDefault(), !showParams.IsNotFocusTween.GetValueOrDefault(), false);
					}
				}
				if (showParams.FocusExplorePlayPoint != null)
				{
					int areaId = showParams.FocusExplorePlayPoint[0];
					int exploreType = showParams.FocusExplorePlayPoint[1];
					ModelBase<ExploreProgressModel>.Instance.SetTrackExploreAreaItemData(areaId, exploreType);
					ModelBase<ExploreProgressModel>.Instance.CheckTrackExploreAreaItemData();
				}
				IWorldMapViewOpenParams showParams2 = this.ShowParams;
				if (((showParams2 != null) ? showParams2.SkipToExploreAreaDetailView : null) != null)
				{
					int areaId2 = this.ShowParams.SkipToExploreAreaDetailView[0];
					EExploreType value = (EExploreType)this.ShowParams.SkipToExploreAreaDetailView[1];
					this.OpenMapExploreAreaDetailView(areaId2, new EExploreType?(value));
				}
				IWorldMapViewOpenParams showParams3 = this.ShowParams;
				if (showParams3 != null && showParams3.NeedRefreshMultiFloor.GetValueOrDefault())
				{
					this.WorldMapUiEntity.MultiFloorComponent.InitMultiMap();
				}
			}
			else
			{
				this.WorldMapUiEntity.MultiFloorComponent.InitMultiMap();
			}
			this.UpdateExtraSecondaryUiOpen();
			this.IsWaitNoteAndRecommend = this.WorldMapUiEntity.SecondaryUiComponent.IsSecondaryUiOpening;
			if (!this.IsWaitNoteAndRecommend)
			{
				this.ExploreInfoItem.UpdateNoteOrPlayProgress();
			}
			if (this.RegionalTerminalBar.IsAvailableShow())
			{
				this.RegionalTerminalBar.BeforeShow();
			}
		}

		// Token: 0x0603248F RID: 205967 RVA: 0x00C932C4 File Offset: 0x00C914C4
		private void InitSize()
		{
			this.WorldMapUiEntity.PlayerComponent.PlayerRotation = 0f;
			float num = base.GetItem(8).GetWidth() / this.RootItem.GetWidth();
			float num2 = base.GetItem(8).GetHeight() / this.RootItem.GetHeight();
			Vector2D viewportSize = LGuiExtension.GetViewportSize();
			this.WorldMapUiEntity.MarkEdgeSize = new Vector2D(viewportSize.X / 2.0 * (double)num - 70.0, viewportSize.Y / 2.0 * (double)num2 - 70.0);
			this.WorldMapUiEntity.OutOfViewPortSize = Vector2D.Create((viewportSize.X / 2.0 + 400.0) * (double)num, (viewportSize.Y / 2.0 + 400.0) * (double)num2);
		}

		// Token: 0x06032490 RID: 205968 RVA: 0x00C933B4 File Offset: 0x00C915B4
		protected override UniTask OnPlayingStartSequenceAsync()
		{
			WorldMapView.<OnPlayingStartSequenceAsync>d__64 <OnPlayingStartSequenceAsync>d__;
			<OnPlayingStartSequenceAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnPlayingStartSequenceAsync>d__.<>4__this = this;
			<OnPlayingStartSequenceAsync>d__.<>1__state = -1;
			<OnPlayingStartSequenceAsync>d__.<>t__builder.Start<WorldMapView.<OnPlayingStartSequenceAsync>d__64>(ref <OnPlayingStartSequenceAsync>d__);
			return <OnPlayingStartSequenceAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06032491 RID: 205969 RVA: 0x00C933F8 File Offset: 0x00C915F8
		protected override void OnAfterShow()
		{
			Singleton<EventSystem>.Instance.Emit(EEventName.WorldMapViewOpened);
			this.ShowParams = null;
			this.LifeEventDispatcher.OnWorldMapAfterShow();
			this.WorldMapUiEntity.MultiFloorComponent.UpdateMultiMap();
			ModelBase<ExploreProgressModel>.Instance.CheckTrackExploreAreaItemData();
			if (this.ShowFogEffectInstant)
			{
				this.HandleUnLockEffect();
			}
		}

		// Token: 0x06032492 RID: 205970 RVA: 0x00C93450 File Offset: 0x00C91650
		protected override void OnAfterPlayStartSequence()
		{
			if (this.IsWaitNoteAndRecommend)
			{
				return;
			}
			this.ResumeMapAndRecommendSequence(null);
		}

		// Token: 0x06032493 RID: 205971 RVA: 0x00C93478 File Offset: 0x00C91678
		private UniTask ResumeMapAndRecommendSequence(float? waitTime = null)
		{
			WorldMapView.<ResumeMapAndRecommendSequence>d__67 <ResumeMapAndRecommendSequence>d__;
			<ResumeMapAndRecommendSequence>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ResumeMapAndRecommendSequence>d__.<>4__this = this;
			<ResumeMapAndRecommendSequence>d__.waitTime = waitTime;
			<ResumeMapAndRecommendSequence>d__.<>1__state = -1;
			<ResumeMapAndRecommendSequence>d__.<>t__builder.Start<WorldMapView.<ResumeMapAndRecommendSequence>d__67>(ref <ResumeMapAndRecommendSequence>d__);
			return <ResumeMapAndRecommendSequence>d__.<>t__builder.Task;
		}

		// Token: 0x06032494 RID: 205972 RVA: 0x00C934C4 File Offset: 0x00C916C4
		private void HandleUnLockEffect()
		{
			if (this.OpenFogId <= 0)
			{
				return;
			}
			this.OpenFogId = 0;
			this.ShowFogEffectInstant = false;
			UUIItem selfPlayerNode = this.Map.SelfPlayerNode;
			FVector? fvector = (selfPlayerNode != null) ? new FVector?(selfPlayerNode.GetLGUISpaceAbsolutePosition()) : null;
			if (fvector != null)
			{
				UUIItem unLockItem = this.UnLockItem;
				if (unLockItem != null)
				{
					FVector value = fvector.Value;
					unLockItem.SetLGUISpaceAbsolutePosition(value);
				}
			}
			UUIItem unLockItem2 = this.UnLockItem;
			if (unLockItem2 != null)
			{
				unLockItem2.SetUIActive(!this.IsNotNeedUnLockEffect);
			}
			LevelSequencePlayer unLockSequence = this.UnLockSequence;
			if (unLockSequence != null)
			{
				unLockSequence.PlayLevelSequenceByName("Start", true, null, false);
			}
			this.Map.HandleMapTileDelegate();
		}

		// Token: 0x06032495 RID: 205973 RVA: 0x00C93578 File Offset: 0x00C91778
		protected override void OnBeforeHide()
		{
			if (this.RegionalTerminalBar.IsAvailableShow())
			{
				this.RegionalTerminalBar.BeforeHide();
			}
			this.Map.UnBindMapTileDelegate();
			this.ShowParams = null;
		}

		// Token: 0x06032496 RID: 205974 RVA: 0x00C935A4 File Offset: 0x00C917A4
		protected override void OnTick(float delta)
		{
			if (this.WorldMapUiEntity != null)
			{
				WorldMapUiEntity worldMapUiEntity = this.WorldMapUiEntity;
				if (((worldMapUiEntity != null) ? worldMapUiEntity.Map : null) != null)
				{
					this.WorldMapUiEntity.Tick(delta);
					this.DrawDebug();
					if (this.ClickedItems == null)
					{
						this.ClickedItems = new List<MarkItem>();
					}
					this.WorldMapUiEntity.InteractComponent.CheckTouch();
					this.WorldMapUiEntity.MoveComponent.TickMoveDirty();
					this.JoystickCheck(false);
					return;
				}
			}
		}

		// Token: 0x06032497 RID: 205975 RVA: 0x00C9361C File Offset: 0x00C9181C
		private void DrawDebug()
		{
			if (!Singleton<Info>.Instance.IsBuildShipping)
			{
				base.GetText(21).SetUIActive(ModelBase<WorldMapModel>.Instance.EnableDebug);
			}
			if (ModelBase<WorldMapModel>.Instance.EnableDebug)
			{
				FVector2D anchorOffset = this.WorldMapUiEntity.Map.GetRootItem().GetAnchorOffset();
				Vector2D vector2D = Vector2D.Create(0.0, 0.0);
				Singleton<LguiUtil>.Instance.ConvertPointerPositionToLguiCenterPosition(UKuroStaticLibrary.GetViewPortMousePosition(), vector2D);
				float mapScale = ModelBase<WorldMapModel>.Instance.MapScale;
				global::Vector vector = global::Vector.Create((vector2D.X - (double)anchorOffset.X) / (double)mapScale * 100.0, -((vector2D.Y - (double)anchorOffset.Y) / (double)mapScale) * 100.0, 0.0);
				ModelBase<WorldMapModel>.Instance.LastWorldMapPointerWorldPosition = vector;
				MarkItem clickedItem = this.WorldMapUiEntity.ClickedItem;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(133, 12);
				defaultInterpolatedStringHandler.AppendLiteral("地图调试信息(编辑器下默认打开)\r\n输入GM EnableMapDebugMode#0 可关闭\r\n地图Id:");
				defaultInterpolatedStringHandler.AppendFormatted<int>(ModelBase<WorldMapModel>.Instance.CurrentWorldMapConfigId);
				defaultInterpolatedStringHandler.AppendLiteral(",重力:");
				defaultInterpolatedStringHandler.AppendFormatted<EMapGravityDirection>(ModelBase<WorldMapModel>.Instance.WorldMapGravity);
				defaultInterpolatedStringHandler.AppendLiteral(",副本Id:");
				defaultInterpolatedStringHandler.AppendFormatted<int>(ModelBase<CreatureModel>.Instance.GetInstanceId());
				defaultInterpolatedStringHandler.AppendLiteral(",一级区域Id:");
				defaultInterpolatedStringHandler.AppendFormatted<int>(MapUtil.GetWorldMapLevelOneAreaId());
				defaultInterpolatedStringHandler.AppendLiteral("\r\n指针Ui坐标(米): X:");
				defaultInterpolatedStringHandler.AppendFormatted(vector2D.X.ToString("F2"));
				defaultInterpolatedStringHandler.AppendLiteral(",Y:");
				defaultInterpolatedStringHandler.AppendFormatted(vector2D.Y.ToString("F2"));
				defaultInterpolatedStringHandler.AppendLiteral("\r\n指针世界坐标(厘米): X:");
				defaultInterpolatedStringHandler.AppendFormatted<double>(Math.Floor(vector.X));
				defaultInterpolatedStringHandler.AppendLiteral(",Y:");
				defaultInterpolatedStringHandler.AppendFormatted<double>(Math.Floor(vector.Y));
				defaultInterpolatedStringHandler.AppendLiteral(",Z:");
				defaultInterpolatedStringHandler.AppendFormatted<double>(Math.Floor(vector.Z));
				defaultInterpolatedStringHandler.AppendLiteral("\r\n地图缩放:");
				defaultInterpolatedStringHandler.AppendFormatted<float>(mapScale);
				defaultInterpolatedStringHandler.AppendLiteral(",最小缩放:");
				defaultInterpolatedStringHandler.AppendFormatted<float>(ModelBase<WorldMapModel>.Instance.MapScaleMin);
				defaultInterpolatedStringHandler.AppendLiteral(",最大缩放:");
				defaultInterpolatedStringHandler.AppendFormatted<float>(ModelBase<WorldMapModel>.Instance.MapScaleMax);
				defaultInterpolatedStringHandler.AppendLiteral("\r\n");
				string text = defaultInterpolatedStringHandler.ToStringAndClear();
				if (clickedItem != null)
				{
					string str = MapDebugger.DumpMarkItemForUi(this.Map, clickedItem);
					text = text + "\n" + str;
				}
				base.GetText(21).SetText(text, true);
			}
		}

		// Token: 0x06032498 RID: 205976 RVA: 0x00C938B8 File Offset: 0x00C91AB8
		private void CalculateJoystickClickItems()
		{
			if (Singleton<Info>.Instance.IsInGamepad())
			{
				FVectorDouble location = this.CursorButton.GetRootItem().D_K2_GetComponentLocation();
				FTransformDouble ftransformDouble = this.Map.MapRootItem.D_K2_GetComponentToWorld();
				FVectorDouble fvectorDouble = UKismetMathLibrary.D_InverseTransformLocation(ftransformDouble, location);
				this.ClickedPosition.Set(fvectorDouble.X, fvectorDouble.Y);
				this.MinRangeAndItem.Item1 = 2147483647.0;
				this.ClickedItems = new List<MarkItem>();
				Dictionary<EMarkType, Dictionary<int, MarkItem>> allMarkItems = this.Map.GetAllMarkItems();
				bool singleTest = allMarkItems.Count <= 1;
				foreach (Dictionary<int, MarkItem> dictionary in allMarkItems.Values)
				{
					foreach (MarkItem markItem in dictionary.Values)
					{
						if (markItem.View != null)
						{
							ValueTuple<bool, double> valueTuple = this.InClickRangeByUiPosition(this.ClickedPosition, Vector2D.Create(markItem.UiPosition.X, markItem.UiPosition.Y), singleTest, new bool?(true), this.WorldMapUiEntity.WorldMapExtraUiPanelComponent.GetCustomClickRange());
							bool item = valueTuple.Item1;
							double item2 = valueTuple.Item2;
							bool interactiveFlag = markItem.GetInteractiveFlag();
							if (item && interactiveFlag)
							{
								if (this.MinRangeAndItem.Item1 > item2)
								{
									this.MinRangeAndItem.Item1 = item2;
									this.MinRangeAndItem.Item2 = markItem;
								}
								this.ClickedItems.Add(markItem);
							}
						}
					}
				}
				this.CursorButton.SetSelected(false);
			}
		}

		// Token: 0x06032499 RID: 205977 RVA: 0x00C93A80 File Offset: 0x00C91C80
		private void HandleJoystickMoving(bool forceExecute = false)
		{
			if ((Singleton<Info>.Instance.IsInGamepad() && this.WorldMapUiEntity.InteractComponent.IsJoystickMoving && !this.WorldMapUiEntity.MoveComponent.IsDragMoveDisabled) || forceExecute)
			{
				this.WorldMapUiEntity.MoveComponent.KillTweening();
				this.CalculateJoystickClickItems();
			}
		}

		// Token: 0x0603249A RID: 205978 RVA: 0x00C93ADC File Offset: 0x00C91CDC
		private void HandleJoystickNoMoving()
		{
			if (Singleton<Info>.Instance.IsInGamepad() && !this.WorldMapUiEntity.InteractComponent.IsJoystickMoving && !this.WorldMapUiEntity.InteractComponent.IsJoystickZoom)
			{
				if (this.WorldMapUiEntity.InteractComponent.IsJoystickFocus)
				{
					if (this.WorldMapUiEntity.MoveComponent.IsTweeningMove)
					{
						return;
					}
					this.WorldMapUiEntity.InteractComponent.SetJoystickFocus(false);
					this.CalculateJoystickClickItems();
				}
				if (this.ClickedItems.Count > 0 && this.WorldMapUiEntity.ClickedItem == null)
				{
					this.CursorButton.SetSelected(true);
					this.WorldMapUiEntity.MoveComponent.SetMapPosition(this.MinRangeAndItem.Item2, true, EClampType.NotClamp, new LTweenEase?(this.UiParams.TweenTypeEase), new float?(this.UiParams.GamePadTweenTime), true, false);
				}
			}
		}

		// Token: 0x0603249B RID: 205979 RVA: 0x00C93BC4 File Offset: 0x00C91DC4
		private void JoystickCheck(bool forceExecute = false)
		{
			this.HandleJoystickMoving(forceExecute);
			this.HandleJoystickNoMoving();
		}

		// Token: 0x0603249C RID: 205980 RVA: 0x00C93BD4 File Offset: 0x00C91DD4
		protected override void OnBeforeDestroy()
		{
			this.CloseSecondaryUi(null, true);
			this.UnRegisterLogicComponents();
			this.ExploreInfoItem.DestroyMapNotes();
			this.ExploreInfoItem.DestroyMapPlayPoints();
			ControllerBase<WorldMapController>.Instance.ClearFocalMarkItem();
			this.ZoomInButton.OnDestroy();
			this.ZoomOutButton.OnDestroy();
			LevelSequencePlayer unLockSequence = this.UnLockSequence;
			if (unLockSequence != null)
			{
				unLockSequence.Clear();
			}
			LevelSequencePlayer hudSequencer = this.HudSequencer;
			if (hudSequencer != null)
			{
				hudSequencer.Clear();
			}
			this.ClickedItems = null;
			this.PowerCurrencyItem.Destroy(null);
			this.OverPowerCurrencyItem.Destroy(null);
			this.Map.Destroy(null);
			this.CursorButton.Destroy(null);
			ModelBase<WorldMapModel>.Instance.WorldMapAxisInteractValidation.Reset();
			ModelBase<WorldMapModel>.Instance.WorldMapId = null;
			ModelBase<WorldMapModel>.Instance.WorldMapCurrentMultiMapId = null;
			ModelBase<WorldMapModel>.Instance.WorldExtraUiCount = 0;
			ModelBase<WorldMapModel>.Instance.IsCanAutoPilotTrack = true;
			ModelBase<WorldMapModel>.Instance.IsMapRangeVisible = true;
			ModelBase<WorldMapModel>.Instance.IsMultiMapVisible = true;
			ModelBase<MapModel>.Instance.ClearPendingAddTempMapMarkList();
			MapModel instance = ModelBase<MapModel>.Instance;
			if (instance != null)
			{
				instance.ClearExtraUiMarkType(EMapType.WorldMap);
			}
			MapModel instance2 = ModelBase<MapModel>.Instance;
			if (instance2 != null)
			{
				instance2.ClearExtraUiMarkId(EMapType.WorldMap);
			}
			MapModel instance3 = ModelBase<MapModel>.Instance;
			if (instance3 != null)
			{
				instance3.ClearExtraUiTileRange(EMapType.WorldMap);
			}
			ModelBase<LevelPlayReportModel>.Instance.ResetDetailRequestFlag();
			ModelBase<ExploreProgressModel>.Instance.WorldMapViewClose();
			ModelBase<ExploreProgressModel>.Instance.SaveToLocalShowNoteIdMap();
			Singleton<EventSystem>.Instance.Emit(EEventName.OnWorldMapClose);
		}

		// Token: 0x0603249D RID: 205981 RVA: 0x00C93D44 File Offset: 0x00C91F44
		private UniTask ChangeMapAsyncAfterFocalMark(WorldMapChangeMapParams changeMapParams)
		{
			WorldMapView.<ChangeMapAsyncAfterFocalMark>d__77 <ChangeMapAsyncAfterFocalMark>d__;
			<ChangeMapAsyncAfterFocalMark>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ChangeMapAsyncAfterFocalMark>d__.<>4__this = this;
			<ChangeMapAsyncAfterFocalMark>d__.changeMapParams = changeMapParams;
			<ChangeMapAsyncAfterFocalMark>d__.<>1__state = -1;
			<ChangeMapAsyncAfterFocalMark>d__.<>t__builder.Start<WorldMapView.<ChangeMapAsyncAfterFocalMark>d__77>(ref <ChangeMapAsyncAfterFocalMark>d__);
			return <ChangeMapAsyncAfterFocalMark>d__.<>t__builder.Task;
		}

		// Token: 0x0603249E RID: 205982 RVA: 0x00C93D90 File Offset: 0x00C91F90
		private UniTask ChangeMapAfterAsync(WorldMapChangeMapParams changeMapParams)
		{
			WorldMapView.<ChangeMapAfterAsync>d__78 <ChangeMapAfterAsync>d__;
			<ChangeMapAfterAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ChangeMapAfterAsync>d__.<>4__this = this;
			<ChangeMapAfterAsync>d__.changeMapParams = changeMapParams;
			<ChangeMapAfterAsync>d__.<>1__state = -1;
			<ChangeMapAfterAsync>d__.<>t__builder.Start<WorldMapView.<ChangeMapAfterAsync>d__78>(ref <ChangeMapAfterAsync>d__);
			return <ChangeMapAfterAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603249F RID: 205983 RVA: 0x00C93DDC File Offset: 0x00C91FDC
		private UniTask ChangeMapAfterFocusPlayer()
		{
			WorldMapView.<ChangeMapAfterFocusPlayer>d__79 <ChangeMapAfterFocusPlayer>d__;
			<ChangeMapAfterFocusPlayer>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ChangeMapAfterFocusPlayer>d__.<>4__this = this;
			<ChangeMapAfterFocusPlayer>d__.<>1__state = -1;
			<ChangeMapAfterFocusPlayer>d__.<>t__builder.Start<WorldMapView.<ChangeMapAfterFocusPlayer>d__79>(ref <ChangeMapAfterFocusPlayer>d__);
			return <ChangeMapAfterFocusPlayer>d__.<>t__builder.Task;
		}

		// Token: 0x060324A0 RID: 205984 RVA: 0x00C93E20 File Offset: 0x00C92020
		private void RegisterLogicComponents()
		{
			this.WorldMapUiEntity = new WorldMapUiEntity();
			this.WorldMapUiEntity.Map = this.Map;
			this.WorldMapUiEntity.UiParams = this.UiParams;
			this.WorldMapUiEntity.OpenParams = this.ShowParams;
			this.WorldMapUiEntity.MapId = this.OpenParamMapId;
			this.WorldMapUiEntity.RegisterComponents();
			this.WorldMapUiEntity.ScaleComponent.ScaleSlider = base.GetSlider(1);
			this.WorldMapUiEntity.MultiFloorComponent.MultiMapFloorLayout = this.MultiMapFloorLayout;
			TWorldMapPlaySequenceFunction worldMapViewPlaySequenceFunction = delegate(string sequenceName, bool blockClick)
			{
				WorldMapView.<<RegisterLogicComponents>b__80_0>d <<RegisterLogicComponents>b__80_0>d;
				<<RegisterLogicComponents>b__80_0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
				<<RegisterLogicComponents>b__80_0>d.<>4__this = this;
				<<RegisterLogicComponents>b__80_0>d.sequenceName = sequenceName;
				<<RegisterLogicComponents>b__80_0>d.blockClick = blockClick;
				<<RegisterLogicComponents>b__80_0>d.<>1__state = -1;
				<<RegisterLogicComponents>b__80_0>d.<>t__builder.Start<WorldMapView.<<RegisterLogicComponents>b__80_0>d>(ref <<RegisterLogicComponents>b__80_0>d);
				return <<RegisterLogicComponents>b__80_0>d.<>t__builder.Task;
			};
			this.WorldMapUiEntity.MultiFloorComponent.WorldMapViewPlaySequenceFunction = worldMapViewPlaySequenceFunction;
			this.WorldMapUiEntity.WorldMapAlterMapComponent.WorldMapViewPlaySequenceFunction = worldMapViewPlaySequenceFunction;
			this.WorldMapUiEntity.WorldMapAlterMapComponent.InverseTowerCtrlRoot = base.GetItem(20);
			this.WorldMapUiEntity.WorldMapAlterMapComponent.InverseTowerCtrlRoot.SetUIActive(false);
			this.WorldMapUiEntity.WorldMapExtraUiPanelComponent.OnExtraUiViewOpened = new Action<WorldMapExtraUiPanel>(this.OnExtraUiViewOpened);
			this.WorldMapUiEntity.WorldMapExtraUiPanelComponent.OnExtraUiViewClosed = new Action(this.OnExtraUiViewClosed);
		}

		// Token: 0x060324A1 RID: 205985 RVA: 0x00C93F49 File Offset: 0x00C92149
		private void UnRegisterLogicComponents()
		{
			this.WorldMapUiEntity.Dispose();
			this.WorldMapUiEntity = null;
		}

		// Token: 0x060324A2 RID: 205986 RVA: 0x00C93F60 File Offset: 0x00C92160
		private void ShowPanel(MarkItem clickedItem, ECustomMarkPanelMode customPanelMode = ECustomMarkPanelMode.Modify)
		{
			if (Singleton<Info>.Instance.IsInGamepad())
			{
				this.WorldMapUiEntity.MoveComponent.PushMap(clickedItem, true, EClampType.NotClamp);
			}
			else
			{
				this.WorldMapUiEntity.MoveComponent.PushMap(clickedItem, true, EClampType.ClampToSafeArea);
			}
			this.WorldMapUiEntity.SecondaryUiComponent.ShowPanel(clickedItem, base.GetItem(25), (int)customPanelMode);
		}

		// Token: 0x060324A3 RID: 205987 RVA: 0x00C93FBC File Offset: 0x00C921BC
		private void UpdateExtraSecondaryUiOpen()
		{
			bool extraSecondaryUiOpen = false;
			foreach (EUiViewName viewName in this.ExtraSecondaryUiViewMap)
			{
				if (Singleton<UiManager>.Instance.IsViewOpen(viewName))
				{
					extraSecondaryUiOpen = true;
					break;
				}
			}
			this.WorldMapUiEntity.SecondaryUiComponent.ExtraSecondaryUiOpen = extraSecondaryUiOpen;
		}

		// Token: 0x060324A4 RID: 205988 RVA: 0x00C9402C File Offset: 0x00C9222C
		private void OnOpenViewBegin(EUiViewName viewName)
		{
			if (this.ExtraSecondaryUiViewMap.Contains(viewName))
			{
				this.CloseSecondaryUi(null, false);
				this.WorldMapUiEntity.SecondaryUiComponent.ExtraSecondaryUiOpen = true;
				this.OnSecondaryUiOpened();
			}
		}

		// Token: 0x060324A5 RID: 205989 RVA: 0x00C9405B File Offset: 0x00C9225B
		private void OnCloseView(EUiViewName viewName, int i)
		{
			if (this.ExtraSecondaryUiViewMap.Contains(viewName))
			{
				this.WorldMapUiEntity.SecondaryUiComponent.ExtraSecondaryUiOpen = false;
				if (!this.WorldMapUiEntity.SecondaryUiComponent.IsSecondaryUiOpening)
				{
					this.OnSecondaryUiClosed(false);
				}
			}
		}

		// Token: 0x060324A6 RID: 205990 RVA: 0x00C94098 File Offset: 0x00C92298
		[NullableContext(2)]
		private void CloseSecondaryUi(Action onClosed = null, bool playSequence = true)
		{
			WorldMapUiEntity worldMapUiEntity = this.WorldMapUiEntity;
			if (((worldMapUiEntity != null) ? worldMapUiEntity.ClickedItem : null) != null && this.WorldMapUiEntity.ClickedItem.IsIgnoreScaleShow)
			{
				this.WorldMapUiEntity.ClickedItem.IsIgnoreScaleShow = false;
				this.WorldMapUiEntity.ClickedItem.SetSelected(false);
				this.WorldMapUiEntity.UpdateSingleMarkItem(this.WorldMapUiEntity.ClickedItem, true);
			}
			if (this.WorldMapUiEntity.SecondaryUiComponent.ExtraSecondaryUiOpen)
			{
				foreach (EUiViewName euiViewName in this.ExtraSecondaryUiViewMap)
				{
					if (Singleton<UiManager>.Instance.IsViewOpen(euiViewName))
					{
						Singleton<UiManager>.Instance.CloseView(euiViewName, null);
					}
				}
			}
			if (!this.WorldMapUiEntity.SecondaryUiComponent.IsInternalSecondaryUiOpen())
			{
				if (onClosed != null)
				{
					onClosed();
				}
				return;
			}
			this.WorldMapUiEntity.MultiFloorComponent.UpdateMultiMap();
			this.WorldMapUiEntity.SecondaryUiComponent.CloseUi(onClosed, playSequence);
		}

		// Token: 0x060324A7 RID: 205991 RVA: 0x00C941AC File Offset: 0x00C923AC
		private void OpenPowerView(int index)
		{
			this.CloseSecondaryUi(delegate
			{
				ControllerBase<PowerController>.Instance.OpenPowerView(EPowerMenuType.Supply, 0);
			}, true);
		}

		// Token: 0x060324A8 RID: 205992 RVA: 0x00C941D4 File Offset: 0x00C923D4
		private void OnSecondaryUiClosed(bool bIsForce = false)
		{
			this.Map.SetClickRangeVisible(false, null);
			if (this.WorldMapUiEntity.ClickedItem != null)
			{
				this.WorldMapUiEntity.ClickedItem.IsIgnoreScaleShow = false;
				this.WorldMapUiEntity.ClickedItem.SetSelected(false);
				this.WorldMapUiEntity.UpdateSingleMarkItem(this.WorldMapUiEntity.ClickedItem, true);
				this.WorldMapUiEntity.ClickedItem = null;
			}
			if (!this.IsCloseThenOpenSecondaryUi)
			{
				this.RemoveUncommittedCustomMark();
			}
			this.WorldMapUiEntity.UpdateMarkItems(null);
			this.ExploreInfoItem.SetMapNotesState(true);
			if (!this.WorldMapUiEntity.WorldMapExtraUiPanelComponent.ShowTopPanel() && (!this.IsCloseThenOpenSecondaryUi || bIsForce))
			{
				this.HudSequencer.StopCurrentSequence(false, false);
				base.GetItem(14).SetUIActive(true);
				Singleton<EventSystem>.Instance.Emit<bool>(EEventName.WorldMapPanelHudVisibleChanged, true);
				this.HudSequencer.PlayLevelSequenceByName("Show", false, null, false);
			}
			this.JoystickCheck(Singleton<Info>.Instance.IsInGamepad());
			this.CursorButton.SetCursorActive(true);
			this.CheckWaitNoteAndRecommend();
		}

		// Token: 0x060324A9 RID: 205993 RVA: 0x00C942F8 File Offset: 0x00C924F8
		private void CheckWaitNoteAndRecommend()
		{
			if (!this.IsWaitNoteAndRecommend)
			{
				return;
			}
			if (this.WorldMapUiEntity.SecondaryUiComponent.IsSecondaryUiOpening)
			{
				return;
			}
			int num = 500;
			this.IsWaitNoteAndRecommend = false;
			this.ExploreInfoItem.UpdateNoteOrPlayProgress();
			this.ResumeMapAndRecommendSequence(new float?((float)num));
		}

		// Token: 0x060324AA RID: 205994 RVA: 0x00C94348 File Offset: 0x00C92548
		private void OnSecondaryUiOpened()
		{
			this.ExploreInfoItem.SetMapNotesState(false);
			if (!this.WorldMapUiEntity.WorldMapExtraUiPanelComponent.HideTopPanel())
			{
				UUIItem item = base.GetItem(14);
				if (!this.IsCloseThenOpenSecondaryUi || (item != null && item.IsUIActiveSelf()))
				{
					this.HudSequencer.StopCurrentSequence(false, false);
					this.HudSequencer.PlayLevelSequenceByName("Hide", false, null, false);
				}
				this.IsCloseThenOpenSecondaryUi = false;
			}
			this.CursorButton.SetCursorActive(false);
		}

		// Token: 0x060324AB RID: 205995 RVA: 0x00C943CA File Offset: 0x00C925CA
		private void OnHudSequenceEnd(string param)
		{
			if (param == "Hide")
			{
				base.GetItem(14).SetUIActive(false);
				Singleton<EventSystem>.Instance.Emit<bool>(EEventName.WorldMapPanelHudVisibleChanged, false);
			}
		}

		// Token: 0x060324AC RID: 205996 RVA: 0x00C943F8 File Offset: 0x00C925F8
		private void OnPointerDrag(Vector2D delta)
		{
			if (this.WorldMapUiEntity.MoveComponent.IsDragMoveDisabled)
			{
				return;
			}
			WorldMapUiEntity worldMapUiEntity = this.WorldMapUiEntity;
			if (worldMapUiEntity != null && worldMapUiEntity.WorldMapExtraUiPanelComponent.OnPointerDrag(delta))
			{
				return;
			}
			this.CloseSecondaryUi(null, true);
		}

		// Token: 0x1700864A RID: 34378
		// (get) Token: 0x060324AD RID: 205997 RVA: 0x00C94430 File Offset: 0x00C92630
		public float MapScale
		{
			get
			{
				return ModelBase<WorldMapModel>.Instance.MapScale;
			}
		}

		// Token: 0x060324AE RID: 205998 RVA: 0x00C9443C File Offset: 0x00C9263C
		private void OnPointerUp(ULGUIPointerEventData eventData)
		{
			if (eventData.mouseButtonType == EMouseButtonType.Right)
			{
				return;
			}
			if (this.WorldMapUiEntity.SecondaryUiComponent.ExtraSecondaryUiOpen)
			{
				return;
			}
			FVector localPointInPlane = eventData.GetLocalPointInPlane();
			Vector2D clickedPosition = Vector2D.Create((double)localPointInPlane.X, (double)localPointInPlane.Y);
			if (!Singleton<Info>.Instance.IsBuildShipping)
			{
				global::Vector vector = MapUtil.UiPosition2WorldPosition(global::Vector.Create((double)localPointInPlane.X, (double)localPointInPlane.Y, 0.0), null);
				global::Vector markPosition = ControllerBase<MapController>.Instance.GetMarkPosition((double)localPointInPlane.X, (double)(-(double)localPointInPlane.Y));
				if (markPosition != null)
				{
					vector.Set(markPosition.X * 100.0, markPosition.Y * 100.0, markPosition.Z * 100.0);
					WorldNavigation.TestFindPath(vector, delegate(bool isSuccess)
					{
						if (isSuccess && Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.WorldMapView))
						{
							Singleton<UiManager>.Instance.CloseViewAsync(EUiViewName.WorldMapView);
						}
					});
				}
			}
			if (this.WorldMapUiEntity.IsInPlayerMap && this.WorldMapUiEntity.PlayerComponent.PlayerOutOfBound && this.InClickRange(clickedPosition, this.Map.SelfPlayerNode, true, null).Item1)
			{
				this.MapFocusPlayer();
				return;
			}
			List<MarkItem> clickedItems = new List<MarkItem>();
			global::Vector clickPosition = global::Vector.Create((double)localPointInPlane.X, (double)localPointInPlane.Y, (double)localPointInPlane.Z);
			int? customClickRange = this.WorldMapUiEntity.WorldMapExtraUiPanelComponent.GetCustomClickRange();
			int cellRadius = 1;
			if (customClickRange != null)
			{
				float num = Math.Max(Math.Max(50f, (float)this.UiParams.MarkMenuRectSize), (float)customClickRange.Value);
				cellRadius = Math.Max(1, (int)Math.Ceiling((double)(num / (this.MapScale * 50f))));
			}
			List<MarkItem> markItemsByClickPosition = this.Map.GetMarkItemsByClickPosition(clickPosition, cellRadius);
			List<UniTask<ValueTuple<MarkItem, UUIItem>>> list = new List<UniTask<ValueTuple<MarkItem, UUIItem>>>();
			List<UniTask<ValueTuple<MarkItem, UUIItem>>> list2 = new List<UniTask<ValueTuple<MarkItem, UUIItem>>>();
			foreach (MarkItem markItem in markItemsByClickPosition)
			{
				if (markItem.View != null && markItem.GetInteractiveFlag() && !markItem.IsOutOfBound)
				{
					list.Add(WorldMapView.<OnPointerUp>g__getMarkTupleFunc|96_0(markItem));
				}
			}
			bool singleClickTest = list.Count <= 1;
			UniTask uniTask = UniTask.WhenAll<ValueTuple<MarkItem, UUIItem>>(list).ContinueWith(delegate(ValueTuple<MarkItem, UUIItem>[] markTupleItemList)
			{
				foreach (ValueTuple<MarkItem, UUIItem> valueTuple in markTupleItemList)
				{
					if (this.InClickRange(clickedPosition, valueTuple.Item2, singleClickTest, this.WorldMapUiEntity.WorldMapExtraUiPanelComponent.GetCustomClickRange()).Item1)
					{
						clickedItems.Add(valueTuple.Item1);
					}
				}
			});
			foreach (Dictionary<int, MarkItem> dictionary in this.Map.GetAllMarkItems().Values)
			{
				foreach (MarkItem markItem2 in dictionary.Values)
				{
					if (markItem2.IsOutOfBound)
					{
						list2.Add(WorldMapView.<OnPointerUp>g__getMarkTupleFunc|96_0(markItem2));
					}
				}
			}
			singleClickTest = (list2.Count <= 1);
			UniTask uniTask2 = UniTask.WhenAll<ValueTuple<MarkItem, UUIItem>>(list2).ContinueWith(delegate(ValueTuple<MarkItem, UUIItem>[] markTupleItemList)
			{
				foreach (ValueTuple<MarkItem, UUIItem> valueTuple in markTupleItemList)
				{
					if (this.InClickRange(clickedPosition, valueTuple.Item2, singleClickTest, this.WorldMapUiEntity.WorldMapExtraUiPanelComponent.GetCustomClickRange()).Item1)
					{
						clickedItems.Add(valueTuple.Item1);
					}
				}
			});
			UniTask.WhenAll(new UniTask[]
			{
				uniTask2,
				uniTask
			}).ContinueWith(delegate()
			{
				List<MarkItem> list3;
				if (!clickedItems.Any((MarkItem item) => item.IsOutOfBound))
				{
					list3 = clickedItems;
				}
				else
				{
					list3 = (from item in clickedItems
					where item.IsOutOfBound
					select item).ToList<MarkItem>();
				}
				List<MarkItem> list4 = list3;
				if (list4.Count == 0)
				{
					this.ClickEmpty(clickedPosition);
					return;
				}
				if (list4.Count == 1)
				{
					this.ClickSingleMark(list4[0], null);
					return;
				}
				if (list4.Count > 1)
				{
					this.ClickMarks(list4, clickedPosition);
				}
			}).Forget();
		}

		// Token: 0x060324AF RID: 205999 RVA: 0x00C947C0 File Offset: 0x00C929C0
		[NullableContext(0)]
		private ValueTuple<bool, double> InClickRange([Nullable(1)] Vector2D clickedPosition, [Nullable(2)] UUIItem item, bool singleTest, int? customClickRange = null)
		{
			return this.InClickRangeByUiPosition(clickedPosition, Vector2D.Create((item != null) ? new FVector2D?(item.GetAnchorOffset()) : null), singleTest, null, customClickRange);
		}

		// Token: 0x060324B0 RID: 206000 RVA: 0x00C94804 File Offset: 0x00C92A04
		[return: Nullable(0)]
		private ValueTuple<bool, double> InClickRangeByUiPosition(Vector2D clickedPosition, Vector2D targetPosition, bool singleTest, bool? isJoystick = null, int? customClickRange = null)
		{
			double num = Vector2D.Distance(clickedPosition, targetPosition);
			double num2 = (double)(singleTest ? customClickRange.GetValueOrDefault(50) : this.UiParams.MarkMenuRectSize);
			if (isJoystick.GetValueOrDefault())
			{
				num2 *= (double)ModelBase<WorldMapModel>.Instance.JoystickClickMultiplier;
			}
			return new ValueTuple<bool, double>(num * (double)this.MapScale <= num2, num);
		}

		// Token: 0x060324B1 RID: 206001 RVA: 0x00C94860 File Offset: 0x00C92A60
		private void ClickEmpty(Vector2D clickedPosition)
		{
			if (this.WorldMapUiEntity.MoveComponent.IsTweeningMove)
			{
				this.WorldMapUiEntity.MoveComponent.KillTweening();
			}
			WorldMapUiEntity worldMapUiEntity = this.WorldMapUiEntity;
			if (worldMapUiEntity != null && worldMapUiEntity.WorldMapExtraUiPanelComponent.ClickEmpty(clickedPosition))
			{
				return;
			}
			int? currentFocalMarkId = ModelBase<WorldMapModel>.Instance.CurrentFocalMarkId;
			int num = 0;
			if (!(currentFocalMarkId.GetValueOrDefault() == num & currentFocalMarkId != null) && ModelBase<WorldMapModel>.Instance.CurrentFocalMarkType != null)
			{
				this.Map.SetMarkUnFocal(ModelBase<WorldMapModel>.Instance.CurrentFocalMarkType.Value, ModelBase<WorldMapModel>.Instance.CurrentFocalMarkId.Value);
			}
			ControllerBase<WorldMapController>.Instance.ClearFocalMarkItem();
			if (this.WorldMapUiEntity.SecondaryUiComponent.IsSecondaryUiOpening)
			{
				this.IsCloseThenOpenSecondaryUi = false;
				this.WorldMapUiEntity.UpdateMarkItems(null);
				this.CloseSecondaryUi(null, true);
				return;
			}
			if (ModelBase<MapModel>.Instance.GetMarkCountByType(EMarkType.Custom) == ModelBase<WorldMapModel>.Instance.CustomMarkSize)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("WorldMapTagFull", Array.Empty<object>());
				return;
			}
			if (!ModelBase<WorldMapModel>.Instance.CustomMarksIsShow || ModelBase<WorldMapModel>.Instance.EnableInstanceDungeonFilterMark || this.ShowMode == EWorldMapShowMode.Base)
			{
				return;
			}
			this.WorldMapUiEntity.ClickedItem = this.CreateNewCustomMarkItem(clickedPosition);
			if (this.WorldMapUiEntity.ClickedItem != null)
			{
				this.WorldMapUiEntity.ClickedItem.IsIgnoreScaleShow = true;
				this.WorldMapUiEntity.ClickedItem.IsCanShowView = true;
				this.ShowPanel(this.WorldMapUiEntity.ClickedItem, ECustomMarkPanelMode.Create);
			}
			Singleton<AudioSystem>.Instance.PostEvent("play_ui_ia_spl_map_click_com");
		}

		// Token: 0x060324B2 RID: 206002 RVA: 0x00C949F8 File Offset: 0x00C92BF8
		private void RemoveUncommittedCustomMark()
		{
			Dictionary<int, MarkItem> markItemsByType = this.Map.GetMarkItemsByType(EMarkType.Custom, true);
			if (markItemsByType == null)
			{
				return;
			}
			List<int> list = new List<int>();
			foreach (MarkItem markItem in markItemsByType.Values)
			{
				CustomMarkItem customMarkItem = markItem as CustomMarkItem;
				if (customMarkItem != null && customMarkItem.IsNewCustomMarkItem)
				{
					list.Add(markItem.MarkId);
				}
			}
			foreach (int p in list)
			{
				Singleton<EventSystem>.Instance.Emit<EMarkType, int>(EEventName.RemoveMapMark, EMarkType.Custom, p);
			}
		}

		// Token: 0x060324B3 RID: 206003 RVA: 0x00C94ACC File Offset: 0x00C92CCC
		private unsafe CustomMarkItem CreateNewCustomMarkItem(Vector2D position)
		{
			double x = position.X;
			double y = position.Y;
			OneOf<global::Vector, Vector2D>? newCustomMarkPosition = ControllerBase<MapController>.Instance.GetNewCustomMarkPosition(x, -y);
			DynamicMarkCreateInfo dynamicMarkCreateInfo = new DynamicMarkCreateInfo(new DynamicMarkCreateParams
			{
				MarkId = new int?(1),
				TrackTarget = (newCustomMarkPosition.Value.IsT1 ? newCustomMarkPosition.Value.AsT1 : newCustomMarkPosition.Value.AsT2),
				MarkConfigId = 1,
				MarkType = EMarkType.Custom,
				MapAndDungeonInfo = new MapAndDungeonInfo
				{
					MapConfigId = new int?(this.OpenParamMapId)
				}
			});
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Map;
			ELogAuthor author = ELogAuthor.LYX;
			string message = "[CustomMarkItem Debug]WorldMapView.CreateNewCustomMarkItem->";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("position", position);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("info", dynamicMarkCreateInfo);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			CustomMarkItem customMarkItem = this.Map.CreateCustomMark(dynamicMarkCreateInfo);
			if (customMarkItem == null)
			{
				return customMarkItem;
			}
			customMarkItem.SetIsNew(true);
			return customMarkItem;
		}

		// Token: 0x060324B4 RID: 206004 RVA: 0x00C94BE8 File Offset: 0x00C92DE8
		private void OnMarkMenuClickItem(MarkItem clickedItem)
		{
			this.ClickSingleMark(clickedItem, null);
		}

		// Token: 0x060324B5 RID: 206005 RVA: 0x00C94C05 File Offset: 0x00C92E05
		private void ClickSingleMark(MarkItem clickedItem, bool? forceShow = null)
		{
			this.WorldMapUiEntity.QuickNavigateComponent.NavigateTo(clickedItem.MarkId, clickedItem.MarkType, true, true, false);
		}

		// Token: 0x060324B6 RID: 206006 RVA: 0x00C94C28 File Offset: 0x00C92E28
		private void ClickSingleMarkImp(MarkItem clickedItem, bool? forceShow = null)
		{
			if (this.WorldMapUiEntity.ClickedItem != null && this.WorldMapUiEntity.ClickedItem.MarkId == clickedItem.MarkId)
			{
				return;
			}
			WorldMapModel instance = ModelBase<WorldMapModel>.Instance;
			int? currentFocalMarkId = instance.CurrentFocalMarkId;
			int num = 0;
			if (!(currentFocalMarkId.GetValueOrDefault() == num & currentFocalMarkId != null) && instance.CurrentFocalMarkType != null)
			{
				this.Map.SetMarkUnFocal(instance.CurrentFocalMarkType.Value, instance.CurrentFocalMarkId.Value);
			}
			this.Map.SetMarkFocal(clickedItem.MarkType, clickedItem.MarkId);
			instance.CurrentFocalMarkType = new EMarkType?(clickedItem.MarkType);
			instance.CurrentFocalMarkId = new int?(clickedItem.MarkId);
			if (instance.EnableDebug)
			{
				MapDebugger.PrintMarkItemDumpInfo(this.WorldMapUiEntity.Map, clickedItem);
			}
			WorldMapUiEntity worldMapUiEntity = this.WorldMapUiEntity;
			if (worldMapUiEntity != null && worldMapUiEntity.WorldMapExtraUiPanelComponent.ClickSingleMark(clickedItem))
			{
				return;
			}
			bool playSequence = true;
			if (this.WorldMapUiEntity.SecondaryUiComponent.IsInternalSecondaryUiOpen())
			{
				if (!clickedItem.IsOutOfBound || forceShow.GetValueOrDefault())
				{
					this.IsCloseThenOpenSecondaryUi = true;
				}
				else
				{
					this.IsCloseThenOpenSecondaryUi = false;
				}
				playSequence = false;
			}
			Action<UUIItem> <>9__1;
			this.CloseSecondaryUi(delegate
			{
				if (clickedItem.IsOutOfBound)
				{
					this.WorldMapUiEntity.MoveComponent.SetMapPosition(clickedItem, true, EClampType.ClampToSafeArea, null, null, true, true);
					if (!forceShow.GetValueOrDefault())
					{
						return;
					}
				}
				if (this.SequenceMarkItem != null && !this.SequenceMarkItem.IsDestroy)
				{
					UniTask<UUIItem> rootItemAsync = this.SequenceMarkItem.GetRootItemAsync();
					Action<UUIItem> continuationFunction;
					if ((continuationFunction = <>9__1) == null)
					{
						continuationFunction = (<>9__1 = delegate(UUIItem rootItem)
						{
							if (rootItem != null)
							{
								this.GetItemLevelSequenceItem(rootItem).StopSequenceByKey("Dianji", false, false);
							}
						});
					}
					rootItemAsync.ContinueWith(continuationFunction);
				}
				this.SequenceMarkItem = clickedItem;
				this.WorldMapUiEntity.ClickedItem = clickedItem;
				MarkItem clickedItem2 = this.WorldMapUiEntity.ClickedItem;
				if (clickedItem2 != null)
				{
					clickedItem2.SetSelected(true);
				}
				this.WorldMapUiEntity.UpdateSingleMarkItem(clickedItem, true);
				if (this.WorldMapUiEntity.ClickedItem.IsMultiMap())
				{
					int multiMapId = this.WorldMapUiEntity.ClickedItem.GetMultiMapId();
					MultiMap? subMapConfigById = ConfigBase<MapConfig>.Instance.GetSubMapConfigById(multiMapId);
					if (subMapConfigById != null)
					{
						int areaId = (subMapConfigById.Value.AreaLength > 0) ? subMapConfigById.Value.Area(0) : this.WorldMapUiEntity.Map.GetWorldMapCenterAreaId();
						int groupId = subMapConfigById.Value.GroupId;
						int floor = subMapConfigById.Value.Floor;
						this.WorldMapUiEntity.MultiFloorComponent.SelectMultiMapFloor(areaId, new int?(groupId), new int?(floor), true);
					}
				}
				else
				{
					this.WorldMapUiEntity.MultiFloorComponent.DeSelectMultiMapFloor(true);
				}
				this.ShowPanel(clickedItem, ECustomMarkPanelMode.Modify);
			}, playSequence);
		}

		// Token: 0x060324B7 RID: 206007 RVA: 0x00C94DAC File Offset: 0x00C92FAC
		private LevelSequencePlayer GetItemLevelSequenceItem(UUIItem item)
		{
			LevelSequencePlayer levelSequencePlayer;
			this.ClickItemLevelSequenceMap.TryGetValue(item, out levelSequencePlayer);
			LevelSequencePlayer levelSequencePlayer2 = levelSequencePlayer;
			if (levelSequencePlayer2 == null)
			{
				levelSequencePlayer2 = new LevelSequencePlayer(item);
				this.ClickItemLevelSequenceMap[item] = levelSequencePlayer2;
			}
			return levelSequencePlayer2;
		}

		// Token: 0x060324B8 RID: 206008 RVA: 0x00C94DE4 File Offset: 0x00C92FE4
		private UniTask OnCloseSecondaryUiByClickOtherMarkCall(List<MarkItem> clickedItems, Vector2D clickedPosition)
		{
			WorldMapView.<OnCloseSecondaryUiByClickOtherMarkCall>d__106 <OnCloseSecondaryUiByClickOtherMarkCall>d__;
			<OnCloseSecondaryUiByClickOtherMarkCall>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnCloseSecondaryUiByClickOtherMarkCall>d__.<>4__this = this;
			<OnCloseSecondaryUiByClickOtherMarkCall>d__.clickedItems = clickedItems;
			<OnCloseSecondaryUiByClickOtherMarkCall>d__.clickedPosition = clickedPosition;
			<OnCloseSecondaryUiByClickOtherMarkCall>d__.<>1__state = -1;
			<OnCloseSecondaryUiByClickOtherMarkCall>d__.<>t__builder.Start<WorldMapView.<OnCloseSecondaryUiByClickOtherMarkCall>d__106>(ref <OnCloseSecondaryUiByClickOtherMarkCall>d__);
			return <OnCloseSecondaryUiByClickOtherMarkCall>d__.<>t__builder.Task;
		}

		// Token: 0x060324B9 RID: 206009 RVA: 0x00C94E38 File Offset: 0x00C93038
		private void ClickMarks(List<MarkItem> clickedItems, Vector2D clickedPosition)
		{
			if (this.WorldMapUiEntity.WorldMapExtraUiPanelComponent.ClickMarks(clickedItems, clickedPosition))
			{
				return;
			}
			if (this.WorldMapUiEntity.SecondaryUiComponent.IsSecondaryUiOpening)
			{
				this.IsCloseThenOpenSecondaryUi = true;
			}
			this.CloseSecondaryUi(delegate
			{
				this.OnCloseSecondaryUiByClickOtherMarkCall(clickedItems, clickedPosition);
				Singleton<AudioSystem>.Instance.PostEvent("play_ui_ia_spl_map_click_com");
			}, true);
			int? currentFocalMarkId = ModelBase<WorldMapModel>.Instance.CurrentFocalMarkId;
			int num = 0;
			if (!(currentFocalMarkId.GetValueOrDefault() == num & currentFocalMarkId != null) && ModelBase<WorldMapModel>.Instance.CurrentFocalMarkType != null)
			{
				this.Map.SetMarkUnFocal(ModelBase<WorldMapModel>.Instance.CurrentFocalMarkType.Value, ModelBase<WorldMapModel>.Instance.CurrentFocalMarkId.Value);
			}
			ControllerBase<WorldMapController>.Instance.ClearFocalMarkItem();
		}

		// Token: 0x060324BA RID: 206010 RVA: 0x00C94F10 File Offset: 0x00C93110
		private void OnCreateMarkItem(DynamicMarkCreateInfo info)
		{
			MarkItem markItem = this.Map.GetMarkItem(info.MarkType, info.MarkId.Value);
			if (markItem != null && markItem.MarkType == EMarkType.Custom)
			{
				markItem.IsIgnoreScaleShow = true;
			}
		}

		// Token: 0x060324BB RID: 206011 RVA: 0x00C94F51 File Offset: 0x00C93151
		private void OnAddMarkItem(MarkItem markItem)
		{
			if (!markItem.IsInConsistentDistrict(false))
			{
				this.WorldMapUiEntity.UpdateSingleMarkItem(markItem, false);
			}
		}

		// Token: 0x060324BC RID: 206012 RVA: 0x00C94F6C File Offset: 0x00C9316C
		private void OnRemoveMarkItem(EMarkType markType, int markId)
		{
			MarkItem markItem = this.Map.GetMarkItem(markType, markId);
			if (markItem != null)
			{
				this.WorldMapUiEntity.UpdateSingleMarkItem(markItem, true);
			}
			MarkItem clickedItem = this.WorldMapUiEntity.ClickedItem;
			if (clickedItem != null && clickedItem.MarkType == markType)
			{
				MarkItem clickedItem2 = this.WorldMapUiEntity.ClickedItem;
				if (clickedItem2 != null && clickedItem2.MarkId == markId)
				{
					this.WorldMapUiEntity.ClickedItem.IsIgnoreScaleShow = false;
					this.WorldMapUiEntity.ClickedItem = null;
				}
			}
		}

		// Token: 0x060324BD RID: 206013 RVA: 0x00C94FEC File Offset: 0x00C931EC
		private void OnWorldMapTrackMarkItem(EMarkType markType, int markId)
		{
			this.WorldMapUiEntity.QuickNavigateComponent.NavigateTo(markId, markType, true, true, false);
		}

		// Token: 0x060324BE RID: 206014 RVA: 0x00C95004 File Offset: 0x00C93204
		private unsafe void OnNavigateFocalMarkItem(int markId, EMarkType markType, bool focal, bool focusTween, bool? needTempShow = null)
		{
			if (needTempShow.GetValueOrDefault() && this.Map.GetMarkItem(markType, markId) == null)
			{
				ModelBase<MapModel>.Instance.CreateTempMapMark(markId);
			}
			MarkItem markItem = this.Map.GetMarkItem(markType, markId);
			if (markItem == null)
			{
				ELogAuthor author = ELogAuthor.LYX;
				string message = "聚焦了不存在的标记";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("地图标记类型:", markType);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("地图标记Id", markId);
				MapLogger.Warn(author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return;
			}
			this.WorldMapUiEntity.MoveComponent.PushMap(markItem, focusTween, EClampType.ClampToDangerousArea);
			if (focal && markItem.MarkType != EMarkType.AreaMark)
			{
				this.FocalMarkItem(markItem.MarkType, markId);
			}
		}

		// Token: 0x060324BF RID: 206015 RVA: 0x00C950C9 File Offset: 0x00C932C9
		private void OnChangeWorldMap(WorldMapChangeMapParams changeMapParams)
		{
			this.ChangeMapAsyncAfterFocalMark(changeMapParams);
		}

		// Token: 0x060324C0 RID: 206016 RVA: 0x00C950D4 File Offset: 0x00C932D4
		private void EventToggleShowCustomMark(bool isShow)
		{
			this.WorldMapUiEntity.UpdateMarkItems(null);
		}

		// Token: 0x060324C1 RID: 206017 RVA: 0x00C950F8 File Offset: 0x00C932F8
		private void EventToggleShowCompletedPlayMark(bool isShow)
		{
			this.WorldMapUiEntity.UpdateMarkItems(null);
		}

		// Token: 0x060324C2 RID: 206018 RVA: 0x00C9511C File Offset: 0x00C9331C
		private void EventNavigateMarkAndShowRange(NavigateMarkShowRange navigate)
		{
			WorldMapUiEntity worldMapUiEntity = this.WorldMapUiEntity;
			WorldMapChangeMapDiffParams worldMapChangeMapDiffParams = (worldMapUiEntity != null) ? worldMapUiEntity.QuickNavigateComponent.GetNavigateMarkIsNeedChangeMap(navigate.MarkId, navigate.MarkType) : null;
			if (worldMapChangeMapDiffParams != null && (worldMapChangeMapDiffParams.MapId != null || worldMapChangeMapDiffParams.Gravity != null))
			{
				this.ChangeMapAsyncAfterFocalMarkAndShowRange(worldMapChangeMapDiffParams.MapId.Value, navigate, new EMapGravityDirection?(worldMapChangeMapDiffParams.Gravity.GetValueOrDefault(EMapGravityDirection.Down)));
				return;
			}
			this.OnNavigateFocalMarkItem(navigate.MarkId, navigate.MarkType, false, navigate.FocusTween.GetValueOrDefault(true), null);
			this.ShowRangeByMarkItem(navigate);
		}

		// Token: 0x060324C3 RID: 206019 RVA: 0x00C951C0 File Offset: 0x00C933C0
		private void EventOpenExploreAreaDetailViewFromMap(int areaId, EExploreType? exploreType = null)
		{
			if (Singleton<UiManager>.Instance.IsViewShow(EUiViewName.MapExploreDetailView))
			{
				return;
			}
			if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.MapExploreDetailView))
			{
				Singleton<UiManager>.Instance.CloseViewAsync(EUiViewName.MapExploreDetailView).ContinueWith(delegate(bool _)
				{
					this.OpenMapExploreAreaDetailView(areaId, exploreType);
				});
				return;
			}
			this.OpenMapExploreAreaDetailView(areaId, exploreType);
		}

		// Token: 0x060324C4 RID: 206020 RVA: 0x00C9523F File Offset: 0x00C9343F
		private void OnWorldMapActivityListDataUpdate()
		{
			this.WorldMapPeriodicActivityItem.Refresh(this.InEightMap());
		}

		// Token: 0x060324C5 RID: 206021 RVA: 0x00C95254 File Offset: 0x00C93454
		public void OpenMapExploreAreaDetailView(int areaId, EExploreType? exploreType = null)
		{
			UiManager instance = Singleton<UiManager>.Instance;
			EUiViewName mapExploreDetailView = EUiViewName.MapExploreDetailView;
			MapExploreDetailViewParams mapExploreDetailViewParams = new MapExploreDetailViewParams();
			mapExploreDetailViewParams.AreaId = areaId;
			mapExploreDetailViewParams.ExploreType = exploreType;
			instance.OpenView(mapExploreDetailView, mapExploreDetailViewParams, delegate(bool success, int viewId)
			{
				if (!success)
				{
					return;
				}
				Singleton<UiModel>.Instance.NormalStack.Peek().AddChildViewById(viewId);
			});
		}

		// Token: 0x060324C6 RID: 206022 RVA: 0x00C952A4 File Offset: 0x00C934A4
		private UniTask ChangeMapAsyncAfterFocalMarkAndShowRange(int mapId, NavigateMarkShowRange navigate, EMapGravityDirection? gravity = null)
		{
			WorldMapView.<ChangeMapAsyncAfterFocalMarkAndShowRange>d__120 <ChangeMapAsyncAfterFocalMarkAndShowRange>d__;
			<ChangeMapAsyncAfterFocalMarkAndShowRange>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ChangeMapAsyncAfterFocalMarkAndShowRange>d__.<>4__this = this;
			<ChangeMapAsyncAfterFocalMarkAndShowRange>d__.mapId = mapId;
			<ChangeMapAsyncAfterFocalMarkAndShowRange>d__.navigate = navigate;
			<ChangeMapAsyncAfterFocalMarkAndShowRange>d__.gravity = gravity;
			<ChangeMapAsyncAfterFocalMarkAndShowRange>d__.<>1__state = -1;
			<ChangeMapAsyncAfterFocalMarkAndShowRange>d__.<>t__builder.Start<WorldMapView.<ChangeMapAsyncAfterFocalMarkAndShowRange>d__120>(ref <ChangeMapAsyncAfterFocalMarkAndShowRange>d__);
			return <ChangeMapAsyncAfterFocalMarkAndShowRange>d__.<>t__builder.Task;
		}

		// Token: 0x060324C7 RID: 206023 RVA: 0x00C95300 File Offset: 0x00C93500
		private UniTask ShowRangeByMarkItem(NavigateMarkShowRange navigate)
		{
			WorldMapView.<ShowRangeByMarkItem>d__121 <ShowRangeByMarkItem>d__;
			<ShowRangeByMarkItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ShowRangeByMarkItem>d__.<>4__this = this;
			<ShowRangeByMarkItem>d__.navigate = navigate;
			<ShowRangeByMarkItem>d__.<>1__state = -1;
			<ShowRangeByMarkItem>d__.<>t__builder.Start<WorldMapView.<ShowRangeByMarkItem>d__121>(ref <ShowRangeByMarkItem>d__);
			return <ShowRangeByMarkItem>d__.<>t__builder.Task;
		}

		// Token: 0x060324C8 RID: 206024 RVA: 0x00C9534C File Offset: 0x00C9354C
		private unsafe void FocalMarkItem(EMarkType markType, int markId)
		{
			MarkItem markItem = this.Map.GetMarkItem(markType, markId);
			if (markItem == null)
			{
				ELogAuthor author = ELogAuthor.LYX;
				string message = "申请了不存在的地图标记";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("地图标记类型:", markType);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("地图标记Id", markId);
				MapLogger.Error(author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return;
			}
			if (markItem.GetIsStrictConfigMark())
			{
				ConfigMarkItem configMarkItem = markItem as ConfigMarkItem;
				if (!configMarkItem.IsFogUnlock)
				{
					int fogHide = configMarkItem.MarkConfig.Value.FogHide;
					MapFog? mapFogConfig = ConfigBase<WorldMapConfig>.Instance.GetMapFogConfig(fogHide);
					this.ShowUnlockCondition((mapFogConfig != null) ? mapFogConfig.GetValueOrDefault().UnlockCondition : 0);
					return;
				}
				if (!configMarkItem.IsConditionShouldShow && !markItem.MarkItemEntity.IsTempMapMark)
				{
					if (configMarkItem.MarkType != EMarkType.CommonGamePlay && configMarkItem.MarkType != EMarkType.LevelPlayReport)
					{
						this.ShowUnlockCondition(configMarkItem.MarkConfig.Value.ShowCondition);
						return;
					}
					if (!configMarkItem.IsConditionShouldShowWithoutServerState && !markItem.MarkItemEntity.IsTempMapMark)
					{
						this.ShowUnlockCondition(configMarkItem.MarkConfig.Value.ShowCondition);
						return;
					}
				}
			}
			markItem.IsCanShowView = true;
			markItem.IsIgnoreScaleShow = true;
			if (markItem.GetInteractiveFlag())
			{
				this.ClickSingleMarkImp(markItem, new bool?(true));
			}
		}

		// Token: 0x060324C9 RID: 206025 RVA: 0x00C954B8 File Offset: 0x00C936B8
		private void ShowUnlockCondition(int conditionId)
		{
			if (conditionId <= 0)
			{
				ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("MapAreaIsLock", Array.Empty<object>());
				return;
			}
			ConditionGroup? conditionGroup = ConfigBase<WorldMapConfig>.Instance.GetConditionGroup(conditionId);
			string text = (conditionGroup != null) ? conditionGroup.GetValueOrDefault().HintText : null;
			if (text != null && !StringUtils.IsEmpty(text))
			{
				string localText = ConfigBase<MapConfig>.Instance.GetLocalText(text);
				ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("UnlockCondition", new object[]
				{
					localText
				});
				return;
			}
			ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("MapAreaIsLock", Array.Empty<object>());
		}

		// Token: 0x060324CA RID: 206026 RVA: 0x00C9554B File Offset: 0x00C9374B
		private void OnZoomOut(float _)
		{
			Singleton<AudioSystem>.Instance.PostEvent("play_ui_com_slider_tick");
			this.IncreaseMapScale(0.1f, EMapScaleSetType.ZoomButton);
		}

		// Token: 0x060324CB RID: 206027 RVA: 0x00C95569 File Offset: 0x00C93769
		private void OnZoomIn(float _)
		{
			Singleton<AudioSystem>.Instance.PostEvent("play_ui_com_slider_tick");
			this.IncreaseMapScale(-0.1f, EMapScaleSetType.ZoomButton);
		}

		// Token: 0x060324CC RID: 206028 RVA: 0x00C95587 File Offset: 0x00C93787
		private void OnCloseBtnClick()
		{
			Singleton<UiManager>.Instance.ResetToBattleView(null);
		}

		// Token: 0x060324CD RID: 206029 RVA: 0x00C95594 File Offset: 0x00C93794
		private void IncreaseMapScale(float delta, EMapScaleSetType type)
		{
			if (type == EMapScaleSetType.Gamepad && this.WorldMapUiEntity.InteractComponent.IsJoystickZoom)
			{
				this.WorldMapUiEntity.MoveComponent.KillTweening();
			}
			if (!this.WorldMapUiEntity.SecondaryUiComponent.IsSecondaryUiOpening && this.WorldMapUiEntity.WorldMapExtraUiPanelComponent.IsEnableMapScale)
			{
				this.WorldMapUiEntity.ScaleComponent.AddMapScale(delta, type);
			}
		}

		// Token: 0x060324CE RID: 206030 RVA: 0x00C955FD File Offset: 0x00C937FD
		private void InputControllerChange(EInputControllerType eInputControllerType, EInputControllerType inputControllerType)
		{
			this.CursorButton.SetCursorActive(!this.WorldMapUiEntity.SecondaryUiComponent.IsSecondaryUiOpening && this.WorldMapUiEntity.WorldMapExtraUiPanelComponent.IsEnableMapCursorButton);
		}

		// Token: 0x060324CF RID: 206031 RVA: 0x00C95630 File Offset: 0x00C93830
		private void OnJoystickCheck()
		{
			if (Singleton<Info>.Instance.IsInGamepad())
			{
				if (this.ClickedItems.Count == 0)
				{
					this.ClickEmpty(this.ClickedPosition);
					return;
				}
				if (this.ClickedItems.Count == 1)
				{
					this.ClickSingleMark(this.ClickedItems[0], null);
					return;
				}
				if (this.ClickedItems.Count > 1)
				{
					this.ClickMarks(this.ClickedItems, this.ClickedPosition);
				}
			}
		}

		// Token: 0x060324D0 RID: 206032 RVA: 0x00C956AD File Offset: 0x00C938AD
		private void OnWorldMapFocusPlayer()
		{
			WorldMapUiEntity worldMapUiEntity = this.WorldMapUiEntity;
			if (worldMapUiEntity != null && worldMapUiEntity.IsInPlayerMap)
			{
				WorldMapUiEntity worldMapUiEntity2 = this.WorldMapUiEntity;
				if (worldMapUiEntity2 != null && worldMapUiEntity2.IsInPlayerGravity)
				{
					this.MapFocusPlayer();
					return;
				}
			}
			this.ChangeMapAfterFocusPlayer();
		}

		// Token: 0x060324D1 RID: 206033 RVA: 0x00C956E8 File Offset: 0x00C938E8
		private void MapFocusPlayer()
		{
			this.ResetFocusInteract();
			int currentAreaId = ModelBase<AreaModel>.Instance.GetCurrentAreaId(null);
			MultiMap? subMapConfigByAreaId = ConfigBase<MapConfig>.Instance.GetSubMapConfigByAreaId(currentAreaId);
			if (subMapConfigByAreaId != null)
			{
				int groupId = subMapConfigByAreaId.Value.GroupId;
				int floor = subMapConfigByAreaId.Value.Floor;
				this.WorldMapUiEntity.MultiFloorComponent.SelectMultiMapFloor(currentAreaId, new int?(groupId), new int?(floor), true);
			}
			WorldMapUiEntity worldMapUiEntity = this.WorldMapUiEntity;
			if (worldMapUiEntity == null)
			{
				return;
			}
			worldMapUiEntity.MoveComponent.FocusPlayer(this.WorldMapUiEntity.PlayerComponent.PlayerUiPosition, true, EClampType.ClampToSafeArea);
		}

		// Token: 0x060324D2 RID: 206034 RVA: 0x00C95790 File Offset: 0x00C93990
		private void OnWorldMapShowTrackList()
		{
			List<ITrackMenuItemData> dataList = this.GetAllTrackMenuItemData();
			if (dataList.Count <= 0)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Tracking_List_Empty_Text", Array.Empty<object>());
				return;
			}
			if (this.WorldMapUiEntity.SecondaryUiComponent.IsSecondaryUiOpening)
			{
				this.IsCloseThenOpenSecondaryUi = true;
			}
			this.CloseSecondaryUi(delegate
			{
				WorldMapUiEntity worldMapUiEntity = this.WorldMapUiEntity;
				if (worldMapUiEntity == null)
				{
					return;
				}
				worldMapUiEntity.SecondaryUiComponent.ShowTrackMenu(this.GetItem(25), dataList);
			}, true);
		}

		// Token: 0x060324D3 RID: 206035 RVA: 0x00C95808 File Offset: 0x00C93A08
		private List<ITrackMenuItemData> GetAllTrackMenuItemData()
		{
			List<MarkItem> trackMenuMarkList = this.Map.GetTrackMenuMarkList();
			List<ITrackMenuItemData> list = new List<ITrackMenuItemData>();
			WorldMapUiEntity worldMapUiEntity = this.WorldMapUiEntity;
			if (worldMapUiEntity != null && worldMapUiEntity.IsInPlayerMap)
			{
				list.Add(new TrackMenuItemData
				{
					IsPlayerSelf = true,
					Icon = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_WorldMapPlayer1"),
					Title = ModelBase<FunctionModel>.Instance.GetPlayerName()
				});
			}
			foreach (MarkItem markItem in trackMenuMarkList)
			{
				list.Add(new TrackMenuItemData
				{
					Icon = markItem.IconPath,
					StateIcon = markItem.GetStateIconPath(),
					MarkItem = markItem
				});
			}
			return list;
		}

		// Token: 0x060324D4 RID: 206036 RVA: 0x00C958D8 File Offset: 0x00C93AD8
		private void OnTrackMenuClickItem(ITrackMenuItemData data)
		{
			this.CloseSecondaryUi(delegate
			{
				this.ResetFocusInteract();
				if (!data.IsPlayerSelf)
				{
					if (data.MarkItem != null)
					{
						this.WorldMapUiEntity.MoveComponent.SetMapPosition(data.MarkItem, true, EClampType.ClampToSafeArea, null, null, true, true);
					}
					return;
				}
				WorldMapUiEntity worldMapUiEntity = this.WorldMapUiEntity;
				if (worldMapUiEntity == null)
				{
					return;
				}
				worldMapUiEntity.MoveComponent.FocusPlayer(this.WorldMapUiEntity.PlayerComponent.PlayerUiPosition, true, EClampType.ClampToSafeArea);
			}, true);
		}

		// Token: 0x060324D5 RID: 206037 RVA: 0x00C9590C File Offset: 0x00C93B0C
		private void UpdateAreaProgress()
		{
			this.ExploreInfoItem.UpdateAreaProgress();
		}

		// Token: 0x060324D6 RID: 206038 RVA: 0x00C9591C File Offset: 0x00C93B1C
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
		{
			if (configParams[0] == "BarItem")
			{
				RegionalTerminalBarItem regionalTerminalBar = this.RegionalTerminalBar;
				if (regionalTerminalBar == null)
				{
					return null;
				}
				return regionalTerminalBar.GetGuideUiItemAndUiItemForShowEx(configParams);
			}
			else
			{
				UUIItem uuiitem;
				if (configParams[0] == "PanelIndex")
				{
					int panelIndex = int.Parse(configParams[1]);
					uuiitem = this.WorldMapUiEntity.SecondaryUiComponent.GetSecondaryPanelGuideFocusUiItem((ESecondaryPanel)panelIndex);
				}
				else
				{
					int num = int.Parse(configParams[0]);
					MapMark? mapMark;
					int? num2 = (ConfigBase<MapConfig>.Instance.GetConfigMark(num) != null) ? new int?(mapMark.GetValueOrDefault().ObjectType) : null;
					if (num2 == null)
					{
						Log instance = Singleton<Log>.Instance;
						ELogModule module = ELogModule.Guide;
						ELogAuthor author = ELogAuthor.TL;
						string message = "聚焦引导的额外参数配置有误, 找不到地图标记";
						ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("markId", num);
						instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
						return null;
					}
					MarkItem markItem = this.Map.GetMarkItem((EMarkType)num2.Value, num);
					this.WorldMapUiEntity.MoveComponent.SetMapPosition(markItem, true, EClampType.ClampToSafeArea, null, null, true, true);
					MarkItem markItem2 = markItem;
					UUIItem uuiitem2;
					if (markItem2 == null)
					{
						uuiitem2 = null;
					}
					else
					{
						MarkItemView view = markItem2.View;
						uuiitem2 = ((view != null) ? view.GetIconItem() : null);
					}
					uuiitem = uuiitem2;
					if (uuiitem == null)
					{
						return null;
					}
					AActor owner = uuiitem.GetOwner();
					TSubclassOf<UActorComponent> @class = UUIButtonComponent.StaticClass();
					bool bManualAttachment = false;
					FTransform ftransform = new FTransform();
					(owner.AddComponentByClass(@class, bManualAttachment, ftransform, false, default(FName)) as UUIButtonComponent).OnClickCallBack.Bind(delegate()
					{
						this.ClickSingleMark(markItem, null);
					});
				}
				if (uuiitem == null)
				{
					return null;
				}
				return new UUIItem[]
				{
					uuiitem,
					uuiitem
				};
			}
		}

		// Token: 0x060324D7 RID: 206039 RVA: 0x00C95ACC File Offset: 0x00C93CCC
		private void CheckAndCleanInvalidCustomMarks()
		{
			if (!LocalStorage.GetPlayer<bool>(ELocalStoragePlayerKey.HasCleanInvalidCustomMark, false))
			{
				Dictionary<int, MarkItem> markItemsByType = this.Map.GetMarkItemsByType(EMarkType.Custom, false);
				if (markItemsByType != null)
				{
					List<int> list = new List<int>();
					foreach (MarkItem markItem in markItemsByType.Values)
					{
						if (!this.Map.InValidMapTile(markItem.WorldPosition))
						{
							list.Add(markItem.MarkId);
						}
					}
					if (list.Count > 0)
					{
						ControllerBase<MapController>.Instance.RequestRemoveMapMarks(EMarkType.Custom, list);
					}
				}
				LocalStorage.SetPlayer<bool>(ELocalStoragePlayerKey.HasCleanInvalidCustomMark, true);
			}
		}

		// Token: 0x060324D8 RID: 206040 RVA: 0x00C95B7C File Offset: 0x00C93D7C
		private void OnChangeMapBtnClick()
		{
			this.ResetFocusInteract();
			this.CloseSecondaryUi(delegate
			{
				this.WorldMapUiEntity.MultiFloorComponent.DeSelectMultiMapFloor(true);
				this.WorldMapUiEntity.SecondaryUiComponent.ShowQuickNavigate(base.GetItem(25), this.Map.GetNavigateMarkList());
			}, true);
		}

		// Token: 0x060324D9 RID: 206041 RVA: 0x00C95B97 File Offset: 0x00C93D97
		private void OnMarkToggleBtnClick()
		{
			this.CloseSecondaryUi(delegate
			{
				WorldMapUiEntity worldMapUiEntity = this.WorldMapUiEntity;
				if (worldMapUiEntity == null)
				{
					return;
				}
				worldMapUiEntity.SecondaryUiComponent.ShowMapMarkTogglePanel(base.GetItem(25), null, null);
			}, true);
		}

		// Token: 0x060324DA RID: 206042 RVA: 0x00C95BAC File Offset: 0x00C93DAC
		private void ResetFocusInteract()
		{
			this.WorldMapUiEntity.InteractComponent.SetJoystickFocus(false);
			this.ClickedItems = new List<MarkItem>();
		}

		// Token: 0x060324DB RID: 206043 RVA: 0x00C95BCA File Offset: 0x00C93DCA
		private void OnChangeGravityBtnClick()
		{
			if (this.WorldMapUiEntity.WorldMapAlterMapComponent.CanChangeMapGravity)
			{
				this.ResetFocusInteract();
				this.CloseSecondaryUi(delegate
				{
					this.WorldMapUiEntity.MultiFloorComponent.DeSelectMultiMapFloor(true);
					this.WorldMapUiEntity.WorldMapAlterMapComponent.ChangeMapGravity();
					this.UpdateGravityBtn();
				}, true);
			}
		}

		// Token: 0x060324DC RID: 206044 RVA: 0x00C95BF8 File Offset: 0x00C93DF8
		private void UpdateGravityBtn()
		{
			bool canChangeMapGravity = this.WorldMapUiEntity.WorldMapAlterMapComponent.CanChangeMapGravity;
			this.WorldMapChangeGravityButtonItem.SetUiActive(canChangeMapGravity);
			if (canChangeMapGravity)
			{
				bool flag = ModelBase<WorldMapModel>.Instance.WorldMapGravity == EMapGravityDirection.Down;
				string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(flag ? "SP_BtnOverviewBDown" : "SP_BtnOverviewB");
				this.WorldMapChangeGravityButtonItem.SetSprite(resourcePath);
			}
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnUpdateGravityBtn, canChangeMapGravity);
		}

		// Token: 0x060324DD RID: 206045 RVA: 0x00C95C6A File Offset: 0x00C93E6A
		private void OnMapOpenFogChange(int fogId)
		{
			this.UpdateCustomizedThumbnail();
		}

		// Token: 0x060324DE RID: 206046 RVA: 0x00C95C74 File Offset: 0x00C93E74
		private void UpdateCustomizedThumbnail()
		{
			Dictionary<int, bool> allUnlockedAreas = ModelBase<MapModel>.Instance.GetAllUnlockedAreas();
			bool flag = allUnlockedAreas != null && allUnlockedAreas.GetValueOrDefault(ConfigCommonParamById.GetIntConfig("UnderseaOverviewUnlockAreaId").Value);
			base.GetItem(22).SetUIActive(ModelBase<WorldMapModel>.Instance.IsNeedCustomizedThumbnail(this.Map.MapId) && flag);
		}

		// Token: 0x060324DF RID: 206047 RVA: 0x00C95CCE File Offset: 0x00C93ECE
		private void OnInputKeyEvent(string keyName, InputDistributeDefine.EActionType actionType, InputIdentification inputIdentification)
		{
			if (keyName == "C")
			{
				this.HandleDebugCopy();
			}
		}

		// Token: 0x060324E0 RID: 206048 RVA: 0x00C95CE4 File Offset: 0x00C93EE4
		[NullableContext(2)]
		private void DebugDrawPosNotify(DebugDrawPosNotify notify, Net.CallbackStatus status)
		{
			TArray<FVector2D> debugMapPath = ModelBase<WorldMapModel>.Instance.GetDebugMapPath();
			debugMapPath.Empty(true);
			Vector2D vector2D = new Vector2D();
			foreach (Aki.Protocol.Vector inV in notify.PosList)
			{
				global::Vector vector = global::Vector.Create(inV);
				MapUtil.WorldPosition2UiPosition2D(Vector2D.Create(vector.X, vector.Y), vector2D);
				debugMapPath.Add(vector2D.ToUeVector2D(false));
			}
			BaseMap map = this.WorldMapUiEntity.Map;
			if (map == null)
			{
				return;
			}
			map.SetDebugPath(debugMapPath);
		}

		// Token: 0x060324E1 RID: 206049 RVA: 0x00C95D84 File Offset: 0x00C93F84
		private void HandleDebugCopy()
		{
			if (ModelBase<WorldMapModel>.Instance.EnableDebug)
			{
				global::Vector lastWorldMapPointerWorldPosition = ModelBase<WorldMapModel>.Instance.LastWorldMapPointerWorldPosition;
				if (lastWorldMapPointerWorldPosition != null)
				{
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(3, 4);
					defaultInterpolatedStringHandler.AppendFormatted<double>(Math.Floor(lastWorldMapPointerWorldPosition.X));
					defaultInterpolatedStringHandler.AppendLiteral(",");
					defaultInterpolatedStringHandler.AppendFormatted<double>(Math.Floor(lastWorldMapPointerWorldPosition.Y));
					defaultInterpolatedStringHandler.AppendLiteral(",");
					defaultInterpolatedStringHandler.AppendFormatted<double>(Math.Floor(lastWorldMapPointerWorldPosition.Z));
					defaultInterpolatedStringHandler.AppendLiteral(",");
					defaultInterpolatedStringHandler.AppendFormatted<int>(ModelBase<WorldMapModel>.Instance.CurrentWorldMapConfigId);
					ULGUIBPLibrary.ClipBoardCopy(defaultInterpolatedStringHandler.ToStringAndClear());
				}
			}
		}

		// Token: 0x060324E2 RID: 206050 RVA: 0x00C95E34 File Offset: 0x00C94034
		[NullableContext(2)]
		private void OpenExtraUi(EWorldMapExtraUiPanelName panelName, object param = null)
		{
			WorldMapUiEntity worldMapUiEntity = this.WorldMapUiEntity;
			if (worldMapUiEntity == null || !worldMapUiEntity.WorldMapExtraUiPanelComponent.IsExtraUiViewOpened)
			{
				this.ExploreInfoItem.SetMapNotesState(false);
				this.HudSequencer.StopCurrentSequence(false, false);
				this.HudSequencer.PlayLevelSequenceByName("Hide", false, null, false);
			}
			WorldMapUiEntity worldMapUiEntity2 = this.WorldMapUiEntity;
			if (worldMapUiEntity2 == null)
			{
				return;
			}
			worldMapUiEntity2.WorldMapExtraUiPanelComponent.OpenUi(panelName, base.GetItem(25), param);
		}

		// Token: 0x060324E3 RID: 206051 RVA: 0x00C95EB1 File Offset: 0x00C940B1
		private void OnExtraUiViewOpened(WorldMapExtraUiPanel panel)
		{
			base.AddChild(panel);
		}

		// Token: 0x060324E4 RID: 206052 RVA: 0x00C95EBC File Offset: 0x00C940BC
		private void OnExtraUiViewClosed()
		{
			WorldMapUiEntity worldMapUiEntity = this.WorldMapUiEntity;
			if (worldMapUiEntity == null || !worldMapUiEntity.WorldMapExtraUiPanelComponent.IsExtraUiViewOpened)
			{
				this.ExploreInfoItem.SetMapNotesState(true);
				this.HudSequencer.StopCurrentSequence(false, false);
				base.GetItem(14).SetUIActive(true);
				Singleton<EventSystem>.Instance.Emit<bool>(EEventName.WorldMapPanelHudVisibleChanged, true);
				this.HudSequencer.PlayLevelSequenceByName("Show", false, null, false);
			}
		}

		// Token: 0x060324E5 RID: 206053 RVA: 0x00C95F38 File Offset: 0x00C94138
		[NullableContext(2)]
		private void EventOpenExtraUiFromMap(EWorldMapExtraUiPanelName panelName, object param = null)
		{
			this.OpenExtraUi(panelName, param);
		}

		// Token: 0x060324E6 RID: 206054 RVA: 0x00C95F42 File Offset: 0x00C94142
		private void EventCloseAllExtraUiFromMap()
		{
			WorldMapUiEntity worldMapUiEntity = this.WorldMapUiEntity;
			if (worldMapUiEntity == null)
			{
				return;
			}
			worldMapUiEntity.WorldMapExtraUiPanelComponent.CloseAllUi();
		}

		// Token: 0x060324E7 RID: 206055 RVA: 0x00C95F59 File Offset: 0x00C94159
		private void SetWorldMapCursorButtonVisible(bool visible)
		{
			this.CursorButton.SetCursorActive(visible);
		}

		// Token: 0x060324EC RID: 206060 RVA: 0x00C96034 File Offset: 0x00C94234
		[CompilerGenerated]
		[return: Nullable(new byte[]
		{
			0,
			0,
			1,
			1
		})]
		internal static UniTask<ValueTuple<MarkItem, UUIItem>> <OnPointerUp>g__getMarkTupleFunc|96_0(MarkItem markItem)
		{
			WorldMapView.<<OnPointerUp>g__getMarkTupleFunc|96_0>d <<OnPointerUp>g__getMarkTupleFunc|96_0>d;
			<<OnPointerUp>g__getMarkTupleFunc|96_0>d.<>t__builder = AsyncUniTaskMethodBuilder<ValueTuple<MarkItem, UUIItem>>.Create();
			<<OnPointerUp>g__getMarkTupleFunc|96_0>d.markItem = markItem;
			<<OnPointerUp>g__getMarkTupleFunc|96_0>d.<>1__state = -1;
			<<OnPointerUp>g__getMarkTupleFunc|96_0>d.<>t__builder.Start<WorldMapView.<<OnPointerUp>g__getMarkTupleFunc|96_0>d>(ref <<OnPointerUp>g__getMarkTupleFunc|96_0>d);
			return <<OnPointerUp>g__getMarkTupleFunc|96_0>d.<>t__builder.Task;
		}

		// Token: 0x060324ED RID: 206061 RVA: 0x00C96078 File Offset: 0x00C94278
		[CompilerGenerated]
		[return: Nullable(new byte[]
		{
			0,
			0,
			1,
			1
		})]
		internal static UniTask<ValueTuple<MarkItem, UUIItem>> <OnCloseSecondaryUiByClickOtherMarkCall>g__getMarkTupleFunc|106_1(MarkItem markItem)
		{
			WorldMapView.<<OnCloseSecondaryUiByClickOtherMarkCall>g__getMarkTupleFunc|106_1>d <<OnCloseSecondaryUiByClickOtherMarkCall>g__getMarkTupleFunc|106_1>d;
			<<OnCloseSecondaryUiByClickOtherMarkCall>g__getMarkTupleFunc|106_1>d.<>t__builder = AsyncUniTaskMethodBuilder<ValueTuple<MarkItem, UUIItem>>.Create();
			<<OnCloseSecondaryUiByClickOtherMarkCall>g__getMarkTupleFunc|106_1>d.markItem = markItem;
			<<OnCloseSecondaryUiByClickOtherMarkCall>g__getMarkTupleFunc|106_1>d.<>1__state = -1;
			<<OnCloseSecondaryUiByClickOtherMarkCall>g__getMarkTupleFunc|106_1>d.<>t__builder.Start<WorldMapView.<<OnCloseSecondaryUiByClickOtherMarkCall>g__getMarkTupleFunc|106_1>d>(ref <<OnCloseSecondaryUiByClickOtherMarkCall>g__getMarkTupleFunc|106_1>d);
			return <<OnCloseSecondaryUiByClickOtherMarkCall>g__getMarkTupleFunc|106_1>d.<>t__builder.Task;
		}

		// Token: 0x0401D63A RID: 120378
		[Nullable(2)]
		protected WorldMapUiEntity WorldMapUiEntity;

		// Token: 0x0401D63B RID: 120379
		[Nullable(2)]
		private BaseMap Map;

		// Token: 0x0401D63C RID: 120380
		[Nullable(2)]
		private UKuroWorldMapUIParams UiParams;

		// Token: 0x0401D63D RID: 120381
		[Nullable(2)]
		private IWorldMapViewOpenParams ShowParams;

		// Token: 0x0401D63E RID: 120382
		private EWorldMapShowMode ShowMode;

		// Token: 0x0401D63F RID: 120383
		[Nullable(2)]
		private MarkItem SequenceMarkItem;

		// Token: 0x0401D640 RID: 120384
		private readonly PowerCurrencyItem PowerCurrencyItem = new PowerCurrencyItem();

		// Token: 0x0401D641 RID: 120385
		private readonly PowerCurrencyItem OverPowerCurrencyItem = new PowerCurrencyItem();

		// Token: 0x0401D642 RID: 120386
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private List<MarkItem> ClickedItems = new List<MarkItem>();

		// Token: 0x0401D643 RID: 120387
		private readonly Vector2D ClickedPosition = new Vector2D();

		// Token: 0x0401D644 RID: 120388
		private LongPressButton ZoomInButton;

		// Token: 0x0401D645 RID: 120389
		private LongPressButton ZoomOutButton;

		// Token: 0x0401D646 RID: 120390
		[Nullable(new byte[]
		{
			0,
			2
		})]
		private ValueTuple<double, MarkItem> MinRangeAndItem = new ValueTuple<double, MarkItem>(0.0, null);

		// Token: 0x0401D647 RID: 120391
		private readonly HandleCursorButton CursorButton = new HandleCursorButton();

		// Token: 0x0401D648 RID: 120392
		private readonly ExploreInfoItem ExploreInfoItem = new ExploreInfoItem();

		// Token: 0x0401D649 RID: 120393
		private readonly WorldMapPeriodicActivityItem WorldMapPeriodicActivityItem = new WorldMapPeriodicActivityItem();

		// Token: 0x0401D64A RID: 120394
		private readonly HonamiMarkSelectPanel HonamiMarkSelectPanel = new HonamiMarkSelectPanel();

		// Token: 0x0401D64B RID: 120395
		private UnderseaOverviewItem UnderseaOverviewItem;

		// Token: 0x0401D64C RID: 120396
		private UUIItem UnLockItem;

		// Token: 0x0401D64D RID: 120397
		private readonly Dictionary<UUIItem, LevelSequencePlayer> ClickItemLevelSequenceMap = new Dictionary<UUIItem, LevelSequencePlayer>();

		// Token: 0x0401D64E RID: 120398
		private MapLifeEventDispatcher LifeEventDispatcher;

		// Token: 0x0401D64F RID: 120399
		private GenericLayout<WorldMapSubMapItem, MultiMap> MultiMapFloorLayout;

		// Token: 0x0401D650 RID: 120400
		private readonly RegionalTerminalBarItem RegionalTerminalBar = new RegionalTerminalBarItem();

		// Token: 0x0401D651 RID: 120401
		private LevelSequencePlayer HudSequencer;

		// Token: 0x0401D652 RID: 120402
		private LevelSequencePlayer UnLockSequence;

		// Token: 0x0401D653 RID: 120403
		private int OpenFogId;

		// Token: 0x0401D654 RID: 120404
		private bool ShowFogEffectInstant;

		// Token: 0x0401D655 RID: 120405
		private bool IsNotNeedUnLockEffect;

		// Token: 0x0401D656 RID: 120406
		private int OpenParamMapId;

		// Token: 0x0401D657 RID: 120407
		private bool IsCloseThenOpenSecondaryUi;

		// Token: 0x0401D658 RID: 120408
		private bool IsWaitNoteAndRecommend;

		// Token: 0x0401D659 RID: 120409
		private WorldMapChangeGravityButtonItem WorldMapChangeGravityButtonItem;

		// Token: 0x0401D65A RID: 120410
		private const int MARKICON_HALFSIZE = 70;

		// Token: 0x0401D65B RID: 120411
		private const int MAX_INT32_NUMBER = 2147483647;

		// Token: 0x0401D65C RID: 120412
		private const int VIEW_PORT_BUFFER_REGION = 400;

		// Token: 0x0401D65D RID: 120413
		private readonly HashSet<EUiViewName> ExtraSecondaryUiViewMap = new HashSet<EUiViewName>
		{
			EUiViewName.PowerView,
			EUiViewName.ExploreProgressView,
			EUiViewName.MapExploreDetailView
		};

		// Token: 0x0200ABF0 RID: 44016
		[NullableContext(0)]
		public static class EMapComponents
		{
			// Token: 0x040357AB RID: 219051
			public const int LeftUi = 0;

			// Token: 0x040357AC RID: 219052
			public const int ScaleSlider = 1;

			// Token: 0x040357AD RID: 219053
			public const int ZoomOut = 2;

			// Token: 0x040357AE RID: 219054
			public const int ZoomIn = 3;

			// Token: 0x040357AF RID: 219055
			public const int FloorSelection = 4;

			// Token: 0x040357B0 RID: 219056
			public const int CloseBtn = 5;

			// Token: 0x040357B1 RID: 219057
			public const int BtnMarkToggle = 6;

			// Token: 0x040357B2 RID: 219058
			public const int SwitchFog = 7;

			// Token: 0x040357B3 RID: 219059
			public const int MarkEdge = 8;

			// Token: 0x040357B4 RID: 219060
			public const int MapRoot = 9;

			// Token: 0x040357B5 RID: 219061
			public const int CurrencyItem = 10;

			// Token: 0x040357B6 RID: 219062
			public const int Cursor = 11;

			// Token: 0x040357B7 RID: 219063
			public const int ParamsItem = 12;

			// Token: 0x040357B8 RID: 219064
			public const int TowerItem = 13;

			// Token: 0x040357B9 RID: 219065
			public const int PanelHud = 14;

			// Token: 0x040357BA RID: 219066
			public const int MultiMapFloorLayout = 15;

			// Token: 0x040357BB RID: 219067
			public const int MultiMapFloorContainer = 16;

			// Token: 0x040357BC RID: 219068
			public const int MapChangeBtn = 17;

			// Token: 0x040357BD RID: 219069
			public const int TxtCountryName = 18;

			// Token: 0x040357BE RID: 219070
			public const int BtnGravityChange = 19;

			// Token: 0x040357BF RID: 219071
			public const int InverseTowerCtrl = 20;

			// Token: 0x040357C0 RID: 219072
			public const int DebugTxt = 21;

			// Token: 0x040357C1 RID: 219073
			public const int UnderseaOverview = 22;

			// Token: 0x040357C2 RID: 219074
			public const int ExploreInfoItem = 23;

			// Token: 0x040357C3 RID: 219075
			public const int BarTerminal = 24;

			// Token: 0x040357C4 RID: 219076
			public const int PanelContent = 25;
		}
	}
}
