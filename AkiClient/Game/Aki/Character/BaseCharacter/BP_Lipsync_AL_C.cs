using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x020041CD RID: 16845
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/BP_Lipsync_AL.BP_Lipsync_AL_C")]
	[UnrealStructLayout(200, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 200)]
	public class BP_Lipsync_AL_C : UActorComponent, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602CCDD RID: 183517 RVA: 0x00AB00EC File Offset: 0x00AAE2EC
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_Lipsync_AL_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/BP_Lipsync_AL.BP_Lipsync_AL_C");
			}
			return BP_Lipsync_AL_C._ClassPtr;
		}

		// Token: 0x0602CCDE RID: 183518 RVA: 0x00AB0110 File Offset: 0x00AAE310
		public BP_Lipsync_AL_C() : this(BuiltinUtils.AllocNativeUObject(BP_Lipsync_AL_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602CCDF RID: 183519 RVA: 0x00AB0138 File Offset: 0x00AAE338
		[NullableContext(1)]
		public BP_Lipsync_AL_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_Lipsync_AL_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602CCE0 RID: 183520 RVA: 0x00AB016B File Offset: 0x00AAE36B
		protected BP_Lipsync_AL_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018F88 RID: 102280
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/BP_Lipsync_AL.BP_Lipsync_AL_C";

		// Token: 0x04018F89 RID: 102281
		private static IntPtr _ClassPtr;

		// Token: 0x04018F8A RID: 102282
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
