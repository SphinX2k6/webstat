using System;

namespace CSharpScript.Utils
{
	// Token: 0x020046AC RID: 18092
	public class BooleanNode : IAstNode, IBooleanNode
	{
		// Token: 0x170080DC RID: 32988
		// (get) Token: 0x0602F151 RID: 192849 RVA: 0x00B27D09 File Offset: 0x00B25F09
		// (set) Token: 0x0602F152 RID: 192850 RVA: 0x00B27D11 File Offset: 0x00B25F11
		public EAstNodeType NodeType { get; set; }

		// Token: 0x170080DD RID: 32989
		// (get) Token: 0x0602F153 RID: 192851 RVA: 0x00B27D1A File Offset: 0x00B25F1A
		// (set) Token: 0x0602F154 RID: 192852 RVA: 0x00B27D22 File Offset: 0x00B25F22
		public bool Value { get; set; }
	}
}
