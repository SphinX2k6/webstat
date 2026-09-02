using System;

namespace CSharpScript.Launcher.Download
{
	// Token: 0x0200461F RID: 17951
	public class IEvaluateResult
	{
		// Token: 0x0401AB0E RID: 109326
		public bool Complete;

		// Token: 0x0401AB0F RID: 109327
		public int FileIndex;

		// Token: 0x0401AB10 RID: 109328
		public EDownloadState DownloadState;

		// Token: 0x0401AB11 RID: 109329
		public int HttpCode;

		// Token: 0x0401AB12 RID: 109330
		public bool Skipped;
	}
}
