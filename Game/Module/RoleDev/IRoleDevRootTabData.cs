using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.RoleDev
{
	// Token: 0x02005031 RID: 20529
	[NullableContext(1)]
	public interface IRoleDevRootTabData
	{
		// Token: 0x17008AD9 RID: 35545
		// (get) Token: 0x06034DEF RID: 216559
		// (set) Token: 0x06034DF0 RID: 216560
		ERoleDevTabType TabIndex { get; set; }

		// Token: 0x17008ADA RID: 35546
		// (get) Token: 0x06034DF1 RID: 216561
		// (set) Token: 0x06034DF2 RID: 216562
		string TabName { get; set; }

		// Token: 0x17008ADB RID: 35547
		// (get) Token: 0x06034DF3 RID: 216563
		// (set) Token: 0x06034DF4 RID: 216564
		bool TabIsUpgrade { get; set; }

		// Token: 0x17008ADC RID: 35548
		// (get) Token: 0x06034DF5 RID: 216565
		// (set) Token: 0x06034DF6 RID: 216566
		bool TabIsFinish { get; set; }
	}
}
