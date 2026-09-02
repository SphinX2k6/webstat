using System;
using System.Runtime.CompilerServices;
using System.Text;
using Aki.Config;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004D9F RID: 19871
	[NullableContext(1)]
	[Nullable(0)]
	public class TrapDefenseBdBuffData
	{
		// Token: 0x06033770 RID: 210800 RVA: 0x00CDF1B2 File Offset: 0x00CDD3B2
		public static TrapDefenseBdBuffData Create(TrapDefenseBdGroup config)
		{
			TrapDefenseBdBuffData trapDefenseBdBuffData = new TrapDefenseBdBuffData(config.Id);
			trapDefenseBdBuffData.Init(config);
			return trapDefenseBdBuffData;
		}

		// Token: 0x06033771 RID: 210801 RVA: 0x00CDF1C7 File Offset: 0x00CDD3C7
		private TrapDefenseBdBuffData(int id)
		{
			this.Id = id;
			this.Level = 1;
			this.MaxLevel = 1;
		}

		// Token: 0x06033772 RID: 210802 RVA: 0x00CDF1E4 File Offset: 0x00CDD3E4
		private void Init(TrapDefenseBdGroup config)
		{
			this.Config = config;
			this.MaxLevel = ConfigBase<TrapDefenseConfig>.Instance.GetBdBuffListByGroupId(config.Id).Count;
			this.UpdateBdBuffConfig();
		}

		// Token: 0x06033773 RID: 210803 RVA: 0x00CDF210 File Offset: 0x00CDD410
		private void UpdateBdBuffConfig()
		{
			int level = this.Level;
			int id = this.Config.Id;
			TrapDefenseBdBuff bdBuffConfig = this.BdBuffConfig;
			this.BdBuffConfig = ConfigBase<TrapDefenseConfig>.Instance.GetBdBuffByLevelAndGroup(level, id).GetValueOrDefault(bdBuffConfig);
		}

		// Token: 0x06033774 RID: 210804 RVA: 0x00CDF252 File Offset: 0x00CDD452
		public void SetLevel(int level)
		{
			if (this.Level == level)
			{
				return;
			}
			if (level < 1)
			{
				return;
			}
			if (level > this.MaxLevel)
			{
				return;
			}
			this.Level = level;
			this.UpdateBdBuffConfig();
		}

		// Token: 0x06033775 RID: 210805 RVA: 0x00CDF27A File Offset: 0x00CDD47A
		public void SetActive(bool active)
		{
			this.IsActive = active;
		}

		// Token: 0x06033776 RID: 210806 RVA: 0x00CDF283 File Offset: 0x00CDD483
		public void SetUnlock(bool unlock)
		{
			this.IsUnlock = unlock;
		}

		// Token: 0x06033777 RID: 210807 RVA: 0x00CDF28C File Offset: 0x00CDD48C
		public int GetActiveBdProgressNum()
		{
			if (!this.IsActive)
			{
				return 0;
			}
			return this.BdBuffConfig.Level;
		}

		// Token: 0x06033778 RID: 210808 RVA: 0x00CDF2A3 File Offset: 0x00CDD4A3
		public bool IsStrengthenFinish()
		{
			return this.IsStrengthen(this.BdBuffConfig);
		}

		// Token: 0x06033779 RID: 210809 RVA: 0x00CDF2B1 File Offset: 0x00CDD4B1
		public bool IsCanStrengthen()
		{
			return this.MaxLevel > 1;
		}

		// Token: 0x0603377A RID: 210810 RVA: 0x00CDF2BC File Offset: 0x00CDD4BC
		public bool IsStrengthen(TrapDefenseBdBuff config)
		{
			return config.Level > 1;
		}

		// Token: 0x0603377B RID: 210811 RVA: 0x00CDF2C8 File Offset: 0x00CDD4C8
		public TrapDefenseBdData GetBelongBdData()
		{
			int belongBd = this.Config.BelongBd;
			return ModelBase<TrapDefenseModel>.Instance.RougeModeData.BdDataMap[belongBd];
		}

		// Token: 0x0603377C RID: 210812 RVA: 0x00CDF2F6 File Offset: 0x00CDD4F6
		public void SetIsShowStrengthen(bool show)
		{
			this.IsShowStrengthen = show;
		}

		// Token: 0x0603377D RID: 210813 RVA: 0x00CDF300 File Offset: 0x00CDD500
		public TrapDefenseBdBuff GetStrengthenConfig()
		{
			if (this.IsStrengthenFinish())
			{
				return this.BdBuffConfig;
			}
			if (!this.IsCanStrengthen())
			{
				return this.BdBuffConfig;
			}
			TrapDefenseBdBuff? bdBuffByLevelAndGroup = ConfigBase<TrapDefenseConfig>.Instance.GetBdBuffByLevelAndGroup(this.Level + 1, this.Config.Id);
			if (bdBuffByLevelAndGroup != null)
			{
				return bdBuffByLevelAndGroup.Value;
			}
			return this.BdBuffConfig;
		}

		// Token: 0x0603377E RID: 210814 RVA: 0x00CDF360 File Offset: 0x00CDD560
		public TrapDefenseBdBuff GetStrengthenBeforeConfig()
		{
			if (this.IsStrengthenFinish())
			{
				TrapDefenseBdBuff? bdBuffByLevelAndGroup = ConfigBase<TrapDefenseConfig>.Instance.GetBdBuffByLevelAndGroup(1, this.Config.Id);
				if (bdBuffByLevelAndGroup != null)
				{
					return bdBuffByLevelAndGroup.Value;
				}
			}
			return this.BdBuffConfig;
		}

		// Token: 0x0603377F RID: 210815 RVA: 0x00CDF3A3 File Offset: 0x00CDD5A3
		public TrapDefenseBdBuff GetShowBdBuffConfig(bool? isInst = null)
		{
			if (isInst != null && isInst.Value)
			{
				return this.BdBuffConfig;
			}
			if (this.IsShowStrengthen)
			{
				return this.GetStrengthenConfig();
			}
			return this.GetStrengthenBeforeConfig();
		}

		// Token: 0x06033780 RID: 210816 RVA: 0x00CDF3D3 File Offset: 0x00CDD5D3
		public bool IsCanSwitchStrengthen(bool? isInst = null)
		{
			return (isInst == null || !isInst.Value) && this.IsCanStrengthen() && this.IsUnlock;
		}

		// Token: 0x06033781 RID: 210817 RVA: 0x00CDF3F9 File Offset: 0x00CDD5F9
		public void ActiveAddBuff()
		{
			if (this.IsActive)
			{
				this.SetLevel(2);
				return;
			}
			this.SetActive(true);
		}

		// Token: 0x06033782 RID: 210818 RVA: 0x00CDF414 File Offset: 0x00CDD614
		public string GetShowActorLabelStr()
		{
			int id = this.Id;
			int quality = this.Config.Quality;
			int id2 = this.BdBuffConfig.Id;
			int level = this.BdBuffConfig.Level;
			bool isActive = this.IsActive;
			bool isUnlock = this.IsUnlock;
			int maxLevel = this.MaxLevel;
			return new StringBuilder().Append("BdBuff_").Append(id).Append("_Bid-").Append(id2).Append("_Quality-").Append(quality).Append("_Lv-").Append(level).Append("_Active-").Append(isActive).Append("_Unlock-").Append(isUnlock).Append("_MaxLv-").Append(maxLevel).ToString();
		}

		// Token: 0x0401DCFE RID: 122110
		public int Id;

		// Token: 0x0401DCFF RID: 122111
		public int Level;

		// Token: 0x0401DD00 RID: 122112
		public TrapDefenseBdGroup Config;

		// Token: 0x0401DD01 RID: 122113
		public TrapDefenseBdBuff BdBuffConfig;

		// Token: 0x0401DD02 RID: 122114
		public bool IsShowStrengthen;

		// Token: 0x0401DD03 RID: 122115
		public bool IsActive;

		// Token: 0x0401DD04 RID: 122116
		public bool IsUnlock;

		// Token: 0x0401DD05 RID: 122117
		public int MaxLevel;
	}
}
