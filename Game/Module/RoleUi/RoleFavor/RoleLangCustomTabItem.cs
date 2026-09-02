using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.RoleLangCustomModel;
using CSharpScript.Game.Module.Util;
using CSharpScript.Launcher.Update;
using UnrealEngine;

namespace CSharpScript.Game.Module.RoleUi.RoleFavor
{
	// Token: 0x02005077 RID: 20599
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RoleLangCustomTabItem : GridProxyAbstract<IRoleLangCustomInfo>
	{
		// Token: 0x060351B4 RID: 217524 RVA: 0x00D51F34 File Offset: 0x00D50134
		protected unsafe override void OnRegisterComponent()
		{
			int num = 8;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIButtonComponent));
			this.ComponentRegisterInfos = list;
			num2 = 2;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(7, new Action(this.OnClickedBtnDownload));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnClickedBtnDownloadProgress));
			this.BtnBindInfo = list2;
		}

		// Token: 0x060351B5 RID: 217525 RVA: 0x00D520C3 File Offset: 0x00D502C3
		protected override void OnStart()
		{
			base.GetExtendToggle(0).CanExecuteChange.Bind(new Func<bool>(this.ToggleCanChangeState));
			base.GetExtendToggle(0).OnStateChange.Add(new Action<EToggleState>(this.OnToggleStateChanged));
		}

		// Token: 0x060351B6 RID: 217526 RVA: 0x00D52100 File Offset: 0x00D50300
		public override void Refresh(IRoleLangCustomInfo data, bool isSelected, int gridIndex)
		{
			this.ItemData = data;
			RoleVoiceLanguage? roleLangCustomConfigById = ConfigBase<MenuBaseConfig>.Instance.GetRoleLangCustomConfigById(data.LangIndex);
			string configTextByKey = Singleton<PublicUtil>.Instance.GetConfigTextByKey(roleLangCustomConfigById.Value.Text);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "VoiceDIY_Dubbing", new <>z__ReadOnlySingleElementList<object>(configTextByKey));
			EToggleState state = (ModelBase<RoleLangCustomModel>.Instance.GetRoleLangType(data.RoleId) == data.LangIndex) ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (extendToggle != null)
			{
				extendToggle.SetToggleState(state, false, false, false);
			}
			this.RefreshButton();
		}

		// Token: 0x060351B7 RID: 217527 RVA: 0x00D52198 File Offset: 0x00D50398
		protected bool RefreshButton()
		{
			bool needTick = this.NeedTick;
			RoleLangCustomUpdateManager updateManager = ModelBase<RoleLangCustomModel>.Instance.GetUpdateManager();
			RoleLangCustomLangPackageInfo info = new RoleLangCustomLangPackageInfo
			{
				RoleId = this.ItemData.RoleId,
				LangIndex = this.ItemData.LangIndex
			};
			ELanguageDownloadStatus downloadStatus = ModelBase<RoleLangCustomModel>.Instance.GetDownloadStatus(info);
			bool flag = downloadStatus == ELanguageDownloadStatus.Done;
			bool flag2 = downloadStatus == ELanguageDownloadStatus.Half;
			bool uiactive = downloadStatus == ELanguageDownloadStatus.None;
			base.GetItem(2).SetUIActive(flag);
			base.GetButton(3).RootUIComp.Get().SetUIActive(flag2);
			base.GetButton(7).RootUIComp.Get().SetUIActive(uiactive);
			if (flag2)
			{
				this.NeedTick = true;
				bool flag3 = updateManager.IsDownloading(info);
				List<int> downloadProgress = updateManager.GetDownloadProgress(info);
				int num = downloadProgress[0];
				int num2 = downloadProgress[1];
				float fillAmount = (num2 == 0) ? 1f : ((float)num / (float)num2);
				base.GetSprite(4).SetFillAmount(fillAmount);
				base.GetSprite(5).SetUIActive(flag3);
				base.GetSprite(6).SetUIActive(!flag3);
			}
			else if (flag)
			{
				this.NeedTick = false;
			}
			return needTick && !this.NeedTick;
		}

		// Token: 0x060351B8 RID: 217528 RVA: 0x00D522C1 File Offset: 0x00D504C1
		public bool OnTick()
		{
			return this.NeedTick && this.RefreshButton();
		}

		// Token: 0x060351B9 RID: 217529 RVA: 0x00D522D4 File Offset: 0x00D504D4
		private bool ToggleCanChangeState()
		{
			if (this.CheckScrollActiveCallback != null && !this.CheckScrollActiveCallback())
			{
				return true;
			}
			RoleLangCustomLangPackageInfo info = new RoleLangCustomLangPackageInfo
			{
				RoleId = this.ItemData.RoleId,
				LangIndex = this.ItemData.LangIndex
			};
			return ModelBase<RoleLangCustomModel>.Instance.GetDownloadStatus(info) == ELanguageDownloadStatus.Done;
		}

		// Token: 0x060351BA RID: 217530 RVA: 0x00D5232E File Offset: 0x00D5052E
		private void OnToggleStateChanged(EToggleState state)
		{
			Action<IRoleLangCustomInfo> onClickedCallback = this.OnClickedCallback;
			if (onClickedCallback == null)
			{
				return;
			}
			onClickedCallback(this.ItemData);
		}

		// Token: 0x060351BB RID: 217531 RVA: 0x00D52348 File Offset: 0x00D50548
		private void OnClickedBtnDownload()
		{
			if (ModelBase<RoleLangCustomModel>.Instance.CheckPackageAudioDownloading(this.ItemData.LangIndex))
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("VoiceDIY_Tips_DownloadingEntireVoice", Array.Empty<object>());
				return;
			}
			RoleLangCustomLangPackageInfo info = new RoleLangCustomLangPackageInfo
			{
				RoleId = this.ItemData.RoleId,
				LangIndex = this.ItemData.LangIndex
			};
			ModelBase<RoleLangCustomModel>.Instance.StartDownloading(info);
			this.NeedTick = true;
		}

		// Token: 0x060351BC RID: 217532 RVA: 0x00D523BC File Offset: 0x00D505BC
		private void OnClickedBtnDownloadProgress()
		{
			RoleLangCustomLangPackageInfo info = new RoleLangCustomLangPackageInfo
			{
				RoleId = this.ItemData.RoleId,
				LangIndex = this.ItemData.LangIndex
			};
			if (ModelBase<RoleLangCustomModel>.Instance.GetUpdateManager().IsDownloading(info))
			{
				ModelBase<RoleLangCustomModel>.Instance.PauseDownloading(info);
				return;
			}
			ModelBase<RoleLangCustomModel>.Instance.StartDownloading(info);
		}

		// Token: 0x0401E93B RID: 125243
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Action<IRoleLangCustomInfo> OnClickedCallback;

		// Token: 0x0401E93C RID: 125244
		[Nullable(2)]
		public Func<bool> CheckScrollActiveCallback;

		// Token: 0x0401E93D RID: 125245
		public bool NeedTick;

		// Token: 0x0401E93E RID: 125246
		protected IRoleLangCustomInfo ItemData;

		// Token: 0x0200B030 RID: 45104
		[NullableContext(0)]
		private enum EToggle
		{
			// Token: 0x04036A8B RID: 223883
			ToggleItem,
			// Token: 0x04036A8C RID: 223884
			TxtName,
			// Token: 0x04036A8D RID: 223885
			PanelCheckState,
			// Token: 0x04036A8E RID: 223886
			BtnDownloadProgress,
			// Token: 0x04036A8F RID: 223887
			SpriteDownloadFill,
			// Token: 0x04036A90 RID: 223888
			SpritePauseIcon,
			// Token: 0x04036A91 RID: 223889
			SpritePlayIcon,
			// Token: 0x04036A92 RID: 223890
			BtnDownload
		}
	}
}
