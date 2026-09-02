using System;
using System.Runtime.CompilerServices;

// Token: 0x02002865 RID: 10341
[NullableContext(1)]
public interface IContentHandler<[Nullable(0)] T> : IContentHandler where T : RoleFavorContentDataBase
{
	// Token: 0x060147DD RID: 83933
	void ShowItem(T contentData);

	// Token: 0x060147DE RID: 83934
	void PlayContent(T contentData, RoleFavorContentItem roleFavorContentItem);
}
