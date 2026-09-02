using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Utils
{
	// Token: 0x020046A5 RID: 18085
	[NullableContext(1)]
	public interface IBinaryOperatorNode
	{
		// Token: 0x170080CE RID: 32974
		// (get) Token: 0x0602F120 RID: 192800
		// (set) Token: 0x0602F121 RID: 192801
		EAstNodeType NodeType { get; set; }

		// Token: 0x170080CF RID: 32975
		// (get) Token: 0x0602F122 RID: 192802
		// (set) Token: 0x0602F123 RID: 192803
		string Operator { get; set; }

		// Token: 0x170080D0 RID: 32976
		// (get) Token: 0x0602F124 RID: 192804
		// (set) Token: 0x0602F125 RID: 192805
		IAstNode[] Args { get; set; }
	}
}
