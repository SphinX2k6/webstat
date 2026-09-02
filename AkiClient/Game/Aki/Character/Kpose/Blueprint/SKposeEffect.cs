using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Character.Kpose.Blueprint
{
	// Token: 0x020041A3 RID: 16803
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/Kpose/Blueprint/SKposeEffect.SKposeEffect")]
	[UnrealStructLayout(128, 16, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 128)]
	public class SKposeEffect : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602C9BD RID: 182717 RVA: 0x00AA7E9B File Offset: 0x00AA609B
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SKposeEffect._ScriptStructPtr != 0) ? SKposeEffect._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/Kpose/Blueprint/SKposeEffect.SKposeEffect", ref SKposeEffect._ScriptStructPtr);
		}

		// Token: 0x17007847 RID: 30791
		// (get) Token: 0x0602C9BE RID: 182718 RVA: 0x00AA7EBF File Offset: 0x00AA60BF
		// (set) Token: 0x0602C9BF RID: 182719 RVA: 0x00AA7EDE File Offset: 0x00AA60DE
		public TSoftObjectPtr<UEffectModelBase> EffectData
		{
			get
			{
				return new TSoftObjectPtr<UEffectModelBase>(base.NativePtr + (IntPtr)SKposeEffect.__PropertyOffset_0, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SKposeEffect.__PropertyOffset_0, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17007848 RID: 30792
		// (get) Token: 0x0602C9C0 RID: 182720 RVA: 0x00AA7F03 File Offset: 0x00AA6103
		// (set) Token: 0x0602C9C1 RID: 182721 RVA: 0x00AA7F13 File Offset: 0x00AA6113
		public unsafe bool Attach
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SKposeEffect.__PropertyOffset_1) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SKposeEffect.__PropertyOffset_1) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007849 RID: 30793
		// (get) Token: 0x0602C9C2 RID: 182722 RVA: 0x00AA7F24 File Offset: 0x00AA6124
		// (set) Token: 0x0602C9C3 RID: 182723 RVA: 0x00AA7F38 File Offset: 0x00AA6138
		public unsafe FName AttachSocketName
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SKposeEffect.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SKposeEffect.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x1700784A RID: 30794
		// (get) Token: 0x0602C9C4 RID: 182724 RVA: 0x00AA7F4D File Offset: 0x00AA614D
		// (set) Token: 0x0602C9C5 RID: 182725 RVA: 0x00AA7F61 File Offset: 0x00AA6161
		public unsafe FName SkeletalTag_Optional_
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SKposeEffect.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SKposeEffect.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x1700784B RID: 30795
		// (get) Token: 0x0602C9C6 RID: 182726 RVA: 0x00AA7F76 File Offset: 0x00AA6176
		// (set) Token: 0x0602C9C7 RID: 182727 RVA: 0x00AA7F8A File Offset: 0x00AA618A
		public unsafe FTransform Transform
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SKposeEffect.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SKposeEffect.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x0602C9C8 RID: 182728 RVA: 0x00AA7F9F File Offset: 0x00AA619F
		public SKposeEffect()
		{
		}

		// Token: 0x0602C9C9 RID: 182729 RVA: 0x00AA7FA7 File Offset: 0x00AA61A7
		public SKposeEffect(TSoftObjectPtr<UEffectModelBase> EffectData, bool Attach, FName AttachSocketName, FName SkeletalTag_Optional_, FTransform Transform)
		{
			this.EffectData = EffectData;
			this.Attach = Attach;
			this.AttachSocketName = AttachSocketName;
			this.SkeletalTag_Optional_ = SkeletalTag_Optional_;
			this.Transform = Transform;
		}

		// Token: 0x0602C9CA RID: 182730 RVA: 0x00AA7FD4 File Offset: 0x00AA61D4
		protected override IntPtr GetUStructPtr()
		{
			return SKposeEffect.StaticStruct();
		}

		// Token: 0x0602C9CB RID: 182731 RVA: 0x00AA7FE0 File Offset: 0x00AA61E0
		[NullableContext(2)]
		public SKposeEffect(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602C9CC RID: 182732 RVA: 0x00AA7FEA File Offset: 0x00AA61EA
		public SKposeEffect(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602C9CD RID: 182733 RVA: 0x00AA7FF5 File Offset: 0x00AA61F5
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SKposeEffect(Pointer, false, true);
		}

		// Token: 0x0602C9CE RID: 182734 RVA: 0x00AA7FFF File Offset: 0x00AA61FF
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SKposeEffect(Pointer, MemoryOwner);
		}

		// Token: 0x04018D2A RID: 101674
		public const string __ObjectPath = "/Game/Aki/Character/Kpose/Blueprint/SKposeEffect.SKposeEffect";

		// Token: 0x04018D2B RID: 101675
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04018D2C RID: 101676
		internal static int __PropertyOffset_0;

		// Token: 0x04018D2D RID: 101677
		internal static int __PropertyOffset_1;

		// Token: 0x04018D2E RID: 101678
		internal static int __PropertyOffset_2;

		// Token: 0x04018D2F RID: 101679
		internal static int __PropertyOffset_3;

		// Token: 0x04018D30 RID: 101680
		internal static int __PropertyOffset_4;
	}
}
