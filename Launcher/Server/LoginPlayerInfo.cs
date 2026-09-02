using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Launcher.Server
{
	// Token: 0x02004539 RID: 17721
	[NullableContext(1)]
	[Nullable(0)]
	public class LoginPlayerInfo
	{
		// Token: 0x0401A7F4 RID: 108532
		public int Code;

		// Token: 0x0401A7F5 RID: 108533
		public int SdkLoginCode;

		// Token: 0x0401A7F6 RID: 108534
		public string UserId = "";

		// Token: 0x0401A7F7 RID: 108535
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public List<UserRegionInfo> UserInfos;

		// Token: 0x0401A7F8 RID: 108536
		public string RecommendRegion = "";
	}
}
