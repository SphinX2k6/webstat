using System;
using System.Runtime.CompilerServices;

// Token: 0x02001EFB RID: 7931
[NullableContext(2)]
[Nullable(0)]
public class HonamiStoryInteractOperateAgent
{
	// Token: 0x0600EC73 RID: 60531 RVA: 0x004054DA File Offset: 0x004036DA
	public void Clear()
	{
		this.StartOperateBackpack = null;
		this.OperateData = null;
		this.BaseHeight = 0f;
		this.BaseWidth = 0f;
		this.TargetOperateBackpack = null;
		this.TargetPosition = -1;
	}

	// Token: 0x0400719F RID: 29087
	public HonamiStoryBackpackPanelBase StartOperateBackpack;

	// Token: 0x040071A0 RID: 29088
	public HonamiStoryItemDataBase OperateData;

	// Token: 0x040071A1 RID: 29089
	public float BaseWidth;

	// Token: 0x040071A2 RID: 29090
	public float BaseHeight;

	// Token: 0x040071A3 RID: 29091
	public HonamiStoryBackpackPanelBase TargetOperateBackpack;

	// Token: 0x040071A4 RID: 29092
	public int TargetPosition = -1;
}
