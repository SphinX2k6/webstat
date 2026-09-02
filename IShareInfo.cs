using System;
using System.Runtime.CompilerServices;

// Token: 0x02000EFF RID: 3839
[NullableContext(1)]
public interface IShareInfo
{
	// Token: 0x170006FD RID: 1789
	// (get) Token: 0x06005EDE RID: 24286
	// (set) Token: 0x06005EDF RID: 24287
	string ImageData { get; set; }

	// Token: 0x170006FE RID: 1790
	// (get) Token: 0x06005EE0 RID: 24288
	// (set) Token: 0x06005EE1 RID: 24289
	ShareData ShareData { get; set; }
}
