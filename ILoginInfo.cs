using System;
using System.Runtime.CompilerServices;

// Token: 0x020020E7 RID: 8423
[NullableContext(1)]
public interface ILoginInfo
{
	// Token: 0x1700135B RID: 4955
	// (get) Token: 0x06010162 RID: 65890
	// (set) Token: 0x06010163 RID: 65891
	int LoginCode { get; set; }

	// Token: 0x1700135C RID: 4956
	// (get) Token: 0x06010164 RID: 65892
	// (set) Token: 0x06010165 RID: 65893
	string Uid { get; set; }

	// Token: 0x1700135D RID: 4957
	// (get) Token: 0x06010166 RID: 65894
	// (set) Token: 0x06010167 RID: 65895
	string UserName { get; set; }

	// Token: 0x1700135E RID: 4958
	// (get) Token: 0x06010168 RID: 65896
	// (set) Token: 0x06010169 RID: 65897
	string Token { get; set; }
}
