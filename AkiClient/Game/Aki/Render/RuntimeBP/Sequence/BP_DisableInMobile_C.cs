using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Sequence
{
	// Token: 0x02003A58 RID: 14936
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Sequence/BP_DisableInMobile.BP_DisableInMobile_C")]
	[UnrealStructLayout(1064, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1064)]
	public class BP_DisableInMobile_C : APointLight, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601F07A RID: 127098 RVA: 0x0090561C File Offset: 0x0090381C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_DisableInMobile_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Sequence/BP_DisableInMobile.BP_DisableInMobile_C");
			}
			return BP_DisableInMobile_C._ClassPtr;
		}

		// Token: 0x0601F07B RID: 127099 RVA: 0x00905640 File Offset: 0x00903840
		public BP_DisableInMobile_C() : this(BuiltinUtils.AllocNativeUObject(BP_DisableInMobile_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601F07C RID: 127100 RVA: 0x00905668 File Offset: 0x00903868
		public BP_DisableInMobile_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_DisableInMobile_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17002DBE RID: 11710
		// (get) Token: 0x0601F07D RID: 127101 RVA: 0x0090569C File Offset: 0x0090389C
		// (set) Token: 0x0601F07E RID: 127102 RVA: 0x009056D5 File Offset: 0x009038D5
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_DisableInMobile_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_DisableInMobile_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x0601F07F RID: 127103 RVA: 0x009056F6 File Offset: 0x009038F6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DisableInMobile_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0601F080 RID: 127104 RVA: 0x0090570A File Offset: 0x0090390A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_DisableInMobile_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601F081 RID: 127105 RVA: 0x0090571F File Offset: 0x0090391F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DisableInMobile_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0601F082 RID: 127106 RVA: 0x00905733 File Offset: 0x00903933
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_DisableInMobile_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601F083 RID: 127107 RVA: 0x00905748 File Offset: 0x00903948
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_DisableInMobile(int EntryPoint)
		{
			BP_DisableInMobile_C.__ExecuteUbergraph_BP_DisableInMobile_FunctionParams* ptr = stackalloc BP_DisableInMobile_C.__ExecuteUbergraph_BP_DisableInMobile_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_DisableInMobile_C.__ExecuteUbergraph_BP_DisableInMobile_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_DisableInMobile_C.__ExecuteUbergraph_BP_DisableInMobile_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_DisableInMobile_C.__ExecuteUbergraph_BP_DisableInMobile_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F084 RID: 127108 RVA: 0x0090578F File Offset: 0x0090398F
		protected BP_DisableInMobile_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400F5A4 RID: 62884
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Sequence/BP_DisableInMobile.BP_DisableInMobile_C";

		// Token: 0x0400F5A5 RID: 62885
		private static IntPtr _ClassPtr;

		// Token: 0x0400F5A6 RID: 62886
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400F5A7 RID: 62887
		internal static int __PropertyOffset_0;

		// Token: 0x0400F5A8 RID: 62888
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400F5A9 RID: 62889
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0400F5AA RID: 62890
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0400F5AB RID: 62891
		private static IntPtr __ExecuteUbergraph_BP_DisableInMobile_NativeFunctionPtr;

		// Token: 0x02009843 RID: 38979
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __ExecuteUbergraph_BP_DisableInMobile_FunctionParams
		{
			// Token: 0x04031E76 RID: 204406
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
