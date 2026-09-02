using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.InputSetting
{
	// Token: 0x02007019 RID: 28697
	[NullableContext(1)]
	[Nullable(0)]
	public class TouchUiEditProxy
	{
		// Token: 0x1700A4E0 RID: 42208
		// (get) Token: 0x06045797 RID: 284567 RVA: 0x0122948C File Offset: 0x0122768C
		[Nullable(2)]
		private ITouchUiEditItem CurrentSelectedItem
		{
			[NullableContext(2)]
			get
			{
				return TouchUiEditViewModel.GetCurrentSelectedItem();
			}
		}

		// Token: 0x06045798 RID: 284568 RVA: 0x01229493 File Offset: 0x01227693
		public TouchUiEditProxy(ITouchUiEditContainer container, ITouchUiEditDataFacade dataFacade, [Nullable(new byte[]
		{
			1,
			1,
			2,
			1
		})] Func<UUIItem, ITouchUiEditData, ITouchUiEditItem> itemCreator)
		{
			this.Container = container;
			this.DataFacade = dataFacade;
			this.ItemCreator = itemCreator;
		}

		// Token: 0x06045799 RID: 284569 RVA: 0x012294C6 File Offset: 0x012276C6
		public void SetView(ITouchUiEditView view)
		{
			this.View = view;
		}

		// Token: 0x0604579A RID: 284570 RVA: 0x012294D0 File Offset: 0x012276D0
		public UniTask OnBeforeStartAsync()
		{
			TouchUiEditProxy.<OnBeforeStartAsync>d__12 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<TouchUiEditProxy.<OnBeforeStartAsync>d__12>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0604579B RID: 284571 RVA: 0x01229514 File Offset: 0x01227714
		public void OnStart()
		{
			TouchUiEditViewModel.SetRootItem(this.Container.GetRootItem());
			string[] resIdList = this.DataFacade.GetResIdList();
			HashSet<UUIItem> hashSet = new HashSet<UUIItem>();
			CommonTouchUiEditGroup? commonTouchUiEditGroup;
			int num = (this.DataFacade.GetGroupConfig() != null) ? commonTouchUiEditGroup.GetValueOrDefault().Id : 0;
			foreach (string resId in resIdList)
			{
				IReadOnlyList<CommonTouchUiEdit> configListByPanelResId = ConfigBase<CommonTouchUiEditConfig>.Instance.GetConfigListByPanelResId(resId);
				if (configListByPanelResId != null)
				{
					foreach (CommonTouchUiEdit commonTouchUiEdit in configListByPanelResId)
					{
						if (commonTouchUiEdit.EditGroup == num)
						{
							int itemIndex = commonTouchUiEdit.ItemIndex;
							int subPanelIndex = commonTouchUiEdit.SubPanelIndex;
							UUIItem item = this.Container.GetItem(resId, itemIndex, subPanelIndex);
							if (item != null)
							{
								hashSet.Add(item);
								ITouchUiEditData data = this.DataFacade.GetData(resId, itemIndex);
								ITouchUiEditItem touchUiEditItem = this.ItemCreator(item, data);
								touchUiEditItem.SetData(data);
								int storageId = this.DataFacade.GetStorageId(resId, itemIndex);
								if (storageId != 0)
								{
									this.EditableItemMap[storageId] = touchUiEditItem;
								}
								this.AllItemList.Add(touchUiEditItem);
								ITouchUiEditData data2 = touchUiEditItem.Data;
								if (data2 != null && data2.DefaultSelect)
								{
									TouchUiEditViewModel.SetCurrentSelectedItem(touchUiEditItem);
								}
							}
						}
					}
					foreach (UUIItem uuiitem in this.Container.GetRegistryItemList(resId))
					{
						if (!hashSet.Contains(uuiitem))
						{
							ITouchUiEditItem item2 = this.ItemCreator(uuiitem, null);
							this.AllItemList.Add(item2);
						}
					}
				}
			}
			this.BindTouchEvents();
		}

		// Token: 0x0604579C RID: 284572 RVA: 0x012296F4 File Offset: 0x012278F4
		public void OnBeforeDestroy()
		{
			this.UnBindTouchEvents();
			TouchUiEditViewModel.SetCurrentSelectedItem(null);
			foreach (ITouchUiEditItem touchUiEditItem in this.AllItemList)
			{
				touchUiEditItem.OnViewDestroy();
			}
			this.EditableItemMap.Clear();
			this.AllItemList.Clear();
			this.Container.OnViewDestroy();
		}

		// Token: 0x0604579D RID: 284573 RVA: 0x01229774 File Offset: 0x01227974
		public void OnTick(float deltaTime)
		{
			if (this.View == null)
			{
				return;
			}
			if (this.CurrentSelectedItem == null)
			{
				return;
			}
			if (this.OffsetDeltaX != 0 || this.OffsetDeltaY != 0)
			{
				this.CurrentSelectedItem.SetOffset(this.CurrentSelectedItem.Data.OffsetX + (float)this.OffsetDeltaX, this.CurrentSelectedItem.Data.OffsetY + (float)this.OffsetDeltaY);
			}
		}

		// Token: 0x0604579E RID: 284574 RVA: 0x012297DE File Offset: 0x012279DE
		public void SetOffsetDeltaX(int offset)
		{
			this.OffsetDeltaX = offset;
		}

		// Token: 0x0604579F RID: 284575 RVA: 0x012297E7 File Offset: 0x012279E7
		public void SetOffsetDeltaY(int offset)
		{
			this.OffsetDeltaY = offset;
		}

		// Token: 0x060457A0 RID: 284576 RVA: 0x012297F0 File Offset: 0x012279F0
		public void SetScale(float scale)
		{
			ITouchUiEditItem currentSelectedItem = this.CurrentSelectedItem;
			if (currentSelectedItem == null)
			{
				return;
			}
			currentSelectedItem.SetScale(scale);
		}

		// Token: 0x060457A1 RID: 284577 RVA: 0x01229803 File Offset: 0x01227A03
		public void SetAlpha(float alpha)
		{
			ITouchUiEditItem currentSelectedItem = this.CurrentSelectedItem;
			if (currentSelectedItem == null)
			{
				return;
			}
			currentSelectedItem.SetAlpha(alpha);
		}

		// Token: 0x060457A2 RID: 284578 RVA: 0x01229816 File Offset: 0x01227A16
		public void SetHierarchyIndex(int index)
		{
			ITouchUiEditItem currentSelectedItem = this.CurrentSelectedItem;
			if (currentSelectedItem == null)
			{
				return;
			}
			currentSelectedItem.SetHierarchyIndex(index);
		}

		// Token: 0x060457A3 RID: 284579 RVA: 0x0122982C File Offset: 0x01227A2C
		public void Save(bool checkOverlap = true)
		{
			if (checkOverlap && this.CheckOverLap())
			{
				ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.CheckOverlap);
				confirmBoxDataNew.FunctionMap[2] = delegate()
				{
					this.SaveImp();
					UiViewBase uiViewBase2 = this.View as UiViewBase;
					if (uiViewBase2 == null)
					{
						return;
					}
					uiViewBase2.CloseMe(null);
				};
				ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
				return;
			}
			this.SaveImp();
			UiViewBase uiViewBase = this.View as UiViewBase;
			if (uiViewBase == null)
			{
				return;
			}
			uiViewBase.CloseMe(null);
		}

		// Token: 0x060457A4 RID: 284580 RVA: 0x01229890 File Offset: 0x01227A90
		public void Reset()
		{
			foreach (ITouchUiEditItem touchUiEditItem in this.EditableItemMap.Values)
			{
				ValueTuple<string, int>? resPair = this.DataFacade.GetResPair(touchUiEditItem.Data.StorageId);
				if (resPair != null)
				{
					ValueTuple<string, int> value = resPair.Value;
					string item = value.Item1;
					int item2 = value.Item2;
					ITouchUiEditData defaultData = this.DataFacade.GetDefaultData(item, item2);
					if (defaultData != null)
					{
						touchUiEditItem.SetScale(defaultData.Scale);
						touchUiEditItem.SetOffset(defaultData.OffsetX, defaultData.OffsetY);
						touchUiEditItem.SetAlpha(defaultData.Alpha);
						touchUiEditItem.SetHierarchyIndex(defaultData.HierarchyIndex);
					}
				}
			}
		}

		// Token: 0x060457A5 RID: 284581 RVA: 0x0122996C File Offset: 0x01227B6C
		public void ResetEditData()
		{
			this.DataFacade.ResetEditData();
		}

		// Token: 0x060457A6 RID: 284582 RVA: 0x0122997C File Offset: 0x01227B7C
		public bool IsEdited()
		{
			using (Dictionary<int, ITouchUiEditItem>.ValueCollection.Enumerator enumerator = this.EditableItemMap.Values.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.IsEdited())
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x060457A7 RID: 284583 RVA: 0x012299DC File Offset: 0x01227BDC
		private void SaveImp()
		{
			List<ITouchUiEditData> list = new List<ITouchUiEditData>();
			foreach (ITouchUiEditItem touchUiEditItem in this.EditableItemMap.Values)
			{
				list.Add(touchUiEditItem.Data);
			}
			this.DataFacade.SaveData(list.ToArray());
			CommonTouchUiEditGroup? commonTouchUiEditGroup;
			int num = (this.DataFacade.GetGroupConfig() != null) ? commonTouchUiEditGroup.GetValueOrDefault().Id : 0;
			if (num == 0)
			{
				Singleton<Log>.Instance.Error(ELogModule.TouchUiEdit, ELogAuthor.TZJ, "保存改键数据出错，分组Id无效", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			Singleton<EventSystem>.Instance.Emit<ECommonTouchUiEditGroup>(EEventName.OnTouchUiEditSave, (ECommonTouchUiEditGroup)num);
		}

		// Token: 0x060457A8 RID: 284584 RVA: 0x01229AB0 File Offset: 0x01227CB0
		private bool CheckOverLap()
		{
			for (int i = 0; i < this.AllItemList.Count; i++)
			{
				ITouchUiEditItem touchUiEditItem = this.AllItemList[i];
				ITouchUiEditData data = touchUiEditItem.Data;
				if (data != null && data.ShouldCheckOverlap && touchUiEditItem.RootItem.IsUIActiveInHierarchy() && touchUiEditItem.RootItem.IsRaycastTarget())
				{
					for (int j = i + 1; j < this.AllItemList.Count; j++)
					{
						ITouchUiEditItem touchUiEditItem2 = this.AllItemList[j];
						if (touchUiEditItem.RootItem.GetOverlapWith(touchUiEditItem2.RootItem))
						{
							return true;
						}
					}
				}
			}
			return false;
		}

		// Token: 0x060457A9 RID: 284585 RVA: 0x01229B4F File Offset: 0x01227D4F
		private void BindTouchEvents()
		{
			ControllerBase<InputDistributeController>.Instance.BindTouches(new int[]
			{
				0,
				1,
				2,
				3,
				4,
				5,
				6,
				7,
				8,
				9
			}, new TInputHandle<InputDistributeDefine.ITouchData>(this.OnTouch));
		}

		// Token: 0x060457AA RID: 284586 RVA: 0x01229B79 File Offset: 0x01227D79
		private void UnBindTouchEvents()
		{
			ControllerBase<InputDistributeController>.Instance.UnBindTouches(new <>z__ReadOnlyArray<int>(new int[]
			{
				0,
				1,
				2,
				3,
				4,
				5,
				6,
				7,
				8,
				9
			}), new TInputHandle<InputDistributeDefine.ITouchData>(this.OnTouch));
		}

		// Token: 0x060457AB RID: 284587 RVA: 0x01229BA8 File Offset: 0x01227DA8
		private void OnTouchTrigger(bool bPress, int touchId)
		{
			TouchFingerData touchFingerData = Singleton<TouchFingerManager>.Instance.GetTouchFingerData((EFingerIndex)touchId);
			if (touchFingerData == null)
			{
				return;
			}
			if (bPress)
			{
				TouchUiEditViewModel.AddTouchFingerData(touchFingerData);
				return;
			}
			TouchUiEditViewModel.RemoveTouchFingerData(touchFingerData);
		}

		// Token: 0x060457AC RID: 284588 RVA: 0x01229BD8 File Offset: 0x01227DD8
		private void OnTouchMove(int touchId)
		{
			if (this.CurrentSelectedItem == null)
			{
				return;
			}
			if (TouchUiEditViewModel.GetTouchFingerDataCount() < 2)
			{
				return;
			}
			TouchFingerData touchFingerData = TouchUiEditViewModel.GetTouchFingerData(0);
			TouchFingerData touchFingerData2 = TouchUiEditViewModel.GetTouchFingerData(1);
			EFingerIndex fingerIndex = touchFingerData.GetFingerIndex();
			EFingerIndex fingerIndex2 = touchFingerData2.GetFingerIndex();
			float fingerExpandCloseValue = Singleton<TouchFingerManager>.Instance.GetFingerExpandCloseValue(fingerIndex, fingerIndex2);
			float num = Singleton<MathUtils>.Instance.RangeClamp(fingerExpandCloseValue, (float)this.DataFacade.MinTouchMoveDifference, (float)this.DataFacade.MaxTouchMoveDifference, this.DataFacade.MinTouchMoveValue, this.DataFacade.MaxTouchMoveValue);
			float num2 = this.CurrentSelectedItem.Data.Scale + num * this.DataFacade.ControlScaleRate;
			UUISliderComponent scaleSlider = this.View.GetScaleSlider();
			float scale = num2;
			if (scaleSlider != null)
			{
				float minValue = scaleSlider.MinValue;
				float maxValue = scaleSlider.MaxValue;
				scale = Singleton<MathUtils>.Instance.Clamp(num2, minValue, maxValue);
			}
			this.CurrentSelectedItem.SetScale(scale);
		}

		// Token: 0x060457AD RID: 284589 RVA: 0x01229CC0 File Offset: 0x01227EC0
		private void OnTouch(string touchIdName, InputDistributeDefine.ITouchData touchData, InputIdentification inputIdentification)
		{
			InputDistributeDefine.ETouchType touchType = touchData.TouchType;
			int touchId = int.Parse(touchIdName);
			switch (touchType)
			{
			case InputDistributeDefine.ETouchType.TouchBegin:
				this.OnTouchTrigger(true, touchId);
				return;
			case InputDistributeDefine.ETouchType.TouchEnd:
				this.OnTouchTrigger(false, touchId);
				return;
			case InputDistributeDefine.ETouchType.TouchMove:
				this.OnTouchMove(touchId);
				return;
			default:
				return;
			}
		}

		// Token: 0x04026D0B RID: 158987
		[Nullable(2)]
		private ITouchUiEditView View;

		// Token: 0x04026D0C RID: 158988
		private readonly Dictionary<int, ITouchUiEditItem> EditableItemMap = new Dictionary<int, ITouchUiEditItem>();

		// Token: 0x04026D0D RID: 158989
		private readonly List<ITouchUiEditItem> AllItemList = new List<ITouchUiEditItem>();

		// Token: 0x04026D0E RID: 158990
		private int OffsetDeltaX;

		// Token: 0x04026D0F RID: 158991
		private int OffsetDeltaY;

		// Token: 0x04026D10 RID: 158992
		private readonly ITouchUiEditContainer Container;

		// Token: 0x04026D11 RID: 158993
		private readonly ITouchUiEditDataFacade DataFacade;

		// Token: 0x04026D12 RID: 158994
		[Nullable(new byte[]
		{
			1,
			1,
			2,
			1
		})]
		private readonly Func<UUIItem, ITouchUiEditData, ITouchUiEditItem> ItemCreator;
	}
}
