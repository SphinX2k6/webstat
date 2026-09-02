using System;

namespace CSharpScript.Launcher.Ui.HotFix
{
	// Token: 0x02004511 RID: 17681
	public class HotFixPopupRepairView : HotFixPopupUiView
	{
		// Token: 0x0602E95C RID: 190812 RVA: 0x00B09DE0 File Offset: 0x00B07FE0
		protected override void OnStart()
		{
			base.OnStart();
			base.SetConfirmationTitle("PatchClearTitle");
			base.SetConfirmationContent("PatchClear", Array.Empty<string>());
			base.SetConfirmationLeftButtonText(EHotFixTextId.HotFixCancel.ToString());
			base.SetConfirmationRightButtonText("ConfirmText");
			base.SetConfirmationCloseButtonActive(true);
			base.SetConfirmationLeftButtonActive(true);
			base.SetConfirmationRightButtonActive(true);
			base.SetConfirmationMiddleButtonActive(false);
			base.SetConfirmationCloseButtonCallBack(delegate
			{
				base.SetActive(false);
			});
			base.SetConfirmationLeftButtonCallBack(delegate
			{
				base.SetActive(false);
			});
			base.SetConfirmationRightButtonCallBack(delegate
			{
				Singleton<HotPatch>.Instance.ClearPatch();
				base.SetActive(false);
			});
		}
	}
}
