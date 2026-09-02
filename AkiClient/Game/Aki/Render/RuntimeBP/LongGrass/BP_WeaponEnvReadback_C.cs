using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.LongGrass
{
	// Token: 0x02003C60 RID: 15456
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/LongGrass/BP_WeaponEnvReadback.BP_WeaponEnvReadback_C")]
	[UnrealStructLayout(1088, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1088)]
	public class BP_WeaponEnvReadback_C : AKuroCSReadback, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06023C08 RID: 146440 RVA: 0x0098B37B File Offset: 0x0098957B
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_WeaponEnvReadback_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/LongGrass/BP_WeaponEnvReadback.BP_WeaponEnvReadback_C");
			}
			return BP_WeaponEnvReadback_C._ClassPtr;
		}

		// Token: 0x06023C09 RID: 146441 RVA: 0x0098B3A0 File Offset: 0x009895A0
		public BP_WeaponEnvReadback_C() : this(BuiltinUtils.AllocNativeUObject(BP_WeaponEnvReadback_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06023C0A RID: 146442 RVA: 0x0098B3C8 File Offset: 0x009895C8
		[NullableContext(1)]
		public BP_WeaponEnvReadback_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_WeaponEnvReadback_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700481D RID: 18461
		// (get) Token: 0x06023C0B RID: 146443 RVA: 0x0098B3FC File Offset: 0x009895FC
		// (set) Token: 0x06023C0C RID: 146444 RVA: 0x0098B435 File Offset: 0x00989635
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_WeaponEnvReadback_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_WeaponEnvReadback_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x06023C0D RID: 146445 RVA: 0x0098B456 File Offset: 0x00989656
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WeaponEnvReadback_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06023C0E RID: 146446 RVA: 0x0098B46A File Offset: 0x0098966A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_WeaponEnvReadback_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06023C0F RID: 146447 RVA: 0x0098B480 File Offset: 0x00989680
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveEndPlay(EEndPlayReason EndPlayReason)
		{
			BP_WeaponEnvReadback_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_WeaponEnvReadback_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_WeaponEnvReadback_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WeaponEnvReadback_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WeaponEnvReadback_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06023C10 RID: 146448 RVA: 0x0098B4CC File Offset: 0x009896CC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveEndPlay_Implementation(EEndPlayReason EndPlayReason)
		{
			BP_WeaponEnvReadback_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_WeaponEnvReadback_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_WeaponEnvReadback_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WeaponEnvReadback_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_WeaponEnvReadback_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06023C11 RID: 146449 RVA: 0x0098B518 File Offset: 0x00989718
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_WeaponEnvReadback(int EntryPoint)
		{
			BP_WeaponEnvReadback_C.__ExecuteUbergraph_BP_WeaponEnvReadback_FunctionParams* ptr = stackalloc BP_WeaponEnvReadback_C.__ExecuteUbergraph_BP_WeaponEnvReadback_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_WeaponEnvReadback_C.__ExecuteUbergraph_BP_WeaponEnvReadback_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WeaponEnvReadback_C.__ExecuteUbergraph_BP_WeaponEnvReadback_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_WeaponEnvReadback_C.__ExecuteUbergraph_BP_WeaponEnvReadback_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06023C12 RID: 146450 RVA: 0x0098B55F File Offset: 0x0098975F
		protected BP_WeaponEnvReadback_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040123D2 RID: 74706
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/LongGrass/BP_WeaponEnvReadback.BP_WeaponEnvReadback_C";

		// Token: 0x040123D3 RID: 74707
		private static IntPtr _ClassPtr;

		// Token: 0x040123D4 RID: 74708
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040123D5 RID: 74709
		internal static int __PropertyOffset_0;

		// Token: 0x040123D6 RID: 74710
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040123D7 RID: 74711
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x040123D8 RID: 74712
		private static IntPtr __ReceiveEndPlay_NativeFunctionPtr;

		// Token: 0x040123D9 RID: 74713
		private static IntPtr __ExecuteUbergraph_BP_WeaponEnvReadback_NativeFunctionPtr;

		// Token: 0x02009D38 RID: 40248
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __ReceiveEndPlay_FunctionParams
		{
			// Token: 0x0403270A RID: 206602
			[FieldOffset(0)]
			public TEnumAsByte<EEndPlayReason> EndPlayReason;
		}

		// Token: 0x02009D39 RID: 40249
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __ExecuteUbergraph_BP_WeaponEnvReadback_FunctionParams
		{
			// Token: 0x0403270B RID: 206603
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
