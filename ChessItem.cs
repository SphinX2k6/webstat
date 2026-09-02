using System;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x02001285 RID: 4741
[NullableContext(1)]
[Nullable(0)]
public class ChessItem
{
	// Token: 0x06007EF3 RID: 32499 RVA: 0x00219E78 File Offset: 0x00218078
	public void Init(int id, IChessAgent agent, bool rotationIsForward)
	{
		this.Id = id;
		this.Agent = agent;
		this.RotationIsForwardInternal = rotationIsForward;
	}

	// Token: 0x06007EF4 RID: 32500 RVA: 0x00219E8F File Offset: 0x0021808F
	public virtual void OnClear()
	{
	}

	// Token: 0x06007EF5 RID: 32501 RVA: 0x00219E91 File Offset: 0x00218091
	public int GetId()
	{
		return this.Id;
	}

	// Token: 0x06007EF6 RID: 32502 RVA: 0x00219E9C File Offset: 0x0021809C
	public void SetCurrentPoint(ChessboardPoint point)
	{
		ChessboardPoint currentPoint = this.CurrentPoint;
		this.CurrentPoint = point;
		if (currentPoint == null)
		{
			return;
		}
		ChessboardPoint terminalPoint = ModelBase<ChessModel>.Instance.GetTerminalPoint();
		if (terminalPoint == null)
		{
			return;
		}
		if (terminalPoint.GetId() == point.GetId())
		{
			this.ReachTerminalTimes++;
			return;
		}
		int sortIndex = terminalPoint.GetSortIndex();
		int sortIndex2 = point.GetSortIndex();
		if (currentPoint.GetSortIndex() < sortIndex && sortIndex2 > sortIndex)
		{
			this.ReachTerminalTimes++;
		}
	}

	// Token: 0x06007EF7 RID: 32503 RVA: 0x00219F10 File Offset: 0x00218110
	[NullableContext(2)]
	public ChessboardPoint GetCurrentPoint()
	{
		return this.CurrentPoint;
	}

	// Token: 0x06007EF8 RID: 32504 RVA: 0x00219F18 File Offset: 0x00218118
	public int GetReachTerminalTimes()
	{
		return this.ReachTerminalTimes;
	}

	// Token: 0x06007EF9 RID: 32505 RVA: 0x00219F20 File Offset: 0x00218120
	[NullableContext(2)]
	public Vector GetLocation()
	{
		IChessAgent agent = this.Agent;
		if (agent == null)
		{
			return null;
		}
		return agent.GetLocation();
	}

	// Token: 0x06007EFA RID: 32506 RVA: 0x00219F33 File Offset: 0x00218133
	public bool RotationIsForward()
	{
		return this.RotationIsForwardInternal;
	}

	// Token: 0x06007EFB RID: 32507 RVA: 0x00219F3C File Offset: 0x0021813C
	public virtual UniTask MoveAsync(Vector location, Rotator rotator, bool performIsForward)
	{
		ChessItem.<MoveAsync>d__14 <MoveAsync>d__;
		<MoveAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<MoveAsync>d__.<>4__this = this;
		<MoveAsync>d__.location = location;
		<MoveAsync>d__.rotator = rotator;
		<MoveAsync>d__.performIsForward = performIsForward;
		<MoveAsync>d__.<>1__state = -1;
		<MoveAsync>d__.<>t__builder.Start<ChessItem.<MoveAsync>d__14>(ref <MoveAsync>d__);
		return <MoveAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06007EFC RID: 32508 RVA: 0x00219F97 File Offset: 0x00218197
	public virtual void Teleport(Vector location, Rotator rotator)
	{
		if (this.CurrentState != EChessStateType.Idle || this.Agent == null)
		{
			return;
		}
		this.Agent.Teleport(location, rotator);
	}

	// Token: 0x06007EFD RID: 32509 RVA: 0x00219FB8 File Offset: 0x002181B8
	public virtual UniTask PerformAsync(int type)
	{
		ChessItem.<PerformAsync>d__16 <PerformAsync>d__;
		<PerformAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PerformAsync>d__.<>4__this = this;
		<PerformAsync>d__.type = type;
		<PerformAsync>d__.<>1__state = -1;
		<PerformAsync>d__.<>t__builder.Start<ChessItem.<PerformAsync>d__16>(ref <PerformAsync>d__);
		return <PerformAsync>d__.<>t__builder.Task;
	}

	// Token: 0x04003CD6 RID: 15574
	private int Id;

	// Token: 0x04003CD7 RID: 15575
	protected EChessStateType CurrentState;

	// Token: 0x04003CD8 RID: 15576
	[Nullable(2)]
	protected ChessboardPoint CurrentPoint;

	// Token: 0x04003CD9 RID: 15577
	[Nullable(2)]
	protected IChessAgent Agent;

	// Token: 0x04003CDA RID: 15578
	private int ReachTerminalTimes;

	// Token: 0x04003CDB RID: 15579
	private bool RotationIsForwardInternal = true;
}
