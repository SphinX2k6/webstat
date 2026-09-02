using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.KuroTetCubemapLerp
{
	// Token: 0x02003C6C RID: 15468
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/KuroTetCubemapLerp/BP_KuroTetCubemapLerp.BP_KuroTetCubemapLerp_C")]
	[UnrealStructLayout(1376, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1373)]
	public class BP_KuroTetCubemapLerp_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06023D9A RID: 146842 RVA: 0x0098DD6C File Offset: 0x0098BF6C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_KuroTetCubemapLerp_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/KuroTetCubemapLerp/BP_KuroTetCubemapLerp.BP_KuroTetCubemapLerp_C");
			}
			return BP_KuroTetCubemapLerp_C._ClassPtr;
		}

		// Token: 0x06023D9B RID: 146843 RVA: 0x0098DD90 File Offset: 0x0098BF90
		public BP_KuroTetCubemapLerp_C() : this(BuiltinUtils.AllocNativeUObject(BP_KuroTetCubemapLerp_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06023D9C RID: 146844 RVA: 0x0098DDB8 File Offset: 0x0098BFB8
		[NullableContext(1)]
		public BP_KuroTetCubemapLerp_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_KuroTetCubemapLerp_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170048A9 RID: 18601
		// (get) Token: 0x06023D9D RID: 146845 RVA: 0x0098DDEC File Offset: 0x0098BFEC
		// (set) Token: 0x06023D9E RID: 146846 RVA: 0x0098DE25 File Offset: 0x0098C025
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_KuroTetCubemapLerp_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_KuroTetCubemapLerp_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170048AA RID: 18602
		// (get) Token: 0x06023D9F RID: 146847 RVA: 0x0098DE46 File Offset: 0x0098C046
		// (set) Token: 0x06023DA0 RID: 146848 RVA: 0x0098DE5A File Offset: 0x0098C05A
		public unsafe UStaticMeshComponent StaticMesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroTetCubemapLerp_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroTetCubemapLerp_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170048AB RID: 18603
		// (get) Token: 0x06023DA1 RID: 146849 RVA: 0x0098DE70 File Offset: 0x0098C070
		// (set) Token: 0x06023DA2 RID: 146850 RVA: 0x0098DEA9 File Offset: 0x0098C0A9
		[Nullable(1)]
		public TArray<FVector> Points
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<FVector> result;
				if ((result = this._Points) == null)
				{
					result = (this._Points = new TArray<FVector>(base.NativePtr + (IntPtr)BP_KuroTetCubemapLerp_C.__PropertyOffset_2, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Points.CopyAssign(value);
			}
		}

		// Token: 0x170048AC RID: 18604
		// (get) Token: 0x06023DA3 RID: 146851 RVA: 0x0098DEB8 File Offset: 0x0098C0B8
		// (set) Token: 0x06023DA4 RID: 146852 RVA: 0x0098DEF1 File Offset: 0x0098C0F1
		[Nullable(1)]
		public TArray<UTexture> Rendertarget
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<UTexture> result;
				if ((result = this._Rendertarget) == null)
				{
					result = (this._Rendertarget = new TArray<UTexture>(base.NativePtr + (IntPtr)BP_KuroTetCubemapLerp_C.__PropertyOffset_3, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Rendertarget.CopyAssign(value);
			}
		}

		// Token: 0x170048AD RID: 18605
		// (get) Token: 0x06023DA5 RID: 146853 RVA: 0x0098DEFF File Offset: 0x0098C0FF
		// (set) Token: 0x06023DA6 RID: 146854 RVA: 0x0098DF13 File Offset: 0x0098C113
		public unsafe UTexture CubeRT
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroTetCubemapLerp_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroTetCubemapLerp_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x170048AE RID: 18606
		// (get) Token: 0x06023DA7 RID: 146855 RVA: 0x0098DF28 File Offset: 0x0098C128
		// (set) Token: 0x06023DA8 RID: 146856 RVA: 0x0098DF3C File Offset: 0x0098C13C
		public unsafe UTexture CubeRT1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroTetCubemapLerp_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroTetCubemapLerp_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x170048AF RID: 18607
		// (get) Token: 0x06023DA9 RID: 146857 RVA: 0x0098DF51 File Offset: 0x0098C151
		// (set) Token: 0x06023DAA RID: 146858 RVA: 0x0098DF65 File Offset: 0x0098C165
		public unsafe UTexture CubeRT2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroTetCubemapLerp_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroTetCubemapLerp_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x170048B0 RID: 18608
		// (get) Token: 0x06023DAB RID: 146859 RVA: 0x0098DF7A File Offset: 0x0098C17A
		// (set) Token: 0x06023DAC RID: 146860 RVA: 0x0098DF8E File Offset: 0x0098C18E
		public unsafe UTexture CubeRT3
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroTetCubemapLerp_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroTetCubemapLerp_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x170048B1 RID: 18609
		// (get) Token: 0x06023DAD RID: 146861 RVA: 0x0098DFA3 File Offset: 0x0098C1A3
		// (set) Token: 0x06023DAE RID: 146862 RVA: 0x0098DFB3 File Offset: 0x0098C1B3
		public unsafe float Weight
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroTetCubemapLerp_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroTetCubemapLerp_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x170048B2 RID: 18610
		// (get) Token: 0x06023DAF RID: 146863 RVA: 0x0098DFC4 File Offset: 0x0098C1C4
		// (set) Token: 0x06023DB0 RID: 146864 RVA: 0x0098DFD4 File Offset: 0x0098C1D4
		public unsafe float Weight1
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroTetCubemapLerp_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroTetCubemapLerp_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x170048B3 RID: 18611
		// (get) Token: 0x06023DB1 RID: 146865 RVA: 0x0098DFE5 File Offset: 0x0098C1E5
		// (set) Token: 0x06023DB2 RID: 146866 RVA: 0x0098DFF5 File Offset: 0x0098C1F5
		public unsafe float Weight2
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroTetCubemapLerp_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroTetCubemapLerp_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x170048B4 RID: 18612
		// (get) Token: 0x06023DB3 RID: 146867 RVA: 0x0098E006 File Offset: 0x0098C206
		// (set) Token: 0x06023DB4 RID: 146868 RVA: 0x0098E016 File Offset: 0x0098C216
		public unsafe float Weight3
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroTetCubemapLerp_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroTetCubemapLerp_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x170048B5 RID: 18613
		// (get) Token: 0x06023DB5 RID: 146869 RVA: 0x0098E028 File Offset: 0x0098C228
		// (set) Token: 0x06023DB6 RID: 146870 RVA: 0x0098E061 File Offset: 0x0098C261
		[Nullable(1)]
		public TArray<AStaticMeshActor> BindMaterialActor
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<AStaticMeshActor> result;
				if ((result = this._BindMaterialActor) == null)
				{
					result = (this._BindMaterialActor = new TArray<AStaticMeshActor>(base.NativePtr + (IntPtr)BP_KuroTetCubemapLerp_C.__PropertyOffset_12, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.BindMaterialActor.CopyAssign(value);
			}
		}

		// Token: 0x170048B6 RID: 18614
		// (get) Token: 0x06023DB7 RID: 146871 RVA: 0x0098E06F File Offset: 0x0098C26F
		// (set) Token: 0x06023DB8 RID: 146872 RVA: 0x0098E07F File Offset: 0x0098C27F
		public unsafe float WeightPower
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroTetCubemapLerp_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroTetCubemapLerp_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x170048B7 RID: 18615
		// (get) Token: 0x06023DB9 RID: 146873 RVA: 0x0098E090 File Offset: 0x0098C290
		// (set) Token: 0x06023DBA RID: 146874 RVA: 0x0098E0A0 File Offset: 0x0098C2A0
		public unsafe bool bShowLine
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroTetCubemapLerp_C.__PropertyOffset_14) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroTetCubemapLerp_C.__PropertyOffset_14) = (value ? 1 : 0);
			}
		}

		// Token: 0x170048B8 RID: 18616
		// (get) Token: 0x06023DBB RID: 146875 RVA: 0x0098E0B4 File Offset: 0x0098C2B4
		// (set) Token: 0x06023DBC RID: 146876 RVA: 0x0098E0ED File Offset: 0x0098C2ED
		[Nullable(1)]
		public TSet<int> tempTetIndices
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TSet<int> result;
				if ((result = this._tempTetIndices) == null)
				{
					result = (this._tempTetIndices = new TSet<int>(base.NativePtr + (IntPtr)BP_KuroTetCubemapLerp_C.__PropertyOffset_15, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.tempTetIndices.CopyAssign(value);
			}
		}

		// Token: 0x170048B9 RID: 18617
		// (get) Token: 0x06023DBD RID: 146877 RVA: 0x0098E0FC File Offset: 0x0098C2FC
		// (set) Token: 0x06023DBE RID: 146878 RVA: 0x0098E135 File Offset: 0x0098C335
		[Nullable(1)]
		public TArray<int> TetIndices
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<int> result;
				if ((result = this._TetIndices) == null)
				{
					result = (this._TetIndices = new TArray<int>(base.NativePtr + (IntPtr)BP_KuroTetCubemapLerp_C.__PropertyOffset_16, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.TetIndices.CopyAssign(value);
			}
		}

		// Token: 0x170048BA RID: 18618
		// (get) Token: 0x06023DBF RID: 146879 RVA: 0x0098E143 File Offset: 0x0098C343
		// (set) Token: 0x06023DC0 RID: 146880 RVA: 0x0098E153 File Offset: 0x0098C353
		public unsafe BP_EWorldType Editor_Type
		{
			get
			{
				return (BP_EWorldType)(*(base.NativePtr + (IntPtr)BP_KuroTetCubemapLerp_C.__PropertyOffset_17));
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroTetCubemapLerp_C.__PropertyOffset_17) = (byte)value;
			}
		}

		// Token: 0x170048BB RID: 18619
		// (get) Token: 0x06023DC1 RID: 146881 RVA: 0x0098E164 File Offset: 0x0098C364
		// (set) Token: 0x06023DC2 RID: 146882 RVA: 0x0098E178 File Offset: 0x0098C378
		public unsafe AStaticMeshActor SequenceBindActor
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AStaticMeshActor>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroTetCubemapLerp_C.__PropertyOffset_18);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroTetCubemapLerp_C.__PropertyOffset_18, value);
			}
		}

		// Token: 0x170048BC RID: 18620
		// (get) Token: 0x06023DC3 RID: 146883 RVA: 0x0098E18D File Offset: 0x0098C38D
		// (set) Token: 0x06023DC4 RID: 146884 RVA: 0x0098E1A1 File Offset: 0x0098C3A1
		public unsafe AStaticMeshActor SequenceBindActor_0
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AStaticMeshActor>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroTetCubemapLerp_C.__PropertyOffset_19);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroTetCubemapLerp_C.__PropertyOffset_19, value);
			}
		}

		// Token: 0x170048BD RID: 18621
		// (get) Token: 0x06023DC5 RID: 146885 RVA: 0x0098E1B6 File Offset: 0x0098C3B6
		// (set) Token: 0x06023DC6 RID: 146886 RVA: 0x0098E1CA File Offset: 0x0098C3CA
		public unsafe AStaticMeshActor SequenceBindActor_1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AStaticMeshActor>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroTetCubemapLerp_C.__PropertyOffset_20);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroTetCubemapLerp_C.__PropertyOffset_20, value);
			}
		}

		// Token: 0x170048BE RID: 18622
		// (get) Token: 0x06023DC7 RID: 146887 RVA: 0x0098E1DF File Offset: 0x0098C3DF
		// (set) Token: 0x06023DC8 RID: 146888 RVA: 0x0098E1F3 File Offset: 0x0098C3F3
		public unsafe AStaticMeshActor SequenceBindActor_2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AStaticMeshActor>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroTetCubemapLerp_C.__PropertyOffset_21);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroTetCubemapLerp_C.__PropertyOffset_21, value);
			}
		}

		// Token: 0x170048BF RID: 18623
		// (get) Token: 0x06023DC9 RID: 146889 RVA: 0x0098E208 File Offset: 0x0098C408
		// (set) Token: 0x06023DCA RID: 146890 RVA: 0x0098E21C File Offset: 0x0098C41C
		public unsafe AStaticMeshActor SequenceBindActor_3
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AStaticMeshActor>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroTetCubemapLerp_C.__PropertyOffset_22);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroTetCubemapLerp_C.__PropertyOffset_22, value);
			}
		}

		// Token: 0x170048C0 RID: 18624
		// (get) Token: 0x06023DCB RID: 146891 RVA: 0x0098E231 File Offset: 0x0098C431
		// (set) Token: 0x06023DCC RID: 146892 RVA: 0x0098E245 File Offset: 0x0098C445
		public unsafe AStaticMeshActor SequenceBindActor_4
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AStaticMeshActor>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroTetCubemapLerp_C.__PropertyOffset_23);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroTetCubemapLerp_C.__PropertyOffset_23, value);
			}
		}

		// Token: 0x170048C1 RID: 18625
		// (get) Token: 0x06023DCD RID: 146893 RVA: 0x0098E25A File Offset: 0x0098C45A
		// (set) Token: 0x06023DCE RID: 146894 RVA: 0x0098E26E File Offset: 0x0098C46E
		public unsafe AStaticMeshActor SequenceBindActor_5
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AStaticMeshActor>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroTetCubemapLerp_C.__PropertyOffset_24);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroTetCubemapLerp_C.__PropertyOffset_24, value);
			}
		}

		// Token: 0x170048C2 RID: 18626
		// (get) Token: 0x06023DCF RID: 146895 RVA: 0x0098E283 File Offset: 0x0098C483
		// (set) Token: 0x06023DD0 RID: 146896 RVA: 0x0098E293 File Offset: 0x0098C493
		public unsafe bool bEditorTick
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroTetCubemapLerp_C.__PropertyOffset_25) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroTetCubemapLerp_C.__PropertyOffset_25) = (value ? 1 : 0);
			}
		}

		// Token: 0x170048C3 RID: 18627
		// (get) Token: 0x06023DD1 RID: 146897 RVA: 0x0098E2A4 File Offset: 0x0098C4A4
		// (set) Token: 0x06023DD2 RID: 146898 RVA: 0x0098E2B4 File Offset: 0x0098C4B4
		public unsafe int lastSearchIndex
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroTetCubemapLerp_C.__PropertyOffset_26);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroTetCubemapLerp_C.__PropertyOffset_26) = value;
			}
		}

		// Token: 0x170048C4 RID: 18628
		// (get) Token: 0x06023DD3 RID: 146899 RVA: 0x0098E2C5 File Offset: 0x0098C4C5
		// (set) Token: 0x06023DD4 RID: 146900 RVA: 0x0098E2D5 File Offset: 0x0098C4D5
		public unsafe int maxLoopCountPerTick
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroTetCubemapLerp_C.__PropertyOffset_27);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroTetCubemapLerp_C.__PropertyOffset_27) = value;
			}
		}

		// Token: 0x170048C5 RID: 18629
		// (get) Token: 0x06023DD5 RID: 146901 RVA: 0x0098E2E6 File Offset: 0x0098C4E6
		// (set) Token: 0x06023DD6 RID: 146902 RVA: 0x0098E2F6 File Offset: 0x0098C4F6
		public unsafe int tetCount
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroTetCubemapLerp_C.__PropertyOffset_28);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroTetCubemapLerp_C.__PropertyOffset_28) = value;
			}
		}

		// Token: 0x170048C6 RID: 18630
		// (get) Token: 0x06023DD7 RID: 146903 RVA: 0x0098E307 File Offset: 0x0098C507
		// (set) Token: 0x06023DD8 RID: 146904 RVA: 0x0098E317 File Offset: 0x0098C517
		public unsafe int nowTetIndex
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroTetCubemapLerp_C.__PropertyOffset_29);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroTetCubemapLerp_C.__PropertyOffset_29) = value;
			}
		}

		// Token: 0x170048C7 RID: 18631
		// (get) Token: 0x06023DD9 RID: 146905 RVA: 0x0098E328 File Offset: 0x0098C528
		// (set) Token: 0x06023DDA RID: 146906 RVA: 0x0098E33C File Offset: 0x0098C53C
		public unsafe FVector4 nowTetWeight
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroTetCubemapLerp_C.__PropertyOffset_30);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroTetCubemapLerp_C.__PropertyOffset_30) = value;
			}
		}

		// Token: 0x170048C8 RID: 18632
		// (get) Token: 0x06023DDB RID: 146907 RVA: 0x0098E351 File Offset: 0x0098C551
		// (set) Token: 0x06023DDC RID: 146908 RVA: 0x0098E361 File Offset: 0x0098C561
		public unsafe bool bNeedUpdateWeight
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroTetCubemapLerp_C.__PropertyOffset_31) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroTetCubemapLerp_C.__PropertyOffset_31) = (value ? 1 : 0);
			}
		}

		// Token: 0x170048C9 RID: 18633
		// (get) Token: 0x06023DDD RID: 146909 RVA: 0x0098E372 File Offset: 0x0098C572
		// (set) Token: 0x06023DDE RID: 146910 RVA: 0x0098E382 File Offset: 0x0098C582
		public unsafe int maxLoopCountPerTick_Mobile
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroTetCubemapLerp_C.__PropertyOffset_32);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroTetCubemapLerp_C.__PropertyOffset_32) = value;
			}
		}

		// Token: 0x170048CA RID: 18634
		// (get) Token: 0x06023DDF RID: 146911 RVA: 0x0098E393 File Offset: 0x0098C593
		// (set) Token: 0x06023DE0 RID: 146912 RVA: 0x0098E3A3 File Offset: 0x0098C5A3
		public unsafe int maxLoopCountPerTick_PC
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroTetCubemapLerp_C.__PropertyOffset_33);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroTetCubemapLerp_C.__PropertyOffset_33) = value;
			}
		}

		// Token: 0x170048CB RID: 18635
		// (get) Token: 0x06023DE1 RID: 146913 RVA: 0x0098E3B4 File Offset: 0x0098C5B4
		// (set) Token: 0x06023DE2 RID: 146914 RVA: 0x0098E3C4 File Offset: 0x0098C5C4
		public unsafe bool bUseMeshMaterial
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroTetCubemapLerp_C.__PropertyOffset_34) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroTetCubemapLerp_C.__PropertyOffset_34) = (value ? 1 : 0);
			}
		}

		// Token: 0x06023DE3 RID: 146915 RVA: 0x0098E3D8 File Offset: 0x0098C5D8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void FindNowTetIndex_Opti(FVector P)
		{
			BP_KuroTetCubemapLerp_C.__FindNowTetIndex_Opti_FunctionParams* ptr = stackalloc BP_KuroTetCubemapLerp_C.__FindNowTetIndex_Opti_FunctionParams[(UIntPtr)159] + 15L / (long)sizeof(BP_KuroTetCubemapLerp_C.__FindNowTetIndex_Opti_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroTetCubemapLerp_C.__FindNowTetIndex_Opti_NativeFunctionPtr, (void*)ptr, 1);
			ptr->P = P;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroTetCubemapLerp_C.__FindNowTetIndex_Opti_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06023DE4 RID: 146916 RVA: 0x0098E421 File Offset: 0x0098C621
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EditorTick()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroTetCubemapLerp_C.__EditorTick_NativeFunctionPtr, null);
		}

		// Token: 0x06023DE5 RID: 146917 RVA: 0x0098E438 File Offset: 0x0098C638
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void UpdateActorMat(AStaticMeshActor self2)
		{
			BP_KuroTetCubemapLerp_C.__UpdateActorMat_FunctionParams* ptr = stackalloc BP_KuroTetCubemapLerp_C.__UpdateActorMat_FunctionParams[(UIntPtr)127] + 15L / (long)sizeof(BP_KuroTetCubemapLerp_C.__UpdateActorMat_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroTetCubemapLerp_C.__UpdateActorMat_NativeFunctionPtr, (void*)ptr, 1);
			ptr->self2 = ((self2 != null) ? self2.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroTetCubemapLerp_C.__UpdateActorMat_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06023DE6 RID: 146918 RVA: 0x0098E48D File Offset: 0x0098C68D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void ClearPointNumber()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroTetCubemapLerp_C.__ClearPointNumber_NativeFunctionPtr, null);
		}

		// Token: 0x06023DE7 RID: 146919 RVA: 0x0098E4A1 File Offset: 0x0098C6A1
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void ShowPointNumber()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroTetCubemapLerp_C.__ShowPointNumber_NativeFunctionPtr, null);
		}

		// Token: 0x06023DE8 RID: 146920 RVA: 0x0098E4B8 File Offset: 0x0098C6B8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void FindClosePoint(FVector P, ref int Array_Index)
		{
			BP_KuroTetCubemapLerp_C.__FindClosePoint_FunctionParams* ptr = stackalloc BP_KuroTetCubemapLerp_C.__FindClosePoint_FunctionParams[(UIntPtr)71] + 15L / (long)sizeof(BP_KuroTetCubemapLerp_C.__FindClosePoint_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroTetCubemapLerp_C.__FindClosePoint_NativeFunctionPtr, (void*)ptr, 1);
			ptr->P = P;
			ptr->Array_Index = Array_Index;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroTetCubemapLerp_C.__FindClosePoint_NativeFunctionPtr, (void*)ptr);
			Array_Index = ptr->Array_Index;
		}

		// Token: 0x06023DE9 RID: 146921 RVA: 0x0098E510 File Offset: 0x0098C710
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual float ScTP(FVector a, FVector b, FVector c)
		{
			BP_KuroTetCubemapLerp_C.__ScTP_FunctionParams* ptr = stackalloc BP_KuroTetCubemapLerp_C.__ScTP_FunctionParams[(UIntPtr)71] + 15L / (long)sizeof(BP_KuroTetCubemapLerp_C.__ScTP_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroTetCubemapLerp_C.__ScTP_NativeFunctionPtr, (void*)ptr, 1);
			ptr->a = a;
			ptr->b = b;
			ptr->c = c;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroTetCubemapLerp_C.__ScTP_NativeFunctionPtr, (void*)ptr);
			return ptr->__Result;
		}

		// Token: 0x06023DEA RID: 146922 RVA: 0x0098E56C File Offset: 0x0098C76C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetUVWXInTet(FVector A, FVector B, FVector C, FVector D, FVector P, ref FVector4 UVWX)
		{
			BP_KuroTetCubemapLerp_C.__GetUVWXInTet_FunctionParams* ptr = stackalloc BP_KuroTetCubemapLerp_C.__GetUVWXInTet_FunctionParams[(UIntPtr)239] + 15L / (long)sizeof(BP_KuroTetCubemapLerp_C.__GetUVWXInTet_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroTetCubemapLerp_C.__GetUVWXInTet_NativeFunctionPtr, (void*)ptr, 1);
			ptr->A = A;
			ptr->B = B;
			ptr->C = C;
			ptr->D = D;
			ptr->P = P;
			ptr->UVWX = UVWX;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroTetCubemapLerp_C.__GetUVWXInTet_NativeFunctionPtr, (void*)ptr);
			UVWX = ptr->UVWX;
		}

		// Token: 0x06023DEB RID: 146923 RVA: 0x0098E5ED File Offset: 0x0098C7ED
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void DrawTet()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroTetCubemapLerp_C.__DrawTet_NativeFunctionPtr, null);
		}

		// Token: 0x06023DEC RID: 146924 RVA: 0x0098E601 File Offset: 0x0098C801
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void ImportTetFromMesh()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroTetCubemapLerp_C.__ImportTetFromMesh_NativeFunctionPtr, null);
		}

		// Token: 0x06023DED RID: 146925 RVA: 0x0098E615 File Offset: 0x0098C815
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void ClearPaint()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroTetCubemapLerp_C.__ClearPaint_NativeFunctionPtr, null);
		}

		// Token: 0x06023DEE RID: 146926 RVA: 0x0098E629 File Offset: 0x0098C829
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Update()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroTetCubemapLerp_C.__Update_NativeFunctionPtr, null);
		}

		// Token: 0x06023DEF RID: 146927 RVA: 0x0098E63D File Offset: 0x0098C83D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Update_Material_Parameters()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroTetCubemapLerp_C.__Update_Material_Parameters_NativeFunctionPtr, null);
		}

		// Token: 0x06023DF0 RID: 146928 RVA: 0x0098E654 File Offset: 0x0098C854
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void FindNowTetIndex(FVector P, ref int Index, ref FVector4 UVWX)
		{
			BP_KuroTetCubemapLerp_C.__FindNowTetIndex_FunctionParams* ptr = stackalloc BP_KuroTetCubemapLerp_C.__FindNowTetIndex_FunctionParams[(UIntPtr)175] + 15L / (long)sizeof(BP_KuroTetCubemapLerp_C.__FindNowTetIndex_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroTetCubemapLerp_C.__FindNowTetIndex_NativeFunctionPtr, (void*)ptr, 1);
			ptr->P = P;
			ptr->Index = Index;
			ptr->UVWX = UVWX;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroTetCubemapLerp_C.__FindNowTetIndex_NativeFunctionPtr, (void*)ptr);
			Index = ptr->Index;
			UVWX = ptr->UVWX;
		}

		// Token: 0x06023DF1 RID: 146929 RVA: 0x0098E6C8 File Offset: 0x0098C8C8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void CalculateWeights(FVector P)
		{
			BP_KuroTetCubemapLerp_C.__CalculateWeights_FunctionParams* ptr = stackalloc BP_KuroTetCubemapLerp_C.__CalculateWeights_FunctionParams[(UIntPtr)463] + 15L / (long)sizeof(BP_KuroTetCubemapLerp_C.__CalculateWeights_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroTetCubemapLerp_C.__CalculateWeights_NativeFunctionPtr, (void*)ptr, 1);
			ptr->P = P;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroTetCubemapLerp_C.__CalculateWeights_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06023DF2 RID: 146930 RVA: 0x0098E714 File Offset: 0x0098C914
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual bool IsInsideTet(FVector P, FVector A, FVector B, FVector C, FVector D, ref FVector4 UVWX)
		{
			BP_KuroTetCubemapLerp_C.__IsInsideTet_FunctionParams* ptr = stackalloc BP_KuroTetCubemapLerp_C.__IsInsideTet_FunctionParams[(UIntPtr)143] + 15L / (long)sizeof(BP_KuroTetCubemapLerp_C.__IsInsideTet_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroTetCubemapLerp_C.__IsInsideTet_NativeFunctionPtr, (void*)ptr, 1);
			ptr->P = P;
			ptr->A = A;
			ptr->B = B;
			ptr->C = C;
			ptr->D = D;
			ptr->UVWX = UVWX;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroTetCubemapLerp_C.__IsInsideTet_NativeFunctionPtr, (void*)ptr);
			UVWX = ptr->UVWX;
			return ptr->__Result;
		}

		// Token: 0x06023DF3 RID: 146931 RVA: 0x0098E79B File Offset: 0x0098C99B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroTetCubemapLerp_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06023DF4 RID: 146932 RVA: 0x0098E7AF File Offset: 0x0098C9AF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroTetCubemapLerp_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06023DF5 RID: 146933 RVA: 0x0098E7C4 File Offset: 0x0098C9C4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroTetCubemapLerp_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06023DF6 RID: 146934 RVA: 0x0098E7D8 File Offset: 0x0098C9D8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroTetCubemapLerp_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06023DF7 RID: 146935 RVA: 0x0098E7F0 File Offset: 0x0098C9F0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_KuroTetCubemapLerp_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_KuroTetCubemapLerp_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_KuroTetCubemapLerp_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroTetCubemapLerp_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroTetCubemapLerp_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06023DF8 RID: 146936 RVA: 0x0098E838 File Offset: 0x0098CA38
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_KuroTetCubemapLerp_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_KuroTetCubemapLerp_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_KuroTetCubemapLerp_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroTetCubemapLerp_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroTetCubemapLerp_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06023DF9 RID: 146937 RVA: 0x0098E880 File Offset: 0x0098CA80
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_KuroTetCubemapLerp(int EntryPoint)
		{
			BP_KuroTetCubemapLerp_C.__ExecuteUbergraph_BP_KuroTetCubemapLerp_FunctionParams* ptr = stackalloc BP_KuroTetCubemapLerp_C.__ExecuteUbergraph_BP_KuroTetCubemapLerp_FunctionParams[(UIntPtr)127] + 15L / (long)sizeof(BP_KuroTetCubemapLerp_C.__ExecuteUbergraph_BP_KuroTetCubemapLerp_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroTetCubemapLerp_C.__ExecuteUbergraph_BP_KuroTetCubemapLerp_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroTetCubemapLerp_C.__ExecuteUbergraph_BP_KuroTetCubemapLerp_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06023DFA RID: 146938 RVA: 0x0098E8C7 File Offset: 0x0098CAC7
		protected BP_KuroTetCubemapLerp_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040124DC RID: 74972
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/KuroTetCubemapLerp/BP_KuroTetCubemapLerp.BP_KuroTetCubemapLerp_C";

		// Token: 0x040124DD RID: 74973
		private static IntPtr _ClassPtr;

		// Token: 0x040124DE RID: 74974
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040124DF RID: 74975
		internal static int __PropertyOffset_0;

		// Token: 0x040124E0 RID: 74976
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040124E1 RID: 74977
		internal static int __PropertyOffset_1;

		// Token: 0x040124E2 RID: 74978
		internal static int __PropertyOffset_2;

		// Token: 0x040124E3 RID: 74979
		private TArray<FVector> _Points;

		// Token: 0x040124E4 RID: 74980
		internal static int __PropertyOffset_3;

		// Token: 0x040124E5 RID: 74981
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UTexture> _Rendertarget;

		// Token: 0x040124E6 RID: 74982
		internal static int __PropertyOffset_4;

		// Token: 0x040124E7 RID: 74983
		internal static int __PropertyOffset_5;

		// Token: 0x040124E8 RID: 74984
		internal static int __PropertyOffset_6;

		// Token: 0x040124E9 RID: 74985
		internal static int __PropertyOffset_7;

		// Token: 0x040124EA RID: 74986
		internal static int __PropertyOffset_8;

		// Token: 0x040124EB RID: 74987
		internal static int __PropertyOffset_9;

		// Token: 0x040124EC RID: 74988
		internal static int __PropertyOffset_10;

		// Token: 0x040124ED RID: 74989
		internal static int __PropertyOffset_11;

		// Token: 0x040124EE RID: 74990
		internal static int __PropertyOffset_12;

		// Token: 0x040124EF RID: 74991
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<AStaticMeshActor> _BindMaterialActor;

		// Token: 0x040124F0 RID: 74992
		internal static int __PropertyOffset_13;

		// Token: 0x040124F1 RID: 74993
		internal static int __PropertyOffset_14;

		// Token: 0x040124F2 RID: 74994
		internal static int __PropertyOffset_15;

		// Token: 0x040124F3 RID: 74995
		private TSet<int> _tempTetIndices;

		// Token: 0x040124F4 RID: 74996
		internal static int __PropertyOffset_16;

		// Token: 0x040124F5 RID: 74997
		private TArray<int> _TetIndices;

		// Token: 0x040124F6 RID: 74998
		internal static int __PropertyOffset_17;

		// Token: 0x040124F7 RID: 74999
		internal static int __PropertyOffset_18;

		// Token: 0x040124F8 RID: 75000
		internal static int __PropertyOffset_19;

		// Token: 0x040124F9 RID: 75001
		internal static int __PropertyOffset_20;

		// Token: 0x040124FA RID: 75002
		internal static int __PropertyOffset_21;

		// Token: 0x040124FB RID: 75003
		internal static int __PropertyOffset_22;

		// Token: 0x040124FC RID: 75004
		internal static int __PropertyOffset_23;

		// Token: 0x040124FD RID: 75005
		internal static int __PropertyOffset_24;

		// Token: 0x040124FE RID: 75006
		internal static int __PropertyOffset_25;

		// Token: 0x040124FF RID: 75007
		internal static int __PropertyOffset_26;

		// Token: 0x04012500 RID: 75008
		internal static int __PropertyOffset_27;

		// Token: 0x04012501 RID: 75009
		internal static int __PropertyOffset_28;

		// Token: 0x04012502 RID: 75010
		internal static int __PropertyOffset_29;

		// Token: 0x04012503 RID: 75011
		internal static int __PropertyOffset_30;

		// Token: 0x04012504 RID: 75012
		internal static int __PropertyOffset_31;

		// Token: 0x04012505 RID: 75013
		internal static int __PropertyOffset_32;

		// Token: 0x04012506 RID: 75014
		internal static int __PropertyOffset_33;

		// Token: 0x04012507 RID: 75015
		internal static int __PropertyOffset_34;

		// Token: 0x04012508 RID: 75016
		private static IntPtr __FindNowTetIndex_Opti_NativeFunctionPtr;

		// Token: 0x04012509 RID: 75017
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x0401250A RID: 75018
		private static IntPtr __UpdateActorMat_NativeFunctionPtr;

		// Token: 0x0401250B RID: 75019
		private static IntPtr __ClearPointNumber_NativeFunctionPtr;

		// Token: 0x0401250C RID: 75020
		private static IntPtr __ShowPointNumber_NativeFunctionPtr;

		// Token: 0x0401250D RID: 75021
		private static IntPtr __FindClosePoint_NativeFunctionPtr;

		// Token: 0x0401250E RID: 75022
		private static IntPtr __ScTP_NativeFunctionPtr;

		// Token: 0x0401250F RID: 75023
		private static IntPtr __GetUVWXInTet_NativeFunctionPtr;

		// Token: 0x04012510 RID: 75024
		private static IntPtr __DrawTet_NativeFunctionPtr;

		// Token: 0x04012511 RID: 75025
		private static IntPtr __ImportTetFromMesh_NativeFunctionPtr;

		// Token: 0x04012512 RID: 75026
		private static IntPtr __ClearPaint_NativeFunctionPtr;

		// Token: 0x04012513 RID: 75027
		private static IntPtr __Update_NativeFunctionPtr;

		// Token: 0x04012514 RID: 75028
		private static IntPtr __Update_Material_Parameters_NativeFunctionPtr;

		// Token: 0x04012515 RID: 75029
		private static IntPtr __FindNowTetIndex_NativeFunctionPtr;

		// Token: 0x04012516 RID: 75030
		private static IntPtr __CalculateWeights_NativeFunctionPtr;

		// Token: 0x04012517 RID: 75031
		private static IntPtr __IsInsideTet_NativeFunctionPtr;

		// Token: 0x04012518 RID: 75032
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04012519 RID: 75033
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0401251A RID: 75034
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0401251B RID: 75035
		private static IntPtr __ExecuteUbergraph_BP_KuroTetCubemapLerp_NativeFunctionPtr;

		// Token: 0x02009D53 RID: 40275
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 144)]
		protected ref struct __FindNowTetIndex_Opti_FunctionParams
		{
			// Token: 0x04032737 RID: 206647
			[FieldOffset(0)]
			public FVector P;
		}

		// Token: 0x02009D54 RID: 40276
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 112)]
		protected ref struct __UpdateActorMat_FunctionParams
		{
			// Token: 0x04032738 RID: 206648
			[FieldOffset(0)]
			public IntPtr self2;
		}

		// Token: 0x02009D55 RID: 40277
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 56)]
		protected ref struct __FindClosePoint_FunctionParams
		{
			// Token: 0x04032739 RID: 206649
			[FieldOffset(0)]
			public FVector P;

			// Token: 0x0403273A RID: 206650
			[FieldOffset(12)]
			public int Array_Index;
		}

		// Token: 0x02009D56 RID: 40278
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 56)]
		protected ref struct __ScTP_FunctionParams
		{
			// Token: 0x0403273B RID: 206651
			[FieldOffset(0)]
			public FVector a;

			// Token: 0x0403273C RID: 206652
			[FieldOffset(12)]
			public FVector b;

			// Token: 0x0403273D RID: 206653
			[FieldOffset(24)]
			public FVector c;

			// Token: 0x0403273E RID: 206654
			[FieldOffset(36)]
			public float __Result;
		}

		// Token: 0x02009D57 RID: 40279
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 224)]
		protected ref struct __GetUVWXInTet_FunctionParams
		{
			// Token: 0x0403273F RID: 206655
			[FieldOffset(0)]
			public FVector A;

			// Token: 0x04032740 RID: 206656
			[FieldOffset(12)]
			public FVector B;

			// Token: 0x04032741 RID: 206657
			[FieldOffset(24)]
			public FVector C;

			// Token: 0x04032742 RID: 206658
			[FieldOffset(36)]
			public FVector D;

			// Token: 0x04032743 RID: 206659
			[FieldOffset(48)]
			public FVector P;

			// Token: 0x04032744 RID: 206660
			[FieldOffset(64)]
			public FVector4 UVWX;
		}

		// Token: 0x02009D58 RID: 40280
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 160)]
		protected ref struct __FindNowTetIndex_FunctionParams
		{
			// Token: 0x04032745 RID: 206661
			[FieldOffset(0)]
			public FVector P;

			// Token: 0x04032746 RID: 206662
			[FieldOffset(12)]
			public int Index;

			// Token: 0x04032747 RID: 206663
			[FieldOffset(16)]
			public FVector4 UVWX;
		}

		// Token: 0x02009D59 RID: 40281
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 448)]
		protected ref struct __CalculateWeights_FunctionParams
		{
			// Token: 0x04032748 RID: 206664
			[FieldOffset(0)]
			public FVector P;
		}

		// Token: 0x02009D5A RID: 40282
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 128)]
		protected ref struct __IsInsideTet_FunctionParams
		{
			// Token: 0x04032749 RID: 206665
			[FieldOffset(0)]
			public FVector P;

			// Token: 0x0403274A RID: 206666
			[FieldOffset(12)]
			public FVector A;

			// Token: 0x0403274B RID: 206667
			[FieldOffset(24)]
			public FVector B;

			// Token: 0x0403274C RID: 206668
			[FieldOffset(36)]
			public FVector C;

			// Token: 0x0403274D RID: 206669
			[FieldOffset(48)]
			public FVector D;

			// Token: 0x0403274E RID: 206670
			[FieldOffset(60)]
			public bool __Result;

			// Token: 0x0403274F RID: 206671
			[FieldOffset(64)]
			public FVector4 UVWX;
		}

		// Token: 0x02009D5B RID: 40283
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032750 RID: 206672
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009D5C RID: 40284
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 112)]
		protected ref struct __ExecuteUbergraph_BP_KuroTetCubemapLerp_FunctionParams
		{
			// Token: 0x04032751 RID: 206673
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
