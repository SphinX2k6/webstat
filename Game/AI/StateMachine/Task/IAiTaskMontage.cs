using System;

namespace CSharpScript.Game.AI.StateMachine.Task
{
	// Token: 0x020070DF RID: 28895
	public interface IAiTaskMontage
	{
		// Token: 0x1700A5F0 RID: 42480
		// (get) Token: 0x060460F7 RID: 286967
		// (set) Token: 0x060460F8 RID: 286968
		bool Playing { get; set; }

		// Token: 0x1700A5F1 RID: 42481
		// (get) Token: 0x060460F9 RID: 286969
		bool HasResource { get; }

		// Token: 0x060460FA RID: 286970
		double GetTimeElapsing();

		// Token: 0x1700A5F2 RID: 42482
		// (get) Token: 0x060460FB RID: 286971
		// (set) Token: 0x060460FC RID: 286972
		float RemainedTrigger { get; set; }

		// Token: 0x060460FD RID: 286973
		double GetTimeLength();

		// Token: 0x060460FE RID: 286974
		double GetTimeRemaining();
	}
}
