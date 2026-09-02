using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.GenericPrompt
{
	// Token: 0x02005CA6 RID: 23718
	[NullableContext(2)]
	[Nullable(0)]
	public class PromptParamHub<T> : IPromptParamHub
	{
		// Token: 0x17009834 RID: 38964
		// (get) Token: 0x0603BDE1 RID: 245217 RVA: 0x00F2C515 File Offset: 0x00F2A715
		// (set) Token: 0x0603BDE2 RID: 245218 RVA: 0x00F2C51D File Offset: 0x00F2A71D
		public int TypeId { get; set; }

		// Token: 0x17009835 RID: 38965
		// (get) Token: 0x0603BDE3 RID: 245219 RVA: 0x00F2C526 File Offset: 0x00F2A726
		// (set) Token: 0x0603BDE4 RID: 245220 RVA: 0x00F2C52E File Offset: 0x00F2A72E
		public TableTextArgNew MainTextObj { get; set; }

		// Token: 0x17009836 RID: 38966
		// (get) Token: 0x0603BDE5 RID: 245221 RVA: 0x00F2C537 File Offset: 0x00F2A737
		// (set) Token: 0x0603BDE6 RID: 245222 RVA: 0x00F2C53F File Offset: 0x00F2A73F
		public TableTextArgNew ExtraTextObj { get; set; }

		// Token: 0x17009837 RID: 38967
		// (get) Token: 0x0603BDE7 RID: 245223 RVA: 0x00F2C548 File Offset: 0x00F2A748
		// (set) Token: 0x0603BDE8 RID: 245224 RVA: 0x00F2C550 File Offset: 0x00F2A750
		public int? PromptId { get; set; }

		// Token: 0x17009838 RID: 38968
		// (get) Token: 0x0603BDE9 RID: 245225 RVA: 0x00F2C559 File Offset: 0x00F2A759
		// (set) Token: 0x0603BDEA RID: 245226 RVA: 0x00F2C561 File Offset: 0x00F2A761
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public IReadOnlyList<object> MainTextParams { [return: Nullable(new byte[]
		{
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1
		})] set; }

		// Token: 0x17009839 RID: 38969
		// (get) Token: 0x0603BDEB RID: 245227 RVA: 0x00F2C56A File Offset: 0x00F2A76A
		// (set) Token: 0x0603BDEC RID: 245228 RVA: 0x00F2C572 File Offset: 0x00F2A772
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public IReadOnlyList<object> ExtraTextParams { [return: Nullable(new byte[]
		{
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1
		})] set; }

		// Token: 0x1700983A RID: 38970
		// (get) Token: 0x0603BDED RID: 245229 RVA: 0x00F2C57B File Offset: 0x00F2A77B
		// (set) Token: 0x0603BDEE RID: 245230 RVA: 0x00F2C583 File Offset: 0x00F2A783
		public Action CloseCallback { get; set; }

		// Token: 0x1700983B RID: 38971
		// (get) Token: 0x0603BDEF RID: 245231 RVA: 0x00F2C58C File Offset: 0x00F2A78C
		// (set) Token: 0x0603BDF0 RID: 245232 RVA: 0x00F2C594 File Offset: 0x00F2A794
		public float? Duration { get; set; }

		// Token: 0x1700983C RID: 38972
		// (get) Token: 0x0603BDF1 RID: 245233 RVA: 0x00F2C59D File Offset: 0x00F2A79D
		// (set) Token: 0x0603BDF2 RID: 245234 RVA: 0x00F2C5A5 File Offset: 0x00F2A7A5
		public string PromptKey { get; set; }

		// Token: 0x1700983D RID: 38973
		// (get) Token: 0x0603BDF3 RID: 245235 RVA: 0x00F2C5AE File Offset: 0x00F2A7AE
		// (set) Token: 0x0603BDF4 RID: 245236 RVA: 0x00F2C5B6 File Offset: 0x00F2A7B6
		public T ExtraParam { get; set; }

		// Token: 0x1700983E RID: 38974
		// (get) Token: 0x0603BDF5 RID: 245237 RVA: 0x00F2C5BF File Offset: 0x00F2A7BF
		public object ExtraParamObj
		{
			get
			{
				return this.ExtraParam;
			}
		}
	}
}
