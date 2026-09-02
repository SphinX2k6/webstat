using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Map;
using CSharpScript.Game.Module.Map.Base;
using CSharpScript.Game.Module.Map.Marks.MarkItem;
using CSharpScript.Game.Module.Map.View.BaseMap;
using CSharpScript.Game.Module.Map.View.BaseMap.Assistant;
using UnrealEngine;

namespace CSharpScript.Game.Module.WorldMap.ViewComponent
{
	// Token: 0x02004B4B RID: 19275
	[NullableContext(1)]
	[Nullable(0)]
	public class WorldMapMoveComponent : MapComponent
	{
		// Token: 0x0603254C RID: 206156 RVA: 0x00C97E1B File Offset: 0x00C9601B
		public WorldMapMoveComponent([Nullable(new byte[]
		{
			0,
			1,
			1,
			1
		})] OneOf<MapComponent, MapComponentContainer, MapEntity> parent) : base(parent)
		{
		}

		// Token: 0x17008662 RID: 34402
		// (get) Token: 0x0603254D RID: 206157 RVA: 0x00C97E3A File Offset: 0x00C9603A
		public override EMapComponent ComponentType
		{
			get
			{
				return EMapComponent.WorldMapMove;
			}
		}

		// Token: 0x17008663 RID: 34403
		// (get) Token: 0x0603254E RID: 206158 RVA: 0x00C97E3D File Offset: 0x00C9603D
		public bool IsTweeningMove
		{
			get
			{
				return this.IsTweening;
			}
		}

		// Token: 0x17008664 RID: 34404
		// (get) Token: 0x0603254F RID: 206159 RVA: 0x00C97E45 File Offset: 0x00C96045
		[Nullable(2)]
		public Vector2D TweenTarget
		{
			[NullableContext(2)]
			get
			{
				return this.TweenTargetInner;
			}
		}

		// Token: 0x17008665 RID: 34405
		// (get) Token: 0x06032550 RID: 206160 RVA: 0x00C97E4D File Offset: 0x00C9604D
		public bool IsDragMoveDisabled
		{
			get
			{
				return this.IsDragDisabled;
			}
		}

		// Token: 0x17008666 RID: 34406
		// (get) Token: 0x06032551 RID: 206161 RVA: 0x00C97E55 File Offset: 0x00C96055
		public float MapScale
		{
			get
			{
				return ModelBase<WorldMapModel>.Instance.MapScale;
			}
		}

		// Token: 0x17008667 RID: 34407
		// (get) Token: 0x06032552 RID: 206162 RVA: 0x00C97E64 File Offset: 0x00C96064
		[Nullable(2)]
		private WorldMapUiEntity WorldMapUiComponent
		{
			[NullableContext(2)]
			get
			{
				WorldMapUiEntity worldMapUiEntity = base.Parent.AsT3 as WorldMapUiEntity;
				if (worldMapUiEntity == null)
				{
					base.LogError(ELogAuthor.LRX, "[地图系统]->二级界面组件没有附加到容器下！", default(ReadOnlySpan<ValueTuple<string, object>>));
					return null;
				}
				return worldMapUiEntity;
			}
		}

		// Token: 0x17008668 RID: 34408
		// (get) Token: 0x06032553 RID: 206163 RVA: 0x00C97EA1 File Offset: 0x00C960A1
		[Nullable(2)]
		private UKuroWorldMapUIParams UiParams
		{
			[NullableContext(2)]
			get
			{
				WorldMapUiEntity worldMapUiComponent = this.WorldMapUiComponent;
				if (worldMapUiComponent == null)
				{
					return null;
				}
				return worldMapUiComponent.UiParams;
			}
		}

		// Token: 0x17008669 RID: 34409
		// (get) Token: 0x06032554 RID: 206164 RVA: 0x00C97EB4 File Offset: 0x00C960B4
		private FVector2D ViewportSize
		{
			get
			{
				return this.WorldMapUiComponent.ViewPortSize;
			}
		}

