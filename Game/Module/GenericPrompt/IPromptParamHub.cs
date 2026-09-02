using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.GenericPrompt
{
	// Token: 0x02005CA5 RID: 23717
	[NullableContext(2)]
	public interface IPromptParamHub
	{
		// Token: 0x1700982A RID: 38954
		// (get) Token: 0x0603BDCE RID: 245198
		// (set) Token: 0x0603BDCF RID: 245199
		int TypeId { get; set; }

		// Token: 0x1700982B RID: 38955
		// (get) Token: 0x0603BDD0 RID: 245200
		// (set) Token: 0x0603BDD1 RID: 245201
		TableTextArgNew MainTextObj { get; set; }

		// Token: 0x1700982C RID: 38956
		// (get) Token: 0x0603BDD2 RID: 245202
		// (set) Token: 0x0603BDD3 RID: 245203
		TableTextArgNew ExtraTextObj { get; set; }

		// Token: 0x1700982D RID: 38957
		// (get) Token: 0x0603BDD4 RID: 245204
		// (set) Token: 0x0603BDD5 RID: 245205
		int? PromptId { get; set; }

		// Token: 0x1700982E RID: 38958
		// (get) Token: 0x0603BDD6 RID: 245206
		// (set) Token: 0x0603BDD7 RID: 245207
		[Nullable(new byte[]
		{
			2,
			1
		})]
		IReadOnlyList<object> MainTextParams { [return: Nullable(new byte[]
		{
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1
		})] set; }

		// Token: 0x1700982F RID: 38959
		// (get) Token: 0x0603BDD8 RID: 245208
		// (set) Token: 0x0603BDD9 RID: 245209
		[Nullable(new byte[]
		{
			2,
			1
		})]
		IReadOnlyList<object> ExtraTextParams { [return: Nullable(new byte[]
		{
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1
		})] set; }

		// Token: 0x17009830 RID: 38960
		// (get) Token: 0x0603BDDA RID: 245210
		// (set) Token: 0x0603BDDB RID: 245211
		Action CloseCallback { get; set; }

		// Token: 0x17009831 RID: 38961
		// (get) Token: 0x0603BDDC RID: 245212
		// (set) Token: 0x0603BDDD RID: 245213
		float? Duration { get; set; }

		// Token: 0x17009832 RID: 38962
		// (get) Token: 0x0603BDDE RID: 245214
		// (set) Token: 0x0603BDDF RID: 245215
		string PromptKey { get; set; }

		// Token: 0x17009833 RID: 38963
		// (get) Token: 0x0603BDE0 RID: 245216
		object ExtraParamObj { get; }
	}
}
