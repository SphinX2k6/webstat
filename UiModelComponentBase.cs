using System;
using System.Runtime.CompilerServices;

// Token: 0x02002CB7 RID: 11447
[NullableContext(1)]
[Nullable(0)]
public abstract class UiModelComponentBase
{
	// Token: 0x17001E3B RID: 7739
	// (get) Token: 0x06016F9F RID: 94111 RVA: 0x0065ED05 File Offset: 0x0065CF05
	public UiModelBase Owner
	{
		get
		{
			return this.OwnerInternal;
		}
	}

	// Token: 0x06016FA0 RID: 94112 RVA: 0x0065ED0D File Offset: 0x0065CF0D
	public void Create(UiModelBase owner)
	{
		this.OwnerInternal = owner;
		this.OnCreate();
	}

	// Token: 0x06016FA1 RID: 94113 RVA: 0x0065ED1C File Offset: 0x0065CF1C
	public void Init()
	{
		this.OnInit();
	}

	// Token: 0x06016FA2 RID: 94114 RVA: 0x0065ED24 File Offset: 0x0065CF24
	public void Start()
	{
		this.OnStart();
	}

	// Token: 0x06016FA3 RID: 94115 RVA: 0x0065ED2C File Offset: 0x0065CF2C
	public virtual void Tick(float deltaTime)
	{
		this.OnTick(deltaTime);
	}

	// Token: 0x06016FA4 RID: 94116 RVA: 0x0065ED35 File Offset: 0x0065CF35
	public void End()
	{
		this.OnEnd();
	}

	// Token: 0x06016FA5 RID: 94117 RVA: 0x0065ED3D File Offset: 0x0065CF3D
	public void Clear()
	{
		this.OnClear();
	}

	// Token: 0x06016FA6 RID: 94118 RVA: 0x0065ED45 File Offset: 0x0065CF45
	protected virtual void OnCreate()
	{
	}

	// Token: 0x06016FA7 RID: 94119 RVA: 0x0065ED47 File Offset: 0x0065CF47
	protected virtual void OnInit()
	{
	}

	// Token: 0x06016FA8 RID: 94120 RVA: 0x0065ED49 File Offset: 0x0065CF49
	protected virtual void OnStart()
	{
	}

	// Token: 0x06016FA9 RID: 94121 RVA: 0x0065ED4B File Offset: 0x0065CF4B
	protected virtual void OnTick(float deltaTime)
	{
	}

	// Token: 0x06016FAA RID: 94122 RVA: 0x0065ED4D File Offset: 0x0065CF4D
	protected virtual void OnEnd()
	{
	}

	// Token: 0x06016FAB RID: 94123 RVA: 0x0065ED4F File Offset: 0x0065CF4F
	protected virtual void OnClear()
	{
	}

	// Token: 0x0400B130 RID: 45360
	public bool NeedTick;

	// Token: 0x0400B131 RID: 45361
	private UiModelBase OwnerInternal;
}
