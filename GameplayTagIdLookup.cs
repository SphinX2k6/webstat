using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

// Token: 0x02000061 RID: 97
[NullableContext(1)]
[Nullable(0)]
public sealed class GameplayTagIdLookup : IReadOnlyDictionary<string, int>, IEnumerable<KeyValuePair<string, int>>, IEnumerable, IReadOnlyCollection<KeyValuePair<string, int>>
{
	// Token: 0x06000210 RID: 528 RVA: 0x0000C51C File Offset: 0x0000A71C
	public GameplayTagIdLookup(GameplayTagRuntimeTable table, bool allowOriginalNameRemap)
	{
	}

	// Token: 0x1700003B RID: 59
	public int this[string key]
	{
		get
		{
			int result;
			if (this.TryGetValue(key, out result))
			{
				return result;
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Game;
			ELogAuthor author = ELogAuthor.LRX;
			string message = "GameplayTag不存在，请检查GameplayTag设置";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("TagName", key);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return 0;
		}
	}

	// Token: 0x06000212 RID: 530 RVA: 0x0000C58C File Offset: 0x0000A78C
	public bool TryGetValue(string key, out int value)
	{
		if (this.NameToTagIdCache.TryGetValue(key, out value))
		{
			return true;
		}
		if (this.InvalidNames.Contains(key))
		{
			value = 0;
			return false;
		}
		if (this.<table>P.TryGetTagId(key, this.<allowOriginalNameRemap>P, out value))
		{
			this.NameToTagIdCache[key] = value;
			return true;
		}
		this.InvalidNames.Add(key);
		return false;
	}

	// Token: 0x06000213 RID: 531 RVA: 0x0000C5F0 File Offset: 0x0000A7F0
	public bool ContainsKey(string key)
	{
		int num;
		return this.TryGetValue(key, out num);
	}

	// Token: 0x1700003C RID: 60
	// (get) Token: 0x06000214 RID: 532 RVA: 0x0000C606 File Offset: 0x0000A806
	public int Count
	{
		get
		{
			return this.NameToTagIdCache.Count;
		}
	}

	// Token: 0x1700003D RID: 61
	// (get) Token: 0x06000215 RID: 533 RVA: 0x0000C614 File Offset: 0x0000A814
	public IEnumerable<int> Values
	{
		get
		{
			Singleton<Log>.Instance.Error(ELogModule.Game, ELogAuthor.LRX, "GameplayTagIdLookup按需构建，不支持遍历Values", default(ReadOnlySpan<ValueTuple<string, object>>));
			return Enumerable.Empty<int>();
		}
	}

	// Token: 0x1700003E RID: 62
	// (get) Token: 0x06000216 RID: 534 RVA: 0x0000C644 File Offset: 0x0000A844
	public IEnumerable<string> Keys
	{
		get
		{
			Singleton<Log>.Instance.Error(ELogModule.Game, ELogAuthor.LRX, "GameplayTagIdLookup不存储字符串key，不支持遍历Keys", default(ReadOnlySpan<ValueTuple<string, object>>));
			return Enumerable.Empty<string>();
		}
	}

	// Token: 0x06000217 RID: 535 RVA: 0x0000C674 File Offset: 0x0000A874
	[return: Nullable(new byte[]
	{
		1,
		0,
		1
	})]
	public IEnumerator<KeyValuePair<string, int>> GetEnumerator()
	{
		Singleton<Log>.Instance.Error(ELogModule.Game, ELogAuthor.LRX, "GameplayTagIdLookup不存储字符串key，不支持遍历", default(ReadOnlySpan<ValueTuple<string, object>>));
		return Enumerable.Empty<KeyValuePair<string, int>>().GetEnumerator();
	}

	// Token: 0x06000218 RID: 536 RVA: 0x0000C6A7 File Offset: 0x0000A8A7
	IEnumerator IEnumerable.GetEnumerator()
	{
		return this.GetEnumerator();
	}

	// Token: 0x040001BE RID: 446
	[CompilerGenerated]
	private GameplayTagRuntimeTable <table>P = table;

	// Token: 0x040001BF RID: 447
	[CompilerGenerated]
	private bool <allowOriginalNameRemap>P = allowOriginalNameRemap;

	// Token: 0x040001C0 RID: 448
	private readonly Dictionary<string, int> NameToTagIdCache = new Dictionary<string, int>();

	// Token: 0x040001C1 RID: 449
	private readonly HashSet<string> InvalidNames = new HashSet<string>();
}
