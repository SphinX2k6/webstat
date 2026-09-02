using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Core.Fight
{
	// Token: 0x02003F6A RID: 16234
	[NullableContext(1)]
	[Nullable(0)]
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Core/Fight/SBulletAudio.SBulletAudio")]
	[UnrealStructLayout(64, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 64)]
	public class SBulletAudio : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06028878 RID: 166008 RVA: 0x00A0E32C File Offset: 0x00A0C52C
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SBulletAudio._ScriptStructPtr != 0) ? SBulletAudio._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Core/Fight/SBulletAudio.SBulletAudio", ref SBulletAudio._ScriptStructPtr);
		}

		// Token: 0x170062B3 RID: 25267
		// (get) Token: 0x06028879 RID: 166009 RVA: 0x00A0E350 File Offset: 0x00A0C550
		// (set) Token: 0x0602887A RID: 166010 RVA: 0x00A0E36F File Offset: 0x00A0C56F
		public TSoftObjectPtr<UAkAudioEvent> 音效资源
		{
			get
			{
				return new TSoftObjectPtr<UAkAudioEvent>(base.NativePtr + (IntPtr)SBulletAudio.__PropertyOffset_0, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SBulletAudio.__PropertyOffset_0, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x170062B4 RID: 25268
		// (get) Token: 0x0602887B RID: 166011 RVA: 0x00A0E394 File Offset: 0x00A0C594
		// (set) Token: 0x0602887C RID: 166012 RVA: 0x00A0E3A8 File Offset: 0x00A0C5A8
		public unsafe string 备注
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SBulletAudio.__PropertyOffset_1)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SBulletAudio.__PropertyOffset_1)), value);
			}
		}

		// Token: 0x0602887D RID: 166013 RVA: 0x00A0E3BD File Offset: 0x00A0C5BD
		public SBulletAudio()
		{
		}

		// Token: 0x0602887E RID: 166014 RVA: 0x00A0E3C5 File Offset: 0x00A0C5C5
		public SBulletAudio(TSoftObjectPtr<UAkAudioEvent> 音效资源, string 备注)
		{
			this.音效资源 = 音效资源;
			this.备注 = 备注;
		}

		// Token: 0x0602887F RID: 166015 RVA: 0x00A0E3DB File Offset: 0x00A0C5DB
		protected override IntPtr GetUStructPtr()
		{
			return SBulletAudio.StaticStruct();
		}

		// Token: 0x06028880 RID: 166016 RVA: 0x00A0E3E7 File Offset: 0x00A0C5E7
		[NullableContext(2)]
		public SBulletAudio(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06028881 RID: 166017 RVA: 0x00A0E3F1 File Offset: 0x00A0C5F1
		public SBulletAudio(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06028882 RID: 166018 RVA: 0x00A0E3FC File Offset: 0x00A0C5FC
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SBulletAudio(Pointer, false, true);
		}

		// Token: 0x06028883 RID: 166019 RVA: 0x00A0E406 File Offset: 0x00A0C606
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SBulletAudio(Pointer, MemoryOwner);
		}

		// Token: 0x040155FF RID: 87551
		public const string __ObjectPath = "/Game/Aki/Core/Fight/SBulletAudio.SBulletAudio";

		// Token: 0x04015600 RID: 87552
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04015601 RID: 87553
		internal static int __PropertyOffset_0;

		// Token: 0x04015602 RID: 87554
		internal static int __PropertyOffset_1;
	}
}
