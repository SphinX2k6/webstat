using System;

namespace CSharpScript.Game.Module.Map.MapDefine
{
	// Token: 0x020058E0 RID: 22752
	public class MarkCreateInfo
	{
		// Token: 0x170093A6 RID: 37798
		// (get) Token: 0x06039BF7 RID: 236535 RVA: 0x00EA06BF File Offset: 0x00E9E8BF
		// (set) Token: 0x06039BF8 RID: 236536 RVA: 0x00EA06C7 File Offset: 0x00E9E8C7
		public virtual EMarkCreateType CreateType { get; protected set; }

		// Token: 0x06039BF9 RID: 236537 RVA: 0x00EA06D0 File Offset: 0x00E9E8D0
		public MarkCreateInfo(EMarkCreateType createType)
		{
			this.CreateType = createType;
		}
	}
}
