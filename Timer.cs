using System;
using System.Runtime.CompilerServices;

// Token: 0x02000BEC RID: 3052
[NullableContext(2)]
[Nullable(0)]
public class Timer
{
	// Token: 0x06003267 RID: 12903 RVA: 0x00022698 File Offset: 0x00020898
	public Timer(int id, TTimerAction action, float interval, int loop, float dilation, TimerHandle handle, Stat stat, string reason)
	{
		this.Id = id;
		this.Action = action;
		this.Interval = interval;
		this.Loop = loop;
		this.Dilation = dilation;
		this.Handle = handle;
		this.Stat = stat;
		this.Reason = reason;
		this.Next = this.Now + (double)(this.Interval / this.Dilation);
	}

	// Token: 0x06003268 RID: 12904 RVA: 0x00022704 File Offset: 0x00020904
	public unsafe bool Do()
	{
		double next = this.Next;
		float delta = (float)(next - this.Now);
		Stat stat = this.Stat;
		this.Now = next;
		this.Next = next + (double)(this.Interval / this.Dilation);
		this.Count++;
		try
		{
			this.Handle = null;
			this.Action(delta);
		}
		catch (Exception ex) when (1)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Timer;
			ELogAuthor author = ELogAuthor.LCC;
			string message = "定时器执行异常";
			Exception error = ex;
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("id", this.Id);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("reason", this.Reason);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("error", ex.Message);
			instance.ErrorWithStack(module, author, message, error, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
		}
		return this.Loop == 0 || this.Count < this.Loop;
	}

	// Token: 0x06003269 RID: 12905 RVA: 0x0002282C File Offset: 0x00020A2C
	[NullableContext(1)]
	public Timer Copy()
	{
		this.Handle = null;
		return new Timer(this.Id, this.Action, this.Interval, this.Loop, this.Dilation, null, this.Stat, this.Reason)
		{
			Now = this.Now,
			Next = this.Next,
			Count = this.Count,
			State = this.State
		};
	}

	// Token: 0x0600326A RID: 12906 RVA: 0x000228A0 File Offset: 0x00020AA0
	public void Clear()
	{
		this.Action = null;
		this.Handle = null;
		this.Stat = null;
	}

	// Token: 0x0600326B RID: 12907 RVA: 0x000228B7 File Offset: 0x00020AB7
	[NullableContext(1)]
	public static int Compare(Timer a, Timer b)
	{
		return a.Next.CompareTo(b.Next);
	}

	// Token: 0x04000539 RID: 1337
	public double Now;

	// Token: 0x0400053A RID: 1338
	public double Next;

	// Token: 0x0400053B RID: 1339
	private int Count;

	// Token: 0x0400053C RID: 1340
	public EState State;

	// Token: 0x0400053D RID: 1341
	public readonly int Id;

	// Token: 0x0400053E RID: 1342
	private TTimerAction Action;

	// Token: 0x0400053F RID: 1343
	public float Interval;

	// Token: 0x04000540 RID: 1344
	private readonly int Loop;

	// Token: 0x04000541 RID: 1345
	public float Dilation;

	// Token: 0x04000542 RID: 1346
	public TimerHandle Handle;

	// Token: 0x04000543 RID: 1347
	private Stat Stat;

	// Token: 0x04000544 RID: 1348
	public readonly string Reason;
}
