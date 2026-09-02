using System;
using System.Runtime.CompilerServices;

// Token: 0x02002C34 RID: 11316
[NullableContext(2)]
[Nullable(0)]
public class UiCameraLoadingAnimation
{
	// Token: 0x06016ACB RID: 92875 RVA: 0x0064C2A5 File Offset: 0x0064A4A5
	public void Initialize()
	{
	}

	// Token: 0x06016ACC RID: 92876 RVA: 0x0064C2A8 File Offset: 0x0064A4A8
	public void Play(float timeLength, float manualFocusDistance, float currentAperture)
	{
		this.UiCamera = UiCameraManager.Get();
		this.UiCameraPostEffectComponent = this.UiCamera.GetUiCameraComponent<UiCameraPostEffectComponent>();
		this.CurrentTime = 0f;
		this.TimeLength = timeLength;
		this.SourceFocusDistance = this.UiCameraPostEffectComponent.GetManualFocusDistance();
		this.SourceAperture = this.UiCameraPostEffectComponent.GetCurrentAperture();
		this.TargetFocusDistance = manualFocusDistance;
		this.TargetAperture = currentAperture;
		this.IsPlaying = true;
	}

	// Token: 0x06016ACD RID: 92877 RVA: 0x0064C31A File Offset: 0x0064A51A
	public void Stop()
	{
		this.TimeLength = 0f;
		this.IsPlaying = false;
		this.PlayPromise = null;
	}

	// Token: 0x06016ACE RID: 92878 RVA: 0x0064C338 File Offset: 0x0064A538
	public void Tick(float delta)
	{
		if (this.TimeLength == 0f || !this.IsPlaying)
		{
			return;
		}
		if (this.CurrentTime >= this.TimeLength)
		{
			CustomPromise<bool> playPromise = this.PlayPromise;
			if (playPromise != null)
			{
				playPromise.SetResult(true);
			}
			this.Stop();
			return;
		}
		float cameraFocalDistance = Singleton<MathUtils>.Instance.Lerp(this.SourceFocusDistance, this.TargetFocusDistance, this.CurrentTime / this.TimeLength);
		float cameraAperture = Singleton<MathUtils>.Instance.Lerp(this.SourceAperture, this.TargetAperture, this.CurrentTime / this.TimeLength);
		this.UiCameraPostEffectComponent.SetCameraFocalDistance(cameraFocalDistance);
		this.UiCameraPostEffectComponent.SetCameraAperture(cameraAperture);
		this.CurrentTime += 10f;
	}

	// Token: 0x0400AEE5 RID: 44773
	private float CurrentTime;

	// Token: 0x0400AEE6 RID: 44774
	private float TimeLength;

	// Token: 0x0400AEE7 RID: 44775
	private float TargetFocusDistance;

	// Token: 0x0400AEE8 RID: 44776
	private float TargetAperture;

	// Token: 0x0400AEE9 RID: 44777
	private float SourceFocusDistance;

	// Token: 0x0400AEEA RID: 44778
	private float SourceAperture;

	// Token: 0x0400AEEB RID: 44779
	public bool IsPlaying;

	// Token: 0x0400AEEC RID: 44780
	private CustomPromise<bool> PlayPromise;

	// Token: 0x0400AEED RID: 44781
	private UiCamera UiCamera;

	// Token: 0x0400AEEE RID: 44782
	private UiCameraPostEffectComponent UiCameraPostEffectComponent;
}
