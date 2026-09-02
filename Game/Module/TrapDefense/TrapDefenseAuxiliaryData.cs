using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004D9D RID: 19869
	public class TrapDefenseAuxiliaryData
	{
		// Token: 0x06033748 RID: 210760 RVA: 0x00CDEAF7 File Offset: 0x00CDCCF7
		[NullableContext(1)]
		public static TrapDefenseAuxiliaryData Create(int id)
		{
			TrapDefenseAuxiliaryData trapDefenseAuxiliaryData = new TrapDefenseAuxiliaryData(id);
			trapDefenseAuxiliaryData.Init();
			return trapDefenseAuxiliaryData;
		}

		// Token: 0x06033749 RID: 210761 RVA: 0x00CDEB05 File Offset: 0x00CDCD05
		private TrapDefenseAuxiliaryData(int id)
		{
			this.Id = id;
		}

		// Token: 0x0603374A RID: 210762 RVA: 0x00CDEB14 File Offset: 0x00CDCD14
		private void Init()
		{
		}

		// Token: 0x0401DCF4 RID: 122100
		public int Id;
	}
}
