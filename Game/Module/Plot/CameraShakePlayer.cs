using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using UnrealEngine;

namespace CSharpScript.Game.Module.Plot
{
	// Token: 0x0200534C RID: 21324
	public class CameraShakePlayer
	{
		// Token: 0x06036653 RID: 222803 RVA: 0x00DB6E14 File Offset: 0x00DB5014
		[NullableContext(1)]
		public void Play(IFlowCameraShake param)
		{
			if (this.IsPlaying)
			{
				this.Stop();
			}
			this.IsPlaying = true;
			this.LoadingId = Singleton<ResourceSystem>.Instance.LoadAsync<UClass>(param.CameraShakeBp + "_C", delegate([Nullable(2)] UClass csClass, string _)
			{
				this.LoadingId = -1;
				if (csClass == null || !csClass.IsValid())
				{
					return;
				}
				this.CameraShake = Global.CharacterCameraManager.StartMatineeCameraShake(csClass, 1f, ECameraShakePlaySpace.CameraLocal, default(FRotator), 1f);
			}, 100, "js_undefined");
		}

		// Token: 0x06036654 RID: 222804 RVA: 0x00DB6E6C File Offset: 0x00DB506C
		public void Stop()
		{
			if (!this.IsPlaying)
			{
				return;
			}
			this.IsPlaying = false;
			if (this.LoadingId != -1)
			{
				Singleton<ResourceSystem>.Instance.CancelAsyncLoad(this.LoadingId);
				this.LoadingId = -1;
			}
			if (this.CameraShake != null)
			{
				Global.CharacterCameraManager.StopCameraShake(this.CameraShake, true);
				this.CameraShake = null;
			}
		}

		// Token: 0x0401F47E RID: 128126
		private int LoadingId = -1;

		// Token: 0x0401F47F RID: 128127
		[Nullable(2)]
		private UMatineeCameraShake CameraShake;

		// Token: 0x0401F480 RID: 128128
		private bool IsPlaying;
	}
}
