using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Quest;

// Token: 0x02001DEC RID: 7660
[NullableContext(1)]
[Nullable(0)]
public class SilentAreaShowInfo
{
	// Token: 0x0600E22D RID: 57901 RVA: 0x003CE807 File Offset: 0x003CCA07
	public SilentAreaShowInfo(int sourceOfAdd, IInformationViewType showInfo)
	{
	}

	// Token: 0x04006CBC RID: 27836
	public int SourceOfAdd = sourceOfAdd;

	// Token: 0x04006CBD RID: 27837
	public IInformationViewType ShowInfo = showInfo;
}
