using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Launcher.Platform.PlatformSdk
{
	// Token: 0x020045B2 RID: 17842
	[NullableContext(1)]
	[Nullable(0)]
	public class IQueryGoodsResponse
	{
		// Token: 0x0401A9AF RID: 108975
		public List<IQueryGoodsResponseData> data;

		// Token: 0x0401A9B0 RID: 108976
		public int code;

		// Token: 0x0401A9B1 RID: 108977
		public string msg;

		// Token: 0x0401A9B2 RID: 108978
		public long timestamp;
	}
}
