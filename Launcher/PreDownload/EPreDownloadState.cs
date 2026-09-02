using System;

namespace CSharpScript.Launcher.PreDownload
{
	// Token: 0x0200453D RID: 17725
	public enum EPreDownloadState
	{
		// Token: 0x0401A806 RID: 108550
		Disabled,
		// Token: 0x0401A807 RID: 108551
		Enabled,
		// Token: 0x0401A808 RID: 108552
		Downloading,
		// Token: 0x0401A809 RID: 108553
		Patching,
		// Token: 0x0401A80A RID: 108554
		Stopped,
		// Token: 0x0401A80B RID: 108555
		Finished
	}
}
