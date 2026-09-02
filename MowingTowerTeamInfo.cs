using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x0200143F RID: 5183
[NullableContext(1)]
[Nullable(0)]
public class MowingTowerTeamInfo
{
	// Token: 0x06009034 RID: 36916 RVA: 0x0025E83B File Offset: 0x0025CA3B
	[NullableContext(2)]
	public MowingTowerLevelDetailInfo GetCurrentSelectLevel()
	{
		return this.CurrentSelectLevelDetailInfo;
	}

	// Token: 0x06009035 RID: 36917 RVA: 0x0025E843 File Offset: 0x0025CA43
	public List<MowingTowerBuffInfo> GetCurrentSelectBuff()
	{
		return this.CurrentSelectBuff;
	}

	// Token: 0x06009036 RID: 36918 RVA: 0x0025E84B File Offset: 0x0025CA4B
	public List<MowingTowerBuffInfo> GetPrepareSelectBuff()
	{
		return this.PrepareSelectBuff;
	}

	// Token: 0x06009037 RID: 36919 RVA: 0x0025E853 File Offset: 0x0025CA53
	[return: Nullable(new byte[]
	{
		0,
		1,
		1
	})]
	public ValueTuple<List<int>, List<int>> GetCurrentTeamMembers()
	{
		return new ValueTuple<List<int>, List<int>>(this.CurrentTeamFirstMembers, this.CurrentTeamLowMembers);
	}

	// Token: 0x06009038 RID: 36920 RVA: 0x0025E866 File Offset: 0x0025CA66
	public void SetCurrentSelectLevel(MowingTowerLevelDetailInfo info)
	{
		this.CurrentSelectLevelDetailInfo = info;
	}

	// Token: 0x06009039 RID: 36921 RVA: 0x0025E870 File Offset: 0x0025CA70
	public void InitLevelBuff(MowingTowerBuffInfo[] buff, MowingTowerBuffInfo[] unlockBuffs)
	{
		this.CurrentSelectBuff = new List<MowingTowerBuffInfo>();
		foreach (MowingTowerBuffInfo mowingTowerBuffInfo in buff)
		{
			MowingTowerBuffInfo mowingTowerBuffInfo2 = new MowingTowerBuffInfo();
			mowingTowerBuffInfo2.BuffId = mowingTowerBuffInfo.BuffId;
			mowingTowerBuffInfo2.Slot = mowingTowerBuffInfo.Slot;
			mowingTowerBuffInfo2.ChangeAble = mowingTowerBuffInfo.ChangeAble;
			this.CurrentSelectBuff.Add(mowingTowerBuffInfo2);
		}
		foreach (MowingTowerBuffInfo mowingTowerBuffInfo3 in buff)
		{
			if (mowingTowerBuffInfo3.BuffId > 0)
			{
				this.CurrentOptionBuff.Add(mowingTowerBuffInfo3);
			}
		}
		foreach (MowingTowerBuffInfo mowingTowerBuffInfo4 in unlockBuffs)
		{
			if (mowingTowerBuffInfo4.BuffId > 0)
			{
				this.CurrentOptionBuff.Add(mowingTowerBuffInfo4);
			}
		}
	}

	// Token: 0x0600903A RID: 36922 RVA: 0x0025E92A File Offset: 0x0025CB2A
	[NullableContext(2)]
	public MowingTowerBuffInfo GetIndexBuff(int index)
	{
		if (index >= this.CurrentSelectBuff.Count)
		{
			return null;
		}
		return this.CurrentSelectBuff[index];
	}

