using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.SceneTransition
{
	// Token: 0x02003B2B RID: 15147
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/SceneTransition/BP_SceneTransitionComponent_Hongguang.BP_SceneTransitionComponent_Hongguang_C")]
	[UnrealStructLayout(688, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 673)]
	public class BP_SceneTransitionComponent_Hongguang_C : BP_SceneTransitionComponent_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06020A93 RID: 133779 RVA: 0x00933207 File Offset: 0x00931407
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SceneTransitionComponent_Hongguang_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/SceneTransition/BP_SceneTransitionComponent_Hongguang.BP_SceneTransitionComponent_Hongguang_C");
			}
			return BP_SceneTransitionComponent_Hongguang_C._ClassPtr;
		}

		// Token: 0x06020A94 RID: 133780 RVA: 0x0093322C File Offset: 0x0093142C
		public BP_SceneTransitionComponent_Hongguang_C() : this(BuiltinUtils.AllocNativeUObject(BP_SceneTransitionComponent_Hongguang_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06020A95 RID: 133781 RVA: 0x00933254 File Offset: 0x00931454
		[NullableContext(1)]
		public BP_SceneTransitionComponent_Hongguang_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SceneTransitionComponent_Hongguang_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700369D RID: 13981
		// (get) Token: 0x06020A96 RID: 133782 RVA: 0x00933287 File Offset: 0x00931487
		// (set) Token: 0x06020A97 RID: 133783 RVA: 0x00933297 File Offset: 0x00931497
		public unsafe bool IsBush
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneTransitionComponent_Hongguang_C.__PropertyOffset_0) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneTransitionComponent_Hongguang_C.__PropertyOffset_0) = (value ? 1 : 0);
			}
		}

		// Token: 0x06020A98 RID: 133784 RVA: 0x009332A8 File Offset: 0x009314A8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void NeedDynMatForRoot(ref bool Out)
		{
			BP_SceneTransitionComponent_Hongguang_C.__NeedDynMatForRoot_FunctionParams* ptr = stackalloc BP_SceneTransitionComponent_Hongguang_C.__NeedDynMatForRoot_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_SceneTransitionComponent_Hongguang_C.__NeedDynMatForRoot_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SceneTransitionComponent_Hongguang_C.__NeedDynMatForRoot_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Out = Out;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SceneTransitionComponent_Hongguang_C.__NeedDynMatForRoot_NativeFunctionPtr, (void*)ptr);
			Out = ptr->Out;
		}

		// Token: 0x06020A99 RID: 133785 RVA: 0x009332F8 File Offset: 0x009314F8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void SetMaterialParameters(float DeltaTime, float TransitionAge, float TransitionNormalizedProcess)
		{
			BP_SceneTransitionComponent_Hongguang_C.__SetMaterialParameters_FunctionParams* ptr = stackalloc BP_SceneTransitionComponent_Hongguang_C.__SetMaterialParameters_FunctionParams[(UIntPtr)167] + 15L / (long)sizeof(BP_SceneTransitionComponent_Hongguang_C.__SetMaterialParameters_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SceneTransitionComponent_Hongguang_C.__SetMaterialParameters_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaTime = DeltaTime;
			ptr->TransitionAge = TransitionAge;
			ptr->TransitionNormalizedProcess = TransitionNormalizedProcess;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SceneTransitionComponent_Hongguang_C.__SetMaterialParameters_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06020A9A RID: 133786 RVA: 0x0093334F File Offset: 0x0093154F
		protected BP_SceneTransitionComponent_Hongguang_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040105B2 RID: 66994
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/SceneTransition/BP_SceneTransitionComponent_Hongguang.BP_SceneTransitionComponent_Hongguang_C";

		// Token: 0x040105B3 RID: 66995
		private static IntPtr _ClassPtr;

		// Token: 0x040105B4 RID: 66996
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040105B5 RID: 66997
		internal new static int __PropertyOffset_0;

		// Token: 0x040105B6 RID: 66998
		private static IntPtr __NeedDynMatForRoot_NativeFunctionPtr;

		// Token: 0x040105B7 RID: 66999
		private static IntPtr __SetMaterialParameters_NativeFunctionPtr;

		// Token: 0x02009A07 RID: 39431
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __NeedDynMatForRoot_FunctionParams
		{
			// Token: 0x040320E8 RID: 205032
			[FieldOffset(0)]
			public bool Out;
		}

		// Token: 0x02009A08 RID: 39432
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 152)]
		protected new ref struct __SetMaterialParameters_FunctionParams
		{
			// Token: 0x040320E9 RID: 205033
			[FieldOffset(0)]
			public float DeltaTime;

			// Token: 0x040320EA RID: 205034
			[FieldOffset(4)]
			public float TransitionAge;

			// Token: 0x040320EB RID: 205035
			[FieldOffset(8)]
			public float TransitionNormalizedProcess;
		}
	}
}
