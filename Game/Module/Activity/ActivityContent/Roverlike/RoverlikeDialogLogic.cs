using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x020063B6 RID: 25526
	public class RoverlikeDialogLogic
	{
		// Token: 0x060401BA RID: 262586 RVA: 0x0106F088 File Offset: 0x0106D288
		[NullableContext(1)]
		public void PlayAudio(string eventPath, [Nullable(2)] Action finishCallback = null)
		{
			RoverlikeDialogLogic.<>c__DisplayClass3_0 CS$<>8__locals1 = new RoverlikeDialogLogic.<>c__DisplayClass3_0();
			CS$<>8__locals1.<>4__this = this;
			this.Stop();
			string text = Singleton<AudioSystem>.Instance.parseAudioEventPath(eventPath);
			if (text == null)
			{
				if (finishCallback != null)
				{
					finishCallback();
				}
				return;
			}
			RoverlikeDialogLogic.<>c__DisplayClass3_0 CS$<>8__locals2 = CS$<>8__locals1;
			int num = this.PlayVersion + 1;
			this.PlayVersion = num;
			CS$<>8__locals2.currentVersion = num;
			this.FinishCallback = finishCallback;
			FTransformDouble? target = null;
			this.PlayEventResult = Singleton<AudioSystem>.Instance.PostEvent(text, target, new PostEventArgs?(new PostEventArgs
			{
				CallbackMask = new ECallbackMask?(ECallbackMask.EndOfEvent),
				CallbackHandler = delegate(EAkCallbackType callbackType, UAkCallbackInfo callbackInfo)
				{
					if (callbackType == EAkCallbackType.EndOfEvent)
					{
						CS$<>8__locals1.<>4__this.OnFinish(CS$<>8__locals1.currentVersion);
					}
				}
			}));
		}

		// Token: 0x060401BB RID: 262587 RVA: 0x0106F128 File Offset: 0x0106D328
		public void Stop()
		{
			this.PlayVersion++;
			if (this.PlayEventResult != 0)
			{
				Singleton<AudioSystem>.Instance.ExecuteAction(this.PlayEventResult, EAudioActionType.Stop, new ExecuteActionArgs?(new ExecuteActionArgs(new int?(0), null, null)));
				this.PlayEventResult = 0;
			}
			this.FinishCallback = null;
		}

		// Token: 0x060401BC RID: 262588 RVA: 0x0106F184 File Offset: 0x0106D384
		private void OnFinish(int version)
		{
			if (version != this.PlayVersion)
			{
				return;
			}
			this.PlayEventResult = 0;
			Action finishCallback = this.FinishCallback;
			this.FinishCallback = null;
			if (finishCallback == null)
			{
				return;
			}
			finishCallback();
		}

		// Token: 0x04023FAF RID: 147375
		private int PlayEventResult;

		// Token: 0x04023FB0 RID: 147376
		[Nullable(2)]
		private Action FinishCallback;

		// Token: 0x04023FB1 RID: 147377
		private int PlayVersion;
	}
}
