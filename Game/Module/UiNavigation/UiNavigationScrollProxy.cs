using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004CA0 RID: 19616
	[NullableContext(1)]
	[Nullable(0)]
	public class UiNavigationScrollProxy
	{
		// Token: 0x060331E6 RID: 209382 RVA: 0x00CCD364 File Offset: 0x00CCB564
		private float GetErrorTolerance(bool isVertical)
		{
			FVector relativeScale3D = this.Listener.RootUIComp.Get().RelativeScale3D;
			float num = 0.0002f;
			if (isVertical && relativeScale3D.Y > 1f)
			{
				float num2 = relativeScale3D.Y - 1f;
				num += num2 * this.Listener.RootUIComp.Get().Height / 2f;
			}
			else if (!isVertical && relativeScale3D.X > 1f)
			{
				float num3 = relativeScale3D.X - 1f;
				num += num3 * this.Listener.RootUIComp.Get().Width / 2f;
			}
			return num;
		}

		// Token: 0x060331E7 RID: 209383 RVA: 0x00CCD415 File Offset: 0x00CCB615
		public void InitScrollView(AActor scrollViewActor, TsUiNavigationBehaviorListener listener)
		{
			this.Listener = listener;
			this.ScrollView = (scrollViewActor.GetComponentByClass(UUIScrollViewWithScrollbarComponent.StaticClass()) as UUIScrollViewWithScrollbarComponent);
		}

		// Token: 0x060331E8 RID: 209384 RVA: 0x00CCD43C File Offset: 0x00CCB63C
		public bool IsScrollViewActive()
		{
			return this.ScrollView != null && this.ScrollView.RootUIComp.Get().IsUIActiveInHierarchy();
		}

		// Token: 0x060331E9 RID: 209385 RVA: 0x00CCD46B File Offset: 0x00CCB66B
		[NullableContext(2)]
		public UUIInturnAnimController GetInturnAnimController()
		{
			if (this.ScrollView == null)
			{
				return null;
			}
			AUIBaseActor content = this.ScrollView.GetContent();
			return ((content != null) ? content.GetComponentByClass(UUIInturnAnimController.StaticClass()) : null) as UUIInturnAnimController;
		}

		// Token: 0x170087C0 RID: 34752
		// (get) Token: 0x060331EA RID: 209386 RVA: 0x00CCD49D File Offset: 0x00CCB69D
		public bool IsVertical
		{
			get
			{
				return this.ScrollView != null && this.ScrollView.Vertical;
			}
		}

		// Token: 0x060331EB RID: 209387 RVA: 0x00CCD4B4 File Offset: 0x00CCB6B4
		public bool HasNormalScrollView()
		{
			return this.ScrollView != null && !this.HasLoopScrollView() && !this.HasMultiTemplateScrollView() && !this.HasDynamicScrollView();
		}

		// Token: 0x060331EC RID: 209388 RVA: 0x00CCD4E0 File Offset: 0x00CCB6E0
		public bool IsInNormalScrollDisplayByGridActor(AUIBaseActor gridBaseActor)
		{
			EOutOfBoundsType eoutOfBoundsType = EOutOfBoundsType.NotOut;
			EOutOfBoundsType eoutOfBoundsType2 = EOutOfBoundsType.NotOut;
			this.ScrollView.GetOutOfBottomBoundsType(gridBaseActor.GetUIItem(), ref eoutOfBoundsType, ref eoutOfBoundsType2, 0f);
			if (this.ScrollView.Vertical)
			{
				return eoutOfBoundsType == EOutOfBoundsType.NotOut;
			}
			return eoutOfBoundsType2 == EOutOfBoundsType.NotOut;
		}

		// Token: 0x060331ED RID: 209389 RVA: 0x00CCD521 File Offset: 0x00CCB721
		public void BindScrollView(UUISelectableComponent selectableComponent)
		{
			if (!this.HasLoopScrollView() && !this.HasMultiTemplateScrollView())
			{
				return;
			}
			this.ScrollView.BindParentUIItem(selectableComponent);
		}

		// Token: 0x060331EE RID: 209390 RVA: 0x00CCD540 File Offset: 0x00CCB740
		public void UnBindScrollView(UUISelectableComponent selectableComponent)
		{
			if (!this.HasLoopScrollView() && !this.HasMultiTemplateScrollView())
			{
				return;
			}
			if (!this.ScrollView.IsValid())
			{
				return;
			}
			this.ScrollView.UnBindParentUIItem(selectableComponent);
		}

		// Token: 0x060331EF RID: 209391 RVA: 0x00CCD56D File Offset: 0x00CCB76D
		public bool HasLoopScrollView()
		{
			return this.ScrollView != null && this.ScrollView is UUILoopScrollViewComponent;
		}

		// Token: 0x060331F0 RID: 209392 RVA: 0x00CCD589 File Offset: 0x00CCB789
		public void SetLoopScrollViewNavigationIndex(int gridIndex)
		{
			if (!this.HasLoopScrollView())
			{
				return;
			}
			(this.ScrollView as UUILoopScrollViewComponent).SetNavigationIndex(gridIndex);
		}

		// Token: 0x060331F1 RID: 209393 RVA: 0x00CCD5A5 File Offset: 0x00CCB7A5
		public int GetLoopScrollViewNavigationIndex()
		{
			if (!this.HasLoopScrollView())
			{
				return -1;
			}
			return (this.ScrollView as UUILoopScrollViewComponent).NavigationIndex;
		}

		// Token: 0x060331F2 RID: 209394 RVA: 0x00CCD5C1 File Offset: 0x00CCB7C1
		public bool CheckLoopScrollChangeNavigation()
		{
			if (this.ScrollView == null)
			{
				return false;
			}
			if (!this.ScrollView.IsChangeNavigation)
			{
				return false;
			}
			this.ScrollView.ResetIsChangeNavigation();
			return true;
		}

		// Token: 0x060331F3 RID: 209395 RVA: 0x00CCD5E8 File Offset: 0x00CCB7E8
		public bool IsInLoopScrollDisplay(int gridIndex)
		{
			if (!this.HasLoopScrollView())
			{
				return true;
			}
			UUILoopScrollViewComponent uuiloopScrollViewComponent = this.ScrollView as UUILoopScrollViewComponent;
			return uuiloopScrollViewComponent.NavigationIndex == -1 || uuiloopScrollViewComponent.NavigationIndex == gridIndex;
		}

		// Token: 0x060331F4 RID: 209396 RVA: 0x00CCD620 File Offset: 0x00CCB820
		[NullableContext(2)]
		public bool IsInLoopScrollDisplayByGridActor(AUIBaseActor gridBaseActor)
		{
			if (!this.HasLoopScrollView())
			{
				return true;
			}
			UUILoopScrollViewComponent uuiloopScrollViewComponent = this.ScrollView as UUILoopScrollViewComponent;
			EOutOfBoundsType eoutOfBoundsType = EOutOfBoundsType.NotOut;
			EOutOfBoundsType eoutOfBoundsType2 = EOutOfBoundsType.NotOut;
			float errorTolerance = this.GetErrorTolerance(uuiloopScrollViewComponent.Vertical);
			UUIItem uiitem;
			if (gridBaseActor != null)
			{
				uiitem = gridBaseActor.GetUIItem();
			}
			else
			{
				uiitem = this.Listener.RootUIComp.Get();
			}
			uuiloopScrollViewComponent.GetOutOfBottomBoundsType(uiitem, ref eoutOfBoundsType, ref eoutOfBoundsType2, errorTolerance);
			if (uuiloopScrollViewComponent.Vertical)
			{
				return eoutOfBoundsType == EOutOfBoundsType.NotOut;
			}
			return eoutOfBoundsType2 == EOutOfBoundsType.NotOut;
		}

		// Token: 0x060331F5 RID: 209397 RVA: 0x00CCD698 File Offset: 0x00CCB898
		[NullableContext(2)]
		public bool IsScrollDisplayByGridActor(AUIBaseActor gridBaseActor)
		{
			if (this.ScrollView == null)
			{
				return true;
			}
			EOutOfBoundsType eoutOfBoundsType = EOutOfBoundsType.NotOut;
			EOutOfBoundsType eoutOfBoundsType2 = EOutOfBoundsType.NotOut;
			float errorTolerance = this.GetErrorTolerance(this.ScrollView.Vertical);
			UUIItem uiitem;
			if (gridBaseActor != null)
			{
				uiitem = gridBaseActor.GetUIItem();
			}
			else
			{
				uiitem = this.Listener.RootUIComp.Get();
			}
			this.ScrollView.GetOutOfBottomBoundsType(uiitem, ref eoutOfBoundsType, ref eoutOfBoundsType2, errorTolerance);
			if (this.ScrollView.Vertical)
			{
				return eoutOfBoundsType == EOutOfBoundsType.NotOut;
			}
			return eoutOfBoundsType2 == EOutOfBoundsType.NotOut;
		}

		// Token: 0x060331F6 RID: 209398 RVA: 0x00CCD710 File Offset: 0x00CCB910
		[NullableContext(2)]
		public AActor GetDynamicGridActor()
		{
			if (!this.HasDynamicScrollView())
			{
				return null;
			}
			UUIScrollViewWithScrollbarComponent scrollView = this.ScrollView;
			AUIBaseActor auibaseActor = (scrollView != null) ? scrollView.GetContent() : null;
			if (auibaseActor == null)
			{
				return null;
			}
			AActor aactor = this.Listener.RootUIComp.Get().GetOwner();
			bool flag = false;
			while (aactor != null && aactor.IsValid() && aactor != auibaseActor)
			{
				if (aactor.GetAttachParentActor() == auibaseActor)
				{
					flag = true;
					break;
				}
				aactor = aactor.GetAttachParentActor();
			}
			if (!flag)
			{
				return null;
			}
			return aactor;
		}

		// Token: 0x060331F7 RID: 209399 RVA: 0x00CCD785 File Offset: 0x00CCB985
		public bool HasDynamicScrollView()
		{
			return this.ScrollView != null && this.ScrollView is UUIDynScrollViewComponent;
		}

		// Token: 0x060331F8 RID: 209400 RVA: 0x00CCD7A4 File Offset: 0x00CCB9A4
		[NullableContext(2)]
		public bool IsInDynScrollDisplay(AUIBaseActor gridBaseActor)
		{
			if (!this.HasDynamicScrollView())
			{
				return true;
			}
			UUIDynScrollViewComponent uuidynScrollViewComponent = this.ScrollView as UUIDynScrollViewComponent;
			EOutOfBoundsType eoutOfBoundsType = EOutOfBoundsType.NotOut;
			EOutOfBoundsType eoutOfBoundsType2 = EOutOfBoundsType.NotOut;
			float errorTolerance = this.GetErrorTolerance(uuidynScrollViewComponent.Vertical);
			UUIItem uiitem;
			if (gridBaseActor != null)
			{
				uiitem = gridBaseActor.GetUIItem();
			}
			else
			{
				uiitem = this.Listener.RootUIComp.Get();
			}
			uuidynScrollViewComponent.GetOutOfBottomBoundsType(uiitem, ref eoutOfBoundsType, ref eoutOfBoundsType2, errorTolerance);
			if (uuidynScrollViewComponent.Vertical)
			{
				return eoutOfBoundsType == EOutOfBoundsType.NotOut;
			}
			return eoutOfBoundsType2 == EOutOfBoundsType.NotOut;
		}

		// Token: 0x060331F9 RID: 209401 RVA: 0x00CCD81C File Offset: 0x00CCBA1C
		public bool GetMultiTemplateScrollPositiveFind(FVector direction, int lastIndex, int index)
		{
			if (this.ScrollView == null)
			{
				return true;
			}
			if (this.ScrollView.Vertical)
			{
				if (direction.Z != 0f)
				{
					if (direction.Z <= 0f)
					{
						return index > lastIndex;
					}
					return index < lastIndex;
				}
				else
				{
					if (direction.X <= 0f)
					{
						return index < lastIndex;
					}
					return index > lastIndex;
				}
			}
			else if (direction.X != 0f)
			{
				if (direction.X <= 0f)
				{
					return index < lastIndex;
				}
				return index > lastIndex;
			}
			else
			{
				if (direction.Z <= 0f)
				{
					return index > lastIndex;
				}
				return index < lastIndex;
			}
		}

		// Token: 0x060331FA RID: 209402 RVA: 0x00CCD8B5 File Offset: 0x00CCBAB5
		public bool IsNeedSlideToEdge(int lastIndex, int findIndex, bool isPositiveFind, NavigationGroup groupConfig)
		{
			return !isPositiveFind && ((findIndex < lastIndex && groupConfig.SlideToLeftOrTop) || (findIndex > lastIndex && groupConfig.SlideToRightOrDown));
		}

		// Token: 0x060331FB RID: 209403 RVA: 0x00CCD8DC File Offset: 0x00CCBADC
		public bool IsNeedReturnBestPick(FVector direction, NavigationGroup groupConfig)
		{
			UUIScrollViewWithScrollbarComponent scrollView = this.ScrollView;
			if (scrollView == null)
			{
				return true;
			}
			if (scrollView.CheckContentUnderSize())
			{
				return true;
			}
			if (scrollView.Horizontal)
			{
				TWeakObjectPtr<UUIScrollbarComponent> horizontalScrollbarComp = scrollView.HorizontalScrollbarComp;
				if (direction.X != 0f)
				{
					float value = scrollView.HorizontalScrollbarComp.Get().Value;
					bool flag = direction.X > 0f;
					return (value >= 0.999f || !flag || !groupConfig.SlideToRightOrDown) && (value <= 0.001f || flag || !groupConfig.SlideToLeftOrTop);
				}
			}
			if (scrollView.Vertical)
			{
				TWeakObjectPtr<UUIScrollbarComponent> verticalScrollbarComp = scrollView.VerticalScrollbarComp;
				if (direction.Z != 0f)
				{
					float value2 = scrollView.VerticalScrollbarComp.Get().Value;
					bool flag2 = direction.Z < 0f;
					return (value2 >= 0.999f || !flag2 || !groupConfig.SlideToRightOrDown) && (value2 <= 0.001f || flag2 || !groupConfig.SlideToLeftOrTop);
				}
			}
			return true;
		}

		// Token: 0x060331FC RID: 209404 RVA: 0x00CCD9DC File Offset: 0x00CCBBDC
		public void SetScrollProgress(bool isScrollToTop)
		{
			UUIScrollViewWithScrollbarComponent scrollView = this.ScrollView;
			if (scrollView == null)
			{
				return;
			}
			scrollView.SetScrollProgress(!isScrollToTop);
		}

		// Token: 0x060331FD RID: 209405 RVA: 0x00CCD9F4 File Offset: 0x00CCBBF4
		public void TryMultiTemplateScrollToGridIndex(int lastIndex, int gridIndex)
		{
			if (this.ScrollView == null)
			{
				return;
			}
			UUIMultiTemplateScrollViewComponent uuimultiTemplateScrollViewComponent = this.ScrollView as UUIMultiTemplateScrollViewComponent;
			if (gridIndex > lastIndex)
			{
				uuimultiTemplateScrollViewComponent.TryScrollToGridIndex(gridIndex, false);
				return;
			}
			uuimultiTemplateScrollViewComponent.TryScrollToGridIndex(gridIndex, true);
		}

		// Token: 0x060331FE RID: 209406 RVA: 0x00CCDA2B File Offset: 0x00CCBC2B
		public bool HasMultiTemplateScrollView()
		{
			return this.ScrollView != null && this.ScrollView is UUIMultiTemplateScrollViewComponent;
		}

		// Token: 0x060331FF RID: 209407 RVA: 0x00CCDA48 File Offset: 0x00CCBC48
		public void RecordFocusListenerIndexInMultiTemplateScrollView()
		{
			if (!this.HasMultiTemplateScrollView())
			{
				return;
			}
			UUIMultiTemplateScrollViewComponent uuimultiTemplateScrollViewComponent = this.ScrollView as UUIMultiTemplateScrollViewComponent;
			this.FocusListenerIndexInMultiTemplateScrollView = uuimultiTemplateScrollViewComponent.GetGridIndexByChildComponent(this.Listener.GetSelectableComponent());
		}

		// Token: 0x06033200 RID: 209408 RVA: 0x00CCDA84 File Offset: 0x00CCBC84
		public TsUiNavigationBehaviorListener GetCurrentFocusListenerInMultiTemplateScrollView()
		{
			if (!this.HasMultiTemplateScrollView())
			{
				return this.Listener;
			}
			if (this.FocusListenerIndexInMultiTemplateScrollView == -1)
			{
				return this.Listener;
			}
			UUISelectableComponent navigationComponentByGridIndex = (this.ScrollView as UUIMultiTemplateScrollViewComponent).GetNavigationComponentByGridIndex(this.FocusListenerIndexInMultiTemplateScrollView);
			object obj;
			if (navigationComponentByGridIndex == null)
			{
				obj = null;
			}
			else
			{
				AActor owner = navigationComponentByGridIndex.GetOwner();
				obj = ((owner != null) ? owner.GetComponentByClass(TsUiNavigationBehaviorListener.StaticClass()) : null);
			}
			TsUiNavigationBehaviorListener tsUiNavigationBehaviorListener = obj as TsUiNavigationBehaviorListener;
			if (tsUiNavigationBehaviorListener == null)
			{
				return this.Listener;
			}
			return tsUiNavigationBehaviorListener;
		}

		// Token: 0x0401DB7C RID: 121724
		private const float ERRORTOLERANCE = 0.001f;

		// Token: 0x0401DB7D RID: 121725
		[Nullable(2)]
		public UUIScrollViewWithScrollbarComponent ScrollView;

		// Token: 0x0401DB7E RID: 121726
		protected TsUiNavigationBehaviorListener Listener;

		// Token: 0x0401DB7F RID: 121727
		private int FocusListenerIndexInMultiTemplateScrollView = -1;
	}
}
