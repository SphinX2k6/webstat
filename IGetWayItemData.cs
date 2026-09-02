using System;
using System.Runtime.CompilerServices;

// Token: 0x02001981 RID: 6529
[NullableContext(1)]
public interface IGetWayItemData
{
	// Token: 0x17000F35 RID: 3893
	// (get) Token: 0x0600BBAD RID: 48045
	// (set) Token: 0x0600BBAE RID: 48046
	int Id { get; set; }

	// Token: 0x17000F36 RID: 3894
	// (get) Token: 0x0600BBAF RID: 48047
	// (set) Token: 0x0600BBB0 RID: 48048
	EGetWayItemType Type { get; set; }

	// Token: 0x17000F37 RID: 3895
	// (get) Token: 0x0600BBB1 RID: 48049
	// (set) Token: 0x0600BBB2 RID: 48050
	string Text { get; set; }

	// Token: 0x17000F38 RID: 3896
	// (get) Token: 0x0600BBB3 RID: 48051
	// (set) Token: 0x0600BBB4 RID: 48052
	int SortIndex { get; set; }

	// Token: 0x17000F39 RID: 3897
	// (get) Token: 0x0600BBB5 RID: 48053
	// (set) Token: 0x0600BBB6 RID: 48054
	Action Function { get; set; }
}
