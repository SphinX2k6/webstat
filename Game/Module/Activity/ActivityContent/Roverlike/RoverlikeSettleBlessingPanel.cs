using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x02006404 RID: 25604
	public class RoverlikeSettleBlessingPanel : UiPanelBase, IRoverlikeSettleSelectablePanel
	{
		// Token: 0x0604047C RID: 263292 RVA: 0x010799B0 File Offset: 0x01077BB0
		[NullableContext(1)]
		public void BindOnItemClick(Action<int> callback)
		{
			this.OnItemClick = callback;
		}

		// Token: 0x0604047D RID: 263293 RVA: 0x010799BC File Offset: 0x01077BBC
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

		// Token: 0x0604047E RID: 263294 RVA: 0x01079A67 File Offset: 0x01077C67
		protected override void OnStart()
		{
			this.BlessingLayout = new GenericLayout<RoverlikeBlessingSuitBlessItem, int>(base.GetGridLayout(1), new Func<RoverlikeBlessingSuitBlessItem>(this.CreateBlessingItem), null, false, true);
		}

		// Token: 0x0604047F RID: 263295 RVA: 0x01079A8C File Offset: 0x01077C8C
		[NullableContext(1)]
		public void Refresh(List<int> configIdList)
		{
			base.GetText(0).SetText(configIdList.Count.ToString(), true);
			bool flag = configIdList.Count > 0;
			GenericLayout<RoverlikeBlessingSuitBlessItem, int> blessingLayout = this.BlessingLayout;
			if (blessingLayout != null)
			{
				blessingLayout.SetActive(flag);
			}
			UUIItem item = base.GetItem(3);
			if (item != null)
			{
				item.SetUIActive(!flag);
			}
			if (flag)
			{
				this.BlessingLayout.RefreshByData(configIdList, null, true);
			}
		}

		// Token: 0x06040480 RID: 263296 RVA: 0x01079AF7 File Offset: 0x01077CF7
		public void SelectByKey(int key)
		{
			GenericLayout<RoverlikeBlessingSuitBlessItem, int> blessingLayout = this.BlessingLayout;
			if (blessingLayout == null)
			{
				return;
			}
			blessingLayout.SelectGridProxyByKey(key, false);
		}

		// Token: 0x06040481 RID: 263297 RVA: 0x01079B10 File Offset: 0x01077D10
		public void ClearSelect()
		{
			GenericLayout<RoverlikeBlessingSuitBlessItem, int> blessingLayout = this.BlessingLayout;
			if (blessingLayout == null)
			{
				return;
			}
			blessingLayout.DeselectCurrentGridProxy();
		}

		// Token: 0x06040482 RID: 263298 RVA: 0x01079B22 File Offset: 0x01077D22
		[NullableContext(1)]
		private RoverlikeBlessingSuitBlessItem CreateBlessingItem()
		{
			RoverlikeBlessingSuitBlessItem roverlikeBlessingSuitBlessItem = new RoverlikeBlessingSuitBlessItem();
			roverlikeBlessingSuitBlessItem.BindOnItemClick(new Action<int>(this.OnGridItemClick));
			return roverlikeBlessingSuitBlessItem;
		}

		// Token: 0x06040483 RID: 263299 RVA: 0x01079B3B File Offset: 0x01077D3B
		private void OnGridItemClick(int blessId)
		{
			Action<int> onItemClick = this.OnItemClick;
			if (onItemClick == null)
			{
				return;
			}
			onItemClick(blessId);
		}

		// Token: 0x0402408B RID: 147595
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericLayout<RoverlikeBlessingSuitBlessItem, int> BlessingLayout;

		// Token: 0x0402408C RID: 147596
		[Nullable(2)]
		private Action<int> OnItemClick;

		// Token: 0x0200C46B RID: 50283
		private class EComponents
		{
			// Token: 0x0403C760 RID: 247648
			public const int TxtNum = 0;

			// Token: 0x0403C761 RID: 247649
			public const int LayoutBlessing = 1;

			// Token: 0x0403C762 RID: 247650
			public const int UiItemBlessingItem = 2;

			// Token: 0x0403C763 RID: 247651
			public const int ItemEmpty = 3;
		}
	}
}
