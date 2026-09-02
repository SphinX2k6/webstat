using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02002E40 RID: 11840
[NullableContext(1)]
[Nullable(0)]
public class AbilityEventInstance
{
	// Token: 0x06018454 RID: 99412 RVA: 0x006C83BC File Offset: 0x006C65BC
	public void Add(object target, EAbilityEventName eventType, long key, Delegate callback)
	{
		TargetEmitter targetEmitter;
		if (!this.EmitterHolders.TryGetValue(eventType, out targetEmitter))
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(5, 1);
			defaultInterpolatedStringHandler.AppendLiteral("Event");
			defaultInterpolatedStringHandler.AppendFormatted<int>((int)eventType);
			targetEmitter = new TargetEmitter(defaultInterpolatedStringHandler.ToStringAndClear());
			this.EmitterHolders[eventType] = targetEmitter;
		}
		targetEmitter.Add(target, key, callback);
	}

	// Token: 0x06018455 RID: 99413 RVA: 0x006C841C File Offset: 0x006C661C
	public void Emit(object target, EAbilityEventName eventType, long key)
	{
		TargetEmitter targetEmitter;
		if (this.EmitterHolders.TryGetValue(eventType, out targetEmitter))
		{
			targetEmitter.Emit(target, key);
		}
	}

	// Token: 0x06018456 RID: 99414 RVA: 0x006C8444 File Offset: 0x006C6644
	public void Emit<[Nullable(2)] T1>(object target, EAbilityEventName eventType, long key, T1 arg1)
	{
		TargetEmitter targetEmitter;
		if (this.EmitterHolders.TryGetValue(eventType, out targetEmitter))
		{
			targetEmitter.Emit<T1>(target, key, arg1);
		}
	}

	// Token: 0x06018457 RID: 99415 RVA: 0x006C846C File Offset: 0x006C666C
	public void Emit<[Nullable(2)] T1, [Nullable(2)] T2>(object target, EAbilityEventName eventType, long key, T1 arg1, T2 arg2)
	{
		TargetEmitter targetEmitter;
		if (this.EmitterHolders.TryGetValue(eventType, out targetEmitter))
		{
			targetEmitter.Emit<T1, T2>(target, key, arg1, arg2);
		}
	}

	// Token: 0x06018458 RID: 99416 RVA: 0x006C8498 File Offset: 0x006C6698
	public void Emit<[Nullable(2)] T1, [Nullable(2)] T2, [Nullable(2)] T3>(object target, EAbilityEventName eventType, long key, T1 arg1, T2 arg2, T3 arg3)
	{
		TargetEmitter targetEmitter;
		if (this.EmitterHolders.TryGetValue(eventType, out targetEmitter))
		{
			targetEmitter.Emit<T1, T2, T3>(target, key, arg1, arg2, arg3);
		}
	}

	// Token: 0x06018459 RID: 99417 RVA: 0x006C84C4 File Offset: 0x006C66C4
	public void Emit<[Nullable(2)] T1, [Nullable(2)] T2, [Nullable(2)] T3, [Nullable(2)] T4>(object target, EAbilityEventName eventType, long key, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
	{
		TargetEmitter targetEmitter;
		if (this.EmitterHolders.TryGetValue(eventType, out targetEmitter))
		{
			targetEmitter.Emit<T1, T2, T3, T4>(target, key, arg1, arg2, arg3, arg4);
		}
	}

	// Token: 0x0601845A RID: 99418 RVA: 0x006C84F4 File Offset: 0x006C66F4
	public void Emit<[Nullable(2)] T1, [Nullable(2)] T2, [Nullable(2)] T3, [Nullable(2)] T4, [Nullable(2)] T5>(object target, EAbilityEventName eventType, long key, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
	{
		TargetEmitter targetEmitter;
		if (this.EmitterHolders.TryGetValue(eventType, out targetEmitter))
		{
			targetEmitter.Emit<T1, T2, T3, T4, T5>(target, key, arg1, arg2, arg3, arg4, arg5);
		}
	}

	// Token: 0x0601845B RID: 99419 RVA: 0x006C8524 File Offset: 0x006C6724
	public void Remove(object target, EAbilityEventName eventType, long key, Delegate callback)
	{
		TargetEmitter targetEmitter;
		if (this.EmitterHolders.TryGetValue(eventType, out targetEmitter))
		{
			targetEmitter.Remove(target, key, callback);
		}
	}

	// Token: 0x0400BA9D RID: 47773
	private readonly Dictionary<EAbilityEventName, TargetEmitter> EmitterHolders = new Dictionary<EAbilityEventName, TargetEmitter>();
}
