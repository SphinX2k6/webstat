using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.GI.LensFlare
{
	// Token: 0x02003CD2 RID: 15570
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/GI/LensFlare/BP_LensFlare.BP_LensFlare_C")]
	[UnrealStructLayout(336, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 336)]
	public class BP_LensFlare_C : UKuroLensFlare, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060251FE RID: 152062 RVA: 0x009B16F8 File Offset: 0x009AF8F8
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_LensFlare_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/GI/LensFlare/BP_LensFlare.BP_LensFlare_C");
			}
			return BP_LensFlare_C._ClassPtr;
		}

		// Token: 0x060251FF RID: 152063 RVA: 0x009B171C File Offset: 0x009AF91C
		public BP_LensFlare_C() : this(BuiltinUtils.AllocNativeUObject(BP_LensFlare_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06025200 RID: 152064 RVA: 0x009B1744 File Offset: 0x009AF944
		[NullableContext(1)]
		public BP_LensFlare_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_LensFlare_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17004FCA RID: 20426
		// (get) Token: 0x06025201 RID: 152065 RVA: 0x009B1777 File Offset: 0x009AF977
		// (set) Token: 0x06025202 RID: 152066 RVA: 0x009B178B File Offset: 0x009AF98B
		public unsafe UDataTable LensFlareDataTable
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UDataTable>(base.NativePtr / (IntPtr)sizeof(void*) + BP_LensFlare_C.__PropertyOffset_0);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_LensFlare_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x17004FCB RID: 20427
		// (get) Token: 0x06025203 RID: 152067 RVA: 0x009B17A0 File Offset: 0x009AF9A0
		// (set) Token: 0x06025204 RID: 152068 RVA: 0x009B17B4 File Offset: 0x009AF9B4
		public unsafe UMaterialInstance MILensFlare
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_LensFlare_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_LensFlare_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17004FCC RID: 20428
		// (get) Token: 0x06025205 RID: 152069 RVA: 0x009B17C9 File Offset: 0x009AF9C9
		// (set) Token: 0x06025206 RID: 152070 RVA: 0x009B17D9 File Offset: 0x009AF9D9
		public unsafe bool EditorUpdate
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LensFlare_C.__PropertyOffset_2) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LensFlare_C.__PropertyOffset_2) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004FCD RID: 20429
		// (get) Token: 0x06025207 RID: 152071 RVA: 0x009B17EA File Offset: 0x009AF9EA
		// (set) Token: 0x06025208 RID: 152072 RVA: 0x009B17FE File Offset: 0x009AF9FE
		public unsafe UMaterialInstanceDynamic DMILensFlare
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_LensFlare_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_LensFlare_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17004FCE RID: 20430
		// (get) Token: 0x06025209 RID: 152073 RVA: 0x009B1813 File Offset: 0x009AFA13
		// (set) Token: 0x0602520A RID: 152074 RVA: 0x009B1823 File Offset: 0x009AFA23
		public unsafe int DefaultWidth
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LensFlare_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LensFlare_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17004FCF RID: 20431
		// (get) Token: 0x0602520B RID: 152075 RVA: 0x009B1834 File Offset: 0x009AFA34
		// (set) Token: 0x0602520C RID: 152076 RVA: 0x009B1848 File Offset: 0x009AFA48
		public unsafe UTexture2D LensFlareTexture
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_LensFlare_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_LensFlare_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17004FD0 RID: 20432
		// (get) Token: 0x0602520D RID: 152077 RVA: 0x009B185D File Offset: 0x009AFA5D
		// (set) Token: 0x0602520E RID: 152078 RVA: 0x009B1871 File Offset: 0x009AFA71
		public unsafe FLinearColor LensFlareColorTint
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LensFlare_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LensFlare_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x0602520F RID: 152079 RVA: 0x009B1888 File Offset: 0x009AFA88
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void EncodeRGBM(FLinearColor InputLinearColor, ref FLinearColor OutputLinearColor)
		{
			BP_LensFlare_C.__EncodeRGBM_FunctionParams* ptr = stackalloc BP_LensFlare_C.__EncodeRGBM_FunctionParams[(UIntPtr)179] + 15L / (long)sizeof(BP_LensFlare_C.__EncodeRGBM_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_LensFlare_C.__EncodeRGBM_NativeFunctionPtr, (void*)ptr, 1);
			ptr->InputLinearColor = InputLinearColor;
			ptr->OutputLinearColor = OutputLinearColor;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LensFlare_C.__EncodeRGBM_NativeFunctionPtr, (void*)ptr);
			OutputLinearColor = ptr->OutputLinearColor;
		}

		// Token: 0x06025210 RID: 152080 RVA: 0x009B18EC File Offset: 0x009AFAEC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void CanUpdate(ref bool Ret)
		{
			BP_LensFlare_C.__CanUpdate_FunctionParams* ptr = stackalloc BP_LensFlare_C.__CanUpdate_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_LensFlare_C.__CanUpdate_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_LensFlare_C.__CanUpdate_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Ret = Ret;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LensFlare_C.__CanUpdate_NativeFunctionPtr, (void*)ptr);
			Ret = ptr->Ret;
		}

		// Token: 0x06025211 RID: 152081 RVA: 0x009B193C File Offset: 0x009AFB3C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Update(bool IsRunning, bool Visible, FLinearColor ColorTint, FVectorDouble LensFlareWorldPosition)
		{
			BP_LensFlare_C.__Update_FunctionParams* ptr = stackalloc BP_LensFlare_C.__Update_FunctionParams[(UIntPtr)111] + 15L / (long)sizeof(BP_LensFlare_C.__Update_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_LensFlare_C.__Update_NativeFunctionPtr, (void*)ptr, 1);
			ptr->IsRunning = IsRunning;
			ptr->Visible = Visible;
			ptr->ColorTint = ColorTint;
			ptr->LensFlareWorldPosition = LensFlareWorldPosition;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LensFlare_C.__Update_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025212 RID: 152082 RVA: 0x009B1998 File Offset: 0x009AFB98
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void InitMesh()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LensFlare_C.__InitMesh_NativeFunctionPtr, null);
		}

		// Token: 0x06025213 RID: 152083 RVA: 0x009B19AC File Offset: 0x009AFBAC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void InitLensFlare(UProceduralMeshComponent InputProceduralMesh)
		{
			BP_LensFlare_C.__InitLensFlare_FunctionParams* ptr = stackalloc BP_LensFlare_C.__InitLensFlare_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_LensFlare_C.__InitLensFlare_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_LensFlare_C.__InitLensFlare_NativeFunctionPtr, (void*)ptr, 1);
			ptr->InputProceduralMesh = ((InputProceduralMesh != null) ? InputProceduralMesh.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LensFlare_C.__InitLensFlare_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025214 RID: 152084 RVA: 0x009B1A01 File Offset: 0x009AFC01
		protected BP_LensFlare_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040131C2 RID: 78274
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/GI/LensFlare/BP_LensFlare.BP_LensFlare_C";

		// Token: 0x040131C3 RID: 78275
		private static IntPtr _ClassPtr;

		// Token: 0x040131C4 RID: 78276
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040131C5 RID: 78277
		internal static int __PropertyOffset_0;

		// Token: 0x040131C6 RID: 78278
		internal static int __PropertyOffset_1;

		// Token: 0x040131C7 RID: 78279
		internal static int __PropertyOffset_2;

		// Token: 0x040131C8 RID: 78280
		internal static int __PropertyOffset_3;

		// Token: 0x040131C9 RID: 78281
		internal static int __PropertyOffset_4;

		// Token: 0x040131CA RID: 78282
		internal static int __PropertyOffset_5;

		// Token: 0x040131CB RID: 78283
		internal static int __PropertyOffset_6;

		// Token: 0x040131CC RID: 78284
		private static IntPtr __EncodeRGBM_NativeFunctionPtr;

		// Token: 0x040131CD RID: 78285
		private static IntPtr __CanUpdate_NativeFunctionPtr;

		// Token: 0x040131CE RID: 78286
		private static IntPtr __Update_NativeFunctionPtr;

		// Token: 0x040131CF RID: 78287
		private static IntPtr __InitMesh_NativeFunctionPtr;

		// Token: 0x040131D0 RID: 78288
		private static IntPtr __InitLensFlare_NativeFunctionPtr;

		// Token: 0x02009EBD RID: 40637
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 164)]
		protected ref struct __EncodeRGBM_FunctionParams
		{
			// Token: 0x04032981 RID: 207233
			[FieldOffset(0)]
			public FLinearColor InputLinearColor;

			// Token: 0x04032982 RID: 207234
			[FieldOffset(16)]
			public FLinearColor OutputLinearColor;
		}

		// Token: 0x02009EBE RID: 40638
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __CanUpdate_FunctionParams
		{
			// Token: 0x04032983 RID: 207235
			[FieldOffset(0)]
			public bool Ret;
		}

		// Token: 0x02009EBF RID: 40639
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 96)]
		protected ref struct __Update_FunctionParams
		{
			// Token: 0x04032984 RID: 207236
			[FieldOffset(0)]
			public bool IsRunning;

			// Token: 0x04032985 RID: 207237
			[FieldOffset(1)]
			public bool Visible;

			// Token: 0x04032986 RID: 207238
			[FieldOffset(4)]
			public FLinearColor ColorTint;

			// Token: 0x04032987 RID: 207239
			[FieldOffset(24)]
			public FVectorDouble LensFlareWorldPosition;
		}

		// Token: 0x02009EC0 RID: 40640
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __InitLensFlare_FunctionParams
		{
			// Token: 0x04032988 RID: 207240
			[FieldOffset(0)]
			public IntPtr InputProceduralMesh;
		}
	}
}
