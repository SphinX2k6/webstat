using System;
using CSharpScript.Core.Common;

namespace CSharpScript.Launcher.Download
{
	// Token: 0x02004619 RID: 17945
	[EnumExtensions]
	public enum EDownloadState
	{
		// Token: 0x0401AAE8 RID: 109288
		None,
		// Token: 0x0401AAE9 RID: 109289
		HttpError,
		// Token: 0x0401AAEA RID: 109290
		FileRenameError,
		// Token: 0x0401AAEB RID: 109291
		ValidateError,
		// Token: 0x0401AAEC RID: 109292
		OpenToWriteError,
		// Token: 0x0401AAED RID: 109293
		NotEnoughSpace,
		// Token: 0x0401AAEE RID: 109294
		DownloadCanceled,
		// Token: 0x0401AAEF RID: 109295
		Success,
		// Token: 0x0401AAF0 RID: 109296
		ChangeToCell
	}
}
