using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Interaction
{
	// Token: 0x02003C75 RID: 15477
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Interaction/BP_CameraShot.BP_CameraShot_C")]
	[UnrealStructLayout(1464, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1464)]
	public class BP_CameraShot_C : AKuroEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06023EB2 RID: 147122 RVA: 0x0098FB1C File Offset: 0x0098DD1C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_CameraShot_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Interaction/BP_CameraShot.BP_CameraShot_C");
			}
			return BP_CameraShot_C._ClassPtr;
		}

		// Token: 0x06023EB3 RID: 147123 RVA: 0x0098FB40 File Offset: 0x0098DD40
		public BP_CameraShot_C() : this(BuiltinUtils.AllocNativeUObject(BP_CameraShot_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06023EB4 RID: 147124 RVA: 0x0098FB68 File Offset: 0x0098DD68
		[NullableContext(1)]
		public BP_CameraShot_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_CameraShot_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17004905 RID: 18693
		// (get) Token: 0x06023EB5 RID: 147125 RVA: 0x0098FB9C File Offset: 0x0098DD9C
		// (set) Token: 0x06023EB6 RID: 147126 RVA: 0x0098FBD5 File Offset: 0x0098DDD5
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_CameraShot_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_CameraShot_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17004906 RID: 18694
		// (get) Token: 0x06023EB7 RID: 147127 RVA: 0x0098FBF6 File Offset: 0x0098DDF6
		// (set) Token: 0x06023EB8 RID: 147128 RVA: 0x0098FC0A File Offset: 0x0098DE0A
		public unsafe UKuroGameBudgetComponent KuroGameBudget
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroGameBudgetComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CameraShot_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CameraShot_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17004907 RID: 18695
		// (get) Token: 0x06023EB9 RID: 147129 RVA: 0x0098FC1F File Offset: 0x0098DE1F
		// (set) Token: 0x06023EBA RID: 147130 RVA: 0x0098FC33 File Offset: 0x0098DE33
		public unsafe UKuroPostProcessComponent KuroPostProcess
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroPostProcessComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CameraShot_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CameraShot_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17004908 RID: 18696
		// (get) Token: 0x06023EBB RID: 147131 RVA: 0x0098FC48 File Offset: 0x0098DE48
		// (set) Token: 0x06023EBC RID: 147132 RVA: 0x0098FC5C File Offset: 0x0098DE5C
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CameraShot_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CameraShot_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17004909 RID: 18697
		// (get) Token: 0x06023EBD RID: 147133 RVA: 0x0098FC71 File Offset: 0x0098DE71
		// (set) Token: 0x06023EBE RID: 147134 RVA: 0x0098FC81 File Offset: 0x0098DE81
		public unsafe float BackgroundStrength
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraShot_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraShot_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x1700490A RID: 18698
		// (get) Token: 0x06023EBF RID: 147135 RVA: 0x0098FC92 File Offset: 0x0098DE92
		// (set) Token: 0x06023EC0 RID: 147136 RVA: 0x0098FCA6 File Offset: 0x0098DEA6
		public unsafe UMaterialInterface Material
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInterface>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CameraShot_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CameraShot_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x1700490B RID: 18699
		// (get) Token: 0x06023EC1 RID: 147137 RVA: 0x0098FCBB File Offset: 0x0098DEBB
		// (set) Token: 0x06023EC2 RID: 147138 RVA: 0x0098FCCF File Offset: 0x0098DECF
		public unsafe UMaterialInstanceDynamic DynamicMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CameraShot_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CameraShot_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x1700490C RID: 18700
		// (get) Token: 0x06023EC3 RID: 147139 RVA: 0x0098FCE4 File Offset: 0x0098DEE4
		// (set) Token: 0x06023EC4 RID: 147140 RVA: 0x0098FCF4 File Offset: 0x0098DEF4
		public unsafe float RotationAngle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraShot_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraShot_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x1700490D RID: 18701
		// (get) Token: 0x06023EC5 RID: 147141 RVA: 0x0098FD05 File Offset: 0x0098DF05
		// (set) Token: 0x06023EC6 RID: 147142 RVA: 0x0098FD15 File Offset: 0x0098DF15
		public unsafe float BlurIntensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraShot_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraShot_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x1700490E RID: 18702
		// (get) Token: 0x06023EC7 RID: 147143 RVA: 0x0098FD26 File Offset: 0x0098DF26
		// (set) Token: 0x06023EC8 RID: 147144 RVA: 0x0098FD36 File Offset: 0x0098DF36
		public unsafe float CircleRadius
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraShot_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraShot_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x1700490F RID: 18703
		// (get) Token: 0x06023EC9 RID: 147145 RVA: 0x0098FD47 File Offset: 0x0098DF47
		// (set) Token: 0x06023ECA RID: 147146 RVA: 0x0098FD57 File Offset: 0x0098DF57
		public unsafe float FrameThickness
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraShot_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraShot_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17004910 RID: 18704
		// (get) Token: 0x06023ECB RID: 147147 RVA: 0x0098FD68 File Offset: 0x0098DF68
		// (set) Token: 0x06023ECC RID: 147148 RVA: 0x0098FD78 File Offset: 0x0098DF78
		public unsafe float mode
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraShot_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraShot_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17004911 RID: 18705
		// (get) Token: 0x06023ECD RID: 147149 RVA: 0x0098FD89 File Offset: 0x0098DF89
		// (set) Token: 0x06023ECE RID: 147150 RVA: 0x0098FD99 File Offset: 0x0098DF99
		public unsafe float FrameX
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraShot_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraShot_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17004912 RID: 18706
		// (get) Token: 0x06023ECF RID: 147151 RVA: 0x0098FDAA File Offset: 0x0098DFAA
		// (set) Token: 0x06023ED0 RID: 147152 RVA: 0x0098FDBA File Offset: 0x0098DFBA
		public unsafe float FrameY
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraShot_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraShot_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17004913 RID: 18707
		// (get) Token: 0x06023ED1 RID: 147153 RVA: 0x0098FDCB File Offset: 0x0098DFCB
		// (set) Token: 0x06023ED2 RID: 147154 RVA: 0x0098FDDB File Offset: 0x0098DFDB
		public unsafe float Line1X
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraShot_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraShot_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x17004914 RID: 18708
		// (get) Token: 0x06023ED3 RID: 147155 RVA: 0x0098FDEC File Offset: 0x0098DFEC
		// (set) Token: 0x06023ED4 RID: 147156 RVA: 0x0098FDFC File Offset: 0x0098DFFC
		public unsafe float Line1Y
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraShot_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraShot_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x17004915 RID: 18709
		// (get) Token: 0x06023ED5 RID: 147157 RVA: 0x0098FE0D File Offset: 0x0098E00D
		// (set) Token: 0x06023ED6 RID: 147158 RVA: 0x0098FE1D File Offset: 0x0098E01D
		public unsafe float Line2X
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraShot_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraShot_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x17004916 RID: 18710
		// (get) Token: 0x06023ED7 RID: 147159 RVA: 0x0098FE2E File Offset: 0x0098E02E
		// (set) Token: 0x06023ED8 RID: 147160 RVA: 0x0098FE3E File Offset: 0x0098E03E
		public unsafe float Line2Y
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraShot_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraShot_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x17004917 RID: 18711
		// (get) Token: 0x06023ED9 RID: 147161 RVA: 0x0098FE4F File Offset: 0x0098E04F
		// (set) Token: 0x06023EDA RID: 147162 RVA: 0x0098FE5F File Offset: 0x0098E05F
		public unsafe float LineAlpha
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraShot_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraShot_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x17004918 RID: 18712
		// (get) Token: 0x06023EDB RID: 147163 RVA: 0x0098FE70 File Offset: 0x0098E070
		// (set) Token: 0x06023EDC RID: 147164 RVA: 0x0098FE80 File Offset: 0x0098E080
		public unsafe float LineThickness
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraShot_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraShot_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x17004919 RID: 18713
		// (get) Token: 0x06023EDD RID: 147165 RVA: 0x0098FE91 File Offset: 0x0098E091
		// (set) Token: 0x06023EDE RID: 147166 RVA: 0x0098FEA1 File Offset: 0x0098E0A1
		public unsafe float EmissionPower
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraShot_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraShot_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x1700491A RID: 18714
		// (get) Token: 0x06023EDF RID: 147167 RVA: 0x0098FEB2 File Offset: 0x0098E0B2
		// (set) Token: 0x06023EE0 RID: 147168 RVA: 0x0098FEC2 File Offset: 0x0098E0C2
		public unsafe float EmissionRange
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraShot_C.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraShot_C.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x1700491B RID: 18715
		// (get) Token: 0x06023EE1 RID: 147169 RVA: 0x0098FED3 File Offset: 0x0098E0D3
		// (set) Token: 0x06023EE2 RID: 147170 RVA: 0x0098FEE3 File Offset: 0x0098E0E3
		public unsafe float EmissionStrength
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraShot_C.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraShot_C.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x1700491C RID: 18716
		// (get) Token: 0x06023EE3 RID: 147171 RVA: 0x0098FEF4 File Offset: 0x0098E0F4
		// (set) Token: 0x06023EE4 RID: 147172 RVA: 0x0098FF04 File Offset: 0x0098E104
		public unsafe float ShadowPower
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraShot_C.__PropertyOffset_23);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraShot_C.__PropertyOffset_23) = value;
			}
		}

		// Token: 0x1700491D RID: 18717
		// (get) Token: 0x06023EE5 RID: 147173 RVA: 0x0098FF15 File Offset: 0x0098E115
		// (set) Token: 0x06023EE6 RID: 147174 RVA: 0x0098FF25 File Offset: 0x0098E125
		public unsafe float ShadowRange
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraShot_C.__PropertyOffset_24);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraShot_C.__PropertyOffset_24) = value;
			}
		}

		// Token: 0x1700491E RID: 18718
		// (get) Token: 0x06023EE7 RID: 147175 RVA: 0x0098FF36 File Offset: 0x0098E136
		// (set) Token: 0x06023EE8 RID: 147176 RVA: 0x0098FF46 File Offset: 0x0098E146
		public unsafe float ShadowStrength
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraShot_C.__PropertyOffset_25);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraShot_C.__PropertyOffset_25) = value;
			}
		}

		// Token: 0x1700491F RID: 18719
		// (get) Token: 0x06023EE9 RID: 147177 RVA: 0x0098FF57 File Offset: 0x0098E157
		// (set) Token: 0x06023EEA RID: 147178 RVA: 0x0098FF67 File Offset: 0x0098E167
		public unsafe float MaskWidth
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraShot_C.__PropertyOffset_26);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraShot_C.__PropertyOffset_26) = value;
			}
		}

		// Token: 0x17004920 RID: 18720
		// (get) Token: 0x06023EEB RID: 147179 RVA: 0x0098FF78 File Offset: 0x0098E178
		// (set) Token: 0x06023EEC RID: 147180 RVA: 0x0098FF88 File Offset: 0x0098E188
		public unsafe float MaskHeight
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraShot_C.__PropertyOffset_27);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraShot_C.__PropertyOffset_27) = value;
			}
		}

		// Token: 0x17004921 RID: 18721
		// (get) Token: 0x06023EED RID: 147181 RVA: 0x0098FF99 File Offset: 0x0098E199
		// (set) Token: 0x06023EEE RID: 147182 RVA: 0x0098FFAD File Offset: 0x0098E1AD
		public unsafe FColor MaskColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraShot_C.__PropertyOffset_28);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraShot_C.__PropertyOffset_28) = value;
			}
		}

		// Token: 0x17004922 RID: 18722
		// (get) Token: 0x06023EEF RID: 147183 RVA: 0x0098FFC2 File Offset: 0x0098E1C2
		// (set) Token: 0x06023EF0 RID: 147184 RVA: 0x0098FFD6 File Offset: 0x0098E1D6
		public unsafe FColor EmissionColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraShot_C.__PropertyOffset_29);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraShot_C.__PropertyOffset_29) = value;
			}
		}

		// Token: 0x17004923 RID: 18723
		// (get) Token: 0x06023EF1 RID: 147185 RVA: 0x0098FFEB File Offset: 0x0098E1EB
		// (set) Token: 0x06023EF2 RID: 147186 RVA: 0x0098FFFF File Offset: 0x0098E1FF
		public unsafe FColor ShadowColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraShot_C.__PropertyOffset_30);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraShot_C.__PropertyOffset_30) = value;
			}
		}

		// Token: 0x06023EF3 RID: 147187 RVA: 0x00990014 File Offset: 0x0098E214
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SetParameter()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CameraShot_C.__SetParameter_NativeFunctionPtr, null);
		}

		// Token: 0x06023EF4 RID: 147188 RVA: 0x00990028 File Offset: 0x0098E228
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 纯色遮罩()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CameraShot_C.__纯色遮罩_NativeFunctionPtr, null);
		}

		// Token: 0x06023EF5 RID: 147189 RVA: 0x0099003C File Offset: 0x0098E23C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 默认()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CameraShot_C.__默认_NativeFunctionPtr, null);
		}

		// Token: 0x06023EF6 RID: 147190 RVA: 0x00990050 File Offset: 0x0098E250
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 艺术画框()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CameraShot_C.__艺术画框_NativeFunctionPtr, null);
		}

		// Token: 0x06023EF7 RID: 147191 RVA: 0x00990064 File Offset: 0x0098E264
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CameraShot_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06023EF8 RID: 147192 RVA: 0x00990078 File Offset: 0x0098E278
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CameraShot_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06023EF9 RID: 147193 RVA: 0x0099008D File Offset: 0x0098E28D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CameraShot_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06023EFA RID: 147194 RVA: 0x009900A1 File Offset: 0x0098E2A1
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CameraShot_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06023EFB RID: 147195 RVA: 0x009900B8 File Offset: 0x0098E2B8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_CameraShot_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_CameraShot_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_CameraShot_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CameraShot_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CameraShot_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06023EFC RID: 147196 RVA: 0x00990100 File Offset: 0x0098E300
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_CameraShot_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_CameraShot_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_CameraShot_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CameraShot_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CameraShot_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06023EFD RID: 147197 RVA: 0x00990148 File Offset: 0x0098E348
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_CameraShot_C.__EditorTick_FunctionParams* ptr = stackalloc BP_CameraShot_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_CameraShot_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CameraShot_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CameraShot_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06023EFE RID: 147198 RVA: 0x00990190 File Offset: 0x0098E390
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_CameraShot_C.__EditorTick_FunctionParams* ptr = stackalloc BP_CameraShot_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_CameraShot_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CameraShot_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CameraShot_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06023EFF RID: 147199 RVA: 0x009901D8 File Offset: 0x0098E3D8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_CameraShot(int EntryPoint)
		{
			BP_CameraShot_C.__ExecuteUbergraph_BP_CameraShot_FunctionParams* ptr = stackalloc BP_CameraShot_C.__ExecuteUbergraph_BP_CameraShot_FunctionParams[(UIntPtr)95] + 15L / (long)sizeof(BP_CameraShot_C.__ExecuteUbergraph_BP_CameraShot_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CameraShot_C.__ExecuteUbergraph_BP_CameraShot_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CameraShot_C.__ExecuteUbergraph_BP_CameraShot_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06023F00 RID: 147200 RVA: 0x0099021F File Offset: 0x0098E41F
		protected BP_CameraShot_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401258F RID: 75151
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Interaction/BP_CameraShot.BP_CameraShot_C";

		// Token: 0x04012590 RID: 75152
		private static IntPtr _ClassPtr;

		// Token: 0x04012591 RID: 75153
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04012592 RID: 75154
		internal static int __PropertyOffset_0;

		// Token: 0x04012593 RID: 75155
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04012594 RID: 75156
		internal static int __PropertyOffset_1;

		// Token: 0x04012595 RID: 75157
		internal static int __PropertyOffset_2;

		// Token: 0x04012596 RID: 75158
		internal static int __PropertyOffset_3;

		// Token: 0x04012597 RID: 75159
		internal static int __PropertyOffset_4;

		// Token: 0x04012598 RID: 75160
		internal static int __PropertyOffset_5;

		// Token: 0x04012599 RID: 75161
		internal static int __PropertyOffset_6;

		// Token: 0x0401259A RID: 75162
		internal static int __PropertyOffset_7;

		// Token: 0x0401259B RID: 75163
		internal static int __PropertyOffset_8;

		// Token: 0x0401259C RID: 75164
		internal static int __PropertyOffset_9;

		// Token: 0x0401259D RID: 75165
		internal static int __PropertyOffset_10;

		// Token: 0x0401259E RID: 75166
		internal static int __PropertyOffset_11;

		// Token: 0x0401259F RID: 75167
		internal static int __PropertyOffset_12;

		// Token: 0x040125A0 RID: 75168
		internal static int __PropertyOffset_13;

		// Token: 0x040125A1 RID: 75169
		internal static int __PropertyOffset_14;

		// Token: 0x040125A2 RID: 75170
		internal static int __PropertyOffset_15;

		// Token: 0x040125A3 RID: 75171
		internal static int __PropertyOffset_16;

		// Token: 0x040125A4 RID: 75172
		internal static int __PropertyOffset_17;

		// Token: 0x040125A5 RID: 75173
		internal static int __PropertyOffset_18;

		// Token: 0x040125A6 RID: 75174
		internal static int __PropertyOffset_19;

		// Token: 0x040125A7 RID: 75175
		internal static int __PropertyOffset_20;

		// Token: 0x040125A8 RID: 75176
		internal static int __PropertyOffset_21;

		// Token: 0x040125A9 RID: 75177
		internal static int __PropertyOffset_22;

		// Token: 0x040125AA RID: 75178
		internal static int __PropertyOffset_23;

		// Token: 0x040125AB RID: 75179
		internal static int __PropertyOffset_24;

		// Token: 0x040125AC RID: 75180
		internal static int __PropertyOffset_25;

		// Token: 0x040125AD RID: 75181
		internal static int __PropertyOffset_26;

		// Token: 0x040125AE RID: 75182
		internal static int __PropertyOffset_27;

		// Token: 0x040125AF RID: 75183
		internal static int __PropertyOffset_28;

		// Token: 0x040125B0 RID: 75184
		internal static int __PropertyOffset_29;

		// Token: 0x040125B1 RID: 75185
		internal static int __PropertyOffset_30;

		// Token: 0x040125B2 RID: 75186
		private static IntPtr __SetParameter_NativeFunctionPtr;

		// Token: 0x040125B3 RID: 75187
		private static IntPtr __纯色遮罩_NativeFunctionPtr;

		// Token: 0x040125B4 RID: 75188
		private static IntPtr __默认_NativeFunctionPtr;

		// Token: 0x040125B5 RID: 75189
		private static IntPtr __艺术画框_NativeFunctionPtr;

		// Token: 0x040125B6 RID: 75190
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x040125B7 RID: 75191
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x040125B8 RID: 75192
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x040125B9 RID: 75193
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x040125BA RID: 75194
		private static IntPtr __ExecuteUbergraph_BP_CameraShot_NativeFunctionPtr;

		// Token: 0x02009D63 RID: 40291
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032758 RID: 206680
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009D64 RID: 40292
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x04032759 RID: 206681
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009D65 RID: 40293
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 80)]
		protected ref struct __ExecuteUbergraph_BP_CameraShot_FunctionParams
		{
			// Token: 0x0403275A RID: 206682
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
