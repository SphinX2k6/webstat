using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.Module.Kurotato.Data
{
	// Token: 0x02005AF1 RID: 23281
	[NullableContext(1)]
	[Nullable(0)]
	public class KurotatoLevelData
	{
		// Token: 0x0603ADF3 RID: 241139 RVA: 0x00EEE617 File Offset: 0x00EEC817
		public KurotatoLevelData(KurotatoLevel config, int activityId)
		{
			this.Config = config;
			this.ActivityId = activityId;
		}

		// Token: 0x170095CA RID: 38346
		// (get) Token: 0x0603ADF4 RID: 241140 RVA: 0x00EEE62D File Offset: 0x00EEC82D
		// (set) Token: 0x0603ADF5 RID: 241141 RVA: 0x00EEE635 File Offset: 0x00EEC835
		public long UnlockTime
		{
			get
			{
				return this.UnlockTimeInternal;
			}
			set
			{
				this.UnlockTimeInternal = value;
			}
		}

		// Token: 0x0603ADF6 RID: 241142 RVA: 0x00EEE640 File Offset: 0x00EEC840
		public bool IsReachUnlockTime()
		{
			double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
			return this.UnlockTimeInternal == 0L || (double)this.UnlockTime < serverTime;
		}

		// Token: 0x170095CB RID: 38347
		// (get) Token: 0x0603ADF7 RID: 241143 RVA: 0x00EEE66C File Offset: 0x00EEC86C
		// (set) Token: 0x0603ADF8 RID: 241144 RVA: 0x00EEE67E File Offset: 0x00EEC87E
		public bool IsUnLock
		{
			get
			{
				return this.IsReachUnlockTime() && this.IsUnLockInternal;
			}
			set
			{
				this.IsUnLockInternal = value;
			}
		}

		// Token: 0x170095CC RID: 38348
		// (get) Token: 0x0603ADF9 RID: 241145 RVA: 0x00EEE687 File Offset: 0x00EEC887
		// (set) Token: 0x0603ADFA RID: 241146 RVA: 0x00EEE68F File Offset: 0x00EEC88F
		public bool IsFinished
		{
			get
			{
				return this.IsFinishedInternal;
			}
			set
			{
				this.IsFinishedInternal = value;
			}
		}

		// Token: 0x170095CD RID: 38349
		// (get) Token: 0x0603ADFB RID: 241147 RVA: 0x00EEE698 File Offset: 0x00EEC898
		// (set) Token: 0x0603ADFC RID: 241148 RVA: 0x00EEE6A0 File Offset: 0x00EEC8A0
		public int HistoryWave
		{
			get
			{
				return this.HistoryWaveInternal;
			}
			set
			{
				this.HistoryWaveInternal = value;
			}
		}

		// Token: 0x170095CE RID: 38350
		// (get) Token: 0x0603ADFD RID: 241149 RVA: 0x00EEE6A9 File Offset: 0x00EEC8A9
		// (set) Token: 0x0603ADFE RID: 241150 RVA: 0x00EEE6B1 File Offset: 0x00EEC8B1
		public int HistoryKillNum
		{
			get
			{
				return this.HistoryKillNumInternal;
			}
			set
			{
				this.HistoryKillNumInternal = value;
			}
		}

		// Token: 0x170095CF RID: 38351
		// (get) Token: 0x0603ADFF RID: 241151 RVA: 0x00EEE6BA File Offset: 0x00EEC8BA
		// (set) Token: 0x0603AE00 RID: 241152 RVA: 0x00EEE6C2 File Offset: 0x00EEC8C2
		public int HistoryRoleId
		{
			get
			{
				return this.HistoryRoleIdInternal;
			}
			set
			{
				this.HistoryRoleIdInternal = value;
			}
		}

		// Token: 0x170095D0 RID: 38352
		// (get) Token: 0x0603AE01 RID: 241153 RVA: 0x00EEE6CB File Offset: 0x00EEC8CB
		public int ArchiveWave
		{
			get
			{
				KurotatoInstInfo archivedDataInternal = this.ArchivedDataInternal;
				if (archivedDataInternal == null)
				{
					return -1;
				}
				return archivedDataInternal.CurWave;
			}
		}

		// Token: 0x170095D1 RID: 38353
		// (get) Token: 0x0603AE02 RID: 241154 RVA: 0x00EEE6DE File Offset: 0x00EEC8DE
		public bool IsArchiveSpecialWave
		{
			get
			{
				KurotatoInstInfo archivedDataInternal = this.ArchivedDataInternal;
				return archivedDataInternal != null && archivedDataInternal.WaveType == 1;
			}
		}

		// Token: 0x170095D2 RID: 38354
		// (get) Token: 0x0603AE03 RID: 241155 RVA: 0x00EEE6F4 File Offset: 0x00EEC8F4
		// (set) Token: 0x0603AE04 RID: 241156 RVA: 0x00EEE6FC File Offset: 0x00EEC8FC
		[Nullable(2)]
		public KurotatoInstInfo ArchivedData
		{
			[NullableContext(2)]
			get
			{
				return this.ArchivedDataInternal;
			}
			[NullableContext(2)]
			set
			{
				this.ArchivedDataInternal = value;
			}
		}

		// Token: 0x170095D3 RID: 38355
		// (get) Token: 0x0603AE05 RID: 241157 RVA: 0x00EEE705 File Offset: 0x00EEC905
		public bool HasArchivedData
		{
			get
			{
				return this.ArchivedDataInternal != null;
			}
		}

		// Token: 0x170095D4 RID: 38356
		// (get) Token: 0x0603AE06 RID: 241158 RVA: 0x00EEE710 File Offset: 0x00EEC910
		public bool HasHistory
		{
			get
			{
				return this.HistoryRoleIdInternal != 0;
			}
		}

		// Token: 0x170095D5 RID: 38357
		// (get) Token: 0x0603AE07 RID: 241159 RVA: 0x00EEE71B File Offset: 0x00EEC91B
		public bool HasRedDot
		{
			get
			{
				return this.IsUnLock && ModelBase<ActivityModel>.Instance.GetActivityCacheData(this.ActivityId, 0, 4, this.Id, 0) == 0;
			}
		}

		// Token: 0x0603AE08 RID: 241160 RVA: 0x00EEE744 File Offset: 0x00EEC944
		public void ReadRedDot()
		{
			if (!this.IsUnLock)
			{
				return;
			}
			if (!this.HasRedDot)
			{
				return;
			}
			ModelBase<ActivityModel>.Instance.SaveActivityData(this.ActivityId, 4, this.Id, 0, 1);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, this.ActivityId);
		}

		// Token: 0x170095D6 RID: 38358
		// (get) Token: 0x0603AE09 RID: 241161 RVA: 0x00EEE794 File Offset: 0x00EEC994
		public int Id
		{
			get
			{
				return this.Config.Id;
			}
		}

		// Token: 0x170095D7 RID: 38359
		// (get) Token: 0x0603AE0A RID: 241162 RVA: 0x00EEE7B0 File Offset: 0x00EEC9B0
		public string Name
		{
			get
			{
				return this.Config.Name;
			}
		}

		// Token: 0x170095D8 RID: 38360
		// (get) Token: 0x0603AE0B RID: 241163 RVA: 0x00EEE7CC File Offset: 0x00EEC9CC
		public int PreId
		{
			get
			{
				return this.Config.PerId;
			}
		}

		// Token: 0x170095D9 RID: 38361
		// (get) Token: 0x0603AE0C RID: 241164 RVA: 0x00EEE7E8 File Offset: 0x00EEC9E8
		public string Number
		{
			get
			{
				return this.Config.Number;
			}
		}

		// Token: 0x170095DA RID: 38362
		// (get) Token: 0x0603AE0D RID: 241165 RVA: 0x00EEE804 File Offset: 0x00EECA04
		public bool IsEndless
		{
			get
			{
				return this.Config.LevelGroup == 3;
			}
		}

		// Token: 0x170095DB RID: 38363
		// (get) Token: 0x0603AE0E RID: 241166 RVA: 0x00EEE824 File Offset: 0x00EECA24
		public int TotalWave
		{
			get
			{
				return this.Config.TotalWave;
			}
		}

		// Token: 0x170095DC RID: 38364
		// (get) Token: 0x0603AE0F RID: 241167 RVA: 0x00EEE840 File Offset: 0x00EECA40
		public int SortId
		{
			get
			{
				return this.Config.SortId;
			}
		}

		// Token: 0x170095DD RID: 38365
		// (get) Token: 0x0603AE10 RID: 241168 RVA: 0x00EEE85C File Offset: 0x00EECA5C
		public int LevelGroup
		{
			get
			{
				return this.Config.LevelGroup;
			}
		}

		// Token: 0x170095DE RID: 38366
		// (get) Token: 0x0603AE11 RID: 241169 RVA: 0x00EEE878 File Offset: 0x00EECA78
		public int Difficulty
		{
			get
			{
				return this.Config.Difficulty;
			}
		}

		// Token: 0x04021407 RID: 136199
		private readonly KurotatoLevel Config;

		// Token: 0x04021408 RID: 136200
		private readonly int ActivityId;

		// Token: 0x04021409 RID: 136201
		private bool IsUnLockInternal;

		// Token: 0x0402140A RID: 136202
		private bool IsFinishedInternal;

		// Token: 0x0402140B RID: 136203
		private long UnlockTimeInternal;

		// Token: 0x0402140C RID: 136204
		private int HistoryWaveInternal;

		// Token: 0x0402140D RID: 136205
		private int HistoryKillNumInternal;

		// Token: 0x0402140E RID: 136206
		private int HistoryRoleIdInternal;

		// Token: 0x0402140F RID: 136207
		[Nullable(2)]
		private KurotatoInstInfo ArchivedDataInternal;
	}
}
