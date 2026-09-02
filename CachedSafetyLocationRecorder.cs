using System;
using System.Runtime.CompilerServices;

// Token: 0x020031F9 RID: 12793
public class CachedSafetyLocationRecorder : ISafetyLocationGetter, IClear
{
	// Token: 0x0601A89B RID: 108699 RVA: 0x007D9F54 File Offset: 0x007D8154
	[NullableContext(2)]
	public Vector GetSafetyLocation()
	{
		if (!this.IsSafety)
		{
			return null;
		}
		return this.SafetyLocation;
	}

	// Token: 0x0601A89C RID: 108700 RVA: 0x007D9F66 File Offset: 0x007D8166
	public bool ClearObject()
	{
		this.IsSafety = false;
		return true;
	}

	// Token: 0x0400D68B RID: 54923
	[Nullable(1)]
	public readonly Vector SafetyLocation = Vector.Create();

	// Token: 0x0400D68C RID: 54924
	public bool IsSafety;
}
