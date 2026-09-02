using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Utils
{
	// Token: 0x020046A7 RID: 18087
	[NullableContext(1)]
	public interface IIdentifierNode
	{
		// Token: 0x170080D4 RID: 32980
		// (get) Token: 0x0602F12C RID: 192812
		// (set) Token: 0x0602F12D RID: 192813
		EAstNodeType NodeType { get; set; }

		// Token: 0x170080D5 RID: 32981
		// (get) Token: 0x0602F12E RID: 192814
		// (set) Token: 0x0602F12F RID: 192815
		string Value { get; set; }
	}
}
