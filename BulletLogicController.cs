using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02002DBE RID: 11710
[NullableContext(2)]
[Nullable(0)]
public class BulletLogicController<[Nullable(0)] T, TParam> : BulletLogicControllerBase where T : UKuroBpDataAsset
{
	// Token: 0x060179DA RID: 96730 RVA: 0x00692426 File Offset: 0x00690626
	[NullableContext(1)]
	protected BulletLogicController(T logicController, Entity bullet) : base(bullet)
	{
		this.LogicController = logicController;
	}

	// Token: 0x060179DB RID: 96731 RVA: 0x00692438 File Offset: 0x00690638
	public override void BulletLogicActionFromBase(object param = null)
	{
		TParam param2;
		if (param is TParam)
		{
			TParam tparam = (TParam)((object)param);
			param2 = tparam;
		}
		else
		{
			param2 = default(TParam);
		}
		this.BulletLogicAction(param2);
	}

	// Token: 0x060179DC RID: 96732 RVA: 0x00692468 File Offset: 0x00690668
	public virtual void BulletLogicAction(TParam param = default(TParam))
	{
	}

	// Token: 0x060179DD RID: 96733 RVA: 0x0069246C File Offset: 0x0069066C
	public override void BulletLogicActionOnHitObstaclesFromBase(object param = null)
	{
		TParam param2;
		if (param is TParam)
		{
			TParam tparam = (TParam)((object)param);
			param2 = tparam;
		}
		else
		{
			param2 = default(TParam);
		}
		this.BulletLogicActionOnHitObstacles(param2);
	}

	// Token: 0x060179DE RID: 96734 RVA: 0x0069249C File Offset: 0x0069069C
	public virtual void BulletLogicActionOnHitObstacles(TParam param = default(TParam))
	{
	}

	// Token: 0x0400B5DD RID: 46557
	[Nullable(1)]
	protected T LogicController;
}
