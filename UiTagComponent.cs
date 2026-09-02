using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02002C61 RID: 11361
[NullableContext(1)]
[Nullable(0)]
public class UiTagComponent
{
	// Token: 0x06016CD2 RID: 93394 RVA: 0x00652E3C File Offset: 0x0065103C
	public void AddTagById(int tagId, params object[] args)
	{
		if (tagId == 0)
		{
			return;
		}
		int num = 0;
		if (this.TagMap.ContainsKey(tagId))
		{
			num = this.TagMap[tagId];
		}
		this.TagMap[tagId] = num + 1;
		this.DispatchEvent(tagId, num, num + 1, args);
	}

	// Token: 0x06016CD3 RID: 93395 RVA: 0x00652E88 File Offset: 0x00651088
	public void ReduceTagById(int tagId, params object[] args)
	{
		if (tagId == 0)
		{
			return;
		}
		if (!this.TagMap.ContainsKey(tagId))
		{
			return;
		}
		int num = this.TagMap[tagId];
		if (num == 0)
		{
			return;
		}
		if (num == 1)
		{
			this.TagMap.Remove(tagId);
		}
		else
		{
			this.TagMap[tagId] = num - 1;
		}
		this.DispatchEvent(tagId, num, num - 1, args);
	}

	// Token: 0x06016CD4 RID: 93396 RVA: 0x00652EE8 File Offset: 0x006510E8
	public void RemoveTagById(int tagId, params object[] args)
	{
		if (tagId == 0)
		{
			return;
		}
		if (!this.TagMap.ContainsKey(tagId))
		{
			return;
		}
		int oldCount = this.TagMap[tagId];
		this.TagMap.Remove(tagId);
		this.DispatchEvent(tagId, oldCount, 0, args);
	}

	// Token: 0x06016CD5 RID: 93397 RVA: 0x00652F2C File Offset: 0x0065112C
	public bool ContainsTagById(int tagId)
	{
		return this.TagMap.ContainsKey(tagId);
	}

	// Token: 0x06016CD6 RID: 93398 RVA: 0x00652F3C File Offset: 0x0065113C
	public bool ContainsTagByName(string tagName)
	{
		int? num = new int?(GameplayTagUtils.GetTagIdByName(tagName));
		return num != null && this.ContainsTagById(num.Value);
	}

	// Token: 0x06016CD7 RID: 93399 RVA: 0x00652F6E File Offset: 0x0065116E
	public int GetTagCountById(int tagId)
	{
		if (tagId == 0)
		{
			return 0;
		}
		if (!this.TagMap.ContainsKey(tagId))
		{
			return 0;
		}
		return this.TagMap[tagId];
	}

	// Token: 0x06016CD8 RID: 93400 RVA: 0x00652F94 File Offset: 0x00651194
	private void DispatchEvent(int tagId, int oldCount, int newCount, params object[] args)
	{
		if (tagId == 0)
		{
			return;
		}
		if (oldCount == newCount)
		{
			return;
		}
		bool flag = oldCount == 0 != (newCount == 0);
		bool tagExist = newCount > 0;
		if (flag && this.TagSwitchedCallbacks.ContainsKey(tagId))
		{
			this.Emit(tagId, tagExist, this.TagSwitchedCallbacks[tagId], args);
		}
	}

	// Token: 0x06016CD9 RID: 93401 RVA: 0x00652FE4 File Offset: 0x006511E4
	private unsafe void Emit(int tagId, bool tagExist, IEnumerable<TTagSwitchedCallback> callbacks, params object[] args)
	{
		if (tagId == 0 || callbacks == null)
		{
			return;
		}
		string nameByTagId = GameplayTagUtils.GetNameByTagId(tagId);
		foreach (TTagSwitchedCallback ttagSwitchedCallback in new List<TTagSwitchedCallback>(callbacks))
		{
			try
			{
				ttagSwitchedCallback(tagId, tagExist, args);
			}
			catch (Exception ex)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Event;
				ELogAuthor author = ELogAuthor.LZK;
				string message = "tag事件回调执行异常";
				Exception error = ex;
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("tag", nameByTagId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("error", ex.Message);
				instance.ErrorWithStack(module, author, message, error, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			}
		}
	}

	// Token: 0x06016CDA RID: 93402 RVA: 0x006530B8 File Offset: 0x006512B8
	public void AddListener(int tagId, TTagSwitchedCallback callback)
	{
		if (!this.TagSwitchedCallbacks.ContainsKey(tagId))
		{
			this.TagSwitchedCallbacks[tagId] = new HashSet<TTagSwitchedCallback>();
		}
		this.TagSwitchedCallbacks[tagId].Add(callback);
	}

	// Token: 0x06016CDB RID: 93403 RVA: 0x006530EC File Offset: 0x006512EC
	public void RemoveListener(int tagId, TTagSwitchedCallback callback)
	{
		if (!this.TagSwitchedCallbacks.ContainsKey(tagId))
		{
			return;
		}
		this.TagSwitchedCallbacks[tagId].Remove(callback);
	}

	// Token: 0x06016CDC RID: 93404 RVA: 0x00653110 File Offset: 0x00651310
	public void RemoveAllTag()
	{
		foreach (int tagId in new List<int>(this.TagMap.Keys))
		{
			this.RemoveTagById(tagId, Array.Empty<object>());
		}
	}

	// Token: 0x0400AFA5 RID: 44965
	private readonly Dictionary<int, int> TagMap = new Dictionary<int, int>();

	// Token: 0x0400AFA6 RID: 44966
	private readonly Dictionary<int, HashSet<TTagSwitchedCallback>> TagSwitchedCallbacks = new Dictionary<int, HashSet<TTagSwitchedCallback>>();
}
