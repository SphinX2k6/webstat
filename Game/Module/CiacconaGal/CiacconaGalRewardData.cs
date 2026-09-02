using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Inventory;

namespace CSharpScript.Game.Module.CiacconaGal
{
	// Token: 0x02005EB7 RID: 24247
	[NullableContext(1)]
	[Nullable(0)]
	public class CiacconaGalRewardData
	{
		// Token: 0x0603CF17 RID: 249623 RVA: 0x00F7A9B4 File Offset: 0x00F78BB4
		public CiacconaGalRewardData(CiacconaActivityReward config)
		{
			this.Config = config;
		}

		// Token: 0x170099BC RID: 39356
		// (get) Token: 0x0603CF18 RID: 249624 RVA: 0x00F7A9C4 File Offset: 0x00F78BC4
		public int Id
		{
			get
			{
				return this.Config.Id;
			}
		}

		// Token: 0x170099BD RID: 39357
		// (get) Token: 0x0603CF19 RID: 249625 RVA: 0x00F7A9E0 File Offset: 0x00F78BE0
		public int ActivityId
		{
			get
			{
				return this.Config.ActivityId;
			}
		}

		// Token: 0x170099BE RID: 39358
		// (get) Token: 0x0603CF1A RID: 249626 RVA: 0x00F7A9FC File Offset: 0x00F78BFC
		public int RewardId
		{
			get
			{
				return this.Config.RewardId;
			}
		}

		// Token: 0x170099BF RID: 39359
		// (get) Token: 0x0603CF1B RID: 249627 RVA: 0x00F7AA18 File Offset: 0x00F78C18
		public TItem[] RewardItemDataList
		{
			get
			{
				List<TItem> list = new List<TItem>();
				DropPackage? config = ConfigDropPackageById.GetConfig(this.RewardId, true);
				if (config == null)
				{
					return list.ToArray();
				}
				foreach (KeyValuePair<int, int> keyValuePair in config.Value.DropPreview())
				{
					int num;
					int num2;
					keyValuePair.Deconstruct(out num, out num2);
					int itemId = num;
					int count = num2;
					list.Add(new TItem
					{
						ItemData = new InventoryDefine.GetItemData(itemId, 0),
						Count = count
					});
				}
				return list.ToArray();
			}
		}

		// Token: 0x170099C0 RID: 39360
		// (get) Token: 0x0603CF1C RID: 249628 RVA: 0x00F7AAD4 File Offset: 0x00F78CD4
		public string Title
		{
			get
			{
				return this.Config.Title;
			}
		}

		// Token: 0x170099C1 RID: 39361
		// (get) Token: 0x0603CF1D RID: 249629 RVA: 0x00F7AAF0 File Offset: 0x00F78CF0
		public string Desc
		{
			get
			{
				return this.Config.Desc;
			}
		}

		// Token: 0x170099C2 RID: 39362
		// (get) Token: 0x0603CF1E RID: 249630 RVA: 0x00F7AB0B File Offset: 0x00F78D0B
		public bool CanReceive
		{
			get
			{
				return this.CanReceiveInternal;
			}
		}

		// Token: 0x170099C3 RID: 39363
		// (get) Token: 0x0603CF1F RID: 249631 RVA: 0x00F7AB13 File Offset: 0x00F78D13
		public bool IsReceived
		{
			get
			{
				return this.IsReceivedInternal;
			}
		}

		// Token: 0x0603CF20 RID: 249632 RVA: 0x00F7AB1B File Offset: 0x00F78D1B
		public void UpdateByServerData(CiacconaScheduleRewardPbData data)
		{
			this.CanReceiveInternal = data.CanReward;
			this.IsReceivedInternal = data.TakeReward;
		}

		// Token: 0x04022367 RID: 140135
		private bool IsReceivedInternal;

		// Token: 0x04022368 RID: 140136
		private bool CanReceiveInternal;

		// Token: 0x04022369 RID: 140137
		private readonly CiacconaActivityReward Config;
	}
}
