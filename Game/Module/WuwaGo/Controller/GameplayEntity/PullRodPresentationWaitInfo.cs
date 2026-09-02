using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.WuwaGo.Controller.GameplayEntity
{
	// Token: 0x02004B13 RID: 19219
	[NullableContext(1)]
	[Nullable(0)]
	[RequiredMember]
	public class PullRodPresentationWaitInfo : IPullRodPresentationWaitInfo
	{
		// Token: 0x17008594 RID: 34196
		// (get) Token: 0x060321F6 RID: 205302 RVA: 0x00C8AFDB File Offset: 0x00C891DB
		// (set) Token: 0x060321F7 RID: 205303 RVA: 0x00C8AFE3 File Offset: 0x00C891E3
		[RequiredMember]
		public SceneInteractionActor SceneActor { get; set; }

		// Token: 0x17008595 RID: 34197
		// (get) Token: 0x060321F8 RID: 205304 RVA: 0x00C8AFEC File Offset: 0x00C891EC
		// (set) Token: 0x060321F9 RID: 205305 RVA: 0x00C8AFF4 File Offset: 0x00C891F4
		[RequiredMember]
		public ULevelSequence Sequence { get; set; }

		// Token: 0x17008596 RID: 34198
		// (get) Token: 0x060321FA RID: 205306 RVA: 0x00C8AFFD File Offset: 0x00C891FD
		// (set) Token: 0x060321FB RID: 205307 RVA: 0x00C8B005 File Offset: 0x00C89205
		[RequiredMember]
		public float PlayRate { get; set; }

		// Token: 0x060321FC RID: 205308 RVA: 0x00C8B00E File Offset: 0x00C8920E
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public PullRodPresentationWaitInfo()
		{
		}
	}
}
