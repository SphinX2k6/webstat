using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MotorFight
{
	// Token: 0x020066C4 RID: 26308
	[NullableContext(1)]
	[Nullable(0)]
	public class MotorFightItemData
	{
		// Token: 0x06041B29 RID: 269097 RVA: 0x010D9924 File Offset: 0x010D7B24
		public MotorFightItemData(MotorFightItem config, int? count = null)
		{
			this.Config = config;
			this.Count = count;
		}

		// Token: 0x1700A053 RID: 41043
		// (get) Token: 0x06041B2B RID: 269099 RVA: 0x010D9943 File Offset: 0x010D7B43
		// (set) Token: 0x06041B2A RID: 269098 RVA: 0x010D993A File Offset: 0x010D7B3A
		public bool IsUnLock
		{
			get
			{
				return this.IsUnLockInternal || this.Count != null;
			}
			set
			{
				this.IsUnLockInternal = value;
			}
		}

		// Token: 0x1700A054 RID: 41044
		// (get) Token: 0x06041B2C RID: 269100 RVA: 0x010D995C File Offset: 0x010D7B5C
		public bool HasItemRedDot
		{
			get
			{
				if (!this.IsUnLock)
				{
					return false;
				}
				HashSet<int> player = LocalStorage.GetPlayer<HashSet<int>>(ELocalStoragePlayerKey.MotorFightItemClicked, null);
				return player == null || !player.Contains(this.Id);
			}
		}

		// Token: 0x06041B2D RID: 269101 RVA: 0x010D9994 File Offset: 0x010D7B94
		public void ReadItemRedDot()
		{
			if (!this.IsUnLock)
			{
				return;
			}
			HashSet<int> player = LocalStorage.GetPlayer<HashSet<int>>(ELocalStoragePlayerKey.MotorFightItemClicked, null);
			if (player != null)
			{
				player.Add(this.Id);
				LocalStorage.SetPlayer<HashSet<int>>(ELocalStoragePlayerKey.MotorFightItemClicked, player);
				return;
			}
			HashSet<int> value = new HashSet<int>
			{
				this.Id
			};
			LocalStorage.SetPlayer<HashSet<int>>(ELocalStoragePlayerKey.MotorFightItemClicked, value);
		}

		// Token: 0x1700A055 RID: 41045
		// (get) Token: 0x06041B2E RID: 269102 RVA: 0x010D99F2 File Offset: 0x010D7BF2
		public int Id
		{
			get
			{
				return this.Config.Id;
			}
		}

		// Token: 0x1700A056 RID: 41046
		// (get) Token: 0x06041B2F RID: 269103 RVA: 0x010D99FF File Offset: 0x010D7BFF
		public string Name
		{
			get
			{
				return this.Config.Name;
			}
		}

		// Token: 0x1700A057 RID: 41047
		// (get) Token: 0x06041B30 RID: 269104 RVA: 0x010D9A0C File Offset: 0x010D7C0C
		public string Desc
		{
			get
			{
				return this.Config.Desc;
			}
		}

		// Token: 0x1700A058 RID: 41048
		// (get) Token: 0x06041B31 RID: 269105 RVA: 0x010D9A19 File Offset: 0x010D7C19
		public string[] DescParams
		{
			get
			{
				return this.Config.DescParam();
			}
		}

		// Token: 0x1700A059 RID: 41049
		// (get) Token: 0x06041B32 RID: 269106 RVA: 0x010D9A26 File Offset: 0x010D7C26
		public int Type
		{
			get
			{
				return this.Config.Type;
			}
		}

		// Token: 0x1700A05A RID: 41050
		// (get) Token: 0x06041B33 RID: 269107 RVA: 0x010D9A33 File Offset: 0x010D7C33
		public int Quality
		{
			get
			{
				return this.Config.Quality;
			}
		}

		// Token: 0x1700A05B RID: 41051
		// (get) Token: 0x06041B34 RID: 269108 RVA: 0x010D9A40 File Offset: 0x010D7C40
		public string Icon
		{
			get
			{
				return this.Config.Icon;
			}
		}

		// Token: 0x1700A05C RID: 41052
		// (get) Token: 0x06041B35 RID: 269109 RVA: 0x010D9A4D File Offset: 0x010D7C4D
		public string BigIcon
		{
			get
			{
				return this.Config.IconBig;
			}
		}

		// Token: 0x1700A05D RID: 41053
		// (get) Token: 0x06041B36 RID: 269110 RVA: 0x010D9A5A File Offset: 0x010D7C5A
		public int ConditionId
		{
			get
			{
				return this.Config.UnlockCondition;
			}
		}

		// Token: 0x04024AA2 RID: 150178
		private MotorFightItem Config;

		// Token: 0x04024AA3 RID: 150179
		private bool IsUnLockInternal;

		// Token: 0x04024AA4 RID: 150180
		public int? Count;
	}
}
