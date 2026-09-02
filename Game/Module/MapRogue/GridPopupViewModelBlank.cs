using System;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.MapRogue
{
	// Token: 0x0200599B RID: 22939
	[NullableContext(1)]
	[Nullable(0)]
	public class GridPopupViewModelBlank : GridPopupViewModelBase
	{
		// Token: 0x17009480 RID: 38016
		// (get) Token: 0x0603A147 RID: 237895 RVA: 0x00EB2EFA File Offset: 0x00EB10FA
		public override bool HasBtnDetail
		{
			get
			{
				return false;
			}
		}

		// Token: 0x0603A148 RID: 237896 RVA: 0x00EB2EFD File Offset: 0x00EB10FD
		public GridPopupViewModelBlank(MapGridData gridData, MapRogueGameInfo gameInfo) : base(gridData, gameInfo)
		{
		}

		// Token: 0x0603A149 RID: 237897 RVA: 0x00EB2F08 File Offset: 0x00EB1108
		public override UniTask Init()
		{
			GridPopupViewModelBlank.<Init>d__4 <Init>d__;
			<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Init>d__.<>4__this = this;
			<Init>d__.<>1__state = -1;
			<Init>d__.<>t__builder.Start<GridPopupViewModelBlank.<Init>d__4>(ref <Init>d__);
			return <Init>d__.<>t__builder.Task;
		}

		// Token: 0x0603A14A RID: 237898 RVA: 0x00EB2F4C File Offset: 0x00EB114C
		public override void RefreshFunctional()
		{
			bool flag = this.GameInfo.MoveState == EMovePathType.CanMove;
			this.Button.SetUiActive(flag);
			if (!flag)
			{
				return;
			}
			this.Button.SetButtonTextByTextId("RogueRes_Block_Move", Array.Empty<string>());
			this.Button.SetButtonFunction(new Action<int>(this.ButtonFunction));
		}

		// Token: 0x0603A14B RID: 237899 RVA: 0x00EB2FA4 File Offset: 0x00EB11A4
		private void ButtonFunction(int _)
		{
			if (this.IsEnd)
			{
				return;
			}
			this.IsEnd = true;
			this.GameInfo.RequestMove(null);
			this.View.CloseMeAsync();
		}

		// Token: 0x04020F1C RID: 134940
		protected PopupComponentFunctionButton Button;
	}
}
