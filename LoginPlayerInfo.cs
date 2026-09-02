using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Common;

// Token: 0x02002100 RID: 8448
[NullableContext(1)]
[Nullable(0)]
public class LoginPlayerInfo : JsonObjBase
{
	// Token: 0x04007C23 RID: 31779
	public int Code;

	// Token: 0x04007C24 RID: 31780
	public int SdkLoginCode;

	// Token: 0x04007C25 RID: 31781
	public string UserId = string.Empty;

	// Token: 0x04007C26 RID: 31782
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public List<UserRegionInfo> UserInfos;

	// Token: 0x04007C27 RID: 31783
	public string RecommendRegion = string.Empty;
}
