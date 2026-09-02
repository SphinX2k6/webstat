using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Scene.Interface;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.SceneViedoPlay
{
	// Token: 0x02003B28 RID: 15144
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/SceneViedoPlay/MediaPlayForModel_Special.MediaPlayForModel_Special_C")]
	[UnrealStructLayout(1544, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1544)]
	public class MediaPlayForModel_Special_C : AKuroEditorTickActor, IUnrealUObject, IUnrealObject, IBPI_SceneBp_C, IUnrealBlueprintInterface, IUnrealInterface, IKuroMp4PlayerPreviewable, IUnrealNativeInterface
	{
		// Token: 0x060209F1 RID: 133617 RVA: 0x00931FD3 File Offset: 0x009301D3
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (MediaPlayForModel_Special_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/SceneViedoPlay/MediaPlayForModel_Special.MediaPlayForModel_Special_C");
			}
			return MediaPlayForModel_Special_C._ClassPtr;
		}

		// Token: 0x060209F2 RID: 133618 RVA: 0x00931FF7 File Offset: 0x009301F7
		int IKuroMp4PlayerPreviewable.InterfaceOffset()
		{
			return MediaPlayForModel_Special_C.__InterfaceOffset_IKuroMp4PlayerPreviewable;
		}

		// Token: 0x060209F3 RID: 133619 RVA: 0x00932000 File Offset: 0x00930200
		public MediaPlayForModel_Special_C() : this(BuiltinUtils.AllocNativeUObject(MediaPlayForModel_Special_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060209F4 RID: 133620 RVA: 0x00932028 File Offset: 0x00930228
		[NullableContext(1)]
		public MediaPlayForModel_Special_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(MediaPlayForModel_Special_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700366D RID: 13933
		// (get) Token: 0x060209F5 RID: 133621 RVA: 0x0093205C File Offset: 0x0093025C
		// (set) Token: 0x060209F6 RID: 133622 RVA: 0x00932095 File Offset: 0x00930295
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)MediaPlayForModel_Special_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)MediaPlayForModel_Special_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700366E RID: 13934
		// (get) Token: 0x060209F7 RID: 133623 RVA: 0x009320B6 File Offset: 0x009302B6
		// (set) Token: 0x060209F8 RID: 133624 RVA: 0x009320CA File Offset: 0x009302CA
		public unsafe USceneComponent VolumeLightSoucePos
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + MediaPlayForModel_Special_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + MediaPlayForModel_Special_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x1700366F RID: 13935
		// (get) Token: 0x060209F9 RID: 133625 RVA: 0x009320DF File Offset: 0x009302DF
		// (set) Token: 0x060209FA RID: 133626 RVA: 0x009320F3 File Offset: 0x009302F3
		public unsafe UStaticMeshComponent VolumeMesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + MediaPlayForModel_Special_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + MediaPlayForModel_Special_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17003670 RID: 13936
		// (get) Token: 0x060209FB RID: 133627 RVA: 0x00932108 File Offset: 0x00930308
		// (set) Token: 0x060209FC RID: 133628 RVA: 0x0093211C File Offset: 0x0093031C
		public unsafe UAkComponent Ak
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UAkComponent>(base.NativePtr / (IntPtr)sizeof(void*) + MediaPlayForModel_Special_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + MediaPlayForModel_Special_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17003671 RID: 13937
		// (get) Token: 0x060209FD RID: 133629 RVA: 0x00932131 File Offset: 0x00930331
		// (set) Token: 0x060209FE RID: 133630 RVA: 0x00932145 File Offset: 0x00930345
		public unsafe UStaticMeshComponent StaticMesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + MediaPlayForModel_Special_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + MediaPlayForModel_Special_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17003672 RID: 13938
		// (get) Token: 0x060209FF RID: 133631 RVA: 0x0093215A File Offset: 0x0093035A
		// (set) Token: 0x06020A00 RID: 133632 RVA: 0x0093216E File Offset: 0x0093036E
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + MediaPlayForModel_Special_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + MediaPlayForModel_Special_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17003673 RID: 13939
		// (get) Token: 0x06020A01 RID: 133633 RVA: 0x00932183 File Offset: 0x00930383
		// (set) Token: 0x06020A02 RID: 133634 RVA: 0x00932197 File Offset: 0x00930397
		public unsafe UMaterial ViedoMaterialTranSlucentTwoSide
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterial>(base.NativePtr / (IntPtr)sizeof(void*) + MediaPlayForModel_Special_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + MediaPlayForModel_Special_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x17003674 RID: 13940
		// (get) Token: 0x06020A03 RID: 133635 RVA: 0x009321AC File Offset: 0x009303AC
		// (set) Token: 0x06020A04 RID: 133636 RVA: 0x009321C0 File Offset: 0x009303C0
		public unsafe UMaterial ViedoMaterialTranSlucent
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterial>(base.NativePtr / (IntPtr)sizeof(void*) + MediaPlayForModel_Special_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + MediaPlayForModel_Special_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x17003675 RID: 13941
		// (get) Token: 0x06020A05 RID: 133637 RVA: 0x009321D5 File Offset: 0x009303D5
		// (set) Token: 0x06020A06 RID: 133638 RVA: 0x009321E9 File Offset: 0x009303E9
		public unsafe UMaterial ViedoMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterial>(base.NativePtr / (IntPtr)sizeof(void*) + MediaPlayForModel_Special_C.__PropertyOffset_8);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + MediaPlayForModel_Special_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x17003676 RID: 13942
		// (get) Token: 0x06020A07 RID: 133639 RVA: 0x009321FE File Offset: 0x009303FE
		// (set) Token: 0x06020A08 RID: 133640 RVA: 0x0093220E File Offset: 0x0093040E
		public unsafe float Intensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)MediaPlayForModel_Special_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)MediaPlayForModel_Special_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17003677 RID: 13943
		// (get) Token: 0x06020A09 RID: 133641 RVA: 0x0093221F File Offset: 0x0093041F
		// (set) Token: 0x06020A0A RID: 133642 RVA: 0x0093222F File Offset: 0x0093042F
		public unsafe float DarkIntensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)MediaPlayForModel_Special_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)MediaPlayForModel_Special_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17003678 RID: 13944
		// (get) Token: 0x06020A0B RID: 133643 RVA: 0x00932240 File Offset: 0x00930440
		// (set) Token: 0x06020A0C RID: 133644 RVA: 0x00932250 File Offset: 0x00930450
		public unsafe int AoiDistance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)MediaPlayForModel_Special_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)MediaPlayForModel_Special_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17003679 RID: 13945
		// (get) Token: 0x06020A0D RID: 133645 RVA: 0x00932261 File Offset: 0x00930461
		// (set) Token: 0x06020A0E RID: 133646 RVA: 0x00932271 File Offset: 0x00930471
		public unsafe bool Translucent
		{
			get
			{
				return *(base.NativePtr + (IntPtr)MediaPlayForModel_Special_C.__PropertyOffset_12) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)MediaPlayForModel_Special_C.__PropertyOffset_12) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700367A RID: 13946
		// (get) Token: 0x06020A0F RID: 133647 RVA: 0x00932282 File Offset: 0x00930482
		// (set) Token: 0x06020A10 RID: 133648 RVA: 0x00932292 File Offset: 0x00930492
		public unsafe bool TwoSide
		{
			get
			{
				return *(base.NativePtr + (IntPtr)MediaPlayForModel_Special_C.__PropertyOffset_13) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)MediaPlayForModel_Special_C.__PropertyOffset_13) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700367B RID: 13947
		// (get) Token: 0x06020A11 RID: 133649 RVA: 0x009322A3 File Offset: 0x009304A3
		// (set) Token: 0x06020A12 RID: 133650 RVA: 0x009322B3 File Offset: 0x009304B3
		public unsafe float Opacity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)MediaPlayForModel_Special_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)MediaPlayForModel_Special_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x1700367C RID: 13948
		// (get) Token: 0x06020A13 RID: 133651 RVA: 0x009322C4 File Offset: 0x009304C4
		// (set) Token: 0x06020A14 RID: 133652 RVA: 0x009322D8 File Offset: 0x009304D8
		public unsafe PDA_MediaPlayDataAsset_C MediaPlayDataAsset
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<PDA_MediaPlayDataAsset_C>(base.NativePtr / (IntPtr)sizeof(void*) + MediaPlayForModel_Special_C.__PropertyOffset_15);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + MediaPlayForModel_Special_C.__PropertyOffset_15, value);
			}
		}

		// Token: 0x1700367D RID: 13949
		// (get) Token: 0x06020A15 RID: 133653 RVA: 0x009322ED File Offset: 0x009304ED
		// (set) Token: 0x06020A16 RID: 133654 RVA: 0x00932301 File Offset: 0x00930501
		public unsafe UMediaPlayer ShareMediaPlayer
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMediaPlayer>(base.NativePtr / (IntPtr)sizeof(void*) + MediaPlayForModel_Special_C.__PropertyOffset_16);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + MediaPlayForModel_Special_C.__PropertyOffset_16, value);
			}
		}

		// Token: 0x1700367E RID: 13950
		// (get) Token: 0x06020A17 RID: 133655 RVA: 0x00932316 File Offset: 0x00930516
		// (set) Token: 0x06020A18 RID: 133656 RVA: 0x0093232A File Offset: 0x0093052A
		public unsafe UMediaTexture ShareMediaTexture
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMediaTexture>(base.NativePtr / (IntPtr)sizeof(void*) + MediaPlayForModel_Special_C.__PropertyOffset_17);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + MediaPlayForModel_Special_C.__PropertyOffset_17, value);
			}
		}

		// Token: 0x1700367F RID: 13951
		// (get) Token: 0x06020A19 RID: 133657 RVA: 0x0093233F File Offset: 0x0093053F
		// (set) Token: 0x06020A1A RID: 133658 RVA: 0x0093234F File Offset: 0x0093054F
		public unsafe bool IsMainPlayer
		{
			get
			{
				return *(base.NativePtr + (IntPtr)MediaPlayForModel_Special_C.__PropertyOffset_18) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)MediaPlayForModel_Special_C.__PropertyOffset_18) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003680 RID: 13952
		// (get) Token: 0x06020A1B RID: 133659 RVA: 0x00932360 File Offset: 0x00930560
		// (set) Token: 0x06020A1C RID: 133660 RVA: 0x00932370 File Offset: 0x00930570
		public unsafe bool isPlaying
		{
			get
			{
				return *(base.NativePtr + (IntPtr)MediaPlayForModel_Special_C.__PropertyOffset_19) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)MediaPlayForModel_Special_C.__PropertyOffset_19) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003681 RID: 13953
		// (get) Token: 0x06020A1D RID: 133661 RVA: 0x00932381 File Offset: 0x00930581
		// (set) Token: 0x06020A1E RID: 133662 RVA: 0x00932391 File Offset: 0x00930591
		public unsafe bool DrawDebugAoi
		{
			get
			{
				return *(base.NativePtr + (IntPtr)MediaPlayForModel_Special_C.__PropertyOffset_20) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)MediaPlayForModel_Special_C.__PropertyOffset_20) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003682 RID: 13954
		// (get) Token: 0x06020A1F RID: 133663 RVA: 0x009323A2 File Offset: 0x009305A2
		// (set) Token: 0x06020A20 RID: 133664 RVA: 0x009323B2 File Offset: 0x009305B2
		public unsafe bool isStopOnHide
		{
			get
			{
				return *(base.NativePtr + (IntPtr)MediaPlayForModel_Special_C.__PropertyOffset_21) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)MediaPlayForModel_Special_C.__PropertyOffset_21) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003683 RID: 13955
		// (get) Token: 0x06020A21 RID: 133665 RVA: 0x009323C3 File Offset: 0x009305C3
		// (set) Token: 0x06020A22 RID: 133666 RVA: 0x009323D3 File Offset: 0x009305D3
		public unsafe bool enableQualityLevel
		{
			get
			{
				return *(base.NativePtr + (IntPtr)MediaPlayForModel_Special_C.__PropertyOffset_22) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)MediaPlayForModel_Special_C.__PropertyOffset_22) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003684 RID: 13956
		// (get) Token: 0x06020A23 RID: 133667 RVA: 0x009323E4 File Offset: 0x009305E4
		// (set) Token: 0x06020A24 RID: 133668 RVA: 0x0093241D File Offset: 0x0093061D
		[Nullable(1)]
		public TArray<int> QualityDistanceList
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<int> result;
				if ((result = this._QualityDistanceList) == null)
				{
					result = (this._QualityDistanceList = new TArray<int>(base.NativePtr + (IntPtr)MediaPlayForModel_Special_C.__PropertyOffset_23, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.QualityDistanceList.CopyAssign(value);
			}
		}

		// Token: 0x17003685 RID: 13957
		// (get) Token: 0x06020A25 RID: 133669 RVA: 0x0093242B File Offset: 0x0093062B
		// (set) Token: 0x06020A26 RID: 133670 RVA: 0x0093243F File Offset: 0x0093063F
		public unsafe UMaterialInstanceDynamic DynamicMaterialInstance
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + MediaPlayForModel_Special_C.__PropertyOffset_24);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + MediaPlayForModel_Special_C.__PropertyOffset_24, value);
			}
		}

		// Token: 0x17003686 RID: 13958
		// (get) Token: 0x06020A27 RID: 133671 RVA: 0x00932454 File Offset: 0x00930654
		// (set) Token: 0x06020A28 RID: 133672 RVA: 0x00932464 File Offset: 0x00930664
		public unsafe float MP4编辑器最大预览距离
		{
			get
			{
				return *(base.NativePtr + (IntPtr)MediaPlayForModel_Special_C.__PropertyOffset_25);
			}
			set
			{
				*(base.NativePtr + (IntPtr)MediaPlayForModel_Special_C.__PropertyOffset_25) = value;
			}
		}

		// Token: 0x17003687 RID: 13959
		// (get) Token: 0x06020A29 RID: 133673 RVA: 0x00932475 File Offset: 0x00930675
		// (set) Token: 0x06020A2A RID: 133674 RVA: 0x00932485 File Offset: 0x00930685
		public unsafe bool bPostProcess
		{
			get
			{
				return *(base.NativePtr + (IntPtr)MediaPlayForModel_Special_C.__PropertyOffset_26) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)MediaPlayForModel_Special_C.__PropertyOffset_26) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003688 RID: 13960
		// (get) Token: 0x06020A2B RID: 133675 RVA: 0x00932496 File Offset: 0x00930696
		// (set) Token: 0x06020A2C RID: 133676 RVA: 0x009324AA File Offset: 0x009306AA
		public unsafe UMaterialInstance VolumeLightMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + MediaPlayForModel_Special_C.__PropertyOffset_27);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + MediaPlayForModel_Special_C.__PropertyOffset_27, value);
			}
		}

		// Token: 0x17003689 RID: 13961
		// (get) Token: 0x06020A2D RID: 133677 RVA: 0x009324BF File Offset: 0x009306BF
		// (set) Token: 0x06020A2E RID: 133678 RVA: 0x009324D3 File Offset: 0x009306D3
		public unsafe UMaterialInstanceDynamic VolumeLightMID
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + MediaPlayForModel_Special_C.__PropertyOffset_28);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + MediaPlayForModel_Special_C.__PropertyOffset_28, value);
			}
		}

		// Token: 0x1700368A RID: 13962
		// (get) Token: 0x06020A2F RID: 133679 RVA: 0x009324E8 File Offset: 0x009306E8
		// (set) Token: 0x06020A30 RID: 133680 RVA: 0x009324FC File Offset: 0x009306FC
		public unsafe UMaterialInstanceDynamic MediaTexPostProcessDMI
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + MediaPlayForModel_Special_C.__PropertyOffset_29);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + MediaPlayForModel_Special_C.__PropertyOffset_29, value);
			}
		}

		// Token: 0x1700368B RID: 13963
		// (get) Token: 0x06020A31 RID: 133681 RVA: 0x00932511 File Offset: 0x00930711
		// (set) Token: 0x06020A32 RID: 133682 RVA: 0x00932525 File Offset: 0x00930725
		public unsafe UMaterialInterface MediaTexPostProcessMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInterface>(base.NativePtr / (IntPtr)sizeof(void*) + MediaPlayForModel_Special_C.__PropertyOffset_30);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + MediaPlayForModel_Special_C.__PropertyOffset_30, value);
			}
		}

		// Token: 0x1700368C RID: 13964
		// (get) Token: 0x06020A33 RID: 133683 RVA: 0x0093253A File Offset: 0x0093073A
		// (set) Token: 0x06020A34 RID: 133684 RVA: 0x0093254A File Offset: 0x0093074A
		public unsafe int PostTexHeight
		{
			get
			{
				return *(base.NativePtr + (IntPtr)MediaPlayForModel_Special_C.__PropertyOffset_31);
			}
			set
			{
				*(base.NativePtr + (IntPtr)MediaPlayForModel_Special_C.__PropertyOffset_31) = value;
			}
		}

		// Token: 0x1700368D RID: 13965
		// (get) Token: 0x06020A35 RID: 133685 RVA: 0x0093255B File Offset: 0x0093075B
		// (set) Token: 0x06020A36 RID: 133686 RVA: 0x0093256B File Offset: 0x0093076B
		public unsafe int PostTexWidth
		{
			get
			{
				return *(base.NativePtr + (IntPtr)MediaPlayForModel_Special_C.__PropertyOffset_32);
			}
			set
			{
				*(base.NativePtr + (IntPtr)MediaPlayForModel_Special_C.__PropertyOffset_32) = value;
			}
		}

		// Token: 0x1700368E RID: 13966
		// (get) Token: 0x06020A37 RID: 133687 RVA: 0x0093257C File Offset: 0x0093077C
		// (set) Token: 0x06020A38 RID: 133688 RVA: 0x00932590 File Offset: 0x00930790
		public unsafe UTextureRenderTarget2D MediaTexPostProcessRT
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + MediaPlayForModel_Special_C.__PropertyOffset_33);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + MediaPlayForModel_Special_C.__PropertyOffset_33, value);
			}
		}

		// Token: 0x1700368F RID: 13967
		// (get) Token: 0x06020A39 RID: 133689 RVA: 0x009325A5 File Offset: 0x009307A5
		// (set) Token: 0x06020A3A RID: 133690 RVA: 0x009325B5 File Offset: 0x009307B5
		public unsafe bool bEnableVolumeLight
		{
			get
			{
				return *(base.NativePtr + (IntPtr)MediaPlayForModel_Special_C.__PropertyOffset_34) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)MediaPlayForModel_Special_C.__PropertyOffset_34) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003690 RID: 13968
		// (get) Token: 0x06020A3B RID: 133691 RVA: 0x009325C6 File Offset: 0x009307C6
		// (set) Token: 0x06020A3C RID: 133692 RVA: 0x009325DA File Offset: 0x009307DA
		public unsafe UMediaPlayer ShareMediaPlayer_EditorPreview
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMediaPlayer>(base.NativePtr / (IntPtr)sizeof(void*) + MediaPlayForModel_Special_C.__PropertyOffset_35);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + MediaPlayForModel_Special_C.__PropertyOffset_35, value);
			}
		}

		// Token: 0x17003691 RID: 13969
		// (get) Token: 0x06020A3D RID: 133693 RVA: 0x009325EF File Offset: 0x009307EF
		// (set) Token: 0x06020A3E RID: 133694 RVA: 0x00932603 File Offset: 0x00930803
		public unsafe UMediaTexture ShareMediaTexture_EditorPreview
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMediaTexture>(base.NativePtr / (IntPtr)sizeof(void*) + MediaPlayForModel_Special_C.__PropertyOffset_36);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + MediaPlayForModel_Special_C.__PropertyOffset_36, value);
			}
		}

		// Token: 0x06020A3F RID: 133695 RVA: 0x00932618 File Offset: 0x00930818
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void ShouldStopOnHide(ref bool ret)
		{
			MediaPlayForModel_Special_C.__ShouldStopOnHide_FunctionParams* ptr = stackalloc MediaPlayForModel_Special_C.__ShouldStopOnHide_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(MediaPlayForModel_Special_C.__ShouldStopOnHide_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(MediaPlayForModel_Special_C.__ShouldStopOnHide_NativeFunctionPtr, (void*)ptr, 1);
			ptr->ret = ret;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, MediaPlayForModel_Special_C.__ShouldStopOnHide_NativeFunctionPtr, (void*)ptr);
			ret = ptr->ret;
		}

		// Token: 0x06020A40 RID: 133696 RVA: 0x00932668 File Offset: 0x00930868
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetAoiRange(ref int ret)
		{
			MediaPlayForModel_Special_C.__GetAoiRange_FunctionParams* ptr = stackalloc MediaPlayForModel_Special_C.__GetAoiRange_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(MediaPlayForModel_Special_C.__GetAoiRange_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(MediaPlayForModel_Special_C.__GetAoiRange_NativeFunctionPtr, (void*)ptr, 1);
			ptr->ret = ret;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, MediaPlayForModel_Special_C.__GetAoiRange_NativeFunctionPtr, (void*)ptr);
			ret = ptr->ret;
		}

		// Token: 0x06020A41 RID: 133697 RVA: 0x009326B7 File Offset: 0x009308B7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void DownSampleMediaTex()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, MediaPlayForModel_Special_C.__DownSampleMediaTex_NativeFunctionPtr, null);
		}

		// Token: 0x06020A42 RID: 133698 RVA: 0x009326CB File Offset: 0x009308CB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 编辑器强制停止()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, MediaPlayForModel_Special_C.__编辑器强制停止_NativeFunctionPtr, null);
		}

		// Token: 0x06020A43 RID: 133699 RVA: 0x009326DF File Offset: 0x009308DF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 编辑器强制播放()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, MediaPlayForModel_Special_C.__编辑器强制播放_NativeFunctionPtr, null);
		}

		// Token: 0x06020A44 RID: 133700 RVA: 0x009326F3 File Offset: 0x009308F3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 编辑器_MP4播放器初始化()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, MediaPlayForModel_Special_C.__编辑器_MP4播放器初始化_NativeFunctionPtr, null);
		}

		// Token: 0x06020A45 RID: 133701 RVA: 0x00932707 File Offset: 0x00930907
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 编辑器MP4播放器停止预览()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, MediaPlayForModel_Special_C.__编辑器MP4播放器停止预览_NativeFunctionPtr, null);
		}

		// Token: 0x06020A46 RID: 133702 RVA: 0x0093271B File Offset: 0x0093091B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 编辑器MP4播放器开始预览()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, MediaPlayForModel_Special_C.__编辑器MP4播放器开始预览_NativeFunctionPtr, null);
		}

		// Token: 0x06020A47 RID: 133703 RVA: 0x00932730 File Offset: 0x00930930
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetSource(ref UMediaSource MediaSource)
		{
			MediaPlayForModel_Special_C.__GetSource_FunctionParams* ptr = stackalloc MediaPlayForModel_Special_C.__GetSource_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(MediaPlayForModel_Special_C.__GetSource_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(MediaPlayForModel_Special_C.__GetSource_NativeFunctionPtr, (void*)ptr, 1);
			ref MediaPlayForModel_Special_C.__GetSource_FunctionParams ptr2 = ref *ptr;
			UMediaSource umediaSource = MediaSource;
			ptr2.MediaSource = ((umediaSource != null) ? umediaSource.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, MediaPlayForModel_Special_C.__GetSource_NativeFunctionPtr, (void*)ptr);
			MediaSource = BuiltinUtils.GetOrCreateUObjectByNativePointer<UMediaSource>(ptr->MediaSource);
		}

		// Token: 0x06020A48 RID: 133704 RVA: 0x00932794 File Offset: 0x00930994
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Init()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, MediaPlayForModel_Special_C.__Init_NativeFunctionPtr, null);
		}

		// Token: 0x06020A49 RID: 133705 RVA: 0x009327A8 File Offset: 0x009309A8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void HideVolumeLight()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, MediaPlayForModel_Special_C.__HideVolumeLight_NativeFunctionPtr, null);
		}

		// Token: 0x06020A4A RID: 133706 RVA: 0x009327BC File Offset: 0x009309BC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void ShowVolumeLight()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, MediaPlayForModel_Special_C.__ShowVolumeLight_NativeFunctionPtr, null);
		}

		// Token: 0x06020A4B RID: 133707 RVA: 0x009327D0 File Offset: 0x009309D0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Release_Player_Asset()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, MediaPlayForModel_Special_C.__Release_Player_Asset_NativeFunctionPtr, null);
		}

		// Token: 0x06020A4C RID: 133708 RVA: 0x009327E4 File Offset: 0x009309E4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void AllocatePlayerAsset(UMediaPlayer player, UMediaTexture texture)
		{
			MediaPlayForModel_Special_C.__AllocatePlayerAsset_FunctionParams* ptr = stackalloc MediaPlayForModel_Special_C.__AllocatePlayerAsset_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(MediaPlayForModel_Special_C.__AllocatePlayerAsset_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(MediaPlayForModel_Special_C.__AllocatePlayerAsset_NativeFunctionPtr, (void*)ptr, 1);
			ptr->player = ((player != null) ? player.NativePtr : IntPtr.Zero);
			ptr->texture = ((texture != null) ? texture.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, MediaPlayForModel_Special_C.__AllocatePlayerAsset_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06020A4D RID: 133709 RVA: 0x00932850 File Offset: 0x00930A50
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OpenSource(ref bool Successs)
		{
			MediaPlayForModel_Special_C.__OpenSource_FunctionParams* ptr = stackalloc MediaPlayForModel_Special_C.__OpenSource_FunctionParams[(UIntPtr)127] + 15L / (long)sizeof(MediaPlayForModel_Special_C.__OpenSource_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(MediaPlayForModel_Special_C.__OpenSource_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Successs = Successs;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, MediaPlayForModel_Special_C.__OpenSource_NativeFunctionPtr, (void*)ptr);
			Successs = ptr->Successs;
		}

		// Token: 0x06020A4E RID: 133710 RVA: 0x0093289F File Offset: 0x00930A9F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void CloseSource()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, MediaPlayForModel_Special_C.__CloseSource_NativeFunctionPtr, null);
		}

		// Token: 0x06020A4F RID: 133711 RVA: 0x009328B3 File Offset: 0x00930AB3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, MediaPlayForModel_Special_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06020A50 RID: 133712 RVA: 0x009328C7 File Offset: 0x00930AC7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, MediaPlayForModel_Special_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06020A51 RID: 133713 RVA: 0x009328DC File Offset: 0x00930ADC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void TickOutside()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, MediaPlayForModel_Special_C.__TickOutside_NativeFunctionPtr, null);
		}

		// Token: 0x06020A52 RID: 133714 RVA: 0x009328F0 File Offset: 0x00930AF0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Pause()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, MediaPlayForModel_Special_C.__Pause_NativeFunctionPtr, null);
		}

		// Token: 0x06020A53 RID: 133715 RVA: 0x00932904 File Offset: 0x00930B04
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Resume()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, MediaPlayForModel_Special_C.__Resume_NativeFunctionPtr, null);
		}

		// Token: 0x06020A54 RID: 133716 RVA: 0x00932918 File Offset: 0x00930B18
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, MediaPlayForModel_Special_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06020A55 RID: 133717 RVA: 0x0093292C File Offset: 0x00930B2C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, MediaPlayForModel_Special_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06020A56 RID: 133718 RVA: 0x00932944 File Offset: 0x00930B44
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			MediaPlayForModel_Special_C.__EditorTick_FunctionParams* ptr = stackalloc MediaPlayForModel_Special_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(MediaPlayForModel_Special_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(MediaPlayForModel_Special_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, MediaPlayForModel_Special_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06020A57 RID: 133719 RVA: 0x0093298C File Offset: 0x00930B8C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			MediaPlayForModel_Special_C.__EditorTick_FunctionParams* ptr = stackalloc MediaPlayForModel_Special_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(MediaPlayForModel_Special_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(MediaPlayForModel_Special_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, MediaPlayForModel_Special_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06020A58 RID: 133720 RVA: 0x009329D3 File Offset: 0x00930BD3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Start()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, MediaPlayForModel_Special_C.__Start_NativeFunctionPtr, null);
		}

		// Token: 0x06020A59 RID: 133721 RVA: 0x009329E7 File Offset: 0x00930BE7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Stop()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, MediaPlayForModel_Special_C.__Stop_NativeFunctionPtr, null);
		}

		// Token: 0x06020A5A RID: 133722 RVA: 0x009329FC File Offset: 0x00930BFC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveEndPlay(EEndPlayReason EndPlayReason)
		{
			MediaPlayForModel_Special_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc MediaPlayForModel_Special_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(MediaPlayForModel_Special_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(MediaPlayForModel_Special_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, MediaPlayForModel_Special_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06020A5B RID: 133723 RVA: 0x00932A48 File Offset: 0x00930C48
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveEndPlay_Implementation(EEndPlayReason EndPlayReason)
		{
			MediaPlayForModel_Special_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc MediaPlayForModel_Special_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(MediaPlayForModel_Special_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(MediaPlayForModel_Special_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, MediaPlayForModel_Special_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06020A5C RID: 133724 RVA: 0x00932A94 File Offset: 0x00930C94
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void PlaySound()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, MediaPlayForModel_Special_C.__PlaySound_NativeFunctionPtr, null);
		}

		// Token: 0x06020A5D RID: 133725 RVA: 0x00932AA8 File Offset: 0x00930CA8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void CloseSound()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, MediaPlayForModel_Special_C.__CloseSound_NativeFunctionPtr, null);
		}

		// Token: 0x06020A5E RID: 133726 RVA: 0x00932ABC File Offset: 0x00930CBC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OnMp4PlayRequested(UMediaPlayer InPlayer, UMediaTexture InTexture)
		{
			MediaPlayForModel_Special_C.__OnMp4PlayRequested_FunctionParams* ptr = stackalloc MediaPlayForModel_Special_C.__OnMp4PlayRequested_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(MediaPlayForModel_Special_C.__OnMp4PlayRequested_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(MediaPlayForModel_Special_C.__OnMp4PlayRequested_NativeFunctionPtr, (void*)ptr, 1);
			ptr->InPlayer = ((InPlayer != null) ? InPlayer.NativePtr : IntPtr.Zero);
			ptr->InTexture = ((InTexture != null) ? InTexture.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, MediaPlayForModel_Special_C.__OnMp4PlayRequested_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06020A5F RID: 133727 RVA: 0x00932B28 File Offset: 0x00930D28
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void OnMp4PlayRequested_Implementation(UMediaPlayer InPlayer, UMediaTexture InTexture)
		{
			MediaPlayForModel_Special_C.__OnMp4PlayRequested_FunctionParams* ptr = stackalloc MediaPlayForModel_Special_C.__OnMp4PlayRequested_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(MediaPlayForModel_Special_C.__OnMp4PlayRequested_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(MediaPlayForModel_Special_C.__OnMp4PlayRequested_NativeFunctionPtr, (void*)ptr, 1);
			ptr->InPlayer = ((InPlayer != null) ? InPlayer.NativePtr : IntPtr.Zero);
			ptr->InTexture = ((InTexture != null) ? InTexture.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallUFunction(base.NativePtr, MediaPlayForModel_Special_C.__OnMp4PlayRequested_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06020A60 RID: 133728 RVA: 0x00932B94 File Offset: 0x00930D94
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnMp4StopRequested()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, MediaPlayForModel_Special_C.__OnMp4StopRequested_NativeFunctionPtr, null);
		}

		// Token: 0x06020A61 RID: 133729 RVA: 0x00932BA8 File Offset: 0x00930DA8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void OnMp4StopRequested_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, MediaPlayForModel_Special_C.__OnMp4StopRequested_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06020A62 RID: 133730 RVA: 0x00932BBD File Offset: 0x00930DBD
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void EditorInit()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, MediaPlayForModel_Special_C.__EditorInit_NativeFunctionPtr, null);
		}

		// Token: 0x06020A63 RID: 133731 RVA: 0x00932BD1 File Offset: 0x00930DD1
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void EditorInit_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, MediaPlayForModel_Special_C.__EditorInit_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06020A64 RID: 133732 RVA: 0x00932BE8 File Offset: 0x00930DE8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			MediaPlayForModel_Special_C.__ReceiveTick_FunctionParams* ptr = stackalloc MediaPlayForModel_Special_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(MediaPlayForModel_Special_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(MediaPlayForModel_Special_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, MediaPlayForModel_Special_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06020A65 RID: 133733 RVA: 0x00932C30 File Offset: 0x00930E30
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			MediaPlayForModel_Special_C.__ReceiveTick_FunctionParams* ptr = stackalloc MediaPlayForModel_Special_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(MediaPlayForModel_Special_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(MediaPlayForModel_Special_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, MediaPlayForModel_Special_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06020A66 RID: 133734 RVA: 0x00932C77 File Offset: 0x00930E77
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnMediaAsyncClosed()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, MediaPlayForModel_Special_C.__OnMediaAsyncClosed_NativeFunctionPtr, null);
		}

		// Token: 0x06020A67 RID: 133735 RVA: 0x00932C8B File Offset: 0x00930E8B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void CustomEvent_0()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, MediaPlayForModel_Special_C.__CustomEvent_0_NativeFunctionPtr, null);
		}

		// Token: 0x06020A68 RID: 133736 RVA: 0x00932CA0 File Offset: 0x00930EA0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_MediaPlayForModel_Special(int EntryPoint)
		{
			MediaPlayForModel_Special_C.__ExecuteUbergraph_MediaPlayForModel_Special_FunctionParams* ptr = stackalloc MediaPlayForModel_Special_C.__ExecuteUbergraph_MediaPlayForModel_Special_FunctionParams[(UIntPtr)327] + 15L / (long)sizeof(MediaPlayForModel_Special_C.__ExecuteUbergraph_MediaPlayForModel_Special_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(MediaPlayForModel_Special_C.__ExecuteUbergraph_MediaPlayForModel_Special_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, MediaPlayForModel_Special_C.__ExecuteUbergraph_MediaPlayForModel_Special_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06020A69 RID: 133737 RVA: 0x00932CEA File Offset: 0x00930EEA
		protected MediaPlayForModel_Special_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401054C RID: 66892
		internal static int __InterfaceOffset_IKuroMp4PlayerPreviewable;

		// Token: 0x0401054D RID: 66893
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/SceneViedoPlay/MediaPlayForModel_Special.MediaPlayForModel_Special_C";

		// Token: 0x0401054E RID: 66894
		private static IntPtr _ClassPtr;

		// Token: 0x0401054F RID: 66895
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04010550 RID: 66896
		internal static int __PropertyOffset_0;

		// Token: 0x04010551 RID: 66897
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04010552 RID: 66898
		internal static int __PropertyOffset_1;

		// Token: 0x04010553 RID: 66899
		internal static int __PropertyOffset_2;

		// Token: 0x04010554 RID: 66900
		internal static int __PropertyOffset_3;

		// Token: 0x04010555 RID: 66901
		internal static int __PropertyOffset_4;

		// Token: 0x04010556 RID: 66902
		internal static int __PropertyOffset_5;

		// Token: 0x04010557 RID: 66903
		internal static int __PropertyOffset_6;

		// Token: 0x04010558 RID: 66904
		internal static int __PropertyOffset_7;

		// Token: 0x04010559 RID: 66905
		internal static int __PropertyOffset_8;

		// Token: 0x0401055A RID: 66906
		internal static int __PropertyOffset_9;

		// Token: 0x0401055B RID: 66907
		internal static int __PropertyOffset_10;

		// Token: 0x0401055C RID: 66908
		internal static int __PropertyOffset_11;

		// Token: 0x0401055D RID: 66909
		internal static int __PropertyOffset_12;

		// Token: 0x0401055E RID: 66910
		internal static int __PropertyOffset_13;

		// Token: 0x0401055F RID: 66911
		internal static int __PropertyOffset_14;

		// Token: 0x04010560 RID: 66912
		internal static int __PropertyOffset_15;

		// Token: 0x04010561 RID: 66913
		internal static int __PropertyOffset_16;

		// Token: 0x04010562 RID: 66914
		internal static int __PropertyOffset_17;

		// Token: 0x04010563 RID: 66915
		internal static int __PropertyOffset_18;

		// Token: 0x04010564 RID: 66916
		internal static int __PropertyOffset_19;

		// Token: 0x04010565 RID: 66917
		internal static int __PropertyOffset_20;

		// Token: 0x04010566 RID: 66918
		internal static int __PropertyOffset_21;

		// Token: 0x04010567 RID: 66919
		internal static int __PropertyOffset_22;

		// Token: 0x04010568 RID: 66920
		internal static int __PropertyOffset_23;

		// Token: 0x04010569 RID: 66921
		private TArray<int> _QualityDistanceList;

		// Token: 0x0401056A RID: 66922
		internal static int __PropertyOffset_24;

		// Token: 0x0401056B RID: 66923
		internal static int __PropertyOffset_25;

		// Token: 0x0401056C RID: 66924
		internal static int __PropertyOffset_26;

		// Token: 0x0401056D RID: 66925
		internal static int __PropertyOffset_27;

		// Token: 0x0401056E RID: 66926
		internal static int __PropertyOffset_28;

		// Token: 0x0401056F RID: 66927
		internal static int __PropertyOffset_29;

		// Token: 0x04010570 RID: 66928
		internal static int __PropertyOffset_30;

		// Token: 0x04010571 RID: 66929
		internal static int __PropertyOffset_31;

		// Token: 0x04010572 RID: 66930
		internal static int __PropertyOffset_32;

		// Token: 0x04010573 RID: 66931
		internal static int __PropertyOffset_33;

		// Token: 0x04010574 RID: 66932
		internal static int __PropertyOffset_34;

		// Token: 0x04010575 RID: 66933
		internal static int __PropertyOffset_35;

		// Token: 0x04010576 RID: 66934
		internal static int __PropertyOffset_36;

		// Token: 0x04010577 RID: 66935
		private static IntPtr __ShouldStopOnHide_NativeFunctionPtr;

		// Token: 0x04010578 RID: 66936
		private static IntPtr __GetAoiRange_NativeFunctionPtr;

		// Token: 0x04010579 RID: 66937
		private static IntPtr __DownSampleMediaTex_NativeFunctionPtr;

		// Token: 0x0401057A RID: 66938
		private static IntPtr __编辑器强制停止_NativeFunctionPtr;

		// Token: 0x0401057B RID: 66939
		private static IntPtr __编辑器强制播放_NativeFunctionPtr;

		// Token: 0x0401057C RID: 66940
		private static IntPtr __编辑器_MP4播放器初始化_NativeFunctionPtr;

		// Token: 0x0401057D RID: 66941
		private static IntPtr __编辑器MP4播放器停止预览_NativeFunctionPtr;

		// Token: 0x0401057E RID: 66942
		private static IntPtr __编辑器MP4播放器开始预览_NativeFunctionPtr;

		// Token: 0x0401057F RID: 66943
		private static IntPtr __GetSource_NativeFunctionPtr;

		// Token: 0x04010580 RID: 66944
		private static IntPtr __Init_NativeFunctionPtr;

		// Token: 0x04010581 RID: 66945
		private static IntPtr __HideVolumeLight_NativeFunctionPtr;

		// Token: 0x04010582 RID: 66946
		private static IntPtr __ShowVolumeLight_NativeFunctionPtr;

		// Token: 0x04010583 RID: 66947
		private static IntPtr __Release_Player_Asset_NativeFunctionPtr;

		// Token: 0x04010584 RID: 66948
		private static IntPtr __AllocatePlayerAsset_NativeFunctionPtr;

		// Token: 0x04010585 RID: 66949
		private static IntPtr __OpenSource_NativeFunctionPtr;

		// Token: 0x04010586 RID: 66950
		private static IntPtr __CloseSource_NativeFunctionPtr;

		// Token: 0x04010587 RID: 66951
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04010588 RID: 66952
		private static IntPtr __TickOutside_NativeFunctionPtr;

		// Token: 0x04010589 RID: 66953
		private static IntPtr __Pause_NativeFunctionPtr;

		// Token: 0x0401058A RID: 66954
		private static IntPtr __Resume_NativeFunctionPtr;

		// Token: 0x0401058B RID: 66955
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0401058C RID: 66956
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x0401058D RID: 66957
		private static IntPtr __Start_NativeFunctionPtr;

		// Token: 0x0401058E RID: 66958
		private static IntPtr __Stop_NativeFunctionPtr;

		// Token: 0x0401058F RID: 66959
		private static IntPtr __ReceiveEndPlay_NativeFunctionPtr;

		// Token: 0x04010590 RID: 66960
		private static IntPtr __PlaySound_NativeFunctionPtr;

		// Token: 0x04010591 RID: 66961
		private static IntPtr __CloseSound_NativeFunctionPtr;

		// Token: 0x04010592 RID: 66962
		private static IntPtr __OnMp4PlayRequested_NativeFunctionPtr;

		// Token: 0x04010593 RID: 66963
		private static IntPtr __OnMp4StopRequested_NativeFunctionPtr;

		// Token: 0x04010594 RID: 66964
		private static IntPtr __EditorInit_NativeFunctionPtr;

		// Token: 0x04010595 RID: 66965
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04010596 RID: 66966
		private static IntPtr __OnMediaAsyncClosed_NativeFunctionPtr;

		// Token: 0x04010597 RID: 66967
		private static IntPtr __CustomEvent_0_NativeFunctionPtr;

		// Token: 0x04010598 RID: 66968
		private static IntPtr __ExecuteUbergraph_MediaPlayForModel_Special_NativeFunctionPtr;

		// Token: 0x020099F9 RID: 39417
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __ShouldStopOnHide_FunctionParams
		{
			// Token: 0x040320D4 RID: 205012
			[FieldOffset(0)]
			public bool ret;
		}

		// Token: 0x020099FA RID: 39418
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __GetAoiRange_FunctionParams
		{
			// Token: 0x040320D5 RID: 205013
			[FieldOffset(0)]
			public int ret;
		}

		// Token: 0x020099FB RID: 39419
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __GetSource_FunctionParams
		{
			// Token: 0x040320D6 RID: 205014
			[FieldOffset(0)]
			public IntPtr MediaSource;
		}

		// Token: 0x020099FC RID: 39420
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __AllocatePlayerAsset_FunctionParams
		{
			// Token: 0x040320D7 RID: 205015
			[FieldOffset(0)]
			public IntPtr player;

			// Token: 0x040320D8 RID: 205016
			[FieldOffset(8)]
			public IntPtr texture;
		}

		// Token: 0x020099FD RID: 39421
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 112)]
		protected ref struct __OpenSource_FunctionParams
		{
			// Token: 0x040320D9 RID: 205017
			[FieldOffset(0)]
			public bool Successs;
		}

		// Token: 0x020099FE RID: 39422
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x040320DA RID: 205018
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x020099FF RID: 39423
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __ReceiveEndPlay_FunctionParams
		{
			// Token: 0x040320DB RID: 205019
			[FieldOffset(0)]
			public TEnumAsByte<EEndPlayReason> EndPlayReason;
		}

		// Token: 0x02009A00 RID: 39424
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __OnMp4PlayRequested_FunctionParams
		{
			// Token: 0x040320DC RID: 205020
			[FieldOffset(0)]
			public IntPtr InPlayer;

			// Token: 0x040320DD RID: 205021
			[FieldOffset(8)]
			public IntPtr InTexture;
		}

		// Token: 0x02009A01 RID: 39425
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x040320DE RID: 205022
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009A02 RID: 39426
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 312)]
		protected ref struct __ExecuteUbergraph_MediaPlayForModel_Special_FunctionParams
		{
			// Token: 0x040320DF RID: 205023
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
