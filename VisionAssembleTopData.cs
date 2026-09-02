using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x020024EC RID: 9452
[NullableContext(1)]
[Nullable(0)]
public class VisionAssembleTopData
{
	// Token: 0x04008F2D RID: 36653
	public string Name = "";

	// Token: 0x04008F2E RID: 36654
	public int Index;

	// Token: 0x04008F2F RID: 36655
	public int Cost;

	// Token: 0x04008F30 RID: 36656
	public List<VisionAssembleSuitItemData> SuitList = new List<VisionAssembleSuitItemData>();
}
