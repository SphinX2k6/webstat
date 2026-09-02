using System;

namespace CSharpScript.Game.Ui
{
	// Token: 0x02004993 RID: 18835
	internal class ActionCommandNode : IActionCommandNode
	{
		// Token: 0x170083E6 RID: 33766
		// (get) Token: 0x0603132C RID: 201516 RVA: 0x00C4117F File Offset: 0x00C3F37F
		// (set) Token: 0x0603132D RID: 201517 RVA: 0x00C41187 File Offset: 0x00C3F387
		public EActionCommandType ActionCommand { get; set; }

		// Token: 0x170083E7 RID: 33767
		// (get) Token: 0x0603132E RID: 201518 RVA: 0x00C41190 File Offset: 0x00C3F390
		// (set) Token: 0x0603132F RID: 201519 RVA: 0x00C41198 File Offset: 0x00C3F398
		public bool Processed { get; set; }
	}
}
