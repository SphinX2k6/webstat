using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001EB7 RID: 7863
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class HelpController : UiControllerBase<HelpController>
{
	// Token: 0x0600E889 RID: 59529 RVA: 0x003EE144 File Offset: 0x003EC344
	protected override bool OnInit()
	{
		FLGUIDelegateForHelpClick flguidelegateForHelpClick = global::DelegateUtils.ToManualReleaseDelegate<FLGUIDelegateForHelpClick>(new Action<int>(this.OnHelpClick));
		UUIExtendButtonComponent.SetDelegateForHelpClick(flguidelegateForHelpClick);
		return true;
	}

	// Token: 0x0600E88A RID: 59530 RVA: 0x003EE16B File Offset: 0x003EC36B
	private void OnHelpClick(int helpGroupId)
	{
		this.OpenHelpById(helpGroupId);
	}

	// Token: 0x0600E88B RID: 59531 RVA: 0x003EE174 File Offset: 0x003EC374
	public void OpenHelpById(int helpGroupId)
	{
		IReadOnlyList<HelpText> helpContentInfoByGroupId = ConfigBase<HelpConfig>.Instance.GetHelpContentInfoByGroupId(helpGroupId);
		if (helpContentInfoByGroupId == null || helpContentInfoByGroupId.Count == 0)
		{
			return;
		}
		this.HelpGroupId = new int?(helpGroupId);
		int type = helpContentInfoByGroupId[0].Type;
		if (type == 0)
		{
			UiManager instance = Singleton<UiManager>.Instance;
			EUiViewName helpView = EUiViewName.HelpView;
			object param = this.HelpGroupId;
			TOpenViewCallBack finishCallback;
			if ((finishCallback = HelpController.<>O.<0>__OpenViewCallback) == null)
			{
				finishCallback = (HelpController.<>O.<0>__OpenViewCallback = new TOpenViewCallBack(HelpController.OpenViewCallback));
			}
			instance.OpenView(helpView, param, finishCallback);
			return;
		}
		if (type != 1)
		{
			return;
		}
		UiManager instance2 = Singleton<UiManager>.Instance;
		EUiViewName helpGuideView = EUiViewName.HelpGuideView;
		object param2 = this.HelpGroupId;
		TOpenViewCallBack finishCallback2;
		if ((finishCallback2 = HelpController.<>O.<0>__OpenViewCallback) == null)
		{
			finishCallback2 = (HelpController.<>O.<0>__OpenViewCallback = new TOpenViewCallBack(HelpController.OpenViewCallback));
		}
		instance2.OpenView(helpGuideView, param2, finishCallback2);
	}

	// Token: 0x0600E88C RID: 59532 RVA: 0x003EE228 File Offset: 0x003EC428
	private static void OpenViewCallback(bool success, int viewId)
	{
		if (success)
		{
			ControllerBase<HelpController>.Instance.HelpGroupId = null;
		}
	}

	// Token: 0x0600E88D RID: 59533 RVA: 0x003EE23D File Offset: 0x003EC43D
	protected override bool OnClear()
	{
		global::DelegateUtils.ReleaseManualReleaseDelegate(new Action<int>(this.OnHelpClick));
		return true;
	}

	// Token: 0x04007005 RID: 28677
	public int? HelpGroupId;

	// Token: 0x020081FC RID: 33276
	[CompilerGenerated]
	private static class <>O
	{
		// Token: 0x0402C186 RID: 180614
		public static TOpenViewCallBack <0>__OpenViewCallback;
	}
}
