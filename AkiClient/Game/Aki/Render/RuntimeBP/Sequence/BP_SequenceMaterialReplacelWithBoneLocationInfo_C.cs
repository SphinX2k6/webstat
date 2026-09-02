using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Sequence
{
	// Token: 0x02003A5E RID: 14942
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Sequence/BP_SequenceMaterialReplacelWithBoneLocationInfo.BP_SequenceMaterialReplacelWithBoneLocationInfo_C")]
	[UnrealStructLayout(1160, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1156)]
	public class BP_SequenceMaterialReplacelWithBoneLocationInfo_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601F0E6 RID: 127206 RVA: 0x00906538 File Offset: 0x00904738
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SequenceMaterialReplacelWithBoneLocationInfo_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Sequence/BP_SequenceMaterialReplacelWithBoneLocationInfo.BP_SequenceMaterialReplacelWithBoneLocationInfo_C");
			}
			return BP_SequenceMaterialReplacelWithBoneLocationInfo_C._ClassPtr;
		}

		// Token: 0x0601F0E7 RID: 127207 RVA: 0x0090655C File Offset: 0x0090475C
		public BP_SequenceMaterialReplacelWithBoneLocationInfo_C() : this(BuiltinUtils.AllocNativeUObject(BP_SequenceMaterialReplacelWithBoneLocationInfo_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601F0E8 RID: 127208 RVA: 0x00906584 File Offset: 0x00904784
		public BP_SequenceMaterialReplacelWithBoneLocationInfo_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SequenceMaterialReplacelWithBoneLocationInfo_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17002DD4 RID: 11732
		// (get) Token: 0x0601F0E9 RID: 127209 RVA: 0x009065B8 File Offset: 0x009047B8
		// (set) Token: 0x0601F0EA RID: 127210 RVA: 0x009065F1 File Offset: 0x009047F1
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_SequenceMaterialReplacelWithBoneLocationInfo_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_SequenceMaterialReplacelWithBoneLocationInfo_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17002DD5 RID: 11733
		// (get) Token: 0x0601F0EB RID: 127211 RVA: 0x00906612 File Offset: 0x00904812
		// (set) Token: 0x0601F0EC RID: 127212 RVA: 0x00906626 File Offset: 0x00904826
		[Nullable(2)]
		public unsafe USceneComponent DefaultSceneRoot
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SequenceMaterialReplacelWithBoneLocationInfo_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SequenceMaterialReplacelWithBoneLocationInfo_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17002DD6 RID: 11734
		// (get) Token: 0x0601F0ED RID: 127213 RVA: 0x0090663B File Offset: 0x0090483B
		// (set) Token: 0x0601F0EE RID: 127214 RVA: 0x0090664F File Offset: 0x0090484F
		[Nullable(2)]
		public unsafe AActor Actor
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SequenceMaterialReplacelWithBoneLocationInfo_C.__PropertyOffset_2);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SequenceMaterialReplacelWithBoneLocationInfo_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17002DD7 RID: 11735
		// (get) Token: 0x0601F0EF RID: 127215 RVA: 0x00906664 File Offset: 0x00904864
		// (set) Token: 0x0601F0F0 RID: 127216 RVA: 0x00906678 File Offset: 0x00904878
		[Nullable(2)]
		public unsafe UMaterialInterface MaterialToReplace
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInterface>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SequenceMaterialReplacelWithBoneLocationInfo_C.__PropertyOffset_3);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SequenceMaterialReplacelWithBoneLocationInfo_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17002DD8 RID: 11736
		// (get) Token: 0x0601F0F1 RID: 127217 RVA: 0x00906690 File Offset: 0x00904890
		// (set) Token: 0x0601F0F2 RID: 127218 RVA: 0x009066C9 File Offset: 0x009048C9
		public TArray<UMaterialInstanceDynamic> DMIs
		{
			get
			{
				base.FastCheckIsValid();
				TArray<UMaterialInstanceDynamic> result;
				if ((result = this._DMIs) == null)
				{
					result = (this._DMIs = new TArray<UMaterialInstanceDynamic>(base.NativePtr + (IntPtr)BP_SequenceMaterialReplacelWithBoneLocationInfo_C.__PropertyOffset_4, this));
				}
				return result;
			}
			set
			{
				this.DMIs.CopyAssign(value);
			}
		}

		// Token: 0x17002DD9 RID: 11737
		// (get) Token: 0x0601F0F3 RID: 127219 RVA: 0x009066D8 File Offset: 0x009048D8
		// (set) Token: 0x0601F0F4 RID: 127220 RVA: 0x00906711 File Offset: 0x00904911
		public TArray<FKuroCharMaterialControllerFloatParameter> FloatParameters
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FKuroCharMaterialControllerFloatParameter> result;
				if ((result = this._FloatParameters) == null)
				{
					result = (this._FloatParameters = new TArray<FKuroCharMaterialControllerFloatParameter>(base.NativePtr + (IntPtr)BP_SequenceMaterialReplacelWithBoneLocationInfo_C.__PropertyOffset_5, this));
				}
				return result;
			}
			set
			{
				this.FloatParameters.CopyAssign(value);
			}
		}

		// Token: 0x17002DDA RID: 11738
		// (get) Token: 0x0601F0F5 RID: 127221 RVA: 0x00906720 File Offset: 0x00904920
		// (set) Token: 0x0601F0F6 RID: 127222 RVA: 0x00906759 File Offset: 0x00904959
		public TArray<FKuroCharMaterialControllerColorParameter> ColorParameters
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FKuroCharMaterialControllerColorParameter> result;
				if ((result = this._ColorParameters) == null)
				{
					result = (this._ColorParameters = new TArray<FKuroCharMaterialControllerColorParameter>(base.NativePtr + (IntPtr)BP_SequenceMaterialReplacelWithBoneLocationInfo_C.__PropertyOffset_6, this));
				}
				return result;
			}
			set
			{
				this.ColorParameters.CopyAssign(value);
			}
		}

		// Token: 0x17002DDB RID: 11739
		// (get) Token: 0x0601F0F7 RID: 127223 RVA: 0x00906767 File Offset: 0x00904967
		// (set) Token: 0x0601F0F8 RID: 127224 RVA: 0x00906777 File Offset: 0x00904977
		public unsafe float Time
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SequenceMaterialReplacelWithBoneLocationInfo_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SequenceMaterialReplacelWithBoneLocationInfo_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17002DDC RID: 11740
		// (get) Token: 0x0601F0F9 RID: 127225 RVA: 0x00906788 File Offset: 0x00904988
		// (set) Token: 0x0601F0FA RID: 127226 RVA: 0x00906798 File Offset: 0x00904998
		public unsafe bool IsPlaying
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SequenceMaterialReplacelWithBoneLocationInfo_C.__PropertyOffset_8) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SequenceMaterialReplacelWithBoneLocationInfo_C.__PropertyOffset_8) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002DDD RID: 11741
		// (get) Token: 0x0601F0FB RID: 127227 RVA: 0x009067A9 File Offset: 0x009049A9
		// (set) Token: 0x0601F0FC RID: 127228 RVA: 0x009067BD File Offset: 0x009049BD
		public unsafe FName ParameterName_Center
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SequenceMaterialReplacelWithBoneLocationInfo_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SequenceMaterialReplacelWithBoneLocationInfo_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17002DDE RID: 11742
		// (get) Token: 0x0601F0FD RID: 127229 RVA: 0x009067D2 File Offset: 0x009049D2
		// (set) Token: 0x0601F0FE RID: 127230 RVA: 0x009067E6 File Offset: 0x009049E6
		public unsafe FName BoneName_Center
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SequenceMaterialReplacelWithBoneLocationInfo_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SequenceMaterialReplacelWithBoneLocationInfo_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17002DDF RID: 11743
		// (get) Token: 0x0601F0FF RID: 127231 RVA: 0x009067FB File Offset: 0x009049FB
		// (set) Token: 0x0601F100 RID: 127232 RVA: 0x0090680F File Offset: 0x00904A0F
		public unsafe FVector CenterBias
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SequenceMaterialReplacelWithBoneLocationInfo_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SequenceMaterialReplacelWithBoneLocationInfo_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x0601F101 RID: 127233 RVA: 0x00906824 File Offset: 0x00904A24
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Reset()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SequenceMaterialReplacelWithBoneLocationInfo_C.__Reset_NativeFunctionPtr, null);
		}

		// Token: 0x0601F102 RID: 127234 RVA: 0x00906838 File Offset: 0x00904A38
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void IsReady(ref bool Result)
		{
			BP_SequenceMaterialReplacelWithBoneLocationInfo_C.__IsReady_FunctionParams* ptr = stackalloc BP_SequenceMaterialReplacelWithBoneLocationInfo_C.__IsReady_FunctionParams[(UIntPtr)63] + 15L / (long)sizeof(BP_SequenceMaterialReplacelWithBoneLocationInfo_C.__IsReady_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SequenceMaterialReplacelWithBoneLocationInfo_C.__IsReady_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Result = Result;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SequenceMaterialReplacelWithBoneLocationInfo_C.__IsReady_NativeFunctionPtr, (void*)ptr);
			Result = ptr->Result;
		}

		// Token: 0x0601F103 RID: 127235 RVA: 0x00906888 File Offset: 0x00904A88
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_SequenceMaterialReplacelWithBoneLocationInfo_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_SequenceMaterialReplacelWithBoneLocationInfo_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SequenceMaterialReplacelWithBoneLocationInfo_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SequenceMaterialReplacelWithBoneLocationInfo_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SequenceMaterialReplacelWithBoneLocationInfo_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F104 RID: 127236 RVA: 0x009068D0 File Offset: 0x00904AD0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_SequenceMaterialReplacelWithBoneLocationInfo_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_SequenceMaterialReplacelWithBoneLocationInfo_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SequenceMaterialReplacelWithBoneLocationInfo_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SequenceMaterialReplacelWithBoneLocationInfo_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SequenceMaterialReplacelWithBoneLocationInfo_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F105 RID: 127237 RVA: 0x00906918 File Offset: 0x00904B18
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_SequenceMaterialReplacelWithBoneLocationInfo(int EntryPoint)
		{
			BP_SequenceMaterialReplacelWithBoneLocationInfo_C.__ExecuteUbergraph_BP_SequenceMaterialReplacelWithBoneLocationInfo_FunctionParams* ptr = stackalloc BP_SequenceMaterialReplacelWithBoneLocationInfo_C.__ExecuteUbergraph_BP_SequenceMaterialReplacelWithBoneLocationInfo_FunctionParams[(UIntPtr)1015] + 15L / (long)sizeof(BP_SequenceMaterialReplacelWithBoneLocationInfo_C.__ExecuteUbergraph_BP_SequenceMaterialReplacelWithBoneLocationInfo_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SequenceMaterialReplacelWithBoneLocationInfo_C.__ExecuteUbergraph_BP_SequenceMaterialReplacelWithBoneLocationInfo_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SequenceMaterialReplacelWithBoneLocationInfo_C.__ExecuteUbergraph_BP_SequenceMaterialReplacelWithBoneLocationInfo_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F106 RID: 127238 RVA: 0x00906962 File Offset: 0x00904B62
		protected BP_SequenceMaterialReplacelWithBoneLocationInfo_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400F5EB RID: 62955
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Sequence/BP_SequenceMaterialReplacelWithBoneLocationInfo.BP_SequenceMaterialReplacelWithBoneLocationInfo_C";

		// Token: 0x0400F5EC RID: 62956
		private static IntPtr _ClassPtr;

		// Token: 0x0400F5ED RID: 62957
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400F5EE RID: 62958
		internal static int __PropertyOffset_0;

		// Token: 0x0400F5EF RID: 62959
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400F5F0 RID: 62960
		internal static int __PropertyOffset_1;

		// Token: 0x0400F5F1 RID: 62961
		internal static int __PropertyOffset_2;

		// Token: 0x0400F5F2 RID: 62962
		internal static int __PropertyOffset_3;

		// Token: 0x0400F5F3 RID: 62963
		internal static int __PropertyOffset_4;

		// Token: 0x0400F5F4 RID: 62964
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UMaterialInstanceDynamic> _DMIs;

		// Token: 0x0400F5F5 RID: 62965
		internal static int __PropertyOffset_5;

		// Token: 0x0400F5F6 RID: 62966
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<FKuroCharMaterialControllerFloatParameter> _FloatParameters;

		// Token: 0x0400F5F7 RID: 62967
		internal static int __PropertyOffset_6;

		// Token: 0x0400F5F8 RID: 62968
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<FKuroCharMaterialControllerColorParameter> _ColorParameters;

		// Token: 0x0400F5F9 RID: 62969
		internal static int __PropertyOffset_7;

		// Token: 0x0400F5FA RID: 62970
		internal static int __PropertyOffset_8;

		// Token: 0x0400F5FB RID: 62971
		internal static int __PropertyOffset_9;

		// Token: 0x0400F5FC RID: 62972
		internal static int __PropertyOffset_10;

		// Token: 0x0400F5FD RID: 62973
		internal static int __PropertyOffset_11;

		// Token: 0x0400F5FE RID: 62974
		private static IntPtr __Reset_NativeFunctionPtr;

		// Token: 0x0400F5FF RID: 62975
		private static IntPtr __IsReady_NativeFunctionPtr;

		// Token: 0x0400F600 RID: 62976
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0400F601 RID: 62977
		private static IntPtr __ExecuteUbergraph_BP_SequenceMaterialReplacelWithBoneLocationInfo_NativeFunctionPtr;

		// Token: 0x02009850 RID: 38992
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 48)]
		protected ref struct __IsReady_FunctionParams
		{
			// Token: 0x04031E83 RID: 204419
			[FieldOffset(0)]
			public bool Result;
		}

		// Token: 0x02009851 RID: 38993
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04031E84 RID: 204420
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009852 RID: 38994
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1000)]
		protected ref struct __ExecuteUbergraph_BP_SequenceMaterialReplacelWithBoneLocationInfo_FunctionParams
		{
			// Token: 0x04031E85 RID: 204421
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
