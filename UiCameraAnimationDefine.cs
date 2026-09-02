using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.UiCameraAnimation.UiCameraContext;

// Token: 0x02002C30 RID: 11312
public class UiCameraAnimationDefine
{
	// Token: 0x0400AEC6 RID: 44742
	[Nullable(1)]
	public const string DEFAULT_BLEND_NAME = "1001";

	// Token: 0x0400AEC7 RID: 44743
	[Nullable(1)]
	public const string CAMERA_ZEROTIME_BLENDNAME = "10009";

	// Token: 0x02008F56 RID: 36694
	public enum ECameraAnimationAttributeType
	{
		// Token: 0x04030220 RID: 197152
		None,
		// Token: 0x04030221 RID: 197153
		Location,
		// Token: 0x04030222 RID: 197154
		Rotation,
		// Token: 0x04030223 RID: 197155
		ArmLength,
		// Token: 0x04030224 RID: 197156
		ArmOffsetLocation,
		// Token: 0x04030225 RID: 197157
		ArmOffsetRotation,
		// Token: 0x04030226 RID: 197158
		CameraFieldOfView,
		// Token: 0x04030227 RID: 197159
		FocalDistance,
		// Token: 0x04030228 RID: 197160
		PostProcessBlendWeight,
		// Token: 0x04030229 RID: 197161
		Aperture,
		// Token: 0x0403022A RID: 197162
		FocalRegion
	}

	// Token: 0x02008F57 RID: 36695
	public enum ECameraAnimationFinishType
	{
		// Token: 0x0403022C RID: 197164
		Finished,
		// Token: 0x0403022D RID: 197165
		Stop
	}

	// Token: 0x02008F58 RID: 36696
	public enum EPlayCameraHandleResult
	{
		// Token: 0x0403022F RID: 197167
		Fail,
		// Token: 0x04030230 RID: 197168
		PlayAnimation,
		// Token: 0x04030231 RID: 197169
		RevertAnimation,
		// Token: 0x04030232 RID: 197170
		Activate
	}

	// Token: 0x02008F59 RID: 36697
	[NullableContext(1)]
	public interface IFinishData
	{
		// Token: 0x1700A86F RID: 43119
		// (get) Token: 0x06049D00 RID: 302336
		UiCameraAnimationDefine.ECameraAnimationFinishType FinishType { get; }

		// Token: 0x1700A870 RID: 43120
		// (get) Token: 0x06049D01 RID: 302337
		UiCameraHandleData FromHandleData { get; }

		// Token: 0x1700A871 RID: 43121
		// (get) Token: 0x06049D02 RID: 302338
		UiCameraHandleData ToHandleData { get; }
	}

	// Token: 0x02008F5A RID: 36698
	[NullableContext(1)]
	[Nullable(0)]
	public class FinishData : UiCameraAnimationDefine.IFinishData
	{
		// Token: 0x1700A872 RID: 43122
		// (get) Token: 0x06049D03 RID: 302339 RVA: 0x01400452 File Offset: 0x013FE652
		// (set) Token: 0x06049D04 RID: 302340 RVA: 0x0140045A File Offset: 0x013FE65A
		public UiCameraAnimationDefine.ECameraAnimationFinishType FinishType { get; set; }

		// Token: 0x1700A873 RID: 43123
		// (get) Token: 0x06049D05 RID: 302341 RVA: 0x01400463 File Offset: 0x013FE663
		// (set) Token: 0x06049D06 RID: 302342 RVA: 0x0140046B File Offset: 0x013FE66B
		public UiCameraHandleData FromHandleData { get; set; }

		// Token: 0x1700A874 RID: 43124
		// (get) Token: 0x06049D07 RID: 302343 RVA: 0x01400474 File Offset: 0x013FE674
		// (set) Token: 0x06049D08 RID: 302344 RVA: 0x0140047C File Offset: 0x013FE67C
		public UiCameraHandleData ToHandleData { get; set; }
	}

