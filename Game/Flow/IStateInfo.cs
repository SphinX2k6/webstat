using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Flow
{
	// Token: 0x02007020 RID: 28704
	[NullableContext(1)]
	public interface IStateInfo
	{
		// Token: 0x1700A4E4 RID: 42212
		// (get) Token: 0x06045844 RID: 284740
		// (set) Token: 0x06045845 RID: 284741
		int Id { get; set; }

		// Token: 0x1700A4E5 RID: 42213
		// (get) Token: 0x06045846 RID: 284742
		// (set) Token: 0x06045847 RID: 284743
		string Name { get; set; }

		// Token: 0x1700A4E6 RID: 42214
		// (get) Token: 0x06045848 RID: 284744
		// (set) Token: 0x06045849 RID: 284745
		bool? _folded { get; set; }

		// Token: 0x1700A4E7 RID: 42215
		// (get) Token: 0x0604584A RID: 284746
		// (set) Token: 0x0604584B RID: 284747
		IActionInfo[] Actions { get; set; }
	}
}
