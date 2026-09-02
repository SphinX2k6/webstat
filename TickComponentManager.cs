using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x0200008B RID: 139
[NullableContext(1)]
[Nullable(0)]
public class TickComponentManager
{
	// Token: 0x06000320 RID: 800 RVA: 0x00012D5F File Offset: 0x00010F5F
	public int GetCurrentTickIntervalCount()
	{
		return this.TickIntervalCount;
	}

	// Token: 0x1700006B RID: 107
	// (get) Token: 0x06000321 RID: 801 RVA: 0x00012D67 File Offset: 0x00010F67
	public bool NeedTick
	{
		get
		{
			return this.NeedTickInternal;
		}
	}

	// Token: 0x1700006C RID: 108
	// (get) Token: 0x06000322 RID: 802 RVA: 0x00012D6F File Offset: 0x00010F6F
	public bool NeedAfterTick
	{
		get
		{
			return this.NeedAfterTickInternal;
		}
	}

	// Token: 0x06000323 RID: 803 RVA: 0x00012D77 File Offset: 0x00010F77
	private static int Compare(TickComponentInfo a, TickComponentInfo b)
	{
		if (a.Priority == b.Priority)
		{
			return a.Index - b.Index;
		}
		return b.Priority - a.Priority;
	}

	// Token: 0x06000324 RID: 804 RVA: 0x00012DA2 File Offset: 0x00010FA2
	public void Clear()
	{
		this.DeltaTotal = 0f;
		this.TickIntervalCount = 0;
		this.DeltaTotalAfter = 0f;
		this.TickIntervalCountAfter = 0;
	}

	// Token: 0x06000325 RID: 805 RVA: 0x00012DC8 File Offset: 0x00010FC8
	public void ClearDelta()
	{
		this.DeltaTotal = 0f;
	}

	// Token: 0x06000326 RID: 806 RVA: 0x00012DD8 File Offset: 0x00010FD8
	public void Add(EntityComponent entityComponent, int? priority)
	{
		if (!entityComponent.NeedTick && !entityComponent.NeedForceTick && !entityComponent.NeedAfterTick && !entityComponent.NeedForceAfterTick)
		{
			return;
		}
		TickComponentInfo item = new TickComponentInfo(entityComponent, this.ComponentCount, priority.GetValueOrDefault());
		if (entityComponent.NeedTick || entityComponent.NeedForceTick)
		{
			this.TickComponents.Add(item);
		}
		if (entityComponent.NeedForceTick)
		{
			this.ForceTickComponents.Add(item);
		}
		if (entityComponent.NeedAfterTick || entityComponent.NeedForceAfterTick)
		{
			this.AfterTickComponents.Add(item);
		}
		if (entityComponent.NeedForceAfterTick)
		{
			this.ForceAfterTickComponents.Add(item);
		}
		this.ComponentCount++;
	}

	// Token: 0x06000327 RID: 807 RVA: 0x00012E88 File Offset: 0x00011088
	public void Sort()
	{
		this.NeedTickInternal = (this.TickComponents.Count > 0 || this.ForceTickComponents.Count > 0);
		this.NeedAfterTickInternal = (this.AfterTickComponents.Count > 0 || this.ForceAfterTickComponents.Count > 0);
		List<TickComponentInfo> tickComponents = this.TickComponents;
		Comparison<TickComponentInfo> comparison;
		if ((comparison = TickComponentManager.<>O.<0>__Compare) == null)
		{
			comparison = (TickComponentManager.<>O.<0>__Compare = new Comparison<TickComponentInfo>(TickComponentManager.Compare));
		}
		tickComponents.Sort(comparison);
		List<TickComponentInfo> forceTickComponents = this.ForceTickComponents;
		Comparison<TickComponentInfo> comparison2;
		if ((comparison2 = TickComponentManager.<>O.<0>__Compare) == null)
		{
			comparison2 = (TickComponentManager.<>O.<0>__Compare = new Comparison<TickComponentInfo>(TickComponentManager.Compare));
		}
		forceTickComponents.Sort(comparison2);
		List<TickComponentInfo> afterTickComponents = this.AfterTickComponents;
		Comparison<TickComponentInfo> comparison3;
		if ((comparison3 = TickComponentManager.<>O.<0>__Compare) == null)
		{
			comparison3 = (TickComponentManager.<>O.<0>__Compare = new Comparison<TickComponentInfo>(TickComponentManager.Compare));
		}
		afterTickComponents.Sort(comparison3);
		List<TickComponentInfo> forceAfterTickComponents = this.ForceAfterTickComponents;
		Comparison<TickComponentInfo> comparison4;
		if ((comparison4 = TickComponentManager.<>O.<0>__Compare) == null)
		{
			comparison4 = (TickComponentManager.<>O.<0>__Compare = new Comparison<TickComponentInfo>(TickComponentManager.Compare));
		}
		forceAfterTickComponents.Sort(comparison4);
	}

