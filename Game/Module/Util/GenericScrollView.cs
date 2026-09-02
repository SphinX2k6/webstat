using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util.Layout;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Util
{
	// Token: 0x02004C72 RID: 19570
	[NullableContext(1)]
	[Nullable(0)]
	public class GenericScrollView<[Nullable(0)] TItem> where TItem : UiPanelBase
	{
		// Token: 0x17008787 RID: 34695
		// (get) Token: 0x06032FD3 RID: 208851 RVA: 0x00CC594A File Offset: 0x00CC3B4A
		[Nullable(2)]
		public UUIItem TempOriginalItem
		{
			[NullableContext(2)]
			get
			{
				GenericLayoutNew<TItem> genericLayout = this.GenericLayout;
				if (genericLayout == null)
				{
					return null;
				}
				return genericLayout.TempOriginalItem;
			}
		}

		// Token: 0x17008788 RID: 34696
		// (get) Token: 0x06032FD4 RID: 208852 RVA: 0x00CC5960 File Offset: 0x00CC3B60
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

		// Token: 0x17008789 RID: 34697
		// (get) Token: 0x06032FD5 RID: 208853 RVA: 0x00CC59E3 File Offset: 0x00CC3BE3
		[Nullable(new byte[]
		{
			0,
			1
		})]
		public TWeakObjectPtr<UUIItem> ContentItem
		{
			[return: Nullable(new byte[]
			{
				0,
				1
			})]
			get
			{
				return this.TargetScroll.ContentUIItem;
			}
		}

		// Token: 0x1700878A RID: 34698
		// (get) Token: 0x06032FD6 RID: 208854 RVA: 0x00CC59F0 File Offset: 0x00CC3BF0
		public float ScrollWidth
		{
			get
			{
				return this.TargetScroll.RootUIComp.Get().Width;
			}
		}

		// Token: 0x06032FD7 RID: 208855 RVA: 0x00CC5A18 File Offset: 0x00CC3C18
		public GenericScrollView(UUIScrollViewWithScrollbarComponent scrollView, TLayoutRefresh<TItem> refreshFunction, [Nullable(2)] UUIItem originalItem = null)
		{
			this.TargetScroll = scrollView;
			this.GenericLayout = new GenericLayoutNew<TItem>(this.TargetScroll.GetContent().GetComponentByClass(UUILayoutBase.StaticClass()) as UUILayoutBase, refreshFunction, originalItem);
			this.GenericLayout.SetScrollView(scrollView);
		}

		// Token: 0x06032FD8 RID: 208856 RVA: 0x00CC5A6A File Offset: 0x00CC3C6A
		[NullableContext(2)]
		public void RefreshByData<T>([Nullable(new byte[]
		{
			2,
			1
		})] List<T> data, int? length = null)
		{
			this.GenericLayout.RebuildLayoutByDataNew<T>(data, length);
		}

		// Token: 0x06032FD9 RID: 208857 RVA: 0x00CC5A79 File Offset: 0x00CC3C79
		public void ClearChildren()
		{
			this.GenericLayout.ClearChildren();
			this.TargetScroll.OnScrollValueChange.Unbind();
		}

		// Token: 0x06032FDA RID: 208858 RVA: 0x00CC5A96 File Offset: 0x00CC3C96
		public void SetHorizontalScrollEnable(bool enable)
		{
			this.TargetScroll.SetHorizontal(enable);
		}

		// Token: 0x06032FDB RID: 208859 RVA: 0x00CC5AA4 File Offset: 0x00CC3CA4
		public void SetVerticalScrollEnable(bool enable)
		{
			this.TargetScroll.SetVertical(enable);
		}

		// Token: 0x06032FDC RID: 208860 RVA: 0x00CC5AB2 File Offset: 0x00CC3CB2
		[NullableContext(2)]
		public UUIItem GetItemByIndex(int index)
		{
			return this.GenericLayout.GetItemByIndex(index);
		}

		// Token: 0x06032FDD RID: 208861 RVA: 0x00CC5AC0 File Offset: 0x00CC3CC0
		[return: Nullable(2)]
		public TItem GetScrollItemByKey(object key)
		{
			return this.GenericLayout.GetLayoutItemByKey(key);
		}

		// Token: 0x06032FDE RID: 208862 RVA: 0x00CC5ACE File Offset: 0x00CC3CCE
		public Dictionary<object, TItem> GetScrollItemMap()
		{
			return this.GenericLayout.GetLayoutItemMap();
		}

		// Token: 0x06032FDF RID: 208863 RVA: 0x00CC5ADB File Offset: 0x00CC3CDB
		public List<TItem> GetScrollItemList()
		{
			return this.GenericLayout.GetLayoutItemList();
		}

		// Token: 0x06032FE0 RID: 208864 RVA: 0x00CC5AE8 File Offset: 0x00CC3CE8
		public void ScrollTo(UUIItem uiItem)
		{
			this.TargetScroll.ScrollTo(uiItem, false);
		}

		// Token: 0x06032FE1 RID: 208865 RVA: 0x00CC5AF8 File Offset: 0x00CC3CF8
		public void ScrollToLeft(object key)
		{
			TItem layoutItemByKey = this.GenericLayout.GetLayoutItemByKey(key);
			FVector relativeLocation = this.TargetScroll.ContentUIItem.Get().RelativeLocation;
			FVector2D fvector2D = new FVector2D(relativeLocation.X, relativeLocation.Y);
			this.TargetScroll.ScrollToLeft(ref fvector2D, layoutItemByKey.GetRootItem(), false);
		}

		// Token: 0x06032FE2 RID: 208866 RVA: 0x00CC5B58 File Offset: 0x00CC3D58
		public void ScrollToRight(object key)
		{
			TItem layoutItemByKey = this.GenericLayout.GetLayoutItemByKey(key);
			FVector relativeLocation = this.TargetScroll.ContentUIItem.Get().RelativeLocation;
			FVector2D fvector2D = new FVector2D(relativeLocation.X, relativeLocation.Y);
			this.TargetScroll.ScrollToRight(ref fvector2D, layoutItemByKey.GetRootItem(), false);
		}

		// Token: 0x06032FE3 RID: 208867 RVA: 0x00CC5BB8 File Offset: 0x00CC3DB8
		public void ScrollToTop(object key)
		{
			TItem layoutItemByKey = this.GenericLayout.GetLayoutItemByKey(key);
			FVector relativeLocation = this.TargetScroll.ContentUIItem.Get().RelativeLocation;
			FVector2D fvector2D = new FVector2D(relativeLocation.X, relativeLocation.Y);
			this.TargetScroll.ScrollToTop(ref fvector2D, layoutItemByKey.GetRootItem(), false);
		}

		// Token: 0x06032FE4 RID: 208868 RVA: 0x00CC5C18 File Offset: 0x00CC3E18
		public void ScrollToBottom(object key)
		{
			TItem layoutItemByKey = this.GenericLayout.GetLayoutItemByKey(key);
			FVector relativeLocation = this.TargetScroll.ContentUIItem.Get().RelativeLocation;
			FVector2D fvector2D = new FVector2D(relativeLocation.X, relativeLocation.Y);
			this.TargetScroll.ScrollToBottom(ref fvector2D, layoutItemByKey.GetRootItem(), false);
		}

		// Token: 0x06032FE5 RID: 208869 RVA: 0x00CC5C78 File Offset: 0x00CC3E78
		public void SetActive(bool bActive)
		{
			this.TargetScroll.RootUIComp.Get().SetUIActive(bActive);
		}

		// Token: 0x06032FE6 RID: 208870 RVA: 0x00CC5C9E File Offset: 0x00CC3E9E
		public void BindScrollValueChange(Action<FVector2D> callback)
		{
			this.TargetScroll.OnScrollValueChange.Bind(callback);
		}

		// Token: 0x06032FE7 RID: 208871 RVA: 0x00CC5CB1 File Offset: 0x00CC3EB1
		public void BindLateUpdate(Action<float> callBack)
		{
			this.GenericLayout.BindLateUpdate(callBack);
		}

		// Token: 0x06032FE8 RID: 208872 RVA: 0x00CC5CBF File Offset: 0x00CC3EBF
		public void UnBindLateUpdate()
		{
			this.GenericLayout.UnBindLateUpdate();
		}

		// Token: 0x06032FE9 RID: 208873 RVA: 0x00CC5CCC File Offset: 0x00CC3ECC
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public GenericLayoutNew<TItem> GetGenericLayout()
		{
			return this.GenericLayout;
		}

		// Token: 0x0401DA9F RID: 121503
		[Nullable(2)]
		private readonly UUIScrollViewWithScrollbarComponent TargetScroll;

		// Token: 0x0401DAA0 RID: 121504
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private readonly GenericLayoutNew<TItem> GenericLayout;
	}
}
