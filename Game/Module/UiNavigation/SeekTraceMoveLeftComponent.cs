using System;
using CSharpScript.Game.LevelGamePlay.SeekTrace;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004D58 RID: 19800
	public class SeekTraceMoveLeftComponent : SeekTraceBaseMoveComponent
	{
		// Token: 0x06033593 RID: 210323 RVA: 0x00CD8629 File Offset: 0x00CD6829
		public SeekTraceMoveLeftComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x06033594 RID: 210324 RVA: 0x00CD8632 File Offset: 0x00CD6832
		protected override ESeekTraceMoveDirection GetMoveDirection()
		{
			return ESeekTraceMoveDirection.Left;
		}
	}
}
