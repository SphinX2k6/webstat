using System;

namespace CSharpScript.Utils
{
	// Token: 0x020046A1 RID: 18081
	public interface INumberNode
	{
		// Token: 0x170080C6 RID: 32966
		// (get) Token: 0x0602F110 RID: 192784
		// (set) Token: 0x0602F111 RID: 192785
		EAstNodeType NodeType { get; set; }

		// Token: 0x170080C7 RID: 32967
		// (get) Token: 0x0602F112 RID: 192786
		// (set) Token: 0x0602F113 RID: 192787
		TFormulaValue Value { get; set; }
	}
}
