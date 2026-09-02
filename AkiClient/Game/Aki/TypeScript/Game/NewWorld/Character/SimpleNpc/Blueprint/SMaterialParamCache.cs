using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.TypeScript.Game.NewWorld.Character.SimpleNpc.Blueprint
{
	// Token: 0x020039C2 RID: 14786
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/TypeScript/Game/NewWorld/Character/SimpleNpc/Blueprint/SMaterialParamCache.SMaterialParamCache")]
	[UnrealStructLayout(176, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 172)]
	public class SMaterialParamCache : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0601DE5D RID: 122461 RVA: 0x008E65C0 File Offset: 0x008E47C0
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SMaterialParamCache._ScriptStructPtr != 0) ? SMaterialParamCache._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/TypeScript/Game/NewWorld/Character/SimpleNpc/Blueprint/SMaterialParamCache.SMaterialParamCache", ref SMaterialParamCache._ScriptStructPtr);
		}

		// Token: 0x170027B5 RID: 10165
		// (get) Token: 0x0601DE5E RID: 122462 RVA: 0x008E65E4 File Offset: 0x008E47E4
		// (set) Token: 0x0601DE5F RID: 122463 RVA: 0x008E65F8 File Offset: 0x008E47F8
		[Nullable(2)]
		public unsafe UMaterialInstanceDynamic sourceMaterial
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + SMaterialParamCache.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + SMaterialParamCache.__PropertyOffset_0, value);
			}
		}

		// Token: 0x170027B6 RID: 10166
		// (get) Token: 0x0601DE60 RID: 122464 RVA: 0x008E6610 File Offset: 0x008E4810
		// (set) Token: 0x0601DE61 RID: 122465 RVA: 0x008E6653 File Offset: 0x008E4853
		public TMap<FName, float> floatCaches
		{
			get
			{
				base.FastCheckIsValid();
				TMap<FName, float> result;
				if ((result = this._floatCaches) == null)
				{
					result = (this._floatCaches = new TMap<FName, float>(base.NativePtr + (IntPtr)SMaterialParamCache.__PropertyOffset_1, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.floatCaches.CopyAssign(value);
			}
		}

		// Token: 0x170027B7 RID: 10167
		// (get) Token: 0x0601DE62 RID: 122466 RVA: 0x008E6664 File Offset: 0x008E4864
		// (set) Token: 0x0601DE63 RID: 122467 RVA: 0x008E66A7 File Offset: 0x008E48A7
		public TMap<FName, FLinearColor> colorCaches
		{
			get
			{
				base.FastCheckIsValid();
				TMap<FName, FLinearColor> result;
				if ((result = this._colorCaches) == null)
				{
					result = (this._colorCaches = new TMap<FName, FLinearColor>(base.NativePtr + (IntPtr)SMaterialParamCache.__PropertyOffset_2, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.colorCaches.CopyAssign(value);
			}
		}

		// Token: 0x170027B8 RID: 10168
		// (get) Token: 0x0601DE64 RID: 122468 RVA: 0x008E66B5 File Offset: 0x008E48B5
		// (set) Token: 0x0601DE65 RID: 122469 RVA: 0x008E66C5 File Offset: 0x008E48C5
		public unsafe int slotIndex
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SMaterialParamCache.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SMaterialParamCache.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x0601DE66 RID: 122470 RVA: 0x008E66D6 File Offset: 0x008E48D6
		public SMaterialParamCache()
		{
		}

		// Token: 0x0601DE67 RID: 122471 RVA: 0x008E66DE File Offset: 0x008E48DE
		public SMaterialParamCache(UMaterialInstanceDynamic sourceMaterial, TMap<FName, float> floatCaches, TMap<FName, FLinearColor> colorCaches, int slotIndex)
		{
			this.sourceMaterial = sourceMaterial;
			this.floatCaches = floatCaches;
			this.colorCaches = colorCaches;
			this.slotIndex = slotIndex;
		}

		// Token: 0x0601DE68 RID: 122472 RVA: 0x008E6703 File Offset: 0x008E4903
		protected override IntPtr GetUStructPtr()
		{
			return SMaterialParamCache.StaticStruct();
		}

		// Token: 0x0601DE69 RID: 122473 RVA: 0x008E670F File Offset: 0x008E490F
		[NullableContext(2)]
		public SMaterialParamCache(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0601DE6A RID: 122474 RVA: 0x008E6719 File Offset: 0x008E4919
		public SMaterialParamCache(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0601DE6B RID: 122475 RVA: 0x008E6724 File Offset: 0x008E4924
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SMaterialParamCache(Pointer, false, true);
		}

		// Token: 0x0601DE6C RID: 122476 RVA: 0x008E672E File Offset: 0x008E492E
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SMaterialParamCache(Pointer, MemoryOwner);
		}

		// Token: 0x0400EA60 RID: 60000
		public const string __ObjectPath = "/Game/Aki/TypeScript/Game/NewWorld/Character/SimpleNpc/Blueprint/SMaterialParamCache.SMaterialParamCache";

		// Token: 0x0400EA61 RID: 60001
		private static IntPtr _ScriptStructPtr;

		// Token: 0x0400EA62 RID: 60002
		internal static int __PropertyOffset_0;

		// Token: 0x0400EA63 RID: 60003
		internal static int __PropertyOffset_1;

		// Token: 0x0400EA64 RID: 60004
		[Nullable(2)]
		private TMap<FName, float> _floatCaches;

		// Token: 0x0400EA65 RID: 60005
		internal static int __PropertyOffset_2;

		// Token: 0x0400EA66 RID: 60006
		[Nullable(2)]
		private TMap<FName, FLinearColor> _colorCaches;

		// Token: 0x0400EA67 RID: 60007
		internal static int __PropertyOffset_3;
	}
}
