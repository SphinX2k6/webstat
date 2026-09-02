using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Light
{
	// Token: 0x02003A87 RID: 14983
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Light/BP_KuroLightDecal.BP_KuroLightDecal_C")]
	[UnrealStructLayout(1328, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1328)]
	public class BP_KuroLightDecal_C : ADecalActor, IUnrealUObject, IUnrealObject, IInterface_KuroLightBP, IUnrealNativeInterface, IUnrealInterface
	{
		// Token: 0x0601F70D RID: 128781 RVA: 0x0091186B File Offset: 0x0090FA6B
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_KuroLightDecal_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Light/BP_KuroLightDecal.BP_KuroLightDecal_C");
			}
			return BP_KuroLightDecal_C._ClassPtr;
		}

		// Token: 0x0601F70E RID: 128782 RVA: 0x0091188F File Offset: 0x0090FA8F
		int IInterface_KuroLightBP.InterfaceOffset()
		{
			return BP_KuroLightDecal_C.__InterfaceOffset_IInterface_KuroLightBP;
		}

		// Token: 0x0601F70F RID: 128783 RVA: 0x00911898 File Offset: 0x0090FA98
		public BP_KuroLightDecal_C() : this(BuiltinUtils.AllocNativeUObject(BP_KuroLightDecal_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601F710 RID: 128784 RVA: 0x009118C0 File Offset: 0x0090FAC0
		public BP_KuroLightDecal_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_KuroLightDecal_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17002FF4 RID: 12276
		// (get) Token: 0x0601F711 RID: 128785 RVA: 0x009118F3 File Offset: 0x0090FAF3
		// (set) Token: 0x0601F712 RID: 128786 RVA: 0x00911903 File Offset: 0x0090FB03
		public unsafe float FadeScreenSize
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroLightDecal_C.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroLightDecal_C.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17002FF5 RID: 12277
		// (get) Token: 0x0601F713 RID: 128787 RVA: 0x00911914 File Offset: 0x0090FB14
		// (set) Token: 0x0601F714 RID: 128788 RVA: 0x00911928 File Offset: 0x0090FB28
		[Nullable(2)]
		public unsafe UMaterialInstanceConstant DecalMaterial
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceConstant>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroLightDecal_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroLightDecal_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17002FF6 RID: 12278
		// (get) Token: 0x0601F715 RID: 128789 RVA: 0x00911940 File Offset: 0x0090FB40
		// (set) Token: 0x0601F716 RID: 128790 RVA: 0x00911979 File Offset: 0x0090FB79
		public TMap<FName, float> Scalars
		{
			get
			{
				base.FastCheckIsValid();
				TMap<FName, float> result;
				if ((result = this._Scalars) == null)
				{
					result = (this._Scalars = new TMap<FName, float>(base.NativePtr + (IntPtr)BP_KuroLightDecal_C.__PropertyOffset_2, this));
				}
				return result;
			}
			set
			{
				this.Scalars.CopyAssign(value);
			}
		}

		// Token: 0x17002FF7 RID: 12279
		// (get) Token: 0x0601F717 RID: 128791 RVA: 0x00911988 File Offset: 0x0090FB88
		// (set) Token: 0x0601F718 RID: 128792 RVA: 0x009119C1 File Offset: 0x0090FBC1
		public TMap<FName, UTexture> Textures
		{
			get
			{
				base.FastCheckIsValid();
				TMap<FName, UTexture> result;
				if ((result = this._Textures) == null)
				{
					result = (this._Textures = new TMap<FName, UTexture>(base.NativePtr + (IntPtr)BP_KuroLightDecal_C.__PropertyOffset_3, this));
				}
				return result;
			}
			set
			{
				this.Textures.CopyAssign(value);
			}
		}

		// Token: 0x17002FF8 RID: 12280
		// (get) Token: 0x0601F719 RID: 128793 RVA: 0x009119D0 File Offset: 0x0090FBD0
		// (set) Token: 0x0601F71A RID: 128794 RVA: 0x00911A09 File Offset: 0x0090FC09
		public TMap<FName, FLinearColor> Vectors
		{
			get
			{
				base.FastCheckIsValid();
				TMap<FName, FLinearColor> result;
				if ((result = this._Vectors) == null)
				{
					result = (this._Vectors = new TMap<FName, FLinearColor>(base.NativePtr + (IntPtr)BP_KuroLightDecal_C.__PropertyOffset_4, this));
				}
				return result;
			}
			set
			{
				this.Vectors.CopyAssign(value);
			}
		}

		// Token: 0x17002FF9 RID: 12281
		// (get) Token: 0x0601F71B RID: 128795 RVA: 0x00911A17 File Offset: 0x0090FC17
		// (set) Token: 0x0601F71C RID: 128796 RVA: 0x00911A27 File Offset: 0x0090FC27
		public unsafe float 最小显示距离
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroLightDecal_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroLightDecal_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17002FFA RID: 12282
		// (get) Token: 0x0601F71D RID: 128797 RVA: 0x00911A38 File Offset: 0x0090FC38
		// (set) Token: 0x0601F71E RID: 128798 RVA: 0x00911A48 File Offset: 0x0090FC48
		public unsafe float 最大显示距离
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroLightDecal_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroLightDecal_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17002FFB RID: 12283
		// (get) Token: 0x0601F71F RID: 128799 RVA: 0x00911A59 File Offset: 0x0090FC59
		// (set) Token: 0x0601F720 RID: 128800 RVA: 0x00911A69 File Offset: 0x0090FC69
		public unsafe float 最小Fade距离
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroLightDecal_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroLightDecal_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17002FFC RID: 12284
		// (get) Token: 0x0601F721 RID: 128801 RVA: 0x00911A7A File Offset: 0x0090FC7A
		// (set) Token: 0x0601F722 RID: 128802 RVA: 0x00911A8A File Offset: 0x0090FC8A
		public unsafe float 最大Fade距离
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroLightDecal_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroLightDecal_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x0601F723 RID: 128803 RVA: 0x00911A9C File Offset: 0x0090FC9C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual int GetPlacementSortOrder()
		{
			BP_KuroLightDecal_C.__GetPlacementSortOrder_FunctionParams* ptr = stackalloc BP_KuroLightDecal_C.__GetPlacementSortOrder_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_KuroLightDecal_C.__GetPlacementSortOrder_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroLightDecal_C.__GetPlacementSortOrder_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroLightDecal_C.__GetPlacementSortOrder_NativeFunctionPtr, (void*)ptr);
			return ptr->__Result;
		}

		// Token: 0x0601F724 RID: 128804 RVA: 0x00911AE4 File Offset: 0x0090FCE4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual int GetPlacementSortOrder_Implementation()
		{
			BP_KuroLightDecal_C.__GetPlacementSortOrder_FunctionParams* ptr = stackalloc BP_KuroLightDecal_C.__GetPlacementSortOrder_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_KuroLightDecal_C.__GetPlacementSortOrder_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroLightDecal_C.__GetPlacementSortOrder_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroLightDecal_C.__GetPlacementSortOrder_NativeFunctionPtr, (void*)ptr, 0);
			return ptr->__Result;
		}

		// Token: 0x0601F725 RID: 128805 RVA: 0x00911B2A File Offset: 0x0090FD2A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void updateMaterialParameters()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroLightDecal_C.__updateMaterialParameters_NativeFunctionPtr, null);
		}

		// Token: 0x0601F726 RID: 128806 RVA: 0x00911B3E File Offset: 0x0090FD3E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroLightDecal_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0601F727 RID: 128807 RVA: 0x00911B52 File Offset: 0x0090FD52
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroLightDecal_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601F728 RID: 128808 RVA: 0x00911B67 File Offset: 0x0090FD67
		protected BP_KuroLightDecal_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400F9CC RID: 63948
		internal static int __InterfaceOffset_IInterface_KuroLightBP;

		// Token: 0x0400F9CD RID: 63949
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Light/BP_KuroLightDecal.BP_KuroLightDecal_C";

		// Token: 0x0400F9CE RID: 63950
		private static IntPtr _ClassPtr;

		// Token: 0x0400F9CF RID: 63951
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400F9D0 RID: 63952
		internal static int __PropertyOffset_0;

		// Token: 0x0400F9D1 RID: 63953
		internal static int __PropertyOffset_1;

		// Token: 0x0400F9D2 RID: 63954
		internal static int __PropertyOffset_2;

		// Token: 0x0400F9D3 RID: 63955
		[Nullable(2)]
		private TMap<FName, float> _Scalars;

		// Token: 0x0400F9D4 RID: 63956
		internal static int __PropertyOffset_3;

		// Token: 0x0400F9D5 RID: 63957
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<FName, UTexture> _Textures;

		// Token: 0x0400F9D6 RID: 63958
		internal static int __PropertyOffset_4;

		// Token: 0x0400F9D7 RID: 63959
		[Nullable(2)]
		private TMap<FName, FLinearColor> _Vectors;

		// Token: 0x0400F9D8 RID: 63960
		internal static int __PropertyOffset_5;

		// Token: 0x0400F9D9 RID: 63961
		internal static int __PropertyOffset_6;

		// Token: 0x0400F9DA RID: 63962
		internal static int __PropertyOffset_7;

		// Token: 0x0400F9DB RID: 63963
		internal static int __PropertyOffset_8;

		// Token: 0x0400F9DC RID: 63964
		private static IntPtr __GetPlacementSortOrder_NativeFunctionPtr;

		// Token: 0x0400F9DD RID: 63965
		private static IntPtr __updateMaterialParameters_NativeFunctionPtr;

		// Token: 0x0400F9DE RID: 63966
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x020098DD RID: 39133
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __GetPlacementSortOrder_FunctionParams
		{
			// Token: 0x04031F32 RID: 204594
			[FieldOffset(0)]
			public int __Result;
		}
	}
}
