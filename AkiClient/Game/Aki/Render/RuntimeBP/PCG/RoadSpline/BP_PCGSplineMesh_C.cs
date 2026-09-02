using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.RoadSpline
{
	// Token: 0x02003B97 RID: 15255
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/RoadSpline/BP_PCGSplineMesh.BP_PCGSplineMesh_C")]
	[UnrealStructLayout(1040, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1040)]
	public class BP_PCGSplineMesh_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06021D76 RID: 138614 RVA: 0x00955407 File Offset: 0x00953607
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_PCGSplineMesh_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/RoadSpline/BP_PCGSplineMesh.BP_PCGSplineMesh_C");
			}
			return BP_PCGSplineMesh_C._ClassPtr;
		}

		// Token: 0x06021D77 RID: 138615 RVA: 0x0095542C File Offset: 0x0095362C
		public BP_PCGSplineMesh_C() : this(BuiltinUtils.AllocNativeUObject(BP_PCGSplineMesh_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06021D78 RID: 138616 RVA: 0x00955454 File Offset: 0x00953654
		[NullableContext(1)]
		public BP_PCGSplineMesh_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_PCGSplineMesh_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003D4C RID: 15692
		// (get) Token: 0x06021D79 RID: 138617 RVA: 0x00955487 File Offset: 0x00953687
		// (set) Token: 0x06021D7A RID: 138618 RVA: 0x0095549B File Offset: 0x0095369B
		public unsafe UStaticMeshComponent StaticMesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PCGSplineMesh_C.__PropertyOffset_0);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PCGSplineMesh_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x17003D4D RID: 15693
		// (get) Token: 0x06021D7B RID: 138619 RVA: 0x009554B0 File Offset: 0x009536B0
		// (set) Token: 0x06021D7C RID: 138620 RVA: 0x009554C4 File Offset: 0x009536C4
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PCGSplineMesh_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PCGSplineMesh_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x06021D7D RID: 138621 RVA: 0x009554D9 File Offset: 0x009536D9
		protected BP_PCGSplineMesh_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04011149 RID: 69961
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/RoadSpline/BP_PCGSplineMesh.BP_PCGSplineMesh_C";

		// Token: 0x0401114A RID: 69962
		private static IntPtr _ClassPtr;

		// Token: 0x0401114B RID: 69963
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401114C RID: 69964
		internal static int __PropertyOffset_0;

		// Token: 0x0401114D RID: 69965
		internal static int __PropertyOffset_1;
	}
}
