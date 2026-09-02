using System;
using System.Runtime.CompilerServices;

// Token: 0x02002864 RID: 10340
[NullableContext(1)]
public interface IContentHandler
{
	// Token: 0x060147DB RID: 83931
	void ShowItem(RoleFavorContentDataBase contentData);

	// Token: 0x060147DC RID: 83932
	void PlayContent(RoleFavorContentDataBase contentData, RoleFavorContentItem roleFavorContentItem);
}
