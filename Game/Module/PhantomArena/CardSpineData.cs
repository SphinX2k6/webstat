using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.PhantomArena
{
	// Token: 0x02005484 RID: 21636
	[NullableContext(1)]
	[Nullable(0)]
	[RequiredMember]
	public class CardSpineData
	{
		// Token: 0x060371A0 RID: 225696 RVA: 0x00DFD8C2 File Offset: 0x00DFBAC2
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public CardSpineData()
		{
		}

		// Token: 0x0401FB71 RID: 129905
		[RequiredMember]
		public string CardSpineAtlasPath;

		// Token: 0x0401FB72 RID: 129906
		[RequiredMember]
		public string CardSpineSkeletonPath;

		// Token: 0x0401FB73 RID: 129907
		[RequiredMember]
		public ECardSpineAnimation AnimationName;

		// Token: 0x0401FB74 RID: 129908
		[RequiredMember]
		public bool IsLoop;
	}
}
