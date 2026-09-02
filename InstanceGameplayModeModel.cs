using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x0200200A RID: 8202
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class InstanceGameplayModeModel : ModelBase<InstanceGameplayModeModel>
{
	// Token: 0x0600F7E5 RID: 63461 RVA: 0x0043E2D0 File Offset: 0x0043C4D0
	protected override bool OnClear()
	{
		this.ClearAll();
		return true;
	}

	// Token: 0x0600F7E6 RID: 63462 RVA: 0x0043E2D9 File Offset: 0x0043C4D9
	protected override bool OnLeaveLevel()
	{
		this.ClearAll();
		return true;
	}

	// Token: 0x0600F7E7 RID: 63463 RVA: 0x0043E2E2 File Offset: 0x0043C4E2
	protected override bool OnChangeMode()
	{
		this.ClearAll();
		return true;
	}

	// Token: 0x0600F7E8 RID: 63464 RVA: 0x0043E2EB File Offset: 0x0043C4EB
	private void ClearAll()
	{
		this.DisabledCreatureSet.Clear();
	}

	// Token: 0x0400779A RID: 30618
	public EDefaultCameraMode DefaultCameraMode;

	// Token: 0x0400779B RID: 30619
	public HashSet<long> DisabledCreatureSet = new HashSet<long>();
}
