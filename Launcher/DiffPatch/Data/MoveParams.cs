using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Launcher.DiffPatch.Data
{
	// Token: 0x02004648 RID: 17992
	[NullableContext(1)]
	[Nullable(0)]
	public class MoveParams
	{
		// Token: 0x0602EF6C RID: 192364 RVA: 0x00B20DA3 File Offset: 0x00B1EFA3
		public MoveParams(LocalFileInfo oldFile, LocalFileInfo newFile)
		{
			this.OldFile = oldFile;
			this.NewFile = newFile;
		}

		// Token: 0x0401ABA7 RID: 109479
		public readonly LocalFileInfo OldFile;

		// Token: 0x0401ABA8 RID: 109480
		public readonly LocalFileInfo NewFile;
	}
}