	// Token: 0x06000328 RID: 808 RVA: 0x00012F78 File Offset: 0x00011178
	public void ForceTick(float delta)
	{
		foreach (TickComponentInfo tickComponentInfo in this.ForceTickComponents)
		{
			tickComponentInfo.Component.ForceTick(delta);
		}
	}

	// Token: 0x06000329 RID: 809 RVA: 0x00012FD0 File Offset: 0x000111D0
	public void Tick(int intervalTime, float delta)
	{
		this.DeltaTotal += delta;
		this.TickIntervalCount++;
		if (!GameBudgetInterfaceController.IsOpen && this.TickIntervalCount < intervalTime)
		{
			return;
		}
		foreach (TickComponentInfo tickComponentInfo in this.TickComponents)
		{
			if (tickComponentInfo.Component.NeedTick)
			{
				tickComponentInfo.Component.Tick(this.DeltaTotal);
			}
		}
		this.DeltaTotal = 0f;
		this.TickIntervalCount = 0;
	}

	// Token: 0x0600032A RID: 810 RVA: 0x0001307C File Offset: 0x0001127C
	public void ForceAfterTick(float delta)
	{
		foreach (TickComponentInfo tickComponentInfo in this.ForceAfterTickComponents)
		{
			tickComponentInfo.Component.ForceAfterTick(delta);
		}
	}

	// Token: 0x0600032B RID: 811 RVA: 0x000130D4 File Offset: 0x000112D4
	public void AfterTick(int intervalTime, float delta)
	{
		this.DeltaTotalAfter += delta;
		this.TickIntervalCountAfter++;
		if (!GameBudgetInterfaceController.IsOpen && this.TickIntervalCountAfter < intervalTime)
		{
			return;
		}
		foreach (TickComponentInfo tickComponentInfo in this.AfterTickComponents)
		{
			if (tickComponentInfo.Component.NeedAfterTick)
			{
				tickComponentInfo.Component.AfterTick(this.DeltaTotalAfter);
			}
		}
		this.DeltaTotalAfter = 0f;
		this.TickIntervalCountAfter = 0;
	}

	// Token: 0x04000348 RID: 840
	private float DeltaTotal;

	// Token: 0x04000349 RID: 841
	private int TickIntervalCount;

	// Token: 0x0400034A RID: 842
	private float DeltaTotalAfter;

	// Token: 0x0400034B RID: 843
	private int TickIntervalCountAfter;

	// Token: 0x0400034C RID: 844
	private bool NeedTickInternal;

	// Token: 0x0400034D RID: 845
	private bool NeedAfterTickInternal;

	// Token: 0x0400034E RID: 846
	private readonly List<TickComponentInfo> TickComponents = new List<TickComponentInfo>();

	// Token: 0x0400034F RID: 847
	private readonly List<TickComponentInfo> ForceTickComponents = new List<TickComponentInfo>();

	// Token: 0x04000350 RID: 848
	private readonly List<TickComponentInfo> AfterTickComponents = new List<TickComponentInfo>();

	// Token: 0x04000351 RID: 849
	private readonly List<TickComponentInfo> ForceAfterTickComponents = new List<TickComponentInfo>();

	// Token: 0x04000352 RID: 850
	private int ComponentCount;

	// Token: 0x0200718E RID: 29070
	[CompilerGenerated]
	private static class <>O
	{
		// Token: 0x040278DE RID: 162014
		[Nullable(new byte[]
		{
			0,
			1
		})]
		public static Comparison<TickComponentInfo> <0>__Compare;
	}
}
