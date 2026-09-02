using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Launcher.Download
{
	// Token: 0x0200461D RID: 17949
	[NullableContext(1)]
	[Nullable(0)]
	public class RequestFileInfo
	{
		// Token: 0x0401AB01 RID: 109313
		public string FileName = "";

		// Token: 0x0401AB02 RID: 109314
		public string Url = "";

		// Token: 0x0401AB03 RID: 109315
		public string SavePath = "";

		// Token: 0x0401AB04 RID: 109316
		public long? Size;

		// Token: 0x0401AB05 RID: 109317
		public string HashString = "";

		// Token: 0x0401AB06 RID: 109318
		public bool bUseDownloadCache;
	}
}
