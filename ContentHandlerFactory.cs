using System;
using System.Runtime.CompilerServices;

// Token: 0x02002866 RID: 10342
public static class ContentHandlerFactory
{
	// Token: 0x060147DF RID: 83935 RVA: 0x005AF7F8 File Offset: 0x005AD9F8
	[NullableContext(1)]
	public static IContentHandler<T> CreateContentHandler<[Nullable(0)] T>(Action<T> showItem, [Nullable(new byte[]
	{
		2,
		1,
		1
	})] Action<T, RoleFavorContentItem> playContent = null) where T : RoleFavorContentDataBase
	{
		return new ContentHandler<T>(showItem, playContent);
	}
}
