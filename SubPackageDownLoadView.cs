using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.ResManager;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using CSharpScript.Launcher.DiffPatch.Update;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002AB8 RID: 10936
[NullableContext(1)]
[Nullable(0)]
public class SubPackageDownLoadView : UiViewBase
{
	// Token: 0x06015E0E RID: 89614 RVA: 0x00613245 File Offset: 0x00611445
	public SubPackageDownLoadView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06015E0F RID: 89615 RVA: 0x00613270 File Offset: 0x00611470
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUITexture)),
			new ValueTuple<int, Type>(2, typeof(UUIVerticalLayout)),
			new ValueTuple<int, Type>(3, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(4, typeof(UUIDynScrollViewComponent)),
			new ValueTuple<int, Type>(5, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(6, typeof(UUIText)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIItem)),
			new ValueTuple<int, Type>(9, typeof(UUIText)),
			new ValueTuple<int, Type>(10, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(5, new Action(this.OnStartBtnClick)),
			new ValueTuple<int, Delegate>(3, new Action<EToggleState>(this.OnClickMobileDataToggle))
		};
	}

	// Token: 0x06015E10 RID: 89616 RVA: 0x006133B8 File Offset: 0x006115B8
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnRefreshSubPackDownLoadState, new Action(this.OnRefreshSubPackDownLoadState));
		Singleton<EventSystem>.Instance.Add(EEventName.OnRefreshSubPackageDownLoadByPriority, new Action(this.OnRefreshSubPackageDownLoadByPriority));
		Singleton<EventSystem>.Instance.Add(EEventName.OnRefreshSubPackUseCellData, new Action(this.OnRefreshSubPackUseCellData));
	}

	// Token: 0x06015E11 RID: 89617 RVA: 0x0061341C File Offset: 0x0061161C
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnRefreshSubPackageDownLoadByPriority, new Action(this.OnRefreshSubPackageDownLoadByPriority));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnRefreshSubPackDownLoadState, new Action(this.OnRefreshSubPackDownLoadState));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnRefreshSubPackUseCellData, new Action(this.OnRefreshSubPackUseCellData));
	}

	// Token: 0x06015E12 RID: 89618 RVA: 0x00613480 File Offset: 0x00611680
	protected override UniTask OnBeforeStartAsync()
	{
		SubPackageDownLoadView.<OnBeforeStartAsync>d__20 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<SubPackageDownLoadView.<OnBeforeStartAsync>d__20>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06015E13 RID: 89619 RVA: 0x006134C4 File Offset: 0x006116C4
	protected override void OnStart()
	{
		ModelBase<SubPackageDownLoadModel>.Instance.UpdaterDownLoadSize();
		ModelBase<SubPackageDownLoadModel>.Instance.UpdaterFinishState();
		ControllerBase<ResourceManagerController>.Instance.ChangeHttpTickFrequency();
		bool player = LocalStorage.GetPlayer<bool>(ELocalStoragePlayerKey.SubDownLoadAgreeUseCellData, false);
		base.GetExtendToggle(3).SetToggleState(player ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
		SubPackageDownLoadViewOpenData param = this.OpenParam as SubPackageDownLoadViewOpenData;
		List<int> subPackageList = new List<int>();
		SubPackageDownLoadViewOpenData param2 = param;
		if (((param2 != null) ? param2.SubPackageIdList : null) != null)
		{
			for (int i = 0; i < param.SubPackageIdList.Length; i++)
			{
				int num = param.SubPackageIdList[i];
				if (num != 0)
				{
					subPackageList.Add(num);
				}
			}
		}
		List<int> data = new List<int>
		{
			0,
			1
		};
		GenericLayout<SubPackageTab, int> tabScrollview = this.TabScrollview;
		if (tabScrollview != null)
		{
			tabScrollview.RefreshByData(data, delegate
			{
				if (param != null && subPackageList.Count > 0)
				{
					for (int j = 0; j < subPackageList.Count; j++)
					{
						int num3 = subPackageList[j];
						if (num3 != 0)
						{
							DownLoadSubPackage? downLoadSubPackageById = ConfigBase<SubPackageConfig>.Instance.GetDownLoadSubPackageById(num3);
							if (downLoadSubPackageById != null && downLoadSubPackageById.Value.Type == 4)
							{
								GenericLayout<SubPackageTab, int> tabScrollview2 = this.TabScrollview;
								if (tabScrollview2 == null)
								{
									return;
								}
								SubPackageTab layoutItemByIndex = tabScrollview2.GetLayoutItemByIndex(1);
								if (layoutItemByIndex == null)
								{
									return;
								}
								layoutItemByIndex.SelectToggle();
								return;
							}
						}
					}
				}
				GenericLayout<SubPackageTab, int> tabScrollview3 = this.TabScrollview;
				if (tabScrollview3 == null)
				{
					return;
				}
				SubPackageTab layoutItemByIndex2 = tabScrollview3.GetLayoutItemByIndex(0);
				if (layoutItemByIndex2 == null)
				{
					return;
				}
				layoutItemByIndex2.SelectToggle();
			}, false);
		}
		string logoPathByLanguage = ConfigBase<UiResourceConfig>.Instance.GetLogoPathByLanguage("LoginLogo");
		base.SetTextureByPath(logoPathByLanguage, base.GetTexture(1), null, null);
		if (ModelBase<SubPackageDownLoadModel>.Instance.IsKeyPackageDownLoadingNone())
		{
			ControllerBase<SubPackageController>.Instance.AutoDownLoadKeySubPackage();
		}
		else if (ModelBase<SubPackageDownLoadModel>.Instance.IsKeyPackageDownLoadingFinish() && subPackageList.Count > 0)
		{
			ControllerBase<SubPackageController>.Instance.PrioritySubPackageDownLoading(subPackageList, null).Forget();
		}
		this.TimerHandle = TimerSystem.GameplayTimeInstance.Forever(delegate(float _)
		{
			this.RefreshDownLoadState();
		}, (float)Singleton<TimeUtil>.Instance.InverseMillisecond, 1f, null, null, true);
		if (param != null)
		{
			PopupCaptionItem captionItem = this.CaptionItem;
			if (captionItem != null)
			{
				captionItem.SetCloseBtnActive(param.IsShowCloseBtn);
			}
			base.GetButton(5).RootUIComp.Get().SetUIActive(!param.IsShowCloseBtn);
			base.GetText(9).SetUIActive(!param.IsShowCloseBtn);
		}
		else
		{
			PopupCaptionItem captionItem2 = this.CaptionItem;
			if (captionItem2 != null)
			{
				captionItem2.SetCloseBtnActive(true);
			}
			base.GetButton(5).RootUIComp.Get().SetUIActive(false);
			base.GetText(9).SetUIActive(false);
		}
		this.RefreshFreeSpace();
		this.RefreshStartBtn();
		ValueTuple<bool, List<int>> valueTuple = ModelBase<SubPackageDownLoadModel>.Instance.CheckGuideQuestNeedDownLoad();
		bool item = valueTuple.Item1;
		List<int> notFinishedList = valueTuple.Item2;
		if (item)
		{
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.SubPackageRecommendConfirm);
			long num2 = 0L;
			foreach (int id in notFinishedList)
			{
				num2 += ModelBase<SubPackageDownLoadModel>.Instance.GetSubPackageSpace(id);
			}
			confirmBoxDataNew.SetTextArgs(new string[]
			{
				ModelBase<SubPackageDownLoadModel>.Instance.ByteConverter(num2)
			});
			confirmBoxDataNew.FunctionMap.Add(2, delegate
			{
				ControllerBase<SubPackageController>.Instance.PrioritySubPackageDownLoading(notFinishedList, null).Forget();
			});
			ControllerBase<ConfirmBoxController>.Instance.ShowNetWorkConfirmBoxView(confirmBoxDataNew, null);
		}
		this.AniPlay(SubPackageDownLoadView.StartTag);
	}

	// Token: 0x06015E14 RID: 89620 RVA: 0x006137E4 File Offset: 0x006119E4
	private void RefreshDownLoadState()
	{
		for (int i = 0; i < this.SubPackageDownLoadItemList.Count; i++)
		{
			this.SubPackageDownLoadItemList[i].RefreshDownLoadState();
		}
	}

	// Token: 0x06015E15 RID: 89621 RVA: 0x00613818 File Offset: 0x00611A18
	private void RefreshFreeSpace()
	{
		long freeSpace = Singleton<VideoResUpdate>.Instance.GetFreeSpace();
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(6), "SubPackageDownLoad_FreeSpace", new <>z__ReadOnlySingleElementList<object>(ModelBase<SubPackageDownLoadModel>.Instance.ByteConverter(freeSpace)));
	}

	// Token: 0x06015E16 RID: 89622 RVA: 0x00613856 File Offset: 0x00611A56
	protected override void OnBeforeHide()
	{
		this.AniPlay(SubPackageDownLoadView.CloseTag);
	}

	// Token: 0x06015E17 RID: 89623 RVA: 0x00613863 File Offset: 0x00611A63
	protected override void OnBeforeDestroy()
	{
		LevelSequencePlayer.SetBanned(this.LevelSequenceBannadHandle);
		ControllerBase<ResourceManagerController>.Instance.RestoreHttpTickFrequency();
		if (this.TimerHandle != null)
		{
			TimerSystem.GameplayTimeInstance.Remove(this.TimerHandle);
			this.TimerHandle = null;
		}
	}

	// Token: 0x06015E18 RID: 89624 RVA: 0x0061389C File Offset: 0x00611A9C
	private SubPackageDownLoadItem CreateNodeGrid(SubPackageDownLoadDynamicData data, UUIItem uiItem, int index)
	{
		SubPackageDownLoadItem subPackageDownLoadItem = new SubPackageDownLoadItem();
		subPackageDownLoadItem.OnClickCallBack = new Action<int, bool>(this.OnClickSubPackageDownLoadVersionCallBack);
		subPackageDownLoadItem.OnClickHelpBtnCallBack = new Action<int, UUIItem>(this.OnClickSubPackageDownLoadVersionTipsCallBack);
		subPackageDownLoadItem.OnClickBtnCallBack = new Action<SubPackageDownLoadDynamicData>(this.OnClickChileItemBtn);
		this.SubPackageDownLoadItemList.Add(subPackageDownLoadItem);
		return subPackageDownLoadItem;
	}

	// Token: 0x06015E19 RID: 89625 RVA: 0x006138F2 File Offset: 0x00611AF2
	private SubPackageTab InitTabItem()
	{
		return new SubPackageTab
		{
			OnClickCallBack = new Action<UUIExtendToggle, int>(this.OnClickTabCallBack)
		};
	}

	// Token: 0x06015E1A RID: 89626 RVA: 0x0061390C File Offset: 0x00611B0C
	private void OnClickSubPackageDownLoadVersionCallBack(int versionId, bool isShowSubItem)
	{
		List<SubPackageDownLoadDynamicData> list = (this.CurrentTabType == 0) ? this.KeySubPackageDataList : this.ExpendSubPackageDataList;
		if (isShowSubItem)
		{
			int num = -1;
			for (int i = 0; i < list.Count; i++)
			{
				int? versionId2 = list[i].VersionId;
				int versionId3 = versionId;
				if (versionId2.GetValueOrDefault() == versionId3 & versionId2 != null)
				{
					num = i;
					break;
				}
			}
			if (num < 0)
			{
				return;
			}
			list[num].IsShowItem = true;
			IReadOnlyList<DownLoadSubPackage> readOnlyList = ConfigBase<SubPackageConfig>.Instance.GetDownLoadSubPackageListByVersion(versionId) ?? new List<DownLoadSubPackage>();
			List<SubPackageDownLoadDynamicData> list2 = new List<SubPackageDownLoadDynamicData>();
			for (int j = 0; j < readOnlyList.Count; j++)
			{
				list2.Add(new SubPackageDownLoadDynamicData
				{
					SubPackageId = new int?(readOnlyList[j].Id)
				});
			}
			list2.Sort(new Comparison<SubPackageDownLoadDynamicData>(this.SortSubPackage));
			list.InsertRange(num + 1, list2);
		}
		else
		{
			for (int k = 0; k < list.Count; k++)
			{
				int? versionId2 = list[k].VersionId;
				int versionId3 = versionId;
				if (versionId2.GetValueOrDefault() == versionId3 & versionId2 != null)
				{
					list[k].IsShowItem = false;
				}
				int? subPackageId = list[k].SubPackageId;
				if (subPackageId != null && subPackageId.Value != 0)
				{
					DownLoadSubPackage? downLoadSubPackageById = ConfigBase<SubPackageConfig>.Instance.GetDownLoadSubPackageById(subPackageId.Value);
					if (downLoadSubPackageById != null && downLoadSubPackageById.Value.Version == versionId)
					{
						list.RemoveAt(k);
						k--;
					}
				}
			}
		}
		DynamicScrollView<SubPackageDownLoadItem, SubPackageDownLoadDynamicItem, SubPackageDownLoadDynamicData> subPackageDownLoadScrollView = this.SubPackageDownLoadScrollView;
		if (subPackageDownLoadScrollView != null)
		{
			subPackageDownLoadScrollView.RefreshByData(list.ToArray(), true, true);
		}
		DynamicScrollView<SubPackageDownLoadItem, SubPackageDownLoadDynamicItem, SubPackageDownLoadDynamicData> subPackageDownLoadScrollView2 = this.SubPackageDownLoadScrollView;
		if (subPackageDownLoadScrollView2 == null)
		{
			return;
		}
		subPackageDownLoadScrollView2.BindLateUpdate(delegate(float _)
		{
			for (int l = 0; l < this.SubPackageDownLoadItemList.Count; l++)
			{
				SubPackageDownLoadItem subPackageDownLoadItem = this.SubPackageDownLoadItemList[l];
				SubPackageDownLoadDynamicData data = subPackageDownLoadItem.GetData();
				bool flag;
				if (data == null)
				{
					flag = false;
				}
				else
				{
					int? versionId4 = data.VersionId;
					int versionId5 = versionId;
					flag = (versionId4.GetValueOrDefault() == versionId5 & versionId4 != null);
				}
				if (flag)
				{
					ControllerBase<UiNavigationNewController>.Instance.SetNavigationFocusForView(subPackageDownLoadItem.GetInteractItem(), true, true, false);
					break;
				}
			}
			DynamicScrollView<SubPackageDownLoadItem, SubPackageDownLoadDynamicItem, SubPackageDownLoadDynamicData> subPackageDownLoadScrollView3 = this.SubPackageDownLoadScrollView;
			if (subPackageDownLoadScrollView3 == null)
			{
				return;
			}
			subPackageDownLoadScrollView3.UnBindLateUpdate();
		});
	}

	// Token: 0x06015E1B RID: 89627 RVA: 0x00613B18 File Offset: 0x00611D18
	private void OnRefreshSubPackageDownLoadByPriority()
	{
		List<SubPackageDownLoadDynamicData> list = new List<SubPackageDownLoadDynamicData>();
		List<SubPackageDownLoadDynamicData> list2 = (this.CurrentTabType == 0) ? this.KeySubPackageDataList : this.ExpendSubPackageDataList;
		for (int i = 0; i < list2.Count; i++)
		{
			SubPackageDownLoadDynamicData subPackageDownLoadDynamicData = list2[i];
			if (subPackageDownLoadDynamicData.SubPackageId == null || subPackageDownLoadDynamicData.SubPackageId.Value == 0)
			{
				list.Add(subPackageDownLoadDynamicData);
				if (subPackageDownLoadDynamicData.IsShowItem)
				{
					IReadOnlyList<DownLoadSubPackage> readOnlyList = ConfigBase<SubPackageConfig>.Instance.GetDownLoadSubPackageListByVersion(subPackageDownLoadDynamicData.VersionId.Value) ?? new List<DownLoadSubPackage>();
					List<SubPackageDownLoadDynamicData> list3 = new List<SubPackageDownLoadDynamicData>();
					for (int j = 0; j < readOnlyList.Count; j++)
					{
						list3.Add(new SubPackageDownLoadDynamicData
						{
							SubPackageId = new int?(readOnlyList[j].Id)
						});
					}
					list3.Sort(new Comparison<SubPackageDownLoadDynamicData>(this.SortSubPackage));
					list.AddRange(list3);
				}
			}
		}
		if (this.CurrentTabType == 0)
		{
			this.KeySubPackageDataList = list;
			DynamicScrollView<SubPackageDownLoadItem, SubPackageDownLoadDynamicItem, SubPackageDownLoadDynamicData> subPackageDownLoadScrollView = this.SubPackageDownLoadScrollView;
			if (subPackageDownLoadScrollView != null)
			{
				subPackageDownLoadScrollView.RefreshByData(this.KeySubPackageDataList.ToArray(), true, true);
			}
		}
		else
		{
			this.ExpendSubPackageDataList = list;
			DynamicScrollView<SubPackageDownLoadItem, SubPackageDownLoadDynamicItem, SubPackageDownLoadDynamicData> subPackageDownLoadScrollView2 = this.SubPackageDownLoadScrollView;
			if (subPackageDownLoadScrollView2 != null)
			{
				subPackageDownLoadScrollView2.RefreshByData(this.ExpendSubPackageDataList.ToArray(), true, true);
			}
		}
		DynamicScrollView<SubPackageDownLoadItem, SubPackageDownLoadDynamicItem, SubPackageDownLoadDynamicData> subPackageDownLoadScrollView3 = this.SubPackageDownLoadScrollView;
		if (subPackageDownLoadScrollView3 != null)
		{
			subPackageDownLoadScrollView3.BindLateUpdate(delegate(float _)
			{
				int k = 0;
				while (k < this.SubPackageDownLoadItemList.Count)
				{
					SubPackageDownLoadItem subPackageDownLoadItem = this.SubPackageDownLoadItemList[k];
					SubPackageDownLoadDynamicData data = subPackageDownLoadItem.GetData();
					if (data != null && data.VersionId != null && data.VersionId.Value != 0)
					{
						int? num = data.VersionId;
						SubPackageDownLoadDynamicData targetData = this.TargetData;
						int? num2 = (targetData != null) ? targetData.VersionId : null;
						if (num.GetValueOrDefault() == num2.GetValueOrDefault() & num != null == (num2 != null))
						{
							goto IL_E3;
						}
					}
					if (data != null && data.SubPackageId != null && data.SubPackageId.Value != 0)
					{
						int? num2 = data.SubPackageId;
						SubPackageDownLoadDynamicData targetData2 = this.TargetData;
						int? num = (targetData2 != null) ? targetData2.SubPackageId : null;
						if (num2.GetValueOrDefault() == num.GetValueOrDefault() & num2 != null == (num != null))
						{
							goto IL_E3;
						}
					}
					k++;
					continue;
					IL_E3:
					ControllerBase<UiNavigationNewController>.Instance.SetNavigationFocusForView(subPackageDownLoadItem.GetInteractItem(), true, true, false);
					break;
				}
				this.TargetData = null;
				DynamicScrollView<SubPackageDownLoadItem, SubPackageDownLoadDynamicItem, SubPackageDownLoadDynamicData> subPackageDownLoadScrollView4 = this.SubPackageDownLoadScrollView;
				if (subPackageDownLoadScrollView4 == null)
				{
					return;
				}
				subPackageDownLoadScrollView4.UnBindLateUpdate();
			});
		}
		this.RefreshStartBtn();
	}

	// Token: 0x06015E1C RID: 89628 RVA: 0x00613C8D File Offset: 0x00611E8D
	private void OnRefreshSubPackUseCellData()
	{
		base.GetExtendToggle(3).SetToggleState(EToggleState.ETT_Checked, true, false, false);
	}

	// Token: 0x06015E1D RID: 89629 RVA: 0x00613CA0 File Offset: 0x00611EA0
	private int SortSubPackage(SubPackageDownLoadDynamicData a, SubPackageDownLoadDynamicData b)
	{
		ESubPackageDownLoadState subPackageDownLoadItemStateById = ModelBase<SubPackageDownLoadModel>.Instance.GetSubPackageDownLoadItemStateById(a.SubPackageId.Value);
		ESubPackageDownLoadState subPackageDownLoadItemStateById2 = ModelBase<SubPackageDownLoadModel>.Instance.GetSubPackageDownLoadItemStateById(b.SubPackageId.Value);
		if (subPackageDownLoadItemStateById != subPackageDownLoadItemStateById2)
		{
			return subPackageDownLoadItemStateById - subPackageDownLoadItemStateById2;
		}
		int num = ModelBase<SubPackageDownLoadModel>.Instance.SubPackageDownLoadList.IndexOf(a.SubPackageId.Value);
		int num2 = ModelBase<SubPackageDownLoadModel>.Instance.SubPackageDownLoadList.IndexOf(b.SubPackageId.Value);
		if (num == num2 && num == -1)
		{
			return a.SubPackageId.Value - b.SubPackageId.Value;
		}
		if (num != num2 && (num == -1 || num2 == -1))
		{
			return num2 - num;
		}
		if (num != num2)
		{
			return num - num2;
		}
		return a.SubPackageId.Value - b.SubPackageId.Value;
	}

	// Token: 0x06015E1E RID: 89630 RVA: 0x00613D66 File Offset: 0x00611F66
	private void OnRefreshSubPackDownLoadState()
	{
		this.RefreshFreeSpace();
		this.RefreshStartBtn();
	}

	// Token: 0x06015E1F RID: 89631 RVA: 0x00613D74 File Offset: 0x00611F74
	private void OnClickSubPackageDownLoadVersionTipsCallBack(int versionId, UUIItem item)
	{
		FVectorDouble fvectorDouble = item.D_K2_GetComponentLocation();
		FVectorDouble vector = new FVectorDouble
		{
			X = fvectorDouble.X,
			Z = fvectorDouble.Z
		};
		SubPackageDownLoadVersionTipsView versionTipsView = this.VersionTipsView;
		if (versionTipsView != null)
		{
			versionTipsView.RefreshItem(versionId, vector);
		}
		SubPackageDownLoadVersionTipsView versionTipsView2 = this.VersionTipsView;
		if (versionTipsView2 == null)
		{
			return;
		}
		versionTipsView2.SetUiActive(true);
	}

	// Token: 0x06015E20 RID: 89632 RVA: 0x00613DCF File Offset: 0x00611FCF
	private void OnClickTabCallBack(UUIExtendToggle toggle, int type)
	{
		UUIExtendToggle currentTabToggle = this.CurrentTabToggle;
		if (currentTabToggle != null)
		{
			currentTabToggle.SetToggleStateForce(EToggleState.ETT_UnChecked, false, false, false);
		}
		this.CurrentTabToggle = toggle;
		this.CurrentTabType = type;
		this.RefreshSubPackageDownLoadScrollView(type);
	}

	// Token: 0x06015E21 RID: 89633 RVA: 0x00613DFC File Offset: 0x00611FFC
	private void RefreshSubPackageDownLoadScrollView(int type)
	{
		if (type != 0)
		{
			if (type == 1)
			{
				if (this.ExpendSubPackageDataList.Count <= 0)
				{
					this.ExpendSubPackageDataList = new List<SubPackageDownLoadDynamicData>(ModelBase<SubPackageDownLoadModel>.Instance.GetExpendSubPackageData());
				}
				DynamicScrollView<SubPackageDownLoadItem, SubPackageDownLoadDynamicItem, SubPackageDownLoadDynamicData> subPackageDownLoadScrollView = this.SubPackageDownLoadScrollView;
				if (subPackageDownLoadScrollView == null)
				{
					return;
				}
				subPackageDownLoadScrollView.RefreshByData(this.ExpendSubPackageDataList.ToArray(), true, true);
			}
			return;
		}
		if (this.KeySubPackageDataList.Count <= 0)
		{
			this.KeySubPackageDataList = new List<SubPackageDownLoadDynamicData>(ModelBase<SubPackageDownLoadModel>.Instance.GetKeySubPackageData());
		}
		DynamicScrollView<SubPackageDownLoadItem, SubPackageDownLoadDynamicItem, SubPackageDownLoadDynamicData> subPackageDownLoadScrollView2 = this.SubPackageDownLoadScrollView;
		if (subPackageDownLoadScrollView2 == null)
		{
			return;
		}
		subPackageDownLoadScrollView2.RefreshByData(this.KeySubPackageDataList.ToArray(), true, true);
	}

	// Token: 0x06015E22 RID: 89634 RVA: 0x00613E94 File Offset: 0x00612094
	private void OnStartBtnClick()
	{
		if (!ModelBase<SubPackageDownLoadModel>.Instance.IsKeyPackageDownLoadingFinish())
		{
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.KeySubPackageDownLoadConfirm);
			confirmBoxDataNew.FunctionMap[1] = delegate()
			{
				ControllerBase<ConfirmBoxController>.Instance.CloseConfirmBoxView();
			};
			confirmBoxDataNew.FunctionMap[2] = delegate()
			{
				ControllerBase<SubPackageController>.Instance.RestartSubPackageDownLoading(1, null).Forget();
			};
			ControllerBase<ConfirmBoxController>.Instance.ShowNetWorkConfirmBoxView(confirmBoxDataNew, null);
			return;
		}
		base.CloseMe(null);
		CustomPromise loginPrepareResCheckPromise = ControllerBase<ResourceManagerController>.Instance.LoginPrepareResCheckPromise;
		if (loginPrepareResCheckPromise == null)
		{
			return;
		}
		loginPrepareResCheckPromise.SetResult();
	}

	// Token: 0x06015E23 RID: 89635 RVA: 0x00613F38 File Offset: 0x00612138
	private void OnClickMobileDataToggle(EToggleState state)
	{
		bool flag = state == EToggleState.ETT_Checked;
		LocalStorage.SetPlayer<bool>(ELocalStoragePlayerKey.SubDownLoadAgreeUseCellData, flag);
		int currentDownLoadId = ModelBase<SubPackageDownLoadModel>.Instance.DownLoadingSubPackageId;
		if (!flag && ModelBase<SubPackageDownLoadModel>.Instance.NetworkListener.GetNetworkType() == 3 && currentDownLoadId > 0)
		{
			ControllerBase<SubPackageController>.Instance.StopSubPackageDownLoading(currentDownLoadId, null);
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.SubPackageDownloadCellNetworkConfirm);
			confirmBoxDataNew.FunctionMap[1] = delegate()
			{
				ControllerBase<ConfirmBoxController>.Instance.CloseConfirmBoxView();
			};
			confirmBoxDataNew.FunctionMap[2] = delegate()
			{
				this.OnRefreshSubPackUseCellData();
				ControllerBase<SubPackageController>.Instance.RestartSubPackageDownLoading(currentDownLoadId, null).Forget();
			};
			ControllerBase<ConfirmBoxController>.Instance.ShowNetWorkConfirmBoxView(confirmBoxDataNew, null);
		}
	}

	// Token: 0x06015E24 RID: 89636 RVA: 0x00614000 File Offset: 0x00612200
	private void RefreshStartBtn()
	{
		bool selfInteractive = ModelBase<SubPackageDownLoadModel>.Instance.IsKeyPackageDownLoadingFinish();
		UUIButtonComponent button = base.GetButton(5);
		if (button == null)
		{
			return;
		}
		button.SetSelfInteractive(selfInteractive);
	}

	// Token: 0x06015E25 RID: 89637 RVA: 0x0061402C File Offset: 0x0061222C
	public void AniPlay(FName tag)
	{
		UUIItem item = base.GetItem(10);
		TArray<UActorComponent> tarray;
		if (item == null)
		{
			tarray = null;
		}
		else
		{
			AActor owner = item.GetOwner();
			tarray = ((owner != null) ? owner.GetComponentsByTag(UUIInturnAnimController.StaticClass(), tag) : null);
		}
		TArray<UActorComponent> tarray2 = tarray;
		if (tarray2 != null && tarray2.Num() > 0)
		{
			UUIInturnAnimController uuiinturnAnimController = tarray2.Get(0) as UUIInturnAnimController;
			if (uuiinturnAnimController == null)
			{
				return;
			}
			uuiinturnAnimController.Play("", -1, false);
		}
	}

	// Token: 0x06015E26 RID: 89638 RVA: 0x0061408E File Offset: 0x0061228E
	private void OnClickChileItemBtn(SubPackageDownLoadDynamicData data)
	{
		this.TargetData = data;
	}

	// Token: 0x0400A7F9 RID: 43001
	private static readonly FName StartTag = new FName("Start");

	// Token: 0x0400A7FA RID: 43002
	private static readonly FName CloseTag = new FName("Close");

	// Token: 0x0400A7FB RID: 43003
	[Nullable(2)]
	private PopupCaptionItem CaptionItem;

	// Token: 0x0400A7FC RID: 43004
	[Nullable(new byte[]
	{
		2,
		1,
		1,
		1
	})]
	private DynamicScrollView<SubPackageDownLoadItem, SubPackageDownLoadDynamicItem, SubPackageDownLoadDynamicData> SubPackageDownLoadScrollView;

	// Token: 0x0400A7FD RID: 43005
	[Nullable(2)]
	private SubPackageDownLoadVersionTipsView VersionTipsView;

	// Token: 0x0400A7FE RID: 43006
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<SubPackageTab, int> TabScrollview;

	// Token: 0x0400A7FF RID: 43007
	[Nullable(2)]
	private UUIExtendToggle CurrentTabToggle;

	// Token: 0x0400A800 RID: 43008
	[Nullable(2)]
	private SubPackageDownLoadDynamicItem SubPackageDownLoadItem;

	// Token: 0x0400A801 RID: 43009
	private readonly List<SubPackageDownLoadItem> SubPackageDownLoadItemList = new List<SubPackageDownLoadItem>();

	// Token: 0x0400A802 RID: 43010
	private int CurrentTabType;

	// Token: 0x0400A803 RID: 43011
	private List<SubPackageDownLoadDynamicData> KeySubPackageDataList = new List<SubPackageDownLoadDynamicData>();

	// Token: 0x0400A804 RID: 43012
	private List<SubPackageDownLoadDynamicData> ExpendSubPackageDataList = new List<SubPackageDownLoadDynamicData>();

	// Token: 0x0400A805 RID: 43013
	[Nullable(2)]
	private TimerHandle TimerHandle;

	// Token: 0x0400A806 RID: 43014
	private bool LevelSequenceBannadHandle;

	// Token: 0x0400A807 RID: 43015
	[Nullable(2)]
	private SubPackageDownLoadDynamicData TargetData;

	// Token: 0x02008E25 RID: 36389
	[NullableContext(0)]
	private static class EComponentDefine
	{
		// Token: 0x0402FD16 RID: 195862
		public const int TitleItem = 0;

		// Token: 0x0402FD17 RID: 195863
		public const int LogoTexture = 1;

		// Token: 0x0402FD18 RID: 195864
		public const int TabVerticalLayout = 2;

		// Token: 0x0402FD19 RID: 195865
		public const int MobileDataToggle = 3;

		// Token: 0x0402FD1A RID: 195866
		public const int SubPackageDyncScrollView = 4;

		// Token: 0x0402FD1B RID: 195867
		public const int StartBtn = 5;

		// Token: 0x0402FD1C RID: 195868
		public const int LeftMemoryText = 6;

		// Token: 0x0402FD1D RID: 195869
		public const int VersionTipsParentItem = 7;

		// Token: 0x0402FD1E RID: 195870
		public const int SubPackageItem = 8;

		// Token: 0x0402FD1F RID: 195871
		public const int StartBtnText = 9;

		// Token: 0x0402FD20 RID: 195872
		public const int ContentItem = 10;
	}
}
