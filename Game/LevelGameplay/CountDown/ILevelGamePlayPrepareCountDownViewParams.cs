using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.LevelGamePlay.CountDown
{
	// Token: 0x02006F22 RID: 28450
	[NullableContext(2)]
	public interface ILevelGamePlayPrepareCountDownViewParams
	{
		// Token: 0x1700A447 RID: 42055
		// (get) Token: 0x06044E66 RID: 282214
		// (set) Token: 0x06044E67 RID: 282215
		int CountDownNum { get; set; }

		// Token: 0x1700A448 RID: 42056
		// (get) Token: 0x06044E68 RID: 282216
		// (set) Token: 0x06044E69 RID: 282217
		string TidText { get; set; }

		// Token: 0x1700A449 RID: 42057
		// (get) Token: 0x06044E6A RID: 282218
		// (set) Token: 0x06044E6B RID: 282219
		ECountDownUiStyle? UiStyle { get; set; }
	}
}
