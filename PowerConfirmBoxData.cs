using System;
using CSharpScript.Game.Ui;

// Token: 0x02002601 RID: 9729
public class PowerConfirmBoxData : UiPopViewData
{
	// Token: 0x06013113 RID: 78099 RVA: 0x0054902D File Offset: 0x0054722D
	public PowerConfirmBoxData(int powerCount, EPowerMenuType type = EPowerMenuType.Supply, bool updateCurrentNeedPower = false, int autoClosePowerCount = -1)
	{
		this.PowerCount = powerCount;
		this.Type = type;
		this.UpdateCurrentNeedPower = updateCurrentNeedPower;
		this.AutoClosePowerCount = autoClosePowerCount;
	}

	// Token: 0x040094C8 RID: 38088
	public int PowerCount;

	// Token: 0x040094C9 RID: 38089
	public EPowerMenuType Type = EPowerMenuType.Supply;

	// Token: 0x040094CA RID: 38090
	public bool UpdateCurrentNeedPower;

	// Token: 0x040094CB RID: 38091
	public int AutoClosePowerCount = -1;
}
