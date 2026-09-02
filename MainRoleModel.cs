using System;
using System.Runtime.CompilerServices;

// Token: 0x020027AA RID: 10154
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class MainRoleModel : ModelBase<MainRoleModel>
{
	// Token: 0x060140D1 RID: 82129 RVA: 0x00598E0D File Offset: 0x0059700D
	public void UpdateCanChangeSexTime(long time)
	{
		this.CanChangeSexTime = time;
	}

	// Token: 0x060140D2 RID: 82130 RVA: 0x00598E16 File Offset: 0x00597016
	public bool CanChangeSex()
	{
		return Singleton<TimeUtil>.Instance.GetServerTimeStamp() >= (double)this.CanChangeSexTime;
	}

	// Token: 0x060140D3 RID: 82131 RVA: 0x00598E2E File Offset: 0x0059702E
	public double GetCanChangeSexTime()
	{
		return (double)this.CanChangeSexTime;
	}

	// Token: 0x04009C38 RID: 39992
	private long CanChangeSexTime;
}
