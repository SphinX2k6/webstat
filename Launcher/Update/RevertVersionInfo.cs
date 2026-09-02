using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Launcher.Update
{
	// Token: 0x020044CE RID: 17614
	[NullableContext(1)]
	[Nullable(0)]
	public class RevertVersionInfo : IRevertVersionInfo
	{
		// Token: 0x17008036 RID: 32822
		// (get) Token: 0x0602E797 RID: 190359 RVA: 0x00B013D4 File Offset: 0x00AFF5D4
		// (set) Token: 0x0602E798 RID: 190360 RVA: 0x00B013DC File Offset: 0x00AFF5DC
		public bool NeedRevert { get; set; }

		// Token: 0x17008037 RID: 32823
		// (get) Token: 0x0602E799 RID: 190361 RVA: 0x00B013E5 File Offset: 0x00AFF5E5
		// (set) Token: 0x0602E79A RID: 190362 RVA: 0x00B013ED File Offset: 0x00AFF5ED
		public HashSet<string> Paks { get; set; } = new HashSet<string>();

		// Token: 0x17008038 RID: 32824
		// (get) Token: 0x0602E79B RID: 190363 RVA: 0x00B013F6 File Offset: 0x00AFF5F6
		// (set) Token: 0x0602E79C RID: 190364 RVA: 0x00B013FE File Offset: 0x00AFF5FE
		public HashSet<string> Files { get; set; } = new HashSet<string>();
	}
}
