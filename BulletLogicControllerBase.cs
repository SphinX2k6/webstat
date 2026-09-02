using System;
using System.Runtime.CompilerServices;

// Token: 0x02002DBD RID: 11709
[NullableContext(1)]
[Nullable(0)]
public abstract class BulletLogicControllerBase
{
	// Token: 0x17001F99 RID: 8089
	// (get) Token: 0x060179D1 RID: 96721 RVA: 0x006923EB File Offset: 0x006905EB
	// (set) Token: 0x060179D2 RID: 96722 RVA: 0x006923F3 File Offset: 0x006905F3
	public bool NeedTick
	{
		get
		{
			return this.NeedTickInternal;
		}
		set
		{
			this.NeedTickInternal = value;
		}
	}

	// Token: 0x060179D3 RID: 96723 RVA: 0x006923FC File Offset: 0x006905FC
	protected BulletLogicControllerBase(Entity bullet)
	{
		this.Bullet = (bullet as BulletEntity);
		this.NeedTickInternal = false;
	}

	// Token: 0x060179D4 RID: 96724 RVA: 0x00692417 File Offset: 0x00690617
	public virtual void OnInit()
	{
	}

	// Token: 0x060179D5 RID: 96725
	[NullableContext(2)]
	public abstract void BulletLogicActionFromBase(object param = null);

	// Token: 0x060179D6 RID: 96726
	[NullableContext(2)]
	public abstract void BulletLogicActionOnHitObstaclesFromBase(object param = null);

	// Token: 0x060179D7 RID: 96727 RVA: 0x00692419 File Offset: 0x00690619
	protected virtual void Update(float deltaTime)
	{
	}

	// Token: 0x060179D8 RID: 96728 RVA: 0x0069241B File Offset: 0x0069061B
	public void Tick(float deltaTime)
	{
		this.Update(deltaTime);
	}

	// Token: 0x060179D9 RID: 96729 RVA: 0x00692424 File Offset: 0x00690624
	public virtual void OnBulletDestroy()
	{
	}

	// Token: 0x0400B5DB RID: 46555
	protected BulletEntity Bullet;

	// Token: 0x0400B5DC RID: 46556
	private bool NeedTickInternal;
}
