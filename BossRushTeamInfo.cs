using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Module.Activity.ActivityContent.BossRush;

// Token: 0x02001279 RID: 4729
[NullableContext(1)]
[Nullable(0)]
public class BossRushTeamInfo
{
	// Token: 0x06007E81 RID: 32385 RVA: 0x002172A6 File Offset: 0x002154A6
	[NullableContext(2)]
	public BossRushLevelDetailInfo GetCurrentSelectLevel()
	{
		return this.CurrentSelectLevelDetailInfo;
	}

	// Token: 0x06007E82 RID: 32386 RVA: 0x002172AE File Offset: 0x002154AE
	public List<BossRushBuffInfo> GetCurrentSelectBuff()
	{
		return this.CurrentSelectBuff;
	}

	// Token: 0x06007E83 RID: 32387 RVA: 0x002172B6 File Offset: 0x002154B6
	public List<BossRushBuffInfo> GetPrepareSelectBuff()
	{
		return this.PrepareSelectBuff;
	}

	// Token: 0x06007E84 RID: 32388 RVA: 0x002172BE File Offset: 0x002154BE
	public List<BossRushBuffInfo> GetCurrentSelectScoreBuff()
	{
		return this.CurrentSelectScoreBuff;
	}

	// Token: 0x06007E85 RID: 32389 RVA: 0x002172C6 File Offset: 0x002154C6
	public List<BossRushBuffInfo> GetCurrentOptionScoreBuff()
	{
		return this.CurrentOptionScoreBuff;
	}

	// Token: 0x06007E86 RID: 32390 RVA: 0x002172CE File Offset: 0x002154CE
	public List<BossRushBuffInfo> GetPrepareSelectScoreBuff()
	{
		return this.PrepareSelectScoreBuff;
	}

	// Token: 0x06007E87 RID: 32391 RVA: 0x002172D6 File Offset: 0x002154D6
	public int[] GetCurrentTeamMembers()
	{
		return this.CurrentTeamMembers.ToArray();
	}

	// Token: 0x06007E88 RID: 32392 RVA: 0x002172E3 File Offset: 0x002154E3
	public void SetCurrentSelectLevel(BossRushLevelDetailInfo info)
	{
		this.CurrentSelectLevelDetailInfo = info;
	}

	// Token: 0x06007E89 RID: 32393 RVA: 0x002172EC File Offset: 0x002154EC
	public void InitLevelBuff(BossRushBuffInfo[] buff, BossRushBuffInfo[] unlockBuffs, BossRushBuffInfo[] optionBuffs, BossRushBuffInfo[] scoreBuffs, BossRushBuffInfo[] allScoreBuffs)
	{
		this.CurrentSelectBuff = new List<BossRushBuffInfo>();
		foreach (BossRushBuffInfo bossRushBuffInfo in buff)
		{
			BossRushBuffInfo bossRushBuffInfo2 = new BossRushBuffInfo();
			bossRushBuffInfo2.BuffId = bossRushBuffInfo.BuffId;
			bossRushBuffInfo2.Slot = bossRushBuffInfo.Slot;
			bossRushBuffInfo2.ChangeAble = bossRushBuffInfo.ChangeAble;
			bossRushBuffInfo2.State = bossRushBuffInfo.State;
			this.CurrentSelectBuff.Add(bossRushBuffInfo2);
		}
		foreach (BossRushBuffInfo bossRushBuffInfo3 in buff)
		{
			if (bossRushBuffInfo3.BuffId > 0)
			{
				this.CurrentOptionBuff.Add(bossRushBuffInfo3);
			}
		}
		foreach (BossRushBuffInfo bossRushBuffInfo4 in unlockBuffs)
		{
			if (bossRushBuffInfo4.BuffId > 0)
			{
				this.CurrentOptionBuff.Add(bossRushBuffInfo4);
			}
		}
		foreach (BossRushBuffInfo bossRushBuffInfo5 in optionBuffs)
		{
			if (bossRushBuffInfo5.BuffId > 0)
			{
				this.CurrentOptionBuff.Add(bossRushBuffInfo5);
			}
		}
		foreach (BossRushBuffInfo bossRushBuffInfo6 in scoreBuffs)
		{
			BossRushBuffInfo bossRushBuffInfo7 = new BossRushBuffInfo();
			bossRushBuffInfo7.BuffId = bossRushBuffInfo6.BuffId;
			bossRushBuffInfo7.Slot = bossRushBuffInfo6.Slot;
			bossRushBuffInfo7.ChangeAble = bossRushBuffInfo6.ChangeAble;
			bossRushBuffInfo7.State = bossRushBuffInfo6.State;
			this.CurrentSelectScoreBuff.Add(bossRushBuffInfo7);
		}
		foreach (BossRushBuffInfo bossRushBuffInfo8 in allScoreBuffs)
		{
			if (bossRushBuffInfo8.BuffId > 0)
			{
				this.CurrentOptionScoreBuff.Add(bossRushBuffInfo8);
			}
		}
	}

