using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.GamePlay.StaticSceneInteraction
{
	// Token: 0x02003DCA RID: 15818
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/GamePlay/StaticSceneInteraction/SInteractivePPVConfig.SInteractivePPVConfig")]
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 16)]
	public class SInteractivePPVConfig : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06026BC8 RID: 158664 RVA: 0x009E0B48 File Offset: 0x009DED48
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SInteractivePPVConfig._ScriptStructPtr != 0) ? SInteractivePPVConfig._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/GamePlay/StaticSceneInteraction/SInteractivePPVConfig.SInteractivePPVConfig", ref SInteractivePPVConfig._ScriptStructPtr);
		}

		// Token: 0x170058D7 RID: 22743
		// (get) Token: 0x06026BC9 RID: 158665 RVA: 0x009E0B6C File Offset: 0x009DED6C
		// (set) Token: 0x06026BCA RID: 158666 RVA: 0x009E0B80 File Offset: 0x009DED80
		[Nullable(2)]
		public unsafe AActor PPVActor
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + SInteractivePPVConfig.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + SInteractivePPVConfig.__PropertyOffset_0, value);
			}
		}

		// Token: 0x170058D8 RID: 22744
		// (get) Token: 0x06026BCB RID: 158667 RVA: 0x009E0B95 File Offset: 0x009DED95
		// (set) Token: 0x06026BCC RID: 158668 RVA: 0x009E0BA5 File Offset: 0x009DEDA5
		public unsafe float TransitionTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SInteractivePPVConfig.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SInteractivePPVConfig.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x170058D9 RID: 22745
		// (get) Token: 0x06026BCD RID: 158669 RVA: 0x009E0BB6 File Offset: 0x009DEDB6
		// (set) Token: 0x06026BCE RID: 158670 RVA: 0x009E0BC6 File Offset: 0x009DEDC6
		public unsafe float AimBlendWeight
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SInteractivePPVConfig.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SInteractivePPVConfig.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x06026BCF RID: 158671 RVA: 0x009E0BD7 File Offset: 0x009DEDD7
		public SInteractivePPVConfig()
		{
		}

		// Token: 0x06026BD0 RID: 158672 RVA: 0x009E0BDF File Offset: 0x009DEDDF
		[NullableContext(1)]
		public SInteractivePPVConfig(AActor PPVActor, float TransitionTime, float AimBlendWeight)
		{
			this.PPVActor = PPVActor;
			this.TransitionTime = TransitionTime;
			this.AimBlendWeight = AimBlendWeight;
		}

		// Token: 0x06026BD1 RID: 158673 RVA: 0x009E0BFC File Offset: 0x009DEDFC
		protected override IntPtr GetUStructPtr()
		{
			return SInteractivePPVConfig.StaticStruct();
		}

		// Token: 0x06026BD2 RID: 158674 RVA: 0x009E0C08 File Offset: 0x009DEE08
		[NullableContext(2)]
		public SInteractivePPVConfig(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06026BD3 RID: 158675 RVA: 0x009E0C12 File Offset: 0x009DEE12
		public SInteractivePPVConfig(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06026BD4 RID: 158676 RVA: 0x009E0C1D File Offset: 0x009DEE1D
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SInteractivePPVConfig(Pointer, false, true);
		}

		// Token: 0x06026BD5 RID: 158677 RVA: 0x009E0C27 File Offset: 0x009DEE27
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SInteractivePPVConfig(Pointer, MemoryOwner);
		}

		// Token: 0x0401433B RID: 82747
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/GamePlay/StaticSceneInteraction/SInteractivePPVConfig.SInteractivePPVConfig";

		// Token: 0x0401433C RID: 82748
		private static IntPtr _ScriptStructPtr;

		// Token: 0x0401433D RID: 82749
		internal static int __PropertyOffset_0;

		// Token: 0x0401433E RID: 82750
		internal static int __PropertyOffset_1;

		// Token: 0x0401433F RID: 82751
		internal static int __PropertyOffset_2;
	}
}
