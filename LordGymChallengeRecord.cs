using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x020021E7 RID: 8679
public class LordGymChallengeRecord
{
	// Token: 0x060105D7 RID: 67031 RVA: 0x00478C8A File Offset: 0x00476E8A
	[NullableContext(2)]
	public IDifficultyVerifyLordChallengeRecord GetLordChallengeRecord(int lordId, int difficulty)
	{
		if (!this.RecordMap.ContainsKey(lordId))
		{
			return null;
		}
		return this.RecordMap[lordId][difficulty];
	}

	// Token: 0x0400810A RID: 33034
	[Nullable(1)]
	private readonly Dictionary<int, List<IDifficultyVerifyLordChallengeRecord>> RecordMap = new Dictionary<int, List<IDifficultyVerifyLordChallengeRecord>>();
}
