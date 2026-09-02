using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x0200233E RID: 9022
[NullableContext(1)]
[Nullable(0)]
public static class OnlineDefine
{
	// Token: 0x06011339 RID: 70457 RVA: 0x004B8E7C File Offset: 0x004B707C
	// Note: this type is marked as 'beforefieldinit'.
	static OnlineDefine()
	{
		Dictionary<EContinuingChallenge, string> dictionary = new Dictionary<EContinuingChallenge, string>();
		dictionary[EContinuingChallenge.Accept] = "ContinuingChallengeAccept";
		dictionary[EContinuingChallenge.Leave] = "ContinuingChallengeRefuse";
		dictionary[EContinuingChallenge.Pending] = "ContinuingChallengePending";
		OnlineDefine.onlineContinuingChallengeIcon = dictionary;
		Dictionary<int, string> dictionary2 = new Dictionary<int, string>();
		dictionary2[0] = "OnlineDisabledByNonOnlineQuest";
		dictionary2[1] = "OnlineDisabledByNonOnlinePlay";
		dictionary2[2] = "OnlineDisabledByTrialRole";
		dictionary2[3] = "OnlineDisabledByGravity";
		dictionary2[4] = "OnlineDisabledByTrialRole";
		OnlineDefine.onlineDisabledSourceTipsId = dictionary2;
	}

	// Token: 0x04008748 RID: 34632
	[StaticVariableRuleIgnore]
	public static readonly Dictionary<EContinuingChallenge, string> onlineContinuingChallengeIcon;

	// Token: 0x04008749 RID: 34633
	[StaticVariableRuleIgnore]
	public static readonly Dictionary<int, string> onlineDisabledSourceTipsId;
}
