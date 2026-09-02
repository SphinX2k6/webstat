using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Character.Components
{
	// Token: 0x02003D95 RID: 15765
	[HasGetTypeHash]
	[UnrealBlittableStruct(UnrealReflectionPropertyTypeCode.UnrealBlittableStruct)]
	[UnrealStructLayout(24, 4, UnrealReflectionPropertyTypeCode.UnrealBlittableStruct, PropertiesSize = 24)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Character/Components/SMaterialDebugInfo.SMaterialDebugInfo")]
	[StructLayout(LayoutKind.Explicit, Pack = 4, Size = 24)]
	public struct SMaterialDebugInfo : IEqualityOperators<SMaterialDebugInfo, SMaterialDebugInfo, bool>, IEquatable<SMaterialDebugInfo>, IUnrealScriptStruct
	{
		// Token: 0x06026823 RID: 157731 RVA: 0x009DA454 File Offset: 0x009D8654
		public SMaterialDebugInfo(FName CurrentController, FName RenderingContent)
		{
			this.CurrentController = CurrentController;
			this.RenderingContent = RenderingContent;
		}

		// Token: 0x06026824 RID: 157732 RVA: 0x009DA464 File Offset: 0x009D8664
		public static bool operator ==(SMaterialDebugInfo left, SMaterialDebugInfo right)
		{
			return left.CurrentController == right.CurrentController && left.RenderingContent == right.RenderingContent;
		}

		// Token: 0x06026825 RID: 157733 RVA: 0x009DA48C File Offset: 0x009D868C
		public static bool operator !=(SMaterialDebugInfo left, SMaterialDebugInfo right)
		{
			return !(left == right);
		}

		// Token: 0x06026826 RID: 157734 RVA: 0x009DA498 File Offset: 0x009D8698
		public bool Equals(SMaterialDebugInfo other)
		{
			return this == other;
		}

		// Token: 0x06026827 RID: 157735 RVA: 0x009DA4A8 File Offset: 0x009D86A8
		[NullableContext(2)]
		public override bool Equals(object obj)
		{
			if (obj is SMaterialDebugInfo)
			{
				SMaterialDebugInfo other = (SMaterialDebugInfo)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x06026828 RID: 157736 RVA: 0x009DA4CD File Offset: 0x009D86CD
		public override int GetHashCode()
		{
			return HashCode.Combine<FName, FName>(this.CurrentController, this.RenderingContent);
		}

		// Token: 0x06026829 RID: 157737 RVA: 0x009DA4E0 File Offset: 0x009D86E0
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SMaterialDebugInfo._ScriptStructPtr != 0) ? SMaterialDebugInfo._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/Character/Components/SMaterialDebugInfo.SMaterialDebugInfo", ref SMaterialDebugInfo._ScriptStructPtr);
		}

		// Token: 0x04014055 RID: 82005
		[FieldOffset(0)]
		public FName CurrentController;

		// Token: 0x04014056 RID: 82006
		[FieldOffset(12)]
		public FName RenderingContent;

		// Token: 0x04014057 RID: 82007
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Character/Components/SMaterialDebugInfo.SMaterialDebugInfo";

		// Token: 0x04014058 RID: 82008
		private static IntPtr _ScriptStructPtr;
	}
}
