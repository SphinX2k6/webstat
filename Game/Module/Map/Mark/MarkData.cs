using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Map.MapDefine;

namespace CSharpScript.Game.Module.Map.Mark
{
	// Token: 0x02005818 RID: 22552
	[RequiredMember]
	public class MarkData
	{
		// Token: 0x0603959C RID: 234908 RVA: 0x00E8E34B File Offset: 0x00E8C54B
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public MarkData()
		{
		}

		// Token: 0x0402099D RID: 133533
		[Nullable(1)]
		[RequiredMember]
		public string Icon;

		// Token: 0x0402099E RID: 133534
		[Nullable(2)]
		public TTrackTarget TrackTarget;

		// Token: 0x0402099F RID: 133535
		public bool? TrackHudEnable;

		// Token: 0x040209A0 RID: 133536
		public float? TrackAutoCancelDistance;

		// Token: 0x040209A1 RID: 133537
		public int TargetInstanceOrMapId;

		// Token: 0x040209A2 RID: 133538
		public int? MultiMapId;

		// Token: 0x040209A3 RID: 133539
		public int? AreaId;
	}
}
