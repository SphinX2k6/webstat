using System;
using AkiClient.Game.Aki.Core.Fight;

// Token: 0x02002D9C RID: 11676
public class BulletDataAimed
{
	// Token: 0x17001F04 RID: 7940
	// (get) Token: 0x060178DB RID: 96475 RVA: 0x0068D6B7 File Offset: 0x0068B8B7
	public bool AimedCtrlDir
	{
		get
		{
			if (this.AimedCtrlDirInternal == null)
			{
				this.AimedCtrlDirInternal = new bool?(this.Data.瞄准发射);
			}
			return this.AimedCtrlDirInternal.Value;
		}
	}

	// Token: 0x17001F05 RID: 7941
	// (get) Token: 0x060178DC RID: 96476 RVA: 0x0068D6E7 File Offset: 0x0068B8E7
	public float AngleOffset
	{
		get
		{
			if (this.AngleOffsetInternal == null)
			{
				this.AngleOffsetInternal = new float?(this.Data.瞄准子弹最大偏转角度);
			}
			return this.AngleOffsetInternal.Value;
		}
	}

	// Token: 0x17001F06 RID: 7942
	// (get) Token: 0x060178DD RID: 96477 RVA: 0x0068D717 File Offset: 0x0068B917
	public float DistLimit
	{
		get
		{
			if (this.DistLimitInternal == null)
			{
				this.DistLimitInternal = new float?(this.Data.瞄准子弹最大射程);
			}
			return this.DistLimitInternal.Value;
		}
	}

	// Token: 0x060178DE RID: 96478 RVA: 0x0068D747 File Offset: 0x0068B947
	public BulletDataAimed(SReBulletDataAimed data)
	{
		this.Data = data;
	}

	// Token: 0x0400B49E RID: 46238
	private readonly SReBulletDataAimed Data;

	// Token: 0x0400B49F RID: 46239
	private bool? AimedCtrlDirInternal;

	// Token: 0x0400B4A0 RID: 46240
	private float? AngleOffsetInternal;

	// Token: 0x0400B4A1 RID: 46241
	private float? DistLimitInternal;
}
