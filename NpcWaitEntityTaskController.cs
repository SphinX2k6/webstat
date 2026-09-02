using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x020031C8 RID: 12744
[NullableContext(1)]
[Nullable(0)]
public class NpcWaitEntityTaskController
{
	// Token: 0x0601A6AC RID: 108204 RVA: 0x007CAE2D File Offset: 0x007C902D
	public NpcWaitEntityTaskController(Entity entity)
	{
		this.OwnerEntity = entity;
	}

	// Token: 0x0601A6AD RID: 108205 RVA: 0x007CAE52 File Offset: 0x007C9052
	private void Init()
	{
		this.TasksMap[ETaskType.IgnoreCollision] = ((Entity npcEntity, int pbDataId) => new NpcIgnoreCollisionTask(npcEntity, pbDataId));
	}

	// Token: 0x0601A6AE RID: 108206 RVA: 0x007CAE80 File Offset: 0x007C9080
	public void Dispose()
	{
		foreach (NpcWaitEntityTask npcWaitEntityTask in this.WaitEntityTaskList)
		{
			npcWaitEntityTask.Stop();
		}
		this.WaitEntityTaskList.Clear();
	}

	// Token: 0x0601A6AF RID: 108207 RVA: 0x007CAEDC File Offset: 0x007C90DC
	[NullableContext(2)]
	public void AddTask(List<int> pbDataIdArray, ETaskType type)
	{
		if (pbDataIdArray != null && pbDataIdArray.Count == 0)
		{
			return;
		}
		if (!this.IsInit)
		{
			this.IsInit = true;
			this.Init();
		}
		Func<Entity, int, NpcWaitEntityTask> func = this.TasksMap[type];
		foreach (int arg in pbDataIdArray)
		{
			NpcWaitEntityTask item = func(this.OwnerEntity, arg);
			this.WaitEntityTaskList.Add(item);
		}
	}

	// Token: 0x0601A6B0 RID: 108208 RVA: 0x007CAF6C File Offset: 0x007C916C
	public void RunTask()
	{
		foreach (NpcWaitEntityTask npcWaitEntityTask in this.WaitEntityTaskList)
		{
			npcWaitEntityTask.Start();
		}
	}

	// Token: 0x0400D547 RID: 54599
	public const int WAIT_IGNORE_ACTOR_TIMEOUT = 30000;

	// Token: 0x0400D548 RID: 54600
	[Nullable(2)]
	private readonly Entity OwnerEntity;

	// Token: 0x0400D549 RID: 54601
	private readonly List<NpcWaitEntityTask> WaitEntityTaskList = new List<NpcWaitEntityTask>();

	// Token: 0x0400D54A RID: 54602
	private readonly Dictionary<ETaskType, Func<Entity, int, NpcWaitEntityTask>> TasksMap = new Dictionary<ETaskType, Func<Entity, int, NpcWaitEntityTask>>();

	// Token: 0x0400D54B RID: 54603
	private bool IsInit;
}
