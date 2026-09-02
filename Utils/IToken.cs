using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Utils
{
	// Token: 0x0200469C RID: 18076
	[NullableContext(1)]
	public interface IToken
	{
		// Token: 0x170080C0 RID: 32960
		// (get) Token: 0x0602F0FD RID: 192765
		// (set) Token: 0x0602F0FE RID: 192766
		ETokenType TokenType { get; set; }

		// Token: 0x170080C1 RID: 32961
		// (get) Token: 0x0602F0FF RID: 192767
		// (set) Token: 0x0602F100 RID: 192768
		string TokenString { get; set; }
	}
}
