using System;

namespace CSharpScript.Game.Module.Plot.Flow
{
	// Token: 0x020053FD RID: 21501
	[Flags]
	public enum ESeamlessFinalizeFlag
	{
		// Token: 0x0401F988 RID: 129416
		None = 0,
		// Token: 0x0401F989 RID: 129417
		ActorAllStop = 1,
		// Token: 0x0401F98A RID: 129418
		ExitMovieMode = 2,
		// Token: 0x0401F98B RID: 129419
		ExitSequenceCamera = 4,
		// Token: 0x0401F98C RID: 129420
		UiRemoveAspectView = 8,
		// Token: 0x0401F98D RID: 129421
		TemplateResetCamera = 16
	}
}
