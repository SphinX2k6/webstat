using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Component;

namespace CSharpScript.Game.Module.MechanismTimeline
{
	// Token: 0x020057D7 RID: 22487
	[NullableContext(1)]
	[Nullable(0)]
	[RequiredMember]
	public class MechanismEventInfo : IMechanismEventInfo
	{
		// Token: 0x170091B3 RID: 37299
		// (get) Token: 0x0603925C RID: 234076 RVA: 0x00E7D5DC File Offset: 0x00E7B7DC
		// (set) Token: 0x0603925D RID: 234077 RVA: 0x00E7D5E4 File Offset: 0x00E7B7E4
		[RequiredMember]
		public ISceneItemSeqEventCbType Info { get; set; }

		// Token: 0x170091B4 RID: 37300
		// (get) Token: 0x0603925E RID: 234078 RVA: 0x00E7D5ED File Offset: 0x00E7B7ED
		// (set) Token: 0x0603925F RID: 234079 RVA: 0x00E7D5F5 File Offset: 0x00E7B7F5
		[RequiredMember]
		public string SeqGuid { get; set; }

		// Token: 0x06039260 RID: 234080 RVA: 0x00E7D5FE File Offset: 0x00E7B7FE
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public MechanismEventInfo()
		{
		}
	}
}
