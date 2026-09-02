using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Common.DollMachine
{
	// Token: 0x02003AED RID: 15085
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_DollItemsPool.BP_DollItemsPool_C")]
	[UnrealStructLayout(1304, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1304)]
	public class BP_DollItemsPool_C : AKuroBPActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602068B RID: 132747 RVA: 0x0092B314 File Offset: 0x00929514
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_DollItemsPool_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_DollItemsPool.BP_DollItemsPool_C");
			}
			return BP_DollItemsPool_C._ClassPtr;
		}

		// Token: 0x0602068C RID: 132748 RVA: 0x0092B338 File Offset: 0x00929538
		public BP_DollItemsPool_C() : this(BuiltinUtils.AllocNativeUObject(BP_DollItemsPool_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602068D RID: 132749 RVA: 0x0092B360 File Offset: 0x00929560
		[NullableContext(1)]
		public BP_DollItemsPool_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_DollItemsPool_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003580 RID: 13696
		// (get) Token: 0x0602068E RID: 132750 RVA: 0x0092B393 File Offset: 0x00929593
		// (set) Token: 0x0602068F RID: 132751 RVA: 0x0092B3A7 File Offset: 0x009295A7
		[Nullable(2)]
		public unsafe USceneComponent DefaultSceneRoot
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItemsPool_C.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItemsPool_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x06020690 RID: 132752 RVA: 0x0092B3BC File Offset: 0x009295BC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 重置并重分配物品ID()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DollItemsPool_C.__重置并重分配物品ID_NativeFunctionPtr, null);
		}

		// Token: 0x06020691 RID: 132753 RVA: 0x0092B3D0 File Offset: 0x009295D0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 分配物件ID()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DollItemsPool_C.__分配物件ID_NativeFunctionPtr, null);
		}

		// Token: 0x06020692 RID: 132754 RVA: 0x0092B3E4 File Offset: 0x009295E4
		protected BP_DollItemsPool_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401030F RID: 66319
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_DollItemsPool.BP_DollItemsPool_C";

		// Token: 0x04010310 RID: 66320
		private static IntPtr _ClassPtr;

		// Token: 0x04010311 RID: 66321
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04010312 RID: 66322
		internal static int __PropertyOffset_0;

		// Token: 0x04010313 RID: 66323
		private static IntPtr __重置并重分配物品ID_NativeFunctionPtr;

		// Token: 0x04010314 RID: 66324
		private static IntPtr __分配物件ID_NativeFunctionPtr;
	}
}
