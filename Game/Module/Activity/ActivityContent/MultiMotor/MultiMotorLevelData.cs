using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MultiMotor
{
	// Token: 0x02006656 RID: 26198
	[NullableContext(1)]
	[Nullable(0)]
	public class MultiMotorLevelData
	{
		// Token: 0x060416C5 RID: 267973 RVA: 0x010C993D File Offset: 0x010C7B3D
		public MultiMotorLevelData(int levelId)
		{
			this.LevelIdInternal = levelId;
		}

		// Token: 0x060416C6 RID: 267974 RVA: 0x010C9957 File Offset: 0x010C7B57
		public void RefreshByLevelInfo(OnlineMotorLevelInfo levelInfo)
		{
			this.BestRecordTime = levelInfo.TimeCost;
			this.BestRanking = levelInfo.Ranking;
		}

		// Token: 0x17009F81 RID: 40833
		// (get) Token: 0x060416C7 RID: 267975 RVA: 0x010C9971 File Offset: 0x010C7B71
		public int LevelId
		{
			get
			{
				return this.LevelIdInternal;
			}
		}

		// Token: 0x17009F82 RID: 40834
		// (get) Token: 0x060416C8 RID: 267976 RVA: 0x010C9979 File Offset: 0x010C7B79
		public bool IsUnLock
		{
			get
			{
				return (this.PreMultiMotorParkourLevelData == null || this.PreMultiMotorParkourLevelData.IsPass) && this.IsReachUnlockTime();
			}
		}

		// Token: 0x060416C9 RID: 267977 RVA: 0x010C9998 File Offset: 0x010C7B98
		public bool IsReachUnlockTime()
		{
			double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
			return this.UnlockTime == 0L || (double)this.UnlockTime < serverTime;
		}

		// Token: 0x17009F83 RID: 40835
		// (get) Token: 0x060416CA RID: 267978 RVA: 0x010C99C4 File Offset: 0x010C7BC4
		public OnlineMotorLevel? Config
		{
			get
			{
				return ConfigBase<MultiMotorConfig>.Instance.GetMotorMultiParkourLevelById(this.LevelId);
			}
		}

		// Token: 0x17009F84 RID: 40836
		// (get) Token: 0x060416CB RID: 267979 RVA: 0x010C99D6 File Offset: 0x010C7BD6
		public bool IsPass
		{
			get
			{
				return this.BestRecordTime != 0;
			}
		}

		// Token: 0x17009F85 RID: 40837
		// (get) Token: 0x060416CC RID: 267980 RVA: 0x010C99E1 File Offset: 0x010C7BE1
		public bool IsFinish
		{
			get
			{
				if (this.TaskList.Count == 0)
				{
					return false;
				}
				return this.TaskList.TrueForAll((MultiMotorTaskData task) => task.IsFinished || task.IsReceived);
			}
		}

		// Token: 0x17009F86 RID: 40838
		// (get) Token: 0x060416CD RID: 267981 RVA: 0x010C9A1C File Offset: 0x010C7C1C
		public bool HasRewardRedDot
		{
			get
			{
				using (List<MultiMotorTaskData>.Enumerator enumerator = this.TaskList.GetEnumerator())
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

		// Token: 0x17009F87 RID: 40839
		// (get) Token: 0x060416CE RID: 267982 RVA: 0x010C9A78 File Offset: 0x010C7C78
		public bool HasLevelRedDot
		{
			get
			{
				if (!this.IsUnLock)
				{
					return false;
				}
				int activityId = ModelBase<MultiMotorModel>.Instance.ActivityId;
				return ModelBase<ActivityModel>.Instance.GetActivityCacheData(activityId, 0, 1, this.LevelId, 0) != 1;
			}
		}

		// Token: 0x060416CF RID: 267983 RVA: 0x010C9AB4 File Offset: 0x010C7CB4
		public void ReadLevelRedDot()
		{
			int activityId = ModelBase<MultiMotorModel>.Instance.ActivityId;
			ModelBase<ActivityModel>.Instance.SaveActivityData(activityId, 1, this.LevelId, 0, 1);
		}

		// Token: 0x04024938 RID: 149816
		private const int MULTI_MOTOR_LEVEL_CLICKED_KEY = 1;

		// Token: 0x04024939 RID: 149817
		private readonly int LevelIdInternal;

		// Token: 0x0402493A RID: 149818
		[Nullable(2)]
		public MultiMotorLevelData PreMultiMotorParkourLevelData;

		// Token: 0x0402493B RID: 149819
		public readonly List<MultiMotorTaskData> TaskList = new List<MultiMotorTaskData>();

		// Token: 0x0402493C RID: 149820
		public long UnlockTime;

		// Token: 0x0402493D RID: 149821
		public int BestRecordTime;

		// Token: 0x0402493E RID: 149822
		public int BestRanking;
	}
}
