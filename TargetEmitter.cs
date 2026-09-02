using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02002E3F RID: 11839
[NullableContext(1)]
[Nullable(0)]
public class TargetEmitter
{
	// Token: 0x0601844A RID: 99402 RVA: 0x006C803B File Offset: 0x006C623B
	public TargetEmitter(string name)
	{
		this.Name = name;
	}

	// Token: 0x0601844B RID: 99403 RVA: 0x006C8060 File Offset: 0x006C6260
	private void MarkEnum(long key)
	{
		if (!this.EnumMapping.ContainsKey(key))
		{
			Dictionary<long, string> enumMapping = this.EnumMapping;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted(this.Name);
			defaultInterpolatedStringHandler.AppendLiteral("_");
			defaultInterpolatedStringHandler.AppendFormatted<long>(key);
			enumMapping[key] = defaultInterpolatedStringHandler.ToStringAndClear();
		}
	}

	// Token: 0x0601844C RID: 99404 RVA: 0x006C80B8 File Offset: 0x006C62B8
	public void Add(object target, long key, Delegate callback)
	{
		this.MarkEnum(key);
		NumberEvent numberEvent;
		if (!this.Emitters.TryGetValue(target, out numberEvent))
		{
			numberEvent = new NumberEvent();
			this.Emitters.Set(target, numberEvent);
		}
		numberEvent.Add(key, callback);
	}

	// Token: 0x0601844D RID: 99405 RVA: 0x006C80F8 File Offset: 0x006C62F8
	public void Emit(object target, long key)
	{
		this.MarkEnum(key);
		NumberEvent numberEvent;
		if (this.Emitters.TryGetValue(target, out numberEvent))
		{
			if (numberEvent.IsEmitting(key))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Event;
				ELogAuthor author = ELogAuthor.TZQ;
				string message = "技能事件重复发送";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("name", this.EnumMapping[key]);
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			numberEvent.Emit(key);
		}
	}

	// Token: 0x0601844E RID: 99406 RVA: 0x006C8160 File Offset: 0x006C6360
	public void Emit<[Nullable(2)] T1>(object target, long key, T1 p1)
	{
		this.MarkEnum(key);
		NumberEvent numberEvent;
		if (this.Emitters.TryGetValue(target, out numberEvent))
		{
			if (numberEvent.IsEmitting(key))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Event;
				ELogAuthor author = ELogAuthor.TZQ;
				string message = "技能事件重复发送";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("name", this.EnumMapping[key]);
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			numberEvent.Emit<T1>(key, p1);
		}
	}

	// Token: 0x0601844F RID: 99407 RVA: 0x006C81CC File Offset: 0x006C63CC
	public void Emit<[Nullable(2)] T1, [Nullable(2)] T2>(object target, long key, T1 p1, T2 p2)
	{
		this.MarkEnum(key);
		NumberEvent numberEvent;
		if (this.Emitters.TryGetValue(target, out numberEvent))
		{
			if (numberEvent.IsEmitting(key))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Event;
				ELogAuthor author = ELogAuthor.TZQ;
				string message = "技能事件重复发送";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("name", this.EnumMapping[key]);
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			numberEvent.Emit<T1, T2>(key, p1, p2);
		}
	}

	// Token: 0x06018450 RID: 99408 RVA: 0x006C8238 File Offset: 0x006C6438
	public void Emit<[Nullable(2)] T1, [Nullable(2)] T2, [Nullable(2)] T3>(object target, long key, T1 p1, T2 p2, T3 p3)
	{
		this.MarkEnum(key);
		NumberEvent numberEvent;
		if (this.Emitters.TryGetValue(target, out numberEvent))
		{
			if (numberEvent.IsEmitting(key))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Event;
				ELogAuthor author = ELogAuthor.TZQ;
				string message = "技能事件重复发送";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("name", this.EnumMapping[key]);
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			numberEvent.Emit<T1, T2, T3>(key, p1, p2, p3);
		}
	}

	// Token: 0x06018451 RID: 99409 RVA: 0x006C82A8 File Offset: 0x006C64A8
	public void Emit<[Nullable(2)] T1, [Nullable(2)] T2, [Nullable(2)] T3, [Nullable(2)] T4>(object target, long key, T1 p1, T2 p2, T3 p3, T4 p4)
	{
		this.MarkEnum(key);
		NumberEvent numberEvent;
		if (this.Emitters.TryGetValue(target, out numberEvent))
		{
			if (numberEvent.IsEmitting(key))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Event;
				ELogAuthor author = ELogAuthor.TZQ;
				string message = "技能事件重复发送";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("name", this.EnumMapping[key]);
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			numberEvent.Emit<T1, T2, T3, T4>(key, p1, p2, p3, p4);
		}
	}

	// Token: 0x06018452 RID: 99410 RVA: 0x006C8318 File Offset: 0x006C6518
	public void Emit<[Nullable(2)] T1, [Nullable(2)] T2, [Nullable(2)] T3, [Nullable(2)] T4, [Nullable(2)] T5>(object target, long key, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5)
	{
		this.MarkEnum(key);
		NumberEvent numberEvent;
		if (this.Emitters.TryGetValue(target, out numberEvent))
		{
			if (numberEvent.IsEmitting(key))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Event;
				ELogAuthor author = ELogAuthor.TZQ;
				string message = "技能事件重复发送";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("name", this.EnumMapping[key]);
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			numberEvent.Emit<T1, T2, T3, T4, T5>(key, p1, p2, p3, p4, p5);
		}
	}

	// Token: 0x06018453 RID: 99411 RVA: 0x006C838C File Offset: 0x006C658C
	public void Remove(object target, long key, Delegate callback)
	{
		this.MarkEnum(key);
		NumberEvent numberEvent;
		if (this.Emitters.TryGetValue(target, out numberEvent))
		{
			numberEvent.Remove(key, callback);
		}
	}

	// Token: 0x0400BA9A RID: 47770
	protected readonly WeakMap<object, NumberEvent> Emitters = new WeakMap<object, NumberEvent>();

	// Token: 0x0400BA9B RID: 47771
	private readonly Dictionary<long, string> EnumMapping = new Dictionary<long, string>();

	// Token: 0x0400BA9C RID: 47772
	private readonly string Name;
}
