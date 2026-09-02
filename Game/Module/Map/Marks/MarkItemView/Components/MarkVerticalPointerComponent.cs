using System;
using CSharpScript.Game.Module.Map.Mark;
using UnrealEngine;

namespace CSharpScript.Game.Module.Map.Marks.MarkItemView.Components
{
	// Token: 0x020058AD RID: 22701
	public class MarkVerticalPointerComponent : MarkPanelBase
	{
		// Token: 0x06039AC9 RID: 236233 RVA: 0x00E9FA8D File Offset: 0x00E9DC8D
		protected override void OnBeforeShow()
		{
			this.UpdatePointerType();
		}

		// Token: 0x06039ACA RID: 236234 RVA: 0x00E9FA95 File Offset: 0x00E9DC95
		public void SetPointerType(EVerticalPointerType type)
		{
			this.PointerType = type;
			if (base.IsShowOrShowing)
			{
				this.UpdatePointerType();
			}
		}

		// Token: 0x06039ACB RID: 236235 RVA: 0x00E9FAAC File Offset: 0x00E9DCAC
		private void UpdatePointerType()
		{
			switch (this.PointerType)
			{
			case EVerticalPointerType.None:
				this.HideSelf();
				return;
			case EVerticalPointerType.Up:
				this.ShowUp();
				return;
			case EVerticalPointerType.Down:
				this.ShowDown();
				return;
			default:
				return;
			}
		}

		// Token: 0x06039ACC RID: 236236 RVA: 0x00E9FAE8 File Offset: 0x00E9DCE8
		public void ShowUp()
		{
			UUIItem rootItem = this.RootItem;
			if (rootItem != null)
			{
				rootItem.SetUIActive(true);
			}
			UUIItem rootItem2 = this.RootItem;
			if (rootItem2 == null)
			{
				return;
			}
			FRotator frotator = new FRotator(0f, 0f, 0f);
			rootItem2.SetUIRelativeRotation(frotator);
		}

		// Token: 0x06039ACD RID: 236237 RVA: 0x00E9FB30 File Offset: 0x00E9DD30
		public void ShowDown()
		{
			UUIItem rootItem = this.RootItem;
			if (rootItem != null)
			{
				rootItem.SetUIActive(true);
			}
			UUIItem rootItem2 = this.RootItem;
			if (rootItem2 == null)
			{
				return;
			}
			FRotator frotator = new FRotator(0f, 0f, 180f);
			rootItem2.SetUIRelativeRotation(frotator);
		}

		// Token: 0x06039ACE RID: 236238 RVA: 0x00E9FB76 File Offset: 0x00E9DD76
		public void HideSelf()
		{
			UUIItem rootItem = this.RootItem;
			if (rootItem == null)
			{
				return;
			}
			rootItem.SetUIActive(false);
		}

		// Token: 0x04020AFE RID: 133886
		private EVerticalPointerType PointerType;
	}
}
