using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.NPC.Animal;

// Token: 0x02002E20 RID: 11808
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
public class AnimalPerformStateBase : StateBase<Entity, EAnimalPerformState>
{
	// Token: 0x06017E2C RID: 97836 RVA: 0x006B130F File Offset: 0x006AF50F
	[NullableContext(1)]
	public AnimalPerformStateBase(Entity owner, EAnimalPerformState state, [Nullable(new byte[]
	{
		2,
		1
	})] StateMachine<Entity, EAnimalPerformState> stateMachine = null) : base(owner, state, stateMachine)
	{
	}

	// Token: 0x1700205B RID: 8283
	// (get) Token: 0x06017E2D RID: 97837 RVA: 0x006B131A File Offset: 0x006AF51A
	// (set) Token: 0x06017E2E RID: 97838 RVA: 0x006B1322 File Offset: 0x006AF522
	public IBPI_AnimalEcological_C AnimalEcologicalInterface
	{
		get
		{
			return this.EcologicalInterface;
		}
		set
		{
			this.EcologicalInterface = value;
		}
	}

	// Token: 0x06017E2F RID: 97839 RVA: 0x006B132B File Offset: 0x006AF52B
	protected override void OnCreate(IEntityArgs args = null)
	{
		this.EcologicalInterface = args.GetP1<IBPI_AnimalEcological_C>();
	}

	// Token: 0x06017E30 RID: 97840 RVA: 0x006B1339 File Offset: 0x006AF539
	protected override void OnDestroy()
	{
		this.AnimalEcologicalInterface = null;
		this.StateMachine = null;
	}

	// Token: 0x06017E31 RID: 97841 RVA: 0x006B1349 File Offset: 0x006AF549
	public float GetActionTime()
	{
		return this.ActionTime;
	}

	// Token: 0x0400B966 RID: 47462
	protected IBPI_AnimalEcological_C EcologicalInterface;

	// Token: 0x0400B967 RID: 47463
	protected float ActionTime;
}
