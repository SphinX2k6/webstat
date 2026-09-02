using System;
using System.Runtime.CompilerServices;

// Token: 0x02003191 RID: 12689
[NullableContext(2)]
public interface INpcSitOnChairParams
{
	// Token: 0x170023BB RID: 9147
	// (get) Token: 0x0601A4FA RID: 107770
	// (set) Token: 0x0601A4FB RID: 107771
	int ChairEntityId { get; set; }

	// Token: 0x170023BC RID: 9148
	// (get) Token: 0x0601A4FC RID: 107772
	// (set) Token: 0x0601A4FD RID: 107773
	string MontagePath { get; set; }

	// Token: 0x170023BD RID: 9149
	// (get) Token: 0x0601A4FE RID: 107774
	// (set) Token: 0x0601A4FF RID: 107775
	[Nullable(1)]
	Func<bool> InterruptCondition { [NullableContext(1)] get; [NullableContext(1)] set; }

	// Token: 0x170023BE RID: 9150
	// (get) Token: 0x0601A500 RID: 107776
	// (set) Token: 0x0601A501 RID: 107777
	Action Finish { get; set; }

	// Token: 0x170023BF RID: 9151
	// (get) Token: 0x0601A502 RID: 107778
	// (set) Token: 0x0601A503 RID: 107779
	Action Abort { get; set; }

	// Token: 0x170023C0 RID: 9152
	// (get) Token: 0x0601A504 RID: 107780
	// (set) Token: 0x0601A505 RID: 107781
	int[] TeleportEffect { get; set; }
}
