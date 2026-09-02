using System;
using Cysharp.Threading.Tasks;

namespace CSharpScript.Game.Ui
{
	// Token: 0x020049A2 RID: 18850
	public interface IUiBehavior
	{
		// Token: 0x0603138A RID: 201610
		UniTask OnUiCreateAsync();

		// Token: 0x0603138B RID: 201611
		void OnAfterUiStart();

		// Token: 0x0603138C RID: 201612
		void OnAfterUiShow();

		// Token: 0x0603138D RID: 201613
		void OnBeforeUiHide();

		// Token: 0x0603138E RID: 201614
		void OnBeforeDestroy();
	}
}
