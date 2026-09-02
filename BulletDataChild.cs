using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Core.Fight;

// Token: 0x02002D9E RID: 11678
[NullableContext(1)]
[Nullable(0)]
public class BulletDataChild
{
	// Token: 0x17001F37 RID: 7991
	// (get) Token: 0x06017916 RID: 96534 RVA: 0x0068E3A3 File Offset: 0x0068C5A3
	public long RowName
	{
		get
		{
			if (this.RowNameInternal == null)
			{
				this.RowNameInternal = new long?(this.Data.召唤子弹ID);
			}
			return this.RowNameInternal.Value;
		}
	}

	// Token: 0x17001F38 RID: 7992
	// (get) Token: 0x06017917 RID: 96535 RVA: 0x0068E3D3 File Offset: 0x0068C5D3
	public float Delay
	{
		get
		{
			if (this.DelayInternal == null)
			{
				this.DelayInternal = new float?(this.Data.召唤子弹延迟);
			}
			return this.DelayInternal.Value;
		}
	}

	// Token: 0x17001F39 RID: 7993
	// (get) Token: 0x06017918 RID: 96536 RVA: 0x0068E403 File Offset: 0x0068C603
	public int Num
	{
		get
		{
			if (this.NumInternal == null)
			{
				this.NumInternal = new int?(this.Data.召唤子弹数量);
			}
			return this.NumInternal.Value;
		}
	}

	// Token: 0x17001F3A RID: 7994
	// (get) Token: 0x06017919 RID: 96537 RVA: 0x0068E433 File Offset: 0x0068C633
	public float Interval
	{
		get
		{
			if (this.IntervalInternal == null)
			{
				this.IntervalInternal = new float?(this.Data.召唤子弹间隔);
			}
			return this.IntervalInternal.Value;
		}
	}

	// Token: 0x17001F3B RID: 7995
	// (get) Token: 0x0601791A RID: 96538 RVA: 0x0068E463 File Offset: 0x0068C663
	public global::EBulletChildrenType Condition
	{
		get
		{
			if (this.ConditionInternal == null)
			{
				this.ConditionInternal = new global::EBulletChildrenType?((global::EBulletChildrenType)this.Data.召唤触发);
			}
			return this.ConditionInternal.Value;
		}
	}

	// Token: 0x17001F3C RID: 7996
	// (get) Token: 0x0601791B RID: 96539 RVA: 0x0068E498 File Offset: 0x0068C698
	public bool BreakOnFail
	{
		get
		{
			if (this.BreakOnFailInternal == null)
			{
				this.BreakOnFailInternal = new bool?(this.Data.失败是否停止);
			}
			return this.BreakOnFailInternal.Value;
		}
	}

	// Token: 0x0601791C RID: 96540 RVA: 0x0068E4C8 File Offset: 0x0068C6C8
	public BulletDataChild(SReBulletDataChildren data)
	{
		this.Data = data;
	}

	// Token: 0x0400B4E0 RID: 46304
	private readonly SReBulletDataChildren Data;

	// Token: 0x0400B4E1 RID: 46305
	private long? RowNameInternal;

	// Token: 0x0400B4E2 RID: 46306
	private float? DelayInternal;

	// Token: 0x0400B4E3 RID: 46307
	private int? NumInternal;

	// Token: 0x0400B4E4 RID: 46308
	private float? IntervalInternal;

	// Token: 0x0400B4E5 RID: 46309
	private global::EBulletChildrenType? ConditionInternal;

	// Token: 0x0400B4E6 RID: 46310
	private bool? BreakOnFailInternal;
}
