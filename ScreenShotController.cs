using System;
using System.Runtime.CompilerServices;

// Token: 0x02002967 RID: 10599
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class ScreenShotController : ControllerBase<ScreenShotController>
{
	// Token: 0x0601513D RID: 86333 RVA: 0x005D5417 File Offset: 0x005D3617
	protected override bool OnClear()
	{
		ScreenShotManager.Clear();
		return true;
	}

	// Token: 0x0601513E RID: 86334 RVA: 0x005D541F File Offset: 0x005D361F
	protected override bool OnLeaveLevel()
	{
		ScreenShotManager.Clear();
		return true;
	}
}
