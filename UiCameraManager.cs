using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02002C4C RID: 11340
public class UiCameraManager : IStaticVariableResetter
{
	// Token: 0x06016B8B RID: 93067 RVA: 0x0064EBA0 File Offset: 0x0064CDA0
	static UiCameraManager()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(UiCameraManager.CreateStaticDefaultValue), new Action(UiCameraManager.ResetStaticDefaultValue));
	}

	// Token: 0x06016B8C RID: 93068 RVA: 0x0064EBBF File Offset: 0x0064CDBF
	public static void CreateStaticDefaultValue()
	{
	}

	// Token: 0x06016B8D RID: 93069 RVA: 0x0064EBC1 File Offset: 0x0064CDC1
	public static void ResetStaticDefaultValue()
	{
		UiCameraManager.UiCamera = null;
	}

	// Token: 0x06016B8E RID: 93070 RVA: 0x0064EBC9 File Offset: 0x0064CDC9
	public static void Initialize()
	{
	}

	// Token: 0x06016B8F RID: 93071 RVA: 0x0064EBCB File Offset: 0x0064CDCB
	public static void Clear()
	{
		UiCamera uiCamera = UiCameraManager.UiCamera;
		if (uiCamera != null)
		{
			uiCamera.Destroy(0f, EViewTargetBlendFunction.VTBlend_Linear, 0f);
		}
		UiCameraManager.UiCamera = null;
	}

	// Token: 0x06016B90 RID: 93072 RVA: 0x0064EBEE File Offset: 0x0064CDEE
	[NullableContext(1)]
	public static UiCamera Get()
	{
		if (UiCameraManager.UiCamera == null)
		{
			UiCameraManager.UiCamera = new UiCamera();
			UiCameraManager.UiCamera.Initialize();
		}
		return UiCameraManager.UiCamera;
	}

	// Token: 0x06016B91 RID: 93073 RVA: 0x0064EC11 File Offset: 0x0064CE11
	public static void Destroy(float blendTime = 0f, EViewTargetBlendFunction blendFunction = EViewTargetBlendFunction.VTBlend_Linear, float blendExp = 0f)
	{
		UiCamera uiCamera = UiCameraManager.UiCamera;
		if (uiCamera != null)
		{
			uiCamera.Destroy(blendTime, blendFunction, blendExp);
		}
		UiCameraManager.UiCamera = null;
	}

	// Token: 0x0400AF3D RID: 44861
	[Nullable(2)]
	private static UiCamera UiCamera;
}
