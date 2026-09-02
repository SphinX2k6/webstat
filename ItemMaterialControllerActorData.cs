using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02003427 RID: 13351
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/Render/Scene/Item/MaterialController/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/Render/Scene/Item/MaterialController/ItemMaterialControllerActorData.ItemMaterialControllerActorData_C")]
public class ItemMaterialControllerActorData : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
{
	// Token: 0x170025B4 RID: 9652
	// (get) Token: 0x0601BDDA RID: 114138 RVA: 0x0084ED6F File Offset: 0x0084CF6F
	// (set) Token: 0x0601BDDB RID: 114139 RVA: 0x0084ED7F File Offset: 0x0084CF7F
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float StartTime
	{
		get
		{
			return *(base.NativePtr + (IntPtr)ItemMaterialControllerActorData.__PropertyOffset_StartTime);
		}
		set
		{
			*(base.NativePtr + (IntPtr)ItemMaterialControllerActorData.__PropertyOffset_StartTime) = value;
		}
	}

	// Token: 0x170025B5 RID: 9653
	// (get) Token: 0x0601BDDC RID: 114140 RVA: 0x0084ED90 File Offset: 0x0084CF90
	// (set) Token: 0x0601BDDD RID: 114141 RVA: 0x0084EDA0 File Offset: 0x0084CFA0
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float LoopTime
	{
		get
		{
			return *(base.NativePtr + (IntPtr)ItemMaterialControllerActorData.__PropertyOffset_LoopTime);
		}
		set
		{
			*(base.NativePtr + (IntPtr)ItemMaterialControllerActorData.__PropertyOffset_LoopTime) = value;
		}
	}

	// Token: 0x170025B6 RID: 9654
	// (get) Token: 0x0601BDDE RID: 114142 RVA: 0x0084EDB1 File Offset: 0x0084CFB1
	// (set) Token: 0x0601BDDF RID: 114143 RVA: 0x0084EDC1 File Offset: 0x0084CFC1
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float EndTime
	{
		get
		{
			return *(base.NativePtr + (IntPtr)ItemMaterialControllerActorData.__PropertyOffset_EndTime);
		}
		set
		{
			*(base.NativePtr + (IntPtr)ItemMaterialControllerActorData.__PropertyOffset_EndTime) = value;
		}
	}

