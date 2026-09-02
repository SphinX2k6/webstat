using System;
using System.Runtime.CompilerServices;

// Token: 0x020022EE RID: 8942
[NullableContext(2)]
public interface IMotorcycleDiyTabViewRegister
{
	// Token: 0x06010E6D RID: 69229
	void RefreshItemScrollView();

	// Token: 0x170014FA RID: 5370
	// (get) Token: 0x06010E6E RID: 69230
	// (set) Token: 0x06010E6F RID: 69231
	Action<int> OnTabCameraClick { get; set; }

	// Token: 0x170014FB RID: 5371
	// (get) Token: 0x06010E70 RID: 69232
	// (set) Token: 0x06010E71 RID: 69233
	Action<EOutlookType, int, int> OnSelectItemClick { get; set; }
}
