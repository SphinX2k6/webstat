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
	// Token: 0x02003CF5 RID: 15605
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/FluidNinjaLive/NinjaLive.NinjaLive_C")]
	[UnrealStructLayout(1928, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1928)]
	public class NinjaLive_C : AUKuroCustomCookActor, IUnrealUObject, IUnrealObject, INinjaLiveInterface_C, IUnrealBlueprintInterface, IUnrealInterface
	{
		// Token: 0x0602577D RID: 153469 RVA: 0x009BA66B File Offset: 0x009B886B
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (NinjaLive_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/FluidNinjaLive/NinjaLive.NinjaLive_C");
			}
			return NinjaLive_C._ClassPtr;
		}

		// Token: 0x0602577E RID: 153470 RVA: 0x009BA690 File Offset: 0x009B8890
		public NinjaLive_C() : this(BuiltinUtils.AllocNativeUObject(NinjaLive_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602577F RID: 153471 RVA: 0x009BA6B8 File Offset: 0x009B88B8
		[NullableContext(1)]
		public NinjaLive_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(NinjaLive_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170051FB RID: 20987
		// (get) Token: 0x06025780 RID: 153472 RVA: 0x009BA6EC File Offset: 0x009B88EC
		// (set) Token: 0x06025781 RID: 153473 RVA: 0x009BA725 File Offset: 0x009B8925
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)NinjaLive_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)NinjaLive_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170051FC RID: 20988
		// (get) Token: 0x06025782 RID: 153474 RVA: 0x009BA746 File Offset: 0x009B8946
		// (set) Token: 0x06025783 RID: 153475 RVA: 0x009BA75A File Offset: 0x009B895A
		public unsafe NinjaLiveComponent_C NinjaLiveComponent
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<NinjaLiveComponent_C>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLive_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLive_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170051FD RID: 20989
		// (get) Token: 0x06025784 RID: 153476 RVA: 0x009BA76F File Offset: 0x009B896F
		// (set) Token: 0x06025785 RID: 153477 RVA: 0x009BA783 File Offset: 0x009B8983
		public unsafe UBoxComponent InteractionVolume
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLive_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLive_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170051FE RID: 20990
		// (get) Token: 0x06025786 RID: 153478 RVA: 0x009BA798 File Offset: 0x009B8998
		// (set) Token: 0x06025787 RID: 153479 RVA: 0x009BA7AC File Offset: 0x009B89AC
		public unsafe UBoxComponent ActivationVolume
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLive_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLive_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x170051FF RID: 20991
		// (get) Token: 0x06025788 RID: 153480 RVA: 0x009BA7C1 File Offset: 0x009B89C1
		// (set) Token: 0x06025789 RID: 153481 RVA: 0x009BA7D5 File Offset: 0x009B89D5
		public unsafe UMaterialBillboardComponent EditorIcon
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialBillboardComponent>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLive_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLive_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17005200 RID: 20992
		// (get) Token: 0x0602578A RID: 153482 RVA: 0x009BA7EA File Offset: 0x009B89EA
		// (set) Token: 0x0602578B RID: 153483 RVA: 0x009BA7FE File Offset: 0x009B89FE
		public unsafe UStaticMeshComponent TraceMesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLive_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLive_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17005201 RID: 20993
		// (get) Token: 0x0602578C RID: 153484 RVA: 0x009BA813 File Offset: 0x009B8A13
		// (set) Token: 0x0602578D RID: 153485 RVA: 0x009BA827 File Offset: 0x009B8A27
		public unsafe USceneComponent Root
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLive_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLive_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x17005202 RID: 20994
		// (get) Token: 0x0602578E RID: 153486 RVA: 0x009BA83C File Offset: 0x009B8A3C
		// (set) Token: 0x0602578F RID: 153487 RVA: 0x009BA850 File Offset: 0x009B8A50
		public unsafe UTextureRenderTarget2D RT_DensityPreview
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLive_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLive_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x17005203 RID: 20995
		// (get) Token: 0x06025790 RID: 153488 RVA: 0x009BA865 File Offset: 0x009B8A65
		// (set) Token: 0x06025791 RID: 153489 RVA: 0x009BA879 File Offset: 0x009B8A79
		public unsafe UMaterialInstance InactiveGrayMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLive_C.__PropertyOffset_8);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLive_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x17005204 RID: 20996
		// (get) Token: 0x06025792 RID: 153490 RVA: 0x009BA88E File Offset: 0x009B8A8E
		// (set) Token: 0x06025793 RID: 153491 RVA: 0x009BA89E File Offset: 0x009B8A9E
		public unsafe bool DisableBlueprint
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLive_C.__PropertyOffset_9) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLive_C.__PropertyOffset_9) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005205 RID: 20997
		// (get) Token: 0x06025794 RID: 153492 RVA: 0x009BA8AF File Offset: 0x009B8AAF
		// (set) Token: 0x06025795 RID: 153493 RVA: 0x009BA8BF File Offset: 0x009B8ABF
		public unsafe float TimeCounterForBrush
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLive_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLive_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17005206 RID: 20998
		// (get) Token: 0x06025796 RID: 153494 RVA: 0x009BA8D0 File Offset: 0x009B8AD0
		// (set) Token: 0x06025797 RID: 153495 RVA: 0x009BA8E0 File Offset: 0x009B8AE0
		public unsafe float DeltaSeconds
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLive_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLive_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17005207 RID: 20999
		// (get) Token: 0x06025798 RID: 153496 RVA: 0x009BA8F1 File Offset: 0x009B8AF1
		// (set) Token: 0x06025799 RID: 153497 RVA: 0x009BA901 File Offset: 0x009B8B01
		public unsafe bool MousePressed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLive_C.__PropertyOffset_12) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLive_C.__PropertyOffset_12) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005208 RID: 21000
		// (get) Token: 0x0602579A RID: 153498 RVA: 0x009BA912 File Offset: 0x009B8B12
		// (set) Token: 0x0602579B RID: 153499 RVA: 0x009BA922 File Offset: 0x009B8B22
		public unsafe bool ShowTraceMeshInEditor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLive_C.__PropertyOffset_13) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLive_C.__PropertyOffset_13) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005209 RID: 21001
		// (get) Token: 0x0602579C RID: 153500 RVA: 0x009BA933 File Offset: 0x009B8B33
		// (set) Token: 0x0602579D RID: 153501 RVA: 0x009BA947 File Offset: 0x009B8B47
		public unsafe FVector TraceMeshSize
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLive_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLive_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x1700520A RID: 21002
		// (get) Token: 0x0602579E RID: 153502 RVA: 0x009BA95C File Offset: 0x009B8B5C
		// (set) Token: 0x0602579F RID: 153503 RVA: 0x009BA970 File Offset: 0x009B8B70
		[Nullable(0)]
		public unsafe TEnumAsByte<UserInput_Enum> UserInputBasedInteraction
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLive_C.__PropertyOffset_15);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLive_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x1700520B RID: 21003
		// (get) Token: 0x060257A0 RID: 153504 RVA: 0x009BA985 File Offset: 0x009B8B85
		// (set) Token: 0x060257A1 RID: 153505 RVA: 0x009BA995 File Offset: 0x009B8B95
		public unsafe bool OverlapBasedInteraction
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLive_C.__PropertyOffset_16) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLive_C.__PropertyOffset_16) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700520C RID: 21004
		// (get) Token: 0x060257A2 RID: 153506 RVA: 0x009BA9A8 File Offset: 0x009B8BA8
		// (set) Token: 0x060257A3 RID: 153507 RVA: 0x009BA9E1 File Offset: 0x009B8BE1
		[Nullable(1)]
		public TArray<NinjaLive_C> NinjaLIVECollisionExclude
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<NinjaLive_C> result;
				if ((result = this._NinjaLIVECollisionExclude) == null)
				{
					result = (this._NinjaLIVECollisionExclude = new TArray<NinjaLive_C>(base.NativePtr + (IntPtr)NinjaLive_C.__PropertyOffset_17, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.NinjaLIVECollisionExclude.CopyAssign(value);
			}
		}

		// Token: 0x1700520D RID: 21005
		// (get) Token: 0x060257A4 RID: 153508 RVA: 0x009BA9EF File Offset: 0x009B8BEF
		// (set) Token: 0x060257A5 RID: 153509 RVA: 0x009BA9FF File Offset: 0x009B8BFF
		public unsafe float Time
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLive_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLive_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x1700520E RID: 21006
		// (get) Token: 0x060257A6 RID: 153510 RVA: 0x009BAA10 File Offset: 0x009B8C10
		// (set) Token: 0x060257A7 RID: 153511 RVA: 0x009BAA20 File Offset: 0x009B8C20
		public unsafe bool SimActivatedByPawnProximity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLive_C.__PropertyOffset_19) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLive_C.__PropertyOffset_19) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700520F RID: 21007
		// (get) Token: 0x060257A8 RID: 153512 RVA: 0x009BAA31 File Offset: 0x009B8C31
		// (set) Token: 0x060257A9 RID: 153513 RVA: 0x009BAA41 File Offset: 0x009B8C41
		public unsafe bool ShowActivationVolumeInEditor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLive_C.__PropertyOffset_20) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLive_C.__PropertyOffset_20) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005210 RID: 21008
		// (get) Token: 0x060257AA RID: 153514 RVA: 0x009BAA52 File Offset: 0x009B8C52
		// (set) Token: 0x060257AB RID: 153515 RVA: 0x009BAA66 File Offset: 0x009B8C66
		public unsafe FVector ActivationVolumeSize
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLive_C.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLive_C.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x17005211 RID: 21009
		// (get) Token: 0x060257AC RID: 153516 RVA: 0x009BAA7B File Offset: 0x009B8C7B
		// (set) Token: 0x060257AD RID: 153517 RVA: 0x009BAA8B File Offset: 0x009B8C8B
		public unsafe float ActivatorProximityCheckFrequency
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLive_C.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLive_C.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x17005212 RID: 21010
		// (get) Token: 0x060257AE RID: 153518 RVA: 0x009BAA9C File Offset: 0x009B8C9C
		// (set) Token: 0x060257AF RID: 153519 RVA: 0x009BAAB0 File Offset: 0x009B8CB0
		[Nullable(0)]
		public unsafe TEnumAsByte<ECollisionChannel> ActivatorType
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLive_C.__PropertyOffset_23);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLive_C.__PropertyOffset_23) = value;
			}
		}

		// Token: 0x17005213 RID: 21011
		// (get) Token: 0x060257B0 RID: 153520 RVA: 0x009BAAC5 File Offset: 0x009B8CC5
		// (set) Token: 0x060257B1 RID: 153521 RVA: 0x009BAAD9 File Offset: 0x009B8CD9
		public unsafe AActor Activator
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLive_C.__PropertyOffset_24);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLive_C.__PropertyOffset_24, value);
			}
		}

		// Token: 0x17005214 RID: 21012
		// (get) Token: 0x060257B2 RID: 153522 RVA: 0x009BAAEE File Offset: 0x009B8CEE
		// (set) Token: 0x060257B3 RID: 153523 RVA: 0x009BAAFE File Offset: 0x009B8CFE
		public unsafe bool PawnInsideActivationBounds
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLive_C.__PropertyOffset_25) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLive_C.__PropertyOffset_25) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005215 RID: 21013
		// (get) Token: 0x060257B4 RID: 153524 RVA: 0x009BAB0F File Offset: 0x009B8D0F
		// (set) Token: 0x060257B5 RID: 153525 RVA: 0x009BAB1F File Offset: 0x009B8D1F
		public unsafe bool InitDone
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLive_C.__PropertyOffset_26) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLive_C.__PropertyOffset_26) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005216 RID: 21014
		// (get) Token: 0x060257B6 RID: 153526 RVA: 0x009BAB30 File Offset: 0x009B8D30
		// (set) Token: 0x060257B7 RID: 153527 RVA: 0x009BAB40 File Offset: 0x009B8D40
		public unsafe bool BeginPlaySupressed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLive_C.__PropertyOffset_27) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLive_C.__PropertyOffset_27) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005217 RID: 21015
		// (get) Token: 0x060257B8 RID: 153528 RVA: 0x009BAB51 File Offset: 0x009B8D51
		// (set) Token: 0x060257B9 RID: 153529 RVA: 0x009BAB61 File Offset: 0x009B8D61
		public unsafe bool UseTraceMeshAsInteractionVolume
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLive_C.__PropertyOffset_28) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLive_C.__PropertyOffset_28) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005218 RID: 21016
		// (get) Token: 0x060257BA RID: 153530 RVA: 0x009BAB72 File Offset: 0x009B8D72
		// (set) Token: 0x060257BB RID: 153531 RVA: 0x009BAB82 File Offset: 0x009B8D82
		public unsafe bool ShowInteractionVolumeInEditor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLive_C.__PropertyOffset_29) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLive_C.__PropertyOffset_29) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005219 RID: 21017
		// (get) Token: 0x060257BC RID: 153532 RVA: 0x009BAB93 File Offset: 0x009B8D93
		// (set) Token: 0x060257BD RID: 153533 RVA: 0x009BABA7 File Offset: 0x009B8DA7
		public unsafe FVector InteractionVolumeSize
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLive_C.__PropertyOffset_30);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLive_C.__PropertyOffset_30) = value;
			}
		}

		// Token: 0x1700521A RID: 21018
		// (get) Token: 0x060257BE RID: 153534 RVA: 0x009BABBC File Offset: 0x009B8DBC
		// (set) Token: 0x060257BF RID: 153535 RVA: 0x009BABF5 File Offset: 0x009B8DF5
		[Nullable(1)]
		public TArray<bool> MultipleTouchLookup
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<bool> result;
				if ((result = this._MultipleTouchLookup) == null)
				{
					result = (this._MultipleTouchLookup = new TArray<bool>(base.NativePtr + (IntPtr)NinjaLive_C.__PropertyOffset_31, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.MultipleTouchLookup.CopyAssign(value);
			}
		}

		// Token: 0x1700521B RID: 21019
		// (get) Token: 0x060257C0 RID: 153536 RVA: 0x009BAC03 File Offset: 0x009B8E03
		// (set) Token: 0x060257C1 RID: 153537 RVA: 0x009BAC13 File Offset: 0x009B8E13
		public unsafe float TickRateCustom
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLive_C.__PropertyOffset_32);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLive_C.__PropertyOffset_32) = value;
			}
		}

		// Token: 0x1700521C RID: 21020
		// (get) Token: 0x060257C2 RID: 153538 RVA: 0x009BAC24 File Offset: 0x009B8E24
		// (set) Token: 0x060257C3 RID: 153539 RVA: 0x009BAC38 File Offset: 0x009B8E38
		public unsafe UPrimitiveComponent InteractionVolumeTemplate
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UPrimitiveComponent>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLive_C.__PropertyOffset_33);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLive_C.__PropertyOffset_33, value);
			}
		}

		// Token: 0x1700521D RID: 21021
		// (get) Token: 0x060257C4 RID: 153540 RVA: 0x009BAC4D File Offset: 0x009B8E4D
		// (set) Token: 0x060257C5 RID: 153541 RVA: 0x009BAC61 File Offset: 0x009B8E61
		public unsafe FName TrackActorPrimitiveComponentsWithTag
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLive_C.__PropertyOffset_34);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLive_C.__PropertyOffset_34) = value;
			}
		}

		// Token: 0x1700521E RID: 21022
		// (get) Token: 0x060257C6 RID: 153542 RVA: 0x009BAC76 File Offset: 0x009B8E76
		// (set) Token: 0x060257C7 RID: 153543 RVA: 0x009BAC8A File Offset: 0x009B8E8A
		public unsafe FName TrackActorSkeletalMeshComponentsWithTag
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLive_C.__PropertyOffset_35);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLive_C.__PropertyOffset_35) = value;
			}
		}

		// Token: 0x1700521F RID: 21023
		// (get) Token: 0x060257C8 RID: 153544 RVA: 0x009BACA0 File Offset: 0x009B8EA0
		// (set) Token: 0x060257C9 RID: 153545 RVA: 0x009BACD9 File Offset: 0x009B8ED9
		[Nullable(new byte[]
		{
			1,
			0
		})]
		public TArray<TEnumAsByte<EObjectTypeQuery>> OverlapFilterInclusiveObjType
		{
			[return: Nullable(new byte[]
			{
				1,
				0
			})]
			get
			{
				base.FastCheckIsValid();
				TArray<TEnumAsByte<EObjectTypeQuery>> result;
				if ((result = this._OverlapFilterInclusiveObjType) == null)
				{
					result = (this._OverlapFilterInclusiveObjType = new TArray<TEnumAsByte<EObjectTypeQuery>>(base.NativePtr + (IntPtr)NinjaLive_C.__PropertyOffset_36, this));
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
				this.OverlapFilterInclusiveObjType.CopyAssign(value);
			}
		}

		// Token: 0x17005220 RID: 21024
		// (get) Token: 0x060257CA RID: 153546 RVA: 0x009BACE8 File Offset: 0x009B8EE8
		// (set) Token: 0x060257CB RID: 153547 RVA: 0x009BAD21 File Offset: 0x009B8F21
		[Nullable(1)]
		public TArray<FName> OverlapFilterInclusiveBoneNameExact
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<FName> result;
				if ((result = this._OverlapFilterInclusiveBoneNameExact) == null)
				{
					result = (this._OverlapFilterInclusiveBoneNameExact = new TArray<FName>(base.NativePtr + (IntPtr)NinjaLive_C.__PropertyOffset_37, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.OverlapFilterInclusiveBoneNameExact.CopyAssign(value);
			}
		}

		// Token: 0x17005221 RID: 21025
		// (get) Token: 0x060257CC RID: 153548 RVA: 0x009BAD30 File Offset: 0x009B8F30
		// (set) Token: 0x060257CD RID: 153549 RVA: 0x009BAD69 File Offset: 0x009B8F69
		[Nullable(1)]
		public TArray<string> OverlapFilterInclusiveBoneNamePartial
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<string> result;
				if ((result = this._OverlapFilterInclusiveBoneNamePartial) == null)
				{
					result = (this._OverlapFilterInclusiveBoneNamePartial = new TArray<string>(base.NativePtr + (IntPtr)NinjaLive_C.__PropertyOffset_38, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.OverlapFilterInclusiveBoneNamePartial.CopyAssign(value);
			}
		}

		// Token: 0x17005222 RID: 21026
		// (get) Token: 0x060257CE RID: 153550 RVA: 0x009BAD78 File Offset: 0x009B8F78
		// (set) Token: 0x060257CF RID: 153551 RVA: 0x009BADB1 File Offset: 0x009B8FB1
		[Nullable(1)]
		public TArray<AActor> ExcludeSpecificActorsFromOverlap
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<AActor> result;
				if ((result = this._ExcludeSpecificActorsFromOverlap) == null)
				{
					result = (this._ExcludeSpecificActorsFromOverlap = new TArray<AActor>(base.NativePtr + (IntPtr)NinjaLive_C.__PropertyOffset_39, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.ExcludeSpecificActorsFromOverlap.CopyAssign(value);
			}
		}

		// Token: 0x17005223 RID: 21027
		// (get) Token: 0x060257D0 RID: 153552 RVA: 0x009BADBF File Offset: 0x009B8FBF
		// (set) Token: 0x060257D1 RID: 153553 RVA: 0x009BADCF File Offset: 0x009B8FCF
		public unsafe bool AutoExcludeLargeOverlappingObjects
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLive_C.__PropertyOffset_40) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLive_C.__PropertyOffset_40) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005224 RID: 21028
		// (get) Token: 0x060257D2 RID: 153554 RVA: 0x009BADE0 File Offset: 0x009B8FE0
		// (set) Token: 0x060257D3 RID: 153555 RVA: 0x009BAE19 File Offset: 0x009B9019
		[Nullable(new byte[]
		{
			1,
			0,
			0
		})]
		public TMap<TEnumAsByte<ECollisionChannel>, TEnumAsByte<EObjectTypeQuery>> OverlapFilterInclusiveCollisionType
		{
			[return: Nullable(new byte[]
			{
				1,
				0,
				0
			})]
			get
			{
				base.FastCheckIsValid();
				TMap<TEnumAsByte<ECollisionChannel>, TEnumAsByte<EObjectTypeQuery>> result;
				if ((result = this._OverlapFilterInclusiveCollisionType) == null)
				{
					result = (this._OverlapFilterInclusiveCollisionType = new TMap<TEnumAsByte<ECollisionChannel>, TEnumAsByte<EObjectTypeQuery>>(base.NativePtr + (IntPtr)NinjaLive_C.__PropertyOffset_41, this));
				}
				return result;
			}
			[param: Nullable(new byte[]
			{
				1,
				0,
				0
			})]
			set
			{
				this.OverlapFilterInclusiveCollisionType.CopyAssign(value);
			}
		}

		// Token: 0x17005225 RID: 21029
		// (get) Token: 0x060257D4 RID: 153556 RVA: 0x009BAE27 File Offset: 0x009B9027
		// (set) Token: 0x060257D5 RID: 153557 RVA: 0x009BAE3B File Offset: 0x009B903B
		[Nullable(0)]
		public unsafe TEnumAsByte<InactiveBehaviour_Enum> TraceMeshInactiveBehaviour
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLive_C.__PropertyOffset_42);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLive_C.__PropertyOffset_42) = value;
			}
		}

		// Token: 0x17005226 RID: 21030
		// (get) Token: 0x060257D6 RID: 153558 RVA: 0x009BAE50 File Offset: 0x009B9050
		// (set) Token: 0x060257D7 RID: 153559 RVA: 0x009BAE60 File Offset: 0x009B9060
		public unsafe bool ActivationEventsDebugPrint
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLive_C.__PropertyOffset_43) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLive_C.__PropertyOffset_43) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005227 RID: 21031
		// (get) Token: 0x060257D8 RID: 153560 RVA: 0x009BAE71 File Offset: 0x009B9071
		// (set) Token: 0x060257D9 RID: 153561 RVA: 0x009BAE81 File Offset: 0x009B9081
		public unsafe bool SimContainerCapacityWarning
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLive_C.__PropertyOffset_44) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLive_C.__PropertyOffset_44) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005228 RID: 21032
		// (get) Token: 0x060257DA RID: 153562 RVA: 0x009BAE92 File Offset: 0x009B9092
		// (set) Token: 0x060257DB RID: 153563 RVA: 0x009BAEA2 File Offset: 0x009B90A2
		public unsafe bool SaveDebugTextToLog
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLive_C.__PropertyOffset_45) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLive_C.__PropertyOffset_45) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005229 RID: 21033
		// (get) Token: 0x060257DC RID: 153564 RVA: 0x009BAEB3 File Offset: 0x009B90B3
		// (set) Token: 0x060257DD RID: 153565 RVA: 0x009BAEC3 File Offset: 0x009B90C3
		public unsafe float DebugTextLifeTimeLength
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLive_C.__PropertyOffset_46);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLive_C.__PropertyOffset_46) = value;
			}
		}

		// Token: 0x1700522A RID: 21034
		// (get) Token: 0x060257DE RID: 153566 RVA: 0x009BAED4 File Offset: 0x009B90D4
		// (set) Token: 0x060257DF RID: 153567 RVA: 0x009BAEE8 File Offset: 0x009B90E8
		public unsafe UPrimitiveComponent OverlappingSkeletalMesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UPrimitiveComponent>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLive_C.__PropertyOffset_47);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLive_C.__PropertyOffset_47, value);
			}
		}

		// Token: 0x1700522B RID: 21035
		// (get) Token: 0x060257E0 RID: 153568 RVA: 0x009BAEFD File Offset: 0x009B90FD
		// (set) Token: 0x060257E1 RID: 153569 RVA: 0x009BAF0D File Offset: 0x009B910D
		public unsafe float BrushStrengthTemp2
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLive_C.__PropertyOffset_48);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLive_C.__PropertyOffset_48) = value;
			}
		}

		// Token: 0x1700522C RID: 21036
		// (get) Token: 0x060257E2 RID: 153570 RVA: 0x009BAF1E File Offset: 0x009B911E
		// (set) Token: 0x060257E3 RID: 153571 RVA: 0x009BAF2E File Offset: 0x009B912E
		public unsafe float InputFeedbackTemp1
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLive_C.__PropertyOffset_49);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLive_C.__PropertyOffset_49) = value;
			}
		}

		// Token: 0x1700522D RID: 21037
		// (get) Token: 0x060257E4 RID: 153572 RVA: 0x009BAF3F File Offset: 0x009B913F
		// (set) Token: 0x060257E5 RID: 153573 RVA: 0x009BAF4F File Offset: 0x009B914F
		public unsafe bool DisableAndNotTickBlock
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLive_C.__PropertyOffset_50) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLive_C.__PropertyOffset_50) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700522E RID: 21038
		// (get) Token: 0x060257E6 RID: 153574 RVA: 0x009BAF60 File Offset: 0x009B9160
		// (set) Token: 0x060257E7 RID: 153575 RVA: 0x009BAF99 File Offset: 0x009B9199
		[Nullable(1)]
		public TArray<UPrimitiveComponent> OverlappingComponents
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<UPrimitiveComponent> result;
				if ((result = this._OverlappingComponents) == null)
				{
					result = (this._OverlappingComponents = new TArray<UPrimitiveComponent>(base.NativePtr + (IntPtr)NinjaLive_C.__PropertyOffset_51, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.OverlappingComponents.CopyAssign(value);
			}
		}

		// Token: 0x1700522F RID: 21039
		// (get) Token: 0x060257E8 RID: 153576 RVA: 0x009BAFA8 File Offset: 0x009B91A8
		// (set) Token: 0x060257E9 RID: 153577 RVA: 0x009BAFE1 File Offset: 0x009B91E1
		[Nullable(1)]
		public TArray<AActor> OverlappingActors
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<AActor> result;
				if ((result = this._OverlappingActors) == null)
				{
					result = (this._OverlappingActors = new TArray<AActor>(base.NativePtr + (IntPtr)NinjaLive_C.__PropertyOffset_52, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.OverlappingActors.CopyAssign(value);
			}
		}

		// Token: 0x17005230 RID: 21040
		// (get) Token: 0x060257EA RID: 153578 RVA: 0x009BAFF0 File Offset: 0x009B91F0
		// (set) Token: 0x060257EB RID: 153579 RVA: 0x009BB029 File Offset: 0x009B9229
		[Nullable(1)]
		public TMap<int, UPrimitiveComponent> SkeletalMesh_TempArray_Pairs
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TMap<int, UPrimitiveComponent> result;
				if ((result = this._SkeletalMesh_TempArray_Pairs) == null)
				{
					result = (this._SkeletalMesh_TempArray_Pairs = new TMap<int, UPrimitiveComponent>(base.NativePtr + (IntPtr)NinjaLive_C.__PropertyOffset_53, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.SkeletalMesh_TempArray_Pairs.CopyAssign(value);
			}
		}

		// Token: 0x17005231 RID: 21041
		// (get) Token: 0x060257EC RID: 153580 RVA: 0x009BB038 File Offset: 0x009B9238
		// (set) Token: 0x060257ED RID: 153581 RVA: 0x009BB071 File Offset: 0x009B9271
		[Nullable(1)]
		public TArray<AActor> OverlappingActorsInitial
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<AActor> result;
				if ((result = this._OverlappingActorsInitial) == null)
				{
					result = (this._OverlappingActorsInitial = new TArray<AActor>(base.NativePtr + (IntPtr)NinjaLive_C.__PropertyOffset_54, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.OverlappingActorsInitial.CopyAssign(value);
			}
		}

		// Token: 0x17005232 RID: 21042
		// (get) Token: 0x060257EE RID: 153582 RVA: 0x009BB080 File Offset: 0x009B9280
		// (set) Token: 0x060257EF RID: 153583 RVA: 0x009BB0B9 File Offset: 0x009B92B9
		[Nullable(1)]
		public OwnerRePlayEvent OwnerRePlayEvent
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				OwnerRePlayEvent result;
				if ((result = this._OwnerRePlayEvent) == null)
				{
					result = (this._OwnerRePlayEvent = new OwnerRePlayEvent(base.NativePtr + (IntPtr)NinjaLive_C.__PropertyOffset_55, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				FMulticastScriptDelegate.NativeCopy(base.NativePtr + (IntPtr)NinjaLive_C.__PropertyOffset_55, (value != null) ? value.NativePtr : ((IntPtr)0));
			}
		}

		// Token: 0x17005233 RID: 21043
		// (get) Token: 0x060257F0 RID: 153584 RVA: 0x009BB0DA File Offset: 0x009B92DA
		// (set) Token: 0x060257F1 RID: 153585 RVA: 0x009BB0EA File Offset: 0x009B92EA
		public unsafe bool OverrideComponentVariables
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLive_C.__PropertyOffset_56) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLive_C.__PropertyOffset_56) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005234 RID: 21044
		// (get) Token: 0x060257F2 RID: 153586 RVA: 0x009BB0FB File Offset: 0x009B92FB
		// (set) Token: 0x060257F3 RID: 153587 RVA: 0x009BB10B File Offset: 0x009B930B
		public unsafe bool AutoConnectToMemoryPool_IF_Found
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLive_C.__PropertyOffset_57) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLive_C.__PropertyOffset_57) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005235 RID: 21045
		// (get) Token: 0x060257F4 RID: 153588 RVA: 0x009BB11C File Offset: 0x009B931C
		// (set) Token: 0x060257F5 RID: 153589 RVA: 0x009BB12C File Offset: 0x009B932C
		public unsafe int OutputFilterMaterialIndex
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLive_C.__PropertyOffset_58);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLive_C.__PropertyOffset_58) = value;
			}
		}

		// Token: 0x17005236 RID: 21046
		// (get) Token: 0x060257F6 RID: 153590 RVA: 0x009BB13D File Offset: 0x009B933D
		// (set) Token: 0x060257F7 RID: 153591 RVA: 0x009BB14D File Offset: 0x009B934D
		public unsafe bool ShowLODdebugMessagesOnScreen
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLive_C.__PropertyOffset_59) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLive_C.__PropertyOffset_59) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005237 RID: 21047
		// (get) Token: 0x060257F8 RID: 153592 RVA: 0x009BB15E File Offset: 0x009B935E
		// (set) Token: 0x060257F9 RID: 153593 RVA: 0x009BB16E File Offset: 0x009B936E
		public unsafe float GlobalBrushScale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLive_C.__PropertyOffset_60);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLive_C.__PropertyOffset_60) = value;
			}
		}

		// Token: 0x17005238 RID: 21048
		// (get) Token: 0x060257FA RID: 153594 RVA: 0x009BB17F File Offset: 0x009B937F
		// (set) Token: 0x060257FB RID: 153595 RVA: 0x009BB18F File Offset: 0x009B938F
		public unsafe bool LOD1_ReduceIterations
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLive_C.__PropertyOffset_61) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLive_C.__PropertyOffset_61) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005239 RID: 21049
		// (get) Token: 0x060257FC RID: 153596 RVA: 0x009BB1A0 File Offset: 0x009B93A0
		// (set) Token: 0x060257FD RID: 153597 RVA: 0x009BB1B0 File Offset: 0x009B93B0
		public unsafe bool LOD2_ReduceSamplingFPS
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLive_C.__PropertyOffset_62) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLive_C.__PropertyOffset_62) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700523A RID: 21050
		// (get) Token: 0x060257FE RID: 153598 RVA: 0x009BB1C1 File Offset: 0x009B93C1
		// (set) Token: 0x060257FF RID: 153599 RVA: 0x009BB1D1 File Offset: 0x009B93D1
		public unsafe bool LOD3_ReduceCollisionAmount
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLive_C.__PropertyOffset_63) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLive_C.__PropertyOffset_63) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700523B RID: 21051
		// (get) Token: 0x06025800 RID: 153600 RVA: 0x009BB1E2 File Offset: 0x009B93E2
		// (set) Token: 0x06025801 RID: 153601 RVA: 0x009BB1F2 File Offset: 0x009B93F2
		public unsafe int MinSamplingFPS
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLive_C.__PropertyOffset_64);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLive_C.__PropertyOffset_64) = value;
			}
		}

		// Token: 0x1700523C RID: 21052
		// (get) Token: 0x06025802 RID: 153602 RVA: 0x009BB203 File Offset: 0x009B9403
		// (set) Token: 0x06025803 RID: 153603 RVA: 0x009BB213 File Offset: 0x009B9413
		public unsafe float LOD_FarBound
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLive_C.__PropertyOffset_65);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLive_C.__PropertyOffset_65) = value;
			}
		}

		// Token: 0x1700523D RID: 21053
		// (get) Token: 0x06025804 RID: 153604 RVA: 0x009BB224 File Offset: 0x009B9424
		// (set) Token: 0x06025805 RID: 153605 RVA: 0x009BB234 File Offset: 0x009B9434
		public unsafe float LOD_NearBound
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLive_C.__PropertyOffset_66);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLive_C.__PropertyOffset_66) = value;
			}
		}

		// Token: 0x1700523E RID: 21054
		// (get) Token: 0x06025806 RID: 153606 RVA: 0x009BB245 File Offset: 0x009B9445
		// (set) Token: 0x06025807 RID: 153607 RVA: 0x009BB255 File Offset: 0x009B9455
		public unsafe int DownscaleCollisionPainterResolution
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLive_C.__PropertyOffset_67);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLive_C.__PropertyOffset_67) = value;
			}
		}

		// Token: 0x1700523F RID: 21055
		// (get) Token: 0x06025808 RID: 153608 RVA: 0x009BB266 File Offset: 0x009B9466
		// (set) Token: 0x06025809 RID: 153609 RVA: 0x009BB276 File Offset: 0x009B9476
		public unsafe int DownscalePressureResolution
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLive_C.__PropertyOffset_68);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLive_C.__PropertyOffset_68) = value;
			}
		}

		// Token: 0x17005240 RID: 21056
		// (get) Token: 0x0602580A RID: 153610 RVA: 0x009BB287 File Offset: 0x009B9487
		// (set) Token: 0x0602580B RID: 153611 RVA: 0x009BB297 File Offset: 0x009B9497
		public unsafe bool SingleTargetMode
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLive_C.__PropertyOffset_69) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLive_C.__PropertyOffset_69) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005241 RID: 21057
		// (get) Token: 0x0602580C RID: 153612 RVA: 0x009BB2A8 File Offset: 0x009B94A8
		// (set) Token: 0x0602580D RID: 153613 RVA: 0x009BB2B8 File Offset: 0x009B94B8
		public unsafe bool InitialActorsProcessed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLive_C.__PropertyOffset_70) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLive_C.__PropertyOffset_70) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005242 RID: 21058
		// (get) Token: 0x0602580E RID: 153614 RVA: 0x009BB2C9 File Offset: 0x009B94C9
		// (set) Token: 0x0602580F RID: 153615 RVA: 0x009BB2D9 File Offset: 0x009B94D9
		public unsafe bool SKMeshTagged
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLive_C.__PropertyOffset_71) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLive_C.__PropertyOffset_71) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005243 RID: 21059
		// (get) Token: 0x06025810 RID: 153616 RVA: 0x009BB2EA File Offset: 0x009B94EA
		// (set) Token: 0x06025811 RID: 153617 RVA: 0x009BB2FA File Offset: 0x009B94FA
		public unsafe bool bOnlySelfTraceMesh
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLive_C.__PropertyOffset_72) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLive_C.__PropertyOffset_72) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005244 RID: 21060
		// (get) Token: 0x06025812 RID: 153618 RVA: 0x009BB30B File Offset: 0x009B950B
		// (set) Token: 0x06025813 RID: 153619 RVA: 0x009BB31B File Offset: 0x009B951B
		public unsafe bool bOnlyFirstSkeletal
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLive_C.__PropertyOffset_73) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLive_C.__PropertyOffset_73) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005245 RID: 21061
		// (get) Token: 0x06025814 RID: 153620 RVA: 0x009BB32C File Offset: 0x009B952C
		// (set) Token: 0x06025815 RID: 153621 RVA: 0x009BB365 File Offset: 0x009B9565
		[Nullable(1)]
		public TArray<USkeletalMeshComponent> tempArray
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<USkeletalMeshComponent> result;
				if ((result = this._tempArray) == null)
				{
					result = (this._tempArray = new TArray<USkeletalMeshComponent>(base.NativePtr + (IntPtr)NinjaLive_C.__PropertyOffset_74, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.tempArray.CopyAssign(value);
			}
		}

		// Token: 0x06025816 RID: 153622 RVA: 0x009BB373 File Offset: 0x009B9573
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void ResetTempArrays()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLive_C.__ResetTempArrays_NativeFunctionPtr, null);
		}

		// Token: 0x06025817 RID: 153623 RVA: 0x009BB387 File Offset: 0x009B9587
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLive_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06025818 RID: 153624 RVA: 0x009BB39B File Offset: 0x009B959B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, NinjaLive_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06025819 RID: 153625 RVA: 0x009BB3B0 File Offset: 0x009B95B0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void InpTchEvt_Released(ETouchIndex FingerIndex, FVector Location)
		{
			NinjaLive_C.__InpTchEvt_Released_FunctionParams* ptr = stackalloc NinjaLive_C.__InpTchEvt_Released_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(NinjaLive_C.__InpTchEvt_Released_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLive_C.__InpTchEvt_Released_NativeFunctionPtr, (void*)ptr, 1);
			ptr->FingerIndex = FingerIndex;
			ptr->Location = Location;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLive_C.__InpTchEvt_Released_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602581A RID: 153626 RVA: 0x009BB404 File Offset: 0x009B9604
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void InpTchEvt_Pressed(ETouchIndex FingerIndex, FVector Location)
		{
			NinjaLive_C.__InpTchEvt_Pressed_FunctionParams* ptr = stackalloc NinjaLive_C.__InpTchEvt_Pressed_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(NinjaLive_C.__InpTchEvt_Pressed_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLive_C.__InpTchEvt_Pressed_NativeFunctionPtr, (void*)ptr, 1);
			ptr->FingerIndex = FingerIndex;
			ptr->Location = Location;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLive_C.__InpTchEvt_Pressed_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602581B RID: 153627 RVA: 0x009BB458 File Offset: 0x009B9658
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void InpActEvt_LeftMouseButton_K2Node_InputKeyEvent_1(FKey Key)
		{
			NinjaLive_C.__InpActEvt_LeftMouseButton_K2Node_InputKeyEvent_1_FunctionParams* ptr = stackalloc NinjaLive_C.__InpActEvt_LeftMouseButton_K2Node_InputKeyEvent_1_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(NinjaLive_C.__InpActEvt_LeftMouseButton_K2Node_InputKeyEvent_1_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLive_C.__InpActEvt_LeftMouseButton_K2Node_InputKeyEvent_1_NativeFunctionPtr, (void*)ptr, 1);
			if (Key != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FKey.StaticStruct(), &ptr->Key, Key.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLive_C.__InpActEvt_LeftMouseButton_K2Node_InputKeyEvent_1_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(NinjaLive_C.__InpActEvt_LeftMouseButton_K2Node_InputKeyEvent_1_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602581C RID: 153628 RVA: 0x009BB4CC File Offset: 0x009B96CC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void InpActEvt_LeftMouseButton_K2Node_InputKeyEvent_0(FKey Key)
		{
			NinjaLive_C.__InpActEvt_LeftMouseButton_K2Node_InputKeyEvent_0_FunctionParams* ptr = stackalloc NinjaLive_C.__InpActEvt_LeftMouseButton_K2Node_InputKeyEvent_0_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(NinjaLive_C.__InpActEvt_LeftMouseButton_K2Node_InputKeyEvent_0_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLive_C.__InpActEvt_LeftMouseButton_K2Node_InputKeyEvent_0_NativeFunctionPtr, (void*)ptr, 1);
			if (Key != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FKey.StaticStruct(), &ptr->Key, Key.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLive_C.__InpActEvt_LeftMouseButton_K2Node_InputKeyEvent_0_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(NinjaLive_C.__InpActEvt_LeftMouseButton_K2Node_InputKeyEvent_0_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602581D RID: 153629 RVA: 0x009BB540 File Offset: 0x009B9740
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void LiveActivation(FName ParamName, float FadeTimeOfBrush, float FadeTimeOfCanvas)
		{
			NinjaLive_C.__LiveActivation_FunctionParams* ptr = stackalloc NinjaLive_C.__LiveActivation_FunctionParams[(UIntPtr)35] + 15L / (long)sizeof(NinjaLive_C.__LiveActivation_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLive_C.__LiveActivation_NativeFunctionPtr, (void*)ptr, 1);
			ptr->ParamName = ParamName;
			ptr->FadeTimeOfBrush = FadeTimeOfBrush;
			ptr->FadeTimeOfCanvas = FadeTimeOfCanvas;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLive_C.__LiveActivation_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602581E RID: 153630 RVA: 0x009BB594 File Offset: 0x009B9794
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void LiveFluidParams(float BrushSize)
		{
			NinjaLive_C.__LiveFluidParams_FunctionParams* ptr = stackalloc NinjaLive_C.__LiveFluidParams_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(NinjaLive_C.__LiveFluidParams_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLive_C.__LiveFluidParams_NativeFunctionPtr, (void*)ptr, 1);
			ptr->BrushSize = BrushSize;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLive_C.__LiveFluidParams_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602581F RID: 153631 RVA: 0x009BB5DC File Offset: 0x009B97DC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			NinjaLive_C.__ReceiveTick_FunctionParams* ptr = stackalloc NinjaLive_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(NinjaLive_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLive_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLive_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025820 RID: 153632 RVA: 0x009BB624 File Offset: 0x009B9824
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			NinjaLive_C.__ReceiveTick_FunctionParams* ptr = stackalloc NinjaLive_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(NinjaLive_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLive_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, NinjaLive_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06025821 RID: 153633 RVA: 0x009BB66B File Offset: 0x009B986B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLive_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06025822 RID: 153634 RVA: 0x009BB67F File Offset: 0x009B987F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, NinjaLive_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06025823 RID: 153635 RVA: 0x009BB694 File Offset: 0x009B9894
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void RePlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLive_C.__RePlay_NativeFunctionPtr, null);
		}

		// Token: 0x06025824 RID: 153636 RVA: 0x009BB6A8 File Offset: 0x009B98A8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void BeforeCookForPC()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLive_C.__BeforeCookForPC_NativeFunctionPtr, null);
		}

		// Token: 0x06025825 RID: 153637 RVA: 0x009BB6BC File Offset: 0x009B98BC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void BeforeCookForPC_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, NinjaLive_C.__BeforeCookForPC_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06025826 RID: 153638 RVA: 0x009BB6D1 File Offset: 0x009B98D1
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void BeforeCookForMobile()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLive_C.__BeforeCookForMobile_NativeFunctionPtr, null);
		}

		// Token: 0x06025827 RID: 153639 RVA: 0x009BB6E5 File Offset: 0x009B98E5
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void BeforeCookForMobile_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, NinjaLive_C.__BeforeCookForMobile_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06025828 RID: 153640 RVA: 0x009BB6FC File Offset: 0x009B98FC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BeginOverlapComponent(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex, bool bFromSweep, in FHitResult SweepResult)
		{
			NinjaLive_C.__BeginOverlapComponent_FunctionParams* ptr = stackalloc NinjaLive_C.__BeginOverlapComponent_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(NinjaLive_C.__BeginOverlapComponent_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLive_C.__BeginOverlapComponent_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			ptr->bFromSweep = bFromSweep;
			if (SweepResult != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FHitResult.StaticStruct(), &ptr->SweepResult, SweepResult.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLive_C.__BeginOverlapComponent_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025829 RID: 153641 RVA: 0x009BB7B8 File Offset: 0x009B99B8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void EndOverlapComponent(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex)
		{
			NinjaLive_C.__EndOverlapComponent_FunctionParams* ptr = stackalloc NinjaLive_C.__EndOverlapComponent_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(NinjaLive_C.__EndOverlapComponent_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLive_C.__EndOverlapComponent_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLive_C.__EndOverlapComponent_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602582A RID: 153642 RVA: 0x009BB844 File Offset: 0x009B9A44
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveActorEndOverlap(AActor OtherActor)
		{
			NinjaLive_C.__ReceiveActorEndOverlap_FunctionParams* ptr = stackalloc NinjaLive_C.__ReceiveActorEndOverlap_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(NinjaLive_C.__ReceiveActorEndOverlap_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLive_C.__ReceiveActorEndOverlap_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLive_C.__ReceiveActorEndOverlap_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602582B RID: 153643 RVA: 0x009BB89C File Offset: 0x009B9A9C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveActorEndOverlap_Implementation(AActor OtherActor)
		{
			NinjaLive_C.__ReceiveActorEndOverlap_FunctionParams* ptr = stackalloc NinjaLive_C.__ReceiveActorEndOverlap_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(NinjaLive_C.__ReceiveActorEndOverlap_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLive_C.__ReceiveActorEndOverlap_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallUFunction(base.NativePtr, NinjaLive_C.__ReceiveActorEndOverlap_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602582C RID: 153644 RVA: 0x009BB8F4 File Offset: 0x009B9AF4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveActorBeginOverlap(AActor OtherActor)
		{
			NinjaLive_C.__ReceiveActorBeginOverlap_FunctionParams* ptr = stackalloc NinjaLive_C.__ReceiveActorBeginOverlap_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(NinjaLive_C.__ReceiveActorBeginOverlap_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLive_C.__ReceiveActorBeginOverlap_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLive_C.__ReceiveActorBeginOverlap_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602582D RID: 153645 RVA: 0x009BB94C File Offset: 0x009B9B4C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveActorBeginOverlap_Implementation(AActor OtherActor)
		{
			NinjaLive_C.__ReceiveActorBeginOverlap_FunctionParams* ptr = stackalloc NinjaLive_C.__ReceiveActorBeginOverlap_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(NinjaLive_C.__ReceiveActorBeginOverlap_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLive_C.__ReceiveActorBeginOverlap_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallUFunction(base.NativePtr, NinjaLive_C.__ReceiveActorBeginOverlap_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602582E RID: 153646 RVA: 0x009BB9A4 File Offset: 0x009B9BA4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_NinjaLive(int EntryPoint)
		{
			NinjaLive_C.__ExecuteUbergraph_NinjaLive_FunctionParams* ptr = stackalloc NinjaLive_C.__ExecuteUbergraph_NinjaLive_FunctionParams[(UIntPtr)2127] + 15L / (long)sizeof(NinjaLive_C.__ExecuteUbergraph_NinjaLive_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLive_C.__ExecuteUbergraph_NinjaLive_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, NinjaLive_C.__ExecuteUbergraph_NinjaLive_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602582F RID: 153647 RVA: 0x009BB9EE File Offset: 0x009B9BEE
		protected NinjaLive_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04013514 RID: 79124
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/FluidNinjaLive/NinjaLive.NinjaLive_C";

		// Token: 0x04013515 RID: 79125
		private static IntPtr _ClassPtr;

		// Token: 0x04013516 RID: 79126
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04013517 RID: 79127
		public static IntPtr __OwnerRePlayEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04013518 RID: 79128
		internal static int __PropertyOffset_0;

		// Token: 0x04013519 RID: 79129
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0401351A RID: 79130
		internal static int __PropertyOffset_1;

		// Token: 0x0401351B RID: 79131
		internal static int __PropertyOffset_2;

		// Token: 0x0401351C RID: 79132
		internal static int __PropertyOffset_3;

		// Token: 0x0401351D RID: 79133
		internal static int __PropertyOffset_4;

		// Token: 0x0401351E RID: 79134
		internal static int __PropertyOffset_5;

		// Token: 0x0401351F RID: 79135
		internal static int __PropertyOffset_6;

		// Token: 0x04013520 RID: 79136
		internal static int __PropertyOffset_7;

		// Token: 0x04013521 RID: 79137
		internal static int __PropertyOffset_8;

		// Token: 0x04013522 RID: 79138
		internal static int __PropertyOffset_9;

		// Token: 0x04013523 RID: 79139
		internal static int __PropertyOffset_10;

		// Token: 0x04013524 RID: 79140
		internal static int __PropertyOffset_11;

		// Token: 0x04013525 RID: 79141
		internal static int __PropertyOffset_12;

		// Token: 0x04013526 RID: 79142
		internal static int __PropertyOffset_13;

		// Token: 0x04013527 RID: 79143
		internal static int __PropertyOffset_14;

		// Token: 0x04013528 RID: 79144
		internal static int __PropertyOffset_15;

		// Token: 0x04013529 RID: 79145
		internal static int __PropertyOffset_16;

		// Token: 0x0401352A RID: 79146
		internal static int __PropertyOffset_17;

		// Token: 0x0401352B RID: 79147
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<NinjaLive_C> _NinjaLIVECollisionExclude;

		// Token: 0x0401352C RID: 79148
		internal static int __PropertyOffset_18;

		// Token: 0x0401352D RID: 79149
		internal static int __PropertyOffset_19;

		// Token: 0x0401352E RID: 79150
		internal static int __PropertyOffset_20;

		// Token: 0x0401352F RID: 79151
		internal static int __PropertyOffset_21;

		// Token: 0x04013530 RID: 79152
		internal static int __PropertyOffset_22;

		// Token: 0x04013531 RID: 79153
		internal static int __PropertyOffset_23;

		// Token: 0x04013532 RID: 79154
		internal static int __PropertyOffset_24;

		// Token: 0x04013533 RID: 79155
		internal static int __PropertyOffset_25;

		// Token: 0x04013534 RID: 79156
		internal static int __PropertyOffset_26;

		// Token: 0x04013535 RID: 79157
		internal static int __PropertyOffset_27;

		// Token: 0x04013536 RID: 79158
		internal static int __PropertyOffset_28;

		// Token: 0x04013537 RID: 79159
		internal static int __PropertyOffset_29;

		// Token: 0x04013538 RID: 79160
		internal static int __PropertyOffset_30;

		// Token: 0x04013539 RID: 79161
		internal static int __PropertyOffset_31;

		// Token: 0x0401353A RID: 79162
		private TArray<bool> _MultipleTouchLookup;

		// Token: 0x0401353B RID: 79163
		internal static int __PropertyOffset_32;

		// Token: 0x0401353C RID: 79164
		internal static int __PropertyOffset_33;

		// Token: 0x0401353D RID: 79165
		internal static int __PropertyOffset_34;

		// Token: 0x0401353E RID: 79166
		internal static int __PropertyOffset_35;

		// Token: 0x0401353F RID: 79167
		internal static int __PropertyOffset_36;

		// Token: 0x04013540 RID: 79168
		[Nullable(new byte[]
		{
			2,
			0
		})]
		private TArray<TEnumAsByte<EObjectTypeQuery>> _OverlapFilterInclusiveObjType;

		// Token: 0x04013541 RID: 79169
		internal static int __PropertyOffset_37;

		// Token: 0x04013542 RID: 79170
		private TArray<FName> _OverlapFilterInclusiveBoneNameExact;

		// Token: 0x04013543 RID: 79171
		internal static int __PropertyOffset_38;

		// Token: 0x04013544 RID: 79172
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<string> _OverlapFilterInclusiveBoneNamePartial;

		// Token: 0x04013545 RID: 79173
		internal static int __PropertyOffset_39;

		// Token: 0x04013546 RID: 79174
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<AActor> _ExcludeSpecificActorsFromOverlap;

		// Token: 0x04013547 RID: 79175
		internal static int __PropertyOffset_40;

		// Token: 0x04013548 RID: 79176
		internal static int __PropertyOffset_41;

		// Token: 0x04013549 RID: 79177
		[Nullable(new byte[]
		{
			2,
			0,
			0
		})]
		private TMap<TEnumAsByte<ECollisionChannel>, TEnumAsByte<EObjectTypeQuery>> _OverlapFilterInclusiveCollisionType;

		// Token: 0x0401354A RID: 79178
		internal static int __PropertyOffset_42;

		// Token: 0x0401354B RID: 79179
		internal static int __PropertyOffset_43;

		// Token: 0x0401354C RID: 79180
		internal static int __PropertyOffset_44;

		// Token: 0x0401354D RID: 79181
		internal static int __PropertyOffset_45;

		// Token: 0x0401354E RID: 79182
		internal static int __PropertyOffset_46;

		// Token: 0x0401354F RID: 79183
		internal static int __PropertyOffset_47;

		// Token: 0x04013550 RID: 79184
		internal static int __PropertyOffset_48;

		// Token: 0x04013551 RID: 79185
		internal static int __PropertyOffset_49;

		// Token: 0x04013552 RID: 79186
		internal static int __PropertyOffset_50;

		// Token: 0x04013553 RID: 79187
		internal static int __PropertyOffset_51;

		// Token: 0x04013554 RID: 79188
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UPrimitiveComponent> _OverlappingComponents;

		// Token: 0x04013555 RID: 79189
		internal static int __PropertyOffset_52;

		// Token: 0x04013556 RID: 79190
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<AActor> _OverlappingActors;

		// Token: 0x04013557 RID: 79191
		internal static int __PropertyOffset_53;

		// Token: 0x04013558 RID: 79192
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<int, UPrimitiveComponent> _SkeletalMesh_TempArray_Pairs;

		// Token: 0x04013559 RID: 79193
		internal static int __PropertyOffset_54;

		// Token: 0x0401355A RID: 79194
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<AActor> _OverlappingActorsInitial;

		// Token: 0x0401355B RID: 79195
		internal static int __PropertyOffset_55;

		// Token: 0x0401355C RID: 79196
		private OwnerRePlayEvent _OwnerRePlayEvent;

		// Token: 0x0401355D RID: 79197
		internal static int __PropertyOffset_56;

		// Token: 0x0401355E RID: 79198
		internal static int __PropertyOffset_57;

		// Token: 0x0401355F RID: 79199
		internal static int __PropertyOffset_58;

		// Token: 0x04013560 RID: 79200
		internal static int __PropertyOffset_59;

		// Token: 0x04013561 RID: 79201
		internal static int __PropertyOffset_60;

		// Token: 0x04013562 RID: 79202
		internal static int __PropertyOffset_61;

		// Token: 0x04013563 RID: 79203
		internal static int __PropertyOffset_62;

		// Token: 0x04013564 RID: 79204
		internal static int __PropertyOffset_63;

		// Token: 0x04013565 RID: 79205
		internal static int __PropertyOffset_64;

		// Token: 0x04013566 RID: 79206
		internal static int __PropertyOffset_65;

		// Token: 0x04013567 RID: 79207
		internal static int __PropertyOffset_66;

		// Token: 0x04013568 RID: 79208
		internal static int __PropertyOffset_67;

		// Token: 0x04013569 RID: 79209
		internal static int __PropertyOffset_68;

		// Token: 0x0401356A RID: 79210
		internal static int __PropertyOffset_69;

		// Token: 0x0401356B RID: 79211
		internal static int __PropertyOffset_70;

		// Token: 0x0401356C RID: 79212
		internal static int __PropertyOffset_71;

		// Token: 0x0401356D RID: 79213
		internal static int __PropertyOffset_72;

		// Token: 0x0401356E RID: 79214
		internal static int __PropertyOffset_73;

		// Token: 0x0401356F RID: 79215
		internal static int __PropertyOffset_74;

		// Token: 0x04013570 RID: 79216
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<USkeletalMeshComponent> _tempArray;

		// Token: 0x04013571 RID: 79217
		private static IntPtr __ResetTempArrays_NativeFunctionPtr;

		// Token: 0x04013572 RID: 79218
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04013573 RID: 79219
		private static IntPtr __InpTchEvt_Released_NativeFunctionPtr;

		// Token: 0x04013574 RID: 79220
		private static IntPtr __InpTchEvt_Pressed_NativeFunctionPtr;

		// Token: 0x04013575 RID: 79221
		private static IntPtr __InpActEvt_LeftMouseButton_K2Node_InputKeyEvent_1_NativeFunctionPtr;

		// Token: 0x04013576 RID: 79222
		private static IntPtr __InpActEvt_LeftMouseButton_K2Node_InputKeyEvent_0_NativeFunctionPtr;

		// Token: 0x04013577 RID: 79223
		private static IntPtr __LiveActivation_NativeFunctionPtr;

		// Token: 0x04013578 RID: 79224
		private static IntPtr __LiveFluidParams_NativeFunctionPtr;

		// Token: 0x04013579 RID: 79225
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0401357A RID: 79226
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0401357B RID: 79227
		private static IntPtr __RePlay_NativeFunctionPtr;

		// Token: 0x0401357C RID: 79228
		private static IntPtr __BeforeCookForPC_NativeFunctionPtr;

		// Token: 0x0401357D RID: 79229
		private static IntPtr __BeforeCookForMobile_NativeFunctionPtr;

		// Token: 0x0401357E RID: 79230
		private static IntPtr __BeginOverlapComponent_NativeFunctionPtr;

		// Token: 0x0401357F RID: 79231
		private static IntPtr __EndOverlapComponent_NativeFunctionPtr;

		// Token: 0x04013580 RID: 79232
		private static IntPtr __ReceiveActorEndOverlap_NativeFunctionPtr;

		// Token: 0x04013581 RID: 79233
		private static IntPtr __ReceiveActorBeginOverlap_NativeFunctionPtr;

		// Token: 0x04013582 RID: 79234
		private static IntPtr __ExecuteUbergraph_NinjaLive_NativeFunctionPtr;

		// Token: 0x02009F01 RID: 40705
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __InpTchEvt_Released_FunctionParams
		{
			// Token: 0x040329FF RID: 207359
			[FieldOffset(0)]
			public TEnumAsByte<ETouchIndex> FingerIndex;

			// Token: 0x04032A00 RID: 207360
			[FieldOffset(4)]
			public FVector Location;
		}

		// Token: 0x02009F02 RID: 40706
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __InpTchEvt_Pressed_FunctionParams
		{
			// Token: 0x04032A01 RID: 207361
			[FieldOffset(0)]
			public TEnumAsByte<ETouchIndex> FingerIndex;

			// Token: 0x04032A02 RID: 207362
			[FieldOffset(4)]
			public FVector Location;
		}

		// Token: 0x02009F03 RID: 40707
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __InpActEvt_LeftMouseButton_K2Node_InputKeyEvent_1_FunctionParams
		{
			// Token: 0x04032A03 RID: 207363
			[FieldOffset(0)]
			public byte Key;
		}

		// Token: 0x02009F04 RID: 40708
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __InpActEvt_LeftMouseButton_K2Node_InputKeyEvent_0_FunctionParams
		{
			// Token: 0x04032A04 RID: 207364
			[FieldOffset(0)]
			public byte Key;
		}

		// Token: 0x02009F05 RID: 40709
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 20)]
		protected ref struct __LiveActivation_FunctionParams
		{
			// Token: 0x04032A05 RID: 207365
			[FieldOffset(0)]
			public FName ParamName;

			// Token: 0x04032A06 RID: 207366
			[FieldOffset(12)]
			public float FadeTimeOfBrush;

			// Token: 0x04032A07 RID: 207367
			[FieldOffset(16)]
			public float FadeTimeOfCanvas;
		}

		// Token: 0x02009F06 RID: 40710
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __LiveFluidParams_FunctionParams
		{
			// Token: 0x04032A08 RID: 207368
			[FieldOffset(0)]
			public float BrushSize;
		}

		// Token: 0x02009F07 RID: 40711
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032A09 RID: 207369
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009F08 RID: 40712
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __BeginOverlapComponent_FunctionParams
		{
			// Token: 0x04032A0A RID: 207370
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x04032A0B RID: 207371
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x04032A0C RID: 207372
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x04032A0D RID: 207373
			[FieldOffset(24)]
			public int OtherBodyIndex;

			// Token: 0x04032A0E RID: 207374
			[FieldOffset(28)]
			public bool bFromSweep;

			// Token: 0x04032A0F RID: 207375
			[FieldOffset(32)]
			public byte SweepResult;
		}

		// Token: 0x02009F09 RID: 40713
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __EndOverlapComponent_FunctionParams
		{
			// Token: 0x04032A10 RID: 207376
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x04032A11 RID: 207377
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x04032A12 RID: 207378
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x04032A13 RID: 207379
			[FieldOffset(24)]
			public int OtherBodyIndex;
		}

		// Token: 0x02009F0A RID: 40714
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected new ref struct __ReceiveActorEndOverlap_FunctionParams
		{
			// Token: 0x04032A14 RID: 207380
			[FieldOffset(0)]
			public IntPtr OtherActor;
		}

		// Token: 0x02009F0B RID: 40715
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected new ref struct __ReceiveActorBeginOverlap_FunctionParams
		{
			// Token: 0x04032A15 RID: 207381
			[FieldOffset(0)]
			public IntPtr OtherActor;
		}

		// Token: 0x02009F0C RID: 40716
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 2112)]
		protected ref struct __ExecuteUbergraph_NinjaLive_FunctionParams
		{
			// Token: 0x04032A16 RID: 207382
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
