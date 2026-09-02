using System;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.AutoPilot;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.Map.Marks.MarkItem;
using CSharpScript.Game.Module.Map.Marks.MarkItemView;
using CSharpScript.Game.Module.Map.Marks.MarkItemView.Components;
using CSharpScript.Game.Module.Map.View.BaseMap.Assistant;
using CSharpScript.Game.Module.Map.View.BaseMap.Assistant.MapTile;
using CSharpScript.Game.Module.Map.View.SubView;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Map.View.BaseMap
{
	// Token: 0x020057ED RID: 22509
	[NullableContext(1)]
	[Nullable(0)]
	public class BaseMap : UiPanelBase
	{
		// Token: 0x170091DA RID: 37338
		// (get) Token: 0x060393C5 RID: 234437 RVA: 0x00E84949 File Offset: 0x00E82B49
		// (set) Token: 0x060393C6 RID: 234438 RVA: 0x00E84951 File Offset: 0x00E82B51
		public int MapId { get; set; }

		// Token: 0x170091DB RID: 37339
		// (get) Token: 0x060393C7 RID: 234439 RVA: 0x00E8495A File Offset: 0x00E82B5A
		// (set) Token: 0x060393C8 RID: 234440 RVA: 0x00E84962 File Offset: 0x00E82B62
		public int InstanceDungeonId { get; set; }

		// Token: 0x170091DC RID: 37340
		// (get) Token: 0x060393C9 RID: 234441 RVA: 0x00E8496B File Offset: 0x00E82B6B
		public MapRangePanel MapRangePanel
		{
			get
			{
				return this.MapRangePanelInner;
			}
		}

		// Token: 0x170091DD RID: 37341
		// (get) Token: 0x060393CA RID: 234442 RVA: 0x00E84973 File Offset: 0x00E82B73
		// (set) Token: 0x060393CB RID: 234443 RVA: 0x00E8497B File Offset: 0x00E82B7B
		public AutoPilotLine AutoPilotLine { get; private set; }

		// Token: 0x170091DE RID: 37342
		// (get) Token: 0x060393CC RID: 234444 RVA: 0x00E84984 File Offset: 0x00E82B84
		public UUIItem MapRootItem
		{
			get
			{
				return this.RootItem;
			}
		}

		// Token: 0x170091DF RID: 37343
		// (get) Token: 0x060393CD RID: 234445 RVA: 0x00E8498C File Offset: 0x00E82B8C
		public EMapGravityDirection MapGravity
		{
			get
			{
				return this.MapGravityInternal;
			}
		}

		// Token: 0x060393CE RID: 234446 RVA: 0x00E84994 File Offset: 0x00E82B94
		public BaseMap(MapConstructorParams mapParams)
		{
			this.InstanceDungeonId = mapParams.InstanceId;
			this.MapId = ModelBase<MapModel>.Instance.GetDungeonWorldMapConfigId(mapParams.InstanceId);
			this.MapType = mapParams.MapType;
			this.MapDefaultScale = mapParams.MapDefaultScale;
			this.MarkScale = mapParams.MarkScale.GetValueOrDefault(1f);
			this.ClickRange = mapParams.ClickRange.GetValueOrDefault(100f);
			this.PreloadTiles = mapParams.PreloadTiles;
			this.MapGravityInternal = mapParams.Gravity.GetValueOrDefault(EMapGravityDirection.Down);
		}

		// Token: 0x060393CF RID: 234447 RVA: 0x00E84A5C File Offset: 0x00E82C5C
		public void Tick()
		{
			MapMarkMgr mapMarkMgr = this.MapMarkMgr;
			if (mapMarkMgr == null)
			{
				return;
			}
			mapMarkMgr.Tick();
		}

		// Token: 0x060393D0 RID: 234448 RVA: 0x00E84A70 File Offset: 0x00E82C70
		public UniTask ChangeMapAsync(int mapId, EMapGravityDirection gravity)
		{
			BaseMap.<ChangeMapAsync>d__37 <ChangeMapAsync>d__;
			<ChangeMapAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ChangeMapAsync>d__.<>4__this = this;
			<ChangeMapAsync>d__.mapId = mapId;
			<ChangeMapAsync>d__.gravity = gravity;
			<ChangeMapAsync>d__.<>1__state = -1;
			<ChangeMapAsync>d__.<>t__builder.Start<BaseMap.<ChangeMapAsync>d__37>(ref <ChangeMapAsync>d__);
			return <ChangeMapAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060393D1 RID: 234449 RVA: 0x00E84AC4 File Offset: 0x00E82CC4
		protected override void OnBeforeDestroy()
		{
			this.UnBindEvents();
			MarkGravityReverseIconComponent playerMapGravityComponent = this.PlayerMapGravityComponent;
			if (playerMapGravityComponent != null)
			{
				playerMapGravityComponent.RecycleToPool();
			}
			this.PlayerMapGravityComponent = null;
			MapMarkMgr mapMarkMgr = this.MapMarkMgr;
			if (mapMarkMgr != null)
			{
				mapMarkMgr.Dispose();
			}
			this.MapMarkMgr = null;
			MapTileMgr mapTileMgr = this.MapTileMgr;
			if (mapTileMgr != null)
			{
				mapTileMgr.Dispose();
			}
			this.MapTileMgr = null;
			MapRangePanel mapRangePanelInner = this.MapRangePanelInner;
			if (mapRangePanelInner != null)
			{
				mapRangePanelInner.Destroy();
			}
			this.MapRangePanelInner = null;
			AutoPilotLine autoPilotLine = this.AutoPilotLine;
			if (autoPilotLine != null)
			{
				autoPilotLine.Destroy();
			}
			this.AutoPilotLine = null;
			MapRoadWaysMgr mapRoadWaysMgr = this.MapRoadWaysMgr;
			if (mapRoadWaysMgr != null)
			{
				mapRoadWaysMgr.Dispose();
			}
			this.MapRoadWaysMgr = null;
		}

		// Token: 0x060393D2 RID: 234450 RVA: 0x00E84B68 File Offset: 0x00E82D68
		protected unsafe override void OnRegisterComponent()
		{
			int num = 14;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x060393D3 RID: 234451 RVA: 0x00E84D64 File Offset: 0x00E82F64
		protected override UniTask OnBeforeStartAsync()
		{
			BaseMap.<OnBeforeStartAsync>d__40 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<BaseMap.<OnBeforeStartAsync>d__40>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060393D4 RID: 234452 RVA: 0x00E84DA8 File Offset: 0x00E82FA8
		protected override void OnStart()
		{
			this.PlayerOutOfBoundIndicator = base.GetItem(2);
			this.PlayerArrow = base.GetItem(1);
			this.RootItem.SetHierarchyIndex(0);
			UUIItem item = base.GetItem(6);
			if (item != null)
			{
				item.SetWidth(this.ClickRange * 2f);
			}
			if (item != null)
			{
				item.SetHeight(this.ClickRange * 2f);
			}
			if (item != null)
			{
				item.SetUIActive(false);
			}
			this.RangeItemLevelSequencePlayer = new LevelSequencePlayer(item);
			this.MapRangePanelInner = new MapRangePanel(this);
			this.MapRangePanelInner.CheckExploreMarkRangeInfo();
			this.AutoPilotLine = new AutoPilotLine(this);
			this.AutoPilotLine.CheckAutoPilotLineInfo();
		}

		// Token: 0x060393D5 RID: 234453 RVA: 0x00E84E5C File Offset: 0x00E8305C
		private void InitAssistants(float markScale)
		{
			UUIItem item = base.GetItem(3);
			UUIItem item2 = base.GetItem(4);
			UUITexture texture = base.GetTexture(5);
			if (Singleton<BaseMapStatic>.Instance.MapMaterialVersion == 2)
			{
				texture = base.GetTexture(9);
			}
			UUIItem item3 = base.GetItem(7);
			UUITexture texture2 = base.GetTexture(8);
			MapMarkMgrParams param = new MapMarkMgrParams
			{
				MapType = this.MapType,
				MapId = this.MapId,
				InstanceDungeonId = this.InstanceDungeonId,
				MarkContainer = item,
				MarkScale = markScale,
				Gravity = new EMapGravityDirection?(this.MapGravityInternal)
			};
			this.MapMarkMgr = new MapMarkMgr(param);
			this.MapMarkMgr.Initialize();
			UUIItem item4 = base.GetItem(10);
			MapTileMgrParams tileMgrParams = new MapTileMgrParams
			{
				MapRootItem = this.RootItem,
				TileContainer = item2,
				TileTexture = texture,
				SubMapContainer = item3,
				SubMapTexture = texture2,
				MapType = this.MapType,
				MapId = this.MapId,
				InstanceDungeonId = this.InstanceDungeonId,
				MapVersion = Singleton<BaseMapStatic>.Instance.MapMaterialVersion,
				PreloadTiles = this.PreloadTiles,
				FogUnlockItem = item4,
				Gravity = new EMapGravityDirection?(this.MapGravityInternal)
			};
			this.MapTileMgr = new MapTileMgr(tileMgrParams);
			this.MapTileMgr.Initialize();
			this.MapRoadWaysMgr = new MapRoadWaysMgr(new MapRoadWaysMgrParams
			{
				MapId = this.MapId,
				InstanceDungeonId = this.InstanceDungeonId,
				Container = base.GetItem(13)
			});
		}

		// Token: 0x170091E0 RID: 37344
		// (get) Token: 0x060393D6 RID: 234454 RVA: 0x00E84FEB File Offset: 0x00E831EB
		public UUIItem MarkContainer
		{
			get
			{
				return base.GetItem(3);
			}
		}

		// Token: 0x170091E1 RID: 37345
		// (get) Token: 0x060393D7 RID: 234455 RVA: 0x00E84FF4 File Offset: 0x00E831F4
		public UUIItem FogUnlockAnchorItem
		{
			get
			{
				return base.GetItem(10);
			}
		}

		// Token: 0x060393D8 RID: 234456 RVA: 0x00E84FFE File Offset: 0x00E831FE
		private void BindEvents()
		{
			if (this.MapType == EMapType.WorldMap)
			{
				return;
			}
			if (ModelBase<GameModeModel>.Instance.WorldDone)
			{
				this.SetUp();
				return;
			}
			Singleton<EventSystem>.Instance.Add(EEventName.WorldDone, new Action(this.SetUp));
		}

		// Token: 0x060393D9 RID: 234457 RVA: 0x00E8503C File Offset: 0x00E8323C
		protected void UnBindEvents()
		{
			if (this.MapType == EMapType.WorldMap)
			{
				return;
			}
			if (Singleton<EventSystem>.Instance.Has(EEventName.WorldDone, new Action(this.SetUp)))
			{
				Singleton<EventSystem>.Instance.Remove(EEventName.WorldDone, new Action(this.SetUp));
			}
		}

		// Token: 0x060393DA RID: 234458 RVA: 0x00E8508C File Offset: 0x00E8328C
		private void SetUp()
		{
			MapTileMgr mapTileMgr = this.MapTileMgr;
			if (mapTileMgr != null)
			{
				mapTileMgr.OnMapSetUp();
			}
			MapTileMgr mapTileMgr2 = this.MapTileMgr;
			if (mapTileMgr2 != null)
			{
				mapTileMgr2.LoadMapBorder().Forget();
			}
			MapMarkMgr mapMarkMgr = this.MapMarkMgr;
			if (mapMarkMgr != null)
			{
				mapMarkMgr.OnMapSetup(null);
			}
			MapRoadWaysMgr mapRoadWaysMgr = this.MapRoadWaysMgr;
			if (mapRoadWaysMgr != null)
			{
				mapRoadWaysMgr.OnMapSetup();
			}
			UUIItem rootItem = this.RootItem;
			if (rootItem == null)
			{
				return;
			}
			rootItem.SetUIActive(true);
		}

		// Token: 0x060393DB RID: 234459 RVA: 0x00E850FC File Offset: 0x00E832FC
		private UniTask SetUpWorldMapAsync()
		{
			BaseMap.<SetUpWorldMapAsync>d__50 <SetUpWorldMapAsync>d__;
			<SetUpWorldMapAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<SetUpWorldMapAsync>d__.<>4__this = this;
			<SetUpWorldMapAsync>d__.<>1__state = -1;
			<SetUpWorldMapAsync>d__.<>t__builder.Start<BaseMap.<SetUpWorldMapAsync>d__50>(ref <SetUpWorldMapAsync>d__);
			return <SetUpWorldMapAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060393DC RID: 234460 RVA: 0x00E8513F File Offset: 0x00E8333F
		public Dictionary<EMarkType, Dictionary<int, MarkItem>> GetAllMarkItems()
		{
			return this.MapMarkMgr.GetAllMarkItems();
		}

		// Token: 0x060393DD RID: 234461 RVA: 0x00E8514C File Offset: 0x00E8334C
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public Dictionary<int, MarkItem> GetMarkItemsByType(EMarkType markType, bool withCrossMap = true)
		{
			return this.MapMarkMgr.GetMarkItemsByType(markType, withCrossMap);
		}

		// Token: 0x060393DE RID: 234462 RVA: 0x00E8515B File Offset: 0x00E8335B
		public List<MarkItem> GetMarkItemsByClickPosition(Vector clickPosition, int cellRadius = 1)
		{
			return this.MapMarkMgr.GetMarkItemsByClickPosition(clickPosition, cellRadius);
		}

		// Token: 0x060393DF RID: 234463 RVA: 0x00E8516A File Offset: 0x00E8336A
		[NullableContext(2)]
		public MarkItem GetMarkItem(EMarkType markType, int markId)
		{
			return this.MapMarkMgr.GetMarkItem(markType, markId);
		}

		// Token: 0x060393E0 RID: 234464 RVA: 0x00E85179 File Offset: 0x00E83379
		public CustomMarkItem CreateCustomMark(DynamicMarkCreateInfo info)
		{
			return this.MapMarkMgr.CreateDynamicMark(info, true) as CustomMarkItem;
		}

		// Token: 0x060393E1 RID: 234465 RVA: 0x00E8518D File Offset: 0x00E8338D
		[return: Nullable(new byte[]
		{
			1,
			0,
			1
		})]
		public List<ValueTuple<MarkItem, double>> FindNearbyMarkItems(MarkItem markItem, float searchRadius, TFilterMarkFunction filterFunction = null)
		{
			return this.MapMarkMgr.FindNearbyMarkItems(markItem, searchRadius, filterFunction);
		}

		// Token: 0x060393E2 RID: 234466 RVA: 0x00E8519D File Offset: 0x00E8339D
		public List<MarkItem> GetTrackMenuMarkList()
		{
			return this.MapMarkMgr.GetTrackMenuMarkList();
		}

		// Token: 0x060393E3 RID: 234467 RVA: 0x00E851AA File Offset: 0x00E833AA
		public List<MarkItem> GetNavigateMarkList()
		{
			return this.MapMarkMgr.GetNavigateMarkList();
		}

		// Token: 0x170091E2 RID: 37346
		// (get) Token: 0x060393E4 RID: 234468 RVA: 0x00E851B7 File Offset: 0x00E833B7
		public Vector4? MapOffset
		{
			get
			{
				return new Vector4?(this.MapTileMgr.MapOffset);
			}
		}

		// Token: 0x170091E3 RID: 37347
		// (get) Token: 0x060393E5 RID: 234469 RVA: 0x00E851C9 File Offset: 0x00E833C9
		public float FakeOffset
		{
			get
			{
				return this.MapTileMgr.FakeOffset;
			}
		}

		// Token: 0x060393E6 RID: 234470 RVA: 0x00E851D6 File Offset: 0x00E833D6
		public void ShowSubMapTile(int groupId, int layer, bool fastTween = false)
		{
			MapTileMgr mapTileMgr = this.MapTileMgr;
			if (mapTileMgr == null)
			{
				return;
			}
			mapTileMgr.ShowSubMapByPosition(groupId, layer, fastTween);
		}

		// Token: 0x060393E7 RID: 234471 RVA: 0x00E851EB File Offset: 0x00E833EB
		public void HideSubMapTile()
		{
			MapTileMgr mapTileMgr = this.MapTileMgr;
			if (mapTileMgr == null)
			{
				return;
			}
			mapTileMgr.HideSubMap();
		}

		// Token: 0x060393E8 RID: 234472 RVA: 0x00E851FD File Offset: 0x00E833FD
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public List<MapTileItem> GetAllMapTileItems()
		{
			MapTileMgr mapTileMgr = this.MapTileMgr;
			if (mapTileMgr == null)
			{
				return null;
			}
			return mapTileMgr.GetMapTileItems();
		}

		// Token: 0x060393E9 RID: 234473 RVA: 0x00E85210 File Offset: 0x00E83410
		[NullableContext(2)]
		public Vector GetWorldMapCenterPosition()
		{
			MapTileMgr mapTileMgr = this.MapTileMgr;
			if (mapTileMgr == null)
			{
				return null;
			}
			return mapTileMgr.GetWorldMapCenterPosition();
		}

		// Token: 0x060393EA RID: 234474 RVA: 0x00E85223 File Offset: 0x00E83423
		public int GetMultiMapAreaIdByPosition(Vector position)
		{
			MapTileMgr mapTileMgr = this.MapTileMgr;
			if (mapTileMgr == null)
			{
				return 0;
			}
			return mapTileMgr.GetMultiMapAreaIdByPosition(position);
		}

		// Token: 0x060393EB RID: 234475 RVA: 0x00E85237 File Offset: 0x00E83437
		public int GetSubMapGroupByPosition(Vector position)
		{
			MapTileMgr mapTileMgr = this.MapTileMgr;
			if (mapTileMgr == null)
			{
				return 0;
			}
			return mapTileMgr.GetSubMapGroupByPosition(position);
		}

		// Token: 0x060393EC RID: 234476 RVA: 0x00E8524C File Offset: 0x00E8344C
		public int GetWorldMapCenterAreaId()
		{
			Vector worldMapCenterPosition = this.MapTileMgr.GetWorldMapCenterPosition();
			if (worldMapCenterPosition == null)
			{
				return 0;
			}
			return this.MapTileMgr.GetMultiMapAreaIdByPosition(worldMapCenterPosition);
		}

		// Token: 0x060393ED RID: 234477 RVA: 0x00E85276 File Offset: 0x00E83476
		public void UpdateCurrentAreaMapGroupId(Vector position)
		{
			MapTileMgr mapTileMgr = this.MapTileMgr;
			if (mapTileMgr == null)
			{
				return;
			}
			mapTileMgr.UpdateCurrentAreaMapGroupId(position);
		}

		// Token: 0x060393EE RID: 234478 RVA: 0x00E8528C File Offset: 0x00E8348C
		public void SetMapScale(float scale)
		{
			UUIItem rootItem = this.RootItem;
			if (rootItem == null)
			{
				return;
			}
			FVector fvector = new FVector(scale, scale, scale);
			rootItem.SetUIRelativeScale3D(fvector);
		}

		// Token: 0x060393EF RID: 234479 RVA: 0x00E852B4 File Offset: 0x00E834B4
		public void HandleFogAreaOpen(int fogId)
		{
			MapTileMgr mapTileMgr = this.MapTileMgr;
			if (mapTileMgr == null)
			{
				return;
			}
			mapTileMgr.HandleFogAreaOpen(fogId);
		}

		// Token: 0x060393F0 RID: 234480 RVA: 0x00E852C7 File Offset: 0x00E834C7
		public void HandleMapTileDelegate()
		{
			MapTileMgr mapTileMgr = this.MapTileMgr;
			if (mapTileMgr == null)
			{
				return;
			}
			mapTileMgr.HandleDelegate();
		}

		// Token: 0x060393F1 RID: 234481 RVA: 0x00E852D9 File Offset: 0x00E834D9
		public void UnBindMapTileDelegate()
		{
			MapTileMgr mapTileMgr = this.MapTileMgr;
			if (mapTileMgr == null)
			{
				return;
			}
			mapTileMgr.UnBindDelegate();
		}

		// Token: 0x060393F2 RID: 234482 RVA: 0x00E852EC File Offset: 0x00E834EC
		public void HandleSceneGamePlayMarkItemOpen(EMarkType markType, int relativeType, int subRelativeType)
		{
			Dictionary<int, MarkItem> markItemsByType = this.GetMarkItemsByType(markType, true);
			if (markItemsByType == null)
			{
				return;
			}
			foreach (KeyValuePair<int, MarkItem> keyValuePair in markItemsByType)
			{
				MarkItem markItem = keyValuePair.Value;
				ConfigMarkItem configMarkItem = markItem as ConfigMarkItem;
				if (configMarkItem != null && configMarkItem.MarkConfig != null && configMarkItem.MarkConfig.Value.RelativeSubType == subRelativeType)
				{
					markItem.IsCanShowView = true;
					markItem.ViewUpdateAsync(Singleton<GeneralLogicTreeUtil>.Instance.GetPlayerLocation(), false, false).ContinueWith(delegate()
					{
						MarkItemView view = markItem.View;
						if (view == null)
						{
							return;
						}
						view.PlayUnlockSequence().Forget();
					}).Forget();
				}
			}
		}

		// Token: 0x060393F3 RID: 234483 RVA: 0x00E853CC File Offset: 0x00E835CC
		[NullableContext(2)]
		public void SetClickRangeVisible(bool visible, Vector2D clickUiPosition = null)
		{
			if (clickUiPosition == null)
			{
				clickUiPosition = Vector2D.Create(0.0, 0.0);
			}
			this.PlaySequenceAndSetActive(visible, clickUiPosition).Forget<bool>();
		}

		// Token: 0x060393F4 RID: 234484 RVA: 0x00E853F8 File Offset: 0x00E835F8
		[NullableContext(0)]
		private UniTask<bool> PlaySequenceAndSetActive(bool bActive, [Nullable(1)] Vector2D clickUiPosition)
		{
			BaseMap.<PlaySequenceAndSetActive>d__77 <PlaySequenceAndSetActive>d__;
			<PlaySequenceAndSetActive>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<PlaySequenceAndSetActive>d__.<>4__this = this;
			<PlaySequenceAndSetActive>d__.bActive = bActive;
			<PlaySequenceAndSetActive>d__.clickUiPosition = clickUiPosition;
			<PlaySequenceAndSetActive>d__.<>1__state = -1;
			<PlaySequenceAndSetActive>d__.<>t__builder.Start<BaseMap.<PlaySequenceAndSetActive>d__77>(ref <PlaySequenceAndSetActive>d__);
			return <PlaySequenceAndSetActive>d__.<>t__builder.Task;
		}

		// Token: 0x060393F5 RID: 234485 RVA: 0x00E8544B File Offset: 0x00E8364B
		public bool InValidMapTile(Vector worldPosition)
		{
			MapTileMgr mapTileMgr = this.MapTileMgr;
			return mapTileMgr != null && mapTileMgr.InValidTile(worldPosition);
		}

		// Token: 0x060393F6 RID: 234486 RVA: 0x00E8545F File Offset: 0x00E8365F
		public void UpdateDraggableParams(ITileNum tileNum)
		{
			MapTileMgr mapTileMgr = this.MapTileMgr;
			if (mapTileMgr == null)
			{
				return;
			}
			mapTileMgr.UpdateDraggableParams(tileNum);
		}

		// Token: 0x060393F7 RID: 234487 RVA: 0x00E85472 File Offset: 0x00E83672
		public void ResetDraggableParams()
		{
			MapTileMgr mapTileMgr = this.MapTileMgr;
			if (mapTileMgr == null)
			{
				return;
			}
			mapTileMgr.ResetDraggableParams();
		}

		// Token: 0x060393F8 RID: 234488 RVA: 0x00E85484 File Offset: 0x00E83684
		public void SetPlayerGravityActive(bool active, EMapGravityDirection gravity = EMapGravityDirection.Down)
		{
			if (gravity != EMapGravityDirection.Down)
			{
				this.PlayerMapGravityComponent.Gravity = gravity;
			}
			MarkGravityReverseIconComponent playerMapGravityComponent = this.PlayerMapGravityComponent;
			if (playerMapGravityComponent == null)
			{
				return;
			}
			playerMapGravityComponent.SetActive(active);
		}

		// Token: 0x060393F9 RID: 234489 RVA: 0x00E854A7 File Offset: 0x00E836A7
		public void SetDebugMarkPosition(Vector2D position)
		{
			UUIItem item = base.GetItem(11);
			if (item != null)
			{
				item.SetAsLastHierarchy();
			}
			if (item != null)
			{
				item.SetUIActive(true);
			}
			if (item == null)
			{
				return;
			}
			item.SetAnchorOffset(position.ToUeVector2D(false));
		}

		// Token: 0x060393FA RID: 234490 RVA: 0x00E854DC File Offset: 0x00E836DC
		public void SetDebugPath(TArray<FVector2D> debugPath)
		{
			UUIItem item = base.GetItem(12);
			if (item != null)
			{
				item.SetUIActive(true);
			}
			object obj;
			if (item == null)
			{
				obj = null;
			}
			else
			{
				AActor owner = item.GetOwner();
				obj = ((owner != null) ? owner.GetComponentByClass(UUI2DLineRaw.StaticClass()) : null);
			}
			UUI2DLineRaw uui2DLineRaw = obj as UUI2DLineRaw;
			if (uui2DLineRaw == null)
			{
				return;
			}
			uui2DLineRaw.SetPoints(debugPath, false);
		}

		// Token: 0x060393FB RID: 234491 RVA: 0x00E85532 File Offset: 0x00E83732
		public void SetMarkUnFocal(EMarkType markType, int markId)
		{
			MapMarkMgr mapMarkMgr = this.MapMarkMgr;
			if (mapMarkMgr == null)
			{
				return;
			}
			mapMarkMgr.RefreshMarkRenderOrderBySelect(markType, markId, false);
		}

		// Token: 0x060393FC RID: 234492 RVA: 0x00E85547 File Offset: 0x00E83747
		public void SetMarkFocal(EMarkType markType, int markId)
		{
			MapMarkMgr mapMarkMgr = this.MapMarkMgr;
			if (mapMarkMgr == null)
			{
				return;
			}
			mapMarkMgr.RefreshMarkRenderOrderBySelect(markType, markId, true);
		}

		// Token: 0x060393FD RID: 234493 RVA: 0x00E8555C File Offset: 0x00E8375C
		[return: Nullable(new byte[]
		{
			2,
			0,
			1
		})]
		public List<ValueTuple<MarkItem, double>> FindNearbyMarkItemsByPosition(Vector position, float searchRadius, [Nullable(new byte[]
		{
			2,
			1
		})] Func<MarkItem, bool> filterFunction = null)
		{
			MapMarkMgr mapMarkMgr = this.MapMarkMgr;
			if (mapMarkMgr == null)
			{
				return null;
			}
			MapMarkContainer mapMarkContainer = mapMarkMgr.MapMarkContainer;
			if (mapMarkContainer == null)
			{
				return null;
			}
			return mapMarkContainer.FindNearbyMarkItemsByPosition(position, searchRadius, filterFunction);
		}

		// Token: 0x040208BA RID: 133306
		public UUIItem SelfPlayerNode;

		// Token: 0x040208BB RID: 133307
		public UUIItem PlayerArrow;

		// Token: 0x040208BC RID: 133308
		public UUIItem PlayerOutOfBoundIndicator;

		// Token: 0x040208BD RID: 133309
		public EMapType MapType = EMapType.WorldMap;

		// Token: 0x040208BE RID: 133310
		private readonly float MapDefaultScale = 1f;

		// Token: 0x040208BF RID: 133311
		private readonly float MarkScale = 1f;

		// Token: 0x040208C0 RID: 133312
		private MapMarkMgr MapMarkMgr;

		// Token: 0x040208C1 RID: 133313
		public MapTileMgr MapTileMgr;

		// Token: 0x040208C2 RID: 133314
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private Dictionary<string, UTexture> PreloadTiles;

		// Token: 0x040208C3 RID: 133315
		private readonly float ClickRange = 100f;

		// Token: 0x040208C4 RID: 133316
		private LevelSequencePlayer RangeItemLevelSequencePlayer;

		// Token: 0x040208C5 RID: 133317
		private bool LogicUiActive;

		// Token: 0x040208C8 RID: 133320
		private MapRangePanel MapRangePanelInner;

		// Token: 0x040208CA RID: 133322
		private EMapGravityDirection MapGravityInternal;

		// Token: 0x040208CB RID: 133323
		[Nullable(2)]
		private MarkGravityReverseIconComponent PlayerMapGravityComponent;

		// Token: 0x040208CC RID: 133324
		[Nullable(2)]
		private MapRoadWaysMgr MapRoadWaysMgr;

		// Token: 0x0200B86C RID: 47212
		[NullableContext(0)]
		public static class EChildComponentType
		{
			// Token: 0x04039094 RID: 233620
			public const int Player = 0;

			// Token: 0x04039095 RID: 233621
			public const int PlayerArrow = 1;

			// Token: 0x04039096 RID: 233622
			public const int PlayerOutOfBoundIndicator = 2;

			// Token: 0x04039097 RID: 233623
			public const int MarkRoot = 3;

			// Token: 0x04039098 RID: 233624
			public const int TileContainer = 4;

			// Token: 0x04039099 RID: 233625
			public const int TileTexture = 5;

			// Token: 0x0403909A RID: 233626
			public const int ClickRangePrompt = 6;

			// Token: 0x0403909B RID: 233627
			public const int SubMapMaskItem = 7;

			// Token: 0x0403909C RID: 233628
			public const int SubMapTileItem = 8;

			// Token: 0x0403909D RID: 233629
			public const int TileTextureV2 = 9;

			// Token: 0x0403909E RID: 233630
			public const int FogUnlockAnchorItem = 10;

			// Token: 0x0403909F RID: 233631
			public const int DebugMark = 11;

			// Token: 0x040390A0 RID: 233632
			public const int DebugPath = 12;

			// Token: 0x040390A1 RID: 233633
			public const int RoadWayContainer = 13;
		}
	}
}
