using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.InputDevice;
using CSharpScript.Launcher.PlayerInput;
using CSharpScript.Launcher.Ui;
using CSharpScript.Launcher.Ui.HotFix;
using CSharpScript.Launcher.Update;
using CSharpScript.Launcher.Update.ResourceDiffUpdate;
using CSharpScript.Launcher.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Launcher.Action
{
	// Token: 0x02004A8D RID: 19085
	[NullableContext(1)]
	[Nullable(0)]
	public class HotFixDownSubPackageDownLoadMobileClearPopView : LaunchComponentsAction
	{
		// Token: 0x06031CAF RID: 203951 RVA: 0x00C77E9C File Offset: 0x00C7609C
		public UniTask OnInitTipsView()
		{
			HotFixDownSubPackageDownLoadMobileClearPopView.<OnInitTipsView>d__13 <OnInitTipsView>d__;
			<OnInitTipsView>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnInitTipsView>d__.<>4__this = this;
			<OnInitTipsView>d__.<>1__state = -1;
			<OnInitTipsView>d__.<>t__builder.Start<HotFixDownSubPackageDownLoadMobileClearPopView.<OnInitTipsView>d__13>(ref <OnInitTipsView>d__);
			return <OnInitTipsView>d__.<>t__builder.Task;
		}

		// Token: 0x06031CB0 RID: 203952 RVA: 0x00C77EE0 File Offset: 0x00C760E0
		protected override void OnStart()
		{
			base.AttachElement<HotFixBtnUiItem>(0).BindClickCallback(new Action(this.OnClickConfirmBtn));
			UUIButtonComponent button = base.GetButton(9);
			if (button != null)
			{
				button.OnClickCallBack.Bind(delegate()
				{
					Singleton<LauncherLog>.Instance.Info("HotFixDownSubPackageDownLoadMobileClearPopView CancelBtn", default(ReadOnlySpan<ValueTuple<string, object>>));
					base.SetActive(false);
					if (this.OnCloseCallBack != null)
					{
						this.OnCloseCallBack();
					}
					this.OnCloseCallBack = null;
				});
			}
			base.GetExtendToggle(1).RootUIComp.Get().SetUIActive(false);
			base.GetExtendToggle(1).OnStateChange.Add(delegate(EToggleState state)
			{
				LauncherLog instance = Singleton<LauncherLog>.Instance;
				string message = "HotFixDownSubPackageDownLoadMobileClearPopView AutoClearToggle";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("state:", state);
				instance.Info(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				HotFixManager.HandleAutoClear = (state == EToggleState.ETT_Checked);
			});
			UUILayoutBase layout = base.GetLayout(2);
			AUIBaseActor gridActor = base.GetItem(3).GetOwner() as AUIBaseActor;
			this.HotFixPackageLayout = new HotFixLayout<SubPackageDownLoadMobileClearItem, ISubPackageDownLoadMobileClearData>(layout, () => new SubPackageDownLoadMobileClearItem
			{
				OnClickToggleCallBack = new Action<int?, bool, EToggleState, string>(this.OnSelectSubItem),
				OnClickHelpBtnCallBack = new Action<int, UUIItem>(this.OnClickHelpBtn)
			}, gridActor);
			HotFixManager.SetLocalText(base.GetText(6), "HotFixSubPackageClearTipsTitle", Array.Empty<string>());
			HotFixManager.SetLocalText(base.GetText(7), "HotFixSubPackageClearTipsTitle_AutoClear", Array.Empty<string>());
		}

		// Token: 0x06031CB1 RID: 203953 RVA: 0x00C77FD4 File Offset: 0x00C761D4
		protected override void OnHide()
		{
			Singleton<HotPatchInputManager>.Instance.UnRegisterInputAction("手柄左摇杆上", new TInputAction(this.InputAction));
			Singleton<HotPatchInputManager>.Instance.UnRegisterInputAction("手柄左摇杆下", new TInputAction(this.InputAction));
			Singleton<HotPatchInputManager>.Instance.UnRegisterInputAction("手柄左边上键", new TInputAction(this.InputAction));
			Singleton<HotPatchInputManager>.Instance.UnRegisterInputAction("手柄左边下键", new TInputAction(this.InputAction));
			Singleton<HotPatchInputManager>.Instance.UnRegisterInputAction("手柄右边下键", new TInputAction(this.OnGamePadClick));
			Singleton<InputDevice>.Instance.UnRegisterInputChangeDelegate(new Action<CSharpScript.Launcher.InputDevice.EInputControllerType, CSharpScript.Launcher.InputDevice.EInputControllerType>(this.OnInputChange));
		}

		// Token: 0x06031CB2 RID: 203954 RVA: 0x00C78080 File Offset: 0x00C76280
		protected override void OnShow()
		{
			this.RefreshView();
			this.RefreshButton();
			Singleton<HotPatchInputManager>.Instance.RegisterInputAction("手柄左摇杆上", new TInputAction(this.InputAction));
			Singleton<HotPatchInputManager>.Instance.RegisterInputAction("手柄左摇杆下", new TInputAction(this.InputAction));
			Singleton<HotPatchInputManager>.Instance.RegisterInputAction("手柄左边上键", new TInputAction(this.InputAction));
			Singleton<HotPatchInputManager>.Instance.RegisterInputAction("手柄左边下键", new TInputAction(this.InputAction));
			Singleton<HotPatchInputManager>.Instance.RegisterInputAction("手柄右边下键", new TInputAction(this.OnGamePadClick));
			Singleton<InputDevice>.Instance.RegisterInputChangeDelegate(new Action<CSharpScript.Launcher.InputDevice.EInputControllerType, CSharpScript.Launcher.InputDevice.EInputControllerType>(this.OnInputChange));
		}

		// Token: 0x06031CB3 RID: 203955 RVA: 0x00C78138 File Offset: 0x00C76338
		private void OnClickConfirmBtn()
		{
			Singleton<LauncherLog>.Instance.Info("HotFixDownSubPackageDownLoadMobileClearPopView ConfirmBtn", default(ReadOnlySpan<ValueTuple<string, object>>));
			if (this.CurrentSelectInfoIdSet.Count > 0)
			{
				if (this.ShowConfirmBox != null)
				{
					this.ShowConfirmBox(delegate
					{
						HotFixManager.ClearSubPackage(new List<int>(this.CurrentSelectInfoIdSet), this.HaveSelectVideo);
						Singleton<ResourceDiffUpdaterManager>.Instance.UpdateDecision();
						if (this.SelectVoiceCodeSet.Count > 0)
						{
							foreach (string audioCode2 in this.SelectVoiceCodeSet)
							{
								Singleton<ResourceDiffUpdaterManager>.Instance.VoiceModule.DeleteByAudioCode(audioCode2);
							}
						}
						if (this.OnCloseCallBack != null)
						{
							this.OnCloseCallBack();
						}
					});
				}
			}
			else
			{
				if (this.HaveSelectVideo)
				{
					HotFixManager.ClearSubPackage(new List<int>(), this.HaveSelectVideo);
				}
				Singleton<ResourceDiffUpdaterManager>.Instance.UpdateDecision();
				if (this.SelectVoiceCodeSet.Count > 0)
				{
					foreach (string audioCode in this.SelectVoiceCodeSet)
					{
						Singleton<ResourceDiffUpdaterManager>.Instance.VoiceModule.DeleteByAudioCode(audioCode);
					}
				}
				if (this.OnCloseCallBack != null)
				{
					this.OnCloseCallBack();
				}
			}
			base.SetActive(false);
		}

		// Token: 0x06031CB4 RID: 203956 RVA: 0x00C7822C File Offset: 0x00C7642C
		private List<ISubPackageDownLoadMobileClearData> GetScrollViewDataList()
		{
			this.AllCanClearSpace = 0;
			this.AllCanSelectItemCount = 0;
			this.SelectIndex = 0;
			List<ISubPackageDownLoadMobileClearData> list = new List<ISubPackageDownLoadMobileClearData>();
			ISubPackageDownLoadMobileClearData subPackageDownLoadMobileClearData = new SubPackageDownLoadMobileClearData
			{
				TitleId = 3
			};
			subPackageDownLoadMobileClearData.HaveVideoCanClear = new bool?(this.GetPlotData());
			list.Add(subPackageDownLoadMobileClearData);
			this.AllCanSelectItemCount++;
			this.PlotAndSceneSplitIndex = this.AllCanSelectItemCount - 1;
			ISubPackageDownLoadMobileClearData subPackageDownLoadMobileClearData2 = new SubPackageDownLoadMobileClearData
			{
				TitleId = 2
			};
			subPackageDownLoadMobileClearData2.SceneIdList = this.GetSceneData();
			list.Add(subPackageDownLoadMobileClearData2);
			this.AllCanSelectItemCount++;
			this.SceneAndVoiceSplitIndex = this.AllCanSelectItemCount - 1;
			ISubPackageDownLoadMobileClearData subPackageDownLoadMobileClearData3 = new SubPackageDownLoadMobileClearData
			{
				TitleId = 5
			};
			subPackageDownLoadMobileClearData3.VoiceLanguageCodeList = this.GetVoiceData();
			list.Add(subPackageDownLoadMobileClearData3);
			this.AllCanSelectItemCount++;
			return list;
		}

		// Token: 0x06031CB5 RID: 203957 RVA: 0x00C78300 File Offset: 0x00C76500
		private List<int> GetSceneData()
		{
			List<int> list = new List<int>();
			foreach (int num in HotFixManager.GetCanCleanSceneIdList())
			{
				long subPackageSpace = HotFixManager.GetSubPackageSpace(num);
				if (subPackageSpace != 0L)
				{
					list.Add(num);
					this.AllCanSelectItemCount++;
					this.AllCanClearSpace += (int)subPackageSpace;
				}
			}
			if (list.Count <= 0)
			{
				list.Add(-1);
			}
			return list;
		}

		// Token: 0x06031CB6 RID: 203958 RVA: 0x00C78390 File Offset: 0x00C76590
		private bool GetPlotData()
		{
			int num = (int)HotFixManager.GetCanCleanVideoSpace();
			this.AllCanClearSpace += num;
			if (num > 0)
			{
				this.AllCanSelectItemCount++;
			}
			return num > 0;
		}

		// Token: 0x06031CB7 RID: 203959 RVA: 0x00C783C8 File Offset: 0x00C765C8
		private List<string> GetVoiceData()
		{
			List<string> list = new List<string>();
			string packageAudioLanguage = Singleton<LauncherLanguageLib>.Instance.GetPackageAudioLanguage();
			IEnumerable<LaunchLangDefine> allLanguageDefines = Singleton<LauncherLanguageLib>.Instance.GetAllLanguageDefines();
			HashSet<string> hashSet = new HashSet<string>();
			foreach (LaunchLangDefine launchLangDefine in allLanguageDefines)
			{
				string audioCode = launchLangDefine.AudioCode;
				if (!hashSet.Contains(audioCode))
				{
					hashSet.Add(audioCode);
					if (!(audioCode == packageAudioLanguage))
					{
						LanguageUpdater updater = Singleton<LanguageUpdateManager>.Instance.GetUpdater(audioCode);
						if (updater != null && updater.Status == ELanguageDownloadStatus.Done && Singleton<ResourceDiffUpdaterManager>.Instance.VoiceModule.GetLocalSizeByAudioCode(audioCode) > 0L)
						{
							list.Add(audioCode);
							this.AllCanSelectItemCount++;
							this.AllCanClearSpace += (int)updater.TotalDiskSize;
						}
					}
				}
			}
			if (list.Count <= 0)
			{
				list.Add("");
			}
			return list;
		}

		// Token: 0x06031CB8 RID: 203960 RVA: 0x00C784C4 File Offset: 0x00C766C4
		private void RefreshView()
		{
			HotFixLayout<SubPackageDownLoadMobileClearItem, ISubPackageDownLoadMobileClearData> hotFixPackageLayout = this.HotFixPackageLayout;
			if (hotFixPackageLayout != null)
			{
				hotFixPackageLayout.RefreshByData(this.GetScrollViewDataList());
			}
			HotFixLayout<SubPackageDownLoadMobileClearItem, ISubPackageDownLoadMobileClearData> hotFixPackageLayout2 = this.HotFixPackageLayout;
			SubPackageDownLoadMobileClearItem subPackageDownLoadMobileClearItem = ((hotFixPackageLayout2 != null) ? hotFixPackageLayout2.GetLayoutItemByIndex(0) : null) as SubPackageDownLoadMobileClearItem;
			if (Singleton<InputDevice>.Instance.IsInGamepad())
			{
				if (subPackageDownLoadMobileClearItem != null)
				{
					subPackageDownLoadMobileClearItem.SelectItem(0);
				}
			}
			else if (subPackageDownLoadMobileClearItem != null)
			{
				subPackageDownLoadMobileClearItem.UnSelectItem();
			}
			HotFixLayout<SubPackageDownLoadMobileClearItem, ISubPackageDownLoadMobileClearData> hotFixPackageLayout3 = this.HotFixPackageLayout;
			SubPackageDownLoadMobileClearItem subPackageDownLoadMobileClearItem2 = ((hotFixPackageLayout3 != null) ? hotFixPackageLayout3.GetLayoutItemByIndex(1) : null) as SubPackageDownLoadMobileClearItem;
			if (subPackageDownLoadMobileClearItem2 != null)
			{
				subPackageDownLoadMobileClearItem2.UnSelectItem();
			}
			HotFixLayout<SubPackageDownLoadMobileClearItem, ISubPackageDownLoadMobileClearData> hotFixPackageLayout4 = this.HotFixPackageLayout;
			SubPackageDownLoadMobileClearItem subPackageDownLoadMobileClearItem3 = ((hotFixPackageLayout4 != null) ? hotFixPackageLayout4.GetLayoutItemByIndex(2) : null) as SubPackageDownLoadMobileClearItem;
			if (subPackageDownLoadMobileClearItem3 == null)
			{
				return;
			}
			subPackageDownLoadMobileClearItem3.UnSelectItem();
		}

		// Token: 0x06031CB9 RID: 203961 RVA: 0x00C78568 File Offset: 0x00C76768
		[NullableContext(2)]
		private void OnSelectSubItem(int? sceneId, bool isVideo, EToggleState state, string voiceCode = null)
		{
			if (state == EToggleState.ETT_Checked)
			{
				if (sceneId != null)
				{
					this.CurrentSelectInfoIdSet.Add(sceneId.Value);
				}
				else if (isVideo)
				{
					this.HaveSelectVideo = true;
				}
				else if (voiceCode != null)
				{
					this.SelectVoiceCodeSet.Add(voiceCode);
				}
			}
			else if (sceneId != null)
			{
				this.CurrentSelectInfoIdSet.Remove(sceneId.Value);
			}
			else if (isVideo)
			{
				this.HaveSelectVideo = false;
			}
			else if (voiceCode != null)
			{
				this.SelectVoiceCodeSet.Remove(voiceCode);
			}
			this.RefreshButton();
		}

		// Token: 0x06031CBA RID: 203962 RVA: 0x00C785FC File Offset: 0x00C767FC
		private void RefreshButton()
		{
			base.GetButton(0).SetSelfInteractive(this.CurrentSelectInfoIdSet.Count > 0 || this.HaveSelectVideo || this.SelectVoiceCodeSet.Count > 0);
			int num = this.HaveSelectVideo ? ((int)HotFixManager.GetCanCleanVideoSpace()) : 0;
			foreach (int packId in this.CurrentSelectInfoIdSet)
			{
				num += (int)HotFixManager.GetSubPackageSpace(packId);
			}
			foreach (string audioCode in this.SelectVoiceCodeSet)
			{
				long localSizeByAudioCode = Singleton<ResourceDiffUpdaterManager>.Instance.VoiceModule.GetLocalSizeByAudioCode(audioCode);
				num += (int)localSizeByAudioCode;
			}
			HotFixManager.SetLocalText(base.GetText(5), "HotFixSubPackageClearButton", new string[]
			{
				HotFixManager.ByteConverter((long)num),
				HotFixManager.ByteConverter((long)this.AllCanClearSpace)
			});
		}

		// Token: 0x06031CBB RID: 203963 RVA: 0x00C7871C File Offset: 0x00C7691C
		private void OnClickHelpBtn(int type, UUIItem item)
		{
			HotFixSubPackageDownLoadVersionTipsView versionTipsView = this.VersionTipsView;
			bool flag;
			if (versionTipsView == null)
			{
				flag = false;
			}
			else
			{
				UUIItem rootItem = versionTipsView.GetRootItem();
				flag = ((rootItem != null) ? new bool?(rootItem.IsUIActiveSelf()) : null).GetValueOrDefault();
			}
			if (flag)
			{
				return;
			}
			HotFixSubPackageDownLoadVersionTipsView versionTipsView2 = this.VersionTipsView;
			if (versionTipsView2 != null)
			{
				FVectorDouble fvectorDouble = item.D_K2_GetComponentLocation();
				versionTipsView2.RefreshItemByClearType(type, fvectorDouble);
			}
			HotFixSubPackageDownLoadVersionTipsView versionTipsView3 = this.VersionTipsView;
			if (versionTipsView3 == null)
			{
				return;
			}
			versionTipsView3.SetActive(true);
		}

		// Token: 0x06031CBC RID: 203964 RVA: 0x00C78790 File Offset: 0x00C76990
		private void InputAction(bool bPress, string actionName)
		{
			if (!bPress)
			{
				return;
			}
			if ("手柄左边上键" == actionName || "手柄左摇杆上" == actionName)
			{
				this.FocusPrev();
			}
			if ("手柄左边下键" == actionName || "手柄左摇杆下" == actionName)
			{
				this.FocusNext();
			}
		}

		// Token: 0x06031CBD RID: 203965 RVA: 0x00C787E1 File Offset: 0x00C769E1
		private void FocusPrev()
		{
			this.SelectCanSelectIndex(Math.Max(0, this.SelectIndex - 1));
		}

		// Token: 0x06031CBE RID: 203966 RVA: 0x00C787F7 File Offset: 0x00C769F7
		private void FocusNext()
		{
			this.SelectCanSelectIndex(Math.Min(this.AllCanSelectItemCount - 1, this.SelectIndex + 1));
		}

		// Token: 0x06031CBF RID: 203967 RVA: 0x00C78814 File Offset: 0x00C76A14
		private int GetLayoutIndex(int selectIndex)
		{
			if (selectIndex <= this.PlotAndSceneSplitIndex)
			{
				return 0;
			}
			if (selectIndex <= this.SceneAndVoiceSplitIndex)
			{
				return 1;
			}
			return 2;
		}

		// Token: 0x06031CC0 RID: 203968 RVA: 0x00C7882D File Offset: 0x00C76A2D
		private int GetSubIndex(int selectIndex)
		{
			if (selectIndex <= this.PlotAndSceneSplitIndex)
			{
				return selectIndex;
			}
			if (selectIndex <= this.SceneAndVoiceSplitIndex)
			{
				return selectIndex - (this.PlotAndSceneSplitIndex + 1);
			}
			return selectIndex - (this.SceneAndVoiceSplitIndex + 1);
		}

		// Token: 0x06031CC1 RID: 203969 RVA: 0x00C78858 File Offset: 0x00C76A58
		private unsafe void SelectCanSelectIndex(int index)
		{
			if (this.SelectIndex == index)
			{
				return;
			}
			if (this.SelectIndex >= 0)
			{
				HotFixLayout<SubPackageDownLoadMobileClearItem, ISubPackageDownLoadMobileClearData> hotFixPackageLayout = this.HotFixPackageLayout;
				SubPackageDownLoadMobileClearItem subPackageDownLoadMobileClearItem = ((hotFixPackageLayout != null) ? hotFixPackageLayout.GetLayoutItemByIndex(this.GetLayoutIndex(this.SelectIndex)) : null) as SubPackageDownLoadMobileClearItem;
				if (subPackageDownLoadMobileClearItem != null)
				{
					subPackageDownLoadMobileClearItem.UnSelectItem();
				}
			}
			LauncherLog instance = Singleton<LauncherLog>.Instance;
			string message = "HotFixDownSubPackageDownLoadMobileClearPopView SelectCanSelectIndex";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("this.SelectIndex", this.SelectIndex);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("newIndex", index);
			instance.Info(message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			this.SelectIndex = index;
			HotFixLayout<SubPackageDownLoadMobileClearItem, ISubPackageDownLoadMobileClearData> hotFixPackageLayout2 = this.HotFixPackageLayout;
			SubPackageDownLoadMobileClearItem subPackageDownLoadMobileClearItem2 = ((hotFixPackageLayout2 != null) ? hotFixPackageLayout2.GetLayoutItemByIndex(this.GetLayoutIndex(this.SelectIndex)) : null) as SubPackageDownLoadMobileClearItem;
			if (subPackageDownLoadMobileClearItem2 != null)
			{
				subPackageDownLoadMobileClearItem2.SelectItem(this.GetSubIndex(this.SelectIndex));
			}
			float inValue = (this.AllCanSelectItemCount > 0) ? ((float)this.SelectIndex / (float)(this.AllCanSelectItemCount - 1)) : 0f;
			UUIScrollbarComponent uiScrollbarComponent = base.GetUiScrollbarComponent(10);
			if (uiScrollbarComponent == null)
			{
				return;
			}
			uiScrollbarComponent.SetValue(inValue, true);
		}

		// Token: 0x06031CC2 RID: 203970 RVA: 0x00C7897C File Offset: 0x00C76B7C
		private void OnGamePadClick(bool bPress, string actionName)
		{
			if (bPress)
			{
				HotFixSubPackageDownLoadVersionTipsView versionTipsView = this.VersionTipsView;
				bool flag;
				if (versionTipsView == null)
				{
					flag = false;
				}
				else
				{
					UUIItem rootItem = versionTipsView.GetRootItem();
					flag = ((rootItem != null) ? new bool?(rootItem.IsUIActiveSelf()) : null).GetValueOrDefault();
				}
				if (!flag)
				{
					HotFixLayout<SubPackageDownLoadMobileClearItem, ISubPackageDownLoadMobileClearData> hotFixPackageLayout = this.HotFixPackageLayout;
					SubPackageDownLoadMobileClearItem subPackageDownLoadMobileClearItem = ((hotFixPackageLayout != null) ? hotFixPackageLayout.GetLayoutItemByIndex(this.GetLayoutIndex(this.SelectIndex)) : null) as SubPackageDownLoadMobileClearItem;
					if (subPackageDownLoadMobileClearItem == null)
					{
						return;
					}
					subPackageDownLoadMobileClearItem.OnClickItem(this.GetSubIndex(this.SelectIndex));
					return;
				}
			}
		}

		// Token: 0x06031CC3 RID: 203971 RVA: 0x00C789FC File Offset: 0x00C76BFC
		private void OnInputChange(CSharpScript.Launcher.InputDevice.EInputControllerType oldControllerType, CSharpScript.Launcher.InputDevice.EInputControllerType newControllerType)
		{
			if (Singleton<InputDevice>.Instance.IsInGamepad())
			{
				HotFixLayout<SubPackageDownLoadMobileClearItem, ISubPackageDownLoadMobileClearData> hotFixPackageLayout = this.HotFixPackageLayout;
				SubPackageDownLoadMobileClearItem subPackageDownLoadMobileClearItem = ((hotFixPackageLayout != null) ? hotFixPackageLayout.GetLayoutItemByIndex(0) : null) as SubPackageDownLoadMobileClearItem;
				if (subPackageDownLoadMobileClearItem != null)
				{
					subPackageDownLoadMobileClearItem.SelectItem(0);
				}
				HotFixLayout<SubPackageDownLoadMobileClearItem, ISubPackageDownLoadMobileClearData> hotFixPackageLayout2 = this.HotFixPackageLayout;
				SubPackageDownLoadMobileClearItem subPackageDownLoadMobileClearItem2 = ((hotFixPackageLayout2 != null) ? hotFixPackageLayout2.GetLayoutItemByIndex(1) : null) as SubPackageDownLoadMobileClearItem;
				if (subPackageDownLoadMobileClearItem2 != null)
				{
					subPackageDownLoadMobileClearItem2.UnSelectItem();
				}
				HotFixLayout<SubPackageDownLoadMobileClearItem, ISubPackageDownLoadMobileClearData> hotFixPackageLayout3 = this.HotFixPackageLayout;
				SubPackageDownLoadMobileClearItem subPackageDownLoadMobileClearItem3 = ((hotFixPackageLayout3 != null) ? hotFixPackageLayout3.GetLayoutItemByIndex(2) : null) as SubPackageDownLoadMobileClearItem;
				if (subPackageDownLoadMobileClearItem3 != null)
				{
					subPackageDownLoadMobileClearItem3.UnSelectItem();
				}
				this.SelectIndex = 0;
				return;
			}
			HotFixLayout<SubPackageDownLoadMobileClearItem, ISubPackageDownLoadMobileClearData> hotFixPackageLayout4 = this.HotFixPackageLayout;
			SubPackageDownLoadMobileClearItem subPackageDownLoadMobileClearItem4 = ((hotFixPackageLayout4 != null) ? hotFixPackageLayout4.GetLayoutItemByIndex(0) : null) as SubPackageDownLoadMobileClearItem;
			if (subPackageDownLoadMobileClearItem4 != null)
			{
				subPackageDownLoadMobileClearItem4.UnSelectItem();
			}
			HotFixLayout<SubPackageDownLoadMobileClearItem, ISubPackageDownLoadMobileClearData> hotFixPackageLayout5 = this.HotFixPackageLayout;
			SubPackageDownLoadMobileClearItem subPackageDownLoadMobileClearItem5 = ((hotFixPackageLayout5 != null) ? hotFixPackageLayout5.GetLayoutItemByIndex(1) : null) as SubPackageDownLoadMobileClearItem;
			if (subPackageDownLoadMobileClearItem5 != null)
			{
				subPackageDownLoadMobileClearItem5.UnSelectItem();
			}
			HotFixLayout<SubPackageDownLoadMobileClearItem, ISubPackageDownLoadMobileClearData> hotFixPackageLayout6 = this.HotFixPackageLayout;
			SubPackageDownLoadMobileClearItem subPackageDownLoadMobileClearItem6 = ((hotFixPackageLayout6 != null) ? hotFixPackageLayout6.GetLayoutItemByIndex(2) : null) as SubPackageDownLoadMobileClearItem;
			if (subPackageDownLoadMobileClearItem6 == null)
			{
				return;
			}
			subPackageDownLoadMobileClearItem6.UnSelectItem();
		}

		// Token: 0x0401D287 RID: 119431
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private HotFixLayout<SubPackageDownLoadMobileClearItem, ISubPackageDownLoadMobileClearData> HotFixPackageLayout;

		// Token: 0x0401D288 RID: 119432
		private readonly HashSet<int> CurrentSelectInfoIdSet = new HashSet<int>();

		// Token: 0x0401D289 RID: 119433
		private bool HaveSelectVideo;

		// Token: 0x0401D28A RID: 119434
		private readonly HashSet<string> SelectVoiceCodeSet = new HashSet<string>();

		// Token: 0x0401D28B RID: 119435
		[Nullable(2)]
		private HotFixSubPackageDownLoadVersionTipsView VersionTipsView;

		// Token: 0x0401D28C RID: 119436
		private int AllCanClearSpace;

		// Token: 0x0401D28D RID: 119437
		[Nullable(2)]
		public Action OnCloseCallBack;

		// Token: 0x0401D28E RID: 119438
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Action<Action> ShowConfirmBox;

		// Token: 0x0401D28F RID: 119439
		private int SelectIndex;

		// Token: 0x0401D290 RID: 119440
		private int AllCanSelectItemCount;

		// Token: 0x0401D291 RID: 119441
		private int PlotAndSceneSplitIndex;

		// Token: 0x0401D292 RID: 119442
		private int SceneAndVoiceSplitIndex;

		// Token: 0x0200AAF3 RID: 43763
		[NullableContext(0)]
		private class EComponentDefine
		{
			// Token: 0x0403534F RID: 217935
			public const int ConfirmBtn = 0;

			// Token: 0x04035350 RID: 217936
			public const int AutoClearToggle = 1;

			// Token: 0x04035351 RID: 217937
			public const int ScrollLayout = 2;

			// Token: 0x04035352 RID: 217938
			public const int ScrollItem = 3;

			// Token: 0x04035353 RID: 217939
			public const int ConfirmBoxText = 5;

			// Token: 0x04035354 RID: 217940
			public const int TitleText = 6;

			// Token: 0x04035355 RID: 217941
			public const int AutoClearText = 7;

			// Token: 0x04035356 RID: 217942
			public const int CloseBtn = 9;

			// Token: 0x04035357 RID: 217943
			public const int ScrollBar = 10;

			// Token: 0x04035358 RID: 217944
			public const int ClearSubPackageTipsPop = 100;
		}
	}
}
