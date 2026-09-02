using System;
using System.Runtime.CompilerServices;

// Token: 0x020020FC RID: 8444
[NullableContext(1)]
[Nullable(0)]
public class SdkLoginConfig
{
	// Token: 0x0601020C RID: 66060 RVA: 0x0046EF82 File Offset: 0x0046D182
	public SdkLoginConfig(string uId = "", string userName = "", string token = "")
	{
		this.Uid = uId;
		this.UserName = userName;
		this.Token = token;
	}

	// Token: 0x0601020D RID: 66061 RVA: 0x0046EFC0 File Offset: 0x0046D1C0
	public string GetLoginUserNameWithUriEncode()
	{
		return Uri.EscapeDataString(this.UserName);
	}

	// Token: 0x04007BD0 RID: 31696
	public string Uid = string.Empty;

	// Token: 0x04007BD1 RID: 31697
	public string UserName = string.Empty;

	// Token: 0x04007BD2 RID: 31698
	public string Token = string.Empty;
}
