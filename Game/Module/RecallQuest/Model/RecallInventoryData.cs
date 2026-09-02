using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Inventory;

namespace CSharpScript.Game.Module.RecallQuest.Model
{
	// Token: 0x02005295 RID: 21141
	[NullableContext(1)]
	[Nullable(0)]
	public class RecallInventoryData
	{
		// Token: 0x060360CD RID: 221389 RVA: 0x00D9B7EC File Offset: 0x00D999EC
		public void InitFromFullSnapshot([TupleElementNames(new string[]
		{
			"ItemId",
			"Count"
		})] [Nullable(new byte[]
		{
			1,
			0
		})] IReadOnlyList<ValueTuple<int, int>> items)
		{
			this.VirtualItemMap.Clear();
			this.CountMap.Clear();
			foreach (ValueTuple<int, int> valueTuple in items)
			{
				this.SetItem(valueTuple.Item1, valueTuple.Item2);
			}
		}

		// Token: 0x060360CE RID: 221390 RVA: 0x00D9B858 File Offset: 0x00D99A58
		public void SetItem(int itemId, int count)
		{
			CommonItemData value = new CommonItemData(itemId, 0, count, InventoryDefine.EItemDataType.CommonItem, null);
			this.VirtualItemMap[itemId] = value;
			this.CountMap[itemId] = count;
		}

		// Token: 0x060360CF RID: 221391 RVA: 0x00D9B892 File Offset: 0x00D99A92
		public void RemoveItem(int itemId)
		{
			this.VirtualItemMap.Remove(itemId);
			this.CountMap.Remove(itemId);
		}

		// Token: 0x060360D0 RID: 221392 RVA: 0x00D9B8AE File Offset: 0x00D99AAE
		public void Clear()
		{
			this.VirtualItemMap.Clear();
			this.CountMap.Clear();
		}

		// Token: 0x060360D1 RID: 221393 RVA: 0x00D9B8C8 File Offset: 0x00D99AC8
		public int GetCount(int configId)
		{
			int result;
			if (!this.CountMap.TryGetValue(configId, out result))
			{
				return 0;
			}
			return result;
		}

		// Token: 0x060360D2 RID: 221394 RVA: 0x00D9B8E8 File Offset: 0x00D99AE8
		public bool IsEmpty()
		{
			return this.VirtualItemMap.Count == 0;
		}

		// Token: 0x060360D3 RID: 221395 RVA: 0x00D9B8F8 File Offset: 0x00D99AF8
		public HashSet<ItemDataBase> GetItemDataBaseSetByMainType(InventoryDefine.EItemMainTypeId mainType)
		{
			HashSet<ItemDataBase> hashSet = new HashSet<ItemDataBase>();
			foreach (CommonItemData commonItemData in this.VirtualItemMap.Values)
			{
				InventoryDefine.EItemMainTypeId? mainType2 = commonItemData.GetMainType();
				if (mainType2.GetValueOrDefault() == mainType & mainType2 != null)
				{
					hashSet.Add(commonItemData);
				}
			}
			return hashSet;
		}

		// Token: 0x060360D4 RID: 221396 RVA: 0x00D9B978 File Offset: 0x00D99B78
		public HashSet<InventoryDefine.EItemMainTypeId> GetAvailableMainTypes()
		{
			if (this.OpenIdMainTypeConfigCache.Count > 0)
			{
				return this.OpenIdMainTypeConfigCache;
			}
			this.OpenIdMainTypeConfigCache.Add(InventoryDefine.EItemMainTypeId.Common);
			this.OpenIdMainTypeConfigCache.Add(InventoryDefine.EItemMainTypeId.Material);
			this.OpenIdMainTypeConfigCache.Add(InventoryDefine.EItemMainTypeId.Mission);
			this.OpenIdMainTypeConfigCache.Add(InventoryDefine.EItemMainTypeId.Special);
			return this.OpenIdMainTypeConfigCache;
		}

		// Token: 0x0401F104 RID: 127236
		private readonly Dictionary<int, CommonItemData> VirtualItemMap = new Dictionary<int, CommonItemData>();

		// Token: 0x0401F105 RID: 127237
		private readonly Dictionary<int, int> CountMap = new Dictionary<int, int>();

		// Token: 0x0401F106 RID: 127238
		private readonly HashSet<InventoryDefine.EItemMainTypeId> OpenIdMainTypeConfigCache = new HashSet<InventoryDefine.EItemMainTypeId>();
	}
}