		// Token: 0x1700866A RID: 34410
		// (get) Token: 0x06032555 RID: 206165 RVA: 0x00C97EC1 File Offset: 0x00C960C1
		private Vector2D MapSize
		{
			get
			{
				WorldMapUiEntity worldMapUiComponent = this.WorldMapUiComponent;
				return ((worldMapUiComponent != null) ? worldMapUiComponent.MapSize : null) ?? Vector2D.Create();
			}
		}

		// Token: 0x1700866B RID: 34411
		// (get) Token: 0x06032556 RID: 206166 RVA: 0x00C97EE0 File Offset: 0x00C960E0
		public Vector2D MapUiPosition
		{
			get
			{
				if (this.MapUiPositionInner == null)
				{
					FVector2D anchorOffset = this.WorldMapUiComponent.Map.GetRootItem().GetAnchorOffset();
					this.MapUiPositionInner = Vector2D.Create((double)anchorOffset.X, (double)anchorOffset.Y);
				}
				return this.MapUiPositionInner;
			}
		}

		// Token: 0x1700866C RID: 34412
		// (get) Token: 0x06032557 RID: 206167 RVA: 0x00C97F2C File Offset: 0x00C9612C
		public IArea SafeAreaSize
		{
			get
			{
				BaseMap map = this.WorldMapUiComponent.Map;
				IArea safeArea = this.SafeArea;
				AkiMap? akiMapConfig = ConfigBase<WorldMapConfig>.Instance.GetAkiMapConfig(map.MapId, true);
				int[] array = (akiMapConfig.Value.SafeAreaOffsetLength == 4) ? akiMapConfig.Value.SafeAreaOffset() : new int[4];
				MapTileMgr mapTileMgr = map.MapTileMgr;
				Vector2D vector2D = (mapTileMgr != null) ? mapTileMgr.GetContentCenterOffset() : null;
				double num = (vector2D != null) ? (vector2D.X * (double)this.MapScale) : 0.0;
				double num2 = (vector2D != null) ? (vector2D.Y * (double)this.MapScale) : 0.0;
				safeArea.MinX = -((this.MapSize.X + (double)map.MapOffset.Value.Y + (double)array[1]) * (double)this.MapScale - (double)this.ViewportSize.X) / 2.0 + num;
				safeArea.MaxX = ((this.MapSize.X - (double)map.MapOffset.Value.X - (double)array[0]) * (double)this.MapScale - (double)this.ViewportSize.X) / 2.0 + num;
				safeArea.MinY = -((this.MapSize.Y - (double)map.MapOffset.Value.Z + (double)array[3]) * (double)this.MapScale - (double)this.ViewportSize.Y) / 2.0 + num2;
				safeArea.MaxY = ((this.MapSize.Y - (double)map.MapOffset.Value.W - (double)array[2]) * (double)this.MapScale - (double)this.ViewportSize.Y) / 2.0 + num2;
				return safeArea;
			}
		}

		// Token: 0x1700866D RID: 34413
		// (get) Token: 0x06032558 RID: 206168 RVA: 0x00C9811C File Offset: 0x00C9631C
		public IArea DangerousAreaSize
		{
			get
			{
				BaseMap map = this.WorldMapUiComponent.Map;
				IArea dangerousArea = this.DangerousArea;
				AkiMap? akiMapConfig = ConfigBase<WorldMapConfig>.Instance.GetAkiMapConfig(map.MapId, true);
				int[] array = (akiMapConfig.Value.SafeAreaOffsetLength == 4) ? akiMapConfig.Value.SafeAreaOffset() : new int[4];
				MapTileMgr mapTileMgr = map.MapTileMgr;
				Vector2D vector2D = (mapTileMgr != null) ? mapTileMgr.GetContentCenterOffset() : null;
				double num = (vector2D != null) ? (vector2D.X * (double)this.MapScale) : 0.0;
				double num2 = (vector2D != null) ? (vector2D.Y * (double)this.MapScale) : 0.0;
				dangerousArea.MinX = -((this.MapSize.X + (double)map.MapOffset.Value.Y + (double)map.FakeOffset + (double)array[1]) * (double)this.MapScale - (double)this.ViewportSize.X) / 2.0 + num;
				dangerousArea.MaxX = ((this.MapSize.X - (double)map.MapOffset.Value.X + (double)map.FakeOffset - (double)array[0]) * (double)this.MapScale - (double)this.ViewportSize.X) / 2.0 + num;
				dangerousArea.MinY = -((this.MapSize.Y - (double)map.MapOffset.Value.Z + (double)map.FakeOffset + (double)array[3]) * (double)this.MapScale - (double)this.ViewportSize.Y) / 2.0 + num2;
				dangerousArea.MaxY = ((this.MapSize.Y - (double)map.MapOffset.Value.W + (double)map.FakeOffset - (double)array[2]) * (double)this.MapScale - (double)this.ViewportSize.Y) / 2.0 + num2;
				return dangerousArea;
			}
		}

