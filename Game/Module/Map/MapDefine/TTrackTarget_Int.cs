using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Map.MapDefine
{
	// Token: 0x020058EB RID: 22763
	[NullableContext(1)]
	[Nullable(0)]
	public class TTrackTarget_Int : TTrackTarget
	{
		// Token: 0x06039C36 RID: 236598 RVA: 0x00EA09E0 File Offset: 0x00E9EBE0
		public TTrackTarget_Int(int Value)
		{
		}

		// Token: 0x06039C37 RID: 236599 RVA: 0x00EA09EF File Offset: 0x00E9EBEF
		public static implicit operator int(TTrackTarget_Int target)
		{
			return target.Value;
		}

		// Token: 0x06039C38 RID: 236600 RVA: 0x00EA09F7 File Offset: 0x00E9EBF7
		public new static implicit operator TTrackTarget_Int(int value)
		{
			return new TTrackTarget_Int(value);
		}

		// Token: 0x06039C39 RID: 236601 RVA: 0x00EA0A00 File Offset: 0x00E9EC00
		[NullableContext(2)]
		public override bool Equals(object obj)
		{
			TTrackTarget_Int ttrackTarget_Int = obj as TTrackTarget_Int;
			return ttrackTarget_Int != null && this.Value == ttrackTarget_Int.Value;
		}

		// Token: 0x06039C3A RID: 236602 RVA: 0x00EA0A27 File Offset: 0x00E9EC27
		public override int GetHashCode()
		{
			return this.Value.GetHashCode();
		}

		// Token: 0x04020C05 RID: 134149
		public int Value = Value;
	}
}
