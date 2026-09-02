using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MotorParkour
{
	// Token: 0x020066AB RID: 26283
	[NullableContext(1)]
	[Nullable(0)]
	public class MotorParkourActivityData : ActivityBaseData
	{
		// Token: 0x06041A25 RID: 268837 RVA: 0x010D44A2 File Offset: 0x010D26A2
		protected override void OnInit(ActivityData data)
		{
			this.InitMotorParkourLevel();
		}

		// Token: 0x06041A26 RID: 268838 RVA: 0x010D44AC File Offset: 0x010D26AC
		protected override void PhraseEx(ActivityData data)
		{
			MotorParkourActivityInfo motorParkourActivityInfo = data.MotorParkourActivityInfo;
			if (motorParkourActivityInfo == null)
			{
				return;
			}
			this.UpdateMotorParkourLevelList(motorParkourActivityInfo.MotorParkourLevelInfos);
		}

		// Token: 0x06041A27 RID: 268839 RVA: 0x010D44D0 File Offset: 0x010D26D0
		public override bool GetExDataRedPointShowState()
		{
			foreach (MotorParkourLevelData motorParkourLevelData in this.LevelDataList)
			{
				if (motorParkourLevelData.HasLevelRedDot || motorParkourLevelData.HasRewardRedDot)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06041A28 RID: 268840 RVA: 0x010D4534 File Offset: 0x010D2734
		protected override bool GetExDataFinishShowState()
		{
			using (List<MotorParkourLevelData>.Enumerator enumerator = this.LevelDataList.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (!enumerator.Current.IsFinished)
					{
						return false;
					}
				}
			}
			return true;
		}

		// Token: 0x06041A29 RID: 268841 RVA: 0x010D4590 File Offset: 0x010D2790
		private void InitMotorParkourLevel()
		{
			foreach (MotorParkour config in ConfigBase<MotorParkourConfig>.Instance.GetMotorParkourLevelByActivityId(base.Id))
			{
				MotorParkourLevelData motorParkourLevelData = new MotorParkourLevelData(config);
				this.MotorParkourLevelMap.Add(config.Id, motorParkourLevelData);
				this.LevelDataList.Add(motorParkourLevelData);
			}
			this.LevelDataList.Sort((MotorParkourLevelData a, MotorParkourLevelData b) => a.Id - b.Id);
			for (int i = 1; i < this.LevelDataList.Count; i++)
			{
				this.LevelDataList[i].PreMotorParkourLevelData = this.LevelDataList[i - 1];
			}
		}

		// Token: 0x06041A2A RID: 268842 RVA: 0x010D4668 File Offset: 0x010D2868
		public void UpdateMotorParkourLevelList(IReadOnlyList<MotorParkourLevelInfo> infoList)
		{
			foreach (MotorParkourLevelInfo motorParkourLevelInfo in infoList)
			{
				int motorParkourId = motorParkourLevelInfo.MotorParkourId;
				MotorParkourLevelData motorParkourLevelData;
				if (!this.MotorParkourLevelMap.TryGetValue(motorParkourId, out motorParkourLevelData))
				{
					return;
				}
				motorParkourLevelData.UpdateTaskStatus(motorParkourLevelInfo.RewardStates);
				motorParkourLevelData.UnlockTime = motorParkourLevelInfo.UnlockTime;
				motorParkourLevelData.BestRecordTime = motorParkourLevelInfo.BestPassTime;
			}
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, base.Id);
		}

		// Token: 0x06041A2B RID: 268843 RVA: 0x010D46FC File Offset: 0x010D28FC
		public bool UpdateMotorParkourLevelBestRecordTime(int levelId, int time)
		{
			MotorParkourLevelData levelDataById = this.GetLevelDataById(levelId);
			if (time <= levelDataById.BestRecordTime || levelDataById.BestRecordTime == 0)
			{
				levelDataById.BestRecordTime = time;
				return true;
			}
			return false;
		}

		// Token: 0x06041A2C RID: 268844 RVA: 0x010D472C File Offset: 0x010D292C
		public MotorParkourLevelData GetSelectedLevelData()
		{
			int num = -1;
			int num2 = -1;
			for (int i = 0; i < this.LevelDataList.Count; i++)
			{
				MotorParkourLevelData motorParkourLevelData = this.LevelDataList[i];
				if (motorParkourLevelData.HasRewardRedDot)
				{
					return motorParkourLevelData;
				}
				if (motorParkourLevelData.IsUnLock && !motorParkourLevelData.IsPass && num == -1)
				{
					num = i;
				}
				if (!motorParkourLevelData.IsUnLock && num2 == -1)
				{
					num2 = i;
				}
			}
			if (num != -1)
			{
				return this.LevelDataList[num];
			}
			if (num2 > 0)
			{
				return this.LevelDataList[num2 - 1];
			}
			return this.LevelDataList[this.LevelDataList.Count - 1];
		}

		// Token: 0x06041A2D RID: 268845 RVA: 0x010D47CC File Offset: 0x010D29CC
		public MotorParkourLevelData GetSelectedLevelDataInRewardView()
		{
			int num = -1;
			for (int i = 0; i < this.LevelDataList.Count; i++)
			{
				MotorParkourLevelData motorParkourLevelData = this.LevelDataList[i];
				if (motorParkourLevelData.HasRewardRedDot)
				{
					return motorParkourLevelData;
				}
				if (num == -1 && !motorParkourLevelData.IsFinished)
				{
					num = i;
				}
			}
			if (num != -1)
			{
				return this.LevelDataList[num];
			}
			return this.LevelDataList[0];
		}

		// Token: 0x06041A2E RID: 268846 RVA: 0x010D4834 File Offset: 0x010D2A34
		public bool RewardHasRedDot()
		{
			using (List<MotorParkourLevelData>.Enumerator enumerator = this.LevelDataList.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.HasRewardRedDot)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x06041A2F RID: 268847 RVA: 0x010D4890 File Offset: 0x010D2A90
		public List<MotorParkourLevelData> GetLevelDataList()
		{
			return this.LevelDataList;
		}

		// Token: 0x06041A30 RID: 268848 RVA: 0x010D4898 File Offset: 0x010D2A98
		public MotorParkourLevelData GetLevelDataById(int levelId)
		{
			MotorParkourLevelData result;
			this.MotorParkourLevelMap.TryGetValue(levelId, out result);
			return result;
		}

		// Token: 0x06041A31 RID: 268849 RVA: 0x010D48B8 File Offset: 0x010D2AB8
		public int GetAllTaskNum()
		{
			int num = 0;
			foreach (MotorParkourLevelData motorParkourLevelData in this.LevelDataList)
			{
				num += motorParkourLevelData.AllTaskNum;
			}
			return num;
		}

		// Token: 0x06041A32 RID: 268850 RVA: 0x010D4910 File Offset: 0x010D2B10
		public int GetFinishedTaskNum()
		{
			int num = 0;
			foreach (MotorParkourLevelData motorParkourLevelData in this.LevelDataList)
			{
				num += motorParkourLevelData.FinishedTaskNum;
			}
			return num;
		}

		// Token: 0x04024A44 RID: 150084
		private readonly Dictionary<int, MotorParkourLevelData> MotorParkourLevelMap = new Dictionary<int, MotorParkourLevelData>();

		// Token: 0x04024A45 RID: 150085
		private readonly List<MotorParkourLevelData> LevelDataList = new List<MotorParkourLevelData>();
	}
}
