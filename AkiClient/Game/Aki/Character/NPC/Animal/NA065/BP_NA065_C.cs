using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Character.NPC.Animal.CommonSmallAnimal;
using AkiClient.Game.Aki.Render.RuntimeBP.SnowCoverInteraction.BluePrints;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA065
{
	// Token: 0x02004112 RID: 16658
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA065/BP_NA065.BP_NA065_C")]
	[UnrealStructLayout(2272, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2264)]
	public class BP_NA065_C : BP_CommonSmallAnimal_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C4F0 RID: 181488 RVA: 0x00A9D03C File Offset: 0x00A9B23C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_NA065_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA065/BP_NA065.BP_NA065_C");
			}
			return BP_NA065_C._ClassPtr;
		}

		// Token: 0x0602C4F1 RID: 181489 RVA: 0x00A9D060 File Offset: 0x00A9B260
		public BP_NA065_C() : this(BuiltinUtils.AllocNativeUObject(BP_NA065_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C4F2 RID: 181490 RVA: 0x00A9D088 File Offset: 0x00A9B288
		[NullableContext(1)]
		public BP_NA065_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_NA065_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007747 RID: 30535
		// (get) Token: 0x0602C4F3 RID: 181491 RVA: 0x00A9D0BC File Offset: 0x00A9B2BC
		// (set) Token: 0x0602C4F4 RID: 181492 RVA: 0x00A9D0F5 File Offset: 0x00A9B2F5
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_NA065_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_NA065_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007748 RID: 30536
		// (get) Token: 0x0602C4F5 RID: 181493 RVA: 0x00A9D116 File Offset: 0x00A9B316
		// (set) Token: 0x0602C4F6 RID: 181494 RVA: 0x00A9D12A File Offset: 0x00A9B32A
		public unsafe BP_SnowTrailComponent_NPC_C BP_SnowTrailComponent_NPC
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_SnowTrailComponent_NPC_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_NA065_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_NA065_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17007749 RID: 30537
		// (get) Token: 0x0602C4F7 RID: 181495 RVA: 0x00A9D13F File Offset: 0x00A9B33F
		// (set) Token: 0x0602C4F8 RID: 181496 RVA: 0x00A9D153 File Offset: 0x00A9B353
		public unsafe UKuroAdjustableCapsuleComponent ROOT
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroAdjustableCapsuleComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_NA065_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_NA065_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x0602C4F9 RID: 181497 RVA: 0x00A9D168 File Offset: 0x00A9B368
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_NA065_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0602C4FA RID: 181498 RVA: 0x00A9D17C File Offset: 0x00A9B37C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_NA065_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602C4FB RID: 181499 RVA: 0x00A9D194 File Offset: 0x00A9B394
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_NA065(int EntryPoint)
		{
			BP_NA065_C.__ExecuteUbergraph_BP_NA065_FunctionParams* ptr = stackalloc BP_NA065_C.__ExecuteUbergraph_BP_NA065_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_NA065_C.__ExecuteUbergraph_BP_NA065_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_NA065_C.__ExecuteUbergraph_BP_NA065_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_NA065_C.__ExecuteUbergraph_BP_NA065_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602C4FC RID: 181500 RVA: 0x00A9D1DB File Offset: 0x00A9B3DB
		protected BP_NA065_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018955 RID: 100693
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA065/BP_NA065.BP_NA065_C";

		// Token: 0x04018956 RID: 100694
		private static IntPtr _ClassPtr;

		// Token: 0x04018957 RID: 100695
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04018958 RID: 100696
		internal new static int __PropertyOffset_0;

		// Token: 0x04018959 RID: 100697
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0401895A RID: 100698
		internal static int __PropertyOffset_1;

		// Token: 0x0401895B RID: 100699
		internal static int __PropertyOffset_2;

		// Token: 0x0401895C RID: 100700
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0401895D RID: 100701
		private static IntPtr __ExecuteUbergraph_BP_NA065_NativeFunctionPtr;

		// Token: 0x0200A439 RID: 42041
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __ExecuteUbergraph_BP_NA065_FunctionParams
		{
			// Token: 0x04033234 RID: 209460
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
