using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Utils
{
	// Token: 0x020046B5 RID: 18101
	[NullableContext(1)]
	[Nullable(0)]
	public class IndexNode : IAstNode, IIndexNode
	{
		// Token: 0x170080F1 RID: 33009
		// (get) Token: 0x0602F184 RID: 192900 RVA: 0x00B27EB6 File Offset: 0x00B260B6
		// (set) Token: 0x0602F185 RID: 192901 RVA: 0x00B27EBE File Offset: 0x00B260BE
		public EAstNodeType NodeType { get; set; }

		// Token: 0x170080F2 RID: 33010
		// (get) Token: 0x0602F186 RID: 192902 RVA: 0x00B27EC7 File Offset: 0x00B260C7
		// (set) Token: 0x0602F187 RID: 192903 RVA: 0x00B27ECF File Offset: 0x00B260CF
		public IAstNode Value { get; set; }

		// Token: 0x170080F3 RID: 33011
		// (get) Token: 0x0602F188 RID: 192904 RVA: 0x00B27ED8 File Offset: 0x00B260D8
		// (set) Token: 0x0602F189 RID: 192905 RVA: 0x00B27EE0 File Offset: 0x00B260E0
		public IAstNode Index { get; set; }
	}
}
