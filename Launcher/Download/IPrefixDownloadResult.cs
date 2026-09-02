using System;

namespace CSharpScript.Launcher.Download
{
	// Token: 0x0200461E RID: 17950
	public class IPrefixDownloadResult
	{
		// Token: 0x0401AB07 RID: 109319
		public bool Complete;

		// Token: 0x0401AB08 RID: 109320
		public float RemainedTime;

		// Token: 0x0401AB09 RID: 109321
		public float SpendTime;

		// Token: 0x0401AB0A RID: 109322
		public long DownloadedSize;

		// Token: 0x0401AB0B RID: 109323
		public int? FileIndex;

		// Token: 0x0401AB0C RID: 109324
		public EDownloadState DownloadState;

		// Token: 0x0401AB0D RID: 109325
		public int HttpCode;
	}
}
