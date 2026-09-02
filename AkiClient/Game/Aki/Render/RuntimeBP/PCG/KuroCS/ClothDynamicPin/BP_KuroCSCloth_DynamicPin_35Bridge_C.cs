using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Render.RuntimeBP.PCG.PBD_PhysicBridge.BP;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.KuroCS.ClothDynamicPin
{
	// Token: 0x02003C05 RID: 15365
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/KuroCS/ClothDynamicPin/BP_KuroCSCloth_DynamicPin_35Bridge.BP_KuroCSCloth_DynamicPin_35Bridge_C")]
	[UnrealStructLayout(2016, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2004)]
	public class BP_KuroCSCloth_DynamicPin_35Bridge_C : AKuroCS_Cloth_DynamicPin, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06022D1B RID: 142619 RVA: 0x0097013A File Offset: 0x0096E33A
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_KuroCSCloth_DynamicPin_35Bridge_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/KuroCS/ClothDynamicPin/BP_KuroCSCloth_DynamicPin_35Bridge.BP_KuroCSCloth_DynamicPin_35Bridge_C");
			}
			return BP_KuroCSCloth_DynamicPin_35Bridge_C._ClassPtr;
		}

		// Token: 0x06022D1C RID: 142620 RVA: 0x00970160 File Offset: 0x0096E360
		public BP_KuroCSCloth_DynamicPin_35Bridge_C() : this(BuiltinUtils.AllocNativeUObject(BP_KuroCSCloth_DynamicPin_35Bridge_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06022D1D RID: 142621 RVA: 0x00970188 File Offset: 0x0096E388
		[NullableContext(1)]
		public BP_KuroCSCloth_DynamicPin_35Bridge_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_KuroCSCloth_DynamicPin_35Bridge_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170042E4 RID: 17124
		// (get) Token: 0x06022D1E RID: 142622 RVA: 0x009701BC File Offset: 0x0096E3BC
		// (set) Token: 0x06022D1F RID: 142623 RVA: 0x009701F5 File Offset: 0x0096E3F5
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_KuroCSCloth_DynamicPin_35Bridge_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_KuroCSCloth_DynamicPin_35Bridge_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170042E5 RID: 17125
		// (get) Token: 0x06022D20 RID: 142624 RVA: 0x00970216 File Offset: 0x0096E416
		// (set) Token: 0x06022D21 RID: 142625 RVA: 0x0097022A File Offset: 0x0096E42A
		public unsafe UBoxComponent Box
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCSCloth_DynamicPin_35Bridge_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCSCloth_DynamicPin_35Bridge_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170042E6 RID: 17126
		// (get) Token: 0x06022D22 RID: 142626 RVA: 0x0097023F File Offset: 0x0096E43F
		// (set) Token: 0x06022D23 RID: 142627 RVA: 0x00970253 File Offset: 0x0096E453
		public unsafe UStaticMeshComponent MobileProxy
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCSCloth_DynamicPin_35Bridge_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCSCloth_DynamicPin_35Bridge_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170042E7 RID: 17127
		// (get) Token: 0x06022D24 RID: 142628 RVA: 0x00970268 File Offset: 0x0096E468
		// (set) Token: 0x06022D25 RID: 142629 RVA: 0x0097027C File Offset: 0x0096E47C
		public unsafe UStaticMeshComponent MeshXZ
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCSCloth_DynamicPin_35Bridge_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCSCloth_DynamicPin_35Bridge_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x170042E8 RID: 17128
		// (get) Token: 0x06022D26 RID: 142630 RVA: 0x00970291 File Offset: 0x0096E491
		// (set) Token: 0x06022D27 RID: 142631 RVA: 0x009702A5 File Offset: 0x0096E4A5
		public unsafe USceneComponent PinnedLB
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCSCloth_DynamicPin_35Bridge_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCSCloth_DynamicPin_35Bridge_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x170042E9 RID: 17129
		// (get) Token: 0x06022D28 RID: 142632 RVA: 0x009702BA File Offset: 0x0096E4BA
		// (set) Token: 0x06022D29 RID: 142633 RVA: 0x009702CE File Offset: 0x0096E4CE
		public unsafe USceneComponent PinnedLT
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCSCloth_DynamicPin_35Bridge_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCSCloth_DynamicPin_35Bridge_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x170042EA RID: 17130
		// (get) Token: 0x06022D2A RID: 142634 RVA: 0x009702E3 File Offset: 0x0096E4E3
		// (set) Token: 0x06022D2B RID: 142635 RVA: 0x009702F7 File Offset: 0x0096E4F7
		public unsafe USceneComponent PinnedRB
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCSCloth_DynamicPin_35Bridge_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCSCloth_DynamicPin_35Bridge_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x170042EB RID: 17131
		// (get) Token: 0x06022D2C RID: 142636 RVA: 0x0097030C File Offset: 0x0096E50C
		// (set) Token: 0x06022D2D RID: 142637 RVA: 0x00970320 File Offset: 0x0096E520
		public unsafe USceneComponent PinnedRT
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCSCloth_DynamicPin_35Bridge_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCSCloth_DynamicPin_35Bridge_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x170042EC RID: 17132
		// (get) Token: 0x06022D2E RID: 142638 RVA: 0x00970335 File Offset: 0x0096E535
		// (set) Token: 0x06022D2F RID: 142639 RVA: 0x00970349 File Offset: 0x0096E549
		public unsafe UTextureRenderTarget2D RTPos
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCSCloth_DynamicPin_35Bridge_C.__PropertyOffset_8);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCSCloth_DynamicPin_35Bridge_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x170042ED RID: 17133
		// (get) Token: 0x06022D30 RID: 142640 RVA: 0x0097035E File Offset: 0x0096E55E
		// (set) Token: 0x06022D31 RID: 142641 RVA: 0x0097036E File Offset: 0x0096E56E
		public unsafe bool bSyncToBindPoint
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroCSCloth_DynamicPin_35Bridge_C.__PropertyOffset_9) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCSCloth_DynamicPin_35Bridge_C.__PropertyOffset_9) = (value ? 1 : 0);
			}
		}

		// Token: 0x170042EE RID: 17134
		// (get) Token: 0x06022D32 RID: 142642 RVA: 0x0097037F File Offset: 0x0096E57F
		// (set) Token: 0x06022D33 RID: 142643 RVA: 0x00970393 File Offset: 0x0096E593
		public unsafe BP_BridgeModels_3_5_C bindBrige
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_BridgeModels_3_5_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCSCloth_DynamicPin_35Bridge_C.__PropertyOffset_10);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCSCloth_DynamicPin_35Bridge_C.__PropertyOffset_10, value);
			}
		}

		// Token: 0x170042EF RID: 17135
		// (get) Token: 0x06022D34 RID: 142644 RVA: 0x009703A8 File Offset: 0x0096E5A8
		// (set) Token: 0x06022D35 RID: 142645 RVA: 0x009703BC File Offset: 0x0096E5BC
		public unsafe BP_CPP_bridge_doubleChain_realModel_Broken_C BindBridgeChain
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_CPP_bridge_doubleChain_realModel_Broken_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCSCloth_DynamicPin_35Bridge_C.__PropertyOffset_11);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCSCloth_DynamicPin_35Bridge_C.__PropertyOffset_11, value);
			}
		}

		// Token: 0x170042F0 RID: 17136
		// (get) Token: 0x06022D36 RID: 142646 RVA: 0x009703D1 File Offset: 0x0096E5D1
		// (set) Token: 0x06022D37 RID: 142647 RVA: 0x009703E1 File Offset: 0x0096E5E1
		public unsafe int linkIndex
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroCSCloth_DynamicPin_35Bridge_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCSCloth_DynamicPin_35Bridge_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x170042F1 RID: 17137
		// (get) Token: 0x06022D38 RID: 142648 RVA: 0x009703F2 File Offset: 0x0096E5F2
		// (set) Token: 0x06022D39 RID: 142649 RVA: 0x00970402 File Offset: 0x0096E602
		public unsafe bool bEditorTick
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroCSCloth_DynamicPin_35Bridge_C.__PropertyOffset_13) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCSCloth_DynamicPin_35Bridge_C.__PropertyOffset_13) = (value ? 1 : 0);
			}
		}

		// Token: 0x170042F2 RID: 17138
		// (get) Token: 0x06022D3A RID: 142650 RVA: 0x00970413 File Offset: 0x0096E613
		// (set) Token: 0x06022D3B RID: 142651 RVA: 0x00970427 File Offset: 0x0096E627
		public unsafe FVector PosOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroCSCloth_DynamicPin_35Bridge_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCSCloth_DynamicPin_35Bridge_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x170042F3 RID: 17139
		// (get) Token: 0x06022D3C RID: 142652 RVA: 0x0097043C File Offset: 0x0096E63C
		// (set) Token: 0x06022D3D RID: 142653 RVA: 0x00970475 File Offset: 0x0096E675
		[Nullable(1)]
		public TArray<UMaterialInstanceDynamic> Mats
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<UMaterialInstanceDynamic> result;
				if ((result = this._Mats) == null)
				{
					result = (this._Mats = new TArray<UMaterialInstanceDynamic>(base.NativePtr + (IntPtr)BP_KuroCSCloth_DynamicPin_35Bridge_C.__PropertyOffset_15, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Mats.CopyAssign(value);
			}
		}

		// Token: 0x170042F4 RID: 17140
		// (get) Token: 0x06022D3E RID: 142654 RVA: 0x00970483 File Offset: 0x0096E683
		// (set) Token: 0x06022D3F RID: 142655 RVA: 0x00970493 File Offset: 0x0096E693
		public unsafe bool bDrawDebug
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroCSCloth_DynamicPin_35Bridge_C.__PropertyOffset_16) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCSCloth_DynamicPin_35Bridge_C.__PropertyOffset_16) = (value ? 1 : 0);
			}
		}

		// Token: 0x170042F5 RID: 17141
		// (get) Token: 0x06022D40 RID: 142656 RVA: 0x009704A4 File Offset: 0x0096E6A4
		// (set) Token: 0x06022D41 RID: 142657 RVA: 0x009704B8 File Offset: 0x0096E6B8
		public unsafe UChildActorComponent editorTicker
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCSCloth_DynamicPin_35Bridge_C.__PropertyOffset_17);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCSCloth_DynamicPin_35Bridge_C.__PropertyOffset_17, value);
			}
		}

		// Token: 0x170042F6 RID: 17142
		// (get) Token: 0x06022D42 RID: 142658 RVA: 0x009704CD File Offset: 0x0096E6CD
		// (set) Token: 0x06022D43 RID: 142659 RVA: 0x009704DD File Offset: 0x0096E6DD
		public unsafe bool bEnable
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroCSCloth_DynamicPin_35Bridge_C.__PropertyOffset_18) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCSCloth_DynamicPin_35Bridge_C.__PropertyOffset_18) = (value ? 1 : 0);
			}
		}

		// Token: 0x170042F7 RID: 17143
		// (get) Token: 0x06022D44 RID: 142660 RVA: 0x009704EE File Offset: 0x0096E6EE
		// (set) Token: 0x06022D45 RID: 142661 RVA: 0x009704FE File Offset: 0x0096E6FE
		public unsafe int Substep_Count
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroCSCloth_DynamicPin_35Bridge_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCSCloth_DynamicPin_35Bridge_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x170042F8 RID: 17144
		// (get) Token: 0x06022D46 RID: 142662 RVA: 0x0097050F File Offset: 0x0096E70F
		// (set) Token: 0x06022D47 RID: 142663 RVA: 0x0097051F File Offset: 0x0096E71F
		public unsafe bool InitOverlap
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroCSCloth_DynamicPin_35Bridge_C.__PropertyOffset_20) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCSCloth_DynamicPin_35Bridge_C.__PropertyOffset_20) = (value ? 1 : 0);
			}
		}

		// Token: 0x170042F9 RID: 17145
		// (get) Token: 0x06022D48 RID: 142664 RVA: 0x00970530 File Offset: 0x0096E730
		// (set) Token: 0x06022D49 RID: 142665 RVA: 0x00970540 File Offset: 0x0096E740
		public unsafe bool bFadeOut
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroCSCloth_DynamicPin_35Bridge_C.__PropertyOffset_21) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCSCloth_DynamicPin_35Bridge_C.__PropertyOffset_21) = (value ? 1 : 0);
			}
		}

		// Token: 0x170042FA RID: 17146
		// (get) Token: 0x06022D4A RID: 142666 RVA: 0x00970551 File Offset: 0x0096E751
		// (set) Token: 0x06022D4B RID: 142667 RVA: 0x00970561 File Offset: 0x0096E761
		public unsafe float FadeOut
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroCSCloth_DynamicPin_35Bridge_C.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCSCloth_DynamicPin_35Bridge_C.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x170042FB RID: 17147
		// (get) Token: 0x06022D4C RID: 142668 RVA: 0x00970572 File Offset: 0x0096E772
		// (set) Token: 0x06022D4D RID: 142669 RVA: 0x00970582 File Offset: 0x0096E782
		public unsafe bool bStopSim
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroCSCloth_DynamicPin_35Bridge_C.__PropertyOffset_23) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCSCloth_DynamicPin_35Bridge_C.__PropertyOffset_23) = (value ? 1 : 0);
			}
		}

		// Token: 0x170042FC RID: 17148
		// (get) Token: 0x06022D4E RID: 142670 RVA: 0x00970593 File Offset: 0x0096E793
		// (set) Token: 0x06022D4F RID: 142671 RVA: 0x009705A3 File Offset: 0x0096E7A3
		public unsafe bool bInit
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroCSCloth_DynamicPin_35Bridge_C.__PropertyOffset_24) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCSCloth_DynamicPin_35Bridge_C.__PropertyOffset_24) = (value ? 1 : 0);
			}
		}

		// Token: 0x170042FD RID: 17149
		// (get) Token: 0x06022D50 RID: 142672 RVA: 0x009705B4 File Offset: 0x0096E7B4
		// (set) Token: 0x06022D51 RID: 142673 RVA: 0x009705ED File Offset: 0x0096E7ED
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
					result = (this._Scalar_Parameters = new TMap<FName, float>(base.NativePtr + (IntPtr)BP_KuroCSCloth_DynamicPin_35Bridge_C.__PropertyOffset_25, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Scalar_Parameters.CopyAssign(value);
			}
		}

		// Token: 0x170042FE RID: 17150
		// (get) Token: 0x06022D52 RID: 142674 RVA: 0x009705FC File Offset: 0x0096E7FC
		// (set) Token: 0x06022D53 RID: 142675 RVA: 0x00970635 File Offset: 0x0096E835
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
					result = (this._Vector_Parameters = new TMap<FName, FLinearColor>(base.NativePtr + (IntPtr)BP_KuroCSCloth_DynamicPin_35Bridge_C.__PropertyOffset_26, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Vector_Parameters.CopyAssign(value);
			}
		}

		// Token: 0x170042FF RID: 17151
		// (get) Token: 0x06022D54 RID: 142676 RVA: 0x00970644 File Offset: 0x0096E844
		// (set) Token: 0x06022D55 RID: 142677 RVA: 0x0097067D File Offset: 0x0096E87D
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
					result = (this._Texture_Parameters = new TMap<FName, UTexture>(base.NativePtr + (IntPtr)BP_KuroCSCloth_DynamicPin_35Bridge_C.__PropertyOffset_27, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Texture_Parameters.CopyAssign(value);
			}
		}

		// Token: 0x17004300 RID: 17152
		// (get) Token: 0x06022D56 RID: 142678 RVA: 0x0097068B File Offset: 0x0096E88B
		// (set) Token: 0x06022D57 RID: 142679 RVA: 0x0097069F File Offset: 0x0096E89F
		public unsafe FTransformDouble Transform
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroCSCloth_DynamicPin_35Bridge_C.__PropertyOffset_28);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCSCloth_DynamicPin_35Bridge_C.__PropertyOffset_28) = value;
			}
		}

		// Token: 0x17004301 RID: 17153
		// (get) Token: 0x06022D58 RID: 142680 RVA: 0x009706B4 File Offset: 0x0096E8B4
		// (set) Token: 0x06022D59 RID: 142681 RVA: 0x009706C4 File Offset: 0x0096E8C4
		public unsafe int Substep_CountRaw
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroCSCloth_DynamicPin_35Bridge_C.__PropertyOffset_29);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCSCloth_DynamicPin_35Bridge_C.__PropertyOffset_29) = value;
			}
		}

		// Token: 0x06022D5A RID: 142682 RVA: 0x009706D5 File Offset: 0x0096E8D5
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateMaterialParams()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCSCloth_DynamicPin_35Bridge_C.__UpdateMaterialParams_NativeFunctionPtr, null);
		}

		// Token: 0x06022D5B RID: 142683 RVA: 0x009706E9 File Offset: 0x0096E8E9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void StopSim()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCSCloth_DynamicPin_35Bridge_C.__StopSim_NativeFunctionPtr, null);
		}

		// Token: 0x06022D5C RID: 142684 RVA: 0x009706FD File Offset: 0x0096E8FD
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void StartSim()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCSCloth_DynamicPin_35Bridge_C.__StartSim_NativeFunctionPtr, null);
		}

		// Token: 0x06022D5D RID: 142685 RVA: 0x00970711 File Offset: 0x0096E911
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void InitRT()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCSCloth_DynamicPin_35Bridge_C.__InitRT_NativeFunctionPtr, null);
		}

		// Token: 0x06022D5E RID: 142686 RVA: 0x00970725 File Offset: 0x0096E925
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void InitMats()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCSCloth_DynamicPin_35Bridge_C.__InitMats_NativeFunctionPtr, null);
		}

		// Token: 0x06022D5F RID: 142687 RVA: 0x00970739 File Offset: 0x0096E939
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void FitToBridge()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCSCloth_DynamicPin_35Bridge_C.__FitToBridge_NativeFunctionPtr, null);
		}

		// Token: 0x06022D60 RID: 142688 RVA: 0x0097074D File Offset: 0x0096E94D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void DrawDeformPoints()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCSCloth_DynamicPin_35Bridge_C.__DrawDeformPoints_NativeFunctionPtr, null);
		}

		// Token: 0x06022D61 RID: 142689 RVA: 0x00970764 File Offset: 0x0096E964
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SyncPos(USceneComponent From, USceneComponent To)
		{
			BP_KuroCSCloth_DynamicPin_35Bridge_C.__SyncPos_FunctionParams* ptr = stackalloc BP_KuroCSCloth_DynamicPin_35Bridge_C.__SyncPos_FunctionParams[(UIntPtr)215] + 15L / (long)sizeof(BP_KuroCSCloth_DynamicPin_35Bridge_C.__SyncPos_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroCSCloth_DynamicPin_35Bridge_C.__SyncPos_NativeFunctionPtr, (void*)ptr, 1);
			ptr->From = ((From != null) ? From.NativePtr : IntPtr.Zero);
			ptr->To = ((To != null) ? To.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCSCloth_DynamicPin_35Bridge_C.__SyncPos_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06022D62 RID: 142690 RVA: 0x009707D2 File Offset: 0x0096E9D2
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SyncToBindPin()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCSCloth_DynamicPin_35Bridge_C.__SyncToBindPin_NativeFunctionPtr, null);
		}

		// Token: 0x06022D63 RID: 142691 RVA: 0x009707E6 File Offset: 0x0096E9E6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void DrawAndSetPin()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCSCloth_DynamicPin_35Bridge_C.__DrawAndSetPin_NativeFunctionPtr, null);
		}

		// Token: 0x06022D64 RID: 142692 RVA: 0x009707FA File Offset: 0x0096E9FA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCSCloth_DynamicPin_35Bridge_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06022D65 RID: 142693 RVA: 0x0097080E File Offset: 0x0096EA0E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroCSCloth_DynamicPin_35Bridge_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06022D66 RID: 142694 RVA: 0x00970823 File Offset: 0x0096EA23
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCSCloth_DynamicPin_35Bridge_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06022D67 RID: 142695 RVA: 0x00970837 File Offset: 0x0096EA37
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroCSCloth_DynamicPin_35Bridge_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06022D68 RID: 142696 RVA: 0x0097084C File Offset: 0x0096EA4C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_KuroCSCloth_DynamicPin_35Bridge_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_KuroCSCloth_DynamicPin_35Bridge_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_KuroCSCloth_DynamicPin_35Bridge_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroCSCloth_DynamicPin_35Bridge_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCSCloth_DynamicPin_35Bridge_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06022D69 RID: 142697 RVA: 0x00970894 File Offset: 0x0096EA94
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_KuroCSCloth_DynamicPin_35Bridge_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_KuroCSCloth_DynamicPin_35Bridge_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_KuroCSCloth_DynamicPin_35Bridge_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroCSCloth_DynamicPin_35Bridge_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroCSCloth_DynamicPin_35Bridge_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06022D6A RID: 142698 RVA: 0x009708DB File Offset: 0x0096EADB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EditorTick()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCSCloth_DynamicPin_35Bridge_C.__EditorTick_NativeFunctionPtr, null);
		}

		// Token: 0x06022D6B RID: 142699 RVA: 0x009708F0 File Offset: 0x0096EAF0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveEndPlay(EEndPlayReason EndPlayReason)
		{
			BP_KuroCSCloth_DynamicPin_35Bridge_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_KuroCSCloth_DynamicPin_35Bridge_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_KuroCSCloth_DynamicPin_35Bridge_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroCSCloth_DynamicPin_35Bridge_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCSCloth_DynamicPin_35Bridge_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06022D6C RID: 142700 RVA: 0x0097093C File Offset: 0x0096EB3C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveEndPlay_Implementation(EEndPlayReason EndPlayReason)
		{
			BP_KuroCSCloth_DynamicPin_35Bridge_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_KuroCSCloth_DynamicPin_35Bridge_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_KuroCSCloth_DynamicPin_35Bridge_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroCSCloth_DynamicPin_35Bridge_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroCSCloth_DynamicPin_35Bridge_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06022D6D RID: 142701 RVA: 0x00970988 File Offset: 0x0096EB88
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_KuroCSCloth_DynamicPin_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex, bool bFromSweep, in FHitResult SweepResult)
		{
			BP_KuroCSCloth_DynamicPin_35Bridge_C.__BndEvt__BP_KuroCSCloth_DynamicPin_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_KuroCSCloth_DynamicPin_35Bridge_C.__BndEvt__BP_KuroCSCloth_DynamicPin_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(BP_KuroCSCloth_DynamicPin_35Bridge_C.__BndEvt__BP_KuroCSCloth_DynamicPin_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroCSCloth_DynamicPin_35Bridge_C.__BndEvt__BP_KuroCSCloth_DynamicPin_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			ptr->bFromSweep = bFromSweep;
			if (SweepResult != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FHitResult.StaticStruct(), &ptr->SweepResult, SweepResult.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCSCloth_DynamicPin_35Bridge_C.__BndEvt__BP_KuroCSCloth_DynamicPin_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06022D6E RID: 142702 RVA: 0x00970A44 File Offset: 0x0096EC44
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_KuroCSCloth_DynamicPin_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex)
		{
			BP_KuroCSCloth_DynamicPin_35Bridge_C.__BndEvt__BP_KuroCSCloth_DynamicPin_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_KuroCSCloth_DynamicPin_35Bridge_C.__BndEvt__BP_KuroCSCloth_DynamicPin_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_KuroCSCloth_DynamicPin_35Bridge_C.__BndEvt__BP_KuroCSCloth_DynamicPin_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroCSCloth_DynamicPin_35Bridge_C.__BndEvt__BP_KuroCSCloth_DynamicPin_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCSCloth_DynamicPin_35Bridge_C.__BndEvt__BP_KuroCSCloth_DynamicPin_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06022D6F RID: 142703 RVA: 0x00970AD0 File Offset: 0x0096ECD0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_KuroCSCloth_DynamicPin_35Bridge(int EntryPoint)
		{
			BP_KuroCSCloth_DynamicPin_35Bridge_C.__ExecuteUbergraph_BP_KuroCSCloth_DynamicPin_35Bridge_FunctionParams* ptr = stackalloc BP_KuroCSCloth_DynamicPin_35Bridge_C.__ExecuteUbergraph_BP_KuroCSCloth_DynamicPin_35Bridge_FunctionParams[(UIntPtr)1567] + 15L / (long)sizeof(BP_KuroCSCloth_DynamicPin_35Bridge_C.__ExecuteUbergraph_BP_KuroCSCloth_DynamicPin_35Bridge_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroCSCloth_DynamicPin_35Bridge_C.__ExecuteUbergraph_BP_KuroCSCloth_DynamicPin_35Bridge_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroCSCloth_DynamicPin_35Bridge_C.__ExecuteUbergraph_BP_KuroCSCloth_DynamicPin_35Bridge_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06022D70 RID: 142704 RVA: 0x00970B1A File Offset: 0x0096ED1A
		protected BP_KuroCSCloth_DynamicPin_35Bridge_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04011AB7 RID: 72375
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/KuroCS/ClothDynamicPin/BP_KuroCSCloth_DynamicPin_35Bridge.BP_KuroCSCloth_DynamicPin_35Bridge_C";

		// Token: 0x04011AB8 RID: 72376
		private static IntPtr _ClassPtr;

		// Token: 0x04011AB9 RID: 72377
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04011ABA RID: 72378
		internal static int __PropertyOffset_0;

		// Token: 0x04011ABB RID: 72379
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04011ABC RID: 72380
		internal static int __PropertyOffset_1;

		// Token: 0x04011ABD RID: 72381
		internal static int __PropertyOffset_2;

		// Token: 0x04011ABE RID: 72382
		internal static int __PropertyOffset_3;

		// Token: 0x04011ABF RID: 72383
		internal static int __PropertyOffset_4;

		// Token: 0x04011AC0 RID: 72384
		internal static int __PropertyOffset_5;

		// Token: 0x04011AC1 RID: 72385
		internal static int __PropertyOffset_6;

		// Token: 0x04011AC2 RID: 72386
		internal static int __PropertyOffset_7;

		// Token: 0x04011AC3 RID: 72387
		internal static int __PropertyOffset_8;

		// Token: 0x04011AC4 RID: 72388
		internal static int __PropertyOffset_9;

		// Token: 0x04011AC5 RID: 72389
		internal static int __PropertyOffset_10;

		// Token: 0x04011AC6 RID: 72390
		internal static int __PropertyOffset_11;

		// Token: 0x04011AC7 RID: 72391
		internal static int __PropertyOffset_12;

		// Token: 0x04011AC8 RID: 72392
		internal static int __PropertyOffset_13;

		// Token: 0x04011AC9 RID: 72393
		internal static int __PropertyOffset_14;

		// Token: 0x04011ACA RID: 72394
		internal static int __PropertyOffset_15;

		// Token: 0x04011ACB RID: 72395
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UMaterialInstanceDynamic> _Mats;

		// Token: 0x04011ACC RID: 72396
		internal static int __PropertyOffset_16;

		// Token: 0x04011ACD RID: 72397
		internal static int __PropertyOffset_17;

		// Token: 0x04011ACE RID: 72398
		internal static int __PropertyOffset_18;

		// Token: 0x04011ACF RID: 72399
		internal static int __PropertyOffset_19;

		// Token: 0x04011AD0 RID: 72400
		internal static int __PropertyOffset_20;

		// Token: 0x04011AD1 RID: 72401
		internal static int __PropertyOffset_21;

		// Token: 0x04011AD2 RID: 72402
		internal static int __PropertyOffset_22;

		// Token: 0x04011AD3 RID: 72403
		internal static int __PropertyOffset_23;

		// Token: 0x04011AD4 RID: 72404
		internal static int __PropertyOffset_24;

		// Token: 0x04011AD5 RID: 72405
		internal static int __PropertyOffset_25;

		// Token: 0x04011AD6 RID: 72406
		private TMap<FName, float> _Scalar_Parameters;

		// Token: 0x04011AD7 RID: 72407
		internal static int __PropertyOffset_26;

		// Token: 0x04011AD8 RID: 72408
		private TMap<FName, FLinearColor> _Vector_Parameters;

		// Token: 0x04011AD9 RID: 72409
		internal static int __PropertyOffset_27;

		// Token: 0x04011ADA RID: 72410
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<FName, UTexture> _Texture_Parameters;

		// Token: 0x04011ADB RID: 72411
		internal static int __PropertyOffset_28;

		// Token: 0x04011ADC RID: 72412
		internal static int __PropertyOffset_29;

		// Token: 0x04011ADD RID: 72413
		private static IntPtr __UpdateMaterialParams_NativeFunctionPtr;

		// Token: 0x04011ADE RID: 72414
		private static IntPtr __StopSim_NativeFunctionPtr;

		// Token: 0x04011ADF RID: 72415
		private static IntPtr __StartSim_NativeFunctionPtr;

		// Token: 0x04011AE0 RID: 72416
		private static IntPtr __InitRT_NativeFunctionPtr;

		// Token: 0x04011AE1 RID: 72417
		private static IntPtr __InitMats_NativeFunctionPtr;

		// Token: 0x04011AE2 RID: 72418
		private static IntPtr __FitToBridge_NativeFunctionPtr;

		// Token: 0x04011AE3 RID: 72419
		private static IntPtr __DrawDeformPoints_NativeFunctionPtr;

		// Token: 0x04011AE4 RID: 72420
		private static IntPtr __SyncPos_NativeFunctionPtr;

		// Token: 0x04011AE5 RID: 72421
		private static IntPtr __SyncToBindPin_NativeFunctionPtr;

		// Token: 0x04011AE6 RID: 72422
		private static IntPtr __DrawAndSetPin_NativeFunctionPtr;

		// Token: 0x04011AE7 RID: 72423
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04011AE8 RID: 72424
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04011AE9 RID: 72425
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04011AEA RID: 72426
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x04011AEB RID: 72427
		private static IntPtr __ReceiveEndPlay_NativeFunctionPtr;

		// Token: 0x04011AEC RID: 72428
		private static IntPtr __BndEvt__BP_KuroCSCloth_DynamicPin_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04011AED RID: 72429
		private static IntPtr __BndEvt__BP_KuroCSCloth_DynamicPin_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04011AEE RID: 72430
		private static IntPtr __ExecuteUbergraph_BP_KuroCSCloth_DynamicPin_35Bridge_NativeFunctionPtr;

		// Token: 0x02009C32 RID: 39986
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 200)]
		protected ref struct __SyncPos_FunctionParams
		{
			// Token: 0x040324BC RID: 206012
			[FieldOffset(0)]
			public IntPtr From;

			// Token: 0x040324BD RID: 206013
			[FieldOffset(8)]
			public IntPtr To;
		}

		// Token: 0x02009C33 RID: 39987
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x040324BE RID: 206014
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009C34 RID: 39988
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __ReceiveEndPlay_FunctionParams
		{
			// Token: 0x040324BF RID: 206015
			[FieldOffset(0)]
			public TEnumAsByte<EEndPlayReason> EndPlayReason;
		}

		// Token: 0x02009C35 RID: 39989
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __BndEvt__BP_KuroCSCloth_DynamicPin_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x040324C0 RID: 206016
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x040324C1 RID: 206017
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x040324C2 RID: 206018
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x040324C3 RID: 206019
			[FieldOffset(24)]
			public int OtherBodyIndex;

			// Token: 0x040324C4 RID: 206020
			[FieldOffset(28)]
			public bool bFromSweep;

			// Token: 0x040324C5 RID: 206021
			[FieldOffset(32)]
			public byte SweepResult;
		}

		// Token: 0x02009C36 RID: 39990
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __BndEvt__BP_KuroCSCloth_DynamicPin_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x040324C6 RID: 206022
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x040324C7 RID: 206023
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x040324C8 RID: 206024
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x040324C9 RID: 206025
			[FieldOffset(24)]
			public int OtherBodyIndex;
		}

		// Token: 0x02009C37 RID: 39991
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1552)]
		protected ref struct __ExecuteUbergraph_BP_KuroCSCloth_DynamicPin_35Bridge_FunctionParams
		{
			// Token: 0x040324CA RID: 206026
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
