using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02000BE6 RID: 3046
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class TickProcessSystem : Singleton<TickProcessSystem>
{
	// Token: 0x0600322E RID: 12846 RVA: 0x000217AE File Offset: 0x0001F9AE
	static TickProcessSystem()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(Singleton<TickProcessSystem>.CreateStaticDefaultValue), new Action(Singleton<TickProcessSystem>.ResetStaticDefaultValue));
	}

	// Token: 0x0600322F RID: 12847 RVA: 0x000217D0 File Offset: 0x0001F9D0
	private void AddToTickSystem(ETickingGroup group, bool tickEvenPaused)
	{
		if (this.TickerMap.ContainsKey(group))
		{
			return;
		}
		Ticker ticker = null;
		switch (group)
		{
		case ETickingGroup.TG_PrePhysics:
			ticker = Singleton<TickSystem>.Instance.Add(new Action<float>(this.TickPrePhysics), "TickProcess_PrePhysics", group, tickEvenPaused, 0, false);
			break;
		case ETickingGroup.TG_StartPhysics:
			ticker = Singleton<TickSystem>.Instance.Add(new Action<float>(this.TickStartPhysics), "TickProcess_StartPhysics", group, tickEvenPaused, 0, false);
			break;
		case ETickingGroup.TG_DuringPhysics:
			ticker = Singleton<TickSystem>.Instance.Add(new Action<float>(this.TickDuringPhysics), "TickProcess_DuringPhysics", group, tickEvenPaused, 0, false);
			break;
		case ETickingGroup.TG_EndPhysics:
			ticker = Singleton<TickSystem>.Instance.Add(new Action<float>(this.TickEndPhysics), "TickProcess_EndPhysics", group, tickEvenPaused, 0, false);
			break;
		case ETickingGroup.TG_PostPhysics:
			ticker = Singleton<TickSystem>.Instance.Add(new Action<float>(this.TickPostPhysics), "TickProcess_PostPhysics", group, tickEvenPaused, 0, false);
			break;
		case ETickingGroup.TG_PostUpdateWork:
			ticker = Singleton<TickSystem>.Instance.Add(new Action<float>(this.TickPostUpdateWork), "TickProcess_PostUpdateWork", group, tickEvenPaused, 0, false);
			break;
		case ETickingGroup.TG_LastDemotable:
			ticker = Singleton<TickSystem>.Instance.Add(new Action<float>(this.TickLastDemotable), "TickProcess_LastDemotable", group, tickEvenPaused, 0, false);
			break;
		case ETickingGroup.TG_NewlySpawned:
			ticker = Singleton<TickSystem>.Instance.Add(new Action<float>(this.TickNewlySpawned), "TickProcess_NewlySpawned", group, tickEvenPaused, 0, false);
			break;
		}
		if (ticker != null)
		{
			this.TickerMap[group] = ticker;
		}
	}

	// Token: 0x06003230 RID: 12848 RVA: 0x00021944 File Offset: 0x0001FB44
	private void RemoveFromTickSystem(ETickingGroup group)
	{
		Ticker ticker;
		if (!this.TickerMap.TryGetValue(group, out ticker) || ticker == null)
		{
			return;
		}
		this.TickerMap.Remove(group);
		Singleton<TickSystem>.Instance.Remove(ticker.Id);
	}

	// Token: 0x06003231 RID: 12849 RVA: 0x00021983 File Offset: 0x0001FB83
	private void TickPrePhysics(float deltaTime)
	{
		this.Tick(deltaTime, ETickingGroup.TG_PrePhysics);
	}

	// Token: 0x06003232 RID: 12850 RVA: 0x0002198D File Offset: 0x0001FB8D
	private void TickStartPhysics(float deltaTime)
	{
		this.Tick(deltaTime, ETickingGroup.TG_StartPhysics);
	}

	// Token: 0x06003233 RID: 12851 RVA: 0x00021997 File Offset: 0x0001FB97
	private void TickDuringPhysics(float deltaTime)
	{
		this.Tick(deltaTime, ETickingGroup.TG_DuringPhysics);
	}

	// Token: 0x06003234 RID: 12852 RVA: 0x000219A1 File Offset: 0x0001FBA1
	private void TickEndPhysics(float deltaTime)
	{
		this.Tick(deltaTime, ETickingGroup.TG_EndPhysics);
	}

	// Token: 0x06003235 RID: 12853 RVA: 0x000219AB File Offset: 0x0001FBAB
	private void TickPostPhysics(float deltaTime)
	{
		this.Tick(deltaTime, ETickingGroup.TG_PostPhysics);
	}

	// Token: 0x06003236 RID: 12854 RVA: 0x000219B5 File Offset: 0x0001FBB5
	private void TickPostUpdateWork(float deltaTime)
	{
		this.Tick(deltaTime, ETickingGroup.TG_PostUpdateWork);
	}

	// Token: 0x06003237 RID: 12855 RVA: 0x000219BF File Offset: 0x0001FBBF
	private void TickLastDemotable(float deltaTime)
	{
		this.Tick(deltaTime, ETickingGroup.TG_LastDemotable);
	}

	// Token: 0x06003238 RID: 12856 RVA: 0x000219C9 File Offset: 0x0001FBC9
	private void TickNewlySpawned(float deltaTime)
	{
		this.Tick(deltaTime, ETickingGroup.TG_NewlySpawned);
	}

	// Token: 0x06003239 RID: 12857 RVA: 0x000219D4 File Offset: 0x0001FBD4
	private void Tick(float deltaTime, ETickingGroup group)
	{
		if (!this.TickProcessGroupMap.ContainsKey(group))
		{
			return;
		}
		HashSet<TickProcess> hashSet = this.TickProcessGroupMap[group];
		if (hashSet.Count < 1)
		{
			return;
		}
		foreach (TickProcess tickProcess in hashSet)
		{
			if (tickProcess.Tick(deltaTime))
			{
				this.RemoveProcessSet.Add(tickProcess.Id);
			}
		}
		if (this.RemoveProcessSet.Count > 0)
		{
			foreach (int processId in this.RemoveProcessSet)
			{
				this.UnregisterTickProcess(processId);
			}
			this.RemoveProcessSet.Clear();
		}
	}

	// Token: 0x0600323A RID: 12858 RVA: 0x00021ABC File Offset: 0x0001FCBC
	public void Initialize()
	{
		this.TickerMap.Clear();
		this.RemoveProcessSet.Clear();
		this.TickProcessGroupMap.Clear();
		this.TickProcessMap.Clear();
	}

	// Token: 0x0600323B RID: 12859 RVA: 0x00021AEC File Offset: 0x0001FCEC
	public int RegisterTickProcess(ETickingGroup group, bool tickEvenPaused, Action<float> callback, string reason)
	{
		if (!this.TickProcessGroupMap.ContainsKey(group))
		{
			this.TickProcessGroupMap[group] = new HashSet<TickProcess>();
			this.AddToTickSystem(group, tickEvenPaused);
		}
		TickProcess tickProcess = new TickProcess();
		tickProcess.Init(callback, group, ETickProcessLifeType.Forever, 0f, reason);
		HashSet<TickProcess> hashSet;
		if (this.TickProcessGroupMap.TryGetValue(group, out hashSet))
		{
			hashSet.Add(tickProcess);
		}
		this.TickProcessMap[tickProcess.Id] = tickProcess;
		return tickProcess.Id;
	}

	// Token: 0x0600323C RID: 12860 RVA: 0x00021B68 File Offset: 0x0001FD68
	public int RegisterOnceTickProcess(ETickingGroup group, bool tickEvenPaused, Action<float> callback)
	{
		if (!this.TickProcessGroupMap.ContainsKey(group))
		{
			this.TickProcessGroupMap[group] = new HashSet<TickProcess>();
			this.AddToTickSystem(group, tickEvenPaused);
		}
		TickProcess tickProcess = new TickProcess();
		tickProcess.Init(callback, group, ETickProcessLifeType.Once, 0f, null);
		HashSet<TickProcess> hashSet;
		if (this.TickProcessGroupMap.TryGetValue(group, out hashSet))
		{
			hashSet.Add(tickProcess);
		}
		this.TickProcessMap[tickProcess.Id] = tickProcess;
		return tickProcess.Id;
	}

	// Token: 0x0600323D RID: 12861 RVA: 0x00021BE4 File Offset: 0x0001FDE4
	public int RegisterDelayTickProcess(ETickingGroup group, bool tickEvenPaused, Action<float> callback, float lifeTime)
	{
		if (!this.TickProcessGroupMap.ContainsKey(group))
		{
			this.TickProcessGroupMap[group] = new HashSet<TickProcess>();
			this.AddToTickSystem(group, tickEvenPaused);
		}
		TickProcess tickProcess = new TickProcess();
		tickProcess.Init(callback, group, ETickProcessLifeType.Delay, lifeTime, null);
		HashSet<TickProcess> hashSet;
		if (this.TickProcessGroupMap.TryGetValue(group, out hashSet))
		{
			hashSet.Add(tickProcess);
		}
		this.TickProcessMap[tickProcess.Id] = tickProcess;
		return tickProcess.Id;
	}

	// Token: 0x0600323E RID: 12862 RVA: 0x00021C5C File Offset: 0x0001FE5C
	public void UnregisterTickProcess(int processId)
	{
		TickProcess tickProcess;
		if (!this.TickProcessMap.TryGetValue(processId, out tickProcess) || tickProcess == null)
		{
			return;
		}
		this.TickProcessMap.Remove(processId);
		ETickingGroup group = tickProcess.Group;
		HashSet<TickProcess> hashSet;
		if (!this.TickProcessGroupMap.TryGetValue(group, out hashSet))
		{
			return;
		}
		hashSet.Remove(tickProcess);
	}

	// Token: 0x0600323F RID: 12863 RVA: 0x00021CAC File Offset: 0x0001FEAC
	public void Clear()
	{
		foreach (ETickingGroup group in this.TickProcessGroupMap.Keys)
		{
			this.RemoveFromTickSystem(group);
		}
		this.TickProcessMap.Clear();
		this.TickProcessGroupMap.Clear();
		this.RemoveProcessSet.Clear();
	}

	// Token: 0x04000514 RID: 1300
	private readonly Dictionary<ETickingGroup, Ticker> TickerMap = new Dictionary<ETickingGroup, Ticker>();

	// Token: 0x04000515 RID: 1301
	private readonly HashSet<int> RemoveProcessSet = new HashSet<int>();

	// Token: 0x04000516 RID: 1302
	private readonly Dictionary<ETickingGroup, HashSet<TickProcess>> TickProcessGroupMap = new Dictionary<ETickingGroup, HashSet<TickProcess>>();

	// Token: 0x04000517 RID: 1303
	private readonly Dictionary<int, TickProcess> TickProcessMap = new Dictionary<int, TickProcess>();
}
