using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Utils
{
	// Token: 0x020046C0 RID: 18112
	[NullableContext(1)]
	[Nullable(0)]
	public class Node : INode
	{
		// Token: 0x170080FD RID: 33021
		// (get) Token: 0x0602F1C6 RID: 192966 RVA: 0x00B294DF File Offset: 0x00B276DF
		// (set) Token: 0x0602F1C7 RID: 192967 RVA: 0x00B294E7 File Offset: 0x00B276E7
		public ENodeType NodeType { get; set; }

		// Token: 0x170080FE RID: 33022
		// (get) Token: 0x0602F1C8 RID: 192968 RVA: 0x00B294F0 File Offset: 0x00B276F0
		// (set) Token: 0x0602F1C9 RID: 192969 RVA: 0x00B294F8 File Offset: 0x00B276F8
		public string Name { get; set; } = string.Empty;

		// Token: 0x170080FF RID: 33023
		// (get) Token: 0x0602F1CA RID: 192970 RVA: 0x00B29501 File Offset: 0x00B27701
		// (set) Token: 0x0602F1CB RID: 192971 RVA: 0x00B29509 File Offset: 0x00B27709
		public TFormulaValue Value { get; set; }

		// Token: 0x17008100 RID: 33024
		// (get) Token: 0x0602F1CC RID: 192972 RVA: 0x00B29512 File Offset: 0x00B27712
		// (set) Token: 0x0602F1CD RID: 192973 RVA: 0x00B2951A File Offset: 0x00B2771A
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public List<INode> Children { [return: Nullable(new byte[]
		{
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1
		})] set; }
	}
}
