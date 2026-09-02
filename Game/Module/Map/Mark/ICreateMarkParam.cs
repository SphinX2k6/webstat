using System;
using Aki.Config;
using CSharpScript.Game.Module.Map.MapDefine;

namespace CSharpScript.Game.Module.Map.Mark
{
	// Token: 0x0200581F RID: 22559
	public interface ICreateMarkParam
	{
		// Token: 0x17009228 RID: 37416
		// (get) Token: 0x060395A1 RID: 234913
		// (set) Token: 0x060395A2 RID: 234914
		int MarkId { get; set; }

		// Token: 0x17009229 RID: 37417
		// (get) Token: 0x060395A3 RID: 234915
		// (set) Token: 0x060395A4 RID: 234916
		EMarkType MarkType { get; set; }

		// Token: 0x1700922A RID: 37418
		// (get) Token: 0x060395A5 RID: 234917
		// (set) Token: 0x060395A6 RID: 234918
		EMapGravityDirection Gravity { get; set; }

		// Token: 0x1700922B RID: 37419
		// (get) Token: 0x060395A7 RID: 234919
		// (set) Token: 0x060395A8 RID: 234920
		MapMark Config { get; set; }

		// Token: 0x1700922C RID: 37420
		// (get) Token: 0x060395A9 RID: 234921
		// (set) Token: 0x060395AA RID: 234922
		DynamicMapMark DynamicConfig { get; set; }

		// Token: 0x1700922D RID: 37421
		// (get) Token: 0x060395AB RID: 234923
		// (set) Token: 0x060395AC RID: 234924
		int EntityId { get; set; }

		// Token: 0x1700922E RID: 37422
		// (get) Token: 0x060395AD RID: 234925
		// (set) Token: 0x060395AE RID: 234926
		int MapId { get; set; }
	}
}
