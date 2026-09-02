using System;

// Token: 0x020010ED RID: 4333
public class GuessJokerRoleData
{
	// Token: 0x060070E8 RID: 28904 RVA: 0x001D7A13 File Offset: 0x001D5C13
	public GuessJokerRoleData(EGuessJokerPlayerType playerType, int maxHp)
	{
		this.PlayerTypeInternal = playerType;
		this.HpInternal = maxHp;
		this.MaxHpInternal = maxHp;
	}

	// Token: 0x060070E9 RID: 28905 RVA: 0x001D7A30 File Offset: 0x001D5C30
	public void RemoveHp(int value)
	{
		int num = this.HpInternal - value;
		if (num < 0)
		{
			num = 0;
		}
		if (num > this.MaxHpInternal)
		{
			num = this.MaxHpInternal;
		}
		this.HpInternal = num;
	}

	// Token: 0x060070EA RID: 28906 RVA: 0x001D7A64 File Offset: 0x001D5C64
	public void SetHp(int value)
	{
		int hpInternal = value;
		if (value < 0)
		{
			hpInternal = 0;
		}
		if (value > this.MaxHpInternal)
		{
			hpInternal = this.MaxHpInternal;
		}
		this.HpInternal = hpInternal;
	}

	// Token: 0x060070EB RID: 28907 RVA: 0x001D7A90 File Offset: 0x001D5C90
	public int GetHp()
	{
		return this.HpInternal;
	}

	// Token: 0x060070EC RID: 28908 RVA: 0x001D7A98 File Offset: 0x001D5C98
	public int GetMaxHp()
	{
		return this.MaxHpInternal;
	}

	// Token: 0x060070ED RID: 28909 RVA: 0x001D7AA0 File Offset: 0x001D5CA0
	public EGuessJokerPlayerType GetPlayerType()
	{
		return this.PlayerTypeInternal;
	}

	// Token: 0x0400364E RID: 13902
	private readonly EGuessJokerPlayerType PlayerTypeInternal;

	// Token: 0x0400364F RID: 13903
	private int HpInternal;

	// Token: 0x04003650 RID: 13904
	private readonly int MaxHpInternal;
}
