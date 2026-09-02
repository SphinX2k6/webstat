using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG._2DRayCastingGamePlay.Camera
{
	// Token: 0x02003C52 RID: 15442
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/2DRayCastingGamePlay/Camera/BP_cpuRayCasting_camera.BP_cpuRayCasting_camera_C")]
	[UnrealStructLayout(1776, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1776)]
	public class BP_cpuRayCasting_camera_C : AFSRayCastingActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060239A4 RID: 145828 RVA: 0x009871B5 File Offset: 0x009853B5
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_cpuRayCasting_camera_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/2DRayCastingGamePlay/Camera/BP_cpuRayCasting_camera.BP_cpuRayCasting_camera_C");
			}
			return BP_cpuRayCasting_camera_C._ClassPtr;
		}

		// Token: 0x060239A5 RID: 145829 RVA: 0x009871DC File Offset: 0x009853DC
		public BP_cpuRayCasting_camera_C() : this(BuiltinUtils.AllocNativeUObject(BP_cpuRayCasting_camera_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060239A6 RID: 145830 RVA: 0x00987204 File Offset: 0x00985404
		public BP_cpuRayCasting_camera_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_cpuRayCasting_camera_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17004754 RID: 18260
		// (get) Token: 0x060239A7 RID: 145831 RVA: 0x00987238 File Offset: 0x00985438
		// (set) Token: 0x060239A8 RID: 145832 RVA: 0x00987271 File Offset: 0x00985471
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_cpuRayCasting_camera_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_cpuRayCasting_camera_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17004755 RID: 18261
		// (get) Token: 0x060239A9 RID: 145833 RVA: 0x00987292 File Offset: 0x00985492
		// (set) Token: 0x060239AA RID: 145834 RVA: 0x009872A6 File Offset: 0x009854A6
		[Nullable(2)]
		public unsafe UProceduralMeshComponent PM_rayArea
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UProceduralMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_cpuRayCasting_camera_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_cpuRayCasting_camera_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17004756 RID: 18262
		// (get) Token: 0x060239AB RID: 145835 RVA: 0x009872BB File Offset: 0x009854BB
		// (set) Token: 0x060239AC RID: 145836 RVA: 0x009872CF File Offset: 0x009854CF
		[Nullable(2)]
		public unsafe UStaticMeshComponent Plane1
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_cpuRayCasting_camera_C.__PropertyOffset_2);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_cpuRayCasting_camera_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17004757 RID: 18263
		// (get) Token: 0x060239AD RID: 145837 RVA: 0x009872E4 File Offset: 0x009854E4
		// (set) Token: 0x060239AE RID: 145838 RVA: 0x009872F8 File Offset: 0x009854F8
		[Nullable(2)]
		public unsafe USceneCaptureComponent2D SceneCaptureComponent2D
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneCaptureComponent2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_cpuRayCasting_camera_C.__PropertyOffset_3);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_cpuRayCasting_camera_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17004758 RID: 18264
		// (get) Token: 0x060239AF RID: 145839 RVA: 0x0098730D File Offset: 0x0098550D
		// (set) Token: 0x060239B0 RID: 145840 RVA: 0x00987321 File Offset: 0x00985521
		[Nullable(2)]
		public unsafe UBoxComponent Box_Collision
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_cpuRayCasting_camera_C.__PropertyOffset_4);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_cpuRayCasting_camera_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17004759 RID: 18265
		// (get) Token: 0x060239B1 RID: 145841 RVA: 0x00987336 File Offset: 0x00985536
		// (set) Token: 0x060239B2 RID: 145842 RVA: 0x0098734A File Offset: 0x0098554A
		[Nullable(2)]
		public unsafe USceneComponent DefaultSceneRoot
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_cpuRayCasting_camera_C.__PropertyOffset_5);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_cpuRayCasting_camera_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x1700475A RID: 18266
		// (get) Token: 0x060239B3 RID: 145843 RVA: 0x00987360 File Offset: 0x00985560
		// (set) Token: 0x060239B4 RID: 145844 RVA: 0x00987399 File Offset: 0x00985599
		public TArray<float> Dis
		{
			get
			{
				base.FastCheckIsValid();
				TArray<float> result;
				if ((result = this._Dis) == null)
				{
					result = (this._Dis = new TArray<float>(base.NativePtr + (IntPtr)BP_cpuRayCasting_camera_C.__PropertyOffset_6, this));
				}
				return result;
			}
			set
			{
				this.Dis.CopyAssign(value);
			}
		}

		// Token: 0x1700475B RID: 18267
		// (get) Token: 0x060239B5 RID: 145845 RVA: 0x009873A8 File Offset: 0x009855A8
		// (set) Token: 0x060239B6 RID: 145846 RVA: 0x009873E1 File Offset: 0x009855E1
		public TArray<FVector> Dirs
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FVector> result;
				if ((result = this._Dirs) == null)
				{
					result = (this._Dirs = new TArray<FVector>(base.NativePtr + (IntPtr)BP_cpuRayCasting_camera_C.__PropertyOffset_7, this));
				}
				return result;
			}
			set
			{
				this.Dirs.CopyAssign(value);
			}
		}

		// Token: 0x1700475C RID: 18268
		// (get) Token: 0x060239B7 RID: 145847 RVA: 0x009873F0 File Offset: 0x009855F0
		// (set) Token: 0x060239B8 RID: 145848 RVA: 0x00987429 File Offset: 0x00985629
		public TArray<FVector> EndPos
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FVector> result;
				if ((result = this._EndPos) == null)
				{
					result = (this._EndPos = new TArray<FVector>(base.NativePtr + (IntPtr)BP_cpuRayCasting_camera_C.__PropertyOffset_8, this));
				}
				return result;
			}
			set
			{
				this.EndPos.CopyAssign(value);
			}
		}

		// Token: 0x1700475D RID: 18269
		// (get) Token: 0x060239B9 RID: 145849 RVA: 0x00987437 File Offset: 0x00985637
		// (set) Token: 0x060239BA RID: 145850 RVA: 0x00987447 File Offset: 0x00985647
		public unsafe float RayCastingDetectDis
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_cpuRayCasting_camera_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_cpuRayCasting_camera_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x1700475E RID: 18270
		// (get) Token: 0x060239BB RID: 145851 RVA: 0x00987458 File Offset: 0x00985658
		// (set) Token: 0x060239BC RID: 145852 RVA: 0x00987468 File Offset: 0x00985668
		public unsafe int particleCount
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_cpuRayCasting_camera_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_cpuRayCasting_camera_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x1700475F RID: 18271
		// (get) Token: 0x060239BD RID: 145853 RVA: 0x00987479 File Offset: 0x00985679
		// (set) Token: 0x060239BE RID: 145854 RVA: 0x00987489 File Offset: 0x00985689
		public unsafe int CountIndex
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_cpuRayCasting_camera_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_cpuRayCasting_camera_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17004760 RID: 18272
		// (get) Token: 0x060239BF RID: 145855 RVA: 0x0098749C File Offset: 0x0098569C
		// (set) Token: 0x060239C0 RID: 145856 RVA: 0x009874D5 File Offset: 0x009856D5
		public TArray<FVector> Vertices
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FVector> result;
				if ((result = this._Vertices) == null)
				{
					result = (this._Vertices = new TArray<FVector>(base.NativePtr + (IntPtr)BP_cpuRayCasting_camera_C.__PropertyOffset_12, this));
				}
				return result;
			}
			set
			{
				this.Vertices.CopyAssign(value);
			}
		}

		// Token: 0x17004761 RID: 18273
		// (get) Token: 0x060239C1 RID: 145857 RVA: 0x009874E4 File Offset: 0x009856E4
		// (set) Token: 0x060239C2 RID: 145858 RVA: 0x0098751D File Offset: 0x0098571D
		public TArray<int> triangles
		{
			get
			{
				base.FastCheckIsValid();
				TArray<int> result;
				if ((result = this._triangles) == null)
				{
					result = (this._triangles = new TArray<int>(base.NativePtr + (IntPtr)BP_cpuRayCasting_camera_C.__PropertyOffset_13, this));
				}
				return result;
			}
			set
			{
				this.triangles.CopyAssign(value);
			}
		}

		// Token: 0x17004762 RID: 18274
		// (get) Token: 0x060239C3 RID: 145859 RVA: 0x0098752B File Offset: 0x0098572B
		// (set) Token: 0x060239C4 RID: 145860 RVA: 0x0098753B File Offset: 0x0098573B
		public unsafe bool stopMeshing
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_cpuRayCasting_camera_C.__PropertyOffset_14) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_cpuRayCasting_camera_C.__PropertyOffset_14) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004763 RID: 18275
		// (get) Token: 0x060239C5 RID: 145861 RVA: 0x0098754C File Offset: 0x0098574C
		// (set) Token: 0x060239C6 RID: 145862 RVA: 0x00987560 File Offset: 0x00985760
		public unsafe FRotator RayStartoRatation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_cpuRayCasting_camera_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_cpuRayCasting_camera_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x17004764 RID: 18276
		// (get) Token: 0x060239C7 RID: 145863 RVA: 0x00987575 File Offset: 0x00985775
		// (set) Token: 0x060239C8 RID: 145864 RVA: 0x00987585 File Offset: 0x00985785
		public unsafe int BatchSize
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_cpuRayCasting_camera_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_cpuRayCasting_camera_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x17004765 RID: 18277
		// (get) Token: 0x060239C9 RID: 145865 RVA: 0x00987596 File Offset: 0x00985796
		// (set) Token: 0x060239CA RID: 145866 RVA: 0x009875A6 File Offset: 0x009857A6
		public unsafe bool PlayerColOnOrNot
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_cpuRayCasting_camera_C.__PropertyOffset_17) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_cpuRayCasting_camera_C.__PropertyOffset_17) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004766 RID: 18278
		// (get) Token: 0x060239CB RID: 145867 RVA: 0x009875B7 File Offset: 0x009857B7
		// (set) Token: 0x060239CC RID: 145868 RVA: 0x009875C7 File Offset: 0x009857C7
		public unsafe bool drawdebug
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_cpuRayCasting_camera_C.__PropertyOffset_18) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_cpuRayCasting_camera_C.__PropertyOffset_18) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004767 RID: 18279
		// (get) Token: 0x060239CD RID: 145869 RVA: 0x009875D8 File Offset: 0x009857D8
		// (set) Token: 0x060239CE RID: 145870 RVA: 0x00987611 File Offset: 0x00985811
		public TArray<FName> ParamNameList
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FName> result;
				if ((result = this._ParamNameList) == null)
				{
					result = (this._ParamNameList = new TArray<FName>(base.NativePtr + (IntPtr)BP_cpuRayCasting_camera_C.__PropertyOffset_19, this));
				}
				return result;
			}
			set
			{
				this.ParamNameList.CopyAssign(value);
			}
		}

		// Token: 0x17004768 RID: 18280
		// (get) Token: 0x060239CF RID: 145871 RVA: 0x00987620 File Offset: 0x00985820
		// (set) Token: 0x060239D0 RID: 145872 RVA: 0x00987659 File Offset: 0x00985859
		public TArray<FVector2D> UvList
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FVector2D> result;
				if ((result = this._UvList) == null)
				{
					result = (this._UvList = new TArray<FVector2D>(base.NativePtr + (IntPtr)BP_cpuRayCasting_camera_C.__PropertyOffset_20, this));
				}
				return result;
			}
			set
			{
				this.UvList.CopyAssign(value);
			}
		}

		// Token: 0x17004769 RID: 18281
		// (get) Token: 0x060239D1 RID: 145873 RVA: 0x00987667 File Offset: 0x00985867
		// (set) Token: 0x060239D2 RID: 145874 RVA: 0x0098767B File Offset: 0x0098587B
		[Nullable(2)]
		public unsafe UMaterialInstanceDynamic MID
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_cpuRayCasting_camera_C.__PropertyOffset_21);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_cpuRayCasting_camera_C.__PropertyOffset_21, value);
			}
		}

		// Token: 0x1700476A RID: 18282
		// (get) Token: 0x060239D3 RID: 145875 RVA: 0x00987690 File Offset: 0x00985890
		// (set) Token: 0x060239D4 RID: 145876 RVA: 0x009876A0 File Offset: 0x009858A0
		public unsafe bool motionOn
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_cpuRayCasting_camera_C.__PropertyOffset_22) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_cpuRayCasting_camera_C.__PropertyOffset_22) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700476B RID: 18283
		// (get) Token: 0x060239D5 RID: 145877 RVA: 0x009876B1 File Offset: 0x009858B1
		// (set) Token: 0x060239D6 RID: 145878 RVA: 0x009876C5 File Offset: 0x009858C5
		public unsafe FVector C
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_cpuRayCasting_camera_C.__PropertyOffset_23);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_cpuRayCasting_camera_C.__PropertyOffset_23) = value;
			}
		}

		// Token: 0x1700476C RID: 18284
		// (get) Token: 0x060239D7 RID: 145879 RVA: 0x009876DA File Offset: 0x009858DA
		// (set) Token: 0x060239D8 RID: 145880 RVA: 0x009876EA File Offset: 0x009858EA
		public unsafe float R
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_cpuRayCasting_camera_C.__PropertyOffset_24);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_cpuRayCasting_camera_C.__PropertyOffset_24) = value;
			}
		}

		// Token: 0x1700476D RID: 18285
		// (get) Token: 0x060239D9 RID: 145881 RVA: 0x009876FB File Offset: 0x009858FB
		// (set) Token: 0x060239DA RID: 145882 RVA: 0x0098770B File Offset: 0x0098590B
		public unsafe float dA
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_cpuRayCasting_camera_C.__PropertyOffset_25);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_cpuRayCasting_camera_C.__PropertyOffset_25) = value;
			}
		}

		// Token: 0x1700476E RID: 18286
		// (get) Token: 0x060239DB RID: 145883 RVA: 0x0098771C File Offset: 0x0098591C
		// (set) Token: 0x060239DC RID: 145884 RVA: 0x0098772C File Offset: 0x0098592C
		public unsafe float A
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_cpuRayCasting_camera_C.__PropertyOffset_26);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_cpuRayCasting_camera_C.__PropertyOffset_26) = value;
			}
		}

		// Token: 0x1700476F RID: 18287
		// (get) Token: 0x060239DD RID: 145885 RVA: 0x0098773D File Offset: 0x0098593D
		// (set) Token: 0x060239DE RID: 145886 RVA: 0x0098774D File Offset: 0x0098594D
		public unsafe float debugangle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_cpuRayCasting_camera_C.__PropertyOffset_27);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_cpuRayCasting_camera_C.__PropertyOffset_27) = value;
			}
		}

		// Token: 0x17004770 RID: 18288
		// (get) Token: 0x060239DF RID: 145887 RVA: 0x0098775E File Offset: 0x0098595E
		// (set) Token: 0x060239E0 RID: 145888 RVA: 0x0098776E File Offset: 0x0098596E
		public unsafe int debugdir
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_cpuRayCasting_camera_C.__PropertyOffset_28);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_cpuRayCasting_camera_C.__PropertyOffset_28) = value;
			}
		}

		// Token: 0x17004771 RID: 18289
		// (get) Token: 0x060239E1 RID: 145889 RVA: 0x0098777F File Offset: 0x0098597F
		// (set) Token: 0x060239E2 RID: 145890 RVA: 0x0098778F File Offset: 0x0098598F
		public unsafe float BoundingBoxSize
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_cpuRayCasting_camera_C.__PropertyOffset_29);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_cpuRayCasting_camera_C.__PropertyOffset_29) = value;
			}
		}

		// Token: 0x17004772 RID: 18290
		// (get) Token: 0x060239E3 RID: 145891 RVA: 0x009877A0 File Offset: 0x009859A0
		// (set) Token: 0x060239E4 RID: 145892 RVA: 0x009877D9 File Offset: 0x009859D9
		public TArray<AActor> IgnoreActors
		{
			get
			{
				base.FastCheckIsValid();
				TArray<AActor> result;
				if ((result = this._IgnoreActors) == null)
				{
					result = (this._IgnoreActors = new TArray<AActor>(base.NativePtr + (IntPtr)BP_cpuRayCasting_camera_C.__PropertyOffset_30, this));
				}
				return result;
			}
			set
			{
				this.IgnoreActors.CopyAssign(value);
			}
		}

		// Token: 0x17004773 RID: 18291
		// (get) Token: 0x060239E5 RID: 145893 RVA: 0x009877E7 File Offset: 0x009859E7
		// (set) Token: 0x060239E6 RID: 145894 RVA: 0x009877F7 File Offset: 0x009859F7
		public unsafe double Max_Degree_Angle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_cpuRayCasting_camera_C.__PropertyOffset_31);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_cpuRayCasting_camera_C.__PropertyOffset_31) = value;
			}
		}

		// Token: 0x17004774 RID: 18292
		// (get) Token: 0x060239E7 RID: 145895 RVA: 0x00987808 File Offset: 0x00985A08
		// (set) Token: 0x060239E8 RID: 145896 RVA: 0x00987818 File Offset: 0x00985A18
		public unsafe double Return_Speed_Degrees_Second
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_cpuRayCasting_camera_C.__PropertyOffset_32);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_cpuRayCasting_camera_C.__PropertyOffset_32) = value;
			}
		}

		// Token: 0x17004775 RID: 18293
		// (get) Token: 0x060239E9 RID: 145897 RVA: 0x00987829 File Offset: 0x00985A29
		// (set) Token: 0x060239EA RID: 145898 RVA: 0x00987839 File Offset: 0x00985A39
		public unsafe double Follow_Speed_Degrees_Second
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_cpuRayCasting_camera_C.__PropertyOffset_33);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_cpuRayCasting_camera_C.__PropertyOffset_33) = value;
			}
		}

		// Token: 0x17004776 RID: 18294
		// (get) Token: 0x060239EB RID: 145899 RVA: 0x0098784A File Offset: 0x00985A4A
		// (set) Token: 0x060239EC RID: 145900 RVA: 0x0098785A File Offset: 0x00985A5A
		public unsafe double Min_Active_Radius
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_cpuRayCasting_camera_C.__PropertyOffset_34);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_cpuRayCasting_camera_C.__PropertyOffset_34) = value;
			}
		}

		// Token: 0x17004777 RID: 18295
		// (get) Token: 0x060239ED RID: 145901 RVA: 0x0098786B File Offset: 0x00985A6B
		// (set) Token: 0x060239EE RID: 145902 RVA: 0x0098787B File Offset: 0x00985A7B
		public unsafe double Max_Active_Radius
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_cpuRayCasting_camera_C.__PropertyOffset_35);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_cpuRayCasting_camera_C.__PropertyOffset_35) = value;
			}
		}

		// Token: 0x17004778 RID: 18296
		// (get) Token: 0x060239EF RID: 145903 RVA: 0x0098788C File Offset: 0x00985A8C
		// (set) Token: 0x060239F0 RID: 145904 RVA: 0x0098789C File Offset: 0x00985A9C
		public unsafe bool Enable跷跷板
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_cpuRayCasting_camera_C.__PropertyOffset_36) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_cpuRayCasting_camera_C.__PropertyOffset_36) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004779 RID: 18297
		// (get) Token: 0x060239F1 RID: 145905 RVA: 0x009878AD File Offset: 0x00985AAD
		// (set) Token: 0x060239F2 RID: 145906 RVA: 0x009878BD File Offset: 0x00985ABD
		public unsafe float RayCastingDetectMax
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_cpuRayCasting_camera_C.__PropertyOffset_37);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_cpuRayCasting_camera_C.__PropertyOffset_37) = value;
			}
		}

		// Token: 0x1700477A RID: 18298
		// (get) Token: 0x060239F3 RID: 145907 RVA: 0x009878CE File Offset: 0x00985ACE
		// (set) Token: 0x060239F4 RID: 145908 RVA: 0x009878DE File Offset: 0x00985ADE
		public unsafe bool 固定碰撞体_旋转不可用_
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_cpuRayCasting_camera_C.__PropertyOffset_38) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_cpuRayCasting_camera_C.__PropertyOffset_38) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700477B RID: 18299
		// (get) Token: 0x060239F5 RID: 145909 RVA: 0x009878EF File Offset: 0x00985AEF
		// (set) Token: 0x060239F6 RID: 145910 RVA: 0x00987903 File Offset: 0x00985B03
		public unsafe FVector startWorldPos
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_cpuRayCasting_camera_C.__PropertyOffset_39);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_cpuRayCasting_camera_C.__PropertyOffset_39) = value;
			}
		}

		// Token: 0x1700477C RID: 18300
		// (get) Token: 0x060239F7 RID: 145911 RVA: 0x00987918 File Offset: 0x00985B18
		// (set) Token: 0x060239F8 RID: 145912 RVA: 0x00987928 File Offset: 0x00985B28
		public unsafe bool DebugMove
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_cpuRayCasting_camera_C.__PropertyOffset_40) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_cpuRayCasting_camera_C.__PropertyOffset_40) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700477D RID: 18301
		// (get) Token: 0x060239F9 RID: 145913 RVA: 0x00987939 File Offset: 0x00985B39
		// (set) Token: 0x060239FA RID: 145914 RVA: 0x00987949 File Offset: 0x00985B49
		public unsafe bool bEditorT
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_cpuRayCasting_camera_C.__PropertyOffset_41) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_cpuRayCasting_camera_C.__PropertyOffset_41) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700477E RID: 18302
		// (get) Token: 0x060239FB RID: 145915 RVA: 0x0098795A File Offset: 0x00985B5A
		// (set) Token: 0x060239FC RID: 145916 RVA: 0x0098796A File Offset: 0x00985B6A
		public unsafe bool bLinear
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_cpuRayCasting_camera_C.__PropertyOffset_42) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_cpuRayCasting_camera_C.__PropertyOffset_42) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700477F RID: 18303
		// (get) Token: 0x060239FD RID: 145917 RVA: 0x0098797B File Offset: 0x00985B7B
		// (set) Token: 0x060239FE RID: 145918 RVA: 0x0098798B File Offset: 0x00985B8B
		public unsafe bool bdebugTransform
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_cpuRayCasting_camera_C.__PropertyOffset_43) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_cpuRayCasting_camera_C.__PropertyOffset_43) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004780 RID: 18304
		// (get) Token: 0x060239FF RID: 145919 RVA: 0x0098799C File Offset: 0x00985B9C
		// (set) Token: 0x06023A00 RID: 145920 RVA: 0x009879D5 File Offset: 0x00985BD5
		public TArray<int> Intarr
		{
			get
			{
				base.FastCheckIsValid();
				TArray<int> result;
				if ((result = this._Intarr) == null)
				{
					result = (this._Intarr = new TArray<int>(base.NativePtr + (IntPtr)BP_cpuRayCasting_camera_C.__PropertyOffset_44, this));
				}
				return result;
			}
			set
			{
				this.Intarr.CopyAssign(value);
			}
		}

		// Token: 0x17004781 RID: 18305
		// (get) Token: 0x06023A01 RID: 145921 RVA: 0x009879E3 File Offset: 0x00985BE3
		// (set) Token: 0x06023A02 RID: 145922 RVA: 0x009879F7 File Offset: 0x00985BF7
		public unsafe FRandomStream randomStream
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_cpuRayCasting_camera_C.__PropertyOffset_45);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_cpuRayCasting_camera_C.__PropertyOffset_45) = value;
			}
		}

		// Token: 0x06023A03 RID: 145923 RVA: 0x00987A0C File Offset: 0x00985C0C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void boxcollisionConst()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_cpuRayCasting_camera_C.__boxcollisionConst_NativeFunctionPtr, null);
		}

		// Token: 0x06023A04 RID: 145924 RVA: 0x00987A20 File Offset: 0x00985C20
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Rotate_Plane_by_Player(bool OnPlaneOrNot, bool StopPlaneReturn)
		{
			BP_cpuRayCasting_camera_C.__Rotate_Plane_by_Player_FunctionParams* ptr = stackalloc BP_cpuRayCasting_camera_C.__Rotate_Plane_by_Player_FunctionParams[(UIntPtr)1567] + 15L / (long)sizeof(BP_cpuRayCasting_camera_C.__Rotate_Plane_by_Player_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_cpuRayCasting_camera_C.__Rotate_Plane_by_Player_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OnPlaneOrNot = OnPlaneOrNot;
			ptr->StopPlaneReturn = StopPlaneReturn;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_cpuRayCasting_camera_C.__Rotate_Plane_by_Player_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06023A05 RID: 145925 RVA: 0x00987A70 File Offset: 0x00985C70
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void updateScale()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_cpuRayCasting_camera_C.__updateScale_NativeFunctionPtr, null);
		}

		// Token: 0x06023A06 RID: 145926 RVA: 0x00987A84 File Offset: 0x00985C84
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void DebugMovement(float dt)
		{
			BP_cpuRayCasting_camera_C.__DebugMovement_FunctionParams* ptr = stackalloc BP_cpuRayCasting_camera_C.__DebugMovement_FunctionParams[(UIntPtr)247] + 15L / (long)sizeof(BP_cpuRayCasting_camera_C.__DebugMovement_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_cpuRayCasting_camera_C.__DebugMovement_NativeFunctionPtr, (void*)ptr, 1);
			ptr->dt = dt;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_cpuRayCasting_camera_C.__DebugMovement_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06023A07 RID: 145927 RVA: 0x00987ACD File Offset: 0x00985CCD
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Init_All()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_cpuRayCasting_camera_C.__Init_All_NativeFunctionPtr, null);
		}

		// Token: 0x06023A08 RID: 145928 RVA: 0x00987AE1 File Offset: 0x00985CE1
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Init_Triangles()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_cpuRayCasting_camera_C.__Init_Triangles_NativeFunctionPtr, null);
		}

		// Token: 0x06023A09 RID: 145929 RVA: 0x00987AF5 File Offset: 0x00985CF5
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Create_Mesh()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_cpuRayCasting_camera_C.__Create_Mesh_NativeFunctionPtr, null);
		}

		// Token: 0x06023A0A RID: 145930 RVA: 0x00987B09 File Offset: 0x00985D09
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void initRay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_cpuRayCasting_camera_C.__initRay_NativeFunctionPtr, null);
		}

		// Token: 0x06023A0B RID: 145931 RVA: 0x00987B1D File Offset: 0x00985D1D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_cpuRayCasting_camera_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06023A0C RID: 145932 RVA: 0x00987B31 File Offset: 0x00985D31
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_cpuRayCasting_camera_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06023A0D RID: 145933 RVA: 0x00987B46 File Offset: 0x00985D46
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EditorTick()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_cpuRayCasting_camera_C.__EditorTick_NativeFunctionPtr, null);
		}

		// Token: 0x06023A0E RID: 145934 RVA: 0x00987B5A File Offset: 0x00985D5A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void CustomEvent_0()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_cpuRayCasting_camera_C.__CustomEvent_0_NativeFunctionPtr, null);
		}

		// Token: 0x06023A0F RID: 145935 RVA: 0x00987B70 File Offset: 0x00985D70
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_cpuRayCasting_camera_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_cpuRayCasting_camera_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_cpuRayCasting_camera_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_cpuRayCasting_camera_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_cpuRayCasting_camera_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06023A10 RID: 145936 RVA: 0x00987BB8 File Offset: 0x00985DB8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_cpuRayCasting_camera_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_cpuRayCasting_camera_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_cpuRayCasting_camera_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_cpuRayCasting_camera_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_cpuRayCasting_camera_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06023A11 RID: 145937 RVA: 0x00987BFF File Offset: 0x00985DFF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_cpuRayCasting_camera_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06023A12 RID: 145938 RVA: 0x00987C13 File Offset: 0x00985E13
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_cpuRayCasting_camera_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06023A13 RID: 145939 RVA: 0x00987C28 File Offset: 0x00985E28
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_cpuRayCasting_camera(int EntryPoint)
		{
			BP_cpuRayCasting_camera_C.__ExecuteUbergraph_BP_cpuRayCasting_camera_FunctionParams* ptr = stackalloc BP_cpuRayCasting_camera_C.__ExecuteUbergraph_BP_cpuRayCasting_camera_FunctionParams[(UIntPtr)351] + 15L / (long)sizeof(BP_cpuRayCasting_camera_C.__ExecuteUbergraph_BP_cpuRayCasting_camera_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_cpuRayCasting_camera_C.__ExecuteUbergraph_BP_cpuRayCasting_camera_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_cpuRayCasting_camera_C.__ExecuteUbergraph_BP_cpuRayCasting_camera_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06023A14 RID: 145940 RVA: 0x00987C72 File Offset: 0x00985E72
		protected BP_cpuRayCasting_camera_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04012248 RID: 74312
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/2DRayCastingGamePlay/Camera/BP_cpuRayCasting_camera.BP_cpuRayCasting_camera_C";

		// Token: 0x04012249 RID: 74313
		private static IntPtr _ClassPtr;

		// Token: 0x0401224A RID: 74314
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401224B RID: 74315
		internal static int __PropertyOffset_0;

		// Token: 0x0401224C RID: 74316
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0401224D RID: 74317
		internal static int __PropertyOffset_1;

		// Token: 0x0401224E RID: 74318
		internal static int __PropertyOffset_2;

		// Token: 0x0401224F RID: 74319
		internal static int __PropertyOffset_3;

		// Token: 0x04012250 RID: 74320
		internal static int __PropertyOffset_4;

		// Token: 0x04012251 RID: 74321
		internal static int __PropertyOffset_5;

		// Token: 0x04012252 RID: 74322
		internal static int __PropertyOffset_6;

		// Token: 0x04012253 RID: 74323
		[Nullable(2)]
		private TArray<float> _Dis;

		// Token: 0x04012254 RID: 74324
		internal static int __PropertyOffset_7;

		// Token: 0x04012255 RID: 74325
		[Nullable(2)]
		private TArray<FVector> _Dirs;

		// Token: 0x04012256 RID: 74326
		internal static int __PropertyOffset_8;

		// Token: 0x04012257 RID: 74327
		[Nullable(2)]
		private TArray<FVector> _EndPos;

		// Token: 0x04012258 RID: 74328
		internal static int __PropertyOffset_9;

		// Token: 0x04012259 RID: 74329
		internal static int __PropertyOffset_10;

		// Token: 0x0401225A RID: 74330
		internal static int __PropertyOffset_11;

		// Token: 0x0401225B RID: 74331
		internal static int __PropertyOffset_12;

		// Token: 0x0401225C RID: 74332
		[Nullable(2)]
		private TArray<FVector> _Vertices;

		// Token: 0x0401225D RID: 74333
		internal static int __PropertyOffset_13;

		// Token: 0x0401225E RID: 74334
		[Nullable(2)]
		private TArray<int> _triangles;

		// Token: 0x0401225F RID: 74335
		internal static int __PropertyOffset_14;

		// Token: 0x04012260 RID: 74336
		internal static int __PropertyOffset_15;

		// Token: 0x04012261 RID: 74337
		internal static int __PropertyOffset_16;

		// Token: 0x04012262 RID: 74338
		internal static int __PropertyOffset_17;

		// Token: 0x04012263 RID: 74339
		internal static int __PropertyOffset_18;

		// Token: 0x04012264 RID: 74340
		internal static int __PropertyOffset_19;

		// Token: 0x04012265 RID: 74341
		[Nullable(2)]
		private TArray<FName> _ParamNameList;

		// Token: 0x04012266 RID: 74342
		internal static int __PropertyOffset_20;

		// Token: 0x04012267 RID: 74343
		[Nullable(2)]
		private TArray<FVector2D> _UvList;

		// Token: 0x04012268 RID: 74344
		internal static int __PropertyOffset_21;

		// Token: 0x04012269 RID: 74345
		internal static int __PropertyOffset_22;

		// Token: 0x0401226A RID: 74346
		internal static int __PropertyOffset_23;

		// Token: 0x0401226B RID: 74347
		internal static int __PropertyOffset_24;

		// Token: 0x0401226C RID: 74348
		internal static int __PropertyOffset_25;

		// Token: 0x0401226D RID: 74349
		internal static int __PropertyOffset_26;

		// Token: 0x0401226E RID: 74350
		internal static int __PropertyOffset_27;

		// Token: 0x0401226F RID: 74351
		internal static int __PropertyOffset_28;

		// Token: 0x04012270 RID: 74352
		internal static int __PropertyOffset_29;

		// Token: 0x04012271 RID: 74353
		internal static int __PropertyOffset_30;

		// Token: 0x04012272 RID: 74354
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<AActor> _IgnoreActors;

		// Token: 0x04012273 RID: 74355
		internal static int __PropertyOffset_31;

		// Token: 0x04012274 RID: 74356
		internal static int __PropertyOffset_32;

		// Token: 0x04012275 RID: 74357
		internal static int __PropertyOffset_33;

		// Token: 0x04012276 RID: 74358
		internal static int __PropertyOffset_34;

		// Token: 0x04012277 RID: 74359
		internal static int __PropertyOffset_35;

		// Token: 0x04012278 RID: 74360
		internal static int __PropertyOffset_36;

		// Token: 0x04012279 RID: 74361
		internal static int __PropertyOffset_37;

		// Token: 0x0401227A RID: 74362
		internal static int __PropertyOffset_38;

		// Token: 0x0401227B RID: 74363
		internal static int __PropertyOffset_39;

		// Token: 0x0401227C RID: 74364
		internal static int __PropertyOffset_40;

		// Token: 0x0401227D RID: 74365
		internal static int __PropertyOffset_41;

		// Token: 0x0401227E RID: 74366
		internal static int __PropertyOffset_42;

		// Token: 0x0401227F RID: 74367
		internal static int __PropertyOffset_43;

		// Token: 0x04012280 RID: 74368
		internal static int __PropertyOffset_44;

		// Token: 0x04012281 RID: 74369
		[Nullable(2)]
		private TArray<int> _Intarr;

		// Token: 0x04012282 RID: 74370
		internal static int __PropertyOffset_45;

		// Token: 0x04012283 RID: 74371
		private static IntPtr __boxcollisionConst_NativeFunctionPtr;

		// Token: 0x04012284 RID: 74372
		private static IntPtr __Rotate_Plane_by_Player_NativeFunctionPtr;

		// Token: 0x04012285 RID: 74373
		private static IntPtr __updateScale_NativeFunctionPtr;

		// Token: 0x04012286 RID: 74374
		private static IntPtr __DebugMovement_NativeFunctionPtr;

		// Token: 0x04012287 RID: 74375
		private static IntPtr __Init_All_NativeFunctionPtr;

		// Token: 0x04012288 RID: 74376
		private static IntPtr __Init_Triangles_NativeFunctionPtr;

		// Token: 0x04012289 RID: 74377
		private static IntPtr __Create_Mesh_NativeFunctionPtr;

		// Token: 0x0401228A RID: 74378
		private static IntPtr __initRay_NativeFunctionPtr;

		// Token: 0x0401228B RID: 74379
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0401228C RID: 74380
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x0401228D RID: 74381
		private static IntPtr __CustomEvent_0_NativeFunctionPtr;

		// Token: 0x0401228E RID: 74382
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0401228F RID: 74383
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04012290 RID: 74384
		private static IntPtr __ExecuteUbergraph_BP_cpuRayCasting_camera_NativeFunctionPtr;

		// Token: 0x02009D0C RID: 40204
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1552)]
		protected ref struct __Rotate_Plane_by_Player_FunctionParams
		{
			// Token: 0x040326C4 RID: 206532
			[FieldOffset(0)]
			public bool OnPlaneOrNot;

			// Token: 0x040326C5 RID: 206533
			[FieldOffset(1)]
			public bool StopPlaneReturn;
		}

		// Token: 0x02009D0D RID: 40205
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 232)]
		protected ref struct __DebugMovement_FunctionParams
		{
			// Token: 0x040326C6 RID: 206534
			[FieldOffset(0)]
			public float dt;
		}

		// Token: 0x02009D0E RID: 40206
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x040326C7 RID: 206535
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009D0F RID: 40207
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 336)]
		protected ref struct __ExecuteUbergraph_BP_cpuRayCasting_camera_FunctionParams
		{
			// Token: 0x040326C8 RID: 206536
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
