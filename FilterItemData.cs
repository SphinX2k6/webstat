using System;
using System.Runtime.CompilerServices;

// Token: 0x020018FC RID: 6396
[NullableContext(2)]
[Nullable(0)]
public class FilterItemData
{
	// Token: 0x0600B797 RID: 46999 RVA: 0x0030D730 File Offset: 0x0030B930
	public FilterItemData(int filterId = 0, string content = null, string iconPath = null)
	{
		this.FilterId = filterId;
		this.Content = content;
		this.IconPath = iconPath;
	}

	// Token: 0x0600B798 RID: 47000 RVA: 0x0030D754 File Offset: 0x0030B954
	public void SetIsShowIcon(bool value)
	{
		this.IsShowIcon = value;
	}

	// Token: 0x0600B799 RID: 47001 RVA: 0x0030D75D File Offset: 0x0030B95D
	public string GetIconPath()
	{
		if (this.IsShowIcon)
		{
			return this.IconPath;
		}
		return null;
	}

	// Token: 0x04005694 RID: 22164
	private bool IsShowIcon = true;

	// Token: 0x04005695 RID: 22165
	public bool NeedChangeColor;

	// Token: 0x04005696 RID: 22166
	public int FilterId;

	// Token: 0x04005697 RID: 22167
	public string Content;

	// Token: 0x04005698 RID: 22168
	private readonly string IconPath;

	// Token: 0x04005699 RID: 22169
	public string ChangeColor;
}
