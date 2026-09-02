using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Character.NPC.Animal.CommonSmallAnimal;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA061
{
	// Token: 0x02004120 RID: 16672
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA061/BP_NA061.BP_NA061_C")]
	[UnrealStructLayout(2256, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2256)]
	public class BP_NA061_C : BP_CommonSmallAnimal_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C54C RID: 181580 RVA: 0x00A9DC28 File Offset: 0x00A9BE28
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_NA061_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA061/BP_NA061.BP_NA061_C");
			}
			return BP_NA061_C._ClassPtr;
		}

		// Token: 0x0602C54D RID: 181581 RVA: 0x00A9DC4C File Offset: 0x00A9BE4C
		public BP_NA061_C() : this(BuiltinUtils.AllocNativeUObject(BP_NA061_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C54E RID: 181582 RVA: 0x00A9DC74 File Offset: 0x00A9BE74
		public BP_NA061_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_NA061_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007753 RID: 30547
		// (get) Token: 0x0602C54F RID: 181583 RVA: 0x00A9DCA8 File Offset: 0x00A9BEA8
		// (set) Token: 0x0602C550 RID: 181584 RVA: 0x00A9DCE1 File Offset: 0x00A9BEE1
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_NA061_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_NA061_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007754 RID: 30548
		// (get) Token: 0x0602C551 RID: 181585 RVA: 0x00A9DD02 File Offset: 0x00A9BF02
		// (set) Token: 0x0602C552 RID: 181586 RVA: 0x00A9DD16 File Offset: 0x00A9BF16
		[Nullable(2)]
		public unsafe UKuroAdjustableCapsuleComponent ROOT
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroAdjustableCapsuleComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_NA061_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_NA061_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x0602C553 RID: 181587 RVA: 0x00A9DD2B File Offset: 0x00A9BF2B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_NA061_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0602C554 RID: 181588 RVA: 0x00A9DD3F File Offset: 0x00A9BF3F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_NA061_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602C555 RID: 181589 RVA: 0x00A9DD54 File Offset: 0x00A9BF54
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_NA061(int EntryPoint)
		{
			BP_NA061_C.__ExecuteUbergraph_BP_NA061_FunctionParams* ptr = stackalloc BP_NA061_C.__ExecuteUbergraph_BP_NA061_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_NA061_C.__ExecuteUbergraph_BP_NA061_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_NA061_C.__ExecuteUbergraph_BP_NA061_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_NA061_C.__ExecuteUbergraph_BP_NA061_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602C556 RID: 181590 RVA: 0x00A9DD9B File Offset: 0x00A9BF9B
		protected BP_NA061_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018997 RID: 100759
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA061/BP_NA061.BP_NA061_C";

		// Token: 0x04018998 RID: 100760
		private static IntPtr _ClassPtr;

		// Token: 0x04018999 RID: 100761
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401899A RID: 100762
		internal new static int __PropertyOffset_0;

		// Token: 0x0401899B RID: 100763
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0401899C RID: 100764
		internal static int __PropertyOffset_1;

		// Token: 0x0401899D RID: 100765
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0401899E RID: 100766
		private static IntPtr __ExecuteUbergraph_BP_NA061_NativeFunctionPtr;

		// Token: 0x0200A43D RID: 42045
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __ExecuteUbergraph_BP_NA061_FunctionParams
		{
			// Token: 0x04033238 RID: 209464
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
