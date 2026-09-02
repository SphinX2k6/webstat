using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02000079 RID: 121
[NullableContext(1)]
[Nullable(0)]
public class TrimLru<[Nullable(2)] TK, TV> where TV : class
{
	// Token: 0x060002E0 RID: 736 RVA: 0x0000FA40 File Offset: 0x0000DC40
	public TrimLru(int capacity, bool allowEmpty = false)
	{
		this.AllowEmpty = allowEmpty;
		if (capacity < 2)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Core;
			ELogAuthor author = ELogAuthor.LCC;
			string message = "容量必须大于 1";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("capacity", capacity);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		this.CapacityInternal = capacity;
		this.DecayRate = 1f - 1f / (float)capacity;
	}

	// Token: 0x17000061 RID: 97
	// (get) Token: 0x060002E1 RID: 737 RVA: 0x0000FAB6 File Offset: 0x0000DCB6
	// (set) Token: 0x060002E2 RID: 738 RVA: 0x0000FABE File Offset: 0x0000DCBE
	public bool Enable
	{
		get
		{
			return this.EnableInternal;
		}
		set
		{
			if (this.EnableInternal != value)
			{
				this.Clear();
			}
			this.EnableInternal = value;
		}
	}

	// Token: 0x17000062 RID: 98
	// (get) Token: 0x060002E3 RID: 739 RVA: 0x0000FAD6 File Offset: 0x0000DCD6
	public int Size
	{
		get
		{
			return this.SizeInternal;
		}
	}

	// Token: 0x17000063 RID: 99
	// (get) Token: 0x060002E4 RID: 740 RVA: 0x0000FADE File Offset: 0x0000DCDE
	// (set) Token: 0x060002E5 RID: 741 RVA: 0x0000FAE8 File Offset: 0x0000DCE8
	public int Capacity
	{
		get
		{
			return this.CapacityInternal;
		}
		set
		{
			if (value < 2)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Core;
				ELogAuthor author = ELogAuthor.LCC;
				string message = "容量必须大于 1";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("capacity", value);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			this.DecayRate = 1f - 1f / (float)value;
			this.HitCount = this.HitCount / (float)this.CapacityInternal * (float)value;
			this.MissCount = this.MissCount / (float)this.CapacityInternal * (float)value;
			this.CapacityInternal = value;
			while (this.SizeInternal > value)
			{
				this.RemoveTail();
			}
		}
	}

	// Token: 0x17000064 RID: 100
	// (get) Token: 0x060002E6 RID: 742 RVA: 0x0000FB7E File Offset: 0x0000DD7E
	public float HitRate
	{
		get
		{
			if (this.HitCount <= 0f)
			{
				return 0f;
			}
			return this.HitCount / (this.HitCount + this.MissCount);
		}
	}

	// Token: 0x17000065 RID: 101
	// (get) Token: 0x060002E7 RID: 743 RVA: 0x0000FBA7 File Offset: 0x0000DDA7
	public float UsedAvg
	{
		get
		{
			if (this.SizeInternal <= 0)
			{
				return 0f;
			}
			return (float)this.UsedCount / (float)this.SizeInternal;
		}
	}

	// Token: 0x17000066 RID: 102
	// (get) Token: 0x060002E8 RID: 744 RVA: 0x0000FBC7 File Offset: 0x0000DDC7
	public float ThresholdUsedRate
	{
		get
		{
			if (this.SizeInternal <= 0)
			{
				return 0f;
			}
			return (float)this.ThresholdUsedCount / (float)this.SizeInternal;
		}
	}

	// Token: 0x060002E9 RID: 745 RVA: 0x0000FBE8 File Offset: 0x0000DDE8
	[return: Nullable(2)]
	public TV Get(TK key)
	{
		if (!this.EnableInternal)
		{
			return default(TV);
		}
		TrimLruNode<TK, TV> trimLruNode;
		if (!this.Table.TryGetValue(key, out trimLruNode))
		{
			this.HitCount *= this.DecayRate;
			this.MissCount = this.MissCount * this.DecayRate + 1f;
			return default(TV);
		}
		this.RemoveNode(trimLruNode);
		trimLruNode.Count++;
		this.AddToFront(trimLruNode);
		this.HitCount = this.HitCount * this.DecayRate + (float)trimLruNode.Size;
		this.MissCount *= this.DecayRate;
		return trimLruNode.Value;
	}

