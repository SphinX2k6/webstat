using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.AutoPilot
{
	// Token: 0x0200614A RID: 24906
	[NullableContext(1)]
	[Nullable(0)]
	[RequiredMember]
	public class AutoPilotTrackingData : AutoPilotDefine.IAutoPilotTrackingData
	{
		// Token: 0x17009AE2 RID: 39650
		// (get) Token: 0x0603EEC3 RID: 257731 RVA: 0x0102113D File Offset: 0x0101F33D
		// (set) Token: 0x0603EEC4 RID: 257732 RVA: 0x01021145 File Offset: 0x0101F345
		[RequiredMember]
		public Vector TargetPos { get; set; }

		// Token: 0x17009AE3 RID: 39651
		// (get) Token: 0x0603EEC5 RID: 257733 RVA: 0x0102114E File Offset: 0x0101F34E
		// (set) Token: 0x0603EEC6 RID: 257734 RVA: 0x01021156 File Offset: 0x0101F356
		public int MapId { get; set; }

		// Token: 0x0603EEC7 RID: 257735 RVA: 0x0102115F File Offset: 0x0101F35F
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public AutoPilotTrackingData()
		{
		}
	}
}
