using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Common;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Ui
{
	// Token: 0x020049C0 RID: 18880
	[NullableContext(2)]
	[Nullable(0)]
	public class CommonDragItemLogic<[Nullable(0)] TItem, [Nullable(1)] TData> where TItem : CommonDragLogicDataItem<TData> where TData : class
	{
		// Token: 0x060315E9 RID: 202217 RVA: 0x00C49338 File Offset: 0x00C47538
		[NullableContext(1)]
		public CommonDragItemLogic(UUIItem normalParent, UUIDraggableComponent dragComponent, int index, Func<TItem> delegateCreateFunction)
		{
			this.StretchVector = new FVector2D?(new FVector2D(0f, 0f));
			this.NormalParent = normalParent;
			this.DragComponent = dragComponent;
			this.Index = index;
			this.MovingParent = dragComponent.RootUIComp.Get().GetParentAsUIItem();
			dragComponent.OnPointerDownCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnPointerDown));
			dragComponent.OnPointerUpCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnPointUp));
			dragComponent.OnPointerDragCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnDrag));
			dragComponent.OnPointerBeginDragCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnDragBegin));
			dragComponent.OnPointerEndDragCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnDragEnd));
			UUIItem uuiitem = dragComponent.RootUIComp.Get().GetOwner().GetComponentByClass(UUIItem.StaticClass()) as UUIItem;
			this.DragItem = uuiitem;
			this.LevelSequencePlayer = new LevelSequencePlayer(uuiitem);
			this.LevelSequencePlayer.BindSequenceCloseEvent(new TSequenceEndEvent(this.FinishSequenceEvent), false);
			this.Canvas = (dragComponent.RootUIComp.Get().GetOwner().GetComponentByClass(ULGUICanvas.StaticClass()) as ULGUICanvas);
			this.Delegate = delegateCreateFunction();
			this.Delegate.SetDragComponent(dragComponent);
			this.Delegate.SetCurrentIndex(index);
		}

		// Token: 0x060315EA RID: 202218 RVA: 0x00C49549 File Offset: 0x00C47749
		[NullableContext(1)]
		public UUIItem GetNormalParent()
		{
			return this.NormalParent;
		}

		// Token: 0x060315EB RID: 202219 RVA: 0x00C49551 File Offset: 0x00C47751
		[NullableContext(1)]
		public TItem GetItem()
		{
			return this.Delegate;
		}

		// Token: 0x060315EC RID: 202220 RVA: 0x00C4955C File Offset: 0x00C4775C
		public void SetActive(bool state)
		{
			UUIDraggableComponent dragComponent = this.DragComponent;
			if (dragComponent == null)
			{
				return;
			}
			dragComponent.RootUIComp.Get().SetUIActive(state);
		}

		// Token: 0x060315ED RID: 202221 RVA: 0x00C49588 File Offset: 0x00C47788
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

		// Token: 0x060315EE RID: 202222 RVA: 0x00C4962F File Offset: 0x00C4782F
		public void Refresh(TData data)
		{
			this.Delegate.SetCurrentData(data);
		}

		// Token: 0x060315EF RID: 202223 RVA: 0x00C49642 File Offset: 0x00C47842
		public void StartClickCheckTimer()
		{
			this.ClearFingerTick();
			this.CurrentCheckFingerTick = Singleton<TickSystem>.Instance.Add(delegate(float _)
			{
				if (this.GetCurrentFingerNum() == 0)
				{
					this.OnPointUp(null);
					this.ClearFingerTick();
				}
			}, "DragTick", ETickingGroup.TG_PrePhysics, true, 0, true).Id;
		}

		// Token: 0x060315F0 RID: 202224 RVA: 0x00C49674 File Offset: 0x00C47874
		public Vector2D GetAnimationTargetPos()
		{
			return this.AnimationTargetPosition;
		}

		// Token: 0x060315F1 RID: 202225 RVA: 0x00C4967C File Offset: 0x00C4787C
		public void SetDragItemHierarchyMax()
		{
			this.DragItem.SetAsLastHierarchy();
			this.Canvas.SetSortOrder(101, true);
		}

		// Token: 0x060315F2 RID: 202226 RVA: 0x00C49697 File Offset: 0x00C47897
		public TData GetCurrentData()
		{
			return this.Delegate.GetCurrentData();
		}

		// Token: 0x060315F3 RID: 202227 RVA: 0x00C496AC File Offset: 0x00C478AC
		public void CacheStartDragPosition()
		{
			FVector lguispaceAbsolutePosition = this.DragComponent.RootUIComp.Get().GetLGUISpaceAbsolutePosition();
			FVector lguispaceAbsolutePosition2 = this.DragComponent.RootUIComp.Get().GetLGUISpaceAbsolutePosition();
			this.StartPosition = new Vector2D((double)lguispaceAbsolutePosition2.X, (double)lguispaceAbsolutePosition2.Y);
			this.AnimationTargetPosition = new Vector2D((double)lguispaceAbsolutePosition.X, (double)lguispaceAbsolutePosition.Y);
		}

		// Token: 0x060315F4 RID: 202228 RVA: 0x00C49720 File Offset: 0x00C47920
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

		// Token: 0x060315F5 RID: 202229 RVA: 0x00C497E4 File Offset: 0x00C479E4
		public void StartDragState()
		{
			this.CacheStartDragPosition();
			this.DragState = true;
			this.IfStayInScrollView = false;
			this.DragComponent.RootUIComp.Get().SetAnchorAlign(UIAnchorHorizontalAlign.Center, UIAnchorVerticalAlign.Middle);
			this.MoveParentDelay = 0f;
			this.Canvas.SetSortOrder(100, true);
			this.DragComponent.RootUIComp.Get().SetBubbleUpToParent(false);
		}

		// Token: 0x060315F6 RID: 202230 RVA: 0x00C49854 File Offset: 0x00C47A54
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

		// Token: 0x060315F7 RID: 202231 RVA: 0x00C498C9 File Offset: 0x00C47AC9
		public virtual void SetToTargetParentAndSetStretch(UUIItem targetItem)
		{
		}

		// Token: 0x060315F8 RID: 202232 RVA: 0x00C498CB File Offset: 0x00C47ACB
		public void SetToNormalParent()
		{
			this.SetToTargetParentAndSetStretch(this.MovingParent);
		}

		// Token: 0x060315F9 RID: 202233 RVA: 0x00C498D9 File Offset: 0x00C47AD9
		public void SetDragSuccessCallBack([Nullable(new byte[]
		{
			1,
			1,
			2
		})] Action<TItem, TItem, bool> onFunction)
		{
			this.OnDragEndFunction = onFunction;
		}

		// Token: 0x060315FA RID: 202234 RVA: 0x00C498E2 File Offset: 0x00C47AE2
		[NullableContext(1)]
		public void SetMoveToScrollViewCallBack(Action<int> callBack)
		{
			this.OnMoveToScrollViewCallBack = callBack;
		}

		// Token: 0x060315FB RID: 202235 RVA: 0x00C498EB File Offset: 0x00C47AEB
		[NullableContext(1)]
		public void SetRemoveFromScrollViewCallBack(Action<int> callBack)
		{
			this.OnRemoveFromScrollViewCallBack = callBack;
		}

		// Token: 0x060315FC RID: 202236 RVA: 0x00C498F4 File Offset: 0x00C47AF4
		[NullableContext(1)]
		public void SetEndDragWhenOnScrollViewCallBack(Action<int, TData> callBack)
		{
			this.OnEndDragWhenOnScrollViewCallBack = callBack;
		}

		// Token: 0x060315FD RID: 202237 RVA: 0x00C498FD File Offset: 0x00C47AFD
		[NullableContext(1)]
		public void SetOnUnOverlayCallBack(Action<int> callBack)
		{
			this.Delegate.SetOnUnOverlayCallBack(callBack);
		}

		// Token: 0x060315FE RID: 202238 RVA: 0x00C49910 File Offset: 0x00C47B10
		[NullableContext(1)]
		public void SetOnOverlayCallBack(Action<int> callBack)
		{
			this.Delegate.SetOnOverlayCallBack(callBack);
		}

		// Token: 0x060315FF RID: 202239 RVA: 0x00C49923 File Offset: 0x00C47B23
		[NullableContext(1)]
		public void SetPointerDownCallBack(Action<int> dragEvent)
		{
			this.OnPointerDownCallBack = dragEvent;
		}

		// Token: 0x06031600 RID: 202240 RVA: 0x00C4992C File Offset: 0x00C47B2C
		[NullableContext(1)]
		public void SetOnDragAnimationStartFunction(Action<int> onFunction)
		{
			this.OnDragAnimationStartFunction = onFunction;
		}

		// Token: 0x06031601 RID: 202241 RVA: 0x00C49935 File Offset: 0x00C47B35
		[NullableContext(1)]
		public void SetOnDragAnimationEndFunction(Action<int> onFunction)
		{
			this.OnDragAnimationEndFunction = onFunction;
		}

		// Token: 0x06031602 RID: 202242 RVA: 0x00C4993E File Offset: 0x00C47B3E
		[NullableContext(1)]
		public void SetOnClickCallBack(Action<int> onFunction)
		{
			this.ClickFunction = onFunction;
		}

		// Token: 0x06031603 RID: 202243 RVA: 0x00C49947 File Offset: 0x00C47B47
		[NullableContext(1)]
		public void SetOnClickFailCallBack(Action<int> onFunction)
		{
			this.ClickFailFunction = onFunction;
		}

		// Token: 0x06031604 RID: 202244 RVA: 0x00C49950 File Offset: 0x00C47B50
		[NullableContext(1)]
		public void SetOnBeginDragCall(Action<int> onFunction)
		{
			this.OnBeginDragFunction = onFunction;
		}

		// Token: 0x06031605 RID: 202245 RVA: 0x00C4995C File Offset: 0x00C47B5C
		[NullableContext(1)]
		public void SetDragCheckItem(List<CommonDragItemLogic<TItem, TData>> itemList)
		{
			List<TItem> list = new List<TItem>();
			foreach (CommonDragItemLogic<TItem, TData> commonDragItemLogic in itemList)
			{
				list.Add(commonDragItemLogic.GetItem());
			}
			this.CheckList = list;
		}

		// Token: 0x06031606 RID: 202246 RVA: 0x00C499BC File Offset: 0x00C47BBC
		public int GetCurrentIndex()
		{
			return this.Index;
		}

		// Token: 0x06031607 RID: 202247 RVA: 0x00C499C4 File Offset: 0x00C47BC4
		public void TickCheckDrag()
		{
			if (this.MoveParentDelay <= 1f)
			{
				this.MoveParentDelay += 1f;
				return;
			}
			this.SetItemToPointerPosition();
			this.CheckOnDrag();
		}

		// Token: 0x06031608 RID: 202248 RVA: 0x00C499F2 File Offset: 0x00C47BF2
		public void ClearStayingItem()
		{
			this.CurrentStaying = default(TItem);
		}

		// Token: 0x06031609 RID: 202249 RVA: 0x00C49A00 File Offset: 0x00C47C00
		public TItem GetStayingItem()
		{
			return this.CurrentStaying;
		}

		// Token: 0x0603160A RID: 202250 RVA: 0x00C49A08 File Offset: 0x00C47C08
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

		// Token: 0x0603160B RID: 202251 RVA: 0x00C49B20 File Offset: 0x00C47D20
		private void OnPointerDown(ULGUIPointerEventData eventData)
		{
			if (!this.Delegate.CheckIfCanDrag() || this.DragState)
			{
				return;
			}
			this.Delegate.SetCurrentDragIndex(this.Index);
			this.CurrentClickState = false;
			this.CurrentRunningTime = 0f;
			this.PlayDragSequenceState = false;
			this.IfDragMove = false;
			this.CurrentMoveData = null;
			this.IfBeginDrag = false;
			this.CurrentTick = Singleton<TickSystem>.Instance.Add(delegate(float _)
			{
				this.CheckTimeForDoDrag();
				this.CurrentRunningTime += Singleton<Time>.Instance.DeltaTime;
			}, "DragTick", ETickingGroup.TG_PrePhysics, true, 0, true).Id;
			if (this.Delegate.GetCurrentData() != null)
			{
				Action<int> onPointerDownCallBack = this.OnPointerDownCallBack;
				if (onPointerDownCallBack == null)
				{
					return;
				}
				onPointerDownCallBack(this.GetCurrentIndex());
			}
		}

		// Token: 0x0603160C RID: 202252 RVA: 0x00C49BE4 File Offset: 0x00C47DE4
		private void OnPointUp(ULGUIPointerEventData eventData)
		{
			this.ClearTick();
			this.ClearFingerTick();
			if (!this.Delegate.CheckIfCurrentDragIndex(this.Index))
			{
				return;
			}
			this.Delegate.ClearCurrentDragIndex();
			if (this.Delegate.GetCurrentData() == null)
			{
				if (this.CheckInClickableTime())
				{
					this.TryDoClick(true);
				}
				return;
			}
			float currentRunningTime = this.CurrentRunningTime;
			this.Delegate.GetClickTime();
			if (!this.IfBeginDrag)
			{
				this.TryDoClick(false);
			}
		}

		// Token: 0x0603160D RID: 202253 RVA: 0x00C49C76 File Offset: 0x00C47E76
		private void ClearFingerTick()
		{
			if (this.CurrentCheckFingerTick != -1)
			{
				Singleton<TickSystem>.Instance.Remove(this.CurrentCheckFingerTick);
				this.CurrentCheckFingerTick = -1;
			}
		}

		// Token: 0x0603160E RID: 202254 RVA: 0x00C49C9C File Offset: 0x00C47E9C
		private void OnDrag(ULGUIPointerEventData eventData)
		{
			if (!this.Delegate.CheckIfCurrentDragIndex(this.Index))
			{
				return;
			}
			if (this.Delegate.GetCurrentData() == null)
			{
				return;
			}
			this.CurrentMoveData = eventData;
			if (this.CurrentRunningTime < this.Delegate.GetClickTime())
			{
				return;
			}
			this.TickCheckDrag();
		}

		// Token: 0x0603160F RID: 202255 RVA: 0x00C49D00 File Offset: 0x00C47F00
		private void OnDragBegin(ULGUIPointerEventData eventData)
		{
			if (!this.Delegate.CheckIfCurrentDragIndex(this.Index))
			{
				return;
			}
			if (this.Delegate.GetCurrentData() == null)
			{
				this.Delegate.ClearCurrentDragIndex();
				return;
			}
			this.CurrentStaying = default(TItem);
			this.IfDragMove = true;
			this.IfBeginDrag = true;
		}

		// Token: 0x06031610 RID: 202256 RVA: 0x00C49D68 File Offset: 0x00C47F68
		private void OnDragEnd(ULGUIPointerEventData eventData)
		{
			if (this.Delegate.GetCurrentData() == null)
			{
				return;
			}
			if (this.IfDragMove)
			{
				if (this.CurrentRunningTime < this.Delegate.GetClickTime())
				{
					this.TryDoClick(false);
				}
				else if (!this.IfStayInScrollView)
				{
					Action<TItem, TItem, bool> onDragEndFunction = this.OnDragEndFunction;
					if (onDragEndFunction != null)
					{
						onDragEndFunction(this.Delegate, this.CurrentStaying, this.IfStayInScrollView);
					}
				}
				this.IfDragMove = false;
			}
			if (this.IfStayInScrollView)
			{
				this.IfStayInScrollView = false;
				this.CeaseFailAnimationState = false;
				Action<int, TData> onEndDragWhenOnScrollViewCallBack = this.OnEndDragWhenOnScrollViewCallBack;
				if (onEndDragWhenOnScrollViewCallBack == null)
				{
					return;
				}
				onEndDragWhenOnScrollViewCallBack(this.GetCurrentIndex(), this.Delegate.GetCurrentData());
			}
		}

		// Token: 0x06031611 RID: 202257 RVA: 0x00C49E25 File Offset: 0x00C48025
		public bool CheckAndGetCurrentClickState()
		{
			return this.CurrentClickState;
		}

		// Token: 0x06031612 RID: 202258 RVA: 0x00C49E2D File Offset: 0x00C4802D
		private void ClearTick()
		{
			if (this.CurrentTick != -1)
			{
				Singleton<TickSystem>.Instance.Remove(this.CurrentTick);
				this.CurrentTick = -1;
			}
		}

		// Token: 0x06031613 RID: 202259 RVA: 0x00C49E50 File Offset: 0x00C48050
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

		// Token: 0x06031614 RID: 202260 RVA: 0x00C49E84 File Offset: 0x00C48084
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

		// Token: 0x06031615 RID: 202261 RVA: 0x00C49EB8 File Offset: 0x00C480B8
		public void DoCeaseSequence()
		{
			this.CeaseFailAnimationState = false;
			this.CeaseAnimationPromise = new CustomPromise<bool>();
			this.LevelSequencePlayer.PlayLevelSequenceByName("Cease", false, null, false);
		}

		// Token: 0x06031616 RID: 202262 RVA: 0x00C49EF2 File Offset: 0x00C480F2
		public CustomPromise<bool> GetCeaseAnimationPromise()
		{
			return this.CeaseAnimationPromise;
		}

		// Token: 0x06031617 RID: 202263 RVA: 0x00C49EFC File Offset: 0x00C480FC
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

		// Token: 0x06031618 RID: 202264 RVA: 0x00C49F44 File Offset: 0x00C48144
		private void DoDragSequence()
		{
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

		// Token: 0x06031619 RID: 202265 RVA: 0x00C49F90 File Offset: 0x00C48190
		private void CheckTimeForDoDrag()
		{
			if (this.GetCurrentFingerNum() >= 2 || this.GetCurrentFingerNum() == 0)
			{
				this.ClearTick();
				return;
			}
			if (this.CurrentRunningTime >= this.Delegate.GetClickTime())
			{
				this.ClearTick();
				if (this.Delegate.GetCurrentData() == null)
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

		// Token: 0x0603161A RID: 202266 RVA: 0x00C4A030 File Offset: 0x00C48230
		private bool TryDoClick(bool force = false)
		{
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

		// Token: 0x0603161B RID: 202267 RVA: 0x00C4A097 File Offset: 0x00C48297
		private bool CheckInClickGap()
		{
			return Singleton<Info>.Instance.IsInGamepad() || Singleton<TimeUtil>.Instance.GetServerTime() - this.LastClickTime > 0.10000000149011612;
		}

		// Token: 0x0603161C RID: 202268 RVA: 0x00C4A0C3 File Offset: 0x00C482C3
		private bool CheckInClickableTime()
		{
			return this.CurrentRunningTime < this.Delegate.GetClickTime() && this.CheckInClickGap();
		}

		// Token: 0x0603161D RID: 202269 RVA: 0x00C4A0E8 File Offset: 0x00C482E8
		private void CheckOnDrag()
		{
			List<CommonDragLogicDataItem<TData>> newOverlayTmp = new List<CommonDragLogicDataItem<TData>>();
			TItem titem = default(TItem);
			List<TItem> checkList = this.CheckList;
			if (checkList != null)
			{
				checkList.ForEach(delegate(TItem value)
				{
					if (!value.CheckIfSelfItem(this.Index) && value.CheckOverlap(this.Delegate.GetBounceX(), this.Delegate.GetBounceY()))
					{
						newOverlayTmp.Add(value);
					}
				});
			}
			int overlapIndex = this.Delegate.GetOverlapIndex(newOverlayTmp);
			if (this.CheckList != null && overlapIndex >= 0)
			{
				titem = this.CheckList[overlapIndex];
			}
			if (this.CurrentStaying != titem)
			{
				TItem titem2 = this.CurrentStaying;
				if (titem2 != null)
				{
					titem2.OnUnOverlay();
				}
				TItem titem3 = titem;
				if (titem3 != null)
				{
					titem3.OnOverlay();
				}
			}
			this.CurrentStaying = titem;
			if (this.ScrollViewBounceX.X != 0.0)
			{
				if (this.Delegate.CheckOverlap(this.ScrollViewBounceX, this.ScrollViewBounceY))
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

		// Token: 0x0603161E RID: 202270 RVA: 0x00C4A224 File Offset: 0x00C48424
		[NullableContext(0)]
		public ValueTuple<float, float> GetMiddlePosition()
		{
			return new ValueTuple<float, float>(this.DragComponent.RootUIComp.Get().GetLGUISpaceCenterAbsolutePosition().X, this.DragComponent.RootUIComp.Get().GetLGUISpaceCenterAbsolutePosition().Y);
		}

		// Token: 0x0603161F RID: 202271 RVA: 0x00C4A270 File Offset: 0x00C48470
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

		// Token: 0x06031620 RID: 202272 RVA: 0x00C4A2D8 File Offset: 0x00C484D8
		public UniTask TickDoCeaseAnimation(float currentProgress)
		{
			CommonDragItemLogic<TItem, TData>.<TickDoCeaseAnimation>d__102 <TickDoCeaseAnimation>d__;
			<TickDoCeaseAnimation>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<TickDoCeaseAnimation>d__.<>4__this = this;
			<TickDoCeaseAnimation>d__.currentProgress = currentProgress;
			<TickDoCeaseAnimation>d__.<>1__state = -1;
			<TickDoCeaseAnimation>d__.<>t__builder.Start<CommonDragItemLogic<TItem, TData>.<TickDoCeaseAnimation>d__102>(ref <TickDoCeaseAnimation>d__);
			return <TickDoCeaseAnimation>d__.<>t__builder.Task;
		}

		// Token: 0x06031621 RID: 202273 RVA: 0x00C4A323 File Offset: 0x00C48523
		public void SetMovingState(bool state)
		{
			this.MovingState = state;
		}

		// Token: 0x0401C5B5 RID: 116149
		public CustomPromise<bool> CeaseAnimationPromise;

		// Token: 0x0401C5B6 RID: 116150
		private readonly TItem Delegate;

		// Token: 0x0401C5B7 RID: 116151
		private readonly UUIDraggableComponent DragComponent;

		// Token: 0x0401C5B8 RID: 116152
		private readonly int Index = -1;

		// Token: 0x0401C5B9 RID: 116153
		protected Action<int> OnPointerDownCallBack;

		// Token: 0x0401C5BA RID: 116154
		[Nullable(new byte[]
		{
			2,
			1
		})]
		protected Action<int, TData> OnEndDragWhenOnScrollViewCallBack;

		// Token: 0x0401C5BB RID: 116155
		protected Action<int> OnMoveToScrollViewCallBack;

		// Token: 0x0401C5BC RID: 116156
		protected Action<int> OnRemoveFromScrollViewCallBack;

		// Token: 0x0401C5BD RID: 116157
		protected Action<int> ClickFunction;

		// Token: 0x0401C5BE RID: 116158
		protected Action<int> ClickFailFunction;

		// Token: 0x0401C5BF RID: 116159
		protected Action<int> OnBeginDragFunction;

		// Token: 0x0401C5C0 RID: 116160
		protected Action<int> OnDragAnimationStartFunction;

		// Token: 0x0401C5C1 RID: 116161
		protected Action<int> OnDragAnimationEndFunction;

		// Token: 0x0401C5C2 RID: 116162
		[Nullable(new byte[]
		{
			2,
			1,
			2
		})]
		protected Action<TItem, TItem, bool> OnDragEndFunction;

		// Token: 0x0401C5C3 RID: 116163
		private ULGUIPointerEventData CurrentMoveData;

		// Token: 0x0401C5C4 RID: 116164
		private bool CurrentClickState;

		// Token: 0x0401C5C5 RID: 116165
		private float CurrentRunningTime;

		// Token: 0x0401C5C6 RID: 116166
		private bool IfDragMove;

		// Token: 0x0401C5C7 RID: 116167
		private bool PlayDragSequenceState;

		// Token: 0x0401C5C8 RID: 116168
		private int CurrentTick = -1;

		// Token: 0x0401C5C9 RID: 116169
		private bool IfBeginDrag;

		// Token: 0x0401C5CA RID: 116170
		private int CurrentCheckFingerTick = -1;

		// Token: 0x0401C5CB RID: 116171
		private double LastClickTime;

		// Token: 0x0401C5CC RID: 116172
		[Nullable(1)]
		private readonly Vector StaticBeginVector = Vector.Create();

		// Token: 0x0401C5CD RID: 116173
		[Nullable(new byte[]
		{
			2,
			1
		})]
		protected List<TItem> CheckList;

		// Token: 0x0401C5CE RID: 116174
		protected TItem CurrentStaying;

		// Token: 0x0401C5CF RID: 116175
		private bool CeaseFailAnimationState;

		// Token: 0x0401C5D0 RID: 116176
		private bool DragState;

		// Token: 0x0401C5D1 RID: 116177
		private readonly LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x0401C5D2 RID: 116178
		private float MoveParentDelay;

		// Token: 0x0401C5D3 RID: 116179
		private Vector2D StartPosition;

		// Token: 0x0401C5D4 RID: 116180
		private Vector2D AnimationTargetPosition;

		// Token: 0x0401C5D5 RID: 116181
		private readonly UUIItem MovingParent;

		// Token: 0x0401C5D6 RID: 116182
		private readonly UUIItem NormalParent;

		// Token: 0x0401C5D7 RID: 116183
		private readonly FVector2D? StretchVector;

		// Token: 0x0401C5D8 RID: 116184
		private readonly UUIItem DragItem;

		// Token: 0x0401C5D9 RID: 116185
		[Nullable(1)]
		private readonly Vector2D ScrollViewBounceX = new Vector2D(0.0, 0.0);

		// Token: 0x0401C5DA RID: 116186
		[Nullable(1)]
		private readonly Vector2D ScrollViewBounceY = new Vector2D(0.0, 0.0);

		// Token: 0x0401C5DB RID: 116187
		private bool IfStayInScrollView;

		// Token: 0x0401C5DC RID: 116188
		[Nullable(1)]
		private readonly Vector2D CurrentAnimationTargetPos = new Vector2D(0.0, 0.0);

		// Token: 0x0401C5DD RID: 116189
		private bool CeaseState;

		// Token: 0x0401C5DE RID: 116190
		[Nullable(1)]
		private readonly Vector2D AnimationStartPos = new Vector2D(0.0, 0.0);

		// Token: 0x0401C5DF RID: 116191
		private bool MovingState;

		// Token: 0x0401C5E0 RID: 116192
		private readonly ULGUICanvas Canvas;

		// Token: 0x0401C5E1 RID: 116193
		private const float CLICKCALLGAP = 0.1f;

		// Token: 0x0401C5E2 RID: 116194
		private const int MOVEPARENTDELAYTIME = 1;

		// Token: 0x0401C5E3 RID: 116195
		private const int HEIGHTCANVASSORT = 100;
	}
}
