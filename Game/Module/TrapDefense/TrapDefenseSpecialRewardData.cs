using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Inventory;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004D98 RID: 19864
	[NullableContext(1)]
	[Nullable(0)]
	public class TrapDefenseSpecialRewardData
	{
		// Token: 0x0603371D RID: 210717 RVA: 0x00CDDBD6 File Offset: 0x00CDBDD6
		public static TrapDefenseSpecialRewardData Create(TrapDefenseSpecialReward config)
		{
			TrapDefenseSpecialRewardData trapDefenseSpecialRewardData = new TrapDefenseSpecialRewardData();
			trapDefenseSpecialRewardData.Config = config;
			trapDefenseSpecialRewardData.Init();
			return trapDefenseSpecialRewardData;
		}

		// Token: 0x0603371E RID: 210718 RVA: 0x00CDDBEA File Offset: 0x00CDBDEA
		public void UpdateByServerData(TrapDefenseRewardInfo serverData)
		{
			this.State = TrapDefenseDefine.trapDefenseRewardServerState2ClientState[serverData.TaskInfo.Status];
			this.CurrentProgress = serverData.TaskInfo.Current;
			this.TotalProgress = serverData.TaskInfo.Target;
		}

		// Token: 0x0603371F RID: 210719 RVA: 0x00CDDC29 File Offset: 0x00CDBE29
		private void Init()
		{
			this.Id = this.Config.Id;
			this.Desc = this.Config.Desc;
			this.InitRewardItemList();
		}

		// Token: 0x06033720 RID: 210720 RVA: 0x00CDDC54 File Offset: 0x00CDBE54
		private void InitRewardItemList()
		{
			this.ItemList.Clear();
			DropPackage? config = ConfigDropPackageById.GetConfig(this.Config.RewardId, true);
			if (config == null)
			{
				return;
			}
			foreach (DicIntInt dicIntInt in config.Value.DropPreviewIter())
			{
				int key = dicIntInt.Key;
				int value = dicIntInt.Value;
				this.ItemList.Add(new TItem
				{
					ItemData = new InventoryDefine.GetItemData(key, 0),
					Count = value
				});
			}
		}

		// Token: 0x0401DCDA RID: 122074
		private TrapDefenseSpecialReward Config;

		// Token: 0x0401DCDB RID: 122075
		public int Id;

		// Token: 0x0401DCDC RID: 122076
		public string Desc = "";

		// Token: 0x0401DCDD RID: 122077
		public List<TItem> ItemList = new List<TItem>();

		// Token: 0x0401DCDE RID: 122078
		public int CurrentProgress;

		// Token: 0x0401DCDF RID: 122079
		public int TotalProgress;

		// Token: 0x0401DCE0 RID: 122080
		public ETrapDefenseRewardState State = ETrapDefenseRewardState.InProgress;
	}
}
