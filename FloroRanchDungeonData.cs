using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02001BC1 RID: 7105
[NullableContext(1)]
[Nullable(0)]
public class FloroRanchDungeonData
{
	// Token: 0x0600CEBF RID: 52927 RVA: 0x00370FFF File Offset: 0x0036F1FF
	public FloroRanchDungeonData(FloroRanchIns config)
	{
		this.Config = config;
	}

	// Token: 0x0600CEC0 RID: 52928 RVA: 0x00371019 File Offset: 0x0036F219
	public void PushSubDungeonData(FloroRanchSubDungeonData subDungeonData)
	{
		this.SubDungeonDataList.Add(subDungeonData);
	}

	// Token: 0x0600CEC1 RID: 52929 RVA: 0x00371028 File Offset: 0x0036F228
	public void UpdateUnLockState(bool isUnLock)
	{
		this.IsUnLockInternal = isUnLock;
		foreach (FloroRanchSubDungeonData floroRanchSubDungeonData in this.SubDungeonDataList)
		{
			floroRanchSubDungeonData.IsInstanceUnlock = true;
		}
	}

	// Token: 0x170010A7 RID: 4263
	// (get) Token: 0x0600CEC2 RID: 52930 RVA: 0x00371080 File Offset: 0x0036F280
	public bool IsUnLock
	{
		get
		{
			return this.IsUnLockInternal;
		}
	}

	// Token: 0x170010A8 RID: 4264
	// (get) Token: 0x0600CEC4 RID: 52932 RVA: 0x00371091 File Offset: 0x0036F291
	// (set) Token: 0x0600CEC3 RID: 52931 RVA: 0x00371088 File Offset: 0x0036F288
	public int ConditionId
	{
		get
		{
			return this.ConditionIdInternal;
		}
		set
		{
			this.ConditionIdInternal = value;
		}
	}

	// Token: 0x170010A9 RID: 4265
	// (get) Token: 0x0600CEC5 RID: 52933 RVA: 0x0037109C File Offset: 0x0036F29C
	public int Id
	{
		get
		{
			return this.Config.Id;
		}
	}

	// Token: 0x170010AA RID: 4266
	// (get) Token: 0x0600CEC6 RID: 52934 RVA: 0x003710B8 File Offset: 0x0036F2B8
	public int SortId
	{
		get
		{
			return this.Config.SortId;
		}
	}

	// Token: 0x170010AB RID: 4267
	// (get) Token: 0x0600CEC7 RID: 52935 RVA: 0x003710D4 File Offset: 0x0036F2D4
	public int DelayTime
	{
		get
		{
			return this.Config.DelayTime;
		}
	}

	// Token: 0x0600CEC8 RID: 52936 RVA: 0x003710F0 File Offset: 0x0036F2F0
	public string GetDungeonName()
	{
		return this.Config.Name;
	}

	// Token: 0x0600CEC9 RID: 52937 RVA: 0x0037110B File Offset: 0x0036F30B
	public List<FloroRanchSubDungeonData> GetSubDungeonData()
	{
		return this.SubDungeonDataList;
	}

	// Token: 0x0600CECA RID: 52938 RVA: 0x00371114 File Offset: 0x0036F314
	public FloroRanchSubDungeonData GetLatestSubDungeonData()
	{
		FloroRanchSubDungeonData result = this.SubDungeonDataList[0];
		foreach (FloroRanchSubDungeonData floroRanchSubDungeonData in this.SubDungeonDataList)
		{
			if (!floroRanchSubDungeonData.IsUnLock)
			{
				return result;
			}
			result = floroRanchSubDungeonData;
		}
		return result;
	}

	// Token: 0x170010AC RID: 4268
	// (get) Token: 0x0600CECB RID: 52939 RVA: 0x00371180 File Offset: 0x0036F380
	public bool IsDifficulty
	{
		get
		{
			return this.Config.Difficulty == 1;
		}
	}

	// Token: 0x170010AD RID: 4269
	// (get) Token: 0x0600CECC RID: 52940 RVA: 0x003711A0 File Offset: 0x0036F3A0
	public string RomeNumIcon
	{
		get
		{
			return this.Config.RomeIconPath;
		}
	}

	// Token: 0x170010AE RID: 4270
	// (get) Token: 0x0600CECD RID: 52941 RVA: 0x003711BC File Offset: 0x0036F3BC
	public bool HasRedDot
	{
		get
		{
			if (!this.IsUnLock)
			{
				return false;
			}
			using (List<FloroRanchSubDungeonData>.Enumerator enumerator = this.SubDungeonDataList.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.HasRedDot)
					{
						return true;
					}
				}
			}
			return false;
		}
	}

	// Token: 0x0400628B RID: 25227
	private readonly FloroRanchIns Config;

	// Token: 0x0400628C RID: 25228
	private readonly List<FloroRanchSubDungeonData> SubDungeonDataList = new List<FloroRanchSubDungeonData>();

	// Token: 0x0400628D RID: 25229
	private bool IsUnLockInternal;

	// Token: 0x0400628E RID: 25230
	private int ConditionIdInternal;
}
