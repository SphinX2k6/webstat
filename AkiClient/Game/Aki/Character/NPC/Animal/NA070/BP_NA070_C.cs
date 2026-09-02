using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.NPC.Animal.CommonSmallAnimal;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA070
{
	// Token: 0x020040FF RID: 16639
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA070/BP_NA070.BP_NA070_C")]
	[UnrealStructLayout(2240, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2240)]
	public class BP_NA070_C : BP_CommonSmallAnimal_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C47D RID: 181373 RVA: 0x00A9C1C8 File Offset: 0x00A9A3C8
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_NA070_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA070/BP_NA070.BP_NA070_C");
			}
			return BP_NA070_C._ClassPtr;
		}

		// Token: 0x0602C47E RID: 181374 RVA: 0x00A9C1EC File Offset: 0x00A9A3EC
		public BP_NA070_C() : this(BuiltinUtils.AllocNativeUObject(BP_NA070_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C47F RID: 181375 RVA: 0x00A9C214 File Offset: 0x00A9A414
		[NullableContext(1)]
		public BP_NA070_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_NA070_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007738 RID: 30520
		// (get) Token: 0x0602C480 RID: 181376 RVA: 0x00A9C247 File Offset: 0x00A9A447
		// (set) Token: 0x0602C481 RID: 181377 RVA: 0x00A9C25B File Offset: 0x00A9A45B
		[Nullable(2)]
		public unsafe UKuroAdjustableCapsuleComponent ROOT
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroAdjustableCapsuleComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_NA070_C.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_NA070_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x0602C482 RID: 181378 RVA: 0x00A9C270 File Offset: 0x00A9A470
		protected BP_NA070_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018904 RID: 100612
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA070/BP_NA070.BP_NA070_C";

		// Token: 0x04018905 RID: 100613
		private static IntPtr _ClassPtr;

		// Token: 0x04018906 RID: 100614
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04018907 RID: 100615
		internal new static int __PropertyOffset_0;
	}
}
