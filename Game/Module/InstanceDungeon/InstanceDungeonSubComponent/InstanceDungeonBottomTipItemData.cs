using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.InstanceDungeon.InstanceDungeonSubComponent
{
	// Token: 0x02005BDF RID: 23519
	[NullableContext(1)]
	[Nullable(0)]
	public class InstanceDungeonBottomTipItemData
	{
		// Token: 0x1700979E RID: 38814
		// (get) Token: 0x0603B8B7 RID: 243895 RVA: 0x00F18083 File Offset: 0x00F16283
		// (set) Token: 0x0603B8B8 RID: 243896 RVA: 0x00F1808B File Offset: 0x00F1628B
		public string TextId { get; set; } = "";

		// Token: 0x1700979F RID: 38815
		// (get) Token: 0x0603B8B9 RID: 243897 RVA: 0x00F18094 File Offset: 0x00F16294
		// (set) Token: 0x0603B8BA RID: 243898 RVA: 0x00F1809C File Offset: 0x00F1629C
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public string[] TextArgs { [return: Nullable(new byte[]
		{
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1
		})] set; }
	}
}
