using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Utils
{
	// Token: 0x020046A2 RID: 18082
	[NullableContext(1)]
	public interface IStringNode
	{
		// Token: 0x170080C8 RID: 32968
		// (get) Token: 0x0602F114 RID: 192788
		// (set) Token: 0x0602F115 RID: 192789
		EAstNodeType NodeType { get; set; }

		// Token: 0x170080C9 RID: 32969
		// (get) Token: 0x0602F116 RID: 192790
		// (set) Token: 0x0602F117 RID: 192791
		string Value { get; set; }
	}
}
