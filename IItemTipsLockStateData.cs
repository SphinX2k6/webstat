using System;
using System.Runtime.CompilerServices;

// Token: 0x020019A0 RID: 6560
[NullableContext(2)]
public interface IItemTipsLockStateData
{
	// Token: 0x17000F5A RID: 3930
	// (get) Token: 0x0600BC61 RID: 48225
	bool? IsShowLockIcon { get; }

	// Token: 0x17000F5B RID: 3931
	// (get) Token: 0x0600BC62 RID: 48226
	bool? IsShowHelpButton { get; }

	// Token: 0x17000F5C RID: 3932
	// (get) Token: 0x0600BC63 RID: 48227
	string TipsTextKey { get; }

	// Token: 0x17000F5D RID: 3933
	// (get) Token: 0x0600BC64 RID: 48228
	[Nullable(new byte[]
	{
		2,
		1
	})]
	string[] TipsTextParams { [return: Nullable(new byte[]
	{
		2,
		1
	})] get; }

	// Token: 0x17000F5E RID: 3934
	// (get) Token: 0x0600BC65 RID: 48229
	Action HelpBtnCallback { get; }
}
