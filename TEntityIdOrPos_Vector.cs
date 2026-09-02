using System;
using System.Runtime.CompilerServices;

// Token: 0x02001DC2 RID: 7618
[NullableContext(1)]
[Nullable(0)]
public class TEntityIdOrPos_Vector : TEntityIdOrPos
{
	// Token: 0x0600E15C RID: 57692 RVA: 0x003C981E File Offset: 0x003C7A1E
	public TEntityIdOrPos_Vector(Vector value)
	{
	}

	// Token: 0x0600E15D RID: 57693 RVA: 0x003C982D File Offset: 0x003C7A2D
	public static implicit operator Vector(TEntityIdOrPos_Vector target)
	{
		return target.Value;
	}

	// Token: 0x0600E15E RID: 57694 RVA: 0x003C9835 File Offset: 0x003C7A35
	public new static implicit operator TEntityIdOrPos_Vector(Vector value)
	{
		return new TEntityIdOrPos_Vector(value);
	}

	// Token: 0x04006C01 RID: 27649
	public Vector Value = value;
}
