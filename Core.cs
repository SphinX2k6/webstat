using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Common;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200007C RID: 124
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class Core : Singleton<Core>
{
	// Token: 0x06000300 RID: 768 RVA: 0x0001090C File Offset: 0x0000EB0C
	[NullableContext(0)]
	public UniTask<bool> Initialize([Nullable(1)] UGameInstance gameInstance)
	{
		Core.<Initialize>d__1 <Initialize>d__;
		<Initialize>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<Initialize>d__.<>4__this = this;
		<Initialize>d__.gameInstance = gameInstance;
		<Initialize>d__.<>1__state = -1;
		<Initialize>d__.<>t__builder.Start<Core.<Initialize>d__1>(ref <Initialize>d__);
		return <Initialize>d__.<>t__builder.Task;
	}

	// Token: 0x06000301 RID: 769 RVA: 0x00010957 File Offset: 0x0000EB57
	public void TickPriority2(float delta)
	{
		if (Singleton<Core>.Instance.ForbiddenTickPriority)
		{
			return;
		}
		Singleton<Core>.Instance.NextTickedPriority = 1;
		Singleton<Time>.Instance.Tick(delta);
	}

	// Token: 0x06000302 RID: 770 RVA: 0x0001097C File Offset: 0x0000EB7C
	public void TickPriority1(float delta)
	{
		if (Singleton<Core>.Instance.NextTickedPriority == 1)
		{
			Singleton<Core>.Instance.NextTickedPriority = 0;
			return;
		}
		Singleton<Core>.Instance.ForbiddenTickPriority = true;
	}

	// Token: 0x06000303 RID: 771 RVA: 0x000109A4 File Offset: 0x0000EBA4
	public void Tick(float delta)
	{
		if (Singleton<Core>.Instance.NextTickedPriority != 0)
		{
			Singleton<Time>.Instance.Tick(delta);
			Singleton<Core>.Instance.ForbiddenTickPriority = true;
		}
		Singleton<Core>.Instance.NextTickedPriority = -1;
		Singleton<CycleCounter>.Instance.RefreshState();
		float num = delta / 1000f;
		Singleton<Net>.Instance.Tick(num);
		if (!Singleton<TickSystem>.Instance.IsPaused)
		{
			foreach (Action<float> action in Singleton<Core>.Instance.PreTickFunctions)
			{
				action(delta);
			}
		}
		TimerSystem.Instance.Tick(delta);
		TimerSystem.FlowTimeInstance.Tick(delta * Singleton<Time>.Instance.TimeDilation * Singleton<Time>.Instance.FlowTimeDilation);
		TimerSystem.GameplayTimeInstance.Tick(delta * Singleton<Time>.Instance.InverseSelfCenteredTimeDilation);
		double serverTimeStamp = Singleton<Time>.Instance.ServerTimeStamp;
		double num2 = serverTimeStamp - Singleton<Time>.Instance.LastServerTime;
		Singleton<Time>.Instance.LastServerTime = serverTimeStamp;
		TimerSystem.RealTimeInstance.Tick((float)num2);
		if (!Singleton<TickSystem>.Instance.IsPaused)
		{
			Singleton<EffectEnvironment>.Instance.Tick(delta, Singleton<Info>.Instance.World);
			if (Singleton<Info>.Instance.EnableForceTick)
			{
				Singleton<EntitySystem>.Instance.ForceTick(delta);
			}
			GameBudgetInterfaceController.UpdateBudgetTime(delta);
		}
		UKuroGameBudgetAllocatorCSharpInterface.TickOutside(num);
		if (!Singleton<TickSystem>.Instance.IsPaused)
		{
			Singleton<EntitySystem>.Instance.Tick(delta);
		}
	}

	// Token: 0x06000304 RID: 772 RVA: 0x00010B1C File Offset: 0x0000ED1C
	public void AfterTick(float delta)
	{
		Singleton<Core>.Instance.NextTickedPriority = 2;
		Singleton<Core>.Instance.ForbiddenTickPriority = false;
		if (!Singleton<TickSystem>.Instance.IsPaused && Singleton<Info>.Instance.EnableForceTick)
		{
			Singleton<EntitySystem>.Instance.ForceAfterTick(delta);
		}
		UKuroGameBudgetAllocatorCSharpInterface.AfterTickOutside(delta / 1000f);
		if (!Singleton<TickSystem>.Instance.IsPaused)
		{
			Singleton<EntitySystem>.Instance.AfterTick(delta);
		}
	}

	// Token: 0x06000305 RID: 773 RVA: 0x00010B88 File Offset: 0x0000ED88
	public void RegisterPreTick(Action<float> func)
	{
		if (this.PreTickFunctions.Contains(func))
		{
			Singleton<Log>.Instance.Warn(ELogModule.Core, ELogAuthor.YZH, "[Core.RegisterPreTickFunctions] 已经注册过PreTickfunc", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		this.PreTickFunctions.Add(func);
	}

	// Token: 0x06000306 RID: 774 RVA: 0x00010BCC File Offset: 0x0000EDCC
	public void UnRegisterPreTick(Action<float> func)
	{
		if (!this.PreTickFunctions.Contains(func))
		{
			Singleton<Log>.Instance.Warn(ELogModule.Core, ELogAuthor.YZH, "[Core.UnRegisterPreTick] 未注册的PreTickfunc", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		this.PreTickFunctions.Remove(func);
	}

	// Token: 0x06000307 RID: 775 RVA: 0x00010C10 File Offset: 0x0000EE10
	private UniTask WaitFrame()
	{
		UniTaskCompletionSource tcs = new UniTaskCompletionSource();
		TimerSystem.Instance.Next(delegate(float _)
		{
			tcs.TrySetResult();
		}, null, null);
		return tcs.Task;
	}

	// Token: 0x04000228 RID: 552
	private readonly HashSet<Action<float>> PreTickFunctions = new HashSet<Action<float>>();

	// Token: 0x04000229 RID: 553
	private int NextTickedPriority = 2;

	// Token: 0x0400022A RID: 554
	public bool ForbiddenTickPriority;
}
