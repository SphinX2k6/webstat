using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Interaction
{
	// Token: 0x02003ACB RID: 15051
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Interaction/SSceneInteractionSequence.SSceneInteractionSequence")]
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 16)]
	public class SSceneInteractionSequence : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602026F RID: 131695 RVA: 0x0092393C File Offset: 0x00921B3C
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SSceneInteractionSequence._ScriptStructPtr != 0) ? SSceneInteractionSequence._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/Scene/Interaction/SSceneInteractionSequence.SSceneInteractionSequence", ref SSceneInteractionSequence._ScriptStructPtr);
		}

		// Token: 0x17003429 RID: 13353
		// (get) Token: 0x06020270 RID: 131696 RVA: 0x00923960 File Offset: 0x00921B60
		// (set) Token: 0x06020271 RID: 131697 RVA: 0x00923974 File Offset: 0x00921B74
		[Nullable(2)]
		public unsafe ULevelSequence Sequence
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<ULevelSequence>(base.NativePtr / (IntPtr)sizeof(void*) + SSceneInteractionSequence.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + SSceneInteractionSequence.__PropertyOffset_0, value);
			}
		}

		// Token: 0x1700342A RID: 13354
		// (get) Token: 0x06020272 RID: 131698 RVA: 0x00923989 File Offset: 0x00921B89
		// (set) Token: 0x06020273 RID: 131699 RVA: 0x00923999 File Offset: 0x00921B99
		public unsafe bool IsLoop
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSceneInteractionSequence.__PropertyOffset_1) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSceneInteractionSequence.__PropertyOffset_1) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700342B RID: 13355
		// (get) Token: 0x06020274 RID: 131700 RVA: 0x009239AA File Offset: 0x00921BAA
		// (set) Token: 0x06020275 RID: 131701 RVA: 0x009239BA File Offset: 0x00921BBA
		public unsafe bool Reverse
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSceneInteractionSequence.__PropertyOffset_2) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSceneInteractionSequence.__PropertyOffset_2) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700342C RID: 13356
		// (get) Token: 0x06020276 RID: 131702 RVA: 0x009239CB File Offset: 0x00921BCB
		// (set) Token: 0x06020277 RID: 131703 RVA: 0x009239DB File Offset: 0x00921BDB
		public unsafe float PlayRate
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSceneInteractionSequence.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSceneInteractionSequence.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x06020278 RID: 131704 RVA: 0x009239EC File Offset: 0x00921BEC
		public SSceneInteractionSequence()
		{
		}

		// Token: 0x06020279 RID: 131705 RVA: 0x009239F4 File Offset: 0x00921BF4
		[NullableContext(1)]
		public SSceneInteractionSequence(ULevelSequence Sequence, bool IsLoop, bool Reverse, float PlayRate)
		{
			this.Sequence = Sequence;
			this.IsLoop = IsLoop;
			this.Reverse = Reverse;
			this.PlayRate = PlayRate;
		}

		// Token: 0x0602027A RID: 131706 RVA: 0x00923A19 File Offset: 0x00921C19
		protected override IntPtr GetUStructPtr()
		{
			return SSceneInteractionSequence.StaticStruct();
		}

		// Token: 0x0602027B RID: 131707 RVA: 0x00923A25 File Offset: 0x00921C25
		[NullableContext(2)]
		public SSceneInteractionSequence(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602027C RID: 131708 RVA: 0x00923A2F File Offset: 0x00921C2F
		public SSceneInteractionSequence(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602027D RID: 131709 RVA: 0x00923A3A File Offset: 0x00921C3A
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SSceneInteractionSequence(Pointer, false, true);
		}

		// Token: 0x0602027E RID: 131710 RVA: 0x00923A44 File Offset: 0x00921C44
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SSceneInteractionSequence(Pointer, MemoryOwner);
		}

		// Token: 0x04010064 RID: 65636
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Interaction/SSceneInteractionSequence.SSceneInteractionSequence";

		// Token: 0x04010065 RID: 65637
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04010066 RID: 65638
		internal static int __PropertyOffset_0;

		// Token: 0x04010067 RID: 65639
		internal static int __PropertyOffset_1;

		// Token: 0x04010068 RID: 65640
		internal static int __PropertyOffset_2;

		// Token: 0x04010069 RID: 65641
		internal static int __PropertyOffset_3;
	}
}
