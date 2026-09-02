using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.StateMachine
{
	// Token: 0x020042BC RID: 17084
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_BindStateDisableCollision.BP_SM_BindStateDisableCollision_C")]
	[UnrealStructLayout(48, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 48)]
	public class BP_SM_BindStateDisableCollision_C : UASMBindState, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602D579 RID: 185721 RVA: 0x00ABD8D8 File Offset: 0x00ABBAD8
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SM_BindStateDisableCollision_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_BindStateDisableCollision.BP_SM_BindStateDisableCollision_C");
			}
			return BP_SM_BindStateDisableCollision_C._ClassPtr;
		}

		// Token: 0x0602D57A RID: 185722 RVA: 0x00ABD8FC File Offset: 0x00ABBAFC
		public BP_SM_BindStateDisableCollision_C() : this(BuiltinUtils.AllocNativeUObject(BP_SM_BindStateDisableCollision_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602D57B RID: 185723 RVA: 0x00ABD924 File Offset: 0x00ABBB24
		[NullableContext(1)]
		public BP_SM_BindStateDisableCollision_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SM_BindStateDisableCollision_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602D57C RID: 185724 RVA: 0x00ABD957 File Offset: 0x00ABBB57
		protected BP_SM_BindStateDisableCollision_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040196D0 RID: 104144
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_BindStateDisableCollision.BP_SM_BindStateDisableCollision_C";

		// Token: 0x040196D1 RID: 104145
		private static IntPtr _ClassPtr;

		// Token: 0x040196D2 RID: 104146
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
