using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x02004259 RID: 16985
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/SDitherDistanceConfig.SDitherDistanceConfig")]
	[UnrealStructLayout(16, 4, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 16)]
	public class SDitherDistanceConfig : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602D003 RID: 184323 RVA: 0x00AB52D3 File Offset: 0x00AB34D3
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SDitherDistanceConfig._ScriptStructPtr != 0) ? SDitherDistanceConfig._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/SDitherDistanceConfig.SDitherDistanceConfig", ref SDitherDistanceConfig._ScriptStructPtr);
		}

		// Token: 0x17007A14 RID: 31252
		// (get) Token: 0x0602D004 RID: 184324 RVA: 0x00AB52F7 File Offset: 0x00AB34F7
		// (set) Token: 0x0602D005 RID: 184325 RVA: 0x00AB5307 File Offset: 0x00AB3507
		public unsafe bool OverrideDefaultDitherConfig
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SDitherDistanceConfig.__PropertyOffset_0) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SDitherDistanceConfig.__PropertyOffset_0) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007A15 RID: 31253
		// (get) Token: 0x0602D006 RID: 184326 RVA: 0x00AB5318 File Offset: 0x00AB3518
		// (set) Token: 0x0602D007 RID: 184327 RVA: 0x00AB5328 File Offset: 0x00AB3528
		public unsafe float StartHideDistance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SDitherDistanceConfig.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SDitherDistanceConfig.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17007A16 RID: 31254
		// (get) Token: 0x0602D008 RID: 184328 RVA: 0x00AB5339 File Offset: 0x00AB3539
		// (set) Token: 0x0602D009 RID: 184329 RVA: 0x00AB5349 File Offset: 0x00AB3549
		public unsafe float CompleteHideDistance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SDitherDistanceConfig.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SDitherDistanceConfig.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17007A17 RID: 31255
		// (get) Token: 0x0602D00A RID: 184330 RVA: 0x00AB535A File Offset: 0x00AB355A
		// (set) Token: 0x0602D00B RID: 184331 RVA: 0x00AB536A File Offset: 0x00AB356A
		public unsafe float StartDitherValue
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SDitherDistanceConfig.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SDitherDistanceConfig.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x0602D00C RID: 184332 RVA: 0x00AB537B File Offset: 0x00AB357B
		public SDitherDistanceConfig()
		{
		}

		// Token: 0x0602D00D RID: 184333 RVA: 0x00AB5383 File Offset: 0x00AB3583
		public SDitherDistanceConfig(bool OverrideDefaultDitherConfig, float StartHideDistance, float CompleteHideDistance, float StartDitherValue)
		{
			this.OverrideDefaultDitherConfig = OverrideDefaultDitherConfig;
			this.StartHideDistance = StartHideDistance;
			this.CompleteHideDistance = CompleteHideDistance;
			this.StartDitherValue = StartDitherValue;
		}

		// Token: 0x0602D00E RID: 184334 RVA: 0x00AB53A8 File Offset: 0x00AB35A8
		protected override IntPtr GetUStructPtr()
		{
			return SDitherDistanceConfig.StaticStruct();
		}

		// Token: 0x0602D00F RID: 184335 RVA: 0x00AB53B4 File Offset: 0x00AB35B4
		[NullableContext(2)]
		public SDitherDistanceConfig(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602D010 RID: 184336 RVA: 0x00AB53BE File Offset: 0x00AB35BE
		public SDitherDistanceConfig(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602D011 RID: 184337 RVA: 0x00AB53C9 File Offset: 0x00AB35C9
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SDitherDistanceConfig(Pointer, false, true);
		}

		// Token: 0x0602D012 RID: 184338 RVA: 0x00AB53D3 File Offset: 0x00AB35D3
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SDitherDistanceConfig(Pointer, MemoryOwner);
		}

		// Token: 0x040193DB RID: 103387
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/SDitherDistanceConfig.SDitherDistanceConfig";

		// Token: 0x040193DC RID: 103388
		private static IntPtr _ScriptStructPtr;

		// Token: 0x040193DD RID: 103389
		internal static int __PropertyOffset_0;

		// Token: 0x040193DE RID: 103390
		internal static int __PropertyOffset_1;

		// Token: 0x040193DF RID: 103391
		internal static int __PropertyOffset_2;

		// Token: 0x040193E0 RID: 103392
		internal static int __PropertyOffset_3;
	}
}
