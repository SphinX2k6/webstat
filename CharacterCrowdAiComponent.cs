using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;

// Token: 0x02003035 RID: 12341
[NullableContext(2)]
[Nullable(0)]
public class CharacterCrowdAiComponent : BaseCrowdAiComponent
{
	// Token: 0x17002203 RID: 8707
	// (get) Token: 0x060193C3 RID: 103363 RVA: 0x00739884 File Offset: 0x00737A84
	protected new CharacterActorComponent ActorComp
	{
		get
		{
			return this.ActorComp as CharacterActorComponent;
		}
	}

	// Token: 0x060193C4 RID: 103364 RVA: 0x00739891 File Offset: 0x00737A91
	protected override bool OnStart()
	{
		base.OnStart();
		this.ActorComp = base.Entity.GetComponent<CharacterActorComponent>();
		Singleton<EventSystem>.Instance.AddWithTarget(base.Entity, EEventName.OnChangeRole, new Action<EntityHandle, EntityHandle>(this.OnChangeRole));
		return true;
	}

	// Token: 0x060193C5 RID: 103365 RVA: 0x007398CE File Offset: 0x00737ACE
	protected override bool OnEnd()
	{
		Singleton<EventSystem>.Instance.RemoveWithTarget(base.Entity, EEventName.OnChangeRole, new Action<EntityHandle, EntityHandle>(this.OnChangeRole));
		return base.OnEnd();
	}

	// Token: 0x060193C6 RID: 103366 RVA: 0x007398F8 File Offset: 0x00737AF8
	protected override void OnTick(float delta)
	{
		this.UpdateRadius(delta * 0.001f);
	}

	// Token: 0x060193C7 RID: 103367 RVA: 0x00739907 File Offset: 0x00737B07
	protected override void OnBoidComponentCreated()
	{
		base.OnBoidComponentCreated();
		this.InitFromRoleBoidParams(ControllerBase<CrowdAiController>.Instance.RoleParams);
	}

	// Token: 0x060193C8 RID: 103368 RVA: 0x0073991F File Offset: 0x00737B1F
	protected void InitFromRoleBoidParams(RoleBoidParams @params)
	{
		if (@params == null)
		{
			return;
		}
		this.MaxRadius = @params.MaxRadius;
		this.MinRadius = @params.MinRadius;
		this.MaxRadiusChangeTime = @params.MaxRadiusChangeTime;
	}

	// Token: 0x060193C9 RID: 103369 RVA: 0x0073994C File Offset: 0x00737B4C
	protected void UpdateRadius(float delta)
	{
		if (this.BoidComponent == null)
		{
			return;
		}
		Singleton<MathUtils>.Instance.CommonTempVector.DeepCopy(this.ActorComp.ActorLocationProxy);
		Singleton<MathUtils>.Instance.CommonTempVector.SubtractionEqual(this.ActorComp.LastActorLocation);
		Singleton<GravityUtils>.Instance.ConvertToPlanarVectorForActor(this.ActorComp, Singleton<MathUtils>.Instance.CommonTempVector);
		if (Singleton<MathUtils>.Instance.CommonTempVector.SizeSquared() > (double)(delta * delta * 400f))
		{
			this.CurRadius = this.MinRadius;
		}
		else
		{
			float num = (this.MaxRadius - this.MinRadius) / this.MaxRadiusChangeTime;
			this.CurRadius = Math.Min(this.CurRadius + delta * num, this.MaxRadius);
		}
		this.BoidComponent.Radius = this.CurRadius;
	}

	// Token: 0x060193CA RID: 103370 RVA: 0x00739A1C File Offset: 0x00737C1C
	[NullableContext(1)]
	protected void OnChangeRole(EntityHandle newEntity, [Nullable(2)] EntityHandle oldEntity)
	{
		WorldEntity entity = newEntity.Entity;
		CharacterCrowdAiComponent characterCrowdAiComponent = (entity != null) ? entity.GetComponent<CharacterCrowdAiComponent>() : null;
		CharacterCrowdAiComponent characterCrowdAiComponent2;
		if (oldEntity == null)
		{
			characterCrowdAiComponent2 = null;
		}
		else
		{
			WorldEntity entity2 = oldEntity.Entity;
			characterCrowdAiComponent2 = ((entity2 != null) ? entity2.GetComponent<CharacterCrowdAiComponent>() : null);
		}
		CharacterCrowdAiComponent characterCrowdAiComponent3 = characterCrowdAiComponent2;
		if (characterCrowdAiComponent3 == null || characterCrowdAiComponent == null)
		{
			return;
		}
		characterCrowdAiComponent.CurRadius = characterCrowdAiComponent3.CurRadius;
		characterCrowdAiComponent.MinRadius = characterCrowdAiComponent3.MinRadius;
		characterCrowdAiComponent.MaxRadius = characterCrowdAiComponent3.MaxRadius;
		characterCrowdAiComponent.MaxRadiusChangeTime = characterCrowdAiComponent3.MaxRadiusChangeTime;
	}

	// Token: 0x060193CB RID: 103371 RVA: 0x00739A8C File Offset: 0x00737C8C
	[NullableContext(1)]
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		CharacterCrowdAiComponent characterCrowdAiComponent = (CharacterCrowdAiComponent)componentTemplate;
		if (base.CanResetComponentProperty("CurRadius"))
		{
			this.CurRadius = characterCrowdAiComponent.CurRadius;
		}
		if (base.CanResetComponentProperty("MinRadius"))
		{
			this.MinRadius = characterCrowdAiComponent.MinRadius;
		}
		if (base.CanResetComponentProperty("MaxRadius"))
		{
			this.MaxRadius = characterCrowdAiComponent.MaxRadius;
		}
		if (base.CanResetComponentProperty("MaxRadiusChangeTime"))
		{
			this.MaxRadiusChangeTime = characterCrowdAiComponent.MaxRadiusChangeTime;
		}
		return true;
	}

	// Token: 0x0400C691 RID: 50833
	private const int STOP_MOVE_MAX_SPEED_SQUARED = 400;

	// Token: 0x0400C692 RID: 50834
	protected float CurRadius = 20f;

	// Token: 0x0400C693 RID: 50835
	protected float MinRadius = 20f;

	// Token: 0x0400C694 RID: 50836
	protected float MaxRadius = 80f;

	// Token: 0x0400C695 RID: 50837
	protected float MaxRadiusChangeTime = 1f;
}
