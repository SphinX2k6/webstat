using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;

// Token: 0x02001430 RID: 5168
[NullableContext(1)]
[Nullable(0)]
public class MowingTowerLevelDetailInfo
{
	// Token: 0x06008FBD RID: 36797 RVA: 0x0025BDF8 File Offset: 0x00259FF8
	public void Phrase(int activityId, MowTowerLevelsInfo data)
	{
		this.ActivityId = activityId;
		this.SetId(data.LevelsId);
		this.SetFirstScore(data.FirstScore);
		this.SetLowerScore(data.SecondScore);
		this.SetUnLockTime((double)data.UnlockTime / 1000.0);
		this.IsOpen = data.IsUnlock;
		this.BuffInfo = new List<MowingTowerBuffInfo>();
		this.OptionBuffInfo = new List<MowingTowerBuffInfo>();
		if (data.BuffSelection.Count == 0)
		{
			MowingTowerBuffInfo mowingTowerBuffInfo = new MowingTowerBuffInfo();
			mowingTowerBuffInfo.BuffId = 0;
			mowingTowerBuffInfo.Slot = 1;
			mowingTowerBuffInfo.ChangeAble = true;
			this.BuffInfo.Add(mowingTowerBuffInfo);
		}
		else
		{
			foreach (int buffId in data.BuffSelection)
			{
				MowingTowerBuffInfo mowingTowerBuffInfo2 = new MowingTowerBuffInfo();
				mowingTowerBuffInfo2.BuffId = buffId;
				mowingTowerBuffInfo2.Slot = 1;
				mowingTowerBuffInfo2.ChangeAble = true;
				this.BuffInfo.Add(mowingTowerBuffInfo2);
			}
		}
		foreach (int buffId2 in this.GetConfig().Value.OptionalBuff())
		{
			MowingTowerBuffInfo mowingTowerBuffInfo3 = new MowingTowerBuffInfo();
			mowingTowerBuffInfo3.BuffId = buffId2;
			mowingTowerBuffInfo3.Slot = 1;
			mowingTowerBuffInfo3.ChangeAble = true;
			this.OptionBuffInfo.Add(mowingTowerBuffInfo3);
		}
		this.FirstPartRoleInfo = new List<MowingTowerRoleInfo>();
		int num = 0;
		foreach (int roleId in data.FirstRoleSelection)
		{
			MowingTowerRoleInfo mowingTowerRoleInfo = new MowingTowerRoleInfo();
			mowingTowerRoleInfo.RoleId = roleId;
			mowingTowerRoleInfo.Slot = num;
			num++;
			this.FirstPartRoleInfo.Add(mowingTowerRoleInfo);
		}
		this.LowPartRoleInfo = new List<MowingTowerRoleInfo>();
		foreach (int roleId2 in data.SecondRoleSelection)
		{
			MowingTowerRoleInfo mowingTowerRoleInfo2 = new MowingTowerRoleInfo();
			mowingTowerRoleInfo2.RoleId = roleId2;
			mowingTowerRoleInfo2.Slot = num;
			num++;
			this.LowPartRoleInfo.Add(mowingTowerRoleInfo2);
		}
	}

	// Token: 0x06008FBE RID: 36798 RVA: 0x0025C03C File Offset: 0x0025A23C
	public void SetId(int id)
	{
		this.Id = id;
	}

	// Token: 0x06008FBF RID: 36799 RVA: 0x0025C045 File Offset: 0x0025A245
	public void SetFirstScore(int score)
	{
		this.FirstPartScore = score;
	}

	// Token: 0x06008FC0 RID: 36800 RVA: 0x0025C04E File Offset: 0x0025A24E
	public void SetLowerScore(int score)
	{
		this.LowPartScore = score;
	}

	// Token: 0x06008FC1 RID: 36801 RVA: 0x0025C057 File Offset: 0x0025A257
	public void SetUnLockTime(double unLockTime)
	{
		this.UnLockTime = unLockTime;
	}

	// Token: 0x06008FC2 RID: 36802 RVA: 0x0025C060 File Offset: 0x0025A260
	public int GetId()
	{
		return this.Id;
	}

	// Token: 0x06008FC3 RID: 36803 RVA: 0x0025C068 File Offset: 0x0025A268
	public string GetNormalTexturePath()
	{
		return this.GetConfig().Value.NormalTexture;
	}

	// Token: 0x06008FC4 RID: 36804 RVA: 0x0025C08C File Offset: 0x0025A28C
	public string GetLockTexturePath()
	{
		return this.GetConfig().Value.LockTexture;
	}

	// Token: 0x06008FC5 RID: 36805 RVA: 0x0025C0B0 File Offset: 0x0025A2B0
	public int[] GetRecommendElementIdArray(ETeamBelong belongTo)
	{
		return this.GetInstanceDungeonConfig(belongTo).Value.RecommendElement();
	}

	// Token: 0x06008FC6 RID: 36806 RVA: 0x0025C0D4 File Offset: 0x0025A2D4
	public bool GetUnLockState()
	{
		return this.IsOpen;
	}

	// Token: 0x06008FC7 RID: 36807 RVA: 0x0025C0DC File Offset: 0x0025A2DC
	public int GetScore()
	{
		return this.FirstPartScore + this.LowPartScore;
	}

	// Token: 0x06008FC8 RID: 36808 RVA: 0x0025C0EB File Offset: 0x0025A2EB
	public int GetFirstScore()
	{
		return this.FirstPartScore;
	}

