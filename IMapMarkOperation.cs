using System;
using CSharpScript.Game.Module.Map.MapDefine;

// Token: 0x0200223F RID: 8767
public interface IMapMarkOperation : IMapOperation
{
	// Token: 0x17001465 RID: 5221
	// (get) Token: 0x060108CA RID: 67786
	// (set) Token: 0x060108CB RID: 67787
	EMarkType MarkType { get; set; }

	// Token: 0x17001466 RID: 5222
	// (get) Token: 0x060108CC RID: 67788
	// (set) Token: 0x060108CD RID: 67789
	int? MarkId { get; set; }
}
