using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MultiMotor
{
	// Token: 0x0200665F RID: 26207
	[NullableContext(1)]
	[Nullable(0)]
	public class IMultiMotorParkourRewardViewData
	{
		// Token: 0x17009F90 RID: 40848
		// (get) Token: 0x0604171D RID: 268061 RVA: 0x010CBF10 File Offset: 0x010CA110
		// (set) Token: 0x0604171E RID: 268062 RVA: 0x010CBF18 File Offset: 0x010CA118
		public MultiMotorData ActivityData { get; set; }

		// Token: 0x17009F91 RID: 40849
		// (get) Token: 0x0604171F RID: 268063 RVA: 0x010CBF21 File Offset: 0x010CA121
		// (set) Token: 0x06041720 RID: 268064 RVA: 0x010CBF29 File Offset: 0x010CA129
		public MultiMotorLevelData SelectLevelData { get; set; }
	}
}
