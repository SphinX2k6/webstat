using System;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;

namespace CSharpScript.Game.Module.MovieMode
{
	// Token: 0x020056E6 RID: 22246
	[NullableContext(2)]
	[Nullable(0)]
	[RequiredMember]
	public class ExitMovieModeParams : IExitMovieModeParams
	{
		// Token: 0x170090F1 RID: 37105
		// (get) Token: 0x060389F1 RID: 231921 RVA: 0x00E578B7 File Offset: 0x00E55AB7
		// (set) Token: 0x060389F2 RID: 231922 RVA: 0x00E578BF File Offset: 0x00E55ABF
		[RequiredMember]
		public float BlendTime { get; set; }

		// Token: 0x170090F2 RID: 37106
		// (get) Token: 0x060389F3 RID: 231923 RVA: 0x00E578C8 File Offset: 0x00E55AC8
		// (set) Token: 0x060389F4 RID: 231924 RVA: 0x00E578D0 File Offset: 0x00E55AD0
		public float? BlackFadeInTime { get; set; }

		// Token: 0x170090F3 RID: 37107
		// (get) Token: 0x060389F5 RID: 231925 RVA: 0x00E578D9 File Offset: 0x00E55AD9
		// (set) Token: 0x060389F6 RID: 231926 RVA: 0x00E578E1 File Offset: 0x00E55AE1
		public Func<UniTask> AfterBlackFadeInCallbackAsync { get; set; }

		// Token: 0x060389F7 RID: 231927 RVA: 0x00E578EA File Offset: 0x00E55AEA
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public ExitMovieModeParams()
		{
		}
	}
}
