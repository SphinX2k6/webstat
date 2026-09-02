using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseSeqCharacter
{
	// Token: 0x020041BC RID: 16828
	[UnrealObjectPath("/Game/Aki/Character/BaseSeqCharacter/SeqAudio_Seq_V2.SeqAudio_Seq_V2_C")]
	[UnrealStructLayout(208, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 201)]
	public class SeqAudio_Seq_V2_C : UActorComponent, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602CB8A RID: 183178 RVA: 0x00AACED4 File Offset: 0x00AAB0D4
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (SeqAudio_Seq_V2_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseSeqCharacter/SeqAudio_Seq_V2.SeqAudio_Seq_V2_C");
			}
			return SeqAudio_Seq_V2_C._ClassPtr;
		}

		// Token: 0x0602CB8B RID: 183179 RVA: 0x00AACEF8 File Offset: 0x00AAB0F8
		public SeqAudio_Seq_V2_C() : this(BuiltinUtils.AllocNativeUObject(SeqAudio_Seq_V2_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602CB8C RID: 183180 RVA: 0x00AACF20 File Offset: 0x00AAB120
		[NullableContext(1)]
		public SeqAudio_Seq_V2_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(SeqAudio_Seq_V2_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170078AA RID: 30890
		// (get) Token: 0x0602CB8D RID: 183181 RVA: 0x00AACF53 File Offset: 0x00AAB153
		// (set) Token: 0x0602CB8E RID: 183182 RVA: 0x00AACF63 File Offset: 0x00AAB163
		public unsafe bool UseAudioSeq
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SeqAudio_Seq_V2_C.__PropertyOffset_0) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SeqAudio_Seq_V2_C.__PropertyOffset_0) = (value ? 1 : 0);
			}
		}

		// Token: 0x0602CB8F RID: 183183 RVA: 0x00AACF74 File Offset: 0x00AAB174
		protected SeqAudio_Seq_V2_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018EA9 RID: 102057
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseSeqCharacter/SeqAudio_Seq_V2.SeqAudio_Seq_V2_C";

		// Token: 0x04018EAA RID: 102058
		private static IntPtr _ClassPtr;

		// Token: 0x04018EAB RID: 102059
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04018EAC RID: 102060
		internal static int __PropertyOffset_0;
	}
}
