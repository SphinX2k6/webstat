using System;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using UnrealEngine;

namespace CSharpScript.Game.Module.MapRogue
{
	// Token: 0x02005999 RID: 22937
	[NullableContext(1)]
	[Nullable(0)]
	public abstract class GridPopupViewModelBase
	{
		// Token: 0x0603A131 RID: 237873 RVA: 0x00EB2C03 File Offset: 0x00EB0E03
		public GridPopupViewModelBase(MapGridData gridData, MapRogueGameInfo gameInfo)
		{
			this.GridData = gridData;
			this.GameInfo = gameInfo;
		}

		// Token: 0x0603A132 RID: 237874 RVA: 0x00EB2C19 File Offset: 0x00EB0E19
		public void BindView(GridPopupView view)
		{
			this.View = view;
		}

		// Token: 0x0603A133 RID: 237875 RVA: 0x00EB2C24 File Offset: 0x00EB0E24
		public bool EventAvailable()
		{
			bool flag = this.GameInfo.MoveState == EMovePathType.CanMove;
			bool flag2 = this.GridData.IsUnlock();
			return flag && flag2;
		}

		// Token: 0x0603A134 RID: 237876 RVA: 0x00EB2C4D File Offset: 0x00EB0E4D
		public virtual UniTask Init()
		{
			return UniTask.CompletedTask;
		}

		// Token: 0x0603A135 RID: 237877 RVA: 0x00EB2C54 File Offset: 0x00EB0E54
		[NullableContext(2)]
		public virtual string GetSubTxtInfo()
		{
			return null;
		}

		// Token: 0x1700947E RID: 38014
		// (get) Token: 0x0603A136 RID: 237878
		public abstract bool HasBtnDetail { get; }

		// Token: 0x0603A137 RID: 237879 RVA: 0x00EB2C57 File Offset: 0x00EB0E57
		public virtual void GetBtnDetailFunc()
		{
		}

		// Token: 0x0603A138 RID: 237880 RVA: 0x00EB2C59 File Offset: 0x00EB0E59
		public void OnClickedClose()
		{
			if (this.IsEnd)
			{
				return;
			}
			this.IsEnd = true;
			this.GameInfo.GameStage = EMapRogueGameStage.Norm;
			GridPopupView view = this.View;
			if (view == null)
			{
				return;
			}
			view.CloseMeAsync();
		}

		// Token: 0x0603A139 RID: 237881 RVA: 0x00EB2C88 File Offset: 0x00EB0E88
		public virtual void RefreshTop()
		{
		}

		// Token: 0x0603A13A RID: 237882 RVA: 0x00EB2C8A File Offset: 0x00EB0E8A
		public virtual void RefreshBottom()
		{
		}

		// Token: 0x0603A13B RID: 237883 RVA: 0x00EB2C8C File Offset: 0x00EB0E8C
		public virtual void RefreshFunctional()
		{
		}

		// Token: 0x0603A13C RID: 237884 RVA: 0x00EB2C8E File Offset: 0x00EB0E8E
		public void MoveButtonFunction(int _)
		{
			if (this.IsEnd)
			{
				return;
			}
			this.IsEnd = true;
			this.GameInfo.RequestMove(new Action<bool>(this.<MoveButtonFunction>g__confirmCloseSelf|16_0));
		}

		// Token: 0x0603A13D RID: 237885 RVA: 0x00EB2CB7 File Offset: 0x00EB0EB7
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public virtual UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
		{
			return null;
		}

		// Token: 0x0603A13E RID: 237886 RVA: 0x00EB2CBA File Offset: 0x00EB0EBA
		[CompilerGenerated]
		private void <MoveButtonFunction>g__confirmCloseSelf|16_0(bool confirm)
		{
			this.IsEnd = confirm;
			if (confirm)
			{
				this.View.CloseMeAsync();
			}
		}

		// Token: 0x04020F13 RID: 134931
		protected GridPopupView View;

		// Token: 0x04020F14 RID: 134932
		public bool IsEnd;

		// Token: 0x04020F15 RID: 134933
		public MapGridData GridData;

		// Token: 0x04020F16 RID: 134934
		public MapRogueGameInfo GameInfo;
	}
}