		// Token: 0x06032559 RID: 206169 RVA: 0x00C9832C File Offset: 0x00C9652C
		protected override void OnAdd()
		{
			this.SafeArea = new Area
			{
				MinX = 0.0,
				MaxX = 0.0,
				MinY = 0.0,
				MaxY = 0.0
			};
			this.DangerousArea = new Area
			{
				MinX = 0.0,
				MaxX = 0.0,
				MinY = 0.0,
				MaxY = 0.0
			};
			this.TweenerDelegate = global::DelegateUtils.ToManualReleaseDelegate<FLTweenVector2SetterDynamic>(new Action<FVector2D>(this.OnTweenUpdate));
		}

		// Token: 0x0603255A RID: 206170 RVA: 0x00C983DE File Offset: 0x00C965DE
		protected override void OnEnable()
		{
			this.AddEventListener();
		}

		// Token: 0x0603255B RID: 206171 RVA: 0x00C983E6 File Offset: 0x00C965E6
		protected override void OnDisable()
		{
			this.RemoveEventListener();
		}

		// Token: 0x0603255C RID: 206172 RVA: 0x00C983F0 File Offset: 0x00C965F0
		protected override void OnRemove()
		{
			this.KillPositionTweener(false);
			FLTweenVector2SetterDynamic tweenerDelegate = this.TweenerDelegate;
			if (tweenerDelegate != null && tweenerDelegate.IsBound())
			{
				global::DelegateUtils.ReleaseManualReleaseDelegate(new Action<FVector2D>(this.OnTweenUpdate));
			}
			this.TweenerDelegate = null;
			this.SafeArea = null;
			this.DangerousArea = null;
		}

		// Token: 0x0603255D RID: 206173 RVA: 0x00C9843E File Offset: 0x00C9663E
		public void KillTweening()
		{
			if (this.IsTweening)
			{
				this.KillPositionTweener(false);
			}
			this.IsTweening = false;
		}

