using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x0200009D RID: 157
[NullableContext(1)]
[Nullable(0)]
public class TickEntityManager
{
	// Token: 0x060003F5 RID: 1013 RVA: 0x00017970 File Offset: 0x00015B70
	public void Add(Entity entity, int priority)
	{
		this.EntityPriority[entity.Id] = priority;
		if (this.Ticking)
		{
			this.CreateEntities.Add(entity);
			return;
		}
		this.AddInternal(entity, priority);
	}

	// Token: 0x060003F6 RID: 1014 RVA: 0x000179A4 File Offset: 0x00015BA4
	private void AddInternal(Entity entity, int priority)
	{
		TickEntityGroup tickEntityGroup;
		if (!this.TickEntityMap.TryGetValue(priority, out tickEntityGroup))
		{
			tickEntityGroup = new TickEntityGroup(priority);
			this.TickEntityMap[priority] = tickEntityGroup;
			this.TickEntityQueue.Insert(this.SearchQueue(priority), tickEntityGroup);
		}
		tickEntityGroup.Entities[entity.Id] = entity;
	}

	// Token: 0x060003F7 RID: 1015 RVA: 0x000179FC File Offset: 0x00015BFC
	private int SearchQueue(int priority)
	{
		int count = this.TickEntityQueue.Count;
		if (count < 4)
		{
			for (int i = 0; i < count; i++)
			{
				if (this.TickEntityQueue[i].Priority < priority)
				{
					return i;
				}
			}
			return count;
		}
		if (this.TickEntityQueue[0].Priority < priority)
		{
			return 0;
		}
		int num = 0;
		int num2 = count;
		while (num2 - num > 1)
		{
			int num3 = num + num2 >> 1;
			if (this.TickEntityQueue[num3].Priority > priority)
			{
				num = num3;
			}
			else
			{
				num2 = num3;
			}
		}
		return num2;
	}

	// Token: 0x060003F8 RID: 1016 RVA: 0x00017A84 File Offset: 0x00015C84
	public void Delete(int entityId)
	{
		int priority;
		if (!this.EntityPriority.TryGetValue(entityId, out priority))
		{
			return;
		}
		if (this.Ticking)
		{
			this.DestroyEntities.Add(entityId);
			return;
		}
		this.DeleteInternal(entityId, priority);
	}

	// Token: 0x060003F9 RID: 1017 RVA: 0x00017ABF File Offset: 0x00015CBF
	private void DeleteInternal(int entityId, int priority)
	{
		this.EntityPriority.Remove(entityId);
		this.TickEntityMap[priority].Entities.Remove(entityId);
	}

	// Token: 0x060003FA RID: 1018 RVA: 0x00017AE8 File Offset: 0x00015CE8
	public void ForceTick(float delta)
	{
		this.Ticking = true;
		foreach (TickEntityGroup tickEntityGroup in this.TickEntityQueue)
		{
			foreach (Entity entity in tickEntityGroup.Entities.Values)
			{
				if (entity.Valid && entity.IsInit)
				{
					entity.ForceTick(delta);
				}
			}
		}
		this.Ticking = false;
		this.CreateAndDestroyInternal();
	}

	// Token: 0x060003FB RID: 1019 RVA: 0x00017BA0 File Offset: 0x00015DA0
	public void Tick(float delta)
	{
		if (GameBudgetInterfaceController.IsOpen)
		{
			return;
		}
		this.Ticking = true;
		foreach (TickEntityGroup tickEntityGroup in this.TickEntityQueue)
		{
			foreach (Entity entity in tickEntityGroup.Entities.Values)
			{
				if (entity.Valid && entity.IsInit)
				{
					entity.Tick(delta);
				}
			}
		}
		this.Ticking = false;
		this.CreateAndDestroyInternal();
	}

	// Token: 0x060003FC RID: 1020 RVA: 0x00017C60 File Offset: 0x00015E60
	public void ForceAfterTick(float delta)
	{
		this.Ticking = true;
		foreach (TickEntityGroup tickEntityGroup in this.TickEntityQueue)
		{
			foreach (Entity entity in tickEntityGroup.Entities.Values)
			{
				if (entity.Valid && entity.IsInit)
				{
					entity.ForceAfterTick(delta);
				}
			}
		}
		this.Ticking = false;
		this.CreateAndDestroyInternal();
	}

	// Token: 0x060003FD RID: 1021 RVA: 0x00017D18 File Offset: 0x00015F18
	public void AfterTick(float delta)
	{
		if (GameBudgetInterfaceController.IsOpen)
		{
			return;
		}
		this.Ticking = true;
		foreach (TickEntityGroup tickEntityGroup in this.TickEntityQueue)
		{
			foreach (Entity entity in tickEntityGroup.Entities.Values)
			{
				if (entity.Valid && entity.IsInit)
				{
					entity.AfterTick(delta);
				}
			}
		}
		this.Ticking = false;
		this.CreateAndDestroyInternal();
	}

	// Token: 0x060003FE RID: 1022 RVA: 0x00017DD8 File Offset: 0x00015FD8
	private void CreateAndDestroyInternal()
	{
		foreach (Entity entity in this.CreateEntities)
		{
			int priority;
			if (entity.Valid && this.EntityPriority.TryGetValue(entity.Id, out priority))
			{
				this.AddInternal(entity, priority);
			}
		}
		this.CreateEntities.Clear();
		foreach (int num in this.DestroyEntities)
		{
			int priority2;
			if (this.EntityPriority.TryGetValue(num, out priority2))
			{
				this.DeleteInternal(num, priority2);
			}
		}
		this.DestroyEntities.Clear();
	}

	// Token: 0x060003FF RID: 1023 RVA: 0x00017EB8 File Offset: 0x000160B8
	public void Clear()
	{
		this.TickEntityMap.Clear();
		this.TickEntityQueue.Clear();
	}

	// Token: 0x040003CF RID: 975
	private readonly Dictionary<int, TickEntityGroup> TickEntityMap = new Dictionary<int, TickEntityGroup>();

	// Token: 0x040003D0 RID: 976
	private readonly List<TickEntityGroup> TickEntityQueue = new List<TickEntityGroup>();

	// Token: 0x040003D1 RID: 977
	private readonly Dictionary<int, int> EntityPriority = new Dictionary<int, int>();

	// Token: 0x040003D2 RID: 978
	private bool Ticking;

	// Token: 0x040003D3 RID: 979
	private readonly List<Entity> CreateEntities = new List<Entity>();

	// Token: 0x040003D4 RID: 980
	private readonly List<int> DestroyEntities = new List<int>();

	// Token: 0x040003D5 RID: 981
	[StaticVariableRuleIgnore]
	private static readonly Stat ForceTickStat = Stat.Create("TickEntityManager.ForceTick", "", "");

	// Token: 0x040003D6 RID: 982
	[StaticVariableRuleIgnore]
	private static readonly Stat TickStat = Stat.Create("TickEntityManager.Tick", "", "");

	// Token: 0x040003D7 RID: 983
	[StaticVariableRuleIgnore]
	private static readonly Stat ForceAfterTickStat = Stat.Create("TickEntityManager.ForceAfterTick", "", "");

	// Token: 0x040003D8 RID: 984
	[StaticVariableRuleIgnore]
	private static readonly Stat AfterTickStat = Stat.Create("TickEntityManager.AfterTick", "", "");

	// Token: 0x040003D9 RID: 985
	private const int BINARY_SEARCH_THREADHOLD = 4;
}
