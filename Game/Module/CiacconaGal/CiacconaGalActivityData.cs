using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;

namespace CSharpScript.Game.Module.CiacconaGal
{
	// Token: 0x02005EB2 RID: 24242
	[NullableContext(1)]
	[Nullable(0)]
	public class CiacconaGalActivityData
	{
		// Token: 0x0603CED3 RID: 249555 RVA: 0x00F7A23C File Offset: 0x00F7843C
		public CiacconaGalActivityData(CiacconaActivityConfig config)
		{
			this.Config = config;
		}

		// Token: 0x17009986 RID: 39302
		// (get) Token: 0x0603CED4 RID: 249556 RVA: 0x00F7A24B File Offset: 0x00F7844B
		public int Id
		{
			get
			{
				return this.Config.Id;
			}
		}

		// Token: 0x17009987 RID: 39303
		// (get) Token: 0x0603CED5 RID: 249557 RVA: 0x00F7A258 File Offset: 0x00F78458
		public int[] SlotIds
		{
			get
			{
				return this.Config.Slots();
			}
		}

		// Token: 0x17009988 RID: 39304
		// (get) Token: 0x0603CED6 RID: 249558 RVA: 0x00F7A265 File Offset: 0x00F78465
		public int InspirationCount
		{
			get
			{
				return this.Inspiration;
			}
		}

		// Token: 0x17009989 RID: 39305
		// (get) Token: 0x0603CED7 RID: 249559 RVA: 0x00F7A26D File Offset: 0x00F7846D
		public int MaxInspirationCount
		{
			get
			{
				return this.Config.InspirationMaxValue;
			}
		}

		// Token: 0x1700998A RID: 39306
		// (get) Token: 0x0603CED8 RID: 249560 RVA: 0x00F7A27A File Offset: 0x00F7847A
		public long RefreshTime
		{
			get
			{
				return this.RefreshTimestamp.GetValueOrDefault();
			}
		}

		// Token: 0x1700998B RID: 39307
		// (get) Token: 0x0603CED9 RID: 249561 RVA: 0x00F7A287 File Offset: 0x00F78487
		public bool State2Unlock
		{
			get
			{
				return this.State2Unlocked;
			}
		}

		// Token: 0x1700998C RID: 39308
		// (get) Token: 0x0603CEDA RID: 249562 RVA: 0x00F7A28F File Offset: 0x00F7848F
		public bool State3Unlock
		{
			get
			{
				return this.State3Unlocked;
			}
		}

		// Token: 0x1700998D RID: 39309
		// (get) Token: 0x0603CEDB RID: 249563 RVA: 0x00F7A297 File Offset: 0x00F78497
		public long EndTime
		{
			get
			{
				return this.EndTimeInternal;
			}
		}

		// Token: 0x1700998E RID: 39310
		// (get) Token: 0x0603CEDC RID: 249564 RVA: 0x00F7A29F File Offset: 0x00F7849F
		public int RecommendQuestId
		{
			get
			{
				return this.Config.RecommendQuestId;
			}
		}

		// Token: 0x1700998F RID: 39311
		// (get) Token: 0x0603CEDD RID: 249565 RVA: 0x00F7A2AC File Offset: 0x00F784AC
		public string RecommendQuestTipsTextId
		{
			get
			{
				return this.Config.RecommendQuestTips;
			}
		}

		// Token: 0x17009990 RID: 39312
		// (get) Token: 0x0603CEDE RID: 249566 RVA: 0x00F7A2B9 File Offset: 0x00F784B9
		public long RewardEndTime
		{
			get
			{
				return this.RewardEndTimeInternal;
			}
		}

		// Token: 0x17009991 RID: 39313
		// (get) Token: 0x0603CEDF RID: 249567 RVA: 0x00F7A2C1 File Offset: 0x00F784C1
		public long RewardStartTime
		{
			get
			{
				return this.RewardStartTimeInternal;
			}
		}

		// Token: 0x17009992 RID: 39314
		// (get) Token: 0x0603CEE0 RID: 249568 RVA: 0x00F7A2C9 File Offset: 0x00F784C9
		public bool IsInRewardTime
		{
			get
			{
				return Singleton<TimeUtil>.Instance.IsInTimeSpan((double)this.RewardStartTime, (double)this.RewardEndTime);
			}
		}

		// Token: 0x17009993 RID: 39315
		// (get) Token: 0x0603CEE1 RID: 249569 RVA: 0x00F7A2E4 File Offset: 0x00F784E4
		[Nullable(2)]
		public string RewardRemainTimeStr
		{
			[NullableContext(2)]
			get
			{
				double remainTime = (double)this.RewardEndTime - Singleton<TimeUtil>.Instance.GetServerTimeStamp() * Singleton<TimeUtil>.Instance.Millisecond;
				return Singleton<TimeUtil>.Instance.GetRemainTimeDataFormat3(remainTime).CountDownText;
			}
		}

