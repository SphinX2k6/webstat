using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Area;
using CSharpScript.Game.Module.Map;
using CSharpScript.Game.Module.Map.Base;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.Map.Mark;
using CSharpScript.Game.Module.Map.Mark.Component;
using CSharpScript.Game.Module.Map.Marks.MarkItem;
using CSharpScript.Game.Module.Map.View.BaseMap;
using CSharpScript.Game.Module.Map.View.BaseMap.Assistant.MapFrameTaskQueue;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;
using UnrealEngine.Extension;

namespace CSharpScript.Game.Module.WorldMap.ViewComponent
{
	// Token: 0x02004B54 RID: 19284
	[NullableContext(1)]
	[Nullable(0)]
	public class WorldMapUiEntity : MapEntity
	{
		// Token: 0x17008686 RID: 34438
		// (get) Token: 0x060325DC RID: 206300 RVA: 0x00C9A559 File Offset: 0x00C98759
		// (set) Token: 0x060325DD RID: 206301 RVA: 0x00C9A561 File Offset: 0x00C98761
		[Nullable(2)]
		public BaseMap Map
		{
			[NullableContext(2)]
			get
			{
				return this.MapInner;
			}
			[NullableContext(2)]
			set
			{
				this.MapInner = value;
				if (value == null)
				{
					return;
				}
				this.RecalculateMapSize();
			}
		}

		// Token: 0x060325DE RID: 206302 RVA: 0x00C9A574 File Offset: 0x00C98774
		public void RecalculateMapSize()
		{
			Vector2D mapSizeOverride = this.Map.MapTileMgr.GetMapSizeOverride();
			if (mapSizeOverride != null)
			{
				this.MapSize = mapSizeOverride;
				return;
			}
			UUIItem rootItem = this.Map.GetRootItem();
			this.MapSize = Vector2D.Create((double)rootItem.GetWidth(), (double)rootItem.GetHeight());
		}

		// Token: 0x17008687 RID: 34439
		// (get) Token: 0x060325DF RID: 206303 RVA: 0x00C9A5C4 File Offset: 0x00C987C4
		// (set) Token: 0x060325E0 RID: 206304 RVA: 0x00C9A5F5 File Offset: 0x00C987F5
		public FVector2D ViewPortSize
		{
			get
			{
				return this.PropertyMap.TryGet(0, Vector2D.ZeroVector, true).AsT2;
			}
			set
			{
				this.PropertyMap.Set(0, value);
			}
		}

		// Token: 0x17008688 RID: 34440
		// (get) Token: 0x060325E1 RID: 206305 RVA: 0x00C9A610 File Offset: 0x00C98810
		// (set) Token: 0x060325E2 RID: 206306 RVA: 0x00C9A653 File Offset: 0x00C98853
		public Vector2D OutOfViewPortSize
		{
			get
			{
				return this.PropertyMap.TryGet(1, Vector2D.Create(0.0, 0.0), true).AsT1;
			}
			set
			{
				this.PropertyMap.Set(1, value);
			}
		}

		// Token: 0x17008689 RID: 34441
		// (get) Token: 0x060325E3 RID: 206307 RVA: 0x00C9A670 File Offset: 0x00C98870
		// (set) Token: 0x060325E4 RID: 206308 RVA: 0x00C9A6B3 File Offset: 0x00C988B3
		public Vector2D MapSize
		{
			get
			{
				return this.PropertyMap.TryGet(2, Vector2D.Create(0.0, 0.0), true).AsT1;
			}
			set
			{
				this.PropertyMap.Set(2, value);
			}
		}

		// Token: 0x1700868A RID: 34442
		// (get) Token: 0x060325E5 RID: 206309 RVA: 0x00C9A6CD File Offset: 0x00C988CD
		// (set) Token: 0x060325E6 RID: 206310 RVA: 0x00C9A6D5 File Offset: 0x00C988D5
		public UKuroWorldMapUIParams UiParams
		{
			get
			{
				return this.UiParamsInner;
			}
			set
			{
				this.UiParamsInner = value;
			}
		}

