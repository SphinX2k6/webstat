using System;

namespace CSharpScript.Utils
{
	// Token: 0x020046BB RID: 18107
	public interface IVariable
	{
		// Token: 0x170080F5 RID: 33013
		// (get) Token: 0x0602F1AF RID: 192943
		// (set) Token: 0x0602F1B0 RID: 192944
		EVariableType Type { get; set; }

		// Token: 0x170080F6 RID: 33014
		// (get) Token: 0x0602F1B1 RID: 192945
		// (set) Token: 0x0602F1B2 RID: 192946
		TFormulaValue Value { get; set; }
	}
}
