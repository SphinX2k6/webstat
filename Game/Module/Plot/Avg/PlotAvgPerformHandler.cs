using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using Cysharp.Threading.Tasks;

namespace CSharpScript.Game.Module.Plot.Avg
{
	// Token: 0x0200544B RID: 21579
	public class PlotAvgPerformHandler : IPlotAvgPerformHandler
	{
		// Token: 0x06037004 RID: 225284 RVA: 0x00DF60B3 File Offset: 0x00DF42B3
		[NullableContext(1)]
		public UniTask PlayCharacterEnterPerformAsync(AvgTalkerEnterActionContext context)
		{
			return UniTask.CompletedTask;
		}

		// Token: 0x06037005 RID: 225285 RVA: 0x00DF60BA File Offset: 0x00DF42BA
		public UniTask PlayCharacterExitPerformAsync(int characterId)
		{
			return UniTask.CompletedTask;
		}

		// Token: 0x06037006 RID: 225286 RVA: 0x00DF60C1 File Offset: 0x00DF42C1
		[NullableContext(1)]
		public UniTask PlayCharacterMovePerformAsync(AvgTalkerMoveActionContext context)
		{
			return UniTask.CompletedTask;
		}

		// Token: 0x06037007 RID: 225287 RVA: 0x00DF60C8 File Offset: 0x00DF42C8
		public void ChangeCharacterAnim(int characterId, EAvgRoleAnimationType animationType, bool isLoop)
		{
		}
	}
}
