using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Launcher.DiffPatch.Data
{
	// Token: 0x0200464A RID: 17994
	[NullableContext(1)]
	[Nullable(0)]
	public class RequireFileInfo
	{
		// Token: 0x0602EF6E RID: 192366 RVA: 0x00B20DF6 File Offset: 0x00B1EFF6
		public RequireFileInfo(string remoteRoute, string localPath, long size, string hash)
		{
			this.RemoteRoute = remoteRoute;
			this.LocalPath = localPath;
			this.Size = size;
			this.Hash = hash;
		}

		// Token: 0x0401ABB1 RID: 109489
		public readonly string RemoteRoute;

		// Token: 0x0401ABB2 RID: 109490
		public readonly string LocalPath;

		// Token: 0x0401ABB3 RID: 109491
		public readonly long Size;

		// Token: 0x0401ABB4 RID: 109492
		public readonly string Hash;
	}
}
