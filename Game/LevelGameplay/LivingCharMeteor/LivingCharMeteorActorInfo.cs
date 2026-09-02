using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LivingCharMeteor
{
	// Token: 0x02006B3E RID: 27454
	[NullableContext(1)]
	[Nullable(0)]
	[RequiredMember]
	internal class LivingCharMeteorActorInfo
	{
		// Token: 0x1700A32C RID: 41772
		// (get) Token: 0x06043D75 RID: 277877 RVA: 0x01188BD6 File Offset: 0x01186DD6
		// (set) Token: 0x06043D76 RID: 277878 RVA: 0x01188BDE File Offset: 0x01186DDE
		[RequiredMember]
		public AActor Actor { get; set; }

		// Token: 0x1700A32D RID: 41773
		// (get) Token: 0x06043D77 RID: 277879 RVA: 0x01188BE7 File Offset: 0x01186DE7
		// (set) Token: 0x06043D78 RID: 277880 RVA: 0x01188BEF File Offset: 0x01186DEF
		[RequiredMember]
		public FVectorDouble Location { get; set; }

		// Token: 0x06043D79 RID: 277881 RVA: 0x01188BF8 File Offset: 0x01186DF8
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public LivingCharMeteorActorInfo()
		{
		}
	}
}
