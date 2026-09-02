using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Util
{
	// Token: 0x02004C73 RID: 19571
	[NullableContext(1)]
	[Nullable(0)]
	public class GenericScrollViewNew<TProxy, [Nullable(2)] TData> where TProxy : class, IGridProxy<TData>
	{
		// Token: 0x1700878B RID: 34699
		// (get) Token: 0x06032FEA RID: 208874 RVA: 0x00CC5CD4 File Offset: 0x00CC3ED4
		public bool IsExpand
		{
			get
			{
				if (this.TargetScroll.Horizontal)
				{
					float width = this.TargetScroll.RootUIComp.Get().Width;
					return this.TargetScroll.ContentUIItem.Get().Width > width;
				}
				float height = this.TargetScroll.RootUIComp.Get().Height;
				return this.TargetScroll.ContentUIItem.Get().Height > height;
			}
		}

		// Token: 0x1700878C RID: 34700
		// (get) Token: 0x06032FEB RID: 208875 RVA: 0x00CC5D57 File Offset: 0x00CC3F57
		[Nullable(new byte[]
		{
			0,
			1
		})]
		public TWeakObjectPtr<UUIItem>? ContentItem
		{
			[return: Nullable(new byte[]
			{
				0,
				1
			})]
			get
			{
				return new TWeakObjectPtr<UUIItem>?(this.TargetScroll.ContentUIItem);
			}
		}

		// Token: 0x1700878D RID: 34701
		// (get) Token: 0x06032FEC RID: 208876 RVA: 0x00CC5D6C File Offset: 0x00CC3F6C
		public float ScrollWidth
		{
			get
			{
				UUIItem uuiitem = this.TargetScroll.RootUIComp.Get();
				if (uuiitem == null)
				{
					return 0f;
				}
				return uuiitem.Width;
			}
		}

		// Token: 0x1700878E RID: 34702
		// (get) Token: 0x06032FED RID: 208877 RVA: 0x00CC5D9C File Offset: 0x00CC3F9C
		public float ScrollHeight
		{
			get
			{
				UUIItem uuiitem = this.TargetScroll.RootUIComp.Get();
				if (uuiitem == null)
				{
					return 0f;
				}
				return uuiitem.Height;
			}
		}

		// Token: 0x06032FEE RID: 208878 RVA: 0x00CC5DCC File Offset: 0x00CC3FCC
		public GenericScrollViewNew(UUIScrollViewWithScrollbarComponent scrollView, Func<TProxy> gridProxyCreateFunction, [Nullable(2)] AUIBaseActor gridActor = null, bool isRefreshAsync = false, [Nullable(2)] UUILayoutBase layout = null)
		{
			this.TargetScroll = scrollView;
			UUILayoutBase layout2 = layout ?? (this.TargetScroll.GetContent().GetComponentByClass(UUILayoutBase.StaticClass()) as UUILayoutBase);
			this.GenericLayout = new GenericLayout<TProxy, TData>(layout2, gridProxyCreateFunction, gridActor, isRefreshAsync, true);
			this.GenericLayout.AnimControllerComponent = (((scrollView != null) ? scrollView.GetOwner().GetComponentByClass(UUIInturnAnimController.StaticClass()) : null) as UUIInturnAnimController);
		}

		// Token: 0x06032FEF RID: 208879 RVA: 0x00CC5E48 File Offset: 0x00CC4048
		public void RefreshByData(IReadOnlyList<TData> data, [Nullable(2)] Action callBack = null, bool playGridAnim = false)
		{
			this.GenericLayout.RefreshByData(data, callBack, playGridAnim);
		}

		// Token: 0x06032FF0 RID: 208880 RVA: 0x00CC5E58 File Offset: 0x00CC4058
		public UniTask RefreshByDataAsync(IReadOnlyList<TData> data, bool playGridAnim = false)
		{
			GenericScrollViewNew<TProxy, TData>.<RefreshByDataAsync>d__12 <RefreshByDataAsync>d__;
			<RefreshByDataAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshByDataAsync>d__.<>4__this = this;
			<RefreshByDataAsync>d__.data = data;
			<RefreshByDataAsync>d__.playGridAnim = playGridAnim;
			<RefreshByDataAsync>d__.<>1__state = -1;
			<RefreshByDataAsync>d__.<>t__builder.Start<GenericScrollViewNew<TProxy, TData>.<RefreshByDataAsync>d__12>(ref <RefreshByDataAsync>d__);
			return <RefreshByDataAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06032FF1 RID: 208881 RVA: 0x00CC5EAB File Offset: 0x00CC40AB
		public void SetHorizontalScrollEnable(bool enable)
		{
			this.TargetScroll.SetHorizontal(enable);
		}

		// Token: 0x06032FF2 RID: 208882 RVA: 0x00CC5EB9 File Offset: 0x00CC40B9
		public void SetVerticalScrollEnable(bool enable)
		{
			this.TargetScroll.SetVertical(enable);
		}

		// Token: 0x06032FF3 RID: 208883 RVA: 0x00CC5EC7 File Offset: 0x00CC40C7
		[NullableContext(2)]
		public UUIItem GetItemByIndex(int index)
		{
			return this.GenericLayout.GetItemByIndex(index);
		}

		// Token: 0x06032FF4 RID: 208884 RVA: 0x00CC5ED5 File Offset: 0x00CC40D5
		[return: Nullable(2)]
		public UUIItem GetItemByKey(object key)
		{
			return this.GenericLayout.GetItemByKey(key);
		}

		// Token: 0x06032FF5 RID: 208885 RVA: 0x00CC5EE3 File Offset: 0x00CC40E3
		[NullableContext(2)]
		public TProxy GetScrollItemByIndex(int index)
		{
			return this.GenericLayout.GetLayoutItemByIndex(index);
		}

		// Token: 0x06032FF6 RID: 208886 RVA: 0x00CC5EF1 File Offset: 0x00CC40F1
		[return: Nullable(2)]
		public TProxy GetScrollItemByKey(object key)
		{
			return this.GenericLayout.GetLayoutItemByKey(key);
		}

		// Token: 0x06032FF7 RID: 208887 RVA: 0x00CC5EFF File Offset: 0x00CC40FF
		public Dictionary<object, TProxy> GetScrollItemMap()
		{
			return this.GenericLayout.GetLayoutItemMap();
		}

		// Token: 0x06032FF8 RID: 208888 RVA: 0x00CC5F0C File Offset: 0x00CC410C
		public List<TProxy> GetScrollItemList()
		{
			return this.GenericLayout.GetLayoutItemList();
		}

		// Token: 0x06032FF9 RID: 208889 RVA: 0x00CC5F19 File Offset: 0x00CC4119
		public void ScrollTo(UUIItem uiItem, bool bTweenAnim = false)
		{
			this.TargetScroll.ScrollTo(uiItem, bTweenAnim);
		}

		// Token: 0x06032FFA RID: 208890 RVA: 0x00CC5F28 File Offset: 0x00CC4128
		public void ScrollToItemByKey(object key)
		{
			UUIItem itemByKey = this.GenericLayout.GetItemByKey(key);
			if (itemByKey != null)
			{
				this.TargetScroll.ScrollTo(itemByKey, false);
			}
		}

		// Token: 0x06032FFB RID: 208891 RVA: 0x00CC5F54 File Offset: 0x00CC4154
		public void LateScrollTo(UUIItem uiItem, [Nullable(2)] Action callBack = null, bool bTweenAnim = false)
		{
			TTimerAction <>9__1;
			this.BindLateUpdate(delegate(float delta)
			{
				TimerSystemInstance gameplayTimeInstance = TimerSystem.GameplayTimeInstance;
				TTimerAction action;
				if ((action = <>9__1) == null)
				{
					action = (<>9__1 = delegate(float _)
					{
						this.ScrollTo(uiItem, bTweenAnim);
						Action callBack2 = callBack;
						if (callBack2 == null)
						{
							return;
						}
						callBack2();
					});
				}
				gameplayTimeInstance.Next(action, null, null);
				this.UnBindLateUpdate();
			});
		}

		// Token: 0x06032FFC RID: 208892 RVA: 0x00CC5F98 File Offset: 0x00CC4198
		public void LateScrollToLeft(object key)
		{
			TTimerAction <>9__1;
			this.BindLateUpdate(delegate(float delta)
			{
				TimerSystemInstance gameplayTimeInstance = TimerSystem.GameplayTimeInstance;
				TTimerAction action;
				if ((action = <>9__1) == null)
				{
					action = (<>9__1 = delegate(float _)
					{
						this.ScrollToLeft(key);
					});
				}
				gameplayTimeInstance.Next(action, null, null);
				this.UnBindLateUpdate();
			});
		}

		// Token: 0x06032FFD RID: 208893 RVA: 0x00CC5FCC File Offset: 0x00CC41CC
		public void ScrollToLeft(object key)
		{
			UUIItem itemByKey = this.GenericLayout.GetItemByKey(key);
			FVector relativeLocation = this.TargetScroll.ContentUIItem.Get().RelativeLocation;
			FVector2D fvector2D = new FVector2D(relativeLocation.X, relativeLocation.Y);
			this.TargetScroll.ScrollToLeft(ref fvector2D, itemByKey, false);
		}

		// Token: 0x06032FFE RID: 208894 RVA: 0x00CC6024 File Offset: 0x00CC4224
		public void ScrollToLeftByItem(UUIItem scrollItem)
		{
			FVector relativeLocation = this.TargetScroll.ContentUIItem.Get().RelativeLocation;
			FVector2D fvector2D = new FVector2D(relativeLocation.X, relativeLocation.Y);
			this.TargetScroll.ScrollToLeft(ref fvector2D, scrollItem, false);
		}

		// Token: 0x06032FFF RID: 208895 RVA: 0x00CC606C File Offset: 0x00CC426C
		public void ScrollToRight(object key)
		{
			UUIItem itemByKey = this.GenericLayout.GetItemByKey(key);
			FVector relativeLocation = this.TargetScroll.ContentUIItem.Get().RelativeLocation;
			FVector2D fvector2D = new FVector2D(relativeLocation.X, relativeLocation.Y);
			this.TargetScroll.ScrollToRight(ref fvector2D, itemByKey, false);
		}

		// Token: 0x06033000 RID: 208896 RVA: 0x00CC60C4 File Offset: 0x00CC42C4
		public void ScrollToTop(object key)
		{
			UUIItem itemByKey = this.GenericLayout.GetItemByKey(key);
			FVector relativeLocation = this.TargetScroll.ContentUIItem.Get().RelativeLocation;
			FVector2D fvector2D = new FVector2D(relativeLocation.X, relativeLocation.Y);
			this.TargetScroll.ScrollToTop(ref fvector2D, itemByKey, false);
		}

		// Token: 0x06033001 RID: 208897 RVA: 0x00CC611C File Offset: 0x00CC431C
		public void ScrollToTopByIndex(int index)
		{
			UUIItem itemByIndex = this.GetItemByIndex(index);
			if (itemByIndex != null)
			{
				FVector relativeLocation = this.TargetScroll.ContentUIItem.Get().RelativeLocation;
				FVector2D fvector2D = new FVector2D(relativeLocation.X, relativeLocation.Y);
				this.TargetScroll.ScrollToTop(ref fvector2D, itemByIndex, false);
			}
		}

		// Token: 0x06033002 RID: 208898 RVA: 0x00CC6170 File Offset: 0x00CC4370
		public void ScrollToBottom(object key)
		{
			UUIItem itemByKey = this.GenericLayout.GetItemByKey(key);
			FVector relativeLocation = this.TargetScroll.ContentUIItem.Get().RelativeLocation;
			FVector2D fvector2D = new FVector2D(relativeLocation.X, relativeLocation.Y);
			this.TargetScroll.ScrollToBottom(ref fvector2D, itemByKey, false);
		}

		// Token: 0x06033003 RID: 208899 RVA: 0x00CC61C8 File Offset: 0x00CC43C8
		public void SetActive(bool bActive)
		{
			this.TargetScroll.RootUIComp.Get().SetUIActive(bActive);
		}

		// Token: 0x06033004 RID: 208900 RVA: 0x00CC61EE File Offset: 0x00CC43EE
		public void BindScrollValueChange(Action<FVector2D> callback)
		{
			this.TargetScroll.OnScrollValueChange.Bind(callback);
		}

		// Token: 0x06033005 RID: 208901 RVA: 0x00CC6201 File Offset: 0x00CC4401
		public void UnBindScrollValueChange()
		{
			this.TargetScroll.OnScrollValueChange.Unbind();
		}

		// Token: 0x06033006 RID: 208902 RVA: 0x00CC6213 File Offset: 0x00CC4413
		public void BindLateUpdate(Action<float> callBack)
		{
			this.GenericLayout.BindLateUpdate(callBack);
		}

		// Token: 0x06033007 RID: 208903 RVA: 0x00CC6221 File Offset: 0x00CC4421
		public void UnBindLateUpdate()
		{
			this.GenericLayout.UnBindLateUpdate();
		}

		// Token: 0x06033008 RID: 208904 RVA: 0x00CC622E File Offset: 0x00CC442E
		[return: Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		public GenericLayout<TProxy, TData> GetGenericLayout()
		{
			return this.GenericLayout;
		}

		// Token: 0x06033009 RID: 208905 RVA: 0x00CC6236 File Offset: 0x00CC4436
		public void SelectGridProxy(int gridIndex = -1, bool fireEvent = false)
		{
			GenericLayout<TProxy, TData> genericLayout = this.GenericLayout;
			if (genericLayout == null)
			{
				return;
			}
			genericLayout.SelectGridProxy(gridIndex, fireEvent);
		}

		// Token: 0x0603300A RID: 208906 RVA: 0x00CC624A File Offset: 0x00CC444A
		public int GetSelectedIndex()
		{
			GenericLayout<TProxy, TData> genericLayout = this.GenericLayout;
			if (genericLayout == null)
			{
				return -1;
			}
			return genericLayout.GetSelectedGridIndex();
		}

		// Token: 0x0603300B RID: 208907 RVA: 0x00CC625D File Offset: 0x00CC445D
		public void PlayTurnAnimation()
		{
			GenericLayout<TProxy, TData> genericLayout = this.GenericLayout;
			if (genericLayout == null)
			{
				return;
			}
			UUIInturnAnimController uiAnimController = genericLayout.GetUiAnimController();
			if (uiAnimController == null)
			{
				return;
			}
			uiAnimController.Play("", -1, false);
		}

		// Token: 0x0603300C RID: 208908 RVA: 0x00CC6280 File Offset: 0x00CC4480
		public EOutOfBoundsType IsItemInViewport(UUIItem item, float tolerance)
		{
			EOutOfBoundsType result = EOutOfBoundsType.NotOut;
			EOutOfBoundsType result2 = EOutOfBoundsType.NotOut;
			this.TargetScroll.GetOutOfBottomBoundsType(item, ref result, ref result2, tolerance);
			if (this.TargetScroll.Vertical)
			{
				return result;
			}
			return result2;
		}

		// Token: 0x0603300D RID: 208909 RVA: 0x00CC62B4 File Offset: 0x00CC44B4
		public EOutOfBoundsType IsItemFullyOutOfViewport(UUIItem item, float tolerance)
		{
			float num = this.TargetScroll.Vertical ? item.GetHeight() : item.GetWidth();
			float tolerance2 = tolerance + num;
			return this.IsItemInViewport(item, tolerance2);
		}

		// Token: 0x0401DAA1 RID: 121505
		[Nullable(2)]
		private readonly UUIScrollViewWithScrollbarComponent TargetScroll;

		// Token: 0x0401DAA2 RID: 121506
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private readonly GenericLayout<TProxy, TData> GenericLayout;
	}
}
