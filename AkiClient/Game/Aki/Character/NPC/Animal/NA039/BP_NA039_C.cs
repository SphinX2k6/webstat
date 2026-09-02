using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.NPC.Animal.CommonBird;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA039
{
	// Token: 0x02004152 RID: 16722
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA039/BP_NA039.BP_NA039_C")]
	[UnrealStructLayout(2240, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2232)]
	public class BP_NA039_C : BP_BaseBird_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C669 RID: 181865 RVA: 0x00AA0288 File Offset: 0x00A9E488
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_NA039_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA039/BP_NA039.BP_NA039_C");
			}
			return BP_NA039_C._ClassPtr;
		}

		// Token: 0x0602C66A RID: 181866 RVA: 0x00AA02AC File Offset: 0x00A9E4AC
		public BP_NA039_C() : this(BuiltinUtils.AllocNativeUObject(BP_NA039_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C66B RID: 181867 RVA: 0x00AA02D4 File Offset: 0x00A9E4D4
		[NullableContext(1)]
		public BP_NA039_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_NA039_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C66C RID: 181868 RVA: 0x00AA0307 File Offset: 0x00A9E507
		protected BP_NA039_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018A6C RID: 100972
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA039/BP_NA039.BP_NA039_C";

		// Token: 0x04018A6D RID: 100973
		private static IntPtr _ClassPtr;

		// Token: 0x04018A6E RID: 100974
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
