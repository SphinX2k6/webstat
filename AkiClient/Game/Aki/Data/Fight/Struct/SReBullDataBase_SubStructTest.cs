using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Core.Fight;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Data.Fight.Struct
{
	// Token: 0x02003EDA RID: 16090
	[NullableContext(1)]
	[Nullable(0)]
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Data/Fight/Struct/SReBullDataBase_SubStructTest.SReBullDataBase_SubStructTest")]
	[UnrealStructLayout(40, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 40)]
	public class SReBullDataBase_SubStructTest : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06028059 RID: 163929 RVA: 0x00A007EC File Offset: 0x009FE9EC
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SReBullDataBase_SubStructTest._ScriptStructPtr != 0) ? SReBullDataBase_SubStructTest._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Fight/Struct/SReBullDataBase_SubStructTest.SReBullDataBase_SubStructTest", ref SReBullDataBase_SubStructTest._ScriptStructPtr);
		}

		// Token: 0x17006009 RID: 24585
		// (get) Token: 0x0602805A RID: 163930 RVA: 0x00A00810 File Offset: 0x009FEA10
		// (set) Token: 0x0602805B RID: 163931 RVA: 0x00A00820 File Offset: 0x009FEA20
		public unsafe bool 子弹新增结构布尔
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SReBullDataBase_SubStructTest.__PropertyOffset_0) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SReBullDataBase_SubStructTest.__PropertyOffset_0) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700600A RID: 24586
		// (get) Token: 0x0602805C RID: 163932 RVA: 0x00A00831 File Offset: 0x009FEA31
		// (set) Token: 0x0602805D RID: 163933 RVA: 0x00A00841 File Offset: 0x009FEA41
		public unsafe float 子弹新增结构浮点
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SReBullDataBase_SubStructTest.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SReBullDataBase_SubStructTest.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x1700600B RID: 24587
		// (get) Token: 0x0602805E RID: 163934 RVA: 0x00A00854 File Offset: 0x009FEA54
		// (set) Token: 0x0602805F RID: 163935 RVA: 0x00A00897 File Offset: 0x009FEA97
		public SReBulletDataScale 子弹新增结构字符串
		{
			get
			{
				base.FastCheckIsValid();
				SReBulletDataScale result;
				if ((result = this._子弹新增结构字符串) == null)
				{
					result = (this._子弹新增结构字符串 = new SReBulletDataScale(base.NativePtr + (IntPtr)SReBullDataBase_SubStructTest.__PropertyOffset_2, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SReBulletDataScale.StaticStruct(), base.NativePtr + (IntPtr)SReBullDataBase_SubStructTest.__PropertyOffset_2, value.NativePtr, 1, false);
			}
		}

		// Token: 0x06028060 RID: 163936 RVA: 0x00A008B8 File Offset: 0x009FEAB8
		public SReBullDataBase_SubStructTest()
		{
		}

		// Token: 0x06028061 RID: 163937 RVA: 0x00A008C0 File Offset: 0x009FEAC0
		public SReBullDataBase_SubStructTest(bool 子弹新增结构布尔, float 子弹新增结构浮点, SReBulletDataScale 子弹新增结构字符串)
		{
			this.子弹新增结构布尔 = 子弹新增结构布尔;
			this.子弹新增结构浮点 = 子弹新增结构浮点;
			this.子弹新增结构字符串 = 子弹新增结构字符串;
		}

		// Token: 0x06028062 RID: 163938 RVA: 0x00A008DD File Offset: 0x009FEADD
		protected override IntPtr GetUStructPtr()
		{
			return SReBullDataBase_SubStructTest.StaticStruct();
		}

		// Token: 0x06028063 RID: 163939 RVA: 0x00A008E9 File Offset: 0x009FEAE9
		[NullableContext(2)]
		public SReBullDataBase_SubStructTest(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06028064 RID: 163940 RVA: 0x00A008F3 File Offset: 0x009FEAF3
		public SReBullDataBase_SubStructTest(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06028065 RID: 163941 RVA: 0x00A008FE File Offset: 0x009FEAFE
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SReBullDataBase_SubStructTest(Pointer, false, true);
		}

		// Token: 0x06028066 RID: 163942 RVA: 0x00A00908 File Offset: 0x009FEB08
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SReBullDataBase_SubStructTest(Pointer, MemoryOwner);
		}

		// Token: 0x04015026 RID: 86054
		public const string __ObjectPath = "/Game/Aki/Data/Fight/Struct/SReBullDataBase_SubStructTest.SReBullDataBase_SubStructTest";

		// Token: 0x04015027 RID: 86055
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04015028 RID: 86056
		internal static int __PropertyOffset_0;

		// Token: 0x04015029 RID: 86057
		internal static int __PropertyOffset_1;

		// Token: 0x0401502A RID: 86058
		internal static int __PropertyOffset_2;

		// Token: 0x0401502B RID: 86059
		[Nullable(2)]
		private SReBulletDataScale _子弹新增结构字符串;
	}
}
