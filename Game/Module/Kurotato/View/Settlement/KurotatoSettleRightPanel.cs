using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Kurotato.View.Settlement
{
	// Token: 0x02005A7A RID: 23162
	[NullableContext(1)]
	[Nullable(0)]
	public class KurotatoSettleRightPanel : UiPanelBase
	{
		// Token: 0x0603A9CB RID: 240075 RVA: 0x00ED8A29 File Offset: 0x00ED6C29
		public EKurotatoSettlePageState GetCurrentPageState()
		{
			return this.PageState;
		}

		// Token: 0x0603A9CC RID: 240076 RVA: 0x00ED8A34 File Offset: 0x00ED6C34
		protected unsafe override void OnRegisterComponent()
		{
			int num = 18;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIArtText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIMultiTemplateScrollViewComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(17, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603A9CD RID: 240077 RVA: 0x00ED8CB8 File Offset: 0x00ED6EB8
		protected override UniTask OnBeforeStartAsync()
		{
			KurotatoSettleRightPanel.<OnBeforeStartAsync>d__13 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<KurotatoSettleRightPanel.<OnBeforeStartAsync>d__13>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603A9CE RID: 240078 RVA: 0x00ED8CFC File Offset: 0x00ED6EFC
		private void SetupOpenParam()
		{
			this.PageState = (EKurotatoSettlePageState)this.OpenParam;
			IKurotatoSettlementData settlementData = ModelBase<KurotatoModel>.Instance.GetSettlementData();
			if (settlementData != null)
			{
				this.IsSuccess = settlementData.IsPass;
				int curLevelId = ModelBase<KurotatoModel>.Instance.GetCurLevelId();
				KurotatoLevel? kurotatoLevel;
				this.IsEndless = (((ConfigBase<KurotatoConfig>.Instance.GetLevelConfig(curLevelId) != null) ? new int?(kurotatoLevel.GetValueOrDefault().Difficulty) : null).GetValueOrDefault() == 3);
			}
		}

		// Token: 0x0603A9CF RID: 240079 RVA: 0x00ED8D88 File Offset: 0x00ED6F88
		private UniTask CreateCompletionTimeItemAsync()
		{
			KurotatoSettleRightPanel.<CreateCompletionTimeItemAsync>d__15 <CreateCompletionTimeItemAsync>d__;
			<CreateCompletionTimeItemAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateCompletionTimeItemAsync>d__.<>4__this = this;
			<CreateCompletionTimeItemAsync>d__.<>1__state = -1;
			<CreateCompletionTimeItemAsync>d__.<>t__builder.Start<KurotatoSettleRightPanel.<CreateCompletionTimeItemAsync>d__15>(ref <CreateCompletionTimeItemAsync>d__);
			return <CreateCompletionTimeItemAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603A9D0 RID: 240080 RVA: 0x00ED8DCC File Offset: 0x00ED6FCC
		private UniTask CreateTotalKillsItemAsync()
		{
			KurotatoSettleRightPanel.<CreateTotalKillsItemAsync>d__16 <CreateTotalKillsItemAsync>d__;
			<CreateTotalKillsItemAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateTotalKillsItemAsync>d__.<>4__this = this;
			<CreateTotalKillsItemAsync>d__.<>1__state = -1;
			<CreateTotalKillsItemAsync>d__.<>t__builder.Start<KurotatoSettleRightPanel.<CreateTotalKillsItemAsync>d__16>(ref <CreateTotalKillsItemAsync>d__);
			return <CreateTotalKillsItemAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603A9D1 RID: 240081 RVA: 0x00ED8E10 File Offset: 0x00ED7010
		private UniTask CreateEndlessCompletionTimeItemAsync()
		{
			KurotatoSettleRightPanel.<CreateEndlessCompletionTimeItemAsync>d__17 <CreateEndlessCompletionTimeItemAsync>d__;
			<CreateEndlessCompletionTimeItemAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateEndlessCompletionTimeItemAsync>d__.<>4__this = this;
			<CreateEndlessCompletionTimeItemAsync>d__.<>1__state = -1;
			<CreateEndlessCompletionTimeItemAsync>d__.<>t__builder.Start<KurotatoSettleRightPanel.<CreateEndlessCompletionTimeItemAsync>d__17>(ref <CreateEndlessCompletionTimeItemAsync>d__);
			return <CreateEndlessCompletionTimeItemAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603A9D2 RID: 240082 RVA: 0x00ED8E54 File Offset: 0x00ED7054
		private UniTask CreateEndlessTotalKillsItemAsync()
		{
			KurotatoSettleRightPanel.<CreateEndlessTotalKillsItemAsync>d__18 <CreateEndlessTotalKillsItemAsync>d__;
			<CreateEndlessTotalKillsItemAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateEndlessTotalKillsItemAsync>d__.<>4__this = this;
			<CreateEndlessTotalKillsItemAsync>d__.<>1__state = -1;
			<CreateEndlessTotalKillsItemAsync>d__.<>t__builder.Start<KurotatoSettleRightPanel.<CreateEndlessTotalKillsItemAsync>d__18>(ref <CreateEndlessTotalKillsItemAsync>d__);
			return <CreateEndlessTotalKillsItemAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603A9D3 RID: 240083 RVA: 0x00ED8E97 File Offset: 0x00ED7097
		private void CreateItemMultiTemplateScrollView()
		{
			this.ItemMultiTemplateScrollView = new MultiTemplateScrollView(base.GetMultiTemplateScrollViewComponent(14));
			this.RefreshScroll();
		}

		// Token: 0x0603A9D4 RID: 240084 RVA: 0x00ED8EB4 File Offset: 0x00ED70B4
		private void InitScrollViewData()
		{
			this.ScrollDataList.Clear();
			if (this.PageState == EKurotatoSettlePageState.Info)
			{
				this.ScrollDataList.AddRange(this.GetCurrentWeaponScrollData());
				this.ScrollDataList.AddRange(this.GetCurrentItemScrollData());
				return;
			}
			this.ScrollDataList.AddRange(this.GetRoleScrollData());
			this.ScrollDataList.AddRange(this.GetUnlockWeaponScrollData());
			this.ScrollDataList.AddRange(this.GetUnlockItemScrollData());
		}

		// Token: 0x0603A9D5 RID: 240085 RVA: 0x00ED8F2C File Offset: 0x00ED712C
		private List<IMultiTemplateGridData> GetRoleScrollData()
		{
			IKurotatoSettlementData settlementData = ModelBase<KurotatoModel>.Instance.GetSettlementData();
			List<int> unlockRoles = ((settlementData != null) ? settlementData.UnlockRoles : null) ?? new List<int>();
			if (unlockRoles.Count == 0)
			{
				return new List<IMultiTemplateGridData>();
			}
			List<IMultiTemplateGridData> list = new List<IMultiTemplateGridData>();
			list.Add(new GridTitleItemData
			{
				Data = new GridTitleItemDataInner
				{
					Title = "Kurotato_FinishprefabTilte_Unlock",
					Num = ""
				}
			});
			Action<RoleItem, bool> <>9__0;
			foreach (int data in unlockRoles)
			{
				RoleItemData roleItemData = new RoleItemData();
				roleItemData.Data = data;
				RoleItemData roleItemData2 = roleItemData;
				Action<RoleItem, bool> onClickCb;
				if ((onClickCb = <>9__0) == null)
				{
					onClickCb = (<>9__0 = delegate(RoleItem item, bool selected)
					{
						this.OnClickRoleItem(item.Data, unlockRoles);
					});
				}
				roleItemData2.OnClickCb = onClickCb;
				list.Add(roleItemData);
			}
			return list;
		}

		// Token: 0x0603A9D6 RID: 240086 RVA: 0x00ED9038 File Offset: 0x00ED7238
		private void OnClickRoleItem(int roleId, List<int> unlockRoles)
		{
			int index = unlockRoles.IndexOf(roleId);
			KurotatoPopupUnlockRoleOpenParam param = new KurotatoPopupUnlockRoleOpenParam
			{
				RoleIds = unlockRoles,
				Index = index
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.KurotatoPopupUnlockRoleView, param, null);
		}

		// Token: 0x0603A9D7 RID: 240087 RVA: 0x00ED9074 File Offset: 0x00ED7274
		private List<IMultiTemplateGridData> GetUnlockWeaponScrollData()
		{
			IKurotatoSettlementData settlementData = ModelBase<KurotatoModel>.Instance.GetSettlementData();
			List<int> unlockWeapons = ((settlementData != null) ? settlementData.UnlockWeapons : null) ?? new List<int>();
			if (unlockWeapons.Count == 0)
			{
				return new List<IMultiTemplateGridData>();
			}
			List<IMultiTemplateGridData> list = new List<IMultiTemplateGridData>();
			list.Add(new GridTitleItemData
			{
				Data = new GridTitleItemDataInner
				{
					Title = "Kurotato_FinishprefabTilte_Getweapon",
					Num = unlockWeapons.Count.ToString()
				}
			});
			for (int i = 0; i < unlockWeapons.Count; i++)
			{
				int id = unlockWeapons[i];
				int index = i;
				list.Add(new GridItemData
				{
					Data = new GridItemCellData
					{
						Item = new KurotatoSmallItemGridData
						{
							Type = EKurotatoCardType.Weapon,
							Id = id,
							IncId = 0,
							Count = 1
						},
						OnClick = delegate
						{
							List<KurotatoCardTip> list2 = new List<KurotatoCardTip>();
							foreach (int selectId in unlockWeapons)
							{
								list2.Add(new KurotatoCardTip
								{
									CardType = EKurotatoCardType.Weapon,
									SelectId = selectId,
									IsConfigId = new bool?(true)
								});
							}
							this.OnClickWeaponItem(list2, index);
						}
					}
				});
			}
			return list;
		}

		// Token: 0x0603A9D8 RID: 240088 RVA: 0x00ED91B0 File Offset: 0x00ED73B0
		private List<IMultiTemplateGridData> GetUnlockItemScrollData()
		{
			IKurotatoSettlementData settlementData = ModelBase<KurotatoModel>.Instance.GetSettlementData();
			KurotatoConfig kurotatoConfig = ConfigBase<KurotatoConfig>.Instance;
			List<int> unlockItems = new List<int>(((settlementData != null) ? settlementData.UnlockItems : null) ?? new List<int>());
			unlockItems.Sort(delegate(int a, int b)
			{
				KurotatoItem? itemConfigByItemId = kurotatoConfig.GetItemConfigByItemId(a);
				int num = (itemConfigByItemId != null) ? itemConfigByItemId.GetValueOrDefault().Quality : 0;
				itemConfigByItemId = kurotatoConfig.GetItemConfigByItemId(b);
				int num2 = (itemConfigByItemId != null) ? itemConfigByItemId.GetValueOrDefault().Quality : 0;
				if (num != num2)
				{
					return num2 - num;
				}
				return a - b;
			});
			if (unlockItems.Count == 0)
			{
				return new List<IMultiTemplateGridData>();
			}
			List<IMultiTemplateGridData> list = new List<IMultiTemplateGridData>();
			list.Add(new GridTitleItemData
			{
				Data = new GridTitleItemDataInner
				{
					Title = "Kurotato_FinishprefabTilte_Getitem",
					Num = unlockItems.Count.ToString()
				}
			});
			for (int i = 0; i < unlockItems.Count; i++)
			{
				int id = unlockItems[i];
				int index = i;
				list.Add(new GridItemData
				{
					Data = new GridItemCellData
					{
						Item = new KurotatoSmallItemGridData
						{
							Type = EKurotatoCardType.Item,
							Id = id,
							IncId = 0,
							Count = 1
						},
						OnClick = delegate
						{
							List<KurotatoCardTip> list2 = new List<KurotatoCardTip>();
							foreach (int selectId in unlockItems)
							{
								list2.Add(new KurotatoCardTip
								{
									CardType = EKurotatoCardType.Item,
									SelectId = selectId,
									IsConfigId = new bool?(true)
								});
							}
							this.OnClickItemItem(list2, index);
						}
					}
				});
			}
			return list;
		}

		// Token: 0x0603A9D9 RID: 240089 RVA: 0x00ED9314 File Offset: 0x00ED7514
		private List<IMultiTemplateGridData> GetCurrentWeaponScrollData()
		{
			IKurotatoSettlementData settlementData = ModelBase<KurotatoModel>.Instance.GetSettlementData();
			List<IMultiTemplateGridData> list = new List<IMultiTemplateGridData>();
			List<KurotatoWeaponData> weaponData = ((settlementData != null) ? settlementData.WeaponPanelData : null) ?? new List<KurotatoWeaponData>();
			KurotatoActivityConfig? kurotatoActivityConfig;
			int num = (ModelBase<KurotatoModel>.Instance.GetActivityConfig() != null) ? kurotatoActivityConfig.GetValueOrDefault().WeaponCount : weaponData.Count;
			GridTitleItemData gridTitleItemData = new GridTitleItemData();
			MultiTemplateGridDataBase<GridTitleItemDataInner, GridTitleItem> multiTemplateGridDataBase = gridTitleItemData;
			GridTitleItemDataInner gridTitleItemDataInner = new GridTitleItemDataInner();
			gridTitleItemDataInner.Title = "Kurotato_FinishprefabTilte_weapon";
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted<int>(weaponData.Count);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted<int>(num);
			gridTitleItemDataInner.Num = defaultInterpolatedStringHandler.ToStringAndClear();
			multiTemplateGridDataBase.Data = gridTitleItemDataInner;
			list.Add(gridTitleItemData);
			for (int i = 0; i < weaponData.Count; i++)
			{
				KurotatoWeaponData kurotatoWeaponData = weaponData[i];
				int index = i;
				list.Add(new GridItemData
				{
					Data = new GridItemCellData
					{
						Item = new KurotatoSmallItemGridData
						{
							Type = EKurotatoCardType.Weapon,
							Id = kurotatoWeaponData.WeaponId,
							IncId = kurotatoWeaponData.IncId,
							Count = 1
						},
						OnClick = delegate
						{
							List<KurotatoCardTip> list2 = new List<KurotatoCardTip>();
							foreach (KurotatoWeaponData kurotatoWeaponData2 in weaponData)
							{
								list2.Add(new KurotatoCardTip
								{
									CardType = EKurotatoCardType.Weapon,
									SelectId = kurotatoWeaponData2.IncId
								});
							}
							this.OnClickWeaponItem(list2, index);
						}
					}
				});
			}
			for (int j = weaponData.Count; j < num; j++)
			{
				list.Add(new GridItemData
				{
					Data = new GridItemCellData
					{
						Item = new KurotatoSmallItemGridData
						{
							Type = EKurotatoCardType.None,
							Id = 0,
							IncId = 0,
							Count = 0
						}
					}
				});
			}
			return list;
		}

		// Token: 0x0603A9DA RID: 240090 RVA: 0x00ED94FC File Offset: 0x00ED76FC
		private void OnClickWeaponItem(List<KurotatoCardTip> cardData, int clickIndex)
		{
			KurotatoPopupItemDetailOpenParam param = new KurotatoPopupItemDetailOpenParam
			{
				Index = clickIndex,
				CardData = cardData
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.KurotatoPopupWeaponDetailView, param, null);
		}

		// Token: 0x0603A9DB RID: 240091 RVA: 0x00ED9530 File Offset: 0x00ED7730
		private List<IMultiTemplateGridData> GetCurrentItemScrollData()
		{
			KurotatoConfig kurotatoConfig = ConfigBase<KurotatoConfig>.Instance;
			IKurotatoSettlementData settlementData = ModelBase<KurotatoModel>.Instance.GetSettlementData();
			List<IMultiTemplateGridData> list = new List<IMultiTemplateGridData>();
			List<KurotatoItemData> itemData = new List<KurotatoItemData>();
			foreach (KurotatoItemData kurotatoItemData in (((settlementData != null) ? settlementData.ItemPanelData : null) ?? new List<KurotatoItemData>()))
			{
				KurotatoItem? kurotatoItem;
				if (kurotatoConfig.GetItemConfigByItemId(kurotatoItemData.ItemId) != null && kurotatoItem.GetValueOrDefault().Type == 2)
				{
					itemData.Add(kurotatoItemData);
				}
			}
			itemData.Sort(delegate(KurotatoItemData a, KurotatoItemData b)
			{
				KurotatoItem? itemConfigByItemId = kurotatoConfig.GetItemConfigByItemId(a.ItemId);
				int num2 = (itemConfigByItemId != null) ? itemConfigByItemId.GetValueOrDefault().Quality : 0;
				itemConfigByItemId = kurotatoConfig.GetItemConfigByItemId(b.ItemId);
				int num3 = (itemConfigByItemId != null) ? itemConfigByItemId.GetValueOrDefault().Quality : 0;
				if (num2 != num3)
				{
					return num3 - num2;
				}
				return a.ItemId - b.ItemId;
			});
			if (itemData.Count == 0)
			{
				return new List<IMultiTemplateGridData>();
			}
			GridTitleItemData gridTitleItemData = new GridTitleItemData();
			int num = 0;
			foreach (KurotatoItemData kurotatoItemData2 in itemData)
			{
				num += kurotatoItemData2.Count;
			}
			gridTitleItemData.Data = new GridTitleItemDataInner
			{
				Title = "Kurotato_FinishprefabTilte_item",
				Num = num.ToString()
			};
			list.Add(gridTitleItemData);
			for (int i = 0; i < itemData.Count; i++)
			{
				KurotatoItemData kurotatoItemData3 = itemData[i];
				int index = i;
				list.Add(new GridItemData
				{
					Data = new GridItemCellData
					{
						Item = new KurotatoSmallItemGridData
						{
							Type = EKurotatoCardType.Item,
							Id = kurotatoItemData3.ItemId,
							IncId = 0,
							Count = kurotatoItemData3.Count,
							IsShowCount = new bool?(true)
						},
						OnClick = delegate
						{
							List<KurotatoCardTip> list2 = new List<KurotatoCardTip>();
							foreach (KurotatoItemData kurotatoItemData4 in itemData)
							{
								list2.Add(new KurotatoCardTip
								{
									CardType = EKurotatoCardType.Item,
									SelectId = kurotatoItemData4.ItemId,
									IsConfigId = new bool?(true)
								});
							}
							this.OnClickItemItem(list2, index);
						}
					}
				});
			}
			return list;
		}

		// Token: 0x0603A9DC RID: 240092 RVA: 0x00ED9760 File Offset: 0x00ED7960
		private void OnClickItemItem(List<KurotatoCardTip> cardData, int clickIndex)
		{
			KurotatoPopupItemDetailOpenParam param = new KurotatoPopupItemDetailOpenParam
			{
				Index = clickIndex,
				CardData = cardData
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.KurotatoPopupWeaponDetailView, param, null);
		}

		// Token: 0x0603A9DD RID: 240093 RVA: 0x00ED9792 File Offset: 0x00ED7992
		protected override void OnStart()
		{
			if (this.IsEndless)
			{
				this.RefreshEndlessMode();
				return;
			}
			this.RefreshNormalMode();
		}

		// Token: 0x0603A9DE RID: 240094 RVA: 0x00ED97A9 File Offset: 0x00ED79A9
		public void SetPageState(EKurotatoSettlePageState state)
		{
			this.PageState = state;
			this.RefreshScroll();
		}

		// Token: 0x0603A9DF RID: 240095 RVA: 0x00ED97B8 File Offset: 0x00ED79B8
		public void RefreshNormalMode()
		{
			this.RefreshModeInfo();
			IKurotatoSettlementData settlementData = ModelBase<KurotatoModel>.Instance.GetSettlementData();
			this.CompletionTimeItem.Refresh("Survivor_Wave", ((settlementData != null) ? settlementData.PassWaveCount : 0).ToString());
			this.TotalKillsItem.Refresh("Kurotato_Settle_TotalKills", ((settlementData != null) ? settlementData.CumulativeKills : 0).ToString());
			this.RefreshScroll();
		}

		// Token: 0x0603A9E0 RID: 240096 RVA: 0x00ED9824 File Offset: 0x00ED7A24
		public void RefreshEndlessMode()
		{
			this.RefreshModeInfo();
			IKurotatoSettlementData settlementData = ModelBase<KurotatoModel>.Instance.GetSettlementData();
			this.EndlessCompletionTimeItem.Refresh("Survivor_Wave", ((settlementData != null) ? settlementData.PassWaveCount : 0).ToString());
			this.EndlessTotalKillsItem.Refresh("Kurotato_Settle_TotalKills", ((settlementData != null) ? settlementData.CumulativeKills : 0).ToString());
			base.GetArtText(13).SetText(((settlementData != null) ? settlementData.PassWaveCount : 0).ToString());
			int num = (settlementData != null) ? settlementData.PassWaveCount : 0;
			foreach (KurotatoWaveLevel kurotatoWaveLevel in ConfigBase<KurotatoConfig>.Instance.GetWaveLevelConfigList())
			{
				if (kurotatoWaveLevel.WaveRange(0) <= num && num <= kurotatoWaveLevel.WaveRange(1))
				{
					base.SetTextureByPath(kurotatoWaveLevel.Icon, base.GetTexture(3), null, null);
					break;
				}
			}
			this.RefreshScroll();
		}

		// Token: 0x0603A9E1 RID: 240097 RVA: 0x00ED9934 File Offset: 0x00ED7B34
		private void RefreshModeInfo()
		{
			int curLevelId = ModelBase<KurotatoModel>.Instance.GetCurLevelId();
			KurotatoLevel? levelConfig = ConfigBase<KurotatoConfig>.Instance.GetLevelConfig(curLevelId);
			EKurotatoLevelDifficulty key = (EKurotatoLevelDifficulty)((levelConfig != null) ? levelConfig.GetValueOrDefault().Difficulty : 0);
			base.GetText(5).ShowTextNew(((levelConfig != null) ? levelConfig.GetValueOrDefault().Name : null) ?? "");
			string hexStr = KurotatoSettleRightPanel.DifficultyColorMap.GetValueOrDefault(key) ?? "#6a6a6a";
			base.GetTexture(4).SetColor(FColor.FromHex(hexStr));
			base.GetItem(0).SetUIActive(this.IsSuccess || this.IsEndless);
			base.GetItem(1).SetUIActive(!this.IsSuccess && !this.IsEndless);
			base.GetTexture(2).SetUIActive(!this.IsEndless);
			base.GetTexture(3).SetUIActive(this.IsEndless);
			base.GetItem(6).SetUIActive(!this.IsEndless);
			base.GetItem(10).SetUIActive(this.IsEndless);
		}

		// Token: 0x0603A9E2 RID: 240098 RVA: 0x00ED9A5C File Offset: 0x00ED7C5C
		private void RefreshScroll()
		{
			this.InitScrollViewData();
			MultiTemplateScrollViewRefreshContext multiTemplateScrollViewRefreshContext = new MultiTemplateScrollViewRefreshContext(this.ScrollDataList);
			multiTemplateScrollViewRefreshContext.ScrollToGridIndex = 0;
			this.ItemMultiTemplateScrollView.RefreshByData(multiTemplateScrollViewRefreshContext);
		}

		// Token: 0x04021287 RID: 135815
		[StaticVariableRuleIgnore]
		private static readonly IReadOnlyDictionary<EKurotatoLevelDifficulty, string> DifficultyColorMap = new Dictionary<EKurotatoLevelDifficulty, string>
		{
			{
				EKurotatoLevelDifficulty.TeachEasy,
				"#6a6a6a"
			},
			{
				EKurotatoLevelDifficulty.TeachDifficulty,
				"#6639d1"
			},
			{
				EKurotatoLevelDifficulty.Interest,
				"#4153db"
			},
			{
				EKurotatoLevelDifficulty.Endless,
				"#b12846"
			}
		};

		// Token: 0x04021288 RID: 135816
		private bool IsSuccess;

		// Token: 0x04021289 RID: 135817
		private bool IsEndless;

		// Token: 0x0402128A RID: 135818
		private EKurotatoSettlePageState PageState = EKurotatoSettlePageState.Info;

		// Token: 0x0402128B RID: 135819
		private readonly KurotatoSettleTipInfoItem CompletionTimeItem = new KurotatoSettleTipInfoItem();

		// Token: 0x0402128C RID: 135820
		private readonly KurotatoSettleTipInfoItem TotalKillsItem = new KurotatoSettleTipInfoItem();

		// Token: 0x0402128D RID: 135821
		private readonly KurotatoSettleTipInfoItem EndlessCompletionTimeItem = new KurotatoSettleTipInfoItem();

		// Token: 0x0402128E RID: 135822
		private readonly KurotatoSettleTipInfoItem EndlessTotalKillsItem = new KurotatoSettleTipInfoItem();

		// Token: 0x0402128F RID: 135823
		[Nullable(2)]
		private MultiTemplateScrollView ItemMultiTemplateScrollView;

		// Token: 0x04021290 RID: 135824
		private readonly List<IMultiTemplateGridData> ScrollDataList = new List<IMultiTemplateGridData>();

		// Token: 0x0200BA44 RID: 47684
		[NullableContext(0)]
		private class EComps
		{
			// Token: 0x04039851 RID: 235601
			public const int PanelSuccess = 0;

			// Token: 0x04039852 RID: 235602
			public const int PanelFailure = 1;

			// Token: 0x04039853 RID: 235603
			public const int TextureEndless = 2;

			// Token: 0x04039854 RID: 235604
			public const int TextureScore = 3;

			// Token: 0x04039855 RID: 235605
			public const int TextureBg = 4;

			// Token: 0x04039856 RID: 235606
			public const int TextMode = 5;

			// Token: 0x04039857 RID: 235607
			public const int PanelNormal = 6;

			// Token: 0x04039858 RID: 235608
			public const int PanelCompletionTime = 7;

			// Token: 0x04039859 RID: 235609
			public const int PanelTotalKills = 8;

			// Token: 0x0403985A RID: 235610
			public const int PanelUnlockInfo = 9;

			// Token: 0x0403985B RID: 235611
			public const int PanelEndless = 10;

			// Token: 0x0403985C RID: 235612
			public const int PanelEndlessCompletionTime = 11;

			// Token: 0x0403985D RID: 235613
			public const int PanelEndlessTotalKills = 12;

			// Token: 0x0403985E RID: 235614
			public const int ArtTextNum = 13;

			// Token: 0x0403985F RID: 235615
			public const int ScrollItem = 14;

			// Token: 0x04039860 RID: 235616
			public const int PanelTitle = 15;

			// Token: 0x04039861 RID: 235617
			public const int PanelItem = 16;

			// Token: 0x04039862 RID: 235618
			public const int PanelRole = 17;
		}
	}
}
