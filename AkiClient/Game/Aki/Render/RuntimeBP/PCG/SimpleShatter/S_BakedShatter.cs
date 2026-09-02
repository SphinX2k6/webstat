using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.SimpleShatter
{
	// Token: 0x02003B77 RID: 15223
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/SimpleShatter/S_BakedShatter.S_BakedShatter")]
	[UnrealStructLayout(96, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 96)]
	public class S_BakedShatter : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x060218A2 RID: 137378 RVA: 0x0094C26C File Offset: 0x0094A46C
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (S_BakedShatter._ScriptStructPtr != 0) ? S_BakedShatter._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/PCG/SimpleShatter/S_BakedShatter.S_BakedShatter", ref S_BakedShatter._ScriptStructPtr);
		}

		// Token: 0x17003BAB RID: 15275
		// (get) Token: 0x060218A3 RID: 137379 RVA: 0x0094C290 File Offset: 0x0094A490
		// (set) Token: 0x060218A4 RID: 137380 RVA: 0x0094C2D3 File Offset: 0x0094A4D3
		public TArray<FTransform> SMComponentLocalTransformArr
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FTransform> result;
				if ((result = this._SMComponentLocalTransformArr) == null)
				{
					result = (this._SMComponentLocalTransformArr = new TArray<FTransform>(base.NativePtr + (IntPtr)S_BakedShatter.__PropertyOffset_0, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.SMComponentLocalTransformArr.CopyAssign(value);
			}
		}

		// Token: 0x17003BAC RID: 15276
		// (get) Token: 0x060218A5 RID: 137381 RVA: 0x0094C2E4 File Offset: 0x0094A4E4
		// (set) Token: 0x060218A6 RID: 137382 RVA: 0x0094C327 File Offset: 0x0094A527
		public TArray<AStaticMeshActor> SMActorArr
		{
			get
			{
				base.FastCheckIsValid();
				TArray<AStaticMeshActor> result;
				if ((result = this._SMActorArr) == null)
				{
					result = (this._SMActorArr = new TArray<AStaticMeshActor>(base.NativePtr + (IntPtr)S_BakedShatter.__PropertyOffset_1, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.SMActorArr.CopyAssign(value);
			}
		}

		// Token: 0x17003BAD RID: 15277
		// (get) Token: 0x060218A7 RID: 137383 RVA: 0x0094C338 File Offset: 0x0094A538
		// (set) Token: 0x060218A8 RID: 137384 RVA: 0x0094C37B File Offset: 0x0094A57B
		public TArray<UStaticMesh> SMArr
		{
			get
			{
				base.FastCheckIsValid();
				TArray<UStaticMesh> result;
				if ((result = this._SMArr) == null)
				{
					result = (this._SMArr = new TArray<UStaticMesh>(base.NativePtr + (IntPtr)S_BakedShatter.__PropertyOffset_2, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.SMArr.CopyAssign(value);
			}
		}

		// Token: 0x17003BAE RID: 15278
		// (get) Token: 0x060218A9 RID: 137385 RVA: 0x0094C38C File Offset: 0x0094A58C
		// (set) Token: 0x060218AA RID: 137386 RVA: 0x0094C3CF File Offset: 0x0094A5CF
		public TArray<FSimpleShatterNode> NodeArr
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FSimpleShatterNode> result;
				if ((result = this._NodeArr) == null)
				{
					result = (this._NodeArr = new TArray<FSimpleShatterNode>(base.NativePtr + (IntPtr)S_BakedShatter.__PropertyOffset_3, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.NodeArr.CopyAssign(value);
			}
		}

		// Token: 0x17003BAF RID: 15279
		// (get) Token: 0x060218AB RID: 137387 RVA: 0x0094C3E0 File Offset: 0x0094A5E0
		// (set) Token: 0x060218AC RID: 137388 RVA: 0x0094C423 File Offset: 0x0094A623
		public TArray<UStaticMeshComponent> SMComponentArr
		{
			get
			{
				base.FastCheckIsValid();
				TArray<UStaticMeshComponent> result;
				if ((result = this._SMComponentArr) == null)
				{
					result = (this._SMComponentArr = new TArray<UStaticMeshComponent>(base.NativePtr + (IntPtr)S_BakedShatter.__PropertyOffset_4, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.SMComponentArr.CopyAssign(value);
			}
		}

		// Token: 0x17003BB0 RID: 15280
		// (get) Token: 0x060218AD RID: 137389 RVA: 0x0094C434 File Offset: 0x0094A634
		// (set) Token: 0x060218AE RID: 137390 RVA: 0x0094C477 File Offset: 0x0094A677
		public TArray<int> BakedArr
		{
			get
			{
				base.FastCheckIsValid();
				TArray<int> result;
				if ((result = this._BakedArr) == null)
				{
					result = (this._BakedArr = new TArray<int>(base.NativePtr + (IntPtr)S_BakedShatter.__PropertyOffset_5, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.BakedArr.CopyAssign(value);
			}
		}

		// Token: 0x060218AF RID: 137391 RVA: 0x0094C485 File Offset: 0x0094A685
		public S_BakedShatter()
		{
		}

		// Token: 0x060218B0 RID: 137392 RVA: 0x0094C48D File Offset: 0x0094A68D
		public S_BakedShatter(TArray<FTransform> SMComponentLocalTransformArr, TArray<AStaticMeshActor> SMActorArr, TArray<UStaticMesh> SMArr, TArray<FSimpleShatterNode> NodeArr, TArray<UStaticMeshComponent> SMComponentArr, TArray<int> BakedArr)
		{
			this.SMComponentLocalTransformArr = SMComponentLocalTransformArr;
			this.SMActorArr = SMActorArr;
			this.SMArr = SMArr;
			this.NodeArr = NodeArr;
			this.SMComponentArr = SMComponentArr;
			this.BakedArr = BakedArr;
		}

		// Token: 0x060218B1 RID: 137393 RVA: 0x0094C4C2 File Offset: 0x0094A6C2
		protected override IntPtr GetUStructPtr()
		{
			return S_BakedShatter.StaticStruct();
		}

		// Token: 0x060218B2 RID: 137394 RVA: 0x0094C4CE File Offset: 0x0094A6CE
		[NullableContext(2)]
		public S_BakedShatter(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x060218B3 RID: 137395 RVA: 0x0094C4D8 File Offset: 0x0094A6D8
		public S_BakedShatter(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x060218B4 RID: 137396 RVA: 0x0094C4E3 File Offset: 0x0094A6E3
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new S_BakedShatter(Pointer, false, true);
		}

		// Token: 0x060218B5 RID: 137397 RVA: 0x0094C4ED File Offset: 0x0094A6ED
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new S_BakedShatter(Pointer, MemoryOwner);
		}

		// Token: 0x04010E58 RID: 69208
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/SimpleShatter/S_BakedShatter.S_BakedShatter";

		// Token: 0x04010E59 RID: 69209
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04010E5A RID: 69210
		internal static int __PropertyOffset_0;

		// Token: 0x04010E5B RID: 69211
		[Nullable(2)]
		private TArray<FTransform> _SMComponentLocalTransformArr;

		// Token: 0x04010E5C RID: 69212
		internal static int __PropertyOffset_1;

		// Token: 0x04010E5D RID: 69213
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<AStaticMeshActor> _SMActorArr;

		// Token: 0x04010E5E RID: 69214
		internal static int __PropertyOffset_2;

		// Token: 0x04010E5F RID: 69215
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UStaticMesh> _SMArr;

		// Token: 0x04010E60 RID: 69216
		internal static int __PropertyOffset_3;

		// Token: 0x04010E61 RID: 69217
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<FSimpleShatterNode> _NodeArr;

		// Token: 0x04010E62 RID: 69218
		internal static int __PropertyOffset_4;

		// Token: 0x04010E63 RID: 69219
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UStaticMeshComponent> _SMComponentArr;

		// Token: 0x04010E64 RID: 69220
		internal static int __PropertyOffset_5;

		// Token: 0x04010E65 RID: 69221
		[Nullable(2)]
		private TArray<int> _BakedArr;
	}
}
