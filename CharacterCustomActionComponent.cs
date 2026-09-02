using System;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02002EAD RID: 11949
[NullableContext(2)]
[Nullable(0)]
public class CharacterCustomActionComponent : EntityComponent
{
	// Token: 0x06018851 RID: 100433 RVA: 0x006E076C File Offset: 0x006DE96C
	protected override bool OnStart()
	{
		this.ActorComp = base.Entity.CheckGetComponent<CharacterActorComponent>();
		this.AnimComp = base.Entity.GetComponent<CharacterAnimationComponent>();
		this.MoveComp = base.Entity.GetComponent<CharacterMoveComponent>();
		this.SkillComp = base.Entity.GetComponent<CharacterSkillComponent>();
		this.StateComp = base.Entity.GetComponent<CharacterUnifiedStateComponent>();
		this.InputComp = base.Entity.GetComponent<CharacterInputComponent>();
		this.TagComp = base.Entity.GetComponent<BaseTagComponent>();
		return true;
	}

	// Token: 0x06018852 RID: 100434 RVA: 0x006E07F4 File Offset: 0x006DE9F4
	protected override void OnTick(float delta)
	{
		while (this.ActionQueue.Size > 0)
		{
			CustomActionBase front = this.ActionQueue.Front;
			if (front == null)
			{
				this.ActionQueue.Pop();
			}
			else
			{
				if (!front.CheckStart())
				{
					front.RunAction();
				}
				if (!front.CheckFinish(delta))
				{
					break;
				}
				this.ActionQueue.Pop();
			}
		}
	}

	// Token: 0x06018853 RID: 100435 RVA: 0x006E0854 File Offset: 0x006DEA54
	public void AbortAllAction(bool success)
	{
		while (this.ActionQueue.Size > 0)
		{
			CustomActionBase front = this.ActionQueue.Front;
			if (front == null)
			{
				this.ActionQueue.Pop();
			}
			else
			{
				if (!front.CheckStart())
				{
					front.RunAction();
				}
				front.Abort(success);
				this.ActionQueue.Pop();
			}
		}
	}

	// Token: 0x06018854 RID: 100436 RVA: 0x006E08AF File Offset: 0x006DEAAF
	protected override bool OnEnd()
	{
		return true;
	}

	// Token: 0x06018855 RID: 100437 RVA: 0x006E08B4 File Offset: 0x006DEAB4
	[NullableContext(1)]
	public void AddCustomMoveToLocation(global::Vector loc, Action callback, [Nullable(2)] Action onStart = null)
	{
		if (this.MoveComp == null || this.AnimComp == null)
		{
			return;
		}
		global::Vector targetLocation = global::Vector.Create(loc);
		CustomMoveToLocation element = new CustomMoveToLocation(this.MoveComp, this.AnimComp, targetLocation, callback, onStart, 200);
		this.ActionQueue.Push(element);
	}

	// Token: 0x06018856 RID: 100438 RVA: 0x006E0900 File Offset: 0x006DEB00
	[NullableContext(1)]
	public void AddCustomSetCollision(BaseActorComponent target, bool ignore, [Nullable(2)] Action callback = null)
	{
		if (this.ActorComp == null)
		{
			return;
		}
		CustomSetCollision element = new CustomSetCollision(this.ActorComp, target, ignore, callback);
		this.ActionQueue.Push(element);
	}

	// Token: 0x06018857 RID: 100439 RVA: 0x006E0934 File Offset: 0x006DEB34
	[NullableContext(1)]
	public void AddCustomSetTurnToTarget(BaseActorComponent target, double angle = 0.0, ECustomSetRotationType type = ECustomSetRotationType.FaceToTarget, [Nullable(2)] Action callback = null, int? time = null)
	{
		if (this.ActorComp == null || this.AnimComp == null)
		{
			return;
		}
		CustomSetActorRotation element = new CustomSetActorRotation(this.ActorComp, target, this.AnimComp, angle, type, callback, time.GetValueOrDefault(200));
		this.ActionQueue.Push(element);
	}

	// Token: 0x06018858 RID: 100440 RVA: 0x006E0984 File Offset: 0x006DEB84
	public void AddCustomPlayMontage([Nullable(1)] string path, int? montageId = null, Action onPlayMontage = null, Action onStopMontage = null, Action callback = null)
	{
		if (this.AnimComp == null)
		{
			return;
		}
		AbpMontageData? abpMontageData = (montageId != null) ? ConfigAbpMontageDataById.GetConfig(montageId.Value, true) : null;
		object obj;
		if (abpMontageData == null || abpMontageData.Value.InitState.Length <= 0)
		{
			obj = null;
		}
		else
		{
			(obj = new IAnimStateParam()).InitStateName = abpMontageData.Value.InitState;
		}
		IAnimStateParam state = obj;
		CustomPlayMontage element = new CustomPlayMontage(base.Entity.GetComponent<BasePerformComponent>(), this.AnimComp, path, state, onPlayMontage, onStopMontage, callback);
		this.ActionQueue.Push(element);
	}

