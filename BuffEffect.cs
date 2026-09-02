using System;
using System.Runtime.CompilerServices;

// Token: 0x02002EEF RID: 12015
[NullableContext(1)]
[Nullable(0)]
public abstract class BuffEffect : BuffEffectBase
{
	// Token: 0x17002169 RID: 8553
	// (get) Token: 0x06018AD2 RID: 101074 RVA: 0x006F7F5E File Offset: 0x006F615E
	public double RemainCd
	{
		get
		{
			IBuffComponent ownerBuffComponent = this.OwnerBuffComponent;
			if (ownerBuffComponent == null)
			{
				return 0.0;
			}
			return ownerBuffComponent.GetBuffEffectCd(this.BuffId, this.Index);
		}
	}

	// Token: 0x1700216A RID: 8554
	// (get) Token: 0x06018AD3 RID: 101075 RVA: 0x006F7F88 File Offset: 0x006F6188
	public double RemainCdForTarget
	{
		get
		{
			if (this.RequireAndLimits.Limits.ExtraEffectCdForTarget <= 0f)
			{
				return 0.0;
			}
			IBuffComponent ownerBuffComponent = this.OwnerBuffComponent;
			if (ownerBuffComponent == null)
			{
				return 0.0;
			}
			return ownerBuffComponent.GetBuffEffectCdForTarget(this.BuffId, this.Index, this.OpponentEntityId);
		}
	}

	// Token: 0x1700216B RID: 8555
	// (get) Token: 0x06018AD4 RID: 101076 RVA: 0x006F7FE1 File Offset: 0x006F61E1
	[Nullable(2)]
	protected IActiveBuff Buff
	{
		[NullableContext(2)]
		get
		{
			IBuffComponent ownerBuffComponent = this.OwnerBuffComponent;
			if (ownerBuffComponent == null)
			{
				return null;
			}
			return ownerBuffComponent.GetBuffByHandle(this.ActiveHandleId);
		}
	}

	// Token: 0x1700216C RID: 8556
	// (get) Token: 0x06018AD5 RID: 101077 RVA: 0x006F7FFA File Offset: 0x006F61FA
	[Nullable(2)]
	protected IActiveBuff PendingBuff
	{
		[NullableContext(2)]
		get
		{
			IBuffComponent ownerBuffComponent = this.OwnerBuffComponent;
			if (ownerBuffComponent == null)
			{
				return null;
			}
			return ownerBuffComponent.GetPendingBuffByHandle(this.ActiveHandleId);
		}
	}

	// Token: 0x06018AD6 RID: 101078 RVA: 0x006F8014 File Offset: 0x006F6214
	protected BuffEffect(int activeHandleId, int index, RequireAndLimits requireAndLimits, BaseBuffComponent ownerBuffComponent, [Nullable(2)] CharacterBuffComponent instigatorBuffComponent) : base(requireAndLimits)
	{
		this.ActiveHandleId = activeHandleId;
		this.Index = index;
		this.OwnerBuffComponent = ownerBuffComponent;
		IActiveBuff buffByHandle = ownerBuffComponent.GetBuffByHandle(activeHandleId);
		if (buffByHandle != null)
		{
			this.Level = buffByHandle.Level;
			this.ServerId = buffByHandle.ServerId;
			this.BuffId = buffByHandle.Id;
			if (instigatorBuffComponent != null)
			{
				this.InstigatorEntityId = instigatorBuffComponent.Entity.Id;
			}
		}
	}

	// Token: 0x06018AD7 RID: 101079 RVA: 0x006F8084 File Offset: 0x006F6284
	public static BuffEffect Create(Type typeOfBuffEffect, int handleId, int index, RequireAndLimits requireAndLimits, BaseBuffComponent ownerBuffComponent, [Nullable(2)] CharacterBuffComponent instigatorBuffComponent, [Nullable(2)] ExtraEffectParameters parameters = null)
	{
		BuffEffect buffEffect = (BuffEffect)Activator.CreateInstance(typeOfBuffEffect, new object[]
		{
			handleId,
			index,
			requireAndLimits,
			ownerBuffComponent,
			instigatorBuffComponent
		});
		if (parameters != null)
		{
			buffEffect.InitParameters(parameters);
		}
		return buffEffect;
	}

	// Token: 0x06018AD8 RID: 101080 RVA: 0x006F80D0 File Offset: 0x006F62D0
	public virtual void OnCreated()
	{
	}

