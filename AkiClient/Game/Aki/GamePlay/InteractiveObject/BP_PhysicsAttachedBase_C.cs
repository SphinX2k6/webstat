using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.GamePlay.InteractiveObject
{
	// Token: 0x02003DD5 RID: 15829
	[UnrealObjectPath("/Game/Aki/GamePlay/InteractiveObject/BP_PhysicsAttachedBase.BP_PhysicsAttachedBase_C")]
	[UnrealStructLayout(1040, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1040)]
	public class BP_PhysicsAttachedBase_C : AStaticMeshActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06026C85 RID: 158853 RVA: 0x009E1E5E File Offset: 0x009E005E
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_PhysicsAttachedBase_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/GamePlay/InteractiveObject/BP_PhysicsAttachedBase.BP_PhysicsAttachedBase_C");
			}
			return BP_PhysicsAttachedBase_C._ClassPtr;
		}

		// Token: 0x06026C86 RID: 158854 RVA: 0x009E1E84 File Offset: 0x009E0084
		public BP_PhysicsAttachedBase_C() : this(BuiltinUtils.AllocNativeUObject(BP_PhysicsAttachedBase_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06026C87 RID: 158855 RVA: 0x009E1EAC File Offset: 0x009E00AC
		[NullableContext(1)]
		public BP_PhysicsAttachedBase_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_PhysicsAttachedBase_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x06026C88 RID: 158856 RVA: 0x009E1EDF File Offset: 0x009E00DF
		protected BP_PhysicsAttachedBase_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401439C RID: 82844
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/GamePlay/InteractiveObject/BP_PhysicsAttachedBase.BP_PhysicsAttachedBase_C";

		// Token: 0x0401439D RID: 82845
		private static IntPtr _ClassPtr;

		// Token: 0x0401439E RID: 82846
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
