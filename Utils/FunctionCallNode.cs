using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Utils
{
	// Token: 0x020046B4 RID: 18100
	[NullableContext(1)]
	[Nullable(0)]
	public class FunctionCallNode : IAstNode, IFunctionCallNode
	{
		// Token: 0x170080EE RID: 33006
		// (get) Token: 0x0602F17D RID: 192893 RVA: 0x00B27E7B File Offset: 0x00B2607B
		// (set) Token: 0x0602F17E RID: 192894 RVA: 0x00B27E83 File Offset: 0x00B26083
		public EAstNodeType NodeType { get; set; }

		// Token: 0x170080EF RID: 33007
		// (get) Token: 0x0602F17F RID: 192895 RVA: 0x00B27E8C File Offset: 0x00B2608C
		// (set) Token: 0x0602F180 RID: 192896 RVA: 0x00B27E94 File Offset: 0x00B26094
		public string Value { get; set; }

		// Token: 0x170080F0 RID: 33008
		// (get) Token: 0x0602F181 RID: 192897 RVA: 0x00B27E9D File Offset: 0x00B2609D
		// (set) Token: 0x0602F182 RID: 192898 RVA: 0x00B27EA5 File Offset: 0x00B260A5
		public IAstNode[] Args { get; set; }
	}
}
