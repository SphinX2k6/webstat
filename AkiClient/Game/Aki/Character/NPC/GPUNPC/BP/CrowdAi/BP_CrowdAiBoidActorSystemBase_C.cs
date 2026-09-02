using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.GPUNPC.BP.CrowdAi
{
	// Token: 0x020040E4 RID: 16612
	[UnrealObjectPath("/Game/Aki/Character/NPC/GPUNPC/BP/CrowdAi/BP_CrowdAiBoidActorSystemBase.BP_CrowdAiBoidActorSystemBase_C")]
	[UnrealStructLayout(2608, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2600)]
	public class BP_CrowdAiBoidActorSystemBase_C : AKuroCrowdAiBoidActorSystem, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602BC43 RID: 179267 RVA: 0x00A88908 File Offset: 0x00A86B08
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_CrowdAiBoidActorSystemBase_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/GPUNPC/BP/CrowdAi/BP_CrowdAiBoidActorSystemBase.BP_CrowdAiBoidActorSystemBase_C");
			}
			return BP_CrowdAiBoidActorSystemBase_C._ClassPtr;
		}

		// Token: 0x0602BC44 RID: 179268 RVA: 0x00A8892C File Offset: 0x00A86B2C
		public BP_CrowdAiBoidActorSystemBase_C() : this(BuiltinUtils.AllocNativeUObject(BP_CrowdAiBoidActorSystemBase_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602BC45 RID: 179269 RVA: 0x00A88954 File Offset: 0x00A86B54
		[NullableContext(1)]
		public BP_CrowdAiBoidActorSystemBase_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_CrowdAiBoidActorSystemBase_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700740A RID: 29706
		// (get) Token: 0x0602BC46 RID: 179270 RVA: 0x00A88987 File Offset: 0x00A86B87
		// (set) Token: 0x0602BC47 RID: 179271 RVA: 0x00A8899B File Offset: 0x00A86B9B
		[Nullable(2)]
		public unsafe GPUNPCData_C Data
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<GPUNPCData_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CrowdAiBoidActorSystemBase_C.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CrowdAiBoidActorSystemBase_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x0602BC48 RID: 179272 RVA: 0x00A889B0 File Offset: 0x00A86BB0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override bool InitGpuNpc()
		{
			BP_CrowdAiBoidActorSystemBase_C.__InitGpuNpc_FunctionParams* ptr = stackalloc BP_CrowdAiBoidActorSystemBase_C.__InitGpuNpc_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_CrowdAiBoidActorSystemBase_C.__InitGpuNpc_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CrowdAiBoidActorSystemBase_C.__InitGpuNpc_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CrowdAiBoidActorSystemBase_C.__InitGpuNpc_NativeFunctionPtr, (void*)ptr);
			return ptr->__Result;
		}

		// Token: 0x0602BC49 RID: 179273 RVA: 0x00A889F8 File Offset: 0x00A86BF8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override bool InitGpuNpc_Implementation()
		{
			BP_CrowdAiBoidActorSystemBase_C.__InitGpuNpc_FunctionParams* ptr = stackalloc BP_CrowdAiBoidActorSystemBase_C.__InitGpuNpc_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_CrowdAiBoidActorSystemBase_C.__InitGpuNpc_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CrowdAiBoidActorSystemBase_C.__InitGpuNpc_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CrowdAiBoidActorSystemBase_C.__InitGpuNpc_NativeFunctionPtr, (void*)ptr, 0);
			return ptr->__Result;
		}

		// Token: 0x0602BC4A RID: 179274 RVA: 0x00A88A3E File Offset: 0x00A86C3E
		protected BP_CrowdAiBoidActorSystemBase_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040181CD RID: 98765
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/GPUNPC/BP/CrowdAi/BP_CrowdAiBoidActorSystemBase.BP_CrowdAiBoidActorSystemBase_C";

		// Token: 0x040181CE RID: 98766
		private static IntPtr _ClassPtr;

		// Token: 0x040181CF RID: 98767
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040181D0 RID: 98768
		internal static int __PropertyOffset_0;

		// Token: 0x040181D1 RID: 98769
		private static IntPtr __InitGpuNpc_NativeFunctionPtr;

		// Token: 0x0200A3D3 RID: 41939
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected new ref struct __InitGpuNpc_FunctionParams
		{
			// Token: 0x040331C0 RID: 209344
			[FieldOffset(0)]
			public bool __Result;
		}
	}
}
