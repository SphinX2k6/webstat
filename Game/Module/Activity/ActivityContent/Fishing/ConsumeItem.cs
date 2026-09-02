using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x020067CF RID: 26575
	internal class ConsumeItem : UiPanelBase
	{
		// Token: 0x060424BE RID: 271550 RVA: 0x01101574 File Offset: 0x010FF774
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x060424BF RID: 271551 RVA: 0x0110163B File Offset: 0x010FF83B
		private void OnClick()
		{
			ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(this.ItemId, true, null);
		}

		// Token: 0x060424C0 RID: 271552 RVA: 0x0110164F File Offset: 0x010FF84F
		protected override void OnStart()
		{
			Singleton<EventSystem>.Instance.Add<IProto_NormalItem, int, int>(EEventName.OnCommonItemCountRefresh, new Action<IProto_NormalItem, int, int>(this.RefreshCount));
		}

		// Token: 0x060424C1 RID: 271553 RVA: 0x0110166D File Offset: 0x010FF86D
		protected override void OnBeforeDestroy()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnCommonItemCountRefresh, new Action<IProto_NormalItem, int, int>(this.RefreshCount));
		}

		// Token: 0x060424C2 RID: 271554 RVA: 0x0110168B File Offset: 0x010FF88B
		[NullableContext(1)]
		private void RefreshCount(IProto_NormalItem normalItem, int i, int arg3)
		{
			this.Refresh(this.ItemId);
		}

		// Token: 0x060424C3 RID: 271555 RVA: 0x0110169C File Offset: 0x010FF89C
		public void Refresh(int itemId)
		{
			this.ItemId = itemId;
			int itemCountByConfigId = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(itemId, 0);
			UUIText text = base.GetText(1);
			if (text != null)
			{
				text.SetText(itemCountByConfigId.ToString(), true);
			}
			base.SetItemIcon(base.GetTexture(0), itemId, null, null);
		}

		// Token: 0x04024E8D RID: 151181
		private int ItemId;

		// Token: 0x0200C81A RID: 51226
		private class EConsumeItem
		{
			// Token: 0x0403D946 RID: 252230
			public const int Icon = 0;

			// Token: 0x0403D947 RID: 252231
			public const int Text = 1;

			// Token: 0x0403D948 RID: 252232
			public const int Btn = 2;
		}
	}
}
