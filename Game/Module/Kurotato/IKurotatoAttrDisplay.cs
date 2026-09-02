using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Kurotato
{
	// Token: 0x02005A53 RID: 23123
	[NullableContext(1)]
	public interface IKurotatoAttrDisplay
	{
		// Token: 0x17009558 RID: 38232
		// (get) Token: 0x0603A872 RID: 239730
		// (set) Token: 0x0603A873 RID: 239731
		string Icon { get; set; }

		// Token: 0x17009559 RID: 38233
		// (get) Token: 0x0603A874 RID: 239732
		// (set) Token: 0x0603A875 RID: 239733
		string Text { get; set; }

		// Token: 0x1700955A RID: 38234
		// (get) Token: 0x0603A876 RID: 239734
		// (set) Token: 0x0603A877 RID: 239735
		int PropertyId { get; set; }
	}
}
