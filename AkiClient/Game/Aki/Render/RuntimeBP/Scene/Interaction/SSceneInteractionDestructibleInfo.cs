using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Fight.Enum;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Interaction
{
	// Token: 0x02003AC5 RID: 15045
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Interaction/SSceneInteractionDestructibleInfo.SSceneInteractionDestructibleInfo")]
	[UnrealStructLayout(40, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 40)]
	public class SSceneInteractionDestructibleInfo : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x060201F5 RID: 131573 RVA: 0x00922C61 File Offset: 0x00920E61
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SSceneInteractionDestructibleInfo._ScriptStructPtr != 0) ? SSceneInteractionDestructibleInfo._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/Scene/Interaction/SSceneInteractionDestructibleInfo.SSceneInteractionDestructibleInfo", ref SSceneInteractionDestructibleInfo._ScriptStructPtr);
		}

		// Token: 0x17003404 RID: 13316
		// (get) Token: 0x060201F6 RID: 131574 RVA: 0x00922C85 File Offset: 0x00920E85
		// (set) Token: 0x060201F7 RID: 131575 RVA: 0x00922C99 File Offset: 0x00920E99
		public unsafe TEnumAsByte<BPELevelPrefabDestructibleHitInfo> HitType
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSceneInteractionDestructibleInfo.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSceneInteractionDestructibleInfo.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17003405 RID: 13317
		// (get) Token: 0x060201F8 RID: 131576 RVA: 0x00922CB0 File Offset: 0x00920EB0
		// (set) Token: 0x060201F9 RID: 131577 RVA: 0x00922CF3 File Offset: 0x00920EF3
		[Nullable(1)]
		public SFloatRangeWithCurve ImpulseStrengthFloatRange
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				SFloatRangeWithCurve result;
				if ((result = this._ImpulseStrengthFloatRange) == null)
				{
					result = (this._ImpulseStrengthFloatRange = new SFloatRangeWithCurve(base.NativePtr + (IntPtr)SSceneInteractionDestructibleInfo.__PropertyOffset_1, base.MemoryOwner ?? this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SFloatRangeWithCurve.StaticStruct(), base.NativePtr + (IntPtr)SSceneInteractionDestructibleInfo.__PropertyOffset_1, value.NativePtr, 1, false);
			}
		}

		// Token: 0x060201FA RID: 131578 RVA: 0x00922D14 File Offset: 0x00920F14
		public SSceneInteractionDestructibleInfo()
		{
		}

		// Token: 0x060201FB RID: 131579 RVA: 0x00922D1C File Offset: 0x00920F1C
		public SSceneInteractionDestructibleInfo(TEnumAsByte<BPELevelPrefabDestructibleHitInfo> HitType, [Nullable(1)] SFloatRangeWithCurve ImpulseStrengthFloatRange)
		{
			this.HitType = HitType;
			this.ImpulseStrengthFloatRange = ImpulseStrengthFloatRange;
		}

		// Token: 0x060201FC RID: 131580 RVA: 0x00922D32 File Offset: 0x00920F32
		protected override IntPtr GetUStructPtr()
		{
			return SSceneInteractionDestructibleInfo.StaticStruct();
		}

		// Token: 0x060201FD RID: 131581 RVA: 0x00922D3E File Offset: 0x00920F3E
		[NullableContext(2)]
		public SSceneInteractionDestructibleInfo(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x060201FE RID: 131582 RVA: 0x00922D48 File Offset: 0x00920F48
		public SSceneInteractionDestructibleInfo(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x060201FF RID: 131583 RVA: 0x00922D53 File Offset: 0x00920F53
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SSceneInteractionDestructibleInfo(Pointer, false, true);
		}

		// Token: 0x06020200 RID: 131584 RVA: 0x00922D5D File Offset: 0x00920F5D
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SSceneInteractionDestructibleInfo(Pointer, MemoryOwner);
		}

		// Token: 0x0401001F RID: 65567
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Interaction/SSceneInteractionDestructibleInfo.SSceneInteractionDestructibleInfo";

		// Token: 0x04010020 RID: 65568
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04010021 RID: 65569
		internal static int __PropertyOffset_0;

		// Token: 0x04010022 RID: 65570
		internal static int __PropertyOffset_1;

		// Token: 0x04010023 RID: 65571
		[Nullable(2)]
		private SFloatRangeWithCurve _ImpulseStrengthFloatRange;
	}
}
