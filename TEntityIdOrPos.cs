using System;
using System.Runtime.CompilerServices;

// Token: 0x02001DC0 RID: 7616
[NullableContext(1)]
[Nullable(0)]
public abstract class TEntityIdOrPos
{
	// Token: 0x0600E155 RID: 57685 RVA: 0x003C97DF File Offset: 0x003C79DF
	public static implicit operator TEntityIdOrPos(TrackVision value)
	{
		return new TEntityIdOrPos_TrackVision(value);
	}

	// Token: 0x0600E156 RID: 57686 RVA: 0x003C97E7 File Offset: 0x003C79E7
	public static implicit operator TEntityIdOrPos(Vector value)
	{
		return new TEntityIdOrPos_Vector(value);
	}

	// Token: 0x0600E157 RID: 57687 RVA: 0x003C97EF File Offset: 0x003C79EF
	public static implicit operator TEntityIdOrPos(int value)
	{
		return new TEntityIdOrPos_Int(value);
	}
}
