using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Landscape
{
	// Token: 0x02003AB4 RID: 15028
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Landscape/FLandscapeIndexList.FLandscapeIndexList")]
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 16)]
	public class FLandscapeIndexList : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x060200D8 RID: 131288 RVA: 0x00920EF4 File Offset: 0x0091F0F4
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (FLandscapeIndexList._ScriptStructPtr != 0) ? FLandscapeIndexList._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/Scene/Landscape/FLandscapeIndexList.FLandscapeIndexList", ref FLandscapeIndexList._ScriptStructPtr);
		}

		// Token: 0x170033AF RID: 13231
		// (get) Token: 0x060200D9 RID: 131289 RVA: 0x00920F18 File Offset: 0x0091F118
		// (set) Token: 0x060200DA RID: 131290 RVA: 0x00920F5B File Offset: 0x0091F15B
		public TArray<int> Index
		{
			get
			{
				base.FastCheckIsValid();
				TArray<int> result;
				if ((result = this._Index) == null)
				{
					result = (this._Index = new TArray<int>(base.NativePtr + (IntPtr)FLandscapeIndexList.__PropertyOffset_0, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.Index.CopyAssign(value);
			}
		}

		// Token: 0x060200DB RID: 131291 RVA: 0x00920F69 File Offset: 0x0091F169
		public FLandscapeIndexList()
		{
		}

		// Token: 0x060200DC RID: 131292 RVA: 0x00920F71 File Offset: 0x0091F171
		public FLandscapeIndexList(TArray<int> Index)
		{
			this.Index = Index;
		}

		// Token: 0x060200DD RID: 131293 RVA: 0x00920F80 File Offset: 0x0091F180
		protected override IntPtr GetUStructPtr()
		{
			return FLandscapeIndexList.StaticStruct();
		}

		// Token: 0x060200DE RID: 131294 RVA: 0x00920F8C File Offset: 0x0091F18C
		[NullableContext(2)]
		public FLandscapeIndexList(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x060200DF RID: 131295 RVA: 0x00920F96 File Offset: 0x0091F196
		public FLandscapeIndexList(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x060200E0 RID: 131296 RVA: 0x00920FA1 File Offset: 0x0091F1A1
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new FLandscapeIndexList(Pointer, false, true);
		}

		// Token: 0x060200E1 RID: 131297 RVA: 0x00920FAB File Offset: 0x0091F1AB
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new FLandscapeIndexList(Pointer, MemoryOwner);
		}

		// Token: 0x0400FF75 RID: 65397
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Landscape/FLandscapeIndexList.FLandscapeIndexList";

		// Token: 0x0400FF76 RID: 65398
		private static IntPtr _ScriptStructPtr;

		// Token: 0x0400FF77 RID: 65399
		internal static int __PropertyOffset_0;

		// Token: 0x0400FF78 RID: 65400
		[Nullable(2)]
		private TArray<int> _Index;
	}
}
