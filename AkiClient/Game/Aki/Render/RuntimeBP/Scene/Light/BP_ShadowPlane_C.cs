using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Light
{
	// Token: 0x02003A99 RID: 15001
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Light/BP_ShadowPlane.BP_ShadowPlane_C")]
	[UnrealStructLayout(1712, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1712)]
	public class BP_ShadowPlane_C : AKuroEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601FA3E RID: 129598 RVA: 0x00916E14 File Offset: 0x00915014
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_ShadowPlane_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Light/BP_ShadowPlane.BP_ShadowPlane_C");
			}
			return BP_ShadowPlane_C._ClassPtr;
		}

		// Token: 0x0601FA3F RID: 129599 RVA: 0x00916E38 File Offset: 0x00915038
		public BP_ShadowPlane_C() : this(BuiltinUtils.AllocNativeUObject(BP_ShadowPlane_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601FA40 RID: 129600 RVA: 0x00916E60 File Offset: 0x00915060
		[NullableContext(1)]
		public BP_ShadowPlane_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_ShadowPlane_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003117 RID: 12567
		// (get) Token: 0x0601FA41 RID: 129601 RVA: 0x00916E94 File Offset: 0x00915094
		// (set) Token: 0x0601FA42 RID: 129602 RVA: 0x00916ECD File Offset: 0x009150CD
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_ShadowPlane_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_ShadowPlane_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003118 RID: 12568
		// (get) Token: 0x0601FA43 RID: 129603 RVA: 0x00916EEE File Offset: 0x009150EE
		// (set) Token: 0x0601FA44 RID: 129604 RVA: 0x00916F02 File Offset: 0x00915102
		public unsafe UKuroGameBudgetComponent KuroGameBudget
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroGameBudgetComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_ShadowPlane_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_ShadowPlane_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17003119 RID: 12569
		// (get) Token: 0x0601FA45 RID: 129605 RVA: 0x00916F17 File Offset: 0x00915117
		// (set) Token: 0x0601FA46 RID: 129606 RVA: 0x00916F2B File Offset: 0x0091512B
		public unsafe UStaticMeshComponent Plane
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_ShadowPlane_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_ShadowPlane_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x1700311A RID: 12570
		// (get) Token: 0x0601FA47 RID: 129607 RVA: 0x00916F40 File Offset: 0x00915140
		// (set) Token: 0x0601FA48 RID: 129608 RVA: 0x00916F54 File Offset: 0x00915154
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_ShadowPlane_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_ShadowPlane_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x1700311B RID: 12571
		// (get) Token: 0x0601FA49 RID: 129609 RVA: 0x00916F69 File Offset: 0x00915169
		// (set) Token: 0x0601FA4A RID: 129610 RVA: 0x00916F7D File Offset: 0x0091517D
		public unsafe UMaterialInstanceDynamic DynamicMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_ShadowPlane_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_ShadowPlane_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x1700311C RID: 12572
		// (get) Token: 0x0601FA4B RID: 129611 RVA: 0x00916F94 File Offset: 0x00915194
		// (set) Token: 0x0601FA4C RID: 129612 RVA: 0x00916FCD File Offset: 0x009151CD
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
					result = (this._Scalar_Parameters = new TMap<FName, float>(base.NativePtr + (IntPtr)BP_ShadowPlane_C.__PropertyOffset_5, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Scalar_Parameters.CopyAssign(value);
			}
		}

		// Token: 0x1700311D RID: 12573
		// (get) Token: 0x0601FA4D RID: 129613 RVA: 0x00916FDC File Offset: 0x009151DC
		// (set) Token: 0x0601FA4E RID: 129614 RVA: 0x00917015 File Offset: 0x00915215
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
					result = (this._Vector_Parameters = new TMap<FName, FLinearColor>(base.NativePtr + (IntPtr)BP_ShadowPlane_C.__PropertyOffset_6, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Vector_Parameters.CopyAssign(value);
			}
		}

		// Token: 0x1700311E RID: 12574
		// (get) Token: 0x0601FA4F RID: 129615 RVA: 0x00917024 File Offset: 0x00915224
		// (set) Token: 0x0601FA50 RID: 129616 RVA: 0x0091705D File Offset: 0x0091525D
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
					result = (this._Texture_Parameters = new TMap<FName, UTexture>(base.NativePtr + (IntPtr)BP_ShadowPlane_C.__PropertyOffset_7, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Texture_Parameters.CopyAssign(value);
			}
		}

		// Token: 0x1700311F RID: 12575
		// (get) Token: 0x0601FA51 RID: 129617 RVA: 0x0091706B File Offset: 0x0091526B
		// (set) Token: 0x0601FA52 RID: 129618 RVA: 0x0091707F File Offset: 0x0091527F
		public unsafe UMaterialInstance Material
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_ShadowPlane_C.__PropertyOffset_8);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_ShadowPlane_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x17003120 RID: 12576
		// (get) Token: 0x0601FA53 RID: 129619 RVA: 0x00917094 File Offset: 0x00915294
		// (set) Token: 0x0601FA54 RID: 129620 RVA: 0x009170A4 File Offset: 0x009152A4
		public unsafe float BlurIntensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ShadowPlane_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ShadowPlane_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17003121 RID: 12577
		// (get) Token: 0x0601FA55 RID: 129621 RVA: 0x009170B5 File Offset: 0x009152B5
		// (set) Token: 0x0601FA56 RID: 129622 RVA: 0x009170C5 File Offset: 0x009152C5
		public unsafe float TranslucentIntensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ShadowPlane_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ShadowPlane_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17003122 RID: 12578
		// (get) Token: 0x0601FA57 RID: 129623 RVA: 0x009170D6 File Offset: 0x009152D6
		// (set) Token: 0x0601FA58 RID: 129624 RVA: 0x009170EA File Offset: 0x009152EA
		public unsafe UTexture2D Texture
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_ShadowPlane_C.__PropertyOffset_11);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_ShadowPlane_C.__PropertyOffset_11, value);
			}
		}

		// Token: 0x17003123 RID: 12579
		// (get) Token: 0x0601FA59 RID: 129625 RVA: 0x009170FF File Offset: 0x009152FF
		// (set) Token: 0x0601FA5A RID: 129626 RVA: 0x00917113 File Offset: 0x00915313
		public unsafe UMaterialInstance Material_Normal
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_ShadowPlane_C.__PropertyOffset_12);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_ShadowPlane_C.__PropertyOffset_12, value);
			}
		}

		// Token: 0x17003124 RID: 12580
		// (get) Token: 0x0601FA5B RID: 129627 RVA: 0x00917128 File Offset: 0x00915328
		// (set) Token: 0x0601FA5C RID: 129628 RVA: 0x0091713C File Offset: 0x0091533C
		public unsafe FLinearColor Color
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ShadowPlane_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ShadowPlane_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17003125 RID: 12581
		// (get) Token: 0x0601FA5D RID: 129629 RVA: 0x00917151 File Offset: 0x00915351
		// (set) Token: 0x0601FA5E RID: 129630 RVA: 0x00917161 File Offset: 0x00915361
		public unsafe float Inver
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ShadowPlane_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ShadowPlane_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x17003126 RID: 12582
		// (get) Token: 0x0601FA5F RID: 129631 RVA: 0x00917172 File Offset: 0x00915372
		// (set) Token: 0x0601FA60 RID: 129632 RVA: 0x00917182 File Offset: 0x00915382
		public unsafe float Hard
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ShadowPlane_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ShadowPlane_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x17003127 RID: 12583
		// (get) Token: 0x0601FA61 RID: 129633 RVA: 0x00917193 File Offset: 0x00915393
		// (set) Token: 0x0601FA62 RID: 129634 RVA: 0x009171A3 File Offset: 0x009153A3
		public unsafe float WindIntensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ShadowPlane_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ShadowPlane_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x17003128 RID: 12584
		// (get) Token: 0x0601FA63 RID: 129635 RVA: 0x009171B4 File Offset: 0x009153B4
		// (set) Token: 0x0601FA64 RID: 129636 RVA: 0x009171C4 File Offset: 0x009153C4
		public unsafe float WindSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ShadowPlane_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ShadowPlane_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x17003129 RID: 12585
		// (get) Token: 0x0601FA65 RID: 129637 RVA: 0x009171D5 File Offset: 0x009153D5
		// (set) Token: 0x0601FA66 RID: 129638 RVA: 0x009171E5 File Offset: 0x009153E5
		public unsafe float WindDir_X
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ShadowPlane_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ShadowPlane_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x1700312A RID: 12586
		// (get) Token: 0x0601FA67 RID: 129639 RVA: 0x009171F6 File Offset: 0x009153F6
		// (set) Token: 0x0601FA68 RID: 129640 RVA: 0x00917206 File Offset: 0x00915406
		public unsafe float WindDir_Y
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ShadowPlane_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ShadowPlane_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x1700312B RID: 12587
		// (get) Token: 0x0601FA69 RID: 129641 RVA: 0x00917217 File Offset: 0x00915417
		// (set) Token: 0x0601FA6A RID: 129642 RVA: 0x00917227 File Offset: 0x00915427
		public unsafe float StrenghtAngle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ShadowPlane_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ShadowPlane_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x1700312C RID: 12588
		// (get) Token: 0x0601FA6B RID: 129643 RVA: 0x00917238 File Offset: 0x00915438
		// (set) Token: 0x0601FA6C RID: 129644 RVA: 0x00917248 File Offset: 0x00915448
		public unsafe float WindRandomSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ShadowPlane_C.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ShadowPlane_C.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x1700312D RID: 12589
		// (get) Token: 0x0601FA6D RID: 129645 RVA: 0x00917259 File Offset: 0x00915459
		// (set) Token: 0x0601FA6E RID: 129646 RVA: 0x00917269 File Offset: 0x00915469
		public unsafe float WindRandomIntensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ShadowPlane_C.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ShadowPlane_C.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x1700312E RID: 12590
		// (get) Token: 0x0601FA6F RID: 129647 RVA: 0x0091727A File Offset: 0x0091547A
		// (set) Token: 0x0601FA70 RID: 129648 RVA: 0x0091728A File Offset: 0x0091548A
		public unsafe float UVPosition_X
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ShadowPlane_C.__PropertyOffset_23);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ShadowPlane_C.__PropertyOffset_23) = value;
			}
		}

		// Token: 0x1700312F RID: 12591
		// (get) Token: 0x0601FA71 RID: 129649 RVA: 0x0091729B File Offset: 0x0091549B
		// (set) Token: 0x0601FA72 RID: 129650 RVA: 0x009172AB File Offset: 0x009154AB
		public unsafe float UVPosition_Y
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ShadowPlane_C.__PropertyOffset_24);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ShadowPlane_C.__PropertyOffset_24) = value;
			}
		}

		// Token: 0x17003130 RID: 12592
		// (get) Token: 0x0601FA73 RID: 129651 RVA: 0x009172BC File Offset: 0x009154BC
		// (set) Token: 0x0601FA74 RID: 129652 RVA: 0x009172CC File Offset: 0x009154CC
		public unsafe float UVScale_X
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ShadowPlane_C.__PropertyOffset_25);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ShadowPlane_C.__PropertyOffset_25) = value;
			}
		}

		// Token: 0x17003131 RID: 12593
		// (get) Token: 0x0601FA75 RID: 129653 RVA: 0x009172DD File Offset: 0x009154DD
		// (set) Token: 0x0601FA76 RID: 129654 RVA: 0x009172ED File Offset: 0x009154ED
		public unsafe float UVScale_Y
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ShadowPlane_C.__PropertyOffset_26);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ShadowPlane_C.__PropertyOffset_26) = value;
			}
		}

		// Token: 0x17003132 RID: 12594
		// (get) Token: 0x0601FA77 RID: 129655 RVA: 0x009172FE File Offset: 0x009154FE
		// (set) Token: 0x0601FA78 RID: 129656 RVA: 0x0091730E File Offset: 0x0091550E
		public unsafe bool ReflectionMode
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ShadowPlane_C.__PropertyOffset_27) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ShadowPlane_C.__PropertyOffset_27) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003133 RID: 12595
		// (get) Token: 0x0601FA79 RID: 129657 RVA: 0x0091731F File Offset: 0x0091551F
		// (set) Token: 0x0601FA7A RID: 129658 RVA: 0x0091732F File Offset: 0x0091552F
		public unsafe float ReflectionIntensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ShadowPlane_C.__PropertyOffset_28);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ShadowPlane_C.__PropertyOffset_28) = value;
			}
		}

		// Token: 0x17003134 RID: 12596
		// (get) Token: 0x0601FA7B RID: 129659 RVA: 0x00917340 File Offset: 0x00915540
		// (set) Token: 0x0601FA7C RID: 129660 RVA: 0x00917350 File Offset: 0x00915550
		public unsafe float ReflectionFlowIntensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ShadowPlane_C.__PropertyOffset_29);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ShadowPlane_C.__PropertyOffset_29) = value;
			}
		}

		// Token: 0x17003135 RID: 12597
		// (get) Token: 0x0601FA7D RID: 129661 RVA: 0x00917361 File Offset: 0x00915561
		// (set) Token: 0x0601FA7E RID: 129662 RVA: 0x00917371 File Offset: 0x00915571
		public unsafe float Radius
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ShadowPlane_C.__PropertyOffset_30);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ShadowPlane_C.__PropertyOffset_30) = value;
			}
		}

		// Token: 0x17003136 RID: 12598
		// (get) Token: 0x0601FA7F RID: 129663 RVA: 0x00917382 File Offset: 0x00915582
		// (set) Token: 0x0601FA80 RID: 129664 RVA: 0x00917392 File Offset: 0x00915592
		public unsafe float ReflectionFlowSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ShadowPlane_C.__PropertyOffset_31);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ShadowPlane_C.__PropertyOffset_31) = value;
			}
		}

		// Token: 0x0601FA81 RID: 129665 RVA: 0x009173A3 File Offset: 0x009155A3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SetParameter()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ShadowPlane_C.__SetParameter_NativeFunctionPtr, null);
		}

		// Token: 0x0601FA82 RID: 129666 RVA: 0x009173B7 File Offset: 0x009155B7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ShadowPlane_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0601FA83 RID: 129667 RVA: 0x009173CB File Offset: 0x009155CB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_ShadowPlane_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601FA84 RID: 129668 RVA: 0x009173E0 File Offset: 0x009155E0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ShadowPlane_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0601FA85 RID: 129669 RVA: 0x009173F4 File Offset: 0x009155F4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_ShadowPlane_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601FA86 RID: 129670 RVA: 0x0091740C File Offset: 0x0091560C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_ShadowPlane_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_ShadowPlane_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_ShadowPlane_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ShadowPlane_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ShadowPlane_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601FA87 RID: 129671 RVA: 0x00917454 File Offset: 0x00915654
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_ShadowPlane_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_ShadowPlane_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_ShadowPlane_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ShadowPlane_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_ShadowPlane_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601FA88 RID: 129672 RVA: 0x0091749B File Offset: 0x0091569B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveDestroyed()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ShadowPlane_C.__ReceiveDestroyed_NativeFunctionPtr, null);
		}

		// Token: 0x0601FA89 RID: 129673 RVA: 0x009174AF File Offset: 0x009156AF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveDestroyed_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_ShadowPlane_C.__ReceiveDestroyed_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601FA8A RID: 129674 RVA: 0x009174C4 File Offset: 0x009156C4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_ShadowPlane_C.__EditorTick_FunctionParams* ptr = stackalloc BP_ShadowPlane_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_ShadowPlane_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ShadowPlane_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ShadowPlane_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601FA8B RID: 129675 RVA: 0x0091750C File Offset: 0x0091570C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_ShadowPlane_C.__EditorTick_FunctionParams* ptr = stackalloc BP_ShadowPlane_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_ShadowPlane_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ShadowPlane_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_ShadowPlane_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601FA8C RID: 129676 RVA: 0x00917554 File Offset: 0x00915754
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_ShadowPlane(int EntryPoint)
		{
			BP_ShadowPlane_C.__ExecuteUbergraph_BP_ShadowPlane_FunctionParams* ptr = stackalloc BP_ShadowPlane_C.__ExecuteUbergraph_BP_ShadowPlane_FunctionParams[(UIntPtr)63] + 15L / (long)sizeof(BP_ShadowPlane_C.__ExecuteUbergraph_BP_ShadowPlane_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ShadowPlane_C.__ExecuteUbergraph_BP_ShadowPlane_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_ShadowPlane_C.__ExecuteUbergraph_BP_ShadowPlane_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601FA8D RID: 129677 RVA: 0x0091759B File Offset: 0x0091579B
		protected BP_ShadowPlane_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400FBB8 RID: 64440
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Light/BP_ShadowPlane.BP_ShadowPlane_C";

		// Token: 0x0400FBB9 RID: 64441
		private static IntPtr _ClassPtr;

		// Token: 0x0400FBBA RID: 64442
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400FBBB RID: 64443
		internal static int __PropertyOffset_0;

		// Token: 0x0400FBBC RID: 64444
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400FBBD RID: 64445
		internal static int __PropertyOffset_1;

		// Token: 0x0400FBBE RID: 64446
		internal static int __PropertyOffset_2;

		// Token: 0x0400FBBF RID: 64447
		internal static int __PropertyOffset_3;

		// Token: 0x0400FBC0 RID: 64448
		internal static int __PropertyOffset_4;

		// Token: 0x0400FBC1 RID: 64449
		internal static int __PropertyOffset_5;

		// Token: 0x0400FBC2 RID: 64450
		private TMap<FName, float> _Scalar_Parameters;

		// Token: 0x0400FBC3 RID: 64451
		internal static int __PropertyOffset_6;

		// Token: 0x0400FBC4 RID: 64452
		private TMap<FName, FLinearColor> _Vector_Parameters;

		// Token: 0x0400FBC5 RID: 64453
		internal static int __PropertyOffset_7;

		// Token: 0x0400FBC6 RID: 64454
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<FName, UTexture> _Texture_Parameters;

		// Token: 0x0400FBC7 RID: 64455
		internal static int __PropertyOffset_8;

		// Token: 0x0400FBC8 RID: 64456
		internal static int __PropertyOffset_9;

		// Token: 0x0400FBC9 RID: 64457
		internal static int __PropertyOffset_10;

		// Token: 0x0400FBCA RID: 64458
		internal static int __PropertyOffset_11;

		// Token: 0x0400FBCB RID: 64459
		internal static int __PropertyOffset_12;

		// Token: 0x0400FBCC RID: 64460
		internal static int __PropertyOffset_13;

		// Token: 0x0400FBCD RID: 64461
		internal static int __PropertyOffset_14;

		// Token: 0x0400FBCE RID: 64462
		internal static int __PropertyOffset_15;

		// Token: 0x0400FBCF RID: 64463
		internal static int __PropertyOffset_16;

		// Token: 0x0400FBD0 RID: 64464
		internal static int __PropertyOffset_17;

		// Token: 0x0400FBD1 RID: 64465
		internal static int __PropertyOffset_18;

		// Token: 0x0400FBD2 RID: 64466
		internal static int __PropertyOffset_19;

		// Token: 0x0400FBD3 RID: 64467
		internal static int __PropertyOffset_20;

		// Token: 0x0400FBD4 RID: 64468
		internal static int __PropertyOffset_21;

		// Token: 0x0400FBD5 RID: 64469
		internal static int __PropertyOffset_22;

		// Token: 0x0400FBD6 RID: 64470
		internal static int __PropertyOffset_23;

		// Token: 0x0400FBD7 RID: 64471
		internal static int __PropertyOffset_24;

		// Token: 0x0400FBD8 RID: 64472
		internal static int __PropertyOffset_25;

		// Token: 0x0400FBD9 RID: 64473
		internal static int __PropertyOffset_26;

		// Token: 0x0400FBDA RID: 64474
		internal static int __PropertyOffset_27;

		// Token: 0x0400FBDB RID: 64475
		internal static int __PropertyOffset_28;

		// Token: 0x0400FBDC RID: 64476
		internal static int __PropertyOffset_29;

		// Token: 0x0400FBDD RID: 64477
		internal static int __PropertyOffset_30;

		// Token: 0x0400FBDE RID: 64478
		internal static int __PropertyOffset_31;

		// Token: 0x0400FBDF RID: 64479
		private static IntPtr __SetParameter_NativeFunctionPtr;

		// Token: 0x0400FBE0 RID: 64480
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0400FBE1 RID: 64481
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0400FBE2 RID: 64482
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0400FBE3 RID: 64483
		private static IntPtr __ReceiveDestroyed_NativeFunctionPtr;

		// Token: 0x0400FBE4 RID: 64484
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x0400FBE5 RID: 64485
		private static IntPtr __ExecuteUbergraph_BP_ShadowPlane_NativeFunctionPtr;

		// Token: 0x0200990D RID: 39181
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04031F6C RID: 204652
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x0200990E RID: 39182
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x04031F6D RID: 204653
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x0200990F RID: 39183
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 48)]
		protected ref struct __ExecuteUbergraph_BP_ShadowPlane_FunctionParams
		{
			// Token: 0x04031F6E RID: 204654
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
