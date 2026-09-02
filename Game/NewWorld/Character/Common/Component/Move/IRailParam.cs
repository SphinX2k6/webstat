using System;

namespace CSharpScript.Game.NewWorld.Character.Common.Component.Move
{
	// Token: 0x02004926 RID: 18726
	public interface IRailParam
	{
		// Token: 0x17008359 RID: 33625
		// (get) Token: 0x06030F8D RID: 200589
		// (set) Token: 0x06030F8E RID: 200590
		ERailMoveType RailType { get; set; }

		// Token: 0x1700835A RID: 33626
		// (get) Token: 0x06030F8F RID: 200591
		// (set) Token: 0x06030F90 RID: 200592
		ERailJumpType JumpType { get; set; }
	}
}
