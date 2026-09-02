using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Weather.BP.Thunder
{
	// Token: 0x02003A00 RID: 14848
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Weather/BP/Thunder/BP_LighteningConductor.BP_LighteningConductor_C")]
	[UnrealStructLayout(1032, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1032)]
	public class BP_LighteningConductor_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601E3E7 RID: 123879 RVA: 0x008F08B8 File Offset: 0x008EEAB8
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_LighteningConductor_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Weather/BP/Thunder/BP_LighteningConductor.BP_LighteningConductor_C");
			}
			return BP_LighteningConductor_C._ClassPtr;
		}

		// Token: 0x0601E3E8 RID: 123880 RVA: 0x008F08DC File Offset: 0x008EEADC
		public BP_LighteningConductor_C() : this(BuiltinUtils.AllocNativeUObject(BP_LighteningConductor_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601E3E9 RID: 123881 RVA: 0x008F0904 File Offset: 0x008EEB04
		[NullableContext(1)]
		public BP_LighteningConductor_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_LighteningConductor_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17002929 RID: 10537
		// (get) Token: 0x0601E3EA RID: 123882 RVA: 0x008F0937 File Offset: 0x008EEB37
		// (set) Token: 0x0601E3EB RID: 123883 RVA: 0x008F094B File Offset: 0x008EEB4B
		[Nullable(2)]
		public unsafe USceneComponent DefaultSceneRoot
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_LighteningConductor_C.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_LighteningConductor_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x0601E3EC RID: 123884 RVA: 0x008F0960 File Offset: 0x008EEB60
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Thunder()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LighteningConductor_C.__Thunder_NativeFunctionPtr, null);
		}

		// Token: 0x0601E3ED RID: 123885 RVA: 0x008F0974 File Offset: 0x008EEB74
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Lightening()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LighteningConductor_C.__Lightening_NativeFunctionPtr, null);
		}

		// Token: 0x0601E3EE RID: 123886 RVA: 0x008F0988 File Offset: 0x008EEB88
		protected BP_LighteningConductor_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400EDE6 RID: 60902
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Weather/BP/Thunder/BP_LighteningConductor.BP_LighteningConductor_C";

		// Token: 0x0400EDE7 RID: 60903
		private static IntPtr _ClassPtr;

		// Token: 0x0400EDE8 RID: 60904
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400EDE9 RID: 60905
		internal static int __PropertyOffset_0;

		// Token: 0x0400EDEA RID: 60906
		private static IntPtr __Thunder_NativeFunctionPtr;

		// Token: 0x0400EDEB RID: 60907
		private static IntPtr __Lightening_NativeFunctionPtr;
	}
}
