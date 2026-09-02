using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.KuroRayMarchingCloud.CloudTraceTail
{
	// Token: 0x02003BF5 RID: 15349
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/KuroRayMarchingCloud/CloudTraceTail/BP_CloudTraceTrail.BP_CloudTraceTrail_C")]
	[UnrealStructLayout(1144, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1137)]
	public class BP_CloudTraceTrail_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06022B02 RID: 142082 RVA: 0x0096BD64 File Offset: 0x00969F64
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_CloudTraceTrail_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/KuroRayMarchingCloud/CloudTraceTail/BP_CloudTraceTrail.BP_CloudTraceTrail_C");
			}
			return BP_CloudTraceTrail_C._ClassPtr;
		}

		// Token: 0x06022B03 RID: 142083 RVA: 0x0096BD88 File Offset: 0x00969F88
		public BP_CloudTraceTrail_C() : this(BuiltinUtils.AllocNativeUObject(BP_CloudTraceTrail_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06022B04 RID: 142084 RVA: 0x0096BDB0 File Offset: 0x00969FB0
		[NullableContext(1)]
		public BP_CloudTraceTrail_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_CloudTraceTrail_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700423E RID: 16958
		// (get) Token: 0x06022B05 RID: 142085 RVA: 0x0096BDE4 File Offset: 0x00969FE4
		// (set) Token: 0x06022B06 RID: 142086 RVA: 0x0096BE1D File Offset: 0x0096A01D
		[Nullable(1)]
		public FPointerToUberGraphFrame UberGraphFrame
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_CloudTraceTrail_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_CloudTraceTrail_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700423F RID: 16959
		// (get) Token: 0x06022B07 RID: 142087 RVA: 0x0096BE3E File Offset: 0x0096A03E
		// (set) Token: 0x06022B08 RID: 142088 RVA: 0x0096BE52 File Offset: 0x0096A052
		public unsafe UStaticMeshComponent StaticMesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudTraceTrail_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudTraceTrail_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17004240 RID: 16960
		// (get) Token: 0x06022B09 RID: 142089 RVA: 0x0096BE67 File Offset: 0x0096A067
		// (set) Token: 0x06022B0A RID: 142090 RVA: 0x0096BE7B File Offset: 0x0096A07B
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudTraceTrail_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudTraceTrail_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17004241 RID: 16961
		// (get) Token: 0x06022B0B RID: 142091 RVA: 0x0096BE90 File Offset: 0x0096A090
		// (set) Token: 0x06022B0C RID: 142092 RVA: 0x0096BEA4 File Offset: 0x0096A0A4
		public unsafe UMaterialInstanceDynamic RTMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudTraceTrail_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudTraceTrail_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17004242 RID: 16962
		// (get) Token: 0x06022B0D RID: 142093 RVA: 0x0096BEB9 File Offset: 0x0096A0B9
		// (set) Token: 0x06022B0E RID: 142094 RVA: 0x0096BECD File Offset: 0x0096A0CD
		public unsafe AActor BindActor
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudTraceTrail_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudTraceTrail_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17004243 RID: 16963
		// (get) Token: 0x06022B0F RID: 142095 RVA: 0x0096BEE2 File Offset: 0x0096A0E2
		// (set) Token: 0x06022B10 RID: 142096 RVA: 0x0096BEF2 File Offset: 0x0096A0F2
		public unsafe float Value
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudTraceTrail_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudTraceTrail_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17004244 RID: 16964
		// (get) Token: 0x06022B11 RID: 142097 RVA: 0x0096BF03 File Offset: 0x0096A103
		// (set) Token: 0x06022B12 RID: 142098 RVA: 0x0096BF17 File Offset: 0x0096A117
		public unsafe UMaterialInstanceDynamic RTMaterial_Pre
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudTraceTrail_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudTraceTrail_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x17004245 RID: 16965
		// (get) Token: 0x06022B13 RID: 142099 RVA: 0x0096BF2C File Offset: 0x0096A12C
		// (set) Token: 0x06022B14 RID: 142100 RVA: 0x0096BF40 File Offset: 0x0096A140
		public unsafe FVectorDouble LastPostion
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudTraceTrail_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudTraceTrail_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17004246 RID: 16966
		// (get) Token: 0x06022B15 RID: 142101 RVA: 0x0096BF55 File Offset: 0x0096A155
		// (set) Token: 0x06022B16 RID: 142102 RVA: 0x0096BF69 File Offset: 0x0096A169
		public unsafe FVector LastMotionOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudTraceTrail_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudTraceTrail_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17004247 RID: 16967
		// (get) Token: 0x06022B17 RID: 142103 RVA: 0x0096BF7E File Offset: 0x0096A17E
		// (set) Token: 0x06022B18 RID: 142104 RVA: 0x0096BF8E File Offset: 0x0096A18E
		public unsafe bool bFadeWhenStop
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudTraceTrail_C.__PropertyOffset_9) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudTraceTrail_C.__PropertyOffset_9) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004248 RID: 16968
		// (get) Token: 0x06022B19 RID: 142105 RVA: 0x0096BF9F File Offset: 0x0096A19F
		// (set) Token: 0x06022B1A RID: 142106 RVA: 0x0096BFAF File Offset: 0x0096A1AF
		public unsafe bool bFirstTick
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudTraceTrail_C.__PropertyOffset_10) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudTraceTrail_C.__PropertyOffset_10) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004249 RID: 16969
		// (get) Token: 0x06022B1B RID: 142107 RVA: 0x0096BFC0 File Offset: 0x0096A1C0
		// (set) Token: 0x06022B1C RID: 142108 RVA: 0x0096BFD0 File Offset: 0x0096A1D0
		public unsafe bool bEditorTick
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudTraceTrail_C.__PropertyOffset_11) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudTraceTrail_C.__PropertyOffset_11) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700424A RID: 16970
		// (get) Token: 0x06022B1D RID: 142109 RVA: 0x0096BFE1 File Offset: 0x0096A1E1
		// (set) Token: 0x06022B1E RID: 142110 RVA: 0x0096BFF5 File Offset: 0x0096A1F5
		public unsafe UTexture2D CloudMask
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudTraceTrail_C.__PropertyOffset_12);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CloudTraceTrail_C.__PropertyOffset_12, value);
			}
		}

		// Token: 0x1700424B RID: 16971
		// (get) Token: 0x06022B1F RID: 142111 RVA: 0x0096C00A File Offset: 0x0096A20A
		// (set) Token: 0x06022B20 RID: 142112 RVA: 0x0096C01A File Offset: 0x0096A21A
		public unsafe bool bDrawBound
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CloudTraceTrail_C.__PropertyOffset_13) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CloudTraceTrail_C.__PropertyOffset_13) = (value ? 1 : 0);
			}
		}

		// Token: 0x06022B21 RID: 142113 RVA: 0x0096C02B File Offset: 0x0096A22B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CloudTraceTrail_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06022B22 RID: 142114 RVA: 0x0096C03F File Offset: 0x0096A23F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CloudTraceTrail_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06022B23 RID: 142115 RVA: 0x0096C054 File Offset: 0x0096A254
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_CloudTraceTrail_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_CloudTraceTrail_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_CloudTraceTrail_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CloudTraceTrail_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CloudTraceTrail_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06022B24 RID: 142116 RVA: 0x0096C09C File Offset: 0x0096A29C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_CloudTraceTrail_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_CloudTraceTrail_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_CloudTraceTrail_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CloudTraceTrail_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CloudTraceTrail_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06022B25 RID: 142117 RVA: 0x0096C0E3 File Offset: 0x0096A2E3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EditorTick()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CloudTraceTrail_C.__EditorTick_NativeFunctionPtr, null);
		}

		// Token: 0x06022B26 RID: 142118 RVA: 0x0096C0F8 File Offset: 0x0096A2F8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_CloudTraceTrail(int EntryPoint)
		{
			BP_CloudTraceTrail_C.__ExecuteUbergraph_BP_CloudTraceTrail_FunctionParams* ptr = stackalloc BP_CloudTraceTrail_C.__ExecuteUbergraph_BP_CloudTraceTrail_FunctionParams[(UIntPtr)687] + 15L / (long)sizeof(BP_CloudTraceTrail_C.__ExecuteUbergraph_BP_CloudTraceTrail_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CloudTraceTrail_C.__ExecuteUbergraph_BP_CloudTraceTrail_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CloudTraceTrail_C.__ExecuteUbergraph_BP_CloudTraceTrail_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06022B27 RID: 142119 RVA: 0x0096C142 File Offset: 0x0096A342
		protected BP_CloudTraceTrail_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04011949 RID: 72009
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/KuroRayMarchingCloud/CloudTraceTail/BP_CloudTraceTrail.BP_CloudTraceTrail_C";

		// Token: 0x0401194A RID: 72010
		private static IntPtr _ClassPtr;

		// Token: 0x0401194B RID: 72011
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401194C RID: 72012
		internal static int __PropertyOffset_0;

		// Token: 0x0401194D RID: 72013
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0401194E RID: 72014
		internal static int __PropertyOffset_1;

		// Token: 0x0401194F RID: 72015
		internal static int __PropertyOffset_2;

		// Token: 0x04011950 RID: 72016
		internal static int __PropertyOffset_3;

		// Token: 0x04011951 RID: 72017
		internal static int __PropertyOffset_4;

		// Token: 0x04011952 RID: 72018
		internal static int __PropertyOffset_5;

		// Token: 0x04011953 RID: 72019
		internal static int __PropertyOffset_6;

		// Token: 0x04011954 RID: 72020
		internal static int __PropertyOffset_7;

		// Token: 0x04011955 RID: 72021
		internal static int __PropertyOffset_8;

		// Token: 0x04011956 RID: 72022
		internal static int __PropertyOffset_9;

		// Token: 0x04011957 RID: 72023
		internal static int __PropertyOffset_10;

		// Token: 0x04011958 RID: 72024
		internal static int __PropertyOffset_11;

		// Token: 0x04011959 RID: 72025
		internal static int __PropertyOffset_12;

		// Token: 0x0401195A RID: 72026
		internal static int __PropertyOffset_13;

		// Token: 0x0401195B RID: 72027
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0401195C RID: 72028
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0401195D RID: 72029
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x0401195E RID: 72030
		private static IntPtr __ExecuteUbergraph_BP_CloudTraceTrail_NativeFunctionPtr;

		// Token: 0x02009C0C RID: 39948
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032466 RID: 205926
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009C0D RID: 39949
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 672)]
		protected ref struct __ExecuteUbergraph_BP_CloudTraceTrail_FunctionParams
		{
			// Token: 0x04032467 RID: 205927
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
