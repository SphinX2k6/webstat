using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Light
{
	// Token: 0x02003A86 RID: 14982
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Light/BP_KuroFlickLight.BP_KuroFlickLight_C")]
	[UnrealStructLayout(1368, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1368)]
	public class BP_KuroFlickLight_C : AKuroFlickerLightActor, IUnrealUObject, IUnrealObject, IInterface_KuroLightBP, IUnrealNativeInterface, IUnrealInterface
	{
		// Token: 0x0601F706 RID: 128774 RVA: 0x0091174C File Offset: 0x0090F94C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_KuroFlickLight_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Light/BP_KuroFlickLight.BP_KuroFlickLight_C");
			}
			return BP_KuroFlickLight_C._ClassPtr;
		}

		// Token: 0x0601F707 RID: 128775 RVA: 0x00911770 File Offset: 0x0090F970
		int IInterface_KuroLightBP.InterfaceOffset()
		{
			return BP_KuroFlickLight_C.__InterfaceOffset_IInterface_KuroLightBP;
		}

		// Token: 0x0601F708 RID: 128776 RVA: 0x00911778 File Offset: 0x0090F978
		public BP_KuroFlickLight_C() : this(BuiltinUtils.AllocNativeUObject(BP_KuroFlickLight_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601F709 RID: 128777 RVA: 0x009117A0 File Offset: 0x0090F9A0
		[NullableContext(1)]
		public BP_KuroFlickLight_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_KuroFlickLight_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0601F70A RID: 128778 RVA: 0x009117D4 File Offset: 0x0090F9D4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual int GetPlacementSortOrder()
		{
			BP_KuroFlickLight_C.__GetPlacementSortOrder_FunctionParams* ptr = stackalloc BP_KuroFlickLight_C.__GetPlacementSortOrder_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_KuroFlickLight_C.__GetPlacementSortOrder_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroFlickLight_C.__GetPlacementSortOrder_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroFlickLight_C.__GetPlacementSortOrder_NativeFunctionPtr, (void*)ptr);
			return ptr->__Result;
		}

		// Token: 0x0601F70B RID: 128779 RVA: 0x0091181C File Offset: 0x0090FA1C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual int GetPlacementSortOrder_Implementation()
		{
			BP_KuroFlickLight_C.__GetPlacementSortOrder_FunctionParams* ptr = stackalloc BP_KuroFlickLight_C.__GetPlacementSortOrder_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_KuroFlickLight_C.__GetPlacementSortOrder_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroFlickLight_C.__GetPlacementSortOrder_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroFlickLight_C.__GetPlacementSortOrder_NativeFunctionPtr, (void*)ptr, 0);
			return ptr->__Result;
		}

		// Token: 0x0601F70C RID: 128780 RVA: 0x00911862 File Offset: 0x0090FA62
		protected BP_KuroFlickLight_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400F9C7 RID: 63943
		internal static int __InterfaceOffset_IInterface_KuroLightBP;

		// Token: 0x0400F9C8 RID: 63944
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Light/BP_KuroFlickLight.BP_KuroFlickLight_C";

		// Token: 0x0400F9C9 RID: 63945
		private static IntPtr _ClassPtr;

		// Token: 0x0400F9CA RID: 63946
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400F9CB RID: 63947
		private static IntPtr __GetPlacementSortOrder_NativeFunctionPtr;

		// Token: 0x020098DC RID: 39132
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __GetPlacementSortOrder_FunctionParams
		{
			// Token: 0x04031F31 RID: 204593
			[FieldOffset(0)]
			public int __Result;
		}
	}
}
