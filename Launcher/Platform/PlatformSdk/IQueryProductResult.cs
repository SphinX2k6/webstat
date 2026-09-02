using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Launcher.Platform.PlatformSdk
{
	// Token: 0x0200456E RID: 17774
	public class IQueryProductResult
	{
		// Token: 0x0401A8F1 RID: 108785
		[Nullable(1)]
		public string FailReason;

		// Token: 0x0401A8F2 RID: 108786
		public bool NeedReLogin;

		// Token: 0x0401A8F3 RID: 108787
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public List<DisplayProductInfo> DataList;
	}
}
