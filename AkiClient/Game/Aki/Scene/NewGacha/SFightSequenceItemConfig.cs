using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Scene.NewGacha
{
	// Token: 0x020039C7 RID: 14791
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Scene/NewGacha/SFightSequenceItemConfig.SFightSequenceItemConfig")]
	[UnrealStructLayout(104, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 104)]
	public class SFightSequenceItemConfig : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0601DE85 RID: 122501 RVA: 0x008E6933 File Offset: 0x008E4B33
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SFightSequenceItemConfig._ScriptStructPtr != 0) ? SFightSequenceItemConfig._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Scene/NewGacha/SFightSequenceItemConfig.SFightSequenceItemConfig", ref SFightSequenceItemConfig._ScriptStructPtr);
		}

		// Token: 0x170027BF RID: 10175
		// (get) Token: 0x0601DE86 RID: 122502 RVA: 0x008E6957 File Offset: 0x008E4B57
		// (set) Token: 0x0601DE87 RID: 122503 RVA: 0x008E696B File Offset: 0x008E4B6B
		[Nullable(2)]
		public unsafe UObject Sequence
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UObject>(base.NativePtr / (IntPtr)sizeof(void*) + SFightSequenceItemConfig.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + SFightSequenceItemConfig.__PropertyOffset_0, value);
			}
		}

		// Token: 0x170027C0 RID: 10176
		// (get) Token: 0x0601DE88 RID: 122504 RVA: 0x008E6980 File Offset: 0x008E4B80
		// (set) Token: 0x0601DE89 RID: 122505 RVA: 0x008E6994 File Offset: 0x008E4B94
		public unsafe string SelectName
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SFightSequenceItemConfig.__PropertyOffset_1)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SFightSequenceItemConfig.__PropertyOffset_1)), value);
			}
		}

		// Token: 0x170027C1 RID: 10177
		// (get) Token: 0x0601DE8A RID: 122506 RVA: 0x008E69AC File Offset: 0x008E4BAC
		// (set) Token: 0x0601DE8B RID: 122507 RVA: 0x008E69EF File Offset: 0x008E4BEF
		public TMap<string, FName> UseComponents_Name__SocketName
		{
			get
			{
				base.FastCheckIsValid();
				TMap<string, FName> result;
				if ((result = this._UseComponents_Name__SocketName) == null)
				{
					result = (this._UseComponents_Name__SocketName = new TMap<string, FName>(base.NativePtr + (IntPtr)SFightSequenceItemConfig.__PropertyOffset_2, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.UseComponents_Name__SocketName.CopyAssign(value);
			}
		}

		// Token: 0x0601DE8C RID: 122508 RVA: 0x008E69FD File Offset: 0x008E4BFD
		public SFightSequenceItemConfig()
		{
		}

		// Token: 0x0601DE8D RID: 122509 RVA: 0x008E6A05 File Offset: 0x008E4C05
		public SFightSequenceItemConfig(UObject Sequence, string SelectName, TMap<string, FName> UseComponents_Name__SocketName)
		{
			this.Sequence = Sequence;
			this.SelectName = SelectName;
			this.UseComponents_Name__SocketName = UseComponents_Name__SocketName;
		}

		// Token: 0x0601DE8E RID: 122510 RVA: 0x008E6A22 File Offset: 0x008E4C22
		protected override IntPtr GetUStructPtr()
		{
			return SFightSequenceItemConfig.StaticStruct();
		}

		// Token: 0x0601DE8F RID: 122511 RVA: 0x008E6A2E File Offset: 0x008E4C2E
		[NullableContext(2)]
		public SFightSequenceItemConfig(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0601DE90 RID: 122512 RVA: 0x008E6A38 File Offset: 0x008E4C38
		public SFightSequenceItemConfig(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0601DE91 RID: 122513 RVA: 0x008E6A43 File Offset: 0x008E4C43
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SFightSequenceItemConfig(Pointer, false, true);
		}

		// Token: 0x0601DE92 RID: 122514 RVA: 0x008E6A4D File Offset: 0x008E4C4D
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SFightSequenceItemConfig(Pointer, MemoryOwner);
		}

		// Token: 0x0400EA82 RID: 60034
		public const string __ObjectPath = "/Game/Aki/Scene/NewGacha/SFightSequenceItemConfig.SFightSequenceItemConfig";

		// Token: 0x0400EA83 RID: 60035
		private static IntPtr _ScriptStructPtr;

		// Token: 0x0400EA84 RID: 60036
		internal static int __PropertyOffset_0;

		// Token: 0x0400EA85 RID: 60037
		internal static int __PropertyOffset_1;

		// Token: 0x0400EA86 RID: 60038
		internal static int __PropertyOffset_2;

		// Token: 0x0400EA87 RID: 60039
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<string, FName> _UseComponents_Name__SocketName;
	}
}
