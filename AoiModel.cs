using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x020034AC RID: 13484
[Nullable(new byte[]
{
	0,
	1
})]
public class AoiModel : ModelBase<AoiModel>
{
	// Token: 0x17002671 RID: 9841
	// (get) Token: 0x0601C710 RID: 116496 RVA: 0x00886832 File Offset: 0x00884A32
	// (set) Token: 0x0601C711 RID: 116497 RVA: 0x0088683A File Offset: 0x00884A3A
	public FVector? MinCoordinate
	{
		get
		{
			return this.MinCoordinateInternal;
		}
		set
		{
			this.MinCoordinateInternal = value;
		}
	}

	// Token: 0x17002672 RID: 9842
	// (get) Token: 0x0601C712 RID: 116498 RVA: 0x00886843 File Offset: 0x00884A43
	// (set) Token: 0x0601C713 RID: 116499 RVA: 0x0088684B File Offset: 0x00884A4B
	public FVector? MaxCoordinate
	{
		get
		{
			return this.MaxCoordinateInternal;
		}
		set
		{
			this.MaxCoordinateInternal = value;
		}
	}

	// Token: 0x0601C714 RID: 116500 RVA: 0x00886854 File Offset: 0x00884A54
	protected override bool OnInit()
	{
		this.MinCoordinateInternal = new FVector?(new FVector());
		this.MaxCoordinateInternal = new FVector?(new FVector());
		return true;
	}

	// Token: 0x0601C715 RID: 116501 RVA: 0x00886877 File Offset: 0x00884A77
	protected override bool OnClear()
	{
		this.MinCoordinateInternal = null;
		this.MaxCoordinateInternal = null;
		return true;
	}

	// Token: 0x0601C716 RID: 116502 RVA: 0x00886892 File Offset: 0x00884A92
	protected override bool OnLeaveLevel()
	{
		return true;
	}

	// Token: 0x0400E4E2 RID: 58594
	private FVector? MinCoordinateInternal;

	// Token: 0x0400E4E3 RID: 58595
	private FVector? MaxCoordinateInternal;
}
