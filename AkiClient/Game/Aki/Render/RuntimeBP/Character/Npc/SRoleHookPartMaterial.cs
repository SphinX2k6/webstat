using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Character.Npc
{
	// Token: 0x02003D70 RID: 15728
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Character/Npc/SRoleHookPartMaterial.SRoleHookPartMaterial")]
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 16)]
	public class SRoleHookPartMaterial : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06026504 RID: 156932 RVA: 0x009D4C1E File Offset: 0x009D2E1E
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SRoleHookPartMaterial._ScriptStructPtr != 0) ? SRoleHookPartMaterial._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/Character/Npc/SRoleHookPartMaterial.SRoleHookPartMaterial", ref SRoleHookPartMaterial._ScriptStructPtr);
		}

		// Token: 0x17005693 RID: 22163
		// (get) Token: 0x06026505 RID: 156933 RVA: 0x009D4C42 File Offset: 0x009D2E42
		// (set) Token: 0x06026506 RID: 156934 RVA: 0x009D4C52 File Offset: 0x009D2E52
		public unsafe int SlotID
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SRoleHookPartMaterial.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SRoleHookPartMaterial.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17005694 RID: 22164
		// (get) Token: 0x06026507 RID: 156935 RVA: 0x009D4C63 File Offset: 0x009D2E63
		// (set) Token: 0x06026508 RID: 156936 RVA: 0x009D4C77 File Offset: 0x009D2E77
		[Nullable(2)]
		public unsafe UMaterialInstance Material
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + SRoleHookPartMaterial.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + SRoleHookPartMaterial.__PropertyOffset_1, value);
			}
		}

		// Token: 0x06026509 RID: 156937 RVA: 0x009D4C8C File Offset: 0x009D2E8C
		public SRoleHookPartMaterial()
		{
		}

		// Token: 0x0602650A RID: 156938 RVA: 0x009D4C94 File Offset: 0x009D2E94
		[NullableContext(1)]
		public SRoleHookPartMaterial(int SlotID, UMaterialInstance Material)
		{
			this.SlotID = SlotID;
			this.Material = Material;
		}

		// Token: 0x0602650B RID: 156939 RVA: 0x009D4CAA File Offset: 0x009D2EAA
		protected override IntPtr GetUStructPtr()
		{
			return SRoleHookPartMaterial.StaticStruct();
		}

		// Token: 0x0602650C RID: 156940 RVA: 0x009D4CB6 File Offset: 0x009D2EB6
		[NullableContext(2)]
		public SRoleHookPartMaterial(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602650D RID: 156941 RVA: 0x009D4CC0 File Offset: 0x009D2EC0
		public SRoleHookPartMaterial(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602650E RID: 156942 RVA: 0x009D4CCB File Offset: 0x009D2ECB
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SRoleHookPartMaterial(Pointer, false, true);
		}

		// Token: 0x0602650F RID: 156943 RVA: 0x009D4CD5 File Offset: 0x009D2ED5
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SRoleHookPartMaterial(Pointer, MemoryOwner);
		}

		// Token: 0x04013DFE RID: 81406
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Character/Npc/SRoleHookPartMaterial.SRoleHookPartMaterial";

		// Token: 0x04013DFF RID: 81407
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04013E00 RID: 81408
		internal static int __PropertyOffset_0;

		// Token: 0x04013E01 RID: 81409
		internal static int __PropertyOffset_1;
	}
}
