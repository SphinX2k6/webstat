using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.LightningFire
{
	// Token: 0x02003BE3 RID: 15331
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/LightningFire/BP_KuroFlickLight_Fire.BP_KuroFlickLight_Fire_C")]
	[UnrealStructLayout(1392, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1388)]
	public class BP_KuroFlickLight_Fire_C : AKuroFlickerLightActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060226E4 RID: 141028 RVA: 0x009654E0 File Offset: 0x009636E0
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_KuroFlickLight_Fire_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/LightningFire/BP_KuroFlickLight_Fire.BP_KuroFlickLight_Fire_C");
			}
			return BP_KuroFlickLight_Fire_C._ClassPtr;
		}

		// Token: 0x060226E5 RID: 141029 RVA: 0x00965504 File Offset: 0x00963704
		public BP_KuroFlickLight_Fire_C() : this(BuiltinUtils.AllocNativeUObject(BP_KuroFlickLight_Fire_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060226E6 RID: 141030 RVA: 0x0096552C File Offset: 0x0096372C
		[NullableContext(1)]
		public BP_KuroFlickLight_Fire_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_KuroFlickLight_Fire_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170040B5 RID: 16565
		// (get) Token: 0x060226E7 RID: 141031 RVA: 0x00965560 File Offset: 0x00963760
		// (set) Token: 0x060226E8 RID: 141032 RVA: 0x00965599 File Offset: 0x00963799
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_KuroFlickLight_Fire_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_KuroFlickLight_Fire_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170040B6 RID: 16566
		// (get) Token: 0x060226E9 RID: 141033 RVA: 0x009655BA File Offset: 0x009637BA
		// (set) Token: 0x060226EA RID: 141034 RVA: 0x009655CA File Offset: 0x009637CA
		public unsafe float Attenuation_Radius_Max
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroFlickLight_Fire_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroFlickLight_Fire_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x060226EB RID: 141035 RVA: 0x009655DB File Offset: 0x009637DB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void DebugRadius()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroFlickLight_Fire_C.__DebugRadius_NativeFunctionPtr, null);
		}

		// Token: 0x060226EC RID: 141036 RVA: 0x009655EF File Offset: 0x009637EF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Set_LightRadius()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroFlickLight_Fire_C.__Set_LightRadius_NativeFunctionPtr, null);
		}

		// Token: 0x060226ED RID: 141037 RVA: 0x00965603 File Offset: 0x00963803
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroFlickLight_Fire_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x060226EE RID: 141038 RVA: 0x00965617 File Offset: 0x00963817
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroFlickLight_Fire_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060226EF RID: 141039 RVA: 0x0096562C File Offset: 0x0096382C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_KuroFlickLight_Fire_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_KuroFlickLight_Fire_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_KuroFlickLight_Fire_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroFlickLight_Fire_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroFlickLight_Fire_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060226F0 RID: 141040 RVA: 0x00965674 File Offset: 0x00963874
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_KuroFlickLight_Fire_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_KuroFlickLight_Fire_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_KuroFlickLight_Fire_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroFlickLight_Fire_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroFlickLight_Fire_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060226F1 RID: 141041 RVA: 0x009656BC File Offset: 0x009638BC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_KuroFlickLight_Fire(int EntryPoint)
		{
			BP_KuroFlickLight_Fire_C.__ExecuteUbergraph_BP_KuroFlickLight_Fire_FunctionParams* ptr = stackalloc BP_KuroFlickLight_Fire_C.__ExecuteUbergraph_BP_KuroFlickLight_Fire_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_KuroFlickLight_Fire_C.__ExecuteUbergraph_BP_KuroFlickLight_Fire_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroFlickLight_Fire_C.__ExecuteUbergraph_BP_KuroFlickLight_Fire_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroFlickLight_Fire_C.__ExecuteUbergraph_BP_KuroFlickLight_Fire_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060226F2 RID: 141042 RVA: 0x00965703 File Offset: 0x00963903
		protected BP_KuroFlickLight_Fire_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040116E2 RID: 71394
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/LightningFire/BP_KuroFlickLight_Fire.BP_KuroFlickLight_Fire_C";

		// Token: 0x040116E3 RID: 71395
		private static IntPtr _ClassPtr;

		// Token: 0x040116E4 RID: 71396
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040116E5 RID: 71397
		internal static int __PropertyOffset_0;

		// Token: 0x040116E6 RID: 71398
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040116E7 RID: 71399
		internal static int __PropertyOffset_1;

		// Token: 0x040116E8 RID: 71400
		private static IntPtr __DebugRadius_NativeFunctionPtr;

		// Token: 0x040116E9 RID: 71401
		private static IntPtr __Set_LightRadius_NativeFunctionPtr;

		// Token: 0x040116EA RID: 71402
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x040116EB RID: 71403
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x040116EC RID: 71404
		private static IntPtr __ExecuteUbergraph_BP_KuroFlickLight_Fire_NativeFunctionPtr;

		// Token: 0x02009BD7 RID: 39895
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x0403241D RID: 205853
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009BD8 RID: 39896
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __ExecuteUbergraph_BP_KuroFlickLight_Fire_FunctionParams
		{
			// Token: 0x0403241E RID: 205854
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
