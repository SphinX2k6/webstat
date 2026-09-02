using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Utils
{
	// Token: 0x020046A6 RID: 18086
	[NullableContext(1)]
	public interface IUnaryOperatorNode
	{
		// Token: 0x170080D1 RID: 32977
		// (get) Token: 0x0602F126 RID: 192806
		// (set) Token: 0x0602F127 RID: 192807
		EAstNodeType NodeType { get; set; }

		// Token: 0x170080D2 RID: 32978
		// (get) Token: 0x0602F128 RID: 192808
		// (set) Token: 0x0602F129 RID: 192809
		string Operator { get; set; }

		// Token: 0x170080D3 RID: 32979
		// (get) Token: 0x0602F12A RID: 192810
		// (set) Token: 0x0602F12B RID: 192811
		IAstNode[] Args { get; set; }
	}
}
