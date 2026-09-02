using System;
using System.Runtime.CompilerServices;

// Token: 0x0200288D RID: 10381
[NullableContext(2)]
public interface ILevelInfo
{
	// Token: 0x17001AD3 RID: 6867
	// (get) Token: 0x060148D1 RID: 84177
	// (set) Token: 0x060148D2 RID: 84178
	int PreUpgradeLv { get; set; }

	// Token: 0x17001AD4 RID: 6868
	// (get) Token: 0x060148D3 RID: 84179
	// (set) Token: 0x060148D4 RID: 84180
	int UpgradeLv { get; set; }

	// Token: 0x17001AD5 RID: 6869
	// (get) Token: 0x060148D5 RID: 84181
	// (set) Token: 0x060148D6 RID: 84182
	string FormatStringId { get; set; }

	// Token: 0x17001AD6 RID: 6870
	// (get) Token: 0x060148D7 RID: 84183
	// (set) Token: 0x060148D8 RID: 84184
	bool? IsMaxLevel { get; set; }
}
