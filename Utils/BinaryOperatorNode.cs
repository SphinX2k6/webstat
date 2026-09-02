using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Utils
{
	// Token: 0x020046B1 RID: 18097
	[NullableContext(1)]
	[Nullable(0)]
	public class BinaryOperatorNode : IAstNode, IBinaryOperatorNode
	{
		// Token: 0x170080E6 RID: 32998
		// (get) Token: 0x0602F16A RID: 192874 RVA: 0x00B27DDB File Offset: 0x00B25FDB
		// (set) Token: 0x0602F16B RID: 192875 RVA: 0x00B27DE3 File Offset: 0x00B25FE3
		public EAstNodeType NodeType { get; set; }

		// Token: 0x170080E7 RID: 32999
		// (get) Token: 0x0602F16C RID: 192876 RVA: 0x00B27DEC File Offset: 0x00B25FEC
		// (set) Token: 0x0602F16D RID: 192877 RVA: 0x00B27DF4 File Offset: 0x00B25FF4
		public string Operator { get; set; }

		// Token: 0x170080E8 RID: 33000
		// (get) Token: 0x0602F16E RID: 192878 RVA: 0x00B27DFD File Offset: 0x00B25FFD
		// (set) Token: 0x0602F16F RID: 192879 RVA: 0x00B27E05 File Offset: 0x00B26005
		public IAstNode[] Args { get; set; }
	}
}
