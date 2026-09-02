using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Launcher.DiffPatch.Data
{
	// Token: 0x0200464B RID: 17995
	[NullableContext(1)]
	[Nullable(0)]
	public class PakFilePair
	{
		// Token: 0x0401ABB5 RID: 109493
		public LocalFileInfo Pak;

		// Token: 0x0401ABB6 RID: 109494
		public LocalFileInfo Sig;

		// Token: 0x0401ABB7 RID: 109495
		public LocalFileInfo Utoc;

		// Token: 0x0401ABB8 RID: 109496
		public LocalFileInfo Ucas;

		// Token: 0x0401ABB9 RID: 109497
		public int MountOrder = 4;
	}
}
