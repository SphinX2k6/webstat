using System;
using CSharpScript.Game.LevelGamePlay.SeekTrace;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004D56 RID: 19798
	public class SeekTraceMoveUpComponent : SeekTraceBaseMoveComponent
	{
		// Token: 0x0603358F RID: 210319 RVA: 0x00CD8611 File Offset: 0x00CD6811
		public SeekTraceMoveUpComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x06033590 RID: 210320 RVA: 0x00CD861A File Offset: 0x00CD681A
		protected override ESeekTraceMoveDirection GetMoveDirection()
		{
			return ESeekTraceMoveDirection.Up;
		}
	}
}
