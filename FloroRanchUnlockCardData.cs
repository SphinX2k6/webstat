using System;
using System.Runtime.CompilerServices;

// Token: 0x02001BD9 RID: 7129
[NullableContext(1)]
[Nullable(0)]
public class FloroRanchUnlockCardData : FloroRanchUnlockDataBase
{
	// Token: 0x0600CF77 RID: 53111 RVA: 0x00371F0C File Offset: 0x0037010C
	public FloroRanchUnlockCardData(int id, bool isUnLock, int conditionId) : base(id, isUnLock, conditionId, EFloroRanchCardType.Phantom)
	{
	}

	// Token: 0x0600CF78 RID: 53112 RVA: 0x00371F18 File Offset: 0x00370118
	public void SetCardData(FloroRanchCardData cardData)
	{
		this.CardData = cardData;
	}

	// Token: 0x0600CF79 RID: 53113 RVA: 0x00371F21 File Offset: 0x00370121
	public FloroRanchCardData GetCardData()
	{
		return this.CardData;
	}

	// Token: 0x040062CD RID: 25293
	private FloroRanchCardData CardData;
}
