using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Launcher.LogUpload
{
	// Token: 0x020045EF RID: 17903
	[NullableContext(1)]
	public interface IKuroSdkController
	{
		// Token: 0x1700808A RID: 32906
		// (get) Token: 0x0602EDB2 RID: 191922
		// (set) Token: 0x0602EDB3 RID: 191923
		Func<bool> CanUseSdk { get; set; }
	}
}
