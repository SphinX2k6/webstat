using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MotorFight
{
	// Token: 0x020066C5 RID: 26309
	[NullableContext(1)]
	[Nullable(0)]
	public class MotorFightLevelData
	{
		// Token: 0x06041B37 RID: 269111 RVA: 0x010D9A67 File Offset: 0x010D7C67
		public MotorFightLevelData(MotorFightLevel config)
		{
			this.Config = config;
		}

		// Token: 0x1700A05E RID: 41054
		// (get) Token: 0x06041B39 RID: 269113 RVA: 0x010D9A8B File Offset: 0x010D7C8B
		// (set) Token: 0x06041B38 RID: 269112 RVA: 0x010D9A76 File Offset: 0x010D7C76
		public long UnlockTime
		{
			get
			{
				return this.UnlockTimeInterval;
			}
			set
			{
				this.UnlockTimeInterval = value / (long)Singleton<TimeUtil>.Instance.InverseMillisecond;
			}
		}

		// Token: 0x06041B3A RID: 269114 RVA: 0x010D9A94 File Offset: 0x010D7C94
		public bool IsReachUnlockTime()
		{
			double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
			return this.UnlockTimeInterval == 0L || (double)this.UnlockTime < serverTime;
		}

		// Token: 0x06041B3B RID: 269115 RVA: 0x010D9AC0 File Offset: 0x010D7CC0
		public bool IsPreLevelFinished()
		{
			return this.PreMotorFightLevelData == null || this.PreMotorFightLevelData.IsFinished;
		}

		// Token: 0x1700A05F RID: 41055
		// (get) Token: 0x06041B3C RID: 269116 RVA: 0x010D9AD7 File Offset: 0x010D7CD7
		public bool IsUnLock
		{
			get
			{
				return this.IsPreLevelFinished() && this.IsReachUnlockTime();
			}
		}

		// Token: 0x1700A060 RID: 41056
		// (get) Token: 0x06041B3E RID: 269118 RVA: 0x010D9AF2 File Offset: 0x010D7CF2
		// (set) Token: 0x06041B3D RID: 269117 RVA: 0x010D9AE9 File Offset: 0x010D7CE9
		public int BestScore
		{
			get
			{
				return this.BestScoreInterval;
			}
			set
			{
				this.BestScoreInterval = value;
			}
		}

		// Token: 0x1700A061 RID: 41057
		// (get) Token: 0x06041B40 RID: 269120 RVA: 0x010D9B03 File Offset: 0x010D7D03
		// (set) Token: 0x06041B3F RID: 269119 RVA: 0x010D9AFA File Offset: 0x010D7CFA
		public bool IsFinished
		{
			get
			{
				return this.IsFinishedInterval;
			}
			set
			{
				this.IsFinishedInterval = value;
			}
		}

		// Token: 0x1700A062 RID: 41058
		// (get) Token: 0x06041B42 RID: 269122 RVA: 0x010D9B14 File Offset: 0x010D7D14
		// (set) Token: 0x06041B41 RID: 269121 RVA: 0x010D9B0B File Offset: 0x010D7D0B
		public int RoleId
		{
			get
			{
				return this.RoleIdInterval;
			}
			set
			{
				this.RoleIdInterval = value;
			}
		}

		// Token: 0x1700A063 RID: 41059
		// (get) Token: 0x06041B43 RID: 269123 RVA: 0x010D9B1C File Offset: 0x010D7D1C
		public bool HasLevelRedDot
		{
			get
			{
				if (!this.IsUnLock || this.IsFinished)
				{
					return false;
				}
				HashSet<int> player = LocalStorage.GetPlayer<HashSet<int>>(ELocalStoragePlayerKey.MotorFightLevelClicked, null);
				return player == null || !player.Contains(this.Id);
			}
		}

		// Token: 0x06041B44 RID: 269124 RVA: 0x010D9B5C File Offset: 0x010D7D5C
		public void ReadLevelRedDot()
		{
			HashSet<int> player = LocalStorage.GetPlayer<HashSet<int>>(ELocalStoragePlayerKey.MotorFightLevelClicked, null);
			if (player != null)
			{
				player.Add(this.Id);
				LocalStorage.SetPlayer<HashSet<int>>(ELocalStoragePlayerKey.MotorFightLevelClicked, player);
				return;
			}
			HashSet<int> value = new HashSet<int>
			{
				this.Id
			};
			LocalStorage.SetPlayer<HashSet<int>>(ELocalStoragePlayerKey.MotorFightLevelClicked, value);
		}

		// Token: 0x1700A064 RID: 41060
		// (get) Token: 0x06041B45 RID: 269125 RVA: 0x010D9BB1 File Offset: 0x010D7DB1
		public int Id
		{
			get
			{
				return this.Config.Id;
			}
		}

		// Token: 0x1700A065 RID: 41061
		// (get) Token: 0x06041B46 RID: 269126 RVA: 0x010D9BBE File Offset: 0x010D7DBE
		public string LevelName
		{
			get
			{
				return this.Config.LevelName;
			}
		}

		// Token: 0x1700A066 RID: 41062
		// (get) Token: 0x06041B47 RID: 269127 RVA: 0x010D9BCB File Offset: 0x010D7DCB
		public string LevelDesc
		{
			get
			{
				return this.Config.LevelDesc;
			}
		}

		// Token: 0x1700A067 RID: 41063
		// (get) Token: 0x06041B48 RID: 269128 RVA: 0x010D9BD8 File Offset: 0x010D7DD8
		public string Number
		{
			get
			{
				return this.Config.SerialNumber;
			}
		}

		// Token: 0x1700A068 RID: 41064
		// (get) Token: 0x06041B49 RID: 269129 RVA: 0x010D9BE5 File Offset: 0x010D7DE5
		public int RewardId
		{
			get
			{
				return this.Config.RewardId;
			}
		}

		// Token: 0x1700A069 RID: 41065
		// (get) Token: 0x06041B4A RID: 269130 RVA: 0x010D9BF2 File Offset: 0x010D7DF2
		public List<int> RecommendRoleIds
		{
			get
			{
				return this.Config.RecommnedRoleListIter().ToList<int>();
			}
		}

		// Token: 0x1700A06A RID: 41066
		// (get) Token: 0x06041B4B RID: 269131 RVA: 0x010D9C04 File Offset: 0x010D7E04
		public EMotorFightLevelType Type
		{
			get
			{
				return (EMotorFightLevelType)this.Config.InstType;
			}
		}

		// Token: 0x1700A06B RID: 41067
		// (get) Token: 0x06041B4C RID: 269132 RVA: 0x010D9C11 File Offset: 0x010D7E11
		public string LevelTexture
		{
			get
			{
				return this.Config.LevelTexture;
			}
		}

		// Token: 0x1700A06C RID: 41068
		// (get) Token: 0x06041B4D RID: 269133 RVA: 0x010D9C1E File Offset: 0x010D7E1E
		public int ActivityId
		{
			get
			{
				return this.Config.ActivityId;
			}
		}

		// Token: 0x1700A06D RID: 41069
		// (get) Token: 0x06041B4E RID: 269134 RVA: 0x010D9C2B File Offset: 0x010D7E2B
		public int Column
		{
			get
			{
				return this.Config.Column;
			}
		}

		// Token: 0x1700A06E RID: 41070
		// (get) Token: 0x06041B4F RID: 269135 RVA: 0x010D9C38 File Offset: 0x010D7E38
		public int Row
		{
			get
			{
				return this.Config.Row;
			}
		}

		// Token: 0x1700A06F RID: 41071
		// (get) Token: 0x06041B50 RID: 269136 RVA: 0x010D9C45 File Offset: 0x010D7E45
		public List<int> PreLevelIds
		{
			get
			{
				return this.Config.PreId().ToList<int>();
			}
		}

		// Token: 0x1700A070 RID: 41072
		// (get) Token: 0x06041B51 RID: 269137 RVA: 0x010D9C57 File Offset: 0x010D7E57
		public string LevelBg
		{
			get
			{
				return this.Config.LevelBg;
			}
		}

		// Token: 0x04024AA5 RID: 150181
		private MotorFightLevel Config;

		// Token: 0x04024AA6 RID: 150182
		[Nullable(2)]
		public MotorFightLevelData PreMotorFightLevelData;

		// Token: 0x04024AA7 RID: 150183
		private long UnlockTimeInterval;

		// Token: 0x04024AA8 RID: 150184
		private int BestScoreInterval;

		// Token: 0x04024AA9 RID: 150185
		private int RoleIdInterval;

		// Token: 0x04024AAA RID: 150186
		private bool IsFinishedInterval;
	}
}
