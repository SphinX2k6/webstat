using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Inventory;

namespace CSharpScript.Game.Module.InstanceDungeon.ExchangeReward
{
	// Token: 0x02005C01 RID: 23553
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class ExchangeRewardModel : ModelBase<ExchangeRewardModel>
	{
		// Token: 0x0603B975 RID: 244085 RVA: 0x00F1B15F File Offset: 0x00F1935F
		protected override bool OnInit()
		{
			return true;
		}

		// Token: 0x0603B976 RID: 244086 RVA: 0x00F1B164 File Offset: 0x00F19364
		public void Phrase(ExchangeRewardInfoResponse message)
		{
			this.ExchangeRewardMap.Clear();
			this.ExchangeShareMap.Clear();
			foreach (KeyValuePair<int, int> keyValuePair in message.SharedDict)
			{
				ExchangeShareData exchangeShareData = new ExchangeShareData();
				exchangeShareData.Phrase(keyValuePair.Key, keyValuePair.Value);
				this.ExchangeShareMap.Add(exchangeShareData.GetId(), exchangeShareData);
			}
			foreach (KeyValuePair<int, int> keyValuePair2 in message.ExchangeRewardDict)
			{
				ExchangeRewardData exchangeRewardData = new ExchangeRewardData();
				exchangeRewardData.Phrase(keyValuePair2.Key, keyValuePair2.Value);
				this.ExchangeRewardMap.Add(exchangeRewardData.GetId(), exchangeRewardData);
			}
		}

		// Token: 0x0603B977 RID: 244087 RVA: 0x00F1B254 File Offset: 0x00F19454
		public void OnExchangeRewardNotify(ExchangeRewardInfoNotify message)
		{
			ExchangeRewardData exchangeRewardData;
			if (!this.ExchangeRewardMap.TryGetValue(message.ExchangeRewardId, out exchangeRewardData))
			{
				exchangeRewardData = new ExchangeRewardData();
				this.ExchangeRewardMap.Add(message.ExchangeRewardId, exchangeRewardData);
			}
			exchangeRewardData.Phrase(message.ExchangeRewardId, message.Count);
		}

		// Token: 0x0603B978 RID: 244088 RVA: 0x00F1B2A0 File Offset: 0x00F194A0
		public void OnShareInfoNotify(ExchangeSharedInfoNotify message)
		{
			foreach (KeyValuePair<int, int> keyValuePair in message.SharedUpdateDict)
			{
				int key = keyValuePair.Key;
				ExchangeShareData exchangeShareData;
				if (!this.ExchangeShareMap.TryGetValue(key, out exchangeShareData))
				{
					exchangeShareData = new ExchangeShareData();
					this.ExchangeShareMap.Add(key, exchangeShareData);
				}
				exchangeShareData.Phrase(key, keyValuePair.Value);
			}
		}

		// Token: 0x0603B979 RID: 244089 RVA: 0x00F1B320 File Offset: 0x00F19520
		public bool GetInstanceDungeonIfCanExchange(int instanceDungeonId)
		{
			int rewardId = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(instanceDungeonId).Value.RewardId;
			if (rewardId == 0)
			{
				return true;
			}
			int? exchangeShareId = ConfigBase<ExchangeRewardConfig>.Instance.GetExchangeShareId(rewardId);
			int? num = new int?(0);
			int num2;
			if (exchangeShareId != null && exchangeShareId.GetValueOrDefault() != 0)
			{
				num2 = ConfigBase<ExchangeRewardConfig>.Instance.GetShareMaxCount(exchangeShareId.Value);
				ExchangeShareData exchangeShareData;
				if (this.ExchangeShareMap.TryGetValue(exchangeShareId.Value, out exchangeShareData))
				{
					num = new int?(exchangeShareData.GetCount());
				}
			}
			else
			{
				num2 = ConfigBase<ExchangeRewardConfig>.Instance.GetExchangeRewardMaxCount(rewardId);
				ExchangeRewardData exchangeRewardData;
				if (this.ExchangeRewardMap.TryGetValue(rewardId, out exchangeRewardData))
				{
					num = new int?(exchangeRewardData.GetCount());
				}
			}
			return num2 == 0 || num.Value < num2;
		}

		// Token: 0x0603B97A RID: 244090 RVA: 0x00F1B3EC File Offset: 0x00F195EC
		public bool GetRewardIfCanExchange(int rewardId)
		{
			int? exchangeShareId = ConfigBase<ExchangeRewardConfig>.Instance.GetExchangeShareId(rewardId);
			int? num = new int?(0);
			int num2;
			if (exchangeShareId != null && exchangeShareId.GetValueOrDefault() != 0)
			{
				num2 = ConfigBase<ExchangeRewardConfig>.Instance.GetShareMaxCount(exchangeShareId.Value);
				ExchangeShareData exchangeShareData;
				if (this.ExchangeShareMap.TryGetValue(exchangeShareId.Value, out exchangeShareData))
				{
					num = new int?(exchangeShareData.GetCount());
				}
			}
			else
			{
				num2 = ConfigBase<ExchangeRewardConfig>.Instance.GetExchangeRewardMaxCount(rewardId);
				ExchangeRewardData exchangeRewardData;
				if (this.ExchangeRewardMap.TryGetValue(rewardId, out exchangeRewardData))
				{
					num = new int?(exchangeRewardData.GetCount());
				}
			}
			return num2 == 0 || num.Value < num2;
		}

		// Token: 0x0603B97B RID: 244091 RVA: 0x00F1B494 File Offset: 0x00F19694
		public int GetExchangeRewardShareCount(int shareId)
		{
			ExchangeShareData exchangeShareData;
			if (this.ExchangeShareMap.TryGetValue(shareId, out exchangeShareData))
			{
				return exchangeShareData.GetCount();
			}
			return 0;
		}

		// Token: 0x0603B97C RID: 244092 RVA: 0x00F1B4BC File Offset: 0x00F196BC
		[NullableContext(2)]
		public List<TItem> GetExchangeNormalConsume(int instanceDungeonId)
		{
			int rewardId = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(instanceDungeonId).Value.RewardId;
			if (rewardId == 0)
			{
				return null;
			}
			Dictionary<int, int> exchangeCost = ConfigBase<ExchangeRewardConfig>.Instance.GetExchangeCost(rewardId);
			List<TItem> list = new List<TItem>();
			foreach (KeyValuePair<int, int> keyValuePair in exchangeCost)
			{
				int key = keyValuePair.Key;
				int value = keyValuePair.Value;
				TItem item = new TItem(new InventoryDefine.GetItemData(key, 0), value);
				list.Add(item);
			}
			return list;
		}

		// Token: 0x0603B97D RID: 244093 RVA: 0x00F1B564 File Offset: 0x00F19764
		public bool IsFinishInstance(int instanceId)
		{
			int? instanceFirstRewardId = ConfigBase<InstanceDungeonConfig>.Instance.GetInstanceFirstRewardId(instanceId);
			bool flag = (instanceFirstRewardId ?? 0) == 0;
			if (flag)
			{
				return false;
			}
			int exchangeRewardMaxCount = ConfigBase<ExchangeRewardConfig>.Instance.GetExchangeRewardMaxCount(instanceFirstRewardId.Value);
			ExchangeRewardData exchangeRewardData;
			int? num = this.ExchangeRewardMap.TryGetValue(instanceFirstRewardId.Value, out exchangeRewardData) ? new int?(exchangeRewardData.GetCount()) : null;
			return exchangeRewardMaxCount != 0 && num != null && num.Value >= exchangeRewardMaxCount;
		}

		// Token: 0x0603B97E RID: 244094 RVA: 0x00F1B5F8 File Offset: 0x00F197F8
		public bool IsFinishInstanceCompatible(int instanceId)
		{
			InstanceDungeon? instanceDungeon;
			int? num = (ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(instanceId) != null) ? new int?(instanceDungeon.GetValueOrDefault().RewardId) : null;
			bool flag = (num ?? 0) == 0;
			if (flag)
			{
				return false;
			}
			if (ConfigBase<ExchangeRewardConfig>.Instance.GetExchangeRewardMaxCount(num.Value) != 1)
			{
				return false;
			}
			int? num2 = null;
			ExchangeRewardData exchangeRewardData;
			if (this.ExchangeRewardMap.TryGetValue(num.Value, out exchangeRewardData))
			{
				num2 = new int?(exchangeRewardData.GetCount());
			}
			return num2 != null && num2.Value >= 1;
		}

		// Token: 0x040218A4 RID: 137380
		public const int POWER_DISCOUNT_HELP_ID = 26;

		// Token: 0x040218A5 RID: 137381
		private readonly Dictionary<int, ExchangeRewardData> ExchangeRewardMap = new Dictionary<int, ExchangeRewardData>();

		// Token: 0x040218A6 RID: 137382
		private readonly Dictionary<int, ExchangeShareData> ExchangeShareMap = new Dictionary<int, ExchangeShareData>();
	}
}
