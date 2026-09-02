using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MotorParkour
{
	// Token: 0x020066AC RID: 26284
	[NullableContext(1)]
	[Nullable(0)]
	public class MotorParkourLevelData
	{
		// Token: 0x06041A34 RID: 268852 RVA: 0x010D4988 File Offset: 0x010D2B88
		public MotorParkourLevelData(MotorParkour config)
		{
			this.Config = config;
			foreach (int id in config.RewardIdsIter())
			{
				MotorParkourTaskData motorParkourTaskData = new MotorParkourTaskData(id);
				motorParkourTaskData.LevelId = config.Id;
				MotorParkourRecord? motorParkourRecordById = ConfigBase<MotorParkourConfig>.Instance.GetMotorParkourRecordById(motorParkourTaskData.RecordId);
				if (motorParkourRecordById != null)
				{
					MotorParkourNPC? motorParkourNpcById = ConfigBase<MotorParkourConfig>.Instance.GetMotorParkourNpcById(motorParkourRecordById.Value.NPCId);
					if (motorParkourNpcById != null)
					{
						MotorParkourRankData item = new MotorParkourRankData(motorParkourNpcById.Value.Name, (float)motorParkourRecordById.Value.Record, Array.ConvertAll<int, float>(motorParkourRecordById.Value.LapRecord(), (int x) => (float)x), false);
						this.RecordList.Add(item);
						this.TaskList.Add(motorParkourTaskData);
					}
				}
			}
		}

		// Token: 0x06041A35 RID: 268853 RVA: 0x010D4AC4 File Offset: 0x010D2CC4
		public void UpdateTaskStatus(IReadOnlyList<MotorParkourRewardState> taskStatusList)
		{
			for (int i = 0; i < taskStatusList.Count; i++)
			{
				this.TaskList[i].Status = TaskStateResolver.TaskState[(ActivityTaskState)taskStatusList[i]];
			}
		}

		// Token: 0x1700A030 RID: 41008
		// (get) Token: 0x06041A36 RID: 268854 RVA: 0x010D4B04 File Offset: 0x010D2D04
		// (set) Token: 0x06041A37 RID: 268855 RVA: 0x010D4B0C File Offset: 0x010D2D0C
		public long UnlockTime
		{
			get
			{
				return this.UnlockTimeInterval;
			}
			set
			{
				this.UnlockTimeInterval = value;
			}
		}

		// Token: 0x06041A38 RID: 268856 RVA: 0x010D4B18 File Offset: 0x010D2D18
		public bool IsReachUnlockTime()
		{
			double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
			return this.UnlockTimeInterval == 0L || (double)this.UnlockTime < serverTime;
		}

		// Token: 0x1700A031 RID: 41009
		// (get) Token: 0x06041A39 RID: 268857 RVA: 0x010D4B44 File Offset: 0x010D2D44
		public bool IsUnLock
		{
			get
			{
				return (this.PreMotorParkourLevelData == null || this.PreMotorParkourLevelData.IsPass) && this.IsReachUnlockTime();
			}
		}

		// Token: 0x1700A032 RID: 41010
		// (get) Token: 0x06041A3A RID: 268858 RVA: 0x010D4B63 File Offset: 0x010D2D63
		// (set) Token: 0x06041A3B RID: 268859 RVA: 0x010D4B6C File Offset: 0x010D2D6C
		public int BestRecordTime
		{
			get
			{
				return this.BestRecordTimeInternal;
			}
			set
			{
				this.BestRecordTimeInternal = value;
				if (value == 0)
				{
					return;
				}
				if (this.MyRankData == null)
				{
					string playerName = ModelBase<FunctionModel>.Instance.GetPlayerName();
					this.MyRankData = new MotorParkourRankData(playerName, (float)value, Array.Empty<float>(), true);
					return;
				}
				this.MyRankData.Time = (float)value;
			}
		}

		// Token: 0x1700A033 RID: 41011
		// (get) Token: 0x06041A3C RID: 268860 RVA: 0x010D4BB9 File Offset: 0x010D2DB9
		public bool IsPass
		{
			get
			{
				return this.BestRecordTime != 0;
			}
		}

		// Token: 0x1700A034 RID: 41012
		// (get) Token: 0x06041A3D RID: 268861 RVA: 0x010D4BC4 File Offset: 0x010D2DC4
		public bool IsFinished
		{
			get
			{
				bool result = true;
				using (List<MotorParkourTaskData>.Enumerator enumerator = this.TaskList.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						if (!enumerator.Current.IsReceived)
						{
							result = false;
							break;
						}
					}
				}
				return result;
			}
		}

		// Token: 0x1700A035 RID: 41013
		// (get) Token: 0x06041A3E RID: 268862 RVA: 0x010D4C20 File Offset: 0x010D2E20
		public int AllTaskNum
		{
			get
			{
				return this.TaskList.Count;
			}
		}

		// Token: 0x1700A036 RID: 41014
		// (get) Token: 0x06041A3F RID: 268863 RVA: 0x010D4C30 File Offset: 0x010D2E30
		public int FinishedTaskNum
		{
			get
			{
				int num = 0;
				using (List<MotorParkourTaskData>.Enumerator enumerator = this.TaskList.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						if (enumerator.Current.IsReceived)
						{
							num++;
						}
					}
				}
				return num;
			}
		}

		// Token: 0x1700A037 RID: 41015
		// (get) Token: 0x06041A40 RID: 268864 RVA: 0x010D4C8C File Offset: 0x010D2E8C
		public List<MotorParkourRankData> HistoryRankList
		{
			get
			{
				List<MotorParkourRankData> list = new List<MotorParkourRankData>(this.RecordList);
				if (this.MyRankData != null)
				{
					list.Add(this.MyRankData);
				}
				list.Sort(delegate(MotorParkourRankData a, MotorParkourRankData b)
				{
					if (a.Time - b.Time >= 0f)
					{
						return 1;
					}
					return -1;
				});
				return list.GetRange(0, Math.Min(3, list.Count));
			}
		}

		// Token: 0x1700A038 RID: 41016
		// (get) Token: 0x06041A41 RID: 268865 RVA: 0x010D4CF4 File Offset: 0x010D2EF4
		public int BestRank
		{
			get
			{
				int num = this.HistoryRankList.FindIndex((MotorParkourRankData record) => record.IsOwn);
				if (num != -1)
				{
					return num + 1;
				}
				return 4;
			}
		}

		// Token: 0x06041A42 RID: 268866 RVA: 0x010D4D38 File Offset: 0x010D2F38
		public List<MotorParkourRankData> GetNewRankList(int newTime)
		{
			MotorParkourRankData item = new MotorParkourRankData(ModelBase<FunctionModel>.Instance.GetPlayerName(), (float)newTime, Array.Empty<float>(), true);
			List<MotorParkourRankData> list = new List<MotorParkourRankData>(this.RecordList);
			list.Add(item);
			list.Sort(delegate(MotorParkourRankData a, MotorParkourRankData b)
			{
				if (a.Time - b.Time >= 0f)
				{
					return 1;
				}
				return -1;
			});
			return list.GetRange(0, Math.Min(3, list.Count));
		}

		// Token: 0x06041A43 RID: 268867 RVA: 0x010D4DA8 File Offset: 0x010D2FA8
		public List<MotorParkourRankData> GetLapRankList(int lap, float playerTime)
		{
			string playerName = ModelBase<FunctionModel>.Instance.GetPlayerName();
			MotorParkourRankData myRank = new MotorParkourRankData(playerName, playerTime, Array.Empty<float>(), true);
			myRank.LapTime[lap - 1] = playerTime;
			List<MotorParkourRankData> list = new List<MotorParkourRankData>(this.RecordList);
			list.Add(myRank);
			list.Sort(delegate(MotorParkourRankData a, MotorParkourRankData b)
			{
				if (a.LapTime[lap - 1] - b.LapTime[lap - 1] >= 0f)
				{
					return 1;
				}
				return -1;
			});
			int num = list.FindIndex((MotorParkourRankData data) => data == myRank);
			for (int i = 0; i < list.Count; i++)
			{
				bool isNeedShowGap = Math.Abs(i - num) == 1;
				list[i].UpdateShowTimeString(lap, playerTime, isNeedShowGap);
			}
			return list.GetRange(0, Math.Min(3, list.Count));
		}

		// Token: 0x1700A039 RID: 41017
		// (get) Token: 0x06041A44 RID: 268868 RVA: 0x010D4E80 File Offset: 0x010D3080
		public bool HasLevelRedDot
		{
			get
			{
				if (!this.IsUnLock || this.IsFinished)
				{
					return false;
				}
				HashSet<int> player = LocalStorage.GetPlayer<HashSet<int>>(ELocalStoragePlayerKey.MotorParkourLevelClicked, null);
				return player == null || !player.Contains(this.Id);
			}
		}

		// Token: 0x06041A45 RID: 268869 RVA: 0x010D4EC0 File Offset: 0x010D30C0
		public void ReadLevelRedDot()
		{
			HashSet<int> player = LocalStorage.GetPlayer<HashSet<int>>(ELocalStoragePlayerKey.MotorParkourLevelClicked, null);
			if (player != null)
			{
				player.Add(this.Id);
				LocalStorage.SetPlayer<HashSet<int>>(ELocalStoragePlayerKey.MotorParkourLevelClicked, player);
				return;
			}
			LocalStorage.SetPlayer<HashSet<int>>(ELocalStoragePlayerKey.MotorParkourLevelClicked, new HashSet<int>
			{
				this.Id
			});
		}

		// Token: 0x1700A03A RID: 41018
		// (get) Token: 0x06041A46 RID: 268870 RVA: 0x010D4F14 File Offset: 0x010D3114
		public bool HasRewardRedDot
		{
			get
			{
				bool result = false;
				using (List<MotorParkourTaskData>.Enumerator enumerator = this.TaskList.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						if (enumerator.Current.IsFinished)
						{
							result = true;
							break;
						}
					}
				}
				return result;
			}
		}

		// Token: 0x06041A47 RID: 268871 RVA: 0x010D4F70 File Offset: 0x010D3170
		public List<int> GetCanReceiveRewardIndex()
		{
			List<int> list = new List<int>();
			for (int i = 0; i < this.TaskList.Count; i++)
			{
				if (this.TaskList[i].IsFinished)
				{
					list.Add(i);
				}
			}
			return list;
		}

		// Token: 0x1700A03B RID: 41019
		// (get) Token: 0x06041A48 RID: 268872 RVA: 0x010D4FB4 File Offset: 0x010D31B4
		public int Id
		{
			get
			{
				return this.Config.Id;
			}
		}

		// Token: 0x1700A03C RID: 41020
		// (get) Token: 0x06041A49 RID: 268873 RVA: 0x010D4FC1 File Offset: 0x010D31C1
		public string SmallBgTexture
		{
			get
			{
				return this.Config.SmallBgTexture;
			}
		}

		// Token: 0x1700A03D RID: 41021
		// (get) Token: 0x06041A4A RID: 268874 RVA: 0x010D4FCE File Offset: 0x010D31CE
		public string SelectedSmallBgTexture
		{
			get
			{
				return this.Config.SelectedSmallBgTexture;
			}
		}

		// Token: 0x1700A03E RID: 41022
		// (get) Token: 0x06041A4B RID: 268875 RVA: 0x010D4FDB File Offset: 0x010D31DB
		public string RaceTrackTexture
		{
			get
			{
				return this.Config.RaceTrackTexture;
			}
		}

		// Token: 0x1700A03F RID: 41023
		// (get) Token: 0x06041A4C RID: 268876 RVA: 0x010D4FE8 File Offset: 0x010D31E8
		public string MapTexture
		{
			get
			{
				return this.Config.MapTexture;
			}
		}

		// Token: 0x1700A040 RID: 41024
		// (get) Token: 0x06041A4D RID: 268877 RVA: 0x010D4FF5 File Offset: 0x010D31F5
		public string LevelName
		{
			get
			{
				return this.Config.LevelName;
			}
		}

		// Token: 0x1700A041 RID: 41025
		// (get) Token: 0x06041A4E RID: 268878 RVA: 0x010D5002 File Offset: 0x010D3202
		public string RomanNum
		{
			get
			{
				return this.Config.RomanNum;
			}
		}

		// Token: 0x1700A042 RID: 41026
		// (get) Token: 0x06041A4F RID: 268879 RVA: 0x010D500F File Offset: 0x010D320F
		[Nullable(0)]
		public Span<float> UiOffset
		{
			[NullableContext(0)]
			get
			{
				return this.Config.GetUiOffsetBytes();
			}
		}

		// Token: 0x1700A043 RID: 41027
		// (get) Token: 0x06041A50 RID: 268880 RVA: 0x010D501C File Offset: 0x010D321C
		[Nullable(0)]
		public Span<float> CenterOffset
		{
			[NullableContext(0)]
			get
			{
				return this.Config.GetCenterOffsetBytes();
			}
		}

		// Token: 0x1700A044 RID: 41028
		// (get) Token: 0x06041A51 RID: 268881 RVA: 0x010D5029 File Offset: 0x010D3229
		public float MapScale
		{
			get
			{
				return this.Config.MapScale;
			}
		}

		// Token: 0x1700A045 RID: 41029
		// (get) Token: 0x06041A52 RID: 268882 RVA: 0x010D5036 File Offset: 0x010D3236
		public int SplineId
		{
			get
			{
				return this.Config.SplineId;
			}
		}

		// Token: 0x1700A046 RID: 41030
		// (get) Token: 0x06041A53 RID: 268883 RVA: 0x010D5043 File Offset: 0x010D3243
		public int SplineStartIndex
		{
			get
			{
				return this.Config.SplineStartIndex;
			}
		}

		// Token: 0x1700A047 RID: 41031
		// (get) Token: 0x06041A54 RID: 268884 RVA: 0x010D5050 File Offset: 0x010D3250
		public int SplineEndIndex
		{
			get
			{
				return this.Config.SplineEndIndex;
			}
		}

		// Token: 0x1700A048 RID: 41032
		// (get) Token: 0x06041A55 RID: 268885 RVA: 0x010D505D File Offset: 0x010D325D
		public int RouteTextureRotation
		{
			get
			{
				return this.Config.RouteTextureRotation;
			}
		}

		// Token: 0x1700A049 RID: 41033
		// (get) Token: 0x06041A56 RID: 268886 RVA: 0x010D506A File Offset: 0x010D326A
		public string RouteName
		{
			get
			{
				return this.Config.RouteName;
			}
		}

		// Token: 0x1700A04A RID: 41034
		// (get) Token: 0x06041A57 RID: 268887 RVA: 0x010D5077 File Offset: 0x010D3277
		public int ActivityId
		{
			get
			{
				return this.Config.ActivityId;
			}
		}

		// Token: 0x04024A46 RID: 150086
		private MotorParkour Config;

		// Token: 0x04024A47 RID: 150087
		[Nullable(2)]
		public MotorParkourLevelData PreMotorParkourLevelData;

		// Token: 0x04024A48 RID: 150088
		public readonly List<MotorParkourTaskData> TaskList = new List<MotorParkourTaskData>();

		// Token: 0x04024A49 RID: 150089
		public List<MotorParkourRankData> RecordList = new List<MotorParkourRankData>();

		// Token: 0x04024A4A RID: 150090
		[Nullable(2)]
		private MotorParkourRankData MyRankData;

		// Token: 0x04024A4B RID: 150091
		private int BestRecordTimeInternal;

		// Token: 0x04024A4C RID: 150092
		private long UnlockTimeInterval;
	}
}
