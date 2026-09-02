using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004E37 RID: 20023
	[NullableContext(1)]
	[Nullable(0)]
	public class TrapDefenseMainLevelView : UiViewBase
	{
		// Token: 0x06033C1A RID: 211994 RVA: 0x00CF026C File Offset: 0x00CEE46C
		public TrapDefenseMainLevelView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x06033C1B RID: 211995 RVA: 0x00CF0288 File Offset: 0x00CEE488
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

		// Token: 0x06033C1C RID: 211996 RVA: 0x00CF045C File Offset: 0x00CEE65C
		protected override UniTask OnBeforeStartAsync()
		{
			TrapDefenseMainLevelView.<OnBeforeStartAsync>d__9 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<TrapDefenseMainLevelView.<OnBeforeStartAsync>d__9>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06033C1D RID: 211997 RVA: 0x00CF049F File Offset: 0x00CEE69F
		protected override void OnStart()
		{
			this.InitData();
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.TrapDefenseMainLevelViewOpen, true);
		}

		// Token: 0x06033C1E RID: 211998 RVA: 0x00CF04B8 File Offset: 0x00CEE6B8
		protected override void OnAddEventListener()
		{
		}

		// Token: 0x06033C1F RID: 211999 RVA: 0x00CF04BA File Offset: 0x00CEE6BA
		protected override void OnRemoveEventListener()
		{
		}

		// Token: 0x06033C20 RID: 212000 RVA: 0x00CF04BC File Offset: 0x00CEE6BC
		protected override void OnBeforeShow()
		{
			this.UpdateData();
		}

		// Token: 0x06033C21 RID: 212001 RVA: 0x00CF04C4 File Offset: 0x00CEE6C4
		protected override void OnBeforeDestroy()
		{
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.TrapDefenseMainLevelViewOpen, false);
		}

		// Token: 0x06033C22 RID: 212002 RVA: 0x00CF04D7 File Offset: 0x00CEE6D7
		protected override void OnBeforeHide()
		{
			this.ViewModel.Model.LevelModeData.SaveCacheReachOpenTimeLevels();
		}

		// Token: 0x06033C23 RID: 212003 RVA: 0x00CF04EE File Offset: 0x00CEE6EE
		public void OnClickBtnKeyboardSet()
		{
			this.ViewModel.Model.OpenViewKeySetting();
		}

		// Token: 0x06033C24 RID: 212004 RVA: 0x00CF0500 File Offset: 0x00CEE700
		public void OnClickBtnSave()
		{
			int helpIdLevelSaveProgress = ConfigBase<TrapDefenseConfig>.Instance.GetHelpIdLevelSaveProgress();
			ControllerBase<HelpController>.Instance.OpenHelpById(helpIdLevelSaveProgress);
		}

		// Token: 0x06033C25 RID: 212005 RVA: 0x00CF0524 File Offset: 0x00CEE724
		public void OnBtnHelp()
		{
			int helpIdMainLevel = ConfigBase<TrapDefenseConfig>.Instance.GetHelpIdMainLevel();
			ControllerBase<HelpController>.Instance.OpenHelpById(helpIdMainLevel);
		}

		// Token: 0x06033C26 RID: 212006 RVA: 0x00CF0547 File Offset: 0x00CEE747
		public void OnBtnClose()
		{
			base.CloseMe(null);
		}

		// Token: 0x06033C27 RID: 212007 RVA: 0x00CF0550 File Offset: 0x00CEE750
		public void InitData()
		{
			if (this.ViewModel.JumpDifficulty != null)
			{
				ETrapDefenseDifficultyLevel? jumpDifficulty = this.ViewModel.JumpDifficulty;
				ETrapDefenseDifficultyLevel etrapDefenseDifficultyLevel = ETrapDefenseDifficultyLevel.None;
				if (!(jumpDifficulty.GetValueOrDefault() == etrapDefenseDifficultyLevel & jumpDifficulty != null))
				{
					this.PanelLevelTab.InitSelectDifficulty(this.ViewModel.JumpDifficulty.Value);
				}
			}
			if (this.ViewModel.JumpLevelData != null)
			{
				this.PanelLevelTab.InitSelectLevel(this.ViewModel.JumpLevelData);
			}
		}

		// Token: 0x06033C28 RID: 212008 RVA: 0x00CF05CF File Offset: 0x00CEE7CF
		public void UpdateData()
		{
			this.PanelLevelTab.UpdateModeData();
			this.UpdateSaveState();
		}

		// Token: 0x06033C29 RID: 212009 RVA: 0x00CF05E4 File Offset: 0x00CEE7E4
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

		// Token: 0x06033C2A RID: 212010 RVA: 0x00CF0668 File Offset: 0x00CEE868
		public void OnSelectLevelItem(TrapDefenseLevelData data)
		{
			this.UpdateSaveState();
			this.PanelNameInfo.UpdateData(data);
			this.PanelMapInfo.UpdateData(data);
			this.PanelTargetInfo.UpdateData(data);
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

		// Token: 0x0401DF4C RID: 122700
		public TrapDefenseMainLevelViewModel ViewModel = ModelBase<TrapDefenseModel>.Instance.ViewModelMainLevel;

		// Token: 0x0401DF4D RID: 122701
		public PopupCaptionItem PopupCaption;

		// Token: 0x0401DF4E RID: 122702
		public TrapDefenseMainLevelTabPanel PanelLevelTab;

		// Token: 0x0401DF4F RID: 122703
		public TrapDefenseLevelNamePanel PanelNameInfo;

		// Token: 0x0401DF50 RID: 122704
		public TrapDefenseLevelMapPanel PanelMapInfo;

		// Token: 0x0401DF51 RID: 122705
		public TrapDefenseLevelTargetPanel PanelTargetInfo;

		// Token: 0x0200ADC0 RID: 44480
		[NullableContext(0)]
		private class EChildType
		{
			// Token: 0x04035F42 RID: 220994
			public const int ItemCaption = 0;

			// Token: 0x04035F43 RID: 220995
			public const int BtnKeyboardSet = 1;

			// Token: 0x04035F44 RID: 220996
			public const int ItemLevelTabPanel = 2;

			// Token: 0x04035F45 RID: 220997
			public const int ItemLevelNamePanel = 3;

			// Token: 0x04035F46 RID: 220998
			public const int ItemLevelMapPanel = 4;

			// Token: 0x04035F47 RID: 220999
			public const int ItemLevelTargetPanel = 5;

			// Token: 0x04035F48 RID: 221000
			public const int BtnSave = 6;

			// Token: 0x04035F49 RID: 221001
			public const int SpriteSaveIcon = 7;

			// Token: 0x04035F4A RID: 221002
			public const int TextSaveTitle = 8;

			// Token: 0x04035F4B RID: 221003
			public const int TexLevel = 9;
		}
	}
}
