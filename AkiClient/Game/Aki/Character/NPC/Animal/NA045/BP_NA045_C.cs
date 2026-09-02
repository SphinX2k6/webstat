using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.NPC.Animal.CommonSmallAnimal;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA045
{
	// Token: 0x02004143 RID: 16707
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA045/BP_NA045.BP_NA045_C")]
	[UnrealStructLayout(2240, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2232)]
	public class BP_NA045_C : BP_CommonSmallAnimal_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C618 RID: 181784 RVA: 0x00A9F6AC File Offset: 0x00A9D8AC
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_NA045_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA045/BP_NA045.BP_NA045_C");
			}
			return BP_NA045_C._ClassPtr;
		}

		// Token: 0x0602C619 RID: 181785 RVA: 0x00A9F6D0 File Offset: 0x00A9D8D0
		public BP_NA045_C() : this(BuiltinUtils.AllocNativeUObject(BP_NA045_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C61A RID: 181786 RVA: 0x00A9F6F8 File Offset: 0x00A9D8F8
		[NullableContext(1)]
		public BP_NA045_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_NA045_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C61B RID: 181787 RVA: 0x00A9F72B File Offset: 0x00A9D92B
		protected BP_NA045_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018A2D RID: 100909
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA045/BP_NA045.BP_NA045_C";

		// Token: 0x04018A2E RID: 100910
		private static IntPtr _ClassPtr;

		// Token: 0x04018A2F RID: 100911
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
