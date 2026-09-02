using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004DA1 RID: 19873
	public class TrapDefenseBuildingData
	{
		// Token: 0x06033796 RID: 210838 RVA: 0x00CDFA7E File Offset: 0x00CDDC7E
		[NullableContext(1)]
		public static TrapDefenseBuildingData Create(int id)
		{
			TrapDefenseBuildingData trapDefenseBuildingData = new TrapDefenseBuildingData(id);
			trapDefenseBuildingData.Init();
			return trapDefenseBuildingData;
		}

		// Token: 0x06033797 RID: 210839 RVA: 0x00CDFA8C File Offset: 0x00CDDC8C
		private TrapDefenseBuildingData(int id)
		{
			this.Id = id;
		}

		// Token: 0x06033798 RID: 210840 RVA: 0x00CDFA9B File Offset: 0x00CDDC9B
		private void Init()
		{
		}

		// Token: 0x0401DD0D RID: 122125
		public int Id;
	}
}
