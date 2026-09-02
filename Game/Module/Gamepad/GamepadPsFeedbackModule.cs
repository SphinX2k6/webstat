using System;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Gamepad
{
	// Token: 0x02005D05 RID: 23813
	public class GamepadPsFeedbackModule
	{
		// Token: 0x0603C0AA RID: 245930 RVA: 0x00F3B555 File Offset: 0x00F39755
		private void CancelAsyncLoad()
		{
			if (this.CurrentResourceId != -1)
			{
				Singleton<ResourceSystem>.Instance.CancelAsyncLoad(this.CurrentResourceId);
			}
		}

		// Token: 0x0603C0AB RID: 245931 RVA: 0x00F3B570 File Offset: 0x00F39770
		[NullableContext(1)]
		public UniTask PlayFeedback(ETriggerEffectSide mode, string path)
		{
			GamepadPsFeedbackModule.<PlayFeedback>d__2 <PlayFeedback>d__;
			<PlayFeedback>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayFeedback>d__.<>4__this = this;
			<PlayFeedback>d__.mode = mode;
			<PlayFeedback>d__.path = path;
			<PlayFeedback>d__.<>1__state = -1;
			<PlayFeedback>d__.<>t__builder.Start<GamepadPsFeedbackModule.<PlayFeedback>d__2>(ref <PlayFeedback>d__);
			return <PlayFeedback>d__.<>t__builder.Task;
		}

		// Token: 0x0603C0AC RID: 245932 RVA: 0x00F3B5C3 File Offset: 0x00F397C3
		public void StopFeedback()
		{
			this.CancelAsyncLoad();
			UTriggerEffectBPLibrary.TriggerEffectSetOffMode(Global.PlayerController, ETriggerEffectSide.Both, ETriggerEffectControllerType.DualSense);
		}

		// Token: 0x0603C0AD RID: 245933 RVA: 0x00F3B5D7 File Offset: 0x00F397D7
		public void Clear()
		{
			this.CancelAsyncLoad();
			UTriggerEffectBPLibrary.TriggerEffectSetOffMode(Global.PlayerController, ETriggerEffectSide.Both, ETriggerEffectControllerType.DualSense);
		}

		// Token: 0x04021BA0 RID: 138144
		private int CurrentResourceId = -1;
	}
}
