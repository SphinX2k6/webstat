using System;
using System.Runtime.CompilerServices;

// Token: 0x0200189B RID: 6299
[NullableContext(1)]
[Nullable(0)]
public class ButtonItemData
{
	// Token: 0x0400555C RID: 21852
	public Action<int> OnClickCallback = delegate(int data)
	{
	};

	// Token: 0x0400555D RID: 21853
	public string ButtonText = "";

	// Token: 0x0400555E RID: 21854
	public int Index;

	// Token: 0x0400555F RID: 21855
	public ERedDotName? RedDotName;
}
