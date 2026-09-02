using System;

namespace CSharpScript.Game.Ui
{
	// Token: 0x02004992 RID: 18834
	internal interface IActionCommandNode
	{
		// Token: 0x170083E4 RID: 33764
		// (get) Token: 0x06031328 RID: 201512
		// (set) Token: 0x06031329 RID: 201513
		EActionCommandType ActionCommand { get; set; }

		// Token: 0x170083E5 RID: 33765
		// (get) Token: 0x0603132A RID: 201514
		// (set) Token: 0x0603132B RID: 201515
		bool Processed { get; set; }
	}
}
