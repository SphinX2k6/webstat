using System;
using System.Runtime.CompilerServices;

// Token: 0x02003103 RID: 12547
[NullableContext(1)]
[Nullable(0)]
public class PerformModeBase
{
	// Token: 0x06019F14 RID: 106260 RVA: 0x00796022 File Offset: 0x00794222
	public PerformModeBase(EPerformMode mode, BasePerformComponent performComp, PerformMachine machine)
	{
		this.Mode = mode;
		this.PerformComp = performComp;
		this.Machine = machine;
	}

	// Token: 0x06019F15 RID: 106261 RVA: 0x0079604B File Offset: 0x0079424B
	public void PushAction(IPerformActionBase actionInfo, bool bRestore)
	{
		if (bRestore)
		{
			this.CachePerformAction.AddFront(actionInfo);
			return;
		}
		this.CachePerformAction.AddRear(actionInfo);
	}

	// Token: 0x06019F16 RID: 106262 RVA: 0x00796069 File Offset: 0x00794269
	[NullableContext(2)]
	public IPerformActionBase PopAction()
	{
		if (this.CachePerformAction.Size == 0)
		{
			return null;
		}
		return this.CachePerformAction.RemoveFront();
	}

	// Token: 0x06019F17 RID: 106263 RVA: 0x00796085 File Offset: 0x00794285
	public virtual bool CheckEnter()
	{
		return false;
	}

	// Token: 0x06019F18 RID: 106264 RVA: 0x00796088 File Offset: 0x00794288
	public virtual bool CheckExit()
	{
		return false;
	}

	// Token: 0x06019F19 RID: 106265 RVA: 0x0079608B File Offset: 0x0079428B
	public void Clear()
	{
		this.CachePerformAction.Clear();
	}

	// Token: 0x0400D001 RID: 53249
	public readonly EPerformMode Mode;

	// Token: 0x0400D002 RID: 53250
	protected readonly BasePerformComponent PerformComp;

	// Token: 0x0400D003 RID: 53251
	protected readonly PerformMachine Machine;

	// Token: 0x0400D004 RID: 53252
	protected readonly Deque<IPerformActionBase> CachePerformAction = new Deque<IPerformActionBase>(4);
}
