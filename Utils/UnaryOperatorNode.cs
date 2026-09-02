using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Utils
{
	// Token: 0x020046B2 RID: 18098
	[NullableContext(1)]
	[Nullable(0)]
	public class UnaryOperatorNode : IAstNode, IUnaryOperatorNode
	{
		// Token: 0x170080E9 RID: 33001
		// (get) Token: 0x0602F171 RID: 192881 RVA: 0x00B27E16 File Offset: 0x00B26016
		// (set) Token: 0x0602F172 RID: 192882 RVA: 0x00B27E1E File Offset: 0x00B2601E
		public EAstNodeType NodeType { get; set; }

		// Token: 0x170080EA RID: 33002
		// (get) Token: 0x0602F173 RID: 192883 RVA: 0x00B27E27 File Offset: 0x00B26027
		// (set) Token: 0x0602F174 RID: 192884 RVA: 0x00B27E2F File Offset: 0x00B2602F
		public string Operator { get; set; }

		// Token: 0x170080EB RID: 33003
		// (get) Token: 0x0602F175 RID: 192885 RVA: 0x00B27E38 File Offset: 0x00B26038
		// (set) Token: 0x0602F176 RID: 192886 RVA: 0x00B27E40 File Offset: 0x00B26040
		public IAstNode[] Args { get; set; }
	}
}
