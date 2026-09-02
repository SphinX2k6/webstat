using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

// Token: 0x0200209C RID: 8348
[NullableContext(1)]
public interface ICardItemData
{
	// Token: 0x170012F5 RID: 4853
	// (get) Token: 0x0600FEC0 RID: 65216
	// (set) Token: 0x0600FEC1 RID: 65217
	int Id { get; set; }

	// Token: 0x170012F6 RID: 4854
	// (get) Token: 0x0600FEC2 RID: 65218
	// (set) Token: 0x0600FEC3 RID: 65219
	List<ITalkOption> Options { get; set; }

	// Token: 0x170012F7 RID: 4855
	// (get) Token: 0x0600FEC4 RID: 65220
	// (set) Token: 0x0600FEC5 RID: 65221
	string Tid { get; set; }

	// Token: 0x170012F8 RID: 4856
	// (get) Token: 0x0600FEC6 RID: 65222
	// (set) Token: 0x0600FEC7 RID: 65223
	int WhoId { get; set; }

	// Token: 0x170012F9 RID: 4857
	// (get) Token: 0x0600FEC8 RID: 65224
	// (set) Token: 0x0600FEC9 RID: 65225
	string BackGroundConfig { get; set; }
}
