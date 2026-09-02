using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Common.DollMachine
{
	// Token: 0x02003B08 RID: 15112
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_DollItem_BeiBi.BP_DollItem_BeiBi_C")]
	[UnrealStructLayout(1552, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1552)]
	public class BP_DollItem_BeiBi_C : BP_DollActor_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06020775 RID: 132981 RVA: 0x0092CD87 File Offset: 0x0092AF87
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_DollItem_BeiBi_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_DollItem_BeiBi.BP_DollItem_BeiBi_C");
			}
			return BP_DollItem_BeiBi_C._ClassPtr;
		}

		// Token: 0x06020776 RID: 132982 RVA: 0x0092CDAC File Offset: 0x0092AFAC
		public BP_DollItem_BeiBi_C() : this(BuiltinUtils.AllocNativeUObject(BP_DollItem_BeiBi_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06020777 RID: 132983 RVA: 0x0092CDD4 File Offset: 0x0092AFD4
		public BP_DollItem_BeiBi_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_DollItem_BeiBi_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170035B8 RID: 13752
		// (get) Token: 0x06020778 RID: 132984 RVA: 0x0092CE08 File Offset: 0x0092B008
		// (set) Token: 0x06020779 RID: 132985 RVA: 0x0092CE41 File Offset: 0x0092B041
		public new FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_DollItem_BeiBi_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_DollItem_BeiBi_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170035B9 RID: 13753
		// (get) Token: 0x0602077A RID: 132986 RVA: 0x0092CE62 File Offset: 0x0092B062
		// (set) Token: 0x0602077B RID: 132987 RVA: 0x0092CE76 File Offset: 0x0092B076
		[Nullable(2)]
		public unsafe UPointLightComponent PointLight
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UPointLightComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_BeiBi_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_BeiBi_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x0602077C RID: 132988 RVA: 0x0092CE8B File Offset: 0x0092B08B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DollItem_BeiBi_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0602077D RID: 132989 RVA: 0x0092CE9F File Offset: 0x0092B09F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_DollItem_BeiBi_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602077E RID: 132990 RVA: 0x0092CEB4 File Offset: 0x0092B0B4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_DollItem_BeiBi(int EntryPoint)
		{
			BP_DollItem_BeiBi_C.__ExecuteUbergraph_BP_DollItem_BeiBi_FunctionParams* ptr = stackalloc BP_DollItem_BeiBi_C.__ExecuteUbergraph_BP_DollItem_BeiBi_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_DollItem_BeiBi_C.__ExecuteUbergraph_BP_DollItem_BeiBi_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_DollItem_BeiBi_C.__ExecuteUbergraph_BP_DollItem_BeiBi_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_DollItem_BeiBi_C.__ExecuteUbergraph_BP_DollItem_BeiBi_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602077F RID: 132991 RVA: 0x0092CEFB File Offset: 0x0092B0FB
		protected BP_DollItem_BeiBi_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040103A6 RID: 66470
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_DollItem_BeiBi.BP_DollItem_BeiBi_C";

		// Token: 0x040103A7 RID: 66471
		private static IntPtr _ClassPtr;

		// Token: 0x040103A8 RID: 66472
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040103A9 RID: 66473
		internal new static int __PropertyOffset_0;

		// Token: 0x040103AA RID: 66474
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040103AB RID: 66475
		internal new static int __PropertyOffset_1;

		// Token: 0x040103AC RID: 66476
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x040103AD RID: 66477
		private static IntPtr __ExecuteUbergraph_BP_DollItem_BeiBi_NativeFunctionPtr;

		// Token: 0x020099BC RID: 39356
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __ExecuteUbergraph_BP_DollItem_BeiBi_FunctionParams
		{
			// Token: 0x0403205E RID: 204894
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
