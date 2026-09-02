using System;
using CSharpScript.Game.LevelGamePlay.SeekTrace;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004D57 RID: 19799
	public class SeekTraceMoveDownComponent : SeekTraceBaseMoveComponent
	{
		// Token: 0x06033591 RID: 210321 RVA: 0x00CD861D File Offset: 0x00CD681D
		public SeekTraceMoveDownComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x06033592 RID: 210322 RVA: 0x00CD8626 File Offset: 0x00CD6826
		protected override ESeekTraceMoveDirection GetMoveDirection()
		{
			return ESeekTraceMoveDirection.Down;
		}
	}
}
