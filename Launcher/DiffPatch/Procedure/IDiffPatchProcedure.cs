using System;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.DiffPatch.Update;
using CSharpScript.Launcher.Ui.HotFix;
using Cysharp.Threading.Tasks;

namespace CSharpScript.Launcher.DiffPatch.Procedure
{
	// Token: 0x02004636 RID: 17974
	public interface IDiffPatchProcedure
	{
		// Token: 0x0602EF25 RID: 192293
		UniTask<bool> Start();

		// Token: 0x0602EF26 RID: 192294
		UniTask<bool> GetRemoteVersionConfig();

		// Token: 0x0602EF27 RID: 192295
		UniTask<bool> IsAppVersionChange();

		// Token: 0x0602EF28 RID: 192296
		UniTask<bool> UpdateResource(bool bUseBgDownload, [Nullable(1)] DiffUpdate update, bool bIsLauncher);

		// Token: 0x170080A0 RID: 32928
		// (get) Token: 0x0602EF29 RID: 192297
		// (set) Token: 0x0602EF2A RID: 192298
		[Nullable(1)]
		Func<DiffUpdate, HotFixManager, UniTask> RegistryExtraPack { [NullableContext(1)] get; [NullableContext(1)] set; }

		// Token: 0x0602EF2B RID: 192299
		void PreComplete();

		// Token: 0x0602EF2C RID: 192300
		UniTask<bool> Complete();

		// Token: 0x170080A1 RID: 32929
		// (get) Token: 0x0602EF2D RID: 192301
		bool HadOldResCleaned { get; }
	}
}
