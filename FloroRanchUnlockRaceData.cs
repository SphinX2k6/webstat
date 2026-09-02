using System;
using System.Runtime.CompilerServices;

// Token: 0x02001BDB RID: 7131
[NullableContext(1)]
[Nullable(0)]
public class FloroRanchUnlockRaceData : FloroRanchUnlockDataBase
{
	// Token: 0x0600CF7D RID: 53117 RVA: 0x00371F69 File Offset: 0x00370169
	public FloroRanchUnlockRaceData(int id, bool isUnLock, int conditionId) : base(id, isUnLock, conditionId, EFloroRanchCardType.Race)
	{
	}

	// Token: 0x0600CF7E RID: 53118 RVA: 0x00371F75 File Offset: 0x00370175
	public void SetRaceData(FloroRanchRaceData raceData)
	{
		this.RaceData = raceData;
	}

	// Token: 0x0600CF7F RID: 53119 RVA: 0x00371F7E File Offset: 0x0037017E
	public FloroRanchRaceData GetRaceData()
	{
		return this.RaceData;
	}

	// Token: 0x0600CF80 RID: 53120 RVA: 0x00371F86 File Offset: 0x00370186
	protected string GetConditionText()
	{
		return LevelGeneralCommons.GetConditionGroupHintText(this.ConditionId) ?? "";
	}

	// Token: 0x040062D2 RID: 25298
	private FloroRanchRaceData RaceData;
}
