using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02005FC2 RID: 24514
	public class BattleVisibleChildView : BattleChildView
	{
		// Token: 0x0603DA45 RID: 252485 RVA: 0x00FB4720 File Offset: 0x00FB2920
		protected void InitChildType(EBattleUiChild childType = EBattleUiChild.Common)
		{
			this.ChildType = childType;
			if (this.ChildType == EBattleUiChild.Ignore)
			{
				this.BaseVisible = true;
				this.InnerVisibleState = 1;
				return;
			}
			this.ChildViewData = ModelBase<BattleUiModel>.Instance.ChildViewData;
			this.BaseVisible = this.ChildViewData.GetChildVisible(childType);
			this.InnerVisibleState = 1;
			this.ChildViewData.AddCallback(childType, new Action(this.OnBattleUiChildVisibleChanged));
		}

		// Token: 0x0603DA46 RID: 252486 RVA: 0x00FB4790 File Offset: 0x00FB2990
		public virtual void ShowBattleVisibleChildView(bool checkVisible = false)
		{
			this.IsEnable = true;
			this.SetVisibleInner(0, true);
			bool visible = this.GetVisible();
			if (visible || !checkVisible)
			{
				this.SetActive(visible);
			}
			if (visible)
			{
				this.OnShowBattleChildView();
			}
		}

		// Token: 0x0603DA47 RID: 252487 RVA: 0x00FB47C9 File Offset: 0x00FB29C9
		public virtual void HideBattleVisibleChildView()
		{
			this.IsEnable = false;
			bool visible = this.GetVisible();
			this.SetVisibleInner(0, false);
			this.SetActive(this.GetVisible());
			if (visible)
			{
				this.OnHideBattleChildView();
			}
		}

		// Token: 0x0603DA48 RID: 252488 RVA: 0x00FB47F4 File Offset: 0x00FB29F4
		public override void Reset()
		{
			this.SetVisibleInner(0, false);
			if (this.ChildViewData != null)
			{
				this.ChildViewData.RemoveCallback(this.ChildType, new Action(this.OnBattleUiChildVisibleChanged));
				this.ChildViewData = null;
			}
			base.Reset();
		}

		// Token: 0x0603DA49 RID: 252489 RVA: 0x00FB4830 File Offset: 0x00FB2A30
		public void ClearChildViewData()
		{
			if (this.ChildViewData != null)
			{
				this.ChildViewData.RemoveCallback(this.ChildType, new Action(this.OnBattleUiChildVisibleChanged));
				this.ChildViewData = null;
			}
		}

		// Token: 0x0603DA4A RID: 252490 RVA: 0x00FB4860 File Offset: 0x00FB2A60
		public override void SetActive(bool visibility)
		{
			if (this.GetVisible() != visibility)
			{
				Singleton<Log>.Instance.Error(ELogModule.Battle, ELogAuthor.CFT, "战斗子界面不要直接调用SetActive, 请调用SetVisible", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			base.SetActive(visibility);
		}

		// Token: 0x0603DA4B RID: 252491 RVA: 0x00FB489A File Offset: 0x00FB2A9A
		private void OnBattleUiChildVisibleChanged()
		{
			this.NotifyVisibleChanged();
		}

		// Token: 0x0603DA4C RID: 252492 RVA: 0x00FB48A4 File Offset: 0x00FB2AA4
		private void NotifyVisibleChanged()
		{
			if (this.ChildViewData == null)
			{
				return;
			}
			bool visible = this.GetVisible();
			this.BaseVisible = this.ChildViewData.GetChildVisible(this.ChildType);
			this.CheckVisibleChange(visible);
		}

		// Token: 0x0603DA4D RID: 252493 RVA: 0x00FB48E0 File Offset: 0x00FB2AE0
		public void SetVisible(int visibleReason, bool bVisible)
		{
			bool visible = this.GetVisible();
			this.SetVisibleInner(visibleReason, bVisible);
			this.CheckVisibleChange(visible);
		}

		// Token: 0x0603DA4E RID: 252494 RVA: 0x00FB4904 File Offset: 0x00FB2B04
		private void CheckVisibleChange(bool oldVisible)
		{
			if (!this.IsEnable)
			{
				return;
			}
			bool visible = this.GetVisible();
			if (oldVisible == visible)
			{
				return;
			}
			this.SetActive(visible);
			if (visible)
			{
				this.OnShowBattleChildView();
				return;
			}
			this.OnHideBattleChildView();
		}

		// Token: 0x0603DA4F RID: 252495 RVA: 0x00FB493D File Offset: 0x00FB2B3D
		private void SetVisibleInner(int visibleReason, bool bVisible)
		{
			this.InnerVisibleState = VisibleStateUtil.SetVisible(this.InnerVisibleState, bVisible, visibleReason);
		}

		// Token: 0x0603DA50 RID: 252496 RVA: 0x00FB4952 File Offset: 0x00FB2B52
		public bool GetVisible()
		{
			return this.BaseVisible && this.InnerVisibleState == 0;
		}

		// Token: 0x0603DA51 RID: 252497 RVA: 0x00FB4967 File Offset: 0x00FB2B67
		protected override void OnShowBattleChildView()
		{
		}

		// Token: 0x0603DA52 RID: 252498 RVA: 0x00FB4969 File Offset: 0x00FB2B69
		protected override void OnHideBattleChildView()
		{
		}

		// Token: 0x04022996 RID: 141718
		[Nullable(2)]
		protected BattleUiChildViewData ChildViewData;

		// Token: 0x04022997 RID: 141719
		protected EBattleUiChild ChildType;

		// Token: 0x04022998 RID: 141720
		protected bool BaseVisible;

		// Token: 0x04022999 RID: 141721
		protected bool IsEnable;

		// Token: 0x0402299A RID: 141722
		protected int InnerVisibleState;
	}
}
