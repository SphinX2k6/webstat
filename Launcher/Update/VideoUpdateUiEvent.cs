using System;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.Update.ResourceDiffUpdate.Updater;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Launcher.Update
{
	// Token: 0x020044D0 RID: 17616
	public class VideoUpdateUiEvent : ResourceDiffUpdateUiEvent
	{
		// Token: 0x0602E79E RID: 190366 RVA: 0x00B01428 File Offset: 0x00AFF628
		[NullableContext(1)]
		[return: Nullable(0)]
		public override UniTask<bool> ShowDialog(bool bSelect, string titleId, string contentId, [Nullable(2)] string leftId, [Nullable(2)] string rightId, [Nullable(2)] string middleId, params string[] contentArgs)
		{
			VideoUpdateUiEvent.<ShowDialog>d__0 <ShowDialog>d__;
			<ShowDialog>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ShowDialog>d__.<>1__state = -1;
			<ShowDialog>d__.<>t__builder.Start<VideoUpdateUiEvent.<ShowDialog>d__0>(ref <ShowDialog>d__);
			return <ShowDialog>d__.<>t__builder.Task;
		}
	}
}