	// Token: 0x06008FC9 RID: 36809 RVA: 0x0025C0F3 File Offset: 0x0025A2F3
	public int GetLowScore()
	{
		return this.LowPartScore;
	}

	// Token: 0x06008FCA RID: 36810 RVA: 0x0025C0FC File Offset: 0x0025A2FC
	public string GetLevelTips()
	{
		return this.GetConfig().Value.LevelTips;
	}

	// Token: 0x06008FCB RID: 36811 RVA: 0x0025C120 File Offset: 0x0025A320
	public string GetUnlockTimeText()
	{
		if (Singleton<TimeUtil>.Instance.GetServerTime() < this.UnLockTime)
		{
			CommonDefine.ICountDown remainTimeDataFormat = Singleton<TimeUtil>.Instance.GetRemainTimeDataFormat3(this.UnLockTime - Singleton<TimeUtil>.Instance.GetServerTime());
			return StringUtils.Format(ConfigMultiTextLang.GetLocalTextNew("MowingTowerUnLockTime", null), new string[]
			{
				remainTimeDataFormat.CountDownText
			});
		}
		return ConfigMultiTextLang.GetLocalTextNew("MowingTowerUnlockCondition", null);
	}

	// Token: 0x06008FCC RID: 36812 RVA: 0x0025C186 File Offset: 0x0025A386
	public double GetUnLockTime()
	{
		return this.UnLockTime;
	}

	// Token: 0x06008FCD RID: 36813 RVA: 0x0025C18E File Offset: 0x0025A38E
	public MowTowerLevelsRe? GetConfig()
	{
		return ConfigBase<MowingTowerConfig>.Instance.GetBossMowingTowerConfigById(this.Id);
	}

	// Token: 0x06008FCE RID: 36814 RVA: 0x0025C1A0 File Offset: 0x0025A3A0
	public int GetMaxBuffCount()
	{
		return this.GetConfig().Value.BuffCount;
	}

	// Token: 0x06008FCF RID: 36815 RVA: 0x0025C1C4 File Offset: 0x0025A3C4
	public int GetInstanceDungeonId()
	{
		return this.GetConfig().Value.InstIds()[0];
	}

	// Token: 0x06008FD0 RID: 36816 RVA: 0x0025C1EC File Offset: 0x0025A3EC
	public bool GetIsInfinite()
	{
		return this.GetConfig().Value.IsInfinite;
	}

	// Token: 0x06008FD1 RID: 36817 RVA: 0x0025C210 File Offset: 0x0025A410
	public string GetLevelDesc()
	{
		return this.GetConfig().Value.LevelDesc;
	}

	// Token: 0x06008FD2 RID: 36818 RVA: 0x0025C234 File Offset: 0x0025A434
	public InstanceDungeon? GetInstanceDungeonConfig(ETeamBelong belongTo)
	{
		int id = this.GetConfig().Value.InstIds()[(int)belongTo];
		return ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(id);
	}

	// Token: 0x06008FD3 RID: 36819 RVA: 0x0025C268 File Offset: 0x0025A468
	public MowingTowerTeamInfo ConvertToTeamInfo()
	{
		MowingTowerTeamInfo mowingTowerTeamInfo = new MowingTowerTeamInfo();
		mowingTowerTeamInfo.SetCurrentSelectLevel(this);
		List<int> list = new List<int>();
		foreach (MowingTowerRoleInfo mowingTowerRoleInfo in this.FirstPartRoleInfo)
		{
			list.Add(mowingTowerRoleInfo.RoleId);
		}
		List<int> list2 = new List<int>();
		foreach (MowingTowerRoleInfo mowingTowerRoleInfo2 in this.LowPartRoleInfo)
		{
			list2.Add(mowingTowerRoleInfo2.RoleId);
		}
		mowingTowerTeamInfo.SetCurrentTeamMembers(list.ToArray(), list2.ToArray());
		mowingTowerTeamInfo.LevelInfo = this;
		mowingTowerTeamInfo.InitLevelBuff(this.BuffInfo.ToArray(), this.OptionBuffInfo.ToArray());
		mowingTowerTeamInfo.InitPrepareSelectBuff();
		mowingTowerTeamInfo.ActivityId = this.ActivityId;
		return mowingTowerTeamInfo;
	}

	// Token: 0x040042A8 RID: 17064
	private int ActivityId;

	// Token: 0x040042A9 RID: 17065
	private int Id;

	// Token: 0x040042AA RID: 17066
	private int FirstPartScore;

	// Token: 0x040042AB RID: 17067
	private int LowPartScore;

	// Token: 0x040042AC RID: 17068
	private double UnLockTime;

	// Token: 0x040042AD RID: 17069
	private List<MowingTowerBuffInfo> BuffInfo = new List<MowingTowerBuffInfo>();

	// Token: 0x040042AE RID: 17070
	private List<MowingTowerBuffInfo> OptionBuffInfo = new List<MowingTowerBuffInfo>();

	// Token: 0x040042AF RID: 17071
	private List<MowingTowerRoleInfo> FirstPartRoleInfo = new List<MowingTowerRoleInfo>();

	// Token: 0x040042B0 RID: 17072
	private List<MowingTowerRoleInfo> LowPartRoleInfo = new List<MowingTowerRoleInfo>();

	// Token: 0x040042B1 RID: 17073
	private bool IsOpen;
}
