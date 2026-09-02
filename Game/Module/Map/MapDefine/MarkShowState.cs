using System;
using Aki.Protocol;

namespace CSharpScript.Game.Module.Map.MapDefine
{
	// Token: 0x020058E1 RID: 22753
	public class MarkShowState : IMarkShowState
	{
		// Token: 0x170093A7 RID: 37799
		// (get) Token: 0x06039BFA RID: 236538 RVA: 0x00EA06DF File Offset: 0x00E9E8DF
		// (set) Token: 0x06039BFB RID: 236539 RVA: 0x00EA06E7 File Offset: 0x00E9E8E7
		public int Id { get; set; }

		// Token: 0x170093A8 RID: 37800
		// (get) Token: 0x06039BFC RID: 236540 RVA: 0x00EA06F0 File Offset: 0x00E9E8F0
		// (set) Token: 0x06039BFD RID: 236541 RVA: 0x00EA06F8 File Offset: 0x00E9E8F8
		public bool NeedFocus { get; set; }

		// Token: 0x170093A9 RID: 37801
		// (get) Token: 0x06039BFE RID: 236542 RVA: 0x00EA0701 File Offset: 0x00E9E901
		// (set) Token: 0x06039BFF RID: 236543 RVA: 0x00EA0709 File Offset: 0x00E9E909
		public MapMarkShowFlag ShowFlag { get; set; }
	}
}
