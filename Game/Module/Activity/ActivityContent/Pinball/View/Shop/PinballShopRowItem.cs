using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Shop
{
	// Token: 0x020065B1 RID: 26033
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1,
		1
	})]
	public class PinballShopRowItem : GridProxyAbstract<List<PinballShopItemProxy>>
	{
		// Token: 0x060410CE RID: 266446 RVA: 0x010B0F14 File Offset: 0x010AF114
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>();
		}

		// Token: 0x060410CF RID: 266447 RVA: 0x010B0F88 File Offset: 0x010AF188
		protected override void OnStart()
		{
			this.PanelItem = base.GetItem(0);
			this.TemplateItem = base.GetItem(1);
			UUIItem panelItem = this.PanelItem;
			if (panelItem != null && panelItem.IsValid())
			{
				UUIItem templateItem = this.TemplateItem;
				if (templateItem != null && templateItem.IsValid())
				{
					this.TemplateItem.SetUIParent(this.PanelItem, false);
					this.TemplateItem.SetUIActive(false);
				}
			}
		}

		// Token: 0x060410D0 RID: 266448 RVA: 0x010B0FF8 File Offset: 0x010AF1F8
		public override void Refresh(List<PinballShopItemProxy> data, bool isSelected, int gridIndex)
		{
			base.GridIndex = gridIndex;
			int num = Math.Min(data.Count, 5);
			this.EnsureSlots(num);
			this.EnsureSlotProxiesCreated(num);
			for (int i = 0; i < num; i++)
			{
				UUIItem uuiitem = this.ItemSlots[i];
				PinballShopGridItem pinballShopGridItem = this.SlotProxies[i];
				PinballShopItemProxy data2 = data[i];
				if (uuiitem != null && pinballShopGridItem != null)
				{
					uuiitem.SetUIActive(true);
					pinballShopGridItem.Refresh(data2, false, gridIndex * 5 + i);
				}
			}
			for (int j = num; j < this.ItemSlots.Count; j++)
			{
				UUIItem uuiitem2 = this.ItemSlots[j];
				if (uuiitem2 != null)
				{
					uuiitem2.SetUIActive(false);
				}
			}
		}

		// Token: 0x060410D1 RID: 266449 RVA: 0x010B10A4 File Offset: 0x010AF2A4
		public override void Clear()
		{
		}

		// Token: 0x060410D2 RID: 266450 RVA: 0x010B10A6 File Offset: 0x010AF2A6
		public override void OnSelected(bool fireEvent)
		{
		}

		// Token: 0x060410D3 RID: 266451 RVA: 0x010B10A8 File Offset: 0x010AF2A8
		public override void OnDeselected(bool fireEvent)
		{
		}

		// Token: 0x060410D4 RID: 266452 RVA: 0x010B10AA File Offset: 0x010AF2AA
		public override object GetKey(List<PinballShopItemProxy> data, int gridIndex)
		{
			return gridIndex;
		}

		// Token: 0x060410D5 RID: 266453 RVA: 0x010B10B4 File Offset: 0x010AF2B4
		private void EnsureSlots(int needCount)
		{
			int num = Math.Min(needCount, 5);
			UUIItem panelItem = this.PanelItem;
			if (panelItem != null && panelItem.IsValid())
			{
				UUIItem templateItem = this.TemplateItem;
				if (templateItem != null && templateItem.IsValid())
				{
					if (num <= 0)
					{
						this.TemplateItem.SetUIActive(false);
						return;
					}
					if (this.ItemSlots.Count == 0)
					{
						this.ItemSlots.Add(this.TemplateItem);
					}
					int num2 = num - this.ItemSlots.Count;
					for (int i = 0; i < num2; i++)
					{
						UUIItem uuiitem = Singleton<LguiUtil>.Instance.CopyItem(this.TemplateItem, this.PanelItem);
						uuiitem.SetUIActive(false);
						this.ItemSlots.Add(uuiitem);
					}
					int num3 = 5 - this.SlotProxies.Count;
					for (int j = 0; j < num3; j++)
					{
						this.SlotProxies.Add(null);
					}
					return;
				}
			}
		}

		// Token: 0x060410D6 RID: 266454 RVA: 0x010B1198 File Offset: 0x010AF398
		private void EnsureSlotProxiesCreated(int needCount)
		{
			for (int i = 0; i < needCount; i++)
			{
				if (this.SlotProxies[i] == null)
				{
					UUIItem uuiitem = this.ItemSlots[i];
					AActor aactor = (uuiitem != null) ? uuiitem.GetOwner() : null;
					if (aactor != null)
					{
						PinballShopGridItem pinballShopGridItem = new PinballShopGridItem();
						pinballShopGridItem.CreateThenShowByActor(aactor, null);
						this.SlotProxies[i] = pinballShopGridItem;
					}
				}
			}
		}

		// Token: 0x04024763 RID: 149347
		private const int MAX_ITEMS_PER_ROW = 5;

		// Token: 0x04024764 RID: 149348
		[Nullable(2)]
		private UUIItem PanelItem;

		// Token: 0x04024765 RID: 149349
		[Nullable(2)]
		private UUIItem TemplateItem;

		// Token: 0x04024766 RID: 149350
		private readonly List<UUIItem> ItemSlots = new List<UUIItem>();

		// Token: 0x04024767 RID: 149351
		[Nullable(new byte[]
		{
			1,
			2
		})]
		private readonly List<PinballShopGridItem> SlotProxies = new List<PinballShopGridItem>();

		// Token: 0x0200C5AE RID: 50606
		[NullableContext(0)]
		private enum ERowComponent
		{
			// Token: 0x0403CD86 RID: 249222
			ItemPanel,
			// Token: 0x0403CD87 RID: 249223
			ShopItem
		}
	}
}
