using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Sequence
{
	// Token: 0x02003A5A RID: 14938
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Sequence/BP_ForbidVolumetricFog.BP_ForbidVolumetricFog_C")]
	[UnrealStructLayout(1056, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1052)]
	public class BP_ForbidVolumetricFog_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601F0A2 RID: 127138 RVA: 0x00905B34 File Offset: 0x00903D34
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_ForbidVolumetricFog_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Sequence/BP_ForbidVolumetricFog.BP_ForbidVolumetricFog_C");
			}
			return BP_ForbidVolumetricFog_C._ClassPtr;
		}

		// Token: 0x0601F0A3 RID: 127139 RVA: 0x00905B58 File Offset: 0x00903D58
		public BP_ForbidVolumetricFog_C() : this(BuiltinUtils.AllocNativeUObject(BP_ForbidVolumetricFog_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601F0A4 RID: 127140 RVA: 0x00905B80 File Offset: 0x00903D80
		[NullableContext(1)]
		public BP_ForbidVolumetricFog_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_ForbidVolumetricFog_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17002DC5 RID: 11717
		// (get) Token: 0x0601F0A5 RID: 127141 RVA: 0x00905BB4 File Offset: 0x00903DB4
		// (set) Token: 0x0601F0A6 RID: 127142 RVA: 0x00905BED File Offset: 0x00903DED
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_ForbidVolumetricFog_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_ForbidVolumetricFog_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17002DC6 RID: 11718
		// (get) Token: 0x0601F0A7 RID: 127143 RVA: 0x00905C0E File Offset: 0x00903E0E
		// (set) Token: 0x0601F0A8 RID: 127144 RVA: 0x00905C22 File Offset: 0x00903E22
		[Nullable(2)]
		public unsafe USceneComponent DefaultSceneRoot
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_ForbidVolumetricFog_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_ForbidVolumetricFog_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17002DC7 RID: 11719
		// (get) Token: 0x0601F0A9 RID: 127145 RVA: 0x00905C37 File Offset: 0x00903E37
		// (set) Token: 0x0601F0AA RID: 127146 RVA: 0x00905C47 File Offset: 0x00903E47
		public unsafe int NewVar_0
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ForbidVolumetricFog_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ForbidVolumetricFog_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x0601F0AB RID: 127147 RVA: 0x00905C58 File Offset: 0x00903E58
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ForbidVolumetricFog_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0601F0AC RID: 127148 RVA: 0x00905C6C File Offset: 0x00903E6C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_ForbidVolumetricFog_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601F0AD RID: 127149 RVA: 0x00905C84 File Offset: 0x00903E84
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveEndPlay(EEndPlayReason EndPlayReason)
		{
			BP_ForbidVolumetricFog_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_ForbidVolumetricFog_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_ForbidVolumetricFog_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ForbidVolumetricFog_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ForbidVolumetricFog_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F0AE RID: 127150 RVA: 0x00905CD0 File Offset: 0x00903ED0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveEndPlay_Implementation(EEndPlayReason EndPlayReason)
		{
			BP_ForbidVolumetricFog_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_ForbidVolumetricFog_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_ForbidVolumetricFog_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ForbidVolumetricFog_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_ForbidVolumetricFog_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F0AF RID: 127151 RVA: 0x00905D1C File Offset: 0x00903F1C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_ForbidVolumetricFog(int EntryPoint)
		{
			BP_ForbidVolumetricFog_C.__ExecuteUbergraph_BP_ForbidVolumetricFog_FunctionParams* ptr = stackalloc BP_ForbidVolumetricFog_C.__ExecuteUbergraph_BP_ForbidVolumetricFog_FunctionParams[(UIntPtr)63] + 15L / (long)sizeof(BP_ForbidVolumetricFog_C.__ExecuteUbergraph_BP_ForbidVolumetricFog_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ForbidVolumetricFog_C.__ExecuteUbergraph_BP_ForbidVolumetricFog_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_ForbidVolumetricFog_C.__ExecuteUbergraph_BP_ForbidVolumetricFog_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F0B0 RID: 127152 RVA: 0x00905D63 File Offset: 0x00903F63
		protected BP_ForbidVolumetricFog_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400F5BE RID: 62910
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Sequence/BP_ForbidVolumetricFog.BP_ForbidVolumetricFog_C";

		// Token: 0x0400F5BF RID: 62911
		private static IntPtr _ClassPtr;

		// Token: 0x0400F5C0 RID: 62912
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400F5C1 RID: 62913
		internal static int __PropertyOffset_0;

		// Token: 0x0400F5C2 RID: 62914
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400F5C3 RID: 62915
		internal static int __PropertyOffset_1;

		// Token: 0x0400F5C4 RID: 62916
		internal static int __PropertyOffset_2;

		// Token: 0x0400F5C5 RID: 62917
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0400F5C6 RID: 62918
		private static IntPtr __ReceiveEndPlay_NativeFunctionPtr;

		// Token: 0x0400F5C7 RID: 62919
		private static IntPtr __ExecuteUbergraph_BP_ForbidVolumetricFog_NativeFunctionPtr;

		// Token: 0x02009847 RID: 38983
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __ReceiveEndPlay_FunctionParams
		{
			// Token: 0x04031E7A RID: 204410
			[FieldOffset(0)]
			public TEnumAsByte<EEndPlayReason> EndPlayReason;
		}

		// Token: 0x02009848 RID: 38984
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 48)]
		protected ref struct __ExecuteUbergraph_BP_ForbidVolumetricFog_FunctionParams
		{
			// Token: 0x04031E7B RID: 204411
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
