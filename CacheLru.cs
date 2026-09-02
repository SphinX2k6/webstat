using System;
using System.Runtime.CompilerServices;

// Token: 0x0200005A RID: 90
[NullableContext(1)]
[Nullable(0)]
public class CacheLru<TK, TV> where TV : class
{
	// Token: 0x060001DD RID: 477 RVA: 0x0000B4A8 File Offset: 0x000096A8
	public CacheLru(int capacity, [Nullable(new byte[]
	{
		1,
		1,
		2
	})] Func<TK, TV> creator)
	{
		this.Lru = new TrimLru<TK, TV>(capacity, false);
		this.Creator = creator;
	}

	// Token: 0x17000030 RID: 48
	// (get) Token: 0x060001DE RID: 478 RVA: 0x0000B4C4 File Offset: 0x000096C4
	// (set) Token: 0x060001DF RID: 479 RVA: 0x0000B4D1 File Offset: 0x000096D1
	public bool Enable
	{
		get
		{
			return this.Lru.Enable;
		}
		set
		{
			this.Lru.Enable = value;
		}
	}

	// Token: 0x17000031 RID: 49
	// (get) Token: 0x060001E0 RID: 480 RVA: 0x0000B4DF File Offset: 0x000096DF
	public int Size
	{
		get
		{
			return this.Lru.Size;
		}
	}

	// Token: 0x17000032 RID: 50
	// (get) Token: 0x060001E1 RID: 481 RVA: 0x0000B4EC File Offset: 0x000096EC
	// (set) Token: 0x060001E2 RID: 482 RVA: 0x0000B4F9 File Offset: 0x000096F9
	public int Capacity
	{
		get
		{
			return this.Lru.Capacity;
		}
		set
		{
			this.Lru.Capacity = value;
		}
	}

	// Token: 0x17000033 RID: 51
	// (get) Token: 0x060001E3 RID: 483 RVA: 0x0000B507 File Offset: 0x00009707
	public float HitRate
	{
		get
		{
			return this.Lru.HitRate;
		}
	}

	// Token: 0x17000034 RID: 52
	// (get) Token: 0x060001E4 RID: 484 RVA: 0x0000B514 File Offset: 0x00009714
	public float UsedAvg
	{
		get
		{
			return this.Lru.UsedAvg;
		}
	}

	// Token: 0x17000035 RID: 53
	// (get) Token: 0x060001E5 RID: 485 RVA: 0x0000B521 File Offset: 0x00009721
	public float ThresholdUsedRate
	{
		get
		{
			return this.Lru.ThresholdUsedRate;
		}
	}

	// Token: 0x060001E6 RID: 486 RVA: 0x0000B530 File Offset: 0x00009730
	[return: Nullable(2)]
	public TV Get(TK key)
	{
		TV tv = this.Lru.Get(key);
		if (tv != null)
		{
			return tv;
		}
		tv = this.Creator(key);
		if (tv == null)
		{
			return default(TV);
		}
		this.Lru.Put(key, tv, 1);
		return tv;
	}

	// Token: 0x060001E7 RID: 487 RVA: 0x0000B583 File Offset: 0x00009783
	public void Clear()
	{
		this.Lru.Clear();
	}

	// Token: 0x040001A9 RID: 425
	private readonly TrimLru<TK, TV> Lru;

	// Token: 0x040001AA RID: 426
	[Nullable(new byte[]
	{
		1,
		1,
		2
	})]
	private readonly Func<TK, TV> Creator;
}