	// Token: 0x06018AD9 RID: 101081 RVA: 0x006F80D2 File Offset: 0x006F62D2
	public virtual void OnRemoved(bool bPremature)
	{
	}

	// Token: 0x06018ADA RID: 101082 RVA: 0x006F80D4 File Offset: 0x006F62D4
	public virtual void OnStackDecreased(int newCount, int oldCount, bool bPremature)
	{
	}

	// Token: 0x06018ADB RID: 101083 RVA: 0x006F80D6 File Offset: 0x006F62D6
	public virtual void OnStackIncreased(int newCount, int oldCount, long? instigatorId)
	{
	}

	// Token: 0x06018ADC RID: 101084 RVA: 0x006F80D8 File Offset: 0x006F62D8
	public virtual void OnPeriodCallback()
	{
	}

	// Token: 0x06018ADD RID: 101085 RVA: 0x006F80DA File Offset: 0x006F62DA
	public override void OnBuffStackOverflow(ActiveBuffInternal buff, int oldStack, int newStack, int stackLimitMax)
	{
	}

	// Token: 0x06018ADE RID: 101086 RVA: 0x006F80DC File Offset: 0x006F62DC
	public bool TryExecute(Partial_RequirementPayload context, IBuffComponent opponent, params object[] parameters)
	{
		if (!this.Check(context, opponent))
		{
			return false;
		}
		this.ExecuteContext = context;
		this.Execute(parameters);
		this.ExecuteContext = null;
		return true;
	}

	// Token: 0x06018ADF RID: 101087 RVA: 0x006F8104 File Offset: 0x006F6304
	public bool Check(Partial_RequirementPayload context, IBuffComponent opponent)
	{
		if (!this.CheckExecutable())
		{
			return false;
		}
		Entity entity = opponent.GetEntity();
		this.OpponentEntityId = ((entity != null) ? entity.Id : 0);
		return base.CheckLoop() && base.CheckRequirements(context) && (this.ActiveHandleId < 0 || (this.RemainCd <= 0.0 && this.RemainCdForTarget <= 0.0 && RandomSystem.GetRandomPercent() <= this.RequireAndLimits.Limits.ExtraEffectProbability));
	}

	// Token: 0x06018AE0 RID: 101088 RVA: 0x006F8193 File Offset: 0x006F6393
	[return: Nullable(2)]
	public object Execute(params object[] parameters)
	{
		this.LoopLock = Singleton<Time>.Instance.Frame;
		object result = this.OnExecute(parameters);
		this.PostExecuted();
		this.LoopLock = -1;
		return result;
	}

	// Token: 0x06018AE1 RID: 101089
	[return: Nullable(2)]
	public abstract object OnExecute(params object[] parameters);

	// Token: 0x06018AE2 RID: 101090 RVA: 0x006F81BC File Offset: 0x006F63BC
	protected virtual void PostExecuted()
	{
		if (this.ActiveHandleId < 0 || this.OwnerBuffComponent == null)
		{
			return;
		}
		if (this.CheckAuthority())
		{
			float remainCd = this.RequireAndLimits.Limits.ExtraEffectCd * 1000f;
			this.OwnerBuffComponent.SetBuffEffectCd(this.BuffId, this.Index, remainCd);
			float num = this.RequireAndLimits.Limits.ExtraEffectCdForTarget * 1000f;
			if (num > 0f)
			{
				this.OwnerBuffComponent.SetBuffEffectCdForTarget(this.BuffId, this.Index, this.OpponentEntityId, num);
			}
		}
		int extraEffectRemoveStackNum = this.RequireAndLimits.Limits.ExtraEffectRemoveStackNum;
		if (this.CheckAuthority() && extraEffectRemoveStackNum > 0)
		{
			this.OwnerBuffComponent.RemoveBuffByHandle(this.ActiveHandleId, extraEffectRemoveStackNum, "buff额外效果触发后移除", null, null, null);
		}
	}

	// Token: 0x0400BF56 RID: 48982
	protected int Timeout;

	// Token: 0x0400BF57 RID: 48983
	[Nullable(2)]
	protected Partial_RequirementPayload ExecuteContext;

	// Token: 0x0400BF58 RID: 48984
	public readonly int ActiveHandleId;

	// Token: 0x0400BF59 RID: 48985
	public readonly int Index;
}
