using System;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.Ui.HotFix.NetWorkDetection;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Launcher.Ui.HotFix
{
	// Token: 0x02004518 RID: 17688
	public class HotFixToolWindowView : LaunchComponentsAction
	{
		// Token: 0x0602E985 RID: 190853 RVA: 0x00B0A538 File Offset: 0x00B08738
		[NullableContext(1)]
		public UniTask LoadAsync(UObject worldContext)
		{
			HotFixToolWindowView.<LoadAsync>d__1 <LoadAsync>d__;
			<LoadAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<LoadAsync>d__.<>4__this = this;
			<LoadAsync>d__.worldContext = worldContext;
			<LoadAsync>d__.<>1__state = -1;
			<LoadAsync>d__.<>t__builder.Start<HotFixToolWindowView.<LoadAsync>d__1>(ref <LoadAsync>d__);
			return <LoadAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0602E986 RID: 190854 RVA: 0x00B0A583 File Offset: 0x00B08783
		private void SetRepairItemActive(bool value)
		{
			base.GetElement<HotFixPopupRepairView>(101).SetActive(value);
		}

		// Token: 0x0602E987 RID: 190855 RVA: 0x00B0A593 File Offset: 0x00B08793
		private void SetNetworkDetectItemActive(bool value)
		{
			base.GetElement<HotFixNetworkDetectionView>(102).SetActive(value);
		}

		// Token: 0x0602E988 RID: 190856 RVA: 0x00B0A5A4 File Offset: 0x00B087A4
		protected override void OnStart()
		{
			base.AttachElement<HotFixButtonItem>(3).BindClickCallback(new Action(this.OnCleanBtnClick));
			HotFixButtonItem hotFixButtonItem = base.AttachElement<HotFixButtonItem>(4);
			hotFixButtonItem.BindClickCallback(new Action(this.OnLogBtnClick));
			hotFixButtonItem.SetActive(false);
			base.AttachElement<HotFixButtonItem>(5).BindClickCallback(new Action(this.OnNetBtnClick));
			base.GetButton(1).OnClickCallBack.Bind(new Action(this.OnBackBtnClick));
		}

		// Token: 0x0602E989 RID: 190857 RVA: 0x00B0A61D File Offset: 0x00B0881D
		private void OnCleanBtnClick()
		{
			this.SetRepairItemActive(true);
		}

		// Token: 0x0602E98A RID: 190858 RVA: 0x00B0A626 File Offset: 0x00B08826
		private void OnLogBtnClick()
		{
		}

		// Token: 0x0602E98B RID: 190859 RVA: 0x00B0A628 File Offset: 0x00B08828
		private void OnNetBtnClick()
		{
			this.SetNetworkDetectItemActive(true);
		}

		// Token: 0x0602E98C RID: 190860 RVA: 0x00B0A631 File Offset: 0x00B08831
		private void OnBackBtnClick()
		{
			base.SetActive(false);
		}

		// Token: 0x0200A730 RID: 42800
		private static class EComponents
		{
			// Token: 0x04033E24 RID: 212516
			public const int BtnMask = 0;

			// Token: 0x04033E25 RID: 212517
			public const int BtnBack = 1;

			// Token: 0x04033E26 RID: 212518
			public const int TxtTile = 2;

			// Token: 0x04033E27 RID: 212519
			public const int BtnClean = 3;

			// Token: 0x04033E28 RID: 212520
			public const int BtnLog = 4;

			// Token: 0x04033E29 RID: 212521
			public const int BtnNet = 5;

			// Token: 0x04033E2A RID: 212522
			public const int RepairPop = 101;

			// Token: 0x04033E2B RID: 212523
			public const int NetworkDetectPop = 102;
		}
	}
}