	// Token: 0x06007E8A RID: 32394 RVA: 0x0021746D File Offset: 0x0021566D
	[NullableContext(2)]
	public BossRushBuffInfo GetIndexBuff(int index)
	{
		if (index >= this.CurrentSelectBuff.Count)
		{
			return null;
		}
		return this.CurrentSelectBuff[index];
	}

	// Token: 0x06007E8B RID: 32395 RVA: 0x0021748C File Offset: 0x0021568C
	public List<BossRushBuffInfo> GetOptionBuff()
	{
		List<BossRushBuffInfo> list = new List<BossRushBuffInfo>();
		if (ModelBase<BossRushModel>.Instance.CurrentSelectBuffTabName == EBuffTabName.Normal)
		{
			using (List<BossRushBuffInfo>.Enumerator enumerator = this.CurrentOptionBuff.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					BossRushBuffInfo item = enumerator.Current;
					if (((item.BuffId > 0 && item.State == BossRushBuffSelectionStatus.BuffLocked) || item.Slot < 0) && !list.Any((BossRushBuffInfo x) => x.BuffId == item.BuffId))
					{
						list.Add(item);
					}
				}
				return list;
			}
		}
		using (List<BossRushBuffInfo>.Enumerator enumerator = this.CurrentOptionScoreBuff.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				BossRushBuffInfo item = enumerator.Current;
				if (!list.Any((BossRushBuffInfo x) => x.BuffId == item.BuffId))
				{
					list.Add(item);
				}
			}
		}
		return list;
	}

	// Token: 0x06007E8C RID: 32396 RVA: 0x002175AC File Offset: 0x002157AC
	public void InitPrepareSelectBuff()
	{
		this.PrepareSelectBuff = new List<BossRushBuffInfo>();
		foreach (BossRushBuffInfo item in this.CurrentSelectBuff)
		{
			this.PrepareSelectBuff.Add(item);
		}
	}

	// Token: 0x06007E8D RID: 32397 RVA: 0x00217610 File Offset: 0x00215810
	public void InitPrepareSelectScoreBuff()
	{
		this.PrepareSelectScoreBuff = new List<BossRushBuffInfo>();
		foreach (BossRushBuffInfo item in this.CurrentSelectScoreBuff)
		{
			this.PrepareSelectScoreBuff.Add(item);
		}
	}

	// Token: 0x06007E8E RID: 32398 RVA: 0x00217674 File Offset: 0x00215874
	public void SetIndexPrepareSelectBuff(int index, BossRushBuffInfo buff)
	{
		if (index < this.PrepareSelectBuff.Count)
		{
			this.PrepareSelectBuff[index] = buff;
			return;
		}
		while (this.PrepareSelectBuff.Count <= index)
		{
			this.PrepareSelectBuff.Add(new BossRushBuffInfo());
		}
		this.PrepareSelectBuff[index] = buff;
	}

	// Token: 0x06007E8F RID: 32399 RVA: 0x002176C8 File Offset: 0x002158C8
	[NullableContext(2)]
	public BossRushBuffInfo GetIndexPrepareSelectBuff(int index)
	{
		if (index >= this.PrepareSelectBuff.Count)
		{
			return null;
		}
		return this.PrepareSelectBuff[index];
	}

	// Token: 0x06007E90 RID: 32400 RVA: 0x002176E6 File Offset: 0x002158E6
	[NullableContext(2)]
	public BossRushBuffInfo GetIndexPrepareSelectScoreBuff(int index)
	{
		if (index >= this.PrepareSelectScoreBuff.Count)
		{
			return null;
		}
		return this.PrepareSelectScoreBuff[index];
	}

	// Token: 0x06007E91 RID: 32401 RVA: 0x00217704 File Offset: 0x00215904
	public void SetPrepareSelectBuff(BossRushBuffInfo[] buff)
	{
		this.PrepareSelectBuff = new List<BossRushBuffInfo>();
		foreach (BossRushBuffInfo item in buff)
		{
			this.PrepareSelectBuff.Add(item);
		}
	}

	// Token: 0x06007E92 RID: 32402 RVA: 0x0021773C File Offset: 0x0021593C
	public void SetPrepareSelectScoreBuff(BossRushBuffInfo[] buff)
	{
		this.PrepareSelectScoreBuff = new List<BossRushBuffInfo>();
		foreach (BossRushBuffInfo item in buff)
		{
			this.PrepareSelectScoreBuff.Add(item);
		}
	}

	// Token: 0x06007E93 RID: 32403 RVA: 0x00217774 File Offset: 0x00215974
	public int GetBuffMaxCount()
	{
		return this.CurrentSelectBuff.Count;
	}

	// Token: 0x06007E94 RID: 32404 RVA: 0x00217784 File Offset: 0x00215984
	public void SetIndexTeamMembers(int index, int roleId)
	{
		if (this.CurrentTeamMembers.Count <= index)
		{
			while (this.CurrentTeamMembers.Count < index)
			{
				this.CurrentTeamMembers.Add(0);
			}
			this.CurrentTeamMembers.Add(roleId);
			return;
		}
		this.CurrentTeamMembers[index] = roleId;
	}

	// Token: 0x06007E95 RID: 32405 RVA: 0x002177D8 File Offset: 0x002159D8
	public void ReSortTeamMembers()
	{
		List<int> list = new List<int>();
		using (List<int>.Enumerator enumerator = this.CurrentTeamMembers.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				int num = enumerator.Current;
				if (num > 0)
				{
					list.Add(num);
				}
			}
			goto IL_47;
		}
		IL_40:
		list.Add(0);
		IL_47:
		if (list.Count >= this.CurrentTeamMembers.Count)
		{
			this.CurrentTeamMembers = list;
			return;
		}
		goto IL_40;
	}

	// Token: 0x06007E96 RID: 32406 RVA: 0x00217858 File Offset: 0x00215A58
	public void SetCurrentTeamMembers(int[] members)
	{
		this.CurrentTeamMembers = new List<int>(members);
	}

	// Token: 0x06007E97 RID: 32407 RVA: 0x00217868 File Offset: 0x00215A68
	public int GetRecommendLevel()
	{
		if (this.LevelInfo == null || this.LevelInfo.GetConfig() == null)
		{
			return 0;
		}
		return ConfigBase<InstanceDungeonConfig>.Instance.GetRecommendLevel(this.LevelInfo.GetConfig().Value.InstId, ModelBase<WorldLevelModel>.Instance.CurWorldLevel);
	}

	// Token: 0x06007E98 RID: 32408 RVA: 0x002178C4 File Offset: 0x00215AC4
	public bool GetIfLevelTooLow()
	{
		int num = 0;
		int num2 = 0;
		foreach (int id in this.CurrentTeamMembers)
		{
			RoleInstance roleInstanceById = ModelBase<RoleModel>.Instance.GetRoleInstanceById(id);
			if (roleInstanceById != null)
			{
				num += roleInstanceById.GetLevelData().GetLevel();
				num2++;
			}
			RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(id, true);
			if (roleDataById != null)
			{
				num += roleDataById.GetLevelData().GetLevel();
				num2++;
			}
		}
		return num2 == 0 || (float)num / (float)num2 < (float)this.GetRecommendLevel();
	}

	// Token: 0x06007E99 RID: 32409 RVA: 0x00217974 File Offset: 0x00215B74
	public void Clear()
	{
		this.CurrentSelectBuff = new List<BossRushBuffInfo>();
		this.CurrentTeamMembers = new List<int>();
	}

	// Token: 0x06007E9A RID: 32410 RVA: 0x0021798C File Offset: 0x00215B8C
	public void ClearTeamInfo()
	{
		this.CurrentTeamMembers = new List<int>();
	}

	// Token: 0x04003CA6 RID: 15526
	public int ActivityId;

	// Token: 0x04003CA7 RID: 15527
	[Nullable(2)]
	private BossRushLevelDetailInfo CurrentSelectLevelDetailInfo;

	// Token: 0x04003CA8 RID: 15528
	private List<BossRushBuffInfo> CurrentSelectBuff = new List<BossRushBuffInfo>();

	// Token: 0x04003CA9 RID: 15529
	private readonly List<BossRushBuffInfo> CurrentOptionBuff = new List<BossRushBuffInfo>();

	// Token: 0x04003CAA RID: 15530
	private List<BossRushBuffInfo> PrepareSelectBuff = new List<BossRushBuffInfo>();

	// Token: 0x04003CAB RID: 15531
	private readonly List<BossRushBuffInfo> CurrentSelectScoreBuff = new List<BossRushBuffInfo>();

	// Token: 0x04003CAC RID: 15532
	private readonly List<BossRushBuffInfo> CurrentOptionScoreBuff = new List<BossRushBuffInfo>();

	// Token: 0x04003CAD RID: 15533
	private List<BossRushBuffInfo> PrepareSelectScoreBuff = new List<BossRushBuffInfo>();

	// Token: 0x04003CAE RID: 15534
	private List<int> CurrentTeamMembers = new List<int>();

	// Token: 0x04003CAF RID: 15535
	[Nullable(2)]
	public BossRushLevelDetailInfo LevelInfo;
}
