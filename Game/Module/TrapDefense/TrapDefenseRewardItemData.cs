using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Inventory;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004D97 RID: 19863
	[NullableContext(1)]
	[Nullable(0)]
	public class TrapDefenseRewardItemData
	{
		// Token: 0x06033717 RID: 210711 RVA: 0x00CDD94D File Offset: 0x00CDBB4D
		public static TrapDefenseRewardItemData Create(TrapDefenseReward config)
		{
			TrapDefenseRewardItemData trapDefenseRewardItemData = new TrapDefenseRewardItemData();
			trapDefenseRewardItemData.Config = new TrapDefenseReward?(config);
			trapDefenseRewardItemData.Id = config.Id;
			trapDefenseRewardItemData.Init();
			return trapDefenseRewardItemData;
		}

		// Token: 0x06033718 RID: 210712 RVA: 0x00CDD974 File Offset: 0x00CDBB74
		public void UpdateByServerData(TrapDefenseRewardInfo serverData)
		{
			ConditionTask taskInfo = serverData.TaskInfo;
			int? num = (taskInfo != null) ? new int?(taskInfo.Id) : null;
			int id = this.Id;
			if (!(num.GetValueOrDefault() == id & num != null))
			{
				return;
			}
			this.State = TrapDefenseDefine.trapDefenseRewardServerState2ClientState[taskInfo.Status];
			double startTime = (double)serverData.LimitBeginTime * Singleton<TimeUtil>.Instance.Millisecond;
			double endTime = (double)serverData.LimitEndTime * Singleton<TimeUtil>.Instance.Millisecond;
			if (!Singleton<TimeUtil>.Instance.IsInTimeSpan(startTime, endTime))
			{
				this.State = ETrapDefenseRewardState.Lock;
			}
			this.StartTime = startTime;
			this.CurProgress = ((taskInfo != null) ? taskInfo.Current : 0);
			this.Target = ((taskInfo != null) ? taskInfo.Target : 0);
		}

		// Token: 0x06033719 RID: 210713 RVA: 0x00CDDA40 File Offset: 0x00CDBC40
		public string GetUnlockRemainTimeStr()
		{
			if (this.State != ETrapDefenseRewardState.Lock)
			{
				return "";
			}
			double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
			double num = this.StartTime - serverTime;
			if (num <= 0.0)
			{
				return "";
			}
			CommonDefine.ICountDown remainTimeDataFormat = Singleton<TimeUtil>.Instance.GetRemainTimeDataFormat3(num);
			return ((remainTimeDataFormat != null) ? remainTimeDataFormat.CountDownText : null) ?? "";
		}

		// Token: 0x0603371A RID: 210714 RVA: 0x00CDDAA4 File Offset: 0x00CDBCA4
		private void Init()
		{
			if (this.Config == null)
			{
				return;
			}
			this.Type = (ETrapDefenseRewardType)this.Config.Value.Type;
			this.Desc = this.Config.Value.Desc;
			this.InitRewardItemList();
		}

		// Token: 0x0603371B RID: 210715 RVA: 0x00CDDAF8 File Offset: 0x00CDBCF8
		private void InitRewardItemList()
		{
			this.ItemList.Clear();
			DropPackage? config = ConfigDropPackageById.GetConfig(this.Config.Value.RewardId, true);
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

		// Token: 0x0401DCD1 RID: 122065
		private TrapDefenseReward? Config;

		// Token: 0x0401DCD2 RID: 122066
		public int Id;

		// Token: 0x0401DCD3 RID: 122067
		public ETrapDefenseRewardType Type;

		// Token: 0x0401DCD4 RID: 122068
		public string Desc = "";

		// Token: 0x0401DCD5 RID: 122069
		public List<TItem> ItemList = new List<TItem>();

		// Token: 0x0401DCD6 RID: 122070
		public ETrapDefenseRewardState State;

		// Token: 0x0401DCD7 RID: 122071
		public double StartTime;

		// Token: 0x0401DCD8 RID: 122072
		public int CurProgress;

		// Token: 0x0401DCD9 RID: 122073
		public int Target;
	}
}
