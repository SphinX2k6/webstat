using System;

// Token: 0x020031C1 RID: 12737
public class NpcRedDotFlowLogic
{
	// Token: 0x0601A696 RID: 108182 RVA: 0x007CA4BD File Offset: 0x007C86BD
	public bool GetRedDotActive()
	{
		if (!this.ManualControl)
		{
			this.CheckRedDotCondition();
		}
		return this.RedDotActive;
	}

	// Token: 0x0601A697 RID: 108183 RVA: 0x007CA4D3 File Offset: 0x007C86D3
	private void CheckRedDotCondition()
	{
		this.RedDotActive = false;
	}

	// Token: 0x0601A698 RID: 108184 RVA: 0x007CA4DC File Offset: 0x007C86DC
	public void ManualControlRedDotActive(bool manualControl, bool redDotActive)
	{
		this.ManualControl = manualControl;
		if (this.ManualControl)
		{
			this.RedDotActive = redDotActive;
			return;
		}
		this.RedDotActive = false;
	}

	// Token: 0x0601A699 RID: 108185 RVA: 0x007CA4FC File Offset: 0x007C86FC
	public void Clear()
	{
		this.RedDotActive = false;
		this.ManualControl = false;
	}

	// Token: 0x0400D524 RID: 54564
	private bool RedDotActive;

	// Token: 0x0400D525 RID: 54565
	private bool ManualControl;
}
