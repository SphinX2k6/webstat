using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Launcher.Update;
using UnrealEngine;

namespace CSharpScript.Game.Module.RoleLangCustomModel.View.Item
{
	// Token: 0x020050FC RID: 20732
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RoleLangCustomLangSelectItem : GridProxyAbstract<IRoleLangCustomLangSelectInfo>
	{
		// Token: 0x0603571A RID: 218906 RVA: 0x00D69B0C File Offset: 0x00D67D0C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 18;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(14, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(15, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(16, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(17, typeof(UUISprite));
			this.ComponentRegisterInfos = list;
			num2 = 3;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(6, new Action(this.OnClickedBtnPlay));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(9, new Action(this.OnClickedBtnDownload));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(10, new Action(this.OnClickedBtnDownloadProgress));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603571B RID: 218907 RVA: 0x00D69E14 File Offset: 0x00D68014
		protected override void OnStart()
		{
			base.GetExtendToggle(0).CanExecuteChange.Bind(new Func<bool>(this.ToggleCanChangeState));
			base.GetExtendToggle(0).OnStateChange.Add(new Action<EToggleState>(this.OnToggleStateChanged));
			this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
		}

		// Token: 0x0603571C RID: 218908 RVA: 0x00D69E6C File Offset: 0x00D6806C
		public override void Refresh(IRoleLangCustomLangSelectInfo data, bool isSelected, int gridIndex)
		{
			this.ItemData = data;
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null && levelSequencePlayer.IsPlayingSequence("Finished"))
			{
				this.LevelSequencePlayer.StopSequenceByKey("Finished", false, true);
			}
			RoleVoiceLanguage? roleLangCustomConfigById = ConfigBase<MenuBaseConfig>.Instance.GetRoleLangCustomConfigById(data.LangIndex);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), roleLangCustomConfigById.Value.Text, Array.Empty<object>());
			FavorRoleInfo? favorRoleInfoConfig = ConfigBase<RoleFavorConfig>.Instance.GetFavorRoleInfoConfig(data.RoleId);
			if (favorRoleInfoConfig != null)
			{
				string item = "";
				if (data.LangIndex == 0)
				{
					item = Singleton<PublicUtil>.Instance.GetConfigTextByKey(favorRoleInfoConfig.Value.CVNameCn);
				}
				else if (data.LangIndex == 1)
				{
					item = Singleton<PublicUtil>.Instance.GetConfigTextByKey(favorRoleInfoConfig.Value.CVNameEn);
				}
				else if (data.LangIndex == 2)
				{
					item = Singleton<PublicUtil>.Instance.GetConfigTextByKey(favorRoleInfoConfig.Value.CVNameJp);
				}
				else if (data.LangIndex == 3)
				{
					item = Singleton<PublicUtil>.Instance.GetConfigTextByKey(favorRoleInfoConfig.Value.CVNameKo);
				}
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), "Role_VoiceDIY_CV", new <>z__ReadOnlySingleElementList<object>(item));
			}
			this.RefreshStateTag();
			this.RefreshButtonState();
			if (this.AudioEventHandle != null)
			{
				Singleton<AudioSystem>.Instance.ExecuteAction(this.AudioEventHandle.Value, EAudioActionType.Stop, null);
				this.AudioEventHandle = null;
			}
			if (this.OnToggleSelectedCheck != null)
			{
				this.SetSelected(this.OnToggleSelectedCheck(this.ItemData), false);
			}
		}

		// Token: 0x0603571D RID: 218909 RVA: 0x00D6A01C File Offset: 0x00D6821C
		public bool OnTick(float delta)
		{
			if (!this.NeedTick)
			{
				return false;
			}
			this.RefreshButtonState();
			this.RefreshStateTag();
			if (!this.NeedTick)
			{
				LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
				if (levelSequencePlayer != null)
				{
					levelSequencePlayer.PlayOrReplaySequenceByName("Finished", false, null);
				}
			}
			return !this.NeedTick;
		}

		// Token: 0x0603571E RID: 218910 RVA: 0x00D6A070 File Offset: 0x00D68270
		public void RefreshStateTag()
		{
			bool flag = ModelBase<RoleLangCustomModel>.Instance.GetRoleLangType(this.ItemData.RoleId) == this.ItemData.LangIndex;
			RoleLangCustomLangPackageInfo info = new RoleLangCustomLangPackageInfo
			{
				RoleId = this.ItemData.RoleId,
				LangIndex = this.ItemData.LangIndex
			};
			ELanguageDownloadStatus downloadStatus = ModelBase<RoleLangCustomModel>.Instance.GetDownloadStatus(info);
			bool flag2 = downloadStatus == ELanguageDownloadStatus.None;
			bool flag3 = downloadStatus == ELanguageDownloadStatus.Half;
			bool flag4 = flag || flag2 || flag3;
			base.GetItem(3).SetUIActive(flag4);
			if (flag4)
			{
				string key;
				if (flag)
				{
					key = "Label_VoiceDIY_Use";
				}
				else if (flag3)
				{
					key = "Label_VoiceDIY_Downloading";
				}
				else
				{
					key = "Label_VoiceDIY_Not_Downloaded";
				}
				base.GetText(5).ShowTextNew(key);
				base.GetSprite(14).SetUIActive(flag2);
				bool flag5 = false;
				if (flag3)
				{
					flag5 = ModelBase<RoleLangCustomModel>.Instance.GetUpdateManager().IsDownloading(info);
				}
				base.GetSprite(15).SetUIActive(flag3 && flag5);
				base.GetSprite(16).SetUIActive(flag3 && !flag5);
				base.GetSprite(17).SetUIActive(flag);
				if (flag)
				{
					UUISprite sprite = base.GetSprite(4);
					if (sprite == null)
					{
						return;
					}
					sprite.SetColor(RoleLangCustomLangSelectItem.IsCurrentUsingColor);
					return;
				}
				else if (flag2)
				{
					UUISprite sprite2 = base.GetSprite(4);
					if (sprite2 == null)
					{
						return;
					}
					sprite2.SetColor(RoleLangCustomLangSelectItem.NoResourceColor);
					return;
				}
				else if (flag3)
				{
					UUISprite sprite3 = base.GetSprite(4);
					if (sprite3 == null)
					{
						return;
					}
					sprite3.SetColor(RoleLangCustomLangSelectItem.DownloadingColor);
				}
			}
		}

		// Token: 0x0603571F RID: 218911 RVA: 0x00D6A1D8 File Offset: 0x00D683D8
		public void RefreshButtonState()
		{
			RoleLangCustomLangPackageInfo info = new RoleLangCustomLangPackageInfo
			{
				RoleId = this.ItemData.RoleId,
				LangIndex = this.ItemData.LangIndex
			};
			ELanguageDownloadStatus downloadStatus = ModelBase<RoleLangCustomModel>.Instance.GetDownloadStatus(info);
			bool flag = downloadStatus == ELanguageDownloadStatus.Done;
			bool flag2 = downloadStatus == ELanguageDownloadStatus.None;
			bool flag3 = downloadStatus == ELanguageDownloadStatus.Half;
			base.GetButton(6).RootUIComp.Get().SetUIActive(flag);
			base.GetButton(9).RootUIComp.Get().SetUIActive(flag2);
			base.GetButton(10).RootUIComp.Get().SetUIActive(flag3);
			if (flag)
			{
				this.NeedTick = false;
				Func<IRoleLangCustomLangSelectInfo, bool> checkCurrentIsPlayingCallback = this.CheckCurrentIsPlayingCallback;
				bool flag4 = checkCurrentIsPlayingCallback != null && checkCurrentIsPlayingCallback(this.ItemData);
				base.GetSprite(7).SetUIActive(!flag4);
				base.GetSprite(8).SetUIActive(flag4);
				return;
			}
			if (!flag2 && flag3)
			{
				List<int> downloadProgress = ModelBase<RoleLangCustomModel>.Instance.GetDownloadProgress(this.ItemData.RoleId, this.ItemData.LangIndex);
				int num = downloadProgress[0];
				int num2 = downloadProgress[1];
				float fillAmount = (num2 == 0) ? 1f : ((float)num / (float)num2);
				base.GetSprite(11).SetFillAmount(fillAmount);
				bool flag5 = !ModelBase<RoleLangCustomModel>.Instance.GetUpdateManager().IsDownloading(info);
				base.GetSprite(12).SetUIActive(flag5);
				base.GetSprite(13).SetUIActive(!flag5);
			}
		}

		// Token: 0x06035720 RID: 218912 RVA: 0x00D6A353 File Offset: 0x00D68553
		public void SetSelected(bool isSelected, bool fireEvent = false)
		{
			base.GetExtendToggle(0).SetToggleState(isSelected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, fireEvent, false, false);
		}

		// Token: 0x06035721 RID: 218913 RVA: 0x00D6A36C File Offset: 0x00D6856C
		public void SetNeedTick(bool needTick)
		{
			this.NeedTick = needTick;
		}

		// Token: 0x06035722 RID: 218914 RVA: 0x00D6A375 File Offset: 0x00D68575
		private bool ToggleCanChangeState()
		{
			return true;
		}

		// Token: 0x06035723 RID: 218915 RVA: 0x00D6A378 File Offset: 0x00D68578
		private void OnToggleStateChanged(EToggleState state)
		{
			Action<IRoleLangCustomLangSelectInfo> onToggleStateChangedCallback = this.OnToggleStateChangedCallback;
			if (onToggleStateChangedCallback == null)
			{
				return;
			}
			onToggleStateChangedCallback(this.ItemData);
		}

		// Token: 0x06035724 RID: 218916 RVA: 0x00D6A390 File Offset: 0x00D68590
		private void OnClickedBtnPlay()
		{
			this.SetSelected(true, true);
			Action<IRoleLangCustomLangSelectInfo> onPlayAudioCallback = this.OnPlayAudioCallback;
			if (onPlayAudioCallback != null)
			{
				onPlayAudioCallback(this.ItemData);
			}
			this.RefreshButtonState();
		}

		// Token: 0x06035725 RID: 218917 RVA: 0x00D6A3B8 File Offset: 0x00D685B8
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
			if (!ModelBase<RoleLangCustomModel>.Instance.CheckSpaceEnough(info))
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("VoiceDIY_Tips_OutOfMemory", Array.Empty<object>());
				return;
			}
			ModelBase<RoleLangCustomModel>.Instance.StartDownloading(info);
			this.NeedTick = true;
		}

		// Token: 0x06035726 RID: 218918 RVA: 0x00D6A450 File Offset: 0x00D68650
		private void OnClickedBtnDownloadProgress()
		{
			this.NeedTick = true;
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

		// Token: 0x0401EB20 RID: 125728
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Action<IRoleLangCustomLangSelectInfo> OnToggleStateChangedCallback;

		// Token: 0x0401EB21 RID: 125729
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Func<IRoleLangCustomLangSelectInfo, bool> OnToggleSelectedCheck;

		// Token: 0x0401EB22 RID: 125730
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Func<IRoleLangCustomLangSelectInfo, bool> CheckCurrentIsPlayingCallback;

		// Token: 0x0401EB23 RID: 125731
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Action<IRoleLangCustomLangSelectInfo> OnPlayAudioCallback;

		// Token: 0x0401EB24 RID: 125732
		public IRoleLangCustomLangSelectInfo ItemData;

		// Token: 0x0401EB25 RID: 125733
		public bool NeedTick;

		// Token: 0x0401EB26 RID: 125734
		protected int? AudioEventHandle;

		// Token: 0x0401EB27 RID: 125735
		[Nullable(2)]
		protected LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x0401EB28 RID: 125736
		[StaticVariableRuleIgnore]
		private static readonly FColor NoResourceColor = FColor.FromHex("#99a4ad");

		// Token: 0x0401EB29 RID: 125737
		[StaticVariableRuleIgnore]
		private static readonly FColor DownloadingColor = FColor.FromHex("#dae4e5");

		// Token: 0x0401EB2A RID: 125738
		[StaticVariableRuleIgnore]
		private static readonly FColor IsCurrentUsingColor = FColor.FromHex("#79e4b5");

		// Token: 0x0200B09C RID: 45212
		[NullableContext(0)]
		private enum EDefine
		{
			// Token: 0x04036CD9 RID: 224473
			TogItem,
			// Token: 0x04036CDA RID: 224474
			TxtLanguageName,
			// Token: 0x04036CDB RID: 224475
			TxtCvName,
			// Token: 0x04036CDC RID: 224476
			PanelStateTag,
			// Token: 0x04036CDD RID: 224477
			SpriteBg,
			// Token: 0x04036CDE RID: 224478
			TxtStateTitle,
			// Token: 0x04036CDF RID: 224479
			BtnPlay,
			// Token: 0x04036CE0 RID: 224480
			SpritePlayIcon,
			// Token: 0x04036CE1 RID: 224481
			SpritePauseIcon,
			// Token: 0x04036CE2 RID: 224482
			BtnDownload,
			// Token: 0x04036CE3 RID: 224483
			BtnDownloadProgress,
			// Token: 0x04036CE4 RID: 224484
			SpriteDownloadFill,
			// Token: 0x04036CE5 RID: 224485
			SpriteStarDownloadIcon,
			// Token: 0x04036CE6 RID: 224486
			SpritePauseDownloadIcon,
			// Token: 0x04036CE7 RID: 224487
			TagSpriteNoLoad,
			// Token: 0x04036CE8 RID: 224488
			TagSpriteDownloading,
			// Token: 0x04036CE9 RID: 224489
			TagSpritePause,
			// Token: 0x04036CEA RID: 224490
			TagSpriteUsing
		}
	}
}
