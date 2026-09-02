using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02002F6B RID: 12139
[NullableContext(1)]
[Nullable(0)]
public abstract class BuffExecution : BuffEffectBase
{
	// Token: 0x06018CDD RID: 101597 RVA: 0x00703797 File Offset: 0x00701997
	protected BuffExecution(RequireAndLimits requireAndLimits) : base(requireAndLimits)
	{
	}

	// Token: 0x06018CDE RID: 101598
	[return: Nullable(2)]
	public abstract object OnExecute(params object[] args);

	// Token: 0x06018CDF RID: 101599 RVA: 0x007037A0 File Offset: 0x007019A0
	public virtual void OnBuffRemovedCallback(ActiveBuffInternal buff)
	{
	}

	// Token: 0x06018CE0 RID: 101600 RVA: 0x007037A2 File Offset: 0x007019A2
	public virtual void OnBuffActiveChangedCallback(ActiveBuffInternal buff, bool isActive)
	{
	}

	// Token: 0x06018CE1 RID: 101601 RVA: 0x007037A4 File Offset: 0x007019A4
	public static T Create<[Nullable(0)] T>(long buffId, int index, RequireAndLimits requireAndLimits, ExtraEffectParameters parameters) where T : BuffExecution
	{
		T t = (T)((object)Activator.CreateInstance(typeof(T), new object[]
		{
			requireAndLimits
		}));
		t.BuffId = buffId;
		t.Index = index;
		if (parameters != null)
		{
			t.InitParameters(parameters);
		}
		return t;
	}

	// Token: 0x06018CE2 RID: 101602 RVA: 0x007037F8 File Offset: 0x007019F8
	protected override bool CheckExecutable()
	{
		IBuffComponent ownerBuffComponent = this.OwnerBuffComponent;
		return ownerBuffComponent != null && ownerBuffComponent.HasBuffAuthority();
	}

	// Token: 0x06018CE3 RID: 101603 RVA: 0x0070380B File Offset: 0x00701A0B
	[NullableContext(2)]
	protected bool Check(Partial_RequirementPayload context)
	{
		if (!this.CheckExecutable())
		{
			return false;
		}
		Entity entity = this.OwnerBuffComponent.GetEntity();
		this.OpponentEntityId = ((entity != null) ? entity.Id : 0);
		return base.CheckRequirements(context ?? new Partial_RequirementPayload());
	}

