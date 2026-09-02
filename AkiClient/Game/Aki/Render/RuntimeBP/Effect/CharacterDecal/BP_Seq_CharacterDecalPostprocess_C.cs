using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Effect.CharacterDecal
{
	// Token: 0x02003D4A RID: 15690
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Effect/CharacterDecal/BP_Seq_CharacterDecalPostprocess.BP_Seq_CharacterDecalPostprocess_C")]
	[UnrealStructLayout(1760, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1760)]
	public class BP_Seq_CharacterDecalPostprocess_C : AKuroEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06026137 RID: 155959 RVA: 0x009CD44A File Offset: 0x009CB64A
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_Seq_CharacterDecalPostprocess_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Effect/CharacterDecal/BP_Seq_CharacterDecalPostprocess.BP_Seq_CharacterDecalPostprocess_C");
			}
			return BP_Seq_CharacterDecalPostprocess_C._ClassPtr;
		}

		// Token: 0x06026138 RID: 155960 RVA: 0x009CD470 File Offset: 0x009CB670
		public BP_Seq_CharacterDecalPostprocess_C() : this(BuiltinUtils.AllocNativeUObject(BP_Seq_CharacterDecalPostprocess_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06026139 RID: 155961 RVA: 0x009CD498 File Offset: 0x009CB698
		[NullableContext(1)]
		public BP_Seq_CharacterDecalPostprocess_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_Seq_CharacterDecalPostprocess_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17005555 RID: 21845
		// (get) Token: 0x0602613A RID: 155962 RVA: 0x009CD4CC File Offset: 0x009CB6CC
		// (set) Token: 0x0602613B RID: 155963 RVA: 0x009CD505 File Offset: 0x009CB705
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_Seq_CharacterDecalPostprocess_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_Seq_CharacterDecalPostprocess_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005556 RID: 21846
		// (get) Token: 0x0602613C RID: 155964 RVA: 0x009CD526 File Offset: 0x009CB726
		// (set) Token: 0x0602613D RID: 155965 RVA: 0x009CD53A File Offset: 0x009CB73A
		public unsafe UKuroPostProcessComponent KuroPostProcess
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroPostProcessComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Seq_CharacterDecalPostprocess_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Seq_CharacterDecalPostprocess_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17005557 RID: 21847
		// (get) Token: 0x0602613E RID: 155966 RVA: 0x009CD54F File Offset: 0x009CB74F
		// (set) Token: 0x0602613F RID: 155967 RVA: 0x009CD563 File Offset: 0x009CB763
		public unsafe UArrowComponent Arrow
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UArrowComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Seq_CharacterDecalPostprocess_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Seq_CharacterDecalPostprocess_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17005558 RID: 21848
		// (get) Token: 0x06026140 RID: 155968 RVA: 0x009CD578 File Offset: 0x009CB778
		// (set) Token: 0x06026141 RID: 155969 RVA: 0x009CD58C File Offset: 0x009CB78C
		public unsafe USphereComponent Sphere
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USphereComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Seq_CharacterDecalPostprocess_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Seq_CharacterDecalPostprocess_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17005559 RID: 21849
		// (get) Token: 0x06026142 RID: 155970 RVA: 0x009CD5A1 File Offset: 0x009CB7A1
		// (set) Token: 0x06026143 RID: 155971 RVA: 0x009CD5B5 File Offset: 0x009CB7B5
		public unsafe UMaterialInterface MainMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInterface>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Seq_CharacterDecalPostprocess_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Seq_CharacterDecalPostprocess_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x1700555A RID: 21850
		// (get) Token: 0x06026144 RID: 155972 RVA: 0x009CD5CA File Offset: 0x009CB7CA
		// (set) Token: 0x06026145 RID: 155973 RVA: 0x009CD5DE File Offset: 0x009CB7DE
		public unsafe UTexture BaseTexture
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Seq_CharacterDecalPostprocess_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Seq_CharacterDecalPostprocess_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x1700555B RID: 21851
		// (get) Token: 0x06026146 RID: 155974 RVA: 0x009CD5F3 File Offset: 0x009CB7F3
		// (set) Token: 0x06026147 RID: 155975 RVA: 0x009CD607 File Offset: 0x009CB807
		public unsafe FLinearColor BaseTexEmissiveChannel
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Seq_CharacterDecalPostprocess_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Seq_CharacterDecalPostprocess_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x1700555C RID: 21852
		// (get) Token: 0x06026148 RID: 155976 RVA: 0x009CD61C File Offset: 0x009CB81C
		// (set) Token: 0x06026149 RID: 155977 RVA: 0x009CD630 File Offset: 0x009CB830
		public unsafe FLinearColor BaseTexAlphaChannel
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Seq_CharacterDecalPostprocess_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Seq_CharacterDecalPostprocess_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x1700555D RID: 21853
		// (get) Token: 0x0602614A RID: 155978 RVA: 0x009CD645 File Offset: 0x009CB845
		// (set) Token: 0x0602614B RID: 155979 RVA: 0x009CD659 File Offset: 0x009CB859
		public unsafe FLinearColor BaseTexColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Seq_CharacterDecalPostprocess_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Seq_CharacterDecalPostprocess_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x1700555E RID: 21854
		// (get) Token: 0x0602614C RID: 155980 RVA: 0x009CD66E File Offset: 0x009CB86E
		// (set) Token: 0x0602614D RID: 155981 RVA: 0x009CD67E File Offset: 0x009CB87E
		public unsafe float BaseTex_UseChannelAsEmissive
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Seq_CharacterDecalPostprocess_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Seq_CharacterDecalPostprocess_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x1700555F RID: 21855
		// (get) Token: 0x0602614E RID: 155982 RVA: 0x009CD68F File Offset: 0x009CB88F
		// (set) Token: 0x0602614F RID: 155983 RVA: 0x009CD69F File Offset: 0x009CB89F
		public unsafe float BaseTexDesaturation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Seq_CharacterDecalPostprocess_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Seq_CharacterDecalPostprocess_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17005560 RID: 21856
		// (get) Token: 0x06026150 RID: 155984 RVA: 0x009CD6B0 File Offset: 0x009CB8B0
		// (set) Token: 0x06026151 RID: 155985 RVA: 0x009CD6C0 File Offset: 0x009CB8C0
		public unsafe float BaseTexIntensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Seq_CharacterDecalPostprocess_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Seq_CharacterDecalPostprocess_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17005561 RID: 21857
		// (get) Token: 0x06026152 RID: 155986 RVA: 0x009CD6D1 File Offset: 0x009CB8D1
		// (set) Token: 0x06026153 RID: 155987 RVA: 0x009CD6E1 File Offset: 0x009CB8E1
		public unsafe float BaseTex_Alpha
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Seq_CharacterDecalPostprocess_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Seq_CharacterDecalPostprocess_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17005562 RID: 21858
		// (get) Token: 0x06026154 RID: 155988 RVA: 0x009CD6F2 File Offset: 0x009CB8F2
		// (set) Token: 0x06026155 RID: 155989 RVA: 0x009CD702 File Offset: 0x009CB902
		public unsafe float BaseTex_U_Scale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Seq_CharacterDecalPostprocess_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Seq_CharacterDecalPostprocess_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17005563 RID: 21859
		// (get) Token: 0x06026156 RID: 155990 RVA: 0x009CD713 File Offset: 0x009CB913
		// (set) Token: 0x06026157 RID: 155991 RVA: 0x009CD723 File Offset: 0x009CB923
		public unsafe float BaseTex_V_Scale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Seq_CharacterDecalPostprocess_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Seq_CharacterDecalPostprocess_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x17005564 RID: 21860
		// (get) Token: 0x06026158 RID: 155992 RVA: 0x009CD734 File Offset: 0x009CB934
		// (set) Token: 0x06026159 RID: 155993 RVA: 0x009CD744 File Offset: 0x009CB944
		public unsafe float BaseTex_V_Pos
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Seq_CharacterDecalPostprocess_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Seq_CharacterDecalPostprocess_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x17005565 RID: 21861
		// (get) Token: 0x0602615A RID: 155994 RVA: 0x009CD755 File Offset: 0x009CB955
		// (set) Token: 0x0602615B RID: 155995 RVA: 0x009CD765 File Offset: 0x009CB965
		public unsafe float BaseTex_U_Pos
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Seq_CharacterDecalPostprocess_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Seq_CharacterDecalPostprocess_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x17005566 RID: 21862
		// (get) Token: 0x0602615C RID: 155996 RVA: 0x009CD776 File Offset: 0x009CB976
		// (set) Token: 0x0602615D RID: 155997 RVA: 0x009CD786 File Offset: 0x009CB986
		public unsafe float BaseTexUClamp
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Seq_CharacterDecalPostprocess_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Seq_CharacterDecalPostprocess_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x17005567 RID: 21863
		// (get) Token: 0x0602615E RID: 155998 RVA: 0x009CD797 File Offset: 0x009CB997
		// (set) Token: 0x0602615F RID: 155999 RVA: 0x009CD7A7 File Offset: 0x009CB9A7
		public unsafe float BaseTexVClamp
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Seq_CharacterDecalPostprocess_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Seq_CharacterDecalPostprocess_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x17005568 RID: 21864
		// (get) Token: 0x06026160 RID: 156000 RVA: 0x009CD7B8 File Offset: 0x009CB9B8
		// (set) Token: 0x06026161 RID: 156001 RVA: 0x009CD7CC File Offset: 0x009CB9CC
		public unsafe UTexture DissolveTex
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Seq_CharacterDecalPostprocess_C.__PropertyOffset_19);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Seq_CharacterDecalPostprocess_C.__PropertyOffset_19, value);
			}
		}

		// Token: 0x17005569 RID: 21865
		// (get) Token: 0x06026162 RID: 156002 RVA: 0x009CD7E1 File Offset: 0x009CB9E1
		// (set) Token: 0x06026163 RID: 156003 RVA: 0x009CD7F5 File Offset: 0x009CB9F5
		public unsafe FLinearColor DissolveTexChannel
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Seq_CharacterDecalPostprocess_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Seq_CharacterDecalPostprocess_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x1700556A RID: 21866
		// (get) Token: 0x06026164 RID: 156004 RVA: 0x009CD80A File Offset: 0x009CBA0A
		// (set) Token: 0x06026165 RID: 156005 RVA: 0x009CD81A File Offset: 0x009CBA1A
		public unsafe float Dissolve_Progress
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Seq_CharacterDecalPostprocess_C.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Seq_CharacterDecalPostprocess_C.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x1700556B RID: 21867
		// (get) Token: 0x06026166 RID: 156006 RVA: 0x009CD82B File Offset: 0x009CBA2B
		// (set) Token: 0x06026167 RID: 156007 RVA: 0x009CD83B File Offset: 0x009CBA3B
		public unsafe float Dissolve_Smooth
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Seq_CharacterDecalPostprocess_C.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Seq_CharacterDecalPostprocess_C.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x1700556C RID: 21868
		// (get) Token: 0x06026168 RID: 156008 RVA: 0x009CD84C File Offset: 0x009CBA4C
		// (set) Token: 0x06026169 RID: 156009 RVA: 0x009CD860 File Offset: 0x009CBA60
		public unsafe FLinearColor Dissolve_EdgeColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Seq_CharacterDecalPostprocess_C.__PropertyOffset_23);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Seq_CharacterDecalPostprocess_C.__PropertyOffset_23) = value;
			}
		}

		// Token: 0x1700556D RID: 21869
		// (get) Token: 0x0602616A RID: 156010 RVA: 0x009CD875 File Offset: 0x009CBA75
		// (set) Token: 0x0602616B RID: 156011 RVA: 0x009CD885 File Offset: 0x009CBA85
		public unsafe float Dissolve_EdgeStrength
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Seq_CharacterDecalPostprocess_C.__PropertyOffset_24);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Seq_CharacterDecalPostprocess_C.__PropertyOffset_24) = value;
			}
		}

		// Token: 0x1700556E RID: 21870
		// (get) Token: 0x0602616C RID: 156012 RVA: 0x009CD896 File Offset: 0x009CBA96
		// (set) Token: 0x0602616D RID: 156013 RVA: 0x009CD8AA File Offset: 0x009CBAAA
		public unsafe UMaterialInstanceDynamic DynamicMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Seq_CharacterDecalPostprocess_C.__PropertyOffset_25);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Seq_CharacterDecalPostprocess_C.__PropertyOffset_25, value);
			}
		}

		// Token: 0x1700556F RID: 21871
		// (get) Token: 0x0602616E RID: 156014 RVA: 0x009CD8BF File Offset: 0x009CBABF
		// (set) Token: 0x0602616F RID: 156015 RVA: 0x009CD8CF File Offset: 0x009CBACF
		public unsafe bool 不选中时允许编辑器Tick
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Seq_CharacterDecalPostprocess_C.__PropertyOffset_26) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Seq_CharacterDecalPostprocess_C.__PropertyOffset_26) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005570 RID: 21872
		// (get) Token: 0x06026170 RID: 156016 RVA: 0x009CD8E0 File Offset: 0x009CBAE0
		// (set) Token: 0x06026171 RID: 156017 RVA: 0x009CD919 File Offset: 0x009CBB19
		[Nullable(1)]
		public TMap<FName, float> Scalar_Parameters
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TMap<FName, float> result;
				if ((result = this._Scalar_Parameters) == null)
				{
					result = (this._Scalar_Parameters = new TMap<FName, float>(base.NativePtr + (IntPtr)BP_Seq_CharacterDecalPostprocess_C.__PropertyOffset_27, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Scalar_Parameters.CopyAssign(value);
			}
		}

		// Token: 0x17005571 RID: 21873
		// (get) Token: 0x06026172 RID: 156018 RVA: 0x009CD928 File Offset: 0x009CBB28
		// (set) Token: 0x06026173 RID: 156019 RVA: 0x009CD961 File Offset: 0x009CBB61
		[Nullable(1)]
		public TMap<FName, FLinearColor> Vector_Parameters
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TMap<FName, FLinearColor> result;
				if ((result = this._Vector_Parameters) == null)
				{
					result = (this._Vector_Parameters = new TMap<FName, FLinearColor>(base.NativePtr + (IntPtr)BP_Seq_CharacterDecalPostprocess_C.__PropertyOffset_28, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Vector_Parameters.CopyAssign(value);
			}
		}

		// Token: 0x17005572 RID: 21874
		// (get) Token: 0x06026174 RID: 156020 RVA: 0x009CD970 File Offset: 0x009CBB70
		// (set) Token: 0x06026175 RID: 156021 RVA: 0x009CD9A9 File Offset: 0x009CBBA9
		[Nullable(1)]
		public TMap<FName, UTexture> Texture_Parameters
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TMap<FName, UTexture> result;
				if ((result = this._Texture_Parameters) == null)
				{
					result = (this._Texture_Parameters = new TMap<FName, UTexture>(base.NativePtr + (IntPtr)BP_Seq_CharacterDecalPostprocess_C.__PropertyOffset_29, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Texture_Parameters.CopyAssign(value);
			}
		}

		// Token: 0x06026176 RID: 156022 RVA: 0x009CD9B7 File Offset: 0x009CBBB7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Update()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Seq_CharacterDecalPostprocess_C.__Update_NativeFunctionPtr, null);
		}

		// Token: 0x06026177 RID: 156023 RVA: 0x009CD9CB File Offset: 0x009CBBCB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Seq_CharacterDecalPostprocess_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06026178 RID: 156024 RVA: 0x009CD9DF File Offset: 0x009CBBDF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Seq_CharacterDecalPostprocess_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06026179 RID: 156025 RVA: 0x009CD9F4 File Offset: 0x009CBBF4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Seq_CharacterDecalPostprocess_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0602617A RID: 156026 RVA: 0x009CDA08 File Offset: 0x009CBC08
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Seq_CharacterDecalPostprocess_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602617B RID: 156027 RVA: 0x009CDA20 File Offset: 0x009CBC20
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_Seq_CharacterDecalPostprocess_C.__EditorTick_FunctionParams* ptr = stackalloc BP_Seq_CharacterDecalPostprocess_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Seq_CharacterDecalPostprocess_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Seq_CharacterDecalPostprocess_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Seq_CharacterDecalPostprocess_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602617C RID: 156028 RVA: 0x009CDA68 File Offset: 0x009CBC68
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_Seq_CharacterDecalPostprocess_C.__EditorTick_FunctionParams* ptr = stackalloc BP_Seq_CharacterDecalPostprocess_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Seq_CharacterDecalPostprocess_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Seq_CharacterDecalPostprocess_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Seq_CharacterDecalPostprocess_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602617D RID: 156029 RVA: 0x009CDAAF File Offset: 0x009CBCAF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void EditorInit()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Seq_CharacterDecalPostprocess_C.__EditorInit_NativeFunctionPtr, null);
		}

		// Token: 0x0602617E RID: 156030 RVA: 0x009CDAC3 File Offset: 0x009CBCC3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void EditorInit_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Seq_CharacterDecalPostprocess_C.__EditorInit_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602617F RID: 156031 RVA: 0x009CDAD8 File Offset: 0x009CBCD8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_Seq_CharacterDecalPostprocess_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_Seq_CharacterDecalPostprocess_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Seq_CharacterDecalPostprocess_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Seq_CharacterDecalPostprocess_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Seq_CharacterDecalPostprocess_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06026180 RID: 156032 RVA: 0x009CDB20 File Offset: 0x009CBD20
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_Seq_CharacterDecalPostprocess_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_Seq_CharacterDecalPostprocess_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Seq_CharacterDecalPostprocess_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Seq_CharacterDecalPostprocess_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Seq_CharacterDecalPostprocess_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06026181 RID: 156033 RVA: 0x009CDB68 File Offset: 0x009CBD68
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_Seq_CharacterDecalPostprocess(int EntryPoint)
		{
			BP_Seq_CharacterDecalPostprocess_C.__ExecuteUbergraph_BP_Seq_CharacterDecalPostprocess_FunctionParams* ptr = stackalloc BP_Seq_CharacterDecalPostprocess_C.__ExecuteUbergraph_BP_Seq_CharacterDecalPostprocess_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_Seq_CharacterDecalPostprocess_C.__ExecuteUbergraph_BP_Seq_CharacterDecalPostprocess_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Seq_CharacterDecalPostprocess_C.__ExecuteUbergraph_BP_Seq_CharacterDecalPostprocess_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Seq_CharacterDecalPostprocess_C.__ExecuteUbergraph_BP_Seq_CharacterDecalPostprocess_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06026182 RID: 156034 RVA: 0x009CDBAF File Offset: 0x009CBDAF
		protected BP_Seq_CharacterDecalPostprocess_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04013B71 RID: 80753
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Effect/CharacterDecal/BP_Seq_CharacterDecalPostprocess.BP_Seq_CharacterDecalPostprocess_C";

		// Token: 0x04013B72 RID: 80754
		private static IntPtr _ClassPtr;

		// Token: 0x04013B73 RID: 80755
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04013B74 RID: 80756
		internal static int __PropertyOffset_0;

		// Token: 0x04013B75 RID: 80757
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04013B76 RID: 80758
		internal static int __PropertyOffset_1;

		// Token: 0x04013B77 RID: 80759
		internal static int __PropertyOffset_2;

		// Token: 0x04013B78 RID: 80760
		internal static int __PropertyOffset_3;

		// Token: 0x04013B79 RID: 80761
		internal static int __PropertyOffset_4;

		// Token: 0x04013B7A RID: 80762
		internal static int __PropertyOffset_5;

		// Token: 0x04013B7B RID: 80763
		internal static int __PropertyOffset_6;

		// Token: 0x04013B7C RID: 80764
		internal static int __PropertyOffset_7;

		// Token: 0x04013B7D RID: 80765
		internal static int __PropertyOffset_8;

		// Token: 0x04013B7E RID: 80766
		internal static int __PropertyOffset_9;

		// Token: 0x04013B7F RID: 80767
		internal static int __PropertyOffset_10;

		// Token: 0x04013B80 RID: 80768
		internal static int __PropertyOffset_11;

		// Token: 0x04013B81 RID: 80769
		internal static int __PropertyOffset_12;

		// Token: 0x04013B82 RID: 80770
		internal static int __PropertyOffset_13;

		// Token: 0x04013B83 RID: 80771
		internal static int __PropertyOffset_14;

		// Token: 0x04013B84 RID: 80772
		internal static int __PropertyOffset_15;

		// Token: 0x04013B85 RID: 80773
		internal static int __PropertyOffset_16;

		// Token: 0x04013B86 RID: 80774
		internal static int __PropertyOffset_17;

		// Token: 0x04013B87 RID: 80775
		internal static int __PropertyOffset_18;

		// Token: 0x04013B88 RID: 80776
		internal static int __PropertyOffset_19;

		// Token: 0x04013B89 RID: 80777
		internal static int __PropertyOffset_20;

		// Token: 0x04013B8A RID: 80778
		internal static int __PropertyOffset_21;

		// Token: 0x04013B8B RID: 80779
		internal static int __PropertyOffset_22;

		// Token: 0x04013B8C RID: 80780
		internal static int __PropertyOffset_23;

		// Token: 0x04013B8D RID: 80781
		internal static int __PropertyOffset_24;

		// Token: 0x04013B8E RID: 80782
		internal static int __PropertyOffset_25;

		// Token: 0x04013B8F RID: 80783
		internal static int __PropertyOffset_26;

		// Token: 0x04013B90 RID: 80784
		internal static int __PropertyOffset_27;

		// Token: 0x04013B91 RID: 80785
		private TMap<FName, float> _Scalar_Parameters;

		// Token: 0x04013B92 RID: 80786
		internal static int __PropertyOffset_28;

		// Token: 0x04013B93 RID: 80787
		private TMap<FName, FLinearColor> _Vector_Parameters;

		// Token: 0x04013B94 RID: 80788
		internal static int __PropertyOffset_29;

		// Token: 0x04013B95 RID: 80789
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<FName, UTexture> _Texture_Parameters;

		// Token: 0x04013B96 RID: 80790
		private static IntPtr __Update_NativeFunctionPtr;

		// Token: 0x04013B97 RID: 80791
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04013B98 RID: 80792
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04013B99 RID: 80793
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x04013B9A RID: 80794
		private static IntPtr __EditorInit_NativeFunctionPtr;

		// Token: 0x04013B9B RID: 80795
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04013B9C RID: 80796
		private static IntPtr __ExecuteUbergraph_BP_Seq_CharacterDecalPostprocess_NativeFunctionPtr;

		// Token: 0x02009FFA RID: 40954
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x04032BD5 RID: 207829
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009FFB RID: 40955
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032BD6 RID: 207830
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009FFC RID: 40956
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __ExecuteUbergraph_BP_Seq_CharacterDecalPostprocess_FunctionParams
		{
			// Token: 0x04032BD7 RID: 207831
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
