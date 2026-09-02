using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Common.InputView.View
{
	// Token: 0x02005E79 RID: 24185
	[NullableContext(1)]
	public interface ITextInputData
	{
		// Token: 0x1700994F RID: 39247
		// (get) Token: 0x0603CD33 RID: 249139
		// (set) Token: 0x0603CD34 RID: 249140
		TConfirm ConfirmFunc { get; set; }

		// Token: 0x17009950 RID: 39248
		// (get) Token: 0x0603CD35 RID: 249141
		// (set) Token: 0x0603CD36 RID: 249142
		TResult ResultFunc { get; set; }

		// Token: 0x17009951 RID: 39249
		// (get) Token: 0x0603CD37 RID: 249143
		// (set) Token: 0x0603CD38 RID: 249144
		string InputText { get; set; }

		// Token: 0x17009952 RID: 39250
		// (get) Token: 0x0603CD39 RID: 249145
		// (set) Token: 0x0603CD3A RID: 249146
		[Nullable(2)]
		string DefaultText { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x17009953 RID: 39251
		// (get) Token: 0x0603CD3B RID: 249147
		// (set) Token: 0x0603CD3C RID: 249148
		bool IsCheckNone { get; set; }
	}
}
