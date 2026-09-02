using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Effect.Setting.EffectDataAsset
{
	// Token: 0x02003DDB RID: 15835
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Effect/Setting/EffectDataAsset/BP_EffectModelAudio.BP_EffectModelAudio_C")]
	[UnrealStructLayout(184, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 184)]
	public class BP_EffectModelAudio_C : BP_EffectModelBase_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06026D49 RID: 159049 RVA: 0x009E2EAF File Offset: 0x009E10AF
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_EffectModelAudio_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Effect/Setting/EffectDataAsset/BP_EffectModelAudio.BP_EffectModelAudio_C");
			}
			return BP_EffectModelAudio_C._ClassPtr;
		}

		// Token: 0x06026D4A RID: 159050 RVA: 0x009E2ED4 File Offset: 0x009E10D4
		public BP_EffectModelAudio_C() : this(BuiltinUtils.AllocNativeUObject(BP_EffectModelAudio_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06026D4B RID: 159051 RVA: 0x009E2EFC File Offset: 0x009E10FC
		public BP_EffectModelAudio_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_EffectModelAudio_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17005967 RID: 22887
		// (get) Token: 0x06026D4C RID: 159052 RVA: 0x009E2F30 File Offset: 0x009E1130
		// (set) Token: 0x06026D4D RID: 159053 RVA: 0x009E2F69 File Offset: 0x009E1169
		public FSoftObjectPath AudioEventSoft
		{
			get
			{
				base.FastCheckIsValid();
				FSoftObjectPath result;
				if ((result = this._AudioEventSoft) == null)
				{
					result = (this._AudioEventSoft = new FSoftObjectPath(base.NativePtr + (IntPtr)BP_EffectModelAudio_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FSoftObjectPath.StaticStruct(), base.NativePtr + (IntPtr)BP_EffectModelAudio_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005968 RID: 22888
		// (get) Token: 0x06026D4E RID: 159054 RVA: 0x009E2F8C File Offset: 0x009E118C
		// (set) Token: 0x06026D4F RID: 159055 RVA: 0x009E2FC5 File Offset: 0x009E11C5
		public TArray<string> SwitchList
		{
			get
			{
				base.FastCheckIsValid();
				TArray<string> result;
				if ((result = this._SwitchList) == null)
				{
					result = (this._SwitchList = new TArray<string>(base.NativePtr + (IntPtr)BP_EffectModelAudio_C.__PropertyOffset_1, this));
				}
				return result;
			}
			set
			{
				this.SwitchList.CopyAssign(value);
			}
		}

		// Token: 0x17005969 RID: 22889
		// (get) Token: 0x06026D50 RID: 159056 RVA: 0x009E2FD3 File Offset: 0x009E11D3
		// (set) Token: 0x06026D51 RID: 159057 RVA: 0x009E2FE3 File Offset: 0x009E11E3
		public unsafe float ActivateDistance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectModelAudio_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectModelAudio_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x1700596A RID: 22890
		// (get) Token: 0x06026D52 RID: 159058 RVA: 0x009E2FF4 File Offset: 0x009E11F4
		// (set) Token: 0x06026D53 RID: 159059 RVA: 0x009E3004 File Offset: 0x009E1204
		public unsafe bool IsStatic
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectModelAudio_C.__PropertyOffset_3) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectModelAudio_C.__PropertyOffset_3) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700596B RID: 22891
		// (get) Token: 0x06026D54 RID: 159060 RVA: 0x009E3015 File Offset: 0x009E1215
		// (set) Token: 0x06026D55 RID: 159061 RVA: 0x009E3025 File Offset: 0x009E1225
		public unsafe float FadeOutTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EffectModelAudio_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EffectModelAudio_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x1700596C RID: 22892
		// (get) Token: 0x06026D56 RID: 159062 RVA: 0x009E3036 File Offset: 0x009E1236
		// (set) Token: 0x06026D57 RID: 159063 RVA: 0x009E304A File Offset: 0x009E124A
		[Nullable(2)]
		public unsafe UAkAudioEvent AudioEvent
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UAkAudioEvent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_EffectModelAudio_C.__PropertyOffset_5);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_EffectModelAudio_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x06026D58 RID: 159064 RVA: 0x009E305F File Offset: 0x009E125F
		protected BP_EffectModelAudio_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401440A RID: 82954
		public new const string __ObjectPath = "/Game/Aki/Effect/Setting/EffectDataAsset/BP_EffectModelAudio.BP_EffectModelAudio_C";

		// Token: 0x0401440B RID: 82955
		private static IntPtr _ClassPtr;

		// Token: 0x0401440C RID: 82956
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401440D RID: 82957
		internal new static int __PropertyOffset_0;

		// Token: 0x0401440E RID: 82958
		[Nullable(2)]
		private FSoftObjectPath _AudioEventSoft;

		// Token: 0x0401440F RID: 82959
		internal new static int __PropertyOffset_1;

		// Token: 0x04014410 RID: 82960
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<string> _SwitchList;

		// Token: 0x04014411 RID: 82961
		internal new static int __PropertyOffset_2;

		// Token: 0x04014412 RID: 82962
		internal new static int __PropertyOffset_3;

		// Token: 0x04014413 RID: 82963
		internal new static int __PropertyOffset_4;

		// Token: 0x04014414 RID: 82964
		internal new static int __PropertyOffset_5;
	}
}
