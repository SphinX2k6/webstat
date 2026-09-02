using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x020067DA RID: 26586
	[NullableContext(1)]
	[Nullable(0)]
	public class DockyardWareHouseViewModel : DockyardWareHouseViewModelBase
	{
		// Token: 0x1700A118 RID: 41240
		// (get) Token: 0x0604250C RID: 271628 RVA: 0x01102842 File Offset: 0x01100A42
		public virtual DockyardWareHouseBackpackPanelModel BackpackPanelModel { [PreserveBaseOverrides] get; } = new DockyardWareHouseBackpackPanelModel();

		// Token: 0x1700A119 RID: 41241
		// (get) Token: 0x0604250D RID: 271629 RVA: 0x0110284A File Offset: 0x01100A4A
		public virtual DockyardWareHouseListPanelModel ListPanelModel { [PreserveBaseOverrides] get; } = new DockyardWareHouseListPanelModel();

		// Token: 0x1700A11A RID: 41242
		// (get) Token: 0x0604250E RID: 271630 RVA: 0x01102852 File Offset: 0x01100A52
		protected override CabinType RequestCabinType { get; } = 1;

		// Token: 0x06042510 RID: 271632 RVA: 0x0110287F File Offset: 0x01100A7F
		protected override void OnInit()
		{
			this.ViewTitle = "Fishing_CageText4";
		}

		// Token: 0x06042511 RID: 271633 RVA: 0x0110288C File Offset: 0x01100A8C
		protected override void OnCloseClick()
		{
			if (!this.InGameplayFlow)
			{
				ControllerBase<FishingController>.Instance.ShowConfirmBoxAndRequestFishingExit(delegate(bool success)
				{
					if (success)
					{
						DockyardWareHouseView view2 = this.View;
						if (view2 == null)
						{
							return;
						}
						view2.CloseMe(null);
					}
				});
				return;
			}
			DockyardWareHouseView view = this.View;
			if (view == null)
			{
				return;
			}
			view.CloseMe(null);
		}

		// Token: 0x06042512 RID: 271634 RVA: 0x011028C0 File Offset: 0x01100AC0
		public override UniTask BeforeStartAsync()
		{
			DockyardWareHouseViewModel.<BeforeStartAsync>d__13 <BeforeStartAsync>d__;
			<BeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<BeforeStartAsync>d__.<>4__this = this;
			<BeforeStartAsync>d__.<>1__state = -1;
			<BeforeStartAsync>d__.<>t__builder.Start<DockyardWareHouseViewModel.<BeforeStartAsync>d__13>(ref <BeforeStartAsync>d__);
			return <BeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06042513 RID: 271635 RVA: 0x01102903 File Offset: 0x01100B03
		[NullableContext(2)]
		public override DockyardItemBlockOriginalData GetItemBlockData(int id)
		{
			return ModelBase<DockyardModel>.Instance.GetItemBlockData(id);
		}

		// Token: 0x04024EA2 RID: 151202
		public bool InGameplayFlow;
	}
}
