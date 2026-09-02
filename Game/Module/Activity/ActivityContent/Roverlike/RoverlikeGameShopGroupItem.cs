using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x0200641D RID: 25629
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RoverlikeGameShopGroupItem : GridProxyAbstract<IRoverlikeGameShopGroupData>
	{
		// Token: 0x06040564 RID: 263524 RVA: 0x0107D59F File Offset: 0x0107B79F
		public void BindOnGridSelect(Action<IRoverlikeGameShopGridData> cb)
		{
			this.OnGridSelect = cb;
		}

		// Token: 0x06040565 RID: 263525 RVA: 0x0107D5A8 File Offset: 0x0107B7A8
		public void BindOnGridsRefreshed(Action<ERoverlikeGameShopItemType> cb)
		{
			this.OnGridsRefreshed = cb;
		}

		// Token: 0x06040566 RID: 263526 RVA: 0x0107D5B4 File Offset: 0x0107B7B4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIGridLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06040567 RID: 263527 RVA: 0x0107D63E File Offset: 0x0107B83E
		protected override void OnStart()
		{
			this.ItemLayout = new GenericLayout<RoverlikeGameShopGrid, IRoverlikeGameShopGridData>(base.GetGridLayout(1), new Func<RoverlikeGameShopGrid>(this.CreateShopGrid), null, false, true);
		}

		// Token: 0x06040568 RID: 263528 RVA: 0x0107D664 File Offset: 0x0107B864
		public override void Refresh(IRoverlikeGameShopGroupData data, bool isSelected, int gridIndex)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), data.TitleTextKey, Array.Empty<object>());
			ERoverlikeGameShopItemType groupType = data.GroupType;
			this.ItemLayout.RefreshByData(data.Grids, delegate
			{
				Action<ERoverlikeGameShopItemType> onGridsRefreshed = this.OnGridsRefreshed;
				if (onGridsRefreshed == null)
				{
					return;
				}
				onGridsRefreshed(groupType);
			}, false);
		}

		// Token: 0x06040569 RID: 263529 RVA: 0x0107D6C4 File Offset: 0x0107B8C4
		public override object GetKey(IRoverlikeGameShopGroupData data, int displayIndex)
		{
			return data.GroupType;
		}

		// Token: 0x0604056A RID: 263530 RVA: 0x0107D6D1 File Offset: 0x0107B8D1
		public void SetGridSelected(int incId, bool selected)
		{
			if (this.ItemLayout == null)
			{
				return;
			}
			RoverlikeGameShopGrid layoutItemByKey = this.ItemLayout.GetLayoutItemByKey(incId);
			if (layoutItemByKey == null)
			{
				return;
			}
			layoutItemByKey.SetSelected(selected, false);
		}

		// Token: 0x0604056B RID: 263531 RVA: 0x0107D6FC File Offset: 0x0107B8FC
		[NullableContext(2)]
		public UUIItem GetGridNavigationItem(int incId)
		{
			GenericLayout<RoverlikeGameShopGrid, IRoverlikeGameShopGridData> itemLayout = this.ItemLayout;
			TWeakObjectPtr<UUIItem>? tweakObjectPtr;
			if (itemLayout == null)
			{
				tweakObjectPtr = null;
			}
			else
			{
				RoverlikeGameShopGrid layoutItemByKey = itemLayout.GetLayoutItemByKey(incId);
				if (layoutItemByKey == null)
				{
					tweakObjectPtr = null;
				}
				else
				{
					UUIExtendToggle itemGridExtendToggle = layoutItemByKey.GetItemGridExtendToggle();
					tweakObjectPtr = ((itemGridExtendToggle != null) ? new TWeakObjectPtr<UUIItem>?(itemGridExtendToggle.RootUIComp) : null);
				}
			}
			TWeakObjectPtr<UUIItem>? tweakObjectPtr2 = tweakObjectPtr;
			if (tweakObjectPtr2 == null)
			{
				return null;
			}
			return tweakObjectPtr2.GetValueOrDefault();
		}

		// Token: 0x0604056C RID: 263532 RVA: 0x0107D76E File Offset: 0x0107B96E
		private RoverlikeGameShopGrid CreateShopGrid()
		{
			RoverlikeGameShopGrid roverlikeGameShopGrid = new RoverlikeGameShopGrid();
			roverlikeGameShopGrid.BindOnSelect(new Action<IRoverlikeGameShopGridData>(this.OnGridSelectFromLayout));
			return roverlikeGameShopGrid;
		}

		// Token: 0x0604056D RID: 263533 RVA: 0x0107D787 File Offset: 0x0107B987
		private void OnGridSelectFromLayout(IRoverlikeGameShopGridData data)
		{
			Action<IRoverlikeGameShopGridData> onGridSelect = this.OnGridSelect;
			if (onGridSelect == null)
			{
				return;
			}
			onGridSelect(data);
		}

		// Token: 0x0604056E RID: 263534 RVA: 0x0107D79A File Offset: 0x0107B99A
		protected override void OnBeforeDestroy()
		{
			this.OnGridSelect = null;
			this.OnGridsRefreshed = null;
		}

		// Token: 0x040240D5 RID: 147669
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<RoverlikeGameShopGrid, IRoverlikeGameShopGridData> ItemLayout;

		// Token: 0x040240D6 RID: 147670
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Action<IRoverlikeGameShopGridData> OnGridSelect;

		// Token: 0x040240D7 RID: 147671
		[Nullable(2)]
		private Action<ERoverlikeGameShopItemType> OnGridsRefreshed;

		// Token: 0x0200C485 RID: 50309
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x0403C7D6 RID: 247766
			public const int TxtTitle = 0;

			// Token: 0x0403C7D7 RID: 247767
			public const int ItemLayout = 1;

			// Token: 0x0403C7D8 RID: 247768
			public const int ItemShopGrid = 2;
		}
	}
}
