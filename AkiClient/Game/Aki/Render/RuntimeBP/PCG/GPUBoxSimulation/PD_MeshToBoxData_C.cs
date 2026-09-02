using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.GPUBoxSimulation
{
	// Token: 0x02003C28 RID: 15400
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/GPUBoxSimulation/PD_MeshToBoxData.PD_MeshToBoxData_C")]
	[UnrealStructLayout(160, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 160)]
	public class PD_MeshToBoxData_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060233B9 RID: 144313 RVA: 0x0097CA73 File Offset: 0x0097AC73
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (PD_MeshToBoxData_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/GPUBoxSimulation/PD_MeshToBoxData.PD_MeshToBoxData_C");
			}
			return PD_MeshToBoxData_C._ClassPtr;
		}

		// Token: 0x060233BA RID: 144314 RVA: 0x0097CA98 File Offset: 0x0097AC98
		public PD_MeshToBoxData_C() : this(BuiltinUtils.AllocNativeUObject(PD_MeshToBoxData_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060233BB RID: 144315 RVA: 0x0097CAC0 File Offset: 0x0097ACC0
		public PD_MeshToBoxData_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(PD_MeshToBoxData_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17004535 RID: 17717
		// (get) Token: 0x060233BC RID: 144316 RVA: 0x0097CAF4 File Offset: 0x0097ACF4
		// (set) Token: 0x060233BD RID: 144317 RVA: 0x0097CB2D File Offset: 0x0097AD2D
		public TMap<TSoftObjectPtr<UStaticMesh>, S_boxColSetupParams> MeshToBoxCol
		{
			get
			{
				base.FastCheckIsValid();
				TMap<TSoftObjectPtr<UStaticMesh>, S_boxColSetupParams> result;
				if ((result = this._MeshToBoxCol) == null)
				{
					result = (this._MeshToBoxCol = new TMap<TSoftObjectPtr<UStaticMesh>, S_boxColSetupParams>(base.NativePtr + (IntPtr)PD_MeshToBoxData_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				this.MeshToBoxCol.CopyAssign(value);
			}
		}

		// Token: 0x060233BE RID: 144318 RVA: 0x0097CB3B File Offset: 0x0097AD3B
		protected PD_MeshToBoxData_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04011EC0 RID: 73408
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/GPUBoxSimulation/PD_MeshToBoxData.PD_MeshToBoxData_C";

		// Token: 0x04011EC1 RID: 73409
		private static IntPtr _ClassPtr;

		// Token: 0x04011EC2 RID: 73410
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04011EC3 RID: 73411
		internal static int __PropertyOffset_0;

		// Token: 0x04011EC4 RID: 73412
		[Nullable(new byte[]
		{
			2,
			1,
			1,
			1
		})]
		private TMap<TSoftObjectPtr<UStaticMesh>, S_boxColSetupParams> _MeshToBoxCol;
	}
}
