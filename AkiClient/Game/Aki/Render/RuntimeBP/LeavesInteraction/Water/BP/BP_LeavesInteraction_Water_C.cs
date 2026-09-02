using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.LeavesInteraction.Water.BP
{
	// Token: 0x02003C69 RID: 15465
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/LeavesInteraction/Water/BP/BP_LeavesInteraction_Water.BP_LeavesInteraction_Water_C")]
	[UnrealStructLayout(1328, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1328)]
	public class BP_LeavesInteraction_Water_C : AInteractiveWaterLeaves, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06023D4A RID: 146762 RVA: 0x0098D5B8 File Offset: 0x0098B7B8
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_LeavesInteraction_Water_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/LeavesInteraction/Water/BP/BP_LeavesInteraction_Water.BP_LeavesInteraction_Water_C");
			}
			return BP_LeavesInteraction_Water_C._ClassPtr;
		}

		// Token: 0x06023D4B RID: 146763 RVA: 0x0098D5DC File Offset: 0x0098B7DC
		public BP_LeavesInteraction_Water_C() : this(BuiltinUtils.AllocNativeUObject(BP_LeavesInteraction_Water_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06023D4C RID: 146764 RVA: 0x0098D604 File Offset: 0x0098B804
		[NullableContext(1)]
		public BP_LeavesInteraction_Water_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_LeavesInteraction_Water_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700488C RID: 18572
		// (get) Token: 0x06023D4D RID: 146765 RVA: 0x0098D638 File Offset: 0x0098B838
		// (set) Token: 0x06023D4E RID: 146766 RVA: 0x0098D671 File Offset: 0x0098B871
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_LeavesInteraction_Water_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_LeavesInteraction_Water_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x06023D4F RID: 146767 RVA: 0x0098D692 File Offset: 0x0098B892
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LeavesInteraction_Water_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06023D50 RID: 146768 RVA: 0x0098D6A6 File Offset: 0x0098B8A6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_LeavesInteraction_Water_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06023D51 RID: 146769 RVA: 0x0098D6BC File Offset: 0x0098B8BC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_LeavesInteraction_Water_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_LeavesInteraction_Water_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_LeavesInteraction_Water_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_LeavesInteraction_Water_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LeavesInteraction_Water_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06023D52 RID: 146770 RVA: 0x0098D704 File Offset: 0x0098B904
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_LeavesInteraction_Water_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_LeavesInteraction_Water_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_LeavesInteraction_Water_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_LeavesInteraction_Water_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_LeavesInteraction_Water_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06023D53 RID: 146771 RVA: 0x0098D74C File Offset: 0x0098B94C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_LeavesInteraction_Water(int EntryPoint)
		{
			BP_LeavesInteraction_Water_C.__ExecuteUbergraph_BP_LeavesInteraction_Water_FunctionParams* ptr = stackalloc BP_LeavesInteraction_Water_C.__ExecuteUbergraph_BP_LeavesInteraction_Water_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_LeavesInteraction_Water_C.__ExecuteUbergraph_BP_LeavesInteraction_Water_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_LeavesInteraction_Water_C.__ExecuteUbergraph_BP_LeavesInteraction_Water_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_LeavesInteraction_Water_C.__ExecuteUbergraph_BP_LeavesInteraction_Water_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06023D54 RID: 146772 RVA: 0x0098D793 File Offset: 0x0098B993
		protected BP_LeavesInteraction_Water_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040124AE RID: 74926
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/LeavesInteraction/Water/BP/BP_LeavesInteraction_Water.BP_LeavesInteraction_Water_C";

		// Token: 0x040124AF RID: 74927
		private static IntPtr _ClassPtr;

		// Token: 0x040124B0 RID: 74928
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040124B1 RID: 74929
		internal static int __PropertyOffset_0;

		// Token: 0x040124B2 RID: 74930
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040124B3 RID: 74931
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x040124B4 RID: 74932
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x040124B5 RID: 74933
		private static IntPtr __ExecuteUbergraph_BP_LeavesInteraction_Water_NativeFunctionPtr;

		// Token: 0x02009D50 RID: 40272
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032734 RID: 206644
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009D51 RID: 40273
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __ExecuteUbergraph_BP_LeavesInteraction_Water_FunctionParams
		{
			// Token: 0x04032735 RID: 206645
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
