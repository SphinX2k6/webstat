using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.InstanceDungeon
{
	// Token: 0x02005BD3 RID: 23507
	[NullableContext(2)]
	[Nullable(0)]
	public class PowerMagnificationRewardPopViewData
	{
		// Token: 0x1700978F RID: 38799
		// (get) Token: 0x0603B846 RID: 243782 RVA: 0x00F16EC3 File Offset: 0x00F150C3
		// (set) Token: 0x0603B847 RID: 243783 RVA: 0x00F16ECB File Offset: 0x00F150CB
		public int SinglePowerCost { get; set; }

		// Token: 0x17009790 RID: 38800
		// (get) Token: 0x0603B848 RID: 243784 RVA: 0x00F16ED4 File Offset: 0x00F150D4
		// (set) Token: 0x0603B849 RID: 243785 RVA: 0x00F16EDC File Offset: 0x00F150DC
		[Nullable(1)]
		public Action<int> RewardCallBack { [NullableContext(1)] get; [NullableContext(1)] set; }

		// Token: 0x17009791 RID: 38801
		// (get) Token: 0x0603B84A RID: 243786 RVA: 0x00F16EE5 File Offset: 0x00F150E5
		// (set) Token: 0x0603B84B RID: 243787 RVA: 0x00F16EED File Offset: 0x00F150ED
		public Action CloseCallBack { get; set; }

		// Token: 0x17009792 RID: 38802
		// (get) Token: 0x0603B84C RID: 243788 RVA: 0x00F16EF6 File Offset: 0x00F150F6
		// (set) Token: 0x0603B84D RID: 243789 RVA: 0x00F16EFE File Offset: 0x00F150FE
		public bool? NeedResetLevelPlayModelRewardFlag { get; set; }

		// Token: 0x17009793 RID: 38803
		// (get) Token: 0x0603B84E RID: 243790 RVA: 0x00F16F07 File Offset: 0x00F15107
		// (set) Token: 0x0603B84F RID: 243791 RVA: 0x00F16F0F File Offset: 0x00F1510F
		public string Tip { get; set; }
	}
}
