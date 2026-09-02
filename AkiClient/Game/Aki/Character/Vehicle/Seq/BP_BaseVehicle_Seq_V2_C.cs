using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Vehicle.Seq
{
	// Token: 0x02003F90 RID: 16272
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/Vehicle/Seq/BP_BaseVehicle_Seq_V2.BP_BaseVehicle_Seq_V2_C")]
	[UnrealStructLayout(1200, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1200)]
	public class BP_BaseVehicle_Seq_V2_C : APawn, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06028B5E RID: 166750 RVA: 0x00A1383C File Offset: 0x00A11A3C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_BaseVehicle_Seq_V2_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Vehicle/Seq/BP_BaseVehicle_Seq_V2.BP_BaseVehicle_Seq_V2_C");
			}
			return BP_BaseVehicle_Seq_V2_C._ClassPtr;
		}

		// Token: 0x06028B5F RID: 166751 RVA: 0x00A13860 File Offset: 0x00A11A60
		public BP_BaseVehicle_Seq_V2_C() : this(BuiltinUtils.AllocNativeUObject(BP_BaseVehicle_Seq_V2_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06028B60 RID: 166752 RVA: 0x00A13888 File Offset: 0x00A11A88
		public BP_BaseVehicle_Seq_V2_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_BaseVehicle_Seq_V2_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17006397 RID: 25495
		// (get) Token: 0x06028B61 RID: 166753 RVA: 0x00A138BC File Offset: 0x00A11ABC
		// (set) Token: 0x06028B62 RID: 166754 RVA: 0x00A138F5 File Offset: 0x00A11AF5
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_BaseVehicle_Seq_V2_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_BaseVehicle_Seq_V2_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006398 RID: 25496
		// (get) Token: 0x06028B63 RID: 166755 RVA: 0x00A13916 File Offset: 0x00A11B16
		// (set) Token: 0x06028B64 RID: 166756 RVA: 0x00A1392A File Offset: 0x00A11B2A
		[Nullable(2)]
		public unsafe USkeletalMeshComponent SkeletalMesh
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BaseVehicle_Seq_V2_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BaseVehicle_Seq_V2_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17006399 RID: 25497
		// (get) Token: 0x06028B65 RID: 166757 RVA: 0x00A1393F File Offset: 0x00A11B3F
		// (set) Token: 0x06028B66 RID: 166758 RVA: 0x00A13953 File Offset: 0x00A11B53
		[Nullable(2)]
		public unsafe USceneComponent DefaultSceneRoot
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BaseVehicle_Seq_V2_C.__PropertyOffset_2);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BaseVehicle_Seq_V2_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x1700639A RID: 25498
		// (get) Token: 0x06028B67 RID: 166759 RVA: 0x00A13968 File Offset: 0x00A11B68
		// (set) Token: 0x06028B68 RID: 166760 RVA: 0x00A1397C File Offset: 0x00A11B7C
		public unsafe FName BindingTag
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BaseVehicle_Seq_V2_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BaseVehicle_Seq_V2_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x1700639B RID: 25499
		// (get) Token: 0x06028B69 RID: 166761 RVA: 0x00A13991 File Offset: 0x00A11B91
		// (set) Token: 0x06028B6A RID: 166762 RVA: 0x00A139A5 File Offset: 0x00A11BA5
		public unsafe FVector FinalSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BaseVehicle_Seq_V2_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BaseVehicle_Seq_V2_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x1700639C RID: 25500
		// (get) Token: 0x06028B6B RID: 166763 RVA: 0x00A139BA File Offset: 0x00A11BBA
		// (set) Token: 0x06028B6C RID: 166764 RVA: 0x00A139CA File Offset: 0x00A11BCA
		public unsafe float velocity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BaseVehicle_Seq_V2_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BaseVehicle_Seq_V2_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x1700639D RID: 25501
		// (get) Token: 0x06028B6D RID: 166765 RVA: 0x00A139DB File Offset: 0x00A11BDB
		// (set) Token: 0x06028B6E RID: 166766 RVA: 0x00A139EF File Offset: 0x00A11BEF
		public unsafe string CurrSpeed
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)BP_BaseVehicle_Seq_V2_C.__PropertyOffset_6)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)BP_BaseVehicle_Seq_V2_C.__PropertyOffset_6)), value);
			}
		}

		// Token: 0x06028B6F RID: 166767 RVA: 0x00A13A04 File Offset: 0x00A11C04
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void GetFinalSpeed()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BaseVehicle_Seq_V2_C.__GetFinalSpeed_NativeFunctionPtr, null);
		}

		// Token: 0x06028B70 RID: 166768 RVA: 0x00A13A18 File Offset: 0x00A11C18
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_BaseVehicle_Seq_V2_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_BaseVehicle_Seq_V2_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_BaseVehicle_Seq_V2_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BaseVehicle_Seq_V2_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BaseVehicle_Seq_V2_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06028B71 RID: 166769 RVA: 0x00A13A60 File Offset: 0x00A11C60
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_BaseVehicle_Seq_V2_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_BaseVehicle_Seq_V2_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_BaseVehicle_Seq_V2_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BaseVehicle_Seq_V2_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_BaseVehicle_Seq_V2_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06028B72 RID: 166770 RVA: 0x00A13AA8 File Offset: 0x00A11CA8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_BaseVehicle_Seq_V2(int EntryPoint)
		{
			BP_BaseVehicle_Seq_V2_C.__ExecuteUbergraph_BP_BaseVehicle_Seq_V2_FunctionParams* ptr = stackalloc BP_BaseVehicle_Seq_V2_C.__ExecuteUbergraph_BP_BaseVehicle_Seq_V2_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_BaseVehicle_Seq_V2_C.__ExecuteUbergraph_BP_BaseVehicle_Seq_V2_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BaseVehicle_Seq_V2_C.__ExecuteUbergraph_BP_BaseVehicle_Seq_V2_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_BaseVehicle_Seq_V2_C.__ExecuteUbergraph_BP_BaseVehicle_Seq_V2_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06028B73 RID: 166771 RVA: 0x00A13AEF File Offset: 0x00A11CEF
		protected BP_BaseVehicle_Seq_V2_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040157D5 RID: 88021
		public new const string __ObjectPath = "/Game/Aki/Character/Vehicle/Seq/BP_BaseVehicle_Seq_V2.BP_BaseVehicle_Seq_V2_C";

		// Token: 0x040157D6 RID: 88022
		private static IntPtr _ClassPtr;

		// Token: 0x040157D7 RID: 88023
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040157D8 RID: 88024
		internal static int __PropertyOffset_0;

		// Token: 0x040157D9 RID: 88025
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040157DA RID: 88026
		internal static int __PropertyOffset_1;

		// Token: 0x040157DB RID: 88027
		internal static int __PropertyOffset_2;

		// Token: 0x040157DC RID: 88028
		internal static int __PropertyOffset_3;

		// Token: 0x040157DD RID: 88029
		internal static int __PropertyOffset_4;

		// Token: 0x040157DE RID: 88030
		internal static int __PropertyOffset_5;

		// Token: 0x040157DF RID: 88031
		internal static int __PropertyOffset_6;

		// Token: 0x040157E0 RID: 88032
		private static IntPtr __GetFinalSpeed_NativeFunctionPtr;

		// Token: 0x040157E1 RID: 88033
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x040157E2 RID: 88034
		private static IntPtr __ExecuteUbergraph_BP_BaseVehicle_Seq_V2_NativeFunctionPtr;

		// Token: 0x0200A13C RID: 41276
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032E70 RID: 208496
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x0200A13D RID: 41277
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __ExecuteUbergraph_BP_BaseVehicle_Seq_V2_FunctionParams
		{
			// Token: 0x04032E71 RID: 208497
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
