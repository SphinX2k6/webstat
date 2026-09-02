using System;
using System.Runtime.CompilerServices;

// Token: 0x02001BDD RID: 7133
[NullableContext(1)]
[Nullable(0)]
public class FloroRanchUnlockToyData : FloroRanchUnlockDataBase
{
	// Token: 0x0600CF85 RID: 53125 RVA: 0x00371FCF File Offset: 0x003701CF
	public FloroRanchUnlockToyData(int id, bool isUnLock, int conditionId) : base(id, isUnLock, conditionId, EFloroRanchCardType.Toy)
	{
	}

	// Token: 0x0600CF86 RID: 53126 RVA: 0x00371FDB File Offset: 0x003701DB
	public void SetToyData(FloroRanchToyData toyData)
	{
		this.ToyData = toyData;
	}

	// Token: 0x0600CF87 RID: 53127 RVA: 0x00371FE4 File Offset: 0x003701E4
	public FloroRanchToyData GetToyData()
	{
		return this.ToyData;
	}

	// Token: 0x040062D4 RID: 25300
	private FloroRanchToyData ToyData;
}
