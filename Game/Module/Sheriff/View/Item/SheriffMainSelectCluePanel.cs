using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Sheriff.View.Item
{
	// Token: 0x02004FED RID: 20461
	[NullableContext(1)]
	[Nullable(0)]
	public class SheriffMainSelectCluePanel : UiTabViewBase
	{
		// Token: 0x06034BF6 RID: 216054 RVA: 0x00D3BF30 File Offset: 0x00D3A130
		protected unsafe override void OnRegisterComponent()
		{
			int num = 22;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIGridLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(17, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(18, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(19, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(20, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(21, typeof(UUIButtonComponent));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(21, new Action(this.OnClickedReplayDialog));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06034BF7 RID: 216055 RVA: 0x00D3C27C File Offset: 0x00D3A47C
		protected override void OnStart()
		{
			this.Proxy = (this.ExtraParams as SheriffMainProxy);
			this.ConfirmBtn = new ButtonItem(base.GetItem(18));
			this.ConfirmBtn.SetFunction(new Action<int>(this.OnClickBtnSkyEyeConfirm));
			this.QuestionTabLayout = new GenericLayout<SheriffQuestionTabItem, int>(base.GetHorizontalLayout(2), new Func<SheriffQuestionTabItem>(this.CreateQuestionTabItem), null, false, true);
			this.SelectLayout = new GenericLayout<SheriffSelectClueItem, int>(base.GetHorizontalLayout(12), new Func<SheriffSelectClueItem>(this.CreateSelectClueItem), null, false, true);
			this.SelectedLayout = new GenericLayout<SheriffSelectClueItem, int>(base.GetHorizontalLayout(16), new Func<SheriffSelectClueItem>(this.CreateSelectClueItem), null, false, true);
			this.ClueLayout = new GenericLayout<SheriffClueItem, int>(base.GetGridLayout(0), new Func<SheriffClueItem>(this.CreateClueItem), null, false, true);
			this.Proxy.OnClueHintStateChangeCallback = new Action(this.OnClueHintStateChangeCallback);
		}

		// Token: 0x06034BF8 RID: 216056 RVA: 0x00D3C364 File Offset: 0x00D3A564
		protected override void OnBeforeShow()
		{
			UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
			if (uiViewSequence != null)
			{
				uiViewSequence.PlayOrReplaySequenceByName("Start", false, null);
			}
			if (this.Proxy.BackFromDetailClue)
			{
				this.Proxy.BackFromDetailClue = false;
				return;
			}
			if (this.Proxy.NeedRemainHoverItem && this.Proxy.ConfirmClueIndex >= 0)
			{
				List<SheriffClueItem> layoutItemList = this.ClueLayout.GetLayoutItemList();
				if (layoutItemList.Count > this.Proxy.ConfirmClueIndex)
				{
					UUIItem rootItem = layoutItemList[this.Proxy.ConfirmClueIndex].GetRootItem();
					ControllerBase<UiNavigationNewController>.Instance.SetNavigationFocusForViewByRootItem(rootItem, "Group1", true);
				}
			}
			this.Proxy.NeedRemainHoverItem = false;
			this.Proxy.ConfirmClueIndex = -1;
			this.Proxy.GamepadHoverIndex = -1;
			this.CacheClueSet.Clear();
			this.CheckClueEnough();
			this.RefreshQuestionTab();
			this.RefreshQuestionPanel();
			this.RefreshCluePanel(true);
		}

		// Token: 0x06034BF9 RID: 216057 RVA: 0x00D3C458 File Offset: 0x00D3A658
		protected void CheckClueEnough()
		{
			SheriffAnomalyInfo anomalyInfo = this.Proxy.GetAnomalyInfo();
			int count = anomalyInfo.ClueIds.Count;
			this.IsClueEnough = (ConfigBase<SheriffConfig>.Instance.GetAnomalyConfigById(anomalyInfo.AnomalyId).Value.ClueLessCount <= count);
			base.GetItem(19).SetUIActive(!this.IsClueEnough);
		}

		// Token: 0x06034BFA RID: 216058 RVA: 0x00D3C4C0 File Offset: 0x00D3A6C0
		protected void RefreshQuestionTab()
		{
			int questionDataLength = this.Proxy.GetQuestionDataLength();
			List<int> list = new List<int>();
			for (int i = 0; i < questionDataLength; i++)
			{
				list.Add(i);
			}
			this.CurQuestionTabIndex = this.Proxy.GetCurQuestionIndex();
			this.QuestionTabLayout.RefreshByData(list.ToArray(), null, true);
		}

		// Token: 0x06034BFB RID: 216059 RVA: 0x00D3C518 File Offset: 0x00D3A718
		protected void RefreshQuestionPanel()
		{
			int curQuestionIndex = this.Proxy.GetCurQuestionIndex();
			base.GetItem(4).SetUIActive(curQuestionIndex > this.CurQuestionTabIndex);
			base.GetItem(7).SetUIActive(curQuestionIndex <= this.CurQuestionTabIndex);
			base.GetItem(11).SetUIActive(curQuestionIndex == this.CurQuestionTabIndex);
			base.GetItem(15).SetUIActive(curQuestionIndex > this.CurQuestionTabIndex);
			ButtonItem confirmBtn = this.ConfirmBtn;
			if (confirmBtn != null)
			{
				confirmBtn.SetUiActive(curQuestionIndex >= this.CurQuestionTabIndex);
			}
			if (curQuestionIndex > this.CurQuestionTabIndex)
			{
				UUIButtonComponent button = base.GetButton(21);
				if (button != null)
				{
					button.RootUIComp.Get().SetUIActive(false);
				}
				SheriffMainProxy proxy = this.Proxy;
				if (proxy != null)
				{
					proxy.RefreshHintButtonEnable(false);
				}
				int questionIdByIndex = this.Proxy.GetQuestionIdByIndex(this.CurQuestionTabIndex);
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(31, 1);
				defaultInterpolatedStringHandler.AppendLiteral("ReasoningQuestion_");
				defaultInterpolatedStringHandler.AppendFormatted<int>(questionIdByIndex);
				defaultInterpolatedStringHandler.AppendLiteral("_QuestionDesc");
				string key = defaultInterpolatedStringHandler.ToStringAndClear();
				UUIText text = base.GetText(5);
				if (text != null)
				{
					text.ShowTextNew(key);
				}
				string conclusionKey = this.Proxy.GetConclusionKey(questionIdByIndex);
				UUIText text2 = base.GetText(6);
				if (text2 != null)
				{
					text2.ShowTextNew(conclusionKey);
				}
				List<int> clueRecords = this.Proxy.GetClueRecords(this.CurQuestionTabIndex);
				clueRecords.Sort((int a, int b) => a - b);
				this.SelectedLayout.RefreshByData(clueRecords, null, true);
				ButtonItem confirmBtn2 = this.ConfirmBtn;
				if (confirmBtn2 != null)
				{
					confirmBtn2.SetEnableClick(true);
				}
				ButtonItem confirmBtn3 = this.ConfirmBtn;
				if (confirmBtn3 == null)
				{
					return;
				}
				confirmBtn3.SetLocalTextNew("Inference_Desc_11", Array.Empty<object>());
				return;
			}
			else
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler;
				if (curQuestionIndex < this.CurQuestionTabIndex)
				{
					UUIButtonComponent button2 = base.GetButton(21);
					if (button2 != null)
					{
						button2.RootUIComp.Get().SetUIActive(false);
					}
					SheriffMainProxy proxy2 = this.Proxy;
					if (proxy2 != null)
					{
						proxy2.RefreshHintButtonEnable(false);
					}
					base.GetSprite(8).SetUIActive(true);
					base.GetTexture(9).SetUIActive(false);
					PublicUtil instance = Singleton<PublicUtil>.Instance;
					defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(15, 1);
					defaultInterpolatedStringHandler.AppendLiteral("Inference_Desc_");
					defaultInterpolatedStringHandler.AppendFormatted<int>(2 + this.CurQuestionTabIndex - 1);
					string configTextByKey = instance.GetConfigTextByKey(defaultInterpolatedStringHandler.ToStringAndClear());
					Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(10), "Inference_Desc_5", new <>z__ReadOnlySingleElementList<object>(configTextByKey));
					return;
				}
				UUIButtonComponent button3 = base.GetButton(21);
				if (button3 != null)
				{
					button3.RootUIComp.Get().SetUIActive(true);
				}
				SheriffMainProxy proxy3 = this.Proxy;
				if (proxy3 != null)
				{
					proxy3.RefreshHintButtonEnable(true);
				}
				int questionIdByIndex2 = this.Proxy.GetQuestionIdByIndex(this.CurQuestionTabIndex);
				base.GetSprite(8).SetUIActive(false);
				base.GetTexture(9).SetUIActive(true);
				int currentClueLength = this.Proxy.GetCurrentClueLength();
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(14), "Inference_Desc_19", new <>z__ReadOnlyArray<object>(new object[]
				{
					this.CacheClueSet.Count,
					currentClueLength
				}));
				defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(31, 1);
				defaultInterpolatedStringHandler.AppendLiteral("ReasoningQuestion_");
				defaultInterpolatedStringHandler.AppendFormatted<int>(questionIdByIndex2);
				defaultInterpolatedStringHandler.AppendLiteral("_QuestionDesc");
				string key2 = defaultInterpolatedStringHandler.ToStringAndClear();
				UUIText text3 = base.GetText(10);
				if (text3 != null)
				{
					text3.ShowTextNew(key2);
				}
				this.RefreshSelectClueLayout();
				ButtonItem confirmBtn4 = this.ConfirmBtn;
				if (confirmBtn4 == null)
				{
					return;
				}
				confirmBtn4.SetLocalTextNew("Inference_Desc_20", Array.Empty<object>());
				return;
			}
		}

		// Token: 0x06034BFC RID: 216060 RVA: 0x00D3C8A0 File Offset: 0x00D3AAA0
		protected void RefreshSelectClueLayout()
		{
			List<int> list = this.CacheClueSet.ToList<int>();
			int realClueLength = list.Count;
			int clueLength = this.Proxy.GetCurrentClueLength();
			for (int i = list.Count; i < clueLength; i++)
			{
				list.Add(0);
			}
			this.SelectLayout.RefreshByData(list, delegate
			{
				ButtonItem confirmBtn = this.ConfirmBtn;
				if (confirmBtn == null)
				{
					return;
				}
				confirmBtn.SetEnableClick(this.IsClueEnough && realClueLength >= clueLength);
			}, true);
		}

		// Token: 0x06034BFD RID: 216061 RVA: 0x00D3C91C File Offset: 0x00D3AB1C
		protected void RefreshCluePanel(bool needAnim = true)
		{
			SheriffAnomalyInfo anomalyInfo = this.Proxy.GetAnomalyInfo();
			if (this.AllClueIds.Count == 0)
			{
				List<int> clueListByAnomalyId = ModelBase<SheriffModel>.Instance.GetClueListByAnomalyId(anomalyInfo.AnomalyId);
				this.AllClueIds = new List<int>(clueListByAnomalyId);
			}
			List<int> list = new List<int>();
			foreach (int item in this.AllClueIds)
			{
				if (anomalyInfo.ClueIds.Contains(item))
				{
					list.Add(item);
				}
				else
				{
					list.Add(0);
				}
			}
			this.ClueLayout.RefreshByData(list, null, needAnim);
		}

		// Token: 0x06034BFE RID: 216062 RVA: 0x00D3C9D4 File Offset: 0x00D3ABD4
		private void OnClickBtnSkyEyeConfirm(int data)
		{
			int curQuestionIndex = this.Proxy.GetCurQuestionIndex();
			if (curQuestionIndex > this.CurQuestionTabIndex)
			{
				ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.SheriffRestartConfirm);
				confirmBoxDataNew.FunctionMap[2] = delegate()
				{
					this.Proxy.RestartGameplay();
				};
				ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
				return;
			}
			if (curQuestionIndex < this.CurQuestionTabIndex)
			{
				return;
			}
			int currentClueLength = this.Proxy.GetCurrentClueLength();
			if (this.CacheClueSet.Count < currentClueLength)
			{
				return;
			}
			this.Proxy.SetClueRecords(this.CurQuestionTabIndex, this.CacheClueSet.ToList<int>());
		}

		// Token: 0x06034BFF RID: 216063 RVA: 0x00D3CA67 File Offset: 0x00D3AC67
		private SheriffQuestionTabItem CreateQuestionTabItem()
		{
			return new SheriffQuestionTabItem(this.Proxy)
			{
				CheckSelectCallback = new Func<int, bool>(this.OnTabToggleCheck),
				OnToggleStateChangedCallback = new Action<int>(this.OnTabStateChangedCallback)
			};
		}

		// Token: 0x06034C00 RID: 216064 RVA: 0x00D3CA98 File Offset: 0x00D3AC98
		private bool OnTabToggleCheck(int index)
		{
			return this.CurQuestionTabIndex == index;
		}

		// Token: 0x06034C01 RID: 216065 RVA: 0x00D3CAA4 File Offset: 0x00D3ACA4
		private void OnTabStateChangedCallback(int index)
		{
			this.CurQuestionTabIndex = index;
			List<SheriffQuestionTabItem> layoutItemList = this.QuestionTabLayout.GetLayoutItemList();
			for (int i = 0; i < layoutItemList.Count; i++)
			{
				layoutItemList[i].SetSelected(i == index, false);
			}
			this.RefreshQuestionPanel();
			this.RefreshCluePanel(true);
		}

		// Token: 0x06034C02 RID: 216066 RVA: 0x00D3CAF3 File Offset: 0x00D3ACF3
		private SheriffSelectClueItem CreateSelectClueItem()
		{
			return new SheriffSelectClueItem();
		}

		// Token: 0x06034C03 RID: 216067 RVA: 0x00D3CAFC File Offset: 0x00D3ACFC
		private SheriffClueItem CreateClueItem()
		{
			return new SheriffClueItem(this.Proxy)
			{
				CheckSelectCallback = new Func<int, EToggleState>(this.OnClueToggleCheck),
				OnToggleStateChangedCallback = new Action<int, bool>(this.OnClueStateChangedCallback),
				CheckCanChangeCallback = new Func<int, EToggleState, bool>(this.OnClueCheckCanChange),
				CheckToggleEnable = new Func<bool>(this.OnClueCheckToggleEnable)
			};
		}

		// Token: 0x06034C04 RID: 216068 RVA: 0x00D3CB5C File Offset: 0x00D3AD5C
		private EToggleState OnClueToggleCheck(int id)
		{
			int curQuestionIndex = this.Proxy.GetCurQuestionIndex();
			if (this.CurQuestionTabIndex != curQuestionIndex)
			{
				return EToggleState.ETT_UnDetermined;
			}
			int item = this.AllClueIds[id];
			if (!this.CacheClueSet.Contains(item))
			{
				return EToggleState.ETT_UnChecked;
			}
			return EToggleState.ETT_Checked;
		}

		// Token: 0x06034C05 RID: 216069 RVA: 0x00D3CBA0 File Offset: 0x00D3ADA0
		private unsafe void OnClueStateChangedCallback(int id, bool isSelected)
		{
			int currentClueLength = this.Proxy.GetCurrentClueLength();
			if (currentClueLength == 1)
			{
				if (isSelected)
				{
					this.CacheClueSet.Clear();
					this.CacheClueSet.Add(id);
				}
				else
				{
					this.CacheClueSet.Remove(id);
				}
				GenericLayout<SheriffClueItem, int> clueLayout = this.ClueLayout;
				using (List<SheriffClueItem>.Enumerator enumerator = (((clueLayout != null) ? clueLayout.GetLayoutItemList() : null) ?? new List<SheriffClueItem>()).GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						SheriffClueItem sheriffClueItem = enumerator.Current;
						sheriffClueItem.RefreshSelected();
					}
					goto IL_193;
				}
			}
			if (isSelected)
			{
				if (this.CacheClueSet.Contains(id) || this.CacheClueSet.Count >= currentClueLength)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Sheriff;
					ELogAuthor author = ELogAuthor.WHJ;
					string message = "Sheriff Cache Clue Set Add Error";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("id", id);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("CacheClueSet", this.CacheClueSet);
					instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				}
				this.CacheClueSet.Add(id);
			}
			else
			{
				if (!this.CacheClueSet.Contains(id))
				{
					Log instance2 = Singleton<Log>.Instance;
					ELogModule module2 = ELogModule.Sheriff;
					ELogAuthor author2 = ELogAuthor.WHJ;
					string message2 = "Sheriff Cache Clue Set Delete Error";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("id", id);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("CacheClueSet", this.CacheClueSet);
					instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
				}
				this.CacheClueSet.Remove(id);
			}
			IL_193:
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(14), "Inference_Desc_19", new <>z__ReadOnlyArray<object>(new object[]
			{
				this.CacheClueSet.Count,
				currentClueLength
			}));
			this.RefreshSelectClueLayout();
		}

		// Token: 0x06034C06 RID: 216070 RVA: 0x00D3CD94 File Offset: 0x00D3AF94
		private bool OnClueCheckCanChange(int id, EToggleState curState)
		{
			if (!this.OnClueCheckToggleEnable())
			{
				return true;
			}
			if (curState == EToggleState.ETT_Checked)
			{
				return true;
			}
			if (curState == EToggleState.ETT_UnChecked && id <= 0 && this.OnClueCheckToggleEnable())
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Inference_Desc_30", Array.Empty<object>());
				return false;
			}
			if (curState == EToggleState.ETT_UnDetermined && !this.OnClueCheckToggleEnable())
			{
				return false;
			}
			bool flag = this.Proxy.GetCurrentClueLength() == 1;
			bool flag2 = this.CacheClueSet.Count < this.Proxy.GetCurrentClueLength() || this.CacheClueSet.Contains(id);
			if (!flag && !flag2)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Inference_Desc_31", Array.Empty<object>());
			}
			return flag || flag2;
		}

		// Token: 0x06034C07 RID: 216071 RVA: 0x00D3CE36 File Offset: 0x00D3B036
		private bool OnClueCheckToggleEnable()
		{
			return this.CurQuestionTabIndex == this.Proxy.GetCurQuestionIndex();
		}

		// Token: 0x06034C08 RID: 216072 RVA: 0x00D3CE4B File Offset: 0x00D3B04B
		private void OnClueHintStateChangeCallback()
		{
			this.RefreshCluePanel(false);
		}

		// Token: 0x06034C09 RID: 216073 RVA: 0x00D3CE54 File Offset: 0x00D3B054
		private void OnClickedReplayDialog()
		{
			SheriffMainProxy proxy = this.Proxy;
			if (proxy == null)
			{
				return;
			}
			proxy.ReplaySelectClueDialog();
		}

		// Token: 0x06034C0A RID: 216074 RVA: 0x00D3CE68 File Offset: 0x00D3B068
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
		{
			if (configParams.Length == 0)
			{
				return null;
			}
			if (!(configParams[0] == "SelectClue"))
			{
				return null;
			}
			int index = int.Parse(configParams[1]) - 1;
			GenericLayout<SheriffClueItem, int> clueLayout = this.ClueLayout;
			UUIItem uuiitem;
			if (clueLayout == null)
			{
				uuiitem = null;
			}
			else
			{
				SheriffClueItem layoutItemByIndex = clueLayout.GetLayoutItemByIndex(index);
				uuiitem = ((layoutItemByIndex != null) ? layoutItemByIndex.GetGuideMagnifierItem() : null);
			}
			UUIItem uuiitem2 = uuiitem;
			if (uuiitem2 == null)
			{
				return null;
			}
			return new UUIItem[]
			{
				uuiitem2,
				uuiitem2
			};
		}

		// Token: 0x0401E64A RID: 124490
		protected int CurQuestionTabIndex;

		// Token: 0x0401E64B RID: 124491
		[Nullable(2)]
		protected SheriffMainProxy Proxy;

		// Token: 0x0401E64C RID: 124492
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericLayout<SheriffQuestionTabItem, int> QuestionTabLayout;

		// Token: 0x0401E64D RID: 124493
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericLayout<SheriffSelectClueItem, int> SelectLayout;

		// Token: 0x0401E64E RID: 124494
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericLayout<SheriffSelectClueItem, int> SelectedLayout;

		// Token: 0x0401E64F RID: 124495
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericLayout<SheriffClueItem, int> ClueLayout;

		// Token: 0x0401E650 RID: 124496
		[Nullable(2)]
		private ButtonItem ConfirmBtn;

		// Token: 0x0401E651 RID: 124497
		protected List<int> AllClueIds = new List<int>();

		// Token: 0x0401E652 RID: 124498
		private readonly HashSet<int> CacheClueSet = new HashSet<int>();

		// Token: 0x0401E653 RID: 124499
		protected bool IsClueEnough = true;

		// Token: 0x0200AFC8 RID: 45000
		[NullableContext(0)]
		private static class EDefine
		{
			// Token: 0x040368B2 RID: 223410
			public const int PanelClue = 0;

			// Token: 0x040368B3 RID: 223411
			public const int ToggleSkyEyeClue = 1;

			// Token: 0x040368B4 RID: 223412
			public const int PanelTabQuestion = 2;

			// Token: 0x040368B5 RID: 223413
			public const int ToggleClueTab = 3;

			// Token: 0x040368B6 RID: 223414
			public const int PanelInfo = 4;

			// Token: 0x040368B7 RID: 223415
			public const int TxtTitle = 5;

			// Token: 0x040368B8 RID: 223416
			public const int TxtInfo = 6;

			// Token: 0x040368B9 RID: 223417
			public const int PanelTips = 7;

			// Token: 0x040368BA RID: 223418
			public const int SpriteLock = 8;

			// Token: 0x040368BB RID: 223419
			public const int TexUnlock = 9;

			// Token: 0x040368BC RID: 223420
			public const int TxtTipsTitle = 10;

			// Token: 0x040368BD RID: 223421
			public const int PanelSelectClue = 11;

			// Token: 0x040368BE RID: 223422
			public const int SelectClueLayout = 12;

			// Token: 0x040368BF RID: 223423
			public const int SelectClueItem = 13;

			// Token: 0x040368C0 RID: 223424
			public const int TxtClueNum = 14;

			// Token: 0x040368C1 RID: 223425
			public const int PanelSelectedClue = 15;

			// Token: 0x040368C2 RID: 223426
			public const int SelectedClueLayout = 16;

			// Token: 0x040368C3 RID: 223427
			public const int SelectedClueItem = 17;

			// Token: 0x040368C4 RID: 223428
			public const int BtnSkyEyeConfirm = 18;

			// Token: 0x040368C5 RID: 223429
			public const int PanelNotEnoughTips = 19;

			// Token: 0x040368C6 RID: 223430
			public const int TxtTips = 20;

			// Token: 0x040368C7 RID: 223431
			public const int BtnPageArrow = 21;
		}
	}
}
