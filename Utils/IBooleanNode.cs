using System;

namespace CSharpScript.Utils
{
	// Token: 0x020046A0 RID: 18080
	public interface IBooleanNode
	{
		// Token: 0x170080C4 RID: 32964
		// (get) Token: 0x0602F10C RID: 192780
		// (set) Token: 0x0602F10D RID: 192781
		EAstNodeType NodeType { get; set; }

		// Token: 0x170080C5 RID: 32965
		// (get) Token: 0x0602F10E RID: 192782
		// (set) Token: 0x0602F10F RID: 192783
		bool Value { get; set; }
	}
}
