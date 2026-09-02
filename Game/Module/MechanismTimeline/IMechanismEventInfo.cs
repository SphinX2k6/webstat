using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Component;

namespace CSharpScript.Game.Module.MechanismTimeline
{
	// Token: 0x020057D6 RID: 22486
	[NullableContext(1)]
	public interface IMechanismEventInfo
	{
		// Token: 0x170091B1 RID: 37297
		// (get) Token: 0x06039258 RID: 234072
		// (set) Token: 0x06039259 RID: 234073
		ISceneItemSeqEventCbType Info { get; set; }

		// Token: 0x170091B2 RID: 37298
		// (get) Token: 0x0603925A RID: 234074
		// (set) Token: 0x0603925B RID: 234075
		string SeqGuid { get; set; }
	}
}
