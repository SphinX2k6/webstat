using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Character.Npc
{
	// Token: 0x02003D6D RID: 15725
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Character/Npc/SNpcHookPartMaterial.SNpcHookPartMaterial")]
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 16)]
	public class SNpcHookPartMaterial : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x060264DE RID: 156894 RVA: 0x009D491E File Offset: 0x009D2B1E
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SNpcHookPartMaterial._ScriptStructPtr != 0) ? SNpcHookPartMaterial._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/Character/Npc/SNpcHookPartMaterial.SNpcHookPartMaterial", ref SNpcHookPartMaterial._ScriptStructPtr);
		}

		// Token: 0x1700568C RID: 22156
		// (get) Token: 0x060264DF RID: 156895 RVA: 0x009D4942 File Offset: 0x009D2B42
		// (set) Token: 0x060264E0 RID: 156896 RVA: 0x009D4952 File Offset: 0x009D2B52
		public unsafe int SlotID
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SNpcHookPartMaterial.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SNpcHookPartMaterial.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x1700568D RID: 22157
		// (get) Token: 0x060264E1 RID: 156897 RVA: 0x009D4963 File Offset: 0x009D2B63
		// (set) Token: 0x060264E2 RID: 156898 RVA: 0x009D4977 File Offset: 0x009D2B77
		[Nullable(2)]
		public unsafe UMaterialInstance Material
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + SNpcHookPartMaterial.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + SNpcHookPartMaterial.__PropertyOffset_1, value);
			}
		}

		// Token: 0x060264E3 RID: 156899 RVA: 0x009D498C File Offset: 0x009D2B8C
		public SNpcHookPartMaterial()
		{
		}

		// Token: 0x060264E4 RID: 156900 RVA: 0x009D4994 File Offset: 0x009D2B94
		[NullableContext(1)]
		public SNpcHookPartMaterial(int SlotID, UMaterialInstance Material)
		{
			this.SlotID = SlotID;
			this.Material = Material;
		}

		// Token: 0x060264E5 RID: 156901 RVA: 0x009D49AA File Offset: 0x009D2BAA
		protected override IntPtr GetUStructPtr()
		{
			return SNpcHookPartMaterial.StaticStruct();
		}

		// Token: 0x060264E6 RID: 156902 RVA: 0x009D49B6 File Offset: 0x009D2BB6
		[NullableContext(2)]
		public SNpcHookPartMaterial(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x060264E7 RID: 156903 RVA: 0x009D49C0 File Offset: 0x009D2BC0
		public SNpcHookPartMaterial(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x060264E8 RID: 156904 RVA: 0x009D49CB File Offset: 0x009D2BCB
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SNpcHookPartMaterial(Pointer, false, true);
		}

		// Token: 0x060264E9 RID: 156905 RVA: 0x009D49D5 File Offset: 0x009D2BD5
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SNpcHookPartMaterial(Pointer, MemoryOwner);
		}

		// Token: 0x04013DEE RID: 81390
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Character/Npc/SNpcHookPartMaterial.SNpcHookPartMaterial";

		// Token: 0x04013DEF RID: 81391
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04013DF0 RID: 81392
		internal static int __PropertyOffset_0;

		// Token: 0x04013DF1 RID: 81393
		internal static int __PropertyOffset_1;
	}
}
