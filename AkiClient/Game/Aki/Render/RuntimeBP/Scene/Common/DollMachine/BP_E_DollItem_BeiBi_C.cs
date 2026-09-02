using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Common.DollMachine
{
	// Token: 0x02003B18 RID: 15128
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_E_DollItem_BeiBi.BP_E_DollItem_BeiBi_C")]
	[UnrealStructLayout(1544, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1544)]
	public class BP_E_DollItem_BeiBi_C : BP_DollActor_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602083C RID: 133180 RVA: 0x0092E395 File Offset: 0x0092C595
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_E_DollItem_BeiBi_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_E_DollItem_BeiBi.BP_E_DollItem_BeiBi_C");
			}
			return BP_E_DollItem_BeiBi_C._ClassPtr;
		}

		// Token: 0x0602083D RID: 133181 RVA: 0x0092E3BC File Offset: 0x0092C5BC
		public BP_E_DollItem_BeiBi_C() : this(BuiltinUtils.AllocNativeUObject(BP_E_DollItem_BeiBi_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602083E RID: 133182 RVA: 0x0092E3E4 File Offset: 0x0092C5E4
		public BP_E_DollItem_BeiBi_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_E_DollItem_BeiBi_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170035F1 RID: 13809
		// (get) Token: 0x0602083F RID: 133183 RVA: 0x0092E418 File Offset: 0x0092C618
		// (set) Token: 0x06020840 RID: 133184 RVA: 0x0092E451 File Offset: 0x0092C651
		public new FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_E_DollItem_BeiBi_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_E_DollItem_BeiBi_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x06020841 RID: 133185 RVA: 0x0092E472 File Offset: 0x0092C672
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_E_DollItem_BeiBi_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06020842 RID: 133186 RVA: 0x0092E486 File Offset: 0x0092C686
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_E_DollItem_BeiBi_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06020843 RID: 133187 RVA: 0x0092E49C File Offset: 0x0092C69C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_E_DollItem_BeiBi(int EntryPoint)
		{
			BP_E_DollItem_BeiBi_C.__ExecuteUbergraph_BP_E_DollItem_BeiBi_FunctionParams* ptr = stackalloc BP_E_DollItem_BeiBi_C.__ExecuteUbergraph_BP_E_DollItem_BeiBi_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_E_DollItem_BeiBi_C.__ExecuteUbergraph_BP_E_DollItem_BeiBi_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_E_DollItem_BeiBi_C.__ExecuteUbergraph_BP_E_DollItem_BeiBi_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_E_DollItem_BeiBi_C.__ExecuteUbergraph_BP_E_DollItem_BeiBi_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06020844 RID: 133188 RVA: 0x0092E4E3 File Offset: 0x0092C6E3
		protected BP_E_DollItem_BeiBi_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04010423 RID: 66595
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_E_DollItem_BeiBi.BP_E_DollItem_BeiBi_C";

		// Token: 0x04010424 RID: 66596
		private static IntPtr _ClassPtr;

		// Token: 0x04010425 RID: 66597
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04010426 RID: 66598
		internal new static int __PropertyOffset_0;

		// Token: 0x04010427 RID: 66599
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04010428 RID: 66600
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04010429 RID: 66601
		private static IntPtr __ExecuteUbergraph_BP_E_DollItem_BeiBi_NativeFunctionPtr;

		// Token: 0x020099C3 RID: 39363
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __ExecuteUbergraph_BP_E_DollItem_BeiBi_FunctionParams
		{
			// Token: 0x04032066 RID: 204902
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
