using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Light
{
	// Token: 0x02003A89 RID: 14985
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Light/BP_KuroLightDecal_Controlled.BP_KuroLightDecal_Controlled_C")]
	[UnrealStructLayout(1328, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1328)]
	public class BP_KuroLightDecal_Controlled_C : AKuroLightActorBase, IUnrealUObject, IUnrealObject, IInterface_KuroLightBP, IUnrealNativeInterface, IUnrealInterface
	{
		// Token: 0x0601F72D RID: 128813 RVA: 0x00911BF8 File Offset: 0x0090FDF8
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_KuroLightDecal_Controlled_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Light/BP_KuroLightDecal_Controlled.BP_KuroLightDecal_Controlled_C");
			}
			return BP_KuroLightDecal_Controlled_C._ClassPtr;
		}

		// Token: 0x0601F72E RID: 128814 RVA: 0x00911C1C File Offset: 0x0090FE1C
		int IInterface_KuroLightBP.InterfaceOffset()
		{
			return BP_KuroLightDecal_Controlled_C.__InterfaceOffset_IInterface_KuroLightBP;
		}

		// Token: 0x0601F72F RID: 128815 RVA: 0x00911C24 File Offset: 0x0090FE24
		public BP_KuroLightDecal_Controlled_C() : this(BuiltinUtils.AllocNativeUObject(BP_KuroLightDecal_Controlled_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601F730 RID: 128816 RVA: 0x00911C4C File Offset: 0x0090FE4C
		[NullableContext(1)]
		public BP_KuroLightDecal_Controlled_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_KuroLightDecal_Controlled_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17002FFD RID: 12285
		// (get) Token: 0x0601F731 RID: 128817 RVA: 0x00911C80 File Offset: 0x0090FE80
		// (set) Token: 0x0601F732 RID: 128818 RVA: 0x00911CB9 File Offset: 0x0090FEB9
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_KuroLightDecal_Controlled_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_KuroLightDecal_Controlled_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17002FFE RID: 12286
		// (get) Token: 0x0601F733 RID: 128819 RVA: 0x00911CDA File Offset: 0x0090FEDA
		// (set) Token: 0x0601F734 RID: 128820 RVA: 0x00911CEE File Offset: 0x0090FEEE
		public unsafe UBillboardComponent Sprite1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBillboardComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroLightDecal_Controlled_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroLightDecal_Controlled_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17002FFF RID: 12287
		// (get) Token: 0x0601F735 RID: 128821 RVA: 0x00911D03 File Offset: 0x0090FF03
		// (set) Token: 0x0601F736 RID: 128822 RVA: 0x00911D17 File Offset: 0x0090FF17
		public unsafe UArrowComponent ArrowComponent1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UArrowComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroLightDecal_Controlled_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroLightDecal_Controlled_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17003000 RID: 12288
		// (get) Token: 0x0601F737 RID: 128823 RVA: 0x00911D2C File Offset: 0x0090FF2C
		// (set) Token: 0x0601F738 RID: 128824 RVA: 0x00911D40 File Offset: 0x0090FF40
		public unsafe UDecalComponent Decal
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UDecalComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroLightDecal_Controlled_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroLightDecal_Controlled_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17003001 RID: 12289
		// (get) Token: 0x0601F739 RID: 128825 RVA: 0x00911D55 File Offset: 0x0090FF55
		// (set) Token: 0x0601F73A RID: 128826 RVA: 0x00911D65 File Offset: 0x0090FF65
		public unsafe float FadeScreenSize
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroLightDecal_Controlled_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroLightDecal_Controlled_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17003002 RID: 12290
		// (get) Token: 0x0601F73B RID: 128827 RVA: 0x00911D76 File Offset: 0x0090FF76
		// (set) Token: 0x0601F73C RID: 128828 RVA: 0x00911D8A File Offset: 0x0090FF8A
		public unsafe UMaterialInstanceConstant DecalMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceConstant>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroLightDecal_Controlled_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroLightDecal_Controlled_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17003003 RID: 12291
		// (get) Token: 0x0601F73D RID: 128829 RVA: 0x00911DA0 File Offset: 0x0090FFA0
		// (set) Token: 0x0601F73E RID: 128830 RVA: 0x00911DD9 File Offset: 0x0090FFD9
		[Nullable(1)]
		public TMap<FName, float> Scalars
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TMap<FName, float> result;
				if ((result = this._Scalars) == null)
				{
					result = (this._Scalars = new TMap<FName, float>(base.NativePtr + (IntPtr)BP_KuroLightDecal_Controlled_C.__PropertyOffset_6, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Scalars.CopyAssign(value);
			}
		}

		// Token: 0x17003004 RID: 12292
		// (get) Token: 0x0601F73F RID: 128831 RVA: 0x00911DE8 File Offset: 0x0090FFE8
		// (set) Token: 0x0601F740 RID: 128832 RVA: 0x00911E21 File Offset: 0x00910021
		[Nullable(1)]
		public TMap<FName, UTexture> Textures
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TMap<FName, UTexture> result;
				if ((result = this._Textures) == null)
				{
					result = (this._Textures = new TMap<FName, UTexture>(base.NativePtr + (IntPtr)BP_KuroLightDecal_Controlled_C.__PropertyOffset_7, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Textures.CopyAssign(value);
			}
		}

		// Token: 0x17003005 RID: 12293
		// (get) Token: 0x0601F741 RID: 128833 RVA: 0x00911E30 File Offset: 0x00910030
		// (set) Token: 0x0601F742 RID: 128834 RVA: 0x00911E69 File Offset: 0x00910069
		[Nullable(1)]
		public TMap<FName, FLinearColor> Vectors
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TMap<FName, FLinearColor> result;
				if ((result = this._Vectors) == null)
				{
					result = (this._Vectors = new TMap<FName, FLinearColor>(base.NativePtr + (IntPtr)BP_KuroLightDecal_Controlled_C.__PropertyOffset_8, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Vectors.CopyAssign(value);
			}
		}

		// Token: 0x0601F743 RID: 128835 RVA: 0x00911E78 File Offset: 0x00910078
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual int GetPlacementSortOrder()
		{
			BP_KuroLightDecal_Controlled_C.__GetPlacementSortOrder_FunctionParams* ptr = stackalloc BP_KuroLightDecal_Controlled_C.__GetPlacementSortOrder_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_KuroLightDecal_Controlled_C.__GetPlacementSortOrder_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroLightDecal_Controlled_C.__GetPlacementSortOrder_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroLightDecal_Controlled_C.__GetPlacementSortOrder_NativeFunctionPtr, (void*)ptr);
			return ptr->__Result;
		}

		// Token: 0x0601F744 RID: 128836 RVA: 0x00911EC0 File Offset: 0x009100C0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual int GetPlacementSortOrder_Implementation()
		{
			BP_KuroLightDecal_Controlled_C.__GetPlacementSortOrder_FunctionParams* ptr = stackalloc BP_KuroLightDecal_Controlled_C.__GetPlacementSortOrder_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_KuroLightDecal_Controlled_C.__GetPlacementSortOrder_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroLightDecal_Controlled_C.__GetPlacementSortOrder_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroLightDecal_Controlled_C.__GetPlacementSortOrder_NativeFunctionPtr, (void*)ptr, 0);
			return ptr->__Result;
		}

		// Token: 0x0601F745 RID: 128837 RVA: 0x00911F06 File Offset: 0x00910106
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void updateMaterialParameters()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroLightDecal_Controlled_C.__updateMaterialParameters_NativeFunctionPtr, null);
		}

		// Token: 0x0601F746 RID: 128838 RVA: 0x00911F1A File Offset: 0x0091011A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroLightDecal_Controlled_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0601F747 RID: 128839 RVA: 0x00911F2E File Offset: 0x0091012E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroLightDecal_Controlled_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601F748 RID: 128840 RVA: 0x00911F44 File Offset: 0x00910144
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void SetLightIntensityScale(float ScaleFactor)
		{
			BP_KuroLightDecal_Controlled_C.__SetLightIntensityScale_FunctionParams* ptr = stackalloc BP_KuroLightDecal_Controlled_C.__SetLightIntensityScale_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_KuroLightDecal_Controlled_C.__SetLightIntensityScale_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroLightDecal_Controlled_C.__SetLightIntensityScale_NativeFunctionPtr, (void*)ptr, 1);
			ptr->ScaleFactor = ScaleFactor;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroLightDecal_Controlled_C.__SetLightIntensityScale_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F749 RID: 128841 RVA: 0x00911F8C File Offset: 0x0091018C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void SetLightIntensityScale_Implementation(float ScaleFactor)
		{
			BP_KuroLightDecal_Controlled_C.__SetLightIntensityScale_FunctionParams* ptr = stackalloc BP_KuroLightDecal_Controlled_C.__SetLightIntensityScale_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_KuroLightDecal_Controlled_C.__SetLightIntensityScale_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroLightDecal_Controlled_C.__SetLightIntensityScale_NativeFunctionPtr, (void*)ptr, 1);
			ptr->ScaleFactor = ScaleFactor;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroLightDecal_Controlled_C.__SetLightIntensityScale_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F74A RID: 128842 RVA: 0x00911FD4 File Offset: 0x009101D4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_KuroLightDecal_Controlled(int EntryPoint)
		{
			BP_KuroLightDecal_Controlled_C.__ExecuteUbergraph_BP_KuroLightDecal_Controlled_FunctionParams* ptr = stackalloc BP_KuroLightDecal_Controlled_C.__ExecuteUbergraph_BP_KuroLightDecal_Controlled_FunctionParams[(UIntPtr)55] + 15L / (long)sizeof(BP_KuroLightDecal_Controlled_C.__ExecuteUbergraph_BP_KuroLightDecal_Controlled_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroLightDecal_Controlled_C.__ExecuteUbergraph_BP_KuroLightDecal_Controlled_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroLightDecal_Controlled_C.__ExecuteUbergraph_BP_KuroLightDecal_Controlled_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F74B RID: 128843 RVA: 0x0091201B File Offset: 0x0091021B
		protected BP_KuroLightDecal_Controlled_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400F9E2 RID: 63970
		internal static int __InterfaceOffset_IInterface_KuroLightBP;

		// Token: 0x0400F9E3 RID: 63971
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Light/BP_KuroLightDecal_Controlled.BP_KuroLightDecal_Controlled_C";

		// Token: 0x0400F9E4 RID: 63972
		private static IntPtr _ClassPtr;

		// Token: 0x0400F9E5 RID: 63973
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400F9E6 RID: 63974
		internal static int __PropertyOffset_0;

		// Token: 0x0400F9E7 RID: 63975
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400F9E8 RID: 63976
		internal static int __PropertyOffset_1;

		// Token: 0x0400F9E9 RID: 63977
		internal static int __PropertyOffset_2;

		// Token: 0x0400F9EA RID: 63978
		internal static int __PropertyOffset_3;

		// Token: 0x0400F9EB RID: 63979
		internal static int __PropertyOffset_4;

		// Token: 0x0400F9EC RID: 63980
		internal static int __PropertyOffset_5;

		// Token: 0x0400F9ED RID: 63981
		internal static int __PropertyOffset_6;

		// Token: 0x0400F9EE RID: 63982
		private TMap<FName, float> _Scalars;

		// Token: 0x0400F9EF RID: 63983
		internal static int __PropertyOffset_7;

		// Token: 0x0400F9F0 RID: 63984
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<FName, UTexture> _Textures;

		// Token: 0x0400F9F1 RID: 63985
		internal static int __PropertyOffset_8;

		// Token: 0x0400F9F2 RID: 63986
		private TMap<FName, FLinearColor> _Vectors;

		// Token: 0x0400F9F3 RID: 63987
		private static IntPtr __GetPlacementSortOrder_NativeFunctionPtr;

		// Token: 0x0400F9F4 RID: 63988
		private static IntPtr __updateMaterialParameters_NativeFunctionPtr;

		// Token: 0x0400F9F5 RID: 63989
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0400F9F6 RID: 63990
		private static IntPtr __SetLightIntensityScale_NativeFunctionPtr;

		// Token: 0x0400F9F7 RID: 63991
		private static IntPtr __ExecuteUbergraph_BP_KuroLightDecal_Controlled_NativeFunctionPtr;

		// Token: 0x020098DE RID: 39134
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __GetPlacementSortOrder_FunctionParams
		{
			// Token: 0x04031F33 RID: 204595
			[FieldOffset(0)]
			public int __Result;
		}

		// Token: 0x020098DF RID: 39135
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __SetLightIntensityScale_FunctionParams
		{
			// Token: 0x04031F34 RID: 204596
			[FieldOffset(0)]
			public float ScaleFactor;
		}

		// Token: 0x020098E0 RID: 39136
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 40)]
		protected ref struct __ExecuteUbergraph_BP_KuroLightDecal_Controlled_FunctionParams
		{
			// Token: 0x04031F35 RID: 204597
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
