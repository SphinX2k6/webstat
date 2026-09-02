using System;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.Define;
using CSharpScript.Launcher.Update.ResourceDiffUpdate;
using UnrealEngine;

namespace CSharpScript.Launcher.Ui.HotFix
{
	// Token: 0x02004504 RID: 17668
	public class HotFixDownLoadTabItem : LaunchComponentsAction, IHotFixLayoutItem
	{
		// Token: 0x0602E8F5 RID: 190709 RVA: 0x00B08102 File Offset: 0x00B06302
		[NullableContext(1)]
		public void SetRootActor(AActor actor)
		{
			base.SetRootActorLaunchComponentsAction(actor);
		}

		// Token: 0x0602E8F6 RID: 190710 RVA: 0x00B0810B File Offset: 0x00B0630B
		protected override void OnStart()
		{
			this.ToggleRef = base.GetExtendToggle(0);
			this.ToggleRef.OnStateChange.Add(delegate(EToggleState state)
			{
				if (state == EToggleState.ETT_Checked && this.OnClickExtendToggleCallBack != null)
				{
					this.OnClickExtendToggleCallBack(this.TabIndex, this.ToggleRef);
				}
			});
		}

		// Token: 0x0602E8F7 RID: 190711 RVA: 0x00B08138 File Offset: 0x00B06338
		[NullableContext(1)]
		public void Refresh(IHotFixLayoutData data)
		{
			IHotFixDownLoadTabItemData hotFixDownLoadTabItemData = (IHotFixDownLoadTabItemData)data;
			this.TabIndex = hotFixDownLoadTabItemData.TabId;
			LauncherDownLoadConfig downLoadTabConfig = Singleton<LauncherConfigLib>.Instance.GetDownLoadTabConfig(this.TabIndex.ToString());
			HotFixManager.SetLocalText(base.GetText(1), (downLoadTabConfig != null) ? downLoadTabConfig.Title : null, Array.Empty<string>());
			long resSize = Singleton<ResourceDiffUpdaterManager>.Instance.GetResSize((EResUpdateType)this.TabIndex);
			base.GetText(2).SetText(HotFixManager.ByteConverter(resSize), true);
			LauncherLog instance = Singleton<LauncherLog>.Instance;
			string message = "HotFixDownLoadTabItem";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("byte", resSize);
			instance.Info(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}

		// Token: 0x0602E8F8 RID: 190712 RVA: 0x00B081D7 File Offset: 0x00B063D7
		public void Select()
		{
			base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_Checked, true, false, false);
		}

		// Token: 0x0401A732 RID: 108338
		private int TabIndex;

		// Token: 0x0401A733 RID: 108339
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Action<int, UUIExtendToggle> OnClickExtendToggleCallBack;

		// Token: 0x0401A734 RID: 108340
		[Nullable(2)]
		private UUIExtendToggle ToggleRef;

		// Token: 0x0200A719 RID: 42777
		private static class EHotFixDownLoadTabData
		{
			// Token: 0x04033DBD RID: 212413
			public const int Toggle = 0;

			// Token: 0x04033DBE RID: 212414
			public const int NameText = 1;

			// Token: 0x04033DBF RID: 212415
			public const int SpaceText = 2;
		}
	}
}
