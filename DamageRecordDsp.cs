using System;

// Token: 0x02002EB8 RID: 11960
public class DamageRecordDsp
{
	// Token: 0x06018889 RID: 100489 RVA: 0x006E2598 File Offset: 0x006E0798
	public DamageRecordDsp(float TimeStamp, float DamageValue, bool QteBegin, bool InGame, bool OutGame, bool OutGameSkill)
	{
		this.TimeStamp = TimeStamp;
		this.DamageValue = DamageValue;
		this.QteBegin = QteBegin;
		this.InGame = InGame;
		this.OutGame = OutGame;
		this.OutGameSkill = OutGameSkill;
	}

	// Token: 0x0400BDA3 RID: 48547
	public float TimeStamp;

	// Token: 0x0400BDA4 RID: 48548
	public float DamageValue;

	// Token: 0x0400BDA5 RID: 48549
	public bool QteBegin;

	// Token: 0x0400BDA6 RID: 48550
	public bool InGame;

	// Token: 0x0400BDA7 RID: 48551
	public bool OutGame;

	// Token: 0x0400BDA8 RID: 48552
	public bool OutGameSkill;
}
