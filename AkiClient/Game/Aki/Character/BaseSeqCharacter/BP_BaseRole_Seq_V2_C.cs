using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Effect.BluePrint.BP_FX_Common;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialController;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseSeqCharacter
{
	// Token: 0x020041BA RID: 16826
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/BaseSeqCharacter/BP_BaseRole_Seq_V2.BP_BaseRole_Seq_V2_C")]
	[UnrealStructLayout(1376, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1376)]
	public class BP_BaseRole_Seq_V2_C : APawn, IUnrealUObject, IUnrealObject, IABPC_Seq_Interface_C, IUnrealBlueprintInterface, IUnrealInterface, ISeqAnimDataInterface, IUnrealNativeInterface, IBPI_SeqAudio_C
	{
		// Token: 0x0602CB32 RID: 183090 RVA: 0x00AABE30 File Offset: 0x00AAA030
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_BaseRole_Seq_V2_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseSeqCharacter/BP_BaseRole_Seq_V2.BP_BaseRole_Seq_V2_C");
			}
			return BP_BaseRole_Seq_V2_C._ClassPtr;
		}

		// Token: 0x0602CB33 RID: 183091 RVA: 0x00AABE54 File Offset: 0x00AAA054
		int ISeqAnimDataInterface.InterfaceOffset()
		{
			return BP_BaseRole_Seq_V2_C.__InterfaceOffset_ISeqAnimDataInterface;
		}

		// Token: 0x0602CB34 RID: 183092 RVA: 0x00AABE5C File Offset: 0x00AAA05C
		public BP_BaseRole_Seq_V2_C() : this(BuiltinUtils.AllocNativeUObject(BP_BaseRole_Seq_V2_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602CB35 RID: 183093 RVA: 0x00AABE84 File Offset: 0x00AAA084
		[NullableContext(1)]
		public BP_BaseRole_Seq_V2_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_BaseRole_Seq_V2_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007894 RID: 30868
		// (get) Token: 0x0602CB36 RID: 183094 RVA: 0x00AABEB8 File Offset: 0x00AAA0B8
		// (set) Token: 0x0602CB37 RID: 183095 RVA: 0x00AABEF1 File Offset: 0x00AAA0F1
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_BaseRole_Seq_V2_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_BaseRole_Seq_V2_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007895 RID: 30869
		// (get) Token: 0x0602CB38 RID: 183096 RVA: 0x00AABF12 File Offset: 0x00AAA112
		// (set) Token: 0x0602CB39 RID: 183097 RVA: 0x00AABF26 File Offset: 0x00AAA126
		public unsafe SeqAudio_Seq_V2_C SeqAudio_Seq_V2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<SeqAudio_Seq_V2_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BaseRole_Seq_V2_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BaseRole_Seq_V2_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17007896 RID: 30870
		// (get) Token: 0x0602CB3A RID: 183098 RVA: 0x00AABF3B File Offset: 0x00AAA13B
		// (set) Token: 0x0602CB3B RID: 183099 RVA: 0x00AABF4F File Offset: 0x00AAA14F
		public unsafe UChildActorComponent Hulu
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BaseRole_Seq_V2_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BaseRole_Seq_V2_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17007897 RID: 30871
		// (get) Token: 0x0602CB3C RID: 183100 RVA: 0x00AABF64 File Offset: 0x00AAA164
		// (set) Token: 0x0602CB3D RID: 183101 RVA: 0x00AABF78 File Offset: 0x00AAA178
		public unsafe ABPC_Seq_Body_V2_C ABPC_Body_V2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<ABPC_Seq_Body_V2_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BaseRole_Seq_V2_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BaseRole_Seq_V2_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17007898 RID: 30872
		// (get) Token: 0x0602CB3E RID: 183102 RVA: 0x00AABF8D File Offset: 0x00AAA18D
		// (set) Token: 0x0602CB3F RID: 183103 RVA: 0x00AABFA1 File Offset: 0x00AAA1A1
		public unsafe USkeletalMeshComponent SkeletalMeshComponent0
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BaseRole_Seq_V2_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BaseRole_Seq_V2_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17007899 RID: 30873
		// (get) Token: 0x0602CB40 RID: 183104 RVA: 0x00AABFB6 File Offset: 0x00AAA1B6
		// (set) Token: 0x0602CB41 RID: 183105 RVA: 0x00AABFCA File Offset: 0x00AAA1CA
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BaseRole_Seq_V2_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BaseRole_Seq_V2_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x1700789A RID: 30874
		// (get) Token: 0x0602CB42 RID: 183106 RVA: 0x00AABFDF File Offset: 0x00AAA1DF
		// (set) Token: 0x0602CB43 RID: 183107 RVA: 0x00AABFEF File Offset: 0x00AAA1EF
		public unsafe int TalkID
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BaseRole_Seq_V2_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BaseRole_Seq_V2_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x1700789B RID: 30875
		// (get) Token: 0x0602CB44 RID: 183108 RVA: 0x00AAC000 File Offset: 0x00AAA200
		// (set) Token: 0x0602CB45 RID: 183109 RVA: 0x00AAC014 File Offset: 0x00AAA214
		public unsafe FName BindingTag
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BaseRole_Seq_V2_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BaseRole_Seq_V2_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x1700789C RID: 30876
		// (get) Token: 0x0602CB46 RID: 183110 RVA: 0x00AAC029 File Offset: 0x00AAA229
		// (set) Token: 0x0602CB47 RID: 183111 RVA: 0x00AAC039 File Offset: 0x00AAA239
		public unsafe float HuluFX_Handle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BaseRole_Seq_V2_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BaseRole_Seq_V2_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x1700789D RID: 30877
		// (get) Token: 0x0602CB48 RID: 183112 RVA: 0x00AAC04A File Offset: 0x00AAA24A
		// (set) Token: 0x0602CB49 RID: 183113 RVA: 0x00AAC05A File Offset: 0x00AAA25A
		public unsafe float CharFX_Group_Handle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BaseRole_Seq_V2_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BaseRole_Seq_V2_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x1700789E RID: 30878
		// (get) Token: 0x0602CB4A RID: 183114 RVA: 0x00AAC06B File Offset: 0x00AAA26B
		// (set) Token: 0x0602CB4B RID: 183115 RVA: 0x00AAC07B File Offset: 0x00AAA27B
		public unsafe float CharFX_Handle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BaseRole_Seq_V2_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BaseRole_Seq_V2_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x1700789F RID: 30879
		// (get) Token: 0x0602CB4C RID: 183116 RVA: 0x00AAC08C File Offset: 0x00AAA28C
		// (set) Token: 0x0602CB4D RID: 183117 RVA: 0x00AAC0A0 File Offset: 0x00AAA2A0
		public unsafe PD_CharacterControllerDataGroup_C DataGroup
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<PD_CharacterControllerDataGroup_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BaseRole_Seq_V2_C.__PropertyOffset_11);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BaseRole_Seq_V2_C.__PropertyOffset_11, value);
			}
		}

		// Token: 0x170078A0 RID: 30880
		// (get) Token: 0x0602CB4E RID: 183118 RVA: 0x00AAC0B5 File Offset: 0x00AAA2B5
		// (set) Token: 0x0602CB4F RID: 183119 RVA: 0x00AAC0C9 File Offset: 0x00AAA2C9
		public unsafe PD_CharacterControllerData_C Data
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<PD_CharacterControllerData_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BaseRole_Seq_V2_C.__PropertyOffset_12);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BaseRole_Seq_V2_C.__PropertyOffset_12, value);
			}
		}

		// Token: 0x170078A1 RID: 30881
		// (get) Token: 0x0602CB50 RID: 183120 RVA: 0x00AAC0DE File Offset: 0x00AAA2DE
		// (set) Token: 0x0602CB51 RID: 183121 RVA: 0x00AAC0F2 File Offset: 0x00AAA2F2
		public unsafe BP_Fx_Scanning_C BPScanning
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_Fx_Scanning_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BaseRole_Seq_V2_C.__PropertyOffset_13);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BaseRole_Seq_V2_C.__PropertyOffset_13, value);
			}
		}

		// Token: 0x170078A2 RID: 30882
		// (get) Token: 0x0602CB52 RID: 183122 RVA: 0x00AAC107 File Offset: 0x00AAA307
		// (set) Token: 0x0602CB53 RID: 183123 RVA: 0x00AAC11B File Offset: 0x00AAA31B
		public unsafe CharRenderingComponent CharRenderingComponent
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<CharRenderingComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BaseRole_Seq_V2_C.__PropertyOffset_14);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BaseRole_Seq_V2_C.__PropertyOffset_14, value);
			}
		}

		// Token: 0x170078A3 RID: 30883
		// (get) Token: 0x0602CB54 RID: 183124 RVA: 0x00AAC130 File Offset: 0x00AAA330
		// (set) Token: 0x0602CB55 RID: 183125 RVA: 0x00AAC140 File Offset: 0x00AAA340
		public unsafe int TalkID_SP
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BaseRole_Seq_V2_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BaseRole_Seq_V2_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x170078A4 RID: 30884
		// (get) Token: 0x0602CB56 RID: 183126 RVA: 0x00AAC151 File Offset: 0x00AAA351
		// (set) Token: 0x0602CB57 RID: 183127 RVA: 0x00AAC161 File Offset: 0x00AAA361
		public unsafe bool EnableKeyLightChan
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BaseRole_Seq_V2_C.__PropertyOffset_16) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BaseRole_Seq_V2_C.__PropertyOffset_16) = (value ? 1 : 0);
			}
		}

		// Token: 0x170078A5 RID: 30885
		// (get) Token: 0x0602CB58 RID: 183128 RVA: 0x00AAC172 File Offset: 0x00AAA372
		// (set) Token: 0x0602CB59 RID: 183129 RVA: 0x00AAC182 File Offset: 0x00AAA382
		public unsafe bool ToonLightChan0
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BaseRole_Seq_V2_C.__PropertyOffset_17) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BaseRole_Seq_V2_C.__PropertyOffset_17) = (value ? 1 : 0);
			}
		}

		// Token: 0x170078A6 RID: 30886
		// (get) Token: 0x0602CB5A RID: 183130 RVA: 0x00AAC193 File Offset: 0x00AAA393
		// (set) Token: 0x0602CB5B RID: 183131 RVA: 0x00AAC1A3 File Offset: 0x00AAA3A3
		public unsafe bool ToonLightChan1
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BaseRole_Seq_V2_C.__PropertyOffset_18) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BaseRole_Seq_V2_C.__PropertyOffset_18) = (value ? 1 : 0);
			}
		}

		// Token: 0x170078A7 RID: 30887
		// (get) Token: 0x0602CB5C RID: 183132 RVA: 0x00AAC1B4 File Offset: 0x00AAA3B4
		// (set) Token: 0x0602CB5D RID: 183133 RVA: 0x00AAC1C4 File Offset: 0x00AAA3C4
		public unsafe bool ToonLightChan2
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BaseRole_Seq_V2_C.__PropertyOffset_19) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BaseRole_Seq_V2_C.__PropertyOffset_19) = (value ? 1 : 0);
			}
		}

		// Token: 0x170078A8 RID: 30888
		// (get) Token: 0x0602CB5E RID: 183134 RVA: 0x00AAC1D8 File Offset: 0x00AAA3D8
		// (set) Token: 0x0602CB5F RID: 183135 RVA: 0x00AAC211 File Offset: 0x00AAA411
		[Nullable(1)]
		public TMap<FName, FTransform> CustomData
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TMap<FName, FTransform> result;
				if ((result = this._CustomData) == null)
				{
					result = (this._CustomData = new TMap<FName, FTransform>(base.NativePtr + (IntPtr)BP_BaseRole_Seq_V2_C.__PropertyOffset_20, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.CustomData.CopyAssign(value);
			}
		}

		// Token: 0x170078A9 RID: 30889
		// (get) Token: 0x0602CB60 RID: 183136 RVA: 0x00AAC21F File Offset: 0x00AAA41F
		// (set) Token: 0x0602CB61 RID: 183137 RVA: 0x00AAC234 File Offset: 0x00AAA434
		[Nullable(1)]
		public TSoftObjectPtr<USkeletalMesh> MeshRef
		{
			[NullableContext(1)]
			get
			{
				return new TSoftObjectPtr<USkeletalMesh>(base.NativePtr + (IntPtr)BP_BaseRole_Seq_V2_C.__PropertyOffset_21, this);
			}
			[NullableContext(1)]
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)BP_BaseRole_Seq_V2_C.__PropertyOffset_21, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x0602CB62 RID: 183138 RVA: 0x00AAC25C File Offset: 0x00AAA45C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetSeqAudio(ref SeqAudio_Seq_V2_C SeqAudio)
		{
			BP_BaseRole_Seq_V2_C.__GetSeqAudio_FunctionParams* ptr = stackalloc BP_BaseRole_Seq_V2_C.__GetSeqAudio_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_BaseRole_Seq_V2_C.__GetSeqAudio_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BaseRole_Seq_V2_C.__GetSeqAudio_NativeFunctionPtr, (void*)ptr, 1);
			ref BP_BaseRole_Seq_V2_C.__GetSeqAudio_FunctionParams ptr2 = ref *ptr;
			SeqAudio_Seq_V2_C seqAudio_Seq_V2_C = SeqAudio;
			ptr2.SeqAudio = ((seqAudio_Seq_V2_C != null) ? seqAudio_Seq_V2_C.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BaseRole_Seq_V2_C.__GetSeqAudio_NativeFunctionPtr, (void*)ptr);
			SeqAudio = BuiltinUtils.GetOrCreateUObjectByNativePointer<SeqAudio_Seq_V2_C>(ptr->SeqAudio);
		}

		// Token: 0x0602CB63 RID: 183139 RVA: 0x00AAC2C0 File Offset: 0x00AAA4C0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual bool GetAnimDataTransform(ref TMap<FName, FTransform> FloatCurveData)
		{
			BP_BaseRole_Seq_V2_C.__GetAnimDataTransform_FunctionParams* ptr = stackalloc BP_BaseRole_Seq_V2_C.__GetAnimDataTransform_FunctionParams[(UIntPtr)103] + 15L / (long)sizeof(BP_BaseRole_Seq_V2_C.__GetAnimDataTransform_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BaseRole_Seq_V2_C.__GetAnimDataTransform_NativeFunctionPtr, (void*)ptr, 1);
			TMap<FName, FTransform> tmap = FloatCurveData;
			if (tmap != null)
			{
				tmap.MoveTo(&ptr->FloatCurveData);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BaseRole_Seq_V2_C.__GetAnimDataTransform_NativeFunctionPtr, (void*)ptr);
			TMap<FName, FTransform> tmap2 = FloatCurveData;
			if (tmap2 != null)
			{
				tmap2.MoveAssign(&ptr->FloatCurveData);
			}
			bool _Result = ptr->__Result;
			UnrealReflectionUtils.DestroyStruct(BP_BaseRole_Seq_V2_C.__GetAnimDataTransform_NativeFunctionPtr, (void*)ptr, 1);
			return _Result;
		}

		// Token: 0x0602CB64 RID: 183140 RVA: 0x00AAC340 File Offset: 0x00AAA540
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual bool GetAnimDataTransform_Implementation(ref TMap<FName, FTransform> FloatCurveData)
		{
			BP_BaseRole_Seq_V2_C.__GetAnimDataTransform_FunctionParams* ptr = stackalloc BP_BaseRole_Seq_V2_C.__GetAnimDataTransform_FunctionParams[(UIntPtr)103] + 15L / (long)sizeof(BP_BaseRole_Seq_V2_C.__GetAnimDataTransform_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BaseRole_Seq_V2_C.__GetAnimDataTransform_NativeFunctionPtr, (void*)ptr, 1);
			TMap<FName, FTransform> tmap = FloatCurveData;
			if (tmap != null)
			{
				tmap.MoveTo(&ptr->FloatCurveData);
			}
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_BaseRole_Seq_V2_C.__GetAnimDataTransform_NativeFunctionPtr, (void*)ptr, 0);
			TMap<FName, FTransform> tmap2 = FloatCurveData;
			if (tmap2 != null)
			{
				tmap2.MoveAssign(&ptr->FloatCurveData);
			}
			bool _Result = ptr->__Result;
			UnrealReflectionUtils.DestroyStruct(BP_BaseRole_Seq_V2_C.__GetAnimDataTransform_NativeFunctionPtr, (void*)ptr, 1);
			return _Result;
		}

		// Token: 0x0602CB65 RID: 183141 RVA: 0x00AAC3C0 File Offset: 0x00AAA5C0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual bool IsCustomSupport()
		{
			BP_BaseRole_Seq_V2_C.__IsCustomSupport_FunctionParams* ptr = stackalloc BP_BaseRole_Seq_V2_C.__IsCustomSupport_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_BaseRole_Seq_V2_C.__IsCustomSupport_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BaseRole_Seq_V2_C.__IsCustomSupport_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BaseRole_Seq_V2_C.__IsCustomSupport_NativeFunctionPtr, (void*)ptr);
			return ptr->__Result;
		}

		// Token: 0x0602CB66 RID: 183142 RVA: 0x00AAC408 File Offset: 0x00AAA608
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual bool IsCustomSupport_Implementation()
		{
			BP_BaseRole_Seq_V2_C.__IsCustomSupport_FunctionParams* ptr = stackalloc BP_BaseRole_Seq_V2_C.__IsCustomSupport_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_BaseRole_Seq_V2_C.__IsCustomSupport_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BaseRole_Seq_V2_C.__IsCustomSupport_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_BaseRole_Seq_V2_C.__IsCustomSupport_NativeFunctionPtr, (void*)ptr, 0);
			return ptr->__Result;
		}

		// Token: 0x0602CB67 RID: 183143 RVA: 0x00AAC450 File Offset: 0x00AAA650
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual bool SetAnimDataTransform(in TMap<FName, FTransform> FloatCurveData)
		{
			BP_BaseRole_Seq_V2_C.__SetAnimDataTransform_FunctionParams* ptr = stackalloc BP_BaseRole_Seq_V2_C.__SetAnimDataTransform_FunctionParams[(UIntPtr)103] + 15L / (long)sizeof(BP_BaseRole_Seq_V2_C.__SetAnimDataTransform_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BaseRole_Seq_V2_C.__SetAnimDataTransform_NativeFunctionPtr, (void*)ptr, 1);
			object obj = FloatCurveData;
			if (obj != null)
			{
				obj.MoveTo(&ptr->FloatCurveData);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BaseRole_Seq_V2_C.__SetAnimDataTransform_NativeFunctionPtr, (void*)ptr);
			object obj2 = FloatCurveData;
			if (obj2 != null)
			{
				obj2.MoveAssign(&ptr->FloatCurveData);
			}
			bool _Result = ptr->__Result;
			UnrealReflectionUtils.DestroyStruct(BP_BaseRole_Seq_V2_C.__SetAnimDataTransform_NativeFunctionPtr, (void*)ptr, 1);
			return _Result;
		}

		// Token: 0x0602CB68 RID: 183144 RVA: 0x00AAC4D0 File Offset: 0x00AAA6D0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual bool SetAnimDataTransform_Implementation(in TMap<FName, FTransform> FloatCurveData)
		{
			BP_BaseRole_Seq_V2_C.__SetAnimDataTransform_FunctionParams* ptr = stackalloc BP_BaseRole_Seq_V2_C.__SetAnimDataTransform_FunctionParams[(UIntPtr)103] + 15L / (long)sizeof(BP_BaseRole_Seq_V2_C.__SetAnimDataTransform_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BaseRole_Seq_V2_C.__SetAnimDataTransform_NativeFunctionPtr, (void*)ptr, 1);
			object obj = FloatCurveData;
			if (obj != null)
			{
				obj.MoveTo(&ptr->FloatCurveData);
			}
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_BaseRole_Seq_V2_C.__SetAnimDataTransform_NativeFunctionPtr, (void*)ptr, 0);
			object obj2 = FloatCurveData;
			if (obj2 != null)
			{
				obj2.MoveAssign(&ptr->FloatCurveData);
			}
			bool _Result = ptr->__Result;
			UnrealReflectionUtils.DestroyStruct(BP_BaseRole_Seq_V2_C.__SetAnimDataTransform_NativeFunctionPtr, (void*)ptr, 1);
			return _Result;
		}

		// Token: 0x0602CB69 RID: 183145 RVA: 0x00AAC550 File Offset: 0x00AAA750
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual TArray<FName> GetSupportGroupNames()
		{
			BP_BaseRole_Seq_V2_C.__GetSupportGroupNames_FunctionParams* ptr = stackalloc BP_BaseRole_Seq_V2_C.__GetSupportGroupNames_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_BaseRole_Seq_V2_C.__GetSupportGroupNames_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BaseRole_Seq_V2_C.__GetSupportGroupNames_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BaseRole_Seq_V2_C.__GetSupportGroupNames_NativeFunctionPtr, (void*)ptr);
			TArray<FName> result = new TArray<FName>(&ptr->__Result, true, true);
			UnrealReflectionUtils.DestroyStruct(BP_BaseRole_Seq_V2_C.__GetSupportGroupNames_NativeFunctionPtr, (void*)ptr, 1);
			return result;
		}

		// Token: 0x0602CB6A RID: 183146 RVA: 0x00AAC5B0 File Offset: 0x00AAA7B0
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual TArray<FName> GetSupportGroupNames_Implementation()
		{
			BP_BaseRole_Seq_V2_C.__GetSupportGroupNames_FunctionParams* ptr = stackalloc BP_BaseRole_Seq_V2_C.__GetSupportGroupNames_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_BaseRole_Seq_V2_C.__GetSupportGroupNames_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BaseRole_Seq_V2_C.__GetSupportGroupNames_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_BaseRole_Seq_V2_C.__GetSupportGroupNames_NativeFunctionPtr, (void*)ptr, 0);
			TArray<FName> result = new TArray<FName>(&ptr->__Result, true, true);
			UnrealReflectionUtils.DestroyStruct(BP_BaseRole_Seq_V2_C.__GetSupportGroupNames_NativeFunctionPtr, (void*)ptr, 1);
			return result;
		}

		// Token: 0x0602CB6B RID: 183147 RVA: 0x00AAC610 File Offset: 0x00AAA810
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual bool GetAnimDataFloat([Nullable(new byte[]
		{
			2,
			1
		})] ref TArray<FNamedCurveValue> FloatCurveData)
		{
			BP_BaseRole_Seq_V2_C.__GetAnimDataFloat_FunctionParams* ptr = stackalloc BP_BaseRole_Seq_V2_C.__GetAnimDataFloat_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_BaseRole_Seq_V2_C.__GetAnimDataFloat_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BaseRole_Seq_V2_C.__GetAnimDataFloat_NativeFunctionPtr, (void*)ptr, 1);
			TArray<FNamedCurveValue> tarray = FloatCurveData;
			if (tarray != null)
			{
				tarray.MoveTo(&ptr->FloatCurveData);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BaseRole_Seq_V2_C.__GetAnimDataFloat_NativeFunctionPtr, (void*)ptr);
			TArray<FNamedCurveValue> tarray2 = FloatCurveData;
			if (tarray2 != null)
			{
				tarray2.MoveAssign(&ptr->FloatCurveData);
			}
			bool _Result = ptr->__Result;
			UnrealReflectionUtils.DestroyStruct(BP_BaseRole_Seq_V2_C.__GetAnimDataFloat_NativeFunctionPtr, (void*)ptr, 1);
			return _Result;
		}

		// Token: 0x0602CB6C RID: 183148 RVA: 0x00AAC690 File Offset: 0x00AAA890
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual bool GetAnimDataFloat_Implementation([Nullable(new byte[]
		{
			2,
			1
		})] ref TArray<FNamedCurveValue> FloatCurveData)
		{
			BP_BaseRole_Seq_V2_C.__GetAnimDataFloat_FunctionParams* ptr = stackalloc BP_BaseRole_Seq_V2_C.__GetAnimDataFloat_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_BaseRole_Seq_V2_C.__GetAnimDataFloat_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BaseRole_Seq_V2_C.__GetAnimDataFloat_NativeFunctionPtr, (void*)ptr, 1);
			TArray<FNamedCurveValue> tarray = FloatCurveData;
			if (tarray != null)
			{
				tarray.MoveTo(&ptr->FloatCurveData);
			}
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_BaseRole_Seq_V2_C.__GetAnimDataFloat_NativeFunctionPtr, (void*)ptr, 0);
			TArray<FNamedCurveValue> tarray2 = FloatCurveData;
			if (tarray2 != null)
			{
				tarray2.MoveAssign(&ptr->FloatCurveData);
			}
			bool _Result = ptr->__Result;
			UnrealReflectionUtils.DestroyStruct(BP_BaseRole_Seq_V2_C.__GetAnimDataFloat_NativeFunctionPtr, (void*)ptr, 1);
			return _Result;
		}

		// Token: 0x0602CB6D RID: 183149 RVA: 0x00AAC710 File Offset: 0x00AAA910
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual bool GetAnimDataVector(ref TMap<FName, FVector> VectorCurveData)
		{
			BP_BaseRole_Seq_V2_C.__GetAnimDataVector_FunctionParams* ptr = stackalloc BP_BaseRole_Seq_V2_C.__GetAnimDataVector_FunctionParams[(UIntPtr)103] + 15L / (long)sizeof(BP_BaseRole_Seq_V2_C.__GetAnimDataVector_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BaseRole_Seq_V2_C.__GetAnimDataVector_NativeFunctionPtr, (void*)ptr, 1);
			TMap<FName, FVector> tmap = VectorCurveData;
			if (tmap != null)
			{
				tmap.MoveTo(&ptr->VectorCurveData);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BaseRole_Seq_V2_C.__GetAnimDataVector_NativeFunctionPtr, (void*)ptr);
			TMap<FName, FVector> tmap2 = VectorCurveData;
			if (tmap2 != null)
			{
				tmap2.MoveAssign(&ptr->VectorCurveData);
			}
			bool _Result = ptr->__Result;
			UnrealReflectionUtils.DestroyStruct(BP_BaseRole_Seq_V2_C.__GetAnimDataVector_NativeFunctionPtr, (void*)ptr, 1);
			return _Result;
		}

		// Token: 0x0602CB6E RID: 183150 RVA: 0x00AAC790 File Offset: 0x00AAA990
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual bool GetAnimDataVector_Implementation(ref TMap<FName, FVector> VectorCurveData)
		{
			BP_BaseRole_Seq_V2_C.__GetAnimDataVector_FunctionParams* ptr = stackalloc BP_BaseRole_Seq_V2_C.__GetAnimDataVector_FunctionParams[(UIntPtr)103] + 15L / (long)sizeof(BP_BaseRole_Seq_V2_C.__GetAnimDataVector_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BaseRole_Seq_V2_C.__GetAnimDataVector_NativeFunctionPtr, (void*)ptr, 1);
			TMap<FName, FVector> tmap = VectorCurveData;
			if (tmap != null)
			{
				tmap.MoveTo(&ptr->VectorCurveData);
			}
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_BaseRole_Seq_V2_C.__GetAnimDataVector_NativeFunctionPtr, (void*)ptr, 0);
			TMap<FName, FVector> tmap2 = VectorCurveData;
			if (tmap2 != null)
			{
				tmap2.MoveAssign(&ptr->VectorCurveData);
			}
			bool _Result = ptr->__Result;
			UnrealReflectionUtils.DestroyStruct(BP_BaseRole_Seq_V2_C.__GetAnimDataVector_NativeFunctionPtr, (void*)ptr, 1);
			return _Result;
		}

		// Token: 0x0602CB6F RID: 183151 RVA: 0x00AAC810 File Offset: 0x00AAAA10
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual bool SetAnimDataFloat([Nullable(new byte[]
		{
			2,
			1
		})] in TArray<FNamedCurveValue> FloatCurveData)
		{
			BP_BaseRole_Seq_V2_C.__SetAnimDataFloat_FunctionParams* ptr = stackalloc BP_BaseRole_Seq_V2_C.__SetAnimDataFloat_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_BaseRole_Seq_V2_C.__SetAnimDataFloat_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BaseRole_Seq_V2_C.__SetAnimDataFloat_NativeFunctionPtr, (void*)ptr, 1);
			object obj = FloatCurveData;
			if (obj != null)
			{
				obj.MoveTo(&ptr->FloatCurveData);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BaseRole_Seq_V2_C.__SetAnimDataFloat_NativeFunctionPtr, (void*)ptr);
			object obj2 = FloatCurveData;
			if (obj2 != null)
			{
				obj2.MoveAssign(&ptr->FloatCurveData);
			}
			bool _Result = ptr->__Result;
			UnrealReflectionUtils.DestroyStruct(BP_BaseRole_Seq_V2_C.__SetAnimDataFloat_NativeFunctionPtr, (void*)ptr, 1);
			return _Result;
		}

		// Token: 0x0602CB70 RID: 183152 RVA: 0x00AAC890 File Offset: 0x00AAAA90
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual bool SetAnimDataFloat_Implementation([Nullable(new byte[]
		{
			2,
			1
		})] in TArray<FNamedCurveValue> FloatCurveData)
		{
			BP_BaseRole_Seq_V2_C.__SetAnimDataFloat_FunctionParams* ptr = stackalloc BP_BaseRole_Seq_V2_C.__SetAnimDataFloat_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_BaseRole_Seq_V2_C.__SetAnimDataFloat_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BaseRole_Seq_V2_C.__SetAnimDataFloat_NativeFunctionPtr, (void*)ptr, 1);
			object obj = FloatCurveData;
			if (obj != null)
			{
				obj.MoveTo(&ptr->FloatCurveData);
			}
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_BaseRole_Seq_V2_C.__SetAnimDataFloat_NativeFunctionPtr, (void*)ptr, 0);
			object obj2 = FloatCurveData;
			if (obj2 != null)
			{
				obj2.MoveAssign(&ptr->FloatCurveData);
			}
			bool _Result = ptr->__Result;
			UnrealReflectionUtils.DestroyStruct(BP_BaseRole_Seq_V2_C.__SetAnimDataFloat_NativeFunctionPtr, (void*)ptr, 1);
			return _Result;
		}

		// Token: 0x0602CB71 RID: 183153 RVA: 0x00AAC910 File Offset: 0x00AAAB10
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual bool SetAnimDataVector(in TMap<FName, FVector> VectorCurveData)
		{
			BP_BaseRole_Seq_V2_C.__SetAnimDataVector_FunctionParams* ptr = stackalloc BP_BaseRole_Seq_V2_C.__SetAnimDataVector_FunctionParams[(UIntPtr)103] + 15L / (long)sizeof(BP_BaseRole_Seq_V2_C.__SetAnimDataVector_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BaseRole_Seq_V2_C.__SetAnimDataVector_NativeFunctionPtr, (void*)ptr, 1);
			object obj = VectorCurveData;
			if (obj != null)
			{
				obj.MoveTo(&ptr->VectorCurveData);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BaseRole_Seq_V2_C.__SetAnimDataVector_NativeFunctionPtr, (void*)ptr);
			object obj2 = VectorCurveData;
			if (obj2 != null)
			{
				obj2.MoveAssign(&ptr->VectorCurveData);
			}
			bool _Result = ptr->__Result;
			UnrealReflectionUtils.DestroyStruct(BP_BaseRole_Seq_V2_C.__SetAnimDataVector_NativeFunctionPtr, (void*)ptr, 1);
			return _Result;
		}

		// Token: 0x0602CB72 RID: 183154 RVA: 0x00AAC990 File Offset: 0x00AAAB90
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual bool SetAnimDataVector_Implementation(in TMap<FName, FVector> VectorCurveData)
		{
			BP_BaseRole_Seq_V2_C.__SetAnimDataVector_FunctionParams* ptr = stackalloc BP_BaseRole_Seq_V2_C.__SetAnimDataVector_FunctionParams[(UIntPtr)103] + 15L / (long)sizeof(BP_BaseRole_Seq_V2_C.__SetAnimDataVector_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BaseRole_Seq_V2_C.__SetAnimDataVector_NativeFunctionPtr, (void*)ptr, 1);
			object obj = VectorCurveData;
			if (obj != null)
			{
				obj.MoveTo(&ptr->VectorCurveData);
			}
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_BaseRole_Seq_V2_C.__SetAnimDataVector_NativeFunctionPtr, (void*)ptr, 0);
			object obj2 = VectorCurveData;
			if (obj2 != null)
			{
				obj2.MoveAssign(&ptr->VectorCurveData);
			}
			bool _Result = ptr->__Result;
			UnrealReflectionUtils.DestroyStruct(BP_BaseRole_Seq_V2_C.__SetAnimDataVector_NativeFunctionPtr, (void*)ptr, 1);
			return _Result;
		}

		// Token: 0x0602CB73 RID: 183155 RVA: 0x00AACA10 File Offset: 0x00AAAC10
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetABPC_Body_V2(ref ABPC_Seq_Body_V2_C ABPC_Body_V2)
		{
			BP_BaseRole_Seq_V2_C.__GetABPC_Body_V2_FunctionParams* ptr = stackalloc BP_BaseRole_Seq_V2_C.__GetABPC_Body_V2_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_BaseRole_Seq_V2_C.__GetABPC_Body_V2_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BaseRole_Seq_V2_C.__GetABPC_Body_V2_NativeFunctionPtr, (void*)ptr, 1);
			ref BP_BaseRole_Seq_V2_C.__GetABPC_Body_V2_FunctionParams ptr2 = ref *ptr;
			ABPC_Seq_Body_V2_C abpc_Seq_Body_V2_C = ABPC_Body_V2;
			ptr2.ABPC_Body_V2 = ((abpc_Seq_Body_V2_C != null) ? abpc_Seq_Body_V2_C.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BaseRole_Seq_V2_C.__GetABPC_Body_V2_NativeFunctionPtr, (void*)ptr);
			ABPC_Body_V2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<ABPC_Seq_Body_V2_C>(ptr->ABPC_Body_V2);
		}

		// Token: 0x0602CB74 RID: 183156 RVA: 0x00AACA74 File Offset: 0x00AAAC74
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void LightChanel()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BaseRole_Seq_V2_C.__LightChanel_NativeFunctionPtr, null);
		}

		// Token: 0x0602CB75 RID: 183157 RVA: 0x00AACA88 File Offset: 0x00AAAC88
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void EndSwitchPose_ToBP(AActor To, bool Log)
		{
			BP_BaseRole_Seq_V2_C.__EndSwitchPose_ToBP_FunctionParams* ptr = stackalloc BP_BaseRole_Seq_V2_C.__EndSwitchPose_ToBP_FunctionParams[(UIntPtr)95] + 15L / (long)sizeof(BP_BaseRole_Seq_V2_C.__EndSwitchPose_ToBP_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BaseRole_Seq_V2_C.__EndSwitchPose_ToBP_NativeFunctionPtr, (void*)ptr, 1);
			ptr->To = ((To != null) ? To.NativePtr : IntPtr.Zero);
			ptr->Log = Log;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BaseRole_Seq_V2_C.__EndSwitchPose_ToBP_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602CB76 RID: 183158 RVA: 0x00AACAE4 File Offset: 0x00AAACE4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void EndSwitchPose_ToSeq(AActor To, bool Log)
		{
			BP_BaseRole_Seq_V2_C.__EndSwitchPose_ToSeq_FunctionParams* ptr = stackalloc BP_BaseRole_Seq_V2_C.__EndSwitchPose_ToSeq_FunctionParams[(UIntPtr)79] + 15L / (long)sizeof(BP_BaseRole_Seq_V2_C.__EndSwitchPose_ToSeq_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BaseRole_Seq_V2_C.__EndSwitchPose_ToSeq_NativeFunctionPtr, (void*)ptr, 1);
			ptr->To = ((To != null) ? To.NativePtr : IntPtr.Zero);
			ptr->Log = Log;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BaseRole_Seq_V2_C.__EndSwitchPose_ToSeq_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602CB77 RID: 183159 RVA: 0x00AACB40 File Offset: 0x00AAAD40
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BeginSwitchPose_ToBP(AActor From, AActor To, float SwitchTime, bool ErrorLog)
		{
			BP_BaseRole_Seq_V2_C.__BeginSwitchPose_ToBP_FunctionParams* ptr = stackalloc BP_BaseRole_Seq_V2_C.__BeginSwitchPose_ToBP_FunctionParams[(UIntPtr)207] + 15L / (long)sizeof(BP_BaseRole_Seq_V2_C.__BeginSwitchPose_ToBP_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BaseRole_Seq_V2_C.__BeginSwitchPose_ToBP_NativeFunctionPtr, (void*)ptr, 1);
			ptr->From = ((From != null) ? From.NativePtr : IntPtr.Zero);
			ptr->To = ((To != null) ? To.NativePtr : IntPtr.Zero);
			ptr->SwitchTime = SwitchTime;
			ptr->ErrorLog = ErrorLog;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BaseRole_Seq_V2_C.__BeginSwitchPose_ToBP_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602CB78 RID: 183160 RVA: 0x00AACBC0 File Offset: 0x00AAADC0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Begin_Switch_Pose_to_Seq(AActor From, AActor To, float SwitchTime, bool ErrorLog)
		{
			BP_BaseRole_Seq_V2_C.__Begin_Switch_Pose_to_Seq_FunctionParams* ptr = stackalloc BP_BaseRole_Seq_V2_C.__Begin_Switch_Pose_to_Seq_FunctionParams[(UIntPtr)191] + 15L / (long)sizeof(BP_BaseRole_Seq_V2_C.__Begin_Switch_Pose_to_Seq_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BaseRole_Seq_V2_C.__Begin_Switch_Pose_to_Seq_NativeFunctionPtr, (void*)ptr, 1);
			ptr->From = ((From != null) ? From.NativePtr : IntPtr.Zero);
			ptr->To = ((To != null) ? To.NativePtr : IntPtr.Zero);
			ptr->SwitchTime = SwitchTime;
			ptr->ErrorLog = ErrorLog;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BaseRole_Seq_V2_C.__Begin_Switch_Pose_to_Seq_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602CB79 RID: 183161 RVA: 0x00AACC3D File Offset: 0x00AAAE3D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 添加扫描效果()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BaseRole_Seq_V2_C.__添加扫描效果_NativeFunctionPtr, null);
		}

		// Token: 0x0602CB7A RID: 183162 RVA: 0x00AACC51 File Offset: 0x00AAAE51
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 卸载角色材质控制器()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BaseRole_Seq_V2_C.__卸载角色材质控制器_NativeFunctionPtr, null);
		}

		// Token: 0x0602CB7B RID: 183163 RVA: 0x00AACC65 File Offset: 0x00AAAE65
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 添加角色材质控制器()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BaseRole_Seq_V2_C.__添加角色材质控制器_NativeFunctionPtr, null);
		}

		// Token: 0x0602CB7C RID: 183164 RVA: 0x00AACC79 File Offset: 0x00AAAE79
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 卸载角色材质控制器组()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BaseRole_Seq_V2_C.__卸载角色材质控制器组_NativeFunctionPtr, null);
		}

		// Token: 0x0602CB7D RID: 183165 RVA: 0x00AACC8D File Offset: 0x00AAAE8D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 添加角色材质控制器组()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BaseRole_Seq_V2_C.__添加角色材质控制器组_NativeFunctionPtr, null);
		}

		// Token: 0x0602CB7E RID: 183166 RVA: 0x00AACCA1 File Offset: 0x00AAAEA1
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void CleanHuluState()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BaseRole_Seq_V2_C.__CleanHuluState_NativeFunctionPtr, null);
		}

		// Token: 0x0602CB7F RID: 183167 RVA: 0x00AACCB8 File Offset: 0x00AAAEB8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void ChangeHuluState(int State)
		{
			BP_BaseRole_Seq_V2_C.__ChangeHuluState_FunctionParams* ptr = stackalloc BP_BaseRole_Seq_V2_C.__ChangeHuluState_FunctionParams[(UIntPtr)63] + 15L / (long)sizeof(BP_BaseRole_Seq_V2_C.__ChangeHuluState_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BaseRole_Seq_V2_C.__ChangeHuluState_NativeFunctionPtr, (void*)ptr, 1);
			ptr->State = State;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BaseRole_Seq_V2_C.__ChangeHuluState_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602CB80 RID: 183168 RVA: 0x00AACD00 File Offset: 0x00AAAF00
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SwitchMeshTransform(bool LevelA)
		{
			BP_BaseRole_Seq_V2_C.__SwitchMeshTransform_FunctionParams* ptr = stackalloc BP_BaseRole_Seq_V2_C.__SwitchMeshTransform_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_BaseRole_Seq_V2_C.__SwitchMeshTransform_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BaseRole_Seq_V2_C.__SwitchMeshTransform_NativeFunctionPtr, (void*)ptr, 1);
			ptr->LevelA = LevelA;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BaseRole_Seq_V2_C.__SwitchMeshTransform_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602CB81 RID: 183169 RVA: 0x00AACD48 File Offset: 0x00AAAF48
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void EndSwitchPose(AActor To, bool Log)
		{
			BP_BaseRole_Seq_V2_C.__EndSwitchPose_FunctionParams* ptr = stackalloc BP_BaseRole_Seq_V2_C.__EndSwitchPose_FunctionParams[(UIntPtr)63] + 15L / (long)sizeof(BP_BaseRole_Seq_V2_C.__EndSwitchPose_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BaseRole_Seq_V2_C.__EndSwitchPose_NativeFunctionPtr, (void*)ptr, 1);
			ptr->To = ((To != null) ? To.NativePtr : IntPtr.Zero);
			ptr->Log = Log;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BaseRole_Seq_V2_C.__EndSwitchPose_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602CB82 RID: 183170 RVA: 0x00AACDA4 File Offset: 0x00AAAFA4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BeginSwitchPose(AActor From, AActor To, float SwitchTime, bool ErrorLog)
		{
			BP_BaseRole_Seq_V2_C.__BeginSwitchPose_FunctionParams* ptr = stackalloc BP_BaseRole_Seq_V2_C.__BeginSwitchPose_FunctionParams[(UIntPtr)71] + 15L / (long)sizeof(BP_BaseRole_Seq_V2_C.__BeginSwitchPose_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BaseRole_Seq_V2_C.__BeginSwitchPose_NativeFunctionPtr, (void*)ptr, 1);
			ptr->From = ((From != null) ? From.NativePtr : IntPtr.Zero);
			ptr->To = ((To != null) ? To.NativePtr : IntPtr.Zero);
			ptr->SwitchTime = SwitchTime;
			ptr->ErrorLog = ErrorLog;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BaseRole_Seq_V2_C.__BeginSwitchPose_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602CB83 RID: 183171 RVA: 0x00AACE1E File Offset: 0x00AAB01E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void JumpFrame()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BaseRole_Seq_V2_C.__JumpFrame_NativeFunctionPtr, null);
		}

		// Token: 0x0602CB84 RID: 183172 RVA: 0x00AACE32 File Offset: 0x00AAB032
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BaseRole_Seq_V2_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0602CB85 RID: 183173 RVA: 0x00AACE46 File Offset: 0x00AAB046
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_BaseRole_Seq_V2_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602CB86 RID: 183174 RVA: 0x00AACE5B File Offset: 0x00AAB05B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveDestroyed()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BaseRole_Seq_V2_C.__ReceiveDestroyed_NativeFunctionPtr, null);
		}

		// Token: 0x0602CB87 RID: 183175 RVA: 0x00AACE6F File Offset: 0x00AAB06F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveDestroyed_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_BaseRole_Seq_V2_C.__ReceiveDestroyed_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602CB88 RID: 183176 RVA: 0x00AACE84 File Offset: 0x00AAB084
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_BaseRole_Seq_V2(int EntryPoint)
		{
			BP_BaseRole_Seq_V2_C.__ExecuteUbergraph_BP_BaseRole_Seq_V2_FunctionParams* ptr = stackalloc BP_BaseRole_Seq_V2_C.__ExecuteUbergraph_BP_BaseRole_Seq_V2_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_BaseRole_Seq_V2_C.__ExecuteUbergraph_BP_BaseRole_Seq_V2_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BaseRole_Seq_V2_C.__ExecuteUbergraph_BP_BaseRole_Seq_V2_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_BaseRole_Seq_V2_C.__ExecuteUbergraph_BP_BaseRole_Seq_V2_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602CB89 RID: 183177 RVA: 0x00AACECB File Offset: 0x00AAB0CB
		protected BP_BaseRole_Seq_V2_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018E63 RID: 101987
		internal static int __InterfaceOffset_ISeqAnimDataInterface;

		// Token: 0x04018E64 RID: 101988
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseSeqCharacter/BP_BaseRole_Seq_V2.BP_BaseRole_Seq_V2_C";

		// Token: 0x04018E65 RID: 101989
		private static IntPtr _ClassPtr;

		// Token: 0x04018E66 RID: 101990
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04018E67 RID: 101991
		internal static int __PropertyOffset_0;

		// Token: 0x04018E68 RID: 101992
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04018E69 RID: 101993
		internal static int __PropertyOffset_1;

		// Token: 0x04018E6A RID: 101994
		internal static int __PropertyOffset_2;

		// Token: 0x04018E6B RID: 101995
		internal static int __PropertyOffset_3;

		// Token: 0x04018E6C RID: 101996
		internal static int __PropertyOffset_4;

		// Token: 0x04018E6D RID: 101997
		internal static int __PropertyOffset_5;

		// Token: 0x04018E6E RID: 101998
		internal static int __PropertyOffset_6;

		// Token: 0x04018E6F RID: 101999
		internal static int __PropertyOffset_7;

		// Token: 0x04018E70 RID: 102000
		internal static int __PropertyOffset_8;

		// Token: 0x04018E71 RID: 102001
		internal static int __PropertyOffset_9;

		// Token: 0x04018E72 RID: 102002
		internal static int __PropertyOffset_10;

		// Token: 0x04018E73 RID: 102003
		internal static int __PropertyOffset_11;

		// Token: 0x04018E74 RID: 102004
		internal static int __PropertyOffset_12;

		// Token: 0x04018E75 RID: 102005
		internal static int __PropertyOffset_13;

		// Token: 0x04018E76 RID: 102006
		internal static int __PropertyOffset_14;

		// Token: 0x04018E77 RID: 102007
		internal static int __PropertyOffset_15;

		// Token: 0x04018E78 RID: 102008
		internal static int __PropertyOffset_16;

		// Token: 0x04018E79 RID: 102009
		internal static int __PropertyOffset_17;

		// Token: 0x04018E7A RID: 102010
		internal static int __PropertyOffset_18;

		// Token: 0x04018E7B RID: 102011
		internal static int __PropertyOffset_19;

		// Token: 0x04018E7C RID: 102012
		internal static int __PropertyOffset_20;

		// Token: 0x04018E7D RID: 102013
		private TMap<FName, FTransform> _CustomData;

		// Token: 0x04018E7E RID: 102014
		internal static int __PropertyOffset_21;

		// Token: 0x04018E7F RID: 102015
		private static IntPtr __GetSeqAudio_NativeFunctionPtr;

		// Token: 0x04018E80 RID: 102016
		private static IntPtr __GetAnimDataTransform_NativeFunctionPtr;

		// Token: 0x04018E81 RID: 102017
		private static IntPtr __IsCustomSupport_NativeFunctionPtr;

		// Token: 0x04018E82 RID: 102018
		private static IntPtr __SetAnimDataTransform_NativeFunctionPtr;

		// Token: 0x04018E83 RID: 102019
		private static IntPtr __GetSupportGroupNames_NativeFunctionPtr;

		// Token: 0x04018E84 RID: 102020
		private static IntPtr __GetAnimDataFloat_NativeFunctionPtr;

		// Token: 0x04018E85 RID: 102021
		private static IntPtr __GetAnimDataVector_NativeFunctionPtr;

		// Token: 0x04018E86 RID: 102022
		private static IntPtr __SetAnimDataFloat_NativeFunctionPtr;

		// Token: 0x04018E87 RID: 102023
		private static IntPtr __SetAnimDataVector_NativeFunctionPtr;

		// Token: 0x04018E88 RID: 102024
		private static IntPtr __GetABPC_Body_V2_NativeFunctionPtr;

		// Token: 0x04018E89 RID: 102025
		private static IntPtr __LightChanel_NativeFunctionPtr;

		// Token: 0x04018E8A RID: 102026
		private static IntPtr __EndSwitchPose_ToBP_NativeFunctionPtr;

		// Token: 0x04018E8B RID: 102027
		private static IntPtr __EndSwitchPose_ToSeq_NativeFunctionPtr;

		// Token: 0x04018E8C RID: 102028
		private static IntPtr __BeginSwitchPose_ToBP_NativeFunctionPtr;

		// Token: 0x04018E8D RID: 102029
		private static IntPtr __Begin_Switch_Pose_to_Seq_NativeFunctionPtr;

		// Token: 0x04018E8E RID: 102030
		private static IntPtr __添加扫描效果_NativeFunctionPtr;

		// Token: 0x04018E8F RID: 102031
		private static IntPtr __卸载角色材质控制器_NativeFunctionPtr;

		// Token: 0x04018E90 RID: 102032
		private static IntPtr __添加角色材质控制器_NativeFunctionPtr;

		// Token: 0x04018E91 RID: 102033
		private static IntPtr __卸载角色材质控制器组_NativeFunctionPtr;

		// Token: 0x04018E92 RID: 102034
		private static IntPtr __添加角色材质控制器组_NativeFunctionPtr;

		// Token: 0x04018E93 RID: 102035
		private static IntPtr __CleanHuluState_NativeFunctionPtr;

		// Token: 0x04018E94 RID: 102036
		private static IntPtr __ChangeHuluState_NativeFunctionPtr;

		// Token: 0x04018E95 RID: 102037
		private static IntPtr __SwitchMeshTransform_NativeFunctionPtr;

		// Token: 0x04018E96 RID: 102038
		private static IntPtr __EndSwitchPose_NativeFunctionPtr;

		// Token: 0x04018E97 RID: 102039
		private static IntPtr __BeginSwitchPose_NativeFunctionPtr;

		// Token: 0x04018E98 RID: 102040
		private static IntPtr __JumpFrame_NativeFunctionPtr;

		// Token: 0x04018E99 RID: 102041
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04018E9A RID: 102042
		private static IntPtr __ReceiveDestroyed_NativeFunctionPtr;

		// Token: 0x04018E9B RID: 102043
		private static IntPtr __ExecuteUbergraph_BP_BaseRole_Seq_V2_NativeFunctionPtr;

		// Token: 0x0200A4E6 RID: 42214
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __GetSeqAudio_FunctionParams
		{
			// Token: 0x0403333F RID: 209727
			[FieldOffset(0)]
			public IntPtr SeqAudio;
		}

		// Token: 0x0200A4E7 RID: 42215
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 88)]
		protected ref struct __GetAnimDataTransform_FunctionParams
		{
			// Token: 0x04033340 RID: 209728
			[FieldOffset(0)]
			public byte FloatCurveData;

			// Token: 0x04033341 RID: 209729
			[FieldOffset(80)]
			public bool __Result;
		}

		// Token: 0x0200A4E8 RID: 42216
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected ref struct __IsCustomSupport_FunctionParams
		{
			// Token: 0x04033342 RID: 209730
			[FieldOffset(0)]
			public bool __Result;
		}

		// Token: 0x0200A4E9 RID: 42217
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 88)]
		protected ref struct __SetAnimDataTransform_FunctionParams
		{
			// Token: 0x04033343 RID: 209731
			[FieldOffset(0)]
			public byte FloatCurveData;

			// Token: 0x04033344 RID: 209732
			[FieldOffset(80)]
			public bool __Result;
		}

		// Token: 0x0200A4EA RID: 42218
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __GetSupportGroupNames_FunctionParams
		{
			// Token: 0x04033345 RID: 209733
			[FieldOffset(0)]
			public byte __Result;
		}

		// Token: 0x0200A4EB RID: 42219
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __GetAnimDataFloat_FunctionParams
		{
			// Token: 0x04033346 RID: 209734
			[FieldOffset(0)]
			public byte FloatCurveData;

			// Token: 0x04033347 RID: 209735
			[FieldOffset(16)]
			public bool __Result;
		}

		// Token: 0x0200A4EC RID: 42220
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 88)]
		protected ref struct __GetAnimDataVector_FunctionParams
		{
			// Token: 0x04033348 RID: 209736
			[FieldOffset(0)]
			public byte VectorCurveData;

			// Token: 0x04033349 RID: 209737
			[FieldOffset(80)]
			public bool __Result;
		}

		// Token: 0x0200A4ED RID: 42221
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __SetAnimDataFloat_FunctionParams
		{
			// Token: 0x0403334A RID: 209738
			[FieldOffset(0)]
			public byte FloatCurveData;

			// Token: 0x0403334B RID: 209739
			[FieldOffset(16)]
			public bool __Result;
		}

		// Token: 0x0200A4EE RID: 42222
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 88)]
		protected ref struct __SetAnimDataVector_FunctionParams
		{
			// Token: 0x0403334C RID: 209740
			[FieldOffset(0)]
			public byte VectorCurveData;

			// Token: 0x0403334D RID: 209741
			[FieldOffset(80)]
			public bool __Result;
		}

		// Token: 0x0200A4EF RID: 42223
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __GetABPC_Body_V2_FunctionParams
		{
			// Token: 0x0403334E RID: 209742
			[FieldOffset(0)]
			public IntPtr ABPC_Body_V2;
		}

		// Token: 0x0200A4F0 RID: 42224
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 80)]
		protected ref struct __EndSwitchPose_ToBP_FunctionParams
		{
			// Token: 0x0403334F RID: 209743
			[FieldOffset(0)]
			public IntPtr To;

			// Token: 0x04033350 RID: 209744
			[FieldOffset(8)]
			public bool Log;
		}

		// Token: 0x0200A4F1 RID: 42225
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 64)]
		protected ref struct __EndSwitchPose_ToSeq_FunctionParams
		{
			// Token: 0x04033351 RID: 209745
			[FieldOffset(0)]
			public IntPtr To;

			// Token: 0x04033352 RID: 209746
			[FieldOffset(8)]
			public bool Log;
		}

		// Token: 0x0200A4F2 RID: 42226
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 192)]
		protected ref struct __BeginSwitchPose_ToBP_FunctionParams
		{
			// Token: 0x04033353 RID: 209747
			[FieldOffset(0)]
			public IntPtr From;

			// Token: 0x04033354 RID: 209748
			[FieldOffset(8)]
			public IntPtr To;

			// Token: 0x04033355 RID: 209749
			[FieldOffset(16)]
			public float SwitchTime;

			// Token: 0x04033356 RID: 209750
			[FieldOffset(20)]
			public bool ErrorLog;
		}

		// Token: 0x0200A4F3 RID: 42227
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 176)]
		protected ref struct __Begin_Switch_Pose_to_Seq_FunctionParams
		{
			// Token: 0x04033357 RID: 209751
			[FieldOffset(0)]
			public IntPtr From;

			// Token: 0x04033358 RID: 209752
			[FieldOffset(8)]
			public IntPtr To;

			// Token: 0x04033359 RID: 209753
			[FieldOffset(16)]
			public float SwitchTime;

			// Token: 0x0403335A RID: 209754
			[FieldOffset(20)]
			public bool ErrorLog;
		}

		// Token: 0x0200A4F4 RID: 42228
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 48)]
		protected ref struct __ChangeHuluState_FunctionParams
		{
			// Token: 0x0403335B RID: 209755
			[FieldOffset(0)]
			public int State;
		}

		// Token: 0x0200A4F5 RID: 42229
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected ref struct __SwitchMeshTransform_FunctionParams
		{
			// Token: 0x0403335C RID: 209756
			[FieldOffset(0)]
			public bool LevelA;
		}

		// Token: 0x0200A4F6 RID: 42230
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 48)]
		protected ref struct __EndSwitchPose_FunctionParams
		{
			// Token: 0x0403335D RID: 209757
			[FieldOffset(0)]
			public IntPtr To;

			// Token: 0x0403335E RID: 209758
			[FieldOffset(8)]
			public bool Log;
		}

		// Token: 0x0200A4F7 RID: 42231
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 56)]
		protected ref struct __BeginSwitchPose_FunctionParams
		{
			// Token: 0x0403335F RID: 209759
			[FieldOffset(0)]
			public IntPtr From;

			// Token: 0x04033360 RID: 209760
			[FieldOffset(8)]
			public IntPtr To;

			// Token: 0x04033361 RID: 209761
			[FieldOffset(16)]
			public float SwitchTime;

			// Token: 0x04033362 RID: 209762
			[FieldOffset(20)]
			public bool ErrorLog;
		}

		// Token: 0x0200A4F8 RID: 42232
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __ExecuteUbergraph_BP_BaseRole_Seq_V2_FunctionParams
		{
			// Token: 0x04033363 RID: 209763
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
