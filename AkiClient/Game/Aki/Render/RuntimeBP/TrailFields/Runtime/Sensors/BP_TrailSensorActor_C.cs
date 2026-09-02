using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.TrailFields.Runtime.Sensors
{
	// Token: 0x02003A2F RID: 14895
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/TrailFields/Runtime/Sensors/BP_TrailSensorActor.BP_TrailSensorActor_C")]
	[UnrealStructLayout(1264, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1264)]
	public class BP_TrailSensorActor_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601EAAB RID: 125611 RVA: 0x008FB27F File Offset: 0x008F947F
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_TrailSensorActor_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/TrailFields/Runtime/Sensors/BP_TrailSensorActor.BP_TrailSensorActor_C");
			}
			return BP_TrailSensorActor_C._ClassPtr;
		}

		// Token: 0x0601EAAC RID: 125612 RVA: 0x008FB2A4 File Offset: 0x008F94A4
		public BP_TrailSensorActor_C() : this(BuiltinUtils.AllocNativeUObject(BP_TrailSensorActor_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601EAAD RID: 125613 RVA: 0x008FB2CC File Offset: 0x008F94CC
		[NullableContext(1)]
		public BP_TrailSensorActor_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_TrailSensorActor_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17002BC8 RID: 11208
		// (get) Token: 0x0601EAAE RID: 125614 RVA: 0x008FB300 File Offset: 0x008F9500
		// (set) Token: 0x0601EAAF RID: 125615 RVA: 0x008FB339 File Offset: 0x008F9539
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_TrailSensorActor_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_TrailSensorActor_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17002BC9 RID: 11209
		// (get) Token: 0x0601EAB0 RID: 125616 RVA: 0x008FB35A File Offset: 0x008F955A
		// (set) Token: 0x0601EAB1 RID: 125617 RVA: 0x008FB36E File Offset: 0x008F956E
		public unsafe UBillboardComponent Billboard
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBillboardComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrailSensorActor_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrailSensorActor_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17002BCA RID: 11210
		// (get) Token: 0x0601EAB2 RID: 125618 RVA: 0x008FB383 File Offset: 0x008F9583
		// (set) Token: 0x0601EAB3 RID: 125619 RVA: 0x008FB397 File Offset: 0x008F9597
		public unsafe UDecalComponent Decal
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UDecalComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrailSensorActor_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrailSensorActor_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17002BCB RID: 11211
		// (get) Token: 0x0601EAB4 RID: 125620 RVA: 0x008FB3AC File Offset: 0x008F95AC
		// (set) Token: 0x0601EAB5 RID: 125621 RVA: 0x008FB3C0 File Offset: 0x008F95C0
		public unsafe USceneComponent SceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrailSensorActor_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrailSensorActor_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17002BCC RID: 11212
		// (get) Token: 0x0601EAB6 RID: 125622 RVA: 0x008FB3D5 File Offset: 0x008F95D5
		// (set) Token: 0x0601EAB7 RID: 125623 RVA: 0x008FB3E9 File Offset: 0x008F95E9
		public unsafe FVector2D WorldSize
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TrailSensorActor_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TrailSensorActor_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17002BCD RID: 11213
		// (get) Token: 0x0601EAB8 RID: 125624 RVA: 0x008FB3FE File Offset: 0x008F95FE
		// (set) Token: 0x0601EAB9 RID: 125625 RVA: 0x008FB412 File Offset: 0x008F9612
		public unsafe UMaterialInstanceDynamic DrawMat
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrailSensorActor_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrailSensorActor_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17002BCE RID: 11214
		// (get) Token: 0x0601EABA RID: 125626 RVA: 0x008FB427 File Offset: 0x008F9627
		// (set) Token: 0x0601EABB RID: 125627 RVA: 0x008FB43B File Offset: 0x008F963B
		public unsafe UMaterialInstanceDynamic CopyMat
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrailSensorActor_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrailSensorActor_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x17002BCF RID: 11215
		// (get) Token: 0x0601EABC RID: 125628 RVA: 0x008FB450 File Offset: 0x008F9650
		// (set) Token: 0x0601EABD RID: 125629 RVA: 0x008FB464 File Offset: 0x008F9664
		public unsafe UMaterialInstanceDynamic EdgeMat
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrailSensorActor_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrailSensorActor_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x17002BD0 RID: 11216
		// (get) Token: 0x0601EABE RID: 125630 RVA: 0x008FB479 File Offset: 0x008F9679
		// (set) Token: 0x0601EABF RID: 125631 RVA: 0x008FB48D File Offset: 0x008F968D
		public unsafe UMaterialInstanceDynamic BlurMat
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrailSensorActor_C.__PropertyOffset_8);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrailSensorActor_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x17002BD1 RID: 11217
		// (get) Token: 0x0601EAC0 RID: 125632 RVA: 0x008FB4A2 File Offset: 0x008F96A2
		// (set) Token: 0x0601EAC1 RID: 125633 RVA: 0x008FB4B2 File Offset: 0x008F96B2
		public unsafe float MiddleRTSizeResolution
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TrailSensorActor_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TrailSensorActor_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17002BD2 RID: 11218
		// (get) Token: 0x0601EAC2 RID: 125634 RVA: 0x008FB4C3 File Offset: 0x008F96C3
		// (set) Token: 0x0601EAC3 RID: 125635 RVA: 0x008FB4D3 File Offset: 0x008F96D3
		public unsafe float PixelWidth_Blured
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TrailSensorActor_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TrailSensorActor_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17002BD3 RID: 11219
		// (get) Token: 0x0601EAC4 RID: 125636 RVA: 0x008FB4E4 File Offset: 0x008F96E4
		// (set) Token: 0x0601EAC5 RID: 125637 RVA: 0x008FB4F8 File Offset: 0x008F96F8
		public unsafe UTextureRenderTarget2D Drawn
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrailSensorActor_C.__PropertyOffset_11);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrailSensorActor_C.__PropertyOffset_11, value);
			}
		}

		// Token: 0x17002BD4 RID: 11220
		// (get) Token: 0x0601EAC6 RID: 125638 RVA: 0x008FB50D File Offset: 0x008F970D
		// (set) Token: 0x0601EAC7 RID: 125639 RVA: 0x008FB521 File Offset: 0x008F9721
		public unsafe UTextureRenderTarget2D Save
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrailSensorActor_C.__PropertyOffset_12);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrailSensorActor_C.__PropertyOffset_12, value);
			}
		}

		// Token: 0x17002BD5 RID: 11221
		// (get) Token: 0x0601EAC8 RID: 125640 RVA: 0x008FB536 File Offset: 0x008F9736
		// (set) Token: 0x0601EAC9 RID: 125641 RVA: 0x008FB54A File Offset: 0x008F974A
		public unsafe UTextureRenderTarget2D Edged
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrailSensorActor_C.__PropertyOffset_13);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrailSensorActor_C.__PropertyOffset_13, value);
			}
		}

		// Token: 0x17002BD6 RID: 11222
		// (get) Token: 0x0601EACA RID: 125642 RVA: 0x008FB55F File Offset: 0x008F975F
		// (set) Token: 0x0601EACB RID: 125643 RVA: 0x008FB573 File Offset: 0x008F9773
		public unsafe UTextureRenderTarget2D Blured
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrailSensorActor_C.__PropertyOffset_14);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrailSensorActor_C.__PropertyOffset_14, value);
			}
		}

		// Token: 0x17002BD7 RID: 11223
		// (get) Token: 0x0601EACC RID: 125644 RVA: 0x008FB588 File Offset: 0x008F9788
		// (set) Token: 0x0601EACD RID: 125645 RVA: 0x008FB59C File Offset: 0x008F979C
		public unsafe UTextureRenderTarget2D CurrentFrame
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrailSensorActor_C.__PropertyOffset_15);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrailSensorActor_C.__PropertyOffset_15, value);
			}
		}

		// Token: 0x17002BD8 RID: 11224
		// (get) Token: 0x0601EACE RID: 125646 RVA: 0x008FB5B1 File Offset: 0x008F97B1
		// (set) Token: 0x0601EACF RID: 125647 RVA: 0x008FB5C5 File Offset: 0x008F97C5
		public unsafe FVector2D Position
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TrailSensorActor_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TrailSensorActor_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x17002BD9 RID: 11225
		// (get) Token: 0x0601EAD0 RID: 125648 RVA: 0x008FB5DA File Offset: 0x008F97DA
		// (set) Token: 0x0601EAD1 RID: 125649 RVA: 0x008FB5EA File Offset: 0x008F97EA
		public unsafe float EdgeOffsetWidth
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TrailSensorActor_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TrailSensorActor_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x17002BDA RID: 11226
		// (get) Token: 0x0601EAD2 RID: 125650 RVA: 0x008FB5FB File Offset: 0x008F97FB
		// (set) Token: 0x0601EAD3 RID: 125651 RVA: 0x008FB60B File Offset: 0x008F980B
		public unsafe float BlurWidth
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TrailSensorActor_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TrailSensorActor_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x17002BDB RID: 11227
		// (get) Token: 0x0601EAD4 RID: 125652 RVA: 0x008FB61C File Offset: 0x008F981C
		// (set) Token: 0x0601EAD5 RID: 125653 RVA: 0x008FB655 File Offset: 0x008F9855
		[Nullable(1)]
		public TArray<STrailDrawInfo> Drawers
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<STrailDrawInfo> result;
				if ((result = this._Drawers) == null)
				{
					result = (this._Drawers = new TArray<STrailDrawInfo>(base.NativePtr + (IntPtr)BP_TrailSensorActor_C.__PropertyOffset_19, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Drawers.CopyAssign(value);
			}
		}

		// Token: 0x17002BDC RID: 11228
		// (get) Token: 0x0601EAD6 RID: 125654 RVA: 0x008FB663 File Offset: 0x008F9863
		// (set) Token: 0x0601EAD7 RID: 125655 RVA: 0x008FB673 File Offset: 0x008F9873
		public unsafe float Rotation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TrailSensorActor_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TrailSensorActor_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x17002BDD RID: 11229
		// (get) Token: 0x0601EAD8 RID: 125656 RVA: 0x008FB684 File Offset: 0x008F9884
		// (set) Token: 0x0601EAD9 RID: 125657 RVA: 0x008FB694 File Offset: 0x008F9894
		public unsafe float HeightOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TrailSensorActor_C.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TrailSensorActor_C.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x17002BDE RID: 11230
		// (get) Token: 0x0601EADA RID: 125658 RVA: 0x008FB6A5 File Offset: 0x008F98A5
		// (set) Token: 0x0601EADB RID: 125659 RVA: 0x008FB6B9 File Offset: 0x008F98B9
		public unsafe FVector2D LastPosition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TrailSensorActor_C.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TrailSensorActor_C.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x17002BDF RID: 11231
		// (get) Token: 0x0601EADC RID: 125660 RVA: 0x008FB6CE File Offset: 0x008F98CE
		// (set) Token: 0x0601EADD RID: 125661 RVA: 0x008FB6DE File Offset: 0x008F98DE
		public unsafe bool ShowGrid
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TrailSensorActor_C.__PropertyOffset_23) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TrailSensorActor_C.__PropertyOffset_23) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002BE0 RID: 11232
		// (get) Token: 0x0601EADE RID: 125662 RVA: 0x008FB6EF File Offset: 0x008F98EF
		// (set) Token: 0x0601EADF RID: 125663 RVA: 0x008FB6FF File Offset: 0x008F98FF
		public unsafe bool IsLandActor_
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TrailSensorActor_C.__PropertyOffset_24) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TrailSensorActor_C.__PropertyOffset_24) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002BE1 RID: 11233
		// (get) Token: 0x0601EAE0 RID: 125664 RVA: 0x008FB710 File Offset: 0x008F9910
		// (set) Token: 0x0601EAE1 RID: 125665 RVA: 0x008FB724 File Offset: 0x008F9924
		public unsafe UMaterialInterface DrawEdge_Inst
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInterface>(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrailSensorActor_C.__PropertyOffset_25);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrailSensorActor_C.__PropertyOffset_25, value);
			}
		}

		// Token: 0x17002BE2 RID: 11234
		// (get) Token: 0x0601EAE2 RID: 125666 RVA: 0x008FB739 File Offset: 0x008F9939
		// (set) Token: 0x0601EAE3 RID: 125667 RVA: 0x008FB74D File Offset: 0x008F994D
		public unsafe UMaterialInterface Blur_Inst
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInterface>(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrailSensorActor_C.__PropertyOffset_26);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrailSensorActor_C.__PropertyOffset_26, value);
			}
		}

		// Token: 0x17002BE3 RID: 11235
		// (get) Token: 0x0601EAE4 RID: 125668 RVA: 0x008FB762 File Offset: 0x008F9962
		// (set) Token: 0x0601EAE5 RID: 125669 RVA: 0x008FB772 File Offset: 0x008F9972
		public unsafe bool SpecificBluredRT
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TrailSensorActor_C.__PropertyOffset_27) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TrailSensorActor_C.__PropertyOffset_27) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002BE4 RID: 11236
		// (get) Token: 0x0601EAE6 RID: 125670 RVA: 0x008FB783 File Offset: 0x008F9983
		// (set) Token: 0x0601EAE7 RID: 125671 RVA: 0x008FB797 File Offset: 0x008F9997
		public unsafe UTextureRenderTarget2D NewBlurdRT
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrailSensorActor_C.__PropertyOffset_28);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrailSensorActor_C.__PropertyOffset_28, value);
			}
		}

		// Token: 0x17002BE5 RID: 11237
		// (get) Token: 0x0601EAE8 RID: 125672 RVA: 0x008FB7AC File Offset: 0x008F99AC
		// (set) Token: 0x0601EAE9 RID: 125673 RVA: 0x008FB7BC File Offset: 0x008F99BC
		public unsafe bool UpdatePositionEveryFrame
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TrailSensorActor_C.__PropertyOffset_29) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TrailSensorActor_C.__PropertyOffset_29) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002BE6 RID: 11238
		// (get) Token: 0x0601EAEA RID: 125674 RVA: 0x008FB7CD File Offset: 0x008F99CD
		// (set) Token: 0x0601EAEB RID: 125675 RVA: 0x008FB7DD File Offset: 0x008F99DD
		public unsafe bool UsePlayPosition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TrailSensorActor_C.__PropertyOffset_30) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TrailSensorActor_C.__PropertyOffset_30) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002BE7 RID: 11239
		// (get) Token: 0x0601EAEC RID: 125676 RVA: 0x008FB7EE File Offset: 0x008F99EE
		// (set) Token: 0x0601EAED RID: 125677 RVA: 0x008FB7FE File Offset: 0x008F99FE
		public unsafe int DynamicRTSize
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TrailSensorActor_C.__PropertyOffset_31);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TrailSensorActor_C.__PropertyOffset_31) = value;
			}
		}

		// Token: 0x17002BE8 RID: 11240
		// (get) Token: 0x0601EAEE RID: 125678 RVA: 0x008FB80F File Offset: 0x008F9A0F
		// (set) Token: 0x0601EAEF RID: 125679 RVA: 0x008FB823 File Offset: 0x008F9A23
		public unsafe UMaterialInterface Draw_Inst
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInterface>(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrailSensorActor_C.__PropertyOffset_32);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrailSensorActor_C.__PropertyOffset_32, value);
			}
		}

		// Token: 0x17002BE9 RID: 11241
		// (get) Token: 0x0601EAF0 RID: 125680 RVA: 0x008FB838 File Offset: 0x008F9A38
		// (set) Token: 0x0601EAF1 RID: 125681 RVA: 0x008FB84C File Offset: 0x008F9A4C
		public unsafe UMaterialInterface Copy_Inst
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInterface>(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrailSensorActor_C.__PropertyOffset_33);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrailSensorActor_C.__PropertyOffset_33, value);
			}
		}

		// Token: 0x0601EAF2 RID: 125682 RVA: 0x008FB864 File Offset: 0x008F9A64
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void IsEnable(ref bool Ret)
		{
			BP_TrailSensorActor_C.__IsEnable_FunctionParams* ptr = stackalloc BP_TrailSensorActor_C.__IsEnable_FunctionParams[(UIntPtr)18] + 15L / (long)sizeof(BP_TrailSensorActor_C.__IsEnable_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_TrailSensorActor_C.__IsEnable_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Ret = Ret;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_TrailSensorActor_C.__IsEnable_NativeFunctionPtr, (void*)ptr);
			Ret = ptr->Ret;
		}

		// Token: 0x0601EAF3 RID: 125683 RVA: 0x008FB8B4 File Offset: 0x008F9AB4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetPlayerActor(ref AActor PlayerActor)
		{
			BP_TrailSensorActor_C.__GetPlayerActor_FunctionParams* ptr = stackalloc BP_TrailSensorActor_C.__GetPlayerActor_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(BP_TrailSensorActor_C.__GetPlayerActor_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_TrailSensorActor_C.__GetPlayerActor_NativeFunctionPtr, (void*)ptr, 1);
			ref BP_TrailSensorActor_C.__GetPlayerActor_FunctionParams ptr2 = ref *ptr;
			AActor aactor = PlayerActor;
			ptr2.PlayerActor = ((aactor != null) ? aactor.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_TrailSensorActor_C.__GetPlayerActor_NativeFunctionPtr, (void*)ptr);
			PlayerActor = BuiltinUtils.GetOrCreateUObjectByNativePointer<AActor>(ptr->PlayerActor);
		}

		// Token: 0x0601EAF4 RID: 125684 RVA: 0x008FB918 File Offset: 0x008F9B18
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void DrawIntoRenderTargets()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_TrailSensorActor_C.__DrawIntoRenderTargets_NativeFunctionPtr, null);
		}

		// Token: 0x0601EAF5 RID: 125685 RVA: 0x008FB92C File Offset: 0x008F9B2C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Init_Render_Targets()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_TrailSensorActor_C.__Init_Render_Targets_NativeFunctionPtr, null);
		}

		// Token: 0x0601EAF6 RID: 125686 RVA: 0x008FB940 File Offset: 0x008F9B40
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual FVector2D UpDatePosition()
		{
			BP_TrailSensorActor_C.__UpDatePosition_FunctionParams* ptr = stackalloc BP_TrailSensorActor_C.__UpDatePosition_FunctionParams[(UIntPtr)463] + 15L / (long)sizeof(BP_TrailSensorActor_C.__UpDatePosition_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_TrailSensorActor_C.__UpDatePosition_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_TrailSensorActor_C.__UpDatePosition_NativeFunctionPtr, (void*)ptr);
			return ptr->__Result;
		}

		// Token: 0x0601EAF7 RID: 125687 RVA: 0x008FB988 File Offset: 0x008F9B88
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void CreateRTandMat()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_TrailSensorActor_C.__CreateRTandMat_NativeFunctionPtr, null);
		}

		// Token: 0x0601EAF8 RID: 125688 RVA: 0x008FB99C File Offset: 0x008F9B9C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void DrawToCurrentFrame(UCanvas Canvas, STrailDrawInfo DrawInfo)
		{
			BP_TrailSensorActor_C.__DrawToCurrentFrame_FunctionParams* ptr = stackalloc BP_TrailSensorActor_C.__DrawToCurrentFrame_FunctionParams[(UIntPtr)151] + 15L / (long)sizeof(BP_TrailSensorActor_C.__DrawToCurrentFrame_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_TrailSensorActor_C.__DrawToCurrentFrame_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Canvas = ((Canvas != null) ? Canvas.NativePtr : IntPtr.Zero);
			if (DrawInfo != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(STrailDrawInfo.StaticStruct(), &ptr->DrawInfo, DrawInfo.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_TrailSensorActor_C.__DrawToCurrentFrame_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601EAF9 RID: 125689 RVA: 0x008FBA16 File Offset: 0x008F9C16
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_TrailSensorActor_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0601EAFA RID: 125690 RVA: 0x008FBA2A File Offset: 0x008F9C2A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_TrailSensorActor_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601EAFB RID: 125691 RVA: 0x008FBA3F File Offset: 0x008F9C3F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Draw()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_TrailSensorActor_C.__Draw_NativeFunctionPtr, null);
		}

		// Token: 0x0601EAFC RID: 125692 RVA: 0x008FBA53 File Offset: 0x008F9C53
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void DrawFinished()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_TrailSensorActor_C.__DrawFinished_NativeFunctionPtr, null);
		}

		// Token: 0x0601EAFD RID: 125693 RVA: 0x008FBA67 File Offset: 0x008F9C67
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_TrailSensorActor_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0601EAFE RID: 125694 RVA: 0x008FBA7B File Offset: 0x008F9C7B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_TrailSensorActor_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601EAFF RID: 125695 RVA: 0x008FBA90 File Offset: 0x008F9C90
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_TrailSensorActor_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_TrailSensorActor_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_TrailSensorActor_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_TrailSensorActor_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_TrailSensorActor_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601EB00 RID: 125696 RVA: 0x008FBAD8 File Offset: 0x008F9CD8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_TrailSensorActor_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_TrailSensorActor_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_TrailSensorActor_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_TrailSensorActor_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_TrailSensorActor_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601EB01 RID: 125697 RVA: 0x008FBB20 File Offset: 0x008F9D20
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_TrailSensorActor(int EntryPoint)
		{
			BP_TrailSensorActor_C.__ExecuteUbergraph_BP_TrailSensorActor_FunctionParams* ptr = stackalloc BP_TrailSensorActor_C.__ExecuteUbergraph_BP_TrailSensorActor_FunctionParams[(UIntPtr)55] + 15L / (long)sizeof(BP_TrailSensorActor_C.__ExecuteUbergraph_BP_TrailSensorActor_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_TrailSensorActor_C.__ExecuteUbergraph_BP_TrailSensorActor_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_TrailSensorActor_C.__ExecuteUbergraph_BP_TrailSensorActor_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601EB02 RID: 125698 RVA: 0x008FBB67 File Offset: 0x008F9D67
		protected BP_TrailSensorActor_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400F208 RID: 61960
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/TrailFields/Runtime/Sensors/BP_TrailSensorActor.BP_TrailSensorActor_C";

		// Token: 0x0400F209 RID: 61961
		private static IntPtr _ClassPtr;

		// Token: 0x0400F20A RID: 61962
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400F20B RID: 61963
		internal static int __PropertyOffset_0;

		// Token: 0x0400F20C RID: 61964
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400F20D RID: 61965
		internal static int __PropertyOffset_1;

		// Token: 0x0400F20E RID: 61966
		internal static int __PropertyOffset_2;

		// Token: 0x0400F20F RID: 61967
		internal static int __PropertyOffset_3;

		// Token: 0x0400F210 RID: 61968
		internal static int __PropertyOffset_4;

		// Token: 0x0400F211 RID: 61969
		internal static int __PropertyOffset_5;

		// Token: 0x0400F212 RID: 61970
		internal static int __PropertyOffset_6;

		// Token: 0x0400F213 RID: 61971
		internal static int __PropertyOffset_7;

		// Token: 0x0400F214 RID: 61972
		internal static int __PropertyOffset_8;

		// Token: 0x0400F215 RID: 61973
		internal static int __PropertyOffset_9;

		// Token: 0x0400F216 RID: 61974
		internal static int __PropertyOffset_10;

		// Token: 0x0400F217 RID: 61975
		internal static int __PropertyOffset_11;

		// Token: 0x0400F218 RID: 61976
		internal static int __PropertyOffset_12;

		// Token: 0x0400F219 RID: 61977
		internal static int __PropertyOffset_13;

		// Token: 0x0400F21A RID: 61978
		internal static int __PropertyOffset_14;

		// Token: 0x0400F21B RID: 61979
		internal static int __PropertyOffset_15;

		// Token: 0x0400F21C RID: 61980
		internal static int __PropertyOffset_16;

		// Token: 0x0400F21D RID: 61981
		internal static int __PropertyOffset_17;

		// Token: 0x0400F21E RID: 61982
		internal static int __PropertyOffset_18;

		// Token: 0x0400F21F RID: 61983
		internal static int __PropertyOffset_19;

		// Token: 0x0400F220 RID: 61984
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<STrailDrawInfo> _Drawers;

		// Token: 0x0400F221 RID: 61985
		internal static int __PropertyOffset_20;

		// Token: 0x0400F222 RID: 61986
		internal static int __PropertyOffset_21;

		// Token: 0x0400F223 RID: 61987
		internal static int __PropertyOffset_22;

		// Token: 0x0400F224 RID: 61988
		internal static int __PropertyOffset_23;

		// Token: 0x0400F225 RID: 61989
		internal static int __PropertyOffset_24;

		// Token: 0x0400F226 RID: 61990
		internal static int __PropertyOffset_25;

		// Token: 0x0400F227 RID: 61991
		internal static int __PropertyOffset_26;

		// Token: 0x0400F228 RID: 61992
		internal static int __PropertyOffset_27;

		// Token: 0x0400F229 RID: 61993
		internal static int __PropertyOffset_28;

		// Token: 0x0400F22A RID: 61994
		internal static int __PropertyOffset_29;

		// Token: 0x0400F22B RID: 61995
		internal static int __PropertyOffset_30;

		// Token: 0x0400F22C RID: 61996
		internal static int __PropertyOffset_31;

		// Token: 0x0400F22D RID: 61997
		internal static int __PropertyOffset_32;

		// Token: 0x0400F22E RID: 61998
		internal static int __PropertyOffset_33;

		// Token: 0x0400F22F RID: 61999
		private static IntPtr __IsEnable_NativeFunctionPtr;

		// Token: 0x0400F230 RID: 62000
		private static IntPtr __GetPlayerActor_NativeFunctionPtr;

		// Token: 0x0400F231 RID: 62001
		private static IntPtr __DrawIntoRenderTargets_NativeFunctionPtr;

		// Token: 0x0400F232 RID: 62002
		private static IntPtr __Init_Render_Targets_NativeFunctionPtr;

		// Token: 0x0400F233 RID: 62003
		private static IntPtr __UpDatePosition_NativeFunctionPtr;

		// Token: 0x0400F234 RID: 62004
		private static IntPtr __CreateRTandMat_NativeFunctionPtr;

		// Token: 0x0400F235 RID: 62005
		private static IntPtr __DrawToCurrentFrame_NativeFunctionPtr;

		// Token: 0x0400F236 RID: 62006
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0400F237 RID: 62007
		private static IntPtr __Draw_NativeFunctionPtr;

		// Token: 0x0400F238 RID: 62008
		private static IntPtr __DrawFinished_NativeFunctionPtr;

		// Token: 0x0400F239 RID: 62009
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0400F23A RID: 62010
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0400F23B RID: 62011
		private static IntPtr __ExecuteUbergraph_BP_TrailSensorActor_NativeFunctionPtr;

		// Token: 0x020097E4 RID: 38884
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 3)]
		protected ref struct __IsEnable_FunctionParams
		{
			// Token: 0x04031DD6 RID: 204246
			[FieldOffset(0)]
			public bool Ret;
		}

		// Token: 0x020097E5 RID: 38885
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __GetPlayerActor_FunctionParams
		{
			// Token: 0x04031DD7 RID: 204247
			[FieldOffset(0)]
			public IntPtr PlayerActor;
		}

		// Token: 0x020097E6 RID: 38886
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 448)]
		protected ref struct __UpDatePosition_FunctionParams
		{
			// Token: 0x04031DD8 RID: 204248
			[FieldOffset(0)]
			public FVector2D __Result;
		}

		// Token: 0x020097E7 RID: 38887
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 136)]
		protected ref struct __DrawToCurrentFrame_FunctionParams
		{
			// Token: 0x04031DD9 RID: 204249
			[FieldOffset(0)]
			public IntPtr Canvas;

			// Token: 0x04031DDA RID: 204250
			[FieldOffset(8)]
			public byte DrawInfo;
		}

		// Token: 0x020097E8 RID: 38888
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04031DDB RID: 204251
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x020097E9 RID: 38889
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 40)]
		protected ref struct __ExecuteUbergraph_BP_TrailSensorActor_FunctionParams
		{
			// Token: 0x04031DDC RID: 204252
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
