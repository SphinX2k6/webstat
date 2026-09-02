using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Sequence.Manager.Structures
{
	// Token: 0x020043B0 RID: 17328
	[UnrealObjectPath("/Game/Aki/Sequence/Manager/Structures/SSeqCharacterBlend.SSeqCharacterBlend")]
	[UnrealStructLayout(96, 16, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 84)]
	public class SSeqCharacterBlend : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602E188 RID: 188808 RVA: 0x00AD6A7C File Offset: 0x00AD4C7C
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SSeqCharacterBlend._ScriptStructPtr != 0) ? SSeqCharacterBlend._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Sequence/Manager/Structures/SSeqCharacterBlend.SSeqCharacterBlend", ref SSeqCharacterBlend._ScriptStructPtr);
		}

		// Token: 0x17007EFF RID: 32511
		// (get) Token: 0x0602E189 RID: 188809 RVA: 0x00AD6AA0 File Offset: 0x00AD4CA0
		// (set) Token: 0x0602E18A RID: 188810 RVA: 0x00AD6AB4 File Offset: 0x00AD4CB4
		public unsafe FName TargetTag
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSeqCharacterBlend.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSeqCharacterBlend.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17007F00 RID: 32512
		// (get) Token: 0x0602E18B RID: 188811 RVA: 0x00AD6AC9 File Offset: 0x00AD4CC9
		// (set) Token: 0x0602E18C RID: 188812 RVA: 0x00AD6ADD File Offset: 0x00AD4CDD
		public unsafe FTransform Transform
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSeqCharacterBlend.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSeqCharacterBlend.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17007F01 RID: 32513
		// (get) Token: 0x0602E18D RID: 188813 RVA: 0x00AD6AF2 File Offset: 0x00AD4CF2
		// (set) Token: 0x0602E18E RID: 188814 RVA: 0x00AD6B02 File Offset: 0x00AD4D02
		public unsafe float BlendTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSeqCharacterBlend.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSeqCharacterBlend.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17007F02 RID: 32514
		// (get) Token: 0x0602E18F RID: 188815 RVA: 0x00AD6B13 File Offset: 0x00AD4D13
		// (set) Token: 0x0602E190 RID: 188816 RVA: 0x00AD6B27 File Offset: 0x00AD4D27
		[Nullable(2)]
		public unsafe AActor Target
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + SSeqCharacterBlend.__PropertyOffset_3);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + SSeqCharacterBlend.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17007F03 RID: 32515
		// (get) Token: 0x0602E191 RID: 188817 RVA: 0x00AD6B3C File Offset: 0x00AD4D3C
		// (set) Token: 0x0602E192 RID: 188818 RVA: 0x00AD6B4C File Offset: 0x00AD4D4C
		public unsafe float BlendAlpha
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSeqCharacterBlend.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSeqCharacterBlend.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x0602E193 RID: 188819 RVA: 0x00AD6B5D File Offset: 0x00AD4D5D
		public SSeqCharacterBlend()
		{
		}

		// Token: 0x0602E194 RID: 188820 RVA: 0x00AD6B65 File Offset: 0x00AD4D65
		[NullableContext(1)]
		public SSeqCharacterBlend(FName TargetTag, FTransform Transform, float BlendTime, AActor Target, float BlendAlpha)
		{
			this.TargetTag = TargetTag;
			this.Transform = Transform;
			this.BlendTime = BlendTime;
			this.Target = Target;
			this.BlendAlpha = BlendAlpha;
		}

		// Token: 0x0602E195 RID: 188821 RVA: 0x00AD6B92 File Offset: 0x00AD4D92
		protected override IntPtr GetUStructPtr()
		{
			return SSeqCharacterBlend.StaticStruct();
		}

		// Token: 0x0602E196 RID: 188822 RVA: 0x00AD6B9E File Offset: 0x00AD4D9E
		[NullableContext(2)]
		public SSeqCharacterBlend(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602E197 RID: 188823 RVA: 0x00AD6BA8 File Offset: 0x00AD4DA8
		public SSeqCharacterBlend(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602E198 RID: 188824 RVA: 0x00AD6BB3 File Offset: 0x00AD4DB3
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SSeqCharacterBlend(Pointer, false, true);
		}

		// Token: 0x0602E199 RID: 188825 RVA: 0x00AD6BBD File Offset: 0x00AD4DBD
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SSeqCharacterBlend(Pointer, MemoryOwner);
		}

		// Token: 0x0401A0E9 RID: 106729
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Sequence/Manager/Structures/SSeqCharacterBlend.SSeqCharacterBlend";

		// Token: 0x0401A0EA RID: 106730
		private static IntPtr _ScriptStructPtr;

		// Token: 0x0401A0EB RID: 106731
		internal static int __PropertyOffset_0;

		// Token: 0x0401A0EC RID: 106732
		internal static int __PropertyOffset_1;

		// Token: 0x0401A0ED RID: 106733
		internal static int __PropertyOffset_2;

		// Token: 0x0401A0EE RID: 106734
		internal static int __PropertyOffset_3;

		// Token: 0x0401A0EF RID: 106735
		internal static int __PropertyOffset_4;
	}
}
