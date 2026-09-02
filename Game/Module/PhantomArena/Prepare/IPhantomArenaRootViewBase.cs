using System;
using Cysharp.Threading.Tasks;

namespace CSharpScript.Game.Module.PhantomArena.Prepare
{
	// Token: 0x020054AC RID: 21676
	public interface IPhantomArenaRootViewBase
	{
		// Token: 0x0603730B RID: 226059
		void OpenChildView(EPhantomArenaChildViewName viewName);

		// Token: 0x0603730C RID: 226060
		UniTask OpenChildViewAsync(EPhantomArenaChildViewName viewName);

		// Token: 0x0603730D RID: 226061
		UniTask<bool> CloseCurChildViewAsync();

		// Token: 0x0603730E RID: 226062
		void CloseCurChildView();

		// Token: 0x0603730F RID: 226063
		void Back();
	}
}
