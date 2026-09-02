using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Ui
{
	// Token: 0x020049C2 RID: 18882
	[NullableContext(1)]
	public interface ICommonPopView
	{
		// Token: 0x06031639 RID: 202297
		UUIItem GetAttachParent();

		// Token: 0x0603163A RID: 202298
		void OnSetCloseBtnInteractive(bool state);

		// Token: 0x0603163B RID: 202299
		void OnSetHelpButtonActive(bool state);

		// Token: 0x0603163C RID: 202300
		void OnSetTitleByTextIdAndArg(string textId, params object[] args);

		// Token: 0x0603163D RID: 202301
		void OnSetBackBtnShowState(bool state);

		// Token: 0x0603163E RID: 202302
		void OnRefreshCost(CommonCurrencyItem[] commonCurrencyItemList);
	}
}