	// Token: 0x170025B7 RID: 9655
	// (get) Token: 0x0601BDE0 RID: 114144 RVA: 0x0084EDD2 File Offset: 0x0084CFD2
	// (set) Token: 0x0601BDE1 RID: 114145 RVA: 0x0084EDE2 File Offset: 0x0084CFE2
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool EnableBaseColorScale
	{
		get
		{
			return *(base.NativePtr + (IntPtr)ItemMaterialControllerActorData.__PropertyOffset_EnableBaseColorScale) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)ItemMaterialControllerActorData.__PropertyOffset_EnableBaseColorScale) = (value ? 1 : 0);
		}
	}

	// Token: 0x170025B8 RID: 9656
	// (get) Token: 0x0601BDE2 RID: 114146 RVA: 0x0084EDF4 File Offset: 0x0084CFF4
	// (set) Token: 0x0601BDE3 RID: 114147 RVA: 0x0084EE2D File Offset: 0x0084D02D
	[UProperty(EPropertyFlags.CPF_None)]
	public FKuroCurveFloat BaseColorScale
	{
		get
		{
			base.FastCheckIsValid();
			FKuroCurveFloat result;
			if ((result = this._BaseColorScale) == null)
			{
				result = (this._BaseColorScale = new FKuroCurveFloat(base.NativePtr + (IntPtr)ItemMaterialControllerActorData.__PropertyOffset_BaseColorScale, this));
			}
			return result;
		}
		set
		{
			UnrealReflectionUtils.CopyNativeStruct(FKuroCurveFloat.StaticStruct(), base.NativePtr + (IntPtr)ItemMaterialControllerActorData.__PropertyOffset_BaseColorScale, (value != null) ? value.NativePtr : ((IntPtr)0), 1, false);
		}
	}

	// Token: 0x170025B9 RID: 9657
	// (get) Token: 0x0601BDE4 RID: 114148 RVA: 0x0084EE55 File Offset: 0x0084D055
	// (set) Token: 0x0601BDE5 RID: 114149 RVA: 0x0084EE65 File Offset: 0x0084D065
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool EnableAddEmissionColor
	{
		get
		{
			return *(base.NativePtr + (IntPtr)ItemMaterialControllerActorData.__PropertyOffset_EnableAddEmissionColor) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)ItemMaterialControllerActorData.__PropertyOffset_EnableAddEmissionColor) = (value ? 1 : 0);
		}
	}

	// Token: 0x170025BA RID: 9658
	// (get) Token: 0x0601BDE6 RID: 114150 RVA: 0x0084EE78 File Offset: 0x0084D078
	// (set) Token: 0x0601BDE7 RID: 114151 RVA: 0x0084EEB1 File Offset: 0x0084D0B1
	[UProperty(EPropertyFlags.CPF_None)]
	public FKuroCurveLinearColor AddEmissionColor
	{
		get
		{
			base.FastCheckIsValid();
			FKuroCurveLinearColor result;
			if ((result = this._AddEmissionColor) == null)
			{
				result = (this._AddEmissionColor = new FKuroCurveLinearColor(base.NativePtr + (IntPtr)ItemMaterialControllerActorData.__PropertyOffset_AddEmissionColor, this));
			}
			return result;
		}
		set
		{
			UnrealReflectionUtils.CopyNativeStruct(FKuroCurveLinearColor.StaticStruct(), base.NativePtr + (IntPtr)ItemMaterialControllerActorData.__PropertyOffset_AddEmissionColor, (value != null) ? value.NativePtr : ((IntPtr)0), 1, false);
		}
	}

	// Token: 0x170025BB RID: 9659
	// (get) Token: 0x0601BDE8 RID: 114152 RVA: 0x0084EED9 File Offset: 0x0084D0D9
	// (set) Token: 0x0601BDE9 RID: 114153 RVA: 0x0084EEE9 File Offset: 0x0084D0E9
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool EnableEmissionChange
	{
		get
		{
			return *(base.NativePtr + (IntPtr)ItemMaterialControllerActorData.__PropertyOffset_EnableEmissionChange) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)ItemMaterialControllerActorData.__PropertyOffset_EnableEmissionChange) = (value ? 1 : 0);
		}
	}

	// Token: 0x170025BC RID: 9660
	// (get) Token: 0x0601BDEA RID: 114154 RVA: 0x0084EEFC File Offset: 0x0084D0FC
	// (set) Token: 0x0601BDEB RID: 114155 RVA: 0x0084EF35 File Offset: 0x0084D135
	[UProperty(EPropertyFlags.CPF_None)]
	public FKuroCurveFloat EmissionLightColorChangeProgress
	{
		get
		{
			base.FastCheckIsValid();
			FKuroCurveFloat result;
			if ((result = this._EmissionLightColorChangeProgress) == null)
			{
				result = (this._EmissionLightColorChangeProgress = new FKuroCurveFloat(base.NativePtr + (IntPtr)ItemMaterialControllerActorData.__PropertyOffset_EmissionLightColorChangeProgress, this));
			}
			return result;
		}
		set
		{
			UnrealReflectionUtils.CopyNativeStruct(FKuroCurveFloat.StaticStruct(), base.NativePtr + (IntPtr)ItemMaterialControllerActorData.__PropertyOffset_EmissionLightColorChangeProgress, (value != null) ? value.NativePtr : ((IntPtr)0), 1, false);
		}
	}

	// Token: 0x170025BD RID: 9661
	// (get) Token: 0x0601BDEC RID: 114156 RVA: 0x0084EF60 File Offset: 0x0084D160
	// (set) Token: 0x0601BDED RID: 114157 RVA: 0x0084EF99 File Offset: 0x0084D199
	[UProperty(EPropertyFlags.CPF_None)]
	public FKuroCurveFloat EmissionLightColorChangeStrength
	{
		get
		{
			base.FastCheckIsValid();
			FKuroCurveFloat result;
			if ((result = this._EmissionLightColorChangeStrength) == null)
			{
				result = (this._EmissionLightColorChangeStrength = new FKuroCurveFloat(base.NativePtr + (IntPtr)ItemMaterialControllerActorData.__PropertyOffset_EmissionLightColorChangeStrength, this));
			}
			return result;
		}
		set
		{
			UnrealReflectionUtils.CopyNativeStruct(FKuroCurveFloat.StaticStruct(), base.NativePtr + (IntPtr)ItemMaterialControllerActorData.__PropertyOffset_EmissionLightColorChangeStrength, (value != null) ? value.NativePtr : ((IntPtr)0), 1, false);
		}
	}

	// Token: 0x170025BE RID: 9662
	// (get) Token: 0x0601BDEE RID: 114158 RVA: 0x0084EFC4 File Offset: 0x0084D1C4
	// (set) Token: 0x0601BDEF RID: 114159 RVA: 0x0084EFFD File Offset: 0x0084D1FD
	[UProperty(EPropertyFlags.CPF_None)]
	public FKuroCurveLinearColor EmissionLightColorChangeColor
	{
		get
		{
			base.FastCheckIsValid();
			FKuroCurveLinearColor result;
			if ((result = this._EmissionLightColorChangeColor) == null)
			{
				result = (this._EmissionLightColorChangeColor = new FKuroCurveLinearColor(base.NativePtr + (IntPtr)ItemMaterialControllerActorData.__PropertyOffset_EmissionLightColorChangeColor, this));
			}
			return result;
		}
		set
		{
			UnrealReflectionUtils.CopyNativeStruct(FKuroCurveLinearColor.StaticStruct(), base.NativePtr + (IntPtr)ItemMaterialControllerActorData.__PropertyOffset_EmissionLightColorChangeColor, (value != null) ? value.NativePtr : ((IntPtr)0), 1, false);
		}
	}

	// Token: 0x170025BF RID: 9663
	// (get) Token: 0x0601BDF0 RID: 114160 RVA: 0x0084F025 File Offset: 0x0084D225
	// (set) Token: 0x0601BDF1 RID: 114161 RVA: 0x0084F035 File Offset: 0x0084D235
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool EnableRimLight
	{
		get
		{
			return *(base.NativePtr + (IntPtr)ItemMaterialControllerActorData.__PropertyOffset_EnableRimLight) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)ItemMaterialControllerActorData.__PropertyOffset_EnableRimLight) = (value ? 1 : 0);
		}
	}

	// Token: 0x170025C0 RID: 9664
	// (get) Token: 0x0601BDF2 RID: 114162 RVA: 0x0084F048 File Offset: 0x0084D248
	// (set) Token: 0x0601BDF3 RID: 114163 RVA: 0x0084F081 File Offset: 0x0084D281
	[UProperty(EPropertyFlags.CPF_None)]
	public FKuroCurveLinearColor RimLightColor
	{
		get
		{
			base.FastCheckIsValid();
			FKuroCurveLinearColor result;
			if ((result = this._RimLightColor) == null)
			{
				result = (this._RimLightColor = new FKuroCurveLinearColor(base.NativePtr + (IntPtr)ItemMaterialControllerActorData.__PropertyOffset_RimLightColor, this));
			}
			return result;
		}
		set
		{
			UnrealReflectionUtils.CopyNativeStruct(FKuroCurveLinearColor.StaticStruct(), base.NativePtr + (IntPtr)ItemMaterialControllerActorData.__PropertyOffset_RimLightColor, (value != null) ? value.NativePtr : ((IntPtr)0), 1, false);
		}
	}

	// Token: 0x170025C1 RID: 9665
	// (get) Token: 0x0601BDF4 RID: 114164 RVA: 0x0084F0AC File Offset: 0x0084D2AC
	// (set) Token: 0x0601BDF5 RID: 114165 RVA: 0x0084F0E5 File Offset: 0x0084D2E5
	[UProperty(EPropertyFlags.CPF_None)]
	public FKuroCurveFloat RimPower
	{
		get
		{
			base.FastCheckIsValid();
			FKuroCurveFloat result;
			if ((result = this._RimPower) == null)
			{
				result = (this._RimPower = new FKuroCurveFloat(base.NativePtr + (IntPtr)ItemMaterialControllerActorData.__PropertyOffset_RimPower, this));
			}
			return result;
		}
		set
		{
			UnrealReflectionUtils.CopyNativeStruct(FKuroCurveFloat.StaticStruct(), base.NativePtr + (IntPtr)ItemMaterialControllerActorData.__PropertyOffset_RimPower, (value != null) ? value.NativePtr : ((IntPtr)0), 1, false);
		}
	}

	// Token: 0x170025C2 RID: 9666
	// (get) Token: 0x0601BDF6 RID: 114166 RVA: 0x0084F10D File Offset: 0x0084D30D
	// (set) Token: 0x0601BDF7 RID: 114167 RVA: 0x0084F11D File Offset: 0x0084D31D
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool EnableDissolve
	{
		get
		{
			return *(base.NativePtr + (IntPtr)ItemMaterialControllerActorData.__PropertyOffset_EnableDissolve) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)ItemMaterialControllerActorData.__PropertyOffset_EnableDissolve) = (value ? 1 : 0);
		}
	}

	// Token: 0x170025C3 RID: 9667
	// (get) Token: 0x0601BDF8 RID: 114168 RVA: 0x0084F130 File Offset: 0x0084D330
	// (set) Token: 0x0601BDF9 RID: 114169 RVA: 0x0084F169 File Offset: 0x0084D369
	[UProperty(EPropertyFlags.CPF_None)]
	public FKuroCurveFloat DissolveProgress
	{
		get
		{
			base.FastCheckIsValid();
			FKuroCurveFloat result;
			if ((result = this._DissolveProgress) == null)
			{
				result = (this._DissolveProgress = new FKuroCurveFloat(base.NativePtr + (IntPtr)ItemMaterialControllerActorData.__PropertyOffset_DissolveProgress, this));
			}
			return result;
		}
		set
		{
			UnrealReflectionUtils.CopyNativeStruct(FKuroCurveFloat.StaticStruct(), base.NativePtr + (IntPtr)ItemMaterialControllerActorData.__PropertyOffset_DissolveProgress, (value != null) ? value.NativePtr : ((IntPtr)0), 1, false);
		}
	}

	// Token: 0x170025C4 RID: 9668
	// (get) Token: 0x0601BDFA RID: 114170 RVA: 0x0084F194 File Offset: 0x0084D394
	// (set) Token: 0x0601BDFB RID: 114171 RVA: 0x0084F1CD File Offset: 0x0084D3CD
	[UProperty(EPropertyFlags.CPF_None)]
	public FKuroCurveFloat DissolveAdjustment
	{
		get
		{
			base.FastCheckIsValid();
			FKuroCurveFloat result;
			if ((result = this._DissolveAdjustment) == null)
			{
				result = (this._DissolveAdjustment = new FKuroCurveFloat(base.NativePtr + (IntPtr)ItemMaterialControllerActorData.__PropertyOffset_DissolveAdjustment, this));
			}
			return result;
		}
		set
		{
			UnrealReflectionUtils.CopyNativeStruct(FKuroCurveFloat.StaticStruct(), base.NativePtr + (IntPtr)ItemMaterialControllerActorData.__PropertyOffset_DissolveAdjustment, (value != null) ? value.NativePtr : ((IntPtr)0), 1, false);
		}
	}

	// Token: 0x170025C5 RID: 9669
	// (get) Token: 0x0601BDFC RID: 114172 RVA: 0x0084F1F8 File Offset: 0x0084D3F8
	// (set) Token: 0x0601BDFD RID: 114173 RVA: 0x0084F231 File Offset: 0x0084D431
	[UProperty(EPropertyFlags.CPF_None)]
	public FKuroCurveFloat DissolveEdageWidth
	{
		get
		{
			base.FastCheckIsValid();
			FKuroCurveFloat result;
			if ((result = this._DissolveEdageWidth) == null)
			{
				result = (this._DissolveEdageWidth = new FKuroCurveFloat(base.NativePtr + (IntPtr)ItemMaterialControllerActorData.__PropertyOffset_DissolveEdageWidth, this));
			}
			return result;
		}
		set
		{
			UnrealReflectionUtils.CopyNativeStruct(FKuroCurveFloat.StaticStruct(), base.NativePtr + (IntPtr)ItemMaterialControllerActorData.__PropertyOffset_DissolveEdageWidth, (value != null) ? value.NativePtr : ((IntPtr)0), 1, false);
		}
	}

	// Token: 0x170025C6 RID: 9670
	// (get) Token: 0x0601BDFE RID: 114174 RVA: 0x0084F25C File Offset: 0x0084D45C
	// (set) Token: 0x0601BDFF RID: 114175 RVA: 0x0084F295 File Offset: 0x0084D495
	[UProperty(EPropertyFlags.CPF_None)]
	public FKuroCurveLinearColor DissolveEdageColor
	{
		get
		{
			base.FastCheckIsValid();
			FKuroCurveLinearColor result;
			if ((result = this._DissolveEdageColor) == null)
			{
				result = (this._DissolveEdageColor = new FKuroCurveLinearColor(base.NativePtr + (IntPtr)ItemMaterialControllerActorData.__PropertyOffset_DissolveEdageColor, this));
			}
			return result;
		}
		set
		{
			UnrealReflectionUtils.CopyNativeStruct(FKuroCurveLinearColor.StaticStruct(), base.NativePtr + (IntPtr)ItemMaterialControllerActorData.__PropertyOffset_DissolveEdageColor, (value != null) ? value.NativePtr : ((IntPtr)0), 1, false);
		}
	}

	// Token: 0x170025C7 RID: 9671
	// (get) Token: 0x0601BE00 RID: 114176 RVA: 0x0084F2C0 File Offset: 0x0084D4C0
	// (set) Token: 0x0601BE01 RID: 114177 RVA: 0x0084F2F9 File Offset: 0x0084D4F9
	[UProperty(EPropertyFlags.CPF_None)]
	public FKuroCurveFloat DissolveEdageStrength
	{
		get
		{
			base.FastCheckIsValid();
			FKuroCurveFloat result;
			if ((result = this._DissolveEdageStrength) == null)
			{
				result = (this._DissolveEdageStrength = new FKuroCurveFloat(base.NativePtr + (IntPtr)ItemMaterialControllerActorData.__PropertyOffset_DissolveEdageStrength, this));
			}
			return result;
		}
		set
		{
			UnrealReflectionUtils.CopyNativeStruct(FKuroCurveFloat.StaticStruct(), base.NativePtr + (IntPtr)ItemMaterialControllerActorData.__PropertyOffset_DissolveEdageStrength, (value != null) ? value.NativePtr : ((IntPtr)0), 1, false);
		}
	}

	// Token: 0x170025C8 RID: 9672
	// (get) Token: 0x0601BE02 RID: 114178 RVA: 0x0084F324 File Offset: 0x0084D524
	// (set) Token: 0x0601BE03 RID: 114179 RVA: 0x0084F35D File Offset: 0x0084D55D
	[UProperty(EPropertyFlags.CPF_None)]
	public FKuroCurveLinearColor DissolveTexSpeed
	{
		get
		{
			base.FastCheckIsValid();
			FKuroCurveLinearColor result;
			if ((result = this._DissolveTexSpeed) == null)
			{
				result = (this._DissolveTexSpeed = new FKuroCurveLinearColor(base.NativePtr + (IntPtr)ItemMaterialControllerActorData.__PropertyOffset_DissolveTexSpeed, this));
			}
			return result;
		}
		set
		{
			UnrealReflectionUtils.CopyNativeStruct(FKuroCurveLinearColor.StaticStruct(), base.NativePtr + (IntPtr)ItemMaterialControllerActorData.__PropertyOffset_DissolveTexSpeed, (value != null) ? value.NativePtr : ((IntPtr)0), 1, false);
		}
	}

	// Token: 0x170025C9 RID: 9673
	// (get) Token: 0x0601BE04 RID: 114180 RVA: 0x0084F385 File Offset: 0x0084D585
	// (set) Token: 0x0601BE05 RID: 114181 RVA: 0x0084F395 File Offset: 0x0084D595
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe ECharacterControllerUVSwitch DissolveUv
	{
		get
		{
			return (ECharacterControllerUVSwitch)(*(base.NativePtr + (IntPtr)ItemMaterialControllerActorData.__PropertyOffset_DissolveUv));
		}
		set
		{
			*(base.NativePtr + (IntPtr)ItemMaterialControllerActorData.__PropertyOffset_DissolveUv) = (byte)value;
		}
	}

	// Token: 0x170025CA RID: 9674
	// (get) Token: 0x0601BE06 RID: 114182 RVA: 0x0084F3A8 File Offset: 0x0084D5A8
	// (set) Token: 0x0601BE07 RID: 114183 RVA: 0x0084F3E1 File Offset: 0x0084D5E1
	[UProperty(EPropertyFlags.CPF_None)]
	public FKuroCurveLinearColor DissolveTexScaleOffset
	{
		get
		{
			base.FastCheckIsValid();
			FKuroCurveLinearColor result;
			if ((result = this._DissolveTexScaleOffset) == null)
			{
				result = (this._DissolveTexScaleOffset = new FKuroCurveLinearColor(base.NativePtr + (IntPtr)ItemMaterialControllerActorData.__PropertyOffset_DissolveTexScaleOffset, this));
			}
			return result;
		}
		set
		{
			UnrealReflectionUtils.CopyNativeStruct(FKuroCurveLinearColor.StaticStruct(), base.NativePtr + (IntPtr)ItemMaterialControllerActorData.__PropertyOffset_DissolveTexScaleOffset, (value != null) ? value.NativePtr : ((IntPtr)0), 1, false);
		}
	}

	// Token: 0x170025CB RID: 9675
	// (get) Token: 0x0601BE08 RID: 114184 RVA: 0x0084F409 File Offset: 0x0084D609
	// (set) Token: 0x0601BE09 RID: 114185 RVA: 0x0084F419 File Offset: 0x0084D619
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool EnableScanning
	{
		get
		{
			return *(base.NativePtr + (IntPtr)ItemMaterialControllerActorData.__PropertyOffset_EnableScanning) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)ItemMaterialControllerActorData.__PropertyOffset_EnableScanning) = (value ? 1 : 0);
		}
	}

	// Token: 0x170025CC RID: 9676
	// (get) Token: 0x0601BE0A RID: 114186 RVA: 0x0084F42C File Offset: 0x0084D62C
	// (set) Token: 0x0601BE0B RID: 114187 RVA: 0x0084F465 File Offset: 0x0084D665
	[UProperty(EPropertyFlags.CPF_None)]
	public FKuroCurveFloat ScanningOutlineMixNoiseStrength
	{
		get
		{
			base.FastCheckIsValid();
			FKuroCurveFloat result;
			if ((result = this._ScanningOutlineMixNoiseStrength) == null)
			{
				result = (this._ScanningOutlineMixNoiseStrength = new FKuroCurveFloat(base.NativePtr + (IntPtr)ItemMaterialControllerActorData.__PropertyOffset_ScanningOutlineMixNoiseStrength, this));
			}
			return result;
		}
		set
		{
			UnrealReflectionUtils.CopyNativeStruct(FKuroCurveFloat.StaticStruct(), base.NativePtr + (IntPtr)ItemMaterialControllerActorData.__PropertyOffset_ScanningOutlineMixNoiseStrength, (value != null) ? value.NativePtr : ((IntPtr)0), 1, false);
		}
	}

	// Token: 0x170025CD RID: 9677
	// (get) Token: 0x0601BE0C RID: 114188 RVA: 0x0084F490 File Offset: 0x0084D690
	// (set) Token: 0x0601BE0D RID: 114189 RVA: 0x0084F4C9 File Offset: 0x0084D6C9
	[UProperty(EPropertyFlags.CPF_None)]
	public FKuroCurveFloat ScanningOutlineStrength
	{
		get
		{
			base.FastCheckIsValid();
			FKuroCurveFloat result;
			if ((result = this._ScanningOutlineStrength) == null)
			{
				result = (this._ScanningOutlineStrength = new FKuroCurveFloat(base.NativePtr + (IntPtr)ItemMaterialControllerActorData.__PropertyOffset_ScanningOutlineStrength, this));
			}
			return result;
		}
		set
		{
			UnrealReflectionUtils.CopyNativeStruct(FKuroCurveFloat.StaticStruct(), base.NativePtr + (IntPtr)ItemMaterialControllerActorData.__PropertyOffset_ScanningOutlineStrength, (value != null) ? value.NativePtr : ((IntPtr)0), 1, false);
		}
	}

	// Token: 0x170025CE RID: 9678
	// (get) Token: 0x0601BE0E RID: 114190 RVA: 0x0084F4F4 File Offset: 0x0084D6F4
	// (set) Token: 0x0601BE0F RID: 114191 RVA: 0x0084F52D File Offset: 0x0084D72D
	[UProperty(EPropertyFlags.CPF_None)]
	public FKuroCurveLinearColor ScanningOutlineTexScaleOffset
	{
		get
		{
			base.FastCheckIsValid();
			FKuroCurveLinearColor result;
			if ((result = this._ScanningOutlineTexScaleOffset) == null)
			{
				result = (this._ScanningOutlineTexScaleOffset = new FKuroCurveLinearColor(base.NativePtr + (IntPtr)ItemMaterialControllerActorData.__PropertyOffset_ScanningOutlineTexScaleOffset, this));
			}
			return result;
		}
		set
		{
			UnrealReflectionUtils.CopyNativeStruct(FKuroCurveLinearColor.StaticStruct(), base.NativePtr + (IntPtr)ItemMaterialControllerActorData.__PropertyOffset_ScanningOutlineTexScaleOffset, (value != null) ? value.NativePtr : ((IntPtr)0), 1, false);
		}
	}

	// Token: 0x170025CF RID: 9679
	// (get) Token: 0x0601BE10 RID: 114192 RVA: 0x0084F558 File Offset: 0x0084D758
	// (set) Token: 0x0601BE11 RID: 114193 RVA: 0x0084F591 File Offset: 0x0084D791
	[UProperty(EPropertyFlags.CPF_None)]
	public FKuroCurveLinearColor ScanningOutlineColor
	{
		get
		{
			base.FastCheckIsValid();
			FKuroCurveLinearColor result;
			if ((result = this._ScanningOutlineColor) == null)
			{
				result = (this._ScanningOutlineColor = new FKuroCurveLinearColor(base.NativePtr + (IntPtr)ItemMaterialControllerActorData.__PropertyOffset_ScanningOutlineColor, this));
			}
			return result;
		}
		set
		{
			UnrealReflectionUtils.CopyNativeStruct(FKuroCurveLinearColor.StaticStruct(), base.NativePtr + (IntPtr)ItemMaterialControllerActorData.__PropertyOffset_ScanningOutlineColor, (value != null) ? value.NativePtr : ((IntPtr)0), 1, false);
		}
	}

	// Token: 0x170025D0 RID: 9680
	// (get) Token: 0x0601BE12 RID: 114194 RVA: 0x0084F5BC File Offset: 0x0084D7BC
	// (set) Token: 0x0601BE13 RID: 114195 RVA: 0x0084F5F5 File Offset: 0x0084D7F5
	[UProperty(EPropertyFlags.CPF_None)]
	public FKuroCurveFloat VertexAnimTimeDebug
	{
		get
		{
			base.FastCheckIsValid();
			FKuroCurveFloat result;
			if ((result = this._VertexAnimTimeDebug) == null)
			{
				result = (this._VertexAnimTimeDebug = new FKuroCurveFloat(base.NativePtr + (IntPtr)ItemMaterialControllerActorData.__PropertyOffset_VertexAnimTimeDebug, this));
			}
			return result;
		}
		set
		{
			UnrealReflectionUtils.CopyNativeStruct(FKuroCurveFloat.StaticStruct(), base.NativePtr + (IntPtr)ItemMaterialControllerActorData.__PropertyOffset_VertexAnimTimeDebug, (value != null) ? value.NativePtr : ((IntPtr)0), 1, false);
		}
	}

	// Token: 0x170025D1 RID: 9681
	// (get) Token: 0x0601BE14 RID: 114196 RVA: 0x0084F620 File Offset: 0x0084D820
	// (set) Token: 0x0601BE15 RID: 114197 RVA: 0x0084F659 File Offset: 0x0084D859
	[UProperty(EPropertyFlags.CPF_None)]
	public FKuroCurveFloat VertexAnimFrame
	{
		get
		{
			base.FastCheckIsValid();
			FKuroCurveFloat result;
			if ((result = this._VertexAnimFrame) == null)
			{
				result = (this._VertexAnimFrame = new FKuroCurveFloat(base.NativePtr + (IntPtr)ItemMaterialControllerActorData.__PropertyOffset_VertexAnimFrame, this));
			}
			return result;
		}
		set
		{
			UnrealReflectionUtils.CopyNativeStruct(FKuroCurveFloat.StaticStruct(), base.NativePtr + (IntPtr)ItemMaterialControllerActorData.__PropertyOffset_VertexAnimFrame, (value != null) ? value.NativePtr : ((IntPtr)0), 1, false);
		}
	}

	// Token: 0x170025D2 RID: 9682
	// (get) Token: 0x0601BE16 RID: 114198 RVA: 0x0084F684 File Offset: 0x0084D884
	// (set) Token: 0x0601BE17 RID: 114199 RVA: 0x0084F6BD File Offset: 0x0084D8BD
	[UProperty(EPropertyFlags.CPF_None)]
	public FKuroCurveLinearColor PivotPainterTransform
	{
		get
		{
			base.FastCheckIsValid();
			FKuroCurveLinearColor result;
			if ((result = this._PivotPainterTransform) == null)
			{
				result = (this._PivotPainterTransform = new FKuroCurveLinearColor(base.NativePtr + (IntPtr)ItemMaterialControllerActorData.__PropertyOffset_PivotPainterTransform, this));
			}
			return result;
		}
		set
		{
			UnrealReflectionUtils.CopyNativeStruct(FKuroCurveLinearColor.StaticStruct(), base.NativePtr + (IntPtr)ItemMaterialControllerActorData.__PropertyOffset_PivotPainterTransform, (value != null) ? value.NativePtr : ((IntPtr)0), 1, false);
		}
	}

	// Token: 0x170025D3 RID: 9683
	// (get) Token: 0x0601BE18 RID: 114200 RVA: 0x0084F6E8 File Offset: 0x0084D8E8
	// (set) Token: 0x0601BE19 RID: 114201 RVA: 0x0084F721 File Offset: 0x0084D921
	[UProperty(EPropertyFlags.CPF_None)]
	public FKuroCurveFloat FloatingThreshold
	{
		get
		{
			base.FastCheckIsValid();
			FKuroCurveFloat result;
			if ((result = this._FloatingThreshold) == null)
			{
				result = (this._FloatingThreshold = new FKuroCurveFloat(base.NativePtr + (IntPtr)ItemMaterialControllerActorData.__PropertyOffset_FloatingThreshold, this));
			}
			return result;
		}
		set
		{
			UnrealReflectionUtils.CopyNativeStruct(FKuroCurveFloat.StaticStruct(), base.NativePtr + (IntPtr)ItemMaterialControllerActorData.__PropertyOffset_FloatingThreshold, (value != null) ? value.NativePtr : ((IntPtr)0), 1, false);
		}
	}

	// Token: 0x170025D4 RID: 9684
	// (get) Token: 0x0601BE1A RID: 114202 RVA: 0x0084F749 File Offset: 0x0084D949
	// (set) Token: 0x0601BE1B RID: 114203 RVA: 0x0084F759 File Offset: 0x0084D959
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool EnablePivotPainterWorldPositionOffset
	{
		get
		{
			return *(base.NativePtr + (IntPtr)ItemMaterialControllerActorData.__PropertyOffset_EnablePivotPainterWorldPositionOffset) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)ItemMaterialControllerActorData.__PropertyOffset_EnablePivotPainterWorldPositionOffset) = (value ? 1 : 0);
		}
	}

	// Token: 0x170025D5 RID: 9685
	// (get) Token: 0x0601BE1C RID: 114204 RVA: 0x0084F76A File Offset: 0x0084D96A
	// (set) Token: 0x0601BE1D RID: 114205 RVA: 0x0084F77A File Offset: 0x0084D97A
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool EnableWorldPositionOffset
	{
		get
		{
			return *(base.NativePtr + (IntPtr)ItemMaterialControllerActorData.__PropertyOffset_EnableWorldPositionOffset) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)ItemMaterialControllerActorData.__PropertyOffset_EnableWorldPositionOffset) = (value ? 1 : 0);
		}
	}

	// Token: 0x170025D6 RID: 9686
	// (get) Token: 0x0601BE1E RID: 114206 RVA: 0x0084F78B File Offset: 0x0084D98B
	// (set) Token: 0x0601BE1F RID: 114207 RVA: 0x0084F79B File Offset: 0x0084D99B
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool DisableFoliageEffect
	{
		get
		{
			return *(base.NativePtr + (IntPtr)ItemMaterialControllerActorData.__PropertyOffset_DisableFoliageEffect) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)ItemMaterialControllerActorData.__PropertyOffset_DisableFoliageEffect) = (value ? 1 : 0);
		}
	}

	// Token: 0x170025D7 RID: 9687
	// (get) Token: 0x0601BE20 RID: 114208 RVA: 0x0084F7AC File Offset: 0x0084D9AC
	// (set) Token: 0x0601BE21 RID: 114209 RVA: 0x0084F7BC File Offset: 0x0084D9BC
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool EnableFoliageEffect
	{
		get
		{
			return *(base.NativePtr + (IntPtr)ItemMaterialControllerActorData.__PropertyOffset_EnableFoliageEffect) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)ItemMaterialControllerActorData.__PropertyOffset_EnableFoliageEffect) = (value ? 1 : 0);
		}
	}

	// Token: 0x170025D8 RID: 9688
	// (get) Token: 0x0601BE22 RID: 114210 RVA: 0x0084F7D0 File Offset: 0x0084D9D0
	// (set) Token: 0x0601BE23 RID: 114211 RVA: 0x0084F809 File Offset: 0x0084DA09
	[UProperty(EPropertyFlags.CPF_None)]
	public FKuroCurveLinearColor RimLightColorSpecil
	{
		get
		{
			base.FastCheckIsValid();
			FKuroCurveLinearColor result;
			if ((result = this._RimLightColorSpecil) == null)
			{
				result = (this._RimLightColorSpecil = new FKuroCurveLinearColor(base.NativePtr + (IntPtr)ItemMaterialControllerActorData.__PropertyOffset_RimLightColorSpecil, this));
			}
			return result;
		}
		set
		{
			UnrealReflectionUtils.CopyNativeStruct(FKuroCurveLinearColor.StaticStruct(), base.NativePtr + (IntPtr)ItemMaterialControllerActorData.__PropertyOffset_RimLightColorSpecil, (value != null) ? value.NativePtr : ((IntPtr)0), 1, false);
		}
	}

	// Token: 0x170025D9 RID: 9689
	// (get) Token: 0x0601BE24 RID: 114212 RVA: 0x0084F831 File Offset: 0x0084DA31
	// (set) Token: 0x0601BE25 RID: 114213 RVA: 0x0084F841 File Offset: 0x0084DA41
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool UseRimlightColorSpecil
	{
		get
		{
			return *(base.NativePtr + (IntPtr)ItemMaterialControllerActorData.__PropertyOffset_UseRimlightColorSpecil) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)ItemMaterialControllerActorData.__PropertyOffset_UseRimlightColorSpecil) = (value ? 1 : 0);
		}
	}

	// Token: 0x170025DA RID: 9690
	// (get) Token: 0x0601BE26 RID: 114214 RVA: 0x0084F854 File Offset: 0x0084DA54
	// (set) Token: 0x0601BE27 RID: 114215 RVA: 0x0084F88D File Offset: 0x0084DA8D
	[UProperty(EPropertyFlags.CPF_None)]
	public FKuroCurveFloat RimlightColorStrength
	{
		get
		{
			base.FastCheckIsValid();
			FKuroCurveFloat result;
			if ((result = this._RimlightColorStrength) == null)
			{
				result = (this._RimlightColorStrength = new FKuroCurveFloat(base.NativePtr + (IntPtr)ItemMaterialControllerActorData.__PropertyOffset_RimlightColorStrength, this));
			}
			return result;
		}
		set
		{
			UnrealReflectionUtils.CopyNativeStruct(FKuroCurveFloat.StaticStruct(), base.NativePtr + (IntPtr)ItemMaterialControllerActorData.__PropertyOffset_RimlightColorStrength, (value != null) ? value.NativePtr : ((IntPtr)0), 1, false);
		}
	}

	// Token: 0x170025DB RID: 9691
	// (get) Token: 0x0601BE28 RID: 114216 RVA: 0x0084F8B5 File Offset: 0x0084DAB5
	// (set) Token: 0x0601BE29 RID: 114217 RVA: 0x0084F8C5 File Offset: 0x0084DAC5
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool UseEmissionTex
	{
		get
		{
			return *(base.NativePtr + (IntPtr)ItemMaterialControllerActorData.__PropertyOffset_UseEmissionTex) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)ItemMaterialControllerActorData.__PropertyOffset_UseEmissionTex) = (value ? 1 : 0);
		}
	}

	// Token: 0x170025DC RID: 9692
	// (get) Token: 0x0601BE2A RID: 114218 RVA: 0x0084F8D8 File Offset: 0x0084DAD8
	// (set) Token: 0x0601BE2B RID: 114219 RVA: 0x0084F911 File Offset: 0x0084DB11
	[UProperty(EPropertyFlags.CPF_None)]
	public FKuroCurveFloat EmissionTexStrength
	{
		get
		{
			base.FastCheckIsValid();
			FKuroCurveFloat result;
			if ((result = this._EmissionTexStrength) == null)
			{
				result = (this._EmissionTexStrength = new FKuroCurveFloat(base.NativePtr + (IntPtr)ItemMaterialControllerActorData.__PropertyOffset_EmissionTexStrength, this));
			}
			return result;
		}
		set
		{
			UnrealReflectionUtils.CopyNativeStruct(FKuroCurveFloat.StaticStruct(), base.NativePtr + (IntPtr)ItemMaterialControllerActorData.__PropertyOffset_EmissionTexStrength, (value != null) ? value.NativePtr : ((IntPtr)0), 1, false);
		}
	}

	// Token: 0x170025DD RID: 9693
	// (get) Token: 0x0601BE2C RID: 114220 RVA: 0x0084F93C File Offset: 0x0084DB3C
	// (set) Token: 0x0601BE2D RID: 114221 RVA: 0x0084F975 File Offset: 0x0084DB75
	[UProperty(EPropertyFlags.CPF_None)]
	public FKuroCurveFloat WorldPositionOffsetNormal
	{
		get
		{
			base.FastCheckIsValid();
			FKuroCurveFloat result;
			if ((result = this._WorldPositionOffsetNormal) == null)
			{
				result = (this._WorldPositionOffsetNormal = new FKuroCurveFloat(base.NativePtr + (IntPtr)ItemMaterialControllerActorData.__PropertyOffset_WorldPositionOffsetNormal, this));
			}
			return result;
		}
		set
		{
			UnrealReflectionUtils.CopyNativeStruct(FKuroCurveFloat.StaticStruct(), base.NativePtr + (IntPtr)ItemMaterialControllerActorData.__PropertyOffset_WorldPositionOffsetNormal, (value != null) ? value.NativePtr : ((IntPtr)0), 1, false);
		}
	}

	// Token: 0x170025DE RID: 9694
	// (get) Token: 0x0601BE2E RID: 114222 RVA: 0x0084F9A0 File Offset: 0x0084DBA0
	// (set) Token: 0x0601BE2F RID: 114223 RVA: 0x0084F9D9 File Offset: 0x0084DBD9
	[UProperty(EPropertyFlags.CPF_None)]
	public FKuroCurveLinearColor WorldPositionOffsetOffset
	{
		get
		{
			base.FastCheckIsValid();
			FKuroCurveLinearColor result;
			if ((result = this._WorldPositionOffsetOffset) == null)
			{
				result = (this._WorldPositionOffsetOffset = new FKuroCurveLinearColor(base.NativePtr + (IntPtr)ItemMaterialControllerActorData.__PropertyOffset_WorldPositionOffsetOffset, this));
			}
			return result;
		}
		set
		{
			UnrealReflectionUtils.CopyNativeStruct(FKuroCurveLinearColor.StaticStruct(), base.NativePtr + (IntPtr)ItemMaterialControllerActorData.__PropertyOffset_WorldPositionOffsetOffset, (value != null) ? value.NativePtr : ((IntPtr)0), 1, false);
		}
	}

	// Token: 0x170025DF RID: 9695
	// (get) Token: 0x0601BE30 RID: 114224 RVA: 0x0084FA04 File Offset: 0x0084DC04
	// (set) Token: 0x0601BE31 RID: 114225 RVA: 0x0084FA3D File Offset: 0x0084DC3D
	[UProperty(EPropertyFlags.CPF_None)]
	public FKuroCurveFloat SimpleUspeed
	{
		get
		{
			base.FastCheckIsValid();
			FKuroCurveFloat result;
			if ((result = this._SimpleUspeed) == null)
			{
				result = (this._SimpleUspeed = new FKuroCurveFloat(base.NativePtr + (IntPtr)ItemMaterialControllerActorData.__PropertyOffset_SimpleUspeed, this));
			}
			return result;
		}
		set
		{
			UnrealReflectionUtils.CopyNativeStruct(FKuroCurveFloat.StaticStruct(), base.NativePtr + (IntPtr)ItemMaterialControllerActorData.__PropertyOffset_SimpleUspeed, (value != null) ? value.NativePtr : ((IntPtr)0), 1, false);
		}
	}

	// Token: 0x170025E0 RID: 9696
	// (get) Token: 0x0601BE32 RID: 114226 RVA: 0x0084FA68 File Offset: 0x0084DC68
	// (set) Token: 0x0601BE33 RID: 114227 RVA: 0x0084FAA1 File Offset: 0x0084DCA1
	[UProperty(EPropertyFlags.CPF_None)]
	public FKuroCurveFloat SimpleVspeed
	{
		get
		{
			base.FastCheckIsValid();
			FKuroCurveFloat result;
			if ((result = this._SimpleVspeed) == null)
			{
				result = (this._SimpleVspeed = new FKuroCurveFloat(base.NativePtr + (IntPtr)ItemMaterialControllerActorData.__PropertyOffset_SimpleVspeed, this));
			}
			return result;
		}
		set
		{
			UnrealReflectionUtils.CopyNativeStruct(FKuroCurveFloat.StaticStruct(), base.NativePtr + (IntPtr)ItemMaterialControllerActorData.__PropertyOffset_SimpleVspeed, (value != null) ? value.NativePtr : ((IntPtr)0), 1, false);
		}
	}

	// Token: 0x170025E1 RID: 9697
	// (get) Token: 0x0601BE34 RID: 114228 RVA: 0x0084FACC File Offset: 0x0084DCCC
	// (set) Token: 0x0601BE35 RID: 114229 RVA: 0x0084FB05 File Offset: 0x0084DD05
	[UProperty(EPropertyFlags.CPF_None)]
	public FKuroCurveFloat SimpleUseFlow
	{
		get
		{
			base.FastCheckIsValid();
			FKuroCurveFloat result;
			if ((result = this._SimpleUseFlow) == null)
			{
				result = (this._SimpleUseFlow = new FKuroCurveFloat(base.NativePtr + (IntPtr)ItemMaterialControllerActorData.__PropertyOffset_SimpleUseFlow, this));
			}
			return result;
		}
		set
		{
			UnrealReflectionUtils.CopyNativeStruct(FKuroCurveFloat.StaticStruct(), base.NativePtr + (IntPtr)ItemMaterialControllerActorData.__PropertyOffset_SimpleUseFlow, (value != null) ? value.NativePtr : ((IntPtr)0), 1, false);
		}
	}

	// Token: 0x170025E2 RID: 9698
	// (get) Token: 0x0601BE36 RID: 114230 RVA: 0x0084FB2D File Offset: 0x0084DD2D
	// (set) Token: 0x0601BE37 RID: 114231 RVA: 0x0084FB3D File Offset: 0x0084DD3D
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool EnableQuanXiPinTu
	{
		get
		{
			return *(base.NativePtr + (IntPtr)ItemMaterialControllerActorData.__PropertyOffset_EnableQuanXiPinTu) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)ItemMaterialControllerActorData.__PropertyOffset_EnableQuanXiPinTu) = (value ? 1 : 0);
		}
	}

	// Token: 0x170025E3 RID: 9699
	// (get) Token: 0x0601BE38 RID: 114232 RVA: 0x0084FB50 File Offset: 0x0084DD50
	// (set) Token: 0x0601BE39 RID: 114233 RVA: 0x0084FB89 File Offset: 0x0084DD89
	[UProperty(EPropertyFlags.CPF_None)]
	public FKuroCurveFloat TransparencyQuanXiPinTu
	{
		get
		{
			base.FastCheckIsValid();
			FKuroCurveFloat result;
			if ((result = this._TransparencyQuanXiPinTu) == null)
			{
				result = (this._TransparencyQuanXiPinTu = new FKuroCurveFloat(base.NativePtr + (IntPtr)ItemMaterialControllerActorData.__PropertyOffset_TransparencyQuanXiPinTu, this));
			}
			return result;
		}
		set
		{
			UnrealReflectionUtils.CopyNativeStruct(FKuroCurveFloat.StaticStruct(), base.NativePtr + (IntPtr)ItemMaterialControllerActorData.__PropertyOffset_TransparencyQuanXiPinTu, (value != null) ? value.NativePtr : ((IntPtr)0), 1, false);
		}
	}

	// Token: 0x170025E4 RID: 9700
	// (get) Token: 0x0601BE3A RID: 114234 RVA: 0x0084FBB4 File Offset: 0x0084DDB4
	// (set) Token: 0x0601BE3B RID: 114235 RVA: 0x0084FBED File Offset: 0x0084DDED
	[UProperty(EPropertyFlags.CPF_None)]
	public FKuroCurveLinearColor TransparentColorQuanXiPinTu
	{
		get
		{
			base.FastCheckIsValid();
			FKuroCurveLinearColor result;
			if ((result = this._TransparentColorQuanXiPinTu) == null)
			{
				result = (this._TransparentColorQuanXiPinTu = new FKuroCurveLinearColor(base.NativePtr + (IntPtr)ItemMaterialControllerActorData.__PropertyOffset_TransparentColorQuanXiPinTu, this));
			}
			return result;
		}
		set
		{
			UnrealReflectionUtils.CopyNativeStruct(FKuroCurveLinearColor.StaticStruct(), base.NativePtr + (IntPtr)ItemMaterialControllerActorData.__PropertyOffset_TransparentColorQuanXiPinTu, (value != null) ? value.NativePtr : ((IntPtr)0), 1, false);
		}
	}

	// Token: 0x170025E5 RID: 9701
	// (get) Token: 0x0601BE3C RID: 114236 RVA: 0x0084FC18 File Offset: 0x0084DE18
	// (set) Token: 0x0601BE3D RID: 114237 RVA: 0x0084FC51 File Offset: 0x0084DE51
	[UProperty(EPropertyFlags.CPF_None)]
	public FKuroCurveLinearColor OpaqueColorQuanXiPinTu
	{
		get
		{
			base.FastCheckIsValid();
			FKuroCurveLinearColor result;
			if ((result = this._OpaqueColorQuanXiPinTu) == null)
			{
				result = (this._OpaqueColorQuanXiPinTu = new FKuroCurveLinearColor(base.NativePtr + (IntPtr)ItemMaterialControllerActorData.__PropertyOffset_OpaqueColorQuanXiPinTu, this));
			}
			return result;
		}
		set
		{
			UnrealReflectionUtils.CopyNativeStruct(FKuroCurveLinearColor.StaticStruct(), base.NativePtr + (IntPtr)ItemMaterialControllerActorData.__PropertyOffset_OpaqueColorQuanXiPinTu, (value != null) ? value.NativePtr : ((IntPtr)0), 1, false);
		}
	}

	// Token: 0x170025E6 RID: 9702
	// (get) Token: 0x0601BE3E RID: 114238 RVA: 0x0084FC79 File Offset: 0x0084DE79
	// (set) Token: 0x0601BE3F RID: 114239 RVA: 0x0084FC89 File Offset: 0x0084DE89
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool EnableQuanXiFengSuo
	{
		get
		{
			return *(base.NativePtr + (IntPtr)ItemMaterialControllerActorData.__PropertyOffset_EnableQuanXiFengSuo) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)ItemMaterialControllerActorData.__PropertyOffset_EnableQuanXiFengSuo) = (value ? 1 : 0);
		}
	}

	// Token: 0x170025E7 RID: 9703
	// (get) Token: 0x0601BE40 RID: 114240 RVA: 0x0084FC9C File Offset: 0x0084DE9C
	// (set) Token: 0x0601BE41 RID: 114241 RVA: 0x0084FCD5 File Offset: 0x0084DED5
	[UProperty(EPropertyFlags.CPF_None)]
	public FKuroCurveFloat TransparencyQuanXiFengSuo
	{
		get
		{
			base.FastCheckIsValid();
			FKuroCurveFloat result;
			if ((result = this._TransparencyQuanXiFengSuo) == null)
			{
				result = (this._TransparencyQuanXiFengSuo = new FKuroCurveFloat(base.NativePtr + (IntPtr)ItemMaterialControllerActorData.__PropertyOffset_TransparencyQuanXiFengSuo, this));
			}
			return result;
		}
		set
		{
			UnrealReflectionUtils.CopyNativeStruct(FKuroCurveFloat.StaticStruct(), base.NativePtr + (IntPtr)ItemMaterialControllerActorData.__PropertyOffset_TransparencyQuanXiFengSuo, (value != null) ? value.NativePtr : ((IntPtr)0), 1, false);
		}
	}

	// Token: 0x170025E8 RID: 9704
	// (get) Token: 0x0601BE42 RID: 114242 RVA: 0x0084FD00 File Offset: 0x0084DF00
	// (set) Token: 0x0601BE43 RID: 114243 RVA: 0x0084FD39 File Offset: 0x0084DF39
	[UProperty(EPropertyFlags.CPF_None)]
	public FKuroCurveLinearColor TransparentColorQuanXiFengSuo
	{
		get
		{
			base.FastCheckIsValid();
			FKuroCurveLinearColor result;
			if ((result = this._TransparentColorQuanXiFengSuo) == null)
			{
				result = (this._TransparentColorQuanXiFengSuo = new FKuroCurveLinearColor(base.NativePtr + (IntPtr)ItemMaterialControllerActorData.__PropertyOffset_TransparentColorQuanXiFengSuo, this));
			}
			return result;
		}
		set
		{
			UnrealReflectionUtils.CopyNativeStruct(FKuroCurveLinearColor.StaticStruct(), base.NativePtr + (IntPtr)ItemMaterialControllerActorData.__PropertyOffset_TransparentColorQuanXiFengSuo, (value != null) ? value.NativePtr : ((IntPtr)0), 1, false);
		}
	}

	// Token: 0x170025E9 RID: 9705
	// (get) Token: 0x0601BE44 RID: 114244 RVA: 0x0084FD64 File Offset: 0x0084DF64
	[UProperty(EPropertyFlags.CPF_None)]
	public TMap<FName, FKuroCurveFloat> CustomScalarParMap
	{
		get
		{
			base.FastCheckIsValid();
			TMap<FName, FKuroCurveFloat> result;
			if ((result = this._CustomScalarParMap) == null)
			{
				result = (this._CustomScalarParMap = new TMap<FName, FKuroCurveFloat>(base.NativePtr + (IntPtr)ItemMaterialControllerActorData.__PropertyOffset_CustomScalarParMap, this));
			}
			return result;
		}
	}

	// Token: 0x170025EA RID: 9706
	// (get) Token: 0x0601BE45 RID: 114245 RVA: 0x0084FDA0 File Offset: 0x0084DFA0
	[UProperty(EPropertyFlags.CPF_None)]
	public TMap<FName, FKuroCurveLinearColor> CustomColorParMap
	{
		get
		{
			base.FastCheckIsValid();
			TMap<FName, FKuroCurveLinearColor> result;
			if ((result = this._CustomColorParMap) == null)
			{
				result = (this._CustomColorParMap = new TMap<FName, FKuroCurveLinearColor>(base.NativePtr + (IntPtr)ItemMaterialControllerActorData.__PropertyOffset_CustomColorParMap, this));
			}
			return result;
		}
	}

	// Token: 0x0601BE46 RID: 114246 RVA: 0x0084FDD9 File Offset: 0x0084DFD9
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (ItemMaterialControllerActorData._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/Render/Scene/Item/MaterialController/ItemMaterialControllerActorData.ItemMaterialControllerActorData_C");
		}
		return ItemMaterialControllerActorData._ClassPtr;
	}

	// Token: 0x0601BE47 RID: 114247 RVA: 0x0084FE00 File Offset: 0x0084E000
	public ItemMaterialControllerActorData() : this(BuiltinUtils.AllocNativeUObject(ItemMaterialControllerActorData.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0601BE48 RID: 114248 RVA: 0x0084FE28 File Offset: 0x0084E028
	public ItemMaterialControllerActorData(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ItemMaterialControllerActorData.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601BE49 RID: 114249 RVA: 0x0084FE5B File Offset: 0x0084E05B
	protected ItemMaterialControllerActorData(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0400E130 RID: 57648
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/Render/Scene/Item/MaterialController/ItemMaterialControllerActorData.ItemMaterialControllerActorData_C";

	// Token: 0x0400E131 RID: 57649
	private static IntPtr _ClassPtr;

	// Token: 0x0400E132 RID: 57650
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400E133 RID: 57651
	private static int __PropertyOffset_StartTime;

	// Token: 0x0400E134 RID: 57652
	private static int __PropertyOffset_LoopTime;

	// Token: 0x0400E135 RID: 57653
	private static int __PropertyOffset_EndTime;

	// Token: 0x0400E136 RID: 57654
	private static int __PropertyOffset_EnableBaseColorScale;

	// Token: 0x0400E137 RID: 57655
	private static int __PropertyOffset_BaseColorScale;

	// Token: 0x0400E138 RID: 57656
	[Nullable(2)]
	private FKuroCurveFloat _BaseColorScale;

	// Token: 0x0400E139 RID: 57657
	private static int __PropertyOffset_EnableAddEmissionColor;

	// Token: 0x0400E13A RID: 57658
	private static int __PropertyOffset_AddEmissionColor;

	// Token: 0x0400E13B RID: 57659
	[Nullable(2)]
	private FKuroCurveLinearColor _AddEmissionColor;

	// Token: 0x0400E13C RID: 57660
	private static int __PropertyOffset_EnableEmissionChange;

	// Token: 0x0400E13D RID: 57661
	private static int __PropertyOffset_EmissionLightColorChangeProgress;

	// Token: 0x0400E13E RID: 57662
	[Nullable(2)]
	private FKuroCurveFloat _EmissionLightColorChangeProgress;

	// Token: 0x0400E13F RID: 57663
	private static int __PropertyOffset_EmissionLightColorChangeStrength;

	// Token: 0x0400E140 RID: 57664
	[Nullable(2)]
	private FKuroCurveFloat _EmissionLightColorChangeStrength;

	// Token: 0x0400E141 RID: 57665
	private static int __PropertyOffset_EmissionLightColorChangeColor;

	// Token: 0x0400E142 RID: 57666
	[Nullable(2)]
	private FKuroCurveLinearColor _EmissionLightColorChangeColor;

	// Token: 0x0400E143 RID: 57667
	private static int __PropertyOffset_EnableRimLight;

	// Token: 0x0400E144 RID: 57668
	private static int __PropertyOffset_RimLightColor;

	// Token: 0x0400E145 RID: 57669
	[Nullable(2)]
	private FKuroCurveLinearColor _RimLightColor;

	// Token: 0x0400E146 RID: 57670
	private static int __PropertyOffset_RimPower;

	// Token: 0x0400E147 RID: 57671
	[Nullable(2)]
	private FKuroCurveFloat _RimPower;

	// Token: 0x0400E148 RID: 57672
	private static int __PropertyOffset_EnableDissolve;

	// Token: 0x0400E149 RID: 57673
	private static int __PropertyOffset_DissolveProgress;

	// Token: 0x0400E14A RID: 57674
	[Nullable(2)]
	private FKuroCurveFloat _DissolveProgress;

	// Token: 0x0400E14B RID: 57675
	private static int __PropertyOffset_DissolveAdjustment;

	// Token: 0x0400E14C RID: 57676
	[Nullable(2)]
	private FKuroCurveFloat _DissolveAdjustment;

	// Token: 0x0400E14D RID: 57677
	private static int __PropertyOffset_DissolveEdageWidth;

	// Token: 0x0400E14E RID: 57678
	[Nullable(2)]
	private FKuroCurveFloat _DissolveEdageWidth;

	// Token: 0x0400E14F RID: 57679
	private static int __PropertyOffset_DissolveEdageColor;

	// Token: 0x0400E150 RID: 57680
	[Nullable(2)]
	private FKuroCurveLinearColor _DissolveEdageColor;

	// Token: 0x0400E151 RID: 57681
	private static int __PropertyOffset_DissolveEdageStrength;

	// Token: 0x0400E152 RID: 57682
	[Nullable(2)]
	private FKuroCurveFloat _DissolveEdageStrength;

	// Token: 0x0400E153 RID: 57683
	private static int __PropertyOffset_DissolveTexSpeed;

	// Token: 0x0400E154 RID: 57684
	[Nullable(2)]
	private FKuroCurveLinearColor _DissolveTexSpeed;

	// Token: 0x0400E155 RID: 57685
	private static int __PropertyOffset_DissolveUv;

	// Token: 0x0400E156 RID: 57686
	private static int __PropertyOffset_DissolveTexScaleOffset;

	// Token: 0x0400E157 RID: 57687
	[Nullable(2)]
	private FKuroCurveLinearColor _DissolveTexScaleOffset;

	// Token: 0x0400E158 RID: 57688
	private static int __PropertyOffset_EnableScanning;

	// Token: 0x0400E159 RID: 57689
	private static int __PropertyOffset_ScanningOutlineMixNoiseStrength;

	// Token: 0x0400E15A RID: 57690
	[Nullable(2)]
	private FKuroCurveFloat _ScanningOutlineMixNoiseStrength;

	// Token: 0x0400E15B RID: 57691
	private static int __PropertyOffset_ScanningOutlineStrength;

	// Token: 0x0400E15C RID: 57692
	[Nullable(2)]
	private FKuroCurveFloat _ScanningOutlineStrength;

	// Token: 0x0400E15D RID: 57693
	private static int __PropertyOffset_ScanningOutlineTexScaleOffset;

	// Token: 0x0400E15E RID: 57694
	[Nullable(2)]
	private FKuroCurveLinearColor _ScanningOutlineTexScaleOffset;

	// Token: 0x0400E15F RID: 57695
	private static int __PropertyOffset_ScanningOutlineColor;

	// Token: 0x0400E160 RID: 57696
	[Nullable(2)]
	private FKuroCurveLinearColor _ScanningOutlineColor;

	// Token: 0x0400E161 RID: 57697
	private static int __PropertyOffset_VertexAnimTimeDebug;

	// Token: 0x0400E162 RID: 57698
	[Nullable(2)]
	private FKuroCurveFloat _VertexAnimTimeDebug;

	// Token: 0x0400E163 RID: 57699
	private static int __PropertyOffset_VertexAnimFrame;

	// Token: 0x0400E164 RID: 57700
	[Nullable(2)]
	private FKuroCurveFloat _VertexAnimFrame;

	// Token: 0x0400E165 RID: 57701
	private static int __PropertyOffset_PivotPainterTransform;

	// Token: 0x0400E166 RID: 57702
	[Nullable(2)]
	private FKuroCurveLinearColor _PivotPainterTransform;

	// Token: 0x0400E167 RID: 57703
	private static int __PropertyOffset_FloatingThreshold;

	// Token: 0x0400E168 RID: 57704
	[Nullable(2)]
	private FKuroCurveFloat _FloatingThreshold;

	// Token: 0x0400E169 RID: 57705
	private static int __PropertyOffset_EnablePivotPainterWorldPositionOffset;

	// Token: 0x0400E16A RID: 57706
	private static int __PropertyOffset_EnableWorldPositionOffset;

	// Token: 0x0400E16B RID: 57707
	private static int __PropertyOffset_DisableFoliageEffect;

	// Token: 0x0400E16C RID: 57708
	private static int __PropertyOffset_EnableFoliageEffect;

	// Token: 0x0400E16D RID: 57709
	private static int __PropertyOffset_RimLightColorSpecil;

	// Token: 0x0400E16E RID: 57710
	[Nullable(2)]
	private FKuroCurveLinearColor _RimLightColorSpecil;

	// Token: 0x0400E16F RID: 57711
	private static int __PropertyOffset_UseRimlightColorSpecil;

	// Token: 0x0400E170 RID: 57712
	private static int __PropertyOffset_RimlightColorStrength;

	// Token: 0x0400E171 RID: 57713
	[Nullable(2)]
	private FKuroCurveFloat _RimlightColorStrength;

	// Token: 0x0400E172 RID: 57714
	private static int __PropertyOffset_UseEmissionTex;

	// Token: 0x0400E173 RID: 57715
	private static int __PropertyOffset_EmissionTexStrength;

	// Token: 0x0400E174 RID: 57716
	[Nullable(2)]
	private FKuroCurveFloat _EmissionTexStrength;

	// Token: 0x0400E175 RID: 57717
	private static int __PropertyOffset_WorldPositionOffsetNormal;

	// Token: 0x0400E176 RID: 57718
	[Nullable(2)]
	private FKuroCurveFloat _WorldPositionOffsetNormal;

	// Token: 0x0400E177 RID: 57719
	private static int __PropertyOffset_WorldPositionOffsetOffset;

	// Token: 0x0400E178 RID: 57720
	[Nullable(2)]
	private FKuroCurveLinearColor _WorldPositionOffsetOffset;

	// Token: 0x0400E179 RID: 57721
	private static int __PropertyOffset_SimpleUspeed;

	// Token: 0x0400E17A RID: 57722
	[Nullable(2)]
	private FKuroCurveFloat _SimpleUspeed;

	// Token: 0x0400E17B RID: 57723
	private static int __PropertyOffset_SimpleVspeed;

	// Token: 0x0400E17C RID: 57724
	[Nullable(2)]
	private FKuroCurveFloat _SimpleVspeed;

	// Token: 0x0400E17D RID: 57725
	private static int __PropertyOffset_SimpleUseFlow;

	// Token: 0x0400E17E RID: 57726
	[Nullable(2)]
	private FKuroCurveFloat _SimpleUseFlow;

	// Token: 0x0400E17F RID: 57727
	private static int __PropertyOffset_EnableQuanXiPinTu;

	// Token: 0x0400E180 RID: 57728
	private static int __PropertyOffset_TransparencyQuanXiPinTu;

	// Token: 0x0400E181 RID: 57729
	[Nullable(2)]
	private FKuroCurveFloat _TransparencyQuanXiPinTu;

	// Token: 0x0400E182 RID: 57730
	private static int __PropertyOffset_TransparentColorQuanXiPinTu;

	// Token: 0x0400E183 RID: 57731
	[Nullable(2)]
	private FKuroCurveLinearColor _TransparentColorQuanXiPinTu;

	// Token: 0x0400E184 RID: 57732
	private static int __PropertyOffset_OpaqueColorQuanXiPinTu;

	// Token: 0x0400E185 RID: 57733
	[Nullable(2)]
	private FKuroCurveLinearColor _OpaqueColorQuanXiPinTu;

	// Token: 0x0400E186 RID: 57734
	private static int __PropertyOffset_EnableQuanXiFengSuo;

	// Token: 0x0400E187 RID: 57735
	private static int __PropertyOffset_TransparencyQuanXiFengSuo;

	// Token: 0x0400E188 RID: 57736
	[Nullable(2)]
	private FKuroCurveFloat _TransparencyQuanXiFengSuo;

	// Token: 0x0400E189 RID: 57737
	private static int __PropertyOffset_TransparentColorQuanXiFengSuo;

	// Token: 0x0400E18A RID: 57738
	[Nullable(2)]
	private FKuroCurveLinearColor _TransparentColorQuanXiFengSuo;

	// Token: 0x0400E18B RID: 57739
	private static int __PropertyOffset_CustomScalarParMap;

	// Token: 0x0400E18C RID: 57740
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TMap<FName, FKuroCurveFloat> _CustomScalarParMap;

	// Token: 0x0400E18D RID: 57741
	private static int __PropertyOffset_CustomColorParMap;

	// Token: 0x0400E18E RID: 57742
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TMap<FName, FKuroCurveLinearColor> _CustomColorParMap;
}
