using System;
using System.Runtime.CompilerServices;

// Token: 0x020019A9 RID: 6569
[NullableContext(1)]
[Nullable(0)]
public class SequenceData
{
	// Token: 0x0600BCB4 RID: 48308 RVA: 0x00321CAC File Offset: 0x0031FEAC
	public SequenceData(string sequenceName, bool isBlock, string tag, [Nullable(2)] CustomPromise<bool> stopPromise = null)
	{
		this.SequenceName = sequenceName;
		this.IsBlock = isBlock;
		this.Tag = tag;
		this.StopPromise = stopPromise;
	}

	// Token: 0x0400593D RID: 22845
	public readonly string SequenceName = "";

	// Token: 0x0400593E RID: 22846
	public readonly bool IsBlock;

	// Token: 0x0400593F RID: 22847
	public readonly string Tag = "";

	// Token: 0x04005940 RID: 22848
	public bool NeedFinishEvent = true;

	// Token: 0x04005941 RID: 22849
	[Nullable(2)]
	public CustomPromise<bool> StopPromise;
}
