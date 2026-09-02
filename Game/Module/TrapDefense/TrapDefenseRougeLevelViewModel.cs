using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004E09 RID: 19977
	[NullableContext(1)]
	[Nullable(0)]
	public class TrapDefenseRougeLevelViewModel
	{
		// Token: 0x06033A99 RID: 211609 RVA: 0x00CE9387 File Offset: 0x00CE7587
		public static TrapDefenseRougeLevelViewModel Create(TrapDefenseModel model)
		{
			return new TrapDefenseRougeLevelViewModel
			{
				Model = model
			};
		}

		// Token: 0x06033A9A RID: 211610 RVA: 0x00CE9395 File Offset: 0x00CE7595
		private TrapDefenseRougeLevelViewModel()
		{
		}

		// Token: 0x06033A9B RID: 211611 RVA: 0x00CE939D File Offset: 0x00CE759D
		public void OnViewClose()
		{
		}

		// Token: 0x06033A9C RID: 211612 RVA: 0x00CE93A0 File Offset: 0x00CE75A0
		public void SetJumpLevelData(int? id)
		{
			TrapDefenseLevelData trapDefenseLevelData;
			this.JumpLevelData = (this.Model.LevelDataFromIdMap.TryGetValue(id.GetValueOrDefault(), out trapDefenseLevelData) ? trapDefenseLevelData : null);
		}

		// Token: 0x06033A9D RID: 211613 RVA: 0x00CE93D2 File Offset: 0x00CE75D2
		public void SetIsInstance(bool isInstance)
		{
			this.IsInstance = isInstance;
		}

		// Token: 0x0401DECE RID: 122574
		public TrapDefenseModel Model;

		// Token: 0x0401DECF RID: 122575
		[Nullable(2)]
		public TrapDefenseLevelData JumpLevelData;

		// Token: 0x0401DED0 RID: 122576
		public bool IsInstance;
	}
}
