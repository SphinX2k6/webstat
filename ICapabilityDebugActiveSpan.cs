using System;
using System.Runtime.CompilerServices;

// Token: 0x02000E45 RID: 3653
[NullableContext(1)]
public interface ICapabilityDebugActiveSpan
{
	// Token: 0x170005E1 RID: 1505
	// (get) Token: 0x0600578E RID: 22414
	// (set) Token: 0x0600578F RID: 22415
	string CapabilityId { get; set; }

	// Token: 0x170005E2 RID: 1506
	// (get) Token: 0x06005790 RID: 22416
	// (set) Token: 0x06005791 RID: 22417
	string GameObjectId { get; set; }

	// Token: 0x170005E3 RID: 1507
	// (get) Token: 0x06005792 RID: 22418
	// (set) Token: 0x06005793 RID: 22419
	string ClassName { get; set; }

	// Token: 0x170005E4 RID: 1508
	// (get) Token: 0x06005794 RID: 22420
	// (set) Token: 0x06005795 RID: 22421
	double StartTime { get; set; }

	// Token: 0x170005E5 RID: 1509
	// (get) Token: 0x06005796 RID: 22422
	// (set) Token: 0x06005797 RID: 22423
	double EndTime { get; set; }
}
