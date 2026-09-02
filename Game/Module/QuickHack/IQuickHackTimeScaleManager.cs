using System;
using Aki.Config;

namespace CSharpScript.Game.Module.QuickHack
{
	// Token: 0x020052FB RID: 21243
	public interface IQuickHackTimeScaleManager
	{
		// Token: 0x060363A4 RID: 222116
		void BeginTimeScale(QuickHackDevice config, int ownerEntityId);

		// Token: 0x060363A5 RID: 222117
		void EndTimeScale();
	}
}
