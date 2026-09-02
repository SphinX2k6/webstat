using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Plot.Sequence.Qte
{
	// Token: 0x02005398 RID: 21400
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class SequenceQteSelectOption : SequenceQteHandleBase<CommonQteSelectOptionContext>
	{
		// Token: 0x0603693F RID: 223551 RVA: 0x00DCC39B File Offset: 0x00DCA59B
		public SequenceQteSelectOption(SequenceQteManager qteManager, CommonQteSelectOptionContext context) : base(qteManager, context)
		{
		}

		// Token: 0x06036940 RID: 223552 RVA: 0x00DCC3A5 File Offset: 0x00DCA5A5
		protected override void OnCommonQteFinished()
		{
			base.OptionIndex = this.Context.SelectOption;
			base.OnCommonQteFinished();
		}
	}
}
