using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Sequence
{
	// Token: 0x02003A5B RID: 14939
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Sequence/BP_MobileDeviceConsole.BP_MobileDeviceConsole_C")]
	[UnrealStructLayout(1096, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1089)]
	public class BP_MobileDeviceConsole_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601F0B1 RID: 127153 RVA: 0x00905D6C File Offset: 0x00903F6C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_MobileDeviceConsole_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Sequence/BP_MobileDeviceConsole.BP_MobileDeviceConsole_C");
			}
			return BP_MobileDeviceConsole_C._ClassPtr;
		}

		// Token: 0x0601F0B2 RID: 127154 RVA: 0x00905D90 File Offset: 0x00903F90
		public BP_MobileDeviceConsole_C() : this(BuiltinUtils.AllocNativeUObject(BP_MobileDeviceConsole_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601F0B3 RID: 127155 RVA: 0x00905DB8 File Offset: 0x00903FB8
		public BP_MobileDeviceConsole_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_MobileDeviceConsole_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17002DC8 RID: 11720
		// (get) Token: 0x0601F0B4 RID: 127156 RVA: 0x00905DEC File Offset: 0x00903FEC
		// (set) Token: 0x0601F0B5 RID: 127157 RVA: 0x00905E25 File Offset: 0x00904025
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_MobileDeviceConsole_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_MobileDeviceConsole_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17002DC9 RID: 11721
		// (get) Token: 0x0601F0B6 RID: 127158 RVA: 0x00905E46 File Offset: 0x00904046
		// (set) Token: 0x0601F0B7 RID: 127159 RVA: 0x00905E5A File Offset: 0x0090405A
		[Nullable(2)]
		public unsafe USceneComponent DefaultSceneRoot
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MobileDeviceConsole_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MobileDeviceConsole_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17002DCA RID: 11722
		// (get) Token: 0x0601F0B8 RID: 127160 RVA: 0x00905E6F File Offset: 0x0090406F
		// (set) Token: 0x0601F0B9 RID: 127161 RVA: 0x00905E7F File Offset: 0x0090407F
		public unsafe int Value
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MobileDeviceConsole_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MobileDeviceConsole_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17002DCB RID: 11723
		// (get) Token: 0x0601F0BA RID: 127162 RVA: 0x00905E90 File Offset: 0x00904090
		// (set) Token: 0x0601F0BB RID: 127163 RVA: 0x00905EA0 File Offset: 0x009040A0
		public unsafe int NewVar_0
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MobileDeviceConsole_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MobileDeviceConsole_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17002DCC RID: 11724
		// (get) Token: 0x0601F0BC RID: 127164 RVA: 0x00905EB1 File Offset: 0x009040B1
		// (set) Token: 0x0601F0BD RID: 127165 RVA: 0x00905EC5 File Offset: 0x009040C5
		public unsafe string Command
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)BP_MobileDeviceConsole_C.__PropertyOffset_4)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)BP_MobileDeviceConsole_C.__PropertyOffset_4)), value);
			}
		}

		// Token: 0x17002DCD RID: 11725
		// (get) Token: 0x0601F0BE RID: 127166 RVA: 0x00905EDC File Offset: 0x009040DC
		// (set) Token: 0x0601F0BF RID: 127167 RVA: 0x00905F15 File Offset: 0x00904115
		public TArray<string> TargetMobileDevice
		{
			get
			{
				base.FastCheckIsValid();
				TArray<string> result;
				if ((result = this._TargetMobileDevice) == null)
				{
					result = (this._TargetMobileDevice = new TArray<string>(base.NativePtr + (IntPtr)BP_MobileDeviceConsole_C.__PropertyOffset_5, this));
				}
				return result;
			}
			set
			{
				this.TargetMobileDevice.CopyAssign(value);
			}
		}

		// Token: 0x17002DCE RID: 11726
		// (get) Token: 0x0601F0C0 RID: 127168 RVA: 0x00905F23 File Offset: 0x00904123
		// (set) Token: 0x0601F0C1 RID: 127169 RVA: 0x00905F33 File Offset: 0x00904133
		public unsafe bool IsTargetDevice
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MobileDeviceConsole_C.__PropertyOffset_6) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MobileDeviceConsole_C.__PropertyOffset_6) = (value ? 1 : 0);
			}
		}

		// Token: 0x0601F0C2 RID: 127170 RVA: 0x00905F44 File Offset: 0x00904144
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MobileDeviceConsole_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0601F0C3 RID: 127171 RVA: 0x00905F58 File Offset: 0x00904158
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_MobileDeviceConsole_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601F0C4 RID: 127172 RVA: 0x00905F70 File Offset: 0x00904170
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveEndPlay(EEndPlayReason EndPlayReason)
		{
			BP_MobileDeviceConsole_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_MobileDeviceConsole_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_MobileDeviceConsole_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MobileDeviceConsole_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MobileDeviceConsole_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F0C5 RID: 127173 RVA: 0x00905FBC File Offset: 0x009041BC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveEndPlay_Implementation(EEndPlayReason EndPlayReason)
		{
			BP_MobileDeviceConsole_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_MobileDeviceConsole_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_MobileDeviceConsole_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MobileDeviceConsole_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_MobileDeviceConsole_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F0C6 RID: 127174 RVA: 0x00906008 File Offset: 0x00904208
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_MobileDeviceConsole(int EntryPoint)
		{
			BP_MobileDeviceConsole_C.__ExecuteUbergraph_BP_MobileDeviceConsole_FunctionParams* ptr = stackalloc BP_MobileDeviceConsole_C.__ExecuteUbergraph_BP_MobileDeviceConsole_FunctionParams[(UIntPtr)223] + 15L / (long)sizeof(BP_MobileDeviceConsole_C.__ExecuteUbergraph_BP_MobileDeviceConsole_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MobileDeviceConsole_C.__ExecuteUbergraph_BP_MobileDeviceConsole_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_MobileDeviceConsole_C.__ExecuteUbergraph_BP_MobileDeviceConsole_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F0C7 RID: 127175 RVA: 0x00906052 File Offset: 0x00904252
		protected BP_MobileDeviceConsole_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400F5C8 RID: 62920
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Sequence/BP_MobileDeviceConsole.BP_MobileDeviceConsole_C";

		// Token: 0x0400F5C9 RID: 62921
		private static IntPtr _ClassPtr;

		// Token: 0x0400F5CA RID: 62922
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400F5CB RID: 62923
		internal static int __PropertyOffset_0;

		// Token: 0x0400F5CC RID: 62924
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400F5CD RID: 62925
		internal static int __PropertyOffset_1;

		// Token: 0x0400F5CE RID: 62926
		internal static int __PropertyOffset_2;

		// Token: 0x0400F5CF RID: 62927
		internal static int __PropertyOffset_3;

		// Token: 0x0400F5D0 RID: 62928
		internal static int __PropertyOffset_4;

		// Token: 0x0400F5D1 RID: 62929
		internal static int __PropertyOffset_5;

		// Token: 0x0400F5D2 RID: 62930
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<string> _TargetMobileDevice;

		// Token: 0x0400F5D3 RID: 62931
		internal static int __PropertyOffset_6;

		// Token: 0x0400F5D4 RID: 62932
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0400F5D5 RID: 62933
		private static IntPtr __ReceiveEndPlay_NativeFunctionPtr;

		// Token: 0x0400F5D6 RID: 62934
		private static IntPtr __ExecuteUbergraph_BP_MobileDeviceConsole_NativeFunctionPtr;

		// Token: 0x02009849 RID: 38985
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __ReceiveEndPlay_FunctionParams
		{
			// Token: 0x04031E7C RID: 204412
			[FieldOffset(0)]
			public TEnumAsByte<EEndPlayReason> EndPlayReason;
		}

		// Token: 0x0200984A RID: 38986
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 208)]
		protected ref struct __ExecuteUbergraph_BP_MobileDeviceConsole_FunctionParams
		{
			// Token: 0x04031E7D RID: 204413
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
