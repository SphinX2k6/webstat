using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Effect;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG._2DRayCastingGamePlay.BuildNewVertexBuffer
{
	// Token: 0x02003C53 RID: 15443
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/2DRayCastingGamePlay/BuildNewVertexBuffer/BP_cpuRayCasting_vertex.BP_cpuRayCasting_vertex_C")]
	[UnrealStructLayout(2000, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1992)]
	public class BP_cpuRayCasting_vertex_C : AHexagonConsumer, IUnrealUObject, IUnrealObject, IBPI_EffectInterface_C, IUnrealBlueprintInterface, IUnrealInterface
	{
		// Token: 0x06023A15 RID: 145941 RVA: 0x00987C7B File Offset: 0x00985E7B
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_cpuRayCasting_vertex_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/2DRayCastingGamePlay/BuildNewVertexBuffer/BP_cpuRayCasting_vertex.BP_cpuRayCasting_vertex_C");
			}
			return BP_cpuRayCasting_vertex_C._ClassPtr;
		}

		// Token: 0x06023A16 RID: 145942 RVA: 0x00987CA0 File Offset: 0x00985EA0
		public BP_cpuRayCasting_vertex_C() : this(BuiltinUtils.AllocNativeUObject(BP_cpuRayCasting_vertex_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06023A17 RID: 145943 RVA: 0x00987CC8 File Offset: 0x00985EC8
		[NullableContext(1)]
		public BP_cpuRayCasting_vertex_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_cpuRayCasting_vertex_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17004782 RID: 18306
		// (get) Token: 0x06023A18 RID: 145944 RVA: 0x00987CFC File Offset: 0x00985EFC
		// (set) Token: 0x06023A19 RID: 145945 RVA: 0x00987D35 File Offset: 0x00985F35
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_cpuRayCasting_vertex_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_cpuRayCasting_vertex_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17004783 RID: 18307
		// (get) Token: 0x06023A1A RID: 145946 RVA: 0x00987D56 File Offset: 0x00985F56
		// (set) Token: 0x06023A1B RID: 145947 RVA: 0x00987D6A File Offset: 0x00985F6A
		public unsafe UStaticMeshComponent Plane1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_cpuRayCasting_vertex_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_cpuRayCasting_vertex_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17004784 RID: 18308
		// (get) Token: 0x06023A1C RID: 145948 RVA: 0x00987D7F File Offset: 0x00985F7F
		// (set) Token: 0x06023A1D RID: 145949 RVA: 0x00987D93 File Offset: 0x00985F93
		public unsafe UBoxComponent Box_Collision
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_cpuRayCasting_vertex_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_cpuRayCasting_vertex_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17004785 RID: 18309
		// (get) Token: 0x06023A1E RID: 145950 RVA: 0x00987DA8 File Offset: 0x00985FA8
		// (set) Token: 0x06023A1F RID: 145951 RVA: 0x00987DE1 File Offset: 0x00985FE1
		[Nullable(1)]
		public TArray<FVector> EndPos
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<FVector> result;
				if ((result = this._EndPos) == null)
				{
					result = (this._EndPos = new TArray<FVector>(base.NativePtr + (IntPtr)BP_cpuRayCasting_vertex_C.__PropertyOffset_3, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.EndPos.CopyAssign(value);
			}
		}

		// Token: 0x17004786 RID: 18310
		// (get) Token: 0x06023A20 RID: 145952 RVA: 0x00987DEF File Offset: 0x00985FEF
		// (set) Token: 0x06023A21 RID: 145953 RVA: 0x00987DFF File Offset: 0x00985FFF
		public unsafe float RayCastingDetectDis
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_cpuRayCasting_vertex_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_cpuRayCasting_vertex_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17004787 RID: 18311
		// (get) Token: 0x06023A22 RID: 145954 RVA: 0x00987E10 File Offset: 0x00986010
		// (set) Token: 0x06023A23 RID: 145955 RVA: 0x00987E20 File Offset: 0x00986020
		public unsafe int CountIndex
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_cpuRayCasting_vertex_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_cpuRayCasting_vertex_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17004788 RID: 18312
		// (get) Token: 0x06023A24 RID: 145956 RVA: 0x00987E34 File Offset: 0x00986034
		// (set) Token: 0x06023A25 RID: 145957 RVA: 0x00987E6D File Offset: 0x0098606D
		[Nullable(1)]
		public TArray<FVector> Vertices
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<FVector> result;
				if ((result = this._Vertices) == null)
				{
					result = (this._Vertices = new TArray<FVector>(base.NativePtr + (IntPtr)BP_cpuRayCasting_vertex_C.__PropertyOffset_6, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Vertices.CopyAssign(value);
			}
		}

		// Token: 0x17004789 RID: 18313
		// (get) Token: 0x06023A26 RID: 145958 RVA: 0x00987E7C File Offset: 0x0098607C
		// (set) Token: 0x06023A27 RID: 145959 RVA: 0x00987EB5 File Offset: 0x009860B5
		[Nullable(1)]
		public TArray<int> triangles
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<int> result;
				if ((result = this._triangles) == null)
				{
					result = (this._triangles = new TArray<int>(base.NativePtr + (IntPtr)BP_cpuRayCasting_vertex_C.__PropertyOffset_7, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.triangles.CopyAssign(value);
			}
		}

		// Token: 0x1700478A RID: 18314
		// (get) Token: 0x06023A28 RID: 145960 RVA: 0x00987EC4 File Offset: 0x009860C4
		// (set) Token: 0x06023A29 RID: 145961 RVA: 0x00987EFD File Offset: 0x009860FD
		[Nullable(1)]
		public FSoftObjectPath EffectNormal
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				FSoftObjectPath result;
				if ((result = this._EffectNormal) == null)
				{
					result = (this._EffectNormal = new FSoftObjectPath(base.NativePtr + (IntPtr)BP_cpuRayCasting_vertex_C.__PropertyOffset_8, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FSoftObjectPath.StaticStruct(), base.NativePtr + (IntPtr)BP_cpuRayCasting_vertex_C.__PropertyOffset_8, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700478B RID: 18315
		// (get) Token: 0x06023A2A RID: 145962 RVA: 0x00987F1E File Offset: 0x0098611E
		// (set) Token: 0x06023A2B RID: 145963 RVA: 0x00987F2E File Offset: 0x0098612E
		public unsafe bool stopMeshing
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_cpuRayCasting_vertex_C.__PropertyOffset_9) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_cpuRayCasting_vertex_C.__PropertyOffset_9) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700478C RID: 18316
		// (get) Token: 0x06023A2C RID: 145964 RVA: 0x00987F3F File Offset: 0x0098613F
		// (set) Token: 0x06023A2D RID: 145965 RVA: 0x00987F53 File Offset: 0x00986153
		public unsafe FRotator RayStartoRatation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_cpuRayCasting_vertex_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_cpuRayCasting_vertex_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x1700478D RID: 18317
		// (get) Token: 0x06023A2E RID: 145966 RVA: 0x00987F68 File Offset: 0x00986168
		// (set) Token: 0x06023A2F RID: 145967 RVA: 0x00987F78 File Offset: 0x00986178
		public unsafe int BatchSize
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_cpuRayCasting_vertex_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_cpuRayCasting_vertex_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x1700478E RID: 18318
		// (get) Token: 0x06023A30 RID: 145968 RVA: 0x00987F89 File Offset: 0x00986189
		// (set) Token: 0x06023A31 RID: 145969 RVA: 0x00987F99 File Offset: 0x00986199
		public unsafe bool PlayerColOnOrNot
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_cpuRayCasting_vertex_C.__PropertyOffset_12) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_cpuRayCasting_vertex_C.__PropertyOffset_12) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700478F RID: 18319
		// (get) Token: 0x06023A32 RID: 145970 RVA: 0x00987FAA File Offset: 0x009861AA
		// (set) Token: 0x06023A33 RID: 145971 RVA: 0x00987FBA File Offset: 0x009861BA
		public unsafe bool drawdebug
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_cpuRayCasting_vertex_C.__PropertyOffset_13) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_cpuRayCasting_vertex_C.__PropertyOffset_13) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004790 RID: 18320
		// (get) Token: 0x06023A34 RID: 145972 RVA: 0x00987FCB File Offset: 0x009861CB
		// (set) Token: 0x06023A35 RID: 145973 RVA: 0x00987FDB File Offset: 0x009861DB
		public unsafe bool motionOn
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_cpuRayCasting_vertex_C.__PropertyOffset_14) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_cpuRayCasting_vertex_C.__PropertyOffset_14) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004791 RID: 18321
		// (get) Token: 0x06023A36 RID: 145974 RVA: 0x00987FEC File Offset: 0x009861EC
		// (set) Token: 0x06023A37 RID: 145975 RVA: 0x00988000 File Offset: 0x00986200
		public unsafe FVector C
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_cpuRayCasting_vertex_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_cpuRayCasting_vertex_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x17004792 RID: 18322
		// (get) Token: 0x06023A38 RID: 145976 RVA: 0x00988015 File Offset: 0x00986215
		// (set) Token: 0x06023A39 RID: 145977 RVA: 0x00988025 File Offset: 0x00986225
		public unsafe float R
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_cpuRayCasting_vertex_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_cpuRayCasting_vertex_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x17004793 RID: 18323
		// (get) Token: 0x06023A3A RID: 145978 RVA: 0x00988036 File Offset: 0x00986236
		// (set) Token: 0x06023A3B RID: 145979 RVA: 0x00988046 File Offset: 0x00986246
		public unsafe float dA
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_cpuRayCasting_vertex_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_cpuRayCasting_vertex_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x17004794 RID: 18324
		// (get) Token: 0x06023A3C RID: 145980 RVA: 0x00988057 File Offset: 0x00986257
		// (set) Token: 0x06023A3D RID: 145981 RVA: 0x00988067 File Offset: 0x00986267
		public unsafe float A
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_cpuRayCasting_vertex_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_cpuRayCasting_vertex_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x17004795 RID: 18325
		// (get) Token: 0x06023A3E RID: 145982 RVA: 0x00988078 File Offset: 0x00986278
		// (set) Token: 0x06023A3F RID: 145983 RVA: 0x00988088 File Offset: 0x00986288
		public unsafe float debugangle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_cpuRayCasting_vertex_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_cpuRayCasting_vertex_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x17004796 RID: 18326
		// (get) Token: 0x06023A40 RID: 145984 RVA: 0x00988099 File Offset: 0x00986299
		// (set) Token: 0x06023A41 RID: 145985 RVA: 0x009880A9 File Offset: 0x009862A9
		public unsafe int debugdir
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_cpuRayCasting_vertex_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_cpuRayCasting_vertex_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x17004797 RID: 18327
		// (get) Token: 0x06023A42 RID: 145986 RVA: 0x009880BA File Offset: 0x009862BA
		// (set) Token: 0x06023A43 RID: 145987 RVA: 0x009880CA File Offset: 0x009862CA
		public unsafe float BoundingBoxSize
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_cpuRayCasting_vertex_C.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_cpuRayCasting_vertex_C.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x17004798 RID: 18328
		// (get) Token: 0x06023A44 RID: 145988 RVA: 0x009880DC File Offset: 0x009862DC
		// (set) Token: 0x06023A45 RID: 145989 RVA: 0x00988115 File Offset: 0x00986315
		[Nullable(1)]
		public TArray<AActor> IgnoreActors
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<AActor> result;
				if ((result = this._IgnoreActors) == null)
				{
					result = (this._IgnoreActors = new TArray<AActor>(base.NativePtr + (IntPtr)BP_cpuRayCasting_vertex_C.__PropertyOffset_22, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.IgnoreActors.CopyAssign(value);
			}
		}

		// Token: 0x17004799 RID: 18329
		// (get) Token: 0x06023A46 RID: 145990 RVA: 0x00988123 File Offset: 0x00986323
		// (set) Token: 0x06023A47 RID: 145991 RVA: 0x00988133 File Offset: 0x00986333
		public unsafe double Max_Degree_Angle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_cpuRayCasting_vertex_C.__PropertyOffset_23);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_cpuRayCasting_vertex_C.__PropertyOffset_23) = value;
			}
		}

		// Token: 0x1700479A RID: 18330
		// (get) Token: 0x06023A48 RID: 145992 RVA: 0x00988144 File Offset: 0x00986344
		// (set) Token: 0x06023A49 RID: 145993 RVA: 0x00988154 File Offset: 0x00986354
		public unsafe double Return_Speed_Degrees_Second
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_cpuRayCasting_vertex_C.__PropertyOffset_24);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_cpuRayCasting_vertex_C.__PropertyOffset_24) = value;
			}
		}

		// Token: 0x1700479B RID: 18331
		// (get) Token: 0x06023A4A RID: 145994 RVA: 0x00988165 File Offset: 0x00986365
		// (set) Token: 0x06023A4B RID: 145995 RVA: 0x00988175 File Offset: 0x00986375
		public unsafe double Follow_Speed_Degrees_Second
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_cpuRayCasting_vertex_C.__PropertyOffset_25);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_cpuRayCasting_vertex_C.__PropertyOffset_25) = value;
			}
		}

		// Token: 0x1700479C RID: 18332
		// (get) Token: 0x06023A4C RID: 145996 RVA: 0x00988186 File Offset: 0x00986386
		// (set) Token: 0x06023A4D RID: 145997 RVA: 0x00988196 File Offset: 0x00986396
		public unsafe double Min_Active_Radius
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_cpuRayCasting_vertex_C.__PropertyOffset_26);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_cpuRayCasting_vertex_C.__PropertyOffset_26) = value;
			}
		}

		// Token: 0x1700479D RID: 18333
		// (get) Token: 0x06023A4E RID: 145998 RVA: 0x009881A7 File Offset: 0x009863A7
		// (set) Token: 0x06023A4F RID: 145999 RVA: 0x009881B7 File Offset: 0x009863B7
		public unsafe double Max_Active_Radius
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_cpuRayCasting_vertex_C.__PropertyOffset_27);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_cpuRayCasting_vertex_C.__PropertyOffset_27) = value;
			}
		}

		// Token: 0x1700479E RID: 18334
		// (get) Token: 0x06023A50 RID: 146000 RVA: 0x009881C8 File Offset: 0x009863C8
		// (set) Token: 0x06023A51 RID: 146001 RVA: 0x009881D8 File Offset: 0x009863D8
		public unsafe bool Enable跷跷板
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_cpuRayCasting_vertex_C.__PropertyOffset_28) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_cpuRayCasting_vertex_C.__PropertyOffset_28) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700479F RID: 18335
		// (get) Token: 0x06023A52 RID: 146002 RVA: 0x009881E9 File Offset: 0x009863E9
		// (set) Token: 0x06023A53 RID: 146003 RVA: 0x009881F9 File Offset: 0x009863F9
		public unsafe float RayCastingDetectMax
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_cpuRayCasting_vertex_C.__PropertyOffset_29);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_cpuRayCasting_vertex_C.__PropertyOffset_29) = value;
			}
		}

		// Token: 0x170047A0 RID: 18336
		// (get) Token: 0x06023A54 RID: 146004 RVA: 0x0098820A File Offset: 0x0098640A
		// (set) Token: 0x06023A55 RID: 146005 RVA: 0x0098821E File Offset: 0x0098641E
		public unsafe FVector startWorldPos
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_cpuRayCasting_vertex_C.__PropertyOffset_30);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_cpuRayCasting_vertex_C.__PropertyOffset_30) = value;
			}
		}

		// Token: 0x170047A1 RID: 18337
		// (get) Token: 0x06023A56 RID: 146006 RVA: 0x00988233 File Offset: 0x00986433
		// (set) Token: 0x06023A57 RID: 146007 RVA: 0x00988243 File Offset: 0x00986443
		public unsafe bool DebugMove
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_cpuRayCasting_vertex_C.__PropertyOffset_31) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_cpuRayCasting_vertex_C.__PropertyOffset_31) = (value ? 1 : 0);
			}
		}

		// Token: 0x170047A2 RID: 18338
		// (get) Token: 0x06023A58 RID: 146008 RVA: 0x00988254 File Offset: 0x00986454
		// (set) Token: 0x06023A59 RID: 146009 RVA: 0x00988264 File Offset: 0x00986464
		public unsafe bool bEditorT
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_cpuRayCasting_vertex_C.__PropertyOffset_32) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_cpuRayCasting_vertex_C.__PropertyOffset_32) = (value ? 1 : 0);
			}
		}

		// Token: 0x170047A3 RID: 18339
		// (get) Token: 0x06023A5A RID: 146010 RVA: 0x00988275 File Offset: 0x00986475
		// (set) Token: 0x06023A5B RID: 146011 RVA: 0x00988285 File Offset: 0x00986485
		public unsafe bool bdebugTransform
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_cpuRayCasting_vertex_C.__PropertyOffset_33) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_cpuRayCasting_vertex_C.__PropertyOffset_33) = (value ? 1 : 0);
			}
		}

		// Token: 0x170047A4 RID: 18340
		// (get) Token: 0x06023A5C RID: 146012 RVA: 0x00988296 File Offset: 0x00986496
		// (set) Token: 0x06023A5D RID: 146013 RVA: 0x009882AA File Offset: 0x009864AA
		public unsafe UTextureRenderTarget2D cap
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_cpuRayCasting_vertex_C.__PropertyOffset_34);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_cpuRayCasting_vertex_C.__PropertyOffset_34, value);
			}
		}

		// Token: 0x170047A5 RID: 18341
		// (get) Token: 0x06023A5E RID: 146014 RVA: 0x009882BF File Offset: 0x009864BF
		// (set) Token: 0x06023A5F RID: 146015 RVA: 0x009882D3 File Offset: 0x009864D3
		public unsafe UTextureRenderTarget2D final
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_cpuRayCasting_vertex_C.__PropertyOffset_35);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_cpuRayCasting_vertex_C.__PropertyOffset_35, value);
			}
		}

		// Token: 0x170047A6 RID: 18342
		// (get) Token: 0x06023A60 RID: 146016 RVA: 0x009882E8 File Offset: 0x009864E8
		// (set) Token: 0x06023A61 RID: 146017 RVA: 0x009882FC File Offset: 0x009864FC
		public unsafe UMaterialInstanceDynamic DMat_add
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_cpuRayCasting_vertex_C.__PropertyOffset_36);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_cpuRayCasting_vertex_C.__PropertyOffset_36, value);
			}
		}

		// Token: 0x170047A7 RID: 18343
		// (get) Token: 0x06023A62 RID: 146018 RVA: 0x00988311 File Offset: 0x00986511
		// (set) Token: 0x06023A63 RID: 146019 RVA: 0x00988325 File Offset: 0x00986525
		public unsafe UMaterialInstanceDynamic DMat_preview
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_cpuRayCasting_vertex_C.__PropertyOffset_37);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_cpuRayCasting_vertex_C.__PropertyOffset_37, value);
			}
		}

		// Token: 0x170047A8 RID: 18344
		// (get) Token: 0x06023A64 RID: 146020 RVA: 0x0098833A File Offset: 0x0098653A
		// (set) Token: 0x06023A65 RID: 146021 RVA: 0x0098834E File Offset: 0x0098654E
		public unsafe UMaterialInstanceDynamic DMat_preview_ice
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_cpuRayCasting_vertex_C.__PropertyOffset_38);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_cpuRayCasting_vertex_C.__PropertyOffset_38, value);
			}
		}

		// Token: 0x170047A9 RID: 18345
		// (get) Token: 0x06023A66 RID: 146022 RVA: 0x00988363 File Offset: 0x00986563
		// (set) Token: 0x06023A67 RID: 146023 RVA: 0x00988373 File Offset: 0x00986573
		public unsafe bool DoNotNeedRayCasting
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_cpuRayCasting_vertex_C.__PropertyOffset_39) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_cpuRayCasting_vertex_C.__PropertyOffset_39) = (value ? 1 : 0);
			}
		}

		// Token: 0x170047AA RID: 18346
		// (get) Token: 0x06023A68 RID: 146024 RVA: 0x00988384 File Offset: 0x00986584
		// (set) Token: 0x06023A69 RID: 146025 RVA: 0x00988394 File Offset: 0x00986594
		public unsafe int RTSize
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_cpuRayCasting_vertex_C.__PropertyOffset_40);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_cpuRayCasting_vertex_C.__PropertyOffset_40) = value;
			}
		}

		// Token: 0x170047AB RID: 18347
		// (get) Token: 0x06023A6A RID: 146026 RVA: 0x009883A5 File Offset: 0x009865A5
		// (set) Token: 0x06023A6B RID: 146027 RVA: 0x009883B5 File Offset: 0x009865B5
		public unsafe bool 是不是冰封状态_
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_cpuRayCasting_vertex_C.__PropertyOffset_41) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_cpuRayCasting_vertex_C.__PropertyOffset_41) = (value ? 1 : 0);
			}
		}

		// Token: 0x170047AC RID: 18348
		// (get) Token: 0x06023A6C RID: 146028 RVA: 0x009883C6 File Offset: 0x009865C6
		// (set) Token: 0x06023A6D RID: 146029 RVA: 0x009883D6 File Offset: 0x009865D6
		public unsafe bool 锁定碰撞体模式_跷跷板直接关闭_
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_cpuRayCasting_vertex_C.__PropertyOffset_42) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_cpuRayCasting_vertex_C.__PropertyOffset_42) = (value ? 1 : 0);
			}
		}

		// Token: 0x170047AD RID: 18349
		// (get) Token: 0x06023A6E RID: 146030 RVA: 0x009883E7 File Offset: 0x009865E7
		// (set) Token: 0x06023A6F RID: 146031 RVA: 0x009883F7 File Offset: 0x009865F7
		public unsafe bool 多个光片模式_玩家离开立刻停止跷跷板_
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_cpuRayCasting_vertex_C.__PropertyOffset_43) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_cpuRayCasting_vertex_C.__PropertyOffset_43) = (value ? 1 : 0);
			}
		}

		// Token: 0x170047AE RID: 18350
		// (get) Token: 0x06023A70 RID: 146032 RVA: 0x00988408 File Offset: 0x00986608
		// (set) Token: 0x06023A71 RID: 146033 RVA: 0x0098841C File Offset: 0x0098661C
		public unsafe FTransform startTransform
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_cpuRayCasting_vertex_C.__PropertyOffset_44);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_cpuRayCasting_vertex_C.__PropertyOffset_44) = value;
			}
		}

		// Token: 0x170047AF RID: 18351
		// (get) Token: 0x06023A72 RID: 146034 RVA: 0x00988431 File Offset: 0x00986631
		// (set) Token: 0x06023A73 RID: 146035 RVA: 0x00988441 File Offset: 0x00986641
		public unsafe float LastFrameRayCastingDis
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_cpuRayCasting_vertex_C.__PropertyOffset_45);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_cpuRayCasting_vertex_C.__PropertyOffset_45) = value;
			}
		}

		// Token: 0x170047B0 RID: 18352
		// (get) Token: 0x06023A74 RID: 146036 RVA: 0x00988452 File Offset: 0x00986652
		// (set) Token: 0x06023A75 RID: 146037 RVA: 0x00988462 File Offset: 0x00986662
		public unsafe bool LastFrame_是不是冰封状态_
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_cpuRayCasting_vertex_C.__PropertyOffset_46) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_cpuRayCasting_vertex_C.__PropertyOffset_46) = (value ? 1 : 0);
			}
		}

		// Token: 0x170047B1 RID: 18353
		// (get) Token: 0x06023A76 RID: 146038 RVA: 0x00988473 File Offset: 0x00986673
		// (set) Token: 0x06023A77 RID: 146039 RVA: 0x00988487 File Offset: 0x00986687
		public unsafe AStaticMeshActor actorBox
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AStaticMeshActor>(base.NativePtr / (IntPtr)sizeof(void*) + BP_cpuRayCasting_vertex_C.__PropertyOffset_47);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_cpuRayCasting_vertex_C.__PropertyOffset_47, value);
			}
		}

		// Token: 0x170047B2 RID: 18354
		// (get) Token: 0x06023A78 RID: 146040 RVA: 0x0098849C File Offset: 0x0098669C
		// (set) Token: 0x06023A79 RID: 146041 RVA: 0x009884D5 File Offset: 0x009866D5
		[Nullable(1)]
		public TArray<FVector> SkipTraceBoxOrigins
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<FVector> result;
				if ((result = this._SkipTraceBoxOrigins) == null)
				{
					result = (this._SkipTraceBoxOrigins = new TArray<FVector>(base.NativePtr + (IntPtr)BP_cpuRayCasting_vertex_C.__PropertyOffset_48, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.SkipTraceBoxOrigins.CopyAssign(value);
			}
		}

		// Token: 0x170047B3 RID: 18355
		// (get) Token: 0x06023A7A RID: 146042 RVA: 0x009884E4 File Offset: 0x009866E4
		// (set) Token: 0x06023A7B RID: 146043 RVA: 0x0098851D File Offset: 0x0098671D
		[Nullable(1)]
		public TArray<FVector> SkipTraceBoxExtent
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<FVector> result;
				if ((result = this._SkipTraceBoxExtent) == null)
				{
					result = (this._SkipTraceBoxExtent = new TArray<FVector>(base.NativePtr + (IntPtr)BP_cpuRayCasting_vertex_C.__PropertyOffset_49, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.SkipTraceBoxExtent.CopyAssign(value);
			}
		}

		// Token: 0x170047B4 RID: 18356
		// (get) Token: 0x06023A7C RID: 146044 RVA: 0x0098852B File Offset: 0x0098672B
		// (set) Token: 0x06023A7D RID: 146045 RVA: 0x0098853F File Offset: 0x0098673F
		public unsafe PD_EntityIDToBoxArr_C DataAsset
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<PD_EntityIDToBoxArr_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_cpuRayCasting_vertex_C.__PropertyOffset_50);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_cpuRayCasting_vertex_C.__PropertyOffset_50, value);
			}
		}

		// Token: 0x06023A7E RID: 146046 RVA: 0x00988554 File Offset: 0x00986754
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetHandle(ref int Handle)
		{
			BP_cpuRayCasting_vertex_C.__GetHandle_FunctionParams* ptr = stackalloc BP_cpuRayCasting_vertex_C.__GetHandle_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_cpuRayCasting_vertex_C.__GetHandle_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_cpuRayCasting_vertex_C.__GetHandle_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Handle = Handle;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_cpuRayCasting_vertex_C.__GetHandle_NativeFunctionPtr, (void*)ptr);
			Handle = ptr->Handle;
		}

		// Token: 0x06023A7F RID: 146047 RVA: 0x009885A3 File Offset: 0x009867A3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void boxcollisionConst()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_cpuRayCasting_vertex_C.__boxcollisionConst_NativeFunctionPtr, null);
		}

		// Token: 0x06023A80 RID: 146048 RVA: 0x009885B8 File Offset: 0x009867B8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Rotate_Plane_by_Player(bool OnPlaneOrNot, bool StopPlaneReturn)
		{
			BP_cpuRayCasting_vertex_C.__Rotate_Plane_by_Player_FunctionParams* ptr = stackalloc BP_cpuRayCasting_vertex_C.__Rotate_Plane_by_Player_FunctionParams[(UIntPtr)1551] + 15L / (long)sizeof(BP_cpuRayCasting_vertex_C.__Rotate_Plane_by_Player_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_cpuRayCasting_vertex_C.__Rotate_Plane_by_Player_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OnPlaneOrNot = OnPlaneOrNot;
			ptr->StopPlaneReturn = StopPlaneReturn;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_cpuRayCasting_vertex_C.__Rotate_Plane_by_Player_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06023A81 RID: 146049 RVA: 0x00988608 File Offset: 0x00986808
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void DebugMovement(float dt)
		{
			BP_cpuRayCasting_vertex_C.__DebugMovement_FunctionParams* ptr = stackalloc BP_cpuRayCasting_vertex_C.__DebugMovement_FunctionParams[(UIntPtr)247] + 15L / (long)sizeof(BP_cpuRayCasting_vertex_C.__DebugMovement_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_cpuRayCasting_vertex_C.__DebugMovement_NativeFunctionPtr, (void*)ptr, 1);
			ptr->dt = dt;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_cpuRayCasting_vertex_C.__DebugMovement_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06023A82 RID: 146050 RVA: 0x00988651 File Offset: 0x00986851
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Init_All()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_cpuRayCasting_vertex_C.__Init_All_NativeFunctionPtr, null);
		}

		// Token: 0x06023A83 RID: 146051 RVA: 0x00988665 File Offset: 0x00986865
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Init_Triangles()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_cpuRayCasting_vertex_C.__Init_Triangles_NativeFunctionPtr, null);
		}

		// Token: 0x06023A84 RID: 146052 RVA: 0x00988679 File Offset: 0x00986879
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void initRay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_cpuRayCasting_vertex_C.__initRay_NativeFunctionPtr, null);
		}

		// Token: 0x06023A85 RID: 146053 RVA: 0x0098868D File Offset: 0x0098688D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_cpuRayCasting_vertex_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06023A86 RID: 146054 RVA: 0x009886A1 File Offset: 0x009868A1
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_cpuRayCasting_vertex_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06023A87 RID: 146055 RVA: 0x009886B6 File Offset: 0x009868B6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void CustomEvent_0()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_cpuRayCasting_vertex_C.__CustomEvent_0_NativeFunctionPtr, null);
		}

		// Token: 0x06023A88 RID: 146056 RVA: 0x009886CA File Offset: 0x009868CA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EditorTick()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_cpuRayCasting_vertex_C.__EditorTick_NativeFunctionPtr, null);
		}

		// Token: 0x06023A89 RID: 146057 RVA: 0x009886E0 File Offset: 0x009868E0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_cpuRayCasting_vertex_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_cpuRayCasting_vertex_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_cpuRayCasting_vertex_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_cpuRayCasting_vertex_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_cpuRayCasting_vertex_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06023A8A RID: 146058 RVA: 0x00988728 File Offset: 0x00986928
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_cpuRayCasting_vertex_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_cpuRayCasting_vertex_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_cpuRayCasting_vertex_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_cpuRayCasting_vertex_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_cpuRayCasting_vertex_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06023A8B RID: 146059 RVA: 0x0098876F File Offset: 0x0098696F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_cpuRayCasting_vertex_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06023A8C RID: 146060 RVA: 0x00988783 File Offset: 0x00986983
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_cpuRayCasting_vertex_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06023A8D RID: 146061 RVA: 0x00988798 File Offset: 0x00986998
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void CustomEvent1()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_cpuRayCasting_vertex_C.__CustomEvent1_NativeFunctionPtr, null);
		}

		// Token: 0x06023A8E RID: 146062 RVA: 0x009887AC File Offset: 0x009869AC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void test()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_cpuRayCasting_vertex_C.__test_NativeFunctionPtr, null);
		}

		// Token: 0x06023A8F RID: 146063 RVA: 0x009887C0 File Offset: 0x009869C0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SeveralLightPlane()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_cpuRayCasting_vertex_C.__SeveralLightPlane_NativeFunctionPtr, null);
		}

		// Token: 0x06023A90 RID: 146064 RVA: 0x009887D4 File Offset: 0x009869D4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void RemoveHandle()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_cpuRayCasting_vertex_C.__RemoveHandle_NativeFunctionPtr, null);
		}

		// Token: 0x06023A91 RID: 146065 RVA: 0x009887E8 File Offset: 0x009869E8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SaveBoxToBp()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_cpuRayCasting_vertex_C.__SaveBoxToBp_NativeFunctionPtr, null);
		}

		// Token: 0x06023A92 RID: 146066 RVA: 0x009887FC File Offset: 0x009869FC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetHandle(int Handle)
		{
			BP_cpuRayCasting_vertex_C.__SetHandle_FunctionParams* ptr = stackalloc BP_cpuRayCasting_vertex_C.__SetHandle_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_cpuRayCasting_vertex_C.__SetHandle_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_cpuRayCasting_vertex_C.__SetHandle_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Handle = Handle;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_cpuRayCasting_vertex_C.__SetHandle_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06023A93 RID: 146067 RVA: 0x00988842 File Offset: 0x00986A42
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SaveBoxArrToDA()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_cpuRayCasting_vertex_C.__SaveBoxArrToDA_NativeFunctionPtr, null);
		}

		// Token: 0x06023A94 RID: 146068 RVA: 0x00988858 File Offset: 0x00986A58
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_cpuRayCasting_vertex(int EntryPoint)
		{
			BP_cpuRayCasting_vertex_C.__ExecuteUbergraph_BP_cpuRayCasting_vertex_FunctionParams* ptr = stackalloc BP_cpuRayCasting_vertex_C.__ExecuteUbergraph_BP_cpuRayCasting_vertex_FunctionParams[(UIntPtr)639] + 15L / (long)sizeof(BP_cpuRayCasting_vertex_C.__ExecuteUbergraph_BP_cpuRayCasting_vertex_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_cpuRayCasting_vertex_C.__ExecuteUbergraph_BP_cpuRayCasting_vertex_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_cpuRayCasting_vertex_C.__ExecuteUbergraph_BP_cpuRayCasting_vertex_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06023A95 RID: 146069 RVA: 0x009888A2 File Offset: 0x00986AA2
		protected BP_cpuRayCasting_vertex_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04012291 RID: 74385
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/2DRayCastingGamePlay/BuildNewVertexBuffer/BP_cpuRayCasting_vertex.BP_cpuRayCasting_vertex_C";

		// Token: 0x04012292 RID: 74386
		private static IntPtr _ClassPtr;

		// Token: 0x04012293 RID: 74387
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04012294 RID: 74388
		internal static int __PropertyOffset_0;

		// Token: 0x04012295 RID: 74389
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04012296 RID: 74390
		internal static int __PropertyOffset_1;

		// Token: 0x04012297 RID: 74391
		internal static int __PropertyOffset_2;

		// Token: 0x04012298 RID: 74392
		internal static int __PropertyOffset_3;

		// Token: 0x04012299 RID: 74393
		private TArray<FVector> _EndPos;

		// Token: 0x0401229A RID: 74394
		internal static int __PropertyOffset_4;

		// Token: 0x0401229B RID: 74395
		internal static int __PropertyOffset_5;

		// Token: 0x0401229C RID: 74396
		internal static int __PropertyOffset_6;

		// Token: 0x0401229D RID: 74397
		private TArray<FVector> _Vertices;

		// Token: 0x0401229E RID: 74398
		internal static int __PropertyOffset_7;

		// Token: 0x0401229F RID: 74399
		private TArray<int> _triangles;

		// Token: 0x040122A0 RID: 74400
		internal static int __PropertyOffset_8;

		// Token: 0x040122A1 RID: 74401
		private FSoftObjectPath _EffectNormal;

		// Token: 0x040122A2 RID: 74402
		internal static int __PropertyOffset_9;

		// Token: 0x040122A3 RID: 74403
		internal static int __PropertyOffset_10;

		// Token: 0x040122A4 RID: 74404
		internal static int __PropertyOffset_11;

		// Token: 0x040122A5 RID: 74405
		internal static int __PropertyOffset_12;

		// Token: 0x040122A6 RID: 74406
		internal static int __PropertyOffset_13;

		// Token: 0x040122A7 RID: 74407
		internal static int __PropertyOffset_14;

		// Token: 0x040122A8 RID: 74408
		internal static int __PropertyOffset_15;

		// Token: 0x040122A9 RID: 74409
		internal static int __PropertyOffset_16;

		// Token: 0x040122AA RID: 74410
		internal static int __PropertyOffset_17;

		// Token: 0x040122AB RID: 74411
		internal static int __PropertyOffset_18;

		// Token: 0x040122AC RID: 74412
		internal static int __PropertyOffset_19;

		// Token: 0x040122AD RID: 74413
		internal static int __PropertyOffset_20;

		// Token: 0x040122AE RID: 74414
		internal static int __PropertyOffset_21;

		// Token: 0x040122AF RID: 74415
		internal static int __PropertyOffset_22;

		// Token: 0x040122B0 RID: 74416
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<AActor> _IgnoreActors;

		// Token: 0x040122B1 RID: 74417
		internal static int __PropertyOffset_23;

		// Token: 0x040122B2 RID: 74418
		internal static int __PropertyOffset_24;

		// Token: 0x040122B3 RID: 74419
		internal static int __PropertyOffset_25;

		// Token: 0x040122B4 RID: 74420
		internal static int __PropertyOffset_26;

		// Token: 0x040122B5 RID: 74421
		internal static int __PropertyOffset_27;

		// Token: 0x040122B6 RID: 74422
		internal static int __PropertyOffset_28;

		// Token: 0x040122B7 RID: 74423
		internal static int __PropertyOffset_29;

		// Token: 0x040122B8 RID: 74424
		internal static int __PropertyOffset_30;

		// Token: 0x040122B9 RID: 74425
		internal static int __PropertyOffset_31;

		// Token: 0x040122BA RID: 74426
		internal static int __PropertyOffset_32;

		// Token: 0x040122BB RID: 74427
		internal static int __PropertyOffset_33;

		// Token: 0x040122BC RID: 74428
		internal static int __PropertyOffset_34;

		// Token: 0x040122BD RID: 74429
		internal static int __PropertyOffset_35;

		// Token: 0x040122BE RID: 74430
		internal static int __PropertyOffset_36;

		// Token: 0x040122BF RID: 74431
		internal static int __PropertyOffset_37;

		// Token: 0x040122C0 RID: 74432
		internal static int __PropertyOffset_38;

		// Token: 0x040122C1 RID: 74433
		internal static int __PropertyOffset_39;

		// Token: 0x040122C2 RID: 74434
		internal static int __PropertyOffset_40;

		// Token: 0x040122C3 RID: 74435
		internal static int __PropertyOffset_41;

		// Token: 0x040122C4 RID: 74436
		internal static int __PropertyOffset_42;

		// Token: 0x040122C5 RID: 74437
		internal static int __PropertyOffset_43;

		// Token: 0x040122C6 RID: 74438
		internal static int __PropertyOffset_44;

		// Token: 0x040122C7 RID: 74439
		internal static int __PropertyOffset_45;

		// Token: 0x040122C8 RID: 74440
		internal static int __PropertyOffset_46;

		// Token: 0x040122C9 RID: 74441
		internal static int __PropertyOffset_47;

		// Token: 0x040122CA RID: 74442
		internal static int __PropertyOffset_48;

		// Token: 0x040122CB RID: 74443
		private TArray<FVector> _SkipTraceBoxOrigins;

		// Token: 0x040122CC RID: 74444
		internal static int __PropertyOffset_49;

		// Token: 0x040122CD RID: 74445
		private TArray<FVector> _SkipTraceBoxExtent;

		// Token: 0x040122CE RID: 74446
		internal static int __PropertyOffset_50;

		// Token: 0x040122CF RID: 74447
		private static IntPtr __GetHandle_NativeFunctionPtr;

		// Token: 0x040122D0 RID: 74448
		private static IntPtr __boxcollisionConst_NativeFunctionPtr;

		// Token: 0x040122D1 RID: 74449
		private static IntPtr __Rotate_Plane_by_Player_NativeFunctionPtr;

		// Token: 0x040122D2 RID: 74450
		private static IntPtr __DebugMovement_NativeFunctionPtr;

		// Token: 0x040122D3 RID: 74451
		private static IntPtr __Init_All_NativeFunctionPtr;

		// Token: 0x040122D4 RID: 74452
		private static IntPtr __Init_Triangles_NativeFunctionPtr;

		// Token: 0x040122D5 RID: 74453
		private static IntPtr __initRay_NativeFunctionPtr;

		// Token: 0x040122D6 RID: 74454
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x040122D7 RID: 74455
		private static IntPtr __CustomEvent_0_NativeFunctionPtr;

		// Token: 0x040122D8 RID: 74456
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x040122D9 RID: 74457
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x040122DA RID: 74458
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x040122DB RID: 74459
		private static IntPtr __CustomEvent1_NativeFunctionPtr;

		// Token: 0x040122DC RID: 74460
		private static IntPtr __test_NativeFunctionPtr;

		// Token: 0x040122DD RID: 74461
		private static IntPtr __SeveralLightPlane_NativeFunctionPtr;

		// Token: 0x040122DE RID: 74462
		private static IntPtr __RemoveHandle_NativeFunctionPtr;

		// Token: 0x040122DF RID: 74463
		private static IntPtr __SaveBoxToBp_NativeFunctionPtr;

		// Token: 0x040122E0 RID: 74464
		private static IntPtr __SetHandle_NativeFunctionPtr;

		// Token: 0x040122E1 RID: 74465
		private static IntPtr __SaveBoxArrToDA_NativeFunctionPtr;

		// Token: 0x040122E2 RID: 74466
		private static IntPtr __ExecuteUbergraph_BP_cpuRayCasting_vertex_NativeFunctionPtr;

		// Token: 0x02009D10 RID: 40208
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __GetHandle_FunctionParams
		{
			// Token: 0x040326C9 RID: 206537
			[FieldOffset(0)]
			public int Handle;
		}

		// Token: 0x02009D11 RID: 40209
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1536)]
		protected ref struct __Rotate_Plane_by_Player_FunctionParams
		{
			// Token: 0x040326CA RID: 206538
			[FieldOffset(0)]
			public bool OnPlaneOrNot;

			// Token: 0x040326CB RID: 206539
			[FieldOffset(1)]
			public bool StopPlaneReturn;
		}

		// Token: 0x02009D12 RID: 40210
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 232)]
		protected ref struct __DebugMovement_FunctionParams
		{
			// Token: 0x040326CC RID: 206540
			[FieldOffset(0)]
			public float dt;
		}

		// Token: 0x02009D13 RID: 40211
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x040326CD RID: 206541
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009D14 RID: 40212
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __SetHandle_FunctionParams
		{
			// Token: 0x040326CE RID: 206542
			[FieldOffset(0)]
			public int Handle;
		}

		// Token: 0x02009D15 RID: 40213
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 624)]
		protected ref struct __ExecuteUbergraph_BP_cpuRayCasting_vertex_FunctionParams
		{
			// Token: 0x040326CF RID: 206543
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
