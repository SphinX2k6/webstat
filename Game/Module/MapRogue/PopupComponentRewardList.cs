using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.MapRogue
{
	// Token: 0x02005996 RID: 22934
	[NullableContext(1)]
	[Nullable(0)]
	public class PopupComponentRewardList : UiPanelBase
	{
		// Token: 0x0603A113 RID: 237843 RVA: 0x00EB2357 File Offset: 0x00EB0557
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIHorizontalLayout)),
				new ValueTuple<int, Type>(1, typeof(UUIItem))
			};
		}

		// Token: 0x0603A114 RID: 237844 RVA: 0x00EB2390 File Offset: 0x00EB0590
		protected override void OnStart()
		{
			this.ItemLayout = new GenericLayout<CommonItemSmallItemGrid, TItem>(base.GetHorizontalLayout(0), new Func<CommonItemSmallItemGrid>(this.OnCreateRewardItem), null, false, true);
		}

		// Token: 0x0603A115 RID: 237845 RVA: 0x00EB23B4 File Offset: 0x00EB05B4
		public void Refresh(MapGridData gridData)
		{
			if (gridData.RewardItemIdList.Count == 0 || gridData.IsExplore)
			{
				this.SetActive(false);
				return;
			}
			List<TItem> list = new List<TItem>();
			foreach (int itemId in gridData.RewardItemIdList)
			{
				TItem item = new TItem(new InventoryDefine.GetItemData(itemId, 0), 0);
				list.Add(item);
			}
			this.ItemLayout.RefreshByData(list, null, false);
		}

		// Token: 0x0603A116 RID: 237846 RVA: 0x00EB2448 File Offset: 0x00EB0648
		private CommonItemSmallItemGrid OnCreateRewardItem()
		{
			return new CommonItemSmallItemGrid();
		}

		// Token: 0x04020F02 RID: 134914
		[Nullable(new byte[]
		{
			2,
			1
		})]
		protected GenericLayout<CommonItemSmallItemGrid, TItem> ItemLayout;
	}
}
