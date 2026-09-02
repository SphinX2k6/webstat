using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.WuwaGo
{
	// Token: 0x02004AAB RID: 19115
	[NullableContext(1)]
	public interface IWuWaGoTimeStopParticipant
	{
		// Token: 0x170084EE RID: 34030
		// (get) Token: 0x06031D64 RID: 204132
		// (set) Token: 0x06031D65 RID: 204133
		bool PausedByTimeStop { get; set; }

		// Token: 0x06031D66 RID: 204134
		void PauseByTimeStop();

		// Token: 0x06031D67 RID: 204135
		void ResumeByTimeStop();

		// Token: 0x06031D68 RID: 204136
		void CancelByTimeStop(string reason);
	}
}
