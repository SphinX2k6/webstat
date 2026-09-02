using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.PB_SeeSaw
{
	// Token: 0x02003BAC RID: 15276
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/PB_SeeSaw/BP_Seesaw.BP_Seesaw_C")]
	[UnrealStructLayout(1408, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1404)]
	public class BP_Seesaw_C : AKuroBPActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06021FC0 RID: 139200 RVA: 0x00959169 File Offset: 0x00957369
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_Seesaw_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/PB_SeeSaw/BP_Seesaw.BP_Seesaw_C");
			}
			return BP_Seesaw_C._ClassPtr;
		}

		// Token: 0x06021FC1 RID: 139201 RVA: 0x00959190 File Offset: 0x00957390
		public BP_Seesaw_C() : this(BuiltinUtils.AllocNativeUObject(BP_Seesaw_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06021FC2 RID: 139202 RVA: 0x009591B8 File Offset: 0x009573B8
		[NullableContext(1)]
		public BP_Seesaw_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_Seesaw_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003E09 RID: 15881
		// (get) Token: 0x06021FC3 RID: 139203 RVA: 0x009591EC File Offset: 0x009573EC
		// (set) Token: 0x06021FC4 RID: 139204 RVA: 0x00959225 File Offset: 0x00957425
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_Seesaw_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_Seesaw_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003E0A RID: 15882
		// (get) Token: 0x06021FC5 RID: 139205 RVA: 0x00959246 File Offset: 0x00957446
		// (set) Token: 0x06021FC6 RID: 139206 RVA: 0x0095925A File Offset: 0x0095745A
		public unsafe UStaticMeshComponent SM_Old_Box_27CM_T
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Seesaw_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Seesaw_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17003E0B RID: 15883
		// (get) Token: 0x06021FC7 RID: 139207 RVA: 0x0095926F File Offset: 0x0095746F
		// (set) Token: 0x06021FC8 RID: 139208 RVA: 0x00959283 File Offset: 0x00957483
		public unsafe UStaticMeshComponent SM_Old_Box_27BM_T
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Seesaw_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Seesaw_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17003E0C RID: 15884
		// (get) Token: 0x06021FC9 RID: 139209 RVA: 0x00959298 File Offset: 0x00957498
		// (set) Token: 0x06021FCA RID: 139210 RVA: 0x009592AC File Offset: 0x009574AC
		public unsafe UPhysicsConstraintComponent Axis
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UPhysicsConstraintComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Seesaw_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Seesaw_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17003E0D RID: 15885
		// (get) Token: 0x06021FCB RID: 139211 RVA: 0x009592C1 File Offset: 0x009574C1
		// (set) Token: 0x06021FCC RID: 139212 RVA: 0x009592D5 File Offset: 0x009574D5
		public unsafe UStaticMeshComponent Base
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Seesaw_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Seesaw_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17003E0E RID: 15886
		// (get) Token: 0x06021FCD RID: 139213 RVA: 0x009592EA File Offset: 0x009574EA
		// (set) Token: 0x06021FCE RID: 139214 RVA: 0x009592FE File Offset: 0x009574FE
		public unsafe UStaticMeshComponent Board
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Seesaw_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Seesaw_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17003E0F RID: 15887
		// (get) Token: 0x06021FCF RID: 139215 RVA: 0x00959313 File Offset: 0x00957513
		// (set) Token: 0x06021FD0 RID: 139216 RVA: 0x00959327 File Offset: 0x00957527
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Seesaw_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Seesaw_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x17003E10 RID: 15888
		// (get) Token: 0x06021FD1 RID: 139217 RVA: 0x0095933C File Offset: 0x0095753C
		// (set) Token: 0x06021FD2 RID: 139218 RVA: 0x0095934C File Offset: 0x0095754C
		public unsafe float MeshBoundRadius
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Seesaw_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Seesaw_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17003E11 RID: 15889
		// (get) Token: 0x06021FD3 RID: 139219 RVA: 0x0095935D File Offset: 0x0095755D
		// (set) Token: 0x06021FD4 RID: 139220 RVA: 0x00959371 File Offset: 0x00957571
		public unsafe FVectorDouble MeshPos
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Seesaw_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Seesaw_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17003E12 RID: 15890
		// (get) Token: 0x06021FD5 RID: 139221 RVA: 0x00959386 File Offset: 0x00957586
		// (set) Token: 0x06021FD6 RID: 139222 RVA: 0x00959396 File Offset: 0x00957596
		public unsafe float PlayerImpulseLerpTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Seesaw_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Seesaw_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17003E13 RID: 15891
		// (get) Token: 0x06021FD7 RID: 139223 RVA: 0x009593A7 File Offset: 0x009575A7
		// (set) Token: 0x06021FD8 RID: 139224 RVA: 0x009593B7 File Offset: 0x009575B7
		public unsafe float DeltaSeconds
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Seesaw_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Seesaw_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17003E14 RID: 15892
		// (get) Token: 0x06021FD9 RID: 139225 RVA: 0x009593C8 File Offset: 0x009575C8
		// (set) Token: 0x06021FDA RID: 139226 RVA: 0x009593D8 File Offset: 0x009575D8
		public unsafe float PlayerImpulse
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Seesaw_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Seesaw_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x06021FDB RID: 139227 RVA: 0x009593E9 File Offset: 0x009575E9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Seesaw_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06021FDC RID: 139228 RVA: 0x009593FD File Offset: 0x009575FD
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Seesaw_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06021FDD RID: 139229 RVA: 0x00959414 File Offset: 0x00957614
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_Seesaw_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_Seesaw_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Seesaw_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Seesaw_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Seesaw_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021FDE RID: 139230 RVA: 0x0095945C File Offset: 0x0095765C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_Seesaw_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_Seesaw_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Seesaw_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Seesaw_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Seesaw_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06021FDF RID: 139231 RVA: 0x009594A3 File Offset: 0x009576A3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Seesaw_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06021FE0 RID: 139232 RVA: 0x009594B7 File Offset: 0x009576B7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Seesaw_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06021FE1 RID: 139233 RVA: 0x009594CC File Offset: 0x009576CC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void OnLogicEnable()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Seesaw_C.__OnLogicEnable_NativeFunctionPtr, null);
		}

		// Token: 0x06021FE2 RID: 139234 RVA: 0x009594E0 File Offset: 0x009576E0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void OnLogicEnable_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Seesaw_C.__OnLogicEnable_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06021FE3 RID: 139235 RVA: 0x009594F5 File Offset: 0x009576F5
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void OnLogicDisable()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Seesaw_C.__OnLogicDisable_NativeFunctionPtr, null);
		}

		// Token: 0x06021FE4 RID: 139236 RVA: 0x00959509 File Offset: 0x00957709
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void OnLogicDisable_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Seesaw_C.__OnLogicDisable_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06021FE5 RID: 139237 RVA: 0x00959520 File Offset: 0x00957720
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_Seesaw(int EntryPoint)
		{
			BP_Seesaw_C.__ExecuteUbergraph_BP_Seesaw_FunctionParams* ptr = stackalloc BP_Seesaw_C.__ExecuteUbergraph_BP_Seesaw_FunctionParams[(UIntPtr)247] + 15L / (long)sizeof(BP_Seesaw_C.__ExecuteUbergraph_BP_Seesaw_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Seesaw_C.__ExecuteUbergraph_BP_Seesaw_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Seesaw_C.__ExecuteUbergraph_BP_Seesaw_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06021FE6 RID: 139238 RVA: 0x0095956A File Offset: 0x0095776A
		protected BP_Seesaw_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040112A5 RID: 70309
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/PB_SeeSaw/BP_Seesaw.BP_Seesaw_C";

		// Token: 0x040112A6 RID: 70310
		private static IntPtr _ClassPtr;

		// Token: 0x040112A7 RID: 70311
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040112A8 RID: 70312
		internal static int __PropertyOffset_0;

		// Token: 0x040112A9 RID: 70313
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040112AA RID: 70314
		internal static int __PropertyOffset_1;

		// Token: 0x040112AB RID: 70315
		internal static int __PropertyOffset_2;

		// Token: 0x040112AC RID: 70316
		internal static int __PropertyOffset_3;

		// Token: 0x040112AD RID: 70317
		internal static int __PropertyOffset_4;

		// Token: 0x040112AE RID: 70318
		internal static int __PropertyOffset_5;

		// Token: 0x040112AF RID: 70319
		internal static int __PropertyOffset_6;

		// Token: 0x040112B0 RID: 70320
		internal static int __PropertyOffset_7;

		// Token: 0x040112B1 RID: 70321
		internal static int __PropertyOffset_8;

		// Token: 0x040112B2 RID: 70322
		internal static int __PropertyOffset_9;

		// Token: 0x040112B3 RID: 70323
		internal static int __PropertyOffset_10;

		// Token: 0x040112B4 RID: 70324
		internal static int __PropertyOffset_11;

		// Token: 0x040112B5 RID: 70325
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x040112B6 RID: 70326
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x040112B7 RID: 70327
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x040112B8 RID: 70328
		private static IntPtr __OnLogicEnable_NativeFunctionPtr;

		// Token: 0x040112B9 RID: 70329
		private static IntPtr __OnLogicDisable_NativeFunctionPtr;

		// Token: 0x040112BA RID: 70330
		private static IntPtr __ExecuteUbergraph_BP_Seesaw_NativeFunctionPtr;

		// Token: 0x02009B82 RID: 39810
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x0403237B RID: 205691
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009B83 RID: 39811
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 232)]
		protected ref struct __ExecuteUbergraph_BP_Seesaw_FunctionParams
		{
			// Token: 0x0403237C RID: 205692
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
