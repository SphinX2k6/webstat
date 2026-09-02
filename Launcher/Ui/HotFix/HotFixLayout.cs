using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Launcher.Ui.HotFix
{
	// Token: 0x02004506 RID: 17670
	[NullableContext(1)]
	[Nullable(0)]
	public class HotFixLayout<TItem, [Nullable(0)] TData> where TItem : class, IHotFixLayoutItem where TData : IHotFixLayoutData
	{
		// Token: 0x0602E905 RID: 190725 RVA: 0x00B08734 File Offset: 0x00B06934
		public HotFixLayout(UUILayoutBase layout, Func<TItem> itemCreateFunction, [Nullable(2)] AUIBaseActor gridActor = null)
		{
			this.Layout = layout;
			((AUIBaseActor)this.Layout.GetOwner()).OnPreDestroyed.Add(new Action<AActor>(this.OnDestroy));
			if (gridActor == null)
			{
				UUIItem attachUIChild = layout.RootUIComp.Get().GetAttachUIChild(0);
				this.TemplateGridActor = (((attachUIChild != null) ? attachUIChild.GetOwner() : null) as AUIBaseActor);
			}
			else
			{
				this.TemplateGridActor = gridActor;
			}
			if (this.TemplateGridActor == null)
			{
				return;
			}
			this.ItemCreateFunction = itemCreateFunction;
			this.TemplateGridActor.GetUIItem().SetUIActive(false);
		}

		// Token: 0x0602E906 RID: 190726 RVA: 0x00B087ED File Offset: 0x00B069ED
		[NullableContext(2)]
		private void OnDestroy(AActor _)
		{
			this.Layout = null;
			this.TemplateGridActor = null;
		}

		// Token: 0x0602E907 RID: 190727 RVA: 0x00B08800 File Offset: 0x00B06A00
		public void LoadGrid(int length)
		{
			for (int i = this.GridItemList.Count; i < length; i++)
			{
				UUIItem item = this.CreateGrid();
				this.GridItemList.Add(item);
			}
		}

		// Token: 0x0602E908 RID: 190728 RVA: 0x00B08838 File Offset: 0x00B06A38
		[NullableContext(2)]
		public UUIItem GetRootUiItem()
		{
			UUILayoutBase layout = this.Layout;
			TWeakObjectPtr<UUIItem>? tweakObjectPtr = (layout != null) ? new TWeakObjectPtr<UUIItem>?(layout.RootUIComp) : null;
			if (tweakObjectPtr == null)
			{
				return null;
			}
			return tweakObjectPtr.GetValueOrDefault();
		}

		// Token: 0x0602E909 RID: 190729 RVA: 0x00B0887C File Offset: 0x00B06A7C
		public IReadOnlyList<TData> GetDataList()
		{
			return this.DataList;
		}

		// Token: 0x0602E90A RID: 190730 RVA: 0x00B08884 File Offset: 0x00B06A84
		[NullableContext(2)]
		private UUIItem CreateGrid()
		{
			return HotFixLguiUtils.CopyItem(this.TemplateGridActor.GetUIItem(), this.GetRootUiItem());
		}

		// Token: 0x0602E90B RID: 190731 RVA: 0x00B0889C File Offset: 0x00B06A9C
		[NullableContext(2)]
		public UUIItem GetGridItemByIndex(int index)
		{
			if (index < 0 || index >= this.GridItemList.Count)
			{
				return null;
			}
			return this.GridItemList[index];
		}

		// Token: 0x0602E90C RID: 190732 RVA: 0x00B088BE File Offset: 0x00B06ABE
		[NullableContext(2)]
		public IHotFixLayoutItem GetLayoutItemByIndex(int index)
		{
			if (index < 0 || index >= this.ItemList.Count)
			{
				return null;
			}
			return this.ItemList[index];
		}

		// Token: 0x0602E90D RID: 190733 RVA: 0x00B088E5 File Offset: 0x00B06AE5
		public IReadOnlyList<IHotFixLayoutItem> GetLayoutItemList()
		{
			return this.ItemList;
		}

		// Token: 0x0602E90E RID: 190734 RVA: 0x00B088F0 File Offset: 0x00B06AF0
		public void RefreshByData(IReadOnlyList<TData> dataList)
		{
			this.DataList = new List<TData>(dataList);
			this.HideChildren();
			this.LoadGrid(dataList.Count);
			for (int i = 0; i < dataList.Count; i++)
			{
				TData tdata = dataList[i];
				ref TData ptr = ref tdata;
				if (default(TData) == null)
				{
					TData tdata2 = tdata;
					ptr = ref tdata2;
				}
				ptr.Index = new int?(i);
				TItem titem;
				if (i >= this.ItemList.Count)
				{
					UUIItem uuiitem = this.GridItemList[i];
					titem = this.ItemCreateFunction();
					titem.SetRootActor(uuiitem.GetOwner());
					this.ItemList.Add(titem);
				}
				else
				{
					titem = this.ItemList[i];
				}
				titem.Refresh(tdata);
				titem.SetActive(true);
			}
		}

		// Token: 0x0602E90F RID: 190735 RVA: 0x00B089D8 File Offset: 0x00B06BD8
		public void HideChildren()
		{
			for (int i = 0; i < this.ItemList.Count; i++)
			{
				this.ItemList[i].SetActive(false);
			}
		}

		// Token: 0x0602E910 RID: 190736 RVA: 0x00B08A14 File Offset: 0x00B06C14
		public void ClearChildren()
		{
			for (int i = 0; i < this.ItemList.Count; i++)
			{
				this.ItemList[i].Destroy();
			}
			this.ItemList.Clear();
			for (int j = 0; j < this.GridItemList.Count; j++)
			{
				AActor owner = this.GridItemList[j].GetOwner();
				if (owner != null && owner.IsValid())
				{
					owner.K2_DestroyActor();
				}
			}
			this.GridItemList.Clear();
		}

		// Token: 0x0401A73D RID: 108349
		[Nullable(2)]
		private UUILayoutBase Layout;

		// Token: 0x0401A73E RID: 108350
		[Nullable(2)]
		private AUIBaseActor TemplateGridActor;

		// Token: 0x0401A73F RID: 108351
		private readonly List<UUIItem> GridItemList = new List<UUIItem>();

		// Token: 0x0401A740 RID: 108352
		private readonly List<TItem> ItemList = new List<TItem>();

		// Token: 0x0401A741 RID: 108353
		private List<TData> DataList = new List<TData>();

		// Token: 0x0401A742 RID: 108354
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private readonly Func<TItem> ItemCreateFunction;
	}
}
