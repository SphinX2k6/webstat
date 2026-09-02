using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Reward;

namespace CSharpScript.Game.Module.Activity.ActivityContent.CyberPunk
{
	// Token: 0x02006970 RID: 26992
	[NullableContext(1)]
	[Nullable(0)]
	public class CyberPunkTaskData
	{
		// Token: 0x06042FB7 RID: 274359 RVA: 0x0113241F File Offset: 0x0113061F
		public void Refresh(ConditionTask task)
		{
			this.Id = task.Id;
			this.Current = task.Current;
			this.Target = task.Target;
			this.Status = task.Status;
			this.InitRewardList();
			this.InitQuestName();
		}

		// Token: 0x06042FB8 RID: 274360 RVA: 0x01132460 File Offset: 0x01130660
		public void InitRewardList()
		{
			EdgeRunnerReward? config = ConfigEdgeRunnerRewardById.GetConfig(this.Id, true);
			if (config != null && config.Value.DropId > 0)
			{
				this.RewardList = ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackagePreviewItemList(config.Value.DropId);
				return;
			}
			this.RewardList = new List<TItem>();
		}

		// Token: 0x06042FB9 RID: 274361 RVA: 0x011324C0 File Offset: 0x011306C0
		public void InitQuestName()
		{
			EdgeRunnerReward? config = ConfigEdgeRunnerRewardById.GetConfig(this.Id, true);
			this.QuestName = (((config != null) ? config.GetValueOrDefault().Desc : null) ?? "");
		}

		// Token: 0x06042FBA RID: 274362 RVA: 0x01132504 File Offset: 0x01130704
		public void SetClaimed()
		{
			this.Status = ConditionTaskState.ConditionTaskTaken;
		}

		// Token: 0x06042FBB RID: 274363 RVA: 0x01132510 File Offset: 0x01130710
		public string GetProgressText()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted<int>(this.Current);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted<int>(this.Target);
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x06042FBC RID: 274364 RVA: 0x01132553 File Offset: 0x01130753
		public bool IsFinished()
		{
			return this.Status == ConditionTaskState.ConditionTaskFinish;
		}

		// Token: 0x06042FBD RID: 274365 RVA: 0x0113255E File Offset: 0x0113075E
		public bool IsClaimed()
		{
			return this.Status == ConditionTaskState.ConditionTaskTaken;
		}

		// Token: 0x06042FBE RID: 274366 RVA: 0x01132569 File Offset: 0x01130769
		public bool IsActive()
		{
			return this.Status == ConditionTaskState.ConditionTaskRunning;
		}

		// Token: 0x040254E5 RID: 152805
		public int Id;

		// Token: 0x040254E6 RID: 152806
		public int Current;

		// Token: 0x040254E7 RID: 152807
		public int Target = 1;

		// Token: 0x040254E8 RID: 152808
		public ConditionTaskState Status;

		// Token: 0x040254E9 RID: 152809
		public List<TItem> RewardList = new List<TItem>();

		// Token: 0x040254EA RID: 152810
		public string QuestName = "";
	}
}
