using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Light
{
	// Token: 0x02003A80 RID: 14976
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Light/BP_FloatLight.BP_FloatLight_C")]
	[UnrealStructLayout(1400, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1400)]
	public class BP_FloatLight_C : AKuroFloatLightActor, IUnrealUObject, IUnrealObject, IInterface_KuroLightBP, IUnrealNativeInterface, IUnrealInterface
	{
		// Token: 0x0601F55F RID: 128351 RVA: 0x0090F178 File Offset: 0x0090D378
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_FloatLight_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Light/BP_FloatLight.BP_FloatLight_C");
			}
			return BP_FloatLight_C._ClassPtr;
		}

		// Token: 0x0601F560 RID: 128352 RVA: 0x0090F19C File Offset: 0x0090D39C
		int IInterface_KuroLightBP.InterfaceOffset()
		{
			return BP_FloatLight_C.__InterfaceOffset_IInterface_KuroLightBP;
		}

		// Token: 0x0601F561 RID: 128353 RVA: 0x0090F1A4 File Offset: 0x0090D3A4
		public BP_FloatLight_C() : this(BuiltinUtils.AllocNativeUObject(BP_FloatLight_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601F562 RID: 128354 RVA: 0x0090F1CC File Offset: 0x0090D3CC
		[NullableContext(1)]
		public BP_FloatLight_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_FloatLight_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17002F46 RID: 12102
		// (get) Token: 0x0601F563 RID: 128355 RVA: 0x0090F1FF File Offset: 0x0090D3FF
		// (set) Token: 0x0601F564 RID: 128356 RVA: 0x0090F213 File Offset: 0x0090D413
		[Nullable(2)]
		public unsafe UBillboardComponent Billboard
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBillboardComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FloatLight_C.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FloatLight_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x0601F565 RID: 128357 RVA: 0x0090F228 File Offset: 0x0090D428
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual int GetPlacementSortOrder()
		{
			BP_FloatLight_C.__GetPlacementSortOrder_FunctionParams* ptr = stackalloc BP_FloatLight_C.__GetPlacementSortOrder_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_FloatLight_C.__GetPlacementSortOrder_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FloatLight_C.__GetPlacementSortOrder_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FloatLight_C.__GetPlacementSortOrder_NativeFunctionPtr, (void*)ptr);
			return ptr->__Result;
		}

		// Token: 0x0601F566 RID: 128358 RVA: 0x0090F270 File Offset: 0x0090D470
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual int GetPlacementSortOrder_Implementation()
		{
			BP_FloatLight_C.__GetPlacementSortOrder_FunctionParams* ptr = stackalloc BP_FloatLight_C.__GetPlacementSortOrder_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_FloatLight_C.__GetPlacementSortOrder_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FloatLight_C.__GetPlacementSortOrder_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_FloatLight_C.__GetPlacementSortOrder_NativeFunctionPtr, (void*)ptr, 0);
			return ptr->__Result;
		}

		// Token: 0x0601F567 RID: 128359 RVA: 0x0090F2B6 File Offset: 0x0090D4B6
		protected BP_FloatLight_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400F8DC RID: 63708
		internal static int __InterfaceOffset_IInterface_KuroLightBP;

		// Token: 0x0400F8DD RID: 63709
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Light/BP_FloatLight.BP_FloatLight_C";

		// Token: 0x0400F8DE RID: 63710
		private static IntPtr _ClassPtr;

		// Token: 0x0400F8DF RID: 63711
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400F8E0 RID: 63712
		internal static int __PropertyOffset_0;

		// Token: 0x0400F8E1 RID: 63713
		private static IntPtr __GetPlacementSortOrder_NativeFunctionPtr;

		// Token: 0x020098CC RID: 39116
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __GetPlacementSortOrder_FunctionParams
		{
			// Token: 0x04031F1E RID: 204574
			[FieldOffset(0)]
			public int __Result;
		}
	}
}
