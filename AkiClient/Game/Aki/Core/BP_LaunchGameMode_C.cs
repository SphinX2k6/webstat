using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Core
{
	// Token: 0x02003F34 RID: 16180
	[UnrealObjectPath("/Game/Aki/Core/BP_LaunchGameMode.BP_LaunchGameMode_C")]
	[UnrealStructLayout(1200, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1200)]
	public class BP_LaunchGameMode_C : AGameModeBase, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602865C RID: 165468 RVA: 0x00A094E6 File Offset: 0x00A076E6
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_LaunchGameMode_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Core/BP_LaunchGameMode.BP_LaunchGameMode_C");
			}
			return BP_LaunchGameMode_C._ClassPtr;
		}

		// Token: 0x0602865D RID: 165469 RVA: 0x00A0950C File Offset: 0x00A0770C
		public BP_LaunchGameMode_C() : this(BuiltinUtils.AllocNativeUObject(BP_LaunchGameMode_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602865E RID: 165470 RVA: 0x00A09534 File Offset: 0x00A07734
		[NullableContext(1)]
		public BP_LaunchGameMode_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_LaunchGameMode_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17006224 RID: 25124
		// (get) Token: 0x0602865F RID: 165471 RVA: 0x00A09567 File Offset: 0x00A07767
		// (set) Token: 0x06028660 RID: 165472 RVA: 0x00A0957B File Offset: 0x00A0777B
		[Nullable(2)]
		public unsafe USceneComponent DefaultSceneRoot
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_LaunchGameMode_C.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_LaunchGameMode_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x06028661 RID: 165473 RVA: 0x00A09590 File Offset: 0x00A07790
		protected BP_LaunchGameMode_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040153EC RID: 87020
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Core/BP_LaunchGameMode.BP_LaunchGameMode_C";

		// Token: 0x040153ED RID: 87021
		private static IntPtr _ClassPtr;

		// Token: 0x040153EE RID: 87022
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040153EF RID: 87023
		internal static int __PropertyOffset_0;
	}
}
