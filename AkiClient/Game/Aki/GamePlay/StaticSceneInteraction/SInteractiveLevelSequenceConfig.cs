using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.GamePlay.StaticSceneInteraction
{
	// Token: 0x02003DC9 RID: 15817
	[NullableContext(1)]
	[Nullable(0)]
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/GamePlay/StaticSceneInteraction/SInteractiveLevelSequenceConfig.SInteractiveLevelSequenceConfig")]
	[UnrealStructLayout(24, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 24)]
	public class SInteractiveLevelSequenceConfig : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06026BBA RID: 158650 RVA: 0x009E0A60 File Offset: 0x009DEC60
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SInteractiveLevelSequenceConfig._ScriptStructPtr != 0) ? SInteractiveLevelSequenceConfig._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/GamePlay/StaticSceneInteraction/SInteractiveLevelSequenceConfig.SInteractiveLevelSequenceConfig", ref SInteractiveLevelSequenceConfig._ScriptStructPtr);
		}

		// Token: 0x170058D4 RID: 22740
		// (get) Token: 0x06026BBB RID: 158651 RVA: 0x009E0A84 File Offset: 0x009DEC84
		// (set) Token: 0x06026BBC RID: 158652 RVA: 0x009E0A98 File Offset: 0x009DEC98
		public unsafe string Mark
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SInteractiveLevelSequenceConfig.__PropertyOffset_0)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SInteractiveLevelSequenceConfig.__PropertyOffset_0)), value);
			}
		}

		// Token: 0x170058D5 RID: 22741
		// (get) Token: 0x06026BBD RID: 158653 RVA: 0x009E0AAD File Offset: 0x009DECAD
		// (set) Token: 0x06026BBE RID: 158654 RVA: 0x009E0ABD File Offset: 0x009DECBD
		public unsafe float 切入时间
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SInteractiveLevelSequenceConfig.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SInteractiveLevelSequenceConfig.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x170058D6 RID: 22742
		// (get) Token: 0x06026BBF RID: 158655 RVA: 0x009E0ACE File Offset: 0x009DECCE
		// (set) Token: 0x06026BC0 RID: 158656 RVA: 0x009E0ADE File Offset: 0x009DECDE
		public unsafe float 切出时间
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SInteractiveLevelSequenceConfig.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SInteractiveLevelSequenceConfig.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x06026BC1 RID: 158657 RVA: 0x009E0AEF File Offset: 0x009DECEF
		public SInteractiveLevelSequenceConfig()
		{
		}

		// Token: 0x06026BC2 RID: 158658 RVA: 0x009E0AF7 File Offset: 0x009DECF7
		public SInteractiveLevelSequenceConfig(string Mark, float 切入时间, float 切出时间)
		{
			this.Mark = Mark;
			this.切入时间 = 切入时间;
			this.切出时间 = 切出时间;
		}

		// Token: 0x06026BC3 RID: 158659 RVA: 0x009E0B14 File Offset: 0x009DED14
		protected override IntPtr GetUStructPtr()
		{
			return SInteractiveLevelSequenceConfig.StaticStruct();
		}

		// Token: 0x06026BC4 RID: 158660 RVA: 0x009E0B20 File Offset: 0x009DED20
		[NullableContext(2)]
		public SInteractiveLevelSequenceConfig(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06026BC5 RID: 158661 RVA: 0x009E0B2A File Offset: 0x009DED2A
		public SInteractiveLevelSequenceConfig(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06026BC6 RID: 158662 RVA: 0x009E0B35 File Offset: 0x009DED35
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SInteractiveLevelSequenceConfig(Pointer, false, true);
		}

		// Token: 0x06026BC7 RID: 158663 RVA: 0x009E0B3F File Offset: 0x009DED3F
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SInteractiveLevelSequenceConfig(Pointer, MemoryOwner);
		}

		// Token: 0x04014336 RID: 82742
		public const string __ObjectPath = "/Game/Aki/GamePlay/StaticSceneInteraction/SInteractiveLevelSequenceConfig.SInteractiveLevelSequenceConfig";

		// Token: 0x04014337 RID: 82743
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04014338 RID: 82744
		internal static int __PropertyOffset_0;

		// Token: 0x04014339 RID: 82745
		internal static int __PropertyOffset_1;

		// Token: 0x0401433A RID: 82746
		internal static int __PropertyOffset_2;
	}
}
