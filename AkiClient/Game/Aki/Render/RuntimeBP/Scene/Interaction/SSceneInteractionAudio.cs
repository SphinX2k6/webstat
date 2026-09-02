using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Interaction
{
	// Token: 0x02003AC3 RID: 15043
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Interaction/SSceneInteractionAudio.SSceneInteractionAudio")]
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 10)]
	public class SSceneInteractionAudio : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x060201DB RID: 131547 RVA: 0x00922AB9 File Offset: 0x00920CB9
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SSceneInteractionAudio._ScriptStructPtr != 0) ? SSceneInteractionAudio._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/Scene/Interaction/SSceneInteractionAudio.SSceneInteractionAudio", ref SSceneInteractionAudio._ScriptStructPtr);
		}

		// Token: 0x170033FF RID: 13311
		// (get) Token: 0x060201DC RID: 131548 RVA: 0x00922ADD File Offset: 0x00920CDD
		// (set) Token: 0x060201DD RID: 131549 RVA: 0x00922AF1 File Offset: 0x00920CF1
		[Nullable(2)]
		public unsafe UAkAudioEvent AkEvent
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UAkAudioEvent>(base.NativePtr / (IntPtr)sizeof(void*) + SSceneInteractionAudio.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + SSceneInteractionAudio.__PropertyOffset_0, value);
			}
		}

		// Token: 0x17003400 RID: 13312
		// (get) Token: 0x060201DE RID: 131550 RVA: 0x00922B06 File Offset: 0x00920D06
		// (set) Token: 0x060201DF RID: 131551 RVA: 0x00922B16 File Offset: 0x00920D16
		public unsafe bool IsFollow
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSceneInteractionAudio.__PropertyOffset_1) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSceneInteractionAudio.__PropertyOffset_1) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003401 RID: 13313
		// (get) Token: 0x060201E0 RID: 131552 RVA: 0x00922B27 File Offset: 0x00920D27
		// (set) Token: 0x060201E1 RID: 131553 RVA: 0x00922B37 File Offset: 0x00920D37
		public unsafe bool AutoMerge
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSceneInteractionAudio.__PropertyOffset_2) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSceneInteractionAudio.__PropertyOffset_2) = (value ? 1 : 0);
			}
		}

		// Token: 0x060201E2 RID: 131554 RVA: 0x00922B48 File Offset: 0x00920D48
		public SSceneInteractionAudio()
		{
		}

		// Token: 0x060201E3 RID: 131555 RVA: 0x00922B50 File Offset: 0x00920D50
		[NullableContext(1)]
		public SSceneInteractionAudio(UAkAudioEvent AkEvent, bool IsFollow, bool AutoMerge)
		{
			this.AkEvent = AkEvent;
			this.IsFollow = IsFollow;
			this.AutoMerge = AutoMerge;
		}

		// Token: 0x060201E4 RID: 131556 RVA: 0x00922B6D File Offset: 0x00920D6D
		protected override IntPtr GetUStructPtr()
		{
			return SSceneInteractionAudio.StaticStruct();
		}

		// Token: 0x060201E5 RID: 131557 RVA: 0x00922B79 File Offset: 0x00920D79
		[NullableContext(2)]
		public SSceneInteractionAudio(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x060201E6 RID: 131558 RVA: 0x00922B83 File Offset: 0x00920D83
		public SSceneInteractionAudio(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x060201E7 RID: 131559 RVA: 0x00922B8E File Offset: 0x00920D8E
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SSceneInteractionAudio(Pointer, false, true);
		}

		// Token: 0x060201E8 RID: 131560 RVA: 0x00922B98 File Offset: 0x00920D98
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SSceneInteractionAudio(Pointer, MemoryOwner);
		}

		// Token: 0x04010016 RID: 65558
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Interaction/SSceneInteractionAudio.SSceneInteractionAudio";

		// Token: 0x04010017 RID: 65559
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04010018 RID: 65560
		internal static int __PropertyOffset_0;

		// Token: 0x04010019 RID: 65561
		internal static int __PropertyOffset_1;

		// Token: 0x0401001A RID: 65562
		internal static int __PropertyOffset_2;
	}
}
