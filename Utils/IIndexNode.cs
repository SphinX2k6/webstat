using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Utils
{
	// Token: 0x020046A9 RID: 18089
	[NullableContext(1)]
	public interface IIndexNode
	{
		// Token: 0x170080D9 RID: 32985
		// (get) Token: 0x0602F136 RID: 192822
		// (set) Token: 0x0602F137 RID: 192823
		EAstNodeType NodeType { get; set; }

		// Token: 0x170080DA RID: 32986
		// (get) Token: 0x0602F138 RID: 192824
		// (set) Token: 0x0602F139 RID: 192825
		IAstNode Value { get; set; }

		// Token: 0x170080DB RID: 32987
		// (get) Token: 0x0602F13A RID: 192826
		// (set) Token: 0x0602F13B RID: 192827
		IAstNode Index { get; set; }
	}
}
