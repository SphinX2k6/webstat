using System;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.Ui.HotFix;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Launcher.Update
{
	// Token: 0x020044C2 RID: 17602
	public class LanguageUpdateViewAgent : IResourceUpdateView
	{
		// Token: 0x0602E753 RID: 190291 RVA: 0x00AFF400 File Offset: 0x00AFD600
		public UniTask<bool> ShowNotEnoughSpaceConfirmation(long totalSize)
		{
			LanguageUpdateViewAgent.<ShowNotEnoughSpaceConfirmation>d__0 <ShowNotEnoughSpaceConfirmation>d__;
			<ShowNotEnoughSpaceConfirmation>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ShowNotEnoughSpaceConfirmation>d__.<>1__state = -1;
			<ShowNotEnoughSpaceConfirmation>d__.<>t__builder.Start<LanguageUpdateViewAgent.<ShowNotEnoughSpaceConfirmation>d__0>(ref <ShowNotEnoughSpaceConfirmation>d__);
			return <ShowNotEnoughSpaceConfirmation>d__.<>t__builder.Task;
		}

		// Token: 0x0602E754 RID: 190292 RVA: 0x00AFF43B File Offset: 0x00AFD63B
		public void UpdatePatchProgress(long receiveSize, long curProgress, long totalProgress, long downloadSpeed)
		{
			if (this.Implement != null)
			{
				this.Implement.UpdatePatchProgress(receiveSize, curProgress, totalProgress, downloadSpeed);
			}
		}

		// Token: 0x0602E755 RID: 190293 RVA: 0x00AFF455 File Offset: 0x00AFD655
		[NullableContext(2)]
		public void SetImplement(IResourceUpdateView implement)
		{
			this.Implement = implement;
		}

		// Token: 0x0401A60E RID: 108046
		[Nullable(2)]
		private IResourceUpdateView Implement;
	}
}
