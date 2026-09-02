using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Utils
{
	// Token: 0x020046AE RID: 18094
	[NullableContext(1)]
	[Nullable(0)]
	public class StringNode : IAstNode, IStringNode
	{
		// Token: 0x170080E0 RID: 32992
		// (get) Token: 0x0602F15B RID: 192859 RVA: 0x00B27D5D File Offset: 0x00B25F5D
		// (set) Token: 0x0602F15C RID: 192860 RVA: 0x00B27D65 File Offset: 0x00B25F65
		public EAstNodeType NodeType { get; set; }

		// Token: 0x170080E1 RID: 32993
		// (get) Token: 0x0602F15D RID: 192861 RVA: 0x00B27D6E File Offset: 0x00B25F6E
		// (set) Token: 0x0602F15E RID: 192862 RVA: 0x00B27D76 File Offset: 0x00B25F76
		public string Value { get; set; }
	}
}
