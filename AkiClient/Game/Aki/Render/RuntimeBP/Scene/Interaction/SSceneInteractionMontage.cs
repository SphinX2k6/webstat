using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Interaction
{
	// Token: 0x02003ACA RID: 15050
	[NullableContext(2)]
	[Nullable(0)]
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Interaction/SSceneInteractionMontage.SSceneInteractionMontage")]
	[UnrealStructLayout(24, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 24)]
	public class SSceneInteractionMontage : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602025F RID: 131679 RVA: 0x00923823 File Offset: 0x00921A23
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SSceneInteractionMontage._ScriptStructPtr != 0) ? SSceneInteractionMontage._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/Scene/Interaction/SSceneInteractionMontage.SSceneInteractionMontage", ref SSceneInteractionMontage._ScriptStructPtr);
		}

		// Token: 0x17003425 RID: 13349
		// (get) Token: 0x06020260 RID: 131680 RVA: 0x00923847 File Offset: 0x00921A47
		// (set) Token: 0x06020261 RID: 131681 RVA: 0x0092385B File Offset: 0x00921A5B
		public unsafe ASkeletalMeshActor SkeletalMesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<ASkeletalMeshActor>(base.NativePtr / (IntPtr)sizeof(void*) + SSceneInteractionMontage.__PropertyOffset_0);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + SSceneInteractionMontage.__PropertyOffset_0, value);
			}
		}

		// Token: 0x17003426 RID: 13350
		// (get) Token: 0x06020262 RID: 131682 RVA: 0x00923870 File Offset: 0x00921A70
		// (set) Token: 0x06020263 RID: 131683 RVA: 0x00923884 File Offset: 0x00921A84
		public unsafe UAnimMontage Montage
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UAnimMontage>(base.NativePtr / (IntPtr)sizeof(void*) + SSceneInteractionMontage.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + SSceneInteractionMontage.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17003427 RID: 13351
		// (get) Token: 0x06020264 RID: 131684 RVA: 0x00923899 File Offset: 0x00921A99
		// (set) Token: 0x06020265 RID: 131685 RVA: 0x009238A9 File Offset: 0x00921AA9
		public unsafe bool Loop
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSceneInteractionMontage.__PropertyOffset_2) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSceneInteractionMontage.__PropertyOffset_2) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003428 RID: 13352
		// (get) Token: 0x06020266 RID: 131686 RVA: 0x009238BA File Offset: 0x00921ABA
		// (set) Token: 0x06020267 RID: 131687 RVA: 0x009238CA File Offset: 0x00921ACA
		public unsafe float PlayRate
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSceneInteractionMontage.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSceneInteractionMontage.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x06020268 RID: 131688 RVA: 0x009238DB File Offset: 0x00921ADB
		public SSceneInteractionMontage()
		{
		}

		// Token: 0x06020269 RID: 131689 RVA: 0x009238E3 File Offset: 0x00921AE3
		[NullableContext(1)]
		public SSceneInteractionMontage(ASkeletalMeshActor SkeletalMesh, UAnimMontage Montage, bool Loop, float PlayRate)
		{
			this.SkeletalMesh = SkeletalMesh;
			this.Montage = Montage;
			this.Loop = Loop;
			this.PlayRate = PlayRate;
		}

		// Token: 0x0602026A RID: 131690 RVA: 0x00923908 File Offset: 0x00921B08
		protected override IntPtr GetUStructPtr()
		{
			return SSceneInteractionMontage.StaticStruct();
		}

		// Token: 0x0602026B RID: 131691 RVA: 0x00923914 File Offset: 0x00921B14
		public SSceneInteractionMontage(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602026C RID: 131692 RVA: 0x0092391E File Offset: 0x00921B1E
		public SSceneInteractionMontage(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602026D RID: 131693 RVA: 0x00923929 File Offset: 0x00921B29
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SSceneInteractionMontage(Pointer, false, true);
		}

		// Token: 0x0602026E RID: 131694 RVA: 0x00923933 File Offset: 0x00921B33
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SSceneInteractionMontage(Pointer, MemoryOwner);
		}

		// Token: 0x0401005E RID: 65630
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Interaction/SSceneInteractionMontage.SSceneInteractionMontage";

		// Token: 0x0401005F RID: 65631
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04010060 RID: 65632
		internal static int __PropertyOffset_0;

		// Token: 0x04010061 RID: 65633
		internal static int __PropertyOffset_1;

		// Token: 0x04010062 RID: 65634
		internal static int __PropertyOffset_2;

		// Token: 0x04010063 RID: 65635
		internal static int __PropertyOffset_3;
	}
}
