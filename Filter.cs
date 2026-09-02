using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;

// Token: 0x02003452 RID: 13394
[NullableContext(1)]
[Nullable(0)]
public abstract class Filter<[Nullable(2)] T>
{
	// Token: 0x17002649 RID: 9801
	// (get) Token: 0x0601C16C RID: 115052 RVA: 0x0086151B File Offset: 0x0085F71B
	// (set) Token: 0x0601C16D RID: 115053 RVA: 0x00861523 File Offset: 0x0085F723
	protected virtual Func<T, bool> TargetCriteriaInternal { get; set; }

	// Token: 0x1700264A RID: 9802
	// (get) Token: 0x0601C16E RID: 115054
	public abstract string DebugName { get; }

	// Token: 0x1700264B RID: 9803
	// (get) Token: 0x0601C16F RID: 115055 RVA: 0x0086152C File Offset: 0x0085F72C
	// (set) Token: 0x0601C170 RID: 115056 RVA: 0x00861534 File Offset: 0x0085F734
	public virtual EFilterType FilterType { get; set; }

	// Token: 0x1700264C RID: 9804
	// (get) Token: 0x0601C171 RID: 115057 RVA: 0x0086153D File Offset: 0x0085F73D
	// (set) Token: 0x0601C172 RID: 115058 RVA: 0x00861545 File Offset: 0x0085F745
	public Func<T, bool> Criteria
	{
		get
		{
			return this.TargetCriteriaInternal;
		}
		set
		{
			this.TargetCriteriaInternal = value;
			Singleton<EventSystem>.Instance.Emit<object>(EEventName.FilterCriteriaChanged, this);
		}
	}

	// Token: 0x0601C173 RID: 115059 RVA: 0x0086155F File Offset: 0x0085F75F
	protected Filter()
	{
		Func<T, bool> targetCriteriaInternal;
		if ((targetCriteriaInternal = Filter<T>.<>O.<0>__AlwaysTrueCriteria) == null)
		{
			targetCriteriaInternal = (Filter<T>.<>O.<0>__AlwaysTrueCriteria = new Func<T, bool>(CriteriaDefine.AlwaysTrueCriteria<T>));
		}
		this.TargetCriteriaInternal = targetCriteriaInternal;
		this.FilterType = EFilterType.Black;
		base..ctor();
	}

	// Token: 0x0601C174 RID: 115060 RVA: 0x0086158F File Offset: 0x0085F78F
	public virtual void Init()
	{
		FilterTypeHelper.TryCatchWrapper<bool>(new Func<bool>(this.OnInit), "[Filter] OnInit执行出错", base.GetType().Name);
	}

	// Token: 0x0601C175 RID: 115061 RVA: 0x008615B4 File Offset: 0x0085F7B4
	protected virtual bool OnInit()
	{
		return true;
	}

	// Token: 0x0601C176 RID: 115062 RVA: 0x008615B7 File Offset: 0x0085F7B7
	public virtual void Cleanup()
	{
		FilterTypeHelper.TryCatchWrapper<bool>(new Func<bool>(this.OnCleanup), "[Filter] OnCleanup执行出错", base.GetType().Name);
	}

	// Token: 0x0601C177 RID: 115063 RVA: 0x008615DC File Offset: 0x0085F7DC
	protected virtual bool OnCleanup()
	{
		return true;
	}

	// Token: 0x0601C178 RID: 115064 RVA: 0x008615E0 File Offset: 0x0085F7E0
	public unsafe bool ExecuteCriteria(T target)
	{
		try
		{
			return this.TargetCriteriaInternal(target);
		}
		catch (Exception ex)
		{
			if (ex != null)
			{
				Exception ex2 = ex;
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.FilterWithState;
				ELogAuthor author = ELogAuthor.XDW;
				string message = "业务层执行过滤器的判定标准的时候异常";
				Exception error = ex2;
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("target", target);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("error", ex2);
				instance.ErrorWithStack(module, author, message, error, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			}
			else
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.FilterWithState;
				ELogAuthor author2 = ELogAuthor.XDW;
				string message2 = "业务层执行过滤器的判定标准的时候异常, 并且捕获的不是Error";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("target", target);
				instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
		}
		return false;
	}

	// Token: 0x02009544 RID: 38212
	[CompilerGenerated]
	private static class <>O
	{
		// Token: 0x040315EC RID: 202220
		[Nullable(new byte[]
		{
			0,
			1
		})]
		public static Func<T, bool> <0>__AlwaysTrueCriteria;
	}
}
