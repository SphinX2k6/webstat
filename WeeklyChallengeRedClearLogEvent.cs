using System;
using System.Runtime.CompilerServices;

// Token: 0x020021DB RID: 8667
[NullableContext(1)]
[Nullable(0)]
public class WeeklyChallengeRedClearLogEvent : PlayerCommonLogData
{
	// Token: 0x1700142C RID: 5164
	// (get) Token: 0x06010580 RID: 66944 RVA: 0x004772E1 File Offset: 0x004754E1
	// (set) Token: 0x06010581 RID: 66945 RVA: 0x004772E9 File Offset: 0x004754E9
	public override string event_id { get; set; } = "1936";

	// Token: 0x040080D9 RID: 32985
	public int i_season_id;

	// Token: 0x040080DA RID: 32986
	public int i_type;
}