	// Token: 0x02008F5B RID: 36699
	[NullableContext(1)]
	[Nullable(0)]
	public class IUiCameraMapping
	{
		// Token: 0x06049D0A RID: 302346 RVA: 0x01400490 File Offset: 0x013FE690
		public IUiCameraMapping(UiCameraMapping config)
		{
			this.Id = config.Id;
			this.ViewName = config.ViewName;
			this.DefaultUiCameraSettingsName = config.DefaultUiCameraSettingsName;
			this.PlayLoadingCameraAnimation = config.BPlayLoadingCameraAnimation;
			this.BodyTargetType = config.BodyTargetType;
			this.DefaultCameraBlendName = config.DefaultCameraBlendName;
			this.UiCameraDelayTime = (float)config.UiCameraDelayTime;
			this.BodyCameraSettingsNameMap = config.BodyCameraSettingsNameMap();
			this.UiCameraBlendNameMap = config.UiCameraBlendNameMap();
		}

		// Token: 0x06049D0B RID: 302347 RVA: 0x0140051C File Offset: 0x013FE71C
		public IUiCameraMapping(ChildUiCameraMapping config)
		{
			this.Id = config.Id;
			this.ViewName = config.ViewName;
			this.DefaultUiCameraSettingsName = config.DefaultUiCameraSettingsName;
			this.PlayLoadingCameraAnimation = config.BPlayLoadingCameraAnimation;
			this.BodyTargetType = config.BodyTargetType;
			this.DefaultCameraBlendName = config.DefaultCameraBlendName;
			this.UiCameraDelayTime = (float)config.UiCameraDelayTime;
			this.BodyCameraSettingsNameMap = config.BodyCameraSettingsNameMap();
			this.UiCameraBlendNameMap = config.UiCameraBlendNameMap();
		}

		// Token: 0x1700A875 RID: 43125
		// (get) Token: 0x06049D0C RID: 302348 RVA: 0x014005A5 File Offset: 0x013FE7A5
		public int Id { get; }

		// Token: 0x1700A876 RID: 43126
		// (get) Token: 0x06049D0D RID: 302349 RVA: 0x014005AD File Offset: 0x013FE7AD
		public string ViewName { get; }

		// Token: 0x1700A877 RID: 43127
		// (get) Token: 0x06049D0E RID: 302350 RVA: 0x014005B5 File Offset: 0x013FE7B5
		public string DefaultUiCameraSettingsName { get; }

		// Token: 0x1700A878 RID: 43128
		// (get) Token: 0x06049D0F RID: 302351 RVA: 0x014005BD File Offset: 0x013FE7BD
		public bool PlayLoadingCameraAnimation { get; }

		// Token: 0x1700A879 RID: 43129
		// (get) Token: 0x06049D10 RID: 302352 RVA: 0x014005C5 File Offset: 0x013FE7C5
		public int BodyTargetType { get; }

		// Token: 0x1700A87A RID: 43130
		// (get) Token: 0x06049D11 RID: 302353 RVA: 0x014005CD File Offset: 0x013FE7CD
		public Dictionary<string, string> BodyCameraSettingsNameMap { get; }

		// Token: 0x1700A87B RID: 43131
		// (get) Token: 0x06049D12 RID: 302354 RVA: 0x014005D5 File Offset: 0x013FE7D5
		public string DefaultCameraBlendName { get; }

		// Token: 0x1700A87C RID: 43132
		// (get) Token: 0x06049D13 RID: 302355 RVA: 0x014005DD File Offset: 0x013FE7DD
		public float UiCameraDelayTime { get; }

		// Token: 0x1700A87D RID: 43133
		// (get) Token: 0x06049D14 RID: 302356 RVA: 0x014005E5 File Offset: 0x013FE7E5
		public Dictionary<string, string> UiCameraBlendNameMap { get; }
	}

	// Token: 0x02008F5C RID: 36700
	public enum EPlayBlendCameraSequenceResult
	{
		// Token: 0x04030240 RID: 197184
		Success,
		// Token: 0x04030241 RID: 197185
		PathIsEmpty,
		// Token: 0x04030242 RID: 197186
		TargetActorNotFound
	}
}
