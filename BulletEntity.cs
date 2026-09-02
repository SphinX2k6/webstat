using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.World.Define;

// Token: 0x02002DE2 RID: 11746
[NullableContext(1)]
[Nullable(0)]
public class BulletEntity : Entity
{
	// Token: 0x06017AED RID: 97005 RVA: 0x0069DE6B File Offset: 0x0069C06B
	public BulletEntity(int id, int index) : base(id, index)
	{
	}

	// Token: 0x17001F9E RID: 8094
	// (get) Token: 0x06017AEE RID: 97006 RVA: 0x0069DE87 File Offset: 0x0069C087
	public override bool UsePool { get; } = 1;

	// Token: 0x06017AEF RID: 97007 RVA: 0x0069DE8F File Offset: 0x0069C08F
	protected override TsGameBudgetGroupConfig StaticGameBudgetConfig()
	{
		return new TsGameBudgetGroupConfig(Singleton<GameBudgetAllocatorConfigCreator>.Instance.TsAlwaysTickConfig);
	}

	// Token: 0x06017AF0 RID: 97008 RVA: 0x0069DEA0 File Offset: 0x0069C0A0
	public BulletInfo GetBulletInfo()
	{
		return this.Info;
	}

	// Token: 0x17001F9F RID: 8095
	// (get) Token: 0x06017AF1 RID: 97009 RVA: 0x0069DEA8 File Offset: 0x0069C0A8
	public BulletDataMain Data
	{
		get
		{
			return this.Info.BulletDataMain;
		}
	}

	// Token: 0x17001FA0 RID: 8096
	// (get) Token: 0x06017AF2 RID: 97010 RVA: 0x0069DEB5 File Offset: 0x0069C0B5
	public Entity BulletOwner
	{
		get
		{
			return this.Info.BulletInitParams.Owner;
		}
	}

	// Token: 0x17001FA1 RID: 8097
	// (get) Token: 0x06017AF3 RID: 97011 RVA: 0x0069DEC7 File Offset: 0x0069C0C7
	public bool NeedDestroy
	{
		get
		{
			return this.Info.NeedDestroy;
		}
	}

	// Token: 0x06017AF4 RID: 97012 RVA: 0x0069DED4 File Offset: 0x0069C0D4
	[NullableContext(2)]
	protected override bool OnCreate(IEntityArgs args = null)
	{
		if (!base.AddComponent<BulletActorComponent>(null, null))
		{
			return false;
		}
		if (!base.AddComponent<BulletActionLogicComponent>(null, null))
		{
			return false;
		}
		base.RegisterToGameBudgetController(null);
		return true;
	}

	// Token: 0x06017AF5 RID: 97013 RVA: 0x0069DF1B File Offset: 0x0069C11B
	protected override bool OnStart()
	{
		base.SetTimeDilation(Singleton<Time>.Instance.TimeDilation);
		return true;
	}

	// Token: 0x06017AF6 RID: 97014 RVA: 0x0069DF2E File Offset: 0x0069C12E
	protected override bool OnClear()
	{
		this.Info.Clear();
		return true;
	}

	// Token: 0x06017AF7 RID: 97015 RVA: 0x0069DF3C File Offset: 0x0069C13C
	[NullableContext(2)]
	public override bool Respawn(IEntityArgs args = null)
	{
		base.RegisterToGameBudgetController(null);
		return base.Respawn(args);
	}

	// Token: 0x0400B6B1 RID: 46769
	private readonly BulletInfo Info = new BulletInfo();
}
