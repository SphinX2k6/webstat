using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02005F9E RID: 24478
	[NullableContext(2)]
	public interface IBattleUiCenterPanelOtherMovePanel
	{
		// Token: 0x0603D785 RID: 251781
		void Tick(float delta);

		// Token: 0x0603D786 RID: 251782
		void Destroy(Action callback = null);
	}
}
