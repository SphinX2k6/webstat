using System;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.Plot
{
	// Token: 0x02005369 RID: 21353
	public class PlotFormation
	{
		// Token: 0x0603672A RID: 223018 RVA: 0x00DBBBC4 File Offset: 0x00DB9DC4
		public void ChangeFormation()
		{
			Singleton<Log>.Instance.Info(ELogModule.Plot, ELogAuthor.FZX, "[剧情加载等待] 剧情切编队-开始", default(ReadOnlySpan<ValueTuple<string, object>>));
			ModelBase<PlotModel>.Instance.InSeamlessFormation = true;
		}

		// Token: 0x0603672B RID: 223019 RVA: 0x00DBBBF8 File Offset: 0x00DB9DF8
		public UniTask CheckFormationPromise()
		{
			PlotFormation.<CheckFormationPromise>d__1 <CheckFormationPromise>d__;
			<CheckFormationPromise>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CheckFormationPromise>d__.<>1__state = -1;
			<CheckFormationPromise>d__.<>t__builder.Start<PlotFormation.<CheckFormationPromise>d__1>(ref <CheckFormationPromise>d__);
			return <CheckFormationPromise>d__.<>t__builder.Task;
		}
	}
}
