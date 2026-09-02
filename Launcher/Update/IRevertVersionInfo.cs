using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Launcher.Update
{
	// Token: 0x020044CA RID: 17610
	[NullableContext(1)]
	public interface IRevertVersionInfo
	{
		// Token: 0x17008033 RID: 32819
		// (get) Token: 0x0602E778 RID: 190328
		// (set) Token: 0x0602E779 RID: 190329
		bool NeedRevert { get; set; }

		// Token: 0x17008034 RID: 32820
		// (get) Token: 0x0602E77A RID: 190330
		// (set) Token: 0x0602E77B RID: 190331
		HashSet<string> Paks { get; set; }

		// Token: 0x17008035 RID: 32821
		// (get) Token: 0x0602E77C RID: 190332
		// (set) Token: 0x0602E77D RID: 190333
		HashSet<string> Files { get; set; }
	}
}
