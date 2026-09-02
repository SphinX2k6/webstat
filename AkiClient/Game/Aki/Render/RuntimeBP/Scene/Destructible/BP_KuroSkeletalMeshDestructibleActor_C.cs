using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Destructible
{
	// Token: 0x02003AD6 RID: 15062
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Destructible/BP_KuroSkeletalMeshDestructibleActor.BP_KuroSkeletalMeshDestructibleActor_C")]
	[UnrealStructLayout(1392, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1392)]
	public class BP_KuroSkeletalMeshDestructibleActor_C : AKuroDestructibleActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06020388 RID: 131976 RVA: 0x00925B5D File Offset: 0x00923D5D
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_KuroSkeletalMeshDestructibleActor_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Destructible/BP_KuroSkeletalMeshDestructibleActor.BP_KuroSkeletalMeshDestructibleActor_C");
			}
			return BP_KuroSkeletalMeshDestructibleActor_C._ClassPtr;
		}

		// Token: 0x06020389 RID: 131977 RVA: 0x00925B84 File Offset: 0x00923D84
		public BP_KuroSkeletalMeshDestructibleActor_C() : this(BuiltinUtils.AllocNativeUObject(BP_KuroSkeletalMeshDestructibleActor_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602038A RID: 131978 RVA: 0x00925BAC File Offset: 0x00923DAC
		[NullableContext(1)]
		public BP_KuroSkeletalMeshDestructibleActor_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_KuroSkeletalMeshDestructibleActor_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602038B RID: 131979 RVA: 0x00925BDF File Offset: 0x00923DDF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 显示或隐藏破碎时渲染模型()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroSkeletalMeshDestructibleActor_C.__显示或隐藏破碎时渲染模型_NativeFunctionPtr, null);
		}

		// Token: 0x0602038C RID: 131980 RVA: 0x00925BF3 File Offset: 0x00923DF3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 显示或隐藏所有的物理模拟碎块()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroSkeletalMeshDestructibleActor_C.__显示或隐藏所有的物理模拟碎块_NativeFunctionPtr, null);
		}

		// Token: 0x0602038D RID: 131981 RVA: 0x00925C07 File Offset: 0x00923E07
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 显示或隐藏代理静态模型()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroSkeletalMeshDestructibleActor_C.__显示或隐藏代理静态模型_NativeFunctionPtr, null);
		}

		// Token: 0x0602038E RID: 131982 RVA: 0x00925C1B File Offset: 0x00923E1B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 编辑时预览破碎效果()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroSkeletalMeshDestructibleActor_C.__编辑时预览破碎效果_NativeFunctionPtr, null);
		}

		// Token: 0x0602038F RID: 131983 RVA: 0x00925C2F File Offset: 0x00923E2F
		protected BP_KuroSkeletalMeshDestructibleActor_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04010112 RID: 65810
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Destructible/BP_KuroSkeletalMeshDestructibleActor.BP_KuroSkeletalMeshDestructibleActor_C";

		// Token: 0x04010113 RID: 65811
		private static IntPtr _ClassPtr;

		// Token: 0x04010114 RID: 65812
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04010115 RID: 65813
		private static IntPtr __显示或隐藏破碎时渲染模型_NativeFunctionPtr;

		// Token: 0x04010116 RID: 65814
		private static IntPtr __显示或隐藏所有的物理模拟碎块_NativeFunctionPtr;

		// Token: 0x04010117 RID: 65815
		private static IntPtr __显示或隐藏代理静态模型_NativeFunctionPtr;

		// Token: 0x04010118 RID: 65816
		private static IntPtr __编辑时预览破碎效果_NativeFunctionPtr;
	}
}
