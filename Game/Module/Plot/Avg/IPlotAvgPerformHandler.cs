using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using Cysharp.Threading.Tasks;

namespace CSharpScript.Game.Module.Plot.Avg
{
	// Token: 0x0200544A RID: 21578
	[NullableContext(1)]
	public interface IPlotAvgPerformHandler
	{
		// Token: 0x06037000 RID: 225280
		UniTask PlayCharacterEnterPerformAsync(AvgTalkerEnterActionContext context);

		// Token: 0x06037001 RID: 225281
		UniTask PlayCharacterExitPerformAsync(int characterId);

		// Token: 0x06037002 RID: 225282
		UniTask PlayCharacterMovePerformAsync(AvgTalkerMoveActionContext context);

		// Token: 0x06037003 RID: 225283
		void ChangeCharacterAnim(int characterId, EAvgRoleAnimationType animationType, bool isLoop);
	}
}
