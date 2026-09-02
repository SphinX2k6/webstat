using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.Module.Plot
{
	// Token: 0x0200534D RID: 21325
	[NullableContext(1)]
	[Nullable(0)]
	public class MovingShotManager
	{
		// Token: 0x06036657 RID: 222807 RVA: 0x00DB6F24 File Offset: 0x00DB5124
		public void Play(IShowTalkCameraMotion param)
		{
			this.Stop();
			EShowTalkCameraMotionType type = param.Type;
			if (type != EShowTalkCameraMotionType.Preset)
			{
				if (type != EShowTalkCameraMotionType.Tween)
				{
					return;
				}
				IShowTalkCameraMotionTween showTalkCameraMotionTween = param as IShowTalkCameraMotionTween;
				this.CurvePlayer.Play(showTalkCameraMotionTween);
				if (showTalkCameraMotionTween.CamShake != null)
				{
					this.ShakePlayer.Play(showTalkCameraMotionTween.CamShake);
				}
			}
			else
			{
				IShowTalkCameraMotionPreset showTalkCameraMotionPreset = param as IShowTalkCameraMotionPreset;
				if (!StringUtils.IsEmpty(showTalkCameraMotionPreset.Sequence))
				{
					this.SequencePlayer.Play(showTalkCameraMotionPreset.Sequence, true);
				}
				if (showTalkCameraMotionPreset.CamShake != null)
				{
					this.ShakePlayer.Play(showTalkCameraMotionPreset.CamShake);
					return;
				}
			}
		}

		// Token: 0x06036658 RID: 222808 RVA: 0x00DB6FB2 File Offset: 0x00DB51B2
		public void Stop()
		{
			this.SequencePlayer.Stop();
			this.CurvePlayer.Stop();
			this.ShakePlayer.Stop();
		}

		// Token: 0x06036659 RID: 222809 RVA: 0x00DB6FD5 File Offset: 0x00DB51D5
		public void OnTick(double delta)
		{
			this.CurvePlayer.OnTick(delta);
		}

		// Token: 0x0401F481 RID: 128129
		private readonly CameraSequencePlayer SequencePlayer = new CameraSequencePlayer();

		// Token: 0x0401F482 RID: 128130
		private readonly CameraCurvePlayer CurvePlayer = new CameraCurvePlayer();

		// Token: 0x0401F483 RID: 128131
		private readonly CameraShakePlayer ShakePlayer = new CameraShakePlayer();
	}
}
