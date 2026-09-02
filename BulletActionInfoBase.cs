using System;

// Token: 0x02002D83 RID: 11651
public class BulletActionInfoBase
{
	// Token: 0x06017804 RID: 96260 RVA: 0x00683E06 File Offset: 0x00682006
	public BulletActionInfoBase(EBulletAction type)
	{
		this.Type = type;
	}

	// Token: 0x06017805 RID: 96261 RVA: 0x00683E18 File Offset: 0x00682018
	public virtual void Clear()
	{
		Singleton<Log>.Instance.Error(ELogModule.Bullet, ELogAuthor.CFT, "BulletActionInfo need override clear()", default(ReadOnlySpan<ValueTuple<string, object>>));
	}

	// Token: 0x0400B444 RID: 46148
	public readonly EBulletAction Type;

	// Token: 0x0400B445 RID: 46149
	public bool IsInPool;

	// Token: 0x0400B446 RID: 46150
	public int Index;
}