	// Token: 0x0600903B RID: 36923 RVA: 0x0025E948 File Offset: 0x0025CB48
	public List<MowingTowerBuffInfo> GetOptionBuff()
	{
		List<MowingTowerBuffInfo> list = new List<MowingTowerBuffInfo>();
		using (List<MowingTowerBuffInfo>.Enumerator enumerator = this.CurrentOptionBuff.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				MowingTowerBuffInfo item = enumerator.Current;
				if ((item.BuffId > 0 || item.Slot < 0) && list.FindIndex((MowingTowerBuffInfo x) => x.BuffId == item.BuffId) == -1)
				{
					list.Add(item);
				}
			}
		}
		return list;
	}

	// Token: 0x0600903C RID: 36924 RVA: 0x0025E9E4 File Offset: 0x0025CBE4
	public void InitPrepareSelectBuff()
	{
		this.PrepareSelectBuff = new List<MowingTowerBuffInfo>();
		foreach (MowingTowerBuffInfo item in this.CurrentSelectBuff)
		{
			this.PrepareSelectBuff.Add(item);
		}
	}

	// Token: 0x0600903D RID: 36925 RVA: 0x0025EA48 File Offset: 0x0025CC48
	public void SetIndexPrepareSelectBuff(int index, MowingTowerBuffInfo buff)
	{
		this.PrepareSelectBuff[index] = buff;
	}

	// Token: 0x0600903E RID: 36926 RVA: 0x0025EA57 File Offset: 0x0025CC57
	[NullableContext(2)]
	public MowingTowerBuffInfo GetIndexPrepareSelectBuff(int index)
	{
		return this.PrepareSelectBuff[index];
	}

	// Token: 0x0600903F RID: 36927 RVA: 0x0025EA68 File Offset: 0x0025CC68
	public void SetPrepareSelectBuff(MowingTowerBuffInfo[] buff)
	{
		this.PrepareSelectBuff = new List<MowingTowerBuffInfo>();
		foreach (MowingTowerBuffInfo item in buff)
		{
			this.PrepareSelectBuff.Add(item);
		}
	}

	// Token: 0x06009040 RID: 36928 RVA: 0x0025EAA0 File Offset: 0x0025CCA0
	public int GetBuffMaxCount()
	{
		return this.CurrentSelectBuff.Count;
	}

	// Token: 0x06009041 RID: 36929 RVA: 0x0025EAAD File Offset: 0x0025CCAD
	public void SetIndexTeamMembers(ETeamBelong belong, int index, int roleId)
	{
		if (belong == ETeamBelong.FirstPart)
		{
			this.SetIndexFirstTeamMembers(index, roleId);
			return;
		}
		if (belong == ETeamBelong.LowPart)
		{
			this.SetIndexLowTeamMembers(index, roleId);
		}
	}

	// Token: 0x06009042 RID: 36930 RVA: 0x0025EAC7 File Offset: 0x0025CCC7
	public void SetIndexFirstTeamMembers(int index, int roleId)
	{
		if (this.CurrentTeamFirstMembers.Count <= index)
		{
			this.CurrentTeamFirstMembers.Add(roleId);
			return;
		}
		this.CurrentTeamFirstMembers[index] = roleId;
	}

	// Token: 0x06009043 RID: 36931 RVA: 0x0025EAF1 File Offset: 0x0025CCF1
	public void SetIndexLowTeamMembers(int index, int roleId)
	{
		if (this.CurrentTeamLowMembers.Count <= index)
		{
			this.CurrentTeamLowMembers.Add(roleId);
			return;
		}
		this.CurrentTeamLowMembers[index] = roleId;
	}

	// Token: 0x06009044 RID: 36932 RVA: 0x0025EB1B File Offset: 0x0025CD1B
	public void ReSortTeamMembers(ETeamBelong belong)
	{
		if (belong == ETeamBelong.FirstPart)
		{
			this.ReSortFirstTeamMembers();
			return;
		}
		if (belong == ETeamBelong.LowPart)
		{
			this.ReSortLowTeamMembers();
		}
	}

	// Token: 0x06009045 RID: 36933 RVA: 0x0025EB34 File Offset: 0x0025CD34
	public void ReSortFirstTeamMembers()
	{
		List<int> list = new List<int>();
		foreach (int num in this.CurrentTeamFirstMembers)
		{
			if (num > 0)
			{
				list.Add(num);
			}
		}
		for (int i = list.Count; i < this.CurrentTeamFirstMembers.Count; i++)
		{
			list.Add(0);
		}
		this.CurrentTeamFirstMembers = list;
	}

	// Token: 0x06009046 RID: 36934 RVA: 0x0025EBBC File Offset: 0x0025CDBC
	public void ReSortLowTeamMembers()
	{
		List<int> list = new List<int>();
		foreach (int num in this.CurrentTeamLowMembers)
		{
			if (num > 0)
			{
				list.Add(num);
			}
		}
		for (int i = list.Count; i < this.CurrentTeamLowMembers.Count; i++)
		{
			list.Add(0);
		}
		this.CurrentTeamLowMembers = list;
	}

	// Token: 0x06009047 RID: 36935 RVA: 0x0025EC44 File Offset: 0x0025CE44
	public void SetCurrentTeamMembers(int[] firstPartRole, int[] lowPartRole)
	{
		this.CurrentTeamFirstMembers = new List<int>(firstPartRole);
		this.CurrentTeamLowMembers = new List<int>(lowPartRole);
	}

	// Token: 0x06009048 RID: 36936 RVA: 0x0025EC60 File Offset: 0x0025CE60
	public int GetRecommendLevel()
	{
		return ConfigBase<InstanceDungeonConfig>.Instance.GetRecommendLevel(this.LevelInfo.GetConfig().Value.InstIds()[0], ModelBase<WorldLevelModel>.Instance.CurWorldLevel);
	}

	// Token: 0x06009049 RID: 36937 RVA: 0x0025ECA0 File Offset: 0x0025CEA0
	public bool GetIfLevelTooLow()
	{
		float num = 0f;
		int num2 = 0;
		foreach (int id in this.CurrentTeamFirstMembers)
		{
			RoleInstance roleInstanceById = ModelBase<RoleModel>.Instance.GetRoleInstanceById(id);
			if (roleInstanceById != null)
			{
				num += (float)roleInstanceById.GetLevelData().GetLevel();
				num2++;
			}
			RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(id, true);
			if (roleDataById != null)
			{
				num += (float)roleDataById.GetLevelData().GetLevel();
				num2++;
			}
		}
		float num3 = (num2 > 0) ? (num / (float)num2) : 0f;
		if (num3 < (float)this.GetRecommendLevel() && num3 != 0f)
		{
			return true;
		}
		foreach (int id2 in this.CurrentTeamLowMembers)
		{
			RoleInstance roleInstanceById2 = ModelBase<RoleModel>.Instance.GetRoleInstanceById(id2);
			if (roleInstanceById2 != null)
			{
				num += (float)roleInstanceById2.GetLevelData().GetLevel();
				num2++;
			}
			RoleDataBase roleDataById2 = ModelBase<RoleModel>.Instance.GetRoleDataById(id2, true);
			if (roleDataById2 != null)
			{
				num += (float)roleDataById2.GetLevelData().GetLevel();
				num2++;
			}
		}
		float num4 = (num2 > 0) ? (num / (float)num2) : 0f;
		return num4 < (float)this.GetRecommendLevel() && num4 != 0f;
	}

	// Token: 0x0600904A RID: 36938 RVA: 0x0025EE18 File Offset: 0x0025D018
	public void Clear()
	{
		this.CurrentSelectBuff = new List<MowingTowerBuffInfo>();
		this.CurrentTeamFirstMembers = new List<int>();
		this.CurrentTeamLowMembers = new List<int>();
	}

	// Token: 0x040042EB RID: 17131
	public int ActivityId;

	// Token: 0x040042EC RID: 17132
	[Nullable(2)]
	private MowingTowerLevelDetailInfo CurrentSelectLevelDetailInfo;

	// Token: 0x040042ED RID: 17133
	private List<MowingTowerBuffInfo> CurrentSelectBuff = new List<MowingTowerBuffInfo>();

	// Token: 0x040042EE RID: 17134
	private readonly List<MowingTowerBuffInfo> CurrentOptionBuff = new List<MowingTowerBuffInfo>();

	// Token: 0x040042EF RID: 17135
	private List<MowingTowerBuffInfo> PrepareSelectBuff = new List<MowingTowerBuffInfo>();

	// Token: 0x040042F0 RID: 17136
	private List<int> CurrentTeamFirstMembers = new List<int>();

	// Token: 0x040042F1 RID: 17137
	private List<int> CurrentTeamLowMembers = new List<int>();

	// Token: 0x040042F2 RID: 17138
	[Nullable(2)]
	public MowingTowerLevelDetailInfo LevelInfo;
}
