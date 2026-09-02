using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Utils
{
	// Token: 0x020046A8 RID: 18088
	[NullableContext(1)]
	public interface IFunctionCallNode
	{
		// Token: 0x170080D6 RID: 32982
		// (get) Token: 0x0602F130 RID: 192816
		// (set) Token: 0x0602F131 RID: 192817
		EAstNodeType NodeType { get; set; }

		// Token: 0x170080D7 RID: 32983
		// (get) Token: 0x0602F132 RID: 192818
		// (set) Token: 0x0602F133 RID: 192819
		string Value { get; set; }

		// Token: 0x170080D8 RID: 32984
		// (get) Token: 0x0602F134 RID: 192820
		// (set) Token: 0x0602F135 RID: 192821
		IAstNode[] Args { get; set; }
	}
}
