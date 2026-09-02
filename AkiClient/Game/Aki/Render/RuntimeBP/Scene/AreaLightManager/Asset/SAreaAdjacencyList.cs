using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.AreaLightManager.Asset
{
	// Token: 0x02003B25 RID: 15141
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/AreaLightManager/Asset/SAreaAdjacencyList.SAreaAdjacencyList")]
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 16)]
	public class SAreaAdjacencyList : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06020961 RID: 133473 RVA: 0x009310EB File Offset: 0x0092F2EB
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SAreaAdjacencyList._ScriptStructPtr != 0) ? SAreaAdjacencyList._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/Scene/AreaLightManager/Asset/SAreaAdjacencyList.SAreaAdjacencyList", ref SAreaAdjacencyList._ScriptStructPtr);
		}

		// Token: 0x17003642 RID: 13890
		// (get) Token: 0x06020962 RID: 133474 RVA: 0x00931110 File Offset: 0x0092F310
		// (set) Token: 0x06020963 RID: 133475 RVA: 0x00931153 File Offset: 0x0092F353
		public TArray<int> Value
		{
			get
			{
				base.FastCheckIsValid();
				TArray<int> result;
				if ((result = this._Value) == null)
				{
					result = (this._Value = new TArray<int>(base.NativePtr + (IntPtr)SAreaAdjacencyList.__PropertyOffset_0, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.Value.CopyAssign(value);
			}
		}

		// Token: 0x06020964 RID: 133476 RVA: 0x00931161 File Offset: 0x0092F361
		public SAreaAdjacencyList()
		{
		}

		// Token: 0x06020965 RID: 133477 RVA: 0x00931169 File Offset: 0x0092F369
		public SAreaAdjacencyList(TArray<int> Value)
		{
			this.Value = Value;
		}

		// Token: 0x06020966 RID: 133478 RVA: 0x00931178 File Offset: 0x0092F378
		protected override IntPtr GetUStructPtr()
		{
			return SAreaAdjacencyList.StaticStruct();
		}

		// Token: 0x06020967 RID: 133479 RVA: 0x00931184 File Offset: 0x0092F384
		[NullableContext(2)]
		public SAreaAdjacencyList(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06020968 RID: 133480 RVA: 0x0093118E File Offset: 0x0092F38E
		public SAreaAdjacencyList(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06020969 RID: 133481 RVA: 0x00931199 File Offset: 0x0092F399
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SAreaAdjacencyList(Pointer, false, true);
		}

		// Token: 0x0602096A RID: 133482 RVA: 0x009311A3 File Offset: 0x0092F3A3
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SAreaAdjacencyList(Pointer, MemoryOwner);
		}

		// Token: 0x040104F1 RID: 66801
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/AreaLightManager/Asset/SAreaAdjacencyList.SAreaAdjacencyList";

		// Token: 0x040104F2 RID: 66802
		private static IntPtr _ScriptStructPtr;

		// Token: 0x040104F3 RID: 66803
		internal static int __PropertyOffset_0;

		// Token: 0x040104F4 RID: 66804
		[Nullable(2)]
		private TArray<int> _Value;
	}
}
