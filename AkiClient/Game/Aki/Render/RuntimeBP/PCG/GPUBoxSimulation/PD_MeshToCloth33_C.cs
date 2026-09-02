using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.GPUBoxSimulation
{
	// Token: 0x02003C29 RID: 15401
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/GPUBoxSimulation/PD_MeshToCloth33.PD_MeshToCloth33_C")]
	[UnrealStructLayout(160, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 160)]
	public class PD_MeshToCloth33_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060233BF RID: 144319 RVA: 0x0097CB44 File Offset: 0x0097AD44
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (PD_MeshToCloth33_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/GPUBoxSimulation/PD_MeshToCloth33.PD_MeshToCloth33_C");
			}
			return PD_MeshToCloth33_C._ClassPtr;
		}

		// Token: 0x060233C0 RID: 144320 RVA: 0x0097CB68 File Offset: 0x0097AD68
		public PD_MeshToCloth33_C() : this(BuiltinUtils.AllocNativeUObject(PD_MeshToCloth33_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060233C1 RID: 144321 RVA: 0x0097CB90 File Offset: 0x0097AD90
		public PD_MeshToCloth33_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(PD_MeshToCloth33_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17004536 RID: 17718
		// (get) Token: 0x060233C2 RID: 144322 RVA: 0x0097CBC4 File Offset: 0x0097ADC4
		// (set) Token: 0x060233C3 RID: 144323 RVA: 0x0097CBFD File Offset: 0x0097ADFD
		public TMap<TSoftObjectPtr<UStaticMesh>, struct_genCloth_33> MeshToCloth33
		{
			get
			{
				base.FastCheckIsValid();
				TMap<TSoftObjectPtr<UStaticMesh>, struct_genCloth_33> result;
				if ((result = this._MeshToCloth33) == null)
				{
					result = (this._MeshToCloth33 = new TMap<TSoftObjectPtr<UStaticMesh>, struct_genCloth_33>(base.NativePtr + (IntPtr)PD_MeshToCloth33_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				this.MeshToCloth33.CopyAssign(value);
			}
		}

		// Token: 0x060233C4 RID: 144324 RVA: 0x0097CC0B File Offset: 0x0097AE0B
		protected PD_MeshToCloth33_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04011EC5 RID: 73413
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/GPUBoxSimulation/PD_MeshToCloth33.PD_MeshToCloth33_C";

		// Token: 0x04011EC6 RID: 73414
		private static IntPtr _ClassPtr;

		// Token: 0x04011EC7 RID: 73415
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04011EC8 RID: 73416
		internal static int __PropertyOffset_0;

		// Token: 0x04011EC9 RID: 73417
		[Nullable(new byte[]
		{
			2,
			1,
			1,
			1
		})]
		private TMap<TSoftObjectPtr<UStaticMesh>, struct_genCloth_33> _MeshToCloth33;
	}
}
