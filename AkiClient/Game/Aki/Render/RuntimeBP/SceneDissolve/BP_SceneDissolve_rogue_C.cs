using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.SceneDissolve
{
	// Token: 0x02003B31 RID: 15153
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/SceneDissolve/BP_SceneDissolve_rogue.BP_SceneDissolve_rogue_C")]
	[UnrealStructLayout(1368, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1364)]
	public class BP_SceneDissolve_rogue_C : AKuroBPActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06020AF8 RID: 133880 RVA: 0x00934064 File Offset: 0x00932264
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SceneDissolve_rogue_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/SceneDissolve/BP_SceneDissolve_rogue.BP_SceneDissolve_rogue_C");
			}
			return BP_SceneDissolve_rogue_C._ClassPtr;
		}

		// Token: 0x06020AF9 RID: 133881 RVA: 0x00934088 File Offset: 0x00932288
		public BP_SceneDissolve_rogue_C() : this(BuiltinUtils.AllocNativeUObject(BP_SceneDissolve_rogue_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06020AFA RID: 133882 RVA: 0x009340B0 File Offset: 0x009322B0
		[NullableContext(1)]
		public BP_SceneDissolve_rogue_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SceneDissolve_rogue_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170036B5 RID: 14005
		// (get) Token: 0x06020AFB RID: 133883 RVA: 0x009340E4 File Offset: 0x009322E4
		// (set) Token: 0x06020AFC RID: 133884 RVA: 0x0093411D File Offset: 0x0093231D
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_SceneDissolve_rogue_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_SceneDissolve_rogue_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170036B6 RID: 14006
		// (get) Token: 0x06020AFD RID: 133885 RVA: 0x0093413E File Offset: 0x0093233E
		// (set) Token: 0x06020AFE RID: 133886 RVA: 0x00934152 File Offset: 0x00932352
		public unsafe UNiagaraComponent NS_Fx_SceneDissolve
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SceneDissolve_rogue_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SceneDissolve_rogue_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170036B7 RID: 14007
		// (get) Token: 0x06020AFF RID: 133887 RVA: 0x00934167 File Offset: 0x00932367
		// (set) Token: 0x06020B00 RID: 133888 RVA: 0x0093417B File Offset: 0x0093237B
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SceneDissolve_rogue_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SceneDissolve_rogue_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170036B8 RID: 14008
		// (get) Token: 0x06020B01 RID: 133889 RVA: 0x00934190 File Offset: 0x00932390
		// (set) Token: 0x06020B02 RID: 133890 RVA: 0x009341A0 File Offset: 0x009323A0
		public unsafe float DissolutionProgress
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneDissolve_rogue_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneDissolve_rogue_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x170036B9 RID: 14009
		// (get) Token: 0x06020B03 RID: 133891 RVA: 0x009341B1 File Offset: 0x009323B1
		// (set) Token: 0x06020B04 RID: 133892 RVA: 0x009341C5 File Offset: 0x009323C5
		public unsafe UMaterialParameterCollection MPC
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialParameterCollection>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SceneDissolve_rogue_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SceneDissolve_rogue_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x170036BA RID: 14010
		// (get) Token: 0x06020B05 RID: 133893 RVA: 0x009341DA File Offset: 0x009323DA
		// (set) Token: 0x06020B06 RID: 133894 RVA: 0x009341EA File Offset: 0x009323EA
		public unsafe float DissolutionHeight
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneDissolve_rogue_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneDissolve_rogue_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x170036BB RID: 14011
		// (get) Token: 0x06020B07 RID: 133895 RVA: 0x009341FB File Offset: 0x009323FB
		// (set) Token: 0x06020B08 RID: 133896 RVA: 0x0093420B File Offset: 0x0093240B
		public unsafe float DissolutionRadius
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneDissolve_rogue_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneDissolve_rogue_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x170036BC RID: 14012
		// (get) Token: 0x06020B09 RID: 133897 RVA: 0x0093421C File Offset: 0x0093241C
		// (set) Token: 0x06020B0A RID: 133898 RVA: 0x00934230 File Offset: 0x00932430
		public unsafe FVector DissolutionData
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneDissolve_rogue_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneDissolve_rogue_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x06020B0B RID: 133899 RVA: 0x00934245 File Offset: 0x00932445
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SetParam()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SceneDissolve_rogue_C.__SetParam_NativeFunctionPtr, null);
		}

		// Token: 0x06020B0C RID: 133900 RVA: 0x00934259 File Offset: 0x00932459
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SceneDissolve_rogue_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06020B0D RID: 133901 RVA: 0x0093426D File Offset: 0x0093246D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SceneDissolve_rogue_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06020B0E RID: 133902 RVA: 0x00934282 File Offset: 0x00932482
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SceneDissolve_rogue_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06020B0F RID: 133903 RVA: 0x00934296 File Offset: 0x00932496
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SceneDissolve_rogue_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06020B10 RID: 133904 RVA: 0x009342AC File Offset: 0x009324AC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_SceneDissolve_rogue_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_SceneDissolve_rogue_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SceneDissolve_rogue_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SceneDissolve_rogue_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SceneDissolve_rogue_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06020B11 RID: 133905 RVA: 0x009342F4 File Offset: 0x009324F4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_SceneDissolve_rogue_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_SceneDissolve_rogue_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SceneDissolve_rogue_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SceneDissolve_rogue_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SceneDissolve_rogue_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06020B12 RID: 133906 RVA: 0x0093433B File Offset: 0x0093253B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SetParamFromSeq()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SceneDissolve_rogue_C.__SetParamFromSeq_NativeFunctionPtr, null);
		}

		// Token: 0x06020B13 RID: 133907 RVA: 0x00934350 File Offset: 0x00932550
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_SceneDissolve_rogue(int EntryPoint)
		{
			BP_SceneDissolve_rogue_C.__ExecuteUbergraph_BP_SceneDissolve_rogue_FunctionParams* ptr = stackalloc BP_SceneDissolve_rogue_C.__ExecuteUbergraph_BP_SceneDissolve_rogue_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_SceneDissolve_rogue_C.__ExecuteUbergraph_BP_SceneDissolve_rogue_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SceneDissolve_rogue_C.__ExecuteUbergraph_BP_SceneDissolve_rogue_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SceneDissolve_rogue_C.__ExecuteUbergraph_BP_SceneDissolve_rogue_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06020B14 RID: 133908 RVA: 0x00934397 File Offset: 0x00932597
		protected BP_SceneDissolve_rogue_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040105F4 RID: 67060
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/SceneDissolve/BP_SceneDissolve_rogue.BP_SceneDissolve_rogue_C";

		// Token: 0x040105F5 RID: 67061
		private static IntPtr _ClassPtr;

		// Token: 0x040105F6 RID: 67062
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040105F7 RID: 67063
		internal static int __PropertyOffset_0;

		// Token: 0x040105F8 RID: 67064
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040105F9 RID: 67065
		internal static int __PropertyOffset_1;

		// Token: 0x040105FA RID: 67066
		internal static int __PropertyOffset_2;

		// Token: 0x040105FB RID: 67067
		internal static int __PropertyOffset_3;

		// Token: 0x040105FC RID: 67068
		internal static int __PropertyOffset_4;

		// Token: 0x040105FD RID: 67069
		internal static int __PropertyOffset_5;

		// Token: 0x040105FE RID: 67070
		internal static int __PropertyOffset_6;

		// Token: 0x040105FF RID: 67071
		internal static int __PropertyOffset_7;

		// Token: 0x04010600 RID: 67072
		private static IntPtr __SetParam_NativeFunctionPtr;

		// Token: 0x04010601 RID: 67073
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04010602 RID: 67074
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04010603 RID: 67075
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04010604 RID: 67076
		private static IntPtr __SetParamFromSeq_NativeFunctionPtr;

		// Token: 0x04010605 RID: 67077
		private static IntPtr __ExecuteUbergraph_BP_SceneDissolve_rogue_NativeFunctionPtr;

		// Token: 0x02009A14 RID: 39444
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032102 RID: 205058
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009A15 RID: 39445
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __ExecuteUbergraph_BP_SceneDissolve_rogue_FunctionParams
		{
			// Token: 0x04032103 RID: 205059
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
