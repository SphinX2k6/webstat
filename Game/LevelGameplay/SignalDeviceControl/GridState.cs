using System;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.LevelGamePlay.SignalDeviceControl
{
	// Token: 0x02006AF6 RID: 27382
	public class GridState : IGridState
	{
		// Token: 0x1700A2F9 RID: 41721
		// (get) Token: 0x06043B08 RID: 277256 RVA: 0x01175011 File Offset: 0x01173211
		// (set) Token: 0x06043B09 RID: 277257 RVA: 0x01175019 File Offset: 0x01173219
		public bool IsFinished { get; set; }

		// Token: 0x1700A2FA RID: 41722
		// (get) Token: 0x06043B0A RID: 277258 RVA: 0x01175022 File Offset: 0x01173222
		// (set) Token: 0x06043B0B RID: 277259 RVA: 0x0117502A File Offset: 0x0117322A
		public EPieceColorType Color { get; set; }
	}
}
