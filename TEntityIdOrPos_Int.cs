using System;
using System.Runtime.CompilerServices;

// Token: 0x02001DC3 RID: 7619
[NullableContext(1)]
[Nullable(0)]
public class TEntityIdOrPos_Int : TEntityIdOrPos
{
	// Token: 0x0600E15F RID: 57695 RVA: 0x003C983D File Offset: 0x003C7A3D
	public TEntityIdOrPos_Int(int value)
	{
	}

	// Token: 0x0600E160 RID: 57696 RVA: 0x003C984C File Offset: 0x003C7A4C
	public static implicit operator int(TEntityIdOrPos_Int target)
	{
		return target.Value;
	}

	// Token: 0x0600E161 RID: 57697 RVA: 0x003C9854 File Offset: 0x003C7A54
	public new static implicit operator TEntityIdOrPos_Int(int value)
	{
		return new TEntityIdOrPos_Int(value);
	}

	// Token: 0x04006C02 RID: 27650
	public int Value = value;
}
