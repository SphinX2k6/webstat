using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02000062 RID: 98
[NullableContext(1)]
[Nullable(0)]
public sealed class GameplayTagRuntimeTable
{
	// Token: 0x1700003F RID: 63
	// (get) Token: 0x06000219 RID: 537 RVA: 0x0000C6AF File Offset: 0x0000A8AF
	public IReadOnlyDictionary<int, int> TagId2UglyTagIdMap
	{
		get
		{
			return this.TagId2UglyTagIdMapInternal;
		}
	}

	// Token: 0x0600021A RID: 538 RVA: 0x0000C6B7 File Offset: 0x0000A8B7
	public GameplayTagRuntimeTable()
	{
		this.EUglyGameplayTagId = new GameplayTagIdLookup(this, false);
		this.EGameplayTagId = new GameplayTagIdLookup(this, true);
		this.ParentTagIdMap = new GameplayTagRuntimeTable.ParentTagIdView();
	}

	// Token: 0x0600021B RID: 539 RVA: 0x0000C6F0 File Offset: 0x0000A8F0
	public bool TryGetTagId(string tagName, bool allowOriginalNameRemap, out int tagId)
	{
		tagId = UGASBPLibrary.FnvHash(tagName);
		int num;
		if (allowOriginalNameRemap && GameplayTagDefine.TryRemapTagId(tagId, out num))
		{
			this.TagId2UglyTagIdMapInternal[tagId] = num;
			tagId = num;
			return true;
		}
		int num2;
		return GameplayTagDefine.TryGetParentTagId(tagId, out num2) || GameplayTagDefine.IsRootTagId(tagId);
	}

	// Token: 0x040001C2 RID: 450
	private readonly Dictionary<int, int> TagId2UglyTagIdMapInternal = new Dictionary<int, int>();

	// Token: 0x040001C3 RID: 451
	public readonly IReadOnlyDictionary<string, int> EUglyGameplayTagId;

	// Token: 0x040001C4 RID: 452
	public readonly IReadOnlyDictionary<string, int> EGameplayTagId;

	// Token: 0x040001C5 RID: 453
	public readonly IReadOnlyDictionary<int, int> ParentTagIdMap;

	// Token: 0x02007187 RID: 29063
	[NullableContext(0)]
	private sealed class ParentTagIdView : IReadOnlyDictionary<int, int>, IEnumerable<KeyValuePair<int, int>>, IEnumerable, IReadOnlyCollection<KeyValuePair<int, int>>
	{
		// Token: 0x1700A764 RID: 42852
		public int this[int key]
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
				string message = "GameplayTag不存在父tag或id不合法";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("TagId", key);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return 0;
			}
		}

		// Token: 0x06046782 RID: 288642 RVA: 0x012ACBFB File Offset: 0x012AADFB
		public bool TryGetValue(int key, out int value)
		{
			return GameplayTagDefine.TryGetParentTagId(key, out value);
		}

		// Token: 0x06046783 RID: 288643 RVA: 0x012ACC04 File Offset: 0x012AAE04
		public bool ContainsKey(int key)
		{
			int num;
			return this.TryGetValue(key, out num);
		}

		// Token: 0x1700A765 RID: 42853
		// (get) Token: 0x06046784 RID: 288644 RVA: 0x012ACC1A File Offset: 0x012AAE1A
		public int Count
		{
			get
			{
				return 13920;
			}
		}

		// Token: 0x1700A766 RID: 42854
		// (get) Token: 0x06046785 RID: 288645 RVA: 0x012ACC24 File Offset: 0x012AAE24
		[Nullable(1)]
		public IEnumerable<int> Keys
		{
			[NullableContext(1)]
			get
			{
				Singleton<Log>.Instance.Error(ELogModule.Game, ELogAuthor.LRX, "ParentTagIdMap为生成查询表，不支持遍历Keys", default(ReadOnlySpan<ValueTuple<string, object>>));
				return Enumerable.Empty<int>();
			}
		}

		// Token: 0x1700A767 RID: 42855
		// (get) Token: 0x06046786 RID: 288646 RVA: 0x012ACC54 File Offset: 0x012AAE54
		[Nullable(1)]
		public IEnumerable<int> Values
		{
			[NullableContext(1)]
			get
			{
				Singleton<Log>.Instance.Error(ELogModule.Game, ELogAuthor.LRX, "ParentTagIdMap为生成查询表，不支持遍历Values", default(ReadOnlySpan<ValueTuple<string, object>>));
				return Enumerable.Empty<int>();
			}
		}

		// Token: 0x06046787 RID: 288647 RVA: 0x012ACC84 File Offset: 0x012AAE84
		[return: Nullable(new byte[]
		{
			1,
			0
		})]
		public IEnumerator<KeyValuePair<int, int>> GetEnumerator()
		{
			Singleton<Log>.Instance.Error(ELogModule.Game, ELogAuthor.LRX, "ParentTagIdMap为生成查询表，不支持遍历", default(ReadOnlySpan<ValueTuple<string, object>>));
			return Enumerable.Empty<KeyValuePair<int, int>>().GetEnumerator();
		}

		// Token: 0x06046788 RID: 288648 RVA: 0x012ACCB7 File Offset: 0x012AAEB7
		[NullableContext(1)]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}
	}
}
