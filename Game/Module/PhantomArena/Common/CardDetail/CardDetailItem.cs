using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Common.CardDetail
{
	// Token: 0x02005578 RID: 21880
	[NullableContext(1)]
	[Nullable(0)]
	public class CardDetailItem : UiPanelBase
	{
		// Token: 0x06037BF8 RID: 228344 RVA: 0x00E21D48 File Offset: 0x00E1FF48
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText)),
				new ValueTuple<int, Type>(1, typeof(UUIMultiTemplateLayout)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(6, typeof(UUILayoutBase)),
				new ValueTuple<int, Type>(7, typeof(UUIItem)),
				new ValueTuple<int, Type>(8, typeof(UUIItem)),
				new ValueTuple<int, Type>(9, typeof(UUIText)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIText)),
				new ValueTuple<int, Type>(10, typeof(UUIItem)),
				new ValueTuple<int, Type>(11, typeof(UUIItem)),
				new ValueTuple<int, Type>(12, typeof(UUIText)),
				new ValueTuple<int, Type>(13, typeof(UUILayoutBase)),
				new ValueTuple<int, Type>(14, typeof(UUIItem)),
				new ValueTuple<int, Type>(15, typeof(UUIItem)),
				new ValueTuple<int, Type>(16, typeof(UUIItem)),
				new ValueTuple<int, Type>(17, typeof(UUIItem)),
				new ValueTuple<int, Type>(18, typeof(UUIItem)),
				new ValueTuple<int, Type>(19, typeof(UUIItem))
			};
		}

		// Token: 0x06037BF9 RID: 228345 RVA: 0x00E21F24 File Offset: 0x00E20124
		private UniTask InitTaskItem()
		{
			CardDetailItem.<InitTaskItem>d__10 <InitTaskItem>d__;
			<InitTaskItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitTaskItem>d__.<>4__this = this;
			<InitTaskItem>d__.<>1__state = -1;
			<InitTaskItem>d__.<>t__builder.Start<CardDetailItem.<InitTaskItem>d__10>(ref <InitTaskItem>d__);
			return <InitTaskItem>d__.<>t__builder.Task;
		}

		// Token: 0x06037BFA RID: 228346 RVA: 0x00E21F68 File Offset: 0x00E20168
		private UniTask InitActiveSkillItem()
		{
			CardDetailItem.<InitActiveSkillItem>d__11 <InitActiveSkillItem>d__;
			<InitActiveSkillItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitActiveSkillItem>d__.<>4__this = this;
			<InitActiveSkillItem>d__.<>1__state = -1;
			<InitActiveSkillItem>d__.<>t__builder.Start<CardDetailItem.<InitActiveSkillItem>d__11>(ref <InitActiveSkillItem>d__);
			return <InitActiveSkillItem>d__.<>t__builder.Task;
		}

		// Token: 0x06037BFB RID: 228347 RVA: 0x00E21FAC File Offset: 0x00E201AC
		private UniTask InitPassiveSkillItem()
		{
			CardDetailItem.<InitPassiveSkillItem>d__12 <InitPassiveSkillItem>d__;
			<InitPassiveSkillItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitPassiveSkillItem>d__.<>4__this = this;
			<InitPassiveSkillItem>d__.<>1__state = -1;
			<InitPassiveSkillItem>d__.<>t__builder.Start<CardDetailItem.<InitPassiveSkillItem>d__12>(ref <InitPassiveSkillItem>d__);
			return <InitPassiveSkillItem>d__.<>t__builder.Task;
		}

		// Token: 0x06037BFC RID: 228348 RVA: 0x00E21FF0 File Offset: 0x00E201F0
		private UniTask InitLockItem()
		{
			CardDetailItem.<InitLockItem>d__13 <InitLockItem>d__;
			<InitLockItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitLockItem>d__.<>4__this = this;
			<InitLockItem>d__.<>1__state = -1;
			<InitLockItem>d__.<>t__builder.Start<CardDetailItem.<InitLockItem>d__13>(ref <InitLockItem>d__);
			return <InitLockItem>d__.<>t__builder.Task;
		}

		// Token: 0x06037BFD RID: 228349 RVA: 0x00E22034 File Offset: 0x00E20234
		private UniTask InitDurationItem()
		{
			CardDetailItem.<InitDurationItem>d__14 <InitDurationItem>d__;
			<InitDurationItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitDurationItem>d__.<>4__this = this;
			<InitDurationItem>d__.<>1__state = -1;
			<InitDurationItem>d__.<>t__builder.Start<CardDetailItem.<InitDurationItem>d__14>(ref <InitDurationItem>d__);
			return <InitDurationItem>d__.<>t__builder.Task;
		}

		// Token: 0x06037BFE RID: 228350 RVA: 0x00E22078 File Offset: 0x00E20278
		private UniTask InitRemainRoundItem()
		{
			CardDetailItem.<InitRemainRoundItem>d__15 <InitRemainRoundItem>d__;
			<InitRemainRoundItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitRemainRoundItem>d__.<>4__this = this;
			<InitRemainRoundItem>d__.<>1__state = -1;
			<InitRemainRoundItem>d__.<>t__builder.Start<CardDetailItem.<InitRemainRoundItem>d__15>(ref <InitRemainRoundItem>d__);
			return <InitRemainRoundItem>d__.<>t__builder.Task;
		}

		// Token: 0x06037BFF RID: 228351 RVA: 0x00E220BC File Offset: 0x00E202BC
		protected override UniTask OnBeforeStartAsync()
		{
			CardDetailItem.<OnBeforeStartAsync>d__16 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<CardDetailItem.<OnBeforeStartAsync>d__16>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06037C00 RID: 228352 RVA: 0x00E22100 File Offset: 0x00E20300
		protected override void OnStart()
		{
			this.AttributeLayout = new CardDetailAttributeLayoutItem(base.GetMultiTemplateLayout(1), base.GetItem(2));
			this.FactorDescLayout = new CardDetailFactorDescLayoutItem(base.GetLayoutBase(6), base.GetItem(7));
			base.GetItem(19).SetUIActive(false);
		}

		// Token: 0x06037C01 RID: 228353 RVA: 0x00E22150 File Offset: 0x00E20350
		public void Refresh(CardDetailItemData data)
		{
			this.Data = data;
			this.RefreshName();
			this.RefreshAttributeLayout(data.AttributeData);
			this.RefreshCardDesc(data.CardDescriptionData);
			this.RefreshFactorDescLayout(data.FactorDataList);
			this.RefreshBgDescription();
			this.RefreshTask(data.TaskData);
			this.RefreshActiveSkill(data.ActiveSkillData);
			this.RefreshPassiveSkill(data.PassiveSkillData);
			this.RefreshLock(data.LockData);
			this.RefreshDuration(data.DurationData);
			this.RefreshRemainRound(data.RemainRoundData);
		}

		// Token: 0x06037C02 RID: 228354 RVA: 0x00E221DC File Offset: 0x00E203DC
		public void RefreshName()
		{
			if (this.Data == null)
			{
				return;
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), this.Data.Name, Array.Empty<object>());
		}

		// Token: 0x06037C03 RID: 228355 RVA: 0x00E22208 File Offset: 0x00E20408
		public void RefreshAttributeLayout(ICardAttributeData attributeData)
		{
			if (attributeData == null)
			{
				CardDetailAttributeLayoutItem attributeLayout = this.AttributeLayout;
				if (attributeLayout == null)
				{
					return;
				}
				attributeLayout.SetLayoutActive(false);
				return;
			}
			else
			{
				CardDetailAttributeItemData item = new CardDetailAttributeItemData
				{
					AttributeName = "PhantomBattle_1001",
					AttributeValue = attributeData.Cost,
					IsHighLight = true
				};
				CardDetailAttributeItemData item2 = new CardDetailAttributeItemData
				{
					AttributeName = "PhantomBattle_1002",
					AttributeValue = attributeData.Attack,
					IsHighLight = false
				};
				CardDetailAttributeItemData item3 = new CardDetailAttributeItemData
				{
					AttributeName = "PhantomBattle_1003",
					AttributeValue = attributeData.Life,
					IsHighLight = false
				};
				List<CardDetailAttributeItemData> dataList = new List<CardDetailAttributeItemData>
				{
					item,
					item2,
					item3
				};
				CardDetailAttributeLayoutItem attributeLayout2 = this.AttributeLayout;
				if (attributeLayout2 != null)
				{
					attributeLayout2.SetLayoutActive(true);
				}
				CardDetailAttributeLayoutItem attributeLayout3 = this.AttributeLayout;
				if (attributeLayout3 == null)
				{
					return;
				}
				attributeLayout3.Refresh(dataList);
				return;
			}
		}

		// Token: 0x06037C04 RID: 228356 RVA: 0x00E222D4 File Offset: 0x00E204D4
		public void RefreshCardDesc(ICardDescriptionData cardDescriptionData)
		{
			if (cardDescriptionData == null)
			{
				base.GetItem(3).SetUIActive(false);
				base.GetItem(4).SetUIActive(false);
				return;
			}
			base.GetItem(3).SetUIActive(true);
			base.GetItem(4).SetUIActive(true);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), cardDescriptionData.Description, cardDescriptionData.DescriptionParams.ToArray());
		}

		// Token: 0x06037C05 RID: 228357 RVA: 0x00E2233C File Offset: 0x00E2053C
		public void RefreshFactorDescLayout(List<CardDetailFactorDescItemData> factorDataList)
		{
			if (factorDataList == null)
			{
				CardDetailFactorDescLayoutItem factorDescLayout = this.FactorDescLayout;
				if (factorDescLayout != null)
				{
					factorDescLayout.SetLayoutActive(false);
				}
				base.GetItem(8).SetUIActive(false);
				return;
			}
			bool flag = factorDataList.Count > 0;
			base.GetItem(8).SetUIActive(flag);
			base.GetLayoutBase(6).RootUIComp.Get().SetUIActive(flag);
			if (flag)
			{
				CardDetailFactorDescLayoutItem factorDescLayout2 = this.FactorDescLayout;
				if (factorDescLayout2 != null)
				{
					factorDescLayout2.SetLayoutActive(true);
				}
				CardDetailFactorDescLayoutItem factorDescLayout3 = this.FactorDescLayout;
				if (factorDescLayout3 == null)
				{
					return;
				}
				factorDescLayout3.Refresh(factorDataList);
			}
		}

		// Token: 0x06037C06 RID: 228358 RVA: 0x00E223C4 File Offset: 0x00E205C4
		public void RefreshBgDescription()
		{
			if (this.Data == null)
			{
				return;
			}
			string bgDescription = this.Data.BgDescription;
			if (bgDescription != null && !StringUtils.IsBlank(bgDescription))
			{
				base.GetItem(10).SetUIActive(true);
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(9), bgDescription, Array.Empty<object>());
				return;
			}
			base.GetItem(10).SetUIActive(false);
		}

		// Token: 0x06037C07 RID: 228359 RVA: 0x00E2242C File Offset: 0x00E2062C
		private void RefreshTask(ICardDetailTaskData taskData)
		{
			if (taskData == null)
			{
				base.GetItem(11).SetUIActive(false);
				base.GetLayoutBase(13).RootUIComp.Get().SetUIActive(false);
				return;
			}
			base.GetItem(11).SetUIActive(true);
			base.GetLayoutBase(13).RootUIComp.Get().SetUIActive(true);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(12), "PhantomBattle_1081", Array.Empty<object>());
			CardDetailTaskDescItem taskDescItem = this.TaskDescItem;
			if (taskDescItem == null)
			{
				return;
			}
			taskDescItem.Refresh(taskData);
		}

		// Token: 0x06037C08 RID: 228360 RVA: 0x00E224BC File Offset: 0x00E206BC
		private void RefreshActiveSkill(ICardDetailActiveSkillData activeSkillData)
		{
			if (activeSkillData == null)
			{
				base.GetItem(15).SetUIActive(false);
				return;
			}
			base.GetItem(15).SetUIActive(true);
			CardDetailActiveSkillItem activeSkillItem = this.ActiveSkillItem;
			if (activeSkillItem == null)
			{
				return;
			}
			activeSkillItem.Refresh(activeSkillData);
		}

		// Token: 0x06037C09 RID: 228361 RVA: 0x00E224EF File Offset: 0x00E206EF
		private void RefreshPassiveSkill(ICardDetailPassiveSkillData passiveSkillData)
		{
			if (passiveSkillData == null)
			{
				base.GetItem(16).SetUIActive(false);
				return;
			}
			base.GetItem(16).SetUIActive(true);
			CardDetailPassiveSkillItem passiveSkillItem = this.PassiveSkillItem;
			if (passiveSkillItem == null)
			{
				return;
			}
			passiveSkillItem.Refresh(passiveSkillData);
		}

		// Token: 0x06037C0A RID: 228362 RVA: 0x00E22522 File Offset: 0x00E20722
		private void RefreshLock(ICardDetailLockData lockData)
		{
			if (lockData == null)
			{
				base.GetItem(17).SetUIActive(false);
				return;
			}
			base.GetItem(17).SetUIActive(true);
			CardDetailLockItem lockItem = this.LockItem;
			if (lockItem == null)
			{
				return;
			}
			lockItem.Refresh(lockData);
		}

		// Token: 0x06037C0B RID: 228363 RVA: 0x00E22555 File Offset: 0x00E20755
		private void RefreshDuration(ICardDetailDurationData durationData)
		{
			if (durationData == null)
			{
				base.GetItem(18).SetUIActive(false);
				return;
			}
			base.GetItem(18).SetUIActive(true);
			CardDetailDurationItem durationItem = this.DurationItem;
			if (durationItem == null)
			{
				return;
			}
			durationItem.Refresh(durationData);
		}

		// Token: 0x06037C0C RID: 228364 RVA: 0x00E22588 File Offset: 0x00E20788
		private void RefreshRemainRound(ICardDetailRemainRoundData remainRoundData)
		{
			if (remainRoundData == null)
			{
				base.GetItem(19).SetUIActive(false);
				return;
			}
			base.GetItem(19).SetUIActive(true);
			CardDetailRemainRoundItem remainRoundItem = this.RemainRoundItem;
			if (remainRoundItem == null)
			{
				return;
			}
			remainRoundItem.Refresh(remainRoundData);
		}

		// Token: 0x06037C0D RID: 228365 RVA: 0x00E225BC File Offset: 0x00E207BC
		public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
		{
			if (configParams == null || configParams.Length == 0)
			{
				return null;
			}
			string a = configParams[0];
			if (a == "CardEffect")
			{
				CardDetailFactorDescLayoutItem factorDescLayout = this.FactorDescLayout;
				if (factorDescLayout == null)
				{
					return null;
				}
				return factorDescLayout.GetGuideUiItemAndUiItemForShowEx(configParams);
			}
			else if (a == "CardAttr")
			{
				UUIMultiTemplateLayout multiTemplateLayout = base.GetMultiTemplateLayout(1);
				UUIItem uuiitem = (multiTemplateLayout != null) ? multiTemplateLayout.GetRootComponent() : null;
				if (uuiitem == null)
				{
					return null;
				}
				return new UUIItem[]
				{
					uuiitem,
					uuiitem
				};
			}
			else
			{
				if (!(a == "Task"))
				{
					return null;
				}
				CardDetailTaskDescItem taskDescItem = this.TaskDescItem;
				UUIItem uuiitem2 = (taskDescItem != null) ? taskDescItem.GetRootItem() : null;
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
		}

		// Token: 0x0401FEAF RID: 130735
		private CardDetailItemData Data;

		// Token: 0x0401FEB0 RID: 130736
		private CardDetailAttributeLayoutItem AttributeLayout;

		// Token: 0x0401FEB1 RID: 130737
		private CardDetailFactorDescLayoutItem FactorDescLayout;

		// Token: 0x0401FEB2 RID: 130738
		private CardDetailTaskDescItem TaskDescItem;

		// Token: 0x0401FEB3 RID: 130739
		private CardDetailActiveSkillItem ActiveSkillItem;

		// Token: 0x0401FEB4 RID: 130740
		private CardDetailPassiveSkillItem PassiveSkillItem;

		// Token: 0x0401FEB5 RID: 130741
		private CardDetailLockItem LockItem;

		// Token: 0x0401FEB6 RID: 130742
		private CardDetailDurationItem DurationItem;

		// Token: 0x0401FEB7 RID: 130743
		private CardDetailRemainRoundItem RemainRoundItem;

		// Token: 0x0200B51C RID: 46364
		[NullableContext(0)]
		private static class EComponents
		{
			// Token: 0x040380F7 RID: 229623
			public const int NameText = 0;

			// Token: 0x040380F8 RID: 229624
			public const int AttributeLayout = 1;

			// Token: 0x040380F9 RID: 229625
			public const int AttributeItem = 2;

			// Token: 0x040380FA RID: 229626
			public const int CardDescTitleItem = 3;

			// Token: 0x040380FB RID: 229627
			public const int CardDescItem = 4;

			// Token: 0x040380FC RID: 229628
			public const int CardDescText = 5;

			// Token: 0x040380FD RID: 229629
			public const int FactorDescLayout = 6;

			// Token: 0x040380FE RID: 229630
			public const int FactorDescItem = 7;

			// Token: 0x040380FF RID: 229631
			public const int FactorTitleItem = 8;

			// Token: 0x04038100 RID: 229632
			public const int BgDescText = 9;

			// Token: 0x04038101 RID: 229633
			public const int BgDescRootItem = 10;

			// Token: 0x04038102 RID: 229634
			public const int TaskTitleItem = 11;

			// Token: 0x04038103 RID: 229635
			public const int TaskTitleText = 12;

			// Token: 0x04038104 RID: 229636
			public const int TaskDescLayout = 13;

			// Token: 0x04038105 RID: 229637
			public const int TaskDescItem = 14;

			// Token: 0x04038106 RID: 229638
			public const int ActiveSkillItem = 15;

			// Token: 0x04038107 RID: 229639
			public const int PassiveSkillItem = 16;

			// Token: 0x04038108 RID: 229640
			public const int LockItem = 17;

			// Token: 0x04038109 RID: 229641
			public const int DurationItem = 18;

			// Token: 0x0403810A RID: 229642
			public const int RemainRoundItem = 19;
		}
	}
}
