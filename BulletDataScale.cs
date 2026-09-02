using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Core.Fight;
using UnrealEngine;

// Token: 0x02002DA6 RID: 11686
[NullableContext(1)]
[Nullable(0)]
public class BulletDataScale
{
	// Token: 0x17001F89 RID: 8073
	// (get) Token: 0x0601797D RID: 96637 RVA: 0x0068FF21 File Offset: 0x0068E121
	public Vector SizeScale
	{
		get
		{
			if (this.SizeScaleInternal == null)
			{
				this.SizeScaleInternal = Vector.Create(this.Data.缩放倍率);
			}
			return this.SizeScaleInternal;
		}
	}

	// Token: 0x17001F8A RID: 8074
	// (get) Token: 0x0601797E RID: 96638 RVA: 0x0068FF4C File Offset: 0x0068E14C
	[Nullable(2)]
	public UCurveVector ScaleCurve
	{
		[NullableContext(2)]
		get
		{
			if (!this.ScaleCurveInit)
			{
				this.ScaleCurveInit = true;
				this.ScaleCurveInternal = this.Data.缩放倍率曲线;
			}
			return this.ScaleCurveInternal;
		}
	}

	// Token: 0x17001F8B RID: 8075
	// (get) Token: 0x0601797F RID: 96639 RVA: 0x0068FF74 File Offset: 0x0068E174
	public bool ShapeSwitch
	{
		get
		{
			if (this.ShapeSwitchInternal == null)
			{
				this.ShapeSwitchInternal = new bool?(this.Data.特定形状开关);
			}
			return this.ShapeSwitchInternal.Value;
		}
	}

	// Token: 0x06017980 RID: 96640 RVA: 0x0068FFA4 File Offset: 0x0068E1A4
	public BulletDataScale(SReBulletDataScale data)
	{
		this.Data = data;
	}

	// Token: 0x06017981 RID: 96641 RVA: 0x0068FFB3 File Offset: 0x0068E1B3
	public bool Preload()
	{
		Vector sizeScale = this.SizeScale;
		UCurveVector scaleCurve = this.ScaleCurve;
		return (bool)true;
	}

	// Token: 0x0400B558 RID: 46424
	private readonly SReBulletDataScale Data;

	// Token: 0x0400B559 RID: 46425
	[Nullable(2)]
	private Vector SizeScaleInternal;

	// Token: 0x0400B55A RID: 46426
	[Nullable(2)]
	private UCurveVector ScaleCurveInternal;

	// Token: 0x0400B55B RID: 46427
	private bool ScaleCurveInit;

	// Token: 0x0400B55C RID: 46428
	private bool? ShapeSwitchInternal;
}
