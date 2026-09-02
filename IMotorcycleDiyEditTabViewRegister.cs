using System;
using System.Runtime.CompilerServices;

// Token: 0x020022EF RID: 8943
[NullableContext(2)]
public interface IMotorcycleDiyEditTabViewRegister : IMotorcycleDiyTabViewRegister
{
	// Token: 0x170014FC RID: 5372
	// (get) Token: 0x06010E72 RID: 69234
	// (set) Token: 0x06010E73 RID: 69235
	Func<MotorcycleDiyPresetData> GetLocalPresetData { get; set; }

	// Token: 0x170014FD RID: 5373
	// (get) Token: 0x06010E74 RID: 69236
	// (set) Token: 0x06010E75 RID: 69237
	Action<EOutlookType, bool> OnEditPresetChanged { get; set; }
}
