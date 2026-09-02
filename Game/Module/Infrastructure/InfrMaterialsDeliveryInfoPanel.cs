using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Infrastructure
{
	// Token: 0x02005C63 RID: 23651
	[NullableContext(1)]
	[Nullable(0)]
	public class InfrMaterialsDeliveryInfoPanel : UiPanelBase
	{
		// Token: 0x0603BC00 RID: 244736 RVA: 0x00F23AFC File Offset: 0x00F21CFC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 42;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(14, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(17, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(18, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(19, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(20, typeof(UUIVerticalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(21, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(22, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(23, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(24, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(25, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(26, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(27, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(28, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(29, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(30, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(31, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(32, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(33, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(34, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(35, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(36, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(37, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(38, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(39, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(40, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(41, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 3;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(4, new Action(this.OnClickEllipsisExpand));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(35, new Action(this.OnClickEllipsisFold));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(36, new Action(this.OnClickClose));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603BC01 RID: 244737 RVA: 0x00F24134 File Offset: 0x00F22334
		private InfrRoadBuild GetRoadConfig()
		{
			return ConfigBase<InfrastructureConfig>.Instance.GetRoadConfigById(this.RoadId).Value;
		}

		// Token: 0x0603BC02 RID: 244738 RVA: 0x00F2415C File Offset: 0x00F2235C
		private InfrLevel GetObservatoryConfig()
		{
			return ConfigBase<InfrastructureConfig>.Instance.GetLevelConfigById(ModelBase<InfrastructureModel>.Instance.FireLevel).Value;
		}

		// Token: 0x0603BC03 RID: 244739 RVA: 0x00F24188 File Offset: 0x00F22388
		[return: Nullable(new byte[]
		{
			1,
			0
		})]
		private List<ValueTuple<int, int>> GetRequirementList()
		{
			if (this.DeliveryType == ActionInfrastructureItemDeliveryType.Road)
			{
				List<ValueTuple<int, int>> list = new List<ValueTuple<int, int>>();
				foreach (DicIntInt dicIntInt in this.GetRoadConfig().RequirementIter())
				{
					list.Add(new ValueTuple<int, int>(dicIntInt.Key, dicIntInt.Value));
				}
				list.Sort((ValueTuple<int, int> a, ValueTuple<int, int> b) => a.Item1 - b.Item1);
				return list;
			}
			List<ValueTuple<int, int>> list2 = new List<ValueTuple<int, int>>();
			foreach (DicIntInt dicIntInt2 in this.GetObservatoryConfig().RequirementIter())
			{
				list2.Add(new ValueTuple<int, int>(dicIntInt2.Key, dicIntInt2.Value));
			}
			list2.Sort((ValueTuple<int, int> a, ValueTuple<int, int> b) => a.Item1 - b.Item1);
			return list2;
		}

		// Token: 0x0603BC04 RID: 244740 RVA: 0x00F242AC File Offset: 0x00F224AC
		private List<string> GetEffectDesList()
		{
			if (this.DeliveryType == ActionInfrastructureItemDeliveryType.Observatory)
			{
				return new List<string>();
			}
			InfrRoadBuild roadConfig = this.GetRoadConfig();
			if (this.GetCurRoadData().Status == InfrStatusPb.InfrStatusProgress)
			{
				string localTextNew = ConfigMultiTextLang.GetLocalTextNew(roadConfig.EffectDes(0), null);
				return new List<string>
				{
					StringUtils.Format(localTextNew, new string[]
					{
						roadConfig.FireExpReward.ToString()
					})
				};
			}
			return new List<string>();
		}

		// Token: 0x0603BC05 RID: 244741 RVA: 0x00F2431C File Offset: 0x00F2251C
		private string GetName()
		{
			if (this.DeliveryType == ActionInfrastructureItemDeliveryType.Road)
			{
				return this.GetRoadConfig().Name;
			}
			return this.GetObservatoryConfig().Name;
		}

		// Token: 0x0603BC06 RID: 244742 RVA: 0x00F24350 File Offset: 0x00F22550
		private string GetDescription()
		{
			if (this.DeliveryType != ActionInfrastructureItemDeliveryType.Road)
			{
				return this.GetObservatoryConfig().StageDescription;
			}
			if (this.GetCurRoadData().Status == InfrStatusPb.InfrStatusComplete)
			{
				return this.GetRoadConfig().BuildDoneDes;
			}
			return this.GetRoadConfig().Description;
		}

		// Token: 0x0603BC07 RID: 244743 RVA: 0x00F243A0 File Offset: 0x00F225A0
		private int GetLength()
		{
			if (this.DeliveryType == ActionInfrastructureItemDeliveryType.Road)
			{
				return this.GetRoadConfig().Length;
			}
			return 0;
		}

		// Token: 0x0603BC08 RID: 244744 RVA: 0x00F243C8 File Offset: 0x00F225C8
		private string GetInfoPicturePath()
		{
			if (this.DeliveryType == ActionInfrastructureItemDeliveryType.Road)
			{
				return this.GetRoadConfig().InfoPicturePath;
			}
			return this.GetObservatoryConfig().InfoPicturePath;
		}

		// Token: 0x0603BC09 RID: 244745 RVA: 0x00F243FB File Offset: 0x00F225FB
		private InfrastructureDefine.IInfrRoadData GetCurRoadData()
		{
			return ModelBase<InfrastructureModel>.Instance.GetRoadDataByRoadId(this.RoadId);
		}

		// Token: 0x170097EB RID: 38891
		// (get) Token: 0x0603BC0A RID: 244746 RVA: 0x00F24410 File Offset: 0x00F22610
		private bool IsMaterialEnough
		{
			get
			{
				List<ValueTuple<int, int>> requirementList = this.GetRequirementList();
				InventoryModel instance = ModelBase<InventoryModel>.Instance;
				foreach (ValueTuple<int, int> valueTuple in requirementList)
				{
					int item = valueTuple.Item1;
					int item2 = valueTuple.Item2;
					if (instance.GetItemCountByConfigId(item, 0) < item2)
					{
						return false;
					}
				}
				return true;
			}
		}

		// Token: 0x0603BC0B RID: 244747 RVA: 0x00F24484 File Offset: 0x00F22684
		protected override UniTask OnBeforeStartAsync()
		{
			InfrMaterialsDeliveryInfoPanel.<OnBeforeStartAsync>d__29 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<InfrMaterialsDeliveryInfoPanel.<OnBeforeStartAsync>d__29>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603BC0C RID: 244748 RVA: 0x00F244C8 File Offset: 0x00F226C8
		private UniTask CreateCaption()
		{
			InfrMaterialsDeliveryInfoPanel.<CreateCaption>d__30 <CreateCaption>d__;
			<CreateCaption>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateCaption>d__.<>4__this = this;
			<CreateCaption>d__.<>1__state = -1;
			<CreateCaption>d__.<>t__builder.Start<InfrMaterialsDeliveryInfoPanel.<CreateCaption>d__30>(ref <CreateCaption>d__);
			return <CreateCaption>d__.<>t__builder.Task;
		}

		// Token: 0x0603BC0D RID: 244749 RVA: 0x00F2450B File Offset: 0x00F2270B
		private void CreateConsumeList()
		{
			this.ConsumeList = new GenericLayout<InfrMaterialsDeliveryConsumeItem, TItem>(base.GetHorizontalLayout(17), () => new InfrMaterialsDeliveryConsumeItem(), null, false, true);
		}

		// Token: 0x0603BC0E RID: 244750 RVA: 0x00F24542 File Offset: 0x00F22742
		private void CreateEffectList()
		{
			this.EffectList = new GenericLayout<InfrMaterialsDeliveryEffectItem, string>(base.GetVerticalLayout(20), () => new InfrMaterialsDeliveryEffectItem(), null, false, true);
		}

		// Token: 0x0603BC0F RID: 244751 RVA: 0x00F2457C File Offset: 0x00F2277C
		private UniTask CreateButtonMarkAsync()
		{
			InfrMaterialsDeliveryInfoPanel.<CreateButtonMarkAsync>d__33 <CreateButtonMarkAsync>d__;
			<CreateButtonMarkAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateButtonMarkAsync>d__.<>4__this = this;
			<CreateButtonMarkAsync>d__.<>1__state = -1;
			<CreateButtonMarkAsync>d__.<>t__builder.Start<InfrMaterialsDeliveryInfoPanel.<CreateButtonMarkAsync>d__33>(ref <CreateButtonMarkAsync>d__);
			return <CreateButtonMarkAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603BC10 RID: 244752 RVA: 0x00F245C0 File Offset: 0x00F227C0
		private UniTask CreateButtonLocateAsync()
		{
			InfrMaterialsDeliveryInfoPanel.<CreateButtonLocateAsync>d__34 <CreateButtonLocateAsync>d__;
			<CreateButtonLocateAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateButtonLocateAsync>d__.<>4__this = this;
			<CreateButtonLocateAsync>d__.<>1__state = -1;
			<CreateButtonLocateAsync>d__.<>t__builder.Start<InfrMaterialsDeliveryInfoPanel.<CreateButtonLocateAsync>d__34>(ref <CreateButtonLocateAsync>d__);
			return <CreateButtonLocateAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603BC11 RID: 244753 RVA: 0x00F24604 File Offset: 0x00F22804
		private UniTask CreateButtonGotoMissionAsync()
		{
			InfrMaterialsDeliveryInfoPanel.<CreateButtonGotoMissionAsync>d__35 <CreateButtonGotoMissionAsync>d__;
			<CreateButtonGotoMissionAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateButtonGotoMissionAsync>d__.<>4__this = this;
			<CreateButtonGotoMissionAsync>d__.<>1__state = -1;
			<CreateButtonGotoMissionAsync>d__.<>t__builder.Start<InfrMaterialsDeliveryInfoPanel.<CreateButtonGotoMissionAsync>d__35>(ref <CreateButtonGotoMissionAsync>d__);
			return <CreateButtonGotoMissionAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603BC12 RID: 244754 RVA: 0x00F24648 File Offset: 0x00F22848
		private UniTask CreateButtonBuildStartAsync()
		{
			InfrMaterialsDeliveryInfoPanel.<CreateButtonBuildStartAsync>d__36 <CreateButtonBuildStartAsync>d__;
			<CreateButtonBuildStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateButtonBuildStartAsync>d__.<>4__this = this;
			<CreateButtonBuildStartAsync>d__.<>1__state = -1;
			<CreateButtonBuildStartAsync>d__.<>t__builder.Start<InfrMaterialsDeliveryInfoPanel.<CreateButtonBuildStartAsync>d__36>(ref <CreateButtonBuildStartAsync>d__);
			return <CreateButtonBuildStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603BC13 RID: 244755 RVA: 0x00F2468C File Offset: 0x00F2288C
		private UniTask CreateLockPanelAsync()
		{
			InfrMaterialsDeliveryInfoPanel.<CreateLockPanelAsync>d__37 <CreateLockPanelAsync>d__;
			<CreateLockPanelAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateLockPanelAsync>d__.<>4__this = this;
			<CreateLockPanelAsync>d__.<>1__state = -1;
			<CreateLockPanelAsync>d__.<>t__builder.Start<InfrMaterialsDeliveryInfoPanel.<CreateLockPanelAsync>d__37>(ref <CreateLockPanelAsync>d__);
			return <CreateLockPanelAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603BC14 RID: 244756 RVA: 0x00F246D0 File Offset: 0x00F228D0
		private UniTask CreateDonePanelAsync()
		{
			InfrMaterialsDeliveryInfoPanel.<CreateDonePanelAsync>d__38 <CreateDonePanelAsync>d__;
			<CreateDonePanelAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateDonePanelAsync>d__.<>4__this = this;
			<CreateDonePanelAsync>d__.<>1__state = -1;
			<CreateDonePanelAsync>d__.<>t__builder.Start<InfrMaterialsDeliveryInfoPanel.<CreateDonePanelAsync>d__38>(ref <CreateDonePanelAsync>d__);
			return <CreateDonePanelAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603BC15 RID: 244757 RVA: 0x00F24714 File Offset: 0x00F22914
		private UniTask CreateWarnPanelAsync()
		{
			InfrMaterialsDeliveryInfoPanel.<CreateWarnPanelAsync>d__39 <CreateWarnPanelAsync>d__;
			<CreateWarnPanelAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateWarnPanelAsync>d__.<>4__this = this;
			<CreateWarnPanelAsync>d__.<>1__state = -1;
			<CreateWarnPanelAsync>d__.<>t__builder.Start<InfrMaterialsDeliveryInfoPanel.<CreateWarnPanelAsync>d__39>(ref <CreateWarnPanelAsync>d__);
			return <CreateWarnPanelAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603BC16 RID: 244758 RVA: 0x00F24757 File Offset: 0x00F22957
		protected override void OnStart()
		{
			this.Refresh(this.OpenParam as InfrastructureDefine.IInfrMaterialsDeliveryOpenParam);
		}

		// Token: 0x0603BC17 RID: 244759 RVA: 0x00F2476C File Offset: 0x00F2296C
		public void Refresh(InfrastructureDefine.IInfrMaterialsDeliveryOpenParam param)
		{
			this.InitData(param);
			if (this.DeliveryType == ActionInfrastructureItemDeliveryType.Road && this.RoadId == 0)
			{
				return;
			}
			this.RefreshCaption();
			this.RefreshTitle();
			this.RefreshEllipsis();
			this.RefreshBuildDifficulty();
			this.RefreshEffect();
			this.RefreshObtain();
			this.RefreshConsume();
			this.RefreshActivated();
			this.RefreshBuildDone();
		}

		// Token: 0x0603BC18 RID: 244760 RVA: 0x00F247C8 File Offset: 0x00F229C8
		private void InitData(InfrastructureDefine.IInfrMaterialsDeliveryOpenParam param)
		{
			this.RoadId = ((param != null) ? param.RoadId : 0);
			this.DeliveryType = ((param != null) ? param.DeliveryType : ActionInfrastructureItemDeliveryType.Road);
			this.OpenSource = ((param != null) ? param.OpenSource : InfrastructureDefine.EMaterialDeliveryOpenSource.BigWorld);
			this.ShowEllipsis = true;
		}

		// Token: 0x0603BC19 RID: 244761 RVA: 0x00F24808 File Offset: 0x00F22A08
		private void RefreshCaption()
		{
			if (this.OpenSource == InfrastructureDefine.EMaterialDeliveryOpenSource.RoadNetworkMap)
			{
				this.Caption.SetHelpCallBack(delegate
				{
					int helpIdActivity = ConfigBase<InfrastructureConfig>.Instance.GetHelpIdActivity();
					ControllerBase<HelpController>.Instance.OpenHelpById(helpIdActivity);
				});
				this.Caption.SetCloseCallBack(new Action(this.OnClickCaptionCloseBtn));
			}
			else
			{
				this.Caption.SetUiActive(false);
			}
			UUIButtonComponent button = base.GetButton(36);
			if (button == null)
			{
				return;
			}
			button.RootUIComp.Get().SetUIActive(false);
		}

		// Token: 0x0603BC1A RID: 244762 RVA: 0x00F2488C File Offset: 0x00F22A8C
		private void RefreshTitle()
		{
			UUIText text = base.GetText(0);
			if (text != null)
			{
				text.ShowTextNew(this.GetName());
			}
			UUISprite sprite = base.GetSprite(40);
			if (sprite != null)
			{
				sprite.SetUIActive(false);
			}
			UUIText text2 = base.GetText(41);
			if (text2 != null)
			{
				text2.SetUIActive(false);
			}
			InfrastructureModel instance = ModelBase<InfrastructureModel>.Instance;
			if (this.DeliveryType == ActionInfrastructureItemDeliveryType.Road)
			{
				UUIText text3 = base.GetText(1);
				if (text3 != null)
				{
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
					defaultInterpolatedStringHandler.AppendFormatted<int>(this.GetLength());
					defaultInterpolatedStringHandler.AppendLiteral("m");
					text3.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
				}
				if (this.RoadId == instance.TracedRoadId)
				{
					UUISprite sprite2 = base.GetSprite(40);
					if (sprite2 != null)
					{
						sprite2.SetUIActive(true);
					}
					string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_InfrastructureMapMark1");
					this.SetSpriteByPath(resourcePath, base.GetSprite(40), false, null, null);
				}
				else if (this.RoadId == instance.RecommendRoadId)
				{
					UUISprite sprite3 = base.GetSprite(40);
					if (sprite3 != null)
					{
						sprite3.SetUIActive(true);
					}
					string resourcePath2 = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_InfrastructureMapMark2");
					this.SetSpriteByPath(resourcePath2, base.GetSprite(40), false, null, null);
				}
			}
			else
			{
				UUIText text4 = base.GetText(41);
				if (text4 != null)
				{
					text4.SetUIActive(false);
				}
				UUIText text5 = base.GetText(41);
				if (text5 != null)
				{
					text5.ShowTextNew(this.GetObservatoryConfig().Description);
				}
				UUIText text6 = base.GetText(1);
				if (text6 != null)
				{
					text6.SetUIActive(false);
				}
			}
			if (this.OpenSource == InfrastructureDefine.EMaterialDeliveryOpenSource.BigWorld && !string.IsNullOrEmpty(this.GetInfoPicturePath()))
			{
				base.SetTextureByPath(this.GetInfoPicturePath(), base.GetTexture(29), null, null);
				return;
			}
			UUITexture texture = base.GetTexture(29);
			if (texture == null)
			{
				return;
			}
			texture.SetUIActive(false);
		}

		// Token: 0x0603BC1B RID: 244763 RVA: 0x00F24A5C File Offset: 0x00F22C5C
		private void RefreshEllipsis()
		{
			UUIText text = base.GetText(3);
			if (text != null)
			{
				text.ShowTextNew(this.GetDescription());
			}
			UUIText text2 = base.GetText(6);
			if (text2 != null)
			{
				text2.ShowTextNew(this.GetDescription());
			}
			UUIText text3 = base.GetText(8);
			if (text3 != null)
			{
				text3.ShowTextNew(this.GetDescription());
			}
			UUIText text4 = base.GetText(8);
			if (text4 != null)
			{
				text4.GetRealSize();
			}
			UUIText text5 = base.GetText(8);
			if (text5 != null && text5.GetRenderLineNum() > 3)
			{
				UUIItem item = base.GetItem(2);
				if (item != null)
				{
					item.SetUIActive(this.ShowEllipsis);
				}
				UUIItem item2 = base.GetItem(5);
				if (item2 != null)
				{
					item2.SetUIActive(false);
				}
				UUIItem item3 = base.GetItem(7);
				if (item3 == null)
				{
					return;
				}
				item3.SetUIActive(!this.ShowEllipsis);
				return;
			}
			else
			{
				UUIItem item4 = base.GetItem(2);
				if (item4 != null)
				{
					item4.SetUIActive(false);
				}
				UUIItem item5 = base.GetItem(5);
				if (item5 != null)
				{
					item5.SetUIActive(true);
				}
				UUIItem item6 = base.GetItem(7);
				if (item6 == null)
				{
					return;
				}
				item6.SetUIActive(false);
				return;
			}
		}

		// Token: 0x0603BC1C RID: 244764 RVA: 0x00F24B5A File Offset: 0x00F22D5A
		private void RefreshBuildDifficulty()
		{
			if (this.DeliveryType == ActionInfrastructureItemDeliveryType.Road)
			{
				this.RefreshRoadDifficulty();
				return;
			}
			this.RefreshObservatoryDifficulty();
		}

		// Token: 0x0603BC1D RID: 244765 RVA: 0x00F24B74 File Offset: 0x00F22D74
		private void RefreshRoadDifficulty()
		{
			UUIItem item = base.GetItem(9);
			if (item != null)
			{
				item.SetUIActive(true);
			}
			InfrRoadBuild roadConfig = this.GetRoadConfig();
			InfrastructureDefine.IInfrRoadData curRoadData = this.GetCurRoadData();
			InfrStatusPb infrStatusPb = (curRoadData != null) ? curRoadData.Status : InfrStatusPb.InfrStatusLock;
			UUIItem item2 = base.GetItem(11);
			if (item2 != null)
			{
				item2.SetUIActive(infrStatusPb != InfrStatusPb.InfrStatusComplete);
			}
			UUIText text = base.GetText(15);
			if (text != null)
			{
				text.SetUIActive(infrStatusPb == InfrStatusPb.InfrStatusComplete);
			}
			UiResource? uiResource;
			string path = (ConfigBase<UiResourceConfig>.Instance.GetResourceConfig(InfrastructureDefine.difficultySpriteResourceId[roadConfig.Difficulty]) != null) ? uiResource.GetValueOrDefault().Path : null;
			this.SetSpriteByPath(path, base.GetSprite(12), true, null, null);
			UUISprite sprite = base.GetSprite(12);
			if (sprite != null)
			{
				sprite.SetUIActive(roadConfig.Difficulty >= 1);
			}
			UUISprite sprite2 = base.GetSprite(13);
			if (sprite2 != null)
			{
				sprite2.SetUIActive(false);
			}
			UUISprite sprite3 = base.GetSprite(14);
			if (sprite3 != null)
			{
				sprite3.SetUIActive(false);
			}
			DateTime localDateTime = DateTimeOffset.FromUnixTimeMilliseconds((long)((curRoadData != null) ? curRoadData.CompleteTime : 0) * (long)Singleton<TimeUtil>.Instance.InverseMillisecond).LocalDateTime;
			UUIText text2 = base.GetText(15);
			if (text2 != null)
			{
				text2.SetText(Singleton<TimeUtil>.Instance.DateFormat3(localDateTime), true);
			}
			if (infrStatusPb == InfrStatusPb.InfrStatusComplete)
			{
				UUIText text3 = base.GetText(10);
				if (text3 == null)
				{
					return;
				}
				text3.ShowTextNew("Build_CompleteTime");
				return;
			}
			else
			{
				UUIText text4 = base.GetText(10);
				if (text4 == null)
				{
					return;
				}
				text4.ShowTextNew("Build_BuildingDiff");
				return;
			}
		}

		// Token: 0x0603BC1E RID: 244766 RVA: 0x00F24CF8 File Offset: 0x00F22EF8
		private void RefreshObservatoryDifficulty()
		{
			if (ModelBase<InfrastructureModel>.Instance.FireLevel < ConfigBase<InfrastructureConfig>.Instance.GetMaxLevel())
			{
				UUIItem item = base.GetItem(9);
				if (item == null)
				{
					return;
				}
				item.SetUIActive(false);
				return;
			}
			else
			{
				UUIText text = base.GetText(10);
				if (text != null)
				{
					text.ShowTextNew("Build_CompleteTime");
				}
				DateTime localDateTime = DateTimeOffset.FromUnixTimeMilliseconds(ModelBase<InfrastructureModel>.Instance.FireLevelReachTime * (long)Singleton<TimeUtil>.Instance.InverseMillisecond).LocalDateTime;
				UUIItem item2 = base.GetItem(11);
				if (item2 != null)
				{
					item2.SetUIActive(false);
				}
				UUIText text2 = base.GetText(15);
				if (text2 != null)
				{
					text2.SetUIActive(true);
				}
				UUIText text3 = base.GetText(15);
				if (text3 == null)
				{
					return;
				}
				text3.SetText(Singleton<TimeUtil>.Instance.DateFormat3(localDateTime), true);
				return;
			}
		}

		// Token: 0x0603BC1F RID: 244767 RVA: 0x00F24DB4 File Offset: 0x00F22FB4
		private void RefreshConsume()
		{
			List<TItem> list = (from x in this.GetRequirementList()
			orderby x.Item1
			select new TItem(new InventoryDefine.GetItemData(x.Item1, 0), x.Item2)).ToList<TItem>();
			GenericLayout<InfrMaterialsDeliveryConsumeItem, TItem> consumeList = this.ConsumeList;
			if (consumeList != null)
			{
				consumeList.RefreshByData(list, null, false);
			}
			if (list.Count == 0)
			{
				UUIItem item = base.GetItem(16);
				if (item == null)
				{
					return;
				}
				item.SetUIActive(false);
				return;
			}
			else if (this.DeliveryType == ActionInfrastructureItemDeliveryType.Road)
			{
				InfrastructureDefine.IInfrRoadData curRoadData = this.GetCurRoadData();
				InfrStatusPb infrStatusPb = (curRoadData != null) ? curRoadData.Status : InfrStatusPb.InfrStatusLock;
				UUIItem item2 = base.GetItem(16);
				if (item2 == null)
				{
					return;
				}
				item2.SetUIActive(infrStatusPb == InfrStatusPb.InfrStatusProgress);
				return;
			}
			else
			{
				UUIItem item3 = base.GetItem(16);
				if (item3 == null)
				{
					return;
				}
				item3.SetUIActive(ModelBase<InfrastructureModel>.Instance.FireLevel < ConfigBase<InfrastructureConfig>.Instance.GetMaxLevel());
				return;
			}
		}

		// Token: 0x0603BC20 RID: 244768 RVA: 0x00F24EA0 File Offset: 0x00F230A0
		private void RefreshEffect()
		{
			if (this.DeliveryType == ActionInfrastructureItemDeliveryType.Observatory)
			{
				UUIItem item = base.GetItem(18);
				if (item == null)
				{
					return;
				}
				item.SetUIActive(false);
				return;
			}
			else if (this.GetCurRoadData().Status != InfrStatusPb.InfrStatusProgress)
			{
				UUIItem item2 = base.GetItem(18);
				if (item2 == null)
				{
					return;
				}
				item2.SetUIActive(false);
				return;
			}
			else
			{
				List<string> effectDesList = this.GetEffectDesList();
				UUIItem item3 = base.GetItem(18);
				if (item3 != null)
				{
					item3.SetUIActive(effectDesList.Count > 0);
				}
				GenericLayout<InfrMaterialsDeliveryEffectItem, string> effectList = this.EffectList;
				if (effectList == null)
				{
					return;
				}
				effectList.RefreshByData(this.GetEffectDesList(), null, false);
				return;
			}
		}

		// Token: 0x0603BC21 RID: 244769 RVA: 0x00F24F28 File Offset: 0x00F23128
		private void RefreshObtain()
		{
			if (this.DeliveryType == ActionInfrastructureItemDeliveryType.Road)
			{
				UUIItem item = base.GetItem(21);
				if (item == null)
				{
					return;
				}
				item.SetUIActive(false);
				return;
			}
			else if (ModelBase<InfrastructureModel>.Instance.FireLevel >= ConfigBase<InfrastructureConfig>.Instance.GetMaxLevel())
			{
				UUIItem item2 = base.GetItem(21);
				if (item2 == null)
				{
					return;
				}
				item2.SetUIActive(false);
				return;
			}
			else
			{
				UUIItem item3 = base.GetItem(21);
				if (item3 != null)
				{
					item3.SetUIActive(true);
				}
				UUIText text = base.GetText(22);
				if (text == null)
				{
					return;
				}
				text.ShowTextNew("Observatory_FunctionOpenDesc");
				return;
			}
		}

		// Token: 0x0603BC22 RID: 244770 RVA: 0x00F24FA8 File Offset: 0x00F231A8
		private void RefreshActivated()
		{
			this.RefreshTitle();
			UUIButtonComponent button = base.GetButton(33);
			if (button != null)
			{
				button.RootUIComp.Get().SetUIActive(false);
			}
			UUIButtonComponent button2 = base.GetButton(34);
			if (button2 != null)
			{
				button2.RootUIComp.Get().SetUIActive(false);
			}
			UUIButtonComponent button3 = base.GetButton(26);
			if (button3 != null)
			{
				button3.RootUIComp.Get().SetUIActive(false);
			}
			UUIButtonComponent button4 = base.GetButton(24);
			if (button4 != null)
			{
				button4.RootUIComp.Get().SetUIActive(false);
			}
			UUIItem item = base.GetItem(31);
			if (item != null)
			{
				item.SetUIActive(false);
			}
			UUIItem item2 = base.GetItem(30);
			if (item2 != null)
			{
				item2.SetUIActive(false);
			}
			UUIItem item3 = base.GetItem(32);
			if (item3 != null)
			{
				item3.SetUIActive(false);
			}
			if (this.DeliveryType == ActionInfrastructureItemDeliveryType.Road)
			{
				InfrastructureDefine.IInfrRoadData curRoadData = this.GetCurRoadData();
				InfrStatusPb status = (curRoadData != null) ? curRoadData.Status : InfrStatusPb.InfrStatusLock;
				this.RefreshRoadActivated(status);
				return;
			}
			this.RefreshObservatoryActivated(ModelBase<InfrastructureModel>.Instance.FireStatus);
		}

		// Token: 0x0603BC23 RID: 244771 RVA: 0x00F250B0 File Offset: 0x00F232B0
		private void RefreshRoadActivated(InfrStatusPb status)
		{
			if (status == InfrStatusPb.InfrStatusLock)
			{
				UUIItem item = base.GetItem(31);
				if (item != null)
				{
					item.SetUIActive(true);
				}
				ConditionGroup? config = ConfigConditionGroupById.GetConfig(this.GetRoadConfig().ConditionId, true);
				this.LockPanel.Refresh(new InfrastructureDefine.InfrMaterialsDeliveryLockData
				{
					LockDescriptionTextId = config.Value.HintText
				});
				UUIButtonComponent button = base.GetButton(33);
				if (button == null)
				{
					return;
				}
				button.RootUIComp.Get().SetUIActive(true);
				return;
			}
			else if (status == InfrStatusPb.InfrStatusProgress)
			{
				if (this.OpenSource == InfrastructureDefine.EMaterialDeliveryOpenSource.RoadNetworkMap)
				{
					UUIButtonComponent button2 = base.GetButton(24);
					if (button2 != null)
					{
						button2.RootUIComp.Get().SetUIActive(!this.GetRoadConfig().DisableMark);
					}
					UUIButtonComponent button3 = base.GetButton(26);
					if (button3 != null)
					{
						button3.RootUIComp.Get().SetUIActive(true);
					}
				}
				else
				{
					UUIButtonComponent button4 = base.GetButton(34);
					if (button4 != null)
					{
						button4.RootUIComp.Get().SetUIActive(true);
					}
				}
				this.ButtonMark.SetLocalTextNew((ModelBase<InfrastructureModel>.Instance.TracedRoadId == this.RoadId) ? "BuildRoadNet_RoadButton_2" : "BuildRoadNet_RoadButton_1", Array.Empty<object>());
				if (!this.IsMaterialEnough)
				{
					UUIItem item2 = base.GetItem(31);
					if (item2 != null)
					{
						item2.SetUIActive(true);
					}
					this.LockPanel.Refresh(new InfrastructureDefine.InfrMaterialsDeliveryLockData
					{
						LockDescriptionTextId = "BuildRoad_MaterialShortageTips"
					});
					this.ButtonBuildStart.SetEnableClick(false);
					return;
				}
				this.ButtonBuildStart.SetEnableClick(true);
				return;
			}
			else
			{
				UUIButtonComponent button5 = base.GetButton(26);
				if (button5 == null)
				{
					return;
				}
				button5.RootUIComp.Get().SetUIActive(true);
				return;
			}
		}

		// Token: 0x0603BC24 RID: 244772 RVA: 0x00F25254 File Offset: 0x00F23454
		private void RefreshObservatoryActivated(InfrStatusPb status)
		{
			InfrastructureConfig instance = ConfigBase<InfrastructureConfig>.Instance;
			int maxLevel = instance.GetMaxLevel();
			if (ModelBase<InfrastructureModel>.Instance.FireLevel >= maxLevel)
			{
				UUIButtonComponent button = base.GetButton(26);
				if (button == null)
				{
					return;
				}
				button.RootUIComp.Get().SetUIActive(true);
				return;
			}
			else if (status == InfrStatusPb.InfrStatusLock)
			{
				UUIItem item = base.GetItem(31);
				if (item != null)
				{
					item.SetUIActive(true);
				}
				ConditionGroup? config = ConfigConditionGroupById.GetConfig(this.GetObservatoryConfig().ConditionId, true);
				this.LockPanel.Refresh(new InfrastructureDefine.InfrMaterialsDeliveryLockData
				{
					LockDescriptionTextId = config.Value.HintText
				});
				UUIButtonComponent button2 = base.GetButton(33);
				if (button2 == null)
				{
					return;
				}
				button2.RootUIComp.Get().SetUIActive(true);
				return;
			}
			else if (status == InfrStatusPb.InfrStatusProgress)
			{
				UUIButtonComponent button3 = base.GetButton(26);
				if (button3 != null)
				{
					button3.RootUIComp.Get().SetUIActive(true);
				}
				InfrastructureModel instance2 = ModelBase<InfrastructureModel>.Instance;
				bool flag = instance2.FireExp >= (long)instance.GetLevelConfigById(instance2.FireLevel + 1).Value.Exp;
				if (this.OpenSource == InfrastructureDefine.EMaterialDeliveryOpenSource.BigWorld)
				{
					UUIButtonComponent button4 = base.GetButton(34);
					if (button4 != null)
					{
						button4.RootUIComp.Get().SetUIActive(true);
					}
				}
				if (!this.IsMaterialEnough || !flag)
				{
					UUIItem item2 = base.GetItem(31);
					if (item2 != null)
					{
						item2.SetUIActive(true);
					}
					this.ButtonBuildStart.SetEnableClick(false);
					this.LockPanel.Refresh(new InfrastructureDefine.InfrMaterialsDeliveryLockData
					{
						LockDescriptionTextId = "BuildRoad_ObserMaterialShortageTips"
					});
					return;
				}
				this.ButtonBuildStart.SetEnableClick(true);
				return;
			}
			else
			{
				UUIButtonComponent button5 = base.GetButton(26);
				if (button5 == null)
				{
					return;
				}
				button5.RootUIComp.Get().SetUIActive(true);
				return;
			}
		}

		// Token: 0x0603BC25 RID: 244773 RVA: 0x00F25410 File Offset: 0x00F23610
		private void RefreshBuildDone()
		{
			if (this.DeliveryType != ActionInfrastructureItemDeliveryType.Road)
			{
				UUIItem item = base.GetItem(23);
				if (item != null)
				{
					item.SetUIActive(ModelBase<InfrastructureModel>.Instance.FireLevel >= ConfigBase<InfrastructureConfig>.Instance.GetMaxLevel());
				}
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(37), "BuildRoad_CompleteDes_1", new <>z__ReadOnlySingleElementList<object>(ConfigMultiTextLang.GetLocalTextNew(this.GetName(), null) ?? ""));
				return;
			}
			UUIItem item2 = base.GetItem(23);
			if (item2 == null)
			{
				return;
			}
			item2.SetUIActive(false);
		}

		// Token: 0x0603BC26 RID: 244774 RVA: 0x00F25497 File Offset: 0x00F23697
		public void SetClickBtnBuildCb(Action cb)
		{
			this.OnClickBtnBuildCb = cb;
		}

		// Token: 0x0603BC27 RID: 244775 RVA: 0x00F254A0 File Offset: 0x00F236A0
		public void SetClickCaptionCloseBtnCb(Action cb)
		{
			this.OnClickCaptionCloseBtnCb = cb;
		}

		// Token: 0x0603BC28 RID: 244776 RVA: 0x00F254A9 File Offset: 0x00F236A9
		private void OnClickButtonMark(int index)
		{
			this.OnClickButtonMarkAsync();
		}

		// Token: 0x0603BC29 RID: 244777 RVA: 0x00F254B4 File Offset: 0x00F236B4
		private UniTask OnClickButtonMarkAsync()
		{
			InfrMaterialsDeliveryInfoPanel.<OnClickButtonMarkAsync>d__59 <OnClickButtonMarkAsync>d__;
			<OnClickButtonMarkAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnClickButtonMarkAsync>d__.<>4__this = this;
			<OnClickButtonMarkAsync>d__.<>1__state = -1;
			<OnClickButtonMarkAsync>d__.<>t__builder.Start<InfrMaterialsDeliveryInfoPanel.<OnClickButtonMarkAsync>d__59>(ref <OnClickButtonMarkAsync>d__);
			return <OnClickButtonMarkAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603BC2A RID: 244778 RVA: 0x00F254F7 File Offset: 0x00F236F7
		private void OnClickButtonLocate(int index)
		{
			this.OnClickButtonLocateAsync();
		}

		// Token: 0x0603BC2B RID: 244779 RVA: 0x00F25500 File Offset: 0x00F23700
		private UniTask OnClickButtonLocateAsync()
		{
			InfrMaterialsDeliveryInfoPanel.<OnClickButtonLocateAsync>d__61 <OnClickButtonLocateAsync>d__;
			<OnClickButtonLocateAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnClickButtonLocateAsync>d__.<>4__this = this;
			<OnClickButtonLocateAsync>d__.<>1__state = -1;
			<OnClickButtonLocateAsync>d__.<>t__builder.Start<InfrMaterialsDeliveryInfoPanel.<OnClickButtonLocateAsync>d__61>(ref <OnClickButtonLocateAsync>d__);
			return <OnClickButtonLocateAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603BC2C RID: 244780 RVA: 0x00F25544 File Offset: 0x00F23744
		private void OnClickButtonGotoMission(int index)
		{
			if (this.DeliveryType != ActionInfrastructureItemDeliveryType.Road)
			{
				return;
			}
			if (this.GetCurRoadData().Status == InfrStatusPb.InfrStatusLock)
			{
				int? intConfig = ConfigCommonParamById.GetIntConfig("InfrTeachStageEndQuestId");
				Singleton<UiManager>.Instance.OpenView(EUiViewName.QuestView, intConfig, null);
				return;
			}
			Singleton<UiManager>.Instance.OpenView(EUiViewName.QuestView, this.GetRoadConfig().BuildQuest, null);
		}

		// Token: 0x0603BC2D RID: 244781 RVA: 0x00F255AD File Offset: 0x00F237AD
		private void OnClickButtonBuildStart(int _)
		{
			Action onClickBtnBuildCb = this.OnClickBtnBuildCb;
			if (onClickBtnBuildCb == null)
			{
				return;
			}
			onClickBtnBuildCb();
		}

		// Token: 0x0603BC2E RID: 244782 RVA: 0x00F255BF File Offset: 0x00F237BF
		private void OnClickClose()
		{
			Action onClickCaptionCloseBtnCb = this.OnClickCaptionCloseBtnCb;
			if (onClickCaptionCloseBtnCb == null)
			{
				return;
			}
			onClickCaptionCloseBtnCb();
		}

		// Token: 0x0603BC2F RID: 244783 RVA: 0x00F255D1 File Offset: 0x00F237D1
		private void OnClickEllipsisExpand()
		{
			this.ShowEllipsis = false;
			this.RefreshEllipsis();
		}

		// Token: 0x0603BC30 RID: 244784 RVA: 0x00F255E0 File Offset: 0x00F237E0
		private void OnClickEllipsisFold()
		{
			this.ShowEllipsis = true;
			this.RefreshEllipsis();
		}

		// Token: 0x0603BC31 RID: 244785 RVA: 0x00F255EF File Offset: 0x00F237EF
		private void OnClickCaptionCloseBtn()
		{
			Action onClickCaptionCloseBtnCb = this.OnClickCaptionCloseBtnCb;
			if (onClickCaptionCloseBtnCb == null)
			{
				return;
			}
			onClickCaptionCloseBtnCb();
		}

		// Token: 0x0603BC32 RID: 244786 RVA: 0x00F25601 File Offset: 0x00F23801
		private void OnClickWarnPanel()
		{
		}

		// Token: 0x04021952 RID: 137554
		private InfrastructureDefine.EMaterialDeliveryOpenSource OpenSource;

		// Token: 0x04021953 RID: 137555
		private int RoadId;

		// Token: 0x04021954 RID: 137556
		private ActionInfrastructureItemDeliveryType DeliveryType = ActionInfrastructureItemDeliveryType.Road;

		// Token: 0x04021955 RID: 137557
		private GenericLayout<InfrMaterialsDeliveryConsumeItem, TItem> ConsumeList;

		// Token: 0x04021956 RID: 137558
		private GenericLayout<InfrMaterialsDeliveryEffectItem, string> EffectList;

		// Token: 0x04021957 RID: 137559
		private readonly ButtonItem ButtonMark = new ButtonItem(null);

		// Token: 0x04021958 RID: 137560
		private readonly ButtonItem ButtonLocate = new ButtonItem(null);

		// Token: 0x04021959 RID: 137561
		private readonly ButtonItem ButtonGotoMission = new ButtonItem(null);

		// Token: 0x0402195A RID: 137562
		private readonly ButtonItem ButtonBuildStart = new ButtonItem(null);

		// Token: 0x0402195B RID: 137563
		private readonly InfrMaterialsDeliveryLockItem LockPanel = new InfrMaterialsDeliveryLockItem();

		// Token: 0x0402195C RID: 137564
		private readonly InfrMaterialsDeliveryLockItem WarnPanel = new InfrMaterialsDeliveryLockItem();

		// Token: 0x0402195D RID: 137565
		private readonly InfrMaterialsDeliveryDoneItem DonePanel = new InfrMaterialsDeliveryDoneItem();

		// Token: 0x0402195E RID: 137566
		private readonly PopupCaptionItem Caption = new PopupCaptionItem(null);

		// Token: 0x0402195F RID: 137567
		private bool ShowEllipsis;

		// Token: 0x04021960 RID: 137568
		private Action OnClickBtnBuildCb;

		// Token: 0x04021961 RID: 137569
		private Action OnClickCaptionCloseBtnCb;

		// Token: 0x0200BCEE RID: 48366
		[NullableContext(0)]
		private class EChildType
		{
			// Token: 0x0403A360 RID: 238432
			public const int TextName = 0;

			// Token: 0x0403A361 RID: 238433
			public const int TextDistance = 1;

			// Token: 0x0403A362 RID: 238434
			public const int PanelEllipsis = 2;

			// Token: 0x0403A363 RID: 238435
			public const int TextEllipsis = 3;

			// Token: 0x0403A364 RID: 238436
			public const int BtnEllipsisExpand = 4;

			// Token: 0x0403A365 RID: 238437
			public const int PanelEllipsis1 = 5;

			// Token: 0x0403A366 RID: 238438
			public const int TextEllipsis1 = 6;

			// Token: 0x0403A367 RID: 238439
			public const int PanelEllipsis2 = 7;

			// Token: 0x0403A368 RID: 238440
			public const int TextEllipsis2 = 8;

			// Token: 0x0403A369 RID: 238441
			public const int PanelBuildDifficulty = 9;

			// Token: 0x0403A36A RID: 238442
			public const int TextBuildDifficultyTitle = 10;

			// Token: 0x0403A36B RID: 238443
			public const int PanelBuildDifficultyStar = 11;

			// Token: 0x0403A36C RID: 238444
			public const int SpriteBuildDifficultyStar1 = 12;

			// Token: 0x0403A36D RID: 238445
			public const int SpriteBuildDifficultyStar2 = 13;

			// Token: 0x0403A36E RID: 238446
			public const int SpriteBuildDifficultyStar3 = 14;

			// Token: 0x0403A36F RID: 238447
			public const int TextBuildTime = 15;

			// Token: 0x0403A370 RID: 238448
			public const int PanelConsume = 16;

			// Token: 0x0403A371 RID: 238449
			public const int HorizontalConsume = 17;

			// Token: 0x0403A372 RID: 238450
			public const int PanelEffect = 18;

			// Token: 0x0403A373 RID: 238451
			public const int TextEffectTitle = 19;

			// Token: 0x0403A374 RID: 238452
			public const int VerticalEffect = 20;

			// Token: 0x0403A375 RID: 238453
			public const int PanelObtain = 21;

			// Token: 0x0403A376 RID: 238454
			public const int TextObtainInfo = 22;

			// Token: 0x0403A377 RID: 238455
			public const int PanelDone = 23;

			// Token: 0x0403A378 RID: 238456
			public const int BtnMark = 24;

			// Token: 0x0403A379 RID: 238457
			public const int TextBtnMark = 25;

			// Token: 0x0403A37A RID: 238458
			public const int BtnLocate = 26;

			// Token: 0x0403A37B RID: 238459
			public const int TextBtnLocate = 27;

			// Token: 0x0403A37C RID: 238460
			public const int PanelMapTexture = 28;

			// Token: 0x0403A37D RID: 238461
			public const int TextureMap = 29;

			// Token: 0x0403A37E RID: 238462
			public const int PanelActivatedWarn = 30;

			// Token: 0x0403A37F RID: 238463
			public const int PanelActivatedDisabled = 31;

			// Token: 0x0403A380 RID: 238464
			public const int PanelActivatedDone = 32;

			// Token: 0x0403A381 RID: 238465
			public const int BtnGotoMission = 33;

			// Token: 0x0403A382 RID: 238466
			public const int BtnBuildStart = 34;

			// Token: 0x0403A383 RID: 238467
			public const int BtnEllipsisFold = 35;

			// Token: 0x0403A384 RID: 238468
			public const int BtnClose = 36;

			// Token: 0x0403A385 RID: 238469
			public const int TextBuildDoneTips1 = 37;

			// Token: 0x0403A386 RID: 238470
			public const int TextBuildDoneTips2 = 38;

			// Token: 0x0403A387 RID: 238471
			public const int CaptionItem = 39;

			// Token: 0x0403A388 RID: 238472
			public const int SpriteRoad = 40;

			// Token: 0x0403A389 RID: 238473
			public const int TextObserveStage = 41;
		}
	}
}
