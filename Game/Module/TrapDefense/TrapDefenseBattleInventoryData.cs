using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004D94 RID: 19860
	[NullableContext(1)]
	[Nullable(0)]
	public class TrapDefenseBattleInventoryData
	{
		// Token: 0x060336F0 RID: 210672 RVA: 0x00CDCF07 File Offset: 0x00CDB107
		public static TrapDefenseBattleInventoryData Create()
		{
			TrapDefenseBattleInventoryData trapDefenseBattleInventoryData = new TrapDefenseBattleInventoryData();
			trapDefenseBattleInventoryData.Init();
			return trapDefenseBattleInventoryData;
		}

		// Token: 0x060336F1 RID: 210673 RVA: 0x00CDCF14 File Offset: 0x00CDB114
		public int GetOwnItemTypeCount()
		{
			int num = 0;
			using (Dictionary<int, TrapDefenseBattleItemData>.ValueCollection.Enumerator enumerator = this.ItemMap.Values.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.InventoryCount > 0)
					{
						num++;
					}
				}
			}
			return num;
		}

		// Token: 0x060336F2 RID: 210674 RVA: 0x00CDCF74 File Offset: 0x00CDB174
		private void Init()
		{
			foreach (TrapDefenseItem config in ConfigBase<TrapDefenseConfig>.Instance.GetAllTrapDefenseItem())
			{
				TrapDefenseBattleItemData trapDefenseBattleItemData = TrapDefenseBattleItemData.Create(config);
				this.ItemMap.Add(trapDefenseBattleItemData.Config.Id, trapDefenseBattleItemData);
			}
		}

		// Token: 0x060336F3 RID: 210675 RVA: 0x00CDCFDC File Offset: 0x00CDB1DC
		[NullableContext(2)]
		public TrapDefenseBattleItemData GetItemData(int itemId)
		{
			TrapDefenseBattleItemData result;
			this.ItemMap.TryGetValue(itemId, out result);
			return result;
		}

		// Token: 0x060336F4 RID: 210676 RVA: 0x00CDCFFC File Offset: 0x00CDB1FC
		public void UpdateItemData(IReadOnlyList<TrapDefenseItemPbData> itemDataList)
		{
			foreach (TrapDefenseItemPbData trapDefenseItemPbData in itemDataList)
			{
				TrapDefenseBattleItemData trapDefenseBattleItemData;
				if (!this.ItemMap.TryGetValue(trapDefenseItemPbData.ConfigId, out trapDefenseBattleItemData))
				{
					trapDefenseBattleItemData = TrapDefenseBattleItemData.Create(ConfigBase<TrapDefenseConfig>.Instance.GetTrapDefenseItemConfigById(trapDefenseItemPbData.ConfigId).Value);
					this.ItemMap.Add(trapDefenseItemPbData.ConfigId, trapDefenseBattleItemData);
				}
				trapDefenseBattleItemData.UpdateByServerData(trapDefenseItemPbData.CarryCount, trapDefenseItemPbData.CarryLimit);
			}
		}

		// Token: 0x0401DCC6 RID: 122054
		public Dictionary<int, TrapDefenseBattleItemData> ItemMap = new Dictionary<int, TrapDefenseBattleItemData>();
	}
}
