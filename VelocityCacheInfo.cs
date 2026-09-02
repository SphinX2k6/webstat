using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x0200322A RID: 12842
[NullableContext(1)]
[Nullable(0)]
public class VelocityCacheInfo
{
	// Token: 0x0601AB72 RID: 109426 RVA: 0x007F4630 File Offset: 0x007F2830
	public string Dump()
	{
		bool isPlayInEditor = GlobalData.IsPlayInEditor;
		string str = "";
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(9, 1);
		defaultInterpolatedStringHandler.AppendLiteral("[Frame, ");
		defaultInterpolatedStringHandler.AppendFormatted<long>(this.Frame);
		defaultInterpolatedStringHandler.AppendLiteral("]");
		string str2 = str + defaultInterpolatedStringHandler.ToStringAndClear();
		defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(9, 1);
		defaultInterpolatedStringHandler.AppendLiteral("[CurZ1, ");
		defaultInterpolatedStringHandler.AppendFormatted<float?>(this.SpeedZ);
		defaultInterpolatedStringHandler.AppendLiteral("]");
		string str3 = str2 + defaultInterpolatedStringHandler.ToStringAndClear();
		defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(9, 1);
		defaultInterpolatedStringHandler.AppendLiteral("[CurZ2, ");
		defaultInterpolatedStringHandler.AppendFormatted<float?>(this.VelocityZ);
		defaultInterpolatedStringHandler.AppendLiteral("]");
		string str4 = str3 + defaultInterpolatedStringHandler.ToStringAndClear();
		defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(9, 1);
		defaultInterpolatedStringHandler.AppendLiteral("[LastZ, ");
		defaultInterpolatedStringHandler.AppendFormatted<float?>(this.LastZ);
		defaultInterpolatedStringHandler.AppendLiteral("]");
		string str5 = str4 + defaultInterpolatedStringHandler.ToStringAndClear();
		defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(8, 1);
		defaultInterpolatedStringHandler.AppendLiteral("[Mode, ");
		defaultInterpolatedStringHandler.AppendFormatted<EMovementMode?>(this.MoveMode);
		defaultInterpolatedStringHandler.AppendLiteral("]");
		return str5 + defaultInterpolatedStringHandler.ToStringAndClear() + "[Context, " + this.Context + "]" + "，";
	}

	// Token: 0x0400D892 RID: 55442
	public long Frame;

	// Token: 0x0400D893 RID: 55443
	public float? SpeedZ;

	// Token: 0x0400D894 RID: 55444
	public float? VelocityZ;

	// Token: 0x0400D895 RID: 55445
	public float? LastZ;

	// Token: 0x0400D896 RID: 55446
	public EMovementMode? MoveMode;

	// Token: 0x0400D897 RID: 55447
	public string Context = "";
}
