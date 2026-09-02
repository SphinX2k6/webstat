using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Launcher.Update
{
	// Token: 0x020044CB RID: 17611
	[NullableContext(1)]
	[Nullable(0)]
	public class PatchFileInfo
	{
		// Token: 0x0401A64F RID: 108111
		public string Name = "";

		// Token: 0x0401A650 RID: 108112
		public string FileUrl = "";

		// Token: 0x0401A651 RID: 108113
		public string SavePath = "";

		// Token: 0x0401A652 RID: 108114
		public bool NeedRestart;

		// Token: 0x0401A653 RID: 108115
		public int MountType;

		// Token: 0x0401A654 RID: 108116
		public long? PakSize;

		// Token: 0x0401A655 RID: 108117
		public string PakSha1 = "";

		// Token: 0x0401A656 RID: 108118
		public int MountOrder;

		// Token: 0x0401A657 RID: 108119
		public long? UtocSize;

		// Token: 0x0401A658 RID: 108120
		public string UtocSha1 = "";

		// Token: 0x0401A659 RID: 108121
		public long? UcasSize;

		// Token: 0x0401A65A RID: 108122
		public string UcasSha1 = "";

		// Token: 0x0401A65B RID: 108123
		public long? SigSize;

		// Token: 0x0401A65C RID: 108124
		public string SigSha1 = "";
	}
}
