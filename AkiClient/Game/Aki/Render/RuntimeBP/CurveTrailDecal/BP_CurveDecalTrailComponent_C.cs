using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.CurveTrailDecal
{
	// Token: 0x02003D55 RID: 15701
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/CurveTrailDecal/BP_CurveDecalTrailComponent.BP_CurveDecalTrailComponent_C")]
	[UnrealStructLayout(2304, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2304)]
	public class BP_CurveDecalTrailComponent_C : UKuroCurveTrailDecalComponent, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06026229 RID: 156201 RVA: 0x009CEE1F File Offset: 0x009CD01F
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_CurveDecalTrailComponent_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/CurveTrailDecal/BP_CurveDecalTrailComponent.BP_CurveDecalTrailComponent_C");
			}
			return BP_CurveDecalTrailComponent_C._ClassPtr;
		}

		// Token: 0x0602622A RID: 156202 RVA: 0x009CEE44 File Offset: 0x009CD044
		public BP_CurveDecalTrailComponent_C() : this(BuiltinUtils.AllocNativeUObject(BP_CurveDecalTrailComponent_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602622B RID: 156203 RVA: 0x009CEE6C File Offset: 0x009CD06C
		[NullableContext(1)]
		public BP_CurveDecalTrailComponent_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_CurveDecalTrailComponent_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602622C RID: 156204 RVA: 0x009CEE9F File Offset: 0x009CD09F
		protected BP_CurveDecalTrailComponent_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04013C0C RID: 80908
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/CurveTrailDecal/BP_CurveDecalTrailComponent.BP_CurveDecalTrailComponent_C";

		// Token: 0x04013C0D RID: 80909
		private static IntPtr _ClassPtr;

		// Token: 0x04013C0E RID: 80910
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
