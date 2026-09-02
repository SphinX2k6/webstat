using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Effect.BluePrint.BP_FX_Common
{
	// Token: 0x02003DEC RID: 15852
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Effect/BluePrint/BP_FX_Common/BP_Fx_ItemControl.BP_Fx_ItemControl_C")]
	[UnrealStructLayout(1144, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1140)]
	public class BP_Fx_ItemControl_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06026F45 RID: 159557 RVA: 0x009E65F4 File Offset: 0x009E47F4
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_Fx_ItemControl_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Effect/BluePrint/BP_FX_Common/BP_Fx_ItemControl.BP_Fx_ItemControl_C");
			}
			return BP_Fx_ItemControl_C._ClassPtr;
		}

		// Token: 0x06026F46 RID: 159558 RVA: 0x009E6618 File Offset: 0x009E4818
		public BP_Fx_ItemControl_C() : this(BuiltinUtils.AllocNativeUObject(BP_Fx_ItemControl_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06026F47 RID: 159559 RVA: 0x009E6640 File Offset: 0x009E4840
		[NullableContext(1)]
		public BP_Fx_ItemControl_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_Fx_ItemControl_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17005A39 RID: 23097
		// (get) Token: 0x06026F48 RID: 159560 RVA: 0x009E6674 File Offset: 0x009E4874
		// (set) Token: 0x06026F49 RID: 159561 RVA: 0x009E66AD File Offset: 0x009E48AD
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_Fx_ItemControl_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_Fx_ItemControl_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005A3A RID: 23098
		// (get) Token: 0x06026F4A RID: 159562 RVA: 0x009E66CE File Offset: 0x009E48CE
		// (set) Token: 0x06026F4B RID: 159563 RVA: 0x009E66E2 File Offset: 0x009E48E2
		public unsafe UNiagaraComponent NS_Fx_ControlSpline
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Fx_ItemControl_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Fx_ItemControl_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17005A3B RID: 23099
		// (get) Token: 0x06026F4C RID: 159564 RVA: 0x009E66F7 File Offset: 0x009E48F7
		// (set) Token: 0x06026F4D RID: 159565 RVA: 0x009E670B File Offset: 0x009E490B
		public unsafe USplineComponent Spline
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USplineComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Fx_ItemControl_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Fx_ItemControl_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17005A3C RID: 23100
		// (get) Token: 0x06026F4E RID: 159566 RVA: 0x009E6720 File Offset: 0x009E4920
		// (set) Token: 0x06026F4F RID: 159567 RVA: 0x009E6734 File Offset: 0x009E4934
		public unsafe USceneComponent Scene
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Fx_ItemControl_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Fx_ItemControl_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17005A3D RID: 23101
		// (get) Token: 0x06026F50 RID: 159568 RVA: 0x009E6749 File Offset: 0x009E4949
		// (set) Token: 0x06026F51 RID: 159569 RVA: 0x009E675D File Offset: 0x009E495D
		public unsafe FVectorDouble Item_Position
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Fx_ItemControl_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Fx_ItemControl_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17005A3E RID: 23102
		// (get) Token: 0x06026F52 RID: 159570 RVA: 0x009E6772 File Offset: 0x009E4972
		// (set) Token: 0x06026F53 RID: 159571 RVA: 0x009E6786 File Offset: 0x009E4986
		public unsafe FVectorDouble Controller_Position
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Fx_ItemControl_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Fx_ItemControl_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17005A3F RID: 23103
		// (get) Token: 0x06026F54 RID: 159572 RVA: 0x009E679B File Offset: 0x009E499B
		// (set) Token: 0x06026F55 RID: 159573 RVA: 0x009E67AF File Offset: 0x009E49AF
		public unsafe FVector Controller_Forward
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Fx_ItemControl_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Fx_ItemControl_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17005A40 RID: 23104
		// (get) Token: 0x06026F56 RID: 159574 RVA: 0x009E67C4 File Offset: 0x009E49C4
		// (set) Token: 0x06026F57 RID: 159575 RVA: 0x009E67D4 File Offset: 0x009E49D4
		public unsafe bool NeedUpdate
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Fx_ItemControl_C.__PropertyOffset_7) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Fx_ItemControl_C.__PropertyOffset_7) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005A41 RID: 23105
		// (get) Token: 0x06026F58 RID: 159576 RVA: 0x009E67E5 File Offset: 0x009E49E5
		// (set) Token: 0x06026F59 RID: 159577 RVA: 0x009E67F5 File Offset: 0x009E49F5
		public unsafe float ForceMin
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Fx_ItemControl_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Fx_ItemControl_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17005A42 RID: 23106
		// (get) Token: 0x06026F5A RID: 159578 RVA: 0x009E6806 File Offset: 0x009E4A06
		// (set) Token: 0x06026F5B RID: 159579 RVA: 0x009E6816 File Offset: 0x009E4A16
		public unsafe float ForceMax
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Fx_ItemControl_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Fx_ItemControl_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17005A43 RID: 23107
		// (get) Token: 0x06026F5C RID: 159580 RVA: 0x009E6827 File Offset: 0x009E4A27
		// (set) Token: 0x06026F5D RID: 159581 RVA: 0x009E6837 File Offset: 0x009E4A37
		public unsafe float LengthAdjust
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Fx_ItemControl_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Fx_ItemControl_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x06026F5E RID: 159582 RVA: 0x009E6848 File Offset: 0x009E4A48
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void CalculateTangents(ref FVector ControllerTangent, ref FVector ItemTangent)
		{
			BP_Fx_ItemControl_C.__CalculateTangents_FunctionParams* ptr = stackalloc BP_Fx_ItemControl_C.__CalculateTangents_FunctionParams[(UIntPtr)327] + 15L / (long)sizeof(BP_Fx_ItemControl_C.__CalculateTangents_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Fx_ItemControl_C.__CalculateTangents_NativeFunctionPtr, (void*)ptr, 1);
			ptr->ControllerTangent = ControllerTangent;
			ptr->ItemTangent = ItemTangent;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Fx_ItemControl_C.__CalculateTangents_NativeFunctionPtr, (void*)ptr);
			ControllerTangent = ptr->ControllerTangent;
			ItemTangent = ptr->ItemTangent;
		}

		// Token: 0x06026F5F RID: 159583 RVA: 0x009E68BC File Offset: 0x009E4ABC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetParameter(FVectorDouble ItemPosition)
		{
			BP_Fx_ItemControl_C.__SetParameter_FunctionParams* ptr = stackalloc BP_Fx_ItemControl_C.__SetParameter_FunctionParams[(UIntPtr)79] + 15L / (long)sizeof(BP_Fx_ItemControl_C.__SetParameter_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Fx_ItemControl_C.__SetParameter_NativeFunctionPtr, (void*)ptr, 1);
			ptr->ItemPosition = ItemPosition;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Fx_ItemControl_C.__SetParameter_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06026F60 RID: 159584 RVA: 0x009E6902 File Offset: 0x009E4B02
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Fx_ItemControl_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06026F61 RID: 159585 RVA: 0x009E6916 File Offset: 0x009E4B16
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Fx_ItemControl_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06026F62 RID: 159586 RVA: 0x009E692C File Offset: 0x009E4B2C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_Fx_ItemControl_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_Fx_ItemControl_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Fx_ItemControl_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Fx_ItemControl_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Fx_ItemControl_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06026F63 RID: 159587 RVA: 0x009E6974 File Offset: 0x009E4B74
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_Fx_ItemControl_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_Fx_ItemControl_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Fx_ItemControl_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Fx_ItemControl_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Fx_ItemControl_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06026F64 RID: 159588 RVA: 0x009E69BC File Offset: 0x009E4BBC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_Fx_ItemControl(int EntryPoint)
		{
			BP_Fx_ItemControl_C.__ExecuteUbergraph_BP_Fx_ItemControl_FunctionParams* ptr = stackalloc BP_Fx_ItemControl_C.__ExecuteUbergraph_BP_Fx_ItemControl_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_Fx_ItemControl_C.__ExecuteUbergraph_BP_Fx_ItemControl_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Fx_ItemControl_C.__ExecuteUbergraph_BP_Fx_ItemControl_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Fx_ItemControl_C.__ExecuteUbergraph_BP_Fx_ItemControl_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06026F65 RID: 159589 RVA: 0x009E6A03 File Offset: 0x009E4C03
		protected BP_Fx_ItemControl_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04014568 RID: 83304
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Effect/BluePrint/BP_FX_Common/BP_Fx_ItemControl.BP_Fx_ItemControl_C";

		// Token: 0x04014569 RID: 83305
		private static IntPtr _ClassPtr;

		// Token: 0x0401456A RID: 83306
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401456B RID: 83307
		internal static int __PropertyOffset_0;

		// Token: 0x0401456C RID: 83308
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0401456D RID: 83309
		internal static int __PropertyOffset_1;

		// Token: 0x0401456E RID: 83310
		internal static int __PropertyOffset_2;

		// Token: 0x0401456F RID: 83311
		internal static int __PropertyOffset_3;

		// Token: 0x04014570 RID: 83312
		internal static int __PropertyOffset_4;

		// Token: 0x04014571 RID: 83313
		internal static int __PropertyOffset_5;

		// Token: 0x04014572 RID: 83314
		internal static int __PropertyOffset_6;

		// Token: 0x04014573 RID: 83315
		internal static int __PropertyOffset_7;

		// Token: 0x04014574 RID: 83316
		internal static int __PropertyOffset_8;

		// Token: 0x04014575 RID: 83317
		internal static int __PropertyOffset_9;

		// Token: 0x04014576 RID: 83318
		internal static int __PropertyOffset_10;

		// Token: 0x04014577 RID: 83319
		private static IntPtr __CalculateTangents_NativeFunctionPtr;

		// Token: 0x04014578 RID: 83320
		private static IntPtr __SetParameter_NativeFunctionPtr;

		// Token: 0x04014579 RID: 83321
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0401457A RID: 83322
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0401457B RID: 83323
		private static IntPtr __ExecuteUbergraph_BP_Fx_ItemControl_NativeFunctionPtr;

		// Token: 0x0200A0C4 RID: 41156
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 312)]
		protected ref struct __CalculateTangents_FunctionParams
		{
			// Token: 0x04032D77 RID: 208247
			[FieldOffset(0)]
			public FVector ControllerTangent;

			// Token: 0x04032D78 RID: 208248
			[FieldOffset(12)]
			public FVector ItemTangent;
		}

		// Token: 0x0200A0C5 RID: 41157
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 64)]
		protected ref struct __SetParameter_FunctionParams
		{
			// Token: 0x04032D79 RID: 208249
			[FieldOffset(0)]
			public FVectorDouble ItemPosition;
		}

		// Token: 0x0200A0C6 RID: 41158
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032D7A RID: 208250
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x0200A0C7 RID: 41159
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __ExecuteUbergraph_BP_Fx_ItemControl_FunctionParams
		{
			// Token: 0x04032D7B RID: 208251
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
