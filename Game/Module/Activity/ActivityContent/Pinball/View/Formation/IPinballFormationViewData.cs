using System;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Formation
{
	// Token: 0x02006632 RID: 26162
	public interface IPinballFormationViewData
	{
		// Token: 0x17009F6A RID: 40810
		// (get) Token: 0x06041597 RID: 267671
		// (set) Token: 0x06041598 RID: 267672
		int LevelId { get; set; }

		// Token: 0x17009F6B RID: 40811
		// (get) Token: 0x06041599 RID: 267673
		// (set) Token: 0x0604159A RID: 267674
		bool? IsRestart { get; set; }

		// Token: 0x17009F6C RID: 40812
		// (get) Token: 0x0604159B RID: 267675
		// (set) Token: 0x0604159C RID: 267676
		bool? IfReturnToPinballMainView { get; set; }
	}
}
