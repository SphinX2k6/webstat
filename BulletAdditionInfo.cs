using System;
using System.Runtime.CompilerServices;

// Token: 0x02002E05 RID: 11781
public class BulletAdditionInfo
{
	// Token: 0x1700204A RID: 8266
	// (get) Token: 0x06017CC7 RID: 97479 RVA: 0x006A234B File Offset: 0x006A054B
	public bool Valid
	{
		get
		{
			return this.ValidInternal;
		}
	}

	// Token: 0x06017CC8 RID: 97480 RVA: 0x006A2353 File Offset: 0x006A0553
	public void Clear()
	{
		this.ValidInternal = false;
		this.SizeScale.Reset();
		this.IntervalScale = 0f;
		this.DurationAddition = 0f;
	}

	// Token: 0x06017CC9 RID: 97481 RVA: 0x006A237D File Offset: 0x006A057D
	public void Init()
	{
		this.ValidInternal = true;
	}

	// Token: 0x0400B86C RID: 47212
	[Nullable(1)]
	public readonly Vector SizeScale = Vector.Create();

	// Token: 0x0400B86D RID: 47213
	public float IntervalScale;

	// Token: 0x0400B86E RID: 47214
	public float DurationAddition;

	// Token: 0x0400B86F RID: 47215
	private bool ValidInternal;
}
