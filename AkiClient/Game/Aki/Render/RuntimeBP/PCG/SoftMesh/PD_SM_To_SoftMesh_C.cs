using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.SoftMesh
{
	// Token: 0x02003B6E RID: 15214
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/SoftMesh/PD_SM_To_SoftMesh.PD_SM_To_SoftMesh_C")]
	[UnrealStructLayout(160, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 160)]
	public class PD_SM_To_SoftMesh_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060217DB RID: 137179 RVA: 0x0094AB57 File Offset: 0x00948D57
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (PD_SM_To_SoftMesh_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/SoftMesh/PD_SM_To_SoftMesh.PD_SM_To_SoftMesh_C");
			}
			return PD_SM_To_SoftMesh_C._ClassPtr;
		}

		// Token: 0x060217DC RID: 137180 RVA: 0x0094AB7C File Offset: 0x00948D7C
		public PD_SM_To_SoftMesh_C() : this(BuiltinUtils.AllocNativeUObject(PD_SM_To_SoftMesh_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060217DD RID: 137181 RVA: 0x0094ABA4 File Offset: 0x00948DA4
		public PD_SM_To_SoftMesh_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(PD_SM_To_SoftMesh_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003B71 RID: 15217
		// (get) Token: 0x060217DE RID: 137182 RVA: 0x0094ABD8 File Offset: 0x00948DD8
		// (set) Token: 0x060217DF RID: 137183 RVA: 0x0094AC11 File Offset: 0x00948E11
		public TMap<TSoftObjectPtr<UStaticMesh>, S_SoftMeshPreset> SMToSoftMesh
		{
			get
			{
				base.FastCheckIsValid();
				TMap<TSoftObjectPtr<UStaticMesh>, S_SoftMeshPreset> result;
				if ((result = this._SMToSoftMesh) == null)
				{
					result = (this._SMToSoftMesh = new TMap<TSoftObjectPtr<UStaticMesh>, S_SoftMeshPreset>(base.NativePtr + (IntPtr)PD_SM_To_SoftMesh_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				this.SMToSoftMesh.CopyAssign(value);
			}
		}

		// Token: 0x060217E0 RID: 137184 RVA: 0x0094AC1F File Offset: 0x00948E1F
		protected PD_SM_To_SoftMesh_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04010DDA RID: 69082
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/SoftMesh/PD_SM_To_SoftMesh.PD_SM_To_SoftMesh_C";

		// Token: 0x04010DDB RID: 69083
		private static IntPtr _ClassPtr;

		// Token: 0x04010DDC RID: 69084
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04010DDD RID: 69085
		internal static int __PropertyOffset_0;

		// Token: 0x04010DDE RID: 69086
		[Nullable(new byte[]
		{
			2,
			1,
			1,
			1
		})]
		private TMap<TSoftObjectPtr<UStaticMesh>, S_SoftMeshPreset> _SMToSoftMesh;
	}
}
