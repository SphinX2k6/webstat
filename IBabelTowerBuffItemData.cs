using System;

// Token: 0x020011F2 RID: 4594
public interface IBabelTowerBuffItemData
{
	// Token: 0x17000A5D RID: 2653
	// (get) Token: 0x06007994 RID: 31124
	// (set) Token: 0x06007995 RID: 31125
	int Id { get; set; }

	// Token: 0x17000A5E RID: 2654
	// (get) Token: 0x06007996 RID: 31126
	// (set) Token: 0x06007997 RID: 31127
	bool IsDeTerm { get; set; }

	// Token: 0x17000A5F RID: 2655
	// (get) Token: 0x06007998 RID: 31128
	// (set) Token: 0x06007999 RID: 31129
	bool CanClick { get; set; }

	// Token: 0x17000A60 RID: 2656
	// (get) Token: 0x0600799A RID: 31130
	// (set) Token: 0x0600799B RID: 31131
	bool? ShowStar { get; set; }

	// Token: 0x17000A61 RID: 2657
	// (get) Token: 0x0600799C RID: 31132
	// (set) Token: 0x0600799D RID: 31133
	bool? IsNecessary { get; set; }

	// Token: 0x17000A62 RID: 2658
	// (get) Token: 0x0600799E RID: 31134
	// (set) Token: 0x0600799F RID: 31135
	bool? IsLock { get; set; }

	// Token: 0x17000A63 RID: 2659
	// (get) Token: 0x060079A0 RID: 31136
	// (set) Token: 0x060079A1 RID: 31137
	bool? IsSelect { get; set; }

	// Token: 0x17000A64 RID: 2660
	// (get) Token: 0x060079A2 RID: 31138
	// (set) Token: 0x060079A3 RID: 31139
	int? GroupId { get; set; }
}
