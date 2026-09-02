using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Reward;

namespace CSharpScript.Game.Module.FlagChallenge
{
	// Token: 0x02005D2A RID: 23850
	[NullableContext(1)]
	[Nullable(0)]
	public class FlagChallengeTaskData
	{
		// Token: 0x0603C29B RID: 246427 RVA: 0x00F41D04 File Offset: 0x00F3FF04
		public FlagChallengeTaskData(int id)
		{
			this.Id = id;
			this.TaskConfig = ConfigBase<FlagChallengeConfig>.Instance.GetTaskConfig(id).Value;
		}

		// Token: 0x0603C29C RID: 246428 RVA: 0x00F41D37 File Offset: 0x00F3FF37
		public void Refresh(ConditionTask taskData)
		{
			this.TaskStatus = taskData.Status;
			this.TaskCurrent = taskData.Current;
			this.TaskTarget = taskData.Target;
		}

		// Token: 0x0603C29D RID: 246429 RVA: 0x00F41D60 File Offset: 0x00F3FF60
		public List<TItem> GetRewardList()
		{
			int dropId = this.TaskConfig.DropId;
			if (dropId <= 0)
			{
				return new List<TItem>();
			}
			return ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackagePreviewItemList(dropId);
		}

		// Token: 0x0603C29E RID: 246430 RVA: 0x00F41D94 File Offset: 0x00F3FF94
		public string GetRewardName()
		{
			return this.TaskConfig.RewardName;
		}

		// Token: 0x0603C29F RID: 246431 RVA: 0x00F41DB0 File Offset: 0x00F3FFB0
		public string GetProgressText()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler;
			if (this.TaskStatus == ConditionTaskState.ConditionTaskRunning)
			{
				defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
				defaultInterpolatedStringHandler.AppendFormatted<int>(this.TaskCurrent);
				defaultInterpolatedStringHandler.AppendLiteral("/");
				defaultInterpolatedStringHandler.AppendFormatted<int>(this.TaskTarget);
				return defaultInterpolatedStringHandler.ToStringAndClear();
			}
			defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted<int>(this.TaskTarget);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted<int>(this.TaskTarget);
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x0603C2A0 RID: 246432 RVA: 0x00F41E35 File Offset: 0x00F40035
		public void SetTaskStatus(ConditionTaskState status)
		{
			this.TaskStatus = status;
		}

		// Token: 0x0603C2A1 RID: 246433 RVA: 0x00F41E3E File Offset: 0x00F4003E
		public ConditionTaskState GetTaskStatus()
		{
			return this.TaskStatus;
		}

		// Token: 0x0603C2A2 RID: 246434 RVA: 0x00F41E46 File Offset: 0x00F40046
		public int GetTaskTarget()
		{
			return this.TaskTarget;
		}

		// Token: 0x0603C2A3 RID: 246435 RVA: 0x00F41E4E File Offset: 0x00F4004E
		public bool CanReceiveReward()
		{
			return this.TaskStatus == ConditionTaskState.ConditionTaskFinish;
		}

		// Token: 0x0603C2A4 RID: 246436 RVA: 0x00F41E59 File Offset: 0x00F40059
		public bool IsTaskReceived()
		{
			return this.TaskStatus == ConditionTaskState.ConditionTaskTaken;
		}

		// Token: 0x0603C2A5 RID: 246437 RVA: 0x00F41E64 File Offset: 0x00F40064
		public bool IsTaskRunning()
		{
			return this.TaskStatus == ConditionTaskState.ConditionTaskRunning;
		}

		// Token: 0x04021C2A RID: 138282
		public readonly int Id;

		// Token: 0x04021C2B RID: 138283
		public readonly FlagChallengeTask TaskConfig;

		// Token: 0x04021C2C RID: 138284
		private ConditionTaskState TaskStatus;

		// Token: 0x04021C2D RID: 138285
		private int TaskCurrent;

		// Token: 0x04021C2E RID: 138286
		private int TaskTarget;
	}
}
