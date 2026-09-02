using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Data.CameraShake.Camera.Up
{
	// Token: 0x02004023 RID: 16419
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Up/NCS_Up_Lv1.NCS_Up_Lv1_C")]
	[UnrealStructLayout(464, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 464)]
	public class NCS_Up_Lv1_C : UKuroCameraShake, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602A9F1 RID: 174577 RVA: 0x00A5E498 File Offset: 0x00A5C698
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (NCS_Up_Lv1_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Up/NCS_Up_Lv1.NCS_Up_Lv1_C");
			}
			return NCS_Up_Lv1_C._ClassPtr;
		}

		// Token: 0x0602A9F2 RID: 174578 RVA: 0x00A5E4BC File Offset: 0x00A5C6BC
		public NCS_Up_Lv1_C() : this(BuiltinUtils.AllocNativeUObject(NCS_Up_Lv1_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602A9F3 RID: 174579 RVA: 0x00A5E4E4 File Offset: 0x00A5C6E4
		[NullableContext(1)]
		public NCS_Up_Lv1_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(NCS_Up_Lv1_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602A9F4 RID: 174580 RVA: 0x00A5E517 File Offset: 0x00A5C717
		protected NCS_Up_Lv1_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401730A RID: 94986
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Data/CameraShake/Camera/Up/NCS_Up_Lv1.NCS_Up_Lv1_C";

		// Token: 0x0401730B RID: 94987
		private static IntPtr _ClassPtr;

		// Token: 0x0401730C RID: 94988
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
