using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;

// Token: 0x02000BED RID: 3053
[NullableContext(1)]
[Nullable(0)]
public class TimerSystemInstance
{
	// Token: 0x0600326C RID: 12908 RVA: 0x000228CC File Offset: 0x00020ACC
	public unsafe void Tick(float delta)
	{
		double num = this.Now + (double)delta;
		this.Now = num;
		PriorityQueue<Timer> queue = this.Queue;
		while (!queue.Empty)
		{
			Timer top = queue.Top;
			if (top == null || top.Next > num)
			{
				IL_105:
				while (!this.PendingRemoveQueue.IsEmpty)
				{
					ValueTuple<TimerHandle, string> valueTuple;
					if (this.PendingRemoveQueue.TryDequeue(out valueTuple))
					{
						Log instance = Singleton<Log>.Instance;
						ELogModule module = ELogModule.Timer;
						ELogAuthor author = ELogAuthor.LFJW;
						string message = "移除TimerHandle已经被GC的定时器";
						<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
						ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0);
						string item = "timer";
						TimerHandle item2 = valueTuple.Item1;
						ptr = new ValueTuple<string, object>(item, (item2 != null) ? new int?(item2.Id) : null);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("reason", valueTuple.Item2);
						instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
						this.Remove(valueTuple.Item1);
					}
				}
				return;
			}
			queue.Pop();
			if (top.State == EState.Normal)
			{
				if (top.Do())
				{
					queue.Push(top);
				}
				else
				{
					this.DoRemove(top);
				}
			}
		}
		goto IL_105;
	}

	// Token: 0x0600326D RID: 12909 RVA: 0x000229EE File Offset: 0x00020BEE
	[NullableContext(2)]
	public bool Has(TimerHandle handle)
	{
		return handle != null && this.Timers.ContainsKey(handle.Id);
	}

	// Token: 0x0600326E RID: 12910 RVA: 0x00022A06 File Offset: 0x00020C06
	[NullableContext(2)]
	public TimerHandle Loop([Nullable(1)] TTimerAction action, float interval, int loop, float dilation = 1f, Stat stat = null, string reason = null, bool needCheckMaxInterval = true)
	{
		if (!TimerSystemInstance.CheckInterval(interval, reason, needCheckMaxInterval) || !TimerSystemInstance.CheckLoop(loop) || !TimerSystemInstance.CheckDilation(dilation))
		{
			return null;
		}
		return this.DoAdd(action, interval, loop, dilation, stat, reason);
	}

	// Token: 0x0600326F RID: 12911 RVA: 0x00022A36 File Offset: 0x00020C36
	[NullableContext(2)]
	public TimerHandle Forever([Nullable(1)] TTimerAction action, float interval, float dilation = 1f, Stat stat = null, string reason = null, bool needCheckMaxInterval = true)
	{
		if (!TimerSystemInstance.CheckInterval(interval, reason, needCheckMaxInterval) || !TimerSystemInstance.CheckDilation(dilation))
		{
			return null;
		}
		return this.DoAdd(action, interval, 0, dilation, stat, reason);
	}

	// Token: 0x06003270 RID: 12912 RVA: 0x00022A5C File Offset: 0x00020C5C
	[NullableContext(2)]
	public TimerHandle Delay([Nullable(1)] TTimerAction action, float interval, Stat stat = null, string reason = null, bool needCheckMaxInterval = true, float dilation = 1f)
	{
		if (!TimerSystemInstance.CheckInterval(interval, reason, needCheckMaxInterval) || !TimerSystemInstance.CheckDilation(dilation))
		{
			return null;
		}
		return this.DoAdd(action, interval, 1, dilation, stat, reason);
	}

	// Token: 0x06003271 RID: 12913 RVA: 0x00022A84 File Offset: 0x00020C84
	[NullableContext(2)]
	public TimerHandle EmitOnTime([Nullable(1)] TTimerAction action, double emitTimeStamp, Stat stat = null, string reason = null, bool needCheckMaxInterval = true, float dilation = 1f)
	{
		float interval = (float)(emitTimeStamp - this.Now);
		if (!TimerSystemInstance.CheckInterval(interval, reason, needCheckMaxInterval) || !TimerSystemInstance.CheckDilation(dilation))
		{
			return null;
		}
		return this.DoAdd(action, interval, 1, dilation, stat, reason);
	}

	// Token: 0x06003272 RID: 12914 RVA: 0x00022AC0 File Offset: 0x00020CC0
	[NullableContext(2)]
	public TimerHandle Next([Nullable(1)] TTimerAction action, Stat stat = null, string reason = null)
	{
		return this.DoAdd(action, 1f, 1, 1f, stat, reason);
	}

	// Token: 0x06003273 RID: 12915 RVA: 0x00022AD6 File Offset: 0x00020CD6
	public void PendingRemove_FinalizerThread(TimerHandle handle, [Nullable(2)] string reason)
	{
		this.PendingRemoveQueue.Enqueue(new ValueTuple<TimerHandle, string>(handle, reason));
	}

	// Token: 0x06003274 RID: 12916 RVA: 0x00022AEC File Offset: 0x00020CEC
	[NullableContext(2)]
	public bool Remove(TimerHandle handle)
	{
		if (handle != null)
		{
			Timer timer = this.Get(handle);
			return timer != null && this.DoRemove(timer);
		}
		return true;
	}

	// Token: 0x06003275 RID: 12917 RVA: 0x00022B14 File Offset: 0x00020D14
	public bool IsPause(TimerHandle handle)
	{
		Timer timer = this.Get(handle);
		return timer != null && timer.State == EState.Pause;
	}

	// Token: 0x06003276 RID: 12918 RVA: 0x00022B38 File Offset: 0x00020D38
	public unsafe bool Pause(TimerHandle handle, [Nullable(2)] string reason = null)
	{
		Timer timer = this.Get(handle);
		if (timer == null)
		{
			return false;
		}
		if (timer.State != EState.Normal)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Timer;
			ELogAuthor author = ELogAuthor.LCC;
			string message = "计时器已废弃或暂停";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("id", handle.Id);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("state", timer.State);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return false;
		}
		Timer timer2 = timer.Copy();
		timer.State = EState.Trash;
		timer2.Next = (double)((float)(timer2.Next - this.Now));
		timer2.State = EState.Pause;
		this.Registry.Unregister(timer);
		this.Timers[handle.Id] = timer2;
		this.Registry.Register(timer2, handle, reason, this.DisposeHandle_FinalizerThread);
		return true;
	}

	// Token: 0x06003277 RID: 12919 RVA: 0x00022C24 File Offset: 0x00020E24
	public unsafe bool Resume(TimerHandle handle)
	{
		Timer timer = this.Get(handle);
		if (timer == null)
		{
			return false;
		}
		if (timer.State != EState.Pause)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Timer;
			ELogAuthor author = ELogAuthor.LCC;
			string message = "计时器已废弃或非暂停";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("id", handle.Id);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("state", timer.State);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return false;
		}
		timer.Next = (double)((float)(timer.Next + this.Now));
		timer.State = EState.Normal;
		this.Queue.Push(timer);
		return true;
	}

	// Token: 0x06003278 RID: 12920 RVA: 0x00022CD8 File Offset: 0x00020ED8
	public unsafe bool ChangeInterval(TimerHandle handle, float interval, [Nullable(2)] string reason, bool needCheckMaxInterval = true)
	{
		if (!TimerSystemInstance.CheckInterval(interval, reason, needCheckMaxInterval))
		{
			return false;
		}
		Timer timer = this.Get(handle);
		if (timer == null)
		{
			return false;
		}
		if (timer.State == EState.Trash)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Timer;
			ELogAuthor author = ELogAuthor.LCC;
			string message = "计时器已废弃";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("id", handle.Id);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("interval", interval);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}
		if (Math.Abs(timer.Interval - interval) < 0.001f)
		{
			return true;
		}
		double now = this.Now;
		if (timer.State == EState.Pause)
		{
			double num = timer.Next + (double)interval - (double)timer.Interval;
			timer.Next = ((num < 0.0) ? 0.0 : num);
			timer.Interval = interval;
			return true;
		}
		Timer timer2 = timer.Copy();
		timer.State = EState.Trash;
		double num2 = timer2.Next + (double)interval - (double)timer2.Interval;
		timer2.Next = ((num2 < now) ? now : num2);
		timer2.Interval = interval;
		this.Registry.Unregister(timer);
		this.Timers[handle.Id] = timer2;
		this.Queue.Push(timer2);
		this.Registry.Register(timer2, handle, reason, this.DisposeHandle_FinalizerThread);
		return true;
	}

	// Token: 0x06003279 RID: 12921 RVA: 0x00022E44 File Offset: 0x00021044
	public unsafe bool ChangeDilation(TimerHandle handle, float dilation, [Nullable(2)] string reason = null)
	{
		if (!TimerSystemInstance.CheckDilation(dilation))
		{
			return false;
		}
		Timer timer = this.Get(handle);
		if (timer == null)
		{
			return false;
		}
		if (timer.State == EState.Trash)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Timer;
			ELogAuthor author = ELogAuthor.LCC;
			string message = "计时器已废弃";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("id", handle.Id);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("dilation", dilation);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}
		if (Math.Abs(timer.Dilation - dilation) < 0.001f)
		{
			return true;
		}
		double now = this.Now;
		if (timer.State == EState.Pause)
		{
			timer.Next = timer.Next * (double)timer.Dilation / (double)dilation;
			timer.Dilation = dilation;
			return true;
		}
		Timer timer2 = timer.Copy();
		timer.State = EState.Trash;
		timer2.Next = now + (timer2.Next - now) * (double)timer2.Dilation / (double)dilation;
		timer2.Dilation = dilation;
		this.Registry.Unregister(timer);
		this.Timers[handle.Id] = timer2;
		this.Queue.Push(timer2);
		this.Registry.Register(timer2, handle, reason, this.DisposeHandle_FinalizerThread);
		return true;
	}

	// Token: 0x0600327A RID: 12922 RVA: 0x00022F8C File Offset: 0x0002118C
	public float GetNextRemainTime(TimerHandle handle)
	{
		Timer timer = this.Get(handle);
		if (timer == null)
		{
			return -1f;
		}
		if (timer.State != EState.Normal)
		{
			return -1f;
		}
		return (float)(timer.Next - this.Now);
	}

	// Token: 0x0600327B RID: 12923 RVA: 0x00022FC8 File Offset: 0x000211C8
	[NullableContext(2)]
	public UniTask Wait(float delay, Stat stat = null)
	{
		UniTaskCompletionSource tcs = new UniTaskCompletionSource();
		this.Delay(delegate(float _)
		{
			tcs.TrySetResult();
		}, delay, stat, null, true, 1f);
		return tcs.Task;
	}

	// Token: 0x0600327C RID: 12924 RVA: 0x00023010 File Offset: 0x00021210
	public void Clear()
	{
		foreach (KeyValuePair<int, Timer> keyValuePair in this.Timers)
		{
			Timer value = keyValuePair.Value;
			if (value.Handle != null)
			{
				this.Remove(value.Handle);
			}
		}
		this.Timers.Clear();
		this.Queue.Clear();
	}

	// Token: 0x0600327D RID: 12925 RVA: 0x00023090 File Offset: 0x00021290
	[return: Nullable(2)]
	private Timer Get(TimerHandle handle)
	{
		if (handle == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.Timer, ELogAuthor.LCC, "计时器句柄为空", default(ReadOnlySpan<ValueTuple<string, object>>));
			return null;
		}
		return this.DoGet(handle.Id);
	}

	// Token: 0x0600327E RID: 12926 RVA: 0x000230CC File Offset: 0x000212CC
	[NullableContext(2)]
	private Timer DoGet(int id)
	{
		if (id <= 0)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Timer;
			ELogAuthor author = ELogAuthor.LCC;
			string message = "计时器句柄非法";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		Timer result;
		if (!this.Timers.TryGetValue(id, out result))
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Timer;
			ELogAuthor author2 = ELogAuthor.LCC;
			string message2 = "计时器句柄不存在";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("id", id);
			instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			return null;
		}
		return result;
	}

	// Token: 0x0600327F RID: 12927 RVA: 0x00023148 File Offset: 0x00021348
	[NullableContext(2)]
	private TimerHandle DoAdd([Nullable(1)] TTimerAction action, float interval, int loop, float dilation, Stat stat, string reason)
	{
		if (action == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Timer;
			ELogAuthor author = ELogAuthor.LCC;
			string message = "定时器处理方法不存在";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("handle", action);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		Stat stat2 = null;
		if (stat == null && !this.StatWeakMap.TryGetValue(action.Method, out stat2))
		{
			stat2 = Stat.CreateWithStack("TimerAction", 2, 5);
			this.StatWeakMap.Add(action.Method, stat2);
		}
		double now = this.Now;
		TimerHandle timerHandle = new TimerHandle(this);
		Timer timer = new Timer(timerHandle.Id, action, interval, loop, dilation, timerHandle, stat ?? stat2, reason);
		timer.Now = now;
		timer.Next = now + (double)(interval / dilation);
		this.Timers[timerHandle.Id] = timer;
		this.Queue.Push(timer);
		this.Registry.Register(timer, timerHandle, reason, this.DisposeHandle_FinalizerThread);
		return timerHandle;
	}

	// Token: 0x06003280 RID: 12928 RVA: 0x0002322C File Offset: 0x0002142C
	private bool DoRemove(Timer timer)
	{
		this.Registry.Unregister(timer);
		timer.State = EState.Trash;
		timer.Clear();
		this.Timers.Remove(timer.Id);
		return true;
	}

	// Token: 0x06003281 RID: 12929 RVA: 0x0002325C File Offset: 0x0002145C
	[NullableContext(2)]
	private unsafe static bool CheckInterval(float interval, string reason = null, bool needCheckMaxInterval = true)
	{
		if (interval < 20f)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Timer;
			ELogAuthor author = ELogAuthor.LCC;
			string message = "计时器间隔必须在合理范围内，请检查定时器间隔参数";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("MIN_TIME", 20);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("MAX_TIME", 180000);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("interval", interval);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			return false;
		}
		if (needCheckMaxInterval && interval > 180000f)
		{
			if (reason != null)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.Timer;
				ELogAuthor author2 = ELogAuthor.LCC;
				string message2 = "计时器间隔较长，此处显式打印辅助定位问题";
				<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray4<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("MIN_TIME", 20);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("MAX_TIME", 180000);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("interval", interval);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 3) = new ValueTuple<string, object>("reason", reason);
				instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 4));
			}
			else
			{
				Log instance3 = Singleton<Log>.Instance;
				ELogModule module3 = ELogModule.Timer;
				ELogAuthor author3 = ELogAuthor.LCC;
				string message3 = "计时器间隔必须在合理范围内，请联系 CC 确认时间是否合理";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray3 = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 0) = new ValueTuple<string, object>("MIN_TIME", 20);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 1) = new ValueTuple<string, object>("MAX_TIME", 180000);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 2) = new ValueTuple<string, object>("interval", interval);
				instance3.Error(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray3, 3));
			}
			return true;
		}
		return true;
	}

	// Token: 0x06003282 RID: 12930 RVA: 0x00023424 File Offset: 0x00021624
	private unsafe static bool CheckLoop(int loop)
	{
		if (loop <= 1 || loop > 10)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Timer;
			ELogAuthor author = ELogAuthor.LCC;
			string message = "计时器次数必须在合理范围内，请检查定时器循环次数参数";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("MAX_LOOP", 10);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("loop", loop);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return false;
		}
		return true;
	}

	// Token: 0x06003283 RID: 12931 RVA: 0x0002349C File Offset: 0x0002169C
	private static bool CheckDilation(float dilation)
	{
		if (dilation <= 0f)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Timer;
			ELogAuthor author = ELogAuthor.LCC;
			string message = "计时器时间缩放不能小于等于 0 ，请检查定时器时间缩放参数";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("dilation", dilation);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return false;
		}
		return true;
	}

	// Token: 0x06003284 RID: 12932 RVA: 0x000234E0 File Offset: 0x000216E0
	public TimerSystemInstance()
	{
		Comparison<Timer> compare;
		if ((compare = TimerSystemInstance.<>O.<0>__Compare) == null)
		{
			compare = (TimerSystemInstance.<>O.<0>__Compare = new Comparison<Timer>(Timer.Compare));
		}
		this.Queue = new PriorityQueue<Timer>(compare);
		this.Stat = Stat.Create("TimerSystem.Tick", "", "");
		this.StatWeakMap = new Dictionary<MethodInfo, Stat>();
		this.PendingRemoveQueue = new ConcurrentQueue<ValueTuple<TimerHandle, string>>();
		this.Registry = new FinalizationRegistry<Timer, TimerHandle>();
		this.DisposeHandle_FinalizerThread = delegate(TimerHandle param, string newReason)
		{
			if (param != null)
			{
				param.PendingRemove_FinalizerThread(newReason);
			}
		};
		base..ctor();
	}

	// Token: 0x04000545 RID: 1349
	public const int MIN_TIME = 20;

	// Token: 0x04000546 RID: 1350
	public const int MAX_TIME = 180000;

	// Token: 0x04000547 RID: 1351
	public const int MAX_LOOP = 10;

	// Token: 0x04000548 RID: 1352
	public const int FOREVER = 0;

	// Token: 0x04000549 RID: 1353
	public double Now;

	// Token: 0x0400054A RID: 1354
	public Dictionary<int, Timer> Timers = new Dictionary<int, Timer>();

	// Token: 0x0400054B RID: 1355
	public PriorityQueue<Timer> Queue;

	// Token: 0x0400054C RID: 1356
	[Nullable(2)]
	public Stat Stat;

	// Token: 0x0400054D RID: 1357
	public Dictionary<MethodInfo, Stat> StatWeakMap;

	// Token: 0x0400054E RID: 1358
	[TupleElementNames(new string[]
	{
		"handle",
		"reason"
	})]
	[Nullable(new byte[]
	{
		1,
		0,
		1,
		2
	})]
	private readonly ConcurrentQueue<ValueTuple<TimerHandle, string>> PendingRemoveQueue;

	// Token: 0x0400054F RID: 1359
	private readonly FinalizationRegistry<Timer, TimerHandle> Registry;

	// Token: 0x04000550 RID: 1360
	[Nullable(2)]
	private readonly Action<TimerHandle, string> DisposeHandle_FinalizerThread;

	// Token: 0x020071C3 RID: 29123
	[CompilerGenerated]
	private static class <>O
	{
		// Token: 0x04027990 RID: 162192
		[Nullable(new byte[]
		{
			0,
			1
		})]
		public static Comparison<Timer> <0>__Compare;
	}
}
