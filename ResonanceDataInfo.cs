using System;

// Token: 0x020027B5 RID: 10165
public class ResonanceDataInfo
{
	// Token: 0x0601419D RID: 82333 RVA: 0x0059DAA8 File Offset: 0x0059BCA8
	public ResonanceDataInfo(int resonId, bool isOpen, int increase)
	{
		this.ResonId = resonId;
		this.IsOpen = isOpen;
		this.Increase = increase;
	}

	// Token: 0x04009C63 RID: 40035
	public readonly int ResonId;

	// Token: 0x04009C64 RID: 40036
	public readonly bool IsOpen;

	// Token: 0x04009C65 RID: 40037
	public readonly int Increase;
}
