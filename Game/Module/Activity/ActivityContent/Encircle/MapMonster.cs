using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Encircle
{
	// Token: 0x02006869 RID: 26729
	[NullableContext(2)]
	[Nullable(0)]
	internal class MapMonster
	{
		// Token: 0x060429BF RID: 272831 RVA: 0x011186BE File Offset: 0x011168BE
		[NullableContext(1)]
		public MapMonster(IHexPos pos, int mapItemId, int priority)
		{
			this.PosInternal = pos;
			this.MapItemIdInternal = new int?(mapItemId);
			this.PriorityInternal = priority;
		}

		// Token: 0x1700A1AC RID: 41388
		// (get) Token: 0x060429C0 RID: 272832 RVA: 0x011186E7 File Offset: 0x011168E7
		public int Priority
		{
			get
			{
				return this.PriorityInternal;
			}
		}

		// Token: 0x1700A1AD RID: 41389
		// (get) Token: 0x060429C1 RID: 272833 RVA: 0x011186EF File Offset: 0x011168EF
		// (set) Token: 0x060429C2 RID: 272834 RVA: 0x011186F7 File Offset: 0x011168F7
		public IHexPos Pos
		{
			get
			{
				return this.PosInternal;
			}
			set
			{
				this.PosInternal = value;
			}
		}

		// Token: 0x1700A1AE RID: 41390
		// (get) Token: 0x060429C3 RID: 272835 RVA: 0x01118700 File Offset: 0x01116900
		// (set) Token: 0x060429C4 RID: 272836 RVA: 0x01118708 File Offset: 0x01116908
		public bool BeTrapped
		{
			get
			{
				return this.BeTrappedInternal;
			}
			set
			{
				this.BeTrappedInternal = value;
			}
		}

		// Token: 0x1700A1AF RID: 41391
		// (get) Token: 0x060429C5 RID: 272837 RVA: 0x01118711 File Offset: 0x01116911
		// (set) Token: 0x060429C6 RID: 272838 RVA: 0x01118719 File Offset: 0x01116919
		public bool BeCaught
		{
			get
			{
				return this.BeCaughtInternal;
			}
			set
			{
				this.BeCaughtInternal = value;
			}
		}

		// Token: 0x1700A1B0 RID: 41392
		// (get) Token: 0x060429C7 RID: 272839 RVA: 0x01118722 File Offset: 0x01116922
		// (set) Token: 0x060429C8 RID: 272840 RVA: 0x0111872A File Offset: 0x0111692A
		public int? MapItemId
		{
			get
			{
				return this.MapItemIdInternal;
			}
			set
			{
				this.MapItemIdInternal = value;
			}
		}

		// Token: 0x04025123 RID: 151843
		private IHexPos PosInternal;

		// Token: 0x04025124 RID: 151844
		private int? MapItemIdInternal;

		// Token: 0x04025125 RID: 151845
		private bool BeTrappedInternal;

		// Token: 0x04025126 RID: 151846
		private bool BeCaughtInternal;

		// Token: 0x04025127 RID: 151847
		private readonly int PriorityInternal = 1;
	}
}
