using System;

namespace CSharpScript.Utils
{
	// Token: 0x020046AD RID: 18093
	public class NumberNode : IAstNode, INumberNode
	{
		// Token: 0x170080DE RID: 32990
		// (get) Token: 0x0602F156 RID: 192854 RVA: 0x00B27D33 File Offset: 0x00B25F33
		// (set) Token: 0x0602F157 RID: 192855 RVA: 0x00B27D3B File Offset: 0x00B25F3B
		public EAstNodeType NodeType { get; set; }

		// Token: 0x170080DF RID: 32991
		// (get) Token: 0x0602F158 RID: 192856 RVA: 0x00B27D44 File Offset: 0x00B25F44
		// (set) Token: 0x0602F159 RID: 192857 RVA: 0x00B27D4C File Offset: 0x00B25F4C
		public TFormulaValue Value { get; set; }
	}
}
