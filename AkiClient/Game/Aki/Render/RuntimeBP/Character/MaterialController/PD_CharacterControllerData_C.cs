using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialContainer;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialController
{
	// Token: 0x02003D7C RID: 15740
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Character/MaterialController/PD_CharacterControllerData.PD_CharacterControllerData_C")]
	[UnrealStructLayout(22168, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 22165)]
	public class PD_CharacterControllerData_C : UKuroMaterialControllerDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06026629 RID: 157225 RVA: 0x009D6522 File Offset: 0x009D4722
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (PD_CharacterControllerData_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Character/MaterialController/PD_CharacterControllerData.PD_CharacterControllerData_C");
			}
			return PD_CharacterControllerData_C._ClassPtr;
		}

		// Token: 0x0602662A RID: 157226 RVA: 0x009D6548 File Offset: 0x009D4748
		public PD_CharacterControllerData_C() : this(BuiltinUtils.AllocNativeUObject(PD_CharacterControllerData_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602662B RID: 157227 RVA: 0x009D6570 File Offset: 0x009D4770
		public PD_CharacterControllerData_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(PD_CharacterControllerData_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700570A RID: 22282
		// (get) Token: 0x0602662C RID: 157228 RVA: 0x009D65A3 File Offset: 0x009D47A3
		// (set) Token: 0x0602662D RID: 157229 RVA: 0x009D65B7 File Offset: 0x009D47B7
		[Nullable(0)]
		public unsafe TEnumAsByte<ECharacterControllerType> DataType
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_0);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x1700570B RID: 22283
		// (get) Token: 0x0602662E RID: 157230 RVA: 0x009D65CC File Offset: 0x009D47CC
		// (set) Token: 0x0602662F RID: 157231 RVA: 0x009D65E0 File Offset: 0x009D47E0
		[Nullable(0)]
		public unsafe TEnumAsByte<ECharacterBodySpecifiedType> SpecifiedBodyType
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_1);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x1700570C RID: 22284
		// (get) Token: 0x06026630 RID: 157232 RVA: 0x009D65F8 File Offset: 0x009D47F8
		// (set) Token: 0x06026631 RID: 157233 RVA: 0x009D6631 File Offset: 0x009D4831
		[Nullable(new byte[]
		{
			1,
			0
		})]
		public TArray<TEnumAsByte<ECharacterMeshPart>> SpecifiedParts
		{
			[return: Nullable(new byte[]
			{
				1,
				0
			})]
			get
			{
				base.FastCheckIsValid();
				TArray<TEnumAsByte<ECharacterMeshPart>> result;
				if ((result = this._SpecifiedParts) == null)
				{
					result = (this._SpecifiedParts = new TArray<TEnumAsByte<ECharacterMeshPart>>(base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_2, this));
				}
				return result;
			}
			[param: Nullable(new byte[]
			{
				1,
				0
			})]
			set
			{
				this.SpecifiedParts.CopyAssign(value);
			}
		}

		// Token: 0x1700570D RID: 22285
		// (get) Token: 0x06026632 RID: 157234 RVA: 0x009D663F File Offset: 0x009D483F
		// (set) Token: 0x06026633 RID: 157235 RVA: 0x009D6653 File Offset: 0x009D4853
		[Nullable(0)]
		public unsafe TEnumAsByte<ECharacterSlotSpecifiedType> SpecifiedSlotType
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_3);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x1700570E RID: 22286
		// (get) Token: 0x06026634 RID: 157236 RVA: 0x009D6668 File Offset: 0x009D4868
		// (set) Token: 0x06026635 RID: 157237 RVA: 0x009D667C File Offset: 0x009D487C
		[Nullable(0)]
		public unsafe TEnumAsByte<ECharacterControllerApplyType> MaterialModifyType
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_4);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x1700570F RID: 22287
		// (get) Token: 0x06026636 RID: 157238 RVA: 0x009D6691 File Offset: 0x009D4891
		// (set) Token: 0x06026637 RID: 157239 RVA: 0x009D66A5 File Offset: 0x009D48A5
		[Nullable(2)]
		public unsafe UMaterialInterface ReplaceMaterial
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInterface>(base.NativePtr / (IntPtr)sizeof(void*) + PD_CharacterControllerData_C.__PropertyOffset_5);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + PD_CharacterControllerData_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17005710 RID: 22288
		// (get) Token: 0x06026638 RID: 157240 RVA: 0x009D66BA File Offset: 0x009D48BA
		// (set) Token: 0x06026639 RID: 157241 RVA: 0x009D66CE File Offset: 0x009D48CE
		[Nullable(2)]
		public unsafe UMaterialInterface ReplaceMaterialMobile
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInterface>(base.NativePtr / (IntPtr)sizeof(void*) + PD_CharacterControllerData_C.__PropertyOffset_6);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + PD_CharacterControllerData_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x17005711 RID: 22289
		// (get) Token: 0x0602663A RID: 157242 RVA: 0x009D66E3 File Offset: 0x009D48E3
		// (set) Token: 0x0602663B RID: 157243 RVA: 0x009D66F3 File Offset: 0x009D48F3
		public unsafe bool RevertMaterial_DEPRECATED
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_7) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_7) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005712 RID: 22290
		// (get) Token: 0x0602663C RID: 157244 RVA: 0x009D6704 File Offset: 0x009D4904
		// (set) Token: 0x0602663D RID: 157245 RVA: 0x009D6714 File Offset: 0x009D4914
		public unsafe bool UseRim
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_8) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_8) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005713 RID: 22291
		// (get) Token: 0x0602663E RID: 157246 RVA: 0x009D6725 File Offset: 0x009D4925
		// (set) Token: 0x0602663F RID: 157247 RVA: 0x009D6735 File Offset: 0x009D4935
		public unsafe bool UseOutline
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_9) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_9) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005714 RID: 22292
		// (get) Token: 0x06026640 RID: 157248 RVA: 0x009D6746 File Offset: 0x009D4946
		// (set) Token: 0x06026641 RID: 157249 RVA: 0x009D6756 File Offset: 0x009D4956
		public unsafe bool OutlineRevertProperty_DEPRECATED
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_10) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_10) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005715 RID: 22293
		// (get) Token: 0x06026642 RID: 157250 RVA: 0x009D6767 File Offset: 0x009D4967
		// (set) Token: 0x06026643 RID: 157251 RVA: 0x009D6777 File Offset: 0x009D4977
		public unsafe bool UseDissolve
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_11) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_11) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005716 RID: 22294
		// (get) Token: 0x06026644 RID: 157252 RVA: 0x009D6788 File Offset: 0x009D4988
		// (set) Token: 0x06026645 RID: 157253 RVA: 0x009D679C File Offset: 0x009D499C
		public unsafe SMaterialControllerLoopTime LoopTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17005717 RID: 22295
		// (get) Token: 0x06026646 RID: 157254 RVA: 0x009D67B1 File Offset: 0x009D49B1
		// (set) Token: 0x06026647 RID: 157255 RVA: 0x009D67C1 File Offset: 0x009D49C1
		public unsafe bool RimRevertProperty_DEPRECATED
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_13) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_13) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005718 RID: 22296
		// (get) Token: 0x06026648 RID: 157256 RVA: 0x009D67D2 File Offset: 0x009D49D2
		// (set) Token: 0x06026649 RID: 157257 RVA: 0x009D67E2 File Offset: 0x009D49E2
		public unsafe bool RimUseTex
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_14) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_14) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005719 RID: 22297
		// (get) Token: 0x0602664A RID: 157258 RVA: 0x009D67F3 File Offset: 0x009D49F3
		// (set) Token: 0x0602664B RID: 157259 RVA: 0x009D6807 File Offset: 0x009D4A07
		[Nullable(0)]
		public unsafe TEnumAsByte<ECharacterControllerChannelSwitch> RimChannel
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_15);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x1700571A RID: 22298
		// (get) Token: 0x0602664C RID: 157260 RVA: 0x009D681C File Offset: 0x009D4A1C
		// (set) Token: 0x0602664D RID: 157261 RVA: 0x009D6855 File Offset: 0x009D4A55
		public SMaterialControllerFloatGroup RimRange
		{
			get
			{
				base.FastCheckIsValid();
				SMaterialControllerFloatGroup result;
				if ((result = this._RimRange) == null)
				{
					result = (this._RimRange = new SMaterialControllerFloatGroup(base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_16, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SMaterialControllerFloatGroup.StaticStruct(), base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_16, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700571B RID: 22299
		// (get) Token: 0x0602664E RID: 157262 RVA: 0x009D6878 File Offset: 0x009D4A78
		// (set) Token: 0x0602664F RID: 157263 RVA: 0x009D68B1 File Offset: 0x009D4AB1
		public SMaterialControllerColorGroup RimColor
		{
			get
			{
				base.FastCheckIsValid();
				SMaterialControllerColorGroup result;
				if ((result = this._RimColor) == null)
				{
					result = (this._RimColor = new SMaterialControllerColorGroup(base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_17, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SMaterialControllerColorGroup.StaticStruct(), base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_17, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700571C RID: 22300
		// (get) Token: 0x06026650 RID: 157264 RVA: 0x009D68D2 File Offset: 0x009D4AD2
		// (set) Token: 0x06026651 RID: 157265 RVA: 0x009D68E2 File Offset: 0x009D4AE2
		public unsafe bool OutlineUseTex
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_18) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_18) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700571D RID: 22301
		// (get) Token: 0x06026652 RID: 157266 RVA: 0x009D68F4 File Offset: 0x009D4AF4
		// (set) Token: 0x06026653 RID: 157267 RVA: 0x009D692D File Offset: 0x009D4B2D
		public SMaterialControllerFloatGroup OutlineWidth
		{
			get
			{
				base.FastCheckIsValid();
				SMaterialControllerFloatGroup result;
				if ((result = this._OutlineWidth) == null)
				{
					result = (this._OutlineWidth = new SMaterialControllerFloatGroup(base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_19, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SMaterialControllerFloatGroup.StaticStruct(), base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_19, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700571E RID: 22302
		// (get) Token: 0x06026654 RID: 157268 RVA: 0x009D6950 File Offset: 0x009D4B50
		// (set) Token: 0x06026655 RID: 157269 RVA: 0x009D6989 File Offset: 0x009D4B89
		public SMaterialControllerColorGroup OutlineColor
		{
			get
			{
				base.FastCheckIsValid();
				SMaterialControllerColorGroup result;
				if ((result = this._OutlineColor) == null)
				{
					result = (this._OutlineColor = new SMaterialControllerColorGroup(base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_20, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SMaterialControllerColorGroup.StaticStruct(), base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_20, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700571F RID: 22303
		// (get) Token: 0x06026656 RID: 157270 RVA: 0x009D69AA File Offset: 0x009D4BAA
		// (set) Token: 0x06026657 RID: 157271 RVA: 0x009D69BA File Offset: 0x009D4BBA
		public unsafe bool DissolveRevertProperty_DEPRECATED
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_21) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_21) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005720 RID: 22304
		// (get) Token: 0x06026658 RID: 157272 RVA: 0x009D69CB File Offset: 0x009D4BCB
		// (set) Token: 0x06026659 RID: 157273 RVA: 0x009D69DF File Offset: 0x009D4BDF
		[Nullable(0)]
		public unsafe TEnumAsByte<ECharacterControllerChannelSwitch> DissolveChannel
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_22);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x17005721 RID: 22305
		// (get) Token: 0x0602665A RID: 157274 RVA: 0x009D69F4 File Offset: 0x009D4BF4
		// (set) Token: 0x0602665B RID: 157275 RVA: 0x009D6A2D File Offset: 0x009D4C2D
		public SMaterialControllerFloatGroup DissolveProgress
		{
			get
			{
				base.FastCheckIsValid();
				SMaterialControllerFloatGroup result;
				if ((result = this._DissolveProgress) == null)
				{
					result = (this._DissolveProgress = new SMaterialControllerFloatGroup(base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_23, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SMaterialControllerFloatGroup.StaticStruct(), base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_23, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005722 RID: 22306
		// (get) Token: 0x0602665C RID: 157276 RVA: 0x009D6A50 File Offset: 0x009D4C50
		// (set) Token: 0x0602665D RID: 157277 RVA: 0x009D6A89 File Offset: 0x009D4C89
		public SMaterialControllerColorGroup DissolveColor
		{
			get
			{
				base.FastCheckIsValid();
				SMaterialControllerColorGroup result;
				if ((result = this._DissolveColor) == null)
				{
					result = (this._DissolveColor = new SMaterialControllerColorGroup(base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_24, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SMaterialControllerColorGroup.StaticStruct(), base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_24, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005723 RID: 22307
		// (get) Token: 0x0602665E RID: 157278 RVA: 0x009D6AAC File Offset: 0x009D4CAC
		// (set) Token: 0x0602665F RID: 157279 RVA: 0x009D6AE5 File Offset: 0x009D4CE5
		public SMaterialControllerFloatGroup DissolveColorIntensity
		{
			get
			{
				base.FastCheckIsValid();
				SMaterialControllerFloatGroup result;
				if ((result = this._DissolveColorIntensity) == null)
				{
					result = (this._DissolveColorIntensity = new SMaterialControllerFloatGroup(base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_25, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SMaterialControllerFloatGroup.StaticStruct(), base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_25, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005724 RID: 22308
		// (get) Token: 0x06026660 RID: 157280 RVA: 0x009D6B06 File Offset: 0x009D4D06
		// (set) Token: 0x06026661 RID: 157281 RVA: 0x009D6B16 File Offset: 0x009D4D16
		public unsafe bool UseTextureSample
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_26) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_26) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005725 RID: 22309
		// (get) Token: 0x06026662 RID: 157282 RVA: 0x009D6B27 File Offset: 0x009D4D27
		// (set) Token: 0x06026663 RID: 157283 RVA: 0x009D6B37 File Offset: 0x009D4D37
		public unsafe bool TextureSampleRevertProperty
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_27) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_27) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005726 RID: 22310
		// (get) Token: 0x06026664 RID: 157284 RVA: 0x009D6B48 File Offset: 0x009D4D48
		// (set) Token: 0x06026665 RID: 157285 RVA: 0x009D6B58 File Offset: 0x009D4D58
		public unsafe bool UseAlphaToMask
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_28) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_28) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005727 RID: 22311
		// (get) Token: 0x06026666 RID: 157286 RVA: 0x009D6B69 File Offset: 0x009D4D69
		// (set) Token: 0x06026667 RID: 157287 RVA: 0x009D6B7D File Offset: 0x009D4D7D
		[Nullable(2)]
		public unsafe UTexture2D MaskTexture
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + PD_CharacterControllerData_C.__PropertyOffset_29);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + PD_CharacterControllerData_C.__PropertyOffset_29, value);
			}
		}

		// Token: 0x17005728 RID: 22312
		// (get) Token: 0x06026668 RID: 157288 RVA: 0x009D6B94 File Offset: 0x009D4D94
		// (set) Token: 0x06026669 RID: 157289 RVA: 0x009D6BCD File Offset: 0x009D4DCD
		public SMaterialControllerFloatGroup Rotation
		{
			get
			{
				base.FastCheckIsValid();
				SMaterialControllerFloatGroup result;
				if ((result = this._Rotation) == null)
				{
					result = (this._Rotation = new SMaterialControllerFloatGroup(base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_30, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SMaterialControllerFloatGroup.StaticStruct(), base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_30, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005729 RID: 22313
		// (get) Token: 0x0602666A RID: 157290 RVA: 0x009D6BEE File Offset: 0x009D4DEE
		// (set) Token: 0x0602666B RID: 157291 RVA: 0x009D6C02 File Offset: 0x009D4E02
		[Nullable(0)]
		public unsafe TEnumAsByte<ECharacterControllerUVSwitch> UVSelection
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_31);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_31) = value;
			}
		}

		// Token: 0x1700572A RID: 22314
		// (get) Token: 0x0602666C RID: 157292 RVA: 0x009D6C18 File Offset: 0x009D4E18
		// (set) Token: 0x0602666D RID: 157293 RVA: 0x009D6C51 File Offset: 0x009D4E51
		public SMaterialControllerColorGroup TextureScaleAndOffset
		{
			get
			{
				base.FastCheckIsValid();
				SMaterialControllerColorGroup result;
				if ((result = this._TextureScaleAndOffset) == null)
				{
					result = (this._TextureScaleAndOffset = new SMaterialControllerColorGroup(base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_32, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SMaterialControllerColorGroup.StaticStruct(), base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_32, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700572B RID: 22315
		// (get) Token: 0x0602666E RID: 157294 RVA: 0x009D6C74 File Offset: 0x009D4E74
		// (set) Token: 0x0602666F RID: 157295 RVA: 0x009D6CAD File Offset: 0x009D4EAD
		public SMaterialControllerColorGroup TextureSpeed
		{
			get
			{
				base.FastCheckIsValid();
				SMaterialControllerColorGroup result;
				if ((result = this._TextureSpeed) == null)
				{
					result = (this._TextureSpeed = new SMaterialControllerColorGroup(base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_33, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SMaterialControllerColorGroup.StaticStruct(), base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_33, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700572C RID: 22316
		// (get) Token: 0x06026670 RID: 157296 RVA: 0x009D6CD0 File Offset: 0x009D4ED0
		// (set) Token: 0x06026671 RID: 157297 RVA: 0x009D6D09 File Offset: 0x009D4F09
		public SMaterialControllerColorGroup TextureColorTint
		{
			get
			{
				base.FastCheckIsValid();
				SMaterialControllerColorGroup result;
				if ((result = this._TextureColorTint) == null)
				{
					result = (this._TextureColorTint = new SMaterialControllerColorGroup(base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_34, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SMaterialControllerColorGroup.StaticStruct(), base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_34, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700572D RID: 22317
		// (get) Token: 0x06026672 RID: 157298 RVA: 0x009D6D2C File Offset: 0x009D4F2C
		// (set) Token: 0x06026673 RID: 157299 RVA: 0x009D6D65 File Offset: 0x009D4F65
		public SMaterialControllerFloatGroup OutlineIntensity
		{
			get
			{
				base.FastCheckIsValid();
				SMaterialControllerFloatGroup result;
				if ((result = this._OutlineIntensity) == null)
				{
					result = (this._OutlineIntensity = new SMaterialControllerFloatGroup(base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_35, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SMaterialControllerFloatGroup.StaticStruct(), base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_35, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700572E RID: 22318
		// (get) Token: 0x06026674 RID: 157300 RVA: 0x009D6D86 File Offset: 0x009D4F86
		// (set) Token: 0x06026675 RID: 157301 RVA: 0x009D6D96 File Offset: 0x009D4F96
		public unsafe bool UseOuterOutlineEffect
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_36) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_36) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700572F RID: 22319
		// (get) Token: 0x06026676 RID: 157302 RVA: 0x009D6DA7 File Offset: 0x009D4FA7
		// (set) Token: 0x06026677 RID: 157303 RVA: 0x009D6DB7 File Offset: 0x009D4FB7
		public unsafe bool UseParameterModify
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_37) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_37) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005730 RID: 22320
		// (get) Token: 0x06026678 RID: 157304 RVA: 0x009D6DC8 File Offset: 0x009D4FC8
		// (set) Token: 0x06026679 RID: 157305 RVA: 0x009D6E01 File Offset: 0x009D5001
		public TArray<SMaterialControllerFloatParameter> FloatParameters
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SMaterialControllerFloatParameter> result;
				if ((result = this._FloatParameters) == null)
				{
					result = (this._FloatParameters = new TArray<SMaterialControllerFloatParameter>(base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_38, this));
				}
				return result;
			}
			set
			{
				this.FloatParameters.CopyAssign(value);
			}
		}

		// Token: 0x17005731 RID: 22321
		// (get) Token: 0x0602667A RID: 157306 RVA: 0x009D6E0F File Offset: 0x009D500F
		// (set) Token: 0x0602667B RID: 157307 RVA: 0x009D6E1F File Offset: 0x009D501F
		public unsafe bool UseColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_39) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_39) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005732 RID: 22322
		// (get) Token: 0x0602667C RID: 157308 RVA: 0x009D6E30 File Offset: 0x009D5030
		// (set) Token: 0x0602667D RID: 157309 RVA: 0x009D6E40 File Offset: 0x009D5040
		public unsafe bool ColorRevertProperty_DEPRECATED
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_40) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_40) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005733 RID: 22323
		// (get) Token: 0x0602667E RID: 157310 RVA: 0x009D6E51 File Offset: 0x009D5051
		// (set) Token: 0x0602667F RID: 157311 RVA: 0x009D6E61 File Offset: 0x009D5061
		public unsafe bool BaseUseTex
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_41) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_41) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005734 RID: 22324
		// (get) Token: 0x06026680 RID: 157312 RVA: 0x009D6E74 File Offset: 0x009D5074
		// (set) Token: 0x06026681 RID: 157313 RVA: 0x009D6EAD File Offset: 0x009D50AD
		public SMaterialControllerColorGroup BaseColor
		{
			get
			{
				base.FastCheckIsValid();
				SMaterialControllerColorGroup result;
				if ((result = this._BaseColor) == null)
				{
					result = (this._BaseColor = new SMaterialControllerColorGroup(base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_42, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SMaterialControllerColorGroup.StaticStruct(), base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_42, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005735 RID: 22325
		// (get) Token: 0x06026682 RID: 157314 RVA: 0x009D6ED0 File Offset: 0x009D50D0
		// (set) Token: 0x06026683 RID: 157315 RVA: 0x009D6F09 File Offset: 0x009D5109
		public SMaterialControllerFloatGroup BaseColorIntensity
		{
			get
			{
				base.FastCheckIsValid();
				SMaterialControllerFloatGroup result;
				if ((result = this._BaseColorIntensity) == null)
				{
					result = (this._BaseColorIntensity = new SMaterialControllerFloatGroup(base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_43, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SMaterialControllerFloatGroup.StaticStruct(), base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_43, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005736 RID: 22326
		// (get) Token: 0x06026684 RID: 157316 RVA: 0x009D6F2A File Offset: 0x009D512A
		// (set) Token: 0x06026685 RID: 157317 RVA: 0x009D6F3A File Offset: 0x009D513A
		public unsafe bool EmissionUseTex
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_44) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_44) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005737 RID: 22327
		// (get) Token: 0x06026686 RID: 157318 RVA: 0x009D6F4C File Offset: 0x009D514C
		// (set) Token: 0x06026687 RID: 157319 RVA: 0x009D6F85 File Offset: 0x009D5185
		public SMaterialControllerColorGroup EmissionColor
		{
			get
			{
				base.FastCheckIsValid();
				SMaterialControllerColorGroup result;
				if ((result = this._EmissionColor) == null)
				{
					result = (this._EmissionColor = new SMaterialControllerColorGroup(base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_45, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SMaterialControllerColorGroup.StaticStruct(), base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_45, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005738 RID: 22328
		// (get) Token: 0x06026688 RID: 157320 RVA: 0x009D6FA8 File Offset: 0x009D51A8
		// (set) Token: 0x06026689 RID: 157321 RVA: 0x009D6FE1 File Offset: 0x009D51E1
		public SMaterialControllerFloatGroup EmissionIntensity
		{
			get
			{
				base.FastCheckIsValid();
				SMaterialControllerFloatGroup result;
				if ((result = this._EmissionIntensity) == null)
				{
					result = (this._EmissionIntensity = new SMaterialControllerFloatGroup(base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_46, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SMaterialControllerFloatGroup.StaticStruct(), base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_46, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005739 RID: 22329
		// (get) Token: 0x0602668A RID: 157322 RVA: 0x009D7004 File Offset: 0x009D5204
		// (set) Token: 0x0602668B RID: 157323 RVA: 0x009D703D File Offset: 0x009D523D
		public TArray<SMaterialControllerColorParameter> ColorParameters
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SMaterialControllerColorParameter> result;
				if ((result = this._ColorParameters) == null)
				{
					result = (this._ColorParameters = new TArray<SMaterialControllerColorParameter>(base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_47, this));
				}
				return result;
			}
			set
			{
				this.ColorParameters.CopyAssign(value);
			}
		}

		// Token: 0x1700573A RID: 22330
		// (get) Token: 0x0602668C RID: 157324 RVA: 0x009D704B File Offset: 0x009D524B
		// (set) Token: 0x0602668D RID: 157325 RVA: 0x009D705B File Offset: 0x009D525B
		public unsafe bool UseCustomMaterialEffect
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_48) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_48) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700573B RID: 22331
		// (get) Token: 0x0602668E RID: 157326 RVA: 0x009D706C File Offset: 0x009D526C
		// (set) Token: 0x0602668F RID: 157327 RVA: 0x009D707C File Offset: 0x009D527C
		public unsafe bool CustomRevertProperty_DEPRECATED
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_49) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_49) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700573C RID: 22332
		// (get) Token: 0x06026690 RID: 157328 RVA: 0x009D7090 File Offset: 0x009D5290
		// (set) Token: 0x06026691 RID: 157329 RVA: 0x009D70C9 File Offset: 0x009D52C9
		public TArray<SMaterialControllerFloatParameter> CustomFloatParameters
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SMaterialControllerFloatParameter> result;
				if ((result = this._CustomFloatParameters) == null)
				{
					result = (this._CustomFloatParameters = new TArray<SMaterialControllerFloatParameter>(base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_50, this));
				}
				return result;
			}
			set
			{
				this.CustomFloatParameters.CopyAssign(value);
			}
		}

		// Token: 0x1700573D RID: 22333
		// (get) Token: 0x06026692 RID: 157330 RVA: 0x009D70D8 File Offset: 0x009D52D8
		// (set) Token: 0x06026693 RID: 157331 RVA: 0x009D7111 File Offset: 0x009D5311
		public TArray<SMaterialControllerColorParameter> CustomColorParameters
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SMaterialControllerColorParameter> result;
				if ((result = this._CustomColorParameters) == null)
				{
					result = (this._CustomColorParameters = new TArray<SMaterialControllerColorParameter>(base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_51, this));
				}
				return result;
			}
			set
			{
				this.CustomColorParameters.CopyAssign(value);
			}
		}

		// Token: 0x1700573E RID: 22334
		// (get) Token: 0x06026694 RID: 157332 RVA: 0x009D7120 File Offset: 0x009D5320
		// (set) Token: 0x06026695 RID: 157333 RVA: 0x009D7159 File Offset: 0x009D5359
		public TArray<SMaterialControllerTextureParameter> CustomTextureParameters
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SMaterialControllerTextureParameter> result;
				if ((result = this._CustomTextureParameters) == null)
				{
					result = (this._CustomTextureParameters = new TArray<SMaterialControllerTextureParameter>(base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_52, this));
				}
				return result;
			}
			set
			{
				this.CustomTextureParameters.CopyAssign(value);
			}
		}

		// Token: 0x1700573F RID: 22335
		// (get) Token: 0x06026696 RID: 157334 RVA: 0x009D7167 File Offset: 0x009D5367
		// (set) Token: 0x06026697 RID: 157335 RVA: 0x009D7177 File Offset: 0x009D5377
		public unsafe bool UseMotionOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_53) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_53) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005740 RID: 22336
		// (get) Token: 0x06026698 RID: 157336 RVA: 0x009D7188 File Offset: 0x009D5388
		// (set) Token: 0x06026699 RID: 157337 RVA: 0x009D7198 File Offset: 0x009D5398
		public unsafe bool MotionOffsetRevertProperty_DEPRECATED
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_54) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_54) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005741 RID: 22337
		// (get) Token: 0x0602669A RID: 157338 RVA: 0x009D71A9 File Offset: 0x009D53A9
		// (set) Token: 0x0602669B RID: 157339 RVA: 0x009D71B9 File Offset: 0x009D53B9
		public unsafe float MotionOffsetLength
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_55);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_55) = value;
			}
		}

		// Token: 0x17005742 RID: 22338
		// (get) Token: 0x0602669C RID: 157340 RVA: 0x009D71CA File Offset: 0x009D53CA
		// (set) Token: 0x0602669D RID: 157341 RVA: 0x009D71DA File Offset: 0x009D53DA
		public unsafe float MotionAffectVertexRange
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_56);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_56) = value;
			}
		}

		// Token: 0x17005743 RID: 22339
		// (get) Token: 0x0602669E RID: 157342 RVA: 0x009D71EC File Offset: 0x009D53EC
		// (set) Token: 0x0602669F RID: 157343 RVA: 0x009D7225 File Offset: 0x009D5425
		public TArray<string> WeaponCases
		{
			get
			{
				base.FastCheckIsValid();
				TArray<string> result;
				if ((result = this._WeaponCases) == null)
				{
					result = (this._WeaponCases = new TArray<string>(base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_57, this));
				}
				return result;
			}
			set
			{
				this.WeaponCases.CopyAssign(value);
			}
		}

		// Token: 0x17005744 RID: 22340
		// (get) Token: 0x060266A0 RID: 157344 RVA: 0x009D7233 File Offset: 0x009D5433
		// (set) Token: 0x060266A1 RID: 157345 RVA: 0x009D7243 File Offset: 0x009D5443
		public unsafe bool IgnoreTimeDilation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_58) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_58) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005745 RID: 22341
		// (get) Token: 0x060266A2 RID: 157346 RVA: 0x009D7254 File Offset: 0x009D5454
		// (set) Token: 0x060266A3 RID: 157347 RVA: 0x009D7264 File Offset: 0x009D5464
		public unsafe bool HiddenAfterEffect
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_59) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_59) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005746 RID: 22342
		// (get) Token: 0x060266A4 RID: 157348 RVA: 0x009D7278 File Offset: 0x009D5478
		// (set) Token: 0x060266A5 RID: 157349 RVA: 0x009D72B1 File Offset: 0x009D54B1
		public SMaterialControllerFloatGroup DissolveSmooth
		{
			get
			{
				base.FastCheckIsValid();
				SMaterialControllerFloatGroup result;
				if ((result = this._DissolveSmooth) == null)
				{
					result = (this._DissolveSmooth = new SMaterialControllerFloatGroup(base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_60, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SMaterialControllerFloatGroup.StaticStruct(), base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_60, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005747 RID: 22343
		// (get) Token: 0x060266A6 RID: 157350 RVA: 0x009D72D4 File Offset: 0x009D54D4
		// (set) Token: 0x060266A7 RID: 157351 RVA: 0x009D730D File Offset: 0x009D550D
		public SMaterialControllerFloatGroup MotionNoiseSpeed
		{
			get
			{
				base.FastCheckIsValid();
				SMaterialControllerFloatGroup result;
				if ((result = this._MotionNoiseSpeed) == null)
				{
					result = (this._MotionNoiseSpeed = new SMaterialControllerFloatGroup(base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_61, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SMaterialControllerFloatGroup.StaticStruct(), base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_61, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005748 RID: 22344
		// (get) Token: 0x060266A8 RID: 157352 RVA: 0x009D732E File Offset: 0x009D552E
		// (set) Token: 0x060266A9 RID: 157353 RVA: 0x009D733E File Offset: 0x009D553E
		public unsafe bool UseDitherEffect
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_62) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_62) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005749 RID: 22345
		// (get) Token: 0x060266AA RID: 157354 RVA: 0x009D734F File Offset: 0x009D554F
		// (set) Token: 0x060266AB RID: 157355 RVA: 0x009D735F File Offset: 0x009D555F
		public unsafe bool DitherRevertProperty_DEPRECATED
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_63) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_63) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700574A RID: 22346
		// (get) Token: 0x060266AC RID: 157356 RVA: 0x009D7370 File Offset: 0x009D5570
		// (set) Token: 0x060266AD RID: 157357 RVA: 0x009D73A9 File Offset: 0x009D55A9
		public SMaterialControllerFloatGroup DitherValue
		{
			get
			{
				base.FastCheckIsValid();
				SMaterialControllerFloatGroup result;
				if ((result = this._DitherValue) == null)
				{
					result = (this._DitherValue = new SMaterialControllerFloatGroup(base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_64, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SMaterialControllerFloatGroup.StaticStruct(), base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_64, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700574B RID: 22347
		// (get) Token: 0x060266AE RID: 157358 RVA: 0x009D73CC File Offset: 0x009D55CC
		// (set) Token: 0x060266AF RID: 157359 RVA: 0x009D7405 File Offset: 0x009D5605
		public TArray<string> OtherCases
		{
			get
			{
				base.FastCheckIsValid();
				TArray<string> result;
				if ((result = this._OtherCases) == null)
				{
					result = (this._OtherCases = new TArray<string>(base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_65, this));
				}
				return result;
			}
			set
			{
				this.OtherCases.CopyAssign(value);
			}
		}

		// Token: 0x1700574C RID: 22348
		// (get) Token: 0x060266B0 RID: 157360 RVA: 0x009D7414 File Offset: 0x009D5614
		// (set) Token: 0x060266B1 RID: 157361 RVA: 0x009D744D File Offset: 0x009D564D
		public SMaterialControllerFloatGroup RimIntensity
		{
			get
			{
				base.FastCheckIsValid();
				SMaterialControllerFloatGroup result;
				if ((result = this._RimIntensity) == null)
				{
					result = (this._RimIntensity = new SMaterialControllerFloatGroup(base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_66, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SMaterialControllerFloatGroup.StaticStruct(), base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_66, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700574D RID: 22349
		// (get) Token: 0x060266B2 RID: 157362 RVA: 0x009D7470 File Offset: 0x009D5670
		// (set) Token: 0x060266B3 RID: 157363 RVA: 0x009D74A9 File Offset: 0x009D56A9
		public TArray<string> CustomPartNames
		{
			get
			{
				base.FastCheckIsValid();
				TArray<string> result;
				if ((result = this._CustomPartNames) == null)
				{
					result = (this._CustomPartNames = new TArray<string>(base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_67, this));
				}
				return result;
			}
			set
			{
				this.CustomPartNames.CopyAssign(value);
			}
		}

		// Token: 0x1700574E RID: 22350
		// (get) Token: 0x060266B4 RID: 157364 RVA: 0x009D74B8 File Offset: 0x009D56B8
		// (set) Token: 0x060266B5 RID: 157365 RVA: 0x009D74F1 File Offset: 0x009D56F1
		public SMaterialControllerFloatGroup TextureMaskRange
		{
			get
			{
				base.FastCheckIsValid();
				SMaterialControllerFloatGroup result;
				if ((result = this._TextureMaskRange) == null)
				{
					result = (this._TextureMaskRange = new SMaterialControllerFloatGroup(base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_68, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SMaterialControllerFloatGroup.StaticStruct(), base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_68, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700574F RID: 22351
		// (get) Token: 0x060266B6 RID: 157366 RVA: 0x009D7512 File Offset: 0x009D5712
		// (set) Token: 0x060266B7 RID: 157367 RVA: 0x009D7522 File Offset: 0x009D5722
		public unsafe bool MaskOriginEffect
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_69) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_69) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005750 RID: 22352
		// (get) Token: 0x060266B8 RID: 157368 RVA: 0x009D7533 File Offset: 0x009D5733
		// (set) Token: 0x060266B9 RID: 157369 RVA: 0x009D7543 File Offset: 0x009D5743
		public unsafe bool UpdateAtLeastOneFrame
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_70) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_70) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005751 RID: 22353
		// (get) Token: 0x060266BA RID: 157370 RVA: 0x009D7554 File Offset: 0x009D5754
		// (set) Token: 0x060266BB RID: 157371 RVA: 0x009D758D File Offset: 0x009D578D
		public TArray<string> CustomExcludePartNames
		{
			get
			{
				base.FastCheckIsValid();
				TArray<string> result;
				if ((result = this._CustomExcludePartNames) == null)
				{
					result = (this._CustomExcludePartNames = new TArray<string>(base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_71, this));
				}
				return result;
			}
			set
			{
				this.CustomExcludePartNames.CopyAssign(value);
			}
		}

		// Token: 0x17005752 RID: 22354
		// (get) Token: 0x060266BC RID: 157372 RVA: 0x009D759B File Offset: 0x009D579B
		// (set) Token: 0x060266BD RID: 157373 RVA: 0x009D75AB File Offset: 0x009D57AB
		public unsafe bool ForceUpdateOnAdd
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_72) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_72) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005753 RID: 22355
		// (get) Token: 0x060266BE RID: 157374 RVA: 0x009D75BC File Offset: 0x009D57BC
		// (set) Token: 0x060266BF RID: 157375 RVA: 0x009D75CC File Offset: 0x009D57CC
		public unsafe bool ForceBattleMask
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_73) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_73) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005754 RID: 22356
		// (get) Token: 0x060266C0 RID: 157376 RVA: 0x009D75DD File Offset: 0x009D57DD
		// (set) Token: 0x060266C1 RID: 157377 RVA: 0x009D75ED File Offset: 0x009D57ED
		public unsafe bool MobileUseDifferentMaterial
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_74) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_74) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005755 RID: 22357
		// (get) Token: 0x060266C2 RID: 157378 RVA: 0x009D75FE File Offset: 0x009D57FE
		// (set) Token: 0x060266C3 RID: 157379 RVA: 0x009D760E File Offset: 0x009D580E
		public unsafe bool OnlyApplyOnLocalPlayer
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_75) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_75) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005756 RID: 22358
		// (get) Token: 0x060266C4 RID: 157380 RVA: 0x009D761F File Offset: 0x009D581F
		// (set) Token: 0x060266C5 RID: 157381 RVA: 0x009D762F File Offset: 0x009D582F
		public unsafe bool NeverApplyOnLocalPlayer
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_76) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)PD_CharacterControllerData_C.__PropertyOffset_76) = (value ? 1 : 0);
			}
		}

		// Token: 0x060266C6 RID: 157382 RVA: 0x009D7640 File Offset: 0x009D5840
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void InitCache()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, PD_CharacterControllerData_C.__InitCache_NativeFunctionPtr, null);
		}

		// Token: 0x060266C7 RID: 157383 RVA: 0x009D7654 File Offset: 0x009D5854
		protected PD_CharacterControllerData_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04013ED3 RID: 81619
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Character/MaterialController/PD_CharacterControllerData.PD_CharacterControllerData_C";

		// Token: 0x04013ED4 RID: 81620
		private static IntPtr _ClassPtr;

		// Token: 0x04013ED5 RID: 81621
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04013ED6 RID: 81622
		internal static int __PropertyOffset_0;

		// Token: 0x04013ED7 RID: 81623
		internal static int __PropertyOffset_1;

		// Token: 0x04013ED8 RID: 81624
		internal static int __PropertyOffset_2;

		// Token: 0x04013ED9 RID: 81625
		[Nullable(new byte[]
		{
			2,
			0
		})]
		private TArray<TEnumAsByte<ECharacterMeshPart>> _SpecifiedParts;

		// Token: 0x04013EDA RID: 81626
		internal static int __PropertyOffset_3;

		// Token: 0x04013EDB RID: 81627
		internal static int __PropertyOffset_4;

		// Token: 0x04013EDC RID: 81628
		internal static int __PropertyOffset_5;

		// Token: 0x04013EDD RID: 81629
		internal static int __PropertyOffset_6;

		// Token: 0x04013EDE RID: 81630
		internal static int __PropertyOffset_7;

		// Token: 0x04013EDF RID: 81631
		internal static int __PropertyOffset_8;

		// Token: 0x04013EE0 RID: 81632
		internal static int __PropertyOffset_9;

		// Token: 0x04013EE1 RID: 81633
		internal static int __PropertyOffset_10;

		// Token: 0x04013EE2 RID: 81634
		internal static int __PropertyOffset_11;

		// Token: 0x04013EE3 RID: 81635
		internal static int __PropertyOffset_12;

		// Token: 0x04013EE4 RID: 81636
		internal static int __PropertyOffset_13;

		// Token: 0x04013EE5 RID: 81637
		internal static int __PropertyOffset_14;

		// Token: 0x04013EE6 RID: 81638
		internal static int __PropertyOffset_15;

		// Token: 0x04013EE7 RID: 81639
		internal static int __PropertyOffset_16;

		// Token: 0x04013EE8 RID: 81640
		[Nullable(2)]
		private SMaterialControllerFloatGroup _RimRange;

		// Token: 0x04013EE9 RID: 81641
		internal static int __PropertyOffset_17;

		// Token: 0x04013EEA RID: 81642
		[Nullable(2)]
		private SMaterialControllerColorGroup _RimColor;

		// Token: 0x04013EEB RID: 81643
		internal static int __PropertyOffset_18;

		// Token: 0x04013EEC RID: 81644
		internal static int __PropertyOffset_19;

		// Token: 0x04013EED RID: 81645
		[Nullable(2)]
		private SMaterialControllerFloatGroup _OutlineWidth;

		// Token: 0x04013EEE RID: 81646
		internal static int __PropertyOffset_20;

		// Token: 0x04013EEF RID: 81647
		[Nullable(2)]
		private SMaterialControllerColorGroup _OutlineColor;

		// Token: 0x04013EF0 RID: 81648
		internal static int __PropertyOffset_21;

		// Token: 0x04013EF1 RID: 81649
		internal static int __PropertyOffset_22;

		// Token: 0x04013EF2 RID: 81650
		internal static int __PropertyOffset_23;

		// Token: 0x04013EF3 RID: 81651
		[Nullable(2)]
		private SMaterialControllerFloatGroup _DissolveProgress;

		// Token: 0x04013EF4 RID: 81652
		internal static int __PropertyOffset_24;

		// Token: 0x04013EF5 RID: 81653
		[Nullable(2)]
		private SMaterialControllerColorGroup _DissolveColor;

		// Token: 0x04013EF6 RID: 81654
		internal static int __PropertyOffset_25;

		// Token: 0x04013EF7 RID: 81655
		[Nullable(2)]
		private SMaterialControllerFloatGroup _DissolveColorIntensity;

		// Token: 0x04013EF8 RID: 81656
		internal static int __PropertyOffset_26;

		// Token: 0x04013EF9 RID: 81657
		internal static int __PropertyOffset_27;

		// Token: 0x04013EFA RID: 81658
		internal static int __PropertyOffset_28;

		// Token: 0x04013EFB RID: 81659
		internal static int __PropertyOffset_29;

		// Token: 0x04013EFC RID: 81660
		internal static int __PropertyOffset_30;

		// Token: 0x04013EFD RID: 81661
		[Nullable(2)]
		private SMaterialControllerFloatGroup _Rotation;

		// Token: 0x04013EFE RID: 81662
		internal static int __PropertyOffset_31;

		// Token: 0x04013EFF RID: 81663
		internal static int __PropertyOffset_32;

		// Token: 0x04013F00 RID: 81664
		[Nullable(2)]
		private SMaterialControllerColorGroup _TextureScaleAndOffset;

		// Token: 0x04013F01 RID: 81665
		internal static int __PropertyOffset_33;

		// Token: 0x04013F02 RID: 81666
		[Nullable(2)]
		private SMaterialControllerColorGroup _TextureSpeed;

		// Token: 0x04013F03 RID: 81667
		internal static int __PropertyOffset_34;

		// Token: 0x04013F04 RID: 81668
		[Nullable(2)]
		private SMaterialControllerColorGroup _TextureColorTint;

		// Token: 0x04013F05 RID: 81669
		internal static int __PropertyOffset_35;

		// Token: 0x04013F06 RID: 81670
		[Nullable(2)]
		private SMaterialControllerFloatGroup _OutlineIntensity;

		// Token: 0x04013F07 RID: 81671
		internal static int __PropertyOffset_36;

		// Token: 0x04013F08 RID: 81672
		internal static int __PropertyOffset_37;

		// Token: 0x04013F09 RID: 81673
		internal static int __PropertyOffset_38;

		// Token: 0x04013F0A RID: 81674
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SMaterialControllerFloatParameter> _FloatParameters;

		// Token: 0x04013F0B RID: 81675
		internal static int __PropertyOffset_39;

		// Token: 0x04013F0C RID: 81676
		internal static int __PropertyOffset_40;

		// Token: 0x04013F0D RID: 81677
		internal static int __PropertyOffset_41;

		// Token: 0x04013F0E RID: 81678
		internal static int __PropertyOffset_42;

		// Token: 0x04013F0F RID: 81679
		[Nullable(2)]
		private SMaterialControllerColorGroup _BaseColor;

		// Token: 0x04013F10 RID: 81680
		internal static int __PropertyOffset_43;

		// Token: 0x04013F11 RID: 81681
		[Nullable(2)]
		private SMaterialControllerFloatGroup _BaseColorIntensity;

		// Token: 0x04013F12 RID: 81682
		internal static int __PropertyOffset_44;

		// Token: 0x04013F13 RID: 81683
		internal static int __PropertyOffset_45;

		// Token: 0x04013F14 RID: 81684
		[Nullable(2)]
		private SMaterialControllerColorGroup _EmissionColor;

		// Token: 0x04013F15 RID: 81685
		internal static int __PropertyOffset_46;

		// Token: 0x04013F16 RID: 81686
		[Nullable(2)]
		private SMaterialControllerFloatGroup _EmissionIntensity;

		// Token: 0x04013F17 RID: 81687
		internal static int __PropertyOffset_47;

		// Token: 0x04013F18 RID: 81688
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SMaterialControllerColorParameter> _ColorParameters;

		// Token: 0x04013F19 RID: 81689
		internal static int __PropertyOffset_48;

		// Token: 0x04013F1A RID: 81690
		internal static int __PropertyOffset_49;

		// Token: 0x04013F1B RID: 81691
		internal static int __PropertyOffset_50;

		// Token: 0x04013F1C RID: 81692
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SMaterialControllerFloatParameter> _CustomFloatParameters;

		// Token: 0x04013F1D RID: 81693
		internal static int __PropertyOffset_51;

		// Token: 0x04013F1E RID: 81694
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SMaterialControllerColorParameter> _CustomColorParameters;

		// Token: 0x04013F1F RID: 81695
		internal static int __PropertyOffset_52;

		// Token: 0x04013F20 RID: 81696
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SMaterialControllerTextureParameter> _CustomTextureParameters;

		// Token: 0x04013F21 RID: 81697
		internal static int __PropertyOffset_53;

		// Token: 0x04013F22 RID: 81698
		internal static int __PropertyOffset_54;

		// Token: 0x04013F23 RID: 81699
		internal static int __PropertyOffset_55;

		// Token: 0x04013F24 RID: 81700
		internal static int __PropertyOffset_56;

		// Token: 0x04013F25 RID: 81701
		internal static int __PropertyOffset_57;

		// Token: 0x04013F26 RID: 81702
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<string> _WeaponCases;

		// Token: 0x04013F27 RID: 81703
		internal static int __PropertyOffset_58;

		// Token: 0x04013F28 RID: 81704
		internal static int __PropertyOffset_59;

		// Token: 0x04013F29 RID: 81705
		internal static int __PropertyOffset_60;

		// Token: 0x04013F2A RID: 81706
		[Nullable(2)]
		private SMaterialControllerFloatGroup _DissolveSmooth;

		// Token: 0x04013F2B RID: 81707
		internal static int __PropertyOffset_61;

		// Token: 0x04013F2C RID: 81708
		[Nullable(2)]
		private SMaterialControllerFloatGroup _MotionNoiseSpeed;

		// Token: 0x04013F2D RID: 81709
		internal static int __PropertyOffset_62;

		// Token: 0x04013F2E RID: 81710
		internal static int __PropertyOffset_63;

		// Token: 0x04013F2F RID: 81711
		internal static int __PropertyOffset_64;

		// Token: 0x04013F30 RID: 81712
		[Nullable(2)]
		private SMaterialControllerFloatGroup _DitherValue;

		// Token: 0x04013F31 RID: 81713
		internal static int __PropertyOffset_65;

		// Token: 0x04013F32 RID: 81714
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<string> _OtherCases;

		// Token: 0x04013F33 RID: 81715
		internal static int __PropertyOffset_66;

		// Token: 0x04013F34 RID: 81716
		[Nullable(2)]
		private SMaterialControllerFloatGroup _RimIntensity;

		// Token: 0x04013F35 RID: 81717
		internal static int __PropertyOffset_67;

		// Token: 0x04013F36 RID: 81718
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<string> _CustomPartNames;

		// Token: 0x04013F37 RID: 81719
		internal static int __PropertyOffset_68;

		// Token: 0x04013F38 RID: 81720
		[Nullable(2)]
		private SMaterialControllerFloatGroup _TextureMaskRange;

		// Token: 0x04013F39 RID: 81721
		internal static int __PropertyOffset_69;

		// Token: 0x04013F3A RID: 81722
		internal static int __PropertyOffset_70;

		// Token: 0x04013F3B RID: 81723
		internal static int __PropertyOffset_71;

		// Token: 0x04013F3C RID: 81724
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<string> _CustomExcludePartNames;

		// Token: 0x04013F3D RID: 81725
		internal static int __PropertyOffset_72;

		// Token: 0x04013F3E RID: 81726
		internal static int __PropertyOffset_73;

		// Token: 0x04013F3F RID: 81727
		internal static int __PropertyOffset_74;

		// Token: 0x04013F40 RID: 81728
		internal static int __PropertyOffset_75;

		// Token: 0x04013F41 RID: 81729
		internal static int __PropertyOffset_76;

		// Token: 0x04013F42 RID: 81730
		private static IntPtr __InitCache_NativeFunctionPtr;
	}
}
