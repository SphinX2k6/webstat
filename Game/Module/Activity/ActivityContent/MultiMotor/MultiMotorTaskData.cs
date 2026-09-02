using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Reward;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MultiMotor
{
	// Token: 0x02006657 RID: 26199
	[NullableContext(1)]
	[Nullable(0)]
	public class MultiMotorTaskData
	{
		// Token: 0x060416D0 RID: 267984 RVA: 0x010C9AE0 File Offset: 0x010C7CE0
		public MultiMotorTaskData(int taskId)
		{
			this.TaskId = taskId;
		}

		// Token: 0x060416D1 RID: 267985 RVA: 0x010C9B04 File Offset: 0x010C7D04
		public void RefreshByTaskInfo(OnlineMotorTask taskInfo)
		{
			switch (taskInfo.State)
			{
			case ActivityTaskState.ActivityTaskRunning:
				this.Status = EActivityTaskState.Active;
				break;
			case ActivityTaskState.ActivityTaskFinish:
				this.Status = EActivityTaskState.FinishedAndUnclaimed;
				break;
			case ActivityTaskState.ActivityTaskTaken:
				this.Status = EActivityTaskState.FinishedAndClaimed;
				break;
			}
			this.Champion = taskInfo.Champion;
			this.FirstRunner = taskInfo.FirstRunner;
			this.PlayCount = taskInfo.PlayCount;
			this.SpeedLap = taskInfo.SpeedLap;
			if (this.IsGlobalTask)
			{
				OnlineMotorGlobalTask? motorGlobalTaskByTaskId = ConfigBase<MultiMotorConfig>.Instance.GetMotorGlobalTaskByTaskId(this.TaskId);
				if (motorGlobalTaskByTaskId != null)
				{
					this.RewardList.Clear();
					this.RewardList.AddRange(ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackagePreviewItemList(motorGlobalTaskByTaskId.Value.DropId));
					return;
				}
			}
			else
			{
				OnlineMotorLevelTask? motorLevelTaskByTaskId = ConfigBase<MultiMotorConfig>.Instance.GetMotorLevelTaskByTaskId(this.TaskId);
				if (motorLevelTaskByTaskId != null)
				{
					this.RewardList.Clear();
					this.RewardList.AddRange(ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackagePreviewItemList(motorLevelTaskByTaskId.Value.DropId));
				}
			}
		}

		// Token: 0x17009F88 RID: 40840
		// (get) Token: 0x060416D2 RID: 267986 RVA: 0x010C9C11 File Offset: 0x010C7E11
		public bool IsRunning
		{
			get
			{
				return this.Status == EActivityTaskState.Active;
			}
		}

		// Token: 0x17009F89 RID: 40841
		// (get) Token: 0x060416D3 RID: 267987 RVA: 0x010C9C1C File Offset: 0x010C7E1C
		public bool IsFinished
		{
			get
			{
				return this.Status == EActivityTaskState.FinishedAndUnclaimed;
			}
		}

		// Token: 0x17009F8A RID: 40842
		// (get) Token: 0x060416D4 RID: 267988 RVA: 0x010C9C27 File Offset: 0x010C7E27
		public bool IsReceived
		{
			get
			{
				return this.Status == EActivityTaskState.FinishedAndClaimed;
			}
		}

		// Token: 0x060416D5 RID: 267989 RVA: 0x010C9C32 File Offset: 0x010C7E32
		public void RefreshState(EActivityTaskState state)
		{
			this.Status = state;
		}

		// Token: 0x17009F8B RID: 40843
		// (get) Token: 0x060416D6 RID: 267990 RVA: 0x010C9C3B File Offset: 0x010C7E3B
		// (set) Token: 0x060416D7 RID: 267991 RVA: 0x010C9C43 File Offset: 0x010C7E43
		public int LevelId
		{
			get
			{
				return this.LevelInternal;
			}
			set
			{
				this.LevelInternal = value;
			}
		}

		// Token: 0x17009F8C RID: 40844
		// (get) Token: 0x060416D8 RID: 267992 RVA: 0x010C9C4C File Offset: 0x010C7E4C
		public bool IsGlobalTask
		{
			get
			{
				return this.LevelId < 0;
			}
		}

		// Token: 0x17009F8D RID: 40845
		// (get) Token: 0x060416D9 RID: 267993 RVA: 0x010C9C58 File Offset: 0x010C7E58
		public string DescString
		{
			get
			{
				string text = "";
				if (this.IsGlobalTask)
				{
					OnlineMotorGlobalTask? motorGlobalTaskByTaskId = ConfigBase<MultiMotorConfig>.Instance.GetMotorGlobalTaskByTaskId(this.TaskId);
					if (motorGlobalTaskByTaskId == null)
					{
						return "";
					}
					if (motorGlobalTaskByTaskId.Value.PlayCount != 0)
					{
						text += ConfigMultiTextLang.GetLocalTextNew(motorGlobalTaskByTaskId.Value.PlayCountDes, null);
						text = StringUtils.Format(text, new string[]
						{
							this.PlayCount.ToString(),
							motorGlobalTaskByTaskId.Value.PlayCount.ToString()
						});
					}
					if (motorGlobalTaskByTaskId.Value.SpeedLap != 0)
					{
						if (!string.IsNullOrEmpty(text))
						{
							text += ConfigMultiTextLang.GetLocalTextNew("MultiMotorTaskDesMiddle", null);
						}
						text += ConfigMultiTextLang.GetLocalTextNew(motorGlobalTaskByTaskId.Value.SpeedLapDes, null);
						text = StringUtils.Format(text, new string[]
						{
							this.SpeedLap.ToString(),
							motorGlobalTaskByTaskId.Value.SpeedLap.ToString()
						});
					}
					if (motorGlobalTaskByTaskId.Value.Champion != 0)
					{
						if (!string.IsNullOrEmpty(text))
						{
							text += ConfigMultiTextLang.GetLocalTextNew("MultiMotorTaskDesMiddle", null);
						}
						text += ConfigMultiTextLang.GetLocalTextNew(motorGlobalTaskByTaskId.Value.ChampionDes, null);
						text = StringUtils.Format(text, new string[]
						{
							this.Champion.ToString(),
							motorGlobalTaskByTaskId.Value.Champion.ToString()
						});
					}
					if (motorGlobalTaskByTaskId.Value.FirstRunner != 0)
					{
						if (!string.IsNullOrEmpty(text))
						{
							text += ConfigMultiTextLang.GetLocalTextNew("MultiMotorTaskDesMiddle", null);
						}
						text += ConfigMultiTextLang.GetLocalTextNew(motorGlobalTaskByTaskId.Value.FirstRunnerDes, null);
						text = StringUtils.Format(text, new string[]
						{
							this.FirstRunner.ToString(),
							motorGlobalTaskByTaskId.Value.FirstRunner.ToString()
						});
					}
				}
				else
				{
					OnlineMotorLevelTask? motorLevelTaskByTaskId = ConfigBase<MultiMotorConfig>.Instance.GetMotorLevelTaskByTaskId(this.TaskId);
					if (motorLevelTaskByTaskId == null)
					{
						return "";
					}
					if (motorLevelTaskByTaskId.Value.PlayCount != 0)
					{
						text += ConfigMultiTextLang.GetLocalTextNew(motorLevelTaskByTaskId.Value.PlayCountDes, null);
						text = StringUtils.Format(text, new string[]
						{
							this.PlayCount.ToString(),
							motorLevelTaskByTaskId.Value.PlayCount.ToString()
						});
					}
					if (motorLevelTaskByTaskId.Value.SpeedLap != 0)
					{
						if (!string.IsNullOrEmpty(text))
						{
							text += ConfigMultiTextLang.GetLocalTextNew("MultiMotorTaskDesMiddle", null);
						}
						text += ConfigMultiTextLang.GetLocalTextNew(motorLevelTaskByTaskId.Value.SpeedLapDes, null);
						text = StringUtils.Format(text, new string[]
						{
							this.SpeedLap.ToString(),
							motorLevelTaskByTaskId.Value.SpeedLap.ToString()
						});
					}
					if (motorLevelTaskByTaskId.Value.Champion != 0)
					{
						if (!string.IsNullOrEmpty(text))
						{
							text += ConfigMultiTextLang.GetLocalTextNew("MultiMotorTaskDesMiddle", null);
						}
						text += ConfigMultiTextLang.GetLocalTextNew(motorLevelTaskByTaskId.Value.ChampionDes, null);
						text = StringUtils.Format(text, new string[]
						{
							this.Champion.ToString(),
							motorLevelTaskByTaskId.Value.Champion.ToString()
						});
					}
					if (motorLevelTaskByTaskId.Value.FirstRunner != 0)
					{
						if (!string.IsNullOrEmpty(text))
						{
							text += ConfigMultiTextLang.GetLocalTextNew("MultiMotorTaskDesMiddle", null);
						}
						text += ConfigMultiTextLang.GetLocalTextNew(motorLevelTaskByTaskId.Value.FirstRunnerDes, null);
						text = StringUtils.Format(text, new string[]
						{
							this.FirstRunner.ToString(),
							motorLevelTaskByTaskId.Value.FirstRunner.ToString()
						});
					}
				}
				return text;
			}
		}

		// Token: 0x0402493F RID: 149823
		public int TaskId;

		// Token: 0x04024940 RID: 149824
		public readonly List<TItem> RewardList = new List<TItem>();

		// Token: 0x04024941 RID: 149825
		private int LevelInternal;

		// Token: 0x04024942 RID: 149826
		private int Champion;

		// Token: 0x04024943 RID: 149827
		private int FirstRunner;

		// Token: 0x04024944 RID: 149828
		private int PlayCount;

		// Token: 0x04024945 RID: 149829
		private int SpeedLap;

		// Token: 0x04024946 RID: 149830
		public EActivityTaskState Status = EActivityTaskState.Active;
	}
}
