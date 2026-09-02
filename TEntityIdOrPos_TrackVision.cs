using System;
using System.Runtime.CompilerServices;

// Token: 0x02001DC1 RID: 7617
[NullableContext(1)]
[Nullable(0)]
public class TEntityIdOrPos_TrackVision : TEntityIdOrPos
{
	// Token: 0x0600E159 RID: 57689 RVA: 0x003C97FF File Offset: 0x003C79FF
	public TEntityIdOrPos_TrackVision(TrackVision value)
	{
	}

	// Token: 0x0600E15A RID: 57690 RVA: 0x003C980E File Offset: 0x003C7A0E
	public static implicit operator TrackVision(TEntityIdOrPos_TrackVision target)
	{
		return target.Value;
	}

	// Token: 0x0600E15B RID: 57691 RVA: 0x003C9816 File Offset: 0x003C7A16
	public new static implicit operator TEntityIdOrPos_TrackVision(TrackVision value)
	{
		return new TEntityIdOrPos_TrackVision(value);
	}

	// Token: 0x04006C00 RID: 27648
	public TrackVision Value = value;
}
