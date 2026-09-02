using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Character.NPC.Animal.CommonSmallAnimal;
using AkiClient.Game.Aki.Render.RuntimeBP.SnowCoverInteraction.BluePrints;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA068
{
	// Token: 0x02004106 RID: 16646
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA068/BP_NA068.BP_NA068_C")]
	[UnrealStructLayout(2272, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2272)]
	public class BP_NA068_C : BP_CommonSmallAnimal_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C4A4 RID: 181412 RVA: 0x00A9C6CC File Offset: 0x00A9A8CC
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_NA068_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA068/BP_NA068.BP_NA068_C");
			}
			return BP_NA068_C._ClassPtr;
		}

		// Token: 0x0602C4A5 RID: 181413 RVA: 0x00A9C6F0 File Offset: 0x00A9A8F0
		public BP_NA068_C() : this(BuiltinUtils.AllocNativeUObject(BP_NA068_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C4A6 RID: 181414 RVA: 0x00A9C718 File Offset: 0x00A9A918
		[NullableContext(1)]
		public BP_NA068_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_NA068_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700773C RID: 30524
		// (get) Token: 0x0602C4A7 RID: 181415 RVA: 0x00A9C74C File Offset: 0x00A9A94C
		// (set) Token: 0x0602C4A8 RID: 181416 RVA: 0x00A9C785 File Offset: 0x00A9A985
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_NA068_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_NA068_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700773D RID: 30525
		// (get) Token: 0x0602C4A9 RID: 181417 RVA: 0x00A9C7A6 File Offset: 0x00A9A9A6
		// (set) Token: 0x0602C4AA RID: 181418 RVA: 0x00A9C7BA File Offset: 0x00A9A9BA
		public unsafe BP_SnowTrailComponent_NPC_C BP_SnowTrailComponent_NPC
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_SnowTrailComponent_NPC_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_NA068_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_NA068_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x1700773E RID: 30526
		// (get) Token: 0x0602C4AB RID: 181419 RVA: 0x00A9C7CF File Offset: 0x00A9A9CF
		// (set) Token: 0x0602C4AC RID: 181420 RVA: 0x00A9C7E3 File Offset: 0x00A9A9E3
		public unsafe UCapsuleComponent Capsule
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCapsuleComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_NA068_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_NA068_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x1700773F RID: 30527
		// (get) Token: 0x0602C4AD RID: 181421 RVA: 0x00A9C7F8 File Offset: 0x00A9A9F8
		// (set) Token: 0x0602C4AE RID: 181422 RVA: 0x00A9C80C File Offset: 0x00A9AA0C
		public unsafe UKuroAdjustableCapsuleComponent ROOT
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroAdjustableCapsuleComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_NA068_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_NA068_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x0602C4AF RID: 181423 RVA: 0x00A9C821 File Offset: 0x00A9AA21
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_NA068_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0602C4B0 RID: 181424 RVA: 0x00A9C835 File Offset: 0x00A9AA35
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_NA068_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602C4B1 RID: 181425 RVA: 0x00A9C84C File Offset: 0x00A9AA4C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_NA068(int EntryPoint)
		{
			BP_NA068_C.__ExecuteUbergraph_BP_NA068_FunctionParams* ptr = stackalloc BP_NA068_C.__ExecuteUbergraph_BP_NA068_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_NA068_C.__ExecuteUbergraph_BP_NA068_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_NA068_C.__ExecuteUbergraph_BP_NA068_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_NA068_C.__ExecuteUbergraph_BP_NA068_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602C4B2 RID: 181426 RVA: 0x00A9C893 File Offset: 0x00A9AA93
		protected BP_NA068_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018920 RID: 100640
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA068/BP_NA068.BP_NA068_C";

		// Token: 0x04018921 RID: 100641
		private static IntPtr _ClassPtr;

		// Token: 0x04018922 RID: 100642
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04018923 RID: 100643
		internal new static int __PropertyOffset_0;

		// Token: 0x04018924 RID: 100644
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04018925 RID: 100645
		internal static int __PropertyOffset_1;

		// Token: 0x04018926 RID: 100646
		internal static int __PropertyOffset_2;

		// Token: 0x04018927 RID: 100647
		internal static int __PropertyOffset_3;

		// Token: 0x04018928 RID: 100648
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04018929 RID: 100649
		private static IntPtr __ExecuteUbergraph_BP_NA068_NativeFunctionPtr;

		// Token: 0x0200A437 RID: 42039
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __ExecuteUbergraph_BP_NA068_FunctionParams
		{
			// Token: 0x04033232 RID: 209458
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
