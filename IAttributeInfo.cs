using System;
using System.Runtime.CompilerServices;

// Token: 0x0200288F RID: 10383
[NullableContext(2)]
public interface IAttributeInfo
{
	// Token: 0x17001ADB RID: 6875
	// (get) Token: 0x060148E2 RID: 84194
	// (set) Token: 0x060148E3 RID: 84195
	string Name { get; set; }

	// Token: 0x17001ADC RID: 6876
	// (get) Token: 0x060148E4 RID: 84196
	// (set) Token: 0x060148E5 RID: 84197
	string IconPath { get; set; }

	// Token: 0x17001ADD RID: 6877
	// (get) Token: 0x060148E6 RID: 84198
	// (set) Token: 0x060148E7 RID: 84199
	bool? ShowArrow { get; set; }

	// Token: 0x17001ADE RID: 6878
	// (get) Token: 0x060148E8 RID: 84200
	// (set) Token: 0x060148E9 RID: 84201
	string PreText { get; set; }

	// Token: 0x17001ADF RID: 6879
	// (get) Token: 0x060148EA RID: 84202
	// (set) Token: 0x060148EB RID: 84203
	string CurText { get; set; }

	// Token: 0x17001AE0 RID: 6880
	// (get) Token: 0x060148EC RID: 84204
	// (set) Token: 0x060148ED RID: 84205
	bool? IsNormalBg { get; set; }

	// Token: 0x17001AE1 RID: 6881
	// (get) Token: 0x060148EE RID: 84206
	// (set) Token: 0x060148EF RID: 84207
	bool? InnerShowBg { get; set; }

	// Token: 0x17001AE2 RID: 6882
	// (get) Token: 0x060148F0 RID: 84208
	// (set) Token: 0x060148F1 RID: 84209
	bool? IsLine { get; set; }
}
