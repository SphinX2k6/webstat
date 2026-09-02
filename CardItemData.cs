using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

// Token: 0x0200209D RID: 8349
[NullableContext(1)]
[Nullable(0)]
public class CardItemData : ICardItemData
{
	// Token: 0x170012FA RID: 4858
	// (get) Token: 0x0600FECA RID: 65226 RVA: 0x0045E7F7 File Offset: 0x0045C9F7
	// (set) Token: 0x0600FECB RID: 65227 RVA: 0x0045E7FF File Offset: 0x0045C9FF
	public int Id { get; set; }

	// Token: 0x170012FB RID: 4859
	// (get) Token: 0x0600FECC RID: 65228 RVA: 0x0045E808 File Offset: 0x0045CA08
	// (set) Token: 0x0600FECD RID: 65229 RVA: 0x0045E810 File Offset: 0x0045CA10
	public List<ITalkOption> Options { get; set; }

	// Token: 0x170012FC RID: 4860
	// (get) Token: 0x0600FECE RID: 65230 RVA: 0x0045E819 File Offset: 0x0045CA19
	// (set) Token: 0x0600FECF RID: 65231 RVA: 0x0045E821 File Offset: 0x0045CA21
	public string Tid { get; set; }

	// Token: 0x170012FD RID: 4861
	// (get) Token: 0x0600FED0 RID: 65232 RVA: 0x0045E82A File Offset: 0x0045CA2A
	// (set) Token: 0x0600FED1 RID: 65233 RVA: 0x0045E832 File Offset: 0x0045CA32
	public int WhoId { get; set; }

	// Token: 0x170012FE RID: 4862
	// (get) Token: 0x0600FED2 RID: 65234 RVA: 0x0045E83B File Offset: 0x0045CA3B
	// (set) Token: 0x0600FED3 RID: 65235 RVA: 0x0045E843 File Offset: 0x0045CA43
	public string BackGroundConfig { get; set; }
}