		// Token: 0x0603255E RID: 206174 RVA: 0x00C98458 File Offset: 0x00C96658
		private void AddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.WorldMapDragInertia, new Action<Vector2D>(this.WorldMapDragInertia));
			Singleton<EventSystem>.Instance.Add(EEventName.WorldMapPointerDrag, new Action<Vector2D>(this.OnPointerDrag));
			Singleton<EventSystem>.Instance.Add(EEventName.WorldMapPointerDown, new Action(this.OnPointerDown));
			Singleton<EventSystem>.Instance.Add<float, EMapScaleSetType>(EEventName.WorldMapWheelAxisInput, new Action<float, EMapScaleSetType>(this.OnWheelInput));
			Singleton<EventSystem>.Instance.Add(EEventName.WorldMapJoystickMoveForward, new Action<float>(this.OnMoveForward));
			Singleton<EventSystem>.Instance.Add(EEventName.WorldMapJoystickMoveRight, new Action<float>(this.OnMoveRight));
			Singleton<EventSystem>.Instance.Add(EEventName.MoveWorldMapToPosition, new Action<global::Vector>(this.MoveToPosition));
		}

		// Token: 0x0603255F RID: 206175 RVA: 0x00C9852C File Offset: 0x00C9672C
		private void RemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.WorldMapDragInertia, new Action<Vector2D>(this.WorldMapDragInertia));
			Singleton<EventSystem>.Instance.Remove(EEventName.WorldMapPointerDrag, new Action<Vector2D>(this.OnPointerDrag));
			Singleton<EventSystem>.Instance.Remove(EEventName.WorldMapPointerDown, new Action(this.OnPointerDown));
			Singleton<EventSystem>.Instance.Remove<float, EMapScaleSetType>(EEventName.WorldMapWheelAxisInput, new Action<float, EMapScaleSetType>(this.OnWheelInput));
			Singleton<EventSystem>.Instance.Remove(EEventName.WorldMapJoystickMoveForward, new Action<float>(this.OnMoveForward));
			Singleton<EventSystem>.Instance.Remove(EEventName.WorldMapJoystickMoveRight, new Action<float>(this.OnMoveRight));
			Singleton<EventSystem>.Instance.Remove(EEventName.MoveWorldMapToPosition, new Action<global::Vector>(this.MoveToPosition));
		}

		// Token: 0x06032560 RID: 206176 RVA: 0x00C98600 File Offset: 0x00C96800
		public void PushMap(MarkItem markItem, bool bUseTween = true, EClampType clampType = EClampType.ClampToDangerousArea)
		{
			if (this.UiParams == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.Map, ELogAuthor.LYX, "请于根节点挂KuroWorldMapUIParams组件", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			this.PushMapByUiPosition(markItem.UiPosition, bUseTween, clampType);
		}

		// Token: 0x06032561 RID: 206177 RVA: 0x00C98640 File Offset: 0x00C96840
		public void PushMapByUiPosition(global::Vector uiPosition, bool bUseTween = true, EClampType clampType = EClampType.ClampToDangerousArea)
		{
			if (this.UiParams == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.Map, ELogAuthor.YSQ, "请于根节点挂KuroWorldMapUIParams组件", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			double x = uiPosition.X;
			double y = uiPosition.Y;
			FVector2D anchorOffset = this.WorldMapUiComponent.Map.GetRootItem().GetAnchorOffset();
			double num = x * (double)this.MapScale + (double)anchorOffset.X;
			double num2 = y * (double)this.MapScale + (double)anchorOffset.Y;
			float x2 = this.UiParams.FocusMark_AnchoredPosition.X;
			float y2 = this.UiParams.FocusMark_AnchoredPosition.Y;
			if (Math.Abs(num - (double)x2) < 9.99999993922529E-09 && Math.Abs(num2 - (double)y2) < 9.99999993922529E-09)
			{
				Singleton<EventSystem>.Instance.Emit(EEventName.WorldMapPositionChanged);
				Singleton<EventSystem>.Instance.Emit(EEventName.WorldMapUpdateMultiMap);
				return;
			}
			Vector2D inTarget = Vector2D.Create(-x * (double)this.MapScale + (double)x2, -y * (double)this.MapScale + (double)y2);
			this.SetMapPosition(inTarget, bUseTween, clampType, new LTweenEase?(this.UiParams.TweenTypeEase), new float?(this.UiParams.TweenTime), true, true);
		}

		// Token: 0x06032562 RID: 206178 RVA: 0x00C98778 File Offset: 0x00C96978
		[NullableContext(2)]
		public void SetMapPosition(object inTarget, bool bUseTween, EClampType clampType = EClampType.NotClamp, LTweenEase? tweenEase = null, float? tweenTime = null, bool sendEvent = true, bool disableDrag = false)
		{
			if (inTarget == null)
			{
				return;
			}
			if (this.UiParams == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.Map, ELogAuthor.LYX, "请于根节点挂KuroWorldMapUIParams组件", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			Vector2D vector2D = Vector2D.Create();
			Vector2D vector2D2 = inTarget as Vector2D;
			if (vector2D2 != null)
			{
				vector2D.DeepCopy(vector2D2);
			}
			else
			{
				MarkItem markItem = inTarget as MarkItem;
				if (markItem != null)
				{
					vector2D.X = markItem.UiPosition.X;
					vector2D.Y = markItem.UiPosition.Y;
					vector2D.MultiplyEqual((double)this.MapScale).UnaryNegation(vector2D);
				}
			}
			Vector2D position = Vector2D.Create(vector2D.X, vector2D.Y);
			vector2D = this.ClampPosition(position, clampType, false);
			if (!bUseTween)
			{
				this.SetMapAnchorOffset(vector2D);
				if (sendEvent)
				{
					this.<SetMapPosition>g__SendEventAction|46_0();
				}
				return;
			}
			FVector2D anchorOffset = this.WorldMapUiComponent.Map.GetRootItem().GetAnchorOffset();
			FVector2D fvector2D = vector2D.ToUeVector2D(false);
			if (this.NearlyPosition(anchorOffset, fvector2D))
			{
				this.SetMapAnchorOffset(vector2D);
				this.<SetMapPosition>g__SendEventAction|46_0();
				return;
			}
			this.KillPositionTweener(false);
			this.IsDragDisabled = disableDrag;
			this.IsTweening = true;
			this.TweenTargetInner = vector2D;
			this.PositionTweener = ULTweenBPLibrary.Vector2To(GlobalData.World, this.TweenerDelegate, anchorOffset, fvector2D, tweenTime.GetValueOrDefault(), 0f, tweenEase.GetValueOrDefault());
			this.PositionTweener.OnCompleteCallBack.Bind(delegate()
			{
				this.TweenTargetInner = null;
				this.IsTweening = false;
				this.IsDragDisabled = false;
				this.<SetMapPosition>g__SendEventAction|46_0();
			});
		}

		// Token: 0x06032563 RID: 206179 RVA: 0x00C988E0 File Offset: 0x00C96AE0
		public void SetMapPositionCauseByScaling(Vector2D focusPosition, [Nullable(2)] Vector2D targetPosition, EClampType clampType = EClampType.NotClamp)
		{
			bool isTweeningMove = this.IsTweeningMove;
			this.KillTweening();
			this.SetMapPosition(focusPosition, false, clampType, null, null, true, false);
			if (targetPosition != null)
			{
				this.SetMapPosition(targetPosition, isTweeningMove, clampType, null, null, true, false);
			}
		}

		// Token: 0x06032564 RID: 206180 RVA: 0x00C98938 File Offset: 0x00C96B38
		public void FocusPlayer(Vector2D playerPosition, bool bUseTween = false, EClampType clampType = EClampType.NotClamp)
		{
			Vector2D vector2D = Vector2D.Create();
			playerPosition.Multiply((double)this.MapScale, vector2D).UnaryNegation(vector2D);
			this.SetMapPosition(vector2D, bUseTween, clampType, new LTweenEase?(this.UiParams.TweenTypeEase), new float?(this.UiParams.TweenTime), true, true);
		}

		// Token: 0x06032565 RID: 206181 RVA: 0x00C9898C File Offset: 0x00C96B8C
		public void TickMoveDirty()
		{
			if (!this.IsMoveForwardDirty && !this.IsMoveRightDirty)
			{
				return;
			}
			Vector2D vector2D = Vector2D.Create(this.MapUiPosition);
			float moveSpeedMultiplier = this.GetMoveSpeedMultiplier();
			if (this.IsMoveForwardDirty)
			{
				vector2D.AdditionEqual(this.ForwardVector.MultiplyEqual((double)moveSpeedMultiplier));
				this.IsMoveForwardDirty = false;
			}
			if (this.IsMoveRightDirty)
			{
				vector2D.AdditionEqual(this.RightVector.MultiplyEqual((double)moveSpeedMultiplier));
				this.IsMoveRightDirty = false;
			}
			this.SetMapPosition(vector2D, false, EClampType.ClampToDangerousArea, null, null, true, false);
		}

		// Token: 0x06032566 RID: 206182 RVA: 0x00C98A20 File Offset: 0x00C96C20
		private void SetMapAnchorOffset(Vector2D targetPosition)
		{
			this.WorldMapUiComponent.Map.GetRootItem().SetAnchorOffset(targetPosition.ToUeVector2D(false));
			this.MapUiPositionInner = targetPosition;
			this.SyncUnlockFogAnchorItemPosition(targetPosition);
		}

		// Token: 0x06032567 RID: 206183 RVA: 0x00C98A4C File Offset: 0x00C96C4C
		private void SyncUnlockFogAnchorItemPosition(Vector2D mapPosition)
		{
			Vector2D vector2D = Vector2D.Create(mapPosition.X, mapPosition.Y);
			BaseMap map = this.WorldMapUiComponent.Map;
			float mapScale = ModelBase<WorldMapModel>.Instance.MapScale;
			vector2D.DivisionEqual((double)mapScale);
			vector2D.UnaryNegation(vector2D);
			map.FogUnlockAnchorItem.SetAnchorOffset(vector2D.ToUeVector2D(false));
		}

		// Token: 0x06032568 RID: 206184 RVA: 0x00C98AA4 File Offset: 0x00C96CA4
		private bool NearlyPosition(FVector2D srcPosition, FVector2D dstPosition)
		{
			return Singleton<MathUtils>.Instance.IsNearlyEqual((double)srcPosition.X, (double)dstPosition.X, null) && Singleton<MathUtils>.Instance.IsNearlyEqual((double)srcPosition.Y, (double)dstPosition.Y, null);
		}

		// Token: 0x06032569 RID: 206185 RVA: 0x00C98AF8 File Offset: 0x00C96CF8
		private Vector2D ClampPosition(Vector2D position, EClampType type, bool dontNew = false)
		{
			double x = position.X;
			double y = position.Y;
			switch (type)
			{
			case EClampType.ClampToSafeArea:
				x = MathCommon.Clamp(position.X, this.SafeAreaSize.MinX, this.SafeAreaSize.MaxX);
				y = MathCommon.Clamp(position.Y, this.SafeArea.MinY, this.SafeArea.MaxY);
				break;
			case EClampType.ClampToDangerousArea:
				x = MathCommon.Clamp(position.X, this.DangerousAreaSize.MinX, this.DangerousAreaSize.MaxX);
				y = MathCommon.Clamp(position.Y, this.DangerousAreaSize.MinY, this.DangerousAreaSize.MaxY);
				break;
			}
			Vector2D vector2D = position;
			if (dontNew || type == EClampType.NotClamp)
			{
				vector2D.X = x;
				vector2D.Y = y;
			}
			else
			{
				vector2D = Vector2D.Create(x, y);
			}
			return vector2D;
		}

		// Token: 0x0603256A RID: 206186 RVA: 0x00C98BD5 File Offset: 0x00C96DD5
		private void KillPositionTweener(bool callComplete = false)
		{
			ULTweener positionTweener = this.PositionTweener;
			if (positionTweener != null && positionTweener.IsValid())
			{
				this.PositionTweener.Kill(callComplete);
				this.PositionTweener = null;
			}
			this.TweenTargetInner = null;
			this.IsTweening = false;
			this.IsDragDisabled = false;
		}

		// Token: 0x0603256B RID: 206187 RVA: 0x00C98C14 File Offset: 0x00C96E14
		private void OnTweenUpdate(FVector2D value)
		{
			Vector2D inTarget = Vector2D.Create(value);
			this.SetMapPosition(inTarget, false, EClampType.ClampToDangerousArea, null, null, true, false);
		}

		// Token: 0x0603256C RID: 206188 RVA: 0x00C98C4C File Offset: 0x00C96E4C
		private void WorldMapDragInertia(Vector2D speed)
		{
			Vector2D vector2D = Vector2D.Create();
			speed.Multiply((double)this.UiParams.TweenTime, vector2D);
			Vector2D inTarget = Vector2D.Create(this.MapUiPosition).AdditionEqual(vector2D);
			this.SetMapPosition(inTarget, true, EClampType.ClampToSafeArea, new LTweenEase?(LTweenEase.OutQuad), new float?(ConfigCommonParamById.GetFloatConfig("MapDragInertiaTime").GetValueOrDefault()), true, false);
		}

		// Token: 0x0603256D RID: 206189 RVA: 0x00C98CAD File Offset: 0x00C96EAD
		private void OnPointerDown()
		{
			if (this.IsDragDisabled)
			{
				return;
			}
			this.KillPositionTweener(true);
		}

		// Token: 0x0603256E RID: 206190 RVA: 0x00C98CBF File Offset: 0x00C96EBF
		private void OnWheelInput(float f, EMapScaleSetType eMapScaleSetType)
		{
		}

		// Token: 0x0603256F RID: 206191 RVA: 0x00C98CC1 File Offset: 0x00C96EC1
		private void OnPointerDrag(Vector2D delta)
		{
			if (this.IsDragDisabled)
			{
				return;
			}
			this.MoveByDelta(delta);
		}

		// Token: 0x06032570 RID: 206192 RVA: 0x00C98CD3 File Offset: 0x00C96ED3
		private void OnMoveForward(float delta)
		{
			this.ForwardVector.Y = (double)delta;
			this.IsMoveForwardDirty = true;
		}

		// Token: 0x06032571 RID: 206193 RVA: 0x00C98CE9 File Offset: 0x00C96EE9
		private void OnMoveRight(float delta)
		{
			this.RightVector.X = (double)delta;
			this.IsMoveRightDirty = true;
		}

		// Token: 0x06032572 RID: 206194 RVA: 0x00C98D00 File Offset: 0x00C96F00
		private void MoveToPosition(global::Vector worldPosition)
		{
			Vector2D vector2D = MapUtil.WorldPosition2UiPosition2D(Vector2D.Create(worldPosition.X, worldPosition.Y), null);
			float mapScale = ModelBase<WorldMapModel>.Instance.MapScale;
			vector2D.UnaryNegation(vector2D);
			vector2D.MultiplyEqual((double)mapScale);
			this.SetMapPosition(vector2D, false, EClampType.ClampToDangerousArea, null, null, true, false);
		}

		// Token: 0x06032573 RID: 206195 RVA: 0x00C98D60 File Offset: 0x00C96F60
		private void MoveByDelta(Vector2D delta)
		{
			Vector2D vector2D = Vector2D.Create(this.MapUiPosition);
			this.SetMapPosition(vector2D.AdditionEqual(delta), false, EClampType.ClampToDangerousArea, null, null, true, false);
		}

		// Token: 0x06032574 RID: 206196 RVA: 0x00C98D9C File Offset: 0x00C96F9C
		private float GetMoveSpeedMultiplier()
		{
			WorldMapModel instance = ModelBase<WorldMapModel>.Instance;
			float valueOrDefault = ConfigCommonParamById.GetFloatConfig("MapDragSpeedMultiplier").GetValueOrDefault(1f);
			float num = instance.MapScaleMax - instance.MapScaleMin;
			if (num > 0f)
			{
				return (instance.MapScale - instance.MapScaleMin) * (1f - valueOrDefault) / num + valueOrDefault;
			}
			return 1f;
		}

		// Token: 0x06032575 RID: 206197 RVA: 0x00C98DFC File Offset: 0x00C96FFC
		[CompilerGenerated]
		private void <SetMapPosition>g__SendEventAction|46_0()
		{
			Singleton<EventSystem>.Instance.Emit(EEventName.WorldMapPositionChanged);
			if (!this.IsTweening)
			{
				Singleton<EventSystem>.Instance.Emit(EEventName.WorldMapUpdateMultiMap);
			}
		}

		// Token: 0x0401D676 RID: 120438
		private bool IsTweening;

		// Token: 0x0401D677 RID: 120439
		private bool IsDragDisabled;

		// Token: 0x0401D678 RID: 120440
		[Nullable(2)]
		private Vector2D TweenTargetInner;

		// Token: 0x0401D679 RID: 120441
		[Nullable(2)]
		private ULTweener PositionTweener;

		// Token: 0x0401D67A RID: 120442
		[Nullable(2)]
		private FLTweenVector2SetterDynamic TweenerDelegate;

		// Token: 0x0401D67B RID: 120443
		[Nullable(2)]
		private IArea SafeArea;

		// Token: 0x0401D67C RID: 120444
		[Nullable(2)]
		private IArea DangerousArea;

		// Token: 0x0401D67D RID: 120445
		private readonly Vector2D ForwardVector = Vector2D.Create();

		// Token: 0x0401D67E RID: 120446
		private readonly Vector2D RightVector = Vector2D.Create();

		// Token: 0x0401D67F RID: 120447
		[Nullable(2)]
		private Vector2D MapUiPositionInner;

		// Token: 0x0401D680 RID: 120448
		private bool IsMoveForwardDirty;

		// Token: 0x0401D681 RID: 120449
		private bool IsMoveRightDirty;
	}
}
