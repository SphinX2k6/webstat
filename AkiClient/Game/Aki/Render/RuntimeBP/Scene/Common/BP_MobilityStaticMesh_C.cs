using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Common
{
	// Token: 0x02003ADE RID: 15070
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Common/BP_MobilityStaticMesh.BP_MobilityStaticMesh_C")]
	[UnrealStructLayout(1040, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1040)]
	public class BP_MobilityStaticMesh_C : AStaticMeshActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06020453 RID: 132179 RVA: 0x009273CC File Offset: 0x009255CC
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_MobilityStaticMesh_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Common/BP_MobilityStaticMesh.BP_MobilityStaticMesh_C");
			}
			return BP_MobilityStaticMesh_C._ClassPtr;
		}

		// Token: 0x06020454 RID: 132180 RVA: 0x009273F0 File Offset: 0x009255F0
		public BP_MobilityStaticMesh_C() : this(BuiltinUtils.AllocNativeUObject(BP_MobilityStaticMesh_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06020455 RID: 132181 RVA: 0x00927418 File Offset: 0x00925618
		[NullableContext(1)]
		public BP_MobilityStaticMesh_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_MobilityStaticMesh_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x06020456 RID: 132182 RVA: 0x0092744B File Offset: 0x0092564B
		protected BP_MobilityStaticMesh_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401019B RID: 65947
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Common/BP_MobilityStaticMesh.BP_MobilityStaticMesh_C";

		// Token: 0x0401019C RID: 65948
		private static IntPtr _ClassPtr;

		// Token: 0x0401019D RID: 65949
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
