using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Util.Layout
{
	// Token: 0x02004C7E RID: 19582
	[NullableContext(2)]
	[Nullable(0)]
	public class GenericLayoutNew<TGenericLayoutNewItem> : IGridPreserver
	{
		// Token: 0x17008795 RID: 34709
		// (get) Token: 0x0603307C RID: 209020 RVA: 0x00CC7DFA File Offset: 0x00CC5FFA
		public UUIItem TempOriginalItem
		{
			get
			{
				return this.OriginalItem;
			}
		}

		// Token: 0x0603307D RID: 209021 RVA: 0x00CC7E04 File Offset: 0x00CC6004
		[NullableContext(1)]
		public GenericLayoutNew(UUILayoutBase layout, [Nullable(new byte[]
		{
			2,
			1
		})] TLayoutRefresh<TGenericLayoutNewItem> refreshFunction, [Nullable(2)] UUIItem originalItem = null)
		{
			this.ProxyLayout = layout;
			this.RefreshFunction = refreshFunction;
			this.SaveOriginalItem(originalItem);
			this.GridsController = new InTurnGridAppearAnimation(this);
			this.GridsController.RegisterAnimController();
		}

		// Token: 0x0603307E RID: 209022 RVA: 0x00CC7E80 File Offset: 0x00CC6080
		private void ClearItemList()
		{
			foreach (TGenericLayoutNewItem tgenericLayoutNewItem in this.ItemMap.Values)
			{
				UiComponentAction uiComponentAction = tgenericLayoutNewItem as UiComponentAction;
				if (uiComponentAction != null)
				{
					uiComponentAction.Destroy(null);
				}
			}
			this.ItemMap.Clear();
			this.ItemList.Clear();
		}

		// Token: 0x0603307F RID: 209023 RVA: 0x00CC7EFC File Offset: 0x00CC60FC
		private void SaveOriginalItem(UUIItem originalItem)
		{
			if (this.OriginalItem == null)
			{
				UUIItem uuiitem;
				if (originalItem == null)
				{
					uuiitem = this.GetItemByIndex(0);
				}
				else
				{
					uuiitem = originalItem;
				}
				if (uuiitem != null)
				{
					uuiitem.SetUIActive(false);
				}
				if (uuiitem != null)
				{
					uuiitem.SetUIParent(this.GetRootParentUiItem(), false);
				}
				this.OriginalItem = uuiitem;
				this.DisplayName = ((uuiitem != null) ? uuiitem.displayName : null);
			}
		}

		// Token: 0x06033080 RID: 209024 RVA: 0x00CC7F55 File Offset: 0x00CC6155
		[NullableContext(1)]
		public void SetScrollView(UUIScrollViewWithScrollbarComponent scrollView)
		{
			this.ScrollView = scrollView;
			this.IsUseByLayout = false;
			GridAppearAnimationBase gridsController = this.GridsController;
			if (gridsController == null)
			{
				return;
			}
			gridsController.RegisterAnimController();
		}

		// Token: 0x06033081 RID: 209025 RVA: 0x00CC7F78 File Offset: 0x00CC6178
		public void PreLoadCopyItem(int preLoadNum)
		{
			for (int i = 0; i < preLoadNum; i++)
			{
				this.CreateCopyItem().SetUIActive(false);
			}
		}

		// Token: 0x06033082 RID: 209026 RVA: 0x00CC7F9D File Offset: 0x00CC619D
		public UUIItem GetRootUiItem()
		{
			return this.ProxyLayout.RootUIComp;
		}

		// Token: 0x06033083 RID: 209027 RVA: 0x00CC7FAF File Offset: 0x00CC61AF
		private UUIItem GetRootParentUiItem()
		{
			return this.GetRootUiItem().GetParentAsUIItem();
		}

		// Token: 0x06033084 RID: 209028 RVA: 0x00CC7FBC File Offset: 0x00CC61BC
		private void RecycleToPool()
		{
			if (this.CopyItemList.Count > 0)
			{
				List<UUIItem> copyItemList = this.CopyItemList;
				UUIItem uuiitem = copyItemList[copyItemList.Count - 1];
				this.CopyItemList.RemoveAt(this.CopyItemList.Count - 1);
				uuiitem.SetUIActive(false);
				this.PoolItemList.Add(uuiitem);
			}
		}

		// Token: 0x06033085 RID: 209029 RVA: 0x00CC8018 File Offset: 0x00CC6218
		[NullableContext(1)]
		private UUIItem CreateCopyItem()
		{
			UUIItem uuiitem = Singleton<LguiUtil>.Instance.CopyItem(this.OriginalItem, this.GetRootUiItem());
			this.CopyItemList.Add(uuiitem);
			return uuiitem;
		}

		// Token: 0x06033086 RID: 209030 RVA: 0x00CC804C File Offset: 0x00CC624C
		private void AddFromPool()
		{
			if (this.PoolItemList.Count > 0)
			{
				List<UUIItem> poolItemList = this.PoolItemList;
				UUIItem uuiitem = poolItemList[poolItemList.Count - 1];
				this.PoolItemList.RemoveAt(this.PoolItemList.Count - 1);
				uuiitem.SetUIActive(true);
				this.CopyItemList.Add(uuiitem);
				return;
			}
			this.CreateCopyItem().SetUIActive(true);
		}

		// Token: 0x06033087 RID: 209031 RVA: 0x00CC80B3 File Offset: 0x00CC62B3
		private void ResetOriginalActor()
		{
			if (this.OriginalItem != null)
			{
				this.OriginalItem.SetUIActive(true);
				this.OriginalItem.SetUIParent(this.GetRootUiItem(), false);
				this.OriginalItem = null;
			}
		}

		// Token: 0x06033088 RID: 209032 RVA: 0x00CC80E4 File Offset: 0x00CC62E4
		private void Clear()
		{
			for (int i = 0; i < this.PoolItemList.Count; i++)
			{
				AActor owner = this.PoolItemList[i].GetOwner();
				if (owner != null && owner.IsValid())
				{
					ULGUIBPLibrary.DestroyActorWithHierarchy(this.PoolItemList[i].GetOwner(), true);
				}
			}
			this.PoolItemList.Clear();
			for (int j = 0; j < this.CopyItemList.Count; j++)
			{
				AActor owner2 = this.CopyItemList[j].GetOwner();
				if (owner2 != null && owner2.IsValid())
				{
					ULGUIBPLibrary.DestroyActorWithHierarchy(this.CopyItemList[j].GetOwner(), true);
				}
			}
			this.CopyItemList.Clear();
			this.ClearGridController();
		}

		// Token: 0x06033089 RID: 209033 RVA: 0x00CC81A5 File Offset: 0x00CC63A5
		public void ClearGridController()
		{
			if (this.GridsController != null)
			{
				this.GridsController.Clear();
				this.GridsController = null;
			}
		}

		// Token: 0x0603308A RID: 209034 RVA: 0x00CC81C1 File Offset: 0x00CC63C1
		public void SetNeedAnim(bool value)
		{
			this.NeedAnim = value;
		}

		// Token: 0x0603308B RID: 209035 RVA: 0x00CC81CC File Offset: 0x00CC63CC
		public void RebuildLayoutByDataNew<T>([Nullable(new byte[]
		{
			2,
			1
		})] IReadOnlyList<T> data, int? length = null)
		{
			this.SaveOriginalItem(null);
			this.ClearItemList();
			int num = (data != null) ? data.Count : 0;
			int valueOrDefault = length.GetValueOrDefault(num);
			int count = this.CopyItemList.Count;
			this.DisplayGridNum = valueOrDefault;
			this.IsClear = false;
			if (valueOrDefault < this.CopyItemList.Count)
			{
				for (int i = 0; i < valueOrDefault; i++)
				{
					this.CopyItemList[i].SetUIActive(true);
				}
				for (int j = valueOrDefault; j < count; j++)
				{
					this.RecycleToPool();
				}
			}
			else if (valueOrDefault > this.CopyItemList.Count)
			{
				for (int k = 0; k < count; k++)
				{
					this.CopyItemList[k].SetUIActive(true);
				}
				for (int l = 0; l < valueOrDefault - count; l++)
				{
					this.AddFromPool();
				}
			}
			int num2 = 0;
			for (int m = 0; m < valueOrDefault; m++)
			{
				UUIItem uuiitem = this.CopyItemList[m];
				uuiitem.displayName = this.DisplayName + "_" + m.ToString();
				object data2 = (m < num) ? data[m] : null;
				TLayoutRefresh<TGenericLayoutNewItem> refreshFunction = this.RefreshFunction;
				ILayoutItem<TGenericLayoutNewItem> layoutItem = (refreshFunction != null) ? refreshFunction(data2, uuiitem, num2) : null;
				if (layoutItem != null && layoutItem.Value != null)
				{
					this.ItemMap.Add(layoutItem.Key, layoutItem.Value);
					this.ItemList.Add(layoutItem.Value);
					num2++;
				}
			}
			if (this.GridsController != null && this.NeedAnim)
			{
				this.GridsController.PlayGridAnim(this.DisplayGridNum, false);
			}
		}

		// Token: 0x0603308C RID: 209036 RVA: 0x00CC8380 File Offset: 0x00CC6580
		public UUIItem GetItemByIndex(int index)
		{
			if (this.ProxyLayout != null)
			{
				TArray<UUIItem> attachUIChildren = this.GetRootUiItem().GetAttachUIChildren();
				if (index < attachUIChildren.Num())
				{
					return attachUIChildren[index];
				}
			}
			return null;
		}

		// Token: 0x0603308D RID: 209037 RVA: 0x00CC83B4 File Offset: 0x00CC65B4
		[NullableContext(1)]
		[return: Nullable(2)]
		public TGenericLayoutNewItem GetLayoutItemByKey(object key)
		{
			TGenericLayoutNewItem result;
			if (this.ItemMap.TryGetValue(key, out result))
			{
				return result;
			}
			return default(TGenericLayoutNewItem);
		}

		// Token: 0x0603308E RID: 209038 RVA: 0x00CC83DC File Offset: 0x00CC65DC
		[NullableContext(1)]
		public Dictionary<object, TGenericLayoutNewItem> GetLayoutItemMap()
		{
			return this.ItemMap;
		}

		// Token: 0x0603308F RID: 209039 RVA: 0x00CC83E4 File Offset: 0x00CC65E4
		[NullableContext(1)]
		public List<TGenericLayoutNewItem> GetLayoutItemList()
		{
			return this.ItemList;
		}

		// Token: 0x06033090 RID: 209040 RVA: 0x00CC83EC File Offset: 0x00CC65EC
		public TGenericLayoutNewItem GetLayoutItemByIndex(int index)
		{
			if (index >= 0 && index < this.ItemList.Count)
			{
				return this.ItemList[index];
			}
			return default(TGenericLayoutNewItem);
		}

		// Token: 0x06033091 RID: 209041 RVA: 0x00CC8421 File Offset: 0x00CC6621
		public void ClearChildren()
		{
			if (this.IsClear)
			{
				return;
			}
			this.IsClear = true;
			this.ProxyLayout.OnLateUpdate.Unbind();
			this.ClearItemList();
			this.Clear();
			this.ResetOriginalActor();
		}

		// Token: 0x06033092 RID: 209042 RVA: 0x00CC8458 File Offset: 0x00CC6658
		public void SetActive(bool bActive)
		{
			this.ProxyLayout.RootUIComp.Get().SetUIActive(bActive);
		}

		// Token: 0x06033093 RID: 209043 RVA: 0x00CC847E File Offset: 0x00CC667E
		public int GetDisplayGridNum()
		{
			return this.DisplayGridNum;
		}

		// Token: 0x06033094 RID: 209044 RVA: 0x00CC8486 File Offset: 0x00CC6686
		public int GetPreservedGridNum()
		{
			return this.CopyItemList.Count;
		}

		// Token: 0x06033095 RID: 209045 RVA: 0x00CC8493 File Offset: 0x00CC6693
		public int GetDisplayGridStartIndex()
		{
			return 0;
		}

		// Token: 0x06033096 RID: 209046 RVA: 0x00CC8496 File Offset: 0x00CC6696
		public int GetDisplayGridEndIndex()
		{
			return this.DisplayGridNum - 1;
		}

		// Token: 0x06033097 RID: 209047 RVA: 0x00CC84A0 File Offset: 0x00CC66A0
		public float GetGridAnimationInterval()
		{
			return this.ProxyLayout.GetGridAnimationInterval();
		}

		// Token: 0x06033098 RID: 209048 RVA: 0x00CC84AD File Offset: 0x00CC66AD
		public float GetGridAnimationStartTime()
		{
			return this.ProxyLayout.GetGridAnimationStartTime();
		}

		// Token: 0x06033099 RID: 209049 RVA: 0x00CC84BA File Offset: 0x00CC66BA
		public UUIItem GetGrid(int gridIndex)
		{
			return this.GetItemByIndex(gridIndex % this.DisplayGridNum);
		}

		// Token: 0x0603309A RID: 209050 RVA: 0x00CC84CA File Offset: 0x00CC66CA
		public UUIItem GetGridByDisplayIndex(int displayIndex)
		{
			return this.GetItemByIndex(displayIndex);
		}

		// Token: 0x0603309B RID: 209051 RVA: 0x00CC84D3 File Offset: 0x00CC66D3
		[NullableContext(1)]
		public void BindLateUpdate(Action<float> callBack)
		{
			this.ProxyLayout.OnLateUpdate.Bind(callBack);
		}

		// Token: 0x0603309C RID: 209052 RVA: 0x00CC84E6 File Offset: 0x00CC66E6
		public void UnBindLateUpdate()
		{
			this.ProxyLayout.OnLateUpdate.Unbind();
		}

		// Token: 0x0603309D RID: 209053 RVA: 0x00CC84F8 File Offset: 0x00CC66F8
		public void NotifyAnimationStart()
		{
			this.ProxyLayout.SetInAnimation(true);
		}

		// Token: 0x0603309E RID: 209054 RVA: 0x00CC8506 File Offset: 0x00CC6706
		public void NotifyAnimationEnd()
		{
			this.ProxyLayout.SetInAnimation(false);
		}

		// Token: 0x0603309F RID: 209055 RVA: 0x00CC8514 File Offset: 0x00CC6714
		public UUIInturnAnimController GetUiAnimController()
		{
			if (this.IsUseByLayout)
			{
				UUILayoutBase proxyLayout = this.ProxyLayout;
				return ((proxyLayout != null) ? proxyLayout.GetOwner().GetComponentByClass(UUIInturnAnimController.StaticClass()) : null) as UUIInturnAnimController;
			}
			UUIScrollViewWithScrollbarComponent scrollView = this.ScrollView;
			AUIBaseActor auibaseActor = (scrollView != null) ? scrollView.GetContent() : null;
			return ((auibaseActor != null) ? auibaseActor.GetComponentByClass(UUIInturnAnimController.StaticClass()) : null) as UUIInturnAnimController;
		}

		// Token: 0x0401DACF RID: 121551
		private GridAppearAnimationBase GridsController;

		// Token: 0x0401DAD0 RID: 121552
		private readonly UUILayoutBase ProxyLayout;

		// Token: 0x0401DAD1 RID: 121553
		private UUIScrollViewWithScrollbarComponent ScrollView;

		// Token: 0x0401DAD2 RID: 121554
		[Nullable(1)]
		private readonly List<UUIItem> CopyItemList = new List<UUIItem>();

		// Token: 0x0401DAD3 RID: 121555
		[Nullable(1)]
		private readonly List<UUIItem> PoolItemList = new List<UUIItem>();

		// Token: 0x0401DAD4 RID: 121556
		private UUIItem OriginalItem;

		// Token: 0x0401DAD5 RID: 121557
		[Nullable(1)]
		private readonly Dictionary<object, TGenericLayoutNewItem> ItemMap = new Dictionary<object, TGenericLayoutNewItem>();

		// Token: 0x0401DAD6 RID: 121558
		[Nullable(1)]
		private List<TGenericLayoutNewItem> ItemList = new List<TGenericLayoutNewItem>();

		// Token: 0x0401DAD7 RID: 121559
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private readonly TLayoutRefresh<TGenericLayoutNewItem> RefreshFunction;

		// Token: 0x0401DAD8 RID: 121560
		private int DisplayGridNum;

		// Token: 0x0401DAD9 RID: 121561
		private bool IsClear;

		// Token: 0x0401DADA RID: 121562
		private string DisplayName;

		// Token: 0x0401DADB RID: 121563
		private bool NeedAnim = true;

		// Token: 0x0401DADC RID: 121564
		private bool IsUseByLayout = true;
	}
}
