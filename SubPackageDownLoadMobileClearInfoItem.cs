using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Launcher.Update.ResourceDiffUpdate;
using CSharpScript.Launcher.Util;
using UnrealEngine;

// Token: 0x02002AB5 RID: 10933
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class SubPackageDownLoadMobileClearInfoItem : GridProxyAbstract<ISubPackageDownLoadMobileClearInfoItemData>
{
	// Token: 0x06015E02 RID: 89602 RVA: 0x00612BA4 File Offset: 0x00610DA4
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickToggle))
		};
	}

	// Token: 0x06015E03 RID: 89603 RVA: 0x00612C38 File Offset: 0x00610E38
	public override void Refresh(ISubPackageDownLoadMobileClearInfoItemData data, bool isSelected, int gridIndex)
	{
		this.SceneId = null;
		this.IsVideo = false;
		this.VoiceCode = null;
		if (data.Type == ESubPackageDownLoadPackageType.OptionalPlot)
		{
			this.RefreshItemByPlot(data.HaveVideoCanClear.GetValueOrDefault());
		}
		if (data.Type == ESubPackageDownLoadPackageType.OptionalScene)
		{
			this.RefreshItemByScene(data.SceneId.GetValueOrDefault());
		}
		if (data.Type == ESubPackageDownLoadPackageType.Voice)
		{
			this.RefreshItemByVoice(data.VoiceLanguageCode ?? "");
		}
	}

	// Token: 0x06015E04 RID: 89604 RVA: 0x00612CB8 File Offset: 0x00610EB8
	public void RefreshItemByScene(int sceneId)
	{
		this.SceneId = new int?(sceneId);
		int? sceneId2 = this.SceneId;
		int num = 0;
		if (sceneId2.GetValueOrDefault() <= num & sceneId2 != null)
		{
			base.GetItem(2).SetUIActive(true);
			base.GetExtendToggle(0).RootUIComp.Get().SetUIActive(false);
			return;
		}
		base.GetItem(2).SetUIActive(false);
		base.GetExtendToggle(0).RootUIComp.Get().SetUIActive(true);
		DownLoadSubPackage value = ConfigBase<SubPackageConfig>.Instance.GetDownLoadSubPackageById(this.SceneId.GetValueOrDefault()).Value;
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), value.Title, Array.Empty<object>());
		long subPackageHaveDownLoadSpace = ModelBase<SubPackageDownLoadModel>.Instance.GetSubPackageHaveDownLoadSpace(this.SceneId.GetValueOrDefault());
		base.GetText(3).SetText(ModelBase<SubPackageDownLoadModel>.Instance.ByteConverter(subPackageHaveDownLoadSpace), true);
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle == null)
		{
			return;
		}
		extendToggle.SetToggleState(EToggleState.ETT_Checked, true, false, false);
	}

	// Token: 0x06015E05 RID: 89605 RVA: 0x00612DC4 File Offset: 0x00610FC4
	public void RefreshItemByPlot(bool haveVideo)
	{
		this.IsVideo = true;
		if (!haveVideo)
		{
			base.GetItem(2).SetUIActive(true);
			base.GetExtendToggle(0).RootUIComp.Get().SetUIActive(false);
			return;
		}
		base.GetItem(2).SetUIActive(false);
		base.GetExtendToggle(0).RootUIComp.Get().SetUIActive(true);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "SubPackageClearTips_Plot_Item_Info", Array.Empty<object>());
		long canCleanVideoSpace = ModelBase<SubPackageDownLoadModel>.Instance.GetCanCleanVideoSpace();
		base.GetText(3).SetText(ModelBase<SubPackageDownLoadModel>.Instance.ByteConverter(canCleanVideoSpace), true);
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle == null)
		{
			return;
		}
		extendToggle.SetToggleState(EToggleState.ETT_Checked, true, false, false);
	}

	// Token: 0x06015E06 RID: 89606 RVA: 0x00612E80 File Offset: 0x00611080
	public void RefreshItemByVoice(string audioCode)
	{
		this.VoiceCode = audioCode;
		if (string.IsNullOrEmpty(audioCode))
		{
			base.GetItem(2).SetUIActive(true);
			base.GetExtendToggle(0).RootUIComp.Get().SetUIActive(false);
			return;
		}
		base.GetItem(2).SetUIActive(false);
		base.GetExtendToggle(0).RootUIComp.Get().SetUIActive(true);
		IEnumerable<LaunchLangDefine> allLanguageDefines = Singleton<LauncherLanguageLib>.Instance.GetAllLanguageDefines();
		LaunchLangDefine launchLangDefine = null;
		foreach (LaunchLangDefine launchLangDefine2 in allLanguageDefines)
		{
			if (launchLangDefine2.AudioCode == audioCode)
			{
				launchLangDefine = launchLangDefine2;
				break;
			}
		}
		RoleVoiceLanguage? roleVoiceLanguage = (launchLangDefine != null) ? ConfigRoleVoiceLanguageByLanguageId.GetConfig(launchLangDefine.LanguageType, true) : null;
		if (roleVoiceLanguage != null)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), roleVoiceLanguage.Value.Text, Array.Empty<object>());
		}
		else
		{
			base.GetText(1).SetText(audioCode, true);
		}
		long localSizeByAudioCode = Singleton<ResourceDiffUpdaterManager>.Instance.VoiceModule.GetLocalSizeByAudioCode(audioCode);
		base.GetText(3).SetText(ModelBase<SubPackageDownLoadModel>.Instance.ByteConverter(localSizeByAudioCode), true);
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle == null)
		{
			return;
		}
		extendToggle.SetToggleState(EToggleState.ETT_Checked, true, false, false);
	}

	// Token: 0x06015E07 RID: 89607 RVA: 0x00612FE0 File Offset: 0x006111E0
	private void OnClickToggle(EToggleState state)
	{
		Action<int?, bool, EToggleState, string> onClickToggleCallBack = this.OnClickToggleCallBack;
		if (onClickToggleCallBack == null)
		{
			return;
		}
		onClickToggleCallBack(this.SceneId, this.IsVideo, state, this.VoiceCode);
	}

	// Token: 0x0400A7F0 RID: 42992
	[Nullable(2)]
	public Action<int?, bool, EToggleState, string> OnClickToggleCallBack;

	// Token: 0x0400A7F1 RID: 42993
	private int? SceneId;

	// Token: 0x0400A7F2 RID: 42994
	private bool IsVideo;

	// Token: 0x0400A7F3 RID: 42995
	[Nullable(2)]
	private string VoiceCode;

	// Token: 0x02008E23 RID: 36387
	[NullableContext(0)]
	private class ESubPackageDownLoadMobileClearInfoItem
	{
		// Token: 0x0402FD0E RID: 195854
		public const int Toggle = 0;

		// Token: 0x0402FD0F RID: 195855
		public const int Text = 1;

		// Token: 0x0402FD10 RID: 195856
		public const int EmptyItem = 2;

		// Token: 0x0402FD11 RID: 195857
		public const int SpaceText = 3;
	}
}
