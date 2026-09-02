using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004DB6 RID: 19894
	[NullableContext(1)]
	[Nullable(0)]
	public class TrapDefenseCampMarkItem : TrapDefenseMarkItem
	{
		// Token: 0x06033878 RID: 211064 RVA: 0x00CE361B File Offset: 0x00CE181B
		[NullableContext(2)]
		public TrapDefenseCampMarkItem(int markId, object extraParam = null) : base(markId, extraParam)
		{
		}

		// Token: 0x06033879 RID: 211065 RVA: 0x00CE3625 File Offset: 0x00CE1825
		protected override void OnInitialize()
		{
			this.EnableCachePosition = true;
		}

		// Token: 0x1700881F RID: 34847
		// (get) Token: 0x0603387A RID: 211066 RVA: 0x00CE362E File Offset: 0x00CE182E
		public override TrapDefenseDefine.ETrapDefenseMarkType MarkType
		{
			get
			{
				return TrapDefenseDefine.ETrapDefenseMarkType.Camp;
			}
		}

		// Token: 0x17008820 RID: 34848
		// (get) Token: 0x0603387B RID: 211067 RVA: 0x00CE3631 File Offset: 0x00CE1831
		public override Vector WorldPosition
		{
			get
			{
				return ModelBase<TrapDefenseModel>.Instance.MapData.CampPosition;
			}
		}
	}
}
