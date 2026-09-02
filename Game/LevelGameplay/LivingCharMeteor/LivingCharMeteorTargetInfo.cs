using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LivingCharMeteor
{
	// Token: 0x02006B3D RID: 27453
	[NullableContext(1)]
	[Nullable(0)]
	[RequiredMember]
	internal class LivingCharMeteorTargetInfo
	{
		// Token: 0x1700A328 RID: 41768
		// (get) Token: 0x06043D6C RID: 277868 RVA: 0x01188B8A File Offset: 0x01186D8A
		// (set) Token: 0x06043D6D RID: 277869 RVA: 0x01188B92 File Offset: 0x01186D92
		[RequiredMember]
		public Entity Entity { get; set; }

		// Token: 0x1700A329 RID: 41769
		// (get) Token: 0x06043D6E RID: 277870 RVA: 0x01188B9B File Offset: 0x01186D9B
		// (set) Token: 0x06043D6F RID: 277871 RVA: 0x01188BA3 File Offset: 0x01186DA3
		[RequiredMember]
		public AActor Actor { get; set; }

		// Token: 0x1700A32A RID: 41770
		// (get) Token: 0x06043D70 RID: 277872 RVA: 0x01188BAC File Offset: 0x01186DAC
		// (set) Token: 0x06043D71 RID: 277873 RVA: 0x01188BB4 File Offset: 0x01186DB4
		public double ScreenDistSquared { get; set; }

		// Token: 0x1700A32B RID: 41771
		// (get) Token: 0x06043D72 RID: 277874 RVA: 0x01188BBD File Offset: 0x01186DBD
		// (set) Token: 0x06043D73 RID: 277875 RVA: 0x01188BC5 File Offset: 0x01186DC5
		public double DistanceSquared { get; set; }

		// Token: 0x06043D74 RID: 277876 RVA: 0x01188BCE File Offset: 0x01186DCE
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public LivingCharMeteorTargetInfo()
		{
		}
	}
}
