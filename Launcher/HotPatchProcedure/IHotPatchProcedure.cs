using System;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.Update;
using Cysharp.Threading.Tasks;

namespace CSharpScript.Launcher.HotPatchProcedure
{
	// Token: 0x020045FB RID: 17915
	public interface IHotPatchProcedure
	{
		// Token: 0x0602EDED RID: 191981
		UniTask<bool> Start();

		// Token: 0x0602EDEE RID: 191982
		UniTask<bool> GetRemoteVersionConfig();

		// Token: 0x0602EDEF RID: 191983
		UniTask<bool> IsAppVersionChange();

		// Token: 0x0602EDF0 RID: 191984
		UniTask<bool> UpdateResource(bool bUseBgDownload, [Nullable(1)] params ResourceUpdate[] updates);

		// Token: 0x0602EDF1 RID: 191985
		[NullableContext(1)]
		bool NeedRestart(params ResourceUpdate[] updates);

		// Token: 0x0602EDF2 RID: 191986
		UniTask<bool> MountPak([Nullable(1)] params ResourceUpdate[] updates);

		// Token: 0x0602EDF3 RID: 191987
		void PreComplete();

		// Token: 0x0602EDF4 RID: 191988
		UniTask<bool> Complete();
	}
}
