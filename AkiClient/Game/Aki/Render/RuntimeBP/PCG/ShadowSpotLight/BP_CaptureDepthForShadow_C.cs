using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.ShadowSpotLight
{
	// Token: 0x02003B7A RID: 15226
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/ShadowSpotLight/BP_CaptureDepthForShadow.BP_CaptureDepthForShadow_C")]
	[UnrealStructLayout(1136, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1136)]
	public class BP_CaptureDepthForShadow_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060218EB RID: 137451 RVA: 0x0094C9AC File Offset: 0x0094ABAC
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_CaptureDepthForShadow_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/ShadowSpotLight/BP_CaptureDepthForShadow.BP_CaptureDepthForShadow_C");
			}
			return BP_CaptureDepthForShadow_C._ClassPtr;
		}

		// Token: 0x060218EC RID: 137452 RVA: 0x0094C9D0 File Offset: 0x0094ABD0
		public BP_CaptureDepthForShadow_C() : this(BuiltinUtils.AllocNativeUObject(BP_CaptureDepthForShadow_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060218ED RID: 137453 RVA: 0x0094C9F8 File Offset: 0x0094ABF8
		public BP_CaptureDepthForShadow_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_CaptureDepthForShadow_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003BC2 RID: 15298
		// (get) Token: 0x060218EE RID: 137454 RVA: 0x0094CA2B File Offset: 0x0094AC2B
		// (set) Token: 0x060218EF RID: 137455 RVA: 0x0094CA3F File Offset: 0x0094AC3F
		[Nullable(2)]
		public unsafe USceneCaptureComponent2D SceneCaptureComponent2D
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneCaptureComponent2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CaptureDepthForShadow_C.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CaptureDepthForShadow_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x17003BC3 RID: 15299
		// (get) Token: 0x060218F0 RID: 137456 RVA: 0x0094CA54 File Offset: 0x0094AC54
		// (set) Token: 0x060218F1 RID: 137457 RVA: 0x0094CA68 File Offset: 0x0094AC68
		[Nullable(2)]
		public unsafe USceneComponent DefaultSceneRoot
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CaptureDepthForShadow_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CaptureDepthForShadow_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17003BC4 RID: 15300
		// (get) Token: 0x060218F2 RID: 137458 RVA: 0x0094CA7D File Offset: 0x0094AC7D
		// (set) Token: 0x060218F3 RID: 137459 RVA: 0x0094CA91 File Offset: 0x0094AC91
		public unsafe string SavePath
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)BP_CaptureDepthForShadow_C.__PropertyOffset_2)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)BP_CaptureDepthForShadow_C.__PropertyOffset_2)), value);
			}
		}

		// Token: 0x17003BC5 RID: 15301
		// (get) Token: 0x060218F4 RID: 137460 RVA: 0x0094CAA6 File Offset: 0x0094ACA6
		// (set) Token: 0x060218F5 RID: 137461 RVA: 0x0094CABA File Offset: 0x0094ACBA
		public unsafe string Name
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)BP_CaptureDepthForShadow_C.__PropertyOffset_3)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)BP_CaptureDepthForShadow_C.__PropertyOffset_3)), value);
			}
		}

		// Token: 0x17003BC6 RID: 15302
		// (get) Token: 0x060218F6 RID: 137462 RVA: 0x0094CACF File Offset: 0x0094ACCF
		// (set) Token: 0x060218F7 RID: 137463 RVA: 0x0094CAE3 File Offset: 0x0094ACE3
		public unsafe FLinearColor LightPos
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CaptureDepthForShadow_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CaptureDepthForShadow_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17003BC7 RID: 15303
		// (get) Token: 0x060218F8 RID: 137464 RVA: 0x0094CAF8 File Offset: 0x0094ACF8
		// (set) Token: 0x060218F9 RID: 137465 RVA: 0x0094CB0C File Offset: 0x0094AD0C
		public unsafe FLinearColor LightVec
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CaptureDepthForShadow_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CaptureDepthForShadow_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17003BC8 RID: 15304
		// (get) Token: 0x060218FA RID: 137466 RVA: 0x0094CB21 File Offset: 0x0094AD21
		// (set) Token: 0x060218FB RID: 137467 RVA: 0x0094CB35 File Offset: 0x0094AD35
		public unsafe string MatSavePathTemp
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)BP_CaptureDepthForShadow_C.__PropertyOffset_6)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)BP_CaptureDepthForShadow_C.__PropertyOffset_6)), value);
			}
		}

		// Token: 0x17003BC9 RID: 15305
		// (get) Token: 0x060218FC RID: 137468 RVA: 0x0094CB4A File Offset: 0x0094AD4A
		// (set) Token: 0x060218FD RID: 137469 RVA: 0x0094CB5E File Offset: 0x0094AD5E
		public unsafe string MatNameTemp
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)BP_CaptureDepthForShadow_C.__PropertyOffset_7)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)BP_CaptureDepthForShadow_C.__PropertyOffset_7)), value);
			}
		}

		// Token: 0x060218FE RID: 137470 RVA: 0x0094CB73 File Offset: 0x0094AD73
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void CaptureDepth()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CaptureDepthForShadow_C.__CaptureDepth_NativeFunctionPtr, null);
		}

		// Token: 0x060218FF RID: 137471 RVA: 0x0094CB87 File Offset: 0x0094AD87
		protected BP_CaptureDepthForShadow_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04010E83 RID: 69251
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/ShadowSpotLight/BP_CaptureDepthForShadow.BP_CaptureDepthForShadow_C";

		// Token: 0x04010E84 RID: 69252
		private static IntPtr _ClassPtr;

		// Token: 0x04010E85 RID: 69253
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04010E86 RID: 69254
		internal static int __PropertyOffset_0;

		// Token: 0x04010E87 RID: 69255
		internal static int __PropertyOffset_1;

		// Token: 0x04010E88 RID: 69256
		internal static int __PropertyOffset_2;

		// Token: 0x04010E89 RID: 69257
		internal static int __PropertyOffset_3;

		// Token: 0x04010E8A RID: 69258
		internal static int __PropertyOffset_4;

		// Token: 0x04010E8B RID: 69259
		internal static int __PropertyOffset_5;

		// Token: 0x04010E8C RID: 69260
		internal static int __PropertyOffset_6;

		// Token: 0x04010E8D RID: 69261
		internal static int __PropertyOffset_7;

		// Token: 0x04010E8E RID: 69262
		private static IntPtr __CaptureDepth_NativeFunctionPtr;
	}
}
