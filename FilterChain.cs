using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;

// Token: 0x02003453 RID: 13395
[NullableContext(1)]
[Nullable(0)]
public class FilterChain<[Nullable(2)] T>
{
	// Token: 0x0601C179 RID: 115065 RVA: 0x008616AC File Offset: 0x0085F8AC
	protected FilterChain()
	{
	}

	// Token: 0x0601C17A RID: 115066 RVA: 0x00861720 File Offset: 0x0085F920
	protected void Init()
	{
		foreach (EFilterType key in FilterTypeHelper.FilterTypePriority)
		{
			this.AllTypeFilters[key] = new HashSet<Filter<T>>();
		}
		Singleton<EventSystem>.Instance.Add<object>(EEventName.FilterCriteriaChanged, new Action<object>(this.OnFilterCriteriaChanged));
		FilterTypeHelper.TryCatchWrapper<bool>(new Func<bool>(this.OnInit), "[FilterChain] OnInit执行出错", base.GetType().Name);
	}

	// Token: 0x0601C17B RID: 115067 RVA: 0x00861795 File Offset: 0x0085F995
	protected virtual bool OnInit()
	{
		return true;
	}

	// Token: 0x0601C17C RID: 115068 RVA: 0x00861798 File Offset: 0x0085F998
	public void Cleanup()
	{
		foreach (HashSet<Filter<T>> hashSet in this.AllTypeFilters.Values)
		{
			foreach (Filter<T> filter in hashSet)
			{
				filter.Cleanup();
			}
			hashSet.Clear();
		}
		this.AllTypeFilters.Clear();
		this.TargetsWithFilter.Clear();
		this.FilterHoldTargets.Clear();
		this.TargetsPassed.Clear();
		Singleton<EventSystem>.Instance.Remove<object>(EEventName.FilterCriteriaChanged, new Action<object>(this.OnFilterCriteriaChanged));
		FilterTypeHelper.TryCatchWrapper<bool>(new Func<bool>(this.OnCleanup), "[FilterChain] OnCleanup执行出错", base.GetType().Name);
	}

	// Token: 0x0601C17D RID: 115069 RVA: 0x00861894 File Offset: 0x0085FA94
	protected virtual bool OnCleanup()
	{
		return true;
	}

	// Token: 0x0601C17E RID: 115070 RVA: 0x00861898 File Offset: 0x0085FA98
	public virtual void AddFilter(Filter<T> filter)
	{
		if (this.FilterHoldTargets.ContainsKey(filter))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.FilterWithState;
			ELogAuthor author = ELogAuthor.XDW;
			string message = "FilterChain中已经有了这个Filter，不需要重复添加";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Filter", filter);
			instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		this.AllTypeFilters[filter.FilterType].Add(filter);
		this.FilterHoldTargets[filter] = new HashSet<T>();
		for (int i = (int)(filter.FilterType + 1); i < FilterTypeHelper.FilterTypePriority.Length; i++)
		{
			foreach (Filter<T> key in this.AllTypeFilters[FilterTypeHelper.FilterTypePriority[i]])
			{
				HashSet<T> hashSet = this.FilterHoldTargets[key];
				foreach (T t in hashSet.ToList<T>())
				{
					bool flag = filter.ExecuteCriteria(t);
					if (flag == FilterTypeHelper.FilterResult[filter.FilterType])
					{
						hashSet.Remove(t);
						this.TargetsWithFilter[t] = filter;
						this.FilterHoldTargets[filter].Add(t);
						this.TryModifyPassedTarget(t, flag);
					}
				}
			}
		}
	}

