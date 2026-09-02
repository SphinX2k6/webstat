using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.BatchedCloth
{
	// Token: 0x02003C42 RID: 15426
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/BatchedCloth/S_BatchedClothColArrStruct.S_BatchedClothColArrStruct")]
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 16)]
	public class S_BatchedClothColArrStruct : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602378B RID: 145291 RVA: 0x0098341C File Offset: 0x0098161C
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (S_BatchedClothColArrStruct._ScriptStructPtr != 0) ? S_BatchedClothColArrStruct._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/PCG/BatchedCloth/S_BatchedClothColArrStruct.S_BatchedClothColArrStruct", ref S_BatchedClothColArrStruct._ScriptStructPtr);
		}

		// Token: 0x1700469C RID: 18076
		// (get) Token: 0x0602378C RID: 145292 RVA: 0x00983440 File Offset: 0x00981640
		// (set) Token: 0x0602378D RID: 145293 RVA: 0x00983483 File Offset: 0x00981683
		public TArray<S_BatchedClothColStruct> BaseStaticMeshActorArr
		{
			get
			{
				base.FastCheckIsValid();
				TArray<S_BatchedClothColStruct> result;
				if ((result = this._BaseStaticMeshActorArr) == null)
				{
					result = (this._BaseStaticMeshActorArr = new TArray<S_BatchedClothColStruct>(base.NativePtr + (IntPtr)S_BatchedClothColArrStruct.__PropertyOffset_0, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.BaseStaticMeshActorArr.CopyAssign(value);
			}
		}

		// Token: 0x0602378E RID: 145294 RVA: 0x00983491 File Offset: 0x00981691
		public S_BatchedClothColArrStruct()
		{
		}

		// Token: 0x0602378F RID: 145295 RVA: 0x00983499 File Offset: 0x00981699
		public S_BatchedClothColArrStruct(TArray<S_BatchedClothColStruct> BaseStaticMeshActorArr)
		{
			this.BaseStaticMeshActorArr = BaseStaticMeshActorArr;
		}

		// Token: 0x06023790 RID: 145296 RVA: 0x009834A8 File Offset: 0x009816A8
		protected override IntPtr GetUStructPtr()
		{
			return S_BatchedClothColArrStruct.StaticStruct();
		}

		// Token: 0x06023791 RID: 145297 RVA: 0x009834B4 File Offset: 0x009816B4
		[NullableContext(2)]
		public S_BatchedClothColArrStruct(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06023792 RID: 145298 RVA: 0x009834BE File Offset: 0x009816BE
		public S_BatchedClothColArrStruct(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06023793 RID: 145299 RVA: 0x009834C9 File Offset: 0x009816C9
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new S_BatchedClothColArrStruct(Pointer, false, true);
		}

		// Token: 0x06023794 RID: 145300 RVA: 0x009834D3 File Offset: 0x009816D3
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new S_BatchedClothColArrStruct(Pointer, MemoryOwner);
		}

		// Token: 0x040120F6 RID: 73974
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/BatchedCloth/S_BatchedClothColArrStruct.S_BatchedClothColArrStruct";

		// Token: 0x040120F7 RID: 73975
		private static IntPtr _ScriptStructPtr;

		// Token: 0x040120F8 RID: 73976
		internal static int __PropertyOffset_0;

		// Token: 0x040120F9 RID: 73977
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<S_BatchedClothColStruct> _BaseStaticMeshActorArr;
	}
}
