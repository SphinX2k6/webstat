using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Editor.Tools.Sequence.SeqGraph
{
	// Token: 0x02003DF1 RID: 15857
	[UnrealObjectPath("/Game/Aki/Editor/Tools/Sequence/SeqGraph/BP_SeqGraph.BP_SeqGraph_C")]
	[UnrealStructLayout(48, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 48)]
	public class BP_SeqGraph_C : UObject, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06027021 RID: 159777 RVA: 0x009E7B3E File Offset: 0x009E5D3E
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SeqGraph_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Editor/Tools/Sequence/SeqGraph/BP_SeqGraph.BP_SeqGraph_C");
			}
			return BP_SeqGraph_C._ClassPtr;
		}

		// Token: 0x06027022 RID: 159778 RVA: 0x009E7B64 File Offset: 0x009E5D64
		public BP_SeqGraph_C() : this(BuiltinUtils.AllocNativeUObject(BP_SeqGraph_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06027023 RID: 159779 RVA: 0x009E7B8C File Offset: 0x009E5D8C
		[NullableContext(1)]
		public BP_SeqGraph_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SeqGraph_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x06027024 RID: 159780 RVA: 0x009E7BBF File Offset: 0x009E5DBF
		protected BP_SeqGraph_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040145EE RID: 83438
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Editor/Tools/Sequence/SeqGraph/BP_SeqGraph.BP_SeqGraph_C";

		// Token: 0x040145EF RID: 83439
		private static IntPtr _ClassPtr;

		// Token: 0x040145F0 RID: 83440
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
