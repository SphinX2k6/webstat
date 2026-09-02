using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Interaction
{
	// Token: 0x02003AC1 RID: 15041
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Interaction/SSceneInteractionActorProjection.SSceneInteractionActorProjection")]
	[UnrealStructLayout(40, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 40)]
	public class SSceneInteractionActorProjection : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x060201BF RID: 131519 RVA: 0x009227E4 File Offset: 0x009209E4
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SSceneInteractionActorProjection._ScriptStructPtr != 0) ? SSceneInteractionActorProjection._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/Scene/Interaction/SSceneInteractionActorProjection.SSceneInteractionActorProjection", ref SSceneInteractionActorProjection._ScriptStructPtr);
		}

		// Token: 0x170033F9 RID: 13305
		// (get) Token: 0x060201C0 RID: 131520 RVA: 0x00922808 File Offset: 0x00920A08
		// (set) Token: 0x060201C1 RID: 131521 RVA: 0x0092284B File Offset: 0x00920A4B
		public TArray<bool> IsProjection
		{
			get
			{
				base.FastCheckIsValid();
				TArray<bool> result;
				if ((result = this._IsProjection) == null)
				{
					result = (this._IsProjection = new TArray<bool>(base.NativePtr + (IntPtr)SSceneInteractionActorProjection.__PropertyOffset_0, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.IsProjection.CopyAssign(value);
			}
		}

		// Token: 0x170033FA RID: 13306
		// (get) Token: 0x060201C2 RID: 131522 RVA: 0x0092285C File Offset: 0x00920A5C
		// (set) Token: 0x060201C3 RID: 131523 RVA: 0x0092289F File Offset: 0x00920A9F
		public TArray<FTransform> Transform
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FTransform> result;
				if ((result = this._Transform) == null)
				{
					result = (this._Transform = new TArray<FTransform>(base.NativePtr + (IntPtr)SSceneInteractionActorProjection.__PropertyOffset_1, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.Transform.CopyAssign(value);
			}
		}

		// Token: 0x170033FB RID: 13307
		// (get) Token: 0x060201C4 RID: 131524 RVA: 0x009228AD File Offset: 0x00920AAD
		// (set) Token: 0x060201C5 RID: 131525 RVA: 0x009228C1 File Offset: 0x00920AC1
		[Nullable(2)]
		public unsafe ItemMaterialControllerActorData MaterialController
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<ItemMaterialControllerActorData>(base.NativePtr / (IntPtr)sizeof(void*) + SSceneInteractionActorProjection.__PropertyOffset_2);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + SSceneInteractionActorProjection.__PropertyOffset_2, value);
			}
		}

		// Token: 0x060201C6 RID: 131526 RVA: 0x009228D6 File Offset: 0x00920AD6
		public SSceneInteractionActorProjection()
		{
		}

		// Token: 0x060201C7 RID: 131527 RVA: 0x009228DE File Offset: 0x00920ADE
		public SSceneInteractionActorProjection(TArray<bool> IsProjection, TArray<FTransform> Transform, ItemMaterialControllerActorData MaterialController)
		{
			this.IsProjection = IsProjection;
			this.Transform = Transform;
			this.MaterialController = MaterialController;
		}

		// Token: 0x060201C8 RID: 131528 RVA: 0x009228FB File Offset: 0x00920AFB
		protected override IntPtr GetUStructPtr()
		{
			return SSceneInteractionActorProjection.StaticStruct();
		}

		// Token: 0x060201C9 RID: 131529 RVA: 0x00922907 File Offset: 0x00920B07
		[NullableContext(2)]
		public SSceneInteractionActorProjection(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x060201CA RID: 131530 RVA: 0x00922911 File Offset: 0x00920B11
		public SSceneInteractionActorProjection(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x060201CB RID: 131531 RVA: 0x0092291C File Offset: 0x00920B1C
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SSceneInteractionActorProjection(Pointer, false, true);
		}

		// Token: 0x060201CC RID: 131532 RVA: 0x00922926 File Offset: 0x00920B26
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SSceneInteractionActorProjection(Pointer, MemoryOwner);
		}

		// Token: 0x04010007 RID: 65543
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Interaction/SSceneInteractionActorProjection.SSceneInteractionActorProjection";

		// Token: 0x04010008 RID: 65544
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04010009 RID: 65545
		internal static int __PropertyOffset_0;

		// Token: 0x0401000A RID: 65546
		[Nullable(2)]
		private TArray<bool> _IsProjection;

		// Token: 0x0401000B RID: 65547
		internal static int __PropertyOffset_1;

		// Token: 0x0401000C RID: 65548
		[Nullable(2)]
		private TArray<FTransform> _Transform;

		// Token: 0x0401000D RID: 65549
		internal static int __PropertyOffset_2;
	}
}
