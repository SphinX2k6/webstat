using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Ui
{
	// Token: 0x02004A36 RID: 18998
	[NullableContext(1)]
	[Nullable(0)]
	public class SceneUiView : UiPanelBase
	{
		// Token: 0x17008477 RID: 33911
		// (get) Token: 0x06031A4C RID: 203340 RVA: 0x00C5E492 File Offset: 0x00C5C692
		public bool FaceCamera
		{
			get
			{
				return this.FaceCameraInternal;
			}
		}

		// Token: 0x06031A4D RID: 203341 RVA: 0x00C5E49C File Offset: 0x00C5C69C
		public void SetFaceCamera(bool enable)
		{
			if (this.FaceCameraInternal == enable)
			{
				return;
			}
			this.FaceCameraInternal = enable;
			if (!enable && this.InitialWorldRotation != null && this.RootItem != null && this.RootItem.IsValid())
			{
				UUIItem rootItem = this.RootItem;
				FRotator value = this.InitialWorldRotation.Value;
				rootItem.SetUIWorldRotation(value);
			}
		}

		// Token: 0x06031A4E RID: 203342 RVA: 0x00C5E4F8 File Offset: 0x00C5C6F8
		public void AttachToAnchor(AActor anchor)
		{
			AActor originalActor = base.GetOriginalActor();
			if (originalActor == null || !originalActor.IsValid() || anchor == null || !anchor.IsValid())
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Scene3dUi;
				ELogAuthor author = ELogAuthor.HYF;
				string message = "[SceneUiView.AttachToAnchor]actor无效";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("view", base.GetType().Name);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			originalActor.K2_AttachToActor(anchor, FName.NAME_None, EAttachmentRule.SnapToTarget, EAttachmentRule.SnapToTarget, EAttachmentRule.SnapToTarget, false, true);
			AActor rootActor = base.GetRootActor();
			this.InitialWorldRotation = ((rootActor != null) ? new FRotator?(rootActor.K2_GetActorRotation()) : null);
		}

		// Token: 0x06031A4F RID: 203343 RVA: 0x00C5E590 File Offset: 0x00C5C790
		public void UpdateFacing(float cameraYaw, float cameraPitch)
		{
			AActor rootActor = base.GetRootActor();
			if (rootActor == null || !rootActor.IsValid() || this.RootItem == null || !this.RootItem.IsValid())
			{
				return;
			}
			if (this.InitialWorldRotation == null)
			{
				this.InitialWorldRotation = new FRotator?(rootActor.K2_GetActorRotation());
			}
			if (this.FacingRotation == null)
			{
				this.FacingRotation = new FRotator?(rootActor.K2_GetActorRotation());
			}
			FRotator value = this.FacingRotation.Value;
			value.Roll = cameraPitch - 90f;
			value.Pitch = 0f;
			value.Yaw = cameraYaw + 90f;
			this.FacingRotation = new FRotator?(value);
			this.RootItem.SetUIWorldRotation(value);
		}

		// Token: 0x06031A50 RID: 203344 RVA: 0x00C5E64E File Offset: 0x00C5C84E
		protected override void OnBeforeCreateImplement()
		{
			this.UiViewSequence = new UiBehaviorLevelSequence(this);
			base.AddUiBehavior(this.UiViewSequence);
		}

		// Token: 0x06031A51 RID: 203345 RVA: 0x00C5E668 File Offset: 0x00C5C868
		protected override UniTask OnShowAsyncImplementImplement()
		{
			SceneUiView.<OnShowAsyncImplementImplement>d__12 <OnShowAsyncImplementImplement>d__;
			<OnShowAsyncImplementImplement>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnShowAsyncImplementImplement>d__.<>4__this = this;
			<OnShowAsyncImplementImplement>d__.<>1__state = -1;
			<OnShowAsyncImplementImplement>d__.<>t__builder.Start<SceneUiView.<OnShowAsyncImplementImplement>d__12>(ref <OnShowAsyncImplementImplement>d__);
			return <OnShowAsyncImplementImplement>d__.<>t__builder.Task;
		}

		// Token: 0x06031A52 RID: 203346 RVA: 0x00C5E6AC File Offset: 0x00C5C8AC
		protected override UniTask OnHideAsyncImplementImplement()
		{
			SceneUiView.<OnHideAsyncImplementImplement>d__13 <OnHideAsyncImplementImplement>d__;
			<OnHideAsyncImplementImplement>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnHideAsyncImplementImplement>d__.<>4__this = this;
			<OnHideAsyncImplementImplement>d__.<>1__state = -1;
			<OnHideAsyncImplementImplement>d__.<>t__builder.Start<SceneUiView.<OnHideAsyncImplementImplement>d__13>(ref <OnHideAsyncImplementImplement>d__);
			return <OnHideAsyncImplementImplement>d__.<>t__builder.Task;
		}

		// Token: 0x06031A53 RID: 203347 RVA: 0x00C5E6F0 File Offset: 0x00C5C8F0
		protected UniTask PlaySequenceAsync(string sequenceName, bool playReverse = false, float? playRate = null)
		{
			SceneUiView.<PlaySequenceAsync>d__14 <PlaySequenceAsync>d__;
			<PlaySequenceAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlaySequenceAsync>d__.<>4__this = this;
			<PlaySequenceAsync>d__.sequenceName = sequenceName;
			<PlaySequenceAsync>d__.playReverse = playReverse;
			<PlaySequenceAsync>d__.playRate = playRate;
			<PlaySequenceAsync>d__.<>1__state = -1;
			<PlaySequenceAsync>d__.<>t__builder.Start<SceneUiView.<PlaySequenceAsync>d__14>(ref <PlaySequenceAsync>d__);
			return <PlaySequenceAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06031A54 RID: 203348 RVA: 0x00C5E74B File Offset: 0x00C5C94B
		public void SkipPlayingSequence()
		{
			UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
			if (uiViewSequence == null)
			{
				return;
			}
			uiViewSequence.StopPrevSequence(true, true);
		}

		// Token: 0x06031A55 RID: 203349 RVA: 0x00C5E75F File Offset: 0x00C5C95F
		protected virtual UniTask OnPlayingStartSequenceAsync()
		{
			return UniTask.CompletedTask;
		}

		// Token: 0x06031A56 RID: 203350 RVA: 0x00C5E766 File Offset: 0x00C5C966
		protected virtual void OnAfterPlayStartSequence()
		{
		}

		// Token: 0x06031A57 RID: 203351 RVA: 0x00C5E768 File Offset: 0x00C5C968
		protected virtual void OnBeforePlayCloseSequence()
		{
		}

		// Token: 0x06031A58 RID: 203352 RVA: 0x00C5E76A File Offset: 0x00C5C96A
		protected virtual UniTask OnPlayingCloseSequenceAsync()
		{
			return UniTask.CompletedTask;
		}

		// Token: 0x06031A59 RID: 203353 RVA: 0x00C5E771 File Offset: 0x00C5C971
		protected virtual UniTask OnPlayingHideSequenceAsync()
		{
			return UniTask.CompletedTask;
		}

		// Token: 0x06031A5A RID: 203354 RVA: 0x00C5E778 File Offset: 0x00C5C978
		[NullableContext(2)]
		protected string GetOpenParamString()
		{
			return this.OpenParam as string;
		}

		// Token: 0x06031A5B RID: 203355 RVA: 0x00C5E785 File Offset: 0x00C5C985
		[return: Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		protected Dictionary<string, string> GetOpenParamMap()
		{
			return this.OpenParam as Dictionary<string, string>;
		}

		// Token: 0x0401CE48 RID: 118344
		[Nullable(2)]
		protected UiBehaviorLevelSequence UiViewSequence;

		// Token: 0x0401CE49 RID: 118345
		public bool LastHide;

		// Token: 0x0401CE4A RID: 118346
		private bool FirstShow = true;

		// Token: 0x0401CE4B RID: 118347
		private bool FaceCameraInternal;

		// Token: 0x0401CE4C RID: 118348
		private FRotator? FacingRotation;

		// Token: 0x0401CE4D RID: 118349
		private FRotator? InitialWorldRotation;
	}
}
