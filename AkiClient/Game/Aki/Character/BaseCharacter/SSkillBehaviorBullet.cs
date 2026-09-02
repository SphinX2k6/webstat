using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x02004279 RID: 17017
	[NullableContext(1)]
	[Nullable(0)]
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/SSkillBehaviorBullet.SSkillBehaviorBullet")]
	[UnrealStructLayout(40, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 40)]
	public class SSkillBehaviorBullet : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602D2A8 RID: 185000 RVA: 0x00AB90C7 File Offset: 0x00AB72C7
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SSkillBehaviorBullet._ScriptStructPtr != 0) ? SSkillBehaviorBullet._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/SSkillBehaviorBullet.SSkillBehaviorBullet", ref SSkillBehaviorBullet._ScriptStructPtr);
		}

		// Token: 0x17007AE9 RID: 31465
		// (get) Token: 0x0602D2A9 RID: 185001 RVA: 0x00AB90EB File Offset: 0x00AB72EB
		// (set) Token: 0x0602D2AA RID: 185002 RVA: 0x00AB90FF File Offset: 0x00AB72FF
		public unsafe string bulletRowName
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SSkillBehaviorBullet.__PropertyOffset_0)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SSkillBehaviorBullet.__PropertyOffset_0)), value);
			}
		}

		// Token: 0x17007AEA RID: 31466
		// (get) Token: 0x0602D2AB RID: 185003 RVA: 0x00AB9114 File Offset: 0x00AB7314
		// (set) Token: 0x0602D2AC RID: 185004 RVA: 0x00AB9124 File Offset: 0x00AB7324
		public unsafe int bulletCount
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSkillBehaviorBullet.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSkillBehaviorBullet.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17007AEB RID: 31467
		// (get) Token: 0x0602D2AD RID: 185005 RVA: 0x00AB9135 File Offset: 0x00AB7335
		// (set) Token: 0x0602D2AE RID: 185006 RVA: 0x00AB9149 File Offset: 0x00AB7349
		public unsafe string BlackboardKey
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SSkillBehaviorBullet.__PropertyOffset_2)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SSkillBehaviorBullet.__PropertyOffset_2)), value);
			}
		}

		// Token: 0x0602D2AF RID: 185007 RVA: 0x00AB915E File Offset: 0x00AB735E
		public SSkillBehaviorBullet()
		{
		}

		// Token: 0x0602D2B0 RID: 185008 RVA: 0x00AB9166 File Offset: 0x00AB7366
		public SSkillBehaviorBullet(string bulletRowName, int bulletCount, string BlackboardKey)
		{
			this.bulletRowName = bulletRowName;
			this.bulletCount = bulletCount;
			this.BlackboardKey = BlackboardKey;
		}

		// Token: 0x0602D2B1 RID: 185009 RVA: 0x00AB9183 File Offset: 0x00AB7383
		protected override IntPtr GetUStructPtr()
		{
			return SSkillBehaviorBullet.StaticStruct();
		}

		// Token: 0x0602D2B2 RID: 185010 RVA: 0x00AB918F File Offset: 0x00AB738F
		[NullableContext(2)]
		public SSkillBehaviorBullet(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602D2B3 RID: 185011 RVA: 0x00AB9199 File Offset: 0x00AB7399
		public SSkillBehaviorBullet(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602D2B4 RID: 185012 RVA: 0x00AB91A4 File Offset: 0x00AB73A4
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SSkillBehaviorBullet(Pointer, false, true);
		}

		// Token: 0x0602D2B5 RID: 185013 RVA: 0x00AB91AE File Offset: 0x00AB73AE
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SSkillBehaviorBullet(Pointer, MemoryOwner);
		}

		// Token: 0x04019528 RID: 103720
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/SSkillBehaviorBullet.SSkillBehaviorBullet";

		// Token: 0x04019529 RID: 103721
		private static IntPtr _ScriptStructPtr;

		// Token: 0x0401952A RID: 103722
		internal static int __PropertyOffset_0;

		// Token: 0x0401952B RID: 103723
		internal static int __PropertyOffset_1;

		// Token: 0x0401952C RID: 103724
		internal static int __PropertyOffset_2;
	}
}
