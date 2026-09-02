using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Interaction
{
	// Token: 0x02003AC8 RID: 15048
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Interaction/SSceneInteractionMaterialController.SSceneInteractionMaterialController")]
	[UnrealStructLayout(48, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 41)]
	public class SSceneInteractionMaterialController : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06020241 RID: 131649 RVA: 0x00923593 File Offset: 0x00921793
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SSceneInteractionMaterialController._ScriptStructPtr != 0) ? SSceneInteractionMaterialController._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/Scene/Interaction/SSceneInteractionMaterialController.SSceneInteractionMaterialController", ref SSceneInteractionMaterialController._ScriptStructPtr);
		}

		// Token: 0x1700341E RID: 13342
		// (get) Token: 0x06020242 RID: 131650 RVA: 0x009235B8 File Offset: 0x009217B8
		// (set) Token: 0x06020243 RID: 131651 RVA: 0x009235FB File Offset: 0x009217FB
		public TArray<AActor> Actors
		{
			get
			{
				base.FastCheckIsValid();
				TArray<AActor> result;
				if ((result = this._Actors) == null)
				{
					result = (this._Actors = new TArray<AActor>(base.NativePtr + (IntPtr)SSceneInteractionMaterialController.__PropertyOffset_0, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.Actors.CopyAssign(value);
			}
		}

		// Token: 0x1700341F RID: 13343
		// (get) Token: 0x06020244 RID: 131652 RVA: 0x00923609 File Offset: 0x00921809
		// (set) Token: 0x06020245 RID: 131653 RVA: 0x0092361D File Offset: 0x0092181D
		[Nullable(2)]
		public unsafe ItemMaterialControllerActorData Data
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<ItemMaterialControllerActorData>(base.NativePtr / (IntPtr)sizeof(void*) + SSceneInteractionMaterialController.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + SSceneInteractionMaterialController.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17003420 RID: 13344
		// (get) Token: 0x06020246 RID: 131654 RVA: 0x00923632 File Offset: 0x00921832
		// (set) Token: 0x06020247 RID: 131655 RVA: 0x00923642 File Offset: 0x00921842
		public unsafe float TailIndex
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSceneInteractionMaterialController.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSceneInteractionMaterialController.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17003421 RID: 13345
		// (get) Token: 0x06020248 RID: 131656 RVA: 0x00923653 File Offset: 0x00921853
		// (set) Token: 0x06020249 RID: 131657 RVA: 0x00923667 File Offset: 0x00921867
		[Nullable(2)]
		public unsafe UMaterialInstance Materials
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + SSceneInteractionMaterialController.__PropertyOffset_3);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + SSceneInteractionMaterialController.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17003422 RID: 13346
		// (get) Token: 0x0602024A RID: 131658 RVA: 0x0092367C File Offset: 0x0092187C
		// (set) Token: 0x0602024B RID: 131659 RVA: 0x0092368C File Offset: 0x0092188C
		public unsafe bool IsRevertMaterial
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSceneInteractionMaterialController.__PropertyOffset_4) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSceneInteractionMaterialController.__PropertyOffset_4) = (value ? 1 : 0);
			}
		}

		// Token: 0x0602024C RID: 131660 RVA: 0x0092369D File Offset: 0x0092189D
		public SSceneInteractionMaterialController()
		{
		}

		// Token: 0x0602024D RID: 131661 RVA: 0x009236A5 File Offset: 0x009218A5
		public SSceneInteractionMaterialController(TArray<AActor> Actors, ItemMaterialControllerActorData Data, float TailIndex, UMaterialInstance Materials, bool IsRevertMaterial)
		{
			this.Actors = Actors;
			this.Data = Data;
			this.TailIndex = TailIndex;
			this.Materials = Materials;
			this.IsRevertMaterial = IsRevertMaterial;
		}

		// Token: 0x0602024E RID: 131662 RVA: 0x009236D2 File Offset: 0x009218D2
		protected override IntPtr GetUStructPtr()
		{
			return SSceneInteractionMaterialController.StaticStruct();
		}

		// Token: 0x0602024F RID: 131663 RVA: 0x009236DE File Offset: 0x009218DE
		[NullableContext(2)]
		public SSceneInteractionMaterialController(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06020250 RID: 131664 RVA: 0x009236E8 File Offset: 0x009218E8
		public SSceneInteractionMaterialController(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06020251 RID: 131665 RVA: 0x009236F3 File Offset: 0x009218F3
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SSceneInteractionMaterialController(Pointer, false, true);
		}

		// Token: 0x06020252 RID: 131666 RVA: 0x009236FD File Offset: 0x009218FD
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SSceneInteractionMaterialController(Pointer, MemoryOwner);
		}

		// Token: 0x04010050 RID: 65616
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Interaction/SSceneInteractionMaterialController.SSceneInteractionMaterialController";

		// Token: 0x04010051 RID: 65617
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04010052 RID: 65618
		internal static int __PropertyOffset_0;

		// Token: 0x04010053 RID: 65619
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<AActor> _Actors;

		// Token: 0x04010054 RID: 65620
		internal static int __PropertyOffset_1;

		// Token: 0x04010055 RID: 65621
		internal static int __PropertyOffset_2;

		// Token: 0x04010056 RID: 65622
		internal static int __PropertyOffset_3;

		// Token: 0x04010057 RID: 65623
		internal static int __PropertyOffset_4;
	}
}
