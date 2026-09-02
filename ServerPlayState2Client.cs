using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02001B71 RID: 7025
public static class ServerPlayState2Client
{
	// Token: 0x0600CBFF RID: 52223 RVA: 0x003665D6 File Offset: 0x003647D6
	// Note: this type is marked as 'beforefieldinit'.
	static ServerPlayState2Client()
	{
		Dictionary<int, EPlayPointState> dictionary = new Dictionary<int, EPlayPointState>();
		dictionary[0] = EPlayPointState.Locked;
		dictionary[1] = EPlayPointState.ToBeCompleted;
		dictionary[2] = EPlayPointState.ToBeCompleted;
		dictionary[3] = EPlayPointState.Completed;
		dictionary[4] = EPlayPointState.Completed;
		ServerPlayState2Client.Map = dictionary;
	}

	// Token: 0x0400618C RID: 24972
	[Nullable(1)]
	[StaticVariableRuleIgnore]
	public static readonly Dictionary<int, EPlayPointState> Map;
}
