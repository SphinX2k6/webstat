using System;
using System.Runtime.CompilerServices;

// Token: 0x02002EE6 RID: 12006
[NullableContext(1)]
[Nullable(0)]
public class AddBuffTrigger : PassiveEffects
{
	// Token: 0x06018A91 RID: 101009 RVA: 0x006F50E6 File Offset: 0x006F32E6
	public AddBuffTrigger(int activeHandleId, int index, RequireAndLimits requireAndLimits, BaseBuffComponent ownerBuffComponent, [Nullable(2)] CharacterBuffComponent instigatorBuffComponent) : base(activeHandleId, index, requireAndLimits, ownerBuffComponent, instigatorBuffComponent)
	{
	}

	// Token: 0x06018A92 RID: 101010 RVA: 0x006F5108 File Offset: 0x006F3308
	protected override void InitParameters(ExtraEffectParameters parameters)
	{
		string[] extraEffectParameters_ = parameters.ExtraEffectParameters_;
		this.EventType = (EBuffTriggerType)int.Parse(extraEffectParameters_[0]);
		this.TargetType = (EPassiveEffectTargetType)int.Parse(extraEffectParameters_[1]);
		string[] array = extraEffectParameters_[2].Split('#', StringSplitOptions.None);
		this.BuffIds = new long[array.Length];
		for (int i = 0; i < array.Length; i++)
		{
			this.BuffIds[i] = long.Parse(array[i]);
		}
		this.InstigatorType = (EPassiveEffectTargetType)((extraEffectParameters_.Length > 3) ? int.Parse(extraEffectParameters_[3]) : 2);
	}

	// Token: 0x06018A93 RID: 101011 RVA: 0x006F5188 File Offset: 0x006F3388
	[return: Nullable(2)]
	public override object OnExecute(params object[] parameters)
	{
		IBuffComponent effectTarget = base.GetEffectTarget();
		IBuffComponent targetByType = base.GetTargetByType(this.InstigatorType);
		if (effectTarget == null)
		{
			return null;
		}
		IActiveBuff buffByHandle = this.OwnerBuffComponent.GetBuffByHandle(base.ActiveHandleId);
		if (buffByHandle != null && buffByHandle.IsValid())
		{
			for (int i = 0; i < this.BuffIds.Length; i++)
			{
				IBuffComponent buffComponent = effectTarget;
				long buffId = this.BuffIds[i];
				IActiveBuff preBuff = buffByHandle;
				int? stackCount = null;
				bool isIterable = true;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(38, 2);
				defaultInterpolatedStringHandler.AppendLiteral("因为触发其它buff额外效果而添加（前置buff Id=");
				defaultInterpolatedStringHandler.AppendFormatted<long>(this.BuffId);
				defaultInterpolatedStringHandler.AppendLiteral(", handle=");
				defaultInterpolatedStringHandler.AppendFormatted<int>(base.ActiveHandleId);
				defaultInterpolatedStringHandler.AppendLiteral("）");
				string reason = defaultInterpolatedStringHandler.ToStringAndClear();
				Partial_RequirementPayload executeContext = this.ExecuteContext;
				buffComponent.AddIterativeBuff(buffId, preBuff, stackCount, isIterable, reason, (executeContext != null) ? executeContext.BulletMessageId : null, targetByType);
			}
		}
		return null;
	}

	// Token: 0x06018A94 RID: 101012 RVA: 0x006F5270 File Offset: 0x006F3470
	public override string GetDebugEffectString()
	{
		return base.GetDebugTriggerString() + "添加Buff " + string.Join<long>(", ", this.BuffIds);
	}

	// Token: 0x0400BF2D RID: 48941
	private long[] BuffIds = Array.Empty<long>();

	// Token: 0x0400BF2E RID: 48942
	private EPassiveEffectTargetType InstigatorType = EPassiveEffectTargetType.ForBuffInstigator;
}
