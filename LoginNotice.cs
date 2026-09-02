using System;
using System.Runtime.CompilerServices;

// Token: 0x020020FB RID: 8443
[NullableContext(1)]
[Nullable(0)]
public class LoginNotice
{
	// Token: 0x0601020A RID: 66058 RVA: 0x0046EEFC File Offset: 0x0046D0FC
	public void Phrase(LoginNoticeEx ex)
	{
		this.WhiteLists = ex.whiteList;
		this.BeginTime = ex.startTimeMs / 1000.0;
		this.EndTime = ex.endTimeMs / 1000.0;
		this.Title = ex.title;
		this.content = ex.content;
	}

	// Token: 0x04007BC9 RID: 31689
	public string Id = string.Empty;

	// Token: 0x04007BCA RID: 31690
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public string[] WhiteLists;

	// Token: 0x04007BCB RID: 31691
	public double ModifyTime;

	// Token: 0x04007BCC RID: 31692
	public double BeginTime;

	// Token: 0x04007BCD RID: 31693
	public double EndTime;

	// Token: 0x04007BCE RID: 31694
	public string Title = string.Empty;

	// Token: 0x04007BCF RID: 31695
	public string content = string.Empty;
}
