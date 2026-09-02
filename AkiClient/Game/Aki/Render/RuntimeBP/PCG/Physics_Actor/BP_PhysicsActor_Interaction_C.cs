using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Core.Fight;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.Physics_Actor
{
	// Token: 0x02003BA7 RID: 15271
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/Physics_Actor/BP_PhysicsActor_Interaction.BP_PhysicsActor_Interaction_C")]
	[UnrealStructLayout(1368, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1368)]
	public class BP_PhysicsActor_Interaction_C : AKuroPhysicActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06021F78 RID: 139128 RVA: 0x00958970 File Offset: 0x00956B70
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_PhysicsActor_Interaction_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/Physics_Actor/BP_PhysicsActor_Interaction.BP_PhysicsActor_Interaction_C");
			}
			return BP_PhysicsActor_Interaction_C._ClassPtr;
		}

		// Token: 0x06021F79 RID: 139129 RVA: 0x00958994 File Offset: 0x00956B94
		public BP_PhysicsActor_Interaction_C() : this(BuiltinUtils.AllocNativeUObject(BP_PhysicsActor_Interaction_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06021F7A RID: 139130 RVA: 0x009589BC File Offset: 0x00956BBC
		[NullableContext(1)]
		public BP_PhysicsActor_Interaction_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_PhysicsActor_Interaction_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003DFA RID: 15866
		// (get) Token: 0x06021F7B RID: 139131 RVA: 0x009589F0 File Offset: 0x00956BF0
		// (set) Token: 0x06021F7C RID: 139132 RVA: 0x00958A29 File Offset: 0x00956C29
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_PhysicsActor_Interaction_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_PhysicsActor_Interaction_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003DFB RID: 15867
		// (get) Token: 0x06021F7D RID: 139133 RVA: 0x00958A4A File Offset: 0x00956C4A
		// (set) Token: 0x06021F7E RID: 139134 RVA: 0x00958A5E File Offset: 0x00956C5E
		public unsafe UStaticMeshComponent StaticMesh_0
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PhysicsActor_Interaction_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PhysicsActor_Interaction_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17003DFC RID: 15868
		// (get) Token: 0x06021F7F RID: 139135 RVA: 0x00958A73 File Offset: 0x00956C73
		// (set) Token: 0x06021F80 RID: 139136 RVA: 0x00958A87 File Offset: 0x00956C87
		public unsafe BP_SceneBattleInteract_C Config
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_SceneBattleInteract_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PhysicsActor_Interaction_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PhysicsActor_Interaction_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17003DFD RID: 15869
		// (get) Token: 0x06021F81 RID: 139137 RVA: 0x00958A9C File Offset: 0x00956C9C
		// (set) Token: 0x06021F82 RID: 139138 RVA: 0x00958AB0 File Offset: 0x00956CB0
		public unsafe FVectorDouble PrePosition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PhysicsActor_Interaction_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PhysicsActor_Interaction_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17003DFE RID: 15870
		// (get) Token: 0x06021F83 RID: 139139 RVA: 0x00958AC5 File Offset: 0x00956CC5
		// (set) Token: 0x06021F84 RID: 139140 RVA: 0x00958AD5 File Offset: 0x00956CD5
		public unsafe float Impulse
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PhysicsActor_Interaction_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PhysicsActor_Interaction_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17003DFF RID: 15871
		// (get) Token: 0x06021F85 RID: 139141 RVA: 0x00958AE6 File Offset: 0x00956CE6
		// (set) Token: 0x06021F86 RID: 139142 RVA: 0x00958AFA File Offset: 0x00956CFA
		public unsafe FVector WeaponImpulse
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PhysicsActor_Interaction_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PhysicsActor_Interaction_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x06021F87 RID: 139143 RVA: 0x00958B0F File Offset: 0x00956D0F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PhysicsActor_Interaction_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06021F88 RID: 139144 RVA: 0x00958B23 File Offset: 0x00956D23
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_PhysicsActor_Interaction_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06021F89 RID: 139145 RVA: 0x00958B38 File Offset: 0x00956D38
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void OnLogicDisable()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PhysicsActor_Interaction_C.__OnLogicDisable_NativeFunctionPtr, null);
		}

		// Token: 0x06021F8A RID: 139146 RVA: 0x00958B4C File Offset: 0x00956D4C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void OnLogicDisable_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_PhysicsActor_Interaction_C.__OnLogicDisable_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06021F8B RID: 139147 RVA: 0x00958B61 File Offset: 0x00956D61
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void OnLogicEnable()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PhysicsActor_Interaction_C.__OnLogicEnable_NativeFunctionPtr, null);
		}

		// Token: 0x06021F8C RID: 139148 RVA: 0x00958B75 File Offset: 0x00956D75
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void OnLogicEnable_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_PhysicsActor_Interaction_C.__OnLogicEnable_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06021F8D RID: 139149 RVA: 0x00958B8C File Offset: 0x00956D8C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OnWeaponInteraction(FVectorDouble OriginPoint, BP_SceneBattleInteract_C Config, int Id)
		{
			BP_PhysicsActor_Interaction_C.__OnWeaponInteraction_FunctionParams* ptr = stackalloc BP_PhysicsActor_Interaction_C.__OnWeaponInteraction_FunctionParams[(UIntPtr)55] + 15L / (long)sizeof(BP_PhysicsActor_Interaction_C.__OnWeaponInteraction_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_PhysicsActor_Interaction_C.__OnWeaponInteraction_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OriginPoint = OriginPoint;
			ptr->Config = ((Config != null) ? Config.NativePtr : IntPtr.Zero);
			ptr->Id = Id;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PhysicsActor_Interaction_C.__OnWeaponInteraction_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021F8E RID: 139150 RVA: 0x00958BF0 File Offset: 0x00956DF0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_PhysicsActor_Interaction(int EntryPoint)
		{
			BP_PhysicsActor_Interaction_C.__ExecuteUbergraph_BP_PhysicsActor_Interaction_FunctionParams* ptr = stackalloc BP_PhysicsActor_Interaction_C.__ExecuteUbergraph_BP_PhysicsActor_Interaction_FunctionParams[(UIntPtr)263] + 15L / (long)sizeof(BP_PhysicsActor_Interaction_C.__ExecuteUbergraph_BP_PhysicsActor_Interaction_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_PhysicsActor_Interaction_C.__ExecuteUbergraph_BP_PhysicsActor_Interaction_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_PhysicsActor_Interaction_C.__ExecuteUbergraph_BP_PhysicsActor_Interaction_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06021F8F RID: 139151 RVA: 0x00958C3A File Offset: 0x00956E3A
		protected BP_PhysicsActor_Interaction_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401127A RID: 70266
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/Physics_Actor/BP_PhysicsActor_Interaction.BP_PhysicsActor_Interaction_C";

		// Token: 0x0401127B RID: 70267
		private static IntPtr _ClassPtr;

		// Token: 0x0401127C RID: 70268
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401127D RID: 70269
		internal static int __PropertyOffset_0;

		// Token: 0x0401127E RID: 70270
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0401127F RID: 70271
		internal static int __PropertyOffset_1;

		// Token: 0x04011280 RID: 70272
		internal static int __PropertyOffset_2;

		// Token: 0x04011281 RID: 70273
		internal static int __PropertyOffset_3;

		// Token: 0x04011282 RID: 70274
		internal static int __PropertyOffset_4;

		// Token: 0x04011283 RID: 70275
		internal static int __PropertyOffset_5;

		// Token: 0x04011284 RID: 70276
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04011285 RID: 70277
		private static IntPtr __OnLogicDisable_NativeFunctionPtr;

		// Token: 0x04011286 RID: 70278
		private static IntPtr __OnLogicEnable_NativeFunctionPtr;

		// Token: 0x04011287 RID: 70279
		private static IntPtr __OnWeaponInteraction_NativeFunctionPtr;

		// Token: 0x04011288 RID: 70280
		private static IntPtr __ExecuteUbergraph_BP_PhysicsActor_Interaction_NativeFunctionPtr;

		// Token: 0x02009B7E RID: 39806
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 40)]
		protected ref struct __OnWeaponInteraction_FunctionParams
		{
			// Token: 0x04032375 RID: 205685
			[FieldOffset(0)]
			public FVectorDouble OriginPoint;

			// Token: 0x04032376 RID: 205686
			[FieldOffset(24)]
			public IntPtr Config;

			// Token: 0x04032377 RID: 205687
			[FieldOffset(32)]
			public int Id;
		}

		// Token: 0x02009B7F RID: 39807
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 248)]
		protected ref struct __ExecuteUbergraph_BP_PhysicsActor_Interaction_FunctionParams
		{
			// Token: 0x04032378 RID: 205688
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
