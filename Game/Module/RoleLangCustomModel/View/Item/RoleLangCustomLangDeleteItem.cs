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
	// Token: 0x020050F9 RID: 20729
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RoleLangCustomLangDeleteItem : GridProxyAbstract<IRoleLangCustomLangSelectInfo>
	{
		// Token: 0x060356FC RID: 218876 RVA: 0x00D68D28 File Offset: 0x00D66F28
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
		}

		// Token: 0x060356FD RID: 218877 RVA: 0x00D68FAC File Offset: 0x00D671AC
		protected override void OnStart()
		{
			base.GetExtendToggle(0).CanExecuteChange.Bind(new Func<bool>(this.ToggleCanChangeState));
			base.GetExtendToggle(0).OnStateChange.Add(new Action<EToggleState>(this.OnToggleStateChanged));
			base.GetExtendToggle(0).OnUndeterminedClicked.Add(new Action(this.OnUndeterminedClicked));
		}

		// Token: 0x060356FE RID: 218878 RVA: 0x00D69010 File Offset: 0x00D67210
		public override void Refresh(IRoleLangCustomLangSelectInfo data, bool isSelected, int gridIndex)
		{
			this.ItemData = data;
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
			base.GetExtendToggle(0).SetSelfInteractive(this.ToggleIsEnable());
			if (!this.ToggleIsEnable())
			{
				base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_UnDetermined, false, false, false);
				return;
			}
			if (this.OnToggleSelectedCheck != null)
			{
				this.SetSelected(this.OnToggleSelectedCheck(data), false);
			}
		}

		// Token: 0x060356FF RID: 218879 RVA: 0x00D6917C File Offset: 0x00D6737C
		public void RefreshStateTag()
		{
			bool flag = ModelBase<RoleLangCustomModel>.Instance.GetRoleLangType(this.ItemData.RoleId) == this.ItemData.LangIndex;
			bool flag2 = this.IsSameAsGlobalLang();
			RoleLangCustomLangPackageInfo info = new RoleLangCustomLangPackageInfo
			{
				RoleId = this.ItemData.RoleId,
				LangIndex = this.ItemData.LangIndex
			};
			ELanguageDownloadStatus downloadStatus = ModelBase<RoleLangCustomModel>.Instance.GetDownloadStatus(info);
			bool flag3 = downloadStatus == ELanguageDownloadStatus.None;
			bool flag4 = downloadStatus == ELanguageDownloadStatus.Half;
			bool flag5 = flag || flag3 || flag4 || flag2;
			base.GetItem(3).SetUIActive(flag5);
			if (flag5)
			{
				string key;
				if (flag)
				{
					key = "Label_VoiceDIY_Use";
				}
				else if (flag2)
				{
					key = "VoiceDIY_DefaultVoice";
				}
				else if (flag4)
				{
					key = "Label_VoiceDIY_Downloading";
				}
				else
				{
					key = "Label_VoiceDIY_Not_Downloaded";
				}
				base.GetText(5).ShowTextNew(key);
				base.GetSprite(14).SetUIActive(flag3 || flag2);
				bool flag6 = false;
				if (flag4)
				{
					flag6 = ModelBase<RoleLangCustomModel>.Instance.GetUpdateManager().IsDownloading(info);
				}
				base.GetSprite(15).SetUIActive(flag4 && flag6);
				base.GetSprite(16).SetUIActive(flag4 && !flag6);
				base.GetSprite(17).SetUIActive(flag);
				if (flag)
				{
					UUISprite sprite = base.GetSprite(4);
					if (sprite == null)
					{
						return;
					}
					sprite.SetColor(RoleLangCustomLangDeleteItem.IsCurrentUsingColor);
					return;
				}
				else if (flag3 || flag2)
				{
					UUISprite sprite2 = base.GetSprite(4);
					if (sprite2 == null)
					{
						return;
					}
					sprite2.SetColor(RoleLangCustomLangDeleteItem.NoResourceColor);
					return;
				}
				else if (flag4)
				{
					UUISprite sprite3 = base.GetSprite(4);
					if (sprite3 == null)
					{
						return;
					}
					sprite3.SetColor(RoleLangCustomLangDeleteItem.DownloadingColor);
				}
			}
		}

		// Token: 0x06035700 RID: 218880 RVA: 0x00D69304 File Offset: 0x00D67504
		protected bool IsSameAsGlobalLang()
		{
			int languageTypeByAudioCode = Singleton<LanguageSystem>.Instance.GetLanguageTypeByAudioCode(Singleton<LanguageSystem>.Instance.PackageAudio);
			return this.ItemData.LangIndex == languageTypeByAudioCode;
		}

		// Token: 0x06035701 RID: 218881 RVA: 0x00D69334 File Offset: 0x00D67534
		protected bool ToggleIsEnable()
		{
			return UKuroLauncherLibrary.NeedHotPatch() && !this.IsSameAsGlobalLang() && ModelBase<RoleLangCustomModel>.Instance.GetRoleLangType(this.ItemData.RoleId) != this.ItemData.LangIndex && ModelBase<RoleLangCustomModel>.Instance.GetDownloadStatus(new RoleLangCustomLangPackageInfo
			{
				RoleId = this.ItemData.RoleId,
				LangIndex = this.ItemData.LangIndex
			}) == ELanguageDownloadStatus.Done;
		}

		// Token: 0x06035702 RID: 218882 RVA: 0x00D693AF File Offset: 0x00D675AF
		public void SetSelected(bool isSelected, bool fireEvent = false)
		{
			if (!this.ToggleIsEnable())
			{
				return;
			}
			base.GetExtendToggle(0).SetToggleState(isSelected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, fireEvent, false, false);
		}

		// Token: 0x06035703 RID: 218883 RVA: 0x00D693D1 File Offset: 0x00D675D1
		private bool ToggleCanChangeState()
		{
			return true;
		}

		// Token: 0x06035704 RID: 218884 RVA: 0x00D693D4 File Offset: 0x00D675D4
		private void OnToggleStateChanged(EToggleState state)
		{
			Action<IRoleLangCustomLangSelectInfo, bool> onToggleStateChangedCallback = this.OnToggleStateChangedCallback;
			if (onToggleStateChangedCallback == null)
			{
				return;
			}
			onToggleStateChangedCallback(this.ItemData, state == EToggleState.ETT_Checked);
		}

		// Token: 0x06035705 RID: 218885 RVA: 0x00D693F0 File Offset: 0x00D675F0
		private void OnUndeterminedClicked()
		{
			bool flag = ModelBase<RoleLangCustomModel>.Instance.GetRoleLangType(this.ItemData.RoleId) == this.ItemData.LangIndex;
			bool flag2 = this.IsSameAsGlobalLang();
			RoleLangCustomLangPackageInfo info = new RoleLangCustomLangPackageInfo
			{
				RoleId = this.ItemData.RoleId,
				LangIndex = this.ItemData.LangIndex
			};
			bool flag3 = ModelBase<RoleLangCustomModel>.Instance.GetDownloadStatus(info) == ELanguageDownloadStatus.None;
			string textId = string.Empty;
			if (flag)
			{
				textId = "VoiceDIY_Tips_CannotDelete_Inuse";
			}
			else if (flag2)
			{
				textId = "VoiceDIY_Tips_CannotDelete_DefaultVoice";
			}
			else if (flag3)
			{
				textId = "VoiceDIY_Tips_CannotDelete_NotDownloaded";
			}
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId(textId, Array.Empty<object>());
		}

		// Token: 0x0401EB13 RID: 125715
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Action<IRoleLangCustomLangSelectInfo, bool> OnToggleStateChangedCallback;

		// Token: 0x0401EB14 RID: 125716
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Func<IRoleLangCustomLangSelectInfo, bool> OnToggleSelectedCheck;

		// Token: 0x0401EB15 RID: 125717
		public IRoleLangCustomLangSelectInfo ItemData;

		// Token: 0x0401EB16 RID: 125718
		[StaticVariableRuleIgnore]
		private static readonly FColor NoResourceColor = FColor.FromHex("#99a4ad");

		// Token: 0x0401EB17 RID: 125719
		[StaticVariableRuleIgnore]
		private static readonly FColor DownloadingColor = FColor.FromHex("#dae4e5");

		// Token: 0x0401EB18 RID: 125720
		[StaticVariableRuleIgnore]
		private static readonly FColor IsCurrentUsingColor = FColor.FromHex("#79e4b5");

		// Token: 0x0200B097 RID: 45207
		[NullableContext(0)]
		private enum EDefine
		{
			// Token: 0x04036CB0 RID: 224432
			TogItem,
			// Token: 0x04036CB1 RID: 224433
			TxtLanguageName,
			// Token: 0x04036CB2 RID: 224434
			TxtCvName,
			// Token: 0x04036CB3 RID: 224435
			PanelStateTag,
			// Token: 0x04036CB4 RID: 224436
			SpriteBg,
			// Token: 0x04036CB5 RID: 224437
			TxtStateTitle,
			// Token: 0x04036CB6 RID: 224438
			BtnPlay,
			// Token: 0x04036CB7 RID: 224439
			SpritePlayIcon,
			// Token: 0x04036CB8 RID: 224440
			SpritePauseIcon,
			// Token: 0x04036CB9 RID: 224441
			BtnDownload,
			// Token: 0x04036CBA RID: 224442
			BtnDownloadProgress,
			// Token: 0x04036CBB RID: 224443
			SpriteDownloadFill,
			// Token: 0x04036CBC RID: 224444
			SpriteStarDownloadIcon,
			// Token: 0x04036CBD RID: 224445
			SpritePauseDownloadIcon,
			// Token: 0x04036CBE RID: 224446
			TagSpriteNoLoad,
			// Token: 0x04036CBF RID: 224447
			TagSpriteDownloading,
			// Token: 0x04036CC0 RID: 224448
			TagSpritePause,
			// Token: 0x04036CC1 RID: 224449
			TagSpriteUsing
		}
	}
}
