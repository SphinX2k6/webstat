using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Activity.ActivityContent.ChessGameplay.StackableChess;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x02001294 RID: 4756
[NullableContext(2)]
[Nullable(0)]
public class StackableChessItem : ChessItem
{
	// Token: 0x17000AD0 RID: 2768
	// (get) Token: 0x06007F54 RID: 32596 RVA: 0x0021A6C2 File Offset: 0x002188C2
	protected new IStackableChessAgent Agent
	{
		get
		{
			return this.Agent as IStackableChessAgent;
		}
	}

	// Token: 0x06007F55 RID: 32597 RVA: 0x0021A6CF File Offset: 0x002188CF
	public override void OnClear()
	{
		this.SetNextItem(null);
	}

	// Token: 0x06007F56 RID: 32598 RVA: 0x0021A6D8 File Offset: 0x002188D8
	public void SetNextItem(StackableChessItem otherItem)
	{
		if (this.NextItem != otherItem && this.Agent != null)
		{
			StackableChessItem nextItem = this.NextItem;
			if (nextItem != null)
			{
				IStackableChessAgent agent = nextItem.Agent;
				if (agent != null)
				{
					agent.DetachFromTarget(this.Agent);
				}
			}
		}
		if (this.Agent != null && otherItem != null)
		{
			IStackableChessAgent agent2 = otherItem.Agent;
			if (agent2 != null)
			{
				agent2.AttachToTarget(this.Agent);
			}
		}
		this.NextItem = otherItem;
	}

	// Token: 0x06007F57 RID: 32599 RVA: 0x0021A741 File Offset: 0x00218941
	public StackableChessItem GetNextItem()
	{
		return this.NextItem;
	}

	// Token: 0x06007F58 RID: 32600 RVA: 0x0021A749 File Offset: 0x00218949
	public Vector GetStackableLocation()
	{
		IStackableChessAgent agent = this.Agent;
		if (agent == null)
		{
			return null;
		}
		return agent.GetStackableLocation();
	}

	// Token: 0x06007F59 RID: 32601 RVA: 0x0021A75C File Offset: 0x0021895C
	public Rotator GetStackableRotator(bool otherIsForward)
	{
		IStackableChessAgent agent = this.Agent;
		if (agent == null)
		{
			return null;
		}
		return agent.GetStackableRotator(base.RotationIsForward() == otherIsForward);
	}

	// Token: 0x06007F5A RID: 32602 RVA: 0x0021A778 File Offset: 0x00218978
	[NullableContext(1)]
	public override UniTask MoveAsync(Vector location, Rotator rotator, bool isForward)
	{
		StackableChessItem.<MoveAsync>d__8 <MoveAsync>d__;
		<MoveAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<MoveAsync>d__.<>4__this = this;
		<MoveAsync>d__.location = location;
		<MoveAsync>d__.rotator = rotator;
		<MoveAsync>d__.isForward = isForward;
		<MoveAsync>d__.<>1__state = -1;
		<MoveAsync>d__.<>t__builder.Start<StackableChessItem.<MoveAsync>d__8>(ref <MoveAsync>d__);
		return <MoveAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06007F5B RID: 32603 RVA: 0x0021A7D4 File Offset: 0x002189D4
	public override UniTask PerformAsync(int type)
	{
		StackableChessItem.<PerformAsync>d__9 <PerformAsync>d__;
		<PerformAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PerformAsync>d__.<>4__this = this;
		<PerformAsync>d__.type = type;
		<PerformAsync>d__.<>1__state = -1;
		<PerformAsync>d__.<>t__builder.Start<StackableChessItem.<PerformAsync>d__9>(ref <PerformAsync>d__);
		return <PerformAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06007F5C RID: 32604 RVA: 0x0021A820 File Offset: 0x00218A20
	[NullableContext(1)]
	private void NotifyNextItemsMoveStateChange(IStackableChessAgent agent, bool isMoving, bool isForward)
	{
		HashSet<int> hashSet = new HashSet<int>();
		bool flag = base.RotationIsForward();
		StackableChessItem nextItem = this.NextItem;
		while (nextItem != null && !hashSet.Contains(nextItem.GetId()))
		{
			hashSet.Add(nextItem.GetId());
			IStackableChessAgent agent2 = nextItem.Agent;
			if (agent2 != null)
			{
				agent2.OnPreviousMoveStateChange(agent, isMoving, isForward, flag == nextItem.RotationIsForward());
			}
			nextItem = nextItem.GetNextItem();
		}
	}

	// Token: 0x06007F5D RID: 32605 RVA: 0x0021A888 File Offset: 0x00218A88
	[NullableContext(1)]
	private void NotifyNextItemsPerformStateChange(IStackableChessAgent agent, int type, bool isPerforming)
	{
		HashSet<int> hashSet = new HashSet<int>();
		StackableChessItem nextItem = this.NextItem;
		while (nextItem != null && !hashSet.Contains(nextItem.GetId()))
		{
			hashSet.Add(nextItem.GetId());
			if (nextItem != null)
			{
				IStackableChessAgent agent2 = nextItem.Agent;
				if (agent2 != null)
				{
					agent2.OnPreviousPerformStateChange(agent, type, isPerforming);
				}
			}
			nextItem = nextItem.GetNextItem();
		}
	}

	// Token: 0x06007F5E RID: 32606 RVA: 0x0021A8E0 File Offset: 0x00218AE0
	public void DetachSelfFromChain()
	{
		StackableChessItem nextItem = this.NextItem;
		StackableChessboardPoint stackableChessboardPoint = base.GetCurrentPoint() as StackableChessboardPoint;
		this.SetNextItem(null);
		if (stackableChessboardPoint == null || nextItem == null)
		{
			return;
		}
		StackableChessItem stackableChessItem = stackableChessboardPoint.FindPreviousItem(this);
		if (stackableChessItem != null)
		{
			stackableChessItem.SetNextItem(nextItem);
			Vector stackableLocation = stackableChessItem.GetStackableLocation();
			if (stackableLocation != null)
			{
				nextItem.Teleport(stackableLocation, stackableChessboardPoint.GetPointRotator(true));
				return;
			}
		}
		else
		{
			Vector pointLocation = stackableChessboardPoint.GetPointLocation();
			nextItem.Teleport(pointLocation, stackableChessboardPoint.GetPointRotator(true));
		}
	}

	// Token: 0x04003CF6 RID: 15606
	private StackableChessItem NextItem;
}
