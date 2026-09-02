using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Launcher.LogUpload
{
	// Token: 0x020045F5 RID: 17909
	[NullableContext(1)]
	[Nullable(0)]
	public class KuroSdkController : IKuroSdkController
	{
		// Token: 0x17008094 RID: 32916
		// (get) Token: 0x0602EDCA RID: 191946 RVA: 0x00B18F2D File Offset: 0x00B1712D
		// (set) Token: 0x0602EDCB RID: 191947 RVA: 0x00B18F35 File Offset: 0x00B17135
		public Func<bool> CanUseSdk { get; set; }
	}
}
