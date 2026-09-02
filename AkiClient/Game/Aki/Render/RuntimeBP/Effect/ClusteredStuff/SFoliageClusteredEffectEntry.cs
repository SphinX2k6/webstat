using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Effect.ClusteredStuff
{
	// Token: 0x02003D49 RID: 15689
	[NullableContext(2)]
	[Nullable(0)]
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Effect/ClusteredStuff/SFoliageClusteredEffectEntry.SFoliageClusteredEffectEntry")]
	[UnrealStructLayout(24, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 24)]
	public class SFoliageClusteredEffectEntry : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06026127 RID: 155943 RVA: 0x009CD331 File Offset: 0x009CB531
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SFoliageClusteredEffectEntry._ScriptStructPtr != 0) ? SFoliageClusteredEffectEntry._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/Effect/ClusteredStuff/SFoliageClusteredEffectEntry.SFoliageClusteredEffectEntry", ref SFoliageClusteredEffectEntry._ScriptStructPtr);
		}

		// Token: 0x17005551 RID: 21841
		// (get) Token: 0x06026128 RID: 155944 RVA: 0x009CD355 File Offset: 0x009CB555
		// (set) Token: 0x06026129 RID: 155945 RVA: 0x009CD369 File Offset: 0x009CB569
		public unsafe UFoliageType FoliageType
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UFoliageType>(base.NativePtr / (IntPtr)sizeof(void*) + SFoliageClusteredEffectEntry.__PropertyOffset_0);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + SFoliageClusteredEffectEntry.__PropertyOffset_0, value);
			}
		}

		// Token: 0x17005552 RID: 21842
		// (get) Token: 0x0602612A RID: 155946 RVA: 0x009CD37E File Offset: 0x009CB57E
		// (set) Token: 0x0602612B RID: 155947 RVA: 0x009CD392 File Offset: 0x009CB592
		public unsafe EffectClusteredStuffSettings EffectSetting
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<EffectClusteredStuffSettings>(base.NativePtr / (IntPtr)sizeof(void*) + SFoliageClusteredEffectEntry.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + SFoliageClusteredEffectEntry.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17005553 RID: 21843
		// (get) Token: 0x0602612C RID: 155948 RVA: 0x009CD3A7 File Offset: 0x009CB5A7
		// (set) Token: 0x0602612D RID: 155949 RVA: 0x009CD3B7 File Offset: 0x009CB5B7
		public unsafe int NumMin
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SFoliageClusteredEffectEntry.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SFoliageClusteredEffectEntry.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17005554 RID: 21844
		// (get) Token: 0x0602612E RID: 155950 RVA: 0x009CD3C8 File Offset: 0x009CB5C8
		// (set) Token: 0x0602612F RID: 155951 RVA: 0x009CD3D8 File Offset: 0x009CB5D8
		public unsafe int NumMax
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SFoliageClusteredEffectEntry.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SFoliageClusteredEffectEntry.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x06026130 RID: 155952 RVA: 0x009CD3E9 File Offset: 0x009CB5E9
		public SFoliageClusteredEffectEntry()
		{
		}

		// Token: 0x06026131 RID: 155953 RVA: 0x009CD3F1 File Offset: 0x009CB5F1
		[NullableContext(1)]
		public SFoliageClusteredEffectEntry(UFoliageType FoliageType, EffectClusteredStuffSettings EffectSetting, int NumMin, int NumMax)
		{
			this.FoliageType = FoliageType;
			this.EffectSetting = EffectSetting;
			this.NumMin = NumMin;
			this.NumMax = NumMax;
		}

		// Token: 0x06026132 RID: 155954 RVA: 0x009CD416 File Offset: 0x009CB616
		protected override IntPtr GetUStructPtr()
		{
			return SFoliageClusteredEffectEntry.StaticStruct();
		}

		// Token: 0x06026133 RID: 155955 RVA: 0x009CD422 File Offset: 0x009CB622
		public SFoliageClusteredEffectEntry(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06026134 RID: 155956 RVA: 0x009CD42C File Offset: 0x009CB62C
		public SFoliageClusteredEffectEntry(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06026135 RID: 155957 RVA: 0x009CD437 File Offset: 0x009CB637
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SFoliageClusteredEffectEntry(Pointer, false, true);
		}

		// Token: 0x06026136 RID: 155958 RVA: 0x009CD441 File Offset: 0x009CB641
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SFoliageClusteredEffectEntry(Pointer, MemoryOwner);
		}

		// Token: 0x04013B6B RID: 80747
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Effect/ClusteredStuff/SFoliageClusteredEffectEntry.SFoliageClusteredEffectEntry";

		// Token: 0x04013B6C RID: 80748
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04013B6D RID: 80749
		internal static int __PropertyOffset_0;

		// Token: 0x04013B6E RID: 80750
		internal static int __PropertyOffset_1;

		// Token: 0x04013B6F RID: 80751
		internal static int __PropertyOffset_2;

		// Token: 0x04013B70 RID: 80752
		internal static int __PropertyOffset_3;
	}
}
