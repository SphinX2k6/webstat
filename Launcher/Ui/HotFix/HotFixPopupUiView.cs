using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Launcher.Ui.HotFix
{
	// Token: 0x02004512 RID: 17682
	[NullableContext(1)]
	[Nullable(0)]
	public class HotFixPopupUiView : LaunchComponentsAction
	{
		// Token: 0x0602E961 RID: 190817 RVA: 0x00B09EAD File Offset: 0x00B080AD
		protected override void OnStart()
		{
			base.AttachElement<HotFixBtnUiItem>(5);
			base.AttachElement<HotFixBtnUiItem>(6);
			base.AttachElement<HotFixBtnUiItem>(7);
		}

		// Token: 0x0602E962 RID: 190818 RVA: 0x00B09EC7 File Offset: 0x00B080C7
		public void SetConfirmationTitle(string tableId)
		{
			HotFixManager.SetLocalText(base.GetText(4), tableId, Array.Empty<string>());
		}

		// Token: 0x0602E963 RID: 190819 RVA: 0x00B09EDB File Offset: 0x00B080DB
		public void SetConfirmationContent(string tableId, params string[] args)
		{
			HotFixManager.SetLocalText(base.GetText(8), tableId, args);
		}

		// Token: 0x0602E964 RID: 190820 RVA: 0x00B09EEB File Offset: 0x00B080EB
		public void SetConfirmationLeftButtonCallBack(Action callback)
		{
			base.GetElement<HotFixBtnUiItem>(5).BindClickCallback(callback);
		}

		// Token: 0x0602E965 RID: 190821 RVA: 0x00B09EFA File Offset: 0x00B080FA
		public void SetConfirmationRightButtonCallBack(Action callback)
		{
			base.GetElement<HotFixBtnUiItem>(6).BindClickCallback(callback);
		}

		// Token: 0x0602E966 RID: 190822 RVA: 0x00B09F09 File Offset: 0x00B08109
		public void SetConfirmationMiddleButtonCallBack(Action callback)
		{
			base.GetElement<HotFixBtnUiItem>(7).BindClickCallback(callback);
		}

		// Token: 0x0602E967 RID: 190823 RVA: 0x00B09F18 File Offset: 0x00B08118
		public void SetConfirmationCloseButtonCallBack(Action callback)
		{
			base.GetButton(2).OnClickCallBack.Unbind();
			base.GetButton(2).OnClickCallBack.Bind(callback);
		}

		// Token: 0x0602E968 RID: 190824 RVA: 0x00B09F3D File Offset: 0x00B0813D
		[NullableContext(2)]
		public void SetConfirmationLeftButtonText(string tableId)
		{
			base.GetElement<HotFixBtnUiItem>(5).SetText(tableId, Array.Empty<string>());
		}

		// Token: 0x0602E969 RID: 190825 RVA: 0x00B09F51 File Offset: 0x00B08151
		[NullableContext(2)]
		public void SetConfirmationRightButtonText(string tableId)
		{
			base.GetElement<HotFixBtnUiItem>(6).SetText(tableId, Array.Empty<string>());
		}

		// Token: 0x0602E96A RID: 190826 RVA: 0x00B09F65 File Offset: 0x00B08165
		[NullableContext(2)]
		public void SetConfirmationMiddleButtonText(string tableId)
		{
			base.GetElement<HotFixBtnUiItem>(7).SetText(tableId, Array.Empty<string>());
		}

		// Token: 0x0602E96B RID: 190827 RVA: 0x00B09F79 File Offset: 0x00B08179
		public void SetConfirmationLeftButtonActive(bool value)
		{
			base.GetElement<HotFixBtnUiItem>(5).SetActive(value);
		}

		// Token: 0x0602E96C RID: 190828 RVA: 0x00B09F88 File Offset: 0x00B08188
		public void SetConfirmationRightButtonActive(bool value)
		{
			base.GetElement<HotFixBtnUiItem>(6).SetActive(value);
		}

		// Token: 0x0602E96D RID: 190829 RVA: 0x00B09F97 File Offset: 0x00B08197
		public void SetConfirmationMiddleButtonActive(bool value)
		{
			base.GetElement<HotFixBtnUiItem>(7).SetActive(value);
		}

		// Token: 0x0602E96E RID: 190830 RVA: 0x00B09FA8 File Offset: 0x00B081A8
		public void SetConfirmationCloseButtonActive(bool value)
		{
			base.GetButton(2).RootUIComp.Get().SetUIActive(value);
		}

		// Token: 0x0200A72D RID: 42797
		[NullableContext(0)]
		private static class EComponents
		{
			// Token: 0x04033E17 RID: 212503
			public const int BtnMask = 0;

			// Token: 0x04033E18 RID: 212504
			public const int BtnRoot = 1;

			// Token: 0x04033E19 RID: 212505
			public const int BtnBack = 2;

			// Token: 0x04033E1A RID: 212506
			public const int CostItem = 3;

			// Token: 0x04033E1B RID: 212507
			public const int TxtTitle = 4;

			// Token: 0x04033E1C RID: 212508
			public const int LeftBtnItem = 5;

			// Token: 0x04033E1D RID: 212509
			public const int RightBtnItem = 6;

			// Token: 0x04033E1E RID: 212510
			public const int MiddleBtnItem = 7;

			// Token: 0x04033E1F RID: 212511
			public const int TxtContent = 8;
		}
	}
}
