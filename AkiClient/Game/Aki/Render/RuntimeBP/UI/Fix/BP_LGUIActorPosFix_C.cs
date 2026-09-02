using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.UI.Fix
{
	// Token: 0x02003A23 RID: 14883
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/UI/Fix/BP_LGUIActorPosFix.BP_LGUIActorPosFix_C")]
	[UnrealStructLayout(232, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 232)]
	public class BP_LGUIActorPosFix_C : UActorComponent, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601E9A3 RID: 125347 RVA: 0x008F9209 File Offset: 0x008F7409
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_LGUIActorPosFix_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/UI/Fix/BP_LGUIActorPosFix.BP_LGUIActorPosFix_C");
			}
			return BP_LGUIActorPosFix_C._ClassPtr;
		}

		// Token: 0x0601E9A4 RID: 125348 RVA: 0x008F9230 File Offset: 0x008F7430
		public BP_LGUIActorPosFix_C() : this(BuiltinUtils.AllocNativeUObject(BP_LGUIActorPosFix_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601E9A5 RID: 125349 RVA: 0x008F9258 File Offset: 0x008F7458
		[NullableContext(1)]
		public BP_LGUIActorPosFix_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_LGUIActorPosFix_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17002B78 RID: 11128
		// (get) Token: 0x0601E9A6 RID: 125350 RVA: 0x008F928C File Offset: 0x008F748C
		// (set) Token: 0x0601E9A7 RID: 125351 RVA: 0x008F92C5 File Offset: 0x008F74C5
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_LGUIActorPosFix_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_LGUIActorPosFix_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17002B79 RID: 11129
		// (get) Token: 0x0601E9A8 RID: 125352 RVA: 0x008F92E6 File Offset: 0x008F74E6
		// (set) Token: 0x0601E9A9 RID: 125353 RVA: 0x008F92FA File Offset: 0x008F74FA
		public unsafe AActor Actor
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + BP_LGUIActorPosFix_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_LGUIActorPosFix_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17002B7A RID: 11130
		// (get) Token: 0x0601E9AA RID: 125354 RVA: 0x008F930F File Offset: 0x008F750F
		// (set) Token: 0x0601E9AB RID: 125355 RVA: 0x008F9323 File Offset: 0x008F7523
		public unsafe UUITexture UITexture_0
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UUITexture>(base.NativePtr / (IntPtr)sizeof(void*) + BP_LGUIActorPosFix_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_LGUIActorPosFix_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x0601E9AC RID: 125356 RVA: 0x008F9338 File Offset: 0x008F7538
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_LGUIActorPosFix_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_LGUIActorPosFix_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_LGUIActorPosFix_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_LGUIActorPosFix_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LGUIActorPosFix_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601E9AD RID: 125357 RVA: 0x008F9380 File Offset: 0x008F7580
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_LGUIActorPosFix_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_LGUIActorPosFix_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_LGUIActorPosFix_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_LGUIActorPosFix_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_LGUIActorPosFix_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601E9AE RID: 125358 RVA: 0x008F93C7 File Offset: 0x008F75C7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LGUIActorPosFix_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0601E9AF RID: 125359 RVA: 0x008F93DB File Offset: 0x008F75DB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_LGUIActorPosFix_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601E9B0 RID: 125360 RVA: 0x008F93F0 File Offset: 0x008F75F0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_LGUIActorPosFix(int EntryPoint)
		{
			BP_LGUIActorPosFix_C.__ExecuteUbergraph_BP_LGUIActorPosFix_FunctionParams* ptr = stackalloc BP_LGUIActorPosFix_C.__ExecuteUbergraph_BP_LGUIActorPosFix_FunctionParams[(UIntPtr)279] + 15L / (long)sizeof(BP_LGUIActorPosFix_C.__ExecuteUbergraph_BP_LGUIActorPosFix_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_LGUIActorPosFix_C.__ExecuteUbergraph_BP_LGUIActorPosFix_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_LGUIActorPosFix_C.__ExecuteUbergraph_BP_LGUIActorPosFix_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601E9B1 RID: 125361 RVA: 0x008F943A File Offset: 0x008F763A
		protected BP_LGUIActorPosFix_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400F15E RID: 61790
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/UI/Fix/BP_LGUIActorPosFix.BP_LGUIActorPosFix_C";

		// Token: 0x0400F15F RID: 61791
		private static IntPtr _ClassPtr;

		// Token: 0x0400F160 RID: 61792
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400F161 RID: 61793
		internal static int __PropertyOffset_0;

		// Token: 0x0400F162 RID: 61794
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400F163 RID: 61795
		internal static int __PropertyOffset_1;

		// Token: 0x0400F164 RID: 61796
		internal static int __PropertyOffset_2;

		// Token: 0x0400F165 RID: 61797
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0400F166 RID: 61798
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0400F167 RID: 61799
		private static IntPtr __ExecuteUbergraph_BP_LGUIActorPosFix_NativeFunctionPtr;

		// Token: 0x020097CA RID: 38858
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04031DB0 RID: 204208
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x020097CB RID: 38859
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 264)]
		protected ref struct __ExecuteUbergraph_BP_LGUIActorPosFix_FunctionParams
		{
			// Token: 0x04031DB1 RID: 204209
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
