using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Core.Fight;

// Token: 0x02002DA4 RID: 11684
[NullableContext(1)]
[Nullable(0)]
public class BulletDataObstacle
{
	// Token: 0x17001F78 RID: 8056
	// (get) Token: 0x06017968 RID: 96616 RVA: 0x0068FA24 File Offset: 0x0068DC24
	public Vector Center
	{
		get
		{
			if (this.CenterInternal == null)
			{
				this.CenterInternal = Vector.Create(this.Data.检测位置);
			}
			return this.CenterInternal;
		}
	}

	// Token: 0x17001F79 RID: 8057
	// (get) Token: 0x06017969 RID: 96617 RVA: 0x0068FA4F File Offset: 0x0068DC4F
	public float Radius
	{
		get
		{
			if (this.RadiusInternal == null)
			{
				this.RadiusInternal = new float?(this.Data.检测距离);
			}
			return this.RadiusInternal.Value;
		}
	}

	// Token: 0x0601796A RID: 96618 RVA: 0x0068FA7F File Offset: 0x0068DC7F
	public BulletDataObstacle(SReBulletDataObstacles data)
	{
		this.Data = data;
	}

	// Token: 0x0601796B RID: 96619 RVA: 0x0068FA8E File Offset: 0x0068DC8E
	public bool Preload()
	{
		Vector center = this.Center;
		float radius = this.Radius;
		return (bool)true;
	}

	// Token: 0x0400B545 RID: 46405
	private readonly SReBulletDataObstacles Data;

	// Token: 0x0400B546 RID: 46406
	[Nullable(2)]
	private Vector CenterInternal;

	// Token: 0x0400B547 RID: 46407
	private float? RadiusInternal;
}
