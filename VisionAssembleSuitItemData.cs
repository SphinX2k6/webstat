using System;
using System.Runtime.CompilerServices;

// Token: 0x020024E6 RID: 9446
public class VisionAssembleSuitItemData
{
	// Token: 0x06012572 RID: 75122 RVA: 0x0050AA68 File Offset: 0x00508C68
	[NullableContext(1)]
	public void Phrase(VisionFetterData data)
	{
		this.FetterGroupId = data.FetterGroupId;
		this.CurrentProgress = data.ActiveFetterGroupNum;
		this.MaxProgress = data.NeedActiveNum;
	}

	// Token: 0x04008F04 RID: 36612
	public int FetterGroupId;

	// Token: 0x04008F05 RID: 36613
	public int CurrentProgress;

	// Token: 0x04008F06 RID: 36614
	public int MaxProgress;
}
