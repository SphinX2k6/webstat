using System;
using System.Runtime.CompilerServices;

// Token: 0x020030B1 RID: 12465
[NullableContext(1)]
[Nullable(0)]
public class LockOnInfo
{
	// Token: 0x06019AE4 RID: 105188 RVA: 0x0077718C File Offset: 0x0077538C
	public LockOnInfo([Nullable(2)] EntityHandle entityHandle = null, string socketName = "")
	{
		this.EntityHandle = entityHandle;
		this.SocketName = socketName;
	}

	// Token: 0x06019AE5 RID: 105189 RVA: 0x007771AD File Offset: 0x007753AD
	public void Copy(LockOnInfo info)
	{
		this.EntityHandle = info.EntityHandle;
		this.SocketName = info.SocketName;
	}

	// Token: 0x06019AE6 RID: 105190 RVA: 0x007771C8 File Offset: 0x007753C8
	public bool Equal(LockOnInfo info)
	{
		EntityHandle entityHandle = this.EntityHandle;
		int? num = (entityHandle != null) ? new int?(entityHandle.Id) : null;
		EntityHandle entityHandle2 = info.EntityHandle;
		int? num2 = (entityHandle2 != null) ? new int?(entityHandle2.Id) : null;
		return (num.GetValueOrDefault() == num2.GetValueOrDefault() & num != null == (num2 != null)) && this.SocketName == info.SocketName;
	}

	// Token: 0x06019AE7 RID: 105191 RVA: 0x0077724C File Offset: 0x0077544C
	public bool Different(LockOnInfo info)
	{
		return this.EntityHandle != info.EntityHandle || (this.SocketName != info.SocketName && !string.IsNullOrEmpty(info.SocketName) && !string.IsNullOrEmpty(this.SocketName));
	}

	// Token: 0x0400CC78 RID: 52344
	[Nullable(2)]
	public EntityHandle EntityHandle;

	// Token: 0x0400CC79 RID: 52345
	public string SocketName = "";
}
