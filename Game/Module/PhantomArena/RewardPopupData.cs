using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena
{
	// Token: 0x0200548E RID: 21646
	[NullableContext(1)]
	[Nullable(0)]
	[RequiredMember]
	public class RewardPopupData
	{
		// Token: 0x060371AA RID: 225706 RVA: 0x00DFD912 File Offset: 0x00DFBB12
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public RewardPopupData()
		{
		}

		// Token: 0x0401FB8A RID: 129930
		[RequiredMember]
		public List<RewardTuple> RewardLists;

		// Token: 0x0401FB8B RID: 129931
		[RequiredMember]
		public UUIItem MountItem;

		// Token: 0x0401FB8C RID: 129932
		public FVector? PosBias;
	}
}
