using System;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.DiffPatch.Update;
using CSharpScript.Launcher.Ui.HotFix;
using CSharpScript.Launcher.Update;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Launcher.DiffPatch.Procedure
{
	// Token: 0x0200463A RID: 17978
	public class MobileDiffPatchProcedure : BaseDiffPatchProcedure
	{
		// Token: 0x0602EF43 RID: 192323 RVA: 0x00B1FED1 File Offset: 0x00B1E0D1
		[NullableContext(1)]
		public MobileDiffPatchProcedure(AppPathMisc pathMisc, HotFixManager viewMgr) : base(pathMisc, viewMgr)
		{
		}

		// Token: 0x0602EF44 RID: 192324 RVA: 0x00B1FEDC File Offset: 0x00B1E0DC
		protected virtual UniTask<bool> PromptDownload(long updateSize, [Nullable(1)] DiffUpdate update)
		{
			MobileDiffPatchProcedure.<PromptDownload>d__1 <PromptDownload>d__;
			<PromptDownload>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<PromptDownload>d__.updateSize = updateSize;
			<PromptDownload>d__.update = update;
			<PromptDownload>d__.<>1__state = -1;
			<PromptDownload>d__.<>t__builder.Start<MobileDiffPatchProcedure.<PromptDownload>d__1>(ref <PromptDownload>d__);
			return <PromptDownload>d__.<>t__builder.Task;
		}

		// Token: 0x0602EF45 RID: 192325 RVA: 0x00B1FF28 File Offset: 0x00B1E128
		public override UniTask<bool> UpdateResource(bool bUseBgDownload, [Nullable(1)] DiffUpdate update, bool bIsLauncher)
		{
			MobileDiffPatchProcedure.<UpdateResource>d__2 <UpdateResource>d__;
			<UpdateResource>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<UpdateResource>d__.<>4__this = this;
			<UpdateResource>d__.bUseBgDownload = bUseBgDownload;
			<UpdateResource>d__.update = update;
			<UpdateResource>d__.bIsLauncher = bIsLauncher;
			<UpdateResource>d__.<>1__state = -1;
			<UpdateResource>d__.<>t__builder.Start<MobileDiffPatchProcedure.<UpdateResource>d__2>(ref <UpdateResource>d__);
			return <UpdateResource>d__.<>t__builder.Task;
		}
	}
}
