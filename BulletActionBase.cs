using System;
using System.Runtime.CompilerServices;

// Token: 0x02002D7B RID: 11643
[NullableContext(2)]
[Nullable(0)]
public class BulletActionBase
{
	// Token: 0x060177D4 RID: 96212 RVA: 0x00682A68 File Offset: 0x00680C68
	public BulletActionBase(EBulletAction type)
	{
		this.Type = type;
		if (Singleton<BulletConstant>.Instance.OpenAllActionStat)
		{
			Stat tickStat = null;
			this.TickStat = tickStat;
		}
	}

	// Token: 0x060177D5 RID: 96213 RVA: 0x00682A97 File Offset: 0x00680C97
	[NullableContext(1)]
	public void Execute(BulletInfo bulletInfo, BulletActionInfoBase actionInfo)
	{
		this.BulletInfo = bulletInfo;
		this.ActionInfo = actionInfo;
		this.OnExecute();
	}

	// Token: 0x060177D6 RID: 96214 RVA: 0x00682AAD File Offset: 0x00680CAD
	protected virtual void OnExecute()
	{
	}

	// Token: 0x060177D7 RID: 96215 RVA: 0x00682AAF File Offset: 0x00680CAF
	public void Tick(float delta)
	{
		this.OnTick(delta);
	}

	// Token: 0x060177D8 RID: 96216 RVA: 0x00682AB8 File Offset: 0x00680CB8
	protected virtual void OnTick(float delta)
	{
	}

	// Token: 0x060177D9 RID: 96217 RVA: 0x00682ABA File Offset: 0x00680CBA
	public virtual void AfterTick(float delta)
	{
	}

	// Token: 0x060177DA RID: 96218 RVA: 0x00682ABC File Offset: 0x00680CBC
	public BulletActionInfoBase GetActionInfo()
	{
		return this.ActionInfo;
	}

	// Token: 0x060177DB RID: 96219 RVA: 0x00682AC4 File Offset: 0x00680CC4
	public virtual void Clear()
	{
		this.IsFinish = false;
		this.BulletInfo = null;
		this.ActionInfo = null;
	}

	// Token: 0x0400B416 RID: 46102
	public readonly EBulletAction Type;

	// Token: 0x0400B417 RID: 46103
	public bool IsInPool;

	// Token: 0x0400B418 RID: 46104
	public int Index;

	// Token: 0x0400B419 RID: 46105
	public bool IsFinish;

	// Token: 0x0400B41A RID: 46106
	public BulletInfo BulletInfo;

	// Token: 0x0400B41B RID: 46107
	public BulletActionInfoBase ActionInfo;

	// Token: 0x0400B41C RID: 46108
	private readonly Stat TickStat;
}
