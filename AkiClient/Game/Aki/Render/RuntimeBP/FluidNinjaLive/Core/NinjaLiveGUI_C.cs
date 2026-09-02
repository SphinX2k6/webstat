using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.FluidNinjaLive.Core
{
	// Token: 0x02003D03 RID: 15619
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/FluidNinjaLive/Core/NinjaLiveGUI.NinjaLiveGUI_C")]
	[UnrealStructLayout(2040, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2040)]
	public class NinjaLiveGUI_C : UUserWidget, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06025A69 RID: 154217 RVA: 0x009C0533 File Offset: 0x009BE733
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (NinjaLiveGUI_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/FluidNinjaLive/Core/NinjaLiveGUI.NinjaLiveGUI_C");
			}
			return NinjaLiveGUI_C._ClassPtr;
		}

		// Token: 0x06025A6A RID: 154218 RVA: 0x009C0558 File Offset: 0x009BE758
		public NinjaLiveGUI_C() : this(BuiltinUtils.AllocNativeUObject(NinjaLiveGUI_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06025A6B RID: 154219 RVA: 0x009C0580 File Offset: 0x009BE780
		[NullableContext(1)]
		public NinjaLiveGUI_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(NinjaLiveGUI_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17005314 RID: 21268
		// (get) Token: 0x06025A6C RID: 154220 RVA: 0x009C05B4 File Offset: 0x009BE7B4
		// (set) Token: 0x06025A6D RID: 154221 RVA: 0x009C05ED File Offset: 0x009BE7ED
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)NinjaLiveGUI_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)NinjaLiveGUI_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005315 RID: 21269
		// (get) Token: 0x06025A6E RID: 154222 RVA: 0x009C060E File Offset: 0x009BE80E
		// (set) Token: 0x06025A6F RID: 154223 RVA: 0x009C0622 File Offset: 0x009BE822
		public unsafe UWidgetAnimation BlinkingText1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UWidgetAnimation>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17005316 RID: 21270
		// (get) Token: 0x06025A70 RID: 154224 RVA: 0x009C0637 File Offset: 0x009BE837
		// (set) Token: 0x06025A71 RID: 154225 RVA: 0x009C064B File Offset: 0x009BE84B
		public unsafe USpinBox _001_SpinBox_BrushSize
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USpinBox>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17005317 RID: 21271
		// (get) Token: 0x06025A72 RID: 154226 RVA: 0x009C0660 File Offset: 0x009BE860
		// (set) Token: 0x06025A73 RID: 154227 RVA: 0x009C0674 File Offset: 0x009BE874
		public unsafe USpinBox _002_SpinBox_BrushDensity
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USpinBox>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17005318 RID: 21272
		// (get) Token: 0x06025A74 RID: 154228 RVA: 0x009C0689 File Offset: 0x009BE889
		// (set) Token: 0x06025A75 RID: 154229 RVA: 0x009C069D File Offset: 0x009BE89D
		public unsafe USpinBox _003_SpinBox_BrushHardness
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USpinBox>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17005319 RID: 21273
		// (get) Token: 0x06025A76 RID: 154230 RVA: 0x009C06B2 File Offset: 0x009BE8B2
		// (set) Token: 0x06025A77 RID: 154231 RVA: 0x009C06C6 File Offset: 0x009BE8C6
		public unsafe USpinBox _004_SpinBox_BrushNoise
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USpinBox>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x1700531A RID: 21274
		// (get) Token: 0x06025A78 RID: 154232 RVA: 0x009C06DB File Offset: 0x009BE8DB
		// (set) Token: 0x06025A79 RID: 154233 RVA: 0x009C06EF File Offset: 0x009BE8EF
		public unsafe USpinBox _005_SpinBox_BrushRnd
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USpinBox>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x1700531B RID: 21275
		// (get) Token: 0x06025A7A RID: 154234 RVA: 0x009C0704 File Offset: 0x009BE904
		// (set) Token: 0x06025A7B RID: 154235 RVA: 0x009C0718 File Offset: 0x009BE918
		public unsafe USpinBox _006_SpinBox_BrushPersist
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USpinBox>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x1700531C RID: 21276
		// (get) Token: 0x06025A7C RID: 154236 RVA: 0x009C072D File Offset: 0x009BE92D
		// (set) Token: 0x06025A7D RID: 154237 RVA: 0x009C0741 File Offset: 0x009BE941
		public unsafe UCheckBox _007_Checkbox_BrushInvert
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCheckBox>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_8);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x1700531D RID: 21277
		// (get) Token: 0x06025A7E RID: 154238 RVA: 0x009C0756 File Offset: 0x009BE956
		// (set) Token: 0x06025A7F RID: 154239 RVA: 0x009C076A File Offset: 0x009BE96A
		public unsafe USpinBox _008_SpinBox_BrushDrag
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USpinBox>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_9);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_9, value);
			}
		}

		// Token: 0x1700531E RID: 21278
		// (get) Token: 0x06025A80 RID: 154240 RVA: 0x009C077F File Offset: 0x009BE97F
		// (set) Token: 0x06025A81 RID: 154241 RVA: 0x009C0793 File Offset: 0x009BE993
		public unsafe USpinBox _009_SpinBox_BrushPuncture
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USpinBox>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_10);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_10, value);
			}
		}

		// Token: 0x1700531F RID: 21279
		// (get) Token: 0x06025A82 RID: 154242 RVA: 0x009C07A8 File Offset: 0x009BE9A8
		// (set) Token: 0x06025A83 RID: 154243 RVA: 0x009C07BC File Offset: 0x009BE9BC
		public unsafe USpinBox _010_SpinBox_SimFeedback
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USpinBox>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_11);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_11, value);
			}
		}

		// Token: 0x17005320 RID: 21280
		// (get) Token: 0x06025A84 RID: 154244 RVA: 0x009C07D1 File Offset: 0x009BE9D1
		// (set) Token: 0x06025A85 RID: 154245 RVA: 0x009C07E5 File Offset: 0x009BE9E5
		public unsafe UButton _011_Button_SimClear
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UButton>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_12);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_12, value);
			}
		}

		// Token: 0x17005321 RID: 21281
		// (get) Token: 0x06025A86 RID: 154246 RVA: 0x009C07FA File Offset: 0x009BE9FA
		// (set) Token: 0x06025A87 RID: 154247 RVA: 0x009C080E File Offset: 0x009BEA0E
		public unsafe USpinBox _012_SpinBox_SimSpeed
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USpinBox>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_13);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_13, value);
			}
		}

		// Token: 0x17005322 RID: 21282
		// (get) Token: 0x06025A88 RID: 154248 RVA: 0x009C0823 File Offset: 0x009BEA23
		// (set) Token: 0x06025A89 RID: 154249 RVA: 0x009C0837 File Offset: 0x009BEA37
		public unsafe USpinBox _013_SpinBox_SimTurbulence
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USpinBox>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_14);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_14, value);
			}
		}

		// Token: 0x17005323 RID: 21283
		// (get) Token: 0x06025A8A RID: 154250 RVA: 0x009C084C File Offset: 0x009BEA4C
		// (set) Token: 0x06025A8B RID: 154251 RVA: 0x009C0860 File Offset: 0x009BEA60
		public unsafe USpinBox _014_SpinBox_VeloAmp
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USpinBox>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_15);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_15, value);
			}
		}

		// Token: 0x17005324 RID: 21284
		// (get) Token: 0x06025A8C RID: 154252 RVA: 0x009C0875 File Offset: 0x009BEA75
		// (set) Token: 0x06025A8D RID: 154253 RVA: 0x009C0889 File Offset: 0x009BEA89
		public unsafe USpinBox _015_SpinBox_VeloOffsetX
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USpinBox>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_16);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_16, value);
			}
		}

		// Token: 0x17005325 RID: 21285
		// (get) Token: 0x06025A8E RID: 154254 RVA: 0x009C089E File Offset: 0x009BEA9E
		// (set) Token: 0x06025A8F RID: 154255 RVA: 0x009C08B2 File Offset: 0x009BEAB2
		public unsafe USpinBox _016_SpinBox_VeloOffsetY
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USpinBox>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_17);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_17, value);
			}
		}

		// Token: 0x17005326 RID: 21286
		// (get) Token: 0x06025A90 RID: 154256 RVA: 0x009C08C7 File Offset: 0x009BEAC7
		// (set) Token: 0x06025A91 RID: 154257 RVA: 0x009C08DB File Offset: 0x009BEADB
		public unsafe USpinBox _017_SpinBox_VeloAmpNoise
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USpinBox>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_18);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_18, value);
			}
		}

		// Token: 0x17005327 RID: 21287
		// (get) Token: 0x06025A92 RID: 154258 RVA: 0x009C08F0 File Offset: 0x009BEAF0
		// (set) Token: 0x06025A93 RID: 154259 RVA: 0x009C0904 File Offset: 0x009BEB04
		public unsafe USpinBox _018_SpinBox_VeloDirNoise
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USpinBox>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_19);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_19, value);
			}
		}

		// Token: 0x17005328 RID: 21288
		// (get) Token: 0x06025A94 RID: 154260 RVA: 0x009C0919 File Offset: 0x009BEB19
		// (set) Token: 0x06025A95 RID: 154261 RVA: 0x009C092D File Offset: 0x009BEB2D
		public unsafe USpinBox _019_SpinBox_VeloDirNoiseSize
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USpinBox>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_20);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_20, value);
			}
		}

		// Token: 0x17005329 RID: 21289
		// (get) Token: 0x06025A96 RID: 154262 RVA: 0x009C0942 File Offset: 0x009BEB42
		// (set) Token: 0x06025A97 RID: 154263 RVA: 0x009C0956 File Offset: 0x009BEB56
		public unsafe USpinBox _020_SpinBox_VeloDirNoiseOffs
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USpinBox>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_21);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_21, value);
			}
		}

		// Token: 0x1700532A RID: 21290
		// (get) Token: 0x06025A98 RID: 154264 RVA: 0x009C096B File Offset: 0x009BEB6B
		// (set) Token: 0x06025A99 RID: 154265 RVA: 0x009C097F File Offset: 0x009BEB7F
		public unsafe UComboBoxString _021_ComboBox_VeloFromBitmap
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UComboBoxString>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_22);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_22, value);
			}
		}

		// Token: 0x1700532B RID: 21291
		// (get) Token: 0x06025A9A RID: 154266 RVA: 0x009C0994 File Offset: 0x009BEB94
		// (set) Token: 0x06025A9B RID: 154267 RVA: 0x009C09A8 File Offset: 0x009BEBA8
		public unsafe USpinBox _022_SpinBox_VeloRotate
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USpinBox>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_23);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_23, value);
			}
		}

		// Token: 0x1700532C RID: 21292
		// (get) Token: 0x06025A9C RID: 154268 RVA: 0x009C09BD File Offset: 0x009BEBBD
		// (set) Token: 0x06025A9D RID: 154269 RVA: 0x009C09D1 File Offset: 0x009BEBD1
		public unsafe USpinBox _023_SpinBox_VeloOffset
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USpinBox>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_24);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_24, value);
			}
		}

		// Token: 0x1700532D RID: 21293
		// (get) Token: 0x06025A9E RID: 154270 RVA: 0x009C09E6 File Offset: 0x009BEBE6
		// (set) Token: 0x06025A9F RID: 154271 RVA: 0x009C09FA File Offset: 0x009BEBFA
		public unsafe USpinBox _024_SpinBox_VeloTile
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USpinBox>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_25);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_25, value);
			}
		}

		// Token: 0x1700532E RID: 21294
		// (get) Token: 0x06025AA0 RID: 154272 RVA: 0x009C0A0F File Offset: 0x009BEC0F
		// (set) Token: 0x06025AA1 RID: 154273 RVA: 0x009C0A23 File Offset: 0x009BEC23
		public unsafe UBorder _024b_Border_Warning_VelocityFromBitmap
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBorder>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_26);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_26, value);
			}
		}

		// Token: 0x1700532F RID: 21295
		// (get) Token: 0x06025AA2 RID: 154274 RVA: 0x009C0A38 File Offset: 0x009BEC38
		// (set) Token: 0x06025AA3 RID: 154275 RVA: 0x009C0A4C File Offset: 0x009BEC4C
		public unsafe USpinBox _025_SimareaMoFx
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USpinBox>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_27);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_27, value);
			}
		}

		// Token: 0x17005330 RID: 21296
		// (get) Token: 0x06025AA4 RID: 154276 RVA: 0x009C0A61 File Offset: 0x009BEC61
		// (set) Token: 0x06025AA5 RID: 154277 RVA: 0x009C0A75 File Offset: 0x009BEC75
		public unsafe USpinBox _025_SimareaMoOffset
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USpinBox>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_28);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_28, value);
			}
		}

		// Token: 0x17005331 RID: 21297
		// (get) Token: 0x06025AA6 RID: 154278 RVA: 0x009C0A8A File Offset: 0x009BEC8A
		// (set) Token: 0x06025AA7 RID: 154279 RVA: 0x009C0A9E File Offset: 0x009BEC9E
		public unsafe UComboBoxString _026_ComboBox_DensFromBitmap
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UComboBoxString>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_29);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_29, value);
			}
		}

		// Token: 0x17005332 RID: 21298
		// (get) Token: 0x06025AA8 RID: 154280 RVA: 0x009C0AB3 File Offset: 0x009BECB3
		// (set) Token: 0x06025AA9 RID: 154281 RVA: 0x009C0AC7 File Offset: 0x009BECC7
		public unsafe UBorder _026b_Border_Warning_DensityFromBitmap
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBorder>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_30);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_30, value);
			}
		}

		// Token: 0x17005333 RID: 21299
		// (get) Token: 0x06025AAA RID: 154282 RVA: 0x009C0ADC File Offset: 0x009BECDC
		// (set) Token: 0x06025AAB RID: 154283 RVA: 0x009C0AF0 File Offset: 0x009BECF0
		public unsafe USpinBox _027_SpinBox_DensityOffsetX
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USpinBox>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_31);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_31, value);
			}
		}

		// Token: 0x17005334 RID: 21300
		// (get) Token: 0x06025AAC RID: 154284 RVA: 0x009C0B05 File Offset: 0x009BED05
		// (set) Token: 0x06025AAD RID: 154285 RVA: 0x009C0B19 File Offset: 0x009BED19
		public unsafe USpinBox _028_SpinBox_DensityOffsetY
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USpinBox>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_32);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_32, value);
			}
		}

		// Token: 0x17005335 RID: 21301
		// (get) Token: 0x06025AAE RID: 154286 RVA: 0x009C0B2E File Offset: 0x009BED2E
		// (set) Token: 0x06025AAF RID: 154287 RVA: 0x009C0B42 File Offset: 0x009BED42
		public unsafe USpinBox _029_SpinBox_DensityTile
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USpinBox>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_33);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_33, value);
			}
		}

		// Token: 0x17005336 RID: 21302
		// (get) Token: 0x06025AB0 RID: 154288 RVA: 0x009C0B57 File Offset: 0x009BED57
		// (set) Token: 0x06025AB1 RID: 154289 RVA: 0x009C0B6B File Offset: 0x009BED6B
		public unsafe UComboBoxString _030_ComboBox_DensFromMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UComboBoxString>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_34);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_34, value);
			}
		}

		// Token: 0x17005337 RID: 21303
		// (get) Token: 0x06025AB2 RID: 154290 RVA: 0x009C0B80 File Offset: 0x009BED80
		// (set) Token: 0x06025AB3 RID: 154291 RVA: 0x009C0B94 File Offset: 0x009BED94
		public unsafe USpinBox _031_SpinBox_DensityFieldAmp
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USpinBox>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_35);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_35, value);
			}
		}

		// Token: 0x17005338 RID: 21304
		// (get) Token: 0x06025AB4 RID: 154292 RVA: 0x009C0BA9 File Offset: 0x009BEDA9
		// (set) Token: 0x06025AB5 RID: 154293 RVA: 0x009C0BBD File Offset: 0x009BEDBD
		public unsafe USpinBox _032_SpinBox_DensityFieldAmpNois
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USpinBox>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_36);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_36, value);
			}
		}

		// Token: 0x17005339 RID: 21305
		// (get) Token: 0x06025AB6 RID: 154294 RVA: 0x009C0BD2 File Offset: 0x009BEDD2
		// (set) Token: 0x06025AB7 RID: 154295 RVA: 0x009C0BE6 File Offset: 0x009BEDE6
		public unsafe USpinBox _033_SpinBox_DensityFieldAmpNoisOfs
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USpinBox>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_37);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_37, value);
			}
		}

		// Token: 0x1700533A RID: 21306
		// (get) Token: 0x06025AB8 RID: 154296 RVA: 0x009C0BFB File Offset: 0x009BEDFB
		// (set) Token: 0x06025AB9 RID: 154297 RVA: 0x009C0C0F File Offset: 0x009BEE0F
		public unsafe USpinBox _034_SpinBox_DensityFieldAmpNoisTile
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USpinBox>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_38);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_38, value);
			}
		}

		// Token: 0x1700533B RID: 21307
		// (get) Token: 0x06025ABA RID: 154298 RVA: 0x009C0C24 File Offset: 0x009BEE24
		// (set) Token: 0x06025ABB RID: 154299 RVA: 0x009C0C38 File Offset: 0x009BEE38
		public unsafe USpinBox _035_SpinBox_BouncyEdges
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USpinBox>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_39);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_39, value);
			}
		}

		// Token: 0x1700533C RID: 21308
		// (get) Token: 0x06025ABC RID: 154300 RVA: 0x009C0C4D File Offset: 0x009BEE4D
		// (set) Token: 0x06025ABD RID: 154301 RVA: 0x009C0C61 File Offset: 0x009BEE61
		public unsafe USpinBox _036_SpinBox_SimEdgeFadePow
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USpinBox>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_40);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_40, value);
			}
		}

		// Token: 0x1700533D RID: 21309
		// (get) Token: 0x06025ABE RID: 154302 RVA: 0x009C0C76 File Offset: 0x009BEE76
		// (set) Token: 0x06025ABF RID: 154303 RVA: 0x009C0C8A File Offset: 0x009BEE8A
		public unsafe USpinBox _037_SpinBox_SimEdgeFadeWidth
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USpinBox>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_41);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_41, value);
			}
		}

		// Token: 0x1700533E RID: 21310
		// (get) Token: 0x06025AC0 RID: 154304 RVA: 0x009C0C9F File Offset: 0x009BEE9F
		// (set) Token: 0x06025AC1 RID: 154305 RVA: 0x009C0CB3 File Offset: 0x009BEEB3
		public unsafe UComboBoxString _038_ComboBox_OutputMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UComboBoxString>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_42);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_42, value);
			}
		}

		// Token: 0x1700533F RID: 21311
		// (get) Token: 0x06025AC2 RID: 154306 RVA: 0x009C0CC8 File Offset: 0x009BEEC8
		// (set) Token: 0x06025AC3 RID: 154307 RVA: 0x009C0CDC File Offset: 0x009BEEDC
		public unsafe UButton _039_Button_SavePaintBuffer
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UButton>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_43);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_43, value);
			}
		}

		// Token: 0x17005340 RID: 21312
		// (get) Token: 0x06025AC4 RID: 154308 RVA: 0x009C0CF1 File Offset: 0x009BEEF1
		// (set) Token: 0x06025AC5 RID: 154309 RVA: 0x009C0D05 File Offset: 0x009BEF05
		public unsafe UButton _040_Button_SaveSimBuffer
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UButton>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_44);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_44, value);
			}
		}

		// Token: 0x17005341 RID: 21313
		// (get) Token: 0x06025AC6 RID: 154310 RVA: 0x009C0D1A File Offset: 0x009BEF1A
		// (set) Token: 0x06025AC7 RID: 154311 RVA: 0x009C0D2E File Offset: 0x009BEF2E
		public unsafe UTextBlock _041_TextBlock_MetaInfo
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextBlock>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_45);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_45, value);
			}
		}

		// Token: 0x17005342 RID: 21314
		// (get) Token: 0x06025AC8 RID: 154312 RVA: 0x009C0D43 File Offset: 0x009BEF43
		// (set) Token: 0x06025AC9 RID: 154313 RVA: 0x009C0D57 File Offset: 0x009BEF57
		public unsafe UBorder Border
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBorder>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_46);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_46, value);
			}
		}

		// Token: 0x17005343 RID: 21315
		// (get) Token: 0x06025ACA RID: 154314 RVA: 0x009C0D6C File Offset: 0x009BEF6C
		// (set) Token: 0x06025ACB RID: 154315 RVA: 0x009C0D80 File Offset: 0x009BEF80
		public unsafe UBorder Main0_StatusBorder
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBorder>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_47);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_47, value);
			}
		}

		// Token: 0x17005344 RID: 21316
		// (get) Token: 0x06025ACC RID: 154316 RVA: 0x009C0D95 File Offset: 0x009BEF95
		// (set) Token: 0x06025ACD RID: 154317 RVA: 0x009C0DA9 File Offset: 0x009BEFA9
		public unsafe UButton Main1_Button_Minimize
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UButton>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_48);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_48, value);
			}
		}

		// Token: 0x17005345 RID: 21317
		// (get) Token: 0x06025ACE RID: 154318 RVA: 0x009C0DBE File Offset: 0x009BEFBE
		// (set) Token: 0x06025ACF RID: 154319 RVA: 0x009C0DD2 File Offset: 0x009BEFD2
		public unsafe UCheckBox Main2_TooltipCheckBox
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCheckBox>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_49);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_49, value);
			}
		}

		// Token: 0x17005346 RID: 21318
		// (get) Token: 0x06025AD0 RID: 154320 RVA: 0x009C0DE7 File Offset: 0x009BEFE7
		// (set) Token: 0x06025AD1 RID: 154321 RVA: 0x009C0DFB File Offset: 0x009BEFFB
		public unsafe UButton Main3_Button_CloseProgram
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UButton>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_50);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_50, value);
			}
		}

		// Token: 0x17005347 RID: 21319
		// (get) Token: 0x06025AD2 RID: 154322 RVA: 0x009C0E10 File Offset: 0x009BF010
		// (set) Token: 0x06025AD3 RID: 154323 RVA: 0x009C0E24 File Offset: 0x009BF024
		public unsafe UComboBoxString Main4_ComboBox_MainMenu
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UComboBoxString>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_51);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_51, value);
			}
		}

		// Token: 0x17005348 RID: 21320
		// (get) Token: 0x06025AD4 RID: 154324 RVA: 0x009C0E39 File Offset: 0x009BF039
		// (set) Token: 0x06025AD5 RID: 154325 RVA: 0x009C0E4D File Offset: 0x009BF04D
		public unsafe UComboBoxString Main5_ComboBox_Presets
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UComboBoxString>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_52);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_52, value);
			}
		}

		// Token: 0x17005349 RID: 21321
		// (get) Token: 0x06025AD6 RID: 154326 RVA: 0x009C0E62 File Offset: 0x009BF062
		// (set) Token: 0x06025AD7 RID: 154327 RVA: 0x009C0E76 File Offset: 0x009BF076
		public unsafe UButton Main6_Button_OverWritePreset
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UButton>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_53);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_53, value);
			}
		}

		// Token: 0x1700534A RID: 21322
		// (get) Token: 0x06025AD8 RID: 154328 RVA: 0x009C0E8B File Offset: 0x009BF08B
		// (set) Token: 0x06025AD9 RID: 154329 RVA: 0x009C0E9F File Offset: 0x009BF09F
		public unsafe UButton Main7_Button_DuplicatePreset
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UButton>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_54);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_54, value);
			}
		}

		// Token: 0x1700534B RID: 21323
		// (get) Token: 0x06025ADA RID: 154330 RVA: 0x009C0EB4 File Offset: 0x009BF0B4
		// (set) Token: 0x06025ADB RID: 154331 RVA: 0x009C0EC8 File Offset: 0x009BF0C8
		public unsafe UButton Main8_Button_RemovePreset
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UButton>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_55);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_55, value);
			}
		}

		// Token: 0x1700534C RID: 21324
		// (get) Token: 0x06025ADC RID: 154332 RVA: 0x009C0EDD File Offset: 0x009BF0DD
		// (set) Token: 0x06025ADD RID: 154333 RVA: 0x009C0EF1 File Offset: 0x009BF0F1
		public unsafe UButton Main9_Button_AutoLoadPreset
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UButton>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_56);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_56, value);
			}
		}

		// Token: 0x1700534D RID: 21325
		// (get) Token: 0x06025ADE RID: 154334 RVA: 0x009C0F06 File Offset: 0x009BF106
		// (set) Token: 0x06025ADF RID: 154335 RVA: 0x009C0F1A File Offset: 0x009BF11A
		public unsafe UImage MenuFrame1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UImage>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_57);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_57, value);
			}
		}

		// Token: 0x1700534E RID: 21326
		// (get) Token: 0x06025AE0 RID: 154336 RVA: 0x009C0F2F File Offset: 0x009BF12F
		// (set) Token: 0x06025AE1 RID: 154337 RVA: 0x009C0F43 File Offset: 0x009BF143
		public unsafe UImage MenuFrame2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UImage>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_58);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_58, value);
			}
		}

		// Token: 0x1700534F RID: 21327
		// (get) Token: 0x06025AE2 RID: 154338 RVA: 0x009C0F58 File Offset: 0x009BF158
		// (set) Token: 0x06025AE3 RID: 154339 RVA: 0x009C0F6C File Offset: 0x009BF16C
		public unsafe UImage MenuFrame3
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UImage>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_59);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_59, value);
			}
		}

		// Token: 0x17005350 RID: 21328
		// (get) Token: 0x06025AE4 RID: 154340 RVA: 0x009C0F81 File Offset: 0x009BF181
		// (set) Token: 0x06025AE5 RID: 154341 RVA: 0x009C0F95 File Offset: 0x009BF195
		public unsafe UMultiLineEditableText MultiLineEditableText_MetaData
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMultiLineEditableText>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_60);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_60, value);
			}
		}

		// Token: 0x17005351 RID: 21329
		// (get) Token: 0x06025AE6 RID: 154342 RVA: 0x009C0FAA File Offset: 0x009BF1AA
		// (set) Token: 0x06025AE7 RID: 154343 RVA: 0x009C0FBE File Offset: 0x009BF1BE
		public unsafe UNamedSlot NamedSlot_empty
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNamedSlot>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_61);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_61, value);
			}
		}

		// Token: 0x17005352 RID: 21330
		// (get) Token: 0x06025AE8 RID: 154344 RVA: 0x009C0FD3 File Offset: 0x009BF1D3
		// (set) Token: 0x06025AE9 RID: 154345 RVA: 0x009C0FE7 File Offset: 0x009BF1E7
		public unsafe UNamedSlot NamedSlot_FluidNinja
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNamedSlot>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_62);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_62, value);
			}
		}

		// Token: 0x17005353 RID: 21331
		// (get) Token: 0x06025AEA RID: 154346 RVA: 0x009C0FFC File Offset: 0x009BF1FC
		// (set) Token: 0x06025AEB RID: 154347 RVA: 0x009C1010 File Offset: 0x009BF210
		public unsafe UTextBlock TextBlock_BRUSH
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextBlock>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_63);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_63, value);
			}
		}

		// Token: 0x17005354 RID: 21332
		// (get) Token: 0x06025AEC RID: 154348 RVA: 0x009C1025 File Offset: 0x009BF225
		// (set) Token: 0x06025AED RID: 154349 RVA: 0x009C1039 File Offset: 0x009BF239
		public unsafe UTextBlock TextBlock_FIELDS
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextBlock>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_64);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_64, value);
			}
		}

		// Token: 0x17005355 RID: 21333
		// (get) Token: 0x06025AEE RID: 154350 RVA: 0x009C104E File Offset: 0x009BF24E
		// (set) Token: 0x06025AEF RID: 154351 RVA: 0x009C1062 File Offset: 0x009BF262
		public unsafe UTextBlock TextBlock_SIM
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextBlock>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_65);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_65, value);
			}
		}

		// Token: 0x17005356 RID: 21334
		// (get) Token: 0x06025AF0 RID: 154352 RVA: 0x009C1077 File Offset: 0x009BF277
		// (set) Token: 0x06025AF1 RID: 154353 RVA: 0x009C108B File Offset: 0x009BF28B
		[Nullable(1)]
		public unsafe string SelectedProjectItem
		{
			[NullableContext(1)]
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)NinjaLiveGUI_C.__PropertyOffset_66)));
			}
			[NullableContext(1)]
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)NinjaLiveGUI_C.__PropertyOffset_66)), value);
			}
		}

		// Token: 0x17005357 RID: 21335
		// (get) Token: 0x06025AF2 RID: 154354 RVA: 0x009C10A0 File Offset: 0x009BF2A0
		// (set) Token: 0x06025AF3 RID: 154355 RVA: 0x009C10B4 File Offset: 0x009BF2B4
		[Nullable(1)]
		public unsafe string SelectedPresetItem
		{
			[NullableContext(1)]
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)NinjaLiveGUI_C.__PropertyOffset_67)));
			}
			[NullableContext(1)]
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)NinjaLiveGUI_C.__PropertyOffset_67)), value);
			}
		}

		// Token: 0x17005358 RID: 21336
		// (get) Token: 0x06025AF4 RID: 154356 RVA: 0x009C10C9 File Offset: 0x009BF2C9
		// (set) Token: 0x06025AF5 RID: 154357 RVA: 0x009C10DD File Offset: 0x009BF2DD
		[Nullable(1)]
		public unsafe string SelectedPresetItemTemp
		{
			[NullableContext(1)]
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)NinjaLiveGUI_C.__PropertyOffset_68)));
			}
			[NullableContext(1)]
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)NinjaLiveGUI_C.__PropertyOffset_68)), value);
			}
		}

		// Token: 0x17005359 RID: 21337
		// (get) Token: 0x06025AF6 RID: 154358 RVA: 0x009C10F2 File Offset: 0x009BF2F2
		// (set) Token: 0x06025AF7 RID: 154359 RVA: 0x009C1106 File Offset: 0x009BF306
		[Nullable(1)]
		public unsafe string NullString
		{
			[NullableContext(1)]
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)NinjaLiveGUI_C.__PropertyOffset_69)));
			}
			[NullableContext(1)]
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)NinjaLiveGUI_C.__PropertyOffset_69)), value);
			}
		}

		// Token: 0x1700535A RID: 21338
		// (get) Token: 0x06025AF8 RID: 154360 RVA: 0x009C111B File Offset: 0x009BF31B
		// (set) Token: 0x06025AF9 RID: 154361 RVA: 0x009C112F File Offset: 0x009BF32F
		[Nullable(1)]
		public unsafe string DefaultSelection
		{
			[NullableContext(1)]
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)NinjaLiveGUI_C.__PropertyOffset_70)));
			}
			[NullableContext(1)]
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)NinjaLiveGUI_C.__PropertyOffset_70)), value);
			}
		}

		// Token: 0x1700535B RID: 21339
		// (get) Token: 0x06025AFA RID: 154362 RVA: 0x009C1144 File Offset: 0x009BF344
		// (set) Token: 0x06025AFB RID: 154363 RVA: 0x009C117D File Offset: 0x009BF37D
		[Nullable(1)]
		public TArray<UNamedSlot> ArrayOfWidgets
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<UNamedSlot> result;
				if ((result = this._ArrayOfWidgets) == null)
				{
					result = (this._ArrayOfWidgets = new TArray<UNamedSlot>(base.NativePtr + (IntPtr)NinjaLiveGUI_C.__PropertyOffset_71, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.ArrayOfWidgets.CopyAssign(value);
			}
		}

		// Token: 0x1700535C RID: 21340
		// (get) Token: 0x06025AFC RID: 154364 RVA: 0x009C118B File Offset: 0x009BF38B
		// (set) Token: 0x06025AFD RID: 154365 RVA: 0x009C119B File Offset: 0x009BF39B
		public unsafe int Counter
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveGUI_C.__PropertyOffset_72);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveGUI_C.__PropertyOffset_72) = value;
			}
		}

		// Token: 0x1700535D RID: 21341
		// (get) Token: 0x06025AFE RID: 154366 RVA: 0x009C11AC File Offset: 0x009BF3AC
		// (set) Token: 0x06025AFF RID: 154367 RVA: 0x009C11BC File Offset: 0x009BF3BC
		public unsafe int SelectedActorIndex
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveGUI_C.__PropertyOffset_73);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveGUI_C.__PropertyOffset_73) = value;
			}
		}

		// Token: 0x1700535E RID: 21342
		// (get) Token: 0x06025B00 RID: 154368 RVA: 0x009C11CD File Offset: 0x009BF3CD
		// (set) Token: 0x06025B01 RID: 154369 RVA: 0x009C11DD File Offset: 0x009BF3DD
		public unsafe bool PresetsDetected
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveGUI_C.__PropertyOffset_74) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveGUI_C.__PropertyOffset_74) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700535F RID: 21343
		// (get) Token: 0x06025B02 RID: 154370 RVA: 0x009C11F0 File Offset: 0x009BF3F0
		// (set) Token: 0x06025B03 RID: 154371 RVA: 0x009C1229 File Offset: 0x009BF429
		[Nullable(1)]
		public OnSelectionChanged OnSelectionChanged
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				OnSelectionChanged result;
				if ((result = this._OnSelectionChanged) == null)
				{
					result = (this._OnSelectionChanged = new OnSelectionChanged(base.NativePtr + (IntPtr)NinjaLiveGUI_C.__PropertyOffset_75, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				FMulticastScriptDelegate.NativeCopy(base.NativePtr + (IntPtr)NinjaLiveGUI_C.__PropertyOffset_75, (value != null) ? value.NativePtr : ((IntPtr)0));
			}
		}

		// Token: 0x17005360 RID: 21344
		// (get) Token: 0x06025B04 RID: 154372 RVA: 0x009C124C File Offset: 0x009BF44C
		// (set) Token: 0x06025B05 RID: 154373 RVA: 0x009C1285 File Offset: 0x009BF485
		[Nullable(1)]
		public OnPresetSelectionChanged OnPresetSelectionChanged
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				OnPresetSelectionChanged result;
				if ((result = this._OnPresetSelectionChanged) == null)
				{
					result = (this._OnPresetSelectionChanged = new OnPresetSelectionChanged(base.NativePtr + (IntPtr)NinjaLiveGUI_C.__PropertyOffset_76, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				FMulticastScriptDelegate.NativeCopy(base.NativePtr + (IntPtr)NinjaLiveGUI_C.__PropertyOffset_76, (value != null) ? value.NativePtr : ((IntPtr)0));
			}
		}

		// Token: 0x17005361 RID: 21345
		// (get) Token: 0x06025B06 RID: 154374 RVA: 0x009C12A8 File Offset: 0x009BF4A8
		// (set) Token: 0x06025B07 RID: 154375 RVA: 0x009C12E1 File Offset: 0x009BF4E1
		[Nullable(1)]
		public OnPresetSave OnPresetSave
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				OnPresetSave result;
				if ((result = this._OnPresetSave) == null)
				{
					result = (this._OnPresetSave = new OnPresetSave(base.NativePtr + (IntPtr)NinjaLiveGUI_C.__PropertyOffset_77, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				FMulticastScriptDelegate.NativeCopy(base.NativePtr + (IntPtr)NinjaLiveGUI_C.__PropertyOffset_77, (value != null) ? value.NativePtr : ((IntPtr)0));
			}
		}

		// Token: 0x17005362 RID: 21346
		// (get) Token: 0x06025B08 RID: 154376 RVA: 0x009C1302 File Offset: 0x009BF502
		// (set) Token: 0x06025B09 RID: 154377 RVA: 0x009C1312 File Offset: 0x009BF512
		public unsafe float Timer
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveGUI_C.__PropertyOffset_78);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveGUI_C.__PropertyOffset_78) = value;
			}
		}

		// Token: 0x17005363 RID: 21347
		// (get) Token: 0x06025B0A RID: 154378 RVA: 0x009C1323 File Offset: 0x009BF523
		// (set) Token: 0x06025B0B RID: 154379 RVA: 0x009C1333 File Offset: 0x009BF533
		public unsafe float TimerTemp
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveGUI_C.__PropertyOffset_79);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveGUI_C.__PropertyOffset_79) = value;
			}
		}

		// Token: 0x17005364 RID: 21348
		// (get) Token: 0x06025B0C RID: 154380 RVA: 0x009C1344 File Offset: 0x009BF544
		// (set) Token: 0x06025B0D RID: 154381 RVA: 0x009C1354 File Offset: 0x009BF554
		public unsafe bool NinjaBaseArraysConstructed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveGUI_C.__PropertyOffset_80) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveGUI_C.__PropertyOffset_80) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005365 RID: 21349
		// (get) Token: 0x06025B0E RID: 154382 RVA: 0x009C1365 File Offset: 0x009BF565
		// (set) Token: 0x06025B0F RID: 154383 RVA: 0x009C1375 File Offset: 0x009BF575
		public unsafe bool PresetSaveOverWriteFlag
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveGUI_C.__PropertyOffset_81) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveGUI_C.__PropertyOffset_81) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005366 RID: 21350
		// (get) Token: 0x06025B10 RID: 154384 RVA: 0x009C1388 File Offset: 0x009BF588
		// (set) Token: 0x06025B11 RID: 154385 RVA: 0x009C13C1 File Offset: 0x009BF5C1
		[Nullable(1)]
		public TArray<FName> TempVarOfParticleTemplatePackages
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<FName> result;
				if ((result = this._TempVarOfParticleTemplatePackages) == null)
				{
					result = (this._TempVarOfParticleTemplatePackages = new TArray<FName>(base.NativePtr + (IntPtr)NinjaLiveGUI_C.__PropertyOffset_82, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.TempVarOfParticleTemplatePackages.CopyAssign(value);
			}
		}

		// Token: 0x17005367 RID: 21351
		// (get) Token: 0x06025B12 RID: 154386 RVA: 0x009C13D0 File Offset: 0x009BF5D0
		// (set) Token: 0x06025B13 RID: 154387 RVA: 0x009C1409 File Offset: 0x009BF609
		[Nullable(1)]
		public TArray<FName> TempVarOfDensityTemplatePackages
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<FName> result;
				if ((result = this._TempVarOfDensityTemplatePackages) == null)
				{
					result = (this._TempVarOfDensityTemplatePackages = new TArray<FName>(base.NativePtr + (IntPtr)NinjaLiveGUI_C.__PropertyOffset_83, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.TempVarOfDensityTemplatePackages.CopyAssign(value);
			}
		}

		// Token: 0x17005368 RID: 21352
		// (get) Token: 0x06025B14 RID: 154388 RVA: 0x009C1418 File Offset: 0x009BF618
		// (set) Token: 0x06025B15 RID: 154389 RVA: 0x009C1451 File Offset: 0x009BF651
		[Nullable(1)]
		public TArray<FName> TempVarOfVelocityTemplatePackages
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<FName> result;
				if ((result = this._TempVarOfVelocityTemplatePackages) == null)
				{
					result = (this._TempVarOfVelocityTemplatePackages = new TArray<FName>(base.NativePtr + (IntPtr)NinjaLiveGUI_C.__PropertyOffset_84, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.TempVarOfVelocityTemplatePackages.CopyAssign(value);
			}
		}

		// Token: 0x17005369 RID: 21353
		// (get) Token: 0x06025B16 RID: 154390 RVA: 0x009C1460 File Offset: 0x009BF660
		// (set) Token: 0x06025B17 RID: 154391 RVA: 0x009C1499 File Offset: 0x009BF699
		[Nullable(1)]
		public TArray<FName> TempVarOfOutputMaterials
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<FName> result;
				if ((result = this._TempVarOfOutputMaterials) == null)
				{
					result = (this._TempVarOfOutputMaterials = new TArray<FName>(base.NativePtr + (IntPtr)NinjaLiveGUI_C.__PropertyOffset_85, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.TempVarOfOutputMaterials.CopyAssign(value);
			}
		}

		// Token: 0x1700536A RID: 21354
		// (get) Token: 0x06025B18 RID: 154392 RVA: 0x009C14A8 File Offset: 0x009BF6A8
		// (set) Token: 0x06025B19 RID: 154393 RVA: 0x009C14E1 File Offset: 0x009BF6E1
		[Nullable(1)]
		public TArray<string> ArrayOfPresetNamesUnsorted
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<string> result;
				if ((result = this._ArrayOfPresetNamesUnsorted) == null)
				{
					result = (this._ArrayOfPresetNamesUnsorted = new TArray<string>(base.NativePtr + (IntPtr)NinjaLiveGUI_C.__PropertyOffset_86, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.ArrayOfPresetNamesUnsorted.CopyAssign(value);
			}
		}

		// Token: 0x1700536B RID: 21355
		// (get) Token: 0x06025B1A RID: 154394 RVA: 0x009C14F0 File Offset: 0x009BF6F0
		// (set) Token: 0x06025B1B RID: 154395 RVA: 0x009C1529 File Offset: 0x009BF729
		[Nullable(1)]
		public TArray<string> ArrayOfPresetNamesSorted
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<string> result;
				if ((result = this._ArrayOfPresetNamesSorted) == null)
				{
					result = (this._ArrayOfPresetNamesSorted = new TArray<string>(base.NativePtr + (IntPtr)NinjaLiveGUI_C.__PropertyOffset_87, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.ArrayOfPresetNamesSorted.CopyAssign(value);
			}
		}

		// Token: 0x1700536C RID: 21356
		// (get) Token: 0x06025B1C RID: 154396 RVA: 0x009C1537 File Offset: 0x009BF737
		// (set) Token: 0x06025B1D RID: 154397 RVA: 0x009C1547 File Offset: 0x009BF747
		public unsafe bool SaveBasicAtlasPlayer
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveGUI_C.__PropertyOffset_88) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveGUI_C.__PropertyOffset_88) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700536D RID: 21357
		// (get) Token: 0x06025B1E RID: 154398 RVA: 0x009C1558 File Offset: 0x009BF758
		// (set) Token: 0x06025B1F RID: 154399 RVA: 0x009C1568 File Offset: 0x009BF768
		public unsafe bool SaveBasicFlowPlayer
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveGUI_C.__PropertyOffset_89) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveGUI_C.__PropertyOffset_89) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700536E RID: 21358
		// (get) Token: 0x06025B20 RID: 154400 RVA: 0x009C1579 File Offset: 0x009BF779
		// (set) Token: 0x06025B21 RID: 154401 RVA: 0x009C1589 File Offset: 0x009BF789
		public unsafe bool NinjaViewPortToolsVisibilityFlag
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveGUI_C.__PropertyOffset_90) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveGUI_C.__PropertyOffset_90) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700536F RID: 21359
		// (get) Token: 0x06025B22 RID: 154402 RVA: 0x009C159C File Offset: 0x009BF79C
		// (set) Token: 0x06025B23 RID: 154403 RVA: 0x009C15D5 File Offset: 0x009BF7D5
		[Nullable(1)]
		public OnDensityMapSave OnDensityMapSave
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				OnDensityMapSave result;
				if ((result = this._OnDensityMapSave) == null)
				{
					result = (this._OnDensityMapSave = new OnDensityMapSave(base.NativePtr + (IntPtr)NinjaLiveGUI_C.__PropertyOffset_91, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				FMulticastScriptDelegate.NativeCopy(base.NativePtr + (IntPtr)NinjaLiveGUI_C.__PropertyOffset_91, (value != null) ? value.NativePtr : ((IntPtr)0));
			}
		}

		// Token: 0x17005370 RID: 21360
		// (get) Token: 0x06025B24 RID: 154404 RVA: 0x009C15F6 File Offset: 0x009BF7F6
		// (set) Token: 0x06025B25 RID: 154405 RVA: 0x009C1606 File Offset: 0x009BF806
		public unsafe bool SystemOn
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveGUI_C.__PropertyOffset_92) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveGUI_C.__PropertyOffset_92) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005371 RID: 21361
		// (get) Token: 0x06025B26 RID: 154406 RVA: 0x009C1617 File Offset: 0x009BF817
		// (set) Token: 0x06025B27 RID: 154407 RVA: 0x009C1627 File Offset: 0x009BF827
		public unsafe bool RecordingStarted
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveGUI_C.__PropertyOffset_93) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveGUI_C.__PropertyOffset_93) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005372 RID: 21362
		// (get) Token: 0x06025B28 RID: 154408 RVA: 0x009C1638 File Offset: 0x009BF838
		// (set) Token: 0x06025B29 RID: 154409 RVA: 0x009C1648 File Offset: 0x009BF848
		public unsafe int TempVecfieldIndex
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveGUI_C.__PropertyOffset_94);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveGUI_C.__PropertyOffset_94) = value;
			}
		}

		// Token: 0x17005373 RID: 21363
		// (get) Token: 0x06025B2A RID: 154410 RVA: 0x009C165C File Offset: 0x009BF85C
		// (set) Token: 0x06025B2B RID: 154411 RVA: 0x009C1695 File Offset: 0x009BF895
		[Nullable(1)]
		public OnPresetDuplicated OnPresetDuplicated
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				OnPresetDuplicated result;
				if ((result = this._OnPresetDuplicated) == null)
				{
					result = (this._OnPresetDuplicated = new OnPresetDuplicated(base.NativePtr + (IntPtr)NinjaLiveGUI_C.__PropertyOffset_95, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				FMulticastScriptDelegate.NativeCopy(base.NativePtr + (IntPtr)NinjaLiveGUI_C.__PropertyOffset_95, (value != null) ? value.NativePtr : ((IntPtr)0));
			}
		}

		// Token: 0x17005374 RID: 21364
		// (get) Token: 0x06025B2C RID: 154412 RVA: 0x009C16B6 File Offset: 0x009BF8B6
		// (set) Token: 0x06025B2D RID: 154413 RVA: 0x009C16C6 File Offset: 0x009BF8C6
		public unsafe bool ForcePreferredPreset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveGUI_C.__PropertyOffset_96) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveGUI_C.__PropertyOffset_96) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005375 RID: 21365
		// (get) Token: 0x06025B2E RID: 154414 RVA: 0x009C16D7 File Offset: 0x009BF8D7
		// (set) Token: 0x06025B2F RID: 154415 RVA: 0x009C16EB File Offset: 0x009BF8EB
		public unsafe AActor SelectedActor
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_97);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_97, value);
			}
		}

		// Token: 0x17005376 RID: 21366
		// (get) Token: 0x06025B30 RID: 154416 RVA: 0x009C1700 File Offset: 0x009BF900
		// (set) Token: 0x06025B31 RID: 154417 RVA: 0x009C1714 File Offset: 0x009BF914
		public unsafe NinjaLiveComponent_C SelectedActorComponent
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<NinjaLiveComponent_C>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_98);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveGUI_C.__PropertyOffset_98, value);
			}
		}

		// Token: 0x06025B32 RID: 154418 RVA: 0x009C172C File Offset: 0x009BF92C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetSelectedActor(int SelectedActorIndex, ref NinjaLive_C NinjaLiveActor)
		{
			NinjaLiveGUI_C.__GetSelectedActor_FunctionParams* ptr = stackalloc NinjaLiveGUI_C.__GetSelectedActor_FunctionParams[(UIntPtr)79] + 15L / (long)sizeof(NinjaLiveGUI_C.__GetSelectedActor_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLiveGUI_C.__GetSelectedActor_NativeFunctionPtr, (void*)ptr, 1);
			ptr->SelectedActorIndex = SelectedActorIndex;
			ref NinjaLiveGUI_C.__GetSelectedActor_FunctionParams ptr2 = ref *ptr;
			NinjaLive_C ninjaLive_C = NinjaLiveActor;
			ptr2.NinjaLiveActor = ((ninjaLive_C != null) ? ninjaLive_C.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLiveGUI_C.__GetSelectedActor_NativeFunctionPtr, (void*)ptr);
			NinjaLiveActor = BuiltinUtils.GetOrCreateUObjectByNativePointer<NinjaLive_C>(ptr->NinjaLiveActor);
		}

		// Token: 0x06025B33 RID: 154419 RVA: 0x009C1798 File Offset: 0x009BF998
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetCurrentLevelInfoGUI(ref FName LevelName, ref FName LevelPath)
		{
			NinjaLiveGUI_C.__GetCurrentLevelInfoGUI_FunctionParams* ptr = stackalloc NinjaLiveGUI_C.__GetCurrentLevelInfoGUI_FunctionParams[(UIntPtr)255] + 15L / (long)sizeof(NinjaLiveGUI_C.__GetCurrentLevelInfoGUI_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLiveGUI_C.__GetCurrentLevelInfoGUI_NativeFunctionPtr, (void*)ptr, 1);
			ptr->LevelName = LevelName;
			ptr->LevelPath = LevelPath;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLiveGUI_C.__GetCurrentLevelInfoGUI_NativeFunctionPtr, (void*)ptr);
			LevelName = ptr->LevelName;
			LevelPath = ptr->LevelPath;
		}

		// Token: 0x06025B34 RID: 154420 RVA: 0x009C180A File Offset: 0x009BFA0A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void BndEvt__ComboBoxString_89_K2Node_ComponentBoundEvent_2_OnOpeningEvent__DelegateSignature()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLiveGUI_C.__BndEvt__ComboBoxString_89_K2Node_ComponentBoundEvent_2_OnOpeningEvent__DelegateSignature_NativeFunctionPtr, null);
		}

		// Token: 0x06025B35 RID: 154421 RVA: 0x009C1820 File Offset: 0x009BFA20
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__ComboBoxString_89_K2Node_ComponentBoundEvent_4_OnSelectionChangedEvent__DelegateSignature(string SelectedItem, ESelectInfo SelectionType)
		{
			NinjaLiveGUI_C.__BndEvt__ComboBoxString_89_K2Node_ComponentBoundEvent_4_OnSelectionChangedEvent__DelegateSignature_FunctionParams* ptr = stackalloc NinjaLiveGUI_C.__BndEvt__ComboBoxString_89_K2Node_ComponentBoundEvent_4_OnSelectionChangedEvent__DelegateSignature_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(NinjaLiveGUI_C.__BndEvt__ComboBoxString_89_K2Node_ComponentBoundEvent_4_OnSelectionChangedEvent__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLiveGUI_C.__BndEvt__ComboBoxString_89_K2Node_ComponentBoundEvent_4_OnSelectionChangedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			FString.CopyFrom((void*)(&ptr->SelectedItem), SelectedItem);
			ptr->SelectionType = SelectionType;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLiveGUI_C.__BndEvt__ComboBoxString_89_K2Node_ComponentBoundEvent_4_OnSelectionChangedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(NinjaLiveGUI_C.__BndEvt__ComboBoxString_89_K2Node_ComponentBoundEvent_4_OnSelectionChangedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x06025B36 RID: 154422 RVA: 0x009C1889 File Offset: 0x009BFA89
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void Construct()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLiveGUI_C.__Construct_NativeFunctionPtr, null);
		}

		// Token: 0x06025B37 RID: 154423 RVA: 0x009C189D File Offset: 0x009BFA9D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void Construct_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, NinjaLiveGUI_C.__Construct_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06025B38 RID: 154424 RVA: 0x009C18B4 File Offset: 0x009BFAB4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void PreConstruct(bool IsDesignTime)
		{
			NinjaLiveGUI_C.__PreConstruct_FunctionParams* ptr = stackalloc NinjaLiveGUI_C.__PreConstruct_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(NinjaLiveGUI_C.__PreConstruct_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLiveGUI_C.__PreConstruct_NativeFunctionPtr, (void*)ptr, 1);
			ptr->IsDesignTime = IsDesignTime;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLiveGUI_C.__PreConstruct_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025B39 RID: 154425 RVA: 0x009C18FC File Offset: 0x009BFAFC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void PreConstruct_Implementation(bool IsDesignTime)
		{
			NinjaLiveGUI_C.__PreConstruct_FunctionParams* ptr = stackalloc NinjaLiveGUI_C.__PreConstruct_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(NinjaLiveGUI_C.__PreConstruct_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLiveGUI_C.__PreConstruct_NativeFunctionPtr, (void*)ptr, 1);
			ptr->IsDesignTime = IsDesignTime;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, NinjaLiveGUI_C.__PreConstruct_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06025B3A RID: 154426 RVA: 0x009C1944 File Offset: 0x009BFB44
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__ComboBox_Presets_K2Node_ComponentBoundEvent_36_OnSelectionChangedEvent__DelegateSignature(string SelectedItem, ESelectInfo SelectionType)
		{
			NinjaLiveGUI_C.__BndEvt__ComboBox_Presets_K2Node_ComponentBoundEvent_36_OnSelectionChangedEvent__DelegateSignature_FunctionParams* ptr = stackalloc NinjaLiveGUI_C.__BndEvt__ComboBox_Presets_K2Node_ComponentBoundEvent_36_OnSelectionChangedEvent__DelegateSignature_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(NinjaLiveGUI_C.__BndEvt__ComboBox_Presets_K2Node_ComponentBoundEvent_36_OnSelectionChangedEvent__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLiveGUI_C.__BndEvt__ComboBox_Presets_K2Node_ComponentBoundEvent_36_OnSelectionChangedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			FString.CopyFrom((void*)(&ptr->SelectedItem), SelectedItem);
			ptr->SelectionType = SelectionType;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLiveGUI_C.__BndEvt__ComboBox_Presets_K2Node_ComponentBoundEvent_36_OnSelectionChangedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(NinjaLiveGUI_C.__BndEvt__ComboBox_Presets_K2Node_ComponentBoundEvent_36_OnSelectionChangedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x06025B3B RID: 154427 RVA: 0x009C19AD File Offset: 0x009BFBAD
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void BndEvt__Button_SavePreset_K2Node_ComponentBoundEvent_36_OnButtonClickedEvent__DelegateSignature()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLiveGUI_C.__BndEvt__Button_SavePreset_K2Node_ComponentBoundEvent_36_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr, null);
		}

		// Token: 0x06025B3C RID: 154428 RVA: 0x009C19C1 File Offset: 0x009BFBC1
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void BndEvt__Button_DuplicatePreset_K2Node_ComponentBoundEvent_217_OnButtonClickedEvent__DelegateSignature()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLiveGUI_C.__BndEvt__Button_DuplicatePreset_K2Node_ComponentBoundEvent_217_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr, null);
		}

		// Token: 0x06025B3D RID: 154429 RVA: 0x009C19D8 File Offset: 0x009BFBD8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OnPresetDuplicationFinished(UDataTable DuplicatedPreset)
		{
			NinjaLiveGUI_C.__OnPresetDuplicationFinished_FunctionParams* ptr = stackalloc NinjaLiveGUI_C.__OnPresetDuplicationFinished_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(NinjaLiveGUI_C.__OnPresetDuplicationFinished_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLiveGUI_C.__OnPresetDuplicationFinished_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DuplicatedPreset = ((DuplicatedPreset != null) ? DuplicatedPreset.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLiveGUI_C.__OnPresetDuplicationFinished_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025B3E RID: 154430 RVA: 0x009C1A30 File Offset: 0x009BFC30
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__CheckBox_21_K2Node_ComponentBoundEvent_219_OnCheckBoxComponentStateChanged__DelegateSignature(bool bIsChecked)
		{
			NinjaLiveGUI_C.__BndEvt__CheckBox_21_K2Node_ComponentBoundEvent_219_OnCheckBoxComponentStateChanged__DelegateSignature_FunctionParams* ptr = stackalloc NinjaLiveGUI_C.__BndEvt__CheckBox_21_K2Node_ComponentBoundEvent_219_OnCheckBoxComponentStateChanged__DelegateSignature_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(NinjaLiveGUI_C.__BndEvt__CheckBox_21_K2Node_ComponentBoundEvent_219_OnCheckBoxComponentStateChanged__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLiveGUI_C.__BndEvt__CheckBox_21_K2Node_ComponentBoundEvent_219_OnCheckBoxComponentStateChanged__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bIsChecked = bIsChecked;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLiveGUI_C.__BndEvt__CheckBox_21_K2Node_ComponentBoundEvent_219_OnCheckBoxComponentStateChanged__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025B3F RID: 154431 RVA: 0x009C1A76 File Offset: 0x009BFC76
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void BndEvt__Main3_Button_Minimize_K2Node_ComponentBoundEvent_0_OnButtonClickedEvent__DelegateSignature()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLiveGUI_C.__BndEvt__Main3_Button_Minimize_K2Node_ComponentBoundEvent_0_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr, null);
		}

		// Token: 0x06025B40 RID: 154432 RVA: 0x009C1A8A File Offset: 0x009BFC8A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void OnInitialized()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLiveGUI_C.__OnInitialized_NativeFunctionPtr, null);
		}

		// Token: 0x06025B41 RID: 154433 RVA: 0x009C1A9E File Offset: 0x009BFC9E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void OnInitialized_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, NinjaLiveGUI_C.__OnInitialized_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06025B42 RID: 154434 RVA: 0x009C1AB4 File Offset: 0x009BFCB4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void Tick(FGeometry MyGeometry, float InDeltaTime)
		{
			NinjaLiveGUI_C.__Tick_FunctionParams* ptr = stackalloc NinjaLiveGUI_C.__Tick_FunctionParams[(UIntPtr)75] + 15L / (long)sizeof(NinjaLiveGUI_C.__Tick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLiveGUI_C.__Tick_NativeFunctionPtr, (void*)ptr, 1);
			if (MyGeometry != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FGeometry.StaticStruct(), &ptr->MyGeometry, MyGeometry.NativePtr, 1, false);
			}
			ptr->InDeltaTime = InDeltaTime;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLiveGUI_C.__Tick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025B43 RID: 154435 RVA: 0x009C1B1C File Offset: 0x009BFD1C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void Tick_Implementation(FGeometry MyGeometry, float InDeltaTime)
		{
			NinjaLiveGUI_C.__Tick_FunctionParams* ptr = stackalloc NinjaLiveGUI_C.__Tick_FunctionParams[(UIntPtr)75] + 15L / (long)sizeof(NinjaLiveGUI_C.__Tick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLiveGUI_C.__Tick_NativeFunctionPtr, (void*)ptr, 1);
			if (MyGeometry != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FGeometry.StaticStruct(), &ptr->MyGeometry, MyGeometry.NativePtr, 1, false);
			}
			ptr->InDeltaTime = InDeltaTime;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, NinjaLiveGUI_C.__Tick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06025B44 RID: 154436 RVA: 0x009C1B85 File Offset: 0x009BFD85
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void BndEvt__Button_152_K2Node_ComponentBoundEvent_13_OnButtonClickedEvent__DelegateSignature()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLiveGUI_C.__BndEvt__Button_152_K2Node_ComponentBoundEvent_13_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr, null);
		}

		// Token: 0x06025B45 RID: 154437 RVA: 0x009C1B99 File Offset: 0x009BFD99
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void BndEvt__Button_RemovePreset_K2Node_ComponentBoundEvent_218_OnButtonClickedEvent__DelegateSignature()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLiveGUI_C.__BndEvt__Button_RemovePreset_K2Node_ComponentBoundEvent_218_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr, null);
		}

		// Token: 0x06025B46 RID: 154438 RVA: 0x009C1BB0 File Offset: 0x009BFDB0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__025_SimareaMoOffset_K2Node_ComponentBoundEvent_1_OnSpinBoxValueCommittedEvent__DelegateSignature(float InValue, ETextCommit CommitMethod)
		{
			NinjaLiveGUI_C.__BndEvt__025_SimareaMoOffset_K2Node_ComponentBoundEvent_1_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams* ptr = stackalloc NinjaLiveGUI_C.__BndEvt__025_SimareaMoOffset_K2Node_ComponentBoundEvent_1_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(NinjaLiveGUI_C.__BndEvt__025_SimareaMoOffset_K2Node_ComponentBoundEvent_1_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLiveGUI_C.__BndEvt__025_SimareaMoOffset_K2Node_ComponentBoundEvent_1_OnSpinBoxValueCommittedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->InValue = InValue;
			ptr->CommitMethod = CommitMethod;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLiveGUI_C.__BndEvt__025_SimareaMoOffset_K2Node_ComponentBoundEvent_1_OnSpinBoxValueCommittedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025B47 RID: 154439 RVA: 0x009C1C04 File Offset: 0x009BFE04
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__50bSpinBox_BrushRnd_K2Node_ComponentBoundEvent_1_OnSpinBoxValueCommittedEvent__DelegateSignature(float InValue, ETextCommit CommitMethod)
		{
			NinjaLiveGUI_C.__BndEvt__50bSpinBox_BrushRnd_K2Node_ComponentBoundEvent_1_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams* ptr = stackalloc NinjaLiveGUI_C.__BndEvt__50bSpinBox_BrushRnd_K2Node_ComponentBoundEvent_1_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(NinjaLiveGUI_C.__BndEvt__50bSpinBox_BrushRnd_K2Node_ComponentBoundEvent_1_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLiveGUI_C.__BndEvt__50bSpinBox_BrushRnd_K2Node_ComponentBoundEvent_1_OnSpinBoxValueCommittedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->InValue = InValue;
			ptr->CommitMethod = CommitMethod;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLiveGUI_C.__BndEvt__50bSpinBox_BrushRnd_K2Node_ComponentBoundEvent_1_OnSpinBoxValueCommittedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025B48 RID: 154440 RVA: 0x009C1C56 File Offset: 0x009BFE56
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void BndEvt__Button_ClearBuffers_K2Node_ComponentBoundEvent_8_OnButtonClickedEvent__DelegateSignature()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLiveGUI_C.__BndEvt__Button_ClearBuffers_K2Node_ComponentBoundEvent_8_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr, null);
		}

		// Token: 0x06025B49 RID: 154441 RVA: 0x009C1C6C File Offset: 0x009BFE6C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__SpinBox_Divergence_K2Node_ComponentBoundEvent_7_OnSpinBoxValueCommittedEvent__DelegateSignature(float InValue, ETextCommit CommitMethod)
		{
			NinjaLiveGUI_C.__BndEvt__SpinBox_Divergence_K2Node_ComponentBoundEvent_7_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams* ptr = stackalloc NinjaLiveGUI_C.__BndEvt__SpinBox_Divergence_K2Node_ComponentBoundEvent_7_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(NinjaLiveGUI_C.__BndEvt__SpinBox_Divergence_K2Node_ComponentBoundEvent_7_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLiveGUI_C.__BndEvt__SpinBox_Divergence_K2Node_ComponentBoundEvent_7_OnSpinBoxValueCommittedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->InValue = InValue;
			ptr->CommitMethod = CommitMethod;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLiveGUI_C.__BndEvt__SpinBox_Divergence_K2Node_ComponentBoundEvent_7_OnSpinBoxValueCommittedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025B4A RID: 154442 RVA: 0x009C1CC0 File Offset: 0x009BFEC0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__SpinBox_Divergence_K2Node_ComponentBoundEvent_6_OnSpinBoxValueChangedEvent__DelegateSignature(float InValue)
		{
			NinjaLiveGUI_C.__BndEvt__SpinBox_Divergence_K2Node_ComponentBoundEvent_6_OnSpinBoxValueChangedEvent__DelegateSignature_FunctionParams* ptr = stackalloc NinjaLiveGUI_C.__BndEvt__SpinBox_Divergence_K2Node_ComponentBoundEvent_6_OnSpinBoxValueChangedEvent__DelegateSignature_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(NinjaLiveGUI_C.__BndEvt__SpinBox_Divergence_K2Node_ComponentBoundEvent_6_OnSpinBoxValueChangedEvent__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLiveGUI_C.__BndEvt__SpinBox_Divergence_K2Node_ComponentBoundEvent_6_OnSpinBoxValueChangedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->InValue = InValue;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLiveGUI_C.__BndEvt__SpinBox_Divergence_K2Node_ComponentBoundEvent_6_OnSpinBoxValueChangedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025B4B RID: 154443 RVA: 0x009C1D08 File Offset: 0x009BFF08
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__SpinBox_Speed_K2Node_ComponentBoundEvent_5_OnSpinBoxValueCommittedEvent__DelegateSignature(float InValue, ETextCommit CommitMethod)
		{
			NinjaLiveGUI_C.__BndEvt__SpinBox_Speed_K2Node_ComponentBoundEvent_5_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams* ptr = stackalloc NinjaLiveGUI_C.__BndEvt__SpinBox_Speed_K2Node_ComponentBoundEvent_5_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(NinjaLiveGUI_C.__BndEvt__SpinBox_Speed_K2Node_ComponentBoundEvent_5_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLiveGUI_C.__BndEvt__SpinBox_Speed_K2Node_ComponentBoundEvent_5_OnSpinBoxValueCommittedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->InValue = InValue;
			ptr->CommitMethod = CommitMethod;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLiveGUI_C.__BndEvt__SpinBox_Speed_K2Node_ComponentBoundEvent_5_OnSpinBoxValueCommittedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025B4C RID: 154444 RVA: 0x009C1D5C File Offset: 0x009BFF5C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__SpinBox_Feedback_K2Node_ComponentBoundEvent_1_OnSpinBoxValueCommittedEvent__DelegateSignature(float InValue, ETextCommit CommitMethod)
		{
			NinjaLiveGUI_C.__BndEvt__SpinBox_Feedback_K2Node_ComponentBoundEvent_1_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams* ptr = stackalloc NinjaLiveGUI_C.__BndEvt__SpinBox_Feedback_K2Node_ComponentBoundEvent_1_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(NinjaLiveGUI_C.__BndEvt__SpinBox_Feedback_K2Node_ComponentBoundEvent_1_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLiveGUI_C.__BndEvt__SpinBox_Feedback_K2Node_ComponentBoundEvent_1_OnSpinBoxValueCommittedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->InValue = InValue;
			ptr->CommitMethod = CommitMethod;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLiveGUI_C.__BndEvt__SpinBox_Feedback_K2Node_ComponentBoundEvent_1_OnSpinBoxValueCommittedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025B4D RID: 154445 RVA: 0x009C1DB0 File Offset: 0x009BFFB0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__SpinBox_Feedback_K2Node_ComponentBoundEvent_0_OnSpinBoxValueChangedEvent__DelegateSignature(float InValue)
		{
			NinjaLiveGUI_C.__BndEvt__SpinBox_Feedback_K2Node_ComponentBoundEvent_0_OnSpinBoxValueChangedEvent__DelegateSignature_FunctionParams* ptr = stackalloc NinjaLiveGUI_C.__BndEvt__SpinBox_Feedback_K2Node_ComponentBoundEvent_0_OnSpinBoxValueChangedEvent__DelegateSignature_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(NinjaLiveGUI_C.__BndEvt__SpinBox_Feedback_K2Node_ComponentBoundEvent_0_OnSpinBoxValueChangedEvent__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLiveGUI_C.__BndEvt__SpinBox_Feedback_K2Node_ComponentBoundEvent_0_OnSpinBoxValueChangedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->InValue = InValue;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLiveGUI_C.__BndEvt__SpinBox_Feedback_K2Node_ComponentBoundEvent_0_OnSpinBoxValueChangedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025B4E RID: 154446 RVA: 0x009C1DF8 File Offset: 0x009BFFF8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__SpinBox_DensityNoiseSize_K2Node_ComponentBoundEvent_7_OnSpinBoxValueCommittedEvent__DelegateSignature(float InValue, ETextCommit CommitMethod)
		{
			NinjaLiveGUI_C.__BndEvt__SpinBox_DensityNoiseSize_K2Node_ComponentBoundEvent_7_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams* ptr = stackalloc NinjaLiveGUI_C.__BndEvt__SpinBox_DensityNoiseSize_K2Node_ComponentBoundEvent_7_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(NinjaLiveGUI_C.__BndEvt__SpinBox_DensityNoiseSize_K2Node_ComponentBoundEvent_7_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLiveGUI_C.__BndEvt__SpinBox_DensityNoiseSize_K2Node_ComponentBoundEvent_7_OnSpinBoxValueCommittedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->InValue = InValue;
			ptr->CommitMethod = CommitMethod;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLiveGUI_C.__BndEvt__SpinBox_DensityNoiseSize_K2Node_ComponentBoundEvent_7_OnSpinBoxValueCommittedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025B4F RID: 154447 RVA: 0x009C1E4C File Offset: 0x009C004C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__SpinBox_DensityNoiseSize_K2Node_ComponentBoundEvent_6_OnSpinBoxValueChangedEvent__DelegateSignature(float InValue)
		{
			NinjaLiveGUI_C.__BndEvt__SpinBox_DensityNoiseSize_K2Node_ComponentBoundEvent_6_OnSpinBoxValueChangedEvent__DelegateSignature_FunctionParams* ptr = stackalloc NinjaLiveGUI_C.__BndEvt__SpinBox_DensityNoiseSize_K2Node_ComponentBoundEvent_6_OnSpinBoxValueChangedEvent__DelegateSignature_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(NinjaLiveGUI_C.__BndEvt__SpinBox_DensityNoiseSize_K2Node_ComponentBoundEvent_6_OnSpinBoxValueChangedEvent__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLiveGUI_C.__BndEvt__SpinBox_DensityNoiseSize_K2Node_ComponentBoundEvent_6_OnSpinBoxValueChangedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->InValue = InValue;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLiveGUI_C.__BndEvt__SpinBox_DensityNoiseSize_K2Node_ComponentBoundEvent_6_OnSpinBoxValueChangedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025B50 RID: 154448 RVA: 0x009C1E94 File Offset: 0x009C0094
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__SpinBox_DensityNoiseOffset_K2Node_ComponentBoundEvent_5_OnSpinBoxValueCommittedEvent__DelegateSignature(float InValue, ETextCommit CommitMethod)
		{
			NinjaLiveGUI_C.__BndEvt__SpinBox_DensityNoiseOffset_K2Node_ComponentBoundEvent_5_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams* ptr = stackalloc NinjaLiveGUI_C.__BndEvt__SpinBox_DensityNoiseOffset_K2Node_ComponentBoundEvent_5_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(NinjaLiveGUI_C.__BndEvt__SpinBox_DensityNoiseOffset_K2Node_ComponentBoundEvent_5_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLiveGUI_C.__BndEvt__SpinBox_DensityNoiseOffset_K2Node_ComponentBoundEvent_5_OnSpinBoxValueCommittedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->InValue = InValue;
			ptr->CommitMethod = CommitMethod;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLiveGUI_C.__BndEvt__SpinBox_DensityNoiseOffset_K2Node_ComponentBoundEvent_5_OnSpinBoxValueCommittedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025B51 RID: 154449 RVA: 0x009C1EE8 File Offset: 0x009C00E8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__SpinBox_DensityNoiseOffset_K2Node_ComponentBoundEvent_3_OnSpinBoxValueChangedEvent__DelegateSignature(float InValue)
		{
			NinjaLiveGUI_C.__BndEvt__SpinBox_DensityNoiseOffset_K2Node_ComponentBoundEvent_3_OnSpinBoxValueChangedEvent__DelegateSignature_FunctionParams* ptr = stackalloc NinjaLiveGUI_C.__BndEvt__SpinBox_DensityNoiseOffset_K2Node_ComponentBoundEvent_3_OnSpinBoxValueChangedEvent__DelegateSignature_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(NinjaLiveGUI_C.__BndEvt__SpinBox_DensityNoiseOffset_K2Node_ComponentBoundEvent_3_OnSpinBoxValueChangedEvent__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLiveGUI_C.__BndEvt__SpinBox_DensityNoiseOffset_K2Node_ComponentBoundEvent_3_OnSpinBoxValueChangedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->InValue = InValue;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLiveGUI_C.__BndEvt__SpinBox_DensityNoiseOffset_K2Node_ComponentBoundEvent_3_OnSpinBoxValueChangedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025B52 RID: 154450 RVA: 0x009C1F30 File Offset: 0x009C0130
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__SpinBox_DensityNoiseAmp_K2Node_ComponentBoundEvent_1_OnSpinBoxValueCommittedEvent__DelegateSignature(float InValue, ETextCommit CommitMethod)
		{
			NinjaLiveGUI_C.__BndEvt__SpinBox_DensityNoiseAmp_K2Node_ComponentBoundEvent_1_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams* ptr = stackalloc NinjaLiveGUI_C.__BndEvt__SpinBox_DensityNoiseAmp_K2Node_ComponentBoundEvent_1_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(NinjaLiveGUI_C.__BndEvt__SpinBox_DensityNoiseAmp_K2Node_ComponentBoundEvent_1_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLiveGUI_C.__BndEvt__SpinBox_DensityNoiseAmp_K2Node_ComponentBoundEvent_1_OnSpinBoxValueCommittedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->InValue = InValue;
			ptr->CommitMethod = CommitMethod;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLiveGUI_C.__BndEvt__SpinBox_DensityNoiseAmp_K2Node_ComponentBoundEvent_1_OnSpinBoxValueCommittedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025B53 RID: 154451 RVA: 0x009C1F84 File Offset: 0x009C0184
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__SpinBox_DensityNoiseAmp_K2Node_ComponentBoundEvent_0_OnSpinBoxValueChangedEvent__DelegateSignature(float InValue)
		{
			NinjaLiveGUI_C.__BndEvt__SpinBox_DensityNoiseAmp_K2Node_ComponentBoundEvent_0_OnSpinBoxValueChangedEvent__DelegateSignature_FunctionParams* ptr = stackalloc NinjaLiveGUI_C.__BndEvt__SpinBox_DensityNoiseAmp_K2Node_ComponentBoundEvent_0_OnSpinBoxValueChangedEvent__DelegateSignature_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(NinjaLiveGUI_C.__BndEvt__SpinBox_DensityNoiseAmp_K2Node_ComponentBoundEvent_0_OnSpinBoxValueChangedEvent__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLiveGUI_C.__BndEvt__SpinBox_DensityNoiseAmp_K2Node_ComponentBoundEvent_0_OnSpinBoxValueChangedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->InValue = InValue;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLiveGUI_C.__BndEvt__SpinBox_DensityNoiseAmp_K2Node_ComponentBoundEvent_0_OnSpinBoxValueChangedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025B54 RID: 154452 RVA: 0x009C1FCC File Offset: 0x009C01CC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__21cSpinBox_VeloOffset_K2Node_ComponentBoundEvent_1_OnSpinBoxValueChangedEvent__DelegateSignature(float InValue)
		{
			NinjaLiveGUI_C.__BndEvt__21cSpinBox_VeloOffset_K2Node_ComponentBoundEvent_1_OnSpinBoxValueChangedEvent__DelegateSignature_FunctionParams* ptr = stackalloc NinjaLiveGUI_C.__BndEvt__21cSpinBox_VeloOffset_K2Node_ComponentBoundEvent_1_OnSpinBoxValueChangedEvent__DelegateSignature_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(NinjaLiveGUI_C.__BndEvt__21cSpinBox_VeloOffset_K2Node_ComponentBoundEvent_1_OnSpinBoxValueChangedEvent__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLiveGUI_C.__BndEvt__21cSpinBox_VeloOffset_K2Node_ComponentBoundEvent_1_OnSpinBoxValueChangedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->InValue = InValue;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLiveGUI_C.__BndEvt__21cSpinBox_VeloOffset_K2Node_ComponentBoundEvent_1_OnSpinBoxValueChangedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025B55 RID: 154453 RVA: 0x009C2014 File Offset: 0x009C0214
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__21cSpinBox_VeloOffset_K2Node_ComponentBoundEvent_0_OnSpinBoxValueCommittedEvent__DelegateSignature(float InValue, ETextCommit CommitMethod)
		{
			NinjaLiveGUI_C.__BndEvt__21cSpinBox_VeloOffset_K2Node_ComponentBoundEvent_0_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams* ptr = stackalloc NinjaLiveGUI_C.__BndEvt__21cSpinBox_VeloOffset_K2Node_ComponentBoundEvent_0_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(NinjaLiveGUI_C.__BndEvt__21cSpinBox_VeloOffset_K2Node_ComponentBoundEvent_0_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLiveGUI_C.__BndEvt__21cSpinBox_VeloOffset_K2Node_ComponentBoundEvent_0_OnSpinBoxValueCommittedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->InValue = InValue;
			ptr->CommitMethod = CommitMethod;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLiveGUI_C.__BndEvt__21cSpinBox_VeloOffset_K2Node_ComponentBoundEvent_0_OnSpinBoxValueCommittedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025B56 RID: 154454 RVA: 0x009C2068 File Offset: 0x009C0268
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__SpinBox_0_K2Node_ComponentBoundEvent_1_OnSpinBoxValueChangedEvent__DelegateSignature(float InValue)
		{
			NinjaLiveGUI_C.__BndEvt__SpinBox_0_K2Node_ComponentBoundEvent_1_OnSpinBoxValueChangedEvent__DelegateSignature_FunctionParams* ptr = stackalloc NinjaLiveGUI_C.__BndEvt__SpinBox_0_K2Node_ComponentBoundEvent_1_OnSpinBoxValueChangedEvent__DelegateSignature_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(NinjaLiveGUI_C.__BndEvt__SpinBox_0_K2Node_ComponentBoundEvent_1_OnSpinBoxValueChangedEvent__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLiveGUI_C.__BndEvt__SpinBox_0_K2Node_ComponentBoundEvent_1_OnSpinBoxValueChangedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->InValue = InValue;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLiveGUI_C.__BndEvt__SpinBox_0_K2Node_ComponentBoundEvent_1_OnSpinBoxValueChangedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025B57 RID: 154455 RVA: 0x009C20B0 File Offset: 0x009C02B0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__SpinBox_0_K2Node_ComponentBoundEvent_0_OnSpinBoxValueCommittedEvent__DelegateSignature(float InValue, ETextCommit CommitMethod)
		{
			NinjaLiveGUI_C.__BndEvt__SpinBox_0_K2Node_ComponentBoundEvent_0_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams* ptr = stackalloc NinjaLiveGUI_C.__BndEvt__SpinBox_0_K2Node_ComponentBoundEvent_0_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(NinjaLiveGUI_C.__BndEvt__SpinBox_0_K2Node_ComponentBoundEvent_0_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLiveGUI_C.__BndEvt__SpinBox_0_K2Node_ComponentBoundEvent_0_OnSpinBoxValueCommittedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->InValue = InValue;
			ptr->CommitMethod = CommitMethod;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLiveGUI_C.__BndEvt__SpinBox_0_K2Node_ComponentBoundEvent_0_OnSpinBoxValueCommittedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025B58 RID: 154456 RVA: 0x009C2102 File Offset: 0x009C0302
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void BndEvt__Button_1_K2Node_ComponentBoundEvent_0_OnButtonClickedEvent__DelegateSignature()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLiveGUI_C.__BndEvt__Button_1_K2Node_ComponentBoundEvent_0_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr, null);
		}

		// Token: 0x06025B59 RID: 154457 RVA: 0x009C2118 File Offset: 0x009C0318
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__50SpinBox_BrushNoise_K2Node_ComponentBoundEvent_0_OnSpinBoxValueCommittedEvent__DelegateSignature(float InValue, ETextCommit CommitMethod)
		{
			NinjaLiveGUI_C.__BndEvt__50SpinBox_BrushNoise_K2Node_ComponentBoundEvent_0_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams* ptr = stackalloc NinjaLiveGUI_C.__BndEvt__50SpinBox_BrushNoise_K2Node_ComponentBoundEvent_0_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(NinjaLiveGUI_C.__BndEvt__50SpinBox_BrushNoise_K2Node_ComponentBoundEvent_0_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLiveGUI_C.__BndEvt__50SpinBox_BrushNoise_K2Node_ComponentBoundEvent_0_OnSpinBoxValueCommittedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->InValue = InValue;
			ptr->CommitMethod = CommitMethod;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLiveGUI_C.__BndEvt__50SpinBox_BrushNoise_K2Node_ComponentBoundEvent_0_OnSpinBoxValueCommittedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025B5A RID: 154458 RVA: 0x009C216C File Offset: 0x009C036C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__SpinBox_Density2_K2Node_ComponentBoundEvent_3_OnSpinBoxValueCommittedEvent__DelegateSignature(float InValue, ETextCommit CommitMethod)
		{
			NinjaLiveGUI_C.__BndEvt__SpinBox_Density2_K2Node_ComponentBoundEvent_3_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams* ptr = stackalloc NinjaLiveGUI_C.__BndEvt__SpinBox_Density2_K2Node_ComponentBoundEvent_3_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(NinjaLiveGUI_C.__BndEvt__SpinBox_Density2_K2Node_ComponentBoundEvent_3_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLiveGUI_C.__BndEvt__SpinBox_Density2_K2Node_ComponentBoundEvent_3_OnSpinBoxValueCommittedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->InValue = InValue;
			ptr->CommitMethod = CommitMethod;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLiveGUI_C.__BndEvt__SpinBox_Density2_K2Node_ComponentBoundEvent_3_OnSpinBoxValueCommittedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025B5B RID: 154459 RVA: 0x009C21C0 File Offset: 0x009C03C0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__SpinBox_Density3_K2Node_ComponentBoundEvent_1_OnSpinBoxValueCommittedEvent__DelegateSignature(float InValue, ETextCommit CommitMethod)
		{
			NinjaLiveGUI_C.__BndEvt__SpinBox_Density3_K2Node_ComponentBoundEvent_1_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams* ptr = stackalloc NinjaLiveGUI_C.__BndEvt__SpinBox_Density3_K2Node_ComponentBoundEvent_1_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(NinjaLiveGUI_C.__BndEvt__SpinBox_Density3_K2Node_ComponentBoundEvent_1_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLiveGUI_C.__BndEvt__SpinBox_Density3_K2Node_ComponentBoundEvent_1_OnSpinBoxValueCommittedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->InValue = InValue;
			ptr->CommitMethod = CommitMethod;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLiveGUI_C.__BndEvt__SpinBox_Density3_K2Node_ComponentBoundEvent_1_OnSpinBoxValueCommittedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025B5C RID: 154460 RVA: 0x009C2214 File Offset: 0x009C0414
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__SpinBox_Density4_K2Node_ComponentBoundEvent_0_OnSpinBoxValueCommittedEvent__DelegateSignature(float InValue, ETextCommit CommitMethod)
		{
			NinjaLiveGUI_C.__BndEvt__SpinBox_Density4_K2Node_ComponentBoundEvent_0_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams* ptr = stackalloc NinjaLiveGUI_C.__BndEvt__SpinBox_Density4_K2Node_ComponentBoundEvent_0_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(NinjaLiveGUI_C.__BndEvt__SpinBox_Density4_K2Node_ComponentBoundEvent_0_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLiveGUI_C.__BndEvt__SpinBox_Density4_K2Node_ComponentBoundEvent_0_OnSpinBoxValueCommittedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->InValue = InValue;
			ptr->CommitMethod = CommitMethod;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLiveGUI_C.__BndEvt__SpinBox_Density4_K2Node_ComponentBoundEvent_0_OnSpinBoxValueCommittedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025B5D RID: 154461 RVA: 0x009C2268 File Offset: 0x009C0468
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__45SpinBox_VeloFromSimAreaMotion_K2Node_ComponentBoundEvent_0_OnSpinBoxValueCommittedEvent__DelegateSignature(float InValue, ETextCommit CommitMethod)
		{
			NinjaLiveGUI_C.__BndEvt__45SpinBox_VeloFromSimAreaMotion_K2Node_ComponentBoundEvent_0_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams* ptr = stackalloc NinjaLiveGUI_C.__BndEvt__45SpinBox_VeloFromSimAreaMotion_K2Node_ComponentBoundEvent_0_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(NinjaLiveGUI_C.__BndEvt__45SpinBox_VeloFromSimAreaMotion_K2Node_ComponentBoundEvent_0_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLiveGUI_C.__BndEvt__45SpinBox_VeloFromSimAreaMotion_K2Node_ComponentBoundEvent_0_OnSpinBoxValueCommittedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->InValue = InValue;
			ptr->CommitMethod = CommitMethod;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLiveGUI_C.__BndEvt__45SpinBox_VeloFromSimAreaMotion_K2Node_ComponentBoundEvent_0_OnSpinBoxValueCommittedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025B5E RID: 154462 RVA: 0x009C22BC File Offset: 0x009C04BC
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__50ComboBox_NinjaOutputMaterial_K2Node_ComponentBoundEvent_0_OnSelectionChangedEvent__DelegateSignature(string SelectedItem, ESelectInfo SelectionType)
		{
			NinjaLiveGUI_C.__BndEvt__50ComboBox_NinjaOutputMaterial_K2Node_ComponentBoundEvent_0_OnSelectionChangedEvent__DelegateSignature_FunctionParams* ptr = stackalloc NinjaLiveGUI_C.__BndEvt__50ComboBox_NinjaOutputMaterial_K2Node_ComponentBoundEvent_0_OnSelectionChangedEvent__DelegateSignature_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(NinjaLiveGUI_C.__BndEvt__50ComboBox_NinjaOutputMaterial_K2Node_ComponentBoundEvent_0_OnSelectionChangedEvent__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLiveGUI_C.__BndEvt__50ComboBox_NinjaOutputMaterial_K2Node_ComponentBoundEvent_0_OnSelectionChangedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			FString.CopyFrom((void*)(&ptr->SelectedItem), SelectedItem);
			ptr->SelectionType = SelectionType;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLiveGUI_C.__BndEvt__50ComboBox_NinjaOutputMaterial_K2Node_ComponentBoundEvent_0_OnSelectionChangedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(NinjaLiveGUI_C.__BndEvt__50ComboBox_NinjaOutputMaterial_K2Node_ComponentBoundEvent_0_OnSelectionChangedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x06025B5F RID: 154463 RVA: 0x009C2328 File Offset: 0x009C0528
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__24SpinBox_DirNoise_K2Node_ComponentBoundEvent_1_OnSpinBoxValueChangedEvent__DelegateSignature(float InValue)
		{
			NinjaLiveGUI_C.__BndEvt__24SpinBox_DirNoise_K2Node_ComponentBoundEvent_1_OnSpinBoxValueChangedEvent__DelegateSignature_FunctionParams* ptr = stackalloc NinjaLiveGUI_C.__BndEvt__24SpinBox_DirNoise_K2Node_ComponentBoundEvent_1_OnSpinBoxValueChangedEvent__DelegateSignature_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(NinjaLiveGUI_C.__BndEvt__24SpinBox_DirNoise_K2Node_ComponentBoundEvent_1_OnSpinBoxValueChangedEvent__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLiveGUI_C.__BndEvt__24SpinBox_DirNoise_K2Node_ComponentBoundEvent_1_OnSpinBoxValueChangedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->InValue = InValue;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLiveGUI_C.__BndEvt__24SpinBox_DirNoise_K2Node_ComponentBoundEvent_1_OnSpinBoxValueChangedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025B60 RID: 154464 RVA: 0x009C2370 File Offset: 0x009C0570
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__24SpinBox_DirNoise_K2Node_ComponentBoundEvent_0_OnSpinBoxValueCommittedEvent__DelegateSignature(float InValue, ETextCommit CommitMethod)
		{
			NinjaLiveGUI_C.__BndEvt__24SpinBox_DirNoise_K2Node_ComponentBoundEvent_0_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams* ptr = stackalloc NinjaLiveGUI_C.__BndEvt__24SpinBox_DirNoise_K2Node_ComponentBoundEvent_0_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(NinjaLiveGUI_C.__BndEvt__24SpinBox_DirNoise_K2Node_ComponentBoundEvent_0_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLiveGUI_C.__BndEvt__24SpinBox_DirNoise_K2Node_ComponentBoundEvent_0_OnSpinBoxValueCommittedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->InValue = InValue;
			ptr->CommitMethod = CommitMethod;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLiveGUI_C.__BndEvt__24SpinBox_DirNoise_K2Node_ComponentBoundEvent_0_OnSpinBoxValueCommittedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025B61 RID: 154465 RVA: 0x009C23C4 File Offset: 0x009C05C4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__41SpinBox_BrushPuncture_K2Node_ComponentBoundEvent_0_OnSpinBoxValueCommittedEvent__DelegateSignature(float InValue, ETextCommit CommitMethod)
		{
			NinjaLiveGUI_C.__BndEvt__41SpinBox_BrushPuncture_K2Node_ComponentBoundEvent_0_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams* ptr = stackalloc NinjaLiveGUI_C.__BndEvt__41SpinBox_BrushPuncture_K2Node_ComponentBoundEvent_0_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(NinjaLiveGUI_C.__BndEvt__41SpinBox_BrushPuncture_K2Node_ComponentBoundEvent_0_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLiveGUI_C.__BndEvt__41SpinBox_BrushPuncture_K2Node_ComponentBoundEvent_0_OnSpinBoxValueCommittedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->InValue = InValue;
			ptr->CommitMethod = CommitMethod;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLiveGUI_C.__BndEvt__41SpinBox_BrushPuncture_K2Node_ComponentBoundEvent_0_OnSpinBoxValueCommittedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025B62 RID: 154466 RVA: 0x009C2418 File Offset: 0x009C0618
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__SpinBox_Add01_K2Node_ComponentBoundEvent_1_OnSpinBoxValueChangedEvent__DelegateSignature(float InValue)
		{
			NinjaLiveGUI_C.__BndEvt__SpinBox_Add01_K2Node_ComponentBoundEvent_1_OnSpinBoxValueChangedEvent__DelegateSignature_FunctionParams* ptr = stackalloc NinjaLiveGUI_C.__BndEvt__SpinBox_Add01_K2Node_ComponentBoundEvent_1_OnSpinBoxValueChangedEvent__DelegateSignature_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(NinjaLiveGUI_C.__BndEvt__SpinBox_Add01_K2Node_ComponentBoundEvent_1_OnSpinBoxValueChangedEvent__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLiveGUI_C.__BndEvt__SpinBox_Add01_K2Node_ComponentBoundEvent_1_OnSpinBoxValueChangedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->InValue = InValue;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLiveGUI_C.__BndEvt__SpinBox_Add01_K2Node_ComponentBoundEvent_1_OnSpinBoxValueChangedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025B63 RID: 154467 RVA: 0x009C2460 File Offset: 0x009C0660
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__SpinBox_Add01_K2Node_ComponentBoundEvent_0_OnSpinBoxValueCommittedEvent__DelegateSignature(float InValue, ETextCommit CommitMethod)
		{
			NinjaLiveGUI_C.__BndEvt__SpinBox_Add01_K2Node_ComponentBoundEvent_0_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams* ptr = stackalloc NinjaLiveGUI_C.__BndEvt__SpinBox_Add01_K2Node_ComponentBoundEvent_0_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(NinjaLiveGUI_C.__BndEvt__SpinBox_Add01_K2Node_ComponentBoundEvent_0_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLiveGUI_C.__BndEvt__SpinBox_Add01_K2Node_ComponentBoundEvent_0_OnSpinBoxValueCommittedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->InValue = InValue;
			ptr->CommitMethod = CommitMethod;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLiveGUI_C.__BndEvt__SpinBox_Add01_K2Node_ComponentBoundEvent_0_OnSpinBoxValueCommittedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025B64 RID: 154468 RVA: 0x009C24B4 File Offset: 0x009C06B4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__AddCheckBox1_K2Node_ComponentBoundEvent_0_OnCheckBoxComponentStateChanged__DelegateSignature(bool bIsChecked)
		{
			NinjaLiveGUI_C.__BndEvt__AddCheckBox1_K2Node_ComponentBoundEvent_0_OnCheckBoxComponentStateChanged__DelegateSignature_FunctionParams* ptr = stackalloc NinjaLiveGUI_C.__BndEvt__AddCheckBox1_K2Node_ComponentBoundEvent_0_OnCheckBoxComponentStateChanged__DelegateSignature_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(NinjaLiveGUI_C.__BndEvt__AddCheckBox1_K2Node_ComponentBoundEvent_0_OnCheckBoxComponentStateChanged__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLiveGUI_C.__BndEvt__AddCheckBox1_K2Node_ComponentBoundEvent_0_OnCheckBoxComponentStateChanged__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bIsChecked = bIsChecked;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLiveGUI_C.__BndEvt__AddCheckBox1_K2Node_ComponentBoundEvent_0_OnCheckBoxComponentStateChanged__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025B65 RID: 154469 RVA: 0x009C24FC File Offset: 0x009C06FC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__32SpinBox_DensSharpSize_K2Node_ComponentBoundEvent_41_OnSpinBoxValueChangedEvent__DelegateSignature(float InValue)
		{
			NinjaLiveGUI_C.__BndEvt__32SpinBox_DensSharpSize_K2Node_ComponentBoundEvent_41_OnSpinBoxValueChangedEvent__DelegateSignature_FunctionParams* ptr = stackalloc NinjaLiveGUI_C.__BndEvt__32SpinBox_DensSharpSize_K2Node_ComponentBoundEvent_41_OnSpinBoxValueChangedEvent__DelegateSignature_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(NinjaLiveGUI_C.__BndEvt__32SpinBox_DensSharpSize_K2Node_ComponentBoundEvent_41_OnSpinBoxValueChangedEvent__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLiveGUI_C.__BndEvt__32SpinBox_DensSharpSize_K2Node_ComponentBoundEvent_41_OnSpinBoxValueChangedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->InValue = InValue;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLiveGUI_C.__BndEvt__32SpinBox_DensSharpSize_K2Node_ComponentBoundEvent_41_OnSpinBoxValueChangedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025B66 RID: 154470 RVA: 0x009C2544 File Offset: 0x009C0744
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__31SpinBox_DensSharpen_K2Node_ComponentBoundEvent_40_OnSpinBoxValueChangedEvent__DelegateSignature(float InValue)
		{
			NinjaLiveGUI_C.__BndEvt__31SpinBox_DensSharpen_K2Node_ComponentBoundEvent_40_OnSpinBoxValueChangedEvent__DelegateSignature_FunctionParams* ptr = stackalloc NinjaLiveGUI_C.__BndEvt__31SpinBox_DensSharpen_K2Node_ComponentBoundEvent_40_OnSpinBoxValueChangedEvent__DelegateSignature_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(NinjaLiveGUI_C.__BndEvt__31SpinBox_DensSharpen_K2Node_ComponentBoundEvent_40_OnSpinBoxValueChangedEvent__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLiveGUI_C.__BndEvt__31SpinBox_DensSharpen_K2Node_ComponentBoundEvent_40_OnSpinBoxValueChangedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->InValue = InValue;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLiveGUI_C.__BndEvt__31SpinBox_DensSharpen_K2Node_ComponentBoundEvent_40_OnSpinBoxValueChangedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025B67 RID: 154471 RVA: 0x009C258C File Offset: 0x009C078C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__29SpinBox_DensHue_K2Node_ComponentBoundEvent_38_OnSpinBoxValueChangedEvent__DelegateSignature(float InValue)
		{
			NinjaLiveGUI_C.__BndEvt__29SpinBox_DensHue_K2Node_ComponentBoundEvent_38_OnSpinBoxValueChangedEvent__DelegateSignature_FunctionParams* ptr = stackalloc NinjaLiveGUI_C.__BndEvt__29SpinBox_DensHue_K2Node_ComponentBoundEvent_38_OnSpinBoxValueChangedEvent__DelegateSignature_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(NinjaLiveGUI_C.__BndEvt__29SpinBox_DensHue_K2Node_ComponentBoundEvent_38_OnSpinBoxValueChangedEvent__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLiveGUI_C.__BndEvt__29SpinBox_DensHue_K2Node_ComponentBoundEvent_38_OnSpinBoxValueChangedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->InValue = InValue;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLiveGUI_C.__BndEvt__29SpinBox_DensHue_K2Node_ComponentBoundEvent_38_OnSpinBoxValueChangedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025B68 RID: 154472 RVA: 0x009C25D4 File Offset: 0x009C07D4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__28SpinBox_DensContrast_K2Node_ComponentBoundEvent_35_OnSpinBoxValueChangedEvent__DelegateSignature(float InValue)
		{
			NinjaLiveGUI_C.__BndEvt__28SpinBox_DensContrast_K2Node_ComponentBoundEvent_35_OnSpinBoxValueChangedEvent__DelegateSignature_FunctionParams* ptr = stackalloc NinjaLiveGUI_C.__BndEvt__28SpinBox_DensContrast_K2Node_ComponentBoundEvent_35_OnSpinBoxValueChangedEvent__DelegateSignature_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(NinjaLiveGUI_C.__BndEvt__28SpinBox_DensContrast_K2Node_ComponentBoundEvent_35_OnSpinBoxValueChangedEvent__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLiveGUI_C.__BndEvt__28SpinBox_DensContrast_K2Node_ComponentBoundEvent_35_OnSpinBoxValueChangedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->InValue = InValue;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLiveGUI_C.__BndEvt__28SpinBox_DensContrast_K2Node_ComponentBoundEvent_35_OnSpinBoxValueChangedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025B69 RID: 154473 RVA: 0x009C261C File Offset: 0x009C081C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__27SpinBox_DensShading_K2Node_ComponentBoundEvent_34_OnSpinBoxValueChangedEvent__DelegateSignature(float InValue)
		{
			NinjaLiveGUI_C.__BndEvt__27SpinBox_DensShading_K2Node_ComponentBoundEvent_34_OnSpinBoxValueChangedEvent__DelegateSignature_FunctionParams* ptr = stackalloc NinjaLiveGUI_C.__BndEvt__27SpinBox_DensShading_K2Node_ComponentBoundEvent_34_OnSpinBoxValueChangedEvent__DelegateSignature_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(NinjaLiveGUI_C.__BndEvt__27SpinBox_DensShading_K2Node_ComponentBoundEvent_34_OnSpinBoxValueChangedEvent__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLiveGUI_C.__BndEvt__27SpinBox_DensShading_K2Node_ComponentBoundEvent_34_OnSpinBoxValueChangedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->InValue = InValue;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLiveGUI_C.__BndEvt__27SpinBox_DensShading_K2Node_ComponentBoundEvent_34_OnSpinBoxValueChangedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025B6A RID: 154474 RVA: 0x009C2664 File Offset: 0x009C0864
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__25SpinBox_DensInputWeight_K2Node_ComponentBoundEvent_32_OnSpinBoxValueChangedEvent__DelegateSignature(float InValue)
		{
			NinjaLiveGUI_C.__BndEvt__25SpinBox_DensInputWeight_K2Node_ComponentBoundEvent_32_OnSpinBoxValueChangedEvent__DelegateSignature_FunctionParams* ptr = stackalloc NinjaLiveGUI_C.__BndEvt__25SpinBox_DensInputWeight_K2Node_ComponentBoundEvent_32_OnSpinBoxValueChangedEvent__DelegateSignature_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(NinjaLiveGUI_C.__BndEvt__25SpinBox_DensInputWeight_K2Node_ComponentBoundEvent_32_OnSpinBoxValueChangedEvent__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLiveGUI_C.__BndEvt__25SpinBox_DensInputWeight_K2Node_ComponentBoundEvent_32_OnSpinBoxValueChangedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->InValue = InValue;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLiveGUI_C.__BndEvt__25SpinBox_DensInputWeight_K2Node_ComponentBoundEvent_32_OnSpinBoxValueChangedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025B6B RID: 154475 RVA: 0x009C26AC File Offset: 0x009C08AC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__24SpinBox_VeloNoise_K2Node_ComponentBoundEvent_31_OnSpinBoxValueChangedEvent__DelegateSignature(float InValue)
		{
			NinjaLiveGUI_C.__BndEvt__24SpinBox_VeloNoise_K2Node_ComponentBoundEvent_31_OnSpinBoxValueChangedEvent__DelegateSignature_FunctionParams* ptr = stackalloc NinjaLiveGUI_C.__BndEvt__24SpinBox_VeloNoise_K2Node_ComponentBoundEvent_31_OnSpinBoxValueChangedEvent__DelegateSignature_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(NinjaLiveGUI_C.__BndEvt__24SpinBox_VeloNoise_K2Node_ComponentBoundEvent_31_OnSpinBoxValueChangedEvent__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLiveGUI_C.__BndEvt__24SpinBox_VeloNoise_K2Node_ComponentBoundEvent_31_OnSpinBoxValueChangedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->InValue = InValue;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLiveGUI_C.__BndEvt__24SpinBox_VeloNoise_K2Node_ComponentBoundEvent_31_OnSpinBoxValueChangedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025B6C RID: 154476 RVA: 0x009C26F4 File Offset: 0x009C08F4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__22SpinBox_VeloAmplify_K2Node_ComponentBoundEvent_15_OnSpinBoxValueChangedEvent__DelegateSignature(float InValue)
		{
			NinjaLiveGUI_C.__BndEvt__22SpinBox_VeloAmplify_K2Node_ComponentBoundEvent_15_OnSpinBoxValueChangedEvent__DelegateSignature_FunctionParams* ptr = stackalloc NinjaLiveGUI_C.__BndEvt__22SpinBox_VeloAmplify_K2Node_ComponentBoundEvent_15_OnSpinBoxValueChangedEvent__DelegateSignature_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(NinjaLiveGUI_C.__BndEvt__22SpinBox_VeloAmplify_K2Node_ComponentBoundEvent_15_OnSpinBoxValueChangedEvent__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLiveGUI_C.__BndEvt__22SpinBox_VeloAmplify_K2Node_ComponentBoundEvent_15_OnSpinBoxValueChangedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->InValue = InValue;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLiveGUI_C.__BndEvt__22SpinBox_VeloAmplify_K2Node_ComponentBoundEvent_15_OnSpinBoxValueChangedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025B6D RID: 154477 RVA: 0x009C273C File Offset: 0x009C093C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__21SpinBox_VeloRotate_K2Node_ComponentBoundEvent_13_OnSpinBoxValueChangedEvent__DelegateSignature(float InValue)
		{
			NinjaLiveGUI_C.__BndEvt__21SpinBox_VeloRotate_K2Node_ComponentBoundEvent_13_OnSpinBoxValueChangedEvent__DelegateSignature_FunctionParams* ptr = stackalloc NinjaLiveGUI_C.__BndEvt__21SpinBox_VeloRotate_K2Node_ComponentBoundEvent_13_OnSpinBoxValueChangedEvent__DelegateSignature_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(NinjaLiveGUI_C.__BndEvt__21SpinBox_VeloRotate_K2Node_ComponentBoundEvent_13_OnSpinBoxValueChangedEvent__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLiveGUI_C.__BndEvt__21SpinBox_VeloRotate_K2Node_ComponentBoundEvent_13_OnSpinBoxValueChangedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->InValue = InValue;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLiveGUI_C.__BndEvt__21SpinBox_VeloRotate_K2Node_ComponentBoundEvent_13_OnSpinBoxValueChangedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025B6E RID: 154478 RVA: 0x009C2784 File Offset: 0x009C0984
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__20SpinBox_VeloOffsetY_K2Node_ComponentBoundEvent_12_OnSpinBoxValueChangedEvent__DelegateSignature(float InValue)
		{
			NinjaLiveGUI_C.__BndEvt__20SpinBox_VeloOffsetY_K2Node_ComponentBoundEvent_12_OnSpinBoxValueChangedEvent__DelegateSignature_FunctionParams* ptr = stackalloc NinjaLiveGUI_C.__BndEvt__20SpinBox_VeloOffsetY_K2Node_ComponentBoundEvent_12_OnSpinBoxValueChangedEvent__DelegateSignature_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(NinjaLiveGUI_C.__BndEvt__20SpinBox_VeloOffsetY_K2Node_ComponentBoundEvent_12_OnSpinBoxValueChangedEvent__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLiveGUI_C.__BndEvt__20SpinBox_VeloOffsetY_K2Node_ComponentBoundEvent_12_OnSpinBoxValueChangedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->InValue = InValue;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLiveGUI_C.__BndEvt__20SpinBox_VeloOffsetY_K2Node_ComponentBoundEvent_12_OnSpinBoxValueChangedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025B6F RID: 154479 RVA: 0x009C27CC File Offset: 0x009C09CC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__19SpinBox_VeloOffsetX_K2Node_ComponentBoundEvent_10_OnSpinBoxValueChangedEvent__DelegateSignature(float InValue)
		{
			NinjaLiveGUI_C.__BndEvt__19SpinBox_VeloOffsetX_K2Node_ComponentBoundEvent_10_OnSpinBoxValueChangedEvent__DelegateSignature_FunctionParams* ptr = stackalloc NinjaLiveGUI_C.__BndEvt__19SpinBox_VeloOffsetX_K2Node_ComponentBoundEvent_10_OnSpinBoxValueChangedEvent__DelegateSignature_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(NinjaLiveGUI_C.__BndEvt__19SpinBox_VeloOffsetX_K2Node_ComponentBoundEvent_10_OnSpinBoxValueChangedEvent__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLiveGUI_C.__BndEvt__19SpinBox_VeloOffsetX_K2Node_ComponentBoundEvent_10_OnSpinBoxValueChangedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->InValue = InValue;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLiveGUI_C.__BndEvt__19SpinBox_VeloOffsetX_K2Node_ComponentBoundEvent_10_OnSpinBoxValueChangedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025B70 RID: 154480 RVA: 0x009C2814 File Offset: 0x009C0A14
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__SpinBox_63_K2Node_ComponentBoundEvent_228_OnSpinBoxValueCommittedEvent__DelegateSignature(float InValue, ETextCommit CommitMethod)
		{
			NinjaLiveGUI_C.__BndEvt__SpinBox_63_K2Node_ComponentBoundEvent_228_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams* ptr = stackalloc NinjaLiveGUI_C.__BndEvt__SpinBox_63_K2Node_ComponentBoundEvent_228_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(NinjaLiveGUI_C.__BndEvt__SpinBox_63_K2Node_ComponentBoundEvent_228_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLiveGUI_C.__BndEvt__SpinBox_63_K2Node_ComponentBoundEvent_228_OnSpinBoxValueCommittedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->InValue = InValue;
			ptr->CommitMethod = CommitMethod;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLiveGUI_C.__BndEvt__SpinBox_63_K2Node_ComponentBoundEvent_228_OnSpinBoxValueCommittedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025B71 RID: 154481 RVA: 0x009C2868 File Offset: 0x009C0A68
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__SpinBox_62_K2Node_ComponentBoundEvent_121_OnSpinBoxValueCommittedEvent__DelegateSignature(float InValue, ETextCommit CommitMethod)
		{
			NinjaLiveGUI_C.__BndEvt__SpinBox_62_K2Node_ComponentBoundEvent_121_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams* ptr = stackalloc NinjaLiveGUI_C.__BndEvt__SpinBox_62_K2Node_ComponentBoundEvent_121_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(NinjaLiveGUI_C.__BndEvt__SpinBox_62_K2Node_ComponentBoundEvent_121_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLiveGUI_C.__BndEvt__SpinBox_62_K2Node_ComponentBoundEvent_121_OnSpinBoxValueCommittedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->InValue = InValue;
			ptr->CommitMethod = CommitMethod;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLiveGUI_C.__BndEvt__SpinBox_62_K2Node_ComponentBoundEvent_121_OnSpinBoxValueCommittedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025B72 RID: 154482 RVA: 0x009C28BC File Offset: 0x009C0ABC
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__MultiLineEditableText_MetaData_K2Node_ComponentBoundEvent_26_OnMultiLineEditableTextCommittedEvent__DelegateSignature(in FText Text, ETextCommit CommitMethod)
		{
			NinjaLiveGUI_C.__BndEvt__MultiLineEditableText_MetaData_K2Node_ComponentBoundEvent_26_OnMultiLineEditableTextCommittedEvent__DelegateSignature_FunctionParams* ptr = stackalloc NinjaLiveGUI_C.__BndEvt__MultiLineEditableText_MetaData_K2Node_ComponentBoundEvent_26_OnMultiLineEditableTextCommittedEvent__DelegateSignature_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(NinjaLiveGUI_C.__BndEvt__MultiLineEditableText_MetaData_K2Node_ComponentBoundEvent_26_OnMultiLineEditableTextCommittedEvent__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLiveGUI_C.__BndEvt__MultiLineEditableText_MetaData_K2Node_ComponentBoundEvent_26_OnMultiLineEditableTextCommittedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			FText.NativeMove((void*)(&ptr->Text), Text.NativePtr);
			ptr->CommitMethod = CommitMethod;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLiveGUI_C.__BndEvt__MultiLineEditableText_MetaData_K2Node_ComponentBoundEvent_26_OnMultiLineEditableTextCommittedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(NinjaLiveGUI_C.__BndEvt__MultiLineEditableText_MetaData_K2Node_ComponentBoundEvent_26_OnMultiLineEditableTextCommittedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x06025B73 RID: 154483 RVA: 0x009C292C File Offset: 0x009C0B2C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__SpinBox_60_K2Node_ComponentBoundEvent_225_OnSpinBoxValueCommittedEvent__DelegateSignature(float InValue, ETextCommit CommitMethod)
		{
			NinjaLiveGUI_C.__BndEvt__SpinBox_60_K2Node_ComponentBoundEvent_225_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams* ptr = stackalloc NinjaLiveGUI_C.__BndEvt__SpinBox_60_K2Node_ComponentBoundEvent_225_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(NinjaLiveGUI_C.__BndEvt__SpinBox_60_K2Node_ComponentBoundEvent_225_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLiveGUI_C.__BndEvt__SpinBox_60_K2Node_ComponentBoundEvent_225_OnSpinBoxValueCommittedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->InValue = InValue;
			ptr->CommitMethod = CommitMethod;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLiveGUI_C.__BndEvt__SpinBox_60_K2Node_ComponentBoundEvent_225_OnSpinBoxValueCommittedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025B74 RID: 154484 RVA: 0x009C297E File Offset: 0x009C0B7E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void BndEvt__ComboBox_NinjaTemplate3_K2Node_ComponentBoundEvent_224_OnOpeningEvent__DelegateSignature()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLiveGUI_C.__BndEvt__ComboBox_NinjaTemplate3_K2Node_ComponentBoundEvent_224_OnOpeningEvent__DelegateSignature_NativeFunctionPtr, null);
		}

		// Token: 0x06025B75 RID: 154485 RVA: 0x009C2994 File Offset: 0x009C0B94
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__ComboBox_NinjaTemplate3_K2Node_ComponentBoundEvent_223_OnSelectionChangedEvent__DelegateSignature(string SelectedItem, ESelectInfo SelectionType)
		{
			NinjaLiveGUI_C.__BndEvt__ComboBox_NinjaTemplate3_K2Node_ComponentBoundEvent_223_OnSelectionChangedEvent__DelegateSignature_FunctionParams* ptr = stackalloc NinjaLiveGUI_C.__BndEvt__ComboBox_NinjaTemplate3_K2Node_ComponentBoundEvent_223_OnSelectionChangedEvent__DelegateSignature_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(NinjaLiveGUI_C.__BndEvt__ComboBox_NinjaTemplate3_K2Node_ComponentBoundEvent_223_OnSelectionChangedEvent__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLiveGUI_C.__BndEvt__ComboBox_NinjaTemplate3_K2Node_ComponentBoundEvent_223_OnSelectionChangedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			FString.CopyFrom((void*)(&ptr->SelectedItem), SelectedItem);
			ptr->SelectionType = SelectionType;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLiveGUI_C.__BndEvt__ComboBox_NinjaTemplate3_K2Node_ComponentBoundEvent_223_OnSelectionChangedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(NinjaLiveGUI_C.__BndEvt__ComboBox_NinjaTemplate3_K2Node_ComponentBoundEvent_223_OnSelectionChangedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x06025B76 RID: 154486 RVA: 0x009C29FD File Offset: 0x009C0BFD
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void BndEvt__ComboBox_NinjaTemplate2_K2Node_ComponentBoundEvent_222_OnOpeningEvent__DelegateSignature()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLiveGUI_C.__BndEvt__ComboBox_NinjaTemplate2_K2Node_ComponentBoundEvent_222_OnOpeningEvent__DelegateSignature_NativeFunctionPtr, null);
		}

		// Token: 0x06025B77 RID: 154487 RVA: 0x009C2A14 File Offset: 0x009C0C14
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__ComboBox_NinjaTemplate2_K2Node_ComponentBoundEvent_120_OnSelectionChangedEvent__DelegateSignature(string SelectedItem, ESelectInfo SelectionType)
		{
			NinjaLiveGUI_C.__BndEvt__ComboBox_NinjaTemplate2_K2Node_ComponentBoundEvent_120_OnSelectionChangedEvent__DelegateSignature_FunctionParams* ptr = stackalloc NinjaLiveGUI_C.__BndEvt__ComboBox_NinjaTemplate2_K2Node_ComponentBoundEvent_120_OnSelectionChangedEvent__DelegateSignature_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(NinjaLiveGUI_C.__BndEvt__ComboBox_NinjaTemplate2_K2Node_ComponentBoundEvent_120_OnSelectionChangedEvent__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLiveGUI_C.__BndEvt__ComboBox_NinjaTemplate2_K2Node_ComponentBoundEvent_120_OnSelectionChangedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			FString.CopyFrom((void*)(&ptr->SelectedItem), SelectedItem);
			ptr->SelectionType = SelectionType;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLiveGUI_C.__BndEvt__ComboBox_NinjaTemplate2_K2Node_ComponentBoundEvent_120_OnSelectionChangedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(NinjaLiveGUI_C.__BndEvt__ComboBox_NinjaTemplate2_K2Node_ComponentBoundEvent_120_OnSelectionChangedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x06025B78 RID: 154488 RVA: 0x009C2A80 File Offset: 0x009C0C80
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__ComboBox_NinjaTemplate1_K2Node_ComponentBoundEvent_220_OnSelectionChangedEvent__DelegateSignature(string SelectedItem, ESelectInfo SelectionType)
		{
			NinjaLiveGUI_C.__BndEvt__ComboBox_NinjaTemplate1_K2Node_ComponentBoundEvent_220_OnSelectionChangedEvent__DelegateSignature_FunctionParams* ptr = stackalloc NinjaLiveGUI_C.__BndEvt__ComboBox_NinjaTemplate1_K2Node_ComponentBoundEvent_220_OnSelectionChangedEvent__DelegateSignature_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(NinjaLiveGUI_C.__BndEvt__ComboBox_NinjaTemplate1_K2Node_ComponentBoundEvent_220_OnSelectionChangedEvent__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLiveGUI_C.__BndEvt__ComboBox_NinjaTemplate1_K2Node_ComponentBoundEvent_220_OnSelectionChangedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			FString.CopyFrom((void*)(&ptr->SelectedItem), SelectedItem);
			ptr->SelectionType = SelectionType;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLiveGUI_C.__BndEvt__ComboBox_NinjaTemplate1_K2Node_ComponentBoundEvent_220_OnSelectionChangedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(NinjaLiveGUI_C.__BndEvt__ComboBox_NinjaTemplate1_K2Node_ComponentBoundEvent_220_OnSelectionChangedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x06025B79 RID: 154489 RVA: 0x009C2AEC File Offset: 0x009C0CEC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__SpinBox_26_K2Node_ComponentBoundEvent_128_OnSpinBoxValueCommittedEvent__DelegateSignature(float InValue, ETextCommit CommitMethod)
		{
			NinjaLiveGUI_C.__BndEvt__SpinBox_26_K2Node_ComponentBoundEvent_128_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams* ptr = stackalloc NinjaLiveGUI_C.__BndEvt__SpinBox_26_K2Node_ComponentBoundEvent_128_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(NinjaLiveGUI_C.__BndEvt__SpinBox_26_K2Node_ComponentBoundEvent_128_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLiveGUI_C.__BndEvt__SpinBox_26_K2Node_ComponentBoundEvent_128_OnSpinBoxValueCommittedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->InValue = InValue;
			ptr->CommitMethod = CommitMethod;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLiveGUI_C.__BndEvt__SpinBox_26_K2Node_ComponentBoundEvent_128_OnSpinBoxValueCommittedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025B7A RID: 154490 RVA: 0x009C2B3E File Offset: 0x009C0D3E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void BndEvt__Button_14_K2Node_ComponentBoundEvent_123_OnButtonClickedEvent__DelegateSignature()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLiveGUI_C.__BndEvt__Button_14_K2Node_ComponentBoundEvent_123_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr, null);
		}

		// Token: 0x06025B7B RID: 154491 RVA: 0x009C2B54 File Offset: 0x009C0D54
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__SpinBox_22_K2Node_ComponentBoundEvent_102_OnSpinBoxValueCommittedEvent__DelegateSignature(float InValue, ETextCommit CommitMethod)
		{
			NinjaLiveGUI_C.__BndEvt__SpinBox_22_K2Node_ComponentBoundEvent_102_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams* ptr = stackalloc NinjaLiveGUI_C.__BndEvt__SpinBox_22_K2Node_ComponentBoundEvent_102_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(NinjaLiveGUI_C.__BndEvt__SpinBox_22_K2Node_ComponentBoundEvent_102_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLiveGUI_C.__BndEvt__SpinBox_22_K2Node_ComponentBoundEvent_102_OnSpinBoxValueCommittedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->InValue = InValue;
			ptr->CommitMethod = CommitMethod;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLiveGUI_C.__BndEvt__SpinBox_22_K2Node_ComponentBoundEvent_102_OnSpinBoxValueCommittedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025B7C RID: 154492 RVA: 0x009C2BA8 File Offset: 0x009C0DA8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__SpinBox_23_K2Node_ComponentBoundEvent_100_OnSpinBoxValueCommittedEvent__DelegateSignature(float InValue, ETextCommit CommitMethod)
		{
			NinjaLiveGUI_C.__BndEvt__SpinBox_23_K2Node_ComponentBoundEvent_100_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams* ptr = stackalloc NinjaLiveGUI_C.__BndEvt__SpinBox_23_K2Node_ComponentBoundEvent_100_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(NinjaLiveGUI_C.__BndEvt__SpinBox_23_K2Node_ComponentBoundEvent_100_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLiveGUI_C.__BndEvt__SpinBox_23_K2Node_ComponentBoundEvent_100_OnSpinBoxValueCommittedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->InValue = InValue;
			ptr->CommitMethod = CommitMethod;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLiveGUI_C.__BndEvt__SpinBox_23_K2Node_ComponentBoundEvent_100_OnSpinBoxValueCommittedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025B7D RID: 154493 RVA: 0x009C2BFC File Offset: 0x009C0DFC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__SpinBox_19_K2Node_ComponentBoundEvent_70_OnSpinBoxValueCommittedEvent__DelegateSignature(float InValue, ETextCommit CommitMethod)
		{
			NinjaLiveGUI_C.__BndEvt__SpinBox_19_K2Node_ComponentBoundEvent_70_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams* ptr = stackalloc NinjaLiveGUI_C.__BndEvt__SpinBox_19_K2Node_ComponentBoundEvent_70_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(NinjaLiveGUI_C.__BndEvt__SpinBox_19_K2Node_ComponentBoundEvent_70_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLiveGUI_C.__BndEvt__SpinBox_19_K2Node_ComponentBoundEvent_70_OnSpinBoxValueCommittedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->InValue = InValue;
			ptr->CommitMethod = CommitMethod;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLiveGUI_C.__BndEvt__SpinBox_19_K2Node_ComponentBoundEvent_70_OnSpinBoxValueCommittedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025B7E RID: 154494 RVA: 0x009C2C50 File Offset: 0x009C0E50
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__SpinBox_18_K2Node_ComponentBoundEvent_94_OnSpinBoxValueCommittedEvent__DelegateSignature(float InValue, ETextCommit CommitMethod)
		{
			NinjaLiveGUI_C.__BndEvt__SpinBox_18_K2Node_ComponentBoundEvent_94_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams* ptr = stackalloc NinjaLiveGUI_C.__BndEvt__SpinBox_18_K2Node_ComponentBoundEvent_94_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(NinjaLiveGUI_C.__BndEvt__SpinBox_18_K2Node_ComponentBoundEvent_94_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLiveGUI_C.__BndEvt__SpinBox_18_K2Node_ComponentBoundEvent_94_OnSpinBoxValueCommittedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->InValue = InValue;
			ptr->CommitMethod = CommitMethod;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLiveGUI_C.__BndEvt__SpinBox_18_K2Node_ComponentBoundEvent_94_OnSpinBoxValueCommittedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025B7F RID: 154495 RVA: 0x009C2CA4 File Offset: 0x009C0EA4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__SpinBox_17_K2Node_ComponentBoundEvent_78_OnSpinBoxValueCommittedEvent__DelegateSignature(float InValue, ETextCommit CommitMethod)
		{
			NinjaLiveGUI_C.__BndEvt__SpinBox_17_K2Node_ComponentBoundEvent_78_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams* ptr = stackalloc NinjaLiveGUI_C.__BndEvt__SpinBox_17_K2Node_ComponentBoundEvent_78_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(NinjaLiveGUI_C.__BndEvt__SpinBox_17_K2Node_ComponentBoundEvent_78_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLiveGUI_C.__BndEvt__SpinBox_17_K2Node_ComponentBoundEvent_78_OnSpinBoxValueCommittedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->InValue = InValue;
			ptr->CommitMethod = CommitMethod;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLiveGUI_C.__BndEvt__SpinBox_17_K2Node_ComponentBoundEvent_78_OnSpinBoxValueCommittedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025B80 RID: 154496 RVA: 0x009C2CF8 File Offset: 0x009C0EF8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__SpinBox_16_K2Node_ComponentBoundEvent_76_OnSpinBoxValueCommittedEvent__DelegateSignature(float InValue, ETextCommit CommitMethod)
		{
			NinjaLiveGUI_C.__BndEvt__SpinBox_16_K2Node_ComponentBoundEvent_76_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams* ptr = stackalloc NinjaLiveGUI_C.__BndEvt__SpinBox_16_K2Node_ComponentBoundEvent_76_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(NinjaLiveGUI_C.__BndEvt__SpinBox_16_K2Node_ComponentBoundEvent_76_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLiveGUI_C.__BndEvt__SpinBox_16_K2Node_ComponentBoundEvent_76_OnSpinBoxValueCommittedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->InValue = InValue;
			ptr->CommitMethod = CommitMethod;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLiveGUI_C.__BndEvt__SpinBox_16_K2Node_ComponentBoundEvent_76_OnSpinBoxValueCommittedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025B81 RID: 154497 RVA: 0x009C2D4C File Offset: 0x009C0F4C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__SpinBox_15_K2Node_ComponentBoundEvent_74_OnSpinBoxValueCommittedEvent__DelegateSignature(float InValue, ETextCommit CommitMethod)
		{
			NinjaLiveGUI_C.__BndEvt__SpinBox_15_K2Node_ComponentBoundEvent_74_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams* ptr = stackalloc NinjaLiveGUI_C.__BndEvt__SpinBox_15_K2Node_ComponentBoundEvent_74_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(NinjaLiveGUI_C.__BndEvt__SpinBox_15_K2Node_ComponentBoundEvent_74_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLiveGUI_C.__BndEvt__SpinBox_15_K2Node_ComponentBoundEvent_74_OnSpinBoxValueCommittedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->InValue = InValue;
			ptr->CommitMethod = CommitMethod;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLiveGUI_C.__BndEvt__SpinBox_15_K2Node_ComponentBoundEvent_74_OnSpinBoxValueCommittedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025B82 RID: 154498 RVA: 0x009C2DA0 File Offset: 0x009C0FA0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__SpinBox_14_K2Node_ComponentBoundEvent_72_OnSpinBoxValueCommittedEvent__DelegateSignature(float InValue, ETextCommit CommitMethod)
		{
			NinjaLiveGUI_C.__BndEvt__SpinBox_14_K2Node_ComponentBoundEvent_72_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams* ptr = stackalloc NinjaLiveGUI_C.__BndEvt__SpinBox_14_K2Node_ComponentBoundEvent_72_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(NinjaLiveGUI_C.__BndEvt__SpinBox_14_K2Node_ComponentBoundEvent_72_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLiveGUI_C.__BndEvt__SpinBox_14_K2Node_ComponentBoundEvent_72_OnSpinBoxValueCommittedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->InValue = InValue;
			ptr->CommitMethod = CommitMethod;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLiveGUI_C.__BndEvt__SpinBox_14_K2Node_ComponentBoundEvent_72_OnSpinBoxValueCommittedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025B83 RID: 154499 RVA: 0x009C2DF4 File Offset: 0x009C0FF4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__SpinBox_12_K2Node_ComponentBoundEvent_64_OnSpinBoxValueCommittedEvent__DelegateSignature(float InValue, ETextCommit CommitMethod)
		{
			NinjaLiveGUI_C.__BndEvt__SpinBox_12_K2Node_ComponentBoundEvent_64_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams* ptr = stackalloc NinjaLiveGUI_C.__BndEvt__SpinBox_12_K2Node_ComponentBoundEvent_64_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(NinjaLiveGUI_C.__BndEvt__SpinBox_12_K2Node_ComponentBoundEvent_64_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLiveGUI_C.__BndEvt__SpinBox_12_K2Node_ComponentBoundEvent_64_OnSpinBoxValueCommittedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->InValue = InValue;
			ptr->CommitMethod = CommitMethod;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLiveGUI_C.__BndEvt__SpinBox_12_K2Node_ComponentBoundEvent_64_OnSpinBoxValueCommittedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025B84 RID: 154500 RVA: 0x009C2E48 File Offset: 0x009C1048
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__SpinBox_11_K2Node_ComponentBoundEvent_60_OnSpinBoxValueCommittedEvent__DelegateSignature(float InValue, ETextCommit CommitMethod)
		{
			NinjaLiveGUI_C.__BndEvt__SpinBox_11_K2Node_ComponentBoundEvent_60_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams* ptr = stackalloc NinjaLiveGUI_C.__BndEvt__SpinBox_11_K2Node_ComponentBoundEvent_60_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(NinjaLiveGUI_C.__BndEvt__SpinBox_11_K2Node_ComponentBoundEvent_60_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLiveGUI_C.__BndEvt__SpinBox_11_K2Node_ComponentBoundEvent_60_OnSpinBoxValueCommittedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->InValue = InValue;
			ptr->CommitMethod = CommitMethod;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLiveGUI_C.__BndEvt__SpinBox_11_K2Node_ComponentBoundEvent_60_OnSpinBoxValueCommittedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025B85 RID: 154501 RVA: 0x009C2E9C File Offset: 0x009C109C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__SpinBox_10_K2Node_ComponentBoundEvent_55_OnSpinBoxValueCommittedEvent__DelegateSignature(float InValue, ETextCommit CommitMethod)
		{
			NinjaLiveGUI_C.__BndEvt__SpinBox_10_K2Node_ComponentBoundEvent_55_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams* ptr = stackalloc NinjaLiveGUI_C.__BndEvt__SpinBox_10_K2Node_ComponentBoundEvent_55_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(NinjaLiveGUI_C.__BndEvt__SpinBox_10_K2Node_ComponentBoundEvent_55_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLiveGUI_C.__BndEvt__SpinBox_10_K2Node_ComponentBoundEvent_55_OnSpinBoxValueCommittedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->InValue = InValue;
			ptr->CommitMethod = CommitMethod;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLiveGUI_C.__BndEvt__SpinBox_10_K2Node_ComponentBoundEvent_55_OnSpinBoxValueCommittedEvent__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025B86 RID: 154502 RVA: 0x009C2EEE File Offset: 0x009C10EE
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void BndEvt__Main9_Button_PreferredPreset_K2Node_ComponentBoundEvent_0_OnButtonClickedEvent__DelegateSignature()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLiveGUI_C.__BndEvt__Main9_Button_PreferredPreset_K2Node_ComponentBoundEvent_0_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr, null);
		}

		// Token: 0x06025B87 RID: 154503 RVA: 0x009C2F04 File Offset: 0x009C1104
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_NinjaLiveGUI(int EntryPoint)
		{
			NinjaLiveGUI_C.__ExecuteUbergraph_NinjaLiveGUI_FunctionParams* ptr = stackalloc NinjaLiveGUI_C.__ExecuteUbergraph_NinjaLiveGUI_FunctionParams[(UIntPtr)10279] + 15L / (long)sizeof(NinjaLiveGUI_C.__ExecuteUbergraph_NinjaLiveGUI_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLiveGUI_C.__ExecuteUbergraph_NinjaLiveGUI_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, NinjaLiveGUI_C.__ExecuteUbergraph_NinjaLiveGUI_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06025B88 RID: 154504 RVA: 0x009C2F4E File Offset: 0x009C114E
		protected NinjaLiveGUI_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040136DB RID: 79579
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/FluidNinjaLive/Core/NinjaLiveGUI.NinjaLiveGUI_C";

		// Token: 0x040136DC RID: 79580
		private static IntPtr _ClassPtr;

		// Token: 0x040136DD RID: 79581
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040136DE RID: 79582
		public static IntPtr __OnPresetDuplicated__DelegateSignature_NativeFunctionPtr;

		// Token: 0x040136DF RID: 79583
		public static IntPtr __OnDensityMapSave__DelegateSignature_NativeFunctionPtr;

		// Token: 0x040136E0 RID: 79584
		public static IntPtr __OnPresetSave__DelegateSignature_NativeFunctionPtr;

		// Token: 0x040136E1 RID: 79585
		public static IntPtr __OnPresetSelectionChanged__DelegateSignature_NativeFunctionPtr;

		// Token: 0x040136E2 RID: 79586
		public static IntPtr __OnSelectionChanged__DelegateSignature_NativeFunctionPtr;

		// Token: 0x040136E3 RID: 79587
		internal static int __PropertyOffset_0;

		// Token: 0x040136E4 RID: 79588
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040136E5 RID: 79589
		internal static int __PropertyOffset_1;

		// Token: 0x040136E6 RID: 79590
		internal static int __PropertyOffset_2;

		// Token: 0x040136E7 RID: 79591
		internal static int __PropertyOffset_3;

		// Token: 0x040136E8 RID: 79592
		internal static int __PropertyOffset_4;

		// Token: 0x040136E9 RID: 79593
		internal static int __PropertyOffset_5;

		// Token: 0x040136EA RID: 79594
		internal static int __PropertyOffset_6;

		// Token: 0x040136EB RID: 79595
		internal static int __PropertyOffset_7;

		// Token: 0x040136EC RID: 79596
		internal static int __PropertyOffset_8;

		// Token: 0x040136ED RID: 79597
		internal static int __PropertyOffset_9;

		// Token: 0x040136EE RID: 79598
		internal static int __PropertyOffset_10;

		// Token: 0x040136EF RID: 79599
		internal static int __PropertyOffset_11;

		// Token: 0x040136F0 RID: 79600
		internal static int __PropertyOffset_12;

		// Token: 0x040136F1 RID: 79601
		internal static int __PropertyOffset_13;

		// Token: 0x040136F2 RID: 79602
		internal static int __PropertyOffset_14;

		// Token: 0x040136F3 RID: 79603
		internal static int __PropertyOffset_15;

		// Token: 0x040136F4 RID: 79604
		internal static int __PropertyOffset_16;

		// Token: 0x040136F5 RID: 79605
		internal static int __PropertyOffset_17;

		// Token: 0x040136F6 RID: 79606
		internal static int __PropertyOffset_18;

		// Token: 0x040136F7 RID: 79607
		internal static int __PropertyOffset_19;

		// Token: 0x040136F8 RID: 79608
		internal static int __PropertyOffset_20;

		// Token: 0x040136F9 RID: 79609
		internal static int __PropertyOffset_21;

		// Token: 0x040136FA RID: 79610
		internal static int __PropertyOffset_22;

		// Token: 0x040136FB RID: 79611
		internal static int __PropertyOffset_23;

		// Token: 0x040136FC RID: 79612
		internal static int __PropertyOffset_24;

		// Token: 0x040136FD RID: 79613
		internal static int __PropertyOffset_25;

		// Token: 0x040136FE RID: 79614
		internal static int __PropertyOffset_26;

		// Token: 0x040136FF RID: 79615
		internal static int __PropertyOffset_27;

		// Token: 0x04013700 RID: 79616
		internal static int __PropertyOffset_28;

		// Token: 0x04013701 RID: 79617
		internal static int __PropertyOffset_29;

		// Token: 0x04013702 RID: 79618
		internal static int __PropertyOffset_30;

		// Token: 0x04013703 RID: 79619
		internal static int __PropertyOffset_31;

		// Token: 0x04013704 RID: 79620
		internal static int __PropertyOffset_32;

		// Token: 0x04013705 RID: 79621
		internal static int __PropertyOffset_33;

		// Token: 0x04013706 RID: 79622
		internal static int __PropertyOffset_34;

		// Token: 0x04013707 RID: 79623
		internal static int __PropertyOffset_35;

		// Token: 0x04013708 RID: 79624
		internal static int __PropertyOffset_36;

		// Token: 0x04013709 RID: 79625
		internal static int __PropertyOffset_37;

		// Token: 0x0401370A RID: 79626
		internal static int __PropertyOffset_38;

		// Token: 0x0401370B RID: 79627
		internal static int __PropertyOffset_39;

		// Token: 0x0401370C RID: 79628
		internal static int __PropertyOffset_40;

		// Token: 0x0401370D RID: 79629
		internal static int __PropertyOffset_41;

		// Token: 0x0401370E RID: 79630
		internal static int __PropertyOffset_42;

		// Token: 0x0401370F RID: 79631
		internal static int __PropertyOffset_43;

		// Token: 0x04013710 RID: 79632
		internal static int __PropertyOffset_44;

		// Token: 0x04013711 RID: 79633
		internal static int __PropertyOffset_45;

		// Token: 0x04013712 RID: 79634
		internal static int __PropertyOffset_46;

		// Token: 0x04013713 RID: 79635
		internal static int __PropertyOffset_47;

		// Token: 0x04013714 RID: 79636
		internal static int __PropertyOffset_48;

		// Token: 0x04013715 RID: 79637
		internal static int __PropertyOffset_49;

		// Token: 0x04013716 RID: 79638
		internal static int __PropertyOffset_50;

		// Token: 0x04013717 RID: 79639
		internal static int __PropertyOffset_51;

		// Token: 0x04013718 RID: 79640
		internal static int __PropertyOffset_52;

		// Token: 0x04013719 RID: 79641
		internal static int __PropertyOffset_53;

		// Token: 0x0401371A RID: 79642
		internal static int __PropertyOffset_54;

		// Token: 0x0401371B RID: 79643
		internal static int __PropertyOffset_55;

		// Token: 0x0401371C RID: 79644
		internal static int __PropertyOffset_56;

		// Token: 0x0401371D RID: 79645
		internal static int __PropertyOffset_57;

		// Token: 0x0401371E RID: 79646
		internal static int __PropertyOffset_58;

		// Token: 0x0401371F RID: 79647
		internal static int __PropertyOffset_59;

		// Token: 0x04013720 RID: 79648
		internal static int __PropertyOffset_60;

		// Token: 0x04013721 RID: 79649
		internal static int __PropertyOffset_61;

		// Token: 0x04013722 RID: 79650
		internal static int __PropertyOffset_62;

		// Token: 0x04013723 RID: 79651
		internal static int __PropertyOffset_63;

		// Token: 0x04013724 RID: 79652
		internal static int __PropertyOffset_64;

		// Token: 0x04013725 RID: 79653
		internal static int __PropertyOffset_65;

		// Token: 0x04013726 RID: 79654
		internal static int __PropertyOffset_66;

		// Token: 0x04013727 RID: 79655
		internal static int __PropertyOffset_67;

		// Token: 0x04013728 RID: 79656
		internal static int __PropertyOffset_68;

		// Token: 0x04013729 RID: 79657
		internal static int __PropertyOffset_69;

		// Token: 0x0401372A RID: 79658
		internal static int __PropertyOffset_70;

		// Token: 0x0401372B RID: 79659
		internal static int __PropertyOffset_71;

		// Token: 0x0401372C RID: 79660
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UNamedSlot> _ArrayOfWidgets;

		// Token: 0x0401372D RID: 79661
		internal static int __PropertyOffset_72;

		// Token: 0x0401372E RID: 79662
		internal static int __PropertyOffset_73;

		// Token: 0x0401372F RID: 79663
		internal static int __PropertyOffset_74;

		// Token: 0x04013730 RID: 79664
		internal static int __PropertyOffset_75;

		// Token: 0x04013731 RID: 79665
		private OnSelectionChanged _OnSelectionChanged;

		// Token: 0x04013732 RID: 79666
		internal static int __PropertyOffset_76;

		// Token: 0x04013733 RID: 79667
		private OnPresetSelectionChanged _OnPresetSelectionChanged;

		// Token: 0x04013734 RID: 79668
		internal static int __PropertyOffset_77;

		// Token: 0x04013735 RID: 79669
		private OnPresetSave _OnPresetSave;

		// Token: 0x04013736 RID: 79670
		internal static int __PropertyOffset_78;

		// Token: 0x04013737 RID: 79671
		internal static int __PropertyOffset_79;

		// Token: 0x04013738 RID: 79672
		internal static int __PropertyOffset_80;

		// Token: 0x04013739 RID: 79673
		internal static int __PropertyOffset_81;

		// Token: 0x0401373A RID: 79674
		internal static int __PropertyOffset_82;

		// Token: 0x0401373B RID: 79675
		private TArray<FName> _TempVarOfParticleTemplatePackages;

		// Token: 0x0401373C RID: 79676
		internal static int __PropertyOffset_83;

		// Token: 0x0401373D RID: 79677
		private TArray<FName> _TempVarOfDensityTemplatePackages;

		// Token: 0x0401373E RID: 79678
		internal static int __PropertyOffset_84;

		// Token: 0x0401373F RID: 79679
		private TArray<FName> _TempVarOfVelocityTemplatePackages;

		// Token: 0x04013740 RID: 79680
		internal static int __PropertyOffset_85;

		// Token: 0x04013741 RID: 79681
		private TArray<FName> _TempVarOfOutputMaterials;

		// Token: 0x04013742 RID: 79682
		internal static int __PropertyOffset_86;

		// Token: 0x04013743 RID: 79683
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<string> _ArrayOfPresetNamesUnsorted;

		// Token: 0x04013744 RID: 79684
		internal static int __PropertyOffset_87;

		// Token: 0x04013745 RID: 79685
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<string> _ArrayOfPresetNamesSorted;

		// Token: 0x04013746 RID: 79686
		internal static int __PropertyOffset_88;

		// Token: 0x04013747 RID: 79687
		internal static int __PropertyOffset_89;

		// Token: 0x04013748 RID: 79688
		internal static int __PropertyOffset_90;

		// Token: 0x04013749 RID: 79689
		internal static int __PropertyOffset_91;

		// Token: 0x0401374A RID: 79690
		private OnDensityMapSave _OnDensityMapSave;

		// Token: 0x0401374B RID: 79691
		internal static int __PropertyOffset_92;

		// Token: 0x0401374C RID: 79692
		internal static int __PropertyOffset_93;

		// Token: 0x0401374D RID: 79693
		internal static int __PropertyOffset_94;

		// Token: 0x0401374E RID: 79694
		internal static int __PropertyOffset_95;

		// Token: 0x0401374F RID: 79695
		private OnPresetDuplicated _OnPresetDuplicated;

		// Token: 0x04013750 RID: 79696
		internal static int __PropertyOffset_96;

		// Token: 0x04013751 RID: 79697
		internal static int __PropertyOffset_97;

		// Token: 0x04013752 RID: 79698
		internal static int __PropertyOffset_98;

		// Token: 0x04013753 RID: 79699
		private static IntPtr __GetSelectedActor_NativeFunctionPtr;

		// Token: 0x04013754 RID: 79700
		private static IntPtr __GetCurrentLevelInfoGUI_NativeFunctionPtr;

		// Token: 0x04013755 RID: 79701
		private static IntPtr __BndEvt__ComboBoxString_89_K2Node_ComponentBoundEvent_2_OnOpeningEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04013756 RID: 79702
		private static IntPtr __BndEvt__ComboBoxString_89_K2Node_ComponentBoundEvent_4_OnSelectionChangedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04013757 RID: 79703
		private static IntPtr __Construct_NativeFunctionPtr;

		// Token: 0x04013758 RID: 79704
		private static IntPtr __PreConstruct_NativeFunctionPtr;

		// Token: 0x04013759 RID: 79705
		private static IntPtr __BndEvt__ComboBox_Presets_K2Node_ComponentBoundEvent_36_OnSelectionChangedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0401375A RID: 79706
		private static IntPtr __BndEvt__Button_SavePreset_K2Node_ComponentBoundEvent_36_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0401375B RID: 79707
		private static IntPtr __BndEvt__Button_DuplicatePreset_K2Node_ComponentBoundEvent_217_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0401375C RID: 79708
		private static IntPtr __OnPresetDuplicationFinished_NativeFunctionPtr;

		// Token: 0x0401375D RID: 79709
		private static IntPtr __BndEvt__CheckBox_21_K2Node_ComponentBoundEvent_219_OnCheckBoxComponentStateChanged__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0401375E RID: 79710
		private static IntPtr __BndEvt__Main3_Button_Minimize_K2Node_ComponentBoundEvent_0_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0401375F RID: 79711
		private static IntPtr __OnInitialized_NativeFunctionPtr;

		// Token: 0x04013760 RID: 79712
		private static IntPtr __Tick_NativeFunctionPtr;

		// Token: 0x04013761 RID: 79713
		private static IntPtr __BndEvt__Button_152_K2Node_ComponentBoundEvent_13_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04013762 RID: 79714
		private static IntPtr __BndEvt__Button_RemovePreset_K2Node_ComponentBoundEvent_218_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04013763 RID: 79715
		private static IntPtr __BndEvt__025_SimareaMoOffset_K2Node_ComponentBoundEvent_1_OnSpinBoxValueCommittedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04013764 RID: 79716
		private static IntPtr __BndEvt__50bSpinBox_BrushRnd_K2Node_ComponentBoundEvent_1_OnSpinBoxValueCommittedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04013765 RID: 79717
		private static IntPtr __BndEvt__Button_ClearBuffers_K2Node_ComponentBoundEvent_8_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04013766 RID: 79718
		private static IntPtr __BndEvt__SpinBox_Divergence_K2Node_ComponentBoundEvent_7_OnSpinBoxValueCommittedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04013767 RID: 79719
		private static IntPtr __BndEvt__SpinBox_Divergence_K2Node_ComponentBoundEvent_6_OnSpinBoxValueChangedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04013768 RID: 79720
		private static IntPtr __BndEvt__SpinBox_Speed_K2Node_ComponentBoundEvent_5_OnSpinBoxValueCommittedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04013769 RID: 79721
		private static IntPtr __BndEvt__SpinBox_Feedback_K2Node_ComponentBoundEvent_1_OnSpinBoxValueCommittedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0401376A RID: 79722
		private static IntPtr __BndEvt__SpinBox_Feedback_K2Node_ComponentBoundEvent_0_OnSpinBoxValueChangedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0401376B RID: 79723
		private static IntPtr __BndEvt__SpinBox_DensityNoiseSize_K2Node_ComponentBoundEvent_7_OnSpinBoxValueCommittedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0401376C RID: 79724
		private static IntPtr __BndEvt__SpinBox_DensityNoiseSize_K2Node_ComponentBoundEvent_6_OnSpinBoxValueChangedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0401376D RID: 79725
		private static IntPtr __BndEvt__SpinBox_DensityNoiseOffset_K2Node_ComponentBoundEvent_5_OnSpinBoxValueCommittedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0401376E RID: 79726
		private static IntPtr __BndEvt__SpinBox_DensityNoiseOffset_K2Node_ComponentBoundEvent_3_OnSpinBoxValueChangedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0401376F RID: 79727
		private static IntPtr __BndEvt__SpinBox_DensityNoiseAmp_K2Node_ComponentBoundEvent_1_OnSpinBoxValueCommittedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04013770 RID: 79728
		private static IntPtr __BndEvt__SpinBox_DensityNoiseAmp_K2Node_ComponentBoundEvent_0_OnSpinBoxValueChangedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04013771 RID: 79729
		private static IntPtr __BndEvt__21cSpinBox_VeloOffset_K2Node_ComponentBoundEvent_1_OnSpinBoxValueChangedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04013772 RID: 79730
		private static IntPtr __BndEvt__21cSpinBox_VeloOffset_K2Node_ComponentBoundEvent_0_OnSpinBoxValueCommittedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04013773 RID: 79731
		private static IntPtr __BndEvt__SpinBox_0_K2Node_ComponentBoundEvent_1_OnSpinBoxValueChangedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04013774 RID: 79732
		private static IntPtr __BndEvt__SpinBox_0_K2Node_ComponentBoundEvent_0_OnSpinBoxValueCommittedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04013775 RID: 79733
		private static IntPtr __BndEvt__Button_1_K2Node_ComponentBoundEvent_0_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04013776 RID: 79734
		private static IntPtr __BndEvt__50SpinBox_BrushNoise_K2Node_ComponentBoundEvent_0_OnSpinBoxValueCommittedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04013777 RID: 79735
		private static IntPtr __BndEvt__SpinBox_Density2_K2Node_ComponentBoundEvent_3_OnSpinBoxValueCommittedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04013778 RID: 79736
		private static IntPtr __BndEvt__SpinBox_Density3_K2Node_ComponentBoundEvent_1_OnSpinBoxValueCommittedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04013779 RID: 79737
		private static IntPtr __BndEvt__SpinBox_Density4_K2Node_ComponentBoundEvent_0_OnSpinBoxValueCommittedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0401377A RID: 79738
		private static IntPtr __BndEvt__45SpinBox_VeloFromSimAreaMotion_K2Node_ComponentBoundEvent_0_OnSpinBoxValueCommittedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0401377B RID: 79739
		private static IntPtr __BndEvt__50ComboBox_NinjaOutputMaterial_K2Node_ComponentBoundEvent_0_OnSelectionChangedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0401377C RID: 79740
		private static IntPtr __BndEvt__24SpinBox_DirNoise_K2Node_ComponentBoundEvent_1_OnSpinBoxValueChangedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0401377D RID: 79741
		private static IntPtr __BndEvt__24SpinBox_DirNoise_K2Node_ComponentBoundEvent_0_OnSpinBoxValueCommittedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0401377E RID: 79742
		private static IntPtr __BndEvt__41SpinBox_BrushPuncture_K2Node_ComponentBoundEvent_0_OnSpinBoxValueCommittedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0401377F RID: 79743
		private static IntPtr __BndEvt__SpinBox_Add01_K2Node_ComponentBoundEvent_1_OnSpinBoxValueChangedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04013780 RID: 79744
		private static IntPtr __BndEvt__SpinBox_Add01_K2Node_ComponentBoundEvent_0_OnSpinBoxValueCommittedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04013781 RID: 79745
		private static IntPtr __BndEvt__AddCheckBox1_K2Node_ComponentBoundEvent_0_OnCheckBoxComponentStateChanged__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04013782 RID: 79746
		private static IntPtr __BndEvt__32SpinBox_DensSharpSize_K2Node_ComponentBoundEvent_41_OnSpinBoxValueChangedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04013783 RID: 79747
		private static IntPtr __BndEvt__31SpinBox_DensSharpen_K2Node_ComponentBoundEvent_40_OnSpinBoxValueChangedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04013784 RID: 79748
		private static IntPtr __BndEvt__29SpinBox_DensHue_K2Node_ComponentBoundEvent_38_OnSpinBoxValueChangedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04013785 RID: 79749
		private static IntPtr __BndEvt__28SpinBox_DensContrast_K2Node_ComponentBoundEvent_35_OnSpinBoxValueChangedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04013786 RID: 79750
		private static IntPtr __BndEvt__27SpinBox_DensShading_K2Node_ComponentBoundEvent_34_OnSpinBoxValueChangedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04013787 RID: 79751
		private static IntPtr __BndEvt__25SpinBox_DensInputWeight_K2Node_ComponentBoundEvent_32_OnSpinBoxValueChangedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04013788 RID: 79752
		private static IntPtr __BndEvt__24SpinBox_VeloNoise_K2Node_ComponentBoundEvent_31_OnSpinBoxValueChangedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04013789 RID: 79753
		private static IntPtr __BndEvt__22SpinBox_VeloAmplify_K2Node_ComponentBoundEvent_15_OnSpinBoxValueChangedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0401378A RID: 79754
		private static IntPtr __BndEvt__21SpinBox_VeloRotate_K2Node_ComponentBoundEvent_13_OnSpinBoxValueChangedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0401378B RID: 79755
		private static IntPtr __BndEvt__20SpinBox_VeloOffsetY_K2Node_ComponentBoundEvent_12_OnSpinBoxValueChangedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0401378C RID: 79756
		private static IntPtr __BndEvt__19SpinBox_VeloOffsetX_K2Node_ComponentBoundEvent_10_OnSpinBoxValueChangedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0401378D RID: 79757
		private static IntPtr __BndEvt__SpinBox_63_K2Node_ComponentBoundEvent_228_OnSpinBoxValueCommittedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0401378E RID: 79758
		private static IntPtr __BndEvt__SpinBox_62_K2Node_ComponentBoundEvent_121_OnSpinBoxValueCommittedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0401378F RID: 79759
		private static IntPtr __BndEvt__MultiLineEditableText_MetaData_K2Node_ComponentBoundEvent_26_OnMultiLineEditableTextCommittedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04013790 RID: 79760
		private static IntPtr __BndEvt__SpinBox_60_K2Node_ComponentBoundEvent_225_OnSpinBoxValueCommittedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04013791 RID: 79761
		private static IntPtr __BndEvt__ComboBox_NinjaTemplate3_K2Node_ComponentBoundEvent_224_OnOpeningEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04013792 RID: 79762
		private static IntPtr __BndEvt__ComboBox_NinjaTemplate3_K2Node_ComponentBoundEvent_223_OnSelectionChangedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04013793 RID: 79763
		private static IntPtr __BndEvt__ComboBox_NinjaTemplate2_K2Node_ComponentBoundEvent_222_OnOpeningEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04013794 RID: 79764
		private static IntPtr __BndEvt__ComboBox_NinjaTemplate2_K2Node_ComponentBoundEvent_120_OnSelectionChangedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04013795 RID: 79765
		private static IntPtr __BndEvt__ComboBox_NinjaTemplate1_K2Node_ComponentBoundEvent_220_OnSelectionChangedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04013796 RID: 79766
		private static IntPtr __BndEvt__SpinBox_26_K2Node_ComponentBoundEvent_128_OnSpinBoxValueCommittedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04013797 RID: 79767
		private static IntPtr __BndEvt__Button_14_K2Node_ComponentBoundEvent_123_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04013798 RID: 79768
		private static IntPtr __BndEvt__SpinBox_22_K2Node_ComponentBoundEvent_102_OnSpinBoxValueCommittedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04013799 RID: 79769
		private static IntPtr __BndEvt__SpinBox_23_K2Node_ComponentBoundEvent_100_OnSpinBoxValueCommittedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0401379A RID: 79770
		private static IntPtr __BndEvt__SpinBox_19_K2Node_ComponentBoundEvent_70_OnSpinBoxValueCommittedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0401379B RID: 79771
		private static IntPtr __BndEvt__SpinBox_18_K2Node_ComponentBoundEvent_94_OnSpinBoxValueCommittedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0401379C RID: 79772
		private static IntPtr __BndEvt__SpinBox_17_K2Node_ComponentBoundEvent_78_OnSpinBoxValueCommittedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0401379D RID: 79773
		private static IntPtr __BndEvt__SpinBox_16_K2Node_ComponentBoundEvent_76_OnSpinBoxValueCommittedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0401379E RID: 79774
		private static IntPtr __BndEvt__SpinBox_15_K2Node_ComponentBoundEvent_74_OnSpinBoxValueCommittedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0401379F RID: 79775
		private static IntPtr __BndEvt__SpinBox_14_K2Node_ComponentBoundEvent_72_OnSpinBoxValueCommittedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x040137A0 RID: 79776
		private static IntPtr __BndEvt__SpinBox_12_K2Node_ComponentBoundEvent_64_OnSpinBoxValueCommittedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x040137A1 RID: 79777
		private static IntPtr __BndEvt__SpinBox_11_K2Node_ComponentBoundEvent_60_OnSpinBoxValueCommittedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x040137A2 RID: 79778
		private static IntPtr __BndEvt__SpinBox_10_K2Node_ComponentBoundEvent_55_OnSpinBoxValueCommittedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x040137A3 RID: 79779
		private static IntPtr __BndEvt__Main9_Button_PreferredPreset_K2Node_ComponentBoundEvent_0_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x040137A4 RID: 79780
		private static IntPtr __ExecuteUbergraph_NinjaLiveGUI_NativeFunctionPtr;

		// Token: 0x02009F49 RID: 40777
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 64)]
		protected ref struct __GetSelectedActor_FunctionParams
		{
			// Token: 0x04032ABD RID: 207549
			[FieldOffset(0)]
			public int SelectedActorIndex;

			// Token: 0x04032ABE RID: 207550
			[FieldOffset(8)]
			public IntPtr NinjaLiveActor;
		}

		// Token: 0x02009F4A RID: 40778
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 240)]
		protected ref struct __GetCurrentLevelInfoGUI_FunctionParams
		{
			// Token: 0x04032ABF RID: 207551
			[FieldOffset(0)]
			public FName LevelName;

			// Token: 0x04032AC0 RID: 207552
			[FieldOffset(12)]
			public FName LevelPath;
		}

		// Token: 0x02009F4B RID: 40779
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __BndEvt__ComboBoxString_89_K2Node_ComponentBoundEvent_4_OnSelectionChangedEvent__DelegateSignature_FunctionParams
		{
			// Token: 0x04032AC1 RID: 207553
			[FieldOffset(0)]
			public FString SelectedItem;

			// Token: 0x04032AC2 RID: 207554
			[FieldOffset(16)]
			public TEnumAsByte<ESelectInfo> SelectionType;
		}

		// Token: 0x02009F4C RID: 40780
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __PreConstruct_FunctionParams
		{
			// Token: 0x04032AC3 RID: 207555
			[FieldOffset(0)]
			public bool IsDesignTime;
		}

		// Token: 0x02009F4D RID: 40781
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __BndEvt__ComboBox_Presets_K2Node_ComponentBoundEvent_36_OnSelectionChangedEvent__DelegateSignature_FunctionParams
		{
			// Token: 0x04032AC4 RID: 207556
			[FieldOffset(0)]
			public FString SelectedItem;

			// Token: 0x04032AC5 RID: 207557
			[FieldOffset(16)]
			public TEnumAsByte<ESelectInfo> SelectionType;
		}

		// Token: 0x02009F4E RID: 40782
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __OnPresetDuplicationFinished_FunctionParams
		{
			// Token: 0x04032AC6 RID: 207558
			[FieldOffset(0)]
			public IntPtr DuplicatedPreset;
		}

		// Token: 0x02009F4F RID: 40783
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected ref struct __BndEvt__CheckBox_21_K2Node_ComponentBoundEvent_219_OnCheckBoxComponentStateChanged__DelegateSignature_FunctionParams
		{
			// Token: 0x04032AC7 RID: 207559
			[FieldOffset(0)]
			public bool bIsChecked;
		}

		// Token: 0x02009F50 RID: 40784
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 60)]
		protected new ref struct __Tick_FunctionParams
		{
			// Token: 0x04032AC8 RID: 207560
			[FieldOffset(0)]
			public byte MyGeometry;

			// Token: 0x04032AC9 RID: 207561
			[FieldOffset(56)]
			public float InDeltaTime;
		}

		// Token: 0x02009F51 RID: 40785
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __BndEvt__025_SimareaMoOffset_K2Node_ComponentBoundEvent_1_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams
		{
			// Token: 0x04032ACA RID: 207562
			[FieldOffset(0)]
			public float InValue;

			// Token: 0x04032ACB RID: 207563
			[FieldOffset(4)]
			public TEnumAsByte<ETextCommit> CommitMethod;
		}

		// Token: 0x02009F52 RID: 40786
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __BndEvt__50bSpinBox_BrushRnd_K2Node_ComponentBoundEvent_1_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams
		{
			// Token: 0x04032ACC RID: 207564
			[FieldOffset(0)]
			public float InValue;

			// Token: 0x04032ACD RID: 207565
			[FieldOffset(4)]
			public TEnumAsByte<ETextCommit> CommitMethod;
		}

		// Token: 0x02009F53 RID: 40787
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __BndEvt__SpinBox_Divergence_K2Node_ComponentBoundEvent_7_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams
		{
			// Token: 0x04032ACE RID: 207566
			[FieldOffset(0)]
			public float InValue;

			// Token: 0x04032ACF RID: 207567
			[FieldOffset(4)]
			public TEnumAsByte<ETextCommit> CommitMethod;
		}

		// Token: 0x02009F54 RID: 40788
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __BndEvt__SpinBox_Divergence_K2Node_ComponentBoundEvent_6_OnSpinBoxValueChangedEvent__DelegateSignature_FunctionParams
		{
			// Token: 0x04032AD0 RID: 207568
			[FieldOffset(0)]
			public float InValue;
		}

		// Token: 0x02009F55 RID: 40789
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __BndEvt__SpinBox_Speed_K2Node_ComponentBoundEvent_5_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams
		{
			// Token: 0x04032AD1 RID: 207569
			[FieldOffset(0)]
			public float InValue;

			// Token: 0x04032AD2 RID: 207570
			[FieldOffset(4)]
			public TEnumAsByte<ETextCommit> CommitMethod;
		}

		// Token: 0x02009F56 RID: 40790
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __BndEvt__SpinBox_Feedback_K2Node_ComponentBoundEvent_1_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams
		{
			// Token: 0x04032AD3 RID: 207571
			[FieldOffset(0)]
			public float InValue;

			// Token: 0x04032AD4 RID: 207572
			[FieldOffset(4)]
			public TEnumAsByte<ETextCommit> CommitMethod;
		}

		// Token: 0x02009F57 RID: 40791
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __BndEvt__SpinBox_Feedback_K2Node_ComponentBoundEvent_0_OnSpinBoxValueChangedEvent__DelegateSignature_FunctionParams
		{
			// Token: 0x04032AD5 RID: 207573
			[FieldOffset(0)]
			public float InValue;
		}

		// Token: 0x02009F58 RID: 40792
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __BndEvt__SpinBox_DensityNoiseSize_K2Node_ComponentBoundEvent_7_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams
		{
			// Token: 0x04032AD6 RID: 207574
			[FieldOffset(0)]
			public float InValue;

			// Token: 0x04032AD7 RID: 207575
			[FieldOffset(4)]
			public TEnumAsByte<ETextCommit> CommitMethod;
		}

		// Token: 0x02009F59 RID: 40793
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __BndEvt__SpinBox_DensityNoiseSize_K2Node_ComponentBoundEvent_6_OnSpinBoxValueChangedEvent__DelegateSignature_FunctionParams
		{
			// Token: 0x04032AD8 RID: 207576
			[FieldOffset(0)]
			public float InValue;
		}

		// Token: 0x02009F5A RID: 40794
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __BndEvt__SpinBox_DensityNoiseOffset_K2Node_ComponentBoundEvent_5_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams
		{
			// Token: 0x04032AD9 RID: 207577
			[FieldOffset(0)]
			public float InValue;

			// Token: 0x04032ADA RID: 207578
			[FieldOffset(4)]
			public TEnumAsByte<ETextCommit> CommitMethod;
		}

		// Token: 0x02009F5B RID: 40795
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __BndEvt__SpinBox_DensityNoiseOffset_K2Node_ComponentBoundEvent_3_OnSpinBoxValueChangedEvent__DelegateSignature_FunctionParams
		{
			// Token: 0x04032ADB RID: 207579
			[FieldOffset(0)]
			public float InValue;
		}

		// Token: 0x02009F5C RID: 40796
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __BndEvt__SpinBox_DensityNoiseAmp_K2Node_ComponentBoundEvent_1_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams
		{
			// Token: 0x04032ADC RID: 207580
			[FieldOffset(0)]
			public float InValue;

			// Token: 0x04032ADD RID: 207581
			[FieldOffset(4)]
			public TEnumAsByte<ETextCommit> CommitMethod;
		}

		// Token: 0x02009F5D RID: 40797
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __BndEvt__SpinBox_DensityNoiseAmp_K2Node_ComponentBoundEvent_0_OnSpinBoxValueChangedEvent__DelegateSignature_FunctionParams
		{
			// Token: 0x04032ADE RID: 207582
			[FieldOffset(0)]
			public float InValue;
		}

		// Token: 0x02009F5E RID: 40798
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __BndEvt__21cSpinBox_VeloOffset_K2Node_ComponentBoundEvent_1_OnSpinBoxValueChangedEvent__DelegateSignature_FunctionParams
		{
			// Token: 0x04032ADF RID: 207583
			[FieldOffset(0)]
			public float InValue;
		}

		// Token: 0x02009F5F RID: 40799
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __BndEvt__21cSpinBox_VeloOffset_K2Node_ComponentBoundEvent_0_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams
		{
			// Token: 0x04032AE0 RID: 207584
			[FieldOffset(0)]
			public float InValue;

			// Token: 0x04032AE1 RID: 207585
			[FieldOffset(4)]
			public TEnumAsByte<ETextCommit> CommitMethod;
		}

		// Token: 0x02009F60 RID: 40800
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __BndEvt__SpinBox_0_K2Node_ComponentBoundEvent_1_OnSpinBoxValueChangedEvent__DelegateSignature_FunctionParams
		{
			// Token: 0x04032AE2 RID: 207586
			[FieldOffset(0)]
			public float InValue;
		}

		// Token: 0x02009F61 RID: 40801
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __BndEvt__SpinBox_0_K2Node_ComponentBoundEvent_0_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams
		{
			// Token: 0x04032AE3 RID: 207587
			[FieldOffset(0)]
			public float InValue;

			// Token: 0x04032AE4 RID: 207588
			[FieldOffset(4)]
			public TEnumAsByte<ETextCommit> CommitMethod;
		}

		// Token: 0x02009F62 RID: 40802
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __BndEvt__50SpinBox_BrushNoise_K2Node_ComponentBoundEvent_0_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams
		{
			// Token: 0x04032AE5 RID: 207589
			[FieldOffset(0)]
			public float InValue;

			// Token: 0x04032AE6 RID: 207590
			[FieldOffset(4)]
			public TEnumAsByte<ETextCommit> CommitMethod;
		}

		// Token: 0x02009F63 RID: 40803
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __BndEvt__SpinBox_Density2_K2Node_ComponentBoundEvent_3_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams
		{
			// Token: 0x04032AE7 RID: 207591
			[FieldOffset(0)]
			public float InValue;

			// Token: 0x04032AE8 RID: 207592
			[FieldOffset(4)]
			public TEnumAsByte<ETextCommit> CommitMethod;
		}

		// Token: 0x02009F64 RID: 40804
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __BndEvt__SpinBox_Density3_K2Node_ComponentBoundEvent_1_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams
		{
			// Token: 0x04032AE9 RID: 207593
			[FieldOffset(0)]
			public float InValue;

			// Token: 0x04032AEA RID: 207594
			[FieldOffset(4)]
			public TEnumAsByte<ETextCommit> CommitMethod;
		}

		// Token: 0x02009F65 RID: 40805
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __BndEvt__SpinBox_Density4_K2Node_ComponentBoundEvent_0_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams
		{
			// Token: 0x04032AEB RID: 207595
			[FieldOffset(0)]
			public float InValue;

			// Token: 0x04032AEC RID: 207596
			[FieldOffset(4)]
			public TEnumAsByte<ETextCommit> CommitMethod;
		}

		// Token: 0x02009F66 RID: 40806
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __BndEvt__45SpinBox_VeloFromSimAreaMotion_K2Node_ComponentBoundEvent_0_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams
		{
			// Token: 0x04032AED RID: 207597
			[FieldOffset(0)]
			public float InValue;

			// Token: 0x04032AEE RID: 207598
			[FieldOffset(4)]
			public TEnumAsByte<ETextCommit> CommitMethod;
		}

		// Token: 0x02009F67 RID: 40807
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __BndEvt__50ComboBox_NinjaOutputMaterial_K2Node_ComponentBoundEvent_0_OnSelectionChangedEvent__DelegateSignature_FunctionParams
		{
			// Token: 0x04032AEF RID: 207599
			[FieldOffset(0)]
			public FString SelectedItem;

			// Token: 0x04032AF0 RID: 207600
			[FieldOffset(16)]
			public TEnumAsByte<ESelectInfo> SelectionType;
		}

		// Token: 0x02009F68 RID: 40808
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __BndEvt__24SpinBox_DirNoise_K2Node_ComponentBoundEvent_1_OnSpinBoxValueChangedEvent__DelegateSignature_FunctionParams
		{
			// Token: 0x04032AF1 RID: 207601
			[FieldOffset(0)]
			public float InValue;
		}

		// Token: 0x02009F69 RID: 40809
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __BndEvt__24SpinBox_DirNoise_K2Node_ComponentBoundEvent_0_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams
		{
			// Token: 0x04032AF2 RID: 207602
			[FieldOffset(0)]
			public float InValue;

			// Token: 0x04032AF3 RID: 207603
			[FieldOffset(4)]
			public TEnumAsByte<ETextCommit> CommitMethod;
		}

		// Token: 0x02009F6A RID: 40810
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __BndEvt__41SpinBox_BrushPuncture_K2Node_ComponentBoundEvent_0_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams
		{
			// Token: 0x04032AF4 RID: 207604
			[FieldOffset(0)]
			public float InValue;

			// Token: 0x04032AF5 RID: 207605
			[FieldOffset(4)]
			public TEnumAsByte<ETextCommit> CommitMethod;
		}

		// Token: 0x02009F6B RID: 40811
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __BndEvt__SpinBox_Add01_K2Node_ComponentBoundEvent_1_OnSpinBoxValueChangedEvent__DelegateSignature_FunctionParams
		{
			// Token: 0x04032AF6 RID: 207606
			[FieldOffset(0)]
			public float InValue;
		}

		// Token: 0x02009F6C RID: 40812
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __BndEvt__SpinBox_Add01_K2Node_ComponentBoundEvent_0_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams
		{
			// Token: 0x04032AF7 RID: 207607
			[FieldOffset(0)]
			public float InValue;

			// Token: 0x04032AF8 RID: 207608
			[FieldOffset(4)]
			public TEnumAsByte<ETextCommit> CommitMethod;
		}

		// Token: 0x02009F6D RID: 40813
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected ref struct __BndEvt__AddCheckBox1_K2Node_ComponentBoundEvent_0_OnCheckBoxComponentStateChanged__DelegateSignature_FunctionParams
		{
			// Token: 0x04032AF9 RID: 207609
			[FieldOffset(0)]
			public bool bIsChecked;
		}

		// Token: 0x02009F6E RID: 40814
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __BndEvt__32SpinBox_DensSharpSize_K2Node_ComponentBoundEvent_41_OnSpinBoxValueChangedEvent__DelegateSignature_FunctionParams
		{
			// Token: 0x04032AFA RID: 207610
			[FieldOffset(0)]
			public float InValue;
		}

		// Token: 0x02009F6F RID: 40815
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __BndEvt__31SpinBox_DensSharpen_K2Node_ComponentBoundEvent_40_OnSpinBoxValueChangedEvent__DelegateSignature_FunctionParams
		{
			// Token: 0x04032AFB RID: 207611
			[FieldOffset(0)]
			public float InValue;
		}

		// Token: 0x02009F70 RID: 40816
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __BndEvt__29SpinBox_DensHue_K2Node_ComponentBoundEvent_38_OnSpinBoxValueChangedEvent__DelegateSignature_FunctionParams
		{
			// Token: 0x04032AFC RID: 207612
			[FieldOffset(0)]
			public float InValue;
		}

		// Token: 0x02009F71 RID: 40817
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __BndEvt__28SpinBox_DensContrast_K2Node_ComponentBoundEvent_35_OnSpinBoxValueChangedEvent__DelegateSignature_FunctionParams
		{
			// Token: 0x04032AFD RID: 207613
			[FieldOffset(0)]
			public float InValue;
		}

		// Token: 0x02009F72 RID: 40818
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __BndEvt__27SpinBox_DensShading_K2Node_ComponentBoundEvent_34_OnSpinBoxValueChangedEvent__DelegateSignature_FunctionParams
		{
			// Token: 0x04032AFE RID: 207614
			[FieldOffset(0)]
			public float InValue;
		}

		// Token: 0x02009F73 RID: 40819
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __BndEvt__25SpinBox_DensInputWeight_K2Node_ComponentBoundEvent_32_OnSpinBoxValueChangedEvent__DelegateSignature_FunctionParams
		{
			// Token: 0x04032AFF RID: 207615
			[FieldOffset(0)]
			public float InValue;
		}

		// Token: 0x02009F74 RID: 40820
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __BndEvt__24SpinBox_VeloNoise_K2Node_ComponentBoundEvent_31_OnSpinBoxValueChangedEvent__DelegateSignature_FunctionParams
		{
			// Token: 0x04032B00 RID: 207616
			[FieldOffset(0)]
			public float InValue;
		}

		// Token: 0x02009F75 RID: 40821
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __BndEvt__22SpinBox_VeloAmplify_K2Node_ComponentBoundEvent_15_OnSpinBoxValueChangedEvent__DelegateSignature_FunctionParams
		{
			// Token: 0x04032B01 RID: 207617
			[FieldOffset(0)]
			public float InValue;
		}

		// Token: 0x02009F76 RID: 40822
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __BndEvt__21SpinBox_VeloRotate_K2Node_ComponentBoundEvent_13_OnSpinBoxValueChangedEvent__DelegateSignature_FunctionParams
		{
			// Token: 0x04032B02 RID: 207618
			[FieldOffset(0)]
			public float InValue;
		}

		// Token: 0x02009F77 RID: 40823
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __BndEvt__20SpinBox_VeloOffsetY_K2Node_ComponentBoundEvent_12_OnSpinBoxValueChangedEvent__DelegateSignature_FunctionParams
		{
			// Token: 0x04032B03 RID: 207619
			[FieldOffset(0)]
			public float InValue;
		}

		// Token: 0x02009F78 RID: 40824
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __BndEvt__19SpinBox_VeloOffsetX_K2Node_ComponentBoundEvent_10_OnSpinBoxValueChangedEvent__DelegateSignature_FunctionParams
		{
			// Token: 0x04032B04 RID: 207620
			[FieldOffset(0)]
			public float InValue;
		}

		// Token: 0x02009F79 RID: 40825
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __BndEvt__SpinBox_63_K2Node_ComponentBoundEvent_228_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams
		{
			// Token: 0x04032B05 RID: 207621
			[FieldOffset(0)]
			public float InValue;

			// Token: 0x04032B06 RID: 207622
			[FieldOffset(4)]
			public TEnumAsByte<ETextCommit> CommitMethod;
		}

		// Token: 0x02009F7A RID: 40826
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __BndEvt__SpinBox_62_K2Node_ComponentBoundEvent_121_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams
		{
			// Token: 0x04032B07 RID: 207623
			[FieldOffset(0)]
			public float InValue;

			// Token: 0x04032B08 RID: 207624
			[FieldOffset(4)]
			public TEnumAsByte<ETextCommit> CommitMethod;
		}

		// Token: 0x02009F7B RID: 40827
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __BndEvt__MultiLineEditableText_MetaData_K2Node_ComponentBoundEvent_26_OnMultiLineEditableTextCommittedEvent__DelegateSignature_FunctionParams
		{
			// Token: 0x04032B09 RID: 207625
			[FieldOffset(0)]
			public byte Text;

			// Token: 0x04032B0A RID: 207626
			[FieldOffset(24)]
			public TEnumAsByte<ETextCommit> CommitMethod;
		}

		// Token: 0x02009F7C RID: 40828
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __BndEvt__SpinBox_60_K2Node_ComponentBoundEvent_225_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams
		{
			// Token: 0x04032B0B RID: 207627
			[FieldOffset(0)]
			public float InValue;

			// Token: 0x04032B0C RID: 207628
			[FieldOffset(4)]
			public TEnumAsByte<ETextCommit> CommitMethod;
		}

		// Token: 0x02009F7D RID: 40829
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __BndEvt__ComboBox_NinjaTemplate3_K2Node_ComponentBoundEvent_223_OnSelectionChangedEvent__DelegateSignature_FunctionParams
		{
			// Token: 0x04032B0D RID: 207629
			[FieldOffset(0)]
			public FString SelectedItem;

			// Token: 0x04032B0E RID: 207630
			[FieldOffset(16)]
			public TEnumAsByte<ESelectInfo> SelectionType;
		}

		// Token: 0x02009F7E RID: 40830
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __BndEvt__ComboBox_NinjaTemplate2_K2Node_ComponentBoundEvent_120_OnSelectionChangedEvent__DelegateSignature_FunctionParams
		{
			// Token: 0x04032B0F RID: 207631
			[FieldOffset(0)]
			public FString SelectedItem;

			// Token: 0x04032B10 RID: 207632
			[FieldOffset(16)]
			public TEnumAsByte<ESelectInfo> SelectionType;
		}

		// Token: 0x02009F7F RID: 40831
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __BndEvt__ComboBox_NinjaTemplate1_K2Node_ComponentBoundEvent_220_OnSelectionChangedEvent__DelegateSignature_FunctionParams
		{
			// Token: 0x04032B11 RID: 207633
			[FieldOffset(0)]
			public FString SelectedItem;

			// Token: 0x04032B12 RID: 207634
			[FieldOffset(16)]
			public TEnumAsByte<ESelectInfo> SelectionType;
		}

		// Token: 0x02009F80 RID: 40832
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __BndEvt__SpinBox_26_K2Node_ComponentBoundEvent_128_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams
		{
			// Token: 0x04032B13 RID: 207635
			[FieldOffset(0)]
			public float InValue;

			// Token: 0x04032B14 RID: 207636
			[FieldOffset(4)]
			public TEnumAsByte<ETextCommit> CommitMethod;
		}

		// Token: 0x02009F81 RID: 40833
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __BndEvt__SpinBox_22_K2Node_ComponentBoundEvent_102_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams
		{
			// Token: 0x04032B15 RID: 207637
			[FieldOffset(0)]
			public float InValue;

			// Token: 0x04032B16 RID: 207638
			[FieldOffset(4)]
			public TEnumAsByte<ETextCommit> CommitMethod;
		}

		// Token: 0x02009F82 RID: 40834
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __BndEvt__SpinBox_23_K2Node_ComponentBoundEvent_100_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams
		{
			// Token: 0x04032B17 RID: 207639
			[FieldOffset(0)]
			public float InValue;

			// Token: 0x04032B18 RID: 207640
			[FieldOffset(4)]
			public TEnumAsByte<ETextCommit> CommitMethod;
		}

		// Token: 0x02009F83 RID: 40835
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __BndEvt__SpinBox_19_K2Node_ComponentBoundEvent_70_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams
		{
			// Token: 0x04032B19 RID: 207641
			[FieldOffset(0)]
			public float InValue;

			// Token: 0x04032B1A RID: 207642
			[FieldOffset(4)]
			public TEnumAsByte<ETextCommit> CommitMethod;
		}

		// Token: 0x02009F84 RID: 40836
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __BndEvt__SpinBox_18_K2Node_ComponentBoundEvent_94_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams
		{
			// Token: 0x04032B1B RID: 207643
			[FieldOffset(0)]
			public float InValue;

			// Token: 0x04032B1C RID: 207644
			[FieldOffset(4)]
			public TEnumAsByte<ETextCommit> CommitMethod;
		}

		// Token: 0x02009F85 RID: 40837
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __BndEvt__SpinBox_17_K2Node_ComponentBoundEvent_78_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams
		{
			// Token: 0x04032B1D RID: 207645
			[FieldOffset(0)]
			public float InValue;

			// Token: 0x04032B1E RID: 207646
			[FieldOffset(4)]
			public TEnumAsByte<ETextCommit> CommitMethod;
		}

		// Token: 0x02009F86 RID: 40838
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __BndEvt__SpinBox_16_K2Node_ComponentBoundEvent_76_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams
		{
			// Token: 0x04032B1F RID: 207647
			[FieldOffset(0)]
			public float InValue;

			// Token: 0x04032B20 RID: 207648
			[FieldOffset(4)]
			public TEnumAsByte<ETextCommit> CommitMethod;
		}

		// Token: 0x02009F87 RID: 40839
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __BndEvt__SpinBox_15_K2Node_ComponentBoundEvent_74_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams
		{
			// Token: 0x04032B21 RID: 207649
			[FieldOffset(0)]
			public float InValue;

			// Token: 0x04032B22 RID: 207650
			[FieldOffset(4)]
			public TEnumAsByte<ETextCommit> CommitMethod;
		}

		// Token: 0x02009F88 RID: 40840
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __BndEvt__SpinBox_14_K2Node_ComponentBoundEvent_72_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams
		{
			// Token: 0x04032B23 RID: 207651
			[FieldOffset(0)]
			public float InValue;

			// Token: 0x04032B24 RID: 207652
			[FieldOffset(4)]
			public TEnumAsByte<ETextCommit> CommitMethod;
		}

		// Token: 0x02009F89 RID: 40841
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __BndEvt__SpinBox_12_K2Node_ComponentBoundEvent_64_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams
		{
			// Token: 0x04032B25 RID: 207653
			[FieldOffset(0)]
			public float InValue;

			// Token: 0x04032B26 RID: 207654
			[FieldOffset(4)]
			public TEnumAsByte<ETextCommit> CommitMethod;
		}

		// Token: 0x02009F8A RID: 40842
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __BndEvt__SpinBox_11_K2Node_ComponentBoundEvent_60_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams
		{
			// Token: 0x04032B27 RID: 207655
			[FieldOffset(0)]
			public float InValue;

			// Token: 0x04032B28 RID: 207656
			[FieldOffset(4)]
			public TEnumAsByte<ETextCommit> CommitMethod;
		}

		// Token: 0x02009F8B RID: 40843
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __BndEvt__SpinBox_10_K2Node_ComponentBoundEvent_55_OnSpinBoxValueCommittedEvent__DelegateSignature_FunctionParams
		{
			// Token: 0x04032B29 RID: 207657
			[FieldOffset(0)]
			public float InValue;

			// Token: 0x04032B2A RID: 207658
			[FieldOffset(4)]
			public TEnumAsByte<ETextCommit> CommitMethod;
		}

		// Token: 0x02009F8C RID: 40844
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 10264)]
		protected ref struct __ExecuteUbergraph_NinjaLiveGUI_FunctionParams
		{
			// Token: 0x04032B2B RID: 207659
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
