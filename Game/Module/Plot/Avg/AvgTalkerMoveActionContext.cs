using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.Module.Plot.Avg
{
	// Token: 0x02005449 RID: 21577
	[NullableContext(1)]
	[Nullable(0)]
	[RequiredMember]
	public class AvgTalkerMoveActionContext
	{
		// Token: 0x17008E16 RID: 36374
		// (get) Token: 0x06036FF7 RID: 225271 RVA: 0x00DF6067 File Offset: 0x00DF4267
		// (set) Token: 0x06036FF8 RID: 225272 RVA: 0x00DF606F File Offset: 0x00DF426F
		public int CharacterId { get; set; }

		// Token: 0x17008E17 RID: 36375
		// (get) Token: 0x06036FF9 RID: 225273 RVA: 0x00DF6078 File Offset: 0x00DF4278
		// (set) Token: 0x06036FFA RID: 225274 RVA: 0x00DF6080 File Offset: 0x00DF4280
		public EAvgRoleAnimationType AnimationType { get; set; }

		// Token: 0x17008E18 RID: 36376
		// (get) Token: 0x06036FFB RID: 225275 RVA: 0x00DF6089 File Offset: 0x00DF4289
		// (set) Token: 0x06036FFC RID: 225276 RVA: 0x00DF6091 File Offset: 0x00DF4291
		public EAvgRolePosition TargetPosition { get; set; }

		// Token: 0x17008E19 RID: 36377
		// (get) Token: 0x06036FFD RID: 225277 RVA: 0x00DF609A File Offset: 0x00DF429A
		// (set) Token: 0x06036FFE RID: 225278 RVA: 0x00DF60A2 File Offset: 0x00DF42A2
		[RequiredMember]
		public IEaseData EaseCurve { get; set; }

		// Token: 0x06036FFF RID: 225279 RVA: 0x00DF60AB File Offset: 0x00DF42AB
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public AvgTalkerMoveActionContext()
		{
		}
	}
}
