using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Common.DollMachine
{
	// Token: 0x02003AEC RID: 15084
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_DollGrabMahcineConveyorBelt.BP_DollGrabMahcineConveyorBelt_C")]
	[UnrealStructLayout(1416, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1416)]
	public class BP_DollGrabMahcineConveyorBelt_C : AKuroSplineConveyorBelt, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06020684 RID: 132740 RVA: 0x0092B24F File Offset: 0x0092944F
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_DollGrabMahcineConveyorBelt_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_DollGrabMahcineConveyorBelt.BP_DollGrabMahcineConveyorBelt_C");
			}
			return BP_DollGrabMahcineConveyorBelt_C._ClassPtr;
		}

		// Token: 0x06020685 RID: 132741 RVA: 0x0092B274 File Offset: 0x00929474
		public BP_DollGrabMahcineConveyorBelt_C() : this(BuiltinUtils.AllocNativeUObject(BP_DollGrabMahcineConveyorBelt_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06020686 RID: 132742 RVA: 0x0092B29C File Offset: 0x0092949C
		[NullableContext(1)]
		public BP_DollGrabMahcineConveyorBelt_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_DollGrabMahcineConveyorBelt_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x06020687 RID: 132743 RVA: 0x0092B2CF File Offset: 0x009294CF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Close()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DollGrabMahcineConveyorBelt_C.__Close_NativeFunctionPtr, null);
		}

		// Token: 0x06020688 RID: 132744 RVA: 0x0092B2E3 File Offset: 0x009294E3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Open()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DollGrabMahcineConveyorBelt_C.__Open_NativeFunctionPtr, null);
		}

		// Token: 0x06020689 RID: 132745 RVA: 0x0092B2F7 File Offset: 0x009294F7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void GenerateTriggerMesh()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DollGrabMahcineConveyorBelt_C.__GenerateTriggerMesh_NativeFunctionPtr, null);
		}

		// Token: 0x0602068A RID: 132746 RVA: 0x0092B30B File Offset: 0x0092950B
		protected BP_DollGrabMahcineConveyorBelt_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04010309 RID: 66313
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_DollGrabMahcineConveyorBelt.BP_DollGrabMahcineConveyorBelt_C";

		// Token: 0x0401030A RID: 66314
		private static IntPtr _ClassPtr;

		// Token: 0x0401030B RID: 66315
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401030C RID: 66316
		private static IntPtr __Close_NativeFunctionPtr;

		// Token: 0x0401030D RID: 66317
		private static IntPtr __Open_NativeFunctionPtr;

		// Token: 0x0401030E RID: 66318
		private static IntPtr __GenerateTriggerMesh_NativeFunctionPtr;
	}
}
