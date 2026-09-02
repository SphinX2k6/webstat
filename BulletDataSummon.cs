using System;
using AkiClient.Game.Aki.Core.Fight;

// Token: 0x02002DA7 RID: 11687
public class BulletDataSummon
{
	// Token: 0x17001F8C RID: 8076
	// (get) Token: 0x06017982 RID: 96642 RVA: 0x0068FFCE File Offset: 0x0068E1CE
	public int EntityId
	{
		get
		{
			if (this.EntityIdInternal == null)
			{
				this.EntityIdInternal = new int?(this.Data.实体ID);
			}
			return this.EntityIdInternal.Value;
		}
	}

	// Token: 0x17001F8D RID: 8077
	// (get) Token: 0x06017983 RID: 96643 RVA: 0x0068FFFE File Offset: 0x0068E1FE
	public bool DestroyEntityOnBulletEnd
	{
		get
		{
			if (this.DestroyEntityOnBulletEndInternal == null)
			{
				this.DestroyEntityOnBulletEndInternal = new bool?(this.Data.是否随子弹销毁而销毁);
			}
			return this.DestroyEntityOnBulletEndInternal.Value;
		}
	}

	// Token: 0x06017984 RID: 96644 RVA: 0x0069002E File Offset: 0x0068E22E
	public BulletDataSummon(SReBulletDataEntity data)
	{
		this.Data = data;
	}

	// Token: 0x0400B55D RID: 46429
	private readonly SReBulletDataEntity Data;

	// Token: 0x0400B55E RID: 46430
	private int? EntityIdInternal;

	// Token: 0x0400B55F RID: 46431
	private bool? DestroyEntityOnBulletEndInternal;
}
