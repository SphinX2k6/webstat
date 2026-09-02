using System;
using System.Runtime.CompilerServices;

// Token: 0x02001C9D RID: 7325
[NullableContext(1)]
public interface IPlayerData
{
	// Token: 0x1700113D RID: 4413
	// (get) Token: 0x0600D6B5 RID: 54965
	int PlayerId { get; }

	// Token: 0x1700113E RID: 4414
	// (get) Token: 0x0600D6B6 RID: 54966
	string PlayerName { get; }

	// Token: 0x1700113F RID: 4415
	// (get) Token: 0x0600D6B7 RID: 54967
	string Signature { get; }
}