	// Token: 0x0601C17F RID: 115071 RVA: 0x00861A18 File Offset: 0x0085FC18
	public unsafe virtual bool RemoveFilter(Filter<T> filter)
	{
		if (!this.AllTypeFilters[filter.FilterType].Remove(filter))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.FilterWithState;
			ELogAuthor author = ELogAuthor.XDW;
			string message = "RemoveFilter失败";
			<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Filter", filter);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("FilterType", filter.FilterType);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("AllTypeFilters", this.AllTypeFilters);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("FilterChain", this);
			instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
			return false;
		}
		IEnumerable<T> source = this.FilterHoldTargets[filter];
		this.FilterHoldTargets.Remove(filter);
		foreach (T t in source.ToList<T>())
		{
			if (FilterTypeHelper.FilterResult[filter.FilterType])
			{
				this.TryModifyPassedTarget(t, false);
			}
			this.TargetsWithFilter.Remove(t);
			this.AddTarget(t, filter.FilterType);
		}
		return true;
	}

	// Token: 0x0601C180 RID: 115072 RVA: 0x00861B68 File Offset: 0x0085FD68
	public unsafe bool AddTarget(T target, EFilterType priority = EFilterType.Top)
	{
		bool flag = true;
		for (int i = (int)priority; i < FilterTypeHelper.FilterTypePriority.Length; i++)
		{
			foreach (Filter<T> filter in this.AllTypeFilters[FilterTypeHelper.FilterTypePriority[i]])
			{
				flag = filter.ExecuteCriteria(target);
				if (flag == FilterTypeHelper.FilterResult[filter.FilterType])
				{
					this.TargetsWithFilter[target] = filter;
					this.FilterHoldTargets[filter].Add(target);
				}
			}
			if (this.TargetsWithFilter.ContainsKey(target))
			{
				break;
			}
		}
		if (!flag)
		{
			if (ModelBase<CreatureModel>.Instance.EnableEntityLog)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.FilterWithState;
				ELogAuthor author = ELogAuthor.XDW;
				string message = "FilterChain中的某个Normal Filter没有通过target筛选";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Filter", this.TargetsWithFilter.GetValueOrDefault(target));
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Target", target);
				instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			}
			return false;
		}
		this.TryModifyPassedTarget(target, true);
		return true;
	}

	// Token: 0x0601C181 RID: 115073 RVA: 0x00861CAC File Offset: 0x0085FEAC
	public Filter<T>[] GetAllFilters()
	{
		return this.AllTypeFilters.Values.SelectMany((HashSet<Filter<T>> filters) => filters).ToArray<Filter<T>>();
	}

	// Token: 0x0601C182 RID: 115074 RVA: 0x00861CE4 File Offset: 0x0085FEE4
	public unsafe bool RemoveTarget(T target)
	{
		bool flag = false;
		Filter<T> filter;
		if (this.TargetsWithFilter.TryGetValue(target, out filter))
		{
			if (!this.FilterHoldTargets[filter].Remove(target))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.FilterWithState;
				ELogAuthor author = ELogAuthor.XDW;
				string message = "[FilterChain] RemoveTarget，FilterHoldTargets和TargetsWithFilter不匹配";
				<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Filter", filter);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Target", target);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("TargetsPassed", this.TargetsPassed);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("TargetsWithFilter", this.TargetsWithFilter);
				instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
			}
			flag = (flag || this.TargetsWithFilter.Remove(target));
		}
		flag = (flag || this.TryModifyPassedTarget(target, false));
		if (flag)
		{
			return true;
		}
		Log instance2 = Singleton<Log>.Instance;
		ELogModule module2 = ELogModule.FilterWithState;
		ELogAuthor author2 = ELogAuthor.XDW;
		string message2 = "[FilterChain] RemoveTarget失败，没有这个Target";
		<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray3<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("Target", target);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("TargetsPassed", this.TargetsPassed);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("TargetsWithFilter", this.TargetsWithFilter);
		instance2.Warn(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 3));
		return false;
	}

	// Token: 0x0601C183 RID: 115075 RVA: 0x00861E57 File Offset: 0x00860057
	protected virtual void OnPassedTargetModified(T target, bool isAdd)
	{
	}

	// Token: 0x0601C184 RID: 115076 RVA: 0x00861E5C File Offset: 0x0086005C
	private void OnFilterCriteriaChanged(object filterUnknown)
	{
		Filter<T> filter = filterUnknown as Filter<T>;
		if (filter == null)
		{
			return;
		}
		IEnumerable<T> source = this.FilterHoldTargets[filter];
		this.FilterHoldTargets[filter] = new HashSet<T>();
		foreach (T t in source.ToList<T>())
		{
			this.TargetsWithFilter.Remove(t);
			this.AddTarget(t, filter.FilterType);
		}
	}

	// Token: 0x0601C185 RID: 115077 RVA: 0x00861EEC File Offset: 0x008600EC
	private bool TryModifyPassedTarget(T target, bool isAdd)
	{
		if (isAdd)
		{
			if (!this.TargetsPassed.Contains(target))
			{
				this.TargetsPassed.Add(target);
				this.OnPassedTargetModified(target, true);
				return true;
			}
		}
		else if (this.TargetsPassed.Remove(target))
		{
			this.OnPassedTargetModified(target, false);
			return true;
		}
		return false;
	}

	// Token: 0x0400E2E4 RID: 58084
	protected readonly Dictionary<EFilterType, HashSet<Filter<T>>> AllTypeFilters = new Dictionary<EFilterType, HashSet<Filter<T>>>();

	// Token: 0x0400E2E5 RID: 58085
	private readonly Dictionary<T, Filter<T>> TargetsWithFilter = new Dictionary<T, Filter<T>>();

	// Token: 0x0400E2E6 RID: 58086
	private readonly Dictionary<Filter<T>, HashSet<T>> FilterHoldTargets = new Dictionary<Filter<T>, HashSet<T>>();

	// Token: 0x0400E2E7 RID: 58087
	private readonly HashSet<T> TargetsPassed = new HashSet<T>();

	// Token: 0x0400E2E8 RID: 58088
	private readonly Stat AddTargetStat = Stat.Create("FilterChain.AddTarget", "", "");

	// Token: 0x0400E2E9 RID: 58089
	private readonly Stat AddFilterStat = Stat.Create("FilterChain.AddFilter", "", "");
}
