using System;
using System.Runtime.CompilerServices;

// Token: 0x0200214A RID: 8522
[NullableContext(1)]
[Nullable(0)]
public class GamepadActiveEvent : PlayerCommonLogData
{
	// Token: 0x170013A2 RID: 5026
	// (get) Token: 0x060103DB RID: 66523 RVA: 0x00475B44 File Offset: 0x00473D44
	// (set) Token: 0x060103DC RID: 66524 RVA: 0x00475B4C File Offset: 0x00473D4C
	public override string event_id { get; set; } = "1050";

	// Token: 0x04007E5F RID: 32351
	public int i_gamepad_count;

	// Token: 0x04007E60 RID: 32352
	public float i_gamepad_time;

	// Token: 0x04007E61 RID: 32353
	public string s_suit_name = "";
}
