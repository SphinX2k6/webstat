using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Battle
{
	// Token: 0x02006638 RID: 26168
	[NullableContext(1)]
	[Nullable(0)]
	public class PinballBattleLevelInfoTargetData : IPinballBattleLevelInfoTargetData
	{
		// Token: 0x17009F75 RID: 40821
		// (get) Token: 0x060415CB RID: 267723 RVA: 0x010C3C2C File Offset: 0x010C1E2C
		// (set) Token: 0x060415CC RID: 267724 RVA: 0x010C3C34 File Offset: 0x010C1E34
		public bool IsSpecial { get; set; }

		// Token: 0x17009F76 RID: 40822
		// (get) Token: 0x060415CD RID: 267725 RVA: 0x010C3C3D File Offset: 0x010C1E3D
		// (set) Token: 0x060415CE RID: 267726 RVA: 0x010C3C45 File Offset: 0x010C1E45
		public bool IsFinish { get; set; }

		// Token: 0x17009F77 RID: 40823
		// (get) Token: 0x060415CF RID: 267727 RVA: 0x010C3C4E File Offset: 0x010C1E4E
		// (set) Token: 0x060415D0 RID: 267728 RVA: 0x010C3C56 File Offset: 0x010C1E56
		public string Desc { get; set; }

		// Token: 0x17009F78 RID: 40824
		// (get) Token: 0x060415D1 RID: 267729 RVA: 0x010C3C5F File Offset: 0x010C1E5F
		// (set) Token: 0x060415D2 RID: 267730 RVA: 0x010C3C67 File Offset: 0x010C1E67
		public int Value { get; set; }
	}
}
