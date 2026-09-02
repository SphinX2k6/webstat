using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Utils
{
	// Token: 0x020046A4 RID: 18084
	[NullableContext(1)]
	public interface IArrayNode
	{
		// Token: 0x170080CC RID: 32972
		// (get) Token: 0x0602F11C RID: 192796
		// (set) Token: 0x0602F11D RID: 192797
		EAstNodeType NodeType { get; set; }

		// Token: 0x170080CD RID: 32973
		// (get) Token: 0x0602F11E RID: 192798
		// (set) Token: 0x0602F11F RID: 192799
		IAstNode[] Value { get; set; }
	}
}
