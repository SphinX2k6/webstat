using System;

namespace CSharpScript.Utils
{
	// Token: 0x020046BC RID: 18108
	public class Variable : IVariable
	{
		// Token: 0x170080F7 RID: 33015
		// (get) Token: 0x0602F1B3 RID: 192947 RVA: 0x00B290C2 File Offset: 0x00B272C2
		// (set) Token: 0x0602F1B4 RID: 192948 RVA: 0x00B290CA File Offset: 0x00B272CA
		public EVariableType Type { get; set; }

		// Token: 0x170080F8 RID: 33016
		// (get) Token: 0x0602F1B5 RID: 192949 RVA: 0x00B290D3 File Offset: 0x00B272D3
		// (set) Token: 0x0602F1B6 RID: 192950 RVA: 0x00B290DB File Offset: 0x00B272DB
		public TFormulaValue Value { get; set; }
	}
}
