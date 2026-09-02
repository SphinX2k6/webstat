using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Kurotato.View.Pause
{
	// Token: 0x02005A93 RID: 23187
	[NullableContext(1)]
	[Nullable(0)]
	public class KurotatoPopupSaveView : UiViewBase, IExtraUiPopFrameType
	{
		// Token: 0x0603AAA9 RID: 240297 RVA: 0x00EDDA29 File Offset: 0x00EDBC29
		public KurotatoPopupSaveView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x0603AAAA RID: 240298 RVA: 0x00EDDA68 File Offset: 0x00EDBC68
		protected unsafe override void OnRegisterComponent()
		{
			int num = 9;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIButtonComponent));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickBtnHelp));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603AAAB RID: 240299 RVA: 0x00EDDBF8 File Offset: 0x00EDBDF8
		protected override UniTask OnBeforeStartAsync()
		{
			KurotatoPopupSaveView.<OnBeforeStartAsync>d__11 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<KurotatoPopupSaveView.<OnBeforeStartAsync>d__11>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603AAAC RID: 240300 RVA: 0x00EDDC3B File Offset: 0x00EDBE3B
		protected override void OnStart()
		{
			this.RefreshSaveState();
			this.RefreshOverwriteConfirmPanel();
		}

		// Token: 0x0603AAAD RID: 240301 RVA: 0x00EDDC4C File Offset: 0x00EDBE4C
		protected override void OnBeforeShow()
		{
			IUiPopFrameInterface childPopView = this.ChildPopView;
			if (childPopView != null)
			{
				childPopView.SetBackBtnShowState(this.Config.Value.NeedClose);
			}
			IUiPopFrameInterface childPopView2 = this.ChildPopView;
			if (childPopView2 != null)
			{
				childPopView2.PopItem.SetMaskResponsibleState(this.Config.Value.NeedMaskClose);
			}
			IUiPopFrameInterface childPopView3 = this.ChildPopView;
			if (childPopView3 == null)
			{
				return;
			}
			childPopView3.PopItem.OverrideBackBtnCallBack(new Action(this.OnClose));
		}

		// Token: 0x0603AAAE RID: 240302 RVA: 0x00EDDCC7 File Offset: 0x00EDBEC7
		protected override void OnAfterShow()
		{
			Action afterShowFunction = this.ConfirmBoxData.GetAfterShowFunction();
			if (afterShowFunction == null)
			{
				return;
			}
			afterShowFunction();
		}

		// Token: 0x0603AAAF RID: 240303 RVA: 0x00EDDCDE File Offset: 0x00EDBEDE
		protected override void OnBeforeHide()
		{
			if (this.LastHide)
			{
				ConfirmBoxDataNew confirmBoxData = this.ConfirmBoxData;
				if (confirmBoxData == null)
				{
					return;
				}
				Action beforePlayCloseFunction = confirmBoxData.BeforePlayCloseFunction;
				if (beforePlayCloseFunction == null)
				{
					return;
				}
				beforePlayCloseFunction();
			}
		}

		// Token: 0x0603AAB0 RID: 240304 RVA: 0x00EDDD04 File Offset: 0x00EDBF04
		protected override void OnBeforeDestroy()
		{
			this.ResetButtonList();
			this.HandleSelectedIndexWhenClose();
			Action action;
			if (this.ConfirmBoxData != null && this.ConfirmBoxData.FunctionMap.TryGetValue(this.SelectedIndex, out action))
			{
				action();
			}
			ConfirmBoxDataNew confirmBoxData = this.ConfirmBoxData;
			if (confirmBoxData == null)
			{
				return;
			}
			Action destroyFunction = confirmBoxData.DestroyFunction;
			if (destroyFunction == null)
			{
				return;
			}
			destroyFunction();
		}

		// Token: 0x0603AAB1 RID: 240305 RVA: 0x00EDDD60 File Offset: 0x00EDBF60
		private void RefreshSaveState()
		{
			List<KurotatoInstInfo> roleSaveInstInfos = ModelBase<KurotatoModel>.Instance.GetRoleSaveInstInfos();
			KurotatoInstInfo kurotatoInstInfo = (roleSaveInstInfos.Count > 0) ? roleSaveInstInfos[0] : null;
			KurotatoInstInfo kurotatoInstInfo2 = (roleSaveInstInfos.Count > 1) ? roleSaveInstInfos[1] : null;
			this.HasOldSave = (kurotatoInstInfo2 != null);
			KurotatoSaveArchivePanel newSavePanel = this.NewSavePanel;
			KurotatoSaveData saveData;
			if (kurotatoInstInfo == null)
			{
				saveData = null;
			}
			else
			{
				KurotatoSaveData kurotatoSaveData = new KurotatoSaveData();
				kurotatoSaveData.SaveTimestamp = kurotatoInstInfo.SaveTimestamp;
				kurotatoSaveData.RoleLevel = kurotatoInstInfo.RoleLevel;
				saveData = kurotatoSaveData;
				kurotatoSaveData.WaveNum = kurotatoInstInfo.CurWave;
			}
			newSavePanel.RefreshSaveInfo(saveData, 0);
			KurotatoSaveArchivePanel oldSavePanel = this.OldSavePanel;
			KurotatoSaveData saveData2;
			if (kurotatoInstInfo2 == null)
			{
				saveData2 = null;
			}
			else
			{
				KurotatoSaveData kurotatoSaveData2 = new KurotatoSaveData();
				kurotatoSaveData2.SaveTimestamp = kurotatoInstInfo2.SaveTimestamp;
				kurotatoSaveData2.RoleLevel = kurotatoInstInfo2.RoleLevel;
				saveData2 = kurotatoSaveData2;
				kurotatoSaveData2.WaveNum = kurotatoInstInfo2.CurWave;
			}
			oldSavePanel.RefreshSaveInfo(saveData2, 1);
		}

		// Token: 0x0603AAB2 RID: 240306 RVA: 0x00EDDE20 File Offset: 0x00EDC020
		private void RefreshOverwriteConfirmPanel()
		{
			base.GetItem(5).SetUIActive(this.HasOldSave);
			UUIItem uuiitem = base.GetButton(7).RootUIComp.Get();
			if (uuiitem == null)
			{
				return;
			}
			uuiitem.SetUIActive(this.HasOldSave);
		}

		// Token: 0x0603AAB3 RID: 240307 RVA: 0x00EDDE63 File Offset: 0x00EDC063
		private bool IsOverwriteConfirmChecked()
		{
			return base.GetExtendToggle(6).ToggleState == EToggleState.ETT_Checked;
		}

		// Token: 0x0603AAB4 RID: 240308 RVA: 0x00EDDE74 File Offset: 0x00EDC074
		private void OnClose()
		{
			this.SelectedIndex = -1;
			base.CloseMe(delegate(bool _)
			{
				Action closeFunction = this.ConfirmBoxData.GetCloseFunction();
				if (closeFunction == null)
				{
					return;
				}
				closeFunction();
			});
		}

		// Token: 0x0603AAB5 RID: 240309 RVA: 0x00EDDE8F File Offset: 0x00EDC08F
		private void HandleSelectedIndexWhenClose()
		{
			if (this.SelectedIndex == -1)
			{
				this.SelectedIndex = 0;
			}
		}

		// Token: 0x0603AAB6 RID: 240310 RVA: 0x00EDDEA4 File Offset: 0x00EDC0A4
		private void OnClickBtnHelp()
		{
			int valueOrDefault = ConfigCommonParamById.GetIntConfig("KurotatoSavePopupHelpId").GetValueOrDefault();
			ControllerBase<HelpController>.Instance.OpenHelpById(valueOrDefault);
		}

		// Token: 0x0603AAB7 RID: 240311 RVA: 0x00EDDED0 File Offset: 0x00EDC0D0
		private UniTask InitButton()
		{
			KurotatoPopupSaveView.<InitButton>d__23 <InitButton>d__;
			<InitButton>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitButton>d__.<>4__this = this;
			<InitButton>d__.<>1__state = -1;
			<InitButton>d__.<>t__builder.Start<KurotatoPopupSaveView.<InitButton>d__23>(ref <InitButton>d__);
			return <InitButton>d__.<>t__builder.Task;
		}

		// Token: 0x0603AAB8 RID: 240312 RVA: 0x00EDDF14 File Offset: 0x00EDC114
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		private UniTask<ConfirmBoxButton> CreateButton(UUIItem uiItem, int index, Action clickFunction)
		{
			KurotatoPopupSaveView.<CreateButton>d__24 <CreateButton>d__;
			<CreateButton>d__.<>t__builder = AsyncUniTaskMethodBuilder<ConfirmBoxButton>.Create();
			<CreateButton>d__.<>4__this = this;
			<CreateButton>d__.uiItem = uiItem;
			<CreateButton>d__.index = index;
			<CreateButton>d__.clickFunction = clickFunction;
			<CreateButton>d__.<>1__state = -1;
			<CreateButton>d__.<>t__builder.Start<KurotatoPopupSaveView.<CreateButton>d__24>(ref <CreateButton>d__);
			return <CreateButton>d__.<>t__builder.Task;
		}

		// Token: 0x0603AAB9 RID: 240313 RVA: 0x00EDDF70 File Offset: 0x00EDC170
		private void ResetButtonList()
		{
			int i = 0;
			int count = this.ButtonList.Count;
			while (i < count)
			{
				this.ButtonList[i].Destroy(null);
				i++;
			}
			this.ButtonList.Clear();
		}

		// Token: 0x0603AABA RID: 240314 RVA: 0x00EDDFB4 File Offset: 0x00EDC1B4
		private void OnConfirmBoxButtonClick(int buttonIndex)
		{
			if (buttonIndex == 1)
			{
				this.HandleSaveAction();
				return;
			}
			ConfirmBoxDataNew confirmBoxData = this.ConfirmBoxData;
			Func<int, bool> func = (confirmBoxData != null) ? confirmBoxData.CanExecuteCloseFunc : null;
			if (func != null && !func(this.SelectedIndex))
			{
				Action action;
				if (this.ConfirmBoxData != null && this.ConfirmBoxData.FunctionMap.TryGetValue(this.SelectedIndex, out action))
				{
					action();
					return;
				}
			}
			else
			{
				base.CloseMe(delegate(bool _)
				{
					Action closeFunction = this.ConfirmBoxData.GetCloseFunction();
					if (closeFunction == null)
					{
						return;
					}
					closeFunction();
				});
			}
		}

		// Token: 0x0603AABB RID: 240315 RVA: 0x00EDE02C File Offset: 0x00EDC22C
		private void HandleSaveAction()
		{
			if (!this.HasOldSave)
			{
				this.DoSaveRecord().Forget();
				return;
			}
			if (!this.IsOverwriteConfirmChecked())
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Kurotato_Character_Save_File_Tips", Array.Empty<object>());
				return;
			}
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.KurotatoOverwriteSave);
			confirmBoxDataNew.FunctionMap[2] = delegate()
			{
				this.DoSaveRecord().Forget();
			};
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
		}

		// Token: 0x0603AABC RID: 240316 RVA: 0x00EDE09C File Offset: 0x00EDC29C
		private UniTask DoSaveRecord()
		{
			KurotatoPopupSaveView.<DoSaveRecord>d__28 <DoSaveRecord>d__;
			<DoSaveRecord>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<DoSaveRecord>d__.<>4__this = this;
			<DoSaveRecord>d__.<>1__state = -1;
			<DoSaveRecord>d__.<>t__builder.Start<KurotatoPopupSaveView.<DoSaveRecord>d__28>(ref <DoSaveRecord>d__);
			return <DoSaveRecord>d__.<>t__builder.Task;
		}

		// Token: 0x0603AABD RID: 240317 RVA: 0x00EDE0DF File Offset: 0x00EDC2DF
		[NullableContext(2)]
		public EUiBehaviourPopType? GetExtraPopFrameType(object param = null)
		{
			return new EUiBehaviourPopType?(EUiBehaviourPopType.Middle);
		}

		// Token: 0x040212D5 RID: 135893
		private readonly KurotatoSaveArchivePanel OldSavePanel = new KurotatoSaveArchivePanel();

		// Token: 0x040212D6 RID: 135894
		private readonly KurotatoSaveArchivePanel NewSavePanel = new KurotatoSaveArchivePanel();

		// Token: 0x040212D7 RID: 135895
		private bool HasOldSave;

		// Token: 0x040212D8 RID: 135896
		[Nullable(2)]
		private ConfirmBoxDataNew ConfirmBoxData;

		// Token: 0x040212D9 RID: 135897
		private ConfirmBox? Config;

		// Token: 0x040212DA RID: 135898
		private int SelectedIndex = -1;

		// Token: 0x040212DB RID: 135899
		private readonly List<ConfirmBoxButton> ButtonList = new List<ConfirmBoxButton>();

		// Token: 0x040212DC RID: 135900
		private readonly List<UUIButtonComponent> ButtonComponentList = new List<UUIButtonComponent>();

		// Token: 0x0200BA82 RID: 47746
		[NullableContext(0)]
		private enum EComps
		{
			// Token: 0x0403995B RID: 235867
			BtnHelp,
			// Token: 0x0403995C RID: 235868
			TextSaveExpireTime,
			// Token: 0x0403995D RID: 235869
			TextSaveTip,
			// Token: 0x0403995E RID: 235870
			OldSavePanel,
			// Token: 0x0403995F RID: 235871
			NewSavePanel,
			// Token: 0x04039960 RID: 235872
			PanelOverwriteConfirm,
			// Token: 0x04039961 RID: 235873
			ToggleOverwriteConfirm,
			// Token: 0x04039962 RID: 235874
			BtnLeft,
			// Token: 0x04039963 RID: 235875
			BtnRight
		}
	}
}
