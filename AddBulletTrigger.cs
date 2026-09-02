using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02002EE7 RID: 12007
[NullableContext(1)]
[Nullable(0)]
public class AddBulletTrigger : PassiveEffects
{
	// Token: 0x06018A95 RID: 101013 RVA: 0x006F5292 File Offset: 0x006F3492
	public AddBulletTrigger(int activeHandleId, int index, RequireAndLimits requireAndLimits, BaseBuffComponent ownerBuffComponent, [Nullable(2)] CharacterBuffComponent instigatorBuffComponent) : base(activeHandleId, index, requireAndLimits, ownerBuffComponent, instigatorBuffComponent)
	{
	}

	// Token: 0x06018A96 RID: 101014 RVA: 0x006F52AC File Offset: 0x006F34AC
	protected override void InitParameters(ExtraEffectParameters parameters)
	{
		string[] extraEffectParameters_ = parameters.ExtraEffectParameters_;
		this.EventType = (EBuffTriggerType)int.Parse(extraEffectParameters_[0]);
		this.TargetType = (EPassiveEffectTargetType)int.Parse(extraEffectParameters_[1]);
		string[] array = extraEffectParameters_[2].Split('#', StringSplitOptions.None);
		this.BulletIds = new long[array.Length];
		for (int i = 0; i < array.Length; i++)
		{
			this.BulletIds[i] = long.Parse(array[i]);
		}
	}

	// Token: 0x06018A97 RID: 101015 RVA: 0x006F5314 File Offset: 0x006F3514
	[return: Nullable(2)]
	public override object OnExecute(params object[] parameters)
	{
		IBuffComponent effectTarget = base.GetEffectTarget();
		Entity entity = (effectTarget != null) ? effectTarget.GetEntity() : null;
		FTransformDouble? ftransformDouble;
		if (entity == null)
		{
			ftransformDouble = null;
		}
		else
		{
			BaseActorComponent baseActorComponent = entity.CheckGetComponent<BaseActorComponent>();
			ftransformDouble = ((baseActorComponent != null) ? new FTransformDouble?(baseActorComponent.ActorTransform) : null);
		}
		FTransformDouble? initialTransform = ftransformDouble;
		BaseBuffComponent instigatorBuffComponent = base.InstigatorBuffComponent;
		Entity entity2;
		if (instigatorBuffComponent == null)
		{
			entity2 = null;
		}
		else
		{
			BaseActorComponent actorComponent = instigatorBuffComponent.GetActorComponent();
			entity2 = ((actorComponent != null) ? actorComponent.Entity : null);
		}
		Entity entity3 = entity2;
		if (entity == null || entity3 == null || initialTransform == null)
		{
			return null;
		}
		long? messageId = base.Buff.MessageId;
		for (int i = 0; i < this.BulletIds.Length; i++)
		{
			ControllerBase<BulletController>.Instance.CreateBulletCustomTarget(entity3, this.BulletIds[i].ToString(), initialTransform, new BulletController.BulletCreateParams
			{
				SyncType = EBulletSyncType.SyncCreate,
				CreateOnAuthority = false
			}, messageId, EBulletCreateSource.Others);
		}
		return null;
	}

	// Token: 0x06018A98 RID: 101016 RVA: 0x006F53E9 File Offset: 0x006F35E9
	public override string GetDebugEffectString()
	{
		return base.GetDebugTriggerString() + "创建子弹 " + string.Join<long>(", ", this.BulletIds);
	}

	// Token: 0x0400BF2F RID: 48943
	private long[] BulletIds = Array.Empty<long>();
}
