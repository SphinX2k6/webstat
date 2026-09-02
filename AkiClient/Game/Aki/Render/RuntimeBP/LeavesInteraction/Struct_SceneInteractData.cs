using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Core.Fight;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.LeavesInteraction
{
	// Token: 0x02003C68 RID: 15464
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/LeavesInteraction/Struct_SceneInteractData.Struct_SceneInteractData")]
	[UnrealStructLayout(24, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 20)]
	public class Struct_SceneInteractData : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06023D3A RID: 146746 RVA: 0x0098D4A7 File Offset: 0x0098B6A7
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (Struct_SceneInteractData._ScriptStructPtr != 0) ? Struct_SceneInteractData._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/LeavesInteraction/Struct_SceneInteractData.Struct_SceneInteractData", ref Struct_SceneInteractData._ScriptStructPtr);
		}

		// Token: 0x17004888 RID: 18568
		// (get) Token: 0x06023D3B RID: 146747 RVA: 0x0098D4CB File Offset: 0x0098B6CB
		// (set) Token: 0x06023D3C RID: 146748 RVA: 0x0098D4DF File Offset: 0x0098B6DF
		[Nullable(2)]
		public unsafe BP_SceneBattleInteract_C DataAsset
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_SceneBattleInteract_C>(base.NativePtr / (IntPtr)sizeof(void*) + Struct_SceneInteractData.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + Struct_SceneInteractData.__PropertyOffset_0, value);
			}
		}

		// Token: 0x17004889 RID: 18569
		// (get) Token: 0x06023D3D RID: 146749 RVA: 0x0098D4F4 File Offset: 0x0098B6F4
		// (set) Token: 0x06023D3E RID: 146750 RVA: 0x0098D504 File Offset: 0x0098B704
		public unsafe float ForceFieldRadius
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Struct_SceneInteractData.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Struct_SceneInteractData.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x1700488A RID: 18570
		// (get) Token: 0x06023D3F RID: 146751 RVA: 0x0098D515 File Offset: 0x0098B715
		// (set) Token: 0x06023D40 RID: 146752 RVA: 0x0098D525 File Offset: 0x0098B725
		public unsafe float RotationalForceField
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Struct_SceneInteractData.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Struct_SceneInteractData.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x1700488B RID: 18571
		// (get) Token: 0x06023D41 RID: 146753 RVA: 0x0098D536 File Offset: 0x0098B736
		// (set) Token: 0x06023D42 RID: 146754 RVA: 0x0098D546 File Offset: 0x0098B746
		public unsafe float CentripetalForceField
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Struct_SceneInteractData.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Struct_SceneInteractData.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x06023D43 RID: 146755 RVA: 0x0098D557 File Offset: 0x0098B757
		public Struct_SceneInteractData()
		{
		}

		// Token: 0x06023D44 RID: 146756 RVA: 0x0098D55F File Offset: 0x0098B75F
		[NullableContext(1)]
		public Struct_SceneInteractData(BP_SceneBattleInteract_C DataAsset, float ForceFieldRadius, float RotationalForceField, float CentripetalForceField)
		{
			this.DataAsset = DataAsset;
			this.ForceFieldRadius = ForceFieldRadius;
			this.RotationalForceField = RotationalForceField;
			this.CentripetalForceField = CentripetalForceField;
		}

		// Token: 0x06023D45 RID: 146757 RVA: 0x0098D584 File Offset: 0x0098B784
		protected override IntPtr GetUStructPtr()
		{
			return Struct_SceneInteractData.StaticStruct();
		}

		// Token: 0x06023D46 RID: 146758 RVA: 0x0098D590 File Offset: 0x0098B790
		[NullableContext(2)]
		public Struct_SceneInteractData(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06023D47 RID: 146759 RVA: 0x0098D59A File Offset: 0x0098B79A
		public Struct_SceneInteractData(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06023D48 RID: 146760 RVA: 0x0098D5A5 File Offset: 0x0098B7A5
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new Struct_SceneInteractData(Pointer, false, true);
		}

		// Token: 0x06023D49 RID: 146761 RVA: 0x0098D5AF File Offset: 0x0098B7AF
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new Struct_SceneInteractData(Pointer, MemoryOwner);
		}

		// Token: 0x040124A8 RID: 74920
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/LeavesInteraction/Struct_SceneInteractData.Struct_SceneInteractData";

		// Token: 0x040124A9 RID: 74921
		private static IntPtr _ScriptStructPtr;

		// Token: 0x040124AA RID: 74922
		internal static int __PropertyOffset_0;

		// Token: 0x040124AB RID: 74923
		internal static int __PropertyOffset_1;

		// Token: 0x040124AC RID: 74924
		internal static int __PropertyOffset_2;

		// Token: 0x040124AD RID: 74925
		internal static int __PropertyOffset_3;
	}
}
