using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.TypeScript.Game.NewWorld.Character.SimpleNpc.Blueprint
{
	// Token: 0x020039C0 RID: 14784
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/TypeScript/Game/NewWorld/Character/SimpleNpc/Blueprint/SHolographicMaterialsCache.SHolographicMaterialsCache")]
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 16)]
	public class SHolographicMaterialsCache : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0601DE34 RID: 122420 RVA: 0x008E5E30 File Offset: 0x008E4030
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SHolographicMaterialsCache._ScriptStructPtr != 0) ? SHolographicMaterialsCache._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/TypeScript/Game/NewWorld/Character/SimpleNpc/Blueprint/SHolographicMaterialsCache.SHolographicMaterialsCache", ref SHolographicMaterialsCache._ScriptStructPtr);
		}

		// Token: 0x170027AC RID: 10156
		// (get) Token: 0x0601DE35 RID: 122421 RVA: 0x008E5E54 File Offset: 0x008E4054
		// (set) Token: 0x0601DE36 RID: 122422 RVA: 0x008E5E97 File Offset: 0x008E4097
		public TArray<SMaterialParamCache> Materials
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SMaterialParamCache> result;
				if ((result = this._Materials) == null)
				{
					result = (this._Materials = new TArray<SMaterialParamCache>(base.NativePtr + (IntPtr)SHolographicMaterialsCache.__PropertyOffset_0, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.Materials.CopyAssign(value);
			}
		}

		// Token: 0x0601DE37 RID: 122423 RVA: 0x008E5EA5 File Offset: 0x008E40A5
		public SHolographicMaterialsCache()
		{
		}

		// Token: 0x0601DE38 RID: 122424 RVA: 0x008E5EAD File Offset: 0x008E40AD
		public SHolographicMaterialsCache(TArray<SMaterialParamCache> Materials)
		{
			this.Materials = Materials;
		}

		// Token: 0x0601DE39 RID: 122425 RVA: 0x008E5EBC File Offset: 0x008E40BC
		protected override IntPtr GetUStructPtr()
		{
			return SHolographicMaterialsCache.StaticStruct();
		}

		// Token: 0x0601DE3A RID: 122426 RVA: 0x008E5EC8 File Offset: 0x008E40C8
		[NullableContext(2)]
		public SHolographicMaterialsCache(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0601DE3B RID: 122427 RVA: 0x008E5ED2 File Offset: 0x008E40D2
		public SHolographicMaterialsCache(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0601DE3C RID: 122428 RVA: 0x008E5EDD File Offset: 0x008E40DD
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SHolographicMaterialsCache(Pointer, false, true);
		}

		// Token: 0x0601DE3D RID: 122429 RVA: 0x008E5EE7 File Offset: 0x008E40E7
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SHolographicMaterialsCache(Pointer, MemoryOwner);
		}

		// Token: 0x0400EA43 RID: 59971
		public const string __ObjectPath = "/Game/Aki/TypeScript/Game/NewWorld/Character/SimpleNpc/Blueprint/SHolographicMaterialsCache.SHolographicMaterialsCache";

		// Token: 0x0400EA44 RID: 59972
		private static IntPtr _ScriptStructPtr;

		// Token: 0x0400EA45 RID: 59973
		internal static int __PropertyOffset_0;

		// Token: 0x0400EA46 RID: 59974
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SMaterialParamCache> _Materials;
	}
}
