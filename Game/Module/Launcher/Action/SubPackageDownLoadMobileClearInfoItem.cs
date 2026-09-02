using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.Ui;
using CSharpScript.Launcher.Ui.HotFix;
using CSharpScript.Launcher.Update.ResourceDiffUpdate;
using CSharpScript.Launcher.Update.ResourceDiffUpdate.Config;
using CSharpScript.Launcher.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Launcher.Action
{
	// Token: 0x02004A90 RID: 19088
	public class SubPackageDownLoadMobileClearInfoItem : LaunchComponentsAction, IHotFixLayoutItem
	{
		// Token: 0x06031CD7 RID: 203991 RVA: 0x00C79128 File Offset: 0x00C77328
		[NullableContext(1)]
		public void SetRootActor(AActor actor)
		{
			base.SetRootActorLaunchComponentsAction(actor);
		}

		// Token: 0x06031CD8 RID: 203992 RVA: 0x00C79134 File Offset: 0x00C77334
		protected override void OnStart()
		{
			base.GetExtendToggle(0).OnStateChange.Add(new Action<EToggleState>(this.OnClickToggle));
			HotFixManager.SetLocalText(base.GetText(4), "HotFixSubPackageHaveNoQuestSpaceClear", Array.Empty<string>());
			base.GetItem(5).SetUIActive(false);
		}

		// Token: 0x06031CD9 RID: 203993 RVA: 0x00C79184 File Offset: 0x00C77384
		[NullableContext(1)]
		public void Refresh(IHotFixLayoutData data)
		{
			ISubPackageDownLoadMobileClearInfoItemData subPackageDownLoadMobileClearInfoItemData = (ISubPackageDownLoadMobileClearInfoItemData)data;
			this.SceneId = null;
			this.IsVideo = false;
			this.VoiceCode = null;
			if (subPackageDownLoadMobileClearInfoItemData.Type == ESubPackageDownLoadPackageType.OptionalPlot)
			{
				this.RefreshItemByPlot(subPackageDownLoadMobileClearInfoItemData.HaveVideoCanClear.GetValueOrDefault());
			}
			if (subPackageDownLoadMobileClearInfoItemData.Type == ESubPackageDownLoadPackageType.OptionalScene)
			{
				this.RefreshItemByScene(subPackageDownLoadMobileClearInfoItemData.SceneId.GetValueOrDefault());
			}
			if (subPackageDownLoadMobileClearInfoItemData.Type == ESubPackageDownLoadPackageType.Voice)
			{
				this.RefreshItemByVoice(subPackageDownLoadMobileClearInfoItemData.VoiceLanguageCode ?? "");
			}
		}

		// Token: 0x06031CDA RID: 203994 RVA: 0x00C7920C File Offset: 0x00C7740C
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
			DownLoadSubPackageRow byId = PackSelectionTables.DownLoadSubPackageTableInstance.GetById(sceneId);
			HotFixManager.SetLocalText(base.GetText(1), byId.Title, Array.Empty<string>());
			long subPackageSpace = HotFixManager.GetSubPackageSpace(sceneId);
			base.GetText(3).SetText(HotFixManager.ByteConverter(subPackageSpace), true);
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (extendToggle == null)
			{
				return;
			}
			extendToggle.SetToggleState(EToggleState.ETT_Checked, true, false, false);
		}

		// Token: 0x06031CDB RID: 203995 RVA: 0x00C792F0 File Offset: 0x00C774F0
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
			HotFixManager.SetLocalText(base.GetText(1), "HotFixSubPackageClearTips_Plot_Item_Info", Array.Empty<string>());
			long canCleanVideoSpace = HotFixManager.GetCanCleanVideoSpace();
			base.GetText(3).SetText(HotFixManager.ByteConverter(canCleanVideoSpace), true);
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (extendToggle == null)
			{
				return;
			}
			extendToggle.SetToggleState(EToggleState.ETT_Checked, true, false, false);
		}

		// Token: 0x06031CDC RID: 203996 RVA: 0x00C7939C File Offset: 0x00C7759C
		[NullableContext(1)]
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
			RoleVoiceLanguageTableRow roleVoiceLanguageTableRow = (launchLangDefine != null) ? PackSelectionTables.RoleVoiceLanguageTableInstance.GetById(launchLangDefine.LanguageType) : null;
			if (roleVoiceLanguageTableRow != null)
			{
				HotFixManager.SetLocalText(base.GetText(1), roleVoiceLanguageTableRow.Text, Array.Empty<string>());
			}
			else
			{
				base.GetText(1).SetText(audioCode, true);
			}
			long localSizeByAudioCode = Singleton<ResourceDiffUpdaterManager>.Instance.VoiceModule.GetLocalSizeByAudioCode(audioCode);
			base.GetText(3).SetText(HotFixManager.ByteConverter(localSizeByAudioCode), true);
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (extendToggle == null)
			{
				return;
			}
			extendToggle.SetToggleState(EToggleState.ETT_Checked, true, false, false);
		}

		// Token: 0x06031CDD RID: 203997 RVA: 0x00C794E0 File Offset: 0x00C776E0
		private void OnClickToggle(EToggleState state)
		{
			Action<int?, bool, EToggleState, string> onClickToggleCallBack = this.OnClickToggleCallBack;
			if (onClickToggleCallBack != null)
			{
				onClickToggleCallBack(this.SceneId, this.IsVideo, state, this.VoiceCode);
			}
			this.IsClicked = (state == EToggleState.ETT_Checked);
		}

		// Token: 0x06031CDE RID: 203998 RVA: 0x00C79510 File Offset: 0x00C77710
		public unsafe void SelectItem()
		{
			LauncherLog instance = Singleton<LauncherLog>.Instance;
			string message = "SubPackageDownLoadMobileClearInfoItem SelectItem";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("SceneId", this.SceneId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("IsVideo", this.IsVideo);
			instance.Info(message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			base.GetItem(5).SetUIActive(true);
		}

		// Token: 0x06031CDF RID: 203999 RVA: 0x00C79590 File Offset: 0x00C77790
		public unsafe void UnSelectItem()
		{
			LauncherLog instance = Singleton<LauncherLog>.Instance;
			string message = "SubPackageDownLoadMobileClearInfoItem UnSelectItem";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("SceneId", this.SceneId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("IsVideo", this.IsVideo);
			instance.Info(message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			base.GetItem(5).SetUIActive(false);
		}

		// Token: 0x06031CE0 RID: 204000 RVA: 0x00C79610 File Offset: 0x00C77810
		public void ClickItemOnGamePad()
		{
			EToggleState etoggleState = this.IsClicked ? EToggleState.ETT_UnChecked : EToggleState.ETT_Checked;
			base.GetExtendToggle(0).SetToggleState(etoggleState, false, false, false);
			Action<int?, bool, EToggleState, string> onClickToggleCallBack = this.OnClickToggleCallBack;
			if (onClickToggleCallBack != null)
			{
				onClickToggleCallBack(this.SceneId, this.IsVideo, etoggleState, this.VoiceCode);
			}
			this.IsClicked = (etoggleState == EToggleState.ETT_Checked);
		}

		// Token: 0x0401D299 RID: 119449
		[Nullable(2)]
		public Action<int?, bool, EToggleState, string> OnClickToggleCallBack;

		// Token: 0x0401D29A RID: 119450
		private int? SceneId;

		// Token: 0x0401D29B RID: 119451
		private bool IsVideo;

		// Token: 0x0401D29C RID: 119452
		[Nullable(2)]
		private string VoiceCode;

		// Token: 0x0401D29D RID: 119453
		private bool IsClicked;

		// Token: 0x0200AAF8 RID: 43768
		private class ESubPackageDownLoadMobileClearInfoItem
		{
			// Token: 0x04035365 RID: 217957
			public const int Toggle = 0;

			// Token: 0x04035366 RID: 217958
			public const int Text = 1;

			// Token: 0x04035367 RID: 217959
			public const int EmptyItem = 2;

			// Token: 0x04035368 RID: 217960
			public const int SpaceText = 3;

			// Token: 0x04035369 RID: 217961
			public const int EmptyText = 4;

			// Token: 0x0403536A RID: 217962
			public const int SelectItem = 5;
		}
	}
}
