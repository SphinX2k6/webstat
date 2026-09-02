using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.KuroSeasonsManager
{
	// Token: 0x02003BE6 RID: 15334
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/KuroSeasonsManager/BP_KuroSeasonsManager.BP_KuroSeasonsManager_C")]
	[UnrealStructLayout(1704, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1704)]
	public class BP_KuroSeasonsManager_C : AKuroSeasonsManager, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602279E RID: 141214 RVA: 0x009667CC File Offset: 0x009649CC
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_KuroSeasonsManager_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/KuroSeasonsManager/BP_KuroSeasonsManager.BP_KuroSeasonsManager_C");
			}
			return BP_KuroSeasonsManager_C._ClassPtr;
		}

		// Token: 0x0602279F RID: 141215 RVA: 0x009667F0 File Offset: 0x009649F0
		public BP_KuroSeasonsManager_C() : this(BuiltinUtils.AllocNativeUObject(BP_KuroSeasonsManager_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060227A0 RID: 141216 RVA: 0x00966818 File Offset: 0x00964A18
		[NullableContext(1)]
		public BP_KuroSeasonsManager_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_KuroSeasonsManager_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170040FA RID: 16634
		// (get) Token: 0x060227A1 RID: 141217 RVA: 0x0096684C File Offset: 0x00964A4C
		// (set) Token: 0x060227A2 RID: 141218 RVA: 0x00966885 File Offset: 0x00964A85
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_KuroSeasonsManager_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_KuroSeasonsManager_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170040FB RID: 16635
		// (get) Token: 0x060227A3 RID: 141219 RVA: 0x009668A6 File Offset: 0x00964AA6
		// (set) Token: 0x060227A4 RID: 141220 RVA: 0x009668B6 File Offset: 0x00964AB6
		public unsafe float Time
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroSeasonsManager_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroSeasonsManager_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x170040FC RID: 16636
		// (get) Token: 0x060227A5 RID: 141221 RVA: 0x009668C7 File Offset: 0x00964AC7
		// (set) Token: 0x060227A6 RID: 141222 RVA: 0x009668D7 File Offset: 0x00964AD7
		public unsafe float SpringStartTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroSeasonsManager_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroSeasonsManager_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x170040FD RID: 16637
		// (get) Token: 0x060227A7 RID: 141223 RVA: 0x009668E8 File Offset: 0x00964AE8
		// (set) Token: 0x060227A8 RID: 141224 RVA: 0x009668F8 File Offset: 0x00964AF8
		public unsafe float SummerStartTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroSeasonsManager_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroSeasonsManager_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x170040FE RID: 16638
		// (get) Token: 0x060227A9 RID: 141225 RVA: 0x00966909 File Offset: 0x00964B09
		// (set) Token: 0x060227AA RID: 141226 RVA: 0x00966919 File Offset: 0x00964B19
		public unsafe float AutumnStartTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroSeasonsManager_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroSeasonsManager_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x170040FF RID: 16639
		// (get) Token: 0x060227AB RID: 141227 RVA: 0x0096692A File Offset: 0x00964B2A
		// (set) Token: 0x060227AC RID: 141228 RVA: 0x0096693A File Offset: 0x00964B3A
		public unsafe float WinterStartTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroSeasonsManager_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroSeasonsManager_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17004100 RID: 16640
		// (get) Token: 0x060227AD RID: 141229 RVA: 0x0096694B File Offset: 0x00964B4B
		// (set) Token: 0x060227AE RID: 141230 RVA: 0x0096695B File Offset: 0x00964B5B
		public unsafe float LastTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroSeasonsManager_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroSeasonsManager_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x060227AF RID: 141231 RVA: 0x0096696C File Offset: 0x00964B6C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_KuroSeasonsManager_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_KuroSeasonsManager_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_KuroSeasonsManager_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroSeasonsManager_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroSeasonsManager_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060227B0 RID: 141232 RVA: 0x009669B4 File Offset: 0x00964BB4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_KuroSeasonsManager_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_KuroSeasonsManager_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_KuroSeasonsManager_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroSeasonsManager_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroSeasonsManager_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060227B1 RID: 141233 RVA: 0x009669FB File Offset: 0x00964BFB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroSeasonsManager_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x060227B2 RID: 141234 RVA: 0x00966A0F File Offset: 0x00964C0F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroSeasonsManager_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060227B3 RID: 141235 RVA: 0x00966A24 File Offset: 0x00964C24
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_KuroSeasonsManager(int EntryPoint)
		{
			BP_KuroSeasonsManager_C.__ExecuteUbergraph_BP_KuroSeasonsManager_FunctionParams* ptr = stackalloc BP_KuroSeasonsManager_C.__ExecuteUbergraph_BP_KuroSeasonsManager_FunctionParams[(UIntPtr)79] + 15L / (long)sizeof(BP_KuroSeasonsManager_C.__ExecuteUbergraph_BP_KuroSeasonsManager_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroSeasonsManager_C.__ExecuteUbergraph_BP_KuroSeasonsManager_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroSeasonsManager_C.__ExecuteUbergraph_BP_KuroSeasonsManager_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060227B4 RID: 141236 RVA: 0x00966A6B File Offset: 0x00964C6B
		protected BP_KuroSeasonsManager_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401174D RID: 71501
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/KuroSeasonsManager/BP_KuroSeasonsManager.BP_KuroSeasonsManager_C";

		// Token: 0x0401174E RID: 71502
		private static IntPtr _ClassPtr;

		// Token: 0x0401174F RID: 71503
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04011750 RID: 71504
		internal static int __PropertyOffset_0;

		// Token: 0x04011751 RID: 71505
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04011752 RID: 71506
		internal static int __PropertyOffset_1;

		// Token: 0x04011753 RID: 71507
		internal static int __PropertyOffset_2;

		// Token: 0x04011754 RID: 71508
		internal static int __PropertyOffset_3;

		// Token: 0x04011755 RID: 71509
		internal static int __PropertyOffset_4;

		// Token: 0x04011756 RID: 71510
		internal static int __PropertyOffset_5;

		// Token: 0x04011757 RID: 71511
		internal static int __PropertyOffset_6;

		// Token: 0x04011758 RID: 71512
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04011759 RID: 71513
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0401175A RID: 71514
		private static IntPtr __ExecuteUbergraph_BP_KuroSeasonsManager_NativeFunctionPtr;

		// Token: 0x02009BE2 RID: 39906
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032430 RID: 205872
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009BE3 RID: 39907
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 64)]
		protected ref struct __ExecuteUbergraph_BP_KuroSeasonsManager_FunctionParams
		{
			// Token: 0x04032431 RID: 205873
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
