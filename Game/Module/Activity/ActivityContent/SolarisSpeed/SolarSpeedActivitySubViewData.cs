using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.SolarisSpeed
{
	// Token: 0x02006374 RID: 25460
	[NullableContext(1)]
	[Nullable(0)]
	public class SolarSpeedActivitySubViewData : ISolarSpeedActivitySubViewData
	{
		// Token: 0x17009CF4 RID: 40180
		// (get) Token: 0x0603FEF7 RID: 261879 RVA: 0x01066750 File Offset: 0x01064950
		// (set) Token: 0x0603FEF8 RID: 261880 RVA: 0x01066758 File Offset: 0x01064958
		public string RewardTextId { get; set; }

		// Token: 0x17009CF5 RID: 40181
		// (get) Token: 0x0603FEF9 RID: 261881 RVA: 0x01066761 File Offset: 0x01064961
		// (set) Token: 0x0603FEFA RID: 261882 RVA: 0x01066769 File Offset: 0x01064969
		public string ButtonTextId { get; set; }

		// Token: 0x17009CF6 RID: 40182
		// (get) Token: 0x0603FEFB RID: 261883 RVA: 0x01066772 File Offset: 0x01064972
		// (set) Token: 0x0603FEFC RID: 261884 RVA: 0x0106677A File Offset: 0x0106497A
		public Func<bool> RewardRedDotStateGetter { get; set; }

		// Token: 0x17009CF7 RID: 40183
		// (get) Token: 0x0603FEFD RID: 261885 RVA: 0x01066783 File Offset: 0x01064983
		// (set) Token: 0x0603FEFE RID: 261886 RVA: 0x0106678B File Offset: 0x0106498B
		public Func<bool> ConfirmRedDotStateGetter { get; set; }

		// Token: 0x17009CF8 RID: 40184
		// (get) Token: 0x0603FEFF RID: 261887 RVA: 0x01066794 File Offset: 0x01064994
		// (set) Token: 0x0603FF00 RID: 261888 RVA: 0x0106679C File Offset: 0x0106499C
		public Func<string> RewardProgressCurrentGetter { get; set; }

		// Token: 0x17009CF9 RID: 40185
		// (get) Token: 0x0603FF01 RID: 261889 RVA: 0x010667A5 File Offset: 0x010649A5
		// (set) Token: 0x0603FF02 RID: 261890 RVA: 0x010667AD File Offset: 0x010649AD
		public string RewardProgressTextId { get; set; }

		// Token: 0x17009CFA RID: 40186
		// (get) Token: 0x0603FF03 RID: 261891 RVA: 0x010667B6 File Offset: 0x010649B6
		// (set) Token: 0x0603FF04 RID: 261892 RVA: 0x010667BE File Offset: 0x010649BE
		public string RewardProgressTotal { get; set; }
	}
}
