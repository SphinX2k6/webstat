using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Ui;
using CSharpScript.Launcher.Platform;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;
using UnrealEngine.Extension;

// Token: 0x020025BD RID: 9661
[NullableContext(2)]
[Nullable(0)]
public class FightPhotoSaveView : UiViewBase
{
	// Token: 0x06012E19 RID: 77337 RVA: 0x00538DFA File Offset: 0x00536FFA
	[NullableContext(1)]
	public FightPhotoSaveView(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x06012E1A RID: 77338 RVA: 0x00538E10 File Offset: 0x00537010
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(2, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUITexture)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIText)),
			new ValueTuple<int, Type>(9, typeof(UUITexture)),
			new ValueTuple<int, Type>(10, typeof(UUIItem)),
			new ValueTuple<int, Type>(11, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action(this.OnCloseBtnClick)),
			new ValueTuple<int, Delegate>(2, new Action(this.OnClickedConfirmButton)),
			new ValueTuple<int, Delegate>(1, new Action<EToggleState>(this.OnClickPersonalInfoShow))
		};
	}

	// Token: 0x06012E1B RID: 77339 RVA: 0x00538F88 File Offset: 0x00537188
	protected override UniTask OnBeforeStartAsync()
	{
		FightPhotoSaveView.<OnBeforeStartAsync>d__9 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<FightPhotoSaveView.<OnBeforeStartAsync>d__9>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06012E1C RID: 77340 RVA: 0x00538FCC File Offset: 0x005371CC
	private void RefreshSaveButton()
	{
		bool flag = Singleton<Info>.Instance.IsXSXPlatform();
		UUIButtonComponent button = base.GetButton(2);
		if (button == null)
		{
			return;
		}
		button.RootUIComp.Get().SetUIActive(!flag);
	}

	// Token: 0x06012E1D RID: 77341 RVA: 0x00539008 File Offset: 0x00537208
	private UniTask CaptureForPreviewAndMissionAsync()
	{
		FightPhotoSaveView.<CaptureForPreviewAndMissionAsync>d__11 <CaptureForPreviewAndMissionAsync>d__;
		<CaptureForPreviewAndMissionAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CaptureForPreviewAndMissionAsync>d__.<>4__this = this;
		<CaptureForPreviewAndMissionAsync>d__.<>1__state = -1;
		<CaptureForPreviewAndMissionAsync>d__.<>t__builder.Start<FightPhotoSaveView.<CaptureForPreviewAndMissionAsync>d__11>(ref <CaptureForPreviewAndMissionAsync>d__);
		return <CaptureForPreviewAndMissionAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06012E1E RID: 77342 RVA: 0x0053904B File Offset: 0x0053724B
	protected override void OnBeforeHide()
	{
		base.OnBeforeHide();
		PhotographController.OnFightPhotoSaveViewClose();
	}

	// Token: 0x06012E1F RID: 77343 RVA: 0x00539058 File Offset: 0x00537258
	private void RefreshPhotoPanel()
	{
		UUIItem item = base.GetItem(3);
		FVector2D viewportSize = UWidgetLayoutLibrary.GetViewportSize(GlobalData.World);
		float viewportScale = UWidgetLayoutLibrary.GetViewportScale(GlobalData.World);
		item.SetWidth(viewportSize.X / (viewportScale * 1.5f));
		item.SetHeight(viewportSize.Y / (viewportScale * 1.5f));
	}

	// Token: 0x06012E20 RID: 77344 RVA: 0x005390AC File Offset: 0x005372AC
	protected override void OnAfterShow()
	{
		PhotoSaveMarkItem markItem = this.MarkItem;
		if (markItem != null)
		{
			markItem.SetUiActive(this.IsShowPlayerName);
		}
		UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
		if (uiViewSequence == null)
		{
			return;
		}
		uiViewSequence.PlaySequence("ScreenShot", true, null);
	}

	// Token: 0x06012E21 RID: 77345 RVA: 0x005390F0 File Offset: 0x005372F0
	private void OnClickedConfirmButton()
	{
		Singleton<Log>.Instance.Info(ELogModule.FightPhotograph, ELogAuthor.CXJ, "点击保存截图按钮", default(ReadOnlySpan<ValueTuple<string, object>>));
		if (ControllerBase<KuroSdkController>.Instance.CheckPhotoPermission())
		{
			this.TakeScreenshot(false, new Action<int, int, TArray<FColor>>(this.OnTakePhoto), new Action<bool>(this.OnIOSPhotoLibraryAuthorizationCompleted), new Action<TArray<byte>>(this.OnPhotoCompressed));
			return;
		}
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.PhotoPermissionRequest);
		Action value = delegate()
		{
			if (ControllerBase<PhotographController>.Instance.CouldRequestPhotoPermission())
			{
				ELocalStorageGlobalKey key = ELocalStorageGlobalKey.RequestPhotoPermissionMinTime;
				double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
				int? intConfig = ConfigCommonParamById.GetIntConfig("PermissionRequestsTimeId");
				LocalStorage.SetGlobal<double?>(key, serverTime + ((intConfig != null) ? new double?((double)intConfig.GetValueOrDefault()) : null));
				ControllerBase<KuroSdkController>.Instance.RequestPhotoPermission(new Action<bool>(this.OnRequestPermissionCallback));
				return;
			}
			this.OnPhotoPermissionDenied();
		};
		confirmBoxDataNew.FunctionMap.Add(1, new Action(this.OnPhotoPermissionDenied));
		confirmBoxDataNew.FunctionMap.Add(2, value);
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
	}

	// Token: 0x06012E22 RID: 77346 RVA: 0x005391A0 File Offset: 0x005373A0
	private unsafe void TakeScreenshot(bool isSaveFile, [Nullable(new byte[]
	{
		1,
		2
	})] Action<int, int, TArray<FColor>> onTakeScreenShotCallback, Action<bool> onIOSPhotoLibraryAuthorizationCompleted = null, Action<TArray<byte>> onPhotoCompressed = null)
	{
		string photoName = this.GetPhotoName();
		this.RelativeShotPath = this.GetRelativeShotPath(photoName);
		string storagePath = UBlueprintPathsLibrary.ProjectUserDir() + this.RelativeShotPath;
		FVector2D viewportSize = UWidgetLayoutLibrary.GetViewportSize(GlobalData.World);
		bool isPs5 = Singleton<Info>.Instance.IsPs5Platform();
		int multiplier = isPs5 ? 1 : this.GetFightSafeMultiplierScale(viewportSize);
		PhotographController.PrepareFightPhotoCapture();
		this.EnterCaptureMode(this.IsShowPlayerName);
		FOnTakeScreenshotCaptured.FOnTakeScreenshotCaptured_ScriptDelegate <>9__1;
		FOnTakeScreenshotCompressed.FOnTakeScreenshotCompressed_ScriptDelegate <>9__2;
		TimerSystem.GameplayTimeInstance.Next(delegate(float _)
		{
			UGameScreenshotTask ugameScreenshotTask = ScreenShotManager.PrepareTakeScreenshot(storagePath, 0f, 0f, viewportSize.X, viewportSize.Y, isSaveFile, viewportSize.X, viewportSize.Y, multiplier);
			if (ugameScreenshotTask == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.FightPhotograph, ELogAuthor.CXJ, "战斗拍照保存：PrepareTakeScreenshot 返回 undefined", default(ReadOnlySpan<ValueTuple<string, object>>));
				this.ExitCaptureMode();
				PhotographController.OnFightPhotoCaptured();
				return;
			}
			FOnTakeScreenshotCaptured.FOnTakeScreenshotCaptured_ScriptDelegate fonTakeScreenshotCaptured_ScriptDelegate;
			if ((fonTakeScreenshotCaptured_ScriptDelegate = <>9__1) == null)
			{
				fonTakeScreenshotCaptured_ScriptDelegate = (<>9__1 = delegate(int width, int height, in TArray<FColor> colors)
				{
					this.ExitCaptureMode();
					PhotographController.OnFightPhotoCaptured();
					onTakeScreenShotCallback(width, height, colors);
				});
			}
			FOnTakeScreenshotCaptured.FOnTakeScreenshotCaptured_ScriptDelegate callback = fonTakeScreenshotCaptured_ScriptDelegate;
			ugameScreenshotTask.OnTakeScreenshotCapturedDelegate.Add(callback);
			if (onIOSPhotoLibraryAuthorizationCompleted != null)
			{
				ugameScreenshotTask.OnIOSPhotoLibraryAuthorizationCompletedDelegate.Add(onIOSPhotoLibraryAuthorizationCompleted);
			}
			if (onPhotoCompressed != null)
			{
				FOnTakeScreenshotCompressed.FOnTakeScreenshotCompressed_ScriptDelegate fonTakeScreenshotCompressed_ScriptDelegate;
				if ((fonTakeScreenshotCompressed_ScriptDelegate = <>9__2) == null)
				{
					fonTakeScreenshotCompressed_ScriptDelegate = (<>9__2 = delegate(in TArray<byte> compressedBitmap)
					{
						onPhotoCompressed(compressedBitmap);
					});
				}
				FOnTakeScreenshotCompressed.FOnTakeScreenshotCompressed_ScriptDelegate callback2 = fonTakeScreenshotCompressed_ScriptDelegate;
				ugameScreenshotTask.OnTakeScreenshotCompressedDelegate.Add(callback2);
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.FightPhotograph;
			ELogAuthor author = ELogAuthor.CXJ;
			string message = "开始战斗拍照保存截图";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("isSaveFile", isSaveFile);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("multiplier", multiplier);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			if (isPs5)
			{
				ugameScreenshotTask.TakeScreenshot();
				return;
			}
			ugameScreenshotTask.TakeScreenshotHighRes(multiplier);
		}, null, null);
	}

	// Token: 0x06012E23 RID: 77347 RVA: 0x00539268 File Offset: 0x00537468
	private unsafe void OnTakePhoto(int width, int height, TArray<FColor> colors)
	{
		this.CurrentTakeWidth = width;
		this.CurrentTakeHeight = height;
		this.CurrentTakeColors = colors;
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.FightPhotograph;
		ELogAuthor author = ELogAuthor.CXJ;
		string message = "截图完成，截图结果进行保存";
		<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("width", width);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("height", height);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("ColorSize", (colors != null) ? new int?(colors.Num()) : null);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
		ESourcePlatformType platformType = Singleton<Info>.Instance.PlatformType;
		if (platformType <= ESourcePlatformType.Android)
		{
			if (platformType != ESourcePlatformType.IOS)
			{
				if (platformType == ESourcePlatformType.Android)
				{
					TArray<byte> tarray = new TArray<byte>();
					UKuroGameScreenshotBPLibrary.ConvertColorsToBitmap(width, height, colors, ref tarray);
					TArray<byte> tarray2 = tarray;
					Log instance2 = Singleton<Log>.Instance;
					ELogModule module2 = ELogModule.FightPhotograph;
					ELogAuthor author2 = ELogAuthor.CXJ;
					string message2 = "截图保存至Android相册";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("bitmapSize", (tarray2 != null) ? new int?(tarray2.Num()) : null);
					instance2.Info(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					UKuroGameScreenshotBPLibrary.SaveColorArrayToAndroidAlbum(width, height, tarray2);
					ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("SaveGalleryPathTips", Array.Empty<object>());
					goto IL_31E;
				}
			}
			else
			{
				if (!UKuroGameScreenshotBPLibrary.IsPhotoLibraryAuthorized())
				{
					Singleton<Log>.Instance.Info(ELogModule.FightPhotograph, ELogAuthor.CXJ, "没有获得IOS相册权限，请求权限，请求完成后再次尝试截图", default(ReadOnlySpan<ValueTuple<string, object>>));
					ScreenShotManager.RequestIOSPhotoLibraryAuthorization();
					return;
				}
				Log instance3 = Singleton<Log>.Instance;
				ELogModule module3 = ELogModule.FightPhotograph;
				ELogAuthor author3 = ELogAuthor.CXJ;
				string message3 = "截图保存IOS相册";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("colors", (colors != null) ? new int?(colors.Num()) : null);
				instance3.Info(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				UKuroGameScreenshotBPLibrary.SaveColorArrayToIosAlbum(width, height, colors);
				ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("SaveGalleryPathTips", Array.Empty<object>());
				goto IL_31E;
			}
		}
		else
		{
			if (platformType == ESourcePlatformType.PS5)
			{
				goto IL_31E;
			}
			if (platformType == ESourcePlatformType.OpenHarmony)
			{
				TArray<byte> tarray3 = new TArray<byte>();
				UKuroGameScreenshotBPLibrary.CompressConvertColorsToBitmap(this.CurrentTakeWidth, this.CurrentTakeHeight, this.CurrentTakeColors, ref tarray3);
				TArray<byte> tarray4 = tarray3;
				Log instance4 = Singleton<Log>.Instance;
				ELogModule module4 = ELogModule.Photo;
				ELogAuthor author4 = ELogAuthor.CXJ;
				string message4 = "截图保存至鸿蒙相册";
				ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("bitmapSize", (tarray4 != null) ? new int?(tarray4.Num()) : null);
				instance4.Info(module4, author4, message4, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
				UKuroGameScreenshotBPLibrary.SaveColorArrayToOpenHarmonyAlbum(this.CurrentTakeWidth, this.CurrentTakeHeight, tarray4);
				ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("SaveGalleryPathTips", Array.Empty<object>());
				goto IL_31E;
			}
		}
		string photoName = this.GetPhotoName();
		this.RelativeShotPath = this.GetRelativeShotPath(photoName);
		UKuroGameScreenshotBPLibrary.SaveScreenshot(UBlueprintPathsLibrary.ProjectUserDir() + this.RelativeShotPath, width, height, colors);
		Log instance5 = Singleton<Log>.Instance;
		ELogModule module5 = ELogModule.FightPhotograph;
		ELogAuthor author5 = ELogAuthor.CXJ;
		string message5 = "截图保存至游戏安装文件夹";
		ValueTuple<string, object> valueTuple4 = new ValueTuple<string, object>("path", this.RelativeShotPath);
		instance5.Info(module5, author5, message5, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple4));
		if (!Singleton<Platform>.Instance.IsCloudGame())
		{
			ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("SavePathTips", new object[]
			{
				this.RelativeShotPath
			});
		}
		IL_31E:
		this.ClosePhotoSaveView();
	}

	// Token: 0x06012E24 RID: 77348 RVA: 0x0053959C File Offset: 0x0053779C
	private unsafe void OnIOSPhotoLibraryAuthorizationCompleted(bool isGranted)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.FightPhotograph;
		ELogAuthor author = ELogAuthor.CXJ;
		string message = "允许权限后重新截图";
		<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("isGranted", isGranted);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("width", this.CurrentTakeWidth);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("height", this.CurrentTakeHeight);
		ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3);
		string item = "colorsSize";
		TArray<FColor> currentTakeColors = this.CurrentTakeColors;
		ptr = new ValueTuple<string, object>(item, (currentTakeColors != null) ? new int?(currentTakeColors.Num()) : null);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
		if (!isGranted)
		{
			this.ClosePhotoSaveView();
			return;
		}
		if (this.CurrentTakeWidth <= 0 || this.CurrentTakeHeight <= 0 || this.CurrentTakeColors == null)
		{
			this.ClosePhotoSaveView();
			return;
		}
		UKuroGameScreenshotBPLibrary.SaveColorArrayToIosAlbum(this.CurrentTakeWidth, this.CurrentTakeHeight, this.CurrentTakeColors);
		ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("SaveGalleryPathTips", Array.Empty<object>());
		this.ClosePhotoSaveView();
	}

	// Token: 0x06012E25 RID: 77349 RVA: 0x005396C8 File Offset: 0x005378C8
	private void OnPhotoPermissionDenied()
	{
		ESourcePlatformType platformType = Singleton<Info>.Instance.PlatformType;
		if (platformType != ESourcePlatformType.IOS)
		{
			if (platformType == ESourcePlatformType.Android)
			{
				ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("Privilege_album_Android", Array.Empty<object>());
				return;
			}
		}
		else
		{
			ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("Privilege_album_IOS", Array.Empty<object>());
		}
	}

	// Token: 0x06012E26 RID: 77350 RVA: 0x00539714 File Offset: 0x00537914
	private void OnPhotoCompressed(TArray<byte> compressedBitmap)
	{
		Singleton<Log>.Instance.Info(ELogModule.FightPhotograph, ELogAuthor.CXJ, "PS Test OnPhotoCompressed", default(ReadOnlySpan<ValueTuple<string, object>>));
		if (Singleton<Info>.Instance.PlatformType == ESourcePlatformType.PS5)
		{
			string photoName = this.GetPhotoName();
			UGameplayStatics.ExportPngPhotoFromData(compressedBitmap, photoName);
		}
	}

	// Token: 0x06012E27 RID: 77351 RVA: 0x0053975D File Offset: 0x0053795D
	private void OnRequestPermissionCallback(bool isAllowed)
	{
		if (isAllowed)
		{
			this.TakeScreenshot(false, new Action<int, int, TArray<FColor>>(this.OnTakePhoto), new Action<bool>(this.OnIOSPhotoLibraryAuthorizationCompleted), null);
			return;
		}
		this.OnPhotoPermissionDenied();
	}

	// Token: 0x06012E28 RID: 77352 RVA: 0x0053978C File Offset: 0x0053798C
	private int GetFightSafeMultiplierScale(FVector2D viewportSize)
	{
		int num = 1;
		FightPhotoSetup? fightPhotoSetupConfigById = ConfigBase<PhotographConfig>.Instance.GetFightPhotoSetupConfigById(1);
		if (fightPhotoSetupConfigById != null)
		{
			PhotoDropDown? config = ConfigPhotoDropDownById.GetConfig(ModelBase<FightPhotoModel>.Instance.GetFightPhotoSetupOption(EFightPhotoSetupOptionType.ImageQuality) ?? fightPhotoSetupConfigById.Value.DefaultDropDownIndex, true);
			if (config != null)
			{
				num = int.Parse(config.Value.Param()[0]);
			}
		}
		int? intConfig = ConfigCommonParamById.GetIntConfig("PhotoMaxAllowedResolution");
		if (intConfig != null)
		{
			int? num2 = intConfig;
			int num3 = 0;
			if (num2.GetValueOrDefault() > num3 & num2 != null)
			{
				float num4 = Math.Max(viewportSize.X, viewportSize.Y) * (float)num;
				num2 = intConfig;
				float? num5 = (num2 != null) ? new float?((float)num2.GetValueOrDefault()) : null;
				if (num4 > num5.GetValueOrDefault() & num5 != null)
				{
					num = 1;
				}
			}
		}
		return Math.Max(1, Math.Min(4, num));
	}

	// Token: 0x06012E29 RID: 77353 RVA: 0x00539894 File Offset: 0x00537A94
	[NullableContext(1)]
	private string GetPhotoName()
	{
		double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
		return Singleton<TimeUtil>.Instance.DateFormatString2(serverTime) + ".png";
	}

	// Token: 0x06012E2A RID: 77354 RVA: 0x005398C1 File Offset: 0x00537AC1
	[NullableContext(1)]
	private string GetRelativeShotPath(string photoName)
	{
		return ModelBase<PhotographModel>.Instance.SavePath + photoName;
	}

	// Token: 0x06012E2B RID: 77355 RVA: 0x005398D3 File Offset: 0x00537AD3
	private void ClosePhotoSaveView()
	{
		base.CloseMe(null);
	}

	// Token: 0x06012E2C RID: 77356 RVA: 0x005398DC File Offset: 0x00537ADC
	private void OnClickPersonalInfoShow(EToggleState toggleState)
	{
		LocalStorage.SetGlobal<bool>(ELocalStorageGlobalKey.PhotoAndShareShowPlayerName, toggleState == EToggleState.ETT_Checked);
		this.IsShowPlayerName = (toggleState == EToggleState.ETT_Checked);
		PhotoSaveMarkItem markItem = this.MarkItem;
		if (markItem == null)
		{
			return;
		}
		markItem.SetUiActive(toggleState == EToggleState.ETT_Checked);
	}

	// Token: 0x06012E2D RID: 77357 RVA: 0x00539908 File Offset: 0x00537B08
	private void OnCloseBtnClick()
	{
		base.CloseMe(null);
	}

	// Token: 0x06012E2E RID: 77358 RVA: 0x00539914 File Offset: 0x00537B14
	private void EnterCaptureMode(bool showMark)
	{
		UUIItem rootItem = base.GetRootItem();
		if (rootItem != null)
		{
			rootItem.SetUIActive(false);
		}
		ULGUIBPLibrary.ResetGlobalBlurUIItem(GlobalData.GameInstance.GetWorld());
		Singleton<EventSystem>.Instance.Emit<bool, bool>(EEventName.OnPhotographViewCaptureMode, true, showMark);
		Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnPreparePhotoScreenShot, false);
	}

	// Token: 0x06012E2F RID: 77359 RVA: 0x00539965 File Offset: 0x00537B65
	private void ExitCaptureMode()
	{
		Singleton<EventSystem>.Instance.Emit<bool, bool>(EEventName.OnPhotographViewCaptureMode, false, false);
		Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnPreparePhotoScreenShot, true);
		UUIItem rootItem = base.GetRootItem();
		if (rootItem == null)
		{
			return;
		}
		rootItem.SetUIActive(true);
	}

	// Token: 0x06012E30 RID: 77360 RVA: 0x0053999C File Offset: 0x00537B9C
	private UniTask waitForNextTick()
	{
		FightPhotoSaveView.<waitForNextTick>d__30 <waitForNextTick>d__;
		<waitForNextTick>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<waitForNextTick>d__.<>1__state = -1;
		<waitForNextTick>d__.<>t__builder.Start<FightPhotoSaveView.<waitForNextTick>d__30>(ref <waitForNextTick>d__);
		return <waitForNextTick>d__.<>t__builder.Task;
	}

	// Token: 0x0400939B RID: 37787
	[Nullable(1)]
	private string RelativeShotPath = "";

	// Token: 0x0400939C RID: 37788
	private bool IsShowPlayerName;

	// Token: 0x0400939D RID: 37789
	private int CurrentTakeWidth;

	// Token: 0x0400939E RID: 37790
	private int CurrentTakeHeight;

	// Token: 0x0400939F RID: 37791
	private TArray<FColor> CurrentTakeColors;

	// Token: 0x040093A0 RID: 37792
	private PhotoSaveMarkItem MarkItem;

	// Token: 0x02008917 RID: 35095
	[NullableContext(0)]
	private enum EComponents
	{
		// Token: 0x0402E424 RID: 189476
		BtnClose,
		// Token: 0x0402E425 RID: 189477
		ToggleShowPersonalInfo,
		// Token: 0x0402E426 RID: 189478
		BtnSave,
		// Token: 0x0402E427 RID: 189479
		ItemPhoto,
		// Token: 0x0402E428 RID: 189480
		TexturePhoto,
		// Token: 0x0402E429 RID: 189481
		ItemPersonalInfo,
		// Token: 0x0402E42A RID: 189482
		ItemLeftTop,
		// Token: 0x0402E42B RID: 189483
		ItemRightBottom,
		// Token: 0x0402E42C RID: 189484
		TextFinished,
		// Token: 0x0402E42D RID: 189485
		TextureHideUi,
		// Token: 0x0402E42E RID: 189486
		ItemHideUi,
		// Token: 0x0402E42F RID: 189487
		ItemHideBtn
	}
}
