using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Character.NPC.Animal.CommonSmallAnimal;
using AkiClient.Game.Aki.Render.RuntimeBP.SnowCoverInteraction.BluePrints;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA066
{
	// Token: 0x0200410E RID: 16654
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA066/BP_NA066.BP_NA066_C")]
	[UnrealStructLayout(2272, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2272)]
	public class BP_NA066_C : BP_CommonSmallAnimal_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C4D3 RID: 181459 RVA: 0x00A9CCA8 File Offset: 0x00A9AEA8
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_NA066_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA066/BP_NA066.BP_NA066_C");
			}
			return BP_NA066_C._ClassPtr;
		}

		// Token: 0x0602C4D4 RID: 181460 RVA: 0x00A9CCCC File Offset: 0x00A9AECC
		public BP_NA066_C() : this(BuiltinUtils.AllocNativeUObject(BP_NA066_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C4D5 RID: 181461 RVA: 0x00A9CCF4 File Offset: 0x00A9AEF4
		[NullableContext(1)]
		public BP_NA066_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_NA066_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007742 RID: 30530
		// (get) Token: 0x0602C4D6 RID: 181462 RVA: 0x00A9CD28 File Offset: 0x00A9AF28
		// (set) Token: 0x0602C4D7 RID: 181463 RVA: 0x00A9CD61 File Offset: 0x00A9AF61
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_NA066_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_NA066_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007743 RID: 30531
		// (get) Token: 0x0602C4D8 RID: 181464 RVA: 0x00A9CD82 File Offset: 0x00A9AF82
		// (set) Token: 0x0602C4D9 RID: 181465 RVA: 0x00A9CD96 File Offset: 0x00A9AF96
		public unsafe BP_SnowTrailComponent_NPC_C BP_SnowTrailComponent_NPC
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_SnowTrailComponent_NPC_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_NA066_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_NA066_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17007744 RID: 30532
		// (get) Token: 0x0602C4DA RID: 181466 RVA: 0x00A9CDAB File Offset: 0x00A9AFAB
		// (set) Token: 0x0602C4DB RID: 181467 RVA: 0x00A9CDBF File Offset: 0x00A9AFBF
		public unsafe UCapsuleComponent Capsule
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCapsuleComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_NA066_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_NA066_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17007745 RID: 30533
		// (get) Token: 0x0602C4DC RID: 181468 RVA: 0x00A9CDD4 File Offset: 0x00A9AFD4
		// (set) Token: 0x0602C4DD RID: 181469 RVA: 0x00A9CDE8 File Offset: 0x00A9AFE8
		public unsafe UKuroAdjustableCapsuleComponent ROOT
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroAdjustableCapsuleComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_NA066_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_NA066_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x0602C4DE RID: 181470 RVA: 0x00A9CDFD File Offset: 0x00A9AFFD
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_NA066_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0602C4DF RID: 181471 RVA: 0x00A9CE11 File Offset: 0x00A9B011
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_NA066_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602C4E0 RID: 181472 RVA: 0x00A9CE28 File Offset: 0x00A9B028
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_NA066(int EntryPoint)
		{
			BP_NA066_C.__ExecuteUbergraph_BP_NA066_FunctionParams* ptr = stackalloc BP_NA066_C.__ExecuteUbergraph_BP_NA066_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_NA066_C.__ExecuteUbergraph_BP_NA066_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_NA066_C.__ExecuteUbergraph_BP_NA066_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_NA066_C.__ExecuteUbergraph_BP_NA066_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602C4E1 RID: 181473 RVA: 0x00A9CE6F File Offset: 0x00A9B06F
		protected BP_NA066_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018941 RID: 100673
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA066/BP_NA066.BP_NA066_C";

		// Token: 0x04018942 RID: 100674
		private static IntPtr _ClassPtr;

		// Token: 0x04018943 RID: 100675
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04018944 RID: 100676
		internal new static int __PropertyOffset_0;

		// Token: 0x04018945 RID: 100677
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04018946 RID: 100678
		internal static int __PropertyOffset_1;

		// Token: 0x04018947 RID: 100679
		internal static int __PropertyOffset_2;

		// Token: 0x04018948 RID: 100680
		internal static int __PropertyOffset_3;

		// Token: 0x04018949 RID: 100681
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0401894A RID: 100682
		private static IntPtr __ExecuteUbergraph_BP_NA066_NativeFunctionPtr;

		// Token: 0x0200A438 RID: 42040
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __ExecuteUbergraph_BP_NA066_FunctionParams
		{
			// Token: 0x04033233 RID: 209459
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
