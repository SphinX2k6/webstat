using System;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Module.LevelLoading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.Letter.View
{
	// Token: 0x02005A20 RID: 23072
	public class LetterBlackScreenSuppressor
	{
		// Token: 0x0603A692 RID: 239250 RVA: 0x00ECF438 File Offset: 0x00ECD638
		public void Suppress()
		{
			if (this.IsSuppressed)
			{
				return;
			}
			if (!ControllerBase<LevelLoadingController>.Instance.CheckIsOpen(new ELoadingPerform?(ELoadingPerform.CameraFade)))
			{
				return;
			}
			this.IsSuppressed = true;
			this.SavedScreenType = ControllerBase<BlackScreenFadeController>.Instance.GetScreenColorType().GetValueOrDefault(EFadeInScreenShowType.Black);
			Global.CharacterCameraManager.FadeAmount = 0f;
			ControllerBase<LevelLoadingController>.Instance.CloseLoading(ELoadingReason.Common, null, null, null);
		}

		// Token: 0x0603A693 RID: 239251 RVA: 0x00ECF4A8 File Offset: 0x00ECD6A8
		public UniTask Restore()
		{
			LetterBlackScreenSuppressor.<Restore>d__4 <Restore>d__;
			<Restore>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Restore>d__.<>4__this = this;
			<Restore>d__.<>1__state = -1;
			<Restore>d__.<>t__builder.Start<LetterBlackScreenSuppressor.<Restore>d__4>(ref <Restore>d__);
			return <Restore>d__.<>t__builder.Task;
		}

		// Token: 0x0402114E RID: 135502
		private const float FadeInDurationSec = 0.001f;

		// Token: 0x0402114F RID: 135503
		private bool IsSuppressed;

		// Token: 0x04021150 RID: 135504
		private EFadeInScreenShowType SavedScreenType = EFadeInScreenShowType.Black;
	}
}
