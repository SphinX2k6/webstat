using System;
using System.Runtime.CompilerServices;

// Token: 0x02001621 RID: 5665
[NullableContext(1)]
[Nullable(0)]
[RequiredMember]
public class VersionPreheatShareData
{
	// Token: 0x06009FBE RID: 40894 RVA: 0x0029B848 File Offset: 0x00299A48
	[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
	[CompilerFeatureRequired("RequiredMembers")]
	public VersionPreheatShareData()
	{
	}

	// Token: 0x04004963 RID: 18787
	[RequiredMember]
	public string PhotoPath;

	// Token: 0x04004964 RID: 18788
	[RequiredMember]
	public string NameTextId;

	// Token: 0x04004965 RID: 18789
	[RequiredMember]
	public string ThemeTextId;
}
