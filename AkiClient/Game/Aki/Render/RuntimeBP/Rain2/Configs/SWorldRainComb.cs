using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Rain2.Configs
{
	// Token: 0x02003B44 RID: 15172
	[NullableContext(2)]
	[Nullable(0)]
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Rain2/Configs/SWorldRainComb.SWorldRainComb")]
	[UnrealStructLayout(40, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 40)]
	public class SWorldRainComb : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06020E19 RID: 134681 RVA: 0x00939B51 File Offset: 0x00937D51
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SWorldRainComb._ScriptStructPtr != 0) ? SWorldRainComb._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/Rain2/Configs/SWorldRainComb.SWorldRainComb", ref SWorldRainComb._ScriptStructPtr);
		}

		// Token: 0x170037CD RID: 14285
		// (get) Token: 0x06020E1A RID: 134682 RVA: 0x00939B75 File Offset: 0x00937D75
		// (set) Token: 0x06020E1B RID: 134683 RVA: 0x00939B89 File Offset: 0x00937D89
		public unsafe UKuroWorldRainComponentSpawnConfig SpawnConfig
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroWorldRainComponentSpawnConfig>(base.NativePtr / (IntPtr)sizeof(void*) + SWorldRainComb.__PropertyOffset_0);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + SWorldRainComb.__PropertyOffset_0, value);
			}
		}

		// Token: 0x170037CE RID: 14286
		// (get) Token: 0x06020E1C RID: 134684 RVA: 0x00939B9E File Offset: 0x00937D9E
		// (set) Token: 0x06020E1D RID: 134685 RVA: 0x00939BB2 File Offset: 0x00937DB2
		public unsafe UKuroWorldRainComponentPhysicsConfig PhysicsConfig
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroWorldRainComponentPhysicsConfig>(base.NativePtr / (IntPtr)sizeof(void*) + SWorldRainComb.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + SWorldRainComb.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170037CF RID: 14287
		// (get) Token: 0x06020E1E RID: 134686 RVA: 0x00939BC7 File Offset: 0x00937DC7
		// (set) Token: 0x06020E1F RID: 134687 RVA: 0x00939BDB File Offset: 0x00937DDB
		public unsafe UKuroWorldRainComponentCustomDataConfig CustomDataConfig
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroWorldRainComponentCustomDataConfig>(base.NativePtr / (IntPtr)sizeof(void*) + SWorldRainComb.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + SWorldRainComb.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170037D0 RID: 14288
		// (get) Token: 0x06020E20 RID: 134688 RVA: 0x00939BF0 File Offset: 0x00937DF0
		// (set) Token: 0x06020E21 RID: 134689 RVA: 0x00939C04 File Offset: 0x00937E04
		public unsafe UClusteredStuffDataAsset ClusteredStuff
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UClusteredStuffDataAsset>(base.NativePtr / (IntPtr)sizeof(void*) + SWorldRainComb.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + SWorldRainComb.__PropertyOffset_3, value);
			}
		}

		// Token: 0x170037D1 RID: 14289
		// (get) Token: 0x06020E22 RID: 134690 RVA: 0x00939C19 File Offset: 0x00937E19
		// (set) Token: 0x06020E23 RID: 134691 RVA: 0x00939C2D File Offset: 0x00937E2D
		public unsafe UAkAudioEvent AudioEvent
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UAkAudioEvent>(base.NativePtr / (IntPtr)sizeof(void*) + SWorldRainComb.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + SWorldRainComb.__PropertyOffset_4, value);
			}
		}

		// Token: 0x06020E24 RID: 134692 RVA: 0x00939C42 File Offset: 0x00937E42
		public SWorldRainComb()
		{
		}

		// Token: 0x06020E25 RID: 134693 RVA: 0x00939C4A File Offset: 0x00937E4A
		[NullableContext(1)]
		public SWorldRainComb(UKuroWorldRainComponentSpawnConfig SpawnConfig, UKuroWorldRainComponentPhysicsConfig PhysicsConfig, UKuroWorldRainComponentCustomDataConfig CustomDataConfig, UClusteredStuffDataAsset ClusteredStuff, UAkAudioEvent AudioEvent)
		{
			this.SpawnConfig = SpawnConfig;
			this.PhysicsConfig = PhysicsConfig;
			this.CustomDataConfig = CustomDataConfig;
			this.ClusteredStuff = ClusteredStuff;
			this.AudioEvent = AudioEvent;
		}

		// Token: 0x06020E26 RID: 134694 RVA: 0x00939C77 File Offset: 0x00937E77
		protected override IntPtr GetUStructPtr()
		{
			return SWorldRainComb.StaticStruct();
		}

		// Token: 0x06020E27 RID: 134695 RVA: 0x00939C83 File Offset: 0x00937E83
		public SWorldRainComb(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06020E28 RID: 134696 RVA: 0x00939C8D File Offset: 0x00937E8D
		public SWorldRainComb(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06020E29 RID: 134697 RVA: 0x00939C98 File Offset: 0x00937E98
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SWorldRainComb(Pointer, false, true);
		}

		// Token: 0x06020E2A RID: 134698 RVA: 0x00939CA2 File Offset: 0x00937EA2
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SWorldRainComb(Pointer, MemoryOwner);
		}

		// Token: 0x040107FD RID: 67581
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Rain2/Configs/SWorldRainComb.SWorldRainComb";

		// Token: 0x040107FE RID: 67582
		private static IntPtr _ScriptStructPtr;

		// Token: 0x040107FF RID: 67583
		internal static int __PropertyOffset_0;

		// Token: 0x04010800 RID: 67584
		internal static int __PropertyOffset_1;

		// Token: 0x04010801 RID: 67585
		internal static int __PropertyOffset_2;

		// Token: 0x04010802 RID: 67586
		internal static int __PropertyOffset_3;

		// Token: 0x04010803 RID: 67587
		internal static int __PropertyOffset_4;
	}
}
