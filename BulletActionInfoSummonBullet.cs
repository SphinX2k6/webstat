using System;
using System.Runtime.CompilerServices;

// Token: 0x02002D85 RID: 11653
[NullableContext(2)]
[Nullable(0)]
public class BulletActionInfoSummonBullet : BulletActionInfoBase
{
	// Token: 0x06017808 RID: 96264 RVA: 0x00683E4C File Offset: 0x0068204C
	public BulletActionInfoSummonBullet(EBulletAction type) : base(type)
	{
	}

	// Token: 0x06017809 RID: 96265 RVA: 0x00683E5C File Offset: 0x0068205C
	public override void Clear()
	{
		this.ChildrenType = null;
		this.Victim = null;
		this.IsStayInCharacter = false;
		this.ParentImpactPoint = null;
		this.ParentLastPosition = null;
	}

	// Token: 0x0400B447 RID: 46151
	public EBulletChildrenType? ChildrenType;

	// Token: 0x0400B448 RID: 46152
	public Entity Victim;

	// Token: 0x0400B449 RID: 46153
	public bool IsStayInCharacter;

	// Token: 0x0400B44A RID: 46154
	public Vector ParentImpactPoint;

	// Token: 0x0400B44B RID: 46155
	public Vector ParentLastPosition;

	// Token: 0x0400B44C RID: 46156
	public bool CreateOnAuthority = true;
}