	// Token: 0x06018859 RID: 100441 RVA: 0x006E0A28 File Offset: 0x006DEC28
	public void AddCustomSetPlayerControl(bool forbid, Action callback = null)
	{
		CustomSetPlayerControl element = new CustomSetPlayerControl(forbid, this.Reason, this.ActorComp, this.SkillComp, this.StateComp, this.InputComp, this.TagComp, callback);
		this.ActionQueue.Push(element);
	}

	// Token: 0x0601885A RID: 100442 RVA: 0x006E0A70 File Offset: 0x006DEC70
	public void AddCustomWaitMontageEnd(bool waitEnd, bool waitLoop, Action callback = null)
	{
		BasePerformComponent component = base.Entity.GetComponent<BasePerformComponent>();
		if (this.AnimComp == null || component == null)
		{
			return;
		}
		CustomWaitMontageEnd element = new CustomWaitMontageEnd(component, this.AnimComp, waitEnd, waitLoop, callback);
		this.ActionQueue.Push(element);
	}

	// Token: 0x0601885B RID: 100443 RVA: 0x006E0AB4 File Offset: 0x006DECB4
	[NullableContext(1)]
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		CharacterCustomActionComponent characterCustomActionComponent = (CharacterCustomActionComponent)componentTemplate;
		if (base.CanResetComponentProperty("ActorComp"))
		{
			if (characterCustomActionComponent.ActorComp == null)
			{
				this.ActorComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterActorComponent>(this.ActorComp), "ActorComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("MoveComp"))
		{
			if (characterCustomActionComponent.MoveComp == null)
			{
				this.MoveComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterMoveComponent>(this.MoveComp), "MoveComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("AnimComp"))
		{
			if (characterCustomActionComponent.AnimComp == null)
			{
				this.AnimComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterAnimationComponent>(this.AnimComp), "AnimComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("SkillComp"))
		{
			if (characterCustomActionComponent.SkillComp == null)
			{
				this.SkillComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterSkillComponent>(this.SkillComp), "SkillComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("StateComp"))
		{
			if (characterCustomActionComponent.StateComp == null)
			{
				this.StateComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterUnifiedStateComponent>(this.StateComp), "StateComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("InputComp"))
		{
			if (characterCustomActionComponent.InputComp == null)
			{
				this.InputComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterInputComponent>(this.InputComp), "InputComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("TagComp"))
		{
			if (characterCustomActionComponent.TagComp == null)
			{
				this.TagComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BaseTagComponent>(this.TagComp), "TagComp"))
			{
				return false;
			}
		}
		return !base.CanResetComponentProperty("ActionQueue") || characterCustomActionComponent.ActionQueue == null || base.CheckClearObject(EntityComponentSystem.ClearObject<Queue<CustomActionBase>>(this.ActionQueue), "ActionQueue");
	}

	// Token: 0x0400BD4F RID: 48463
	protected const int MODEL_BUFFER_TIME = 200;

	// Token: 0x0400BD50 RID: 48464
	protected const float MAX_ROTATION_TIME = 1000f;

	// Token: 0x0400BD51 RID: 48465
	protected const float ROTATION_ANGLE_TOLERANCE = 10f;

	// Token: 0x0400BD52 RID: 48466
	[Nullable(1)]
	private readonly string Reason = "[CharacterCustomActionComponent] Input Limited Action";

	// Token: 0x0400BD53 RID: 48467
	private CharacterActorComponent ActorComp;

	// Token: 0x0400BD54 RID: 48468
	private CharacterMoveComponent MoveComp;

	// Token: 0x0400BD55 RID: 48469
	private CharacterAnimationComponent AnimComp;

	// Token: 0x0400BD56 RID: 48470
	private CharacterSkillComponent SkillComp;

	// Token: 0x0400BD57 RID: 48471
	private CharacterUnifiedStateComponent StateComp;

	// Token: 0x0400BD58 RID: 48472
	private CharacterInputComponent InputComp;

	// Token: 0x0400BD59 RID: 48473
	private BaseTagComponent TagComp;

	// Token: 0x0400BD5A RID: 48474
	[Nullable(1)]
	private readonly Queue<CustomActionBase> ActionQueue = new Queue<CustomActionBase>(4);
}
