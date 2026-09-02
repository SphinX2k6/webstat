using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Core
{
	// Token: 0x02003F39 RID: 16185
	[UnrealObjectPath("/Game/Aki/Core/BP_StartupGameMode.BP_StartupGameMode_C")]
	[UnrealStructLayout(1280, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1280)]
	public class BP_StartupGameMode_C : AGameMode, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602868B RID: 165515 RVA: 0x00A09A62 File Offset: 0x00A07C62
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_StartupGameMode_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Core/BP_StartupGameMode.BP_StartupGameMode_C");
			}
			return BP_StartupGameMode_C._ClassPtr;
		}

		// Token: 0x0602868C RID: 165516 RVA: 0x00A09A88 File Offset: 0x00A07C88
		public BP_StartupGameMode_C() : this(BuiltinUtils.AllocNativeUObject(BP_StartupGameMode_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602868D RID: 165517 RVA: 0x00A09AB0 File Offset: 0x00A07CB0
		[NullableContext(1)]
		public BP_StartupGameMode_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_StartupGameMode_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700622D RID: 25133
		// (get) Token: 0x0602868E RID: 165518 RVA: 0x00A09AE3 File Offset: 0x00A07CE3
		// (set) Token: 0x0602868F RID: 165519 RVA: 0x00A09AF7 File Offset: 0x00A07CF7
		[Nullable(2)]
		public unsafe USceneComponent DefaultSceneRoot
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_StartupGameMode_C.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_StartupGameMode_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x06028690 RID: 165520 RVA: 0x00A09B0C File Offset: 0x00A07D0C
		protected BP_StartupGameMode_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401540D RID: 87053
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Core/BP_StartupGameMode.BP_StartupGameMode_C";

		// Token: 0x0401540E RID: 87054
		private static IntPtr _ClassPtr;

		// Token: 0x0401540F RID: 87055
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04015410 RID: 87056
		internal static int __PropertyOffset_0;
	}
}
