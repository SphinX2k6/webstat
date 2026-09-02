using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Utils
{
	// Token: 0x020046AF RID: 18095
	[NullableContext(1)]
	[Nullable(0)]
	public class ParenthesizedExpressionNode : IAstNode, IParenthesizedExpressionNode
	{
		// Token: 0x170080E2 RID: 32994
		// (get) Token: 0x0602F160 RID: 192864 RVA: 0x00B27D87 File Offset: 0x00B25F87
		// (set) Token: 0x0602F161 RID: 192865 RVA: 0x00B27D8F File Offset: 0x00B25F8F
		public EAstNodeType NodeType { get; set; }

		// Token: 0x170080E3 RID: 32995
		// (get) Token: 0x0602F162 RID: 192866 RVA: 0x00B27D98 File Offset: 0x00B25F98
		// (set) Token: 0x0602F163 RID: 192867 RVA: 0x00B27DA0 File Offset: 0x00B25FA0
		public IAstNode Value { get; set; }
	}
}
