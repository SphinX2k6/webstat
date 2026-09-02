using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using CSharpScript.Launcher.Platform;
using Cysharp.Threading.Tasks;
using UnrealEngine;

// Token: 0x02002489 RID: 9353
[NullableContext(1)]
[Nullable(0)]
public class PhantomManagerConfigSharePopItem : UiViewBase
{
	// Token: 0x06012264 RID: 74340 RVA: 0x004FD84F File Offset: 0x004FBA4F
	public PhantomManagerConfigSharePopItem(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06012265 RID: 74341 RVA: 0x004FD858 File Offset: 0x004FBA58
	protected unsafe override void OnRegisterComponent()
	{
		int num = 9;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUITextInputComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 4;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnClickedSelfUpdate));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnClickedShare));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(5, new Action(this.OnClickedPaste));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(6, new Action(this.OnClickedImport));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06012266 RID: 74342 RVA: 0x004FDA50 File Offset: 0x004FBC50
	protected override void OnStart()
	{
		UUIText text = base.GetText(0);
		if (text != null)
		{
			text.SetText(ModelBase<PhantomBattleModel>.Instance.GetSelfPhantomConfigCode(), true);
		}
		UUIItem item = base.GetItem(3);
		if (item != null)
		{
			item.SetUIActive(ModelBase<PhantomBattleModel>.Instance.GetPhantomConfigData().PhantomSelfConfigNeedUpdate);
		}
		bool flag = Singleton<Info>.Instance.IsHomeConsolePlatform();
		UUIButtonComponent button = base.GetButton(2);
		if (button != null)
		{
			button.RootUIComp.Get().SetUIActive(!flag);
		}
		UUIButtonComponent button2 = base.GetButton(5);
		if (button2 != null)
		{
			button2.RootUIComp.Get().SetUIActive(!flag);
		}
		this.LevelSequence = new LevelSequencePlayer(base.GetItem(8));
		this.LevelSequence.PlayLevelSequenceByName("Progressing", false, null, false);
	}

	// Token: 0x06012267 RID: 74343 RVA: 0x004FDB1C File Offset: 0x004FBD1C
	protected bool GetTimeValid()
	{
		long lastSharedCheckTime = ModelBase<PhantomBattleModel>.Instance.GetPhantomConfigData().LastSharedCheckTime;
		double now = Singleton<Time>.Instance.Now;
		int phantomSharedCodeCd = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomSharedCodeCd();
		return now - (double)lastSharedCheckTime >= (double)(phantomSharedCodeCd * 1000);
	}

	// Token: 0x06012268 RID: 74344 RVA: 0x004FDB5E File Offset: 0x004FBD5E
	private void OnClickedSelfUpdate()
	{
		ControllerBase<PhantomBattleController>.Instance.RequestPhBaPlanUpdatePlan().ContinueWith(delegate(bool value)
		{
			if (!value)
			{
				return;
			}
			UUIItem item = base.GetItem(3);
			if (item != null)
			{
				item.SetUIActive(false);
			}
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("PhantomProject_ShareImport_Des_7", Array.Empty<object>());
			PhantomDiscardPlanShareReport logData = new PhantomDiscardPlanShareReport
			{
				i_type = 1,
				s_my_code = ModelBase<PhantomBattleModel>.Instance.GetPhantomConfigData().SelfPhantomConfigCode
			};
			ControllerBase<LogReportController>.Instance.LogReport(logData);
		}).Forget();
	}

	// Token: 0x06012269 RID: 74345 RVA: 0x004FDB80 File Offset: 0x004FBD80
	private void OnClickedShare()
	{
		PhantomManagerConfigData configData = ModelBase<PhantomBattleModel>.Instance.GetPhantomConfigData();
		string txtContext = StringUtils.Format(Singleton<PublicUtil>.Instance.GetConfigTextByKey("PhantomProject_ShareContent"), new string[]
		{
			ModelBase<FunctionModel>.Instance.GetPlayerName() ?? string.Empty,
			configData.SelfPhantomConfigCode
		});
		ControllerBase<LogReportController>.Instance.LogReport(new PhantomDiscardPlanShareReport
		{
			i_type = 2,
			s_my_code = configData.SelfPhantomConfigCode
		});
		if (!configData.PhantomSelfConfigNeedUpdate)
		{
			this.CopySuccess(txtContext);
			return;
		}
		if (!configData.ConfirmBoxLoginSet.Contains(EConfirmBoxConfigId.PhantomConfigCanUpdateSelf))
		{
			this.NeedUpdateLoginShowTmp = false;
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.PhantomConfigCanUpdateSelf);
			confirmBoxDataNew.HasToggle = true;
			confirmBoxDataNew.ToggleText = Singleton<PublicUtil>.Instance.GetConfigTextByKey("PhantomProject_CommonText");
			confirmBoxDataNew.IsEscViewTriggerCallBack = false;
			confirmBoxDataNew.SetToggleFunction(delegate(bool value)
			{
				this.NeedUpdateLoginShowTmp = value;
			});
			confirmBoxDataNew.FunctionMap[1] = delegate()
			{
				this.CopySuccess(txtContext);
				if (this.NeedUpdateLoginShowTmp)
				{
					configData.ConfirmBoxLoginSet.Add(EConfirmBoxConfigId.PhantomConfigCanUpdateSelf);
					configData.ConfigViewShareUpdateSelect = EPhantomManagerEditCloseState.Left;
				}
			};
			confirmBoxDataNew.FunctionMap[2] = delegate()
			{
				this.UpdateSelfAndReset();
				if (this.NeedUpdateLoginShowTmp)
				{
					configData.ConfirmBoxLoginSet.Add(EConfirmBoxConfigId.PhantomConfigCanUpdateSelf);
					configData.ConfigViewShareUpdateSelect = EPhantomManagerEditCloseState.Right;
				}
			};
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
			return;
		}
		if (configData.ConfigViewShareUpdateSelect == EPhantomManagerEditCloseState.Right)
		{
			this.UpdateSelfAndReset();
			return;
		}
		this.CopySuccess(txtContext);
	}

	// Token: 0x0601226A RID: 74346 RVA: 0x004FDCEB File Offset: 0x004FBEEB
	private void CopySuccess(string txt)
	{
		ULGUIBPLibrary.ClipBoardCopy(txt);
		ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("PhantomProject_ShareImport_Des_8", Array.Empty<object>());
	}

	// Token: 0x0601226B RID: 74347 RVA: 0x004FDD07 File Offset: 0x004FBF07
	private void UpdateSelfAndReset()
	{
		ControllerBase<PhantomBattleController>.Instance.RequestPhBaPlanUpdatePlan().ContinueWith(delegate(bool _)
		{
			UUIItem item = base.GetItem(3);
			if (item != null)
			{
				item.SetUIActive(false);
			}
			PhantomManagerConfigData phantomConfigData = ModelBase<PhantomBattleModel>.Instance.GetPhantomConfigData();
			string txt = StringUtils.Format(Singleton<PublicUtil>.Instance.GetConfigTextByKey("PhantomProject_ShareContent"), new string[]
			{
				ModelBase<FunctionModel>.Instance.GetPlayerName() ?? string.Empty,
				phantomConfigData.SelfPhantomConfigCode
			});
			this.CopySuccess(txt);
		}).Forget();
	}

	// Token: 0x0601226C RID: 74348 RVA: 0x004FDD2C File Offset: 0x004FBF2C
	private void OnClickedPaste()
	{
		if (Singleton<Platform>.Instance.IsCloudGame())
		{
			string pasteTarget = string.Empty;
			UKuroCloudGameWrapper.ClipBoardPaste();
			TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
			{
				ULGUIBPLibrary.ClipBoardPaste(ref pasteTarget);
				if (!StringUtils.IsEmpty(pasteTarget))
				{
					UUITextInputComponent inputText2 = this.GetInputText(4);
					if (inputText2 == null)
					{
						return;
					}
					inputText2.SetText(pasteTarget, true);
				}
			}, 200f, null, null, true, 1f);
			return;
		}
		string empty = string.Empty;
		ULGUIBPLibrary.ClipBoardPaste(ref empty);
		if (!StringUtils.IsEmpty(empty))
		{
			UUITextInputComponent inputText = base.GetInputText(4);
			if (inputText == null)
			{
				return;
			}
			inputText.SetText(empty, true);
		}
	}

	// Token: 0x0601226D RID: 74349 RVA: 0x004FDDB0 File Offset: 0x004FBFB0
	private void OnClickedImport()
	{
		if (!this.GetTimeValid())
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("PhantomProject_ShareImport_Des_14", Array.Empty<object>());
			return;
		}
		string code = base.GetInputText(4).GetText();
		if (!this.IsCodeValid(code))
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("PhantomProject_ShareImport_Des_13", Array.Empty<object>());
			return;
		}
		UUIButtonComponent button = base.GetButton(6);
		if (button != null)
		{
			button.RootUIComp.Get().SetUIActive(false);
		}
		UUIItem item = base.GetItem(7);
		if (item != null)
		{
			item.SetUIActive(true);
		}
		ControllerBase<PhantomBattleController>.Instance.RequestPhBaPlanFindPlan(code).ContinueWith(delegate(PhBaPlanFindPlanResponse response)
		{
			PhantomManagerConfigData configData = ModelBase<PhantomBattleModel>.Instance.GetPhantomConfigData();
			UUIButtonComponent button2 = this.GetButton(6);
			if (button2 != null)
			{
				button2.RootUIComp.Get().SetUIActive(true);
			}
			UUIItem item2 = this.GetItem(7);
			if (item2 != null)
			{
				item2.SetUIActive(false);
			}
			configData.LastSharedCheckTime = (long)Singleton<Time>.Instance.Now;
			if (response == null)
			{
				this.GetInputText(4).SetText(string.Empty, false);
				return;
			}
			ControllerBase<LogReportController>.Instance.LogReport(new PhantomDiscardPlanShareReport
			{
				i_type = 3,
				s_others_code = code
			});
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.PhantomConfigUsePlayerPlant);
			confirmBoxDataNew.SetTextArgs(new string[]
			{
				response.Plan.Name
			});
			confirmBoxDataNew.FunctionMap[2] = delegate()
			{
				configData.PhantomSelfConfigNeedUpdate = !response.TowPlanSame;
				List<int> fetterIdList = new List<int>();
				HashSet<int> hashSet = new HashSet<int>();
				foreach (PhantomFetterGroup phantomFetterGroup in ConfigBase<PhantomBattleConfig>.Instance.GetPhantomFetterGroupList())
				{
					fetterIdList.Add(phantomFetterGroup.Id);
					hashSet.Add(phantomFetterGroup.Id);
				}
				ModelBase<PhantomBattleModel>.Instance.CacheShareConfigData(response.Plan);
				ControllerBase<PhantomBattleController>.Instance.RequestPhBaPlanSaveUsePlan(false, hashSet).ContinueWith(delegate(bool value)
				{
					if (!value)
					{
						configData.DoCacheDataUpdate(false);
						return;
					}
					configData.DoLogReport(fetterIdList, false);
					ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("PhantomProject_ShareImport_Des_12", Array.Empty<object>());
					this.CloseMe(null);
					Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnPhantomConfigManagerDataUpdate, true);
				}).Forget();
			};
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
		}).Forget();
	}

	// Token: 0x0601226E RID: 74350 RVA: 0x004FDE78 File Offset: 0x004FC078
	private bool IsCodeValid(string code)
	{
		int phantomManagerShareCodeMax = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomManagerShareCodeMax();
		int phantomManagerShareCodeMin = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomManagerShareCodeMin();
		return code.Length >= phantomManagerShareCodeMin && code.Length <= phantomManagerShareCodeMax && StringUtils.CheckIsOnlyLettersAndNumbers(code);
	}

	// Token: 0x04008D9C RID: 36252
	[Nullable(2)]
	protected LevelSequencePlayer LevelSequence;

	// Token: 0x04008D9D RID: 36253
	private bool NeedUpdateLoginShowTmp;

	// Token: 0x020087A2 RID: 34722
	[NullableContext(0)]
	private enum EDefine
	{
		// Token: 0x0402DDA5 RID: 187813
		TxtCodeNum,
		// Token: 0x0402DDA6 RID: 187814
		BtnUpdate,
		// Token: 0x0402DDA7 RID: 187815
		BtnShare,
		// Token: 0x0402DDA8 RID: 187816
		PanelNeedUpdate,
		// Token: 0x0402DDA9 RID: 187817
		InputBox,
		// Token: 0x0402DDAA RID: 187818
		BtnInputPaste,
		// Token: 0x0402DDAB RID: 187819
		BtnImport,
		// Token: 0x0402DDAC RID: 187820
		PanelInProgress,
		// Token: 0x0402DDAD RID: 187821
		PanelInProgressAnim
	}
}
