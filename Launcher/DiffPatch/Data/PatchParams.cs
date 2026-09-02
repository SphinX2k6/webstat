using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Launcher.DiffPatch.Data
{
	// Token: 0x02004649 RID: 17993
	[NullableContext(1)]
	[Nullable(0)]
	public class PatchParams
	{
		// Token: 0x0602EF6D RID: 192365 RVA: 0x00B20DB9 File Offset: 0x00B1EFB9
		public PatchParams(LocalFileInfo diffFile, string oldDir, string newDir, List<LocalFileInfo> oldModify, Dictionary<string, LocalFileInfo> allDestFiles, long copySize, long newRefSize)
		{
			this.DiffFile = diffFile;
			this.OldDir = oldDir;
			this.NewDir = newDir;
			this.OldModify = oldModify;
			this.AllDestFiles = allDestFiles;
			this.CopySize = copySize;
			this.NewRefSize = newRefSize;
		}

		// Token: 0x0401ABA9 RID: 109481
		public bool PatchSuccess;

		// Token: 0x0401ABAA RID: 109482
		public readonly LocalFileInfo DiffFile;

		// Token: 0x0401ABAB RID: 109483
		public readonly string OldDir;

		// Token: 0x0401ABAC RID: 109484
		public readonly string NewDir;

		// Token: 0x0401ABAD RID: 109485
		public readonly List<LocalFileInfo> OldModify;

		// Token: 0x0401ABAE RID: 109486
		public readonly Dictionary<string, LocalFileInfo> AllDestFiles;

		// Token: 0x0401ABAF RID: 109487
		public readonly long CopySize;

		// Token: 0x0401ABB0 RID: 109488
		public readonly long NewRefSize;
	}
}
