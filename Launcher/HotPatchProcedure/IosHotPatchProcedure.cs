using System;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.Ui.HotFix;
using CSharpScript.Launcher.Update;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Launcher.HotPatchProcedure
{
	// Token: 0x020045FE RID: 17918
	public class IosHotPatchProcedure : MobileHotPatchProcedure
	{
		// Token: 0x0602EE08 RID: 192008 RVA: 0x00B1A01F File Offset: 0x00B1821F
		[NullableContext(1)]
		public IosHotPatchProcedure(AppPathMisc pathMisc, HotFixManager viewMgr) : base(pathMisc, viewMgr)
		{
		}

		// Token: 0x0602EE09 RID: 192009 RVA: 0x00B1A02C File Offset: 0x00B1822C
		protected override UniTask<bool> DownloadFiles(bool bUseBgDownload, [Nullable(1)] params ResourceUpdate[] updates)
		{
			IosHotPatchProcedure.<DownloadFiles>d__1 <DownloadFiles>d__;
			<DownloadFiles>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<DownloadFiles>d__.<>4__this = this;
			<DownloadFiles>d__.bUseBgDownload = bUseBgDownload;
			<DownloadFiles>d__.updates = updates;
			<DownloadFiles>d__.<>1__state = -1;
			<DownloadFiles>d__.<>t__builder.Start<IosHotPatchProcedure.<DownloadFiles>d__1>(ref <DownloadFiles>d__);
			return <DownloadFiles>d__.<>t__builder.Task;
		}
	}
}
