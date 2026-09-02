using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x020026D0 RID: 9936
[NullableContext(1)]
[Nullable(0)]
public class DangoDungeonCommandQueue
{
	// Token: 0x060139C5 RID: 80325 RVA: 0x0057899B File Offset: 0x00576B9B
	public void Init()
	{
		this.Reset();
	}

	// Token: 0x060139C6 RID: 80326 RVA: 0x005789A3 File Offset: 0x00576BA3
	public void AddCommand(IDangoDungeonCommand command)
	{
		if (this.IsAborted)
		{
			return;
		}
		this.CommandQueue.Push(command);
	}

	// Token: 0x060139C7 RID: 80327 RVA: 0x005789BA File Offset: 0x00576BBA
	public void Abort()
	{
		if (this.CurCommand != null)
		{
			this.CurCommand.IsAborted = true;
		}
		this.IsAborted = true;
	}

	// Token: 0x060139C8 RID: 80328 RVA: 0x005789D8 File Offset: 0x00576BD8
	public UniTask Execute()
	{
		DangoDungeonCommandQueue.<Execute>d__10 <Execute>d__;
		<Execute>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<Execute>d__.<>4__this = this;
		<Execute>d__.<>1__state = -1;
		<Execute>d__.<>t__builder.Start<DangoDungeonCommandQueue.<Execute>d__10>(ref <Execute>d__);
		return <Execute>d__.<>t__builder.Task;
	}

	// Token: 0x060139C9 RID: 80329 RVA: 0x00578A1C File Offset: 0x00576C1C
	private void RecordCommandExecuteTime(ERacingBetsCommandType commandType, double time)
	{
	}

	// Token: 0x060139CA RID: 80330 RVA: 0x00578A2C File Offset: 0x00576C2C
	private void PrintStatsInfo()
	{
	}

	// Token: 0x060139CB RID: 80331 RVA: 0x00578A39 File Offset: 0x00576C39
	public void OnEnd(bool isAborted)
	{
		Action<bool> onCommandQueueEndCallBack = this.OnCommandQueueEndCallBack;
		if (onCommandQueueEndCallBack != null)
		{
			onCommandQueueEndCallBack(isAborted);
		}
		this.Reset();
	}

	// Token: 0x060139CC RID: 80332 RVA: 0x00578A53 File Offset: 0x00576C53
	private void Reset()
	{
		this.TotalTime = 0.0;
		this.CurCommandActionIndex = 0;
		this.Stats.Clear();
		this.IsAborted = false;
		this.CommandQueue.Clear();
		this.OnCommandQueueEndCallBack = null;
	}

	// Token: 0x060139CD RID: 80333 RVA: 0x00578A8F File Offset: 0x00576C8F
	public void BindCommandQueueEndCallBack(Action<bool> callBack)
	{
		this.OnCommandQueueEndCallBack = callBack;
	}

	// Token: 0x040098A0 RID: 39072
	public int CurCommandActionIndex;

	// Token: 0x040098A1 RID: 39073
	private bool IsAborted;

	// Token: 0x040098A2 RID: 39074
	private Queue<IDangoDungeonCommand> CommandQueue = new Queue<IDangoDungeonCommand>(4);

	// Token: 0x040098A3 RID: 39075
	[Nullable(2)]
	private Action<bool> OnCommandQueueEndCallBack;

	// Token: 0x040098A4 RID: 39076
	private readonly Dictionary<ERacingBetsCommandType, IDangoDungeonCommandStats> Stats = new Dictionary<ERacingBetsCommandType, IDangoDungeonCommandStats>();

	// Token: 0x040098A5 RID: 39077
	[Nullable(2)]
	private IDangoDungeonCommand CurCommand;

	// Token: 0x040098A6 RID: 39078
	private double TotalTime;
}
