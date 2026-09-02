using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Effect;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Interaction
{
	// Token: 0x02003ACD RID: 15053
	[NullableContext(1)]
	[Nullable(0)]
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Interaction/SScenePropertyEffect.SScenePropertyEffect")]
	[UnrealStructLayout(56, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 56)]
	public class SScenePropertyEffect : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x060202A5 RID: 131749 RVA: 0x00924028 File Offset: 0x00922228
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SScenePropertyEffect._ScriptStructPtr != 0) ? SScenePropertyEffect._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/Scene/Interaction/SScenePropertyEffect.SScenePropertyEffect", ref SScenePropertyEffect._ScriptStructPtr);
		}

		// Token: 0x1700343C RID: 13372
		// (get) Token: 0x060202A6 RID: 131750 RVA: 0x0092404C File Offset: 0x0092224C
		// (set) Token: 0x060202A7 RID: 131751 RVA: 0x0092408F File Offset: 0x0092228F
		public SSceneInteractionMaterialController Material
		{
			get
			{
				base.FastCheckIsValid();
				SSceneInteractionMaterialController result;
				if ((result = this._Material) == null)
				{
					result = (this._Material = new SSceneInteractionMaterialController(base.NativePtr + (IntPtr)SScenePropertyEffect.__PropertyOffset_0, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SSceneInteractionMaterialController.StaticStruct(), base.NativePtr + (IntPtr)SScenePropertyEffect.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700343D RID: 13373
		// (get) Token: 0x060202A8 RID: 131752 RVA: 0x009240B0 File Offset: 0x009222B0
		// (set) Token: 0x060202A9 RID: 131753 RVA: 0x009240C4 File Offset: 0x009222C4
		[Nullable(2)]
		public unsafe BP_EffectActor_C Effect
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_EffectActor_C>(base.NativePtr / (IntPtr)sizeof(void*) + SScenePropertyEffect.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + SScenePropertyEffect.__PropertyOffset_1, value);
			}
		}

		// Token: 0x060202AA RID: 131754 RVA: 0x009240D9 File Offset: 0x009222D9
		public SScenePropertyEffect()
		{
		}

		// Token: 0x060202AB RID: 131755 RVA: 0x009240E1 File Offset: 0x009222E1
		public SScenePropertyEffect(SSceneInteractionMaterialController Material, BP_EffectActor_C Effect)
		{
			this.Material = Material;
			this.Effect = Effect;
		}

		// Token: 0x060202AC RID: 131756 RVA: 0x009240F7 File Offset: 0x009222F7
		protected override IntPtr GetUStructPtr()
		{
			return SScenePropertyEffect.StaticStruct();
		}

		// Token: 0x060202AD RID: 131757 RVA: 0x00924103 File Offset: 0x00922303
		[NullableContext(2)]
		public SScenePropertyEffect(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x060202AE RID: 131758 RVA: 0x0092410D File Offset: 0x0092230D
		public SScenePropertyEffect(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x060202AF RID: 131759 RVA: 0x00924118 File Offset: 0x00922318
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SScenePropertyEffect(Pointer, false, true);
		}

		// Token: 0x060202B0 RID: 131760 RVA: 0x00924122 File Offset: 0x00922322
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SScenePropertyEffect(Pointer, MemoryOwner);
		}

		// Token: 0x04010089 RID: 65673
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Interaction/SScenePropertyEffect.SScenePropertyEffect";

		// Token: 0x0401008A RID: 65674
		private static IntPtr _ScriptStructPtr;

		// Token: 0x0401008B RID: 65675
		internal static int __PropertyOffset_0;

		// Token: 0x0401008C RID: 65676
		[Nullable(2)]
		private SSceneInteractionMaterialController _Material;

		// Token: 0x0401008D RID: 65677
		internal static int __PropertyOffset_1;
	}
}
