using System;
using System.Runtime.CompilerServices;

// Token: 0x020030F2 RID: 12530
[NullableContext(2)]
public interface ISwitchState : IActionParamMap
{
	// Token: 0x17002320 RID: 8992
	// (get) Token: 0x06019EB0 RID: 106160
	// (set) Token: 0x06019EB1 RID: 106161
	string TargetStateName { get; set; }

	// Token: 0x17002321 RID: 8993
	// (get) Token: 0x06019EB2 RID: 106162
	// (set) Token: 0x06019EB3 RID: 106163
	bool? IsNoTransition { get; set; }

	// Token: 0x17002322 RID: 8994
	// (get) Token: 0x06019EB4 RID: 106164
	// (set) Token: 0x06019EB5 RID: 106165
	string Context { get; set; }
}
