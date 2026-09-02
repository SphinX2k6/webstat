using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004E19 RID: 19993
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class TrapDefenseBuildingDevelopDragDataItem : CommonDragLogicDataItem<TrapDefenseBuildingDevelopItemData>
	{
		// Token: 0x06033B2C RID: 211756 RVA: 0x00CEBB9D File Offset: 0x00CE9D9D
		public override bool CheckIfCanDrag()
		{
			return ModelBase<TrapDefenseModel>.Instance.ViewModelBuildingDevelop.CheckIfCanDrag();
		}

		// Token: 0x06033B2D RID: 211757 RVA: 0x00CEBBAE File Offset: 0x00CE9DAE
		public override bool CheckIfCurrentDragIndex(int index)
		{
			return ModelBase<TrapDefenseModel>.Instance.ViewModelBuildingDevelop.CheckIfCurrentDragIndex(index);
		}

		// Token: 0x06033B2E RID: 211758 RVA: 0x00CEBBC0 File Offset: 0x00CE9DC0
		public override void SetCurrentDragIndex(int index)
		{
			ModelBase<TrapDefenseModel>.Instance.ViewModelBuildingDevelop.SetCurrentDragIndex(index);
		}

		// Token: 0x06033B2F RID: 211759 RVA: 0x00CEBBD2 File Offset: 0x00CE9DD2
		public override void ClearCurrentDragIndex()
		{
			ModelBase<TrapDefenseModel>.Instance.ViewModelBuildingDevelop.ClearCurrentDragIndex();
		}

		// Token: 0x06033B30 RID: 211760 RVA: 0x00CEBBE3 File Offset: 0x00CE9DE3
		public override float GetClickTime()
		{
			if (this.ClickTime == -1f)
			{
				this.ClickTime = (float)ConfigBase<TrapDefenseConfig>.Instance.GetDragItemClickTime();
			}
			return this.ClickTime;
		}

		// Token: 0x0401DEFD RID: 122621
		private float ClickTime = -1f;
	}
}
