using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x02006826 RID: 26662
	[NullableContext(1)]
	[Nullable(0)]
	public class FishingNormalTechCostItem : GridProxyAbstract<int>
	{
		// Token: 0x060427A9 RID: 272297 RVA: 0x0110F12C File Offset: 0x0110D32C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickBtn));
			this.BtnBindInfo = list2;
		}

		// Token: 0x060427AA RID: 272298 RVA: 0x0110F214 File Offset: 0x0110D414
		protected override void OnStart()
		{
			this.AddEventListener();
		}

		// Token: 0x060427AB RID: 272299 RVA: 0x0110F21C File Offset: 0x0110D41C
		protected override void OnBeforeDestroy()
		{
			this.RemoveEventListener();
		}

		// Token: 0x060427AC RID: 272300 RVA: 0x0110F224 File Offset: 0x0110D424
		private void AddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<IReadOnlyList<IProto_NormalItem>>(EEventName.OnAddCommonItemList, new Action<IReadOnlyList<IProto_NormalItem>>(this.OnAddCommonItemList));
			Singleton<EventSystem>.Instance.Add<IReadOnlyList<int>>(EEventName.OnRemoveCommonItem, new Action<IReadOnlyList<int>>(this.OnRemoveCommonItem));
			Singleton<EventSystem>.Instance.Add<IProto_NormalItem, int, int>(EEventName.OnCommonItemCountRefresh, new Action<IProto_NormalItem, int, int>(this.OnCommonItemCountRefresh));
		}

		// Token: 0x060427AD RID: 272301 RVA: 0x0110F288 File Offset: 0x0110D488
		private void RemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnAddCommonItemList, new Action<IReadOnlyList<IProto_NormalItem>>(this.OnAddCommonItemList));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnRemoveCommonItem, new Action<IReadOnlyList<int>>(this.OnRemoveCommonItem));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnCommonItemCountRefresh, new Action<IProto_NormalItem, int, int>(this.OnCommonItemCountRefresh));
		}

		// Token: 0x060427AE RID: 272302 RVA: 0x0110F2EC File Offset: 0x0110D4EC
		private void OnAddCommonItemList(IReadOnlyList<IProto_NormalItem> normalItemList)
		{
			foreach (IProto_NormalItem proto_NormalItem in normalItemList)
			{
				if (this.ItemId == proto_NormalItem.Id)
				{
					this.RefreshCountText();
					break;
				}
			}
		}

		// Token: 0x060427AF RID: 272303 RVA: 0x0110F344 File Offset: 0x0110D544
		private void OnRemoveCommonItem(IReadOnlyList<int> configId)
		{
			if (!configId.Contains(this.ItemId))
			{
				return;
			}
			this.RefreshCountText();
		}

		// Token: 0x060427B0 RID: 272304 RVA: 0x0110F35B File Offset: 0x0110D55B
		private void OnCommonItemCountRefresh(IProto_NormalItem normalItem, int count, int lastCount)
		{
			if (this.ItemId != normalItem.Id)
			{
				return;
			}
			this.RefreshCountText();
		}

		// Token: 0x060427B1 RID: 272305 RVA: 0x0110F374 File Offset: 0x0110D574
		public override void Refresh(int data, bool isSelected, int gridIndex)
		{
			this.ItemId = data;
			CSharpScript.Game.Module.Inventory.ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(data);
			if (itemConfigData == null)
			{
				return;
			}
			base.SetTextureByPath(itemConfigData.IconSmall, base.GetTexture(2), null, null);
			int itemCountByConfigId = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(this.ItemId, 0);
			UUIText text = base.GetText(3);
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
			defaultInterpolatedStringHandler.AppendFormatted<int>(itemCountByConfigId);
			text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
		}

		// Token: 0x060427B2 RID: 272306 RVA: 0x0110F3EC File Offset: 0x0110D5EC
		private void RefreshCountText()
		{
			int itemCountByConfigId = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(this.ItemId, 0);
			UUIText text = base.GetText(3);
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
			defaultInterpolatedStringHandler.AppendFormatted<int>(itemCountByConfigId);
			text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
		}

		// Token: 0x060427B3 RID: 272307 RVA: 0x0110F430 File Offset: 0x0110D630
		private void OnClickBtn()
		{
			if (this.ItemId != 0)
			{
				ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(this.ItemId, true, null);
			}
		}

		// Token: 0x04025012 RID: 151570
		private int ItemId;

		// Token: 0x0200C863 RID: 51299
		[NullableContext(0)]
		private class EComponentDefine
		{
			// Token: 0x0403DAC0 RID: 252608
			public const int Btn = 0;

			// Token: 0x0403DAC1 RID: 252609
			public const int TipsText = 1;

			// Token: 0x0403DAC2 RID: 252610
			public const int IconTexture = 2;

			// Token: 0x0403DAC3 RID: 252611
			public const int CostText = 3;
		}
	}
}
