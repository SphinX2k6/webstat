using System;

namespace CSharpScript.Game.LevelGamePlay.SignalDeviceControl
{
	// Token: 0x02006AFB RID: 27387
	public class SignalDeviceViewConstants
	{
		// Token: 0x1700A2FC RID: 41724
		// (get) Token: 0x06043B21 RID: 277281 RVA: 0x0117560C File Offset: 0x0117380C
		public static int GRIDNUM
		{
			get
			{
				return SignalDeviceModel.ROWNUM * SignalDeviceModel.ROWNUM;
			}
		}
	}
}
