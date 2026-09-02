using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02003428 RID: 13352
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/Render/Scene/Item/MaterialController/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/Render/Scene/Item/MaterialController/ItemMaterialControllerGlobalData.ItemMaterialControllerGlobalData_C")]
public class ItemMaterialControllerGlobalData : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
{
	// Token: 0x170025EB RID: 9707
	// (get) Token: 0x0601BE4A RID: 114250 RVA: 0x0084FE64 File Offset: 0x0084E064
	// (set) Token: 0x0601BE4B RID: 114251 RVA: 0x0084FE74 File Offset: 0x0084E074
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float StartTime
	{
		get
		{
			return *(base.NativePtr + (IntPtr)ItemMaterialControllerGlobalData.__PropertyOffset_StartTime);
		}
		set
		{
			*(base.NativePtr + (IntPtr)ItemMaterialControllerGlobalData.__PropertyOffset_StartTime) = value;
		}
	}

	// Token: 0x170025EC RID: 9708
	// (get) Token: 0x0601BE4C RID: 114252 RVA: 0x0084FE85 File Offset: 0x0084E085
	// (set) Token: 0x0601BE4D RID: 114253 RVA: 0x0084FE95 File Offset: 0x0084E095
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float LoopTime
	{
		get
		{
			return *(base.NativePtr + (IntPtr)ItemMaterialControllerGlobalData.__PropertyOffset_LoopTime);
		}
		set
		{
			*(base.NativePtr + (IntPtr)ItemMaterialControllerGlobalData.__PropertyOffset_LoopTime) = value;
		}
	}

	// Token: 0x170025ED RID: 9709
	// (get) Token: 0x0601BE4E RID: 114254 RVA: 0x0084FEA6 File Offset: 0x0084E0A6
	// (set) Token: 0x0601BE4F RID: 114255 RVA: 0x0084FEB6 File Offset: 0x0084E0B6
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float EndTime
	{
		get
		{
			return *(base.NativePtr + (IntPtr)ItemMaterialControllerGlobalData.__PropertyOffset_EndTime);
		}
		set
		{
			*(base.NativePtr + (IntPtr)ItemMaterialControllerGlobalData.__PropertyOffset_EndTime) = value;
		}
	}

