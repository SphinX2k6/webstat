using System;
using System.Runtime.CompilerServices;

// Token: 0x020017BE RID: 6078
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
public class BlackScreenGlobalData : Singleton<BlackScreenGlobalData>
{
	// Token: 0x0600AB85 RID: 43909 RVA: 0x002DD8A4 File Offset: 0x002DBAA4
	public void CreateShowPromise()
	{
		this.ShowPromise = new CustomPromise();
	}

	// Token: 0x0600AB86 RID: 43910 RVA: 0x002DD8B1 File Offset: 0x002DBAB1
	public void FinishShowPromise()
	{
		this.ShowPromise.SetResult();
	}

	// Token: 0x0600AB87 RID: 43911 RVA: 0x002DD8BE File Offset: 0x002DBABE
	public void CreateHidePromise()
	{
		this.HidePromise = new CustomPromise();
	}

	// Token: 0x0600AB88 RID: 43912 RVA: 0x002DD8CB File Offset: 0x002DBACB
	public void FinishHidePromise()
	{
		this.HidePromise.SetResult();
	}

	// Token: 0x0600AB89 RID: 43913 RVA: 0x002DD8D8 File Offset: 0x002DBAD8
	public void ResetGlobalData()
	{
		this.ShowPromise = null;
		this.HidePromise = null;
	}

	// Token: 0x04005197 RID: 20887
	public CustomPromise ShowPromise;

	// Token: 0x04005198 RID: 20888
	public CustomPromise HidePromise;
}
