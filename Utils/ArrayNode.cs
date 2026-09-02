using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Utils
{
	// Token: 0x020046B0 RID: 18096
	[NullableContext(1)]
	[Nullable(0)]
	public class ArrayNode : IAstNode, IArrayNode
	{
		// Token: 0x170080E4 RID: 32996
		// (get) Token: 0x0602F165 RID: 192869 RVA: 0x00B27DB1 File Offset: 0x00B25FB1
		// (set) Token: 0x0602F166 RID: 192870 RVA: 0x00B27DB9 File Offset: 0x00B25FB9
		public EAstNodeType NodeType { get; set; }

		// Token: 0x170080E5 RID: 32997
		// (get) Token: 0x0602F167 RID: 192871 RVA: 0x00B27DC2 File Offset: 0x00B25FC2
		// (set) Token: 0x0602F168 RID: 192872 RVA: 0x00B27DCA File Offset: 0x00B25FCA
		public IAstNode[] Value { get; set; }
	}
}
