using System;

namespace CSharpScript.Game.Module.Activity.ActivityContent.WheelTower
{
	// Token: 0x02006220 RID: 25120
	public interface IWheelTowerMedalGroupData
	{
		// Token: 0x17009C0E RID: 39950
		// (get) Token: 0x0603F623 RID: 259619
		// (set) Token: 0x0603F624 RID: 259620
		int GroupId { get; set; }

		// Token: 0x17009C0F RID: 39951
		// (get) Token: 0x0603F625 RID: 259621
		// (set) Token: 0x0603F626 RID: 259622
		int SeasonId { get; set; }

		// Token: 0x17009C10 RID: 39952
		// (get) Token: 0x0603F627 RID: 259623
		// (set) Token: 0x0603F628 RID: 259624
		int CycleId { get; set; }

		// Token: 0x17009C11 RID: 39953
		// (get) Token: 0x0603F629 RID: 259625
		// (set) Token: 0x0603F62A RID: 259626
		int Progress { get; set; }

		// Token: 0x17009C12 RID: 39954
		// (get) Token: 0x0603F62B RID: 259627
		// (set) Token: 0x0603F62C RID: 259628
		long CompleteTime { get; set; }

		// Token: 0x17009C13 RID: 39955
		// (get) Token: 0x0603F62D RID: 259629
		// (set) Token: 0x0603F62E RID: 259630
		int CurrentMedalId { get; set; }

		// Token: 0x17009C14 RID: 39956
		// (get) Token: 0x0603F62F RID: 259631
		// (set) Token: 0x0603F630 RID: 259632
		int NextMedalId { get; set; }

		// Token: 0x17009C15 RID: 39957
		// (get) Token: 0x0603F631 RID: 259633
		// (set) Token: 0x0603F632 RID: 259634
		int CurrentTarget { get; set; }

		// Token: 0x17009C16 RID: 39958
		// (get) Token: 0x0603F633 RID: 259635
		// (set) Token: 0x0603F634 RID: 259636
		bool IsMaxLevel { get; set; }
	}
}
