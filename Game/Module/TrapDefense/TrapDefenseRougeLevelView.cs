using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004E39 RID: 20025
	[NullableContext(1)]
	[Nullable(0)]
	public class TrapDefenseRougeLevelView : UiViewBase
	{
		// Token: 0x06033C2F RID: 212015 RVA: 0x00CF073F File Offset: 0x00CEE93F
		public TrapDefenseRougeLevelView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x06033C30 RID: 212016 RVA: 0x00CF0758 File Offset: 0x00CEE958
		protected unsafe override void OnRegisterComponent()
		{
			int num = 10;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUITexture));
			this.ComponentRegisterInfos = list;
			num2 = 2;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnClickBtnKeyboardSet));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(6, new Action(this.OnClickBtnSave));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06033C31 RID: 212017 RVA: 0x00CF092C File Offset: 0x00CEEB2C
		protected override UniTask OnBeforeStartAsync()
		{
			TrapDefenseRougeLevelView.<OnBeforeStartAsync>d__9 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<TrapDefenseRougeLevelView.<OnBeforeStartAsync>d__9>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06033C32 RID: 212018 RVA: 0x00CF096F File Offset: 0x00CEEB6F
		protected override void OnStart()
		{
			ModelBase<TrapDefenseModel>.Instance.RougeModeData.CheckModeOpenRedDotState();
			this.InitData();
		}

		// Token: 0x06033C33 RID: 212019 RVA: 0x00CF0987 File Offset: 0x00CEEB87
		protected override void OnAddEventListener()
		{
		}

		// Token: 0x06033C34 RID: 212020 RVA: 0x00CF0989 File Offset: 0x00CEEB89
		protected override void OnRemoveEventListener()
		{
		}

		// Token: 0x06033C35 RID: 212021 RVA: 0x00CF098B File Offset: 0x00CEEB8B
		protected override void OnBeforeShow()
		{
			this.UpdateData();
		}

		// Token: 0x06033C36 RID: 212022 RVA: 0x00CF0993 File Offset: 0x00CEEB93
		protected override void OnBeforeDestroy()
		{
		}

		// Token: 0x06033C37 RID: 212023 RVA: 0x00CF0995 File Offset: 0x00CEEB95
		protected override void OnBeforeHide()
		{
			this.ViewModel.Model.RougeModeData.SaveCacheReachOpenTimeLevels();
		}

		// Token: 0x06033C38 RID: 212024 RVA: 0x00CF09AC File Offset: 0x00CEEBAC
		public void OnClickBtnKeyboardSet()
		{
			this.ViewModel.Model.OpenViewKeySetting();
		}

		// Token: 0x06033C39 RID: 212025 RVA: 0x00CF09C0 File Offset: 0x00CEEBC0
		public void OnClickBtnSave()
		{
			int helpIdLevelSaveProgress = ConfigBase<TrapDefenseConfig>.Instance.GetHelpIdLevelSaveProgress();
			ControllerBase<HelpController>.Instance.OpenHelpById(helpIdLevelSaveProgress);
		}

		// Token: 0x06033C3A RID: 212026 RVA: 0x00CF09E4 File Offset: 0x00CEEBE4
		public void OnBtnHelp()
		{
			int helpIdRougeLevel = ConfigBase<TrapDefenseConfig>.Instance.GetHelpIdRougeLevel();
			ControllerBase<HelpController>.Instance.OpenHelpById(helpIdRougeLevel);
		}

		// Token: 0x06033C3B RID: 212027 RVA: 0x00CF0A07 File Offset: 0x00CEEC07
		public void OnBtnClose()
		{
			base.CloseMe(null);
		}

		// Token: 0x06033C3C RID: 212028 RVA: 0x00CF0A10 File Offset: 0x00CEEC10
		public void InitData()
		{
			if (this.ViewModel.JumpLevelData != null)
			{
				this.PanelLevelTab.InitSelectLevel(this.ViewModel.JumpLevelData);
			}
		}

		// Token: 0x06033C3D RID: 212029 RVA: 0x00CF0A35 File Offset: 0x00CEEC35
		public void UpdateData()
		{
			this.PanelLevelTab.UpdateModeData();
			this.UpdateSaveState();
		}

		// Token: 0x06033C3E RID: 212030 RVA: 0x00CF0A48 File Offset: 0x00CEEC48
		public void UpdateSaveState()
		{
			TrapDefenseLevelData curSelectLevel = this.PanelLevelTab.CurSelectLevel;
			bool flag = curSelectLevel != null && curSelectLevel.Config.IsCanSave;
			UUIButtonComponent button = base.GetButton(6);
			if (button != null)
			{
				button.RootUIComp.Get().SetUIActive(flag);
			}
			if (flag)
			{
				ETrapDefenseTextKey etrapDefenseTextKey = curSelectLevel.IsLeaved ? ETrapDefenseTextKey.LevelExistSaveTitle : ETrapDefenseTextKey.LevelCanSaveTitle;
				UUIText text = base.GetText(8);
				if (text == null)
				{
					return;
				}
				text.ShowTextNew(etrapDefenseTextKey.ToString());
			}
		}

		// Token: 0x06033C3F RID: 212031 RVA: 0x00CF0ACC File Offset: 0x00CEECCC
		public void OnSelectLevelItem(TrapDefenseLevelData data)
		{
			this.PanelNameInfo.UpdateData(data);
			this.PanelMapInfo.UpdateData(data);
			this.PanelTargetInfo.UpdateData(data);
			this.UpdateSaveState();
			string levelImage = data.Config.LevelImage;
			base.SetTextureByPath(levelImage, base.GetTexture(9), null, null);
			UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
			if (uiViewSequence != null)
			{
				uiViewSequence.StopSequenceByKey("Switch", false, false);
			}
			UiBehaviorLevelSequence uiViewSequence2 = this.UiViewSequence;
			if (uiViewSequence2 == null)
			{
				return;
			}
			uiViewSequence2.PlaySequencePurely("Switch", false, false);
		}

		// Token: 0x0401DF52 RID: 122706
		public TrapDefenseRougeLevelViewModel ViewModel = ModelBase<TrapDefenseModel>.Instance.ViewModelRougeLevel;

		// Token: 0x0401DF53 RID: 122707
		public PopupCaptionItem PopupCaption;

		// Token: 0x0401DF54 RID: 122708
		public TrapDefenseRougeLevelTabPanel PanelLevelTab;

		// Token: 0x0401DF55 RID: 122709
		public TrapDefenseLevelNamePanel PanelNameInfo;

		// Token: 0x0401DF56 RID: 122710
		public TrapDefenseLevelMapPanel PanelMapInfo;

		// Token: 0x0401DF57 RID: 122711
		public TrapDefenseLevelTargetPanel PanelTargetInfo;

		// Token: 0x0200ADC2 RID: 44482
		[NullableContext(0)]
		private class EChildType
		{
			// Token: 0x04035F50 RID: 221008
			public const int ItemCaption = 0;

			// Token: 0x04035F51 RID: 221009
			public const int BtnKeyboardSet = 1;

			// Token: 0x04035F52 RID: 221010
			public const int ItemLevelTabPanel = 2;

			// Token: 0x04035F53 RID: 221011
			public const int ItemLevelNamePanel = 3;

			// Token: 0x04035F54 RID: 221012
			public const int ItemLevelMapPanel = 4;

			// Token: 0x04035F55 RID: 221013
			public const int ItemLevelTargetPanel = 5;

			// Token: 0x04035F56 RID: 221014
			public const int BtnSave = 6;

			// Token: 0x04035F57 RID: 221015
			public const int SpriteSaveIcon = 7;

			// Token: 0x04035F58 RID: 221016
			public const int TextSaveTitle = 8;

			// Token: 0x04035F59 RID: 221017
			public const int TexLevel = 9;
		}
	}
}
