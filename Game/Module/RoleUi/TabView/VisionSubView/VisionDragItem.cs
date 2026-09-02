using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Common;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.RoleUi.TabView.VisionSubView
{
	// Token: 0x02005070 RID: 20592
	[NullableContext(2)]
	[Nullable(0)]
	public class VisionDragItem : UiPanelBase
	{
		// Token: 0x06035132 RID: 217394 RVA: 0x00D4F8B0 File Offset: 0x00D4DAB0
		[NullableContext(1)]
		public VisionDragItem(UUIItem uiItem, UUIDraggableComponent dragComponent, UUISprite bgSprite, UUITexture middleTexture, EPhantomItemIndex index)
		{
			this.DragComponent = dragComponent;
			this.DragItem = (dragComponent.GetOwner().GetComponentByClass(UUIItem.StaticClass()) as UUIItem);
			this.BgSprite = bgSprite;
			this.MiddleTexture = middleTexture;
			this.Index = (int)index;
			this.NormalParent = uiItem;
			this.LevelSequencePlayer = new LevelSequencePlayer(this.DragItem);
			this.LevelSequencePlayer.BindSequenceCloseEvent(new TSequenceEndEvent(this.FinishSequenceEvent), false);
			this.SourceItem = uiItem;
			this.StretchVector = new FVector2D?(Vector2D.Create(0.0, 0.0).ToUeVector2D(false));
			this.SourceWidth = uiItem.Width;
			this.SourceHeight = uiItem.Width;
		}

		// Token: 0x06035133 RID: 217395 RVA: 0x00D4F9E8 File Offset: 0x00D4DBE8
		public void Init()
		{
			base.CreateThenShowByActor(this.SourceItem.GetOwner(), null);
		}

		// Token: 0x06035134 RID: 217396 RVA: 0x00D4F9FC File Offset: 0x00D4DBFC
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

		// Token: 0x06035135 RID: 217397 RVA: 0x00D4FA2D File Offset: 0x00D4DC2D
		public void SetDragItemHierarchyMax()
		{
			this.GetDragRoot().SetAsLastHierarchy();
		}

		// Token: 0x06035136 RID: 217398 RVA: 0x00D4FA3A File Offset: 0x00D4DC3A
		public UUIItem GetDragRoot()
		{
			return this.DragItem;
		}

		// Token: 0x06035137 RID: 217399 RVA: 0x00D4FA42 File Offset: 0x00D4DC42
		[NullableContext(1)]
		public void SetDragCheckItem(List<VisionDragItem> itemList)
		{
			this.CheckList = itemList;
		}

		// Token: 0x06035138 RID: 217400 RVA: 0x00D4FA4B File Offset: 0x00D4DC4B
		[NullableContext(1)]
		public void SetDraggingParent(UUIItem item)
		{
			this.DraggingParent = item;
		}

		// Token: 0x06035139 RID: 217401 RVA: 0x00D4FA54 File Offset: 0x00D4DC54
		[NullableContext(1)]
		public void SetOnDragAnimationStartFunction(Action<int> onFunction)
		{
			this.OnDragAnimationStartFunction = onFunction;
		}

		// Token: 0x0603513A RID: 217402 RVA: 0x00D4FA5D File Offset: 0x00D4DC5D
		[NullableContext(1)]
		public void SetOnDragAnimationEndFunction(Action<int> onFunction)
		{
			this.OnDragAnimationEndFunction = onFunction;
		}

		// Token: 0x0603513B RID: 217403 RVA: 0x00D4FA66 File Offset: 0x00D4DC66
		[NullableContext(1)]
		public void SetOnClickCallBack(Action<int> onFunction)
		{
			this.ClickFunction = onFunction;
		}

		// Token: 0x0603513C RID: 217404 RVA: 0x00D4FA6F File Offset: 0x00D4DC6F
		[NullableContext(1)]
		public void SetOnClickFailCallBack(Action<int> onFunction)
		{
			this.ClickFailFunction = onFunction;
		}

		// Token: 0x0603513D RID: 217405 RVA: 0x00D4FA78 File Offset: 0x00D4DC78
		[NullableContext(1)]
		public void SetOnBeginDragCall(Action<int> onFunction)
		{
			this.OnBeginDragFunction = onFunction;
		}

		// Token: 0x0603513E RID: 217406 RVA: 0x00D4FA84 File Offset: 0x00D4DC84
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

		// Token: 0x0603513F RID: 217407 RVA: 0x00D4FAEB File Offset: 0x00D4DCEB
		public bool CheckAndGetCurrentClickState()
		{
			return this.CurrentClickState;
		}

		// Token: 0x06035140 RID: 217408 RVA: 0x00D4FAF3 File Offset: 0x00D4DCF3
		[NullableContext(1)]
		public void SetDragSuccessCallBack(Action<VisionDragItem, List<VisionDragItem>> onFunction)
		{
			this.OnDragEndFunction = onFunction;
		}

		// Token: 0x06035141 RID: 217409 RVA: 0x00D4FAFC File Offset: 0x00D4DCFC
		public Vector2D GetAnimationTargetPos()
		{
			return this.AnimationTargetPosition;
		}

		// Token: 0x06035142 RID: 217410 RVA: 0x00D4FB04 File Offset: 0x00D4DD04
		public void ClearStayingItem()
		{
			this.CurrentStaying.Clear();
		}

		// Token: 0x06035143 RID: 217411 RVA: 0x00D4FB11 File Offset: 0x00D4DD11
		[NullableContext(1)]
		public List<VisionDragItem> GetStayingItem()
		{
			return this.CurrentStaying;
		}

		// Token: 0x06035144 RID: 217412 RVA: 0x00D4FB1C File Offset: 0x00D4DD1C
		public void DoDragSequence()
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

		// Token: 0x06035145 RID: 217413 RVA: 0x00D4FB68 File Offset: 0x00D4DD68
		public void DoCeaseSequence()
		{
			this.CeaseFailAnimationState = false;
			this.CeaseAnimationPromise = new CustomPromise<bool>();
			this.LevelSequencePlayer.PlayLevelSequenceByName("Cease", false, null, false);
		}

		// Token: 0x06035146 RID: 217414 RVA: 0x00D4FBA4 File Offset: 0x00D4DDA4
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

		// Token: 0x06035147 RID: 217415 RVA: 0x00D4FBEA File Offset: 0x00D4DDEA
		public void ResetPositionThenStartDragState()
		{
			this.ResetPosition();
			this.StartDragState();
		}

		// Token: 0x06035148 RID: 217416 RVA: 0x00D4FBF8 File Offset: 0x00D4DDF8
		public void CacheStartDragPosition()
		{
			this.DragComponent.RootUIComp.Get().SetAnchorAlign(UIAnchorHorizontalAlign.Center, UIAnchorVerticalAlign.Middle);
			FVector lguispaceAbsolutePosition = this.DragComponent.RootUIComp.Get().GetLGUISpaceAbsolutePosition();
			this.DragComponent.RootUIComp.Get().SetUIParent(this.DraggingParent, true);
			this.DragComponent.RootUIComp.Get().SetLGUISpaceAbsolutePosition(lguispaceAbsolutePosition);
			FVector lguispaceAbsolutePosition2 = this.DragComponent.RootUIComp.Get().GetLGUISpaceAbsolutePosition();
			this.StartPosition = new Vector2D((double)lguispaceAbsolutePosition2.X, (double)lguispaceAbsolutePosition2.Y);
			this.AnimationTargetPosition = new Vector2D((double)lguispaceAbsolutePosition.X, (double)lguispaceAbsolutePosition.Y);
			this.BackDragItemToNormalParent();
			FVector uiitemScale = new FVector(1f, 1f, 1f);
			this.DragComponent.RootUIComp.Get().SetUIItemScale(uiitemScale);
		}

		// Token: 0x06035149 RID: 217417 RVA: 0x00D4FCF4 File Offset: 0x00D4DEF4
		public void StartDragState()
		{
			this.DragState = true;
			this.DragComponent.RootUIComp.Get().SetAnchorAlign(UIAnchorHorizontalAlign.Center, UIAnchorVerticalAlign.Middle);
			FVector lguispaceAbsolutePosition = this.DragComponent.RootUIComp.Get().GetLGUISpaceAbsolutePosition();
			this.DragComponent.RootUIComp.Get().SetUIParent(this.DraggingParent, true);
			this.DragComponent.RootUIComp.Get().SetLGUISpaceAbsolutePosition(lguispaceAbsolutePosition);
			this.MoveParentDelay = 0;
		}

		// Token: 0x0603514A RID: 217418 RVA: 0x00D4FD7C File Offset: 0x00D4DF7C
		public void SetItemToSourceSize()
		{
			this.DragComponent.RootUIComp.Get().SetWidth(this.SourceWidth);
			this.DragComponent.RootUIComp.Get().SetHeight(this.SourceHeight);
		}

		// Token: 0x0603514B RID: 217419 RVA: 0x00D4FDC8 File Offset: 0x00D4DFC8
		public void StartClickCheckTimer()
		{
			this.ClearFingerTick();
			Ticker ticker = Singleton<TickSystem>.Instance.Add(delegate(float _)
			{
				if (this.GetCurrentFinger() == 0)
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

		// Token: 0x0603514C RID: 217420 RVA: 0x00D4FE0C File Offset: 0x00D4E00C
		public void OnDragBegin(ULGUIPointerEventData eventData)
		{
			if (!ModelBase<PhantomBattleModel>.Instance.CheckIfCurrentDragIndex(this.Index))
			{
				return;
			}
			this.OnDragStartVector.X = (double)this.DragComponent.RootUIComp.Get().GetAnchorOffsetX();
			this.OnDragStartVector.Y = (double)this.DragComponent.RootUIComp.Get().GetAnchorOffsetY();
			this.CurrentStaying.Clear();
			this.IfDragMove = true;
			this.OnBeginDrag();
		}

		// Token: 0x0603514D RID: 217421 RVA: 0x00D4FE8C File Offset: 0x00D4E08C
		[NullableContext(1)]
		public void SetPointerDownCallBack(Action<int> dragEvent)
		{
			this.OnPointerDownCallBack = dragEvent;
		}

		// Token: 0x0603514E RID: 217422 RVA: 0x00D4FE98 File Offset: 0x00D4E098
		public void OnPointerDown(ULGUIPointerEventData eventData)
		{
			if (!ModelBase<PhantomBattleModel>.Instance.CheckIfCanDrag())
			{
				return;
			}
			if (ModelBase<PhantomBattleModel>.Instance.CheckIfCanDrag())
			{
				ModelBase<PhantomBattleModel>.Instance.SetCurrentDragIndex(this.Index);
			}
			this.CurrentClickState = false;
			this.CurrentRunningTime = 0f;
			this.PlayDragSequenceState = false;
			this.IfDragMove = false;
			this.CeaseAnimationPromise = null;
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

		// Token: 0x0603514F RID: 217423 RVA: 0x00D4FF50 File Offset: 0x00D4E150
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

		// Token: 0x06035150 RID: 217424 RVA: 0x00D4FF84 File Offset: 0x00D4E184
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

		// Token: 0x06035151 RID: 217425 RVA: 0x00D50008 File Offset: 0x00D4E208
		private int GetCurrentFinger()
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

		// Token: 0x06035152 RID: 217426 RVA: 0x00D5003C File Offset: 0x00D4E23C
		public void SetToTargetParentAndSetStretch(UUIItem targetItem)
		{
			this.DragComponent.RootUIComp.Get().SetAnchorAlign(UIAnchorHorizontalAlign.Stretch, UIAnchorVerticalAlign.Stretch);
			this.DragComponent.RootUIComp.Get().SetUIParent(targetItem, true);
			this.DragComponent.RootUIComp.Get().SetVerticalStretch(this.StretchVector.Value);
			this.DragComponent.RootUIComp.Get().SetHorizontalStretch(this.StretchVector.Value);
		}

		// Token: 0x06035153 RID: 217427 RVA: 0x00D500C3 File Offset: 0x00D4E2C3
		public void SetToNormalParent()
		{
			this.SetToTargetParentAndSetStretch(this.NormalParent);
		}

		// Token: 0x06035154 RID: 217428 RVA: 0x00D500D4 File Offset: 0x00D4E2D4
		public void ResetPosition()
		{
			if (this.CeaseFailAnimationState)
			{
				this.TryDoCeaseFailSequence();
			}
			this.CeaseFailAnimationState = false;
			if (!this.DragState)
			{
				return;
			}
			this.EndDragState();
			if (this.StartPosition != null)
			{
				this.DragComponent.RootUIComp.Get().SetAnchorOffset(this.StretchVector.Value);
			}
			this.DragState = false;
		}

		// Token: 0x06035155 RID: 217429 RVA: 0x00D50137 File Offset: 0x00D4E337
		private void EndDragState()
		{
			this.BackDragItemToNormalParent();
		}

		// Token: 0x06035156 RID: 217430 RVA: 0x00D50140 File Offset: 0x00D4E340
		private void BackDragItemToNormalParent()
		{
			this.DragComponent.RootUIComp.Get().SetAnchorAlign(UIAnchorHorizontalAlign.Stretch, UIAnchorVerticalAlign.Stretch);
			this.DragComponent.RootUIComp.Get().SetUIParent(this.NormalParent, true);
			FVector uiitemScale = new FVector(1f, 1f, 1f);
			this.DragComponent.RootUIComp.Get().SetUIItemScale(uiitemScale);
			this.DragComponent.RootUIComp.Get().SetHorizontalStretch(this.StretchVector.Value);
			this.DragComponent.RootUIComp.Get().SetVerticalStretch(this.StretchVector.Value);
		}

		// Token: 0x06035157 RID: 217431 RVA: 0x00D501FC File Offset: 0x00D4E3FC
		public void OnPointUp(ULGUIPointerEventData eventData)
		{
			this.ClearTick();
			this.ClearFingerTick();
			if (!ModelBase<PhantomBattleModel>.Instance.CheckIfCurrentDragIndex(this.Index))
			{
				return;
			}
			ModelBase<PhantomBattleModel>.Instance.ClearCurrentDragIndex();
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
		}

		// Token: 0x06035158 RID: 217432 RVA: 0x00D50262 File Offset: 0x00D4E462
		private bool CheckInClickableTime()
		{
			return this.CurrentRunningTime < 300f && this.CheckInClickGap();
		}

		// Token: 0x06035159 RID: 217433 RVA: 0x00D50279 File Offset: 0x00D4E479
		private bool CheckInClickGap()
		{
			return Singleton<Info>.Instance.IsInGamepad() || Singleton<TimeUtil>.Instance.GetServerTime() - this.LastClickTime > 1.0;
		}

		// Token: 0x0603515A RID: 217434 RVA: 0x00D502A5 File Offset: 0x00D4E4A5
		protected void OnBeginDrag()
		{
			this.IfBeginDrag = true;
		}

		// Token: 0x0603515B RID: 217435 RVA: 0x00D502AE File Offset: 0x00D4E4AE
		private void ClearFingerTick()
		{
			if (this.CurrentCheckFingerTick != -1)
			{
				Singleton<TickSystem>.Instance.Remove(this.CurrentCheckFingerTick);
				this.CurrentCheckFingerTick = -1;
			}
		}

		// Token: 0x0603515C RID: 217436 RVA: 0x00D502D1 File Offset: 0x00D4E4D1
		private void ClearTick()
		{
			if (this.CurrentTick != -1)
			{
				Singleton<TickSystem>.Instance.Remove(this.CurrentTick);
				this.CurrentTick = -1;
			}
		}

		// Token: 0x0603515D RID: 217437 RVA: 0x00D502F4 File Offset: 0x00D4E4F4
		public void OnDragEnd(ULGUIPointerEventData eventData)
		{
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
				else
				{
					Action<VisionDragItem, List<VisionDragItem>> onDragEndFunction = this.OnDragEndFunction;
					if (onDragEndFunction != null)
					{
						onDragEndFunction(this, this.CurrentStaying);
					}
				}
				this.IfDragMove = false;
			}
		}

		// Token: 0x0603515E RID: 217438 RVA: 0x00D50348 File Offset: 0x00D4E548
		public void SetItemToPointerPosition()
		{
			if (!this.DragState)
			{
				return;
			}
			FVector worldPointInPlane = Singleton<LguiEventSystemManager>.Instance.GetPointerEventData(0, false).GetWorldPointInPlane();
			float num = ConfigBase<PhantomBattleConfig>.Instance.GetVisionScrollerOffsetX() * (float)ConfigBase<PhantomBattleConfig>.Instance.GetVisionScrollerOffsetXDir();
			float num2 = ConfigBase<PhantomBattleConfig>.Instance.GetVisionScrollerOffsetY() * (float)ConfigBase<PhantomBattleConfig>.Instance.GetVisionScrollerOffsetYDir();
			float num3 = worldPointInPlane.X + num;
			float num4 = worldPointInPlane.Z + num2;
			if (this.StaticBeginVector.X == (double)num3 && this.StaticBeginVector.Y == (double)num4)
			{
				return;
			}
			this.StaticBeginVector.X = (double)num3;
			this.StaticBeginVector.Y = (double)num4;
			this.DragComponent.RootUIComp.Get().SetAnchorOffsetX((float)this.StaticBeginVector.X);
			this.DragComponent.RootUIComp.Get().SetAnchorOffsetY((float)this.StaticBeginVector.Y);
		}

		// Token: 0x0603515F RID: 217439 RVA: 0x00D50431 File Offset: 0x00D4E631
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

		// Token: 0x06035160 RID: 217440 RVA: 0x00D50458 File Offset: 0x00D4E658
		[NullableContext(0)]
		public ValueTuple<float, float> GetMiddlePosition()
		{
			return new ValueTuple<float, float>(this.DragComponent.RootUIComp.Get().GetLGUISpaceCenterAbsolutePosition().X, this.DragComponent.RootUIComp.Get().GetLGUISpaceCenterAbsolutePosition().Y);
		}

		// Token: 0x06035161 RID: 217441 RVA: 0x00D504A4 File Offset: 0x00D4E6A4
		private void OnDrag(ULGUIPointerEventData eventData)
		{
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

		// Token: 0x06035162 RID: 217442 RVA: 0x00D504E0 File Offset: 0x00D4E6E0
		private void CheckOnDrag()
		{
			List<VisionDragItem> list = new List<VisionDragItem>();
			if (this.CheckList != null)
			{
				foreach (VisionDragItem visionDragItem in this.CheckList)
				{
					if (!visionDragItem.CheckIfSelfItem(this.Index) && visionDragItem.CheckOverlap(this.GetBounceX(), this.GetBounceY()))
					{
						list.Add(visionDragItem);
					}
				}
			}
			foreach (VisionDragItem visionDragItem2 in this.CurrentStaying)
			{
				if (!list.Contains(visionDragItem2))
				{
					visionDragItem2.OnUnOverlay();
				}
			}
			foreach (VisionDragItem visionDragItem3 in list)
			{
				if (!this.CurrentStaying.Contains(visionDragItem3))
				{
					visionDragItem3.OnOverlay();
				}
			}
			this.CurrentStaying = list;
		}

		// Token: 0x06035163 RID: 217443 RVA: 0x00D50604 File Offset: 0x00D4E804
		public bool CheckIfSelfItem(int index)
		{
			return index == this.Index;
		}

		// Token: 0x06035164 RID: 217444 RVA: 0x00D5060F File Offset: 0x00D4E80F
		public int GetCurrentIndex()
		{
			return this.Index;
		}

		// Token: 0x06035165 RID: 217445 RVA: 0x00D50617 File Offset: 0x00D4E817
		public void Refresh(PhantomDataBase data)
		{
			this.CurrentData = data;
			this.RefreshIcon(data);
			this.RefreshQuality(data);
		}

		// Token: 0x06035166 RID: 217446 RVA: 0x00D5062E File Offset: 0x00D4E82E
		public PhantomDataBase GetCurrentData()
		{
			return this.CurrentData;
		}

		// Token: 0x06035167 RID: 217447 RVA: 0x00D50636 File Offset: 0x00D4E836
		protected void OnUnOverlay()
		{
			Action onUnOverlayCallBack = this.OnUnOverlayCallBack;
			if (onUnOverlayCallBack == null)
			{
				return;
			}
			onUnOverlayCallBack();
		}

		// Token: 0x06035168 RID: 217448 RVA: 0x00D50648 File Offset: 0x00D4E848
		protected void OnOverlay()
		{
			Action onOverlayCallBack = this.OnOverlayCallBack;
			if (onOverlayCallBack == null)
			{
				return;
			}
			onOverlayCallBack();
		}

		// Token: 0x06035169 RID: 217449 RVA: 0x00D5065C File Offset: 0x00D4E85C
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

		// Token: 0x0603516A RID: 217450 RVA: 0x00D506CC File Offset: 0x00D4E8CC
		private void RefreshIcon(PhantomDataBase data)
		{
			this.MiddleTexture.SetUIActive(data != null);
			if (data == null)
			{
				return;
			}
			ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(data.GetConfigId(true));
			base.SetTextureByPath(itemConfigData.IconMiddle, this.MiddleTexture, new EUiViewName?(EUiViewName.VisionEquipmentView), null);
		}

		// Token: 0x0603516B RID: 217451 RVA: 0x00D5071B File Offset: 0x00D4E91B
		private void RefreshQuality(PhantomDataBase data)
		{
			this.BgSprite.SetUIActive(data != null);
		}

		// Token: 0x0603516C RID: 217452 RVA: 0x00D5072C File Offset: 0x00D4E92C
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

		// Token: 0x0603516D RID: 217453 RVA: 0x00D50794 File Offset: 0x00D4E994
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

		// Token: 0x0401E8F1 RID: 125169
		private const int CLICKTIME = 300;

		// Token: 0x0401E8F2 RID: 125170
		private const int CLICKCALLGAP = 1;

		// Token: 0x0401E8F3 RID: 125171
		private const int MOVEPARENTDELAYTIME = 1;

		// Token: 0x0401E8F4 RID: 125172
		public CustomPromise<bool> CeaseAnimationPromise;

		// Token: 0x0401E8F5 RID: 125173
		private readonly UUIDraggableComponent DragComponent;

		// Token: 0x0401E8F6 RID: 125174
		private readonly UUISprite BgSprite;

		// Token: 0x0401E8F7 RID: 125175
		private readonly UUITexture MiddleTexture;

		// Token: 0x0401E8F8 RID: 125176
		private readonly int Index = -1;

		// Token: 0x0401E8F9 RID: 125177
		private PhantomDataBase CurrentData;

		// Token: 0x0401E8FA RID: 125178
		private Action<int> OnPointerDownCallBack;

		// Token: 0x0401E8FB RID: 125179
		public Action OnOverlayCallBack;

		// Token: 0x0401E8FC RID: 125180
		public Action OnUnOverlayCallBack;

		// Token: 0x0401E8FD RID: 125181
		protected Action<int> ClickFunction;

		// Token: 0x0401E8FE RID: 125182
		protected Action<int> ClickFailFunction;

		// Token: 0x0401E8FF RID: 125183
		private Action<int> OnBeginDragFunction;

		// Token: 0x0401E900 RID: 125184
		[Nullable(1)]
		private readonly Vector2D BounceX = new Vector2D(0.0, 0.0);

		// Token: 0x0401E901 RID: 125185
		[Nullable(1)]
		private readonly Vector2D BounceY = new Vector2D(0.0, 0.0);

		// Token: 0x0401E902 RID: 125186
		private readonly LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x0401E903 RID: 125187
		private Vector2D StartPosition;

		// Token: 0x0401E904 RID: 125188
		private UUIItem DraggingParent;

		// Token: 0x0401E905 RID: 125189
		private Vector2D AnimationTargetPosition;

		// Token: 0x0401E906 RID: 125190
		private int CurrentTick = -1;

		// Token: 0x0401E907 RID: 125191
		private int CurrentCheckFingerTick = -1;

		// Token: 0x0401E908 RID: 125192
		private ULGUIPointerEventData CurrentMoveData;

		// Token: 0x0401E909 RID: 125193
		[Nullable(1)]
		private List<VisionDragItem> CurrentStaying = new List<VisionDragItem>();

		// Token: 0x0401E90A RID: 125194
		private float CurrentRunningTime;

		// Token: 0x0401E90B RID: 125195
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private List<VisionDragItem> CheckList;

		// Token: 0x0401E90C RID: 125196
		[Nullable(new byte[]
		{
			2,
			1,
			1,
			1
		})]
		private Action<VisionDragItem, List<VisionDragItem>> OnDragEndFunction;

		// Token: 0x0401E90D RID: 125197
		private Action<int> OnDragAnimationStartFunction;

		// Token: 0x0401E90E RID: 125198
		private Action<int> OnDragAnimationEndFunction;

		// Token: 0x0401E90F RID: 125199
		private readonly UUIItem NormalParent;

		// Token: 0x0401E910 RID: 125200
		[Nullable(1)]
		private readonly Vector StaticBeginVector = Vector.Create();

		// Token: 0x0401E911 RID: 125201
		[Nullable(1)]
		private readonly Vector OnDragStartVector = Vector.Create();

		// Token: 0x0401E912 RID: 125202
		private readonly UUIItem DragItem;

		// Token: 0x0401E913 RID: 125203
		private bool DragState;

		// Token: 0x0401E914 RID: 125204
		private bool IfDragMove;

		// Token: 0x0401E915 RID: 125205
		private bool CurrentClickState;

		// Token: 0x0401E916 RID: 125206
		private double LastClickTime;

		// Token: 0x0401E917 RID: 125207
		private bool PlayDragSequenceState;

		// Token: 0x0401E918 RID: 125208
		private bool CeaseFailAnimationState;

		// Token: 0x0401E919 RID: 125209
		private readonly FVector2D? StretchVector;

		// Token: 0x0401E91A RID: 125210
		private readonly UUIItem SourceItem;

		// Token: 0x0401E91B RID: 125211
		private readonly float SourceWidth;

		// Token: 0x0401E91C RID: 125212
		private readonly float SourceHeight;

		// Token: 0x0401E91D RID: 125213
		private int MoveParentDelay;

		// Token: 0x0401E91E RID: 125214
		private bool IfBeginDrag;
	}
}
