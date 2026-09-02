using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Common;
using CSharpScript.Launcher.Platform;
using CSharpScript.Typing;
using UnrealEngine;

namespace CSharpScript.Game.Camera
{
	// Token: 0x0200708D RID: 28813
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class CameraModel : ModelBase<CameraModel>
	{
		// Token: 0x1700A5A2 RID: 42402
		// (get) Token: 0x06045D36 RID: 286006 RVA: 0x01247FA1 File Offset: 0x012461A1
		// (set) Token: 0x06045D37 RID: 286007 RVA: 0x01247FA9 File Offset: 0x012461A9
		public CameraModelInstance MainModel { get; private set; }

		// Token: 0x06045D38 RID: 286008 RVA: 0x01247FB4 File Offset: 0x012461B4
		public CameraModelInstance CreateSeparateCameraModel(string cameraName)
		{
			CameraModelInstance separateCameraModel = this.GetSeparateCameraModel(cameraName);
			if (separateCameraModel != null)
			{
				return separateCameraModel;
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Camera;
			ELogAuthor author = ELogAuthor.LJM;
			string message = "[分屏相机][CameraModel]新建分屏相机";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("cameraName", cameraName);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			CameraModelInstance cameraModelInstance = new CameraModelInstance(cameraName);
			this.CameraModelInstanceMap[cameraName] = cameraModelInstance;
			cameraModelInstance.Init();
			return cameraModelInstance;
		}

		// Token: 0x06045D39 RID: 286009 RVA: 0x01248011 File Offset: 0x01246211
		[return: Nullable(2)]
		public CameraModelInstance GetSeparateCameraModel(string cameraName = "MainCamera")
		{
			if (cameraName == "MainCamera")
			{
				return this.MainModel;
			}
			return this.CameraModelInstanceMap.GetValueOrDefault(cameraName);
		}

		// Token: 0x06045D3A RID: 286010 RVA: 0x01248033 File Offset: 0x01246233
		public bool HasSeparateCamera()
		{
			return this.CameraModelInstanceMap.Count > 0;
		}

		// Token: 0x06045D3B RID: 286011 RVA: 0x01248044 File Offset: 0x01246244
		public void DestroySeparateCameraModel(string cameraName)
		{
			if (cameraName == "MainCamera")
			{
				return;
			}
			CameraModelInstance cameraModelInstance;
			if (!this.CameraModelInstanceMap.TryGetValue(cameraName, out cameraModelInstance))
			{
				return;
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Camera;
			ELogAuthor author = ELogAuthor.LJM;
			string message = "[分屏相机][CameraModel]销毁分屏相机";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("cameraName", cameraName);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			cameraModelInstance.Clear();
			this.CameraModelInstanceMap.Remove(cameraName);
		}

		// Token: 0x06045D3C RID: 286012 RVA: 0x012480AB File Offset: 0x012462AB
		protected override bool OnInit()
		{
			this.UpdateCameraParam();
			this.MainModel = new CameraModelInstance("MainCamera");
			return this.MainModel.Init();
		}

		// Token: 0x06045D3D RID: 286013 RVA: 0x012480D0 File Offset: 0x012462D0
		public void ModelIterator(Action<CameraModelInstance> action)
		{
			action(this.MainModel);
			foreach (KeyValuePair<string, CameraModelInstance> keyValuePair in new Dictionary<string, CameraModelInstance>(this.CameraModelInstanceMap))
			{
				string text;
				CameraModelInstance cameraModelInstance;
				keyValuePair.Deconstruct(out text, out cameraModelInstance);
				CameraModelInstance obj = cameraModelInstance;
				action(obj);
			}
		}

		// Token: 0x06045D3E RID: 286014 RVA: 0x01248144 File Offset: 0x01246344
		protected override bool OnClear()
		{
			this.ModelIterator(delegate(CameraModelInstance instance)
			{
				instance.Clear();
			});
			this.CameraModelInstanceMap.Clear();
			APlayerController playerController = Global.PlayerController;
			if (playerController != null)
			{
				playerController.RemoveAdditionalPlayerCameraManagers();
			}
			return true;
		}

		// Token: 0x06045D3F RID: 286015 RVA: 0x01248194 File Offset: 0x01246394
		private void UpdateCameraParam()
		{
			if (Singleton<Info>.Instance.IsMobilePlatform())
			{
				if ((Singleton<Info>.Instance.PlatformType == ESourcePlatformType.Android && Singleton<Platform>.Instance.IsHuaWeiDevice()) || Singleton<Platform>.Instance.IsHonorDevice())
				{
					this.UpdateHuaWeiParam();
					return;
				}
				this.UpdateMobileParam();
				return;
			}
			else
			{
				if (Singleton<CloudGameManager>.Instance.IsCloudGame)
				{
					this.UpdateCloudGameParam();
					return;
				}
				this.MobileDensityYawScale = 0.0055555557f;
				this.MobileDensityPitchScale = 0.0055555557f;
				return;
			}
		}

		// Token: 0x06045D40 RID: 286016 RVA: 0x0124820C File Offset: 0x0124640C
		private unsafe void UpdateHuaWeiParam()
		{
			FVector2D physicalScreenResolution = KuroScreen.GetPhysicalScreenResolution();
			float x = physicalScreenResolution.X;
			float y = physicalScreenResolution.Y;
			FVector2D physicalScreenResolutionV = KuroScreen.GetPhysicalScreenResolutionV2();
			float x2 = physicalScreenResolutionV.X;
			float y2 = physicalScreenResolutionV.Y;
			FVector2D displayScreenResolution = KuroScreen.GetDisplayScreenResolution();
			float x3 = displayScreenResolution.X;
			float y3 = displayScreenResolution.Y;
			FIntPoint defaultScreenResolution = Singleton<GameSettingsDeviceRender>.Instance.GetDefaultScreenResolution();
			int x4 = defaultScreenResolution.X;
			int y4 = defaultScreenResolution.Y;
			this.PhysicalScreenWidth = Math.Max(x, y);
			this.PhysicalScreenHeight = Math.Min(x, y);
			this.PhysicalScreenWidthV2 = Math.Max(x2, y2);
			this.PhysicalScreenHeightV2 = Math.Min(x2, y2);
			this.DisplayScreenWidth = Math.Max(x3, y3);
			this.DisplayScreenHeight = Math.Min(x3, y3);
			this.GameScreenWidth = (float)Math.Max(x4, y4);
			this.GameScreenHeight = (float)Math.Min(x4, y4);
			this.PhysicalDensityDpi = Math.Max((float)KuroScreen.GetPhysicalScreenDensityDPI(), 160f);
			this.RealPhysicalDensityDpi = this.PhysicalScreenWidth / this.DisplayScreenWidth * this.PhysicalDensityDpi;
			if (Singleton<MathUtils>.Instance.IsNearlyEqual((double)this.PhysicalScreenWidthV2, 0.0, null) || Singleton<MathUtils>.Instance.IsNearlyEqual((double)this.PhysicalScreenWidthV2, 0.0, null))
			{
				this.PhysicalScreenWidthV2 = this.GameScreenWidth;
				this.PhysicalScreenWidthV2 = this.GameScreenHeight;
			}
			this.MobileDensityYawScale = this.PhysicalScreenWidthV2 / (this.GameScreenWidth * this.RealPhysicalDensityDpi);
			this.MobileDensityPitchScale = this.PhysicalScreenWidthV2 / (this.GameScreenHeight * this.RealPhysicalDensityDpi);
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Camera;
			ELogAuthor author = ELogAuthor.LJM;
			string message = "CameraInputController";
			<>y__InlineArray12<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray12<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray12<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("GameScreenWidth", this.GameScreenWidth);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray12<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("GameScreenHeight", this.GameScreenHeight);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray12<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("PhysicalScreenWidth", this.PhysicalScreenWidth);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray12<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("PhysicalScreenHeight", this.PhysicalScreenHeight);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray12<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 4) = new ValueTuple<string, object>("PhysicalScreenWidthV2", this.PhysicalScreenWidthV2);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray12<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 5) = new ValueTuple<string, object>("PhysicalScreenHeightV2", this.PhysicalScreenHeightV2);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray12<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 6) = new ValueTuple<string, object>("DisplayScreenWidth", this.DisplayScreenWidth);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray12<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 7) = new ValueTuple<string, object>("DisplayScreenHeight", this.DisplayScreenHeight);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray12<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 8) = new ValueTuple<string, object>("PhysicalDensityDpi", this.PhysicalDensityDpi);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray12<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 9) = new ValueTuple<string, object>("RealPhysicalDensityDpi", this.RealPhysicalDensityDpi);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray12<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 10) = new ValueTuple<string, object>("MobileDensityYawScale", this.MobileDensityYawScale);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray12<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 11) = new ValueTuple<string, object>("MobileDensityPitchScale", this.MobileDensityPitchScale);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray12<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 12));
		}

		// Token: 0x06045D41 RID: 286017 RVA: 0x01248564 File Offset: 0x01246764
		private unsafe void UpdateMobileParam()
		{
			FVector2D physicalScreenResolution = KuroScreen.GetPhysicalScreenResolution();
			float x = physicalScreenResolution.X;
			float y = physicalScreenResolution.Y;
			FIntPoint defaultScreenResolution = Singleton<GameSettingsDeviceRender>.Instance.GetDefaultScreenResolution();
			int x2 = defaultScreenResolution.X;
			int y2 = defaultScreenResolution.Y;
			this.GameScreenWidth = (float)Math.Max(x2, y2);
			this.GameScreenHeight = (float)Math.Min(x2, y2);
			this.PhysicalScreenWidth = Math.Max(x, y);
			this.PhysicalScreenHeight = Math.Min(x, y);
			if (Singleton<Info>.Instance.PlatformType == ESourcePlatformType.IOS)
			{
				this.PhysicalDensityDpi = Math.Max((float)KuroScreen.ComputePhysicalScreenDensity(), 160f);
			}
			else
			{
				this.PhysicalDensityDpi = Math.Max((float)KuroScreen.GetPhysicalScreenDensityDPI(), 160f);
			}
			if (Singleton<MathUtils>.Instance.IsNearlyEqual((double)this.PhysicalScreenWidth, 0.0, null) || Singleton<MathUtils>.Instance.IsNearlyEqual((double)this.PhysicalScreenHeight, 0.0, null))
			{
				this.PhysicalScreenWidth = this.GameScreenWidth;
				this.PhysicalScreenHeight = this.GameScreenHeight;
			}
			this.MobileDensityYawScale = this.PhysicalScreenWidth / (this.GameScreenWidth * this.PhysicalDensityDpi);
			this.MobileDensityPitchScale = this.PhysicalScreenHeight / (this.GameScreenHeight * this.PhysicalDensityDpi);
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Camera;
			ELogAuthor author = ELogAuthor.LJM;
			string message = "CameraInputController";
			<>y__InlineArray7<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray7<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("GameScreenWidth", this.GameScreenWidth);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("GameScreenHeight", this.GameScreenHeight);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("PhysicalScreenWidth", this.PhysicalScreenWidth);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("PhysicalScreenHeight", this.PhysicalScreenHeight);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 4) = new ValueTuple<string, object>("PhysicalDensityDpi", this.PhysicalDensityDpi);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 5) = new ValueTuple<string, object>("MobileDensityYawScale", this.MobileDensityYawScale);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 6) = new ValueTuple<string, object>("MobileDensityPitchScale", this.MobileDensityPitchScale);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 7));
		}

		// Token: 0x06045D42 RID: 286018 RVA: 0x012487B4 File Offset: 0x012469B4
		private unsafe void UpdateCloudGameParam()
		{
			int deviceScreenWidth = Singleton<CloudGameManager>.Instance.DeviceScreenWidth;
			int deviceScreenHeight = Singleton<CloudGameManager>.Instance.DeviceScreenHeight;
			this.PhysicalDensityDpi = (float)Singleton<CloudGameManager>.Instance.CloudGameDpi;
			int screenWidth = Singleton<CloudGameManager>.Instance.ScreenWidth;
			int screenHeight = Singleton<CloudGameManager>.Instance.ScreenHeight;
			this.GameScreenWidth = (float)Math.Max(screenWidth, screenHeight);
			this.GameScreenHeight = (float)Math.Min(screenWidth, screenHeight);
			this.PhysicalScreenWidth = (float)Math.Max(deviceScreenWidth, deviceScreenHeight);
			this.PhysicalScreenHeight = (float)Math.Min(deviceScreenWidth, deviceScreenHeight);
			if (Singleton<MathUtils>.Instance.IsNearlyEqual((double)this.PhysicalScreenWidth, 0.0, null) || Singleton<MathUtils>.Instance.IsNearlyEqual((double)this.PhysicalScreenHeight, 0.0, null))
			{
				this.PhysicalScreenWidth = this.GameScreenWidth;
				this.PhysicalScreenHeight = this.GameScreenHeight;
			}
			this.MobileDensityYawScale = this.PhysicalScreenWidth / (this.GameScreenWidth * this.PhysicalDensityDpi);
			this.MobileDensityPitchScale = this.PhysicalScreenHeight / (this.GameScreenHeight * this.PhysicalDensityDpi);
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Camera;
			ELogAuthor author = ELogAuthor.LJM;
			string message = "CameraModel CloudGameParam";
			<>y__InlineArray7<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray7<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("GameScreenWidth", this.GameScreenWidth);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("GameScreenHeight", this.GameScreenHeight);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("PhysicalScreenWidth", this.PhysicalScreenWidth);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("PhysicalScreenHeight", this.PhysicalScreenHeight);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 4) = new ValueTuple<string, object>("PhysicalDensityDpi", this.PhysicalDensityDpi);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 5) = new ValueTuple<string, object>("MobileDensityYawScale", this.MobileDensityYawScale);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 6) = new ValueTuple<string, object>("MobileDensityPitchScale", this.MobileDensityPitchScale);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 7));
		}

		// Token: 0x04027164 RID: 160100
		public const string MAIN_CAMERA = "MainCamera";

		// Token: 0x04027165 RID: 160101
		public const float CAMER_DEFAULT_NEAR_CLIP = 10f;

		// Token: 0x04027166 RID: 160102
		internal const int MIN_PHYSICAL_DENSITY_DPI = 160;

		// Token: 0x04027167 RID: 160103
		internal const int DEFAULT_DPI = 180;

		// Token: 0x04027169 RID: 160105
		private readonly Dictionary<string, CameraModelInstance> CameraModelInstanceMap = new Dictionary<string, CameraModelInstance>();

		// Token: 0x0402716A RID: 160106
		private float GameScreenWidth;

		// Token: 0x0402716B RID: 160107
		private float GameScreenHeight;

		// Token: 0x0402716C RID: 160108
		private float PhysicalScreenWidth;

		// Token: 0x0402716D RID: 160109
		private float PhysicalScreenHeight;

		// Token: 0x0402716E RID: 160110
		private float PhysicalScreenWidthV2;

		// Token: 0x0402716F RID: 160111
		private float PhysicalScreenHeightV2;

		// Token: 0x04027170 RID: 160112
		private float DisplayScreenWidth;

		// Token: 0x04027171 RID: 160113
		private float DisplayScreenHeight;

		// Token: 0x04027172 RID: 160114
		private float PhysicalDensityDpi;

		// Token: 0x04027173 RID: 160115
		private float RealPhysicalDensityDpi;

		// Token: 0x04027174 RID: 160116
		public float MobileDensityYawScale;

		// Token: 0x04027175 RID: 160117
		public float MobileDensityPitchScale;
	}
}