	// Token: 0x170025EE RID: 9710
	// (get) Token: 0x0601BE50 RID: 114256 RVA: 0x0084FEC7 File Offset: 0x0084E0C7
	// (set) Token: 0x0601BE51 RID: 114257 RVA: 0x0084FED7 File Offset: 0x0084E0D7
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool EnableBaseColorScale
	{
		get
		{
			return *(base.NativePtr + (IntPtr)ItemMaterialControllerGlobalData.__PropertyOffset_EnableBaseColorScale) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)ItemMaterialControllerGlobalData.__PropertyOffset_EnableBaseColorScale) = (value ? 1 : 0);
		}
	}

	// Token: 0x170025EF RID: 9711
	// (get) Token: 0x0601BE52 RID: 114258 RVA: 0x0084FEE8 File Offset: 0x0084E0E8
	// (set) Token: 0x0601BE53 RID: 114259 RVA: 0x0084FF21 File Offset: 0x0084E121
	[UProperty(EPropertyFlags.CPF_None)]
	public FKuroCurveFloat BaseColorScale
	{
		get
		{
			base.FastCheckIsValid();
			FKuroCurveFloat result;
			if ((result = this._BaseColorScale) == null)
			{
				result = (this._BaseColorScale = new FKuroCurveFloat(base.NativePtr + (IntPtr)ItemMaterialControllerGlobalData.__PropertyOffset_BaseColorScale, this));
			}
			return result;
		}
		set
		{
			UnrealReflectionUtils.CopyNativeStruct(FKuroCurveFloat.StaticStruct(), base.NativePtr + (IntPtr)ItemMaterialControllerGlobalData.__PropertyOffset_BaseColorScale, (value != null) ? value.NativePtr : ((IntPtr)0), 1, false);
		}
	}

	// Token: 0x170025F0 RID: 9712
	// (get) Token: 0x0601BE54 RID: 114260 RVA: 0x0084FF49 File Offset: 0x0084E149
	// (set) Token: 0x0601BE55 RID: 114261 RVA: 0x0084FF59 File Offset: 0x0084E159
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool EnableAddEmissionColor
	{
		get
		{
			return *(base.NativePtr + (IntPtr)ItemMaterialControllerGlobalData.__PropertyOffset_EnableAddEmissionColor) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)ItemMaterialControllerGlobalData.__PropertyOffset_EnableAddEmissionColor) = (value ? 1 : 0);
		}
	}

	// Token: 0x170025F1 RID: 9713
	// (get) Token: 0x0601BE56 RID: 114262 RVA: 0x0084FF6C File Offset: 0x0084E16C
	// (set) Token: 0x0601BE57 RID: 114263 RVA: 0x0084FFA5 File Offset: 0x0084E1A5
	[UProperty(EPropertyFlags.CPF_None)]
	public FKuroCurveLinearColor AddEmissionColor
	{
		get
		{
			base.FastCheckIsValid();
			FKuroCurveLinearColor result;
			if ((result = this._AddEmissionColor) == null)
			{
				result = (this._AddEmissionColor = new FKuroCurveLinearColor(base.NativePtr + (IntPtr)ItemMaterialControllerGlobalData.__PropertyOffset_AddEmissionColor, this));
			}
			return result;
		}
		set
		{
			UnrealReflectionUtils.CopyNativeStruct(FKuroCurveLinearColor.StaticStruct(), base.NativePtr + (IntPtr)ItemMaterialControllerGlobalData.__PropertyOffset_AddEmissionColor, (value != null) ? value.NativePtr : ((IntPtr)0), 1, false);
		}
	}

	// Token: 0x170025F2 RID: 9714
	// (get) Token: 0x0601BE58 RID: 114264 RVA: 0x0084FFCD File Offset: 0x0084E1CD
	// (set) Token: 0x0601BE59 RID: 114265 RVA: 0x0084FFDD File Offset: 0x0084E1DD
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool EnableRimLight
	{
		get
		{
			return *(base.NativePtr + (IntPtr)ItemMaterialControllerGlobalData.__PropertyOffset_EnableRimLight) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)ItemMaterialControllerGlobalData.__PropertyOffset_EnableRimLight) = (value ? 1 : 0);
		}
	}

	// Token: 0x170025F3 RID: 9715
	// (get) Token: 0x0601BE5A RID: 114266 RVA: 0x0084FFF0 File Offset: 0x0084E1F0
	// (set) Token: 0x0601BE5B RID: 114267 RVA: 0x00850029 File Offset: 0x0084E229
	[UProperty(EPropertyFlags.CPF_None)]
	public FKuroCurveLinearColor AddRimLightColor
	{
		get
		{
			base.FastCheckIsValid();
			FKuroCurveLinearColor result;
			if ((result = this._AddRimLightColor) == null)
			{
				result = (this._AddRimLightColor = new FKuroCurveLinearColor(base.NativePtr + (IntPtr)ItemMaterialControllerGlobalData.__PropertyOffset_AddRimLightColor, this));
			}
			return result;
		}
		set
		{
			UnrealReflectionUtils.CopyNativeStruct(FKuroCurveLinearColor.StaticStruct(), base.NativePtr + (IntPtr)ItemMaterialControllerGlobalData.__PropertyOffset_AddRimLightColor, (value != null) ? value.NativePtr : ((IntPtr)0), 1, false);
		}
	}

	// Token: 0x170025F4 RID: 9716
	// (get) Token: 0x0601BE5C RID: 114268 RVA: 0x00850054 File Offset: 0x0084E254
	// (set) Token: 0x0601BE5D RID: 114269 RVA: 0x0085008D File Offset: 0x0084E28D
	[UProperty(EPropertyFlags.CPF_None)]
	public FKuroCurveFloat RimWidth
	{
		get
		{
			base.FastCheckIsValid();
			FKuroCurveFloat result;
			if ((result = this._RimWidth) == null)
			{
				result = (this._RimWidth = new FKuroCurveFloat(base.NativePtr + (IntPtr)ItemMaterialControllerGlobalData.__PropertyOffset_RimWidth, this));
			}
			return result;
		}
		set
		{
			UnrealReflectionUtils.CopyNativeStruct(FKuroCurveFloat.StaticStruct(), base.NativePtr + (IntPtr)ItemMaterialControllerGlobalData.__PropertyOffset_RimWidth, (value != null) ? value.NativePtr : ((IntPtr)0), 1, false);
		}
	}

	// Token: 0x170025F5 RID: 9717
	// (get) Token: 0x0601BE5E RID: 114270 RVA: 0x008500B8 File Offset: 0x0084E2B8
	// (set) Token: 0x0601BE5F RID: 114271 RVA: 0x008500F1 File Offset: 0x0084E2F1
	[UProperty(EPropertyFlags.CPF_None)]
	public FKuroCurveFloat RimPower
	{
		get
		{
			base.FastCheckIsValid();
			FKuroCurveFloat result;
			if ((result = this._RimPower) == null)
			{
				result = (this._RimPower = new FKuroCurveFloat(base.NativePtr + (IntPtr)ItemMaterialControllerGlobalData.__PropertyOffset_RimPower, this));
			}
			return result;
		}
		set
		{
			UnrealReflectionUtils.CopyNativeStruct(FKuroCurveFloat.StaticStruct(), base.NativePtr + (IntPtr)ItemMaterialControllerGlobalData.__PropertyOffset_RimPower, (value != null) ? value.NativePtr : ((IntPtr)0), 1, false);
		}
	}

	// Token: 0x170025F6 RID: 9718
	// (get) Token: 0x0601BE60 RID: 114272 RVA: 0x0085011C File Offset: 0x0084E31C
	// (set) Token: 0x0601BE61 RID: 114273 RVA: 0x00850155 File Offset: 0x0084E355
	[UProperty(EPropertyFlags.CPF_None)]
	public FKuroCurveFloat RimMix
	{
		get
		{
			base.FastCheckIsValid();
			FKuroCurveFloat result;
			if ((result = this._RimMix) == null)
			{
				result = (this._RimMix = new FKuroCurveFloat(base.NativePtr + (IntPtr)ItemMaterialControllerGlobalData.__PropertyOffset_RimMix, this));
			}
			return result;
		}
		set
		{
			UnrealReflectionUtils.CopyNativeStruct(FKuroCurveFloat.StaticStruct(), base.NativePtr + (IntPtr)ItemMaterialControllerGlobalData.__PropertyOffset_RimMix, (value != null) ? value.NativePtr : ((IntPtr)0), 1, false);
		}
	}

	// Token: 0x170025F7 RID: 9719
	// (get) Token: 0x0601BE62 RID: 114274 RVA: 0x0085017D File Offset: 0x0084E37D
	// (set) Token: 0x0601BE63 RID: 114275 RVA: 0x0085018D File Offset: 0x0084E38D
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool EnableScanningOutline
	{
		get
		{
			return *(base.NativePtr + (IntPtr)ItemMaterialControllerGlobalData.__PropertyOffset_EnableScanningOutline) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)ItemMaterialControllerGlobalData.__PropertyOffset_EnableScanningOutline) = (value ? 1 : 0);
		}
	}

	// Token: 0x170025F8 RID: 9720
	// (get) Token: 0x0601BE64 RID: 114276 RVA: 0x008501A0 File Offset: 0x0084E3A0
	// (set) Token: 0x0601BE65 RID: 114277 RVA: 0x008501D9 File Offset: 0x0084E3D9
	[UProperty(EPropertyFlags.CPF_None)]
	public FKuroCurveLinearColor ScanningOutlineColor
	{
		get
		{
			base.FastCheckIsValid();
			FKuroCurveLinearColor result;
			if ((result = this._ScanningOutlineColor) == null)
			{
				result = (this._ScanningOutlineColor = new FKuroCurveLinearColor(base.NativePtr + (IntPtr)ItemMaterialControllerGlobalData.__PropertyOffset_ScanningOutlineColor, this));
			}
			return result;
		}
		set
		{
			UnrealReflectionUtils.CopyNativeStruct(FKuroCurveLinearColor.StaticStruct(), base.NativePtr + (IntPtr)ItemMaterialControllerGlobalData.__PropertyOffset_ScanningOutlineColor, (value != null) ? value.NativePtr : ((IntPtr)0), 1, false);
		}
	}

	// Token: 0x170025F9 RID: 9721
	// (get) Token: 0x0601BE66 RID: 114278 RVA: 0x00850204 File Offset: 0x0084E404
	// (set) Token: 0x0601BE67 RID: 114279 RVA: 0x0085023D File Offset: 0x0084E43D
	[UProperty(EPropertyFlags.CPF_None)]
	public FKuroCurveFloat ScanningOutlineWidth
	{
		get
		{
			base.FastCheckIsValid();
			FKuroCurveFloat result;
			if ((result = this._ScanningOutlineWidth) == null)
			{
				result = (this._ScanningOutlineWidth = new FKuroCurveFloat(base.NativePtr + (IntPtr)ItemMaterialControllerGlobalData.__PropertyOffset_ScanningOutlineWidth, this));
			}
			return result;
		}
		set
		{
			UnrealReflectionUtils.CopyNativeStruct(FKuroCurveFloat.StaticStruct(), base.NativePtr + (IntPtr)ItemMaterialControllerGlobalData.__PropertyOffset_ScanningOutlineWidth, (value != null) ? value.NativePtr : ((IntPtr)0), 1, false);
		}
	}

	// Token: 0x170025FA RID: 9722
	// (get) Token: 0x0601BE68 RID: 114280 RVA: 0x00850268 File Offset: 0x0084E468
	// (set) Token: 0x0601BE69 RID: 114281 RVA: 0x008502A1 File Offset: 0x0084E4A1
	[UProperty(EPropertyFlags.CPF_None)]
	public FKuroCurveLinearColor ScanningOutlineTexScaleOffset
	{
		get
		{
			base.FastCheckIsValid();
			FKuroCurveLinearColor result;
			if ((result = this._ScanningOutlineTexScaleOffset) == null)
			{
				result = (this._ScanningOutlineTexScaleOffset = new FKuroCurveLinearColor(base.NativePtr + (IntPtr)ItemMaterialControllerGlobalData.__PropertyOffset_ScanningOutlineTexScaleOffset, this));
			}
			return result;
		}
		set
		{
			UnrealReflectionUtils.CopyNativeStruct(FKuroCurveLinearColor.StaticStruct(), base.NativePtr + (IntPtr)ItemMaterialControllerGlobalData.__PropertyOffset_ScanningOutlineTexScaleOffset, (value != null) ? value.NativePtr : ((IntPtr)0), 1, false);
		}
	}

	// Token: 0x170025FB RID: 9723
	// (get) Token: 0x0601BE6A RID: 114282 RVA: 0x008502CC File Offset: 0x0084E4CC
	// (set) Token: 0x0601BE6B RID: 114283 RVA: 0x00850305 File Offset: 0x0084E505
	[UProperty(EPropertyFlags.CPF_None)]
	public FKuroCurveLinearColor ScanningBrokenTexScaleOffset
	{
		get
		{
			base.FastCheckIsValid();
			FKuroCurveLinearColor result;
			if ((result = this._ScanningBrokenTexScaleOffset) == null)
			{
				result = (this._ScanningBrokenTexScaleOffset = new FKuroCurveLinearColor(base.NativePtr + (IntPtr)ItemMaterialControllerGlobalData.__PropertyOffset_ScanningBrokenTexScaleOffset, this));
			}
			return result;
		}
		set
		{
			UnrealReflectionUtils.CopyNativeStruct(FKuroCurveLinearColor.StaticStruct(), base.NativePtr + (IntPtr)ItemMaterialControllerGlobalData.__PropertyOffset_ScanningBrokenTexScaleOffset, (value != null) ? value.NativePtr : ((IntPtr)0), 1, false);
		}
	}

	// Token: 0x0601BE6C RID: 114284 RVA: 0x0085032D File Offset: 0x0084E52D
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (ItemMaterialControllerGlobalData._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/Render/Scene/Item/MaterialController/ItemMaterialControllerGlobalData.ItemMaterialControllerGlobalData_C");
		}
		return ItemMaterialControllerGlobalData._ClassPtr;
	}

	// Token: 0x0601BE6D RID: 114285 RVA: 0x00850354 File Offset: 0x0084E554
	public ItemMaterialControllerGlobalData() : this(BuiltinUtils.AllocNativeUObject(ItemMaterialControllerGlobalData.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0601BE6E RID: 114286 RVA: 0x0085037C File Offset: 0x0084E57C
	public ItemMaterialControllerGlobalData(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ItemMaterialControllerGlobalData.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601BE6F RID: 114287 RVA: 0x008503AF File Offset: 0x0084E5AF
	protected ItemMaterialControllerGlobalData(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0400E18F RID: 57743
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/Render/Scene/Item/MaterialController/ItemMaterialControllerGlobalData.ItemMaterialControllerGlobalData_C";

	// Token: 0x0400E190 RID: 57744
	private static IntPtr _ClassPtr;

	// Token: 0x0400E191 RID: 57745
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400E192 RID: 57746
	private static int __PropertyOffset_StartTime;

	// Token: 0x0400E193 RID: 57747
	private static int __PropertyOffset_LoopTime;

	// Token: 0x0400E194 RID: 57748
	private static int __PropertyOffset_EndTime;

	// Token: 0x0400E195 RID: 57749
	private static int __PropertyOffset_EnableBaseColorScale;

	// Token: 0x0400E196 RID: 57750
	private static int __PropertyOffset_BaseColorScale;

	// Token: 0x0400E197 RID: 57751
	[Nullable(2)]
	private FKuroCurveFloat _BaseColorScale;

	// Token: 0x0400E198 RID: 57752
	private static int __PropertyOffset_EnableAddEmissionColor;

	// Token: 0x0400E199 RID: 57753
	private static int __PropertyOffset_AddEmissionColor;

	// Token: 0x0400E19A RID: 57754
	[Nullable(2)]
	private FKuroCurveLinearColor _AddEmissionColor;

	// Token: 0x0400E19B RID: 57755
	private static int __PropertyOffset_EnableRimLight;

	// Token: 0x0400E19C RID: 57756
	private static int __PropertyOffset_AddRimLightColor;

	// Token: 0x0400E19D RID: 57757
	[Nullable(2)]
	private FKuroCurveLinearColor _AddRimLightColor;

	// Token: 0x0400E19E RID: 57758
	private static int __PropertyOffset_RimWidth;

	// Token: 0x0400E19F RID: 57759
	[Nullable(2)]
	private FKuroCurveFloat _RimWidth;

	// Token: 0x0400E1A0 RID: 57760
	private static int __PropertyOffset_RimPower;

	// Token: 0x0400E1A1 RID: 57761
	[Nullable(2)]
	private FKuroCurveFloat _RimPower;

	// Token: 0x0400E1A2 RID: 57762
	private static int __PropertyOffset_RimMix;

	// Token: 0x0400E1A3 RID: 57763
	[Nullable(2)]
	private FKuroCurveFloat _RimMix;

	// Token: 0x0400E1A4 RID: 57764
	private static int __PropertyOffset_EnableScanningOutline;

	// Token: 0x0400E1A5 RID: 57765
	private static int __PropertyOffset_ScanningOutlineColor;

	// Token: 0x0400E1A6 RID: 57766
	[Nullable(2)]
	private FKuroCurveLinearColor _ScanningOutlineColor;

	// Token: 0x0400E1A7 RID: 57767
	private static int __PropertyOffset_ScanningOutlineWidth;

	// Token: 0x0400E1A8 RID: 57768
	[Nullable(2)]
	private FKuroCurveFloat _ScanningOutlineWidth;

	// Token: 0x0400E1A9 RID: 57769
	private static int __PropertyOffset_ScanningOutlineTexScaleOffset;

	// Token: 0x0400E1AA RID: 57770
	[Nullable(2)]
	private FKuroCurveLinearColor _ScanningOutlineTexScaleOffset;

	// Token: 0x0400E1AB RID: 57771
	private static int __PropertyOffset_ScanningBrokenTexScaleOffset;

	// Token: 0x0400E1AC RID: 57772
	[Nullable(2)]
	private FKuroCurveLinearColor _ScanningBrokenTexScaleOffset;
}
