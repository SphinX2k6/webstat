using System;
using System.Runtime.CompilerServices;

// Token: 0x02001A5B RID: 6747
[NullableContext(1)]
[Nullable(0)]
public class CommonTabData
{
	// Token: 0x0600C0DD RID: 49373 RVA: 0x0032DC27 File Offset: 0x0032BE27
	[NullableContext(2)]
	public CommonTabData([Nullable(1)] string icon, CommonTabTitleData titleData, CommonTabTitleData tabItemTitleData = null)
	{
		this.Icon = icon;
		this.TitleData = titleData;
		this.TabItemTitleData = tabItemTitleData;
	}

	// Token: 0x0600C0DE RID: 49374 RVA: 0x0032DC4F File Offset: 0x0032BE4F
	public void SetSmallIcon(string icon)
	{
		this.SmallIcon = icon;
	}

	// Token: 0x0600C0DF RID: 49375 RVA: 0x0032DC58 File Offset: 0x0032BE58
	public string GetSmallIcon()
	{
		if (string.IsNullOrEmpty(this.SmallIcon))
		{
			return this.GetIcon();
		}
		return this.SmallIcon;
	}

	// Token: 0x0600C0E0 RID: 49376 RVA: 0x0032DC74 File Offset: 0x0032BE74
	public string GetIcon()
	{
		return this.Icon;
	}

	// Token: 0x0600C0E1 RID: 49377 RVA: 0x0032DC7C File Offset: 0x0032BE7C
	[NullableContext(2)]
	public CommonTabTitleData GetTitleData()
	{
		return this.TitleData;
	}

	// Token: 0x0600C0E2 RID: 49378 RVA: 0x0032DC84 File Offset: 0x0032BE84
	[NullableContext(2)]
	public CommonTabTitleData GetTabItemTitleData()
	{
		return this.TabItemTitleData;
	}

	// Token: 0x04005A67 RID: 23143
	private readonly string Icon;

	// Token: 0x04005A68 RID: 23144
	[Nullable(2)]
	private readonly CommonTabTitleData TitleData;

	// Token: 0x04005A69 RID: 23145
	[Nullable(2)]
	private readonly CommonTabTitleData TabItemTitleData;

	// Token: 0x04005A6A RID: 23146
	private string SmallIcon = "";
}
