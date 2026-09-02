using System;
using System.Runtime.CompilerServices;

// Token: 0x02002867 RID: 10343
[NullableContext(1)]
[Nullable(0)]
public class ContentHandler<[Nullable(0)] T> : IContentHandler<T>, IContentHandler where T : RoleFavorContentDataBase
{
	// Token: 0x060147E0 RID: 83936 RVA: 0x005AF801 File Offset: 0x005ADA01
	public ContentHandler(Action<T> showItem, [Nullable(new byte[]
	{
		2,
		1,
		1
	})] Action<T, RoleFavorContentItem> playContent)
	{
		this.ShowItemAction = showItem;
		this.PlayContentAction = playContent;
	}

	// Token: 0x060147E1 RID: 83937 RVA: 0x005AF817 File Offset: 0x005ADA17
	public void ShowItem(T contentData)
	{
		this.ShowItemAction(contentData);
	}

	// Token: 0x060147E2 RID: 83938 RVA: 0x005AF825 File Offset: 0x005ADA25
	public void PlayContent(T contentData, RoleFavorContentItem roleFavorContentItem)
	{
		Action<T, RoleFavorContentItem> playContentAction = this.PlayContentAction;
		if (playContentAction == null)
		{
			return;
		}
		playContentAction(contentData, roleFavorContentItem);
	}

	// Token: 0x060147E3 RID: 83939 RVA: 0x005AF839 File Offset: 0x005ADA39
	void IContentHandler.ShowItem(RoleFavorContentDataBase contentData)
	{
		this.ShowItem((T)((object)contentData));
	}

	// Token: 0x060147E4 RID: 83940 RVA: 0x005AF847 File Offset: 0x005ADA47
	void IContentHandler.PlayContent(RoleFavorContentDataBase contentData, RoleFavorContentItem roleFavorContentItem)
	{
		this.PlayContent((T)((object)contentData), roleFavorContentItem);
	}

	// Token: 0x04009E6A RID: 40554
	private Action<T> ShowItemAction;

	// Token: 0x04009E6B RID: 40555
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private Action<T, RoleFavorContentItem> PlayContentAction;
}
