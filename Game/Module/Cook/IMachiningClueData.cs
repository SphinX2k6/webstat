using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Cook
{
	// Token: 0x02005E04 RID: 24068
	[NullableContext(1)]
	public interface IMachiningClueData
	{
		// Token: 0x17009908 RID: 39176
		// (get) Token: 0x0603C929 RID: 248105
		// (set) Token: 0x0603C92A RID: 248106
		bool IsUnlock { get; set; }

		// Token: 0x17009909 RID: 39177
		// (get) Token: 0x0603C92B RID: 248107
		// (set) Token: 0x0603C92C RID: 248108
		string ContentText { get; set; }
	}
}
