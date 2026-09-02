using System;
using CSharpScript.Game.LevelGamePlay.SeekTrace;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004D59 RID: 19801
	public class SeekTraceMoveRightComponent : SeekTraceBaseMoveComponent
	{
		// Token: 0x06033595 RID: 210325 RVA: 0x00CD8635 File Offset: 0x00CD6835
		public SeekTraceMoveRightComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x06033596 RID: 210326 RVA: 0x00CD863E File Offset: 0x00CD683E
		protected override ESeekTraceMoveDirection GetMoveDirection()
		{
			return ESeekTraceMoveDirection.Right;
		}
	}
}
