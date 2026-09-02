using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MoonChasing
{
	// Token: 0x0200673B RID: 26427
	[NullableContext(1)]
	[Nullable(0)]
	public class BuildingMapMoveComponent
	{
		// Token: 0x1700A0B4 RID: 41140
		// (get) Token: 0x06041E80 RID: 269952 RVA: 0x010E8FC8 File Offset: 0x010E71C8
		// (set) Token: 0x06041E81 RID: 269953 RVA: 0x010E8FD0 File Offset: 0x010E71D0
		public double MapScale
		{
			get
			{
				return this.MapScaleInternal;
			}
			set
			{
				this.MapScaleInternal = value;
			}
		}

		// Token: 0x1700A0B5 RID: 41141
		// (get) Token: 0x06041E82 RID: 269954 RVA: 0x010E8FD9 File Offset: 0x010E71D9
		public bool IsInDrag
		{
			get
			{
				return this.IsDragging;
			}
		}

		// Token: 0x06041E83 RID: 269955 RVA: 0x010E8FE4 File Offset: 0x010E71E4
		public BuildingMapMoveComponent(UUIDraggableComponent draggable, bool bindDrag = true, bool bindScroll = true, bool bindEndDrag = false)
		{
			this.MapItem = draggable.GetRootComponent();
			if (bindDrag)
			{
				draggable.OnPointerBeginDragCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnPointerBeginDragCallBack));
				if (bindEndDrag)
				{
					draggable.OnPointerEndDragCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnPointerUp));
				}
				else
				{
					draggable.OnPointerUpCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnPointerUp));
				}
				draggable.OnPointerDragCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnPointerDragCallBack));
				draggable.OnPointerDownCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnPointerDown));
				draggable.OnPointerCancelCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnPointerUp));
			}
			if (bindScroll)
			{
				draggable.OnPointerScrollCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnPointerScrollCallback));
			}
			this.InitData();
		}

		// Token: 0x06041E84 RID: 269956 RVA: 0x010E924D File Offset: 0x010E744D
		private void InitData()
		{
			this.InitPosTweener();
			this.InitScaleTweener();
			this.InitViewportSize();
			this.InitScaleSafeArea();
			this.UpdateMoveDangerousArea();
			this.UpdateMoveSafeArea();
		}

		// Token: 0x06041E85 RID: 269957 RVA: 0x010E9273 File Offset: 0x010E7473
		private void InitPosTweener()
		{
			this.Delegate = global::DelegateUtils.ToManualReleaseDelegate<FLTweenVector2SetterDynamic>(new Action<FVector2D>(this.OnTweenUpdate));
		}

		// Token: 0x06041E86 RID: 269958 RVA: 0x010E928C File Offset: 0x010E748C
		private void InitScaleTweener()
		{
			this.ScaleDelegate = global::DelegateUtils.ToManualReleaseDelegate<FLTweenVector3SetterDynamic>(new Action<FVector>(this.OnScaleTweenUpdate));
		}

		// Token: 0x06041E87 RID: 269959 RVA: 0x010E92A8 File Offset: 0x010E74A8
		private unsafe void InitViewportSize()
		{
			this.ViewportSize.X = (double)Singleton<UiLayer>.Instance.UiRootItem.GetWidth();
			this.ViewportSize.Y = (double)Singleton<UiLayer>.Instance.UiRootItem.GetHeight();
			ULGUICanvasScaler canvasScaler = Singleton<UiLayer>.Instance.UiRootItem.GetCanvasScaler();
			float num = canvasScaler.ReferenceResolution.X / canvasScaler.ReferenceResolution.Y;
			double num2 = this.ViewportSize.X / this.ViewportSize.Y;
			double num3 = num2 / (double)num;
			this.SizeInterval = ((num3 > 1.0) ? num3 : ((double)num / num2));
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.MoonChasing;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "[MapMoveComponent]初始化Viewport";
			<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Viewport大小", this.ViewportSize);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("ReferenceResolution大小", canvasScaler.ReferenceResolution);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("Viewport与ReferenceResolution比值", num3);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("实际应用的比值", this.SizeInterval);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
		}

		// Token: 0x06041E88 RID: 269960 RVA: 0x010E93F0 File Offset: 0x010E75F0
		protected virtual void UpdateMoveDangerousArea()
		{
			double num = (double)this.MapItem.GetWidth() * this.MapScaleInternal;
			double num2 = (double)this.MapItem.GetHeight() * this.MapScaleInternal;
			num = ((num < this.ViewportSize.X) ? this.ViewportSize.X : num);
			num2 = ((num2 < this.ViewportSize.Y) ? this.ViewportSize.Y : num2);
			double num3 = Math.Abs(num - this.ViewportSize.X) / 2.0;
			double num4 = Math.Abs(num2 - this.ViewportSize.Y) / 2.0;
			this.MoveDangerousArea.MinX = -num3;
			this.MoveDangerousArea.MaxX = num3;
			this.MoveDangerousArea.MinY = -num4;
			this.MoveDangerousArea.MaxY = num4;
		}

		// Token: 0x06041E89 RID: 269961 RVA: 0x010E94CC File Offset: 0x010E76CC
		protected virtual void UpdateMoveSafeArea()
		{
			double num = ((double)this.MapItem.GetWidth() - this.MapMoveRebound.X * 2.0) * this.MapScaleInternal;
			double num2 = ((double)this.MapItem.GetHeight() - this.MapMoveRebound.Y * 2.0) * this.MapScaleInternal;
			num = ((num < this.ViewportSize.X) ? this.ViewportSize.X : num);
			num2 = ((num2 < this.ViewportSize.Y) ? this.ViewportSize.Y : num2);
			double num3 = Math.Abs(num - this.ViewportSize.X) / 2.0;
			double num4 = Math.Abs(num2 - this.ViewportSize.Y) / 2.0;
			this.MoveSafeArea.MinX = -num3;
			this.MoveSafeArea.MaxX = num3;
			this.MoveSafeArea.MinY = -num4;
			this.MoveSafeArea.MaxY = num4;
		}

		// Token: 0x06041E8A RID: 269962 RVA: 0x010E95D4 File Offset: 0x010E77D4
		private void InitScaleSafeArea()
		{
			this.SetScaleSafeArea(0.5, 2.0);
			this.MapMoveRebound.X = 400.0;
			this.MapMoveRebound.Y = 300.0;
		}

		// Token: 0x06041E8B RID: 269963 RVA: 0x010E9624 File Offset: 0x010E7824
		private void ClampByMoveSafeArea(Vector2D vector2D)
		{
			vector2D.X = Singleton<MathUtils>.Instance.Clamp(vector2D.X, this.MoveSafeArea.MinX, this.MoveSafeArea.MaxX);
			vector2D.Y = Singleton<MathUtils>.Instance.Clamp(vector2D.Y, this.MoveSafeArea.MinY, this.MoveSafeArea.MaxY);
		}

		// Token: 0x06041E8C RID: 269964 RVA: 0x010E968C File Offset: 0x010E788C
		private void ClampByMoveDangerousArea(Vector2D vector2D)
		{
			vector2D.X = Singleton<MathUtils>.Instance.Clamp(vector2D.X, this.MoveDangerousArea.MinX, this.MoveDangerousArea.MaxX);
			vector2D.Y = Singleton<MathUtils>.Instance.Clamp(vector2D.Y, this.MoveDangerousArea.MinY, this.MoveDangerousArea.MaxY);
		}

		// Token: 0x06041E8D RID: 269965 RVA: 0x010E96F4 File Offset: 0x010E78F4
		[NullableContext(2)]
		public void SetScale(double scale, ESetScaleSource source, Vector2D targetPos = null)
		{
			double num = Singleton<MathUtils>.Instance.Clamp(scale, this.MapScaleSafeArea.Min, this.MapScaleSafeArea.Max);
			if (num == this.MapScaleInternal && source != ESetScaleSource.Tween)
			{
				return;
			}
			this.KillPosTweener();
			double mapScaleInternal = this.MapScaleInternal;
			this.MapScaleInternal = num;
			this.UpdateMoveDangerousArea();
			this.UpdateMoveSafeArea();
			this.TempVector.Set(num, num, num);
			UUIItem mapItem = this.MapItem;
			FVector fvector = this.TempVector.ToUeVectorOld();
			mapItem.SetUIRelativeScale3D(fvector);
			Vector2D realPosition = this.GetRealPosition(num, mapScaleInternal, source, targetPos);
			this.TempVector2D.Reset();
			this.TempVector2D.AdditionEqual(realPosition);
			this.MoveToTargetPos(this.TempVector2D, EClampType.ClampToSafeArea);
			Action<ESetScaleSource> changeScaleCallback = this.ChangeScaleCallback;
			if (changeScaleCallback == null)
			{
				return;
			}
			changeScaleCallback(source);
		}

		// Token: 0x06041E8E RID: 269966 RVA: 0x010E97BC File Offset: 0x010E79BC
		private Vector2D GetRealPosition(double newScale, double oldScale, ESetScaleSource source, [Nullable(2)] Vector2D targetPos = null)
		{
			Vector2D vector2D = Vector2D.Create(this.MapItem.GetAnchorOffset());
			if (source <= ESetScaleSource.MultiTouch)
			{
				Vector2D mousePosConverToLgui = this.GetMousePosConverToLgui(this.InteractCenterPoint.X, this.InteractCenterPoint.Y);
				mousePosConverToLgui.Set(mousePosConverToLgui.X - this.ViewportSize.X / 2.0, mousePosConverToLgui.Y - this.ViewportSize.Y / 2.0);
				return vector2D.SubtractionEqual(mousePosConverToLgui).MultiplyEqual(newScale / oldScale).AdditionEqual(mousePosConverToLgui);
			}
			if (source != ESetScaleSource.Tween)
			{
				return vector2D.MultiplyEqual(newScale / oldScale);
			}
			if (targetPos != null)
			{
				return targetPos.MultiplyEqual(-1.0).MultiplyEqual(this.MapScale);
			}
			return vector2D.MultiplyEqual(newScale / oldScale);
		}

		// Token: 0x06041E8F RID: 269967 RVA: 0x010E9890 File Offset: 0x010E7A90
		private Vector2D GetMousePosConverToLgui(double mousePosX, double mousePosY)
		{
			ULGUICanvasScaler canvasScaler = Singleton<UiLayer>.Instance.UiRootItem.GetCanvasScaler();
			if (canvasScaler == null)
			{
				return Vector2D.Create();
			}
			Vector2D vector2D = Vector2D.Create(mousePosX, mousePosY);
			ULGUICanvasScaler ulguicanvasScaler = canvasScaler;
			FVector2D fvector2D = vector2D.ToUeVector2D(false);
			FVector2D fvector2D2 = ulguicanvasScaler.ConvertPositionFromViewportToLGUICanvas(fvector2D);
			vector2D.FromUeVector2D(fvector2D2);
			vector2D.X = MathCommon.Clamp(vector2D.X, 0.0, this.ViewportSize.X);
			vector2D.Y = MathCommon.Clamp(vector2D.Y, 0.0, this.ViewportSize.Y);
			return vector2D;
		}

		// Token: 0x06041E90 RID: 269968 RVA: 0x010E9928 File Offset: 0x010E7B28
		[NullableContext(2)]
		private void OnPointerBeginDragCallBack(ULGUIPointerEventData eventData)
		{
			if (this.IsInMultiTouch)
			{
				return;
			}
			this.KillPosTweener();
			FVector pointerPosition = eventData.pointerPosition;
			Vector2D mousePosConverToLgui = this.GetMousePosConverToLgui((double)pointerPosition.X, (double)pointerPosition.Y);
			this.LastDragPos.DeepCopy(mousePosConverToLgui);
			Action<ULGUIPointerEventData> pointerBeginDragExtraCallBack = this.PointerBeginDragExtraCallBack;
			if (pointerBeginDragExtraCallBack == null)
			{
				return;
			}
			pointerBeginDragExtraCallBack(eventData);
		}

		// Token: 0x06041E91 RID: 269969 RVA: 0x010E9980 File Offset: 0x010E7B80
		[NullableContext(2)]
		private void OnPointerDragCallBack(ULGUIPointerEventData eventData)
		{
			if (this.IsInMultiTouch)
			{
				this.IsDragging = false;
				this.PointerDeltaPos.Reset();
				return;
			}
			this.IsDragging = true;
			FVector pointerPosition = eventData.pointerPosition;
			Vector2D mousePosConverToLgui = this.GetMousePosConverToLgui((double)pointerPosition.X, (double)pointerPosition.Y);
			Vector2D vector2D = Vector2D.Create(mousePosConverToLgui.X, mousePosConverToLgui.Y).SubtractionEqual(this.LastDragPos);
			if (vector2D.X == 0.0 && vector2D.Y == 0.0)
			{
				return;
			}
			double num = mousePosConverToLgui.X - this.LastDragPos.X;
			double num2 = mousePosConverToLgui.Y - this.LastDragPos.Y;
			this.PointerDeltaPos.DeepCopy(vector2D);
			this.LastDragPos.DeepCopy(mousePosConverToLgui);
			this.TempVector2D.FromUeVector2D(this.MapItem.GetAnchorOffset());
			this.TempVector2D.X = this.TempVector2D.X + num;
			this.TempVector2D.Y = this.TempVector2D.Y + num2;
			this.MoveToTargetPos(this.TempVector2D, EClampType.ClampToDangerousArea);
		}

		// Token: 0x06041E92 RID: 269970 RVA: 0x010E9AA3 File Offset: 0x010E7CA3
		public void EmitPointerDown()
		{
			this.PointerDownTime = Singleton<Time>.Instance.NowSeconds;
		}

		// Token: 0x06041E93 RID: 269971 RVA: 0x010E9AB5 File Offset: 0x010E7CB5
		[NullableContext(2)]
		private void OnPointerDown(ULGUIPointerEventData eventData)
		{
			if (eventData == null || this.IsInMultiTouch || !this.CheckPointInScope(eventData.pointerPosition))
			{
				return;
			}
			this.IsDragging = true;
			this.PointerDownTime = Singleton<Time>.Instance.NowSeconds;
		}

		// Token: 0x06041E94 RID: 269972 RVA: 0x010E9AE8 File Offset: 0x010E7CE8
		[NullableContext(2)]
		private void OnPointerUp(ULGUIPointerEventData eventData)
		{
			if (this.IsInMultiTouch)
			{
				return;
			}
			this.IsDragging = false;
			if (this.PointerDeltaPos.X == 0.0 && this.PointerDeltaPos.Y == 0.0)
			{
				return;
			}
			if (!this.CheckPointInScope(eventData.pointerPosition))
			{
				return;
			}
			this.HandleDragInertia();
			Action<ULGUIPointerEventData> pointerUpExtraCallBack = this.PointerUpExtraCallBack;
			if (pointerUpExtraCallBack == null)
			{
				return;
			}
			pointerUpExtraCallBack(eventData);
		}

		// Token: 0x06041E95 RID: 269973 RVA: 0x010E9B58 File Offset: 0x010E7D58
		[NullableContext(2)]
		private void OnPointerScrollCallback(ULGUIPointerEventData eventData)
		{
			float scrollAxisValue = eventData.scrollAxisValue;
			if (scrollAxisValue == 0f)
			{
				return;
			}
			this.InteractCenterPoint.Reset();
			this.InteractCenterPoint.AdditionEqual(this.GetCursorPoint());
			double num = (double)scrollAxisValue * this.ScaleStep;
			this.SetScale(this.MapScaleInternal + num, ESetScaleSource.PointerScroll, null);
		}

		// Token: 0x06041E96 RID: 269974 RVA: 0x010E9BAC File Offset: 0x010E7DAC
		private void OnTweenUpdate(FVector2D targetPos)
		{
			this.MapItem.SetAnchorOffset(targetPos);
		}

		// Token: 0x06041E97 RID: 269975 RVA: 0x010E9BBA File Offset: 0x010E7DBA
		private void OnScaleTweenUpdate(FVector targetScale)
		{
			this.ScaleTempPos.Set((double)targetScale.Y, (double)targetScale.Z);
			this.SetScale((double)targetScale.X, ESetScaleSource.Tween, this.ScaleTempPos);
		}

		// Token: 0x06041E98 RID: 269976 RVA: 0x010E9BEC File Offset: 0x010E7DEC
		private bool CheckPointInScope(FVector mousePos)
		{
			Vector2D mousePosConverToLgui = this.GetMousePosConverToLgui((double)mousePos.X, (double)mousePos.Y);
			return mousePosConverToLgui.X >= 0.0 && mousePosConverToLgui.X <= this.ViewportSize.X && mousePosConverToLgui.Y >= 0.0 && mousePosConverToLgui.Y <= this.ViewportSize.Y;
		}

		// Token: 0x06041E99 RID: 269977 RVA: 0x010E9C5C File Offset: 0x010E7E5C
		private void HandleDragInertia()
		{
			double num = Singleton<Time>.Instance.NowSeconds - this.PointerDownTime;
			double num2 = this.PointerDeltaPos.Size() / num;
			if (!this.ViewportSize.IsNearlyZero(9.999999747378752E-05))
			{
				num2 = MathCommon.Clamp(num2, 0.0, this.ViewportSize.Size());
			}
			if (!this.PointerDeltaPos.Normalize(0.0))
			{
				this.PointerDeltaPos.Reset();
				return;
			}
			Vector2D vector2D = Vector2D.Create();
			this.PointerDeltaPos.Multiply(num2, vector2D);
			Vector2D vector2D2 = Vector2D.Create();
			vector2D.Multiply(2.0, vector2D2);
			Vector2D targetPos = Vector2D.Create(this.MapItem.GetAnchorOffset()).AdditionEqual(vector2D2);
			this.MoveToTargetPosWithTween(targetPos, LTweenEase.OutQuad, 0.800000011920929);
		}

		// Token: 0x06041E9A RID: 269978 RVA: 0x010E9D36 File Offset: 0x010E7F36
		private void KillPosTweener()
		{
			if (this.PosTweener != null)
			{
				this.PosTweener.Kill(false);
				this.PosTweener = null;
			}
		}

		// Token: 0x06041E9B RID: 269979 RVA: 0x010E9D53 File Offset: 0x010E7F53
		private void KillScaleTweener()
		{
			if (this.ScaleTweener != null)
			{
				this.ScaleTweener.Kill(false);
				this.ScaleTweener = null;
			}
		}

		// Token: 0x06041E9C RID: 269980 RVA: 0x010E9D70 File Offset: 0x010E7F70
		private void MoveToTargetPosWithTween(Vector2D targetPos, LTweenEase tweenEase = LTweenEase.Linear, double tweenTime = 2.0)
		{
			this.ClampByMoveSafeArea(targetPos);
			this.IsTweening = true;
			this.KillPosTweener();
			this.PosTweener = ULTweenBPLibrary.Vector2To(GlobalData.World, this.Delegate, this.MapItem.GetAnchorOffset(), targetPos.ToUeVector2D(false), (float)tweenTime, 0f, tweenEase);
			this.PosTweener.OnCompleteCallBack.Bind(delegate()
			{
				this.IsTweening = false;
			});
		}

		// Token: 0x06041E9D RID: 269981 RVA: 0x010E9DDD File Offset: 0x010E7FDD
		private void MoveToTargetPos(Vector2D targetPos, EClampType clampType = EClampType.ClampToSafeArea)
		{
			if (clampType == EClampType.ClampToSafeArea)
			{
				this.ClampByMoveSafeArea(targetPos);
			}
			else if (clampType == EClampType.ClampToDangerousArea)
			{
				this.ClampByMoveDangerousArea(targetPos);
			}
			this.MapItem.SetAnchorOffset(targetPos.ToUeVector2D(false));
		}

		// Token: 0x06041E9E RID: 269982 RVA: 0x010E9E08 File Offset: 0x010E8008
		public void MoveToTarget(double[] offsetXY, LTweenEase tweenEase = LTweenEase.Linear, double tweenTime = 2.0, [Nullable(2)] Action callback = null)
		{
			this.TempVector2D.Reset();
			this.TempVector2D.X = -offsetXY[0] * this.MapScale;
			this.TempVector2D.Y = -offsetXY[1] * this.MapScale;
			if (tweenTime != 0.0)
			{
				this.MoveToTargetPosWithTween(this.TempVector2D, tweenEase, tweenTime);
				if (callback != null)
				{
					callback();
					return;
				}
			}
			else
			{
				this.MoveToTargetPos(this.TempVector2D, EClampType.ClampToSafeArea);
				if (callback != null)
				{
					callback();
				}
			}
		}

		// Token: 0x06041E9F RID: 269983 RVA: 0x010E9E8C File Offset: 0x010E808C
		public void ScaleToTarget(double scale, float[] offset, LTweenEase tweenEase = LTweenEase.Linear, float tweenTime = 2f, ETweenScaleType tweenScaleType = ETweenScaleType.Normal, [Nullable(2)] Action callback = null)
		{
			double targetScale = scale;
			if (tweenScaleType == ETweenScaleType.PreventOverScaling)
			{
				targetScale = ((this.MapScale > scale) ? this.MapScale : scale);
			}
			else if (tweenScaleType == ETweenScaleType.PreventUnderScaling)
			{
				targetScale = ((this.MapScale < scale) ? this.MapScale : scale);
			}
			if (tweenTime != 0f)
			{
				this.ScaleToTargetScaleWithTween(targetScale, offset, tweenEase, tweenTime);
				if (callback != null)
				{
					callback();
					return;
				}
			}
			else
			{
				this.ScaleTempPos.Set((double)offset[0], (double)offset[1]);
				this.SetScale(scale, ESetScaleSource.Tween, this.ScaleTempPos);
				if (callback != null)
				{
					callback();
				}
			}
		}

		// Token: 0x06041EA0 RID: 269984 RVA: 0x010E9F1C File Offset: 0x010E811C
		private void ScaleToTargetScaleWithTween(double targetScale, float[] offset, LTweenEase tweenEase = LTweenEase.Linear, float tweenTime = 2f)
		{
			this.IsTweening = true;
			this.KillScaleTweener();
			FVector2D anchorOffset = this.MapItem.GetAnchorOffset();
			this.ScaleTempStartVector.Set(this.MapScaleInternal, (double)(-(double)anchorOffset.X) / this.MapScaleInternal, (double)(-(double)anchorOffset.Y) / this.MapScaleInternal);
			this.ScaleTempEndVector.Set(targetScale, (double)offset[0], (double)offset[1]);
			this.ScaleTweener = ULTweenBPLibrary.Vector3To(GlobalData.World, this.ScaleDelegate, this.ScaleTempStartVector.ToUeVectorOld(), this.ScaleTempEndVector.ToUeVectorOld(), tweenTime, 0f, tweenEase);
			this.ScaleTweener.OnCompleteCallBack.Bind(delegate()
			{
				this.IsTweening = false;
			});
		}

		// Token: 0x06041EA1 RID: 269985 RVA: 0x010E9FD8 File Offset: 0x010E81D8
		private Vector2D GetCursorPoint()
		{
			TsCharacterController characterController = Global.CharacterController;
			if (characterController != null)
			{
				this.TempVector2D.Reset();
				return this.TempVector2D.AdditionEqual(characterController.GetCursorPosition());
			}
			this.TempVector2D.Reset();
			return this.TempVector2D;
		}

		// Token: 0x06041EA2 RID: 269986 RVA: 0x010EA01C File Offset: 0x010E821C
		private void OnGamepadMoveOverScreen(double overOffsetX, double overOffsetY)
		{
			this.TempVector2D.FromUeVector2D(this.MapItem.GetAnchorOffset());
			this.TempVector2D.X = this.TempVector2D.X - overOffsetX;
			this.TempVector2D.Y = this.TempVector2D.Y - overOffsetY;
			this.MoveToTargetPos(this.TempVector2D, EClampType.ClampToDangerousArea);
		}

		// Token: 0x06041EA3 RID: 269987 RVA: 0x010EA081 File Offset: 0x010E8281
		public void LongPressScroll(float value)
		{
			this.InteractCenterPoint.Reset();
			this.SetScale(this.MapScaleInternal + (double)value, ESetScaleSource.LongPress, null);
		}

		// Token: 0x06041EA4 RID: 269988 RVA: 0x010EA09F File Offset: 0x010E829F
		public void SliderScroll(float value)
		{
			this.SetScale((double)value, ESetScaleSource.Slider, null);
		}

		// Token: 0x06041EA5 RID: 269989 RVA: 0x010EA0AB File Offset: 0x010E82AB
		public void SetChangeScaleCallback(Action<ESetScaleSource> callback)
		{
			this.ChangeScaleCallback = callback;
		}

		// Token: 0x06041EA6 RID: 269990 RVA: 0x010EA0B4 File Offset: 0x010E82B4
		public unsafe void SetScaleSafeArea(double min, double max)
		{
			if (min > max)
			{
				this.MapScaleSafeArea.Min = max * this.SizeInterval;
				this.MapScaleSafeArea.Max = min * this.SizeInterval;
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.MoonChasing;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "[MapMoveComponent]按照分辨率比例设置真实大小";
				<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("设置最小", max);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("设置最大", min);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("真实最小", this.MapScaleSafeArea.Min);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("真实最大", this.MapScaleSafeArea.Max);
				instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
				return;
			}
			this.MapScaleSafeArea.Min = min * this.SizeInterval;
			this.MapScaleSafeArea.Max = max * this.SizeInterval;
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.MoonChasing;
			ELogAuthor author2 = ELogAuthor.XXJ;
			string message2 = "[MapMoveComponent]按照分辨率比例设置真实大小";
			<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray4<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("设置最小", min);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("设置最大", max);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("真实最小", this.MapScaleSafeArea.Min);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 3) = new ValueTuple<string, object>("真实最大", this.MapScaleSafeArea.Max);
			instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 4));
		}

		// Token: 0x06041EA7 RID: 269991 RVA: 0x010EA271 File Offset: 0x010E8471
		public void SetMapMoveRebound(float x, float y)
		{
			this.MapMoveRebound.X = (double)x;
			this.MapMoveRebound.Y = (double)y;
		}

		// Token: 0x06041EA8 RID: 269992 RVA: 0x010EA28D File Offset: 0x010E848D
		public void Destroy()
		{
			this.KillPosTweener();
			this.KillScaleTweener();
			global::DelegateUtils.ReleaseManualReleaseDelegate(new Action<FVector2D>(this.OnTweenUpdate));
			global::DelegateUtils.ReleaseManualReleaseDelegate(new Action<FVector>(this.OnScaleTweenUpdate));
		}

		// Token: 0x06041EA9 RID: 269993 RVA: 0x010EA2BD File Offset: 0x010E84BD
		public void AddGamepadEvent()
		{
			Singleton<EventSystem>.Instance.Add<double, double>(EEventName.GamepadMoveOverScreen, new Action<double, double>(this.OnGamepadMoveOverScreen));
		}

		// Token: 0x06041EAA RID: 269994 RVA: 0x010EA2DB File Offset: 0x010E84DB
		public void RemoveGamepadEvent()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.GamepadMoveOverScreen, new Action<double, double>(this.OnGamepadMoveOverScreen));
		}

		// Token: 0x1700A0B6 RID: 41142
		// (get) Token: 0x06041EAB RID: 269995 RVA: 0x010EA2F9 File Offset: 0x010E84F9
		public bool IsInTouch
		{
			get
			{
				return this.TouchMap.Count > 0;
			}
		}

		// Token: 0x1700A0B7 RID: 41143
		// (get) Token: 0x06041EAC RID: 269996 RVA: 0x010EA309 File Offset: 0x010E8509
		public bool IsInMultiTouch
		{
			get
			{
				return this.TouchMap.Count > 1;
			}
		}

		// Token: 0x06041EAD RID: 269997 RVA: 0x010EA31C File Offset: 0x010E851C
		private void OnTouch(string touchIdName, InputDistributeDefine.ITouchData touchData, InputIdentification inputIdentification)
		{
			InputDistributeDefine.ETouchType touchType = touchData.TouchType;
			if (touchType == InputDistributeDefine.ETouchType.TouchMove)
			{
				this.TouchChangeMapScale();
				return;
			}
			if (touchType == InputDistributeDefine.ETouchType.TouchBegin)
			{
				this.TouchTrigger(true, touchData);
				return;
			}
			this.TouchTrigger(false, touchData);
		}

		// Token: 0x06041EAE RID: 269998 RVA: 0x010EA350 File Offset: 0x010E8550
		private void TouchTrigger(bool bTouchPress, InputDistributeDefine.ITouchData touchData)
		{
			int touchId = touchData.TouchId;
			if (bTouchPress)
			{
				if (Singleton<LguiEventSystemManager>.Instance.IsPressComponentIsValid(touchId))
				{
					this.TouchMap[touchId] = touchData;
				}
			}
			else
			{
				this.TouchMap.Remove(touchId);
			}
			this.InteractCenterPoint.Reset();
			foreach (InputDistributeDefine.ITouchData touchData2 in this.TouchMap.Values)
			{
				this.TempTouchVector2D.Set(touchData2.TouchPosition.X, touchData2.TouchPosition.Y);
				this.InteractCenterPoint.AdditionEqual(this.TempTouchVector2D);
			}
			if (this.TouchMap.Count > 0)
			{
				this.InteractCenterPoint.DivisionEqual((double)this.TouchMap.Count);
			}
		}

		// Token: 0x06041EAF RID: 269999 RVA: 0x010EA438 File Offset: 0x010E8638
		private void TouchChangeMapScale()
		{
			if (!this.IsInMultiTouch)
			{
				return;
			}
			ValueTuple<EFingerExpandCloseType, float> fingerExpandCloseType = Singleton<TouchFingerManager>.Instance.GetFingerExpandCloseType(EFingerIndex.One, EFingerIndex.Two);
			EFingerExpandCloseType item = fingerExpandCloseType.Item1;
			float item2 = fingerExpandCloseType.Item2;
			if (item == EFingerExpandCloseType.None)
			{
				return;
			}
			this.SetScale(this.MapScaleInternal + (double)item2, ESetScaleSource.MultiTouch, null);
		}

		// Token: 0x06041EB0 RID: 270000 RVA: 0x010EA47C File Offset: 0x010E867C
		public void BindTouch()
		{
			ControllerBase<InputDistributeController>.Instance.BindTouches(new int[]
			{
				0,
				1
			}, new TInputHandle<InputDistributeDefine.ITouchData>(this.OnTouch));
		}

		// Token: 0x06041EB1 RID: 270001 RVA: 0x010EA49E File Offset: 0x010E869E
		public void UnbindTouch()
		{
			ControllerBase<InputDistributeController>.Instance.UnBindTouches(new <>z__ReadOnlyArray<int>(new int[]
			{
				0,
				1
			}), new TInputHandle<InputDistributeDefine.ITouchData>(this.OnTouch));
		}

		// Token: 0x06041EB2 RID: 270002 RVA: 0x010EA4C5 File Offset: 0x010E86C5
		public UUIItem GetMapItem()
		{
			return this.MapItem;
		}

		// Token: 0x06041EB3 RID: 270003 RVA: 0x010EA4CD File Offset: 0x010E86CD
		public void SwitchOnMove(bool bOn)
		{
			this.CanMove = bOn;
		}

		// Token: 0x06041EB4 RID: 270004 RVA: 0x010EA4D8 File Offset: 0x010E86D8
		public void AddMoveListener(bool bOn = true)
		{
			this.SwitchOnMove(bOn);
			Singleton<EventSystem>.Instance.Add<float>(EEventName.MapDragMoveForward, new Action<float>(this.OnMoveForward));
			Singleton<EventSystem>.Instance.Add<float>(EEventName.MapDragMoveRight, new Action<float>(this.OnMoveRight));
		}

		// Token: 0x06041EB5 RID: 270005 RVA: 0x010EA524 File Offset: 0x010E8724
		public void RemoveMoveListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.MapDragMoveForward, new Action<float>(this.OnMoveForward));
			Singleton<EventSystem>.Instance.Remove(EEventName.MapDragMoveRight, new Action<float>(this.OnMoveRight));
		}

		// Token: 0x06041EB6 RID: 270006 RVA: 0x010EA55E File Offset: 0x010E875E
		private void OnMoveForward(float delta)
		{
			if (!this.CanMove)
			{
				return;
			}
			this.ForwardVector.Y = (double)delta * this.MapScale * (double)(-(double)this.MoveSpeed);
			this.IsMoveForwardDirty = true;
		}

		// Token: 0x06041EB7 RID: 270007 RVA: 0x010EA58D File Offset: 0x010E878D
		private void OnMoveRight(float delta)
		{
			if (!this.CanMove)
			{
				return;
			}
			this.RightVector.X = (double)delta * this.MapScale * (double)(-(double)this.MoveSpeed);
			this.IsMoveRightDirty = true;
		}

		// Token: 0x06041EB8 RID: 270008 RVA: 0x010EA5BC File Offset: 0x010E87BC
		public void TickMove()
		{
			if (!this.IsMoveForwardDirty && !this.IsMoveRightDirty)
			{
				return;
			}
			this.TempMoveVector2D.FromUeVector2D(this.MapItem.GetAnchorOffset());
			if (this.IsMoveForwardDirty)
			{
				this.TempMoveVector2D.AdditionEqual(this.ForwardVector);
				this.IsMoveForwardDirty = false;
			}
			if (this.IsMoveRightDirty)
			{
				this.TempMoveVector2D.AdditionEqual(this.RightVector);
				this.IsMoveRightDirty = false;
			}
			this.MoveToTargetPos(this.TempMoveVector2D, EClampType.ClampToSafeArea);
		}

		// Token: 0x06041EB9 RID: 270009 RVA: 0x010EA644 File Offset: 0x010E8844
		[NullableContext(0)]
		[return: TupleElementNames(new string[]
		{
			"ratioX",
			"ratioY"
		})]
		public ValueTuple<double, double> GetOffsetDisRelativeToViewportCenterRatio(double offsetX, double offsetY)
		{
			double item = Math.Abs(offsetX) * this.MapScale / (this.ViewportSize.X / 2.0);
			double item2 = Math.Abs(offsetY) * this.MapScale / (this.ViewportSize.Y / 2.0);
			return new ValueTuple<double, double>(item, item2);
		}

		// Token: 0x04024C47 RID: 150599
		private double PointerDownTime;

		// Token: 0x04024C48 RID: 150600
		protected bool IsDragging;

		// Token: 0x04024C49 RID: 150601
		protected bool IsTweening;

		// Token: 0x04024C4A RID: 150602
		[Nullable(2)]
		private ULTweener PosTweener;

		// Token: 0x04024C4B RID: 150603
		[Nullable(2)]
		private FLTweenVector2SetterDynamic Delegate;

		// Token: 0x04024C4C RID: 150604
		[Nullable(2)]
		private ULTweener ScaleTweener;

		// Token: 0x04024C4D RID: 150605
		[Nullable(2)]
		private FLTweenVector3SetterDynamic ScaleDelegate;

		// Token: 0x04024C4E RID: 150606
		private readonly Vector2D ScaleTempPos = Vector2D.Create();

		// Token: 0x04024C4F RID: 150607
		private readonly Vector ScaleTempStartVector = Vector.Create();

		// Token: 0x04024C50 RID: 150608
		private readonly Vector ScaleTempEndVector = Vector.Create();

		// Token: 0x04024C51 RID: 150609
		private readonly Vector2D LastDragPos = Vector2D.Create();

		// Token: 0x04024C52 RID: 150610
		private readonly Vector2D PointerDeltaPos = Vector2D.Create();

		// Token: 0x04024C53 RID: 150611
		public readonly double ScaleStep = 0.05000000074505806;

		// Token: 0x04024C54 RID: 150612
		public readonly IScaleArea MapScaleSafeArea = new ScaleArea
		{
			Min = 0.0,
			Max = 0.0
		};

		// Token: 0x04024C55 RID: 150613
		private double MapScaleInternal = 1.0;

		// Token: 0x04024C56 RID: 150614
		private readonly Vector2D ViewportSize = Vector2D.Create();

		// Token: 0x04024C57 RID: 150615
		private readonly Vector2D MapMoveRebound = Vector2D.Create();

		// Token: 0x04024C58 RID: 150616
		protected readonly IMoveArea MoveSafeArea = new MoveArea
		{
			MinX = 0.0,
			MaxX = 0.0,
			MinY = 0.0,
			MaxY = 0.0
		};

		// Token: 0x04024C59 RID: 150617
		protected readonly IMoveArea MoveDangerousArea = new MoveArea
		{
			MinX = 0.0,
			MaxX = 0.0,
			MinY = 0.0,
			MaxY = 0.0
		};

		// Token: 0x04024C5A RID: 150618
		private readonly Vector2D InteractCenterPoint = Vector2D.Create();

		// Token: 0x04024C5B RID: 150619
		private readonly UUIItem MapItem;

		// Token: 0x04024C5C RID: 150620
		private readonly Vector2D TempVector2D = Vector2D.Create();

		// Token: 0x04024C5D RID: 150621
		private readonly Vector TempVector = Vector.Create();

		// Token: 0x04024C5E RID: 150622
		private double SizeInterval = 1.0;

		// Token: 0x04024C5F RID: 150623
		[Nullable(2)]
		private Action<ESetScaleSource> ChangeScaleCallback;

		// Token: 0x04024C60 RID: 150624
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Action<ULGUIPointerEventData> PointerBeginDragExtraCallBack;

		// Token: 0x04024C61 RID: 150625
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Action<ULGUIPointerEventData> PointerUpExtraCallBack;

		// Token: 0x04024C62 RID: 150626
		private readonly Vector2D TempTouchVector2D = Vector2D.Create();

		// Token: 0x04024C63 RID: 150627
		private readonly Dictionary<int, InputDistributeDefine.ITouchData> TouchMap = new Dictionary<int, InputDistributeDefine.ITouchData>();

		// Token: 0x04024C64 RID: 150628
		public float MoveSpeed = 1f;

		// Token: 0x04024C65 RID: 150629
		private readonly Vector2D ForwardVector = new Vector2D();

		// Token: 0x04024C66 RID: 150630
		private readonly Vector2D RightVector = new Vector2D();

		// Token: 0x04024C67 RID: 150631
		private readonly Vector2D TempMoveVector2D = Vector2D.Create();

		// Token: 0x04024C68 RID: 150632
		private bool IsMoveForwardDirty;

		// Token: 0x04024C69 RID: 150633
		private bool IsMoveRightDirty;

		// Token: 0x04024C6A RID: 150634
		private bool CanMove;

		// Token: 0x04024C6B RID: 150635
		private const float TWEEN_TIME = 2f;

		// Token: 0x04024C6C RID: 150636
		private const float DRAG_TWEEN_TIME = 0.8f;
	}
}
