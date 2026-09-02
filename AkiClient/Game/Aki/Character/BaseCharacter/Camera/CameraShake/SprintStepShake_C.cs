using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Camera.CameraShake
{
	// Token: 0x0200432C RID: 17196
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Camera/CameraShake/SprintStepShake.SprintStepShake_C")]
	[UnrealStructLayout(416, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 416)]
	public class SprintStepShake_C : UMatineeCameraShake, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602D9E9 RID: 186857 RVA: 0x00AC4B6A File Offset: 0x00AC2D6A
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (SprintStepShake_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/Camera/CameraShake/SprintStepShake.SprintStepShake_C");
			}
			return SprintStepShake_C._ClassPtr;
		}

		// Token: 0x0602D9EA RID: 186858 RVA: 0x00AC4B90 File Offset: 0x00AC2D90
		public SprintStepShake_C() : this(BuiltinUtils.AllocNativeUObject(SprintStepShake_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602D9EB RID: 186859 RVA: 0x00AC4BB8 File Offset: 0x00AC2DB8
		[NullableContext(1)]
		public SprintStepShake_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(SprintStepShake_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602D9EC RID: 186860 RVA: 0x00AC4BEB File Offset: 0x00AC2DEB
		protected SprintStepShake_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019B81 RID: 105345
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/Camera/CameraShake/SprintStepShake.SprintStepShake_C";

		// Token: 0x04019B82 RID: 105346
		private static IntPtr _ClassPtr;

		// Token: 0x04019B83 RID: 105347
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
