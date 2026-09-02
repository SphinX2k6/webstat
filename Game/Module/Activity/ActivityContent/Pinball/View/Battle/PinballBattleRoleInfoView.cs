using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.KuroSimpleCombat;
using CSharpScript.Game.KuroSimpleCombat.PB;
using CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Role;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Battle
{
	// Token: 0x0200663C RID: 26172
	[NullableContext(1)]
	[Nullable(0)]
	public class PinballBattleRoleInfoView : UiPanelBase
	{
		// Token: 0x17009F7A RID: 40826
		// (get) Token: 0x060415E6 RID: 267750 RVA: 0x010C4466 File Offset: 0x010C2666
		// (set) Token: 0x060415E7 RID: 267751 RVA: 0x010C446E File Offset: 0x010C266E
		public new IPinballBattleRoleInfoViewParam OpenParam { get; set; }

		// Token: 0x060415E8 RID: 267752 RVA: 0x010C4478 File Offset: 0x010C2678
		protected unsafe override void OnRegisterComponent()
		{
			int num = 20;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(16, typeof(USpineSkeletonAnimationComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(17, typeof(UUIVerticalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(18, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(19, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x060415E9 RID: 267753 RVA: 0x010C4740 File Offset: 0x010C2940
		protected override void OnStart()
		{
			this.InitRoleLayout();
			this.InitDetailTabLayout();
			this.InitSkillScroll();
			this.InitAttrScroll();
			this.InitBuffScroll();
			UUISprite sprite = base.GetSprite(4);
			this.OriginalHpBarWidth = ((sprite != null) ? sprite.GetWidth() : 0f);
			UUISprite sprite2 = base.GetSprite(6);
			this.OriginalShieldBarWidth = ((sprite2 != null) ? sprite2.GetWidth() : 0f);
		}

		// Token: 0x060415EA RID: 267754 RVA: 0x010C47A8 File Offset: 0x010C29A8
		protected override void OnBeforeShow()
		{
			List<PinballRoleHeadItemData> list = new List<PinballRoleHeadItemData>();
			for (int i = 0; i < this.OpenParam.RoleList.Count; i++)
			{
				int id = this.OpenParam.RoleList[i];
				PinballRoleConfig? pinballRoleConfigById = ConfigBase<PinballConfig>.Instance.GetPinballRoleConfigById(id);
				PinballRoleHeadItemData item = new PinballRoleHeadItemData
				{
					RoleConfig = pinballRoleConfigById.Value,
					IsSelected = (i == 0),
					IsLocked = false,
					IsTrail = pinballRoleConfigById.Value.IsTrail,
					NeedRedDot = false
				};
				list.Add(item);
			}
			GenericLayout<PinballRoleHeadItem, IPinballRoleHeadItemData> roleLayout = this.RoleLayout;
			if (roleLayout != null)
			{
				roleLayout.RefreshByData(list, null, false);
			}
			this.OnRoleHeadItemSelect(list[0]);
		}

		// Token: 0x060415EB RID: 267755 RVA: 0x010C485F File Offset: 0x010C2A5F
		private void InitRoleLayout()
		{
			this.RoleLayout = new GenericLayout<PinballRoleHeadItem, IPinballRoleHeadItemData>(base.GetVerticalLayout(17), new Func<PinballRoleHeadItem>(this.CreateRoleHeadItem), null, false, true);
		}

		// Token: 0x060415EC RID: 267756 RVA: 0x010C4883 File Offset: 0x010C2A83
		private PinballRoleHeadItem CreateRoleHeadItem()
		{
			return new PinballRoleHeadItem
			{
				OnSelectCallBack = delegate(IPinballRoleHeadItemData d)
				{
					this.OnRoleHeadItemSelect((PinballRoleHeadItemData)d);
				}
			};
		}

		// Token: 0x060415ED RID: 267757 RVA: 0x010C489C File Offset: 0x010C2A9C
		private void SelectRoleHeadData(PinballRoleHeadItemData data)
		{
			if (this.SelectedRoleHeadData != null)
			{
				this.SelectedRoleHeadData.IsSelected = false;
				GenericLayout<PinballRoleHeadItem, IPinballRoleHeadItemData> roleLayout = this.RoleLayout;
				if (roleLayout != null)
				{
					roleLayout.RefreshGridProxyByKey<int>(this.SelectedRoleHeadData.RoleConfig.Id);
				}
			}
			data.IsSelected = true;
			this.SelectedRoleHeadData = data;
			GenericLayout<PinballRoleHeadItem, IPinballRoleHeadItemData> roleLayout2 = this.RoleLayout;
			if (roleLayout2 == null)
			{
				return;
			}
			roleLayout2.RefreshGridProxyByKey<int>(data.RoleConfig.Id);
		}

		// Token: 0x060415EE RID: 267758 RVA: 0x010C4910 File Offset: 0x010C2B10
		private void OnRoleHeadItemSelect(PinballRoleHeadItemData data)
		{
			this.SelectRoleHeadData(data);
			this.RefreshRole(data.RoleConfig).Forget();
			PinballBdConfig? pinballBdConfigById = ConfigBase<PinballConfig>.Instance.GetPinballBdConfigById(data.RoleConfig.Bd);
			base.TrySetTextureByPath((pinballBdConfigById != null) ? pinballBdConfigById.GetValueOrDefault().MiddleIcon : null, base.GetTexture(0), null, null);
			Singleton<LguiUtil>.Instance.TrySetLocalTextNew(base.GetText(1), ModelBase<PinballModel>.Instance.GetRoleNameByPinballRoleConfig(data.RoleConfig), Array.Empty<object>());
			Singleton<LguiUtil>.Instance.TrySetLocalTextNew(base.GetText(2), "Pinball_Character_List_01", new <>z__ReadOnlySingleElementList<object>(data.RoleConfig.IsTrail ? data.RoleConfig.InitLevelId : ModelBase<PinballModel>.Instance.GetRoleLevel(data.RoleConfig.Id)));
			KscEntityHandle kscEntityByRoleId = (ControllerBase<KuroSimpleCombatController>.Instance.CurSubModel as PinballBattleSubModel).GetKscEntityByRoleId(data.RoleConfig.Id);
			if (kscEntityByRoleId == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.PinballBattle;
				ELogAuthor author = ELogAuthor.LJ;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(23, 1);
				defaultInterpolatedStringHandler.AppendLiteral("找不到角色id对应的KSC实体！RoleId：");
				defaultInterpolatedStringHandler.AppendFormatted<int>(data.RoleConfig.Id);
				instance.Error(module, author, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			AKSC_Entity kscEntity = kscEntityByRoleId.KscEntity;
			UKSC_SkillComp uksc_SkillComp = (kscEntity != null) ? kscEntity.GetSkillComp() : null;
			if (uksc_SkillComp == null)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.PinballBattle;
				ELogAuthor author2 = ELogAuthor.LJ;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(22, 1);
				defaultInterpolatedStringHandler.AppendLiteral("找不到角色id对应的技能组件！RoleId：");
				defaultInterpolatedStringHandler.AppendFormatted<int>(data.RoleConfig.Id);
				instance2.Error(module2, author2, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			UKSC_AttrSet attrSet_ = uksc_SkillComp.AttrSet_;
			if (attrSet_ == null)
			{
				Log instance3 = Singleton<Log>.Instance;
				ELogModule module3 = ELogModule.PinballBattle;
				ELogAuthor author3 = ELogAuthor.LJ;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(24, 1);
				defaultInterpolatedStringHandler.AppendLiteral("找不到角色id对应的技能属性组件！RoleId：");
				defaultInterpolatedStringHandler.AppendFormatted<int>(data.RoleConfig.Id);
				instance3.Error(module3, author3, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			int num;
			attrSet_.Attrs_.TryGetValue(EKSC_AttrType.Life, out num);
			int num2;
			attrSet_.Attrs_.TryGetValue(EKSC_AttrType.LifeMax, out num2);
			float num3 = (float)num / (float)num2;
			UUISprite sprite = base.GetSprite(4);
			if (sprite != null)
			{
				sprite.SetWidth(num3 * this.OriginalHpBarWidth);
			}
			UUIText text = base.GetText(3);
			if (text != null)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
				defaultInterpolatedStringHandler.AppendFormatted<int>(num);
				defaultInterpolatedStringHandler.AppendLiteral("/");
				defaultInterpolatedStringHandler.AppendFormatted<int>(num2);
				text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
			}
			int num4;
			attrSet_.Attrs_.TryGetValue(EKSC_AttrType.Shield, out num4);
			int num5;
			attrSet_.Attrs_.TryGetValue(EKSC_AttrType.ShieldMax, out num5);
			base.GetItem(19).SetUIActive(num4 > 0);
			base.GetSprite(6).SetUIActive(num4 > 0);
			if (num4 > 0)
			{
				float num6 = (float)num4 / (float)num5;
				base.GetSprite(6).SetWidth(num6 * this.OriginalShieldBarWidth);
				UUIText text2 = base.GetText(5);
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
				defaultInterpolatedStringHandler.AppendFormatted<int>(num4);
				defaultInterpolatedStringHandler.AppendLiteral("/");
				defaultInterpolatedStringHandler.AppendFormatted<int>(num5);
				text2.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
			}
			List<int> list = new List<int>();
			for (int i = 0; i < data.RoleConfig.SkillDisplayListLength; i++)
			{
				list.Add(data.RoleConfig.SkillDisplayList(i));
			}
			GenericScrollViewNew<PinballBattleRoleDetailSkillItem, int> skillScroll = this.SkillScroll;
			if (skillScroll != null)
			{
				skillScroll.RefreshByData(list, null, false);
			}
			List<PinballAttributeItemData> data2 = this.BuildAttrDataList(attrSet_.Attrs_);
			GenericScrollViewNew<PinballAttributeItem, IPinballAttributeItemData> attrScroll = this.AttrScroll;
			if (attrScroll != null)
			{
				attrScroll.RefreshByData(data2, null, false);
			}
			this.RefreshBuffScroll(uksc_SkillComp);
		}

		// Token: 0x060415EF RID: 267759 RVA: 0x010C4CD8 File Offset: 0x010C2ED8
		private void RefreshBuffScroll(UKSC_SkillComp skillComp)
		{
			TMap<UKSC_DA_Buff, int> tmap = new TMap<UKSC_DA_Buff, int>();
			skillComp.GetAllBuffs(ref tmap);
			List<BuffView> list = new List<BuffView>();
			foreach (KeyValuePair<UKSC_DA_Buff, int> keyValuePair in tmap)
			{
				UKSC_DA_Buff uksc_DA_Buff;
				int num;
				keyValuePair.Deconstruct(out uksc_DA_Buff, out num);
				UKSC_DA_Buff key = uksc_DA_Buff;
				int buffCount = num;
				UKuroSimpleCombatSubsystem kscSubsystem = Singleton<KscEnv>.Instance.KscSubsystem;
				int? num2;
				if (kscSubsystem == null)
				{
					num2 = null;
				}
				else
				{
					UKSC_World kscworld = kscSubsystem.GetKSCWorld();
					num2 = ((kscworld != null) ? new int?(kscworld.LoadedBuffDa.Get(key)) : null);
				}
				int? num3 = num2;
				if (num3 != null)
				{
					BuffView buffView = ModelBase<PinballModel>.Instance.CreateBuffView(num3.Value, buffCount);
					if (buffView != null)
					{
						list.Add(buffView);
					}
				}
			}
			if (list.Count > 0)
			{
				list.Sort((BuffView a, BuffView b) => b.Sort - a.Sort);
				GenericScrollViewNew<PinballBattleRoleDetailBuffItem, BuffView> buffScroll = this.BuffScroll;
				if (buffScroll != null)
				{
					buffScroll.RefreshByData(list, null, false);
				}
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
				GenericScrollViewNew<PinballBattleRoleDetailBuffItem, BuffView> buffScroll2 = this.BuffScroll;
				if (buffScroll2 != null)
				{
					buffScroll2.RefreshByData(list, null, false);
				}
				UUIItem item2 = base.GetItem(9);
				if (item2 == null)
				{
					return;
				}
				item2.SetUIActive(true);
				return;
			}
		}

		// Token: 0x060415F0 RID: 267760 RVA: 0x010C4E30 File Offset: 0x010C3030
		private List<PinballAttributeItemData> BuildAttrDataList(TMap<EKSC_AttrType, int> attrs)
		{
			List<PinballAttributeItemData> list = new List<PinballAttributeItemData>();
			int id = ModelBase<PinballModel>.Instance.ActivityData.Id;
			PinballActivity? pinballActivityConfigByActivityId = ConfigBase<PinballConfig>.Instance.GetPinballActivityConfigByActivityId(id);
			if (pinballActivityConfigByActivityId == null)
			{
				return list;
			}
			int battleAttrShowListLength = pinballActivityConfigByActivityId.Value.BattleAttrShowListLength;
			for (int i = 0; i < battleAttrShowListLength; i++)
			{
				int num = pinballActivityConfigByActivityId.Value.BattleAttrShowList(i);
				PinballPropertyIndex? pinballPropertyIndexConfigById = ConfigBase<PinballConfig>.Instance.GetPinballPropertyIndexConfigById(num);
				if (pinballPropertyIndexConfigById == null)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Pinball;
					ELogAuthor author = ELogAuthor.CB;
					string message = "属性配置不存在";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("attrId", num);
					instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				}
				else
				{
					EPinballAttr epinballAttr = (EPinballAttr)num;
					int attributeValue;
					if (epinballAttr != EPinballAttr.Atk)
					{
						if (epinballAttr != EPinballAttr.CritDamage)
						{
							int num2;
							attrs.TryGetValue((EKSC_AttrType)pinballPropertyIndexConfigById.Value.KscAttrType, out num2);
							attributeValue = num2;
						}
						else
						{
							int num3;
							attrs.TryGetValue(EKSC_AttrType.CritDamage, out num3);
							attributeValue = num3 + 10000;
						}
					}
					else
					{
						int num4;
						attrs.TryGetValue(EKSC_AttrType.Atk, out num4);
						int num5;
						attrs.TryGetValue(EKSC_AttrType.AtkChange, out num5);
						int num6;
						attrs.TryGetValue(EKSC_AttrType.AtkExtra, out num6);
						attributeValue = (int)Math.Ceiling((double)((float)num4 * (1f + (float)num5 * 0.0001f) + (float)num6));
					}
					PinballAttributeItemData item = new PinballAttributeItemData
					{
						IsBgShow = (i % 2 == 1),
						AttributeConfig = pinballPropertyIndexConfigById.Value,
						AttributeValue = attributeValue
					};
					list.Add(item);
				}
			}
			return list;
		}

		// Token: 0x060415F1 RID: 267761 RVA: 0x010C4FB0 File Offset: 0x010C31B0
		private UniTask RefreshRole(PinballRoleConfig config)
		{
			PinballBattleRoleInfoView.<RefreshRole>d__22 <RefreshRole>d__;
			<RefreshRole>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshRole>d__.<>4__this = this;
			<RefreshRole>d__.config = config;
			<RefreshRole>d__.<>1__state = -1;
			<RefreshRole>d__.<>t__builder.Start<PinballBattleRoleInfoView.<RefreshRole>d__22>(ref <RefreshRole>d__);
			return <RefreshRole>d__.<>t__builder.Task;
		}

		// Token: 0x060415F2 RID: 267762 RVA: 0x010C4FFC File Offset: 0x010C31FC
		private void InitDetailTabLayout()
		{
			this.DetailTabLayout = new GenericLayout<PinballBattleRoleDetailTabItem, EPinballBattleRoleDetailTabType>(base.GetHorizontalLayout(7), new Func<PinballBattleRoleDetailTabItem>(this.CreateDetailTabItem), null, false, true);
			List<EPinballBattleRoleDetailTabType> data = new List<EPinballBattleRoleDetailTabType>
			{
				EPinballBattleRoleDetailTabType.Buff,
				EPinballBattleRoleDetailTabType.Attr,
				EPinballBattleRoleDetailTabType.Skill
			};
			GenericLayout<PinballBattleRoleDetailTabItem, EPinballBattleRoleDetailTabType> detailTabLayout = this.DetailTabLayout;
			if (detailTabLayout == null)
			{
				return;
			}
			detailTabLayout.RefreshByData(data, delegate
			{
				GenericLayout<PinballBattleRoleDetailTabItem, EPinballBattleRoleDetailTabType> detailTabLayout2 = this.DetailTabLayout;
				if (detailTabLayout2 == null)
				{
					return;
				}
				detailTabLayout2.SelectGridProxy(0, true);
			}, false);
		}

		// Token: 0x060415F3 RID: 267763 RVA: 0x010C5063 File Offset: 0x010C3263
		private PinballBattleRoleDetailTabItem CreateDetailTabItem()
		{
			return new PinballBattleRoleDetailTabItem
			{
				OnSelectCallBack = new Action<EPinballBattleRoleDetailTabType>(this.OnDetailTabItemSelect)
			};
		}

		// Token: 0x060415F4 RID: 267764 RVA: 0x010C507C File Offset: 0x010C327C
		private void OnDetailTabItemSelect(EPinballBattleRoleDetailTabType data)
		{
			switch (data)
			{
			case EPinballBattleRoleDetailTabType.Buff:
			{
				UUIScrollViewWithScrollbarComponent scrollViewWithScrollbar = base.GetScrollViewWithScrollbar(14);
				if (scrollViewWithScrollbar != null)
				{
					scrollViewWithScrollbar.RootUIComp.Get().SetUIActive(true);
				}
				UUIScrollViewWithScrollbarComponent scrollViewWithScrollbar2 = base.GetScrollViewWithScrollbar(12);
				if (scrollViewWithScrollbar2 != null)
				{
					scrollViewWithScrollbar2.RootUIComp.Get().SetUIActive(false);
				}
				UUIScrollViewWithScrollbarComponent scrollViewWithScrollbar3 = base.GetScrollViewWithScrollbar(10);
				if (scrollViewWithScrollbar3 == null)
				{
					return;
				}
				scrollViewWithScrollbar3.RootUIComp.Get().SetUIActive(false);
				return;
			}
			case EPinballBattleRoleDetailTabType.Attr:
			{
				UUIScrollViewWithScrollbarComponent scrollViewWithScrollbar4 = base.GetScrollViewWithScrollbar(14);
				if (scrollViewWithScrollbar4 != null)
				{
					scrollViewWithScrollbar4.RootUIComp.Get().SetUIActive(false);
				}
				UUIScrollViewWithScrollbarComponent scrollViewWithScrollbar5 = base.GetScrollViewWithScrollbar(12);
				if (scrollViewWithScrollbar5 != null)
				{
					scrollViewWithScrollbar5.RootUIComp.Get().SetUIActive(true);
				}
				UUIScrollViewWithScrollbarComponent scrollViewWithScrollbar6 = base.GetScrollViewWithScrollbar(10);
				if (scrollViewWithScrollbar6 == null)
				{
					return;
				}
				scrollViewWithScrollbar6.RootUIComp.Get().SetUIActive(false);
				return;
			}
			case EPinballBattleRoleDetailTabType.Skill:
			{
				UUIScrollViewWithScrollbarComponent scrollViewWithScrollbar7 = base.GetScrollViewWithScrollbar(14);
				if (scrollViewWithScrollbar7 != null)
				{
					scrollViewWithScrollbar7.RootUIComp.Get().SetUIActive(false);
				}
				UUIScrollViewWithScrollbarComponent scrollViewWithScrollbar8 = base.GetScrollViewWithScrollbar(12);
				if (scrollViewWithScrollbar8 != null)
				{
					scrollViewWithScrollbar8.RootUIComp.Get().SetUIActive(false);
				}
				UUIScrollViewWithScrollbarComponent scrollViewWithScrollbar9 = base.GetScrollViewWithScrollbar(10);
				if (scrollViewWithScrollbar9 == null)
				{
					return;
				}
				scrollViewWithScrollbar9.RootUIComp.Get().SetUIActive(true);
				return;
			}
			default:
				return;
			}
		}

		// Token: 0x060415F5 RID: 267765 RVA: 0x010C51C4 File Offset: 0x010C33C4
		private void InitSkillScroll()
		{
			this.SkillScroll = new GenericScrollViewNew<PinballBattleRoleDetailSkillItem, int>(base.GetScrollViewWithScrollbar(10), new Func<PinballBattleRoleDetailSkillItem>(this.CreateSkillItem), null, false, null);
		}

		// Token: 0x060415F6 RID: 267766 RVA: 0x010C51E8 File Offset: 0x010C33E8
		private PinballBattleRoleDetailSkillItem CreateSkillItem()
		{
			return new PinballBattleRoleDetailSkillItem();
		}

		// Token: 0x060415F7 RID: 267767 RVA: 0x010C51EF File Offset: 0x010C33EF
		private void InitAttrScroll()
		{
			this.AttrScroll = new GenericScrollViewNew<PinballAttributeItem, IPinballAttributeItemData>(base.GetScrollViewWithScrollbar(12), new Func<PinballAttributeItem>(this.CreateAttrItem), null, false, null);
		}

		// Token: 0x060415F8 RID: 267768 RVA: 0x010C5213 File Offset: 0x010C3413
		private PinballAttributeItem CreateAttrItem()
		{
			return new PinballAttributeItem();
		}

		// Token: 0x060415F9 RID: 267769 RVA: 0x010C521A File Offset: 0x010C341A
		private void InitBuffScroll()
		{
			this.BuffScroll = new GenericScrollViewNew<PinballBattleRoleDetailBuffItem, BuffView>(base.GetScrollViewWithScrollbar(14), new Func<PinballBattleRoleDetailBuffItem>(this.CreateBuffItem), null, false, null);
		}

		// Token: 0x060415FA RID: 267770 RVA: 0x010C523E File Offset: 0x010C343E
		private PinballBattleRoleDetailBuffItem CreateBuffItem()
		{
			return new PinballBattleRoleDetailBuffItem();
		}

		// Token: 0x040248EF RID: 149743
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<PinballRoleHeadItem, IPinballRoleHeadItemData> RoleLayout;

		// Token: 0x040248F0 RID: 149744
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericLayout<PinballBattleRoleDetailTabItem, EPinballBattleRoleDetailTabType> DetailTabLayout;

		// Token: 0x040248F1 RID: 149745
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericScrollViewNew<PinballBattleRoleDetailSkillItem, int> SkillScroll;

		// Token: 0x040248F2 RID: 149746
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericScrollViewNew<PinballAttributeItem, IPinballAttributeItemData> AttrScroll;

		// Token: 0x040248F3 RID: 149747
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericScrollViewNew<PinballBattleRoleDetailBuffItem, BuffView> BuffScroll;

		// Token: 0x040248F4 RID: 149748
		private float OriginalHpBarWidth;

		// Token: 0x040248F5 RID: 149749
		private float OriginalShieldBarWidth;

		// Token: 0x040248F6 RID: 149750
		[Nullable(2)]
		private PinballRoleHeadItemData SelectedRoleHeadData;

		// Token: 0x0200C660 RID: 50784
		[NullableContext(0)]
		private enum EComponent
		{
			// Token: 0x0403D11F RID: 250143
			TexRoleType,
			// Token: 0x0403D120 RID: 250144
			TxtRoleName,
			// Token: 0x0403D121 RID: 250145
			TxtRoleLevel,
			// Token: 0x0403D122 RID: 250146
			TxtHpNum,
			// Token: 0x0403D123 RID: 250147
			SpriteHpBar,
			// Token: 0x0403D124 RID: 250148
			TxtShieldNum,
			// Token: 0x0403D125 RID: 250149
			SpriteShieldBar,
			// Token: 0x0403D126 RID: 250150
			DetailTabLayout,
			// Token: 0x0403D127 RID: 250151
			DetailTabLayoutItem,
			// Token: 0x0403D128 RID: 250152
			DetailEmpty,
			// Token: 0x0403D129 RID: 250153
			ScrollSkill,
			// Token: 0x0403D12A RID: 250154
			ScrollSkillItem,
			// Token: 0x0403D12B RID: 250155
			ScrollAttr,
			// Token: 0x0403D12C RID: 250156
			ScrollAttrItem,
			// Token: 0x0403D12D RID: 250157
			ScrollBuff,
			// Token: 0x0403D12E RID: 250158
			BuffLayoutItem,
			// Token: 0x0403D12F RID: 250159
			SpineRole,
			// Token: 0x0403D130 RID: 250160
			RoleHeadLayout,
			// Token: 0x0403D131 RID: 250161
			RoleHeadLayoutItem,
			// Token: 0x0403D132 RID: 250162
			PnlShiledNum
		}
	}
}
