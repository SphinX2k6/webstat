using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.FlagChallenge
{
	// Token: 0x02005D37 RID: 23863
	[NullableContext(1)]
	public interface IFlagChallengeBuffAddItemData
	{
		// Token: 0x17009890 RID: 39056
		// (get) Token: 0x0603C2E9 RID: 246505
		// (set) Token: 0x0603C2EA RID: 246506
		string IconPath { get; set; }

		// Token: 0x17009891 RID: 39057
		// (get) Token: 0x0603C2EB RID: 246507
		// (set) Token: 0x0603C2EC RID: 246508
		string NameKey { get; set; }

		// Token: 0x17009892 RID: 39058
		// (get) Token: 0x0603C2ED RID: 246509
		// (set) Token: 0x0603C2EE RID: 246510
		string Value { get; set; }
	}
}
