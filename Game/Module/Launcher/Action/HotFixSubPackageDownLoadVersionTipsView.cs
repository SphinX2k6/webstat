using System;
using CSharpScript.Launcher.Ui;
using CSharpScript.Launcher.Ui.HotFix;
using UnrealEngine;

namespace CSharpScript.Game.Module.Launcher.Action
{
	// Token: 0x02004A91 RID: 19089
	public class HotFixSubPackageDownLoadVersionTipsView : LaunchComponentsAction
	{
		// Token: 0x06031CE2 RID: 204002 RVA: 0x00C79671 File Offset: 0x00C77871
		protected override void OnStart()
		{
			base.GetButton(0).OnClickCallBack.Bind(delegate()
			{
				Singleton<LauncherLog>.Instance.Info("HotFixSubPackageDownLoadVersionTipsView MaskBtn", default(ReadOnlySpan<ValueTuple<string, object>>));
				base.SetActive(false);
			});
		}

		// Token: 0x06031CE3 RID: 204003 RVA: 0x00C79690 File Offset: 0x00C77890
		public void RefreshItemByClearType(int clearType, FVector vector)
		{
			HotFixManager.SetLocalText(base.GetText(2), "HotFixSubPackageClearTipsTitle_TipsTitle_" + HotFixDownSubPackageDownLoadMobileClearPopViewDefine.ClearTypeToTipsNumber[clearType].ToString(), Array.Empty<string>());
			HotFixManager.SetLocalText(base.GetText(3), "HotFixSubPackageClearTipsTitle_TipsDes_" + HotFixDownSubPackageDownLoadMobileClearPopViewDefine.ClearTypeToTipsNumber[clearType].ToString(), Array.Empty<string>());
			this.TipsVector.X = vector.X + 45f;
			this.TipsVector.Z = vector.Z + 20f;
			FHitResult fhitResult = new FHitResult();
			base.GetItem(1).D_K2_SetWorldLocation(this.TipsVector, false, ref fhitResult, false);
		}

		// Token: 0x0401D29E RID: 119454
		private const int BG_ITEM_OFFSETX = 45;

		// Token: 0x0401D29F RID: 119455
		private const int BG_ITEM_OFFSETZ = 20;

		// Token: 0x0401D2A0 RID: 119456
		private FVector TipsVector = new FVector();

		// Token: 0x0200AAF9 RID: 43769
		private static class EComponentDefine
		{
			// Token: 0x0403536B RID: 217963
			public const int MaskBtn = 0;

			// Token: 0x0403536C RID: 217964
			public const int BgItem = 1;

			// Token: 0x0403536D RID: 217965
			public const int TitleText = 2;

			// Token: 0x0403536E RID: 217966
			public const int ContentText = 3;
		}
	}
}
