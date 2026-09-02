using System;
using System.Runtime.CompilerServices;

// Token: 0x020031BB RID: 12731
[NullableContext(1)]
[Nullable(0)]
public class InterestItemPosition : InterestItemBase
{
	// Token: 0x170023E3 RID: 9187
	// (get) Token: 0x0601A666 RID: 108134 RVA: 0x007C8E6E File Offset: 0x007C706E
	public override EInterestItemType Type
	{
		get
		{
			return EInterestItemType.Position;
		}
	}

	// Token: 0x0601A667 RID: 108135 RVA: 0x007C8E71 File Offset: 0x007C7071
	public override bool GetLocation(Vector outVector)
	{
		outVector.DeepCopy(this.Position);
		return true;
	}

	// Token: 0x0601A668 RID: 108136 RVA: 0x007C8E80 File Offset: 0x007C7080
	public override string GetDebugInfo()
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(13, 3);
		defaultInterpolatedStringHandler.AppendLiteral("X: ");
		defaultInterpolatedStringHandler.AppendFormatted<double>(this.Position.X);
		defaultInterpolatedStringHandler.AppendLiteral(", Y: ");
		defaultInterpolatedStringHandler.AppendFormatted<double>(this.Position.Y);
		defaultInterpolatedStringHandler.AppendLiteral(", Z: ");
		defaultInterpolatedStringHandler.AppendFormatted<double>(this.Position.Z);
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x0400D509 RID: 54537
	public Vector Position = Vector.Create();
}