	// Token: 0x060002EA RID: 746 RVA: 0x0000FCA0 File Offset: 0x0000DEA0
	public bool Put(TK key, TV value, int size = 1)
	{
		if (key == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Core;
			ELogAuthor author = ELogAuthor.LCC;
			string message = "无效键";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("key", key);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return false;
		}
		if (this.Table.ContainsKey(key))
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Core;
			ELogAuthor author2 = ELogAuthor.LCC;
			string message2 = "键已存在";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("key", key);
			instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			return false;
		}
		if (!this.AllowEmpty && value == null)
		{
			Log instance3 = Singleton<Log>.Instance;
			ELogModule module3 = ELogModule.Core;
			ELogAuthor author3 = ELogAuthor.LCC;
			string message3 = "无效对象";
			ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("value", value);
			instance3.Error(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
			return false;
		}
		if (!this.EnableInternal)
		{
			return false;
		}
		TrimLruNode<TK, TV> trimLruNode = new TrimLruNode<TK, TV>(key, value, size);
		this.Table[key] = trimLruNode;
		this.AddToFront(trimLruNode);
		while (this.SizeInternal > this.CapacityInternal)
		{
			this.RemoveTail();
		}
		return true;
	}

	// Token: 0x060002EB RID: 747 RVA: 0x0000FD98 File Offset: 0x0000DF98
	public void Clear()
	{
		while (this.SizeInternal > 0)
		{
			this.RemoveTail();
		}
		this.Table.Clear();
		this.Head = null;
		this.Tail = null;
		this.HitCount = 0f;
		this.MissCount = 0f;
	}

	// Token: 0x060002EC RID: 748 RVA: 0x0000FDE8 File Offset: 0x0000DFE8
	private void AddToFront(TrimLruNode<TK, TV> node)
	{
		node.Prev = null;
		node.Next = this.Head;
		if (this.Head != null)
		{
			this.Head.Prev = node;
		}
		else
		{
			this.Tail = node;
		}
		this.Head = node;
		this.SizeInternal += node.Size;
		this.UsedCount += node.Count * node.Size;
		if (node.Count >= 3)
		{
			this.ThresholdUsedCount += node.Count * node.Size;
		}
	}

	// Token: 0x060002ED RID: 749 RVA: 0x0000FE7C File Offset: 0x0000E07C
	private void RemoveNode(TrimLruNode<TK, TV> node)
	{
		if (node.Prev != null)
		{
			node.Prev.Next = node.Next;
		}
		else
		{
			this.Head = node.Next;
		}
		if (node.Next != null)
		{
			node.Next.Prev = node.Prev;
		}
		else
		{
			this.Tail = node.Prev;
		}
		node.Prev = null;
		node.Next = null;
		this.SizeInternal -= node.Size;
		this.UsedCount -= node.Count * node.Size;
		if (node.Count >= 3)
		{
			this.ThresholdUsedCount -= node.Count * node.Size;
		}
	}

	// Token: 0x060002EE RID: 750 RVA: 0x0000FF38 File Offset: 0x0000E138
	private void RemoveTail()
	{
		if (this.Tail == null)
		{
			return;
		}
		TrimLruNode<TK, TV> tail = this.Tail;
		this.RemoveNode(tail);
		tail.Count = 0;
		this.Table.Remove(tail.Key);
	}

	// Token: 0x0400020F RID: 527
	private const int USED_THRESHOLD = 3;

	// Token: 0x04000210 RID: 528
	private bool EnableInternal = true;

	// Token: 0x04000211 RID: 529
	private int CapacityInternal;

	// Token: 0x04000212 RID: 530
	private float DecayRate;

	// Token: 0x04000213 RID: 531
	private readonly Dictionary<TK, TrimLruNode<TK, TV>> Table = new Dictionary<TK, TrimLruNode<TK, TV>>();

	// Token: 0x04000214 RID: 532
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private TrimLruNode<TK, TV> Head;

	// Token: 0x04000215 RID: 533
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private TrimLruNode<TK, TV> Tail;

	// Token: 0x04000216 RID: 534
	private int SizeInternal;

	// Token: 0x04000217 RID: 535
	private float HitCount;

	// Token: 0x04000218 RID: 536
	private float MissCount;

	// Token: 0x04000219 RID: 537
	private int UsedCount;

	// Token: 0x0400021A RID: 538
	private int ThresholdUsedCount;

	// Token: 0x0400021B RID: 539
	private readonly bool AllowEmpty;
}
