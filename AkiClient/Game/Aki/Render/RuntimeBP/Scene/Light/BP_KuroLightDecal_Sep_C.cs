using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Light
{
	// Token: 0x02003A8A RID: 14986
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Light/BP_KuroLightDecal_Sep.BP_KuroLightDecal_Sep_C")]
	[UnrealStructLayout(1392, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1392)]
	public class BP_KuroLightDecal_Sep_C : ADecalActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601F74C RID: 128844 RVA: 0x00912024 File Offset: 0x00910224
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_KuroLightDecal_Sep_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Light/BP_KuroLightDecal_Sep.BP_KuroLightDecal_Sep_C");
			}
			return BP_KuroLightDecal_Sep_C._ClassPtr;
		}

		// Token: 0x0601F74D RID: 128845 RVA: 0x00912048 File Offset: 0x00910248
		public BP_KuroLightDecal_Sep_C() : this(BuiltinUtils.AllocNativeUObject(BP_KuroLightDecal_Sep_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601F74E RID: 128846 RVA: 0x00912070 File Offset: 0x00910270
		public BP_KuroLightDecal_Sep_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_KuroLightDecal_Sep_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003006 RID: 12294
		// (get) Token: 0x0601F74F RID: 128847 RVA: 0x009120A3 File Offset: 0x009102A3
		// (set) Token: 0x0601F750 RID: 128848 RVA: 0x009120B3 File Offset: 0x009102B3
		public unsafe float FadeScreenSize
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroLightDecal_Sep_C.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroLightDecal_Sep_C.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17003007 RID: 12295
		// (get) Token: 0x0601F751 RID: 128849 RVA: 0x009120C4 File Offset: 0x009102C4
		// (set) Token: 0x0601F752 RID: 128850 RVA: 0x009120D8 File Offset: 0x009102D8
		[Nullable(2)]
		public unsafe UMaterialInstanceConstant DecalMaterial
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceConstant>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroLightDecal_Sep_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroLightDecal_Sep_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17003008 RID: 12296
		// (get) Token: 0x0601F753 RID: 128851 RVA: 0x009120F0 File Offset: 0x009102F0
		// (set) Token: 0x0601F754 RID: 128852 RVA: 0x00912129 File Offset: 0x00910329
		public TMap<FName, float> Scalars
		{
			get
			{
				base.FastCheckIsValid();
				TMap<FName, float> result;
				if ((result = this._Scalars) == null)
				{
					result = (this._Scalars = new TMap<FName, float>(base.NativePtr + (IntPtr)BP_KuroLightDecal_Sep_C.__PropertyOffset_2, this));
				}
				return result;
			}
			set
			{
				this.Scalars.CopyAssign(value);
			}
		}

		// Token: 0x17003009 RID: 12297
		// (get) Token: 0x0601F755 RID: 128853 RVA: 0x00912138 File Offset: 0x00910338
		// (set) Token: 0x0601F756 RID: 128854 RVA: 0x00912171 File Offset: 0x00910371
		public TMap<FName, UTexture> Textures
		{
			get
			{
				base.FastCheckIsValid();
				TMap<FName, UTexture> result;
				if ((result = this._Textures) == null)
				{
					result = (this._Textures = new TMap<FName, UTexture>(base.NativePtr + (IntPtr)BP_KuroLightDecal_Sep_C.__PropertyOffset_3, this));
				}
				return result;
			}
			set
			{
				this.Textures.CopyAssign(value);
			}
		}

		// Token: 0x1700300A RID: 12298
		// (get) Token: 0x0601F757 RID: 128855 RVA: 0x00912180 File Offset: 0x00910380
		// (set) Token: 0x0601F758 RID: 128856 RVA: 0x009121B9 File Offset: 0x009103B9
		public TMap<FName, FLinearColor> Vectors
		{
			get
			{
				base.FastCheckIsValid();
				TMap<FName, FLinearColor> result;
				if ((result = this._Vectors) == null)
				{
					result = (this._Vectors = new TMap<FName, FLinearColor>(base.NativePtr + (IntPtr)BP_KuroLightDecal_Sep_C.__PropertyOffset_4, this));
				}
				return result;
			}
			set
			{
				this.Vectors.CopyAssign(value);
			}
		}

		// Token: 0x1700300B RID: 12299
		// (get) Token: 0x0601F759 RID: 128857 RVA: 0x009121C7 File Offset: 0x009103C7
		// (set) Token: 0x0601F75A RID: 128858 RVA: 0x009121D7 File Offset: 0x009103D7
		public unsafe float MainTili
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroLightDecal_Sep_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroLightDecal_Sep_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x1700300C RID: 12300
		// (get) Token: 0x0601F75B RID: 128859 RVA: 0x009121E8 File Offset: 0x009103E8
		// (set) Token: 0x0601F75C RID: 128860 RVA: 0x009121F8 File Offset: 0x009103F8
		public unsafe float Contrast
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroLightDecal_Sep_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroLightDecal_Sep_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x1700300D RID: 12301
		// (get) Token: 0x0601F75D RID: 128861 RVA: 0x00912209 File Offset: 0x00910409
		// (set) Token: 0x0601F75E RID: 128862 RVA: 0x00912219 File Offset: 0x00910419
		public unsafe float EmissiveIntensty
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroLightDecal_Sep_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroLightDecal_Sep_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x1700300E RID: 12302
		// (get) Token: 0x0601F75F RID: 128863 RVA: 0x0091222A File Offset: 0x0091042A
		// (set) Token: 0x0601F760 RID: 128864 RVA: 0x0091223A File Offset: 0x0091043A
		public unsafe float MainSpeed_X
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroLightDecal_Sep_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroLightDecal_Sep_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x1700300F RID: 12303
		// (get) Token: 0x0601F761 RID: 128865 RVA: 0x0091224B File Offset: 0x0091044B
		// (set) Token: 0x0601F762 RID: 128866 RVA: 0x0091225B File Offset: 0x0091045B
		public unsafe float MainSpeed_Y
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroLightDecal_Sep_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroLightDecal_Sep_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17003010 RID: 12304
		// (get) Token: 0x0601F763 RID: 128867 RVA: 0x0091226C File Offset: 0x0091046C
		// (set) Token: 0x0601F764 RID: 128868 RVA: 0x0091227C File Offset: 0x0091047C
		public unsafe float NoiseScale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroLightDecal_Sep_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroLightDecal_Sep_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17003011 RID: 12305
		// (get) Token: 0x0601F765 RID: 128869 RVA: 0x0091228D File Offset: 0x0091048D
		// (set) Token: 0x0601F766 RID: 128870 RVA: 0x0091229D File Offset: 0x0091049D
		public unsafe float NoiseIntensty
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroLightDecal_Sep_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroLightDecal_Sep_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17003012 RID: 12306
		// (get) Token: 0x0601F767 RID: 128871 RVA: 0x009122AE File Offset: 0x009104AE
		// (set) Token: 0x0601F768 RID: 128872 RVA: 0x009122BE File Offset: 0x009104BE
		public unsafe float NoiseAmount
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroLightDecal_Sep_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroLightDecal_Sep_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17003013 RID: 12307
		// (get) Token: 0x0601F769 RID: 128873 RVA: 0x009122CF File Offset: 0x009104CF
		// (set) Token: 0x0601F76A RID: 128874 RVA: 0x009122DF File Offset: 0x009104DF
		public unsafe float NoiseSpeed_X
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroLightDecal_Sep_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroLightDecal_Sep_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17003014 RID: 12308
		// (get) Token: 0x0601F76B RID: 128875 RVA: 0x009122F0 File Offset: 0x009104F0
		// (set) Token: 0x0601F76C RID: 128876 RVA: 0x00912300 File Offset: 0x00910500
		public unsafe float NoiseSpeed_Y
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroLightDecal_Sep_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroLightDecal_Sep_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x17003015 RID: 12309
		// (get) Token: 0x0601F76D RID: 128877 RVA: 0x00912311 File Offset: 0x00910511
		// (set) Token: 0x0601F76E RID: 128878 RVA: 0x00912321 File Offset: 0x00910521
		public unsafe float NoisePanX
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroLightDecal_Sep_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroLightDecal_Sep_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x17003016 RID: 12310
		// (get) Token: 0x0601F76F RID: 128879 RVA: 0x00912332 File Offset: 0x00910532
		// (set) Token: 0x0601F770 RID: 128880 RVA: 0x00912342 File Offset: 0x00910542
		public unsafe float NoisePanY
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroLightDecal_Sep_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroLightDecal_Sep_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x17003017 RID: 12311
		// (get) Token: 0x0601F771 RID: 128881 RVA: 0x00912353 File Offset: 0x00910553
		// (set) Token: 0x0601F772 RID: 128882 RVA: 0x00912367 File Offset: 0x00910567
		[Nullable(2)]
		public unsafe UTexture Noise
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroLightDecal_Sep_C.__PropertyOffset_17);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroLightDecal_Sep_C.__PropertyOffset_17, value);
			}
		}

		// Token: 0x17003018 RID: 12312
		// (get) Token: 0x0601F773 RID: 128883 RVA: 0x0091237C File Offset: 0x0091057C
		// (set) Token: 0x0601F774 RID: 128884 RVA: 0x00912390 File Offset: 0x00910590
		[Nullable(2)]
		public unsafe UTexture MainTex
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroLightDecal_Sep_C.__PropertyOffset_18);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroLightDecal_Sep_C.__PropertyOffset_18, value);
			}
		}

		// Token: 0x17003019 RID: 12313
		// (get) Token: 0x0601F775 RID: 128885 RVA: 0x009123A5 File Offset: 0x009105A5
		// (set) Token: 0x0601F776 RID: 128886 RVA: 0x009123B9 File Offset: 0x009105B9
		public unsafe FLinearColor ColorTint
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroLightDecal_Sep_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroLightDecal_Sep_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x0601F777 RID: 128887 RVA: 0x009123CE File Offset: 0x009105CE
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void updateMaterialParameters()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroLightDecal_Sep_C.__updateMaterialParameters_NativeFunctionPtr, null);
		}

		// Token: 0x0601F778 RID: 128888 RVA: 0x009123E2 File Offset: 0x009105E2
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroLightDecal_Sep_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0601F779 RID: 128889 RVA: 0x009123F6 File Offset: 0x009105F6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroLightDecal_Sep_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601F77A RID: 128890 RVA: 0x0091240B File Offset: 0x0091060B
		protected BP_KuroLightDecal_Sep_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400F9F8 RID: 63992
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Light/BP_KuroLightDecal_Sep.BP_KuroLightDecal_Sep_C";

		// Token: 0x0400F9F9 RID: 63993
		private static IntPtr _ClassPtr;

		// Token: 0x0400F9FA RID: 63994
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400F9FB RID: 63995
		internal static int __PropertyOffset_0;

		// Token: 0x0400F9FC RID: 63996
		internal static int __PropertyOffset_1;

		// Token: 0x0400F9FD RID: 63997
		internal static int __PropertyOffset_2;

		// Token: 0x0400F9FE RID: 63998
		[Nullable(2)]
		private TMap<FName, float> _Scalars;

		// Token: 0x0400F9FF RID: 63999
		internal static int __PropertyOffset_3;

		// Token: 0x0400FA00 RID: 64000
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<FName, UTexture> _Textures;

		// Token: 0x0400FA01 RID: 64001
		internal static int __PropertyOffset_4;

		// Token: 0x0400FA02 RID: 64002
		[Nullable(2)]
		private TMap<FName, FLinearColor> _Vectors;

		// Token: 0x0400FA03 RID: 64003
		internal static int __PropertyOffset_5;

		// Token: 0x0400FA04 RID: 64004
		internal static int __PropertyOffset_6;

		// Token: 0x0400FA05 RID: 64005
		internal static int __PropertyOffset_7;

		// Token: 0x0400FA06 RID: 64006
		internal static int __PropertyOffset_8;

		// Token: 0x0400FA07 RID: 64007
		internal static int __PropertyOffset_9;

		// Token: 0x0400FA08 RID: 64008
		internal static int __PropertyOffset_10;

		// Token: 0x0400FA09 RID: 64009
		internal static int __PropertyOffset_11;

		// Token: 0x0400FA0A RID: 64010
		internal static int __PropertyOffset_12;

		// Token: 0x0400FA0B RID: 64011
		internal static int __PropertyOffset_13;

		// Token: 0x0400FA0C RID: 64012
		internal static int __PropertyOffset_14;

		// Token: 0x0400FA0D RID: 64013
		internal static int __PropertyOffset_15;

		// Token: 0x0400FA0E RID: 64014
		internal static int __PropertyOffset_16;

		// Token: 0x0400FA0F RID: 64015
		internal static int __PropertyOffset_17;

		// Token: 0x0400FA10 RID: 64016
		internal static int __PropertyOffset_18;

		// Token: 0x0400FA11 RID: 64017
		internal static int __PropertyOffset_19;

		// Token: 0x0400FA12 RID: 64018
		private static IntPtr __updateMaterialParameters_NativeFunctionPtr;

		// Token: 0x0400FA13 RID: 64019
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;
	}
}
