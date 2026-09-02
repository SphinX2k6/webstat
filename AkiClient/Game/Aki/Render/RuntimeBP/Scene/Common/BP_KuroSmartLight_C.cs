using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Common
{
	// Token: 0x02003ADD RID: 15069
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Common/BP_KuroSmartLight.BP_KuroSmartLight_C")]
	[UnrealStructLayout(1248, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1241)]
	public class BP_KuroSmartLight_C : AKuroSmartLightActor, IUnrealUObject, IUnrealObject, IInterface_KuroLightBP, IUnrealNativeInterface, IUnrealInterface
	{
		// Token: 0x0602043D RID: 132157 RVA: 0x0092704C File Offset: 0x0092524C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_KuroSmartLight_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Common/BP_KuroSmartLight.BP_KuroSmartLight_C");
			}
			return BP_KuroSmartLight_C._ClassPtr;
		}

		// Token: 0x0602043E RID: 132158 RVA: 0x00927070 File Offset: 0x00925270
		int IInterface_KuroLightBP.InterfaceOffset()
		{
			return BP_KuroSmartLight_C.__InterfaceOffset_IInterface_KuroLightBP;
		}

		// Token: 0x0602043F RID: 132159 RVA: 0x00927078 File Offset: 0x00925278
		public BP_KuroSmartLight_C() : this(BuiltinUtils.AllocNativeUObject(BP_KuroSmartLight_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06020440 RID: 132160 RVA: 0x009270A0 File Offset: 0x009252A0
		[NullableContext(1)]
		public BP_KuroSmartLight_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_KuroSmartLight_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170034B4 RID: 13492
		// (get) Token: 0x06020441 RID: 132161 RVA: 0x009270D4 File Offset: 0x009252D4
		// (set) Token: 0x06020442 RID: 132162 RVA: 0x0092710D File Offset: 0x0092530D
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_KuroSmartLight_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_KuroSmartLight_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170034B5 RID: 13493
		// (get) Token: 0x06020443 RID: 132163 RVA: 0x0092712E File Offset: 0x0092532E
		// (set) Token: 0x06020444 RID: 132164 RVA: 0x00927142 File Offset: 0x00925342
		[Nullable(2)]
		public unsafe UBillboardComponent Billboard
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBillboardComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroSmartLight_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroSmartLight_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170034B6 RID: 13494
		// (get) Token: 0x06020445 RID: 132165 RVA: 0x00927157 File Offset: 0x00925357
		// (set) Token: 0x06020446 RID: 132166 RVA: 0x0092716B File Offset: 0x0092536B
		[Nullable(2)]
		public unsafe UAkAudioEvent AudioEventLightOn
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UAkAudioEvent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroSmartLight_C.__PropertyOffset_2);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroSmartLight_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170034B7 RID: 13495
		// (get) Token: 0x06020447 RID: 132167 RVA: 0x00927180 File Offset: 0x00925380
		// (set) Token: 0x06020448 RID: 132168 RVA: 0x00927194 File Offset: 0x00925394
		[Nullable(2)]
		public unsafe UAkAudioEvent AudioEventLightOff
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UAkAudioEvent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroSmartLight_C.__PropertyOffset_3);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroSmartLight_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x170034B8 RID: 13496
		// (get) Token: 0x06020449 RID: 132169 RVA: 0x009271A9 File Offset: 0x009253A9
		// (set) Token: 0x0602044A RID: 132170 RVA: 0x009271B9 File Offset: 0x009253B9
		public unsafe bool LightOn
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroSmartLight_C.__PropertyOffset_4) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroSmartLight_C.__PropertyOffset_4) = (value ? 1 : 0);
			}
		}

		// Token: 0x0602044B RID: 132171 RVA: 0x009271CC File Offset: 0x009253CC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual int GetPlacementSortOrder()
		{
			BP_KuroSmartLight_C.__GetPlacementSortOrder_FunctionParams* ptr = stackalloc BP_KuroSmartLight_C.__GetPlacementSortOrder_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_KuroSmartLight_C.__GetPlacementSortOrder_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroSmartLight_C.__GetPlacementSortOrder_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroSmartLight_C.__GetPlacementSortOrder_NativeFunctionPtr, (void*)ptr);
			return ptr->__Result;
		}

		// Token: 0x0602044C RID: 132172 RVA: 0x00927214 File Offset: 0x00925414
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual int GetPlacementSortOrder_Implementation()
		{
			BP_KuroSmartLight_C.__GetPlacementSortOrder_FunctionParams* ptr = stackalloc BP_KuroSmartLight_C.__GetPlacementSortOrder_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_KuroSmartLight_C.__GetPlacementSortOrder_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroSmartLight_C.__GetPlacementSortOrder_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroSmartLight_C.__GetPlacementSortOrder_NativeFunctionPtr, (void*)ptr, 0);
			return ptr->__Result;
		}

		// Token: 0x0602044D RID: 132173 RVA: 0x0092725C File Offset: 0x0092545C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void OnUpdateLightOn(float Time)
		{
			BP_KuroSmartLight_C.__OnUpdateLightOn_FunctionParams* ptr = stackalloc BP_KuroSmartLight_C.__OnUpdateLightOn_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_KuroSmartLight_C.__OnUpdateLightOn_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroSmartLight_C.__OnUpdateLightOn_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Time = Time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroSmartLight_C.__OnUpdateLightOn_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602044E RID: 132174 RVA: 0x009272A4 File Offset: 0x009254A4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void OnUpdateLightOn_Implementation(float Time)
		{
			BP_KuroSmartLight_C.__OnUpdateLightOn_FunctionParams* ptr = stackalloc BP_KuroSmartLight_C.__OnUpdateLightOn_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_KuroSmartLight_C.__OnUpdateLightOn_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroSmartLight_C.__OnUpdateLightOn_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Time = Time;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroSmartLight_C.__OnUpdateLightOn_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602044F RID: 132175 RVA: 0x009272EC File Offset: 0x009254EC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void OnUpdateLightOff(float Time)
		{
			BP_KuroSmartLight_C.__OnUpdateLightOff_FunctionParams* ptr = stackalloc BP_KuroSmartLight_C.__OnUpdateLightOff_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_KuroSmartLight_C.__OnUpdateLightOff_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroSmartLight_C.__OnUpdateLightOff_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Time = Time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroSmartLight_C.__OnUpdateLightOff_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06020450 RID: 132176 RVA: 0x00927334 File Offset: 0x00925534
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void OnUpdateLightOff_Implementation(float Time)
		{
			BP_KuroSmartLight_C.__OnUpdateLightOff_FunctionParams* ptr = stackalloc BP_KuroSmartLight_C.__OnUpdateLightOff_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_KuroSmartLight_C.__OnUpdateLightOff_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroSmartLight_C.__OnUpdateLightOff_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Time = Time;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroSmartLight_C.__OnUpdateLightOff_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06020451 RID: 132177 RVA: 0x0092737C File Offset: 0x0092557C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_KuroSmartLight(int EntryPoint)
		{
			BP_KuroSmartLight_C.__ExecuteUbergraph_BP_KuroSmartLight_FunctionParams* ptr = stackalloc BP_KuroSmartLight_C.__ExecuteUbergraph_BP_KuroSmartLight_FunctionParams[(UIntPtr)127] + 15L / (long)sizeof(BP_KuroSmartLight_C.__ExecuteUbergraph_BP_KuroSmartLight_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroSmartLight_C.__ExecuteUbergraph_BP_KuroSmartLight_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroSmartLight_C.__ExecuteUbergraph_BP_KuroSmartLight_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06020452 RID: 132178 RVA: 0x009273C3 File Offset: 0x009255C3
		protected BP_KuroSmartLight_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401018D RID: 65933
		internal static int __InterfaceOffset_IInterface_KuroLightBP;

		// Token: 0x0401018E RID: 65934
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Common/BP_KuroSmartLight.BP_KuroSmartLight_C";

		// Token: 0x0401018F RID: 65935
		private static IntPtr _ClassPtr;

		// Token: 0x04010190 RID: 65936
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04010191 RID: 65937
		internal static int __PropertyOffset_0;

		// Token: 0x04010192 RID: 65938
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04010193 RID: 65939
		internal static int __PropertyOffset_1;

		// Token: 0x04010194 RID: 65940
		internal static int __PropertyOffset_2;

		// Token: 0x04010195 RID: 65941
		internal static int __PropertyOffset_3;

		// Token: 0x04010196 RID: 65942
		internal static int __PropertyOffset_4;

		// Token: 0x04010197 RID: 65943
		private static IntPtr __GetPlacementSortOrder_NativeFunctionPtr;

		// Token: 0x04010198 RID: 65944
		private static IntPtr __OnUpdateLightOn_NativeFunctionPtr;

		// Token: 0x04010199 RID: 65945
		private static IntPtr __OnUpdateLightOff_NativeFunctionPtr;

		// Token: 0x0401019A RID: 65946
		private static IntPtr __ExecuteUbergraph_BP_KuroSmartLight_NativeFunctionPtr;

		// Token: 0x02009985 RID: 39301
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __GetPlacementSortOrder_FunctionParams
		{
			// Token: 0x0403200B RID: 204811
			[FieldOffset(0)]
			public int __Result;
		}

		// Token: 0x02009986 RID: 39302
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __OnUpdateLightOn_FunctionParams
		{
			// Token: 0x0403200C RID: 204812
			[FieldOffset(0)]
			public float Time;
		}

		// Token: 0x02009987 RID: 39303
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __OnUpdateLightOff_FunctionParams
		{
			// Token: 0x0403200D RID: 204813
			[FieldOffset(0)]
			public float Time;
		}

		// Token: 0x02009988 RID: 39304
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 112)]
		protected ref struct __ExecuteUbergraph_BP_KuroSmartLight_FunctionParams
		{
			// Token: 0x0403200E RID: 204814
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
