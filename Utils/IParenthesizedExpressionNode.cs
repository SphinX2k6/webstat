using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Utils
{
	// Token: 0x020046A3 RID: 18083
	[NullableContext(1)]
	public interface IParenthesizedExpressionNode
	{
		// Token: 0x170080CA RID: 32970
		// (get) Token: 0x0602F118 RID: 192792
		// (set) Token: 0x0602F119 RID: 192793
		EAstNodeType NodeType { get; set; }

		// Token: 0x170080CB RID: 32971
		// (get) Token: 0x0602F11A RID: 192794
		// (set) Token: 0x0602F11B RID: 192795
		IAstNode Value { get; set; }
	}
}
