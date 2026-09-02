using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Inventory;

namespace CSharpScript.Game.Module.RecallQuest.Model
{
	// Token: 0x02005296 RID: 21142
	[NullableContext(1)]
	[Nullable(0)]
	public class RecallInventoryDataProxy : InventoryDataProxy
	{
		// Token: 0x060360D6 RID: 221398 RVA: 0x00D9B9FD File Offset: 0x00D99BFD
		public RecallInventoryDataProxy(RecallInventoryData data)
		{
			this.Data = data;
		}

		// Token: 0x060360D7 RID: 221399 RVA: 0x00D9BA0C File Offset: 0x00D99C0C
		public override List<ItemMainType> GetOpenIdMainTypeConfig()
		{
			HashSet<InventoryDefine.EItemMainTypeId> availableMainTypes = this.Data.GetAvailableMainTypes();
			IEnumerable<ItemMainType> enumerable = ConfigBase<InventoryConfig>.Instance.GetAllMainTypeConfig() ?? Array.Empty<ItemMainType>();
			List<ItemMainType> list = new List<ItemMainType>();
			foreach (ItemMainType item in enumerable)
			{
				if (item.BShowInInventoryView && availableMainTypes.Contains((InventoryDefine.EItemMainTypeId)item.Id))
				{
					list.Add(item);
				}
			}
			list.Sort((ItemMainType a, ItemMainType b) => a.SequenceId - b.SequenceId);
			return list;
		}

		// Token: 0x060360D8 RID: 221400 RVA: 0x00D9BAB8 File Offset: 0x00D99CB8
		public override HashSet<ItemDataBase> GetItemDataBaseByMainType(InventoryDefine.EItemMainTypeId mainType)
		{
			return this.Data.GetItemDataBaseSetByMainType(mainType);
		}

		// Token: 0x060360D9 RID: 221401 RVA: 0x00D9BAC6 File Offset: 0x00D99CC6
		public override int GetInventoryItemGridCountByMainType(InventoryDefine.EItemMainTypeId mainType)
		{
			return 0;
		}

		// Token: 0x060360DA RID: 221402 RVA: 0x00D9BAC9 File Offset: 0x00D99CC9
		public override bool SupportShowCurrency()
		{
			return false;
		}

		// Token: 0x060360DB RID: 221403 RVA: 0x00D9BACC File Offset: 0x00D99CCC
		public override int GetItemCountByConfigId(int itemConfigId, int uniqueId)
		{
			return this.Data.GetCount(itemConfigId);
		}

		// Token: 0x0401F107 RID: 127239
		private readonly RecallInventoryData Data;
	}
}
