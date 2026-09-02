using System;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.LevelGamePlay.SignalDeviceControl
{
	// Token: 0x02006AF5 RID: 27381
	public interface IGridState
	{
		// Token: 0x1700A2F7 RID: 41719
		// (get) Token: 0x06043B04 RID: 277252
		// (set) Token: 0x06043B05 RID: 277253
		bool IsFinished { get; set; }

		// Token: 0x1700A2F8 RID: 41720
		// (get) Token: 0x06043B06 RID: 277254
		// (set) Token: 0x06043B07 RID: 277255
		EPieceColorType Color { get; set; }
	}
}
