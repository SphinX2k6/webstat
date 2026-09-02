using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Utils
{
	// Token: 0x020046BF RID: 18111
	[NullableContext(1)]
	public interface INode
	{
		// Token: 0x170080F9 RID: 33017
		// (get) Token: 0x0602F1BE RID: 192958
		// (set) Token: 0x0602F1BF RID: 192959
		ENodeType NodeType { get; set; }

		// Token: 0x170080FA RID: 33018
		// (get) Token: 0x0602F1C0 RID: 192960
		// (set) Token: 0x0602F1C1 RID: 192961
		string Name { get; set; }

		// Token: 0x170080FB RID: 33019
		// (get) Token: 0x0602F1C2 RID: 192962
		// (set) Token: 0x0602F1C3 RID: 192963
		TFormulaValue Value { get; set; }

		// Token: 0x170080FC RID: 33020
		// (get) Token: 0x0602F1C4 RID: 192964
		// (set) Token: 0x0602F1C5 RID: 192965
		[Nullable(new byte[]
		{
			2,
			1
		})]
		List<INode> Children { [return: Nullable(new byte[]
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
