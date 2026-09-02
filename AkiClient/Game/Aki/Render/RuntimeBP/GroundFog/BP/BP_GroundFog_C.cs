using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.GroundFog.BP
{
	// Token: 0x02003C90 RID: 15504
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/GroundFog/BP/BP_GroundFog.BP_GroundFog_C")]
	[UnrealStructLayout(1552, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1545)]
	public class BP_GroundFog_C : AKuroEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060242BF RID: 148159 RVA: 0x009969B8 File Offset: 0x00994BB8
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_GroundFog_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/GroundFog/BP/BP_GroundFog.BP_GroundFog_C");
			}
			return BP_GroundFog_C._ClassPtr;
		}

		// Token: 0x060242C0 RID: 148160 RVA: 0x009969DC File Offset: 0x00994BDC
		public BP_GroundFog_C() : this(BuiltinUtils.AllocNativeUObject(BP_GroundFog_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060242C1 RID: 148161 RVA: 0x00996A04 File Offset: 0x00994C04
		[NullableContext(1)]
		public BP_GroundFog_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_GroundFog_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17004A74 RID: 19060
		// (get) Token: 0x060242C2 RID: 148162 RVA: 0x00996A38 File Offset: 0x00994C38
		// (set) Token: 0x060242C3 RID: 148163 RVA: 0x00996A71 File Offset: 0x00994C71
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_GroundFog_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_GroundFog_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17004A75 RID: 19061
		// (get) Token: 0x060242C4 RID: 148164 RVA: 0x00996A92 File Offset: 0x00994C92
		// (set) Token: 0x060242C5 RID: 148165 RVA: 0x00996AA6 File Offset: 0x00994CA6
		public unsafe UStaticMeshComponent CloudBaseMesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GroundFog_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GroundFog_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17004A76 RID: 19062
		// (get) Token: 0x060242C6 RID: 148166 RVA: 0x00996ABB File Offset: 0x00994CBB
		// (set) Token: 0x060242C7 RID: 148167 RVA: 0x00996ACF File Offset: 0x00994CCF
		public unsafe UArrowComponent Arrow
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UArrowComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GroundFog_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GroundFog_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17004A77 RID: 19063
		// (get) Token: 0x060242C8 RID: 148168 RVA: 0x00996AE4 File Offset: 0x00994CE4
		// (set) Token: 0x060242C9 RID: 148169 RVA: 0x00996AF8 File Offset: 0x00994CF8
		public unsafe UBillboardComponent Billboard
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBillboardComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GroundFog_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GroundFog_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17004A78 RID: 19064
		// (get) Token: 0x060242CA RID: 148170 RVA: 0x00996B0D File Offset: 0x00994D0D
		// (set) Token: 0x060242CB RID: 148171 RVA: 0x00996B21 File Offset: 0x00994D21
		public unsafe UNiagaraComponent Niagara
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GroundFog_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GroundFog_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17004A79 RID: 19065
		// (get) Token: 0x060242CC RID: 148172 RVA: 0x00996B36 File Offset: 0x00994D36
		// (set) Token: 0x060242CD RID: 148173 RVA: 0x00996B4A File Offset: 0x00994D4A
		public unsafe UProceduralMeshComponent ProceduralMesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UProceduralMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GroundFog_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GroundFog_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17004A7A RID: 19066
		// (get) Token: 0x060242CE RID: 148174 RVA: 0x00996B5F File Offset: 0x00994D5F
		// (set) Token: 0x060242CF RID: 148175 RVA: 0x00996B73 File Offset: 0x00994D73
		public unsafe USplineComponent Spline
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USplineComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GroundFog_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GroundFog_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x17004A7B RID: 19067
		// (get) Token: 0x060242D0 RID: 148176 RVA: 0x00996B88 File Offset: 0x00994D88
		// (set) Token: 0x060242D1 RID: 148177 RVA: 0x00996B9C File Offset: 0x00994D9C
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GroundFog_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GroundFog_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x17004A7C RID: 19068
		// (get) Token: 0x060242D2 RID: 148178 RVA: 0x00996BB1 File Offset: 0x00994DB1
		// (set) Token: 0x060242D3 RID: 148179 RVA: 0x00996BC1 File Offset: 0x00994DC1
		public unsafe int Segments
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GroundFog_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GroundFog_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17004A7D RID: 19069
		// (get) Token: 0x060242D4 RID: 148180 RVA: 0x00996BD4 File Offset: 0x00994DD4
		// (set) Token: 0x060242D5 RID: 148181 RVA: 0x00996C0D File Offset: 0x00994E0D
		[Nullable(1)]
		public TArray<FVector> PointArray
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<FVector> result;
				if ((result = this._PointArray) == null)
				{
					result = (this._PointArray = new TArray<FVector>(base.NativePtr + (IntPtr)BP_GroundFog_C.__PropertyOffset_9, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.PointArray.CopyAssign(value);
			}
		}

		// Token: 0x17004A7E RID: 19070
		// (get) Token: 0x060242D6 RID: 148182 RVA: 0x00996C1C File Offset: 0x00994E1C
		// (set) Token: 0x060242D7 RID: 148183 RVA: 0x00996C55 File Offset: 0x00994E55
		[Nullable(1)]
		public TArray<int> Triangles
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<int> result;
				if ((result = this._Triangles) == null)
				{
					result = (this._Triangles = new TArray<int>(base.NativePtr + (IntPtr)BP_GroundFog_C.__PropertyOffset_10, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Triangles.CopyAssign(value);
			}
		}

		// Token: 0x17004A7F RID: 19071
		// (get) Token: 0x060242D8 RID: 148184 RVA: 0x00996C64 File Offset: 0x00994E64
		// (set) Token: 0x060242D9 RID: 148185 RVA: 0x00996C9D File Offset: 0x00994E9D
		[Nullable(1)]
		public TArray<FVector> NormalArray
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<FVector> result;
				if ((result = this._NormalArray) == null)
				{
					result = (this._NormalArray = new TArray<FVector>(base.NativePtr + (IntPtr)BP_GroundFog_C.__PropertyOffset_11, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.NormalArray.CopyAssign(value);
			}
		}

		// Token: 0x17004A80 RID: 19072
		// (get) Token: 0x060242DA RID: 148186 RVA: 0x00996CAC File Offset: 0x00994EAC
		// (set) Token: 0x060242DB RID: 148187 RVA: 0x00996CE5 File Offset: 0x00994EE5
		[Nullable(1)]
		public TArray<FVector2D> UV
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<FVector2D> result;
				if ((result = this._UV) == null)
				{
					result = (this._UV = new TArray<FVector2D>(base.NativePtr + (IntPtr)BP_GroundFog_C.__PropertyOffset_12, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.UV.CopyAssign(value);
			}
		}

		// Token: 0x17004A81 RID: 19073
		// (get) Token: 0x060242DC RID: 148188 RVA: 0x00996CF3 File Offset: 0x00994EF3
		// (set) Token: 0x060242DD RID: 148189 RVA: 0x00996D07 File Offset: 0x00994F07
		public unsafe UMaterialInstanceDynamic PlaneFogMI
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GroundFog_C.__PropertyOffset_13);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GroundFog_C.__PropertyOffset_13, value);
			}
		}

		// Token: 0x17004A82 RID: 19074
		// (get) Token: 0x060242DE RID: 148190 RVA: 0x00996D1C File Offset: 0x00994F1C
		// (set) Token: 0x060242DF RID: 148191 RVA: 0x00996D30 File Offset: 0x00994F30
		public unsafe FVectorDouble CharacterPos
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GroundFog_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GroundFog_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x17004A83 RID: 19075
		// (get) Token: 0x060242E0 RID: 148192 RVA: 0x00996D45 File Offset: 0x00994F45
		// (set) Token: 0x060242E1 RID: 148193 RVA: 0x00996D59 File Offset: 0x00994F59
		public unsafe FVector CharacterPosPrez
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GroundFog_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GroundFog_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x17004A84 RID: 19076
		// (get) Token: 0x060242E2 RID: 148194 RVA: 0x00996D6E File Offset: 0x00994F6E
		// (set) Token: 0x060242E3 RID: 148195 RVA: 0x00996D7E File Offset: 0x00994F7E
		public unsafe float FadeDistance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GroundFog_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GroundFog_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x17004A85 RID: 19077
		// (get) Token: 0x060242E4 RID: 148196 RVA: 0x00996D8F File Offset: 0x00994F8F
		// (set) Token: 0x060242E5 RID: 148197 RVA: 0x00996D9F File Offset: 0x00994F9F
		public unsafe float CharacterV
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GroundFog_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GroundFog_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x17004A86 RID: 19078
		// (get) Token: 0x060242E6 RID: 148198 RVA: 0x00996DB0 File Offset: 0x00994FB0
		// (set) Token: 0x060242E7 RID: 148199 RVA: 0x00996DC0 File Offset: 0x00994FC0
		public unsafe float ParticleSpawnDistance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GroundFog_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GroundFog_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x17004A87 RID: 19079
		// (get) Token: 0x060242E8 RID: 148200 RVA: 0x00996DD1 File Offset: 0x00994FD1
		// (set) Token: 0x060242E9 RID: 148201 RVA: 0x00996DE1 File Offset: 0x00994FE1
		public unsafe bool UpdatePerFourFrame01
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GroundFog_C.__PropertyOffset_19) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GroundFog_C.__PropertyOffset_19) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004A88 RID: 19080
		// (get) Token: 0x060242EA RID: 148202 RVA: 0x00996DF2 File Offset: 0x00994FF2
		// (set) Token: 0x060242EB RID: 148203 RVA: 0x00996E02 File Offset: 0x00995002
		public unsafe bool UpdatePerFourFrame02
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GroundFog_C.__PropertyOffset_20) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GroundFog_C.__PropertyOffset_20) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004A89 RID: 19081
		// (get) Token: 0x060242EC RID: 148204 RVA: 0x00996E13 File Offset: 0x00995013
		// (set) Token: 0x060242ED RID: 148205 RVA: 0x00996E23 File Offset: 0x00995023
		public unsafe bool UpdatePerFourFrame03
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GroundFog_C.__PropertyOffset_21) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GroundFog_C.__PropertyOffset_21) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004A8A RID: 19082
		// (get) Token: 0x060242EE RID: 148206 RVA: 0x00996E34 File Offset: 0x00995034
		// (set) Token: 0x060242EF RID: 148207 RVA: 0x00996E48 File Offset: 0x00995048
		public unsafe FVector position
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GroundFog_C.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GroundFog_C.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x17004A8B RID: 19083
		// (get) Token: 0x060242F0 RID: 148208 RVA: 0x00996E5D File Offset: 0x0099505D
		// (set) Token: 0x060242F1 RID: 148209 RVA: 0x00996E71 File Offset: 0x00995071
		public unsafe UStaticMesh CloudStaticMesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMesh>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GroundFog_C.__PropertyOffset_23);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GroundFog_C.__PropertyOffset_23, value);
			}
		}

		// Token: 0x17004A8C RID: 19084
		// (get) Token: 0x060242F2 RID: 148210 RVA: 0x00996E86 File Offset: 0x00995086
		// (set) Token: 0x060242F3 RID: 148211 RVA: 0x00996E9A File Offset: 0x0099509A
		public unsafe UMaterialInstance CloudMat
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GroundFog_C.__PropertyOffset_24);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GroundFog_C.__PropertyOffset_24, value);
			}
		}

		// Token: 0x17004A8D RID: 19085
		// (get) Token: 0x060242F4 RID: 148212 RVA: 0x00996EAF File Offset: 0x009950AF
		// (set) Token: 0x060242F5 RID: 148213 RVA: 0x00996EC3 File Offset: 0x009950C3
		public unsafe UMaterialInstanceDynamic CloudMat_DMI
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GroundFog_C.__PropertyOffset_25);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GroundFog_C.__PropertyOffset_25, value);
			}
		}

		// Token: 0x17004A8E RID: 19086
		// (get) Token: 0x060242F6 RID: 148214 RVA: 0x00996ED8 File Offset: 0x009950D8
		// (set) Token: 0x060242F7 RID: 148215 RVA: 0x00996EE8 File Offset: 0x009950E8
		public unsafe bool IsEditor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GroundFog_C.__PropertyOffset_26) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GroundFog_C.__PropertyOffset_26) = (value ? 1 : 0);
			}
		}

		// Token: 0x060242F8 RID: 148216 RVA: 0x00996EF9 File Offset: 0x009950F9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdatePerFourFrame()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GroundFog_C.__UpdatePerFourFrame_NativeFunctionPtr, null);
		}

		// Token: 0x060242F9 RID: 148217 RVA: 0x00996F0D File Offset: 0x0099510D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void CalculateCharacterSpace()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GroundFog_C.__CalculateCharacterSpace_NativeFunctionPtr, null);
		}

		// Token: 0x060242FA RID: 148218 RVA: 0x00996F21 File Offset: 0x00995121
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Calculate_Character_Speed()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GroundFog_C.__Calculate_Character_Speed_NativeFunctionPtr, null);
		}

		// Token: 0x060242FB RID: 148219 RVA: 0x00996F35 File Offset: 0x00995135
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void CalculateUVs()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GroundFog_C.__CalculateUVs_NativeFunctionPtr, null);
		}

		// Token: 0x060242FC RID: 148220 RVA: 0x00996F49 File Offset: 0x00995149
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void CalculateNormals()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GroundFog_C.__CalculateNormals_NativeFunctionPtr, null);
		}

		// Token: 0x060242FD RID: 148221 RVA: 0x00996F5D File Offset: 0x0099515D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Calculate_Triangles()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GroundFog_C.__Calculate_Triangles_NativeFunctionPtr, null);
		}

		// Token: 0x060242FE RID: 148222 RVA: 0x00996F71 File Offset: 0x00995171
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void GetCurvePoints()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GroundFog_C.__GetCurvePoints_NativeFunctionPtr, null);
		}

		// Token: 0x060242FF RID: 148223 RVA: 0x00996F85 File Offset: 0x00995185
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GroundFog_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06024300 RID: 148224 RVA: 0x00996F99 File Offset: 0x00995199
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_GroundFog_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06024301 RID: 148225 RVA: 0x00996FB0 File Offset: 0x009951B0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_GroundFog_C.__EditorTick_FunctionParams* ptr = stackalloc BP_GroundFog_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_GroundFog_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GroundFog_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GroundFog_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024302 RID: 148226 RVA: 0x00996FF8 File Offset: 0x009951F8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_GroundFog_C.__EditorTick_FunctionParams* ptr = stackalloc BP_GroundFog_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_GroundFog_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GroundFog_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_GroundFog_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06024303 RID: 148227 RVA: 0x00997040 File Offset: 0x00995240
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_GroundFog_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_GroundFog_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_GroundFog_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GroundFog_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GroundFog_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024304 RID: 148228 RVA: 0x00997088 File Offset: 0x00995288
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_GroundFog_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_GroundFog_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_GroundFog_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GroundFog_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_GroundFog_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06024305 RID: 148229 RVA: 0x009970D0 File Offset: 0x009952D0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_GroundFog(int EntryPoint)
		{
			BP_GroundFog_C.__ExecuteUbergraph_BP_GroundFog_FunctionParams* ptr = stackalloc BP_GroundFog_C.__ExecuteUbergraph_BP_GroundFog_FunctionParams[(UIntPtr)103] + 15L / (long)sizeof(BP_GroundFog_C.__ExecuteUbergraph_BP_GroundFog_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GroundFog_C.__ExecuteUbergraph_BP_GroundFog_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_GroundFog_C.__ExecuteUbergraph_BP_GroundFog_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06024306 RID: 148230 RVA: 0x00997117 File Offset: 0x00995317
		protected BP_GroundFog_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04012804 RID: 75780
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/GroundFog/BP/BP_GroundFog.BP_GroundFog_C";

		// Token: 0x04012805 RID: 75781
		private static IntPtr _ClassPtr;

		// Token: 0x04012806 RID: 75782
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04012807 RID: 75783
		internal static int __PropertyOffset_0;

		// Token: 0x04012808 RID: 75784
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04012809 RID: 75785
		internal static int __PropertyOffset_1;

		// Token: 0x0401280A RID: 75786
		internal static int __PropertyOffset_2;

		// Token: 0x0401280B RID: 75787
		internal static int __PropertyOffset_3;

		// Token: 0x0401280C RID: 75788
		internal static int __PropertyOffset_4;

		// Token: 0x0401280D RID: 75789
		internal static int __PropertyOffset_5;

		// Token: 0x0401280E RID: 75790
		internal static int __PropertyOffset_6;

		// Token: 0x0401280F RID: 75791
		internal static int __PropertyOffset_7;

		// Token: 0x04012810 RID: 75792
		internal static int __PropertyOffset_8;

		// Token: 0x04012811 RID: 75793
		internal static int __PropertyOffset_9;

		// Token: 0x04012812 RID: 75794
		private TArray<FVector> _PointArray;

		// Token: 0x04012813 RID: 75795
		internal static int __PropertyOffset_10;

		// Token: 0x04012814 RID: 75796
		private TArray<int> _Triangles;

		// Token: 0x04012815 RID: 75797
		internal static int __PropertyOffset_11;

		// Token: 0x04012816 RID: 75798
		private TArray<FVector> _NormalArray;

		// Token: 0x04012817 RID: 75799
		internal static int __PropertyOffset_12;

		// Token: 0x04012818 RID: 75800
		private TArray<FVector2D> _UV;

		// Token: 0x04012819 RID: 75801
		internal static int __PropertyOffset_13;

		// Token: 0x0401281A RID: 75802
		internal static int __PropertyOffset_14;

		// Token: 0x0401281B RID: 75803
		internal static int __PropertyOffset_15;

		// Token: 0x0401281C RID: 75804
		internal static int __PropertyOffset_16;

		// Token: 0x0401281D RID: 75805
		internal static int __PropertyOffset_17;

		// Token: 0x0401281E RID: 75806
		internal static int __PropertyOffset_18;

		// Token: 0x0401281F RID: 75807
		internal static int __PropertyOffset_19;

		// Token: 0x04012820 RID: 75808
		internal static int __PropertyOffset_20;

		// Token: 0x04012821 RID: 75809
		internal static int __PropertyOffset_21;

		// Token: 0x04012822 RID: 75810
		internal static int __PropertyOffset_22;

		// Token: 0x04012823 RID: 75811
		internal static int __PropertyOffset_23;

		// Token: 0x04012824 RID: 75812
		internal static int __PropertyOffset_24;

		// Token: 0x04012825 RID: 75813
		internal static int __PropertyOffset_25;

		// Token: 0x04012826 RID: 75814
		internal static int __PropertyOffset_26;

		// Token: 0x04012827 RID: 75815
		private static IntPtr __UpdatePerFourFrame_NativeFunctionPtr;

		// Token: 0x04012828 RID: 75816
		private static IntPtr __CalculateCharacterSpace_NativeFunctionPtr;

		// Token: 0x04012829 RID: 75817
		private static IntPtr __Calculate_Character_Speed_NativeFunctionPtr;

		// Token: 0x0401282A RID: 75818
		private static IntPtr __CalculateUVs_NativeFunctionPtr;

		// Token: 0x0401282B RID: 75819
		private static IntPtr __CalculateNormals_NativeFunctionPtr;

		// Token: 0x0401282C RID: 75820
		private static IntPtr __Calculate_Triangles_NativeFunctionPtr;

		// Token: 0x0401282D RID: 75821
		private static IntPtr __GetCurvePoints_NativeFunctionPtr;

		// Token: 0x0401282E RID: 75822
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0401282F RID: 75823
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x04012830 RID: 75824
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04012831 RID: 75825
		private static IntPtr __ExecuteUbergraph_BP_GroundFog_NativeFunctionPtr;

		// Token: 0x02009D98 RID: 40344
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x0403278F RID: 206735
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009D99 RID: 40345
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032790 RID: 206736
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009D9A RID: 40346
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 88)]
		protected ref struct __ExecuteUbergraph_BP_GroundFog_FunctionParams
		{
			// Token: 0x04032791 RID: 206737
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
