using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.CurveTrailDecal
{
	// Token: 0x02003D57 RID: 15703
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/CurveTrailDecal/BP_KuroCurveTrailDecalSpawnerComponent.BP_KuroCurveTrailDecalSpawnerComponent_C")]
	[UnrealStructLayout(752, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 752)]
	public class BP_KuroCurveTrailDecalSpawnerComponent_C : UKuroCurveTrailDecalSpawnerComponent, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602623A RID: 156218 RVA: 0x009CF0AC File Offset: 0x009CD2AC
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_KuroCurveTrailDecalSpawnerComponent_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/CurveTrailDecal/BP_KuroCurveTrailDecalSpawnerComponent.BP_KuroCurveTrailDecalSpawnerComponent_C");
			}
			return BP_KuroCurveTrailDecalSpawnerComponent_C._ClassPtr;
		}

		// Token: 0x0602623B RID: 156219 RVA: 0x009CF0D0 File Offset: 0x009CD2D0
		public BP_KuroCurveTrailDecalSpawnerComponent_C() : this(BuiltinUtils.AllocNativeUObject(BP_KuroCurveTrailDecalSpawnerComponent_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602623C RID: 156220 RVA: 0x009CF0F8 File Offset: 0x009CD2F8
		[NullableContext(1)]
		public BP_KuroCurveTrailDecalSpawnerComponent_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_KuroCurveTrailDecalSpawnerComponent_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602623D RID: 156221 RVA: 0x009CF12B File Offset: 0x009CD32B
		protected BP_KuroCurveTrailDecalSpawnerComponent_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04013C18 RID: 80920
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/CurveTrailDecal/BP_KuroCurveTrailDecalSpawnerComponent.BP_KuroCurveTrailDecalSpawnerComponent_C";

		// Token: 0x04013C19 RID: 80921
		private static IntPtr _ClassPtr;

		// Token: 0x04013C1A RID: 80922
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
