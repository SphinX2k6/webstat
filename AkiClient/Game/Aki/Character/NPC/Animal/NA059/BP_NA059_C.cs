using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Character.NPC.Animal.CommonSmallAnimal;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA059
{
	// Token: 0x02004125 RID: 16677
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA059/BP_NA059.BP_NA059_C")]
	[UnrealStructLayout(2272, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2264)]
	public class BP_NA059_C : BP_CommonSmallAnimal_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C570 RID: 181616 RVA: 0x00A9E0E4 File Offset: 0x00A9C2E4
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_NA059_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA059/BP_NA059.BP_NA059_C");
			}
			return BP_NA059_C._ClassPtr;
		}

		// Token: 0x0602C571 RID: 181617 RVA: 0x00A9E108 File Offset: 0x00A9C308
		public BP_NA059_C() : this(BuiltinUtils.AllocNativeUObject(BP_NA059_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C572 RID: 181618 RVA: 0x00A9E130 File Offset: 0x00A9C330
		[NullableContext(1)]
		public BP_NA059_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_NA059_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007758 RID: 30552
		// (get) Token: 0x0602C573 RID: 181619 RVA: 0x00A9E164 File Offset: 0x00A9C364
		// (set) Token: 0x0602C574 RID: 181620 RVA: 0x00A9E19D File Offset: 0x00A9C39D
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_NA059_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_NA059_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007759 RID: 30553
		// (get) Token: 0x0602C575 RID: 181621 RVA: 0x00A9E1BE File Offset: 0x00A9C3BE
		// (set) Token: 0x0602C576 RID: 181622 RVA: 0x00A9E1D2 File Offset: 0x00A9C3D2
		public unsafe UCapsuleComponent Capsule
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCapsuleComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_NA059_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_NA059_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x1700775A RID: 30554
		// (get) Token: 0x0602C577 RID: 181623 RVA: 0x00A9E1E7 File Offset: 0x00A9C3E7
		// (set) Token: 0x0602C578 RID: 181624 RVA: 0x00A9E1FB File Offset: 0x00A9C3FB
		public unsafe UKuroAdjustableCapsuleComponent ROOT
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroAdjustableCapsuleComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_NA059_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_NA059_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x0602C579 RID: 181625 RVA: 0x00A9E210 File Offset: 0x00A9C410
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_NA059_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0602C57A RID: 181626 RVA: 0x00A9E224 File Offset: 0x00A9C424
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_NA059_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602C57B RID: 181627 RVA: 0x00A9E23C File Offset: 0x00A9C43C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_NA059(int EntryPoint)
		{
			BP_NA059_C.__ExecuteUbergraph_BP_NA059_FunctionParams* ptr = stackalloc BP_NA059_C.__ExecuteUbergraph_BP_NA059_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_NA059_C.__ExecuteUbergraph_BP_NA059_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_NA059_C.__ExecuteUbergraph_BP_NA059_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_NA059_C.__ExecuteUbergraph_BP_NA059_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602C57C RID: 181628 RVA: 0x00A9E283 File Offset: 0x00A9C483
		protected BP_NA059_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040189B1 RID: 100785
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA059/BP_NA059.BP_NA059_C";

		// Token: 0x040189B2 RID: 100786
		private static IntPtr _ClassPtr;

		// Token: 0x040189B3 RID: 100787
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040189B4 RID: 100788
		internal new static int __PropertyOffset_0;

		// Token: 0x040189B5 RID: 100789
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040189B6 RID: 100790
		internal static int __PropertyOffset_1;

		// Token: 0x040189B7 RID: 100791
		internal static int __PropertyOffset_2;

		// Token: 0x040189B8 RID: 100792
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x040189B9 RID: 100793
		private static IntPtr __ExecuteUbergraph_BP_NA059_NativeFunctionPtr;

		// Token: 0x0200A43F RID: 42047
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __ExecuteUbergraph_BP_NA059_FunctionParams
		{
			// Token: 0x0403323A RID: 209466
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
