using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Character.BaseSeqCharacter;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.Npc;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Sequence.Seq_BP
{
	// Token: 0x02004397 RID: 17303
	[UnrealObjectPath("/Game/Aki/Sequence/Seq_BP/BP_SeqNPC.BP_SeqNPC_C")]
	[UnrealStructLayout(1824, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1824)]
	public class BP_SeqNPC_C : BP_NpcCombinedMesh_C, IUnrealUObject, IUnrealObject, ISeqAnimDataInterface, IUnrealNativeInterface, IUnrealInterface, IABPC_Seq_Interface_C, IUnrealBlueprintInterface, IBPI_SeqAudio_C
	{
		// Token: 0x0602DE20 RID: 187936 RVA: 0x00ACF6EC File Offset: 0x00ACD8EC
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SeqNPC_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Sequence/Seq_BP/BP_SeqNPC.BP_SeqNPC_C");
			}
			return BP_SeqNPC_C._ClassPtr;
		}

		// Token: 0x0602DE21 RID: 187937 RVA: 0x00ACF710 File Offset: 0x00ACD910
		int ISeqAnimDataInterface.InterfaceOffset()
		{
			return BP_SeqNPC_C.__InterfaceOffset_ISeqAnimDataInterface;
		}

		// Token: 0x0602DE22 RID: 187938 RVA: 0x00ACF718 File Offset: 0x00ACD918
		public BP_SeqNPC_C() : this(BuiltinUtils.AllocNativeUObject(BP_SeqNPC_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602DE23 RID: 187939 RVA: 0x00ACF740 File Offset: 0x00ACD940
		[NullableContext(1)]
		public BP_SeqNPC_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SeqNPC_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007DD9 RID: 32217
		// (get) Token: 0x0602DE24 RID: 187940 RVA: 0x00ACF774 File Offset: 0x00ACD974
		// (set) Token: 0x0602DE25 RID: 187941 RVA: 0x00ACF7AD File Offset: 0x00ACD9AD
		[Nullable(1)]
		public new FPointerToUberGraphFrame UberGraphFrame
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_SeqNPC_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_SeqNPC_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007DDA RID: 32218
		// (get) Token: 0x0602DE26 RID: 187942 RVA: 0x00ACF7CE File Offset: 0x00ACD9CE
		// (set) Token: 0x0602DE27 RID: 187943 RVA: 0x00ACF7E2 File Offset: 0x00ACD9E2
		[Nullable(2)]
		public unsafe SeqAudio_Seq_V2_C SeqAudio_Seq_V2
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<SeqAudio_Seq_V2_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SeqNPC_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SeqNPC_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17007DDB RID: 32219
		// (get) Token: 0x0602DE28 RID: 187944 RVA: 0x00ACF7F7 File Offset: 0x00ACD9F7
		// (set) Token: 0x0602DE29 RID: 187945 RVA: 0x00ACF80B File Offset: 0x00ACDA0B
		[Nullable(2)]
		public unsafe ABPC_Seq_Body_V2_C ABPC_Body_V2
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<ABPC_Seq_Body_V2_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SeqNPC_C.__PropertyOffset_2);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SeqNPC_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17007DDC RID: 32220
		// (get) Token: 0x0602DE2A RID: 187946 RVA: 0x00ACF820 File Offset: 0x00ACDA20
		// (set) Token: 0x0602DE2B RID: 187947 RVA: 0x00ACF834 File Offset: 0x00ACDA34
		[Nullable(2)]
		public unsafe PD_NpcSetupData_C NPC_DA
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<PD_NpcSetupData_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SeqNPC_C.__PropertyOffset_3);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SeqNPC_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17007DDD RID: 32221
		// (get) Token: 0x0602DE2C RID: 187948 RVA: 0x00ACF849 File Offset: 0x00ACDA49
		// (set) Token: 0x0602DE2D RID: 187949 RVA: 0x00ACF859 File Offset: 0x00ACDA59
		public unsafe int MaxLod
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SeqNPC_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SeqNPC_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17007DDE RID: 32222
		// (get) Token: 0x0602DE2E RID: 187950 RVA: 0x00ACF86A File Offset: 0x00ACDA6A
		// (set) Token: 0x0602DE2F RID: 187951 RVA: 0x00ACF87A File Offset: 0x00ACDA7A
		public unsafe int LodBias
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SeqNPC_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SeqNPC_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17007DDF RID: 32223
		// (get) Token: 0x0602DE30 RID: 187952 RVA: 0x00ACF88B File Offset: 0x00ACDA8B
		// (set) Token: 0x0602DE31 RID: 187953 RVA: 0x00ACF89B File Offset: 0x00ACDA9B
		public unsafe bool IgnoreSockets
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SeqNPC_C.__PropertyOffset_6) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SeqNPC_C.__PropertyOffset_6) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007DE0 RID: 32224
		// (get) Token: 0x0602DE32 RID: 187954 RVA: 0x00ACF8AC File Offset: 0x00ACDAAC
		// (set) Token: 0x0602DE33 RID: 187955 RVA: 0x00ACF8BC File Offset: 0x00ACDABC
		public unsafe int TalkID
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SeqNPC_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SeqNPC_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17007DE1 RID: 32225
		// (get) Token: 0x0602DE34 RID: 187956 RVA: 0x00ACF8CD File Offset: 0x00ACDACD
		// (set) Token: 0x0602DE35 RID: 187957 RVA: 0x00ACF8DD File Offset: 0x00ACDADD
		public unsafe int TalkID_SP
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SeqNPC_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SeqNPC_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17007DE2 RID: 32226
		// (get) Token: 0x0602DE36 RID: 187958 RVA: 0x00ACF8F0 File Offset: 0x00ACDAF0
		// (set) Token: 0x0602DE37 RID: 187959 RVA: 0x00ACF929 File Offset: 0x00ACDB29
		[Nullable(1)]
		public TMap<FName, FTransform> Float_Curve_Data
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TMap<FName, FTransform> result;
				if ((result = this._Float_Curve_Data) == null)
				{
					result = (this._Float_Curve_Data = new TMap<FName, FTransform>(base.NativePtr + (IntPtr)BP_SeqNPC_C.__PropertyOffset_9, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Float_Curve_Data.CopyAssign(value);
			}
		}

		// Token: 0x17007DE3 RID: 32227
		// (get) Token: 0x0602DE38 RID: 187960 RVA: 0x00ACF937 File Offset: 0x00ACDB37
		// (set) Token: 0x0602DE39 RID: 187961 RVA: 0x00ACF947 File Offset: 0x00ACDB47
		public unsafe bool 开启阴影投射
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SeqNPC_C.__PropertyOffset_10) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SeqNPC_C.__PropertyOffset_10) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007DE4 RID: 32228
		// (get) Token: 0x0602DE3A RID: 187962 RVA: 0x00ACF958 File Offset: 0x00ACDB58
		// (set) Token: 0x0602DE3B RID: 187963 RVA: 0x00ACF968 File Offset: 0x00ACDB68
		public unsafe bool 开启阴影投射Cache
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SeqNPC_C.__PropertyOffset_11) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SeqNPC_C.__PropertyOffset_11) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007DE5 RID: 32229
		// (get) Token: 0x0602DE3C RID: 187964 RVA: 0x00ACF97C File Offset: 0x00ACDB7C
		// (set) Token: 0x0602DE3D RID: 187965 RVA: 0x00ACF9B5 File Offset: 0x00ACDBB5
		[Nullable(1)]
		public TArray<UKuroNpcExtraDecorationConfig> NPC_Decoration
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<UKuroNpcExtraDecorationConfig> result;
				if ((result = this._NPC_Decoration) == null)
				{
					result = (this._NPC_Decoration = new TArray<UKuroNpcExtraDecorationConfig>(base.NativePtr + (IntPtr)BP_SeqNPC_C.__PropertyOffset_12, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.NPC_Decoration.CopyAssign(value);
			}
		}

		// Token: 0x0602DE3E RID: 187966 RVA: 0x00ACF9C4 File Offset: 0x00ACDBC4
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetSeqAudio(ref SeqAudio_Seq_V2_C SeqAudio)
		{
			BP_SeqNPC_C.__GetSeqAudio_FunctionParams* ptr = stackalloc BP_SeqNPC_C.__GetSeqAudio_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_SeqNPC_C.__GetSeqAudio_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SeqNPC_C.__GetSeqAudio_NativeFunctionPtr, (void*)ptr, 1);
			ref BP_SeqNPC_C.__GetSeqAudio_FunctionParams ptr2 = ref *ptr;
			SeqAudio_Seq_V2_C seqAudio_Seq_V2_C = SeqAudio;
			ptr2.SeqAudio = ((seqAudio_Seq_V2_C != null) ? seqAudio_Seq_V2_C.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SeqNPC_C.__GetSeqAudio_NativeFunctionPtr, (void*)ptr);
			SeqAudio = BuiltinUtils.GetOrCreateUObjectByNativePointer<SeqAudio_Seq_V2_C>(ptr->SeqAudio);
		}

		// Token: 0x0602DE3F RID: 187967 RVA: 0x00ACFA28 File Offset: 0x00ACDC28
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetABPC_Body_V2(ref ABPC_Seq_Body_V2_C ABPC_Body_V2)
		{
			BP_SeqNPC_C.__GetABPC_Body_V2_FunctionParams* ptr = stackalloc BP_SeqNPC_C.__GetABPC_Body_V2_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_SeqNPC_C.__GetABPC_Body_V2_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SeqNPC_C.__GetABPC_Body_V2_NativeFunctionPtr, (void*)ptr, 1);
			ref BP_SeqNPC_C.__GetABPC_Body_V2_FunctionParams ptr2 = ref *ptr;
			ABPC_Seq_Body_V2_C abpc_Seq_Body_V2_C = ABPC_Body_V2;
			ptr2.ABPC_Body_V2 = ((abpc_Seq_Body_V2_C != null) ? abpc_Seq_Body_V2_C.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SeqNPC_C.__GetABPC_Body_V2_NativeFunctionPtr, (void*)ptr);
			ABPC_Body_V2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<ABPC_Seq_Body_V2_C>(ptr->ABPC_Body_V2);
		}

		// Token: 0x0602DE40 RID: 187968 RVA: 0x00ACFA8C File Offset: 0x00ACDC8C
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual bool GetAnimDataTransform(ref TMap<FName, FTransform> FloatCurveData)
		{
			BP_SeqNPC_C.__GetAnimDataTransform_FunctionParams* ptr = stackalloc BP_SeqNPC_C.__GetAnimDataTransform_FunctionParams[(UIntPtr)103] + 15L / (long)sizeof(BP_SeqNPC_C.__GetAnimDataTransform_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SeqNPC_C.__GetAnimDataTransform_NativeFunctionPtr, (void*)ptr, 1);
			TMap<FName, FTransform> tmap = FloatCurveData;
			if (tmap != null)
			{
				tmap.MoveTo(&ptr->FloatCurveData);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SeqNPC_C.__GetAnimDataTransform_NativeFunctionPtr, (void*)ptr);
			TMap<FName, FTransform> tmap2 = FloatCurveData;
			if (tmap2 != null)
			{
				tmap2.MoveAssign(&ptr->FloatCurveData);
			}
			bool _Result = ptr->__Result;
			UnrealReflectionUtils.DestroyStruct(BP_SeqNPC_C.__GetAnimDataTransform_NativeFunctionPtr, (void*)ptr, 1);
			return _Result;
		}

		// Token: 0x0602DE41 RID: 187969 RVA: 0x00ACFB0C File Offset: 0x00ACDD0C
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual bool GetAnimDataTransform_Implementation(ref TMap<FName, FTransform> FloatCurveData)
		{
			BP_SeqNPC_C.__GetAnimDataTransform_FunctionParams* ptr = stackalloc BP_SeqNPC_C.__GetAnimDataTransform_FunctionParams[(UIntPtr)103] + 15L / (long)sizeof(BP_SeqNPC_C.__GetAnimDataTransform_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SeqNPC_C.__GetAnimDataTransform_NativeFunctionPtr, (void*)ptr, 1);
			TMap<FName, FTransform> tmap = FloatCurveData;
			if (tmap != null)
			{
				tmap.MoveTo(&ptr->FloatCurveData);
			}
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SeqNPC_C.__GetAnimDataTransform_NativeFunctionPtr, (void*)ptr, 0);
			TMap<FName, FTransform> tmap2 = FloatCurveData;
			if (tmap2 != null)
			{
				tmap2.MoveAssign(&ptr->FloatCurveData);
			}
			bool _Result = ptr->__Result;
			UnrealReflectionUtils.DestroyStruct(BP_SeqNPC_C.__GetAnimDataTransform_NativeFunctionPtr, (void*)ptr, 1);
			return _Result;
		}

		// Token: 0x0602DE42 RID: 187970 RVA: 0x00ACFB8C File Offset: 0x00ACDD8C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual bool IsCustomSupport()
		{
			BP_SeqNPC_C.__IsCustomSupport_FunctionParams* ptr = stackalloc BP_SeqNPC_C.__IsCustomSupport_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_SeqNPC_C.__IsCustomSupport_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SeqNPC_C.__IsCustomSupport_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SeqNPC_C.__IsCustomSupport_NativeFunctionPtr, (void*)ptr);
			return ptr->__Result;
		}

		// Token: 0x0602DE43 RID: 187971 RVA: 0x00ACFBD4 File Offset: 0x00ACDDD4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual bool IsCustomSupport_Implementation()
		{
			BP_SeqNPC_C.__IsCustomSupport_FunctionParams* ptr = stackalloc BP_SeqNPC_C.__IsCustomSupport_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_SeqNPC_C.__IsCustomSupport_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SeqNPC_C.__IsCustomSupport_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SeqNPC_C.__IsCustomSupport_NativeFunctionPtr, (void*)ptr, 0);
			return ptr->__Result;
		}

		// Token: 0x0602DE44 RID: 187972 RVA: 0x00ACFC1C File Offset: 0x00ACDE1C
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual bool SetAnimDataTransform(in TMap<FName, FTransform> FloatCurveData)
		{
			BP_SeqNPC_C.__SetAnimDataTransform_FunctionParams* ptr = stackalloc BP_SeqNPC_C.__SetAnimDataTransform_FunctionParams[(UIntPtr)103] + 15L / (long)sizeof(BP_SeqNPC_C.__SetAnimDataTransform_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SeqNPC_C.__SetAnimDataTransform_NativeFunctionPtr, (void*)ptr, 1);
			object obj = FloatCurveData;
			if (obj != null)
			{
				obj.MoveTo(&ptr->FloatCurveData);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SeqNPC_C.__SetAnimDataTransform_NativeFunctionPtr, (void*)ptr);
			object obj2 = FloatCurveData;
			if (obj2 != null)
			{
				obj2.MoveAssign(&ptr->FloatCurveData);
			}
			bool _Result = ptr->__Result;
			UnrealReflectionUtils.DestroyStruct(BP_SeqNPC_C.__SetAnimDataTransform_NativeFunctionPtr, (void*)ptr, 1);
			return _Result;
		}

		// Token: 0x0602DE45 RID: 187973 RVA: 0x00ACFC9C File Offset: 0x00ACDE9C
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual bool SetAnimDataTransform_Implementation(in TMap<FName, FTransform> FloatCurveData)
		{
			BP_SeqNPC_C.__SetAnimDataTransform_FunctionParams* ptr = stackalloc BP_SeqNPC_C.__SetAnimDataTransform_FunctionParams[(UIntPtr)103] + 15L / (long)sizeof(BP_SeqNPC_C.__SetAnimDataTransform_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SeqNPC_C.__SetAnimDataTransform_NativeFunctionPtr, (void*)ptr, 1);
			object obj = FloatCurveData;
			if (obj != null)
			{
				obj.MoveTo(&ptr->FloatCurveData);
			}
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SeqNPC_C.__SetAnimDataTransform_NativeFunctionPtr, (void*)ptr, 0);
			object obj2 = FloatCurveData;
			if (obj2 != null)
			{
				obj2.MoveAssign(&ptr->FloatCurveData);
			}
			bool _Result = ptr->__Result;
			UnrealReflectionUtils.DestroyStruct(BP_SeqNPC_C.__SetAnimDataTransform_NativeFunctionPtr, (void*)ptr, 1);
			return _Result;
		}

		// Token: 0x0602DE46 RID: 187974 RVA: 0x00ACFD1C File Offset: 0x00ACDF1C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual bool GetAnimDataFloat([Nullable(new byte[]
		{
			2,
			1
		})] ref TArray<FNamedCurveValue> FloatCurveData)
		{
			BP_SeqNPC_C.__GetAnimDataFloat_FunctionParams* ptr = stackalloc BP_SeqNPC_C.__GetAnimDataFloat_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_SeqNPC_C.__GetAnimDataFloat_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SeqNPC_C.__GetAnimDataFloat_NativeFunctionPtr, (void*)ptr, 1);
			TArray<FNamedCurveValue> tarray = FloatCurveData;
			if (tarray != null)
			{
				tarray.MoveTo(&ptr->FloatCurveData);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SeqNPC_C.__GetAnimDataFloat_NativeFunctionPtr, (void*)ptr);
			TArray<FNamedCurveValue> tarray2 = FloatCurveData;
			if (tarray2 != null)
			{
				tarray2.MoveAssign(&ptr->FloatCurveData);
			}
			bool _Result = ptr->__Result;
			UnrealReflectionUtils.DestroyStruct(BP_SeqNPC_C.__GetAnimDataFloat_NativeFunctionPtr, (void*)ptr, 1);
			return _Result;
		}

		// Token: 0x0602DE47 RID: 187975 RVA: 0x00ACFD9C File Offset: 0x00ACDF9C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual bool GetAnimDataFloat_Implementation([Nullable(new byte[]
		{
			2,
			1
		})] ref TArray<FNamedCurveValue> FloatCurveData)
		{
			BP_SeqNPC_C.__GetAnimDataFloat_FunctionParams* ptr = stackalloc BP_SeqNPC_C.__GetAnimDataFloat_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_SeqNPC_C.__GetAnimDataFloat_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SeqNPC_C.__GetAnimDataFloat_NativeFunctionPtr, (void*)ptr, 1);
			TArray<FNamedCurveValue> tarray = FloatCurveData;
			if (tarray != null)
			{
				tarray.MoveTo(&ptr->FloatCurveData);
			}
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SeqNPC_C.__GetAnimDataFloat_NativeFunctionPtr, (void*)ptr, 0);
			TArray<FNamedCurveValue> tarray2 = FloatCurveData;
			if (tarray2 != null)
			{
				tarray2.MoveAssign(&ptr->FloatCurveData);
			}
			bool _Result = ptr->__Result;
			UnrealReflectionUtils.DestroyStruct(BP_SeqNPC_C.__GetAnimDataFloat_NativeFunctionPtr, (void*)ptr, 1);
			return _Result;
		}

		// Token: 0x0602DE48 RID: 187976 RVA: 0x00ACFE1C File Offset: 0x00ACE01C
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual bool GetAnimDataVector(ref TMap<FName, FVector> VectorCurveData)
		{
			BP_SeqNPC_C.__GetAnimDataVector_FunctionParams* ptr = stackalloc BP_SeqNPC_C.__GetAnimDataVector_FunctionParams[(UIntPtr)103] + 15L / (long)sizeof(BP_SeqNPC_C.__GetAnimDataVector_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SeqNPC_C.__GetAnimDataVector_NativeFunctionPtr, (void*)ptr, 1);
			TMap<FName, FVector> tmap = VectorCurveData;
			if (tmap != null)
			{
				tmap.MoveTo(&ptr->VectorCurveData);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SeqNPC_C.__GetAnimDataVector_NativeFunctionPtr, (void*)ptr);
			TMap<FName, FVector> tmap2 = VectorCurveData;
			if (tmap2 != null)
			{
				tmap2.MoveAssign(&ptr->VectorCurveData);
			}
			bool _Result = ptr->__Result;
			UnrealReflectionUtils.DestroyStruct(BP_SeqNPC_C.__GetAnimDataVector_NativeFunctionPtr, (void*)ptr, 1);
			return _Result;
		}

		// Token: 0x0602DE49 RID: 187977 RVA: 0x00ACFE9C File Offset: 0x00ACE09C
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual bool GetAnimDataVector_Implementation(ref TMap<FName, FVector> VectorCurveData)
		{
			BP_SeqNPC_C.__GetAnimDataVector_FunctionParams* ptr = stackalloc BP_SeqNPC_C.__GetAnimDataVector_FunctionParams[(UIntPtr)103] + 15L / (long)sizeof(BP_SeqNPC_C.__GetAnimDataVector_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SeqNPC_C.__GetAnimDataVector_NativeFunctionPtr, (void*)ptr, 1);
			TMap<FName, FVector> tmap = VectorCurveData;
			if (tmap != null)
			{
				tmap.MoveTo(&ptr->VectorCurveData);
			}
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SeqNPC_C.__GetAnimDataVector_NativeFunctionPtr, (void*)ptr, 0);
			TMap<FName, FVector> tmap2 = VectorCurveData;
			if (tmap2 != null)
			{
				tmap2.MoveAssign(&ptr->VectorCurveData);
			}
			bool _Result = ptr->__Result;
			UnrealReflectionUtils.DestroyStruct(BP_SeqNPC_C.__GetAnimDataVector_NativeFunctionPtr, (void*)ptr, 1);
			return _Result;
		}

		// Token: 0x0602DE4A RID: 187978 RVA: 0x00ACFF1C File Offset: 0x00ACE11C
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual TArray<FName> GetSupportGroupNames()
		{
			BP_SeqNPC_C.__GetSupportGroupNames_FunctionParams* ptr = stackalloc BP_SeqNPC_C.__GetSupportGroupNames_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_SeqNPC_C.__GetSupportGroupNames_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SeqNPC_C.__GetSupportGroupNames_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SeqNPC_C.__GetSupportGroupNames_NativeFunctionPtr, (void*)ptr);
			TArray<FName> result = new TArray<FName>(&ptr->__Result, true, true);
			UnrealReflectionUtils.DestroyStruct(BP_SeqNPC_C.__GetSupportGroupNames_NativeFunctionPtr, (void*)ptr, 1);
			return result;
		}

		// Token: 0x0602DE4B RID: 187979 RVA: 0x00ACFF7C File Offset: 0x00ACE17C
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual TArray<FName> GetSupportGroupNames_Implementation()
		{
			BP_SeqNPC_C.__GetSupportGroupNames_FunctionParams* ptr = stackalloc BP_SeqNPC_C.__GetSupportGroupNames_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_SeqNPC_C.__GetSupportGroupNames_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SeqNPC_C.__GetSupportGroupNames_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SeqNPC_C.__GetSupportGroupNames_NativeFunctionPtr, (void*)ptr, 0);
			TArray<FName> result = new TArray<FName>(&ptr->__Result, true, true);
			UnrealReflectionUtils.DestroyStruct(BP_SeqNPC_C.__GetSupportGroupNames_NativeFunctionPtr, (void*)ptr, 1);
			return result;
		}

		// Token: 0x0602DE4C RID: 187980 RVA: 0x00ACFFDC File Offset: 0x00ACE1DC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual bool SetAnimDataFloat([Nullable(new byte[]
		{
			2,
			1
		})] in TArray<FNamedCurveValue> FloatCurveData)
		{
			BP_SeqNPC_C.__SetAnimDataFloat_FunctionParams* ptr = stackalloc BP_SeqNPC_C.__SetAnimDataFloat_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_SeqNPC_C.__SetAnimDataFloat_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SeqNPC_C.__SetAnimDataFloat_NativeFunctionPtr, (void*)ptr, 1);
			object obj = FloatCurveData;
			if (obj != null)
			{
				obj.MoveTo(&ptr->FloatCurveData);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SeqNPC_C.__SetAnimDataFloat_NativeFunctionPtr, (void*)ptr);
			object obj2 = FloatCurveData;
			if (obj2 != null)
			{
				obj2.MoveAssign(&ptr->FloatCurveData);
			}
			bool _Result = ptr->__Result;
			UnrealReflectionUtils.DestroyStruct(BP_SeqNPC_C.__SetAnimDataFloat_NativeFunctionPtr, (void*)ptr, 1);
			return _Result;
		}

		// Token: 0x0602DE4D RID: 187981 RVA: 0x00AD005C File Offset: 0x00ACE25C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual bool SetAnimDataFloat_Implementation([Nullable(new byte[]
		{
			2,
			1
		})] in TArray<FNamedCurveValue> FloatCurveData)
		{
			BP_SeqNPC_C.__SetAnimDataFloat_FunctionParams* ptr = stackalloc BP_SeqNPC_C.__SetAnimDataFloat_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_SeqNPC_C.__SetAnimDataFloat_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SeqNPC_C.__SetAnimDataFloat_NativeFunctionPtr, (void*)ptr, 1);
			object obj = FloatCurveData;
			if (obj != null)
			{
				obj.MoveTo(&ptr->FloatCurveData);
			}
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SeqNPC_C.__SetAnimDataFloat_NativeFunctionPtr, (void*)ptr, 0);
			object obj2 = FloatCurveData;
			if (obj2 != null)
			{
				obj2.MoveAssign(&ptr->FloatCurveData);
			}
			bool _Result = ptr->__Result;
			UnrealReflectionUtils.DestroyStruct(BP_SeqNPC_C.__SetAnimDataFloat_NativeFunctionPtr, (void*)ptr, 1);
			return _Result;
		}

		// Token: 0x0602DE4E RID: 187982 RVA: 0x00AD00DC File Offset: 0x00ACE2DC
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual bool SetAnimDataVector(in TMap<FName, FVector> VectorCurveData)
		{
			BP_SeqNPC_C.__SetAnimDataVector_FunctionParams* ptr = stackalloc BP_SeqNPC_C.__SetAnimDataVector_FunctionParams[(UIntPtr)103] + 15L / (long)sizeof(BP_SeqNPC_C.__SetAnimDataVector_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SeqNPC_C.__SetAnimDataVector_NativeFunctionPtr, (void*)ptr, 1);
			object obj = VectorCurveData;
			if (obj != null)
			{
				obj.MoveTo(&ptr->VectorCurveData);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SeqNPC_C.__SetAnimDataVector_NativeFunctionPtr, (void*)ptr);
			object obj2 = VectorCurveData;
			if (obj2 != null)
			{
				obj2.MoveAssign(&ptr->VectorCurveData);
			}
			bool _Result = ptr->__Result;
			UnrealReflectionUtils.DestroyStruct(BP_SeqNPC_C.__SetAnimDataVector_NativeFunctionPtr, (void*)ptr, 1);
			return _Result;
		}

		// Token: 0x0602DE4F RID: 187983 RVA: 0x00AD015C File Offset: 0x00ACE35C
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual bool SetAnimDataVector_Implementation(in TMap<FName, FVector> VectorCurveData)
		{
			BP_SeqNPC_C.__SetAnimDataVector_FunctionParams* ptr = stackalloc BP_SeqNPC_C.__SetAnimDataVector_FunctionParams[(UIntPtr)103] + 15L / (long)sizeof(BP_SeqNPC_C.__SetAnimDataVector_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SeqNPC_C.__SetAnimDataVector_NativeFunctionPtr, (void*)ptr, 1);
			object obj = VectorCurveData;
			if (obj != null)
			{
				obj.MoveTo(&ptr->VectorCurveData);
			}
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SeqNPC_C.__SetAnimDataVector_NativeFunctionPtr, (void*)ptr, 0);
			object obj2 = VectorCurveData;
			if (obj2 != null)
			{
				obj2.MoveAssign(&ptr->VectorCurveData);
			}
			bool _Result = ptr->__Result;
			UnrealReflectionUtils.DestroyStruct(BP_SeqNPC_C.__SetAnimDataVector_NativeFunctionPtr, (void*)ptr, 1);
			return _Result;
		}

		// Token: 0x0602DE50 RID: 187984 RVA: 0x00AD01DB File Offset: 0x00ACE3DB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateNpcByDa()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SeqNPC_C.__UpdateNpcByDa_NativeFunctionPtr, null);
		}

		// Token: 0x0602DE51 RID: 187985 RVA: 0x00AD01EF File Offset: 0x00ACE3EF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SeqNPC_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0602DE52 RID: 187986 RVA: 0x00AD0203 File Offset: 0x00ACE403
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SeqNPC_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602DE53 RID: 187987 RVA: 0x00AD0218 File Offset: 0x00ACE418
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_SeqNPC_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_SeqNPC_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SeqNPC_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SeqNPC_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SeqNPC_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602DE54 RID: 187988 RVA: 0x00AD0260 File Offset: 0x00ACE460
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_SeqNPC_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_SeqNPC_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SeqNPC_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SeqNPC_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SeqNPC_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602DE55 RID: 187989 RVA: 0x00AD02A8 File Offset: 0x00ACE4A8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_SeqNPC_C.__EditorTick_FunctionParams* ptr = stackalloc BP_SeqNPC_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SeqNPC_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SeqNPC_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SeqNPC_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602DE56 RID: 187990 RVA: 0x00AD02F0 File Offset: 0x00ACE4F0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_SeqNPC_C.__EditorTick_FunctionParams* ptr = stackalloc BP_SeqNPC_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SeqNPC_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SeqNPC_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SeqNPC_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602DE57 RID: 187991 RVA: 0x00AD0338 File Offset: 0x00ACE538
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_SeqNPC(int EntryPoint)
		{
			BP_SeqNPC_C.__ExecuteUbergraph_BP_SeqNPC_FunctionParams* ptr = stackalloc BP_SeqNPC_C.__ExecuteUbergraph_BP_SeqNPC_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_SeqNPC_C.__ExecuteUbergraph_BP_SeqNPC_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SeqNPC_C.__ExecuteUbergraph_BP_SeqNPC_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SeqNPC_C.__ExecuteUbergraph_BP_SeqNPC_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602DE58 RID: 187992 RVA: 0x00AD037F File Offset: 0x00ACE57F
		protected BP_SeqNPC_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019ECB RID: 106187
		internal static int __InterfaceOffset_ISeqAnimDataInterface;

		// Token: 0x04019ECC RID: 106188
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Sequence/Seq_BP/BP_SeqNPC.BP_SeqNPC_C";

		// Token: 0x04019ECD RID: 106189
		private static IntPtr _ClassPtr;

		// Token: 0x04019ECE RID: 106190
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04019ECF RID: 106191
		internal new static int __PropertyOffset_0;

		// Token: 0x04019ED0 RID: 106192
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04019ED1 RID: 106193
		internal new static int __PropertyOffset_1;

		// Token: 0x04019ED2 RID: 106194
		internal new static int __PropertyOffset_2;

		// Token: 0x04019ED3 RID: 106195
		internal new static int __PropertyOffset_3;

		// Token: 0x04019ED4 RID: 106196
		internal new static int __PropertyOffset_4;

		// Token: 0x04019ED5 RID: 106197
		internal new static int __PropertyOffset_5;

		// Token: 0x04019ED6 RID: 106198
		internal new static int __PropertyOffset_6;

		// Token: 0x04019ED7 RID: 106199
		internal new static int __PropertyOffset_7;

		// Token: 0x04019ED8 RID: 106200
		internal new static int __PropertyOffset_8;

		// Token: 0x04019ED9 RID: 106201
		internal new static int __PropertyOffset_9;

		// Token: 0x04019EDA RID: 106202
		[Nullable(2)]
		private TMap<FName, FTransform> _Float_Curve_Data;

		// Token: 0x04019EDB RID: 106203
		internal new static int __PropertyOffset_10;

		// Token: 0x04019EDC RID: 106204
		internal new static int __PropertyOffset_11;

		// Token: 0x04019EDD RID: 106205
		internal new static int __PropertyOffset_12;

		// Token: 0x04019EDE RID: 106206
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UKuroNpcExtraDecorationConfig> _NPC_Decoration;

		// Token: 0x04019EDF RID: 106207
		private static IntPtr __GetSeqAudio_NativeFunctionPtr;

		// Token: 0x04019EE0 RID: 106208
		private static IntPtr __GetABPC_Body_V2_NativeFunctionPtr;

		// Token: 0x04019EE1 RID: 106209
		private static IntPtr __GetAnimDataTransform_NativeFunctionPtr;

		// Token: 0x04019EE2 RID: 106210
		private static IntPtr __IsCustomSupport_NativeFunctionPtr;

		// Token: 0x04019EE3 RID: 106211
		private static IntPtr __SetAnimDataTransform_NativeFunctionPtr;

		// Token: 0x04019EE4 RID: 106212
		private static IntPtr __GetAnimDataFloat_NativeFunctionPtr;

		// Token: 0x04019EE5 RID: 106213
		private static IntPtr __GetAnimDataVector_NativeFunctionPtr;

		// Token: 0x04019EE6 RID: 106214
		private static IntPtr __GetSupportGroupNames_NativeFunctionPtr;

		// Token: 0x04019EE7 RID: 106215
		private static IntPtr __SetAnimDataFloat_NativeFunctionPtr;

		// Token: 0x04019EE8 RID: 106216
		private static IntPtr __SetAnimDataVector_NativeFunctionPtr;

		// Token: 0x04019EE9 RID: 106217
		private static IntPtr __UpdateNpcByDa_NativeFunctionPtr;

		// Token: 0x04019EEA RID: 106218
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04019EEB RID: 106219
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04019EEC RID: 106220
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x04019EED RID: 106221
		private static IntPtr __ExecuteUbergraph_BP_SeqNPC_NativeFunctionPtr;

		// Token: 0x0200A5CF RID: 42447
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __GetSeqAudio_FunctionParams
		{
			// Token: 0x04033566 RID: 210278
			[FieldOffset(0)]
			public IntPtr SeqAudio;
		}

		// Token: 0x0200A5D0 RID: 42448
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __GetABPC_Body_V2_FunctionParams
		{
			// Token: 0x04033567 RID: 210279
			[FieldOffset(0)]
			public IntPtr ABPC_Body_V2;
		}

		// Token: 0x0200A5D1 RID: 42449
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 88)]
		protected ref struct __GetAnimDataTransform_FunctionParams
		{
			// Token: 0x04033568 RID: 210280
			[FieldOffset(0)]
			public byte FloatCurveData;

			// Token: 0x04033569 RID: 210281
			[FieldOffset(80)]
			public bool __Result;
		}

		// Token: 0x0200A5D2 RID: 42450
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected ref struct __IsCustomSupport_FunctionParams
		{
			// Token: 0x0403356A RID: 210282
			[FieldOffset(0)]
			public bool __Result;
		}

		// Token: 0x0200A5D3 RID: 42451
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 88)]
		protected ref struct __SetAnimDataTransform_FunctionParams
		{
			// Token: 0x0403356B RID: 210283
			[FieldOffset(0)]
			public byte FloatCurveData;

			// Token: 0x0403356C RID: 210284
			[FieldOffset(80)]
			public bool __Result;
		}

		// Token: 0x0200A5D4 RID: 42452
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __GetAnimDataFloat_FunctionParams
		{
			// Token: 0x0403356D RID: 210285
			[FieldOffset(0)]
			public byte FloatCurveData;

			// Token: 0x0403356E RID: 210286
			[FieldOffset(16)]
			public bool __Result;
		}

		// Token: 0x0200A5D5 RID: 42453
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 88)]
		protected ref struct __GetAnimDataVector_FunctionParams
		{
			// Token: 0x0403356F RID: 210287
			[FieldOffset(0)]
			public byte VectorCurveData;

			// Token: 0x04033570 RID: 210288
			[FieldOffset(80)]
			public bool __Result;
		}

		// Token: 0x0200A5D6 RID: 42454
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __GetSupportGroupNames_FunctionParams
		{
			// Token: 0x04033571 RID: 210289
			[FieldOffset(0)]
			public byte __Result;
		}

		// Token: 0x0200A5D7 RID: 42455
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __SetAnimDataFloat_FunctionParams
		{
			// Token: 0x04033572 RID: 210290
			[FieldOffset(0)]
			public byte FloatCurveData;

			// Token: 0x04033573 RID: 210291
			[FieldOffset(16)]
			public bool __Result;
		}

		// Token: 0x0200A5D8 RID: 42456
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 88)]
		protected ref struct __SetAnimDataVector_FunctionParams
		{
			// Token: 0x04033574 RID: 210292
			[FieldOffset(0)]
			public byte VectorCurveData;

			// Token: 0x04033575 RID: 210293
			[FieldOffset(80)]
			public bool __Result;
		}

		// Token: 0x0200A5D9 RID: 42457
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04033576 RID: 210294
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x0200A5DA RID: 42458
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x04033577 RID: 210295
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x0200A5DB RID: 42459
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __ExecuteUbergraph_BP_SeqNPC_FunctionParams
		{
			// Token: 0x04033578 RID: 210296
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
