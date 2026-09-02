using System;
using System.Runtime.CompilerServices;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace UnrealEngine
{
	// Token: 0x020043EF RID: 17391
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/json2struct/example.example")]
	[UnrealStructLayout(152, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 152)]
	public class example : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602E2F1 RID: 189169 RVA: 0x00ADB666 File Offset: 0x00AD9866
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (example._ScriptStructPtr != 0) ? example._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/json2struct/example.example", ref example._ScriptStructPtr);
		}

		// Token: 0x17007F29 RID: 32553
		// (get) Token: 0x0602E2F2 RID: 189170 RVA: 0x00ADB68A File Offset: 0x00AD988A
		// (set) Token: 0x0602E2F3 RID: 189171 RVA: 0x00ADB69E File Offset: 0x00AD989E
		public unsafe string String
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)example.__PropertyOffset_0)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)example.__PropertyOffset_0)), value);
			}
		}

		// Token: 0x17007F2A RID: 32554
		// (get) Token: 0x0602E2F4 RID: 189172 RVA: 0x00ADB6B3 File Offset: 0x00AD98B3
		// (set) Token: 0x0602E2F5 RID: 189173 RVA: 0x00ADB6C3 File Offset: 0x00AD98C3
		public unsafe bool Boolean
		{
			get
			{
				return *(base.NativePtr + (IntPtr)example.__PropertyOffset_1) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)example.__PropertyOffset_1) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007F2B RID: 32555
		// (get) Token: 0x0602E2F6 RID: 189174 RVA: 0x00ADB6D4 File Offset: 0x00AD98D4
		// (set) Token: 0x0602E2F7 RID: 189175 RVA: 0x00ADB6E4 File Offset: 0x00AD98E4
		public unsafe int Integer
		{
			get
			{
				return *(base.NativePtr + (IntPtr)example.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)example.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17007F2C RID: 32556
		// (get) Token: 0x0602E2F8 RID: 189176 RVA: 0x00ADB6F5 File Offset: 0x00AD98F5
		// (set) Token: 0x0602E2F9 RID: 189177 RVA: 0x00ADB705 File Offset: 0x00AD9905
		public unsafe float Float
		{
			get
			{
				return *(base.NativePtr + (IntPtr)example.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)example.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17007F2D RID: 32557
		// (get) Token: 0x0602E2FA RID: 189178 RVA: 0x00ADB718 File Offset: 0x00AD9918
		// (set) Token: 0x0602E2FB RID: 189179 RVA: 0x00ADB75B File Offset: 0x00AD995B
		public ExampleNested Struct
		{
			get
			{
				base.FastCheckIsValid();
				ExampleNested result;
				if ((result = this._Struct) == null)
				{
					result = (this._Struct = new ExampleNested(base.NativePtr + (IntPtr)example.__PropertyOffset_4, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(ExampleNested.StaticStruct(), base.NativePtr + (IntPtr)example.__PropertyOffset_4, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007F2E RID: 32558
		// (get) Token: 0x0602E2FC RID: 189180 RVA: 0x00ADB77C File Offset: 0x00AD997C
		// (set) Token: 0x0602E2FD RID: 189181 RVA: 0x00ADB7BF File Offset: 0x00AD99BF
		public TArray<ExampleNested> Array
		{
			get
			{
				base.FastCheckIsValid();
				TArray<ExampleNested> result;
				if ((result = this._Array) == null)
				{
					result = (this._Array = new TArray<ExampleNested>(base.NativePtr + (IntPtr)example.__PropertyOffset_5, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.Array.CopyAssign(value);
			}
		}

		// Token: 0x17007F2F RID: 32559
		// (get) Token: 0x0602E2FE RID: 189182 RVA: 0x00ADB7D0 File Offset: 0x00AD99D0
		// (set) Token: 0x0602E2FF RID: 189183 RVA: 0x00ADB813 File Offset: 0x00AD9A13
		public TMap<string, ExampleNested> Map
		{
			get
			{
				base.FastCheckIsValid();
				TMap<string, ExampleNested> result;
				if ((result = this._Map) == null)
				{
					result = (this._Map = new TMap<string, ExampleNested>(base.NativePtr + (IntPtr)example.__PropertyOffset_6, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.Map.CopyAssign(value);
			}
		}

		// Token: 0x0602E300 RID: 189184 RVA: 0x00ADB821 File Offset: 0x00AD9A21
		public example()
		{
		}

		// Token: 0x0602E301 RID: 189185 RVA: 0x00ADB829 File Offset: 0x00AD9A29
		public example(string String, bool Boolean, int Integer, float Float, ExampleNested Struct, TArray<ExampleNested> Array, TMap<string, ExampleNested> Map)
		{
			this.String = String;
			this.Boolean = Boolean;
			this.Integer = Integer;
			this.Float = Float;
			this.Struct = Struct;
			this.Array = Array;
			this.Map = Map;
		}

		// Token: 0x0602E302 RID: 189186 RVA: 0x00ADB866 File Offset: 0x00AD9A66
		protected override IntPtr GetUStructPtr()
		{
			return example.StaticStruct();
		}

		// Token: 0x0602E303 RID: 189187 RVA: 0x00ADB872 File Offset: 0x00AD9A72
		[NullableContext(2)]
		public example(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602E304 RID: 189188 RVA: 0x00ADB87C File Offset: 0x00AD9A7C
		public example(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602E305 RID: 189189 RVA: 0x00ADB887 File Offset: 0x00AD9A87
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new example(Pointer, false, true);
		}

		// Token: 0x0602E306 RID: 189190 RVA: 0x00ADB891 File Offset: 0x00AD9A91
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new example(Pointer, MemoryOwner);
		}

		// Token: 0x0401A218 RID: 107032
		public const string __ObjectPath = "/json2struct/example.example";

		// Token: 0x0401A219 RID: 107033
		private static IntPtr _ScriptStructPtr;

		// Token: 0x0401A21A RID: 107034
		internal static int __PropertyOffset_0;

		// Token: 0x0401A21B RID: 107035
		internal static int __PropertyOffset_1;

		// Token: 0x0401A21C RID: 107036
		internal static int __PropertyOffset_2;

		// Token: 0x0401A21D RID: 107037
		internal static int __PropertyOffset_3;

		// Token: 0x0401A21E RID: 107038
		internal static int __PropertyOffset_4;

		// Token: 0x0401A21F RID: 107039
		[Nullable(2)]
		private ExampleNested _Struct;

		// Token: 0x0401A220 RID: 107040
		internal static int __PropertyOffset_5;

		// Token: 0x0401A221 RID: 107041
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<ExampleNested> _Array;

		// Token: 0x0401A222 RID: 107042
		internal static int __PropertyOffset_6;

		// Token: 0x0401A223 RID: 107043
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private TMap<string, ExampleNested> _Map;
	}
}
