using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.NPC.Common;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA062
{
	// Token: 0x0200411C RID: 16668
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA062/BP_NA062_NPC.BP_NA062_NPC_C")]
	[UnrealStructLayout(2336, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2328)]
	public class BP_NA062_NPC_C : BP_BaseNPC_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C533 RID: 181555 RVA: 0x00A9D8E8 File Offset: 0x00A9BAE8
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_NA062_NPC_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA062/BP_NA062_NPC.BP_NA062_NPC_C");
			}
			return BP_NA062_NPC_C._ClassPtr;
		}

		// Token: 0x0602C534 RID: 181556 RVA: 0x00A9D90C File Offset: 0x00A9BB0C
		public BP_NA062_NPC_C() : this(BuiltinUtils.AllocNativeUObject(BP_NA062_NPC_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C535 RID: 181557 RVA: 0x00A9D934 File Offset: 0x00A9BB34
		[NullableContext(1)]
		public BP_NA062_NPC_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_NA062_NPC_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007750 RID: 30544
		// (get) Token: 0x0602C536 RID: 181558 RVA: 0x00A9D967 File Offset: 0x00A9BB67
		// (set) Token: 0x0602C537 RID: 181559 RVA: 0x00A9D97B File Offset: 0x00A9BB7B
		[Nullable(2)]
		public unsafe UKuroAdjustableCapsuleComponent ROOT
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroAdjustableCapsuleComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_NA062_NPC_C.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_NA062_NPC_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x0602C538 RID: 181560 RVA: 0x00A9D990 File Offset: 0x00A9BB90
		protected BP_NA062_NPC_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018985 RID: 100741
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA062/BP_NA062_NPC.BP_NA062_NPC_C";

		// Token: 0x04018986 RID: 100742
		private static IntPtr _ClassPtr;

		// Token: 0x04018987 RID: 100743
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04018988 RID: 100744
		internal new static int __PropertyOffset_0;
	}
}