		// Token: 0x17009994 RID: 39316
		// (get) Token: 0x0603CEE2 RID: 249570 RVA: 0x00F7A31F File Offset: 0x00F7851F
		public ECiacconaGalActivityState State
		{
			get
			{
				if (this.State3Unlock)
				{
					return ECiacconaGalActivityState.SubEndingFinish;
				}
				if (this.State2Unlock)
				{
					return ECiacconaGalActivityState.TaskFinish;
				}
				return ECiacconaGalActivityState.Init;
			}
		}

		// Token: 0x17009995 RID: 39317
		// (get) Token: 0x0603CEE3 RID: 249571 RVA: 0x00F7A338 File Offset: 0x00F78538
		public int FinishedSubEndingCount
		{
			get
			{
				int num = 0;
				if (this.ServerData == null)
				{
					return num;
				}
				foreach (CiacconaChapterPbData ciacconaChapterPbData in this.ServerData.ChapterDatas)
				{
					using (IEnumerator<CiacconaChapterResultPbData> enumerator2 = ciacconaChapterPbData.ResultDatas.GetEnumerator())
					{
						while (enumerator2.MoveNext())
						{
							if (enumerator2.Current.Finish)
							{
								num++;
							}
						}
					}
				}
				return num;
			}
		}

		// Token: 0x17009996 RID: 39318
		// (get) Token: 0x0603CEE4 RID: 249572 RVA: 0x00F7A3D0 File Offset: 0x00F785D0
		public int TotalSubEndingCount
		{
			get
			{
				int num = 1;
				if (this.ServerData == null)
				{
					return num;
				}
				foreach (CiacconaChapterPbData ciacconaChapterPbData in this.ServerData.ChapterDatas)
				{
					num += ciacconaChapterPbData.ResultDatas.Count;
				}
				return num;
			}
		}

		// Token: 0x17009997 RID: 39319
		// (get) Token: 0x0603CEE5 RID: 249573 RVA: 0x00F7A438 File Offset: 0x00F78638
		[Nullable(2)]
		public string RemainTimeToNextRefreshStr
		{
			[NullableContext(2)]
			get
			{
				double serverTimeStamp = Singleton<TimeUtil>.Instance.GetServerTimeStamp();
				double num = (double)this.RefreshTime - serverTimeStamp * Singleton<TimeUtil>.Instance.Millisecond;
				if (num < Singleton<TimeUtil>.Instance.Hour)
				{
					return Singleton<TimeUtil>.Instance.GetRemainTimeDataFormat4(num).CountDownText;
				}
				return Singleton<TimeUtil>.Instance.GetRemainTimeDataFormat3(num).CountDownText;
			}
		}

		// Token: 0x0603CEE6 RID: 249574 RVA: 0x00F7A494 File Offset: 0x00F78694
		public void UpdateByServerData(CiacconaActivityPbData data)
		{
			this.ServerData = data;
			this.UpdateInspirationData(data.InspirationData);
			this.State2Unlocked = data.State1Unlock;
			this.State3Unlocked = data.State2Unlock;
			this.RewardStartTimeInternal = data.LimitedStartTime;
			this.RewardEndTimeInternal = data.LimitedEndTime;
		}

		// Token: 0x0603CEE7 RID: 249575 RVA: 0x00F7A4E4 File Offset: 0x00F786E4
		[NullableContext(2)]
		public void UpdateInspirationData(CiacconaInspirationPbData data)
		{
			if (data == null)
			{
				return;
			}
			this.Inspiration = data.Inspiration;
			this.RefreshTimestamp = new long?(data.RefreshTime);
		}

		// Token: 0x0603CEE8 RID: 249576 RVA: 0x00F7A507 File Offset: 0x00F78707
		public void UpdateState(CiacconaActivityStateUnlockUpdateNotify data)
		{
			this.State2Unlocked = data.State1Unlock;
			this.State3Unlocked = data.State2Unlock;
		}

		// Token: 0x0603CEE9 RID: 249577 RVA: 0x00F7A521 File Offset: 0x00F78721
		public void UpdateEndTime(long endTime)
		{
			this.EndTimeInternal = endTime;
		}

		// Token: 0x04022352 RID: 140114
		private int Inspiration;

		// Token: 0x04022353 RID: 140115
		private long? RefreshTimestamp;

		// Token: 0x04022354 RID: 140116
		private bool State2Unlocked;

		// Token: 0x04022355 RID: 140117
		private bool State3Unlocked;

		// Token: 0x04022356 RID: 140118
		private long EndTimeInternal;

		// Token: 0x04022357 RID: 140119
		private long RewardEndTimeInternal;

		// Token: 0x04022358 RID: 140120
		private long RewardStartTimeInternal;

		// Token: 0x04022359 RID: 140121
		[Nullable(2)]
		private CiacconaActivityPbData ServerData;

		// Token: 0x0402235A RID: 140122
		private CiacconaActivityConfig Config;
	}
}
