using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x0200296F RID: 10607
[NullableContext(1)]
[Nullable(0)]
public class SdkLoginViewData
{
	// Token: 0x0601515C RID: 86364 RVA: 0x005D5762 File Offset: 0x005D3962
	public static SdkLoginViewData Create(string descTextId, Action enterCallback, Action cancelCallback, List<SdkLoginViewLayoutData> layoutData)
	{
		return new SdkLoginViewData
		{
			DescTextId = descTextId,
			EnterCallback = enterCallback,
			CancelCallback = cancelCallback,
			LayoutData = layoutData
		};
	}

	// Token: 0x0400A25B RID: 41563
	public string DescTextId = "";

	// Token: 0x0400A25C RID: 41564
	public Action EnterCallback = delegate()
	{
	};

	// Token: 0x0400A25D RID: 41565
	public Action CancelCallback = delegate()
	{
	};

	// Token: 0x0400A25E RID: 41566
	public List<SdkLoginViewLayoutData> LayoutData = new List<SdkLoginViewLayoutData>();
}
