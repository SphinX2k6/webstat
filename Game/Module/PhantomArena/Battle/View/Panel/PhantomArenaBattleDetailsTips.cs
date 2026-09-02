using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.PhantomArena.Battle.Model;
using CSharpScript.Game.Module.PhantomArena.Common.CardDetail;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Battle.View.Panel
{
	// Token: 0x020055B8 RID: 21944
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomArenaBattleDetailsTips : UiPanelBase
	{
		// Token: 0x06037DE3 RID: 228835 RVA: 0x00E27BAC File Offset: 0x00E25DAC
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUILayoutBase)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(6, typeof(UUIButtonComponent))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(5, new Action(this.OnCardDescBtnClick)),
				new ValueTuple<int, Delegate>(6, new Action(this.OnClickBottomMask))
			};
		}

		// Token: 0x06037DE4 RID: 228836 RVA: 0x00E27C9C File Offset: 0x00E25E9C
		protected UniTask InitDetailsItem()
		{
			PhantomArenaBattleDetailsTips.<InitDetailsItem>d__15 <InitDetailsItem>d__;
			<InitDetailsItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitDetailsItem>d__.<>4__this = this;
			<InitDetailsItem>d__.<>1__state = -1;
			<InitDetailsItem>d__.<>t__builder.Start<PhantomArenaBattleDetailsTips.<InitDetailsItem>d__15>(ref <InitDetailsItem>d__);
			return <InitDetailsItem>d__.<>t__builder.Task;
		}

		// Token: 0x06037DE5 RID: 228837 RVA: 0x00E27CE0 File Offset: 0x00E25EE0
		protected UniTask InitMaskButton()
		{
			PhantomArenaBattleDetailsTips.<InitMaskButton>d__16 <InitMaskButton>d__;
			<InitMaskButton>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitMaskButton>d__.<>4__this = this;
			<InitMaskButton>d__.<>1__state = -1;
			<InitMaskButton>d__.<>t__builder.Start<PhantomArenaBattleDetailsTips.<InitMaskButton>d__16>(ref <InitMaskButton>d__);
			return <InitMaskButton>d__.<>t__builder.Task;
		}

		// Token: 0x06037DE6 RID: 228838 RVA: 0x00E27D24 File Offset: 0x00E25F24
		protected override UniTask OnBeforeStartAsync()
		{
			PhantomArenaBattleDetailsTips.<OnBeforeStartAsync>d__17 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<PhantomArenaBattleDetailsTips.<OnBeforeStartAsync>d__17>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06037DE7 RID: 228839 RVA: 0x00E27D68 File Offset: 0x00E25F68
		protected override void OnStart()
		{
			UUIButtonComponent button = base.GetButton(6);
			if (button != null)
			{
				button.RootUIComp.Get().SetUIActive(false);
			}
			this.Sequence = new UiSequencePlayer(this.RootItem);
			this.Sequence.BindOnEndSequenceEvent(new Action<string>(this.SequenceEnd));
			this.EntryDescLayoutItem = new CardDetailEntryDescLayoutItem(base.GetLayoutBase(3), base.GetItem(4));
		}

		// Token: 0x06037DE8 RID: 228840 RVA: 0x00E27DD6 File Offset: 0x00E25FD6
		protected override void OnBeforeDestroy()
		{
			this.Sequence.Clear();
			DynamicMaskButton maskButton = this.MaskButton;
			if (maskButton != null)
			{
				maskButton.Destroy(null);
			}
			this.RemoveTimeHandler();
		}

		// Token: 0x06037DE9 RID: 228841 RVA: 0x00E27DFB File Offset: 0x00E25FFB
		private void SequenceEnd(string sequenceName)
		{
			if (sequenceName == "Close")
			{
				this.SetActive(false);
			}
		}

		// Token: 0x06037DEA RID: 228842 RVA: 0x00E27E14 File Offset: 0x00E26014
		public unsafe void RefreshByTaskData(PhantomArenaCardTaskData taskData)
		{
			PhantomBattleCard phantomBattleCardConfig = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleCardConfig(taskData.TaskCardConfigId);
			Dictionary<int, int> dictionary = phantomBattleCardConfig.InitAttack();
			int num;
			int attack = dictionary.TryGetValue(0, out num) ? num : 0;
			int num2;
			int life = dictionary.TryGetValue(1, out num2) ? num2 : 0;
			List<CardDetailFactorDescItemData> list = new List<CardDetailFactorDescItemData>();
			Span<int> cardFactorIdBytes = phantomBattleCardConfig.GetCardFactorIdBytes();
			for (int i = 0; i < cardFactorIdBytes.Length; i++)
			{
				int factorConfigId = *cardFactorIdBytes[i];
				list.Add(new CardDetailFactorDescItemData
				{
					FactorConfigId = factorConfigId,
					IsActive = false
				});
			}
			PhantomBattleFourCTask phantomArenaFourTask = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomArenaFourTask(taskData.TaskCardConfigId);
			int conditionDescCurrentProgress = taskData.GetConditionDescCurrentProgress(phantomArenaFourTask.TaskDescConditionId);
			CardDetailTaskData taskData2 = new CardDetailTaskData
			{
				Desc = phantomArenaFourTask.TaskDesc,
				CurrentProgress = conditionDescCurrentProgress
			};
			CardAttributeData attributeData = new CardAttributeData
			{
				Cost = phantomBattleCardConfig.Cost,
				Attack = attack,
				Life = life
			};
			CardDescriptionData cardDescriptionData = new CardDescriptionData
			{
				Description = phantomBattleCardConfig.CardEffectDescription,
				DescriptionParams = phantomBattleCardConfig.CardEffectDescriptionParams().ToList<string>()
			};
			CardDetailItemData data = new CardDetailItemData
			{
				Name = phantomBattleCardConfig.Name,
				AttributeData = attributeData,
				CardDescriptionData = cardDescriptionData,
				FactorDataList = list,
				TaskData = taskData2
			};
			this.DetailItem.Refresh(data);
			this.EntryDescLayoutItem.RefreshByCardConfig(phantomBattleCardConfig);
		}

		// Token: 0x06037DEB RID: 228843 RVA: 0x00E27F80 File Offset: 0x00E26180
		private List<CardDetailFactorDescItemData> GetFactorDataList(PhantomCardData cardData)
		{
			if (cardData.IsTool)
			{
				return new List<CardDetailFactorDescItemData>();
			}
			List<CardDetailFactorDescItemData> list = new List<CardDetailFactorDescItemData>();
			foreach (int factorConfigId in cardData.ExtraFactors)
			{
				list.Add(new CardDetailFactorDescItemData
				{
					FactorConfigId = factorConfigId,
					IsActive = true
				});
			}
			foreach (int factorConfigId2 in cardData.UnActiveFactors)
			{
				list.Add(new CardDetailFactorDescItemData
				{
					FactorConfigId = factorConfigId2,
					IsActive = false
				});
			}
			return list;
		}

		// Token: 0x06037DEC RID: 228844 RVA: 0x00E28058 File Offset: 0x00E26258
		private CardAttributeData GetAttributeData(PhantomCardData cardData)
		{
			if (cardData.IsTool)
			{
				return null;
			}
			int fightValueByAttr = cardData.GetFightValueByAttr(PhantomBattleCardAttr.AttackAbility);
			int fightValueByAttr2 = cardData.GetFightValueByAttr(PhantomBattleCardAttr.LifeAbility);
			int fightValueByAttr3 = cardData.GetFightValueByAttr(PhantomBattleCardAttr.CostAbility);
			return new CardAttributeData
			{
				Cost = fightValueByAttr3,
				Attack = fightValueByAttr,
				Life = fightValueByAttr2
			};
		}

		// Token: 0x06037DED RID: 228845 RVA: 0x00E280A4 File Offset: 0x00E262A4
		private CardDescriptionData GetCardDescriptionData(PhantomCardData cardData)
		{
			if (cardData.IsTool)
			{
				return null;
			}
			PhantomBattleCard phantomBattleCardConfig = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleCardConfig(cardData.ConfigId);
			return new CardDescriptionData
			{
				Description = phantomBattleCardConfig.CardEffectDescription,
				DescriptionParams = phantomBattleCardConfig.CardEffectDescriptionParams().ToList<string>()
			};
		}

		// Token: 0x06037DEE RID: 228846 RVA: 0x00E280F0 File Offset: 0x00E262F0
		private CardDetailDurationData GetDurationData(PhantomCardData cardData)
		{
			if (cardData.HasDurability)
			{
				return new CardDetailDurationData
				{
					DurationDesc = cardData.Durable.ToString() + "/" + cardData.DurableMax.ToString()
				};
			}
			return null;
		}

		// Token: 0x06037DEF RID: 228847 RVA: 0x00E28138 File Offset: 0x00E26338
		private CardDetailActiveSkillData GetActiveSkillData(PhantomCardData cardData)
		{
			if (cardData.HasClickActiveSkill)
			{
				PhantomBattleCard phantomBattleCardConfig = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleCardConfig(cardData.ConfigId);
				return new CardDetailActiveSkillData
				{
					Desc = phantomBattleCardConfig.DurableSkillDescription,
					Params = phantomBattleCardConfig.DurableSkillDescriptionParams().ToList<string>()
				};
			}
			return null;
		}

		// Token: 0x06037DF0 RID: 228848 RVA: 0x00E28184 File Offset: 0x00E26384
		private CardDetailPassiveSkillData GetPassiveSkillData(PhantomCardData cardData)
		{
			if (cardData.IsField)
			{
				PhantomBattleCard phantomBattleCardConfig = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleCardConfig(cardData.ConfigId);
				string textKey = (!(cardData.IsNpcCard ? ModelBase<PhantomArenaBattleModel>.Instance.OpponentData.IsFieldActive : ModelBase<PhantomArenaBattleModel>.Instance.OwnData.IsFieldActive)) ? "PhantomBattle_1143" : "PhantomBattle_1144";
				CardDetailConditionInData inData = new CardDetailConditionInData
				{
					TextArg = new TableTextArgNew(textKey, Array.Empty<object>())
				};
				CardDetailPassiveSkillFieldData fieldData = new CardDetailPassiveSkillFieldData
				{
					InData = inData
				};
				CardDetailEffectCountData effectCountData = null;
				if (cardData.HasCountSkill)
				{
					effectCountData = new CardDetailEffectCountData
					{
						CurrentEffectCount = cardData.CurEffectCount,
						TotalEffectCount = cardData.MaxEffectCount
					};
				}
				return new CardDetailPassiveSkillData
				{
					Desc = (cardData.HasCountSkill ? phantomBattleCardConfig.CountSkillDescription : phantomBattleCardConfig.CardEffectDescription),
					Params = (cardData.HasCountSkill ? phantomBattleCardConfig.CountSkillDescriptionParams().ToList<string>() : phantomBattleCardConfig.CardEffectDescriptionParams().ToList<string>()),
					FieldData = fieldData,
					EffectCountData = effectCountData
				};
			}
			return null;
		}

		// Token: 0x06037DF1 RID: 228849 RVA: 0x00E28290 File Offset: 0x00E26490
		private CardDetailPassiveSkillData GetCountSkillData(PhantomCardData cardData)
		{
			if (cardData.HasCountSkill)
			{
				PhantomBattleCard phantomBattleCardConfig = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleCardConfig(cardData.ConfigId);
				CardDetailEffectCountData effectCountData = new CardDetailEffectCountData
				{
					CurrentEffectCount = cardData.CurEffectCount,
					TotalEffectCount = cardData.MaxEffectCount
				};
				return new CardDetailPassiveSkillData
				{
					Desc = phantomBattleCardConfig.CountSkillDescription,
					Params = phantomBattleCardConfig.CountSkillDescriptionParams().ToList<string>(),
					EffectCountData = effectCountData
				};
			}
			return null;
		}

		// Token: 0x06037DF2 RID: 228850 RVA: 0x00E28301 File Offset: 0x00E26501
		private CardDetailRemainRoundData GetRemainRoundData(PhantomCardData cardData)
		{
			if (cardData.IsCopy)
			{
				return new CardDetailRemainRoundData
				{
					RemainRound = 1
				};
			}
			return null;
		}

		// Token: 0x06037DF3 RID: 228851 RVA: 0x00E2831C File Offset: 0x00E2651C
		private void RefreshByNormalCardData(PhantomCardData cardData)
		{
			List<CardDetailFactorDescItemData> factorDataList = this.GetFactorDataList(cardData);
			CardAttributeData attributeData = this.GetAttributeData(cardData);
			CardDescriptionData cardDescriptionData = this.GetCardDescriptionData(cardData);
			CardDetailDurationData durationData = this.GetDurationData(cardData);
			CardDetailActiveSkillData activeSkillData = this.GetActiveSkillData(cardData);
			CardDetailPassiveSkillData countSkillData = this.GetCountSkillData(cardData);
			CardDetailRemainRoundData remainRoundData = this.GetRemainRoundData(cardData);
			PhantomBattleCard phantomBattleCardConfig = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleCardConfig(cardData.ConfigId);
			CardDetailItemData data = new CardDetailItemData
			{
				Name = phantomBattleCardConfig.Name,
				AttributeData = attributeData,
				CardDescriptionData = cardDescriptionData,
				FactorDataList = factorDataList,
				DurationData = durationData,
				ActiveSkillData = activeSkillData,
				PassiveSkillData = countSkillData,
				RemainRoundData = remainRoundData
			};
			this.DetailItem.Refresh(data);
			this.EntryDescLayoutItem.RefreshByCardConfig(phantomBattleCardConfig);
		}

		// Token: 0x06037DF4 RID: 228852 RVA: 0x00E283D8 File Offset: 0x00E265D8
		private void RefreshByFieldCardData(PhantomCardData cardData)
		{
			CardDetailActiveSkillData activeSkillData = this.GetActiveSkillData(cardData);
			CardDetailPassiveSkillData passiveSkillData = this.GetPassiveSkillData(cardData);
			PhantomBattleCard phantomBattleCardConfig = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleCardConfig(cardData.ConfigId);
			CardDetailItemData data = new CardDetailItemData
			{
				Name = phantomBattleCardConfig.Name,
				ActiveSkillData = activeSkillData,
				PassiveSkillData = passiveSkillData
			};
			this.DetailItem.Refresh(data);
			this.EntryDescLayoutItem.RefreshByCardConfig(phantomBattleCardConfig);
		}

		// Token: 0x06037DF5 RID: 228853 RVA: 0x00E28440 File Offset: 0x00E26640
		private void CalculateTriggerItemPosition(UUIItem triggerItem)
		{
			if (triggerItem != null)
			{
				global::Vector tempWorldPos = this.TempWorldPos;
				FVectorDouble fvectorDouble = triggerItem.D_K2_GetComponentLocation();
				tempWorldPos.FromUeVector(fvectorDouble);
				global::Transform itemWorldTrans = this.ItemWorldTrans;
				FTransform ftransform = this.ParentUiItem.K2_GetComponentToWorld();
				itemWorldTrans.FromUeTransform(ftransform);
				this.ItemWorldTrans.InverseTransformPosition(this.TempWorldPos, this.TempWorldPos);
				UUIItem originalItem = this.GetOriginalItem();
				if (originalItem == null)
				{
					return;
				}
				originalItem.SetUIRelativeLocation(this.TempWorldPos.ToUeVectorOld());
			}
		}

		// Token: 0x06037DF6 RID: 228854 RVA: 0x00E284B0 File Offset: 0x00E266B0
		private void RefreshPivotAndOffset(IPhantomArenaBattleDetailsTipsData tipsData)
		{
			this.ShowType = tipsData.ShowType;
			if (tipsData.PositionType == EPhantomArenaBattleDetailsPositionType.LeftTop)
			{
				base.GetItem(0).SetHierarchyIndex(0);
				this.SetPivotAndResetOffset(0f, 1f);
				return;
			}
			if (tipsData.PositionType == EPhantomArenaBattleDetailsPositionType.RightTop)
			{
				base.GetItem(1).SetHierarchyIndex(0);
				this.SetPivotAndResetOffset(1f, 1f);
				return;
			}
			if (tipsData.PositionType == EPhantomArenaBattleDetailsPositionType.LeftBottom)
			{
				base.GetItem(0).SetHierarchyIndex(0);
				this.SetPivotAndResetOffset(0f, 0f);
				return;
			}
			base.GetItem(1).SetHierarchyIndex(0);
			this.SetPivotAndResetOffset(1f, 0f);
		}

		// Token: 0x06037DF7 RID: 228855 RVA: 0x00E2855A File Offset: 0x00E2675A
		private void AddTimeHandler()
		{
			this.RemoveTimeHandler();
			this.TimerHandle = TimerSystem.GameplayTimeInstance.Forever(delegate(float _)
			{
				this.CheckMouseInTip();
			}, 100f, 1f, null, null, true);
		}

		// Token: 0x06037DF8 RID: 228856 RVA: 0x00E2858B File Offset: 0x00E2678B
		private void RemoveTimeHandler()
		{
			if (this.TimerHandle != null)
			{
				TimerSystem.GameplayTimeInstance.Remove(this.TimerHandle);
				this.TimerHandle = null;
			}
		}

		// Token: 0x06037DF9 RID: 228857 RVA: 0x00E285B0 File Offset: 0x00E267B0
		private void ShowTips()
		{
			this.RemoveTimeHandler();
			this.SetActive(true);
			this.Sequence.StopPrevSequence(false, true);
			this.Sequence.PlaySequence("Start", false, null);
		}

		// Token: 0x06037DFA RID: 228858 RVA: 0x00E285F4 File Offset: 0x00E267F4
		private void HideTips()
		{
			this.RemoveTimeHandler();
			this.Sequence.StopPrevSequence(false, true);
			this.Sequence.PlaySequence("Close", false, null);
			this.ShowType = EPhantomArenaBattleDetailsTipsShowType.None;
		}

		// Token: 0x06037DFB RID: 228859 RVA: 0x00E28638 File Offset: 0x00E26838
		private void CheckMouseInTip()
		{
			if (this.RootItem == null)
			{
				this.RemoveTimeHandler();
				return;
			}
			ULGUIPointerEventData pointerEventData = Singleton<LguiEventSystemManager>.Instance.GetPointerEventData(0, true);
			if (pointerEventData == null || !pointerEventData.enterComponentStack.Contains(this.RootItem))
			{
				this.HideTips();
			}
		}

		// Token: 0x06037DFC RID: 228860 RVA: 0x00E2867D File Offset: 0x00E2687D
		public void RefreshByCardData(PhantomCardData cardData)
		{
			if (cardData.IsField)
			{
				this.RefreshByFieldCardData(cardData);
				return;
			}
			this.RefreshByNormalCardData(cardData);
		}

		// Token: 0x06037DFD RID: 228861 RVA: 0x00E28696 File Offset: 0x00E26896
		public void SetTipsPositionByAttachItem(IPhantomArenaBattleDetailsTipsData tipsData)
		{
			UUIItem originalItem = this.GetOriginalItem();
			if (originalItem != null)
			{
				originalItem.SetUIParent(tipsData.AttachItem, false);
			}
			this.RefreshPivotAndOffset(tipsData);
		}

		// Token: 0x06037DFE RID: 228862 RVA: 0x00E286B7 File Offset: 0x00E268B7
		public void SetTipsPositionByTriggerItem(IPhantomArenaBattleDetailsTipsData tipsData)
		{
			this.RefreshPivotAndOffset(tipsData);
			this.CalculateTriggerItemPosition(tipsData.TriggerItem);
		}

		// Token: 0x06037DFF RID: 228863 RVA: 0x00E286CC File Offset: 0x00E268CC
		public void SetTipsActive(EPhantomArenaBattleShowTipsType showType)
		{
			bool flag = showType == EPhantomArenaBattleShowTipsType.DetailsTips || showType == EPhantomArenaBattleShowTipsType.FieldDetailsTips;
			if (this.IsInActive == flag)
			{
				return;
			}
			this.IsInActive = flag;
			EPhantomArenaBattleShowTipsType showTipsType = this.ShowTipsType;
			this.ShowTipsType = showType;
			if (this.IsInActive)
			{
				this.ShowTips();
				return;
			}
			if (showTipsType == EPhantomArenaBattleShowTipsType.DetailsTips)
			{
				this.HideTips();
				return;
			}
			if (showTipsType == EPhantomArenaBattleShowTipsType.FieldDetailsTips)
			{
				this.AddTimeHandler();
			}
		}

		// Token: 0x06037E00 RID: 228864 RVA: 0x00E28728 File Offset: 0x00E26928
		public void SetPivotAndResetOffset(float pivotX, float pivotY)
		{
			UUIItem originalItem = this.GetOriginalItem();
			if (originalItem != null)
			{
				originalItem.SetPivot(new FVector2D(pivotX, pivotY));
			}
			UUIItem originalItem2 = this.GetOriginalItem();
			if (originalItem2 == null)
			{
				return;
			}
			originalItem2.SetAnchorOffset(new FVector2D(0f, 0f));
		}

		// Token: 0x06037E01 RID: 228865 RVA: 0x00E28761 File Offset: 0x00E26961
		private void ShowMaskButton()
		{
			this.MaskButton.SetActive(true);
		}

		// Token: 0x06037E02 RID: 228866 RVA: 0x00E2876F File Offset: 0x00E2696F
		private void HideMaskButton()
		{
			this.MaskButton.SetActive(false);
		}

		// Token: 0x06037E03 RID: 228867 RVA: 0x00E2877D File Offset: 0x00E2697D
		public void SetMaskAttach(UUIItem uiItem)
		{
			this.MaskAttach = uiItem;
		}

		// Token: 0x06037E04 RID: 228868 RVA: 0x00E28786 File Offset: 0x00E26986
		public void ShowEntry()
		{
			if (this.IsEntryShow)
			{
				return;
			}
			this.IsEntryShow = true;
			this.RefreshEntryShowState();
		}

		// Token: 0x06037E05 RID: 228869 RVA: 0x00E2879E File Offset: 0x00E2699E
		public void HideEntry()
		{
			if (!this.IsEntryShow)
			{
				return;
			}
			this.IsEntryShow = false;
			this.RefreshEntryShowState();
		}

		// Token: 0x06037E06 RID: 228870 RVA: 0x00E287B6 File Offset: 0x00E269B6
		public void RefreshEntryShowState()
		{
			base.GetItem(1).SetUIActive(this.IsEntryShow);
		}

		// Token: 0x06037E07 RID: 228871 RVA: 0x00E287CA File Offset: 0x00E269CA
		private void OnCardDescBtnClick()
		{
			this.ShowEntry();
			this.ShowMaskButton();
		}

		// Token: 0x06037E08 RID: 228872 RVA: 0x00E287D8 File Offset: 0x00E269D8
		private void OnMaskBtnClick()
		{
			this.HideEntry();
			this.HideMaskButton();
		}

		// Token: 0x06037E09 RID: 228873 RVA: 0x00E287E8 File Offset: 0x00E269E8
		public void SetBtnMaskCallback(Action cb)
		{
			this.BtnBottomCb = cb;
			UUIButtonComponent button = base.GetButton(6);
			if (button == null)
			{
				return;
			}
			button.RootUIComp.Get().SetUIActive(true);
		}

		// Token: 0x06037E0A RID: 228874 RVA: 0x00E2881B File Offset: 0x00E26A1B
		private void OnClickBottomMask()
		{
			Action btnBottomCb = this.BtnBottomCb;
			if (btnBottomCb == null)
			{
				return;
			}
			btnBottomCb();
		}

		// Token: 0x06037E0B RID: 228875 RVA: 0x00E28830 File Offset: 0x00E26A30
		public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
		{
			if (configParams == null || configParams.Length == 0)
			{
				return null;
			}
			string a = configParams[0];
			if (a == "CardEffect" || a == "CardAttr" || a == "Task")
			{
				CardDetailItem detailItem = this.DetailItem;
				if (detailItem == null)
				{
					return null;
				}
				return detailItem.GetGuideUiItemAndUiItemForShowEx(configParams);
			}
			else
			{
				if (!(a == "CardFullInfo"))
				{
					return null;
				}
				UUIItem item = base.GetItem(0);
				if (item == null)
				{
					return null;
				}
				return new UUIItem[]
				{
					item,
					item
				};
			}
		}

		// Token: 0x0401FF9E RID: 130974
		protected CardDetailItem DetailItem;

		// Token: 0x0401FF9F RID: 130975
		protected CardDetailEntryDescLayoutItem EntryDescLayoutItem;

		// Token: 0x0401FFA0 RID: 130976
		protected UiSequencePlayer Sequence;

		// Token: 0x0401FFA1 RID: 130977
		protected DynamicMaskButton MaskButton;

		// Token: 0x0401FFA2 RID: 130978
		protected UUIItem MaskAttach;

		// Token: 0x0401FFA3 RID: 130979
		protected bool IsEntryShow;

		// Token: 0x0401FFA4 RID: 130980
		public EPhantomArenaBattleShowTipsType ShowTipsType;

		// Token: 0x0401FFA5 RID: 130981
		public bool IsInActive;

		// Token: 0x0401FFA6 RID: 130982
		public EPhantomArenaBattleDetailsTipsShowType ShowType;

		// Token: 0x0401FFA7 RID: 130983
		protected Action BtnBottomCb;

		// Token: 0x0401FFA8 RID: 130984
		protected readonly global::Vector TempWorldPos = global::Vector.Create();

		// Token: 0x0401FFA9 RID: 130985
		protected readonly global::Transform ItemWorldTrans = global::Transform.Create();

		// Token: 0x0401FFAA RID: 130986
		protected TimerHandle TimerHandle;

		// Token: 0x0200B576 RID: 46454
		[NullableContext(0)]
		private class EComponentDefine
		{
			// Token: 0x04038280 RID: 230016
			public const int DescRootItem = 0;

			// Token: 0x04038281 RID: 230017
			public const int EntryRootItem = 1;

			// Token: 0x04038282 RID: 230018
			public const int CardDetailsItem = 2;

			// Token: 0x04038283 RID: 230019
			public const int EntryDescLayout = 3;

			// Token: 0x04038284 RID: 230020
			public const int EntryDescLayoutItem = 4;

			// Token: 0x04038285 RID: 230021
			public const int CardDescBtn = 5;

			// Token: 0x04038286 RID: 230022
			public const int BtnMask = 6;
		}
	}
}