	// Token: 0x06018CE4 RID: 101604 RVA: 0x0070384C File Offset: 0x00701A4C
	public unsafe bool SetExecuteContext(ActiveBuffInternal buff)
	{
		this.Level = buff.Level;
		this.Buff = buff;
		IBuffComponent ownerBuffComponent = buff.GetOwnerBuffComponent();
		if (ownerBuffComponent == null)
		{
			CombatLog instance = Singleton<CombatLog>.Instance;
			CombatLog.EDebugModule flag = CombatLog.EDebugModule.Buff;
			Entity entity = null;
			string message = "设置执行效果上下文失败";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("handle", (buff != null) ? buff.Handle : 0);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("buffId", (buff != null) ? buff.Id : 0L);
			instance.Warn(flag, entity, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return false;
		}
		bool instigatorBuffComponent = buff.GetInstigatorBuffComponent() != null;
		this.OwnerBuffComponent = ownerBuffComponent;
		if (instigatorBuffComponent)
		{
			this.InstigatorEntityId = buff.GetInstigator().Id;
		}
		return true;
	}

	// Token: 0x06018CE5 RID: 101605 RVA: 0x0070390B File Offset: 0x00701B0B
	public void ClearExecuteContext()
	{
		this.OwnerBuffComponent = null;
		this.Buff = null;
	}

	// Token: 0x06018CE6 RID: 101606 RVA: 0x0070391C File Offset: 0x00701B1C
	public bool TryExecute(ActiveBuffInternal buff, params object[] parameters)
	{
		if (!base.CheckLoop())
		{
			return false;
		}
		if (!this.SetExecuteContext(buff))
		{
			return false;
		}
		if (!this.Check(new Partial_RequirementPayload()))
		{
			return false;
		}
		this.LoopLock = Singleton<Time>.Instance.Frame;
		this.OnExecute(parameters);
		this.PostExecuted();
		this.LoopLock = -1;
		this.ClearExecuteContext();
		return true;
	}

	// Token: 0x06018CE7 RID: 101607 RVA: 0x0070397C File Offset: 0x00701B7C
	[NullableContext(2)]
	protected IBuffComponent GetEffectTarget()
	{
		EExecutionTargetType targetType = this.TargetType;
		IBuffComponent result;
		if (targetType != EExecutionTargetType.Self)
		{
			if (targetType != EExecutionTargetType.Instigator)
			{
				result = null;
			}
			else
			{
				result = base.InstigatorBuffComponent;
			}
		}
		else
		{
			result = this.OwnerBuffComponent;
		}
		return result;
	}

	// Token: 0x06018CE8 RID: 101608 RVA: 0x007039AE File Offset: 0x00701BAE
	public virtual void OnBuffAddedCallback(ActiveBuffInternal buff, bool isIterable)
	{
	}

	// Token: 0x06018CE9 RID: 101609 RVA: 0x007039B0 File Offset: 0x00701BB0
	public virtual void OnPeriodCallback(ActiveBuffInternal buff)
	{
	}

	// Token: 0x06018CEA RID: 101610 RVA: 0x007039B2 File Offset: 0x00701BB2
	public override void OnBuffStackOverflow(ActiveBuffInternal buff, int oldStack, int newStack, int stackLimitMax)
	{
		if (!this.SetExecuteContext(buff))
		{
			return;
		}
		this.DoBuffStackOverflow(oldStack, newStack, stackLimitMax);
		this.ClearExecuteContext();
	}

	// Token: 0x06018CEB RID: 101611 RVA: 0x007039D0 File Offset: 0x00701BD0
	public void BuffEffectExecutePush()
	{
		Entity exactOwnerEntity = base.ExactOwnerEntity;
		if (exactOwnerEntity == null)
		{
			CombatLog instance = Singleton<CombatLog>.Instance;
			CombatLog.EDebugModule flag = CombatLog.EDebugModule.Buff;
			Entity entity = null;
			string message = "[Buff]EffectExecutePush失败";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("buffId", this.BuffId);
			instance.Warn(flag, entity, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		BuffEffectExecutePush buffEffectExecutePush = new BuffEffectExecutePush();
		buffEffectExecutePush.HandleId = this.Buff.Handle;
		buffEffectExecutePush.Index = this.Index;
		Singleton<CombatNet>.Instance.Send(EPushMessageId.BuffEffectExecutePush, exactOwnerEntity, buffEffectExecutePush, null, null, null);
	}

	// Token: 0x06018CEC RID: 101612 RVA: 0x00703A68 File Offset: 0x00701C68
	protected void PostExecuted()
	{
		if (this.Buff == null || this.Buff.Handle < 0 || this.OwnerBuffComponent == null)
		{
			return;
		}
		int extraEffectRemoveStackNum = this.RequireAndLimits.Limits.ExtraEffectRemoveStackNum;
		if (this.CheckAuthority() && extraEffectRemoveStackNum > 0)
		{
			this.OwnerBuffComponent.RemoveBuffByHandle(this.Buff.Handle, extraEffectRemoveStackNum, "buff额外效果触发后移除", null, null, null);
		}
	}

	// Token: 0x0400C16F RID: 49519
	[Nullable(2)]
	protected IActiveBuff Buff;

	// Token: 0x0400C170 RID: 49520
	protected int Index;

	// Token: 0x0400C171 RID: 49521
	protected EExecutionTargetType TargetType;
}
