using System;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002968 RID: 10600
public class ScreenShotManager : IStaticVariableResetter
{
	// Token: 0x06015140 RID: 86336 RVA: 0x005D542F File Offset: 0x005D362F
	static ScreenShotManager()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(ScreenShotManager.CreateStaticDefaultValue), new Action(ScreenShotManager.ResetStaticDefaultValue));
	}

	// Token: 0x06015141 RID: 86337 RVA: 0x005D544E File Offset: 0x005D364E
	public static void CreateStaticDefaultValue()
	{
		ScreenShotManager.GameScreenshotTask = null;
	}

	// Token: 0x06015142 RID: 86338 RVA: 0x005D5456 File Offset: 0x005D3656
	public static void ResetStaticDefaultValue()
	{
		ScreenShotManager.GameScreenshotTask = null;
	}

	// Token: 0x06015143 RID: 86339 RVA: 0x005D545E File Offset: 0x005D365E
	public static void Clear()
	{
		ScreenShotManager.ResetScreenShot();
	}

	// Token: 0x06015144 RID: 86340 RVA: 0x005D5468 File Offset: 0x005D3668
	[NullableContext(1)]
	[return: Nullable(2)]
	public static UGameScreenshotTask PrepareTakeScreenshot(string relativePath, float minX, float minY, float maxX, float maxY, bool saveFile, float screenshotResolutionX = 0f, float screenshotResolutionY = 0f, int resolutionMultiplier = 1)
	{
		ScreenShotManager.ResetScreenShot();
		Vector2D vector2D = Vector2D.Create((double)minX, (double)minY);
		Vector2D vector2D2 = Vector2D.Create((double)maxX, (double)maxY);
		ScreenShotManager.GameScreenshotTask = UKuroGameScreenshotBPLibrary.PrepareTakeScreenshot(GlobalData.World, relativePath, vector2D.ToUeVector2D(false), vector2D2.ToUeVector2D(false), screenshotResolutionX, screenshotResolutionY, saveFile, resolutionMultiplier);
		return ScreenShotManager.GameScreenshotTask;
	}

	// Token: 0x06015145 RID: 86341 RVA: 0x005D54BA File Offset: 0x005D36BA
	public static void ResetScreenShot()
	{
		if (ScreenShotManager.GameScreenshotTask != null && ScreenShotManager.GameScreenshotTask.IsValid())
		{
			ScreenShotManager.GameScreenshotTask.Reset();
		}
		ScreenShotManager.GameScreenshotTask = null;
	}

	// Token: 0x06015146 RID: 86342 RVA: 0x005D54DF File Offset: 0x005D36DF
	public static void RequestIOSPhotoLibraryAuthorization()
	{
		UGameScreenshotTask gameScreenshotTask = ScreenShotManager.GameScreenshotTask;
		if (gameScreenshotTask == null)
		{
			return;
		}
		gameScreenshotTask.RequestIOSPhotoLibraryAuthorization();
	}

	// Token: 0x06015147 RID: 86343 RVA: 0x005D54F0 File Offset: 0x005D36F0
	[return: Nullable(new byte[]
	{
		0,
		1
	})]
	public static UniTask<UTexture2D> TakeFullScreenShotToTextureAsync()
	{
		FVector2D viewportSize = UWidgetLayoutLibrary.GetViewportSize(GlobalData.World);
		return ScreenShotManager.TakeScreenShotToTextureHotFixedAsync(0f, 0f, viewportSize.X, viewportSize.Y);
	}

	// Token: 0x06015148 RID: 86344 RVA: 0x005D5524 File Offset: 0x005D3724
	[return: Nullable(new byte[]
	{
		0,
		1
	})]
	public static UniTask<UTexture2D> TakeScreenShotToTextureHotFixedAsync(float minX, float minY, float maxX, float maxY)
	{
		ScreenShotManager.<TakeScreenShotToTextureHotFixedAsync>d__9 <TakeScreenShotToTextureHotFixedAsync>d__;
		<TakeScreenShotToTextureHotFixedAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<UTexture2D>.Create();
		<TakeScreenShotToTextureHotFixedAsync>d__.minX = minX;
		<TakeScreenShotToTextureHotFixedAsync>d__.minY = minY;
		<TakeScreenShotToTextureHotFixedAsync>d__.maxX = maxX;
		<TakeScreenShotToTextureHotFixedAsync>d__.maxY = maxY;
		<TakeScreenShotToTextureHotFixedAsync>d__.<>1__state = -1;
		<TakeScreenShotToTextureHotFixedAsync>d__.<>t__builder.Start<ScreenShotManager.<TakeScreenShotToTextureHotFixedAsync>d__9>(ref <TakeScreenShotToTextureHotFixedAsync>d__);
		return <TakeScreenShotToTextureHotFixedAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06015149 RID: 86345 RVA: 0x005D557F File Offset: 0x005D377F
	[NullableContext(1)]
	public static UTexture2D CreateTextureFromBuffer(int minX, int minY, int maxX, int maxY)
	{
		return ULGUIBPLibrary.CreateTexture2DFromBuffer(minX, maxX, minY, maxY);
	}

	// Token: 0x0400A24F RID: 41551
	[Nullable(2)]
	private static UGameScreenshotTask GameScreenshotTask;
}
