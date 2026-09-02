using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.AutoPilot;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.Map.Mark;
using CSharpScript.Game.Module.Map.Marks.MarkItem;
using CSharpScript.Game.Module.Map.Marks.MarkItemView;
using CSharpScript.Game.Module.Map.View.BaseMap.Assistant;
using CSharpScript.Game.Module.Map.View.SubView;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Map.View.BaseMap
{
	// Token: 0x020057EF RID: 22511
	[NullableContext(1)]
	[Nullable(0)]
	public class MiniMap : UiPanelBase
	{
		// Token: 0x170091E4 RID: 37348
		// (get) Token: 0x06039400 RID: 234496 RVA: 0x00E855D2 File Offset: 0x00E837D2
		// (set) Token: 0x06039401 RID: 234497 RVA: 0x00E855DA File Offset: 0x00E837DA
		public int MapId { get; set; }

		// Token: 0x170091E5 RID: 37349
		// (get) Token: 0x06039402 RID: 234498 RVA: 0x00E855E3 File Offset: 0x00E837E3
		// (set) Token: 0x06039403 RID: 234499 RVA: 0x00E855EB File Offset: 0x00E837EB
		public int InstanceDungeonId { get; set; }

		// Token: 0x170091E6 RID: 37350
		// (get) Token: 0x06039404 RID: 234500 RVA: 0x00E855F4 File Offset: 0x00E837F4
		public EMapGravityDirection MapGravity
		{
			get
			{
				return ModelBase<MapModel>.Instance.CurrentPlayerGravity;
			}
		}

		// Token: 0x06039405 RID: 234501 RVA: 0x00E85600 File Offset: 0x00E83800
		public MiniMap(EMapType mapType, int instanceId, float mapDefaultScale, float? markScale = null, Dictionary<string, UTexture> preloadTiles = null)
		{
			this.MapType = mapType;
			this.InstanceDungeonId = instanceId;
			this.MapId = ModelBase<MapModel>.Instance.GetDungeonMapConfigId(instanceId);
			this.MapDefaultScale = mapDefaultScale;
			this.MarkScale = markScale.GetValueOrDefault(1f);
			this.PreloadTiles = preloadTiles;
		}

		// Token: 0x06039406 RID: 234502 RVA: 0x00E85680 File Offset: 0x00E83880
		protected override void OnBeforeDestroy()
		{
			this.UnBindEvents();
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
			this.MapSoundBoxSfxMgr = null;
			MapRangePanel mapRangePanel = this.MapRangePanel;
			if (mapRangePanel != null)
			{
				mapRangePanel.Destroy();
			}
			this.MapRangePanel = null;
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

		// Token: 0x06039407 RID: 234503 RVA: 0x00E85714 File Offset: 0x00E83914
		protected unsafe override void OnRegisterComponent()
		{
			int num = 8;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06039408 RID: 234504 RVA: 0x00E85844 File Offset: 0x00E83A44
		protected override void OnStart()
		{
			this.SetMapScale(this.MapDefaultScale);
			this.InitAssistants(this.MarkScale);
			this.BindEvents();
			this.RootItem.SetUIActive(false);
			this.RootItem.SetHierarchyIndex(0);
			this.MapRangePanel = new MapRangePanel(this);
			this.MapRangePanel.CheckExploreMarkRangeInfo();
			this.AutoPilotLine = new AutoPilotLine(this);
			AutoPilotLine autoPilotLine = this.AutoPilotLine;
			if (autoPilotLine == null)
			{
				return;
			}
			autoPilotLine.CheckAutoPilotLineInfo();
		}

		// Token: 0x06039409 RID: 234505 RVA: 0x00E858C4 File Offset: 0x00E83AC4
		private void InitAssistants(float markScale)
		{
			UUIItem item = base.GetItem(0);
			UUIItem item2 = base.GetItem(1);
			UUITexture texture = base.GetTexture(2);
			UUIItem item3 = base.GetItem(3);
			UUITexture texture2 = base.GetTexture(4);
			texture.SetUIActive(false);
			if (Singleton<MiniMapStatic>.Instance.MapMaterialVersion == 2)
			{
				texture = base.GetTexture(6);
				if (texture != null)
				{
					texture.SetUIActive(false);
				}
			}
			UUIItem item4 = base.GetItem(5);
			MapMarkMgrParams param = new MapMarkMgrParams
			{
				MapType = this.MapType,
				MapId = this.MapId,
				InstanceDungeonId = this.InstanceDungeonId,
				MarkContainer = item,
				MarkScale = markScale
			};
			this.MapMarkMgr = new MapMarkMgr(param);
			this.MapMarkMgr.Initialize();
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
				MapVersion = Singleton<MiniMapStatic>.Instance.MapMaterialVersion,
				PreloadTiles = this.PreloadTiles,
				SubMapMask = item4
			};
			this.MapTileMgr = new MapTileMgr(tileMgrParams);
			this.MapTileMgr.Initialize();
			this.MapSoundBoxSfxMgr = new MapSoundBoxSfxMgr();
			this.MapRoadWaysMgr = new MapRoadWaysMgr(new MapRoadWaysMgrParams
			{
				MapId = this.MapId,
				InstanceDungeonId = this.InstanceDungeonId,
				Container = base.GetItem(7)
			});
		}

		// Token: 0x0603940A RID: 234506 RVA: 0x00E85A4A File Offset: 0x00E83C4A
		private void BindEvents()
		{
			if (ModelBase<GameModeModel>.Instance.WorldDone)
			{
				this.SetUp();
				return;
			}
			Singleton<EventSystem>.Instance.Add(EEventName.WorldDone, new Action(this.SetUp));
		}

		// Token: 0x0603940B RID: 234507 RVA: 0x00E85A7B File Offset: 0x00E83C7B
		protected void UnBindEvents()
		{
			if (Singleton<EventSystem>.Instance.Has(EEventName.WorldDone, new Action(this.SetUp)))
			{
				Singleton<EventSystem>.Instance.Remove(EEventName.WorldDone, new Action(this.SetUp));
			}
		}

		// Token: 0x0603940C RID: 234508 RVA: 0x00E85AB8 File Offset: 0x00E83CB8
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

		// Token: 0x0603940D RID: 234509 RVA: 0x00E85B28 File Offset: 0x00E83D28
		public void MiniMapUpdateMarkItems(Vector2D anchorOffset, float realScale, Vector playerLocation)
		{
			MiniMap.<>c__DisplayClass31_0 CS$<>8__locals1 = new MiniMap.<>c__DisplayClass31_0();
			CS$<>8__locals1.playerLocation = playerLocation;
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.realScale = realScale;
			CS$<>8__locals1.anchorOffset = anchorOffset;
			MapMarkMgr mapMarkMgr = this.MapMarkMgr;
			if (mapMarkMgr != null)
			{
				mapMarkMgr.UpdateNearbyMarkItem(CS$<>8__locals1.playerLocation, new Action<MarkItem>(CS$<>8__locals1.<MiniMapUpdateMarkItems>g__UpdateFunction|0), new Action<MarkItem>(CS$<>8__locals1.<MiniMapUpdateMarkItems>g__OnExitFunction|1));
			}
			MapRangePanel mapRangePanel = this.MapRangePanel;
			if (mapRangePanel == null)
			{
				return;
			}
			mapRangePanel.MiniMapUpdate();
		}

		// Token: 0x0603940E RID: 234510 RVA: 0x00E85B98 File Offset: 0x00E83D98
		private static void SetMarkItemPosition(MarkItem markItem, Vector2D position)
		{
			MarkItemView view = markItem.View;
			if (view != null && !view.IsCreating)
			{
				UUIItem rootItem = view.GetRootItem();
				if (rootItem != null && rootItem.IsValid() && markItem.MarkItemEntity.ViewLifeCircle.IsChildViewVisible(EMarkViewComponentType.MarkView, false))
				{
					rootItem.SetAnchorOffset(position.ToUeVector2D(false));
					return;
				}
			}
			else
			{
				markItem.GetRootItemAsync().ContinueWith(delegate(UUIItem markUiItem)
				{
					if (markUiItem != null && markUiItem.IsValid() && markItem.MarkItemEntity.ViewLifeCircle.IsChildViewVisible(EMarkViewComponentType.MarkView, false))
					{
						markUiItem.SetAnchorOffset(position.ToUeVector2D(false));
					}
				}).Forget();
			}
		}

		// Token: 0x0603940F RID: 234511 RVA: 0x00E85C2F File Offset: 0x00E83E2F
		public void Tick()
		{
			MapMarkMgr mapMarkMgr = this.MapMarkMgr;
			if (mapMarkMgr != null)
			{
				mapMarkMgr.Tick();
			}
			AutoPilotLine autoPilotLine = this.AutoPilotLine;
			if (autoPilotLine == null)
			{
				return;
			}
			autoPilotLine.OnMiniMapTick();
		}

		// Token: 0x06039410 RID: 234512 RVA: 0x00E85C52 File Offset: 0x00E83E52
		public void UpdateMinimapTiles(Vector position)
		{
			MapTileMgr mapTileMgr = this.MapTileMgr;
			if (mapTileMgr == null)
			{
				return;
			}
			mapTileMgr.UpdateMinimapTiles(position);
		}

		// Token: 0x06039411 RID: 234513 RVA: 0x00E85C65 File Offset: 0x00E83E65
		public void SetMapScale(float scale)
		{
			UUIItem rootItem = this.RootItem;
			if (rootItem == null)
			{
				return;
			}
			rootItem.D_SetWorldScale3D(new FVectorDouble((double)scale, (double)scale, (double)scale));
		}

		// Token: 0x06039412 RID: 234514 RVA: 0x00E85C82 File Offset: 0x00E83E82
		[NullableContext(2)]
		public MarkItem GetMarkItem(EMarkType markType, int markId)
		{
			MapMarkMgr mapMarkMgr = this.MapMarkMgr;
			if (mapMarkMgr == null)
			{
				return null;
			}
			return mapMarkMgr.GetMarkItem(markType, markId);
		}

		// Token: 0x06039413 RID: 234515 RVA: 0x00E85C98 File Offset: 0x00E83E98
		public UniTask ChangeMapAsync(int mapId)
		{
			MiniMap.<ChangeMapAsync>d__37 <ChangeMapAsync>d__;
			<ChangeMapAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ChangeMapAsync>d__.<>4__this = this;
			<ChangeMapAsync>d__.mapId = mapId;
			<ChangeMapAsync>d__.<>1__state = -1;
			<ChangeMapAsync>d__.<>t__builder.Start<MiniMap.<ChangeMapAsync>d__37>(ref <ChangeMapAsync>d__);
			return <ChangeMapAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06039414 RID: 234516 RVA: 0x00E85CE3 File Offset: 0x00E83EE3
		public UUIItem MarkContainer()
		{
			return base.GetItem(0);
		}

		// Token: 0x040208CE RID: 133326
		public EMapType MapType;

		// Token: 0x040208D1 RID: 133329
		[Nullable(2)]
		private MapMarkMgr MapMarkMgr;

		// Token: 0x040208D2 RID: 133330
		[Nullable(2)]
		public MapTileMgr MapTileMgr;

		// Token: 0x040208D3 RID: 133331
		[Nullable(2)]
		private MapSoundBoxSfxMgr MapSoundBoxSfxMgr;

		// Token: 0x040208D4 RID: 133332
		private readonly Dictionary<string, UTexture> PreloadTiles;

		// Token: 0x040208D5 RID: 133333
		private readonly float MapDefaultScale = 1f;

		// Token: 0x040208D6 RID: 133334
		private readonly float MarkScale = 1f;

		// Token: 0x040208D7 RID: 133335
		[Nullable(2)]
		private MapRangePanel MapRangePanel;

		// Token: 0x040208D8 RID: 133336
		private AutoPilotLine AutoPilotLine;

		// Token: 0x040208D9 RID: 133337
		[Nullable(2)]
		private MapRoadWaysMgr MapRoadWaysMgr;

		// Token: 0x040208DA RID: 133338
		private readonly Vector2D CachedMarkItemUi2dPosition = Vector2D.Create();

		// Token: 0x040208DB RID: 133339
		private readonly Vector2D CachedOffset = Vector2D.Create();

		// Token: 0x0200B873 RID: 47219
		[NullableContext(0)]
		public static class EChildComponentType
		{
			// Token: 0x040390BC RID: 233660
			public const int MarkRoot = 0;

			// Token: 0x040390BD RID: 233661
			public const int TileContainer = 1;

			// Token: 0x040390BE RID: 233662
			public const int TileTexture = 2;

			// Token: 0x040390BF RID: 233663
			public const int SubMapTileContainer = 3;

			// Token: 0x040390C0 RID: 233664
			public const int SubMapTileTexture = 4;

			// Token: 0x040390C1 RID: 233665
			public const int SubMapMask = 5;

			// Token: 0x040390C2 RID: 233666
			public const int TileTextureV2 = 6;

			// Token: 0x040390C3 RID: 233667
			public const int RoadWayContainer = 7;
		}
	}
}
