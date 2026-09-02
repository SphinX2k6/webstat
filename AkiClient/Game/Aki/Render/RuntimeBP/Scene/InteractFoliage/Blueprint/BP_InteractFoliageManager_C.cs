using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.InteractFoliage.Blueprint
{
	// Token: 0x02003AD3 RID: 15059
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/InteractFoliage/Blueprint/BP_InteractFoliageManager.BP_InteractFoliageManager_C")]
	[UnrealStructLayout(1408, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1393)]
	public class BP_InteractFoliageManager_C : AKuroBPActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602035D RID: 131933 RVA: 0x009256DF File Offset: 0x009238DF
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_InteractFoliageManager_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/InteractFoliage/Blueprint/BP_InteractFoliageManager.BP_InteractFoliageManager_C");
			}
			return BP_InteractFoliageManager_C._ClassPtr;
		}

		// Token: 0x0602035E RID: 131934 RVA: 0x00925704 File Offset: 0x00923904
		public BP_InteractFoliageManager_C() : this(BuiltinUtils.AllocNativeUObject(BP_InteractFoliageManager_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602035F RID: 131935 RVA: 0x0092572C File Offset: 0x0092392C
		[NullableContext(1)]
		public BP_InteractFoliageManager_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_InteractFoliageManager_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003472 RID: 13426
		// (get) Token: 0x06020360 RID: 131936 RVA: 0x00925760 File Offset: 0x00923960
		// (set) Token: 0x06020361 RID: 131937 RVA: 0x00925799 File Offset: 0x00923999
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_InteractFoliageManager_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_InteractFoliageManager_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003473 RID: 13427
		// (get) Token: 0x06020362 RID: 131938 RVA: 0x009257BA File Offset: 0x009239BA
		// (set) Token: 0x06020363 RID: 131939 RVA: 0x009257CE File Offset: 0x009239CE
		public unsafe UStaticMeshComponent Interactor
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_InteractFoliageManager_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_InteractFoliageManager_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17003474 RID: 13428
		// (get) Token: 0x06020364 RID: 131940 RVA: 0x009257E3 File Offset: 0x009239E3
		// (set) Token: 0x06020365 RID: 131941 RVA: 0x009257F7 File Offset: 0x009239F7
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_InteractFoliageManager_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_InteractFoliageManager_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17003475 RID: 13429
		// (get) Token: 0x06020366 RID: 131942 RVA: 0x0092580C File Offset: 0x00923A0C
		// (set) Token: 0x06020367 RID: 131943 RVA: 0x00925820 File Offset: 0x00923A20
		public unsafe FTransformDouble CharacterTransform
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_InteractFoliageManager_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_InteractFoliageManager_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17003476 RID: 13430
		// (get) Token: 0x06020368 RID: 131944 RVA: 0x00925835 File Offset: 0x00923A35
		// (set) Token: 0x06020369 RID: 131945 RVA: 0x00925845 File Offset: 0x00923A45
		public unsafe bool Active
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_InteractFoliageManager_C.__PropertyOffset_4) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_InteractFoliageManager_C.__PropertyOffset_4) = (value ? 1 : 0);
			}
		}

		// Token: 0x0602036A RID: 131946 RVA: 0x00925856 File Offset: 0x00923A56
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InteractFoliageManager_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0602036B RID: 131947 RVA: 0x0092586A File Offset: 0x00923A6A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_InteractFoliageManager_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602036C RID: 131948 RVA: 0x00925880 File Offset: 0x00923A80
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_InteractFoliageManager_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_InteractFoliageManager_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_InteractFoliageManager_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InteractFoliageManager_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InteractFoliageManager_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602036D RID: 131949 RVA: 0x009258C8 File Offset: 0x00923AC8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_InteractFoliageManager_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_InteractFoliageManager_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_InteractFoliageManager_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InteractFoliageManager_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_InteractFoliageManager_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602036E RID: 131950 RVA: 0x0092590F File Offset: 0x00923B0F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void CheckActive()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InteractFoliageManager_C.__CheckActive_NativeFunctionPtr, null);
		}

		// Token: 0x0602036F RID: 131951 RVA: 0x00925923 File Offset: 0x00923B23
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void DebugInteractor()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InteractFoliageManager_C.__DebugInteractor_NativeFunctionPtr, null);
		}

		// Token: 0x06020370 RID: 131952 RVA: 0x00925938 File Offset: 0x00923B38
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_InteractFoliageManager(int EntryPoint)
		{
			BP_InteractFoliageManager_C.__ExecuteUbergraph_BP_InteractFoliageManager_FunctionParams* ptr = stackalloc BP_InteractFoliageManager_C.__ExecuteUbergraph_BP_InteractFoliageManager_FunctionParams[(UIntPtr)447] + 15L / (long)sizeof(BP_InteractFoliageManager_C.__ExecuteUbergraph_BP_InteractFoliageManager_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InteractFoliageManager_C.__ExecuteUbergraph_BP_InteractFoliageManager_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_InteractFoliageManager_C.__ExecuteUbergraph_BP_InteractFoliageManager_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06020371 RID: 131953 RVA: 0x00925982 File Offset: 0x00923B82
		protected BP_InteractFoliageManager_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040100FA RID: 65786
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/InteractFoliage/Blueprint/BP_InteractFoliageManager.BP_InteractFoliageManager_C";

		// Token: 0x040100FB RID: 65787
		private static IntPtr _ClassPtr;

		// Token: 0x040100FC RID: 65788
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040100FD RID: 65789
		internal static int __PropertyOffset_0;

		// Token: 0x040100FE RID: 65790
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040100FF RID: 65791
		internal static int __PropertyOffset_1;

		// Token: 0x04010100 RID: 65792
		internal static int __PropertyOffset_2;

		// Token: 0x04010101 RID: 65793
		internal static int __PropertyOffset_3;

		// Token: 0x04010102 RID: 65794
		internal static int __PropertyOffset_4;

		// Token: 0x04010103 RID: 65795
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04010104 RID: 65796
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04010105 RID: 65797
		private static IntPtr __CheckActive_NativeFunctionPtr;

		// Token: 0x04010106 RID: 65798
		private static IntPtr __DebugInteractor_NativeFunctionPtr;

		// Token: 0x04010107 RID: 65799
		private static IntPtr __ExecuteUbergraph_BP_InteractFoliageManager_NativeFunctionPtr;

		// Token: 0x02009978 RID: 39288
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04031FFE RID: 204798
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009979 RID: 39289
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 432)]
		protected ref struct __ExecuteUbergraph_BP_InteractFoliageManager_FunctionParams
		{
			// Token: 0x04031FFF RID: 204799
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
