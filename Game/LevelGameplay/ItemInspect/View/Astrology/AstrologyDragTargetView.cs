using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.ItemInspect.View.Astrology
{
	// Token: 0x02006E4D RID: 28237
	[NullableContext(2)]
	[Nullable(0)]
	public class AstrologyDragTargetView : UiPanelBase
	{
		// Token: 0x0604487A RID: 280698 RVA: 0x011D059E File Offset: 0x011CE79E
		protected override void OnStart()
		{
			this.SequencePlayer = new UiSequencePlayer(this.RootItem);
			this.SequencePlayer.BindOnEndSequenceEvent(new Action<string>(this.OnSequenceEnd));
		}

		// Token: 0x0604487B RID: 280699 RVA: 0x011D05C8 File Offset: 0x011CE7C8
		protected override void OnBeforeShow()
		{
			this.HasPlayedFinish = false;
			UiSequencePlayer sequencePlayer = this.SequencePlayer;
			if (sequencePlayer == null)
			{
				return;
			}
			sequencePlayer.PlaySequencePurely("Start", false, false);
		}

		// Token: 0x0604487C RID: 280700 RVA: 0x011D05E8 File Offset: 0x011CE7E8
		protected override void OnBeforeDestroy()
		{
			this.ClearFinishFallbackTimer();
			this.ClearCloseFallbackTimer();
			this.ClearHideFallbackTimer();
			this.OnFinishAnimEnd = null;
			this.OnCloseAnimEnd = null;
			UiSequencePlayer sequencePlayer = this.SequencePlayer;
			if (sequencePlayer != null)
			{
				sequencePlayer.Clear();
			}
			this.SequencePlayer = null;
		}

		// Token: 0x0604487D RID: 280701 RVA: 0x011D0622 File Offset: 0x011CE822
		[NullableContext(1)]
		public void SetScreenPosition(Vector2D position)
		{
			UUIItem rootItem = this.RootItem;
			if (rootItem == null)
			{
				return;
			}
			rootItem.SetAnchorOffset(position.ToUeVector2D(false));
		}

		// Token: 0x0604487E RID: 280702 RVA: 0x011D063B File Offset: 0x011CE83B
		public void PlayShow()
		{
			if (this.HasPlayedClose || base.IsDestroy)
			{
				return;
			}
			this.CancelHide();
			base.SetUiActive(true);
			UiSequencePlayer sequencePlayer = this.SequencePlayer;
			if (sequencePlayer == null)
			{
				return;
			}
			sequencePlayer.PlaySequencePurely("Start", false, false);
		}

		// Token: 0x0604487F RID: 280703 RVA: 0x011D0674 File Offset: 0x011CE874
		public void PlayCloseThenHide()
		{
			if (this.IsHidePlaying || this.HasPlayedClose || base.IsDestroy)
			{
				return;
			}
			this.IsHidePlaying = true;
			UiSequencePlayer sequencePlayer = this.SequencePlayer;
			if (sequencePlayer != null)
			{
				sequencePlayer.PlaySequencePurely("Close", false, false);
			}
			this.HideFallbackTimer = TimerSystem.Instance.Delay(new TTimerAction(this.HideSelf), 1500f, null, null, true, 1f);
		}

		// Token: 0x06044880 RID: 280704 RVA: 0x011D06E2 File Offset: 0x011CE8E2
		public void HideImmediately()
		{
			this.CancelHide();
			base.SetUiActive(false);
		}

		// Token: 0x06044881 RID: 280705 RVA: 0x011D06F4 File Offset: 0x011CE8F4
		public void PlayFinish(Action onAnimEnd = null)
		{
			if (this.HasPlayedFinish)
			{
				return;
			}
			this.HasPlayedFinish = true;
			this.OnFinishAnimEnd = onAnimEnd;
			UiSequencePlayer sequencePlayer = this.SequencePlayer;
			if (sequencePlayer != null)
			{
				sequencePlayer.PlaySequencePurely("Finish", false, false);
			}
			if (onAnimEnd != null)
			{
				this.FinishFallbackTimer = TimerSystem.Instance.Delay(new TTimerAction(this.NotifyFinishAnimEnd), 1500f, null, null, true, 1f);
			}
		}

		// Token: 0x06044882 RID: 280706 RVA: 0x011D075C File Offset: 0x011CE95C
		public void PlayCloseThenDestroy(Action onAnimEnd = null)
		{
			if (this.HasPlayedClose || base.IsDestroy)
			{
				return;
			}
			this.HasPlayedClose = true;
			this.OnCloseAnimEnd = onAnimEnd;
			this.ClearFinishFallbackTimer();
			this.OnFinishAnimEnd = null;
			this.CancelHide();
			UiSequencePlayer sequencePlayer = this.SequencePlayer;
			if (sequencePlayer != null)
			{
				sequencePlayer.PlaySequencePurely("Close", false, false);
			}
			this.CloseFallbackTimer = TimerSystem.Instance.Delay(new TTimerAction(this.DestroySelf), 1500f, null, null, true, 1f);
		}

		// Token: 0x06044883 RID: 280707 RVA: 0x011D07DC File Offset: 0x011CE9DC
		[NullableContext(1)]
		private void OnSequenceEnd(string sequenceName)
		{
			if (sequenceName == "Finish")
			{
				this.NotifyFinishAnimEnd();
				return;
			}
			if (sequenceName == "Close")
			{
				if (this.HasPlayedClose)
				{
					this.DestroySelf();
					return;
				}
				if (this.IsHidePlaying)
				{
					this.HideSelf();
				}
			}
		}

		// Token: 0x06044884 RID: 280708 RVA: 0x011D081C File Offset: 0x011CEA1C
		private void NotifyFinishAnimEnd()
		{
			this.ClearFinishFallbackTimer();
			Action onFinishAnimEnd = this.OnFinishAnimEnd;
			this.OnFinishAnimEnd = null;
			if (onFinishAnimEnd == null)
			{
				return;
			}
			onFinishAnimEnd();
		}

		// Token: 0x06044885 RID: 280709 RVA: 0x011D083B File Offset: 0x011CEA3B
		private void NotifyFinishAnimEnd(float _)
		{
			this.NotifyFinishAnimEnd();
		}

		// Token: 0x06044886 RID: 280710 RVA: 0x011D0843 File Offset: 0x011CEA43
		private void DestroySelf()
		{
			this.ClearCloseFallbackTimer();
			Action onCloseAnimEnd = this.OnCloseAnimEnd;
			this.OnCloseAnimEnd = null;
			if (!base.IsDestroy)
			{
				base.Destroy(null);
			}
			if (onCloseAnimEnd == null)
			{
				return;
			}
			onCloseAnimEnd();
		}

		// Token: 0x06044887 RID: 280711 RVA: 0x011D0871 File Offset: 0x011CEA71
		private void DestroySelf(float _)
		{
			this.DestroySelf();
		}

		// Token: 0x06044888 RID: 280712 RVA: 0x011D0879 File Offset: 0x011CEA79
		private void HideSelf()
		{
			this.ClearHideFallbackTimer();
			this.IsHidePlaying = false;
			base.SetUiActive(false);
		}

		// Token: 0x06044889 RID: 280713 RVA: 0x011D088F File Offset: 0x011CEA8F
		private void HideSelf(float _)
		{
			this.HideSelf();
		}

		// Token: 0x0604488A RID: 280714 RVA: 0x011D0897 File Offset: 0x011CEA97
		private void CancelHide()
		{
			this.ClearHideFallbackTimer();
			this.IsHidePlaying = false;
		}

		// Token: 0x0604488B RID: 280715 RVA: 0x011D08A6 File Offset: 0x011CEAA6
		private void ClearFinishFallbackTimer()
		{
			TimerHandle finishFallbackTimer = this.FinishFallbackTimer;
			if (finishFallbackTimer != null)
			{
				finishFallbackTimer.Remove();
			}
			this.FinishFallbackTimer = null;
		}

		// Token: 0x0604488C RID: 280716 RVA: 0x011D08C1 File Offset: 0x011CEAC1
		private void ClearCloseFallbackTimer()
		{
			TimerHandle closeFallbackTimer = this.CloseFallbackTimer;
			if (closeFallbackTimer != null)
			{
				closeFallbackTimer.Remove();
			}
			this.CloseFallbackTimer = null;
		}

		// Token: 0x0604488D RID: 280717 RVA: 0x011D08DC File Offset: 0x011CEADC
		private void ClearHideFallbackTimer()
		{
			TimerHandle hideFallbackTimer = this.HideFallbackTimer;
			if (hideFallbackTimer != null)
			{
				hideFallbackTimer.Remove();
			}
			this.HideFallbackTimer = null;
		}

		// Token: 0x04026257 RID: 156247
		private const int FINISH_ANIM_FALLBACK_MS = 1500;

		// Token: 0x04026258 RID: 156248
		private const int CLOSE_ANIM_FALLBACK_MS = 1500;

		// Token: 0x04026259 RID: 156249
		private UiSequencePlayer SequencePlayer;

		// Token: 0x0402625A RID: 156250
		private bool HasPlayedFinish;

		// Token: 0x0402625B RID: 156251
		private bool HasPlayedClose;

		// Token: 0x0402625C RID: 156252
		private bool IsHidePlaying;

		// Token: 0x0402625D RID: 156253
		private Action OnFinishAnimEnd;

		// Token: 0x0402625E RID: 156254
		private Action OnCloseAnimEnd;

		// Token: 0x0402625F RID: 156255
		private TimerHandle FinishFallbackTimer;

		// Token: 0x04026260 RID: 156256
		private TimerHandle CloseFallbackTimer;

		// Token: 0x04026261 RID: 156257
		private TimerHandle HideFallbackTimer;
	}
}