		// Token: 0x1700868B RID: 34443
		// (get) Token: 0x060325E7 RID: 206311 RVA: 0x00C9A6DE File Offset: 0x00C988DE
		// (set) Token: 0x060325E8 RID: 206312 RVA: 0x00C9A6E6 File Offset: 0x00C988E6
		[Nullable(2)]
		public IWorldMapViewOpenParams OpenParams { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x1700868C RID: 34444
		// (get) Token: 0x060325E9 RID: 206313 RVA: 0x00C9A6F0 File Offset: 0x00C988F0
		// (set) Token: 0x060325EA RID: 206314 RVA: 0x00C9A73F File Offset: 0x00C9893F
		public int MapId
		{
			get
			{
				PropertyMap<OneOf<int, string>, OneOf<Vector2D, FVector2D, int>> propertyMap = this.PropertyMap;
				OneOf<int, string> key = 3;
				IWorldMapViewOpenParams openParams = this.OpenParams;
				return propertyMap.TryGet(key, ((openParams != null) ? openParams.MapId : null).GetValueOrDefault(8), true).AsT3;
			}
			set
			{
				this.PropertyMap.Set(3, value);
			}
		}

		// Token: 0x1700868D RID: 34445
		// (get) Token: 0x060325EB RID: 206315 RVA: 0x00C9A75C File Offset: 0x00C9895C
		public bool IsInPlayerMap
		{
			get
			{
				MapModel instance = ModelBase<MapModel>.Instance;
				AreaConfig instance2 = ConfigBase<AreaConfig>.Instance;
				AreaModel instance3 = ModelBase<AreaModel>.Instance;
				int currentAreaId = instance3.GetCurrentAreaId(new EAreaLevel?(EAreaLevel.Extra));
				if (currentAreaId != 0)
				{
					Area? areaInfo = instance2.GetAreaInfo(currentAreaId);
					if (areaInfo != null && areaInfo.Value.IsPlayerPosNeedCheck && areaInfo.Value.MapConfigId == this.MapId)
					{
						return true;
					}
				}
				int currentAreaId2 = instance3.GetCurrentAreaId(new EAreaLevel?(EAreaLevel.FirstLevel));
				if (currentAreaId2 != 0)
				{
					Area? areaInfo2 = instance2.GetAreaInfo(currentAreaId2);
					if (areaInfo2 != null)
					{
						return areaInfo2.Value.MapConfigId == this.MapId;
					}
				}
				int? lastHighLevelArea = instance.LastHighLevelArea;
				if (lastHighLevelArea == null)
				{
					return instance.CurrentWorldMapConfigId == this.MapId;
				}
				Area? areaInfo3 = instance2.GetAreaInfo(instance2.GetLevelOneAreaId(lastHighLevelArea.Value));
				if (areaInfo3 != null)
				{
					return areaInfo3.Value.MapConfigId == this.MapId;
				}
				return instance.CurrentWorldMapConfigId == this.MapId;
			}
		}

		// Token: 0x1700868E RID: 34446
		// (get) Token: 0x060325EC RID: 206316 RVA: 0x00C9A86C File Offset: 0x00C98A6C
		public bool IsInPlayerGravity
		{
			get
			{
				EMapGravityDirection currentPlayerGravity = ModelBase<MapModel>.Instance.CurrentPlayerGravity;
				EMapGravityDirection? worldMapSelectGravity = ModelBase<WorldMapModel>.Instance.WorldMapSelectGravity;
				return currentPlayerGravity == worldMapSelectGravity.GetValueOrDefault() & worldMapSelectGravity != null;
			}
		}

		// Token: 0x1700868F RID: 34447
		// (get) Token: 0x060325ED RID: 206317 RVA: 0x00C9A89F File Offset: 0x00C98A9F
		public WorldMapSecondaryUiComponent SecondaryUiComponent
		{
			get
			{
				return base.GetComponent<WorldMapSecondaryUiComponent>(EMapComponent.WorldMapSecondaryUi);
			}
		}

		// Token: 0x17008690 RID: 34448
		// (get) Token: 0x060325EE RID: 206318 RVA: 0x00C9A8A8 File Offset: 0x00C98AA8
		public WorldMapInteractComponent InteractComponent
		{
			get
			{
				return base.GetComponent<WorldMapInteractComponent>(EMapComponent.WorldMapInteract);
			}
		}

		// Token: 0x17008691 RID: 34449
		// (get) Token: 0x060325EF RID: 206319 RVA: 0x00C9A8B1 File Offset: 0x00C98AB1
		public WorldMapMoveComponent MoveComponent
		{
			get
			{
				return base.GetComponent<WorldMapMoveComponent>(EMapComponent.WorldMapMove);
			}
		}

		// Token: 0x17008692 RID: 34450
		// (get) Token: 0x060325F0 RID: 206320 RVA: 0x00C9A8BA File Offset: 0x00C98ABA
		public WorldMapScaleComponent ScaleComponent
		{
			get
			{
				return base.GetComponent<WorldMapScaleComponent>(EMapComponent.WorldMapScale);
			}
		}

		// Token: 0x17008693 RID: 34451
		// (get) Token: 0x060325F1 RID: 206321 RVA: 0x00C9A8C3 File Offset: 0x00C98AC3
		public WorldMapPlayerComponent PlayerComponent
		{
			get
			{
				return base.GetComponent<WorldMapPlayerComponent>(EMapComponent.WorldMapPlayer);
			}
		}

		// Token: 0x17008694 RID: 34452
		// (get) Token: 0x060325F2 RID: 206322 RVA: 0x00C9A8CC File Offset: 0x00C98ACC
		public WorldMapMultiFloorComponent MultiFloorComponent
		{
			get
			{
				return base.GetComponent<WorldMapMultiFloorComponent>(EMapComponent.WorldMapMultiFloor);
			}
		}

		// Token: 0x17008695 RID: 34453
		// (get) Token: 0x060325F3 RID: 206323 RVA: 0x00C9A8D5 File Offset: 0x00C98AD5
		public WorldMapQuickNavigateComponent QuickNavigateComponent
		{
			get
			{
				return base.GetComponent<WorldMapQuickNavigateComponent>(EMapComponent.WorldMapQuickNavigate);
			}
		}

		// Token: 0x17008696 RID: 34454
		// (get) Token: 0x060325F4 RID: 206324 RVA: 0x00C9A8DE File Offset: 0x00C98ADE
		public WorldMapStreamingComponent WorldMapStreamingComponent
		{
			get
			{
				return base.GetComponent<WorldMapStreamingComponent>(EMapComponent.WorldMapStreaming);
			}
		}

		// Token: 0x17008697 RID: 34455
		// (get) Token: 0x060325F5 RID: 206325 RVA: 0x00C9A8E7 File Offset: 0x00C98AE7
		public WorldMapAlterMapComponent WorldMapAlterMapComponent
		{
			get
			{
				return base.GetComponent<WorldMapAlterMapComponent>(EMapComponent.WorldMapAlterMap);
			}
		}

		// Token: 0x17008698 RID: 34456
		// (get) Token: 0x060325F6 RID: 206326 RVA: 0x00C9A8F1 File Offset: 0x00C98AF1
		public WorldMapExtraUiPanelComponent WorldMapExtraUiPanelComponent
		{
			get
			{
				return base.GetComponent<WorldMapExtraUiPanelComponent>(EMapComponent.WorldMapExtraUiPanel);
			}
		}

		// Token: 0x060325F7 RID: 206327 RVA: 0x00C9A8FB File Offset: 0x00C98AFB
		protected override void OnInit()
		{
			this.Reset(true);
		}

		// Token: 0x060325F8 RID: 206328 RVA: 0x00C9A904 File Offset: 0x00C98B04
		public void Reset(bool focus = true)
		{
			this.ScaleComponent.Initialize();
			this.InitSelfPlayerMark();
			if (!this.SecondaryUiComponent.IsSecondaryUiOpening)
			{
				IWorldMapViewOpenParams openParams = this.OpenParams;
				if (openParams != null)
				{
					bool? isNotFocusTween = openParams.IsNotFocusTween;
					if (isNotFocusTween != null && isNotFocusTween.GetValueOrDefault())
					{
						MarkItem markItem = this.Map.GetMarkItem(this.OpenParams.MarkType, this.OpenParams.MarkId.Value);
						if (markItem != null)
						{
							this.OpenParams.StartScale = new float?(this.ScaleComponent.MapScale);
							this.OpenParams.StartWorldPosition = Vector2D.Create(-markItem.UiPosition.X * (double)this.OpenParams.StartScale.Value, -markItem.UiPosition.Y * (double)this.OpenParams.StartScale.Value);
						}
					}
				}
				IWorldMapViewOpenParams openParams2 = this.OpenParams;
				if (openParams2 != null && openParams2.StartScale != null)
				{
					this.ScaleComponent.SetMapScale(this.OpenParams.StartScale.Value, EMapScaleSetType.Other, false, true);
				}
				IWorldMapViewOpenParams openParams3 = this.OpenParams;
				if (((openParams3 != null) ? openParams3.StartWorldPosition : null) == null)
				{
					IWorldMapViewOpenParams openParams4 = this.OpenParams;
					if (((openParams4 != null) ? openParams4.DebugWorldPosition : null) == null)
					{
						if (!ModelBase<MapModel>.Instance.CurrentInWorld)
						{
							this.SetPlayerInstancePosition(focus);
							goto IL_23F;
						}
						if (!this.IsInPlayerMap)
						{
							goto IL_23F;
						}
						this.UpdateSelfPlayerMark();
						if (focus)
						{
							this.MoveComponent.FocusPlayer(this.PlayerComponent.PlayerUiPosition, false, EClampType.ClampToSafeArea);
							goto IL_23F;
						}
						goto IL_23F;
					}
				}
				if (focus)
				{
					IWorldMapViewOpenParams openParams5 = this.OpenParams;
					if (((openParams5 != null) ? openParams5.StartWorldPosition : null) != null)
					{
						this.MoveComponent.SetMapPosition(this.OpenParams.StartWorldPosition, false, EClampType.NotClamp, null, null, true, false);
					}
					else
					{
						IWorldMapViewOpenParams openParams6 = this.OpenParams;
						if (((openParams6 != null) ? openParams6.DebugWorldPosition : null) != null)
						{
							this.MoveComponent.PushMapByUiPosition(this.OpenParams.DebugWorldPosition, false, EClampType.ClampToDangerousArea);
							this.Map.SetDebugMarkPosition(Vector2D.Create(this.OpenParams.DebugWorldPosition.X, this.OpenParams.DebugWorldPosition.Y));
						}
					}
				}
			}
			IL_23F:
			this.WorldMapStreamingComponent.BindAll(this.Map.GetAllMapTileItems());
			this.WorldMapStreamingComponent.Update();
			this.OnPlayerMarkPositionChanged(0, null);
			this.UpdateMarkItems(null);
			this.SecondaryUiComponent.AllSecondaryPanelsUpdateMap();
		}

		// Token: 0x060325F9 RID: 206329 RVA: 0x00C9AB94 File Offset: 0x00C98D94
		public void RegisterComponents()
		{
			this.ViewPortSize = LGuiExtension.GetUiViewportSize();
			base.AddComponent<WorldMapExtraUiPanelComponent>(EMapComponent.WorldMapExtraUiPanel);
			base.AddComponent<WorldMapSecondaryUiComponent>(EMapComponent.WorldMapSecondaryUi);
			base.AddComponent<WorldMapInteractComponent>(EMapComponent.WorldMapInteract);
			base.AddComponent<WorldMapMoveComponent>(EMapComponent.WorldMapMove);
			base.AddComponent<WorldMapPlayerComponent>(EMapComponent.WorldMapPlayer);
			base.AddComponent<WorldMapMultiFloorComponent>(EMapComponent.WorldMapMultiFloor);
			base.AddComponent<WorldMapQuickNavigateComponent>(EMapComponent.WorldMapQuickNavigate);
			base.AddComponent<WorldMapStreamingComponent>(EMapComponent.WorldMapStreaming);
			base.AddComponent<WorldMapAlterMapComponent>(EMapComponent.WorldMapAlterMap);
			base.AddComponent<WorldMapScaleComponent>(EMapComponent.WorldMapScale).ScaleChangeEvent = new WorldMapScaleComponent.TScaleChangeEvent(this.OnWorldMapScaleChanged);
			Singleton<EventSystem>.Instance.Add(EEventName.OnMarkItemTrackStateChange, new Action<MarkItem>(this.OnMarkItemTrackStateChanged));
			Singleton<EventSystem>.Instance.Add(EEventName.OnMarkItemAutoPilotTrackStateChange, new Action<EMarkType, int>(this.OnMarkItemAutoPilotTrackStateChanged));
			Singleton<EventSystem>.Instance.Add<EMarkType, int, bool>(EEventName.MarkForceVisibleChanged, new Action<EMarkType, int, bool>(this.OnMarkForceVisibleChanged));
			Singleton<EventSystem>.Instance.Add<int, global::Vector>(EEventName.ScenePlayerLocationChanged, new Action<int, global::Vector>(this.OnPlayerMarkPositionChanged));
			Singleton<EventSystem>.Instance.Add(EEventName.OnMapMarkTaskComplete, new Action<EMarkType, int>(this.OnMarkTaskComplete));
			Singleton<EventSystem>.Instance.Add(EEventName.WorldMapPositionChanged, new Action(this.OnWorldMapPositionChanged));
			Singleton<EventSystem>.Instance.Add(EEventName.WorldMapUpdateMultiMap, new Action(this.OnWorldMapUpdateMultiMapChanged));
			Singleton<EventSystem>.Instance.Add<int>(EEventName.WorldMapSelectMultiMap, new Action<int>(this.OnSubMapChanged));
		}

		// Token: 0x060325FA RID: 206330 RVA: 0x00C9ACF0 File Offset: 0x00C98EF0
		protected override void OnDispose()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnMarkItemTrackStateChange, new Action<MarkItem>(this.OnMarkItemTrackStateChanged));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnMarkItemAutoPilotTrackStateChange, new Action<EMarkType, int>(this.OnMarkItemAutoPilotTrackStateChanged));
			Singleton<EventSystem>.Instance.Remove(EEventName.MarkForceVisibleChanged, new Action<EMarkType, int, bool>(this.OnMarkForceVisibleChanged));
			Singleton<EventSystem>.Instance.Remove(EEventName.ScenePlayerLocationChanged, new <>f__AnonymousDelegate10<int, global::Vector>(this.OnPlayerMarkPositionChanged));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnMapMarkTaskComplete, new Action<EMarkType, int>(this.OnMarkTaskComplete));
			Singleton<EventSystem>.Instance.Remove(EEventName.WorldMapPositionChanged, new Action(this.OnWorldMapPositionChanged));
			Singleton<EventSystem>.Instance.Remove(EEventName.WorldMapUpdateMultiMap, new Action(this.OnWorldMapUpdateMultiMapChanged));
			Singleton<EventSystem>.Instance.Remove(EEventName.WorldMapSelectMultiMap, new Action<int>(this.OnSubMapChanged));
			this.MapGamePlayRequestPreemptiveFrameQueue.Dispose();
			this.MapUpdateTaskFrameQueue.Dispose();
			this.Map = null;
		}

		// Token: 0x060325FB RID: 206331 RVA: 0x00C9ADFA File Offset: 0x00C98FFA
		protected override void OnTick()
		{
			BaseMap map = this.Map;
			if (map != null)
			{
				map.Tick();
			}
			this.MapGamePlayRequestPreemptiveFrameQueue.Process();
			this.WorldMapStreamingComponent.RefreshViewportCache();
			this.MapUpdateTaskFrameQueue.Process();
		}

		// Token: 0x060325FC RID: 206332 RVA: 0x00C9AE2E File Offset: 0x00C9902E
		public void CancelAllTasks()
		{
			this.MapGamePlayRequestPreemptiveFrameQueue.Dispose();
			this.MapUpdateTaskFrameQueue.Dispose();
		}

		// Token: 0x060325FD RID: 206333 RVA: 0x00C9AE48 File Offset: 0x00C99048
		private void OnWorldMapScaleChanged(float oldScale, float newScale, EMapScaleSetType type)
		{
			if (this.ClickedItem == null)
			{
				Vector2D targetPosition = null;
				Vector2D vector2D = Vector2D.Create(this.Map.GetRootItem().GetAnchorOffset());
				Vector2D tweenTarget = this.MoveComponent.TweenTarget;
				Vector2D vector2D2 = null;
				if (type - EMapScaleSetType.ZoomButton <= 4)
				{
					vector2D2 = this.GetScaleAnchoredPosition();
				}
				float num = (oldScale == 0f) ? 1f : (newScale / oldScale);
				Vector2D focusPosition;
				if (vector2D2 != null)
				{
					focusPosition = vector2D.Subtraction(vector2D2, vector2D).Multiply((double)num, vector2D).Addition(vector2D2, vector2D);
					if (tweenTarget != null)
					{
						targetPosition = tweenTarget.Subtraction(vector2D2, tweenTarget).Multiply((double)num, tweenTarget).Addition(vector2D2, tweenTarget);
					}
				}
				else
				{
					focusPosition = vector2D.Multiply((double)num, vector2D);
					if (tweenTarget != null)
					{
						targetPosition = tweenTarget.Multiply((double)num, vector2D);
					}
				}
				this.MoveComponent.SetMapPositionCauseByScaling(focusPosition, targetPosition, EClampType.ClampToDangerousArea);
			}
			else
			{
				this.MoveComponent.PushMap(this.ClickedItem, false, EClampType.ClampToDangerousArea);
			}
			BaseMap map = this.Map;
			if (map == null)
			{
				return;
			}
			map.AutoPilotLine.RefreshFindPathLine();
		}

		// Token: 0x060325FE RID: 206334 RVA: 0x00C9AF40 File Offset: 0x00C99140
		[NullableContext(2)]
		private Vector2D GetScaleAnchoredPosition()
		{
			TsBasePlayerController tsBasePlayerController = Global.PlayerController as TsBasePlayerController;
			if (tsBasePlayerController == null)
			{
				return null;
			}
			Vector2D vector2D = null;
			if (Singleton<Info>.Instance.IsInKeyBoard())
			{
				vector2D = Vector2D.Create(tsBasePlayerController.GetCursorPosition());
			}
			else if (Singleton<Info>.Instance.IsInTouch())
			{
				vector2D = this.InteractComponent.MultiTouchOriginCenter;
			}
			if (vector2D == null)
			{
				return null;
			}
			ULGUICanvasScaler canvasScaler = Singleton<UiLayer>.Instance.UiRootItem.GetCanvasScaler();
			if (canvasScaler == null)
			{
				return null;
			}
			ULGUICanvasScaler ulguicanvasScaler = canvasScaler;
			FVector2D fvector2D = vector2D.ToUeVector2D(false);
			FVector2D fvector2D2 = ulguicanvasScaler.ConvertPositionFromViewportToLGUICanvas(fvector2D);
			Vector2D viewportSize = LGuiExtension.GetViewportSize();
			viewportSize.Set((double)fvector2D2.X - viewportSize.X / 2.0, (double)fvector2D2.Y - viewportSize.Y / 2.0);
			return viewportSize;
		}

		// Token: 0x060325FF RID: 206335 RVA: 0x00C9B000 File Offset: 0x00C99200
		public void InitSelfPlayerMark()
		{
			if (!this.WorldMapExtraUiPanelComponent.IsExtraUiViewOpened)
			{
				bool isInPlayerMap = this.IsInPlayerMap;
				UUIItem selfPlayerNode = this.Map.SelfPlayerNode;
				selfPlayerNode.SetUIActive(isInPlayerMap);
				if (isInPlayerMap)
				{
					selfPlayerNode.SetAsLastHierarchy();
				}
				this.UpdateSelfPlayerGravity();
				return;
			}
			BaseMap map = this.Map;
			if (map == null)
			{
				return;
			}
			UUIItem selfPlayerNode2 = map.SelfPlayerNode;
			if (selfPlayerNode2 == null)
			{
				return;
			}
			selfPlayerNode2.SetUIActive(this.WorldMapExtraUiPanelComponent.IsShowPlayerMark);
		}

		// Token: 0x06032600 RID: 206336 RVA: 0x00C9B06C File Offset: 0x00C9926C
		private void UpdateSelfPlayerGravity()
		{
			bool flag = ModelBase<WorldMapModel>.Instance.IsGravityMap(this.MapId);
			UUIItem playerArrow = this.Map.PlayerArrow;
			if (flag && !this.IsInPlayerGravity)
			{
				playerArrow.SetAlpha(0.4f);
				this.Map.SetPlayerGravityActive(true, ModelBase<MapModel>.Instance.CurrentPlayerGravity);
				return;
			}
			playerArrow.SetAlpha(1f);
			this.Map.SetPlayerGravityActive(false, EMapGravityDirection.Down);
		}

		// Token: 0x06032601 RID: 206337 RVA: 0x00C9B0DC File Offset: 0x00C992DC
		public void UpdateSelfPlayerMark()
		{
			if (this.WorldMapExtraUiPanelComponent.IsExtraUiViewOpened && !this.WorldMapExtraUiPanelComponent.IsShowPlayerMark)
			{
				return;
			}
			this.PlayerComponent.UpdatePlayerPosition();
			float playerRotation = this.PlayerComponent.PlayerRotation;
			Vector2D playerUiPosition = this.PlayerComponent.PlayerUiPosition;
			float mapScale = this.ScaleComponent.MapScale;
			UUIItem playerArrow = this.Map.PlayerArrow;
			FRotator frotator = new FRotator(0f, playerRotation, 0f);
			playerArrow.SetUIRelativeRotation(frotator);
			Vector2D mapUiPosition = this.MoveComponent.MapUiPosition;
			Vector2D vector2D = Vector2D.Create();
			playerUiPosition.Multiply((double)mapScale, vector2D).Addition(mapUiPosition, vector2D);
			ValueTuple<Vector2D, bool> valueTuple = this.ClampToMarkEdge(vector2D);
			Vector2D item = valueTuple.Item1;
			bool item2 = valueTuple.Item2;
			UUIItem playerOutOfBoundIndicator = this.Map.PlayerOutOfBoundIndicator;
			if (item2)
			{
				this.PlayerComponent.PlayerOutOfBound = true;
				Vector2D vector2D2 = item.Subtraction(mapUiPosition, item).Division((double)mapScale, item);
				this.Map.SelfPlayerNode.SetAnchorOffset(vector2D2.ToUeVector2D(false));
				float inYaw = (float)(Math.Atan2(vector2D.Y, vector2D.X) * 57.2957763671875 - 90.0);
				UUIItem uuiitem = playerOutOfBoundIndicator;
				frotator = new FRotator(0f, inYaw, 0f);
				uuiitem.SetUIRelativeRotation(frotator);
			}
			else
			{
				this.PlayerComponent.PlayerOutOfBound = false;
				this.Map.SelfPlayerNode.SetAnchorOffset(this.PlayerComponent.PlayerUiPosition.ToUeVector2D(false));
			}
			playerOutOfBoundIndicator.SetUIActive(item2);
		}

		// Token: 0x06032602 RID: 206338 RVA: 0x00C9B254 File Offset: 0x00C99454
		private void SetPlayerInstancePosition(bool focus = true)
		{
			this.UpdateSelfPlayerMark();
			if (focus)
			{
				Vector2D lastBigScenePlayerUiPosition = MapUtil.GetLastBigScenePlayerUiPosition();
				this.MoveComponent.FocusPlayer(lastBigScenePlayerUiPosition, false, EClampType.ClampToSafeArea);
			}
		}

		// Token: 0x06032603 RID: 206339 RVA: 0x00C9B280 File Offset: 0x00C99480
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		public ValueTuple<Vector2D, bool> ClampToMarkEdge(Vector2D offset)
		{
			Vector2D markEdgeSize = this.MarkEdgeSize;
			if (Math.Abs(offset.X) < markEdgeSize.X && Math.Abs(offset.Y) < markEdgeSize.Y)
			{
				return new ValueTuple<Vector2D, bool>(offset, false);
			}
			Vector2D item = Vector2D.Create();
			if (Math.Abs(offset.X / offset.Y) > markEdgeSize.X / markEdgeSize.Y)
			{
				item = offset.Multiply(markEdgeSize.X / Math.Abs(offset.X), offset);
			}
			else
			{
				item = offset.Multiply(markEdgeSize.Y / Math.Abs(offset.Y), offset);
			}
			return new ValueTuple<Vector2D, bool>(item, true);
		}

		// Token: 0x06032604 RID: 206340 RVA: 0x00C9B326 File Offset: 0x00C99526
		private void OnMarkItemTrackStateChanged(MarkItem markItem)
		{
			if (!markItem.IsDestroy)
			{
				this.UpdateSingleMarkItem(markItem, true);
			}
		}

		// Token: 0x06032605 RID: 206341 RVA: 0x00C9B338 File Offset: 0x00C99538
		private void OnMarkItemAutoPilotTrackStateChanged(EMarkType markType, int markId)
		{
			MarkItem markItem = this.Map.GetMarkItem(markType, markId);
			if (markItem != null && !markItem.IsDestroy)
			{
				this.UpdateSingleMarkItem(markItem, true);
			}
		}

		// Token: 0x06032606 RID: 206342 RVA: 0x00C9B368 File Offset: 0x00C99568
		private void OnMarkForceVisibleChanged(EMarkType markType, int markId, bool visible)
		{
			this.UpdateMarkItems(null);
		}

		// Token: 0x06032607 RID: 206343 RVA: 0x00C9B384 File Offset: 0x00C99584
		private void OnSubMapChanged(int selectMultiMapId)
		{
			this.UpdateMarkItems(null);
		}

		// Token: 0x06032608 RID: 206344 RVA: 0x00C9B3A0 File Offset: 0x00C995A0
		public void UpdateMarkItems(bool? forceViewUpdate = null)
		{
			this.UpdateSelfPlayerMark();
			this.WorldMapStreamingComponent.RefreshViewportCache();
			foreach (Dictionary<int, MarkItem> dictionary in this.Map.GetAllMarkItems().Values)
			{
				foreach (MarkItem markItem in dictionary.Values)
				{
					this.QueueExecutionUpdateSingleMarkItem(markItem, forceViewUpdate.GetValueOrDefault());
				}
			}
			this.ScaleComponent.FlushScaleDirty();
		}

		// Token: 0x06032609 RID: 206345 RVA: 0x00C9B45C File Offset: 0x00C9965C
		public UniTask UpdateMarkItemsAsync()
		{
			WorldMapUiEntity.<UpdateMarkItemsAsync>d__74 <UpdateMarkItemsAsync>d__;
			<UpdateMarkItemsAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<UpdateMarkItemsAsync>d__.<>4__this = this;
			<UpdateMarkItemsAsync>d__.<>1__state = -1;
			<UpdateMarkItemsAsync>d__.<>t__builder.Start<WorldMapUiEntity.<UpdateMarkItemsAsync>d__74>(ref <UpdateMarkItemsAsync>d__);
			return <UpdateMarkItemsAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603260A RID: 206346 RVA: 0x00C9B4A0 File Offset: 0x00C996A0
		private void OnMarkTaskComplete(EMarkType markType, int markId)
		{
			MarkItem markItem = this.Map.GetMarkItem(markType, markId);
			if (markItem != null && !markItem.IsDestroy)
			{
				this.UpdateSingleMarkItem(markItem, false);
			}
		}

		// Token: 0x0603260B RID: 206347 RVA: 0x00C9B4CE File Offset: 0x00C996CE
		private bool MarkItemUpdateCheck(MarkItem markItem)
		{
			return markItem.PermanentUpdate || this.WorldMapStreamingComponent.HandleStreamingUpdate(markItem);
		}

		// Token: 0x0603260C RID: 206348 RVA: 0x00C9B4E8 File Offset: 0x00C996E8
		private void QueueExecutionUpdateSingleMarkItem(MarkItem markItem, bool forceViewUpdate = false)
		{
			WorldMapScaleComponent scaleComponent = this.ScaleComponent;
			bool isScaleDirty = scaleComponent.IsScaleDirty;
			if (isScaleDirty || markItem.PermanentUpdate)
			{
				this.UpdateSingleMarkItem(markItem, true);
				return;
			}
			if (!this.WorldMapStreamingComponent.IsInStreamingRange(markItem))
			{
				markItem.MarkItemEntity.ViewLifeCircle.SetChildViewVisibility(EMarkViewComponentType.MarkView, false);
				markItem.CreateOrCycleView();
				return;
			}
			UpdateSingleMarkItemParam param = new UpdateSingleMarkItemParam
			{
				MapUiPosition = this.MoveComponent.MapUiPosition,
				MapScale = scaleComponent.MapScale,
				PlayerWorldPosition = this.PlayerComponent.PlayerWorldPosition,
				IsDragging = this.InteractComponent.IsDragging,
				IsScaleDirty = isScaleDirty,
				ForceViewUpdate = forceViewUpdate
			};
			MapMarkPreemptiveFrameTask task = new MapMarkPreemptiveFrameTask
			{
				Priority = 0,
				Execute = delegate
				{
					if (!markItem.IsDestroy)
					{
						this.UpdateSingleMarkItemInternal(markItem, param).Forget();
					}
				},
				MarkId = markItem.MarkId,
				MarkType = markItem.MarkType
			};
			this.MapUpdateTaskFrameQueue.AddTask(task);
		}

		// Token: 0x0603260D RID: 206349 RVA: 0x00C9B610 File Offset: 0x00C99810
		public void UpdateSingleMarkItem(MarkItem markItem, bool forceViewUpdate = false)
		{
			WorldMapScaleComponent scaleComponent = this.ScaleComponent;
			UpdateSingleMarkItemParam param = new UpdateSingleMarkItemParam
			{
				MapUiPosition = this.MoveComponent.MapUiPosition,
				MapScale = scaleComponent.MapScale,
				PlayerWorldPosition = this.PlayerComponent.PlayerWorldPosition,
				IsDragging = this.InteractComponent.IsDragging,
				IsScaleDirty = scaleComponent.IsScaleDirty,
				ForceViewUpdate = forceViewUpdate
			};
			this.UpdateSingleMarkItemInternal(markItem, param).Forget();
		}

		// Token: 0x0603260E RID: 206350 RVA: 0x00C9B68C File Offset: 0x00C9988C
		public UniTask UpdateSingleMarkItemAsync(MarkItem markItem, bool forceViewUpdate = false)
		{
			WorldMapUiEntity.<UpdateSingleMarkItemAsync>d__79 <UpdateSingleMarkItemAsync>d__;
			<UpdateSingleMarkItemAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<UpdateSingleMarkItemAsync>d__.<>4__this = this;
			<UpdateSingleMarkItemAsync>d__.markItem = markItem;
			<UpdateSingleMarkItemAsync>d__.forceViewUpdate = forceViewUpdate;
			<UpdateSingleMarkItemAsync>d__.<>1__state = -1;
			<UpdateSingleMarkItemAsync>d__.<>t__builder.Start<WorldMapUiEntity.<UpdateSingleMarkItemAsync>d__79>(ref <UpdateSingleMarkItemAsync>d__);
			return <UpdateSingleMarkItemAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603260F RID: 206351 RVA: 0x00C9B6E0 File Offset: 0x00C998E0
		private UniTask UpdateSingleMarkItemInternal(MarkItem markItem, UpdateSingleMarkItemParam param)
		{
			WorldMapUiEntity.<UpdateSingleMarkItemInternal>d__80 <UpdateSingleMarkItemInternal>d__;
			<UpdateSingleMarkItemInternal>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<UpdateSingleMarkItemInternal>d__.<>4__this = this;
			<UpdateSingleMarkItemInternal>d__.markItem = markItem;
			<UpdateSingleMarkItemInternal>d__.param = param;
			<UpdateSingleMarkItemInternal>d__.<>1__state = -1;
			<UpdateSingleMarkItemInternal>d__.<>t__builder.Start<WorldMapUiEntity.<UpdateSingleMarkItemInternal>d__80>(ref <UpdateSingleMarkItemInternal>d__);
			return <UpdateSingleMarkItemInternal>d__.<>t__builder.Task;
		}

		// Token: 0x06032610 RID: 206352 RVA: 0x00C9B734 File Offset: 0x00C99934
		private void OnPlayerMarkPositionChanged(int _1 = 0, global::Vector _2 = null)
		{
			if (this.Map == null)
			{
				return;
			}
			Dictionary<int, MarkItem> markItemsByType = this.Map.GetMarkItemsByType(EMarkType.OtherPlayers, true);
			if (markItemsByType == null || markItemsByType.Count == 0)
			{
				return;
			}
			foreach (MarkItem markItem in markItemsByType.Values)
			{
				this.UpdateSingleMarkItem(markItem, false);
			}
		}

		// Token: 0x06032611 RID: 206353 RVA: 0x00C9B7AC File Offset: 0x00C999AC
		private unsafe void CheckAndCreateGamePlayRequestTask(MarkItem markItem)
		{
			MarkCommonGamePlayStateComponent component = markItem.MarkItemEntity.GetComponent<MarkCommonGamePlayStateComponent>(EMapComponent.MarkCommonGamePlayState);
			if (component != null && component.NeedRequestGamePlayState())
			{
				int? relativeId = component.GetRelativeId();
				int? relativeDungeonId = component.GetRelativeDungeonId();
				if (relativeId == null || relativeDungeonId == null)
				{
					return;
				}
				MapGamePlayRequestPreemptiveFrameTask mapGamePlayRequestPreemptiveFrameTask = new MapGamePlayRequestPreemptiveFrameTask();
				mapGamePlayRequestPreemptiveFrameTask.Priority = 0;
				mapGamePlayRequestPreemptiveFrameTask.Execute = delegate()
				{
				};
				mapGamePlayRequestPreemptiveFrameTask.MarkId = markItem.MarkId;
				mapGamePlayRequestPreemptiveFrameTask.GamePlayId = relativeId.Value;
				mapGamePlayRequestPreemptiveFrameTask.InstId = relativeDungeonId.Value;
				MapGamePlayRequestPreemptiveFrameTask task = mapGamePlayRequestPreemptiveFrameTask;
				this.MapGamePlayRequestPreemptiveFrameQueue.AddTask(task);
				OneOf<MapMark, DynamicMapMark, TreasureBoxDetectorMark> config = markItem.MarkItemEntity.GetComponent<MarkConfigComponent>(EMapComponent.MarkConfig).Config;
				if (config.IsT1)
				{
					Span<int> associatedGameplayMarksBytes = config.AsT1.GetAssociatedGameplayMarksBytes();
					for (int i = 0; i < associatedGameplayMarksBytes.Length; i++)
					{
						int markId = *associatedGameplayMarksBytes[i];
						MapMark? configMark = ConfigBase<MapConfig>.Instance.GetConfigMark(markId);
						if (configMark != null)
						{
							MapGamePlayRequestPreemptiveFrameTask mapGamePlayRequestPreemptiveFrameTask2 = new MapGamePlayRequestPreemptiveFrameTask();
							mapGamePlayRequestPreemptiveFrameTask2.Priority = 0;
							mapGamePlayRequestPreemptiveFrameTask2.Execute = delegate()
							{
							};
							mapGamePlayRequestPreemptiveFrameTask2.MarkId = markItem.MarkId;
							mapGamePlayRequestPreemptiveFrameTask2.GamePlayId = configMark.Value.RelativeId;
							mapGamePlayRequestPreemptiveFrameTask2.InstId = configMark.Value.RelativeDungeonId;
							MapGamePlayRequestPreemptiveFrameTask task2 = mapGamePlayRequestPreemptiveFrameTask2;
							this.MapGamePlayRequestPreemptiveFrameQueue.AddTask(task2);
						}
					}
				}
				component.HasRequestGamePlay = true;
			}
		}

		// Token: 0x06032612 RID: 206354 RVA: 0x00C9B94D File Offset: 0x00C99B4D
		private void OnWorldMapPositionChanged()
		{
			this.WorldMapStreamingComponent.Update();
			this.UpdateMarkItems(new bool?(true));
		}

		// Token: 0x06032613 RID: 206355 RVA: 0x00C9B966 File Offset: 0x00C99B66
		private void OnWorldMapUpdateMultiMapChanged()
		{
			this.MultiFloorComponent.UpdateMultiMap();
		}

		// Token: 0x0401D69B RID: 120475
		private const float RAD_2_DEG = 57.295776f;

		// Token: 0x0401D69C RID: 120476
		private const float DEG_PI_4 = 90f;

		// Token: 0x0401D69D RID: 120477
		[Nullable(2)]
		private BaseMap MapInner;

		// Token: 0x0401D69E RID: 120478
		[Nullable(2)]
		private UKuroWorldMapUIParams UiParamsInner;

		// Token: 0x0401D6A0 RID: 120480
		[Nullable(2)]
		public MarkItem ClickedItem;

		// Token: 0x0401D6A1 RID: 120481
		private readonly MapGamePlayRequestPreemptiveFrameQueue MapGamePlayRequestPreemptiveFrameQueue = new MapGamePlayRequestPreemptiveFrameQueue(200, 0);

		// Token: 0x0401D6A2 RID: 120482
		private readonly MapUpdateTaskPreemptiveFrameQueue MapUpdateTaskFrameQueue = new MapUpdateTaskPreemptiveFrameQueue(1500, 0);

		// Token: 0x0401D6A3 RID: 120483
		[Nullable(2)]
		public Vector2D MarkEdgeSize;

		// Token: 0x0200AC1F RID: 44063
		[NullableContext(0)]
		public static class EPropertyType
		{
			// Token: 0x0403588A RID: 219274
			public const int ViewPortSize = 0;

			// Token: 0x0403588B RID: 219275
			public const int OutOfViewPortSize = 1;

			// Token: 0x0403588C RID: 219276
			public const int MapSize = 2;

			// Token: 0x0403588D RID: 219277
			public const int MapId = 3;
		}
	}
}
