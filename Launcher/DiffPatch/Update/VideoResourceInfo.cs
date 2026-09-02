using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Launcher.DiffPatch.Update
{
	// Token: 0x0200462E RID: 17966
	[NullableContext(1)]
	[Nullable(0)]
	public class VideoResourceInfo
	{
		// Token: 0x0602EEE9 RID: 192233 RVA: 0x00B1E204 File Offset: 0x00B1C404
		public VideoResourceInfo(string RemoteRoute, string LocalPath, string PakFileName, long PakSize, string PakHash, string SigFileName, long SigSize, string SigHash)
		{
		}

		// Token: 0x0401AB4D RID: 109389
		public readonly string RemoteRoute = RemoteRoute;

		// Token: 0x0401AB4E RID: 109390
		public readonly string LocalPath = LocalPath;

		// Token: 0x0401AB4F RID: 109391
		public readonly string PakFileName = PakFileName;

		// Token: 0x0401AB50 RID: 109392
		public readonly long PakSize = PakSize;

		// Token: 0x0401AB51 RID: 109393
		public readonly string PakHash = PakHash;

		// Token: 0x0401AB52 RID: 109394
		public readonly string SigFileName = SigFileName;

		// Token: 0x0401AB53 RID: 109395
		public readonly long SigSize = SigSize;

		// Token: 0x0401AB54 RID: 109396
		public readonly string SigHash = SigHash;
	}
}
