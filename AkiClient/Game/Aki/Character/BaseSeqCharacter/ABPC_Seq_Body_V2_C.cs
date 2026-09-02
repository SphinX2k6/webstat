using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseSeqCharacter
{
	// Token: 0x020041B6 RID: 16822
	[UnrealObjectPath("/Game/Aki/Character/BaseSeqCharacter/ABPC_Seq_Body_V2.ABPC_Seq_Body_V2_C")]
	[UnrealStructLayout(464, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 460)]
	public class ABPC_Seq_Body_V2_C : UActorComponent, IUnrealUObject, IUnrealObject, ICurveSourceInterface, IUnrealNativeInterface, IUnrealInterface
	{
		// Token: 0x0602CAF0 RID: 183024 RVA: 0x00AAB4ED File Offset: 0x00AA96ED
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ABPC_Seq_Body_V2_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseSeqCharacter/ABPC_Seq_Body_V2.ABPC_Seq_Body_V2_C");
			}
			return ABPC_Seq_Body_V2_C._ClassPtr;
		}

		// Token: 0x0602CAF1 RID: 183025 RVA: 0x00AAB511 File Offset: 0x00AA9711
		int ICurveSourceInterface.InterfaceOffset()
		{
			return ABPC_Seq_Body_V2_C.__InterfaceOffset_ICurveSourceInterface;
		}

		// Token: 0x0602CAF2 RID: 183026 RVA: 0x00AAB518 File Offset: 0x00AA9718
		public ABPC_Seq_Body_V2_C() : this(BuiltinUtils.AllocNativeUObject(ABPC_Seq_Body_V2_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602CAF3 RID: 183027 RVA: 0x00AAB540 File Offset: 0x00AA9740
		[NullableContext(1)]
		public ABPC_Seq_Body_V2_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ABPC_Seq_Body_V2_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700787C RID: 30844
		// (get) Token: 0x0602CAF4 RID: 183028 RVA: 0x00AAB573 File Offset: 0x00AA9773
		// (set) Token: 0x0602CAF5 RID: 183029 RVA: 0x00AAB583 File Offset: 0x00AA9783
		public unsafe bool 启用物理模拟
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABPC_Seq_Body_V2_C.__PropertyOffset_0) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABPC_Seq_Body_V2_C.__PropertyOffset_0) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700787D RID: 30845
		// (get) Token: 0x0602CAF6 RID: 183030 RVA: 0x00AAB594 File Offset: 0x00AA9794
		// (set) Token: 0x0602CAF7 RID: 183031 RVA: 0x00AAB5A4 File Offset: 0x00AA97A4
		public unsafe float 物理模拟权重
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABPC_Seq_Body_V2_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABPC_Seq_Body_V2_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x1700787E RID: 30846
		// (get) Token: 0x0602CAF8 RID: 183032 RVA: 0x00AAB5B8 File Offset: 0x00AA97B8
		// (set) Token: 0x0602CAF9 RID: 183033 RVA: 0x00AAB5F1 File Offset: 0x00AA97F1
		[Nullable(1)]
		public TArray<FNamedCurveValue> NamedCurves
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<FNamedCurveValue> result;
				if ((result = this._NamedCurves) == null)
				{
					result = (this._NamedCurves = new TArray<FNamedCurveValue>(base.NativePtr + (IntPtr)ABPC_Seq_Body_V2_C.__PropertyOffset_2, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.NamedCurves.CopyAssign(value);
			}
		}

		// Token: 0x1700787F RID: 30847
		// (get) Token: 0x0602CAFA RID: 183034 RVA: 0x00AAB5FF File Offset: 0x00AA97FF
		// (set) Token: 0x0602CAFB RID: 183035 RVA: 0x00AAB613 File Offset: 0x00AA9813
		public unsafe FRotator Add_LookAt
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABPC_Seq_Body_V2_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABPC_Seq_Body_V2_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17007880 RID: 30848
		// (get) Token: 0x0602CAFC RID: 183036 RVA: 0x00AAB628 File Offset: 0x00AA9828
		// (set) Token: 0x0602CAFD RID: 183037 RVA: 0x00AAB63C File Offset: 0x00AA983C
		public unsafe FRotator Add_Bip001Head
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABPC_Seq_Body_V2_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABPC_Seq_Body_V2_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17007881 RID: 30849
		// (get) Token: 0x0602CAFE RID: 183038 RVA: 0x00AAB651 File Offset: 0x00AA9851
		// (set) Token: 0x0602CAFF RID: 183039 RVA: 0x00AAB665 File Offset: 0x00AA9865
		public unsafe FRotator Add_Bip001Neck
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABPC_Seq_Body_V2_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABPC_Seq_Body_V2_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17007882 RID: 30850
		// (get) Token: 0x0602CB00 RID: 183040 RVA: 0x00AAB67A File Offset: 0x00AA987A
		// (set) Token: 0x0602CB01 RID: 183041 RVA: 0x00AAB68E File Offset: 0x00AA988E
		public unsafe FRotator Add_Bip001Spine2
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABPC_Seq_Body_V2_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABPC_Seq_Body_V2_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17007883 RID: 30851
		// (get) Token: 0x0602CB02 RID: 183042 RVA: 0x00AAB6A3 File Offset: 0x00AA98A3
		// (set) Token: 0x0602CB03 RID: 183043 RVA: 0x00AAB6B7 File Offset: 0x00AA98B7
		public unsafe FRotator Add_Bip001LClavicle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABPC_Seq_Body_V2_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABPC_Seq_Body_V2_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17007884 RID: 30852
		// (get) Token: 0x0602CB04 RID: 183044 RVA: 0x00AAB6CC File Offset: 0x00AA98CC
		// (set) Token: 0x0602CB05 RID: 183045 RVA: 0x00AAB6E0 File Offset: 0x00AA98E0
		public unsafe FRotator Add_Bip001LUpperArm
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABPC_Seq_Body_V2_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABPC_Seq_Body_V2_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17007885 RID: 30853
		// (get) Token: 0x0602CB06 RID: 183046 RVA: 0x00AAB6F5 File Offset: 0x00AA98F5
		// (set) Token: 0x0602CB07 RID: 183047 RVA: 0x00AAB709 File Offset: 0x00AA9909
		public unsafe FRotator Add_Bip001LForearm
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABPC_Seq_Body_V2_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABPC_Seq_Body_V2_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17007886 RID: 30854
		// (get) Token: 0x0602CB08 RID: 183048 RVA: 0x00AAB71E File Offset: 0x00AA991E
		// (set) Token: 0x0602CB09 RID: 183049 RVA: 0x00AAB732 File Offset: 0x00AA9932
		public unsafe FRotator Add_Bip001RClavicle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABPC_Seq_Body_V2_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABPC_Seq_Body_V2_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17007887 RID: 30855
		// (get) Token: 0x0602CB0A RID: 183050 RVA: 0x00AAB747 File Offset: 0x00AA9947
		// (set) Token: 0x0602CB0B RID: 183051 RVA: 0x00AAB75B File Offset: 0x00AA995B
		public unsafe FRotator Add_Bip001RUpperArm
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABPC_Seq_Body_V2_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABPC_Seq_Body_V2_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17007888 RID: 30856
		// (get) Token: 0x0602CB0C RID: 183052 RVA: 0x00AAB770 File Offset: 0x00AA9970
		// (set) Token: 0x0602CB0D RID: 183053 RVA: 0x00AAB784 File Offset: 0x00AA9984
		public unsafe FRotator Add_Bip001RForearm
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABPC_Seq_Body_V2_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABPC_Seq_Body_V2_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17007889 RID: 30857
		// (get) Token: 0x0602CB0E RID: 183054 RVA: 0x00AAB799 File Offset: 0x00AA9999
		// (set) Token: 0x0602CB0F RID: 183055 RVA: 0x00AAB7AD File Offset: 0x00AA99AD
		public unsafe FRotator Add_Bip001Spine1
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABPC_Seq_Body_V2_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABPC_Seq_Body_V2_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x1700788A RID: 30858
		// (get) Token: 0x0602CB10 RID: 183056 RVA: 0x00AAB7C2 File Offset: 0x00AA99C2
		// (set) Token: 0x0602CB11 RID: 183057 RVA: 0x00AAB7D6 File Offset: 0x00AA99D6
		public unsafe FRotator Add_Bip001LHand
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABPC_Seq_Body_V2_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABPC_Seq_Body_V2_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x1700788B RID: 30859
		// (get) Token: 0x0602CB12 RID: 183058 RVA: 0x00AAB7EB File Offset: 0x00AA99EB
		// (set) Token: 0x0602CB13 RID: 183059 RVA: 0x00AAB7FF File Offset: 0x00AA99FF
		public unsafe FRotator Add_Bip001RHand
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABPC_Seq_Body_V2_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABPC_Seq_Body_V2_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x1700788C RID: 30860
		// (get) Token: 0x0602CB14 RID: 183060 RVA: 0x00AAB814 File Offset: 0x00AA9A14
		// (set) Token: 0x0602CB15 RID: 183061 RVA: 0x00AAB824 File Offset: 0x00AA9A24
		public unsafe float SeqLHandWeight
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABPC_Seq_Body_V2_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABPC_Seq_Body_V2_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x1700788D RID: 30861
		// (get) Token: 0x0602CB16 RID: 183062 RVA: 0x00AAB835 File Offset: 0x00AA9A35
		// (set) Token: 0x0602CB17 RID: 183063 RVA: 0x00AAB845 File Offset: 0x00AA9A45
		public unsafe float SeqRHandWeight
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABPC_Seq_Body_V2_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABPC_Seq_Body_V2_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x1700788E RID: 30862
		// (get) Token: 0x0602CB18 RID: 183064 RVA: 0x00AAB856 File Offset: 0x00AA9A56
		// (set) Token: 0x0602CB19 RID: 183065 RVA: 0x00AAB86A File Offset: 0x00AA9A6A
		public unsafe FRotator Add_Bip001LThigh
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABPC_Seq_Body_V2_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABPC_Seq_Body_V2_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x1700788F RID: 30863
		// (get) Token: 0x0602CB1A RID: 183066 RVA: 0x00AAB87F File Offset: 0x00AA9A7F
		// (set) Token: 0x0602CB1B RID: 183067 RVA: 0x00AAB893 File Offset: 0x00AA9A93
		public unsafe FRotator Add_Bip001LCalf
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABPC_Seq_Body_V2_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABPC_Seq_Body_V2_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x17007890 RID: 30864
		// (get) Token: 0x0602CB1C RID: 183068 RVA: 0x00AAB8A8 File Offset: 0x00AA9AA8
		// (set) Token: 0x0602CB1D RID: 183069 RVA: 0x00AAB8BC File Offset: 0x00AA9ABC
		public unsafe FRotator Add_Bip001LFoot
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABPC_Seq_Body_V2_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABPC_Seq_Body_V2_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x17007891 RID: 30865
		// (get) Token: 0x0602CB1E RID: 183070 RVA: 0x00AAB8D1 File Offset: 0x00AA9AD1
		// (set) Token: 0x0602CB1F RID: 183071 RVA: 0x00AAB8E5 File Offset: 0x00AA9AE5
		public unsafe FRotator Add_Bip001RThigh
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABPC_Seq_Body_V2_C.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABPC_Seq_Body_V2_C.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x17007892 RID: 30866
		// (get) Token: 0x0602CB20 RID: 183072 RVA: 0x00AAB8FA File Offset: 0x00AA9AFA
		// (set) Token: 0x0602CB21 RID: 183073 RVA: 0x00AAB90E File Offset: 0x00AA9B0E
		public unsafe FRotator Add_Bip001RCalf
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABPC_Seq_Body_V2_C.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABPC_Seq_Body_V2_C.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x17007893 RID: 30867
		// (get) Token: 0x0602CB22 RID: 183074 RVA: 0x00AAB923 File Offset: 0x00AA9B23
		// (set) Token: 0x0602CB23 RID: 183075 RVA: 0x00AAB937 File Offset: 0x00AA9B37
		public unsafe FRotator Add_Bip001RFoot
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABPC_Seq_Body_V2_C.__PropertyOffset_23);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABPC_Seq_Body_V2_C.__PropertyOffset_23) = value;
			}
		}

		// Token: 0x0602CB24 RID: 183076 RVA: 0x00AAB94C File Offset: 0x00AA9B4C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual FName GetBindingName()
		{
			ABPC_Seq_Body_V2_C.__GetBindingName_FunctionParams* ptr = stackalloc ABPC_Seq_Body_V2_C.__GetBindingName_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(ABPC_Seq_Body_V2_C.__GetBindingName_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABPC_Seq_Body_V2_C.__GetBindingName_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABPC_Seq_Body_V2_C.__GetBindingName_NativeFunctionPtr, (void*)ptr);
			return ptr->__Result;
		}

		// Token: 0x0602CB25 RID: 183077 RVA: 0x00AAB994 File Offset: 0x00AA9B94
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual FName GetBindingName_Implementation()
		{
			ABPC_Seq_Body_V2_C.__GetBindingName_FunctionParams* ptr = stackalloc ABPC_Seq_Body_V2_C.__GetBindingName_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(ABPC_Seq_Body_V2_C.__GetBindingName_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABPC_Seq_Body_V2_C.__GetBindingName_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallUFunction(base.NativePtr, ABPC_Seq_Body_V2_C.__GetBindingName_NativeFunctionPtr, (void*)ptr, 0);
			return ptr->__Result;
		}

		// Token: 0x0602CB26 RID: 183078 RVA: 0x00AAB9DC File Offset: 0x00AA9BDC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetCurves([Nullable(new byte[]
		{
			2,
			1
		})] ref TArray<FNamedCurveValue> OutValues)
		{
			ABPC_Seq_Body_V2_C.__GetCurves_FunctionParams* ptr = stackalloc ABPC_Seq_Body_V2_C.__GetCurves_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(ABPC_Seq_Body_V2_C.__GetCurves_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABPC_Seq_Body_V2_C.__GetCurves_NativeFunctionPtr, (void*)ptr, 1);
			TArray<FNamedCurveValue> tarray = OutValues;
			if (tarray != null)
			{
				tarray.MoveTo(&ptr->OutValues);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABPC_Seq_Body_V2_C.__GetCurves_NativeFunctionPtr, (void*)ptr);
			TArray<FNamedCurveValue> tarray2 = OutValues;
			if (tarray2 != null)
			{
				tarray2.MoveAssign(&ptr->OutValues);
			}
			UnrealReflectionUtils.DestroyStruct(ABPC_Seq_Body_V2_C.__GetCurves_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602CB27 RID: 183079 RVA: 0x00AABA54 File Offset: 0x00AA9C54
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void GetCurves_Implementation([Nullable(new byte[]
		{
			2,
			1
		})] ref TArray<FNamedCurveValue> OutValues)
		{
			ABPC_Seq_Body_V2_C.__GetCurves_FunctionParams* ptr = stackalloc ABPC_Seq_Body_V2_C.__GetCurves_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(ABPC_Seq_Body_V2_C.__GetCurves_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABPC_Seq_Body_V2_C.__GetCurves_NativeFunctionPtr, (void*)ptr, 1);
			TArray<FNamedCurveValue> tarray = OutValues;
			if (tarray != null)
			{
				tarray.MoveTo(&ptr->OutValues);
			}
			UnrealReflectionUtils.CallUFunction(base.NativePtr, ABPC_Seq_Body_V2_C.__GetCurves_NativeFunctionPtr, (void*)ptr, 0);
			TArray<FNamedCurveValue> tarray2 = OutValues;
			if (tarray2 != null)
			{
				tarray2.MoveAssign(&ptr->OutValues);
			}
			UnrealReflectionUtils.DestroyStruct(ABPC_Seq_Body_V2_C.__GetCurves_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602CB28 RID: 183080 RVA: 0x00AABAD0 File Offset: 0x00AA9CD0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual float GetCurveValue(FName CurveName)
		{
			ABPC_Seq_Body_V2_C.__GetCurveValue_FunctionParams* ptr = stackalloc ABPC_Seq_Body_V2_C.__GetCurveValue_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(ABPC_Seq_Body_V2_C.__GetCurveValue_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABPC_Seq_Body_V2_C.__GetCurveValue_NativeFunctionPtr, (void*)ptr, 1);
			ptr->CurveName = CurveName;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABPC_Seq_Body_V2_C.__GetCurveValue_NativeFunctionPtr, (void*)ptr);
			return ptr->__Result;
		}

		// Token: 0x0602CB29 RID: 183081 RVA: 0x00AABB1C File Offset: 0x00AA9D1C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual float GetCurveValue_Implementation(FName CurveName)
		{
			ABPC_Seq_Body_V2_C.__GetCurveValue_FunctionParams* ptr = stackalloc ABPC_Seq_Body_V2_C.__GetCurveValue_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(ABPC_Seq_Body_V2_C.__GetCurveValue_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABPC_Seq_Body_V2_C.__GetCurveValue_NativeFunctionPtr, (void*)ptr, 1);
			ptr->CurveName = CurveName;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, ABPC_Seq_Body_V2_C.__GetCurveValue_NativeFunctionPtr, (void*)ptr, 0);
			return ptr->__Result;
		}

		// Token: 0x0602CB2A RID: 183082 RVA: 0x00AABB6C File Offset: 0x00AA9D6C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void ProcessEye(FVector EyeLookAt, float AngleScale)
		{
			ABPC_Seq_Body_V2_C.__ProcessEye_FunctionParams* ptr = stackalloc ABPC_Seq_Body_V2_C.__ProcessEye_FunctionParams[(UIntPtr)235] + 15L / (long)sizeof(ABPC_Seq_Body_V2_C.__ProcessEye_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABPC_Seq_Body_V2_C.__ProcessEye_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EyeLookAt = EyeLookAt;
			ptr->AngleScale = AngleScale;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABPC_Seq_Body_V2_C.__ProcessEye_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602CB2B RID: 183083 RVA: 0x00AABBBC File Offset: 0x00AA9DBC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetAnimDataFloatByOwner([Nullable(new byte[]
		{
			2,
			1
		})] ref TArray<FNamedCurveValue> InCurves)
		{
			ABPC_Seq_Body_V2_C.__SetAnimDataFloatByOwner_FunctionParams* ptr = stackalloc ABPC_Seq_Body_V2_C.__SetAnimDataFloatByOwner_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(ABPC_Seq_Body_V2_C.__SetAnimDataFloatByOwner_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABPC_Seq_Body_V2_C.__SetAnimDataFloatByOwner_NativeFunctionPtr, (void*)ptr, 1);
			TArray<FNamedCurveValue> tarray = InCurves;
			if (tarray != null)
			{
				tarray.MoveTo(&ptr->InCurves);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABPC_Seq_Body_V2_C.__SetAnimDataFloatByOwner_NativeFunctionPtr, (void*)ptr);
			TArray<FNamedCurveValue> tarray2 = InCurves;
			if (tarray2 != null)
			{
				tarray2.MoveAssign(&ptr->InCurves);
			}
			UnrealReflectionUtils.DestroyStruct(ABPC_Seq_Body_V2_C.__SetAnimDataFloatByOwner_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602CB2C RID: 183084 RVA: 0x00AABC34 File Offset: 0x00AA9E34
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetAnimDataVectorByOwner(ref TMap<FName, FVector> VectorMap)
		{
			ABPC_Seq_Body_V2_C.__SetAnimDataVectorByOwner_FunctionParams* ptr = stackalloc ABPC_Seq_Body_V2_C.__SetAnimDataVectorByOwner_FunctionParams[(UIntPtr)1127] + 15L / (long)sizeof(ABPC_Seq_Body_V2_C.__SetAnimDataVectorByOwner_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABPC_Seq_Body_V2_C.__SetAnimDataVectorByOwner_NativeFunctionPtr, (void*)ptr, 1);
			TMap<FName, FVector> tmap = VectorMap;
			if (tmap != null)
			{
				tmap.MoveTo(&ptr->VectorMap);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABPC_Seq_Body_V2_C.__SetAnimDataVectorByOwner_NativeFunctionPtr, (void*)ptr);
			TMap<FName, FVector> tmap2 = VectorMap;
			if (tmap2 != null)
			{
				tmap2.MoveAssign(&ptr->VectorMap);
			}
			UnrealReflectionUtils.DestroyStruct(ABPC_Seq_Body_V2_C.__SetAnimDataVectorByOwner_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602CB2D RID: 183085 RVA: 0x00AABCAF File Offset: 0x00AA9EAF
		protected ABPC_Seq_Body_V2_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018E3D RID: 101949
		internal static int __InterfaceOffset_ICurveSourceInterface;

		// Token: 0x04018E3E RID: 101950
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseSeqCharacter/ABPC_Seq_Body_V2.ABPC_Seq_Body_V2_C";

		// Token: 0x04018E3F RID: 101951
		private static IntPtr _ClassPtr;

		// Token: 0x04018E40 RID: 101952
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04018E41 RID: 101953
		internal static int __PropertyOffset_0;

		// Token: 0x04018E42 RID: 101954
		internal static int __PropertyOffset_1;

		// Token: 0x04018E43 RID: 101955
		internal static int __PropertyOffset_2;

		// Token: 0x04018E44 RID: 101956
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<FNamedCurveValue> _NamedCurves;

		// Token: 0x04018E45 RID: 101957
		internal static int __PropertyOffset_3;

		// Token: 0x04018E46 RID: 101958
		internal static int __PropertyOffset_4;

		// Token: 0x04018E47 RID: 101959
		internal static int __PropertyOffset_5;

		// Token: 0x04018E48 RID: 101960
		internal static int __PropertyOffset_6;

		// Token: 0x04018E49 RID: 101961
		internal static int __PropertyOffset_7;

		// Token: 0x04018E4A RID: 101962
		internal static int __PropertyOffset_8;

		// Token: 0x04018E4B RID: 101963
		internal static int __PropertyOffset_9;

		// Token: 0x04018E4C RID: 101964
		internal static int __PropertyOffset_10;

		// Token: 0x04018E4D RID: 101965
		internal static int __PropertyOffset_11;

		// Token: 0x04018E4E RID: 101966
		internal static int __PropertyOffset_12;

		// Token: 0x04018E4F RID: 101967
		internal static int __PropertyOffset_13;

		// Token: 0x04018E50 RID: 101968
		internal static int __PropertyOffset_14;

		// Token: 0x04018E51 RID: 101969
		internal static int __PropertyOffset_15;

		// Token: 0x04018E52 RID: 101970
		internal static int __PropertyOffset_16;

		// Token: 0x04018E53 RID: 101971
		internal static int __PropertyOffset_17;

		// Token: 0x04018E54 RID: 101972
		internal static int __PropertyOffset_18;

		// Token: 0x04018E55 RID: 101973
		internal static int __PropertyOffset_19;

		// Token: 0x04018E56 RID: 101974
		internal static int __PropertyOffset_20;

		// Token: 0x04018E57 RID: 101975
		internal static int __PropertyOffset_21;

		// Token: 0x04018E58 RID: 101976
		internal static int __PropertyOffset_22;

		// Token: 0x04018E59 RID: 101977
		internal static int __PropertyOffset_23;

		// Token: 0x04018E5A RID: 101978
		private static IntPtr __GetBindingName_NativeFunctionPtr;

		// Token: 0x04018E5B RID: 101979
		private static IntPtr __GetCurves_NativeFunctionPtr;

		// Token: 0x04018E5C RID: 101980
		private static IntPtr __GetCurveValue_NativeFunctionPtr;

		// Token: 0x04018E5D RID: 101981
		private static IntPtr __ProcessEye_NativeFunctionPtr;

		// Token: 0x04018E5E RID: 101982
		private static IntPtr __SetAnimDataFloatByOwner_NativeFunctionPtr;

		// Token: 0x04018E5F RID: 101983
		private static IntPtr __SetAnimDataVectorByOwner_NativeFunctionPtr;

		// Token: 0x0200A4DC RID: 42204
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __GetBindingName_FunctionParams
		{
			// Token: 0x04033333 RID: 209715
			[FieldOffset(0)]
			public FName __Result;
		}

		// Token: 0x0200A4DD RID: 42205
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __GetCurves_FunctionParams
		{
			// Token: 0x04033334 RID: 209716
			[FieldOffset(0)]
			public byte OutValues;
		}

		// Token: 0x0200A4DE RID: 42206
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __GetCurveValue_FunctionParams
		{
			// Token: 0x04033335 RID: 209717
			[FieldOffset(0)]
			public FName CurveName;

			// Token: 0x04033336 RID: 209718
			[FieldOffset(12)]
			public float __Result;
		}

		// Token: 0x0200A4DF RID: 42207
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 220)]
		protected ref struct __ProcessEye_FunctionParams
		{
			// Token: 0x04033337 RID: 209719
			[FieldOffset(0)]
			public FVector EyeLookAt;

			// Token: 0x04033338 RID: 209720
			[FieldOffset(12)]
			public float AngleScale;
		}

		// Token: 0x0200A4E0 RID: 42208
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __SetAnimDataFloatByOwner_FunctionParams
		{
			// Token: 0x04033339 RID: 209721
			[FieldOffset(0)]
			public byte InCurves;
		}

		// Token: 0x0200A4E1 RID: 42209
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1112)]
		protected ref struct __SetAnimDataVectorByOwner_FunctionParams
		{
			// Token: 0x0403333A RID: 209722
			[FieldOffset(0)]
			public byte VectorMap;
		}
	}
}
