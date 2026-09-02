using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Render.RuntimeBP.FluidNinjaLive.Core;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.FluidNinjaLive
{
	// Token: 0x02003CF8 RID: 15608
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/FluidNinjaLive/NinjaLive_PresetManager.NinjaLive_PresetManager_C")]
	[UnrealStructLayout(1528, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1521)]
	public class NinjaLive_PresetManager_C : AActor, IUnrealUObject, IUnrealObject, IWriteDataTableInterface_C, IUnrealBlueprintInterface, IUnrealInterface
	{
		// Token: 0x0602588F RID: 153743 RVA: 0x009BC4FB File Offset: 0x009BA6FB
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (NinjaLive_PresetManager_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/FluidNinjaLive/NinjaLive_PresetManager.NinjaLive_PresetManager_C");
			}
			return NinjaLive_PresetManager_C._ClassPtr;
		}

		// Token: 0x06025890 RID: 153744 RVA: 0x009BC520 File Offset: 0x009BA720
		public NinjaLive_PresetManager_C() : this(BuiltinUtils.AllocNativeUObject(NinjaLive_PresetManager_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06025891 RID: 153745 RVA: 0x009BC548 File Offset: 0x009BA748
		public NinjaLive_PresetManager_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(NinjaLive_PresetManager_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17005269 RID: 21097
		// (get) Token: 0x06025892 RID: 153746 RVA: 0x009BC57C File Offset: 0x009BA77C
		// (set) Token: 0x06025893 RID: 153747 RVA: 0x009BC5B5 File Offset: 0x009BA7B5
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)NinjaLive_PresetManager_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)NinjaLive_PresetManager_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700526A RID: 21098
		// (get) Token: 0x06025894 RID: 153748 RVA: 0x009BC5D6 File Offset: 0x009BA7D6
		// (set) Token: 0x06025895 RID: 153749 RVA: 0x009BC5EA File Offset: 0x009BA7EA
		[Nullable(2)]
		public unsafe UChildActorComponent WriteDataTableUtility
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLive_PresetManager_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLive_PresetManager_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x1700526B RID: 21099
		// (get) Token: 0x06025896 RID: 153750 RVA: 0x009BC5FF File Offset: 0x009BA7FF
		// (set) Token: 0x06025897 RID: 153751 RVA: 0x009BC613 File Offset: 0x009BA813
		[Nullable(2)]
		public unsafe USceneComponent Root
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLive_PresetManager_C.__PropertyOffset_2);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLive_PresetManager_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x1700526C RID: 21100
		// (get) Token: 0x06025898 RID: 153752 RVA: 0x009BC628 File Offset: 0x009BA828
		// (set) Token: 0x06025899 RID: 153753 RVA: 0x009BC63C File Offset: 0x009BA83C
		[Nullable(2)]
		public unsafe UMaterialBillboardComponent EditorIcon
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialBillboardComponent>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLive_PresetManager_C.__PropertyOffset_3);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLive_PresetManager_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x1700526D RID: 21101
		// (get) Token: 0x0602589A RID: 153754 RVA: 0x009BC651 File Offset: 0x009BA851
		// (set) Token: 0x0602589B RID: 153755 RVA: 0x009BC665 File Offset: 0x009BA865
		public unsafe FName AssetTrimmedName_Global
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLive_PresetManager_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLive_PresetManager_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x1700526E RID: 21102
		// (get) Token: 0x0602589C RID: 153756 RVA: 0x009BC67A File Offset: 0x009BA87A
		// (set) Token: 0x0602589D RID: 153757 RVA: 0x009BC68E File Offset: 0x009BA88E
		public unsafe FName AssetPath_Global
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLive_PresetManager_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLive_PresetManager_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x1700526F RID: 21103
		// (get) Token: 0x0602589E RID: 153758 RVA: 0x009BC6A3 File Offset: 0x009BA8A3
		// (set) Token: 0x0602589F RID: 153759 RVA: 0x009BC6B7 File Offset: 0x009BA8B7
		[Nullable(2)]
		public unsafe NinjaLiveGUI_C BP_Widget_GUI1_Var
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<NinjaLiveGUI_C>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLive_PresetManager_C.__PropertyOffset_6);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLive_PresetManager_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x17005270 RID: 21104
		// (get) Token: 0x060258A0 RID: 153760 RVA: 0x009BC6CC File Offset: 0x009BA8CC
		// (set) Token: 0x060258A1 RID: 153761 RVA: 0x009BC6E0 File Offset: 0x009BA8E0
		[Nullable(2)]
		public unsafe AActor DefaultActor
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLive_PresetManager_C.__PropertyOffset_7);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLive_PresetManager_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x17005271 RID: 21105
		// (get) Token: 0x060258A2 RID: 153762 RVA: 0x009BC6F5 File Offset: 0x009BA8F5
		// (set) Token: 0x060258A3 RID: 153763 RVA: 0x009BC705 File Offset: 0x009BA905
		public unsafe int DefaultLiveActorIndex
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLive_PresetManager_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLive_PresetManager_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17005272 RID: 21106
		// (get) Token: 0x060258A4 RID: 153764 RVA: 0x009BC718 File Offset: 0x009BA918
		// (set) Token: 0x060258A5 RID: 153765 RVA: 0x009BC751 File Offset: 0x009BA951
		public TArray<AActor> ArrayOfLevelActors
		{
			get
			{
				base.FastCheckIsValid();
				TArray<AActor> result;
				if ((result = this._ArrayOfLevelActors) == null)
				{
					result = (this._ArrayOfLevelActors = new TArray<AActor>(base.NativePtr + (IntPtr)NinjaLive_PresetManager_C.__PropertyOffset_9, this));
				}
				return result;
			}
			set
			{
				this.ArrayOfLevelActors.CopyAssign(value);
			}
		}

		// Token: 0x17005273 RID: 21107
		// (get) Token: 0x060258A6 RID: 153766 RVA: 0x009BC75F File Offset: 0x009BA95F
		// (set) Token: 0x060258A7 RID: 153767 RVA: 0x009BC773 File Offset: 0x009BA973
		public unsafe string NinjaLiveAssetTrimmedName
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)NinjaLive_PresetManager_C.__PropertyOffset_10)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)NinjaLive_PresetManager_C.__PropertyOffset_10)), value);
			}
		}

		// Token: 0x17005274 RID: 21108
		// (get) Token: 0x060258A8 RID: 153768 RVA: 0x009BC788 File Offset: 0x009BA988
		// (set) Token: 0x060258A9 RID: 153769 RVA: 0x009BC79C File Offset: 0x009BA99C
		public unsafe FName NinjaLivePath
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLive_PresetManager_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLive_PresetManager_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17005275 RID: 21109
		// (get) Token: 0x060258AA RID: 153770 RVA: 0x009BC7B4 File Offset: 0x009BA9B4
		// (set) Token: 0x060258AB RID: 153771 RVA: 0x009BC7ED File Offset: 0x009BA9ED
		public TArray<UNamedSlot> ArrayOfLevelActorNamedSlots
		{
			get
			{
				base.FastCheckIsValid();
				TArray<UNamedSlot> result;
				if ((result = this._ArrayOfLevelActorNamedSlots) == null)
				{
					result = (this._ArrayOfLevelActorNamedSlots = new TArray<UNamedSlot>(base.NativePtr + (IntPtr)NinjaLive_PresetManager_C.__PropertyOffset_12, this));
				}
				return result;
			}
			set
			{
				this.ArrayOfLevelActorNamedSlots.CopyAssign(value);
			}
		}

		// Token: 0x17005276 RID: 21110
		// (get) Token: 0x060258AC RID: 153772 RVA: 0x009BC7FB File Offset: 0x009BA9FB
		// (set) Token: 0x060258AD RID: 153773 RVA: 0x009BC80B File Offset: 0x009BAA0B
		public unsafe int RT_counter
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLive_PresetManager_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLive_PresetManager_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17005277 RID: 21111
		// (get) Token: 0x060258AE RID: 153774 RVA: 0x009BC81C File Offset: 0x009BAA1C
		// (set) Token: 0x060258AF RID: 153775 RVA: 0x009BC830 File Offset: 0x009BAA30
		public unsafe string RT_RenderPathDynamic
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)NinjaLive_PresetManager_C.__PropertyOffset_14)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)NinjaLive_PresetManager_C.__PropertyOffset_14)), value);
			}
		}

		// Token: 0x17005278 RID: 21112
		// (get) Token: 0x060258B0 RID: 153776 RVA: 0x009BC845 File Offset: 0x009BAA45
		// (set) Token: 0x060258B1 RID: 153777 RVA: 0x009BC859 File Offset: 0x009BAA59
		public unsafe string RT_RenderPathStatic
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)NinjaLive_PresetManager_C.__PropertyOffset_15)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)NinjaLive_PresetManager_C.__PropertyOffset_15)), value);
			}
		}

		// Token: 0x17005279 RID: 21113
		// (get) Token: 0x060258B2 RID: 153778 RVA: 0x009BC86E File Offset: 0x009BAA6E
		// (set) Token: 0x060258B3 RID: 153779 RVA: 0x009BC87E File Offset: 0x009BAA7E
		public unsafe bool GUIWidgetInitDone
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLive_PresetManager_C.__PropertyOffset_16) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLive_PresetManager_C.__PropertyOffset_16) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700527A RID: 21114
		// (get) Token: 0x060258B4 RID: 153780 RVA: 0x009BC890 File Offset: 0x009BAA90
		// (set) Token: 0x060258B5 RID: 153781 RVA: 0x009BC8C9 File Offset: 0x009BAAC9
		public TArray<UNamedSlot> NamedSlots
		{
			get
			{
				base.FastCheckIsValid();
				TArray<UNamedSlot> result;
				if ((result = this._NamedSlots) == null)
				{
					result = (this._NamedSlots = new TArray<UNamedSlot>(base.NativePtr + (IntPtr)NinjaLive_PresetManager_C.__PropertyOffset_17, this));
				}
				return result;
			}
			set
			{
				this.NamedSlots.CopyAssign(value);
			}
		}

		// Token: 0x1700527B RID: 21115
		// (get) Token: 0x060258B6 RID: 153782 RVA: 0x009BC8D7 File Offset: 0x009BAAD7
		// (set) Token: 0x060258B7 RID: 153783 RVA: 0x009BC8EB File Offset: 0x009BAAEB
		[Nullable(2)]
		public unsafe UDataTable LoadedDataTable
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UDataTable>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLive_PresetManager_C.__PropertyOffset_18);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLive_PresetManager_C.__PropertyOffset_18, value);
			}
		}

		// Token: 0x1700527C RID: 21116
		// (get) Token: 0x060258B8 RID: 153784 RVA: 0x009BC900 File Offset: 0x009BAB00
		// (set) Token: 0x060258B9 RID: 153785 RVA: 0x009BC914 File Offset: 0x009BAB14
		public unsafe string LoadedDataTablePath
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)NinjaLive_PresetManager_C.__PropertyOffset_19)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)NinjaLive_PresetManager_C.__PropertyOffset_19)), value);
			}
		}

		// Token: 0x1700527D RID: 21117
		// (get) Token: 0x060258BA RID: 153786 RVA: 0x009BC929 File Offset: 0x009BAB29
		// (set) Token: 0x060258BB RID: 153787 RVA: 0x009BC939 File Offset: 0x009BAB39
		public unsafe byte TextureCompression
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLive_PresetManager_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLive_PresetManager_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x1700527E RID: 21118
		// (get) Token: 0x060258BC RID: 153788 RVA: 0x009BC94A File Offset: 0x009BAB4A
		// (set) Token: 0x060258BD RID: 153789 RVA: 0x009BC95A File Offset: 0x009BAB5A
		public unsafe float PNGExportGamma
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLive_PresetManager_C.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLive_PresetManager_C.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x1700527F RID: 21119
		// (get) Token: 0x060258BE RID: 153790 RVA: 0x009BC96B File Offset: 0x009BAB6B
		// (set) Token: 0x060258BF RID: 153791 RVA: 0x009BC97B File Offset: 0x009BAB7B
		public unsafe bool SaveTexturesWithsRGB
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLive_PresetManager_C.__PropertyOffset_22) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLive_PresetManager_C.__PropertyOffset_22) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005280 RID: 21120
		// (get) Token: 0x060258C0 RID: 153792 RVA: 0x009BC98C File Offset: 0x009BAB8C
		// (set) Token: 0x060258C1 RID: 153793 RVA: 0x009BC99C File Offset: 0x009BAB9C
		public unsafe float VelocityMapDownscaleFactor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLive_PresetManager_C.__PropertyOffset_23);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLive_PresetManager_C.__PropertyOffset_23) = value;
			}
		}

		// Token: 0x17005281 RID: 21121
		// (get) Token: 0x060258C2 RID: 153794 RVA: 0x009BC9AD File Offset: 0x009BABAD
		// (set) Token: 0x060258C3 RID: 153795 RVA: 0x009BC9BD File Offset: 0x009BABBD
		public unsafe bool CompensateUEGammaCorrection
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLive_PresetManager_C.__PropertyOffset_24) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLive_PresetManager_C.__PropertyOffset_24) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005282 RID: 21122
		// (get) Token: 0x060258C4 RID: 153796 RVA: 0x009BC9CE File Offset: 0x009BABCE
		// (set) Token: 0x060258C5 RID: 153797 RVA: 0x009BC9DE File Offset: 0x009BABDE
		public unsafe int DensityMapTextureCompressionIndex
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLive_PresetManager_C.__PropertyOffset_25);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLive_PresetManager_C.__PropertyOffset_25) = value;
			}
		}

		// Token: 0x17005283 RID: 21123
		// (get) Token: 0x060258C6 RID: 153798 RVA: 0x009BC9EF File Offset: 0x009BABEF
		// (set) Token: 0x060258C7 RID: 153799 RVA: 0x009BC9FF File Offset: 0x009BABFF
		public unsafe int VelocityMapTextureCompressionIndex
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLive_PresetManager_C.__PropertyOffset_26);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLive_PresetManager_C.__PropertyOffset_26) = value;
			}
		}

		// Token: 0x17005284 RID: 21124
		// (get) Token: 0x060258C8 RID: 153800 RVA: 0x009BCA10 File Offset: 0x009BAC10
		// (set) Token: 0x060258C9 RID: 153801 RVA: 0x009BCA20 File Offset: 0x009BAC20
		public unsafe bool CustomTickRate
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLive_PresetManager_C.__PropertyOffset_27) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLive_PresetManager_C.__PropertyOffset_27) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005285 RID: 21125
		// (get) Token: 0x060258CA RID: 153802 RVA: 0x009BCA31 File Offset: 0x009BAC31
		// (set) Token: 0x060258CB RID: 153803 RVA: 0x009BCA41 File Offset: 0x009BAC41
		public unsafe bool UsePluginForFGAExport
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLive_PresetManager_C.__PropertyOffset_28) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLive_PresetManager_C.__PropertyOffset_28) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005286 RID: 21126
		// (get) Token: 0x060258CC RID: 153804 RVA: 0x009BCA52 File Offset: 0x009BAC52
		// (set) Token: 0x060258CD RID: 153805 RVA: 0x009BCA62 File Offset: 0x009BAC62
		public unsafe bool DisablePresetManager
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLive_PresetManager_C.__PropertyOffset_29) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLive_PresetManager_C.__PropertyOffset_29) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005287 RID: 21127
		// (get) Token: 0x060258CE RID: 153806 RVA: 0x009BCA73 File Offset: 0x009BAC73
		// (set) Token: 0x060258CF RID: 153807 RVA: 0x009BCA87 File Offset: 0x009BAC87
		[Nullable(2)]
		public unsafe AActor DefaultLiveStageActor
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLive_PresetManager_C.__PropertyOffset_30);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLive_PresetManager_C.__PropertyOffset_30, value);
			}
		}

		// Token: 0x17005288 RID: 21128
		// (get) Token: 0x060258D0 RID: 153808 RVA: 0x009BCA9C File Offset: 0x009BAC9C
		// (set) Token: 0x060258D1 RID: 153809 RVA: 0x009BCAAC File Offset: 0x009BACAC
		public unsafe bool HighlightSelectedActors
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLive_PresetManager_C.__PropertyOffset_31) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLive_PresetManager_C.__PropertyOffset_31) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005289 RID: 21129
		// (get) Token: 0x060258D2 RID: 153810 RVA: 0x009BCABD File Offset: 0x009BACBD
		// (set) Token: 0x060258D3 RID: 153811 RVA: 0x009BCAD1 File Offset: 0x009BACD1
		public unsafe string InternalSavePath
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)NinjaLive_PresetManager_C.__PropertyOffset_32)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)NinjaLive_PresetManager_C.__PropertyOffset_32)), value);
			}
		}

		// Token: 0x1700528A RID: 21130
		// (get) Token: 0x060258D4 RID: 153812 RVA: 0x009BCAE6 File Offset: 0x009BACE6
		// (set) Token: 0x060258D5 RID: 153813 RVA: 0x009BCAFA File Offset: 0x009BACFA
		public unsafe string ExternalSavePath
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)NinjaLive_PresetManager_C.__PropertyOffset_33)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)NinjaLive_PresetManager_C.__PropertyOffset_33)), value);
			}
		}

		// Token: 0x1700528B RID: 21131
		// (get) Token: 0x060258D6 RID: 153814 RVA: 0x009BCB0F File Offset: 0x009BAD0F
		// (set) Token: 0x060258D7 RID: 153815 RVA: 0x009BCB23 File Offset: 0x009BAD23
		public unsafe string DefaultPreset
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)NinjaLive_PresetManager_C.__PropertyOffset_34)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)NinjaLive_PresetManager_C.__PropertyOffset_34)), value);
			}
		}

		// Token: 0x1700528C RID: 21132
		// (get) Token: 0x060258D8 RID: 153816 RVA: 0x009BCB38 File Offset: 0x009BAD38
		// (set) Token: 0x060258D9 RID: 153817 RVA: 0x009BCB4C File Offset: 0x009BAD4C
		public unsafe string NinjaRootFolder
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)NinjaLive_PresetManager_C.__PropertyOffset_35)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)NinjaLive_PresetManager_C.__PropertyOffset_35)), value);
			}
		}

		// Token: 0x1700528D RID: 21133
		// (get) Token: 0x060258DA RID: 153818 RVA: 0x009BCB61 File Offset: 0x009BAD61
		// (set) Token: 0x060258DB RID: 153819 RVA: 0x009BCB75 File Offset: 0x009BAD75
		public unsafe string DefaultLiveActor
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)NinjaLive_PresetManager_C.__PropertyOffset_36)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)NinjaLive_PresetManager_C.__PropertyOffset_36)), value);
			}
		}

		// Token: 0x1700528E RID: 21134
		// (get) Token: 0x060258DC RID: 153820 RVA: 0x009BCB8A File Offset: 0x009BAD8A
		// (set) Token: 0x060258DD RID: 153821 RVA: 0x009BCB9A File Offset: 0x009BAD9A
		public unsafe bool FirstStart
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLive_PresetManager_C.__PropertyOffset_37) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLive_PresetManager_C.__PropertyOffset_37) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700528F RID: 21135
		// (get) Token: 0x060258DE RID: 153822 RVA: 0x009BCBAC File Offset: 0x009BADAC
		// (set) Token: 0x060258DF RID: 153823 RVA: 0x009BCBE5 File Offset: 0x009BADE5
		public TArray<FAssetData> AvailableImagesData
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FAssetData> result;
				if ((result = this._AvailableImagesData) == null)
				{
					result = (this._AvailableImagesData = new TArray<FAssetData>(base.NativePtr + (IntPtr)NinjaLive_PresetManager_C.__PropertyOffset_38, this));
				}
				return result;
			}
			set
			{
				this.AvailableImagesData.CopyAssign(value);
			}
		}

		// Token: 0x17005290 RID: 21136
		// (get) Token: 0x060258E0 RID: 153824 RVA: 0x009BCBF4 File Offset: 0x009BADF4
		// (set) Token: 0x060258E1 RID: 153825 RVA: 0x009BCC2D File Offset: 0x009BAE2D
		public TArray<FName> AvailableImagesNames
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FName> result;
				if ((result = this._AvailableImagesNames) == null)
				{
					result = (this._AvailableImagesNames = new TArray<FName>(base.NativePtr + (IntPtr)NinjaLive_PresetManager_C.__PropertyOffset_39, this));
				}
				return result;
			}
			set
			{
				this.AvailableImagesNames.CopyAssign(value);
			}
		}

		// Token: 0x17005291 RID: 21137
		// (get) Token: 0x060258E2 RID: 153826 RVA: 0x009BCC3C File Offset: 0x009BAE3C
		// (set) Token: 0x060258E3 RID: 153827 RVA: 0x009BCC75 File Offset: 0x009BAE75
		public TArray<FAssetData> AvailableParticlesData
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FAssetData> result;
				if ((result = this._AvailableParticlesData) == null)
				{
					result = (this._AvailableParticlesData = new TArray<FAssetData>(base.NativePtr + (IntPtr)NinjaLive_PresetManager_C.__PropertyOffset_40, this));
				}
				return result;
			}
			set
			{
				this.AvailableParticlesData.CopyAssign(value);
			}
		}

		// Token: 0x17005292 RID: 21138
		// (get) Token: 0x060258E4 RID: 153828 RVA: 0x009BCC84 File Offset: 0x009BAE84
		// (set) Token: 0x060258E5 RID: 153829 RVA: 0x009BCCBD File Offset: 0x009BAEBD
		public TArray<FName> AvailableParticleNames
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FName> result;
				if ((result = this._AvailableParticleNames) == null)
				{
					result = (this._AvailableParticleNames = new TArray<FName>(base.NativePtr + (IntPtr)NinjaLive_PresetManager_C.__PropertyOffset_41, this));
				}
				return result;
			}
			set
			{
				this.AvailableParticleNames.CopyAssign(value);
			}
		}

		// Token: 0x17005293 RID: 21139
		// (get) Token: 0x060258E6 RID: 153830 RVA: 0x009BCCCB File Offset: 0x009BAECB
		// (set) Token: 0x060258E7 RID: 153831 RVA: 0x009BCCDB File Offset: 0x009BAEDB
		public unsafe bool ArraysConstructed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLive_PresetManager_C.__PropertyOffset_42) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLive_PresetManager_C.__PropertyOffset_42) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005294 RID: 21140
		// (get) Token: 0x060258E8 RID: 153832 RVA: 0x009BCCEC File Offset: 0x009BAEEC
		// (set) Token: 0x060258E9 RID: 153833 RVA: 0x009BCCFC File Offset: 0x009BAEFC
		public unsafe bool PMInitFinished
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLive_PresetManager_C.__PropertyOffset_43) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLive_PresetManager_C.__PropertyOffset_43) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005295 RID: 21141
		// (get) Token: 0x060258EA RID: 153834 RVA: 0x009BCD0D File Offset: 0x009BAF0D
		// (set) Token: 0x060258EB RID: 153835 RVA: 0x009BCD1D File Offset: 0x009BAF1D
		public unsafe bool DebugPerformance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLive_PresetManager_C.__PropertyOffset_44) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLive_PresetManager_C.__PropertyOffset_44) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005296 RID: 21142
		// (get) Token: 0x060258EC RID: 153836 RVA: 0x009BCD2E File Offset: 0x009BAF2E
		// (set) Token: 0x060258ED RID: 153837 RVA: 0x009BCD3E File Offset: 0x009BAF3E
		public unsafe bool PoolManagerDetected
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLive_PresetManager_C.__PropertyOffset_45) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLive_PresetManager_C.__PropertyOffset_45) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005297 RID: 21143
		// (get) Token: 0x060258EE RID: 153838 RVA: 0x009BCD4F File Offset: 0x009BAF4F
		// (set) Token: 0x060258EF RID: 153839 RVA: 0x009BCD5F File Offset: 0x009BAF5F
		public unsafe bool AutoConnectToMemoryPool_IF_Found
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLive_PresetManager_C.__PropertyOffset_46) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLive_PresetManager_C.__PropertyOffset_46) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005298 RID: 21144
		// (get) Token: 0x060258F0 RID: 153840 RVA: 0x009BCD70 File Offset: 0x009BAF70
		// (set) Token: 0x060258F1 RID: 153841 RVA: 0x009BCD80 File Offset: 0x009BAF80
		public unsafe bool PresetManagerDebugPrint
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLive_PresetManager_C.__PropertyOffset_47) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLive_PresetManager_C.__PropertyOffset_47) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005299 RID: 21145
		// (get) Token: 0x060258F2 RID: 153842 RVA: 0x009BCD91 File Offset: 0x009BAF91
		// (set) Token: 0x060258F3 RID: 153843 RVA: 0x009BCDA1 File Offset: 0x009BAFA1
		public unsafe bool SaveDebugTextToDefaultLog
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLive_PresetManager_C.__PropertyOffset_48) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLive_PresetManager_C.__PropertyOffset_48) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700529A RID: 21146
		// (get) Token: 0x060258F4 RID: 153844 RVA: 0x009BCDB2 File Offset: 0x009BAFB2
		// (set) Token: 0x060258F5 RID: 153845 RVA: 0x009BCDC2 File Offset: 0x009BAFC2
		public unsafe float DebugTextLifetime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLive_PresetManager_C.__PropertyOffset_49);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLive_PresetManager_C.__PropertyOffset_49) = value;
			}
		}

		// Token: 0x1700529B RID: 21147
		// (get) Token: 0x060258F6 RID: 153846 RVA: 0x009BCDD3 File Offset: 0x009BAFD3
		// (set) Token: 0x060258F7 RID: 153847 RVA: 0x009BCDE7 File Offset: 0x009BAFE7
		public unsafe FColor HighlightColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLive_PresetManager_C.__PropertyOffset_50);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLive_PresetManager_C.__PropertyOffset_50) = value;
			}
		}

		// Token: 0x1700529C RID: 21148
		// (get) Token: 0x060258F8 RID: 153848 RVA: 0x009BCDFC File Offset: 0x009BAFFC
		// (set) Token: 0x060258F9 RID: 153849 RVA: 0x009BCE0C File Offset: 0x009BB00C
		public unsafe float HighlightThickness
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLive_PresetManager_C.__PropertyOffset_51);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLive_PresetManager_C.__PropertyOffset_51) = value;
			}
		}

		// Token: 0x1700529D RID: 21149
		// (get) Token: 0x060258FA RID: 153850 RVA: 0x009BCE1D File Offset: 0x009BB01D
		// (set) Token: 0x060258FB RID: 153851 RVA: 0x009BCE2D File Offset: 0x009BB02D
		public unsafe float HighlightDuration
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLive_PresetManager_C.__PropertyOffset_52);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLive_PresetManager_C.__PropertyOffset_52) = value;
			}
		}

		// Token: 0x1700529E RID: 21150
		// (get) Token: 0x060258FC RID: 153852 RVA: 0x009BCE3E File Offset: 0x009BB03E
		// (set) Token: 0x060258FD RID: 153853 RVA: 0x009BCE4E File Offset: 0x009BB04E
		public unsafe float HighlightRefreshRate
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLive_PresetManager_C.__PropertyOffset_53);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLive_PresetManager_C.__PropertyOffset_53) = value;
			}
		}

		// Token: 0x1700529F RID: 21151
		// (get) Token: 0x060258FE RID: 153854 RVA: 0x009BCE5F File Offset: 0x009BB05F
		// (set) Token: 0x060258FF RID: 153855 RVA: 0x009BCE6F File Offset: 0x009BB06F
		public unsafe bool ShowMouseCursor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLive_PresetManager_C.__PropertyOffset_54) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLive_PresetManager_C.__PropertyOffset_54) = (value ? 1 : 0);
			}
		}

		// Token: 0x170052A0 RID: 21152
		// (get) Token: 0x06025900 RID: 153856 RVA: 0x009BCE80 File Offset: 0x009BB080
		// (set) Token: 0x06025901 RID: 153857 RVA: 0x009BCE94 File Offset: 0x009BB094
		[Nullable(2)]
		public unsafe UMaterialInstanceDynamic RenderBufferSaver
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLive_PresetManager_C.__PropertyOffset_55);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLive_PresetManager_C.__PropertyOffset_55, value);
			}
		}

		// Token: 0x170052A1 RID: 21153
		// (get) Token: 0x06025902 RID: 153858 RVA: 0x009BCEAC File Offset: 0x009BB0AC
		// (set) Token: 0x06025903 RID: 153859 RVA: 0x009BCEE5 File Offset: 0x009BB0E5
		public TArray<string> PresetSavingBugWorkaroundUEversions
		{
			get
			{
				base.FastCheckIsValid();
				TArray<string> result;
				if ((result = this._PresetSavingBugWorkaroundUEversions) == null)
				{
					result = (this._PresetSavingBugWorkaroundUEversions = new TArray<string>(base.NativePtr + (IntPtr)NinjaLive_PresetManager_C.__PropertyOffset_56, this));
				}
				return result;
			}
			set
			{
				this.PresetSavingBugWorkaroundUEversions.CopyAssign(value);
			}
		}

		// Token: 0x170052A2 RID: 21154
		// (get) Token: 0x06025904 RID: 153860 RVA: 0x009BCEF3 File Offset: 0x009BB0F3
		// (set) Token: 0x06025905 RID: 153861 RVA: 0x009BCF03 File Offset: 0x009BB103
		public unsafe bool DisableGUIWarningOnPresetSaving
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLive_PresetManager_C.__PropertyOffset_57) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLive_PresetManager_C.__PropertyOffset_57) = (value ? 1 : 0);
			}
		}

		// Token: 0x06025906 RID: 153862 RVA: 0x009BCF14 File Offset: 0x009BB114
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void MarkForSave_UE426_BugWorkaround(UObject CurrentAsset)
		{
			NinjaLive_PresetManager_C.__MarkForSave_UE426_BugWorkaround_FunctionParams* ptr = stackalloc NinjaLive_PresetManager_C.__MarkForSave_UE426_BugWorkaround_FunctionParams[(UIntPtr)335] + 15L / (long)sizeof(NinjaLive_PresetManager_C.__MarkForSave_UE426_BugWorkaround_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLive_PresetManager_C.__MarkForSave_UE426_BugWorkaround_NativeFunctionPtr, (void*)ptr, 1);
			ptr->CurrentAsset = ((CurrentAsset != null) ? CurrentAsset.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLive_PresetManager_C.__MarkForSave_UE426_BugWorkaround_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025907 RID: 153863 RVA: 0x009BCF6C File Offset: 0x009BB16C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void ConvertToPowerOfTwo(int In, ref int Out)
		{
			NinjaLive_PresetManager_C.__ConvertToPowerOfTwo_FunctionParams* ptr = stackalloc NinjaLive_PresetManager_C.__ConvertToPowerOfTwo_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(NinjaLive_PresetManager_C.__ConvertToPowerOfTwo_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLive_PresetManager_C.__ConvertToPowerOfTwo_NativeFunctionPtr, (void*)ptr, 1);
			ptr->In = In;
			ptr->Out = Out;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLive_PresetManager_C.__ConvertToPowerOfTwo_NativeFunctionPtr, (void*)ptr);
			Out = ptr->Out;
		}

		// Token: 0x06025908 RID: 153864 RVA: 0x009BCFC4 File Offset: 0x009BB1C4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetCurrentLevelInfo(ref FName LevelName, ref FName LevelPath)
		{
			NinjaLive_PresetManager_C.__GetCurrentLevelInfo_FunctionParams* ptr = stackalloc NinjaLive_PresetManager_C.__GetCurrentLevelInfo_FunctionParams[(UIntPtr)255] + 15L / (long)sizeof(NinjaLive_PresetManager_C.__GetCurrentLevelInfo_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLive_PresetManager_C.__GetCurrentLevelInfo_NativeFunctionPtr, (void*)ptr, 1);
			ptr->LevelName = LevelName;
			ptr->LevelPath = LevelPath;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLive_PresetManager_C.__GetCurrentLevelInfo_NativeFunctionPtr, (void*)ptr);
			LevelName = ptr->LevelName;
			LevelPath = ptr->LevelPath;
		}

		// Token: 0x06025909 RID: 153865 RVA: 0x009BD038 File Offset: 0x009BB238
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void MarkNewFilesAsUnsaved([Nullable(new byte[]
		{
			2,
			1
		})] ref TArray<FAssetData> ArrayOfUnsaveAssetData)
		{
			NinjaLive_PresetManager_C.__MarkNewFilesAsUnsaved_FunctionParams* ptr = stackalloc NinjaLive_PresetManager_C.__MarkNewFilesAsUnsaved_FunctionParams[(UIntPtr)183] + 15L / (long)sizeof(NinjaLive_PresetManager_C.__MarkNewFilesAsUnsaved_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLive_PresetManager_C.__MarkNewFilesAsUnsaved_NativeFunctionPtr, (void*)ptr, 1);
			TArray<FAssetData> tarray = ArrayOfUnsaveAssetData;
			if (tarray != null)
			{
				tarray.MoveTo(&ptr->ArrayOfUnsaveAssetData);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLive_PresetManager_C.__MarkNewFilesAsUnsaved_NativeFunctionPtr, (void*)ptr);
			TArray<FAssetData> tarray2 = ArrayOfUnsaveAssetData;
			if (tarray2 != null)
			{
				tarray2.MoveAssign(&ptr->ArrayOfUnsaveAssetData);
			}
			UnrealReflectionUtils.DestroyStruct(NinjaLive_PresetManager_C.__MarkNewFilesAsUnsaved_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602590A RID: 153866 RVA: 0x009BD0B4 File Offset: 0x009BB2B4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void DataTable_SingleKeyPicker_DT([Nullable(2)] UDataTable DataTableIn, string KeyToPick, ref string PickedKeyValue, ref bool NotFound)
		{
			NinjaLive_PresetManager_C.__DataTable_SingleKeyPicker_DT_FunctionParams* ptr = stackalloc NinjaLive_PresetManager_C.__DataTable_SingleKeyPicker_DT_FunctionParams[(UIntPtr)135] + 15L / (long)sizeof(NinjaLive_PresetManager_C.__DataTable_SingleKeyPicker_DT_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLive_PresetManager_C.__DataTable_SingleKeyPicker_DT_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DataTableIn = ((DataTableIn != null) ? DataTableIn.NativePtr : IntPtr.Zero);
			FString.CopyFrom((void*)(&ptr->KeyToPick), KeyToPick);
			FString.CopyFrom((void*)(&ptr->PickedKeyValue), PickedKeyValue);
			ptr->NotFound = NotFound;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLive_PresetManager_C.__DataTable_SingleKeyPicker_DT_NativeFunctionPtr, (void*)ptr);
			PickedKeyValue = FString.ToString((void*)(&ptr->PickedKeyValue));
			NotFound = ptr->NotFound;
			UnrealReflectionUtils.DestroyStruct(NinjaLive_PresetManager_C.__DataTable_SingleKeyPicker_DT_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602590B RID: 153867 RVA: 0x009BD158 File Offset: 0x009BB358
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Preset_SingleKeyPicker_DT(string PresetName, string KeyToPick, [Nullable(2)] ref UDataTable DataTable, ref string PickedKeyValue)
		{
			NinjaLive_PresetManager_C.__Preset_SingleKeyPicker_DT_FunctionParams* ptr = stackalloc NinjaLive_PresetManager_C.__Preset_SingleKeyPicker_DT_FunctionParams[(UIntPtr)567] + 15L / (long)sizeof(NinjaLive_PresetManager_C.__Preset_SingleKeyPicker_DT_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLive_PresetManager_C.__Preset_SingleKeyPicker_DT_NativeFunctionPtr, (void*)ptr, 1);
			FString.CopyFrom((void*)(&ptr->PresetName), PresetName);
			FString.CopyFrom((void*)(&ptr->KeyToPick), KeyToPick);
			ref NinjaLive_PresetManager_C.__Preset_SingleKeyPicker_DT_FunctionParams ptr2 = ref *ptr;
			UDataTable udataTable = DataTable;
			ptr2.DataTable = ((udataTable != null) ? udataTable.NativePtr : IntPtr.Zero);
			FString.CopyFrom((void*)(&ptr->PickedKeyValue), PickedKeyValue);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLive_PresetManager_C.__Preset_SingleKeyPicker_DT_NativeFunctionPtr, (void*)ptr);
			DataTable = BuiltinUtils.GetOrCreateUObjectByNativePointer<UDataTable>(ptr->DataTable);
			PickedKeyValue = FString.ToString((void*)(&ptr->PickedKeyValue));
			UnrealReflectionUtils.DestroyStruct(NinjaLive_PresetManager_C.__Preset_SingleKeyPicker_DT_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602590C RID: 153868 RVA: 0x009BD208 File Offset: 0x009BB408
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void AssetDataFromObject(UObject InputObject, ref FAssetData ComboAssetData, ref FName Object_Path, ref FName Package_Name, ref FName Package_Path, ref FName Asset_Name, ref FName Asset_Class)
		{
			NinjaLive_PresetManager_C.__AssetDataFromObject_FunctionParams* ptr = stackalloc NinjaLive_PresetManager_C.__AssetDataFromObject_FunctionParams[(UIntPtr)559] + 15L / (long)sizeof(NinjaLive_PresetManager_C.__AssetDataFromObject_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLive_PresetManager_C.__AssetDataFromObject_NativeFunctionPtr, (void*)ptr, 1);
			ptr->InputObject = ((InputObject != null) ? InputObject.NativePtr : IntPtr.Zero);
			if (ComboAssetData != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FAssetData.StaticStruct(), &ptr->ComboAssetData, ComboAssetData.NativePtr, 1, false);
			}
			ptr->Object_Path = Object_Path;
			ptr->Package_Name = Package_Name;
			ptr->Package_Path = Package_Path;
			ptr->Asset_Name = Asset_Name;
			ptr->Asset_Class = Asset_Class;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLive_PresetManager_C.__AssetDataFromObject_NativeFunctionPtr, (void*)ptr);
			if (ComboAssetData != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FAssetData.StaticStruct(), ComboAssetData.NativePtr, &ptr->ComboAssetData, 1, false);
			}
			Object_Path = ptr->Object_Path;
			Package_Name = ptr->Package_Name;
			Package_Path = ptr->Package_Path;
			Asset_Name = ptr->Asset_Name;
			Asset_Class = ptr->Asset_Class;
			UnrealReflectionUtils.DestroyStruct(NinjaLive_PresetManager_C.__AssetDataFromObject_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602590D RID: 153869 RVA: 0x009BD33C File Offset: 0x009BB53C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Preset_to_InternalCSV_to_DT_Saver(bool OverWriteFlag, string VarAsString, string SelectedItem, [Nullable(2)] ref TArray<FName> AssetPaths, FName AssetName)
		{
			NinjaLive_PresetManager_C.__Preset_to_InternalCSV_to_DT_Saver_FunctionParams* ptr = stackalloc NinjaLive_PresetManager_C.__Preset_to_InternalCSV_to_DT_Saver_FunctionParams[(UIntPtr)1271] + 15L / (long)sizeof(NinjaLive_PresetManager_C.__Preset_to_InternalCSV_to_DT_Saver_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLive_PresetManager_C.__Preset_to_InternalCSV_to_DT_Saver_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverWriteFlag = OverWriteFlag;
			FString.CopyFrom((void*)(&ptr->VarAsString), VarAsString);
			FString.CopyFrom((void*)(&ptr->SelectedItem), SelectedItem);
			TArray<FName> tarray = AssetPaths;
			if (tarray != null)
			{
				tarray.MoveTo(&ptr->AssetPaths);
			}
			ptr->AssetName = AssetName;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLive_PresetManager_C.__Preset_to_InternalCSV_to_DT_Saver_NativeFunctionPtr, (void*)ptr);
			TArray<FName> tarray2 = AssetPaths;
			if (tarray2 != null)
			{
				tarray2.MoveAssign(&ptr->AssetPaths);
			}
			UnrealReflectionUtils.DestroyStruct(NinjaLive_PresetManager_C.__Preset_to_InternalCSV_to_DT_Saver_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602590E RID: 153870 RVA: 0x009BD3E4 File Offset: 0x009BB5E4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void RenderTargetExportSingle([Nullable(2)] UTextureRenderTarget2D TextureRenderTarget, bool InternalSave, bool sRGB, bool NoAlpha, bool SaveWithDialog, FName InternalFilePath, FName ExternalFilePath, string FileName, string Extension, ref FName SavedAssetPath, [Nullable(2)] ref FAssetData SavedAssetData)
		{
			NinjaLive_PresetManager_C.__RenderTargetExportSingle_FunctionParams* ptr = stackalloc NinjaLive_PresetManager_C.__RenderTargetExportSingle_FunctionParams[(UIntPtr)895] + 15L / (long)sizeof(NinjaLive_PresetManager_C.__RenderTargetExportSingle_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLive_PresetManager_C.__RenderTargetExportSingle_NativeFunctionPtr, (void*)ptr, 1);
			ptr->TextureRenderTarget = ((TextureRenderTarget != null) ? TextureRenderTarget.NativePtr : IntPtr.Zero);
			ptr->InternalSave = InternalSave;
			ptr->sRGB = sRGB;
			ptr->NoAlpha = NoAlpha;
			ptr->SaveWithDialog = SaveWithDialog;
			ptr->InternalFilePath = InternalFilePath;
			ptr->ExternalFilePath = ExternalFilePath;
			FString.CopyFrom((void*)(&ptr->FileName), FileName);
			FString.CopyFrom((void*)(&ptr->Extension), Extension);
			ptr->SavedAssetPath = SavedAssetPath;
			if (SavedAssetData != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FAssetData.StaticStruct(), &ptr->SavedAssetData, SavedAssetData.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLive_PresetManager_C.__RenderTargetExportSingle_NativeFunctionPtr, (void*)ptr);
			SavedAssetPath = ptr->SavedAssetPath;
			if (SavedAssetData != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FAssetData.StaticStruct(), SavedAssetData.NativePtr, &ptr->SavedAssetData, 1, false);
			}
			UnrealReflectionUtils.DestroyStruct(NinjaLive_PresetManager_C.__RenderTargetExportSingle_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602590F RID: 153871 RVA: 0x009BD500 File Offset: 0x009BB700
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetAssetNameAndPath(UObject Object, ref FName AssetTrimmedName, ref FName AssetPath)
		{
			NinjaLive_PresetManager_C.__SetAssetNameAndPath_FunctionParams* ptr = stackalloc NinjaLive_PresetManager_C.__SetAssetNameAndPath_FunctionParams[(UIntPtr)367] + 15L / (long)sizeof(NinjaLive_PresetManager_C.__SetAssetNameAndPath_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLive_PresetManager_C.__SetAssetNameAndPath_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Object = ((Object != null) ? Object.NativePtr : IntPtr.Zero);
			ptr->AssetTrimmedName = AssetTrimmedName;
			ptr->AssetPath = AssetPath;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLive_PresetManager_C.__SetAssetNameAndPath_NativeFunctionPtr, (void*)ptr);
			AssetTrimmedName = ptr->AssetTrimmedName;
			AssetPath = ptr->AssetPath;
		}

		// Token: 0x06025910 RID: 153872 RVA: 0x009BD588 File Offset: 0x009BB788
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLive_PresetManager_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06025911 RID: 153873 RVA: 0x009BD59C File Offset: 0x009BB79C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, NinjaLive_PresetManager_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06025912 RID: 153874 RVA: 0x009BD5B4 File Offset: 0x009BB7B4
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void InpActEvt_LeftMouseButton_K2Node_InputKeyEvent_5(FKey Key)
		{
			NinjaLive_PresetManager_C.__InpActEvt_LeftMouseButton_K2Node_InputKeyEvent_5_FunctionParams* ptr = stackalloc NinjaLive_PresetManager_C.__InpActEvt_LeftMouseButton_K2Node_InputKeyEvent_5_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(NinjaLive_PresetManager_C.__InpActEvt_LeftMouseButton_K2Node_InputKeyEvent_5_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLive_PresetManager_C.__InpActEvt_LeftMouseButton_K2Node_InputKeyEvent_5_NativeFunctionPtr, (void*)ptr, 1);
			if (Key != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FKey.StaticStruct(), &ptr->Key, Key.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLive_PresetManager_C.__InpActEvt_LeftMouseButton_K2Node_InputKeyEvent_5_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(NinjaLive_PresetManager_C.__InpActEvt_LeftMouseButton_K2Node_InputKeyEvent_5_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x06025913 RID: 153875 RVA: 0x009BD628 File Offset: 0x009BB828
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void InpActEvt_LeftMouseButton_K2Node_InputKeyEvent_4(FKey Key)
		{
			NinjaLive_PresetManager_C.__InpActEvt_LeftMouseButton_K2Node_InputKeyEvent_4_FunctionParams* ptr = stackalloc NinjaLive_PresetManager_C.__InpActEvt_LeftMouseButton_K2Node_InputKeyEvent_4_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(NinjaLive_PresetManager_C.__InpActEvt_LeftMouseButton_K2Node_InputKeyEvent_4_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLive_PresetManager_C.__InpActEvt_LeftMouseButton_K2Node_InputKeyEvent_4_NativeFunctionPtr, (void*)ptr, 1);
			if (Key != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FKey.StaticStruct(), &ptr->Key, Key.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLive_PresetManager_C.__InpActEvt_LeftMouseButton_K2Node_InputKeyEvent_4_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(NinjaLive_PresetManager_C.__InpActEvt_LeftMouseButton_K2Node_InputKeyEvent_4_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x06025914 RID: 153876 RVA: 0x009BD69C File Offset: 0x009BB89C
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void InpActEvt_RightMouseButton_K2Node_InputKeyEvent_3(FKey Key)
		{
			NinjaLive_PresetManager_C.__InpActEvt_RightMouseButton_K2Node_InputKeyEvent_3_FunctionParams* ptr = stackalloc NinjaLive_PresetManager_C.__InpActEvt_RightMouseButton_K2Node_InputKeyEvent_3_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(NinjaLive_PresetManager_C.__InpActEvt_RightMouseButton_K2Node_InputKeyEvent_3_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLive_PresetManager_C.__InpActEvt_RightMouseButton_K2Node_InputKeyEvent_3_NativeFunctionPtr, (void*)ptr, 1);
			if (Key != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FKey.StaticStruct(), &ptr->Key, Key.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLive_PresetManager_C.__InpActEvt_RightMouseButton_K2Node_InputKeyEvent_3_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(NinjaLive_PresetManager_C.__InpActEvt_RightMouseButton_K2Node_InputKeyEvent_3_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x06025915 RID: 153877 RVA: 0x009BD710 File Offset: 0x009BB910
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void InpActEvt_RightMouseButton_K2Node_InputKeyEvent_2(FKey Key)
		{
			NinjaLive_PresetManager_C.__InpActEvt_RightMouseButton_K2Node_InputKeyEvent_2_FunctionParams* ptr = stackalloc NinjaLive_PresetManager_C.__InpActEvt_RightMouseButton_K2Node_InputKeyEvent_2_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(NinjaLive_PresetManager_C.__InpActEvt_RightMouseButton_K2Node_InputKeyEvent_2_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLive_PresetManager_C.__InpActEvt_RightMouseButton_K2Node_InputKeyEvent_2_NativeFunctionPtr, (void*)ptr, 1);
			if (Key != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FKey.StaticStruct(), &ptr->Key, Key.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLive_PresetManager_C.__InpActEvt_RightMouseButton_K2Node_InputKeyEvent_2_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(NinjaLive_PresetManager_C.__InpActEvt_RightMouseButton_K2Node_InputKeyEvent_2_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x06025916 RID: 153878 RVA: 0x009BD784 File Offset: 0x009BB984
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void InpActEvt_MiddleMouseButton_K2Node_InputKeyEvent_1(FKey Key)
		{
			NinjaLive_PresetManager_C.__InpActEvt_MiddleMouseButton_K2Node_InputKeyEvent_1_FunctionParams* ptr = stackalloc NinjaLive_PresetManager_C.__InpActEvt_MiddleMouseButton_K2Node_InputKeyEvent_1_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(NinjaLive_PresetManager_C.__InpActEvt_MiddleMouseButton_K2Node_InputKeyEvent_1_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLive_PresetManager_C.__InpActEvt_MiddleMouseButton_K2Node_InputKeyEvent_1_NativeFunctionPtr, (void*)ptr, 1);
			if (Key != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FKey.StaticStruct(), &ptr->Key, Key.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLive_PresetManager_C.__InpActEvt_MiddleMouseButton_K2Node_InputKeyEvent_1_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(NinjaLive_PresetManager_C.__InpActEvt_MiddleMouseButton_K2Node_InputKeyEvent_1_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x06025917 RID: 153879 RVA: 0x009BD7F8 File Offset: 0x009BB9F8
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void InpActEvt_MiddleMouseButton_K2Node_InputKeyEvent_0(FKey Key)
		{
			NinjaLive_PresetManager_C.__InpActEvt_MiddleMouseButton_K2Node_InputKeyEvent_0_FunctionParams* ptr = stackalloc NinjaLive_PresetManager_C.__InpActEvt_MiddleMouseButton_K2Node_InputKeyEvent_0_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(NinjaLive_PresetManager_C.__InpActEvt_MiddleMouseButton_K2Node_InputKeyEvent_0_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLive_PresetManager_C.__InpActEvt_MiddleMouseButton_K2Node_InputKeyEvent_0_NativeFunctionPtr, (void*)ptr, 1);
			if (Key != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FKey.StaticStruct(), &ptr->Key, Key.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLive_PresetManager_C.__InpActEvt_MiddleMouseButton_K2Node_InputKeyEvent_0_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(NinjaLive_PresetManager_C.__InpActEvt_MiddleMouseButton_K2Node_InputKeyEvent_0_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x06025918 RID: 153880 RVA: 0x009BD86C File Offset: 0x009BBA6C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void WriteDataTableFunction([Nullable(2)] UDataTable InputTable, string InputData)
		{
			NinjaLive_PresetManager_C.__WriteDataTableFunction_FunctionParams* ptr = stackalloc NinjaLive_PresetManager_C.__WriteDataTableFunction_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(NinjaLive_PresetManager_C.__WriteDataTableFunction_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLive_PresetManager_C.__WriteDataTableFunction_NativeFunctionPtr, (void*)ptr, 1);
			ptr->InputTable = ((InputTable != null) ? InputTable.NativePtr : IntPtr.Zero);
			FString.CopyFrom((void*)(&ptr->InputData), InputData);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLive_PresetManager_C.__WriteDataTableFunction_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(NinjaLive_PresetManager_C.__WriteDataTableFunction_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x06025919 RID: 153881 RVA: 0x009BD8DF File Offset: 0x009BBADF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLive_PresetManager_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0602591A RID: 153882 RVA: 0x009BD8F3 File Offset: 0x009BBAF3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, NinjaLive_PresetManager_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602591B RID: 153883 RVA: 0x009BD908 File Offset: 0x009BBB08
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			NinjaLive_PresetManager_C.__ReceiveTick_FunctionParams* ptr = stackalloc NinjaLive_PresetManager_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(NinjaLive_PresetManager_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLive_PresetManager_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLive_PresetManager_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602591C RID: 153884 RVA: 0x009BD950 File Offset: 0x009BBB50
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			NinjaLive_PresetManager_C.__ReceiveTick_FunctionParams* ptr = stackalloc NinjaLive_PresetManager_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(NinjaLive_PresetManager_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLive_PresetManager_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, NinjaLive_PresetManager_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602591D RID: 153885 RVA: 0x009BD998 File Offset: 0x009BBB98
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OnDensityMapSave(bool SavePaintBuffer)
		{
			NinjaLive_PresetManager_C.__OnDensityMapSave_FunctionParams* ptr = stackalloc NinjaLive_PresetManager_C.__OnDensityMapSave_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(NinjaLive_PresetManager_C.__OnDensityMapSave_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLive_PresetManager_C.__OnDensityMapSave_NativeFunctionPtr, (void*)ptr, 1);
			ptr->SavePaintBuffer = SavePaintBuffer;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLive_PresetManager_C.__OnDensityMapSave_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602591E RID: 153886 RVA: 0x009BD9E0 File Offset: 0x009BBBE0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_NinjaLive_PresetManager(int EntryPoint)
		{
			NinjaLive_PresetManager_C.__ExecuteUbergraph_NinjaLive_PresetManager_FunctionParams* ptr = stackalloc NinjaLive_PresetManager_C.__ExecuteUbergraph_NinjaLive_PresetManager_FunctionParams[(UIntPtr)1119] + 15L / (long)sizeof(NinjaLive_PresetManager_C.__ExecuteUbergraph_NinjaLive_PresetManager_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLive_PresetManager_C.__ExecuteUbergraph_NinjaLive_PresetManager_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, NinjaLive_PresetManager_C.__ExecuteUbergraph_NinjaLive_PresetManager_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602591F RID: 153887 RVA: 0x009BDA2A File Offset: 0x009BBC2A
		protected NinjaLive_PresetManager_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040135BF RID: 79295
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/FluidNinjaLive/NinjaLive_PresetManager.NinjaLive_PresetManager_C";

		// Token: 0x040135C0 RID: 79296
		private static IntPtr _ClassPtr;

		// Token: 0x040135C1 RID: 79297
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040135C2 RID: 79298
		internal static int __PropertyOffset_0;

		// Token: 0x040135C3 RID: 79299
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040135C4 RID: 79300
		internal static int __PropertyOffset_1;

		// Token: 0x040135C5 RID: 79301
		internal static int __PropertyOffset_2;

		// Token: 0x040135C6 RID: 79302
		internal static int __PropertyOffset_3;

		// Token: 0x040135C7 RID: 79303
		internal static int __PropertyOffset_4;

		// Token: 0x040135C8 RID: 79304
		internal static int __PropertyOffset_5;

		// Token: 0x040135C9 RID: 79305
		internal static int __PropertyOffset_6;

		// Token: 0x040135CA RID: 79306
		internal static int __PropertyOffset_7;

		// Token: 0x040135CB RID: 79307
		internal static int __PropertyOffset_8;

		// Token: 0x040135CC RID: 79308
		internal static int __PropertyOffset_9;

		// Token: 0x040135CD RID: 79309
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<AActor> _ArrayOfLevelActors;

		// Token: 0x040135CE RID: 79310
		internal static int __PropertyOffset_10;

		// Token: 0x040135CF RID: 79311
		internal static int __PropertyOffset_11;

		// Token: 0x040135D0 RID: 79312
		internal static int __PropertyOffset_12;

		// Token: 0x040135D1 RID: 79313
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UNamedSlot> _ArrayOfLevelActorNamedSlots;

		// Token: 0x040135D2 RID: 79314
		internal static int __PropertyOffset_13;

		// Token: 0x040135D3 RID: 79315
		internal static int __PropertyOffset_14;

		// Token: 0x040135D4 RID: 79316
		internal static int __PropertyOffset_15;

		// Token: 0x040135D5 RID: 79317
		internal static int __PropertyOffset_16;

		// Token: 0x040135D6 RID: 79318
		internal static int __PropertyOffset_17;

		// Token: 0x040135D7 RID: 79319
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UNamedSlot> _NamedSlots;

		// Token: 0x040135D8 RID: 79320
		internal static int __PropertyOffset_18;

		// Token: 0x040135D9 RID: 79321
		internal static int __PropertyOffset_19;

		// Token: 0x040135DA RID: 79322
		internal static int __PropertyOffset_20;

		// Token: 0x040135DB RID: 79323
		internal static int __PropertyOffset_21;

		// Token: 0x040135DC RID: 79324
		internal static int __PropertyOffset_22;

		// Token: 0x040135DD RID: 79325
		internal static int __PropertyOffset_23;

		// Token: 0x040135DE RID: 79326
		internal static int __PropertyOffset_24;

		// Token: 0x040135DF RID: 79327
		internal static int __PropertyOffset_25;

		// Token: 0x040135E0 RID: 79328
		internal static int __PropertyOffset_26;

		// Token: 0x040135E1 RID: 79329
		internal static int __PropertyOffset_27;

		// Token: 0x040135E2 RID: 79330
		internal static int __PropertyOffset_28;

		// Token: 0x040135E3 RID: 79331
		internal static int __PropertyOffset_29;

		// Token: 0x040135E4 RID: 79332
		internal static int __PropertyOffset_30;

		// Token: 0x040135E5 RID: 79333
		internal static int __PropertyOffset_31;

		// Token: 0x040135E6 RID: 79334
		internal static int __PropertyOffset_32;

		// Token: 0x040135E7 RID: 79335
		internal static int __PropertyOffset_33;

		// Token: 0x040135E8 RID: 79336
		internal static int __PropertyOffset_34;

		// Token: 0x040135E9 RID: 79337
		internal static int __PropertyOffset_35;

		// Token: 0x040135EA RID: 79338
		internal static int __PropertyOffset_36;

		// Token: 0x040135EB RID: 79339
		internal static int __PropertyOffset_37;

		// Token: 0x040135EC RID: 79340
		internal static int __PropertyOffset_38;

		// Token: 0x040135ED RID: 79341
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<FAssetData> _AvailableImagesData;

		// Token: 0x040135EE RID: 79342
		internal static int __PropertyOffset_39;

		// Token: 0x040135EF RID: 79343
		[Nullable(2)]
		private TArray<FName> _AvailableImagesNames;

		// Token: 0x040135F0 RID: 79344
		internal static int __PropertyOffset_40;

		// Token: 0x040135F1 RID: 79345
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<FAssetData> _AvailableParticlesData;

		// Token: 0x040135F2 RID: 79346
		internal static int __PropertyOffset_41;

		// Token: 0x040135F3 RID: 79347
		[Nullable(2)]
		private TArray<FName> _AvailableParticleNames;

		// Token: 0x040135F4 RID: 79348
		internal static int __PropertyOffset_42;

		// Token: 0x040135F5 RID: 79349
		internal static int __PropertyOffset_43;

		// Token: 0x040135F6 RID: 79350
		internal static int __PropertyOffset_44;

		// Token: 0x040135F7 RID: 79351
		internal static int __PropertyOffset_45;

		// Token: 0x040135F8 RID: 79352
		internal static int __PropertyOffset_46;

		// Token: 0x040135F9 RID: 79353
		internal static int __PropertyOffset_47;

		// Token: 0x040135FA RID: 79354
		internal static int __PropertyOffset_48;

		// Token: 0x040135FB RID: 79355
		internal static int __PropertyOffset_49;

		// Token: 0x040135FC RID: 79356
		internal static int __PropertyOffset_50;

		// Token: 0x040135FD RID: 79357
		internal static int __PropertyOffset_51;

		// Token: 0x040135FE RID: 79358
		internal static int __PropertyOffset_52;

		// Token: 0x040135FF RID: 79359
		internal static int __PropertyOffset_53;

		// Token: 0x04013600 RID: 79360
		internal static int __PropertyOffset_54;

		// Token: 0x04013601 RID: 79361
		internal static int __PropertyOffset_55;

		// Token: 0x04013602 RID: 79362
		internal static int __PropertyOffset_56;

		// Token: 0x04013603 RID: 79363
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<string> _PresetSavingBugWorkaroundUEversions;

		// Token: 0x04013604 RID: 79364
		internal static int __PropertyOffset_57;

		// Token: 0x04013605 RID: 79365
		private static IntPtr __MarkForSave_UE426_BugWorkaround_NativeFunctionPtr;

		// Token: 0x04013606 RID: 79366
		private static IntPtr __ConvertToPowerOfTwo_NativeFunctionPtr;

		// Token: 0x04013607 RID: 79367
		private static IntPtr __GetCurrentLevelInfo_NativeFunctionPtr;

		// Token: 0x04013608 RID: 79368
		private static IntPtr __MarkNewFilesAsUnsaved_NativeFunctionPtr;

		// Token: 0x04013609 RID: 79369
		private static IntPtr __DataTable_SingleKeyPicker_DT_NativeFunctionPtr;

		// Token: 0x0401360A RID: 79370
		private static IntPtr __Preset_SingleKeyPicker_DT_NativeFunctionPtr;

		// Token: 0x0401360B RID: 79371
		private static IntPtr __AssetDataFromObject_NativeFunctionPtr;

		// Token: 0x0401360C RID: 79372
		private static IntPtr __Preset_to_InternalCSV_to_DT_Saver_NativeFunctionPtr;

		// Token: 0x0401360D RID: 79373
		private static IntPtr __RenderTargetExportSingle_NativeFunctionPtr;

		// Token: 0x0401360E RID: 79374
		private static IntPtr __SetAssetNameAndPath_NativeFunctionPtr;

		// Token: 0x0401360F RID: 79375
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04013610 RID: 79376
		private static IntPtr __InpActEvt_LeftMouseButton_K2Node_InputKeyEvent_5_NativeFunctionPtr;

		// Token: 0x04013611 RID: 79377
		private static IntPtr __InpActEvt_LeftMouseButton_K2Node_InputKeyEvent_4_NativeFunctionPtr;

		// Token: 0x04013612 RID: 79378
		private static IntPtr __InpActEvt_RightMouseButton_K2Node_InputKeyEvent_3_NativeFunctionPtr;

		// Token: 0x04013613 RID: 79379
		private static IntPtr __InpActEvt_RightMouseButton_K2Node_InputKeyEvent_2_NativeFunctionPtr;

		// Token: 0x04013614 RID: 79380
		private static IntPtr __InpActEvt_MiddleMouseButton_K2Node_InputKeyEvent_1_NativeFunctionPtr;

		// Token: 0x04013615 RID: 79381
		private static IntPtr __InpActEvt_MiddleMouseButton_K2Node_InputKeyEvent_0_NativeFunctionPtr;

		// Token: 0x04013616 RID: 79382
		private static IntPtr __WriteDataTableFunction_NativeFunctionPtr;

		// Token: 0x04013617 RID: 79383
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04013618 RID: 79384
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04013619 RID: 79385
		private static IntPtr __OnDensityMapSave_NativeFunctionPtr;

		// Token: 0x0401361A RID: 79386
		private static IntPtr __ExecuteUbergraph_NinjaLive_PresetManager_NativeFunctionPtr;

		// Token: 0x02009F16 RID: 40726
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 320)]
		protected ref struct __MarkForSave_UE426_BugWorkaround_FunctionParams
		{
			// Token: 0x04032A28 RID: 207400
			[FieldOffset(0)]
			public IntPtr CurrentAsset;
		}

		// Token: 0x02009F17 RID: 40727
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __ConvertToPowerOfTwo_FunctionParams
		{
			// Token: 0x04032A29 RID: 207401
			[FieldOffset(0)]
			public int In;

			// Token: 0x04032A2A RID: 207402
			[FieldOffset(4)]
			public int Out;
		}

		// Token: 0x02009F18 RID: 40728
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 240)]
		protected ref struct __GetCurrentLevelInfo_FunctionParams
		{
			// Token: 0x04032A2B RID: 207403
			[FieldOffset(0)]
			public FName LevelName;

			// Token: 0x04032A2C RID: 207404
			[FieldOffset(12)]
			public FName LevelPath;
		}

		// Token: 0x02009F19 RID: 40729
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 168)]
		protected ref struct __MarkNewFilesAsUnsaved_FunctionParams
		{
			// Token: 0x04032A2D RID: 207405
			[FieldOffset(0)]
			public byte ArrayOfUnsaveAssetData;
		}

		// Token: 0x02009F1A RID: 40730
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 120)]
		protected ref struct __DataTable_SingleKeyPicker_DT_FunctionParams
		{
			// Token: 0x04032A2E RID: 207406
			[FieldOffset(0)]
			public IntPtr DataTableIn;

			// Token: 0x04032A2F RID: 207407
			[FieldOffset(8)]
			public FString KeyToPick;

			// Token: 0x04032A30 RID: 207408
			[FieldOffset(24)]
			public FString PickedKeyValue;

			// Token: 0x04032A31 RID: 207409
			[FieldOffset(40)]
			public bool NotFound;
		}

		// Token: 0x02009F1B RID: 40731
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 552)]
		protected ref struct __Preset_SingleKeyPicker_DT_FunctionParams
		{
			// Token: 0x04032A32 RID: 207410
			[FieldOffset(0)]
			public FString PresetName;

			// Token: 0x04032A33 RID: 207411
			[FieldOffset(16)]
			public FString KeyToPick;

			// Token: 0x04032A34 RID: 207412
			[FieldOffset(32)]
			public IntPtr DataTable;

			// Token: 0x04032A35 RID: 207413
			[FieldOffset(40)]
			public FString PickedKeyValue;
		}

		// Token: 0x02009F1C RID: 40732
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 544)]
		protected ref struct __AssetDataFromObject_FunctionParams
		{
			// Token: 0x04032A36 RID: 207414
			[FieldOffset(0)]
			public IntPtr InputObject;

			// Token: 0x04032A37 RID: 207415
			[FieldOffset(8)]
			public byte ComboAssetData;

			// Token: 0x04032A38 RID: 207416
			[FieldOffset(120)]
			public FName Object_Path;

			// Token: 0x04032A39 RID: 207417
			[FieldOffset(132)]
			public FName Package_Name;

			// Token: 0x04032A3A RID: 207418
			[FieldOffset(144)]
			public FName Package_Path;

			// Token: 0x04032A3B RID: 207419
			[FieldOffset(156)]
			public FName Asset_Name;

			// Token: 0x04032A3C RID: 207420
			[FieldOffset(168)]
			public FName Asset_Class;
		}

		// Token: 0x02009F1D RID: 40733
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1256)]
		protected ref struct __Preset_to_InternalCSV_to_DT_Saver_FunctionParams
		{
			// Token: 0x04032A3D RID: 207421
			[FieldOffset(0)]
			public bool OverWriteFlag;

			// Token: 0x04032A3E RID: 207422
			[FieldOffset(8)]
			public FString VarAsString;

			// Token: 0x04032A3F RID: 207423
			[FieldOffset(24)]
			public FString SelectedItem;

			// Token: 0x04032A40 RID: 207424
			[FieldOffset(40)]
			public byte AssetPaths;

			// Token: 0x04032A41 RID: 207425
			[FieldOffset(56)]
			public FName AssetName;
		}

		// Token: 0x02009F1E RID: 40734
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 880)]
		protected ref struct __RenderTargetExportSingle_FunctionParams
		{
			// Token: 0x04032A42 RID: 207426
			[FieldOffset(0)]
			public IntPtr TextureRenderTarget;

			// Token: 0x04032A43 RID: 207427
			[FieldOffset(8)]
			public bool InternalSave;

			// Token: 0x04032A44 RID: 207428
			[FieldOffset(9)]
			public bool sRGB;

			// Token: 0x04032A45 RID: 207429
			[FieldOffset(10)]
			public bool NoAlpha;

			// Token: 0x04032A46 RID: 207430
			[FieldOffset(11)]
			public bool SaveWithDialog;

			// Token: 0x04032A47 RID: 207431
			[FieldOffset(12)]
			public FName InternalFilePath;

			// Token: 0x04032A48 RID: 207432
			[FieldOffset(24)]
			public FName ExternalFilePath;

			// Token: 0x04032A49 RID: 207433
			[FieldOffset(40)]
			public FString FileName;

			// Token: 0x04032A4A RID: 207434
			[FieldOffset(56)]
			public FString Extension;

			// Token: 0x04032A4B RID: 207435
			[FieldOffset(72)]
			public FName SavedAssetPath;

			// Token: 0x04032A4C RID: 207436
			[FieldOffset(88)]
			public byte SavedAssetData;
		}

		// Token: 0x02009F1F RID: 40735
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 352)]
		protected ref struct __SetAssetNameAndPath_FunctionParams
		{
			// Token: 0x04032A4D RID: 207437
			[FieldOffset(0)]
			public IntPtr Object;

			// Token: 0x04032A4E RID: 207438
			[FieldOffset(8)]
			public FName AssetTrimmedName;

			// Token: 0x04032A4F RID: 207439
			[FieldOffset(20)]
			public FName AssetPath;
		}

		// Token: 0x02009F20 RID: 40736
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __InpActEvt_LeftMouseButton_K2Node_InputKeyEvent_5_FunctionParams
		{
			// Token: 0x04032A50 RID: 207440
			[FieldOffset(0)]
			public byte Key;
		}

		// Token: 0x02009F21 RID: 40737
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __InpActEvt_LeftMouseButton_K2Node_InputKeyEvent_4_FunctionParams
		{
			// Token: 0x04032A51 RID: 207441
			[FieldOffset(0)]
			public byte Key;
		}

		// Token: 0x02009F22 RID: 40738
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __InpActEvt_RightMouseButton_K2Node_InputKeyEvent_3_FunctionParams
		{
			// Token: 0x04032A52 RID: 207442
			[FieldOffset(0)]
			public byte Key;
		}

		// Token: 0x02009F23 RID: 40739
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __InpActEvt_RightMouseButton_K2Node_InputKeyEvent_2_FunctionParams
		{
			// Token: 0x04032A53 RID: 207443
			[FieldOffset(0)]
			public byte Key;
		}

		// Token: 0x02009F24 RID: 40740
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __InpActEvt_MiddleMouseButton_K2Node_InputKeyEvent_1_FunctionParams
		{
			// Token: 0x04032A54 RID: 207444
			[FieldOffset(0)]
			public byte Key;
		}

		// Token: 0x02009F25 RID: 40741
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __InpActEvt_MiddleMouseButton_K2Node_InputKeyEvent_0_FunctionParams
		{
			// Token: 0x04032A55 RID: 207445
			[FieldOffset(0)]
			public byte Key;
		}

		// Token: 0x02009F26 RID: 40742
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __WriteDataTableFunction_FunctionParams
		{
			// Token: 0x04032A56 RID: 207446
			[FieldOffset(0)]
			public IntPtr InputTable;

			// Token: 0x04032A57 RID: 207447
			[FieldOffset(8)]
			public FString InputData;
		}

		// Token: 0x02009F27 RID: 40743
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032A58 RID: 207448
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009F28 RID: 40744
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected ref struct __OnDensityMapSave_FunctionParams
		{
			// Token: 0x04032A59 RID: 207449
			[FieldOffset(0)]
			public bool SavePaintBuffer;
		}

		// Token: 0x02009F29 RID: 40745
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1104)]
		protected ref struct __ExecuteUbergraph_NinjaLive_PresetManager_FunctionParams
		{
			// Token: 0x04032A5A RID: 207450
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
