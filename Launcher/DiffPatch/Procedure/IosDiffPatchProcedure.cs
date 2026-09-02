using System;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.DiffPatch.Update;
using CSharpScript.Launcher.Ui.HotFix;
using CSharpScript.Launcher.Update;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Launcher.DiffPatch.Procedure
{
	// Token: 0x02004639 RID: 17977
	public class IosDiffPatchProcedure : MobileDiffPatchProcedure
	{
		// Token: 0x0602EF40 RID: 192320 RVA: 0x00B1FE6A File Offset: 0x00B1E06A
		[NullableContext(1)]
		public IosDiffPatchProcedure(AppPathMisc pathMisc, HotFixManager viewMgr) : base(pathMisc, viewMgr)
		{
		}

		// Token: 0x0602EF41 RID: 192321 RVA: 0x00B1FE74 File Offset: 0x00B1E074
		protected override UniTask<bool> PromptDownload(long updateSize, [Nullable(1)] DiffUpdate update)
		{
			IosDiffPatchProcedure.<PromptDownload>d__1 <PromptDownload>d__;
			<PromptDownload>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<PromptDownload>d__.<>4__this = this;
			<PromptDownload>d__.updateSize = updateSize;
			<PromptDownload>d__.update = update;
			<PromptDownload>d__.<>1__state = -1;
			<PromptDownload>d__.<>t__builder.Start<IosDiffPatchProcedure.<PromptDownload>d__1>(ref <PromptDownload>d__);
			return <PromptDownload>d__.<>t__builder.Task;
		}
	}
}
