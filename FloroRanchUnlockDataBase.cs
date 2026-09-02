using System;

// Token: 0x02001BDA RID: 7130
public abstract class FloroRanchUnlockDataBase
{
	// Token: 0x0600CF7A RID: 53114 RVA: 0x00371F29 File Offset: 0x00370129
	public FloroRanchUnlockDataBase(int id, bool isUnLock, int conditionId, EFloroRanchCardType type)
	{
		this.Id = id;
		this.IsUnLock = isUnLock;
		this.ConditionId = conditionId;
		this.Type = type;
	}

	// Token: 0x0600CF7B RID: 53115 RVA: 0x00371F4E File Offset: 0x0037014E
	public void UpdateInfo(bool isUnLock, int conditionId)
	{
		this.IsUnLock = isUnLock;
		this.ConditionId = conditionId;
	}

	// Token: 0x170010F8 RID: 4344
	// (get) Token: 0x0600CF7C RID: 53116 RVA: 0x00371F5E File Offset: 0x0037015E
	public bool IsDefaultUnlock
	{
		get
		{
			return this.ConditionId == 0;
		}
	}

	// Token: 0x040062CE RID: 25294
	public int Id;

	// Token: 0x040062CF RID: 25295
	public EFloroRanchCardType Type;

	// Token: 0x040062D0 RID: 25296
	public bool IsUnLock;

	// Token: 0x040062D1 RID: 25297
	public int ConditionId;
}
