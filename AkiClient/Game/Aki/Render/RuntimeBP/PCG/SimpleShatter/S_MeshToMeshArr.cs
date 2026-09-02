using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.SimpleShatter
{
	// Token: 0x02003B78 RID: 15224
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/SimpleShatter/S_MeshToMeshArr.S_MeshToMeshArr")]
	[UnrealStructLayout(32, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 32)]
	public class S_MeshToMeshArr : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x060218B6 RID: 137398 RVA: 0x0094C4F6 File Offset: 0x0094A6F6
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (S_MeshToMeshArr._ScriptStructPtr != 0) ? S_MeshToMeshArr._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/PCG/SimpleShatter/S_MeshToMeshArr.S_MeshToMeshArr", ref S_MeshToMeshArr._ScriptStructPtr);
		}

		// Token: 0x17003BB1 RID: 15281
		// (get) Token: 0x060218B7 RID: 137399 RVA: 0x0094C51C File Offset: 0x0094A71C
		// (set) Token: 0x060218B8 RID: 137400 RVA: 0x0094C55F File Offset: 0x0094A75F
		public TArray<UStaticMesh> MemberVar_0
		{
			get
			{
				base.FastCheckIsValid();
				TArray<UStaticMesh> result;
				if ((result = this._MemberVar_0) == null)
				{
					result = (this._MemberVar_0 = new TArray<UStaticMesh>(base.NativePtr + (IntPtr)S_MeshToMeshArr.__PropertyOffset_0, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.MemberVar_0.CopyAssign(value);
			}
		}

		// Token: 0x17003BB2 RID: 15282
		// (get) Token: 0x060218B9 RID: 137401 RVA: 0x0094C56D File Offset: 0x0094A76D
		// (set) Token: 0x060218BA RID: 137402 RVA: 0x0094C57D File Offset: 0x0094A77D
		public unsafe bool 易碎物_
		{
			get
			{
				return *(base.NativePtr + (IntPtr)S_MeshToMeshArr.__PropertyOffset_1) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)S_MeshToMeshArr.__PropertyOffset_1) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003BB3 RID: 15283
		// (get) Token: 0x060218BB RID: 137403 RVA: 0x0094C58E File Offset: 0x0094A78E
		// (set) Token: 0x060218BC RID: 137404 RVA: 0x0094C59E File Offset: 0x0094A79E
		public unsafe bool 消融_
		{
			get
			{
				return *(base.NativePtr + (IntPtr)S_MeshToMeshArr.__PropertyOffset_2) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)S_MeshToMeshArr.__PropertyOffset_2) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003BB4 RID: 15284
		// (get) Token: 0x060218BD RID: 137405 RVA: 0x0094C5AF File Offset: 0x0094A7AF
		// (set) Token: 0x060218BE RID: 137406 RVA: 0x0094C5C3 File Offset: 0x0094A7C3
		[Nullable(2)]
		public unsafe UNiagaraSystem 粒子特效
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraSystem>(base.NativePtr / (IntPtr)sizeof(void*) + S_MeshToMeshArr.__PropertyOffset_3);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + S_MeshToMeshArr.__PropertyOffset_3, value);
			}
		}

		// Token: 0x060218BF RID: 137407 RVA: 0x0094C5D8 File Offset: 0x0094A7D8
		public S_MeshToMeshArr()
		{
		}

		// Token: 0x060218C0 RID: 137408 RVA: 0x0094C5E0 File Offset: 0x0094A7E0
		public S_MeshToMeshArr(TArray<UStaticMesh> MemberVar_0, bool 易碎物_, bool 消融_, UNiagaraSystem 粒子特效)
		{
			this.MemberVar_0 = MemberVar_0;
			this.易碎物_ = 易碎物_;
			this.消融_ = 消融_;
			this.粒子特效 = 粒子特效;
		}

		// Token: 0x060218C1 RID: 137409 RVA: 0x0094C605 File Offset: 0x0094A805
		protected override IntPtr GetUStructPtr()
		{
			return S_MeshToMeshArr.StaticStruct();
		}

		// Token: 0x060218C2 RID: 137410 RVA: 0x0094C611 File Offset: 0x0094A811
		[NullableContext(2)]
		public S_MeshToMeshArr(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x060218C3 RID: 137411 RVA: 0x0094C61B File Offset: 0x0094A81B
		public S_MeshToMeshArr(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x060218C4 RID: 137412 RVA: 0x0094C626 File Offset: 0x0094A826
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new S_MeshToMeshArr(Pointer, false, true);
		}

		// Token: 0x060218C5 RID: 137413 RVA: 0x0094C630 File Offset: 0x0094A830
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new S_MeshToMeshArr(Pointer, MemoryOwner);
		}

		// Token: 0x04010E66 RID: 69222
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/SimpleShatter/S_MeshToMeshArr.S_MeshToMeshArr";

		// Token: 0x04010E67 RID: 69223
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04010E68 RID: 69224
		internal static int __PropertyOffset_0;

		// Token: 0x04010E69 RID: 69225
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UStaticMesh> _MemberVar_0;

		// Token: 0x04010E6A RID: 69226
		internal static int __PropertyOffset_1;

		// Token: 0x04010E6B RID: 69227
		internal static int __PropertyOffset_2;

		// Token: 0x04010E6C RID: 69228
		internal static int __PropertyOffset_3;
	}
}
