using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Light.Performance
{
	// Token: 0x02003AB0 RID: 15024
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Light/Performance/BP_PostInnerGlow.BP_PostInnerGlow_C")]
	[UnrealStructLayout(1528, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1528)]
	public class BP_PostInnerGlow_C : AKuroEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06020039 RID: 131129 RVA: 0x0091FE6B File Offset: 0x0091E06B
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_PostInnerGlow_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Light/Performance/BP_PostInnerGlow.BP_PostInnerGlow_C");
			}
			return BP_PostInnerGlow_C._ClassPtr;
		}

		// Token: 0x0602003A RID: 131130 RVA: 0x0091FE90 File Offset: 0x0091E090
		public BP_PostInnerGlow_C() : this(BuiltinUtils.AllocNativeUObject(BP_PostInnerGlow_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602003B RID: 131131 RVA: 0x0091FEB8 File Offset: 0x0091E0B8
		[NullableContext(1)]
		public BP_PostInnerGlow_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_PostInnerGlow_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003378 RID: 13176
		// (get) Token: 0x0602003C RID: 131132 RVA: 0x0091FEEC File Offset: 0x0091E0EC
		// (set) Token: 0x0602003D RID: 131133 RVA: 0x0091FF25 File Offset: 0x0091E125
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_PostInnerGlow_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_PostInnerGlow_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003379 RID: 13177
		// (get) Token: 0x0602003E RID: 131134 RVA: 0x0091FF46 File Offset: 0x0091E146
		// (set) Token: 0x0602003F RID: 131135 RVA: 0x0091FF5A File Offset: 0x0091E15A
		public unsafe UKuroPostProcessComponent KuroPostProcess
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroPostProcessComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PostInnerGlow_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PostInnerGlow_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x1700337A RID: 13178
		// (get) Token: 0x06020040 RID: 131136 RVA: 0x0091FF6F File Offset: 0x0091E16F
		// (set) Token: 0x06020041 RID: 131137 RVA: 0x0091FF83 File Offset: 0x0091E183
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PostInnerGlow_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PostInnerGlow_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x1700337B RID: 13179
		// (get) Token: 0x06020042 RID: 131138 RVA: 0x0091FF98 File Offset: 0x0091E198
		// (set) Token: 0x06020043 RID: 131139 RVA: 0x0091FFAC File Offset: 0x0091E1AC
		public unsafe UMaterialInstanceDynamic DynamicMaterial_3
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PostInnerGlow_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PostInnerGlow_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x1700337C RID: 13180
		// (get) Token: 0x06020044 RID: 131140 RVA: 0x0091FFC1 File Offset: 0x0091E1C1
		// (set) Token: 0x06020045 RID: 131141 RVA: 0x0091FFD1 File Offset: 0x0091E1D1
		public unsafe float OffsetX
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PostInnerGlow_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PostInnerGlow_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x1700337D RID: 13181
		// (get) Token: 0x06020046 RID: 131142 RVA: 0x0091FFE2 File Offset: 0x0091E1E2
		// (set) Token: 0x06020047 RID: 131143 RVA: 0x0091FFF2 File Offset: 0x0091E1F2
		public unsafe float OffsetY
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PostInnerGlow_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PostInnerGlow_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x1700337E RID: 13182
		// (get) Token: 0x06020048 RID: 131144 RVA: 0x00920003 File Offset: 0x0091E203
		// (set) Token: 0x06020049 RID: 131145 RVA: 0x00920013 File Offset: 0x0091E213
		public unsafe float Intensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PostInnerGlow_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PostInnerGlow_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x1700337F RID: 13183
		// (get) Token: 0x0602004A RID: 131146 RVA: 0x00920024 File Offset: 0x0091E224
		// (set) Token: 0x0602004B RID: 131147 RVA: 0x00920038 File Offset: 0x0091E238
		public unsafe UMaterial Material_1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterial>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PostInnerGlow_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PostInnerGlow_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x17003380 RID: 13184
		// (get) Token: 0x0602004C RID: 131148 RVA: 0x0092004D File Offset: 0x0091E24D
		// (set) Token: 0x0602004D RID: 131149 RVA: 0x00920061 File Offset: 0x0091E261
		public unsafe FLinearColor Color
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PostInnerGlow_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PostInnerGlow_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17003381 RID: 13185
		// (get) Token: 0x0602004E RID: 131150 RVA: 0x00920076 File Offset: 0x0091E276
		// (set) Token: 0x0602004F RID: 131151 RVA: 0x00920086 File Offset: 0x0091E286
		public unsafe float Range
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PostInnerGlow_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PostInnerGlow_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17003382 RID: 13186
		// (get) Token: 0x06020050 RID: 131152 RVA: 0x00920097 File Offset: 0x0091E297
		// (set) Token: 0x06020051 RID: 131153 RVA: 0x009200A7 File Offset: 0x0091E2A7
		public unsafe int ToonDepth
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PostInnerGlow_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PostInnerGlow_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17003383 RID: 13187
		// (get) Token: 0x06020052 RID: 131154 RVA: 0x009200B8 File Offset: 0x0091E2B8
		// (set) Token: 0x06020053 RID: 131155 RVA: 0x009200C8 File Offset: 0x0091E2C8
		public unsafe float OffsetX_2
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PostInnerGlow_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PostInnerGlow_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17003384 RID: 13188
		// (get) Token: 0x06020054 RID: 131156 RVA: 0x009200D9 File Offset: 0x0091E2D9
		// (set) Token: 0x06020055 RID: 131157 RVA: 0x009200E9 File Offset: 0x0091E2E9
		public unsafe float OffsetX_3
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PostInnerGlow_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PostInnerGlow_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17003385 RID: 13189
		// (get) Token: 0x06020056 RID: 131158 RVA: 0x009200FA File Offset: 0x0091E2FA
		// (set) Token: 0x06020057 RID: 131159 RVA: 0x0092010A File Offset: 0x0091E30A
		public unsafe float OffsetY_2
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PostInnerGlow_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PostInnerGlow_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17003386 RID: 13190
		// (get) Token: 0x06020058 RID: 131160 RVA: 0x0092011B File Offset: 0x0091E31B
		// (set) Token: 0x06020059 RID: 131161 RVA: 0x0092012B File Offset: 0x0091E32B
		public unsafe float OffsetY_3
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PostInnerGlow_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PostInnerGlow_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x17003387 RID: 13191
		// (get) Token: 0x0602005A RID: 131162 RVA: 0x0092013C File Offset: 0x0091E33C
		// (set) Token: 0x0602005B RID: 131163 RVA: 0x0092014C File Offset: 0x0091E34C
		public unsafe float Intensity_2
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PostInnerGlow_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PostInnerGlow_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x17003388 RID: 13192
		// (get) Token: 0x0602005C RID: 131164 RVA: 0x0092015D File Offset: 0x0091E35D
		// (set) Token: 0x0602005D RID: 131165 RVA: 0x0092016D File Offset: 0x0091E36D
		public unsafe float Intensity_3
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PostInnerGlow_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PostInnerGlow_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x17003389 RID: 13193
		// (get) Token: 0x0602005E RID: 131166 RVA: 0x0092017E File Offset: 0x0091E37E
		// (set) Token: 0x0602005F RID: 131167 RVA: 0x00920192 File Offset: 0x0091E392
		public unsafe FLinearColor Color_2
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PostInnerGlow_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PostInnerGlow_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x1700338A RID: 13194
		// (get) Token: 0x06020060 RID: 131168 RVA: 0x009201A7 File Offset: 0x0091E3A7
		// (set) Token: 0x06020061 RID: 131169 RVA: 0x009201BB File Offset: 0x0091E3BB
		public unsafe FLinearColor Color_3
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PostInnerGlow_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PostInnerGlow_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x1700338B RID: 13195
		// (get) Token: 0x06020062 RID: 131170 RVA: 0x009201D0 File Offset: 0x0091E3D0
		// (set) Token: 0x06020063 RID: 131171 RVA: 0x009201E0 File Offset: 0x0091E3E0
		public unsafe float Range_2
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PostInnerGlow_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PostInnerGlow_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x1700338C RID: 13196
		// (get) Token: 0x06020064 RID: 131172 RVA: 0x009201F1 File Offset: 0x0091E3F1
		// (set) Token: 0x06020065 RID: 131173 RVA: 0x00920201 File Offset: 0x0091E401
		public unsafe float Range_3
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PostInnerGlow_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PostInnerGlow_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x1700338D RID: 13197
		// (get) Token: 0x06020066 RID: 131174 RVA: 0x00920212 File Offset: 0x0091E412
		// (set) Token: 0x06020067 RID: 131175 RVA: 0x00920226 File Offset: 0x0091E426
		public unsafe UMaterial Material_2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterial>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PostInnerGlow_C.__PropertyOffset_21);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PostInnerGlow_C.__PropertyOffset_21, value);
			}
		}

		// Token: 0x1700338E RID: 13198
		// (get) Token: 0x06020068 RID: 131176 RVA: 0x0092023B File Offset: 0x0091E43B
		// (set) Token: 0x06020069 RID: 131177 RVA: 0x0092024F File Offset: 0x0091E44F
		public unsafe UMaterialInstanceDynamic DynamicMaterial_2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PostInnerGlow_C.__PropertyOffset_22);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PostInnerGlow_C.__PropertyOffset_22, value);
			}
		}

		// Token: 0x1700338F RID: 13199
		// (get) Token: 0x0602006A RID: 131178 RVA: 0x00920264 File Offset: 0x0091E464
		// (set) Token: 0x0602006B RID: 131179 RVA: 0x00920278 File Offset: 0x0091E478
		public unsafe UMaterialInstanceDynamic DynamicMaterial_1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PostInnerGlow_C.__PropertyOffset_23);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PostInnerGlow_C.__PropertyOffset_23, value);
			}
		}

		// Token: 0x17003390 RID: 13200
		// (get) Token: 0x0602006C RID: 131180 RVA: 0x0092028D File Offset: 0x0091E48D
		// (set) Token: 0x0602006D RID: 131181 RVA: 0x009202A1 File Offset: 0x0091E4A1
		public unsafe UMaterial Material_3
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterial>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PostInnerGlow_C.__PropertyOffset_24);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PostInnerGlow_C.__PropertyOffset_24, value);
			}
		}

		// Token: 0x17003391 RID: 13201
		// (get) Token: 0x0602006E RID: 131182 RVA: 0x009202B8 File Offset: 0x0091E4B8
		// (set) Token: 0x0602006F RID: 131183 RVA: 0x009202F1 File Offset: 0x0091E4F1
		[Nullable(1)]
		public TArray<FWeightedBlendable> Post_Process_Materials_Array
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<FWeightedBlendable> result;
				if ((result = this._Post_Process_Materials_Array) == null)
				{
					result = (this._Post_Process_Materials_Array = new TArray<FWeightedBlendable>(base.NativePtr + (IntPtr)BP_PostInnerGlow_C.__PropertyOffset_25, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Post_Process_Materials_Array.CopyAssign(value);
			}
		}

		// Token: 0x17003392 RID: 13202
		// (get) Token: 0x06020070 RID: 131184 RVA: 0x009202FF File Offset: 0x0091E4FF
		// (set) Token: 0x06020071 RID: 131185 RVA: 0x0092030F File Offset: 0x0091E50F
		public unsafe float bUseNewColorBlend_1
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PostInnerGlow_C.__PropertyOffset_26);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PostInnerGlow_C.__PropertyOffset_26) = value;
			}
		}

		// Token: 0x17003393 RID: 13203
		// (get) Token: 0x06020072 RID: 131186 RVA: 0x00920320 File Offset: 0x0091E520
		// (set) Token: 0x06020073 RID: 131187 RVA: 0x00920330 File Offset: 0x0091E530
		public unsafe float bUseNewColorBlend_3
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PostInnerGlow_C.__PropertyOffset_27);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PostInnerGlow_C.__PropertyOffset_27) = value;
			}
		}

		// Token: 0x17003394 RID: 13204
		// (get) Token: 0x06020074 RID: 131188 RVA: 0x00920341 File Offset: 0x0091E541
		// (set) Token: 0x06020075 RID: 131189 RVA: 0x00920351 File Offset: 0x0091E551
		public unsafe float bUseNewColorBlend_2
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PostInnerGlow_C.__PropertyOffset_28);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PostInnerGlow_C.__PropertyOffset_28) = value;
			}
		}

		// Token: 0x17003395 RID: 13205
		// (get) Token: 0x06020076 RID: 131190 RVA: 0x00920362 File Offset: 0x0091E562
		// (set) Token: 0x06020077 RID: 131191 RVA: 0x00920372 File Offset: 0x0091E572
		public unsafe float Smooth_1
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PostInnerGlow_C.__PropertyOffset_29);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PostInnerGlow_C.__PropertyOffset_29) = value;
			}
		}

		// Token: 0x17003396 RID: 13206
		// (get) Token: 0x06020078 RID: 131192 RVA: 0x00920383 File Offset: 0x0091E583
		// (set) Token: 0x06020079 RID: 131193 RVA: 0x00920393 File Offset: 0x0091E593
		public unsafe float Smooth_2
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PostInnerGlow_C.__PropertyOffset_30);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PostInnerGlow_C.__PropertyOffset_30) = value;
			}
		}

		// Token: 0x17003397 RID: 13207
		// (get) Token: 0x0602007A RID: 131194 RVA: 0x009203A4 File Offset: 0x0091E5A4
		// (set) Token: 0x0602007B RID: 131195 RVA: 0x009203B4 File Offset: 0x0091E5B4
		public unsafe float Smooth_3
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PostInnerGlow_C.__PropertyOffset_31);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PostInnerGlow_C.__PropertyOffset_31) = value;
			}
		}

		// Token: 0x0602007C RID: 131196 RVA: 0x009203C5 File Offset: 0x0091E5C5
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SetPar()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PostInnerGlow_C.__SetPar_NativeFunctionPtr, null);
		}

		// Token: 0x0602007D RID: 131197 RVA: 0x009203D9 File Offset: 0x0091E5D9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SetPostMaterial()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PostInnerGlow_C.__SetPostMaterial_NativeFunctionPtr, null);
		}

		// Token: 0x0602007E RID: 131198 RVA: 0x009203F0 File Offset: 0x0091E5F0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetParameter(UMaterialInstanceDynamic MaterialInstance, float RimRange, float RimOffsetX, float RimOffsetY, float RimIntensity, FLinearColor RimColor, float bUseNewColorBlend, float Smooth)
		{
			BP_PostInnerGlow_C.__SetParameter_FunctionParams* ptr = stackalloc BP_PostInnerGlow_C.__SetParameter_FunctionParams[(UIntPtr)71] + 15L / (long)sizeof(BP_PostInnerGlow_C.__SetParameter_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_PostInnerGlow_C.__SetParameter_NativeFunctionPtr, (void*)ptr, 1);
			ptr->MaterialInstance = ((MaterialInstance != null) ? MaterialInstance.NativePtr : IntPtr.Zero);
			ptr->RimRange = RimRange;
			ptr->RimOffsetX = RimOffsetX;
			ptr->RimOffsetY = RimOffsetY;
			ptr->RimIntensity = RimIntensity;
			ptr->RimColor = RimColor;
			ptr->bUseNewColorBlend = bUseNewColorBlend;
			ptr->Smooth = Smooth;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PostInnerGlow_C.__SetParameter_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602007F RID: 131199 RVA: 0x0092047B File Offset: 0x0091E67B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PostInnerGlow_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06020080 RID: 131200 RVA: 0x0092048F File Offset: 0x0091E68F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_PostInnerGlow_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06020081 RID: 131201 RVA: 0x009204A4 File Offset: 0x0091E6A4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PostInnerGlow_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06020082 RID: 131202 RVA: 0x009204B8 File Offset: 0x0091E6B8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_PostInnerGlow_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06020083 RID: 131203 RVA: 0x009204D0 File Offset: 0x0091E6D0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_PostInnerGlow_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_PostInnerGlow_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_PostInnerGlow_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_PostInnerGlow_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PostInnerGlow_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06020084 RID: 131204 RVA: 0x00920518 File Offset: 0x0091E718
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_PostInnerGlow_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_PostInnerGlow_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_PostInnerGlow_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_PostInnerGlow_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_PostInnerGlow_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06020085 RID: 131205 RVA: 0x0092055F File Offset: 0x0091E75F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveDestroyed()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PostInnerGlow_C.__ReceiveDestroyed_NativeFunctionPtr, null);
		}

		// Token: 0x06020086 RID: 131206 RVA: 0x00920573 File Offset: 0x0091E773
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveDestroyed_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_PostInnerGlow_C.__ReceiveDestroyed_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06020087 RID: 131207 RVA: 0x00920588 File Offset: 0x0091E788
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_PostInnerGlow_C.__EditorTick_FunctionParams* ptr = stackalloc BP_PostInnerGlow_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_PostInnerGlow_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_PostInnerGlow_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PostInnerGlow_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06020088 RID: 131208 RVA: 0x009205D0 File Offset: 0x0091E7D0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_PostInnerGlow_C.__EditorTick_FunctionParams* ptr = stackalloc BP_PostInnerGlow_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_PostInnerGlow_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_PostInnerGlow_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_PostInnerGlow_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06020089 RID: 131209 RVA: 0x00920618 File Offset: 0x0091E818
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_PostInnerGlow(int EntryPoint)
		{
			BP_PostInnerGlow_C.__ExecuteUbergraph_BP_PostInnerGlow_FunctionParams* ptr = stackalloc BP_PostInnerGlow_C.__ExecuteUbergraph_BP_PostInnerGlow_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(BP_PostInnerGlow_C.__ExecuteUbergraph_BP_PostInnerGlow_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_PostInnerGlow_C.__ExecuteUbergraph_BP_PostInnerGlow_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_PostInnerGlow_C.__ExecuteUbergraph_BP_PostInnerGlow_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602008A RID: 131210 RVA: 0x0092065F File Offset: 0x0091E85F
		protected BP_PostInnerGlow_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400FF18 RID: 65304
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Light/Performance/BP_PostInnerGlow.BP_PostInnerGlow_C";

		// Token: 0x0400FF19 RID: 65305
		private static IntPtr _ClassPtr;

		// Token: 0x0400FF1A RID: 65306
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400FF1B RID: 65307
		internal static int __PropertyOffset_0;

		// Token: 0x0400FF1C RID: 65308
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400FF1D RID: 65309
		internal static int __PropertyOffset_1;

		// Token: 0x0400FF1E RID: 65310
		internal static int __PropertyOffset_2;

		// Token: 0x0400FF1F RID: 65311
		internal static int __PropertyOffset_3;

		// Token: 0x0400FF20 RID: 65312
		internal static int __PropertyOffset_4;

		// Token: 0x0400FF21 RID: 65313
		internal static int __PropertyOffset_5;

		// Token: 0x0400FF22 RID: 65314
		internal static int __PropertyOffset_6;

		// Token: 0x0400FF23 RID: 65315
		internal static int __PropertyOffset_7;

		// Token: 0x0400FF24 RID: 65316
		internal static int __PropertyOffset_8;

		// Token: 0x0400FF25 RID: 65317
		internal static int __PropertyOffset_9;

		// Token: 0x0400FF26 RID: 65318
		internal static int __PropertyOffset_10;

		// Token: 0x0400FF27 RID: 65319
		internal static int __PropertyOffset_11;

		// Token: 0x0400FF28 RID: 65320
		internal static int __PropertyOffset_12;

		// Token: 0x0400FF29 RID: 65321
		internal static int __PropertyOffset_13;

		// Token: 0x0400FF2A RID: 65322
		internal static int __PropertyOffset_14;

		// Token: 0x0400FF2B RID: 65323
		internal static int __PropertyOffset_15;

		// Token: 0x0400FF2C RID: 65324
		internal static int __PropertyOffset_16;

		// Token: 0x0400FF2D RID: 65325
		internal static int __PropertyOffset_17;

		// Token: 0x0400FF2E RID: 65326
		internal static int __PropertyOffset_18;

		// Token: 0x0400FF2F RID: 65327
		internal static int __PropertyOffset_19;

		// Token: 0x0400FF30 RID: 65328
		internal static int __PropertyOffset_20;

		// Token: 0x0400FF31 RID: 65329
		internal static int __PropertyOffset_21;

		// Token: 0x0400FF32 RID: 65330
		internal static int __PropertyOffset_22;

		// Token: 0x0400FF33 RID: 65331
		internal static int __PropertyOffset_23;

		// Token: 0x0400FF34 RID: 65332
		internal static int __PropertyOffset_24;

		// Token: 0x0400FF35 RID: 65333
		internal static int __PropertyOffset_25;

		// Token: 0x0400FF36 RID: 65334
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<FWeightedBlendable> _Post_Process_Materials_Array;

		// Token: 0x0400FF37 RID: 65335
		internal static int __PropertyOffset_26;

		// Token: 0x0400FF38 RID: 65336
		internal static int __PropertyOffset_27;

		// Token: 0x0400FF39 RID: 65337
		internal static int __PropertyOffset_28;

		// Token: 0x0400FF3A RID: 65338
		internal static int __PropertyOffset_29;

		// Token: 0x0400FF3B RID: 65339
		internal static int __PropertyOffset_30;

		// Token: 0x0400FF3C RID: 65340
		internal static int __PropertyOffset_31;

		// Token: 0x0400FF3D RID: 65341
		private static IntPtr __SetPar_NativeFunctionPtr;

		// Token: 0x0400FF3E RID: 65342
		private static IntPtr __SetPostMaterial_NativeFunctionPtr;

		// Token: 0x0400FF3F RID: 65343
		private static IntPtr __SetParameter_NativeFunctionPtr;

		// Token: 0x0400FF40 RID: 65344
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0400FF41 RID: 65345
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0400FF42 RID: 65346
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0400FF43 RID: 65347
		private static IntPtr __ReceiveDestroyed_NativeFunctionPtr;

		// Token: 0x0400FF44 RID: 65348
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x0400FF45 RID: 65349
		private static IntPtr __ExecuteUbergraph_BP_PostInnerGlow_NativeFunctionPtr;

		// Token: 0x02009949 RID: 39241
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 56)]
		protected ref struct __SetParameter_FunctionParams
		{
			// Token: 0x04031FA8 RID: 204712
			[FieldOffset(0)]
			public IntPtr MaterialInstance;

			// Token: 0x04031FA9 RID: 204713
			[FieldOffset(8)]
			public float RimRange;

			// Token: 0x04031FAA RID: 204714
			[FieldOffset(12)]
			public float RimOffsetX;

			// Token: 0x04031FAB RID: 204715
			[FieldOffset(16)]
			public float RimOffsetY;

			// Token: 0x04031FAC RID: 204716
			[FieldOffset(20)]
			public float RimIntensity;

			// Token: 0x04031FAD RID: 204717
			[FieldOffset(24)]
			public FLinearColor RimColor;

			// Token: 0x04031FAE RID: 204718
			[FieldOffset(40)]
			public float bUseNewColorBlend;

			// Token: 0x04031FAF RID: 204719
			[FieldOffset(44)]
			public float Smooth;
		}

		// Token: 0x0200994A RID: 39242
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04031FB0 RID: 204720
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x0200994B RID: 39243
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x04031FB1 RID: 204721
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x0200994C RID: 39244
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __ExecuteUbergraph_BP_PostInnerGlow_FunctionParams
		{
			// Token: 0x04031FB2 RID: 204722
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
