using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Core.Extension;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.LevelLoading
{
	// Token: 0x02005A10 RID: 23056
	[NullableContext(2)]
	[Nullable(0)]
	public class CameraFadeLoading
	{
		// Token: 0x0603A624 RID: 239140 RVA: 0x00ECDB54 File Offset: 0x00ECBD54
		public void EnterInterlude(float duration = 1f, bool needBackToFight = false, bool needCheckOpenView = true, int? treeId = null, EFadeInScreenShowType screenType = EFadeInScreenShowType.Black, Action callback = null)
		{
			float num = Math.Clamp(duration, 0f, 30f);
			this.FadeIn(num * (float)Singleton<TimeUtil>.Instance.InverseMillisecond, needBackToFight, needCheckOpenView, treeId, screenType, callback);
		}

		// Token: 0x0603A625 RID: 239141 RVA: 0x00ECDB90 File Offset: 0x00ECBD90
		public void ExitInterlude(float duration = 1f, Action callback = null)
		{
			float num = Math.Clamp(duration, 0f, 30f);
			this.FadeOut(num * (float)Singleton<TimeUtil>.Instance.InverseMillisecond, callback);
		}

		// Token: 0x0603A626 RID: 239142 RVA: 0x00ECDBC2 File Offset: 0x00ECBDC2
		public bool IsInFade()
		{
			return this.LoadingFade;
		}

		// Token: 0x0603A627 RID: 239143 RVA: 0x00ECDBCA File Offset: 0x00ECBDCA
		public bool IsInFadeOut()
		{
			return ModelBase<LevelLoadingModel>.Instance.CameraFadeHidePromise != null;
		}

		// Token: 0x0603A628 RID: 239144 RVA: 0x00ECDBDC File Offset: 0x00ECBDDC
		private void FadeIn(float duration = 1f, bool needBackToFight = false, bool needCheckOpenView = true, int? treeId = null, EFadeInScreenShowType screenType = EFadeInScreenShowType.Black, Action callback = null)
		{
			if (this.LoadingFade)
			{
				return;
			}
			this.LoadingFade = true;
			APlayerCameraManager characterCameraManager = Global.CharacterCameraManager;
			if (screenType != EFadeInScreenShowType.White)
			{
				if (screenType == EFadeInScreenShowType.Black)
				{
					characterCameraManager.FadeColor = this.ColorBlack;
				}
			}
			else
			{
				characterCameraManager.FadeColor = this.ColorWhite;
			}
			ControllerBase<BlackScreenFadeController>.Instance.ChangeColor(screenType);
			this.AddBlackScreen(duration, needBackToFight, needCheckOpenView, treeId).Finally(delegate()
			{
				Action callback2 = callback;
				if (callback2 == null)
				{
					return;
				}
				callback2();
			}).Forget();
		}

		// Token: 0x0603A629 RID: 239145 RVA: 0x00ECDC60 File Offset: 0x00ECBE60
		private void FadeOut(float duration = 1f, Action callback = null)
		{
			this.RemoveBlackScreen(duration).Finally(delegate()
			{
				this.LoadingFade = false;
				Action callback2 = callback;
				if (callback2 == null)
				{
					return;
				}
				callback2();
			}).Forget();
		}

		// Token: 0x0603A62A RID: 239146 RVA: 0x00ECDCA0 File Offset: 0x00ECBEA0
		private UniTask AddBlackScreen(float num, bool needBackToFight = false, bool needCheckOpenView = true, int? treeId = null)
		{
			CameraFadeLoading.<AddBlackScreen>d__12 <AddBlackScreen>d__;
			<AddBlackScreen>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<AddBlackScreen>d__.num = num;
			<AddBlackScreen>d__.needBackToFight = needBackToFight;
			<AddBlackScreen>d__.needCheckOpenView = needCheckOpenView;
			<AddBlackScreen>d__.treeId = treeId;
			<AddBlackScreen>d__.<>1__state = -1;
			<AddBlackScreen>d__.<>t__builder.Start<CameraFadeLoading.<AddBlackScreen>d__12>(ref <AddBlackScreen>d__);
			return <AddBlackScreen>d__.<>t__builder.Task;
		}

		// Token: 0x0603A62B RID: 239147 RVA: 0x00ECDCFC File Offset: 0x00ECBEFC
		private UniTask RemoveBlackScreen(float num)
		{
			CameraFadeLoading.<RemoveBlackScreen>d__13 <RemoveBlackScreen>d__;
			<RemoveBlackScreen>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RemoveBlackScreen>d__.num = num;
			<RemoveBlackScreen>d__.<>1__state = -1;
			<RemoveBlackScreen>d__.<>t__builder.Start<CameraFadeLoading.<RemoveBlackScreen>d__13>(ref <RemoveBlackScreen>d__);
			return <RemoveBlackScreen>d__.<>t__builder.Task;
		}

		// Token: 0x0603A62C RID: 239148 RVA: 0x00ECDD40 File Offset: 0x00ECBF40
		public EFadeInScreenShowType ColorSearch()
		{
			if (Global.CharacterCameraManager.FadeColor.R >= 0.5f && Global.CharacterCameraManager.FadeColor.G >= 0.5f && Global.CharacterCameraManager.FadeColor.B >= 0.5f)
			{
				return EFadeInScreenShowType.White;
			}
			return EFadeInScreenShowType.Black;
		}

		// Token: 0x0603A62D RID: 239149 RVA: 0x00ECDD94 File Offset: 0x00ECBF94
		public bool SetColor(EFadeInScreenShowType type)
		{
			if (!this.IsInFade())
			{
				return false;
			}
			APlayerCameraManager characterCameraManager = Global.CharacterCameraManager;
			if (type != EFadeInScreenShowType.White)
			{
				if (type == EFadeInScreenShowType.Black)
				{
					characterCameraManager.FadeColor = this.ColorBlack;
				}
			}
			else
			{
				characterCameraManager.FadeColor = this.ColorWhite;
			}
			ControllerBase<BlackScreenFadeController>.Instance.ChangeColor(type);
			return true;
		}

		// Token: 0x040210FA RID: 135418
		private bool LoadingFade;

		// Token: 0x040210FB RID: 135419
		private readonly FLinearColor ColorBlack = new FLinearColor(0f, 0f, 0f, 1f);

		// Token: 0x040210FC RID: 135420
		private readonly FLinearColor ColorWhite = new FLinearColor(1f, 1f, 1f, 1f);

		// Token: 0x040210FD RID: 135421
		private const float INTERLUDE_FADE_IN_TIME = 1f;

		// Token: 0x040210FE RID: 135422
		private const float INTERLUDE_FADE_OUT_TIME = 1f;

		// Token: 0x040210FF RID: 135423
		private const float INTERLUDE_LIMIT_TIME = 30f;
	}
}
