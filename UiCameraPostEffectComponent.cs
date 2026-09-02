using System;
using UnrealEngine;

// Token: 0x02002C46 RID: 11334
public class UiCameraPostEffectComponent : UiCameraComponent
{
	// Token: 0x06016B57 RID: 93015 RVA: 0x0064E3B2 File Offset: 0x0064C5B2
	public void SetCameraFocusMethod(ECameraFocusMethod focusMethod)
	{
		this.CineCameraComponent.FocusSettings.FocusMethod = focusMethod;
	}

	// Token: 0x06016B58 RID: 93016 RVA: 0x0064E3C5 File Offset: 0x0064C5C5
	public void SetCameraFieldOfView(float fieldOfView)
	{
		this.CineCameraComponent.SetFieldOfView(fieldOfView);
	}

	// Token: 0x06016B59 RID: 93017 RVA: 0x0064E3D3 File Offset: 0x0064C5D3
	public void SetCameraFocalDistance(float focalDistance)
	{
		this.CineCameraComponent.FocusSettings.ManualFocusDistance = focalDistance;
	}

	// Token: 0x06016B5A RID: 93018 RVA: 0x0064E3E6 File Offset: 0x0064C5E6
	public void SetCameraCurrentFocalLength(float currentFocalLength)
	{
		this.CineCameraComponent.CurrentFocalLength = currentFocalLength;
	}

	// Token: 0x06016B5B RID: 93019 RVA: 0x0064E3F4 File Offset: 0x0064C5F4
	public void SetCameraAperture(float aperture)
	{
		this.CineCameraComponent.CurrentAperture = aperture;
	}

	// Token: 0x06016B5C RID: 93020 RVA: 0x0064E402 File Offset: 0x0064C602
	public void SetCameraFocalRegion(float focalRegion)
	{
		this.CineCameraComponent.CurrentFocalRegion = focalRegion;
	}

	// Token: 0x06016B5D RID: 93021 RVA: 0x0064E410 File Offset: 0x0064C610
	public void SetCameraPostProcessBlendWeight(float postProcessBlendWeight)
	{
		this.CineCameraComponent.SetPostProcessBlendWeight(postProcessBlendWeight);
	}

	// Token: 0x06016B5E RID: 93022 RVA: 0x0064E41E File Offset: 0x0064C61E
	public float GetFieldOfView()
	{
		return this.CineCameraComponent.FieldOfView;
	}

	// Token: 0x06016B5F RID: 93023 RVA: 0x0064E42B File Offset: 0x0064C62B
	public float GetManualFocusDistance()
	{
		return this.CineCameraComponent.FocusSettings.ManualFocusDistance;
	}

	// Token: 0x06016B60 RID: 93024 RVA: 0x0064E43D File Offset: 0x0064C63D
	public float GetCurrentAperture()
	{
		return this.CineCameraComponent.CurrentAperture;
	}

	// Token: 0x06016B61 RID: 93025 RVA: 0x0064E44A File Offset: 0x0064C64A
	public float GetPostProcessBlendWeight()
	{
		return this.CineCameraComponent.PostProcessBlendWeight;
	}
}
