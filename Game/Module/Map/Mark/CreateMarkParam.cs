using System;
using Aki.Config;
using CSharpScript.Game.Module.Map.MapDefine;

namespace CSharpScript.Game.Module.Map.Mark
{
	// Token: 0x02005820 RID: 22560
	public class CreateMarkParam : ICreateMarkParam
	{
		// Token: 0x1700922F RID: 37423
		// (get) Token: 0x060395AF RID: 234927 RVA: 0x00E8E428 File Offset: 0x00E8C628
		// (set) Token: 0x060395B0 RID: 234928 RVA: 0x00E8E430 File Offset: 0x00E8C630
		public int MarkId { get; set; }

		// Token: 0x17009230 RID: 37424
		// (get) Token: 0x060395B1 RID: 234929 RVA: 0x00E8E439 File Offset: 0x00E8C639
		// (set) Token: 0x060395B2 RID: 234930 RVA: 0x00E8E441 File Offset: 0x00E8C641
		public EMarkType MarkType { get; set; }

		// Token: 0x17009231 RID: 37425
		// (get) Token: 0x060395B3 RID: 234931 RVA: 0x00E8E44A File Offset: 0x00E8C64A
		// (set) Token: 0x060395B4 RID: 234932 RVA: 0x00E8E452 File Offset: 0x00E8C652
		public EMapGravityDirection Gravity { get; set; }

		// Token: 0x17009232 RID: 37426
		// (get) Token: 0x060395B5 RID: 234933 RVA: 0x00E8E45B File Offset: 0x00E8C65B
		// (set) Token: 0x060395B6 RID: 234934 RVA: 0x00E8E463 File Offset: 0x00E8C663
		public MapMark Config { get; set; }

		// Token: 0x17009233 RID: 37427
		// (get) Token: 0x060395B7 RID: 234935 RVA: 0x00E8E46C File Offset: 0x00E8C66C
		// (set) Token: 0x060395B8 RID: 234936 RVA: 0x00E8E474 File Offset: 0x00E8C674
		public DynamicMapMark DynamicConfig { get; set; }

		// Token: 0x17009234 RID: 37428
		// (get) Token: 0x060395B9 RID: 234937 RVA: 0x00E8E47D File Offset: 0x00E8C67D
		// (set) Token: 0x060395BA RID: 234938 RVA: 0x00E8E485 File Offset: 0x00E8C685
		public int EntityId { get; set; }

		// Token: 0x17009235 RID: 37429
		// (get) Token: 0x060395BB RID: 234939 RVA: 0x00E8E48E File Offset: 0x00E8C68E
		// (set) Token: 0x060395BC RID: 234940 RVA: 0x00E8E496 File Offset: 0x00E8C696
		public int MapId { get; set; }
	}
}
