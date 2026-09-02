using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02002478 RID: 9336
public class LevelUpPastVisionData
{
	// Token: 0x04008D48 RID: 36168
	public int Level;

	// Token: 0x04008D49 RID: 36169
	public int UniqueId;

	// Token: 0x04008D4A RID: 36170
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public List<AttrListScrollData> AttrListScrollData;

	// Token: 0x04008D4B RID: 36171
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public List<VisionSlotData> SlotData;

	// Token: 0x04008D4C RID: 36172
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public List<Aki.Protocol.PhantomPropInfo> SubProp;
}
