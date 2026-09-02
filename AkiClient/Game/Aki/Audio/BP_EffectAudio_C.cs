using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Audio
{
	// Token: 0x0200437B RID: 17275
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Audio/BP_EffectAudio.BP_EffectAudio_C")]
	[UnrealStructLayout(1040, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1040)]
	public class BP_EffectAudio_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602DC86 RID: 187526 RVA: 0x00ACBD8F File Offset: 0x00AC9F8F
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_EffectAudio_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Audio/BP_EffectAudio.BP_EffectAudio_C");
			}
			return BP_EffectAudio_C._ClassPtr;
		}

		// Token: 0x0602DC87 RID: 187527 RVA: 0x00ACBDB4 File Offset: 0x00AC9FB4
		public BP_EffectAudio_C() : this(BuiltinUtils.AllocNativeUObject(BP_EffectAudio_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602DC88 RID: 187528 RVA: 0x00ACBDDC File Offset: 0x00AC9FDC
		[NullableContext(1)]
		public BP_EffectAudio_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_EffectAudio_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007D6A RID: 32106
		// (get) Token: 0x0602DC89 RID: 187529 RVA: 0x00ACBE0F File Offset: 0x00ACA00F
		// (set) Token: 0x0602DC8A RID: 187530 RVA: 0x00ACBE23 File Offset: 0x00ACA023
		public unsafe UAkComponent AkComponent
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UAkComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_EffectAudio_C.__PropertyOffset_0);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_EffectAudio_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x17007D6B RID: 32107
		// (get) Token: 0x0602DC8B RID: 187531 RVA: 0x00ACBE38 File Offset: 0x00ACA038
		// (set) Token: 0x0602DC8C RID: 187532 RVA: 0x00ACBE4C File Offset: 0x00ACA04C
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_EffectAudio_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_EffectAudio_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x0602DC8D RID: 187533 RVA: 0x00ACBE61 File Offset: 0x00ACA061
		protected BP_EffectAudio_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019D76 RID: 105846
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Audio/BP_EffectAudio.BP_EffectAudio_C";

		// Token: 0x04019D77 RID: 105847
		private static IntPtr _ClassPtr;

		// Token: 0x04019D78 RID: 105848
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04019D79 RID: 105849
		internal static int __PropertyOffset_0;

		// Token: 0x04019D7A RID: 105850
		internal static int __PropertyOffset_1;
	}
}
