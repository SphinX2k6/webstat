using System;
using System.Runtime.CompilerServices;

// Token: 0x020011C2 RID: 4546
[RequiredMember]
public class ArtemisQteViewParams
{
	// Token: 0x060077B9 RID: 30649 RVA: 0x001F5892 File Offset: 0x001F3A92
	[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
	[CompilerFeatureRequired("RequiredMembers")]
	public ArtemisQteViewParams()
	{
	}

	// Token: 0x040039F6 RID: 14838
	[RequiredMember]
	public int GamePlayId;

	// Token: 0x040039F7 RID: 14839
	[RequiredMember]
	public int Index;

	// Token: 0x040039F8 RID: 14840
	[Nullable(1)]
	[RequiredMember]
	public Action CallBack;
}
