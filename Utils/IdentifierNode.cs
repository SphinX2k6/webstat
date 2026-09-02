using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Utils
{
	// Token: 0x020046B3 RID: 18099
	[NullableContext(1)]
	[Nullable(0)]
	public class IdentifierNode : IAstNode, IIdentifierNode
	{
		// Token: 0x170080EC RID: 33004
		// (get) Token: 0x0602F178 RID: 192888 RVA: 0x00B27E51 File Offset: 0x00B26051
		// (set) Token: 0x0602F179 RID: 192889 RVA: 0x00B27E59 File Offset: 0x00B26059
		public EAstNodeType NodeType { get; set; }

		// Token: 0x170080ED RID: 33005
		// (get) Token: 0x0602F17A RID: 192890 RVA: 0x00B27E62 File Offset: 0x00B26062
		// (set) Token: 0x0602F17B RID: 192891 RVA: 0x00B27E6A File Offset: 0x00B2606A
		public string Value { get; set; }
	}
}
