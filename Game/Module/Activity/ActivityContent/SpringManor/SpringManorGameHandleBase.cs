using System;

namespace CSharpScript.Game.Module.Activity.ActivityContent.SpringManor
{
	// Token: 0x020062F4 RID: 25332
	public abstract class SpringManorGameHandleBase
	{
		// Token: 0x0603FADA RID: 260826
		public abstract int GetCurrentProgress();

		// Token: 0x0603FADB RID: 260827
		public abstract int GetTotalProgress();

		// Token: 0x0603FADC RID: 260828
		public abstract void EnterGame();

		// Token: 0x0603FADD RID: 260829
		public abstract ERedDotName? GetRedDotName();
	}
}
