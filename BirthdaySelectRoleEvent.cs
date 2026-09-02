using System;
using System.Runtime.CompilerServices;

// Token: 0x02002197 RID: 8599
[NullableContext(1)]
[Nullable(0)]
public class BirthdaySelectRoleEvent : PlayerCommonLogData
{
	// Token: 0x170013EF RID: 5103
	// (get) Token: 0x060104C2 RID: 66754 RVA: 0x00476841 File Offset: 0x00474A41
	// (set) Token: 0x060104C3 RID: 66755 RVA: 0x00476849 File Offset: 0x00474A49
	public override string event_id { get; set; } = "1062";

	// Token: 0x04007F8C RID: 32652
	public int i_role_id;

	// Token: 0x04007F8D RID: 32653
	public bool b_if_selected_role;

	// Token: 0x04007F8E RID: 32654
	public int i_birthday_count;

	// Token: 0x04007F8F RID: 32655
	public int i_trigger_type;

	// Token: 0x04007F90 RID: 32656
	public int bird_round_id;
}
