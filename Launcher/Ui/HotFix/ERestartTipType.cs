using System;
using CSharpScript.Core.Common;

namespace CSharpScript.Launcher.Ui.HotFix
{
	// Token: 0x0200450E RID: 17678
	[EnumExtensions]
	public enum ERestartTipType
	{
		// Token: 0x0401A749 RID: 108361
		[EnumStringMember("HotFixRestartToCompleteHotFix")]
		HotFixComplete,
		// Token: 0x0401A74A RID: 108362
		[EnumStringMember("HotFixRestartToRepairFiles")]
		RepairFilesComplete,
		// Token: 0x0401A74B RID: 108363
		[EnumStringMember("HotFixRestartToCompleteHotFixWin")]
		HotFixCompleteWin,
		// Token: 0x0401A74C RID: 108364
		[EnumStringMember("HotFixRestartToRepairFilesWin")]
		RepairFilesCompleteWin
	}
}
