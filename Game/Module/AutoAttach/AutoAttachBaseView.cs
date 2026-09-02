using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.AutoAttach
{
	// Token: 0x02006156 RID: 24918
	[NullableContext(2)]
	[Nullable(0)]
	public abstract class AutoAttachBaseView<T, [Nullable(0)] TAttachItem> : IAutoAttachBaseView<T> where TAttachItem : AutoAttachItem<T>
	{
		// Token: 0x0603EF4F RID: 257871 RVA: 0x0102309C File Offset: 0x0102129C
		[NullableContext(1)]
		public AutoAttachBaseView(AActor controllerActor, bool isNeedScrollCallback = false)
		{
			this.ControllerActor = controllerActor;
			this.ControllerItem = (controllerActor.GetComponentByClass(UUIItem.StaticClass()) as UUIItem);
			UUIItem controllerItem = this.ControllerItem;
			this.ControllerHeight = ((controllerItem != null) ? controllerItem.Height : 0f);
			UUIItem controllerItem2 = this.ControllerItem;
			this.ControllerWidth = ((controllerItem2 != null) ? controllerItem2.Width : 0f);
			this.CurrentMoveOffsetMap[EMoveType.Velocity] = 0f;
			this.CurrentMoveOffsetMap[EMoveType.Inertia] = 0f;
			Ticker ticker = Singleton<TickSystem>.Instance.Add(new Action<float>(this.Tick), "AutoAttachBaseView", ETickingGroup.TG_PrePhysics, true, 0, true);
			this.TickId = ((ticker != null) ? ticker.Id : -1);
			this.VelocityCurve = Singleton<ResourceSystem>.Instance.GetLoadedAsset<UCurveFloat>("/Game/Aki/UI/UIResources/Common/LevelSequence/Curve/VelocityCurve.VelocityCurve");
			this.InertiaCurve = Singleton<ResourceSystem>.Instance.GetLoadedAsset<UCurveFloat>("/Game/Aki/UI/UIResources/Common/LevelSequence/Curve/InertiaCurve.InertiaCurve");
			this.BoundaryCurve = Singleton<ResourceSystem>.Instance.GetLoadedAsset<UCurveFloat>("/Game/Aki/UI/UIResources/Common/LevelSequence/Curve/BoundaryCurve.BoundaryCurve");
			this.FullVelocityTime = ConfigBase<CommonConfig>.Instance.GetAutoAttachVelocityTime().GetValueOrDefault();
			this.FullInertiaTime = ConfigBase<CommonConfig>.Instance.GetAutoAttachInertiaTime().GetValueOrDefault();
			this.IsMoving = false;
			UUIItem controllerItem3 = this.ControllerItem;
			AUIBaseActor auibaseActor = ((controllerItem3 != null) ? controllerItem3.GetOwner() : null) as AUIBaseActor;
			if (auibaseActor != null)
			{
				auibaseActor.OnPreDestroyed.Add(new Action<AActor>(this.OnActorDestroy));
			}
			this.IsNeedScrollCallback = isNeedScrollCallback;
		}

		// Token: 0x0603EF50 RID: 257872 RVA: 0x01023272 File Offset: 0x01021472
		private void OnActorDestroy(AActor actor)
		{
			this.Clear();
		}

		// Token: 0x0603EF51 RID: 257873 RVA: 0x0102327A File Offset: 0x0102147A
		public virtual float GetTrueBoundary()
		{
			return 0f;
		}

		// Token: 0x0603EF52 RID: 257874 RVA: 0x01023281 File Offset: 0x01021481
		public void SetItemSelectMode(EAttachMode mode)
		{
			this.SelectItemModel = mode;
		}

		// Token: 0x0603EF53 RID: 257875 RVA: 0x0102328A File Offset: 0x0102148A
		public void SetPageLimitState(bool state)
		{
			this.PageLimitState = state;
		}

		// Token: 0x0603EF54 RID: 257876 RVA: 0x01023293 File Offset: 0x01021493
		public void SetMoveMultiFactor(float value)
		{
			this.MoveMultiFactor = value;
		}

		// Token: 0x0603EF55 RID: 257877 RVA: 0x0102329C File Offset: 0x0102149C
		[NullableContext(1)]
		public void SetDragBeginCallback(Action callback)
		{
			this.DragBegin = callback;
		}

		// Token: 0x0603EF56 RID: 257878 RVA: 0x010232A5 File Offset: 0x010214A5
		[NullableContext(1)]
		public void SetMoveItemsCallback(Action callback)
		{
			this.MoveItemsCallback = callback;
		}

		// Token: 0x0603EF57 RID: 257879 RVA: 0x010232AE File Offset: 0x010214AE
		[NullableContext(1)]
		public void SetAudioEvent(string eventName)
		{
			this.AudioEvent = eventName;
		}

		// Token: 0x0603EF58 RID: 257880 RVA: 0x010232B7 File Offset: 0x010214B7
		public bool IsVelocityMoveState()
		{
			return this.VelocityMoveState;
		}

		// Token: 0x0603EF59 RID: 257881 RVA: 0x010232C0 File Offset: 0x010214C0
		[NullableContext(1)]
		public void CreateItems(AActor itemActor, float initGap, Func<AActor, int, int, TAttachItem> createFunction, EAttachDirection direction = EAttachDirection.Horizontal)
		{
			this.EnableDragEvent();
			this.CreateItemFunction = createFunction;
			this.SourceActor = itemActor;
			this.SourceItem = (this.SourceActor.GetComponentByClass(UUIItem.StaticClass()) as UUIItem);
			this.Gap = initGap;
			this.AttachDirection = new EAttachDirection?(direction);
			this.SourceItemHeight = this.SourceItem.Height;
			this.SourceItemWidth = this.SourceItem.Width;
			this.ShowItemNum = this.GetCurrentShowNum();
			this.MinusVelocityMoveDistance = this.GetItemGapSize() / 2f;
			this.InitDefaultMoveBoundary();
		}

		// Token: 0x0603EF5A RID: 257882 RVA: 0x0102335B File Offset: 0x0102155B
		public void SetMoveBoundary(float distance)
		{
			this.MoveBoundary = distance;
		}

		// Token: 0x0603EF5B RID: 257883 RVA: 0x01023364 File Offset: 0x01021564
		public EAttachDirection? GetCurrentMoveDirection()
		{
			return this.AttachDirection;
		}

		// Token: 0x0603EF5C RID: 257884 RVA: 0x0102336C File Offset: 0x0102156C
		private void InitDefaultMoveBoundary()
		{
			this.MoveBoundary = this.GetItemSize();
		}

		// Token: 0x0603EF5D RID: 257885 RVA: 0x0102337A File Offset: 0x0102157A
		public void SetBoundDistance(float size)
		{
			this.MoveBoundary = size;
		}

		// Token: 0x0603EF5E RID: 257886 RVA: 0x01023383 File Offset: 0x01021583
		protected float GetItemGapSize()
		{
			return this.GetItemSize() + this.Gap;
		}

		// Token: 0x0603EF5F RID: 257887 RVA: 0x01023394 File Offset: 0x01021594
		private int GetCurrentShowNum()
		{
			EAttachDirection? attachDirection = this.AttachDirection;
			EAttachDirection eattachDirection = EAttachDirection.Horizontal;
			float num;
			if (attachDirection.GetValueOrDefault() == eattachDirection & attachDirection != null)
			{
				num = this.ControllerWidth;
			}
			else
			{
				num = this.ControllerHeight;
			}
			float itemGapSize = this.GetItemGapSize();
			int num2 = (int)Math.Ceiling((double)(num / itemGapSize));
			if (num2 % 2 != 0)
			{
				return num2;
			}
			return num2 - 1;
		}

		// Token: 0x0603EF60 RID: 257888 RVA: 0x010233F4 File Offset: 0x010215F4
		public void EnableDragEvent()
		{
			if (this.ControllerActor != null)
			{
				UUIDraggableComponent uuidraggableComponent = this.ControllerActor.GetComponentByClass(UUIDraggableComponent.StaticClass()) as UUIDraggableComponent;
				if (uuidraggableComponent != null)
				{
					uuidraggableComponent.OnPointerBeginDragCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnPointerBeginDrag));
					uuidraggableComponent.OnPointerDragCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnPointerDragCallback));
					uuidraggableComponent.OnPointerEndDragCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnPointerDragEnd));
					uuidraggableComponent.NavigateToPrevDelegate.Bind(new Action(this.NavigateToPrev));
					uuidraggableComponent.NavigateToNextDelegate.Bind(new Action(this.NavigateToNext));
					if (this.IsNeedScrollCallback)
					{
						uuidraggableComponent.OnPointerScrollCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnPointerScrollCallBack));
					}
				}
			}
		}

		// Token: 0x0603EF61 RID: 257889 RVA: 0x010234C0 File Offset: 0x010216C0
		public void DisableDragEvent()
		{
			if (this.ControllerActor != null)
			{
				UUIDraggableComponent uuidraggableComponent = this.ControllerActor.GetComponentByClass(UUIDraggableComponent.StaticClass()) as UUIDraggableComponent;
				if (uuidraggableComponent != null)
				{
					uuidraggableComponent.OnPointerBeginDragCallBack.Unbind();
					uuidraggableComponent.OnPointerDragCallBack.Unbind();
					uuidraggableComponent.OnPointerEndDragCallBack.Unbind();
					uuidraggableComponent.NavigateToPrevDelegate.Unbind();
					uuidraggableComponent.NavigateToNextDelegate.Unbind();
				}
			}
		}

		// Token: 0x0603EF62 RID: 257890 RVA: 0x0102352A File Offset: 0x0102172A
		public float GetGap()
		{
			return this.Gap;
		}

		// Token: 0x0603EF63 RID: 257891 RVA: 0x01023534 File Offset: 0x01021734
		public float GetItemSize()
		{
			EAttachDirection? attachDirection = this.AttachDirection;
			EAttachDirection eattachDirection = EAttachDirection.Horizontal;
			float result;
			if (attachDirection.GetValueOrDefault() == eattachDirection & attachDirection != null)
			{
				result = this.SourceItemWidth;
			}
			else
			{
				result = this.SourceItemHeight;
			}
			return result;
		}

		// Token: 0x0603EF64 RID: 257892 RVA: 0x01023578 File Offset: 0x01021778
		public float GetViewSize()
		{
			EAttachDirection? attachDirection = this.AttachDirection;
			EAttachDirection eattachDirection = EAttachDirection.Horizontal;
			float result;
			if (attachDirection.GetValueOrDefault() == eattachDirection & attachDirection != null)
			{
				result = this.ControllerWidth;
			}
			else
			{
				result = this.ControllerHeight;
			}
			return result;
		}

		// Token: 0x0603EF65 RID: 257893 RVA: 0x010235BC File Offset: 0x010217BC
		protected void Tick(float delta)
		{
			USequencerManager sequencerManager = ALGUIManagerActor.GetSequencerManager(GlobalData.World);
			float num = (sequencerManager != null) ? sequencerManager.GetGlobalPlayRate() : 1f;
			float deltaTime = delta * num;
			if (this.ForceToItemIndex != null)
			{
				this.MoveToShowIndexForce(this.ForceToItemIndex.Value);
				this.ForceToItemIndex = null;
			}
			if (this.ForceSelectItemCache != null)
			{
				this.MoveToItemForce(this.ForceSelectItemCache);
				this.ForceSelectItemCache = default(TAttachItem);
			}
			if (this.NeedDelayApplyCachePointerDragData)
			{
				this.OnPointerDragDelay++;
				if (this.OnPointerDragDelay >= 1)
				{
					this.NeedDelayApplyCachePointerDragData = false;
					this.ApplyCachePointerDragData(this.OnPointerDragCacheData);
				}
			}
			if (!this.DragState && (this.InertiaState || this.VelocityMoveState))
			{
				if (this.VelocityMoveState)
				{
					this.DoVelocityMove(deltaTime);
				}
				else if (this.CurrentRunningElasticTime < this.FullInertiaTime)
				{
					this.DoElasticMove(deltaTime);
				}
				else
				{
					this.CheckInertiaSelectState = true;
					this.InertiaState = false;
				}
			}
			else
			{
				if (this.CheckInertiaSelectState)
				{
					this.CheckInertiaSelectState = false;
					this.CurrentRunningElasticTime = 0f;
					if (!this.CurrentSelectState && this.SelectItemModel == EAttachMode.EndMove)
					{
						int count = this.Items.Count;
						for (int i = 0; i < count; i++)
						{
							TAttachItem tattachItem = this.Items[i];
							if (tattachItem.GetCurrentShowItemIndex() == this.CurrentSelectItemIndex && !tattachItem.GetSelectedState())
							{
								tattachItem.Select();
								this.CurrentSelectState = true;
							}
						}
					}
				}
				this.VelocityMoveState = false;
			}
			if (this.IsMoving != this.MovingState())
			{
				this.IsMoving = this.MovingState();
				if (this.IsMoving)
				{
					Action dragBegin = this.DragBegin;
					if (dragBegin == null)
					{
						return;
					}
					dragBegin();
				}
			}
		}

		// Token: 0x0603EF66 RID: 257894 RVA: 0x0102378C File Offset: 0x0102198C
		private void DoVelocityMove(float deltaTime)
		{
			float value = this.GetMoveTypeOffset(EMoveType.Velocity).Value;
			float num = value / this.FullVelocityTime;
			this.CurrentVelocityRunningTime += deltaTime;
			float num2 = this.CurrentVelocityRunningTime / this.FullVelocityTime;
			num2 = ((num2 > 1f) ? 1f : num2);
			float offset = num * this.GetCurveValue(this.VelocityCurve, num2) * deltaTime;
			float num3 = this.RecalculateMoveOffset(offset);
			if (Math.Abs(num3) < 0.01f)
			{
				num3 = 0f;
			}
			if (Math.Abs(this.CurrentVelocityMoveDelta + num3) > Math.Abs(value))
			{
				num3 = value - this.CurrentVelocityMoveDelta;
			}
			this.MoveItems(num3, false);
			this.CurrentVelocityMoveDelta += num3;
			if (this.VelocityDirection > 0f)
			{
				if (num3 <= 0f)
				{
					this.EndVelocityMove();
				}
			}
			else if (this.VelocityDirection < 0f && num3 >= 0f)
			{
				this.EndVelocityMove();
			}
			if (num2 >= 1f)
			{
				if (Math.Abs(this.CurrentVelocityMoveDelta) < Math.Abs(value))
				{
					this.CurrentVelocityRunningTime -= deltaTime;
					return;
				}
				this.EndVelocityMove();
			}
		}

		// Token: 0x0603EF67 RID: 257895 RVA: 0x010238A8 File Offset: 0x01021AA8
		private void DoElasticMove(float deltaTime)
		{
			float value = this.GetMoveTypeOffset(EMoveType.Inertia).Value;
			float num = value / this.FullInertiaTime;
			this.CurrentRunningElasticTime += deltaTime;
			float num2 = this.CurrentRunningElasticTime / this.FullInertiaTime;
			num2 = ((num2 > 1f) ? 1f : num2);
			float num3 = num * this.GetCurveValue(this.InertiaCurve, num2) * deltaTime;
			if (Math.Abs(this.CurrentElasticMoveDelta + num3) > Math.Abs(value))
			{
				num3 = value - this.CurrentElasticMoveDelta;
			}
			this.MoveItems(num3, false);
			this.CurrentElasticMoveDelta += num3;
			if (num2 >= 1f && Math.Abs(this.CurrentElasticMoveDelta) < Math.Abs(value))
			{
				this.CurrentRunningElasticTime -= deltaTime;
			}
		}

		// Token: 0x0603EF68 RID: 257896 RVA: 0x01023968 File Offset: 0x01021B68
		[NullableContext(1)]
		protected float GetCurveValue(UCurveFloat curve, float progress)
		{
			return curve.GetFloatValue(progress);
		}

		// Token: 0x0603EF69 RID: 257897 RVA: 0x01023974 File Offset: 0x01021B74
		private void EndVelocityMove()
		{
			this.VelocityMoveState = false;
			this.InertiaState = false;
			TAttachItem item = this.FindAutoAttachItem();
			this.ScrollToItem(item, false);
		}

		// Token: 0x0603EF6A RID: 257898 RVA: 0x0102399E File Offset: 0x01021B9E
		[NullableContext(1)]
		public void ReloadView(int showItemNum, T[] data, int attachTo = 0)
		{
			this.DataLength = showItemNum;
			this.ReloadItems(showItemNum, data, attachTo);
		}

		// Token: 0x0603EF6B RID: 257899 RVA: 0x010239B0 File Offset: 0x01021BB0
		public int GetShowItemNum()
		{
			return this.ShowItemNum;
		}

		// Token: 0x0603EF6C RID: 257900 RVA: 0x010239B8 File Offset: 0x01021BB8
		public int GetDataLength()
		{
			return this.DataLength;
		}

		// Token: 0x0603EF6D RID: 257901 RVA: 0x010239C0 File Offset: 0x01021BC0
		public void RefreshItems()
		{
			int count = this.Items.Count;
			for (int i = 0; i < count; i++)
			{
				this.Items[i].RefreshItem();
			}
		}

		// Token: 0x0603EF6E RID: 257902 RVA: 0x010239FC File Offset: 0x01021BFC
		public TAttachItem FindNearestMiddleItem()
		{
			if (this.Items.Count == 0)
			{
				Singleton<Log>.Instance.Error(ELogModule.UiCommon, ELogAuthor.YZY, "列表没有数据，找不到中间物体", default(ReadOnlySpan<ValueTuple<string, object>>));
				return default(TAttachItem);
			}
			TAttachItem result = this.Items[0];
			float num = Math.Abs(this.Items[0].GetCurrentPosition());
			int count = this.Items.Count;
			for (int i = 0; i < count; i++)
			{
				float num2 = Math.Abs(this.Items[i].GetCurrentPosition());
				if (num2 < num)
				{
					result = this.Items[i];
					num = num2;
				}
			}
			return result;
		}

		// Token: 0x0603EF6F RID: 257903 RVA: 0x01023AC4 File Offset: 0x01021CC4
		[NullableContext(1)]
		public List<TAttachItem> GetItems()
		{
			return this.Items;
		}

		// Token: 0x0603EF70 RID: 257904 RVA: 0x01023ACC File Offset: 0x01021CCC
		protected TAttachItem GetShowIndexItem(int showIndex)
		{
			TAttachItem result = default(TAttachItem);
			int count = this.Items.Count;
			for (int i = 0; i < count; i++)
			{
				if (this.Items[i].GetCurrentShowItemIndex() == showIndex)
				{
					result = this.Items[i];
					break;
				}
			}
			return result;
		}

		// Token: 0x0603EF71 RID: 257905 RVA: 0x01023B24 File Offset: 0x01021D24
		public TAttachItem GetItemByShowIndex(int showItemIndex)
		{
			foreach (TAttachItem tattachItem in this.Items)
			{
				if (tattachItem.GetCurrentShowItemIndex() == showItemIndex)
				{
					return tattachItem;
				}
			}
			return default(TAttachItem);
		}

		// Token: 0x0603EF72 RID: 257906 RVA: 0x01023B90 File Offset: 0x01021D90
		protected void ForceUnSelectItems()
		{
			int count = this.Items.Count;
			for (int i = 0; i < count; i++)
			{
				this.Items[i].ForceUnSelectItem();
			}
			this.CurrentSelectState = false;
		}

		// Token: 0x0603EF73 RID: 257907 RVA: 0x01023BD4 File Offset: 0x01021DD4
		[NullableContext(1)]
		public void ScrollToItem(TAttachItem item, bool force = false)
		{
			if (this.InertiaState && !force)
			{
				return;
			}
			float currentPosition = item.GetCurrentPosition();
			this.SetMoveTypeOffset(EMoveType.Inertia, -currentPosition);
			this.ForceUnSelectItems();
			this.CurrentSelectItemIndex = item.GetCurrentShowItemIndex();
			if (force)
			{
				this.ForceSelectItemCache = item;
				return;
			}
			this.CurrentRunningElasticTime = 0f;
			this.InertiaState = true;
		}

		// Token: 0x0603EF74 RID: 257908 RVA: 0x01023C38 File Offset: 0x01021E38
		private void MoveToShowIndexForce(int showItemIndex)
		{
			TAttachItem tattachItem = this.FindNearestMiddleItem();
			if (tattachItem == null)
			{
				return;
			}
			int num = showItemIndex - tattachItem.GetCurrentShowItemIndex();
			float num2 = (float)this.GetAutoAttachMoveMinusOffsetDirection() * this.GetItemGapSize() * (float)num + tattachItem.GetCurrentPosition();
			this.SetMoveTypeOffset(EMoveType.Inertia, -num2);
			float offset = this.RecalculateMoveOffset(-num2);
			this.MoveItems(offset, true);
			this.InertiaState = false;
			this.VelocityMoveState = false;
		}

		// Token: 0x0603EF75 RID: 257909 RVA: 0x01023CAC File Offset: 0x01021EAC
		[NullableContext(1)]
		private void MoveToItemForce(TAttachItem item)
		{
			float currentPosition = item.GetCurrentPosition();
			this.SetMoveTypeOffset(EMoveType.Inertia, -currentPosition);
			float offset = this.RecalculateMoveOffset(-currentPosition);
			this.MoveItems(offset, true);
			this.InertiaState = false;
			this.VelocityMoveState = false;
		}

		// Token: 0x0603EF76 RID: 257910 RVA: 0x01023CF0 File Offset: 0x01021EF0
		public void AttachToNextItem(int direction)
		{
			TAttachItem tattachItem = this.FindNextDirectionItem(direction);
			if (tattachItem != null)
			{
				this.AttachToIndex(tattachItem.GetCurrentShowItemIndex(), false);
				return;
			}
			TAttachItem tattachItem2 = this.FindNearestMiddleItem();
			if (tattachItem2 == null)
			{
				return;
			}
			this.AttachToIndex(tattachItem2.GetCurrentShowItemIndex(), false);
		}

		// Token: 0x0603EF77 RID: 257911 RVA: 0x01023D44 File Offset: 0x01021F44
		public void AttachToIndex(int showItemIndex, bool force = false)
		{
			if (this.InertiaState && !force)
			{
				return;
			}
			TAttachItem showIndexItem = this.GetShowIndexItem(showItemIndex);
			if (showIndexItem != null)
			{
				this.ScrollToItem(showIndexItem, force);
			}
			else
			{
				this.ForceUnSelectItems();
				this.CurrentSelectItemIndex = showItemIndex;
				TAttachItem tattachItem = this.FindNearestMiddleItem();
				if (tattachItem == null)
				{
					return;
				}
				if (!force)
				{
					int num = showItemIndex - tattachItem.GetCurrentShowItemIndex();
					float num2 = (float)this.GetAutoAttachMoveMinusOffsetDirection() * this.GetItemGapSize() * (float)num - tattachItem.GetCurrentPosition();
					this.SetMoveTypeOffset(EMoveType.Inertia, -num2);
					this.CurrentRunningElasticTime = 0f;
					this.InertiaState = true;
				}
				else
				{
					this.ForceToItemIndex = new int?(showItemIndex);
				}
			}
			this.Tick(0f);
		}

		// Token: 0x0603EF78 RID: 257912 RVA: 0x01023DF8 File Offset: 0x01021FF8
		protected int GetAutoAttachMoveMinusOffsetDirection()
		{
			EAttachDirection? attachDirection = this.AttachDirection;
			EAttachDirection eattachDirection = EAttachDirection.Horizontal;
			if (attachDirection.GetValueOrDefault() == eattachDirection & attachDirection != null)
			{
				return 1;
			}
			return -1;
		}

		// Token: 0x0603EF79 RID: 257913 RVA: 0x01023E25 File Offset: 0x01022025
		public int GetCurrentSelectIndex()
		{
			return this.CurrentSelectItemIndex;
		}

		// Token: 0x0603EF7A RID: 257914 RVA: 0x01023E2D File Offset: 0x0102202D
		[NullableContext(1)]
		public TAttachItem GetCurrentSelectItem()
		{
			return this.Items[this.CurrentSelectItemIndex];
		}

		// Token: 0x0603EF7B RID: 257915 RVA: 0x01023E40 File Offset: 0x01022040
		public bool MovingState()
		{
			return this.DragState || this.InertiaState;
		}

		// Token: 0x0603EF7C RID: 257916 RVA: 0x01023E52 File Offset: 0x01022052
		private void OnPointerDragCallback(ULGUIPointerEventData eventData)
		{
			this.OnPointerDrag(eventData);
		}

		// Token: 0x0603EF7D RID: 257917 RVA: 0x01023E5B File Offset: 0x0102205B
		private void OnPointerDragEnd(ULGUIPointerEventData eventData)
		{
			this.OnPointerEndDrag(eventData);
		}

		// Token: 0x0603EF7E RID: 257918 RVA: 0x01023E64 File Offset: 0x01022064
		private void OnPointerBeginDrag(ULGUIPointerEventData eventData)
		{
			this.DragState = true;
			this.InertiaState = false;
			this.CheckInertiaSelectState = false;
			this.VelocityMoveState = false;
			this.BeginPlanePosition = ((eventData != null) ? new FVector?(eventData.GetWorldPointInPlane()) : null);
			this.CurrentPlanePosition = ((eventData != null) ? new FVector?(eventData.GetWorldPointInPlane()) : null);
			int count = this.Items.Count;
			for (int i = 0; i < count; i++)
			{
				this.Items[i].OnControllerDragStart();
			}
			Action dragBegin = this.DragBegin;
			if (dragBegin == null)
			{
				return;
			}
			dragBegin();
		}

		// Token: 0x0603EF7F RID: 257919 RVA: 0x01023F09 File Offset: 0x01022109
		private void NavigateToPrev()
		{
			this.AttachToNextItem(-1);
		}

		// Token: 0x0603EF80 RID: 257920 RVA: 0x01023F12 File Offset: 0x01022112
		private void NavigateToNext()
		{
			this.AttachToNextItem(1);
		}

		// Token: 0x0603EF81 RID: 257921 RVA: 0x01023F1C File Offset: 0x0102211C
		private void OnPointerScrollCallBack(ULGUIPointerEventData eventData)
		{
			float? num = (eventData != null) ? new float?(eventData.scrollAxisValue) : null;
			if (num != null)
			{
				float? num2 = num;
				float num3 = 0f;
				if (!(num2.GetValueOrDefault() == num3 & num2 != null))
				{
					num2 = num;
					num3 = 0f;
					int num4 = (int)((num2.GetValueOrDefault() > num3 & num2 != null) ? (num + 0.5f) : (num - 0.5f)).Value;
					this.AttachToNextItem(-num4);
				}
			}
		}

		// Token: 0x0603EF82 RID: 257922 RVA: 0x01023FF4 File Offset: 0x010221F4
		private void OnPointerDrag(ULGUIPointerEventData eventData)
		{
			this.OnPointerDragDelay = 0;
			this.NeedDelayApplyCachePointerDragData = true;
			this.OnPointerDragCacheData = eventData;
			FVector worldPointInPlane = eventData.GetWorldPointInPlane();
			FVector? beginPlanePosition = this.BeginPlanePosition;
			if (beginPlanePosition != null)
			{
				float num = this.GetVectorPositionByMoveDirection(worldPointInPlane) - this.GetVectorPositionByMoveDirection(beginPlanePosition.Value);
				if (num != 0f)
				{
					this.SetMoveTypeOffset(EMoveType.Inertia, num);
					float offset = this.RecalculateMoveOffset(num);
					this.MoveItems(offset, false);
					this.BeginPlanePosition = new FVector?(worldPointInPlane);
				}
			}
		}

		// Token: 0x0603EF83 RID: 257923 RVA: 0x0102406F File Offset: 0x0102226F
		private void ApplyCachePointerDragData(ULGUIPointerEventData eventData)
		{
			this.CurrentPlanePosition = new FVector?(eventData.GetWorldPointInPlane());
		}

		// Token: 0x0603EF84 RID: 257924 RVA: 0x01024084 File Offset: 0x01022284
		private void OnPointerEndDrag(ULGUIPointerEventData eventData)
		{
			int count = this.Items.Count;
			for (int i = 0; i < count; i++)
			{
				this.Items[i].OnControllerDragEnd();
			}
			this.DragState = false;
			this.CurrentRunningElasticTime = 0f;
			this.CurrentVelocityMoveDelta = 0f;
			this.CurrentElasticMoveDelta = 0f;
			if (!this.SupportVelocity)
			{
				TAttachItem tattachItem = this.FindAutoAttachItem();
				this.AttachToIndex(tattachItem.GetCurrentShowItemIndex(), false);
				return;
			}
			FVector worldPointInPlane = eventData.GetWorldPointInPlane();
			float num = 0f;
			if (this.CurrentPlanePosition != null)
			{
				num = (this.GetVectorPositionByMoveDirection(worldPointInPlane) - this.GetVectorPositionByMoveDirection(this.CurrentPlanePosition.Value)) * this.MoveMultiFactor;
			}
			if (Math.Abs(num) < this.MinusVelocityMoveDistance)
			{
				TAttachItem tattachItem2 = this.FindAutoAttachItem();
				this.AttachToIndex(tattachItem2.GetCurrentShowItemIndex(), false);
				return;
			}
			if (this.PageLimitState && Math.Abs(num) > this.GetItemGapSize())
			{
				int direction = (num > 0f) ? -1 : 1;
				this.AttachToNextItem(direction);
				return;
			}
			this.VelocityMoveState = true;
			this.SetMoveTypeOffset(EMoveType.Velocity, num);
			this.VelocityDirection = (float)((num > 0f) ? 1 : -1);
			this.CurrentVelocityRunningTime = 0f;
		}

		// Token: 0x0603EF85 RID: 257925 RVA: 0x010241D0 File Offset: 0x010223D0
		private float GetVectorPositionByMoveDirection(FVector vector)
		{
			EAttachDirection? attachDirection = this.AttachDirection;
			EAttachDirection eattachDirection = EAttachDirection.Horizontal;
			if (attachDirection.GetValueOrDefault() == eattachDirection & attachDirection != null)
			{
				return vector.X;
			}
			return vector.Z;
		}

		// Token: 0x0603EF86 RID: 257926 RVA: 0x01024208 File Offset: 0x01022408
		protected float? GetMoveTypeOffset(EMoveType type)
		{
			float value;
			if (!this.CurrentMoveOffsetMap.TryGetValue(type, out value))
			{
				return null;
			}
			return new float?(value);
		}

		// Token: 0x0603EF87 RID: 257927 RVA: 0x01024235 File Offset: 0x01022435
		protected void SetMoveTypeOffset(EMoveType type, float offset)
		{
			this.CurrentMoveOffsetMap[type] = offset;
			if (type == EMoveType.Inertia)
			{
				this.CurrentElasticMoveDelta = 0f;
			}
		}

		// Token: 0x0603EF88 RID: 257928 RVA: 0x01024254 File Offset: 0x01022454
		private void MoveItems(float offset, bool forceMove = false)
		{
			float num = 99999f;
			int? num2 = null;
			int count = this.Items.Count;
			for (int i = 0; i < count; i++)
			{
				TAttachItem tattachItem = this.Items[i];
				tattachItem.MoveItem(offset);
				if (((!this.CurrentSelectState && this.SelectItemModel == EAttachMode.OnMoving) || forceMove) && tattachItem.GetCurrentShowItemIndex() == this.CurrentSelectItemIndex && !tattachItem.GetSelectedState())
				{
					tattachItem.Select();
					this.CurrentSelectState = true;
				}
				float num3 = Math.Abs(tattachItem.GetCurrentMovePercentage() - 0.5f);
				if (num3 < num)
				{
					num = num3;
					num2 = new int?(tattachItem.GetItemIndex());
				}
			}
			int? currentMiddleIndex = this.CurrentMiddleIndex;
			int? num4 = num2;
			if (!(currentMiddleIndex.GetValueOrDefault() == num4.GetValueOrDefault() & currentMiddleIndex != null == (num4 != null)))
			{
				this.CurrentMiddleIndex = num2;
				if (!forceMove)
				{
					Singleton<AudioSystem>.Instance.PostEvent(this.AudioEvent);
				}
			}
			if (this.SelectItemModel == EAttachMode.OnMovingNearest && !forceMove)
			{
				TAttachItem tattachItem2 = this.FindAutoAttachItem();
				if (tattachItem2 != null && !tattachItem2.GetSelectedState())
				{
					this.ForceUnSelectItems();
					this.CurrentSelectItemIndex = tattachItem2.GetCurrentShowItemIndex();
					tattachItem2.Select();
					this.CurrentSelectState = true;
				}
			}
			Action moveItemsCallback = this.MoveItemsCallback;
			if (moveItemsCallback == null)
			{
				return;
			}
			moveItemsCallback();
		}

		// Token: 0x0603EF89 RID: 257929
		[NullableContext(1)]
		public abstract TAttachItem FindAutoAttachItem();

		// Token: 0x0603EF8A RID: 257930
		protected abstract float RecalculateMoveOffset(float offset);

		// Token: 0x0603EF8B RID: 257931
		[NullableContext(1)]
		protected abstract void ReloadItems(int showItemNum, T[] data, int attachTo = 0);

		// Token: 0x0603EF8C RID: 257932
		public abstract bool GetIfCircle();

		// Token: 0x0603EF8D RID: 257933
		protected abstract TAttachItem FindNextDirectionItem(int direction);

		// Token: 0x0603EF8E RID: 257934 RVA: 0x010243D8 File Offset: 0x010225D8
		public void Clear()
		{
			foreach (TAttachItem tattachItem in this.Items)
			{
				tattachItem.Destroy(null);
			}
			this.Items = new List<TAttachItem>();
			if (this.TickId != -1)
			{
				Singleton<TickSystem>.Instance.Remove(this.TickId);
				this.TickId = -1;
			}
		}

		// Token: 0x04023528 RID: 144680
		protected AActor SourceActor;

		// Token: 0x04023529 RID: 144681
		protected UUIItem SourceItem;

		// Token: 0x0402352A RID: 144682
		protected float SourceItemHeight;

		// Token: 0x0402352B RID: 144683
		protected float SourceItemWidth;

		// Token: 0x0402352C RID: 144684
		protected AActor ControllerActor;

		// Token: 0x0402352D RID: 144685
		protected UUIItem ControllerItem;

		// Token: 0x0402352E RID: 144686
		protected float ControllerHeight;

		// Token: 0x0402352F RID: 144687
		protected float ControllerWidth;

		// Token: 0x04023530 RID: 144688
		protected float Gap;

		// Token: 0x04023531 RID: 144689
		protected int ShowItemNum;

		// Token: 0x04023532 RID: 144690
		protected int DataLength;

		// Token: 0x04023533 RID: 144691
		protected float MoveBoundary;

		// Token: 0x04023534 RID: 144692
		protected bool InertiaState;

		// Token: 0x04023535 RID: 144693
		private bool CheckInertiaSelectState;

		// Token: 0x04023536 RID: 144694
		protected bool DragState;

		// Token: 0x04023537 RID: 144695
		protected bool VelocityMoveState;

		// Token: 0x04023538 RID: 144696
		private FVector? BeginPlanePosition;

		// Token: 0x04023539 RID: 144697
		private FVector? CurrentPlanePosition;

		// Token: 0x0402353A RID: 144698
		private readonly bool SupportVelocity = true;

		// Token: 0x0402353B RID: 144699
		private float VelocityDirection;

		// Token: 0x0402353C RID: 144700
		protected float CurrentVelocityRunningTime;

		// Token: 0x0402353D RID: 144701
		private readonly UCurveFloat VelocityCurve;

		// Token: 0x0402353E RID: 144702
		private readonly UCurveFloat InertiaCurve;

		// Token: 0x0402353F RID: 144703
		protected readonly UCurveFloat BoundaryCurve;

		// Token: 0x04023540 RID: 144704
		private readonly float FullVelocityTime;

		// Token: 0x04023541 RID: 144705
		private readonly float FullInertiaTime;

		// Token: 0x04023542 RID: 144706
		private float CurrentElasticMoveDelta;

		// Token: 0x04023543 RID: 144707
		private float CurrentVelocityMoveDelta;

		// Token: 0x04023544 RID: 144708
		private float MinusVelocityMoveDistance;

		// Token: 0x04023545 RID: 144709
		[Nullable(1)]
		private readonly Dictionary<EMoveType, float> CurrentMoveOffsetMap = new Dictionary<EMoveType, float>();

		// Token: 0x04023546 RID: 144710
		[Nullable(1)]
		protected List<TAttachItem> Items = new List<TAttachItem>();

		// Token: 0x04023547 RID: 144711
		private TAttachItem ForceSelectItemCache;

		// Token: 0x04023548 RID: 144712
		protected EAttachDirection? AttachDirection;

		// Token: 0x04023549 RID: 144713
		protected bool CurrentSelectState;

		// Token: 0x0402354A RID: 144714
		protected int CurrentSelectItemIndex;

		// Token: 0x0402354B RID: 144715
		protected float CurrentRunningElasticTime;

		// Token: 0x0402354C RID: 144716
		private EAttachMode SelectItemModel = EAttachMode.EndMove;

		// Token: 0x0402354D RID: 144717
		private int TickId = -1;

		// Token: 0x0402354E RID: 144718
		private float MoveMultiFactor = 5f;

		// Token: 0x0402354F RID: 144719
		private bool PageLimitState;

		// Token: 0x04023550 RID: 144720
		[Nullable(1)]
		private string AudioEvent = "ui_common_picker_tick";

		// Token: 0x04023551 RID: 144721
		private int? CurrentMiddleIndex;

		// Token: 0x04023552 RID: 144722
		[Nullable(new byte[]
		{
			1,
			1,
			2
		})]
		protected Func<AActor, int, int, TAttachItem> CreateItemFunction = (AActor actor, int index, int showNum) => default(TAttachItem);

		// Token: 0x04023553 RID: 144723
		private bool IsMoving;

		// Token: 0x04023554 RID: 144724
		private readonly bool IsNeedScrollCallback;

		// Token: 0x04023555 RID: 144725
		private Action DragBegin;

		// Token: 0x04023556 RID: 144726
		private Action MoveItemsCallback;

		// Token: 0x04023557 RID: 144727
		private const float ENDMOVEFLOAT = 0.01f;

		// Token: 0x04023558 RID: 144728
		private const float MOVEMULFACTOR = 5f;

		// Token: 0x04023559 RID: 144729
		private const float VERYBIGDISTANCE = 99999f;

		// Token: 0x0402355A RID: 144730
		private const float DISTANCETOMIDDLE = 0.5f;

		// Token: 0x0402355B RID: 144731
		[Nullable(1)]
		private const string DEFALTAUDIO = "ui_common_picker_tick";

		// Token: 0x0402355C RID: 144732
		private int? ForceToItemIndex;

		// Token: 0x0402355D RID: 144733
		private int OnPointerDragDelay;

		// Token: 0x0402355E RID: 144734
		private bool NeedDelayApplyCachePointerDragData;

		// Token: 0x0402355F RID: 144735
		private ULGUIPointerEventData OnPointerDragCacheData;
	}
}
