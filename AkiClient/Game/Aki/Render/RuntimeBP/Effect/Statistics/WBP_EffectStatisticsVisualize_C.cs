using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialContainer;
using AkiClient.Game.Aki.UI.Module.Common.View.Widget;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Effect.Statistics
{
	// Token: 0x02003D2B RID: 15659
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Effect/Statistics/WBP_EffectStatisticsVisualize.WBP_EffectStatisticsVisualize_C")]
	[UnrealStructLayout(1720, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1720)]
	public class WBP_EffectStatisticsVisualize_C : UUserWidget, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06025E1E RID: 155166 RVA: 0x009C79EA File Offset: 0x009C5BEA
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (WBP_EffectStatisticsVisualize_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Effect/Statistics/WBP_EffectStatisticsVisualize.WBP_EffectStatisticsVisualize_C");
			}
			return WBP_EffectStatisticsVisualize_C._ClassPtr;
		}

		// Token: 0x06025E1F RID: 155167 RVA: 0x009C7A10 File Offset: 0x009C5C10
		public WBP_EffectStatisticsVisualize_C() : this(BuiltinUtils.AllocNativeUObject(WBP_EffectStatisticsVisualize_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06025E20 RID: 155168 RVA: 0x009C7A38 File Offset: 0x009C5C38
		[NullableContext(1)]
		public WBP_EffectStatisticsVisualize_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(WBP_EffectStatisticsVisualize_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700543E RID: 21566
		// (get) Token: 0x06025E21 RID: 155169 RVA: 0x009C7A6B File Offset: 0x009C5C6B
		// (set) Token: 0x06025E22 RID: 155170 RVA: 0x009C7A7F File Offset: 0x009C5C7F
		public unsafe KuroImage_C BG
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<KuroImage_C>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_EffectStatisticsVisualize_C.__PropertyOffset_0);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_EffectStatisticsVisualize_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x1700543F RID: 21567
		// (get) Token: 0x06025E23 RID: 155171 RVA: 0x009C7A94 File Offset: 0x009C5C94
		// (set) Token: 0x06025E24 RID: 155172 RVA: 0x009C7AA8 File Offset: 0x009C5CA8
		public unsafe UButton Button
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UButton>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_EffectStatisticsVisualize_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_EffectStatisticsVisualize_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17005440 RID: 21568
		// (get) Token: 0x06025E25 RID: 155173 RVA: 0x009C7ABD File Offset: 0x009C5CBD
		// (set) Token: 0x06025E26 RID: 155174 RVA: 0x009C7AD1 File Offset: 0x009C5CD1
		public unsafe UButton Button_0
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UButton>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_EffectStatisticsVisualize_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_EffectStatisticsVisualize_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17005441 RID: 21569
		// (get) Token: 0x06025E27 RID: 155175 RVA: 0x009C7AE6 File Offset: 0x009C5CE6
		// (set) Token: 0x06025E28 RID: 155176 RVA: 0x009C7AFA File Offset: 0x009C5CFA
		public unsafe UButton Button_1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UButton>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_EffectStatisticsVisualize_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_EffectStatisticsVisualize_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17005442 RID: 21570
		// (get) Token: 0x06025E29 RID: 155177 RVA: 0x009C7B0F File Offset: 0x009C5D0F
		// (set) Token: 0x06025E2A RID: 155178 RVA: 0x009C7B23 File Offset: 0x009C5D23
		public unsafe UButton Button_4
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UButton>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_EffectStatisticsVisualize_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_EffectStatisticsVisualize_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17005443 RID: 21571
		// (get) Token: 0x06025E2B RID: 155179 RVA: 0x009C7B38 File Offset: 0x009C5D38
		// (set) Token: 0x06025E2C RID: 155180 RVA: 0x009C7B4C File Offset: 0x009C5D4C
		public unsafe UButton Button_5
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UButton>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_EffectStatisticsVisualize_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_EffectStatisticsVisualize_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17005444 RID: 21572
		// (get) Token: 0x06025E2D RID: 155181 RVA: 0x009C7B61 File Offset: 0x009C5D61
		// (set) Token: 0x06025E2E RID: 155182 RVA: 0x009C7B75 File Offset: 0x009C5D75
		public unsafe UButton Button_6
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UButton>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_EffectStatisticsVisualize_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_EffectStatisticsVisualize_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x17005445 RID: 21573
		// (get) Token: 0x06025E2F RID: 155183 RVA: 0x009C7B8A File Offset: 0x009C5D8A
		// (set) Token: 0x06025E30 RID: 155184 RVA: 0x009C7B9E File Offset: 0x009C5D9E
		public unsafe UButton Button_7
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UButton>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_EffectStatisticsVisualize_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_EffectStatisticsVisualize_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x17005446 RID: 21574
		// (get) Token: 0x06025E31 RID: 155185 RVA: 0x009C7BB3 File Offset: 0x009C5DB3
		// (set) Token: 0x06025E32 RID: 155186 RVA: 0x009C7BC7 File Offset: 0x009C5DC7
		public unsafe UButton Button_46
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UButton>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_EffectStatisticsVisualize_C.__PropertyOffset_8);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_EffectStatisticsVisualize_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x17005447 RID: 21575
		// (get) Token: 0x06025E33 RID: 155187 RVA: 0x009C7BDC File Offset: 0x009C5DDC
		// (set) Token: 0x06025E34 RID: 155188 RVA: 0x009C7BF0 File Offset: 0x009C5DF0
		public unsafe UComboBoxString ComboBoxString
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UComboBoxString>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_EffectStatisticsVisualize_C.__PropertyOffset_9);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_EffectStatisticsVisualize_C.__PropertyOffset_9, value);
			}
		}

		// Token: 0x17005448 RID: 21576
		// (get) Token: 0x06025E35 RID: 155189 RVA: 0x009C7C05 File Offset: 0x009C5E05
		// (set) Token: 0x06025E36 RID: 155190 RVA: 0x009C7C19 File Offset: 0x009C5E19
		public unsafe UComboBoxString ComboBoxString_1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UComboBoxString>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_EffectStatisticsVisualize_C.__PropertyOffset_10);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_EffectStatisticsVisualize_C.__PropertyOffset_10, value);
			}
		}

		// Token: 0x17005449 RID: 21577
		// (get) Token: 0x06025E37 RID: 155191 RVA: 0x009C7C2E File Offset: 0x009C5E2E
		// (set) Token: 0x06025E38 RID: 155192 RVA: 0x009C7C42 File Offset: 0x009C5E42
		public unsafe UComboBoxString ComboBoxString_2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UComboBoxString>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_EffectStatisticsVisualize_C.__PropertyOffset_11);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_EffectStatisticsVisualize_C.__PropertyOffset_11, value);
			}
		}

		// Token: 0x1700544A RID: 21578
		// (get) Token: 0x06025E39 RID: 155193 RVA: 0x009C7C57 File Offset: 0x009C5E57
		// (set) Token: 0x06025E3A RID: 155194 RVA: 0x009C7C6B File Offset: 0x009C5E6B
		public unsafe UListView List
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UListView>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_EffectStatisticsVisualize_C.__PropertyOffset_12);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_EffectStatisticsVisualize_C.__PropertyOffset_12, value);
			}
		}

		// Token: 0x1700544B RID: 21579
		// (get) Token: 0x06025E3B RID: 155195 RVA: 0x009C7C80 File Offset: 0x009C5E80
		// (set) Token: 0x06025E3C RID: 155196 RVA: 0x009C7C94 File Offset: 0x009C5E94
		public unsafe UTextBlock TextBlock_2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextBlock>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_EffectStatisticsVisualize_C.__PropertyOffset_13);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_EffectStatisticsVisualize_C.__PropertyOffset_13, value);
			}
		}

		// Token: 0x1700544C RID: 21580
		// (get) Token: 0x06025E3D RID: 155197 RVA: 0x009C7CA9 File Offset: 0x009C5EA9
		// (set) Token: 0x06025E3E RID: 155198 RVA: 0x009C7CBD File Offset: 0x009C5EBD
		public unsafe UTextBlock TextBlock_6
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextBlock>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_EffectStatisticsVisualize_C.__PropertyOffset_14);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_EffectStatisticsVisualize_C.__PropertyOffset_14, value);
			}
		}

		// Token: 0x1700544D RID: 21581
		// (get) Token: 0x06025E3F RID: 155199 RVA: 0x009C7CD2 File Offset: 0x009C5ED2
		// (set) Token: 0x06025E40 RID: 155200 RVA: 0x009C7CE6 File Offset: 0x009C5EE6
		public unsafe UTextBlock TextBlock_7
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextBlock>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_EffectStatisticsVisualize_C.__PropertyOffset_15);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_EffectStatisticsVisualize_C.__PropertyOffset_15, value);
			}
		}

		// Token: 0x1700544E RID: 21582
		// (get) Token: 0x06025E41 RID: 155201 RVA: 0x009C7CFB File Offset: 0x009C5EFB
		// (set) Token: 0x06025E42 RID: 155202 RVA: 0x009C7D0F File Offset: 0x009C5F0F
		public unsafe UTextBlock TextBlock_8
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextBlock>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_EffectStatisticsVisualize_C.__PropertyOffset_16);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_EffectStatisticsVisualize_C.__PropertyOffset_16, value);
			}
		}

		// Token: 0x1700544F RID: 21583
		// (get) Token: 0x06025E43 RID: 155203 RVA: 0x009C7D24 File Offset: 0x009C5F24
		// (set) Token: 0x06025E44 RID: 155204 RVA: 0x009C7D38 File Offset: 0x009C5F38
		public unsafe UTextBlock TextBlock_15
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextBlock>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_EffectStatisticsVisualize_C.__PropertyOffset_17);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_EffectStatisticsVisualize_C.__PropertyOffset_17, value);
			}
		}

		// Token: 0x17005450 RID: 21584
		// (get) Token: 0x06025E45 RID: 155205 RVA: 0x009C7D4D File Offset: 0x009C5F4D
		// (set) Token: 0x06025E46 RID: 155206 RVA: 0x009C7D61 File Offset: 0x009C5F61
		public unsafe KuroImage_C TitleBG
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<KuroImage_C>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_EffectStatisticsVisualize_C.__PropertyOffset_18);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_EffectStatisticsVisualize_C.__PropertyOffset_18, value);
			}
		}

		// Token: 0x17005451 RID: 21585
		// (get) Token: 0x06025E47 RID: 155207 RVA: 0x009C7D76 File Offset: 0x009C5F76
		// (set) Token: 0x06025E48 RID: 155208 RVA: 0x009C7D8A File Offset: 0x009C5F8A
		public unsafe UWidgetSwitcher WidgetSwitcher_0
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UWidgetSwitcher>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_EffectStatisticsVisualize_C.__PropertyOffset_19);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_EffectStatisticsVisualize_C.__PropertyOffset_19, value);
			}
		}

		// Token: 0x17005452 RID: 21586
		// (get) Token: 0x06025E49 RID: 155209 RVA: 0x009C7D9F File Offset: 0x009C5F9F
		// (set) Token: 0x06025E4A RID: 155210 RVA: 0x009C7DAF File Offset: 0x009C5FAF
		public unsafe float RefreshCounter
		{
			get
			{
				return *(base.NativePtr + (IntPtr)WBP_EffectStatisticsVisualize_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)WBP_EffectStatisticsVisualize_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x17005453 RID: 21587
		// (get) Token: 0x06025E4B RID: 155211 RVA: 0x009C7DC0 File Offset: 0x009C5FC0
		// (set) Token: 0x06025E4C RID: 155212 RVA: 0x009C7DD0 File Offset: 0x009C5FD0
		public unsafe float RefreshInterval
		{
			get
			{
				return *(base.NativePtr + (IntPtr)WBP_EffectStatisticsVisualize_C.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)WBP_EffectStatisticsVisualize_C.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x17005454 RID: 21588
		// (get) Token: 0x06025E4D RID: 155213 RVA: 0x009C7DE1 File Offset: 0x009C5FE1
		// (set) Token: 0x06025E4E RID: 155214 RVA: 0x009C7DF1 File Offset: 0x009C5FF1
		public unsafe int CurrentCount
		{
			get
			{
				return *(base.NativePtr + (IntPtr)WBP_EffectStatisticsVisualize_C.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)WBP_EffectStatisticsVisualize_C.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x17005455 RID: 21589
		// (get) Token: 0x06025E4F RID: 155215 RVA: 0x009C7E02 File Offset: 0x009C6002
		// (set) Token: 0x06025E50 RID: 155216 RVA: 0x009C7E12 File Offset: 0x009C6012
		public unsafe int TickCount
		{
			get
			{
				return *(base.NativePtr + (IntPtr)WBP_EffectStatisticsVisualize_C.__PropertyOffset_23);
			}
			set
			{
				*(base.NativePtr + (IntPtr)WBP_EffectStatisticsVisualize_C.__PropertyOffset_23) = value;
			}
		}

		// Token: 0x17005456 RID: 21590
		// (get) Token: 0x06025E51 RID: 155217 RVA: 0x009C7E23 File Offset: 0x009C6023
		// (set) Token: 0x06025E52 RID: 155218 RVA: 0x009C7E33 File Offset: 0x009C6033
		public unsafe int RegisteredInterval
		{
			get
			{
				return *(base.NativePtr + (IntPtr)WBP_EffectStatisticsVisualize_C.__PropertyOffset_24);
			}
			set
			{
				*(base.NativePtr + (IntPtr)WBP_EffectStatisticsVisualize_C.__PropertyOffset_24) = value;
			}
		}

		// Token: 0x17005457 RID: 21591
		// (get) Token: 0x06025E53 RID: 155219 RVA: 0x009C7E44 File Offset: 0x009C6044
		// (set) Token: 0x06025E54 RID: 155220 RVA: 0x009C7E54 File Offset: 0x009C6054
		public unsafe int ReleasedInterval
		{
			get
			{
				return *(base.NativePtr + (IntPtr)WBP_EffectStatisticsVisualize_C.__PropertyOffset_25);
			}
			set
			{
				*(base.NativePtr + (IntPtr)WBP_EffectStatisticsVisualize_C.__PropertyOffset_25) = value;
			}
		}

		// Token: 0x17005458 RID: 21592
		// (get) Token: 0x06025E55 RID: 155221 RVA: 0x009C7E65 File Offset: 0x009C6065
		// (set) Token: 0x06025E56 RID: 155222 RVA: 0x009C7E79 File Offset: 0x009C6079
		[Nullable(0)]
		public unsafe TEnumAsByte<EEffectStatisticsSortType> SortType
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)WBP_EffectStatisticsVisualize_C.__PropertyOffset_26);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)WBP_EffectStatisticsVisualize_C.__PropertyOffset_26) = value;
			}
		}

		// Token: 0x17005459 RID: 21593
		// (get) Token: 0x06025E57 RID: 155223 RVA: 0x009C7E8E File Offset: 0x009C608E
		// (set) Token: 0x06025E58 RID: 155224 RVA: 0x009C7E9E File Offset: 0x009C609E
		public unsafe bool Ascending
		{
			get
			{
				return *(base.NativePtr + (IntPtr)WBP_EffectStatisticsVisualize_C.__PropertyOffset_27) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)WBP_EffectStatisticsVisualize_C.__PropertyOffset_27) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700545A RID: 21594
		// (get) Token: 0x06025E59 RID: 155225 RVA: 0x009C7EAF File Offset: 0x009C60AF
		// (set) Token: 0x06025E5A RID: 155226 RVA: 0x009C7EBF File Offset: 0x009C60BF
		public unsafe int TempIndex
		{
			get
			{
				return *(base.NativePtr + (IntPtr)WBP_EffectStatisticsVisualize_C.__PropertyOffset_28);
			}
			set
			{
				*(base.NativePtr + (IntPtr)WBP_EffectStatisticsVisualize_C.__PropertyOffset_28) = value;
			}
		}

		// Token: 0x1700545B RID: 21595
		// (get) Token: 0x06025E5B RID: 155227 RVA: 0x009C7ED0 File Offset: 0x009C60D0
		// (set) Token: 0x06025E5C RID: 155228 RVA: 0x009C7EE0 File Offset: 0x009C60E0
		public unsafe int FactoryFilter
		{
			get
			{
				return *(base.NativePtr + (IntPtr)WBP_EffectStatisticsVisualize_C.__PropertyOffset_29);
			}
			set
			{
				*(base.NativePtr + (IntPtr)WBP_EffectStatisticsVisualize_C.__PropertyOffset_29) = value;
			}
		}

		// Token: 0x1700545C RID: 21596
		// (get) Token: 0x06025E5D RID: 155229 RVA: 0x009C7EF1 File Offset: 0x009C60F1
		// (set) Token: 0x06025E5E RID: 155230 RVA: 0x009C7F01 File Offset: 0x009C6101
		public unsafe int CheckTypeFilter
		{
			get
			{
				return *(base.NativePtr + (IntPtr)WBP_EffectStatisticsVisualize_C.__PropertyOffset_30);
			}
			set
			{
				*(base.NativePtr + (IntPtr)WBP_EffectStatisticsVisualize_C.__PropertyOffset_30) = value;
			}
		}

		// Token: 0x1700545D RID: 21597
		// (get) Token: 0x06025E5F RID: 155231 RVA: 0x009C7F12 File Offset: 0x009C6112
		// (set) Token: 0x06025E60 RID: 155232 RVA: 0x009C7F22 File Offset: 0x009C6122
		public unsafe int ListLength
		{
			get
			{
				return *(base.NativePtr + (IntPtr)WBP_EffectStatisticsVisualize_C.__PropertyOffset_31);
			}
			set
			{
				*(base.NativePtr + (IntPtr)WBP_EffectStatisticsVisualize_C.__PropertyOffset_31) = value;
			}
		}

		// Token: 0x1700545E RID: 21598
		// (get) Token: 0x06025E61 RID: 155233 RVA: 0x009C7F33 File Offset: 0x009C6133
		// (set) Token: 0x06025E62 RID: 155234 RVA: 0x009C7F43 File Offset: 0x009C6143
		public unsafe int NiagaraStatisticsCount
		{
			get
			{
				return *(base.NativePtr + (IntPtr)WBP_EffectStatisticsVisualize_C.__PropertyOffset_32);
			}
			set
			{
				*(base.NativePtr + (IntPtr)WBP_EffectStatisticsVisualize_C.__PropertyOffset_32) = value;
			}
		}

		// Token: 0x1700545F RID: 21599
		// (get) Token: 0x06025E63 RID: 155235 RVA: 0x009C7F54 File Offset: 0x009C6154
		// (set) Token: 0x06025E64 RID: 155236 RVA: 0x009C7F64 File Offset: 0x009C6164
		public unsafe int Content
		{
			get
			{
				return *(base.NativePtr + (IntPtr)WBP_EffectStatisticsVisualize_C.__PropertyOffset_33);
			}
			set
			{
				*(base.NativePtr + (IntPtr)WBP_EffectStatisticsVisualize_C.__PropertyOffset_33) = value;
			}
		}

		// Token: 0x17005460 RID: 21600
		// (get) Token: 0x06025E65 RID: 155237 RVA: 0x009C7F78 File Offset: 0x009C6178
		// (set) Token: 0x06025E66 RID: 155238 RVA: 0x009C7FB1 File Offset: 0x009C61B1
		[Nullable(1)]
		public FNiagaraDebugHUDSettingsData NiagaraDebugSettings
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				FNiagaraDebugHUDSettingsData result;
				if ((result = this._NiagaraDebugSettings) == null)
				{
					result = (this._NiagaraDebugSettings = new FNiagaraDebugHUDSettingsData(base.NativePtr + (IntPtr)WBP_EffectStatisticsVisualize_C.__PropertyOffset_34, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FNiagaraDebugHUDSettingsData.StaticStruct(), base.NativePtr + (IntPtr)WBP_EffectStatisticsVisualize_C.__PropertyOffset_34, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005461 RID: 21601
		// (get) Token: 0x06025E67 RID: 155239 RVA: 0x009C7FD2 File Offset: 0x009C61D2
		// (set) Token: 0x06025E68 RID: 155240 RVA: 0x009C7FE2 File Offset: 0x009C61E2
		public unsafe int TotalNiagaraSystems
		{
			get
			{
				return *(base.NativePtr + (IntPtr)WBP_EffectStatisticsVisualize_C.__PropertyOffset_35);
			}
			set
			{
				*(base.NativePtr + (IntPtr)WBP_EffectStatisticsVisualize_C.__PropertyOffset_35) = value;
			}
		}

		// Token: 0x17005462 RID: 21602
		// (get) Token: 0x06025E69 RID: 155241 RVA: 0x009C7FF3 File Offset: 0x009C61F3
		// (set) Token: 0x06025E6A RID: 155242 RVA: 0x009C8003 File Offset: 0x009C6203
		public unsafe int TotalNiagaraParticles
		{
			get
			{
				return *(base.NativePtr + (IntPtr)WBP_EffectStatisticsVisualize_C.__PropertyOffset_36);
			}
			set
			{
				*(base.NativePtr + (IntPtr)WBP_EffectStatisticsVisualize_C.__PropertyOffset_36) = value;
			}
		}

		// Token: 0x17005463 RID: 21603
		// (get) Token: 0x06025E6B RID: 155243 RVA: 0x009C8014 File Offset: 0x009C6214
		// (set) Token: 0x06025E6C RID: 155244 RVA: 0x009C8024 File Offset: 0x009C6224
		public unsafe int TotalNiagaraEmitters
		{
			get
			{
				return *(base.NativePtr + (IntPtr)WBP_EffectStatisticsVisualize_C.__PropertyOffset_37);
			}
			set
			{
				*(base.NativePtr + (IntPtr)WBP_EffectStatisticsVisualize_C.__PropertyOffset_37) = value;
			}
		}

		// Token: 0x17005464 RID: 21604
		// (get) Token: 0x06025E6D RID: 155245 RVA: 0x009C8035 File Offset: 0x009C6235
		// (set) Token: 0x06025E6E RID: 155246 RVA: 0x009C8045 File Offset: 0x009C6245
		public unsafe int TotalNiagaraMemoryUsage
		{
			get
			{
				return *(base.NativePtr + (IntPtr)WBP_EffectStatisticsVisualize_C.__PropertyOffset_38);
			}
			set
			{
				*(base.NativePtr + (IntPtr)WBP_EffectStatisticsVisualize_C.__PropertyOffset_38) = value;
			}
		}

		// Token: 0x17005465 RID: 21605
		// (get) Token: 0x06025E6F RID: 155247 RVA: 0x009C8056 File Offset: 0x009C6256
		// (set) Token: 0x06025E70 RID: 155248 RVA: 0x009C8066 File Offset: 0x009C6266
		public unsafe int TotalNiagaraCulled
		{
			get
			{
				return *(base.NativePtr + (IntPtr)WBP_EffectStatisticsVisualize_C.__PropertyOffset_39);
			}
			set
			{
				*(base.NativePtr + (IntPtr)WBP_EffectStatisticsVisualize_C.__PropertyOffset_39) = value;
			}
		}

		// Token: 0x17005466 RID: 21606
		// (get) Token: 0x06025E71 RID: 155249 RVA: 0x009C8078 File Offset: 0x009C6278
		// (set) Token: 0x06025E72 RID: 155250 RVA: 0x009C80B1 File Offset: 0x009C62B1
		[Nullable(1)]
		public SCharacterBodySpecifiedStruct NewVar_0
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				SCharacterBodySpecifiedStruct result;
				if ((result = this._NewVar_0) == null)
				{
					result = (this._NewVar_0 = new SCharacterBodySpecifiedStruct(base.NativePtr + (IntPtr)WBP_EffectStatisticsVisualize_C.__PropertyOffset_40, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SCharacterBodySpecifiedStruct.StaticStruct(), base.NativePtr + (IntPtr)WBP_EffectStatisticsVisualize_C.__PropertyOffset_40, value.NativePtr, 1, false);
			}
		}

		// Token: 0x06025E73 RID: 155251 RVA: 0x009C80D2 File Offset: 0x009C62D2
		protected WBP_EffectStatisticsVisualize_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04013952 RID: 80210
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Effect/Statistics/WBP_EffectStatisticsVisualize.WBP_EffectStatisticsVisualize_C";

		// Token: 0x04013953 RID: 80211
		private static IntPtr _ClassPtr;

		// Token: 0x04013954 RID: 80212
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04013955 RID: 80213
		internal static int __PropertyOffset_0;

		// Token: 0x04013956 RID: 80214
		internal static int __PropertyOffset_1;

		// Token: 0x04013957 RID: 80215
		internal static int __PropertyOffset_2;

		// Token: 0x04013958 RID: 80216
		internal static int __PropertyOffset_3;

		// Token: 0x04013959 RID: 80217
		internal static int __PropertyOffset_4;

		// Token: 0x0401395A RID: 80218
		internal static int __PropertyOffset_5;

		// Token: 0x0401395B RID: 80219
		internal static int __PropertyOffset_6;

		// Token: 0x0401395C RID: 80220
		internal static int __PropertyOffset_7;

		// Token: 0x0401395D RID: 80221
		internal static int __PropertyOffset_8;

		// Token: 0x0401395E RID: 80222
		internal static int __PropertyOffset_9;

		// Token: 0x0401395F RID: 80223
		internal static int __PropertyOffset_10;

		// Token: 0x04013960 RID: 80224
		internal static int __PropertyOffset_11;

		// Token: 0x04013961 RID: 80225
		internal static int __PropertyOffset_12;

		// Token: 0x04013962 RID: 80226
		internal static int __PropertyOffset_13;

		// Token: 0x04013963 RID: 80227
		internal static int __PropertyOffset_14;

		// Token: 0x04013964 RID: 80228
		internal static int __PropertyOffset_15;

		// Token: 0x04013965 RID: 80229
		internal static int __PropertyOffset_16;

		// Token: 0x04013966 RID: 80230
		internal static int __PropertyOffset_17;

		// Token: 0x04013967 RID: 80231
		internal static int __PropertyOffset_18;

		// Token: 0x04013968 RID: 80232
		internal static int __PropertyOffset_19;

		// Token: 0x04013969 RID: 80233
		internal static int __PropertyOffset_20;

		// Token: 0x0401396A RID: 80234
		internal static int __PropertyOffset_21;

		// Token: 0x0401396B RID: 80235
		internal static int __PropertyOffset_22;

		// Token: 0x0401396C RID: 80236
		internal static int __PropertyOffset_23;

		// Token: 0x0401396D RID: 80237
		internal static int __PropertyOffset_24;

		// Token: 0x0401396E RID: 80238
		internal static int __PropertyOffset_25;

		// Token: 0x0401396F RID: 80239
		internal static int __PropertyOffset_26;

		// Token: 0x04013970 RID: 80240
		internal static int __PropertyOffset_27;

		// Token: 0x04013971 RID: 80241
		internal static int __PropertyOffset_28;

		// Token: 0x04013972 RID: 80242
		internal static int __PropertyOffset_29;

		// Token: 0x04013973 RID: 80243
		internal static int __PropertyOffset_30;

		// Token: 0x04013974 RID: 80244
		internal static int __PropertyOffset_31;

		// Token: 0x04013975 RID: 80245
		internal static int __PropertyOffset_32;

		// Token: 0x04013976 RID: 80246
		internal static int __PropertyOffset_33;

		// Token: 0x04013977 RID: 80247
		internal static int __PropertyOffset_34;

		// Token: 0x04013978 RID: 80248
		private FNiagaraDebugHUDSettingsData _NiagaraDebugSettings;

		// Token: 0x04013979 RID: 80249
		internal static int __PropertyOffset_35;

		// Token: 0x0401397A RID: 80250
		internal static int __PropertyOffset_36;

		// Token: 0x0401397B RID: 80251
		internal static int __PropertyOffset_37;

		// Token: 0x0401397C RID: 80252
		internal static int __PropertyOffset_38;

		// Token: 0x0401397D RID: 80253
		internal static int __PropertyOffset_39;

		// Token: 0x0401397E RID: 80254
		internal static int __PropertyOffset_40;

		// Token: 0x0401397F RID: 80255
		private SCharacterBodySpecifiedStruct _NewVar_0;
	}
}
