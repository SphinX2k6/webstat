using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Launcher.LogUpload
{
	// Token: 0x020045F4 RID: 17908
	[NullableContext(1)]
	[Nullable(0)]
	public class LocalStorage : ILocalStorage
	{
		// Token: 0x17008093 RID: 32915
		// (get) Token: 0x0602EDC7 RID: 191943 RVA: 0x00B18F14 File Offset: 0x00B17114
		// (set) Token: 0x0602EDC8 RID: 191944 RVA: 0x00B18F1C File Offset: 0x00B1711C
		public Func<int?> GetRecentlyLoginUid { get; set; }
	}
}
