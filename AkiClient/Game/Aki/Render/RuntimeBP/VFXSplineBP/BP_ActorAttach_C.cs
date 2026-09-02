using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.VFXSplineBP
{
	// Token: 0x02003A0F RID: 14863
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/VFXSplineBP/BP_ActorAttach.BP_ActorAttach_C")]
	[UnrealStructLayout(1032, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1032)]
	public class BP_ActorAttach_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601E610 RID: 124432 RVA: 0x008F44E7 File Offset: 0x008F26E7
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_ActorAttach_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/VFXSplineBP/BP_ActorAttach.BP_ActorAttach_C");
			}
			return BP_ActorAttach_C._ClassPtr;
		}

		// Token: 0x0601E611 RID: 124433 RVA: 0x008F450C File Offset: 0x008F270C
		public BP_ActorAttach_C() : this(BuiltinUtils.AllocNativeUObject(BP_ActorAttach_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601E612 RID: 124434 RVA: 0x008F4534 File Offset: 0x008F2734
		[NullableContext(1)]
		public BP_ActorAttach_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_ActorAttach_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170029EF RID: 10735
		// (get) Token: 0x0601E613 RID: 124435 RVA: 0x008F4567 File Offset: 0x008F2767
		// (set) Token: 0x0601E614 RID: 124436 RVA: 0x008F457B File Offset: 0x008F277B
		[Nullable(2)]
		public unsafe USceneComponent DefaultSceneRoot
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_ActorAttach_C.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_ActorAttach_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x0601E615 RID: 124437 RVA: 0x008F4590 File Offset: 0x008F2790
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void GetActorPosition()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ActorAttach_C.__GetActorPosition_NativeFunctionPtr, null);
		}

		// Token: 0x0601E616 RID: 124438 RVA: 0x008F45A4 File Offset: 0x008F27A4
		protected BP_ActorAttach_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400EF33 RID: 61235
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/VFXSplineBP/BP_ActorAttach.BP_ActorAttach_C";

		// Token: 0x0400EF34 RID: 61236
		private static IntPtr _ClassPtr;

		// Token: 0x0400EF35 RID: 61237
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400EF36 RID: 61238
		internal static int __PropertyOffset_0;

		// Token: 0x0400EF37 RID: 61239
		private static IntPtr __GetActorPosition_NativeFunctionPtr;
	}
}
