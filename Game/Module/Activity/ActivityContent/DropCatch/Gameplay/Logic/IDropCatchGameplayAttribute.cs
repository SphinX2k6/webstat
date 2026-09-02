using System;

namespace CSharpScript.Game.Module.Activity.ActivityContent.DropCatch.Gameplay.Logic
{
	// Token: 0x0200691B RID: 26907
	public interface IDropCatchGameplayAttribute
	{
		// Token: 0x06042D1E RID: 273694
		float GetBaseValue();

		// Token: 0x06042D1F RID: 273695
		float GetFinalValue();

		// Token: 0x06042D20 RID: 273696
		void SetFinalValue(float value);

		// Token: 0x06042D21 RID: 273697
		void Reset();
	}
}
