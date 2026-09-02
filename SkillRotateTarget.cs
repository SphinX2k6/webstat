using System;
using System.Runtime.CompilerServices;

// Token: 0x02003112 RID: 12562
[NullableContext(2)]
[Nullable(0)]
public class SkillRotateTarget
{
	// Token: 0x06019F8F RID: 106383 RVA: 0x0079A392 File Offset: 0x00798592
	public void Reset()
	{
		this.TargetVector = null;
		this.TargetString = null;
		this.Type = ESkillRotateType.None;
	}

	// Token: 0x0400D05B RID: 53339
	public Vector TargetVector;

	// Token: 0x0400D05C RID: 53340
	public string TargetString;

	// Token: 0x0400D05D RID: 53341
	public ESkillRotateType Type;
}
