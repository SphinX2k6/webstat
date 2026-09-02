using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Common;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.RoleUi.TabView.VisionSubView
{
	// Token: 0x0200506F RID: 20591
	[NullableContext(2)]
	[Nullable(0)]
	public class VisionCommonDragItem
	{
		// Token: 0x060350EE RID: 217326 RVA: 0x00D4E5B4 File Offset: 0x00D4C7B4
		[NullableContext(1)]
		public VisionCommonDragItem(UUIItem normalParent, UUIDraggableComponent dragComponent, UUIItem dragParent, EPhantomItemIndex index)
		{
			this.StretchVector = new FVector2D?(new FVector2D(0f, 0f));
			this.NormalParent = normalParent;
			this.DragComponent = dragComponent;
			this.Index = (int)index;
			this.MovingParent = dragComponent.RootUIComp.Get().GetParentAsUIItem();
			this.DragParent = dragParent;
			dragComponent.OnPointerDownCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnPointerDown));
			dragComponent.OnPointerUpCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnPointUp));
			dragComponent.OnPointerDragCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnDrag));
			dragComponent.OnPointerBeginDragCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnDragBegin));
			dragComponent.OnPointerEndDragCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnDragEnd));
			UUIItem uuiitem = dragComponent.GetOwner().GetComponentByClass(UUIItem.StaticClass()) as UUIItem;
			this.DragItem = uuiitem;
			this.LevelSequencePlayer = new LevelSequencePlayer(uuiitem);
			this.LevelSequencePlayer.BindSequenceCloseEvent(new TSequenceEndEvent(this.FinishSequenceEvent), false);
			this.Canvas = (dragComponent.GetOwner().GetComponentByClass(ULGUICanvas.StaticClass()) as ULGUICanvas);
		}

		// Token: 0x060350EF RID: 217327 RVA: 0x00D4E7C9 File Offset: 0x00D4C9C9
		[NullableContext(1)]
		public UUIItem GetNormalParent()
		{
			return this.NormalParent;
		}

		// Token: 0x060350F0 RID: 217328 RVA: 0x00D4E7D4 File Offset: 0x00D4C9D4
		public void SetActive(bool state)
		{
			UUIDraggableComponent dragComponent = this.DragComponent;
			if (dragComponent == null)
			{
				return;
			}
			dragComponent.RootUIComp.Get().SetUIActive(state);
		}

		// Token: 0x060350F1 RID: 217329 RVA: 0x00D4E800 File Offset: 0x00D4CA00
		[NullableContext(1)]
		public void SetScrollViewItem(UUIItem scrollView)
		{
			FVector2D fvector2D = new Vector2D(0.5, 0.5).ToUeVector2D(false);
			FVector lguispaceAbsolutePositionByPivot = scrollView.GetLGUISpaceAbsolutePositionByPivot(fvector2D);
			float num = scrollView.Width / 2f;
			float num2 = lguispaceAbsolutePositionByPivot.X - num;
			float num3 = lguispaceAbsolutePositionByPivot.X + num;
			this.ScrollViewBounceX.X = (double)num2;
			this.ScrollViewBounceX.Y = (double)num3;
			num = scrollView.Height / 2f;
			float num4 = lguispaceAbsolutePositionByPivot.Y - num;
			float num5 = lguispaceAbsolutePositionByPivot.Y + num;
			this.ScrollViewBounceY.X = (double)num4;
			this.ScrollViewBounceY.Y = (double)num5;
		}

		// Token: 0x060350F2 RID: 217330 RVA: 0x00D4E8A7 File Offset: 0x00D4CAA7
		public void Refresh(PhantomDataBase data, bool isTrialRole)
		{
			this.CurrentData = data;
			this.IsTrailRole = isTrialRole;
		}

		// Token: 0x060350F3 RID: 217331 RVA: 0x00D4E8B8 File Offset: 0x00D4CAB8
		public void StartClickCheckTimer()
		{
			this.ClearFingerTick();
			Ticker ticker = Singleton<TickSystem>.Instance.Add(delegate(float _)
			{
				if (this.GetCurrentFingerNum() == 0)
				{
					this.OnPointUp(null);
					this.ClearFingerTick();
				}
			}, "DragTick", ETickingGroup.TG_PrePhysics, true, 0, true);
			if (ticker != null)
			{
				this.CurrentCheckFingerTick = ticker.Id;
			}
		}

		// Token: 0x060350F4 RID: 217332 RVA: 0x00D4E8FA File Offset: 0x00D4CAFA
		public Vector2D GetAnimationTargetPos()
		{
			return this.AnimationTargetPosition;
		}

		// Token: 0x060350F5 RID: 217333 RVA: 0x00D4E902 File Offset: 0x00D4CB02
		public void SetDragItemHierarchyMax()
		{
			this.DragItem.SetAsLastHierarchy();
			this.Canvas.SetSortOrder(101, true);
		}

		// Token: 0x060350F6 RID: 217334 RVA: 0x00D4E91D File Offset: 0x00D4CB1D
		public PhantomDataBase GetCurrentData()
		{
			return this.CurrentData;
		}

		// Token: 0x060350F7 RID: 217335 RVA: 0x00D4E928 File Offset: 0x00D4CB28
		public void CacheStartDragPosition()
		{
			FVector lguispaceAbsolutePosition = this.DragComponent.RootUIComp.Get().GetLGUISpaceAbsolutePosition();
			FVector lguispaceAbsolutePosition2 = this.DragComponent.RootUIComp.Get().GetLGUISpaceAbsolutePosition();
			this.StartPosition = new Vector2D((double)lguispaceAbsolutePosition2.X, (double)lguispaceAbsolutePosition2.Y);
			this.AnimationTargetPosition = new Vector2D((double)lguispaceAbsolutePosition.X, (double)lguispaceAbsolutePosition.Y);
		}

		// Token: 0x060350F8 RID: 217336 RVA: 0x00D4E99C File Offset: 0x00D4CB9C
		private void BackDragItemToNormalParent()
		{
			this.DragComponent.RootUIComp.Get().SetAnchorAlign(UIAnchorHorizontalAlign.Stretch, UIAnchorVerticalAlign.Stretch);
			FVector uiitemScale = new FVector(1f, 1f, 1f);
			this.DragComponent.RootUIComp.Get().SetUIItemScale(uiitemScale);
			this.DragComponent.RootUIComp.Get().SetHorizontalStretch(this.StretchVector.Value);
			this.DragComponent.RootUIComp.Get().SetVerticalStretch(this.StretchVector.Value);
			this.Canvas.SetSortOrder(0, true);
			this.DragComponent.RootUIComp.Get().SetBubbleUpToParent(true);
		}

		// Token: 0x060350F9 RID: 217337 RVA: 0x00D4EA60 File Offset: 0x00D4CC60
		public void StartDragState()
		{
			this.CacheStartDragPosition();
			this.DragState = true;
			this.IfStayInScrollView = false;
			this.DragComponent.RootUIComp.Get().SetAnchorAlign(UIAnchorHorizontalAlign.Center, UIAnchorVerticalAlign.Middle);
			this.SourceWidth = this.DragComponent.RootUIComp.Get().Width;
			this.SourceHeight = this.DragComponent.RootUIComp.Get().Height;
			this.MoveParentDelay = 0;
			this.Canvas.SetSortOrder(100, true);
			this.DragComponent.RootUIComp.Get().SetBubbleUpToParent(false);
		}

		// Token: 0x060350FA RID: 217338 RVA: 0x00D4EB08 File Offset: 0x00D4CD08
		public void ResetPosition()
		{
			this.LevelSequencePlayer.StopSequenceByKey("Drag", false, true);
			if (this.CeaseFailAnimationState)
			{
				this.TryDoCeaseFailSequence();
			}
			this.CeaseFailAnimationState = false;
			if (!this.DragState)
			{
				return;
			}
			this.BackDragItemToNormalParent();
			if (this.StartPosition != null)
			{
				this.DragComponent.RootUIComp.Get().SetAnchorOffset(this.StretchVector.Value);
			}
			this.DragState = false;
		}

		// Token: 0x060350FB RID: 217339 RVA: 0x00D4EB7D File Offset: 0x00D4CD7D
		public void SetToTargetParentAndSetStretch(UUIItem targetItem)
		{
		}

		// Token: 0x060350FC RID: 217340 RVA: 0x00D4EB7F File Offset: 0x00D4CD7F
		public void SetToNormalParent()
		{
			this.SetToTargetParentAndSetStretch(this.MovingParent);
		}

		// Token: 0x060350FD RID: 217341 RVA: 0x00D4EB8D File Offset: 0x00D4CD8D
		[NullableContext(1)]
		public void SetDragSuccessCallBack(Action<VisionCommonDragItem, List<VisionCommonDragItem>, bool> onFunction)
		{
			this.OnDragEndFunction = onFunction;
		}

		// Token: 0x060350FE RID: 217342 RVA: 0x00D4EB96 File Offset: 0x00D4CD96
		[NullableContext(1)]
		public void SetMoveToScrollViewCallBack(Action<int> callBack)
		{
			this.OnMoveToScrollViewCallBack = callBack;
		}

		// Token: 0x060350FF RID: 217343 RVA: 0x00D4EB9F File Offset: 0x00D4CD9F
		[NullableContext(1)]
		public void SetRemoveFromScrollViewCallBack(Action<int> callBack)
		{
			this.OnRemoveFromScrollViewCallBack = callBack;
		}

		// Token: 0x06035100 RID: 217344 RVA: 0x00D4EBA8 File Offset: 0x00D4CDA8
		[NullableContext(1)]
		public void SetEndDragWhenOnScrollViewCallBack(Action<int, PhantomBattleData> callBack)
		{
			this.OnEndDragWhenOnScrollViewCallBack = callBack;
		}

		// Token: 0x06035101 RID: 217345 RVA: 0x00D4EBB1 File Offset: 0x00D4CDB1
		[NullableContext(1)]
		public void SetOnUnOverlayCallBack(Action<int> callBack)
		{
			this.OnUnOverlayCallBack = callBack;
		}

		// Token: 0x06035102 RID: 217346 RVA: 0x00D4EBBA File Offset: 0x00D4CDBA
		[NullableContext(1)]
		public void SetOnOverlayCallBack(Action<int> callBack)
		{
			this.OnOverlayCallBack = callBack;
		}

		// Token: 0x06035103 RID: 217347 RVA: 0x00D4EBC3 File Offset: 0x00D4CDC3
		[NullableContext(1)]
		public void SetPointerDownCallBack(Action<int> dragEvent)
		{
			this.OnPointerDownCallBack = dragEvent;
		}

		// Token: 0x06035104 RID: 217348 RVA: 0x00D4EBCC File Offset: 0x00D4CDCC
		[NullableContext(1)]
		public void SetPointerUpCallBack(Action<int> dragEvent)
		{
			this.OnPointerUpCallBack = dragEvent;
		}

		// Token: 0x06035105 RID: 217349 RVA: 0x00D4EBD5 File Offset: 0x00D4CDD5
		[NullableContext(1)]
		public void SetOnDragAnimationStartFunction(Action<int> onFunction)
		{
			this.OnDragAnimationStartFunction = onFunction;
		}

		// Token: 0x06035106 RID: 217350 RVA: 0x00D4EBDE File Offset: 0x00D4CDDE
		[NullableContext(1)]
		public void SetOnDragAnimationEndFunction(Action<int> onFunction)
		{
			this.OnDragAnimationEndFunction = onFunction;
		}

		// Token: 0x06035107 RID: 217351 RVA: 0x00D4EBE7 File Offset: 0x00D4CDE7
		[NullableContext(1)]
		public void SetOnClickCallBack(Action<int> onFunction)
		{
			this.ClickFunction = onFunction;
		}

		// Token: 0x06035108 RID: 217352 RVA: 0x00D4EBF0 File Offset: 0x00D4CDF0
		[NullableContext(1)]
		public void SetOnClickFailCallBack(Action<int> onFunction)
		{
			this.ClickFailFunction = onFunction;
		}

		// Token: 0x06035109 RID: 217353 RVA: 0x00D4EBF9 File Offset: 0x00D4CDF9
		[NullableContext(1)]
		public void SetOnBeginDragCall(Action<int> onFunction)
		{
			this.OnBeginDragFunction = onFunction;
		}

		// Token: 0x0603510A RID: 217354 RVA: 0x00D4EC02 File Offset: 0x00D4CE02
		[NullableContext(1)]
		public void SetDragCheckItem(List<VisionCommonDragItem> itemList)
		{
			this.CheckList = itemList;
		}

		// Token: 0x0603510B RID: 217355 RVA: 0x00D4EC0B File Offset: 0x00D4CE0B
		public int GetCurrentIndex()
		{
			return this.Index;
		}

		// Token: 0x0603510C RID: 217356 RVA: 0x00D4EC13 File Offset: 0x00D4CE13
		public void TickCheckDrag()
		{
			if (this.MoveParentDelay <= 1)
			{
				this.MoveParentDelay++;
				return;
			}
			this.SetItemToPointerPosition();
			this.CheckOnDrag();
		}

		// Token: 0x0603510D RID: 217357 RVA: 0x00D4EC39 File Offset: 0x00D4CE39
		public void ClearStayingItem()
		{
			this.CurrentStaying.Clear();
		}

		// Token: 0x0603510E RID: 217358 RVA: 0x00D4EC46 File Offset: 0x00D4CE46
		[NullableContext(1)]
		public List<VisionCommonDragItem> GetStayingItem()
		{
			return this.CurrentStaying;
		}

		// Token: 0x0603510F RID: 217359 RVA: 0x00D4EC50 File Offset: 0x00D4CE50
		public void SetItemToPointerPosition()
		{
			if (!this.DragState)
			{
				return;
			}
			FVector? pointerEventDataPosition = Singleton<LguiEventSystemManager>.Instance.GetPointerEventDataPosition(0);
			Vector2D vector2D = Vector2D.Create((double)pointerEventDataPosition.Value.X, (double)pointerEventDataPosition.Value.Y);
			Vector2D vector2D2 = vector2D;
			ULGUICanvasScaler canvasScaler = Singleton<UiLayer>.Instance.UiRootItem.GetCanvasScaler();
			FVector2D fvector2D = vector2D.ToUeVector2D(false);
			vector2D2.FromUeVector2D(canvasScaler.ConvertPositionFromViewportToLGUICanvas(fvector2D));
			float num = ConfigBase<PhantomBattleConfig>.Instance.GetVisionScrollerOffsetX() * (float)ConfigBase<PhantomBattleConfig>.Instance.GetVisionScrollerOffsetXDir();
			float num2 = ConfigBase<PhantomBattleConfig>.Instance.GetVisionScrollerOffsetY() * (float)ConfigBase<PhantomBattleConfig>.Instance.GetVisionScrollerOffsetYDir();
			double num3 = vector2D.X + (double)num;
			double num4 = vector2D.Y + (double)num2;
			if (this.StaticBeginVector.X == num3 && this.StaticBeginVector.Y == num4)
			{
				return;
			}
			this.StaticBeginVector.X = num3;
			this.StaticBeginVector.Y = num4;
			UUIItem uuiitem = this.DragComponent.RootUIComp.Get();
			FVector fvector = new FVector((float)num3, (float)num4, 0f);
			uuiitem.SetLGUISpaceAbsolutePosition(fvector);
		}

		// Token: 0x06035110 RID: 217360 RVA: 0x00D4ED68 File Offset: 0x00D4CF68
		private void OnPointerDown(ULGUIPointerEventData eventData)
		{
			if (!ModelBase<PhantomBattleModel>.Instance.CheckIfCanDrag() || this.DragState)
			{
				return;
			}
			ModelBase<PhantomBattleModel>.Instance.SetCurrentDragIndex(this.Index);
			this.CurrentClickState = false;
			this.CurrentRunningTime = 0f;
			this.PlayDragSequenceState = false;
			this.IfDragMove = false;
			this.CurrentMoveData = null;
			this.IfBeginDrag = false;
			Ticker ticker = Singleton<TickSystem>.Instance.Add(delegate(float _)
			{
				this.CheckTimeForDoDrag();
				this.CurrentRunningTime += Singleton<Time>.Instance.DeltaTime;
			}, "DragTick", ETickingGroup.TG_PrePhysics, true, 0, true);
			if (ticker != null)
			{
				this.CurrentTick = ticker.Id;
			}
			if (this.CurrentData != null)
			{
				Action<int> onPointerDownCallBack = this.OnPointerDownCallBack;
				if (onPointerDownCallBack == null)
				{
					return;
				}
				onPointerDownCallBack(this.GetCurrentIndex());
			}
		}

		// Token: 0x06035111 RID: 217361 RVA: 0x00D4EE18 File Offset: 0x00D4D018
		private void OnPointUp(ULGUIPointerEventData eventData)
		{
			this.ClearTick();
			this.ClearFingerTick();
			if (!ModelBase<PhantomBattleModel>.Instance.CheckIfCurrentDragIndex(this.Index))
			{
				return;
			}
			ModelBase<PhantomBattleModel>.Instance.ClearCurrentDragIndex();
			Action<int> onPointerUpCallBack = this.OnPointerUpCallBack;
			if (onPointerUpCallBack != null)
			{
				onPointerUpCallBack(this.Index);
			}
			if (this.IsTrailRole)
			{
				if (this.CheckInClickGap())
				{
					this.TryDoClick(true);
					return;
				}
				this.TryDoClick(false);
				return;
			}
			else
			{
				if (this.CurrentData == null)
				{
					if (this.CheckInClickableTime())
					{
						this.TryDoClick(true);
					}
					return;
				}
				float currentRunningTime = this.CurrentRunningTime;
				if (!this.IfBeginDrag)
				{
					this.TryDoClick(false);
				}
				return;
			}
		}

		// Token: 0x06035112 RID: 217362 RVA: 0x00D4EEB7 File Offset: 0x00D4D0B7
		private void ClearFingerTick()
		{
			if (this.CurrentCheckFingerTick != -1)
			{
				Singleton<TickSystem>.Instance.Remove(this.CurrentCheckFingerTick);
				this.CurrentCheckFingerTick = -1;
			}
		}

		// Token: 0x06035113 RID: 217363 RVA: 0x00D4EEDC File Offset: 0x00D4D0DC
		private void OnDrag(ULGUIPointerEventData eventData)
		{
			if (this.IsTrailRole)
			{
				return;
			}
			if (!ModelBase<PhantomBattleModel>.Instance.CheckIfCurrentDragIndex(this.Index))
			{
				return;
			}
			if (this.CurrentData == null)
			{
				return;
			}
			this.CurrentMoveData = eventData;
			if (this.CurrentRunningTime < 300f)
			{
				return;
			}
			this.TickCheckDrag();
		}

		// Token: 0x06035114 RID: 217364 RVA: 0x00D4EF2C File Offset: 0x00D4D12C
		private void OnDragBegin(ULGUIPointerEventData eventData)
		{
			if (this.IsTrailRole)
			{
				return;
			}
			if (!ModelBase<PhantomBattleModel>.Instance.CheckIfCurrentDragIndex(this.Index))
			{
				return;
			}
			if (this.CurrentData == null)
			{
				ModelBase<PhantomBattleModel>.Instance.ClearCurrentDragIndex();
				return;
			}
			this.CurrentStaying.Clear();
			this.IfDragMove = true;
			this.IfBeginDrag = true;
		}

		// Token: 0x06035115 RID: 217365 RVA: 0x00D4EF84 File Offset: 0x00D4D184
		private void OnDragEnd(ULGUIPointerEventData eventData)
		{
			if (this.IsTrailRole)
			{
				return;
			}
			if (this.CurrentData == null)
			{
				return;
			}
			if (this.IfDragMove)
			{
				if (this.CurrentRunningTime < 300f)
				{
					this.TryDoClick(false);
				}
				else if (!this.IfStayInScrollView)
				{
					Action<VisionCommonDragItem, List<VisionCommonDragItem>, bool> onDragEndFunction = this.OnDragEndFunction;
					if (onDragEndFunction != null)
					{
						onDragEndFunction(this, this.CurrentStaying, this.IfStayInScrollView);
					}
				}
				this.IfDragMove = false;
			}
			if (this.IfStayInScrollView)
			{
				this.IfStayInScrollView = false;
				this.CeaseFailAnimationState = false;
				Action<int, PhantomBattleData> onEndDragWhenOnScrollViewCallBack = this.OnEndDragWhenOnScrollViewCallBack;
				if (onEndDragWhenOnScrollViewCallBack == null)
				{
					return;
				}
				onEndDragWhenOnScrollViewCallBack(this.GetCurrentIndex(), this.CurrentData as PhantomBattleData);
			}
		}

		// Token: 0x06035116 RID: 217366 RVA: 0x00D4F026 File Offset: 0x00D4D226
		public bool CheckAndGetCurrentClickState()
		{
			return this.CurrentClickState;
		}

		// Token: 0x06035117 RID: 217367 RVA: 0x00D4F02E File Offset: 0x00D4D22E
		private void ClearTick()
		{
			if (this.CurrentTick != -1)
			{
				Singleton<TickSystem>.Instance.Remove(this.CurrentTick);
				this.CurrentTick = -1;
			}
		}

		// Token: 0x06035118 RID: 217368 RVA: 0x00D4F054 File Offset: 0x00D4D254
		public void CancelDrag()
		{
			this.ClearTick();
			this.ClearFingerTick();
			this.IfDragMove = false;
			this.IfBeginDrag = false;
			this.IfStayInScrollView = false;
			this.CurrentStaying.Clear();
			this.CeaseState = false;
			this.MovingState = false;
			this.CeaseFailAnimationState = false;
			CustomPromise<bool> ceaseAnimationPromise = this.CeaseAnimationPromise;
			if (ceaseAnimationPromise == null)
			{
				return;
			}
			ceaseAnimationPromise.SetResult(true);
		}

		// Token: 0x06035119 RID: 217369 RVA: 0x00D4F0B4 File Offset: 0x00D4D2B4
		private int GetCurrentFingerNum()
		{
			bool flag = Singleton<LguiEventSystemManager>.Instance.IsPressComponentIsValid(0);
			bool flag2 = Singleton<LguiEventSystemManager>.Instance.IsPressComponentIsValid(1);
			int num = 0;
			if (flag)
			{
				num++;
			}
			if (flag2)
			{
				num++;
			}
			return num;
		}

		// Token: 0x0603511A RID: 217370 RVA: 0x00D4F0E8 File Offset: 0x00D4D2E8
		[NullableContext(1)]
		private void FinishSequenceEvent(string sequenceName)
		{
			if (sequenceName == "Cease")
			{
				this.CeaseAnimationPromise.SetResult(true);
				Action<int> onDragAnimationEndFunction = this.OnDragAnimationEndFunction;
				if (onDragAnimationEndFunction == null)
				{
					return;
				}
				onDragAnimationEndFunction(this.GetCurrentIndex());
			}
		}

		// Token: 0x0603511B RID: 217371 RVA: 0x00D4F11C File Offset: 0x00D4D31C
		public void DoCeaseSequence()
		{
			this.CeaseFailAnimationState = false;
			this.CeaseAnimationPromise = new CustomPromise<bool>();
			this.LevelSequencePlayer.PlayLevelSequenceByName("Cease", false, null, false);
		}

		// Token: 0x0603511C RID: 217372 RVA: 0x00D4F156 File Offset: 0x00D4D356
		public CustomPromise<bool> GetCeaseAnimationPromise()
		{
			return this.CeaseAnimationPromise;
		}

		// Token: 0x0603511D RID: 217373 RVA: 0x00D4F160 File Offset: 0x00D4D360
		private void TryDoCeaseFailSequence()
		{
			if (this.CeaseFailAnimationState)
			{
				this.LevelSequencePlayer.PlayLevelSequenceByName("Fail", false, null, false);
				Action<int> onDragAnimationEndFunction = this.OnDragAnimationEndFunction;
				if (onDragAnimationEndFunction == null)
				{
					return;
				}
				onDragAnimationEndFunction(this.GetCurrentIndex());
			}
		}

		// Token: 0x0603511E RID: 217374 RVA: 0x00D4F1A8 File Offset: 0x00D4D3A8
		private void DoDragSequence()
		{
			if (this.IsTrailRole)
			{
				return;
			}
			this.TickCheckDrag();
			this.LevelSequencePlayer.PlayLevelSequenceByName("Drag", false, null, false);
			this.CeaseFailAnimationState = true;
			Action<int> onDragAnimationStartFunction = this.OnDragAnimationStartFunction;
			if (onDragAnimationStartFunction == null)
			{
				return;
			}
			onDragAnimationStartFunction(this.GetCurrentIndex());
		}

		// Token: 0x0603511F RID: 217375 RVA: 0x00D4F1FC File Offset: 0x00D4D3FC
		private void CheckTimeForDoDrag()
		{
			if (this.GetCurrentFingerNum() >= 2 || this.GetCurrentFingerNum() == 0)
			{
				this.ClearTick();
				return;
			}
			if (this.CurrentRunningTime >= 300f)
			{
				this.ClearTick();
				if (this.CurrentData == null)
				{
					return;
				}
				if (!this.PlayDragSequenceState)
				{
					this.DoDragSequence();
					this.PlayDragSequenceState = true;
				}
				if (this.OnBeginDragFunction != null)
				{
					this.OnBeginDragFunction(this.Index);
				}
				if (this.CurrentMoveData != null)
				{
					this.OnDrag(this.CurrentMoveData);
				}
			}
		}

		// Token: 0x06035120 RID: 217376 RVA: 0x00D4F280 File Offset: 0x00D4D480
		private bool TryDoClick(bool force = false)
		{
			if (this.CheckIsBlockedByOther())
			{
				this.CurrentClickState = false;
				return false;
			}
			if (force || this.CheckInClickableTime())
			{
				Action<int> clickFunction = this.ClickFunction;
				if (clickFunction != null)
				{
					clickFunction(this.Index);
				}
				this.LastClickTime = Singleton<TimeUtil>.Instance.GetServerTime();
				this.CurrentClickState = true;
				return true;
			}
			this.CurrentClickState = false;
			Action<int> clickFailFunction = this.ClickFailFunction;
			if (clickFailFunction != null)
			{
				clickFailFunction(this.Index);
			}
			return false;
		}

		// Token: 0x06035121 RID: 217377 RVA: 0x00D4F2F8 File Offset: 0x00D4D4F8
		private bool CheckIsBlockedByOther()
		{
			UUIItem nowHitComponent = Singleton<LguiEventSystemManager>.Instance.GetNowHitComponent();
			return nowHitComponent != null && nowHitComponent != this.DragItem && nowHitComponent != this.DragParent;
		}

		// Token: 0x06035122 RID: 217378 RVA: 0x00D4F32A File Offset: 0x00D4D52A
		private bool CheckInClickGap()
		{
			return Singleton<Info>.Instance.IsInGamepad() || Singleton<TimeUtil>.Instance.GetServerTime() - this.LastClickTime > 1.0;
		}

		// Token: 0x06035123 RID: 217379 RVA: 0x00D4F356 File Offset: 0x00D4D556
		private bool CheckInClickableTime()
		{
			return this.CurrentRunningTime < 300f && this.CheckInClickGap();
		}

		// Token: 0x06035124 RID: 217380 RVA: 0x00D4F370 File Offset: 0x00D4D570
		private void CheckOnDrag()
		{
			List<VisionCommonDragItem> list = new List<VisionCommonDragItem>();
			if (this.CheckList != null)
			{
				foreach (VisionCommonDragItem visionCommonDragItem in this.CheckList)
				{
					if (!visionCommonDragItem.CheckIfSelfItem(this.Index) && visionCommonDragItem.CheckOverlap(this.GetBounceX(), this.GetBounceY()))
					{
						list.Add(visionCommonDragItem);
					}
				}
			}
			foreach (VisionCommonDragItem visionCommonDragItem2 in this.CurrentStaying)
			{
				if (!list.Contains(visionCommonDragItem2))
				{
					visionCommonDragItem2.OnUnOverlay();
				}
			}
			foreach (VisionCommonDragItem visionCommonDragItem3 in list)
			{
				if (!this.CurrentStaying.Contains(visionCommonDragItem3))
				{
					visionCommonDragItem3.OnOverlay();
				}
			}
			this.CurrentStaying = list;
			if (this.ScrollViewBounceX.X != 0.0)
			{
				if (this.CheckOverlap(this.ScrollViewBounceX, this.ScrollViewBounceY))
				{
					if (!this.IfStayInScrollView)
					{
						Action<int> onMoveToScrollViewCallBack = this.OnMoveToScrollViewCallBack;
						if (onMoveToScrollViewCallBack != null)
						{
							onMoveToScrollViewCallBack(this.GetCurrentIndex());
						}
						this.IfStayInScrollView = true;
						return;
					}
				}
				else if (this.IfStayInScrollView)
				{
					Action<int> onRemoveFromScrollViewCallBack = this.OnRemoveFromScrollViewCallBack;
					if (onRemoveFromScrollViewCallBack != null)
					{
						onRemoveFromScrollViewCallBack(this.GetCurrentIndex());
					}
					this.IfStayInScrollView = false;
				}
			}
		}

		// Token: 0x06035125 RID: 217381 RVA: 0x00D4F508 File Offset: 0x00D4D708
		public bool CheckIfSelfItem(int index)
		{
			return index == this.Index;
		}

		// Token: 0x06035126 RID: 217382 RVA: 0x00D4F514 File Offset: 0x00D4D714
		[NullableContext(1)]
		public bool CheckOverlap(Vector2D inX, Vector2D inY)
		{
			double x = inX.X;
			double y = inX.Y;
			double x2 = inY.X;
			double y2 = inY.Y;
			double x3 = this.GetBounceX().X;
			double y3 = this.GetBounceX().Y;
			double x4 = this.GetBounceY().X;
			double y4 = this.GetBounceY().Y;
			return x < y3 && x3 < y && x2 < y4 && x4 < y2;
		}

		// Token: 0x06035127 RID: 217383 RVA: 0x00D4F584 File Offset: 0x00D4D784
		[NullableContext(1)]
		private Vector2D GetBounceX()
		{
			UUIItem uuiitem = this.DragComponent.RootUIComp.Get();
			float num = this.SourceWidth / 2f;
			float num2 = uuiitem.GetLGUISpaceCenterAbsolutePosition().X - num;
			float num3 = uuiitem.GetLGUISpaceCenterAbsolutePosition().X + num;
			this.BounceX.X = (double)num2;
			this.BounceX.Y = (double)num3;
			return this.BounceX;
		}

		// Token: 0x06035128 RID: 217384 RVA: 0x00D4F5EC File Offset: 0x00D4D7EC
		[NullableContext(1)]
		private Vector2D GetBounceY()
		{
			UUIItem uuiitem = this.DragComponent.RootUIComp.Get();
			float num = this.SourceHeight / 2f;
			float num2 = uuiitem.GetLGUISpaceCenterAbsolutePosition().Y - num;
			float num3 = uuiitem.GetLGUISpaceCenterAbsolutePosition().Y + num;
			this.BounceY.X = (double)num2;
			this.BounceY.Y = (double)num3;
			return this.BounceY;
		}

		// Token: 0x06035129 RID: 217385 RVA: 0x00D4F654 File Offset: 0x00D4D854
		private void OnUnOverlay()
		{
			Action<int> onUnOverlayCallBack = this.OnUnOverlayCallBack;
			if (onUnOverlayCallBack == null)
			{
				return;
			}
			onUnOverlayCallBack(this.GetCurrentIndex());
		}

		// Token: 0x0603512A RID: 217386 RVA: 0x00D4F66C File Offset: 0x00D4D86C
		private void OnOverlay()
		{
			Action<int> onOverlayCallBack = this.OnOverlayCallBack;
			if (onOverlayCallBack == null)
			{
				return;
			}
			onOverlayCallBack(this.GetCurrentIndex());
		}

		// Token: 0x0603512B RID: 217387 RVA: 0x00D4F684 File Offset: 0x00D4D884
		[NullableContext(0)]
		public ValueTuple<float, float> GetMiddlePosition()
		{
			return new ValueTuple<float, float>(this.DragComponent.RootUIComp.Get().GetLGUISpaceCenterAbsolutePosition().X, this.DragComponent.RootUIComp.Get().GetLGUISpaceCenterAbsolutePosition().Y);
		}

		// Token: 0x0603512C RID: 217388 RVA: 0x00D4F6D0 File Offset: 0x00D4D8D0
		[NullableContext(1)]
		public static int GetOverlapIndex(VisionCommonDragItem self, List<VisionCommonDragItem> targets)
		{
			int count = targets.Count;
			ValueTuple<float, float> middlePosition = self.GetMiddlePosition();
			int currentIndex = targets[0].GetCurrentIndex();
			ValueTuple<float, float> middlePosition2 = targets[0].GetMiddlePosition();
			float num = middlePosition.Item1 * middlePosition.Item1;
			float num2 = middlePosition.Item2 * middlePosition.Item2;
			float num3 = Math.Abs(num - middlePosition2.Item1 * middlePosition2.Item1);
			float num4 = Math.Abs(num2 - middlePosition2.Item2 * middlePosition2.Item2);
			float num5 = num3 + num4;
			for (int i = 0; i < count; i++)
			{
				middlePosition2 = targets[i].GetMiddlePosition();
				float num6 = Math.Abs(num - middlePosition2.Item1 * middlePosition2.Item1);
				num4 = Math.Abs(num2 - middlePosition2.Item2 * middlePosition2.Item2);
				float num7 = num6 + num4;
				if (num5 > num7)
				{
					num5 = num7;
					currentIndex = targets[i].GetCurrentIndex();
				}
			}
			return currentIndex;
		}

		// Token: 0x0603512D RID: 217389 RVA: 0x00D4F7BC File Offset: 0x00D4D9BC
		[NullableContext(1)]
		public void SetDragComponentToTargetPositionParam(Vector2D targetVec)
		{
			this.CeaseState = true;
			this.CurrentAnimationTargetPos.X = targetVec.X;
			this.CurrentAnimationTargetPos.Y = targetVec.Y;
			FVector lguispaceAbsolutePosition = this.DragItem.GetLGUISpaceAbsolutePosition();
			this.AnimationStartPos.X = (double)lguispaceAbsolutePosition.X;
			this.AnimationStartPos.Y = (double)lguispaceAbsolutePosition.Y;
		}

		// Token: 0x0603512E RID: 217390 RVA: 0x00D4F824 File Offset: 0x00D4DA24
		public UniTask TickDoCeaseAnimation(float currentProgress)
		{
			VisionCommonDragItem.<TickDoCeaseAnimation>d__121 <TickDoCeaseAnimation>d__;
			<TickDoCeaseAnimation>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<TickDoCeaseAnimation>d__.<>4__this = this;
			<TickDoCeaseAnimation>d__.currentProgress = currentProgress;
			<TickDoCeaseAnimation>d__.<>1__state = -1;
			<TickDoCeaseAnimation>d__.<>t__builder.Start<VisionCommonDragItem.<TickDoCeaseAnimation>d__121>(ref <TickDoCeaseAnimation>d__);
			return <TickDoCeaseAnimation>d__.<>t__builder.Task;
		}

		// Token: 0x0603512F RID: 217391 RVA: 0x00D4F86F File Offset: 0x00D4DA6F
		public void SetMovingState(bool state)
		{
			this.MovingState = state;
		}

		// Token: 0x0401E8B8 RID: 125112
		private const int CLICKTIME = 300;

		// Token: 0x0401E8B9 RID: 125113
		private const int CLICKCALLGAP = 1;

		// Token: 0x0401E8BA RID: 125114
		private const int MOVEPARENTDELAYTIME = 1;

		// Token: 0x0401E8BB RID: 125115
		private const int HEIGHTCANVASSORT = 100;

		// Token: 0x0401E8BC RID: 125116
		public CustomPromise<bool> CeaseAnimationPromise;

		// Token: 0x0401E8BD RID: 125117
		private readonly UUIDraggableComponent DragComponent;

		// Token: 0x0401E8BE RID: 125118
		private readonly int Index = -1;

		// Token: 0x0401E8BF RID: 125119
		private Action<int> OnPointerDownCallBack;

		// Token: 0x0401E8C0 RID: 125120
		private Action<int> OnPointerUpCallBack;

		// Token: 0x0401E8C1 RID: 125121
		private Action<int> OnOverlayCallBack;

		// Token: 0x0401E8C2 RID: 125122
		private Action<int> OnUnOverlayCallBack;

		// Token: 0x0401E8C3 RID: 125123
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Action<int, PhantomBattleData> OnEndDragWhenOnScrollViewCallBack;

		// Token: 0x0401E8C4 RID: 125124
		private Action<int> OnMoveToScrollViewCallBack;

		// Token: 0x0401E8C5 RID: 125125
		private Action<int> OnRemoveFromScrollViewCallBack;

		// Token: 0x0401E8C6 RID: 125126
		private Action<int> ClickFunction;

		// Token: 0x0401E8C7 RID: 125127
		private Action<int> ClickFailFunction;

		// Token: 0x0401E8C8 RID: 125128
		private Action<int> OnBeginDragFunction;

		// Token: 0x0401E8C9 RID: 125129
		private Action<int> OnDragAnimationStartFunction;

		// Token: 0x0401E8CA RID: 125130
		private Action<int> OnDragAnimationEndFunction;

		// Token: 0x0401E8CB RID: 125131
		[Nullable(new byte[]
		{
			2,
			1,
			1,
			1
		})]
		private Action<VisionCommonDragItem, List<VisionCommonDragItem>, bool> OnDragEndFunction;

		// Token: 0x0401E8CC RID: 125132
		private ULGUIPointerEventData CurrentMoveData;

		// Token: 0x0401E8CD RID: 125133
		private bool CurrentClickState;

		// Token: 0x0401E8CE RID: 125134
		private float CurrentRunningTime;

		// Token: 0x0401E8CF RID: 125135
		private bool IfDragMove;

		// Token: 0x0401E8D0 RID: 125136
		private bool PlayDragSequenceState;

		// Token: 0x0401E8D1 RID: 125137
		private int CurrentTick = -1;

		// Token: 0x0401E8D2 RID: 125138
		private bool IfBeginDrag;

		// Token: 0x0401E8D3 RID: 125139
		private int CurrentCheckFingerTick = -1;

		// Token: 0x0401E8D4 RID: 125140
		private double LastClickTime;

		// Token: 0x0401E8D5 RID: 125141
		[Nullable(1)]
		private readonly Vector StaticBeginVector = Vector.Create();

		// Token: 0x0401E8D6 RID: 125142
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private List<VisionCommonDragItem> CheckList;

		// Token: 0x0401E8D7 RID: 125143
		private float SourceWidth;

		// Token: 0x0401E8D8 RID: 125144
		private float SourceHeight;

		// Token: 0x0401E8D9 RID: 125145
		[Nullable(1)]
		private readonly Vector2D BounceX = new Vector2D(0.0, 0.0);

		// Token: 0x0401E8DA RID: 125146
		[Nullable(1)]
		private readonly Vector2D BounceY = new Vector2D(0.0, 0.0);

		// Token: 0x0401E8DB RID: 125147
		[Nullable(1)]
		private List<VisionCommonDragItem> CurrentStaying = new List<VisionCommonDragItem>();

		// Token: 0x0401E8DC RID: 125148
		private bool CeaseFailAnimationState;

		// Token: 0x0401E8DD RID: 125149
		private bool DragState;

		// Token: 0x0401E8DE RID: 125150
		private readonly LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x0401E8DF RID: 125151
		private int MoveParentDelay;

		// Token: 0x0401E8E0 RID: 125152
		private PhantomDataBase CurrentData;

		// Token: 0x0401E8E1 RID: 125153
		private Vector2D StartPosition;

		// Token: 0x0401E8E2 RID: 125154
		private Vector2D AnimationTargetPosition;

		// Token: 0x0401E8E3 RID: 125155
		private readonly UUIItem MovingParent;

		// Token: 0x0401E8E4 RID: 125156
		private readonly UUIItem NormalParent;

		// Token: 0x0401E8E5 RID: 125157
		private readonly FVector2D? StretchVector;

		// Token: 0x0401E8E6 RID: 125158
		private readonly UUIItem DragItem;

		// Token: 0x0401E8E7 RID: 125159
		private readonly UUIItem DragParent;

		// Token: 0x0401E8E8 RID: 125160
		[Nullable(1)]
		private readonly Vector2D ScrollViewBounceX = new Vector2D(0.0, 0.0);

		// Token: 0x0401E8E9 RID: 125161
		[Nullable(1)]
		private readonly Vector2D ScrollViewBounceY = new Vector2D(0.0, 0.0);

		// Token: 0x0401E8EA RID: 125162
		private bool IfStayInScrollView;

		// Token: 0x0401E8EB RID: 125163
		[Nullable(1)]
		private readonly Vector2D CurrentAnimationTargetPos = new Vector2D(0.0, 0.0);

		// Token: 0x0401E8EC RID: 125164
		private bool CeaseState;

		// Token: 0x0401E8ED RID: 125165
		[Nullable(1)]
		private readonly Vector2D AnimationStartPos = new Vector2D(0.0, 0.0);

		// Token: 0x0401E8EE RID: 125166
		private bool MovingState;

		// Token: 0x0401E8EF RID: 125167
		private readonly ULGUICanvas Canvas;

		// Token: 0x0401E8F0 RID: 125168
		private bool IsTrailRole;
	}
}
