using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using Google.Protobuf.Collections;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MultiMotor
{
	// Token: 0x02006655 RID: 26197
	[NullableContext(1)]
	[Nullable(0)]
	public class MultiMotorData : ActivityBaseData
	{
		// Token: 0x060416B6 RID: 267958 RVA: 0x010C91E4 File Offset: 0x010C73E4
		protected override void PhraseEx(ActivityData data)
		{
			OnlineMotorActivityData onlineMotorActivityData = data.OnlineMotorActivityData;
			RepeatedField<OnlineMotorLevelInfo> levelInfoList = ((onlineMotorActivityData != null) ? onlineMotorActivityData.OnlineMotorLevelInfos : null) ?? new RepeatedField<OnlineMotorLevelInfo>();
			this.InitLevelData(levelInfoList);
			RepeatedField<OnlineMotorLevelUnLockTime> unlockTimes = ((onlineMotorActivityData != null) ? onlineMotorActivityData.UnLocks : null) ?? new RepeatedField<OnlineMotorLevelUnLockTime>();
			this.InitLevelUnlockTime(unlockTimes);
			RepeatedField<OnlineMotorTask> levelTaskList = ((onlineMotorActivityData != null) ? onlineMotorActivityData.LevelTasks : null) ?? new RepeatedField<OnlineMotorTask>();
			RepeatedField<OnlineMotorTask> globalTaskList = ((onlineMotorActivityData != null) ? onlineMotorActivityData.GlobalTasks : null) ?? new RepeatedField<OnlineMotorTask>();
			this.InitTaskData(levelTaskList, globalTaskList);
			MultiMotorController instance = ControllerBase<MultiMotorController>.Instance;
			if (instance == null)
			{
				return;
			}
			instance.OnMultiMotorDataInit();
		}

		// Token: 0x060416B7 RID: 267959 RVA: 0x010C9278 File Offset: 0x010C7478
		private void InitLevelData(IEnumerable<OnlineMotorLevelInfo> levelInfoList)
		{
			Dictionary<int, OnlineMotorLevelInfo> dictionary = new Dictionary<int, OnlineMotorLevelInfo>();
			foreach (OnlineMotorLevelInfo onlineMotorLevelInfo in levelInfoList)
			{
				dictionary[onlineMotorLevelInfo.LevelId] = onlineMotorLevelInfo;
			}
			IReadOnlyList<OnlineMotorLevel> allMotorMultiParkourLevel = ConfigBase<MultiMotorConfig>.Instance.GetAllMotorMultiParkourLevel();
			foreach (OnlineMotorLevel onlineMotorLevel in (allMotorMultiParkourLevel ?? new List<OnlineMotorLevel>()))
			{
				MultiMotorLevelData multiMotorLevelData = new MultiMotorLevelData(onlineMotorLevel.Id);
				OnlineMotorLevelInfo levelInfo;
				if (dictionary.TryGetValue(onlineMotorLevel.Id, out levelInfo))
				{
					multiMotorLevelData.RefreshByLevelInfo(levelInfo);
				}
				this.LevelDataMap[onlineMotorLevel.Id] = multiMotorLevelData;
			}
			foreach (KeyValuePair<int, MultiMotorLevelData> keyValuePair in this.LevelDataMap)
			{
				MultiMotorLevelData value = keyValuePair.Value;
				OnlineMotorLevel? motorMultiParkourLevelById = ConfigBase<MultiMotorConfig>.Instance.GetMotorMultiParkourLevelById(value.LevelId);
				if (motorMultiParkourLevelById != null && motorMultiParkourLevelById.Value.PreLevel != 0)
				{
					this.LevelDataMap.TryGetValue(motorMultiParkourLevelById.Value.PreLevel, out value.PreMultiMotorParkourLevelData);
				}
			}
		}

		// Token: 0x060416B8 RID: 267960 RVA: 0x010C93E8 File Offset: 0x010C75E8
		private void InitTaskData(IEnumerable<OnlineMotorTask> levelTaskList, IEnumerable<OnlineMotorTask> globalTaskList)
		{
			foreach (OnlineMotorTask onlineMotorTask in levelTaskList)
			{
				MultiMotorTaskData multiMotorTaskData = new MultiMotorTaskData(onlineMotorTask.TaskId);
				OnlineMotorLevelTask? motorLevelTaskByTaskId = ConfigBase<MultiMotorConfig>.Instance.GetMotorLevelTaskByTaskId(onlineMotorTask.TaskId);
				multiMotorTaskData.LevelId = ((motorLevelTaskByTaskId != null) ? motorLevelTaskByTaskId.GetValueOrDefault().LevelId : 0);
				multiMotorTaskData.RefreshByTaskInfo(onlineMotorTask);
				this.TaskDataMap[onlineMotorTask.TaskId] = multiMotorTaskData;
			}
			foreach (OnlineMotorTask onlineMotorTask2 in globalTaskList)
			{
				MultiMotorTaskData multiMotorTaskData2 = new MultiMotorTaskData(onlineMotorTask2.TaskId);
				multiMotorTaskData2.LevelId = -1;
				multiMotorTaskData2.RefreshByTaskInfo(onlineMotorTask2);
				this.TaskDataMap[-onlineMotorTask2.TaskId] = multiMotorTaskData2;
			}
			foreach (KeyValuePair<int, MultiMotorTaskData> keyValuePair in this.TaskDataMap)
			{
				MultiMotorTaskData value = keyValuePair.Value;
				MultiMotorLevelData multiMotorLevelData;
				if (!value.IsGlobalTask && this.LevelDataMap.TryGetValue(value.LevelId, out multiMotorLevelData))
				{
					multiMotorLevelData.TaskList.Add(value);
				}
			}
		}

		// Token: 0x060416B9 RID: 267961 RVA: 0x010C955C File Offset: 0x010C775C
		private void InitLevelUnlockTime(IEnumerable<OnlineMotorLevelUnLockTime> unlockTimes)
		{
			Dictionary<int, long> dictionary = new Dictionary<int, long>();
			foreach (OnlineMotorLevelUnLockTime onlineMotorLevelUnLockTime in unlockTimes)
			{
				dictionary[onlineMotorLevelUnLockTime.LevelId] = onlineMotorLevelUnLockTime.UnLockTime;
			}
			foreach (KeyValuePair<int, MultiMotorLevelData> keyValuePair in this.LevelDataMap)
			{
				long unlockTime;
				if (dictionary.TryGetValue(keyValuePair.Key, out unlockTime))
				{
					keyValuePair.Value.UnlockTime = unlockTime;
				}
			}
		}

		// Token: 0x060416BA RID: 267962 RVA: 0x010C9610 File Offset: 0x010C7810
		public void InitLevelRankData()
		{
			this.LevelBattleRankMap.Clear();
			foreach (OnlineTeamData onlineTeamData in ModelBase<OnlineModel>.Instance.GetTeamList())
			{
				this.LevelBattleRankMap[onlineTeamData.PlayerId] = 0;
			}
		}

		// Token: 0x060416BB RID: 267963 RVA: 0x010C9680 File Offset: 0x010C7880
		public List<MultiMotorLevelData> GetLevelDataList()
		{
			return new List<MultiMotorLevelData>(this.LevelDataMap.Values);
		}

		// Token: 0x17009F7C RID: 40828
		// (get) Token: 0x060416BC RID: 267964 RVA: 0x010C9692 File Offset: 0x010C7892
		public int TotalLevelCount
		{
			get
			{
				return this.LevelDataMap.Count;
			}
		}

		// Token: 0x17009F7D RID: 40829
		// (get) Token: 0x060416BD RID: 267965 RVA: 0x010C96A0 File Offset: 0x010C78A0
		public int FinishedLevelCount
		{
			get
			{
				int num = 0;
				foreach (KeyValuePair<int, MultiMotorLevelData> keyValuePair in this.LevelDataMap)
				{
					if (keyValuePair.Value.IsPass)
					{
						num++;
					}
				}
				return num;
			}
		}

		// Token: 0x060416BE RID: 267966 RVA: 0x010C9704 File Offset: 0x010C7904
		public List<MultiMotorTaskData> GetGlobalTaskList()
		{
			List<MultiMotorTaskData> list = new List<MultiMotorTaskData>();
			foreach (KeyValuePair<int, MultiMotorTaskData> keyValuePair in this.TaskDataMap)
			{
				if (keyValuePair.Value.IsGlobalTask)
				{
					list.Add(keyValuePair.Value);
				}
			}
			return list;
		}

		// Token: 0x17009F7E RID: 40830
		// (get) Token: 0x060416BF RID: 267967 RVA: 0x010C9774 File Offset: 0x010C7974
		public bool HasGlobalRewardRedDot
		{
			get
			{
				using (List<MultiMotorTaskData>.Enumerator enumerator = this.GetGlobalTaskList().GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						if (enumerator.Current.IsFinished)
						{
							return true;
						}
					}
				}
				return false;
			}
		}

		// Token: 0x17009F7F RID: 40831
		// (get) Token: 0x060416C0 RID: 267968 RVA: 0x010C97D0 File Offset: 0x010C79D0
		public bool HasAnyRewardRedDot
		{
			get
			{
				foreach (KeyValuePair<int, MultiMotorLevelData> keyValuePair in this.LevelDataMap)
				{
					if (keyValuePair.Value.HasRewardRedDot)
					{
						return true;
					}
				}
				return this.HasGlobalRewardRedDot;
			}
		}

		// Token: 0x17009F80 RID: 40832
		// (get) Token: 0x060416C1 RID: 267969 RVA: 0x010C9838 File Offset: 0x010C7A38
		public bool HasAnyLevelRedDot
		{
			get
			{
				foreach (KeyValuePair<int, MultiMotorLevelData> keyValuePair in this.LevelDataMap)
				{
					if (keyValuePair.Value.HasLevelRedDot)
					{
						return true;
					}
				}
				return false;
			}
		}

		// Token: 0x060416C2 RID: 267970 RVA: 0x010C989C File Offset: 0x010C7A9C
		public override bool GetExDataRedPointShowState()
		{
			return this.HasAnyRewardRedDot;
		}

		// Token: 0x060416C3 RID: 267971 RVA: 0x010C98A4 File Offset: 0x010C7AA4
		protected override bool GetExDataFinishShowState()
		{
			if (this.TaskDataMap.Count == 0)
			{
				return false;
			}
			foreach (KeyValuePair<int, MultiMotorTaskData> keyValuePair in this.TaskDataMap)
			{
				if (!keyValuePair.Value.IsReceived)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x04024935 RID: 149813
		public readonly Dictionary<int, MultiMotorLevelData> LevelDataMap = new Dictionary<int, MultiMotorLevelData>();

		// Token: 0x04024936 RID: 149814
		public readonly Dictionary<int, int> LevelBattleRankMap = new Dictionary<int, int>();

		// Token: 0x04024937 RID: 149815
		public readonly Dictionary<int, MultiMotorTaskData> TaskDataMap = new Dictionary<int, MultiMotorTaskData>();
	}
}
