using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.BatchedCloth
{
	// Token: 0x02003C41 RID: 15425
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/BatchedCloth/PD_MeshToMeshActorArrForBatchedCloth.PD_MeshToMeshActorArrForBatchedCloth_C")]
	[UnrealStructLayout(160, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 160)]
	public class PD_MeshToMeshActorArrForBatchedCloth_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06023785 RID: 145285 RVA: 0x0098334B File Offset: 0x0098154B
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (PD_MeshToMeshActorArrForBatchedCloth_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/BatchedCloth/PD_MeshToMeshActorArrForBatchedCloth.PD_MeshToMeshActorArrForBatchedCloth_C");
			}
			return PD_MeshToMeshActorArrForBatchedCloth_C._ClassPtr;
		}

		// Token: 0x06023786 RID: 145286 RVA: 0x00983370 File Offset: 0x00981570
		public PD_MeshToMeshActorArrForBatchedCloth_C() : this(BuiltinUtils.AllocNativeUObject(PD_MeshToMeshActorArrForBatchedCloth_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06023787 RID: 145287 RVA: 0x00983398 File Offset: 0x00981598
		public PD_MeshToMeshActorArrForBatchedCloth_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(PD_MeshToMeshActorArrForBatchedCloth_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700469B RID: 18075
		// (get) Token: 0x06023788 RID: 145288 RVA: 0x009833CC File Offset: 0x009815CC
		// (set) Token: 0x06023789 RID: 145289 RVA: 0x00983405 File Offset: 0x00981605
		public TMap<UStaticMesh, S_BatchedClothColArrStruct> SMActor_To_SMActorArr_For_Batched_Cloth
		{
			get
			{
				base.FastCheckIsValid();
				TMap<UStaticMesh, S_BatchedClothColArrStruct> result;
				if ((result = this._SMActor_To_SMActorArr_For_Batched_Cloth) == null)
				{
					result = (this._SMActor_To_SMActorArr_For_Batched_Cloth = new TMap<UStaticMesh, S_BatchedClothColArrStruct>(base.NativePtr + (IntPtr)PD_MeshToMeshActorArrForBatchedCloth_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				this.SMActor_To_SMActorArr_For_Batched_Cloth.CopyAssign(value);
			}
		}

		// Token: 0x0602378A RID: 145290 RVA: 0x00983413 File Offset: 0x00981613
		protected PD_MeshToMeshActorArrForBatchedCloth_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040120F1 RID: 73969
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/BatchedCloth/PD_MeshToMeshActorArrForBatchedCloth.PD_MeshToMeshActorArrForBatchedCloth_C";

		// Token: 0x040120F2 RID: 73970
		private static IntPtr _ClassPtr;

		// Token: 0x040120F3 RID: 73971
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040120F4 RID: 73972
		internal static int __PropertyOffset_0;

		// Token: 0x040120F5 RID: 73973
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private TMap<UStaticMesh, S_BatchedClothColArrStruct> _SMActor_To_SMActorArr_For_Batched_Cloth;
	}
}
