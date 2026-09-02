using System;
using System.Runtime.CompilerServices;

// Token: 0x020030F3 RID: 12531
[NullableContext(2)]
[Nullable(0)]
public class SwitchState : ISwitchState, IActionParamMap
{
	// Token: 0x17002323 RID: 8995
	// (get) Token: 0x06019EB6 RID: 106166 RVA: 0x007945D3 File Offset: 0x007927D3
	// (set) Token: 0x06019EB7 RID: 106167 RVA: 0x007945DB File Offset: 0x007927DB
	public string TargetStateName { get; set; }

	// Token: 0x17002324 RID: 8996
	// (get) Token: 0x06019EB8 RID: 106168 RVA: 0x007945E4 File Offset: 0x007927E4
	// (set) Token: 0x06019EB9 RID: 106169 RVA: 0x007945EC File Offset: 0x007927EC
	public bool? IsNoTransition { get; set; }

	// Token: 0x17002325 RID: 8997
	// (get) Token: 0x06019EBA RID: 106170 RVA: 0x007945F5 File Offset: 0x007927F5
	// (set) Token: 0x06019EBB RID: 106171 RVA: 0x007945FD File Offset: 0x007927FD
	public string Context { get; set; }
}
