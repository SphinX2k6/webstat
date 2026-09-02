using System;
using System.Runtime.CompilerServices;

// Token: 0x02001B2B RID: 6955
[NullableContext(1)]
public interface ICdnServerAddress
{
	// Token: 0x17001012 RID: 4114
	// (get) Token: 0x0600C87B RID: 51323
	string GachaDetailServerAddressPrefix { get; }

	// Token: 0x17001013 RID: 4115
	// (get) Token: 0x0600C87C RID: 51324
	string GachaDetailServerId { get; }

	// Token: 0x17001014 RID: 4116
	// (get) Token: 0x0600C87D RID: 51325
	string GachaRecordServerAddressPrefix { get; }

	// Token: 0x17001015 RID: 4117
	// (get) Token: 0x0600C87E RID: 51326
	string GachaRecordServerId { get; }

	// Token: 0x17001016 RID: 4118
	// (get) Token: 0x0600C87F RID: 51327
	string NoticeServerPrefixAddress { get; }

	// Token: 0x17001017 RID: 4119
	// (get) Token: 0x0600C880 RID: 51328
	string MarqueeServerId { get; }

	// Token: 0x17001018 RID: 4120
	// (get) Token: 0x0600C881 RID: 51329
	string GachaInfoServerPrefixAddress { get; }

	// Token: 0x17001019 RID: 4121
	// (get) Token: 0x0600C882 RID: 51330
	string GachaInfoServerId { get; }
}
