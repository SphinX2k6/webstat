using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.SwingInteraction
{
	// Token: 0x02003A43 RID: 14915
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/SwingInteraction/BP_SwingChair.BP_SwingChair_C")]
	[UnrealStructLayout(1352, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1352)]
	public class BP_SwingChair_C : AKuroBPActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601ED9A RID: 126362 RVA: 0x009001BF File Offset: 0x008FE3BF
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SwingChair_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/SwingInteraction/BP_SwingChair.BP_SwingChair_C");
			}
			return BP_SwingChair_C._ClassPtr;
		}

		// Token: 0x0601ED9B RID: 126363 RVA: 0x009001E4 File Offset: 0x008FE3E4
		public BP_SwingChair_C() : this(BuiltinUtils.AllocNativeUObject(BP_SwingChair_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601ED9C RID: 126364 RVA: 0x0090020C File Offset: 0x008FE40C
		[NullableContext(1)]
		public BP_SwingChair_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SwingChair_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17002CCB RID: 11467
		// (get) Token: 0x0601ED9D RID: 126365 RVA: 0x00900240 File Offset: 0x008FE440
		// (set) Token: 0x0601ED9E RID: 126366 RVA: 0x00900279 File Offset: 0x008FE479
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_SwingChair_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_SwingChair_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17002CCC RID: 11468
		// (get) Token: 0x0601ED9F RID: 126367 RVA: 0x0090029A File Offset: 0x008FE49A
		// (set) Token: 0x0601EDA0 RID: 126368 RVA: 0x009002AE File Offset: 0x008FE4AE
		public unsafe UBoxComponent Box
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SwingChair_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SwingChair_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17002CCD RID: 11469
		// (get) Token: 0x0601EDA1 RID: 126369 RVA: 0x009002C3 File Offset: 0x008FE4C3
		// (set) Token: 0x0601EDA2 RID: 126370 RVA: 0x009002D7 File Offset: 0x008FE4D7
		public unsafe UPhysicsConstraintComponent PhysicsConstraint
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UPhysicsConstraintComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SwingChair_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SwingChair_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17002CCE RID: 11470
		// (get) Token: 0x0601EDA3 RID: 126371 RVA: 0x009002EC File Offset: 0x008FE4EC
		// (set) Token: 0x0601EDA4 RID: 126372 RVA: 0x00900300 File Offset: 0x008FE500
		public unsafe UStaticMeshComponent Dizuo
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SwingChair_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SwingChair_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17002CCF RID: 11471
		// (get) Token: 0x0601EDA5 RID: 126373 RVA: 0x00900315 File Offset: 0x008FE515
		// (set) Token: 0x0601EDA6 RID: 126374 RVA: 0x00900329 File Offset: 0x008FE529
		public unsafe UStaticMeshComponent Yizi
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SwingChair_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SwingChair_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17002CD0 RID: 11472
		// (get) Token: 0x0601EDA7 RID: 126375 RVA: 0x0090033E File Offset: 0x008FE53E
		// (set) Token: 0x0601EDA8 RID: 126376 RVA: 0x00900352 File Offset: 0x008FE552
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SwingChair_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SwingChair_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x0601EDA9 RID: 126377 RVA: 0x00900367 File Offset: 0x008FE567
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SwingChair_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0601EDAA RID: 126378 RVA: 0x0090037B File Offset: 0x008FE57B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SwingChair_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601EDAB RID: 126379 RVA: 0x00900390 File Offset: 0x008FE590
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void OnLogicEnable()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SwingChair_C.__OnLogicEnable_NativeFunctionPtr, null);
		}

		// Token: 0x0601EDAC RID: 126380 RVA: 0x009003A4 File Offset: 0x008FE5A4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void OnLogicEnable_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SwingChair_C.__OnLogicEnable_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601EDAD RID: 126381 RVA: 0x009003B9 File Offset: 0x008FE5B9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void OnLogicDisable()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SwingChair_C.__OnLogicDisable_NativeFunctionPtr, null);
		}

		// Token: 0x0601EDAE RID: 126382 RVA: 0x009003CD File Offset: 0x008FE5CD
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void OnLogicDisable_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SwingChair_C.__OnLogicDisable_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601EDAF RID: 126383 RVA: 0x009003E4 File Offset: 0x008FE5E4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_SwingChair(int EntryPoint)
		{
			BP_SwingChair_C.__ExecuteUbergraph_BP_SwingChair_FunctionParams* ptr = stackalloc BP_SwingChair_C.__ExecuteUbergraph_BP_SwingChair_FunctionParams[(UIntPtr)103] + 15L / (long)sizeof(BP_SwingChair_C.__ExecuteUbergraph_BP_SwingChair_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SwingChair_C.__ExecuteUbergraph_BP_SwingChair_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SwingChair_C.__ExecuteUbergraph_BP_SwingChair_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601EDB0 RID: 126384 RVA: 0x0090042B File Offset: 0x008FE62B
		protected BP_SwingChair_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400F3D0 RID: 62416
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/SwingInteraction/BP_SwingChair.BP_SwingChair_C";

		// Token: 0x0400F3D1 RID: 62417
		private static IntPtr _ClassPtr;

		// Token: 0x0400F3D2 RID: 62418
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400F3D3 RID: 62419
		internal static int __PropertyOffset_0;

		// Token: 0x0400F3D4 RID: 62420
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400F3D5 RID: 62421
		internal static int __PropertyOffset_1;

		// Token: 0x0400F3D6 RID: 62422
		internal static int __PropertyOffset_2;

		// Token: 0x0400F3D7 RID: 62423
		internal static int __PropertyOffset_3;

		// Token: 0x0400F3D8 RID: 62424
		internal static int __PropertyOffset_4;

		// Token: 0x0400F3D9 RID: 62425
		internal static int __PropertyOffset_5;

		// Token: 0x0400F3DA RID: 62426
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0400F3DB RID: 62427
		private static IntPtr __OnLogicEnable_NativeFunctionPtr;

		// Token: 0x0400F3DC RID: 62428
		private static IntPtr __OnLogicDisable_NativeFunctionPtr;

		// Token: 0x0400F3DD RID: 62429
		private static IntPtr __ExecuteUbergraph_BP_SwingChair_NativeFunctionPtr;

		// Token: 0x0200980F RID: 38927
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 88)]
		protected ref struct __ExecuteUbergraph_BP_SwingChair_FunctionParams
		{
			// Token: 0x04031E18 RID: 204312
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
