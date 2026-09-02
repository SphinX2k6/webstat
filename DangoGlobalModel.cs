using System;
using System.Runtime.CompilerServices;

// Token: 0x02001B19 RID: 6937
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class DangoGlobalModel : ModelBase<DangoGlobalModel>
{
	// Token: 0x0600C7DF RID: 51167 RVA: 0x0034E557 File Offset: 0x0034C757
	protected override bool OnClear()
	{
		this.ClearAll();
		return true;
	}

	// Token: 0x0600C7E0 RID: 51168 RVA: 0x0034E560 File Offset: 0x0034C760
	protected override bool OnLeaveLevel()
	{
		this.ClearAll();
		return true;
	}

	// Token: 0x0600C7E1 RID: 51169 RVA: 0x0034E569 File Offset: 0x0034C769
	protected override bool OnChangeMode()
	{
		this.ClearAll();
		return true;
	}

	// Token: 0x0600C7E2 RID: 51170 RVA: 0x0034E572 File Offset: 0x0034C772
	private void ClearAll()
	{
		this.Config = null;
	}

	// Token: 0x04005FCC RID: 24524
	public DangoGlobalConfig Config;
}
