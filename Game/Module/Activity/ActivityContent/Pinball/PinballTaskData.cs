using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Inventory;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball
{
	// Token: 0x0200658A RID: 25994
	[NullableContext(1)]
	[Nullable(0)]
	public class PinballTaskData
	{
		// Token: 0x17009EA8 RID: 40616
		// (get) Token: 0x06040E9A RID: 265882 RVA: 0x010A7426 File Offset: 0x010A5626
		// (set) Token: 0x06040E9B RID: 265883 RVA: 0x010A742E File Offset: 0x010A562E
		[Nullable(2)]
		public ConditionTask Data { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x17009EA9 RID: 40617
		// (get) Token: 0x06040E9C RID: 265884 RVA: 0x010A7437 File Offset: 0x010A5637
		// (set) Token: 0x06040E9D RID: 265885 RVA: 0x010A743F File Offset: 0x010A563F
		public EPinballTaskState Status { get; set; }

		// Token: 0x17009EAA RID: 40618
		// (get) Token: 0x06040E9E RID: 265886 RVA: 0x010A7448 File Offset: 0x010A5648
		// (set) Token: 0x06040E9F RID: 265887 RVA: 0x010A7450 File Offset: 0x010A5650
		public List<TItem> RewardList { get; set; } = new List<TItem>();

		// Token: 0x17009EAB RID: 40619
		// (get) Token: 0x06040EA0 RID: 265888 RVA: 0x010A7459 File Offset: 0x010A5659
		// (set) Token: 0x06040EA1 RID: 265889 RVA: 0x010A7461 File Offset: 0x010A5661
		public int Current { get; set; }

		// Token: 0x17009EAC RID: 40620
		// (get) Token: 0x06040EA2 RID: 265890 RVA: 0x010A746A File Offset: 0x010A566A
		// (set) Token: 0x06040EA3 RID: 265891 RVA: 0x010A7472 File Offset: 0x010A5672
		public int Target { get; set; } = 1;

		// Token: 0x17009EAD RID: 40621
		// (get) Token: 0x06040EA4 RID: 265892 RVA: 0x010A747B File Offset: 0x010A567B
		// (set) Token: 0x06040EA5 RID: 265893 RVA: 0x010A7483 File Offset: 0x010A5683
		public string QuestName { get; set; } = "";

		// Token: 0x17009EAE RID: 40622
		// (get) Token: 0x06040EA6 RID: 265894 RVA: 0x010A748C File Offset: 0x010A568C
		// (set) Token: 0x06040EA7 RID: 265895 RVA: 0x010A7494 File Offset: 0x010A5694
		[Nullable(2)]
		public string QuestNameTextKey { [NullableContext(2)] get; [NullableContext(2)] set; } = "";

		// Token: 0x17009EAF RID: 40623
		// (get) Token: 0x06040EA8 RID: 265896 RVA: 0x010A749D File Offset: 0x010A569D
		// (set) Token: 0x06040EA9 RID: 265897 RVA: 0x010A74A5 File Offset: 0x010A56A5
		public int DropId { get; set; }

		// Token: 0x17009EB0 RID: 40624
		// (get) Token: 0x06040EAA RID: 265898 RVA: 0x010A74AE File Offset: 0x010A56AE
		// (set) Token: 0x06040EAB RID: 265899 RVA: 0x010A74B6 File Offset: 0x010A56B6
		public EPinballTaskTab TaskTab { get; set; }

		// Token: 0x06040EAC RID: 265900 RVA: 0x010A74C0 File Offset: 0x010A56C0
		public PinballTaskData(ConditionTask taskData)
		{
			this.Data = taskData;
			this.Status = PinballTaskData.ConvertTaskState(taskData.Status);
			this.Current = taskData.Current;
			this.Target = taskData.Target;
			this.QuestName = "";
			this.QuestNameTextKey = "";
			this.RewardList = new List<TItem>();
		}

		// Token: 0x06040EAD RID: 265901 RVA: 0x010A754C File Offset: 0x010A574C
		public void UpdateTaskData(ConditionTask taskData)
		{
			this.Data = taskData;
			this.Status = PinballTaskData.ConvertTaskState(taskData.Status);
			this.Current = taskData.Current;
			this.Target = taskData.Target;
		}

		// Token: 0x06040EAE RID: 265902 RVA: 0x010A7580 File Offset: 0x010A5780
		public void SetRewardList(int dropId)
		{
			this.DropId = dropId;
			this.RewardList = new List<TItem>();
			if (dropId == 0)
			{
				return;
			}
			DropPackage? config = ConfigDropPackageById.GetConfig(dropId, true);
			if (config == null || config.Value.DropPreviewLength == 0)
			{
				return;
			}
			for (int i = 0; i < config.Value.DropPreviewLength; i++)
			{
				DicIntInt? dicIntInt = config.Value.DropPreview(i);
				if (dicIntInt != null)
				{
					int key = dicIntInt.Value.Key;
					int value = dicIntInt.Value.Value;
					this.RewardList.Add(new TItem(new InventoryDefine.GetItemData(key, 0), value));
				}
			}
		}

		// Token: 0x06040EAF RID: 265903 RVA: 0x010A7638 File Offset: 0x010A5838
		private static EPinballTaskState ConvertTaskState(ConditionTaskState state)
		{
			switch (state)
			{
			case ConditionTaskState.ConditionTaskRunning:
				return EPinballTaskState.UnLock;
			case ConditionTaskState.ConditionTaskFinish:
				return EPinballTaskState.Claimable;
			case ConditionTaskState.ConditionTaskTaken:
				return EPinballTaskState.Finished;
			default:
				return EPinballTaskState.UnLock;
			}
		}

		// Token: 0x17009EB1 RID: 40625
		// (get) Token: 0x06040EB0 RID: 265904 RVA: 0x010A7655 File Offset: 0x010A5855
		public bool IsDoing
		{
			get
			{
				return this.Status == EPinballTaskState.UnLock;
			}
		}

		// Token: 0x17009EB2 RID: 40626
		// (get) Token: 0x06040EB1 RID: 265905 RVA: 0x010A7660 File Offset: 0x010A5860
		public bool IsUnclaimed
		{
			get
			{
				return this.Status == EPinballTaskState.Claimable;
			}
		}

		// Token: 0x17009EB3 RID: 40627
		// (get) Token: 0x06040EB2 RID: 265906 RVA: 0x010A766B File Offset: 0x010A586B
		public bool IsFinished
		{
			get
			{
				return this.Status == EPinballTaskState.Finished;
			}
		}
	}
}
