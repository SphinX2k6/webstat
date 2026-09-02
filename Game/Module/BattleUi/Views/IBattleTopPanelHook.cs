using System;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02005F9C RID: 24476
	[NullableContext(1)]
	public interface IBattleTopPanelHook
	{
		// Token: 0x0603D756 RID: 251734
		UniTask OnInitAsync(TopPanel topPanel);

		// Token: 0x0603D757 RID: 251735
		void OnShow(TopPanel topPanel);

		// Token: 0x0603D758 RID: 251736
		void OnHide(TopPanel topPanel);

		// Token: 0x0603D759 RID: 251737
		void OnAddEventListener(TopPanel topPanel);

		// Token: 0x0603D75A RID: 251738
		void OnRemoveEventListener(TopPanel topPanel);

		// Token: 0x0603D75B RID: 251739
		void OnRefresh(TopPanel topPanel);

		// Token: 0x0603D75C RID: 251740
		void OnReset(TopPanel topPanel);
	}
}
