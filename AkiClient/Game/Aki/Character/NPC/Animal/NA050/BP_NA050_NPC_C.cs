using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.NPC.Common;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA050
{
	// Token: 0x02004139 RID: 16697
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA050/BP_NA050_NPC.BP_NA050_NPC_C")]
	[UnrealStructLayout(2320, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2314)]
	public class BP_NA050_NPC_C : BP_BaseNPC_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C5F0 RID: 181744 RVA: 0x00A9F15C File Offset: 0x00A9D35C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_NA050_NPC_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA050/BP_NA050_NPC.BP_NA050_NPC_C");
			}
			return BP_NA050_NPC_C._ClassPtr;
		}

		// Token: 0x0602C5F1 RID: 181745 RVA: 0x00A9F180 File Offset: 0x00A9D380
		public BP_NA050_NPC_C() : this(BuiltinUtils.AllocNativeUObject(BP_NA050_NPC_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C5F2 RID: 181746 RVA: 0x00A9F1A8 File Offset: 0x00A9D3A8
		[NullableContext(1)]
		public BP_NA050_NPC_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_NA050_NPC_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C5F3 RID: 181747 RVA: 0x00A9F1DB File Offset: 0x00A9D3DB
		protected BP_NA050_NPC_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018A0F RID: 100879
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA050/BP_NA050_NPC.BP_NA050_NPC_C";

		// Token: 0x04018A10 RID: 100880
		private static IntPtr _ClassPtr;

		// Token: 0x04018A11 RID: 100881
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
