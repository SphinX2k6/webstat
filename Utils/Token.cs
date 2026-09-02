using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Utils
{
	// Token: 0x0200469D RID: 18077
	[NullableContext(1)]
	[Nullable(0)]
	public class Token : IToken
	{
		// Token: 0x170080C2 RID: 32962
		// (get) Token: 0x0602F101 RID: 192769 RVA: 0x00B26F41 File Offset: 0x00B25141
		// (set) Token: 0x0602F102 RID: 192770 RVA: 0x00B26F49 File Offset: 0x00B25149
		public ETokenType TokenType { get; set; }

		// Token: 0x170080C3 RID: 32963
		// (get) Token: 0x0602F103 RID: 192771 RVA: 0x00B26F52 File Offset: 0x00B25152
		// (set) Token: 0x0602F104 RID: 192772 RVA: 0x00B26F5A File Offset: 0x00B2515A
		public string TokenString { get; set; }
	}
}
