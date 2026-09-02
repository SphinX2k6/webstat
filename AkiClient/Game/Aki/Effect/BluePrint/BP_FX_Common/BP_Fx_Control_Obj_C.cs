using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Effect.BluePrint.BP_FX_Common
{
	// Token: 0x02003DEB RID: 15851
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Effect/BluePrint/BP_FX_Common/BP_Fx_Control_Obj.BP_Fx_Control_Obj_C")]
	[UnrealStructLayout(1064, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1057)]
	public class BP_Fx_Control_Obj_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06026F36 RID: 159542 RVA: 0x009E63C4 File Offset: 0x009E45C4
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_Fx_Control_Obj_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Effect/BluePrint/BP_FX_Common/BP_Fx_Control_Obj.BP_Fx_Control_Obj_C");
			}
			return BP_Fx_Control_Obj_C._ClassPtr;
		}

		// Token: 0x06026F37 RID: 159543 RVA: 0x009E63E8 File Offset: 0x009E45E8
		public BP_Fx_Control_Obj_C() : this(BuiltinUtils.AllocNativeUObject(BP_Fx_Control_Obj_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06026F38 RID: 159544 RVA: 0x009E6410 File Offset: 0x009E4610
		[NullableContext(1)]
		public BP_Fx_Control_Obj_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_Fx_Control_Obj_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17005A35 RID: 23093
		// (get) Token: 0x06026F39 RID: 159545 RVA: 0x009E6444 File Offset: 0x009E4644
		// (set) Token: 0x06026F3A RID: 159546 RVA: 0x009E647D File Offset: 0x009E467D
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_Fx_Control_Obj_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_Fx_Control_Obj_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005A36 RID: 23094
		// (get) Token: 0x06026F3B RID: 159547 RVA: 0x009E649E File Offset: 0x009E469E
		// (set) Token: 0x06026F3C RID: 159548 RVA: 0x009E64B2 File Offset: 0x009E46B2
		public unsafe UNiagaraComponent NS_Fx_Control_Obj_Beam
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Fx_Control_Obj_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Fx_Control_Obj_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17005A37 RID: 23095
		// (get) Token: 0x06026F3D RID: 159549 RVA: 0x009E64C7 File Offset: 0x009E46C7
		// (set) Token: 0x06026F3E RID: 159550 RVA: 0x009E64DB File Offset: 0x009E46DB
		public unsafe AActor EndActor
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Fx_Control_Obj_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Fx_Control_Obj_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17005A38 RID: 23096
		// (get) Token: 0x06026F3F RID: 159551 RVA: 0x009E64F0 File Offset: 0x009E46F0
		// (set) Token: 0x06026F40 RID: 159552 RVA: 0x009E6500 File Offset: 0x009E4700
		public unsafe bool CanShow
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Fx_Control_Obj_C.__PropertyOffset_3) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Fx_Control_Obj_C.__PropertyOffset_3) = (value ? 1 : 0);
			}
		}

		// Token: 0x06026F41 RID: 159553 RVA: 0x009E6514 File Offset: 0x009E4714
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_Fx_Control_Obj_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_Fx_Control_Obj_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Fx_Control_Obj_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Fx_Control_Obj_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Fx_Control_Obj_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06026F42 RID: 159554 RVA: 0x009E655C File Offset: 0x009E475C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_Fx_Control_Obj_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_Fx_Control_Obj_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Fx_Control_Obj_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Fx_Control_Obj_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Fx_Control_Obj_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06026F43 RID: 159555 RVA: 0x009E65A4 File Offset: 0x009E47A4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_Fx_Control_Obj(int EntryPoint)
		{
			BP_Fx_Control_Obj_C.__ExecuteUbergraph_BP_Fx_Control_Obj_FunctionParams* ptr = stackalloc BP_Fx_Control_Obj_C.__ExecuteUbergraph_BP_Fx_Control_Obj_FunctionParams[(UIntPtr)71] + 15L / (long)sizeof(BP_Fx_Control_Obj_C.__ExecuteUbergraph_BP_Fx_Control_Obj_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Fx_Control_Obj_C.__ExecuteUbergraph_BP_Fx_Control_Obj_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Fx_Control_Obj_C.__ExecuteUbergraph_BP_Fx_Control_Obj_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06026F44 RID: 159556 RVA: 0x009E65EB File Offset: 0x009E47EB
		protected BP_Fx_Control_Obj_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401455E RID: 83294
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Effect/BluePrint/BP_FX_Common/BP_Fx_Control_Obj.BP_Fx_Control_Obj_C";

		// Token: 0x0401455F RID: 83295
		private static IntPtr _ClassPtr;

		// Token: 0x04014560 RID: 83296
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04014561 RID: 83297
		internal static int __PropertyOffset_0;

		// Token: 0x04014562 RID: 83298
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04014563 RID: 83299
		internal static int __PropertyOffset_1;

		// Token: 0x04014564 RID: 83300
		internal static int __PropertyOffset_2;

		// Token: 0x04014565 RID: 83301
		internal static int __PropertyOffset_3;

		// Token: 0x04014566 RID: 83302
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04014567 RID: 83303
		private static IntPtr __ExecuteUbergraph_BP_Fx_Control_Obj_NativeFunctionPtr;

		// Token: 0x0200A0C2 RID: 41154
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032D75 RID: 208245
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x0200A0C3 RID: 41155
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 56)]
		protected ref struct __ExecuteUbergraph_BP_Fx_Control_Obj_FunctionParams
		{
			// Token: 0x04032D76 RID: 208246
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
