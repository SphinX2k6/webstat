using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Light
{
	// Token: 0x02003A8B RID: 14987
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Light/BP_KuroMoveLightActor.BP_KuroMoveLightActor_C")]
	[UnrealStructLayout(1384, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1384)]
	public class BP_KuroMoveLightActor_C : AKuroMoveLightActor, IUnrealUObject, IUnrealObject, IInterface_KuroLightBP, IUnrealNativeInterface, IUnrealInterface
	{
		// Token: 0x0601F77B RID: 128891 RVA: 0x00912414 File Offset: 0x00910614
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_KuroMoveLightActor_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Light/BP_KuroMoveLightActor.BP_KuroMoveLightActor_C");
			}
			return BP_KuroMoveLightActor_C._ClassPtr;
		}

		// Token: 0x0601F77C RID: 128892 RVA: 0x00912438 File Offset: 0x00910638
		int IInterface_KuroLightBP.InterfaceOffset()
		{
			return BP_KuroMoveLightActor_C.__InterfaceOffset_IInterface_KuroLightBP;
		}

		// Token: 0x0601F77D RID: 128893 RVA: 0x00912440 File Offset: 0x00910640
		public BP_KuroMoveLightActor_C() : this(BuiltinUtils.AllocNativeUObject(BP_KuroMoveLightActor_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601F77E RID: 128894 RVA: 0x00912468 File Offset: 0x00910668
		[NullableContext(1)]
		public BP_KuroMoveLightActor_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_KuroMoveLightActor_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0601F77F RID: 128895 RVA: 0x0091249C File Offset: 0x0091069C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual int GetPlacementSortOrder()
		{
			BP_KuroMoveLightActor_C.__GetPlacementSortOrder_FunctionParams* ptr = stackalloc BP_KuroMoveLightActor_C.__GetPlacementSortOrder_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_KuroMoveLightActor_C.__GetPlacementSortOrder_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroMoveLightActor_C.__GetPlacementSortOrder_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroMoveLightActor_C.__GetPlacementSortOrder_NativeFunctionPtr, (void*)ptr);
			return ptr->__Result;
		}

		// Token: 0x0601F780 RID: 128896 RVA: 0x009124E4 File Offset: 0x009106E4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual int GetPlacementSortOrder_Implementation()
		{
			BP_KuroMoveLightActor_C.__GetPlacementSortOrder_FunctionParams* ptr = stackalloc BP_KuroMoveLightActor_C.__GetPlacementSortOrder_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_KuroMoveLightActor_C.__GetPlacementSortOrder_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroMoveLightActor_C.__GetPlacementSortOrder_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroMoveLightActor_C.__GetPlacementSortOrder_NativeFunctionPtr, (void*)ptr, 0);
			return ptr->__Result;
		}

		// Token: 0x0601F781 RID: 128897 RVA: 0x0091252A File Offset: 0x0091072A
		protected BP_KuroMoveLightActor_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400FA14 RID: 64020
		internal static int __InterfaceOffset_IInterface_KuroLightBP;

		// Token: 0x0400FA15 RID: 64021
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Light/BP_KuroMoveLightActor.BP_KuroMoveLightActor_C";

		// Token: 0x0400FA16 RID: 64022
		private static IntPtr _ClassPtr;

		// Token: 0x0400FA17 RID: 64023
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400FA18 RID: 64024
		private static IntPtr __GetPlacementSortOrder_NativeFunctionPtr;

		// Token: 0x020098E1 RID: 39137
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __GetPlacementSortOrder_FunctionParams
		{
			// Token: 0x04031F36 RID: 204598
			[FieldOffset(0)]
			public int __Result;
		}
	}
}
