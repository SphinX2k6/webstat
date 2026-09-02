using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Protocol;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x02006405 RID: 25605
	[NullableContext(1)]
	[Nullable(0)]
	public class RoverlikeSettleItemPanel : UiPanelBase, IRoverlikeSettleSelectablePanel
	{
		// Token: 0x06040485 RID: 263301 RVA: 0x01079B56 File Offset: 0x01077D56
		public void BindOnItemClick(Action<int, int> callback)
		{
			this.OnItemClick = callback;
		}

		// Token: 0x06040486 RID: 263302 RVA: 0x01079B60 File Offset: 0x01077D60
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIGridLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06040487 RID: 263303 RVA: 0x01079C0B File Offset: 0x01077E0B
		protected override void OnStart()
		{
			this.ItemLayout = new GenericLayout<RoverlikeEntrySmallGridItem, IRoverlikeEntrySmallGridData>(base.GetGridLayout(1), new Func<RoverlikeEntrySmallGridItem>(this.CreateItemGrid), null, false, true);
		}

		// Token: 0x06040488 RID: 263304 RVA: 0x01079C30 File Offset: 0x01077E30
		public void Refresh(List<int> configIdList)
		{
			base.GetText(0).SetText(configIdList.Count.ToString(), true);
			List<IRoverlikeEntrySmallGridData> list = new List<IRoverlikeEntrySmallGridData>();
			foreach (int configId in configIdList)
			{
				RoverlikeEntrySmallGridData item = new RoverlikeEntrySmallGridData
				{
					ConfigId = configId,
					Type = RoverRogueGainDataType.RoverRogueGainItem
				};
				list.Add(item);
			}
			bool flag = list.Count > 0;
			GenericLayout<RoverlikeEntrySmallGridItem, IRoverlikeEntrySmallGridData> itemLayout = this.ItemLayout;
			if (itemLayout != null)
			{
				itemLayout.SetActive(flag);
			}
			UUIItem item2 = base.GetItem(3);
			if (item2 != null)
			{
				item2.SetUIActive(!flag);
			}
			if (flag)
			{
				this.ItemLayout.RefreshByData(list, null, true);
			}
		}

		// Token: 0x06040489 RID: 263305 RVA: 0x01079CFC File Offset: 0x01077EFC
		public void SelectByKey(int key)
		{
			GenericLayout<RoverlikeEntrySmallGridItem, IRoverlikeEntrySmallGridData> itemLayout = this.ItemLayout;
			if (itemLayout == null)
			{
				return;
			}
			itemLayout.SelectGridProxyByKey(key, false);
		}

		// Token: 0x0604048A RID: 263306 RVA: 0x01079D15 File Offset: 0x01077F15
		public void ClearSelect()
		{
			GenericLayout<RoverlikeEntrySmallGridItem, IRoverlikeEntrySmallGridData> itemLayout = this.ItemLayout;
			if (itemLayout == null)
			{
				return;
			}
			itemLayout.DeselectCurrentGridProxy();
		}

		// Token: 0x0604048B RID: 263307 RVA: 0x01079D27 File Offset: 0x01077F27
		private RoverlikeEntrySmallGridItem CreateItemGrid()
		{
			RoverlikeEntrySmallGridItem roverlikeEntrySmallGridItem = new RoverlikeEntrySmallGridItem();
			roverlikeEntrySmallGridItem.BindOnItemClick(new Action<IRoverlikeEntrySmallGridData, int>(this.OnGridItemClick));
			return roverlikeEntrySmallGridItem;
		}

		// Token: 0x0604048C RID: 263308 RVA: 0x01079D40 File Offset: 0x01077F40
		private void OnGridItemClick(IRoverlikeEntrySmallGridData data, int key)
		{
			Action<int, int> onItemClick = this.OnItemClick;
			if (onItemClick == null)
			{
				return;
			}
			onItemClick(data.ConfigId, key);
		}

		// Token: 0x0402408D RID: 147597
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<RoverlikeEntrySmallGridItem, IRoverlikeEntrySmallGridData> ItemLayout;

		// Token: 0x0402408E RID: 147598
		[Nullable(2)]
		private Action<int, int> OnItemClick;

		// Token: 0x0200C46C RID: 50284
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x0403C764 RID: 247652
			public const int TxtNum = 0;

			// Token: 0x0403C765 RID: 247653
			public const int LayoutItem = 1;

			// Token: 0x0403C766 RID: 247654
			public const int SpoilsItem = 2;

			// Token: 0x0403C767 RID: 247655
			public const int ItemEmpty = 3;
		}
	}
}
