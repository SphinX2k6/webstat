using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Camera
{
	// Token: 0x020042EA RID: 17130
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Camera/BP_Fx_Yangyang_Atk_51.BP_Fx_Yangyang_Atk_51_C")]
	[UnrealStructLayout(416, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 416)]
	public class BP_Fx_Yangyang_Atk_51_C : UMatineeCameraShake, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602D70A RID: 186122 RVA: 0x00AC03F7 File Offset: 0x00ABE5F7
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_Fx_Yangyang_Atk_51_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/Camera/BP_Fx_Yangyang_Atk_51.BP_Fx_Yangyang_Atk_51_C");
			}
			return BP_Fx_Yangyang_Atk_51_C._ClassPtr;
		}

		// Token: 0x0602D70B RID: 186123 RVA: 0x00AC041C File Offset: 0x00ABE61C
		public BP_Fx_Yangyang_Atk_51_C() : this(BuiltinUtils.AllocNativeUObject(BP_Fx_Yangyang_Atk_51_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602D70C RID: 186124 RVA: 0x00AC0444 File Offset: 0x00ABE644
		[NullableContext(1)]
		public BP_Fx_Yangyang_Atk_51_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_Fx_Yangyang_Atk_51_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602D70D RID: 186125 RVA: 0x00AC0477 File Offset: 0x00ABE677
		protected BP_Fx_Yangyang_Atk_51_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040197DB RID: 104411
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/Camera/BP_Fx_Yangyang_Atk_51.BP_Fx_Yangyang_Atk_51_C";

		// Token: 0x040197DC RID: 104412
		private static IntPtr _ClassPtr;

		// Token: 0x040197DD RID: 104413
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
